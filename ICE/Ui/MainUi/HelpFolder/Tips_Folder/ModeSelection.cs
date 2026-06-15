using Dalamud.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICE.Ui.MainUi.HelpFolder.Tips_Folder
{
    internal class ModeSelection
    {
        public static void Draw()
        {
            ImGui.TextWrapped("当前存在5种不同的模式（截至撰写本文时），所有模式都提供略有不同的功能。");
            ImGui.TextWrapped("取决于你想要什么/什么你的目标是，这些都服务于所有不同的功能。");

            if (ImGui.BeginTabBar("模式选择信息"))
            {
                if (ImGui.BeginTabItem("标准"))
                {
                    StandardMode();
                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("遗物研磨"))
                {
                    RelicGrind();
                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("议程模式"))
                {
                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }
        }

        private static void StandardMode()
        {
            ImGui.Dummy(new(0, 5));
            ImGuiEx.IconWithText(FontAwesomeIcon.List, "标准");
            ImGui.TextWrapped(
                "最简单的模式。标准仅运行您已启用的任务 " +
                "对于您当前的课程 - 您选择您想要完成的事情，它会处理其余的事情。");
            ImGui.TextWrapped("这使您可以完全控制要运行的任务，使其非常适合：");
            ImGui.BulletText("Score Farming - 选择特定的高价值任务");
            ImGui.BulletText("Exp研磨");
            ImGui.BulletText("信用/行星积分/代币耕作");
            ImGui.TextWrapped(
                "基本任务（等级D→A）只会从您开始的职业中提取。 " +
                "将选择临时任务（天气、定时和顺序）和红色警报 " +
                "任务之间 - 启用多职业设置以允许切换这些职业。");
        }

        private static void RelicGrind()
        {
            ImGui.Dummy(new(0, 5));
            ImGuiEx.IconWithText(FontAwesomeIcon.ArrowUpRightDots, "遗物研磨");

            ImGui.TextWrapped(
                "A模式旨在以最小的干预自动选择遗物进展的任务。 " +
                "它扫描所有可用任务，评估每个任务提供的经验，并选择其中之一 " +
                "为您当前的级别提供最大的收益。");
            ImGui.TextWrapped(
                "如果你很高足够级别需要下一个等级职业，但尚未解锁 " +
                "（例如，D 级已完成，但 C 级尚未解锁），请确保在开始之前手动解锁。");
            ImGui.TextWrapped("注意：此模式不会为您交换行星。每个行星还有一个经验上限：");
            ImGui.BulletText("Sinus — Rank IV Max");
            ImGui.BulletText("Phaenna — 等级V Max");
            ImGui.BulletText("Oizys— 等级 VI Max");
        }

        public static void GoldCompletion()
        {

        }
    }
}
