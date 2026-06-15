using Dalamud.Interface;
using Dalamud.Interface.Textures;
using Dalamud.Interface.Utility.Raii;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using ICE.Ui.MainUi.ModeSelect_Modes;
using ICE.Ui.MainUi.ModeSelect_Modes.CosmicTable;
using ICE.Utilities.Cosmic_Helper;
using ICE.Utilities.GatheringHelper;
using ICE.Utilities.ImGuiTools;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TerraFX.Interop.Windows;
using static ICE.ConfigFiles.Config.MissionSettings;
using static MissionTimer;

namespace ICE.Ui
{
    internal class Window_ExternalDetails : Window
    {
        public static uint SelectedMission = 0;

        public static List<string> JokeList = new()
        {
            "海盗最喜欢的字母是什么？\n" +
            "你可能认为它是 R，但它的初恋是 C\n" +
            "（如果您像海盗一样口头说出它会有所帮助）",

            "你知道，我最近在读这本关于反重力的书，\n" +
            "老实说，我很难把它放下",

            "为什么网球职业选手总是互相拥抱？\n" +
            "因为他们在“Love All”开始比赛",

            "为什么幽灵不能生孩子？\n" +
            "因为他们有万圣节",

            "您如何拯救溺水海盗？\n" +
            "您给他Cprrrrrrr",

            "骷髅最喜欢的零食是什么？\n" +
            "排骨！备用肋骨！",

            "老实说，只是想说谢谢您使用我的插件，非常感谢<3",

            "Knock Knock\n" +
            "[This is where you say who's there]\n" +
            "Lettuce\n" +
            "[Lettuce who]\n" +
            "生菜",

            "你是一只只有一只眼睛的恐龙吗？" +
            "A“Doyouthinkheseemesaurs”",

            "所以...你是在告诉我这米饭是虾炒的吗？",

            "感谢所有帮助实现这一目标的人。\n" +
            "Strife 特别感谢你做了我不想钓鱼的事情\n" +
            "（抱歉让您开始大鱼 #NotSorry#MuchLove)\n" +
            "哇谢谢你的UI，这他妈的很漂亮总是\n" +
            "Puni.sh一般为您帮助我的每一个愚蠢的问题"
        };
        public static int jokeId = 0;

        public Window_ExternalDetails() : base($"Ice 的宇宙探索 |任务详细信息")
        {
            Flags = ImGuiWindowFlags.None;
            SizeConstraints = new()
            {
                MinimumSize = new Vector2(500, 500)
            };
            P.windowSystem.AddWindow(this);
        }

        public void Dispose()
        {
            P.windowSystem.RemoveWindow(this);
        }

        public override void OnOpen()
        {
            Collapsed = false;
            BringToFront();
            CollapsedCondition = ImGuiCond.Appearing;
        }

        public override void Draw()
        {
            if (CosmicHelper.SheetMissionDict.TryGetValue(SelectedMission, out var sheetInfo))
            {
                ImGui.Text($"任务：");
                ImGui.SameLine(0, 5);
                ImGui.TextDisabled($"[{SelectedMission}]");
                ImGui.SameLine(0, 5);
                ImGui.Text($"{sheetInfo.Name}");

                if (ImGui.BeginTabBar("任务详细信息主选项卡"))
                {
                    if (ImGui.BeginTabItem("Details"))
                    {
                        MissionDetails(sheetInfo);
                        ImGui.EndTabItem();
                    }

                    if (CosmicHelper.CrafterJobList.ContainsAny(sheetInfo.Jobs))
                    {
                        if (ImGui.BeginTabItem("工艺详细信息"))
                        {
                            CraftDetails(sheetInfo);
                            ImGui.EndTabItem();
                        }
                    }

                    if (ImGui.BeginTabItem("Completion统计"))
                    {
                        StatInfo(sheetInfo);
                        ImGui.EndTabItem();
                    }
                    ImGui.EndTabBar();
                }
            }
        }
        private static void MissionDetails(CosmicHelper.CosmicInfo mission)
        {
            if (ImGui.BeginTable("详细的任务信息", 2, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("姓名");
                ImGui.TableSetupColumn("信息");

                // Row 1
                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.Text("宇宙信用");

                ImGui.TableNextColumn();
                ImGui.Text($"{mission.CosmoCredit}");

                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.Text($"行星积分");

                ImGui.TableNextColumn();
                ImGui.Text($"{mission.LunarCredit}");

                if (mission.DronebitReward != 0)
                {
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    if (Svc.Texture.TryGetFromGameIcon(65138, out var dronebitIcon))
                    {
                        ImGui.Image(dronebitIcon.GetWrapOrEmpty().Handle, new Vector2(24, 24));
                        if (ImGui.IsItemHovered())
                        {
                            ImGui.BeginTooltip();
                            ImGui.Image(dronebitIcon.GetWrapOrEmpty().Handle, new Vector2(40, 40));
                            ImGui.EndTooltip();
                        }
                        ImGui.SameLine();
                    }
                    ImGui.AlignTextToFramePadding();
                    ImGui.Text($"无人机");

                    ImGui.TableNextColumn();
                    ImGui.AlignTextToFramePadding();
                    ImGui.Text($"{mission.DronebitReward}");
                }

                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.Text($"Class分数：");

                ImGui.TableNextColumn();
                ImGui.Text($"{mission.ClassScore}");

                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.AlignTextToFramePadding();
                ImGui.Text($"作业");

                ImGui.TableNextColumn();
                foreach (var job in mission.Jobs)
                {
                    ISharedImmediateTexture? icon = CosmicHelper.ClassInfoDict[job].JobIcon;
                    Vector2 size = new Vector2(20, 20);
                    ImGui.Image(icon.GetWrapOrEmpty().Handle, size);
                    ImGui.SameLine();
                }

                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);
                ImGui.AlignTextToFramePadding();
                ImGui.Text($"完全的：");

                ImGui.TableNextColumn();
                ImGui_Ice.CompletionStatusIcon(mission);

                if (mission.BronzeScore != 0)
                {
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"铜牌要求");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{mission.BronzeScore}");
                }
                if (mission.SilverScore != 0)
                {
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text($"银要求");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{mission.SilverScore}");
                }
                if (mission.GoldScore != 0)
                {
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("黄金要求");

                    ImGui.TableNextColumn();
                    ImGui.Text($"{mission.GoldScore}");
                }

                if (mission.MarkerId != 0)
                {
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("采集区");

                    ImGui.TableNextColumn();

                    ImGui.PushFont(UiBuilder.IconFont);
                    ImGui.Text(FontAwesomeIcon.Flag.ToIconString());
                    ImGui.PopFont();
                    if (ImGui.IsItemClicked())
                    {
                        Utils.SetGatheringRing(mission.TerritoryId, (int)mission.MapPosition.X, (int)mission.MapPosition.Y, mission.Radius, mission.Name);
                    }
                }

                if (GatheringUtil.CriticalSpots.TryGetValue(mission.Critical_MapKey, out var criticalInfo))
                {
                    ImGui.TableNextRow();
                    ImGui.TableSetColumnIndex(0);
                    ImGui.Text("危急区域");

                    ImGui.TableNextColumn();
                    ImGuiEx.Icon(FontAwesomeIcon.Flag);
                    if (ImGui.IsItemClicked())
                    {
                        Utils.SetFlagForNPC(mission.TerritoryId, criticalInfo.X, criticalInfo.Y);
                    }
                }

                ImGui.EndTable();
            }

            if (mission.ExpModifier_3 != 0)
            {
                if (ImGui.BeginTable("Exp奖励", 2, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.Borders))
                {
                    ImGui.TableSetupColumn("类经验");
                    ImGui.TableSetupColumn("水平百分比");

                    ImGui.TableHeadersRow();

                    if (mission.ExpModifier_1 != 0)
                    {
                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text("Lv。10-49");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{mission.ExpModifier_1}%");
                    }

                    if (mission.ExpModifier_2 != 0)
                    {
                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text("LV。50-89");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{mission.ExpModifier_2}%");
                    }

                    if (mission.ExpModifier_3 != 0)
                    {
                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text("LV。90-99");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{mission.ExpModifier_3}%");
                    }

                    ImGui.EndTable();
                }
            }

            ImGui.Text("任务属性");
            if (mission.Attributes == MissionAttributes.None)
            {
                ImGui.Text("无");
                return;
            }
            else
            {
                foreach (MissionAttributes flag in Enum.GetValues<MissionAttributes>())
                {
                    if (flag != MissionAttributes.None && mission.Attributes.HasFlag(flag))
                    {
                        ImGui.Text($"{EnumNameConverter(flag)}");
                    }
                }
            }
        }
        private static void CraftDetails(CosmicHelper.CosmicInfo mission)
        {
            if (mission.Crafts_Main.Count > 0)
            {
                Mission_Table.CrafterManagement(mission, SelectedMission);
            }
        }
        
        private static void StatInfo(CosmicHelper.CosmicInfo missionInfo)
        {
            if (C.MissionConfig.TryGetValue(SelectedMission, out var config))
            {
                bool allowDelete = (ImGui.IsKeyDown(ImGuiKey.LeftShift) || ImGui.IsKeyDown(ImGuiKey.RightShift)) && (ImGui.IsKeyDown(ImGuiKey.LeftCtrl) || ImGui.IsKeyDown(ImGuiKey.RightCtrl));

                using (ImRaii.Disabled(!allowDelete))
                {
                    if (ImGui.Button("重置统计"))
                    {
                        P.MissionTimer.ResetTimers(SelectedMission);
                    }
                }
                if (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenDisabled))
                {
                    ImGui.BeginTooltip();
                    ImGui.Text("按住 Shift + Control");
                    ImGui.EndTooltip();
                }

                if (config.TurninRecords.Count > 0)
                {
                    ImGui.Text($"Best Time: {TimeSpan.FromSeconds(config.BestTimeOverall()):mm\\:ss\\.ff}");
                    ImGui.Text($"Average Time: {TimeSpan.FromSeconds(config.AverageTime()):mm\\:ss\\.ff}");
                }
                else
                {
                    ImGui.Text("最佳时间：--:--:--");
                    ImGui.Text("平均时间：--:--:--");
                }

                ImGui.Text($"Times Completed: {config.TotalCompletions}");
                ImGui.Text($"Times Attempted: {config.TotalAttempts}");

                var baseScore = missionInfo.ClassScore;
                var comsoCredit = missionInfo.CosmoCredit;
                var planetCredit = missionInfo.LunarCredit;

                ImGui.Separator();
                ImGui.Text("每小时估计分数：");
                ImGui.SameLine();
                ImGui.TextDisabled("?");
                if (ImGui.IsItemHovered())
                {
                    ImGui.BeginTooltip();
                    ImGui.Text("这是假设：");
                    ImGui.Text("1：您每次都能完美地完成您想要的任务");
                    ImGui.Text("2：您每次都会达到阈值");
                    ImGui.Text("这是基于您的平均时间。\n" +
                               "所以要跑好几次才能获得对时机有很好的感觉");
                    ImGui.EndTooltip();
                }
                if (ImGui.BeginTable("分数信息：外部详细信息", 5, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders))
                {
                    foreach (var entry in missionInfo.ScoreInfo().Where(x => x.Value.Score != 0))
                    {
                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        ImGui.Text($"{entry.Key} [{entry.Value.Completions:N0}]");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{entry.Value.Score:N2}");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{entry.Value.Cosmocredit:N2}");

                        ImGui.TableNextColumn();
                        ImGui.Text($"{entry.Value.PlanetCredits:N2}");

                        ImGui.TableNextColumn();
                        string tokens = entry.Value.Tokens > 0 ? $"{entry.Value.Tokens:N2}" : "-";
                        ImGui.Text(tokens);
                    }

                    ImGui.EndTable();
                }
                if (config.TotalCompletions != 0)
                {
                    if (ImGui.BeginChild("任务计时器", ImGui.GetContentRegionAvail()))
                    {
                        // Group records by state, preserving enum order
                        var recordsByState = config.TurninRecords
                            .GroupBy(r => r.State)
                            .OrderBy(g => (int)g.Key)
                            .ToList();

                        if (ImGui.BeginTabBar("Completion统计"))
                        {
                            // "All" tab always shown if there are any records
                            if (ImGui.BeginTabItem("All"))
                            {
                                DrawTurninTable(config.TurninRecords);
                                ImGui.EndTabItem();
                            }

                            // One tab per state that has at least one record
                            foreach (var group in recordsByState)
                            {
                                var label = group.Key.ToString();
                                if (ImGui.BeginTabItem(label))
                                {
                                    DrawTurninTable(group.ToList());
                                    ImGui.EndTabItem();
                                }
                            }

                            ImGui.EndTabBar();
                        }
                    }
                    ImGui.EndChild();
                }
            }
        }

        public static string EnumNameConverter(MissionAttributes attribute)
        {
            return attribute switch
            {
                MissionAttributes.Craft => "制作",
                MissionAttributes.Gather => "收集",
                MissionAttributes.Fish => "Fishing",
                MissionAttributes.Limited => "有限供应",
                MissionAttributes.Collectables => "Collectable",
                MissionAttributes.ReducedItems => "Reducable项目",
                MissionAttributes.ExpertCraft => "专家工艺",
                MissionAttributes.Score_TimeRemaining => "Timed评分",
                MissionAttributes.Score_Chain => "连锁聚集得分",
                MissionAttributes.Score_Boon => "收集者的奖励得分",
                MissionAttributes.Score_LargestSize => "最大鱼得分",
                MissionAttributes.Score_Variety => "所需的鱼品种",
                MissionAttributes.Score_MinimumScore => "任务分数要求",
                MissionAttributes.Critical => "危急任务",
                MissionAttributes.ProvisionalTimed => "Time required",
                MissionAttributes.ProvisionalWeather => "需要天气",
                MissionAttributes.ProvisionalSequential => "需要序列任务",
                _ => attribute.ToString()
            };
        }
        private  static void DrawTurninTable(List<TurninData> records)
        {
            if (!ImGui.BeginTable("TurninTable", 2, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg | ImGuiTableFlags.ScrollY | ImGuiTableFlags.SizingFixedFit)) 
                return;

            ImGui.TableSetupScrollFreeze(0, 1);
            ImGui.TableSetupColumn("时间");
            ImGui.TableSetupColumn("状态", ImGuiTableColumnFlags.WidthStretch, 100f);
            ImGui.TableHeadersRow();

            foreach (var record in records)
            {
                ImGui.TableNextRow();
                ImGui.TableNextColumn();
                ImGui.TextUnformatted($"{TimeSpan.FromSeconds(record.Time):mm\\:ss\\.ff}");
                ImGui.TableNextColumn();
                ImGui.TextUnformatted(record.State.ToString());
            }

            ImGui.EndTable();
        }
    }
}
