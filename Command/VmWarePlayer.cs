using System.Collections.Generic;
using System.Linq;
using SmartAssembly.Attributes;

[DoNotPrune]
[DoNotObfuscateType]
[DoNotPruneType]
internal class VmWarePlayer : VmWareMachine
{
	public override bool EnableInterruptibleBroadcaster(BIOS bios_0)
	{
		return bios_0.SerialNumber.Contains("vmware");
	}

	public override bool EnableInterruptibleBroadcaster(ComputerSystem computerSystem_0)
	{
		if (!computerSystem_0.Manufacturer.Contains("vmware") && !computerSystem_0.Model.Contains("vmware"))
		{
			if (computerSystem_0.OEMStringArray == null)
			{
				return false;
			}
			return computerSystem_0.OEMStringArray.Contains("virtual");
		}
		return true;
	}

	public override bool ExcludeInterruptibleBroadcaster(IEnumerable<DiskDrive> ienumerable_0)
	{
		return ienumerable_0.Any((DiskDrive d) => d.Model.Contains("vmware"));
	}

	public override bool SetupInterruptibleBroadcaster(IEnumerable<PnPEntity> ienumerable_0)
	{
		if (!ienumerable_0.Any((PnPEntity d) => d.Name.Equals("vmware pointing device")) && !ienumerable_0.Any((PnPEntity d) => d.Name.Contains("vmware sata")) && !ienumerable_0.Any((PnPEntity d) => d.Name.Equals("vmware usb pointing device")) && !ienumerable_0.Any((PnPEntity d) => d.Name.Equals("vmware vmci bus device")) && !ienumerable_0.Any((PnPEntity d) => d.Name.Equals("vmware virtual s scsi disk device")))
		{
			return ienumerable_0.Any((PnPEntity d) => d.Name.StartsWith("vmware svga"));
		}
		return true;
	}

	public override bool SearchInterruptibleBroadcaster(IEnumerable<WindowsService> ienumerable_0)
	{
		if (!ienumerable_0.Any((WindowsService s) => s.CancelStruct().Contains("vmware") && s.Name.Equals("vmtools")) && !ienumerable_0.Any((WindowsService s) => s.CancelStruct().Contains("vmware") && s.Name.Equals("tpvcgateway")))
		{
			return ienumerable_0.Any((WindowsService s) => s.CancelStruct().Contains("vmware") && s.Name.Equals("tpautoconnsvc"));
		}
		return true;
	}
}
