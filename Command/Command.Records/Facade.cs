using System.Collections.Generic;

namespace Command.Records;

internal interface Facade
{
	string Name { get; }

	bool EnableInterruptibleBroadcaster(ComputerSystem computerSystem_0);

	bool EnableInterruptibleBroadcaster(BIOS bios_0);

	bool ExcludeInterruptibleBroadcaster(IEnumerable<DiskDrive> ienumerable_0);

	bool SetupInterruptibleBroadcaster(IEnumerable<PnPEntity> ienumerable_0);

	bool IncludeInterruptibleBroadcaster(IEnumerable<string> ienumerable_0);

	bool SearchInterruptibleBroadcaster(IEnumerable<WindowsService> ienumerable_0);

	bool ChangeInterruptibleBroadcaster(ComputerSystem computerSystem_0, BIOS bios_0, IEnumerable<DiskDrive> ienumerable_0, IEnumerable<PnPEntity> ienumerable_1, IEnumerable<string> ienumerable_2, IEnumerable<WindowsService> ienumerable_3);
}
