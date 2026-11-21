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

public sealed class Facility_Damage : ActiveUnit_Damage
{
	[CompilerGenerated]
	private sealed class ComposerDecoratorEntry
	{
		public string Local_thePreferredAimpoint;

		internal bool FillInterruptibleField(Mount theM)
		{
			return Operators.CompareString(theM.ObjectID, Local_thePreferredAimpoint, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ModelDecoratorEntry
	{
		public Facility_Damage _003C_003E4__this;

		public Weapon theWeapon;

		internal bool CalculateInterruptibleField(Mount theM)
		{
			return _003C_003E4__this.AimpointHasCompatibleEmitter(theM, theWeapon.ARM_SpecifiedEMission);
		}
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
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

	public new static Facility_Damage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Facility_Damage facility_Damage = new Facility_Damage(ref activeUnit_0);
			facility_Damage.myUnit = activeUnit_0;
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
						facility_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "LastWeaponHit":
					{
						string innerText = Misc.StartRequest(xmlNode.ChildNodes[0].ChildNodes, "ID").InnerText;
						if (concurrentDictionary_0.ContainsKey(innerText))
						{
							facility_Damage.LastWeaponHit = (Weapon)concurrentDictionary_0[innerText];
							break;
						}
						XmlNode xmlNode_ = xmlNode.ChildNodes[0];
						facility_Damage.LastWeaponHit = Weapon.FromXML(ref xmlNode_, ref concurrentDictionary_0, ref activeUnit_0.ParentScen);
						break;
					}
					case "InitialDP":
						facility_Damage.myUnit.InitialDP = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Fire":
						facility_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
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
			return facility_Damage;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100553", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Facility_Damage result = new Facility_Damage(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Facility_Damage(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void DetermineSecondaryDamage(float float_0, Warhead.WarheadType warheadType_0, float float_1)
	{
		try
		{
			if (float_0 <= 0f)
			{
				return;
			}
			double num = float_0 / myUnit.GetDamagePts();
			if (float_1 > 0f)
			{
				switch (warheadType_0)
				{
				case Warhead.WarheadType.Incendiary:
					num = 8.0 * num;
					break;
				case Warhead.WarheadType.AntiElectrical:
					num = 2.0 * num;
					break;
				case Warhead.WarheadType.Chemical:
				case Warhead.WarheadType.Biological:
					num = 0.0;
					break;
				}
				num *= (double)float_1;
			}
			if (num >= 0.9)
			{
				num = 0.9;
			}
			double num2 = num;
			float num3 = (float)(num * 0.3);
			float num4 = (float)(num * 0.1);
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

	public override void AdjustBombletDamageForArmor(ref float float_0, Warhead.WarheadType warheadType_0)
	{
		switch (warheadType_0)
		{
		case Warhead.WarheadType.Cluster_AP:
			switch (((Facility)myUnit).Armor_General)
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
			switch (((Facility)myUnit).Armor_General)
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
			switch (((Facility)myUnit).Armor_General)
			{
			case GlobalVariables.ArmorRating.Light:
				float_0 = 2f * float_0;
				break;
			case GlobalVariables.ArmorRating.Medium:
				float_0 = float_0;
				break;
			case GlobalVariables.ArmorRating.Heavy:
				float_0 = (float)(0.75 * (double)float_0);
				break;
			case GlobalVariables.ArmorRating.Special:
				float_0 = (float)(0.5 * (double)float_0);
				break;
			case GlobalVariables.ArmorRating.None:
				float_0 = 3f * float_0;
				break;
			}
			break;
		case Warhead.WarheadType.SuperFrag:
		{
			GlobalVariables.ArmorRating armor_General = ((Facility)myUnit).Armor_General;
			if (armor_General != GlobalVariables.ArmorRating.None && armor_General != GlobalVariables.ArmorRating.Light)
			{
				float_0 = 0f;
			}
			break;
		}
		}
	}

	public override void AdjustBlastDamageForArmor(ref float float_0)
	{
		switch (((Facility)myUnit).Armor_General)
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
			double num3 = myUnit.GetDamagePts();
			Warhead warhead = weapon_0.Warheads[0];
			double num4 = 0.0;
			double num5;
			if (!warhead.GetIsNuclear(weapon_0.ParentScen) && !warhead.GetIsAirburst(weapon_0, myUnit) && !warhead.IsIncendiary)
			{
				num5 = weapon_0.CreateReponse(((Facility)myUnit).Armor_General, myUnit.VisualSizeClass) / 100f;
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
			float float_2 = ((myUnit.CurrentAltitude_AGL < 0f) ? myUnit.GetCurrentAltitude() : ((weapon_0.Warheads.Length == 0) ? myUnit.GetCurrentAltitude() : weapon_0.ImpactAltitude));
			if (weapon_0.Warheads[0].Type == Warhead.WarheadType.HardTargetPenetrator)
			{
				Facility._FacilityCategory category = ((Facility)myUnit).Category;
				if (category == Facility._FacilityCategory.Building_Underground || category == Facility._FacilityCategory.SurfaceAndUnderground)
				{
					float_2 = (float)myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen) - 10f;
				}
			}
			bool flag = false;
			if (myUnit.AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Count() > 0)
			{
				flag = myUnit.AirFacilities_ReadOnly.Length != 0 && myUnit.AirFacilities_ReadOnly.Length == myUnit.AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Count();
			}
			if (!nullable_0.HasValue || !nullable_1.HasValue)
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_, ref double_2, float_0 / 1852f, float_1);
				nullable_0 = double_2;
				nullable_1 = double_;
			}
			if (num5 <= 0.0)
			{
				if (warhead.IsExplosive)
				{
					if (warhead.GetIsAirburst(weapon_0, myUnit))
					{
						new Explosion(ref myUnit.ParentScen, nullable_1.Value, nullable_0.Value, nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, myUnit.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, myUnit.ParentScen), weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
					}
					else
					{
						new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
					}
				}
				else
				{
					myUnit.ParentScen.AddMessage("没有盔甲穿透！", myUnit.Name + " - 无装甲穿透", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
			}
			else
			{
				myUnit.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num5 * 100.0)) + "%渗透百分比", myUnit.Name + " - 装甲穿透", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				num6 = (flag ? ((num5 < 0.6 && !(warhead.DP >= 100f)) ? Math.Round(num5 * (double)warhead.DP / 8.0, 2) : ((num5 < 0.4 && !(warhead.DP >= 250f)) ? Math.Round(num5 * (double)warhead.DP / 2.0, 2) : ((!(num5 < 0.2) || warhead.DP >= 500f) ? Math.Round(num5 * 2.0 * (double)warhead.DP, 2) : Math.Round(num5 * (double)warhead.DP, 2)))) : (warhead.IsExplosive ? Math.Round(num5 * 2.0 * (double)warhead.DP, 2) : Math.Round(num5 * (double)warhead.DP, 2)));
				if (num5 < 1.0 && warhead.IsExplosive)
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, (float)((double)warhead.DP * (1.0 - num5)), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
				else if (((Facility)myUnit).Armor_General == GlobalVariables.ArmorRating.None && warhead.IsExplosive)
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, (float)((double)warhead.DP * num5 * 0.25), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
				else
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, (Weapon._WeaponType)0, (float)weapon_0.Type, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
			}
			if (Math.Round(num6 + num4, 1) > 0.0)
			{
				myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + "遭受武器毁伤：" + Conversions.ToString(Math.Round(num6 + num4, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
			myUnit.SetDamagePts(bool_0: false, weapon_0, (float)((double)myUnit.GetDamagePts() - (num6 + num4)));
			ResolveComponentHits(warhead.Type, warhead.ExplosivesType, (float)(num6 + num4), (float)num3, (float)num5, bool_0: false, (float)num5, weapon_0.ARM_SpecifiedEMission.Key);
			ResolveProximityDamageToHostedUnits(bool_0: false);
			RaiseEvent_DamageSustained();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100555", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReadBridge(Weapon weapon_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0)
	{
		if (Debugger.IsAttached)
		{
			_ = nullable_0.HasValue;
			_ = nullable_1.HasValue;
		}
		try
		{
			bool flag = false;
			if (string.IsNullOrEmpty(string_0))
			{
				IEnumerable<Mount> enumerable = ((Facility)myUnit).Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
				if (weapon_0.Warheads.Length <= 1)
				{
					if (enumerable.Count() > 0)
					{
						int num = GameGeneral.LockRandom_0.Next(1, enumerable.Count());
						enumerable.ElementAtOrDefault(num - 1).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0);
						if (!Information.IsNothing(enumerable) && enumerable.Count() > 0 && enumerable.Count() >= num)
						{
							string_0 = enumerable.ElementAtOrDefault(num - 1).ObjectID;
						}
						flag = true;
					}
				}
				else
				{
					int num2 = weapon_0.Warheads.Length - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (enumerable.Count() > 0)
						{
							int num3 = GameGeneral.LockRandom_0.Next(1, enumerable.Count());
							enumerable.ElementAtOrDefault(num3 - 1).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0);
							if (!Information.IsNothing(enumerable) && enumerable.Count() > 0 && enumerable.Count() >= num3)
							{
								string_0 = enumerable.ElementAtOrDefault(num3 - 1).ObjectID;
							}
							flag = true;
						}
						enumerable = ((Facility)myUnit).Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
					}
				}
			}
			else
			{
				string Local_thePreferredAimpoint = string_0;
				IEnumerable<Mount> source = ((Facility)myUnit).Mounts.Where((Mount theM) => Operators.CompareString(theM.ObjectID, Local_thePreferredAimpoint, TextCompare: false) == 0);
				if (source.Count() > 0)
				{
					source.ElementAtOrDefault(0).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0);
					flag = true;
				}
			}
			myUnit.Damage.LastWeaponHit = weapon_0;
			if (!flag)
			{
				if (Information.IsNothing(nullable_0))
				{
					nullable_0 = myUnit.GetLatitude();
				}
				if (Information.IsNothing(nullable_1))
				{
					nullable_1 = myUnit.GetLongitude();
				}
				if (Information.IsNothing(nullable_2))
				{
					nullable_2 = myUnit.GetLandElevation(bool_0: true, bool_1: false, bool_2: false, myUnit.ParentScen);
				}
				ResolveDamageFromWeapon_CreateExplosion(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100556", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void ResolveDamageFromWeapon(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0)
	{
		if (Module_Unit.AwakeTokenizer(myUnit))
		{
			return;
		}
		try
		{
			bool hasAimpoints;
			if (hasAimpoints = ((Facility)myUnit).HasAimpoints)
			{
				if (!hasAimpoints)
				{
					return;
				}
				_ = (double)myUnit.Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed).Count() / (double)myUnit.Mounts.Count;
				if (weapon_0.ValidTargets.Radar)
				{
					IEnumerable<Mount> source = myUnit.Mounts.Where((Mount theM) => AimpointHasCompatibleEmitter(theM, weapon_0.ARM_SpecifiedEMission));
					if (source.Count() <= 0)
					{
						ReadBridge(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, ref string_0, bool_0);
					}
					else
					{
						IEnumerable<Mount> source2 = source.Where((Mount theM) => theM.HasEmittingSensors);
						if (source2.Count() <= 0)
						{
							int num = GameGeneral.LockRandom_0.Next(1, source.Count());
							source.ElementAtOrDefault(num - 1).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0);
						}
						else if (source2.Count() == 1)
						{
							source2.ElementAtOrDefault(0).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0);
						}
						else
						{
							int num2 = GameGeneral.LockRandom_0.Next(1, source2.Count());
							source2.ElementAtOrDefault(num2 - 1).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0);
						}
					}
				}
				else
				{
					ReadBridge(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, ref string_0, bool_0);
				}
				if (((Facility)myUnit).Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed).Count() == 0 && !myUnit.IsDestroyed)
				{
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Unit destroyed, final weapon: " + weapon_0.Name + " (" + weapon_0.ObjectID + ")", "Weapon Interaction");
				}
			}
			else
			{
				base.ResolveDamageFromWeapon(weapon_0, geoPoint_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, ref string_0, bool_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100557", "");
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
			Facility facility = (Facility)myUnit;
			if (facility.Armor_General > GlobalVariables.ArmorRating.None)
			{
				return;
			}
			double num = myUnit.GetDamagePts();
			if (float_0 > 0f)
			{
				if (facility.Category == Facility._FacilityCategory.Building_Reveted)
				{
					float_0 *= 0.9f;
				}
				new WeaponImpact(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), myUnit.GetCurrentAltitude(), WeaponImpact.ImpactType.Kinetic, 0);
				myUnit.AddMessage(myUnit.Name + "遭受了碎片毁伤：" + Conversions.ToString(Math.Round(float_0, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - float_0);
				ResolveComponentHits(Warhead.WarheadType.Fragmentation, Warhead.WarheadExplosivesType.Fragmentation, float_0, (float)num, 0f, bool_0: true, 0f);
				ResolveProximityDamageToHostedUnits(bool_0: true);
				RaiseEvent_DamageSustained();
				if (myUnit.GetDamagePts() <= 0f)
				{
					myUnit.SetDamagePts(bool_0: false, null, 0f);
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Nearby fragmentation warhead detonated and destroyed the facility.", "Weapon Interaction");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100558", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
