using Dalamud.Interface;
using ICE.Utilities.Cosmic_Helper;
using Lumina.Excel.Sheets;

namespace ICE.Ui.Debug_Tabs.Debug_Tables
{
    internal class Table_FishInfo
    {
        public static void Draw()
        {
            var fishMissions = CosmicHelper.SheetMissionDict.Where(x => x.Value.Jobs.Contains(18))
                .OrderBy(x => x.Key)
                .ToDictionary();

            if (ImGui.BeginTable("钓鱼信息", 6, ImGuiTableFlags.RowBg | ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("任务ID");
                ImGui.TableSetupColumn("任务名称");
                ImGui.TableSetupColumn("属性");
                ImGui.TableSetupColumn("具体的");
                ImGui.TableSetupColumn("总要求");
                ImGui.TableSetupColumn("品种要求", ImGuiTableColumnFlags.WidthStretch);

                ImGui.TableHeadersRow();

                foreach (var mission in fishMissions)
                {
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"{mission.Key}");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{mission.Value.Name}");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{mission.Value.Attributes}");

                    ImGui.TableNextColumn();
                    if (mission.Value.Gathering_Min.Count > 0)
                    {
                        ImGuiEx.Icon(FontAwesomeIcon.Fish);
                        if (ImGui.IsItemHovered())
                        {
                            ImGui.BeginTooltip();

                            if (ImGui.BeginTable("鱼项信息", 3, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders))
                            {
                                foreach (var fishItem in mission.Value.Gathering_Min)
                                {
                                    ImGui.TableNextRow();
                                    ImGui.TableSetColumnIndex(0);
                                    if (Svc.Data.GetExcelSheet<Item>().TryGetRow(fishItem.Key, out var fishInfo))
                                    {
                                        ImGui.Text($"{fishInfo.Name.ToString()}");
                                    }

                                    ImGui.TableNextColumn();
                                    ImGui.Text($"{fishItem.Value}");

                                    ImGui.TableNextColumn();
                                    ImGui.Text($"{fishItem.Key}");
                                }

                                ImGui.EndTable();
                            };

                            ImGui.EndTooltip();
                        }
                    }
                    else
                    {
                        ImGui.Text("-");
                    }

                    ImGui.TableNextColumn();
                    ImGui.Text($"{mission.Value.Fish_AmountRequired}");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{mission.Value.Fish_VarietyAmount}");
                }

                ImGui.EndTable();
            }
        }
    }
}
