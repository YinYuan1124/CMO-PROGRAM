using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Damage : ActiveUnit_Damage
{
	private Aircraft reponseObserver;

	[SpecialName]
	private Aircraft GetAircraft()
	{
		if (Information.IsNothing(reponseObserver))
		{
			reponseObserver = (Aircraft)myUnit;
		}
		return reponseObserver;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Damage");
			if ((int)_FireIntensity > 0)
			{
				XmlWriter obj = xmlWriter_0;
				byte fireIntensity = (byte)_FireIntensity;
				obj.WriteElementString("Fire", fireIntensity.ToString());
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
			exception_?.Data.Add("Error at 100445", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_Damage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Aircraft_Damage aircraft_Damage = new Aircraft_Damage(ref activeUnit_0);
			aircraft_Damage.myUnit = activeUnit_0;
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
						aircraft_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "LastWeaponHit":
					{
						string innerText = Misc.StartRequest(xmlNode.ChildNodes[0].ChildNodes, "ID").InnerText;
						if (concurrentDictionary_0.ContainsKey(innerText))
						{
							aircraft_Damage.LastWeaponHit = (Weapon)concurrentDictionary_0[innerText];
							break;
						}
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						aircraft_Damage.LastWeaponHit = Weapon.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
						break;
					}
					case "Fire":
						aircraft_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
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
			return aircraft_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100446", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Aircraft_Damage result = new Aircraft_Damage(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Aircraft_Damage(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void ResolveDamageFromWeapon(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0)
	{
		if (!Module_Unit.AwakeTokenizer(myUnit))
		{
			if (!GetAircraft().IsAerostat && !GetAircraft().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage))
			{
				myUnit.ParentScen.DestroyThisUnit(myUnit, "Destroyed, hit by " + weapon_0.Name + " (" + weapon_0.ObjectID + ")", "Weapon Interaction");
			}
			else
			{
				string string_ = "";
				base.ResolveDamageFromWeapon(weapon_0, geoPoint_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, ref string_, bool_0);
			}
		}
	}

	protected override void ResolveDamageFromDirectImpact(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ref ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2)
	{
		try
		{
			if (weapon_0.Type == Weapon._WeaponType.LaserDazzler)
			{
				double num = Module_Unit.RangeToPoint_Slant(myUnit, geoPoint_0) / weapon_0.MaxRange_NoTargetType;
				double num7 = 1.0 - num;
				ResolveDamageFromDazzler((float)num7);
				return;
			}
			float damagePts = myUnit.GetDamagePts();
			double num8 = (weapon_0.IsGuidedWeapon() ? ((double)MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Module_Unit.BearingToUnit_True(myUnit, weapon_0))) : ((double)MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Module_Unit.BearingToPoint_True(myUnit, geoPoint_0.Latitude, geoPoint_0.Longitude))));
			Warhead warhead = weapon_0.Warheads[0];
			LockRandom lockRandom_ = GameGeneral.LockRandom_0;
			double num9 = 0.0;
			double num10 = warhead.DP;
			switch (weapon_0.TechGeneration)
			{
			case GlobalVariables.TechGenerationClass.Late1970s:
				num10 = (double)warhead.DP * 1.05;
				break;
			case GlobalVariables.TechGenerationClass.Early1980s:
				num10 = (double)warhead.DP * 1.1;
				break;
			case GlobalVariables.TechGenerationClass.Late1980s:
				num10 = (double)warhead.DP * 1.15;
				break;
			case GlobalVariables.TechGenerationClass.Early1990s:
				num10 = (double)warhead.DP * 1.2;
				break;
			case GlobalVariables.TechGenerationClass.Late1990s:
				num10 = (double)warhead.DP * 1.25;
				break;
			case GlobalVariables.TechGenerationClass.Early2000s:
				num10 = (double)warhead.DP * 1.3;
				break;
			case GlobalVariables.TechGenerationClass.Late2000s:
				num10 = (double)warhead.DP * 1.35;
				break;
			case GlobalVariables.TechGenerationClass.Early2010s:
				num10 = (double)warhead.DP * 1.4;
				break;
			case GlobalVariables.TechGenerationClass.Late2010s:
				num10 = (double)warhead.DP * 1.45;
				break;
			case GlobalVariables.TechGenerationClass.Early2020s:
				num10 = (double)warhead.DP * 1.5;
				break;
			case GlobalVariables.TechGenerationClass.Late2020s:
				num10 = (double)warhead.DP * 1.55;
				break;
			}
			if (!weapon_0.IsGuidedWeapon() && weapon_0.Flags.Fuze_Proximity)
			{
				int num11 = (int)Math.Round(GameGeneral.LockRandom_0.NextDouble() * 100.0);
				int num12;
				if (num11 <= 20)
				{
					num12 = 100;
					myUnit.AddMessage("Direct-hit of proximity-fuze warhead - full damage applied.", "Prox - Direct hit", LoggedMessage.MessageType.WeaponDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else if (num11 <= 40)
				{
					num12 = 80;
					myUnit.AddMessage("Near-miss of proximity-fuze warhead - 80% damage applied.", "Prox - Near miss", LoggedMessage.MessageType.WeaponDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else if (num11 <= 60)
				{
					num12 = 40;
					myUnit.AddMessage("Close miss of proximity-fuze warhead - 40% damage applied.", "Prox - Close miss", LoggedMessage.MessageType.WeaponDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else if (num11 <= 80)
				{
					num12 = 20;
					myUnit.AddMessage("Miss of proximity-fuze warhead - 20% damage applied.", "Prox - Miss", LoggedMessage.MessageType.WeaponDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else
				{
					num12 = 10;
					myUnit.AddMessage("Far miss of proximity-fuze warhead - 10% damage applied.", "Prox - Far miss", LoggedMessage.MessageType.WeaponDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				num10 = num10 * (double)num12 / 100.0;
			}
			double num13 = ((!weapon_0.IsUnguidedBallisticWeapon || (!UnguidedWeapon.IsSalvo(weapon_0.Name) && !UnguidedWeapon.IsBurst(weapon_0.Name))) ? num10 : ((double)(float)((double)lockRandom_.Next(1, 11) * 0.1 * num10)));
			if (weapon_0.IsLaserShot)
			{
				num13 = 0.0;
				num9 = CalculateLaserImpactDamage(weapon_0, geoPoint_0);
			}
			if (warhead.Type == Warhead.WarheadType.Kinetic || warhead.Type == Warhead.WarheadType.ArmorPiercing)
			{
				num9 = weapon_0.ShockDamage_KE();
			}
			string text = "";
			if (Operators.CompareString(GetAircraft().Name, GetAircraft().UnitClass, TextCompare: false) != 0)
			{
				text = " (" + GetAircraft().UnitClass + ")";
			}
			float num14 = (GetAircraft().IsAerostat ? ((float)lockRandom_.NextDouble()) : (weapon_0.CreateReponse(GetAircraft().Armor_Fuselage, myUnit.VisualSizeClass) / 100f));
			LastWeaponHit = weapon_0;
			if (num14 > 0f)
			{
				if (WillBeDestroyedByPenetration())
				{
					myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + text + "遭受压力舱的渗透 - 在半空中分裂！", myUnit.Name + " 被摧毁！", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					GetAircraft().ParentScen.DestroyThisUnit(GetAircraft(), Misc.ReadRequest(myUnit.Name) + text + " suffered penetration on pressurized cabin - Disintegrating in mid-air! hit by " + weapon_0.Name + " (" + weapon_0.ObjectID + ")", "Weapon Interaction");
					myUnit.SetDamagePts(bool_0: false, null, 0f);
				}
				else
				{
					double num2 = (double)num14 * (num13 + num9);
					myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + text + "遭受武器毁伤：" + Conversions.ToString(Math.Round(num2, 2)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					myUnit.SetDamagePts(bool_0: false, null, (float)((double)myUnit.GetDamagePts() - num2));
					if (myUnit.GetDamagePts() > 0f)
					{
						double num3 = num2 / 40.0;
						if (lockRandom_.NextDouble() < num3)
						{
							myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + text + "它的飞行控制被击倒 - 正在下降！", myUnit.Name + " 被摧毁！", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							GetAircraft().ParentScen.DestroyThisUnit(GetAircraft(), Misc.ReadRequest(myUnit.Name) + text + " has its flight controls knocked out - going down! hit by " + weapon_0.Name + " (" + weapon_0.ObjectID + ")", "Weapon Interaction");
							myUnit.SetDamagePts(bool_0: false, null, 0f);
						}
					}
				}
			}
			if (myUnit.GetDamagePts() > 0f)
			{
				double num4 = 0.0;
				if (GetAircraft().Crew == 0)
				{
					num4 = 0.0;
				}
				else
				{
					switch (GetAircraft().Size)
					{
					case GlobalVariables.AircraftSizeClass.Medium:
						num4 = 0.3;
						break;
					case GlobalVariables.AircraftSizeClass.Small:
						num4 = 0.4;
						break;
					case GlobalVariables.AircraftSizeClass.VLarge:
						num4 = 0.1;
						break;
					case GlobalVariables.AircraftSizeClass.Large:
						num4 = 0.2;
						break;
					}
				}
				if (weapon_0.IsUnguidedBallisticWeapon)
				{
					num4 = (float)(num4 * 0.2);
				}
				double num5 = num8;
				if (num5 < 45.0)
				{
					num4 *= 1.5;
				}
				else if (num5 >= 135.0)
				{
					if (num5 < 225.0)
					{
						num4 *= 0.5;
					}
					else if (num5 >= 315.0)
					{
						num4 *= 1.5;
					}
				}
				if (GetAircraft().Crew > 0 && lockRandom_.NextDouble() < num4)
				{
					num14 = weapon_0.CreateReponse(GetAircraft().Armor_Cockpit, myUnit.VisualSizeClass) / 100f;
					myUnit.AddMessage("驾驶舱命中 - 渗透" + Conversions.ToString(num14 * 100f) + "%", "命中座舱", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
					if ((double)num14 > 0.5)
					{
						myUnit.AddMessage("驾驶舱和机组人员丧失能力 - 飞机失控！", myUnit.Name + " 被摧毁！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
						GetAircraft().ParentScen.DestroyThisUnit(GetAircraft(), "Cockpit & crew incapacitated - aircraft is out of control! hit by " + weapon_0.Name + " (" + weapon_0.ObjectID + ")", "Weapon Interaction");
						return;
					}
				}
				float num6 = 0f;
				switch (GetAircraft().Size)
				{
				case GlobalVariables.AircraftSizeClass.Small:
					num6 = 0.5f;
					break;
				case GlobalVariables.AircraftSizeClass.UAS_Class1_Micro:
				case GlobalVariables.AircraftSizeClass.UAS_Class1_Mini:
				case GlobalVariables.AircraftSizeClass.UAS_Class1_Small:
				case GlobalVariables.AircraftSizeClass.UAS_Class2:
					num6 = 0.7f;
					break;
				case GlobalVariables.AircraftSizeClass.VLarge:
					num6 = 0.1f;
					break;
				case GlobalVariables.AircraftSizeClass.Large:
					num6 = 0.2f;
					break;
				case GlobalVariables.AircraftSizeClass.Medium:
					num6 = 0.3f;
					break;
				}
				if (weapon_0.IsUnguidedBallisticWeapon)
				{
					num6 = (float)((double)num6 * 0.2);
				}
				if (lockRandom_.NextDouble() < (double)num6)
				{
					num14 = weapon_0.CreateReponse(GetAircraft().Armor_Powerplant, myUnit.VisualSizeClass) / 100f;
					myUnit.AddMessage("引擎命中 - 渗透" + Conversions.ToString(num14 * 100f) + "%", "命中引擎", LoggedMessage.MessageType.UnitLost, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
					if ((double)num14 > 0.5)
					{
						IEnumerable<Engine> source = GetAircraft().Propulsion.Where((Engine theE) => theE.Status == PlatformComponent._ComponentStatus.Operational);
						if (source.Count() > 0)
						{
							Engine engine = source.ElementAtOrDefault(lockRandom_.Next(0, source.Count()));
							engine.Destroy(GetAircraft().GetUnitSide(), bool_0: false, bool_1: false);
							myUnit.AddMessage("发动机" + engine.Name + "已被摧毁！", myUnit.Name + " 被摧毁！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(GetAircraft().GetLongitude(), GetAircraft().GetLatitude()));
						}
					}
				}
				ResolveComponentHits(warhead.Type, warhead.ExplosivesType, num13 + num9, damagePts, num14, bool_0: false, num14, weapon_0.ARM_SpecifiedEMission.Key);
			}
			ResolveProximityDamageToHostedUnits(bool_0: true);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100447", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DetermineSecondaryDamage(float float_0, Warhead.WarheadType warheadType_0, float float_1)
	{
		try
		{
			if (float_0 > 0f)
			{
				double num = float_0 / myUnit.GetDamagePts();
				num = 0.3;
				switch (warheadType_0)
				{
				case Warhead.WarheadType.Fragmentation_ABM:
					num += 0.4;
					break;
				case Warhead.WarheadType.Fragmentation:
				case Warhead.WarheadType.ContinuousRod:
					num += 0.2;
					break;
				}
				if (num >= 0.9)
				{
					num = 0.9;
				}
				double num2 = num;
				float num3 = (float)(num - 0.1);
				float num4 = (float)(num - 0.2);
				double num5 = GameGeneral.LockRandom_0.NextDouble();
				if (num5 < (double)num4)
				{
					CauseFire(FireIntensityLevel.Severe);
				}
				else if (num5 < (double)num3)
				{
					CauseFire(FireIntensityLevel.Major);
				}
				else if (num5 < num2)
				{
					CauseFire(FireIntensityLevel.Minor);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100554", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	private bool WillBeDestroyedByPenetration()
	{
		if (GetAircraft().GetCurrentAltitude() < 3657.6f)
		{
			return false;
		}
		switch (GetAircraft().Type)
		{
		default:
			return false;
		case Aircraft._AircraftType.AirborneLaserPlatform:
		case Aircraft._AircraftType.OECM:
		case Aircraft._AircraftType.AEW:
		case Aircraft._AircraftType.AirborneCP:
		case Aircraft._AircraftType.SAR:
		case Aircraft._AircraftType.ASW:
		case Aircraft._AircraftType.MPA:
		case Aircraft._AircraftType.ForwardObserver:
		case Aircraft._AircraftType.AreaSurveillance:
		case Aircraft._AircraftType.Recon:
		case Aircraft._AircraftType.ELINT:
		case Aircraft._AircraftType.SIGINT:
		case Aircraft._AircraftType.Transport:
		case Aircraft._AircraftType.Cargo:
		case Aircraft._AircraftType.Commercial:
		case Aircraft._AircraftType.Civilian:
		case Aircraft._AircraftType.Tanker:
		case Aircraft._AircraftType.AirShip:
		case Aircraft._AircraftType.AeroStat:
			return true;
		}
	}

	public override void ResolveDamageFromFrag(float float_0, float float_1, int int_0 = 0)
	{
		if (myUnit.RemoteSimEntityType != 0)
		{
			return;
		}
		try
		{
			if (GetAircraft().IsAerostat)
			{
				base.ResolveDamageFromFrag(float_0, float_1);
				if (myUnit.GetDamagePts() <= 0f)
				{
					myUnit.SetDamagePts(bool_0: false, null, 0f);
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Fragmentation warhead detonated nearby", "Weapon Interaction");
				}
			}
			else
			{
				myUnit.ParentScen.DestroyThisUnit(myUnit, "Fragmentation warhead detonated nearby", "Weapon Interaction");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100448", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ResolveDamageFromBlast(float float_0, Warhead.WarheadType warheadType_0, Warhead.WarheadExplosivesType warheadExplosivesType_0, Weapon.DetonationMedium detonationMedium_0)
	{
		if (myUnit.RemoteSimEntityType != 0)
		{
			return;
		}
		try
		{
			if (float_0 >= 2f)
			{
				if (GetAircraft().IsAerostat)
				{
					base.ResolveDamageFromBlast(float_0, warheadType_0, warheadExplosivesType_0, detonationMedium_0);
				}
				else
				{
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Blast warhead detonated nearby", "Weapon Interaction");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100449", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void UnderwayRepairs(float float_0)
	{
	}

	public override void DoSecondaryDamage(float float_0)
	{
		if (!GetAircraft().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage))
		{
			return;
		}
		try
		{
			float num = 0f;
			switch (FireIntensity)
			{
			case FireIntensityLevel.Minor:
				num = (float)((double)myUnit.InitialDP * 0.2 * (double)(float_0 / 3600f));
				break;
			case FireIntensityLevel.Major:
				num = (float)((double)myUnit.InitialDP * 0.4 * (double)(float_0 / 3600f));
				break;
			case FireIntensityLevel.Severe:
				num = (float)((double)myUnit.InitialDP * 0.8 * (double)(float_0 / 3600f));
				break;
			case FireIntensityLevel.Conflagration:
				num = (float)myUnit.InitialDP * (float_0 / 3600f);
				if (GameGeneral.LockRandom_0.Next(1, 101) <= 5)
				{
					myUnit.AddMessage(myUnit.Name + "有燃料爆炸，正在解体！", myUnit.Name + " 被摧毁！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					myUnit.ParentScen.DestroyThisUnit(myUnit, myUnit.Name + "有燃料爆炸，正在解体！", "Fire / Flooding");
					return;
				}
				break;
			}
			if (num > 0f)
			{
				myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - num);
			}
			if (myUnit.Damage.DamagePercent <= 80f)
			{
				if (!GetAircraft().ParentScen.FifthSecondIsChangingOnThisPulse || FireIntensity == FireIntensityLevel.NoFire)
				{
					return;
				}
				byte b = (byte)GameGeneral.LockRandom_0.Next(1, 11);
				GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
				int? num2 = (int?)proficiency;
				if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					b += 3;
				}
				else
				{
					num2 = (int?)proficiency;
					if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						b += 2;
					}
					else
					{
						num2 = (int?)proficiency;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
						{
							b++;
						}
						else
						{
							num2 = (int?)proficiency;
							if (!(num2.HasValue ? new bool?(num2.GetValueOrDefault() == 3) : null).GetValueOrDefault())
							{
								num2 = (int?)proficiency;
								if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 4) : null).GetValueOrDefault())
								{
									b = (byte)Math.Max(0, b - 2);
								}
							}
						}
					}
				}
				b = (byte)Math.Max(0, (int)b);
				if (b <= 10)
				{
					switch (b)
					{
					default:
						return;
					case 1:
					case 2:
					case 3:
					case 4:
						FireIntensity = (FireIntensityLevel)Math.Max(0, (int)(FireIntensity - 1));
						return;
					case 5:
					case 6:
					case 7:
					case 8:
						return;
					case 9:
					case 10:
						break;
					}
				}
				else
				{
					b = 10;
				}
				if (FireIntensity != FireIntensityLevel.Conflagration)
				{
					FireIntensity++;
				}
			}
			else
			{
				myUnit.AddMessage(myUnit.Name + " 超过80%机身受损，已解体！！！", myUnit.Name + " 被摧毁！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				myUnit.ParentScen.DestroyThisUnit(myUnit, myUnit.Name + " 超过80%机身受损，已解体！！！", "Fire / Flooding");
			}
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
}
