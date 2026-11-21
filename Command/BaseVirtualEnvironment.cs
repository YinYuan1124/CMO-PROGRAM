using System.Collections.Generic;
using Command.Records;
using SmartAssembly.Attributes;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
internal abstract class BaseVirtualEnvironment : Facade
{
	public abstract string Name { get; }

	public virtual bool SetupInterruptibleBroadcaster(IEnumerable<PnPEntity> ienumerable_0)
	{
		return false;
	}

	public virtual bool ExcludeInterruptibleBroadcaster(IEnumerable<DiskDrive> ienumerable_0)
	{
		return false;
	}

	public virtual bool IncludeInterruptibleBroadcaster(IEnumerable<string> ienumerable_0)
	{
		return false;
	}

	public virtual bool SearchInterruptibleBroadcaster(IEnumerable<WindowsService> ienumerable_0)
	{
		return false;
	}

	public virtual bool EnableInterruptibleBroadcaster(BIOS bios_0)
	{
		return false;
	}

	public virtual bool EnableInterruptibleBroadcaster(ComputerSystem computerSystem_0)
	{
		return false;
	}

	public virtual bool ChangeInterruptibleBroadcaster(ComputerSystem computerSystem_0, BIOS bios_0, IEnumerable<DiskDrive> ienumerable_0, IEnumerable<PnPEntity> ienumerable_1, IEnumerable<string> ienumerable_2, IEnumerable<WindowsService> ienumerable_3)
	{
		bool num = EnableInterruptibleBroadcaster(computerSystem_0);
		bool flag = EnableInterruptibleBroadcaster(bios_0);
		bool flag2 = ExcludeInterruptibleBroadcaster(ienumerable_0);
		bool flag3 = SetupInterruptibleBroadcaster(ienumerable_1);
		bool flag4 = IncludeInterruptibleBroadcaster(ienumerable_2);
		bool flag5 = SearchInterruptibleBroadcaster(ienumerable_3);
		return num || flag || flag2 || flag3 || flag4 || flag5;
	}
}
