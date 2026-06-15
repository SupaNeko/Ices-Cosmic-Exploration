using Lumina.Excel.Sheets;

namespace ICE.Ui.Debug_Tabs.Debug_Tables
{
    internal class Table_TimeWeather
    {
        public static unsafe void Draw()
        {
            var timeSheet = Svc.Data.GetExcelSheet<WKSMissionLotterySpecialCond>();

            if (ImGui.BeginTable($"WKSMission时间表", 4, ImGuiTableFlags.SizingFixedFit))
            {
                ImGui.TableSetupColumn("钥匙");
                ImGui.TableSetupColumn("需要天气");
                ImGui.TableSetupColumn("开始时间");
                ImGui.TableSetupColumn("结束时间");

                ImGui.TableHeadersRow();

                foreach (var entry in timeSheet)
                {
                    ImGui.TableNextRow();

                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"{entry.RowId}");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{entry.WeatherRequired.Value.Name}"); // Unknown 0

                    ImGui.TableNextColumn();
                    ImGui.Text($"{entry.StartTimeHour}"); // Unknown 1

                    ImGui.TableNextColumn();
                    ImGui.Text($"{entry.EndTimeHour}"); // Unknown 2

                }

                ImGui.EndTable();
            }
        }
    }
}
