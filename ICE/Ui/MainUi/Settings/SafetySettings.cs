using Dalamud.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Ui.MainUi.Settings
{
    internal class SafetySettings
    {
        private static bool rejectUnknownYesNo = C.RejectUnknownYesno;
        private static bool delayGrabMission = C.DelayGrabMission;
        private static int delayAmount = C.DelayIncrease;
        private static bool delayCraft = C.DelayCraft;
        private static int delayCraftAmount = C.DelayCraftIncrease;

        public static void Draw()
        {
            ImGuiEx.IconWithText(FontAwesomeIcon.ExclamationTriangle, "安全设置");
            ImGui.Dummy(new Vector2(0, 5));

            if (ImGui.Checkbox("忽略非宇宙提示", ref rejectUnknownYesNo))
            {
                C.RejectUnknownYesno = rejectUnknownYesNo;
                C.Save();
            }
            ImGuiEx.HelpMarker(
                "警告！这是避免加入随机队伍的安全功能！\n" +
                "如果你取消选中此功能，你将加入随机聚会邀请。\n" +
                "您已被警告。禁用后果自负。"
            );
            if (ImGui.Checkbox("添加延迟任务菜单", ref delayGrabMission))
            {
                C.DelayGrabMission = delayGrabMission;
                C.Save();
            }
            ImGuiEx.HelpMarker(
                "这是为了安全！如果你想减少任务之间的延迟，请便。\n" +
                "安全性约为……250？如果你有动画锁，你完全可以为了刷信用点把它调得更高，或者如果你很勇敢就调低。我不是你爸爸（不过我会讲爸爸笑话）。");
            if (delayGrabMission)
            {
                ImGui.SetNextItemWidth(150);
                ImGui.SameLine();
                if (ImGui.SliderInt("ms###Mission", ref delayAmount, 0, 1000))
                {
                    if (C.DelayIncrease != delayAmount)
                    {
                        C.DelayIncrease = delayAmount;
                        C.SaveDebounced();
                    }
                }
            }
            if (ImGui.Checkbox("添加制作菜单延迟", ref delayCraft))
            {
                C.DelayCraft = delayCraft;
                C.Save();
            }
            ImGuiEx.HelpMarker(
                "这是为了安全！如果你想减少延迟，请便。\n" +
                "安全性约为……2500？如果你有动画锁，你完全可以为了刷信用点把它调得更高，或者如果你很勇敢就调低。我不是你爸爸（不过我会讲爸爸笑话）。");
            if (delayCraft)
            {
                ImGui.SetNextItemWidth(150);
                ImGui.SameLine();
                if (ImGui.SliderInt("ms###Crafting", ref delayCraftAmount, 500, 5000))
                {
                    if (C.DelayCraftIncrease != delayCraftAmount)
                    {
                        C.DelayCraftIncrease = delayCraftAmount;
                        C.SaveDebounced();
                    }
                }
            }
            int delayRelic = C.DelayPostRelic;
            ImGui.SetNextItemWidth(150);
            if (ImGui.SliderInt("延迟宇宙工具上交后", ref delayRelic, 0, 5000))
            {
                C.DelayPostRelic = delayRelic;
                C.SaveDebounced();
            }
            bool gatherDelay = C.Delay_Gather;
            if (ImGui.Checkbox("添加采集延迟", ref gatherDelay))
            {
                C.Delay_Gather = gatherDelay;
                C.Save();
            }
            bool closeRewardPopup = C.HideRewardWindow;
            if (ImGui.Checkbox("自动关闭奖励弹出窗口", ref closeRewardPopup))
            {
                C.HideRewardWindow = closeRewardPopup;
                C.Save();
            }
        }
    }
}
