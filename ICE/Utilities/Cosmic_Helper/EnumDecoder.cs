using System;
using System.Collections.Generic;
using System.Text;

namespace ICE.Utilities.Cosmic_Helper;

public static unsafe partial class CosmicHelper
{
    public static string PlaylistOptionString(PlaylistOptions option)
    {
        if (CosmicMoonRegistry.TryGetMoonForMaxRelicOption(option, out var moon))
            return $"最大 {moon.DisplayName} 宇宙工具 [等级 {moon.MaxRelicStage}]";

        return option switch
        {
            PlaylistOptions.None => "无",
            PlaylistOptions.SelectedRelicLv => "已选宇宙工具等级",
            PlaylistOptions.CreditAmount => "宇宙信用点数量",
            PlaylistOptions.PlanetAmount => "行星信用点数量",
            PlaylistOptions.DronebitAmount => "行星无人机代币数量",
            PlaylistOptions.ClassLevel => "职业等级",
            PlaylistOptions.ClassScore => "职业分数",
            PlaylistOptions.GoldClassMissions => "全部任务金星",
            PlaylistOptions.ToolMaxExp => "工具经验最大值",
            _ => "???"
        };
    }
}
