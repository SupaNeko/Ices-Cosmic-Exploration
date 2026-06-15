using System;
using System.Collections.Generic;
using System.Text;

namespace ICE.Ui.MainUi.HelpFolder.Tips_Folder
{
    internal class Welcome
    {
        public static void Draw()
        {
            ImGui.TextWrapped($"欢迎！这可能是迄今为止我创建的最复杂的插件。");
            ImGui.TextWrapped($"这个插件是专门为宇宙探索的使用而设计的，而且有点重。因此，我将尝试并完成所有不同的提示/技巧");

            ImGui.Dummy(new(0, 5));

            ImGui.TextWrapped("在旁边，您会发现几个不同的选项卡，它们将“尝试”并回答您可能遇到的任何问题。");
            ImGui.TextWrapped("请务必检查要求部分以了解您需要什么");
            ImGui.TextWrapped("或者只是阅读一个特定的选项卡来找出答案。可能会回答很多问题");
        }
    }
}
