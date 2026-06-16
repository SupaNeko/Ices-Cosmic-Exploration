using Dalamud.Interface;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;
using ECommons.GameHelpers;
using ICE.Ui.MainUi.ModeSelect_Modes.CosmicTable;
using ICE.Ui.MainUi.Settings;
using ICE.Utilities.Cosmic_Helper;
using ICE.Utilities.ImGuiTools;
using System.Collections.Generic;

namespace ICE.Ui.MainUi.ModeSelect_Modes
{
    internal class Mission_Setup
    {
        private static readonly Dictionary<string, uint> BattleJobs = new()
        {
            // Tanks
            { "Paladin", 19 },
            { "Warrior", 21 },
            { "黑暗骑士", 32 },
            { "Gunbreaker", 37 },
    
            // Healers
            { "白法师", 24 },
            { "Scholar", 28 },
            { "Astrologian", 33 },
            { "Sage", 40 },
    
            // Melee DPS
            { "Monk", 20 },
            { "Dragoon", 22 },
            { "Ninja", 30 },
            { "Samurai", 34 },
            { "Reaper", 39 },
            { "Viper", 41 },
    
            // Physical Ranged DPS
            { "Bard", 23 },
            { "Machinist", 31 },
            { "Dancer", 38 },
    
            // Magical Ranged DPS
            { "黑法师", 25 },
            { "Summoner", 27 },
            { "Red Mage", 35 },
            { "Pictomancer", 42 }
        };

        public static Mission_Table? MissionTable;
        private static List<CosmicHelper.MissionInfo> TableItems = [];
        private static int ItemCount = 0;
        private static string newListName = string.Empty;

        public static void Draw()
        {
            using var style = ImRaii.PushStyle(ImGuiStyleVar.ChildRounding, 10).Push(ImGuiStyleVar.ChildBorderSize, 1);

            // Header at the top
            float scale = ImGuiHelpers.GlobalScale;

            using (var headerChild = ImRaii.Child("##modeSelect_StandardHeader", new Vector2(0, 45 * scale), true, ImGuiWindowFlags.NoScrollbar))
            {
                if (!headerChild.Success) return;

                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 10 * scale);
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + 5 * scale);

                string modeType = string.Empty;
                FontAwesomeIcon modeIcon = FontAwesomeIcon.List;

                bool standard = C.SelectedMode == ModeSelect.Standard;
                bool relicMode = C.SelectedMode == ModeSelect.RelicMode;
                bool xpLeveling = C.SelectedMode == ModeSelect.LevelMode;
                bool goldMode = C.SelectedMode == ModeSelect.MissionGoldMode;
                bool agendaMode = C.SelectedMode == ModeSelect.AgendaMode;


                if (standard)
                    modeType = "标准";
                else if (relicMode)
                {
                    modeType = "宇宙工具升级";
                    modeIcon = FontAwesomeIcon.ArrowUpRightDots;
                }
                else if (xpLeveling)
                {
                    modeType = "练级刷取";
                    modeIcon = FontAwesomeIcon.Leaf;
                }
                else if (goldMode)
                {
                    modeType = "达成金星";
                    modeIcon = FontAwesomeIcon.Trophy;
                }
                else if (agendaMode)
                {
                    modeType = "宇宙议程";
                    modeIcon = FontAwesomeIcon.ClipboardList;
                }

                ImGuiEx.IconWithText(modeIcon, $"{modeType} Mode");

                ImGui.SameLine(0, 10 * scale);

                // Adjust the Y position to center the button vertically with the text
                float textHeight = ImGui.GetTextLineHeight();
                float buttonHeight = ImGui.GetFrameHeight();
                float yOffset = (textHeight - buttonHeight) / 2f;
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);

                if (ImGuiEx.IconButtonWithText(FontAwesomeIcon.Play, "模式选择"))
                {
                    ImGui.OpenPopup("模式选择 |选择模式窗口");
                }
                if (ImGui.BeginPopup("模式选择 |选择模式窗口"))
                {
                    MainWindow.ModeSelection();

                    ImGui.EndPopup();
                }

                uint currentJobId = (uint)Player.Job;
                bool usingSupportedJob = CosmicHelper.CrafterJobList.Contains(currentJobId) || CosmicHelper.GatheringJobList.Contains(currentJobId);

                bool AnyStop = C.StopOnceHitCosmicScore
                             | C.StopWhenLevel
                            || C.StopOnceHitCosmoCredits
                            || C.StopOnceHitLunarCredits
                            || C.StopOnceRelicFinished;
                if (AnyStop)
                {
                    ImGui.SameLine(0, 10 * scale);
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);
                    ImGuiEx.Icon(FontAwesomeIcon.ExclamationTriangle);
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();

                        ImGui.Text("似乎您已启用以下一项");
                        if (C.StopOnceHitCosmicScore)
                            ImGui.BulletText($"Stop at Cosmic Score [{C.CosmicScoreCap:N0}]");
                        if (C.StopWhenLevel)
                            ImGui.BulletText($"Stop When Level [{C.TargetLevel:N0}]");
                        if (C.StopOnceHitCosmoCredits)
                            ImGui.BulletText($"宇宙信用点达到时停止 [{C.CosmoCreditsCap:N0}]");
                        if (C.StopOnceHitLunarCredits)
                            ImGui.BulletText($"行星信用点达到时停止 [{C.LunarCreditsCap:N0}]");
                        if (C.StopOnceRelicFinished)
                            ImGui.BulletText($"一旦宇宙工具完成就停止");

                        ImGui.Text("所以如果你停下来并且不确定为什么......这可能就是为什么");

                        ImGui.EndTooltip();
                    }
                }

                ImGui.SameLine(0, 10 * scale);
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);

                bool unsupportedArtisan = false; // xpLeveling && CosmicHelper.CrafterJobList.Contains((uint)Player.Job);
                bool unsupportedMoon = xpLeveling 
                    && CosmicMoonRegistry.TryGetMoon(Player.Territory.RowId, out var currentMoon)
                    && !CosmicMoonRegistry.HasLevelingContent(currentMoon);

                // Leveling on a hub requires QuickLevelList entries; gathering still needs route YAML per territory
                using (ImRaii.Disabled(SchedulerMain.State != IceState.Idle || !usingSupportedJob || unsupportedMoon))
                {
                    if (ImGui.Button("开始", new Vector2(150 * scale, 0)))
                    {
                        SchedulerMain.EnablePlugin();
                    }
                }

                if (unsupportedArtisan)
                {
                    ImGui.SameLine(0, 10 * scale);
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);
                    ImGuiEx.Icon(EColor.Red, FontAwesomeIcon.ExclamationTriangle);
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.Text("嘿！您需要更新 artisan 才能使用此模式，请至少更新到：");
                        ImGui.Text("4.0.4.29");
                        ImGui.EndTooltip();
                    }
                }
                else if (unsupportedMoon && CosmicMoonRegistry.TryGetMoon(Player.Territory.RowId, out var unsupportedHub))
                {
                    ImGui.SameLine(0, 10 * scale);
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);
                    ImGuiEx.Icon(EColor.Red, FontAwesomeIcon.ExclamationTriangle);
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.Text($"Hey! {unsupportedHub.DisplayName} is not supported for leveling yet.");
                        var missing = new List<string>();
                        if (!CosmicMoonRegistry.HasLevelingContent(unsupportedHub))
                            missing.Add("QuickLevelList任务");
                        if (!CosmicMoonContent.HasGatheringRoutes(unsupportedHub.TerritoryId))
                            missing.Add("采集路线");
                        if (missing.Count > 0)
                            ImGui.Text($"Still needed: {string.Join(", ", missing)}.");
                        ImGui.EndTooltip();
                    }
                }
                if (!P.AutoHook.UpdatedPlugin() && CosmicMoonRegistry.Auxesia.TerritoryId == Player.Territory.RowId)
                {
                    ImGui.SameLine(0, 10 * scale);
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);
                    ImGuiEx.Icon(EColor.Red, FontAwesomeIcon.ExclamationTriangle);
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.Text($"嘿！这个星球目前不支持您的 autohook 版本");
                        ImGui.Text($"你需要（当前）处于测试版本才能在此处自动化捕鱼");
                        ImGui.Text($"如果您尝试运行此任务并且它选择了钓鱼任务，将会弹出另一个警告...");
                        ImGui.EndTooltip();
                    }
                }

                ImGui.SameLine(0, 10 * scale);
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);

                using (ImRaii.Disabled(SchedulerMain.State == IceState.Idle))
                {
                    using (ImRaii.PushColor(ImGuiCol.Button, new Vector4(0.8f, 0.2f, 0.2f, 1.0f)))
                    using (ImRaii.PushColor(ImGuiCol.ButtonHovered, new Vector4(0.9f, 0.3f, 0.3f, 1.0f)))
                    using (ImRaii.PushColor(ImGuiCol.ButtonActive, new Vector4(0.7f, 0.1f, 0.1f, 1.0f)))
                    {
                        if (ImGui.Button("停止", new Vector2(150 * scale, 0)))
                        {
                            SchedulerMain.DisablePlugin();
                        }
                    }
                }

                ImGui.SameLine(0, 10 * scale);
                ImGui.SetCursorPosY(ImGui.GetCursorPosY() + yOffset);

                if (ImGui.Button("任务设置"))
                {
                    ImGui.OpenPopup("任务设置：弹出");
                }
                if (ImGui.BeginPopup("任务设置：弹出"))
                {
                    // TODO: Mission Settings
                    bool grindAllProvisionals = C.GrindAllProvisionals;
                    if (ImGui.Checkbox("临时：允许所有类", ref grindAllProvisionals))
                    {
                        C.GrindAllProvisionals = grindAllProvisionals;
                        C.Save();
                    }
                    ImGuiEx.HelpMarker("启用此功能将向您显示您可以完成的所有天气/限时/序列任务，\n" +
                                       "在完成您开始的任何职业的正常任务之上。\n" +
                                       "如果你只想关注一个特定的类，请将其设置为 false");

                    bool allowCriticalsAllClass = C.GrindOffClassRedAlert;
                    if (ImGui.Checkbox("紧急任务：允许所有职业", ref allowCriticalsAllClass))
                    {
                        C.GrindOffClassRedAlert = allowCriticalsAllClass;
                        C.Save();
                    }
                    ImGuiEx.HelpMarker($"这将允许您磨练其他职业的紧急任务。 " +
                        $"（因此，如果您在 crp 上，但弹出 bsm 紧急任务）");

                    bool removeGold = C.RemoveAfterGold;
                    if (ImGui.Checkbox("达成金星后删除任务", ref removeGold))
                    {
                        C.RemoveAfterGold = removeGold;
                        C.Save();
                    }
                    using (ImRaii.Disabled(!removeGold))
                    {
                        bool keepARanks = C.KeepARanks;
                        if (ImGui.Checkbox("保持“A Rank”任务及以下", ref keepARanks))
                        {
                            C.KeepARanks = keepARanks;
                            C.Save();
                        }
                    }

                    ImGui.Checkbox("当前任务后停止", ref Mission_Settings.StopAfterCurrent);
                    bool relicTurnin = C.TurninRelic;
                    if (ImGui.Checkbox($"如果宇宙工具已完成则上交##RelicTurnin_GeneralSetting", ref relicTurnin))
                    {
                        C.TurninRelic = relicTurnin;
                        C.Save();
                    }
                    ImGui.SameLine();
                    ImGui.TextDisabled("?");
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.SetTooltip("请注意这是如何运作的。如果我将来更改此设置，此工具提示也会更改。\n" +
                                         "1：这将检查您当前的职业[不是菜单职业，实际当前职业]是否有宇宙工具交接。\n" +
                                         "2：您必须没有该工具配备此功能以全自动运行。 \n" +
                                         "\t- 这是因为我此时使用 cba 编码这一事实。（将来可能会改变我的想法*耸耸肩*）\n" +
                                         "3：这将优先于“停止 @ 宇宙工具上交”，从某种意义上说，如果您同时启用了两者，它将转入与停止。继续今天的\n" +
                                         "4：如果您正在上制作职业，它会让您回到交接后正在制作的站点。 \n" +
                                         "\t- 这是可选的，您可以随意禁用它，我只是喜欢这样，这样我就可以回到我选择的隔离区域");
                    }

                    ImGui.Separator();
                    bool relic_AllowRedAlert = C.Relic_IncludeCriticals;
                    if (ImGui.Checkbox("宇宙工具模式：允许紧急任务", ref relic_AllowRedAlert))
                    {
                        C.Relic_IncludeCriticals = relic_AllowRedAlert;
                        C.Save();
                    }

                    bool OnlySelected = C.XPRelicOnlyEnabled;
                    if (ImGui.Checkbox("宇宙工具模式：仅启用", ref OnlySelected))
                    {
                        C.XPRelicOnlyEnabled = OnlySelected;
                        C.Save();
                    }
                    if (ImGui.Button("打开职业交换设置"))
                    {
                        C.SelectedTab = WindowSelection.CharacterSettings;
                    }

                    if (ImGui.Button("保存当前任务预设"))
                    {
                        ImGui.OpenPopup("预设保存编辑器");
                    }

                    if (ImGui.BeginPopup("预设保存编辑器"))
                    {
                        ImGui.InputText($"播放列表名称", ref newListName);
                        using (ImRaii.Disabled(string.IsNullOrEmpty(newListName)))
                        {
                            if (ImGui.Button("保存新列表"))
                            {
                                List<uint> new_Playlist = new();
                                foreach (var mission in C.MissionConfig.Where(x => x.Value.Enabled))
                                {
                                    new_Playlist.Add(mission.Key);
                                }
                                if (C.Mission_Playlist.ContainsKey(newListName))
                                {
                                    C.Mission_Playlist[newListName] = new_Playlist;
                                }
                                else
                                {
                                    C.Mission_Playlist.Add(newListName, new_Playlist);
                                }
                                C.Save();
                                ImGui.CloseCurrentPopup();
                            }
                        }

                        ImGui.EndPopup();
                    }

                    if (C.Mission_Playlist.Count > 0)
                    {
                        if (ImGui.Button("查看所有预设"))
                        {
                            ImGui.OpenPopup("Preset：列表查看器");
                        }

                        if (ImGui.BeginPopup("Preset：列表查看器"))
                        {
                            ImGui.Text($"加载任务预设");

                            if (ImGui.BeginTable($"Preset：TableViewer", 3, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders))
                            {
                                ImGui.TableSetupColumn("名称");
                                ImGui.TableSetupColumn("启用金额");

                                ImGui.TableHeadersRow();

                                ImGui.TableNextRow();
                                ImGui.TableSetColumnIndex(0);
                                ImGui.AlignTextToFramePadding();
                                ImGui.Text($"清除全部");
                                ImGui.SameLine();
                                if (ImGuiEx.IconButton(FontAwesomeIcon.ArrowUpRightFromSquare, $"FreshPreset_Button"))
                                {
                                    foreach (var mission in C.MissionConfig)
                                    {
                                        mission.Value.Enabled = false;
                                    }
                                    C.Save();
                                    ImGui.CloseCurrentPopup();
                                }

                                foreach (var item in C.Mission_Playlist)
                                {
                                    ImGui.TableNextRow();
                                    ImGui.TableSetColumnIndex(0);
                                    ImGui.AlignTextToFramePadding();
                                    ImGui.Text($"{item.Key}");
                                    ImGui.SameLine();
                                    if (ImGuiEx.IconButton(FontAwesomeIcon.ArrowUpRightFromSquare, $"{item.Key}_Button"))
                                    {
                                        foreach (var mission in C.MissionConfig)
                                        {
                                            if (item.Value.Contains(mission.Key))
                                                mission.Value.Enabled = true;
                                            else
                                                mission.Value.Enabled = false;
                                        }
                                        C.Save();
                                        ImGui.CloseCurrentPopup();
                                    }
                                    if (ImGui.IsItemHovered())
                                    {
                                        ImGui.SetTooltip("导入任务");
                                    }

                                    ImGui.TableNextColumn();
                                    ImGui.AlignTextToFramePadding();
                                    ImGui.Text($"{item.Value.Count}");

                                    ImGui.TableNextColumn();
                                    if (ImGuiEx.IconButton(FontAwesomeIcon.Trash, $"{item.Key}_Remove"))
                                    {
                                        C.Mission_Playlist.Remove(item);
                                        C.Save();
                                    }
                                    if (ImGui.IsItemHovered())
                                    {
                                        ImGui.SetTooltip("从列表中删除");
                                    }
                                }

                                ImGui.EndTable();
                            }

                            ImGui.EndPopup();
                        }
                    }


                ImGui.EndPopup();
                }
            }

            using (var bodyChild = ImRaii.Child("##modeSelect_Body", new Vector2(0, -1), true, ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse))
            {
                if (!bodyChild.Success) return;

                float scrollbarSize = ImGui.GetStyle().ScrollbarSize;
                float buttonRowHeight = (ImGui.GetTextLineHeight() + 8 * scale + 4 * scale) + scrollbarSize;

                using (var missionButtons = ImRaii.Child("##tab_scroll", new Vector2(0, buttonRowHeight), false, ImGuiWindowFlags.HorizontalScrollbar))
                {
                    if (!missionButtons.Success)
                        return;

                    ImGui_Ice.DrawRankButton("紧急任务", MissionFilter.RedAlert, MissionTable);
                    ImGui_Ice.DrawRankButton("Sequence", MissionFilter.Sequence, MissionTable);
                    ImGui_Ice.DrawRankButton("天气", MissionFilter.Weather, MissionTable);
                    ImGui_Ice.DrawRankButton("限时", MissionFilter.Timed, MissionTable);
                    ImGui_Ice.DrawRankButton("大师", MissionFilter.Master, MissionTable);
                    ImGui_Ice.DrawRankButton("A Rank", MissionFilter.ARank, MissionTable);
                    ImGui_Ice.DrawRankButton("B Rank", MissionFilter.BRank, MissionTable);
                    ImGui_Ice.DrawRankButton("C Rank", MissionFilter.CRank, MissionTable);
                    ImGui_Ice.DrawRankButton("D Rank", MissionFilter.DRank, MissionTable);

                    ImGui_Ice.EndCategoryButtonRow();
                }

                var bottomSpace = ImGui.GetTextLineHeight() + 6f;
                bottomSpace += 12f; // prevent the tabs from creating a scrollbar

                Vector2 size = new(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y - bottomSpace);
                if (ImGui.BeginChild("###MissionTableV3", size, false))
                {
                    try
                    {
                        if (MissionTable == null && CosmicHelper.SheetMissionDict.Count > 0)
                        {
                            foreach (var mission in CosmicHelper.SheetMissionDict)
                            {
                                CosmicHelper.MissionInfo missionDetails = new() { Id = mission.Key };
                                TableItems.Add(missionDetails);
                            }
                            ItemCount = TableItems.Count();
                            MissionTable = new(TableItems);
                        }
                        var filterActive = MissionTable.FilteredItems.Count != 0 && MissionTable.FilteredItems.Count != ItemCount;
                        var filterCount = filterActive ? $" (of {ItemCount})" : "";
                        var height = ImGui.GetFrameHeight();
                        MissionTable.Draw(height + 4f);
                    }
                    catch (Exception ex)
                    {
                        IceLogging.Error(ex.Message, "Drawing Mission Table");
                    }
                }
                ImGui.EndChild();
            }
        }
    }
}
