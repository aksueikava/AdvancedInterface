using Exiled.API.Interfaces;
using System.ComponentModel;

namespace AdvancedInterface
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Are debug messages displayed?")]
        public bool Debug { get; set; } = false;

        [Description("Update interval for the hint in seconds.")]
        public float UpdateInterval { get; set; } = 1.0f;

        [Description("Server name to be displayed in the hint.")]
        public string ServerName { get; set; } = "<b><u>Server Name</u></b>";

        [Description("Round time format. Use placeholders: {0} - minutes, {1} - seconds.")]
        public string RoundTimeFormat { get; set; } = "The round runs: {0} minutes, {1} seconds.";

        [Description("Hint text format. Use placeholders: {0} - player role color, {1} - player nickname, {2} - player role, {3} - spectator count, {4} - kill count, {5} - server name, {6} - round time.")]
        public string HintText { get; set; } = @"
<size=25><align=left><voffset=20><color={0}>👤</color> <color={0}>|</color> {1}</voffset>
<color={0}>🎭</color> <color={0}>| Your role:</color> {2}
<color={0}>👥</color> <color={0}>| They are watching you:</color> <color={0}>{3}</color>
<color={0}>🔪</color> <color={0}>| Kills:</color> <color={0}>{4}</color></align></size>
<size=20><align=center><voffset=-15em><u><pos=-700>{5}</pos></u></voffset>\n<pos=-700>{6}</pos></align></size>";
    }
}