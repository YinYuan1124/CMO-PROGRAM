using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Pages;

namespace Command_Core;

public class EventExporter_Tacview2x : IEventExporter
{
	public enum _TypeOfNewObjectToDeclare
	{
		None,
		ActiveUnit,
		UnguidedWeapon,
		Contact,
		WeaponImpact,
		Explosion
	}

	[CompilerGenerated]
	private sealed class ItemCallbackCandidate
	{
		public IEventExporter.EventExportNotification Local_theNotification;

		public string Local_UnitObjectID;

		internal bool NewInterruptibleField(Side theSide)
		{
			return Operators.CompareString(theSide.Name, Local_theNotification.EventParameters["ObserverSide"].Value.ToString(), TextCompare: false) == 0;
		}

		internal bool PushInterruptibleField(Explosion theE)
		{
			return Operators.CompareString(theE.ObjectID, Local_UnitObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ServerComparator
	{
		public IEventExporter.EventExportNotification Local_theNotification;

		internal bool InvokeInterruptibleField(Side theSide)
		{
			return Operators.CompareString(theSide.Name, Local_theNotification.EventParameters["ObserverSide"].Value.ToString(), TextCompare: false) == 0;
		}

		internal bool SetupInterruptibleField(Side theSide)
		{
			return Operators.CompareString(theSide.Name, Local_theNotification.EventParameters["UnitSide"].Value.ToString(), TextCompare: false) == 0;
		}
	}

	private string m_BridgeClient;

	private bool _InvocationClient;

	private ConcurrentQueue<IEventExporter.EventExportNotification> m_ClassClient;

	private ConcurrentDictionary<string, Dictionary<string, long>> m_RequestClient;

	private Dictionary<string, StreamWriter> _ValueClient;

	private Thread tokenizerClient;

	protected string LastPrintedTimeString;

	protected static long UnitIDIncrement;

	private static Dictionary<long, Tuple<string, string, string, string>> m_StubClient;

	private EventWaitHandle m_WriterClient;

	private static Dictionary<string, DataTable> specificationClient;

	private static bool watcherClient;

	private static Dictionary<string, DataTable> reponseClient;

	private static bool _DescriptorClient;

	private bool poolClient;

	public readonly Dictionary<string, string> NewUnitCache;

	private static readonly object _TaskClient;

	private bool filterClient;

	[CompilerGenerated]
	private IEventExporter.EventExporterRunMode m_TestsClient;

	[CompilerGenerated]
	private bool m_InterpreterClient;

	[CompilerGenerated]
	private bool modelClient;

	[CompilerGenerated]
	private bool advisorClient;

	[CompilerGenerated]
	private bool serializerClient;

	[CompilerGenerated]
	private bool m_RefClient;

	[CompilerGenerated]
	private bool m_ErrorClient;

	[CompilerGenerated]
	private bool m_CodeClient;

	[CompilerGenerated]
	private bool statusClient;

	[CompilerGenerated]
	private string m_ProccesorClient;

	[CompilerGenerated]
	private EventExporter_Common m_ConfigurationClient;

	public IEventExporter.EventExporterRunMode RunMode
	{
		[CompilerGenerated]
		get
		{
			return m_TestsClient;
		}
		[CompilerGenerated]
		set
		{
			m_TestsClient = value;
		}
	}

	public bool ExportEngagementCycle
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterClient;
		}
		[CompilerGenerated]
		set
		{
			m_InterpreterClient = value;
		}
	}

	public bool ExportSensorDetectionFailure { get; set; }

	public bool ExportSensorDetectionSuccess { get; set; }

	public bool ExportUnitPositions
	{
		[CompilerGenerated]
		get
		{
			return modelClient;
		}
		[CompilerGenerated]
		set
		{
			modelClient = value;
		}
	}

	public bool ExportWeaponEndgame
	{
		[CompilerGenerated]
		get
		{
			return advisorClient;
		}
		[CompilerGenerated]
		set
		{
			advisorClient = value;
		}
	}

	public bool ExportWeaponFired { get; set; }

	public bool ExportUnitDestroyed
	{
		[CompilerGenerated]
		get
		{
			return serializerClient;
		}
		[CompilerGenerated]
		set
		{
			serializerClient = value;
		}
	}

	public bool ExportFuelConsumed
	{
		[CompilerGenerated]
		get
		{
			return m_RefClient;
		}
		[CompilerGenerated]
		set
		{
			m_RefClient = value;
		}
	}

	public bool ExportFuelTransfer
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorClient;
		}
		[CompilerGenerated]
		set
		{
			m_ErrorClient = value;
		}
	}

	public bool ExportCargoTransfer
	{
		[CompilerGenerated]
		get
		{
			return m_CodeClient;
		}
		[CompilerGenerated]
		set
		{
			m_CodeClient = value;
		}
	}

	public bool ExportAirOps { get; set; }

	public bool ExportDockingOps { get; set; }

	public bool UseZeroHour
	{
		[CompilerGenerated]
		get
		{
			return statusClient;
		}
		[CompilerGenerated]
		set
		{
			statusClient = value;
		}
	}

	public string FileExportFolder
	{
		[CompilerGenerated]
		get
		{
			return m_ProccesorClient;
		}
		[CompilerGenerated]
		set
		{
			m_ProccesorClient = value;
		}
	}

	public bool ExportUnitDamaged { get; set; }

	public EventExporter_Common Common
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationClient;
		}
		[CompilerGenerated]
		set
		{
			m_ConfigurationClient = value;
		}
	}

	public virtual int QueueLength => m_ClassClient.Count;

	public virtual string Name => "Tacview2x";

	public virtual IEventExporter.EventExporterType ExporterType => IEventExporter.EventExporterType.const_5;

	public bool ExportExplosions
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public bool ExportWeaponImpacts
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public bool RequiresHeartbeatForStaticUnits => false;

	public bool UsesRAMQueue => true;

	public virtual bool IsOperating
	{
		get
		{
			return filterClient;
		}
		set
		{
			filterClient = value;
		}
	}

	public bool UsesUnitMissionAndStatus => false;

	public bool UsesUnitDamage => false;

	static EventExporter_Tacview2x()
	{
		m_StubClient = new Dictionary<long, Tuple<string, string, string, string>>();
		specificationClient = new Dictionary<string, DataTable>();
		watcherClient = false;
		reponseClient = new Dictionary<string, DataTable>();
		_DescriptorClient = false;
		_TaskClient = RuntimeHelpers.GetObjectValue(new object());
	}

	public EventExporter_Tacview2x(IEventExporter.EventExporterRunMode eventExporterRunMode_0, string string_0)
	{
		Common = new EventExporter_Common(this);
		_InvocationClient = false;
		m_ClassClient = new ConcurrentQueue<IEventExporter.EventExportNotification>();
		m_RequestClient = new ConcurrentDictionary<string, Dictionary<string, long>>();
		_ValueClient = new Dictionary<string, StreamWriter>();
		m_WriterClient = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		poolClient = false;
		NewUnitCache = new Dictionary<string, string>();
		filterClient = true;
		RunMode = eventExporterRunMode_0;
		UseZeroHour = true;
		ExportUnitPositions = true;
		ExportWeaponFired = true;
		ExportUnitDestroyed = true;
		ExportWeaponEndgame = true;
		ExportFuelConsumed = false;
		ExportFuelTransfer = false;
		ExportCargoTransfer = false;
		ExportSensorDetectionSuccess = false;
		ExportSensorDetectionFailure = false;
		ExportAirOps = true;
		ExportDockingOps = true;
		ExportUnitDamaged = false;
		Common.GetCommonConfig("Tacview Settings");
		DefineRepository();
		if (ExporterType == IEventExporter.EventExporterType.const_5)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				FileExportFolder = GameGeneral.TopLevelWritablePath;
			}
			else
			{
				FileExportFolder = string_0;
			}
			Common.LoadPerUnitExportSettings();
			Start();
		}
	}

	private void DefineRepository()
	{
		try
		{
			if (!watcherClient && FileExistsNative.FileExistsFast(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"))
			{
				specificationClient.Add("Aircraft", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"));
				specificationClient.Add("Ship", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 1));
				specificationClient.Add("Submarine", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 2));
				specificationClient.Add("Facility", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 3));
				specificationClient.Add("Weapon", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 4));
				watcherClient = true;
			}
			if (!_DescriptorClient && FileExistsNative.FileExistsFast(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls"))
			{
				reponseClient.Add("Aircraft", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls"));
				reponseClient.Add("Ship", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 1));
				reponseClient.Add("Submarine", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 2));
				reponseClient.Add("Facility", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 3));
				reponseClient.Add("Weapon", ContextConsumer.SetupStub(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 4));
				_DescriptorClient = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			MessageBox.Show(string.Format("Unable to read {0}", GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"));
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void Start()
	{
		tokenizerClient = new Thread(PublishRepository);
		tokenizerClient.Priority = ThreadPriority.BelowNormal;
		switch (RunMode)
		{
		case IEventExporter.EventExporterRunMode.NonInteractive:
			tokenizerClient.Name = "Tacview 2.x Exporter (Monte Carlo) Thread";
			break;
		case IEventExporter.EventExporterRunMode.Interactive:
			tokenizerClient.Name = "Tacview v2.x Exporter (Interactive) Thread";
			break;
		}
		tokenizerClient.Start();
	}

	private void PublishRepository()
	{
		m_BridgeClient = Path.Combine(FileExportFolder, "Tacview2x.acmi");
		try
		{
			if (FileExistsNative.FileExistsFast(m_BridgeClient))
			{
				File.Delete(m_BridgeClient);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		while (true)
		{
			m_WriterClient.WaitOne();
			if (!_InvocationClient)
			{
				ResetRepository();
			}
		}
	}

	public virtual void ExportEvent(IEventExporter.ExportedEventType exportedEventType_0, Dictionary<string, IEventExporter.EventNotificationParameter> dictionary_0, Scenario scenario_0)
	{
		if (!poolClient)
		{
			if (!Directory.Exists(FileExportFolder))
			{
				Directory.CreateDirectory(FileExportFolder);
			}
			poolClient = true;
		}
		IEventExporter.EventExportNotification eventExportNotification = new IEventExporter.EventExportNotification();
		eventExportNotification.EventType = exportedEventType_0;
		eventExportNotification.EventParameters = dictionary_0;
		eventExportNotification.ParentScen = scenario_0;
		eventExportNotification.FileExportFolder = FileExportFolder;
		m_ClassClient.Enqueue(eventExportNotification);
		if (!_InvocationClient)
		{
			m_WriterClient.Set();
		}
	}

	protected static void PrintPositionAndAttitude(long long_0, Module_Unit.Unit unit_0, ref StringBuilder stringBuilder_0, IEventExporter.EventExportNotification eventExportNotification_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			stringBuilder.Append("T=");
			switch (eventExportNotification_0.EventType)
			{
			case IEventExporter.ExportedEventType.WeaponFired:
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["FiringUnitLongitude"].Value), 6))).Append("|");
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["FiringUnitLatitude"].Value), 6))).Append("|");
				stringBuilder.Append(Conversions.ToInteger(eventExportNotification_0.EventParameters["FiringUnitAltitude_m"].Value));
				break;
			case IEventExporter.ExportedEventType.ContactPositions:
			{
				Contact contact = (Contact)unit_0;
				string value3 = XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["ContactLongitude"].Value), 6));
				string value4 = XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["ContactLatitude"].Value), 6));
				string value5 = (string.IsNullOrEmpty(Conversions.ToString(eventExportNotification_0.EventParameters["ContactCourse"].Value)) ? "0" : XmlConvert.ToString(Math.Round(Conversions.ToSingle(eventExportNotification_0.EventParameters["ContactCourse"].Value), 1)));
				string value6 = null;
				if (string.IsNullOrEmpty(Conversions.ToString(eventExportNotification_0.EventParameters["ContactAltitude_m"].Value)))
				{
					if (contact.IsAir_GuidedWeapon_Contact)
					{
						value6 = "6000";
					}
					else if (!contact.IsOrbitalContact && !contact.IsBallisticTarget())
					{
						if (contact.IsLandContact)
						{
							value6 = Conversions.ToString((int)Terrain.GetElevation(Conversions.ToDouble(value4), Conversions.ToDouble(value3), bool_0: false, contact.GetUnitSide().ParentScen));
						}
						else if (contact.IsSubmergedContact)
						{
							value6 = Conversions.ToString((int)Math.Round((double)Terrain.GetElevation(Conversions.ToDouble(value4), Conversions.ToDouble(value3), bool_0: false, contact.GetUnitSide().ParentScen) / 2.0));
						}
						else if (contact.IsShipContact)
						{
							value6 = "0";
						}
						else if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						value6 = "200000";
					}
				}
				else
				{
					value6 = XmlConvert.ToString(Conversions.ToSingle(eventExportNotification_0.EventParameters["ContactAltitude_m"].Value));
				}
				string value7 = "";
				string value8 = "";
				if (unit_0.IsActiveUnit)
				{
					value7 = XmlConvert.ToString(Conversions.ToSingle(eventExportNotification_0.EventParameters["UnitAttitude_Roll"].Value));
					value8 = XmlConvert.ToString(Conversions.ToSingle(eventExportNotification_0.EventParameters["UnitAttitude_Pitch"].Value));
				}
				stringBuilder.Append(value3).Append("|");
				stringBuilder.Append(value4).Append("|");
				if ((!unit_0.IsShip || unit_0.IsFacility) && !string.IsNullOrEmpty(value6))
				{
					stringBuilder.Append(value6);
				}
				if (unit_0.IsActiveUnit)
				{
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(value7))
					{
						stringBuilder.Append(value7);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(value8))
					{
						stringBuilder.Append(value8);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(value5))
					{
						stringBuilder.Append(value5);
					}
				}
				break;
			}
			default:
			{
				string value = XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["UnitLongitude"].Value), 6));
				string value2 = XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["UnitLatitude"].Value), 6));
				string text = XmlConvert.ToString(Math.Round(Conversions.ToSingle(eventExportNotification_0.EventParameters["UnitCourse"].Value), 1));
				string text2 = Conversions.ToString(Conversions.ToInteger(eventExportNotification_0.EventParameters["UnitAltitude_m"].Value));
				string text3 = "";
				string text4 = "";
				if (unit_0.IsActiveUnit)
				{
					text3 = XmlConvert.ToString(Conversions.ToSingle(eventExportNotification_0.EventParameters["UnitAttitude_Roll"].Value));
					text4 = XmlConvert.ToString(Conversions.ToSingle(eventExportNotification_0.EventParameters["UnitAttitude_Pitch"].Value));
				}
				string item = text;
				string item2 = text2;
				string item3 = "";
				string item4 = "";
				if (unit_0.IsActiveUnit)
				{
					item3 = text3;
					item4 = text4;
				}
				lock (m_StubClient)
				{
					if (m_StubClient.ContainsKey(long_0))
					{
						Tuple<string, string, string, string> tuple = m_StubClient[long_0];
						bool flag = false;
						if (Operators.CompareString(tuple.Item1, text, TextCompare: false) != 0)
						{
							flag = true;
						}
						if (Operators.CompareString(tuple.Item2, text2, TextCompare: false) != 0)
						{
							flag = true;
						}
						if (Operators.CompareString(tuple.Item3, text3, TextCompare: false) == 0)
						{
							text3 = "";
						}
						else
						{
							flag = true;
						}
						if (Operators.CompareString(tuple.Item4, text4, TextCompare: false) == 0)
						{
							text4 = "";
						}
						else
						{
							flag = true;
						}
						if (flag)
						{
							m_StubClient[long_0] = new Tuple<string, string, string, string>(item, item2, item3, item4);
						}
					}
					else
					{
						m_StubClient.Add(long_0, new Tuple<string, string, string, string>(text, text2, text3, text4));
					}
				}
				stringBuilder.Append(value).Append("|");
				stringBuilder.Append(value2).Append("|");
				if ((!unit_0.IsShip || unit_0.IsFacility) && !string.IsNullOrEmpty(text2))
				{
					stringBuilder.Append(text2);
				}
				if (unit_0.IsActiveUnit)
				{
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(text3))
					{
						stringBuilder.Append(text3);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(text4))
					{
						stringBuilder.Append(text4);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(text))
					{
						stringBuilder.Append(text);
					}
				}
				break;
			}
			case IEventExporter.ExportedEventType.Explosion:
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["Longitude"].Value), 6))).Append("|");
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(eventExportNotification_0.EventParameters["Latitude"].Value), 6))).Append("|");
				stringBuilder.Append(Conversions.ToInteger(eventExportNotification_0.EventParameters["Altitude"].Value));
				break;
			case IEventExporter.ExportedEventType.WeaponEndgame:
				break;
			}
			stringBuilder_0.Append(stringBuilder.ToString());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void AwakeRepository(object object_0, ref StringBuilder stringBuilder_0)
	{
		stringBuilder_0.Append("Type=");
		if (!((ScenarioObject)object_0).IsActiveUnit && !((ScenarioObject)object_0).DisableWriter())
		{
			if ((object)object_0.GetType() == typeof(UnguidedWeapon))
			{
				stringBuilder_0.Append("+Weapon");
				switch (((UnguidedWeapon)object_0).Type)
				{
				case Weapon._WeaponType.Rocket:
					stringBuilder_0.Append("+Rocket");
					break;
				case Weapon._WeaponType.IronBomb:
					stringBuilder_0.Append("+Bomb");
					break;
				case Weapon._WeaponType.Gun:
					stringBuilder_0.Append("+Projectile");
					if (((UnguidedWeapon)object_0).Warheads.Length != 0)
					{
						if (((UnguidedWeapon)object_0).Warheads[0].Caliber == Warhead.WarheadCaliber.Gun_6_15mm)
						{
							stringBuilder_0.Append("+Bullet");
						}
						else
						{
							stringBuilder_0.Append("+Shell");
						}
					}
					break;
				}
			}
			else if ((object)object_0.GetType() == typeof(WeaponImpact))
			{
				stringBuilder_0.Append("+Explosion");
			}
			return;
		}
		ActiveUnit activeUnit = (((ScenarioObject)object_0).IsActiveUnit ? ((ActiveUnit)object_0) : ((Contact)object_0).ActualUnit);
		if (activeUnit.IsFixedFacility)
		{
			stringBuilder_0.Append("Static");
		}
		else if (activeUnit.IsSatellite)
		{
			stringBuilder_0.Append("Medium");
		}
		else
		{
			switch (activeUnit.VisualSizeClass)
			{
			case GlobalVariables.TargetVisualSizeClass.Stealthy:
			case GlobalVariables.TargetVisualSizeClass.VSmall:
				stringBuilder_0.Append("Minor");
				break;
			case GlobalVariables.TargetVisualSizeClass.Small:
				stringBuilder_0.Append("Light");
				break;
			case GlobalVariables.TargetVisualSizeClass.Medium:
				stringBuilder_0.Append("Medium");
				break;
			case GlobalVariables.TargetVisualSizeClass.Large:
			case GlobalVariables.TargetVisualSizeClass.VLarge:
				stringBuilder_0.Append("Heavy");
				break;
			}
		}
		switch (activeUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			stringBuilder_0.Append("+Air");
			if (((Aircraft)activeUnit).IsHelicopter)
			{
				stringBuilder_0.Append("+Rotorcraft");
			}
			else
			{
				stringBuilder_0.Append("+FixedWing");
			}
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			stringBuilder_0.Append("+Sea");
			switch (((Ship)activeUnit).Category)
			{
			case Ship._ShipCategory.SurfaceCombatant:
				stringBuilder_0.Append("+Warship");
				break;
			case Ship._ShipCategory.AviationShip:
			case Ship._ShipCategory.SurfaceCombatantAviation:
				stringBuilder_0.Append("+AircraftCarrier");
				break;
			}
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			stringBuilder_0.Append("+Sea+Watercraft+Submarine");
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			stringBuilder_0.Append("+Ground");
			if (activeUnit.IsFixedFacility)
			{
				if (activeUnit.HasAirFacilities)
				{
					if (activeUnit.AirFacilities_ReadOnly[0].IsOpenAirFacility)
					{
						stringBuilder_0.Append("+Aerodrome");
					}
					else
					{
						stringBuilder_0.Append("+Building");
					}
				}
				else
				{
					stringBuilder_0.Append("+Building");
				}
				break;
			}
			switch (((Facility)activeUnit).EnableBridge())
			{
			case IMobileGroundUnit._MobileUnitCategory.Armor:
				stringBuilder_0.Append("+Armor+Tank");
				break;
			case IMobileGroundUnit._MobileUnitCategory.Infantry:
				stringBuilder_0.Append("+Human");
				break;
			default:
				stringBuilder_0.Append("+Vehicle");
				break;
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
			case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
			case IMobileGroundUnit._MobileUnitCategory.Engineer:
			case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
				stringBuilder_0.Append("+Vehicle");
				break;
			case IMobileGroundUnit._MobileUnitCategory.AAA:
			case IMobileGroundUnit._MobileUnitCategory.SAM:
				stringBuilder_0.Append("+AntiAircraft");
				break;
			}
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			stringBuilder_0.Append("+Weapon");
			switch (((Weapon)activeUnit).Type)
			{
			case Weapon._WeaponType.GuidedProjectile:
				stringBuilder_0.Append("+Projectile");
				break;
			case Weapon._WeaponType.Decoy_Expendable:
			case Weapon._WeaponType.Decoy_Towed:
				stringBuilder_0.Append("+Decoy");
				break;
			case Weapon._WeaponType.GuidedWeapon:
				stringBuilder_0.Append("+Missile");
				break;
			case Weapon._WeaponType.BallisticMissile:
			case Weapon._WeaponType.RV:
			case Weapon._WeaponType.HGV:
				stringBuilder_0.Append("+Missile");
				break;
			case Weapon._WeaponType.Torpedo:
				stringBuilder_0.Append("+Torpedo");
				break;
			}
			break;
		}
		if (((ScenarioObject)object_0).DisableWriter())
		{
			stringBuilder_0.Append("+Static");
		}
	}

	protected static long DeclareNewUnit(string string_0, _TypeOfNewObjectToDeclare _TypeOfNewObjectToDeclare_0, string string_1, ref StringBuilder stringBuilder_0, Scenario scenario_0, Dictionary<string, long> dictionary_0, IEventExporter.EventExportNotification eventExportNotification_0, Dictionary<string, string> dictionary_1)
	{
		try
		{
			object taskClient = _TaskClient;
			ObjectFlowControl.CheckForSyncLockOnValueType(taskClient);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(taskClient, ref lockTaken);
				UnitIDIncrement++;
				switch (_TypeOfNewObjectToDeclare_0)
				{
				case _TypeOfNewObjectToDeclare.ActiveUnit:
				{
					if (!scenario_0.ActiveUnits.ContainsKey(string_0))
					{
						break;
					}
					ActiveUnit activeUnit = scenario_0.ActiveUnits[string_0];
					if (activeUnit == null)
					{
						return 0L;
					}
					if (string.IsNullOrEmpty(activeUnit.UnitClass))
					{
						return 0L;
					}
					long unitIDIncrement3 = UnitIDIncrement;
					dictionary_0.Add(string_0, unitIDIncrement3);
					stringBuilder_0.AppendLine().Append(unitIDIncrement3).Append(",");
					PrintPositionAndAttitude(unitIDIncrement3, activeUnit, ref stringBuilder_0, eventExportNotification_0);
					stringBuilder_0.Append(",");
					AwakeRepository(activeUnit, ref stringBuilder_0);
					stringBuilder_0.Append(",");
					switch (activeUnit.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						stringBuilder_0.Append("Length=").Append(((Aircraft)activeUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Aircraft)activeUnit).Span).Append(",");
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						stringBuilder_0.Append("Length=").Append(((Ship)activeUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Ship)activeUnit).Beam).Append(",");
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						stringBuilder_0.Append("Length=").Append(((Submarine)activeUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Submarine)activeUnit).Beam).Append(",");
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						stringBuilder_0.Append("Length=").Append(((Facility)activeUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Facility)activeUnit).Width).Append(",");
						if (!activeUnit.HasAirFacilities || !activeUnit.AirFacilities_ReadOnly[0].IsOpenAirFacility)
						{
							double value = ((Facility)activeUnit).Length / 4f;
							stringBuilder_0.Append("Height=").Append(value).Append(",");
						}
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						stringBuilder_0.Append("Length=").Append(((Weapon)activeUnit).Length).Append(",");
						break;
					}
					if (eventExportNotification_0.EventType == IEventExporter.ExportedEventType.WeaponFired)
					{
						stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["FiringUnitSide"].Value));
					}
					else if (eventExportNotification_0.EventType == IEventExporter.ExportedEventType.WeaponEndgame)
					{
						stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["WeaponSide"].Value));
					}
					else
					{
						stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["UnitSide"].Value));
					}
					stringBuilder_0.Append(",");
					string value2 = "Blue";
					switch (scenario_0.Sides_ReadOnly[0].GetConsidersThisSideToBe(activeUnit.GetUnitSide()))
					{
					case Misc.PostureStance.Neutral:
						value2 = "White";
						break;
					case Misc.PostureStance.Friendly:
						value2 = "Blue";
						break;
					case Misc.PostureStance.Unfriendly:
						value2 = "Orange";
						break;
					case Misc.PostureStance.Hostile:
						value2 = "Red";
						break;
					}
					stringBuilder_0.Append("Color=").Append(value2);
					stringBuilder_0.Append(",Name=").Append(activeUnit.UnitClass.Replace(",", "\\,")).Append(",Pilot=")
						.Append(activeUnit.Name.Replace(",", "\\,"));
					if (activeUnit.GetParentGroup() != null)
					{
						stringBuilder_0.Append(",Group=").Append(activeUnit.GetParentGroup().Name.Replace(",", "\\,"));
					}
					if (!string.IsNullOrEmpty(string_1))
					{
						long value3 = (dictionary_0.ContainsKey(string_1) ? dictionary_0[string_1] : DeclareNewUnit(string_1, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref stringBuilder_0, scenario_0, dictionary_0, eventExportNotification_0, dictionary_1));
						stringBuilder_0.Append(",Parent=").Append(value3);
					}
					dictionary_1[string_0] = stringBuilder_0.ToString();
					QueryRepository(activeUnit, scenario_0, stringBuilder_0);
					return unitIDIncrement3;
				}
				case _TypeOfNewObjectToDeclare.UnguidedWeapon:
				{
					if (!scenario_0.UnguidedWeapons.ContainsKey(string_0))
					{
						break;
					}
					UnguidedWeapon unguidedWeapon = scenario_0.UnguidedWeapons[string_0];
					if (unguidedWeapon == null)
					{
						return 0L;
					}
					if (unguidedWeapon.Type != Weapon._WeaponType.Laser && unguidedWeapon.Type != Weapon._WeaponType.Microwave && unguidedWeapon.Type != Weapon._WeaponType.LaserDazzler)
					{
						long unitIDIncrement4 = UnitIDIncrement;
						dictionary_0.Add(string_0, unitIDIncrement4);
						stringBuilder_0.AppendLine().Append(unitIDIncrement4).Append(",");
						if (eventExportNotification_0.EventType == IEventExporter.ExportedEventType.WeaponEndgame)
						{
							stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["WeaponSide"].Value));
						}
						else
						{
							stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["FiringUnitSide"].Value));
						}
						PrintPositionAndAttitude(unitIDIncrement4, unguidedWeapon, ref stringBuilder_0, eventExportNotification_0);
						stringBuilder_0.Append(",");
						AwakeRepository(unguidedWeapon, ref stringBuilder_0);
						stringBuilder_0.Append(",");
						if (eventExportNotification_0.EventType == IEventExporter.ExportedEventType.WeaponEndgame)
						{
							stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["WeaponSide"].Value));
						}
						else if (eventExportNotification_0.EventParameters.ContainsKey("FiringUnitSide"))
						{
							stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["FiringUnitSide"].Value));
						}
						else
						{
							stringBuilder_0.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(eventExportNotification_0.EventParameters["UnitSide"].Value));
						}
						stringBuilder_0.Append(",");
						string value4 = "Blue";
						switch (scenario_0.Sides_ReadOnly[0].GetConsidersThisSideToBe(unguidedWeapon.GetUnitSide()))
						{
						case Misc.PostureStance.Neutral:
							value4 = "White";
							break;
						case Misc.PostureStance.Friendly:
							value4 = "Blue";
							break;
						case Misc.PostureStance.Unfriendly:
							value4 = "Orange";
							break;
						case Misc.PostureStance.Hostile:
							value4 = "Red";
							break;
						}
						stringBuilder_0.Append("Color=").Append(value4);
						stringBuilder_0.Append(",Name=").Append(unguidedWeapon.UnitClass.Replace(",", ".")).Append(",Pilot=")
							.Append(unguidedWeapon.Name.Replace(",", "."));
						if (!string.IsNullOrEmpty(string_1))
						{
							long value5 = (dictionary_0.ContainsKey(string_1) ? dictionary_0[string_1] : DeclareNewUnit(string_1, _TypeOfNewObjectToDeclare.UnguidedWeapon, null, ref stringBuilder_0, scenario_0, dictionary_0, eventExportNotification_0, dictionary_1));
							stringBuilder_0.Append(",Parent=").Append(value5);
						}
						return unitIDIncrement4;
					}
					long unitIDIncrement5 = UnitIDIncrement;
					dictionary_0.Add(string_0, unitIDIncrement5);
					stringBuilder_0.AppendLine().Append(unitIDIncrement5).Append(",");
					PrintPositionAndAttitude(unitIDIncrement5, unguidedWeapon, ref stringBuilder_0, eventExportNotification_0);
					Conversions.ToString(eventExportNotification_0.EventParameters["FiringUnitID"].Value);
					string key = Conversions.ToString(eventExportNotification_0.EventParameters["TargetContactActualUnitID"].Value);
					long value6 = dictionary_0[key];
					stringBuilder_0.Append(",Type=Beam,FocusedTarget=").Append(value6);
					stringBuilder_0.Append("\r\n");
					TimeSpan timeSpan4 = TimeSpan.Parse(Conversions.ToString(eventExportNotification_0.EventParameters["Time"].Value));
					stringBuilder_0.Append("#" + Conversions.ToString(Math.Floor(timeSpan4.Add(new TimeSpan(0, 0, 2)).TotalSeconds)) + "." + timeSpan4.Milliseconds.ToString("D3"));
					stringBuilder_0.AppendLine().Append("-").Append(unitIDIncrement5)
						.Append("\r\n");
					stringBuilder_0.Append("#" + Conversions.ToString(Math.Floor(timeSpan4.TotalSeconds)) + "." + timeSpan4.Milliseconds.ToString("D3")).Append("\r\n");
					break;
				}
				case _TypeOfNewObjectToDeclare.Contact:
				{
					Contact contact = null;
					Side side = null;
					side = scenario_0.Sides_ReadOnly.Where((Side theSide) => Operators.CompareString(theSide.Name, eventExportNotification_0.EventParameters["ObserverSide"].Value.ToString(), TextCompare: false) == 0).FirstOrDefault();
					if (side == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return 0L;
					}
					foreach (Contact contacts_ in side.Contacts_List)
					{
						if (Operators.CompareString(contacts_.ObjectID, string_0, TextCompare: false) == 0)
						{
							contact = contacts_;
							break;
						}
					}
					if (contact == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return 0L;
					}
					ActiveUnit actualUnit = contact.ActualUnit;
					if (actualUnit == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return 0L;
					}
					if (string.IsNullOrEmpty(actualUnit.UnitClass))
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return 0L;
					}
					long unitIDIncrement6 = UnitIDIncrement;
					dictionary_0.Add(string_0, unitIDIncrement6);
					stringBuilder_0.AppendLine().Append(unitIDIncrement6).Append(",");
					PrintPositionAndAttitude(unitIDIncrement6, contact, ref stringBuilder_0, eventExportNotification_0);
					stringBuilder_0.Append(",");
					AwakeRepository(contact, ref stringBuilder_0);
					stringBuilder_0.Append(",");
					switch (actualUnit.UnitType)
					{
					case GlobalVariables.ActiveUnitType.Aircraft:
						stringBuilder_0.Append("Length=").Append(((Aircraft)actualUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Aircraft)actualUnit).Span).Append(",");
						break;
					case GlobalVariables.ActiveUnitType.Ship:
						stringBuilder_0.Append("Length=").Append(((Ship)actualUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Ship)actualUnit).Beam).Append(",");
						break;
					case GlobalVariables.ActiveUnitType.Submarine:
						stringBuilder_0.Append("Length=").Append(((Submarine)actualUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Submarine)actualUnit).Beam).Append(",");
						break;
					case GlobalVariables.ActiveUnitType.Facility:
						stringBuilder_0.Append("Length=").Append(((Facility)actualUnit).Length).Append(",");
						stringBuilder_0.Append("Width=").Append(((Facility)actualUnit).Width).Append(",");
						if (!actualUnit.HasAirFacilities || !actualUnit.AirFacilities_ReadOnly[0].IsOpenAirFacility)
						{
							double value7 = ((Facility)actualUnit).Length / 4f;
							stringBuilder_0.Append("Height=").Append(value7).Append(",");
						}
						break;
					case GlobalVariables.ActiveUnitType.Weapon:
						stringBuilder_0.Append("Length=").Append(((Weapon)actualUnit).Length).Append(",");
						break;
					}
					string value8 = "White";
					switch (contact.GetStance(side))
					{
					case Misc.PostureStance.Neutral:
						value8 = "Green";
						break;
					case Misc.PostureStance.Friendly:
						value8 = "Blue";
						break;
					case Misc.PostureStance.Unfriendly:
						value8 = "Orange";
						break;
					case Misc.PostureStance.Hostile:
						value8 = "Red";
						break;
					case Misc.PostureStance.Unknown:
						value8 = "Yellow";
						break;
					}
					stringBuilder_0.Append("Color=").Append(value8);
					stringBuilder_0.Append(",Name=").Append(contact.Name.Replace(",", "\\,"));
					if (actualUnit.GetParentGroup() != null)
					{
						stringBuilder_0.Append(",Group=").Append(actualUnit.GetParentGroup().Name.Replace(",", "\\,"));
					}
					if (!string.IsNullOrEmpty(string_1))
					{
						long value9 = (dictionary_0.ContainsKey(string_1) ? dictionary_0[string_1] : DeclareNewUnit(string_1, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref stringBuilder_0, scenario_0, dictionary_0, eventExportNotification_0, dictionary_1));
						stringBuilder_0.Append(",Parent=").Append(value9);
					}
					dictionary_1[string_0] = stringBuilder_0.ToString();
					if (contact.IDStatus < Contact_Base.IdentificationStatus.KnownClass && !actualUnit.GetIsAutoDetectable(null) && !actualUnit.GetIsAutoDetectable(side))
					{
						switch (contact.Type)
						{
						case Contact_Base.ContactType.Missile:
							stringBuilder_0.Append(",Shape=Missile.GenericMRBM.obj");
							break;
						case Contact_Base.ContactType.Orbital:
							stringBuilder_0.Append(",Shape=Spacecraft.Satellite.obj");
							break;
						case Contact_Base.ContactType.Torpedo:
							stringBuilder_0.Append(",Shape=Core.Torpedo.obj");
							break;
						case Contact_Base.ContactType.Air:
						case Contact_Base.ContactType.Decoy_Air:
							if (((Aircraft)actualUnit).IsHelicopter)
							{
								stringBuilder_0.Append(",Shape=TransparentHelo.obj");
							}
							else
							{
								stringBuilder_0.Append(",Shape=TransparentBogie.obj");
							}
							break;
						case Contact_Base.ContactType.Surface:
						case Contact_Base.ContactType.Decoy_Surface:
							stringBuilder_0.Append(",Shape=TransparentSkunk.obj");
							break;
						case Contact_Base.ContactType.Facility_Mobile:
						case Contact_Base.ContactType.Decoy_Land:
							stringBuilder_0.Append(",Shape=TransparentVehicle.obj");
							break;
						case Contact_Base.ContactType.Submarine:
						case Contact_Base.ContactType.Decoy_Sub:
							stringBuilder_0.Append(",Shape=TransparentGoblin.obj");
							break;
						case Contact_Base.ContactType.Sonobuoy:
							stringBuilder_0.Append(",Shape=apache.sonobuoy");
							break;
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							break;
						case Contact_Base.ContactType.Aimpoint:
						case Contact_Base.ContactType.Facility_Fixed:
						case Contact_Base.ContactType.Installation:
						case Contact_Base.ContactType.AirBase:
						case Contact_Base.ContactType.NavalBase:
						case Contact_Base.ContactType.ActivationPoint:
							QueryRepository(actualUnit, scenario_0, stringBuilder_0);
							break;
						}
						DeclareNewUnit(string_0, _TypeOfNewObjectToDeclare.Contact, string_1, ref stringBuilder_0, scenario_0, dictionary_0, eventExportNotification_0, dictionary_1);
					}
					else
					{
						QueryRepository(actualUnit, scenario_0, stringBuilder_0);
					}
					return unitIDIncrement6;
				}
				case _TypeOfNewObjectToDeclare.WeaponImpact:
				{
					long unitIDIncrement2 = UnitIDIncrement;
					dictionary_0.Add(string_0, unitIDIncrement2);
					stringBuilder_0.AppendLine().Append(unitIDIncrement2).Append(",");
					Scenario scenario_ = null;
					WeaponImpact unit_ = new WeaponImpact(ref scenario_, 0.0, 0.0, 0f, WeaponImpact.ImpactType.Kinetic, 0);
					PrintPositionAndAttitude(unitIDIncrement2, unit_, ref stringBuilder_0, eventExportNotification_0);
					stringBuilder_0.Append(",Type=Misc+Explosion");
					stringBuilder_0.Append("\r\n");
					TimeSpan timeSpan3 = TimeSpan.Parse(Conversions.ToString(eventExportNotification_0.EventParameters["Time"].Value));
					stringBuilder_0.Append("#" + Conversions.ToString(Math.Floor(timeSpan3.Add(new TimeSpan(0, 0, 5)).TotalSeconds)) + "." + timeSpan3.Milliseconds.ToString("D3"));
					stringBuilder_0.AppendLine().Append("-").Append(unitIDIncrement2)
						.Append("\r\n");
					stringBuilder_0.Append("#" + Conversions.ToString(Math.Floor(timeSpan3.TotalSeconds)) + "." + timeSpan3.Milliseconds.ToString("D3")).Append("\r\n");
					return unitIDIncrement2;
				}
				case _TypeOfNewObjectToDeclare.Explosion:
				{
					long unitIDIncrement = UnitIDIncrement;
					Explosion explosion = eventExportNotification_0.ParentScen.Explosions.Where((Explosion theE) => Operators.CompareString(theE.ObjectID, string_0, TextCompare: false) == 0).FirstOrDefault();
					if (explosion == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return 0L;
					}
					dictionary_0.Add(string_0, unitIDIncrement);
					stringBuilder_0.AppendLine().Append(unitIDIncrement).Append(",");
					PrintPositionAndAttitude(unitIDIncrement, explosion, ref stringBuilder_0, eventExportNotification_0);
					stringBuilder_0.Append(",Radius=1,Type=Misc+Explosion").Append("\r\n");
					Weapon.DetonationMedium detonationMedium_ = (Module_Unit.ResetTokenizer(explosion) ? ((explosion.CurrentAltitude_AGL < 0f) ? Weapon.DetonationMedium.Underground : Weapon.DetonationMedium.Air) : ((explosion.GetCurrentAltitude() < 0f) ? Weapon.DetonationMedium.Underwater : Weapon.DetonationMedium.Air));
					float num = 0f;
					switch (explosion.WarheadType)
					{
					case Warhead.WarheadType.Incendiary:
						num = (float)Math.Sqrt(2100.0 / Math.PI);
						break;
					case Warhead.WarheadType.Fragmentation:
						num = Explosion.GetCutoffRange_Frag_nm(explosion.ExpYield, detonationMedium_);
						break;
					case Warhead.WarheadType.HE_BlastFrag:
					case Warhead.WarheadType.SemiAP:
					case Warhead.WarheadType.HardTargetPenetrator:
					case Warhead.WarheadType.Torpedo:
					case Warhead.WarheadType.DepthCharge:
					case Warhead.WarheadType.Nuclear:
						num = Explosion.GetCutoffRange_Blast_nm(explosion.ExpYield, detonationMedium_);
						break;
					case Warhead.WarheadType.FAE:
						num = (float)(explosion.ExpYield / 5.0);
						break;
					}
					TimeSpan timeSpan = TimeSpan.Parse(Conversions.ToString(eventExportNotification_0.EventParameters["Time"].Value));
					float maxDuration = explosion.MaxDuration;
					float num2 = 0.1f;
					TimeSpan timeSpan2;
					do
					{
						timeSpan2 = timeSpan.Add(new TimeSpan(0, 0, 0, 0, (int)Math.Round(maxDuration * num2 * 1000f)));
						stringBuilder_0.Append("#" + Conversions.ToString(Math.Floor(timeSpan2.TotalSeconds)) + "." + timeSpan2.Milliseconds.ToString("D3"));
						stringBuilder_0.AppendLine().Append(unitIDIncrement).Append(",");
						PrintPositionAndAttitude(unitIDIncrement, explosion, ref stringBuilder_0, eventExportNotification_0);
						stringBuilder_0.Append(",Radius=").Append((int)Math.Round((double)(num2 * num) * 1852.0));
						stringBuilder_0.Append("\r\n");
						num2 += 0.1f;
					}
					while (num2 <= 1f);
					stringBuilder_0.Append("#" + Conversions.ToString(Math.Floor(timeSpan2.Add(new TimeSpan(0, 0, 1)).TotalSeconds)) + "." + timeSpan.Milliseconds.ToString("D3"));
					stringBuilder_0.AppendLine().Append("-").Append(unitIDIncrement)
						.Append("\r\n");
					stringBuilder_0.Append("#" + Conversions.ToString(Math.Floor(timeSpan.TotalSeconds)) + "." + timeSpan.Milliseconds.ToString("D3")).Append("\r\n");
					return unitIDIncrement;
				}
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(taskClient);
				}
			}
			return 0L;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
			return 0L;
		}
	}

	private static void QueryRepository(object object_0, Scenario scenario_0, StringBuilder stringBuilder_0)
	{
		string dBUsed = scenario_0.DBUsed;
		DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
		switch (DBOps.GetDBRecordByHash(dBUsed, ref dbfileCheckResult_, bool_0: false, bool_1: false).DBID)
		{
		case 2:
		{
			DataTable dataTable2 = null;
			switch (((ActiveUnit)object_0).UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				dataTable2 = reponseClient["Aircraft"];
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				dataTable2 = reponseClient["Ship"];
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				dataTable2 = reponseClient["Submarine"];
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				dataTable2 = reponseClient["Weapon"];
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				stringBuilder_0.Append(",Shape=Spacecraft.Satellite.obj");
				break;
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
				dataTable2 = reponseClient["Facility"];
				break;
			}
			if (((ScenarioObject)object_0).IsSatellite || dataTable2 == null)
			{
				break;
			}
			string right2 = ((ActiveUnit)object_0).DBID.ToString();
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = dataTable2.Rows.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DataRow dataRow2 = (DataRow)enumerator2.Current;
					if (Operators.CompareString(Conversions.ToString(dataRow2["DBID"]), right2, TextCompare: false) == 0)
					{
						stringBuilder_0.Append(",Shape=").Append(RuntimeHelpers.GetObjectValue(dataRow2["Mesh"]));
						break;
					}
				}
				break;
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
		}
		case 1:
		{
			DataTable dataTable = null;
			switch (((ActiveUnit)object_0).UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				dataTable = specificationClient["Aircraft"];
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				dataTable = specificationClient["Ship"];
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				dataTable = specificationClient["Submarine"];
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				dataTable = specificationClient["Weapon"];
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				stringBuilder_0.Append(",Shape=Spacecraft.Satellite.obj");
				break;
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
				dataTable = specificationClient["Facility"];
				break;
			}
			if (((ScenarioObject)object_0).IsSatellite || dataTable == null)
			{
				break;
			}
			string right = ((ActiveUnit)object_0).DBID.ToString();
			IEnumerator enumerator = null;
			try
			{
				enumerator = dataTable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					if (Operators.CompareString(Conversions.ToString(dataRow["DBID"]), right, TextCompare: false) == 0)
					{
						stringBuilder_0.Append(",Shape=").Append(RuntimeHelpers.GetObjectValue(dataRow["Mesh"]));
						break;
					}
				}
				break;
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}
		}
	}

	protected static string GetEventString(IEventExporter.EventExportNotification eventExportNotification_0, Dictionary<string, long> dictionary_0, ref string string_0, Dictionary<string, string> dictionary_1)
	{
		try
		{
			StringBuilder stringBuilder_ = new StringBuilder();
			stringBuilder_.Clear();
			TimeSpan timeSpan = TimeSpan.Parse(Conversions.ToString(eventExportNotification_0.EventParameters["Time"].Value));
			string text = "#" + Conversions.ToString(Math.Floor(timeSpan.TotalSeconds)) + "." + timeSpan.Milliseconds.ToString("D3");
			if (Operators.CompareString(text, string_0, TextCompare: false) != 0)
			{
				stringBuilder_.AppendLine().AppendLine().Append(text);
				string_0 = text;
			}
			bool flag = false;
			if (eventExportNotification_0.EventType == IEventExporter.ExportedEventType.UnitPositions_Destruction)
			{
				eventExportNotification_0.EventType = IEventExporter.ExportedEventType.UnitPositions;
				flag = true;
			}
			switch (eventExportNotification_0.EventType)
			{
			case IEventExporter.ExportedEventType.WeaponFired:
			{
				string text4 = Conversions.ToString(eventExportNotification_0.EventParameters["WeaponID"].Value);
				string text5 = Conversions.ToString(eventExportNotification_0.EventParameters["FiringUnitID"].Value);
				if (!dictionary_0.ContainsKey(text5))
				{
					DeclareNewUnit(text5, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1);
					stringBuilder_.Append("\r\n");
				}
				if (eventExportNotification_0.ParentScen.ActiveUnits.ContainsKey(text4))
				{
					DeclareNewUnit(text4, _TypeOfNewObjectToDeclare.ActiveUnit, text5, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1);
				}
				else
				{
					DeclareNewUnit(text4, _TypeOfNewObjectToDeclare.UnguidedWeapon, text5, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1);
				}
				break;
			}
			case IEventExporter.ExportedEventType.WeaponEndgame:
			{
				string text2 = Conversions.ToString(eventExportNotification_0.EventParameters["WeaponID"].Value);
				string left2 = Conversions.ToString(eventExportNotification_0.EventParameters["Result"].Value);
				if (Operators.CompareString(left2, "HIT", TextCompare: false) != 0 && Operators.CompareString(left2, "KILL", TextCompare: false) != 0)
				{
					return stringBuilder_.ToString();
				}
				long num7 = (dictionary_0.ContainsKey(text2) ? dictionary_0[text2] : (eventExportNotification_0.ParentScen.ActiveUnits.ContainsKey(text2) ? DeclareNewUnit(text2, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1) : DeclareNewUnit(text2, _TypeOfNewObjectToDeclare.UnguidedWeapon, null, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1)));
				if (num7 == 0)
				{
					return stringBuilder_.ToString();
				}
				stringBuilder_.AppendLine().Append("-").Append(num7);
				dictionary_0[text2] = 0L;
				break;
			}
			case IEventExporter.ExportedEventType.UnitDestroyed:
			{
				string key2 = Conversions.ToString(eventExportNotification_0.EventParameters["UnitID"].Value);
				if (dictionary_0.ContainsKey(key2))
				{
					long num5 = dictionary_0[key2];
					if (num5 == 0)
					{
						return stringBuilder_.ToString();
					}
					stringBuilder_.AppendLine().Append("-").Append(num5);
					dictionary_0[key2] = 0L;
					break;
				}
				return stringBuilder_.ToString();
			}
			case IEventExporter.ExportedEventType.UnitPositions:
			{
				string text8 = Conversions.ToString(eventExportNotification_0.EventParameters["UnitID"].Value);
				ActiveUnit activeUnit = null;
				UnguidedWeapon unguidedWeapon = null;
				if (eventExportNotification_0.ParentScen.ActiveUnits.ContainsKey(text8))
				{
					activeUnit = eventExportNotification_0.ParentScen.ActiveUnits[text8];
					if (activeUnit == null || (activeUnit.IsDestroyed && flag))
					{
						return stringBuilder_.ToString();
					}
				}
				else if (eventExportNotification_0.ParentScen.UnguidedWeapons.ContainsKey(text8))
				{
					unguidedWeapon = eventExportNotification_0.ParentScen.UnguidedWeapons[text8];
					if (unguidedWeapon == null)
					{
						return stringBuilder_.ToString();
					}
				}
				if (dictionary_0.ContainsKey(text8))
				{
					long num3 = dictionary_0[text8];
					if (num3 == 0)
					{
						return stringBuilder_.ToString();
					}
					stringBuilder_.AppendLine().Append(num3).Append(",");
					if (activeUnit == null)
					{
						if (unguidedWeapon != null)
						{
							PrintPositionAndAttitude(num3, unguidedWeapon, ref stringBuilder_, eventExportNotification_0);
						}
					}
					else
					{
						PrintPositionAndAttitude(num3, activeUnit, ref stringBuilder_, eventExportNotification_0);
					}
				}
				else
				{
					DeclareNewUnit(text8, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1);
				}
				break;
			}
			case IEventExporter.ExportedEventType.EngagementCycle:
			{
				string text6 = Conversions.ToString(eventExportNotification_0.EventParameters["CycleAction"].Value);
				if (Operators.CompareString(text6, "Dropping contact", TextCompare: false) == 0)
				{
					string key = Conversions.ToString(eventExportNotification_0.EventParameters["ContactID"].Value);
					if (!dictionary_0.ContainsKey(key))
					{
						return stringBuilder_.ToString();
					}
					long num2 = dictionary_0[key];
					if (num2 == 0)
					{
						return stringBuilder_.ToString();
					}
					stringBuilder_.AppendLine().Append("-").Append(num2);
					dictionary_0[key] = 0L;
				}
				else
				{
					if (!text6.StartsWith("Contact ID status changed"))
					{
						break;
					}
					string text7 = Conversions.ToString(eventExportNotification_0.EventParameters["ContactID"].Value);
					if (!dictionary_0.TryGetValue(text7, out var value))
					{
						return stringBuilder_.ToString();
					}
					if (value == 0)
					{
						return stringBuilder_.ToString();
					}
					Contact contact2 = null;
					Side side2 = null;
					side2 = eventExportNotification_0.ParentScen.Sides_ReadOnly.Where((Side theSide) => Operators.CompareString(theSide.Name, eventExportNotification_0.EventParameters["UnitSide"].Value.ToString(), TextCompare: false) == 0).FirstOrDefault();
					if (side2 == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return stringBuilder_.ToString();
					}
					foreach (Contact contacts_ in side2.Contacts_List)
					{
						if (Operators.CompareString(contacts_.ObjectID, text7, TextCompare: false) == 0)
						{
							contact2 = contacts_;
							break;
						}
					}
					if (contact2 == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return stringBuilder_.ToString();
					}
					stringBuilder_.AppendLine().Append(value).Append(",");
					switch (contact2.IDStatus)
					{
					case Contact_Base.IdentificationStatus.KnownClass:
					case Contact_Base.IdentificationStatus.PreciseID:
						stringBuilder_.Append("Name=").Append(contact2.ActualUnit.UnitClass.Replace(",", "\\,")).Append(",Pilot=")
							.Append(contact2.Name.Replace(",", "\\,"));
						QueryRepository(contact2.ActualUnit, eventExportNotification_0.ParentScen, stringBuilder_);
						break;
					case Contact_Base.IdentificationStatus.KnownType:
						stringBuilder_.Append("Name=").Append(contact2.Name.Replace(",", "\\,"));
						if (contact2.IsSubmergedContact)
						{
							QueryRepository(contact2.ActualUnit, eventExportNotification_0.ParentScen, stringBuilder_);
						}
						break;
					}
				}
				break;
			}
			case IEventExporter.ExportedEventType.WeaponImpact:
			{
				string text10 = Conversions.ToString(eventExportNotification_0.EventParameters["UnitID"].Value);
				if (!dictionary_0.ContainsKey(text10))
				{
					DeclareNewUnit(text10, _TypeOfNewObjectToDeclare.WeaponImpact, null, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1);
				}
				break;
			}
			case IEventExporter.ExportedEventType.Explosion:
			{
				string text9 = Conversions.ToString(eventExportNotification_0.EventParameters["ExplosionID"].Value);
				long num4 = (dictionary_0.ContainsKey(text9) ? dictionary_0[text9] : DeclareNewUnit(text9, _TypeOfNewObjectToDeclare.Explosion, null, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1));
				Explosion explosion = null;
				for (int i = eventExportNotification_0.ParentScen.Explosions.Count - 1; i >= 0; i += -1)
				{
					try
					{
						Explosion explosion2 = eventExportNotification_0.ParentScen.Explosions[i];
						if (string.CompareOrdinal(explosion2.ObjectID, text9) == 0)
						{
							explosion = explosion2;
							break;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						break;
					}
				}
				if (explosion == null)
				{
					return null;
				}
				stringBuilder_.AppendLine().Append(num4).Append(",");
				PrintPositionAndAttitude(num4, explosion, ref stringBuilder_, eventExportNotification_0);
				stringBuilder_.Append(",Type=Misc+Explosion");
				break;
			}
			case IEventExporter.ExportedEventType.AirOps:
			case IEventExporter.ExportedEventType.DockingOps:
			{
				string left = Conversions.ToString(eventExportNotification_0.EventParameters["Action"].Value);
				if (Operators.CompareString(left, "Landing", TextCompare: false) == 0 || Operators.CompareString(left, "Docking", TextCompare: false) == 0)
				{
					string key3 = Conversions.ToString(eventExportNotification_0.EventParameters["UnitID"].Value);
					if (!dictionary_0.ContainsKey(key3))
					{
						return stringBuilder_.ToString();
					}
					long num6 = dictionary_0[key3];
					if (num6 == 0)
					{
						return stringBuilder_.ToString();
					}
					stringBuilder_.AppendLine().Append("-").Append(num6);
					dictionary_0[key3] = 0L;
				}
				break;
			}
			case IEventExporter.ExportedEventType.ContactPositions:
			{
				string text3 = Conversions.ToString(eventExportNotification_0.EventParameters["ContactID"].Value);
				if (dictionary_0.ContainsKey(text3))
				{
					long num = dictionary_0[text3];
					if (num == 0)
					{
						return stringBuilder_.ToString();
					}
					Contact contact = null;
					Side side = null;
					side = eventExportNotification_0.ParentScen.Sides_ReadOnly.Where((Side theSide) => Operators.CompareString(theSide.Name, eventExportNotification_0.EventParameters["ObserverSide"].Value.ToString(), TextCompare: false) == 0).FirstOrDefault();
					if (side == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return stringBuilder_.ToString();
					}
					foreach (Contact contacts_2 in side.Contacts_List)
					{
						if (Operators.CompareString(contacts_2.ObjectID, text3, TextCompare: false) == 0)
						{
							contact = contacts_2;
							break;
						}
					}
					if (contact == null)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return stringBuilder_.ToString();
					}
					stringBuilder_.AppendLine().Append(num).Append(",");
					PrintPositionAndAttitude(num, contact, ref stringBuilder_, eventExportNotification_0);
				}
				else
				{
					DeclareNewUnit(text3, _TypeOfNewObjectToDeclare.Contact, null, ref stringBuilder_, eventExportNotification_0.ParentScen, dictionary_0, eventExportNotification_0, dictionary_1);
				}
				break;
			}
			}
			return stringBuilder_.ToString();
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private void ResetRepository()
	{
		_InvocationClient = true;
		IEventExporter.EventExportNotification result = null;
		while (m_ClassClient.Count > 0)
		{
			try
			{
				m_ClassClient.TryDequeue(out result);
				if (!Information.IsNothing(result))
				{
					m_BridgeClient = Path.Combine(result.FileExportFolder, "Tacview2x.acmi");
					Dictionary<string, long> dictionary;
					if (m_RequestClient.ContainsKey(m_BridgeClient))
					{
						dictionary = m_RequestClient[m_BridgeClient];
					}
					else
					{
						dictionary = new Dictionary<string, long>();
						m_RequestClient.TryAdd(m_BridgeClient, dictionary);
					}
					StreamWriter streamWriter;
					if (_ValueClient.ContainsKey(m_BridgeClient))
					{
						streamWriter = _ValueClient[m_BridgeClient];
					}
					else
					{
						MapRepository(m_BridgeClient, result.ParentScen);
						streamWriter = File.AppendText(m_BridgeClient);
						streamWriter.AutoFlush = true;
						_ValueClient.Add(m_BridgeClient, streamWriter);
					}
					string eventString = GetEventString(result, dictionary, ref LastPrintedTimeString, NewUnitCache);
					if (!string.IsNullOrEmpty(eventString))
					{
						streamWriter.WriteLine(eventString);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		_InvocationClient = false;
	}

	private void MapRepository(string string_0, Scenario scenario_0)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(string_0);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("FileType=text/acmi/tacview").Append("\r\n");
			stringBuilder.Append("FileVersion=2.1").Append("\r\n");
			stringBuilder.Append("0,ReferenceTime=" + scenario_0.ZeroHour.ToString("yyyy-MM-ddThh:mm:ss")).Append("Z").Append("\r\n");
			File.WriteAllText(string_0, stringBuilder.ToString());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string SortRepository(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return string_0;
		}
		if (string_0.Contains(","))
		{
			string_0 = string_0.Replace(",", "\\,");
		}
		if (string_0.Contains("="))
		{
			string_0 = string_0.Replace("=", "\\=");
		}
		return string_0;
	}

	public virtual void StopCleanUpAndReset()
	{
		if (!Information.IsNothing(tokenizerClient))
		{
			tokenizerClient.Abort();
			tokenizerClient = null;
		}
		m_ClassClient = new ConcurrentQueue<IEventExporter.EventExportNotification>();
		m_RequestClient.Clear();
		foreach (StreamWriter value in _ValueClient.Values)
		{
			if (!Information.IsNothing(value))
			{
				value.Flush();
				value.Close();
				value.Dispose();
			}
		}
		_ValueClient.Clear();
		_InvocationClient = false;
	}

	public void Shutdown()
	{
	}

	public virtual void SetScenario(Scenario scenario_0)
	{
		int num = scenario_0.ActiveUnits_List.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (!scenario_0.ActiveUnits_List.ElementAt(i).IsGroup)
			{
				scenario_0.ActiveUnits_List.ElementAt(i).Kinematics.ExportLocationEvent(bool_0: true);
			}
		}
	}

	public void SetOutputRate(IEventExporter.ExportedEventType exportedEventType_0, IEventExporter.EventExportOutputRate eventExportOutputRate_0)
	{
	}

	public bool ShouldOutputNow(IEventExporter.ExportedEventType exportedEventType_0, Scenario scenario_0)
	{
		return true;
	}
}
