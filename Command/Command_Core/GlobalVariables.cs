using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class GlobalVariables
{
	public enum ProficiencyLevel
	{
		Novice,
		Cadet,
		Regular,
		Veteran,
		Ace
	}

	public enum ArmorRating : short
	{
		None = 1001,
		Armor_Handgun = 1005,
		Armor_Rifle = 1010,
		Armor_HMG = 1015,
		RHA_20mm = 1020,
		RHA_25mm = 1025,
		RHA_30mm = 1030,
		RHA_35mm = 1035,
		Light = 2001,
		Medium = 2002,
		Heavy = 2003,
		Special = 2004
	}

	public enum PatrolType : byte
	{
		ASW,
		ASuW_Naval,
		AAW,
		ASuW_Land,
		ASuW_Mixed,
		SEAD,
		SeaControl
	}

	public enum TargetVisualSizeClass : byte
	{
		Stealthy,
		VSmall,
		Small,
		Medium,
		Large,
		VLarge,
		Unknown
	}

	public enum UnitNoiseLevelClass : byte
	{
		Loud,
		Noisy,
		Quiet,
		VQuiet,
		ExQuiet
	}

	public enum ActiveUnitType : byte
	{
		None,
		Aircraft,
		Ship,
		Submarine,
		Facility,
		Aimpoint,
		Weapon,
		Satellite,
		Vehicle,
		Personnel
	}

	public enum AircraftSizeClass : byte
	{
		None = 0,
		UAS_Class1_Micro = 1,
		UAS_Class1_Mini = 2,
		UAS_Class1_Small = 3,
		UAS_Class2 = 4,
		Small = 10,
		Medium = 20,
		Large = 30,
		VLarge = 40
	}

	public enum RunwayLengthClass
	{
		None = 1001,
		ManualLaunch = 1002,
		CatapultLaunched = 1101,
		VTOL = 2001,
		Between_1_250m = 3002,
		Between_1_450m = 3004,
		Between_451_900m = 3009,
		Between_901_1400m = 3014,
		Between_1401_2000m = 3020,
		Between_2001_2600m = 3026,
		Between_2601_3200m = 3032,
		Between_3201_4000m = 3040,
		Between_4000_5600m = 3056
	}

	public enum TechGenerationClass
	{
		None = 1001,
		NotApplicable = 1002,
		Early1950s = 2001,
		Late1950s = 2002,
		Early1960s = 2003,
		Late1960s = 2004,
		Early1970s = 2005,
		Late1970s = 2006,
		Early1980s = 2007,
		Late1980s = 2008,
		Early1990s = 2009,
		Late1990s = 2010,
		Early2000s = 2011,
		Late2000s = 2012,
		Early2010s = 2013,
		Late2010s = 2014,
		Early2020s = 2015,
		Late2020s = 2016,
		Visual = 2501,
		Visual_Gen1 = 2601,
		Visual_Gen2 = 2602,
		Visual_Gen3 = 2603,
		LLTV_Gen1 = 2701,
		LLTV_Gen2 = 2702,
		LLTV_Gen3 = 2703,
		IR_NonImaging = 2801,
		IR_Imaging_Gen1 = 2802,
		IR_Imaging_Gen2 = 2803,
		IR_Imaging_Gen3 = 2804,
		IR_SingleSpectral = 3001,
		IR_DualSpectral = 3002,
		IR_Imaging_FPA = 3003
	}

	public static string ApplicationStartupPath;

	public static long TimerCount;

	public static string FileDBConnString;

	public static string InMemoryConnString;

	public static Dictionary<Tuple<int, int>, int> ElevationsAt1DegIntervals;

	public static bool Headless;

	static GlobalVariables()
	{
		ApplicationStartupPath = Application.StartupPath;
		ElevationsAt1DegIntervals = new Dictionary<Tuple<int, int>, int>();
		Headless = false;
	}
}
