using System.ComponentModel;
using Command.Watchers;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[TypeConverter(typeof(ListRuleWatcher))]
[DoNotPruneType]
public enum HoverInfoEnableDetailedEnum
{
	[Description("Show Detailed")]
	ShowDetailed,
	[Description("Show Summary")]
	ShowSummary,
	[Description("Hide")]
	Hide
}
