using ECommons.GameHelpers;
using ICE.Utilities.Cosmic_Helper;
using ICE.Utilities.GatheringHelper;
using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ICE.Ui.Debug_Tabs.Debug_Hud
{
    internal class Hud_CollectableGathering
    {
        public static unsafe void Draw()
        {
            if (GenericHelpers.TryGetAddonMaster<GatheringMasterpiece>("GatheringMasterpiece", out var gatherCollect) && gatherCollect.IsAddonReady)
            {
                if (ImGui.Button("尝试采集"))
                {
                    Task_Gather.CollectableGather(gatherCollect);
                }
                ImGui.SameLine();
                if (ImGui.Button("重置增益检查"))
                {
                    Mission_Settings.Collectable_BuffCount = GatheringUtil.CollectStandardCharges();
                }

                ImGuiTableFlags tableFlags = ImGuiTableFlags.RowBg |
                             ImGuiTableFlags.Borders |
                             ImGuiTableFlags.SizingFixedFit |
                             ImGuiTableFlags.Resizable |           // Allow column resizing
                             ImGuiTableFlags.Reorderable |         // Allow column reordering
                             ImGuiTableFlags.Hideable;             // Allow hiding columns via right-click

                if (ImGui.BeginTable("Gathering_Collectable", 2, tableFlags))
                {
                    ImGui.TableSetupColumn("##AddonInfo");
                    ImGui.TableSetupColumn("##AddonValue");

                    // Row 1
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("项目名称： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.ItemName}");

                    // Row 2
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("项目ID： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.ItemID}");

                    // Row 3
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("当前收藏价值： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.CurrentCollectability}");

                    // Row 4
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("项目完整性： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.CurrentIntegrity} / {gatherCollect.TotalIntegrity}");

                    // Row 5
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("Min收藏度： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.MinCollectability}");

                    // Row 6
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("中收藏度： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.MidCollectability}");

                    // Row 7
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("高收藏性： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.HighCollectability}");

                    // Row 8
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("最大收藏价值： ");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.MaxCollectability}");

                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"冲刷量");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.ScourPower}");

                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"黄铜力量");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.BrazenPowerMin} | {gatherCollect.BrazenPowerMax}");

                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"细致力量");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{gatherCollect.MeticulousPower}");

                    ImGui.EndTable();
                }
            }
            else if (GenericHelpers.TryGetAddonMaster<Gathering>("采集", out var gather) && gather.IsAddonReady)
            {
                if (ImGui.Button("Increase可收藏性"))
                {
                    foreach (var item in gather.GatheredItems)
                    {
                        if (item.ItemID != 0)
                        {
                            bool missingDur = gather.CurrentIntegrity < gather.TotalIntegrity;
                            bool useAction = Task_Gather.UseGatherAction(0, item.GatherChance, item.BoonChance, gather.CurrentIntegrity, gather.TotalIntegrity, PlayerHelper.GetGp());
                            IceLogging.Debug($"Used action: {useAction}");
                            break;
                        }
                    }
                }
            }
            else
            {
                ImGui.Text("等待采集窗口可见");
            }
        }
    }
}
