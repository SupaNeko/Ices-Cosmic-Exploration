using FFXIVClientStructs.FFXIV.Client.Game.UI;
using ICE.Ui.MainUi.HelpFolder.Tips_Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICE.Ui.MainUi.HelpFolder
{
    internal class helpSelect_Tips
    {
        public enum Help_Selection
        {
            Welcome,
            ModeSelection,
            AgendaMode, 

        }

        private static Help_Selection selectedMode = Help_Selection.Welcome;

        private static string EnumString(Help_Selection tipSelected)
        {
            return tipSelected switch
            {
                Help_Selection.Welcome => "Welcome",
                Help_Selection.ModeSelection => "模式选择",
                Help_Selection.AgendaMode => "宇宙议程",
                _ => tipSelected.ToString()
            };
        }

        private static readonly Dictionary<Help_Selection, Action> TipViews = new()
        {
            [Help_Selection.Welcome] = () => Welcome.Draw(),
            [Help_Selection.ModeSelection] = () => ModeSelection.Draw(),
        };

        public static void Draw()
        {
            float spacing = 10f;
            float leftPanelWidth = 200f;
            float rightPanelWidth = ImGui.GetContentRegionAvail().X - leftPanelWidth - spacing;
            float childHeight = ImGui.GetContentRegionAvail().Y;

            if (ImGui.BeginChild("提示选择器", new Vector2(leftPanelWidth, childHeight), true))
            {
                foreach (Help_Selection tip in Enum.GetValues<Help_Selection>())
                {
                    bool isSelected = tip == selectedMode;
                    if (ImGui.Selectable($"{EnumString(tip)}", isSelected))
                    {
                        selectedMode = tip;
                    }
                }
            }
            ImGui.EndChild();

            ImGui.SameLine(0, spacing);
            if (ImGui.BeginChild("DebugContent", new System.Numerics.Vector2(rightPanelWidth, childHeight), true))
            {
                if (TipViews.TryGetValue(selectedMode, out var drawAction))
                {
                    drawAction();
                }
                else
                {
                    ImGui.Text("未知提示查看");
                }
            }
            ImGui.EndChild();
        }

        private static void ScoreMax()
        {
            ImGui.TextWrapped("每个星球都有一组专门的任务，在刷分方面被认为是最“最佳”的。" +
                "\n有某些任务比其他任务更值得刷取。天气/限时也是其中的一部分。以下是我针对每个职业的建议。");
            ImGui.TextWrapped("");
        }
    }
}
