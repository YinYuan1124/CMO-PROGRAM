using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Loadout : ScenarioObject
{
	public delegate void LoadoutWeaponRecordAddedEventHandler(string LoadoutObjectID, string WeaponRecObjectID);

	public delegate void LoadoutWeaponRecordRemovedEventHandler(string LoadoutObjectID, string WeaponRecObjectID);

	public enum LoadoutRole
	{
		None = 1001,
		Intercept_BVR = 2001,
		Intercept_WVR = 2002,
		AirSuperiority_BVR = 2003,
		AirSuperiority_WVR = 2004,
		PointDefence_BVR = 2005,
		PointDefence_WVR = 2006,
		GunsOnly = 2007,
		AntiSatellite_Intercept = 2101,
		AirborneLaser = 2102,
		LandNaval_Strike = 3001,
		LandNaval_Standoff = 3002,
		LandNaval_SEAD_ARM = 3003,
		LandNaval_SEAD_TALD = 3004,
		LandNaval_DEAD = 3005,
		LandOnly_Strike = 3101,
		LandOnly_Standoff = 3102,
		LandOnly_SEAD_ARM = 3103,
		LandOnly_SEAD_TALD = 3104,
		LandOnly_DEAD = 3105,
		NavalOnly_Strike = 3201,
		NavalOnly_Standoff = 3202,
		NavalOnly_SEAD_ARM = 3203,
		NavalOnly_SEAD_TALD = 3204,
		NavalOnly_DEAD = 3205,
		BAI_CAS = 3401,
		Buddy_Illumination = 3501,
		OECM = 4001,
		AEW = 4002,
		CommandPost = 4003,
		ChaffLaying = 4004,
		SearchAndRescue = 4101,
		CombatSearchAndRescue = 4102,
		MineSweeping = 4201,
		MineRecon = 4202,
		NavalMineLaying = 4301,
		ASW_Patrol = 6001,
		ASW_Attack = 6002,
		Forward_Observer = 7001,
		Area_Surveillance = 7002,
		Armed_Recon = 7003,
		Unarmed_Recon = 7004,
		Maritime_Surveillance = 7005,
		Paratroopers = 7101,
		Troop_Transport = 7102,
		Cargo = 7201,
		AirRefueling = 8001,
		Training = 8101,
		TargetTow = 8102,
		TargetDrone = 8103,
		Ferry = 9001,
		Unavailable = 9002,
		Reserve = 9003,
		ArmedFerry = 9004
	}

	public enum _LoadoutWeather : short
	{
		None = 1001,
		AllWeather = 2001,
		LimitedAllWeather = 2002,
		ClearWeather = 2003
	}

	public enum _LoadoutDayNight : short
	{
		None = 1001,
		DayNight = 2001,
		NightOnly = 2002,
		DayOnly = 2003
	}

	private struct ConsumerItem
	{
		public int facadeItem;

		public int Quantity;
	}

	public int DBID;

	public string Comments;

	public int ROF;

	public int MaxCapacity;

	public int ReadyTime;

	public int ReadyTime_Sustained;

	public WeaponRec[] Weapons;

	public LoadoutRole Role;

	public _LoadoutDayNight TimeOfDay;

	public _LoadoutWeather Weather;

	public float WeightDragModifier;

	public int CombatRadius;

	public short TimeOnStation_Minutes;

	public int PayloadWeight;

	public int PayloadWeightDroppable;

	public int PayloadWeight_TakeOff;

	public int PayloadWeightDroppable_TakeOff;

	public bool NoOptionalWeapons;

	private AircraftMissionProfile _PrototypeDic;

	public bool RequiresBuddyIllumination;

	public bool QuickTurnaround;

	public int QuickTurnaround_ReadyTime;

	public int QuickTurnaround_MaxSorties;

	public int QuickTurnaround_AdditionalTimePenalty;

	public int QuickTurnaround_AirborneTime;

	public _LoadoutDayNight QuickTurnaround_TimeofDay;

	public Doctrine._WeaponState WinchesterShotgun;

	public bool Hypothetical;

	public int Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public bool Cargo_ParadropCapable;

	[ThreadStatic]
	private static StringBuilder comparatorDic;

	[CompilerGenerated]
	private static LoadoutWeaponRecordAddedEventHandler _ItemDic;

	[CompilerGenerated]
	private static LoadoutWeaponRecordRemovedEventHandler _SetterDic;

	public bool IsAAW
	{
		get
		{
			LoadoutRole role = Role;
			if ((uint)(role - 2001) > 5u && role != LoadoutRole.AntiSatellite_Intercept)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsASW
	{
		get
		{
			if ((uint)(Role - 6001) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsSupportOrPatrol
	{
		get
		{
			switch (Role)
			{
			default:
				return false;
			case LoadoutRole.OECM:
			case LoadoutRole.AEW:
			case LoadoutRole.CommandPost:
			case LoadoutRole.SearchAndRescue:
			case LoadoutRole.NavalMineLaying:
			case LoadoutRole.Forward_Observer:
			case LoadoutRole.Area_Surveillance:
			case LoadoutRole.Unarmed_Recon:
			case LoadoutRole.AirRefueling:
				return true;
			}
		}
	}

	public bool IsSurveillanceOrRecon
	{
		get
		{
			LoadoutRole role = Role;
			if ((uint)(role - 7001) > 1u && role != LoadoutRole.Unarmed_Recon)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsStrike
	{
		get
		{
			switch (Role)
			{
			default:
				return false;
			case LoadoutRole.LandNaval_Strike:
			case LoadoutRole.LandNaval_Standoff:
			case LoadoutRole.LandNaval_SEAD_ARM:
			case LoadoutRole.LandNaval_SEAD_TALD:
			case LoadoutRole.LandNaval_DEAD:
			case LoadoutRole.LandOnly_Strike:
			case LoadoutRole.LandOnly_Standoff:
			case LoadoutRole.LandOnly_SEAD_ARM:
			case LoadoutRole.LandOnly_SEAD_TALD:
			case LoadoutRole.LandOnly_DEAD:
			case LoadoutRole.NavalOnly_Strike:
			case LoadoutRole.NavalOnly_Standoff:
			case LoadoutRole.NavalOnly_SEAD_ARM:
			case LoadoutRole.NavalOnly_SEAD_TALD:
			case LoadoutRole.NavalOnly_DEAD:
			case LoadoutRole.BAI_CAS:
			case LoadoutRole.NavalMineLaying:
			case LoadoutRole.ASW_Attack:
				return true;
			}
		}
	}

	public int CurrentCapacity
	{
		get
		{
			try
			{
				WeaponRec[] weapons = Weapons;
				int num = 0;
				WeaponRec[] array = weapons;
				WeaponRec[] array2 = array;
				foreach (WeaponRec weaponRec in array2)
				{
					num += (int)Math.Round(Math.Round((double)weaponRec.CurrentLoad / (double)weaponRec.Multiple, 0));
				}
				return num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101010", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0;
			}
		}
	}

	public static event LoadoutWeaponRecordAddedEventHandler LoadoutWeaponRecordAdded
	{
		[CompilerGenerated]
		add
		{
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler = _ItemDic;
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler2;
			do
			{
				loadoutWeaponRecordAddedEventHandler2 = loadoutWeaponRecordAddedEventHandler;
				LoadoutWeaponRecordAddedEventHandler value2 = (LoadoutWeaponRecordAddedEventHandler)Delegate.Combine(loadoutWeaponRecordAddedEventHandler2, value);
				loadoutWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref _ItemDic, value2, loadoutWeaponRecordAddedEventHandler2);
			}
			while ((object)loadoutWeaponRecordAddedEventHandler != loadoutWeaponRecordAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler = _ItemDic;
			LoadoutWeaponRecordAddedEventHandler loadoutWeaponRecordAddedEventHandler2;
			do
			{
				loadoutWeaponRecordAddedEventHandler2 = loadoutWeaponRecordAddedEventHandler;
				LoadoutWeaponRecordAddedEventHandler value2 = (LoadoutWeaponRecordAddedEventHandler)Delegate.Remove(loadoutWeaponRecordAddedEventHandler2, value);
				loadoutWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref _ItemDic, value2, loadoutWeaponRecordAddedEventHandler2);
			}
			while ((object)loadoutWeaponRecordAddedEventHandler != loadoutWeaponRecordAddedEventHandler2);
		}
	}

	public static event LoadoutWeaponRecordRemovedEventHandler LoadoutWeaponRecordRemoved
	{
		[CompilerGenerated]
		add
		{
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler = _SetterDic;
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler2;
			do
			{
				loadoutWeaponRecordRemovedEventHandler2 = loadoutWeaponRecordRemovedEventHandler;
				LoadoutWeaponRecordRemovedEventHandler value2 = (LoadoutWeaponRecordRemovedEventHandler)Delegate.Combine(loadoutWeaponRecordRemovedEventHandler2, value);
				loadoutWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref _SetterDic, value2, loadoutWeaponRecordRemovedEventHandler2);
			}
			while ((object)loadoutWeaponRecordRemovedEventHandler != loadoutWeaponRecordRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler = _SetterDic;
			LoadoutWeaponRecordRemovedEventHandler loadoutWeaponRecordRemovedEventHandler2;
			do
			{
				loadoutWeaponRecordRemovedEventHandler2 = loadoutWeaponRecordRemovedEventHandler;
				LoadoutWeaponRecordRemovedEventHandler value2 = (LoadoutWeaponRecordRemovedEventHandler)Delegate.Remove(loadoutWeaponRecordRemovedEventHandler2, value);
				loadoutWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref _SetterDic, value2, loadoutWeaponRecordRemovedEventHandler2);
			}
			while ((object)loadoutWeaponRecordRemovedEventHandler != loadoutWeaponRecordRemovedEventHandler2);
		}
	}

	public string ToXML(ref HashSet<string> hashSet_0, Scenario scenario_0)
	{
		try
		{
			if (comparatorDic == null)
			{
				comparatorDic = new StringBuilder();
			}
			else
			{
				comparatorDic.Clear();
			}
			comparatorDic.Append("<Loadout>");
			comparatorDic.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					comparatorDic.Append("</Loadout>");
					return comparatorDic.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			comparatorDic.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (!string.IsNullOrEmpty(Name))
			{
				comparatorDic.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			}
			comparatorDic.Append("<ROF>").Append(ROF).Append("</ROF>");
			if (MaxCapacity != 0)
			{
				comparatorDic.Append("<MC>").Append(MaxCapacity).Append("</MC>");
			}
			if (ReadyTime != 0)
			{
				comparatorDic.Append("<RT>").Append(ReadyTime).Append("</RT>");
			}
			if (NoOptionalWeapons)
			{
				comparatorDic.Append("<NOW>True</NOW>");
			}
			comparatorDic.Append("<Weaps>");
			WeaponRec[] weapons = Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				comparatorDic.Append(weaponRec.ToXML(hashSet_0, scenario_0));
			}
			comparatorDic.Append("</Weaps>");
			comparatorDic.Append("<Role>").Append((int)Role).Append("</Role>");
			if (PayloadWeight != 0)
			{
				comparatorDic.Append("<PayloadWeight>").Append(PayloadWeight).Append("</PayloadWeight>");
			}
			if (PayloadWeightDroppable != 0)
			{
				comparatorDic.Append("<PayloadWeightDroppable>").Append(PayloadWeightDroppable).Append("</PayloadWeightDroppable>");
			}
			if (PayloadWeight_TakeOff != 0)
			{
				comparatorDic.Append("<PayloadWeight_TakeOff>").Append(PayloadWeight_TakeOff).Append("</PayloadWeight_TakeOff>");
			}
			if (PayloadWeightDroppable_TakeOff != 0)
			{
				comparatorDic.Append("<PayloadWeightDroppable_TakeOff>").Append(PayloadWeightDroppable_TakeOff).Append("</PayloadWeightDroppable_TakeOff>");
			}
			if (WeightDragModifier != 0f)
			{
				comparatorDic.Append("<WeightDragModifier>").Append(XmlConvert.ToString(WeightDragModifier)).Append("</WeightDragModifier>");
			}
			if (CombatRadius != 0)
			{
				comparatorDic.Append("<CombatRadius>").Append(CombatRadius).Append("</CombatRadius>");
			}
			if (TimeOnStation_Minutes != 0)
			{
				comparatorDic.Append("<TimeOnStation_Minutes>").Append(TimeOnStation_Minutes).Append("</TimeOnStation_Minutes>");
			}
			if (QuickTurnaround)
			{
				comparatorDic.Append("<QT>True</QT>");
			}
			if (QuickTurnaround_ReadyTime != 0)
			{
				comparatorDic.Append("<QT_ReadyTime>").Append(QuickTurnaround_ReadyTime).Append("</QT_ReadyTime>");
			}
			if (QuickTurnaround_AirborneTime != 0)
			{
				comparatorDic.Append("<QT_AirborneTime>").Append(QuickTurnaround_AirborneTime).Append("</QT_AirborneTime>");
			}
			if (QuickTurnaround_MaxSorties != 0)
			{
				comparatorDic.Append("<QT_MaxSorties>").Append(QuickTurnaround_MaxSorties).Append("</QT_MaxSorties>");
			}
			if (QuickTurnaround_AdditionalTimePenalty != 0)
			{
				comparatorDic.Append("<QT_AdditionalTimePenalty>").Append(QuickTurnaround_AdditionalTimePenalty).Append("</QT_AdditionalTimePenalty>");
			}
			comparatorDic.Append("<QT_TimeofDay>").Append((int)QuickTurnaround_TimeofDay).Append("</QT_TimeofDay>");
			comparatorDic.Append("<WinchesterShotgun>").Append((int)WinchesterShotgun).Append("</WinchesterShotgun>");
			comparatorDic.Append("</Loadout>");
			return comparatorDic.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101007", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Loadout()
	{
		Weapons = new WeaponRec[0];
		NoOptionalWeapons = false;
	}

	public static Loadout FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Aircraft aircraft_0, ref Scenario scenario_0)
	{
		try
		{
			Loadout loadout_ = new Loadout();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "QuickTurnaround_ReadyTime":
					case "QT_ReadyTime":
						loadout_.QuickTurnaround_ReadyTime = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Name":
						loadout_.Name = xmlNode.InnerText;
						break;
					case "PayloadWeight":
						loadout_.PayloadWeight = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							loadout_.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(loadout_.ObjectID, loadout_);
							break;
						}
						return (Loadout)concurrentDictionary_0[xmlNode.InnerText];
					case "PayloadWeightDroppable":
						loadout_.PayloadWeightDroppable = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "PayloadWeightDroppable_TakeOff":
						loadout_.PayloadWeightDroppable_TakeOff = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ROF":
						loadout_.ROF = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "QuickTurnaround_AdditionalTimePenalty":
					case "QT_AdditionalTimePenalty":
						loadout_.QuickTurnaround_AdditionalTimePenalty = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "CombatRadius":
						loadout_.CombatRadius = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "PayloadWeight_TakeOff":
						loadout_.PayloadWeight_TakeOff = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "DBID":
						loadout_.DBID = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "QuickTurnaround_AirborneTime":
					case "QT_AirborneTime":
						loadout_.QuickTurnaround_AirborneTime = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "QuickTurnaround_MaxSorties":
					case "QT_MaxSorties":
						loadout_.QuickTurnaround_MaxSorties = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "RT":
					case "ReadyTime":
						loadout_.ReadyTime = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Role":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							loadout_.Role = (LoadoutRole)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							loadout_.Role = (LoadoutRole)Enum.Parse(typeof(LoadoutRole), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "WeightDragModifier":
						loadout_.WeightDragModifier = XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", "."));
						break;
					case "WinchesterShotgun":
						loadout_.WinchesterShotgun = (Doctrine._WeaponState)Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "NOW":
						loadout_.NoOptionalWeapons = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "Weapons":
					case "Weaps":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
								WeaponRec weaponRec_ = WeaponRec.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref scenario_0);
								loadout_.AddWeaponRec(weaponRec_);
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "QT":
					case "QuickTurnaround":
						loadout_.QuickTurnaround = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "QuickTurnaround_TimeofDay":
					case "QT_TimeofDay":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							loadout_.QuickTurnaround_TimeofDay = (_LoadoutDayNight)Conversions.ToShort(xmlNode.InnerText);
						}
						else
						{
							loadout_.QuickTurnaround_TimeofDay = (_LoadoutDayNight)Enum.Parse(typeof(_LoadoutDayNight), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "TimeOnStation_Minutes":
						loadout_.TimeOnStation_Minutes = Conversions.ToShort(xmlNode.InnerText);
						break;
					case "Sensors":
					case "Sens":
					{
						if (!xmlNode.HasChildNodes)
						{
							break;
						}
						WeaponRec[] weapons = DBFunctions.GetLoadout(ref scenario_0, loadout_.DBID, loadout_.NoOptionalWeapons, bool_1: false).Weapons;
						WeaponRec[] array = weapons;
						foreach (WeaponRec weaponRec in array)
						{
							if (weaponRec.GetReferenceWeapon(scenario_0).Type == Weapon._WeaponType.SensorPod)
							{
								loadout_.AddWeaponRec(weaponRec);
							}
						}
						break;
					}
					case "MC":
					case "MaxCapacity":
						loadout_.MaxCapacity = Conversions.ToInteger(xmlNode.InnerText);
						break;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			if (loadout_.PayloadWeight == 0)
			{
				DBFunctions.GetLoadoutPayloadWeight(ref scenario_0, ref loadout_);
			}
			if (loadout_.PayloadWeight > 0 && loadout_.PayloadWeight_TakeOff == 0)
			{
				DBFunctions.GetLoadoutPayloadTakeOffWeight_Static(ref scenario_0, ref loadout_);
			}
			if (loadout_.WinchesterShotgun == Doctrine._WeaponState.LoadoutSetting)
			{
				loadout_.WinchesterShotgun = Doctrine._WeaponState.Winchester;
			}
			Loadout loadout = DBFunctions.GetLoadout(ref scenario_0, loadout_.DBID, bool_0: false, bool_1: false);
			loadout_.Cargo_Type = loadout.Cargo_Type;
			loadout_.Cargo_Area = loadout.Cargo_Area;
			loadout_.Cargo_Crew = loadout.Cargo_Crew;
			loadout_.Cargo_Mass = loadout.Cargo_Mass;
			loadout_.Cargo_ParadropCapable = loadout.Cargo_ParadropCapable;
			return loadout_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101008", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal List<Sensor> NewClass(Scenario scenario_0)
	{
		List<Sensor> list = new List<Sensor>();
		try
		{
			int num = Weapons.Length;
			if (num <= 0)
			{
				return list;
			}
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				WeaponRec weaponRec = Weapons[i];
				if (weaponRec.CurrentLoad <= 0)
				{
					continue;
				}
				Weapon referenceWeapon = weaponRec.GetReferenceWeapon(scenario_0);
				if (referenceWeapon.Type == Weapon._WeaponType.SensorPod)
				{
					Sensor[] array = referenceWeapon.Sensors_ReadOnly();
					Sensor[] array2 = array;
					foreach (Sensor item in array2)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101009", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return list;
		}
	}

	[SpecialName]
	public AircraftMissionProfile GetMissionProfile(Scenario scenario_0)
	{
		if (Information.IsNothing(_PrototypeDic))
		{
			int dBID = DBID;
			SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
			_PrototypeDic = DBFunctions.GetLoadoutMissionProfile(dBID, ref sqliteConnection_, scenario_0);
		}
		return _PrototypeDic;
	}

	public Loadout(int int_0, string string_0, int int_1, int int_2, int int_3, int int_4, LoadoutRole loadoutRole_0, _LoadoutDayNight _LoadoutDayNight_0, _LoadoutWeather _LoadoutWeather_0, float float_0, int int_5, short short_0, bool bool_0, bool bool_1, bool bool_2, int int_6, int int_7, int int_8, int int_9, _LoadoutDayNight _LoadoutDayNight_1, Doctrine._WeaponState _WeaponState_0)
	{
		Weapons = new WeaponRec[0];
		NoOptionalWeapons = false;
		DBID = int_0;
		Name = string_0;
		ROF = int_1;
		MaxCapacity = int_2;
		ReadyTime = int_3;
		ReadyTime_Sustained = int_4;
		Weapons = new WeaponRec[0];
		Role = loadoutRole_0;
		TimeOfDay = _LoadoutDayNight_0;
		Weather = _LoadoutWeather_0;
		WeightDragModifier = float_0;
		CombatRadius = int_5;
		TimeOnStation_Minutes = short_0;
		RequiresBuddyIllumination = bool_0;
		NoOptionalWeapons = bool_1;
		QuickTurnaround = bool_2;
		QuickTurnaround_ReadyTime = int_6;
		QuickTurnaround_MaxSorties = int_7;
		QuickTurnaround_AdditionalTimePenalty = int_8;
		QuickTurnaround_AirborneTime = int_9;
		QuickTurnaround_TimeofDay = _LoadoutDayNight_1;
		WinchesterShotgun = _WeaponState_0;
	}

	public void AddWeaponRec(WeaponRec weaponRec_0)
	{
		ArrayExtensions.Add(ref Weapons, weaponRec_0);
		_ItemDic?.Invoke(ObjectID, weaponRec_0.ObjectID);
	}

	public void RemoveWeaponRec(WeaponRec weaponRec_0)
	{
		ArrayExtensions.Remove(ref Weapons, weaponRec_0);
		_SetterDic?.Invoke(ObjectID, weaponRec_0.ObjectID);
	}

	public void ClearAllWeapons()
	{
		List<WeaponRec> list = Weapons.ToList();
		ArrayExtensions.Clear(ref Weapons);
		foreach (WeaponRec item in list)
		{
			_SetterDic?.Invoke(ObjectID, item.ObjectID);
		}
	}

	internal string PushClass()
	{
		LoadoutRole role = Role;
		if (1 == 0)
		{
		}
		string result = role switch
		{
			LoadoutRole.AntiSatellite_Intercept => "Anti-Satellite Intercept", 
			LoadoutRole.Intercept_BVR => "Intercept BVR", 
			LoadoutRole.Intercept_WVR => "Intercept WVR", 
			LoadoutRole.AirSuperiority_BVR => "Air Superiority BVR", 
			LoadoutRole.AirSuperiority_WVR => "Air Superiority WVR", 
			LoadoutRole.PointDefence_BVR => "Point Defence BVR", 
			LoadoutRole.PointDefence_WVR => "Point Defence WVR", 
			LoadoutRole.GunsOnly => "Guns Only", 
			LoadoutRole.None => "None", 
			LoadoutRole.LandOnly_Strike => "Land Only Strike", 
			LoadoutRole.LandOnly_Standoff => "Land Only Standoff", 
			LoadoutRole.LandOnly_SEAD_ARM => "Land Only SEAD ARM", 
			LoadoutRole.LandOnly_SEAD_TALD => "Land Only SEAD TALD", 
			LoadoutRole.LandOnly_DEAD => "Land Only DEAD", 
			LoadoutRole.LandNaval_Strike => "Land/Naval Strike", 
			LoadoutRole.LandNaval_Standoff => "Land/Naval Standoff", 
			LoadoutRole.LandNaval_SEAD_ARM => "Land/Naval SEAD ARM", 
			LoadoutRole.LandNaval_SEAD_TALD => "Land/Naval SEAD TALD", 
			LoadoutRole.LandNaval_DEAD => "Land/Naval DEAD", 
			LoadoutRole.AirborneLaser => "机载激光", 
			LoadoutRole.Buddy_Illumination => "支援照射", 
			LoadoutRole.BAI_CAS => "BAI CAS", 
			LoadoutRole.NavalOnly_Strike => "Naval Only Strike", 
			LoadoutRole.NavalOnly_Standoff => "Naval Only Standoff", 
			LoadoutRole.NavalOnly_SEAD_ARM => "Naval Only SEAD ARM", 
			LoadoutRole.NavalOnly_SEAD_TALD => "Naval Only SEAD TALD", 
			LoadoutRole.NavalOnly_DEAD => "Naval Only DEAD", 
			LoadoutRole.CombatSearchAndRescue => "Combat, Search and Rescue", 
			LoadoutRole.SearchAndRescue => "Search and Rescue", 
			LoadoutRole.OECM => "OECM", 
			LoadoutRole.AEW => "AEW", 
			LoadoutRole.CommandPost => "指挥所", 
			LoadoutRole.ChaffLaying => "播撒箔条", 
			LoadoutRole.NavalMineLaying => "Naval Minelaying", 
			LoadoutRole.MineRecon => "雷区侦察", 
			LoadoutRole.MineSweeping => "Minesweeping", 
			LoadoutRole.Forward_Observer => "Forward Observer", 
			LoadoutRole.Area_Surveillance => "Area Surveillance", 
			LoadoutRole.Armed_Recon => "武装侦察", 
			LoadoutRole.Unarmed_Recon => "非武装侦察", 
			LoadoutRole.Maritime_Surveillance => "海上监视", 
			LoadoutRole.ASW_Attack => "ASW Attack", 
			LoadoutRole.ASW_Patrol => "反潜ASW巡逻", 
			LoadoutRole.Cargo => "Cargo", 
			LoadoutRole.Troop_Transport => "部队运输", 
			LoadoutRole.Paratroopers => "Paratroopers", 
			LoadoutRole.Ferry => "Ferry", 
			LoadoutRole.Unavailable => "Unavailable", 
			LoadoutRole.Reserve => "Reserve", 
			LoadoutRole.ArmedFerry => "Armed Ferry", 
			LoadoutRole.Training => "training", 
			LoadoutRole.TargetTow => "拖曳目标", 
			LoadoutRole.TargetDrone => "靶标目标", 
			LoadoutRole.AirRefueling => "Air Refueling", 
			_ => null, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private List<ConsumerItem> InvokeClass(WeaponRec[] weaponRec_0)
	{
		List<ConsumerItem> list = new List<ConsumerItem>();
		int num = weaponRec_0.Count() - 1;
		ConsumerItem consumerItem = default(ConsumerItem);
		for (int i = 0; i <= num; i++)
		{
			if (weaponRec_0[i].CurrentLoad <= 0)
			{
				continue;
			}
			bool flag = false;
			int num2 = list.Count - 1;
			int j;
			for (j = 0; j <= num2; j++)
			{
				consumerItem = list[j];
				if (consumerItem.facadeItem > weaponRec_0[i].int_0)
				{
					break;
				}
				if (consumerItem.facadeItem == weaponRec_0[i].int_0)
				{
					flag = true;
					consumerItem.Quantity += weaponRec_0[i].CurrentLoad;
					list[j] = consumerItem;
					break;
				}
			}
			if (!flag)
			{
				consumerItem.facadeItem = weaponRec_0[i].int_0;
				consumerItem.Quantity = weaponRec_0[i].CurrentLoad;
				list.Insert(j, consumerItem);
			}
		}
		return list;
	}

	internal bool SetupClass(Scenario scenario_0, int int_0, bool bool_0)
	{
		Loadout loadout_ = new Loadout(int_0, "tempLoadout", 1, 1, 1, 1, LoadoutRole.None, _LoadoutDayNight.DayOnly, _LoadoutWeather.None, 0f, 0, 0, bool_0: false, bool_0, bool_2: false, 0, 0, 0, 0, _LoadoutDayNight.DayNight, Doctrine._WeaponState.LoadoutSetting);
		DBFunctions.GetLoadoutWeapons(ref scenario_0, ref loadout_, int_0, bool_0);
		if (Weapons.Count() == 0 && loadout_.Weapons.Count() == 0)
		{
			return false;
		}
		List<ConsumerItem> list = new List<ConsumerItem>();
		List<ConsumerItem> list2 = new List<ConsumerItem>();
		list = InvokeClass(Weapons);
		list2 = InvokeClass(loadout_.Weapons);
		if (list.Count == list2.Count)
		{
			int num = Weapons.Count() - 1;
			for (int i = 0; i <= num; i++)
			{
				if (list[i].facadeItem == list2[i].facadeItem)
				{
					if (list[i].Quantity != list2[i].Quantity)
					{
						return false;
					}
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}
}
