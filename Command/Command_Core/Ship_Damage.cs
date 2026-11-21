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

public sealed class Ship_Damage : ActiveUnit_Damage
{
	[CompilerGenerated]
	private sealed class InitializerItem
	{
		public Weapon Local_theWeapon;

		internal bool PrintInterruptibleReg(Sensor theS)
		{
			if (theS.IsActive)
			{
				if (theS.DBID != Local_theWeapon.ARM_SpecifiedEMission.Key)
				{
					return theS.classFacade == Local_theWeapon.ARM_SpecifiedEMission.Key;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ValCollectionTask
	{
		public Warhead Local_theWarhead;

		internal bool DefineInterruptibleReg(Warhead theWH)
		{
			return theWH != Local_theWarhead;
		}
	}

	private Ship _PrinterFacade;

	[SpecialName]
	private Ship GetParentPlatform()
	{
		if (Information.IsNothing(_PrinterFacade))
		{
			_PrinterFacade = (Ship)myUnit;
		}
		return _PrinterFacade;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Ship_Damage");
			if ((int)FireIntensity > 0)
			{
				xmlWriter_0.WriteElementString("Fire", ((byte)FireIntensity).ToString());
			}
			if ((int)FloodIntensity > 0)
			{
				xmlWriter_0.WriteElementString("Flood", ((byte)FloodIntensity).ToString());
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
			exception_?.Data.Add("Error at 100783", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Ship_Damage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		Ship_Damage result = null;
		try
		{
			Ship_Damage ship_Damage = new Ship_Damage(ref activeUnit_0);
			ship_Damage.myUnit = activeUnit_0;
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
						ship_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "LastWeaponHit":
						if (xmlNode.ChildNodes.Count > 0)
						{
							string innerText = Misc.StartRequest(xmlNode.ChildNodes[0].ChildNodes, "ID").InnerText;
							if (concurrentDictionary_0.ContainsKey(innerText))
							{
								ship_Damage.LastWeaponHit = (Weapon)concurrentDictionary_0[innerText];
								break;
							}
							XmlNode xmlNode_ = xmlNode.ChildNodes[0];
							ship_Damage.LastWeaponHit = Weapon.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
						}
						break;
					case "InitialDP":
						ship_Damage.myUnit.InitialDP = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Flood":
						ship_Damage._FloodIntensity = (FloodingIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "Fire":
						ship_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
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
			result = ship_Damage;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100784", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Ship_Damage(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void AdjustBombletDamageForArmor(ref float float_0, Warhead.WarheadType warheadType_0)
	{
		switch (warheadType_0)
		{
		case Warhead.WarheadType.Cluster_AP:
			switch (((Ship)myUnit).Armor_Belt)
			{
			case GlobalVariables.ArmorRating.Light:
				float_0 = (float)(0.5 * (double)float_0);
				break;
			default:
				float_0 = 0f;
				break;
			case GlobalVariables.ArmorRating.None:
				break;
			}
			break;
		case Warhead.WarheadType.Cluster_AT:
		case Warhead.WarheadType.Cluster_SmartSubs:
			switch (((Ship)myUnit).Armor_Belt)
			{
			default:
				float_0 = 0f;
				break;
			case GlobalVariables.ArmorRating.Medium:
				float_0 = (float)(0.5 * (double)float_0);
				break;
			case GlobalVariables.ArmorRating.Light:
				float_0 = (float)(0.7 * (double)float_0);
				break;
			case GlobalVariables.ArmorRating.None:
				break;
			}
			break;
		case Warhead.WarheadType.Cluster_Penetrator:
			switch (((Ship)myUnit).Armor_Belt)
			{
			case GlobalVariables.ArmorRating.Light:
				float_0 = (float)(0.9 * (double)float_0);
				break;
			case GlobalVariables.ArmorRating.Medium:
				float_0 = (float)(0.7 * (double)float_0);
				break;
			case GlobalVariables.ArmorRating.Heavy:
				float_0 = (float)(0.5 * (double)float_0);
				break;
			case GlobalVariables.ArmorRating.Special:
				float_0 = (float)(0.2 * (double)float_0);
				break;
			}
			break;
		}
	}

	public override void AdjustBlastDamageForArmor(ref float float_0)
	{
		switch (((Ship)myUnit).Armor_Belt)
		{
		case GlobalVariables.ArmorRating.Light:
			float_0 = (float)(0.9 * (double)float_0);
			break;
		case GlobalVariables.ArmorRating.Medium:
			float_0 = (float)(0.6 * (double)float_0);
			break;
		case GlobalVariables.ArmorRating.Heavy:
			float_0 = (float)(0.3 * (double)float_0);
			break;
		case GlobalVariables.ArmorRating.Special:
			float_0 = (float)(0.1 * (double)float_0);
			break;
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
			float damagePts = myUnit.GetDamagePts();
			Warhead Local_theWarhead = weapon_0.Warheads[0];
			float num3;
			double num4;
			if (!Local_theWarhead.GetIsNuclear(weapon_0.ParentScen) && !Local_theWarhead.GetIsAirburst(weapon_0, GetParentPlatform()))
			{
				num3 = weapon_0.CreateReponse(((Ship)myUnit).Armor_Belt, myUnit.VisualSizeClass) / 100f;
				num4 = weapon_0.ShockDamage_KE();
			}
			else
			{
				num3 = 0f;
				num4 = 0.0;
			}
			double num5 = 0.0;
			if (weapon_0.IsLaserShot)
			{
				num5 = 0.0;
				num4 = CalculateLaserImpactDamage(weapon_0, geoPoint_0);
			}
			float float_2 = (weapon_0.IsMissile ? ((float)weapon_0.GetOptimumBurstHeight_AGL(GetParentPlatform())) : 0f);
			float num6 = Local_theWarhead.DP;
			foreach (Warhead item in weapon_0.Warheads.Where((Warhead theWH) => theWH != Local_theWarhead).ToList())
			{
				Weapon carriedWeapon = item.GetCarriedWeapon(weapon_0.ParentScen);
				if (carriedWeapon != null && carriedWeapon.Warheads.Length != 0)
				{
					num6 += item.GetCarriedWeapon(weapon_0.ParentScen).Warheads[0].DP;
				}
			}
			if (weapon_0.ValidTargets.Radar && !Information.IsNothing(weapon_0.ARM_SpecifiedEMission))
			{
				IEnumerable<Sensor> source = myUnit.Sensors_Cached.Where((Sensor theS) => theS.IsActive && (theS.DBID == weapon_0.ARM_SpecifiedEMission.Key || theS.classFacade == weapon_0.ARM_SpecifiedEMission.Key));
				if (source.Count() > 0)
				{
					int index = GameGeneral.LockRandom_0.Next(0, source.Count());
					DetermineComponentDamage(weapon_0.Warheads[0].Type, weapon_0.Warheads[0].ExplosivesType, source.ElementAtOrDefault(index), num6, damagePts, weapon_0.ARM_SpecifiedEMission.Key, num3);
				}
			}
			if (!nullable_0.HasValue || !nullable_1.HasValue)
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_, ref double_2, float_0 / 1852f, float_1);
				nullable_0 = double_2;
				nullable_1 = double_;
			}
			if (num3 <= 0f)
			{
				if (Local_theWarhead.IsExplosive)
				{
					if (Local_theWarhead.GetIsAirburst(weapon_0, GetParentPlatform()))
					{
						new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, num6, Local_theWarhead.DP, Local_theWarhead.Type, Local_theWarhead.ExplosivesType, null, null, null, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
					}
					else
					{
						new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, num6, Local_theWarhead.DP, Local_theWarhead.Type, Local_theWarhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
					}
				}
				else
				{
					myUnit.ParentScen.AddMessage("没有护甲穿透力", "没有护甲穿透力", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, num6, Local_theWarhead.DP, Local_theWarhead.Type, Local_theWarhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
			}
			else
			{
				myUnit.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num3 * 100f)) + "%渗透百分比", myUnit.Name + " - armor penetrated", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				num5 = ((!Local_theWarhead.IsExplosive) ? ((double)(float)Math.Round(num3 * num6, 2)) : ((Local_theWarhead.Type != Warhead.WarheadType.Torpedo) ? ((double)(float)Math.Round(num3 * 2f * num6, 2)) : (weapon_0.Flags.Torpedo_StraightRunning ? ((double)num6) : ((double)num6 + (double)num6 * GameGeneral.LockRandom_0.NextDouble() * 3.0))));
				if (num3 < 1f && Local_theWarhead.IsExplosive)
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, num6 * (1f - num3), Local_theWarhead.DP, Local_theWarhead.Type, Local_theWarhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
				else if (((Ship)myUnit).Armor_Bulkhead == GlobalVariables.ArmorRating.None && Local_theWarhead.IsExplosive)
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, (float)((double)(num6 * num3) * 0.25), Local_theWarhead.DP, Local_theWarhead.Type, Local_theWarhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
			}
			if (Math.Round(num5 + num4, 1) > 0.0)
			{
				myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + "遭受武器毁伤：" + Conversions.ToString(Math.Round(num5 + num4, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
			myUnit.SetDamagePts(bool_0: false, weapon_0, (float)((double)myUnit.GetDamagePts() - (num5 + num4)));
			ResolveComponentHits(Local_theWarhead.Type, Local_theWarhead.ExplosivesType, num5 + num4, damagePts, num3, bool_0: false, num3, weapon_0.ARM_SpecifiedEMission.Key);
			ResolveProximityDamageToHostedUnits(bool_0: false);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100785", "");
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
				switch (GetParentPlatform().Category)
				{
				default:
					throw new NotImplementedException();
				case Ship._ShipCategory.Amphibious:
					num4 = (float)(1.5 * num4);
					num5 = (float)(1.5 * num5);
					break;
				case Ship._ShipCategory.Auxiliary:
				case Ship._ShipCategory.Merchant:
				case Ship._ShipCategory.Civilian:
				case Ship._ShipCategory.MobileOffshoreBase:
					num4 = 2.0 * num4;
					num5 = 2.0 * num5;
					break;
				case Ship._ShipCategory.AviationShip:
				case Ship._ShipCategory.SurfaceCombatant:
				case Ship._ShipCategory.SurfaceCombatantAviation:
					break;
				}
				num4 *= (double)float_1;
				num5 *= (double)float_1;
			}
			if ((uint)(warheadType_0 - 6001) <= 2u || warheadType_0 == Warhead.WarheadType.Cluster_SmartSubs)
			{
				num4 = Math.Max(0.7, num4);
			}
			foreach (Engine item in ((Ship)myUnit).Propulsion)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					num5 *= 1.3;
				}
			}
			if (num4 >= 0.9)
			{
				num4 = 0.9;
			}
			if (num5 >= 0.9)
			{
				num5 = 0.9;
			}
			double num6 = num4;
			float num7 = (float)(num4 * 0.3);
			float num8 = (float)(num4 * 0.1);
			double num9 = GameGeneral.LockRandom_0.NextDouble();
			if (num9 < (double)num8)
			{
				CauseFire(FireIntensityLevel.Severe);
			}
			else if (num9 < (double)num7)
			{
				CauseFire(FireIntensityLevel.Major);
			}
			else if (num9 < num6)
			{
				CauseFire(FireIntensityLevel.Minor);
			}
			double num10 = num5;
			float num11 = (float)(num4 * 0.3);
			float num2 = (float)(num4 * 0.1);
			double num3 = GameGeneral.LockRandom_0.NextDouble();
			if (num3 < (double)num2)
			{
				CauseFlooding(FloodingIntensityLevel.Severe);
			}
			else if (num3 < (double)num11)
			{
				CauseFlooding(FloodingIntensityLevel.Major);
			}
			else if (num3 < num10)
			{
				CauseFlooding(FloodingIntensityLevel.Minor);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100785", "");
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
		if (myUnit.RemoteSimEntityType == Module_Unit.Unit.RemoteSimEntityTypeEnum.Local)
		{
			base.ResolveDamageFromFrag(float_0, float_1, int_0);
		}
	}

	public override ComponentHitType ResolveComponentHitType(Warhead warhead_0)
	{
		int num = GameGeneral.LockRandom_0.Next(1, 101);
		switch (warhead_0.Type)
		{
		default:
			switch (((Ship)myUnit).Category)
			{
			case Ship._ShipCategory.AviationShip:
			case Ship._ShipCategory.MobileOffshoreBase:
				if (num <= 10)
				{
					return ComponentHitType.Mount;
				}
				if (num <= 20)
				{
					return ComponentHitType.FlightDeck;
				}
				if (num <= 40)
				{
					return ComponentHitType.Hangar;
				}
				if (num <= 50)
				{
					return ComponentHitType.Sensor;
				}
				if (num <= 60)
				{
					return ComponentHitType.Flooding;
				}
				if (num <= 70)
				{
					return ComponentHitType.Fire;
				}
				if (num <= 80)
				{
					return ComponentHitType.Engineering;
				}
				if (num <= 90)
				{
					return ComponentHitType.CIC;
				}
				return ComponentHitType.Rudder;
			default:
				if (num <= 30)
				{
					return ComponentHitType.Mount;
				}
				if (num <= 50)
				{
					return ComponentHitType.Sensor;
				}
				if (num <= 60)
				{
					return ComponentHitType.Flooding;
				}
				if (num <= 70)
				{
					return ComponentHitType.Fire;
				}
				if (num <= 80)
				{
					return ComponentHitType.Engineering;
				}
				if (num <= 90)
				{
					return ComponentHitType.CIC;
				}
				return ComponentHitType.Rudder;
			case Ship._ShipCategory.Auxiliary:
				if (num <= 10)
				{
					return ComponentHitType.Mount;
				}
				if (num <= 30)
				{
					return ComponentHitType.Cargo;
				}
				if (num <= 50)
				{
					return ComponentHitType.Flooding;
				}
				if (num <= 70)
				{
					return ComponentHitType.Fire;
				}
				if (num <= 80)
				{
					return ComponentHitType.Engineering;
				}
				if (num <= 90)
				{
					return ComponentHitType.CIC;
				}
				return ComponentHitType.Rudder;
			case Ship._ShipCategory.Merchant:
				if (num <= 10)
				{
					return ComponentHitType.Mount;
				}
				if (num <= 30)
				{
					return ComponentHitType.Cargo;
				}
				if (num <= 50)
				{
					return ComponentHitType.Flooding;
				}
				if (num <= 70)
				{
					return ComponentHitType.Fire;
				}
				if (num <= 80)
				{
					return ComponentHitType.Engineering;
				}
				if (num <= 90)
				{
					return ComponentHitType.CIC;
				}
				return ComponentHitType.Rudder;
			}
		case Warhead.WarheadType.Torpedo:
			if (num <= 10)
			{
				return ComponentHitType.Mount;
			}
			if (num <= 50)
			{
				return ComponentHitType.Flooding;
			}
			if (num <= 60)
			{
				return ComponentHitType.Sonar;
			}
			if (num <= 90)
			{
				return ComponentHitType.Engineering;
			}
			return ComponentHitType.Rudder;
		case Warhead.WarheadType.Fragmentation:
		{
			Ship._ShipCategory category = ((Ship)myUnit).Category;
			if (category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.MobileOffshoreBase)
			{
				if (num <= 30)
				{
					return ComponentHitType.Sensor;
				}
				if (num <= 50)
				{
					return ComponentHitType.Mount;
				}
				if (num <= 80)
				{
					return ComponentHitType.Mount;
				}
				if (num <= 90)
				{
					return ComponentHitType.FlightDeck;
				}
				return ComponentHitType.CIC;
			}
			if (num <= 30)
			{
				return ComponentHitType.Sensor;
			}
			if (num <= 50)
			{
				return ComponentHitType.Mount;
			}
			if (num <= 80)
			{
				return ComponentHitType.FlightDeck;
			}
			if (num <= 90)
			{
				return ComponentHitType.FlightDeck;
			}
			return ComponentHitType.CIC;
		}
		}
	}

	protected override void DetermineDamageResult(ComponentHitType componentHitType_0)
	{
		try
		{
			switch (componentHitType_0)
			{
			case ComponentHitType.Mount:
			{
				PlatformComponent platformComponent = DetermineComponentThatIsHit(componentHitType_0);
				if (platformComponent != null && platformComponent.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					platformComponent.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
					myUnit.ParentScen.AddMessage("Mount: " + platformComponent.Name + "已被摧毁！", myUnit.Name + " 损失了一个挂架/武器", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				break;
			}
			case ComponentHitType.Flooding:
				myUnit.ParentScen.AddMessage(myUnit.Name + " is flooding!", myUnit.Name + " is flooding!", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				break;
			case ComponentHitType.Fire:
				myUnit.ParentScen.AddMessage(myUnit.Name + " is on fire!", myUnit.Name + " is on fire!", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				break;
			case ComponentHitType.Engineering:
			{
				Engine engine = (Engine)DetermineComponentThatIsHit(componentHitType_0);
				if (engine != null && engine.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					engine.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
					myUnit.ParentScen.AddMessage("供电设备：" + engine.Name + "已被摧毁！", myUnit.Name + " lost an engine", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				break;
			}
			case ComponentHitType.CIC:
				((Ship)myUnit).CIC.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
				break;
			case ComponentHitType.Rudder:
				((Ship)myUnit).Rudder.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
				myUnit.ParentScen.AddMessage("Rudder has been destroyed!", myUnit.Name + " lost its rudder", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				break;
			case ComponentHitType.FlightDeck:
			case ComponentHitType.Hangar:
			{
				AirFacility airFacility = (AirFacility)DetermineComponentThatIsHit(componentHitType_0);
				if (airFacility != null && airFacility.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					airFacility.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
					myUnit.ParentScen.AddMessage("Air Facility: " + airFacility.Name + "已被摧毁！", myUnit.Name + " lost an air facility", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				break;
			}
			case ComponentHitType.Cargo:
				throw new NotImplementedException();
			case ComponentHitType.Sensor:
			case ComponentHitType.Sonar:
			{
				Sensor sensor = (Sensor)DetermineComponentThatIsHit(componentHitType_0);
				if (sensor != null && sensor.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					sensor.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
					myUnit.ParentScen.AddMessage("Sensor: " + sensor.Name + "已被摧毁！", myUnit.Name + " 损失了一个传感器", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				break;
			}
			case ComponentHitType.Magazine:
			{
				Magazine magazine = (Magazine)DetermineComponentThatIsHit(componentHitType_0);
				if (magazine != null && magazine.Status != PlatformComponent._ComponentStatus.Destroyed)
				{
					magazine.Destroy(myUnit.GetUnitSide(), bool_0: false, bool_1: false);
					myUnit.ParentScen.AddMessage("Magazine: " + magazine.Name + "已被摧毁！", myUnit.Name + " lost a shared magazine", LoggedMessage.MessageType.UnitDamage, 5, myUnit.ObjectID, myUnit.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				}
				break;
			}
			case ComponentHitType.PressureHull:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100787", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
