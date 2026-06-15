using Dalamud.Interface;
using ICE.Utilities.ImGuiTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICE.Ui.MainUi.Settings
{
    internal class Shop_Dronebit
    {
        public static void Draw()
        {
            if (ImGui.Button("运行无人机Finder"))
            {
                SchedulerMain.State = IceState.ArtifactSearch;
            }

            if (ImGui.Button("停止"))
            {
                SchedulerMain.DisablePlugin();
            }

            bool buyDrones = C.Cosmodrone_Buy;
            if (ImGui.Checkbox("购买无人机", ref buyDrones))
            {
                C.Cosmodrone_Buy = buyDrones;
                C.Save();
            }
            ImGui_Ice.IconWithTooltip(FontAwesomeIcon.QuestionCircle, 
                "您想购买无人机吗？如果是，请启用此"
                );

            int drone_buyAtAmount = C.Cosmodrone_BuyAt;
            ImGui.SetNextItemWidth(200);
            if (ImGui.SliderInt("按金额购买", ref drone_buyAtAmount, 200, 5000))
            {
                drone_buyAtAmount = (int)Math.Round(drone_buyAtAmount / 200.0) * 200;
                C.Cosmodrone_BuyAt = drone_buyAtAmount;
                C.SaveDebounced();
            }
            ImGui_Ice.IconWithTooltip(FontAwesomeIcon.QuestionCircle, 
                "您想从供应商那里购买无人机吗？\n" +
                "设置增量为200，最大为5,000"
                );

            int maxCrateAmount = C.Cosmodrone_MaxKeep;
            ImGui.SetNextItemWidth(200);
            if (ImGui.InputInt("最大无人机", ref maxCrateAmount))
            {
                if (maxCrateAmount < 0)
                    maxCrateAmount = 0;
                C.Cosmodrone_MaxKeep = maxCrateAmount;
                C.SaveDebounced();
            }
            ImGui_Ice.IconWithTooltip(FontAwesomeIcon.QuestionCircle,
                "你想要保留的无人机的最大数量是多少？\n" +
                "0 = 将继续购买\n" +
                "任何高于0的东西都将只是一个硬上限，如果达到这个就会停止购买"
                );

            bool runDroneFinder = C.Cosmodrone_Run;
            if (ImGui.Checkbox("自动化cosmodrone", ref runDroneFinder))
            {
                C.Cosmodrone_Run = runDroneFinder;
                C.Save();
            }
            ImGui_Ice.IconWithTooltip(FontAwesomeIcon.QuestionCircle,
                "您想运行自动无人机查找吗？如果是，请启用此\n" +
                "请不要这样做。");
        }
    }
}
