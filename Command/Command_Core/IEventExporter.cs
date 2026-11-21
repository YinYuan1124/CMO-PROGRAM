using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public interface IEventExporter
{
	[Serializable]
	public struct EventNotificationParameter
	{
		public object Value;

		public Type DataType;

		public int MaxStringLength;

		public EventNotificationParameter(object object_0, Type type_0, int int_0 = 0)
		{
			this = default(EventNotificationParameter);
			Value = RuntimeHelpers.GetObjectValue(object_0);
			DataType = type_0;
			MaxStringLength = int_0;
		}
	}

	public enum ExportedEventType
	{
		None = 0,
		WeaponFired = 1,
		WeaponEndgame = 2,
		FuelConsumed = 3,
		UnitDestroyed = 4,
		SensorDetectionAttempt = 5,
		const_6 = 6,
		UnitPositions = 7,
		EngagementCycle = 8,
		FuelTransfer = 9,
		WeaponImpact = 10,
		Explosion = 11,
		AirOps = 12,
		DockingOps = 13,
		WaterSplash = 14,
		ContactPositions = 15,
		SimExecution = 16,
		UnitPositions_Destruction = 17,
		UnitDamaged = 17,
		CargoTransfer = 18,
		Max = 19
	}

	public enum EventExportOutputRate
	{
		Unknown = -1,
		Continuous,
		Secondx1,
		Secondx2,
		Secondx5,
		const_5,
		const_6,
		Minutex1,
		Minutex5,
		const_9,
		const_10,
		Hourx1,
		Hourx6,
		Hourx12,
		Hourx24,
		SimSpeed
	}

	public enum EventExporterRunMode
	{
		Interactive,
		NonInteractive
	}

	[Serializable]
	public sealed class EventExportNotification
	{
		public ExportedEventType EventType;

		public Dictionary<string, EventNotificationParameter> EventParameters;

		public string FileExportFolder;

		public Scenario ParentScen;

		internal byte[] ToByteArray()
		{
			if (this == null)
			{
				return null;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
			binaryFormatter.Serialize(memoryStream, this);
			return memoryStream.ToArray();
		}

		public static EventExportNotification FromByteArray(byte[] byte_0)
		{
			try
			{
				using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				memoryStream.Write(byte_0, 0, byte_0.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				return (EventExportNotification)binaryFormatter.Deserialize(memoryStream);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return null;
			}
		}
	}

	public enum EventExporterType
	{
		None,
		XMLFile,
		CSVFile,
		MSAccess,
		const_4,
		const_5,
		TacviewRealtime,
		const_7,
		SQLite,
		TacviewPipe,
		SIMDIS
	}

	string Name { get; }

	int QueueLength { get; }

	string FileExportFolder { get; set; }

	EventExporterType ExporterType { get; }

	bool RequiresHeartbeatForStaticUnits { get; }

	bool UsesUnitMissionAndStatus { get; }

	bool UsesUnitDamage { get; }

	EventExporterRunMode RunMode { get; set; }

	bool IsOperating { get; set; }

	bool UsesRAMQueue { get; }

	bool UseZeroHour { get; set; }

	bool ExportSensorDetectionSuccess { get; set; }

	bool ExportSensorDetectionFailure { get; set; }

	bool ExportWeaponFired { get; set; }

	bool ExportWeaponEndgame { get; set; }

	bool ExportUnitPositions { get; set; }

	bool ExportEngagementCycle { get; set; }

	bool ExportUnitDestroyed { get; set; }

	bool ExportFuelConsumed { get; set; }

	bool ExportFuelTransfer { get; set; }

	bool ExportCargoTransfer { get; set; }

	bool ExportExplosions { get; set; }

	bool ExportWeaponImpacts { get; set; }

	bool ExportAirOps { get; set; }

	bool ExportDockingOps { get; set; }

	bool ExportUnitDamaged { get; set; }

	EventExporter_Common Common { get; set; }

	void ExportEvent(ExportedEventType exportedEventType_0, Dictionary<string, EventNotificationParameter> dictionary_0, Scenario scenario_0);

	void Start();

	void SetScenario(Scenario scenario_0);

	void StopCleanUpAndReset();

	void Shutdown();

	void SetOutputRate(ExportedEventType exportedEventType_0, EventExportOutputRate eventExportOutputRate_0);

	bool ShouldOutputNow(ExportedEventType exportedEventType_0, Scenario scenario_0);
}
