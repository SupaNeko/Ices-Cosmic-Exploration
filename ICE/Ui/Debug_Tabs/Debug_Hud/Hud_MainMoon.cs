using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ICE.Ui.Debug_Tabs.Debug_Hud
{
    internal class Hud_MainMoon
    {
        public static void Draw()
        {
            if (GenericHelpers.TryGetAddonMaster<WKSHud>("WKSHud", out var HudAddon))
            {
                if (ImGui.Button("任务"))
                {
                    HudAddon.Mission();
                }

                ImGui.SameLine();

                if (ImGui.Button("机甲"))
                {
                    HudAddon.Mech();
                }

                ImGui.SameLine();

                if (ImGui.Button("斯特勒"))
                {
                    HudAddon.Steller();
                }

                ImGui.SameLine();

                if (ImGui.Button("基础设施"))
                {
                    HudAddon.Infrastructor();
                }

                ImGui.SameLine();

                if (ImGui.Button("研究"))
                {
                    HudAddon.Research();
                }

                ImGui.SameLine();

                if (ImGui.Button("职业追踪器"))
                {
                    HudAddon.ClassTracker();
                }
            }
            else
            {
                ImGui.Text("等待“WKShud”可见");
            }
        }
    }
}
