using Dalamud.Interface;
using Dalamud.Interface.Utility.Raii;
using ECommons.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICE.Ui.MainUi.HelpFolder
{
    internal class helpSelect_Required
    {
        public static void Draw()
        {
            ImGui.TextWrapped("这些是插件运行所需的以下插件的列表。如果您没有安装这些，它将无法正常运行");

            ImGui.Separator();
            ImGuiEx.IconWithText(FontAwesomeIcon.Hammer, "制作");
            HasPlugin("https://love.puni.sh/ment.json", "Artisan");

            ImGui.Separator();
            ImGuiEx.IconWithText(FontAwesomeIcon.Feather, "收集");
            ImGui.Text("For 植物学家/矿工/渔民");
            HasPlugin("https://puni.sh/api/repository/veyn", "vnavmesh");
            ImGui.Dummy(new Vector2(0, 10));
            ImGui.Text("仅适用于渔民");
            HasPlugin("https://love.puni.sh/ment.json", "自动挂钩");

            ImGui.Separator();
            ImGuiEx.IconWithText(FontAwesomeIcon.Running, "自动化中心活动");
            HasPlugin("https://puni.sh/api/repository/veyn", "vnavmesh");

            ImGui.Separator();
            ImGui.TextWrapped("这不是必需的，但强烈建议用于升级角色。它将自动从你的军械库/库存中装备装备，并在运行练级研磨模式时将其更换");
            ImGuiEx.IconWithText(FontAwesomeIcon.Leaf, "造型师");
            HasPlugin("https://raw.githubusercontent.com/NightmareXIV/MyDalamudPlugins/main/pluginmaster.json", "造型师");
        }

        public static void HasPlugin(string repo, string pluginName)
        {
            bool isInstalled = DalamudReflector.HasRepo($"{repo}");
            if (isInstalled)
            {
                FontAwesome.Print(EColor.Green, FontAwesome.Check);
                ImGui.SameLine();
                ImGui.Text($"{pluginName} Repo is Installed");
            }
            else
            {
                FontAwesome.Print(EColor.Red, FontAwesome.Cross);
                ImGui.SameLine();
                if (ImGui.Button($"Install {pluginName} Repo"))
                {
                    DalamudReflector.AddRepo(repo, true);
                    DalamudReflector.SaveDalamudConfig();
                }
            }

            bool hasPlugin = Utils.HasPlugin($"{pluginName}");

            if (hasPlugin)
            {
                FontAwesome.Print(EColor.Green, FontAwesome.Check);
                ImGui.SameLine();
                ImGui.Text($"{pluginName} is installed");
            }
            else
            {
                FontAwesome.Print(EColor.Red, FontAwesome.Cross);
                ImGui.SameLine();
                using (ImRaii.Disabled(installingPlugin))
                {
                    if (ImGui.Button($"Install {pluginName}"))
                    {
                        _ = InstallPlugin(repo, pluginName);
                    }
                }
            }
        }

        private static bool installingPlugin = false;
        private static async Task InstallPlugin(string repo, string pluginName)
        {
            if (installingPlugin) return; // Already installing

            installingPlugin = true;
            try
            {
                await DalamudReflector.AddPlugin(repo, pluginName);
                DalamudReflector.SaveDalamudConfig();
            }
            finally
            {
                installingPlugin = false;
            }
        }
    }
}
