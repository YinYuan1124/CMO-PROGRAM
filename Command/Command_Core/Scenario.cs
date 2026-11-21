using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using CSMaterial;
using Command_Core.DAL;
using Command_Core.LoadSave;
using Command_Core.Lua;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using OpenDis.Pages;
using ThreadSafeCollections;

namespace Command_Core;

[Serializable]
public sealed class Scenario
{
	public delegate void TitleChangedEventHandler(Scenario theScen, string NewTitle);

	public delegate void CurrentScenarioChangedEventHandler(Scenario theNewScen);

	public delegate void CurrentSideChangedEventHandler(Scenario theScen);

	public delegate void SidesChangedEventHandler(Scenario theScen, SideAdditionOrRemoval AddOrRemove);

	public delegate void TimeCompressionChangedEventHandler();

	public delegate void TimeChangedManuallyEventHandler(Scenario theScen, DateTime NewTime);

	public delegate void NewMessageEventHandler(LoggedMessage theM);

	public delegate void UnitAddedEventHandler(Scenario theScen, string theUnitObjectID);

	public delegate void UnitRemovedEventHandler(Scenario theScen, ActiveUnit theUnit);

	public delegate void EventTriggersChangedEventHandler(Scenario theScen);

	public delegate void EventConditionsChangedEventHandler(Scenario theScen);

	public delegate void EventActionsChangedEventHandler(Scenario theScen);

	public delegate void ScenAttachmentsChangedEventHandler();

	public delegate void ScenCompletedEventHandler(Scenario theScen);

	public delegate void UnitSideChangedEventHandler(Scenario theSCen, string theUnitObjectID, string theOldSideID);

	public sealed class Cache_LOS_CheckEntry
	{
		public bool HasLOS;

		public string SrcUnitObjectID;

		public string DestUnitObjectID;

		public double SrcUnitLatitude;

		public double SrcUnitLongitude;

		public float SrcUnitAltitude;

		public double DestUnitLatitude;

		public double DestUnitLongitude;

		public float DestUnitAltitude;

		public float TimeToLive;

		public Cache_LOS_CheckEntry(string string_0, double double_0, double double_1, float float_0, string string_1, double double_2, double double_3, float float_1, bool bool_0)
		{
			TimeToLive = 5f;
			HasLOS = bool_0;
			SrcUnitObjectID = string_0;
			DestUnitObjectID = string_1;
			SrcUnitLatitude = double_0;
			SrcUnitLongitude = double_1;
			SrcUnitAltitude = float_0;
			DestUnitLatitude = double_2;
			DestUnitLongitude = double_3;
			DestUnitAltitude = float_1;
		}
	}

	public enum enumTimeCompression : byte
	{
		OneSec,
		TwoSec,
		FiveSec,
		FifteenSec,
		Coarse_OneSecSlice,
		Coarse_FiveSecSlice
	}

	public enum ScenarioFeatureOption
	{
		None = 0,
		DetailedGunFireControl = 1,
		UnlimitedBaseMagazines = 2,
		AircraftDamage = 3,
		CommsJamming = 5,
		CommsDisruption = 6,
		EMP_Omni = 7,
		HEL_Phase2 = 9,
		RailgunsAndHVPs = 10,
		RealisticSubComms = 12,
		LandTypeEffects = 13,
		FixedSideColors = 14,
		WeatherAffectsShipSpeed = 15,
		AllowLandingPlannerInstantLoading = 16,
		LandTypeEffects_Advanced = 17,
		ACS_NAW_Limitations = 18
	}

	public enum SideAdditionOrRemoval : byte
	{
		Addition,
		Removal
	}

	public enum WeatherModellingLevel : byte
	{
		Level0,
		Level1
	}

	public struct _FeatureCompatibility
	{
		private bool? _ItemItem;

		private bool? m_SetterItem;

		private bool? m_CreatorItem;

		private bool? m_TemplateItem;

		private bool? _MappingItem;

		private bool? mockItem;

		private bool? m_TagItem;

		private bool? _FieldItem;

		public bool CockpitVisibility { get; set; }

		[SpecialName]
		public bool GetHypotheticals(SQLiteConnection sqliteConnection_0)
		{
			if (!_ItemItem.HasValue)
			{
				_ItemItem = DBFunctions.CheckFeatureCompatibility(0, sqliteConnection_0);
			}
			return _ItemItem.Value;
		}

		[SpecialName]
		public bool GetCarrierCapableFlag(SQLiteConnection sqliteConnection_0)
		{
			if (!m_SetterItem.HasValue)
			{
				m_SetterItem = DBFunctions.CheckFeatureCompatibility(1, sqliteConnection_0);
			}
			return m_SetterItem.Value;
		}

		[SpecialName]
		public bool GetWRA(SQLiteConnection sqliteConnection_0)
		{
			if (!m_CreatorItem.HasValue)
			{
				m_CreatorItem = DBFunctions.CheckFeatureCompatibility(2, sqliteConnection_0);
			}
			return m_CreatorItem.Value;
		}

		[SpecialName]
		public bool GetLPI_Radars(SQLiteConnection sqliteConnection_0)
		{
			if (!m_TemplateItem.HasValue)
			{
				m_TemplateItem = DBFunctions.CheckFeatureCompatibility(3, sqliteConnection_0);
			}
			return m_TemplateItem.Value;
		}

		[SpecialName]
		public bool GetWeaponSnapUpDown(SQLiteConnection sqliteConnection_0)
		{
			if (!_MappingItem.HasValue)
			{
				_MappingItem = DBFunctions.CheckFeatureCompatibility(4, sqliteConnection_0);
			}
			return _MappingItem.Value;
		}

		[SpecialName]
		public bool GetWeaponAGL_ASL(SQLiteConnection sqliteConnection_0)
		{
			if (!mockItem.HasValue)
			{
				mockItem = DBFunctions.CheckFeatureCompatibility(5, sqliteConnection_0);
			}
			return mockItem.Value;
		}

		[SpecialName]
		public bool GetRevisedSubOptics(SQLiteConnection sqliteConnection_0)
		{
			if (!m_TagItem.HasValue)
			{
				m_TagItem = DBFunctions.CheckFeatureCompatibility(7, sqliteConnection_0);
			}
			return m_TagItem.Value;
		}

		[SpecialName]
		public bool GetGuidedWeaponsPitchAttitude(SQLiteConnection sqliteConnection_0)
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RegItem
	{
		public Action<double> Local_PercentageComplete;

		public ConcurrentDictionary<string, ScenarioObject> Local_ObjectsDictionary;

		public Scenario Local_theScen;

		public int Local_ItemsInstantiated;

		public int Local_TotalItems;

		public List<XmlNode> Local_theList;

		public ActiveUnit[] Local_theArray;

		public List<XmlNode> Local_theList_Groups;

		public ActiveUnit[] Local_theArray_Groups;

		internal void SetInterruptibleReg(int i)
		{
			XmlNode xmlNode_ = Local_theList[i];
			ActiveUnit activeUnit = ActiveUnit.FromXML(ref xmlNode_, ref Local_ObjectsDictionary, ref Local_theScen);
			if (activeUnit != null && activeUnit.DBID != 0)
			{
				Local_theArray[i] = activeUnit;
				Local_ItemsInstantiated++;
				Local_PercentageComplete((double)Local_ItemsInstantiated / (double)Local_TotalItems);
			}
		}

		internal void FillInterruptibleReg(int i)
		{
			XmlNode xmlNode_ = Local_theList_Groups[i];
			Group group = Group.FromXML(ref xmlNode_, ref Local_ObjectsDictionary, ref Local_theScen);
			Local_theArray_Groups[i] = group;
			Local_ItemsInstantiated++;
			Local_PercentageComplete((double)Local_ItemsInstantiated / (double)Local_TotalItems);
		}
	}

	[CompilerGenerated]
	private sealed class ParamExpressionDic
	{
		public Side Local_theNewM_Side;

		public DateTime Local_theNewM_TimeStamp;

		public string Local_theNewM_Text;

		public bool Local_AlreadyHaveMessage;

		internal void CalculateInterruptibleReg(LoggedMessage theLM, ParallelLoopState loopstate)
		{
			if (theLM != null && theLM.Side != null && theLM.Side == Local_theNewM_Side && DateTime.Compare(theLM.Timestamp, Local_theNewM_TimeStamp) == 0 && string.CompareOrdinal(theLM.Text, Local_theNewM_Text) == 0)
			{
				Local_AlreadyHaveMessage = true;
				loopstate.Stop();
			}
		}
	}

	[CompilerGenerated]
	private sealed class TemplateInstanceFilter
	{
		public Side Local_ASide;

		public bool Local_AlreadyHaveMessage2;

		public ParamExpressionDic CS_0024_003C_003E8__locals1;

		internal void PopInterruptibleReg(LoggedMessage theLM, ParallelLoopState loopstate)
		{
			if (theLM != null && theLM.Side != null && theLM.Side == Local_ASide && DateTime.Compare(theLM.Timestamp, CS_0024_003C_003E8__locals1.Local_theNewM_TimeStamp) == 0 && string.CompareOrdinal(theLM.Text, CS_0024_003C_003E8__locals1.Local_theNewM_Text) == 0)
			{
				Local_AlreadyHaveMessage2 = true;
				loopstate.Stop();
			}
		}
	}

	[CompilerGenerated]
	private sealed class TemplateThreadBridge
	{
		public Side Local_theSide;

		internal bool InstantiateInterruptibleReg(Side side_0)
		{
			return Operators.CompareString(side_0.ObjectID, Local_theSide.ObjectID, TextCompare: false) == 0;
		}

		internal bool CreateInterruptibleReg(Side side_0)
		{
			return Operators.CompareString(side_0.ObjectID, Local_theSide.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class InvocationListenerMapping
	{
		public KeyValuePair<Side, Misc.PostureStance> Local_theKVP;

		internal bool CompareInterruptibleReg(KeyValuePair<Side, Misc.PostureStance> keyValuePair_0)
		{
			return Operators.CompareString(keyValuePair_0.Key.ObjectID, Local_theKVP.Key.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ParamItem
	{
		public ReferencePoint Local_SourceRP;

		internal bool ReadInterruptibleReg(ReferencePoint TargetRP)
		{
			return Operators.CompareString(TargetRP.ObjectID, Local_SourceRP.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class PageItem
	{
		public ExclusionZone Local_SourceEZ;

		internal bool DisableInterruptibleReg(ExclusionZone TargetEZ)
		{
			return Operators.CompareString(TargetEZ.ObjectID, Local_SourceEZ.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ThreadConfigManager
	{
		public NoNavZone Local_SourceNNZ;

		internal bool UpdateInterruptibleReg(NoNavZone noNavZone_0)
		{
			return Operators.CompareString(noNavZone_0.ObjectID, Local_SourceNNZ.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class MockCallbackCandidate
	{
		public Mission Local_SourceMission;

		internal bool InsertInterruptibleReg(Mission TargetMission)
		{
			return Operators.CompareString(TargetMission.ObjectID, Local_SourceMission.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class GlobalCollectionRecord
	{
		public WeaponSalvo Local_SourceSalvo;

		internal bool PrepareInterruptibleReg(WeaponSalvo TargetSalvo)
		{
			return Operators.CompareString(TargetSalvo.ObjectID, Local_SourceSalvo.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class RulesItem
	{
		public Explosion Local_theExplosion;

		internal bool ReflectInterruptibleReg(Explosion Scen1Explosion)
		{
			return Operators.CompareString(Scen1Explosion.ObjectID, Local_theExplosion.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class AdvisorDecoratorEntry
	{
		public WeaponImpact Local_theWI;

		internal bool VisitInterruptibleReg(WeaponImpact weaponImpact_0)
		{
			return Operators.CompareString(weaponImpact_0.ObjectID, Local_theWI.ObjectID, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class AuthenticationProcessResolver
	{
		public ChaffCorridorCloud Local_theCloud;

		internal bool RestartInterruptibleReg(ChaffCorridorCloud chaffCorridorCloud_0)
		{
			return Operators.CompareString(chaffCorridorCloud_0.ObjectID, Local_theCloud.ObjectID, TextCompare: false) == 0;
		}
	}

	public string TimelineID;

	public string ParentTimelineID;

	public int MonteCarloIteration;

	private string _ObjectID;

	public string ContentTag;

	public string CampaignID;

	public string CampaignSessionID;

	public int CampaignScore;

	public bool RunningHeadless;

	private string _Title;

	private string _Description;

	private string _Description_Encrypted;

	public short Meta_Complexity;

	public short Meta_Difficulty;

	public string Meta_ScenSetting;

	public string FileName;

	public string FileNamePath;

	private DateTime _Time;

	public DateTime? TimeToHalt;

	public DateTime ZeroHour;

	private bool _DaylightSavingTime;

	private string _DaylightSavingTime_Start;

	private string _DaylightSavingTime_End;

	private DateTime? _StartTime;

	private TimeSpan? _Duration;

	private bool _HasEnded;

	[AccessedThroughProperty("ActiveUnits")]
	[CompilerGenerated]
	private ObservableDictionary<string, ActiveUnit> ActiveUnits_value;

	public object ActiveUnitsSyncLock;

	private List<ActiveUnit> Cache_ActiveUnits_List;

	public List<Group> Groups;

	private List<Weapon> _GuidedWeapons;

	private List<Weapon> _MobileDecoysActive;

	private List<Weapon> _SonobuoysInWater;

	private List<Weapon> _AllWeaponsAlive;

	private enumTimeCompression _TimeCompression;

	private float _GameResolution;

	private Side[] _Sides;

	private List<ActiveUnit> _UnitAdditions;

	private List<ActiveUnit> _UnitRemovals;

	private List<UnguidedWeapon> list_0;

	private List<ActiveUnit> _UnitDeletions;

	public int UnitsAutoIncrement;

	private Side _CurrentSide;

	public string GameVersion;

	public bool ExecutionInProgress;

	public bool SerializationInProgress;

	public float Navigation_FinegrainedThresholdDistance;

	public float Navigation_FinegrainedMaxDistance;

	public bool UserIsPlottingCourse;

	public int DefaultGuidedWeaponsVsAirTargetWRASetting;

	[CompilerGenerated]
	[AccessedThroughProperty("ScenAttachments")]
	private ObservableDictionary<string, ScenAttachmentObject> ScenAttachments_value;

	public Queue<LoggedMessage> UnhandledPopUpMessages;

	public List<LoggedMessage> MessageLog;

	private ConcurrentQueue<LoggedMessage> _MessageLogQueue;

	private long _MessageIncrement;

	private string _DBUsed;

	private bool? Cache_IsDBUsedCWDB;

	private SQLiteConnection _DBConnection;

	public bool LoadStockUnits;

	private List<ActiveUnit> _OperativeUnits;

	private List<ActiveUnit> _NonoperativeUnits;

	internal HashSet<XmlNode> UnitsForLateInstantiation;

	public bool SecondIsChangingOnThisPulse;

	public bool FifthSecondIsChangingOnThisPulse;

	public bool FifteenthSecondIsChangingOnThisPulse;

	public bool ThirtiethSecondIsChangingOnThisPulse;

	public bool MinuteIsChangingOnThisPulse;

	public bool FifthMinuteIsChangingOnThisPulse;

	public bool FifteenthMinuteIsChangingOnThisPulse;

	public bool ThirtiethMinuteIsChangingOnThisPulse;

	public bool HourIsChangingOnThisPulse;

	public bool SixHourIsChangingOnThisPulse;

	public bool TwelveHourIsChangingOnThisPulse;

	public bool TwentyFourHourIsChangingOnThisPulse;

	internal List<ActiveUnit> Cache_FacilitiesWithPiers;

	public ConcurrentDictionary<int, Weapon> Cache_Weapons;

	public ConcurrentDictionary<int, Sensor> Cache_Sensors;

	internal ConcurrentDictionary<int, ConcurrentDictionary<int, bool>> Cache_SensorCompatibleFrequencies;

	internal ConcurrentDictionary<string, XSection[]> Cache_XSections;

	internal ConcurrentDictionary<int, int> Cache_FuelForPitchEnabledWeapons;

	internal ConcurrentDictionary<int, (int BurnTime, int FlightEndurance)> Cache_BurnTimesForBoostCoastWeapons;

	public Weather.TTimeOfDayType?[][] Cache_TimeOfDay;

	internal ConcurrentDictionary<int, Sensor> Cache_AssociatedSensors;

	internal ConcurrentDictionary<int, AltBand[]> Cache_PowerplantAltBands;

	internal TDictionary<string, List<Platform>> Cache_PrimaryTargetForWhichPlatforms;

	public HashSet<int> Cache_DisabledLoadouts;

	internal ConcurrentDictionary<ulong, int?> Cache_WRA_WeaponQty_SystemDefault;

	internal ConcurrentDictionary<ulong, Doctrine.WRA_FiringDoctrineEntry> Cache_WRA_FiringDoctrineEntry_SystemDefault;

	internal List<ActiveUnit> CandidatesForDetectionByMines;

	public List<string> LoadingNotices;

	internal bool ThreadedOpsMustStop;

	public HashSet<ScenarioFeatureOption> DeclaredFeatures;

	public bool LastSavedInScenEdit;

	public _FeatureCompatibility FeatureCompatibility;

	public int? MaxRisingMineRange_meters;

	private LuaSandBox _LuaSandbox;

	public bool UIRefreshTrigger;

	public bool CurrentlyInsertingMessages;

	internal EventWaitHandle EventWaitHandle_FinishPulse;

	public WeatherModellingLevel WeatherLevel;

	private Weather.WeatherProfile _GlobalWeather;

	public List<MDSP_Error> MissionPlannerErrorList;

	[AccessedThroughProperty("EventTriggers")]
	[CompilerGenerated]
	private ObservableDictionary<string, EventTrigger> EventTriggers_value;

	[AccessedThroughProperty("EventConditions")]
	[CompilerGenerated]
	private ObservableDictionary<string, EventCondition> EventConditions_value;

	[AccessedThroughProperty("EventActions")]
	[CompilerGenerated]
	private ObservableDictionary<string, EventAction> EventActions_value;

	[AccessedThroughProperty("SimEvents")]
	[CompilerGenerated]
	private ObservableDictionary<string, SimEvent> SimEvents_value;

	[AccessedThroughProperty("Explosions")]
	[CompilerGenerated]
	private ObservableList<Explosion> Explosions_value;

	[CompilerGenerated]
	[AccessedThroughProperty("WeaponImpacts")]
	private ObservableList<WeaponImpact> WeaponImpacts_value;

	[CompilerGenerated]
	[AccessedThroughProperty("WaterSplashes")]
	private List<WaterSplash> WaterSplashes_value;

	[CompilerGenerated]
	[AccessedThroughProperty("GroundImpacts")]
	private List<GroundImpact> GroundImpacts_value;

	[AccessedThroughProperty("UnguidedWeapons")]
	[CompilerGenerated]
	private ObservableDictionary<string, UnguidedWeapon> UnguidedWeapons_value;

	public List<UnguidedWeapon> Mines;

	public ObservableDictionary<string, UnguidedWeapon> MineAllocation;

	public List<ChaffCorridorCloud> ChaffClouds;

	public ConcurrentHashSet<Side> UnitAutodetectionValidation;

	[CompilerGenerated]
	private static TimeChangedManuallyEventHandler _OnTimeChangedManuallyEvent;

	[CompilerGenerated]
	private static NewMessageEventHandler _OnNewMessageEvent;

	[CompilerGenerated]
	private static ScenAttachmentsChangedEventHandler _ScenAttachmentsChangedEvent;

	[CompilerGenerated]
	private static UnitSideChangedEventHandler _UnitSideChangedEvent;

	public string LuaXml;

	public string LuaXmlPassed;

	public static List<Tuple<string, CargoTracker>> CargoMovement;

	public bool AnyActiveWeaponEffectThreats;

	private object _ActiveUnits_ListLockObj;

	private object UnUsedObj;

	private Game _GameContext;

	public bool DEBUG_DiscriminateResolutionAndCompression;

	public float? DEBUG_CustomResolution;

	public enumTimeCompression? DEBUG_CustomCompression;

	public bool HasBeenReleased;

	public static ConcurrentDictionary<(float, double, float), (float, double)> NEZ_DLZ_Cache;

	public bool _LockFidelityResolution;

	private object _AddUnitLockObj;

	private object _AddRemoveUnitsLockObj;

	[CompilerGenerated]
	private object object_0;

	private object _GetGuidedWeaponsLockObj;

	private object _Locker_ActiveUnits_DictionaryChanged;

	internal List<string> WeaponFeedBackMessage;

	public ObservableDictionary<string, ActiveUnit> ActiveUnits
	{
		[CompilerGenerated]
		get
		{
			return ActiveUnits_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, ActiveUnit>.DictionaryChangedEventHandler val = ActiveUnits_DictionaryChanged;
			ObservableDictionary<string, ActiveUnit> activeUnits_value = ActiveUnits_value;
			if (activeUnits_value != null)
			{
				activeUnits_value.DictionaryChanged -= val;
			}
			ActiveUnits_value = value;
			activeUnits_value = ActiveUnits_value;
			if (activeUnits_value != null)
			{
				activeUnits_value.DictionaryChanged += val;
			}
		}
	}

	public ObservableDictionary<string, ScenAttachmentObject> ScenAttachments
	{
		[CompilerGenerated]
		get
		{
			return ScenAttachments_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, ScenAttachmentObject>.DictionaryChangedEventHandler val = ScenAttachments_DictionaryChanged;
			ObservableDictionary<string, ScenAttachmentObject> scenAttachments_value = ScenAttachments_value;
			if (scenAttachments_value != null)
			{
				scenAttachments_value.DictionaryChanged -= val;
			}
			ScenAttachments_value = value;
			scenAttachments_value = ScenAttachments_value;
			if (scenAttachments_value != null)
			{
				scenAttachments_value.DictionaryChanged += val;
			}
		}
	}

	public DataTable Cache_Aircraft_DT => DBFunctions.CurrentDatabaseCache.Cache_Aircraft_DT;

	public DataTable Cache_Ships_DT => DBFunctions.CurrentDatabaseCache.Cache_Ships_DT;

	public DataTable Cache_Subs_DT => DBFunctions.CurrentDatabaseCache.Cache_Subs_DT;

	public DataTable Cache_Facilities_DT => DBFunctions.CurrentDatabaseCache.Cache_Facilities_DT;

	public DataTable Cache_GroundUnits_DT => DBFunctions.CurrentDatabaseCache.Cache_GroundUnits_DT;

	public DataTable Cache_Satellites_DT => DBFunctions.CurrentDatabaseCache.Cache_Satellites_DT;

	public DataTable Cache_Weapons_DT => DBFunctions.CurrentDatabaseCache.Cache_Weapons_DT;

	public DataTable Cache_OperatorCountries_DT => DBFunctions.CurrentDatabaseCache.Cache_OperatorCountries_DT;

	public ConcurrentDictionary<string, HashSet<int>> Cache_AllPossibleEmissionsPerUnit => DBFunctions.CurrentDatabaseCache.Cache_AllPossibleEmissionsPerUnit;

	public ObservableDictionary<string, EventTrigger> EventTriggers
	{
		[CompilerGenerated]
		get
		{
			return EventTriggers_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, EventTrigger>.DictionaryChangedEventHandler val = EventTriggers_DictionaryChanged;
			ObservableDictionary<string, EventTrigger> eventTriggers_value = EventTriggers_value;
			if (eventTriggers_value != null)
			{
				eventTriggers_value.DictionaryChanged -= val;
			}
			EventTriggers_value = value;
			eventTriggers_value = EventTriggers_value;
			if (eventTriggers_value != null)
			{
				eventTriggers_value.DictionaryChanged += val;
			}
		}
	}

	public ObservableDictionary<string, EventCondition> EventConditions
	{
		[CompilerGenerated]
		get
		{
			return EventConditions_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, EventCondition>.DictionaryChangedEventHandler val = EventConditions_DictionaryChanged;
			ObservableDictionary<string, EventCondition> eventConditions_value = EventConditions_value;
			if (eventConditions_value != null)
			{
				eventConditions_value.DictionaryChanged -= val;
			}
			EventConditions_value = value;
			eventConditions_value = EventConditions_value;
			if (eventConditions_value != null)
			{
				eventConditions_value.DictionaryChanged += val;
			}
		}
	}

	public ObservableDictionary<string, EventAction> EventActions
	{
		[CompilerGenerated]
		get
		{
			return EventActions_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, EventAction>.DictionaryChangedEventHandler val = EventActions_DictionaryChanged;
			ObservableDictionary<string, EventAction> eventActions_value = EventActions_value;
			if (eventActions_value != null)
			{
				eventActions_value.DictionaryChanged -= val;
			}
			EventActions_value = value;
			eventActions_value = EventActions_value;
			if (eventActions_value != null)
			{
				eventActions_value.DictionaryChanged += val;
			}
		}
	}

	public ObservableDictionary<string, SimEvent> SimEvents
	{
		[CompilerGenerated]
		get
		{
			return SimEvents_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SimEvents_value = value;
		}
	}

	public ObservableList<Explosion> Explosions
	{
		[CompilerGenerated]
		get
		{
			return Explosions_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Explosion>> value2 = Explosions_ItemsAdded;
			ObservableList<Explosion> explosions_value = Explosions_value;
			if (explosions_value != null)
			{
				explosions_value.ItemsAdded -= value2;
			}
			Explosions_value = value;
			explosions_value = Explosions_value;
			if (explosions_value != null)
			{
				explosions_value.ItemsAdded += value2;
			}
		}
	}

	public ObservableList<WeaponImpact> WeaponImpacts
	{
		[CompilerGenerated]
		get
		{
			return WeaponImpacts_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<WeaponImpact>> value2 = WeaponImpacts_ItemsAdded;
			ObservableList<WeaponImpact> weaponImpacts_value = WeaponImpacts_value;
			if (weaponImpacts_value != null)
			{
				weaponImpacts_value.ItemsAdded -= value2;
			}
			WeaponImpacts_value = value;
			weaponImpacts_value = WeaponImpacts_value;
			if (weaponImpacts_value != null)
			{
				weaponImpacts_value.ItemsAdded += value2;
			}
		}
	}

	public List<WaterSplash> WaterSplashes
	{
		[CompilerGenerated]
		get
		{
			return WaterSplashes_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WaterSplashes_value = value;
		}
	}

	public List<GroundImpact> GroundImpacts
	{
		[CompilerGenerated]
		get
		{
			return GroundImpacts_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GroundImpacts_value = value;
		}
	}

	public ObservableDictionary<string, UnguidedWeapon> UnguidedWeapons
	{
		[CompilerGenerated]
		get
		{
			return UnguidedWeapons_value;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			INotifyDictionaryChanged<string, UnguidedWeapon>.DictionaryChangedEventHandler val = UnguidedWeapons_DictionaryChanged;
			ObservableDictionary<string, UnguidedWeapon> unguidedWeapons_value = UnguidedWeapons_value;
			if (unguidedWeapons_value != null)
			{
				unguidedWeapons_value.DictionaryChanged -= val;
			}
			UnguidedWeapons_value = value;
			unguidedWeapons_value = UnguidedWeapons_value;
			if (unguidedWeapons_value != null)
			{
				unguidedWeapons_value.DictionaryChanged += val;
			}
		}
	}

	public object writing
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = RuntimeHelpers.GetObjectValue(value);
		}
	}

	public bool LockFidelityResolution
	{
		get
		{
			return _LockFidelityResolution;
		}
		set
		{
			TimeCompression_Set(enumTimeCompression.Coarse_OneSecSlice);
			string string_ = "Unchanged state";
			if (LockFidelityResolution && !value)
			{
				string_ = "Locked -> Unlocked";
			}
			else if (!LockFidelityResolution && value)
			{
				string_ = "Unlocked -> Locked";
			}
			AddMessage(string_, "Simulation resolution Lock", LoggedMessage.MessageType.SpecialMessage, 1, "");
			_LockFidelityResolution = value;
		}
	}

	public Game GameContext
	{
		get
		{
			if (_GameContext == null)
			{
				_GameContext = new Game();
			}
			return _GameContext;
		}
		set
		{
			_GameContext = value;
		}
	}

	public string Title
	{
		get
		{
			return _Title;
		}
		set
		{
			_Title = value;
			Scenario.TitleChanged?.Invoke(this, value);
		}
	}

	public string ObjectID
	{
		get
		{
			if (string.IsNullOrEmpty(_ObjectID))
			{
				_ObjectID = Guid.NewGuid().ToString();
			}
			return _ObjectID;
		}
		set
		{
			_ObjectID = value;
		}
	}

	public string Description
	{
		get
		{
			if (string.IsNullOrEmpty(_Description_Encrypted))
			{
				return _Description;
			}
			if (string.IsNullOrEmpty(_Description_Encrypted))
			{
				return string.Empty;
			}
			return Crypto.ListImporter(_Description_Encrypted, "DaltonTrumbo");
		}
		set
		{
			_Description = string.Empty;
			if (string.IsNullOrEmpty(value))
			{
				_Description_Encrypted = value;
			}
			else
			{
				_Description_Encrypted = Crypto.VerifyImporter(value, "DaltonTrumbo");
			}
		}
	}

	public ObservableList<IEventExporter> ApplicableEventExporters => Exporter_General.EventExporters_Interactive;

	public string DBUsed
	{
		get
		{
			return _DBUsed;
		}
		set
		{
			bool num = string.IsNullOrEmpty(_DBUsed) || string.IsNullOrEmpty(value) || Operators.CompareString(value, _DBUsed, TextCompare: false) != 0;
			_DBUsed = value;
			if (num)
			{
				_DBConnection = null;
				GameGeneral.Debug_LastLoadedDB = value;
				if (DBConnection != null)
				{
					DBFunctions.CurrentDatabaseCache.BuildCache(_DBUsed, DBConnection);
				}
			}
		}
	}

	public bool? IsDBUsedCWDB
	{
		get
		{
			try
			{
				if (!Cache_IsDBUsedCWDB.HasValue)
				{
					DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
					DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(DBUsed, ref dbfileCheckResult_, bool_0: false, bool_1: false);
					Cache_IsDBUsedCWDB = dBRecordByHash.DBID == 2;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 854929267518567", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return Cache_IsDBUsedCWDB;
		}
	}

	public LuaSandBox Scenario_LuaSandbox
	{
		get
		{
			if (Information.IsNothing(_LuaSandbox))
			{
				if (LuaSandBox.Singleton() == null)
				{
					_LuaSandbox = new LuaSandBox();
				}
				else
				{
					_LuaSandbox = LuaSandBox.Singleton();
				}
			}
			return _LuaSandbox;
		}
		set
		{
			_LuaSandbox = value;
		}
	}

	public bool IsRunningInCampaignMode
	{
		get
		{
			if (string.IsNullOrEmpty(CampaignID))
			{
				return false;
			}
			return !string.IsNullOrEmpty(CampaignSessionID);
		}
	}

	public List<Weapon> GuidedWeaponsInAir
	{
		get
		{
			try
			{
				if (Information.IsNothing(_GuidedWeapons) || Information.IsNothing(_SonobuoysInWater) || Information.IsNothing(_AllWeaponsAlive))
				{
					object getGuidedWeaponsLockObj = _GetGuidedWeaponsLockObj;
					ObjectFlowControl.CheckForSyncLockOnValueType(getGuidedWeaponsLockObj);
					bool lockTaken = false;
					try
					{
						Monitor.Enter(getGuidedWeaponsLockObj, ref lockTaken);
						if (Information.IsNothing(_GuidedWeapons) || Information.IsNothing(_SonobuoysInWater) || Information.IsNothing(_AllWeaponsAlive))
						{
							List<Weapon> list = new List<Weapon>();
							List<Weapon> list2 = new List<Weapon>();
							List<Weapon> list3 = new List<Weapon>();
							List<Weapon> list4 = new List<Weapon>();
							List<ActiveUnit> activeUnits_List = ActiveUnits_List;
							int count = activeUnits_List.Count;
							ActiveUnit activeUnit = null;
							int num = count - 1;
							for (int i = 0; i <= num; i++)
							{
								try
								{
									activeUnit = activeUnits_List[i];
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									ProjectData.ClearProjectError();
									continue;
								}
								if (activeUnit == null || !activeUnit.IsWeapon)
								{
									continue;
								}
								Weapon weapon = (Weapon)activeUnit;
								list4.Add(weapon);
								if (weapon.IsNuke.Value)
								{
									AnyActiveWeaponEffectThreats = true;
								}
								if (!weapon.IsGuidedWeapon() && !weapon.IsGuidedProjectile && !weapon.IsBallisticMissile && !weapon.IsReEntryVehicle && (weapon.Type != Weapon._WeaponType.Torpedo || weapon.Comms_ReadOnly.Length == 0))
								{
									if (weapon.IsMobileDecoy)
									{
										list2.Add(weapon);
									}
									else if (weapon.Type == Weapon._WeaponType.Sonobuoy)
									{
										list3.Add(weapon);
									}
								}
								else
								{
									list.Add(weapon);
								}
							}
							_GuidedWeapons = list;
							_MobileDecoysActive = list2;
							_SonobuoysInWater = list3;
							_AllWeaponsAlive = list4;
						}
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(getGuidedWeaponsLockObj);
						}
					}
				}
				return _GuidedWeapons;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101026", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Weapon> guidedWeapons = _GuidedWeapons;
				ProjectData.ClearProjectError();
				return guidedWeapons;
			}
		}
		set
		{
			_GuidedWeapons = value;
		}
	}

	public List<Weapon> MobileDecoysActive
	{
		get
		{
			try
			{
				if (Information.IsNothing(_MobileDecoysActive))
				{
					_ = GuidedWeaponsInAir;
				}
				return _MobileDecoysActive;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101274", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Weapon> mobileDecoysActive = _MobileDecoysActive;
				ProjectData.ClearProjectError();
				return mobileDecoysActive;
			}
		}
		set
		{
			_MobileDecoysActive = value;
		}
	}

	public List<Weapon> SonobuoysInWater
	{
		get
		{
			try
			{
				if (Information.IsNothing(_SonobuoysInWater))
				{
					_ = GuidedWeaponsInAir;
				}
				return _SonobuoysInWater;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101274", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Weapon> sonobuoysInWater = _SonobuoysInWater;
				ProjectData.ClearProjectError();
				return sonobuoysInWater;
			}
		}
		set
		{
			_SonobuoysInWater = value;
		}
	}

	public List<Weapon> AllWeaponsAlive
	{
		get
		{
			try
			{
				if (_AllWeaponsAlive == null)
				{
					_ = GuidedWeaponsInAir;
				}
				return _AllWeaponsAlive;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101275", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Weapon> allWeaponsAlive = _AllWeaponsAlive;
				ProjectData.ClearProjectError();
				return allWeaponsAlive;
			}
		}
		set
		{
			_AllWeaponsAlive = value;
		}
	}

	public Weather.WeatherProfile GlobalWeather
	{
		get
		{
			if (Information.IsNothing(_GlobalWeather))
			{
				_GlobalWeather = Weather.DefaultWeather();
			}
			return _GlobalWeather;
		}
		set
		{
			_GlobalWeather = value;
		}
	}

	public bool HasEnded => _HasEnded;

	public bool HasStarted => DateTime.Compare(Time, StartTime) > 0;

	public DateTime StartTime
	{
		get
		{
			if (!_StartTime.HasValue)
			{
				_StartTime = Time;
			}
			return _StartTime.Value;
		}
		set
		{
			_StartTime = value;
		}
	}

	public TimeSpan Duration
	{
		get
		{
			if (!_Duration.HasValue)
			{
				_Duration = new TimeSpan(24, 0, 0);
			}
			return _Duration.Value;
		}
		set
		{
			_Duration = value;
		}
	}

	public DateTime Time => _Time;

	public bool Use_DST
	{
		get
		{
			return _DaylightSavingTime;
		}
		set
		{
			_DaylightSavingTime = value;
		}
	}

	public string DST_Start
	{
		get
		{
			return _DaylightSavingTime_Start;
		}
		set
		{
			_DaylightSavingTime_Start = value;
		}
	}

	public string DST_End
	{
		get
		{
			return _DaylightSavingTime_End;
		}
		set
		{
			_DaylightSavingTime_End = value;
		}
	}

	public SQLiteConnection DBConnection
	{
		get
		{
			if (_DBConnection == null)
			{
				if (string.IsNullOrEmpty(DBUsed))
				{
					_DBConnection = null;
				}
				else
				{
					_DBConnection = new SQLiteConnection(DBOps.smethod_1(MerchantMerchantPage.LogoutList.Info.DirectoryPath, DBUsed));
				}
			}
			return _DBConnection;
		}
	}

	public float GameResolution
	{
		get
		{
			return _GameResolution;
		}
		set
		{
			_GameResolution = value;
		}
	}

	public List<ActiveUnit> ActiveUnits_List
	{
		get
		{
			try
			{
				if (Cache_ActiveUnits_List == null || Cache_ActiveUnits_List.Count != ActiveUnits.Count)
				{
					object activeUnits_ListLockObj = _ActiveUnits_ListLockObj;
					ObjectFlowControl.CheckForSyncLockOnValueType(activeUnits_ListLockObj);
					bool lockTaken = false;
					try
					{
						Monitor.Enter(activeUnits_ListLockObj, ref lockTaken);
						if (Cache_ActiveUnits_List == null || Cache_ActiveUnits_List.Count != ActiveUnits.Count)
						{
							List<ActiveUnit> list = new List<ActiveUnit>();
							lock (ActiveUnits)
							{
								IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator = ActiveUnits.GetEnumerator();
								try
								{
									while (enumerator.MoveNext())
									{
										list.Add(enumerator.Current.Value);
									}
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									ProjectData.ClearProjectError();
								}
							}
							Cache_ActiveUnits_List = list;
						}
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(activeUnits_ListLockObj);
						}
					}
				}
				return Cache_ActiveUnits_List;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200053", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<ActiveUnit> result = ActiveUnits.Values.ToList();
				ProjectData.ClearProjectError();
				return result;
			}
		}
		set
		{
			object activeUnits_ListLockObj = _ActiveUnits_ListLockObj;
			ObjectFlowControl.CheckForSyncLockOnValueType(activeUnits_ListLockObj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(activeUnits_ListLockObj, ref lockTaken);
				Cache_ActiveUnits_List = value;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(activeUnits_ListLockObj);
				}
			}
		}
	}

	public Side[] Sides_ReadOnly => _Sides;

	public List<ActiveUnit> NewbornUnits => _UnitAdditions;

	public List<ActiveUnit> MorituriUnits => _UnitRemovals;

	public List<UnguidedWeapon> MorituriUnguidedWeapons => list_0;

	public List<ActiveUnit> DeletedUnits => _UnitDeletions;

	public int TimeCompression_SimSeconds
	{
		get
		{
			enumTimeCompression timeCompression = _TimeCompression;
			if (1 == 0)
			{
			}
			int result = timeCompression switch
			{
				enumTimeCompression.OneSec => 1, 
				enumTimeCompression.TwoSec => 2, 
				enumTimeCompression.FiveSec => 5, 
				enumTimeCompression.FifteenSec => 15, 
				enumTimeCompression.Coarse_OneSecSlice => 30, 
				enumTimeCompression.Coarse_FiveSecSlice => 150, 
				_ => 1, 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public enumTimeCompression TimeCompression => _TimeCompression;

	public long MessageIncrement => _MessageIncrement;

	public static event TitleChangedEventHandler TitleChanged;

	public static event CurrentScenarioChangedEventHandler CurrentScenarioChanged;

	public static event CurrentSideChangedEventHandler CurrentSideChanged;

	public static event SidesChangedEventHandler SidesChanged;

	public static event TimeCompressionChangedEventHandler TimeCompressionChanged;

	public static event TimeChangedManuallyEventHandler TimeChangedManually
	{
		[CompilerGenerated]
		add
		{
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler = _OnTimeChangedManuallyEvent;
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler2;
			do
			{
				timeChangedManuallyEventHandler2 = timeChangedManuallyEventHandler;
				TimeChangedManuallyEventHandler value2 = (TimeChangedManuallyEventHandler)Delegate.Combine(timeChangedManuallyEventHandler2, value);
				timeChangedManuallyEventHandler = Interlocked.CompareExchange(ref _OnTimeChangedManuallyEvent, value2, timeChangedManuallyEventHandler2);
			}
			while ((object)timeChangedManuallyEventHandler != timeChangedManuallyEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler = _OnTimeChangedManuallyEvent;
			TimeChangedManuallyEventHandler timeChangedManuallyEventHandler2;
			do
			{
				timeChangedManuallyEventHandler2 = timeChangedManuallyEventHandler;
				TimeChangedManuallyEventHandler value2 = (TimeChangedManuallyEventHandler)Delegate.Remove(timeChangedManuallyEventHandler2, value);
				timeChangedManuallyEventHandler = Interlocked.CompareExchange(ref _OnTimeChangedManuallyEvent, value2, timeChangedManuallyEventHandler2);
			}
			while ((object)timeChangedManuallyEventHandler != timeChangedManuallyEventHandler2);
		}
	}

	public static event NewMessageEventHandler NewMessage
	{
		[CompilerGenerated]
		add
		{
			NewMessageEventHandler newMessageEventHandler = _OnNewMessageEvent;
			NewMessageEventHandler newMessageEventHandler2;
			do
			{
				newMessageEventHandler2 = newMessageEventHandler;
				NewMessageEventHandler value2 = (NewMessageEventHandler)Delegate.Combine(newMessageEventHandler2, value);
				newMessageEventHandler = Interlocked.CompareExchange(ref _OnNewMessageEvent, value2, newMessageEventHandler2);
			}
			while ((object)newMessageEventHandler != newMessageEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NewMessageEventHandler newMessageEventHandler = _OnNewMessageEvent;
			NewMessageEventHandler newMessageEventHandler2;
			do
			{
				newMessageEventHandler2 = newMessageEventHandler;
				NewMessageEventHandler value2 = (NewMessageEventHandler)Delegate.Remove(newMessageEventHandler2, value);
				newMessageEventHandler = Interlocked.CompareExchange(ref _OnNewMessageEvent, value2, newMessageEventHandler2);
			}
			while ((object)newMessageEventHandler != newMessageEventHandler2);
		}
	}

	public static event UnitAddedEventHandler UnitAdded;

	public static event UnitRemovedEventHandler UnitRemoved;

	public static event EventTriggersChangedEventHandler EventTriggersChanged;

	public static event EventConditionsChangedEventHandler EventConditionsChanged;

	public static event EventActionsChangedEventHandler EventActionsChanged;

	public static event ScenAttachmentsChangedEventHandler ScenAttachmentsChanged
	{
		[CompilerGenerated]
		add
		{
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler = _ScenAttachmentsChangedEvent;
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler2;
			do
			{
				scenAttachmentsChangedEventHandler2 = scenAttachmentsChangedEventHandler;
				ScenAttachmentsChangedEventHandler value2 = (ScenAttachmentsChangedEventHandler)Delegate.Combine(scenAttachmentsChangedEventHandler2, value);
				scenAttachmentsChangedEventHandler = Interlocked.CompareExchange(ref _ScenAttachmentsChangedEvent, value2, scenAttachmentsChangedEventHandler2);
			}
			while ((object)scenAttachmentsChangedEventHandler != scenAttachmentsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler = _ScenAttachmentsChangedEvent;
			ScenAttachmentsChangedEventHandler scenAttachmentsChangedEventHandler2;
			do
			{
				scenAttachmentsChangedEventHandler2 = scenAttachmentsChangedEventHandler;
				ScenAttachmentsChangedEventHandler value2 = (ScenAttachmentsChangedEventHandler)Delegate.Remove(scenAttachmentsChangedEventHandler2, value);
				scenAttachmentsChangedEventHandler = Interlocked.CompareExchange(ref _ScenAttachmentsChangedEvent, value2, scenAttachmentsChangedEventHandler2);
			}
			while ((object)scenAttachmentsChangedEventHandler != scenAttachmentsChangedEventHandler2);
		}
	}

	public static event ScenCompletedEventHandler ScenCompleted;

	public static event UnitSideChangedEventHandler UnitSideChanged
	{
		[CompilerGenerated]
		add
		{
			UnitSideChangedEventHandler unitSideChangedEventHandler = _UnitSideChangedEvent;
			UnitSideChangedEventHandler unitSideChangedEventHandler2;
			do
			{
				unitSideChangedEventHandler2 = unitSideChangedEventHandler;
				UnitSideChangedEventHandler value2 = (UnitSideChangedEventHandler)Delegate.Combine(unitSideChangedEventHandler2, value);
				unitSideChangedEventHandler = Interlocked.CompareExchange(ref _UnitSideChangedEvent, value2, unitSideChangedEventHandler2);
			}
			while ((object)unitSideChangedEventHandler != unitSideChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitSideChangedEventHandler unitSideChangedEventHandler = _UnitSideChangedEvent;
			UnitSideChangedEventHandler unitSideChangedEventHandler2;
			do
			{
				unitSideChangedEventHandler2 = unitSideChangedEventHandler;
				UnitSideChangedEventHandler value2 = (UnitSideChangedEventHandler)Delegate.Remove(unitSideChangedEventHandler2, value);
				unitSideChangedEventHandler = Interlocked.CompareExchange(ref _UnitSideChangedEvent, value2, unitSideChangedEventHandler2);
			}
			while ((object)unitSideChangedEventHandler != unitSideChangedEventHandler2);
		}
	}

	static Scenario()
	{
		CargoMovement = new List<Tuple<string, CargoTracker>>();
		NEZ_DLZ_Cache = new ConcurrentDictionary<(float, double, float), (float, double)>();
	}

	public void ReleaseReferences()
	{
		try
		{
			ThreadedOpsMustStop = true;
			_LuaSandbox = null;
			_GameContext = null;
			Pathfinding.ClearAllPathfinderRequests();
			_CurrentSide = null;
			foreach (KeyValuePair<string, ActiveUnit> activeUnit in ActiveUnits)
			{
				if (string.IsNullOrEmpty(activeUnit.Key) | (activeUnit.Value == null))
				{
					Debugger.Break();
				}
				else
				{
					activeUnit.Value.ReleaseReferences();
				}
			}
			Side[] sides = _Sides;
			for (int i = 0; i < sides.Length; i = checked(i + 1))
			{
				sides[i].ReleaseReferences();
			}
			Groups.Clear();
			ActiveUnits.Clear();
			Cache_ActiveUnits_List = null;
			_Sides = null;
			ScenAttachments = null;
			UnhandledPopUpMessages = null;
			MessageLog = null;
			_MessageLogQueue = null;
			DBUsed = null;
			_OperativeUnits = null;
			_NonoperativeUnits = null;
			UnitsForLateInstantiation = null;
			Cache_FacilitiesWithPiers = null;
			Cache_Weapons = null;
			Cache_SensorCompatibleFrequencies = null;
			Cache_XSections = null;
			Cache_FuelForPitchEnabledWeapons = null;
			Cache_BurnTimesForBoostCoastWeapons = null;
			Cache_AssociatedSensors = null;
			Cache_PowerplantAltBands = null;
			Cache_PrimaryTargetForWhichPlatforms = null;
			Cache_DisabledLoadouts = null;
			CandidatesForDetectionByMines.Clear();
			EventTriggers = null;
			EventConditions = null;
			EventActions = null;
			SimEvents = null;
			Explosions = null;
			WeaponImpacts = null;
			WaterSplashes = null;
			GroundImpacts = null;
			UnguidedWeapons = null;
			Mines = null;
			MineAllocation = null;
			ChaffClouds = null;
			HasBeenReleased = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	internal bool IsEmpty()
	{
		if (_Sides.Count() <= 0)
		{
			if (_Title == null && _Description == null && _Description_Encrypted == null)
			{
				if (EventTriggers.Count <= 0 && EventActions.Count <= 0 && EventConditions.Count <= 0)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public void CheckForUndeclaredFeatures()
	{
		if (DeclaredFeatures.Contains(ScenarioFeatureOption.CommsDisruption))
		{
			return;
		}
		foreach (ActiveUnit activeUnits_ in ActiveUnits_List)
		{
			if (activeUnits_ != null && !activeUnits_.CommStuff.IsConnectedToSideNetwork)
			{
				DeclaredFeatures.Add(ScenarioFeatureOption.CommsDisruption);
				break;
			}
		}
		foreach (EventAction value in EventActions.Values)
		{
			if (value.Type == EventAction.EventActionType.LuaScript && Misc.CustomizeValue(((EventAction_LuaScript)value).ScriptText, "OUTOFCOMMS", StringComparison.OrdinalIgnoreCase))
			{
				DeclaredFeatures.Add(ScenarioFeatureOption.CommsDisruption);
				break;
			}
		}
	}

	public static void FIX_FlightPlanWeapon_Altitude(Mission mission_0, Mission.Flight flight_0 = null, bool bool_0 = false)
	{
		if (mission_0.MissionClass != Mission._MissionClass.Strike)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<ActiveUnit, ActiveUnit> item in mission_0.UnitsAssignedToMission)
		{
			if (!item.Key.IsAircraft)
			{
				continue;
			}
			Aircraft aircraft = (Aircraft)item.Key;
			if (flight_0 == null)
			{
				if (!aircraft.Navigator.HasFlightPlan)
				{
					continue;
				}
				HashSet<Module_Unit.Unit> specificTargets = ((Strike)mission_0).SpecificTargets;
				if (specificTargets == null || specificTargets.Count <= 0)
				{
					continue;
				}
				Contact contact_;
				if (specificTargets.ElementAtOrDefault(0).IsActiveUnit)
				{
					contact_ = new Contact((ActiveUnit)specificTargets.ElementAtOrDefault(0), 0, bool_0: true);
				}
				else
				{
					if (!specificTargets.ElementAtOrDefault(0).DisableWriter())
					{
						return;
					}
					contact_ = (Contact)specificTargets.ElementAtOrDefault(0);
				}
				Weapon weapon = aircraft.Weaponry.MostSuitableWeaponForThisTarget(contact_, bool_1: false, bool_2: false, bool_3: true, aircraft.Doctrine);
				if (weapon == null)
				{
					continue;
				}
				float minLaunchAlt_AGL = weapon.MinLaunchAlt_AGL;
				float num = weapon.MaxLaunchAlt_AGL;
				AircraftMissionProfile missionProfile = aircraft.Loadout.GetMissionProfile(aircraft.ParentScen);
				bool flag = false;
				int num2 = 0;
				Waypoint[] flightPlan = aircraft.Navigator.GetFlight().FlightPlan;
				Waypoint[] array = flightPlan;
				foreach (Waypoint waypoint in array)
				{
					num2++;
					if (waypoint.Type == Waypoint.WaypointType.WeaponLaunch || waypoint.Type == Waypoint.WaypointType.InitialPoint)
					{
						flag = true;
					}
					float? desiredAltitude = waypoint.DesiredAltitude;
					float? desiredAltitude_TerrainFollowing = waypoint.DesiredAltitude_TerrainFollowing;
					if (waypoint.Type == Waypoint.WaypointType.TurningPoint)
					{
						if (flag)
						{
							waypoint.DesiredAltitude = missionProfile.CruiseAltitudeEgress;
						}
						else
						{
							waypoint.DesiredAltitude = missionProfile.CruiseAltitudeIngress;
						}
					}
					if (waypoint.Type == Waypoint.WaypointType.StrikeIngress)
					{
						if ((aircraft.Navigator.GetFlight().FlightPlan[num2].Type == Waypoint.WaypointType.InitialPoint) | (aircraft.Navigator.GetFlight().FlightPlan[num2].Type == Waypoint.WaypointType.WeaponLaunch))
						{
							waypoint.DesiredAltitude = missionProfile.AttackAltitudeIngress;
						}
						else
						{
							waypoint.DesiredAltitude = missionProfile.CruiseAltitudeIngress;
						}
					}
					if (waypoint.Type == Waypoint.WaypointType.StrikeEgress)
					{
						waypoint.DesiredAltitude = missionProfile.CruiseAltitudeEgress;
					}
					if (!((waypoint.Type == Waypoint.WaypointType.Target) | (waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.InitialPoint) | (waypoint.Type == Waypoint.WaypointType.WeaponTarget)))
					{
						continue;
					}
					if ((waypoint.Type == Waypoint.WaypointType.StrikeIngress || (((waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.InitialPoint)) && num == 0f)) && missionProfile.AttackAltitudeIngress > 0f)
					{
						if (num == 0f)
						{
							num = 2.1474836E+09f;
						}
						if ((num > 0f && missionProfile.AttackAltitudeIngress < num) & (missionProfile.AttackAltitudeIngress > minLaunchAlt_AGL))
						{
							waypoint.DesiredAltitude = missionProfile.AttackAltitudeIngress;
							if (bool_0)
							{
								float? desiredAltitude2 = waypoint.DesiredAltitude;
								if (!((desiredAltitude2.HasValue & desiredAltitude.HasValue) ? new bool?(desiredAltitude2.GetValueOrDefault() != desiredAltitude.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									desiredAltitude2 = desiredAltitude_TerrainFollowing;
									float? desiredAltitude_TerrainFollowing2 = waypoint.DesiredAltitude_TerrainFollowing;
									if (!((desiredAltitude2.HasValue & desiredAltitude_TerrainFollowing2.HasValue) ? new bool?(desiredAltitude2.GetValueOrDefault() != desiredAltitude_TerrainFollowing2.GetValueOrDefault()) : null).GetValueOrDefault())
									{
										goto IL_092a;
									}
								}
								if (!hashSet.Contains(waypoint.Description))
								{
									hashSet.Add(waypoint.Description);
								}
							}
							goto IL_092a;
						}
					}
					if (((waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.InitialPoint)) && num == 0f && missionProfile.CruiseAltitudeIngress > 0f)
					{
						if (num == 0f)
						{
							num = 2.1474836E+09f;
						}
						if ((num > 0f && missionProfile.CruiseAltitudeIngress < num) & (missionProfile.CruiseAltitudeIngress > minLaunchAlt_AGL))
						{
							waypoint.DesiredAltitude = missionProfile.CruiseAltitudeIngress;
							if (bool_0)
							{
								float? desiredAltitude3 = waypoint.DesiredAltitude;
								if (!((desiredAltitude3.HasValue & desiredAltitude.HasValue) ? new bool?(desiredAltitude3.GetValueOrDefault() != desiredAltitude.GetValueOrDefault()) : null).GetValueOrDefault())
								{
									desiredAltitude3 = desiredAltitude_TerrainFollowing;
									float? desiredAltitude_TerrainFollowing3 = waypoint.DesiredAltitude_TerrainFollowing;
									if (!((desiredAltitude3.HasValue & desiredAltitude_TerrainFollowing3.HasValue) ? new bool?(desiredAltitude3.GetValueOrDefault() != desiredAltitude_TerrainFollowing3.GetValueOrDefault()) : null).GetValueOrDefault())
									{
										goto IL_0948;
									}
								}
								if (!hashSet.Contains(waypoint.Description))
								{
									hashSet.Add(waypoint.Description);
								}
							}
						}
						goto IL_0948;
					}
					int num3 = 0;
					if (Terrain.ExcludeWatcher(waypoint.Latitude, waypoint.Longitude).IsOverland)
					{
						num3 = Terrain.GetElevation(waypoint.Latitude, waypoint.Longitude, bool_0: false, aircraft.ParentScen);
					}
					else
					{
						float num4 = 0f;
						foreach (Module_Unit.Unit specificTarget in ((Strike)mission_0).SpecificTargets)
						{
							num3 = Terrain.GetElevation(specificTarget.GetLatitude(), specificTarget.GetLongitude(), bool_0: false, aircraft.ParentScen);
							if (num3 <= 0)
							{
								continue;
							}
							bool? flag2;
							if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
							{
								float? desiredAltitude_TerrainFollowing4 = waypoint.DesiredAltitude_TerrainFollowing;
								float num5 = minLaunchAlt_AGL + (float)num3;
								flag2 = (desiredAltitude_TerrainFollowing4.HasValue ? new bool?(desiredAltitude_TerrainFollowing4.GetValueOrDefault() < num5) : null);
							}
							else
							{
								flag2 = true;
							}
							bool? flag3 = flag2;
							bool? flag4;
							if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
							{
								float? desiredAltitude_TerrainFollowing5 = waypoint.DesiredAltitude_TerrainFollowing;
								float num6 = num - (float)num3;
								flag4 = (desiredAltitude_TerrainFollowing5.HasValue ? new bool?(desiredAltitude_TerrainFollowing5.GetValueOrDefault() > num6) : null);
							}
							else
							{
								flag4 = true;
							}
							bool? flag5 = (num > 0f) & flag4;
							if (!(flag3.GetValueOrDefault() ? new bool?(true) : ((!flag5.HasValue) ? null : (flag5.GetValueOrDefault() | flag3))).GetValueOrDefault())
							{
								continue;
							}
							if (num4 == 0f)
							{
								num4 = (float)num3 + minLaunchAlt_AGL + 10f;
							}
							else if (num4 - (float)num3 < minLaunchAlt_AGL)
							{
								num4 = num4 - minLaunchAlt_AGL - 10f;
								num4 = (float)num3 + (num - minLaunchAlt_AGL) / 2f;
								waypoint.DesiredAltitude = num4;
								if ((waypoint.Type == Waypoint.WaypointType.Target) | (waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.InitialPoint) | (waypoint.Type == Waypoint.WaypointType.WeaponTarget))
								{
									waypoint.ReferenceWeapon_ID = weapon.DBID;
								}
							}
						}
					}
					if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
					{
						float? desiredAltitude_TerrainFollowing6 = waypoint.DesiredAltitude_TerrainFollowing;
						float num7 = minLaunchAlt_AGL + (float)num3;
						if (!(desiredAltitude_TerrainFollowing6.HasValue ? new bool?(desiredAltitude_TerrainFollowing6.GetValueOrDefault() < num7) : null).GetValueOrDefault())
						{
							goto IL_09b0;
						}
					}
					float value = minLaunchAlt_AGL + 10f + (float)num3;
					waypoint.DesiredAltitude_TerrainFollowing = value;
					waypoint.DesiredAltitude = value;
					goto IL_09b0;
					IL_092a:
					if (num == 2.1474836E+09f)
					{
						num = 0f;
					}
					continue;
					IL_0948:
					if (num == 2.1474836E+09f)
					{
						num = 0f;
					}
					continue;
					IL_0966:
					if ((waypoint.Type == Waypoint.WaypointType.Target) | (waypoint.Type == Waypoint.WaypointType.WeaponLaunch) | (waypoint.Type == Waypoint.WaypointType.InitialPoint) | (waypoint.Type == Waypoint.WaypointType.WeaponTarget))
					{
						waypoint.ReferenceWeapon_ID = weapon.DBID;
					}
					continue;
					IL_09b0:
					bool? flag6;
					if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
					{
						float? desiredAltitude_TerrainFollowing7 = waypoint.DesiredAltitude_TerrainFollowing;
						float num8 = num - (float)num3;
						flag6 = (desiredAltitude_TerrainFollowing7.HasValue ? new bool?(desiredAltitude_TerrainFollowing7.GetValueOrDefault() > num8) : null);
					}
					else
					{
						flag6 = true;
					}
					if (((num > 0f) & flag6).GetValueOrDefault())
					{
						float value2 = num - 10f + (float)num3;
						waypoint.DesiredAltitude_TerrainFollowing = value2;
						waypoint.DesiredAltitude = value2;
					}
					if (bool_0)
					{
						float? desiredAltitude4 = waypoint.DesiredAltitude;
						if (!((desiredAltitude4.HasValue & desiredAltitude.HasValue) ? new bool?(desiredAltitude4.GetValueOrDefault() != desiredAltitude.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							desiredAltitude4 = desiredAltitude_TerrainFollowing;
							float? desiredAltitude_TerrainFollowing8 = waypoint.DesiredAltitude_TerrainFollowing;
							if (!((desiredAltitude4.HasValue & desiredAltitude_TerrainFollowing8.HasValue) ? new bool?(desiredAltitude4.GetValueOrDefault() != desiredAltitude_TerrainFollowing8.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								goto IL_0966;
							}
						}
						if (!hashSet.Contains(waypoint.Description))
						{
							hashSet.Add("飞行编队" + aircraft.Navigator.GetFlight().Name + " " + waypoint.Description);
						}
					}
					goto IL_0966;
				}
			}
			else if (aircraft.Navigator.HasFlight)
			{
				Operators.CompareString(aircraft.Navigator.GetFlight().Callsign, flight_0.Callsign, TextCompare: false);
			}
		}
		if (hashSet.Count > 0 && bool_0)
		{
			GameGeneral.ResolveBridge("Waypoint(s) " + string.Join(",", hashSet) + " desired altitude(s) adjusted to follow a valid Flight Plan.", mission_0.UnitsAssignedToMission.Values.FirstOrDefault()?.GetUnitSide(), "Adjusted values", GameGeneral.MessageBoxMessageType.Warning);
		}
	}

	public static bool DetermineLOS(double double_0, double double_1, float float_0, double double_2, double double_3, float float_1, bool bool_0, Scenario scenario_0, int int_0 = 0, bool bool_1 = false)
	{
		try
		{
			float num = 900f;
			float num7 = 9000f;
			float num8 = 0f;
			float num9 = 18900f;
			double double_4 = 0.0;
			double double_5 = 0.0;
			double double_6 = 0.0;
			Geodesic_Vincenty.ApproxSphericalToCartesian(double_0, double_1, float_0 + (float)int_0, ref double_4, ref double_5, ref double_6);
			double double_7 = 0.0;
			double double_8 = 0.0;
			double double_9 = 0.0;
			Geodesic_Vincenty.ApproxSphericalToCartesian(double_2, double_3, float_1, ref double_7, ref double_8, ref double_9);
			double num10 = double_7 - double_4;
			double num11 = double_8 - double_5;
			double num12 = double_9 - double_6;
			double num13 = Math.Sqrt(num10 * num10 + num11 * num11 + num12 * num12);
			if (num13 < 37800.0)
			{
				double num14 = num13;
				while (num14 > (double)num)
				{
					num8 += num;
					if (!((double)num8 <= num13))
					{
						break;
					}
					if (!IsLOS_Exists_BetweenTwoPoints(num8, num13, double_4, double_5, double_6, num10, num11, num12, float_0, float_1, bool_0, bool_1, scenario_0))
					{
						num14 -= (double)num;
						continue;
					}
					return false;
				}
			}
			else
			{
				float num2 = num9;
				float num3 = num9;
				double num4 = num13 - (double)(num9 * 2f);
				float num5 = (float)(num13 - (double)num9);
				while (num2 > num)
				{
					num8 += num;
					if (!(num8 <= num9))
					{
						break;
					}
					if (!IsLOS_Exists_BetweenTwoPoints(num8, num13, double_4, double_5, double_6, num10, num11, num12, float_0, float_1, bool_0, bool_1, scenario_0))
					{
						num2 -= num;
						continue;
					}
					return false;
				}
				if (num4 > (double)(num7 * 2f))
				{
					double num6 = num4;
					num8 = num9;
					while (num6 > (double)num7)
					{
						num8 += num7;
						if (!(num8 <= num5))
						{
							break;
						}
						if (!IsLOS_Exists_BetweenTwoPoints(num8, num13, double_4, double_5, double_6, num10, num11, num12, float_0, float_1, bool_0, bool_1, scenario_0))
						{
							num6 -= (double)num7;
							continue;
						}
						return false;
					}
				}
				num8 = (float)num13 - num9;
				while (num3 > num)
				{
					num8 += num;
					if (!((double)num8 <= num13))
					{
						break;
					}
					if (!IsLOS_Exists_BetweenTwoPoints(num8, num13, double_4, double_5, double_6, num10, num11, num12, float_0, float_1, bool_0, bool_1, scenario_0))
					{
						num3 -= num;
						continue;
					}
					return false;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100872", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	private static bool IsLOS_Exists_BetweenTwoPoints(float float_0, double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, float float_1, float float_2, bool bool_0, bool bool_1, Scenario scenario_0)
	{
		float num = (float)((double)float_0 / double_0);
		if (num <= 1f)
		{
			double double_10 = double_1 + double_4 * (double)num;
			double double_11 = double_2 + double_5 * (double)num;
			double double_12 = double_3 + double_6 * (double)num;
			double double_7 = 0.0;
			double double_8 = 0.0;
			double double_9 = 0.0;
			Geodesic_Vincenty.ApproxCartesianToSpherical(double_10, double_11, double_12, ref double_7, ref double_8, ref double_9);
			if (double_9 <= (double)Terrain.GlobalMaxTerrainElevation)
			{
				short watcher = Terrain.GetWatcher(double_7, double_8);
				if (double_9 <= (double)watcher)
				{
					if (!(double_9 <= (double)float_1) && double_9 > (double)float_2)
					{
						return false;
					}
					int? num2 = null;
					if (double_9 < (double)float_1 && double_9 < (double)float_2)
					{
						num2 = Terrain.GetElevation(double_7, double_8, bool_0: false, scenario_0);
						if (double_9 < (double)num2.Value)
						{
							return true;
						}
					}
					if (!num2.HasValue)
					{
						num2 = Terrain.GetElevation(double_7, double_8, bool_0: false, scenario_0);
					}
					if (bool_0)
					{
						int? num3 = num2;
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() > 0) : null).GetValueOrDefault())
						{
							return true;
						}
					}
					else
					{
						bool? flag;
						if (bool_1)
						{
							int? num4 = num2;
							flag = (num4.HasValue ? new bool?(num4.GetValueOrDefault() <= 0) : null);
						}
						else
						{
							flag = false;
						}
						bool? flag2 = flag;
						if (((!flag2) ?? flag2).GetValueOrDefault())
						{
							double num5 = double_9;
							double? num6 = num2;
							if ((num6.HasValue ? new bool?(num5 <= num6.GetValueOrDefault()) : null).GetValueOrDefault())
							{
								return true;
							}
						}
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public string ToXML_ViaStream(bool bool_0)
	{
		using MemoryStream stream_ = RCMS.recyclableMemoryStreamManager_0.GetStream();
		ToXML(stream_, bool_0);
		return Misc.AssetRequest(stream_);
	}

	public string ToXML_ViaStringBuilder(bool bool_0)
	{
		StringWriter stringWriter = new StringWriter(new StringBuilder());
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
		if (!bool_0)
		{
			xmlTextWriter.Formatting = System.Xml.Formatting.Indented;
			xmlTextWriter.Indentation = 4;
		}
		Save(xmlTextWriter);
		return stringWriter.ToString();
	}

	public void ToXML(Stream stream_0, bool bool_0)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		if (!bool_0)
		{
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "    ";
		}
		XmlWriter xmlWriter_ = XmlWriter.Create(stream_0, xmlWriterSettings);
		Save(xmlWriter_);
	}

	private void Save(XmlWriter xmlWriter_0)
	{
		try
		{
			HashSet<string> hashSet_ = new HashSet<string>();
			using (xmlWriter_0)
			{
				if (string.IsNullOrEmpty(ContentTag))
				{
					xmlWriter_0.WriteStartElement("Scenario");
				}
				else
				{
					xmlWriter_0.WriteStartElement("ContentScenario");
				}
				xmlWriter_0.WriteElementString("TimelineID", TimelineID.ToString());
				xmlWriter_0.WriteElementString("ObjectID", ObjectID.ToString());
				xmlWriter_0.WriteElementString("ContentTag", ContentTag);
				xmlWriter_0.WriteElementString("CampaignID", CampaignID);
				xmlWriter_0.WriteElementString("CampaignSessionID", CampaignSessionID);
				xmlWriter_0.WriteElementString("CampaignScore", CampaignScore.ToString());
				xmlWriter_0.WriteElementString("Title", _Title);
				xmlWriter_0.WriteElementString("Description", _Description);
				xmlWriter_0.WriteElementString("Description_Encrypted", _Description_Encrypted);
				xmlWriter_0.WriteElementString("Meta_Complexity", Conversions.ToString((int)Meta_Complexity));
				xmlWriter_0.WriteElementString("Meta_Difficulty", Conversions.ToString((int)Meta_Difficulty));
				xmlWriter_0.WriteElementString("Meta_ScenSetting", Meta_ScenSetting);
				xmlWriter_0.WriteElementString("FileName", FileName);
				xmlWriter_0.WriteElementString("FileNamePath", FileNamePath);
				xmlWriter_0.WriteElementString("Time", _Time.ToBinary().ToString());
				xmlWriter_0.WriteElementString("ZeroHour", ZeroHour.ToBinary().ToString());
				if (_StartTime.HasValue)
				{
					xmlWriter_0.WriteElementString("StartTime", _StartTime.Value.ToBinary().ToString());
				}
				if (_Duration.HasValue)
				{
					xmlWriter_0.WriteElementString("Duration", _Duration.Value.Ticks.ToString());
				}
				xmlWriter_0.WriteElementString("DaylightSavingTime", _DaylightSavingTime.ToString());
				if (Information.IsNothing(_DaylightSavingTime_Start))
				{
					_DaylightSavingTime_Start = "00.00";
				}
				if (Information.IsNothing(_DaylightSavingTime_End))
				{
					_DaylightSavingTime_End = "00.00";
				}
				xmlWriter_0.WriteElementString("DaylightSavingTime_Start", _DaylightSavingTime_Start.ToString());
				xmlWriter_0.WriteElementString("DaylightSavingTime_End", _DaylightSavingTime_End.ToString());
				xmlWriter_0.WriteStartElement("Sides");
				Side[] sides_ReadOnly = Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side side in array)
				{
					XmlWriter xmlWriter = xmlWriter_0;
					Scenario scenario_ = this;
					xmlWriter.WriteRaw(side.ToXML(ref hashSet_, ref scenario_));
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("NonActiveUnits");
				xmlWriter_0.WriteStartElement("Explosions");
				foreach (Explosion explosion in Explosions)
				{
					explosion.ToXML(ref xmlWriter_0, ref hashSet_);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("WeaponImpacts");
				for (int i = WeaponImpacts.Count - 1; i >= 0; i += -1)
				{
					WeaponImpacts[i].ToXML(ref xmlWriter_0, ref hashSet_);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("UnguidedWeapons");
				foreach (UnguidedWeapon value in UnguidedWeapons.Values)
				{
					xmlWriter_0.WriteRaw(value.ToXML(ref xmlWriter_0, ref hashSet_));
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("ChaffClouds");
				foreach (ChaffCorridorCloud chaffCloud in ChaffClouds)
				{
					chaffCloud.ToXML(ref xmlWriter_0, ref hashSet_);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("ActiveUnits");
				foreach (ActiveUnit activeUnits_ in ActiveUnits_List)
				{
					if (activeUnits_ != null)
					{
						activeUnits_.ToXML(ref xmlWriter_0, ref hashSet_);
						xmlWriter_0.Flush();
					}
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("Groups");
				foreach (Group group in Groups)
				{
					if (group != null)
					{
						xmlWriter_0.WriteElementString("ID", group.ObjectID);
					}
				}
				xmlWriter_0.WriteEndElement();
				XmlWriter xmlWriter2 = xmlWriter_0;
				byte weatherLevel = (byte)WeatherLevel;
				xmlWriter2.WriteElementString("WeatherModel", weatherLevel.ToString());
				xmlWriter_0.WriteStartElement("GlobalWeather");
				GlobalWeather.ToXML(ref xmlWriter_0);
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("EventTriggers");
				foreach (EventTrigger value2 in EventTriggers.Values)
				{
					value2.ToXML(xmlWriter_0, hashSet_, this);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("EventConditions");
				foreach (EventCondition value3 in EventConditions.Values)
				{
					value3.ToXML(xmlWriter_0, hashSet_, this);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("EventActions");
				foreach (EventAction value4 in EventActions.Values)
				{
					value4.ToXML(xmlWriter_0, hashSet_, this);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("SimEvents");
				foreach (SimEvent value5 in SimEvents.Values)
				{
					value5.ToXML(xmlWriter_0, hashSet_, this);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("ScenAttachmentObjects");
				foreach (ScenAttachmentObject value6 in ScenAttachments.Values)
				{
					value6.ToXML(xmlWriter_0, hashSet_, this);
				}
				xmlWriter_0.WriteEndElement();
				xmlWriter_0.WriteStartElement("FlightplanErrors");
				foreach (MDSP_Error missionPlannerError in MissionPlannerErrorList)
				{
					missionPlannerError.ToXML(hashSet_);
				}
				xmlWriter_0.WriteEndElement();
				XmlWriter xmlWriter3 = xmlWriter_0;
				int timeCompression = (int)_TimeCompression;
				xmlWriter3.WriteElementString("TimeCompression", timeCompression.ToString());
				xmlWriter_0.WriteElementString("GameResolution", XmlConvert.ToString(_GameResolution));
				SaveMessageLog(xmlWriter_0);
				xmlWriter_0.WriteElementString("MessageIncrement", _MessageIncrement.ToString());
				xmlWriter_0.WriteElementString("UnitsAutoIncrement", UnitsAutoIncrement.ToString());
				if (!Information.IsNothing(GetCurrentSide()))
				{
					xmlWriter_0.WriteElementString("CurrentSide", GetCurrentSide().Name);
				}
				xmlWriter_0.WriteElementString("GameVersion", GameVersion);
				xmlWriter_0.WriteElementString("DBUsed", DBUsed.ToString());
				if (LastSavedInScenEdit)
				{
					xmlWriter_0.WriteElementString("LastSavedInScenEdit", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.ACS_NAW_Limitations))
				{
					xmlWriter_0.WriteElementString("LandingPlan_ACS_NAW_Limitations", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.DetailedGunFireControl))
				{
					xmlWriter_0.WriteElementString("Realism_DetailedGunFireControl", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.UnlimitedBaseMagazines))
				{
					xmlWriter_0.WriteElementString("Realism_UnlimitedBaseMags", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.RealisticSubComms))
				{
					xmlWriter_0.WriteElementString("Realism_RealisticSubComms", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.LandTypeEffects))
				{
					xmlWriter_0.WriteElementString("Realism_LandTypeEffects", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.LandTypeEffects_Advanced))
				{
					xmlWriter_0.WriteElementString("Realism_LandTypeEffects_Advanced", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.CommsJamming))
				{
					xmlWriter_0.WriteElementString("Realism_CommsJamming", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.CommsDisruption))
				{
					xmlWriter_0.WriteElementString("Realism_CommsDisruption", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.AircraftDamage))
				{
					xmlWriter_0.WriteElementString("Realism_AircraftDamage", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.WeatherAffectsShipSpeed))
				{
					xmlWriter_0.WriteElementString("Realism_WeatherAffectsShipSpeed", "True");
				}
				if (DeclaredFeatures.Contains(ScenarioFeatureOption.AllowLandingPlannerInstantLoading))
				{
					xmlWriter_0.WriteElementString("LandingPlan_InstLoad", "True");
				}
				if (!string.IsNullOrEmpty(LuaXml))
				{
					xmlWriter_0.WriteElementString("LuaXml", LuaXml);
				}
				if (!string.IsNullOrEmpty(LuaXmlPassed))
				{
					xmlWriter_0.WriteElementString("LuaXmlPassed", LuaXmlPassed);
				}
				if (DefaultGuidedWeaponsVsAirTargetWRASetting != -101)
				{
					xmlWriter_0.WriteElementString("DefaultGuidedWeaponsVsAirTargetWRASetting", DefaultGuidedWeaponsVsAirTargetWRASetting.ToString());
				}
				xmlWriter_0.WriteEndElement();
			}
			hashSet_ = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101022", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Scenario FromXmlText(string string_0, ref string string_1, Action<double> action_0, bool bool_0 = false, bool bool_1 = true)
	{
		return FromXMLText_internal(string_0, ref string_1, action_0, bool_0, bool_1);
	}

	public static Scenario FromXMLText_internal(string string_0, ref string string_1, Action<double> action_0, bool bool_0 = false, bool bool_1 = true)
	{
		if (action_0 == null)
		{
			action_0 = delegate
			{
			};
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.LoadXml(string_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200465", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			_ = Debugger.IsAttached;
			try
			{
				string_0 = Misc.CleanUpXML_Headers(string_0);
				xmlDocument.LoadXml(string_0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				exception_?.Data.Add("Error at 200466", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				_ = Debugger.IsAttached;
				string_0 = Misc.CleanUpXML_IllegalCharacters(string_0.ToCharArray());
				xmlDocument.LoadXml(string_0);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			int Local_TotalItems = 0;
			Scenario Local_theScen = new Scenario("", "", "");
			ConcurrentDictionary<string, ScenarioObject> Local_ObjectsDictionary = new ConcurrentDictionary<string, ScenarioObject>();
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/Scenario");
			string text = ((xmlNode == null) ? "ContentScenario" : "Scenario");
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/GameGUID");
			if (xmlNode == null)
			{
				Local_theScen.TimelineID = xmlDocument.SelectSingleNode("/" + text + "/TimelineID")?.InnerText;
			}
			else
			{
				Local_theScen.TimelineID = xmlNode.InnerText;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/ObjectID");
			if (xmlNode != null)
			{
				Local_theScen.ObjectID = xmlNode.InnerText;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/ContentTag");
			if (xmlNode != null)
			{
				Local_theScen.ContentTag = xmlNode.InnerText;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/CampaignID");
			if (xmlNode != null)
			{
				Local_theScen.CampaignID = xmlNode.InnerText;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/CampaignSessionID");
			if (xmlNode != null)
			{
				Local_theScen.CampaignSessionID = xmlNode.InnerText;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/CampaignScore");
			if (xmlNode != null)
			{
				Local_theScen.CampaignScore = Conversions.ToInteger(xmlNode.InnerText);
			}
			Local_theScen.Title = xmlDocument.SelectSingleNode("/" + text + "/Title")?.InnerText;
			Local_theScen._Description = xmlDocument.SelectSingleNode("/" + text + "/Description").InnerText;
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Description_Encrypted");
			if (xmlNode != null)
			{
				Local_theScen._Description_Encrypted = xmlNode.InnerText;
			}
			Local_theScen.Description = Local_theScen.Description.Replace("<HR>", "");
			try
			{
				Local_theScen.Meta_Complexity = Conversions.ToShort(xmlDocument.SelectSingleNode("/" + text + "/Meta_Complexity").InnerText);
				Local_theScen.Meta_Difficulty = Conversions.ToShort(xmlDocument.SelectSingleNode("/" + text + "/Meta_Difficulty").InnerText);
				Local_theScen.Meta_ScenSetting = xmlDocument.SelectSingleNode("/" + text + "/Meta_ScenSetting").InnerText;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 200051", exception_2.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			Local_theScen.FileName = xmlDocument.SelectSingleNode("/" + text + "/FileName").InnerText;
			try
			{
				if (xmlDocument.SelectSingleNode("/" + text + "/FileNamePath") != null)
				{
					Local_theScen.FileNamePath = xmlDocument.SelectSingleNode("/" + text + "/FileNamePath").InnerText;
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			Local_theScen._Time = DateTime.FromBinary(Conversions.ToLong(xmlDocument.SelectSingleNode("/" + text + "/Time").InnerText));
			try
			{
				Local_theScen.ZeroHour = DateTime.FromBinary(Conversions.ToLong(xmlDocument.SelectSingleNode("/" + text + "/ZeroHour").InnerText));
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				ProjectData.ClearProjectError();
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/StartTime");
			if (xmlNode != null && Operators.CompareString(xmlNode.InnerText, "0", TextCompare: false) != 0)
			{
				Local_theScen._StartTime = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/DaylightSavingTime");
			if (xmlNode != null)
			{
				Local_theScen._DaylightSavingTime = Conversions.ToBoolean(xmlNode.InnerText);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/DaylightSavingTime_Start");
			if (xmlNode != null && Operators.CompareString(xmlNode.InnerText, "0", TextCompare: false) != 0)
			{
				Local_theScen._DaylightSavingTime_Start = xmlDocument.SelectSingleNode("/" + text + "/DaylightSavingTime_Start").InnerText.Replace(",", ".");
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Duration");
			if (xmlNode != null && Operators.CompareString(xmlNode.InnerText, "0", TextCompare: false) != 0)
			{
				Local_theScen._Duration = new TimeSpan(Conversions.ToLong(xmlNode.InnerText));
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/DaylightSavingTime_End");
			if (xmlNode != null && Operators.CompareString(xmlNode.InnerText, "0", TextCompare: false) != 0)
			{
				Local_theScen._DaylightSavingTime_End = xmlDocument.SelectSingleNode("/" + text + "/DaylightSavingTime_End").InnerText.Replace(",", ".");
			}
			try
			{
				Local_theScen.DBUsed = xmlDocument.SelectSingleNode("/" + text + "/DBUsed").InnerText.ToString();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at 999999", exception_3.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (string.IsNullOrEmpty(exception_3.Message))
				{
					GameGeneral.ResolveBridge("错误！想定文件可能已损坏，无法确定要使用哪个数据库！", null);
				}
				else
				{
					GameGeneral.ResolveBridge("错误：" + exception_3.Message, null);
				}
				ProjectData.ClearProjectError();
				return null;
			}
			if (Versioned.IsNumeric(Local_theScen.DBUsed))
			{
				Local_theScen.DBUsed = DBOps.GetHashForMostRecentVersionOfThisDB(Conversions.ToInteger(Local_theScen.DBUsed));
			}
			DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(Local_theScen.DBUsed, ref dbfileCheckResult_, bool_0: true, bool_1);
			if (Information.IsNothing(dBRecordByHash))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new Exception("错误：" + DBOps.PublishImporter(dbfileCheckResult_));
			}
			if (dBRecordByHash.IsRegistered)
			{
				bool? isSupportedByGame = dBRecordByHash.IsSupportedByGame;
				if (((!isSupportedByGame) ?? isSupportedByGame).GetValueOrDefault())
				{
					string_1 += "CAUTION! The database version matching this scenario is no longer supported by the simulation engine. The loaded scenario was automatically matched to the current version of this database. This change will persist on the next scenario save.\r\nNOTE: All units in the scenario will be rebuilt as brand-new from the DB (thus erasing any modified state on them, e.g. damage or expended fuel/weapons). Please use the SBR to restore any unit customizations (damage, ammo etc.) after the rebuild process.";
					Local_theScen.DBUsed = DBOps.GetHashForMostRecentVersionOfThisDB(dBRecordByHash.DBID);
					Local_theScen.LoadStockUnits = true;
				}
			}
			if (bool_0)
			{
				Local_theScen.LoadStockUnits = true;
			}
			DBFunctions.GetPersonnelCargoValues(Local_theScen, ref Mount.PersonnelMass, ref Mount.PersonnelArea);
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Sides");
			XmlNodeList xmlNodeList = null;
			if (xmlNode != null)
			{
				xmlNodeList = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/NonActiveUnits/Explosions");
			XmlNodeList xmlNodeList8 = null;
			if (xmlNode != null)
			{
				xmlNodeList8 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/NonActiveUnits/WeaponImpacts");
			XmlNodeList xmlNodeList9 = null;
			if (xmlNode != null)
			{
				xmlNodeList9 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/NonActiveUnits/UnguidedWeapons");
			XmlNodeList xmlNodeList10 = null;
			if (xmlNode != null)
			{
				xmlNodeList10 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/NonActiveUnits/ChaffClouds");
			XmlNodeList xmlNodeList11 = null;
			if (xmlNode != null)
			{
				xmlNodeList11 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/ActiveUnits");
			XmlNodeList xmlNodeList12 = null;
			if (xmlNode != null)
			{
				xmlNodeList12 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Groups");
			XmlNodeList xmlNodeList13 = null;
			if (xmlNode != null)
			{
				xmlNodeList13 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/EventTriggers");
			XmlNodeList xmlNodeList14 = null;
			if (xmlNode != null)
			{
				xmlNodeList14 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/EventConditions");
			XmlNodeList xmlNodeList15 = null;
			if (xmlNode != null)
			{
				xmlNodeList15 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/EventActions");
			XmlNodeList xmlNodeList2 = null;
			if (xmlNode != null)
			{
				xmlNodeList2 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/SimEvents");
			XmlNodeList xmlNodeList3 = null;
			if (xmlNode != null)
			{
				xmlNodeList3 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/ScenAttachmentObjects");
			XmlNodeList xmlNodeList4 = null;
			if (xmlNode != null)
			{
				xmlNodeList4 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/MessageLog");
			XmlNodeList xmlNodeList5 = null;
			if (xmlNode != null)
			{
				xmlNodeList5 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/FlightplanErrors");
			XmlNodeList xmlNodeList6 = null;
			if (xmlNode != null)
			{
				xmlNodeList6 = xmlNode.ChildNodes;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/CustomEnvironmentZones");
			XmlNodeList xmlNodeList7 = null;
			if (xmlNode != null)
			{
				xmlNodeList7 = xmlNode.ChildNodes;
			}
			if (xmlNodeList != null)
			{
				Local_TotalItems += xmlNodeList.Count;
			}
			if (xmlNodeList8 != null)
			{
				Local_TotalItems += xmlNodeList8.Count;
			}
			if (xmlNodeList9 != null)
			{
				Local_TotalItems += xmlNodeList9.Count;
			}
			if (xmlNodeList10 != null)
			{
				Local_TotalItems += xmlNodeList10.Count;
			}
			if (xmlNodeList11 != null)
			{
				Local_TotalItems += xmlNodeList11.Count;
			}
			if (xmlNodeList12 != null)
			{
				Local_TotalItems += xmlNodeList12.Count;
			}
			if (xmlNodeList13 != null)
			{
				Local_TotalItems += xmlNodeList13.Count;
			}
			if (xmlNodeList14 != null)
			{
				Local_TotalItems += xmlNodeList14.Count;
			}
			if (xmlNodeList15 != null)
			{
				Local_TotalItems += xmlNodeList15.Count;
			}
			if (xmlNodeList2 != null)
			{
				Local_TotalItems += xmlNodeList2.Count;
			}
			if (xmlNodeList3 != null)
			{
				Local_TotalItems += xmlNodeList3.Count;
			}
			if (xmlNodeList4 != null)
			{
				Local_TotalItems += xmlNodeList4.Count;
			}
			if (xmlNodeList5 != null)
			{
				Local_TotalItems += xmlNodeList5.Count;
			}
			if (xmlNodeList7 != null)
			{
				Local_TotalItems += xmlNodeList7.Count;
			}
			int Local_ItemsInstantiated = 0;
			if (!Information.IsNothing(xmlNodeList))
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNodeList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode_ = (XmlNode)enumerator.Current;
						Side side_ = Side.FromXML(ref xmlNode_, ref Local_theScen, ref Local_ObjectsDictionary);
						Local_theScen.AddSide(side_);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList8))
			{
				IEnumerator enumerator10 = null;
				try
				{
					enumerator10 = xmlNodeList8.GetEnumerator();
					while (enumerator10.MoveNext())
					{
						XmlNode xmlNode_4 = (XmlNode)enumerator10.Current;
						Explosion item = Explosion.FromXML(ref xmlNode_4, ref Local_ObjectsDictionary);
						Local_theScen.Explosions.Add(item);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator10 is IDisposable)
					{
						(enumerator10 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList9))
			{
				IEnumerator enumerator11 = null;
				try
				{
					enumerator11 = xmlNodeList9.GetEnumerator();
					while (enumerator11.MoveNext())
					{
						XmlNode xmlNode_5 = (XmlNode)enumerator11.Current;
						WeaponImpact item5 = WeaponImpact.FromXML(ref xmlNode_5, ref Local_ObjectsDictionary);
						Local_theScen.WeaponImpacts.Add(item5);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator11 is IDisposable)
					{
						(enumerator11 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList10))
			{
				IEnumerator enumerator12 = null;
				try
				{
					enumerator12 = xmlNodeList10.GetEnumerator();
					while (enumerator12.MoveNext())
					{
						XmlNode xmlNode_6 = (XmlNode)enumerator12.Current;
						UnguidedWeapon unguidedWeapon = UnguidedWeapon.FromXML(ref xmlNode_6, ref Local_ObjectsDictionary, ref Local_theScen);
						Local_theScen.UnguidedWeapons.Add(unguidedWeapon.ObjectID, unguidedWeapon);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator12 is IDisposable)
					{
						(enumerator12 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList11))
			{
				IEnumerator enumerator13 = null;
				try
				{
					enumerator13 = xmlNodeList11.GetEnumerator();
					while (enumerator13.MoveNext())
					{
						XmlNode xmlNode_7 = (XmlNode)enumerator13.Current;
						ChaffCorridorCloud item6 = ChaffCorridorCloud.FromXML(ref xmlNode_7, ref Local_ObjectsDictionary);
						Local_theScen.ChaffClouds.Add(item6);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator13 is IDisposable)
					{
						(enumerator13 as IDisposable).Dispose();
					}
				}
			}
			if (xmlNodeList12 != null)
			{
				List<XmlNode> Local_theList = new List<XmlNode>(xmlNodeList12.Count);
				List<XmlNode> Local_theList_Groups = new List<XmlNode>();
				IEnumerator enumerator14 = null;
				try
				{
					enumerator14 = xmlNodeList12.GetEnumerator();
					while (enumerator14.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator14.Current;
						if (Operators.CompareString(xmlNode2.Name, "Group", TextCompare: false) == 0)
						{
							Local_theList_Groups.Add(xmlNode2);
						}
						else
						{
							Local_theList.Add(xmlNode2);
						}
					}
				}
				finally
				{
					if (enumerator14 is IDisposable)
					{
						(enumerator14 as IDisposable).Dispose();
					}
				}
				ActiveUnit[] Local_theArray = new ActiveUnit[Local_theList.Count - 1 + 1];
				ActiveUnit[] Local_theArray_Groups = new ActiveUnit[Local_theList_Groups.Count - 1 + 1];
				if (((DbConnection)Local_theScen.DBConnection).State == ConnectionState.Closed)
				{
					((DbConnection)Local_theScen.DBConnection).Open();
				}
				Parallel.For(0, Local_theList.Count, delegate(int i)
				{
					XmlNode xmlNode_13 = Local_theList[i];
					ActiveUnit activeUnit2 = ActiveUnit.FromXML(ref xmlNode_13, ref Local_ObjectsDictionary, ref Local_theScen);
					if (activeUnit2 != null && activeUnit2.DBID != 0)
					{
						Local_theArray[i] = activeUnit2;
						int num5 = Local_ItemsInstantiated;
						Local_ItemsInstantiated = num5 + 1;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				});
				if (Local_theList_Groups.Count > 0)
				{
					Parallel.For(0, Local_theList_Groups.Count, delegate(int i)
					{
						XmlNode xmlNode_12 = Local_theList_Groups[i];
						Group group3 = Group.FromXML(ref xmlNode_12, ref Local_ObjectsDictionary, ref Local_theScen);
						Local_theArray_Groups[i] = group3;
						int num4 = Local_ItemsInstantiated;
						Local_ItemsInstantiated = num4 + 1;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					});
				}
				List<ActiveUnit> list = new List<ActiveUnit>(Local_theArray.Length + Local_theArray_Groups.Length);
				list.AddRange(Local_theArray);
				if (Local_theArray_Groups.Length != 0)
				{
					list.AddRange(Local_theArray_Groups);
				}
				foreach (ActiveUnit item8 in list)
				{
					if (item8 == null)
					{
						continue;
					}
					if (!Local_theScen.ActiveUnits.ContainsKey(item8.ObjectID))
					{
						Local_theScen.ActiveUnits.Add(item8.ObjectID, item8);
					}
					int num = Local_ItemsInstantiated;
					Local_ItemsInstantiated = num + 1;
					action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					if (Information.IsNothing(item8.AssignedMissionOrPackage()))
					{
						if (item8.AI.IsEscort)
						{
							item8.AI.IsEscort = false;
						}
					}
					else if (item8.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike && item8.AI.IsEscort)
					{
						item8.AI.IsEscort = false;
					}
				}
				foreach (ActiveUnit value3 in Local_theScen.ActiveUnits.Values)
				{
					if (value3 != null)
					{
						value3.ParentScen = Local_theScen;
					}
				}
			}
			foreach (XmlNode item9 in Local_theScen.UnitsForLateInstantiation)
			{
				XmlNode xmlNode_8 = item9;
				ActiveUnit activeUnit = ActiveUnit.FromXML(ref xmlNode_8, ref Local_ObjectsDictionary, ref Local_theScen);
				Local_theScen.ActiveUnits[activeUnit.ObjectID] = activeUnit;
			}
			Local_theScen.UnitsForLateInstantiation.Clear();
			if (xmlNodeList13 != null)
			{
				IEnumerator enumerator2 = null;
				try
				{
					enumerator2 = xmlNodeList13.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						XmlNode xmlNode3 = (XmlNode)enumerator2.Current;
						Group group = null;
						try
						{
							group = (Group)Local_ObjectsDictionary[xmlNode3.InnerText];
						}
						catch (Exception projectError4)
						{
							ProjectData.SetProjectError(projectError4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						if (group == null)
						{
							Local_theScen.ActiveUnits.Remove(xmlNode3.InnerText);
						}
						else
						{
							Local_theScen.Groups.Add(group);
							group.ParentScen = Local_theScen;
							group.m_ErrorDic = true;
						}
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList14))
			{
				IEnumerator enumerator3 = null;
				try
				{
					enumerator3 = xmlNodeList14.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						XmlNode xmlNode_9 = (XmlNode)enumerator3.Current;
						EventTrigger eventTrigger = EventTrigger.FromXML(ref xmlNode_9, ref Local_ObjectsDictionary, ref Local_theScen);
						Local_theScen.EventTriggers.Add(eventTrigger.ObjectID, eventTrigger);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator3 is IDisposable)
					{
						(enumerator3 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList15))
			{
				IEnumerator enumerator4 = null;
				try
				{
					enumerator4 = xmlNodeList15.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						XmlNode xmlNode_10 = (XmlNode)enumerator4.Current;
						EventCondition eventCondition = EventCondition.FromXML(ref xmlNode_10, ref Local_ObjectsDictionary, ref Local_theScen);
						Local_theScen.EventConditions.Add(eventCondition.ObjectID, eventCondition);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator4 is IDisposable)
					{
						(enumerator4 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList2))
			{
				IEnumerator enumerator5 = null;
				try
				{
					enumerator5 = xmlNodeList2.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						XmlNode xmlNode_11 = (XmlNode)enumerator5.Current;
						EventAction eventAction = EventAction.FromXML(ref xmlNode_11, ref Local_ObjectsDictionary, ref Local_theScen);
						Local_theScen.EventActions.Add(eventAction.ObjectID, eventAction);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator5 is IDisposable)
					{
						(enumerator5 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList3))
			{
				IEnumerator enumerator6 = null;
				try
				{
					enumerator6 = xmlNodeList3.GetEnumerator();
					while (enumerator6.MoveNext())
					{
						SimEvent simEvent = SimEvent.FromXML((XmlNode)enumerator6.Current, Local_ObjectsDictionary, Local_theScen);
						Local_theScen.SimEvents.Add(simEvent.ObjectID, simEvent);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator6 is IDisposable)
					{
						(enumerator6 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList4))
			{
				IEnumerator enumerator7 = null;
				try
				{
					enumerator7 = xmlNodeList4.GetEnumerator();
					while (enumerator7.MoveNext())
					{
						ScenAttachmentObject scenAttachmentObject = ScenAttachmentObject.FromXML((XmlNode)enumerator7.Current, Local_ObjectsDictionary, Local_theScen);
						Local_theScen.ScenAttachments.Add(scenAttachmentObject.ObjectID, scenAttachmentObject);
						Local_ItemsInstantiated++;
						action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
					}
				}
				finally
				{
					if (enumerator7 is IDisposable)
					{
						(enumerator7 as IDisposable).Dispose();
					}
				}
			}
			if (!Information.IsNothing(xmlNodeList6))
			{
				IEnumerator enumerator8 = null;
				try
				{
					enumerator8 = xmlNodeList6.GetEnumerator();
					while (enumerator8.MoveNext())
					{
						XmlNode xmlNode_2 = (XmlNode)enumerator8.Current;
						MDSP_Error item7 = MDSP_Error.FromXML(ref xmlNode_2, ref Local_ObjectsDictionary);
						Local_theScen.MissionPlannerErrorList.Add(item7);
					}
				}
				finally
				{
					if (enumerator8 is IDisposable)
					{
						(enumerator8 as IDisposable).Dispose();
					}
				}
			}
			XmlNode xmlNode4 = xmlDocument.SelectSingleNode("/" + text + "/WeatherModel");
			if (Information.IsNothing(xmlNode4))
			{
				Local_theScen.WeatherLevel = WeatherModellingLevel.Level0;
			}
			else
			{
				Local_theScen.WeatherLevel = (WeatherModellingLevel)Conversions.ToByte(xmlNode4.InnerText);
			}
			xmlNode4 = xmlDocument.SelectSingleNode("/" + text + "/GlobalWeather");
			if (!Information.IsNothing(xmlNode4))
			{
				Local_theScen._GlobalWeather = Weather.WeatherProfile.FromXML(ref xmlNode4);
			}
			string innerText = xmlDocument.SelectSingleNode("/" + text + "/TimeCompression").InnerText;
			if (Versioned.IsNumeric(innerText))
			{
				try
				{
					Local_theScen._TimeCompression = (enumTimeCompression)Conversions.ToByte(innerText);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					Local_theScen._TimeCompression = enumTimeCompression.OneSec;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Local_theScen._TimeCompression = (enumTimeCompression)Enum.Parse(typeof(enumTimeCompression), innerText, ignoreCase: true);
			}
			Local_theScen._GameResolution = XmlConvert.ToSingle(xmlDocument.SelectSingleNode("/" + text + "/GameResolution").InnerText.Replace(",", "."));
			IEnumerator enumerator9 = null;
			try
			{
				enumerator9 = xmlNodeList5.GetEnumerator();
				while (enumerator9.MoveNext())
				{
					XmlNode xmlNode_3 = (XmlNode)enumerator9.Current;
					LoggedMessage loggedMessage = LoggedMessage.FromXML(ref xmlNode_3, ref Local_ObjectsDictionary);
					if (!Information.IsNothing(loggedMessage))
					{
						Local_theScen.MessageLog.Add(loggedMessage);
					}
					Local_ItemsInstantiated++;
					action_0((double)Local_ItemsInstantiated / (double)Local_TotalItems);
				}
			}
			finally
			{
				if (enumerator9 is IDisposable)
				{
					(enumerator9 as IDisposable).Dispose();
				}
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/MessageIncrement");
			if (xmlNode != null)
			{
				Local_theScen._MessageIncrement = Conversions.ToInteger(xmlNode.InnerText);
			}
			Local_theScen.UnitsAutoIncrement = Conversions.ToInteger(xmlDocument.SelectSingleNode("/" + text + "/UnitsAutoIncrement").InnerText);
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/MessageIncrement");
			if (xmlNode != null)
			{
				Local_theScen._MessageIncrement = Conversions.ToInteger(xmlNode.InnerText);
			}
			if (!Information.IsNothing(xmlDocument.SelectSingleNode("/" + text + "/CurrentSide")))
			{
				string innerText2 = xmlDocument.SelectSingleNode("/" + text + "/CurrentSide").InnerText;
				Side[] sides_ReadOnly2 = Local_theScen.Sides_ReadOnly;
				Side[] array2 = sides_ReadOnly2;
				foreach (Side side in array2)
				{
					if (Operators.CompareString(side.Name, innerText2, TextCompare: false) == 0)
					{
						Local_theScen.SetCurrentSide(side);
					}
				}
			}
			Local_theScen.GameVersion = xmlDocument.SelectSingleNode("/" + text + "/GameVersion").InnerText;
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/LastSavedInScenEdit");
			if (xmlNode != null)
			{
				Local_theScen.LastSavedInScenEdit = true;
			}
			if (Local_theScen.LastSavedInScenEdit)
			{
				Local_theScen.ZeroHour = Local_theScen._Time;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_DetailedGunFireControl");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.DetailedGunFireControl);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_RealisticSubComms");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.RealisticSubComms);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_LandTypeEffects");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.LandTypeEffects);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_LandTypeEffects_Advanced");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.LandTypeEffects_Advanced);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_UnlimitedAirWeapons");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.UnlimitedBaseMagazines);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_UnlimitedBaseMags");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.UnlimitedBaseMagazines);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_CommsJamming");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.CommsJamming);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_AircraftDamage");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.AircraftDamage);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/LandingPlan_InstLoad");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.AllowLandingPlannerInstantLoading);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/LandingPlan_ACS_NAW_Limitations");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.ACS_NAW_Limitations);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_WeatherAffectsShipSpeed");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.WeatherAffectsShipSpeed);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Features_FixedSideColors");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.FixedSideColors);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/Realism_CommsDisruption");
			if (xmlNode != null)
			{
				Local_theScen.DeclaredFeatures.Add(ScenarioFeatureOption.CommsDisruption);
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/LuaXml");
			if (xmlNode != null)
			{
				Local_theScen.LuaXml = xmlNode.InnerText;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/LuaXmlPassed");
			if (!Information.IsNothing(xmlNode))
			{
				Local_theScen.LuaXmlPassed = xmlNode.InnerText;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/DefaultGuidedWeaponsVsAirTargetWRAToNEZ");
			if (xmlNode != null)
			{
				Local_theScen.DefaultGuidedWeaponsVsAirTargetWRASetting = -102;
			}
			xmlNode = xmlDocument.SelectSingleNode("/" + text + "/DefaultGuidedWeaponsVsAirTargetWRASetting");
			if (xmlNode != null && int.TryParse(xmlNode.InnerText, out var result))
			{
				Local_theScen.DefaultGuidedWeaponsVsAirTargetWRASetting = result;
			}
			Side[] sides_ReadOnly3 = Local_theScen.Sides_ReadOnly;
			checked
			{
				for (int j = 0; j < sides_ReadOnly3.Length; j++)
				{
					Side side_2 = sides_ReadOnly3[j];
					side_2.PostDeserializationHousekeeping(ref Local_theScen, Local_ObjectsDictionary, bool_0: false);
					List<Contact> list2 = new List<Contact>();
					list2.AddRange(side_2.Contacts_List);
					foreach (Contact item10 in list2)
					{
						if (item10.PostDeserializationHousekeeping(ref Local_theScen, ref Local_ObjectsDictionary, ref side_2))
						{
							if (item10.ActualUnit.GetIsAutoDetectable(side_2) && item10.LastDetections.Count == 0 && item10.IDStatus == Contact_Base.IdentificationStatus.PreciseID)
							{
								item10.AddDetectionRecord((null, null, 0f, ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection, item10.ActualUnit.ParentScen.Time));
							}
						}
						else
						{
							side_2.Contacts.Remove(item10._ActualUnitID);
						}
					}
					List<Contact> list3 = new List<Contact>();
					list3.AddRange(side_2.BaseContacts_List);
					foreach (Contact item11 in list3)
					{
						if (item11.PostDeserializationHousekeeping(ref Local_theScen, ref Local_ObjectsDictionary, ref side_2))
						{
							if (item11.ActualUnit.GetIsAutoDetectable(side_2) && item11.LastDetections.Count == 0 && item11.IDStatus == Contact_Base.IdentificationStatus.PreciseID)
							{
								item11.AddDetectionRecord((null, null, 0f, ActiveUnit_Sensory.SpecialDetectionMode.AutoDetection, item11.ActualUnit.ParentScen.Time));
							}
						}
						else
						{
							side_2.BaseContacts.Remove(item11._ActualUnitID);
						}
					}
					foreach (ReferencePoint refPoint in side_2.RefPoints)
					{
						refPoint.PostDeserializationHousekeeping(Local_ObjectsDictionary);
					}
					foreach (Mission item12 in side_2.GetMissionsTotal(Local_theScen))
					{
						if (Information.IsNothing(item12))
						{
							continue;
						}
						item12.PostDeserializationHousekeeping(ref Local_theScen, side_2, bool_0: false, ref Local_ObjectsDictionary);
						foreach (Mission.Flight flight in item12.FlightList)
						{
							if (!Information.IsNothing(flight) && flight.FlightPlan.Count() != 0)
							{
								Waypoint[] flightPlan = flight.FlightPlan;
								for (int k = 0; k < flightPlan.Length; k++)
								{
									flightPlan[k].PostDeserializationHousekeeping(ref Local_theScen, side_2, bool_0: false);
								}
							}
						}
					}
					foreach (ActiveUnit item2 in side_2.Units.ToList())
					{
						if (!Information.IsNothing(item2))
						{
							ActiveUnit activeUnit_ = item2;
							activeUnit_.Sensory.PostDeserializationHousekeeping_LocalAndPrivateContacts(ref activeUnit_, Local_ObjectsDictionary);
						}
					}
				}
				foreach (ActiveUnit value6 in Local_theScen.ActiveUnits.Values)
				{
					value6?.PostDeserializationHousekeeping_Groupmembership(ref Local_theScen, Local_ObjectsDictionary);
				}
				List<ActiveUnit> list4 = new List<ActiveUnit>();
				foreach (ActiveUnit value4 in Local_theScen.ActiveUnits.Values)
				{
					value4.PostDeserializationHousekeeping_General(ref Local_theScen, Local_ObjectsDictionary, list4, bool_0: false);
					if (value4.IsGroup)
					{
						continue;
					}
					List<CommLink> list5 = new List<CommLink>();
					list5.AddRange(value4.CommStuff.CommLinksEstablished_ReadOnly);
					foreach (CommLink item3 in list5)
					{
						try
						{
							item3.PostDeserializationHousekeeping(ref Local_ObjectsDictionary);
						}
						catch (Exception ex4)
						{
							ProjectData.SetProjectError(ex4);
							Exception exception_4 = ex4;
							value4.CommStuff.DropCommLink(item3);
							exception_4?.Data.Add("Error at 200052", exception_4.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					Sensor[] array = value4.Sensors_ReadOnly();
					Sensor[] array3 = array;
					foreach (Sensor sensor in array3)
					{
						sensor.PostDeserializationHousekeeping(ref Local_theScen);
						if (Information.IsNothing(sensor.ParentPlatform))
						{
							sensor.ParentPlatform = value4;
						}
					}
				}
				foreach (ActiveUnit item4 in list4)
				{
					Local_theScen.ActiveUnits.Remove(item4.ObjectID);
				}
				foreach (Explosion explosion in Local_theScen.Explosions)
				{
					explosion.PostDeserializationHousekeeping(ref Local_ObjectsDictionary);
				}
				foreach (UnguidedWeapon value5 in Local_theScen.UnguidedWeapons.Values)
				{
					value5.PostDeserializationHousekeeping(ref Local_theScen);
				}
				foreach (Group group2 in Local_theScen.Groups)
				{
					group2.m_ErrorDic = false;
				}
				Local_ObjectsDictionary.Clear();
				foreach (string loadingNotice in Local_theScen.LoadingNotices)
				{
					string_1 = string_1 + "\r\n" + loadingNotice + "\r\n";
				}
				Local_theScen.GuidedWeaponsInAir = null;
				Local_theScen.SonobuoysInWater = null;
				Local_theScen.AllWeaponsAlive = null;
				_ = Local_theScen.GuidedWeaponsInAir;
				Local_theScen.UpdateMissionFlightSize();
				Side[] sides_ReadOnly = Local_theScen.Sides_ReadOnly;
				Side[] array4 = sides_ReadOnly;
				foreach (Side side2 in array4)
				{
					foreach (ActiveUnit unit in side2.Units)
					{
						if (Information.IsNothing(unit) || !unit.IsAircraft || Information.IsNothing(((Aircraft)unit).Loadout))
						{
							continue;
						}
						WeaponRec[] weapons = ((Aircraft)unit).Loadout.Weapons;
						WeaponRec[] array5 = weapons;
						foreach (WeaponRec weaponRec in array5)
						{
							if (!weaponRec.GetReferenceWeapon(unit.ParentScen).IsPalletWeapon || weaponRec.GetReferenceWeapon(unit.ParentScen).Warheads.Count() <= 0)
							{
								continue;
							}
							Warhead[] warheads = weaponRec.GetReferenceWeapon(unit.ParentScen).Warheads;
							Warhead[] array6 = warheads;
							foreach (Warhead warhead in array6)
							{
								if (warhead.GetCarriedWeapon(unit.ParentScen) == null)
								{
									continue;
								}
								if (side2.Doctrine.WRA == null)
								{
									side2.Doctrine.WRA = new Dictionary<int, Doctrine.WRA_Weapon>();
								}
								if (!side2.Doctrine.WRA.ContainsKey(warhead.GetCarriedWeapon(unit.ParentScen).DBID))
								{
									Weapon weapon_ = warhead.GetCarriedWeapon(unit.ParentScen);
									Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon(ref weapon_, unit.ParentScen);
									if (!side2.Doctrine.WRA.ContainsKey(weaponRec.GetReferenceWeapon(unit.ParentScen).DBID))
									{
										side2.Doctrine.WRA.Add(warhead.GetCarriedWeapon(unit.ParentScen).DBID, value);
									}
								}
								if (unit.Doctrine.WRA == null)
								{
									unit.Doctrine.WRA = new Dictionary<int, Doctrine.WRA_Weapon>();
								}
								if (!unit.Doctrine.WRA.ContainsKey(warhead.GetCarriedWeapon(unit.ParentScen).DBID))
								{
									Weapon weapon_2 = warhead.GetCarriedWeapon(unit.ParentScen);
									Doctrine.WRA_Weapon value2 = new Doctrine.WRA_Weapon(ref weapon_2, unit.ParentScen);
									if (!unit.Doctrine.WRA.ContainsKey(warhead.GetCarriedWeapon(unit.ParentScen).DBID))
									{
										unit.Doctrine.WRA.Add(warhead.GetCarriedWeapon(unit.ParentScen).DBID, value2);
									}
								}
							}
						}
					}
				}
				return Local_theScen;
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception exception_5 = ex5;
			exception_5?.Data.Add("Error at 101023", string_1);
			GameGeneral.WriteExceptionsToLog(ref exception_5);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Scenario smethod_0(string string_0, ref string string_1, Action<double> action_0)
	{
		if (action_0 == null)
		{
			action_0 = delegate
			{
			};
		}
		try
		{
			return FromXMLText_internal(File.ReadAllText(string_0), ref string_1, action_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101025", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal bool UsesHighFidelity()
	{
		return GameResolution == 0.1f;
	}

	public void Initialize()
	{
		GameGeneral.RegisteredExceptions.Clear();
		GameGeneral.VeryHighIntensityResolution = 5f;
		List<EventTrigger> list = new List<EventTrigger>();
		foreach (EventTrigger value in EventTriggers.Values)
		{
			if (value.Type == EventTrigger.EventTriggerType.ScenLoaded)
			{
				list.Add(value);
			}
		}
		if (list.Count > 0)
		{
			FireEvents(list);
		}
	}

	public static string[] QueryScenario_ScenFileName(string string_0, List<string> list_1)
	{
		string[] array = new string[list_1.Count - 1 + 1];
		string scenarioObject_AsXML = ScenContainer.LoadFromFile(string_0).GetScenarioObject_AsXML();
		int num = list_1.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			XmlReader xmlReader = XmlReader.Create(new StringReader(scenarioObject_AsXML));
			using (xmlReader)
			{
				if (xmlReader.ReadToDescendant(list_1[i]))
				{
					array[i] = xmlReader.ReadElementContentAsString();
				}
				else
				{
					array[i] = "";
				}
			}
		}
		return array;
	}

	public static string QueryScenario_ScenFileName(string string_0, string string_1)
	{
		new List<string>();
		return QueryScenario_ScenXML(ScenContainer.LoadFromFile(string_0).GetScenarioObject_AsXML(), string_1);
	}

	public static string QueryScenario_ScenXML(string string_0, string string_1)
	{
		try
		{
			XmlReader xmlReader = XmlReader.Create(new StringReader(string_0));
			using (xmlReader)
			{
				if (xmlReader.ReadToDescendant(string_1))
				{
					return xmlReader.ReadElementContentAsString();
				}
				return null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101285", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public void FireEvents(List<EventTrigger> list_1)
	{
		ActiveUnit activeUnit = null;
		Contact contact = null;
		try
		{
			foreach (EventTrigger item in list_1)
			{
				foreach (SimEvent item2 in SimEvents.Values.ToList())
				{
					if (!item2.IsActive)
					{
						continue;
					}
					LuaSandBox.Singleton().EventX = item2;
					if (!item2.Triggers.Contains(item))
					{
						continue;
					}
					if (item2.GetConditionsAreMet(this))
					{
						if (item2.Probability != 100 && GameGeneral.LockRandom_0.Next(0, 100) > item2.Probability)
						{
							if (item2.IsShown)
							{
								AddMessage("事件：'" + item2.Description + "'被触发但没有执行（概率检查失败）。", "事件已触发但未执行", LoggedMessage.MessageType.EventEngine, 1, "");
							}
							if (!item2.IsRepeatable)
							{
								item2.IsActive = false;
							}
							continue;
						}
						ActiveUnit activeUnit2 = null;
						activeUnit = null;
						contact = null;
						List<Sensor> sensorsThatMadeDetection = null;
						if (item.Type == EventTrigger.EventTriggerType.UnitRemainsInArea)
						{
							activeUnit2 = ((EventTrigger_UnitRemainsInArea)item).CulpritUnit;
						}
						else if (item.Type == EventTrigger.EventTriggerType.UnitEntersArea)
						{
							activeUnit2 = ((EventTrigger_UnitEntersArea)item).CulpritUnit;
							if (Information.IsNothing(activeUnit2))
							{
								if (!((EventTrigger_UnitEntersArea)item).Modifier_NOT)
								{
									continue;
								}
							}
							else
							{
								if (((EventTrigger_UnitEntersArea)item).Modifier_EXIT)
								{
									if (((EventTrigger_UnitEntersArea)item).JustEnteredArea)
									{
										activeUnit2.ActiveEnterAreaTriggers.Add(((EventTrigger_UnitEntersArea)item).ObjectID);
										activeUnit2 = null;
										continue;
									}
									if (((EventTrigger_UnitEntersArea)item).LeavesArea)
									{
										activeUnit2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitEntersArea)item).ObjectID);
									}
								}
								else if (((EventTrigger_UnitEntersArea)item).JustEnteredArea)
								{
									activeUnit2.ActiveEnterAreaTriggers.Add(((EventTrigger_UnitEntersArea)item).ObjectID);
								}
								else if (((EventTrigger_UnitEntersArea)item).LeavesArea)
								{
									activeUnit2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitEntersArea)item).ObjectID);
								}
								if (activeUnit2.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo)
								{
									activeUnit2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitEntersArea)item).ObjectID);
								}
							}
						}
						else if (item.Type == EventTrigger.EventTriggerType.UnitDamaged)
						{
							activeUnit2 = ((EventTrigger_UnitDamaged)item).DamagedUnit;
							activeUnit = ((EventTrigger_UnitDamaged)item).DamagingUnit;
							Scenario_LuaSandbox.UnitY = null;
						}
						else if (item.Type == EventTrigger.EventTriggerType.UnitDestroyed)
						{
							activeUnit2 = ((EventTrigger_UnitDestroyed)item).DestroyedUnit;
							activeUnit = ((EventTrigger_UnitDestroyed)item).DamagingUnit;
							if (activeUnit2.IsBeingPickedUp && activeUnit2.PickUpUnit != null)
							{
								activeUnit = activeUnit2.PickUpUnit;
							}
							Scenario_LuaSandbox.UnitY = null;
						}
						else if (item.Type == EventTrigger.EventTriggerType.UnitDetected)
						{
							activeUnit2 = ((EventTrigger_UnitDetected)item).DetectedUnit;
							activeUnit = ((EventTrigger_UnitDetected)item).DetectingUnit;
							sensorsThatMadeDetection = ((EventTrigger_UnitDetected)item).SensorsThatMadeDetection;
							contact = ((EventTrigger_UnitDetected)item).DetectedAsContact;
							if (((EventTrigger_UnitDetected)item).DetectedInArea.HasValue)
							{
								bool? detectedInArea = ((EventTrigger_UnitDetected)item).DetectedInArea;
								detectedInArea = detectedInArea;
								if (detectedInArea.GetValueOrDefault() && !Information.IsNothing(contact))
								{
									contact.ActiveEnterAreaTriggers.Add(((EventTrigger_UnitDetected)item).ObjectID);
								}
							}
						}
						else if (item.Type == EventTrigger.EventTriggerType.UnitBaseStatus)
						{
							activeUnit2 = ((EventTrigger_UnitBaseStatus)item).CulpritUnit;
						}
						else if (item.Type == EventTrigger.EventTriggerType.UnitCargoMoved)
						{
							_ = ((EventTrigger_UnitCargoMoved)item).postEvent;
							activeUnit2 = ((EventTrigger_UnitCargoMoved)item).BaseUnit;
						}
						if (!Information.IsNothing(activeUnit2))
						{
							Scenario_LuaSandbox.UnitX = activeUnit2;
						}
						if (!(Information.IsNothing(activeUnit2) & Information.IsNothing(activeUnit) & Information.IsNothing(contact)))
						{
							if (Information.IsNothing(activeUnit))
							{
								LuaSandBox.Singleton().UnitY = null;
							}
							else
							{
								Scenario_LuaSandbox.UnitY = activeUnit;
								Scenario_LuaSandbox.SensorsThatMadeDetection = sensorsThatMadeDetection;
							}
							if (Information.IsNothing(contact))
							{
								LuaSandBox.Singleton().UnitC = null;
							}
							else
							{
								Scenario_LuaSandbox.UnitC = contact;
							}
						}
						if (item2.IsShown)
						{
							AddMessage("事件：'" + item2.Description + "'已触发执行。", "想定事件执行", LoggedMessage.MessageType.EventEngine, 1, "");
						}
						if (!item2.IsRepeatable)
						{
							item2.IsActive = false;
						}
						if (item.Type == EventTrigger.EventTriggerType.Time)
						{
							item2.IsActive = false;
						}
						foreach (EventAction item3 in item2.Actions.ToList())
						{
							item3.Execute(this, item2);
						}
					}
					else
					{
						if (item2.IsShown)
						{
							AddMessage("事件：'" + item2.Description + "'被触发但没有执行（至少有一个条件不成立）。", "事件已触发但未执行（条件未满足）", LoggedMessage.MessageType.EventEngine, 1, "");
						}
						if (!item2.IsRepeatable)
						{
							item2.IsActive = false;
						}
						if (item.Type == EventTrigger.EventTriggerType.Time)
						{
							item2.IsActive = false;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101028", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	public void SetTime(bool bool_0, DateTime dateTime_0)
	{
		try
		{
			if ((int)_TimeCompression <= 3)
			{
				if (_Time.Second == dateTime_0.Second)
				{
					SecondIsChangingOnThisPulse = false;
				}
				else
				{
					SecondIsChangingOnThisPulse = true;
				}
			}
			else
			{
				SecondIsChangingOnThisPulse = true;
			}
			FifthSecondIsChangingOnThisPulse = false;
			FifteenthSecondIsChangingOnThisPulse = false;
			ThirtiethSecondIsChangingOnThisPulse = false;
			MinuteIsChangingOnThisPulse = false;
			FifthMinuteIsChangingOnThisPulse = false;
			FifteenthMinuteIsChangingOnThisPulse = false;
			ThirtiethMinuteIsChangingOnThisPulse = false;
			HourIsChangingOnThisPulse = false;
			SixHourIsChangingOnThisPulse = false;
			TwelveHourIsChangingOnThisPulse = false;
			TwentyFourHourIsChangingOnThisPulse = false;
			if (SecondIsChangingOnThisPulse)
			{
				if (dateTime_0.Second % 5 == 0)
				{
					FifthSecondIsChangingOnThisPulse = true;
					if (dateTime_0.Second % 15 == 0)
					{
						FifteenthSecondIsChangingOnThisPulse = true;
						if (dateTime_0.Second % 30 == 0)
						{
							ThirtiethSecondIsChangingOnThisPulse = true;
							if (dateTime_0.Second % 60 == 0)
							{
								MinuteIsChangingOnThisPulse = true;
								if (dateTime_0.Minute % 5 == 0)
								{
									FifthMinuteIsChangingOnThisPulse = true;
									if (dateTime_0.Minute % 15 == 0)
									{
										FifteenthMinuteIsChangingOnThisPulse = true;
										if (dateTime_0.Minute % 30 == 0)
										{
											ThirtiethMinuteIsChangingOnThisPulse = true;
											if (_Time.Hour != dateTime_0.Hour)
											{
												HourIsChangingOnThisPulse = true;
											}
										}
									}
								}
							}
						}
					}
				}
				if (GameResolution > 1f)
				{
					List<DateTime> list = new List<DateTime>();
					int num = (int)Math.Round(GameResolution) - 1;
					for (int i = 1; i <= num; i++)
					{
						DateTime item = dateTime_0.Subtract(new TimeSpan(0, 0, i));
						list.Add(item);
					}
					foreach (DateTime item2 in list)
					{
						if (item2.Second % 5 != 0)
						{
							continue;
						}
						FifthSecondIsChangingOnThisPulse = true;
						if (item2.Second % 15 != 0)
						{
							continue;
						}
						FifteenthSecondIsChangingOnThisPulse = true;
						if (item2.Second % 30 != 0)
						{
							continue;
						}
						ThirtiethSecondIsChangingOnThisPulse = true;
						if (item2.Second % 60 != 0)
						{
							continue;
						}
						MinuteIsChangingOnThisPulse = true;
						if (item2.Minute % 5 != 0)
						{
							continue;
						}
						FifthMinuteIsChangingOnThisPulse = true;
						if (item2.Minute % 15 != 0)
						{
							continue;
						}
						FifteenthMinuteIsChangingOnThisPulse = true;
						if (item2.Minute % 30 == 0)
						{
							ThirtiethMinuteIsChangingOnThisPulse = true;
							if (_Time.Hour != item2.Hour)
							{
								HourIsChangingOnThisPulse = true;
							}
						}
					}
				}
			}
			TimeSpan timeSpan = dateTime_0 - StartTime;
			if (timeSpan.TotalHours > 0.0 && HourIsChangingOnThisPulse && (timeSpan.Hours % 6 == 0 || timeSpan.TotalHours % 6.0 == 0.0))
			{
				SixHourIsChangingOnThisPulse = true;
				if (timeSpan.Hours % 12 == 0 || timeSpan.TotalHours % 12.0 == 0.0)
				{
					TwelveHourIsChangingOnThisPulse = true;
					if (timeSpan.Hours % 24 == 0 || timeSpan.TotalHours % 24.0 == 0.0)
					{
						TwentyFourHourIsChangingOnThisPulse = true;
					}
				}
			}
			List<EventTrigger> list2 = new List<EventTrigger>();
			if (bool_0)
			{
				_OnTimeChangedManuallyEvent?.Invoke(this, dateTime_0);
			}
			else
			{
				foreach (EventTrigger value in EventTriggers.Values)
				{
					if (value.Type == EventTrigger.EventTriggerType.Time && ((EventTrigger_Time)value).GetIsFulfilled(dateTime_0))
					{
						list2.Add(value);
					}
					if (value.Type == EventTrigger.EventTriggerType.RandomTime && ((EventTrigger_RandomTime)value).GetIsFulfilled(dateTime_0))
					{
						list2.Add(value);
					}
					if (value.Type == EventTrigger.EventTriggerType.RegularTime && ((EventTrigger_RegularTime)value).GetIsFulfilled(this))
					{
						list2.Add(value);
					}
				}
				if (SecondIsChangingOnThisPulse)
				{
					foreach (EventTrigger value2 in EventTriggers.Values)
					{
						if (value2.Type == EventTrigger.EventTriggerType.UnitEntersArea && ((EventTrigger_UnitEntersArea)value2).GetIsFulfilled(this))
						{
							list2.Add(value2);
						}
						if (value2.Type == EventTrigger.EventTriggerType.UnitRemainsInArea && ((EventTrigger_UnitRemainsInArea)value2).GetIsFulfilled(this, GameResolution))
						{
							list2.Add(value2);
						}
					}
				}
			}
			_Time = dateTime_0;
			FireEvents(list2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101029", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EndScenario()
	{
		_HasEnded = true;
		Scenario.ScenCompleted?.Invoke(this);
	}

	public void AdjustGameResolution()
	{
		if (!LockFidelityResolution)
		{
			if (RunningHeadless)
			{
				GameResolution = GetAdjustedGameResolution(GameGeneral.Global_PulseResolution);
			}
			else
			{
				GameResolution = GetAdjustedGameResolution(_TimeCompression);
			}
		}
	}

	internal float GetAdjustedGameResolution(enumTimeCompression enumTimeCompression_0)
	{
		switch (enumTimeCompression_0)
		{
		case enumTimeCompression.Coarse_FiveSecSlice:
		{
			bool flag = false;
			foreach (Weapon item in GuidedWeaponsInAir)
			{
				if (item.IsAerospaceUnit && (item.IsAAW || item.IsASAT || item.PopReponse()))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				foreach (UnguidedWeapon item2 in new List<UnguidedWeapon>(UnguidedWeapons.Values))
				{
					if (item2 != null && item2.PrepareWatcher())
					{
						flag = true;
						break;
					}
				}
			}
			if (GameGeneral.VeryHighIntensityResolution > 0f && GameGeneral.UseDynamicResolution)
			{
				return 0.1f;
			}
			if ((GameGeneral.HighIntensityResolution > 0f && GameGeneral.UseDynamicResolution) || flag)
			{
				return 1f;
			}
			return 5f;
		}
		default:
			return 0.1f;
		case enumTimeCompression.Coarse_OneSecSlice:
			if (GameGeneral.VeryHighIntensityResolution > 0f && GameGeneral.UseDynamicResolution)
			{
				return 0.1f;
			}
			return 1f;
		}
	}

	internal float GetAdjustedGameResolution(float float_0)
	{
		if (float_0 == 5f)
		{
			return GetAdjustedGameResolution(enumTimeCompression.Coarse_FiveSecSlice);
		}
		if (float_0 == 1f)
		{
			return GetAdjustedGameResolution(enumTimeCompression.Coarse_OneSecSlice);
		}
		return GetAdjustedGameResolution(enumTimeCompression.OneSec);
	}

	public void TimeCompression_Increase()
	{
		if (!LockFidelityResolution && (int)_TimeCompression < 5)
		{
			_TimeCompression++;
			AdjustGameResolution();
			Scenario.TimeCompressionChanged?.Invoke();
		}
	}

	public void TimeCompression_Decrease()
	{
		if (!LockFidelityResolution && (int)_TimeCompression > 0)
		{
			_TimeCompression--;
			AdjustGameResolution();
			Scenario.TimeCompressionChanged?.Invoke();
		}
	}

	public void TimeCompression_Set(enumTimeCompression enumTimeCompression_0)
	{
		if (!LockFidelityResolution)
		{
			_TimeCompression = enumTimeCompression_0;
			AdjustGameResolution();
			Scenario.TimeCompressionChanged?.Invoke();
		}
	}

	internal bool SetSimulationFidelity(float float_0, bool bool_0 = false, bool bool_1 = true)
	{
		if (float_0 != 0.1f && float_0 != 1f && float_0 != 5f)
		{
			return false;
		}
		if (LockFidelityResolution != bool_0)
		{
			LockFidelityResolution = bool_0;
		}
		if (bool_1)
		{
			AddMessage("Changed simulation resolution from " + GameResolution.ToString("#.#") + "至" + float_0.ToString("#.#") + " (Locked)", "Simulation resolution changed", LoggedMessage.MessageType.SpecialMessage, 1, "");
		}
		GameResolution = float_0;
		return true;
	}

	public void SetCurrentSide(Side side_0)
	{
		_CurrentSide = side_0;
		Scenario.CurrentSideChanged?.Invoke(this);
	}

	public Side GetCurrentSide()
	{
		if (Sides_ReadOnly.Length == 0)
		{
			return null;
		}
		if (_CurrentSide == null)
		{
			return Sides_ReadOnly[0];
		}
		return _CurrentSide;
	}

	public void BranchToNewTimeline()
	{
		ParentTimelineID = TimelineID;
		TimelineID = Guid.NewGuid().ToString();
	}

	public Scenario()
	{
		RunningHeadless = false;
		ActiveUnits = new ObservableDictionary<string, ActiveUnit>();
		ActiveUnitsSyncLock = RuntimeHelpers.GetObjectValue(new object());
		Groups = new List<Group>();
		_GuidedWeapons = new List<Weapon>();
		_MobileDecoysActive = new List<Weapon>();
		_SonobuoysInWater = new List<Weapon>();
		_AllWeaponsAlive = new List<Weapon>();
		_Sides = new Side[0];
		_UnitAdditions = new List<ActiveUnit>();
		_UnitRemovals = new List<ActiveUnit>();
		list_0 = new List<UnguidedWeapon>();
		_UnitDeletions = new List<ActiveUnit>();
		Navigation_FinegrainedThresholdDistance = 0.5f;
		Navigation_FinegrainedMaxDistance = 8f;
		UserIsPlottingCourse = false;
		DefaultGuidedWeaponsVsAirTargetWRASetting = -101;
		ScenAttachments = new ObservableDictionary<string, ScenAttachmentObject>();
		UnhandledPopUpMessages = new Queue<LoggedMessage>();
		MessageLog = new List<LoggedMessage>();
		_MessageLogQueue = new ConcurrentQueue<LoggedMessage>();
		UnitsForLateInstantiation = new HashSet<XmlNode>();
		Cache_FacilitiesWithPiers = new List<ActiveUnit>();
		Cache_Weapons = new ConcurrentDictionary<int, Weapon>();
		Cache_Sensors = new ConcurrentDictionary<int, Sensor>();
		Cache_SensorCompatibleFrequencies = new ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>();
		Cache_XSections = new ConcurrentDictionary<string, XSection[]>();
		Cache_FuelForPitchEnabledWeapons = new ConcurrentDictionary<int, int>();
		Cache_BurnTimesForBoostCoastWeapons = new ConcurrentDictionary<int, (int, int)>();
		Cache_TimeOfDay = new Weather.TTimeOfDayType?[360][];
		Cache_AssociatedSensors = new ConcurrentDictionary<int, Sensor>();
		Cache_PowerplantAltBands = new ConcurrentDictionary<int, AltBand[]>();
		Cache_PrimaryTargetForWhichPlatforms = new TDictionary<string, List<Platform>>();
		Cache_DisabledLoadouts = new HashSet<int>();
		Cache_WRA_WeaponQty_SystemDefault = new ConcurrentDictionary<ulong, int?>();
		Cache_WRA_FiringDoctrineEntry_SystemDefault = new ConcurrentDictionary<ulong, Doctrine.WRA_FiringDoctrineEntry>();
		CandidatesForDetectionByMines = new List<ActiveUnit>();
		LoadingNotices = new List<string>();
		ThreadedOpsMustStop = false;
		DeclaredFeatures = new HashSet<ScenarioFeatureOption>();
		LastSavedInScenEdit = false;
		FeatureCompatibility = default(_FeatureCompatibility);
		EventWaitHandle_FinishPulse = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		MissionPlannerErrorList = new List<MDSP_Error>();
		EventTriggers = new ObservableDictionary<string, EventTrigger>();
		EventConditions = new ObservableDictionary<string, EventCondition>();
		EventActions = new ObservableDictionary<string, EventAction>();
		SimEvents = new ObservableDictionary<string, SimEvent>();
		Explosions = new ObservableList<Explosion>();
		WeaponImpacts = new ObservableList<WeaponImpact>();
		WaterSplashes = new List<WaterSplash>();
		GroundImpacts = new List<GroundImpact>();
		UnguidedWeapons = new ObservableDictionary<string, UnguidedWeapon>();
		MineAllocation = new ObservableDictionary<string, UnguidedWeapon>();
		ChaffClouds = new List<ChaffCorridorCloud>();
		UnitAutodetectionValidation = new ConcurrentHashSet<Side>();
		_ActiveUnits_ListLockObj = RuntimeHelpers.GetObjectValue(new object());
		UnUsedObj = RuntimeHelpers.GetObjectValue(new object());
		DEBUG_CustomResolution = null;
		DEBUG_CustomCompression = null;
		HasBeenReleased = false;
		_AddUnitLockObj = RuntimeHelpers.GetObjectValue(new object());
		_AddRemoveUnitsLockObj = RuntimeHelpers.GetObjectValue(new object());
		writing = RuntimeHelpers.GetObjectValue(new object());
		_GetGuidedWeaponsLockObj = RuntimeHelpers.GetObjectValue(new object());
		_Locker_ActiveUnits_DictionaryChanged = RuntimeHelpers.GetObjectValue(new object());
		WeaponFeedBackMessage = new List<string>();
		TimelineID = Guid.NewGuid().ToString();
		_ObjectID = Guid.NewGuid().ToString();
		ZeroHour = _Time;
	}

	public Scenario(string string_0, string string_1, string string_2)
	{
		RunningHeadless = false;
		ActiveUnits = new ObservableDictionary<string, ActiveUnit>();
		ActiveUnitsSyncLock = RuntimeHelpers.GetObjectValue(new object());
		Groups = new List<Group>();
		_GuidedWeapons = new List<Weapon>();
		_MobileDecoysActive = new List<Weapon>();
		_SonobuoysInWater = new List<Weapon>();
		_AllWeaponsAlive = new List<Weapon>();
		_Sides = new Side[0];
		_UnitAdditions = new List<ActiveUnit>();
		_UnitRemovals = new List<ActiveUnit>();
		list_0 = new List<UnguidedWeapon>();
		_UnitDeletions = new List<ActiveUnit>();
		Navigation_FinegrainedThresholdDistance = 0.5f;
		Navigation_FinegrainedMaxDistance = 8f;
		UserIsPlottingCourse = false;
		DefaultGuidedWeaponsVsAirTargetWRASetting = -101;
		ScenAttachments = new ObservableDictionary<string, ScenAttachmentObject>();
		UnhandledPopUpMessages = new Queue<LoggedMessage>();
		MessageLog = new List<LoggedMessage>();
		_MessageLogQueue = new ConcurrentQueue<LoggedMessage>();
		UnitsForLateInstantiation = new HashSet<XmlNode>();
		Cache_FacilitiesWithPiers = new List<ActiveUnit>();
		Cache_Weapons = new ConcurrentDictionary<int, Weapon>();
		Cache_Sensors = new ConcurrentDictionary<int, Sensor>();
		Cache_SensorCompatibleFrequencies = new ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>();
		Cache_XSections = new ConcurrentDictionary<string, XSection[]>();
		Cache_FuelForPitchEnabledWeapons = new ConcurrentDictionary<int, int>();
		Cache_BurnTimesForBoostCoastWeapons = new ConcurrentDictionary<int, (int, int)>();
		Cache_TimeOfDay = new Weather.TTimeOfDayType?[360][];
		Cache_AssociatedSensors = new ConcurrentDictionary<int, Sensor>();
		Cache_PowerplantAltBands = new ConcurrentDictionary<int, AltBand[]>();
		Cache_PrimaryTargetForWhichPlatforms = new TDictionary<string, List<Platform>>();
		Cache_DisabledLoadouts = new HashSet<int>();
		Cache_WRA_WeaponQty_SystemDefault = new ConcurrentDictionary<ulong, int?>();
		Cache_WRA_FiringDoctrineEntry_SystemDefault = new ConcurrentDictionary<ulong, Doctrine.WRA_FiringDoctrineEntry>();
		CandidatesForDetectionByMines = new List<ActiveUnit>();
		LoadingNotices = new List<string>();
		ThreadedOpsMustStop = false;
		DeclaredFeatures = new HashSet<ScenarioFeatureOption>();
		LastSavedInScenEdit = false;
		FeatureCompatibility = default(_FeatureCompatibility);
		EventWaitHandle_FinishPulse = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		MissionPlannerErrorList = new List<MDSP_Error>();
		EventTriggers = new ObservableDictionary<string, EventTrigger>();
		EventConditions = new ObservableDictionary<string, EventCondition>();
		EventActions = new ObservableDictionary<string, EventAction>();
		SimEvents = new ObservableDictionary<string, SimEvent>();
		Explosions = new ObservableList<Explosion>();
		WeaponImpacts = new ObservableList<WeaponImpact>();
		WaterSplashes = new List<WaterSplash>();
		GroundImpacts = new List<GroundImpact>();
		UnguidedWeapons = new ObservableDictionary<string, UnguidedWeapon>();
		MineAllocation = new ObservableDictionary<string, UnguidedWeapon>();
		ChaffClouds = new List<ChaffCorridorCloud>();
		UnitAutodetectionValidation = new ConcurrentHashSet<Side>();
		_ActiveUnits_ListLockObj = RuntimeHelpers.GetObjectValue(new object());
		UnUsedObj = RuntimeHelpers.GetObjectValue(new object());
		DEBUG_CustomResolution = null;
		DEBUG_CustomCompression = null;
		HasBeenReleased = false;
		_AddUnitLockObj = RuntimeHelpers.GetObjectValue(new object());
		_AddRemoveUnitsLockObj = RuntimeHelpers.GetObjectValue(new object());
		writing = RuntimeHelpers.GetObjectValue(new object());
		_GetGuidedWeaponsLockObj = RuntimeHelpers.GetObjectValue(new object());
		_Locker_ActiveUnits_DictionaryChanged = RuntimeHelpers.GetObjectValue(new object());
		WeaponFeedBackMessage = new List<string>();
		Title = string_0;
		Description = string_1;
		FileName = string_2;
		SetTime(bool_0: false, DateTime.UtcNow);
		TimelineID = Guid.NewGuid().ToString();
		_ObjectID = Guid.NewGuid().ToString();
		ZeroHour = _Time;
	}

	public Scenario(string string_0)
	{
		RunningHeadless = false;
		ActiveUnits = new ObservableDictionary<string, ActiveUnit>();
		ActiveUnitsSyncLock = RuntimeHelpers.GetObjectValue(new object());
		Groups = new List<Group>();
		_GuidedWeapons = new List<Weapon>();
		_MobileDecoysActive = new List<Weapon>();
		_SonobuoysInWater = new List<Weapon>();
		_AllWeaponsAlive = new List<Weapon>();
		_Sides = new Side[0];
		_UnitAdditions = new List<ActiveUnit>();
		_UnitRemovals = new List<ActiveUnit>();
		list_0 = new List<UnguidedWeapon>();
		_UnitDeletions = new List<ActiveUnit>();
		Navigation_FinegrainedThresholdDistance = 0.5f;
		Navigation_FinegrainedMaxDistance = 8f;
		UserIsPlottingCourse = false;
		DefaultGuidedWeaponsVsAirTargetWRASetting = -101;
		ScenAttachments = new ObservableDictionary<string, ScenAttachmentObject>();
		UnhandledPopUpMessages = new Queue<LoggedMessage>();
		MessageLog = new List<LoggedMessage>();
		_MessageLogQueue = new ConcurrentQueue<LoggedMessage>();
		UnitsForLateInstantiation = new HashSet<XmlNode>();
		Cache_FacilitiesWithPiers = new List<ActiveUnit>();
		Cache_Weapons = new ConcurrentDictionary<int, Weapon>();
		Cache_Sensors = new ConcurrentDictionary<int, Sensor>();
		Cache_SensorCompatibleFrequencies = new ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>();
		Cache_XSections = new ConcurrentDictionary<string, XSection[]>();
		Cache_FuelForPitchEnabledWeapons = new ConcurrentDictionary<int, int>();
		Cache_BurnTimesForBoostCoastWeapons = new ConcurrentDictionary<int, (int, int)>();
		Cache_TimeOfDay = new Weather.TTimeOfDayType?[360][];
		Cache_AssociatedSensors = new ConcurrentDictionary<int, Sensor>();
		Cache_PowerplantAltBands = new ConcurrentDictionary<int, AltBand[]>();
		Cache_PrimaryTargetForWhichPlatforms = new TDictionary<string, List<Platform>>();
		Cache_DisabledLoadouts = new HashSet<int>();
		Cache_WRA_WeaponQty_SystemDefault = new ConcurrentDictionary<ulong, int?>();
		Cache_WRA_FiringDoctrineEntry_SystemDefault = new ConcurrentDictionary<ulong, Doctrine.WRA_FiringDoctrineEntry>();
		CandidatesForDetectionByMines = new List<ActiveUnit>();
		LoadingNotices = new List<string>();
		ThreadedOpsMustStop = false;
		DeclaredFeatures = new HashSet<ScenarioFeatureOption>();
		LastSavedInScenEdit = false;
		FeatureCompatibility = default(_FeatureCompatibility);
		EventWaitHandle_FinishPulse = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		MissionPlannerErrorList = new List<MDSP_Error>();
		EventTriggers = new ObservableDictionary<string, EventTrigger>();
		EventConditions = new ObservableDictionary<string, EventCondition>();
		EventActions = new ObservableDictionary<string, EventAction>();
		SimEvents = new ObservableDictionary<string, SimEvent>();
		Explosions = new ObservableList<Explosion>();
		WeaponImpacts = new ObservableList<WeaponImpact>();
		WaterSplashes = new List<WaterSplash>();
		GroundImpacts = new List<GroundImpact>();
		UnguidedWeapons = new ObservableDictionary<string, UnguidedWeapon>();
		MineAllocation = new ObservableDictionary<string, UnguidedWeapon>();
		ChaffClouds = new List<ChaffCorridorCloud>();
		UnitAutodetectionValidation = new ConcurrentHashSet<Side>();
		_ActiveUnits_ListLockObj = RuntimeHelpers.GetObjectValue(new object());
		UnUsedObj = RuntimeHelpers.GetObjectValue(new object());
		DEBUG_CustomResolution = null;
		DEBUG_CustomCompression = null;
		HasBeenReleased = false;
		_AddUnitLockObj = RuntimeHelpers.GetObjectValue(new object());
		_AddRemoveUnitsLockObj = RuntimeHelpers.GetObjectValue(new object());
		writing = RuntimeHelpers.GetObjectValue(new object());
		_GetGuidedWeaponsLockObj = RuntimeHelpers.GetObjectValue(new object());
		_Locker_ActiveUnits_DictionaryChanged = RuntimeHelpers.GetObjectValue(new object());
		WeaponFeedBackMessage = new List<string>();
		_Time = DateAndTime.Now.ToUniversalTime();
		DBUsed = string_0;
		TimelineID = Guid.NewGuid().ToString();
		_ObjectID = Guid.NewGuid().ToString();
		ZeroHour = _Time;
	}

	public void MessageIncrement_Add1()
	{
		_MessageIncrement++;
	}

	private void InsertMsgsToMessageLogList()
	{
		CurrentlyInsertingMessages = true;
		while (_MessageLogQueue.Count > 0)
		{
			try
			{
				_MessageLogQueue.TryDequeue(out var result);
				if (result == null)
				{
					continue;
				}
				bool Local_AlreadyHaveMessage = false;
				Side Local_theNewM_Side = result.Side;
				DateTime Local_theNewM_TimeStamp = result.Timestamp;
				string Local_theNewM_Text = result.Text;
				List<LoggedMessage> messageLog = MessageLog;
				if (GameGeneral.DedupAlliedMessages && !RunningHeadless && Local_theNewM_Side != null)
				{
					try
					{
						Parallel.ForEach(messageLog, delegate(LoggedMessage theLM, ParallelLoopState loopstate)
						{
							if (theLM != null && theLM.Side != null && theLM.Side == Local_theNewM_Side && DateTime.Compare(theLM.Timestamp, Local_theNewM_TimeStamp) == 0 && string.CompareOrdinal(theLM.Text, Local_theNewM_Text) == 0)
							{
								Local_AlreadyHaveMessage = true;
								loopstate.Stop();
							}
						});
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				if (!GameGeneral.DedupAlliedMessages || !Local_AlreadyHaveMessage)
				{
					MessageLog.Add(result);
				}
				if (Local_theNewM_Side == null || !GameGeneral.DedupAlliedMessages)
				{
					continue;
				}
				LoggedMessage.MessageType type = result.Type;
				if ((int)(type - 1) > 1 && (int)(type - 6) > 1 && (int)(type - 19) > 3)
				{
					continue;
				}
				Side[] sides_ReadOnly = Sides_ReadOnly;
				Side[] array = sides_ReadOnly;
				foreach (Side Local_ASide in array)
				{
					if (Local_ASide == result.Side || result.Side.GetConsidersThisSideToBe(Local_ASide) != Misc.PostureStance.Friendly)
					{
						continue;
					}
					bool Local_AlreadyHaveMessage2 = false;
					if (!RunningHeadless)
					{
						try
						{
							Parallel.ForEach(messageLog, delegate(LoggedMessage theLM, ParallelLoopState loopstate)
							{
								if (theLM != null && theLM.Side != null && theLM.Side == Local_ASide && DateTime.Compare(theLM.Timestamp, Local_theNewM_TimeStamp) == 0 && string.CompareOrdinal(theLM.Text, Local_theNewM_Text) == 0)
								{
									Local_AlreadyHaveMessage2 = true;
									loopstate.Stop();
								}
							});
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
					}
					if (!Local_AlreadyHaveMessage2)
					{
						MessageIncrement_Add1();
						LoggedMessage item = new LoggedMessage(_MessageIncrement, result.Text, result.Summary, result.Type, result.Timestamp, result.ReporterID, result.Level, Local_ASide, result.Location);
						MessageLog.Add(item);
					}
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		CurrentlyInsertingMessages = false;
		EventWaitHandle_FinishPulse.Set();
	}

	public void AddMessage(LoggedMessage loggedMessage_0)
	{
		if (loggedMessage_0 == null)
		{
			return;
		}
		_OnNewMessageEvent?.Invoke(loggedMessage_0);
		if (SimConfiguration.DefaultGamePreferences.MessageLogSettings[loggedMessage_0.Type].ShowOnMessageLog)
		{
			_MessageLogQueue.Enqueue(loggedMessage_0);
			if (!CurrentlyInsertingMessages)
			{
				CurrentlyInsertingMessages = true;
				Task.Factory.StartNew(InsertMsgsToMessageLogList);
			}
		}
		if (SimConfiguration.DefaultGamePreferences.MessageLogSettings[loggedMessage_0.Type].PopUp)
		{
			UnhandledPopUpMessages.Enqueue(loggedMessage_0);
		}
		if (SimConfiguration.DefaultGamePreferences.MessageLogSettings[loggedMessage_0.Type].bool_0 && loggedMessage_0.Side == GetCurrentSide())
		{
			TimeCompression_Set(enumTimeCompression.OneSec);
		}
	}

	public void AddMessage(string string_0, string string_1, LoggedMessage.MessageType messageType_0, byte byte_0, string string_2, Side side_0 = null, Geopoint_Struct geopoint_Struct_0 = default(Geopoint_Struct), bool bool_0 = false)
	{
		try
		{
			if (messageType_0 != LoggedMessage.MessageType.UnguidedWeaponModifiers)
			{
				if (_MessageIncrement == long.MaxValue)
				{
					_MessageIncrement = 1L;
				}
				else
				{
					_MessageIncrement++;
				}
				LoggedMessage loggedMessage_ = new LoggedMessage(_MessageIncrement, string_0, string_1, messageType_0, _Time, string_2, byte_0, side_0, geopoint_Struct_0, bool_0);
				AddMessage(loggedMessage_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101031", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CleanUpExplosions()
	{
		try
		{
			List<Explosion> list = new List<Explosion>();
			foreach (Explosion explosion in Explosions)
			{
				if (explosion.HasExpired)
				{
					list.Add(explosion);
				}
			}
			foreach (Explosion item in list)
			{
				Explosions.Remove(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101032", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CleanUpWeaponImpacts()
	{
		try
		{
			List<WeaponImpact> list = new List<WeaponImpact>();
			foreach (WeaponImpact weaponImpact in WeaponImpacts)
			{
				if (weaponImpact.Age > 5f)
				{
					list.Add(weaponImpact);
				}
			}
			foreach (WeaponImpact item in list)
			{
				WeaponImpacts.Remove(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10324052394609", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ClearMessageLog()
	{
		MessageLog.Clear();
	}

	public void AddRemoveUnits()
	{
		object addRemoveUnitsLockObj = _AddRemoveUnitsLockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(addRemoveUnitsLockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(addRemoveUnitsLockObj, ref lockTaken);
			try
			{
				for (int i = _UnitAdditions.Count - 1; i >= 0; i += -1)
				{
					ActiveUnit activeUnit = _UnitAdditions[i];
					if (string.IsNullOrEmpty(activeUnit.ObjectID))
					{
						activeUnit.ResetIDs();
					}
					if (ActiveUnits.ContainsKey(activeUnit.ObjectID))
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						ActiveUnits.Add(activeUnit.ObjectID, activeUnit);
						_UnitAdditions.Remove(activeUnit);
					}
				}
				for (int j = _UnitRemovals.Count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit2 = _UnitRemovals[j];
					if (_UnitDeletions.Contains(activeUnit2))
					{
						_UnitDeletions.Remove(activeUnit2);
					}
					ActiveUnits.Remove(activeUnit2.ObjectID);
					_UnitRemovals.Remove(activeUnit2);
					activeUnit2.Destroy(bool_0: false, bool_1: false, bool_2: false, "Final removal");
				}
				for (int k = _UnitDeletions.Count - 1; k >= 0; k += -1)
				{
					ActiveUnit activeUnit3 = _UnitDeletions[k];
					activeUnit3.Destroy(bool_0: true, bool_1: false, bool_2: false, "Final removal");
					ActiveUnits.Remove(activeUnit3.ObjectID);
					_UnitDeletions.Remove(activeUnit3);
				}
				for (int l = list_0.Count - 1; l >= 0; l += -1)
				{
					UnguidedWeapon unguidedWeapon = list_0[l];
					UnguidedWeapons.Remove(unguidedWeapon.ObjectID);
					list_0.Remove(unguidedWeapon);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101033", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(addRemoveUnitsLockObj);
			}
		}
	}

	public void DeleteThisUnit(ActiveUnit activeUnit_0)
	{
		if (!_UnitDeletions.Contains(activeUnit_0))
		{
			_UnitDeletions.Add(activeUnit_0);
		}
	}

	public void DestroyThisUnit(ActiveUnit activeUnit_0, string string_0, string string_1 = null)
	{
		if (!_UnitRemovals.Contains(activeUnit_0))
		{
			_UnitRemovals.Add(activeUnit_0);
		}
		if (!activeUnit_0.IsGroup && (!activeUnit_0.IsShip || !((Ship)activeUnit_0).IsSinking))
		{
			if (activeUnit_0.IsActiveUnit)
			{
				activeUnit_0.Kinematics.ExportLocationEvent(bool_0: true);
			}
			ExportUnitDestructionEvent(activeUnit_0, string_0, string_1);
		}
	}

	public void DestroyThisUnguidedWeapon(UnguidedWeapon unguidedWeapon_0, string string_0, string string_1 = null)
	{
		if (!list_0.Contains(unguidedWeapon_0))
		{
			list_0.Add(unguidedWeapon_0);
		}
	}

	public void DeleteUnitImmediately(string string_0, bool bool_0, string string_1, string string_2 = null)
	{
		try
		{
			ActiveUnit activeUnit = null;
			UnguidedWeapon unit_ = null;
			if (ActiveUnits.TryGetValue(string_0, ref activeUnit))
			{
				if (!activeUnit.IsGroup)
				{
					if (activeUnit.IsActiveUnit)
					{
						activeUnit.Kinematics.ExportLocationEvent(bool_0: true);
					}
					ExportUnitDestructionEvent(activeUnit, string_1, string_2);
				}
				activeUnit.Destroy(bool_0, bool_1: false, bool_2: false, string_1);
			}
			else if (UnguidedWeapons.TryGetValue(string_0, ref unit_))
			{
				ExportUnitDestructionEvent(unit_, string_1, string_2);
				UnguidedWeapon unguidedWeapon = UnguidedWeapons[string_0];
				Scenario scenario_ = this;
				unguidedWeapon.DestroyMe(ref scenario_, string_1);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 300018", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void ExportUnitDamagedEvent(Module_Unit.Unit unit_0, string string_0, string string_1 = null)
	{
		string text = "-";
		string text2 = "-";
		string text3 = "-";
		string text4 = "0";
		if (string_1 != null)
		{
			text = string_1;
		}
		if (unit_0.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)unit_0;
			text4 = activeUnit.Damage.DamagePercent.ToString("F6");
			if (activeUnit.Damage.FireIntensity != 0)
			{
				text2 = activeUnit.Damage.FireIntensity.ToString();
			}
			if (activeUnit.Damage.FloodIntensity != 0)
			{
				text3 = activeUnit.Damage.FloodIntensity.ToString();
			}
		}
		foreach (IEventExporter applicableEventExporter in ApplicableEventExporters)
		{
			if (applicableEventExporter.IsOperating && applicableEventExporter.ExportUnitDamaged)
			{
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(Title, typeof(string), 500));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(TimelineID, typeof(string), 40));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(Time.Subtract(ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(unit_0.ObjectID, typeof(string), 40));
				dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(unit_0.Name, typeof(string), 500));
				dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(unit_0.UnitClass, typeof(string), 500));
				dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(unit_0.GetUnitSide().Name, typeof(string), 500));
				dictionary.Add("DamagePercent", new IEventExporter.EventNotificationParameter(text4, typeof(string), 10));
				dictionary.Add("Fire", new IEventExporter.EventNotificationParameter(text2, typeof(string)));
				dictionary.Add("Flooding", new IEventExporter.EventNotificationParameter(text3, typeof(string)));
				dictionary.Add("Reason", new IEventExporter.EventNotificationParameter(string_0, typeof(string)));
				dictionary.Add("Cause", new IEventExporter.EventNotificationParameter(text, typeof(string)));
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.UnitPositions_Destruction, dictionary, this);
			}
		}
	}

	internal void ExportUnitDestructionEvent(Module_Unit.Unit unit_0, string string_0, string string_1 = null)
	{
		string text = "-";
		if (string_1 != null)
		{
			text = string_1;
		}
		foreach (IEventExporter applicableEventExporter in ApplicableEventExporters)
		{
			if (applicableEventExporter.IsOperating && applicableEventExporter.ExportUnitDestroyed)
			{
				Dictionary<string, IEventExporter.EventNotificationParameter> dictionary = new Dictionary<string, IEventExporter.EventNotificationParameter>(30);
				if (MonteCarloIteration > 0)
				{
					dictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(Title, typeof(string), 500));
					dictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(MonteCarloIteration, typeof(int)));
				}
				dictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(TimelineID, typeof(string), 40));
				if (applicableEventExporter.UseZeroHour)
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(Time.Subtract(ZeroHour).ToString("c"), typeof(TimeSpan), 30));
				}
				else
				{
					dictionary.Add("Time", new IEventExporter.EventNotificationParameter(Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + Time.Millisecond.ToString("D3"), typeof(DateTime)));
				}
				dictionary.Add("UnitID", new IEventExporter.EventNotificationParameter(unit_0.ObjectID, typeof(string), 40));
				dictionary.Add("UnitName", new IEventExporter.EventNotificationParameter(unit_0.Name, typeof(string), 500));
				dictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(unit_0.UnitClass, typeof(string), 500));
				dictionary.Add("UnitSide", new IEventExporter.EventNotificationParameter(unit_0.GetUnitSide()?.Name, typeof(string), 500));
				dictionary.Add("MiscInfo", new IEventExporter.EventNotificationParameter(string.Empty, typeof(string)));
				dictionary.Add("Reason", new IEventExporter.EventNotificationParameter(string_0, typeof(string)));
				dictionary.Add("Cause", new IEventExporter.EventNotificationParameter(text, typeof(string)));
				applicableEventExporter.ExportEvent(IEventExporter.ExportedEventType.UnitDestroyed, dictionary, this);
			}
		}
		ISimConnector[] activeSimConnectors = SimConnect_General.ActiveSimConnectors;
		ISimConnector[] array = activeSimConnectors;
		foreach (ISimConnector simConnector in array)
		{
			if (simConnector.ExportUnitDestroyed && (simConnector.ConnectorType != ISimConnector.SimConnectorType.DIS || unit_0.RemoteSimEntityType != Module_Unit.Unit.RemoteSimEntityTypeEnum.DIS))
			{
				Dictionary<string, Tuple<Type, string>> dictionary2 = new Dictionary<string, Tuple<Type, string>>();
				dictionary2.Add("TimelineID", new Tuple<Type, string>(typeof(string), TimelineID));
				dictionary2.Add("Time", new Tuple<Type, string>(typeof(DateTime), Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + Time.Millisecond.ToString("D3")));
				dictionary2.Add("UnitID", new Tuple<Type, string>(typeof(string), unit_0.ObjectID));
				dictionary2.Add("UnitName", new Tuple<Type, string>(typeof(string), unit_0.Name));
				dictionary2.Add("UnitClass", new Tuple<Type, string>(typeof(string), unit_0.UnitClass));
				dictionary2.Add("UnitSide", new Tuple<Type, string>(typeof(string), unit_0.GetUnitSide().Name));
				dictionary2.Add("MiscInfo", new Tuple<Type, string>(typeof(string), ""));
				dictionary2.Add("Reason", new Tuple<Type, string>(typeof(string), string_0));
				simConnector.ExportInfo(ISimConnector.ExportedInfoType.UnitDestroyed, dictionary2, this);
			}
		}
	}

	public void AddThisUnit(ActiveUnit activeUnit_0)
	{
		object addUnitLockObj = _AddUnitLockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(addUnitLockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(addUnitLockObj, ref lockTaken);
			if (_UnitAdditions.Contains(activeUnit_0))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				_UnitAdditions.Add(activeUnit_0);
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(addUnitLockObj);
			}
		}
	}

	public void AddSide(Side side_0)
	{
		if (!_Sides.Contains(side_0))
		{
			ArrayExtensions.Add(ref _Sides, side_0);
			Scenario.SidesChanged?.Invoke(this, SideAdditionOrRemoval.Addition);
		}
	}

	public void RemoveSide(Side side_0)
	{
		ArrayExtensions.Remove(ref _Sides, side_0);
		Scenario.SidesChanged?.Invoke(this, SideAdditionOrRemoval.Removal);
	}

	public static void ChangeCurrentScenarioOnClient(Scenario scenario_0)
	{
		Scenario.CurrentScenarioChanged?.Invoke(scenario_0);
	}

	internal Aircraft AddNewAircraft(Side side_0, string string_0, double double_0, double double_1, int int_0, int int_1, float float_0, Module_Unit.Unit.RemoteSimEntityTypeEnum remoteSimEntityTypeEnum_0 = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string string_1 = null)
	{
		try
		{
			if (IsUnitExists(string_1))
			{
				throw new Exception("请求的自定义GUID已在此想定中使用");
			}
			Scenario scenario_ = this;
			Aircraft aircraft_ = new Aircraft(ref scenario_, string_1);
			scenario_ = this;
			DBFunctions.GetAircraft(ref scenario_, ref aircraft_, int_0);
			UnitsAutoIncrement++;
			aircraft_.Name = string_0;
			aircraft_.SetUnitSide(bool_0: false, side_0);
			if (int_1 > 0)
			{
				DBFunctions.GetLoadout(ref aircraft_, int_1, bool_0: false);
			}
			aircraft_.SetThrottle(ActiveUnit.Throttle.Loiter);
			aircraft_.Kinematics.DetermineReserveFuelQty();
			aircraft_.CurrentHeading = 0f;
			aircraft_.SetLatitude(null, double_1);
			aircraft_.SetLongitude(null, double_0);
			short elevation = Terrain.GetElevation(double_1, double_0, bool_0: false, this);
			if (float_0 < (float)(elevation + 1))
			{
				aircraft_.SetCurrentAltitude(bool_1: false, elevation + 1);
			}
			else
			{
				aircraft_.SetCurrentAltitude(bool_1: false, float_0);
			}
			aircraft_.CurrentSpeed = aircraft_.Kinematics.GetMaximumSpeed(float_0, ActiveUnit.Throttle.Loiter, bool_0: false);
			aircraft_.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
			aircraft_.SetDesiredHeading(ActiveUnit.TurnRate.Max, 0f);
			aircraft_.DesiredAltitude = aircraft_.GetCurrentAltitude();
			ActiveUnit activeUnit_ = aircraft_;
			scenario_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_);
			if (aircraft_.Loadout != null)
			{
				WeaponRec[] weapons = aircraft_.Loadout.Weapons;
				for (int i = 0; i < weapons.Length; i = checked(i + 1))
				{
					Weapon referenceWeapon = weapons[i].GetReferenceWeapon(aircraft_.ParentScen);
					referenceWeapon.SetLongitude(null, aircraft_.GetLongitude());
					referenceWeapon.SetLatitude(null, aircraft_.GetLatitude());
					referenceWeapon.SetCurrentAltitude(bool_0: false, aircraft_.GetCurrentAltitude());
					referenceWeapon.CurrentHeading = aircraft_.CurrentHeading;
					referenceWeapon.CurrentSpeed = aircraft_.CurrentSpeed;
				}
			}
			aircraft_.Kinematics.ExportLocationEvent(bool_0: true);
			return aircraft_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101034", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Satellite AddNewSatellite(Side side_0, string string_0, int int_0, int int_1, Module_Unit.Unit.RemoteSimEntityTypeEnum remoteSimEntityTypeEnum_0 = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string string_1 = null)
	{
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataSatellite", int_0, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			if (IsUnitExists(string_1))
			{
				throw new Exception("请求的自定义GUID已在此想定中使用");
			}
			Scenario scenario_ = this;
			Satellite satellite_ = new Satellite(ref scenario_, string_1);
			scenario_ = this;
			DBFunctions.GetSatellite(ref scenario_, ref satellite_, int_0, int_1);
			UnitsAutoIncrement++;
			satellite_.Kinematics.Move(1f, bool_0: false, bool_1: false, Time);
			Side[] sides_ReadOnly = Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side_ in array)
			{
				satellite_.SetIsAutoDetectable(side_, bool_0: true);
			}
			if (!string.IsNullOrEmpty(string_0))
			{
				satellite_.Name = string_0;
			}
			satellite_.SetUnitSide(bool_0: false, side_0);
			ActiveUnit activeUnit_ = satellite_;
			scenario_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_);
			satellite_.Kinematics.ExportLocationEvent(bool_0: true);
			return satellite_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101035", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Ship AddNewShip(Side side_0, int int_0, string string_0, double double_0, double double_1, bool bool_0 = false, Module_Unit.Unit.RemoteSimEntityTypeEnum remoteSimEntityTypeEnum_0 = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string string_1 = null)
	{
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataShip", int_0, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			if (IsUnitExists(string_1))
			{
				throw new Exception("请求的自定义GUID已在此想定中使用");
			}
			double num = Terrain.GetElevation(double_1, double_0, bool_0: false, this);
			if (!bool_0 && num > 0.0)
			{
				throw new Exception("你不能把船放在陆上！");
			}
			Scenario scenario_ = this;
			Ship ship_ = new Ship(ref scenario_, string_1);
			scenario_ = this;
			DBFunctions.GetShip(ref scenario_, ref ship_, int_0);
			UnitsAutoIncrement++;
			ship_.Name = string_0;
			ship_.SetUnitSide(bool_0: false, side_0);
			ship_.CurrentHeading = 0f;
			ship_.CurrentSpeed = 0f;
			ship_.SetLatitude(null, double_1);
			ship_.SetLongitude(null, double_0);
			ship_.DesiredSpeed = 0f;
			ship_.SetDesiredHeading(ActiveUnit.TurnRate.Max, 0f);
			ActiveUnit activeUnit_ = ship_;
			scenario_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_);
			ship_.Kinematics.ExportLocationEvent(bool_0: true);
			return ship_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101036", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Weapon AddNewWeapon(Side side_0, string string_0, double double_0, double double_1, int int_0, float float_0, Module_Unit.Unit.RemoteSimEntityTypeEnum remoteSimEntityTypeEnum_0 = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string string_1 = null)
	{
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataWeapon", int_0, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			if (IsUnitExists(string_1))
			{
				throw new Exception("请求的自定义GUID已在此想定中使用");
			}
			Scenario scenario_ = this;
			Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_, int_0, bool_0: false, string_1);
			UnitsAutoIncrement++;
			newWeapon.Name = string_0;
			newWeapon.SetUnitSide(bool_0: false, side_0);
			newWeapon.SetThrottle(ActiveUnit.Throttle.Cruise);
			newWeapon.CurrentHeading = 0f;
			newWeapon.CurrentSpeed = newWeapon.Kinematics.GetMaximumSpeed(float_0, ActiveUnit.Throttle.Cruise, bool_0: false);
			newWeapon.SetLatitude(null, double_1);
			newWeapon.SetLongitude(null, double_0);
			newWeapon.SetCurrentAltitude(bool_0: false, float_0);
			newWeapon.SetDesiredHeading(ActiveUnit.TurnRate.Max, 0f);
			newWeapon.DesiredAltitude = float_0;
			ActiveUnit activeUnit_ = newWeapon;
			scenario_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_);
			newWeapon.RemoteSimEntityType = remoteSimEntityTypeEnum_0;
			newWeapon.Kinematics.ExportLocationEvent(bool_0: true);
			return newWeapon;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10324958245687345897", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private bool IsUnitExists(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		foreach (ActiveUnit activeUnits_ in ActiveUnits_List)
		{
			if (activeUnits_ != null && Operators.CompareString(activeUnits_.ObjectID, string_0, TextCompare: false) == 0)
			{
				return true;
			}
		}
		return false;
	}

	internal Submarine AddNewSubmarine(Side side_0, int int_0, string string_0, double double_0, double double_1, bool bool_0 = false, Module_Unit.Unit.RemoteSimEntityTypeEnum remoteSimEntityTypeEnum_0 = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string string_1 = null)
	{
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataSubmarine", int_0, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			if (IsUnitExists(string_1))
			{
				throw new Exception("请求的自定义GUID已在此想定中使用");
			}
			double num = Terrain.GetElevation(double_1, double_0, bool_0: false, this);
			if (!bool_0 && num > 0.0)
			{
				throw new Exception("你不能把潜艇放在陆上！");
			}
			Scenario scenario_ = this;
			Submarine submarine_ = new Submarine(ref scenario_, string_1);
			scenario_ = this;
			DBFunctions.GetSubmarine(ref scenario_, ref submarine_, int_0);
			UnitsAutoIncrement++;
			submarine_.Name = string_0;
			submarine_.SetUnitSide(bool_0: false, side_0);
			submarine_.CurrentHeading = 0f;
			submarine_.CurrentSpeed = 0f;
			submarine_.SetCurrentAltitude(bool_0: false, Math.Max(-40f, submarine_.Kinematics.GetMinimumAltitude()));
			submarine_.SetLatitude(null, double_1);
			submarine_.SetLongitude(null, double_0);
			submarine_.DesiredSpeed = 0f;
			submarine_.SetDesiredHeading(ActiveUnit.TurnRate.Max, 0f);
			submarine_.DesiredAltitude = -20f;
			ActiveUnit activeUnit_ = submarine_;
			scenario_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_);
			submarine_.Kinematics.ExportLocationEvent(bool_0: true);
			return submarine_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101037", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Facility AddNewFacility(Side side_0, int int_0, string string_0, double double_0, double double_1, bool bool_0 = false, Module_Unit.Unit.RemoteSimEntityTypeEnum remoteSimEntityTypeEnum_0 = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string string_1 = null)
	{
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataFacility", int_0, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			if (IsUnitExists(string_1))
			{
				throw new Exception("请求的自定义GUID已在此想定中使用");
			}
			Scenario scenario_ = this;
			Facility facility_ = new Facility(ref scenario_, string_1);
			int elevation = Terrain.GetElevation(double_1, double_0, bool_0: false, this);
			scenario_ = this;
			DBFunctions.GetFacility(ref scenario_, ref facility_, int_0);
			if (facility_.IsFixedFacility)
			{
				facility_.SetIsAutoDetectable(null, bool_0: true);
			}
			facility_.Name = string_0;
			if (!bool_0 && elevation < 0)
			{
				Facility._FacilityCategory category = facility_.Category;
				if (category != Facility._FacilityCategory.Underwater && category != Facility._FacilityCategory.Water_Surface)
				{
					throw new Exception("尝试放置设施：" + facility_.Name + "（类别：" + facility_.UnitClass + " - DBID: " + Conversions.ToString(facility_.DBID) + "）坐标：维度：" + Conversions.ToString(double_1) + " - 经度：" + Conversions.ToString(double_0) + "。该点位于水下。中止放置！");
				}
			}
			UnitsAutoIncrement++;
			facility_.SetUnitSide(bool_0: false, side_0);
			facility_.CurrentHeading = 0f;
			facility_.CurrentSpeed = 0f;
			facility_.SetLatitude(null, double_1);
			facility_.SetLongitude(null, double_0);
			if (facility_.Category == Facility._FacilityCategory.Water_Surface)
			{
				facility_.SetCurrentAltitude(bool_0: false, 0f);
			}
			else
			{
				facility_.SetCurrentAltitude(bool_0: false, elevation);
			}
			facility_.DesiredSpeed = 0f;
			facility_.SetDesiredHeading(ActiveUnit.TurnRate.Max, 0f);
			ActiveUnit activeUnit_ = facility_;
			scenario_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_);
			facility_.Kinematics.ExportLocationEvent(bool_0: true);
			return facility_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101286", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal Vehicle AddNewVehicle(Side side_0, int int_0, string string_0, double double_0, double double_1, bool bool_0 = false, Module_Unit.Unit.RemoteSimEntityTypeEnum remoteSimEntityTypeEnum_0 = Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string string_1 = null)
	{
		try
		{
			if (IsUnitExists(string_1))
			{
				throw new Exception("请求的自定义GUID已在此想定中使用");
			}
			Scenario scenario_ = this;
			Vehicle vehicle_ = new Vehicle(ref scenario_, string_1);
			int elevation = Terrain.GetElevation(double_1, double_0, bool_0: false, this);
			scenario_ = this;
			DBFunctions.GetVehicle(ref scenario_, ref vehicle_, int_0);
			if (vehicle_.IsFixedFacility)
			{
				vehicle_.SetIsAutoDetectable(null, bool_0: true);
			}
			vehicle_.Name = string_0;
			if (!bool_0 && elevation < 0 && !vehicle_.IsOutOfFuel)
			{
				throw new Exception("Attempted to place vehicle: " + vehicle_.Name + "（类别：" + vehicle_.UnitClass + " - DBID: " + Conversions.ToString(vehicle_.DBID) + "）坐标：维度：" + Conversions.ToString(double_1) + " - 经度：" + Conversions.ToString(double_0) + " . This point appears to be on water. Placement aborted!");
			}
			UnitsAutoIncrement++;
			vehicle_.SetUnitSide(bool_0: false, side_0);
			vehicle_.CurrentHeading = 0f;
			vehicle_.CurrentSpeed = 0f;
			vehicle_.SetLatitude(null, double_1);
			vehicle_.SetLongitude(null, double_0);
			vehicle_.SetCurrentAltitude(bool_0: false, elevation);
			vehicle_.DesiredSpeed = 0f;
			vehicle_.SetDesiredHeading(ActiveUnit.TurnRate.Max, 0f);
			ActiveUnit activeUnit_ = vehicle_;
			scenario_ = this;
			GameGeneral.AddUnitToCollections(ref activeUnit_, ref scenario_);
			vehicle_.Kinematics.ExportLocationEvent(bool_0: true);
			return vehicle_;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101286", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	internal UnguidedWeapon AddNewMine(Side side_0, int int_0, List<ReferencePoint> list_1, ref string string_0)
	{
		try
		{
			if (DBFunctions.CheckObjectIsDeprecated("DataWeapon", int_0, DBConnection))
			{
				throw new Exception("The requested object has been deprecated in the database");
			}
			Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(list_1);
			if (!Information.IsNothing(geopoint_Struct) && !geopoint_Struct.HasZeroCoords)
			{
				UnguidedWeapon unguidedWeapon_ = new UnguidedWeapon(Cache_GetWeapon(int_0), null, null, 0.0, 0.0, 0L);
				if (unguidedWeapon_.IsMine)
				{
					unguidedWeapon_.SetUnitSide(bool_0: false, side_0);
					string text = UnguidedWeapon.CanLayMineHere(ref unguidedWeapon_, geopoint_Struct.Latitude, geopoint_Struct.Longitude, Terrain.GetElevation(geopoint_Struct.Latitude, geopoint_Struct.Longitude, bool_0: false, this), this);
					if (string.CompareOrdinal(text, "OK") == 0)
					{
						UnguidedWeapons.Add(unguidedWeapon_.ObjectID, unguidedWeapon_);
						return unguidedWeapon_;
					}
					string_0 = text;
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
			exception_?.Data.Add("Error at 101039", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	internal bool ExportUnitsToFile(string string_0, string string_1, string string_2, string string_3, Side side_0, Collection<ActiveUnit> collection_0)
	{
		ImportExportRecord importExportRecord = new ImportExportRecord();
		importExportRecord.Name = string_1;
		importExportRecord.Comments = string_2;
		new XmlWriterSettings
		{
			Indent = true,
			IndentChars = "    ",
			ConformanceLevel = ConformanceLevel.Auto
		};
		foreach (ActiveUnit item3 in collection_0.Where((ActiveUnit theU) => theU.IsActiveUnit).ToList())
		{
			if (item3.IsGroup)
			{
				ActiveUnit groupLead = ((Group)item3).GroupLead;
				ImportExportRecord.MemberRecord item = ExportUnitsToIER(groupLead);
				importExportRecord.MemberRecords.Add(item);
				foreach (ActiveUnit value in ((Group)item3).Units.Values)
				{
					if (!value.IsGroupLead())
					{
						item = ExportUnitsToIER(value);
						importExportRecord.MemberRecords.Add(item);
					}
				}
			}
			else
			{
				ImportExportRecord.MemberRecord item2 = ExportUnitsToIER(item3);
				importExportRecord.MemberRecords.Add(item2);
			}
		}
		StreamWriter streamWriter = new StreamWriter(string_0);
		JsonSerializer val = new JsonSerializer();
		using (streamWriter)
		{
			JsonTextWriter val2 = new JsonTextWriter(streamWriter);
			val2.Formatting = Newtonsoft.Json.Formatting.Indented;
			using (val2)
			{
				val.Serialize(val2, importExportRecord);
			}
		}
		return true;
	}

	internal ImportExportRecord.MemberRecord ExportUnitsToIER(ActiveUnit activeUnit_0)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "    ";
		xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
		int int_ = 0;
		ImportExportRecord.MemberRecord memberRecord_ = new ImportExportRecord.MemberRecord();
		memberRecord_.Member_DBID = activeUnit_0.DBID;
		memberRecord_.Member_GUID = activeUnit_0.ObjectID;
		switch (activeUnit_0.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			memberRecord_.MemberType = "Aircraft";
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			memberRecord_.MemberType = "Ship";
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			memberRecord_.MemberType = "Submarine";
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			memberRecord_.MemberType = "Facility";
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			memberRecord_.MemberType = "Weapon";
			break;
		case GlobalVariables.ActiveUnitType.Vehicle:
			memberRecord_.MemberType = "Vehicle";
			break;
		}
		memberRecord_.Orientation = activeUnit_0.CurrentHeading;
		memberRecord_.Longitude = activeUnit_0.GetLongitude();
		memberRecord_.Latitude = activeUnit_0.GetLatitude();
		memberRecord_.MemberName = activeUnit_0.Name;
		memberRecord_.Altitude = activeUnit_0.GetCurrentAltitude();
		memberRecord_.Speed = activeUnit_0.CurrentSpeed;
		if ((object)activeUnit_0.GetType() == typeof(Aircraft))
		{
			if (Information.IsNothing(((Aircraft)activeUnit_0).Loadout))
			{
				memberRecord_.LoadoutID = 0;
			}
			else
			{
				memberRecord_.LoadoutID = ((Aircraft)activeUnit_0).Loadout.DBID;
			}
		}
		if (activeUnit_0.IsGroupMember())
		{
			memberRecord_.ParentGroupName = activeUnit_0.GetParentGroup().Name;
			memberRecord_.ParentGroupGUID = activeUnit_0.GetParentGroup().ObjectID;
		}
		if (activeUnit_0.GetParentGroup() != null)
		{
			ActiveUnit groupLead = activeUnit_0.GetParentGroup().GroupLead;
			memberRecord_.FormationStationPoint = activeUnit_0.Navigator.UnitFormationStation;
			Tuple<double, double> latitudeAndLongitude = activeUnit_0.Navigator.UnitFormationStation.GetLatitudeAndLongitude(activeUnit_0, groupLead);
			memberRecord_.FormationLongitude = latitudeAndLongitude.Item1;
			memberRecord_.FormationLatitude = latitudeAndLongitude.Item2;
			if (activeUnit_0.IsGroupLead())
			{
				memberRecord_.LastFormationSet = activeUnit_0.GetParentGroup().LastFormationSet;
				memberRecord_.LastFormationSpacing = activeUnit_0.GetParentGroup().LastFormationSpacing;
				memberRecord_.LastFormationSpacingUnits = activeUnit_0.GetParentGroup().LastFormationSpacingUnits;
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
		{
			xmlWriter.WriteStartElement("DeltaUnit");
			StreamWriter streamWriter_ = null;
			SBR.GenerateDeltaFragmentForThisUnit(activeUnit_0, activeUnit_0.ParentScen, xmlWriter, streamWriter_, ref int_);
			xmlWriter.WriteEndElement();
			xmlWriter.Flush();
		}
		if (Operators.CompareString(Misc.AssetRequest(memoryStream), "<DeltaUnit />", TextCompare: false) != 0)
		{
			memberRecord_.Member_SBR = Misc.AssetRequest(memoryStream);
		}
		SaveHostedAircraft(ref activeUnit_0, ref memberRecord_);
		SaveDockedBoats(ref activeUnit_0, ref memberRecord_);
		return memberRecord_;
	}

	internal void SaveHostedAircraft(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly.Count <= 0)
		{
			return;
		}
		foreach (Aircraft item in activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly)
		{
			ImportExportRecord.HostedAircraftRecord hostedAircraftRecord = new ImportExportRecord.HostedAircraftRecord(item.Name, item.DBID, (item.Loadout != null) ? item.Int32_0 : 0, (int)Math.Round(item.AirOps.ConditionTimer / 60f));
			hostedAircraftRecord.Member = ExportUnitsToIER(item);
			memberRecord_0.HostedAircraftRecords.Add(hostedAircraftRecord);
		}
	}

	internal void SaveDockedBoats(ref ActiveUnit activeUnit_0, ref ImportExportRecord.MemberRecord memberRecord_0)
	{
		if (activeUnit_0.DockingOps.EmbarkedBoats.Count <= 0)
		{
			return;
		}
		foreach (ActiveUnit embarkedBoat in activeUnit_0.DockingOps.EmbarkedBoats)
		{
			ImportExportRecord.EmbarkedBoatRecord embarkedBoatRecord = new ImportExportRecord.EmbarkedBoatRecord(embarkedBoat.Name, embarkedBoat.DBID, (int)Math.Round(embarkedBoat.DockingOps.ConditionTimer / 60f), embarkedBoat.UnitType_String);
			embarkedBoatRecord.Member = ExportUnitsToIER(embarkedBoat);
			memberRecord_0.EmbarkedBoatRecords.Add(embarkedBoatRecord);
		}
	}

	internal List<ActiveUnit> ImportUnitsFromFile(string string_0, Side side_0)
	{
		try
		{
			StreamReader streamReader = new StreamReader(string_0);
			List<ActiveUnit> list_ = new List<ActiveUnit>();
			new List<string>();
			ImportExportRecord importExportRecord;
			using (streamReader)
			{
				importExportRecord = (ImportExportRecord)JsonConvert.DeserializeObject(streamReader.ReadToEnd(), typeof(ImportExportRecord));
			}
			foreach (ImportExportRecord.MemberRecord memberRecord in importExportRecord.MemberRecords)
			{
				try
				{
					ImportMemberRecord(memberRecord, ref list_, ref side_0, importExportRecord.Template);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 200054", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			List<Group> list = new List<Group>();
			foreach (ActiveUnit item in side_0.Units.ToList())
			{
				if (item.IsGroup && ((Group)item).Units.Count < 2)
				{
					list.Add((Group)item);
				}
			}
			foreach (Group item2 in list)
			{
				DeleteUnitImmediately(item2.ObjectID, bool_0: true, "Group dissolving");
			}
			return list_;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101040", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<ActiveUnit> result = new List<ActiveUnit>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void ImportMemberRecord(ImportExportRecord.MemberRecord memberRecord_0, ref List<ActiveUnit> list_1, ref Side side_0, bool bool_0 = false)
	{
		XmlDocument xmlDocument = new XmlDocument();
		if (Information.IsNothing(memberRecord_0.MemberType))
		{
			Facility facility = AddNewFacility(side_0, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
			facility.CurrentHeading = memberRecord_0.Orientation;
			list_1.Add(facility);
			ActiveUnit activeUnit_ = facility;
			ImportGroupMemberRecord(ref memberRecord_0, ref side_0, ref activeUnit_);
			return;
		}
		if (!Information.IsNothing(memberRecord_0.Member_SBR) && memberRecord_0.Member_SBR.Length > 0)
		{
			xmlDocument.LoadXml(memberRecord_0.Member_SBR);
		}
		if (bool_0)
		{
			memberRecord_0.Member_GUID = "";
		}
		ActiveUnit_Navigator.FormationStation formationStationPoint = memberRecord_0.FormationStationPoint;
		double formationLatitude = memberRecord_0.FormationLatitude;
		double formationLongitude = memberRecord_0.FormationLongitude;
		string lastFormationSet = memberRecord_0.LastFormationSet;
		float lastFormationSpacing = memberRecord_0.LastFormationSpacing;
		byte lastFormationSpacingUnits = memberRecord_0.LastFormationSpacingUnits;
		switch (memberRecord_0.MemberType)
		{
		case "Ship":
		case "Command_Core.Ship":
		{
			Ship ship = AddNewShip(side_0, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
			ship.CurrentHeading = memberRecord_0.Orientation;
			ship.SetDesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
			ship.SetCurrentAltitude(bool_0: false, (float)memberRecord_0.Altitude);
			ship.CurrentSpeed = (float)memberRecord_0.Speed;
			ActiveUnit activeUnit_4;
			if (bool_0)
			{
				activeUnit_4 = ship;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_4);
			}
			else
			{
				activeUnit_4 = null;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_4);
			}
			activeUnit_4 = ship;
			ImportHostedAircraftRecords(ref activeUnit_4, side_0, ref memberRecord_0, bool_0);
			activeUnit_4 = ship;
			ImportEmbarkedBoatRecords(ref activeUnit_4, side_0, ref memberRecord_0, bool_0);
			list_1.Add(ship);
			activeUnit_4 = ship;
			ImportGroupMemberRecord(ref memberRecord_0, ref side_0, ref activeUnit_4);
			if (ship.GetParentGroup() != null)
			{
				ship.Navigator.UnitFormationStation = formationStationPoint;
				ship.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
				if (ship.IsGroupLead())
				{
					ship.GetParentGroup().LastFormationSet = lastFormationSet;
					ship.GetParentGroup().LastFormationSpacing = lastFormationSpacing;
					ship.GetParentGroup().LastFormationSpacingUnits = lastFormationSpacingUnits;
				}
			}
			break;
		}
		case "地面单元":
		case "Command_Core.Ground Unit":
		case "Command_Core.GroundUnit":
		case "Command_Core.Vehicle":
		case "Vehicle":
		case "GroundUnit":
		{
			Vehicle vehicle = AddNewVehicle(side_0, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
			vehicle.CurrentHeading = memberRecord_0.Orientation;
			vehicle.SetDesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
			vehicle.SetCurrentAltitude(bool_0: false, (float)memberRecord_0.Altitude);
			vehicle.CurrentSpeed = (float)memberRecord_0.Speed;
			ActiveUnit activeUnit_5;
			if (bool_0)
			{
				activeUnit_5 = vehicle;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_5);
			}
			else
			{
				activeUnit_5 = null;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_5);
			}
			activeUnit_5 = vehicle;
			ImportHostedAircraftRecords(ref activeUnit_5, side_0, ref memberRecord_0, bool_0);
			activeUnit_5 = vehicle;
			ImportEmbarkedBoatRecords(ref activeUnit_5, side_0, ref memberRecord_0, bool_0);
			list_1.Add(vehicle);
			activeUnit_5 = vehicle;
			ImportGroupMemberRecord(ref memberRecord_0, ref side_0, ref activeUnit_5);
			if (vehicle.GetParentGroup() != null)
			{
				vehicle.Navigator.UnitFormationStation = formationStationPoint;
				vehicle.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
				if (vehicle.IsGroupLead())
				{
					vehicle.GetParentGroup().LastFormationSet = lastFormationSet;
					vehicle.GetParentGroup().LastFormationSpacing = lastFormationSpacing;
					vehicle.GetParentGroup().LastFormationSpacingUnits = lastFormationSpacingUnits;
				}
			}
			break;
		}
		case "Submarine":
		case "Command_Core.Submarine":
		{
			Submarine submarine = AddNewSubmarine(side_0, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
			submarine.CurrentHeading = memberRecord_0.Orientation;
			submarine.SetDesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
			submarine.SetCurrentAltitude(bool_0: false, (float)memberRecord_0.Altitude);
			submarine.CurrentSpeed = (float)memberRecord_0.Speed;
			ActiveUnit activeUnit_6;
			if (bool_0)
			{
				activeUnit_6 = submarine;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_6);
			}
			else
			{
				activeUnit_6 = null;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_6);
			}
			activeUnit_6 = submarine;
			ImportHostedAircraftRecords(ref activeUnit_6, side_0, ref memberRecord_0, bool_0);
			activeUnit_6 = submarine;
			ImportEmbarkedBoatRecords(ref activeUnit_6, side_0, ref memberRecord_0, bool_0);
			list_1.Add(submarine);
			activeUnit_6 = submarine;
			ImportGroupMemberRecord(ref memberRecord_0, ref side_0, ref activeUnit_6);
			if (submarine.GetParentGroup() != null)
			{
				submarine.Navigator.UnitFormationStation = formationStationPoint;
				submarine.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
				if (submarine.IsGroupLead())
				{
					submarine.GetParentGroup().LastFormationSet = lastFormationSet;
					submarine.GetParentGroup().LastFormationSpacing = lastFormationSpacing;
					submarine.GetParentGroup().LastFormationSpacingUnits = lastFormationSpacingUnits;
				}
			}
			break;
		}
		case "Command_Core.Aircraft":
		case "Aircraft":
		{
			Aircraft aircraft = AddNewAircraft(side_0, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, memberRecord_0.Member_DBID, memberRecord_0.LoadoutID, (float)memberRecord_0.Altitude, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
			aircraft.CurrentHeading = memberRecord_0.Orientation;
			aircraft.SetDesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
			aircraft.SetCurrentAltitude(bool_1: false, (float)memberRecord_0.Altitude);
			aircraft.CurrentSpeed = (float)memberRecord_0.Speed;
			ActiveUnit activeUnit_3;
			if (bool_0)
			{
				activeUnit_3 = aircraft;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_3);
			}
			else
			{
				activeUnit_3 = null;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_3);
			}
			activeUnit_3 = aircraft;
			ImportHostedAircraftRecords(ref activeUnit_3, side_0, ref memberRecord_0, bool_0);
			list_1.Add(aircraft);
			activeUnit_3 = aircraft;
			ImportGroupMemberRecord(ref memberRecord_0, ref side_0, ref activeUnit_3);
			if (aircraft.GetParentGroup() != null)
			{
				aircraft.Navigator.UnitFormationStation = formationStationPoint;
				aircraft.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
				if (aircraft.IsGroupLead())
				{
					aircraft.GetParentGroup().LastFormationSet = lastFormationSet;
					aircraft.GetParentGroup().LastFormationSpacing = lastFormationSpacing;
					aircraft.GetParentGroup().LastFormationSpacingUnits = lastFormationSpacingUnits;
				}
			}
			break;
		}
		case "Facility":
		case "Command_Core.Facility":
		{
			Facility facility2 = AddNewFacility(side_0, memberRecord_0.Member_DBID, memberRecord_0.MemberName, memberRecord_0.Longitude, memberRecord_0.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, memberRecord_0.Member_GUID);
			facility2.SetDesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
			facility2.CurrentHeading = memberRecord_0.Orientation;
			facility2.SetCurrentAltitude(bool_0: false, (float)memberRecord_0.Altitude);
			facility2.CurrentSpeed = (float)memberRecord_0.Speed;
			ActiveUnit activeUnit_2;
			if (bool_0)
			{
				activeUnit_2 = facility2;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_2);
			}
			else
			{
				activeUnit_2 = null;
				SBR.ProcessUnit(this, xmlDocument, ref activeUnit_2);
			}
			activeUnit_2 = facility2;
			ImportHostedAircraftRecords(ref activeUnit_2, side_0, ref memberRecord_0, bool_0);
			activeUnit_2 = facility2;
			ImportEmbarkedBoatRecords(ref activeUnit_2, side_0, ref memberRecord_0, bool_0);
			list_1.Add(facility2);
			activeUnit_2 = facility2;
			ImportGroupMemberRecord(ref memberRecord_0, ref side_0, ref activeUnit_2);
			if (facility2.GetParentGroup() != null)
			{
				facility2.Navigator.UnitFormationStation = formationStationPoint;
				facility2.AI.NavDestination = new Geopoint_Struct(formationLongitude, formationLatitude);
				if (facility2.IsGroupLead())
				{
					facility2.GetParentGroup().LastFormationSet = lastFormationSet;
					facility2.GetParentGroup().LastFormationSpacing = lastFormationSpacing;
					facility2.GetParentGroup().LastFormationSpacingUnits = lastFormationSpacingUnits;
				}
			}
			break;
		}
		}
	}

	private void ImportHostedAircraftRecords(ref ActiveUnit activeUnit_0, Side side_0, ref ImportExportRecord.MemberRecord memberRecord_0, bool bool_0)
	{
		if (Information.IsNothing(memberRecord_0.HostedAircraftRecords) || memberRecord_0.HostedAircraftRecords.Count == 0)
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			foreach (ImportExportRecord.HostedAircraftRecord hostedAircraftRecord in memberRecord_0.HostedAircraftRecords)
			{
				if (bool_0 && hostedAircraftRecord.Member != null)
				{
					hostedAircraftRecord.Member.Member_GUID = "";
				}
				Aircraft aircraft = AddNewAircraft(side_0, hostedAircraftRecord.Name, memberRecord_0.Longitude, memberRecord_0.Latitude, hostedAircraftRecord.AC_DBID, hostedAircraftRecord.Loadout_ID, 0f, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, hostedAircraftRecord.Member?.Member_GUID);
				aircraft.CurrentHeading = memberRecord_0.Orientation;
				aircraft.SetDesiredHeading(ActiveUnit.TurnRate.Max, memberRecord_0.Orientation);
				if (hostedAircraftRecord.Member?.Member_SBR != null && hostedAircraftRecord.Member.Member_SBR.Length > 0)
				{
					xmlDocument.LoadXml(hostedAircraftRecord.Member.Member_SBR);
					if (bool_0)
					{
						ActiveUnit activeUnit_ = aircraft;
						SBR.ProcessUnit(this, xmlDocument, ref activeUnit_);
					}
					else
					{
						ActiveUnit activeUnit_2 = null;
						SBR.ProcessUnit(this, xmlDocument, ref activeUnit_2);
					}
				}
				activeUnit_0.AirOps.AddThisAircraft(aircraft, bool_0: false);
				if (hostedAircraftRecord.ReadyTime_Mins > 0)
				{
					aircraft.AirOps.ConditionTimer = hostedAircraftRecord.ReadyTime_Mins * 60;
				}
				if (aircraft.AirOps.ConditionTimer > 0f)
				{
					aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101041", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ImportEmbarkedBoatRecords(ref ActiveUnit activeUnit_0, Side side_0, ref ImportExportRecord.MemberRecord memberRecord_0, bool bool_0)
	{
		if (Information.IsNothing(memberRecord_0.EmbarkedBoatRecords) || memberRecord_0.EmbarkedBoatRecords.Count == 0)
		{
			return;
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			foreach (ImportExportRecord.EmbarkedBoatRecord embarkedBoatRecord in memberRecord_0.EmbarkedBoatRecords)
			{
				if (bool_0 && embarkedBoatRecord.Member != null)
				{
					embarkedBoatRecord.Member.Member_GUID = "";
				}
				ActiveUnit activeUnit = null;
				if (Operators.CompareString(embarkedBoatRecord.Type, "Ship", TextCompare: false) == 0)
				{
					activeUnit = AddNewShip(side_0, embarkedBoatRecord.Boat_DBID, embarkedBoatRecord.Name, 0.0, 0.0);
				}
				else if (Operators.CompareString(embarkedBoatRecord.Type, "Submarine", TextCompare: false) == 0)
				{
					activeUnit = AddNewSubmarine(side_0, embarkedBoatRecord.Boat_DBID, embarkedBoatRecord.Name, 0.0, 0.0);
				}
				if (activeUnit == null)
				{
					continue;
				}
				if (embarkedBoatRecord.Member?.Member_SBR != null && embarkedBoatRecord.Member.Member_SBR.Length > 0)
				{
					xmlDocument.LoadXml(embarkedBoatRecord.Member.Member_SBR);
					if (bool_0)
					{
						ActiveUnit activeUnit_ = activeUnit;
						SBR.ProcessUnit(this, xmlDocument, ref activeUnit_);
					}
					else
					{
						ActiveUnit activeUnit_2 = null;
						SBR.ProcessUnit(this, xmlDocument, ref activeUnit_2);
					}
				}
				activeUnit_0.DockingOps.AddThisBoat(activeUnit);
				if (embarkedBoatRecord.ReadyTime_Mins > 0)
				{
					activeUnit.DockingOps.ConditionTimer = embarkedBoatRecord.ReadyTime_Mins * 60;
				}
				if (activeUnit.DockingOps.ConditionTimer > 0f)
				{
					activeUnit.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101041", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ImportGroupMemberRecord(ref ImportExportRecord.MemberRecord memberRecord_0, ref Side side_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			if (!Information.IsNothing(memberRecord_0.ParentGroupName))
			{
				if (Misc.ContainsByName(Groups, memberRecord_0.ParentGroupName))
				{
					activeUnit_0.SetParentGroup(bool_0: false, Misc.GetByName(Groups, memberRecord_0.ParentGroupName));
					return;
				}
				List<ActiveUnit> list = new List<ActiveUnit>();
				list.Add(activeUnit_0);
				Scenario scenario_ = this;
				new Group(ref scenario_, ref side_0, list).Name = memberRecord_0.ParentGroupName;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101042", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CheckForDestroyEvents(ActiveUnit activeUnit_0, float float_0)
	{
		try
		{
			if (activeUnit_0.IsGroup)
			{
				return;
			}
			List<EventTrigger> list = new List<EventTrigger>();
			foreach (EventTrigger value in EventTriggers.Values)
			{
				if (value.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value).GetIsFulfilled(activeUnit_0))
				{
					list.Add(value);
				}
			}
			foreach (EventTrigger value2 in EventTriggers.Values)
			{
				if (value2.Type == EventTrigger.EventTriggerType.UnitDamaged && (float)(int)((EventTrigger_UnitDamaged)value2).DamagePercent > activeUnit_0.utilsVal && ((EventTrigger_UnitDamaged)value2).GetIsFulfilled(activeUnit_0, float_0, 101f))
				{
					list.Add(value2);
				}
			}
			FireEvents(list);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101043", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Weapon Cache_GetWeapon(int int_0)
	{
		if (int_0 == -1)
		{
			return null;
		}
		Weapon value = null;
		if (!Cache_Weapons.TryGetValue(int_0, out value))
		{
			Scenario scenario_ = this;
			value = Weapon.GetNewWeapon(ref scenario_, int_0, bool_0: false);
			Cache_Weapons.TryAdd(int_0, value);
		}
		return value;
	}

	public Sensor Cache_GetSensor(int int_0)
	{
		Sensor value = null;
		if (!Cache_Sensors.TryGetValue(int_0, out value))
		{
			SQLiteConnection sqliteConnection_ = DBConnection;
			value = DBFunctions.GetSensor(int_0, ref sqliteConnection_);
			Cache_Sensors.TryAdd(int_0, value);
		}
		return value;
	}

	private void ActiveUnits_DictionaryChanged(object sender, NotifyDictionaryChangedEventArgs<string, ActiveUnit> e)
	{
		object locker_ActiveUnits_DictionaryChanged = _Locker_ActiveUnits_DictionaryChanged;
		ObjectFlowControl.CheckForSyncLockOnValueType(locker_ActiveUnits_DictionaryChanged);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(locker_ActiveUnits_DictionaryChanged, ref lockTaken);
			try
			{
				Cache_ActiveUnits_List = null;
				Side[] sides_ReadOnly = Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
				{
					sides_ReadOnly[i].SetFriendlyUnits(this, null);
				}
				switch (e.Action)
				{
				case NotifyCollectionChangedAction.Remove:
					Scenario.UnitRemoved?.Invoke(this, e.OldItem.Value);
					if (e.OldItem.Value.GetUnitSide() != null)
					{
						e.OldItem.Value.GetUnitSide().Units.Remove(e.OldItem.Value);
					}
					break;
				case NotifyCollectionChangedAction.Add:
					if (!Information.IsNothing(e.NewItem.Value.GetUnitSide()) && !e.NewItem.Value.GetUnitSide().Units.Contains(e.NewItem.Value))
					{
						e.NewItem.Value.GetUnitSide().Units.Add(e.NewItem.Value);
						Scenario.UnitAdded?.Invoke(this, e.NewItem.Value.ObjectID);
					}
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200568", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(locker_ActiveUnits_DictionaryChanged);
			}
		}
	}

	private void UnguidedWeapons_DictionaryChanged(object sender, NotifyDictionaryChangedEventArgs<string, UnguidedWeapon> e)
	{
		try
		{
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				Side[] sides_ReadOnly = Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
				{
					sides_ReadOnly[i].Contacts_NonAU.Remove(e.OldItem.Key);
				}
			}
			if (Mines == null)
			{
				Mines = new List<UnguidedWeapon>();
			}
			if (e.Action != 0)
			{
				return;
			}
			foreach (KeyValuePair<string, UnguidedWeapon> newItem in e.NewItems)
			{
				if (newItem.Value.IsMine)
				{
					Mines.Add(newItem.Value);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101045", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void EventTriggers_DictionaryChanged(object sender, NotifyDictionaryChangedEventArgs<string, EventTrigger> e)
	{
		Scenario.EventTriggersChanged?.Invoke(this);
	}

	private void EventConditions_DictionaryChanged(object sender, NotifyDictionaryChangedEventArgs<string, EventCondition> e)
	{
		Scenario.EventConditionsChanged?.Invoke(this);
	}

	private void EventActions_DictionaryChanged(object sender, NotifyDictionaryChangedEventArgs<string, EventAction> e)
	{
		Scenario.EventActionsChanged?.Invoke(this);
	}

	public void OnUnitSideChanged(string string_0, string string_1)
	{
		_UnitSideChangedEvent?.Invoke(this, string_0, string_1);
	}

	private void SaveMessageLog(XmlWriter xmlWriter_0)
	{
		try
		{
			xmlWriter_0.WriteRaw("<MessageLog>");
			foreach (LoggedMessage item in MessageLog.ToList())
			{
				try
				{
					if (item != null && Sides_ReadOnly.Contains(item.Side))
					{
						xmlWriter_0.WriteRaw(item.ToXML());
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			xmlWriter_0.WriteRaw("</MessageLog>");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			xmlWriter_0.WriteRaw("</MessageLog>");
			exception_?.Data.Add("Error at 101046", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ScenAttachments_DictionaryChanged(object sender, NotifyDictionaryChangedEventArgs<string, ScenAttachmentObject> e)
	{
		_ScenAttachmentsChangedEvent?.Invoke();
	}

	private void UpdateMissionFlightSize()
	{
		Side[] sides_ReadOnly = Sides_ReadOnly;
		Mission._FlightSize flightSize = default(Mission._FlightSize);
		Side[] array = sides_ReadOnly;
		Side[] array2 = array;
		foreach (Side side in array2)
		{
			if (Information.IsNothing(side.Missions))
			{
				continue;
			}
			foreach (Mission item in side.GetMissionsTotal(this))
			{
				if (Information.IsNothing(item))
				{
					continue;
				}
				int num = 99;
				switch (item.MissionClass)
				{
				case Mission._MissionClass.Strike:
					flightSize = ((Strike)item).FlightSize;
					break;
				case Mission._MissionClass.Patrol:
					flightSize = ((Patrol)item).FlightSize;
					break;
				case Mission._MissionClass.Support:
					flightSize = ((SupportMission)item).FlightSize;
					break;
				case Mission._MissionClass.Ferry:
					flightSize = ((FerryMission)item).FlightSize;
					break;
				case Mission._MissionClass.Mining:
					flightSize = ((MiningMission)item).FlightSize;
					break;
				case Mission._MissionClass.MineClearing:
					flightSize = ((MineClearingMission)item).FlightSize;
					break;
				case Mission._MissionClass.Escort:
					flightSize = ((EscortMission)item).FlightSize;
					break;
				}
				if (!(flightSize == 0))
				{
					continue;
				}
				Scenario scenario_ = this;
				foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item3 in item.InvokeValue(ref scenario_, bool_0: false, bool_1: false))
				{
					foreach (KeyValuePair<string, Dictionary<string, int>> item4 in item3.Value)
					{
						foreach (KeyValuePair<string, int> item2 in item4.Value)
						{
							if (item2.Value < num)
							{
								num = item2.Value;
							}
						}
					}
				}
				switch (item.MissionClass)
				{
				case Mission._MissionClass.Strike:
				{
					Strike strike = (Strike)item;
					switch (strike.Type)
					{
					default:
						if (num == 1)
						{
							strike.FlightSize = 1;
						}
						else if (num == 2)
						{
							strike.FlightSize = 2;
						}
						else if (num == 3)
						{
							strike.FlightSize = 3;
						}
						else if (num <= 5)
						{
							strike.FlightSize = 4;
						}
						else if (num <= 7)
						{
							strike.FlightSize = 6;
						}
						else
						{
							strike.FlightSize = 4;
						}
						break;
					case Strike.StrikeType.Sub_Strike:
						strike.FlightSize = 1;
						break;
					case Strike.StrikeType.Air_Intercept:
						if (num == 1)
						{
							strike.FlightSize = 1;
						}
						else
						{
							strike.FlightSize = 2;
						}
						break;
					}
					break;
				}
				case Mission._MissionClass.Patrol:
				{
					Patrol patrol = (Patrol)item;
					switch (patrol.Type)
					{
					case GlobalVariables.PatrolType.ASW:
						patrol.FlightSize = 1;
						break;
					default:
						patrol.FlightSize = 1;
						break;
					case GlobalVariables.PatrolType.AAW:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					case GlobalVariables.PatrolType.ASuW_Land:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					case GlobalVariables.PatrolType.ASuW_Mixed:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					case GlobalVariables.PatrolType.SEAD:
						if (num == 1)
						{
							patrol.FlightSize = 1;
						}
						else
						{
							patrol.FlightSize = 2;
						}
						break;
					}
					break;
				}
				case Mission._MissionClass.Support:
					((SupportMission)item).FlightSize = 1;
					break;
				case Mission._MissionClass.Ferry:
				{
					FerryMission ferryMission = (FerryMission)item;
					if (num == 1)
					{
						ferryMission.FlightSize = 1;
					}
					else if (num == 2)
					{
						ferryMission.FlightSize = 2;
					}
					else if (num == 3)
					{
						ferryMission.FlightSize = 3;
					}
					else if (num <= 5)
					{
						ferryMission.FlightSize = 4;
					}
					else if (num <= 7)
					{
						ferryMission.FlightSize = 6;
					}
					else
					{
						ferryMission.FlightSize = 4;
					}
					break;
				}
				case Mission._MissionClass.Mining:
				{
					MiningMission miningMission = (MiningMission)item;
					if (num == 1)
					{
						miningMission.FlightSize = 1;
					}
					else if (num == 2)
					{
						miningMission.FlightSize = 2;
					}
					else if (num == 3)
					{
						miningMission.FlightSize = 3;
					}
					else if (num <= 5)
					{
						miningMission.FlightSize = 4;
					}
					else if (num <= 7)
					{
						miningMission.FlightSize = 6;
					}
					else
					{
						miningMission.FlightSize = 4;
					}
					break;
				}
				case Mission._MissionClass.MineClearing:
					((MineClearingMission)item).FlightSize = 1;
					break;
				case Mission._MissionClass.Escort:
					flightSize = ((EscortMission)item).FlightSize;
					break;
				}
			}
		}
	}

	internal List<string> CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref Side side_0, ref Mission mission_0)
	{
		List<string> list = new List<string>();
		if (!Information.IsNothing(this) && !Information.IsNothing(mission_0))
		{
			bool flag = false;
			bool flag2 = false;
			try
			{
				Mission obj = mission_0;
				Scenario scenario_ = this;
				Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary = obj.InvokeValue(ref scenario_, bool_0: false, bool_1: false);
				Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary2;
				Dictionary<string, Dictionary<string, Dictionary<string, int>>> dictionary3;
				if (mission_0.MissionClass == Mission._MissionClass.Strike && ((Strike)mission_0).Escort_FlightSize_NonShooter == 0)
				{
					Mission obj2 = mission_0;
					scenario_ = this;
					dictionary2 = obj2.InvokeValue(ref scenario_, bool_0: true, bool_1: true);
					dictionary3 = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
				}
				else
				{
					Mission obj3 = mission_0;
					scenario_ = this;
					dictionary2 = obj3.InvokeValue(ref scenario_, bool_0: true, bool_1: false);
					Mission obj4 = mission_0;
					scenario_ = this;
					dictionary3 = obj4.InvokeValue(ref scenario_, bool_0: false, bool_1: true);
				}
				if (dictionary.Count > 0 || dictionary2.Count > 0 || dictionary3.Count > 0)
				{
					Mission._FlightSize _FlightSize_ = default(Mission._FlightSize);
					Mission._FlightSize _FlightSize_2 = default(Mission._FlightSize);
					Mission._FlightSize _FlightSize_3 = default(Mission._FlightSize);
					switch (mission_0.MissionClass)
					{
					case Mission._MissionClass.Strike:
					{
						Strike strike = (Strike)mission_0;
						_FlightSize_ = strike.FlightSize;
						_FlightSize_2 = strike.Escort_FlightSize_Shooter;
						_FlightSize_3 = strike.Escort_FlightSize_NonShooter;
						strike.ExcludeValue(ref _FlightSize_, ref strike.MinimumNumberOfAircraft);
						strike.ExcludeValue(ref _FlightSize_2, ref strike.MinimumNumberOfAircraft_Escorts_Shooter);
						strike.ExcludeValue(ref _FlightSize_3, ref strike.MinimumNumberOfAircraft_Escorts_NonShooter);
						flag = strike.UseFlightSizeHardLimit;
						flag2 = strike.UseFlightSizeHardLimit_Escort;
						break;
					}
					case Mission._MissionClass.Patrol:
					{
						Patrol patrol = (Patrol)mission_0;
						_FlightSize_ = patrol.FlightSize;
						patrol.ExcludeValue(ref _FlightSize_, ref patrol.MinimumNumberOfAircraft);
						flag = patrol.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Support:
					{
						SupportMission supportMission = (SupportMission)mission_0;
						_FlightSize_ = supportMission.FlightSize;
						supportMission.ExcludeValue(ref _FlightSize_, ref supportMission.MinimumNumberOfAircraft);
						flag = supportMission.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Ferry:
					{
						FerryMission obj6 = (FerryMission)mission_0;
						_FlightSize_ = obj6.FlightSize;
						flag = obj6.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Mining:
					{
						MiningMission miningMission = (MiningMission)mission_0;
						_FlightSize_ = miningMission.FlightSize;
						miningMission.ExcludeValue(ref _FlightSize_, ref miningMission.MinimumNumberOfAircraft);
						flag = miningMission.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.MineClearing:
					{
						MineClearingMission mineClearingMission = (MineClearingMission)mission_0;
						_FlightSize_ = mineClearingMission.FlightSize;
						mineClearingMission.ExcludeValue(ref _FlightSize_, ref mineClearingMission.MinimumNumberOfAircraft);
						flag = mineClearingMission.UseFlightSizeHardLimit;
						break;
					}
					case Mission._MissionClass.Escort:
					{
						EscortMission obj5 = (EscortMission)mission_0;
						_FlightSize_ = obj5.FlightSize;
						flag2 = obj5.UseFlightSizeHardLimit;
						break;
					}
					}
					if (flag)
					{
						foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item7 in dictionary)
						{
							Dictionary<string, Dictionary<string, int>> value = item7.Value;
							string key = item7.Key;
							foreach (KeyValuePair<string, Dictionary<string, int>> item8 in value)
							{
								Dictionary<string, int> value2 = item8.Value;
								string key2 = item8.Key;
								foreach (KeyValuePair<string, int> item9 in value2)
								{
									string key3 = item9.Key;
									int value3 = item9.Value;
									if (value3 < _FlightSize_)
									{
										string item = (Information.IsNothing(side_0) ? ("任务：" + mission_0.Name + "， 飞机" + key2 + "，挂载" + key3 + " 在舰船/基地" + key + "：飞机数量（" + Conversions.ToString(value3) + "）低于最小飞行编队大小（" + Conversions.ToString(_FlightSize_.value) + ")") : ("分方：" + side_0.Name + "任务：" + mission_0.Name + "， 飞机" + key2 + "，挂载" + key3 + " 在舰船/基地" + key + "：飞机数量（" + Conversions.ToString(value3) + "）低于最小飞行编队大小（" + Conversions.ToString(_FlightSize_.value) + ")"));
										list.Add(item);
									}
								}
							}
						}
					}
					if (flag2)
					{
						foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item10 in dictionary2)
						{
							Dictionary<string, Dictionary<string, int>> value4 = item10.Value;
							string key4 = item10.Key;
							foreach (KeyValuePair<string, Dictionary<string, int>> item11 in value4)
							{
								Dictionary<string, int> value5 = item11.Value;
								string key5 = item11.Key;
								foreach (KeyValuePair<string, int> item12 in value5)
								{
									string key6 = item12.Key;
									int value6 = item12.Value;
									if (value6 < _FlightSize_2)
									{
										string item5 = (Information.IsNothing(side_0) ? ("战斗机/SEAD 护航对于任务：" + mission_0.Name + "， 飞机" + key5 + "，挂载" + key6 + " 在舰船/基地" + key4 + "：飞机数量（" + Conversions.ToString(value6) + "）低于最小飞行编队大小（" + Conversions.ToString(_FlightSize_2.value) + ")") : ("分方：" + side_0.Name + "，战斗机/SEAD 护航对于任务：" + mission_0.Name + "， 飞机" + key5 + "，挂载" + key6 + " 在舰船/基地" + key4 + "：飞机数量（" + Conversions.ToString(value6) + "）低于最小飞行编队大小（" + Conversions.ToString(_FlightSize_2.value) + ")"));
										list.Add(item5);
									}
								}
							}
						}
						if (!Information.IsNothing(_FlightSize_3))
						{
							foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, int>>> item2 in dictionary3)
							{
								Dictionary<string, Dictionary<string, int>> value7 = item2.Value;
								string key7 = item2.Key;
								foreach (KeyValuePair<string, Dictionary<string, int>> item3 in value7)
								{
									Dictionary<string, int> value8 = item3.Value;
									string key8 = item3.Key;
									foreach (KeyValuePair<string, int> item4 in value8)
									{
										string key9 = item4.Key;
										int value9 = item4.Value;
										if (value9 < _FlightSize_3)
										{
											string item6 = (Information.IsNothing(side_0) ? ("护航任务：" + mission_0.Name + "， 飞机" + key8 + "，挂载" + key9 + " 在舰船/基地" + key7 + "：飞机数量（" + Conversions.ToString(value9) + "）低于最小飞行编队大小（" + Conversions.ToString(_FlightSize_3.value) + ")") : ("分方：" + side_0.Name + "，护航任务：" + mission_0.Name + "， 飞机" + key8 + "，挂载" + key9 + " 在舰船/基地" + key7 + "：飞机数量（" + Conversions.ToString(value9) + "）低于最小飞行编队大小（" + Conversions.ToString(_FlightSize_3.value) + ")"));
											list.Add(item6);
										}
									}
								}
							}
						}
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 101252", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<string> result = new List<string>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
		return list;
	}

	private void WeaponImpacts_ItemsAdded(object object_1, ObservableListModified<WeaponImpact> observableListModified_0)
	{
		foreach (WeaponImpact item in observableListModified_0.Items)
		{
			WeaponImpact.ExportWeaponImpactEvent(item, this);
		}
	}

	private void Explosions_ItemsAdded(object object_1, ObservableListModified<Explosion> observableListModified_0)
	{
		foreach (Explosion item in observableListModified_0.Items)
		{
			Explosion.ExportExplosionEvent(item, this);
		}
	}

	public static bool MergeScenarios(string string_0, string string_1, string string_2, DBOps.DatabaseMatchToleranceLevel databaseMatchToleranceLevel_0, bool bool_0, ref string string_3)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			if (string.IsNullOrEmpty(string_0))
			{
				stringBuilder.Append("想定1文件未选择！");
				string_3 = stringBuilder.ToString();
				return false;
			}
			if (FileExistsNative.FileExistsFast(string_0))
			{
				if (string.IsNullOrEmpty(string_1))
				{
					stringBuilder.Append("想定2文件名未选择！");
					string_3 = stringBuilder.ToString();
					return false;
				}
				if (FileExistsNative.FileExistsFast(string_1))
				{
					if (string.IsNullOrEmpty(string_2))
					{
						stringBuilder.Append("合并目标文件名未选择！");
						string_3 = stringBuilder.ToString();
						return false;
					}
					if (Directory.Exists(Path.GetDirectoryName(string_2)))
					{
						Scenario scenarioObject;
						try
						{
							stringBuilder.Append("加载想定1...");
							string_3 = stringBuilder.ToString();
							ScenContainer scenContainer = ScenContainer.LoadFromFile(string_0);
							string string_4 = null;
							scenarioObject = scenContainer.GetScenarioObject(ref string_4, null, bool_0: false);
							stringBuilder.Append(" 完毕。");
							string_3 = stringBuilder.ToString();
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							stringBuilder.Append(" Error: " + ex2.Message).Append("\r\n").Append("\r\n")
								.Append("合并取消，请解决问题后重试。");
							string_3 = stringBuilder.ToString();
							ProjectData.ClearProjectError();
							return false;
						}
						stringBuilder.Append("\r\n").Append("\r\n");
						string_3 = stringBuilder.ToString();
						Scenario scenarioObject2;
						try
						{
							stringBuilder.Append("加载想定2...");
							string_3 = stringBuilder.ToString();
							ScenContainer scenContainer2 = ScenContainer.LoadFromFile(string_1);
							string string_5 = null;
							scenarioObject2 = scenContainer2.GetScenarioObject(ref string_5, null, bool_0: false);
							stringBuilder.Append(" 完毕。");
							string_3 = stringBuilder.ToString();
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							stringBuilder.Append(" Error: " + ex4.Message).Append("\r\n").Append("\r\n")
								.Append("合并取消，请解决问题后重试。");
							string_3 = stringBuilder.ToString();
							ProjectData.ClearProjectError();
							return false;
						}
						DBOps.DatabaseMatchToleranceLevel databaseMatchToleranceLevel = DBOps.smethod_0(scenarioObject.DBUsed, scenarioObject2.DBUsed);
						switch (databaseMatchToleranceLevel_0)
						{
						case DBOps.DatabaseMatchToleranceLevel.SameFamily:
							if (databaseMatchToleranceLevel != DBOps.DatabaseMatchToleranceLevel.ExactVersion && databaseMatchToleranceLevel != DBOps.DatabaseMatchToleranceLevel.SameFamily)
							{
								stringBuilder.Append("'Same family' DB match level specified, but the two scenarios do not use the same general database. Merge aborted.");
								string_3 = stringBuilder.ToString();
								return false;
							}
							break;
						case DBOps.DatabaseMatchToleranceLevel.ExactVersion:
							if (databaseMatchToleranceLevel != DBOps.DatabaseMatchToleranceLevel.ExactVersion)
							{
								stringBuilder.Append("'Exact version' DB match level specified, but the two scenarios do not reference the exact same database. Merge aborted.");
								string_3 = stringBuilder.ToString();
								return false;
							}
							break;
						}
						if (scenarioObject2._Sides.Length != 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging sides (and their missions, contacts and ref. points) from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							Side[] sides = scenarioObject2._Sides;
							ActiveUnit activeUnit = null;
							Side[] array2 = sides;
							foreach (Side Local_theSide in array2)
							{
								stringBuilder.Append("\r\n").Append(Local_theSide.Name).Append(": ");
								string_3 = stringBuilder.ToString();
								bool flag;
								if ((flag = scenarioObject.Sides_ReadOnly.Where((Side side_0) => Operators.CompareString(side_0.ObjectID, Local_theSide.ObjectID, TextCompare: false) == 0).Count() > 0) && !bool_0)
								{
									stringBuilder.Append("A side with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else if (flag && bool_0)
								{
									stringBuilder.Append("\r\n").Append("\r\n").Append("A side with the same unique ID already exists on scenario #1, and merging side clones is allowed. Proceeding... ");
									string_3 = stringBuilder.ToString();
									Side side = scenarioObject.Sides_ReadOnly.Where((Side side_0) => Operators.CompareString(side_0.ObjectID, Local_theSide.ObjectID, TextCompare: false) == 0).ElementAtOrDefault(0);
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging postures of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									ReadOnlyCollection<KeyValuePair<Side, Misc.PostureStance>> postures_ReadOnly = Local_theSide.Postures_ReadOnly;
									if (postures_ReadOnly.Count > 0)
									{
										ReadOnlyCollection<KeyValuePair<Side, Misc.PostureStance>> postures_ReadOnly2 = side.Postures_ReadOnly;
										foreach (KeyValuePair<Side, Misc.PostureStance> Local_theKVP in postures_ReadOnly)
										{
											if (postures_ReadOnly2.Where((KeyValuePair<Side, Misc.PostureStance> keyValuePair_0) => Operators.CompareString(keyValuePair_0.Key.ObjectID, Local_theKVP.Key.ObjectID, TextCompare: false) == 0).Count() == 0)
											{
												side.SetConsidersThisSideToBe(Local_theKVP.Key, Local_theKVP.Value);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging reference points of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									List<ReferencePoint> list = Local_theSide.RefPoints.ToList();
									if (list.Count > 0)
									{
										foreach (ReferencePoint Local_SourceRP in list)
										{
											if (side.RefPoints.Where((ReferencePoint TargetRP) => Operators.CompareString(TargetRP.ObjectID, Local_SourceRP.ObjectID, TextCompare: false) == 0).Count() <= 0)
											{
												side.RefPoints.Add(Local_SourceRP);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging exclusion zones of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									List<ExclusionZone> exclusionZones = Local_theSide.ExclusionZones;
									if (exclusionZones.Count > 0)
									{
										foreach (ExclusionZone Local_SourceEZ in exclusionZones)
										{
											if (side.ExclusionZones.Where((ExclusionZone TargetEZ) => Operators.CompareString(TargetEZ.ObjectID, Local_SourceEZ.ObjectID, TextCompare: false) == 0).Count() <= 0)
											{
												side.ExclusionZones.Add(Local_SourceEZ);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging no-nav zones of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									List<NoNavZone> noNavZones = Local_theSide.NoNavZones;
									if (noNavZones.Count > 0)
									{
										foreach (NoNavZone Local_SourceNNZ in noNavZones)
										{
											if (side.NoNavZones.Where((NoNavZone noNavZone_0) => Operators.CompareString(noNavZone_0.ObjectID, Local_SourceNNZ.ObjectID, TextCompare: false) == 0).Count() <= 0)
											{
												side.NoNavZones.Add(Local_SourceNNZ);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging quick-jump slots of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									Dictionary<int, QuickJumpSlot> quickJumpSlots = Local_theSide.QuickJumpSlots;
									if (quickJumpSlots.Count > 0)
									{
										foreach (KeyValuePair<int, QuickJumpSlot> item in quickJumpSlots)
										{
											if (!side.QuickJumpSlots.ContainsKey(item.Key))
											{
												side.QuickJumpSlots.Add(item.Key, item.Value);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging contacts zones of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									ObservableDictionary<string, Contact> contacts = Local_theSide.Contacts;
									if (contacts.Count > 0)
									{
										foreach (KeyValuePair<string, Contact> item2 in contacts)
										{
											if (!side.Contacts.ContainsKey(item2.Key))
											{
												side.Contacts.Add(item2.Key, item2.Value);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging base-contacts zones of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									ObservableDictionary<string, Contact> baseContacts = Local_theSide.BaseContacts;
									if (baseContacts.Count > 0)
									{
										foreach (KeyValuePair<string, Contact> item3 in baseContacts)
										{
											if (!side.BaseContacts.ContainsKey(item3.Key))
											{
												side.BaseContacts.Add(item3.Key, item3.Value);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging non-AU contacts zones of side: " + Local_theSide.Name + "...");
									string_3 = stringBuilder.ToString();
									HashSet<string> contacts_NonAU = Local_theSide.Contacts_NonAU;
									if (contacts_NonAU.Count > 0)
									{
										foreach (string item4 in contacts_NonAU)
										{
											side.Contacts_NonAU.Add(item4);
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging missions of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									ReadOnlyCollection<Mission> missions = Local_theSide.Missions;
									if (missions.Count > 0)
									{
										foreach (Mission Local_SourceMission in missions)
										{
											if (side.Missions.Where((Mission TargetMission) => Operators.CompareString(TargetMission.ObjectID, Local_SourceMission.ObjectID, TextCompare: false) == 0).Count() > 0)
											{
												continue;
											}
											side.Missions_Add(Local_SourceMission);
											foreach (ActiveUnit activeUnits_ in scenarioObject2.ActiveUnits_List)
											{
												if (activeUnits_.AssignedMissionOrPackage() != null && activeUnits_.AssignedMissionOrPackage() == Local_SourceMission && scenarioObject.ActiveUnits.TryGetValue(activeUnits_.ObjectID, ref activeUnit) && activeUnit.AssignedMissionOrPackage() == null)
												{
													ActiveUnit activeUnit2 = activeUnit;
													Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
													activeUnit2.Set_AssignedMissionOrPackage(Local_SourceMission, bool_0: true, bool_1: false, ref missionAssignmentAttemptResult_);
												}
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging special actions of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									Dictionary<string, SpecialAction> specialActions = Local_theSide.SpecialActions;
									if (specialActions.Count > 0)
									{
										foreach (KeyValuePair<string, SpecialAction> item5 in specialActions)
										{
											if (!side.SpecialActions.ContainsKey(item5.Key))
											{
												side.SpecialActions.Add(item5.Key, item5.Value);
											}
										}
									}
									stringBuilder.Append("\r\n").Append("\r\n").Append("Merging weapon salvos of side: " + Local_theSide.Name + " (base version wins on conflicts)...");
									string_3 = stringBuilder.ToString();
									WeaponSalvo[] weaponSalvos = Local_theSide.WeaponSalvos;
									if (weaponSalvos.Length != 0)
									{
										WeaponSalvo[] array = weaponSalvos;
										WeaponSalvo[] array3 = array;
										foreach (WeaponSalvo Local_SourceSalvo in array3)
										{
											if (side.WeaponSalvos.Where((WeaponSalvo TargetSalvo) => Operators.CompareString(TargetSalvo.ObjectID, Local_SourceSalvo.ObjectID, TextCompare: false) == 0).Count() <= 0)
											{
												ArrayExtensions.Add(ref side.WeaponSalvos, Local_SourceSalvo);
											}
										}
									}
									stringBuilder.Append("Finished merging objects of side: " + Local_theSide.Name);
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.AddSide(Local_theSide);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.Explosions.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging explosions from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (Explosion Local_theExplosion in scenarioObject2.Explosions)
							{
								stringBuilder.Append("\r\n").Append(Local_theExplosion.ObjectID).Append(": ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.Explosions.Where((Explosion Scen1Explosion) => Operators.CompareString(Scen1Explosion.ObjectID, Local_theExplosion.ObjectID, TextCompare: false) == 0).Count() <= 0)
								{
									scenarioObject.Explosions.Add(Local_theExplosion);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									stringBuilder.Append("An explosion with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.WeaponImpacts.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging weapon impacts from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (WeaponImpact Local_theWI in scenarioObject2.WeaponImpacts)
							{
								stringBuilder.Append("\r\n").Append(Local_theWI.ObjectID).Append(": ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.WeaponImpacts.Where((WeaponImpact weaponImpact_0) => Operators.CompareString(weaponImpact_0.ObjectID, Local_theWI.ObjectID, TextCompare: false) == 0).Count() <= 0)
								{
									scenarioObject.WeaponImpacts.Add(Local_theWI);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									stringBuilder.Append("A weapon impact with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.UnguidedWeapons.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging unguided weapons from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (KeyValuePair<string, UnguidedWeapon> unguidedWeapon in scenarioObject2.UnguidedWeapons)
							{
								stringBuilder.Append("\r\n").Append(unguidedWeapon.Key).Append(" (")
									.Append(unguidedWeapon.Value.Name)
									.Append("): ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.UnguidedWeapons.ContainsKey(unguidedWeapon.Key))
								{
									stringBuilder.Append("An unguided weapon with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.UnguidedWeapons.Add(unguidedWeapon.Key, unguidedWeapon.Value);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.ChaffClouds.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging chaff clouds from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (ChaffCorridorCloud Local_theCloud in scenarioObject2.ChaffClouds)
							{
								stringBuilder.Append("\r\n").Append(Local_theCloud.ObjectID).Append(": ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.ChaffClouds.Where((ChaffCorridorCloud chaffCorridorCloud_0) => Operators.CompareString(chaffCorridorCloud_0.ObjectID, Local_theCloud.ObjectID, TextCompare: false) == 0).Count() <= 0)
								{
									scenarioObject.ChaffClouds.Add(Local_theCloud);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									stringBuilder.Append("A chaff cloud with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.ActiveUnits.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging active units from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (KeyValuePair<string, ActiveUnit> activeUnit3 in scenarioObject2.ActiveUnits)
							{
								stringBuilder.Append("\r\n").Append(activeUnit3.Value.Name).Append(" (")
									.Append(activeUnit3.Value.UnitClass)
									.Append("): ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.ActiveUnits.ContainsKey(activeUnit3.Key))
								{
									stringBuilder.Append("An active unit with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.ActiveUnits.Add(activeUnit3.Key, activeUnit3.Value);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.Groups.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging groups from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (Group group in scenarioObject2.Groups)
							{
								stringBuilder.Append("\r\n").Append(group.Name).Append(": ");
								string_3 = stringBuilder.ToString();
								if (Misc.ContainsByName(scenarioObject.Groups, group.Name))
								{
									stringBuilder.Append("A group with the same name already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.Groups.Add(group);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.EventTriggers.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging event triggers from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (KeyValuePair<string, EventTrigger> eventTrigger in scenarioObject2.EventTriggers)
							{
								stringBuilder.Append("\r\n").Append(eventTrigger.Value.Name).Append(" (")
									.Append(eventTrigger.Key)
									.Append("): ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.EventTriggers.ContainsKey(eventTrigger.Key))
								{
									stringBuilder.Append("An event trigger with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.EventTriggers.Add(eventTrigger.Key, eventTrigger.Value);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.EventConditions.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging event conditions from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (KeyValuePair<string, EventCondition> eventCondition in scenarioObject2.EventConditions)
							{
								stringBuilder.Append("\r\n").Append(eventCondition.Value.Name).Append(" (")
									.Append(eventCondition.Key)
									.Append("): ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.EventConditions.ContainsKey(eventCondition.Key))
								{
									stringBuilder.Append("An event condition with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.EventConditions.Add(eventCondition.Key, eventCondition.Value);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.EventActions.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging event actions from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (KeyValuePair<string, EventAction> eventAction in scenarioObject2.EventActions)
							{
								stringBuilder.Append("\r\n").Append(eventAction.Value.Name).Append(" (")
									.Append(eventAction.Key)
									.Append("): ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.EventActions.ContainsKey(eventAction.Key))
								{
									stringBuilder.Append("An event action with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.EventActions.Add(eventAction.Key, eventAction.Value);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.SimEvents.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging sim events from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (KeyValuePair<string, SimEvent> simEvent in scenarioObject2.SimEvents)
							{
								stringBuilder.Append("\r\n").Append(simEvent.Value.Name).Append(" (")
									.Append(simEvent.Key)
									.Append("): ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.SimEvents.ContainsKey(simEvent.Key))
								{
									stringBuilder.Append("A sim event with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.SimEvents.Add(simEvent.Key, simEvent.Value);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						if (scenarioObject2.ScenAttachments.Count > 0)
						{
							stringBuilder.Append("\r\n").Append("\r\n").Append("Merging scenario attachments from scenario #2 into scenario #1...");
							string_3 = stringBuilder.ToString();
							foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in scenarioObject2.ScenAttachments)
							{
								stringBuilder.Append("\r\n").Append(scenAttachment.Value.Name).Append(" (")
									.Append(scenAttachment.Key)
									.Append("): ");
								string_3 = stringBuilder.ToString();
								if (scenarioObject.ScenAttachments.ContainsKey(scenAttachment.Key))
								{
									stringBuilder.Append("A scen attachment object with the same unique ID already exists on scenario #1 - skipping.");
									string_3 = stringBuilder.ToString();
								}
								else
								{
									scenarioObject.ScenAttachments.Add(scenAttachment.Key, scenAttachment.Value);
									stringBuilder.Append("OK");
									string_3 = stringBuilder.ToString();
								}
							}
						}
						scenarioObject.UnitsAutoIncrement = scenarioObject.ActiveUnits.Count + scenarioObject.Groups.Count + scenarioObject.UnguidedWeapons.Count + scenarioObject.Sides_ReadOnly.Select((Side theSide) => theSide.RefPoints.Count).Sum() + 10;
						stringBuilder.Append("\r\n").Append("\r\n").Append("Finished merging objects - saving result...");
						string_3 = stringBuilder.ToString();
						Command_Core.LoadSave.LoadSave.SaveScenario(scenarioObject, scenarioObject.GetCurrentSide(), string_2, bool_0: false);
						stringBuilder.Append("\r\n").Append("\r\n").Append("合并成功完成！");
						string_3 = stringBuilder.ToString();
						scenarioObject = null;
						scenarioObject2 = null;
						return true;
					}
					stringBuilder.Append("合并目标文件保存路径不存在！");
					string_3 = stringBuilder.ToString();
					return false;
				}
				stringBuilder.Append("想定2文件名错误！");
				string_3 = stringBuilder.ToString();
				return false;
			}
			stringBuilder.Append("想定1文件名错误！");
			string_3 = stringBuilder.ToString();
			return false;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			GameGeneral.ResolveBridge("未处理异常：" + ex6.Message + "\r\n\r\nStacktrace: " + ex6.StackTrace, null);
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void CreateNatureSideIfNeeded()
	{
		if (!NatureSideExists())
		{
			Scenario scenario_ = this;
			Side side_ = new Side("Nature", ref scenario_, bool_0: true);
			AddSide(side_);
		}
	}

	public Side GetNatureSide()
	{
		Side[] sides_ReadOnly = Sides_ReadOnly;
		int num = 0;
		Side side;
		while (true)
		{
			if (num < sides_ReadOnly.Length)
			{
				side = sides_ReadOnly[num];
				if (side.CalcOrder())
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return side;
	}

	public bool NatureSideExists()
	{
		try
		{
			Side[] sides_ReadOnly = Sides_ReadOnly;
			int num = 0;
			while (true)
			{
				if (num < sides_ReadOnly.Length)
				{
					if (sides_ReadOnly[num].CalcOrder())
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public string GetConcatenated_MDSP_Errors(string string_0, string string_1)
	{
		if (MissionPlannerErrorList == null)
		{
			return null;
		}
		string text = "";
		foreach (MDSP_Error missionPlannerError in MissionPlannerErrorList)
		{
			if (!((Operators.CompareString(string_0, "", TextCompare: false) != 0) & (Operators.CompareString(string_0, null, TextCompare: false) != 0) & (Operators.CompareString(string_0, missionPlannerError.Mission, TextCompare: false) != 0)) && !((Operators.CompareString(string_1, "", TextCompare: false) != 0) & (Operators.CompareString(string_1, null, TextCompare: false) != 0) & (Operators.CompareString(string_1, missionPlannerError.Flight, TextCompare: false) != 0)))
			{
				text = text + Environment.NewLine + " Mission:" + missionPlannerError.Mission + " Flight " + missionPlannerError.Flight + " Error" + missionPlannerError.Message;
			}
		}
		return text;
	}
}
