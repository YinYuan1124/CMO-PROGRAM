using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using CoordinateSharp;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Game
{
	public delegate void GameModeChangedEventHandler();

	public delegate void CurrentGameStatusChangedEventHandler();

	public delegate void GameStatusChangeRequestIssuedEventHandler(_GameStatus DesiredStatus);

	public enum _GameMode : byte
	{
		SinglePlayer,
		MultiPlayer,
		ScenEdit,
		MultiplayerScenEdit,
		MonteCarlo
	}

	public enum _GameStatus : byte
	{
		Paused,
		Running
	}

	public class GamePreferences
	{
		public enum SonobuoyVisibilitySetting : byte
		{
			Normal,
			Ghosted,
			DontShow
		}

		public enum SpeedUnitSetting : byte
		{
			Knots,
			KPH,
			MPH
		}

		public enum DPIScalingMethodSetting : byte
		{
			WindowsInternal,
			Font
		}

		public enum RefPointVisibilitySetting : byte
		{
			Normal,
			Small,
			DontShow
		}

		public enum MapCursorBoxVisibilitySetting : byte
		{
			AtCursor,
			Bottom,
			DontShow
		}

		public enum MapSymbolsSetting : byte
		{
			NTDS,
			Stylized,
			Directional
		}

		public enum GhostedGroupMembersVisibilitySetting : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum PlottedPathsVisibilitySetting : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum FlightPlansVisibilitySetting_Airborne : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		public enum FlightPlansVisibilitySetting_Planned : byte
		{
			All,
			SelectedTaskPool,
			SelectedPackage,
			SelectedFlight,
			DontShow
		}

		public enum ObjectVisibilitySetting : short
		{
			All,
			Selected,
			DontShow
		}

		public enum Unit_Behaviour_Bark : byte
		{
			All,
			SelectedUnit,
			DontShow
		}

		private bool predicateComparator;

		private bool m_SingletonComparator;

		private bool recordComparator;

		private bool exceptionComparator;

		private bool m_AttrComparator;

		private int m_VisitorComparator;

		private bool _ExporterComparator;

		private int m_PrototypeComparator;

		private bool m_ComparatorComparator;

		private bool _ItemComparator;

		private bool m_SetterComparator;

		private SonobuoyVisibilitySetting creatorComparator;

		private RefPointVisibilitySetting _TemplateComparator;

		private MapSymbolsSetting mappingComparator;

		private MapCursorBoxVisibilitySetting mockComparator;

		private SpeedUnitSetting m_TagComparator;

		private Parse_Format_Type fieldComparator;

		private bool _QueueComparator;

		private GhostedGroupMembersVisibilitySetting m_RegComparator;

		private PlottedPathsVisibilitySetting m_ParamComparator;

		private FlightPlansVisibilitySetting_Airborne m_PageComparator;

		private string _RulesComparator;

		private FlightPlansVisibilitySetting_Planned m_MethodComparator;

		private float serviceComparator;

		private bool _SystemComparator;

		private float m_CandidateComparator;

		private ObjectVisibilitySetting m_BaseComparator;

		private bool policyComparator;

		private bool m_BroadcasterComparator;

		private bool identifierComparator;

		private bool printerComparator;

		private bool _ParserComparator;

		private bool _AlgoComparator;

		private bool m_DatabaseComparator;

		private bool _InterceptorComparator;

		private string messageComparator;

		private bool m_ProductComparator;

		private bool _AnnotationComparator;

		public Dictionary<LoggedMessage.MessageType, LoggedMessage.MessageSettings> MessageLogSettings;

		public bool UsePersonalMapProfile;

		private MapProfile iteratorComparator;

		private SimConfiguration.WindowPauseBehaviour _InitializerComparator;

		private SimConfiguration.WindowPauseBehaviour m_RoleComparator;

		private bool factoryComparator;

		private SlugTrailTimeFrequency _AttributeComparator;

		private bool _EventComparator;

		private bool globalComparator;

		private bool workerComparator;

		private bool m_AccountComparator;

		private bool _StateComparator;

		private bool authenticationComparator;

		private int paramsComparator;

		private int _InfoComparator;

		private int helperComparator;

		private int m_MapperComparator;

		private int managerComparator;

		private bool _GetterComparator;

		private Unit_Behaviour_Bark m_ProducerComparator;

		[Description("If True, the program will automatically save the current scenario to the file 'Autosave.scen', every 30 seconds.")]
		[DisplayName("Use Autosave")]
		public bool UseAutosave
		{
			get
			{
				return predicateComparator;
			}
			set
			{
				predicateComparator = value;
			}
		}

		[DisplayName("Run core engine multithreaded")]
		[Description("If True, the core engine will execute multithreaded")]
		public bool RunCoreMultithreaded
		{
			get
			{
				return m_SingletonComparator;
			}
			set
			{
				m_SingletonComparator = value;
			}
		}

		[Description("Show Diangostics information (number of active units, pulse execution time etc.")]
		[DisplayName("Show Diagnostic Information")]
		public bool ShowDiagnostics
		{
			get
			{
				return recordComparator;
			}
			set
			{
				recordComparator = value;
			}
		}

		public bool MessageLogInWindow
		{
			get
			{
				return exceptionComparator;
			}
			set
			{
				exceptionComparator = value;
			}
		}

		public bool GameSounds
		{
			get
			{
				return m_AttrComparator;
			}
			set
			{
				m_AttrComparator = value;
			}
		}

		public int Int32_0
		{
			get
			{
				return m_VisitorComparator;
			}
			set
			{
				m_VisitorComparator = value;
			}
		}

		public bool GameMusic
		{
			get
			{
				return _ExporterComparator;
			}
			set
			{
				_ExporterComparator = value;
			}
		}

		public int MusicVolume
		{
			get
			{
				return m_PrototypeComparator;
			}
			set
			{
				m_PrototypeComparator = value;
			}
		}

		public bool ShowUSUnitsForEditCargo
		{
			get
			{
				return _ItemComparator;
			}
			set
			{
				_ItemComparator = value;
			}
		}

		public bool ShowAltitudeInFeet
		{
			get
			{
				return m_ComparatorComparator;
			}
			set
			{
				m_ComparatorComparator = value;
			}
		}

		public bool ZoomOnCursor
		{
			get
			{
				return m_SetterComparator;
			}
			set
			{
				m_SetterComparator = value;
			}
		}

		public SonobuoyVisibilitySetting SonobuoyVisibility
		{
			get
			{
				return creatorComparator;
			}
			set
			{
				creatorComparator = value;
			}
		}

		public RefPointVisibilitySetting RefPointVisibility
		{
			get
			{
				return _TemplateComparator;
			}
			set
			{
				_TemplateComparator = value;
			}
		}

		public MapSymbolsSetting MapSymbolsSet
		{
			get
			{
				return mappingComparator;
			}
			set
			{
				mappingComparator = value;
			}
		}

		public SpeedUnitSetting GroundUnitsSpeedUnit
		{
			get
			{
				return m_TagComparator;
			}
			set
			{
				m_TagComparator = value;
			}
		}

		public Parse_Format_Type GeoCoordinateType
		{
			get
			{
				return fieldComparator;
			}
			set
			{
				fieldComparator = value;
			}
		}

		public MapCursorBoxVisibilitySetting MapCursorBox
		{
			get
			{
				return mockComparator;
			}
			set
			{
				mockComparator = value;
			}
		}

		public bool OnlyShowAvailableLoadouts
		{
			get
			{
				return _QueueComparator;
			}
			set
			{
				_QueueComparator = value;
			}
		}

		public GhostedGroupMembersVisibilitySetting ShowGhostedGroupMembers
		{
			get
			{
				return m_RegComparator;
			}
			set
			{
				m_RegComparator = value;
			}
		}

		public ObjectVisibilitySetting ShowMissionArea
		{
			get
			{
				return m_BaseComparator;
			}
			set
			{
				m_BaseComparator = value;
			}
		}

		public PlottedPathsVisibilitySetting ShowPlottedPaths
		{
			get
			{
				return m_ParamComparator;
			}
			set
			{
				m_ParamComparator = value;
			}
		}

		public FlightPlansVisibilitySetting_Airborne ShowFlightPlans_Airborne
		{
			get
			{
				return m_PageComparator;
			}
			set
			{
				m_PageComparator = value;
			}
		}

		public FlightPlansVisibilitySetting_Planned ShowFlightPlans_Planned
		{
			get
			{
				return m_MethodComparator;
			}
			set
			{
				m_MethodComparator = value;
			}
		}

		public Unit_Behaviour_Bark ShowAU_Behaviour_Bark
		{
			get
			{
				return m_ProducerComparator;
			}
			set
			{
				m_ProducerComparator = value;
			}
		}

		public float NavigationMaxDistanceNMSetting
		{
			get
			{
				return serviceComparator;
			}
			set
			{
				serviceComparator = value;
			}
		}

		public bool RMB_MoveOrder_Enabled
		{
			get
			{
				return _SystemComparator;
			}
			set
			{
				_SystemComparator = value;
			}
		}

		public float NavigationThresholdDistanceDegSetting
		{
			get
			{
				return m_CandidateComparator;
			}
			set
			{
				m_CandidateComparator = value;
			}
		}

		public bool UnitStatusImage
		{
			get
			{
				return policyComparator;
			}
			set
			{
				policyComparator = value;
			}
		}

		public bool SalvoTimeout
		{
			get
			{
				return m_BroadcasterComparator;
			}
			set
			{
				m_BroadcasterComparator = value;
			}
		}

		public bool ShowAutomaticFireInfo
		{
			get
			{
				return identifierComparator;
			}
			set
			{
				identifierComparator = value;
			}
		}

		public bool ShowGameSpeedButton
		{
			get
			{
				return printerComparator;
			}
			set
			{
				printerComparator = value;
			}
		}

		public bool LogDebugInfoToFile
		{
			get
			{
				return _ParserComparator;
			}
			set
			{
				_ParserComparator = value;
			}
		}

		public bool PlacenameVisibility
		{
			get
			{
				return _AlgoComparator;
			}
			set
			{
				_AlgoComparator = value;
			}
		}

		public bool MessageLogCanvas
		{
			get
			{
				return m_DatabaseComparator;
			}
			set
			{
				m_DatabaseComparator = value;
			}
		}

		public bool AllowPowerPlanSwitch
		{
			get
			{
				return _InterceptorComparator;
			}
			set
			{
				_InterceptorComparator = value;
			}
		}

		public bool StartFullScreen
		{
			get
			{
				return m_ProductComparator;
			}
			set
			{
				m_ProductComparator = value;
			}
		}

		public string TacviewExePath
		{
			get
			{
				return messageComparator;
			}
			set
			{
				messageComparator = value;
			}
		}

		public bool ColorDataBlocks
		{
			get
			{
				return _AnnotationComparator;
			}
			set
			{
				_AnnotationComparator = value;
			}
		}

		public SimConfiguration.WindowPauseBehaviour PauseOnDBView
		{
			get
			{
				return _InitializerComparator;
			}
			set
			{
				_InitializerComparator = value;
			}
		}

		public SimConfiguration.WindowPauseBehaviour PauseOnAirDockOps
		{
			get
			{
				return m_RoleComparator;
			}
			set
			{
				m_RoleComparator = value;
			}
		}

		public SlugTrailTimeFrequency SlugTrailTimeFrequency
		{
			get
			{
				return _AttributeComparator;
			}
			set
			{
				_AttributeComparator = value;
			}
		}

		public bool SlugTrail_Use
		{
			get
			{
				return _EventComparator;
			}
			set
			{
				_EventComparator = value;
			}
		}

		public bool SlugTrail_OwnAndAllied
		{
			get
			{
				return globalComparator;
			}
			set
			{
				globalComparator = value;
			}
		}

		public bool SlugTrail_Friendly
		{
			get
			{
				return workerComparator;
			}
			set
			{
				workerComparator = value;
			}
		}

		public bool SlugTrail_Neutral
		{
			get
			{
				return m_AccountComparator;
			}
			set
			{
				m_AccountComparator = value;
			}
		}

		public bool SlugTrail_Hostile
		{
			get
			{
				return _StateComparator;
			}
			set
			{
				_StateComparator = value;
			}
		}

		public int SlugTrail_LifeTime
		{
			get
			{
				return paramsComparator;
			}
			set
			{
				paramsComparator = value;
			}
		}

		public int GroundUnitZoom
		{
			get
			{
				return _InfoComparator;
			}
			set
			{
				_InfoComparator = value;
			}
		}

		public int DiamondZoom
		{
			get
			{
				return helperComparator;
			}
			set
			{
				helperComparator = value;
			}
		}

		public int FlowerZoom
		{
			get
			{
				return managerComparator;
			}
			set
			{
				managerComparator = value;
			}
		}

		public int RectangleZoom
		{
			get
			{
				return m_MapperComparator;
			}
			set
			{
				m_MapperComparator = value;
			}
		}

		public bool SlugTrail_Unfriendly
		{
			get
			{
				return authenticationComparator;
			}
			set
			{
				authenticationComparator = value;
			}
		}

		public bool SlugTrail_UnKnown
		{
			get
			{
				return _GetterComparator;
			}
			set
			{
				_GetterComparator = value;
			}
		}

		public MapProfile PersonalMapProfile
		{
			get
			{
				if (iteratorComparator == null)
				{
					iteratorComparator = MapProfile.GetDefaultProfile();
				}
				return iteratorComparator;
			}
			set
			{
				iteratorComparator = value;
			}
		}

		public bool AllowInGameDownloads
		{
			get
			{
				return factoryComparator;
			}
			set
			{
				factoryComparator = value;
			}
		}

		public GamePreferences()
		{
			MessageLogSettings = new Dictionary<LoggedMessage.MessageType, LoggedMessage.MessageSettings>();
			MessageLogSettings.Add(LoggedMessage.MessageType.AirOps, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.CommsIsolatedMessage, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.ContactChange, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.DockingOps, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewContact, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewAirContact, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewSurfaceContact, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewUnderwaterContact, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewGroundContact, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewMineContact, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.PointDefence, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.EventEngine, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.SpecialMessage, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: true));
			MessageLogSettings.Add(LoggedMessage.MessageType.UI, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitAI, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitDamage, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: true));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitLost, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: true));
			MessageLogSettings.Add(LoggedMessage.MessageType.WeaponDamage, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.WeaponEndgame, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.WeaponLogic, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.NewWeaponContact, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: true, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnguidedWeaponModifiers, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.const_23, new LoggedMessage.MessageSettings(bool_1: false, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.Debug, new LoggedMessage.MessageSettings(bool_1: true, bool_2: false, bool_3: false, bool_4: false));
			MessageLogSettings.Add(LoggedMessage.MessageType.UnitAIEmergency, new LoggedMessage.MessageSettings(bool_1: false, bool_2: true, bool_3: true, bool_4: true));
		}
	}

	private _GameStatus m_WorkerClient;

	private _GameMode _AccountClient;

	[CompilerGenerated]
	private static GameStatusChangeRequestIssuedEventHandler _StateClient;

	public string AALog_Name;

	[CompilerGenerated]
	private static GameModeChangedEventHandler _AuthenticationClient;

	[CompilerGenerated]
	private static CurrentGameStatusChangedEventHandler _ParamsClient;

	public _GameStatus Status => m_WorkerClient;

	public _GameMode GameMode
	{
		get
		{
			return _AccountClient;
		}
		set
		{
			bool num = _AccountClient != value;
			_AccountClient = value;
			if (num)
			{
				_AuthenticationClient?.Invoke();
			}
		}
	}

	public bool IsScenEditGameMode => (GameMode == _GameMode.ScenEdit) | (GameMode == _GameMode.MultiplayerScenEdit);

	public static event GameModeChangedEventHandler GameModeChanged
	{
		[CompilerGenerated]
		add
		{
			GameModeChangedEventHandler gameModeChangedEventHandler = _AuthenticationClient;
			GameModeChangedEventHandler gameModeChangedEventHandler2;
			do
			{
				gameModeChangedEventHandler2 = gameModeChangedEventHandler;
				GameModeChangedEventHandler value2 = (GameModeChangedEventHandler)Delegate.Combine(gameModeChangedEventHandler2, value);
				gameModeChangedEventHandler = Interlocked.CompareExchange(ref _AuthenticationClient, value2, gameModeChangedEventHandler2);
			}
			while ((object)gameModeChangedEventHandler != gameModeChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GameModeChangedEventHandler gameModeChangedEventHandler = _AuthenticationClient;
			GameModeChangedEventHandler gameModeChangedEventHandler2;
			do
			{
				gameModeChangedEventHandler2 = gameModeChangedEventHandler;
				GameModeChangedEventHandler value2 = (GameModeChangedEventHandler)Delegate.Remove(gameModeChangedEventHandler2, value);
				gameModeChangedEventHandler = Interlocked.CompareExchange(ref _AuthenticationClient, value2, gameModeChangedEventHandler2);
			}
			while ((object)gameModeChangedEventHandler != gameModeChangedEventHandler2);
		}
	}

	public static event CurrentGameStatusChangedEventHandler CurrentGameStatusChanged
	{
		[CompilerGenerated]
		add
		{
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler = _ParamsClient;
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler2;
			do
			{
				currentGameStatusChangedEventHandler2 = currentGameStatusChangedEventHandler;
				CurrentGameStatusChangedEventHandler value2 = (CurrentGameStatusChangedEventHandler)Delegate.Combine(currentGameStatusChangedEventHandler2, value);
				currentGameStatusChangedEventHandler = Interlocked.CompareExchange(ref _ParamsClient, value2, currentGameStatusChangedEventHandler2);
			}
			while ((object)currentGameStatusChangedEventHandler != currentGameStatusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler = _ParamsClient;
			CurrentGameStatusChangedEventHandler currentGameStatusChangedEventHandler2;
			do
			{
				currentGameStatusChangedEventHandler2 = currentGameStatusChangedEventHandler;
				CurrentGameStatusChangedEventHandler value2 = (CurrentGameStatusChangedEventHandler)Delegate.Remove(currentGameStatusChangedEventHandler2, value);
				currentGameStatusChangedEventHandler = Interlocked.CompareExchange(ref _ParamsClient, value2, currentGameStatusChangedEventHandler2);
			}
			while ((object)currentGameStatusChangedEventHandler != currentGameStatusChangedEventHandler2);
		}
	}

	public static event GameStatusChangeRequestIssuedEventHandler GameStatusChangeRequestIssued
	{
		[CompilerGenerated]
		add
		{
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler = _StateClient;
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler2;
			do
			{
				gameStatusChangeRequestIssuedEventHandler2 = gameStatusChangeRequestIssuedEventHandler;
				GameStatusChangeRequestIssuedEventHandler value2 = (GameStatusChangeRequestIssuedEventHandler)Delegate.Combine(gameStatusChangeRequestIssuedEventHandler2, value);
				gameStatusChangeRequestIssuedEventHandler = Interlocked.CompareExchange(ref _StateClient, value2, gameStatusChangeRequestIssuedEventHandler2);
			}
			while ((object)gameStatusChangeRequestIssuedEventHandler != gameStatusChangeRequestIssuedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler = _StateClient;
			GameStatusChangeRequestIssuedEventHandler gameStatusChangeRequestIssuedEventHandler2;
			do
			{
				gameStatusChangeRequestIssuedEventHandler2 = gameStatusChangeRequestIssuedEventHandler;
				GameStatusChangeRequestIssuedEventHandler value2 = (GameStatusChangeRequestIssuedEventHandler)Delegate.Remove(gameStatusChangeRequestIssuedEventHandler2, value);
				gameStatusChangeRequestIssuedEventHandler = Interlocked.CompareExchange(ref _StateClient, value2, gameStatusChangeRequestIssuedEventHandler2);
			}
			while ((object)gameStatusChangeRequestIssuedEventHandler != gameStatusChangeRequestIssuedEventHandler2);
		}
	}

	internal static void ListBridge(_GameStatus _GameStatus_0)
	{
		_StateClient?.Invoke(_GameStatus_0);
	}

	public void Run()
	{
		if (GameMode != _GameMode.MultiPlayer)
		{
			m_WorkerClient = _GameStatus.Running;
			_ParamsClient?.Invoke();
		}
	}

	public void Pause()
	{
		m_WorkerClient = _GameStatus.Paused;
		_ParamsClient?.Invoke();
	}

	public Game()
	{
		DateTime now = DateAndTime.Now;
		AALog_Name = now.Year + "-" + now.Month + "-" + now.Day + "_" + now.Hour + "." + now.Minute + "." + now.Second;
	}
}
