using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Damage : ActiveUnit_Damage
{
	private Submarine configurationProxy;

	public override FireIntensityLevel FireIntensity
	{
		get
		{
			return base.FireIntensity;
		}
		set
		{
			bool num = value != FireIntensity;
			base.FireIntensity = value;
			if (num && (int)FireIntensity > 1)
			{
				myUnit.AddMessage(myUnit.Name + "由于火灾，必须紧急上升到潜望镜的深度！", myUnit.Name + " 紧急上浮blowing", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
		}
	}

	public override FloodingIntensityLevel FloodIntensity
	{
		get
		{
			return base.FloodIntensity;
		}
		set
		{
			bool num = value != FloodIntensity;
			base.FloodIntensity = value;
			if (num && (int)FloodIntensity > 1)
			{
				myUnit.AddMessage(myUnit.Name + "因漏水而必须紧急浮出水面！", myUnit.Name + " 紧急上浮blowing", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
		}
	}

	[SpecialName]
	private Submarine GetParentPlatform()
	{
		if (configurationProxy == null)
		{
			configurationProxy = (Submarine)myUnit;
		}
		return configurationProxy;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		xmlWriter_0.WriteStartElement("Submarine_Damage");
		if ((int)_FireIntensity > 0)
		{
			XmlWriter obj = xmlWriter_0;
			byte fireIntensity = (byte)_FireIntensity;
			obj.WriteElementString("Fire", fireIntensity.ToString());
		}
		if ((int)_FloodIntensity > 0)
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

	public new static Submarine_Damage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Submarine_Damage submarine_Damage = new Submarine_Damage(ref activeUnit_0);
			submarine_Damage.myUnit = activeUnit_0;
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
						submarine_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "LastWeaponHit":
					{
						string innerText = Misc.StartRequest(xmlNode.ChildNodes[0].ChildNodes, "ID").InnerText;
						if (concurrentDictionary_0.ContainsKey(innerText))
						{
							submarine_Damage.LastWeaponHit = (Weapon)concurrentDictionary_0[innerText];
							break;
						}
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						submarine_Damage.LastWeaponHit = Weapon.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
						break;
					}
					case "InitialDP":
						submarine_Damage.myUnit.InitialDP = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Flood":
						submarine_Damage._FloodIntensity = (FloodingIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "Fire":
						submarine_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
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
			return submarine_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100828", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Submarine_Damage result = new Submarine_Damage(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Submarine_Damage(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void ResolveDamageFromWeapon(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0)
	{
		if (Module_Unit.AwakeTokenizer(myUnit))
		{
			return;
		}
		try
		{
			if (weapon_0.Warheads.Length == 0)
			{
				return;
			}
			Warhead warhead = weapon_0.Warheads[0];
			if (weapon_0.Warheads[0].Type == Warhead.WarheadType.Weapon)
			{
				warhead = weapon_0.Warheads[0].GetCarriedWeapon(weapon_0.ParentScen).Warheads[0];
			}
			if (float_0 == 0f)
			{
				ResolveDamageFromDirectImpact(weapon_0, geoPoint_0, float_0, float_1, ref activeUnit_0, nullable_0, nullable_1, nullable_2);
			}
			else if (warhead.IsExplosive || warhead.IsIncendiary)
			{
				if (!nullable_0.HasValue || !nullable_1.HasValue)
				{
					double double_ = 0.0;
					double double_2 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_, ref double_2, float_0 / 1852f, float_1);
					nullable_0 = double_2;
					nullable_1 = double_;
				}
				if (Terrain.GetElevation(nullable_0.Value, nullable_1.Value, bool_0: false, myUnit.ParentScen) <= 0)
				{
					new WaterSplash(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, Explosion.GetCutoffRange_Blast_nm(warhead.DP, Weapon.DetonationMedium.Underwater));
				}
				if (!nullable_2.HasValue)
				{
					nullable_2 = (weapon_0.IsTorpedo ? new float?((int)Math.Round(weapon_0.GetCurrentAltitude())) : (weapon_0.IsMissile ? new float?((int)Math.Round(myUnit.GetCurrentAltitude() + (float)weapon_0.GetOptimumBurstHeight_AGL(myUnit))) : ((weapon_0.Type == Weapon._WeaponType.DepthCharge || (weapon_0.Warheads[0].Type == Warhead.WarheadType.Weapon && weapon_0.Warheads[0].GetCarriedWeapon(myUnit.ParentScen).Type == Weapon._WeaponType.DepthCharge)) ? new float?((int)Math.Round(Math.Max(-100.0, (double)Terrain.GetElevation(nullable_0.Value, nullable_1.Value, bool_0: false, myUnit.ParentScen) / 2.0))) : new float?(Math.Max(0, (int)Terrain.GetElevation(nullable_0.Value, nullable_1.Value, bool_0: false, myUnit.ParentScen))))));
				}
				new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, nullable_2.Value, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, activeUnit_0, null, null, 0, 0);
			}
			myUnit.Damage.LastWeaponHit = weapon_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100829", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void AdjustBombletDamageForArmor(ref float float_0, Warhead.WarheadType warheadType_0)
	{
		switch (warheadType_0)
		{
		case Warhead.WarheadType.Cluster_AP:
			float_0 = (float)(0.5 * (double)float_0);
			break;
		case Warhead.WarheadType.Cluster_AT:
		case Warhead.WarheadType.Cluster_SmartSubs:
			float_0 = (float)(0.7 * (double)float_0);
			break;
		case Warhead.WarheadType.Cluster_Penetrator:
			float_0 = (float)(0.9 * (double)float_0);
			break;
		case Warhead.WarheadType.SuperFrag:
			float_0 = (float)(0.6 * (double)float_0);
			break;
		}
	}

	public override void DetermineSecondaryDamage(float float_0, Warhead.WarheadType warheadType_0, float float_1)
	{
		try
		{
			if (float_0 <= 0f)
			{
				return;
			}
			float num = float_0 / myUnit.GetDamagePts();
			double num4 = num;
			double num5 = num;
			if (float_1 > 0f)
			{
				switch (warheadType_0)
				{
				case Warhead.WarheadType.Torpedo_ASWOptimized:
					num5 = 100.0;
					num4 = 4.0 * num4;
					break;
				case Warhead.WarheadType.Torpedo:
					num5 = 4.0 * num5;
					break;
				case Warhead.WarheadType.Incendiary:
					num4 = 8.0 * num4;
					num5 = 0.0;
					break;
				case Warhead.WarheadType.AntiElectrical:
					num4 = 2.0 * num4;
					break;
				case Warhead.WarheadType.Chemical:
				case Warhead.WarheadType.Biological:
					num4 = 0.0;
					num5 = 0.0;
					break;
				}
				num4 *= (double)float_1;
				num5 *= (double)float_1;
			}
			if (GetParentPlatform().Flags.UsesLiOnBattery)
			{
				num4 *= 2.0;
			}
			if (num4 >= 0.95)
			{
				num4 = 0.95;
			}
			if (num5 >= 0.95)
			{
				num5 = 0.95;
			}
			double num6 = num4;
			float num7 = (float)(num4 * 0.3);
			float num8 = (float)(num4 * 0.1);
			double num9 = (double)GameGeneral.LockRandom_0.Next(1, 101) / 100.0;
			if (num9 < (double)num8)
			{
				switch (GetParentPlatform().Damage.FireIntensity)
				{
				default:
					CauseFire(FireIntensityLevel.Severe);
					break;
				case FireIntensityLevel.Severe:
					CauseFire(FireIntensityLevel.Conflagration);
					break;
				case FireIntensityLevel.Conflagration:
					break;
				}
			}
			else if (num9 < (double)num7)
			{
				switch (GetParentPlatform().Damage.FireIntensity)
				{
				default:
					CauseFire(FireIntensityLevel.Major);
					break;
				case FireIntensityLevel.Major:
					CauseFire(FireIntensityLevel.Severe);
					break;
				case FireIntensityLevel.Severe:
				case FireIntensityLevel.Conflagration:
					break;
				}
			}
			else if (num9 < num6)
			{
				switch (GetParentPlatform().Damage.FireIntensity)
				{
				default:
					CauseFire(FireIntensityLevel.Minor);
					break;
				case FireIntensityLevel.Minor:
					CauseFire(FireIntensityLevel.Major);
					break;
				case FireIntensityLevel.Major:
				case FireIntensityLevel.Severe:
				case FireIntensityLevel.Conflagration:
					break;
				}
			}
			double num10 = num5;
			float num11 = (float)(num5 * 0.3);
			float num2 = (float)(num5 * 0.1);
			double num3 = (double)GameGeneral.LockRandom_0.Next(1, 101) / 100.0;
			if (num3 < (double)num2)
			{
				switch (GetParentPlatform().Damage.FloodIntensity)
				{
				default:
					CauseFlooding(FloodingIntensityLevel.Severe);
					break;
				case FloodingIntensityLevel.Severe:
					CauseFlooding(FloodingIntensityLevel.Capsizing);
					break;
				case FloodingIntensityLevel.Capsizing:
					break;
				}
			}
			else if (num3 < (double)num11)
			{
				switch (GetParentPlatform().Damage.FloodIntensity)
				{
				default:
					CauseFlooding(FloodingIntensityLevel.Major);
					break;
				case FloodingIntensityLevel.Major:
					CauseFlooding(FloodingIntensityLevel.Severe);
					break;
				case FloodingIntensityLevel.Severe:
				case FloodingIntensityLevel.Capsizing:
					break;
				}
			}
			else if (num3 < num10)
			{
				switch (GetParentPlatform().Damage.FloodIntensity)
				{
				default:
					CauseFlooding(FloodingIntensityLevel.Minor);
					break;
				case FloodingIntensityLevel.Minor:
					CauseFlooding(FloodingIntensityLevel.Major);
					break;
				case FloodingIntensityLevel.Major:
				case FloodingIntensityLevel.Severe:
				case FloodingIntensityLevel.Capsizing:
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100830", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override void ResolveDamageFromDirectImpact(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ref ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2)
	{
		try
		{
			if (weapon_0.Type == Weapon._WeaponType.LaserDazzler)
			{
				double num = Module_Unit.RangeToPoint_Slant(myUnit, geoPoint_0) / weapon_0.MaxRange_NoTargetType;
				double num2 = 1.0 - num;
				ResolveDamageFromDazzler((float)num2);
				return;
			}
			double num3 = myUnit.GetDamagePts();
			if (weapon_0.Warheads[0].Type == Warhead.WarheadType.Weapon)
			{
				weapon_0 = weapon_0.Warheads[0].GetCarriedWeapon(weapon_0.ParentScen);
			}
			Warhead warhead = weapon_0.Warheads[0];
			double num4 = 0.0;
			double num5;
			if (!warhead.GetIsNuclear(weapon_0.ParentScen) && !warhead.GetIsAirburst(weapon_0, myUnit))
			{
				num5 = ((myUnit.GetCurrentAltitude() == 0f || warhead.Type == Warhead.WarheadType.HEAT || warhead.Type == Warhead.WarheadType.Torpedo_ASWOptimized) ? ((double)(weapon_0.CreateReponse(GlobalVariables.ArmorRating.Heavy, myUnit.VisualSizeClass) / 100f)) : 0.0);
				if (((Submarine)myUnit).Flags.DoubleHull)
				{
					Warhead warhead2 = weapon_0.Warheads.FirstOrDefault();
					if (warhead2 != null && warhead2.Type != Warhead.WarheadType.Torpedo_ASWOptimized)
					{
						num5 *= 0.5;
					}
				}
				num4 = weapon_0.ShockDamage_KE();
			}
			else
			{
				num5 = 0.0;
			}
			double num6 = 0.0;
			if (weapon_0.IsLaserShot)
			{
				num6 = 0.0;
				num4 = CalculateLaserImpactDamage(weapon_0, geoPoint_0);
			}
			if (num5 <= 0.0)
			{
				if (!warhead.IsExplosive && !warhead.IsIncendiary)
				{
					myUnit.ParentScen.AddMessage("没有盔甲穿透！", "没有盔甲穿透！", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else
				{
					if (!nullable_0.HasValue || !nullable_1.HasValue)
					{
						double double_ = 0.0;
						double double_2 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_, ref double_2, (float)(((double)GetParentPlatform().Beam * 0.5 + 2.0) * 0.000539957), GameGeneral.LockRandom_0.Next(0, 360));
						nullable_0 = double_2;
						nullable_1 = double_;
					}
					if (warhead.GetIsAirburst(weapon_0, myUnit))
					{
						new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, myUnit.GetCurrentAltitude(), weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0);
					}
					else
					{
						new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, myUnit.GetCurrentAltitude(), weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0);
					}
				}
			}
			else
			{
				myUnit.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num5 * 100.0)) + "%渗透百分比", myUnit.Name + " - armor penetrated", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				num6 = Math.Round(num5 * (double)warhead.DP, 2);
				if (num5 < 1.0 && warhead.IsExplosive)
				{
					double double_3 = 0.0;
					double double_4 = 0.0;
					Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_3, ref double_4, (float)(((double)GetParentPlatform().Beam * 0.5 + 2.0) * 0.000539957), GameGeneral.LockRandom_0.Next(0, 360));
					nullable_0 = double_4;
					nullable_1 = double_3;
					new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, myUnit.GetCurrentAltitude(), weapon_0.Type, (float)((double)warhead.DP * (1.0 - num5)), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0);
				}
				else if (!warhead.IsExplosive && !warhead.IsIncendiary)
				{
					myUnit.ParentScen.AddMessage("没有盔甲穿透！", "没有盔甲穿透！", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				else
				{
					if (!nullable_0.HasValue || !nullable_1.HasValue)
					{
						ActiveUnit activeUnit = myUnit;
						bool? nullable_3 = null;
						double double_5 = activeUnit.GetLongitude(nullable_3);
						ActiveUnit activeUnit2 = myUnit;
						bool? nullable_4 = null;
						double double_6 = activeUnit2.GetLatitude(nullable_4);
						int int_ = GameGeneral.LockRandom_0.Next((int)Math.Round(warhead.DP / 2f), (int)Math.Round(warhead.DP * 2f));
						int int_2 = GameGeneral.LockRandom_0.Next(0, 360);
						double double_7 = 0.0;
						double double_8 = 0.0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_5, ref double_6, ref double_7, ref double_8, ref int_, ref int_2);
						activeUnit2.SetLatitude(nullable_4, double_6);
						activeUnit.SetLongitude(nullable_3, double_5);
						nullable_0 = double_8;
						nullable_1 = double_7;
					}
					if (warhead.GetIsAirburst(weapon_0, myUnit))
					{
						new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, myUnit.GetCurrentAltitude(), weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0);
					}
					else
					{
						new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, myUnit.CurrentHeading, myUnit.GetCurrentAltitude(), weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0);
					}
				}
			}
			if (Math.Round(num6 + num4, 1) > 0.0)
			{
				myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + "遭受武器毁伤：" + Conversions.ToString((int)Math.Round(num6 + num4)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
			myUnit.SetDamagePts(bool_0: false, weapon_0, (float)((double)myUnit.GetDamagePts() - (num6 + num4)));
			ResolveComponentHits(warhead.Type, warhead.ExplosivesType, (float)(num6 + num4), (float)num3, (float)num5, bool_0: false, weapon_0.ARM_SpecifiedEMission.Key);
			ResolveProximityDamageToHostedUnits(bool_0: false);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100831", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
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
			double num = myUnit.GetDamagePts();
			if (Math.Round(float_0, 1) > 0.0)
			{
				new WeaponImpact(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
				myUnit.AddMessage(myUnit.Name + "遭受了碎片毁伤：" + Conversions.ToString(Math.Round(float_0, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - float_0);
				ResolveComponentHits(Warhead.WarheadType.Fragmentation, Warhead.WarheadExplosivesType.Fragmentation, float_0, (float)num, 0f, bool_0: true, 0f);
				ResolveProximityDamageToHostedUnits(bool_0: true);
				RaiseEvent_DamageSustained();
				if (myUnit.GetDamagePts() <= 0f)
				{
					myUnit.SetDamagePts(bool_0: false, null, 0f);
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Nearby fragmentation warhead detonated and destroyed the submarine.", "Weapon Interaction");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100832", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
