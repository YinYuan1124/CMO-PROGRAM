using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Engine : PlatformComponent
{
	public enum EngineType : short
	{
		None = 1001,
		Turbojet = 2001,
		Turbofan = 2002,
		Turboprop = 2003,
		Piston = 2004,
		Turboshaft = 2005,
		Diesel = 3001,
		Steam = 3002,
		Gas_Turbine = 3003,
		Nuclear = 3004,
		PumpJet = 3005,
		Gasoline = 3006,
		Electric = 4001,
		AIP = 4002,
		Rocket_BoostCoast = 5001,
		Torpedo = 5002,
		WeaponCoast = 5003,
		Rocket_LongBurn = 5004,
		Ramjet = 5005,
		Torpedo_ThermalCombustion = 6001,
		Torpedo_ThermalClosedCycle = 6002,
		Torpedo_Electric = 6003
	}

	public EngineType Type;

	public AltBand[] AltBands;

	public bool Hypothetical;

	internal AltBand m_ConfigClient;

	[ThreadStatic]
	private static StringBuilder _RegistryClient;

	public override void ResetIDs()
	{
		base.ResetIDs();
	}

	public string ToXML(HashSet<string> hashSet_0)
	{
		try
		{
			if (_RegistryClient == null)
			{
				_RegistryClient = new StringBuilder();
			}
			else
			{
				_RegistryClient.Clear();
			}
			_RegistryClient.Append("<Engine>");
			_RegistryClient.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					_RegistryClient.Append("</Engine>");
					return _RegistryClient.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			_RegistryClient.Append("<DBID>").Append(DBID).Append("</DBID>");
			_RegistryClient.Append("<Name>").Append(SecurityElement.Escape(Name.Replace("\u0002", ""))).Append("</Name>");
			if (_Status != 0)
			{
				StringBuilder stringBuilder = _RegistryClient.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != 0)
			{
				_RegistryClient.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			_RegistryClient.Append("</Engine>");
			return _RegistryClient.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100669", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Engine()
		: base(null)
	{
		AltBands = new AltBand[0];
	}

	public static Engine FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Engine engine = new Engine();
			engine.ParentPlatform = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "Status":
						switch (xmlNode.InnerText)
						{
						default:
							engine._Status = (_ComponentStatus)Conversions.ToByte(xmlNode.InnerText);
							break;
						case "Operational":
							engine._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							engine._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							engine._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "Name":
						engine.Name = xmlNode.InnerText;
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							engine.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(engine.ObjectID, engine);
							break;
						}
						return (Engine)concurrentDictionary_0[xmlNode.InnerText];
					case "DBID":
					{
						int int_ = Conversions.ToInteger(xmlNode.InnerText);
						Engine engine2;
						ActiveUnit activeUnit_ = (engine2 = engine).ParentPlatform;
						Engine engine3 = DBFunctions.GetEngine(int_, ref activeUnit_);
						engine2.ParentPlatform = activeUnit_;
						engine3.ObjectID_Set(engine.ObjectID);
						engine3._Status = engine.Status;
						engine3.Name = engine.Name;
						engine = engine3;
						break;
					}
					case "DamageSeverity":
						engine.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode.InnerText);
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
			return engine;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100670", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Engine result = new Engine();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public AltBand GetOptimumAltBandForThisThrottle(ActiveUnit.Throttle throttle_0)
	{
		switch (throttle_0)
		{
		default:
			if (AltBands.Length == 0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return null;
			}
			return AltBands[AltBands.Length - 1];
		case ActiveUnit.Throttle.FullStop:
			return (from theBand in AltBands
				select (theBand) into theBand
				orderby (float)theBand.Speed_Loiter / theBand.Consumption_Full descending
				select theBand).ElementAtOrDefault(0);
		case ActiveUnit.Throttle.Loiter:
			return (from theBand in AltBands
				select (theBand) into theBand
				orderby (float)theBand.Speed_Loiter / theBand.Consumption_Loiter descending
				select theBand).ElementAtOrDefault(0);
		case ActiveUnit.Throttle.Cruise:
			return (from theBand in AltBands
				select (theBand) into theBand
				orderby (float)theBand.Speed_Cruise / theBand.Consumption_Cruise descending
				select theBand).ElementAtOrDefault(0);
		case ActiveUnit.Throttle.Full:
			return (from theBand in AltBands
				select (theBand) into theBand
				orderby (float?)theBand.Speed_Full / theBand.Consumption_Full descending
				select theBand).ElementAtOrDefault(0);
		case ActiveUnit.Throttle.Flank:
			return (from theBand in AltBands
				select (theBand) into theBand
				orderby (float?)theBand.Speed_Flank / theBand.Consumption_Flank descending
				select theBand).ElementAtOrDefault(0);
		}
	}

	public bool CanUseThisFuelType(FuelRec._FuelType _FuelType_0)
	{
		switch (Type)
		{
		case EngineType.Electric:
			return _FuelType_0 == FuelRec._FuelType.Battery;
		case EngineType.Diesel:
			return _FuelType_0 == FuelRec._FuelType.DieselFuel;
		case EngineType.Steam:
			return _FuelType_0 == FuelRec._FuelType.OilFuel;
		case EngineType.Gas_Turbine:
			return _FuelType_0 == FuelRec._FuelType.GasFuel;
		case EngineType.Gasoline:
			return _FuelType_0 == FuelRec._FuelType.Gasoline;
		case EngineType.WeaponCoast:
			return _FuelType_0 == FuelRec._FuelType.WeaponCoast;
		case EngineType.Rocket_BoostCoast:
		case EngineType.Rocket_LongBurn:
			return _FuelType_0 == FuelRec._FuelType.RocketFuel;
		case EngineType.Turbojet:
		case EngineType.Turbofan:
		case EngineType.Turboprop:
		case EngineType.Turboshaft:
		case EngineType.Ramjet:
			return _FuelType_0 == FuelRec._FuelType.AviationFuel;
		case EngineType.AIP:
			return _FuelType_0 == FuelRec._FuelType.AirIndepedent;
		default:
			return false;
		case EngineType.Torpedo_Electric:
			return _FuelType_0 == FuelRec._FuelType.Battery;
		case EngineType.Torpedo:
		case EngineType.Torpedo_ThermalCombustion:
		case EngineType.Torpedo_ThermalClosedCycle:
			return _FuelType_0 == FuelRec._FuelType.RocketFuel;
		}
	}

	public bool CanBeUsedOverland()
	{
		AltBand[] altBands = AltBands;
		AltBand[] array = altBands;
		foreach (AltBand altBand in array)
		{
			if (altBand.MaxAlt == 0f && altBand.MinAlt == 0f)
			{
				return true;
			}
		}
		return false;
	}

	public bool CanBeUsedOnWater()
	{
		return AltBands.Length > 1;
	}

	private bool PostRepository()
	{
		long? speed_Flank = AltBands[0].Speed_Flank;
		return (speed_Flank.HasValue ? new bool?(speed_Flank.GetValueOrDefault() > 0) : null).Value;
	}

	public Engine(ActiveUnit activeUnit_0)
		: base(activeUnit_0)
	{
		AltBands = new AltBand[0];
	}

	public Engine(ActiveUnit activeUnit_0, int int_0, string string_0, EngineType engineType_0)
		: base(activeUnit_0)
	{
		AltBands = new AltBand[0];
		DBID = int_0;
		Name = string_0;
		Type = engineType_0;
	}

	public int MaxSpeed()
	{
		AltBand[] altBands = AltBands;
		int num = 0;
		AltBand[] array = altBands;
		AltBand[] array2 = array;
		foreach (AltBand altBand in array2)
		{
			num = Math.Max(num, altBand.MaxSpeed.Value);
		}
		return num;
	}

	public override void vmethod_0(float float_0)
	{
		if (!base.ParentPlatform.IsAerospaceUnit || Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		float num = ((float_0 < 0.1f) ? 0.05f : ((float_0 < 0.25f) ? 0.15f : ((float_0 < 0.5f) ? 0.3f : ((float_0 < 0.75f) ? 0.5f : 0.75f))));
		if (Status != 0)
		{
			num /= 2f;
		}
		if ((double)num < 0.05)
		{
			num = 0.05f;
		}
		if ((double)num > 0.95)
		{
			num = 0.95f;
		}
		float num2 = num;
		float num3 = (float)((double)num - 0.1);
		float num4 = (float)((double)num - 0.2);
		float num5 = (float)((double)num - 0.3);
		double num6 = GameGeneral.LockRandom_0.NextDouble();
		if (num6 < (double)num5)
		{
			Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer(base.ParentPlatform));
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " lost an engine", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
		}
		else if (num6 < (double)num4)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了严重的毁伤。", base.ParentPlatform.Name + " had an engine damaged", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < (double)num3)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了中度毁伤。", base.ParentPlatform.Name + " had an engine damaged", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < (double)num2)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "受轻伤。", base.ParentPlatform.Name + " had an engine damaged", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}
}
