using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Damage
{
	public delegate void DamageSustainedEventHandler(ActiveUnit myUnit);

	public enum ComponentHitType : byte
	{
		Mount,
		Sensor,
		Flooding,
		Fire,
		Engineering,
		CIC,
		Rudder,
		FlightDeck,
		Hangar,
		Cargo,
		PressureHull,
		Sonar,
		Magazine
	}

	public enum FireIntensityLevel : byte
	{
		NoFire,
		Minor,
		Major,
		Severe,
		Conflagration
	}

	public enum FloodingIntensityLevel : byte
	{
		NoFlooding,
		Minor,
		Major,
		Severe,
		Capsizing
	}

	[CompilerGenerated]
	private sealed class DatabaseMerchantService
	{
		public Weapon theWeapon;

		internal bool StartInterruptibleMock(Sensor theS)
		{
			if (theS.IsActive)
			{
				if (theS.DBID != theWeapon.ARM_SpecifiedEMission.Key)
				{
					return theS.classFacade == theWeapon.ARM_SpecifiedEMission.Key;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class FacadeComparator
	{
		public KeyValuePair<int, EmissionContainer> ARM_SpecifiedEmission;

		internal bool AssetInterruptibleMock(Sensor theE)
		{
			if (theE.DBID != ARM_SpecifiedEmission.Key)
			{
				return theE.classFacade == ARM_SpecifiedEmission.Key;
			}
			return true;
		}
	}

	protected ActiveUnit myUnit;

	protected FireIntensityLevel _FireIntensity;

	protected FloodingIntensityLevel _FloodIntensity;

	protected float _TimeToNextSecondaryDamageControl;

	public Weapon LastWeaponHit;

	[CompilerGenerated]
	private static DamageSustainedEventHandler _ObjectWrapper;

	public virtual FloodingIntensityLevel FloodIntensity
	{
		get
		{
			return _FloodIntensity;
		}
		set
		{
			try
			{
				if (value != _FloodIntensity)
				{
					_FloodIntensity = value;
					myUnit.Kinematics.PerformOutOfSequenceExportLocation = true;
					switch (_FloodIntensity)
					{
					case FloodingIntensityLevel.NoFlooding:
						myUnit.AddMessage(myUnit.Name + "密封了所有泄漏。", myUnit.Name + " - 所有漏水已修复", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FloodingIntensityLevel.Minor:
						myUnit.AddMessage(myUnit.Name + "有轻微的漏水。", myUnit.Name + " - 轻度漏水", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FloodingIntensityLevel.Major:
						myUnit.AddMessage(myUnit.Name + "有大量漏水。", myUnit.Name + " - 中度漏水", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FloodingIntensityLevel.Severe:
						myUnit.AddMessage(myUnit.Name + "有严重的漏水。", myUnit.Name + " - 严重漏水", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FloodingIntensityLevel.Capsizing:
						myUnit.AddMessage("警告：" + myUnit.Name + "有倾覆的危险！", myUnit.Name + " 有可能倾覆！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100111", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual FireIntensityLevel FireIntensity
	{
		get
		{
			return _FireIntensity;
		}
		set
		{
			try
			{
				if (value != _FireIntensity)
				{
					_FireIntensity = value;
					myUnit.Kinematics.PerformOutOfSequenceExportLocation = true;
					switch (_FireIntensity)
					{
					case FireIntensityLevel.NoFire:
						myUnit.AddMessage(myUnit.Name + "熄灭了所有火灾。", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FireIntensityLevel.Minor:
						myUnit.AddMessage(myUnit.Name + "有小火灾。", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FireIntensityLevel.Major:
						myUnit.AddMessage(myUnit.Name + "有大火灾。", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FireIntensityLevel.Severe:
						myUnit.AddMessage(myUnit.Name + "有严重的火灾。", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					case FireIntensityLevel.Conflagration:
						myUnit.AddMessage("警告：" + myUnit.Name + "有毁灭性大火灾！", "损伤报告", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100112", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public float DamagePercent
	{
		get
		{
			try
			{
				if (myUnit.IsFacility)
				{
					if (((Facility)myUnit).HasAimpoints)
					{
						int num = myUnit.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed).Count();
						if (num == 0)
						{
							return 100f;
						}
						return Math.Max(0f, Math.Min(100f, (float)(100.0 - (double)num / (double)myUnit.Mounts.Count * 100.0)));
					}
					if (myUnit.GetDamagePts() == (float)myUnit.InitialDP)
					{
						return 0f;
					}
					return Math.Max(0f, Math.Min(100f, (float)Math.Round(100f - myUnit.GetDamagePts() / (float)myUnit.InitialDP * 100f, 1)));
				}
				if (myUnit.GetDamagePts() == (float)myUnit.InitialDP)
				{
					return 0f;
				}
				return Math.Max(0f, Math.Min(100f, (float)Math.Round(100f - myUnit.GetDamagePts() / (float)myUnit.InitialDP * 100f, 1)));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100113", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				float damagePts = myUnit.GetDamagePts();
				ProjectData.ClearProjectError();
				return damagePts;
			}
		}
	}

	public static event DamageSustainedEventHandler DamageSustained
	{
		[CompilerGenerated]
		add
		{
			DamageSustainedEventHandler damageSustainedEventHandler = _ObjectWrapper;
			DamageSustainedEventHandler damageSustainedEventHandler2;
			do
			{
				damageSustainedEventHandler2 = damageSustainedEventHandler;
				DamageSustainedEventHandler value2 = (DamageSustainedEventHandler)Delegate.Combine(damageSustainedEventHandler2, value);
				damageSustainedEventHandler = Interlocked.CompareExchange(ref _ObjectWrapper, value2, damageSustainedEventHandler2);
			}
			while ((object)damageSustainedEventHandler != damageSustainedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DamageSustainedEventHandler damageSustainedEventHandler = _ObjectWrapper;
			DamageSustainedEventHandler damageSustainedEventHandler2;
			do
			{
				damageSustainedEventHandler2 = damageSustainedEventHandler;
				DamageSustainedEventHandler value2 = (DamageSustainedEventHandler)Delegate.Remove(damageSustainedEventHandler2, value);
				damageSustainedEventHandler = Interlocked.CompareExchange(ref _ObjectWrapper, value2, damageSustainedEventHandler2);
			}
			while ((object)damageSustainedEventHandler != damageSustainedEventHandler2);
		}
	}

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ActiveUnit_Damage");
			if ((int)FireIntensity > 0)
			{
				XmlWriter obj = xmlWriter_0;
				byte fireIntensity = (byte)_FireIntensity;
				obj.WriteElementString("Fire", fireIntensity.ToString());
			}
			if ((int)FloodIntensity > 0)
			{
				XmlWriter obj2 = xmlWriter_0;
				byte floodIntensity = (byte)_FloodIntensity;
				obj2.WriteElementString("Flood", floodIntensity.ToString());
			}
			xmlWriter_0.WriteElementString("TTNSDC", XmlConvert.ToString(_TimeToNextSecondaryDamageControl));
			if (LastWeaponHit != null)
			{
				xmlWriter_0.WriteStartElement("LastWeaponHit");
				LastWeaponHit.ToXML(ref xmlWriter_0, ref hashSet_0);
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100109", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Damage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_Damage activeUnit_Damage = new ActiveUnit_Damage();
			activeUnit_Damage.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TTNSDC":
						activeUnit_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "LastWeaponHit":
					{
						string innerText = Misc.StartRequest(xmlNode.ChildNodes[0].ChildNodes, "ID").InnerText;
						if (concurrentDictionary_0.ContainsKey(innerText))
						{
							activeUnit_Damage.LastWeaponHit = (Weapon)concurrentDictionary_0[innerText];
							break;
						}
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						activeUnit_Damage.LastWeaponHit = Weapon.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
						break;
					}
					case "Flood":
						activeUnit_Damage._FloodIntensity = (FloodingIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "Fire":
						activeUnit_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
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
			return activeUnit_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100110", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_Damage result = new ActiveUnit_Damage();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private ActiveUnit_Damage()
	{
		LastWeaponHit = null;
	}

	public ActiveUnit_Damage(ref ActiveUnit activeUnit_0)
	{
		LastWeaponHit = null;
		myUnit = activeUnit_0;
	}

	public virtual void ResolveDamageFromFrag(float float_0, float float_1, int int_0 = 0)
	{
		if (myUnit.RemoteSimEntityType != 0)
		{
			return;
		}
		float damagePts = myUnit.GetDamagePts();
		try
		{
			if (float_0 > 0f)
			{
				new WeaponImpact(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
				if ((int)Math.Round(float_0) == 0)
				{
					myUnit.AddMessage(myUnit.Name + "遭受了轻微的碎片毁伤", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + "遭受了碎片毁伤：" + Conversions.ToString(Math.Round(float_0, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - float_0);
				ResolveComponentHits(Warhead.WarheadType.Fragmentation, Warhead.WarheadExplosivesType.Fragmentation, float_0, damagePts, 0f, bool_0: true, 0f, int_0);
				ResolveProximityDamageToHostedUnits(bool_0: true);
				RaiseEvent_DamageSustained();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100114", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public double CalculateLaserImpactDamage(Weapon weapon_0, GeoPoint geoPoint_0)
	{
		myUnit.GetDamagePts();
		try
		{
			double num = geoPoint_0.RangeToPoint_Slant(new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude())) / weapon_0.MaxRange_NoTargetType;
			double num2 = (double)weapon_0.Warheads[0].DP * Math.Pow(1.0 - num, 2.0);
			if (geoPoint_0.Altitude <= 12000f || myUnit.GetCurrentAltitude() <= 12000f)
			{
				double num3;
				if (geoPoint_0.Altitude < 12000f && myUnit.GetCurrentAltitude() < 12000f)
				{
					num3 = 1.0;
				}
				else
				{
					float num4 = Math.Abs(geoPoint_0.Altitude - myUnit.GetCurrentAltitude());
					num3 = ((!(geoPoint_0.Altitude > 12000f) || myUnit.GetCurrentAltitude() >= 12000f) ? ((double)((12000f - geoPoint_0.Altitude) / num4)) : ((double)((12000f - myUnit.GetCurrentAltitude()) / num4)));
				}
				Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(myUnit.ParentScen, myUnit.GetLatitude(), myUnit.GetLongitude(), (int)Math.Round(myUnit.GetCurrentAltitude()));
				double num5 = 1f - weatherAtThisTimeAndPlace.FractionUnderRain;
				float rainfallRate = weatherAtThisTimeAndPlace.RainfallRate;
				double num6 = ((!(rainfallRate <= 40f)) ? 0.05 : ((!(rainfallRate <= 30f)) ? 0.1 : ((!(rainfallRate <= 20f)) ? 0.25 : ((!(rainfallRate <= 10f)) ? 0.5 : ((rainfallRate <= 0f) ? 1.0 : 0.75)))));
				double num7 = num5 * num6;
				if (num3 < 1.0 && num7 < 1.0)
				{
					num7 *= 1.0 - num3;
				}
				num2 *= num7;
			}
			LastWeaponHit = weapon_0;
			return num2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10011205314", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.0;
		}
	}

	public virtual void ResolveDamageFromBlast(float float_0, Warhead.WarheadType warheadType_0, Warhead.WarheadExplosivesType warheadExplosivesType_0, Weapon.DetonationMedium detonationMedium_0)
	{
		if (myUnit.RemoteSimEntityType != 0)
		{
			return;
		}
		float damagePts = myUnit.GetDamagePts();
		try
		{
			if (myUnit.IsMCMPlatform && detonationMedium_0 == Weapon.DetonationMedium.Underwater)
			{
				float_0 = (float)((double)float_0 * 0.1);
			}
			AdjustBlastDamageForArmor(ref float_0);
			if (Math.Round(float_0, 1) <= 0.0)
			{
				return;
			}
			new WeaponImpact(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
			bool flag = myUnit.AirFacilities_ReadOnly.Length != 0 && myUnit.AirFacilities_ReadOnly.Length == myUnit.AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Count();
			if (myUnit.IsFixedFacility && flag)
			{
				float_0 -= 10000f;
				if (float_0 <= 0f)
				{
					return;
				}
				float_0 *= 0.01f;
			}
			if (!myUnit.IsWeapon)
			{
				myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + "受到爆炸毁伤：" + Conversions.ToString(Math.Round(float_0, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
			myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - float_0);
			ResolveComponentHits(warheadType_0, warheadExplosivesType_0, float_0, damagePts, 0f, bool_0: true, 0f);
			ResolveProximityDamageToHostedUnits(bool_0: true);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100115", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageFromBomblets(float float_0, Warhead.WarheadType warheadType_0, Warhead.WarheadExplosivesType warheadExplosivesType_0, float float_1)
	{
		if (float_0 == 0f || myUnit.RemoteSimEntityType != 0)
		{
			return;
		}
		try
		{
			float damagePts = myUnit.GetDamagePts();
			AdjustBombletDamageForArmor(ref float_0, warheadType_0);
			if (Math.Round(float_0, 2) > 0.0)
			{
				new WeaponImpact(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
				myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + "遭受了炸弹毁伤：" + Conversions.ToString(Math.Round(float_0, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - float_0);
				ResolveComponentHits(warheadType_0, warheadExplosivesType_0, float_0, damagePts, 0f, bool_0: true, 0f);
				ResolveProximityDamageToHostedUnits(bool_0: true);
				RaiseEvent_DamageSustained();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100116", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void AdjustBombletDamageForArmor(ref float float_0, Warhead.WarheadType warheadType_0)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	public virtual void AdjustBlastDamageForArmor(ref float float_0)
	{
	}

	protected virtual void ResolveDamageFromDirectImpact(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ref ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2)
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		throw new NotImplementedException();
	}

	public virtual void ResolveDamageFromWeapon(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0)
	{
		if (Module_Unit.AwakeTokenizer(myUnit))
		{
			return;
		}
		try
		{
			if (weapon_0.Type == Weapon._WeaponType.Microwave)
			{
				float float_2 = (float)Math.Pow(1f - Module_Unit.RangeToUnit_Slant(myUnit, weapon_0.FiringParent) / weapon_0.MaxRange_NoTargetType, 2.0);
				method_0(float_2);
			}
			else
			{
				if (weapon_0.Warheads.Length == 0)
				{
					return;
				}
				if (bool_0)
				{
					if (myUnit.RemoteSimEntityType != 0)
					{
						return;
					}
					ResolveDamageFromDirectImpact(weapon_0, geoPoint_0, float_0, float_1, ref activeUnit_0, nullable_0, nullable_1, nullable_2);
				}
				else
				{
					float damagePts = myUnit.GetDamagePts();
					if (weapon_0.ValidTargets.Radar && !Information.IsNothing(weapon_0.ARM_SpecifiedEMission))
					{
						IEnumerable<Sensor> source = myUnit.Sensors_Cached.Where((Sensor theS) => theS.IsActive && (theS.DBID == weapon_0.ARM_SpecifiedEMission.Key || theS.classFacade == weapon_0.ARM_SpecifiedEMission.Key));
						if (source.Count() > 0)
						{
							int index = GameGeneral.LockRandom_0.Next(0, source.Count());
							DetermineComponentDamage(weapon_0.Warheads[0].Type, weapon_0.Warheads[0].ExplosivesType, source.ElementAtOrDefault(index), weapon_0.Warheads[0].DP, damagePts, weapon_0.ARM_SpecifiedEMission.Key, 0f);
						}
					}
					ResolveDamageFromWeapon_CreateExplosion(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2);
				}
				LastWeaponHit = weapon_0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100117", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageFromWeapon_CreateExplosion(Weapon weapon_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2)
	{
		if (Debugger.IsAttached)
		{
			_ = nullable_0.HasValue;
			_ = nullable_1.HasValue;
		}
		Warhead warhead = weapon_0.Warheads[0];
		if (warhead.IsExplosive || warhead.IsIncendiary)
		{
			if (Information.IsNothing(nullable_2))
			{
				nullable_2 = ((!weapon_0.Navigator.HasPlottedCourse() || weapon_0.Navigator.PlottedCourse[0].Altitude <= 4000f) ? new float?((int)Math.Round(weapon_0.ImpactAltitude)) : new float?((int)Math.Round(weapon_0.GetCurrentAltitude())));
			}
			if (Information.IsNothing(nullable_0) || Information.IsNothing(nullable_1))
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_, ref double_2, float_0 / 1852f, float_1);
				nullable_0 = double_2;
				nullable_1 = double_;
			}
			new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, nullable_2.Value, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, activeUnit_0, null, null, 0, 0);
			myUnit.Damage.LastWeaponHit = weapon_0;
		}
	}

	public virtual void DetermineSecondaryDamage(float float_0, Warhead.WarheadType warheadType_0, float float_1)
	{
	}

	public bool AimpointHasCompatibleEmitter(Mount mount_0, KeyValuePair<int, EmissionContainer> keyValuePair_0)
	{
		try
		{
			return (from theE in mount_0.Sensors_ReadOnly
				select (theE) into theE
				where theE.DBID == keyValuePair_0.Key || theE.classFacade == keyValuePair_0.Key
				select theE).Count() > 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100118", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void CollectClient()
	{
	}

	protected void ResolveComponentHits(Warhead.WarheadType warheadType_0, Warhead.WarheadExplosivesType warheadExplosivesType_0, double double_0, float float_0, float float_1, bool bool_0, float float_2, int int_0 = 0)
	{
		try
		{
			int num = DetermineNumberOfComponentHits(double_0, warheadType_0, float_0, float_1, int_0);
			bool flag = int_0 == 0;
			if (num > myUnit.OrderIssuer().Count)
			{
				num = myUnit.OrderIssuer().Count;
			}
			if (num > 0)
			{
				int num2 = num;
				for (int i = 1; i <= num2; i++)
				{
					PlatformComponent platformComponent = DetermineHitComponent(int_0, flag);
					if (platformComponent != null && !string.IsNullOrEmpty(platformComponent.Name) && platformComponent.IsSensor && ((Sensor)platformComponent).m_IsMk1Eyeball)
					{
						platformComponent = null;
					}
					if (platformComponent != null)
					{
						DetermineComponentDamage(warheadType_0, warheadExplosivesType_0, platformComponent, double_0, float_0, int_0, float_2);
					}
					if (!flag)
					{
						flag = true;
					}
				}
			}
			DetermineSecondaryDamage((float)double_0, warheadType_0, float_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100119", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void ResolveProximityDamageToHostedUnits(bool bool_0)
	{
		if (!bool_0)
		{
			return;
		}
		AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
		AirFacility[] array = airFacilities_ReadOnly;
		foreach (AirFacility airFacility in array)
		{
			if (airFacility.IsOpenAirFacility)
			{
				double num = GameGeneral.LockRandom_0.NextDouble();
				PlatformComponent._DamageSeverityFactor damageSeverityFactor = ((!(num <= 0.7)) ? PlatformComponent._DamageSeverityFactor.Heavy : ((!(num <= 0.3)) ? PlatformComponent._DamageSeverityFactor.Medium : PlatformComponent._DamageSeverityFactor.Light));
				if (myUnit.IsFacility && (((Facility)myUnit).Category == Facility._FacilityCategory.Building_Reveted || ((Facility)myUnit).Category == Facility._FacilityCategory.Structure_Reveted) && damageSeverityFactor != 0)
				{
					damageSeverityFactor--;
				}
				airFacility.HandleDamageToHostedAircraft(damageSeverityFactor, 0f);
			}
		}
	}

	protected void RaiseEvent_DamageSustained()
	{
		_ObjectWrapper?.Invoke(myUnit);
	}

	protected virtual void DetermineDamageResult(ComponentHitType componentHitType_0)
	{
	}

	public void DetermineComponentDamage(Warhead.WarheadType warheadType_0, Warhead.WarheadExplosivesType warheadExplosivesType_0, PlatformComponent platformComponent_0, double double_0, float float_0, int int_0, float float_1)
	{
		int num = GameGeneral.LockRandom_0.Next(1, 101);
		try
		{
			if (num < 10 && platformComponent_0.IsSensor && int_0 == platformComponent_0.DBID)
			{
				num = 10;
			}
			GlobalVariables.ArmorRating armorRating = GlobalVariables.ArmorRating.None;
			if (platformComponent_0.IsMount)
			{
				armorRating = ((Mount)platformComponent_0).ArmorRating;
			}
			if (platformComponent_0.IsMagazine)
			{
				armorRating = ((Magazine)platformComponent_0).Armor;
			}
			if (armorRating != GlobalVariables.ArmorRating.None || !platformComponent_0.IsAirFacility)
			{
				goto IL_0b8c;
			}
			switch (platformComponent_0.ParentPlatform.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				armorRating = ((Aircraft)platformComponent_0.ParentPlatform).Armor_Fuselage;
				goto IL_0b8c;
			case GlobalVariables.ActiveUnitType.Ship:
				armorRating = ((Ship)platformComponent_0.ParentPlatform).Armor_Deck;
				goto IL_0b8c;
			case GlobalVariables.ActiveUnitType.Facility:
				armorRating = ((Facility)platformComponent_0.ParentPlatform).Armor_General;
				goto IL_0b8c;
			case GlobalVariables.ActiveUnitType.Submarine:
				break;
			default:
				goto IL_0b8c;
			}
			armorRating = GlobalVariables.ArmorRating.Heavy;
			goto IL_0c20;
			IL_010f:
			string string_ = (((object)platformComponent_0.GetType() == typeof(Cargo)) ? ("[货物]" + ((Cargo)platformComponent_0).CargoObjectName) : platformComponent_0.Name);
			int num2 = num;
			PlatformComponent._DamageSeverityFactor damageSeverityFactor_ = PlatformComponent._DamageSeverityFactor.Light;
			if (num2 >= 10)
			{
				if (num2 < 30)
				{
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "已经轻微受损。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "遭受了额外的轻度损伤。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					damageSeverityFactor_ = PlatformComponent._DamageSeverityFactor.Light;
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational)
					{
						platformComponent_0.Damage(PlatformComponent._DamageSeverityFactor.Light);
					}
				}
				else if (num2 < 40)
				{
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "已经中度受损。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "遭受了额外的中度毁伤。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					damageSeverityFactor_ = PlatformComponent._DamageSeverityFactor.Medium;
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational || (platformComponent_0.Status == PlatformComponent._ComponentStatus.Damaged && (int)platformComponent_0.DamageSeverity < 1))
					{
						platformComponent_0.Damage(PlatformComponent._DamageSeverityFactor.Medium);
					}
				}
				else if (num2 < 70)
				{
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "已经严重受损。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "遭受了额外的重伤。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					damageSeverityFactor_ = PlatformComponent._DamageSeverityFactor.Heavy;
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational || (platformComponent_0.Status == PlatformComponent._ComponentStatus.Damaged && (int)platformComponent_0.DamageSeverity < 2))
					{
						platformComponent_0.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
					}
				}
				else if (platformComponent_0.IsAirFacility && ((AirFacility)platformComponent_0).IsOpenAirFacility)
				{
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "已经严重受损。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "遭受了额外的重伤。", myUnit.Name + " 有组件受损", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					damageSeverityFactor_ = PlatformComponent._DamageSeverityFactor.Heavy;
					platformComponent_0.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
				}
				else
				{
					if (platformComponent_0.Status == PlatformComponent._ComponentStatus.Operational)
					{
						if (!myUnit.IsWeapon)
						{
							myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "已被摧毁！", myUnit.Name + " 有组件被摧毁", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
					}
					else if (!myUnit.IsWeapon)
					{
						myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(string_) + "遭受了额外的毁伤！", myUnit.Name + " 有组件被摧毁", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					if ((int)platformComponent_0.Status < 2)
					{
						platformComponent_0.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
					}
				}
			}
			if (platformComponent_0.Status != PlatformComponent._ComponentStatus.Destroyed && platformComponent_0.IsAirFacility)
			{
				((AirFacility)platformComponent_0).HandleDamageToHostedAircraft(damageSeverityFactor_, float_1);
			}
			return;
			IL_0c20:
			switch (warheadExplosivesType_0)
			{
			case Warhead.WarheadExplosivesType.Incendiary_Napalm:
			case Warhead.WarheadExplosivesType.Incendiary_WP:
			case Warhead.WarheadExplosivesType.HEAT_LightArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor:
				num = 0;
				break;
			case Warhead.WarheadExplosivesType.Incendiary_FAE:
			case Warhead.WarheadExplosivesType.HEAT_MediumArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_MediumArmor:
				num -= 90;
				break;
			default:
				num -= 50;
				break;
			case Warhead.WarheadExplosivesType.Fragmentation:
			case Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation:
			case Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber:
			case Warhead.WarheadExplosivesType.LaserEnergy:
			case Warhead.WarheadExplosivesType.KineticEnergy:
				num = 0;
				break;
			}
			goto IL_010f;
			IL_0ae2:
			Warhead.WarheadExplosivesType warheadExplosivesType = warheadExplosivesType_0;
			Warhead.WarheadExplosivesType warheadExplosivesType2 = warheadExplosivesType;
			if (warheadExplosivesType2 <= Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor)
			{
				if (warheadExplosivesType2 <= Warhead.WarheadExplosivesType.HEAT_LightArmor)
				{
					if ((uint)(warheadExplosivesType2 - 2101) <= 1u || warheadExplosivesType2 == Warhead.WarheadExplosivesType.HEAT_LightArmor)
					{
						goto IL_0b75;
					}
				}
				else
				{
					if (warheadExplosivesType2 == Warhead.WarheadExplosivesType.Fragmentation || warheadExplosivesType2 == Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation)
					{
						goto IL_0b83;
					}
					if (warheadExplosivesType2 == Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor)
					{
						goto IL_0b75;
					}
				}
			}
			else if (warheadExplosivesType2 <= Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor)
			{
				if (warheadExplosivesType2 == Warhead.WarheadExplosivesType.Mine_AntiTank_LightArmor || warheadExplosivesType2 == Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor)
				{
					goto IL_0b75;
				}
			}
			else if (warheadExplosivesType2 == Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber || warheadExplosivesType2 == Warhead.WarheadExplosivesType.LaserEnergy || warheadExplosivesType2 == Warhead.WarheadExplosivesType.KineticEnergy)
			{
				goto IL_0b83;
			}
			num -= 30;
			goto IL_010f;
			IL_0b75:
			num -= 90;
			goto IL_010f;
			IL_0b8c:
			switch (armorRating)
			{
			case GlobalVariables.ArmorRating.Special:
				goto IL_09e0;
			case GlobalVariables.ArmorRating.Medium:
				goto IL_0ae2;
			case GlobalVariables.ArmorRating.Light:
				goto IL_0bc6;
			case GlobalVariables.ArmorRating.Heavy:
				goto IL_0c20;
			}
			goto IL_010f;
			IL_09e0:
			switch (warheadExplosivesType_0)
			{
			case Warhead.WarheadExplosivesType.Incendiary_Napalm:
			case Warhead.WarheadExplosivesType.Incendiary_WP:
			case Warhead.WarheadExplosivesType.HEAT_LightArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_LightArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_LightArmor:
				num = 0;
				break;
			case Warhead.WarheadExplosivesType.Incendiary_FAE:
			case Warhead.WarheadExplosivesType.HEAT_MediumArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_MediumArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_MediumArmor:
				num = 0;
				break;
			case Warhead.WarheadExplosivesType.HEAT_HeavyArmor:
			case Warhead.WarheadExplosivesType.Submunitions_AntiTank_HeavyArmor:
			case Warhead.WarheadExplosivesType.Mine_AntiTank_HeavyArmor:
			case Warhead.WarheadExplosivesType.LongRodPenetrator_HeavyArmor:
				num -= 90;
				break;
			default:
				num -= 70;
				break;
			case Warhead.WarheadExplosivesType.Fragmentation:
			case Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation:
			case Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber:
			case Warhead.WarheadExplosivesType.LaserEnergy:
			case Warhead.WarheadExplosivesType.KineticEnergy:
				num = 0;
				break;
			}
			goto IL_010f;
			IL_0c0d:
			num -= 10;
			goto IL_010f;
			IL_0bc6:
			Warhead.WarheadExplosivesType warheadExplosivesType3 = warheadExplosivesType_0;
			Warhead.WarheadExplosivesType warheadExplosivesType4 = warheadExplosivesType3;
			if (warheadExplosivesType4 <= Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation)
			{
				if (warheadExplosivesType4 != Warhead.WarheadExplosivesType.Fragmentation && warheadExplosivesType4 != Warhead.WarheadExplosivesType.Submunitions_AntiPersonnel_Fragmentation)
				{
					goto IL_0c0d;
				}
			}
			else if (warheadExplosivesType4 != Warhead.WarheadExplosivesType.AntiElectrical_ConductiveFiber && warheadExplosivesType4 != Warhead.WarheadExplosivesType.LaserEnergy && warheadExplosivesType4 != Warhead.WarheadExplosivesType.KineticEnergy)
			{
				goto IL_0c0d;
			}
			num -= 90;
			goto IL_010f;
			IL_0b83:
			num = 0;
			goto IL_010f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100120", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void DoSecondaryDamage(float float_0)
	{
		try
		{
			float num = 0f;
			switch (FireIntensity)
			{
			case FireIntensityLevel.Minor:
				num = (float)((double)myUnit.InitialDP * 0.04 * (double)(float_0 / 3600f));
				break;
			case FireIntensityLevel.Major:
				num = (float)((double)myUnit.InitialDP * 0.08 * (double)(float_0 / 3600f));
				break;
			case FireIntensityLevel.Severe:
				num = (float)((double)myUnit.InitialDP * 0.12 * (double)(float_0 / 3600f));
				break;
			case FireIntensityLevel.Conflagration:
			{
				num = (float)((double)myUnit.InitialDP * 0.24 * (double)(float_0 / 3600f));
				bool flag = myUnit.AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Any();
				if ((myUnit.IsFacility && flag) || GameGeneral.LockRandom_0.Next(1, 101) > 5)
				{
					break;
				}
				myUnit.AddMessage(myUnit.Name + "火灾肆虐失控，正在瓦解！", myUnit.Name + " 正在燃烧！！！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				if (myUnit.IsShip)
				{
					if (((Ship)myUnit).IsSinking)
					{
						myUnit.ParentScen.DestroyThisUnit(myUnit, "Onboard fires raging out of control.", "Fire / Flooding");
					}
					else
					{
						myUnit.SetDamagePts(bool_0: false, null, Math.Min(myUnit.GetDamagePts(), -1f));
					}
				}
				else
				{
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Fire damage", "Fire / Flooding");
				}
				return;
			}
			}
			float num2 = 0f;
			switch (FloodIntensity)
			{
			case FloodingIntensityLevel.Minor:
				num2 = (float)((double)myUnit.InitialDP * 0.04 * (double)(float_0 / 3600f));
				break;
			case FloodingIntensityLevel.Major:
				num2 = (float)((double)myUnit.InitialDP * 0.08 * (double)(float_0 / 3600f));
				break;
			case FloodingIntensityLevel.Severe:
				num2 = (float)((double)myUnit.InitialDP * 0.12 * (double)(float_0 / 3600f));
				break;
			case FloodingIntensityLevel.Capsizing:
				num2 = (float)((double)myUnit.InitialDP * 0.24 * (double)(float_0 / 3600f));
				if (myUnit.IsShip && GameGeneral.LockRandom_0.Next(1, 101) <= 5)
				{
					myUnit.AddMessage(myUnit.Name + "倾覆 - 放弃船!!!", myUnit.Name + " 正在倾覆！！！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					if (((Ship)myUnit).IsSinking)
					{
						myUnit.ParentScen.DestroyThisUnit(myUnit, "Ship capsizing", "Fire / Flooding");
					}
					else
					{
						myUnit.SetDamagePts(bool_0: false, null, Math.Min(myUnit.GetDamagePts(), -1f));
					}
					return;
				}
				break;
			}
			if (num + num2 > 0f)
			{
				myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - (num + num2));
			}
			_TimeToNextSecondaryDamageControl -= float_0;
			if (_TimeToNextSecondaryDamageControl > 0f || num + num2 == 0f)
			{
				return;
			}
			if (FireIntensity != 0)
			{
				byte b = (byte)GameGeneral.LockRandom_0.Next(1, 11);
				GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
				int? num3 = (int?)proficiency;
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					b += 3;
				}
				else
				{
					num3 = (int?)proficiency;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						b += 2;
					}
					else
					{
						num3 = (int?)proficiency;
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							b++;
						}
						else
						{
							num3 = (int?)proficiency;
							if (!(num3.HasValue ? new bool?(num3.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num3 = (int?)proficiency;
								if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									b = (byte)Math.Max(0, b - 2);
								}
							}
						}
					}
				}
				if (myUnit.IsSubmarine && ((Submarine)myUnit).Flags.UsesLiOnBattery)
				{
					b += 2;
				}
				b = (byte)Math.Max(0, (int)b);
				if (b > 10)
				{
					b = 10;
					goto IL_0a0e;
				}
				if ((uint)(b - 1) > 3u)
				{
					if ((uint)(b - 9) <= 1u)
					{
						goto IL_0a0e;
					}
				}
				else
				{
					FireIntensity = (FireIntensityLevel)Math.Max(0, (int)(FireIntensity - 1));
				}
			}
			goto IL_076f;
			IL_0744:
			if (FloodIntensity != FloodingIntensityLevel.Capsizing)
			{
				FloodIntensity++;
			}
			goto IL_0723;
			IL_0a0e:
			if (FireIntensity != FireIntensityLevel.Conflagration)
			{
				FireIntensity++;
			}
			goto IL_076f;
			IL_076f:
			if (FloodIntensity != 0)
			{
				byte b2 = (byte)GameGeneral.LockRandom_0.Next(1, 11);
				GlobalVariables.ProficiencyLevel? proficiency2 = myUnit.Proficiency;
				int? num4 = (int?)proficiency2;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					b2 += 3;
				}
				else
				{
					num4 = (int?)proficiency2;
					if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						b2 += 2;
					}
					else
					{
						num4 = (int?)proficiency2;
						if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							b2++;
						}
						else
						{
							num4 = (int?)proficiency2;
							if (!(num4.HasValue ? new bool?(num4.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num4 = (int?)proficiency2;
								if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									b2 = (byte)Math.Max(0, b2 - 2);
								}
							}
						}
					}
				}
				b2 = (byte)Math.Max(0, (int)b2);
				if (b2 > 10)
				{
					b2 = 10;
					goto IL_0744;
				}
				if ((uint)(b2 - 1) > 3u)
				{
					if ((uint)(b2 - 9) <= 1u)
					{
						goto IL_0744;
					}
				}
				else
				{
					FloodIntensity = (FloodingIntensityLevel)Math.Max(0, (int)(FloodIntensity - 1));
				}
			}
			goto IL_0723;
			IL_0723:
			_TimeToNextSecondaryDamageControl = GameGeneral.LockRandom_0.Next(900, 1801);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200283", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected void CauseFlooding(FloodingIntensityLevel floodingIntensityLevel_0)
	{
		try
		{
			if ((int)floodingIntensityLevel_0 <= (int)FloodIntensity)
			{
				if (floodingIntensityLevel_0 == FloodIntensity && FloodIntensity != FloodingIntensityLevel.Capsizing)
				{
					double num = 0.0;
					switch (floodingIntensityLevel_0)
					{
					case FloodingIntensityLevel.Minor:
						num = 0.5;
						break;
					case FloodingIntensityLevel.Major:
						num = 0.25;
						break;
					case FloodingIntensityLevel.Severe:
						num = 0.1;
						break;
					}
					if (GameGeneral.LockRandom_0.NextDouble() < num)
					{
						FloodIntensity++;
					}
				}
			}
			else
			{
				FloodIntensity = floodingIntensityLevel_0;
			}
			_TimeToNextSecondaryDamageControl = GameGeneral.LockRandom_0.Next(120, 181);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100122", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CauseFire(FireIntensityLevel fireIntensityLevel_0)
	{
		try
		{
			if ((int)fireIntensityLevel_0 <= (int)FireIntensity)
			{
				if (fireIntensityLevel_0 == FireIntensity && FireIntensity != FireIntensityLevel.Conflagration)
				{
					double num = 0.0;
					switch (fireIntensityLevel_0)
					{
					case FireIntensityLevel.Minor:
						num = 0.5;
						break;
					case FireIntensityLevel.Major:
						num = 0.25;
						break;
					case FireIntensityLevel.Severe:
						num = 0.1;
						break;
					}
					if (GameGeneral.LockRandom_0.NextDouble() < num)
					{
						FireIntensity++;
					}
				}
			}
			else
			{
				FireIntensity = fireIntensityLevel_0;
			}
			_TimeToNextSecondaryDamageControl = GameGeneral.LockRandom_0.Next(120, 181);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100123", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected virtual PlatformComponent DetermineHitComponent(int int_0 = 0, bool bool_0 = false)
	{
		if (myUnit.OrderIssuer().Count == 0)
		{
			return null;
		}
		try
		{
			if (!bool_0 && int_0 > 0)
			{
				List<PlatformComponent> list = new List<PlatformComponent>();
				foreach (PlatformComponent item in myUnit.OrderIssuer())
				{
					if (item.IsSensor && (((Sensor)item).DBID == int_0 || ((Sensor)item).classFacade == int_0))
					{
						list.Add(item);
					}
				}
				if (list.Count > 0)
				{
					int index = GameGeneral.LockRandom_0.Next(0, list.Count);
					return list[index];
				}
			}
			float num = (float)(1.0 / (double)myUnit.OrderIssuer().Count);
			if (num < 5f)
			{
				num = 5f;
			}
			PlatformComponent platformComponent;
			float num2;
			int index2;
			do
			{
				index2 = GameGeneral.LockRandom_0.Next(0, myUnit.OrderIssuer().Count);
				platformComponent = myUnit.OrderIssuer()[index2];
				num2 = num;
				num2 = ((platformComponent.IsSensor || platformComponent.IsMount || platformComponent.IsCommDevice) ? (2f * num) : ((!platformComponent.IsAirFacility) ? (num / 3f) : (((AirFacility)platformComponent).IsOpenAirFacility ? (num * 3f) : (num / 3f))));
				if ((double)num2 > 0.9)
				{
					num2 = 0.9f;
				}
				index2 = GameGeneral.LockRandom_0.Next(1, 101);
			}
			while (!((double)index2 / 100.0 < (double)num2));
			return platformComponent;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100124", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	protected int DetermineNumberOfComponentHits(double double_0, Warhead.WarheadType warheadType_0, float float_0, float float_1, int int_0 = 0)
	{
		try
		{
			float num = (float)Math.Round(double_0 / (double)float_0, 2);
			if (myUnit.OrderIssuer().Count == 0)
			{
				return 0;
			}
			if (warheadType_0 != Warhead.WarheadType.Fragmentation && warheadType_0 != Warhead.WarheadType.Cluster_AP && warheadType_0 != Warhead.WarheadType.Cluster_AT)
			{
				int num3 = GameGeneral.LockRandom_0.Next(1, 8);
				num3 = (int)Math.Round((float)num3 * (float_1 + 1f));
				if (warheadType_0 == Warhead.WarheadType.Torpedo)
				{
					num3 += 5;
				}
				double num4 = Math.Round(num, 1);
				if (num4 < 0.1)
				{
					return num3 - 6;
				}
				if (num4 == 0.1)
				{
					return num3 - 4;
				}
				if (num4 == 0.2)
				{
					return num3 - 3;
				}
				if (num4 == 0.3)
				{
					return num3 - 2;
				}
				if (num4 == 0.4)
				{
					return num3 - 1;
				}
				if (num4 == 0.5)
				{
					return num3;
				}
				if (num4 == 0.6)
				{
					return num3 + 1;
				}
				if (num4 == 0.7)
				{
					return num3 + 2;
				}
				if (num4 == 0.8)
				{
					return num3 + 3;
				}
				if (num4 == 0.9)
				{
					return num3 + 4;
				}
				return num3 + 5;
			}
			int num5 = 0;
			int num6 = ((double_0 <= 10.0) ? 1 : ((double_0 <= 20.0) ? 2 : ((double_0 <= 50.0) ? 3 : ((double_0 <= 100.0) ? 4 : 5))));
			for (int i = 1; i <= num6; i++)
			{
				int num2 = GameGeneral.LockRandom_0.Next(1, 8);
				num5 += num2;
			}
			return num5;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100125", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	protected virtual PlatformComponent DetermineComponentThatIsHit(ComponentHitType componentHitType_0)
	{
		List<PlatformComponent> list = new List<PlatformComponent>();
		try
		{
			switch (componentHitType_0)
			{
			case ComponentHitType.Mount:
			{
				Magazine[] magazines = ((Platform)myUnit).Magazines;
				Magazine[] array5 = magazines;
				foreach (Magazine item2 in array5)
				{
					list.Add(item2);
				}
				DockFacility[] dockFacilities_ReadOnly = myUnit.DockFacilities_ReadOnly;
				DockFacility[] array6 = dockFacilities_ReadOnly;
				foreach (DockFacility item3 in array6)
				{
					list.Add(item3);
				}
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array7 = airFacilities_ReadOnly;
				foreach (AirFacility item4 in array7)
				{
					list.Add(item4);
				}
				foreach (Mount mount in myUnit.Mounts)
				{
					list.Add(mount);
				}
				if (list.Count == 0)
				{
					return null;
				}
				int index6 = GameGeneral.LockRandom_0.Next(0, list.Count);
				return list[index6];
			}
			case ComponentHitType.Sensor:
			{
				Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
				Sensor[] array8 = sensors_Cached2;
				foreach (Sensor item5 in array8)
				{
					list.Add(item5);
				}
				if (list.Count == 0)
				{
					return null;
				}
				int index7 = GameGeneral.LockRandom_0.Next(0, list.Count);
				return list[index7];
			}
			case ComponentHitType.Engineering:
			{
				foreach (Engine item6 in myUnit.Propulsion)
				{
					list.Add(item6);
				}
				if (list.Count == 0)
				{
					return null;
				}
				int index4 = GameGeneral.LockRandom_0.Next(0, list.Count);
				return list[index4];
			}
			case ComponentHitType.CIC:
				return ((Ship)myUnit).CIC;
			case ComponentHitType.Rudder:
				if ((object)myUnit.GetType() == typeof(Ship))
				{
					return ((Ship)myUnit).Rudder;
				}
				if ((object)myUnit.GetType() == typeof(Submarine))
				{
					return ((Submarine)myUnit).Rudder;
				}
				goto default;
			default:
				return null;
			case ComponentHitType.FlightDeck:
			{
				AirFacility[] airFacilities_ReadOnly3 = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array4 = airFacilities_ReadOnly3;
				foreach (AirFacility airFacility2 in array4)
				{
					switch (airFacility2.AirFacType)
					{
					case AirFacility._AirFacType.Runway:
					case AirFacility._AirFacType.RunwayWithArrest:
					case AirFacility._AirFacType.RunwayAccessPoint:
					case AirFacility._AirFacType.Catapult:
					case AirFacility._AirFacType.SkiJump:
					case AirFacility._AirFacType.CarrierArrestingGear:
					case AirFacility._AirFacType.Pad:
					case AirFacility._AirFacType.PadWithHaulDown:
					case AirFacility._AirFacType.OpenParking:
					case AirFacility._AirFacType.Elevator:
						list.Add(airFacility2);
						break;
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				int index5 = GameGeneral.LockRandom_0.Next(0, list.Count);
				return list[index5];
			}
			case ComponentHitType.Hangar:
			{
				AirFacility[] airFacilities_ReadOnly2 = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array2 = airFacilities_ReadOnly2;
				foreach (AirFacility airFacility in array2)
				{
					if (airFacility.AirFacType == AirFacility._AirFacType.Hangar)
					{
						list.Add(airFacility);
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				int index2 = GameGeneral.LockRandom_0.Next(0, list.Count);
				return list[index2];
			}
			case ComponentHitType.Cargo:
			{
				int num = GameGeneral.LockRandom_0.Next(0, myUnit.OnboardCargo.Count());
				return myUnit.OnboardCargo[num];
			}
			case ComponentHitType.PressureHull:
				return ((Submarine)myUnit).PressureHull;
			case ComponentHitType.Sonar:
			{
				Sensor[] sensors_Cached = myUnit.Sensors_Cached;
				Sensor[] array3 = sensors_Cached;
				foreach (Sensor sensor in array3)
				{
					if (sensor.IsSonar)
					{
						list.Add(sensor);
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				int index3 = GameGeneral.LockRandom_0.Next(0, list.Count);
				return list[index3];
			}
			case ComponentHitType.Magazine:
			{
				Magazine[] magazines2 = ((Platform)myUnit).Magazines;
				Magazine[] array = magazines2;
				foreach (Magazine item in array)
				{
					list.Add(item);
				}
				if (list.Count == 0)
				{
					return null;
				}
				int index = GameGeneral.LockRandom_0.Next(0, list.Count);
				return list[index];
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100127", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public float ArmorPenetrationPercent(Warhead warhead_0)
	{
		return 100f;
	}

	public virtual ComponentHitType ResolveComponentHitType(Warhead warhead_0)
	{
		return ComponentHitType.Mount;
	}

	public virtual void UnderwayRepairs(float float_0)
	{
		if (myUnit.ParentScen.HourIsChangingOnThisPulse)
		{
			PerformComponentRepairs(myUnit.Proficiency.Value);
			if (myUnit.IsFacility)
			{
				PerformStructuralRepairs(myUnit.Proficiency.Value);
			}
		}
	}

	public void PerformStructuralRepairs(GlobalVariables.ProficiencyLevel proficiencyLevel_0)
	{
		try
		{
			if ((int)FireIntensity > 1 || (int)FloodIntensity > 1 || !(myUnit.GetDamagePts() < (float)myUnit.InitialDP))
			{
				return;
			}
			float num = 100f - DamagePercent;
			switch (proficiencyLevel_0)
			{
			case GlobalVariables.ProficiencyLevel.Novice:
				num = (float)((double)num * 0.3);
				break;
			case GlobalVariables.ProficiencyLevel.Cadet:
				num = (float)((double)num * 0.5);
				break;
			case GlobalVariables.ProficiencyLevel.Regular:
				num = (float)((double)num * 0.8);
				break;
			case GlobalVariables.ProficiencyLevel.Veteran:
				num = (float)((double)num * 1.0);
				break;
			case GlobalVariables.ProficiencyLevel.Ace:
				num = (float)((double)num * 1.5);
				break;
			}
			if (num < 1f && GameGeneral.LockRandom_0.Next(0, 100) < (int)Math.Round(num * 100f))
			{
				num = 1f;
			}
			if (!((double)num >= 1.0) || !((float)GameGeneral.LockRandom_0.Next(0, 101) < num))
			{
				return;
			}
			ActiveUnit activeUnit;
			(activeUnit = myUnit).SetDamagePts(bool_0: false, null, activeUnit.GetDamagePts() + (float)((double)myUnit.InitialDP / 100.0));
			if (myUnit.GetDamagePts() < (float)myUnit.InitialDP)
			{
				myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "：结构损坏正在修复，现在在" + Conversions.ToString(Math.Round(myUnit.Damage.DamagePercent, 1)) + "%. ", myUnit.Name + " 正在修复中", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				return;
			}
			if (myUnit.GetDamagePts() > (float)myUnit.InitialDP)
			{
				myUnit.SetDamagePts(bool_0: false, null, myUnit.InitialDP);
			}
			myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "：结构完整性完全恢复！", myUnit.Name + " 返回100%", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100128", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PerformComponentRepairs(GlobalVariables.ProficiencyLevel proficiencyLevel_0)
	{
		try
		{
			float num = 100f - DamagePercent;
			switch (proficiencyLevel_0)
			{
			case GlobalVariables.ProficiencyLevel.Novice:
				num = (float)((double)num * 0.3);
				break;
			case GlobalVariables.ProficiencyLevel.Cadet:
				num = (float)((double)num * 0.5);
				break;
			case GlobalVariables.ProficiencyLevel.Regular:
				num = (float)((double)num * 0.8);
				break;
			case GlobalVariables.ProficiencyLevel.Veteran:
				num = (float)((double)num * 1.0);
				break;
			case GlobalVariables.ProficiencyLevel.Ace:
				num = (float)((double)num * 1.5);
				break;
			}
			foreach (PlatformComponent item in myUnit.OrderIssuer())
			{
				if (item.Status == PlatformComponent._ComponentStatus.Damaged)
				{
					PerformIndividualComponentRepair(num, item);
				}
			}
			if (myUnit.IsShip)
			{
				PerformIndividualComponentRepair(num, ((Ship)myUnit).CIC);
				PerformIndividualComponentRepair(num, ((Ship)myUnit).Rudder);
			}
			else if (myUnit.IsFacility)
			{
				PerformIndividualComponentRepair(num, ((Facility)myUnit).CIC);
			}
			else if (myUnit.IsSubmarine)
			{
				PerformIndividualComponentRepair(num, ((Submarine)myUnit).CIC);
				PerformIndividualComponentRepair(num, ((Submarine)myUnit).Rudder);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100128", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PerformIndividualComponentRepair(float float_0, PlatformComponent platformComponent_0)
	{
		if (platformComponent_0.Status != PlatformComponent._ComponentStatus.Damaged)
		{
			return;
		}
		switch (platformComponent_0.DamageSeverity)
		{
		case PlatformComponent._DamageSeverityFactor.Light:
			float_0 -= 10f;
			if ((float)GameGeneral.LockRandom_0.Next(1, 101) < float_0)
			{
				platformComponent_0.MakeOperational(bool_0: false);
				myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(platformComponent_0.Name) + "已经完全修好了。", myUnit.Name + " 受损组件已恢复", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
			break;
		case PlatformComponent._DamageSeverityFactor.Medium:
			if (!myUnit.IsOperating() || myUnit.IsFacility)
			{
				float_0 -= 20f;
				if ((float)GameGeneral.LockRandom_0.Next(1, 101) < float_0)
				{
					platformComponent_0.DamageSeverity = PlatformComponent._DamageSeverityFactor.Light;
					myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(platformComponent_0.Name) + "正在修复（轻微损坏）。", myUnit.Name + " 受损组件正在修复", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
			}
			break;
		case PlatformComponent._DamageSeverityFactor.Heavy:
			if (!myUnit.IsOperating() || myUnit.IsFacility)
			{
				float_0 -= 30f;
				if ((float)GameGeneral.LockRandom_0.Next(1, 101) < float_0)
				{
					platformComponent_0.DamageSeverity = PlatformComponent._DamageSeverityFactor.Medium;
					myUnit.ParentScen.AddMessage(Misc.ReadRequest(myUnit.Name) + "损坏报告：" + Misc.ReadRequest(platformComponent_0.Name) + "正在修复（中等毁伤）。", myUnit.Name + " 受损组件正在修复", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
			}
			break;
		}
	}

	public void method_0(float float_0)
	{
		if (myUnit.RemoteSimEntityType != 0 || float_0 == 0f || myUnit.IsUnderground || myUnit.IsUnderwater)
		{
			return;
		}
		if (myUnit.Sensors_ReadOnly().Length != 0 || myUnit.Comms_ReadOnly.Length != 0)
		{
			myUnit.AddMessage(myUnit.Name + " is being hit by an EMP wave or beam!", myUnit.Name + " 被击溃！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
		}
		new WeaponImpact(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude(), WeaponImpact.ImpactType.Electronic, 0);
		foreach (PlatformComponent item in myUnit.OrderIssuer())
		{
			item.vmethod_0(float_0);
		}
	}

	public void ResolveDamageFromDazzler(float float_0)
	{
		if (myUnit.RemoteSimEntityType != 0 || myUnit.IsUnderground || myUnit.IsUnderwater)
		{
			return;
		}
		if (myUnit.Sensors_ReadOnly().Length != 0 || myUnit.Comms_ReadOnly.Length != 0)
		{
			myUnit.AddMessage(myUnit.Name + " is being hit by a laser dazzler!", myUnit.Name + " dazzled!", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
		}
		if (myUnit.IsPlatform)
		{
			((Platform)myUnit).ResolveDamageFromDazzler(float_0);
		}
		foreach (PlatformComponent item in myUnit.OrderIssuer())
		{
			item.ResolveDamageFromDazzler(float_0);
		}
	}
}
