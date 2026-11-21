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

public sealed class Vehicle_Damage : ActiveUnit_Damage
{
	[CompilerGenerated]
	private sealed class PrinterConfigObject
	{
		public string Local_thePreferredAimpoint;

		internal bool NewInterruptibleParam(Mount theM)
		{
			return Operators.CompareString(theM.ObjectID, Local_thePreferredAimpoint, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ObserverCollectionTask
	{
		public Vehicle_Damage _003C_003E4__this;

		public Weapon theWeapon;

		internal bool PushInterruptibleParam(Mount theM)
		{
			return _003C_003E4__this.AimpointHasCompatibleEmitter(theM, theWeapon.ARM_SpecifiedEMission);
		}
	}

	private Vehicle managerProxy;

	private Vehicle AddReponse()
	{
		if (managerProxy == null)
		{
			managerProxy = (Vehicle)myUnit;
		}
		return managerProxy;
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
		xmlWriter_0.WriteEndElement();
	}

	public new static Vehicle_Damage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Vehicle_Damage vehicle_Damage = new Vehicle_Damage(ref activeUnit_0);
			vehicle_Damage.myUnit = activeUnit_0;
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
						vehicle_Damage._TimeToNextSecondaryDamageControl = Math.Abs(XmlConvert.ToSingle(xmlNode.InnerText.Replace(",", ".")));
						break;
					case "InitialDP":
						vehicle_Damage.myUnit.InitialDP = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Fire":
						vehicle_Damage._FireIntensity = (FireIntensityLevel)Conversions.ToByte(xmlNode.InnerText);
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
			return vehicle_Damage;
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
			Vehicle_Damage result = new Vehicle_Damage(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Vehicle_Damage(ref ActiveUnit activeUnit_0)
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
			switch (((Vehicle)myUnit).Armor_General)
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
			switch (((Vehicle)myUnit).Armor_General)
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
			switch (((Vehicle)myUnit).Armor_General)
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
			GlobalVariables.ArmorRating armor_General = ((Vehicle)myUnit).Armor_General;
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
		switch (((Vehicle)myUnit).Armor_General)
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
			double num = myUnit.GetDamagePts();
			Warhead warhead = weapon_0.Warheads[0];
			double num2 = 0.0;
			double num3;
			if (!warhead.GetIsNuclear(weapon_0.ParentScen) && !warhead.GetIsAirburst(weapon_0, myUnit) && !warhead.IsIncendiary)
			{
				num3 = weapon_0.CreateReponse(((Vehicle)myUnit).Armor_General, myUnit.VisualSizeClass) / 100f;
				num2 = weapon_0.ShockDamage_KE();
			}
			else
			{
				num3 = 0.0;
			}
			double num4 = 0.0;
			if (weapon_0.IsLaserShot)
			{
				num4 = 0.0;
				num2 = CalculateLaserImpactDamage(weapon_0, geoPoint_0);
			}
			float float_2 = ((myUnit.CurrentAltitude_AGL < 0f) ? myUnit.GetCurrentAltitude() : ((weapon_0.Warheads.Length == 0) ? myUnit.GetCurrentAltitude() : weapon_0.ImpactAltitude));
			bool flag = false;
			if (myUnit.AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Count() > 0)
			{
				flag = myUnit.AirFacilities_ReadOnly.Length != 0 && myUnit.AirFacilities_ReadOnly.Length == myUnit.AirFacilities_ReadOnly.Where((AirFacility AF) => AF.IsOpenAirFacility).Count();
			}
			if (Information.IsNothing(nullable_0) || Information.IsNothing(nullable_1))
			{
				double double_ = 0.0;
				double double_2 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref double_, ref double_2, float_0 / 1852f, float_1);
				nullable_0 = double_2;
				nullable_1 = double_;
			}
			if (num3 <= 0.0)
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
					myUnit.ParentScen.AddMessage("没有盔甲穿透！", "No penetration", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, myUnit, null, null, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
			}
			else
			{
				myUnit.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num3 * 100.0)) + "%渗透百分比", "Weapon penetration", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
				num4 = (flag ? ((num3 < 0.6 && !(warhead.DP >= 100f)) ? Math.Round(num3 * (double)warhead.DP / 8.0, 2) : ((num3 < 0.4 && !(warhead.DP >= 250f)) ? Math.Round(num3 * (double)warhead.DP / 2.0, 2) : ((!(num3 < 0.2) || warhead.DP >= 500f) ? Math.Round(num3 * 2.0 * (double)warhead.DP, 2) : Math.Round(num3 * (double)warhead.DP, 2)))) : (warhead.IsExplosive ? Math.Round(num3 * 2.0 * (double)warhead.DP, 2) : Math.Round(num3 * (double)warhead.DP, 2)));
				if (num3 < 1.0 && warhead.IsExplosive)
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, (float)((double)warhead.DP * (1.0 - num3)), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
				else if (((Vehicle)myUnit).Armor_General == GlobalVariables.ArmorRating.None && warhead.IsExplosive)
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, weapon_0.Type, (float)((double)warhead.DP * num3 * 0.25), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
				else
				{
					new Explosion(ref myUnit.ParentScen, myUnit.GetLongitude(), myUnit.GetLatitude(), nullable_1.Value, nullable_0.Value, weapon_0.CurrentHeading, float_2, (Weapon._WeaponType)0, (float)weapon_0.Type, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, myUnit, null, null, 0, 0, 0, 0f, weapon_0.ARM_SpecifiedEMission.Key);
				}
			}
			if (Math.Round(num4 + num2, 1) > 0.0)
			{
				myUnit.AddMessage(Misc.ReadRequest(myUnit.Name) + "遭受武器毁伤：" + Conversions.ToString(Math.Round(num4 + num2, 1)) + " DPs", myUnit.Name + "损伤", LoggedMessage.MessageType.UnitDamage, 1, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
			myUnit.SetDamagePts(bool_0: false, weapon_0, (float)((double)myUnit.GetDamagePts() - (num4 + num2)));
			ResolveComponentHits(warhead.Type, warhead.ExplosivesType, (float)(num4 + num2), (float)num, (float)num3, bool_0: false, (float)num3, weapon_0.ARM_SpecifiedEMission.Key);
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

	private void DestroyReponse(Weapon weapon_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0)
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
				IEnumerable<Mount> enumerable = ((Vehicle)myUnit).Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
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
						enumerable = ((Vehicle)myUnit).Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed);
					}
				}
			}
			else
			{
				string Local_thePreferredAimpoint = string_0;
				IEnumerable<Mount> source = ((Vehicle)myUnit).Mounts.Where((Mount theM) => Operators.CompareString(theM.ObjectID, Local_thePreferredAimpoint, TextCompare: false) == 0);
				if (source.Count() > 0)
				{
					source.ElementAtOrDefault(0).ResolveDamageFromWeapon(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, bool_0);
					flag = true;
				}
			}
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
			if (hasAimpoints = ((Vehicle)myUnit).HasAimpoints)
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
						DestroyReponse(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, ref string_0, bool_0);
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
					DestroyReponse(weapon_0, float_0, float_1, activeUnit_0, nullable_0, nullable_1, nullable_2, ref string_0, bool_0);
				}
				if (((Vehicle)myUnit).Mounts.Where((Mount theM) => theM.Status != PlatformComponent._ComponentStatus.Destroyed).Count() == 0 && !myUnit.IsDestroyed)
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
			if (((Vehicle)myUnit).Armor_General > GlobalVariables.ArmorRating.None)
			{
				return;
			}
			double num = myUnit.GetDamagePts();
			if (float_0 > 0f)
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
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Nearby fragmentation warhead detonated and destroyed the Vehicle.", "Weapon Interaction");
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

	public override void DoSecondaryDamage(float float_0)
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
				if (GameGeneral.LockRandom_0.Next(1, 101) <= 5)
				{
					myUnit.AddMessage(myUnit.Name + "倾覆 - 放弃船!!!", myUnit.Name + "正在下沉！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Vehicle capsizing", "Fire / Flooding");
					return;
				}
				break;
			}
			if (num + num2 > 0f)
			{
				myUnit.SetDamagePts(bool_0: false, null, myUnit.GetDamagePts() - (num + num2));
			}
			_TimeToNextSecondaryDamageControl -= float_0;
			if (_TimeToNextSecondaryDamageControl > 0f)
			{
				return;
			}
			if (!Module_Unit.ResetTokenizer(AddReponse()) && AddReponse().IsOutOfFuel)
			{
				Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(myUnit.ParentScen, myUnit.GetLatitude(), myUnit.GetLongitude(), 0);
				if (AddReponse().MaxSeaState < weatherAtThisTimeAndPlace.SeaState && GameGeneral.LockRandom_0.NextDouble() > 0.9)
				{
					myUnit.AddMessage(myUnit.Name + " is flooding due to excessive sea state!!!", myUnit.Name + "正在下沉！", LoggedMessage.MessageType.UnitDamage, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					myUnit.ParentScen.DestroyThisUnit(myUnit, "Vehicle flooded", "Fire / Flooding");
					return;
				}
			}
			if (num + num2 == 0f)
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
					goto IL_07fc;
				}
				if ((uint)(b - 1) > 3u)
				{
					if ((uint)(b - 9) <= 1u)
					{
						goto IL_07fc;
					}
				}
				else
				{
					FireIntensity = (FireIntensityLevel)Math.Max(0, (int)(FireIntensity - 1));
				}
			}
			goto IL_0827;
			IL_07fc:
			if (FireIntensity != FireIntensityLevel.Conflagration)
			{
				FireIntensity++;
			}
			goto IL_0827;
			IL_0ae8:
			_TimeToNextSecondaryDamageControl = GameGeneral.LockRandom_0.Next(60, 300);
			return;
			IL_0abd:
			if (FloodIntensity != FloodingIntensityLevel.Capsizing)
			{
				FloodIntensity++;
			}
			goto IL_0ae8;
			IL_0827:
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
					goto IL_0abd;
				}
				if ((uint)(b2 - 1) > 3u)
				{
					if ((uint)(b2 - 9) <= 1u)
					{
						goto IL_0abd;
					}
				}
				else
				{
					FloodIntensity = (FloodingIntensityLevel)Math.Max(0, (int)(FloodIntensity - 1));
				}
			}
			goto IL_0ae8;
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
