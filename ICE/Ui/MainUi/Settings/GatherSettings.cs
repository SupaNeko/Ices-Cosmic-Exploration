using Dalamud.Interface.Utility.Raii;
using ICE.Utilities.Cosmic_Helper;
using ICE.Utilities.GatheringHelper;
using ICE.Utilities.ImGuiTools;
using Lumina.Excel.Sheets;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static ICE.ConfigFiles.Config;

namespace ICE.Ui.MainUi.Settings
{
    internal class GatherSettings
    {
        public enum MissionKinds
        {
            LimitedNodes,
            GatherX,
            TimeAttack,
            Chain_Scoring,
            Boon_Scoring,
            Chain_Boon,
            DualClass,
            GreaterReach_GatherX,
            GreaterReach_Boon,
            GreaterReach_Chain,
            GreaterReach_Boon_Chain,
        }

        private static string newProfileName = "";
        private static string[] MissionTypes = 
        [
            "有限节点", 
            "采集x数量", 
            "时间攻击", 
            "Chained评分", 
            "恩赐得分", 
            "连锁+奖励得分", 
            "双类",
            "Greater Reach [Gather X]",
            "Greater Reach [Boon]",
            "Greater Reach [Chain]",
            "Greater Reach [Boon + Chain]",
        ];
        private static readonly string[] RankLabels = ["所有任务", "D及以上", "C 及以上", "B及以上", "A及以上", "EX及以上", "EX+ only"];
        private static MissionKinds _selectedMission = MissionKinds.LimitedNodes;

        private static readonly string PROFILE_PREFIX = "IceGatherProfile_";

        public static string ExportGatherProfile(int profileId)
        {
            if (!C.GatherProfiles.TryGetValue(profileId, out var profile))
                return string.Empty;

            var json = JsonSerializer.Serialize(profile, new JsonSerializerOptions
            {
                WriteIndented = false
            });

            var bytes = Encoding.UTF8.GetBytes(json);
            var base64 = Convert.ToBase64String(bytes);

            return PROFILE_PREFIX + base64;
        }
        public static bool ImportGatherProfile(string importString, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Check for and remove the prefix
                if (!importString.StartsWith(PROFILE_PREFIX))
                {
                    errorMessage = "无效的导入字符串：缺少前缀";
                    return false;
                }

                var base64String = importString.Substring(PROFILE_PREFIX.Length);

                var bytes = Convert.FromBase64String(base64String);
                var json = Encoding.UTF8.GetString(bytes);

                var profile = JsonSerializer.Deserialize<GatherProfile>(json);
                if (profile == null)
                {
                    errorMessage = "反序列化失败轮廓";
                    return false;
                }

                // Get the next available ID
                int nextId = C.GatherProfiles.Keys.Count > 0
                    ? C.GatherProfiles.Keys.Max() + 1
                    : 0;

                profile.Id = nextId;
                C.GatherProfiles[nextId] = profile;

                // Save the configuration
                C.Save();

                return true;
            }
            catch (FormatException)
            {
                errorMessage = "无效的导入字符串：无效的base64";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Import failed: {ex.Message}";
                return false;
            }
        }
        public static bool InitialSetupProfile(string importString, MissionKinds type, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (!importString.StartsWith(PROFILE_PREFIX))
                {
                    errorMessage = "无效的导入字符串：缺少前缀";
                    return false;
                }

                var base64String = importString.Substring(PROFILE_PREFIX.Length);
                var bytes = Convert.FromBase64String(base64String);
                var json = Encoding.UTF8.GetString(bytes);

                var profile = JsonSerializer.Deserialize<GatherProfile>(json);
                if (profile == null)
                {
                    errorMessage = "反序列化失败轮廓";
                    return false;
                }

                int nextId = C.GatherProfiles.Keys.Count > 0
                    ? C.GatherProfiles.Keys.Max() + 1
                    : 0;

                profile.Id = nextId;
                C.GatherProfiles[nextId] = profile;

                foreach (var mission in C.MissionConfig)
                {
                    if (!CosmicHelper.SheetMissionDict.TryGetValue(mission.Key, out var missionDict))
                        continue;

                    var attrs = missionDict.Attributes;
                    if (!attrs.HasFlag(MissionAttributes.Gather))
                        continue;
                    if (attrs.HasFlag(MissionAttributes.Collectables) || attrs.HasFlag(MissionAttributes.ReducedItems))
                        continue;

                    if (GetMissionKind(attrs) == type)
                        mission.Value.GProfileId = nextId;
                }

                return true;
            }
            catch (FormatException)
            {
                errorMessage = "无效的导入字符串：无效的base64";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Import failed: {ex.Message}";
                return false;
            }
        }
        private static Dictionary<uint, string> Foods = new();

        public static void Draw()
        {
            int maxGp = 1200;

            bool SelfSpiritbondGather = C.SelfSpiritbondGather;
            if (ImGui.Checkbox("在采集时提取精炼度", ref SelfSpiritbondGather))
            {
                if (C.SelfSpiritbondGather != SelfSpiritbondGather)
                {
                    C.SelfSpiritbondGather = SelfSpiritbondGather;
                    C.Save();
                }
            }
            ImGuiEx.HelpMarker("启用此功能将使其到潘多拉的强心剂功能不会自动暂停的位置。");

            bool AutoCordial = C.AutoCordial;
            if (ImGui.Checkbox("自动强心剂", ref AutoCordial))
            {
                C.AutoCordial = AutoCordial;
                C.Save();
            }
            ImGuiEx.HelpMarker("仅在使用ICE时职业，而不是手动模式\n" +
                               "在月亮");
            if (ImGui.CollapsingHeader("强心剂的设置"))
            {
                int cordialMinRank = C.CordialMinRank;
                ImGui.SetNextItemWidth(150);
                if (ImGui.Combo("Min强心剂任务等级", ref cordialMinRank, RankLabels, RankLabels.Length))
                {
                    C.CordialMinRank = cordialMinRank;
                    C.Save();
                }

                bool InverseCordialPrio = C.inverseCordialPrio;
                bool PreventOvercap = C.PreventOvercap;
                int CordialMinGp = C.CordialMinGp;

                if (ImGui.Checkbox("反向优先级（Watered -> Regular -> Hi）", ref InverseCordialPrio))
                {
                    C.inverseCordialPrio = InverseCordialPrio;
                    C.Save();
                }
                if (ImGui.Checkbox("防止超额", ref PreventOvercap))
                {
                    C.PreventOvercap = PreventOvercap;
                    C.Save();
                }
                ImGui.SetNextItemWidth(200);
                if (ImGui.SliderInt("在低于以下条件时使用强心剂键GP", ref CordialMinGp, 0, maxGp))
                {
                    C.CordialMinGp = CordialMinGp;
                    C.SaveDebounced();
                }
                ImGui.SameLine();
                ImGuiEx.HelpMarker("在使用强心剂感之前，您可以拥有的最低 gp 是多少。\n" +
                                   "如果设置为0，即使启用它也永远不会使用强心剂的饮料（因为......你永远不会有0 gp）");
            }

            if (ImGui.CollapsingHeader("食物设置"))
            {
                int foodMinRank = C.FoodMinRank;
                ImGui.SetNextItemWidth(150);
                if (ImGui.Combo("Min食物任务等级", ref foodMinRank, RankLabels, RankLabels.Length))
                {
                    C.FoodMinRank = foodMinRank;
                    C.Save();
                }

                bool useFood = C.UseGatheringFood;
                if (ImGui.Checkbox("在采集任务中使用食物", ref useFood))
                {
                    C.UseGatheringFood = useFood;
                    C.Save();
                }

                if (ImGui.Button("选择采集食物"))
                {
                    foreach (var item in ConsumableInfo.GatherFood)
                    {
                        if (PlayerHelper.GetItemCount(item.Id, out var count) && count > 0)
                            Foods[item.Id] = item.Name;
                    }

                    ImGui.OpenPopup("食物选择");
                }
                ImGui.SameLine();
                if (C.GatheringFood == 0)
                {
                    ImGui.Text("没有选择食物");
                }
                else
                {
                    var itemName = Svc.Data.GetExcelSheet<Item>().Where(x => x.RowId == C.GatheringFood).FirstOrDefault().Name.ToString();
                    ImGui.Text($"{itemName}");
                }

                if (ImGui.BeginPopup("食物选择"))
                {
                    if (ImGui.BeginTable("食品选择", 2, ImGuiTableFlags.RowBg))
                    {
                        ImGui.TableSetupColumn("食品项目");
                        ImGui.TableSetupColumn("数量");

                        // First Column, pretty much giving an option for "None" if they want none
                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        if (ImGui.Selectable("不使用采集食物"))
                        {
                            C.GatheringFood = 0;
                            C.Save();
                            ImGui.CloseCurrentPopup();
                        }

                        foreach (var item in Foods)
                        {
                            ImGui.TableNextRow();
                            ImGui.PushID(item.Key);

                            ImGui.TableSetColumnIndex(0);
                            if (ImGui.Selectable($"{item.Value}"))
                            {
                                C.GatheringFood = item.Key;
                                C.Save();

                                ImGui.CloseCurrentPopup();
                            }

                            ImGui.TableNextColumn();
                            PlayerHelper.GetItemCount(item.Key, out var count);
                            if (ImGui.Selectable($"x {count}"))
                            {
                                C.GatheringFood = item.Key;
                                C.Save();

                                ImGui.CloseCurrentPopup();
                            }
                        }

                        ImGui.EndTable();
                    }

                    ImGui.EndPopup();
                }
            }

            ImGui.Separator();

            if (ImGui.BeginTable("采集配置文件设置", 2, ImGuiTableFlags.SizingFixedFit))
            {
                ImGui.TableSetupColumn("配置文件选择");
                ImGui.TableSetupColumn("采集设置");

                // 1st Row, technically only really used for the gather profile name creator
                ImGui.TableNextRow();

                ImGui.TableSetColumnIndex(0);
                ImGui.SetNextItemWidth(200);
                ImGui.InputText("新配置文件名称", ref newProfileName, 64);
                using (ImRaii.Disabled(newProfileName == ""))
                {
                    if (ImGui.Button("添加配置文件") && !string.IsNullOrWhiteSpace(newProfileName))
                    {
                        var newId = C.GatherProfiles.Keys.Max() + 1;
                        C.GatherProfiles[newId] = new()
                        {
                            Name = newProfileName,
                        };
                        C.Save();
                        newProfileName = "";
                    }
                }

                // 2nd Row, Actually profile selector
                ImGui.TableNextRow();
                ImGui.TableSetColumnIndex(0);

                #region Profile Selection

                ImGui.Text("采集配置文件");

                bool canDelete = C.GatherProfiles.Count > 1 && C.SelectedGatherIndex != 0;
                using (ImRaii.Disabled(!canDelete))
                {
                    if (ImGui.Button("删除选定的配置文件"))
                    {
                        int deletedId = C.SelectedGatherIndex;

                        // Don't allow deleting the default profile
                        if (deletedId == 0)
                        {
                            return;
                        }

                        // Remove the profile
                        C.GatherProfiles.Remove(deletedId);

                        // Update all missions using this GatherSettingId
                        foreach (var mission in C.MissionConfig)
                        {
                            if (mission.Value.GProfileId == deletedId)
                            {
                                mission.Value.GProfileId = 0; // fallback to default
                            }
                        }

                        // Clamp the selected index and save
                        C.SelectedGatherIndex = 0;
                        C.Save();
                    }
                }

                if (ImGui.BeginChild("GatherProfileChild", new Vector2(300, ImGui.GetTextLineHeightWithSpacing() * 5 + 10), true))
                {
                    foreach (var profile in C.GatherProfiles)
                    {
                        var id = profile.Key;
                        bool isSelected = C.SelectedGatherIndex == id;
                        if (ImGui.Selectable($"{profile.Value.Name}##{profile.Value.Name}_{id}", isSelected))
                        {
                            C.SelectedGatherIndex = id;
                            C.Save();
                        }

                        if (isSelected)
                            ImGui.SetItemDefaultFocus();
                    }
                }
                ImGui.EndChild();

                if (!C.GatherProfiles.TryGetValue(C.SelectedGatherIndex, out var entry))
                {
                    // We've somehow gotten a variable that is outside the normal index, so going to just reset it back to 0
                    C.SelectedGatherIndex = 0;
                    C.SaveDebounced();
                }

                var missionIndex = (int)_selectedMission;
                if (ImGui.Combo("任务类型", ref missionIndex, MissionTypes, MissionTypes.Length))
                    _selectedMission = (MissionKinds)missionIndex;
                if (ImGui.Button("适用于任务类型"))
                {
                    foreach (var mission in C.MissionConfig)
                    {
                        if (!CosmicHelper.SheetMissionDict.TryGetValue(mission.Key, out var missionDict))
                            continue;

                        var attrs = missionDict.Attributes;
                        if (!attrs.HasFlag(MissionAttributes.Gather))
                            continue;
                        if (attrs.HasFlag(MissionAttributes.Collectables) || attrs.HasFlag(MissionAttributes.ReducedItems))
                            continue;

                        if (GetMissionKind(attrs) == _selectedMission)
                            mission.Value.GProfileId = entry.Id;
                    }

                    C.Save();
                }

                #endregion

                #region Profile Editor

                ImGui.TableNextColumn();
                #region Minimum GP + Dual Class Info

                int minGP = entry.MinimumGp;
                ImGui.SetNextItemWidth(100);
                if (ImGui.SliderInt("开始任务最低 GP", ref minGP, -1, maxGp))
                {
                    entry.MinimumGp = minGP;
                    C.SaveDebounced();
                }

                ImGui.Text("双工艺量去了哪里？");
                ImGui.SameLine();
                ImGui.Dummy(new(5, 0));
                ImGui.SameLine();
                ImGui.TextDisabled("?");
                if (ImGui.IsItemHovered())
                {
                    ImGui.SetNextWindowSize(new(400.0f, 0.0f)); // Fixed width, auto height
                    ImGui.BeginTooltip();

                    ImGui.TextWrapped("简答：现在已内置\n" +
                     "Long回答： 老实说，这本身就是一个繁琐的系统。由于 Square 决定不再继续进入第二个月球的双重制作任务，我认为最好将其与评分系统联系起来。您实际上只需要：\n" +
                     "金星：3件\n" +
                     "银星：2个项目\n" +
                     "铜星：1物品\n" +
                     "能够达到阈值。即便如此，如果你第一次尝试没有击中它，它就会继续聚集。加。这使得我不必担心钓鱼的配置文件管理...... 4 个任务？在我眼中似乎有点多余。\n" +
                     "所以现在它会如何运作。选择上交选项（金星/任意都相同），它现在会采集到必要的数量 -> 准备好后转交。\n" +
                     "NOW NONE OF YOU CAN TELL IT TO CRAFT 27 ITEMS. STOP IT. IT SAID CRAFT (╯°Д°)╯︵/(.□ . \\)");
                    ImGui.EndTooltip();
                }

                #endregion

                #region Boon Increase 2

                if (ImGui.CollapsingHeader("登山者的礼物II"))
                {
                    string buffName = "BoonIncrease2";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "对你的恩赐触发几率施加 30% 的增益。";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }

                    ImGui.PopID();
                }

                #endregion

                #region Boon Increase 1

                if (ImGui.CollapsingHeader("登山者的礼物I"))
                {
                    string buffName = "BoonIncrease1";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "对你的恩赐触发几率施加 10% 的增益。";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Nophica's / Nald'thal's Tidings

                if (ImGui.CollapsingHeader("诺菲卡/纳尔塔尔的消息增益"))
                {
                    string buffName = "Tidings";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "将采集者恩赐的物品产量提高1";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Blessed / Kings Yield II

                if (ImGui.CollapsingHeader("祝福/国王产量 II"))
                {
                    string buffName = "YieldII";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minUsableDurability = entry.GatherBuffs.Buffs[buffName].MinUsableDurability;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "采集时获得的项目数增加 2\n" +
                                        "仅在采集节点具有完全耐久度时适用";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("节点使用耐久性", ref minUsableDurability, 0, 8))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinUsableDurability = minUsableDurability;
                        C.SaveDebounced();
                    }
                    ImGui_Ice.IconWithTooltip(Dalamud.Interface.FontAwesomeIcon.InfoCircle,
                        "在此操作之前节点可以拥有的最低耐用性是多少已激活？\n" +
                        "主要用于可以连续刷新耐久度的任务");

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Blessed / Kings Yield I

                if (ImGui.CollapsingHeader("祝福/国王产量 I"))
                {
                    string buffName = "YieldI";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minUsableDurability = entry.GatherBuffs.Buffs[buffName].MinUsableDurability;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "采集时获得的项目数增加 1\n" +
                                        "仅在采集节点具有完全耐久度时适用";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("节点使用耐久性", ref minUsableDurability, 0, 8))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinUsableDurability = minUsableDurability;
                        C.SaveDebounced();
                    }
                    ImGui_Ice.IconWithTooltip(Dalamud.Interface.FontAwesomeIcon.InfoCircle,
                        "在此操作之前节点可以拥有的最低耐用性是多少已激活？\n" +
                        "主要用于可以连续刷新耐久度的任务");

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Bonus Integrity

                if (ImGui.CollapsingHeader("永恒的话语/坚实的理由"))
                {
                    string buffName = "BonusIntegrity";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minUsableDurability = entry.GatherBuffs.Buffs[buffName].MinUsableDurability;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "将完整性提高1\n" +
                                        "50% 几率获得灵光一现";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用的最低节点耐用性", ref minUsableDurability, 0, 8))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinUsableDurability = minUsableDurability;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Bountiful Yield II

                if (ImGui.CollapsingHeader("丰沛产量 II / 丰收 II"))
                {
                    string buffName = "BountifulYieldII";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "采集时获得的项目数增加 2\n" +
                                        "仅在采集节点具有完全耐久度时适用";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.Text("要采集的最小项目");
                    ImGui.SameLine();
                    int minItems = entry.GatherBuffs.BountifulMinItem;
                    if (ImGui.DragInt("##MinItemsGather", ref minItems, 1, 2, 4))
                    {
                        entry.GatherBuffs.BountifulMinItem = minItems;
                        C.SaveDebounced();
                    }

                    ImGui.PopID();
                }

                #endregion

                #region Field Mastery (Gather Chance)

                #region Field Mastery III

                if (ImGui.CollapsingHeader("领域掌握|Sharp Vision III"))
                {
                    string buffName = "FieldMasteryIII";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "采集几率增加 50%\n" +
                                        "请注意：您可以启用多个，但只能启用最接近的 " +
                                        "100% 最便宜的将被应用";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Field Mastery II

                if (ImGui.CollapsingHeader("领域掌握|敏锐视野II"))
                {
                    string buffName = "FieldMasteryII";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "采集几率提高 15%\n" +
                                        "请注意：您可以启用多个，但只能启用最接近的 " +
                                        "100% 最便宜的将被应用";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Field Mastery I

                if (ImGui.CollapsingHeader("领域掌握|敏锐的视野I"))
                {
                    string buffName = "FieldMasteryI";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "采集几率增加 5%\n" +
                                        "请注意：您可以启用多个，但只能启用最接近的 " +
                                        "100% 最便宜的将被应用";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #region Field Mastery [Temp]

                if (ImGui.CollapsingHeader("Flora Mastery |清除 Vision [Temp]"))
                {
                    string buffName = "FieldMasteryTemp";

                    ImGui.PushID(buffName);

                    bool currentlyEnabled = entry.GatherBuffs.Buffs[buffName].Enabled;
                    int minUseGp = entry.GatherBuffs.Buffs[buffName].MinGp;
                    int minActionGp = GatheringUtil.GathActionDict[buffName].RequiredGp;
                    int maxActionUsage = entry.GatherBuffs.Buffs[buffName].MaxUse;
                    string ActionInfo = "采集几率提高 15%\n" +
                                        "这可以应用于正常的领域掌握，但仅适用于每次命中";

                    ImGui.Text($"动作信息： ");
                    ImGuiEx.HelpMarker(ActionInfo);

                    if (ImGui.Checkbox("使能够", ref currentlyEnabled))
                    {
                        entry.GatherBuffs.Buffs[buffName].Enabled = currentlyEnabled;
                        C.Save();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.SliderInt("使用最低 Gp", ref minUseGp, minActionGp, maxGp))
                    {
                        entry.GatherBuffs.Buffs[buffName].MinGp = minUseGp;
                        C.SaveDebounced();
                    }

                    ImGui.SetNextItemWidth(200);
                    if (ImGui.InputInt("Max Use", ref maxActionUsage))
                    {
                        entry.GatherBuffs.Buffs[buffName].MaxUse = maxActionUsage;
                        C.SaveDebounced();
                    }
                    ImGuiEx.HelpMarker("设置为-1以允许无限使用 \n" +
                                       "设置为1-> X以设置每个任务的最大使用量");

                    ImGui.PopID();
                }

                #endregion

                #endregion

                #endregion

                ImGui.EndTable();
            }

            ImGui.Separator();
            if (ImGui.Button("复制选定的配置文件"))
            {
                string export = ExportGatherProfile(C.SelectedGatherIndex);
                ImGui.SetClipboardText(export);
            }

            if (ImGui.Button("导入选定的配置文件"))
            {
                string importProfile = ImGui.GetClipboardText();
                string errorMessage = "";
                ImportGatherProfile(importProfile, out errorMessage);
                if (errorMessage != "")
                {
                    IceLogging.Error(errorMessage);
                }
                C.Save();
            }

            ImGui.Dummy(new Vector2(0, 10));

            ImGui.Separator();

            ImGui.Dummy(new Vector2(0, 10));

            using (ImRaii.Disabled(!ImGui.IsKeyDown(ImGuiKey.LeftShift)))
            {
                if (ImGui.Button("设置采集配置文件"))
                {
                    SetupAllProfiles();

                    C.Save();
                }
            }
            ImGuiEx.HelpMarker("请注意：\n" +
                               "这将清除你当前的所有配置文件，并应用我对每个配置文件的建议。\n" +
                               "对于你们大多数人来说这很好，这实际上只是在您不知道要为每件申请什么时才在这里。" +
                               "如果您对此感到满意，请按住左移并应用");
        }

        private static MissionKinds GetMissionKind(MissionAttributes attrs)
        {
            bool limited = attrs.HasFlag(MissionAttributes.Limited);
            bool timed = attrs.HasFlag(MissionAttributes.Score_TimeRemaining);
            bool chain = attrs.HasFlag(MissionAttributes.Score_Chain);
            bool boon = attrs.HasFlag(MissionAttributes.Score_Boon);
            bool collects = attrs.HasFlag(MissionAttributes.Collectables);
            bool reduced = attrs.HasFlag(MissionAttributes.ReducedItems);
            bool grGatherX = attrs.HasFlag(MissionAttributes.GreaterReach_GatherX);
            bool grBoon = attrs.HasFlag(MissionAttributes.GreaterReach_Boon);
            bool grChain = attrs.HasFlag(MissionAttributes.GreaterReach_Chain);
            bool grBoonCh = attrs.HasFlag(MissionAttributes.GreaterReach_Boon_Chain);

            if (grBoonCh) return MissionKinds.GreaterReach_Boon_Chain;
            if (grChain) return MissionKinds.GreaterReach_Chain;
            if (grBoon) return MissionKinds.GreaterReach_Boon;
            if (grGatherX) return MissionKinds.GreaterReach_GatherX;
            if (limited) return MissionKinds.LimitedNodes;
            if (timed) return MissionKinds.TimeAttack;
            if (chain && boon) return MissionKinds.Chain_Boon;
            if (chain) return MissionKinds.Chain_Scoring;
            if (boon) return MissionKinds.Boon_Scoring;

            // DualClass uses craftMission flag rather than attrs pattern
            if (attrs.HasFlag(MissionAttributes.Craft)) return MissionKinds.DualClass;

            return MissionKinds.GatherX; // fallback: plain gather
        }

        public static void SetupAllProfiles()
        {
            foreach (var profile in C.GatherProfiles)
            {
                if (profile.Key == 0)
                    continue;
                else
                {
                    C.GatherProfiles.Remove(profile.Key);
                    foreach (var mission in C.MissionConfig)
                    {
                        if (mission.Value.GProfileId == profile.Key)
                        {
                            mission.Value.GProfileId = 0; // fallback to default
                        }
                    }
                }
            }

            string timedMissions = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IlRpbWVkIE1pc3Npb25zIiwiTWluaW11bUdwIjoxMDAsIkR1YWxDbGFzc0NyYWZ0QW1vdW50IjoxLCJHYXRoZXJCdWZmcyI6eyJCdWZmcyI6eyJCb29uSW5jcmVhc2UyIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MTAwLCJNYXhVc2UiOi0xfSwiQm9vbkluY3JlYXNlMSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xfSwiVGlkaW5ncyI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjIwMCwiTWF4VXNlIjotMX0sIllpZWxkSUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjUwMCwiTWF4VXNlIjotMX0sIllpZWxkSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjQwMCwiTWF4VXNlIjotMX0sIkJvdW50aWZ1bFlpZWxkSUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvbnVzSW50ZWdyaXR5Ijp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MzAwLCJNYXhVc2UiOi0xfSwiQm9udXNJbnRlZ3JpdHlDaGFuY2UiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyNTAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeVRlbXAiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX19LCJCb3VudGlmdWxNaW5JdGVtIjo0fX0=";
            string limitedMissions = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkxpbWl0ZWQgTm9kZXMiLCJNaW5pbXVtR3AiOjEwMCwiRHVhbENsYXNzQ3JhZnRBbW91bnQiOjEsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvb25JbmNyZWFzZTEiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX0sIlRpZGluZ3MiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyMDAsIk1heFVzZSI6LTF9LCJZaWVsZElJIjp7IkVuYWJsZWQiOnRydWUsIk1pbkdwIjo1MDAsIk1heFVzZSI6LTF9LCJZaWVsZEkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo0MDAsIk1heFVzZSI6LTF9LCJCb3VudGlmdWxZaWVsZElJIjp7IkVuYWJsZWQiOnRydWUsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTF9LCJCb251c0ludGVncml0eSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjMwMCwiTWF4VXNlIjotMX0sIkJvbnVzSW50ZWdyaXR5Q2hhbmNlIjp7IkVuYWJsZWQiOnRydWUsIk1pbkdwIjowLCJNYXhVc2UiOi0xfSwiRmllbGRNYXN0ZXJ5SUlJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MjUwLCJNYXhVc2UiOi0xfSwiRmllbGRNYXN0ZXJ5SUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xfSwiRmllbGRNYXN0ZXJ5VGVtcCI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTF9fSwiQm91bnRpZnVsTWluSXRlbSI6NH19";
            string chainedMissions = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkNoYWluZWQiLCJNaW5pbXVtR3AiOjEwMCwiRHVhbENsYXNzQ3JhZnRBbW91bnQiOjEsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTF9LCJCb29uSW5jcmVhc2UxIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTF9LCJUaWRpbmdzIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MjAwLCJNYXhVc2UiOi0xfSwiWWllbGRJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwMCwiTWF4VXNlIjotMX0sIllpZWxkSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjQwMCwiTWF4VXNlIjotMX0sIkJvdW50aWZ1bFlpZWxkSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTF9LCJCb251c0ludGVncml0eSI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6MzAwLCJNYXhVc2UiOi0xfSwiQm9udXNJbnRlZ3JpdHlDaGFuY2UiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyNTAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeVRlbXAiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX19LCJCb3VudGlmdWxNaW5JdGVtIjo0fX0=";
            string DualClass = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkR1YWwgQ2xhc3MiLCJNaW5pbXVtR3AiOjEwMCwiRHVhbENsYXNzQ3JhZnRBbW91bnQiOjIsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvb25JbmNyZWFzZTEiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xfSwiVGlkaW5ncyI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjIwMCwiTWF4VXNlIjotMX0sIllpZWxkSUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjUwMCwiTWF4VXNlIjotMX0sIllpZWxkSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjQwMCwiTWF4VXNlIjotMX0sIkJvdW50aWZ1bFlpZWxkSUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvbnVzSW50ZWdyaXR5Ijp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MzAwLCJNYXhVc2UiOi0xfSwiQm9udXNJbnRlZ3JpdHlDaGFuY2UiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyNTAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeVRlbXAiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX19LCJCb3VudGlmdWxNaW5JdGVtIjo0fX0=";
            string boonMissions = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkJvb24iLCJNaW5pbXVtR3AiOjEwMCwiRHVhbENsYXNzQ3JhZnRBbW91bnQiOjEsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvb25JbmNyZWFzZTEiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX0sIlRpZGluZ3MiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyMDAsIk1heFVzZSI6LTF9LCJZaWVsZElJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAwLCJNYXhVc2UiOi0xfSwiWWllbGRJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NDAwLCJNYXhVc2UiOi0xfSwiQm91bnRpZnVsWWllbGRJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvbnVzSW50ZWdyaXR5Ijp7IkVuYWJsZWQiOnRydWUsIk1pbkdwIjozMDAsIk1heFVzZSI6LTF9LCJCb251c0ludGVncml0eUNoYW5jZSI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6MCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeUlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjI1MCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeUlJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MTAwLCJNYXhVc2UiOi0xfSwiRmllbGRNYXN0ZXJ5SSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xfSwiRmllbGRNYXN0ZXJ5VGVtcCI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xfX0sIkJvdW50aWZ1bE1pbkl0ZW0iOjR9fQ==";
            string ChainBoonMission = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkNoYWluZWQgXHUwMDJCIEJvb24iLCJNaW5pbXVtR3AiOjEwMCwiRHVhbENsYXNzQ3JhZnRBbW91bnQiOjEsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvb25JbmNyZWFzZTEiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xfSwiVGlkaW5ncyI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjIwMCwiTWF4VXNlIjotMX0sIllpZWxkSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MDAsIk1heFVzZSI6LTF9LCJZaWVsZEkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo0MDAsIk1heFVzZSI6LTF9LCJCb3VudGlmdWxZaWVsZElJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MTAwLCJNYXhVc2UiOi0xfSwiQm9udXNJbnRlZ3JpdHkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjMwMCwiTWF4VXNlIjotMX0sIkJvbnVzSW50ZWdyaXR5Q2hhbmNlIjp7IkVuYWJsZWQiOnRydWUsIk1pbkdwIjowLCJNYXhVc2UiOi0xfSwiRmllbGRNYXN0ZXJ5SUlJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MjUwLCJNYXhVc2UiOi0xfSwiRmllbGRNYXN0ZXJ5SUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlUZW1wIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTF9fSwiQm91bnRpZnVsTWluSXRlbSI6NH19";
            string GatherXAmount = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkdhdGhlciBYIEFtb3VudCIsIk1pbmltdW1HcCI6LTEsIkR1YWxDbGFzc0NyYWZ0QW1vdW50IjoxLCJHYXRoZXJCdWZmcyI6eyJCdWZmcyI6eyJCb29uSW5jcmVhc2UyIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MTAwLCJNYXhVc2UiOi0xfSwiQm9vbkluY3JlYXNlMSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xfSwiVGlkaW5ncyI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjIwMCwiTWF4VXNlIjotMX0sIllpZWxkSUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjUwMCwiTWF4VXNlIjotMX0sIllpZWxkSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjQwMCwiTWF4VXNlIjotMX0sIkJvdW50aWZ1bFlpZWxkSUkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkJvbnVzSW50ZWdyaXR5Ijp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MzAwLCJNYXhVc2UiOi0xfSwiQm9udXNJbnRlZ3JpdHlDaGFuY2UiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyNTAsIk1heFVzZSI6LTF9LCJGaWVsZE1hc3RlcnlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX0sIkZpZWxkTWFzdGVyeVRlbXAiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMX19LCJCb3VudGlmdWxNaW5JdGVtIjo0fX0=";

            string GreaterReach_GatherX = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkdyZWF0ZXIgUmVhY2ggW0dhdGhlciBYXSIsIk1pbmltdW1HcCI6LTEsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJCb29uSW5jcmVhc2UxIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJUaWRpbmdzIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MjAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiWWllbGRJSSI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6NTAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiWWllbGRJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NDAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiQm91bnRpZnVsWWllbGRJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkJvbnVzSW50ZWdyaXR5Ijp7IkVuYWJsZWQiOnRydWUsIk1pbkdwIjozMDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJCb251c0ludGVncml0eUNoYW5jZSI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6MCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkZpZWxkTWFzdGVyeUlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjI1MCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkZpZWxkTWFzdGVyeUlJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MTAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiRmllbGRNYXN0ZXJ5SSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiRmllbGRNYXN0ZXJ5VGVtcCI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfX19fQ==";
            string GreaterReach_Boon = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkdyZWF0ZXIgUmVhY2ggW0Jvb25dIiwiTWluaW11bUdwIjotMSwiR2F0aGVyQnVmZnMiOnsiQnVmZnMiOnsiQm9vbkluY3JlYXNlMiI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6MTAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiQm9vbkluY3JlYXNlMSI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJUaWRpbmdzIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MjAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiWWllbGRJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIllpZWxkSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjQwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkJvdW50aWZ1bFlpZWxkSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJCb251c0ludGVncml0eSI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6MzAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiQm9udXNJbnRlZ3JpdHlDaGFuY2UiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJGaWVsZE1hc3RlcnlJSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyNTAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJGaWVsZE1hc3RlcnlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkZpZWxkTWFzdGVyeUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkZpZWxkTWFzdGVyeVRlbXAiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH19fX0=";
            string GreaterReach_Chain = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkdyZWF0ZXIgUmVhY2ggW0NoYWluXSIsIk1pbmltdW1HcCI6LTEsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJCb29uSW5jcmVhc2UxIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJUaWRpbmdzIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MjAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiWWllbGRJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjUwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIllpZWxkSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjQwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkJvdW50aWZ1bFlpZWxkSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJCb251c0ludGVncml0eSI6eyJFbmFibGVkIjp0cnVlLCJNaW5HcCI6MzAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiQm9udXNJbnRlZ3JpdHlDaGFuY2UiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJGaWVsZE1hc3RlcnlJSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoyNTAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJGaWVsZE1hc3RlcnlJSSI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkZpZWxkTWFzdGVyeUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkZpZWxkTWFzdGVyeVRlbXAiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH19fX0=";
            string GreaterReach_BoonCh = "IceGatherProfile_eyJJZCI6MCwiTmFtZSI6IkdyZWF0ZXIgUmVhY2ggW0Jvb24gXHUwMDJCIENoYWluXSIsIk1pbmltdW1HcCI6LTEsIkdhdGhlckJ1ZmZzIjp7IkJ1ZmZzIjp7IkJvb25JbmNyZWFzZTIiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjEwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkJvb25JbmNyZWFzZTEiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjUwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiVGlkaW5ncyI6eyJFbmFibGVkIjpmYWxzZSwiTWluR3AiOjIwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIllpZWxkSUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo1MDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJZaWVsZEkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjo0MDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJCb3VudGlmdWxZaWVsZElJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MTAwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiQm9udXNJbnRlZ3JpdHkiOnsiRW5hYmxlZCI6dHJ1ZSwiTWluR3AiOjMwMCwiTWF4VXNlIjotMSwiTWluVXNhYmxlRHVyYWJpbGl0eSI6MH0sIkJvbnVzSW50ZWdyaXR5Q2hhbmNlIjp7IkVuYWJsZWQiOnRydWUsIk1pbkdwIjowLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiRmllbGRNYXN0ZXJ5SUlJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6MjUwLCJNYXhVc2UiOi0xLCJNaW5Vc2FibGVEdXJhYmlsaXR5IjowfSwiRmllbGRNYXN0ZXJ5SUkiOnsiRW5hYmxlZCI6ZmFsc2UsIk1pbkdwIjoxMDAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJGaWVsZE1hc3RlcnlJIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9LCJGaWVsZE1hc3RlcnlUZW1wIjp7IkVuYWJsZWQiOmZhbHNlLCJNaW5HcCI6NTAsIk1heFVzZSI6LTEsIk1pblVzYWJsZUR1cmFiaWxpdHkiOjB9fX19";

            GatherSettings.InitialSetupProfile(timedMissions, MissionKinds.TimeAttack, out var _);
            GatherSettings.InitialSetupProfile(limitedMissions, MissionKinds.LimitedNodes, out var _);
            GatherSettings.InitialSetupProfile(chainedMissions, MissionKinds.Chain_Scoring, out var _);
            GatherSettings.InitialSetupProfile(boonMissions, MissionKinds.Boon_Scoring, out var _);
            GatherSettings.InitialSetupProfile(ChainBoonMission, MissionKinds.Chain_Boon, out var _);
            GatherSettings.InitialSetupProfile(DualClass, MissionKinds.DualClass, out var _);
            GatherSettings.InitialSetupProfile(GatherXAmount, MissionKinds.GatherX, out var _);
            GatherSettings.InitialSetupProfile(GreaterReach_GatherX, MissionKinds.GreaterReach_GatherX, out var _);
            GatherSettings.InitialSetupProfile(GreaterReach_Chain, MissionKinds.GreaterReach_Chain, out var _);
            GatherSettings.InitialSetupProfile(GreaterReach_Boon, MissionKinds.GreaterReach_Boon, out var _);
            GatherSettings.InitialSetupProfile(GreaterReach_BoonCh, MissionKinds.GreaterReach_Boon_Chain, out var _);

        }
    }
}