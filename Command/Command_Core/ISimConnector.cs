using System;
using System.Collections.Generic;

namespace Command_Core;

public interface ISimConnector
{
	public enum DistributedSimulationState : byte
	{
		StoppedFrozen,
		Running
	}

	public enum ExportedInfoType
	{
		None,
		Heartbeat,
		EntityState,
		WeaponFire,
		WeaponImpactOrDetonation,
		UnitDestroyed,
		AcousticEmission_Passive
	}

	public enum SimConnectorType
	{
		None,
		DIS
	}

	string Name { get; }

	int QueueLength { get; }

	SimConnectorType ConnectorType { get; }

	DistributedSimulationState SessionState { get; }

	bool ExportUnitPositions { get; set; }

	bool ExportWeaponFired { get; set; }

	bool ExportWeaponImpactOrDetonation { get; set; }

	bool ExportUnitDestroyed { get; set; }

	void ExportInfo(ExportedInfoType exportedInfoType_0, Dictionary<string, Tuple<Type, string>> dictionary_0, Scenario scenario_0);

	void Start();

	void SetScenario(Scenario scenario_0);

	void StopCleanUpAndReset();

	void PerformHousekeeping();

	bool UnitHasToSendHeartbeat(Module_Unit.Unit unit_0);
}
