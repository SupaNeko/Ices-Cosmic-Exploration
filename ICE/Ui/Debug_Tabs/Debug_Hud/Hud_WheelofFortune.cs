using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ICE.Ui.Debug_Tabs.Debug_Hud
{
    internal class Hud_WheelofFortune
    {
        public static void Draw()
        {
            if (ImGui.Button($"自动抽奖"))
            {
                Task_Gamba.Enqueue();
            }

            if (GenericHelpers.TryGetAddonMaster<WKSLottery>("WKSLottery", out var lotto) && lotto.IsAddonReady)
            {
                ImGui.Text($"Lottery 插件可见！");

                if (ImGui.Button($"左轮选择"))
                {
                    Task_Gamba.SelectWheelLeft(lotto);
                }
                ImGui.SameLine();

                if (ImGui.Button($"右轮选择"))
                {
                    Task_Gamba.SelectWheelRight(lotto);
                }

                ImGui.SameLine();
                if (ImGui.Button($"确认"))
                {
                    lotto.ConfirmButton();
                }

                if (ImGui.Button($"自动抽奖"))
                {
                    Task_Gamba.Enqueue();
                }

                ImGui.Text($"左轮中的项目");
                foreach (var l in lotto.LeftWheelItems)
                {
                    ImGui.Text($"Name: {l.itemName} | Id: {l.itemId} | Amount: {l.itemAmount}");
                }

                ImGui.Spacing();
                foreach (var m in lotto.RightWheelItems)
                {
                    ImGui.Text($"Name: {m.itemName} | Id: {m.itemId} | Amount: {m.itemAmount}");
                }
            }
            else
            {
                ImGui.Text("等待“WKSLotery”可见");
            }
        }
    }
}
