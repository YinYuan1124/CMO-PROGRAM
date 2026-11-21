using System.ComponentModel;
using Command.Watchers;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[TypeConverter(typeof(ListRuleWatcher))]
[DoNotObfuscate]
[DoNotPrune]
public enum HoverInfoEnableEnum
{
	[Description("Show")]
	Show = 0,
	[Description("Hide")]
	Hide = 2
}
