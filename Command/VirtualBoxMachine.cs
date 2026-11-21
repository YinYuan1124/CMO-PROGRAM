using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPrune]
[DoNotObfuscateType]
[DoNotPruneType]
internal class VirtualBoxMachine : BaseVirtualEnvironment
{
	public override string Name => "VirtualBox";

	public override bool ExcludeInterruptibleBroadcaster(IEnumerable<DiskDrive> ienumerable_0)
	{
		return ienumerable_0.Any((DiskDrive d) => d.Model.Contains("vbox"));
	}

	public override bool IncludeInterruptibleBroadcaster(IEnumerable<string> ienumerable_0)
	{
		return ienumerable_0.Contains("vboxservice");
	}
}
