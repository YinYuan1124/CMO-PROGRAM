using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using CSMaterial;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Warhead : ScenarioObject
{
	public enum WarheadType
	{
		None = 1001,
		HE_BlastFrag = 2001,
		ArmorPiercing = 2002,
		HEAT = 2003,
		Incendiary = 2004,
		Fragmentation = 2005,
		SemiAP = 2006,
		HESH = 2007,
		ContinuousRod = 2008,
		HardTargetPenetrator = 2009,
		FAE = 2010,
		SuperFrag = 2011,
		Fragmentation_ABM = 2012,
		Torpedo = 3001,
		DepthCharge = 3002,
		Torpedo_ASWOptimized = 3003,
		Nuclear = 4001,
		Chemical = 4011,
		Biological = 4021,
		Weapon = 5002,
		Aircraft = 5003,
		Ship = 5004,
		Submarine = 5005,
		GroundUnit = 5006,
		Satellite = 5007,
		Cluster_AP = 6001,
		Cluster_AT = 6002,
		Cluster_Penetrator = 6003,
		Cluster_SmartSubs = 6012,
		Landmine_AP = 7001,
		Landmine_AT = 7002,
		LongRodPenetrator = 8001,
		AntiElectrical = 9001,
		Leaflet = 9002,
		Laser_COIL = 9101,
		Laser_CarbonDioxide = 9102,
		Laser_DeuteriumFluoride = 9103,
		Laser_SolidStateFiber = 9104,
		EMP_Directed = 9201,
		EMP_Omni = 9202,
		Kinetic = 9801
	}

	public enum _LaserType
	{
		None,
		Chemical,
		SolidState
	}

	public enum WarheadExplosivesType : short
	{
		None = 1001,
		HE_TNT = 2001,
		HE_HMX = 2002,
		HE_PETN = 2003,
		HE_RDX = 2004,
		HE_C4 = 2005,
		HE_Tritonal = 2006,
		HE_Ammonite = 2007,
		HE_Trinitrophenol = 2008,
		HE_Torpex = 2009,
		HE_Dynamite = 2010,
		HE_PBXN_1XX = 2011,
		HE_AFX_757 = 2012,
		HE_Minol2 = 2013,
		HE_H6 = 2014,
		HE_Destex = 2015,
		HE_Minol1 = 2016,
		HE_HBX1 = 2017,
		HE_HBX3 = 2018,
		HE_Hexanite = 2019,
		HE_Hexamine = 2020,
		HE_Minol3 = 2021,
		HE_Minol4 = 2022,
		HE_PBX = 2023,
		Incendiary_Napalm = 2101,
		Incendiary_WP = 2102,
		Incendiary_FAE = 2103,
		HEAT_LightArmor = 2201,
		HEAT_MediumArmor = 2202,
		HEAT_HeavyArmor = 2203,
		HEAT_SpecialArmor = 2204,
		Fragmentation = 2301,
		ContinuousRod = 2401,
		Nuclear = 4001,
		Chemical = 4011,
		Bacteriological = 4012,
		Submunitions_AntiPersonnel_Fragmentation = 6001,
		Submunitions_AntiTank_LightArmor = 6002,
		Submunitions_AntiTank_MediumArmor = 6003,
		Submunitions_AntiTank_HeavyArmor = 6004,
		Submunitions_AntiTank_SpecialArmor = 6005,
		Submunitions_AntiRunwayPenetrator = 6011,
		Mine_AntiPersonnel_Fragmentation = 7011,
		Mine_AntiTank_LightArmor = 7012,
		Mine_AntiTank_MediumArmor = 7013,
		Mine_AntiTank_HeavyArmor = 7014,
		Mine_AntiTank_SpecialArmor = 7015,
		LongRodPenetrator_LightArmor = 8001,
		LongRodPenetrator_MediumArmor = 8002,
		LongRodPenetrator_HeavyArmor = 8003,
		LongRodPenetrator_SpecialArmor = 8004,
		AntiElectrical_ConductiveFiber = 9001,
		Leaflets = 9002,
		LaserEnergy = 9101,
		KineticEnergy = 9801,
		WeaponPayload = 9998
	}

	public enum WarheadCaliber : short
	{
		None = 1001,
		Gun_6_15mm = 2001,
		Gun_16_24mm = 2002,
		Gun_25_60mm = 2003,
		Gun_61_80mm = 2004,
		Gun_81_150mm = 2005,
		Gun_151_200mm = 2006,
		Gun_201_350mm = 2007,
		Gun_351_450mm = 2008,
		Rocket_6_15mm = 3001,
		Rocket_16_24mm = 3002,
		Rocket_25_60mm = 3003,
		Rocket_61_80mm = 3004,
		Rocket_81_150mm = 3005,
		Rocket_151_200mm = 3006,
		Rocket_201_350mm = 3007,
		Rocket_351_450mm = 3008
	}

	public const float HardTargetPenetratorDepth = 10f;

	public int DBID;

	public float DP;

	public WarheadType Type;

	public WarheadExplosivesType ExplosivesType;

	public WarheadCaliber Caliber;

	public short NumberOfWarheads;

	public float ExplosivesWeight;

	public short ClusterBombDispersionAreaLength;

	public short ClusterBombDispersionAreaWidth;

	public bool Hypothetical;

	private Weapon callbackReader;

	public bool IsAreaEffect
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case WarheadType.Fragmentation:
			case WarheadType.FAE:
			case WarheadType.SuperFrag:
			case WarheadType.Nuclear:
			case WarheadType.Chemical:
			case WarheadType.Biological:
			case WarheadType.Cluster_AP:
			case WarheadType.Cluster_AT:
			case WarheadType.Cluster_Penetrator:
			case WarheadType.Cluster_SmartSubs:
			case WarheadType.AntiElectrical:
				return true;
			}
		}
	}

	public bool IsAreaEffect_Conventional
	{
		get
		{
			if (!IsAreaEffect)
			{
				switch (Type)
				{
				default:
					return false;
				case WarheadType.Fragmentation:
				case WarheadType.FAE:
				case WarheadType.SuperFrag:
				case WarheadType.Chemical:
				case WarheadType.Cluster_AP:
				case WarheadType.Cluster_AT:
				case WarheadType.Cluster_Penetrator:
				case WarheadType.Cluster_SmartSubs:
				case WarheadType.AntiElectrical:
					return true;
				}
			}
			return true;
		}
	}

	public bool IsExplosive
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case WarheadType.HE_BlastFrag:
			case WarheadType.HEAT:
			case WarheadType.Fragmentation:
			case WarheadType.SemiAP:
			case WarheadType.HESH:
			case WarheadType.ContinuousRod:
			case WarheadType.HardTargetPenetrator:
			case WarheadType.FAE:
			case WarheadType.Fragmentation_ABM:
			case WarheadType.Torpedo:
			case WarheadType.DepthCharge:
			case WarheadType.Torpedo_ASWOptimized:
			case WarheadType.Nuclear:
			case WarheadType.Landmine_AP:
			case WarheadType.Landmine_AT:
				return true;
			}
		}
	}

	public bool IsIncendiary
	{
		get
		{
			if (Type == WarheadType.Incendiary)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsCluster
	{
		get
		{
			WarheadType type = Type;
			if (type != WarheadType.SuperFrag && (uint)(type - 6001) > 2u && type != WarheadType.Cluster_SmartSubs)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsEMP
	{
		get
		{
			if (Type == WarheadType.EMP_Directed)
			{
				return true;
			}
			return Type == WarheadType.EMP_Omni;
		}
	}

	public _LaserType LaserType
	{
		get
		{
			switch (Type)
			{
			default:
				return _LaserType.None;
			case WarheadType.Laser_DeuteriumFluoride:
			case WarheadType.Laser_SolidStateFiber:
				return _LaserType.SolidState;
			case WarheadType.Laser_COIL:
			case WarheadType.Laser_CarbonDioxide:
				return _LaserType.Chemical;
			}
		}
	}

	public Warhead()
	{
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		if (!Information.IsNothing(callbackReader))
		{
			callbackReader.ResetIDs();
		}
	}

	public void ToXML(ref XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Warhead");
			xmlWriter_0.WriteElementString("DBID", DBID.ToString());
			xmlWriter_0.WriteElementString("ID", ObjectID);
			xmlWriter_0.WriteElementString("DP", XmlConvert.ToString(DP));
			XmlWriter obj = xmlWriter_0;
			int type = (int)Type;
			obj.WriteElementString("Type", type.ToString());
			XmlWriter obj2 = xmlWriter_0;
			type = (int)ExplosivesType;
			obj2.WriteElementString("ExpType", type.ToString());
			XmlWriter obj3 = xmlWriter_0;
			type = (int)Caliber;
			obj3.WriteElementString("Cal", type.ToString());
			xmlWriter_0.WriteElementString("NOW", NumberOfWarheads.ToString());
			xmlWriter_0.WriteElementString("CBDAL", ClusterBombDispersionAreaLength.ToString());
			xmlWriter_0.WriteElementString("CBDAW", ClusterBombDispersionAreaWidth.ToString());
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100746", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Warhead FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		try
		{
			Warhead warhead = new Warhead();
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "DP":
						warhead.DP = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "CBDAW":
						warhead.ClusterBombDispersionAreaWidth = Conversions.ToShort(xmlNode.InnerText);
						break;
					case "CBDAL":
						warhead.ClusterBombDispersionAreaLength = Conversions.ToShort(xmlNode.InnerText);
						break;
					case "ID":
						if (!concurrentDictionary_0.ContainsKey(xmlNode.InnerText))
						{
							warhead.ObjectID_Set(xmlNode.InnerText);
							concurrentDictionary_0.TryAdd(warhead.ObjectID, warhead);
							break;
						}
						return (Warhead)concurrentDictionary_0[xmlNode.InnerText];
					case "Cal":
					case "Caliber":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							warhead.Caliber = (WarheadCaliber)Conversions.ToShort(xmlNode.InnerText);
						}
						else
						{
							warhead.Caliber = (WarheadCaliber)Enum.Parse(typeof(WarheadCaliber), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "DBID":
						warhead.DBID = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "ExplosivesType":
					case "ExpType":
						warhead.ExplosivesType = (WarheadExplosivesType)Conversions.ToShort(xmlNode.InnerText);
						break;
					case "Type":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							warhead.Type = (WarheadType)Conversions.ToInteger(xmlNode.InnerText);
						}
						else
						{
							warhead.Type = (WarheadType)Enum.Parse(typeof(WarheadType), xmlNode.InnerText, ignoreCase: true);
						}
						break;
					case "NumberOfWarheads":
					case "NOW":
						warhead.NumberOfWarheads = (short)Conversions.ToInteger(xmlNode.InnerText);
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
			return warhead;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100747", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Warhead result = new Warhead();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public bool GetIsNuclear(Scenario scenario_0)
	{
		if (Type == WarheadType.Nuclear)
		{
			return true;
		}
		if (GetCarriedWeapon(scenario_0) != null && callbackReader.IsNuke.Value)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public bool GetIsAirburst(Weapon weapon_0, ActiveUnit activeUnit_0)
	{
		if (IsCluster)
		{
			return true;
		}
		if (!Information.IsNothing(activeUnit_0))
		{
			if (weapon_0.IsMissile && weapon_0.IsAAW && !Information.IsNothing(activeUnit_0) && (activeUnit_0.IsShip || activeUnit_0.IsFacility) && (int)activeUnit_0.VisualSizeClass > 1)
			{
				return false;
			}
			switch (Type)
			{
			default:
				if (GetIsNuclear(weapon_0.ParentScen))
				{
					if (activeUnit_0.IsHardTarget)
					{
						return false;
					}
					return true;
				}
				if (weapon_0.IsAAW)
				{
					WarheadType type = Type;
					if (type == WarheadType.Fragmentation || type == WarheadType.ContinuousRod || type == WarheadType.Fragmentation_ABM)
					{
						return true;
					}
				}
				return false;
			case WarheadType.Fragmentation:
			case WarheadType.FAE:
			case WarheadType.SuperFrag:
			case WarheadType.Cluster_AP:
			case WarheadType.Cluster_AT:
			case WarheadType.Cluster_Penetrator:
			case WarheadType.Cluster_SmartSubs:
			case WarheadType.EMP_Omni:
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	public Weapon GetCarriedWeapon(Scenario scenario_0)
	{
		if (Type == WarheadType.Weapon)
		{
			if (callbackReader == null)
			{
				callbackReader = scenario_0.Cache_GetWeapon((int)Math.Round(DP));
			}
			return callbackReader;
		}
		return null;
	}

	public double ClusterCoverageArea(WarheadType warheadType_0, double double_0)
	{
		if (ClusterBombDispersionAreaLength == 0 && ClusterBombDispersionAreaWidth == 0)
		{
			double num = 51.36986301369863;
			if (1 == 0)
			{
			}
			double result = warheadType_0 switch
			{
				WarheadType.Cluster_AP => num * double_0 * 1.2, 
				WarheadType.Cluster_AT => num * double_0 * 0.8, 
				WarheadType.Cluster_Penetrator => num * double_0 * 0.4, 
				_ => throw new NotImplementedException(), 
			};
			if (1 == 0)
			{
			}
			return result;
		}
		return (short)(ClusterBombDispersionAreaLength * ClusterBombDispersionAreaWidth);
	}

	public Warhead(string string_0, float float_0, WarheadType warheadType_0, WarheadExplosivesType warheadExplosivesType_0, WarheadCaliber warheadCaliber_0, string string_1 = "")
	{
		try
		{
			Name = string_0;
			DP = float_0;
			Type = warheadType_0;
			ExplosivesType = warheadExplosivesType_0;
			if (Type == WarheadType.Nuclear)
			{
				DP = 1000000f * DP;
			}
			Caliber = warheadCaliber_0;
			if (string.IsNullOrEmpty(string_1))
			{
				NumberOfWarheads = 1;
			}
			else
			{
				NumberOfWarheads = (short)Conversions.ToInteger(string_1);
			}
			if (Type == WarheadType.Cluster_AP || Type == WarheadType.Cluster_AT || Type == WarheadType.Cluster_Penetrator || Type == WarheadType.Cluster_SmartSubs || Type == WarheadType.SuperFrag)
			{
				DP *= NumberOfWarheads;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100748", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static double BombletDamageAtThisTarget(Platform platform_0, double double_0, double double_1, float float_0)
	{
		try
		{
			_ = platform_0.VisualSizeClass;
			if (platform_0.IsFacility && platform_0.AirFacilities_ReadOnly.Length != 0 && platform_0.AirFacilities_ReadOnly[0].DefineReader())
			{
				float num = MathFunctions.DeleteRequest(platform_0.CurrentHeading, float_0);
				return double_0 * 0.1 + double_0 * 0.9 * (1.0 - Math.Abs(Math.Sin((double)num * CSMath.PI_dividedBy_180)));
			}
			float num2 = (float)((double)platform_0.FlatSurfaceArea_m2 / double_1);
			if (num2 > 1f)
			{
				num2 = 1f;
			}
			return double_0 * (double)num2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100749", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.0;
		}
	}

	public static float BombletDamageAtThisAimpoint(Mount mount_0, double double_0, int int_0, float float_0, double double_1, WarheadType warheadType_0, WarheadExplosivesType warheadExplosivesType_0)
	{
		try
		{
			int maxValue = (int)Math.Round(double_1 / 10.0);
			float num = (((warheadType_0 == WarheadType.Cluster_SmartSubs) ? (GameGeneral.LockRandom_0.Next(1, 101) > 30) : (GameGeneral.LockRandom_0.Next(1, maxValue) <= int_0)) ? float_0 : ((float)(double_0 / double_1)));
			switch (warheadExplosivesType_0)
			{
			case WarheadExplosivesType.Submunitions_AntiRunwayPenetrator:
				num *= 5f;
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_LightArmor:
				num = (float)((double)num * 1.5);
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_MediumArmor:
				num *= 2f;
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_HeavyArmor:
				num *= 3f;
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_SpecialArmor:
				num *= 4f;
				break;
			}
			num = (float)((double)num * ((double)GameGeneral.LockRandom_0.Next(8, 13) / 10.0));
			return (float)Math.Min(num * 100f, double_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100750", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public static float FragDamageAtThisDistance(double double_0, double double_1, double double_2, WarheadType warheadType_0, double double_3, Weapon.DetonationMedium detonationMedium_0, bool bool_0, Scenario scenario_0)
	{
		try
		{
			switch (warheadType_0)
			{
			case WarheadType.HE_BlastFrag:
				double_3 = double_3;
				break;
			case WarheadType.Fragmentation_ABM:
				double_3 *= 2.0;
				break;
			default:
				return 0f;
			case WarheadType.Fragmentation:
			case WarheadType.SuperFrag:
				break;
			}
			float cutoffRange_Frag_nm = Explosion.GetCutoffRange_Frag_nm(double_3, Weapon.DetonationMedium.Air);
			if (double_2 <= (double)cutoffRange_Frag_nm)
			{
				double num = Math.Pow((float)(((double)cutoffRange_Frag_nm - double_2) / (double)cutoffRange_Frag_nm), 2.0);
				if (bool_0 && Terrain.GetElevation(double_0, double_1, bool_0: false, scenario_0) > 0)
				{
					switch (LandCover.DestroyClass(double_0, double_1, scenario_0))
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case LandCover.LandCoverType.Urban_CloseInnerCity:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedHighRise:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_AttachedHouses:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_CloseIndustrial:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedApartments:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_DetachedHouses:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedIndustrial:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_ShantyTown:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					case LandCover.LandCoverType.Mixed_forest:
						num *= 0.5;
						break;
					case LandCover.LandCoverType.Closed_shrublands:
					case LandCover.LandCoverType.Open_shrublands:
						num *= 0.75;
						break;
					case LandCover.LandCoverType.Woody_savannas:
					case LandCover.LandCoverType.Savannas:
						num *= 0.9;
						break;
					case LandCover.LandCoverType.UrbanAndBuiltUp:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Croplands:
					case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
						num *= 0.85;
						break;
					case LandCover.LandCoverType.Water:
					case LandCover.LandCoverType.Grasslands:
					case LandCover.LandCoverType.Permanent_wetlands:
					case LandCover.LandCoverType.SnowAndIce:
					case LandCover.LandCoverType.BarrenOrSparselyVegetated:
						break;
					}
				}
				double num2 = double_3 * num;
				if (num2 > double_3)
				{
					num2 = double_3;
				}
				return (float)num2;
			}
			return 0f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100751", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public static float BlastDamageAtThisDistance(double double_0, double double_1, double double_2, double double_3, WarheadType warheadType_0, double double_4, Weapon.DetonationMedium detonationMedium_0, bool bool_0, Scenario scenario_0)
	{
		double num = 0.0;
		try
		{
			double num2;
			switch (warheadType_0)
			{
			case WarheadType.HardTargetPenetrator:
				num2 = double_4;
				break;
			case WarheadType.HE_BlastFrag:
				num2 = double_4;
				break;
			case WarheadType.HEAT:
				num2 = double_4 / 5.0;
				break;
			case WarheadType.Fragmentation:
				num2 = double_4 / 3.0;
				break;
			default:
				num2 = double_4;
				break;
			case WarheadType.Nuclear:
				num2 = double_4 / 2.0;
				break;
			case WarheadType.Torpedo:
			case WarheadType.DepthCharge:
				num2 = double_4;
				break;
			}
			num += num2;
			if (num == 0.0)
			{
				return 0f;
			}
			if (double_2 <= 0.0005399568034557236)
			{
				return (float)num;
			}
			double num3 = Explosion.GetCutoffRange_Blast_nm(num, detonationMedium_0);
			if (double_2 <= num3)
			{
				double x = 1.0 - double_2 / num3;
				double num4 = ((detonationMedium_0 == Weapon.DetonationMedium.Underwater) ? Math.Pow(x, 3.0) : Math.Pow(x, 2.0));
				if (bool_0 && Terrain.GetElevation(double_0, double_1, bool_0: false, scenario_0) > 0)
				{
					switch (LandCover.DestroyClass(double_0, double_1, scenario_0))
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case LandCover.LandCoverType.Urban_CloseInnerCity:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedHighRise:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_AttachedHouses:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_CloseIndustrial:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedApartments:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_DetachedHouses:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedIndustrial:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_ShantyTown:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					case LandCover.LandCoverType.Mixed_forest:
						num4 *= 0.5;
						break;
					case LandCover.LandCoverType.Closed_shrublands:
					case LandCover.LandCoverType.Open_shrublands:
						num4 *= 0.75;
						break;
					case LandCover.LandCoverType.Woody_savannas:
					case LandCover.LandCoverType.Savannas:
						num4 *= 0.9;
						break;
					case LandCover.LandCoverType.UrbanAndBuiltUp:
						num4 *= 0.25;
						break;
					case LandCover.LandCoverType.Croplands:
					case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
						num4 *= 0.85;
						break;
					case LandCover.LandCoverType.Water:
					case LandCover.LandCoverType.Grasslands:
					case LandCover.LandCoverType.Permanent_wetlands:
					case LandCover.LandCoverType.SnowAndIce:
					case LandCover.LandCoverType.BarrenOrSparselyVegetated:
						break;
					}
				}
				return (float)Math.Min(num * num4, double_4);
			}
			return 0f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100752", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}
}
