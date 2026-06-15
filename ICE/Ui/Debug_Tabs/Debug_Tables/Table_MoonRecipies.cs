using ICE.Utilities.Cosmic_Helper;

namespace ICE.Ui.Debug_Tabs.Debug_Tables
{
    internal class Table_MoonRecipies
    {
        private static string RecipeTableSearchText = "";

        public static unsafe void Draw()
        {
            ImGui.SetNextItemWidth(250);
            ImGui.InputText("按名称搜索", ref RecipeTableSearchText, 100);

            ImGuiTableFlags tableFlags = ImGuiTableFlags.RowBg |
                            ImGuiTableFlags.Borders |
                            ImGuiTableFlags.SizingFixedFit |
                            ImGuiTableFlags.Resizable |           // Allow column resizing
                            ImGuiTableFlags.Reorderable |         // Allow column reordering
                            ImGuiTableFlags.Hideable;             // Allow hiding columns via right-click

            if (ImGui.BeginTable("任务信息列表", 14, tableFlags))
            {
                ImGui.TableSetupColumn("钥匙");
                ImGui.TableSetupColumn("任务名称");
                ImGui.TableSetupColumn("主工艺1");
                ImGui.TableSetupColumn("金额 [1]");
                ImGui.TableSetupColumn("主工艺2");
                ImGui.TableSetupColumn("金额 [2]");
                ImGui.TableSetupColumn("主工艺3");
                ImGui.TableSetupColumn("金额 [3]");
                ImGui.TableSetupColumn("预制[1]");
                ImGui.TableSetupColumn("金额 [1]");
                ImGui.TableSetupColumn("前期制作 [2]");
                ImGui.TableSetupColumn("金额 [2]");
                ImGui.TableSetupColumn("前期制作 [3]");
                ImGui.TableSetupColumn("金额 [3]");

                ImGui.TableHeadersRow();

                foreach (var entry in CosmicHelper.SheetMissionDict)
                {
                    if (entry.Value.Jobs.Any(x => CosmicHelper.CrafterJobList.Contains(x)))
                    {
                        if (!string.IsNullOrEmpty(RecipeTableSearchText) &&
                            !entry.Value.Name.ToLower().Contains(RecipeTableSearchText.ToLower()))
                            continue;

                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text($"{entry.Key}");

                        ImGui.TableNextColumn();
                        var missionName = CosmicHelper.SheetMissionDict.First(x => x.Key == entry.Key).Value.Name;
                        ImGui.Text($"{missionName}");

                        // Column #2
                        foreach (var mainCraft in entry.Value.Crafts_Main)
                        {
                            ImGui.TableNextColumn();
                            ImGui.Text($"{mainCraft.Value.ItemId}");
                            if (ImGui.IsItemHovered())
                            {
                                ImGui.BeginTooltip();
                                ImGui.Text($"RecipeID: {mainCraft.Key}");
                                string itemName = ExcelHelper.ItemSheet.GetRow(mainCraft.Value.ItemId).Name.ToString();
                                ImGui.Text($"项目名称： {itemName}");
                                ImGui.Separator();
                                ImGui.Text($"项目ID： {mainCraft.Value.ItemId}");
                                ImGui.Text($"Necessary Amount: {mainCraft.Value.RequiredAmount}");
                                ImGui.Text($"Recipe ID: {mainCraft.Value.RecipeId}");
                                ImGui.Text($"Expert Craft: {mainCraft.Value.ExpertCraft}");
                                ImGui.Separator();
                                ImGui.Text($"必需项目");
                                foreach (var item in mainCraft.Value.RequiredItems)
                                {
                                    ImGui.Text($"Id: {item.Key}");
                                    ImGui.Text($"Amount: {item.Value}");
                                }

                                ImGui.EndTooltip();
                            }

                            ImGui.TableNextColumn();
                            ImGui.Text($"{mainCraft.Value.RequiredAmount}");
                        }

                        ImGui.TableSetColumnIndex(7);
                        if (entry.Value.Crafts_Pre.Count > 0)
                        {
                            foreach (var preCraft in entry.Value.Crafts_Pre)
                            {
                                ImGui.TableNextColumn();
                                ImGui.Text($"{preCraft.Value.ItemId}");
                                if (ImGui.IsItemHovered())
                                {
                                    ImGui.BeginTooltip();
                                    ImGui.Text($"RecipeID: {preCraft.Key}");
                                    string itemName = ExcelHelper.ItemSheet.GetRow(preCraft.Value.ItemId).Name.ToString();
                                    ImGui.Text($"项目名称： {itemName}");
                                    ImGui.Separator();
                                    ImGui.Text($"项目ID： {preCraft.Value.ItemId}");
                                    ImGui.Text($"Necessary Amount: {preCraft.Value.RequiredAmount}");
                                    ImGui.Text($"Recipe ID: {preCraft.Value.RecipeId}");
                                    ImGui.Text($"Expert Craft: {preCraft.Value.ExpertCraft}");
                                    ImGui.Separator();
                                    ImGui.Text($"必需项目");
                                    foreach (var item in preCraft.Value.RequiredItems)
                                    {
                                        string itemNameC = ExcelHelper.ItemSheet.GetRow(item.Key).Name.ToString();
                                        ImGui.Text($"{itemNameC}");
                                        ImGui.Text($"Id: {item.Key}");
                                        ImGui.Text($"Amount: {item.Value}");
                                    }

                                    ImGui.EndTooltip();
                                }

                                ImGui.TableNextColumn();
                                ImGui.Text($"{preCraft.Value.RequiredAmount}");
                            }
                        }
                    }
                }

                ImGui.EndTable();
            }
        }
    }
}
