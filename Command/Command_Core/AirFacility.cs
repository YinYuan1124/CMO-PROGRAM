using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class AirFacility : PlatformComponent
{
	public enum _AirFacType : short
	{
		None = 1001,
		Runway = 2001,
		RunwayWithArrest = 2002,
		RunwayGrade_Taxiway = 2003,
		RunwayAccessPoint = 2004,
		Catapult = 2005,
		SkiJump = 2006,
		CarrierArrestingGear = 2007,
		Pad = 3001,
		PadWithHaulDown = 3002,
		Hangar = 4001,
		OpenParking = 4002,
		Elevator = 4003,
		const_13 = 5001
	}

	public enum _ReasonForAircraftRemoval : byte
	{
		TransferToAnotherAirFac = 1,
		TakeoffOrDestruction
	}

	private _AirFacType _ModelObserver;

	private GlobalVariables.AircraftSizeClass advisorObserver;

	public int Capacity;

	private TDictionary<string, Aircraft> _CustomerObserver;

	public GlobalVariables.RunwayLengthClass RunwayLength;

	[ThreadStatic]
	private static StringBuilder _SerializerObserver;

	public TDictionary<string, Aircraft> HostedAircraft => _CustomerObserver;

	public string TypeString => PrintReader(Name);

	public string RunwayString
	{
		get
		{
			string result = "";
			switch (RunwayLength)
			{
			case GlobalVariables.RunwayLengthClass.VTOL:
				result = "Veritcal Take-Off and Landing";
				break;
			case GlobalVariables.RunwayLengthClass.CatapultLaunched:
				result = "Catapult launched";
				break;
			case GlobalVariables.RunwayLengthClass.ManualLaunch:
				result = "Manual Launch";
				break;
			case GlobalVariables.RunwayLengthClass.Between_451_900m:
				result = "450-900m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_1_450m:
				result = "Short Take-Off and Landing up to 450m";
				break;
			case GlobalVariables.RunwayLengthClass.Between_1_250m:
				result = "Short Take-Off and Landing up to 250m";
				break;
			case GlobalVariables.RunwayLengthClass.Between_2001_2600m:
				result = "2000-2600m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_1401_2000m:
				result = "1400-2000m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_901_1400m:
				result = "900-1400m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_4000_5600m:
				result = "4000-5600m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_3201_4000m:
				result = "3200-4000m long";
				break;
			case GlobalVariables.RunwayLengthClass.Between_2601_3200m:
				result = "2600-3200m long";
				break;
			}
			return result;
		}
	}

	public override _ComponentStatus Status => base.Status;

	public GlobalVariables.AircraftSizeClass EffectiveRunwaySize
	{
		get
		{
			if (Information.IsNothing(base.ParentPlatform))
			{
				return GlobalVariables.AircraftSizeClass.None;
			}
			double num = 100f - base.ParentPlatform.Damage.DamagePercent;
			if (num <= 75.0)
			{
				if (num <= 50.0)
				{
					if (num <= 25.0)
					{
						if (num <= 10.0)
						{
							return GlobalVariables.AircraftSizeClass.None;
						}
						return (GlobalVariables.AircraftSizeClass)Math.Max((int)(advisorObserver - 3), 0);
					}
					return (GlobalVariables.AircraftSizeClass)Math.Max((int)(advisorObserver - 2), 0);
				}
				return (GlobalVariables.AircraftSizeClass)Math.Max((int)(advisorObserver - 1), 0);
			}
			return advisorObserver;
		}
	}

	public _AirFacType AirFacType => _ModelObserver;

	public GlobalVariables.AircraftSizeClass MaxAircraftSize => advisorObserver;

	public bool IsOpenAirFacility
	{
		get
		{
			switch (AirFacType)
			{
			default:
				return false;
			case _AirFacType.Runway:
			case _AirFacType.RunwayWithArrest:
			case _AirFacType.RunwayGrade_Taxiway:
			case _AirFacType.RunwayAccessPoint:
			case _AirFacType.SkiJump:
			case _AirFacType.Pad:
			case _AirFacType.PadWithHaulDown:
			case _AirFacType.OpenParking:
				return true;
			}
		}
	}

	public int ParkingSpace_Total
	{
		get
		{
			int num = 0;
			switch (advisorObserver)
			{
			case GlobalVariables.AircraftSizeClass.Small:
				num = Capacity;
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class2:
				num = Math.Max((int)Math.Round((double)Capacity * 0.5), (int)advisorObserver);
				break;
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
			case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
				num = Math.Max((int)Math.Round((double)Capacity * 0.25), (int)advisorObserver);
				break;
			case GlobalVariables.AircraftSizeClass.VLarge:
				num = 4 * Capacity;
				break;
			case GlobalVariables.AircraftSizeClass.Large:
				num = 3 * Capacity;
				break;
			case GlobalVariables.AircraftSizeClass.Medium:
				num = 2 * Capacity;
				break;
			}
			if ((int)advisorObserver < 10)
			{
				return num;
			}
			return num * 10;
		}
	}

	public int ParkingSpace_Free
	{
		get
		{
			try
			{
				int num = ParkingSpace_Total;
				foreach (Aircraft value in HostedAircraft.Values)
				{
					num -= (int)value.Size;
				}
				return num;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100656", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return 0;
		}
	}

	public string ToXML(HashSet<string> hashSet_0)
	{
		try
		{
			if (_SerializerObserver == null)
			{
				_SerializerObserver = new StringBuilder();
			}
			else
			{
				_SerializerObserver.Clear();
			}
			_SerializerObserver.Append("<AirFacility>");
			_SerializerObserver.Append("<ID>").Append(ObjectID).Append("</ID>");
			_SerializerObserver.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (DBID == 0)
			{
				_SerializerObserver.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
				_SerializerObserver.Append("<Type>").Append((int)_ModelObserver).Append("</Type>");
				_SerializerObserver.Append("<Size>").Append((int)advisorObserver).Append("</Size>");
				_SerializerObserver.Append("<Capacity>").Append(Capacity).Append("</Capacity>");
			}
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					_SerializerObserver.Append("</AirFacility>");
					return _SerializerObserver.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			if (_Status != 0)
			{
				StringBuilder stringBuilder = _SerializerObserver.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != 0)
			{
				_SerializerObserver.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			_SerializerObserver.Append("</AirFacility>");
			return _SerializerObserver.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100652", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static AirFacility StartReader(XmlNode xmlNode_0)
	{
		try
		{
			int num = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "Type").InnerText);
			int int_ = Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "Capacity").InnerText);
			GlobalVariables.RunwayLengthClass runwayLengthClass_ = (GlobalVariables.RunwayLengthClass)0;
			GlobalVariables.AircraftSizeClass int_2 = GlobalVariables.AircraftSizeClass.None;
			switch (Conversions.ToInteger(Misc.StartRequest(xmlNode_0.ChildNodes, "Size").InnerText))
			{
			case 1:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.VTOL;
				int_2 = GlobalVariables.AircraftSizeClass.Small;
				break;
			case 2:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.VTOL;
				int_2 = GlobalVariables.AircraftSizeClass.Medium;
				break;
			case 3:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.VTOL;
				int_2 = GlobalVariables.AircraftSizeClass.Large;
				break;
			case 4:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.VTOL;
				int_2 = GlobalVariables.AircraftSizeClass.VLarge;
				break;
			case 5:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.Between_1_450m;
				int_2 = GlobalVariables.AircraftSizeClass.Small;
				break;
			case 6:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.Between_451_900m;
				int_2 = GlobalVariables.AircraftSizeClass.Small;
				break;
			case 7:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.Between_901_1400m;
				int_2 = GlobalVariables.AircraftSizeClass.Medium;
				break;
			case 8:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.Between_2001_2600m;
				int_2 = GlobalVariables.AircraftSizeClass.Large;
				break;
			case 9:
				runwayLengthClass_ = GlobalVariables.RunwayLengthClass.Between_2601_3200m;
				int_2 = GlobalVariables.AircraftSizeClass.VLarge;
				break;
			}
			return new AirFacility(null, Misc.StartRequest(xmlNode_0.ChildNodes, "Name").InnerText, (_AirFacType)num, (int)int_2, int_, runwayLengthClass_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200033", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public static AirFacility FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0)
	{
		try
		{
			XmlNode xmlNode = Misc.StartRequest(xmlNode_0.ChildNodes, "DBID");
			string text = Misc.StartRequest(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.CreateRequest(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (AirFacility)concurrentDictionary_0[text];
			}
			AirFacility airFacility;
			if (Information.IsNothing(xmlNode))
			{
				airFacility = StartReader(xmlNode_0);
			}
			else if (Operators.CompareString(xmlNode.InnerText, "0", TextCompare: false) == 0)
			{
				airFacility = StartReader(xmlNode_0);
				if (Information.IsNothing(airFacility))
				{
					return null;
				}
			}
			else if (Operators.CompareString(xmlNode.InnerText, "-1", TextCompare: false) == 0)
			{
				airFacility = AddUAV_Class1_Hanger(null);
			}
			else
			{
				int int_ = Conversions.ToInteger(xmlNode.InnerText);
				SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
				airFacility = DBFunctions.GetAirFacility(int_, ref sqliteConnection_);
			}
			if (concurrentDictionary_0.ContainsKey(text))
			{
				return (AirFacility)concurrentDictionary_0[text];
			}
			airFacility.ObjectID_Set(text);
			concurrentDictionary_0.TryAdd(airFacility.ObjectID, airFacility);
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode2 = (XmlNode)enumerator.Current;
					string name = xmlNode2.Name;
					if (Operators.CompareString(name, "Status", TextCompare: false) == 0)
					{
						switch (xmlNode2.InnerText)
						{
						default:
							airFacility._Status = (_ComponentStatus)Conversions.ToByte(xmlNode2.InnerText);
							break;
						case "Operational":
							airFacility._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							airFacility._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							airFacility._Status = _ComponentStatus.Damaged;
							break;
						}
					}
					else if (Operators.CompareString(name, "DamageSeverity", TextCompare: false) == 0)
					{
						airFacility.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode2.InnerText);
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
			return airFacility;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100653", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public AirFacility(ActiveUnit activeUnit_0, string string_0, _AirFacType _AirFacType_0, int int_0, int int_1, GlobalVariables.RunwayLengthClass runwayLengthClass_0)
		: base(activeUnit_0)
	{
		Name = string_0;
		_ModelObserver = _AirFacType_0;
		advisorObserver = (GlobalVariables.AircraftSizeClass)int_0;
		RunwayLength = runwayLengthClass_0;
		_CustomerObserver = new TDictionary<string, Aircraft>();
		Capacity = int_1;
	}

	internal bool AssetReader()
	{
		return _CustomerObserver.Count > 0;
	}

	public override void Destroy(Side side_0, bool bool_0, bool bool_1)
	{
		try
		{
			if (HostedAircraft.Skip(0).Count() > 0)
			{
				foreach (Aircraft value in HostedAircraft.Values)
				{
					base.ParentPlatform.ParentScen.DestroyThisUnit(value, "Air facility this aircraft was landed on was destroyed", "Host Destruction");
				}
			}
			base.Destroy(side_0, bool_0, bool_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100654", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HandleDamageToHostedAircraft(_DamageSeverityFactor _DamageSeverityFactor_0, float float_0)
	{
		if (HostedAircraft.Skip(0).Count() <= 0 || (!IsOpenAirFacility && float_0 == 0f))
		{
			return;
		}
		foreach (Aircraft value in HostedAircraft.Values)
		{
			if (IsOpenAirFacility || float_0 >= 1f || GameGeneral.LockRandom_0.NextDouble() <= (double)float_0)
			{
				string text = "";
				if (Operators.CompareString(value.Name, value.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + value.UnitClass + ")";
				}
				if (base.ParentPlatform != null)
				{
					base.ParentPlatform.AddMessage(value.Name + text + "被托管在" + Name + "并且已经被破坏了！", value.Name + " 被摧毁！", LoggedMessage.MessageType.UnitLost, 2, bool_0: false, new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
					base.ParentPlatform.ParentScen.DestroyThisUnit(value, value.Name + text + "被托管在" + Name + "并且已经被破坏了！", "Host Destruction");
				}
			}
		}
	}

	private string PrintReader(string string_0)
	{
		int num = Strings.InStr(string_0, "(");
		if (num == 0)
		{
			return string_0;
		}
		return Strings.Trim(Strings.Left(string_0, num - 1));
	}

	internal bool DefineReader()
	{
		_AirFacType airFacType = AirFacType;
		if ((uint)(airFacType - 2001) > 2u && (uint)(airFacType - 2005) > 2u && (uint)(airFacType - 3001) > 1u)
		{
			return false;
		}
		return true;
	}

	internal bool PublishReader()
	{
		if ((uint)(AirFacType - 3001) <= 1u)
		{
			return true;
		}
		return false;
	}

	internal bool AwakeReader()
	{
		return AirFacType == _AirFacType.Catapult;
	}

	internal bool QueryReader()
	{
		if ((uint)(AirFacType - 4001) <= 1u)
		{
			return true;
		}
		return false;
	}

	internal bool ResetReader()
	{
		_AirFacType airFacType = AirFacType;
		if (1 == 0)
		{
		}
		bool result = airFacType switch
		{
			_AirFacType.Elevator => true, 
			_AirFacType.RunwayAccessPoint => true, 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public AirOpsAttemptResult CanHostThisAircraft_BySize(Aircraft aircraft_0)
	{
		try
		{
			if (Information.IsNothing(base.ParentPlatform))
			{
				return AirOpsAttemptResult.Failure_other;
			}
			if ((aircraft_0.Size == GlobalVariables.AircraftSizeClass.UAS_Class1_Micro) | (aircraft_0.Size == GlobalVariables.AircraftSizeClass.UAS_Class1_Mini) | (aircraft_0.Size == GlobalVariables.AircraftSizeClass.UAS_Class1_Small))
			{
				AddUAV_Class1_Hanger(base.ParentPlatform);
				return AirOpsAttemptResult.Success;
			}
			if ((int)(base.ParentPlatform.UnitType - 2) <= 1 && (int)aircraft_0.Size > (int)advisorObserver)
			{
				return AirOpsAttemptResult.Unable_to_fit_in_hangar_space;
			}
			if ((int)aircraft_0.Size < 10 && AirFacType == _AirFacType.const_13 && HostedAircraft.Count == 0)
			{
				return AirOpsAttemptResult.Success;
			}
			int num = ParkingSpace_Free;
			if (HostedAircraft.ContainsKey(aircraft_0.ObjectID))
			{
				num += (int)aircraft_0.Size;
			}
			if (num < (int)aircraft_0.Size)
			{
				return AirOpsAttemptResult.Not_enough_space;
			}
			return AirOpsAttemptResult.Success;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100657", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return AirOpsAttemptResult.Failure_Program;
		}
	}

	public static AirFacility AddUAV_Class1_Hanger(ActiveUnit activeUnit_0)
	{
		try
		{
			if (activeUnit_0 != null && activeUnit_0.parserVal)
			{
				return null;
			}
			AirFacility airFacility = new AirFacility(activeUnit_0, "UAV Storage (UAV [NATO Class I])", _AirFacType.Hangar, 3, 1000, GlobalVariables.RunwayLengthClass.CatapultLaunched);
			airFacility.DBID = -1;
			if (activeUnit_0 == null)
			{
				return airFacility;
			}
			if (airFacility != null)
			{
				activeUnit_0.AddAirFacility(airFacility);
				activeUnit_0.parserVal = true;
			}
			return airFacility;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100745.1", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}
}
