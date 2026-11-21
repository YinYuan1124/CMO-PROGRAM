using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
internal class VirtualPcMachine : BaseVirtualEnvironment
{
	public override string Name => "Microsoft Virtual PC";

	public override bool IncludeInterruptibleBroadcaster(IEnumerable<string> ienumerable_0)
	{
		if (ienumerable_0.Contains("vpcmap") && ienumerable_0.Contains("vmsrvc"))
		{
			return true;
		}
		return ienumerable_0.Contains("vmusrvc");
	}
}
