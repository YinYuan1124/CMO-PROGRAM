using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
internal class QEmuMachine : BaseVirtualEnvironment
{
	public override string Name => "QEMU";

	public override bool ExcludeInterruptibleBroadcaster(IEnumerable<DiskDrive> ienumerable_0)
	{
		return ienumerable_0.Any((DiskDrive d) => d.Name.IndexOf("qemu") >= 0);
	}
}
