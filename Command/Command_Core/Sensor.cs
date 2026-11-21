using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Sharp3D.Math.Core;

namespace Command_Core;

public sealed class Sensor : PlatformComponent
{
	public struct _Capabilities
	{
		public bool AirSearch;

		public bool SurfaceSearch;

		public bool SubSearch;

		public bool LandSearch_Mobile;

		public bool LandSearch_Fixed;

		public bool PeriscopeSearch;

		public bool C_RAM;

		public bool SpaceSearch_ABM;

		public bool Mine_Obstacle_Search;

		public bool RangeInfo;

		public bool HeadingInfo;

		public bool AltitudeInfo;

		public bool SpeedInfo;

		public bool NavigationOnly;

		public bool GroundMappingOnly;

		public bool TerrainAvoidanceFollowingOnly;

		public bool WeatherOnly;

		public bool WeatherAndNavigationOnly;

		public bool OTH_Backscatter;

		public bool OTH_SurfaceWave;

		public bool TorpedoWarning;

		public bool MissileApproachWarning;
	}

	public struct _Codes
	{
		public bool IFF_Capable;

		public bool Classification;

		public bool NCTR_JEM;

		public bool NCTR_NBILST;

		public bool ContinuousTrackingCapable;

		public bool ContinousTrackingCapable_RadarTracker;

		public bool ContinousTrackingCapable_Visual;

		public bool TWS;

		public bool MTI;

		public bool LPI;

		public bool VisualNightCapable;

		public bool Pulse_only;

		public bool Doppler_LDSD_Limited;

		public bool Doppler_LDSD_Full;

		public bool CWI;

		public bool ICWI;

		public bool bool_0;

		public bool GeneratesAAWFireControl;

		public bool ShallowWaterCapable_Partial;

		public bool ShallowWaterCapable_Full;

		public bool PESA;

		public bool AESA;

		public bool SyntheticApertureRadar;

		public bool PeriscopeSearch_Basic;

		public bool PeriscopeAndSurfaceSearch_FineRangeResolution;

		public bool PeriscopeAndSurfaceSearch_AdvancedProcessing;

		public bool FrequencyAgile;
	}

	public enum FrequencyBand : long
	{
		A_Band = 1001L,
		B_Band = 1002L,
		C_Band = 1003L,
		D_Band = 1004L,
		E_Band = 1005L,
		F_Band = 1006L,
		G_Band = 1007L,
		H_Band = 1008L,
		I_Band = 1009L,
		J_Band = 1010L,
		K_Band = 1011L,
		L_Band = 1012L,
		M_Band = 1013L,
		Visual_Light = 2001L,
		Near_IR = 2002L,
		Far_IR = 2003L,
		Laser = 2004L,
		ELF_Radio = 3001L,
		SLF_Radio = 3002L,
		ULF_Radio = 3003L,
		VLF_Radio = 3004L,
		LF_Radio = 3005L,
		MF_Radio = 3006L,
		HF_Radio = 3007L,
		VHF_Radio = 3008L,
		UHF_Radio = 3009L,
		SHF_Radio = 3010L,
		EHF_Radio = 3011L,
		LF_Sonar = 4001L,
		MF_Sonar = 4002L,
		HF_Sonar = 4003L,
		VLF_Sonar = 4004L
	}

	public enum Sensor_Type : short
	{
		None = 1001,
		Radar = 2001,
		SemiActive = 2002,
		Visual = 2003,
		Infrared = 2004,
		TVM = 2005,
		ESM = 3001,
		ECM = 3002,
		EMP_Projector = 3003,
		PCLS = 3004,
		LaserDesignator = 4001,
		LaserSpotTracker = 4002,
		LaserRangefinder = 4003,
		HullSonar_PassiveOnly = 5001,
		HullSonar_ActivePassive = 5002,
		HullSonar_ActiveOnly = 5003,
		TowedArray_PassiveOnly = 5011,
		TowedArray_ActivePassive = 5012,
		TowedArray_ActiveOnly = 5013,
		VDS_PassiveOnly = 5021,
		VDS_ActivePassive = 5022,
		VDS_ActiveOnly = 5023,
		DippingSonar_PassiveOnly = 5031,
		DippingSonar_ActivePassive = 5032,
		DippingSonar_ActiveOnly = 5033,
		BottomFixedSonar_PassiveOnly = 5041,
		MAD = 5101,
		PingIntercept = 5901,
		MineSweep_MechanicalCableCutter = 6001,
		MineSweep_MagneticInfluence = 6002,
		MineSweep_AcousticInfluence = 6003,
		MineSweep_MultiInfluence = 6004,
		MineSweep_TwoShipMagneticInfluence = 6011,
		MineNeutralization_MooredMineCableCutter = 6021,
		MineNeutralization_ExplosiveChargeMineDisposal = 6022,
		MineNeutralization_DiverExplosiveCharge = 6031,
		Microwave_Emitter = 7001,
		NonDetectingEmitter = 8001,
		SensorGroup = 9001
	}

	public enum Sensor_Role : long
	{
		None = 1001L,
		AirSearch_2D_LR = 2001L,
		AirSeach_3D_LR = 2002L,
		AirSeach_2D_MR = 2003L,
		AirSeach_3D_MR = 2004L,
		AirSeach_2D_SR = 2005L,
		AirSeach_3D_SR = 2006L,
		AirSurfaceSearch_2D_LR = 2011L,
		AirSurfaceSearch_3D_LR = 2012L,
		AirSurfaceSearch_2D_MR = 2013L,
		AirSurfaceSearch_3D_MR = 2014L,
		AirSurfaceSearch_2D_SR = 2015L,
		AirSurfaceSearch_3D_SR = 2016L,
		HeightFinder_LR = 2017L,
		HeightFinder_MR = 2018L,
		HeightFinder_SR = 2019L,
		SurfaceSearch_LR = 2021L,
		SurfaceSearch_MR = 2022L,
		SurfaceSearch_SR = 2023L,
		SurfaceSearch_OTH = 2027L,
		SurfaceSearch_Navigation = 2028L,
		NavigationOnly = 2031L,
		GroundMappingOnly = 2032L,
		TerrainAvoidanceFollowingOnly = 2033L,
		WeatherOnly = 2034L,
		WeatherNavigationOnly = 2035L,
		TargetIndicator_SurfToAir_2D = 2101L,
		TargetIndicator_SurfToAir_3D = 2102L,
		TargetIndicator_SurfToAirSurfToSurf_2D = 2103L,
		TargetIndicator_SurfToAirSurfToSurf_3D = 2104L,
		TargetIndicator_SurfToSurf = 2105L,
		CounterBattery = 2109L,
		FCR_AirToAir_LR = 2111L,
		FCR_AirToAir_MR = 2112L,
		FCR_AirToAir_SR = 2113L,
		FCR_AirToAir_AirToSurf_LR = 2121L,
		FCR_AirToAir_AirToSurf_MR = 2122L,
		FCR_AirToAir_AirToSurf_SR = 2123L,
		FCR_AirToSurf_LR = 2124L,
		FCR_AirToSurf_MR = 2125L,
		FCR_AirToSurf_SR = 2126L,
		FCR_SurfToAir_LR = 2131L,
		FCR_SurfToAir_MR = 2132L,
		FCR_SurfToAir_SR = 2133L,
		FCR_SurfToAir_SurfToSurf_LR = 2141L,
		FCR_SurfToAir_SurfToSurf_MR = 2142L,
		FCR_SurfToAir_SurfToSurf_SR = 2143L,
		FCR_SurfToSurf = 2151L,
		FCR_SurfToSurf_OTH = 2152L,
		FCR_SurfToSurf_Torpedo = 2161L,
		FCR_GunOnly = 2191L,
		Illuminator_SAM_LR = 2201L,
		Illuminator_SAM_MR = 2202L,
		Illuminator_SAM_SR = 2203L,
		ActiveMissileSeeker = 2211L,
		RangeOnly = 2301L,
		Land_ATC = 2311L,
		Shipboard_ATC = 2312L,
		BMEWS = 2401L,
		Radar_BallisticMissileBattleManagement = 2402L,
		Radar_BallisticMissileTracker = 2403L,
		Radar_BallisticMissileEngagement = 2404L,
		LLTV_MineRecon = 2791L,
		IR_MAWS = 2891L,
		ESM_RWR = 3001L,
		ESM_LWR = 3002L,
		ESM_ELINT = 3011L,
		ESM_ELINT_OTHT = 3012L,
		ESM_COMINT = 3021L,
		ESM_SIGINT = 3031L,
		ESM_SIGINT_OTHT = 3032L,
		ESM_MASINT = 3041L,
		ESM_HFDF = 3101L,
		ESM_HFDF_OTHT = 3102L,
		ESM_ELS = 3201L,
		ESM_PassiveMissileSeeker = 3211L,
		ECM_OECM = 4001L,
		ECM_DECM = 4011L,
		ECM_OECM_DECM = 4021L,
		ECM_Repeater = 4031L,
		IRCM = 4041L,
		ECM_COMINT_Jammer = 4091L,
		ECM_AcousticJammer = 4901L,
		ECM_AcousticRepeater = 4902L,
		HullSonarPassiveOnlySearch = 5001L,
		HullSonarPassiveOnlySearchTrack = 5002L,
		HullSonarPassiveOnlyRangingFlankArraySearchTrack = 5011L,
		HullSonarPassiveOnlyTorpedoWarning = 5021L,
		HullSonarActivePassiveSearch = 5031L,
		HullSonarActivePassiveSearchTrack = 5032L,
		HullSonarActivePassiveSearchAttack = 5033L,
		HullSonarActivePassiveSearchMortarFireControl = 5034L,
		HullSonarActivePassiveAttack = 5041L,
		HullSonarActiveOnlySearch = 5061L,
		HullSonarActiveOnlySearchTrack = 5062L,
		HullSonarActiveOnlySearchAttack = 5063L,
		HullSonarActiveOnlySearchMortarFireControl = 5064L,
		HullSonarActiveOnlyAttack = 5071L,
		HullSonarActiveOnlyMortarFireControl = 5072L,
		HullSonarActiveOnlyBottomProfiler = 5081L,
		HullSonarActiveOnlyShortRangeSidescanMapping = 5082L,
		HullSonarActiveOnlyShortRangeSidescanMappingHighDefinitionLPI = 5083L,
		HullSonarActiveOnlyMineAvoidance = 5091L,
		HullSonarActiveOnlyMineObstacleAvoidance = 5092L,
		HullSonarActiveOnlyShallowWaterMineObstacleAvoidance = 5093L,
		HullSonarActiveOnlyShallowWaterHighDefinitionMineObstacleAvoidance = 5094L,
		HullSonarActiveOnlyUnderIceNavigationandMineObstacleAvoidance = 5095L,
		HullSonarActiveOnlyAntiCollisionNavigation = 5096L,
		HullSonarActiveOnlyMineReconnaissance = 5097L,
		HullSonarActiveOnlyMineHunting = 5098L,
		HullSonarActiveOnlyMineHuntingASWMortarFireControl = 5099L,
		HullSonarPassiveOnlyVerticalRangingArray = 5012L,
		LLTV_Surveillance_Camera = 2701L,
		LLTV_SurveillanceAndNavigation_Camera = 2702L,
		LLTV_NightVisionGoggles_NVG = 2703L,
		LLTV_DayNight_SphericalSituationalAwarenessAndFireControl = 2709L,
		LLTV_DayNight_SphericalSituationalAwareness = 2710L,
		LLTV_Reconnaissance_FrameCamera = 2711L,
		LLTV_Reconnaissance_LongRange_FrameCamera = 2712L,
		LLTV_Reconnaissance_VeryLongRange_FrameCamera = 2713L,
		LLTV_Reconnaissance_Satellite_FrameCamera = 2719L,
		LLTV_WideAngleAerialSurveillance_WAAS = 2720L,
		LLTV_Navigation = 2721L,
		LLTV_NavigationAndAttack = 2730L,
		LLTV_Attack = 2731L,
		LLTV_TargetTrackingAndIdentification = 2771L,
		LLTV_TargetSearchTrackingAndIdentification = 2772L,
		LLTV_TargetSearchSlavedTrackingAndIdentification = 2773L,
		LLTV_WeaponDirector = 2781L,
		LLTV_WeaponDirectorAndTargetTrackingAndIdentification = 2782L,
		LLTV_WeaponDirectorAndTargetSearchTrackingAndIdentification = 2783L,
		LLTV_WeaponDirectorAndTargetSearchSlavedTrackingAndIdentification = 2784L,
		LLTV_MineReconnaissance = 2791L,
		TASSPassiveOnlyTowedArraySonarSystem = 5101L,
		TASSPassiveOnlyFatLineTowedArraySonarSystem = 5102L,
		TASSPassiveOnlyThinLineTowedArraySonarSystem = 5103L,
		TASSPassiveOnlyAreaSurveillanceTowedArraySonarSystem = 5104L,
		TASSPassiveTorpedoWarningTowedArraySonarSystem = 5111L,
		TASSActivePassiveTowedArraySonarSystem = 5131L,
		TASSActivePassiveAreaSurveillanceTowedArraySonarSystem = 5132L,
		TASSActiveOnlyTowedArraySonarSystem = 5161L,
		SURTASSPassiveOnlySurveillanceTowedArraySonarSystem = 5191L,
		SURTASSActivePassiveSurveillanceTowedArraySonarSystem = 5192L,
		SURTASSActiveOnlySurveillanceTowedArraySonarSystem = 5193L,
		VDSPassiveOnlyVariableDepthSonar = 5201L,
		VDSActivePassiveVariableDepthSonar = 5231L,
		VDSActiveOnlyVariableDepthSonar = 5261L,
		VDSActiveOnlyMineReconnaissanceVariableDepthSonar = 5271L,
		VDSActiveOnlyMineHuntingVariableDepthSonar = 5272L,
		VDSActiveOnlySidescanMineHuntingVariableDepthSonar = 5273L,
		VDSPropelledActiveOnlyMineHuntingVariableDepthSonar = 5274L,
		DippingSonarPassiveOnlySearchTrack = 5301L,
		DippingSonarActivePassiveSearchTrack = 5331L,
		DippingSonarActivePassiveShallowWaterSearchTrack = 5332L,
		DippingSonarActiveOnlySearchTrack = 5361L,
		HelicopterTowedActiveOnlyMineReconnaissanceSonar = 5391L,
		SOSUSPassiveSoundSurveillanceSystems = 5401L,
		MooredSonobuoyPassiveSearch = 5402L,
		SonobuoyPassiveOnlyNonDirectional = 5501L,
		SonobuoyPassiveOnlyDirectional = 5502L,
		SonobuoyPassiveOnlyDirectionalFrequencyAnalysisandRecording_DIFAR = 5507L,
		SonobuoyPassiveOnlyDirectionalLowFrequencyAnalysisandRanging_LOFAR = 5508L,
		SonobuoyPassiveOnlyDirectionalVerticalLineArrayDIFAR_VLAD = 5509L,
		SonobuoyActivePassiveRangeOnlyOmniDirectional = 5511L,
		SonobuoyActivePassiveRangeDirectional = 5512L,
		SonobuoyActiveOnlyRangeOnlyNonDirectional = 5521L,
		SonobuoyActiveOnlyRangeOnlyNonDirectionalContinousPing = 5522L,
		SonobuoyActiveOnlyRangeOnlyNonDirectionalCommandActivatedSonobuoySystem_CASS = 5523L,
		SonobuoyActiveOnlyRangeDirectional = 5527L,
		SonobuoyActiveOnlyRangeDirectionalCommandActivatedSonobuoySystem_DICASS = 5528L,
		SonobuoyActiveOnlyRangeDirectionalExtendedEchoRanging_EER = 5529L,
		TorpedoSeekerPassiveOnly = 5701L,
		TorpedoSeekerPassiveOnlyShallowWater = 5702L,
		TorpedoSeekerActivePassive = 5711L,
		TorpedoSeekerActivePassiveShallowWater = 5712L,
		TorpedoSeekerActivePassiveWakeHomer_WH = 5713L,
		TorpedoSeekerActivePassiveShallowWaterWakeHomer_WH = 5714L,
		TorpedoSeekerActiveOnly = 5721L,
		TorpedoSeekerActiveOnlyShallowWater = 5722L,
		TorpedoSeekerWakeHomer = 5791L,
		Visual_Binoculars = 2501L,
		Visual_Optical_Sight = 2511L,
		Visual_Bomb_Sight = 2512L,
		Visual_Surveillance_Periscope = 2515L,
		Visual_Fire_Control_Periscope = 2516L,
		Visual_Searchlight = 2521L,
		Visual_Surveillance_TVCamera = 2601L,
		Visual_SurveillanceNavigation_TVCamera = 2602L,
		Visual_SpaceObject_Surveillance = 2605L,
		Visual_SpaceObject_Tracker = 2606L,
		Visual_DayOnlySphericalSituationalAwarenessAndFireControl = 2609L,
		Visual_DayOnlySphericalSituationalAwareness = 2610L,
		Visual_Reconnaissance_FrameCamera = 2611L,
		Visual_Reconnaissance_LongRange_FrameCamera = 2612L,
		Visual_Reconnaissance_VeryLongRange_FrameCamera = 2613L,
		Visual_Reconnaissance_SatelliteFrameCamera = 2619L,
		Visual_WideAngle_AerialSurveillance_WAAS = 2620L,
		Visual_Navigation_TVCamera = 2621L,
		Visual_NavigationAndAttack_TVCamera = 2630L,
		Visual_Attack_TVCamera = 2631L,
		Visual_Strike_Camera = 2641L,
		Visual_TargetTrackingAndIdentification_TVCamera = 2671L,
		Visual_TargetSearchTrackingAndIdentification_TVCamera = 2672L,
		Visual_TargetSearch_SlavedTrackingAndIdentification_TVCamera = 2673L,
		Visual_WeaponDirector_TVCamera = 2681L,
		Visual_WeaponDirector_TargetTrackingAndIdentification_TVCamera = 2682L,
		Visual_WeaponDirector_TargetSearchTrackingAndIdentification_TVCamera = 2683L,
		Visual_WeaponDirector_TargetSearchSlavedTrackingAndIdentification_TVCamera = 2684L,
		MAD = 5801L,
		AcousticIntercept = 5901L,
		AcousticInterceptPassiveRanging = 5902L,
		AcousticInterceptSurveillance = 5903L,
		AcousticInterceptTorpedoWarning = 5911L
	}

	public enum DetectionAttemptType
	{
		VolumeSearch,
		SpecificTargetTracking,
		WeaponGuidance,
		Recon
	}

	public enum SensorDetectionFeedback
	{
		DB_Invisible = -10000,
		PROGRAM_Exception = 99999,
		GENERAL_Range = 1,
		GENERAL_TargetSuitability = 3,
		GENERAL_CoveringArc = 5,
		GENERAL_MaxAltitude_AGL = 7,
		GENERAL_MinAltitude_AGL = 9,
		GENERAL_MaxAltitude_ASL = 11,
		GENERAL_MinAltitude_ASL = 13,
		GENERAL_Other = 15,
		GENERAL_WeaponESM_UnsuitableTarget_Satellite = 17,
		GENERAL_WeaponESM_UnsuitableTarget_AircraftOrWeapon = 19,
		GENERAL_WeaponESM_UnsuitableTarget_ShipOrFacility = 21,
		GENERAL_SuccessfullDetection_FromOneOfThePCLS = 22,
		GENERAL_FailedDetection_FromAllThePCLS = 23,
		GENERAL_SuccessfullDetection_IR = 24,
		GENERAL_FailedDetection_IR = 25,
		GENERAL_SuccessfullDetection_PingIntercept = 26,
		GENERAL_FailedDetection_PingIntercept = 27,
		GENERAL_SuccessfullDetection_Visual = 28,
		GENERAL_FailedDetection_Visual = 29,
		GENERAL_SuccessfullDetection_Radar = 30,
		GENERAL_FailedDetection_Radar = 31,
		GENERAL_SuccessfullDetection_ESM = 32,
		GENERAL_FailedDetection_ESM = 33,
		GENERAL_SuccessfullDetection_HullandBottomFixed_PassiveSonar = 34,
		GENERAL_FailedDetection_HullandBottomFixed_PassiveSonar = 35,
		GENERAL_SuccessfullDetection_HullandBottomFixed_ActiveSonar = 36,
		GENERAL_FailedDetection_HullandBottomFixed_ActiveSonar = 37,
		GENERAL_SuccessfullDetection_DippingAndVDS_PassiveSonar = 38,
		GENERAL_FailedDetection_DippingAndVDS_PassiveSonar = 39,
		GENERAL_SuccessfullDetection_DippingAndVDS_ActiveSonar = 40,
		GENERAL_FailedDetection_DippingAndVDS_ActiveSonar = 41,
		GENERAL_SuccessfullDetection_MAD = 42,
		GENERAL_FailedDetection_MAD = 43,
		RADAR_RadarLOS_SurfaceWave = 101,
		RADAR_RadarLOS = 103,
		RADAR_RadarLOS_Terrain = 105,
		RADAR_PureIlluminatorFailedDetection = 107,
		RADAR_PureIlluminatorSuccessfulDetection = 109,
		RADAR_SubUnitAbovePeriscopeDepthNotDetectable_BiologicsOrFalseContact = 111,
		RADAR_SubUnitAbovePeriscopeDepthNotDetectable_NoPeriscopeOrSnorkel = 113,
		RADAR_CantDetectPeriscope = 115,
		RADAR_BlindCone = 117,
		RADAR_LDSD_Limited_LookDown15deg = 119,
		RADAR_LDSD_Limited_LookDown5deg = 121,
		RADAR_Other = 123,
		RADAR_ECM_Equation = 125,
		RADAR_Successful_OTHBackscatter = 126,
		RADAR_ABM_HorizonFailed = 127,
		RADAR_ABM_HorizonSuccessful = 129,
		VISUAL_VerticalViewAngle45deg = 201,
		VISUAL_AverageCockpitVisibility_VerticalViewAngle25deg = 203,
		VISUAL_RNG_ExcellentCockpitVisibility = 205,
		VISUAL_RNG_AverageCockpitVisibility = 207,
		VISUAL_RNG_PoorCockpitVisibility = 209,
		VISUAL_LOS = 211,
		VISUAL_MaxNominalRange = 213,
		VISUAL_MaxSpecificRange = 215,
		VISUAL_ABM_Horizon_Failed = 217,
		VISUAL_ABM_Horizon_Successful = 218,
		IR_LOSVisual = 401,
		IR_MaxRange = 403,
		IR_MaxRange_SpecificToTarget = 405,
		IR_NoPeriscopeSearchCapability = 407,
		IR_ABM_BeyondHorizon = 409,
		PING_LOSSonar = 501,
		PING_MaxRange = 503,
		PING_NoInterceptionFromAnyEmitter = 505,
		ACTIVESONAR_NotOperating = 601,
		ACTIVESONAR_LOSSonar = 603,
		ACTIVESONAR_AboveDeafSpeed = 605,
		ACTIVESONAR_MaxRangeSpecificTarget = 607,
		ACTIVESONAR_SuccessfulDirectDetection = 608,
		ACTIVESONAR_SuccessfulIndirectDetection = 610,
		ACTIVESONAR_SuccessfulBottomBounceDetection = 612,
		ACTIVESONAR_SuccessfulDetectionThroughCZ = 614,
		ACTIVESONAR_Other = 615,
		PASSIVESONAR_NotOperating = 701,
		PASSIVESONAR_SuccessfulPingIntercept = 702,
		PASSIVESONAR_FailedPingIntercept = 703,
		PASSIVESONAR_AboveDeafSpeed = 705,
		PASSIVESONAR_LOSSonar = 707,
		PASSIVESONAR_MaxNominalRange = 709,
		PASSIVESONAR_SignalMaskedByAnother = 711,
		PASSIVESONAR_MaxActualRange = 713,
		PASSIVESONAR_LandmassInBetween = 715,
		PASSIVESONAR_SuccessfulDetectionThroughCZ = 716,
		PASSIVESONAR_CZBlockingAndNoDirectPath = 717,
		MAD_UnitIsSubBiologics = 801,
		MAD_UnitIsTorpedo = 803,
		MAD_MaxEffectiveRange = 805,
		MAD_IsNotBoatType = 807,
		RADARILLUMINATION_RadarHorizonLOS_SurfaceWave = 901,
		RADARILLUMINATION_RadarHorizonLOS = 903,
		RADARILLUMINATION_RadarHorizonLOS_Failed = 905,
		RADARILLUMINATION_CoveringArc = 907,
		RADARILLUMINATION_Other = 909,
		RADARILLUMINATION_ECMEquation = 911,
		RADARILLUMINATION_ABM_Horizon_Failure = 913,
		RADARILLUMINATION_ABM_Horizon_Success = 914,
		RADARILLUMINATION_OTH_Success = 916,
		RADARILLUMINATION_OTH_Failure = 917,
		ESM_RadarHorizonLOS_SurfaceWave = 1001,
		ESM_RadarHorizonLOS = 1003,
		ESM_RadarHorizonLOS_Terrain = 1005,
		ESM_RWRvsJamming = 1007,
		ESM_Equation = 1009,
		ESM_OTHSW_Emitter_MaxRange = 1011,
		ESM_OTHSW_Emitter_LOS = 1013,
		ESM_EmitterNotActive = 1015,
		ESM_IncompatibleFrequency = 1017,
		ESM_EmitterNotOperating = 1019,
		ESM_MaxRange = 1021,
		ESM_Success = 1022,
		ESM_Failure = 1023
	}

	private enum SensorDetectionCheck
	{

	}

	public enum SensorDetectionCheckResult
	{
		Undefined = 0,
		Success = 1,
		Fail_OutOfRange = 2,
		Fail_NoLOS_Terrain = 3,
		Fail_NoLOS_Cloud = 4,
		Fail_NoLOS_Fog = 5,
		Fail_NoLOS_Horizon = 6,
		Fail_OutsideCoverageArc = 7,
		Fail_NotSuitableForThisTarget = 8,
		Fail_SensorParentInoperative = 9,
		Fail_NotEnoughReturn = 10,
		Fail_Other = 9999
	}

	public enum ActiveEmissionMode : byte
	{
		Search_Track,
		Illuminate
	}

	public class RadioElectronicFrequency
	{
		public FrequencyBand Band;

		public string ToString_Short
		{
			get
			{
				FrequencyBand band = Band;
				if (band <= FrequencyBand.Near_IR)
				{
					FrequencyBand frequencyBand = band - 1001;
					if ((ulong)frequencyBand <= 12uL && (ulong)frequencyBand <= 12uL)
					{
						FrequencyBand frequencyBand4 = frequencyBand;
						FrequencyBand frequencyBand5 = frequencyBand4;
						if ((ulong)frequencyBand5 <= 12uL)
						{
							switch (frequencyBand5)
							{
							case (FrequencyBand)0L:
								return "A";
							case (FrequencyBand)1L:
								return "B";
							case (FrequencyBand)2L:
								return "C";
							case (FrequencyBand)3L:
								return "D";
							case (FrequencyBand)4L:
								return "E";
							case (FrequencyBand)5L:
								return "F";
							case (FrequencyBand)6L:
								return "G";
							case (FrequencyBand)7L:
								return "H";
							case (FrequencyBand)8L:
								return "I";
							case (FrequencyBand)9L:
								return "J";
							case (FrequencyBand)10L:
								return "K";
							case (FrequencyBand)11L:
								return "L";
							case (FrequencyBand)12L:
								return "M";
							}
						}
					}
					if (band == FrequencyBand.Near_IR)
					{
						return "Near IR";
					}
				}
				else
				{
					if (band == FrequencyBand.Far_IR)
					{
						return "Far IR";
					}
					FrequencyBand frequencyBand2 = band - 3001;
					if ((ulong)frequencyBand2 <= 10uL && (ulong)frequencyBand2 <= 10uL)
					{
						FrequencyBand frequencyBand6 = frequencyBand2;
						FrequencyBand frequencyBand7 = frequencyBand6;
						if ((ulong)frequencyBand7 <= 10uL)
						{
							switch (frequencyBand7)
							{
							case (FrequencyBand)0L:
								return "ELF";
							case (FrequencyBand)1L:
								return "SLF";
							case (FrequencyBand)2L:
								return "ULF";
							case (FrequencyBand)7L:
								return "VHF";
							case (FrequencyBand)8L:
								return "UHF";
							case (FrequencyBand)9L:
								return "SHF";
							case (FrequencyBand)10L:
								return "EHF";
							case (FrequencyBand)3L:
								goto IL_02be;
							case (FrequencyBand)5L:
								goto IL_02c8;
							case (FrequencyBand)4L:
								goto IL_02d2;
							case (FrequencyBand)6L:
								goto IL_02f9;
							}
						}
					}
					FrequencyBand frequencyBand3 = band - 4001;
					if ((ulong)frequencyBand3 <= 3uL && (ulong)frequencyBand3 <= 3uL)
					{
						FrequencyBand frequencyBand8 = frequencyBand3;
						FrequencyBand frequencyBand9 = frequencyBand8;
						if ((ulong)frequencyBand9 <= 3uL)
						{
							switch (frequencyBand9)
							{
							case (FrequencyBand)3L:
								break;
							case (FrequencyBand)1L:
								goto IL_02c8;
							case (FrequencyBand)0L:
								goto IL_02d2;
							default:
								goto IL_02dc;
							case (FrequencyBand)2L:
								goto IL_02f9;
							}
							goto IL_02be;
						}
					}
				}
				goto IL_02dc;
				IL_02dc:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return string.Empty;
				IL_02f9:
				return "HF";
				IL_02be:
				return "VLF";
				IL_02d2:
				return "LF";
				IL_02c8:
				return "MF";
			}
		}

		public RadioElectronicFrequency(FrequencyBand frequencyBand_0)
		{
			Band = frequencyBand_0;
		}

		public long BandCeiling()
		{
			FrequencyBand frequencyBand = Band - 1001;
			if ((ulong)frequencyBand <= 12uL && (ulong)frequencyBand <= 12uL)
			{
				FrequencyBand frequencyBand2 = frequencyBand;
				FrequencyBand frequencyBand3 = frequencyBand2;
				if ((ulong)frequencyBand3 <= 12uL)
				{
					switch (frequencyBand3)
					{
					case (FrequencyBand)0L:
						return 250000000L;
					case (FrequencyBand)1L:
						return 500000000L;
					case (FrequencyBand)2L:
						return 1000000000L;
					case (FrequencyBand)3L:
						return 2000000000L;
					case (FrequencyBand)4L:
						return 3000000000L;
					case (FrequencyBand)5L:
						return 4000000000L;
					case (FrequencyBand)6L:
						return 6000000000L;
					case (FrequencyBand)7L:
						return 8000000000L;
					case (FrequencyBand)8L:
						return 10000000000L;
					case (FrequencyBand)9L:
						return 20000000000L;
					case (FrequencyBand)10L:
						return 40000000000L;
					case (FrequencyBand)11L:
						return 60000000000L;
					case (FrequencyBand)12L:
						return 100000000000L;
					}
				}
			}
			return 0L;
		}

		public long BandBottom()
		{
			FrequencyBand frequencyBand = Band - 1001;
			if ((ulong)frequencyBand <= 12uL && (ulong)frequencyBand <= 12uL)
			{
				FrequencyBand frequencyBand2 = frequencyBand;
				FrequencyBand frequencyBand3 = frequencyBand2;
				if ((ulong)frequencyBand3 <= 12uL)
				{
					switch (frequencyBand3)
					{
					case (FrequencyBand)0L:
						return 1000000L;
					case (FrequencyBand)1L:
						return 250000000L;
					case (FrequencyBand)2L:
						return 500000000L;
					case (FrequencyBand)3L:
						return 1000000000L;
					case (FrequencyBand)4L:
						return 2000000000L;
					case (FrequencyBand)5L:
						return 3000000000L;
					case (FrequencyBand)6L:
						return 4000000000L;
					case (FrequencyBand)7L:
						return 6000000000L;
					case (FrequencyBand)8L:
						return 8000000000L;
					case (FrequencyBand)9L:
						return 10000000000L;
					case (FrequencyBand)10L:
						return 20000000000L;
					case (FrequencyBand)11L:
						return 40000000000L;
					case (FrequencyBand)12L:
						return 60000000000L;
					}
				}
			}
			return 0L;
		}
	}

	public float maxRange;

	public float minRange;

	public Sensor_Type Type;

	public Sensor_Role Role;

	public string RoleDescription;

	public int MaxIlluminate;

	public float MaxAltitude_AGL;

	public float MinAltitude_AGL;

	public float MaxAltitude_ASL;

	public float MinAltitude_ASL;

	public float RangeResolution_Nominal;

	public float HeightResolution;

	public float AngleResolution;

	private int _ProxyFacade;

	public int TimeToNextScan;

	public int TimeToNextScan_Full;

	public _Capabilities Capabilities;

	public _Codes Codes;

	public RadioElectronicFrequency[] SearchFreqs;

	public RadioElectronicFrequency[] IlluminationFreqs;

	private List<Contact> _ReaderFacade;

	public List<Weapon> SemiActiveWeaponsGuided;

	private List<string> propertyFacade;

	public Dictionary<string, bool> DetectionChecksThisPulse;

	private bool importerFacade;

	private bool? m_RepositoryFacade;

	public _Coverage Coverage_Illuminate;

	public GlobalVariables.TechGenerationClass TechGeneration;

	[ThreadStatic]
	private RadarModel.TRadar _BridgeFacade;

	[ThreadStatic]
	private RadarModel.TReceiver m_Receiver;

	public bool Hypothetical;

	public float? Boresight;

	public bool IsSensorInLoadout;

	public bool IsSensorInMount;

	public int IsSensorInGroup;

	public int MastHeight;

	internal short classFacade;

	private short _RequestFacade;

	private short valueFacade;

	private short _TokenizerFacade;

	private float m_StubFacade;

	private long m_UpperFreq;

	private long m_LowerFreq;

	private long m_UpperFreqIlluminate;

	private long m_LowerFreqIlluminate;

	public float m_RadarHorBeamwidth;

	internal float m_RadarVerBeamwidth;

	internal float m_SystemNoiseLevel_SearchOrTrack;

	internal float m_ProcessingGain_SearchOrTrack;

	internal float m_PowerOutputW_SearchOrTrack;

	internal float m_PulseWidth_SearchOrTrack;

	internal float m_RadarBlindTime_SearchOrTrack;

	internal float m_PRF_SearchOrTrack;

	internal float m_RadarHorBeamwidth_Illuminate;

	internal float m_RadarVerBeamwidth_Illuminate;

	internal float m_SystemNoiseLevel_Illuminate;

	internal float m_ProcessingGain_Illuminate;

	internal float m_PowerOutputW_Illuminate;

	internal float m_PulseWidth_Illuminate;

	internal float m_RadarBlindTimeIlluminate;

	internal float m_PRF_Illuminate;

	internal float m_Sensitivity;

	internal float m_SystemLoss;

	internal short m_ESMNumberOfChannels;

	internal float _ProccesorFacade;

	internal float m_StrategyFacade;

	internal float configurationFacade;

	internal float m_ECMNumberOfTargets;

	internal float m_ECMPoKReduction;

	public bool ESM_PreciseEmitterID;

	internal short m_ResolverFacade;

	internal short publisherFacade;

	internal short serverFacade;

	public short m_MineSweepWidth;

	internal short m_MineSweepMaximumSpeed;

	internal float schemaFacade;

	internal float _UtilsFacade;

	internal float m_PredicateFacade;

	internal float m_SingletonFacade;

	public float MaxElevationAngle;

	public float MinElevationAngle;

	public float MaxAntennaElevationAngle;

	public float MinAntennaElevationAngle;

	private float m_RecordFacade;

	private float m_ExceptionFacade;

	private float _AttrFacade;

	private float m_VisitorFacade;

	private float _ExporterFacade;

	private float m_PrototypeFacade;

	private bool m_ComparatorFacade;

	[ThreadStatic]
	private static StringBuilder m_sensor_xmlStr;

	private bool? _SetterFacade;

	private bool? creatorFacade;

	private List<SensorDetectionFeedback> m_SensorDetectionFeedbackList;

	private bool IsMk1Eyeball;

	private HashSet<FrequencyBand> FrequencyBandHashSet;

	private ThreadLocal<List<Sensor>> SensorList;

	public bool VariableMaxRange
	{
		get
		{
			if (Type == Sensor_Type.Radar)
			{
				if (!Codes.AESA && !Codes.PESA)
				{
					return false;
				}
				return !Coverage.Has360Coverage();
			}
			return false;
		}
	}

	public override _ComponentStatus Status => base.Status;

	public bool IsScanningOnThisPulse
	{
		get
		{
			if (TimeToNextScan <= 0)
			{
				return true;
			}
			if (TargetsTrackedForFireControl_Readonly.Count <= 0)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsScanningOnThisPulse_Full
	{
		get
		{
			if (TimeToNextScan_Full <= 0)
			{
				return true;
			}
			return false;
		}
	}

	public bool CanDetectEmissions
	{
		get
		{
			Sensor_Type type = Type;
			if (type != Sensor_Type.ESM && type != Sensor_Type.PingIntercept)
			{
				return false;
			}
			return true;
		}
	}

	public float Swath_Total => Swath_Port + Swath_Starboard;

	public float Swath_Port
	{
		get
		{
			try
			{
				float result = 0f;
				if (Coverage.PB2 || Coverage.PS1)
				{
					result = (float)((double)maxRange * Math2.SetClass(22.5));
				}
				if (Coverage.PB1 || Coverage.PS2)
				{
					result = (float)((double)maxRange * Math2.FillClass(45f));
				}
				if (Coverage.PMF2 || Coverage.PMA1)
				{
					result = (float)((double)maxRange * Math2.SetClass(67.5));
				}
				if (Coverage.PMF1 || Coverage.PMA2)
				{
					result = maxRange;
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100695", "");
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

	public float Swath_Starboard
	{
		get
		{
			try
			{
				float result = 0f;
				if (Coverage.SB2 || Coverage.SS1)
				{
					result = (float)((double)maxRange * Math2.SetClass(22.5));
				}
				if (Coverage.SB1 || Coverage.SS2)
				{
					result = (float)((double)maxRange * Math2.FillClass(45f));
				}
				if (Coverage.SMF2 || Coverage.SMA1)
				{
					result = (float)((double)maxRange * Math2.SetClass(67.5));
				}
				if (Coverage.SMF1 || Coverage.SMA2)
				{
					result = maxRange;
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100696", "");
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

	public long UpperFreq
	{
		get
		{
			if (m_UpperFreq <= 0)
			{
				if (SearchFreqs.Length == 0)
				{
					return 0L;
				}
				long num = 0L;
				RadioElectronicFrequency[] searchFreqs = SearchFreqs;
				RadioElectronicFrequency[] array = searchFreqs;
				foreach (RadioElectronicFrequency radioElectronicFrequency in array)
				{
					if (radioElectronicFrequency.BandCeiling() > num)
					{
						num = radioElectronicFrequency.BandCeiling();
					}
				}
				return num;
			}
			return m_UpperFreq;
		}
	}

	public long LowerFreq
	{
		get
		{
			if (m_LowerFreq <= 0)
			{
				if (SearchFreqs.Length == 0)
				{
					return 0L;
				}
				long num = long.MaxValue;
				RadioElectronicFrequency[] searchFreqs = SearchFreqs;
				RadioElectronicFrequency[] array = searchFreqs;
				foreach (RadioElectronicFrequency radioElectronicFrequency in array)
				{
					if (radioElectronicFrequency.BandBottom() < num)
					{
						num = radioElectronicFrequency.BandBottom();
					}
				}
				return num;
			}
			return m_LowerFreq;
		}
	}

	public long UpperFreqIlluminate
	{
		get
		{
			try
			{
				if (m_UpperFreqIlluminate <= 0)
				{
					if (IlluminationFreqs.Length == 0)
					{
						return 0L;
					}
					long num = 0L;
					RadioElectronicFrequency[] illuminationFreqs = IlluminationFreqs;
					RadioElectronicFrequency[] array = illuminationFreqs;
					foreach (RadioElectronicFrequency radioElectronicFrequency in array)
					{
						if (radioElectronicFrequency.BandCeiling() > num)
						{
							num = radioElectronicFrequency.BandCeiling();
						}
					}
					return num;
				}
				return m_UpperFreqIlluminate;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100698", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0L;
			}
		}
	}

	public long LowerFreqIlluminate
	{
		get
		{
			try
			{
				if (m_LowerFreqIlluminate <= 0)
				{
					if (IlluminationFreqs.Length == 0)
					{
						return 0L;
					}
					long num = long.MaxValue;
					RadioElectronicFrequency[] illuminationFreqs = IlluminationFreqs;
					RadioElectronicFrequency[] array = illuminationFreqs;
					foreach (RadioElectronicFrequency radioElectronicFrequency in array)
					{
						if (radioElectronicFrequency.BandBottom() < num)
						{
							num = radioElectronicFrequency.BandBottom();
						}
					}
					return num;
				}
				return m_LowerFreqIlluminate;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100699", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return 0L;
			}
		}
	}

	public List<Contact> TargetsTrackedForFireControl_Readonly => _ReaderFacade;

	public bool IsActive
	{
		get
		{
			if (CanBeActive)
			{
				if (Status == _ComponentStatus.Operational)
				{
					return importerFacade;
				}
				return false;
			}
			return false;
		}
	}

	public bool? IsNeutralized
	{
		get
		{
			return m_RepositoryFacade;
		}
		set
		{
			m_RepositoryFacade = value;
		}
	}

	public bool HasActiveModeOnly
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case Sensor_Type.Radar:
			case Sensor_Type.ECM:
			case Sensor_Type.LaserDesignator:
			case Sensor_Type.LaserRangefinder:
			case Sensor_Type.HullSonar_ActiveOnly:
			case Sensor_Type.TowedArray_ActiveOnly:
			case Sensor_Type.VDS_ActiveOnly:
			case Sensor_Type.DippingSonar_ActiveOnly:
				return true;
			}
		}
	}

	public int ScanInterval
	{
		get
		{
			if (_ProxyFacade < 1)
			{
				_ProxyFacade = 1;
			}
			return _ProxyFacade;
		}
		set
		{
			_ProxyFacade = Math.Max(value, 1);
		}
	}

	public bool IsPureIlluminator
	{
		get
		{
			if (IsMineCountermeasure)
			{
				return false;
			}
			if (Type == Sensor_Type.MAD)
			{
				return false;
			}
			return SearchFreqs.Count() == 0;
		}
	}

	public bool IsContinousTrackingCapable
	{
		get
		{
			if (!Codes.ContinuousTrackingCapable && !Codes.ContinousTrackingCapable_RadarTracker && !Codes.ContinousTrackingCapable_Visual && !Codes.AESA && !Codes.PESA)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsFireControlRadar
	{
		get
		{
			if (Type != Sensor_Type.Radar)
			{
				return false;
			}
			Sensor_Role role = Role;
			if (role <= Sensor_Role.FCR_SurfToAir_SurfToSurf_SR)
			{
				Sensor_Role sensor_Role = role - 2111;
				if ((ulong)sensor_Role <= 22uL && (ulong)sensor_Role <= 22uL)
				{
					Sensor_Role sensor_Role2 = sensor_Role;
					Sensor_Role sensor_Role3 = sensor_Role2;
					if ((ulong)sensor_Role3 <= 22uL)
					{
						switch (sensor_Role3)
						{
						case (Sensor_Role)0L:
						case (Sensor_Role)1L:
						case (Sensor_Role)2L:
							return true;
						case (Sensor_Role)10L:
						case (Sensor_Role)11L:
						case (Sensor_Role)12L:
							return true;
						case (Sensor_Role)13L:
						case (Sensor_Role)14L:
						case (Sensor_Role)15L:
							return true;
						case (Sensor_Role)20L:
						case (Sensor_Role)21L:
						case (Sensor_Role)22L:
							return true;
						case (Sensor_Role)3L:
						case (Sensor_Role)4L:
						case (Sensor_Role)5L:
						case (Sensor_Role)6L:
						case (Sensor_Role)7L:
						case (Sensor_Role)8L:
						case (Sensor_Role)9L:
						case (Sensor_Role)16L:
						case (Sensor_Role)17L:
						case (Sensor_Role)18L:
						case (Sensor_Role)19L:
							goto IL_0140;
						}
					}
				}
				if ((ulong)(role - 2141) <= 2uL)
				{
					return true;
				}
			}
			else if ((ulong)(role - 2151) > 1uL && role != Sensor_Role.FCR_SurfToSurf_Torpedo && role == Sensor_Role.FCR_GunOnly)
			{
				return true;
			}
			goto IL_0140;
			IL_0140:
			return false;
		}
	}

	public bool IsGroundBasedFireControlRadar
	{
		get
		{
			if (Type == Sensor_Type.Radar)
			{
				if (IsPureIlluminator)
				{
					return false;
				}
				Sensor_Role role = Role;
				if ((ulong)(role - 2101) > 3uL)
				{
					Sensor_Role sensor_Role = role - 2121;
					if ((ulong)sensor_Role <= 22uL && (ulong)sensor_Role <= 22uL)
					{
						Sensor_Role sensor_Role2 = sensor_Role;
						Sensor_Role sensor_Role3 = sensor_Role2;
						if ((ulong)sensor_Role3 <= 22uL)
						{
							switch (sensor_Role3)
							{
							case (Sensor_Role)6L:
							case (Sensor_Role)7L:
							case (Sensor_Role)8L:
							case (Sensor_Role)9L:
							case (Sensor_Role)13L:
							case (Sensor_Role)14L:
							case (Sensor_Role)15L:
							case (Sensor_Role)16L:
							case (Sensor_Role)17L:
							case (Sensor_Role)18L:
							case (Sensor_Role)19L:
								goto IL_010d;
							case (Sensor_Role)0L:
							case (Sensor_Role)1L:
							case (Sensor_Role)2L:
							case (Sensor_Role)3L:
							case (Sensor_Role)4L:
							case (Sensor_Role)5L:
							case (Sensor_Role)10L:
							case (Sensor_Role)11L:
							case (Sensor_Role)12L:
							case (Sensor_Role)20L:
							case (Sensor_Role)21L:
							case (Sensor_Role)22L:
								goto IL_0112;
							}
						}
					}
					if (role != Sensor_Role.FCR_GunOnly)
					{
						goto IL_010d;
					}
				}
				goto IL_0112;
			}
			return false;
			IL_0112:
			return true;
			IL_010d:
			return false;
		}
	}

	public bool IsGroundBasedAirSearchRadar
	{
		get
		{
			if (Type == Sensor_Type.Radar)
			{
				if (IsPureIlluminator)
				{
					return false;
				}
				Sensor_Role role = Role;
				if ((ulong)(role - 2001) > 5uL && (ulong)(role - 2011) > 8uL)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsGroundBasedOECM
	{
		get
		{
			if (Type == Sensor_Type.ECM)
			{
				Sensor_Role role = Role;
				if (role != Sensor_Role.ECM_OECM && role != Sensor_Role.ECM_OECM_DECM)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool CanPerformVolumeSearch
	{
		get
		{
			switch (Type)
			{
			default:
			{
				if (IsPureIlluminator)
				{
					return false;
				}
				Sensor_Role role = Role;
				if ((ulong)(role - 2031) > 4uL && role != Sensor_Role.FCR_GunOnly && (ulong)(role - 2201) > 2uL)
				{
					return true;
				}
				return false;
			}
			case Sensor_Type.None:
			case Sensor_Type.SemiActive:
			case Sensor_Type.TVM:
			case Sensor_Type.ECM:
			case Sensor_Type.LaserDesignator:
			case Sensor_Type.LaserSpotTracker:
			case Sensor_Type.LaserRangefinder:
			case Sensor_Type.SensorGroup:
				return false;
			}
		}
	}

	public bool IsHeightFinder
	{
		get
		{
			if ((ulong)(Role - 2017) <= 2uL)
			{
				return true;
			}
			return false;
		}
	}

	public bool CanPerformIllumination
	{
		get
		{
			if (MaxIlluminate == 0)
			{
				return false;
			}
			if (IlluminationFreqs.Count() == 0 && m_UpperFreqIlluminate == 0L && m_LowerFreqIlluminate == 0)
			{
				return false;
			}
			return true;
		}
	}

	public bool CanBeActive
	{
		get
		{
			if (IsMineCountermeasure)
			{
				return true;
			}
			if (Role == Sensor_Role.ECM_DECM)
			{
				return false;
			}
			if (Role == Sensor_Role.IRCM)
			{
				return false;
			}
			return Misc.HasActiveMode(Type);
		}
	}

	public Geopoint_Struct[] MineSweepCoverageArea
	{
		get
		{
			try
			{
				if (IsMineCountermeasure)
				{
					if (IsActive)
					{
						if (TimeToNextScan <= 0)
						{
							double num = (double)m_MineSweepWidth / 1852.0;
							float num2 = Math2.UpdateClass(base.ParentPlatform.CurrentHeading + 180f);
							Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
							Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
							Geopoint_Struct geopoint_Struct3 = default(Geopoint_Struct);
							Geopoint_Struct geopoint_Struct4 = default(Geopoint_Struct);
							float float_ = 0.08099355f;
							if (!base.ParentPlatform.IsShip && !base.ParentPlatform.IsSubmarine)
							{
								Geopoint_Struct[] array = new Geopoint_Struct[4];
								Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, (float)(num * 3.0), num2);
								Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct3.Longitude, ref geopoint_Struct3.Latitude, (float)(num / 2.0), Math2.UpdateClass(num2 - 90f));
								Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, (float)(num / 2.0), Math2.UpdateClass(num2 + 90f));
								array[0] = new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude());
								array[1] = geopoint_Struct3;
								array[2] = geopoint_Struct2;
								array[3] = geopoint_Struct;
								return array;
							}
							if (Type == Sensor_Type.MineSweep_MechanicalCableCutter)
							{
								Geopoint_Struct[] array2 = new Geopoint_Struct[3];
								Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, (float)(num * 3.0), num2);
								Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct3.Longitude, ref geopoint_Struct3.Latitude, (float)num, Math2.UpdateClass(num2 + 90f));
								Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref geopoint_Struct4.Longitude, ref geopoint_Struct4.Latitude, float_, num2);
								array2[0] = geopoint_Struct4;
								array2[1] = geopoint_Struct2;
								array2[2] = geopoint_Struct3;
								return array2;
							}
							Geopoint_Struct[] array3 = new Geopoint_Struct[4];
							Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, (float)(num * 3.0), num2);
							Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct3.Longitude, ref geopoint_Struct3.Latitude, (float)(num / 2.0), Math2.UpdateClass(num2 - 90f));
							Geodesic_EdWilliams.CalcPoint_Williams(geopoint_Struct2.Longitude, geopoint_Struct2.Latitude, ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, (float)(num / 2.0), Math2.UpdateClass(num2 + 90f));
							Geodesic_EdWilliams.CalcPoint_Williams(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude(), ref geopoint_Struct4.Longitude, ref geopoint_Struct4.Latitude, float_, num2);
							array3[0] = geopoint_Struct4;
							array3[1] = geopoint_Struct3;
							array3[2] = geopoint_Struct2;
							array3[3] = geopoint_Struct;
							return array3;
						}
						return null;
					}
					return null;
				}
				return null;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100702", "");
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

	public bool IsOperating
	{
		get
		{
			try
			{
				if (base.ParentPlatform == null)
				{
					return false;
				}
				if (Status == _ComponentStatus.Operational)
				{
					if (Operators.CompareString(ReasonForInoperative, "None", TextCompare: false) == 0)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100705", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
	}

	public override string ReasonForInoperative
	{
		get
		{
			if (Information.IsNothing(base.ParentPlatform))
			{
				return "None";
			}
			if (base.ParentPlatform.IsSubmarine)
			{
				bool revisedSubOptics = base.ParentPlatform.ParentScen.FeatureCompatibility.GetRevisedSubOptics(base.ParentPlatform.ParentScen.DBConnection);
				if (Operators.CompareString(Name, "Mk1 视线", TextCompare: false) == 0 && revisedSubOptics)
				{
					bool? flag;
					bool? flag2 = (flag = ParentHasNoVisualSensor());
					bool? flag3;
					if (flag2.HasValue && !flag.GetValueOrDefault())
					{
						flag3 = false;
					}
					else
					{
						bool? isDBUsedCWDB;
						flag2 = (isDBUsedCWDB = base.ParentPlatform.ParentScen.IsDBUsedCWDB);
						flag3 = ((!flag2.HasValue) ? null : (isDBUsedCWDB.GetValueOrDefault() & flag));
					}
					bool? flag4 = flag3;
					if (((!flag4) ?? flag4).GetValueOrDefault() && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "潜艇必须在水面才能进行视线观察";
					}
				}
				if (Type == Sensor_Type.ESM)
				{
					if (!((Submarine)base.ParentPlatform).IsAtPeriscopeDepth && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "潜艇必须处于潜望镜深度或更浅的位置";
					}
					if (base.ParentPlatform.CurrentSpeed > 10f && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "ESM传感器只能在速度小于或等于10节时工作";
					}
				}
				if (Type == Sensor_Type.Infrared && ((Submarine)base.ParentPlatform).Type != Submarine._SubmarineType.ROV && ((Submarine)base.ParentPlatform).Type != Submarine._SubmarineType.UUV)
				{
					if (!((Submarine)base.ParentPlatform).IsAtPeriscopeDepth && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "潜艇必须处于潜望镜深度或更浅的位置";
					}
					if (base.ParentPlatform.CurrentSpeed > 10f && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "潜望镜只能在速度小于或等于10节时工作";
					}
				}
				if (Type == Sensor_Type.Visual && ((Submarine)base.ParentPlatform).Type != Submarine._SubmarineType.ROV && ((Submarine)base.ParentPlatform).Type != Submarine._SubmarineType.UUV)
				{
					if (!((Submarine)base.ParentPlatform).IsAtPeriscopeDepth && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "潜艇必须处于潜望镜深度或更浅的位置";
					}
					if (base.ParentPlatform.CurrentSpeed > 10f && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "潜望镜只能在速度小于或等于10节时工作";
					}
				}
				if (Type == Sensor_Type.Radar)
				{
					if (!((Submarine)base.ParentPlatform).IsAtPeriscopeDepth && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "潜艇必须处于潜望镜深度或更浅的位置";
					}
					if (base.ParentPlatform.CurrentSpeed > 10f && !((Submarine)base.ParentPlatform).IsSurfaced)
					{
						return "雷达只能在速度小于或等于10节时工作";
					}
				}
			}
			if (IsTowedArray)
			{
				if (!(base.ParentPlatform.CurrentSpeed <= 15f))
				{
					return "拖曳阵列只能在速度小于15节时工作";
				}
				int landElevation = base.ParentPlatform.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen);
				if (Role != Sensor_Role.TASSActiveOnlyTowedArraySonarSystem && Role != Sensor_Role.TASSPassiveTorpedoWarningTowedArraySonarSystem)
				{
					if (landElevation > -150)
					{
						return "拖曳阵列无法在小于150米深度工作";
					}
				}
				else if (landElevation > -20)
				{
					return "鱼雷警戒拖曳阵列无法在小于20米深度工作";
				}
			}
			if (IsDippingSonar && base.ParentPlatform.IsAircraft && (((Aircraft)base.ParentPlatform).AirOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || base.ParentPlatform.GetCurrentAltitude() > 50f || base.ParentPlatform.CurrentSpeed != 0f))
			{
				return "平台没有悬停和部署传感器";
			}
			_ = IsDECM;
			if (HasActiveModeOnly && !IsActive)
			{
				return "传感器仅具有主动模式且未开机";
			}
			return "None";
		}
	}

	public bool IsMineCountermeasure
	{
		get
		{
			if (Type <= (Sensor_Type)6000)
			{
				return false;
			}
			return Type < (Sensor_Type)7000;
		}
	}

	public bool IsExplosiveMineNeutralizer
	{
		get
		{
			if (Type == Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal)
			{
				return true;
			}
			return Type == Sensor_Type.MineNeutralization_DiverExplosiveCharge;
		}
	}

	public bool IsOTH
	{
		get
		{
			if (Capabilities.OTH_Backscatter)
			{
				return true;
			}
			return Capabilities.OTH_SurfaceWave;
		}
	}

	public bool IsDippingSonar
	{
		get
		{
			if (Type != Sensor_Type.DippingSonar_ActiveOnly && Type != Sensor_Type.DippingSonar_ActivePassive)
			{
				return Type == Sensor_Type.DippingSonar_PassiveOnly;
			}
			return true;
		}
	}

	public bool IsDECM
	{
		get
		{
			switch (Role)
			{
			default:
				return false;
			case Sensor_Role.IRCM:
				return true;
			case Sensor_Role.ECM_DECM:
			case Sensor_Role.ECM_OECM_DECM:
				return true;
			}
		}
	}

	public bool IsMineHuntingSensor
	{
		get
		{
			switch (Role)
			{
			case Sensor_Role.LLTV_MineRecon:
				return true;
			default:
				return false;
			case Sensor_Role.HullSonarActiveOnlyMineReconnaissance:
			case Sensor_Role.HullSonarActiveOnlyMineHunting:
			case Sensor_Role.HullSonarActiveOnlyMineHuntingASWMortarFireControl:
			case Sensor_Role.VDSActiveOnlyMineReconnaissanceVariableDepthSonar:
			case Sensor_Role.VDSActiveOnlyMineHuntingVariableDepthSonar:
			case Sensor_Role.VDSActiveOnlySidescanMineHuntingVariableDepthSonar:
			case Sensor_Role.VDSPropelledActiveOnlyMineHuntingVariableDepthSonar:
			case Sensor_Role.HelicopterTowedActiveOnlyMineReconnaissanceSonar:
				return true;
			}
		}
	}

	public bool IsCommsJammer
	{
		get
		{
			if (Role == Sensor_Role.ECM_COMINT_Jammer)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsOECM
	{
		get
		{
			Sensor_Role role = Role;
			if (role != Sensor_Role.ECM_OECM && role != Sensor_Role.ECM_OECM_DECM && role != Sensor_Role.ECM_COMINT_Jammer)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsTowedArray
	{
		get
		{
			if ((uint)(Type - 5011) <= 2u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsSonar
	{
		get
		{
			switch (Type)
			{
			default:
				return false;
			case Sensor_Type.HullSonar_PassiveOnly:
			case Sensor_Type.HullSonar_ActivePassive:
			case Sensor_Type.HullSonar_ActiveOnly:
			case Sensor_Type.TowedArray_PassiveOnly:
			case Sensor_Type.TowedArray_ActivePassive:
			case Sensor_Type.TowedArray_ActiveOnly:
			case Sensor_Type.VDS_PassiveOnly:
			case Sensor_Type.VDS_ActivePassive:
			case Sensor_Type.VDS_ActiveOnly:
			case Sensor_Type.DippingSonar_PassiveOnly:
			case Sensor_Type.DippingSonar_ActivePassive:
			case Sensor_Type.DippingSonar_ActiveOnly:
			case Sensor_Type.BottomFixedSonar_PassiveOnly:
				return true;
			}
		}
	}

	public bool IsPingIntercept
	{
		get
		{
			if (Type == Sensor_Type.PingIntercept)
			{
				return true;
			}
			return false;
		}
	}

	public bool m_IsMk1Eyeball => IsMk1Eyeball;

	public HashSet<FrequencyBand> UsedFrequencies
	{
		get
		{
			HashSet<FrequencyBand> hashSet = null;
			try
			{
				if (FrequencyBandHashSet == null)
				{
					List<FrequencyBand> list = new List<FrequencyBand>();
					list.AddRange(SearchFreqs.Select((RadioElectronicFrequency theF) => theF.Band));
					list.AddRange(IlluminationFreqs.Select((RadioElectronicFrequency theF) => theF.Band));
					FrequencyBandHashSet = new HashSet<FrequencyBand>(list);
				}
				hashSet = FrequencyBandHashSet;
				return hashSet;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				hashSet = hashSet;
				ProjectData.ClearProjectError();
				return hashSet;
			}
		}
	}

	internal int TestWriter()
	{
		if (Codes.AESA)
		{
			return 90;
		}
		if (Codes.PESA)
		{
			return 60;
		}
		return 15;
	}

	internal bool StopWriter()
	{
		switch (Type)
		{
		case Sensor_Type.Microwave_Emitter:
			return MaxIlluminate > 1;
		default:
			return false;
		case Sensor_Type.Radar:
			if (MaxIlluminate > 1)
			{
				return TargetsTrackedForFireControl_Readonly.Count > 0;
			}
			return false;
		}
	}

	[SpecialName]
	public float GetmaxRangeAtAngle(float float_0)
	{
		if (VariableMaxRange)
		{
			return VerifyWriter(float_0);
		}
		return maxRange;
	}

	[SpecialName]
	public float GetGetRadarOffBoresightGainModifier(float float_0)
	{
		if (VariableMaxRange)
		{
			float num = Math.Abs(ListWriter(float_0));
			if (num > 0f)
			{
				return (float)Math.Pow(Math2.PopClass(num), 1.3);
			}
		}
		return 1f;
	}

	private float CancelWriter(float float_0)
	{
		return (float)Math.Pow(Math.Abs(Math2.PopClass(float_0)), 0.65);
	}

	internal float VerifyWriter(float float_0)
	{
		float result = maxRange;
		float num = Math.Abs(ListWriter(float_0));
		if (num > 0f)
		{
			result = maxRange * CancelWriter(num);
		}
		return result;
	}

	internal float ListWriter(float float_0)
	{
		float num = float_0;
		num = Math2.UpdateClass(float_0);
		float num2 = 0f;
		float float_ = 0f;
		float float_2 = 0f;
		float num3 = 0f;
		if (GetCoverageArc(num, ref float_, ref float_2))
		{
			if (float_2 <= float_)
			{
				num3 = (float_ + (360f + float_2)) / 2f;
				num2 = (360f + float_2 - float_ - 120f) / 2f;
				num = ((num < float_) ? (360f + num - num3) : (num - num3));
			}
			else
			{
				num3 = (float_ + float_2) / 2f;
				num -= num3;
				num2 = (float_2 - float_ - 120f) / 2f;
			}
			if (num == 0f)
			{
				return 0f;
			}
			if (num > 180f)
			{
				num -= 360f;
			}
			if (num2 <= 0f)
			{
				if (num > 180f)
				{
					num -= 360f;
				}
			}
			else
			{
				float num4 = Math.Abs(num) - num2;
				num = ((num4 <= 0f) ? 0f : ((num4 <= 180f) ? num4 : (num4 - 360f)));
			}
			return num;
		}
		return 0f;
	}

	internal float ResolveWriter(float float_0, float float_1)
	{
		if ((Codes.AESA || Codes.PESA) && !Coverage.Has360Coverage() && ListWriter(float_1) != 0f)
		{
			float num = VerifyWriter(float_1);
			return float_0 / (num / maxRange);
		}
		return float_0;
	}

	public static bool CanTrackAllTargetsAtThisBoresightBearing(Sensor sensor_0, int int_0, List<Module_Unit.Unit> list_0)
	{
		foreach (Module_Unit.Unit item in list_0)
		{
			float float_ = Module_Unit.BearingToUnit_True(sensor_0.ParentPlatform, item);
			if (!((double)Math.Abs(MathFunctions.DeleteRequest(int_0, float_)) <= (double)sensor_0.TestWriter() / 2.0))
			{
				return false;
			}
		}
		return true;
	}

	public void CalculateAntennaEmissionLimitAngles(float float_0)
	{
		float num = MaxAntennaElevationAngle;
		float num2 = MinAntennaElevationAngle;
		if (Codes.PESA || Codes.AESA)
		{
			num = 60f;
			num2 = -60f;
		}
		if (Capabilities.SpaceSearch_ABM)
		{
			num = 90f;
		}
		num += float_0;
		num2 -= float_0;
		if (num < 90f)
		{
			m_RecordFacade = (float)Math.Sin((double)num * 0.0174532925199433);
		}
		else
		{
			m_RecordFacade = 1f;
		}
		if (num2 < -90f)
		{
			m_ExceptionFacade = -1f;
		}
		else
		{
			m_ExceptionFacade = (float)Math.Sin((double)num2 * 0.0174532925199433);
		}
	}

	public void CalculateRadarResolutionCell()
	{
		float float_;
		if (IsPureIlluminator)
		{
			_AttrFacade = 0.081f * m_PulseWidth_Illuminate;
			m_VisitorFacade = m_RadarVerBeamwidth_Illuminate / 57f / 2f;
			_ExporterFacade = m_RadarHorBeamwidth_Illuminate / 2f;
			float_ = m_RadarVerBeamwidth_Illuminate / 2f;
		}
		else
		{
			_AttrFacade = 0.081f * m_PulseWidth_SearchOrTrack;
			m_VisitorFacade = m_RadarVerBeamwidth / 57f / 2f;
			_ExporterFacade = m_RadarHorBeamwidth / 2f;
			float_ = m_RadarVerBeamwidth / 2f;
		}
		m_PrototypeFacade = _ExporterFacade / 57f;
		CalculateAntennaEmissionLimitAngles(float_);
	}

	public void ReCalculateResolutionCell()
	{
		if (Type == Sensor_Type.Radar && !IsPureIlluminator && CanPerformIllumination)
		{
			float float_;
			if (TargetsTrackedForFireControl_Readonly.Count <= 0)
			{
				_AttrFacade = 0.081f * m_PulseWidth_SearchOrTrack;
				m_VisitorFacade = m_RadarVerBeamwidth / 57f / 2f;
				_ExporterFacade = m_RadarHorBeamwidth / 2f;
				float_ = m_RadarVerBeamwidth / 2f;
			}
			else
			{
				_AttrFacade = 0.081f * m_PulseWidth_Illuminate;
				m_VisitorFacade = m_RadarVerBeamwidth_Illuminate / 57f / 2f;
				_ExporterFacade = m_RadarHorBeamwidth_Illuminate / 2f;
				float_ = m_RadarVerBeamwidth_Illuminate / 2f;
			}
			m_PrototypeFacade = _ExporterFacade / 57f;
			CalculateAntennaEmissionLimitAngles(float_);
		}
	}

	internal bool PostWriter()
	{
		return _AttrFacade > 0f;
	}

	internal bool RunWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, ActiveUnit activeUnit_2, float float_1)
	{
		if (PostWriter())
		{
			if (Math.Abs(float_0 - float_1) <= _AttrFacade)
			{
				if ((double)Math.Abs(activeUnit_2.GetCurrentAltitude() - activeUnit_1.GetCurrentAltitude()) <= (double)(m_VisitorFacade * float_0) * 1852.0)
				{
					if (Module_Unit.RangeToUnit_Horiz(activeUnit_2, activeUnit_1) <= m_PrototypeFacade * float_0)
					{
						float float_2 = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit_1);
						float float_3 = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit_2);
						if (Math.Abs(MathFunctions.DeleteRequest(float_2, float_3)) <= _ExporterFacade)
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	internal bool StartWriter(ActiveUnit activeUnit_0, ConcurrentQueue<Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>>> concurrentQueue_0)
	{
		if (PostWriter())
		{
			float num = Module_Unit.RangeToUnit_Horiz(base.ParentPlatform, activeUnit_0);
			foreach (Tuple<Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>> item2 in concurrentQueue_0)
			{
				if (item2.Item2 != activeUnit_0 && item2.Item3.Contains(this))
				{
					float item = item2.Item4;
					if (item <= num && RunWriter(base.ParentPlatform, activeUnit_0, num, item2.Item2, item))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	public string ToXML(HashSet<string> hashSet_0)
	{
		try
		{
			if (m_sensor_xmlStr == null)
			{
				m_sensor_xmlStr = new StringBuilder();
			}
			else
			{
				m_sensor_xmlStr.Clear();
			}
			m_sensor_xmlStr.Append("<Sensor>");
			m_sensor_xmlStr.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (hashSet_0 != null)
			{
				if (hashSet_0.Contains(ObjectID))
				{
					m_sensor_xmlStr.Append("</Sensor>");
					return m_sensor_xmlStr.ToString();
				}
				hashSet_0.Add(ObjectID);
			}
			m_sensor_xmlStr.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (_Status != 0)
			{
				StringBuilder stringBuilder = m_sensor_xmlStr.Append("<St>");
				byte status = (byte)_Status;
				stringBuilder.Append(status.ToString()).Append("</St>");
			}
			if (base.DamageSeverity != 0)
			{
				m_sensor_xmlStr.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			m_sensor_xmlStr.Append("<Name>").Append(SecurityElement.Escape(Name)).Append("</Name>");
			if (Coverage.HasDefinedArcs)
			{
				m_sensor_xmlStr.Append(Coverage.ToXML(bool_0: false));
			}
			if (Coverage_Illuminate.HasDefinedArcs)
			{
				m_sensor_xmlStr.Append(Coverage_Illuminate.ToXML(bool_0: true));
			}
			if (_ReaderFacade.Count > 0)
			{
				m_sensor_xmlStr.Append("<TTFFC>");
				foreach (Contact item in _ReaderFacade)
				{
					if (item != null)
					{
						m_sensor_xmlStr.Append("<ID>").Append(item.ObjectID).Append("</ID>");
					}
				}
				m_sensor_xmlStr.Append("</TTFFC>");
			}
			if (SemiActiveWeaponsGuided.Count > 0)
			{
				m_sensor_xmlStr.Append("<SAWG>");
				foreach (Weapon item2 in SemiActiveWeaponsGuided.ToList())
				{
					if (item2 != null)
					{
						m_sensor_xmlStr.Append("<ID>").Append(item2.ObjectID).Append("</ID>");
					}
				}
				m_sensor_xmlStr.Append("</SAWG>");
			}
			if (TimeToNextScan != 0)
			{
				m_sensor_xmlStr.Append("<TTNS>").Append(TimeToNextScan).Append("</TTNS>");
			}
			if (IsActive)
			{
				m_sensor_xmlStr.Append("<IsA>True</IsA>");
			}
			if (Boresight.HasValue)
			{
				m_sensor_xmlStr.Append("<Boresight>").Append(XmlConvert.ToString(Boresight.Value)).Append("</Boresight>");
			}
			if (IsSensorInGroup > 0)
			{
				m_sensor_xmlStr.Append("<SensorGroup>").Append(XmlConvert.ToString(IsSensorInGroup)).Append("</SensorGroup>");
			}
			m_sensor_xmlStr.Append("</Sensor>");
			return m_sensor_xmlStr.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100693", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Sensor()
		: base(null)
	{
		Capabilities = default(_Capabilities);
		Codes = default(_Codes);
		SearchFreqs = new RadioElectronicFrequency[0];
		IlluminationFreqs = new RadioElectronicFrequency[0];
		_ReaderFacade = new List<Contact>();
		SemiActiveWeaponsGuided = new List<Weapon>();
		propertyFacade = new List<string>();
		Coverage_Illuminate = new _Coverage();
		IsSensorInLoadout = false;
		IsSensorInMount = false;
		IsSensorInGroup = -1;
		MastHeight = 0;
		MaxElevationAngle = 30f;
		MinElevationAngle = -30f;
		MaxAntennaElevationAngle = 30f;
		MinAntennaElevationAngle = -30f;
		m_RecordFacade = 0.5f;
		m_ExceptionFacade = 0.5f;
		m_ComparatorFacade = true;
		_SetterFacade = null;
		creatorFacade = null;
		SensorList = new ThreadLocal<List<Sensor>>();
	}

	public override bool TargetIsWithinCoverageArc(Module_Unit.Unit unit_0, float? nullable_0 = null)
	{
		bool result = false;
		try
		{
			if (StopWriter() && Boresight.HasValue)
			{
				float float_ = Module_Unit.BearingToUnit_True(base.ParentPlatform, unit_0);
				if ((double)Math.Abs(MathFunctions.DeleteRequest(Boresight.Value, float_)) <= (double)TestWriter() / 2.0)
				{
					result = true;
					return true;
				}
				result = false;
				return false;
			}
			return result = base.TargetIsWithinCoverageArc(unit_0, nullable_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10234590832469", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public static Sensor FromXML(XmlNode xmlNode_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ActiveUnit activeUnit_0)
	{
		try
		{
			Sensor sensor = new Sensor();
			sensor.ParentPlatform = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode_ = (XmlNode)enumerator.Current;
					switch (xmlNode_.Name)
					{
					case "SensorGroup":
						sensor.IsSensorInGroup = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Name":
						sensor.Name = xmlNode_.InnerText;
						break;
					case "Status":
					case "St":
						switch (xmlNode_.InnerText)
						{
						default:
							sensor._Status = (_ComponentStatus)Conversions.ToByte(xmlNode_.InnerText);
							break;
						case "Operational":
							sensor._Status = _ComponentStatus.Operational;
							break;
						case "Destroyed":
							sensor._Status = _ComponentStatus.Destroyed;
							break;
						case "Damaged":
							sensor._Status = _ComponentStatus.Damaged;
							break;
						}
						break;
					case "TargetsIlluminated":
					case "TTFFC":
					case "TargetsTrackedForFireControl":
						try
						{
							enumerator3 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								Contact item = Contact.FromXML(((XmlNode)enumerator3.Current).InnerText, ref concurrentDictionary_0);
								sensor._ReaderFacade.Add(item);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					case "ID":
						if (!Information.IsNothing(concurrentDictionary_0))
						{
							if (concurrentDictionary_0.ContainsKey(xmlNode_.InnerText))
							{
								return (Sensor)concurrentDictionary_0[xmlNode_.InnerText];
							}
							sensor.ObjectID_Set(xmlNode_.InnerText);
							concurrentDictionary_0.TryAdd(sensor.ObjectID, sensor);
						}
						break;
					case "DBID":
					{
						int int_ = Conversions.ToInteger(xmlNode_.InnerText);
						SQLiteConnection sqliteConnection_ = activeUnit_0.ParentScen.DBConnection;
						Sensor sensor2 = DBFunctions.GetSensor(int_, ref sqliteConnection_);
						sensor2.ObjectID_Set(sensor.ObjectID);
						sensor2._Status = sensor.Status;
						sensor2.Name = sensor.Name;
						sensor2.DBID = Conversions.ToInteger(xmlNode_.InnerText);
						sensor2.Coverage = sensor.Coverage;
						foreach (Contact item2 in sensor.TargetsTrackedForFireControl_Readonly)
						{
							sensor2._ReaderFacade.Add(item2);
						}
						sensor2.SemiActiveWeaponsGuided = sensor.SemiActiveWeaponsGuided;
						if (sensor.IsActive)
						{
							sensor2.GoActive();
						}
						sensor = sensor2;
						break;
					}
					case "IsA":
					case "IsActive":
						sensor.importerFacade = Conversions.ToBoolean(xmlNode_.InnerText);
						break;
					case "DamageSeverity":
						sensor.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(xmlNode_.InnerText);
						break;
					case "Cov_Ill":
					case "Coverage_Illuminate":
						sensor.Coverage_Illuminate = _Coverage.FromXML(ref xmlNode_);
						break;
					case "SemiActiveWeaponsGuided":
					case "SAWG":
						try
						{
							enumerator2 = xmlNode_.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode = (XmlNode)enumerator2.Current;
								sensor.propertyFacade.Add(xmlNode.ChildNodes[0].InnerText);
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "TTNS":
						sensor.TimeToNextScan = Conversions.ToInteger(xmlNode_.InnerText);
						break;
					case "Cov":
					case "Coverage":
						sensor.Coverage = _Coverage.FromXML(ref xmlNode_);
						break;
					case "Boresight":
						sensor.Boresight = Convert.ToSingle(xmlNode_.InnerText, CultureInfo.InvariantCulture);
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
			if (string.IsNullOrEmpty(sensor.Name))
			{
				if (sensor.DBID == 0)
				{
					sensor.Name = "Mk1 Eyeball";
				}
				else
				{
					Sensor sensor3 = sensor;
					int dBID = sensor.DBID;
					SQLiteConnection sqliteConnection_2 = activeUnit_0.ParentScen.DBConnection;
					sensor3.Name = DBFunctions.GetSensorName(dBID, ref sqliteConnection_2);
				}
			}
			return sensor;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100694", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Sensor result = new Sensor();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public bool GetCanPerformBDA(bool bool_0, bool bool_1)
	{
		switch (Type)
		{
		case Sensor_Type.Visual:
		case Sensor_Type.Infrared:
			return true;
		case Sensor_Type.Radar:
			if (bool_0 && Codes.Classification)
			{
				return true;
			}
			break;
		}
		if (bool_1 && IsSonar && !IsActive)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public bool GetSearchesInThisFrequency(FrequencyBand frequencyBand_0)
	{
		RadioElectronicFrequency[] searchFreqs = SearchFreqs;
		for (int i = 0; i < searchFreqs.Length; i = checked(i + 1))
		{
			if (searchFreqs[i].Band == frequencyBand_0)
			{
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	public bool GetIlluminatesInThisFrequency(FrequencyBand frequencyBand_0)
	{
		RadioElectronicFrequency[] illuminationFreqs = IlluminationFreqs;
		int num = 0;
		while (true)
		{
			if (num < illuminationFreqs.Length)
			{
				if (illuminationFreqs[num].Band == frequencyBand_0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		return true;
	}

	[SpecialName]
	public bool GetCanJamThisSensor(Sensor sensor_0)
	{
		switch (sensor_0.Type)
		{
		case Sensor_Type.Infrared:
			if (Role != Sensor_Role.IRCM)
			{
				return false;
			}
			break;
		case Sensor_Type.Radar:
		case Sensor_Type.SemiActive:
			if (Role != Sensor_Role.ECM_OECM && Role != Sensor_Role.ECM_OECM_DECM)
			{
				return false;
			}
			break;
		case Sensor_Type.HullSonar_ActivePassive:
		case Sensor_Type.HullSonar_ActiveOnly:
		case Sensor_Type.TowedArray_ActiveOnly:
		case Sensor_Type.VDS_ActiveOnly:
		case Sensor_Type.DippingSonar_ActivePassive:
		case Sensor_Type.DippingSonar_ActiveOnly:
			if (Role != Sensor_Role.ECM_AcousticJammer)
			{
				return false;
			}
			break;
		}
		if (IsOperating)
		{
			if (InvokeOrder(sensor_0))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	public bool GetCanJamThisCommDevice(CommDevice commDevice_0)
	{
		if (IsOperating)
		{
			if (PushOrder(commDevice_0))
			{
				if (commDevice_0.Type == CommDevice.CommLinkType.Land_Line)
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	public bool GetCanSpoofThisSensor(Sensor sensor_0)
	{
		if (Information.IsNothing(base.ParentPlatform))
		{
			return false;
		}
		if (Status == _ComponentStatus.Operational)
		{
			if (InvokeOrder(sensor_0))
			{
				switch (sensor_0.Type)
				{
				case Sensor_Type.Infrared:
					return Role == Sensor_Role.IRCM;
				case Sensor_Type.Radar:
				case Sensor_Type.SemiActive:
					if (!IsDECM)
					{
						return IsOECM;
					}
					return true;
				default:
					return false;
				case Sensor_Type.HullSonar_ActivePassive:
				case Sensor_Type.HullSonar_ActiveOnly:
				case Sensor_Type.TowedArray_ActiveOnly:
				case Sensor_Type.VDS_ActiveOnly:
				case Sensor_Type.DippingSonar_ActivePassive:
				case Sensor_Type.DippingSonar_ActiveOnly:
					return Role == Sensor_Role.ECM_AcousticJammer;
				}
			}
			return false;
		}
		return false;
	}

	public void PostDeserializationHousekeeping(ref Scenario scenario_0)
	{
		try
		{
			if (propertyFacade.Count <= 0)
			{
				return;
			}
			foreach (string item in propertyFacade)
			{
				Weapon weapon = (Weapon)scenario_0.ActiveUnits[item];
				if (!Information.IsNothing(weapon))
				{
					SemiActiveWeaponsGuided.Add(weapon);
					weapon.SensorProvidingFireControlForMe = this;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100700", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public bool GetIsPrecise(float float_0)
	{
		try
		{
			if (IsSonar)
			{
				if (IsActive)
				{
					return true;
				}
				return false;
			}
			switch (Type)
			{
			case Sensor_Type.Radar:
			{
				if (IsOTH)
				{
					return false;
				}
				if (CanPerformIllumination)
				{
					return true;
				}
				if (Capabilities.SpaceSearch_ABM && (Role == Sensor_Role.Radar_BallisticMissileBattleManagement || Role == Sensor_Role.Radar_BallisticMissileEngagement || Role == Sensor_Role.Radar_BallisticMissileTracker))
				{
					return true;
				}
				RadioElectronicFrequency[] searchFreqs = SearchFreqs;
				for (int i = 0; i < searchFreqs.Length; i = checked(i + 1))
				{
					if ((ulong)(searchFreqs[i].Band - 1003) <= 10uL)
					{
						return true;
					}
				}
				return false;
			}
			case Sensor_Type.Visual:
				if (float_0 < 2f * _UtilsFacade)
				{
					return true;
				}
				return false;
			case Sensor_Type.Infrared:
				if (Codes.Classification)
				{
					return float_0 < 2f * m_SingletonFacade;
				}
				return float_0 < 1f * m_SingletonFacade;
			default:
				return RangeResolution_Nominal == 0f || AngleResolution == 0f;
			case Sensor_Type.PingIntercept:
				return false;
			case Sensor_Type.MAD:
				return false;
			case Sensor_Type.ESM:
			case Sensor_Type.PCLS:
				return false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100701", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[SpecialName]
	public bool GetCanTrackThisContact_AAWFireControlGrade(Contact contact_0, bool bool_0 = false)
	{
		if (contact_0 == null)
		{
			return false;
		}
		Module_Unit.Unit.LOSCheckResult? nullable_ = null;
		bool? nullable_2 = null;
		bool? nullable_3 = null;
		bool? nullable_4 = null;
		bool? nullable_5 = null;
		bool? nullable_6 = null;
		if (contact_0.ActualUnit == null)
		{
			return false;
		}
		if (GetIsSuitableForThisTarget(contact_0.ActualUnit))
		{
			float num = 5f;
			if (IsContinousTrackingCapable)
			{
				num = Math.Max(num, ScanInterval);
			}
			if (Type == Sensor_Type.Radar)
			{
				if (GetIsPrecise(Module_Unit.RangeToUnit_Slant(base.ParentPlatform, contact_0.ActualUnit)) && base.ParentPlatform.Sensory.RunDic(contact_0, num, Sensor_Type.Radar))
				{
					return true;
				}
			}
			else
			{
				if (!base.ParentPlatform.Sensory.RunDic(contact_0, num, Type))
				{
					return false;
				}
				if (Codes.GeneratesAAWFireControl && (IsOperating || bool_0))
				{
					ActiveUnit parentPlatform = base.ParentPlatform;
					ActiveUnit actualUnit = contact_0.ActualUnit;
					List<Geopoint_Struct> list_ = null;
					float float_ = Module_Unit.RangeToUnit_Slant(base.ParentPlatform, contact_0.ActualUnit);
					Lazy<Dictionary<int, EmissionContainer>> lazy_ = null;
					if (CanDetectTarget(DetectionAttemptType.WeaponGuidance, parentPlatform, actualUnit, ref list_, float_, ref lazy_, null, ref nullable_2, ref nullable_3, ref nullable_, ref nullable_4, ref nullable_5, ref nullable_6))
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	public bool GetCanSweepThisMine(UnguidedWeapon unguidedWeapon_0)
	{
		bool result = false;
		if (IsMineCountermeasure)
		{
			switch (Type)
			{
			case Sensor_Type.MineSweep_TwoShipMagneticInfluence:
				result = unguidedWeapon_0.Type != Weapon._WeaponType.MooredMine && unguidedWeapon_0.Type != Weapon._WeaponType.FloatingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DriftingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_MechanicalCableCutter:
				result = unguidedWeapon_0.Type == Weapon._WeaponType.MooredMine || unguidedWeapon_0.Type == Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_MagneticInfluence:
				result = unguidedWeapon_0.Type != Weapon._WeaponType.MooredMine && unguidedWeapon_0.Type != Weapon._WeaponType.FloatingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DriftingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_AcousticInfluence:
				result = unguidedWeapon_0.Type != Weapon._WeaponType.MooredMine && unguidedWeapon_0.Type != Weapon._WeaponType.FloatingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DriftingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineSweep_MultiInfluence:
				result = unguidedWeapon_0.Type != Weapon._WeaponType.MooredMine && unguidedWeapon_0.Type != Weapon._WeaponType.FloatingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DriftingMine && unguidedWeapon_0.Type != Weapon._WeaponType.DummyMine;
				break;
			case Sensor_Type.MineNeutralization_DiverExplosiveCharge:
				result = true;
				break;
			case Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal:
				result = true;
				break;
			case Sensor_Type.MineNeutralization_MooredMineCableCutter:
				result = unguidedWeapon_0.Type == Weapon._WeaponType.MooredMine || unguidedWeapon_0.Type == Weapon._WeaponType.DummyMine;
				break;
			}
			if (base.ParentPlatform.IsWeapon & (base.ParentPlatform.SubType == 4101) & (unguidedWeapon_0.Type == Weapon._WeaponType.FloatingMine || unguidedWeapon_0.Type == Weapon._WeaponType.DriftingMine))
			{
				result = true;
			}
			return result;
		}
		return false;
	}

	[SpecialName]
	public bool GetCanTriggerThisMine(UnguidedWeapon unguidedWeapon_0)
	{
		bool result = false;
		if (IsMineCountermeasure)
		{
			switch (Type)
			{
			case Sensor_Type.MineSweep_AcousticInfluence:
			case Sensor_Type.MineSweep_MultiInfluence:
				result = unguidedWeapon_0.Flags.Mine_PassiveBroadBandAcousticFuze || unguidedWeapon_0.Flags.Mine_PassiveNarrowBandAcousticFuze;
				break;
			case Sensor_Type.MineNeutralization_DiverExplosiveCharge:
				result = true;
				break;
			case Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal:
				result = true;
				break;
			case Sensor_Type.MineSweep_MagneticInfluence:
			case Sensor_Type.MineSweep_TwoShipMagneticInfluence:
				result = unguidedWeapon_0.Flags.Mine_SimpleMagneticFuze || unguidedWeapon_0.Flags.Mine_TotalFieldMagnetometerFuze;
				break;
			}
			if (base.ParentPlatform.IsWeapon & (base.ParentPlatform.SubType == 4101) & (unguidedWeapon_0.Type == Weapon._WeaponType.FloatingMine || unguidedWeapon_0.Type == Weapon._WeaponType.DriftingMine))
			{
				result = true;
			}
			return result;
		}
		return false;
	}

	[SpecialName]
	public float GetProbabilityToSweepThisMine(UnguidedWeapon unguidedWeapon_0)
	{
		Sensor_Type type = Type;
		if (1 == 0)
		{
		}
		float result = type switch
		{
			Sensor_Type.MineSweep_TwoShipMagneticInfluence => 0.3f, 
			Sensor_Type.MineSweep_MechanicalCableCutter => 0.4f, 
			Sensor_Type.MineSweep_MagneticInfluence => 0.3f, 
			Sensor_Type.MineSweep_AcousticInfluence => 0.3f, 
			Sensor_Type.MineSweep_MultiInfluence => 0.6f, 
			Sensor_Type.MineNeutralization_DiverExplosiveCharge => 0.8f, 
			Sensor_Type.MineNeutralization_ExplosiveChargeMineDisposal => 0.6f, 
			Sensor_Type.MineNeutralization_MooredMineCableCutter => 0.4f, 
			_ => 0f, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[SpecialName]
	public bool GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType activeUnitType_0)
	{
		if (Type == Sensor_Type.ESM)
		{
			return true;
		}
		if (Type == Sensor_Type.PingIntercept)
		{
			return true;
		}
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			return Capabilities.AirSearch;
		case GlobalVariables.ActiveUnitType.Ship:
			return Capabilities.SurfaceSearch;
		case GlobalVariables.ActiveUnitType.Submarine:
			if (Role != Sensor_Role.TASSActiveOnlyTowedArraySonarSystem && Role != Sensor_Role.TASSPassiveTorpedoWarningTowedArraySonarSystem)
			{
				return Capabilities.SubSearch;
			}
			return true;
		case GlobalVariables.ActiveUnitType.Facility:
			if (!Capabilities.LandSearch_Fixed)
			{
				return Capabilities.LandSearch_Mobile;
			}
			return true;
		default:
			return false;
		case GlobalVariables.ActiveUnitType.Weapon:
			if (!Capabilities.AirSearch && !Capabilities.SpaceSearch_ABM)
			{
				return Capabilities.C_RAM;
			}
			return true;
		case GlobalVariables.ActiveUnitType.Satellite:
			return Capabilities.SpaceSearch_ABM;
		case GlobalVariables.ActiveUnitType.Vehicle:
		case GlobalVariables.ActiveUnitType.Personnel:
			return Capabilities.LandSearch_Mobile;
		}
	}

	[SpecialName]
	public bool GetIsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType activeUnitType_0, Weapon weapon_0)
	{
		try
		{
			if (Type == Sensor_Type.ESM)
			{
				if (weapon_0.ValidTargets.Radar)
				{
					if (!(weapon_0.MaxAirRange <= 0f))
					{
						return true;
					}
					if (weapon_0.MaxSurfaceRange > 0f)
					{
						return true;
					}
				}
				if (weapon_0.IsDecoy)
				{
					return true;
				}
			}
			if (Type == Sensor_Type.PingIntercept)
			{
				return true;
			}
			switch (activeUnitType_0)
			{
			case GlobalVariables.ActiveUnitType.Ship:
				if (!IsSonar && !IsPingIntercept)
				{
					if (weapon_0.ValidTargets.SurfaceVessel)
					{
						return Capabilities.SurfaceSearch;
					}
					break;
				}
				return true;
			case GlobalVariables.ActiveUnitType.Submarine:
				if (weapon_0.ValidTargets.Submarine)
				{
					return Capabilities.SubSearch;
				}
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				if (weapon_0.ValidTargets.LandStructure_Hard || weapon_0.ValidTargets.LandStructure_Soft || weapon_0.ValidTargets.MobileTarget_Hard || weapon_0.ValidTargets.MobileTarget_Soft)
				{
					return Capabilities.LandSearch_Fixed || Capabilities.LandSearch_Mobile;
				}
				break;
			case GlobalVariables.ActiveUnitType.Aircraft:
			case GlobalVariables.ActiveUnitType.Weapon:
				if (weapon_0.ValidTargets.Aircraft || weapon_0.ValidTargets.Helicopter || weapon_0.ValidTargets.Missile)
				{
					return Capabilities.AirSearch;
				}
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				if (weapon_0.ValidTargets.Satellite)
				{
					return Capabilities.SpaceSearch_ABM;
				}
				break;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100703", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public bool TargetIsWithinRadarVelocityFilter(ActiveUnit activeUnit_0)
	{
		int num = 0;
		int num2 = 0;
		if (Capabilities.AirSearch)
		{
			num = 0;
			num2 = 3300;
		}
		if (Capabilities.SpaceSearch_ABM)
		{
			num = 1980;
			num2 = 19800;
		}
		if (Capabilities.AirSearch && Capabilities.SpaceSearch_ABM)
		{
			num = 0;
			num2 = 19800;
		}
		if (activeUnit_0.CurrentSpeed > (float)num && activeUnit_0.CurrentSpeed < (float)num2)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	public bool GetIsSuitableForThisTarget(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 == null)
		{
			return false;
		}
		try
		{
			if (Type == Sensor_Type.ESM)
			{
				if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsFacility)
				{
					if (activeUnit_0.HasEmittingSensors && !activeUnit_0.IsUnderground && !activeUnit_0.IsUnderwater)
					{
						return true;
					}
					return false;
				}
				return true;
			}
			if (Role == Sensor_Role.IR_MAWS && activeUnit_0.IsWeapon)
			{
				return true;
			}
			if (Type == Sensor_Type.PingIntercept)
			{
				if (activeUnit_0.IsSubmarine || activeUnit_0.IsShip)
				{
					return true;
				}
				if (activeUnit_0.IsWeapon)
				{
					if (activeUnit_0.IsTorpedo)
					{
						return true;
					}
					if (((Weapon)activeUnit_0).Type == Weapon._WeaponType.Sonobuoy)
					{
						return true;
					}
				}
				if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
				{
					return true;
				}
			}
			if (activeUnit_0.IsAerospaceUnit && Type == Sensor_Type.Radar && !TargetIsWithinRadarVelocityFilter(activeUnit_0))
			{
				return false;
			}
			if (activeUnit_0.IsAircraft)
			{
				if (((Aircraft)activeUnit_0).IsAerostat)
				{
					return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship) || GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility);
				}
				return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft);
			}
			if (activeUnit_0.IsShip)
			{
				return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship);
			}
			if (activeUnit_0.IsSubmarine)
			{
				if ((((Submarine)activeUnit_0).IsSurfaced || (Capabilities.PeriscopeSearch && ((Submarine)activeUnit_0).IsAtPeriscopeDepth)) && GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship))
				{
					return true;
				}
				return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine);
			}
			if (activeUnit_0.IsFacility)
			{
				if (GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility))
				{
					if (((Facility)activeUnit_0).RepresentsMobileGroundUnit)
					{
						return Capabilities.LandSearch_Mobile;
					}
					return Capabilities.LandSearch_Fixed;
				}
				return false;
			}
			if (activeUnit_0.IsMobileGroundUnit)
			{
				return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Vehicle) || GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Personnel);
			}
			if (activeUnit_0.IsWeapon)
			{
				switch (((Weapon)activeUnit_0).Type)
				{
				case Weapon._WeaponType.Rocket:
					if ((double)((Weapon)activeUnit_0).Diameter < 0.1)
					{
						return Capabilities.C_RAM;
					}
					return Capabilities.AirSearch || Capabilities.C_RAM;
				case Weapon._WeaponType.GuidedWeapon:
					return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Weapon);
				case Weapon._WeaponType.UAV_Expendable:
					return Capabilities.AirSearch;
				case Weapon._WeaponType.Decoy_Vehicle:
					if (((Weapon)activeUnit_0).IsMobileDecoy_Air)
					{
						return Capabilities.AirSearch;
					}
					if (((Weapon)activeUnit_0).IsMobileDecoy_Surface)
					{
						return Capabilities.SurfaceSearch;
					}
					if (((Weapon)activeUnit_0).IsMobileDecoy_Sub)
					{
						return Capabilities.SubSearch;
					}
					break;
				case Weapon._WeaponType.BallisticMissile:
					return Capabilities.SpaceSearch_ABM || GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft);
				case Weapon._WeaponType.Torpedo:
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.MooredMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.DriftingMine:
					return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine);
				case Weapon._WeaponType.RV:
				case Weapon._WeaponType.HGV:
					return GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite) || GetIsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Weapon);
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100704", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	[SpecialName]
	private bool? ParentHasNoVisualSensor()
	{
		if (!_SetterFacade.HasValue)
		{
			_SetterFacade = true;
			Sensor[] array = base.ParentPlatform.Sensors_ReadOnly();
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				if (DBID != sensor.DBID && sensor.Type == Sensor_Type.Visual)
				{
					_SetterFacade = false;
					break;
				}
			}
		}
		return _SetterFacade;
	}

	public Sensor(ref SQLiteConnection sqliteConnection_0, int int_0, string string_0, Sensor_Type sensor_Type_0, Sensor_Role sensor_Role_0, GlobalVariables.TechGenerationClass techGenerationClass_0, float float_0, float float_1, byte byte_0, byte byte_1, int int_1, int int_2, float float_2, float float_3, float float_4, float float_5, int int_3, float float_6, float float_7, float float_8, bool bool_0, short short_0 = 0, short short_1 = 0, short short_2 = 0, short short_3 = 0, float float_9 = 0f, long long_0 = 0L, long long_1 = 0L, long long_2 = 0L, long long_3 = 0L, float float_10 = 0f, float float_11 = 0f, float float_12 = 0f, float float_13 = 0f, float float_14 = 0f, float float_15 = 0f, short MineSweepWidth = 0, short MineSweepMaximumSpeed = 0, float float_16 = 0f, float float_17 = 0f, float float_18 = 0f, float float_19 = 0f, bool bool_1 = false)
	{
		Capabilities = default(_Capabilities);
		Codes = default(_Codes);
		SearchFreqs = new RadioElectronicFrequency[0];
		IlluminationFreqs = new RadioElectronicFrequency[0];
		_ReaderFacade = new List<Contact>();
		SemiActiveWeaponsGuided = new List<Weapon>();
		propertyFacade = new List<string>();
		Coverage_Illuminate = new _Coverage();
		IsSensorInLoadout = false;
		IsSensorInMount = false;
		IsSensorInGroup = -1;
		MastHeight = 0;
		MaxElevationAngle = 30f;
		MinElevationAngle = -30f;
		MaxAntennaElevationAngle = 30f;
		MinAntennaElevationAngle = -30f;
		m_RecordFacade = 0.5f;
		m_ExceptionFacade = 0.5f;
		m_ComparatorFacade = true;
		_SetterFacade = null;
		creatorFacade = null;
		SensorList = new ThreadLocal<List<Sensor>>();
		try
		{
			DBID = int_0;
			maxRange = float_0;
			minRange = float_1;
			Name = string_0;
			MaxIlluminate = int_2;
			MaxAltitude_AGL = float_2;
			MinAltitude_AGL = float_3;
			MaxAltitude_ASL = float_4;
			MinAltitude_ASL = float_5;
			Type = sensor_Type_0;
			Role = sensor_Role_0;
			TechGeneration = techGenerationClass_0;
			ScanInterval = int_3;
			HeightResolution = float_8;
			classFacade = short_0;
			_RequestFacade = short_1;
			valueFacade = short_2;
			_TokenizerFacade = short_3;
			m_StubFacade = float_9;
			m_UpperFreq = long_0;
			m_LowerFreq = long_1;
			m_UpperFreqIlluminate = long_2;
			m_LowerFreqIlluminate = long_3;
			m_MineSweepWidth = MineSweepWidth;
			m_MineSweepMaximumSpeed = MineSweepMaximumSpeed;
			schemaFacade = Math.Max(1f, float_16);
			_UtilsFacade = Math.Max(1f, float_17);
			m_PredicateFacade = Math.Max(1f, float_18);
			m_SingletonFacade = Math.Max(1f, float_19);
			if (Type == Sensor_Type.ESM)
			{
				Sensor sensor_ = this;
				DBFunctions.GetESMSpecificParameters(ref sensor_, sqliteConnection_0);
			}
			if (Type == Sensor_Type.Radar || Type == Sensor_Type.Microwave_Emitter)
			{
				Sensor sensor_2 = this;
				DBFunctions.GetRadarSpecificParameters(ref sensor_2, sqliteConnection_0);
			}
			_ProccesorFacade = float_10;
			m_StrategyFacade = float_11;
			configurationFacade = float_12;
			m_ECMNumberOfTargets = float_13;
			m_ECMPoKReduction = float_14;
			if (IsSonar || IsPingIntercept)
			{
				RangeResolution_Nominal = (float)(0.2 * (double)maxRange);
				switch (TechGeneration)
				{
				default:
					AngleResolution = 2f;
					break;
				case GlobalVariables.TechGenerationClass.Early1950s:
				case GlobalVariables.TechGenerationClass.Late1950s:
					AngleResolution = 30f;
					break;
				case GlobalVariables.TechGenerationClass.Early1960s:
				case GlobalVariables.TechGenerationClass.Late1960s:
					AngleResolution = 25f;
					break;
				case GlobalVariables.TechGenerationClass.Early1970s:
				case GlobalVariables.TechGenerationClass.Late1970s:
					AngleResolution = 20f;
					break;
				case GlobalVariables.TechGenerationClass.Early1980s:
				case GlobalVariables.TechGenerationClass.Late1980s:
					AngleResolution = 15f;
					break;
				case GlobalVariables.TechGenerationClass.Early1990s:
				case GlobalVariables.TechGenerationClass.Late1990s:
					AngleResolution = 10f;
					break;
				case GlobalVariables.TechGenerationClass.Early2000s:
				case GlobalVariables.TechGenerationClass.Late2000s:
					AngleResolution = 5f;
					break;
				}
			}
			AngleResolution = float_7;
			if (AngleResolution == 0f)
			{
				AngleResolution = float_15;
			}
			if (AngleResolution == 0f)
			{
				AngleResolution = 5f;
			}
			if (!bool_0)
			{
				Sensor sensor_3 = this;
				DBFunctions.GetSensorCapabilities(ref sensor_3, int_0, sqliteConnection_0);
				sensor_3 = this;
				DBFunctions.GetSensorCodes(ref sensor_3, int_0, sqliteConnection_0);
				sensor_3 = this;
				DBFunctions.GetSensorSearchFreqs(ref sensor_3, int_0, sqliteConnection_0);
				sensor_3 = this;
				DBFunctions.GetSensorIlluminationFreqs(ref sensor_3, int_0, sqliteConnection_0);
			}
			if (IsPureIlluminator)
			{
				Codes.ContinousTrackingCapable_RadarTracker = true;
			}
			if ((IsSonar || IsPingIntercept) && !HasActiveModeOnly)
			{
				Codes.ContinuousTrackingCapable = true;
			}
			if (Type == Sensor_Type.MAD && AngleResolution == 0f)
			{
				AngleResolution = 2f;
			}
			LockRandom lockRandom_ = GameGeneral.LockRandom_0;
			TimeToNextScan = lockRandom_.Next(0, ScanInterval);
			TimeToNextScan_Full = 0;
			Hypothetical = bool_1;
			if (Type == Sensor_Type.Radar)
			{
				CalculateRadarResolutionCell();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100706", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool PointDefenceJam(ref Sensor sensor_0, ref ActiveUnit activeUnit_0, List<string> list_0)
	{
		try
		{
			float indexerFacade = m_ECMPoKReduction;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			float num = 0f;
			if (TechGeneration == GlobalVariables.TechGenerationClass.NotApplicable)
			{
				num = indexerFacade;
			}
			else if (Role == Sensor_Role.IRCM)
			{
				num = indexerFacade;
			}
			else
			{
				int num2 = TechGeneration - sensor_0.TechGeneration;
				if (num2 < -3)
				{
					num = indexerFacade - 15f;
				}
				else if (num2 == -3)
				{
					num = indexerFacade - 10f;
				}
				else if (num2 == -2)
				{
					num = indexerFacade - 5f;
				}
				else if (num2 == -1)
				{
					num = indexerFacade;
				}
				else if (num2 == 0)
				{
					num = indexerFacade;
				}
				else if (num2 == 1)
				{
					num = indexerFacade;
				}
				else if (num2 == 2)
				{
					num = indexerFacade + 5f;
				}
				else if (num2 == 3)
				{
					num = indexerFacade + 10f;
				}
				else if (num2 > 3)
				{
					num = indexerFacade + 15f;
				}
			}
			if (sensor_0.Type == Sensor_Type.Radar && sensor_0.Codes.AESA)
			{
				num -= 30f;
			}
			num = Math.Max(num, 5f);
			stringBuilder.Append("防守干扰机（" + Misc.ReadRequest(Name) + ";技术：" + Misc.MapRequest(TechGeneration) + "） 上" + activeUnit_0.Name + "试图欺骗传感器：" + Misc.ReadRequest(sensor_0.Name) + "（技术：" + Misc.MapRequest(sensor_0.TechGeneration) + "）（的：" + sensor_0.ParentPlatform.Name + "）。最终概率：" + Conversions.ToString(Math.Round(num, 2)) + "%. ");
			int num3 = GameGeneral.LockRandom_0.Next(1, 101);
			bool result = false;
			string string_;
			if ((float)num3 <= num)
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num3) + " - 成功");
				string_ = Misc.ReadRequest(Name) + " 被干扰" + Misc.ReadRequest(sensor_0.Name) + " 成功";
				result = true;
			}
			else
			{
				stringBuilder.Append("结果：" + Conversions.ToString(num3) + " - 失败");
				string_ = Misc.ReadRequest(Name) + " 尝试干扰" + Misc.ReadRequest(sensor_0.Name) + " 失败";
			}
			base.ParentPlatform.ParentScen.AddMessage(stringBuilder.ToString(), string_, LoggedMessage.MessageType.WeaponEndgame, 10, ObjectID, null, new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			list_0?.Add(stringBuilder.ToString());
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100707", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void GoActive()
	{
		if (!importerFacade && Status == _ComponentStatus.Operational)
		{
			importerFacade = true;
			RaiseEventStatusChanged();
			TimeToNextScan = GameGeneral.LockRandom_0.Next(0, ScanInterval);
			TimeToNextScan_Full = 0;
		}
	}

	public void GoPassive()
	{
		if (importerFacade)
		{
			importerFacade = false;
			if (_ReaderFacade.Count > 0)
			{
				_ReaderFacade.Clear();
			}
			RaiseEventStatusChanged();
		}
	}

	public override void Damage(_DamageSeverityFactor _DamageSeverityFactor_0)
	{
		try
		{
			List<Contact> list = new List<Contact>();
			foreach (Contact item in _ReaderFacade)
			{
				list.Add(item);
			}
			foreach (Contact item2 in list)
			{
				StopTrackingTarget(item2);
			}
			if (CanBeActive && IsActive)
			{
				GoPassive();
			}
			base.Damage(_DamageSeverityFactor_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100708", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Destroy(Side side_0, bool bool_0, bool bool_1)
	{
		try
		{
			if (!bool_1)
			{
				base.Destroy(side_0, bool_0, bool_1);
			}
			List<Contact> list = new List<Contact>();
			foreach (Contact item in _ReaderFacade)
			{
				list.Add(item);
			}
			foreach (Contact item2 in list)
			{
				StopTrackingTarget(item2);
			}
			GoPassive();
			_Status = _ComponentStatus.Destroyed;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100709", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool CanIlluminateForThisWeapon(ref Weapon weapon_0)
	{
		if (Type == Sensor_Type.Radar && (m_RadarHorBeamwidth_Illuminate == 0f || m_RadarVerBeamwidth_Illuminate == 0f))
		{
			return false;
		}
		if (Type == Sensor_Type.LaserDesignator && weapon_0.Directors.Count == 0)
		{
			Sensor sensor = weapon_0.Sensors_ReadOnly()[0];
			if (sensor != null && sensor.Type == Sensor_Type.LaserSpotTracker)
			{
				return true;
			}
		}
		return weapon_0.Directors.Contains(DBID);
	}

	public bool CanDirectThisMount(ref Mount mount_0)
	{
		try
		{
			foreach (int compatibleDirector in mount_0.CompatibleDirectors)
			{
				if (compatibleDirector == DBID)
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100710", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void TrackTargetForFireControl(ref Contact contact_0)
	{
		try
		{
			if (!_ReaderFacade.Contains(contact_0))
			{
				_ReaderFacade.Add(contact_0);
			}
			if (CanBeActive)
			{
				if (!IsActive)
				{
					GoActive();
				}
				AssetWriter(contact_0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100711", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void AssetWriter(Contact contact_0)
	{
		try
		{
			foreach (ActiveUnit activeUnits_ in base.ParentPlatform.ParentScen.ActiveUnits_List)
			{
				if (!Information.IsNothing(activeUnits_) && activeUnits_.IsWeapon && !Information.IsNothing(activeUnits_.AI.PrimaryTarget) && activeUnits_.AI.PrimaryTarget == contact_0)
				{
					((Weapon)activeUnits_).BlindTime = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100712", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsTrackingThisTargetForFireControl(ref Contact contact_0)
	{
		if (IsActive)
		{
			return _ReaderFacade.Contains(contact_0);
		}
		return false;
	}

	public bool IsTrackingThisUnitForFireControl(ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (IsActive)
			{
				if (_ReaderFacade.Count < 1)
				{
					return false;
				}
				List<Contact> list = new List<Contact>();
				list.AddRange(_ReaderFacade.ToList());
				int num = list.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						Contact contact = list[num2];
						if (contact != null && contact.ActualUnit == activeUnit_0)
						{
							break;
						}
						num2++;
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200034", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void StopTrackingTarget(Contact contact_0, bool bool_0 = false)
	{
		try
		{
			if (!_ReaderFacade.Contains(contact_0))
			{
				return;
			}
			try
			{
				_ReaderFacade.Remove(contact_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200035", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				ProjectData.ClearProjectError();
			}
			if (!bool_0)
			{
				foreach (ActiveUnit value in base.ParentPlatform.ParentScen.ActiveUnits.Values)
				{
					if (value != null && value.IsWeapon && value.GetUnitSide() == base.ParentPlatform.GetUnitSide() && value.AI.PrimaryTarget == contact_0 && SemiActiveWeaponsGuided.Contains((Weapon)value))
					{
						try
						{
							SemiActiveWeaponsGuided.Remove((Weapon)value);
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2?.Data.Add("Error at 200036", exception_2.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			if (_ReaderFacade.Count == 0 && IsPureIlluminator)
			{
				GoPassive();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 100713", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool HasFireControlChannelAvailable()
	{
		return _ReaderFacade.Count < MaxIlluminate;
	}

	public bool CanDetectTarget_NonAU(ActiveUnit activeUnit_0, Module_Unit.Unit unit_0, float float_0)
	{
		try
		{
			if (maxRange < float_0)
			{
				return false;
			}
			if (TargetIsWithinCoverageArc(unit_0))
			{
				if (unit_0.GetType() == typeof(UnguidedWeapon) && ((UnguidedWeapon)unit_0).IsMine)
				{
					if (Type == Sensor_Type.Visual)
					{
						Weapon._WeaponType type = ((UnguidedWeapon)unit_0).Type;
						if (type != Weapon._WeaponType.FloatingMine && type != Weapon._WeaponType.DriftingMine)
						{
							return false;
						}
						float float_ = 0.16198704f;
						ForgotWriter(activeUnit_0, unit_0, ref float_);
						if (float_ <= float_0)
						{
							return false;
						}
						return true;
					}
					if ((IsSonar || IsPingIntercept) && IsActive && (GetSearchesInThisFrequency(FrequencyBand.HF_Sonar) || Capabilities.Mine_Obstacle_Search))
					{
						float num;
						switch (((UnguidedWeapon)unit_0).Type)
						{
						case Weapon._WeaponType.FloatingMine:
							num = 0.7f;
							break;
						case Weapon._WeaponType.BottomMine:
						case Weapon._WeaponType.MovingMine:
							num = 0.5f;
							break;
						case Weapon._WeaponType.MooredMine:
						case Weapon._WeaponType.RisingMine:
							num = 1f;
							break;
						case Weapon._WeaponType.DriftingMine:
							num = 0.7f;
							break;
						default:
							throw new NotImplementedException();
						case Weapon._WeaponType.DummyMine:
							num = 1f;
							break;
						}
						if (maxRange * num < float_0)
						{
							return false;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100714", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void ResetSensorFailureReport()
	{
		if (GameGeneral.PE_CompleteSensorFailureReport || GameGeneral.ReportCompleteSensorDetectionAttempt)
		{
			m_SensorDetectionFeedbackList = new List<SensorDetectionFeedback>();
		}
	}

	public bool? FeedSensorFailureItem(bool bool_0, SensorDetectionFeedback sensorDetectionFeedback_0, ref bool? nullable_0, bool bool_1 = false)
	{
		return bool_0;
	}

	public bool CanDetectTarget(DetectionAttemptType detectionAttemptType_0, ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref List<Geopoint_Struct> list_0, float float_0, ref Lazy<Dictionary<int, EmissionContainer>> lazy_0, List<ActiveUnit> list_1, ref bool? nullable_0, ref bool? nullable_1, ref Module_Unit.Unit.LOSCheckResult? nullable_2, ref bool? nullable_3, ref bool? nullable_4, ref bool? nullable_5)
	{
		if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0)._FacadeReader)
		{
			return true;
		}
		bool bool_ = false;
		bool? nullable_6 = null;
		if (maxRange < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_Range, ref nullable_6).HasValue)
		{
			return false;
		}
		if (!GetIsSuitableForThisTarget(activeUnit_1) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_TargetSuitability, ref nullable_6).HasValue)
		{
			return false;
		}
		if (!TargetIsWithinCoverageArc(activeUnit_1) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_CoveringArc, ref nullable_6).HasValue)
		{
			return false;
		}
		if (activeUnit_1 == null)
		{
			return false;
		}
		if (activeUnit_1.IsAerospaceUnit && !Capabilities.SpaceSearch_ABM)
		{
			if (MaxAltitude_AGL > 0f && activeUnit_1.GetCurrentAltitude() > MaxAltitude_AGL + activeUnit_0.GetCurrentAltitude() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_MaxAltitude_AGL, ref nullable_6).HasValue)
			{
				return false;
			}
			if (MinAltitude_AGL > 0f && activeUnit_1.GetCurrentAltitude() < MinAltitude_AGL + activeUnit_0.GetCurrentAltitude() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_MinAltitude_AGL, ref nullable_6).HasValue)
			{
				return false;
			}
			if (MaxAltitude_ASL > 0f && activeUnit_1.GetCurrentAltitude() > MaxAltitude_ASL && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_MaxAltitude_ASL, ref nullable_6).HasValue)
			{
				return false;
			}
			if (MinAltitude_ASL > 0f && activeUnit_1.GetCurrentAltitude() < MinAltitude_ASL && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_MinAltitude_ASL, ref nullable_6).HasValue)
			{
				return false;
			}
		}
		try
		{
			bool? flag = null;
			switch (Type)
			{
			case Sensor_Type.ESM:
				if (activeUnit_0.IsWeapon && !((Weapon)activeUnit_0).IsDecoy)
				{
					if (activeUnit_1.IsSatellite)
					{
						if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_WeaponESM_UnsuitableTarget_Satellite, ref nullable_6).HasValue)
						{
							return false;
						}
					}
					else if (((Weapon)activeUnit_0).MaxAirRange == 0f)
					{
						if ((activeUnit_1.IsAircraft | activeUnit_1.IsWeapon) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_WeaponESM_UnsuitableTarget_AircraftOrWeapon, ref nullable_6).HasValue)
						{
							return false;
						}
					}
					else if (((Weapon)activeUnit_0).MaxSurfaceRange == 0f && (activeUnit_1.IsShip || activeUnit_1.IsFacility) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_WeaponESM_UnsuitableTarget_ShipOrFacility, ref nullable_6).HasValue)
					{
						return false;
					}
				}
				flag = RegisterWriter(activeUnit_0, activeUnit_1, float_0, ref lazy_0, ref nullable_4, ref nullable_5, bool_);
				if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_ESM, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_ESM, ref nullable_6);
				}
				break;
			case Sensor_Type.Radar:
				flag = DefineWriter(activeUnit_0, activeUnit_1, float_0, list_1, ref nullable_0, ref nullable_1, bool_);
				if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_Radar, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_Radar, ref nullable_6);
				}
				break;
			case Sensor_Type.Visual:
				flag = OrderWriter(activeUnit_0, activeUnit_1, float_0, ref nullable_2, bool_);
				if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_Visual, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_Visual, ref nullable_6);
				}
				break;
			case Sensor_Type.Infrared:
				flag = ValidateOrder(activeUnit_0, activeUnit_1, float_0, ref nullable_2, bool_);
				if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_IR, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_IR, ref nullable_6);
				}
				break;
			case Sensor_Type.TowedArray_PassiveOnly:
			case Sensor_Type.TowedArray_ActivePassive:
			case Sensor_Type.TowedArray_ActiveOnly:
			{
				int landElevation = activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, activeUnit_0.ParentScen);
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), landElevation, activeUnit_0.ParentScen);
				float value = 0f;
				if (activeUnit_0.IsShip)
				{
					value = thermalLayerAtThisLocation.Floor - 20;
				}
				else if (activeUnit_0.IsSubmarine)
				{
					value = ((activeUnit_0.GetCurrentAltitude() <= (float)thermalLayerAtThisLocation.Floor || (float)(thermalLayerAtThisLocation.Ceiling + 30) <= activeUnit_0.GetCurrentAltitude()) ? ((float)(int)Math.Round(activeUnit_0.GetCurrentAltitude())) : ((float)(thermalLayerAtThisLocation.Floor - 20)));
				}
				bool flag3 = true;
				if (HasActiveModeOnly)
				{
					flag = ConnectOrder(activeUnit_0, activeUnit_1, float_0, nullable_3, value);
				}
				else if (IsActive)
				{
					flag = ConnectOrder(activeUnit_0, activeUnit_1, float_0, nullable_3, value);
				}
				else
				{
					flag3 = false;
					flag = ComputeOrder(activeUnit_0, activeUnit_1, float_0, lazy_0, bool_0: false, nullable_3, value);
				}
				if (flag3)
				{
					if (flag.Value)
					{
						FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_ActiveSonar, ref nullable_6);
					}
					else
					{
						FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_ActiveSonar, ref nullable_6);
					}
				}
				else if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_PassiveSonar, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_PassiveSonar, ref nullable_6);
				}
				break;
			}
			case Sensor_Type.PCLS:
				new List<ActiveUnit>();
				foreach (ActiveUnit activeUnits_ in activeUnit_0.ParentScen.ActiveUnits_List)
				{
					Sensor[] sensors_Cached = activeUnits_.Sensors_Cached;
					Sensor[] array = sensors_Cached;
					foreach (Sensor sensor in array)
					{
						if (sensor.Type == Sensor_Type.NonDetectingEmitter && PublishWriter(activeUnit_0, activeUnits_, sensor, activeUnit_1, float_0, list_1, ref nullable_0, ref nullable_1, bool_) && FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.GENERAL_SuccessfullDetection_FromOneOfThePCLS, ref nullable_6).HasValue)
						{
							return true;
						}
					}
				}
				if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_FailedDetection_FromAllThePCLS, ref nullable_6).HasValue)
				{
					return false;
				}
				break;
			case Sensor_Type.VDS_PassiveOnly:
			case Sensor_Type.VDS_ActivePassive:
			case Sensor_Type.VDS_ActiveOnly:
			case Sensor_Type.DippingSonar_PassiveOnly:
			case Sensor_Type.DippingSonar_ActivePassive:
			case Sensor_Type.DippingSonar_ActiveOnly:
			{
				SonarModel.ThermoclineLayer thermalLayerAtThisLocation2 = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen), activeUnit_0.ParentScen);
				float value2 = ((GameGeneral.LockRandom_0.Next(0, 101) <= 50) ? ((float)(thermalLayerAtThisLocation2.Floor - 30)) : ((float)(int)Math.Round((double)thermalLayerAtThisLocation2.Ceiling / 2.0)));
				bool flag4 = true;
				if (HasActiveModeOnly)
				{
					flag = ConnectOrder(activeUnit_0, activeUnit_1, float_0, nullable_3, value2);
				}
				else if (IsActive)
				{
					flag = ConnectOrder(activeUnit_0, activeUnit_1, float_0, nullable_3, value2);
				}
				else
				{
					flag = ComputeOrder(activeUnit_0, activeUnit_1, float_0, lazy_0, bool_0: false, nullable_3, value2);
					flag4 = false;
				}
				if (flag4)
				{
					if (flag.Value)
					{
						FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_ActiveSonar, ref nullable_6);
					}
					else
					{
						FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_ActiveSonar, ref nullable_6);
					}
				}
				else if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_DippingAndVDS_PassiveSonar, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_DippingAndVDS_PassiveSonar, ref nullable_6);
				}
				break;
			}
			default:
				FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_Other, ref nullable_6);
				return false;
			case Sensor_Type.PingIntercept:
				flag = MoveOrder(activeUnit_0, activeUnit_1, float_0, lazy_0, nullable_3);
				if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_PingIntercept, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_PingIntercept, ref nullable_6);
				}
				break;
			case Sensor_Type.MAD:
				flag = ManageWriter(activeUnit_0, activeUnit_1, float_0);
				if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_MAD, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_MAD, ref nullable_6);
				}
				break;
			case Sensor_Type.HullSonar_PassiveOnly:
			case Sensor_Type.HullSonar_ActivePassive:
			case Sensor_Type.HullSonar_ActiveOnly:
			case Sensor_Type.BottomFixedSonar_PassiveOnly:
			{
				bool flag2 = true;
				if (HasActiveModeOnly)
				{
					flag = ConnectOrder(activeUnit_0, activeUnit_1, float_0, nullable_3);
				}
				else if (IsActive)
				{
					flag = ConnectOrder(activeUnit_0, activeUnit_1, float_0, nullable_3);
				}
				else
				{
					flag = ComputeOrder(activeUnit_0, activeUnit_1, float_0, lazy_0, bool_0: false, nullable_3);
					flag2 = false;
				}
				if (flag2)
				{
					if (flag.Value)
					{
						FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_HullandBottomFixed_ActiveSonar, ref nullable_6);
					}
					else
					{
						FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_HullandBottomFixed_ActiveSonar, ref nullable_6);
					}
				}
				else if (flag.Value)
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_SuccessfullDetection_HullandBottomFixed_PassiveSonar, ref nullable_6);
				}
				else
				{
					FeedSensorFailureItem(flag.Value, SensorDetectionFeedback.GENERAL_FailedDetection_HullandBottomFixed_PassiveSonar, ref nullable_6);
				}
				break;
			}
			}
			bool? flag5 = flag;
			flag5 = flag5;
			if (flag5.GetValueOrDefault() && !ActiveUnit_Sensory.DetectionIsPrecise(this, Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1)) && (!activeUnit_1.IsFixedFacility || Type == Sensor_Type.ESM))
			{
				list_0 = ((lazy_0 == null || !lazy_0.IsValueCreated) ? activeUnit_0.Sensory.GetUncertaintyArea(this, activeUnit_1, Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1), null) : activeUnit_0.Sensory.GetUncertaintyArea(this, activeUnit_1, Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1), lazy_0.Value));
			}
			if (nullable_6.HasValue)
			{
				return nullable_6.Value;
			}
			return flag.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100715", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool PrintWriter(float float_0, float float_1, float float_2)
	{
		float num = float_0 - float_1;
		if (num <= 0f)
		{
			if ((double)(num / m_ExceptionFacade) > (double)float_2 * 1852.0)
			{
				return true;
			}
		}
		else if ((double)(num / m_RecordFacade) > (double)float_2 * 1852.0)
		{
			return true;
		}
		return false;
	}

	private bool DefineWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, List<ActiveUnit> list_0, ref bool? nullable_0, ref bool? nullable_1, bool bool_0 = false)
	{
		try
		{
			bool? nullable_2 = null;
			if (Capabilities.OTH_SurfaceWave)
			{
				if (nullable_1.HasValue)
				{
					bool? flag = nullable_1;
					if (((!flag) ?? flag).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_RadarLOS_SurfaceWave, ref nullable_2).HasValue)
					{
						return false;
					}
				}
			}
			else if (nullable_0.HasValue)
			{
				bool? flag2 = nullable_0;
				if (((!flag2) ?? flag2).GetValueOrDefault() && !GameGeneral.PE_CompleteSensorFailureReport && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_RadarLOS, ref nullable_2).HasValue)
				{
					return false;
				}
			}
			if (VariableMaxRange && !Coverage.Has360Coverage())
			{
				List<RangeSymbol> list = PlatformComponent.RangeWedges_GetArcs(new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()), this, maxRange);
				float float_ = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit_1);
				float num = 0f;
				foreach (RangeSymbol item in list)
				{
					double num2 = Math.Abs(MathFunctions.DeleteRequest((float)Math2.ReadClass(item.LeftArc, item.RightArc), float_));
					if (num2 > (double)num)
					{
						num = (float)num2;
					}
				}
				if (num > 90f)
				{
					num -= 90f;
				}
				if (GetmaxRangeAtAngle(num) < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.GENERAL_Range, ref nullable_2).HasValue)
				{
					return false;
				}
			}
			if (IsPureIlluminator)
			{
				if (LoginOrder(activeUnit_0, activeUnit_1, float_0, list_0, bool_0: true, bool_1: false, ref nullable_0, ref nullable_1) == SensorDetectionCheckResult.Success)
				{
					if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.RADAR_PureIlluminatorSuccessfulDetection, ref nullable_2).HasValue)
					{
						return true;
					}
				}
				else if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_PureIlluminatorFailedDetection, ref nullable_2).HasValue)
				{
					return false;
				}
			}
			if (activeUnit_1.IsSubmarine && Math.Round(activeUnit_1.GetCurrentAltitude()) >= -20.0)
			{
				switch (((Submarine)activeUnit_1).Type)
				{
				case Submarine._SubmarineType.None:
				case Submarine._SubmarineType.Biologics:
				case Submarine._SubmarineType.FalseTarget:
					if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_SubUnitAbovePeriscopeDepthNotDetectable_BiologicsOrFalseContact, ref nullable_2).HasValue)
					{
						return false;
					}
					break;
				case Submarine._SubmarineType.SDV:
				case Submarine._SubmarineType.ROV:
				case Submarine._SubmarineType.UUV:
					if (activeUnit_1.GetCurrentAltitude() < 0f && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_SubUnitAbovePeriscopeDepthNotDetectable_NoPeriscopeOrSnorkel, ref nullable_2).HasValue)
					{
						return false;
					}
					break;
				}
			}
			if (activeUnit_1.IsSubmarine && Math.Round(activeUnit_1.GetCurrentAltitude()) >= -20.0 && activeUnit_1.GetCurrentAltitude() < -5f && !Capabilities.PeriscopeSearch && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_CantDetectPeriscope, ref nullable_2).HasValue)
			{
				return false;
			}
			if (!activeUnit_0.IsSatellite && PrintWriter(activeUnit_1.GetCurrentAltitude(), activeUnit_0.GetCurrentAltitude(), float_0) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_BlindCone, ref nullable_2).HasValue)
			{
				return false;
			}
			if ((activeUnit_1.IsAircraft || activeUnit_1.IsMissile) && activeUnit_0.GetCurrentAltitude() > activeUnit_1.GetCurrentAltitude() && !Codes.Doppler_LDSD_Full)
			{
				float value = (float)Geodesic_Vincenty.EnableInvocation(Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1), activeUnit_0.GetCurrentAltitude(), activeUnit_1.GetCurrentAltitude());
				if (Codes.Doppler_LDSD_Limited && Math.Abs(value) > 15f)
				{
					if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_LDSD_Limited_LookDown15deg, ref nullable_2).HasValue)
					{
						return false;
					}
				}
				else if (!Codes.Doppler_LDSD_Limited && Math.Abs(value) > 5f && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_LDSD_Limited_LookDown5deg, ref nullable_2).HasValue)
				{
					return false;
				}
			}
			ActiveUnit parentPlatform = base.ParentPlatform;
			string string_ = "";
			float float_2 = Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_));
			XSection._SignatureType signatureType_ = ((GetSearchesInThisFrequency(FrequencyBand.A_Band) || GetSearchesInThisFrequency(FrequencyBand.B_Band) || GetSearchesInThisFrequency(FrequencyBand.C_Band) || GetSearchesInThisFrequency(FrequencyBand.D_Band)) ? XSection._SignatureType.Radar_A_D : XSection._SignatureType.Radar_E_M);
			XSection xSection = smethod_0(activeUnit_1, signatureType_);
			if (xSection == null)
			{
				xSection = smethod_0(activeUnit_1, signatureType_);
			}
			if (xSection == null && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_Other, ref nullable_2).HasValue)
			{
				return false;
			}
			if (xSection.isDBInvisible(activeUnit_1) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.DB_Invisible, ref nullable_2).HasValue)
			{
				return false;
			}
			float float_3 = RadarModel.LoginWriter(xSection, activeUnit_1, float_2);
			if (activeUnit_1.IsPlatform && ((Platform)activeUnit_1).RepresentsMobileGroundUnit)
			{
				float_3 = RadarModel.ModifiedSignature_MobileUnits_db(this, float_3, activeUnit_1);
			}
			if (!IsPureIlluminator && !ExcludeOrder(activeUnit_0, activeUnit_1, float_3, float_0, ActiveEmissionMode.Search_Track, list_0, activeUnit_0.WeatherAtMyLocation, bool_0) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_ECM_Equation, ref nullable_2).HasValue)
			{
				return false;
			}
			if (Capabilities.OTH_Backscatter && FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.RADAR_Successful_OTHBackscatter, ref nullable_2).HasValue)
			{
				return true;
			}
			if (Capabilities.SpaceSearch_ABM && activeUnit_1.IsWeapon && (((Weapon)activeUnit_1).Type == Weapon._WeaponType.RV || ((Weapon)activeUnit_1).Type == Weapon._WeaponType.HGV))
			{
				if (Horizon.CollectInvocation(activeUnit_0, activeUnit_1, this) <= Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude()))
				{
					if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_ABM_HorizonFailed, ref nullable_2).HasValue)
					{
						return false;
					}
				}
				else if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.RADAR_ABM_HorizonSuccessful, ref nullable_2).HasValue)
				{
					return true;
				}
			}
			if (Capabilities.OTH_SurfaceWave)
			{
				if (!nullable_1.HasValue)
				{
					nullable_1 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
				}
				if (!nullable_1.Value && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_RadarLOS_SurfaceWave, ref nullable_2).HasValue)
				{
					return false;
				}
				if (nullable_2.HasValue)
				{
					return nullable_2.Value;
				}
				return nullable_1.Value;
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen);
			}
			if (!nullable_0.Value && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADAR_RadarLOS, ref nullable_2).HasValue)
			{
				return false;
			}
			if (nullable_2.HasValue)
			{
				return nullable_2.Value;
			}
			return nullable_0.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100716", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool PublishWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, Sensor sensor_0, ActiveUnit activeUnit_2, float float_0, List<ActiveUnit> list_0, ref bool? nullable_0, ref bool? nullable_1, bool bool_0 = false)
	{
		try
		{
			if (activeUnit_1.Sensory.InterruptConsumer().AwakeIssuer())
			{
				if (Capabilities.OTH_SurfaceWave)
				{
					if (nullable_1.HasValue)
					{
						bool? flag = nullable_1;
						if (((!flag) ?? flag).GetValueOrDefault())
						{
							return false;
						}
					}
				}
				else if (nullable_0.HasValue)
				{
					bool? flag2 = nullable_0;
					if (((!flag2) ?? flag2).GetValueOrDefault())
					{
						return false;
					}
				}
				if (activeUnit_2.IsSubmarine && Math.Round(activeUnit_2.GetCurrentAltitude()) >= -20.0)
				{
					switch (((Submarine)activeUnit_2).Type)
					{
					case Submarine._SubmarineType.None:
					case Submarine._SubmarineType.Biologics:
					case Submarine._SubmarineType.FalseTarget:
						return false;
					case Submarine._SubmarineType.SDV:
					case Submarine._SubmarineType.ROV:
					case Submarine._SubmarineType.UUV:
						if (activeUnit_2.GetCurrentAltitude() < 0f)
						{
							return false;
						}
						break;
					}
				}
				if (activeUnit_2.IsSubmarine && Math.Round(activeUnit_2.GetCurrentAltitude()) >= -20.0 && activeUnit_2.GetCurrentAltitude() < -5f && !Capabilities.PeriscopeSearch)
				{
					return false;
				}
				ActiveUnit parentPlatform = base.ParentPlatform;
				string string_ = "";
				Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_2, bool_0: false, ref string_));
				XSection._SignatureType signatureType_ = ((GetSearchesInThisFrequency(FrequencyBand.A_Band) || GetSearchesInThisFrequency(FrequencyBand.B_Band) || GetSearchesInThisFrequency(FrequencyBand.C_Band) || GetSearchesInThisFrequency(FrequencyBand.D_Band)) ? XSection._SignatureType.Radar_A_D : XSection._SignatureType.Radar_E_M);
				Module_Unit.BearingToUnit_Relative(activeUnit_2, activeUnit_1);
				Module_Unit.BearingToUnit_Relative(activeUnit_2, activeUnit_0);
				float float_ = RadarModel.GetWriter(activeUnit_2, signatureType_, activeUnit_1, activeUnit_0);
				if (activeUnit_2.IsPlatform && ((Platform)activeUnit_2).RepresentsMobileGroundUnit)
				{
					float_ = RadarModel.ModifiedSignature_MobileUnits_db(this, float_, activeUnit_2);
				}
				if (AwakeWriter(activeUnit_0, activeUnit_2, activeUnit_1, sensor_0, float_, float_0, ActiveEmissionMode.Search_Track, list_0, activeUnit_0.WeatherAtMyLocation))
				{
					if (Capabilities.OTH_Backscatter)
					{
						return true;
					}
					if (Capabilities.SpaceSearch_ABM && activeUnit_2.IsWeapon && (((Weapon)activeUnit_2).Type == Weapon._WeaponType.RV || ((Weapon)activeUnit_2).Type == Weapon._WeaponType.HGV))
					{
						return Horizon.CollectInvocation(activeUnit_0, activeUnit_2, this) > Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_2.GetLatitude(), activeUnit_2.GetLongitude());
					}
					if (Capabilities.OTH_SurfaceWave)
					{
						if (!nullable_1.HasValue)
						{
							nullable_1 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_2, ref activeUnit_0.ParentScen, bool_0: true);
						}
						if ((!nullable_1).GetValueOrDefault())
						{
							return false;
						}
					}
					else
					{
						if (!nullable_0.HasValue)
						{
							nullable_0 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_2, ref activeUnit_0.ParentScen, bool_0: false, Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_1, sensor_0));
						}
						if ((!nullable_0).GetValueOrDefault())
						{
							return false;
						}
					}
					if (Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_1, sensor_0, activeUnit_2, ref activeUnit_0.ParentScen))
					{
						if (Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_1, sensor_0, activeUnit_0, ref activeUnit_0.ParentScen, bool_0: false, Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_1, sensor_0), Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_0, this)))
						{
							return true;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100716", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool AwakeWriter(Module_Unit.Unit unit_0, ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, Sensor sensor_0, float float_0, float float_1, ActiveEmissionMode activeEmissionMode_0, List<ActiveUnit> list_0, Weather.WeatherProfile weatherProfile_0)
	{
		try
		{
			RadarModel.TTarget tTarget = new RadarModel.TTarget();
			RadarModel.TRadar tradar_ = new RadarModel.TRadar();
			double num = RadarModel.StartStub(Module_Unit.RangeToUnit_Horiz(base.ParentPlatform, activeUnit_0), base.ParentPlatform.GetCurrentAltitude() + (float)base.ParentPlatform.GetMastHeight_Radar(this), activeUnit_0.GetCurrentAltitude(), ref weatherProfile_0);
			float num2 = Module_Unit.RangeToUnit_Slant(unit_0, activeUnit_0);
			if (_BridgeFacade == null)
			{
				_BridgeFacade = new RadarModel.TRadar();
			}
			_BridgeFacade.Altitude = Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(unit_0, this);
			_BridgeFacade.ElevationAngle = 0.0 - num;
			if (sensor_0.Type == Sensor_Type.NonDetectingEmitter)
			{
				if (sensor_0.m_RadarHorBeamwidth == 0f)
				{
					sensor_0.m_RadarHorBeamwidth = 3f;
				}
				if (sensor_0.m_RadarVerBeamwidth == 0f)
				{
					sensor_0.m_RadarVerBeamwidth = 3f;
				}
				if (sensor_0.m_PulseWidth_SearchOrTrack == 0f)
				{
					sensor_0.m_PulseWidth_SearchOrTrack = 2f;
				}
				if (sensor_0.m_PowerOutputW_SearchOrTrack == 0f)
				{
					sensor_0.m_PowerOutputW_SearchOrTrack = 17000000f;
				}
				if (sensor_0.m_PRF_SearchOrTrack == 0f)
				{
					sensor_0.m_PRF_SearchOrTrack = 1000f;
				}
			}
			if (Type == Sensor_Type.PCLS)
			{
				if (m_RadarHorBeamwidth == 0f)
				{
					m_RadarHorBeamwidth = 7.5f;
				}
				if (m_RadarVerBeamwidth == 0f)
				{
					m_RadarVerBeamwidth = 7.5f;
				}
				if (m_SystemNoiseLevel_SearchOrTrack == 0f)
				{
					m_SystemNoiseLevel_SearchOrTrack = 2f;
				}
				if (m_ProcessingGain_SearchOrTrack == 0f)
				{
					m_ProcessingGain_SearchOrTrack = -2.2f;
				}
			}
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Illuminate:
				_BridgeFacade.SetGainFromBeamwidth(sensor_0.m_RadarHorBeamwidth_Illuminate, sensor_0.m_RadarVerBeamwidth_Illuminate);
				_BridgeFacade.PowerOutputW = sensor_0.m_PowerOutputW_Illuminate;
				_BridgeFacade.PulseWidth = sensor_0.m_PulseWidth_Illuminate;
				_BridgeFacade.ProcessingGain = sensor_0.m_ProcessingGain_Illuminate;
				_BridgeFacade.SystemNoiseLevel = sensor_0.m_SystemNoiseLevel_Illuminate;
				_BridgeFacade.Frequency = (double)(sensor_0.UpperFreqIlluminate + sensor_0.LowerFreqIlluminate) * 0.5;
				_BridgeFacade.PRF = sensor_0.m_PRF_Illuminate;
				break;
			case ActiveEmissionMode.Search_Track:
				_BridgeFacade.SetGainFromBeamwidth(sensor_0.m_RadarHorBeamwidth, sensor_0.m_RadarVerBeamwidth);
				_BridgeFacade.PowerOutputW = sensor_0.m_PowerOutputW_SearchOrTrack;
				_BridgeFacade.PulseWidth = sensor_0.m_PulseWidth_SearchOrTrack;
				_BridgeFacade.ProcessingGain = sensor_0.m_ProcessingGain_SearchOrTrack;
				_BridgeFacade.SystemNoiseLevel = sensor_0.m_SystemNoiseLevel_SearchOrTrack;
				_BridgeFacade.Frequency = (double)(sensor_0.UpperFreq + sensor_0.LowerFreq) * 0.5;
				_BridgeFacade.PRF = sensor_0.m_PRF_SearchOrTrack;
				break;
			}
			tradar_.SetGainFromBeamwidth(m_RadarHorBeamwidth, m_RadarVerBeamwidth);
			tradar_.PowerOutputW = m_PowerOutputW_SearchOrTrack;
			tradar_.PulseWidth = m_PulseWidth_SearchOrTrack;
			tradar_.ProcessingGain = m_ProcessingGain_SearchOrTrack;
			tradar_.SystemNoiseLevel = m_SystemNoiseLevel_SearchOrTrack;
			tradar_.Frequency = (double)(UpperFreq + LowerFreq) * 0.5;
			tradar_.PRF = m_PRF_SearchOrTrack;
			if (!activeUnit_0.IsShip && !activeUnit_0.IsFacility && !activeUnit_0.IsSubmarine)
			{
				tTarget.Altitude = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_0);
			}
			else
			{
				tTarget.Height = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_0);
				tTarget.ObjectType = RadarModel.TTargetType.tgt_SurfaceShip;
				if (Codes.PeriscopeSearch_Basic)
				{
					_BridgeFacade.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.Basic;
				}
				else if (Codes.PeriscopeAndSurfaceSearch_FineRangeResolution)
				{
					_BridgeFacade.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.FineRangeResolution;
				}
				else if (Codes.PeriscopeAndSurfaceSearch_AdvancedProcessing)
				{
					_BridgeFacade.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.AdvancedProcessing;
				}
			}
			tTarget.RCS = float_0;
			if (list_0 == null)
			{
				list_0 = base.ParentPlatform.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
			}
			List<Sensor> list = new List<Sensor>();
			foreach (ActiveUnit item in list_0)
			{
				Sensor[] sensors_Cached = item.Sensors_Cached;
				Sensor[] array6 = sensors_Cached;
				foreach (Sensor sensor in array6)
				{
					if (sensor.IsOECM && sensor.GetCanJamThisSensor(this))
					{
						list.Add(sensor);
					}
				}
			}
			float float_2 = Math2.PublishClass(base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetLongitude(), activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude());
			int count = list.Count;
			RadarModel.TJammer[] array = new RadarModel.TJammer[count - 1 + 1];
			double[] array2 = new double[count - 1 + 1];
			double[] array3 = new double[count - 1 + 1];
			int num3 = count - 1;
			for (int i = 0; i <= num3; i++)
			{
				Sensor sensor2 = list[i];
				RadarModel.TJammer tJammer = new RadarModel.TJammer();
				tJammer.Bandwidth = sensor2.configurationFacade;
				tJammer.Altitude = sensor2.ParentPlatform.GetCurrentAltitude();
				tJammer.Frequency = _BridgeFacade.Frequency;
				tJammer.AntennaGain = sensor2._ProccesorFacade;
				tJammer.PowerOutputW = sensor2.m_StrategyFacade;
				if (Codes.AESA)
				{
					tJammer.PowerOutputW *= 0.1;
				}
				else if (Codes.PESA)
				{
					tJammer.PowerOutputW *= 0.5;
				}
				int num4 = TechGeneration - sensor2.TechGeneration;
				if (num4 < -3)
				{
					tJammer.PowerOutputW *= 20.0;
				}
				else if (num4 == -3)
				{
					tJammer.PowerOutputW *= 10.0;
				}
				else if (num4 == -2)
				{
					tJammer.PowerOutputW *= 5.0;
				}
				else if (num4 == -1)
				{
					tJammer.PowerOutputW *= 2.0;
				}
				else if (num4 != 0)
				{
					if (num4 == 1)
					{
						tJammer.PowerOutputW *= 0.5;
					}
					else if (num4 == 2)
					{
						tJammer.PowerOutputW *= 0.2;
					}
					else if (num4 == 3)
					{
						tJammer.PowerOutputW *= 0.1;
					}
					else if (num4 > 3)
					{
						tJammer.PowerOutputW *= 0.05;
					}
				}
				array[i] = tJammer;
				float num5 = Module_Unit.RangeToUnit_Slant(base.ParentPlatform, sensor2.ParentPlatform);
				array2[i] = num5;
				float num6 = MathFunctions.DeleteRequest(float_2, Math2.PublishClass(base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetLongitude(), sensor2.ParentPlatform.GetLatitude(), sensor2.ParentPlatform.GetLongitude()));
				array3[i] = num6;
			}
			if (!Codes.AESA)
			{
				bool flag = false;
				double num7 = 1.0;
				foreach (ChaffCorridorCloud chaffCloud in base.ParentPlatform.ParentScen.ChaffClouds)
				{
					if (!Capabilities.AltitudeInfo || (activeUnit_0.GetCurrentAltitude() <= (float)chaffCloud.CurtainCeiling && activeUnit_0.GetCurrentAltitude() >= (float)chaffCloud.CurtainFloor))
					{
						Geopoint_Struct[] rectangularArea = Math2.GetRectangularArea(chaffCloud.GetLatitude(), chaffCloud.GetLongitude(), chaffCloud.CoverageLength, chaffCloud.CoverageWidth, chaffCloud.CurrentHeading);
						if (activeUnit_0.GetIsInsideThisArea(rectangularArea, base.ParentPlatform.ParentScen, bool_0: false))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					RadioElectronicFrequency[] array4 = null;
					switch (activeEmissionMode_0)
					{
					case ActiveEmissionMode.Illuminate:
						array4 = IlluminationFreqs;
						break;
					case ActiveEmissionMode.Search_Track:
						array4 = SearchFreqs;
						break;
					}
					RadioElectronicFrequency[] array5 = array4;
					for (int j = 0; j < array5.Length; j = checked(j + 1))
					{
						FrequencyBand frequencyBand = array5[j].Band - 1001;
						if ((ulong)frequencyBand <= 11uL && (ulong)frequencyBand <= 11uL)
						{
							FrequencyBand frequencyBand2 = frequencyBand;
							FrequencyBand frequencyBand3 = frequencyBand2;
							if ((ulong)frequencyBand3 <= 11uL)
							{
								switch (frequencyBand3)
								{
								case (FrequencyBand)0L:
								case (FrequencyBand)1L:
								case (FrequencyBand)2L:
									num7 = Math.Min(0.05, num7);
									continue;
								case (FrequencyBand)3L:
								case (FrequencyBand)4L:
								case (FrequencyBand)5L:
									num7 = Math.Min(0.1, num7);
									continue;
								case (FrequencyBand)6L:
								case (FrequencyBand)7L:
								case (FrequencyBand)8L:
									num7 = Math.Min(0.15, num7);
									continue;
								case (FrequencyBand)9L:
								case (FrequencyBand)10L:
								case (FrequencyBand)11L:
									num7 = Math.Min(0.2, num7);
									continue;
								}
							}
						}
						num7 = Math.Min(0.25, num7);
					}
					GlobalVariables.TechGenerationClass techGeneration = TechGeneration;
					if (techGeneration < GlobalVariables.TechGenerationClass.Late1950s)
					{
						num7 *= 0.1;
					}
					else if (techGeneration == GlobalVariables.TechGenerationClass.Early1960s)
					{
						num7 *= 0.15;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.Late1960s)
					{
						num7 *= 0.2;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.Early1970s)
					{
						num7 *= 0.3;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.Early1980s)
					{
						num7 *= 0.4;
					}
					else
					{
						switch (techGeneration)
						{
						default:
							switch (techGeneration)
							{
							case GlobalVariables.TechGenerationClass.Late1990s:
								num7 *= 0.9;
								break;
							case GlobalVariables.TechGenerationClass.Early1990s:
								num7 *= 0.8;
								break;
							}
							break;
						case GlobalVariables.TechGenerationClass.Early1980s:
							num7 *= 0.5;
							break;
						case GlobalVariables.TechGenerationClass.Late1980s:
							num7 *= 0.6;
							break;
						case GlobalVariables.TechGenerationClass.Early1990s:
							num7 *= 0.7;
							break;
						}
					}
					num7 = Math.Min(1.0, num7);
					tTarget.RCS_m2 *= num7;
				}
			}
			RadarModel.TSurfaceType tsurfaceType_ = RadarModel.TSurfaceType.st_Urban;
			float num8 = 0f;
			RadarModel.RadarClutterType radarClutterType_ = RadarModel.RadarClutterType.None;
			if (_BridgeFacade.ElevationAngle <= 0.0)
			{
				if ((Codes.AESA && activeEmissionMode_0 == ActiveEmissionMode.Illuminate) || base.ParentPlatform.Sensory.ManageDic(activeUnit_0))
				{
					radarClutterType_ = RadarModel.RadarClutterType.None;
				}
				else
				{
					if (activeUnit_0.IsShip || activeUnit_0.IsSubmarine || (activeUnit_0.IsAircraft && !Module_Unit.ResetTokenizer(activeUnit_0)))
					{
						Terrain.IncludeWatcher(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), 2f);
						tsurfaceType_ = RadarModel.TSurfaceType.st_Mountains;
					}
					num8 = Terrain.InvokeWatcher(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen);
					if (Terrain.GetElevation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen) <= 0)
					{
						tsurfaceType_ = RadarModel.TSurfaceType.st_Wetland;
					}
					else
					{
						float num9 = num8;
						tsurfaceType_ = ((num9 < 0.1f) ? RadarModel.TSurfaceType.st_Wetland : ((num9 < 0.2f) ? RadarModel.TSurfaceType.st_Forest : ((num9 < 0.3f) ? RadarModel.TSurfaceType.st_Shrubland : ((!(num9 < 0.4f)) ? RadarModel.TSurfaceType.st_Mountains : RadarModel.TSurfaceType.st_Cropland))));
					}
				}
			}
			else
			{
				radarClutterType_ = RadarModel.RadarClutterType.None;
			}
			return RadarModel.InsertStub(_BridgeFacade, tTarget, count, array, float_1, array2, array3, weatherProfile_0, radarClutterType_, TechGeneration, 0.0, 0.0, ref tradar_, num2, tsurfaceType_, num8);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100743", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static XSection smethod_0(ActiveUnit activeUnit_0, XSection._SignatureType _SignatureType_0)
	{
		try
		{
			XSection[] xSections_ReadOnly = activeUnit_0.XSections_ReadOnly;
			int num = xSections_ReadOnly.Length - 1;
			int num2 = 0;
			XSection xSection;
			while (true)
			{
				if (num2 <= num)
				{
					xSection = xSections_ReadOnly[num2];
					if (xSection != null && xSection.SignatureType == _SignatureType_0)
					{
						break;
					}
					num2++;
					continue;
				}
				return null;
			}
			return xSection;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200034", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public float GetLandCoverMaxDetectionRangeModifier_Visual(LandCover.LandCoverType landCoverType_0)
	{
		float result = 1f;
		switch (landCoverType_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case LandCover.LandCoverType.Urban_CloseInnerCity:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedHighRise:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_AttachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_CloseIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedApartments:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_DetachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_ShantyTown:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
		case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
		case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
		case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
		case LandCover.LandCoverType.Mixed_forest:
			result = 0.5f;
			break;
		case LandCover.LandCoverType.Closed_shrublands:
		case LandCover.LandCoverType.Open_shrublands:
			result = 0.75f;
			break;
		case LandCover.LandCoverType.Woody_savannas:
		case LandCover.LandCoverType.Savannas:
			result = 0.9f;
			break;
		case LandCover.LandCoverType.UrbanAndBuiltUp:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Croplands:
		case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
			result = 0.85f;
			break;
		case LandCover.LandCoverType.Water:
		case LandCover.LandCoverType.Grasslands:
		case LandCover.LandCoverType.Permanent_wetlands:
		case LandCover.LandCoverType.SnowAndIce:
		case LandCover.LandCoverType.BarrenOrSparselyVegetated:
			break;
		}
		return result;
	}

	internal float QueryWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			ActiveUnit parentPlatform = base.ParentPlatform;
			string string_ = "";
			float num = Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_));
			XSection._SignatureType signatureType_ = XSection._SignatureType.Visual_Detect;
			XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.Visual_Detect);
			if (xSection == null)
			{
				xSection = smethod_0(activeUnit_1, signatureType_);
			}
			if (xSection == null)
			{
				return 0f;
			}
			if (xSection.isDBInvisible(activeUnit_1))
			{
				return 0f;
			}
			float num2 = 0f;
			if (num < 315f && num > 45f)
			{
				if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
				{
					num2 = xSection.GetSide(activeUnit_1);
				}
				else if (num >= 135f && num <= 225f)
				{
					num2 = xSection.GetRear(activeUnit_1);
				}
			}
			else
			{
				num2 = xSection.GetFront(activeUnit_1);
			}
			num2 += activeUnit_1.DestroyClient(XSection._SignatureType.Visual_Detect, "Absolute");
			bool flag = false;
			if (activeUnit_0 != null && activeUnit_0.GetUnitSide() != null && activeUnit_0.GetUnitSide().Contacts != null && activeUnit_1 != null)
			{
				flag = activeUnit_0.GetUnitSide().Contacts.ContainsKey(activeUnit_1.ObjectID);
			}
			float num3 = ((!flag || _UtilsFacade <= schemaFacade) ? (num2 * schemaFacade) : (num2 * _UtilsFacade));
			Side natureSide = activeUnit_1.ParentScen.GetNatureSide();
			if (bool_0 && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
			{
				if ((activeUnit_1.IsFacility || activeUnit_1.IsMobileGroundUnit || activeUnit_1.IsAircraft) && base.ParentPlatform.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation && Terrain.GetElevation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen) > 0)
				{
					(LandCover.LandCoverType, int) tuple = LandCover.AddClass(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.ParentScen, (List<CustomEnvironmentZone>)(object)natureSide);
					if (!activeUnit_1.IsAircraft || activeUnit_1.CurrentAltitude_AGL < (float)tuple.Item2)
					{
						float landCoverMaxDetectionRangeModifier_Visual = GetLandCoverMaxDetectionRangeModifier_Visual(tuple.Item1);
						num3 *= landCoverMaxDetectionRangeModifier_Visual;
					}
				}
				if (activeUnit_0 != null && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced))
				{
					float num4 = activeUnit_0.GetCurrentAltitude() + (float)activeUnit_0.GetMastHeight_Visual(this);
					if ((activeUnit_0.IsFacility || activeUnit_0.IsMobileGroundUnit || activeUnit_0.IsAircraft) && activeUnit_0.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation)
					{
						int elevation = Terrain.GetElevation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen);
						if (elevation > 0)
						{
							(LandCover.LandCoverType, int) tuple2 = LandCover.AddClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.ParentScen, (List<CustomEnvironmentZone>)(object)natureSide);
							if (num4 - (float)elevation < (float)tuple2.Item2)
							{
								float landCoverMaxDetectionRangeModifier_Visual2 = GetLandCoverMaxDetectionRangeModifier_Visual(tuple2.Item1);
								num3 *= landCoverMaxDetectionRangeModifier_Visual2;
							}
						}
					}
				}
			}
			if (bool_1 && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced) && activeUnit_0 != null && !activeUnit_0.IsSatellite && !activeUnit_1.IsSatellite)
			{
				float float_ = activeUnit_0.GetCurrentAltitude() + (float)activeUnit_0.GetMastHeight_Visual(this);
				if (m_ComparatorFacade)
				{
					foreach (Tuple<LandCover.LandCoverType, int> item in LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), float_, activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetCurrentAltitude(), activeUnit_0.ParentScen, natureSide).ToList())
					{
						float landCoverMaxDetectionRangeModifier_Visual3 = GetLandCoverMaxDetectionRangeModifier_Visual(item.Item1);
						num3 *= landCoverMaxDetectionRangeModifier_Visual3;
					}
				}
			}
			num3 *= activeUnit_1.DestroyClient(XSection._SignatureType.Visual_Detect, "Factor");
			if (bool_2)
			{
				ForgotWriter(activeUnit_0, activeUnit_1, ref num3);
			}
			return Math.Min(maxRange, num3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100719", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public float GetLandCoverMaxDetectionRangeModifier_IR(LandCover.LandCoverType landCoverType_0)
	{
		float result = 1f;
		switch (landCoverType_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case LandCover.LandCoverType.Urban_CloseInnerCity:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedHighRise:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_AttachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_CloseIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedApartments:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_DetachedHouses:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_SpacedIndustrial:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Urban_ShantyTown:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
		case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
		case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
		case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
		case LandCover.LandCoverType.Mixed_forest:
			result = 0.5f;
			break;
		case LandCover.LandCoverType.Closed_shrublands:
		case LandCover.LandCoverType.Open_shrublands:
			result = 0.75f;
			break;
		case LandCover.LandCoverType.Woody_savannas:
		case LandCover.LandCoverType.Savannas:
			result = 0.9f;
			break;
		case LandCover.LandCoverType.UrbanAndBuiltUp:
			result = 0.25f;
			break;
		case LandCover.LandCoverType.Croplands:
		case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
			result = 0.85f;
			break;
		case LandCover.LandCoverType.Water:
		case LandCover.LandCoverType.Grasslands:
		case LandCover.LandCoverType.Permanent_wetlands:
		case LandCover.LandCoverType.SnowAndIce:
		case LandCover.LandCoverType.BarrenOrSparselyVegetated:
			break;
		}
		return result;
	}

	internal float ResetWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, bool bool_0 = false)
	{
		try
		{
			ActiveUnit parentPlatform = base.ParentPlatform;
			string string_ = "";
			float num = Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_));
			XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.IR_Detect);
			if (xSection == null)
			{
				return 0f;
			}
			if (xSection.isDBInvisible(activeUnit_1))
			{
				return 0f;
			}
			float num2 = 0f;
			if (num < 315f && num > 45f)
			{
				if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
				{
					num2 = xSection.GetSide(activeUnit_1);
				}
				else if (num >= 135f && num <= 225f)
				{
					num2 = xSection.GetRear(activeUnit_1);
				}
			}
			else
			{
				num2 = xSection.GetFront(activeUnit_1);
			}
			num2 += activeUnit_1.DestroyClient(XSection._SignatureType.IR_Detect, "Absolute");
			float num3 = ((activeUnit_0.GetUnitSide() == null) ? (num2 * m_PredicateFacade) : ((!activeUnit_0.GetUnitSide().Contacts.ContainsKey(activeUnit_1.ObjectID) || m_SingletonFacade <= m_PredicateFacade) ? (num2 * m_PredicateFacade) : (num2 * m_SingletonFacade)));
			switch (TechGeneration)
			{
			case GlobalVariables.TechGenerationClass.IR_Imaging_FPA:
				num3 = (float)((double)num3 * 2.5);
				break;
			case GlobalVariables.TechGenerationClass.IR_DualSpectral:
				num3 = (float)((double)num3 * 1.8);
				break;
			}
			bool flag = bool_0;
			if (!bool_0 && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
			{
				float num4 = 1f;
				Side natureSide = activeUnit_1.ParentScen.GetNatureSide();
				if ((activeUnit_1.IsFacility || activeUnit_1.IsMobileGroundUnit || activeUnit_1.IsAircraft) && base.ParentPlatform.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation && Terrain.GetElevation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen) > 0)
				{
					(LandCover.LandCoverType, int) tuple = LandCover.AddClass(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.ParentScen, (List<CustomEnvironmentZone>)(object)natureSide);
					if (!activeUnit_1.IsAircraft || activeUnit_1.CurrentAltitude_AGL < (float)tuple.Item2)
					{
						flag = true;
						num4 = GetLandCoverMaxDetectionRangeModifier_IR(tuple.Item1);
						num3 *= num4;
					}
				}
				if (activeUnit_0 != null)
				{
					float num5 = activeUnit_0.GetCurrentAltitude() + (float)activeUnit_0.GetMastHeight_Visual(this);
					if ((activeUnit_0.IsFacility || activeUnit_0.IsMobileGroundUnit || activeUnit_0.IsAircraft) && activeUnit_0.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation)
					{
						int elevation = Terrain.GetElevation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen);
						if (elevation > 0)
						{
							(LandCover.LandCoverType, int) tuple2 = LandCover.AddClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.ParentScen, (List<CustomEnvironmentZone>)(object)natureSide);
							if (num5 - (float)elevation < (float)tuple2.Item2)
							{
								num4 = GetLandCoverMaxDetectionRangeModifier_IR(tuple2.Item1);
								num3 *= num4;
							}
						}
					}
					if (m_ComparatorFacade && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced) && !activeUnit_0.IsSatellite && !activeUnit_1.IsSatellite)
					{
						foreach (Tuple<LandCover.LandCoverType, int> item in LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), num5, activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetCurrentAltitude(), activeUnit_0.ParentScen, natureSide).ToList())
						{
							num4 = GetLandCoverMaxDetectionRangeModifier_Visual(item.Item1);
							num3 *= num4;
						}
					}
				}
			}
			if (!flag && activeUnit_0.IsAircraft && activeUnit_1.IsAircraft)
			{
				double num6 = Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1) * 1852f;
				double num7 = Math.Atan2(activeUnit_1.GetCurrentAltitude() - activeUnit_0.GetCurrentAltitude(), num6);
				double num8 = (double)Module_Unit.BearingToUnit_Relative(activeUnit_0, activeUnit_1) * 0.0174532925199433;
				Vector3D vector3D = new Vector3D(num6 * Math.Sin(num7) * Math.Cos(num8), num6 * Math.Sin(num7) * Math.Sin(num8), num6 * Math.Cos(num7));
				if (Math.Atan2(vector3D.Y, vector3D.GetLength()) * 57.2957795130823 < 0.0)
				{
					switch (LandCover.DestroyClass(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_0.ParentScen))
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case LandCover.LandCoverType.Urban_CloseInnerCity:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_SpacedHighRise:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_AttachedHouses:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_CloseIndustrial:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_SpacedApartments:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_DetachedHouses:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_SpacedIndustrial:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Urban_ShantyTown:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Water:
					{
						int seaState = Weather.GetWeatherAtThisTimeAndPlace(activeUnit_0.ParentScen, activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), 0).SeaState;
						num3 = (float)((double)num3 * (1.0 - (0.2 + (double)seaState * 0.05)));
						break;
					}
					case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					case LandCover.LandCoverType.Mixed_forest:
						num3 = (float)((double)num3 * 0.4);
						break;
					case LandCover.LandCoverType.Closed_shrublands:
					case LandCover.LandCoverType.Open_shrublands:
						num3 = (float)((double)num3 * 0.65);
						break;
					case LandCover.LandCoverType.Woody_savannas:
					case LandCover.LandCoverType.Savannas:
						num3 = (float)((double)num3 * 0.75);
						break;
					case LandCover.LandCoverType.Permanent_wetlands:
						num3 = (float)((double)num3 * 0.9);
						break;
					case LandCover.LandCoverType.UrbanAndBuiltUp:
						num3 = (float)((double)num3 * 0.25);
						break;
					case LandCover.LandCoverType.Croplands:
					case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
						num3 = (float)((double)num3 * 0.75);
						break;
					case LandCover.LandCoverType.Grasslands:
					case LandCover.LandCoverType.BarrenOrSparselyVegetated:
						num3 = (float)((double)num3 * 0.9);
						break;
					case LandCover.LandCoverType.SnowAndIce:
						break;
					}
				}
			}
			num3 *= activeUnit_1.DestroyClient(XSection._SignatureType.IR_Detect, "Factor");
			num3 *= activeUnit_1.DestroyClient(XSection._SignatureType.IR_Detect, "Factor");
			FlushWriter(activeUnit_0, activeUnit_1, ref num3);
			if (activeUnit_1.IsAircraft)
			{
				if (((Aircraft)activeUnit_1).IRSS_ShieldedExhaustAntiStrela && activeUnit_1.GetCurrentAltitude() > activeUnit_0.GetCurrentAltitude())
				{
					num3 = (float)((double)num3 * 0.9);
				}
				else if (((Aircraft)activeUnit_1).IRSS_MaskedExhaust_Slit && activeUnit_1.GetCurrentAltitude() > activeUnit_0.GetCurrentAltitude())
				{
					num3 = (float)(1.3 * (double)num3);
				}
			}
			return Math.Min(maxRange, num3);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100720", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public float MaxIDRangeOnThisTarget(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		Sensor_Type type = Type;
		if (1 == 0)
		{
		}
		float result = type switch
		{
			Sensor_Type.Radar => SortWriter(activeUnit_1), 
			Sensor_Type.Visual => MapWriter(activeUnit_0, activeUnit_1), 
			Sensor_Type.Infrared => CalcWriter(activeUnit_0, activeUnit_1), 
			_ => 0f, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private float MapWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		if (activeUnit_1.IsSubmarine && Math.Round(activeUnit_1.GetCurrentAltitude()) < -20.0)
		{
			return 0f;
		}
		try
		{
			ActiveUnit parentPlatform = base.ParentPlatform;
			string string_ = "";
			float num = Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_));
			XSection._SignatureType signatureType_ = XSection._SignatureType.Visual_ID;
			XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.Visual_ID);
			if (Information.IsNothing(xSection))
			{
				xSection = smethod_0(activeUnit_1, signatureType_);
			}
			if (Information.IsNothing(xSection))
			{
				return 0f;
			}
			if (xSection.isDBInvisible(activeUnit_1))
			{
				return 0f;
			}
			float num2 = 0f;
			if (num < 315f && num > 45f)
			{
				if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
				{
					num2 = xSection.GetSide(activeUnit_1);
				}
				else if (num >= 135f && num <= 225f)
				{
					num2 = xSection.GetRear(activeUnit_1);
				}
			}
			else
			{
				num2 = xSection.GetFront(activeUnit_1);
			}
			float float_ = num2 * _UtilsFacade;
			ForgotWriter(activeUnit_0, activeUnit_1, ref float_);
			return float_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100721", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	private float SortWriter(ActiveUnit activeUnit_0)
	{
		if (Codes.Classification)
		{
			return maxRange / 4f;
		}
		return 0f;
	}

	private float CalcWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		if (activeUnit_1.IsSubmarine && !((Submarine)activeUnit_1).IsSurfaced)
		{
			return 0f;
		}
		try
		{
			ActiveUnit parentPlatform = base.ParentPlatform;
			string string_ = "";
			float num = Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_));
			XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.IR_ID);
			if (xSection == null)
			{
				return 0f;
			}
			if (xSection.isDBInvisible(activeUnit_1))
			{
				return 0f;
			}
			float num2 = 0f;
			if (num < 315f && num > 45f)
			{
				if ((num >= 45f && num <= 135f) || (num >= 225f && num <= 315f))
				{
					num2 = xSection.GetSide(activeUnit_1);
				}
				else if (num >= 135f && num <= 225f)
				{
					num2 = xSection.GetRear(activeUnit_1);
				}
			}
			else
			{
				num2 = xSection.GetFront(activeUnit_1);
			}
			float float_ = num2 * m_SingletonFacade;
			FlushWriter(activeUnit_0, activeUnit_1, ref float_);
			return float_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100722", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	private void RateWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0)
	{
		if (float_0 == 0f)
		{
			return;
		}
		Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(activeUnit_1.ParentScen, activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), 0);
		float rainfallRate = weatherAtThisTimeAndPlace.RainfallRate;
		if (rainfallRate <= 40f)
		{
			if (rainfallRate <= 30f)
			{
				if (rainfallRate <= 20f)
				{
					if (rainfallRate <= 10f)
					{
						if (rainfallRate > 0f)
						{
							float_0 = (float)((double)float_0 * 0.75);
						}
					}
					else
					{
						float_0 = (float)((double)float_0 * 0.5);
					}
				}
				else
				{
					float_0 = (float)((double)float_0 * 0.25);
				}
			}
			else
			{
				float_0 = (float)((double)float_0 * 0.1);
			}
		}
		else
		{
			float_0 = (float)((double)float_0 * 0.05);
		}
		CollectWriter(weatherAtThisTimeAndPlace, activeUnit_0, activeUnit_1, ref float_0);
	}

	private void FlushWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0)
	{
		if (float_0 == 0f)
		{
			return;
		}
		Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(activeUnit_1.ParentScen, activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), 0);
		float rainfallRate = weatherAtThisTimeAndPlace.RainfallRate;
		if (rainfallRate <= 40f)
		{
			if (rainfallRate <= 30f)
			{
				if (rainfallRate <= 20f)
				{
					if (rainfallRate <= 10f)
					{
						if (rainfallRate > 0f)
						{
							float_0 = (float)((double)float_0 * 0.75);
						}
					}
					else
					{
						float_0 = (float)((double)float_0 * 0.5);
					}
				}
				else
				{
					float_0 = (float)((double)float_0 * 0.25);
				}
			}
			else
			{
				float_0 = (float)((double)float_0 * 0.1);
			}
		}
		else
		{
			float_0 = (float)((double)float_0 * 0.05);
		}
		CollectWriter(weatherAtThisTimeAndPlace, activeUnit_0, activeUnit_1, ref float_0);
	}

	private void ForgotWriter(ActiveUnit activeUnit_0, Module_Unit.Unit unit_0, ref float float_0)
	{
		if (float_0 == 0f)
		{
			return;
		}
		try
		{
			if (!Codes.VisualNightCapable)
			{
				DateTime time = base.ParentPlatform.ParentScen.Time;
				Weather.TTimeOfDayType tTimeOfDayType;
				try
				{
					tTimeOfDayType = SunModule.CollectSpecification(base.ParentPlatform.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, bool_0: true, unit_0.GetLatitude(), unit_0.GetLongitude(), 0.0);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					tTimeOfDayType = SunModule.OrderSpecification(Misc.DisableRequest(base.ParentPlatform.ParentScen.Time, unit_0.GetLongitude(), base.ParentPlatform.ParentScen.Use_DST, base.ParentPlatform.ParentScen.DST_Start, base.ParentPlatform.ParentScen.DST_End));
					ProjectData.ClearProjectError();
				}
				float num = 0f;
				float num2 = 0f;
				switch (tTimeOfDayType)
				{
				case Weather.TTimeOfDayType.tod_Day:
					num = 1f;
					num2 = 1f;
					break;
				case Weather.TTimeOfDayType.tod_Twilight:
					num = 0.75f;
					num2 = 0.8f;
					break;
				case Weather.TTimeOfDayType.tod_Night:
					num = 0.35f;
					num2 = 0.45f;
					break;
				}
				if (!unit_0.IsAircraft && !unit_0.IsMissile)
				{
					float_0 *= num2;
				}
				else
				{
					float_0 *= num;
				}
			}
			Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(base.ParentPlatform.ParentScen, unit_0.GetLatitude(), unit_0.GetLongitude(), 0);
			float rainfallRate = weatherAtThisTimeAndPlace.RainfallRate;
			if (rainfallRate <= 40f)
			{
				if (rainfallRate <= 30f)
				{
					if (rainfallRate <= 20f)
					{
						if (rainfallRate <= 10f)
						{
							if (rainfallRate > 0f)
							{
								float_0 = (float)((double)float_0 * 0.9);
							}
						}
						else
						{
							float_0 = (float)((double)float_0 * 0.7);
						}
					}
					else
					{
						float_0 = (float)((double)float_0 * 0.5);
					}
				}
				else
				{
					float_0 = (float)((double)float_0 * 0.3);
				}
			}
			else
			{
				float_0 = (float)((double)float_0 * 0.2);
			}
			CollectWriter(weatherAtThisTimeAndPlace, activeUnit_0, unit_0, ref float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100723", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void CollectWriter(Weather.WeatherProfile weatherProfile_0, Module_Unit.Unit unit_0, Module_Unit.Unit unit_1, ref float float_0)
	{
		float currentAltitude_AGL = unit_0.CurrentAltitude_AGL;
		float currentAltitude_AGL2 = unit_1.CurrentAltitude_AGL;
		float fractionUnderRain = weatherProfile_0.FractionUnderRain;
		if (fractionUnderRain <= 0.9f)
		{
			if (fractionUnderRain <= 0.8f)
			{
				if (fractionUnderRain <= 0.7f)
				{
					if (fractionUnderRain <= 0.6f)
					{
						if (fractionUnderRain <= 0.5f)
						{
							if (fractionUnderRain <= 0.4f)
							{
								if (fractionUnderRain <= 0.3f)
								{
									if (fractionUnderRain <= 0.2f)
									{
										if (fractionUnderRain <= 0.1f)
										{
											if (fractionUnderRain > 0f && ((2133.6f > currentAltitude_AGL && currentAltitude_AGL > 1524f) || (2133.6f > currentAltitude_AGL2 && currentAltitude_AGL2 > 1524f)))
											{
												float_0 = (float)((double)float_0 * 0.7);
											}
										}
										else if ((4876.8003f > currentAltitude_AGL && currentAltitude_AGL > 3048f) || (4876.8003f > currentAltitude_AGL2 && currentAltitude_AGL2 > 3048f))
										{
											float_0 = (float)((double)float_0 * 0.7);
										}
									}
									else if ((7010.4f > currentAltitude_AGL && currentAltitude_AGL > 6096f) || (7010.4f > currentAltitude_AGL2 && currentAltitude_AGL2 > 6096f))
									{
										float_0 = (float)((double)float_0 * 0.7);
									}
								}
								else if ((2133.6f > currentAltitude_AGL && currentAltitude_AGL > 609.60004f) || (2133.6f > currentAltitude_AGL2 && currentAltitude_AGL2 > 609.60004f))
								{
									float_0 = (float)((double)float_0 * 0.3);
								}
							}
							else if ((4876.8003f > currentAltitude_AGL && currentAltitude_AGL > 2133.6f) || (4876.8003f > currentAltitude_AGL2 && currentAltitude_AGL2 > 2133.6f))
							{
								float_0 = (float)((double)float_0 * 0.3);
							}
						}
						else if ((8534.4f > currentAltitude_AGL && currentAltitude_AGL > 7620f) || (8534.4f > currentAltitude_AGL2 && currentAltitude_AGL2 > 7620f))
						{
							float_0 = (float)((double)float_0 * 0.3);
						}
					}
					else if ((!(4876.8003f <= currentAltitude_AGL) && !(currentAltitude_AGL <= 2133.6f)) || (!(4876.8003f <= currentAltitude_AGL2) && currentAltitude_AGL2 > 2133.6f))
					{
						float_0 = (float)((double)float_0 * 0.3);
					}
					else if ((9144f > currentAltitude_AGL && currentAltitude_AGL > 8229.601f) || (9144f > currentAltitude_AGL2 && currentAltitude_AGL2 > 8229.601f))
					{
						float_0 = (float)((double)float_0 * 0.7);
					}
				}
				else if ((!(4876.8003f <= currentAltitude_AGL) && !(currentAltitude_AGL <= 2133.6f)) || (!(4876.8003f <= currentAltitude_AGL2) && currentAltitude_AGL2 > 2133.6f))
				{
					float_0 = (float)((double)float_0 * 0.1);
				}
				else if ((10972.8f > currentAltitude_AGL && currentAltitude_AGL > 9144f) || (10972.8f > currentAltitude_AGL2 && currentAltitude_AGL2 > 9144f))
				{
					float_0 = (float)((double)float_0 * 0.3);
				}
			}
			else if ((!(10972.8f <= currentAltitude_AGL) && !(currentAltitude_AGL <= 2133.6f)) || (!(10972.8f <= currentAltitude_AGL2) && currentAltitude_AGL2 > 2133.6f))
			{
				float_0 = (float)((double)float_0 * 0.1);
			}
			else if (609.60004f > currentAltitude_AGL || 609.60004f > currentAltitude_AGL2)
			{
				float_0 = (float)((double)float_0 * 0.2);
			}
		}
		else if ((!(10972.8f <= currentAltitude_AGL) && !(currentAltitude_AGL <= 2133.6f)) || (!(10972.8f <= currentAltitude_AGL2) && currentAltitude_AGL2 > 2133.6f))
		{
			float_0 = (float)((double)float_0 * 0.1);
		}
		else if (609.60004f > currentAltitude_AGL || !(609.60004f <= currentAltitude_AGL2))
		{
			float_0 = (float)((double)float_0 * 0.1);
		}
	}

	private bool OrderWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, ref Module_Unit.Unit.LOSCheckResult? nullable_0, bool bool_0 = false)
	{
		bool? nullable_ = null;
		ActiveUnit parentPlatform = base.ParentPlatform;
		string string_ = "";
		Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_));
		if (smethod_0(activeUnit_1, XSection._SignatureType.Visual_Detect).isDBInvisible(activeUnit_1) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.DB_Invisible, ref nullable_).HasValue)
		{
			return false;
		}
		try
		{
			double num = 0.0;
			if (activeUnit_0.IsAircraft && IsMk1Eyeball)
			{
				double num9 = Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1) * 1852f;
				double num10 = Math.Atan2(activeUnit_1.GetCurrentAltitude() - activeUnit_0.GetCurrentAltitude(), num9);
				double num11 = (double)Module_Unit.BearingToUnit_Relative(activeUnit_0, activeUnit_1) * 0.0174532925199433;
				Vector3D vector3D = new Vector3D(num9 * Math.Sin(num10) * Math.Cos(num11), num9 * Math.Sin(num10) * Math.Sin(num11), num9 * Math.Cos(num10));
				Matrix3D identity = Matrix3D.Identity;
				double num12 = (double)(0f - activeUnit_0.Attitude_Roll) * 0.0174532925199433;
				double num13 = Math.Sin(num12);
				double num17 = (identity.M22 = Math.Cos(num12));
				double num14 = num17;
				double i = num14;
				identity.M23 = num13;
				identity.M32 = 0.0 - num13;
				identity.M33 = i;
				Matrix3D identity2 = Matrix3D.Identity;
				double num15 = (double)(0f - activeUnit_0.Attitude_Pitch) * 0.0174532925199433;
				double num2 = Math.Sin(num15);
				num17 = (identity2.M11 = Math.Cos(num15));
				num14 = num17;
				double m2 = num14;
				identity2.M13 = 0.0 - num2;
				identity2.M31 = num2;
				identity2.M33 = m2;
				_ = identity2 * identity * vector3D;
				num = Math.Atan2(vector3D.Y, vector3D.GetLength()) * 57.2957795130823;
				double num3 = Module_Unit.BearingToUnit_Relative(activeUnit_0, activeUnit_1);
				if (num < -45.0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_VerticalViewAngle45deg, ref nullable_).HasValue)
				{
					return false;
				}
				switch ((!(num3 < 315.0) || num3 <= 45.0) ? ((Aircraft)activeUnit_0).VisibilityForward : ((num3 > 45.0 && !(num3 >= 135.0)) ? ((Aircraft)activeUnit_0).VisibilitySideways : ((!(num3 >= 135.0) || num3 > 225.0) ? ((Aircraft)activeUnit_0).VisibilitySideways : ((Aircraft)activeUnit_0).VisibilityAft)))
				{
				case Aircraft.CockpitVisibility.Excellent:
					if (GameGeneral.LockRandom_0.Next(1, 101) > 95 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_RNG_ExcellentCockpitVisibility, ref nullable_).HasValue)
					{
						return false;
					}
					break;
				case Aircraft.CockpitVisibility.Average:
					if (num < -25.0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_AverageCockpitVisibility_VerticalViewAngle25deg, ref nullable_).HasValue)
					{
						return false;
					}
					if (GameGeneral.LockRandom_0.Next(1, 101) > 50 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_RNG_AverageCockpitVisibility, ref nullable_).HasValue)
					{
						return false;
					}
					break;
				case Aircraft.CockpitVisibility.Poor:
					if (GameGeneral.LockRandom_0.Next(1, 101) > 2 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_RNG_PoorCockpitVisibility, ref nullable_).HasValue)
					{
						return false;
					}
					break;
				}
			}
			if (nullable_0.HasValue)
			{
				int? num4 = (int?)nullable_0;
				if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() != 1) : null).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_LOS, ref nullable_).HasValue)
				{
					return false;
				}
			}
			bool num5 = (activeUnit_1.IsShip || activeUnit_1.IsSubmarine) | (activeUnit_1.IsMobileGroundUnit && !Module_Unit.ResetTokenizer(activeUnit_1));
			bool flag = activeUnit_0.IsAircraft || activeUnit_0.IsMissile || activeUnit_0.IsSatellite;
			bool flag2 = false;
			if (num5 && flag)
			{
				float float_ = 0f;
				Ship.ShipWakeSize shipWakeSize = Ship.ShipWakeSize.NoWake;
				if (activeUnit_1.IsShip)
				{
					shipWakeSize = ((Ship)activeUnit_1).WakeSize;
				}
				if (activeUnit_1.IsSubmarine)
				{
					shipWakeSize = ((Submarine)activeUnit_1).WakeSize;
				}
				if (activeUnit_1.IsVehicle)
				{
					shipWakeSize = ((Vehicle)activeUnit_1).WakeSize;
				}
				switch (shipWakeSize)
				{
				case Ship.ShipWakeSize.NoWake:
					float_ = 0f;
					break;
				case Ship.ShipWakeSize.VSmall:
					float_ = 3f;
					break;
				case Ship.ShipWakeSize.Small:
					float_ = 10f;
					break;
				case Ship.ShipWakeSize.Medium:
					float_ = 19f;
					break;
				case Ship.ShipWakeSize.Large:
					float_ = 25f;
					break;
				case Ship.ShipWakeSize.VLarge:
					float_ = 32f;
					break;
				}
				ForgotWriter(activeUnit_0, activeUnit_1, ref float_);
				flag2 = float_ > float_0;
			}
			bool flag3 = false;
			if (activeUnit_1.IsAircraft)
			{
				float float_2 = 0f;
				switch (activeUnit_1.FlushIssuer())
				{
				case ActiveUnit.AirContrailSize.NoContrail:
					float_2 = 0f;
					break;
				case ActiveUnit.AirContrailSize.VSmall:
					float_2 = 2f;
					break;
				case ActiveUnit.AirContrailSize.Small:
					float_2 = 10f;
					break;
				case ActiveUnit.AirContrailSize.Medium:
					float_2 = 20f;
					break;
				case ActiveUnit.AirContrailSize.Large:
					float_2 = 30f;
					break;
				case ActiveUnit.AirContrailSize.VLarge:
					float_2 = 50f;
					break;
				}
				if (activeUnit_0.IsAircraft && flag2)
				{
					float num6 = 1f;
					float num19;
					if (!(num < 0.0))
					{
						num19 = 0.9f;
					}
					else
					{
						LandCover.LandCoverType landCoverType = LandCover.DestroyClass(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_0.ParentScen);
						if (1 == 0)
						{
						}
						float num20 = landCoverType switch
						{
							LandCover.LandCoverType.SnowAndIce => 1f, 
							LandCover.LandCoverType.Water => 0.8f, 
							_ => 0.7f, 
						};
						if (1 == 0)
						{
						}
						num19 = num20;
					}
					num6 = num19;
					flag2 = float_0 * num6 > float_0;
				}
				ForgotWriter(activeUnit_0, activeUnit_1, ref float_2);
				flag3 = float_2 > float_0;
			}
			if (activeUnit_1.IsPlatform && ((Platform)activeUnit_1).RepresentsMobileGroundUnit && Module_Unit.ResetTokenizer(activeUnit_1) && ((activeUnit_1.IsFacility || activeUnit_1.IsMobileGroundUnit) & (activeUnit_1.CurrentSpeed > 0f)))
			{
				flag2 = (float)(int)Math.Round(QueryWriter(activeUnit_0, activeUnit_1, bool_0: true, bool_1: true, bool_2: true) * (1f + activeUnit_1.CurrentSpeed / 10f)) > float_0;
			}
			bool flag4;
			if (!(flag4 = float_0 <= maxRange) && !flag2 && !flag3 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_MaxNominalRange, ref nullable_).HasValue)
			{
				return false;
			}
			bool flag5;
			if ((flag5 = flag4 && !flag2 && !flag3) && !activeUnit_0.IsSatellite && !activeUnit_0.IsWeapon)
			{
				bool flag6 = false;
				if (activeUnit_0.CommStuff.IsConnectedToSideNetwork)
				{
					flag6 = activeUnit_0.GetUnitSide().Contacts.ContainsKey(activeUnit_1.ObjectID);
				}
				else
				{
					foreach (Contact item in Module_ActiveUnit_Sensory.ListTokenizer(activeUnit_0.Sensory))
					{
						if (Operators.CompareString(item?.ActualUnit?.ObjectID, activeUnit_1.ObjectID, TextCompare: false) == 0)
						{
							flag6 = true;
							break;
						}
					}
				}
				if (!flag6)
				{
					int num7 = VolumeSearchRange_Visual(this);
					if (float_0 > (float)num7)
					{
						return false;
					}
				}
			}
			if (flag5)
			{
				if (QueryWriter(activeUnit_0, activeUnit_1, bool_0: false, bool_1: false, bool_2: true) < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_MaxSpecificRange, ref nullable_).HasValue)
				{
					return false;
				}
				if (!bool_0)
				{
					float num8 = QueryWriter(activeUnit_0, activeUnit_1, bool_0: true, bool_1: false, bool_2: true);
					if (num8 < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_MaxSpecificRange, ref nullable_).HasValue)
					{
						return false;
					}
					if (activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced) && !activeUnit_0.IsSatellite && !activeUnit_1.IsSatellite)
					{
						Side natureSide = activeUnit_1.ParentScen.GetNatureSide();
						float float_3 = activeUnit_0.GetCurrentAltitude() + (float)activeUnit_0.GetMastHeight_Visual(this);
						foreach (Tuple<LandCover.LandCoverType, int> allLandCoverAndCoverElevationBetweenPoint in LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), float_3, activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetCurrentAltitude(), activeUnit_0.ParentScen, natureSide))
						{
							float landCoverMaxDetectionRangeModifier_Visual = GetLandCoverMaxDetectionRangeModifier_Visual(allLandCoverAndCoverElevationBetweenPoint.Item1);
							num8 *= landCoverMaxDetectionRangeModifier_Visual;
							if (num8 < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_MaxSpecificRange, ref nullable_).HasValue)
							{
								return false;
							}
						}
					}
				}
			}
			if (Capabilities.SpaceSearch_ABM && activeUnit_1.IsWeapon)
			{
				Weapon._WeaponType type = ((Weapon)activeUnit_1).Type;
				if ((uint)(type - 5000) <= 1u || type == Weapon._WeaponType.HGV)
				{
					float float_4 = (int)Math.Round(activeUnit_1.GetCurrentAltitude());
					if (Horizon.OrderInvocation(activeUnit_0, ref float_4, this) > Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude()) && flag4)
					{
						if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.VISUAL_ABM_Horizon_Successful, ref nullable_).HasValue)
						{
							return true;
						}
					}
					else if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_ABM_Horizon_Failed, ref nullable_).HasValue)
					{
						return false;
					}
				}
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
			}
			bool result;
			if (!(result = nullable_0.Value == Module_Unit.Unit.LOSCheckResult.Success) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.VISUAL_LOS, ref nullable_).HasValue)
			{
				return false;
			}
			if (nullable_.HasValue)
			{
				return nullable_.Value;
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100724", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool RegisterWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, ref Lazy<Dictionary<int, EmissionContainer>> lazy_0, ref bool? nullable_0, ref bool? nullable_1, bool bool_0 = false)
	{
		if (activeUnit_1.Sensory.InterruptConsumer().AwakeIssuer())
		{
			bool? nullable_2 = null;
			if (maxRange < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_MaxRange, ref nullable_2).HasValue)
			{
				return false;
			}
			try
			{
				Sensor[] sensors_Cached = activeUnit_1.Sensors_Cached;
				bool result = false;
				Sensor[] array = sensors_Cached;
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (sensor.Capabilities.OTH_SurfaceWave)
					{
						if (nullable_1.HasValue)
						{
							bool? flag = nullable_1;
							if (((!flag) ?? flag).GetValueOrDefault())
							{
								FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_OTHSW_Emitter_LOS, ref nullable_2);
								continue;
							}
						}
					}
					else if (nullable_0.HasValue)
					{
						bool? flag2 = nullable_0;
						if (((!flag2) ?? flag2).GetValueOrDefault())
						{
							FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_RadarHorizonLOS, ref nullable_2);
							continue;
						}
					}
					if (sensor.Type != Sensor_Type.Radar && !sensor.IsOECM && sensor.Type != Sensor_Type.NonDetectingEmitter)
					{
						continue;
					}
					if (sensor.IsActive)
					{
						if (sensor.IsOperating)
						{
							if (sensor.IsOECM && Role == Sensor_Role.ESM_RWR)
							{
								FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_RWRvsJamming, ref nullable_2);
							}
							else if (sensor.TargetIsWithinCoverageArc(activeUnit_0))
							{
								if (InvokeOrder(sensor))
								{
									bool flag3;
									ActiveEmissionMode activeEmissionMode_ = ((flag3 = sensor.SemiActiveWeaponsGuided.Count > 0 || sensor.IsPureIlluminator) ? ActiveEmissionMode.Illuminate : ActiveEmissionMode.Search_Track);
									if (SetupOrder(sensor, float_0, activeEmissionMode_, activeUnit_0.WeatherAtMyLocation))
									{
										if (!Capabilities.OTH_Backscatter)
										{
											if (sensor.Capabilities.OTH_SurfaceWave)
											{
												if (sensor.maxRange < float_0)
												{
													FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_OTHSW_Emitter_MaxRange, ref nullable_2);
													continue;
												}
												if (!nullable_1.HasValue)
												{
													nullable_1 = Module_Unit.Has_ESM_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
												}
												if (!nullable_1.Value)
												{
													FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_OTHSW_Emitter_LOS, ref nullable_2);
													continue;
												}
											}
											else
											{
												if (!nullable_0.HasValue)
												{
													nullable_0 = Module_Unit.Has_ESM_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen);
												}
												if (!nullable_0.Value)
												{
													FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_RadarHorizonLOS, ref nullable_2);
													continue;
												}
											}
										}
										result = true;
										int key = ((sensor.classFacade == 1001) ? sensor.DBID : sensor.classFacade);
										if (!lazy_0.Value.ContainsKey(key))
										{
											lazy_0.Value.Add(key, new EmissionContainer(0.0, flag3, ESM_PreciseEmitterID));
										}
										if (!lazy_0.Value[key].IsIllumination && flag3)
										{
											lazy_0.Value[key].IsIllumination = true;
										}
										if (!lazy_0.Value[key].PreciseID && ESM_PreciseEmitterID)
										{
											lazy_0.Value[key].PreciseID = true;
										}
										if (activeUnit_0.IsSubmarine)
										{
											if (sensor.Capabilities.PeriscopeSearch)
											{
												activeUnit_0.TimeSinceLastThreatDetection_ESM = 0f;
											}
											else if (sensor.Capabilities.SurfaceSearch && activeUnit_0.GetCurrentAltitude() >= -5f)
											{
												activeUnit_0.TimeSinceLastThreatDetection_ESM = 0f;
											}
										}
										if (!activeUnit_0.IsAircraft && !activeUnit_0.IsShip && !activeUnit_0.IsSubmarine && !activeUnit_0.IsFacility)
										{
											continue;
										}
										if (activeUnit_0.IncomingGuidedWeaponsList.Length == 0)
										{
											if (flag3)
											{
												Contact contact = activeUnit_0.GetUnitSide().Contacts[activeUnit_1.ObjectID];
												if (contact != null)
												{
													activeUnit_0.Sensory.HandleAssumedWeaponContactFromGuidanceDetection(contact, this, sensor, float_0, lazy_0.Value);
												}
											}
											continue;
										}
										Contact contact2 = activeUnit_0.GetUnitSide().Contacts[activeUnit_1.ObjectID];
										if (contact2 == null)
										{
											continue;
										}
										if (contact2.GetStance(activeUnit_0.GetUnitSide()) != Misc.PostureStance.Hostile)
										{
											Contact contact3 = activeUnit_1.GetUnitSide().Contacts[activeUnit_0.ObjectID];
											if (contact3 != null && sensor.TargetsTrackedForFireControl_Readonly.Contains(contact3))
											{
												contact2.SetStance(activeUnit_0.GetUnitSide(), bool_0: false, Misc.PostureStance.Hostile);
												string text = "";
												if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
												{
													text = " (" + activeUnit_0.UnitClass + ")";
												}
												activeUnit_0.ParentScen.AddMessage("目标：" + contact2.Name + "正照射" + activeUnit_0.Name + text + "现在被认为是敌对的！", contact2.Name + " 现在是敌方！", LoggedMessage.MessageType.ContactChange, 0, null, activeUnit_0.GetUnitSide(), new Geopoint_Struct(contact2.GetLongitude(), contact2.GetLatitude()));
											}
										}
										if (flag3)
										{
											activeUnit_0.Sensory.HandleAssumedWeaponContactFromGuidanceDetection(contact2, this, sensor, float_0, lazy_0.Value);
										}
									}
									else
									{
										FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_Equation, ref nullable_2);
									}
								}
								else
								{
									FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_IncompatibleFrequency, ref nullable_2);
								}
							}
							else
							{
								FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_RWRvsJamming, ref nullable_2);
							}
						}
						else
						{
							FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_EmitterNotActive, ref nullable_2);
						}
					}
					else
					{
						FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ESM_EmitterNotActive, ref nullable_2);
					}
				}
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100725", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return false;
			}
		}
		return false;
	}

	private bool ManageWriter(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0)
	{
		try
		{
			bool? nullable_ = null;
			if (activeUnit_1.IsBoat)
			{
				if (activeUnit_1.IsSubmarine)
				{
					Submarine._SubmarineType type = ((Submarine)activeUnit_1).Type;
					if ((type == Submarine._SubmarineType.None || type == Submarine._SubmarineType.Biologics) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.MAD_UnitIsSubBiologics, ref nullable_).HasValue)
					{
						return false;
					}
				}
				if (activeUnit_1.IsTorpedo && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.MAD_UnitIsTorpedo, ref nullable_).HasValue)
				{
					return false;
				}
				double num = (double)(int)Math.Round(((IBoat)activeUnit_1).Displacement_Standard) / 24500.0;
				double num2 = (double)maxRange * num;
				if (activeUnit_1.IsSubmarine && ((Submarine)activeUnit_1).Flags.NonmagneticHull)
				{
					num2 /= 2.0;
				}
				int num3 = (int)Math.Round((float)Math.Abs(Terrain.GetElevation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen)) - Math.Abs(activeUnit_1.GetCurrentAltitude()));
				if (num3 < 50)
				{
					num2 /= 2.0;
				}
				else if (num3 < 100)
				{
					num2 *= 0.75;
				}
				bool flag = num2 >= (double)float_0;
				if (FeedSensorFailureItem(flag, SensorDetectionFeedback.MAD_MaxEffectiveRange, ref nullable_).HasValue)
				{
					return flag;
				}
				return false;
			}
			FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.MAD_IsNotBoatType, ref nullable_);
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100726", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private float RevertWriter(int int_0, ActiveUnit activeUnit_0)
	{
		return 0f;
	}

	private float CountOrder(ActiveUnit activeUnit_0)
	{
		float num = 1f;
		try
		{
			float currentAltitude_AGL = activeUnit_0.CurrentAltitude_AGL;
			if (currentAltitude_AGL < 10f)
			{
				num = 0.2f;
			}
			else if (currentAltitude_AGL < 20f)
			{
				num = 0.4f;
			}
			else if (currentAltitude_AGL < 30f)
			{
				num = 0.7f;
			}
			if (num == 1f)
			{
				return num;
			}
			switch (TechGeneration)
			{
			default:
				throw new NotImplementedException();
			case GlobalVariables.TechGenerationClass.Early1950s:
			case GlobalVariables.TechGenerationClass.Late1950s:
				num = num;
				break;
			case GlobalVariables.TechGenerationClass.Early1960s:
			case GlobalVariables.TechGenerationClass.Late1960s:
				num = (float)((double)num + 0.1);
				break;
			case GlobalVariables.TechGenerationClass.Early1970s:
			case GlobalVariables.TechGenerationClass.Late1970s:
				num = (float)((double)num + 0.2);
				break;
			case GlobalVariables.TechGenerationClass.Early1980s:
			case GlobalVariables.TechGenerationClass.Late1980s:
				num = (float)((double)num + 0.3);
				break;
			case GlobalVariables.TechGenerationClass.Early1990s:
			case GlobalVariables.TechGenerationClass.Late1990s:
				num = (float)((double)num + 0.4);
				break;
			case GlobalVariables.TechGenerationClass.Early2000s:
			case GlobalVariables.TechGenerationClass.Late2000s:
				num = (float)((double)num + 0.5);
				break;
			case GlobalVariables.TechGenerationClass.Early2010s:
			case GlobalVariables.TechGenerationClass.Late2010s:
				num = (float)((double)num + 0.6);
				break;
			case GlobalVariables.TechGenerationClass.Early2020s:
			case GlobalVariables.TechGenerationClass.Late2020s:
				num = (float)((double)num + 0.7);
				break;
			}
			FrequencyBand frequencyBand = SearchFreqs[0].Band - 4001;
			if ((ulong)frequencyBand <= 3uL && (ulong)frequencyBand <= 3uL)
			{
				FrequencyBand frequencyBand2 = frequencyBand;
				FrequencyBand frequencyBand3 = frequencyBand2;
				if ((ulong)frequencyBand3 <= 3uL)
				{
					switch (frequencyBand3)
					{
					case (FrequencyBand)0L:
						num = (float)((double)num - 0.3);
						goto IL_01d3;
					case (FrequencyBand)1L:
						num = (float)((double)num - 0.1);
						goto IL_01d3;
					case (FrequencyBand)2L:
						num = num;
						goto IL_01d3;
					case (FrequencyBand)3L:
						{
							num = (float)((double)num - 0.5);
							goto IL_01d3;
						}
						IL_01d3:
						return (float)Math.Min(0.9, num);
					}
				}
			}
			throw new NotImplementedException();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101327", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 1f;
		}
	}

	private float CustomizeOrder(double double_0, double double_1, int int_0)
	{
		try
		{
			float num = ((int_0 <= -300) ? 1f : ((int_0 < -50) ? ((float)(0.5 + 0.5 * ((double)(Math.Abs(int_0) - 50) / 250.0))) : 0.5f));
			bool flag = SeaIceProvider.PrepareWriter(double_1, double_0);
			if (num >= 1f && !flag)
			{
				return 1f;
			}
			float num2 = (flag ? 0.5f : num);
			switch (TechGeneration)
			{
			default:
				throw new NotImplementedException();
			case GlobalVariables.TechGenerationClass.Early1950s:
			case GlobalVariables.TechGenerationClass.Late1950s:
				num2 = num2;
				break;
			case GlobalVariables.TechGenerationClass.Early1960s:
			case GlobalVariables.TechGenerationClass.Late1960s:
				num2 = (float)((double)num2 + 0.1);
				break;
			case GlobalVariables.TechGenerationClass.Early1970s:
			case GlobalVariables.TechGenerationClass.Late1970s:
				num2 = (float)((double)num2 + 0.2);
				break;
			case GlobalVariables.TechGenerationClass.Early1980s:
			case GlobalVariables.TechGenerationClass.Late1980s:
				num2 = (float)((double)num2 + 0.3);
				break;
			case GlobalVariables.TechGenerationClass.Early1990s:
			case GlobalVariables.TechGenerationClass.Late1990s:
				num2 = (float)((double)num2 + 0.4);
				break;
			case GlobalVariables.TechGenerationClass.Early2000s:
			case GlobalVariables.TechGenerationClass.Late2000s:
				num2 = (float)((double)num2 + 0.5);
				break;
			case GlobalVariables.TechGenerationClass.Early2010s:
			case GlobalVariables.TechGenerationClass.Late2010s:
				num2 = (float)((double)num2 + 0.6);
				break;
			case GlobalVariables.TechGenerationClass.Early2020s:
			case GlobalVariables.TechGenerationClass.Late2020s:
				num2 = (float)((double)num2 + 0.7);
				break;
			}
			FrequencyBand frequencyBand = SearchFreqs[0].Band - 4001;
			if ((ulong)frequencyBand <= 3uL && (ulong)frequencyBand <= 3uL)
			{
				FrequencyBand frequencyBand2 = frequencyBand;
				FrequencyBand frequencyBand3 = frequencyBand2;
				if ((ulong)frequencyBand3 <= 3uL)
				{
					switch (frequencyBand3)
					{
					case (FrequencyBand)0L:
						num2 = (float)((double)num2 - 0.3);
						goto IL_01e6;
					case (FrequencyBand)1L:
						num2 = (float)((double)num2 - 0.1);
						goto IL_01e6;
					case (FrequencyBand)2L:
						num2 = num2;
						goto IL_01e6;
					case (FrequencyBand)3L:
						{
							num2 = (float)((double)num2 - 0.5);
							goto IL_01e6;
						}
						IL_01e6:
						return (float)Math.Min(0.9, num2);
					}
				}
			}
			throw new NotImplementedException();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100727", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 1f;
		}
	}

	private float CloneOrder(ActiveUnit activeUnit_0, float float_0, float? nullable_0)
	{
		try
		{
			float_0 = Math.Min(1f, float_0 * 2f);
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			float float_ = (nullable_0.HasValue ? nullable_0.Value : ((float)(int)Math.Round(activeUnit_0.GetCurrentAltitude())));
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline = SonarModel.GetPositionRelativeToThermocline(float_, thermalLayerAtThisLocation);
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline2 = SonarModel.GetPositionRelativeToThermocline((int)Math.Round(activeUnit_0.GetCurrentAltitude()), thermalLayerAtThisLocation);
			float strength = thermalLayerAtThisLocation.Strength;
			if (positionRelativeToThermocline != 0 || positionRelativeToThermocline2 != 0)
			{
				if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Inside)
				{
					float_0 = (float)((double)float_0 * Math.Max(0.1, 1f - strength * 2f));
				}
				else if (positionRelativeToThermocline != SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 != SonarModel.PositionRelativeToThermocline.Inside)
				{
					if (positionRelativeToThermocline == positionRelativeToThermocline2)
					{
						if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Below && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Below)
						{
							if (thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel(float_) && thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel((int)Math.Round(activeUnit_0.GetCurrentAltitude())))
							{
								float_0 *= 2f;
							}
							else if (thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel(float_) || thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel((int)Math.Round(activeUnit_0.GetCurrentAltitude())))
							{
								float_0 = (float)((double)float_0 * 1.5);
							}
						}
					}
					else
					{
						float_0 *= 1f - strength;
					}
				}
				else
				{
					float_0 *= 1f - strength / 2f;
				}
			}
			return float_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100728", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			float result = float_0 / 2f;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public bool UsesDeepSoundChannel()
	{
		if (Type == Sensor_Type.BottomFixedSonar_PassiveOnly)
		{
			return true;
		}
		Sensor_Role role = Role;
		if ((ulong)(role - 5191) > 2uL && role != Sensor_Role.SOSUSPassiveSoundSurveillanceSystems)
		{
			return false;
		}
		return true;
	}

	private bool ConnectOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, bool? nullable_0, float? nullable_1 = null)
	{
		try
		{
			bool? nullable_2 = null;
			if (!activeUnit_1.IsOperating() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ACTIVESONAR_NotOperating, ref nullable_2).HasValue)
			{
				return false;
			}
			if (nullable_0.HasValue && ((!nullable_0) ?? nullable_0).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ACTIVESONAR_LOSSonar, ref nullable_2).HasValue)
			{
				return false;
			}
			short num = (short)(IsTowedArray ? 25 : (activeUnit_0.IsTorpedo ? 200 : 30));
			if (activeUnit_0.CurrentSpeed >= (float)num && !activeUnit_0.IsWeapon && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ACTIVESONAR_AboveDeafSpeed, ref nullable_2).HasValue)
			{
				return false;
			}
			if (activeUnit_0.IsTorpedo)
			{
				float_0 = Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1);
			}
			float num8 = maxRange;
			float num9;
			if (activeUnit_0.IsTorpedo)
			{
				num9 = 1f;
			}
			else
			{
				float num10 = activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, bool_0: false);
				float num11;
				float num12;
				if (activeUnit_0.CurrentSpeed <= 5f)
				{
					num11 = 0f;
					num12 = 0f;
				}
				else
				{
					num11 = (float)((double)(activeUnit_0.DesiredSpeed - 5f) / ((double)num10 + 1E-06 - 5.0));
					num12 = (float)((double)(activeUnit_0.CurrentSpeed - 5f) / ((double)num10 + 1E-06 - 5.0));
				}
				num9 = (float)(1.0 - (0.75 * (double)num11 + 0.25 * (double)num12));
				Sensor_Type type = Type;
				if ((uint)(type - 5012) <= 1u || (uint)(type - 5022) <= 1u)
				{
					num9 = CloneOrder(activeUnit_0, num9, nullable_1);
				}
			}
			ActiveUnit parentPlatform = base.ParentPlatform;
			string string_ = "";
			float num13 = Math2.UpdateClass(Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_));
			XSection xSection = smethod_0(activeUnit_1, XSection._SignatureType.ActiveSonar);
			if (Information.IsNothing(xSection))
			{
				FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ACTIVESONAR_Other, ref nullable_2);
				return false;
			}
			if (xSection.isDBInvisible(activeUnit_1))
			{
				FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.DB_Invisible, ref nullable_2);
				return false;
			}
			float num14 = 0f;
			float num15 = 0f;
			if (num13 < 315f && num13 > 45f)
			{
				if ((num13 >= 45f && num13 <= 135f) || (num13 >= 225f && num13 <= 315f))
				{
					num14 = xSection.GetSide(activeUnit_1);
					num15 = (activeUnit_0.IsTorpedo ? 100f : 250f);
				}
				else if (num13 >= 135f && num13 <= 225f)
				{
					num14 = xSection.GetRear(activeUnit_1);
					num15 = (activeUnit_0.IsTorpedo ? 15f : 60f);
				}
			}
			else
			{
				num14 = xSection.GetFront(activeUnit_1);
				num15 = (activeUnit_0.IsTorpedo ? 15f : 60f);
			}
			float num2 = num14 / num15;
			float num3 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1, nullable_1);
			float num4 = CustomizeOrder(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen));
			float num5 = CountOrder(activeUnit_1);
			float num6 = (float)(9.87473 * (double)num3 * (double)num4 * (double)num5);
			float num7 = num8 * num9 * num3 * num4 * num5 * num2;
			bool flag = true;
			bool bool_ = true;
			if (base.ParentPlatform.IsShip && activeUnit_1.IsShip)
			{
				flag = false;
			}
			if (UsesDeepSoundChannel())
			{
				flag = false;
			}
			if (IsDippingSonar)
			{
				flag = false;
			}
			if (bool_ && Terrain.PushWatcher(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), 300, base.ParentPlatform.ParentScen) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ACTIVESONAR_LOSSonar, ref nullable_2).HasValue)
			{
				return false;
			}
			if (flag)
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = Module_Unit.Has_Sonar_LOS_ToUnit(activeUnit_0, activeUnit_1, ref activeUnit_0.ParentScen, ref bool_);
				}
				if (((!nullable_0) ?? nullable_0).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ACTIVESONAR_LOSSonar, ref nullable_2).HasValue)
				{
					return false;
				}
			}
			if (float_0 > num7 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.ACTIVESONAR_MaxRangeSpecificTarget, ref nullable_2).HasValue)
			{
				return false;
			}
			if (float_0 < num6)
			{
				if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.ACTIVESONAR_SuccessfulDirectDetection, ref nullable_2).HasValue)
				{
					return true;
				}
				return false;
			}
			if ((double)float_0 < (double)num6 * 1.2 && SelectOrder(activeUnit_0, activeUnit_1, num7, float_0, num7, nullable_1) && FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.ACTIVESONAR_SuccessfulBottomBounceDetection, ref nullable_2).HasValue)
			{
				return true;
			}
			if (CallOrder(activeUnit_0, activeUnit_1, num7, ref float_0, nullable_1) && FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.ACTIVESONAR_SuccessfulDetectionThroughCZ, ref nullable_2).HasValue)
			{
				return true;
			}
			if (nullable_2.HasValue)
			{
				return nullable_2.Value;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100729", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool MoveOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, Lazy<Dictionary<int, EmissionContainer>> lazy_0, bool? nullable_0)
	{
		try
		{
			if (activeUnit_1.Sensory.InterruptConsumer().AwakeIssuer())
			{
				bool? nullable_ = null;
				if (nullable_0.HasValue && ((!nullable_0) ?? nullable_0).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PING_LOSSonar, ref nullable_).HasValue)
				{
					return false;
				}
				if (maxRange < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PING_MaxRange, ref nullable_).HasValue)
				{
					return false;
				}
				if (!nullable_0.HasValue)
				{
					bool flag = true;
					if (base.ParentPlatform.IsShip && activeUnit_1.IsShip)
					{
						flag = false;
					}
					if (Type == Sensor_Type.PingIntercept && activeUnit_1.IsAircraft && ((Aircraft)activeUnit_1).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
					{
						flag = false;
					}
					if (flag)
					{
						ref Scenario parentScen = ref activeUnit_0.ParentScen;
						bool bool_ = false;
						nullable_0 = Module_Unit.Has_Sonar_LOS_ToUnit(activeUnit_0, activeUnit_1, ref parentScen, ref bool_);
						if (((!nullable_0) ?? nullable_0).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PING_LOSSonar, ref nullable_).HasValue)
						{
							return false;
						}
					}
				}
				float num = activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, bool_0: false);
				float num2 = (float)((double)base.ParentPlatform.DesiredSpeed / ((double)num + 1E-06));
				float num3 = (float)((double)activeUnit_0.CurrentSpeed / ((double)num + 1E-06));
				float num4 = (float)(1.0 - (0.75 * (double)num2 + 0.25 * (double)num3));
				float num5 = maxRange * num4;
				float num6 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1);
				float num7 = (float)(9.87473 * (double)num6);
				float num8 = num5 * num6;
				bool flag2 = float_0 < num7;
				bool flag3 = CallOrder(activeUnit_0, activeUnit_1, num8, ref float_0);
				bool flag4 = false;
				if ((double)float_0 < (double)num7 * 1.2 && SelectOrder(activeUnit_0, activeUnit_1, num8, float_0, num8))
				{
					flag4 = true;
				}
				Sensor[] sensors_Cached = activeUnit_1.Sensors_Cached;
				bool flag5 = false;
				Sensor[] array = sensors_Cached;
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if ((sensor.IsSonar || sensor.IsPingIntercept) && sensor.IsActive && sensor.IsOperating && sensor.TargetIsWithinCoverageArc(activeUnit_0) && InvokeOrder(sensor) && (flag5 = ((flag2 || flag4 || flag3) ? true : false)))
					{
						int key = ((sensor.classFacade == 1001) ? sensor.DBID : sensor.classFacade);
						if (!lazy_0.Value.ContainsKey(key))
						{
							lazy_0.Value.Add(key, new EmissionContainer(0.0, bool_0: false, ESM_PreciseEmitterID));
						}
						if (!lazy_0.Value[key].PreciseID && ESM_PreciseEmitterID)
						{
							lazy_0.Value[key].PreciseID = true;
						}
					}
				}
				if (flag5)
				{
					if (nullable_.HasValue)
					{
						return nullable_.Value;
					}
					return flag5;
				}
				if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PING_NoInterceptionFromAnyEmitter, ref nullable_).HasValue)
				{
					return false;
				}
				if (nullable_.HasValue)
				{
					return nullable_.Value;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100730", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static float DeleteOrder(object object_0)
	{
		float num = ((ActiveUnit)object_0).Kinematics.GetMaximumSpeed(((ActiveUnit)object_0).Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, bool_0: false, bool_1: false);
		if (num == 0f)
		{
			return 0f;
		}
		return (float)((double)((Module_Unit.Unit)object_0).CurrentSpeed / ((double)num + 1E-06));
	}

	private static float AddOrder(object object_0)
	{
		float num = ((ActiveUnit)object_0).Kinematics.GetMaximumSpeed(((ActiveUnit)object_0).Kinematics.GetMinimumAltitude(), ActiveUnit.Throttle.Flank, bool_0: false);
		if (num == 0f)
		{
			return 0f;
		}
		bool flag = false;
		if (((ActiveUnit)object_0).SubType == 9001)
		{
			flag = true;
		}
		float num2 = ((ActiveUnit)object_0).DesiredSpeed;
		if (((Module_Unit.Unit)object_0).CurrentSpeed == 0f)
		{
			num2 = 0f;
		}
		return (float)(((((ScenarioObject)object_0).IsShip && ((Ship)object_0).IsNuke) || (((ScenarioObject)object_0).IsSubmarine && ((Submarine)object_0).IsNuke)) ? Math.Min(1.0, (double)(num2 + 5f) / ((double)num + 1E-06)) : (flag ? Math.Min(1.0, (double)(num2 + 5f) / ((double)num + 0.0001)) : ((double)num2 / ((double)num + 1E-06))));
	}

	public static (float FrontalAspectValue, float SideAspectValue, float RearAspectValue) NavalUnitNoiseInDecibels(ActiveUnit activeUnit_0, FrequencyBand frequencyBand_0)
	{
		(float, float, float) result;
		if (!activeUnit_0.IsBoat && !activeUnit_0.IsTorpedo)
		{
			result = (0f, 0f, 0f);
		}
		else
		{
			XSection xSection = null;
			FrequencyBand frequencyBand = frequencyBand_0 - 4001;
			if ((ulong)frequencyBand <= 3uL && (ulong)frequencyBand <= 3uL)
			{
				FrequencyBand frequencyBand2 = frequencyBand;
				FrequencyBand frequencyBand3 = frequencyBand2;
				if ((ulong)frequencyBand3 <= 3uL)
				{
					switch (frequencyBand3)
					{
					case (FrequencyBand)0L:
						xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_LF);
						if (xSection == null)
						{
							xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_LF);
						}
						break;
					case (FrequencyBand)1L:
						xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_MF);
						if (xSection == null)
						{
							xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_MF);
						}
						break;
					case (FrequencyBand)2L:
						xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_HF);
						if (xSection == null)
						{
							xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_HF);
						}
						break;
					case (FrequencyBand)3L:
						xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
						if (xSection == null)
						{
							xSection = smethod_0(activeUnit_0, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
						}
						break;
					}
				}
			}
			if (xSection == null)
			{
				result = (0f, 0f, 0f);
			}
			else if (xSection.isDBInvisible(activeUnit_0))
			{
				result = (0f, 0f, 0f);
			}
			else
			{
				bool flag = false;
				if (activeUnit_0.IsSubmarine)
				{
					Submarine submarine = (Submarine)activeUnit_0;
					if (submarine.PrimaryEngine != null && submarine.AI.SelectFuelTypeToConsume(submarine.PrimaryEngine) == FuelRec._FuelType.DieselFuel)
					{
						flag = true;
					}
					else if (submarine.PrimaryEngine == null && Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				bool flag2 = activeUnit_0.IsBoat && ((IBoat)activeUnit_0).IsCavitating();
				List<float> list = new List<float>();
				list.Add(xSection.GetFront(activeUnit_0));
				list.Add(xSection.GetSide(activeUnit_0));
				list.Add(xSection.GetRear(activeUnit_0));
				double num = AddOrder(activeUnit_0);
				float num2 = DeleteOrder(activeUnit_0);
				float num3 = (float)(0.75 * num + 0.25 * (double)num2);
				int num4 = list.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					float num5 = list[i];
					num5 *= num3;
					if (flag2)
					{
						float num6 = activeUnit_0.Kinematics.CavitationSpeed(activeUnit_0.GetCurrentAltitude());
						float num7 = (float)activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.GetCurrentAltitude()) - num6;
						if (num7 == 0f)
						{
							num5 += 15f;
						}
						else
						{
							float num8 = (activeUnit_0.DesiredSpeed - num6) / num7;
							num5 += 15f * num8;
						}
					}
					if (flag)
					{
						float num9 = (float)(15.0 * Math.Pow(((double)activeUnit_0.DesiredSpeed + 0.0001) / (double)activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.GetCurrentAltitude()), 2.0));
						if (float.IsNaN(num9) || num9 > 15f)
						{
							num9 = 15f;
						}
						num5 += num9;
					}
					list[i] = num5;
				}
				result = (list[0], list[1], list[2]);
			}
		}
		return result;
	}

	private float DestroyOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float? nullable_0 = null)
	{
		float num;
		if (IsDippingSonar)
		{
			num = 1f;
		}
		else
		{
			float num3;
			float num4;
			if (activeUnit_0.CurrentSpeed <= 5f)
			{
				num3 = 0f;
				num4 = 0f;
			}
			else
			{
				num3 = AddOrder(activeUnit_0);
				num4 = DeleteOrder(activeUnit_0);
			}
			num = (float)(1.0 - (0.75 * (double)num3 + 0.25 * (double)num4));
			Sensor_Type type = Type;
			if ((uint)(type - 5012) <= 1u || (uint)(type - 5022) <= 1u)
			{
				num = CloneOrder(activeUnit_0, num, nullable_0);
			}
		}
		if (activeUnit_0.IsTorpedo)
		{
			num = (float)Math.Max(0.9, num);
		}
		(float, float, float) tuple = NavalUnitNoiseInDecibels(activeUnit_1, SearchFreqs[0].Band);
		string string_ = "";
		float num5 = Module_Unit.PrintTokenizer(activeUnit_0, activeUnit_1, bool_0: false, ref string_);
		float num6 = 0f;
		if (!(num5 < 315f) || !(num5 > 45f))
		{
			(num6, _, _) = tuple;
		}
		else if ((num5 >= 45f && num5 <= 135f) || (num5 >= 225f && num5 <= 315f))
		{
			num6 = tuple.Item2;
		}
		else if (num5 >= 135f && num5 <= 225f)
		{
			num6 = tuple.Item3;
		}
		FrequencyBand frequencyBand = SearchFreqs[0].Band - 4001;
		int num7 = 0;
		if ((ulong)frequencyBand <= 3uL && (ulong)frequencyBand <= 3uL)
		{
			FrequencyBand frequencyBand2 = frequencyBand;
			FrequencyBand frequencyBand3 = frequencyBand2;
			if ((ulong)frequencyBand3 <= 3uL)
			{
				switch (frequencyBand3)
				{
				case (FrequencyBand)0L:
					num7 = 112;
					break;
				case (FrequencyBand)1L:
					num7 = 104;
					break;
				case (FrequencyBand)2L:
					num7 = 96;
					break;
				case (FrequencyBand)3L:
					num7 = 142;
					break;
				}
			}
		}
		float num8 = num6 / (float)num7;
		float num9 = maxRange * num * num8;
		float num10 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1, nullable_0);
		float num2 = CustomizeOrder(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen));
		return num9 * num10 * num2;
	}

	private bool ComputeOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, Lazy<Dictionary<int, EmissionContainer>> lazy_0, bool bool_0, bool? nullable_0, float? nullable_1 = null)
	{
		try
		{
			bool? nullable_2 = null;
			if (!activeUnit_1.IsOperating() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_NotOperating, ref nullable_2).HasValue)
			{
				return false;
			}
			if (DetectionChecksThisPulse == null)
			{
				DetectionChecksThisPulse = new Dictionary<string, bool>();
			}
			if (DetectionChecksThisPulse.ContainsKey(activeUnit_1.ObjectID))
			{
				DetectionChecksThisPulse[activeUnit_1.ObjectID] = false;
			}
			else
			{
				DetectionChecksThisPulse.Add(activeUnit_1.ObjectID, value: false);
			}
			if (nullable_0.HasValue && ((!nullable_0) ?? nullable_0).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_LOSSonar, ref nullable_2).HasValue)
			{
				return false;
			}
			if (Type == Sensor_Type.BottomFixedSonar_PassiveOnly)
			{
				nullable_1 = activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen) + 1;
			}
			if (activeUnit_0.IsTorpedo)
			{
				float_0 = Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnit_1);
			}
			short num = (short)(IsTowedArray ? 25 : (activeUnit_0.IsTorpedo ? 200 : 30));
			if (activeUnit_0.CurrentSpeed >= (float)num && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_AboveDeafSpeed, ref nullable_2).HasValue)
			{
				return false;
			}
			if (float_0 > maxRange && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_MaxNominalRange, ref nullable_2).HasValue)
			{
				return false;
			}
			bool flag = true;
			bool bool_ = true;
			if (base.ParentPlatform.IsShip && activeUnit_1.IsShip)
			{
				flag = false;
			}
			if (UsesDeepSoundChannel())
			{
				flag = false;
			}
			if (IsDippingSonar)
			{
				flag = false;
			}
			float num2 = DestroyOrder(activeUnit_0, activeUnit_1, nullable_1);
			float num3 = SonarPropagationModifier(UsesDeepSoundChannel(), activeUnit_0, activeUnit_1, nullable_1);
			float num4 = CustomizeOrder(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), Terrain.GetElevation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen));
			float num5 = (float)(9.87473 * (double)num3 * (double)num4);
			if (!bool_0)
			{
				float float_ = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnit_1);
				float num6;
				switch (TechGeneration)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					num6 = 10f;
					break;
				case GlobalVariables.TechGenerationClass.Early1950s:
					num6 = 20f;
					break;
				case GlobalVariables.TechGenerationClass.Late1950s:
					num6 = 17.5f;
					break;
				case GlobalVariables.TechGenerationClass.Early1960s:
					num6 = 15f;
					break;
				case GlobalVariables.TechGenerationClass.Late1960s:
					num6 = 14f;
					break;
				case GlobalVariables.TechGenerationClass.Early1970s:
					num6 = 13f;
					break;
				case GlobalVariables.TechGenerationClass.Late1970s:
					num6 = 12f;
					break;
				case GlobalVariables.TechGenerationClass.Early1980s:
					num6 = 11f;
					break;
				case GlobalVariables.TechGenerationClass.Late1980s:
					num6 = 10f;
					break;
				case GlobalVariables.TechGenerationClass.Early1990s:
					num6 = 9f;
					break;
				case GlobalVariables.TechGenerationClass.Late1990s:
					num6 = 8f;
					break;
				case GlobalVariables.TechGenerationClass.Early2000s:
					num6 = 7f;
					break;
				case GlobalVariables.TechGenerationClass.Late2000s:
					num6 = 6f;
					break;
				case GlobalVariables.TechGenerationClass.Early2010s:
					num6 = 5f;
					break;
				case GlobalVariables.TechGenerationClass.Late2010s:
					num6 = 4f;
					break;
				case GlobalVariables.TechGenerationClass.Early2020s:
					num6 = 3f;
					break;
				case GlobalVariables.TechGenerationClass.Late2020s:
					num6 = 2f;
					break;
				}
				foreach (ActiveUnit activeUnits_ in activeUnit_0.ParentScen.ActiveUnits_List)
				{
					if (activeUnits_ == null || (!activeUnits_.IsShip && !activeUnits_.IsSubmarine && !activeUnits_.IsTorpedo) || activeUnits_ == activeUnit_1 || !activeUnits_.IsOperating())
					{
						continue;
					}
					float float_2 = Module_Unit.BearingToUnit_True(activeUnit_0, activeUnits_);
					if (Math.Abs(MathFunctions.DeleteRequest(float_, float_2)) >= num6 || !TargetIsWithinCoverageArc(activeUnits_))
					{
						continue;
					}
					switch (PatchOrder(activeUnits_))
					{
					case (SensorDetectionCheck)2:
						if (DestroyOrder(activeUnit_0, activeUnits_, nullable_1) <= num2)
						{
							break;
						}
						if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_SignalMaskedByAnother, ref nullable_2).HasValue)
						{
							return false;
						}
						goto end_IL_0548;
					case (SensorDetectionCheck)0:
						if (ComputeOrder(activeUnit_0, activeUnits_, Module_Unit.RangeToUnit_Horiz(activeUnit_0, activeUnits_), new Lazy<Dictionary<int, EmissionContainer>>(), bool_0: true, null, nullable_1) && !(DestroyOrder(activeUnit_0, activeUnits_, nullable_1) <= num2))
						{
							if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_SignalMaskedByAnother, ref nullable_2).HasValue)
							{
								return false;
							}
							goto end_IL_0548;
						}
						break;
					}
					continue;
					end_IL_0548:
					break;
				}
			}
			if (float_0 > num2 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_MaxActualRange, ref nullable_2).HasValue)
			{
				return false;
			}
			if (bool_ && Terrain.PushWatcher(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), 300, base.ParentPlatform.ParentScen) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_LandmassInBetween, ref nullable_2).HasValue)
			{
				return false;
			}
			if (flag)
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = Module_Unit.Has_Sonar_LOS_ToUnit(activeUnit_0, activeUnit_1, ref activeUnit_0.ParentScen, ref bool_);
				}
				if (((!nullable_0) ?? nullable_0).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_LOSSonar, ref nullable_2).HasValue)
				{
					return false;
				}
			}
			if (!UsesDeepSoundChannel())
			{
				if (CallOrder(activeUnit_0, activeUnit_1, num2, ref float_0, nullable_1) && float_0 < num2)
				{
					DetectionChecksThisPulse[activeUnit_1.ObjectID] = true;
					if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.PASSIVESONAR_SuccessfulDetectionThroughCZ, ref nullable_2).HasValue)
					{
						return true;
					}
				}
				else if (float_0 > num5 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.PASSIVESONAR_CZBlockingAndNoDirectPath, ref nullable_2).HasValue)
				{
					return false;
				}
			}
			DetectionChecksThisPulse[activeUnit_1.ObjectID] = true;
			if (nullable_2.HasValue)
			{
				return nullable_2.Value;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100731", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private SensorDetectionCheck PatchOrder(ActiveUnit activeUnit_0)
	{
		if (DetectionChecksThisPulse == null)
		{
			return (SensorDetectionCheck)0;
		}
		bool value = false;
		if (DetectionChecksThisPulse.TryGetValue(activeUnit_0.ObjectID, out value))
		{
			if (value)
			{
				return (SensorDetectionCheck)2;
			}
			return (SensorDetectionCheck)1;
		}
		return (SensorDetectionCheck)0;
	}

	public float SonarPropagationModifier(bool bool_0, ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float? nullable_0 = null)
	{
		float float_ = 1f;
		ViewOrder(activeUnit_0, activeUnit_1, ref float_, nullable_0);
		if (bool_0)
		{
			LogoutOrder(activeUnit_0, activeUnit_1, ref float_, nullable_0);
		}
		return float_;
	}

	public static void EffectOfSurfaceDuct(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0, float? nullable_0 = null)
	{
		float num = (nullable_0.HasValue ? nullable_0.Value : activeUnit_0.GetCurrentAltitude());
		if (num >= -50f && (activeUnit_1 == null || activeUnit_1.GetCurrentAltitude() >= -50f))
		{
			float num2 = 1f - Math.Abs(num) / (float)Math.Abs(-50);
			if (activeUnit_1 == null)
			{
				float_0 = (float)((double)float_0 * (1.0 + 0.5 * (double)num2));
				return;
			}
			float num3 = 1f - (Math.Abs(num) + Math.Abs(activeUnit_1.GetCurrentAltitude())) / (float)(2 * Math.Abs(-50));
			float_0 = (float)((double)float_0 * (1.0 + 0.5 * (double)num3));
		}
	}

	private bool SelectOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, float float_1, float float_2, float? nullable_0 = null)
	{
		float num = (nullable_0.HasValue ? nullable_0.Value : ((float)(int)Math.Round(activeUnit_0.GetCurrentAltitude())));
		float num2 = float_2;
		try
		{
			GeoPoint geoPoint = new GeoPoint();
			float num3 = num - (float)Terrain.GetElevation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen);
			float num4 = activeUnit_1.GetCurrentAltitude() - (float)Terrain.GetElevation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen);
			float float_3 = num3 * float_1 / (num3 + num4);
			double longitude = activeUnit_0.GetLongitude();
			double latitude = activeUnit_0.GetLatitude();
			GeoPoint geoPoint2;
			double double_ = (geoPoint2 = geoPoint).Longitude;
			GeoPoint geoPoint3;
			double double_2 = (geoPoint3 = geoPoint).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, float_3, Math2.PublishClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude()));
			geoPoint3.Latitude = double_2;
			geoPoint2.Longitude = double_;
			float float_4 = 1f;
			ViewOrder(activeUnit_0, activeUnit_1, ref float_4, nullable_0);
			if (float_4 < 1f)
			{
				num2 = float_2 * (1f + float_4 / 2f);
			}
			GeoPoint geoPoint4 = new GeoPoint(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), num);
			GeoPoint geoPoint_ = new GeoPoint(activeUnit_1.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetCurrentAltitude());
			if (geoPoint4.RangeToPoint_Slant(geoPoint) + geoPoint.RangeToPoint_Slant(geoPoint_) >= num2)
			{
				return false;
			}
			float num5 = Terrain.InvokeWatcher(geoPoint.Latitude, geoPoint.Longitude, bool_0: false, base.ParentPlatform.ParentScen);
			float num6 = 1f - num5;
			switch (TechGeneration)
			{
			default:
				throw new NotImplementedException();
			case GlobalVariables.TechGenerationClass.Early1960s:
			case GlobalVariables.TechGenerationClass.Late1960s:
				num6 = (float)((double)num6 + 0.1);
				break;
			case GlobalVariables.TechGenerationClass.Early1970s:
			case GlobalVariables.TechGenerationClass.Late1970s:
				num6 = (float)((double)num6 + 0.2);
				break;
			case GlobalVariables.TechGenerationClass.Early1980s:
			case GlobalVariables.TechGenerationClass.Late1980s:
				num6 = (float)((double)num6 + 0.3);
				break;
			case GlobalVariables.TechGenerationClass.Early1990s:
			case GlobalVariables.TechGenerationClass.Late1990s:
				num6 = (float)((double)num6 + 0.4);
				break;
			case GlobalVariables.TechGenerationClass.Early2000s:
			case GlobalVariables.TechGenerationClass.Late2000s:
				num6 = (float)((double)num6 + 0.5);
				break;
			case GlobalVariables.TechGenerationClass.Early2010s:
			case GlobalVariables.TechGenerationClass.Late2010s:
				num6 = (float)((double)num6 + 0.6);
				break;
			case GlobalVariables.TechGenerationClass.Early2020s:
			case GlobalVariables.TechGenerationClass.Late2020s:
				num6 = (float)((double)num6 + 0.7);
				break;
			case GlobalVariables.TechGenerationClass.Early1950s:
			case GlobalVariables.TechGenerationClass.Late1950s:
				break;
			}
			FrequencyBand frequencyBand = SearchFreqs[0].Band - 4001;
			if ((ulong)frequencyBand <= 3uL && (ulong)frequencyBand <= 3uL)
			{
				FrequencyBand frequencyBand2 = frequencyBand;
				FrequencyBand frequencyBand3 = frequencyBand2;
				if ((ulong)frequencyBand3 <= 3uL)
				{
					switch (frequencyBand3)
					{
					case (FrequencyBand)0L:
						num6 = (float)((double)num6 - 0.3);
						goto IL_03af;
					case (FrequencyBand)1L:
						num6 = (float)((double)num6 - 0.1);
						goto IL_03af;
					case (FrequencyBand)2L:
						num6 = num6;
						goto IL_03af;
					case (FrequencyBand)3L:
						{
							num6 = (float)((double)num6 - 0.5);
							goto IL_03af;
						}
						IL_03af:
						num2 *= num6;
						if (num2 <= float_2)
						{
							return true;
						}
						return false;
					}
				}
			}
			throw new NotImplementedException();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100733", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool CallOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, ref float float_1, float? nullable_0 = null)
	{
		try
		{
			float num = SonarModel.smethod_0(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetUnitSide(), activeUnit_0.ParentScen);
			if (num == 0f)
			{
				return false;
			}
			float num2 = 5f;
			float num3 = num + num2;
			int num4 = 1;
			while (true)
			{
				float num5 = (float)((double)((float)num4 * num) - (double)num2 * 0.5);
				float num6 = (float)((double)((float)num4 * num) + (double)num2 * 0.5);
				if (!(num5 <= float_0))
				{
					break;
				}
				if (float_1 <= num5 || num6 <= float_1)
				{
					num4++;
					continue;
				}
				Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
				float float_2 = Math2.PublishClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude());
				int num7 = 0;
				while (true)
				{
					float num8 = num3 * (float)num7 + num / 2f;
					if (!(num8 <= float_1))
					{
						break;
					}
					Geodesic_EdWilliams.CalcPoint_Williams(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude(), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, num8, float_2);
					if (Terrain.GetElevation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, bool_0: false, base.ParentPlatform.ParentScen) <= SonarModel.ConnectSpecification(geopoint_Struct.Latitude))
					{
						num7++;
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100733", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private void LogoutOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0, float? nullable_0 = null)
	{
		try
		{
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation2 = SonarModel.GetThermalLayerAtThisLocation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			float float_ = (nullable_0.HasValue ? nullable_0.Value : ((float)(int)Math.Round(activeUnit_0.GetCurrentAltitude())));
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline = SonarModel.GetPositionRelativeToThermocline(float_, thermalLayerAtThisLocation);
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline2 = SonarModel.GetPositionRelativeToThermocline((int)Math.Round(activeUnit_1.GetCurrentAltitude()), thermalLayerAtThisLocation2);
			if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Below && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Below)
			{
				if (thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel(float_) && thermalLayerAtThisLocation2.GetIsInsideDeepSoundChannel((int)Math.Round(activeUnit_1.GetCurrentAltitude())))
				{
					float_0 *= 2f;
				}
				else if (thermalLayerAtThisLocation.GetIsInsideDeepSoundChannel(float_) || thermalLayerAtThisLocation2.GetIsInsideDeepSoundChannel((int)Math.Round(activeUnit_1.GetCurrentAltitude())))
				{
					float_0 = (float)((double)float_0 * 1.5);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 102134656566777", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ViewOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, ref float float_0, float? nullable_0 = null)
	{
		try
		{
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation = SonarModel.GetThermalLayerAtThisLocation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			SonarModel.ThermoclineLayer thermalLayerAtThisLocation2 = SonarModel.GetThermalLayerAtThisLocation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetLandElevation(bool_0: false, bool_1: false, bool_2: false, base.ParentPlatform.ParentScen), activeUnit_0.ParentScen);
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline = SonarModel.GetPositionRelativeToThermocline(nullable_0.HasValue ? nullable_0.Value : ((float)(int)Math.Round(activeUnit_0.GetCurrentAltitude())), thermalLayerAtThisLocation);
			SonarModel.PositionRelativeToThermocline positionRelativeToThermocline2 = SonarModel.GetPositionRelativeToThermocline((int)Math.Round(activeUnit_1.GetCurrentAltitude()), thermalLayerAtThisLocation2);
			float num = (thermalLayerAtThisLocation.Strength + thermalLayerAtThisLocation2.Strength) / 2f;
			if (num == 0f)
			{
				return;
			}
			if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Above && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Above)
			{
				EffectOfSurfaceDuct(activeUnit_0, activeUnit_1, ref float_0, nullable_0);
			}
			else if (positionRelativeToThermocline == SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 == SonarModel.PositionRelativeToThermocline.Inside)
			{
				float_0 = (float)((double)float_0 * Math.Max(0.1, 1f - num * 2f));
			}
			else if (positionRelativeToThermocline != SonarModel.PositionRelativeToThermocline.Inside && positionRelativeToThermocline2 != SonarModel.PositionRelativeToThermocline.Inside)
			{
				if (positionRelativeToThermocline == positionRelativeToThermocline2)
				{
					if (positionRelativeToThermocline != SonarModel.PositionRelativeToThermocline.Below)
					{
					}
				}
				else
				{
					float_0 *= 1f - num;
				}
			}
			else
			{
				float_0 *= 1f - num / 2f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100734", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool ValidateOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, ref Module_Unit.Unit.LOSCheckResult? nullable_0, bool bool_0 = false)
	{
		try
		{
			bool? nullable_ = null;
			if (nullable_0.HasValue)
			{
				int? num = (int?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() != 1) : null).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.IR_LOSVisual, ref nullable_).HasValue)
				{
					return false;
				}
			}
			if (float_0 > maxRange && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.IR_MaxRange, ref nullable_).HasValue)
			{
				return false;
			}
			if (activeUnit_1.IsSubmarine && Math.Round(activeUnit_1.GetCurrentAltitude()) >= -20.0 && activeUnit_1.GetCurrentAltitude() < -5f && !Capabilities.PeriscopeSearch && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.IR_NoPeriscopeSearchCapability, ref nullable_).HasValue)
			{
				return false;
			}
			if (!activeUnit_0.IsSatellite && !activeUnit_0.IsWeapon)
			{
				bool flag = false;
				if (activeUnit_0.CommStuff.IsConnectedToSideNetwork)
				{
					flag = activeUnit_0.GetUnitSide().Contacts.ContainsKey(activeUnit_1.ObjectID);
				}
				else
				{
					foreach (Contact item in Module_ActiveUnit_Sensory.ListTokenizer(activeUnit_0.Sensory))
					{
						if (Operators.CompareString(item?.ActualUnit?.ObjectID, activeUnit_1.ObjectID, TextCompare: false) == 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					int num2 = VolumeSearchRange_IR(this);
					if (float_0 > (float)num2 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.IR_MaxRange, ref nullable_).HasValue)
					{
						return false;
					}
				}
			}
			if (ResetWriter(activeUnit_0, activeUnit_1, bool_0) < float_0 && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.IR_MaxRange_SpecificToTarget, ref nullable_).HasValue)
			{
				return false;
			}
			if (Capabilities.SpaceSearch_ABM && activeUnit_1.IsWeapon)
			{
				Weapon._WeaponType type = ((Weapon)activeUnit_1).Type;
				if ((uint)(type - 5000) <= 1u || type == Weapon._WeaponType.HGV)
				{
					float float_ = (int)Math.Round(activeUnit_1.GetCurrentAltitude());
					bool result;
					if (!(result = Horizon.OrderInvocation(activeUnit_0, ref float_, this) > Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude())) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.IR_ABM_BeyondHorizon, ref nullable_).HasValue)
					{
						return false;
					}
					if (nullable_.HasValue)
					{
						return nullable_.Value;
					}
					return result;
				}
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
			}
			if (nullable_0.Value == Module_Unit.Unit.LOSCheckResult.Success)
			{
				if (nullable_.HasValue)
				{
					return nullable_.Value;
				}
				return true;
			}
			FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.IR_LOSVisual, ref nullable_);
			if (nullable_.HasValue)
			{
				return nullable_.Value;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100735", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public SensorDetectionCheckResult CanIlluminateTarget(ActiveUnit activeUnit_0, ref Contact contact_0, ref Scenario scenario_0, float float_0, List<ActiveUnit> list_0, bool bool_0, bool bool_1, ref bool? nullable_0, ref bool? nullable_1, ref Module_Unit.Unit.LOSCheckResult? nullable_2, ref bool? nullable_3)
	{
		ActiveUnit actualUnit = contact_0.ActualUnit;
		return CanIlluminateTarget(activeUnit_0, actualUnit, float_0, list_0, bool_0, bool_1, ref nullable_0, ref nullable_1, ref nullable_2, ref nullable_3);
	}

	private SensorDetectionCheckResult LoginOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, List<ActiveUnit> list_0, bool bool_0, bool bool_1, ref bool? nullable_0, ref bool? nullable_1)
	{
		try
		{
			bool? nullable_2 = null;
			if (Capabilities.OTH_SurfaceWave)
			{
				if (nullable_1.HasValue)
				{
					bool? flag = nullable_1;
					if (((!flag) ?? flag).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS_SurfaceWave, ref nullable_2).HasValue)
					{
						return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
					}
				}
			}
			else if (nullable_0.HasValue)
			{
				bool? flag2 = nullable_0;
				if (((!flag2) ?? flag2).GetValueOrDefault() && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS, ref nullable_2).HasValue)
				{
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				}
			}
			if ((!bool_0 || float_0 <= 5f) && !bool_1 && !TargetIsWithinIlluminateCoverageArc(activeUnit_1) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_CoveringArc, ref nullable_2).HasValue)
			{
				return SensorDetectionCheckResult.Fail_OutsideCoverageArc;
			}
			if (TargetsTrackedForFireControl_Readonly.Count > 0)
			{
				bool flag3 = false;
				List<Module_Unit.Unit> list = new List<Module_Unit.Unit>(TargetsTrackedForFireControl_Readonly);
				list.Add(activeUnit_1);
				int num = 0;
				do
				{
					if (!CanTrackAllTargetsAtThisBoresightBearing(this, num, list))
					{
						num++;
						continue;
					}
					flag3 = true;
					break;
				}
				while (num <= 359);
				if (!flag3)
				{
					return SensorDetectionCheckResult.Fail_OutsideCoverageArc;
				}
			}
			ActiveUnit parentPlatform = base.ParentPlatform;
			string string_ = "";
			float num2 = Module_Unit.PrintTokenizer(parentPlatform, activeUnit_1, bool_0: false, ref string_);
			XSection._SignatureType signatureType_ = ((GetIlluminatesInThisFrequency(FrequencyBand.A_Band) || GetIlluminatesInThisFrequency(FrequencyBand.B_Band) || GetIlluminatesInThisFrequency(FrequencyBand.C_Band) || GetIlluminatesInThisFrequency(FrequencyBand.D_Band)) ? XSection._SignatureType.Radar_A_D : XSection._SignatureType.Radar_E_M);
			XSection xSection = smethod_0(activeUnit_1, signatureType_);
			if (xSection == null && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_Other, ref nullable_2).HasValue)
			{
				return SensorDetectionCheckResult.Fail_Other;
			}
			if (xSection.isDBInvisible(activeUnit_1) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.DB_Invisible, ref nullable_2).HasValue)
			{
				return SensorDetectionCheckResult.Fail_Other;
			}
			float float_ = 0f;
			if (num2 < 315f && num2 > 45f)
			{
				if ((num2 >= 45f && num2 <= 135f) || (num2 >= 225f && num2 <= 315f))
				{
					float_ = xSection.GetSide(activeUnit_1);
				}
				else if (num2 >= 135f && num2 <= 225f)
				{
					float_ = xSection.GetRear(activeUnit_1);
				}
			}
			else
			{
				float_ = xSection.GetFront(activeUnit_1);
			}
			if (!ExcludeOrder(activeUnit_0, activeUnit_1, float_, float_0, ActiveEmissionMode.Illuminate, list_0, activeUnit_0.WeatherAtMyLocation) && FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_ECMEquation, ref nullable_2).HasValue)
			{
				return SensorDetectionCheckResult.Fail_NotEnoughReturn;
			}
			if (Capabilities.SpaceSearch_ABM && activeUnit_1.IsWeapon && (((Weapon)activeUnit_1).Type == Weapon._WeaponType.RV || ((Weapon)activeUnit_1).Type == Weapon._WeaponType.HGV))
			{
				if (Horizon.CollectInvocation(activeUnit_0, activeUnit_1, this) <= Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude()))
				{
					if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_ABM_Horizon_Failure, ref nullable_2).HasValue)
					{
						return SensorDetectionCheckResult.Fail_NoLOS_Horizon;
					}
				}
				else if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.RADARILLUMINATION_ABM_Horizon_Success, ref nullable_2).HasValue)
				{
					return SensorDetectionCheckResult.Success;
				}
			}
			if (Capabilities.OTH_SurfaceWave)
			{
				if (!nullable_1.HasValue)
				{
					nullable_1 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
				}
				if (nullable_1.Value)
				{
					if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.RADARILLUMINATION_OTH_Success, ref nullable_2).HasValue)
					{
						return SensorDetectionCheckResult.Success;
					}
				}
				else if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_OTH_Failure, ref nullable_2).HasValue)
				{
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				}
			}
			else
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = Module_Unit.Has_Radar_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen);
				}
				if (nullable_0.Value)
				{
					if (FeedSensorFailureItem(bool_0: true, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS, ref nullable_2).HasValue)
					{
						return SensorDetectionCheckResult.Success;
					}
				}
				else if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_RadarHorizonLOS_Failed, ref nullable_2).HasValue)
				{
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				}
			}
			if (FeedSensorFailureItem(bool_0: false, SensorDetectionFeedback.RADARILLUMINATION_Other, ref nullable_2).HasValue)
			{
				return SensorDetectionCheckResult.Fail_Other;
			}
			return SensorDetectionCheckResult.Undefined;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100736", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return SensorDetectionCheckResult.Undefined;
		}
	}

	private SensorDetectionCheckResult GetOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, bool bool_0, bool bool_1, ref Module_Unit.Unit.LOSCheckResult? nullable_0)
	{
		try
		{
			if (nullable_0.HasValue && nullable_0.Value != Module_Unit.Unit.LOSCheckResult.Success)
			{
				switch (nullable_0.Value)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_Other:
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
					return SensorDetectionCheckResult.Fail_NoLOS_Horizon;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
					return SensorDetectionCheckResult.Fail_NoLOS_Cloud;
				}
			}
			if (!((bool_0 && float_0 > 5f) || bool_1) && !TargetIsWithinIlluminateCoverageArc(activeUnit_1))
			{
				return SensorDetectionCheckResult.Fail_OutsideCoverageArc;
			}
			float num = 0f;
			switch (activeUnit_1.VisualSizeClass)
			{
			case GlobalVariables.TargetVisualSizeClass.Stealthy:
				num = (float)((double)maxRange * 0.1);
				break;
			case GlobalVariables.TargetVisualSizeClass.VSmall:
				num = (float)((double)maxRange * 0.18);
				break;
			case GlobalVariables.TargetVisualSizeClass.Small:
				num = (float)((double)maxRange * 0.4);
				break;
			case GlobalVariables.TargetVisualSizeClass.Medium:
				num = (float)((double)maxRange * 0.62);
				break;
			case GlobalVariables.TargetVisualSizeClass.Large:
				num = (float)((double)maxRange * 0.8);
				break;
			case GlobalVariables.TargetVisualSizeClass.VLarge:
				num = maxRange;
				break;
			}
			if (float_0 <= num)
			{
				if (Capabilities.SpaceSearch_ABM && activeUnit_1.IsWeapon && ((Weapon)activeUnit_1).IsReEntryVehicle)
				{
					float float_ = (int)Math.Round(activeUnit_1.GetCurrentAltitude());
					if (Horizon.OrderInvocation(activeUnit_0, ref float_, this) <= Math2.VerifyClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude()))
					{
						return SensorDetectionCheckResult.Fail_NoLOS_Horizon;
					}
					return SensorDetectionCheckResult.Success;
				}
				if (!nullable_0.HasValue)
				{
					nullable_0 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
				}
				if (nullable_0.Value == Module_Unit.Unit.LOSCheckResult.Success)
				{
					return SensorDetectionCheckResult.Success;
				}
				switch (nullable_0.Value)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_Other:
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
					return SensorDetectionCheckResult.Fail_NoLOS_Horizon;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
					return SensorDetectionCheckResult.Fail_NoLOS_Cloud;
				}
			}
			return SensorDetectionCheckResult.Fail_OutOfRange;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100737", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return SensorDetectionCheckResult.Undefined;
		}
	}

	private SensorDetectionCheckResult WriteOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, ref Module_Unit.Unit.LOSCheckResult? nullable_0)
	{
		try
		{
			if (nullable_0.HasValue)
			{
				int? num = (int?)nullable_0;
				if ((num.HasValue ? new bool?(num.GetValueOrDefault() != 1) : null).GetValueOrDefault())
				{
					switch (nullable_0.Value)
					{
					case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
						return SensorDetectionCheckResult.Fail_NoLOS_Cloud;
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						return SensorDetectionCheckResult.Fail_Other;
					case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
						return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
					}
				}
			}
			float float_ = maxRange;
			RateWriter(activeUnit_0, activeUnit_1, ref float_);
			if (float_0 <= float_)
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
				}
				if (nullable_0.Value == Module_Unit.Unit.LOSCheckResult.Success)
				{
					return SensorDetectionCheckResult.Success;
				}
				switch (nullable_0.Value)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_Other:
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
					return SensorDetectionCheckResult.Fail_NoLOS_Horizon;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
					return SensorDetectionCheckResult.Fail_NoLOS_Cloud;
				}
			}
			return SensorDetectionCheckResult.Fail_OutOfRange;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100738", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return SensorDetectionCheckResult.Fail_Other;
		}
	}

	private SensorDetectionCheckResult NewOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, ref Module_Unit.Unit.LOSCheckResult? nullable_0)
	{
		try
		{
			if (nullable_0.HasValue && nullable_0.Value != Module_Unit.Unit.LOSCheckResult.Success)
			{
				switch (nullable_0.Value)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_Other:
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
					return SensorDetectionCheckResult.Fail_NoLOS_Horizon;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
					return SensorDetectionCheckResult.Fail_NoLOS_Cloud;
				}
			}
			if (float_0 <= maxRange)
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = Module_Unit.Has_Visual_LOS_ToUnit(activeUnit_0, this, activeUnit_1, ref activeUnit_0.ParentScen, bool_0: true);
				}
				if (nullable_0.Value == Module_Unit.Unit.LOSCheckResult.Success)
				{
					return SensorDetectionCheckResult.Success;
				}
				switch (nullable_0.Value)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_Other:
					return SensorDetectionCheckResult.Fail_Other;
				case Module_Unit.Unit.LOSCheckResult.Fail_OutOfHorizon:
					return SensorDetectionCheckResult.Fail_NoLOS_Horizon;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByTerrain:
					return SensorDetectionCheckResult.Fail_NoLOS_Terrain;
				case Module_Unit.Unit.LOSCheckResult.Fail_BlockedByCloud:
					return SensorDetectionCheckResult.Fail_NoLOS_Cloud;
				}
			}
			return SensorDetectionCheckResult.Fail_OutOfRange;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100739", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return SensorDetectionCheckResult.Undefined;
		}
	}

	public SensorDetectionCheckResult CanIlluminateTarget(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, List<ActiveUnit> list_0, bool bool_0, bool bool_1, ref bool? nullable_0, ref bool? nullable_1, ref Module_Unit.Unit.LOSCheckResult? nullable_2, ref bool? nullable_3)
	{
		if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0)._FacadeReader)
		{
			return SensorDetectionCheckResult.Success;
		}
		if (activeUnit_1.IsDestroyed)
		{
			return SensorDetectionCheckResult.Fail_Other;
		}
		try
		{
			if (!((bool_0 && float_0 > 5f) || bool_1) && !TargetIsWithinIlluminateCoverageArc(activeUnit_1))
			{
				return SensorDetectionCheckResult.Fail_OutsideCoverageArc;
			}
			if (maxRange < float_0)
			{
				return SensorDetectionCheckResult.Fail_OutOfRange;
			}
			if (GetIsSuitableForThisTarget(activeUnit_1))
			{
				Sensor_Type type = Type;
				if (1 == 0)
				{
				}
				SensorDetectionCheckResult result = type switch
				{
					Sensor_Type.LaserDesignator => WriteOrder(activeUnit_0, activeUnit_1, float_0, ref nullable_2), 
					Sensor_Type.Radar => LoginOrder(activeUnit_0, activeUnit_1, float_0, list_0, bool_0, bool_1, ref nullable_0, ref nullable_1), 
					Sensor_Type.Visual => GetOrder(activeUnit_0, activeUnit_1, float_0, bool_0, bool_1, ref nullable_2), 
					Sensor_Type.Infrared => NewOrder(activeUnit_0, activeUnit_1, float_0, ref nullable_2), 
					_ => SensorDetectionCheckResult.Undefined, 
				};
				if (1 == 0)
				{
				}
				return result;
			}
			return SensorDetectionCheckResult.Fail_NotSuitableForThisTarget;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100740", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return SensorDetectionCheckResult.Undefined;
		}
	}

	public bool TargetIsWithinIlluminateCoverageArc(Module_Unit.Unit unit_0, float? nullable_0 = null)
	{
		try
		{
			if (Information.IsNothing(unit_0))
			{
				return false;
			}
			ActiveUnit parentPlatform = base.ParentPlatform;
			float num = Math2.PublishClass(parentPlatform.GetLatitude(), parentPlatform.GetLongitude(), unit_0.GetLatitude(), unit_0.GetLongitude());
			float num2 = (Information.IsNothing(nullable_0) ? parentPlatform.CurrentHeading : nullable_0.Value);
			float num3 = Math2.UpdateClass(num - num2);
			num2 = 0f;
			float num4 = num3;
			if (num4 <= 22.5f)
			{
				return Coverage_Illuminate.SB1;
			}
			if (num4 <= 45f)
			{
				return Coverage_Illuminate.SB2;
			}
			if (num4 <= 67.5f)
			{
				return Coverage_Illuminate.SMF1;
			}
			if (num4 <= 90f)
			{
				return Coverage_Illuminate.SMF2;
			}
			if (num4 <= 112.5f)
			{
				return Coverage_Illuminate.SMA1;
			}
			if (num4 <= 135f)
			{
				return Coverage_Illuminate.SMA2;
			}
			if (num4 <= 157.5f)
			{
				return Coverage_Illuminate.SS1;
			}
			if (num4 <= 180f)
			{
				return Coverage_Illuminate.SS2;
			}
			if (num4 <= 202.5f)
			{
				return Coverage_Illuminate.PS1;
			}
			if (num4 <= 225f)
			{
				return Coverage_Illuminate.PS2;
			}
			if (num4 <= 247.5f)
			{
				return Coverage_Illuminate.PMA1;
			}
			if (num4 <= 270f)
			{
				return Coverage_Illuminate.PMA2;
			}
			if (num4 <= 292.5f)
			{
				return Coverage_Illuminate.PMF1;
			}
			if (num4 <= 315f)
			{
				return Coverage_Illuminate.PMF2;
			}
			if (num4 <= 337.5f)
			{
				return Coverage_Illuminate.PB1;
			}
			return Coverage_Illuminate.PB2;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100741", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool PushOrder(CommDevice commDevice_0)
	{
		return UsedFrequencies.Intersect(commDevice_0.UsedFrequencies).Any();
	}

	private bool InvokeOrder(Sensor sensor_0)
	{
		int dBID;
		int dBID2;
		if (DBID <= sensor_0.DBID)
		{
			dBID = DBID;
			dBID2 = sensor_0.DBID;
		}
		else
		{
			dBID2 = DBID;
			dBID = sensor_0.DBID;
		}
		ConcurrentDictionary<int, bool> concurrentDictionary;
		if (base.ParentPlatform.ParentScen.Cache_SensorCompatibleFrequencies.ContainsKey(dBID2))
		{
			concurrentDictionary = base.ParentPlatform.ParentScen.Cache_SensorCompatibleFrequencies[dBID2];
		}
		else
		{
			concurrentDictionary = new ConcurrentDictionary<int, bool>();
			base.ParentPlatform.ParentScen.Cache_SensorCompatibleFrequencies.TryAdd(dBID2, concurrentDictionary);
		}
		if (concurrentDictionary.ContainsKey(dBID))
		{
			return concurrentDictionary[dBID];
		}
		GlobalSingleton instance = GlobalSingleton.GetInstance();
		HashSet<FrequencyBand> usedFrequencies = sensor_0.UsedFrequencies;
		bool flag = false;
		foreach (FrequencyBand usedFrequency in UsedFrequencies)
		{
			foreach (FrequencyBand item in usedFrequencies)
			{
				if (usedFrequency == item)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			foreach (FrequencyBand usedFrequency2 in sensor_0.UsedFrequencies)
			{
				if (!instance.NormalizedNatoFrequencyBand.ContainsKey(usedFrequency2))
				{
					continue;
				}
				foreach (FrequencyBand usedFrequency3 in UsedFrequencies)
				{
					if (instance.NormalizedNatoFrequencyBand[usedFrequency2].NonNatoFrequencies.ContainsKey(usedFrequency3))
					{
						return true;
					}
				}
			}
		}
		concurrentDictionary.TryAdd(dBID, flag);
		return flag;
	}

	private bool SetupOrder(Sensor sensor_0, float float_0, ActiveEmissionMode activeEmissionMode_0, Weather.WeatherProfile weatherProfile_0, bool bool_0 = false)
	{
		try
		{
			if (_BridgeFacade == null)
			{
				_BridgeFacade = new RadarModel.TRadar();
			}
			m_Receiver = default(RadarModel.TReceiver);
			_BridgeFacade.Altitude = (int)Math.Round(sensor_0.ParentPlatform.GetCurrentAltitude());
			_BridgeFacade.ElevationAngle = 0.0 - RadarModel.StartStub(float_0, sensor_0.ParentPlatform.GetCurrentAltitude(), base.ParentPlatform.GetCurrentAltitude(), ref weatherProfile_0);
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Illuminate:
				_BridgeFacade.SetGainFromBeamwidth(sensor_0.m_RadarHorBeamwidth_Illuminate, sensor_0.m_RadarVerBeamwidth_Illuminate);
				_BridgeFacade.PowerOutputW = sensor_0.m_PowerOutputW_Illuminate;
				_BridgeFacade.PulseWidth = sensor_0.m_PulseWidth_Illuminate;
				_BridgeFacade.ProcessingGain = sensor_0.m_ProcessingGain_Illuminate;
				_BridgeFacade.SystemNoiseLevel = sensor_0.m_SystemNoiseLevel_Illuminate;
				_BridgeFacade.Frequency = (double)(sensor_0.UpperFreqIlluminate + sensor_0.LowerFreqIlluminate) / 2.0;
				_BridgeFacade.PRF = sensor_0.m_PRF_Illuminate;
				break;
			case ActiveEmissionMode.Search_Track:
				_BridgeFacade.SetGainFromBeamwidth(sensor_0.m_RadarHorBeamwidth, sensor_0.m_RadarVerBeamwidth);
				_BridgeFacade.PowerOutputW = sensor_0.m_PowerOutputW_SearchOrTrack;
				_BridgeFacade.PulseWidth = sensor_0.m_PulseWidth_SearchOrTrack;
				_BridgeFacade.ProcessingGain = sensor_0.m_ProcessingGain_SearchOrTrack;
				_BridgeFacade.SystemNoiseLevel = sensor_0.m_SystemNoiseLevel_SearchOrTrack;
				_BridgeFacade.Frequency = (double)(sensor_0.UpperFreq + sensor_0.LowerFreq) / 2.0;
				_BridgeFacade.PRF = sensor_0.m_PRF_SearchOrTrack;
				break;
			}
			if (sensor_0.Codes.AESA)
			{
				_BridgeFacade.PowerOutputW *= 0.025;
			}
			m_Receiver.Altitude = (int)Math.Round(base.ParentPlatform.GetCurrentAltitude());
			m_Receiver.Sensitivity = m_Sensitivity;
			m_Receiver.SystemLoss = m_SystemLoss;
			RadarModel.TRadar bridgeFacade = _BridgeFacade;
			RadarModel.TReceiver treceiver_ = m_Receiver;
			double double_ = float_0;
			Weather.WeatherProfile object_ = weatherProfile_0;
			RadarModel.IDoubleMatrix idoubleMatrix_ = null;
			return RadarModel.RestartStub(bridgeFacade, treceiver_, double_, 0.0, object_, ref idoubleMatrix_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100742", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public double GetLandCoverRCSModifier(LandCover.LandCoverType landCoverType_0)
	{
		double result = 1.0;
		switch (landCoverType_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case LandCover.LandCoverType.Urban_CloseInnerCity:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_SpacedHighRise:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_AttachedHouses:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_CloseIndustrial:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_SpacedApartments:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_DetachedHouses:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_SpacedIndustrial:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Urban_ShantyTown:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
		case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
		case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
		case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
		case LandCover.LandCoverType.Mixed_forest:
			result = 0.06;
			break;
		case LandCover.LandCoverType.Closed_shrublands:
		case LandCover.LandCoverType.Open_shrublands:
			result = 0.32;
			break;
		case LandCover.LandCoverType.Woody_savannas:
		case LandCover.LandCoverType.Savannas:
			result = 0.66;
			break;
		case LandCover.LandCoverType.UrbanAndBuiltUp:
			result = 0.004;
			break;
		case LandCover.LandCoverType.Croplands:
		case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
			result = 0.5;
			break;
		case LandCover.LandCoverType.Water:
		case LandCover.LandCoverType.Grasslands:
		case LandCover.LandCoverType.Permanent_wetlands:
		case LandCover.LandCoverType.SnowAndIce:
		case LandCover.LandCoverType.BarrenOrSparselyVegetated:
			break;
		}
		return result;
	}

	private bool ExcludeOrder(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, float float_0, float float_1, ActiveEmissionMode activeEmissionMode_0, List<ActiveUnit> list_0, Weather.WeatherProfile weatherProfile_0, bool bool_0 = false)
	{
		try
		{
			if (_BridgeFacade == null)
			{
				_BridgeFacade = new RadarModel.TRadar();
			}
			RadarModel.TTarget tTarget = new RadarModel.TTarget();
			double num = RadarModel.StartStub(Module_Unit.RangeToUnit_Horiz(base.ParentPlatform, activeUnit_1), base.ParentPlatform.GetCurrentAltitude() + (float)base.ParentPlatform.GetMastHeight_Radar(this), activeUnit_1.GetCurrentAltitude(), ref weatherProfile_0);
			_BridgeFacade.Altitude = Module_Unit.Unit.DetermineAltitude_SensorObserver_Radar(activeUnit_0, this);
			_BridgeFacade.ElevationAngle = 0.0 - num;
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Illuminate:
				_BridgeFacade.SetGainFromBeamwidth(m_RadarHorBeamwidth_Illuminate, m_RadarVerBeamwidth_Illuminate);
				_BridgeFacade.PowerOutputW = m_PowerOutputW_Illuminate;
				_BridgeFacade.PulseWidth = m_PulseWidth_Illuminate;
				_BridgeFacade.ProcessingGain = m_ProcessingGain_Illuminate;
				_BridgeFacade.SystemNoiseLevel = m_SystemNoiseLevel_Illuminate;
				_BridgeFacade.Frequency = (double)(UpperFreqIlluminate + LowerFreqIlluminate) * 0.5;
				_BridgeFacade.PRF = m_PRF_Illuminate;
				break;
			case ActiveEmissionMode.Search_Track:
				_BridgeFacade.SetGainFromBeamwidth(m_RadarHorBeamwidth, m_RadarVerBeamwidth);
				_BridgeFacade.PowerOutputW = m_PowerOutputW_SearchOrTrack;
				_BridgeFacade.PulseWidth = m_PulseWidth_SearchOrTrack;
				_BridgeFacade.ProcessingGain = m_ProcessingGain_SearchOrTrack;
				_BridgeFacade.SystemNoiseLevel = m_SystemNoiseLevel_SearchOrTrack;
				_BridgeFacade.Frequency = (double)(UpperFreq + LowerFreq) * 0.5;
				_BridgeFacade.PRF = m_PRF_SearchOrTrack;
				break;
			}
			if (!activeUnit_1.IsShip && !activeUnit_1.IsFacility && !activeUnit_1.IsSubmarine)
			{
				tTarget.Altitude = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_1);
			}
			else
			{
				tTarget.Height = Module_Unit.Unit.DetermineAltitude_SensorTarget_Radar(activeUnit_1);
				tTarget.ObjectType = RadarModel.TTargetType.tgt_SurfaceShip;
				if (Codes.PeriscopeSearch_Basic)
				{
					_BridgeFacade.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.Basic;
				}
				else if (Codes.PeriscopeAndSurfaceSearch_FineRangeResolution)
				{
					_BridgeFacade.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.FineRangeResolution;
				}
				else if (Codes.PeriscopeAndSurfaceSearch_AdvancedProcessing)
				{
					_BridgeFacade.SurfaceAndPeriscopeSearchCapability = RadarModel.TSurfaceAndPeriscopeSearchCapability.AdvancedProcessing;
				}
			}
			tTarget.RCS = float_0;
			if ((activeUnit_1.IsAircraft || activeUnit_1.IsMissile) && (Codes.Doppler_LDSD_Full || Codes.Doppler_LDSD_Limited) && !Codes.AESA && !Codes.PESA && !Codes.FrequencyAgile && Math.Abs(Math2.RevertClass(base.ParentPlatform.IsAircraft ? base.ParentPlatform.CurrentHeading : Module_Unit.BearingToUnit_True(base.ParentPlatform, activeUnit_1), activeUnit_1.CurrentHeading, Module_Unit.CalcTokenizer(activeUnit_1))) < 60.0)
			{
				if (activeUnit_1.IsMissile)
				{
					tTarget.RCS_m2 *= 0.06;
				}
				else if (activeUnit_1.IsAircraft)
				{
					GlobalVariables.ProficiencyLevel? proficiency = ((Aircraft)activeUnit_1).Proficiency;
					int? num5 = (int?)proficiency;
					if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						tTarget.RCS_m2 *= 0.66;
					}
					else
					{
						num5 = (int?)proficiency;
						if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							tTarget.RCS_m2 *= 0.32;
						}
						else
						{
							num5 = (int?)proficiency;
							if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								tTarget.RCS_m2 *= 0.06;
							}
							else
							{
								num5 = (int?)proficiency;
								if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 3) : null).GetValueOrDefault())
								{
									tTarget.RCS_m2 *= 0.004;
								}
								else
								{
									num5 = (int?)proficiency;
									if ((num5.HasValue ? new bool?(num5.GetValueOrDefault() == 4) : null).GetValueOrDefault())
									{
										tTarget.RCS_m2 *= 0.001;
									}
								}
							}
						}
					}
				}
			}
			if (!bool_0 && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
			{
				double num6 = 1.0;
				Side natureSide = activeUnit_0.ParentScen.GetNatureSide();
				if ((activeUnit_1.IsFacility || activeUnit_1.IsMobileGroundUnit || activeUnit_1.IsAircraft) && base.ParentPlatform.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation && Terrain.GetElevation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen) > 0)
				{
					(LandCover.LandCoverType, int) tuple = LandCover.AddClass(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.ParentScen, (List<CustomEnvironmentZone>)(object)natureSide);
					if (!activeUnit_1.IsAircraft || activeUnit_1.CurrentAltitude_AGL < (float)tuple.Item2)
					{
						num6 = GetLandCoverRCSModifier(tuple.Item1);
						tTarget.RCS_m2 *= num6;
					}
				}
				if (activeUnit_0 != null)
				{
					float num7 = activeUnit_0.GetCurrentAltitude() + (float)activeUnit_0.GetMastHeight_Radar(this);
					if ((activeUnit_0.IsFacility || activeUnit_0.IsMobileGroundUnit || activeUnit_0.IsAircraft) && activeUnit_0.GetCurrentAltitude() < (float)Terrain.GlobalMaxTerrainElevation)
					{
						int elevation = Terrain.GetElevation(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen);
						if (elevation > 0)
						{
							(LandCover.LandCoverType, int) tuple2 = LandCover.AddClass(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), activeUnit_0.ParentScen, (List<CustomEnvironmentZone>)(object)natureSide);
							if (num7 - (float)elevation < (float)tuple2.Item2)
							{
								num6 = GetLandCoverRCSModifier(tuple2.Item1);
								tTarget.RCS_m2 *= num6;
							}
						}
					}
				}
			}
			if (list_0 == null)
			{
				list_0 = base.ParentPlatform.Sensory.GetJammerUnitsAffectingMe(bool_0: false);
			}
			if (SensorList.IsValueCreated)
			{
				SensorList.Value.Clear();
			}
			else
			{
				SensorList.Value = new List<Sensor>();
			}
			foreach (ActiveUnit item in list_0)
			{
				Sensor[] sensors_Cached = item.Sensors_Cached;
				Sensor[] array6 = sensors_Cached;
				foreach (Sensor sensor in array6)
				{
					if (sensor.IsOECM && sensor.GetCanJamThisSensor(this))
					{
						SensorList.Value.Add(sensor);
					}
				}
			}
			float float_2 = Math2.PublishClass(base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetLongitude(), activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude());
			int count = SensorList.Value.Count;
			RadarModel.TJammer[] array = new RadarModel.TJammer[count - 1 + 1];
			double[] array2 = new double[count - 1 + 1];
			double[] array3 = new double[count - 1 + 1];
			int num8 = count - 1;
			for (int i = 0; i <= num8; i++)
			{
				Sensor sensor2 = SensorList.Value[i];
				RadarModel.TJammer tJammer = new RadarModel.TJammer();
				tJammer.Bandwidth = sensor2.configurationFacade;
				tJammer.Altitude = sensor2.ParentPlatform.GetCurrentAltitude();
				tJammer.Frequency = _BridgeFacade.Frequency;
				tJammer.AntennaGain = sensor2._ProccesorFacade;
				tJammer.PowerOutputW = sensor2.m_StrategyFacade;
				if (Codes.AESA)
				{
					tJammer.PowerOutputW *= 0.1;
				}
				else if (Codes.PESA)
				{
					tJammer.PowerOutputW *= 0.5;
				}
				else if (Codes.FrequencyAgile)
				{
					tJammer.PowerOutputW *= 0.75;
				}
				int num9 = TechGeneration - sensor2.TechGeneration;
				if (num9 < -3)
				{
					tJammer.PowerOutputW *= 20.0;
				}
				else if (num9 == -3)
				{
					tJammer.PowerOutputW *= 10.0;
				}
				else if (num9 == -2)
				{
					tJammer.PowerOutputW *= 5.0;
				}
				else if (num9 == -1)
				{
					tJammer.PowerOutputW *= 2.0;
				}
				else if (num9 != 0)
				{
					if (num9 == 1)
					{
						tJammer.PowerOutputW *= 0.5;
					}
					else if (num9 == 2)
					{
						tJammer.PowerOutputW *= 0.2;
					}
					else if (num9 == 3)
					{
						tJammer.PowerOutputW *= 0.1;
					}
					else if (num9 > 3)
					{
						tJammer.PowerOutputW *= 0.05;
					}
				}
				array[i] = tJammer;
				float num10 = Module_Unit.RangeToUnit_Slant(base.ParentPlatform, sensor2.ParentPlatform);
				array2[i] = num10;
				float num11 = MathFunctions.DeleteRequest(float_2, Math2.PublishClass(base.ParentPlatform.GetLatitude(), base.ParentPlatform.GetLongitude(), sensor2.ParentPlatform.GetLatitude(), sensor2.ParentPlatform.GetLongitude()));
				array3[i] = num11;
			}
			if (!Codes.AESA)
			{
				bool flag = false;
				double num12 = 1.0;
				foreach (ChaffCorridorCloud chaffCloud in base.ParentPlatform.ParentScen.ChaffClouds)
				{
					if (!Capabilities.AltitudeInfo || (activeUnit_1.GetCurrentAltitude() <= (float)chaffCloud.CurtainCeiling && activeUnit_1.GetCurrentAltitude() >= (float)chaffCloud.CurtainFloor))
					{
						Geopoint_Struct[] rectangularArea = Math2.GetRectangularArea(chaffCloud.GetLatitude(), chaffCloud.GetLongitude(), chaffCloud.CoverageLength, chaffCloud.CoverageWidth, chaffCloud.CurrentHeading);
						if (activeUnit_1.GetIsInsideThisArea(rectangularArea, base.ParentPlatform.ParentScen, bool_0: false))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					RadioElectronicFrequency[] array4 = null;
					switch (activeEmissionMode_0)
					{
					case ActiveEmissionMode.Illuminate:
						array4 = IlluminationFreqs;
						break;
					case ActiveEmissionMode.Search_Track:
						array4 = SearchFreqs;
						break;
					}
					RadioElectronicFrequency[] array5 = array4;
					for (int j = 0; j < array5.Length; j = checked(j + 1))
					{
						FrequencyBand frequencyBand = array5[j].Band - 1001;
						if ((ulong)frequencyBand <= 11uL && (ulong)frequencyBand <= 11uL)
						{
							FrequencyBand frequencyBand2 = frequencyBand;
							FrequencyBand frequencyBand3 = frequencyBand2;
							if ((ulong)frequencyBand3 <= 11uL)
							{
								switch (frequencyBand3)
								{
								case (FrequencyBand)0L:
								case (FrequencyBand)1L:
								case (FrequencyBand)2L:
									num12 = Math.Min(0.05, num12);
									continue;
								case (FrequencyBand)3L:
								case (FrequencyBand)4L:
								case (FrequencyBand)5L:
									num12 = Math.Min(0.1, num12);
									continue;
								case (FrequencyBand)6L:
								case (FrequencyBand)7L:
								case (FrequencyBand)8L:
									num12 = Math.Min(0.15, num12);
									continue;
								case (FrequencyBand)9L:
								case (FrequencyBand)10L:
								case (FrequencyBand)11L:
									num12 = Math.Min(0.2, num12);
									continue;
								}
							}
						}
						num12 = Math.Min(0.25, num12);
					}
					GlobalVariables.TechGenerationClass techGeneration = TechGeneration;
					if (techGeneration < GlobalVariables.TechGenerationClass.Late1950s)
					{
						num12 *= 0.1;
					}
					else if (techGeneration == GlobalVariables.TechGenerationClass.Early1960s)
					{
						num12 *= 0.15;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.Late1960s)
					{
						num12 *= 0.2;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.Early1970s)
					{
						num12 *= 0.3;
					}
					else if (techGeneration < GlobalVariables.TechGenerationClass.Early1980s)
					{
						num12 *= 0.4;
					}
					else
					{
						switch (techGeneration)
						{
						default:
							switch (techGeneration)
							{
							case GlobalVariables.TechGenerationClass.Late1990s:
								num12 *= 0.9;
								break;
							case GlobalVariables.TechGenerationClass.Early1990s:
								num12 *= 0.8;
								break;
							}
							break;
						case GlobalVariables.TechGenerationClass.Early1980s:
							num12 *= 0.5;
							break;
						case GlobalVariables.TechGenerationClass.Late1980s:
							num12 *= 0.6;
							break;
						case GlobalVariables.TechGenerationClass.Early1990s:
							num12 *= 0.7;
							break;
						}
					}
					num12 = Math.Min(1.0, num12);
					tTarget.RCS_m2 *= num12;
				}
			}
			RadarModel.TSurfaceType tsurfaceType_ = RadarModel.TSurfaceType.st_Urban;
			float num2 = 0f;
			RadarModel.RadarClutterType radarClutterType = RadarModel.RadarClutterType.None;
			if (_BridgeFacade.ElevationAngle <= 0.0)
			{
				if ((Codes.AESA && activeEmissionMode_0 == ActiveEmissionMode.Illuminate) || base.ParentPlatform.Sensory.ManageDic(activeUnit_1))
				{
					radarClutterType = RadarModel.RadarClutterType.None;
				}
				else
				{
					if (activeUnit_1.IsShip || activeUnit_1.IsSubmarine || (activeUnit_1.IsAircraft && !Module_Unit.ResetTokenizer(activeUnit_1)))
					{
						Terrain.IncludeWatcher(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), 2f);
						tsurfaceType_ = RadarModel.TSurfaceType.st_Mountains;
					}
					num2 = Terrain.InvokeWatcher(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen);
					if (Terrain.GetElevation(activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), bool_0: false, base.ParentPlatform.ParentScen) <= 0)
					{
						tsurfaceType_ = RadarModel.TSurfaceType.st_Wetland;
					}
					else
					{
						float num3 = num2;
						tsurfaceType_ = ((num3 < 0.1f) ? RadarModel.TSurfaceType.st_Wetland : ((num3 < 0.2f) ? RadarModel.TSurfaceType.st_Forest : ((num3 < 0.3f) ? RadarModel.TSurfaceType.st_Shrubland : ((!(num3 < 0.4f)) ? RadarModel.TSurfaceType.st_Mountains : RadarModel.TSurfaceType.st_Cropland))));
					}
				}
			}
			else
			{
				radarClutterType = RadarModel.RadarClutterType.None;
			}
			RadarModel.TRadar bridgeFacade = _BridgeFacade;
			double double_ = float_1;
			Weather.WeatherProfile object_ = weatherProfile_0;
			RadarModel.RadarClutterType radarClutterType_ = radarClutterType;
			GlobalVariables.TechGenerationClass techGeneration2 = TechGeneration;
			RadarModel.TRadar tradar_ = null;
			bool flag2;
			if (flag2 = RadarModel.InsertStub(bridgeFacade, tTarget, count, array, double_, array2, array3, object_, radarClutterType_, techGeneration2, 0.0, 0.0, ref tradar_, 0.0, tsurfaceType_, num2))
			{
				if (!bool_0 && m_ComparatorFacade && activeUnit_0.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced) && !activeUnit_0.IsSatellite && !activeUnit_1.IsSatellite)
				{
					double num4 = 1.0;
					Side natureSide2 = activeUnit_0.ParentScen.GetNatureSide();
					if (activeUnit_0 != null)
					{
						float float_3 = activeUnit_0.GetCurrentAltitude() + (float)activeUnit_0.GetMastHeight_Radar(this);
						foreach (Tuple<LandCover.LandCoverType, int> allLandCoverAndCoverElevationBetweenPoint in LandCover.GetAllLandCoverAndCoverElevationBetweenPoints(activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), float_3, activeUnit_1.GetLatitude(), activeUnit_1.GetLongitude(), activeUnit_1.GetCurrentAltitude(), activeUnit_0.ParentScen, natureSide2))
						{
							num4 = GetLandCoverRCSModifier(allLandCoverAndCoverElevationBetweenPoint.Item1);
							tTarget.RCS_m2 *= num4;
							RadarModel.TRadar bridgeFacade2 = _BridgeFacade;
							double double_2 = float_1;
							Weather.WeatherProfile object_2 = weatherProfile_0;
							RadarModel.RadarClutterType radarClutterType_2 = radarClutterType;
							GlobalVariables.TechGenerationClass techGeneration3 = TechGeneration;
							tradar_ = null;
							if (!(flag2 = RadarModel.InsertStub(bridgeFacade2, tTarget, count, array, double_2, array2, array3, object_2, radarClutterType_2, techGeneration3, 0.0, 0.0, ref tradar_, 0.0, tsurfaceType_, num2)))
							{
								return flag2;
							}
						}
					}
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100743", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private bool IncludeOrder(Module_Unit.Unit unit_0, float float_0, float float_1, ActiveEmissionMode activeEmissionMode_0)
	{
		try
		{
			RadarModel.TTarget tTarget = new RadarModel.TTarget();
			RadarModel.TRadar tradar_ = new RadarModel.TRadar();
			new Weather.WeatherProfile();
			tradar_.Altitude = (int)Math.Round(base.ParentPlatform.GetCurrentAltitude());
			switch (activeEmissionMode_0)
			{
			case ActiveEmissionMode.Illuminate:
				tradar_.SetGainFromBeamwidth(m_RadarHorBeamwidth_Illuminate, m_RadarVerBeamwidth_Illuminate);
				tradar_.PowerOutputW = m_PowerOutputW_Illuminate;
				tradar_.PulseWidth = m_PulseWidth_Illuminate;
				tradar_.ProcessingGain = m_ProcessingGain_Illuminate;
				tradar_.SystemNoiseLevel = m_SystemNoiseLevel_Illuminate;
				tradar_.Frequency = (double)(UpperFreqIlluminate + LowerFreqIlluminate) / 2.0;
				tradar_.PRF = m_PRF_Illuminate;
				break;
			case ActiveEmissionMode.Search_Track:
				tradar_.SetGainFromBeamwidth(m_RadarHorBeamwidth, m_RadarVerBeamwidth);
				tradar_.PowerOutputW = m_PowerOutputW_SearchOrTrack;
				tradar_.PulseWidth = m_PulseWidth_SearchOrTrack;
				tradar_.ProcessingGain = m_ProcessingGain_SearchOrTrack;
				tradar_.SystemNoiseLevel = m_SystemNoiseLevel_SearchOrTrack;
				tradar_.Frequency = (double)(UpperFreq + LowerFreq) / 2.0;
				tradar_.PRF = m_PRF_SearchOrTrack;
				break;
			}
			tradar_.ElevationAngle = 0.0;
			tTarget.Altitude = (int)Math.Round(unit_0.GetCurrentAltitude());
			tTarget.RCS = float_0;
			return RadarModel.ViewWriter(ref tradar_, tTarget.RCS_m2, float_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100744", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public static Sensor GetEyeball(SQLiteConnection sqliteConnection_0)
	{
		try
		{
			Sensor sensor = new Sensor(ref sqliteConnection_0, 0, "Mk1 视线", Sensor_Type.Visual, Sensor_Role.AirSurfaceSearch_3D_SR, GlobalVariables.TechGenerationClass.NotApplicable, 50f, 0f, 180, 180, 10, 0, 0f, 0f, 0f, 0f, 0, 0f, 0f, 0f, bool_0: true, 0, 0, 0, 0, 0f, 0L, 0L, 0L, 0L, 0f, 0f, 0f, 0f, 0f, 0f, 0, 0);
			sensor.IsMk1Eyeball = true;
			sensor.Capabilities.AirSearch = true;
			sensor.Capabilities.SurfaceSearch = true;
			sensor.Capabilities.LandSearch_Mobile = true;
			sensor.Capabilities.LandSearch_Fixed = true;
			sensor.Capabilities.PeriscopeSearch = true;
			sensor.Capabilities.AltitudeInfo = true;
			sensor.Capabilities.HeadingInfo = true;
			sensor.Capabilities.RangeInfo = true;
			sensor.Codes.ContinousTrackingCapable_Visual = true;
			sensor.Codes.IFF_Capable = true;
			sensor.Codes.Classification = true;
			sensor.SearchFreqs = new RadioElectronicFrequency[1];
			Sensor obj = sensor;
			obj.SearchFreqs[0] = new RadioElectronicFrequency(FrequencyBand.Visual_Light);
			obj.ScanInterval = 1;
			obj.AngleResolution = 0f;
			obj.RangeResolution_Nominal = 0f;
			obj.schemaFacade = 1f;
			obj._UtilsFacade = 1f;
			return obj;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100745", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Sensor result = new Sensor();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal bool SearchOrder()
	{
		if (IsMk1Eyeball)
		{
			return true;
		}
		if (Type == Sensor_Type.Visual)
		{
			switch (Role)
			{
			default:
				return false;
			case Sensor_Role.Visual_Binoculars:
			case Sensor_Role.Visual_Optical_Sight:
			case Sensor_Role.Visual_Bomb_Sight:
			case Sensor_Role.Visual_Surveillance_Periscope:
			case Sensor_Role.Visual_Fire_Control_Periscope:
			case Sensor_Role.LLTV_NightVisionGoggles_NVG:
				return true;
			}
		}
		return false;
	}

	public override void vmethod_0(float float_0)
	{
		if (SearchOrder() || Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		float num = ((float_0 < 0.1f) ? 0.05f : ((float_0 < 0.25f) ? 0.15f : ((float_0 < 0.5f) ? 0.3f : ((float_0 < 0.75f) ? 0.5f : 0.75f))));
		GlobalVariables.TechGenerationClass techGeneration = TechGeneration;
		num = ((techGeneration < GlobalVariables.TechGenerationClass.Early1960s) ? ((float)((double)num - 0.3)) : ((techGeneration < GlobalVariables.TechGenerationClass.Early1980s) ? ((float)((double)num + 0.1)) : ((techGeneration < GlobalVariables.TechGenerationClass.Late1980s) ? ((float)((double)num + 0.3)) : ((techGeneration < GlobalVariables.TechGenerationClass.Late1980s) ? ((float)((double)num + 0.4)) : ((float)((double)num + 0.5))))));
		if (!IsOperating)
		{
			num /= 3f;
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
			Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer((Facility)base.ParentPlatform));
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 损失了一个传感器", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
		}
		else if (num6 < (double)num4)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了严重的毁伤。", base.ParentPlatform.Name + " 有一个传感器受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < (double)num3)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了中度毁伤。", base.ParentPlatform.Name + " 有一个传感器受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < (double)num2)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "受轻伤。", base.ParentPlatform.Name + " 有一个传感器受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}

	public static int VolumeSearchRange_IR(Sensor sensor_0)
	{
		switch (sensor_0.TechGeneration)
		{
		case GlobalVariables.TechGenerationClass.IR_NonImaging:
			return 5;
		case GlobalVariables.TechGenerationClass.IR_Imaging_Gen1:
			return 10;
		case GlobalVariables.TechGenerationClass.IR_Imaging_Gen2:
			return 15;
		case GlobalVariables.TechGenerationClass.IR_Imaging_Gen3:
			return 20;
		case GlobalVariables.TechGenerationClass.Early1950s:
			return 3;
		case GlobalVariables.TechGenerationClass.Late1950s:
			return 3;
		case GlobalVariables.TechGenerationClass.Early1960s:
			return 4;
		case GlobalVariables.TechGenerationClass.Late1960s:
			return 4;
		case GlobalVariables.TechGenerationClass.Early1970s:
			return 5;
		case GlobalVariables.TechGenerationClass.Late1970s:
			return 5;
		case GlobalVariables.TechGenerationClass.Early1980s:
			return 10;
		case GlobalVariables.TechGenerationClass.Late1980s:
			return 10;
		case GlobalVariables.TechGenerationClass.Early1990s:
			return 20;
		case GlobalVariables.TechGenerationClass.Late1990s:
			return 20;
		case GlobalVariables.TechGenerationClass.Early2000s:
			return 25;
		case GlobalVariables.TechGenerationClass.Late2000s:
			return 25;
		case GlobalVariables.TechGenerationClass.Early2010s:
			return 30;
		case GlobalVariables.TechGenerationClass.Late2010s:
			return 30;
		case GlobalVariables.TechGenerationClass.Early2020s:
			return 35;
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 25;
		case GlobalVariables.TechGenerationClass.IR_Imaging_FPA:
			return 25;
		case GlobalVariables.TechGenerationClass.IR_DualSpectral:
			return 10;
		}
	}

	public static int VolumeSearchRange_Visual(Sensor sensor_0)
	{
		if (!sensor_0.IsMk1Eyeball)
		{
			switch (sensor_0.TechGeneration)
			{
			case GlobalVariables.TechGenerationClass.Visual:
				return 10;
			case GlobalVariables.TechGenerationClass.Early1950s:
				return 6;
			case GlobalVariables.TechGenerationClass.Late1950s:
				return 6;
			case GlobalVariables.TechGenerationClass.Early1960s:
				return 8;
			case GlobalVariables.TechGenerationClass.Late1960s:
				return 8;
			case GlobalVariables.TechGenerationClass.Early1970s:
				return 10;
			case GlobalVariables.TechGenerationClass.Late1970s:
				return 10;
			case GlobalVariables.TechGenerationClass.Early1980s:
				return 20;
			case GlobalVariables.TechGenerationClass.Late1980s:
				return 20;
			case GlobalVariables.TechGenerationClass.Early1990s:
				return 40;
			case GlobalVariables.TechGenerationClass.Late1990s:
				return 40;
			case GlobalVariables.TechGenerationClass.Early2000s:
				return 50;
			case GlobalVariables.TechGenerationClass.Late2000s:
				return 50;
			case GlobalVariables.TechGenerationClass.Early2010s:
				return 60;
			case GlobalVariables.TechGenerationClass.Late2010s:
				return 60;
			case GlobalVariables.TechGenerationClass.Early2020s:
				return 70;
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return 20;
			case GlobalVariables.TechGenerationClass.LLTV_Gen1:
				return 6;
			case GlobalVariables.TechGenerationClass.LLTV_Gen2:
				return 8;
			case GlobalVariables.TechGenerationClass.LLTV_Gen3:
				return 10;
			case GlobalVariables.TechGenerationClass.Visual_Gen1:
				return 12;
			case GlobalVariables.TechGenerationClass.Visual_Gen2:
				return 15;
			case GlobalVariables.TechGenerationClass.Visual_Gen3:
				return 20;
			}
		}
		return 15;
	}

	public void VisualIRZoom(ref float float_0, ref float float_1, ref float float_2, ref float float_3)
	{
		float_0 = schemaFacade;
		float_1 = _UtilsFacade;
		float_2 = m_PredicateFacade;
		float_3 = m_SingletonFacade;
	}

	public override void ResolveDamageFromDazzler(float float_0)
	{
		if ((uint)(Type - 2003) > 1u || Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		double num = ((float_0 < 0.1f) ? 0.05 : ((float_0 < 0.25f) ? 0.15 : ((float_0 < 0.5f) ? 0.3 : ((float_0 < 0.75f) ? 0.5 : 0.75))));
		if (!IsOperating)
		{
			num = (float)(num / 3.0);
		}
		if (IsMk1Eyeball)
		{
			num += 0.2;
		}
		if (num < 0.05)
		{
			num = 0.05;
		}
		if (num > 0.95)
		{
			num = 0.95;
		}
		double num2 = num;
		double num3 = (float)(num - 0.1);
		double num4 = (float)(num - 0.2);
		double num5 = (float)(num - 0.3);
		double num6 = GameGeneral.LockRandom_0.NextDouble();
		if (num6 < num5)
		{
			Destroy(base.ParentPlatform.GetUnitSide(), bool_0: false, Module_ActiveUnit.CancelTokenizer((Facility)base.ParentPlatform));
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "已被摧毁！", base.ParentPlatform.Name + " 损失了一个传感器", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
		}
		else if (num6 < num4)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了严重的毁伤。", base.ParentPlatform.Name + " 有一个传感器受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < num3)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "遭受了中度毁伤。", base.ParentPlatform.Name + " 有一个传感器受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < num2)
		{
			if (!base.ParentPlatform.IsWeapon)
			{
				base.ParentPlatform.ParentScen.AddMessage(Misc.ReadRequest(base.ParentPlatform.Name) + "损坏报告：" + Misc.ReadRequest(Name) + "受轻伤。", base.ParentPlatform.Name + " 有一个传感器受损", LoggedMessage.MessageType.UnitDamage, 5, base.ParentPlatform.ObjectID, base.ParentPlatform.GetUnitSide(), new Geopoint_Struct(base.ParentPlatform.GetLongitude(), base.ParentPlatform.GetLatitude()));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}
}
