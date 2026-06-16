using Dalamud.Interface;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Utility;
using Lumina.Excel.Sheets;
using System.Collections.Generic;
using static ICE.ConfigFiles.Config;

namespace ICE.Ui.MainUi.Settings
{
    internal class ShoppingTab
    {
        private static string ItemSearch = string.Empty;
        private static ImGuiEx.RealtimeDragDrop<uint> MaterialDragDrop = new("MaterialShop", (id) => id.ToString());
        private static ImGuiEx.RealtimeDragDrop<uint> GearDragDrop = new("GearShop", (id) => id.ToString());

        public static unsafe void Draw()
        {
            float minContentWidth = 920 * ImGuiHelpers.GlobalScale;
            var availWidth = ImGui.GetContentRegionAvail().X;
            if (availWidth < minContentWidth)
                ImGui.SetNextWindowContentSize(new Vector2(minContentWidth, 0));

            using var scrollChild = ImRaii.Child("##shoppingTabScroll", new Vector2(0, 0), false, ImGuiWindowFlags.HorizontalScrollbar);
            if (!scrollChild.Success) return;

            bool BuyItems = C.BuyItems;

            if (ImGui.Checkbox("购买物品", ref BuyItems))
            {
                C.BuyItems = BuyItems;
                C.StopOnceHitCosmoCredits = false;
                C.Save();
            }
            ImGui.SameLine();
            ImGuiEx.Icon(FontAwesomeIcon.QuestionCircle);
            if (ImGui.IsItemHovered())
            {
                ImGui.BeginTooltip();
                ImGui.Text("这是您可以创建的个性化购物清单，当您达到一定数量的信用点时它将运行。");
                ImGui.Text("以下是以下各项的作用：");
                ImGui.BulletText("保持：将购买最多数量的物品，以确保您的库存中有足够的物品。此计数在运行之间不会减少。\n" +
                                 "对于像强心剂之类的东西很有用，你想要手头上总是有一定数量的");
                ImGui.BulletText("购买：将购买 X 数量的这些物品，当它从供应商处购买时，数量会减少，直到达到 0.\n" +
                                 "适合一次性购买，或者您只需要特定数量的");
                ImGui.BulletText("保持 Buying：一旦满足其他2个（保留/购买），如果有信用点，它将不断购买该物品。\n" +
                                 "这只能设置为 1 个项目，通常用于您只想花费信用点的东西");
                ImGui.EndTooltip();
            }
            ImGui.NewLine();

            int buyAtAmount = C.CosmoBuyAtAmount;
            int CosmoKeepAmount = C.CosmoKeepAmount;

            ImGui.SetNextItemWidth(150);
            if (ImGui.SliderInt("当你购买物品时达到", ref buyAtAmount, 0, 30000))
            {
                C.CosmoBuyAtAmount = buyAtAmount;
                C.SaveDebounced();
            }

            ImGui.SetNextItemWidth(150);
            if (ImGui.SliderInt("保留这么多宇宙信用点", ref CosmoKeepAmount, 0, buyAtAmount))
            {
                C.CosmoKeepAmount = CosmoKeepAmount;
                C.SaveDebounced();
            }

            CheckConfigState();
            if (Task_BuyCosmoItems.CanPurchaseAnyItem())
            {
                ImGui.Text("您可以从列表中购买宇宙信用点项目！");
            }
            else
            {
                ImGui.Text("您无法使用当前的信用值/项目购买任何项目（很好，这只是一个测试）");
            }

            if (ImGui.Button("添加材质/染料/物品"))
            {
                ImGui.OpenPopup("CosmocreditMateriaPopup");
            }

            ImGui.SameLine();

            if (ImGui.Button("添加装甲/房屋/坐骑"))
            {
                ImGui.OpenPopup("Cosmocredit_MountArmorPopup");
            }

            ImGui.SameLine();
            
            if (ImGui.Button("清除购物清单"))
            {
                C.CosmoShopping.Clear();
                C.CosmoShoppingOrder.Clear();
                C.CosmoShoppingOrder_Gear.Clear();

                C.Save();
            }

            DrawAddItemPopups();

            ImGui.Separator();
            ImGui.NewLine();

            DrawShoppingTable("Armor/Housing/Mounts", Shop_Cosmocredits.Shop_MountsCards, C.CosmoShoppingOrder_Gear, GearDragDrop);

            // Draw separate tables for each shop type

            ImGui.NewLine();

            DrawShoppingTable("Materials/Dyes/Items", Shop_Cosmocredits.Shop_MateriaDye, C.CosmoShoppingOrder, MaterialDragDrop);
        }

        private static void DrawAddItemPopups()
        {
            ImGui.SetNextWindowSize(new Vector2(400, 0), ImGuiCond.Appearing);

            if (ImGui.BeginPopup("CosmocreditMateriaPopup"))
            {
                ImGui.SetNextItemWidth(380);
                ImGui.InputText("##Item Search", ref ItemSearch, 256);

                ImGui.Spacing();

                if (ImGui.BeginTable("Cosmo材料店", 2, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.ScrollY | ImGuiTableFlags.RowBg, new Vector2(0, 250)))
                {
                    ImGui.TableSetupColumn("图标", ImGuiTableColumnFlags.WidthFixed, 20);
                    ImGui.TableSetupColumn("名称", ImGuiTableColumnFlags.WidthStretch);

                    foreach (var item in Shop_Cosmocredits.Shop_MateriaDye)
                    {
                        DrawShopItemRow(item.Key, C.CosmoShoppingOrder);
                    }
                    ImGui.EndTable();
                }

                ImGui.EndPopup();
            }

            if (ImGui.BeginPopup("Cosmocredit_MountArmorPopup"))
            {
                ImGui.SetNextItemWidth(380);
                ImGui.InputText("##Item Search2", ref ItemSearch, 256);

                ImGui.Spacing();

                if (ImGui.BeginTable("Cosmo装备店", 2, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.ScrollY | ImGuiTableFlags.RowBg, new Vector2(0, 250)))
                {
                    ImGui.TableSetupColumn("图标", ImGuiTableColumnFlags.WidthFixed, 20);
                    ImGui.TableSetupColumn("名称", ImGuiTableColumnFlags.WidthStretch);

                    foreach (var item in Shop_Cosmocredits.Shop_MountsCards)
                    {
                        DrawShopItemRow(item.Key, C.CosmoShoppingOrder_Gear);
                    }
                    ImGui.EndTable();
                }

                ImGui.EndPopup();
            }
        }

        private static void DrawShopItemRow(uint id, List<uint> orderList)
        {
            if (Svc.Data.GetExcelSheet<Item>().TryGetRow(id, out var itemInfo))
            {
                var name = itemInfo.Name.ToString();

                if (!ItemSearch.IsNullOrWhitespace() && !name.ToLower().Contains(ItemSearch.ToLower()))
                {
                    return;
                }

                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.PushID(id);

                if (itemInfo.Icon is { } itemIcon && Svc.Texture.TryGetFromGameIcon((int)itemIcon, out var texture))
                {
                    ImGui.Image(texture.GetWrapOrEmpty().Handle, new Vector2(20, 20));
                }

                ImGui.TableNextColumn();
                ImGui.Text($"{itemInfo.Name}");

                if (ImGui.IsItemHovered() && ImGui.IsItemClicked(ImGuiMouseButton.Left))
                {
                    AddItemToList(id, orderList);
                    C.Save();
                }

                ImGui.PopID();
            }
        }

        private static void DrawShoppingTable(string tableName, Dictionary<uint, Shop_Cosmocredits.ItemInfo> shopData, List<uint> orderList, ImGuiEx.RealtimeDragDrop<uint> dragDrop)
        {
            if (orderList.Count == 0)
            {
                ImGui.TextDisabled($"No items in {tableName} shopping list");
                return;
            }

            ImGui.Text($"{tableName} ({orderList.Count} items)");

            dragDrop.Begin();

            if (ImGui.BeginTable($"Shopping_{tableName}", 10, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("命令", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("名称");
                ImGui.TableSetupColumn("有", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("成本", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("种类", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("解锁", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("保持", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("买", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("继续购买", ImGuiTableColumnFlags.WidthFixed);
                ImGui.TableSetupColumn("", ImGuiTableColumnFlags.WidthFixed);

                ImGui.TableHeadersRow();

                for (int i = 0; i < orderList.Count; i++)
                {
                    uint itemId = orderList[i];
                    DrawShoppingItemRow(itemId, shopData, i, orderList, dragDrop);
                }

                ImGui.EndTable();
            }

            dragDrop.End();
        }

        private static void DrawShoppingItemRow(uint itemId, Dictionary<uint, Shop_Cosmocredits.ItemInfo> shopData, int index, List<uint> orderList, ImGuiEx.RealtimeDragDrop<uint> dragDrop)
        {
            var setting = C.CosmoShopping[itemId];
            var itemInfo = Svc.Data.GetExcelSheet<Item>().GetRow(itemId);

            ImGui.TableNextRow();
            dragDrop.NextRow();
            dragDrop.SetRowColor(itemId);

            ImGui.PushID(itemId);

            // Drag/Drop Handle - MUCH SIMPLER NOW!
            ImGui.TableSetColumnIndex(0);
            dragDrop.DrawButtonDummy(itemId, orderList, index);

            // Name
            ImGui.TableNextColumn();
            if (itemInfo.Icon is { } itemIcon && Svc.Texture.TryGetFromGameIcon((int)itemIcon, out var texture))
            {
                ImGui.Image(texture.GetWrapOrEmpty().Handle, new Vector2(24, 24));
                ImGui.SameLine();
            }
            ImGui.Text($"{itemInfo.Name}");

            // Have
            ImGui.TableNextColumn();
            PlayerHelper.GetItemCount(itemId, out var count);
            ImGui.Text($"{count}");

            // Cost
            ImGui.TableNextColumn();
            if (shopData.TryGetValue(itemId, out var shopInfo))
            {
                ImGui.Text($"{shopInfo.Cost:N0}");
            }

            // Kind
            ImGui.TableNextColumn();
            string kind = itemInfo.ItemUICategory.Value.Name.ToString();
            ImGui.Text(kind);

            // Unlocked (for consumable items like mounts, orchestrion rolls, cards, etc.)
            ImGui.TableNextColumn();
            ImGui.TextUnformatted(UnlockState.IsItemUnlockable(itemInfo) ? UnlockState.IsItemUnlocked(itemInfo) ? "Yes" : "No" : "-");

            // Keep Amount
            ImGui.TableNextColumn();
            ImGui.SetNextItemWidth(80);
            var keepAmount = setting.KeepAmount;
            if (ImGui.InputInt($"##keep_{itemId}", ref keepAmount))
            {
                setting.KeepAmount = Math.Max(0, keepAmount);
                C.SaveDebounced();
            }

            // Buy Amount
            ImGui.TableNextColumn();
            ImGui.SetNextItemWidth(80);
            var buyAmount = setting.BuyAmount;
            if (ImGui.InputInt($"##buy_{itemId}", ref buyAmount))
            {
                setting.BuyAmount = Math.Max(0, buyAmount);
                C.SaveDebounced();
            }

            // Keep Buying
            ImGui.TableNextColumn();
            var keepBuying = setting.KeepBuying;
            if (ImGui.Checkbox($"##keepbuying_{itemId}", ref keepBuying))
            {
                foreach (var enabled in C.CosmoShopping)
                {
                    enabled.Value.KeepBuying = false;
                }

                setting.KeepBuying = keepBuying;
                C.Save();
            }

            // Remove Button
            ImGui.TableNextColumn();
            if (ImGuiEx.IconButton(FontAwesomeIcon.Trash, $"##remove_{itemId}"))
            {
                RemoveItem(itemId, orderList);
                C.Save();
            }

            ImGui.PopID();
        }

        private static void AddItemToList(uint itemId, List<uint> orderList)
        {
            if (C.CosmoShopping.ContainsKey(itemId))
                return;

            C.CosmoShopping[itemId] = new CosmoShoppingList();
            orderList.Add(itemId);
        }

        private static void RemoveItem(uint itemId, List<uint> orderList)
        {
            C.CosmoShopping.Remove(itemId);
            orderList.Remove(itemId);
        }

        public static void CheckConfigState()
        {
            if (C.CosmoShopping == null)
            {
                C.CosmoShopping = new();
                C.Save();
            }
            if (C.CosmoShoppingOrder == null)
            {
                C.CosmoShoppingOrder = new();
                C.Save();
            }
            if (C.CosmoShoppingOrder_Gear == null)
            {
                C.CosmoShoppingOrder_Gear = new();
                C.Save();
            }
        }
    }
}