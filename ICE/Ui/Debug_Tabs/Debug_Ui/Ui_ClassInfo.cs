using Dalamud.Interface.Utility.Raii;
using ICE.Utilities.Cosmic_Helper;

namespace ICE.Ui.Debug_Tabs.Debug_Ui
{
    internal class Ui_ClassInfo
    {
        public static void Draw()
        {
            var classInfo = CosmicHelper.Cosmic_ClassInfo();

            using var tabBar = ImRaii.TabBar("宇宙职业信息");
            if (!tabBar) return;

            foreach (var item in classInfo)
            {
                using var tabItem = ImRaii.TabItem($"作业 {item.Key}");
                if (!tabItem) continue;

                ImGui.Text($"Score: {item.Value.Score}");
                ImGui.Separator();

                using var table = ImRaii.Table($"ClassInfo_{item.Key}", 2,
                    ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.SizingFixedFit);
                if (!table) continue;

                // Set up columns
                ImGui.TableSetupColumn("属性", ImGuiTableColumnFlags.WidthFixed, 150f);
                ImGui.TableSetupColumn("价值", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();

                // Current Stage
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.Text("当前阶段");
                ImGui.TableNextColumn();
                ImGui.Text($"{item.Value.Stage_Current}");

                // Next Stage
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.Text("下一阶段");
                ImGui.TableNextColumn();
                ImGui.Text($"{item.Value.Stage_Next}");

                // Experience entries
                foreach (var exp in item.Value.CurrentExp)
                {
                    ImGui.TableNextRow();
                    ImGui.TableNextColumn();
                    ImGui.Text(exp.Value.Name);
                    ImGui.TableNextColumn();
                    ImGui.Text($"{exp.Value.Current} / {exp.Value.Needed} (Max: {exp.Value.Max})");
                }
            }
        }
    }
}