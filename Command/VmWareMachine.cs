using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPruneType]
[DoNotObfuscateType]
[DoNotPrune]
internal abstract class VmWareMachine : BaseVirtualEnvironment
{
	public override string Name => "VMware";

	public override bool ExcludeInterruptibleBroadcaster(IEnumerable<DiskDrive> ienumerable_0)
	{
		return ienumerable_0.Any((DiskDrive d) => d.Name.Contains("vmware"));
	}

	public override bool EnableInterruptibleBroadcaster(ComputerSystem computerSystem_0)
	{
		if (computerSystem_0.Manufacturer.Contains("vmware"))
		{
			return computerSystem_0.Model.Contains("virtual");
		}
		return false;
	}
}
