using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
internal class HyperVMachine : BaseVirtualEnvironment
{
	public override string Name => "Microsoft Hyper-V";

	public override bool ExcludeInterruptibleBroadcaster(IEnumerable<DiskDrive> ienumerable_0)
	{
		return ienumerable_0.Any((DiskDrive d) => d.Caption.Contains("virtual"));
	}

	public override bool EnableInterruptibleBroadcaster(ComputerSystem computerSystem_0)
	{
		if (computerSystem_0.Manufacturer.Contains("microsoft"))
		{
			return computerSystem_0.Model.Contains("virtual");
		}
		return false;
	}
}
