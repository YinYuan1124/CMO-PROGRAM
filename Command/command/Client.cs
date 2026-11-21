using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Threading;
using Command.Bridges;
using Command.Filters;
using Command.Listeners;
using Command.Managers;
using Command.Messages;
using Command.Records;
using Command.Tacview;
using Command_Core;
using Command_Core.LoadSave;
using Command_Core.Lua;
using DXRenderer;
using DarkUI.Collections;
using DarkUI.Forms;
using ExWorldWind;
using Magic.Samples.DisplaySettings;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Pages;

namespace Command;

[StandardModule]
public sealed class Client
{
	public delegate void ScenarioChangingEventHandler();

	public delegate void SelectedUnitChangedEventHandler(Module_Unit.Unit theUnit);

	public delegate void SelectedWaypointChangedEventHandler(Waypoint theWaypoint);

	public delegate void SelectedUnitPreChangeEventHandler();

	public delegate void SelectedWaypointPreChangeEventHandler();

	public delegate void CurrentSideChangedEventHandler();

	public delegate void TimeAdvancedEventHandler(Scenario theScen);

	public enum UserAction
	{
		None,
		MeasuringDistance,
		AddingPlatform,
		CreatingNewScenario,
		EditingScenarioTitleDescription,
		SavingScenario,
		PlottingCourse,
		SettingBaseForUnit,
		AddingReferencePoint,
		MovingReferencePoint,
		DroppingATarget,
		const_11,
		CopyingAUnit,
		SettingGroupLead,
		AddingFormationStation,
		SettingRefPointsRelativeTo,
		TargetingContact_AutoEngage,
		TargetingContact_ManualFire,
		const_18,
		DefiningArea_Rectangle,
		RequestSatellitePrediction,
		CloningAUnit,
		PackingScenarioForDistribution,
		PlottingCourseForSalvo,
		SelectingTanker,
		DefiningArea_Circle,
		SelectingPickupTarget,
		RTB,
		JoingGroupAsEscort,
		InvestigateContact,
		RefuelAtTarget,
		HoveringOnInteractableContact,
		SelectingRearmSupply
	}

	[CompilerGenerated]
	private sealed class FacadeMap
	{
		public Scenario Local_newScen;

		public bool Local_CauseIsVCRPlayback;

		public Game Local_theGameContext;

		internal void CallInterruptiblePage()
		{
			try
			{
				Scenario scenario_ = CompareConfiguration();
				bool flag = Local_newScen != CompareConfiguration();
				ConcurrentDictionary<int, Weapon> cache_Weapons = null;
				try
				{
					if (scenario_ != null)
					{
						cache_Weapons = scenario_.Cache_Weapons;
					}
					if (flag && CompareConfiguration() != null)
					{
						InsertConfiguration(null);
						ReleaseReferences();
						ItemExporter.ConnectInterruptibleTemplate.MainForm.ReleaseReferences();
						Command_Core.GlobalSingleton.GetInstance().Notification_Barks.Clear();
						GameGeneral.ReleaseReferences();
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 2009874", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				ReadConfiguration(Local_newScen);
				bool godsEye = false;
				if (CurrentSide != null)
				{
					godsEye = CurrentMapProfile.GodsEye;
				}
				if (flag & Local_CauseIsVCRPlayback)
				{
					CompareConfiguration().Cache_Weapons = cache_Weapons;
				}
				cache_Weapons = null;
				if (!flag)
				{
					return;
				}
				try
				{
					CompareConfiguration().GameContext = Local_theGameContext;
					if (Information.IsNothing(CompareConfiguration()))
					{
						GameGeneral.Debug_LastLoadedScenario = "N/A";
					}
					else
					{
						GameGeneral.Debug_LastLoadedScenario = CompareConfiguration().Title;
					}
					m_DescriptorRequest = null;
					Dispatcher.CurrentDispatcher.InvokeAsync(delegate
					{
						ItemExporter.ConnectInterruptibleTemplate.MainForm?.objectError?.VM?.DeleteInterruptibleRegistry();
					});
					if (scenario_ != null)
					{
						_ = ItemExporter.ConnectInterruptibleTemplate.MainForm.gclass5_0;
						if (ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Visible)
						{
							ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Close();
						}
						GameGeneral.DestroyPreviousScenario(ref scenario_, bool_1: true);
					}
					SelectThisUnit(null, bool_0: true);
					SelectedWaypoint = null;
					paramsClass = null;
					theCommsWindow = null;
					theSensorsWindow = null;
					theDamageControlWindow = null;
					ListConfiguration(null);
					NewMissionWindow = null;
					OpenMessageWindows = null;
					theCommsWindow = new UnitComms();
					theSensorsWindow = new UnitSensors();
					theDamageControlWindow = new DamageControlWindow();
					ListConfiguration(new BackgroundWorker());
					NewMissionWindow = new NewMission();
					OpenMessageWindows = new Dictionary<LoggedMessage.MessageType, NewMessageForm>();
					AutosaveCountdown = 20000.0;
					m_CallbackRequest = null;
					m_CallbackRequest = new Queue<string>();
					RunToThisTime = null;
					if (scenario_ != null)
					{
						scenario_.ReleaseReferences();
						scenario_ = null;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3?.Data.Add("Error at 2009873", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				bool bool_ = true;
				try
				{
					DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
					CurrentDB = DBOps.GetDBRecordByHash(CompareConfiguration().DBUsed, ref dbfileCheckResult_, bool_0: true, bool_);
					if (CurrentDB == null)
					{
						throw new Exception(DBOps.PublishImporter(dbfileCheckResult_));
					}
					Game._GameMode gameMode = CurrentGame.GameMode;
					CurrentGame.GameMode = gameMode;
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception exception_4 = ex4;
					exception_4?.Data.Add("Error at 200987432", exception_4.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				try
				{
					if (_CandidateClass)
					{
						CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
					}
					if (_CandidateClass)
					{
						ItemExporter.ConnectInterruptibleTemplate.MainForm.AdjustToScenActiveFeatureChanges();
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception exception_5 = ex5;
					exception_5?.Data.Add("Error at 200987218", exception_5.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_5);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				if (CurrentScenario == null)
				{
					return;
				}
				try
				{
					if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
					{
						MoveConfiguration(CurrentScenario);
					}
					if (Information.IsNothing(CompareConfiguration().GetCurrentSide()))
					{
						if (CompareConfiguration().Sides_ReadOnly.Any())
						{
							CurrentSide = CompareConfiguration().Sides_ReadOnly[0];
						}
						else
						{
							CurrentSide = null;
						}
					}
					else
					{
						Side currentSide = CompareConfiguration().GetCurrentSide();
						if (Local_CauseIsVCRPlayback)
						{
							CurrentMapProfile.GodsEye = godsEye;
						}
						CurrentSide = currentSide;
					}
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception exception_6 = ex6;
					exception_6?.Data.Add("Error at 200987432", exception_6.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				try
				{
					if (GameGeneral.TacviewPipeEnabled)
					{
						if (Local_CauseIsVCRPlayback)
						{
							if (ConfigurationRegistryFilter.PublishInterruptibleMap().Count > 0)
							{
								ConfigurationRegistryFilter.PublishInterruptibleMap()[0].Close();
							}
						}
						else
						{
							ConfigurationRegistryFilter.ListInterruptibleMap();
						}
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception exception_7 = ex7;
					exception_7?.Data.Add("Error at 200987721", exception_7.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_7);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				try
				{
					_ = ItemExporter.ConnectInterruptibleTemplate.MainForm.ElementHost_RightColumnWPF.Visible;
					if ((CurrentSide == null) | Local_CauseIsVCRPlayback)
					{
						MustRefreshMainForm = true;
					}
					else
					{
						if (CurrentSide.CameraAlt != 0.0)
						{
							ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = (int)Math.Round(CurrentSide.CameraAlt);
						}
						if (CurrentSide.MapCenter != null)
						{
							ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, CurrentSide.MapCenter);
						}
						if (CurrentSide.Units.FirstOrDefault() != null)
						{
							SelectThisUnit(CurrentSide.Units.FirstOrDefault(), bool_0: true);
							if (SelectedUnit != null)
							{
								ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
							}
						}
					}
					if (ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1 != null)
					{
						ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(CurrentScenario, CurrentSide, SelectedUnit, bool_0: false);
					}
				}
				catch (Exception ex8)
				{
					ProjectData.SetProjectError(ex8);
					Exception exception_8 = ex8;
					exception_8?.Data.Add("Error at 20098737443", exception_8.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_8);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				try
				{
					if (_CandidateClass)
					{
						ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshCaption();
					}
				}
				catch (Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					Exception exception_9 = ex9;
					exception_9?.Data.Add("Error at 200359", exception_9.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_9);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (CurrentGame.Status == Game._GameStatus.Running)
					{
						CurrentGame.Pause();
					}
					advisorRequest?.Invoke();
					CurrentScenario.Scenario_LuaSandbox = LuaSandbox;
					CurrentScenario.Scenario_LuaSandbox.RefreshStats(CurrentScenario);
					CurrentScenario.Initialize();
					if (!Local_CauseIsVCRPlayback)
					{
						Scenario currentScenario = CurrentScenario;
						string string_ = "";
						ValidateScenarioAreas(currentScenario, bool_0: false, ref string_);
					}
					StrategyRegistryFilter.SelectInterruptibleComparator(CurrentScenario);
					if (Local_CauseIsVCRPlayback)
					{
						IEnumerator enumerator = null;
						try
						{
							enumerator = ItemExporter.RevertInterruptibleMap.OpenForms.GetEnumerator();
							while (enumerator.MoveNext())
							{
								Form form = (Form)enumerator.Current;
								if (form is GInterface9 && form.Visible)
								{
									((GInterface9)form).RefreshForm();
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
					}
					if (SimConfiguration.DefaultGamePreferences.MessageLogInWindow && MainFormShownComplete)
					{
						ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshMessageLogWindowWPF();
					}
					iteratorClass = CurrentScenario.ActiveUnits.Count;
					ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshCaption();
				}
				catch (Exception ex10)
				{
					ProjectData.SetProjectError(ex10);
					Exception exception_10 = ex10;
					exception_10?.Data.Add("Error at 20098730098", exception_10.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_10);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 200516", exception_2.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	[CompilerGenerated]
	private sealed class ProxyMap
	{
		public Scenario object_;

		internal void LogoutInterruptiblePage()
		{
			ComputeConfiguration(object_);
		}
	}

	[CompilerGenerated]
	private sealed class ClientCollectionTask
	{
		public PlatformComponent Local_theComponent;

		internal bool ViewInterruptiblePage(Sensor theSensor)
		{
			return Operators.CompareString(theSensor.ObjectID, Local_theComponent.ObjectID, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ProxyProcessProducer
	{
		public Scenario Local_theScen;

		internal void ValidateInterruptiblePage(LoggedMessage theMess)
		{
			int num = IndexOf_Fast(Local_theScen.MessageLog, theMess);
			if (num >= 0)
			{
				interpreterRequest.Enqueue(num);
			}
		}
	}

	[CompilerGenerated]
	private sealed class RequestListenerMapping
	{
		public DateTime Local_ScenTime;

		public MemoryTributary Local_ScenClone;

		internal void LoginInterruptiblePage()
		{
			_DatabaseClass.QueueSnapshotToSave(Local_ScenTime, Local_ScenClone);
		}
	}

	[CompilerGenerated]
	private sealed class CodeDecoratorEntry
	{
		public WeaponSalvo.Shooter Local_theShooter;

		internal bool GetInterruptiblePage(ActiveUnit theUn)
		{
			if (theUn != null)
			{
				return Operators.CompareString(theUn.ObjectID, Local_theShooter.ShooterObjectID, TextCompare: true) == 0;
			}
			return false;
		}
	}

	public static Dispatcher Dispatcher;

	internal static DisplaySettings systemClass;

	internal static bool _CandidateClass;

	public static bool MustRefreshMainForm;

	public static Dictionary<string, Bitmap> MapSymbolBitmaps;

	[CompilerGenerated]
	[AccessedThroughProperty("_CurrentScenario")]
	private static Scenario m_BaseClass;

	internal static string _PolicyClass;

	[AccessedThroughProperty("_CurrentSide")]
	[CompilerGenerated]
	private static Side broadcasterClass;

	private static UserAction _IdentifierClass;

	private static UserAction printerClass;

	public static Zone AreaInPolygonDraw;

	internal static bool m_ParserClass;

	private static DBRecord algoClass;

	internal static RecorderTape _DatabaseClass;

	private static bool _InterceptorClass;

	internal static RecorderForm messageClass;

	internal static bool _ProductClass;

	private static bool annotationClass;

	internal static int iteratorClass;

	internal static float initializerClass;

	internal static double _RoleClass;

	internal static string m_FactoryClass;

	private static ThreadPriority _AttributeClass;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private static System.Windows.Forms.Timer m_EventClass;

	[AccessedThroughProperty("SteamDownloadCheckTimer")]
	[CompilerGenerated]
	private static System.Windows.Forms.Timer globalClass;

	private static bool m_WorkerClass;

	internal static ReferencePoint.OrientationType m_AccountClass;

	internal static float _StateClass;

	internal static string authenticationClass;

	private static Module_Unit.Unit paramsClass;

	internal static bool infoClass;

	internal static WorldWindow helperClass;

	public static int CloneScenarioInterval;

	private static int m_MapperClass;

	internal static Mount _ManagerClass;

	internal static WeaponSalvo getterClass;

	internal static int _ProducerClass;

	internal static ToolStrip procClass;

	private static bool structRequest;

	internal static Exception merchantRequest;

	internal static Queue<string> m_CallbackRequest;

	public static string SaveScenarioPath;

	private static Bitmap decoratorRequest;

	internal static object m_ProcessRequest;

	public static Dictionary<Image, IntPtr> Cache_GDIBitmapHandles;

	internal static Font m_ThreadRequest;

	public static Font CommandDefaultFont;

	public static DateTime? RunToThisTime;

	public static List<string> RecentFilenames;

	private static int ruleRequest;

	public static ReferencePoint SelectedRefPoint;

	public static List<Module_Unit.Unit> MapVisibleUnits;

	public static Dictionary<Module_Unit.Unit, Tuple<int, int>> MapVisibleUnit_ScreenCoords;

	public static List<Module_Unit.Unit> MapSelectableUnits;

	public static bool MainWindowsUseFullScreen;

	private static LuaSandBox collectionRequest;

	internal static Dictionary<string, Image> _InstanceRequest;

	internal static Dictionary<Image, Image> objectRequest;

	internal static Dictionary<Image, Image> parameterRequest;

	internal static Color _ExpressionRequest;

	internal static Color dispatcherRequest;

	internal static Color _ListenerRequest;

	internal static Color configRequest;

	internal static Color registryRequest;

	internal static Color m_DefinitionRequest;

	internal static Color _ValRequest;

	internal static Color m_WrapperRequest;

	private static MapProfile m_ObserverRequest;

	private static Waypoint _IssuerRequest;

	public static double GroupOpacity;

	public static byte GroupAlpha;

	public static byte SensorOpacity;

	public static double AutosaveCountdown;

	private static Lazy<WeaponsWindow> _ClientRequest;

	public static UnitSensors theSensorsWindow;

	public static UnitComms theCommsWindow;

	public static DamageControlWindow theDamageControlWindow;

	public static Magazines theMagazinesWindow;

	public static CampaignEditorWindow theCampaignEditorWindow;

	public static StartGameMenuWindow startGameMenuWindow_0;

	public static TimeUnderway theTimeUnderwayWindow;

	[AccessedThroughProperty("BW_ShowLoadingDB")]
	[CompilerGenerated]
	private static BackgroundWorker dicRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_Core_Pulse")]
	private static BackgroundWorker m_ConsumerRequest;

	public static NewMission NewMissionWindow;

	public static FlightPlanErrors FlightPlanErrorsWindow;

	public static FlightPlanTime FlightPlanTimeWindow;

	internal static string facadeRequest;

	internal static byte? _ProxyRequest;

	internal static int? m_ReaderRequest;

	private static bool _PropertyRequest;

	public static Dictionary<LoggedMessage.MessageType, NewMessageForm> OpenMessageWindows;

	public static Dispatcher MainThreadDispatcher;

	public static ElementHost theElementHostRightColumn;

	public static OrbitAnchor OrbitAnchorWindow;

	public static LicenseTweaker theLT;

	public static ScenarioFeatures ScenarioFeaturesWindow;

	public static List<Geopoint_Struct[]> LOS_ShadedArea;

	public static int LOS_HowManyThreads;

	public static bool LoadingTimerLock;

	public static bool ScenarioWasLoadedAsBlank;

	private static bool m_ImporterRequest;

	public static VisualIndicator @ref;

	private static FlightPlanAircraftLoadout repositoryRequest;

	private static FlightPlanEditorTargets _BridgeRequest;

	private static FlightPlanEditorTargetsArea _InvocationRequest;

	private static FlightPlanEditorTargetsPreliminary m_ClassRequest;

	private static FlightPlanEditorWeaponRoute requestRequest;

	private static AttackTarget m_ValueRequest;

	private static MissionEditor m_TokenizerRequest;

	private static ReferencePointManager stubRequest;

	private static AirTaskingOrder writerRequest;

	private static FlightPlanEditor _SpecificationRequest;

	internal static FloatingLicenseErrorForm _WatcherRequest;

	private static string m_ReponseRequest;

	private static Module_Unit.Unit m_DescriptorRequest;

	private static ActiveUnit m_PoolRequest;

	private static Contact _TaskRequest;

	private static KeysConverter filterRequest;

	private static HashSet<LoggedMessage> testsRequest;

	private static ConcurrentQueue<int> interpreterRequest;

	private static bool m_ContainerRequest;

	public static string FloatingLicenseErrorMessage;

	[AccessedThroughProperty("_CurrentScenario")]
	[CompilerGenerated]
	private static Scenario composerRequest;

	[CompilerGenerated]
	[AccessedThroughProperty("_CurrentSide")]
	private static Side m_ModelRequest;

	[CompilerGenerated]
	private static ScenarioChangingEventHandler advisorRequest;

	[CompilerGenerated]
	private static SelectedUnitChangedEventHandler customerRequest;

	[CompilerGenerated]
	private static SelectedWaypointChangedEventHandler m_SerializerRequest;

	[CompilerGenerated]
	private static SelectedUnitPreChangeEventHandler _RefRequest;

	[CompilerGenerated]
	private static SelectedWaypointPreChangeEventHandler _ErrorRequest;

	[CompilerGenerated]
	private static CurrentSideChangedEventHandler _CodeRequest;

	[CompilerGenerated]
	private static TimeAdvancedEventHandler m_ConnectionRequest;

	public static Game CurrentGame => composerRequest.GameContext;

	public static bool AddingDecoyPlatform
	{
		get
		{
			return m_ImporterRequest;
		}
		set
		{
			m_ImporterRequest = value;
			AddUnit.Unarmed = value;
		}
	}

	public static bool MainFormShownComplete
	{
		get
		{
			return structRequest;
		}
		set
		{
			structRequest = value;
			if (value && startGameMenuWindow_0 != null && startGameMenuWindow_0.IsVisible)
			{
				startGameMenuWindow_0.ShowButtons();
			}
		}
	}

	public static FlightPlanAircraftLoadout FlightPlanAircraftLoadoutWindow
	{
		get
		{
			if (repositoryRequest == null)
			{
				repositoryRequest = new FlightPlanAircraftLoadout();
			}
			return repositoryRequest;
		}
	}

	public static FlightPlanEditorTargets FlightPlanEditorTargetsWindow
	{
		get
		{
			if (Information.IsNothing(_BridgeRequest))
			{
				_BridgeRequest = new FlightPlanEditorTargets();
			}
			return _BridgeRequest;
		}
	}

	public static FlightPlanEditorTargetsArea FlightPlanEditorTargetsAreaWindow
	{
		get
		{
			if (Information.IsNothing(_InvocationRequest))
			{
				_InvocationRequest = new FlightPlanEditorTargetsArea();
			}
			return _InvocationRequest;
		}
	}

	public static FlightPlanEditorTargetsPreliminary FlightPlanEditorTargetsPreliminaryWindow
	{
		get
		{
			if (Information.IsNothing(m_ClassRequest))
			{
				m_ClassRequest = new FlightPlanEditorTargetsPreliminary();
			}
			return m_ClassRequest;
		}
	}

	public static FlightPlanEditorWeaponRoute FlightPlanEditorWeaponRouteWindow
	{
		get
		{
			if (Information.IsNothing(requestRequest))
			{
				requestRequest = new FlightPlanEditorWeaponRoute();
			}
			return requestRequest;
		}
	}

	public static AttackTarget WeapAllocWindow
	{
		get
		{
			if (Information.IsNothing(m_ValueRequest))
			{
				m_ValueRequest = new AttackTarget();
			}
			return m_ValueRequest;
		}
		set
		{
			m_ValueRequest = value;
		}
	}

	public static LuaSandBox LuaSandbox
	{
		get
		{
			if (Information.IsNothing(collectionRequest))
			{
				collectionRequest = new LuaSandBox();
			}
			return collectionRequest;
		}
		set
		{
			collectionRequest = value;
		}
	}

	public static MissionEditor MissionEditorWindow
	{
		get
		{
			if (Information.IsNothing(m_TokenizerRequest))
			{
				m_TokenizerRequest = new MissionEditor();
			}
			return m_TokenizerRequest;
		}
	}

	public static ReferencePointManager ReferencePointManagerWindow
	{
		get
		{
			if (Information.IsNothing(stubRequest))
			{
				stubRequest = new ReferencePointManager();
			}
			return stubRequest;
		}
	}

	public static AirTaskingOrder AirTaskingOrderWindow
	{
		get
		{
			if (Information.IsNothing(writerRequest))
			{
				writerRequest = new AirTaskingOrder();
			}
			return writerRequest;
		}
	}

	public static FlightPlanEditor FlightPlanEditorWindow
	{
		get
		{
			if (Information.IsNothing(_SpecificationRequest))
			{
				_SpecificationRequest = new FlightPlanEditor();
			}
			return _SpecificationRequest;
		}
		set
		{
			_SpecificationRequest = value;
		}
	}

	public static WeaponsWindow theWeaponsWindow => _ClientRequest.Value;

	public static bool RunningInSteamMode
	{
		get
		{
			return annotationClass;
		}
		set
		{
			annotationClass = value;
		}
	}

	public static DBRecord CurrentDB
	{
		get
		{
			return algoClass;
		}
		set
		{
			bool num = value != algoClass;
			DBRecord object_ = algoClass;
			algoClass = value;
			if (num)
			{
				DestroyConfiguration(object_);
			}
		}
	}

	public static Scenario CurrentScenario
	{
		get
		{
			if (composerRequest != null)
			{
				return composerRequest;
			}
			return composerRequest = new Scenario();
		}
	}

	public static Side CurrentSide
	{
		get
		{
			return m_ModelRequest;
		}
		set
		{
			Side modelRequest = m_ModelRequest;
			InsertConfiguration(value);
			if (modelRequest == value)
			{
				return;
			}
			SelectThisUnit(null, bool_0: true);
			if (modelRequest != null)
			{
				modelRequest.IsHumanControlled = false;
			}
			if (value != null)
			{
				value.IsHumanControlled = true;
				if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
				{
					value.ScrubMissions(composerRequest);
				}
				if (SimConfiguration.DefaultGamePreferences.UsePersonalMapProfile)
				{
					CurrentMapProfile = SimConfiguration.DefaultGamePreferences.PersonalMapProfile;
				}
				else
				{
					CurrentMapProfile = value.SideMapProfile;
				}
				try
				{
					ItemExporter.ConnectInterruptibleTemplate.MainForm.AdjustQuickJumpMenu();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				composerRequest.AddMessage("切换到分方：" + value.Name, "切换分方", LoggedMessage.MessageType.UI, 0, null);
			}
			CurrentUserAction = UserAction.None;
			_CodeRequest?.Invoke();
		}
	}

	public static MapProfile CurrentMapProfile
	{
		get
		{
			if (SimConfiguration.DefaultGamePreferences.UsePersonalMapProfile)
			{
				return SimConfiguration.DefaultGamePreferences.PersonalMapProfile;
			}
			if (m_ObserverRequest == null)
			{
				m_ObserverRequest = MapProfile.GetDefaultProfile();
			}
			return m_ObserverRequest;
		}
		set
		{
			m_ObserverRequest = value;
			try
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static Module_Unit.Unit SelectedUnit
	{
		get
		{
			try
			{
				if (string.IsNullOrEmpty(m_ReponseRequest))
				{
					m_DescriptorRequest = null;
					return null;
				}
				if (m_DescriptorRequest != null && string.CompareOrdinal(m_DescriptorRequest.ObjectID, m_ReponseRequest) == 0)
				{
					return m_DescriptorRequest;
				}
				if (composerRequest.ActiveUnits.TryGetValue(m_ReponseRequest, ref m_PoolRequest))
				{
					m_DescriptorRequest = m_PoolRequest;
					return m_PoolRequest;
				}
				if (!string.IsNullOrEmpty(CurrentMapProfile.String_0) && composerRequest.ActiveUnits.ContainsKey(CurrentMapProfile.String_0))
				{
					foreach (Contact item in Module_ActiveUnit_Sensory.ListTokenizer(composerRequest.ActiveUnits[CurrentMapProfile.String_0].Sensory))
					{
						if (string.CompareOrdinal(item.ObjectID, m_ReponseRequest) == 0)
						{
							m_DescriptorRequest = item;
							return item;
						}
					}
				}
				else if (m_ModelRequest != null)
				{
					int count = m_ModelRequest.Contacts.Count;
					List<Contact> contacts_List = m_ModelRequest.Contacts_List;
					int num = count - 1;
					for (int i = 0; i <= num; i++)
					{
						try
						{
							Contact contact = contacts_List[i];
							if (string.CompareOrdinal(contact.ObjectID, m_ReponseRequest) == 0)
							{
								m_DescriptorRequest = contact;
								return contact;
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
					}
					int count2 = m_ModelRequest.BaseContacts_List.Count;
					List<Contact> baseContacts_List = m_ModelRequest.BaseContacts_List;
					int num2 = count2 - 1;
					for (int j = 0; j <= num2; j++)
					{
						try
						{
							Contact contact2 = baseContacts_List[j];
							if (string.CompareOrdinal(contact2.ObjectID, m_ReponseRequest) == 0)
							{
								m_DescriptorRequest = contact2;
								return contact2;
							}
						}
						catch (Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							ProjectData.ClearProjectError();
						}
					}
				}
				return null;
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return null;
			}
		}
	}

	public static Waypoint SelectedWaypoint
	{
		get
		{
			return _IssuerRequest;
		}
		set
		{
			try
			{
				int num;
				if (!Information.IsNothing(value) && !Information.IsNothing(_IssuerRequest))
				{
					num = (((object)_IssuerRequest.ObjectID != value.ObjectID) ? 1 : 0);
					if (num == 0)
					{
						goto IL_005b;
					}
				}
				else
				{
					num = 1;
				}
				_ErrorRequest?.Invoke();
				goto IL_005b;
				IL_005b:
				_IssuerRequest = value;
				if (num != 0)
				{
					m_SerializerRequest?.Invoke(value);
				}
				MustRefreshMainForm = true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200629", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public static List<ReferencePoint> HighlightedRefPoints
	{
		get
		{
			if (Information.IsNothing(m_ModelRequest))
			{
				return null;
			}
			List<ReferencePoint> list = new List<ReferencePoint>();
			foreach (ReferencePoint refPoint in m_ModelRequest.RefPoints)
			{
				if (!Information.IsNothing(refPoint) && refPoint.IsHighlighted)
				{
					list.Add(refPoint);
				}
			}
			return list;
		}
	}

	public static UserAction CurrentUserAction
	{
		get
		{
			if (_IdentifierClass == UserAction.None)
			{
				return printerClass;
			}
			return _IdentifierClass;
		}
		set
		{
			UserAction identifierClass = _IdentifierClass;
			bool flag;
			if ((flag = _IdentifierClass != value) && (identifierClass == UserAction.PlottingCourse || value == UserAction.PlottingCourse))
			{
				bool playerIsPlottingCourse = value == UserAction.PlottingCourse;
				foreach (ActiveUnit item in GetSelectedActiveUnitsForCoursePlot())
				{
					item.PlayerIsPlottingCourse = playerIsPlottingCourse;
				}
			}
			_IdentifierClass = value;
			if (flag)
			{
				if (_IdentifierClass == UserAction.PlottingCourseForSalvo)
				{
					MustRefreshMainForm = true;
					WeapAllocWindow.Hide();
				}
				if (identifierClass == UserAction.PlottingCourseForSalvo && !WeapAllocWindow.IsDisposed)
				{
					WeapAllocWindow.RefreshForm();
					WeapAllocWindow.Show();
				}
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AdjustToUserActionChange();
			}
			AddingDecoyPlatform = false;
		}
	}

	public static UserAction CurrentUserAction_Hovering
	{
		get
		{
			return printerClass;
		}
		set
		{
			printerClass = value;
		}
	}

	public static event ScenarioChangingEventHandler ScenarioChanging
	{
		[CompilerGenerated]
		add
		{
			ScenarioChangingEventHandler scenarioChangingEventHandler = advisorRequest;
			ScenarioChangingEventHandler scenarioChangingEventHandler2;
			do
			{
				scenarioChangingEventHandler2 = scenarioChangingEventHandler;
				ScenarioChangingEventHandler value2 = (ScenarioChangingEventHandler)Delegate.Combine(scenarioChangingEventHandler2, value);
				scenarioChangingEventHandler = Interlocked.CompareExchange(ref advisorRequest, value2, scenarioChangingEventHandler2);
			}
			while ((object)scenarioChangingEventHandler != scenarioChangingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScenarioChangingEventHandler scenarioChangingEventHandler = advisorRequest;
			ScenarioChangingEventHandler scenarioChangingEventHandler2;
			do
			{
				scenarioChangingEventHandler2 = scenarioChangingEventHandler;
				ScenarioChangingEventHandler value2 = (ScenarioChangingEventHandler)Delegate.Remove(scenarioChangingEventHandler2, value);
				scenarioChangingEventHandler = Interlocked.CompareExchange(ref advisorRequest, value2, scenarioChangingEventHandler2);
			}
			while ((object)scenarioChangingEventHandler != scenarioChangingEventHandler2);
		}
	}

	public static event SelectedUnitChangedEventHandler SelectedUnitChanged
	{
		[CompilerGenerated]
		add
		{
			SelectedUnitChangedEventHandler selectedUnitChangedEventHandler = customerRequest;
			SelectedUnitChangedEventHandler selectedUnitChangedEventHandler2;
			do
			{
				selectedUnitChangedEventHandler2 = selectedUnitChangedEventHandler;
				SelectedUnitChangedEventHandler value2 = (SelectedUnitChangedEventHandler)Delegate.Combine(selectedUnitChangedEventHandler2, value);
				selectedUnitChangedEventHandler = Interlocked.CompareExchange(ref customerRequest, value2, selectedUnitChangedEventHandler2);
			}
			while ((object)selectedUnitChangedEventHandler != selectedUnitChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectedUnitChangedEventHandler selectedUnitChangedEventHandler = customerRequest;
			SelectedUnitChangedEventHandler selectedUnitChangedEventHandler2;
			do
			{
				selectedUnitChangedEventHandler2 = selectedUnitChangedEventHandler;
				SelectedUnitChangedEventHandler value2 = (SelectedUnitChangedEventHandler)Delegate.Remove(selectedUnitChangedEventHandler2, value);
				selectedUnitChangedEventHandler = Interlocked.CompareExchange(ref customerRequest, value2, selectedUnitChangedEventHandler2);
			}
			while ((object)selectedUnitChangedEventHandler != selectedUnitChangedEventHandler2);
		}
	}

	public static event SelectedWaypointChangedEventHandler SelectedWaypointChanged
	{
		[CompilerGenerated]
		add
		{
			SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler = m_SerializerRequest;
			SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler2;
			do
			{
				selectedWaypointChangedEventHandler2 = selectedWaypointChangedEventHandler;
				SelectedWaypointChangedEventHandler value2 = (SelectedWaypointChangedEventHandler)Delegate.Combine(selectedWaypointChangedEventHandler2, value);
				selectedWaypointChangedEventHandler = Interlocked.CompareExchange(ref m_SerializerRequest, value2, selectedWaypointChangedEventHandler2);
			}
			while ((object)selectedWaypointChangedEventHandler != selectedWaypointChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler = m_SerializerRequest;
			SelectedWaypointChangedEventHandler selectedWaypointChangedEventHandler2;
			do
			{
				selectedWaypointChangedEventHandler2 = selectedWaypointChangedEventHandler;
				SelectedWaypointChangedEventHandler value2 = (SelectedWaypointChangedEventHandler)Delegate.Remove(selectedWaypointChangedEventHandler2, value);
				selectedWaypointChangedEventHandler = Interlocked.CompareExchange(ref m_SerializerRequest, value2, selectedWaypointChangedEventHandler2);
			}
			while ((object)selectedWaypointChangedEventHandler != selectedWaypointChangedEventHandler2);
		}
	}

	public static event SelectedUnitPreChangeEventHandler SelectedUnitPreChange
	{
		[CompilerGenerated]
		add
		{
			SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler = _RefRequest;
			SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler2;
			do
			{
				selectedUnitPreChangeEventHandler2 = selectedUnitPreChangeEventHandler;
				SelectedUnitPreChangeEventHandler value2 = (SelectedUnitPreChangeEventHandler)Delegate.Combine(selectedUnitPreChangeEventHandler2, value);
				selectedUnitPreChangeEventHandler = Interlocked.CompareExchange(ref _RefRequest, value2, selectedUnitPreChangeEventHandler2);
			}
			while ((object)selectedUnitPreChangeEventHandler != selectedUnitPreChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler = _RefRequest;
			SelectedUnitPreChangeEventHandler selectedUnitPreChangeEventHandler2;
			do
			{
				selectedUnitPreChangeEventHandler2 = selectedUnitPreChangeEventHandler;
				SelectedUnitPreChangeEventHandler value2 = (SelectedUnitPreChangeEventHandler)Delegate.Remove(selectedUnitPreChangeEventHandler2, value);
				selectedUnitPreChangeEventHandler = Interlocked.CompareExchange(ref _RefRequest, value2, selectedUnitPreChangeEventHandler2);
			}
			while ((object)selectedUnitPreChangeEventHandler != selectedUnitPreChangeEventHandler2);
		}
	}

	public static event SelectedWaypointPreChangeEventHandler SelectedWaypointPreChange
	{
		[CompilerGenerated]
		add
		{
			SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler = _ErrorRequest;
			SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler2;
			do
			{
				selectedWaypointPreChangeEventHandler2 = selectedWaypointPreChangeEventHandler;
				SelectedWaypointPreChangeEventHandler value2 = (SelectedWaypointPreChangeEventHandler)Delegate.Combine(selectedWaypointPreChangeEventHandler2, value);
				selectedWaypointPreChangeEventHandler = Interlocked.CompareExchange(ref _ErrorRequest, value2, selectedWaypointPreChangeEventHandler2);
			}
			while ((object)selectedWaypointPreChangeEventHandler != selectedWaypointPreChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler = _ErrorRequest;
			SelectedWaypointPreChangeEventHandler selectedWaypointPreChangeEventHandler2;
			do
			{
				selectedWaypointPreChangeEventHandler2 = selectedWaypointPreChangeEventHandler;
				SelectedWaypointPreChangeEventHandler value2 = (SelectedWaypointPreChangeEventHandler)Delegate.Remove(selectedWaypointPreChangeEventHandler2, value);
				selectedWaypointPreChangeEventHandler = Interlocked.CompareExchange(ref _ErrorRequest, value2, selectedWaypointPreChangeEventHandler2);
			}
			while ((object)selectedWaypointPreChangeEventHandler != selectedWaypointPreChangeEventHandler2);
		}
	}

	public static event CurrentSideChangedEventHandler CurrentSideChanged
	{
		[CompilerGenerated]
		add
		{
			CurrentSideChangedEventHandler currentSideChangedEventHandler = _CodeRequest;
			CurrentSideChangedEventHandler currentSideChangedEventHandler2;
			do
			{
				currentSideChangedEventHandler2 = currentSideChangedEventHandler;
				CurrentSideChangedEventHandler value2 = (CurrentSideChangedEventHandler)Delegate.Combine(currentSideChangedEventHandler2, value);
				currentSideChangedEventHandler = Interlocked.CompareExchange(ref _CodeRequest, value2, currentSideChangedEventHandler2);
			}
			while ((object)currentSideChangedEventHandler != currentSideChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CurrentSideChangedEventHandler currentSideChangedEventHandler = _CodeRequest;
			CurrentSideChangedEventHandler currentSideChangedEventHandler2;
			do
			{
				currentSideChangedEventHandler2 = currentSideChangedEventHandler;
				CurrentSideChangedEventHandler value2 = (CurrentSideChangedEventHandler)Delegate.Remove(currentSideChangedEventHandler2, value);
				currentSideChangedEventHandler = Interlocked.CompareExchange(ref _CodeRequest, value2, currentSideChangedEventHandler2);
			}
			while ((object)currentSideChangedEventHandler != currentSideChangedEventHandler2);
		}
	}

	public static event TimeAdvancedEventHandler TimeAdvanced
	{
		[CompilerGenerated]
		add
		{
			TimeAdvancedEventHandler timeAdvancedEventHandler = m_ConnectionRequest;
			TimeAdvancedEventHandler timeAdvancedEventHandler2;
			do
			{
				timeAdvancedEventHandler2 = timeAdvancedEventHandler;
				TimeAdvancedEventHandler value2 = (TimeAdvancedEventHandler)Delegate.Combine(timeAdvancedEventHandler2, value);
				timeAdvancedEventHandler = Interlocked.CompareExchange(ref m_ConnectionRequest, value2, timeAdvancedEventHandler2);
			}
			while ((object)timeAdvancedEventHandler != timeAdvancedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TimeAdvancedEventHandler timeAdvancedEventHandler = m_ConnectionRequest;
			TimeAdvancedEventHandler timeAdvancedEventHandler2;
			do
			{
				timeAdvancedEventHandler2 = timeAdvancedEventHandler;
				TimeAdvancedEventHandler value2 = (TimeAdvancedEventHandler)Delegate.Remove(timeAdvancedEventHandler2, value);
				timeAdvancedEventHandler = Interlocked.CompareExchange(ref m_ConnectionRequest, value2, timeAdvancedEventHandler2);
			}
			while ((object)timeAdvancedEventHandler != timeAdvancedEventHandler2);
		}
	}

	[SpecialName]
	internal static string RemoveConfiguration()
	{
		return Path.Combine(GameGeneral.TopLevelWritablePath, "Scenarios", "Steam Workshop");
	}

	[SpecialName]
	internal static Module_Unit.Unit SetConfiguration()
	{
		return paramsClass;
	}

	[SpecialName]
	internal static void FillConfiguration(Module_Unit.Unit unit_0)
	{
		bool flag;
		if ((flag = ((!Information.IsNothing(paramsClass)) ? (paramsClass != unit_0) : (!Information.IsNothing(unit_0)))) && !Information.IsNothing(paramsClass) && paramsClass.DisableWriter() && ((Contact)paramsClass).IsFilteredOut)
		{
			MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		paramsClass = unit_0;
		if (flag)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_UI();
		}
		if (flag && !Information.IsNothing(paramsClass) && paramsClass.DisableWriter() && ((Contact)paramsClass).IsFilteredOut)
		{
			MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.UpdateHoverInfo(flag);
	}

	[SpecialName]
	internal static bool PopConfiguration()
	{
		return _InterceptorClass;
	}

	[SpecialName]
	internal static void InstantiateConfiguration(bool bool_0)
	{
		_InterceptorClass = bool_0;
		if (bool_0)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_Record.Checked = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_Record.Text = "停止录制";
			ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_Record.Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\Stop_16.gif");
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_Record.Checked = false;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_Record.Text = "录像";
			ItemExporter.ConnectInterruptibleTemplate.MainForm.TSB_Record.Image = Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Menu\\record_button_16.png");
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private static Scenario CompareConfiguration()
	{
		return composerRequest;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void ReadConfiguration(Scenario scenario_0)
	{
		composerRequest = scenario_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void InsertConfiguration(Side side_0)
	{
		m_ModelRequest = side_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void VisitConfiguration(System.Windows.Forms.Timer timer_0)
	{
		EventHandler value = SearchConfiguration;
		System.Windows.Forms.Timer eventClass = m_EventClass;
		if (eventClass != null)
		{
			eventClass.Tick -= value;
		}
		m_EventClass = timer_0;
		eventClass = m_EventClass;
		if (eventClass != null)
		{
			eventClass.Tick += value;
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void StopConfiguration(System.Windows.Forms.Timer timer_0)
	{
		EventHandler value = ConcatConfiguration;
		System.Windows.Forms.Timer timer = globalClass;
		if (timer != null)
		{
			timer.Tick -= value;
		}
		globalClass = timer_0;
		timer = globalClass;
		if (timer != null)
		{
			timer.Tick += value;
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void ListConfiguration(BackgroundWorker backgroundWorker_0)
	{
		dicRequest = backgroundWorker_0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void RunConfiguration(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = ViewConfiguration;
		RunWorkerCompletedEventHandler value2 = LoginConfiguration;
		BackgroundWorker consumerRequest = m_ConsumerRequest;
		if (consumerRequest != null)
		{
			consumerRequest.DoWork -= value;
			consumerRequest.RunWorkerCompleted -= value2;
		}
		m_ConsumerRequest = backgroundWorker_0;
		consumerRequest = m_ConsumerRequest;
		if (consumerRequest != null)
		{
			consumerRequest.DoWork += value;
			consumerRequest.RunWorkerCompleted += value2;
		}
	}

	static Client()
	{
		_CandidateClass = false;
		AreaInPolygonDraw = null;
		messageClass = new RecorderForm();
		authenticationClass = "";
		structRequest = false;
		m_ProcessRequest = RuntimeHelpers.GetObjectValue(new object());
		Cache_GDIBitmapHandles = new Dictionary<Image, IntPtr>();
		m_ThreadRequest = new Font("Verdana", 9f, FontStyle.Bold);
		CommandDefaultFont = new Font("微软雅黑", 9f, FontStyle.Regular);
		RecentFilenames = new List<string>();
		ruleRequest = 300;
		MapVisibleUnits = new List<Module_Unit.Unit>();
		MapVisibleUnit_ScreenCoords = new Dictionary<Module_Unit.Unit, Tuple<int, int>>();
		MapSelectableUnits = new List<Module_Unit.Unit>();
		_InstanceRequest = new Dictionary<string, Image>();
		objectRequest = new Dictionary<Image, Image>();
		parameterRequest = new Dictionary<Image, Image>();
		_ExpressionRequest = Color.FromArgb(255, 128, 224, 255);
		dispatcherRequest = Color.Yellow;
		_ListenerRequest = Color.FromArgb(255, 137, 254, 137);
		configRequest = Color.FromArgb(255, 255, 104, 1);
		registryRequest = Color.FromArgb(255, 219, 0, 0);
		m_DefinitionRequest = Color.FromArgb(75, Color.DodgerBlue);
		_ValRequest = Color.FromArgb(255, Color.White);
		m_WrapperRequest = Color.FromArgb(255, Color.White);
		GroupOpacity = 0.6;
		GroupAlpha = 100;
		SensorOpacity = 55;
		_ClientRequest = new Lazy<WeaponsWindow>();
		theMagazinesWindow = new Magazines();
		theCampaignEditorWindow = new CampaignEditorWindow();
		theTimeUnderwayWindow = new TimeUnderway();
		FlightPlanErrorsWindow = new FlightPlanErrors();
		FlightPlanTimeWindow = new FlightPlanTime();
		_PropertyRequest = false;
		OrbitAnchorWindow = new OrbitAnchor();
		theLT = new LicenseTweaker();
		LOS_HowManyThreads = Environment.ProcessorCount - 1;
		LoadingTimerLock = false;
		ScenarioWasLoadedAsBlank = false;
		m_ImporterRequest = false;
		_WatcherRequest = new FloatingLicenseErrorForm();
		filterRequest = new KeysConverter();
		testsRequest = new HashSet<LoggedMessage>();
		m_ContainerRequest = false;
	}

	public static string GetCustomIconPath(string string_0)
	{
		return Application.StartupPath + "\\Symbols\\Custom\\" + string_0;
	}

	[SpecialName]
	internal static Color GetColorFromStance(Misc.PostureStance postureStance_0)
	{
		if (1 == 0)
		{
		}
		Color result = postureStance_0 switch
		{
			Misc.PostureStance.Neutral => _ListenerRequest, 
			Misc.PostureStance.Friendly => _ExpressionRequest, 
			Misc.PostureStance.Unfriendly => configRequest, 
			Misc.PostureStance.Hostile => registryRequest, 
			Misc.PostureStance.Unknown => dispatcherRequest, 
			_ => default(Color), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private static void RegisterStrategy()
	{
		MustRefreshMainForm = true;
	}

	private static void ManageStrategy(string string_0)
	{
		FloatingLicenseErrorMessage = string_0;
	}

	public static void Initialize()
	{
		try
		{
			Dispatcher = Dispatcher.CurrentDispatcher;
			PlatformComponent.StatusChanged += CallConfiguration;
			ActiveUnit_Damage.DamageSustained += LogoutConfiguration;
			Scenario.CurrentSideChanged += PatchConfiguration;
			Scenario.SidesChanged += SelectConfiguration;
			Scenario.ScenCompleted += AddConfiguration;
			Scenario.CurrentScenarioChanged += CountConfiguration;
			Side.ScoreChanged += CheckConfiguration;
			SAO_OverlaySingle.UseMapOverlay += InitConfiguration;
			GameGeneral.CoreToUIMessage += CustomizeConfiguration;
			LuaSandbox.actionUIwindow += InterruptConfiguration;
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("初始化开始。");
			}
			Thread thread = new Thread(StrategyRegistryFilter.CallInterruptibleComparator);
			thread.Name = "DB Images download thread";
			thread.Priority = ThreadPriority.Lowest;
			thread.Start();
			VisitConfiguration(new System.Windows.Forms.Timer());
			m_EventClass.Interval = 1000;
			m_EventClass.Start();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.m_ValueConnection = null;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapState();
			if (!Directory.Exists(RemoveConfiguration()))
			{
				Directory.CreateDirectory(RemoveConfiguration());
			}
			if (!Directory.Exists(GameGeneral.AttachmentRepoPath))
			{
				Directory.CreateDirectory(GameGeneral.AttachmentRepoPath);
			}
			GameGeneral.CoreInitialize(bool_1: false);
			Licensing.Initialize(annotationClass);
			StrategyRegistryFilter.CloneInterruptibleComparator();
			ParseCustomICons();
			if (!Directory.Exists(GameGeneral.LogsPath))
			{
				Directory.CreateDirectory(GameGeneral.LogsPath);
			}
			OnStartForcedLocalChange.GetInstance().Apply();
			AuthenticationSingleton.NewInterruptibleSchema();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("成功初始化了Sim Core。");
			}
			if (RecordThreadBridge.InvokeInterruptibleConnection() && SimConfiguration.DefaultGamePreferences.AllowPowerPlanSwitch)
			{
				RecordThreadBridge.NewInterruptibleConnection();
				if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
				{
					GameGeneral.WriteLogDebugInfoToFile("成功切换到高性能电源计划。");
				}
			}
			DecoratorMerchantPage.RegisterGlobal();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("成功加载了Lua UI Handler。");
			}
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("成功创建了新推演。");
			}
			string text = SimConfiguration.DefaultDB_Hash;
			if (Information.IsNothing(text))
			{
				text = (SimConfiguration.DefaultDB_Hash = DBOps.GetHashForMostRecentVersionOfThisDB(1));
			}
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("成功设置数据库哈希值。");
			}
			if (Versioned.IsNumeric(text))
			{
				text = DBOps.GetHashForMostRecentVersionOfThisDB(Conversions.ToInteger(text));
			}
			try
			{
				RevertStrategy();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			try
			{
				SetCurrentScenario(new Scenario(text), bool_0: false);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				DarkMessageBox.ShowError("错误：" + exception_.Message + "\r\n" + exception_.StackTrace + "\r\n\r\nAborting...", "Error");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				try
				{
					ItemExporter.RevertInterruptibleMap.SortInterruptibleMap();
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("已成功完成设置当前想定。");
			}
			ConnectConfiguration();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("成功初始化了Lua。");
			}
			AutosaveCountdown = 20.0;
			CacheMapUnitSymbols();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("Successfully cached map symbols.");
			}
			CreateNewScenario();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("Successfully created new scenario.");
			}
			RunConfiguration(new BackgroundWorker());
			m_ConsumerRequest.WorkerSupportsCancellation = true;
			StopConfiguration(new System.Windows.Forms.Timer());
			globalClass.Interval = 60000;
			globalClass.Start();
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Show();
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Hide();
			if (SimConfiguration.DefaultGamePreferences.LogDebugInfoToFile)
			{
				GameGeneral.WriteLogDebugInfoToFile("初始化完成。");
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 200576", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ParseCustomICons(string string_0, int int_0, bool bool_0 = true)
	{
		if (FileExistsNative.FileExistsFast(GameGeneral.CustomIconPath + string_0))
		{
			GameGeneral.CustomIconCollection.Add(int_0, new Dictionary<GlobalVariables.ActiveUnitType, Dictionary<int, GameGeneral.CustomIconWrapper>>());
			GameGeneral.CustomIconCollection_Parent.Add(int_0, new Dictionary<GlobalVariables.ActiveUnitType, GameGeneral.CustomIconWrapper>());
			IEnumerator enumerator = null;
			try
			{
				enumerator = Enum.GetValues(typeof(GlobalVariables.ActiveUnitType)).GetEnumerator();
				while (enumerator.MoveNext())
				{
					GlobalVariables.ActiveUnitType key = (GlobalVariables.ActiveUnitType)Conversions.ToByte(enumerator.Current);
					GameGeneral.CustomIconCollection[int_0].Add(key, new Dictionary<int, GameGeneral.CustomIconWrapper>());
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			new OpenFileDialog();
			string[] array = Strings.Split(new StreamReader(GameGeneral.CustomIconPath + string_0).ReadToEnd().Replace("\r", "\r\n").Replace("\n", "\r\n"), "\r\n", -1, CompareMethod.Text);
			string[] array3 = array;
			foreach (string text in array3)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				string[] array2 = Strings.Split(text, ";", -1, CompareMethod.Text);
				if (array2.Count() < 3)
				{
					continue;
				}
				string left = array2[0].ToLower();
				int result;
				if (Operators.CompareString(array2[1], "*", TextCompare: true) == 0)
				{
					result = -1;
				}
				else if (!int.TryParse(array2[1], out result))
				{
					continue;
				}
				string text2 = array2[2];
				int result2 = -1;
				if (array2.Count() > 3)
				{
					int.TryParse(array2[3], out result2);
				}
				bool bool_ = false;
				if (array2.Count() > 4 && Operators.CompareString(array2[4].ToLower(), "rot", TextCompare: true) == 0)
				{
					bool_ = true;
				}
				GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
				if (Operators.CompareString(left, "#ship", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Ship;
				}
				else if (Operators.CompareString(left, "#aircraft", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Aircraft;
				}
				else if (Operators.CompareString(left, "#vehicle", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Vehicle;
				}
				else if (Operators.CompareString(left, "#facility", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Facility;
				}
				else if (Operators.CompareString(left, "#submarine", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Submarine;
				}
				else if (Operators.CompareString(left, "#weapon", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Weapon;
				}
				else if (Operators.CompareString(left, "#satellite", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Satellite;
				}
				else if (Operators.CompareString(left, "#personnel", TextCompare: true) == 0)
				{
					activeUnitType = GlobalVariables.ActiveUnitType.Personnel;
				}
				if (result == -1)
				{
					if (!GameGeneral.CustomIconCollection_Parent[int_0].ContainsKey(activeUnitType))
					{
						GameGeneral.CustomIconCollection_Parent[int_0].Add(activeUnitType, new GameGeneral.CustomIconWrapper(text2, result2, bool_));
					}
				}
				else if (activeUnitType != 0 && FileExistsNative.FileExistsFast(GameGeneral.CustomIconPath + text2) && !GameGeneral.CustomIconCollection[int_0][activeUnitType].ContainsKey(result))
				{
					GameGeneral.CustomIconCollection[int_0][activeUnitType].Add(result, new GameGeneral.CustomIconWrapper(text2, result2, bool_));
				}
			}
		}
		else if (bool_0)
		{
			FileStream fileStream = File.Create(GameGeneral.CustomIconPath + string_0);
			new StreamWriter(fileStream).Close();
			fileStream.Dispose();
			ParseCustomICons(string_0, int_0, bool_0: false);
		}
	}

	public static void ParseCustomICons()
	{
		GameGeneral.CustomIconCollection.Clear();
		GameGeneral.CustomIconCollection_Parent.Clear();
		try
		{
			if (!Directory.Exists(GameGeneral.CustomIconPath))
			{
				Directory.CreateDirectory(GameGeneral.CustomIconPath);
			}
			ParseCustomICons("Associations_DB3000.csv", 1);
			ParseCustomICons("Associations_CWDB.csv", 2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("Failed to load and parse custom icons. Please check that you are running Command as administrator." + ex2.Message, "Error");
			ProjectData.ClearProjectError();
		}
	}

	private static void RevertStrategy()
	{
		List<string> list = new List<string>();
		list.Add("Nahimic");
		list.Add("NvidiaShare");
		list.Add("RivaTuner");
		list.Add("Raptr");
		list.Add("MSIAfterburn");
		List<string> list2 = new List<string>();
		List<int> list3 = new List<int>();
		Process[] processes = Process.GetProcesses();
		Process[] array = processes;
		foreach (Process process in array)
		{
			foreach (string item in list)
			{
				if (process.ProcessName.ToLower().Replace(" ", "").Trim()
					.Contains(item.ToLower().Replace(" ", "").Trim()) | item.ToLower().Replace(" ", "").Trim()
					.Contains(process.ProcessName.ToLower().Replace(" ", "").Trim()))
				{
					if (!list2.Contains(process.ProcessName))
					{
						list2.Add(process.ProcessName);
					}
					list3.Add(process.Id);
				}
			}
		}
		if (list2.Count <= 0)
		{
			return;
		}
		string text = null;
		foreach (string item2 in list2)
		{
			text = text + " " + item2 + Environment.NewLine;
		}
		DarkMessageBox.ShowWarning("These processes are known to cause instability/performance/UI glitches when running alongside Command! It is recommended to close them (either through their own UI or through Task Manager) before continuing. " + Environment.NewLine + text, "Warning");
		try
		{
			Exception exception_ = new Exception("WARNING: one or more program known for cause instability is running " + Environment.NewLine + text);
			GameGeneral.WriteExceptionsToLog(ref exception_);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static DialogResult WarnAboutDeletedMissionDependencies(Mission mission_0)
	{
		if ((mission_0.CreationMode == MissionCreationType.LandingPlanner || mission_0.CreationMode == MissionCreationType.Generated) && DarkMessageBox.ShowWarning("WARNING ! Deleting a generated mission may break inter-mission relationships. Do you want to proceed ?", "Deletion may break relationships", DarkDialogButton.YesNo) == DialogResult.No)
		{
			return DialogResult.No;
		}
		foreach (Mission mission in m_ModelRequest.Missions)
		{
			mission_0 = mission;
			foreach (KeyValuePair<Mission, Mission> item in mission_0.MissionStartTrigger_MissionCompleted)
			{
				if (Operators.CompareString(item.Key.ObjectID, mission_0.ObjectID, TextCompare: true) == 0 && DarkMessageBox.ShowWarning("WARNING ! A mission depends on the mission you are about to delete, this will break the relationship and could prevent " + item.Value.Name + " to ever start! Do you want to proceed ?", "Deletion breaks a relationship", DarkDialogButton.YesNo) == DialogResult.No)
				{
					return DialogResult.No;
				}
			}
		}
		return DialogResult.Yes;
	}

	private static void CountConfiguration(Scenario scenario_0)
	{
		SetCurrentScenario(scenario_0, bool_0: false);
	}

	private static void CustomizeConfiguration(string string_0, string string_1, object object_0, GameGeneral.MessageBoxMessageType messageBoxMessageType_0)
	{
		if (object_0 == null || m_ModelRequest == null || object_0 == m_ModelRequest)
		{
			switch (messageBoxMessageType_0)
			{
			case GameGeneral.MessageBoxMessageType.Information:
				DarkMessageBox.ShowInformation(string_0, string_1);
				break;
			case GameGeneral.MessageBoxMessageType.Warning:
				DarkMessageBox.ShowWarning(string_0, string_1);
				break;
			case GameGeneral.MessageBoxMessageType.ErrorMessage:
				DarkMessageBox.ShowError(string_0, string_1);
				break;
			}
		}
	}

	private static void CloneConfiguration(Game._GameStatus _GameStatus_0)
	{
		switch (_GameStatus_0)
		{
		case Game._GameStatus.Running:
			CurrentGame.Run();
			return;
		case Game._GameStatus.Paused:
			CurrentGame.Pause();
			return;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private static void ConnectConfiguration()
	{
		try
		{
			_ = composerRequest.Scenario_LuaSandbox;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError("无法加载Lua！错误：" + ex2.Message, "Error");
			ItemExporter.RevertInterruptibleMap.SortInterruptibleMap();
			ProjectData.ClearProjectError();
		}
	}

	public static void ReleaseReferences()
	{
		try
		{
			if (MapVisibleUnits != null)
			{
				MapVisibleUnits.Clear();
			}
			if (MapVisibleUnit_ScreenCoords != null)
			{
				MapVisibleUnit_ScreenCoords.Clear();
			}
			if (MapSelectableUnits != null)
			{
				MapSelectableUnits.Clear();
			}
			SelectedRefPoint = null;
			_ManagerClass = null;
			getterClass = null;
			ClearMessageLog();
			stubRequest?.ReleaseReferences();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetCurrentScenario(Scenario scenario_0, bool bool_0)
	{
		Game Local_theGameContext = new Game();
		if (composerRequest != null)
		{
			Local_theGameContext = composerRequest.GameContext;
		}
		Dispatcher.Invoke(delegate
		{
			try
			{
				Scenario scenario_ = CompareConfiguration();
				bool flag = scenario_0 != CompareConfiguration();
				ConcurrentDictionary<int, Weapon> cache_Weapons = null;
				try
				{
					if (scenario_ != null)
					{
						cache_Weapons = scenario_.Cache_Weapons;
					}
					if (flag && CompareConfiguration() != null)
					{
						InsertConfiguration(null);
						ReleaseReferences();
						ItemExporter.ConnectInterruptibleTemplate.MainForm.ReleaseReferences();
						Command_Core.GlobalSingleton.GetInstance().Notification_Barks.Clear();
						GameGeneral.ReleaseReferences();
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					exception_?.Data.Add("Error at 2009874", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw;
				}
				ReadConfiguration(scenario_0);
				bool godsEye = false;
				if (CurrentSide != null)
				{
					godsEye = CurrentMapProfile.GodsEye;
				}
				if (flag && bool_0)
				{
					CompareConfiguration().Cache_Weapons = cache_Weapons;
				}
				cache_Weapons = null;
				if (flag)
				{
					try
					{
						CompareConfiguration().GameContext = Local_theGameContext;
						if (Information.IsNothing(CompareConfiguration()))
						{
							GameGeneral.Debug_LastLoadedScenario = "N/A";
						}
						else
						{
							GameGeneral.Debug_LastLoadedScenario = CompareConfiguration().Title;
						}
						m_DescriptorRequest = null;
						Dispatcher.CurrentDispatcher.InvokeAsync(delegate
						{
							ItemExporter.ConnectInterruptibleTemplate.MainForm?.objectError?.VM?.DeleteInterruptibleRegistry();
						});
						if (scenario_ != null)
						{
							_ = ItemExporter.ConnectInterruptibleTemplate.MainForm.gclass5_0;
							if (ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Visible)
							{
								ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Close();
							}
							GameGeneral.DestroyPreviousScenario(ref scenario_, bool_1: true);
						}
						SelectThisUnit(null, bool_0: true);
						SelectedWaypoint = null;
						paramsClass = null;
						theCommsWindow = null;
						theSensorsWindow = null;
						theDamageControlWindow = null;
						ListConfiguration(null);
						NewMissionWindow = null;
						OpenMessageWindows = null;
						theCommsWindow = new UnitComms();
						theSensorsWindow = new UnitSensors();
						theDamageControlWindow = new DamageControlWindow();
						ListConfiguration(new BackgroundWorker());
						NewMissionWindow = new NewMission();
						OpenMessageWindows = new Dictionary<LoggedMessage.MessageType, NewMessageForm>();
						AutosaveCountdown = 20000.0;
						m_CallbackRequest = null;
						m_CallbackRequest = new Queue<string>();
						RunToThisTime = null;
						if (scenario_ != null)
						{
							scenario_.ReleaseReferences();
							scenario_ = null;
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 2009873", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
					bool bool_ = true;
					try
					{
						DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
						CurrentDB = DBOps.GetDBRecordByHash(CompareConfiguration().DBUsed, ref dbfileCheckResult_, bool_0: true, bool_);
						if (CurrentDB == null)
						{
							throw new Exception(DBOps.PublishImporter(dbfileCheckResult_));
						}
						Game._GameMode gameMode = CurrentGame.GameMode;
						CurrentGame.GameMode = gameMode;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception exception_3 = ex3;
						exception_3?.Data.Add("Error at 200987432", exception_3.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_3);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
					try
					{
						if (_CandidateClass)
						{
							CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
						}
						if (_CandidateClass)
						{
							ItemExporter.ConnectInterruptibleTemplate.MainForm.AdjustToScenActiveFeatureChanges();
						}
					}
					catch (Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						Exception exception_4 = ex4;
						exception_4?.Data.Add("Error at 200987218", exception_4.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw;
					}
					if (CurrentScenario != null)
					{
						try
						{
							if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
							{
								MoveConfiguration(CurrentScenario);
							}
							if (Information.IsNothing(CompareConfiguration().GetCurrentSide()))
							{
								if (CompareConfiguration().Sides_ReadOnly.Any())
								{
									CurrentSide = CompareConfiguration().Sides_ReadOnly[0];
								}
								else
								{
									CurrentSide = null;
								}
							}
							else
							{
								Side currentSide = CompareConfiguration().GetCurrentSide();
								if (bool_0)
								{
									CurrentMapProfile.GodsEye = godsEye;
								}
								CurrentSide = currentSide;
							}
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception exception_5 = ex5;
							exception_5?.Data.Add("Error at 200987432", exception_5.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_5);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw;
						}
						try
						{
							if (GameGeneral.TacviewPipeEnabled)
							{
								if (bool_0)
								{
									if (ConfigurationRegistryFilter.PublishInterruptibleMap().Count > 0)
									{
										ConfigurationRegistryFilter.PublishInterruptibleMap()[0].Close();
									}
								}
								else
								{
									ConfigurationRegistryFilter.ListInterruptibleMap();
								}
							}
						}
						catch (Exception ex6)
						{
							ProjectData.SetProjectError(ex6);
							Exception exception_6 = ex6;
							exception_6?.Data.Add("Error at 200987721", exception_6.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw;
						}
						try
						{
							_ = ItemExporter.ConnectInterruptibleTemplate.MainForm.ElementHost_RightColumnWPF.Visible;
							if (CurrentSide == null || bool_0)
							{
								MustRefreshMainForm = true;
							}
							else
							{
								if (CurrentSide.CameraAlt != 0.0)
								{
									ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = (int)Math.Round(CurrentSide.CameraAlt);
								}
								if (CurrentSide.MapCenter != null)
								{
									ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, CurrentSide.MapCenter);
								}
								if (CurrentSide.Units.FirstOrDefault() != null)
								{
									SelectThisUnit(CurrentSide.Units.FirstOrDefault(), bool_0: true);
									if (SelectedUnit != null)
									{
										ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
									}
								}
							}
							if (ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1 != null)
							{
								ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(CurrentScenario, CurrentSide, SelectedUnit, bool_0: false);
							}
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception exception_7 = ex7;
							exception_7?.Data.Add("Error at 20098737443", exception_7.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_7);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw;
						}
						try
						{
							if (_CandidateClass)
							{
								ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshCaption();
							}
						}
						catch (Exception ex8)
						{
							ProjectData.SetProjectError(ex8);
							Exception exception_8 = ex8;
							exception_8?.Data.Add("Error at 200359", exception_8.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_8);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (CurrentGame.Status == Game._GameStatus.Running)
							{
								CurrentGame.Pause();
							}
							advisorRequest?.Invoke();
							CurrentScenario.Scenario_LuaSandbox = LuaSandbox;
							CurrentScenario.Scenario_LuaSandbox.RefreshStats(CurrentScenario);
							CurrentScenario.Initialize();
							if (!bool_0)
							{
								Scenario currentScenario = CurrentScenario;
								string string_ = "";
								ValidateScenarioAreas(currentScenario, bool_0: false, ref string_);
							}
							StrategyRegistryFilter.SelectInterruptibleComparator(CurrentScenario);
							if (bool_0)
							{
								IEnumerator enumerator = null;
								try
								{
									enumerator = ItemExporter.RevertInterruptibleMap.OpenForms.GetEnumerator();
									while (enumerator.MoveNext())
									{
										Form form = (Form)enumerator.Current;
										if (form is GInterface9 && form.Visible)
										{
											((GInterface9)form).RefreshForm();
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
							}
							if (SimConfiguration.DefaultGamePreferences.MessageLogInWindow && MainFormShownComplete)
							{
								ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshMessageLogWindowWPF();
							}
							iteratorClass = CurrentScenario.ActiveUnits.Count;
							ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshCaption();
							return;
						}
						catch (Exception ex9)
						{
							ProjectData.SetProjectError(ex9);
							Exception exception_9 = ex9;
							exception_9?.Data.Add("Error at 20098730098", exception_9.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_9);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							throw;
						}
					}
				}
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10);
				Exception exception_10 = ex10;
				exception_10?.Data.Add("Error at 200516", exception_10.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_10);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		});
	}

	private static void MoveConfiguration(Scenario scenario_0)
	{
		int count = scenario_0.ActiveUnits.Count;
		List<ActiveUnit> activeUnits_List = scenario_0.ActiveUnits_List;
		if (count == 0)
		{
			return;
		}
		try
		{
			ActiveUnit activeUnit = null;
			for (int i = count - 1; i >= 0; i += -1)
			{
				activeUnit = activeUnits_List[i];
				if (activeUnit != null && activeUnit.ChanceOfAppearance != 0 && activeUnit.ChanceOfAppearance != 100 && GameGeneral.LockRandom_0.Next(0, 101) > activeUnit.ChanceOfAppearance)
				{
					scenario_0.DeleteUnitImmediately(activeUnit.ObjectID, bool_0: true, "Chance of appearance failed");
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ValidateScenarioAreas(Scenario scenario_0, bool bool_0, ref string string_0)
	{
		try
		{
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				foreach (NoNavZone noNavZone in side.NoNavZones)
				{
					string string_ = "";
					if (!ActiveUnit_Navigator.ValidateArea(ref noNavZone.Area, ref string_, side, scenario_0, "禁航区 '" + noNavZone.Description + "'"))
					{
						if (bool_0)
						{
							string_0 = string_0 + "    " + string_ + "\r\n";
						}
						else
						{
							DarkMessageBox.ShowWarning(string_ + "联系想定设计人员以解决问题。", "Warning");
						}
					}
				}
				foreach (ExclusionZone exclusionZone in side.ExclusionZones)
				{
					string string_2 = "";
					if (!ActiveUnit_Navigator.ValidateArea(ref exclusionZone.Area, ref string_2, side, scenario_0, "封锁区 '" + exclusionZone.Description + "'"))
					{
						if (bool_0)
						{
							string_0 = string_0 + "    " + string_2 + "\r\n";
						}
						else
						{
							DarkMessageBox.ShowWarning(string_2 + "联系想定设计人员以解决问题。", "Warning");
						}
					}
				}
				foreach (Mission mission in side.Missions)
				{
					string string_3 = "";
					if (mission.MissionClass == Mission._MissionClass.Patrol)
					{
						if (!ActiveUnit_Navigator.ValidateArea(ref ((Patrol)mission).PatrolArea, ref string_3, side, scenario_0, "巡逻任务 '" + mission.Name + "'"))
						{
							if (bool_0)
							{
								string_0 = string_0 + "    " + string_3 + "\r\n";
							}
							else
							{
								DarkMessageBox.ShowWarning(string_3 + "联系想定设计人员以解决问题。", "Warning");
							}
						}
					}
					else
					{
						if (mission.MissionClass == Mission._MissionClass.Support)
						{
							continue;
						}
						if (mission.MissionClass == Mission._MissionClass.Mining)
						{
							if (!ActiveUnit_Navigator.ValidateArea(ref ((MiningMission)mission).Area, ref string_3, side, scenario_0, "布雷任务 '" + mission.Name + "'"))
							{
								if (bool_0)
								{
									string_0 = string_0 + "    " + string_3 + "\r\n";
								}
								else
								{
									DarkMessageBox.ShowWarning(string_3 + "联系想定设计人员以解决问题。", "Warning");
								}
							}
						}
						else if (mission.MissionClass == Mission._MissionClass.MineClearing && !ActiveUnit_Navigator.ValidateArea(ref ((MineClearingMission)mission).Area, ref string_3, side, scenario_0, "扫雷任务 '" + mission.Name + "'"))
						{
							if (bool_0)
							{
								string_0 = string_0 + "    " + string_3 + "\r\n";
							}
							else
							{
								DarkMessageBox.ShowWarning(string_3 + "联系想定设计人员以解决问题。", "Warning");
							}
						}
					}
				}
			}
			foreach (EventTrigger value in scenario_0.EventTriggers.Values)
			{
				switch (value.Type)
				{
				case EventTrigger.EventTriggerType.UnitEntersArea:
				{
					string string_5 = "";
					if (!ActiveUnit_Navigator.ValidateArea(ref ((EventTrigger_UnitEntersArea)value).Area, ref string_5, null, scenario_0, "单元驻留区域触发 '" + value.Description + "'"))
					{
						if (bool_0)
						{
							string_0 = string_0 + "    " + string_5 + "\r\n";
						}
						else
						{
							DarkMessageBox.ShowWarning(string_5 + "联系想定设计人员以解决问题。", "Warning");
						}
					}
					break;
				}
				case EventTrigger.EventTriggerType.UnitRemainsInArea:
				{
					string string_4 = "";
					if (!ActiveUnit_Navigator.ValidateArea(ref ((EventTrigger_UnitRemainsInArea)value).Area, ref string_4, null, scenario_0, "单元驻留区域触发 '" + value.Description + "'"))
					{
						if (bool_0)
						{
							string_0 = string_0 + "    " + string_4 + "\r\n";
						}
						else
						{
							DarkMessageBox.ShowWarning(string_4 + "联系想定设计人员以解决问题。", "Warning");
						}
					}
					break;
				}
				}
			}
			foreach (EventAction value2 in scenario_0.EventActions.Values)
			{
				if (value2.Type != EventAction.EventActionType.TeleportInArea)
				{
					continue;
				}
				string string_6 = "";
				if (!ActiveUnit_Navigator.ValidateArea(ref ((EventAction_TeleportInArea)value2).Area, ref string_6, null, scenario_0, "传送到区域动作 '" + value2.Description + "'"))
				{
					if (bool_0)
					{
						string_0 = string_0 + "    " + string_6 + "\r\n";
					}
					else
					{
						DarkMessageBox.ShowInformation(string_6 + "联系想定设计人员以解决问题。", "");
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101269", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void DeleteConfiguration()
	{
	}

	public static void AssignToMission(object object_0, IEnumerable<ActiveUnit> ienumerable_0, ref Mission mission_0, ref bool bool_0)
	{
		foreach (ActiveUnit item in ienumerable_0)
		{
			ActiveUnit activeUnit_ = item;
			ActiveUnit activeUnit = activeUnit_;
			Scenario scenario_ = composerRequest;
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult = activeUnit.CollectIssuer(ref scenario_, ref activeUnit_, ref mission_0, ref bool_0);
			if (missionAssignmentAttemptResult == Mission.MissionAssignmentAttemptResult.Success)
			{
				StringBuilder stringBuilder = activeUnit_.Doctrine.WriteRepository(mission_0.Doctrine, composerRequest, bool_0: true);
				if (stringBuilder.Length > 0)
				{
					DarkMessageBox.ShowWarning(activeUnit_.Name + "被指定给任务，然而" + (string)Interaction.IIf(activeUnit_.IsGroup, "Group", "Unit") + " 条令可能与任务条令冲突：" + stringBuilder.ToString() + ".", "可能存在条令冲突");
				}
			}
			else
			{
				DarkMessageBox.ShowWarning("无法将单元 " + activeUnit_.Name + " 指定给任务。原因：" + Misc.SortRequest(missionAssignmentAttemptResult), "无法指定任务");
			}
		}
		mission_0.TimeSincePlayerNotification = 0;
		MustRefreshMainForm = true;
	}

	public static void SelectMultipleUnits(List<Module_Unit.Unit> list_0)
	{
		if (list_0.Count == 0 || m_ModelRequest == null)
		{
			return;
		}
		if (list_0.Count == 1)
		{
			SelectThisUnit(list_0[list_0.Count - 1], bool_0: true);
			return;
		}
		m_ModelRequest.SelectedUnits_Clear(bool_0: false);
		foreach (Module_Unit.Unit item in list_0)
		{
			m_ModelRequest.SelectedUnits_Add(item, bool_0: false);
		}
		m_ModelRequest.RaiseSelectedUnitsChanged();
		SetHookedUnit(bool_0: true, list_0[0]);
		if (!list_0[0].IsGroup && !Information.IsNothing(list_0[0].GetUnitSide()))
		{
			if (list_0[0].GetUnitSide() == m_ModelRequest)
			{
				if (theSensorsWindow.Visible)
				{
					theSensorsWindow.BuildForm();
				}
				if (theWeaponsWindow.Visible)
				{
					theWeaponsWindow.BuildForm();
				}
				if (theCommsWindow.Visible)
				{
					theCommsWindow.BuildForm();
				}
			}
			else
			{
				if (theSensorsWindow.Visible)
				{
					theSensorsWindow.Visible = false;
				}
				if (theWeaponsWindow.Visible)
				{
					theWeaponsWindow.Visible = false;
				}
				if (theCommsWindow.Visible)
				{
					theCommsWindow.Visible = false;
				}
			}
		}
		if (SelectedUnit.GetUnitSide() == m_ModelRequest)
		{
			Side modelRequest = m_ModelRequest;
			Module_Unit.Unit selectedUnit = SelectedUnit;
			string string_ = null;
			if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0) && SelectedUnit.IsActiveUnit)
			{
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Flight = null;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Mission = null;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
			}
		}
		MustRefreshMainForm = true;
	}

	public static void SelectThisUnit(Module_Unit.Unit unit_0, bool bool_0, bool bool_1 = true)
	{
		checked
		{
			try
			{
				if (m_ModelRequest == null)
				{
					return;
				}
				if (unit_0 == null)
				{
					foreach (Module_Unit.Unit selectedUnit2 in m_ModelRequest.SelectedUnits)
					{
						if (selectedUnit2.IsActiveUnit)
						{
							ActiveUnit activeUnit = (ActiveUnit)selectedUnit2;
							if (activeUnit.Navigator.HasPlottedCourse() && activeUnit.Navigator.PlottedCourse.Contains(_IssuerRequest))
							{
								return;
							}
						}
						if (selectedUnit2.IsActiveUnit)
						{
							ActiveUnit activeUnit2 = (ActiveUnit)selectedUnit2;
							if (activeUnit2.Navigator.HasFlightPlan && activeUnit2.Navigator.GetFlight().FlightPlan.Contains(_IssuerRequest))
							{
								return;
							}
						}
					}
				}
				if (bool_0)
				{
					m_ModelRequest.SelectedUnits_Clear();
				}
				if (unit_0 != null)
				{
					m_ModelRequest.SelectedUnits_Add(unit_0);
				}
				if (bool_0)
				{
					SetHookedUnit(bool_0, unit_0);
					if (_IssuerRequest != null && unit_0 != null && unit_0.IsActiveUnit)
					{
						ActiveUnit activeUnit3 = (ActiveUnit)unit_0;
						Waypoint[] plottedCourse = activeUnit3.Navigator.PlottedCourse;
						for (int i = 0; i < plottedCourse.Length; i++)
						{
							if (plottedCourse[i] == _IssuerRequest)
							{
								bool_1 = false;
								break;
							}
						}
						if (bool_1 & activeUnit3.Navigator.HasFlightPlan)
						{
							Waypoint[] flightPlan = activeUnit3.Navigator.GetFlight().FlightPlan;
							for (int j = 0; j < flightPlan.Length; j++)
							{
								if (flightPlan[j] == _IssuerRequest)
								{
									bool_1 = false;
									break;
								}
							}
						}
					}
					if (bool_1)
					{
						SelectedWaypoint = null;
					}
				}
				if (unit_0 == null)
				{
					if (ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Visible)
					{
						ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Hide();
					}
				}
				else
				{
					if (!unit_0.IsGroup && !Information.IsNothing(unit_0.GetUnitSide()))
					{
						if (unit_0.GetUnitSide() == m_ModelRequest)
						{
							if (theSensorsWindow.Visible)
							{
								theSensorsWindow.BuildForm();
							}
							if (theWeaponsWindow.Visible)
							{
								theWeaponsWindow.BuildForm();
							}
							if (theCommsWindow.Visible)
							{
								theCommsWindow.BuildForm();
							}
						}
						else
						{
							if (theSensorsWindow.Visible)
							{
								theSensorsWindow.Visible = false;
							}
							if (theWeaponsWindow.Visible)
							{
								theWeaponsWindow.Visible = false;
							}
							if (theCommsWindow.Visible)
							{
								theCommsWindow.Visible = false;
							}
						}
					}
					if (SelectedUnit != null && SelectedUnit.GetUnitSide() == m_ModelRequest)
					{
						Side modelRequest = m_ModelRequest;
						Module_Unit.Unit selectedUnit = SelectedUnit;
						string string_ = null;
						if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0) && SelectedUnit.IsActiveUnit)
						{
							ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
							ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
							ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Flight = null;
							ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Mission = null;
							ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
						}
					}
				}
				MustRefreshMainForm = true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200587", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	[SpecialName]
	private static void SetHookedUnit(bool bool_0, Module_Unit.Unit unit_0)
	{
		Module_Unit.Unit selectedUnit = SelectedUnit;
		bool flag;
		if (flag = unit_0 == null || selectedUnit == null || (object)selectedUnit.ObjectID != unit_0.ObjectID)
		{
			_RefRequest?.Invoke();
		}
		Module_Unit.Unit unit_ = selectedUnit;
		if (unit_0 != null)
		{
			m_ReponseRequest = unit_0.ObjectID;
		}
		if (flag)
		{
			customerRequest?.Invoke(unit_0);
			if (GameGeneral.TacviewPipeEnabled && unit_0 != null)
			{
				ConfigurationRegistryFilter.PostInterruptibleMap();
			}
		}
		if (bool_0 && flag && structRequest)
		{
			try
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.AddInterruptibleIndexer(unit_0, unit_);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		if (unit_0 != null && flag)
		{
			if (ItemExporter.ConnectInterruptibleTemplate.InternalDBViewer.Visible)
			{
				if (SelectedUnit == null)
				{
					return;
				}
				ActiveUnit activeUnit = null;
				if (SelectedUnit.IsActiveUnit)
				{
					activeUnit = (ActiveUnit)SelectedUnit;
				}
				if (SelectedUnit.DisableWriter() && ((Contact)SelectedUnit).IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
				{
					activeUnit = ((Contact)SelectedUnit).ActualUnit;
				}
				if (SelectedUnit.IsGroup && ((Group)SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					activeUnit = ((Group)SelectedUnit).Units.Values.ElementAtOrDefault(0);
				}
				if (activeUnit != null)
				{
					smethod_1(activeUnit);
				}
			}
			if (!_PropertyRequest)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Slide_RC_In();
				_PropertyRequest = true;
			}
		}
		if (unit_0 == null)
		{
			m_ReponseRequest = null;
		}
		MustRefreshMainForm = true;
	}

	public static void smethod_0(string string_0, int int_0, string string_1 = null)
	{
		DBViewer.OpenNewDatabaseWindow(string_0, int_0, string_1);
	}

	public static void smethod_1(ActiveUnit activeUnit_0, string string_0 = null)
	{
		string text = "";
		if (!Information.IsNothing(activeUnit_0) && !activeUnit_0.IsGroup)
		{
			if (activeUnit_0.IsAircraft)
			{
				text = "飞机";
			}
			else if (activeUnit_0.IsShip)
			{
				text = "舰船";
			}
			else if (activeUnit_0.IsSubmarine)
			{
				text = "潜艇";
			}
			else if (activeUnit_0.IsFacility)
			{
				text = "设施";
			}
			else if (activeUnit_0.IsMobileGroundUnit)
			{
				text = "地面单元";
			}
			else if (activeUnit_0.IsSatellite)
			{
				text = "卫星";
			}
			else if (activeUnit_0.IsWeapon)
			{
				text = "武器";
			}
			InternalDBViewer lastOpenedDBViewer = GlobalSingleton.GetInstance().GetLastOpenedDBViewer();
			if (lastOpenedDBViewer != null && !ItemExporter.RegisterInterruptibleMap.Keyboard.CtrlKeyDown)
			{
				lastOpenedDBViewer.HighlightTarget = string_0;
				lastOpenedDBViewer.DisplayDataBaseEntry(activeUnit_0.DBID, text);
			}
			else
			{
				DBViewer.OpenNewDatabaseWindow(text, activeUnit_0.DBID, string_0);
			}
		}
	}

	private static void AddConfiguration(object object_0)
	{
		if (composerRequest == object_0 && composerRequest.Sides_ReadOnly.Length != 0)
		{
			m_WorkerClass = true;
		}
	}

	public static void ShutdownCleanup()
	{
		if (!Information.IsNothing(m_ConsumerRequest))
		{
			m_ConsumerRequest.CancelAsync();
		}
	}

	public static void ProcessNewTurn(int int_0)
	{
		try
		{
			SetupConfiguration(int_0);
			if (CurrentGame == null || CurrentGame.Status != Game._GameStatus.Running)
			{
				return;
			}
			ExcludeConfiguration();
			if (m_ConsumerRequest.IsBusy)
			{
				return;
			}
			if (GameGeneral.CatastrophicCoreException == null)
			{
				m_ConsumerRequest.RunWorkerAsync();
				return;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw GameGeneral.CatastrophicCoreException;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			try
			{
				exception_?.Data.Add("Error at 200593", exception_.Message);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void DestroyConfiguration(object object_0)
	{
		if (!Information.IsNothing(object_0))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.DBMenu_Build();
		}
		MustRefreshMainForm = true;
	}

	public static void CacheMapUnitSymbols()
	{
		_InstanceRequest.Clear();
		objectRequest.Clear();
		parameterRequest.Clear();
		Dictionary<string, Bitmap> dictionary = new Dictionary<string, Bitmap>();
		string text = "";
		switch (SimConfiguration.DefaultGamePreferences.MapSymbolsSet)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case Game.GamePreferences.MapSymbolsSetting.NTDS:
			text = "NTDS";
			break;
		case Game.GamePreferences.MapSymbolsSetting.Stylized:
			text = "Stylized";
			break;
		case Game.GamePreferences.MapSymbolsSetting.Directional:
			text = "Directional";
			break;
		}
		string[] files = Directory.GetFiles(GlobalVariables.ApplicationStartupPath + "\\Symbols\\" + text);
		string[] array = files;
		foreach (string text2 in array)
		{
			if (text2.EndsWith(".png") | text2.EndsWith(".gif"))
			{
				Bitmap bitmap = new Bitmap(new Bitmap(text2));
				Bitmap value = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format32bppArgb);
				dictionary.Add(Path.GetFileName(text2), value);
			}
		}
		if (SimConfiguration.DefaultGamePreferences.MapSymbolsSet == Game.GamePreferences.MapSymbolsSetting.Directional)
		{
			files = Directory.GetFiles(GlobalVariables.ApplicationStartupPath + "\\Symbols\\Stylized");
			string[] array2 = files;
			foreach (string text3 in array2)
			{
				if ((text3.EndsWith(".png") | text3.EndsWith(".gif")) && !dictionary.ContainsKey(Path.GetFileName(text3)))
				{
					decoratorRequest = (Bitmap)Image.FromFile(text3);
					dictionary.Add(Path.GetFileName(text3), decoratorRequest);
				}
			}
		}
		MapSymbolBitmaps = dictionary;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.m_ValueConnection = dictionary["hosted_units.png"];
	}

	private static void ComputeConfiguration(object object_0)
	{
		if (object_0 != composerRequest)
		{
			return;
		}
		CurrentSide = composerRequest.GetCurrentSide();
		if (m_ModelRequest != null)
		{
			try
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSL_Status.Text = "切换到分方：" + m_ModelRequest.Name;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.objectError.VM.MoveInterruptibleRegistry();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			MustRefreshMainForm = true;
		}
	}

	private static void PatchConfiguration(Scenario scenario_0)
	{
		if (Thread.CurrentThread.ManagedThreadId == Dispatcher.Thread.ManagedThreadId)
		{
			ComputeConfiguration(scenario_0);
			return;
		}
		Dispatcher.Invoke(delegate
		{
			ComputeConfiguration(scenario_0);
		});
	}

	private static void SelectConfiguration(object object_0, Scenario.SideAdditionOrRemoval sideAdditionOrRemoval_0)
	{
		if (sideAdditionOrRemoval_0 == Scenario.SideAdditionOrRemoval.Removal && !composerRequest.Sides_ReadOnly.Contains(m_ModelRequest))
		{
			if (composerRequest.Sides_ReadOnly.Length == 0)
			{
				composerRequest.SetCurrentSide(null);
			}
			else
			{
				composerRequest.SetCurrentSide(composerRequest.Sides_ReadOnly[0]);
			}
		}
		if (composerRequest.Sides_ReadOnly.Length == 1)
		{
			composerRequest.SetCurrentSide(composerRequest.Sides_ReadOnly[0]);
		}
	}

	public static void AdjustForUnitSelectionChanges()
	{
		if (Information.IsNothing(m_ModelRequest) || Information.IsNothing(composerRequest) || Information.IsNothing(m_ModelRequest.SelectedUnits))
		{
			return;
		}
		if (!m_ModelRequest.SelectedUnits.Contains(SelectedUnit))
		{
			SelectThisUnit(null, bool_0: true);
		}
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && (((ActiveUnit)selectedUnit).IsDestroyed || !((ActiveUnit)selectedUnit).IsOperating()))
			{
				list.Add(selectedUnit);
			}
		}
		foreach (Module_Unit.Unit item in list)
		{
			m_ModelRequest.SelectedUnits_Remove(item);
		}
		if (!Information.IsNothing(SelectedUnit))
		{
			if ((object)SelectedUnit.GetType() == typeof(Contact))
			{
				if (!composerRequest.ActiveUnits.Values.Contains(((Contact)SelectedUnit).ActualUnit))
				{
					SelectThisUnit(null, bool_0: true);
				}
			}
			else if (!composerRequest.ActiveUnits.ContainsKey(SelectedUnit.ObjectID))
			{
				SelectThisUnit(null, bool_0: true);
			}
		}
		if (m_ModelRequest.SelectedUnits.Count == 0)
		{
			SelectThisUnit(null, bool_0: true);
		}
		else
		{
			SelectThisUnit(m_ModelRequest.SelectedUnits[m_ModelRequest.SelectedUnits.Count - 1], bool_0: true);
		}
		if (Information.IsNothing(SelectedUnit) && theWeaponsWindow.Visible)
		{
			theWeaponsWindow.Hide();
		}
	}

	private static void CallConfiguration(PlatformComponent platformComponent_0)
	{
		if ((object)platformComponent_0.GetType() == typeof(Sensor))
		{
			if (!theSensorsWindow.Visible)
			{
				return;
			}
			if (((Sensor)platformComponent_0).ParentPlatform == SelectedUnit)
			{
				theSensorsWindow.RunInterruptibleItem().Start();
			}
			else
			{
				if (platformComponent_0.ParentPlatform == null || !platformComponent_0.ParentPlatform.IsWeapon || !SelectedUnit.IsActiveUnit)
				{
					return;
				}
				using IEnumerator<Sensor> enumerator = (from theSensor in ((ActiveUnit)SelectedUnit).Sensors_ReadOnly()
					where Operators.CompareString(theSensor.ObjectID, platformComponent_0.ObjectID, TextCompare: true) == 0
					select theSensor).GetEnumerator();
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					theSensorsWindow.RunInterruptibleItem().Start();
				}
			}
		}
		else if ((object)platformComponent_0.GetType() == typeof(CommDevice) && theCommsWindow.Visible && ((CommDevice)platformComponent_0).ParentPlatform == SelectedUnit)
		{
			theCommsWindow.PopInterruptibleExporter().Start();
		}
	}

	private static void LogoutConfiguration(object object_0)
	{
		if (object_0 == SelectedUnit && theSensorsWindow.Visible)
		{
			theSensorsWindow.RunInterruptibleItem().Start();
		}
	}

	public static void AddSide(string string_0, ref Scenario scenario_0)
	{
		Side side = new Side(string_0, ref scenario_0);
		composerRequest.AddSide(side);
		if (composerRequest.Sides_ReadOnly.Length == 1)
		{
			CurrentSide = side;
		}
		if (ItemExporter.ConnectInterruptibleTemplate.Sides.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.Sides.RefreshForm();
		}
	}

	public static void SaveCurrentScenario(bool bool_0, string string_0 = "", bool bool_1 = false)
	{
		bool flag;
		if (flag = CurrentGame.Status == Game._GameStatus.Running)
		{
			CurrentGame.Pause();
		}
		composerRequest.DBUsed = algoClass.Hash;
		composerRequest.LastSavedInScenEdit = CurrentGame.GameMode == Game._GameMode.ScenEdit;
		int num = 0;
		do
		{
			try
			{
				if (GameGeneral.PE_SaveAsXML)
				{
					MemoryTributary memoryTributary_ = GameGeneral.PostBridge(composerRequest);
					if (string.IsNullOrEmpty(string_0))
					{
						LoadSave.SaveScenario_XML(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName, memoryTributary_);
					}
					else
					{
						LoadSave.SaveScenario_XML(string_0, memoryTributary_);
					}
				}
				else if (string.IsNullOrEmpty(string_0))
				{
					LoadSave.SaveScenario(composerRequest, m_ModelRequest, ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName, bool_0, bool_1);
				}
				else
				{
					LoadSave.SaveScenario(composerRequest, m_ModelRequest, string_0, bool_0, bool_1);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200360", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				goto IL_0145;
			}
			break;
			IL_0145:
			num++;
		}
		while (num <= 4);
		if (flag)
		{
			CurrentGame.Run();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		CurrentUserAction = UserAction.None;
	}

	public static void CreateNewScenario()
	{
		SetCurrentScenario(new Scenario(algoClass.Hash), bool_0: false);
		ItemExporter.ConnectInterruptibleTemplate.MainForm?.MessageLogControlViewModel?.ResetLog();
		composerRequest.SetTime(bool_0: false, DateAndTime.Now.ToUniversalTime());
		composerRequest.GameResolution = 1f;
		composerRequest.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		composerRequest.LastSavedInScenEdit = true;
		composerRequest.FileName = null;
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AircraftDamage);
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects);
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		ScenarioWasLoadedAsBlank = true;
		SaveScenarioPath = null;
		CurrentSide = null;
		MustRefreshMainForm = true;
	}

	public static void CreateNewScenario(string string_0)
	{
		SetCurrentScenario(new Scenario(string_0), bool_0: false);
		ItemExporter.ConnectInterruptibleTemplate.MainForm?.MessageLogControlViewModel?.ResetLog();
		composerRequest.SetTime(bool_0: false, DateAndTime.Now.ToUniversalTime());
		composerRequest.GameResolution = 1f;
		composerRequest.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		composerRequest.LastSavedInScenEdit = true;
		composerRequest.FileName = null;
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.AircraftDamage);
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.LandTypeEffects);
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed);
		composerRequest.DeclaredFeatures.Add(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations);
		ScenarioWasLoadedAsBlank = true;
		SaveScenarioPath = null;
		CurrentSide = null;
		MustRefreshMainForm = true;
	}

	public static bool CanSeeAllPrivateInformationOnThisUnit(Module_Unit.Unit unit_0)
	{
		if (CurrentMapProfile.GodsEye)
		{
			return true;
		}
		if (unit_0.IsActiveUnit)
		{
			if (unit_0.IsWeapon && ((Weapon)unit_0).DataLinkParent != null && InterpreterObjectListener.CollectInterruptibleTask(((Weapon)unit_0).DataLinkParent))
			{
				return true;
			}
			if (!((ActiveUnit)unit_0).CommStuff.IsConnectedToSideNetwork && Operators.CompareString(unit_0.ObjectID, CurrentMapProfile.String_0, TextCompare: true) != 0)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(CurrentMapProfile.String_0) && Operators.CompareString(unit_0.ObjectID, CurrentMapProfile.String_0, TextCompare: true) != 0)
			{
				return false;
			}
			if (unit_0.GetUnitSide() == m_ModelRequest)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static void ViewConfiguration(object object_0, object object_1)
	{
		Run1Turn();
		MustRefreshMainForm = true;
	}

	private static bool ValidateConfiguration()
	{
		foreach (IEventExporter item in Exporter_General.EventExporters_Interactive)
		{
			if (item.UsesRAMQueue && item.QueueLength > 1000000)
			{
				return true;
			}
		}
		return false;
	}

	public static void Run1Turn()
	{
		try
		{
			iteratorClass = composerRequest.ActiveUnits_List.Count;
			_RoleClass = Pathfinding.InterruptStub();
			m_FactoryClass = Pathfinding.RemoveStub();
			if (ScenarioWasLoadedAsBlank)
			{
				ScenarioWasLoadedAsBlank = false;
				return;
			}
			int timeCompression_SimSeconds = composerRequest.TimeCompression_SimSeconds;
			for (int i = 1; i <= timeCompression_SimSeconds; i++)
			{
				if (RunToThisTime.HasValue)
				{
					DateTime time = composerRequest.Time;
					DateTime? runToThisTime = RunToThisTime;
					if ((runToThisTime.HasValue ? new bool?(DateTime.Compare(time, runToThisTime.GetValueOrDefault()) >= 0) : null).GetValueOrDefault())
					{
						CurrentGame.Pause();
						break;
					}
				}
				if (composerRequest.TimeToHalt.HasValue)
				{
					DateTime time2 = composerRequest.Time;
					DateTime? timeToHalt = composerRequest.TimeToHalt;
					if ((timeToHalt.HasValue ? new bool?(DateTime.Compare(time2, timeToHalt.GetValueOrDefault()) >= 0) : null).GetValueOrDefault())
					{
						CurrentGame.Pause();
						break;
					}
				}
				if (CurrentGame.Status == Game._GameStatus.Paused)
				{
					break;
				}
				while (ValidateConfiguration())
				{
					Thread.Sleep(1000);
				}
				GetConfiguration(composerRequest, ref initializerClass);
				if (composerRequest.FifteenthSecondIsChangingOnThisPulse)
				{
					PushConfiguration(composerRequest, bool_0: true, string.Empty);
				}
				foreach (LoggedMessage unhandledPopUpMessage in composerRequest.UnhandledPopUpMessages)
				{
					if (unhandledPopUpMessage.Side == m_ModelRequest)
					{
						CurrentGame.Pause();
						break;
					}
				}
				if (composerRequest.TimeCompression_SimSeconds > 1)
				{
					MustRefreshMainForm = true;
				}
				if (GameGeneral.TacviewPipeEnabled)
				{
					TacviewClient.RefreshContactsOfCurrentSide();
				}
			}
			PushConfiguration(composerRequest, bool_0: true, string.Empty);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200658", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void LoginConfiguration(object object_0, object object_1)
	{
		MustRefreshMainForm = true;
	}

	internal static void GetConfiguration(Scenario scenario_0, ref float float_0)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		try
		{
			try
			{
				GameGeneral.MainGameLoop(ref scenario_0);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_.Data.Add("Error at 200362", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101163", exception_2.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
		stopwatch.Stop();
		float_0 = stopwatch.ElapsedMilliseconds;
		MustRefreshMainForm = true;
		if (!scenario_0.HasBeenReleased)
		{
			m_ConnectionRequest?.Invoke(scenario_0);
		}
	}

	public static void ConfigureCommandCoreSettings(ref Scenario scenario_0)
	{
		scenario_0.Navigation_FinegrainedMaxDistance = SimConfiguration.DefaultGamePreferences.NavigationMaxDistanceNMSetting;
		scenario_0.Navigation_FinegrainedThresholdDistance = SimConfiguration.DefaultGamePreferences.NavigationThresholdDistanceDegSetting;
	}

	public static void ConfigureCommandCorePlottedCourseSettings(ref Scenario scenario_0, bool bool_0)
	{
		scenario_0.UserIsPlottingCourse = bool_0;
	}

	public static void TimeStep_15sec()
	{
		if (CurrentGame.Status != Game._GameStatus.Running)
		{
			RunToThisTime = composerRequest.Time.AddSeconds(15.0);
			CurrentGame.Run();
		}
	}

	public static void TimeStep_1min()
	{
		if (CurrentGame.Status != Game._GameStatus.Running)
		{
			RunToThisTime = composerRequest.Time.AddSeconds(60.0);
			CurrentGame.Run();
		}
	}

	public static void TimeStep_5min()
	{
		if (CurrentGame.Status != Game._GameStatus.Running)
		{
			RunToThisTime = composerRequest.Time.AddMinutes(5.0);
			CurrentGame.Run();
		}
	}

	public static void TimeStep_15min()
	{
		if (CurrentGame.Status != Game._GameStatus.Running)
		{
			RunToThisTime = composerRequest.Time.AddMinutes(15.0);
			CurrentGame.Run();
		}
	}

	public static void QuickJumpSlot_Retrieve(int int_0)
	{
		if (!m_ModelRequest.QuickJumpSlots.ContainsKey(int_0))
		{
			return;
		}
		m_ModelRequest.QuickJumpSlots.TryGetValue(int_0, out var value);
		if (Information.IsNothing(value))
		{
			DarkMessageBox.ShowError("不存在该 ID 的快速跳转视角!", "快速跳转条目错误!");
			return;
		}
		string left = value.LocationString.Split('_')[0];
		if (Operators.CompareString(left, "AU", TextCompare: true) == 0)
		{
			ActiveUnit activeUnit = null;
			composerRequest.ActiveUnits.TryGetValue(value.LocationString.Split('_')[1], ref activeUnit);
			if (!Information.IsNothing(activeUnit))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
				ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = value.CameraAlt;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TrackCamActive = value.Tracking;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSL_Status.Text = "跳转到视角 #" + Conversions.ToString(int_0);
			}
		}
		else if (Operators.CompareString(left, "Con", TextCompare: true) == 0)
		{
			Contact contact = null;
			m_ModelRequest.Contacts.TryGetValue(value.LocationString.Split('_')[1], ref contact);
			if (!Information.IsNothing(contact))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(contact.GetLongitude(), contact.GetLatitude()));
				ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = value.CameraAlt;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TrackCamActive = value.Tracking;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.TSL_Status.Text = "跳转到视角 #" + Conversions.ToString(int_0);
			}
		}
	}

	public static void ShowDamageDetails()
	{
		if (!Information.IsNothing(SelectedUnit) && SelectedUnit.IsActiveUnit)
		{
			Side modelRequest = m_ModelRequest;
			Module_Unit.Unit selectedUnit = SelectedUnit;
			string string_ = null;
			if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0) && (Information.IsNothing(theDamageControlWindow) || !theDamageControlWindow.Visible) && SelectedUnit.IsPlatform)
			{
				theDamageControlWindow = new DamageControlWindow();
				theDamageControlWindow.theSelectedUnit = (ActiveUnit)SelectedUnit;
				theDamageControlWindow.theCurrentGame = CurrentGame;
				theDamageControlWindow.Show();
			}
		}
	}

	public static void ShowMags()
	{
		if (Information.IsNothing(SelectedUnit) || (!Information.IsNothing(theMagazinesWindow) && theMagazinesWindow.Visible) || !SelectedUnit.IsActiveUnit)
		{
			return;
		}
		if (SelectedUnit.IsPlatform)
		{
			if (Information.IsNothing(((Platform)SelectedUnit).Magazines))
			{
				DarkMessageBox.ShowError("选定的单元没有弹药库。", "没有弹药库！");
			}
			else if (CurrentGame.GameMode != Game._GameMode.ScenEdit && ((Platform)SelectedUnit).Magazines.Count() <= 0)
			{
				bool flag = false;
				if ((SelectedUnit.IsShip || SelectedUnit.IsFacility || SelectedUnit.IsMobileGroundUnit) && ((Platform)SelectedUnit).Mounts.Count > 0)
				{
					foreach (Mount mount in ((Platform)SelectedUnit).Mounts)
					{
						if (mount.MountMagazine.Weapons.Count > 0)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					theMagazinesWindow = new Magazines();
					theMagazinesWindow.SelectedUnit = (ActiveUnit)SelectedUnit;
					theMagazinesWindow.Show();
				}
				else
				{
					DarkMessageBox.ShowError("选定的单元没有弹药库。", "没有弹药库！");
				}
			}
			else
			{
				theMagazinesWindow = new Magazines();
				theMagazinesWindow.SelectedUnit = (ActiveUnit)SelectedUnit;
				theMagazinesWindow.Show();
			}
		}
		else if (SelectedUnit.IsGroup)
		{
			if (Information.IsNothing(((Group)SelectedUnit).SharedMagazines))
			{
				DarkMessageBox.ShowError("选定的单元没有弹药库。", "没有弹药库！");
				return;
			}
			if (((Group)SelectedUnit).SharedMagazines.Length == 0)
			{
				DarkMessageBox.ShowError("选定的编组没有弹药库。", "没有弹药库！");
				return;
			}
			theMagazinesWindow = new Magazines();
			theMagazinesWindow.SelectedUnit = (ActiveUnit)SelectedUnit;
			theMagazinesWindow.Show();
		}
	}

	public static void ShowDaysUnderway()
	{
		if (!Information.IsNothing(SelectedUnit) && !theTimeUnderwayWindow.Visible && SelectedUnit.IsActiveUnit)
		{
			theTimeUnderwayWindow = new TimeUnderway();
			theTimeUnderwayWindow.theAU = (ActiveUnit)SelectedUnit;
			theTimeUnderwayWindow.Show();
		}
	}

	public static void ShowSetUnitProperties()
	{
		if (SelectedUnit != null && !ItemExporter.ConnectInterruptibleTemplate.Form_SetFuelAndAirborneTime.Visible && SelectedUnit.IsActiveUnit)
		{
			ItemExporter.ConnectInterruptibleTemplate.Form_SetFuelAndAirborneTime.Show();
		}
	}

	public static void ClearMessageLog()
	{
		composerRequest.ClearMessageLog();
		if (ItemExporter.ConnectInterruptibleTemplate.MainForm.objectError.VM != null)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.objectError.VM.ClearLog();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.objectError.VM.RefreshLoggedMessages();
		}
		if (ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Visible || ItemExporter.ConnectInterruptibleTemplate.MainForm.gclass5_0 != null)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlViewModel.ClearLog();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlViewModel.RefreshLoggedMessages();
		}
		MustRefreshMainForm = true;
	}

	public static void CloseAllOpenWindows(bool bool_0)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = ItemExporter.RevertInterruptibleMap.OpenForms.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Form form = (Form)enumerator.Current;
				if (form != ItemExporter.ConnectInterruptibleTemplate.m_InterpreterTemplate && form != ItemExporter.ConnectInterruptibleTemplate.databaseTemplate && form.Visible && form != ItemExporter.ConnectInterruptibleTemplate.attributeTemplate)
				{
					try
					{
						form.Hide();
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
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
	}

	public static void ShowThrottleAlt()
	{
		if (_IssuerRequest != null && _IssuerRequest.Category == Waypoint.WaypointCategory.FlightPlan)
		{
			bool flag = false;
			Side[] sides_ReadOnly = composerRequest.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i++)
			{
				foreach (Mission mission in sides_ReadOnly[i].Missions)
				{
					foreach (Mission.Flight flight in mission.FlightList)
					{
						for (int j = flight.FlightPlan.Count() - 1; j >= 0; j += -1)
						{
							Waypoint waypoint = flight.FlightPlan[j];
							if (waypoint == _IssuerRequest)
							{
								flag = true;
							}
							if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman) && waypoint.Waypoint_LeadElementWingman == _IssuerRequest)
							{
								flag = true;
							}
							if (!Information.IsNothing(waypoint.Waypoint_SecondElement) && waypoint.Waypoint_SecondElement == _IssuerRequest)
							{
								flag = true;
							}
							if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman) && waypoint.Waypoint_SecondElementWingman == _IssuerRequest)
							{
								flag = true;
							}
							if (!Information.IsNothing(waypoint.Waypoint_ThirdElement) && waypoint.Waypoint_ThirdElement == _IssuerRequest)
							{
								flag = true;
							}
							if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman) && waypoint.Waypoint_ThirdElementWingman == _IssuerRequest)
							{
								flag = true;
							}
							if (flag)
							{
								ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_SelectedUnit = null;
								ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint = _IssuerRequest;
								ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Flight = flight;
								ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Mission = mission;
								ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Show();
								return;
							}
						}
					}
				}
			}
		}
		if (SelectedUnit == null || !SelectedUnit.IsActiveUnit || SelectedUnit.IsSatellite || (SelectedUnit.IsWeapon && Information.IsNothing(((Weapon)SelectedUnit).DataLinkParent)) || (ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint != null && ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Visible) || SelectedUnit == null)
		{
			return;
		}
		Side modelRequest = m_ModelRequest;
		Module_Unit.Unit selectedUnit = SelectedUnit;
		string string_ = null;
		if (!GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0) || SelectedUnit.GetUnitSide() != m_ModelRequest)
		{
			return;
		}
		if (SelectedUnit.IsGroup)
		{
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Flight = null;
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Mission = null;
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Show();
		}
		else if (!((ActiveUnit)SelectedUnit).IsFixedFacility)
		{
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_SelectedUnit = (ActiveUnit)SelectedUnit;
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint = null;
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Flight = null;
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Mission = null;
			if (!SelectedUnit.IsWeapon || ((Weapon)SelectedUnit).Type != Weapon._WeaponType.Sonobuoy)
			{
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Show();
			}
		}
	}

	public static List<ActiveUnit> GetSelectedActiveUnitsForCoursePlot()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			Side modelRequest = m_ModelRequest;
			string string_ = null;
			if (!GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0) || selectedUnit.IsSatellite || (selectedUnit.IsFacility && ((Facility)selectedUnit).IsFixedFacility))
			{
				continue;
			}
			if (selectedUnit.IsGroup)
			{
				Group.GroupType type = ((Group)selectedUnit).Type;
				if (type == Group.GroupType.Installation || (int)(type - 5) <= 1)
				{
					continue;
				}
			}
			list.Add((ActiveUnit)selectedUnit);
		}
		return list;
	}

	public static void Split()
	{
		if (SelectedUnit != null && SelectedUnit.IsFacility && ((ActiveUnit)SelectedUnit).AddClient())
		{
			SplitUnit splitUnit = new SplitUnit();
			splitUnit.SourceUnit = (ActiveUnit)SelectedUnit;
			splitUnit.Show();
		}
	}

	public static void Merge()
	{
		if (Information.IsNothing(m_ModelRequest) || m_ModelRequest.SelectedUnits.Count <= 1)
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			ActiveUnit activeUnit = (ActiveUnit)selectedUnit;
			if (selectedUnit.GetUnitSide() != m_ModelRequest || !activeUnit.AddClient() || !(Module_Unit.RangeToUnit_Horiz(m_ModelRequest.SelectedUnits.ElementAt(0), selectedUnit) <= 0.2f))
			{
				return;
			}
		}
		ActiveUnit activeUnit2 = (ActiveUnit)m_ModelRequest.SelectedUnits.ElementAt(0);
		for (int i = m_ModelRequest.SelectedUnits.Count - 1; i >= 1; i += -1)
		{
			foreach (Mount item in ((ActiveUnit)m_ModelRequest.SelectedUnits.ElementAt(i)).Mounts.ToList())
			{
				activeUnit2.Mounts.Add(item);
				((ActiveUnit)m_ModelRequest.SelectedUnits.ElementAt(i)).Mounts.Remove(item);
			}
			((ActiveUnit)m_ModelRequest.SelectedUnits.ElementAt(i)).Destroy(bool_0: true, bool_1: true, bool_2: true, "Unit Merged");
		}
	}

	public static void PlotCourse()
	{
		if (SelectedUnit == null)
		{
			return;
		}
		try
		{
			bool flag = false;
			if (!Information.IsNothing(SelectedUnit))
			{
				Side modelRequest = m_ModelRequest;
				Module_Unit.Unit selectedUnit = SelectedUnit;
				string string_ = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				foreach (Module_Unit.Unit selectedUnit2 in m_ModelRequest.SelectedUnits)
				{
					string string_2 = null;
					if (selectedUnit2.IsActiveUnit && selectedUnit2.GetUnitSide() == m_ModelRequest)
					{
						if (GameGeneral.CanIssueOrdersToThisUnit(m_ModelRequest, selectedUnit2, bool_1: false, ref string_2, CurrentMapProfile.String_0))
						{
							flag = true;
						}
						else if (!string.IsNullOrEmpty(string_2))
						{
							((ActiveUnit)selectedUnit2).AddMessage(selectedUnit2.Name + "不能指示改变路径（" + string_2 + ")", selectedUnit2.Name + " 无法下指令", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(selectedUnit2.GetLongitude(), selectedUnit2.GetLatitude()));
						}
					}
				}
			}
			if (!flag || SelectedUnit.IsSatellite)
			{
				return;
			}
			if (!Information.IsNothing(SelectedUnit) && !Information.IsNothing(_IssuerRequest))
			{
				if (SelectedUnit.GetUnitSide() == m_ModelRequest)
				{
					int num = Array.IndexOf(((ActiveUnit)SelectedUnit).Navigator.PlottedCourse, _IssuerRequest);
					int num2 = ((ActiveUnit)SelectedUnit).Navigator.PlottedCourse.Count() - 1;
					int num3 = num + 1;
					for (int i = num2; i >= num3; i += -1)
					{
						((ActiveUnit)SelectedUnit).Navigator.RemoveWaypoint_Soft(((ActiveUnit)SelectedUnit).Navigator.PlottedCourse[i], bool_1: true);
					}
					CurrentUserAction = UserAction.PlottingCourse;
					Scenario scenario_ = composerRequest;
					ConfigureCommandCorePlottedCourseSettings(ref scenario_, bool_0: true);
					MustRefreshMainForm = true;
				}
			}
			else if (CurrentUserAction != UserAction.PlottingCourse && CurrentUserAction != UserAction.PlottingCourseForSalvo)
			{
				List<ActiveUnit> selectedActiveUnitsForCoursePlot = GetSelectedActiveUnitsForCoursePlot();
				if (selectedActiveUnitsForCoursePlot.Count == 0)
				{
					return;
				}
				foreach (ActiveUnit item in selectedActiveUnitsForCoursePlot)
				{
					item.Navigator.ClearPlottedCourse();
				}
				CurrentUserAction = UserAction.PlottingCourse;
			}
			else
			{
				if (CurrentUserAction == UserAction.PlottingCourse)
				{
					Scenario scenario_2 = composerRequest;
					ConfigureCommandCorePlottedCourseSettings(ref scenario_2, bool_0: false);
				}
				CurrentUserAction = UserAction.None;
				MustRefreshMainForm = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101143", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void WriteConfiguration(int int_0)
	{
		if (m_ModelRequest != null && SelectedUnit != null)
		{
			QuickJumpSlot quickJumpSlot = new QuickJumpSlot();
			quickJumpSlot.Index = int_0;
			if (SelectedUnit.IsActiveUnit)
			{
				quickJumpSlot.LocationString = "AU_" + SelectedUnit.ObjectID;
			}
			else
			{
				quickJumpSlot.LocationString = "Con_" + ((Contact)SelectedUnit).ActualUnit.ObjectID;
			}
			quickJumpSlot.CameraAlt = ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude;
			quickJumpSlot.Tracking = ItemExporter.ConnectInterruptibleTemplate.MainForm.TrackCamActive;
			if (m_ModelRequest.QuickJumpSlots.ContainsKey(quickJumpSlot.Index))
			{
				m_ModelRequest.QuickJumpSlots[quickJumpSlot.Index] = quickJumpSlot;
			}
			else
			{
				m_ModelRequest.QuickJumpSlots.Add(quickJumpSlot.Index, quickJumpSlot);
			}
			ItemExporter.ConnectInterruptibleTemplate.MainForm.TSL_Status.Text = "保存为快速跳转视角 #" + Conversions.ToString(int_0);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.AdjustQuickJumpMenu();
		}
	}

	public static void HandleGlobalHotkeys(Keys keys_0)
	{
		switch (keys_0)
		{
		case Keys.OemOpenBrackets:
		{
			string string_4 = "";
			ActiveUnit_Weaponry.DropPassiveSonobuoy(SelectedUnit, bool_1: false, bool_2: true, ref string_4);
			if (!string.IsNullOrEmpty(string_4))
			{
				composerRequest.AddMessage(SelectedUnit.Name + " 正尝试投放被动声呐（深）" + string_4, "投放声呐", LoggedMessage.MessageType.AirOps, 5, SelectedUnit.ObjectID, m_ModelRequest, new Geopoint_Struct(SelectedUnit.GetLongitude(), SelectedUnit.GetLatitude()));
			}
			break;
		}
		case Keys.OemPipe:
			SelectNextUnit();
			break;
		case Keys.OemCloseBrackets:
		{
			string string_ = "";
			ActiveUnit_Weaponry.DropActiveSonobuoy(SelectedUnit, bool_1: false, bool_2: true, ref string_);
			if (!string.IsNullOrEmpty(string_))
			{
				composerRequest.AddMessage(SelectedUnit.Name + " 正尝试投放声呐（深）" + string_, "投放声呐", LoggedMessage.MessageType.AirOps, 5, SelectedUnit.ObjectID, m_ModelRequest, new Geopoint_Struct(SelectedUnit.GetLongitude(), SelectedUnit.GetLatitude()));
			}
			break;
		}
		case Keys.Back:
			SelectPreviousUnit();
			break;
		case Keys.Return:
			composerRequest.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleTimeCompressionChanged();
			break;
		case Keys.Escape:
			AreaInPolygonDraw = null;
			if (CurrentUserAction != 0)
			{
				CurrentUserAction = UserAction.None;
				Scenario scenario_ = composerRequest;
				ConfigureCommandCorePlottedCourseSettings(ref scenario_, bool_0: false);
			}
			break;
		case Keys.Space:
			switch (CurrentGame.Status)
			{
			case Game._GameStatus.Running:
				CurrentGame.Pause();
				break;
			case Game._GameStatus.Paused:
				CurrentGame.Run();
				break;
			}
			break;
		case Keys.D0:
		case Keys.D1:
		case Keys.D2:
		case Keys.D3:
		case Keys.D4:
		case Keys.D5:
		case Keys.D6:
		case Keys.D7:
		case Keys.D8:
		case Keys.D9:
			if (m_ModelRequest != null)
			{
				QuickJumpSlot_Retrieve(Conversions.ToInteger(filterRequest.ConvertToString(keys_0)));
			}
			break;
		case Keys.A:
		{
			bool flag = true;
			foreach (Module_Unit.Unit selectedUnit2 in m_ModelRequest.SelectedUnits)
			{
				if (selectedUnit2.IsActiveUnit && selectedUnit2.GetUnitSide() == m_ModelRequest && !selectedUnit2.IsWeapon)
				{
					byte? b = (byte?)((ActiveUnit)selectedUnit2).Doctrine.GetWeaponControlStatus_Air(composerRequest, bool_0: false, null, bool_1: false, bool_2: false);
					bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null);
					if (((!flag2) ?? flag2).GetValueOrDefault())
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				Doctrine._WCS? nullable_ = null;
				WeaponsHold_SelectedUnits(ref nullable_);
			}
			else
			{
				Doctrine._WCS? nullable_2 = Doctrine._WCS.Hold;
				WeaponsHold_SelectedUnits(ref nullable_2);
			}
			break;
		}
		case Keys.B:
			if (!Information.IsNothing(m_ModelRequest))
			{
				ReturnToBase();
			}
			break;
		case Keys.C:
			CopyUnit();
			break;
		case Keys.D:
			DetachUnits();
			break;
		case Keys.E:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.DropTargets();
			break;
		case Keys.F:
			MarkContactFriendly();
			break;
		case Keys.G:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.GroupUnits();
			break;
		case Keys.H:
			MarkContactHostile();
			break;
		case Keys.I:
		{
			if (m_ModelRequest == null)
			{
				break;
			}
			bool flag7 = true;
			foreach (Module_Unit.Unit selectedUnit3 in m_ModelRequest.SelectedUnits)
			{
				if (selectedUnit3.IsActiveUnit && selectedUnit3.GetUnitSide() == m_ModelRequest && !selectedUnit3.IsWeapon)
				{
					byte? b4 = (byte?)((ActiveUnit)selectedUnit3).Doctrine.GetIgnorePlottedCourse(composerRequest, bool_0: false, null, bool_1: false, bool_2: false);
					bool? flag8 = (b4.HasValue ? new bool?(b4.GetValueOrDefault() == 1) : null);
					if (((!flag8) ?? flag8).GetValueOrDefault())
					{
						flag7 = false;
						break;
					}
				}
			}
			if (flag7)
			{
				Doctrine._UseIgnorePlottedCourse? nullable_7 = null;
				IgnorePlottedCourse_SelectedUnits(ref nullable_7);
			}
			else
			{
				Doctrine._UseIgnorePlottedCourse? nullable_8 = Doctrine._UseIgnorePlottedCourse.Yes;
				IgnorePlottedCourse_SelectedUnits(ref nullable_8);
			}
			break;
		}
		case Keys.L:
		{
			if (m_ModelRequest == null)
			{
				break;
			}
			bool bool_2 = true;
			foreach (Module_Unit.Unit selectedUnit4 in m_ModelRequest.SelectedUnits)
			{
				if (selectedUnit4.IsActiveUnit && selectedUnit4.GetUnitSide() == m_ModelRequest && ((selectedUnit4.IsFacility && !((ActiveUnit)selectedUnit4).IsFixedFacility) || selectedUnit4.IsMobileGroundUnit) && !((ActiveUnit)selectedUnit4).AI.HoldPosition)
				{
					bool_2 = false;
					break;
				}
			}
			HoldPosition(ref bool_2);
			break;
		}
		case Keys.M:
			MoveUnit();
			break;
		case Keys.N:
			MarkContactNeutral();
			break;
		case Keys.O:
			if (!Information.IsNothing(m_ModelRequest))
			{
				ItemExporter.ConnectInterruptibleTemplate.ORBAT.Show();
			}
			break;
		case Keys.Q:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.authenticationCode = true;
			break;
		case Keys.R:
			RenameUnitOrContact();
			break;
		case Keys.T:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ToggleTrackcam();
			break;
		case Keys.U:
			UnassigUnitsAndDisengage();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(composerRequest, m_ModelRequest, SelectedUnit, bool_0: false);
			break;
		case Keys.X:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ZoomOut();
			break;
		case Keys.Z:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ZoomIn(bool_0: false);
			break;
		case Keys.RWin:
			if (SelectedUnit != null)
			{
				Point point = ManagerListenerManager.SetInterruptibleMap(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1, SelectedUnit.GetLatitude(), SelectedUnit.GetLongitude());
				if (SelectedUnit.IsActiveUnit)
				{
					ItemExporter.ConnectInterruptibleTemplate.MainForm.ShowUnitContextMenu(SelectedUnit, point.X, point.Y);
				}
				if (SelectedUnit.DisableWriter())
				{
					ItemExporter.ConnectInterruptibleTemplate.MainForm.ShowContactContextMenu((Contact)SelectedUnit, point.X, point.Y);
				}
			}
			break;
		case Keys.Insert:
		case Keys.NumPad0:
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				CurrentUserAction = UserAction.AddingPlatform;
			}
			break;
		case Keys.End:
		case Keys.NumPad1:
			CurrentMapProfile.ShowIlluminationVectors++;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
			break;
		case Keys.Down:
		case Keys.NumPad2:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.PanMapDown();
			break;
		case Keys.P:
		case Keys.NumPad3:
			DropSelectedContacts();
			break;
		case Keys.Left:
		case Keys.NumPad4:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.PanMapLeft();
			break;
		case Keys.Right:
		case Keys.NumPad6:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.PanMapRight();
			break;
		case Keys.Home:
		case Keys.NumPad7:
			CurrentMapProfile.ShowTargetingVectors++;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
			break;
		case Keys.Up:
		case Keys.NumPad8:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.PanMapUp();
			break;
		case Keys.Prior:
		case Keys.V:
		case Keys.NumPad9:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SwitchView();
			break;
		case Keys.Multiply:
			CurrentMapProfile.ShowDatablocks++;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
			break;
		case Keys.Delete:
		case Keys.Decimal:
			if (_IssuerRequest == null)
			{
				DeleteUnit();
			}
			else
			{
				DeleteWaypoint();
			}
			break;
		case Keys.Divide:
			CurrentMapProfile.ShowDatalinks++;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
			break;
		case Keys.F1:
			AttackTarget_Auto();
			break;
		case Keys.F2:
			ShowThrottleAlt();
			break;
		case Keys.F3:
			PlotCourse();
			break;
		case Keys.F4:
			EditFormation();
			break;
		case Keys.F5:
			ShowMags();
			break;
		case Keys.F6:
			ShowAirOps();
			break;
		case Keys.F7:
			ShowDockingOps();
			break;
		case Keys.F8:
			ShowWeaponDetails();
			break;
		case Keys.F9:
			if (m_ModelRequest != null)
			{
				ShowSensorsForSelectedUnit();
			}
			break;
		case Keys.F10:
			ShowDamageDetails();
			break;
		case Keys.F11:
			if (m_ModelRequest == null)
			{
				DarkMessageBox.ShowError("您必须选择一个分方。", "没有选择分方！");
			}
			else
			{
				MissionEditorWindow.Show();
			}
			break;
		case Keys.D | Keys.Shift:
			DeployDippingSonar();
			break;
		case Keys.C | Keys.Shift:
			CloneUnit();
			break;
		case Keys.Delete | Keys.Shift:
			if (DarkMessageBox.ShowWarning("This will remove all units in the scenario, except the selection. Proceed ?", string.Empty, DarkDialogButton.YesNoCancel) == DialogResult.Yes)
			{
				DeleteAllUnit(m_ModelRequest.SelectedUnits.ToHashSet());
			}
			break;
		case Keys.F1 | Keys.Shift:
			AttackTarget_Manual();
			break;
		case Keys.Insert | Keys.Shift:
		case Keys.NumPad0 | Keys.Shift:
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				CurrentUserAction = UserAction.AddingPlatform;
				AddingDecoyPlatform = true;
			}
			break;
		case Keys.S | Keys.Shift:
			Set_UnitIsSpotted();
			break;
		case Keys.OemCloseBrackets | Keys.Shift:
		{
			string string_3 = "";
			ActiveUnit_Weaponry.DropActiveSonobuoy(SelectedUnit, bool_1: true, bool_2: true, ref string_3);
			if (!string.IsNullOrEmpty(string_3))
			{
				composerRequest.AddMessage(SelectedUnit.Name + " 正尝试投放主动声呐（浅）" + string_3, "投放声呐", LoggedMessage.MessageType.AirOps, 5, SelectedUnit.ObjectID, m_ModelRequest, new Geopoint_Struct(SelectedUnit.GetLongitude(), SelectedUnit.GetLatitude()));
			}
			break;
		}
		case Keys.OemOpenBrackets | Keys.Shift:
		{
			string string_2 = "";
			ActiveUnit_Weaponry.DropPassiveSonobuoy(SelectedUnit, bool_1: true, bool_2: true, ref string_2);
			if (!string.IsNullOrEmpty(string_2))
			{
				composerRequest.AddMessage(SelectedUnit.Name + " 正尝试投放被动声呐（浅）" + string_2, "投放声呐", LoggedMessage.MessageType.AirOps, 5, SelectedUnit.ObjectID, m_ModelRequest, new Geopoint_Struct(SelectedUnit.GetLongitude(), SelectedUnit.GetLatitude()));
			}
			break;
		}
		case Keys.End | Keys.Control:
			_ = m_ModelRequest.RefPoints;
			foreach (ReferencePoint highlightedRefPoint in HighlightedRefPoints)
			{
				highlightedRefPoint.IsHighlighted = false;
			}
			MustRefreshMainForm = true;
			break;
		case Keys.Insert | Keys.Control:
			CurrentUserAction = UserAction.AddingReferencePoint;
			SelectedRefPoint = null;
			break;
		case Keys.D0 | Keys.Control:
			WriteConfiguration(0);
			break;
		case Keys.D1 | Keys.Control:
			WriteConfiguration(1);
			break;
		case Keys.D2 | Keys.Control:
			WriteConfiguration(2);
			break;
		case Keys.D3 | Keys.Control:
			WriteConfiguration(3);
			break;
		case Keys.D4 | Keys.Control:
			WriteConfiguration(4);
			break;
		case Keys.D5 | Keys.Control:
			WriteConfiguration(5);
			break;
		case Keys.D6 | Keys.Control:
			WriteConfiguration(6);
			break;
		case Keys.D7 | Keys.Control:
			WriteConfiguration(7);
			break;
		case Keys.D8 | Keys.Control:
			WriteConfiguration(8);
			break;
		case Keys.D9 | Keys.Control:
			WriteConfiguration(9);
			break;
		case Keys.A | Keys.Control:
		{
			if (m_ModelRequest == null)
			{
				break;
			}
			bool flag5 = true;
			foreach (ActiveUnit unit in m_ModelRequest.Units)
			{
				if (unit.IsActiveUnit && unit.GetUnitSide() == m_ModelRequest && !unit.IsWeapon)
				{
					byte? b3 = (byte?)unit.Doctrine.GetWeaponControlStatus_Air(composerRequest, bool_0: false, null, bool_1: false, bool_2: false);
					bool? flag6 = (b3.HasValue ? new bool?(b3.GetValueOrDefault() == 2) : null);
					if (((!flag6) ?? flag6).GetValueOrDefault())
					{
						flag5 = false;
						break;
					}
				}
			}
			if (flag5)
			{
				Doctrine._WCS? nullable_5 = null;
				WeaponsHold_AllUnits(ref nullable_5);
			}
			else
			{
				Doctrine._WCS? nullable_6 = Doctrine._WCS.Hold;
				WeaponsHold_AllUnits(ref nullable_6);
			}
			break;
		}
		case Keys.C | Keys.Control:
			CopyGUID();
			break;
		case Keys.D | Keys.Control:
			ToggleDistanceMeasure();
			break;
		case Keys.E | Keys.Control:
			DisengageTargets();
			break;
		case Keys.H | Keys.Control:
			MarkContactUnfriendly();
			break;
		case Keys.I | Keys.Control:
		{
			if (m_ModelRequest == null)
			{
				break;
			}
			bool flag3 = true;
			foreach (ActiveUnit unit2 in m_ModelRequest.Units)
			{
				if (unit2.IsActiveUnit && unit2.GetUnitSide() == m_ModelRequest && !unit2.IsWeapon)
				{
					byte? b2 = (byte?)unit2.Doctrine.GetIgnorePlottedCourse(composerRequest, bool_0: false, null, bool_1: false, bool_2: false);
					bool? flag4 = (b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null);
					if (((!flag4) ?? flag4).GetValueOrDefault())
					{
						flag3 = false;
						break;
					}
				}
			}
			if (flag3)
			{
				Doctrine._UseIgnorePlottedCourse? nullable_3 = null;
				IgnorePlottedCourse_AllUnits(ref nullable_3);
			}
			else
			{
				Doctrine._UseIgnorePlottedCourse? nullable_4 = Doctrine._UseIgnorePlottedCourse.Yes;
				IgnorePlottedCourse_AllUnits(ref nullable_4);
			}
			break;
		}
		case Keys.K | Keys.Control:
			CurrentUserAction = UserAction.DefiningArea_Rectangle;
			break;
		case Keys.L | Keys.Control:
		{
			if (m_ModelRequest == null)
			{
				break;
			}
			bool bool_ = true;
			foreach (ActiveUnit unit3 in m_ModelRequest.Units)
			{
				if (unit3.IsActiveUnit && unit3.GetUnitSide() == m_ModelRequest && ((unit3.IsFacility && !unit3.IsFixedFacility) || unit3.IsMobileGroundUnit) && !unit3.AI.HoldPosition)
				{
					bool_ = false;
					break;
				}
			}
			HoldPositionAllUnits(ref bool_);
			break;
		}
		case Keys.M | Keys.Control:
			ClearMessageLog();
			break;
		case Keys.O | Keys.Control:
			CurrentUserAction = UserAction.DefiningArea_Circle;
			break;
		case Keys.P | Keys.Control:
			UI_InitiatePolygonZoneCreation();
			break;
		case Keys.R | Keys.Control:
			RenameRefPoint();
			break;
		case Keys.V | Keys.Control:
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				GodsEyeView();
			}
			break;
		case Keys.W | Keys.Control:
			DeleteWaypoint();
			break;
		case Keys.X | Keys.Control:
		{
			if (Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1))
			{
				GameGeneral.WriteLogDebugInfoToFile("WorldWindow1 object not found! Error 200594");
				break;
			}
			WorldWindow worldWindow = ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1;
			ref Point currentMousePosition = ref ItemExporter.ConnectInterruptibleTemplate.MainForm.CurrentMousePosition;
			int int_ = currentMousePosition.X;
			ref Point currentMousePosition2 = ref ItemExporter.ConnectInterruptibleTemplate.MainForm.CurrentMousePosition;
			int int_2 = currentMousePosition2.Y;
			double double_ = 0.0;
			double double_2 = 0.0;
			ManagerListenerManager.PopInterruptibleMap(worldWindow, ref int_, ref int_2, ref double_, ref double_2);
			currentMousePosition2.Y = int_2;
			currentMousePosition.X = int_;
			Clipboard.SetText("latitude='" + Conversions.ToString(double_2) + "', longitude='" + Conversions.ToString(double_) + "'");
			break;
		}
		case Keys.Z | Keys.Control:
			CopyRefPoints();
			break;
		case Keys.Return | Keys.Control:
			switch (CurrentGame.Status)
			{
			case Game._GameStatus.Running:
				CurrentGame.Pause();
				break;
			case Game._GameStatus.Paused:
				CurrentGame.Run();
				break;
			}
			break;
		case Keys.F1 | Keys.Control:
			smethod_2();
			break;
		case Keys.Delete | Keys.Control:
		case Keys.Decimal | Keys.Control:
			if (!Information.IsNothing(m_ModelRequest))
			{
				DeleteRefPoint();
			}
			break;
		case Keys.NumPad0 | Keys.Control:
			CurrentUserAction = UserAction.AddingReferencePoint;
			SelectedRefPoint = null;
			break;
		case Keys.I | Keys.Shift | Keys.Control:
			if (m_ModelRequest != null)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.ToggleIsolatedPOV();
			}
			break;
		case Keys.C | Keys.Shift | Keys.Control:
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				ItemExporter.ConnectInterruptibleTemplate.ConsoleWindow2.Show();
			}
			break;
		case Keys.F6 | Keys.Control:
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AddRemoveAircraft();
			}
			break;
		case Keys.F7 | Keys.Control:
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AddRemoveDockedBoats();
			}
			break;
		case Keys.F9 | Keys.Control:
			if (SelectedUnit != null && m_ModelRequest.SelectedUnits.Count != 0)
			{
				MainForm mainForm2 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
				Module_Unit.Unit selectedUnit = SelectedUnit;
				ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_2 = m_ModelRequest.SelectedUnits;
				List<ActiveUnit> list_2 = null;
				mainForm2.ShowDoctrineROE(selectedUnit, ref readOnlyCollection_2, ref list_2, bool_0: true);
			}
			else if (_IssuerRequest != null)
			{
				MainForm mainForm3 = ItemExporter.ConnectInterruptibleTemplate.MainForm;
				Waypoint issuerRequest = _IssuerRequest;
				ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_3 = null;
				List<ActiveUnit> list_3 = null;
				mainForm3.ShowDoctrineROE(issuerRequest, ref readOnlyCollection_3, ref list_3, bool_0: true);
			}
			break;
		case Keys.F11 | Keys.Control:
			if (m_ModelRequest == null)
			{
				DarkMessageBox.ShowError("您必须选择一个分方。", "没有选择分方！");
			}
			else
			{
				NewMissionWindow.Show();
			}
			break;
		case Keys.F11 | Keys.Shift | Keys.Control:
			if (m_ModelRequest == null)
			{
				DarkMessageBox.ShowWarning("您必须选择一个分方。", "没有选择分方！");
			}
			else
			{
				AirTaskingOrderWindow.Show();
			}
			break;
		case Keys.F9 | Keys.Shift | Keys.Control:
			if (m_ModelRequest != null)
			{
				MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
				Side modelRequest = m_ModelRequest;
				ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = null;
				List<ActiveUnit> list_ = null;
				mainForm.ShowDoctrineROE(modelRequest, ref readOnlyCollection_, ref list_, bool_0: true);
			}
			break;
		case Keys.M | Keys.Shift | Keys.Control:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ToggleMessageLogInSeparateWindow();
			MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
			break;
		case Keys.D1 | Keys.Alt:
			TimeStep_15sec();
			break;
		case Keys.D2 | Keys.Alt:
			TimeStep_1min();
			break;
		case Keys.D3 | Keys.Alt:
			TimeStep_5min();
			break;
		case Keys.D4 | Keys.Alt:
			TimeStep_15min();
			break;
		case Keys.Return | Keys.Alt:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ToggleFullScreen();
			break;
		case Keys.S | Keys.Alt:
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit && composerRequest.Sides_ReadOnly.Count() > 1)
			{
				CloseAllOpenWindows(bool_0: true);
				int num = Array.IndexOf(composerRequest.Sides_ReadOnly.OrderBy((Side theS) => theS.Name).ToArray(), m_ModelRequest);
				int num2 = ((num != composerRequest.Sides_ReadOnly.Count() - 1) ? (num + 1) : 0);
				composerRequest.SetCurrentSide(composerRequest.Sides_ReadOnly.OrderBy((Side theS) => theS.Name).ToArray()[num2]);
			}
			break;
		case Keys.D | Keys.Alt:
			ItemExporter.ConnectInterruptibleTemplate.DebugTool.Show();
			break;
		}
	}

	public static void Benchmark_Vicenty()
	{
		new Stopwatch().Start();
		float num = -180f;
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		do
		{
			float num2 = -90f;
			do
			{
				Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(num2, num);
				tLocalTM.CountInterruptibleQueue(num2, num, ref double_, ref double_2, bool_0: false);
				tLocalTM.CustomizeInterruptibleQueue(double_, double_2, ref double_3, ref double_4);
				num2 += 0.1f;
			}
			while (num2 <= 90f);
			num += 0.1f;
		}
		while (num <= 180f);
	}

	public static void Benchmark_OSM()
	{
		new Stopwatch().Start();
		float num = -180f;
		do
		{
			float num2 = -90f;
			do
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(num, num2);
				MercatorProjection.toGeoCoord(mercatorPixel.x, mercatorPixel.y);
				num2 += 0.1f;
			}
			while (num2 <= 90f);
			num += 0.1f;
		}
		while (num <= 180f);
	}

	public static void Benchmark_Vicenty_ClosureRate()
	{
		new Stopwatch().Start();
		float num = -180f;
		do
		{
			float num2 = -90f;
			do
			{
				Geodesic_Vincenty.GetInvocation(20.0, 15.0, 0.5, 50.0, num, num2, 0.8, 25.0);
				num2 += 0.1f;
			}
			while (num2 <= 90f);
			num += 0.1f;
		}
		while (num <= 180f);
	}

	public static void Benchmark_OSM_ClosureRate()
	{
		new Stopwatch().Start();
		float num = -180f;
		do
		{
			float num2 = -90f;
			do
			{
				MercatorProjection.ClosureRate_Geocentric(20.0, 15.0, 100.0, 50.0, num, num2, 100.0, 25.0);
				num2 += 0.1f;
			}
			while (num2 <= 90f);
			num += 0.1f;
		}
		while (num <= 180f);
	}

	public static void Benchmark_Vincenty_PointInPolygon(List<ReferencePoint> list_0)
	{
		new Stopwatch().Start();
		float num = -180f;
		do
		{
			float num2 = -90f;
			do
			{
				GeoPoint.PointInPolygon_Vincenty(num, num2, list_0);
				num2 += 1f;
			}
			while (num2 <= 90f);
			num += 1f;
		}
		while (num <= 180f);
	}

	public static void Benchmark_OSM_PointInPolygon(List<ReferencePoint> list_0)
	{
		new Stopwatch().Start();
		float num = -180f;
		do
		{
			float num2 = -90f;
			do
			{
				GeoPoint.PointInPolygon(num, num2, list_0);
				num2 += 1f;
			}
			while (num2 <= 90f);
			num += 1f;
		}
		while (num <= 180f);
	}

	public static void TEST_PointInPolygon(List<ReferencePoint> list_0)
	{
		float num = -180f;
		do
		{
			float num2 = -90f;
			do
			{
				if (GeoPoint.PointInPolygon_Vincenty(num, num2, list_0) != GeoPoint.PointInPolygon(num, num2, list_0))
				{
					Debugger.Break();
				}
				num2 += 1f;
			}
			while (num2 <= 90f);
			num += 1f;
		}
		while (num <= 180f);
	}

	public static void test()
	{
		float num = 0.0001f;
		float num7 = 5f;
		float num8 = 0.1f;
		long num9 = 0L;
		long num10 = 0L;
		long num11 = 0L;
		long num12 = 0L;
		long num13 = 0L;
		float num14 = num8;
		bool flag = num14 >= 0f;
		double double_ = 0.0;
		double double_2 = 0.0;
		double double_3 = 0.0;
		double double_4 = 0.0;
		for (float num2 = -180f; flag ? (num2 <= 180f) : (num2 >= 180f); num2 += num14)
		{
			float num3 = num8;
			bool flag2 = num3 >= 0f;
			for (float num4 = -90f; flag2 ? (num4 <= 90f) : (num4 >= 90f); num4 += num3)
			{
				double num5 = 0.0;
				double num6 = 0.0;
				try
				{
					num5 = Geodesic_Vincenty.GetInvocation(20.0, 15.0, 0.5, 50.0, num4, num2, 0.8, 25.0);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					Debugger.Break();
					num12++;
					ProjectData.ClearProjectError();
				}
				try
				{
					num6 = MercatorProjection.ClosureRate_Geocentric(20.0, 15.0, 100.0, 50.0, num2, num4, 100.0, 25.0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					Debugger.Break();
					num13++;
					ProjectData.ClearProjectError();
				}
				try
				{
					Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(num4, num2);
					tLocalTM.CountInterruptibleQueue(num4, num2, ref double_, ref double_2, bool_0: false);
					tLocalTM.CustomizeInterruptibleQueue(double_, double_2, ref double_3, ref double_4);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					Debugger.Break();
					num10++;
					ProjectData.ClearProjectError();
				}
				try
				{
					MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(num2, num4);
					MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(mercatorPixel.x, mercatorPixel.y);
					if (Math.Abs(double_3 - tCoord.Lat) > (double)num)
					{
						num9++;
					}
					if (Math.Abs(double_4 - tCoord.Lon) > (double)num)
					{
						num9++;
					}
					if (num5 != 0.0 && Math.Abs(num5 - num6) > (double)num7)
					{
						num9++;
					}
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					Debugger.Break();
					num11++;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public static void ReturnToBase(Module_Unit.Unit unit_0 = null)
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		if (unit_0 == null)
		{
			list = m_ModelRequest.SelectedUnits.ToList();
		}
		else
		{
			list.Add(unit_0);
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.GetUnitSide() != m_ModelRequest)
			{
				continue;
			}
			ActiveUnit activeUnit = (ActiveUnit)selectedUnit;
			if (activeUnit.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit;
				activeUnit.FuelState = aircraft.GetIsBingoOrJoker(null, aircraft.Doctrine.GetBingoJoker(aircraft.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
				activeUnit.WeaponState = aircraft.Weaponry.IsWinchesterOrShotgun();
				activeUnit.AirOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				string text = "";
				if (Operators.CompareString(activeUnit.Name, activeUnit.UnitClass, TextCompare: true) != 0)
				{
					text = " (" + activeUnit.UnitClass + ")";
				}
				string text2 = "";
				ActiveUnit actualDestinationHost = ((Aircraft_AirOps)activeUnit.AirOps).ActualDestinationHost;
				if (!Information.IsNothing(actualDestinationHost))
				{
					text2 = " (" + actualDestinationHost.Name + ")";
				}
				activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
				composerRequest.AddMessage(activeUnit.Name + text + "正返回基地" + text2, "单元返回基地", LoggedMessage.MessageType.AirOps, 5, activeUnit.ObjectID, m_ModelRequest, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
			}
			else if (activeUnit.IsShip || activeUnit.IsSubmarine || (selectedUnit.IsVehicle && ((Vehicle)selectedUnit).IsOutOfFuel))
			{
				string text3 = "";
				ActiveUnit actualDestinationHost2 = activeUnit.DockingOps.ActualDestinationHost;
				if (!Information.IsNothing(actualDestinationHost2))
				{
					text3 = " (" + actualDestinationHost2.Name + ")";
				}
				activeUnit.DockingOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
				activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
				composerRequest.AddMessage(activeUnit.Name + "正在返回停靠单元" + text3, "单元返回母舰", LoggedMessage.MessageType.DockingOps, 5, activeUnit.ObjectID, m_ModelRequest, new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
			}
			if (!activeUnit.IsGroup)
			{
				continue;
			}
			if (((Group)activeUnit).Type == Group.GroupType.AirGroup)
			{
				List<ActiveUnit> list2 = new List<ActiveUnit>();
				list2.AddRange(((Group)activeUnit).Units.Values);
				foreach (ActiveUnit item in list2)
				{
					item.FuelState = ((Aircraft)item).GetIsBingoOrJoker(null, item.Doctrine.GetBingoJoker(item.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
					item.WeaponState = ((Aircraft)item).Weaponry.IsWinchesterOrShotgun();
					string text4 = "";
					if (Operators.CompareString(item.Name, item.UnitClass, TextCompare: true) != 0)
					{
						text4 = " (" + item.UnitClass + ")";
					}
					string text5 = "";
					ActiveUnit actualDestinationHost3 = ((Aircraft_AirOps)item.AirOps).ActualDestinationHost;
					if (!Information.IsNothing(actualDestinationHost3))
					{
						text5 = " (" + actualDestinationHost3.Name + ") ";
					}
					item.AirOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: false, bool_3: true);
					item.Navigator.ResetTimeToNextPathfinderCheck();
					composerRequest.AddMessage(item.Name + text4 + "正返回基地" + text5, "单元返回基地", LoggedMessage.MessageType.AirOps, 5, item.ObjectID, m_ModelRequest, new Geopoint_Struct(item.GetLongitude(), item.GetLatitude()));
				}
			}
			else
			{
				if (((Group)activeUnit).Type != Group.GroupType.SurfaceGroup && ((Group)activeUnit).Type != Group.GroupType.SubGroup)
				{
					continue;
				}
				List<ActiveUnit> list3 = new List<ActiveUnit>();
				list3.AddRange(((Group)activeUnit).Units.Values);
				foreach (ActiveUnit item2 in list3)
				{
					if (item2.IsShip || item2.IsSubmarine)
					{
						item2.DockingOps.AttemptToRTB(bool_0: true, ActiveUnit._ActiveUnitStatus.RTB_Manual, bool_1: false, ActiveUnit._ActiveUnitStatus.Unassigned, bool_2: true, bool_3: true);
						string text6 = "";
						ActiveUnit actualDestinationHost4 = activeUnit.DockingOps.ActualDestinationHost;
						if (!Information.IsNothing(actualDestinationHost4))
						{
							text6 = " (" + actualDestinationHost4.Name + ") ";
						}
						item2.Navigator.ResetTimeToNextPathfinderCheck();
						composerRequest.AddMessage(item2.Name + "正在返回停靠单元" + text6, "单元返回母舰", LoggedMessage.MessageType.DockingOps, 5, item2.ObjectID, m_ModelRequest);
					}
				}
			}
		}
		MustRefreshMainForm = true;
	}

	public static void UnassigUnitsAndDisengage()
	{
		if (Information.IsNothing(SelectedUnit) || m_ModelRequest.SelectedUnits.Count == 0)
		{
			return;
		}
		List<ActiveUnit> list_ = new List<ActiveUnit>();
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && selectedUnit.GetUnitSide() == m_ModelRequest)
			{
				list_.Add((ActiveUnit)selectedUnit);
			}
		}
		if (list_.Count > 0)
		{
			NewConfiguration(ref list_);
		}
		DisengageTargets();
		foreach (ActiveUnit item in list_)
		{
			item.Status = ActiveUnit._ActiveUnitStatus.Manual_Unassigned;
			item.Navigator.ClearPlottedCourse();
		}
	}

	private static void NewConfiguration(ref List<ActiveUnit> list_0)
	{
		foreach (ActiveUnit item in list_0)
		{
			if (!item.IsActiveUnit || item.GetUnitSide() != m_ModelRequest || item.IsWeapon)
			{
				continue;
			}
			ActiveUnit activeUnit_ = item;
			if (item.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)item;
				Aircraft_AirOps airOps = aircraft.AirOps;
				if (airOps.Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || airOps.ConditionTimer == 0f)
				{
					airOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
				}
				if (aircraft.Navigator.PlottedCourse.Count() > 0 && aircraft.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse)
				{
					aircraft.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				else if (aircraft.Status == ActiveUnit._ActiveUnitStatus.Tasked)
				{
					aircraft.Status = ActiveUnit._ActiveUnitStatus.Tasked;
				}
				else
				{
					aircraft.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				if (aircraft.FuelState != 0)
				{
					aircraft.FuelState = ActiveUnit._ActiveUnitFuelState.IgnoreBingoAndJoker;
				}
				if (aircraft.WeaponState != 0)
				{
					aircraft.WeaponState = ActiveUnit._ActiveUnitWeaponState.IgnoreWinchesterAndShotgun;
				}
				if (!Information.IsNothing(airOps.A2AR_Destination))
				{
					airOps.DisconnectFromTanker();
				}
			}
			else if (item.IsShip)
			{
				Ship ship = (Ship)item;
				ActiveUnit_DockingOps dockingOps = ship.DockingOps;
				dockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
				if (ship.Navigator.PlottedCourse.Count() <= 0)
				{
					ship.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				else
				{
					ship.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				if (!Information.IsNothing(dockingOps.UNREP_Destination))
				{
					dockingOps.DisconnectFromSupplier();
				}
			}
			else if (item.IsSubmarine)
			{
				Submarine submarine = (Submarine)item;
				ActiveUnit_DockingOps dockingOps2 = submarine.DockingOps;
				dockingOps2.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Underway;
				if (submarine.Navigator.PlottedCourse.Count() <= 0)
				{
					submarine.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				}
				else
				{
					submarine.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
				}
				if (!Information.IsNothing(dockingOps2.UNREP_Destination))
				{
					dockingOps2.DisconnectFromSupplier();
				}
			}
			else if (item.IsGroup)
			{
				RemoveUnitFromMission(ref activeUnit_);
				activeUnit_.Doctrine.ClearCachedParentDoctrine();
				List<ActiveUnit> list_ = new List<ActiveUnit>();
				foreach (ActiveUnit value in ((Group)item).Units.Values)
				{
					if (value.IsOperating())
					{
						list_.Add(value);
					}
				}
				if (list_.Count > 0)
				{
					NewConfiguration(ref list_);
				}
			}
			else
			{
				activeUnit_.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
			}
			activeUnit_.WeaponState = ActiveUnit._ActiveUnitWeaponState.None;
			activeUnit_.ClearManualOrders();
			RemoveUnitFromMission(ref activeUnit_);
			activeUnit_.Doctrine.ClearCachedParentDoctrine();
			activeUnit_.Sensory.vmethod_0(activeUnit_.Sensors_Cached);
			activeUnit_.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
		}
		MustRefreshMainForm = true;
	}

	public static void RemoveUnitFromMission(ref ActiveUnit activeUnit_0)
	{
		string text = "";
		if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: true) != 0)
		{
			text = " (" + activeUnit_0.UnitClass + ")";
		}
		if (Information.IsNothing(activeUnit_0.AssignedMissionOrPackage()))
		{
			if (Information.IsNothing(activeUnit_0.AssignedTaskPool))
			{
				composerRequest.AddMessage(activeUnit_0.Name + text + "没有命令（未分配）", "单元未指定", LoggedMessage.MessageType.UnitAI, 5, activeUnit_0.ObjectID, m_ModelRequest, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				return;
			}
			string name = activeUnit_0.AssignedTaskPool.Name;
			Mission mission = activeUnit_0.AssignedMissionOrPackage();
			ActiveUnit obj = activeUnit_0;
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
			obj.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
			activeUnit_0.AssignedTaskPool = null;
			if (!Information.IsNothing(mission))
			{
				mission.RemoveFlightsWithoutAircraft(composerRequest, m_ModelRequest);
			}
			composerRequest.AddMessage(activeUnit_0.Name + text + "已从任务池中删除：" + name, "单元从任务池中移除", LoggedMessage.MessageType.UnitAI, 5, activeUnit_0.ObjectID, m_ModelRequest, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
			return;
		}
		string name2 = activeUnit_0.AssignedMissionOrPackage().Name;
		Mission mission2 = activeUnit_0.AssignedMissionOrPackage();
		if (activeUnit_0.AI.IsEscort)
		{
			activeUnit_0.AI.IsEscort = false;
		}
		activeUnit_0.Navigator.ClearFlight();
		ActiveUnit obj2 = activeUnit_0;
		Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
		obj2.Set_AssignedMissionOrPackage(null, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
		activeUnit_0.AssignedTaskPool = null;
		if (!Information.IsNothing(mission2))
		{
			mission2.RemoveFlightsWithoutAircraft(composerRequest, m_ModelRequest);
		}
		composerRequest.AddMessage(activeUnit_0.Name + text + "已从任务中删除：" + name2, "单元从任务中移除", LoggedMessage.MessageType.UnitAI, 5, activeUnit_0.ObjectID, m_ModelRequest, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
	}

	public static void ToggleDistanceMeasure()
	{
		SelectedRefPoint = null;
		if (CurrentUserAction == UserAction.MeasuringDistance)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.StartOfMeasurement = default(Geopoint_Struct);
			CurrentUserAction = UserAction.None;
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.StartOfMeasurement = default(Geopoint_Struct);
			CurrentUserAction = UserAction.MeasuringDistance;
		}
	}

	public static void DeployDippingSonar()
	{
		if (SelectedUnit != null && SelectedUnit.IsActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)SelectedUnit;
			if (activeUnit.IsAircraft && ((Aircraft)activeUnit).IsHelicopter && activeUnit.Sensory.HasAvailableDippingSonar && ((Aircraft_AirOps)activeUnit.AirOps).Condition != Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				((Aircraft_AirOps)activeUnit.AirOps).HoverForDippingSonar();
			}
		}
	}

	public static void HoldPosition(ref bool bool_0)
	{
		if (Information.IsNothing(m_ModelRequest) || Information.IsNothing(SelectedUnit) || m_ModelRequest.SelectedUnits.Count == 0)
		{
			return;
		}
		bool_0 = !bool_0;
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && selectedUnit.GetUnitSide() == m_ModelRequest && ((selectedUnit.IsFacility && !((Facility)selectedUnit).IsFixedFacility) || selectedUnit.IsMobileGroundUnit))
			{
				((ActiveUnit)selectedUnit).AI.HoldPosition = bool_0;
			}
		}
	}

	public static void HoldPositionAllUnits(ref bool bool_0)
	{
		if (Information.IsNothing(m_ModelRequest) || m_ModelRequest.SelectedUnits.Count == 0)
		{
			return;
		}
		bool_0 = !bool_0;
		foreach (ActiveUnit unit in m_ModelRequest.Units)
		{
			if (unit.IsActiveUnit && unit.GetUnitSide() == m_ModelRequest && ((unit.IsFacility && !((Facility)unit).IsFixedFacility) || unit.IsMobileGroundUnit))
			{
				unit.AI.HoldPosition = bool_0;
			}
		}
	}

	public static void DropSelectedContacts()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (!selectedUnit.DisableWriter())
			{
				continue;
			}
			Contact contact = (Contact)selectedUnit;
			Side modelRequest = m_ModelRequest;
			Scenario scenario_ = composerRequest;
			modelRequest.DropContact(contact, ref scenario_, bool_0: true);
			Side[] sides_ReadOnly = composerRequest.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				if (side.GetConsidersThisSideToBe(m_ModelRequest) == Misc.PostureStance.Friendly && side != m_ModelRequest && side.Contacts_List.Contains(contact))
				{
					scenario_ = composerRequest;
					side.DropContact(contact, ref scenario_, bool_0: false);
				}
			}
			Side modelRequest2 = m_ModelRequest;
			scenario_ = composerRequest;
			modelRequest2.DropBaseContact(contact, ref scenario_);
		}
		m_ModelRequest.ProcessContactListChanges(composerRequest);
		m_ModelRequest.ProcessBaseContactListChanges(composerRequest);
	}

	public static void ShowWeaponDetails()
	{
		if (SelectedUnit != null && !SelectedUnit.IsGroup && SelectedUnit.IsActiveUnit)
		{
			Side modelRequest = m_ModelRequest;
			Module_Unit.Unit selectedUnit = SelectedUnit;
			string string_ = null;
			if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0))
			{
				theWeaponsWindow.theSelectedUnit = (ActiveUnit)SelectedUnit;
				theWeaponsWindow.Show();
			}
		}
	}

	public static void ShowCommsDetails()
	{
		if (SelectedUnit != null && !SelectedUnit.IsGroup && SelectedUnit.IsActiveUnit)
		{
			Side modelRequest = m_ModelRequest;
			Module_Unit.Unit selectedUnit = SelectedUnit;
			string string_ = null;
			if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0))
			{
				theCommsWindow = new UnitComms();
				theCommsWindow.theSelectedUnit = (ActiveUnit)SelectedUnit;
				theCommsWindow.Show();
			}
		}
	}

	public static void DetachUnits()
	{
		if (composerRequest.Sides_ReadOnly.Count() <= 0 || m_ModelRequest.SelectedUnits.Count <= 0)
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.GetUnitSide() == m_ModelRequest && !selectedUnit.IsWeapon)
			{
				((ActiveUnit)selectedUnit).DetachUnit(bool_0: true, bool_1: true, bool_2: false);
			}
		}
		MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.TSL_Status.Text = "选定的单元与编队分离。";
	}

	public static void SelectNextUnit()
	{
		if (!Information.IsNothing(m_ModelRequest) && CurrentUserAction == UserAction.None)
		{
			List<Module_Unit.Unit> list = MapVisibleUnits.ToList();
			if (list.Count > 0)
			{
				Module_Unit.Unit unit_ = ((Information.IsNothing(SelectedUnit) || !list.Contains(SelectedUnit)) ? list[0] : ((list.IndexOf(SelectedUnit) == list.Count - 1) ? list[0] : list[list.IndexOf(SelectedUnit) + 1]));
				m_ModelRequest.SelectedUnits_Clear();
				list.Clear();
				list = null;
				SelectThisUnit(unit_, bool_0: true);
			}
		}
	}

	public static void SelectPreviousUnit()
	{
		if (!Information.IsNothing(m_ModelRequest))
		{
			List<Module_Unit.Unit> list = MapVisibleUnits.ToList();
			if (list.Count > 0)
			{
				Module_Unit.Unit unit_ = ((Information.IsNothing(SelectedUnit) || !list.Contains(SelectedUnit)) ? list[list.Count - 1] : ((list.IndexOf(SelectedUnit) == 0) ? list[list.Count - 1] : list[list.IndexOf(SelectedUnit) - 1]));
				m_ModelRequest.SelectedUnits_Clear();
				list.Clear();
				list = null;
				SelectThisUnit(unit_, bool_0: true);
			}
		}
	}

	public static void RenameUnitOrContact()
	{
		if (Information.IsNothing(m_ModelRequest) || CurrentUserAction != 0)
		{
			return;
		}
		if (m_ModelRequest.SelectedUnits.Count == 1)
		{
			if (!Information.IsNothing(SelectedUnit))
			{
				ItemExporter.ConnectInterruptibleTemplate.RenameObject.RenamingOption = RenameObject.E_RenamingOption.Unit;
				ItemExporter.ConnectInterruptibleTemplate.RenameObject.ShowDialog();
			}
		}
		else if (m_ModelRequest.SelectedUnits.Count <= 1)
		{
			composerRequest.AddMessage("选择要重命名的单元，编队或目标。", null, LoggedMessage.MessageType.SpecialMessage, 1, null, m_ModelRequest);
		}
		else
		{
			composerRequest.AddMessage("一次只能重命名一个单元，编队或目标。", null, LoggedMessage.MessageType.SpecialMessage, 1, null, m_ModelRequest);
		}
	}

	public static void GodsEyeView()
	{
		if (composerRequest.Sides_ReadOnly.Count() == 0)
		{
			return;
		}
		bool godsEye;
		if (godsEye = CurrentMapProfile.GodsEye)
		{
			if (godsEye)
			{
				CurrentMapProfile.GodsEye = false;
				composerRequest.AddMessage("关闭上帝视角。", "开启上帝视角", LoggedMessage.MessageType.UI, 5, null, m_ModelRequest);
			}
		}
		else
		{
			CurrentMapProfile.GodsEye = true;
			composerRequest.AddMessage("开启上帝视角。", "开启上帝视角", LoggedMessage.MessageType.UI, 5, null, m_ModelRequest);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		MustRefreshMainForm = true;
	}

	public static void RenameRefPoint()
	{
		if (!Information.IsNothing(m_ModelRequest) && CurrentUserAction == UserAction.None)
		{
			if (HighlightedRefPoints.Count == 1)
			{
				ItemExporter.ConnectInterruptibleTemplate.RenameObject.RenamingOption = RenameObject.E_RenamingOption.ReferencePoint;
				ItemExporter.ConnectInterruptibleTemplate.RenameObject.ShowDialog();
			}
			else if (HighlightedRefPoints.Count <= 1)
			{
				composerRequest.AddMessage("选择要重命名的参考点。", null, LoggedMessage.MessageType.SpecialMessage, 1, null, m_ModelRequest);
			}
			else
			{
				composerRequest.AddMessage("一次只能重命名一个参考点。请只选择一个参考点。", null, LoggedMessage.MessageType.SpecialMessage, 1, null, m_ModelRequest);
			}
		}
	}

	public static void Set_UnitIsSpotted()
	{
		if (CurrentGame.GameMode != Game._GameMode.ScenEdit || Information.IsNothing(m_ModelRequest) || m_ModelRequest.SelectedUnits.Count == 0)
		{
			return;
		}
		ActiveUnit activeUnit = null;
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (!selectedUnit.IsWeapon)
			{
				if (selectedUnit.DisableWriter())
				{
					activeUnit = ((Contact)selectedUnit).ActualUnit;
				}
				else if (selectedUnit.IsActiveUnit)
				{
					activeUnit = (ActiveUnit)selectedUnit;
				}
				if (activeUnit == null)
				{
					break;
				}
				string name = activeUnit.SubTypeDescription + " " + activeUnit.UnitType_String + "在" + composerRequest.Time.ToShortDateString() + "-" + composerRequest.Time.ToShortTimeString();
				ReferencePoint referencePoint = new ReferencePoint(selectedUnit.GetLongitude(), selectedUnit.GetLatitude());
				referencePoint.Name = name;
				referencePoint.IsHighlighted = true;
				m_ModelRequest.RefPoints.Add(referencePoint);
				MustRefreshMainForm = true;
			}
		}
	}

	public static void CloneUnit()
	{
		if (!Information.IsNothing(m_ModelRequest) && CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			SelectedRefPoint = null;
			if (!Information.IsNothing(SelectedUnit) && SelectedUnit.IsActiveUnit && ((ActiveUnit)SelectedUnit).GetUnitSide() == m_ModelRequest)
			{
				CurrentUserAction = UserAction.CloningAUnit;
			}
		}
	}

	public static void CopyUnit()
	{
		if (!Information.IsNothing(m_ModelRequest) && CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			SelectedRefPoint = null;
			if (!Information.IsNothing(SelectedUnit) && SelectedUnit.IsActiveUnit)
			{
				CurrentUserAction = UserAction.CopyingAUnit;
			}
		}
	}

	public static void CopyGUID()
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		if (Information.IsNothing(m_ModelRequest) || m_ModelRequest.SelectedUnits.Count <= 0)
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (!Information.IsNothing(selectedUnit))
			{
				if (flag)
				{
					stringBuilder.Append(" , ");
				}
				stringBuilder.Append("{name='" + selectedUnit.Name.ToString() + "', guid='" + selectedUnit.ObjectID + "'}");
				flag = true;
			}
		}
		Clipboard.SetText(stringBuilder.ToString());
	}

	public static void CopyRefPoints()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		_ = m_ModelRequest.RefPoints;
		List<ReferencePoint> highlightedRefPoints = HighlightedRefPoints;
		if (highlightedRefPoints.Count <= 0)
		{
			return;
		}
		foreach (ReferencePoint item in highlightedRefPoints)
		{
			if (!Information.IsNothing(item))
			{
				if (flag)
				{
					stringBuilder.Append(" , ");
				}
				stringBuilder.Append("{name='" + item.Name.ToString() + "', guid='" + item.ObjectID + "', latitude='" + Conversions.ToString(item.Latitude) + "', longitude='" + Conversions.ToString(item.Longitude) + "'}");
				flag = true;
			}
		}
		Clipboard.SetText(stringBuilder.ToString());
	}

	public static void AttackTarget_Auto()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		if (CurrentMapProfile.GodsEye)
		{
			DarkMessageBox.ShowError("在上帝视角下无法下达攻击指令！", "");
			return;
		}
		try
		{
			if (m_ModelRequest.SelectedUnits.Count == 0)
			{
				return;
			}
			foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
			{
				string string_ = null;
				if (!GameGeneral.CanIssueOrdersToThisUnit(m_ModelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0))
				{
					if (selectedUnit.IsActiveUnit)
					{
						((ActiveUnit)selectedUnit).AddMessage(selectedUnit.Name + "不能参与攻击（" + string_ + ")", selectedUnit.Name + " 无法加入攻击", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(selectedUnit.GetLongitude(), selectedUnit.GetLatitude()));
					}
					continue;
				}
				CurrentUserAction = UserAction.TargetingContact_AutoEngage;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101140", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void AttackTarget_Manual()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		if (CurrentMapProfile.GodsEye)
		{
			DarkMessageBox.ShowError("在上帝视角下无法下达攻击指令！", "");
			return;
		}
		try
		{
			if (m_ModelRequest.SelectedUnits.Count == 0)
			{
				return;
			}
			foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
			{
				string string_ = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(m_ModelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0))
				{
					if (!selectedUnit.IsWeapon || (selectedUnit.IsWeapon & ((Weapon)selectedUnit).IsPalletWeapon))
					{
						CurrentUserAction = UserAction.TargetingContact_ManualFire;
						break;
					}
				}
				else if (selectedUnit.IsActiveUnit && !string.IsNullOrEmpty(string_))
				{
					((ActiveUnit)selectedUnit).AddMessage(selectedUnit.Name + "不能参与攻击（" + string_ + ")", selectedUnit.Name + " 无法加入攻击", LoggedMessage.MessageType.UnitAI, 0, bool_0: false, new Geopoint_Struct(selectedUnit.GetLongitude(), selectedUnit.GetLatitude()));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101141", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void EditFormation()
	{
		if (SelectedUnit != null && SelectedUnit.GetUnitSide() == m_ModelRequest)
		{
			Side modelRequest = m_ModelRequest;
			Module_Unit.Unit selectedUnit = SelectedUnit;
			string string_ = null;
			if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0) && SelectedUnit.IsGroup)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = 20000;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(SelectedUnit.GetLongitude(), SelectedUnit.GetLatitude()));
				CurrentMapProfile.ViewMode = MapProfile.MapViewMode.UnitView;
				ItemExporter.ConnectInterruptibleTemplate.FormationEditor.SelectedGroup = (Group)SelectedUnit;
				ItemExporter.ConnectInterruptibleTemplate.FormationEditor.Show();
			}
		}
	}

	public static void smethod_2()
	{
		if (m_ModelRequest == null)
		{
			return;
		}
		if (CurrentMapProfile.GodsEye)
		{
			DarkMessageBox.ShowError("在上帝视角下无法下达攻击指令！", "Error");
			return;
		}
		try
		{
			if (m_ModelRequest.SelectedUnits.Count == 0)
			{
				return;
			}
			foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
			{
				Side modelRequest = m_ModelRequest;
				string string_ = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0) && !selectedUnit.IsWeapon)
				{
					CurrentUserAction = UserAction.const_18;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101142", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ShowAirOps()
	{
		ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Clear();
		if (m_ModelRequest == null)
		{
			return;
		}
		if (ItemExporter.ConnectInterruptibleTemplate.AirOps.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AirOps.Close();
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (Information.IsNothing(selectedUnit) || !selectedUnit.IsActiveUnit)
			{
				continue;
			}
			if (selectedUnit.IsGroup && ((Group)selectedUnit).Type == Group.GroupType.SurfaceGroup)
			{
				foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
				{
					if (value.AirFacilities_ReadOnly.Length != 0)
					{
						ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Add(value.ObjectID);
					}
				}
			}
			else if (((ActiveUnit)selectedUnit).AirFacilities_ReadOnly.Length != 0)
			{
				ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Add(selectedUnit.ObjectID);
			}
		}
		if (ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Count <= 0 && !Information.IsNothing(SelectedUnit) && SelectedUnit.IsActiveUnit)
		{
			if (SelectedUnit.IsGroup && ((Group)SelectedUnit).Type == Group.GroupType.SurfaceGroup)
			{
				foreach (ActiveUnit value2 in ((Group)SelectedUnit).Units.Values)
				{
					if (value2.AirFacilities_ReadOnly.Length != 0)
					{
						ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Add(value2.ObjectID);
					}
				}
			}
			else if (((ActiveUnit)SelectedUnit).AirFacilities_ReadOnly.Length != 0)
			{
				ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Add(SelectedUnit.ObjectID);
			}
		}
		if (ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Count <= 0)
		{
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit && m_ModelRequest.SelectedUnits.Count == 1 && m_ModelRequest.SelectedUnits.First().IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)m_ModelRequest.SelectedUnits.First();
				ItemExporter.ConnectInterruptibleTemplate.AirOps.SelectedHosts_IDs.Add(activeUnit.ObjectID);
				ItemExporter.ConnectInterruptibleTemplate.AirOps.TabControl1.SelectTab(1);
				ItemExporter.ConnectInterruptibleTemplate.AirOps.Show();
			}
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.AirOps.Show();
		}
	}

	public static void ShowDockingOps()
	{
		ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Clear();
		if (m_ModelRequest == null)
		{
			return;
		}
		if (ItemExporter.ConnectInterruptibleTemplate.DockingOps.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.DockingOps.Close();
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (Information.IsNothing(selectedUnit) || !selectedUnit.IsActiveUnit)
			{
				continue;
			}
			if (selectedUnit.IsGroup && (((Group)selectedUnit).Type == Group.GroupType.SurfaceGroup || ((Group)selectedUnit).Type == Group.GroupType.SubGroup))
			{
				foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
				{
					if (value.DockFacilities_ReadOnly.Length != 0)
					{
						ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Add(value);
					}
				}
			}
			else if (((ActiveUnit)selectedUnit).DockFacilities_ReadOnly.Length != 0)
			{
				ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Add((ActiveUnit)selectedUnit);
			}
		}
		if (ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Count <= 0 && !Information.IsNothing(SelectedUnit) && SelectedUnit.IsActiveUnit)
		{
			if (SelectedUnit.IsGroup && (((Group)SelectedUnit).Type == Group.GroupType.SurfaceGroup || ((Group)SelectedUnit).Type == Group.GroupType.SubGroup))
			{
				foreach (ActiveUnit value2 in ((Group)SelectedUnit).Units.Values)
				{
					if (value2.DockFacilities_ReadOnly.Length != 0)
					{
						ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Add(value2);
					}
				}
			}
			else if (((ActiveUnit)SelectedUnit).DockFacilities_ReadOnly.Length != 0)
			{
				ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Add((ActiveUnit)SelectedUnit);
			}
		}
		if (ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Count <= 0)
		{
			if (CurrentGame.GameMode == Game._GameMode.ScenEdit && m_ModelRequest.SelectedUnits.Count == 1 && m_ModelRequest.SelectedUnits.First().IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)m_ModelRequest.SelectedUnits.First();
				ItemExporter.ConnectInterruptibleTemplate.DockingOps.SelectedHosts.Add(activeUnit);
				ItemExporter.ConnectInterruptibleTemplate.DockingOps.TabControl1.SelectTab(1);
				ItemExporter.ConnectInterruptibleTemplate.DockingOps.Show();
				ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.Mode = 1;
				ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.ParentForm = ItemExporter.ConnectInterruptibleTemplate.DockingOps;
				ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.theSelectedUnit = activeUnit;
				ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.Show();
			}
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.DockingOps.Show();
		}
	}

	public static void ShowSensorsForSelectedUnit()
	{
		if (Information.IsNothing(SelectedUnit) || !SelectedUnit.IsActiveUnit)
		{
			return;
		}
		Side modelRequest = m_ModelRequest;
		Module_Unit.Unit selectedUnit = SelectedUnit;
		string string_ = null;
		if (!GameGeneral.CanIssueOrdersToThisUnit(modelRequest, selectedUnit, bool_1: false, ref string_, CurrentMapProfile.String_0))
		{
			return;
		}
		if (Information.IsNothing(_IssuerRequest))
		{
			if ((SelectedUnit.IsWeapon && Information.IsNothing(((Weapon)SelectedUnit).DataLinkParent)) || SelectedUnit.GetUnitSide() != m_ModelRequest)
			{
				return;
			}
			if (m_ModelRequest.SelectedUnits.Count <= 1)
			{
				if (SelectedUnit.IsGroup)
				{
					ItemExporter.ConnectInterruptibleTemplate.MultipleUnitSensors.SelectedUnits = ((Group)SelectedUnit).ToList();
					ItemExporter.ConnectInterruptibleTemplate.MultipleUnitSensors.Show();
				}
				else
				{
					OpenSensorsWindow();
				}
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.MultipleUnitSensors.SelectedUnits = m_ModelRequest.SelectedUnits.ToList();
				ItemExporter.ConnectInterruptibleTemplate.MultipleUnitSensors.Show();
			}
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MultipleUnitSensors.Show();
		}
	}

	public static void MoveUnit()
	{
		if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			SelectedRefPoint = null;
			if (CurrentUserAction == UserAction.None && !Information.IsNothing(SelectedUnit))
			{
				CurrentUserAction = UserAction.const_11;
			}
		}
	}

	public static void DeleteRefPoint()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		ObservableList<ReferencePoint> refPoints = m_ModelRequest.RefPoints;
		foreach (ReferencePoint highlightedRefPoint in HighlightedRefPoints)
		{
			if (!highlightedRefPoint.IsLocked)
			{
				refPoints.Remove(highlightedRefPoint);
			}
		}
		SelectedRefPoint = null;
		MustRefreshMainForm = true;
	}

	public static void MarkContactHostile()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.DisableWriter())
			{
				Contact contact = (Contact)selectedUnit;
				if (contact.GetStance(m_ModelRequest) != Misc.PostureStance.Hostile)
				{
					contact.SetStance(m_ModelRequest, bool_0: true, Misc.PostureStance.Hostile);
					composerRequest.AddMessage("目标：" + contact.Name + "已被手动标记为敌对！", "目标被标记为敌方", LoggedMessage.MessageType.ContactChange, 1, null, m_ModelRequest, new Geopoint_Struct(contact.GetLongitude(), contact.GetLatitude()));
				}
			}
		}
		MustRefreshMainForm = true;
	}

	public static void MarkContactUnfriendly()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.DisableWriter())
			{
				Contact contact = (Contact)selectedUnit;
				if (contact.GetStance(m_ModelRequest) != Misc.PostureStance.Unfriendly)
				{
					contact.SetStance(m_ModelRequest, bool_0: true, Misc.PostureStance.Unfriendly);
					composerRequest.AddMessage("目标：" + contact.Name + "手动标记为不友好。", "目标被标记为非友方", LoggedMessage.MessageType.ContactChange, 1, null, m_ModelRequest, new Geopoint_Struct(contact.GetLongitude(), contact.GetLatitude()));
				}
			}
		}
		MustRefreshMainForm = true;
	}

	public static void MarkContactNeutral()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.DisableWriter())
			{
				Contact contact = (Contact)selectedUnit;
				if (contact.GetStance(m_ModelRequest) != 0)
				{
					contact.SetStance(m_ModelRequest, bool_0: true, Misc.PostureStance.Neutral);
					composerRequest.AddMessage("目标：" + contact.Name + "手动标记为中性。", "目标被标记为中立", LoggedMessage.MessageType.ContactChange, 1, null, m_ModelRequest, new Geopoint_Struct(contact.GetLongitude(), contact.GetLatitude()));
				}
			}
		}
		MustRefreshMainForm = true;
	}

	public static void MarkContactFriendly()
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.DisableWriter())
			{
				Contact contact = (Contact)selectedUnit;
				if (contact.GetStance(m_ModelRequest) != Misc.PostureStance.Friendly)
				{
					contact.SetStance(m_ModelRequest, bool_0: true, Misc.PostureStance.Friendly);
					composerRequest.AddMessage("目标：" + contact.Name + "手动标记为友好。", "目标被标记为友方", LoggedMessage.MessageType.ContactChange, 1, null, m_ModelRequest, new Geopoint_Struct(contact.GetLongitude(), contact.GetLatitude()));
				}
			}
		}
		MustRefreshMainForm = true;
	}

	public static void IgnorePlottedCourse_SelectedUnits(ref Doctrine._UseIgnorePlottedCourse? nullable_0)
	{
		if (m_ModelRequest.SelectedUnits.Count <= 0)
		{
			if (!Information.IsNothing(SelectedUnit) && SelectedUnit.IsActiveUnit && SelectedUnit.GetUnitSide() == m_ModelRequest && !SelectedUnit.IsWeapon)
			{
				Doctrine doctrine = ((ActiveUnit)SelectedUnit).Doctrine;
				if (doctrine.GetIgnorePlottedCourse_PlayerEditable(composerRequest))
				{
					doctrine.SetIgnorePlottedCourse(composerRequest, bool_0: false, true, bool_1: false, bool_2: false, nullable_0);
				}
			}
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (!selectedUnit.IsActiveUnit || selectedUnit.GetUnitSide() != m_ModelRequest || selectedUnit.IsWeapon)
			{
				continue;
			}
			Doctrine doctrine2 = ((ActiveUnit)selectedUnit).Doctrine;
			if (doctrine2.GetIgnorePlottedCourse_PlayerEditable(composerRequest))
			{
				bool? nullable_ = false;
				if (!Information.IsNothing(SelectedUnit) && selectedUnit == SelectedUnit)
				{
					nullable_ = true;
				}
				doctrine2.SetIgnorePlottedCourse(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
			}
		}
	}

	public static void IgnorePlottedCourse_AllUnits(ref Doctrine._UseIgnorePlottedCourse? nullable_0)
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		foreach (ActiveUnit unit in m_ModelRequest.Units)
		{
			if (!unit.IsActiveUnit || unit.GetUnitSide() != m_ModelRequest || unit.IsWeapon)
			{
				continue;
			}
			Doctrine doctrine = unit.Doctrine;
			if (doctrine.GetIgnorePlottedCourse_PlayerEditable(composerRequest))
			{
				bool? nullable_ = false;
				if (!Information.IsNothing(SelectedUnit) && unit == SelectedUnit)
				{
					nullable_ = true;
				}
				doctrine.SetIgnorePlottedCourse(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
			}
		}
	}

	public static void WeaponsHold_AllUnits(ref Doctrine._WCS? nullable_0)
	{
		if (m_ModelRequest.Units.Count == 0)
		{
			return;
		}
		foreach (ActiveUnit unit in m_ModelRequest.Units)
		{
			if (unit.IsActiveUnit && unit.GetUnitSide() == m_ModelRequest && !unit.IsWeapon)
			{
				bool? nullable_ = false;
				if (!Information.IsNothing(SelectedUnit) && unit == SelectedUnit)
				{
					nullable_ = true;
				}
				Doctrine doctrine = unit.Doctrine;
				if (doctrine.GetWeaponControlStatus_Air_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Air(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine.GetWeaponControlStatus_Surface_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Surface(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine.GetWeaponControlStatus_Submarine_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Submarine(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine.GetWeaponControlStatus_Land_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Land(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
			}
		}
	}

	public static void WeaponsHold_SelectedUnits(ref Doctrine._WCS? nullable_0)
	{
		if (Information.IsNothing(m_ModelRequest))
		{
			return;
		}
		if (m_ModelRequest.SelectedUnits.Count <= 0)
		{
			if (!Information.IsNothing(SelectedUnit) && SelectedUnit.IsActiveUnit && SelectedUnit.GetUnitSide() == m_ModelRequest && !SelectedUnit.IsWeapon)
			{
				Doctrine doctrine = ((ActiveUnit)SelectedUnit).Doctrine;
				if (doctrine.GetWeaponControlStatus_Air_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Air(composerRequest, bool_0: false, true, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine.GetWeaponControlStatus_Surface_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Surface(composerRequest, bool_0: false, true, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine.GetWeaponControlStatus_Submarine_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Submarine(composerRequest, bool_0: false, true, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine.GetWeaponControlStatus_Land_PlayerEditable(composerRequest))
				{
					doctrine.SetWeaponControlStatus_Land(composerRequest, bool_0: false, true, bool_1: false, bool_2: false, nullable_0);
				}
			}
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && selectedUnit.GetUnitSide() == m_ModelRequest && !selectedUnit.IsWeapon)
			{
				bool? nullable_ = false;
				if (!Information.IsNothing(SelectedUnit) && selectedUnit == SelectedUnit)
				{
					nullable_ = true;
				}
				Doctrine doctrine2 = ((ActiveUnit)selectedUnit).Doctrine;
				if (doctrine2.GetWeaponControlStatus_Air_PlayerEditable(composerRequest))
				{
					doctrine2.SetWeaponControlStatus_Air(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine2.GetWeaponControlStatus_Surface_PlayerEditable(composerRequest))
				{
					doctrine2.SetWeaponControlStatus_Surface(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine2.GetWeaponControlStatus_Submarine_PlayerEditable(composerRequest))
				{
					doctrine2.SetWeaponControlStatus_Submarine(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
				if (doctrine2.GetWeaponControlStatus_Land_PlayerEditable(composerRequest))
				{
					doctrine2.SetWeaponControlStatus_Land(composerRequest, bool_0: false, nullable_, bool_1: false, bool_2: false, nullable_0);
				}
			}
		}
	}

	public static void DeselectAllUnits(List<Module_Unit.Unit> list_0)
	{
		if (m_ModelRequest == null)
		{
			return;
		}
		foreach (Module_Unit.Unit item in m_ModelRequest.SelectedUnits.ToList())
		{
			if (list_0 != null && list_0.Count > 0)
			{
				foreach (Module_Unit.Unit item2 in list_0)
				{
					Operators.CompareString(item.ObjectID, item2.ObjectID, TextCompare: true);
				}
				m_ModelRequest.SelectedUnits_Remove(item);
			}
			if (list_0 == null || list_0.Count == 0)
			{
				SelectThisUnit(null, bool_0: true, bool_1: false);
			}
		}
	}

	public static void DeselectThisUnit(Module_Unit.Unit unit_0)
	{
		if (m_ModelRequest.SelectedUnits.Contains(unit_0))
		{
			m_ModelRequest.SelectedUnits_Remove(unit_0);
			SelectThisUnit(null, bool_0: true);
		}
	}

	public static void OpenSensorsWindow()
	{
		if (!Information.IsNothing(SelectedUnit) && (!SelectedUnit.IsWeapon || !Information.IsNothing(((Weapon)SelectedUnit).DataLinkParent)) && (Information.IsNothing(theSensorsWindow) || !theSensorsWindow.Visible))
		{
			theSensorsWindow = new UnitSensors();
			theSensorsWindow.Show();
		}
	}

	public static void DisengageTargets()
	{
		if (Information.IsNothing(m_ModelRequest) || m_ModelRequest.SelectedUnits.Count == 0)
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in m_ModelRequest.SelectedUnits)
		{
			if (!selectedUnit.IsActiveUnit || selectedUnit.GetUnitSide() != m_ModelRequest || selectedUnit.IsWeapon)
			{
				continue;
			}
			if (selectedUnit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
				{
					ActiveUnit activeUnit_ = value;
					activeUnit_.AI.ClearAllTargets(ref activeUnit_);
				}
			}
			else
			{
				ActiveUnit activeUnit_2 = (ActiveUnit)selectedUnit;
				activeUnit_2.AI.ClearAllTargets(ref activeUnit_2);
			}
		}
		MustRefreshMainForm = true;
	}

	public static void DeleteWaypoint()
	{
		if (m_ModelRequest == null || _IssuerRequest == null)
		{
			return;
		}
		if (_IssuerRequest.IncludeReponse())
		{
			DarkMessageBox.ShowWarning("无法删除巡逻航点！请在Flightplan编辑器中更改航点类型，然后重试。", string.Empty);
			return;
		}
		if (_IssuerRequest.CheckReponse())
		{
			DarkMessageBox.ShowWarning("无法删除警戒航点！请在Flightplan编辑器中更改航点类型，然后重试。", string.Empty);
			return;
		}
		if (_IssuerRequest.Type == Waypoint.WaypointType.TakeOff)
		{
			DarkMessageBox.ShowWarning("无法删除起飞航点！请在Flightplan编辑器中删除航点。", string.Empty);
			return;
		}
		if (_IssuerRequest.Type == Waypoint.WaypointType.LandingMarshal)
		{
			DarkMessageBox.ShowWarning("无法删除着陆集合航点！请在Flightplan编辑器中删除航点。", string.Empty);
			return;
		}
		if (_IssuerRequest.Type == Waypoint.WaypointType.Land)
		{
			DarkMessageBox.ShowWarning("无法删除着陆航点！请在Flightplan编辑器中删除航点。", string.Empty);
			return;
		}
		if (_IssuerRequest.SetupReponse())
		{
			DarkMessageBox.ShowWarning("无法删除拆分编队航点。在Flightplan编辑器中更改编队队形，然后重试。", string.Empty);
			return;
		}
		bool flag = false;
		foreach (ActiveUnit unit in m_ModelRequest.Units)
		{
			if (unit.Navigator.PlottedCourse.Contains(_IssuerRequest))
			{
				unit.Navigator.RemoveWaypoint_Soft(_IssuerRequest, bool_1: true);
			}
		}
		if (!flag)
		{
			foreach (Mission mission in m_ModelRequest.Missions)
			{
				if (mission.TestValue())
				{
					foreach (Mission.Flight flight in mission.FlightList)
					{
						Waypoint[] flightPlan = flight.FlightPlan;
						Waypoint[] array = flightPlan;
						foreach (Waypoint waypoint in array)
						{
							if (waypoint != _IssuerRequest)
							{
								if (Information.IsNothing(waypoint.Waypoint_LeadElementWingman) || waypoint.Waypoint_LeadElementWingman != _IssuerRequest)
								{
									if (Information.IsNothing(waypoint.Waypoint_SecondElement) || waypoint.Waypoint_SecondElement != _IssuerRequest)
									{
										if (Information.IsNothing(waypoint.Waypoint_SecondElementWingman) || waypoint.Waypoint_SecondElementWingman != _IssuerRequest)
										{
											if (Information.IsNothing(waypoint.Waypoint_ThirdElement) || waypoint.Waypoint_ThirdElement != _IssuerRequest)
											{
												if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman) && waypoint.Waypoint_ThirdElementWingman == _IssuerRequest)
												{
													DarkMessageBox.ShowWarning("无法删除拆分编队航点。在Flightplan编辑器中更改编队队形，然后重试。", string.Empty);
													flag = true;
													break;
												}
												continue;
											}
											DarkMessageBox.ShowWarning("无法删除拆分编队航点。在Flightplan编辑器中更改编队队形，然后重试。", string.Empty);
											flag = true;
											break;
										}
										DarkMessageBox.ShowWarning("无法删除拆分编队航点。在Flightplan编辑器中更改编队队形，然后重试。", string.Empty);
										flag = true;
										break;
									}
									DarkMessageBox.ShowWarning("无法删除拆分编队航点。在Flightplan编辑器中更改编队队形，然后重试。", string.Empty);
									flag = true;
									break;
								}
								DarkMessageBox.ShowWarning("无法删除拆分编队航点。在Flightplan编辑器中更改编队队形，然后重试。", string.Empty);
								flag = true;
								break;
							}
							if (waypoint.SetupReponse())
							{
								DarkMessageBox.ShowWarning("无法删除拆分编队航点。在Flightplan编辑器中更改编队队形，然后重试。", string.Empty);
							}
							else
							{
								ActiveUnit_Navigator.RemoveWaypoint_Hard(composerRequest, mission, flight, _IssuerRequest);
								RegistryParameterMessage.AwakeCustomer();
								if (FlightPlanEditorWindow.Visible)
								{
									FlightPlanEditorWindow.NewPolicy();
								}
								if (AirTaskingOrderWindow.Visible)
								{
									AirTaskingOrderWindow.RefreshWindow();
								}
								if (FlightPlanTimeWindow.Visible)
								{
									FlightPlanTimeWindow.Visible = false;
								}
							}
							flag = true;
							break;
						}
						if (flag)
						{
							break;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
		}
		SelectedWaypoint = null;
		MustRefreshMainForm = true;
	}

	public static void DeleteUnit()
	{
		try
		{
			if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
			{
				return;
			}
			Module_Unit.Unit selectedUnit = SelectedUnit;
			List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
			List<Module_Unit.Unit> list2 = new List<Module_Unit.Unit>();
			foreach (Module_Unit.Unit selectedUnit2 in m_ModelRequest.SelectedUnits)
			{
				if (!selectedUnit2.IsGroup || DarkMessageBox.ShowWarning("仅删除陆战单元 " + selectedUnit2.Name + " 而不删除编组中的其它单元？", "删除编组", DarkDialogButton.OkCancel) == DialogResult.OK)
				{
					continue;
				}
				if (DarkMessageBox.ShowWarning("删除编组 " + selectedUnit2.Name + " 以及编组中的所有单元？", "删除编组", DarkDialogButton.OkCancel) == DialogResult.OK)
				{
					foreach (ActiveUnit value in ((Group)SelectedUnit).Units.Values)
					{
						list.Add(value);
					}
				}
				else
				{
					list2.Add(selectedUnit2);
				}
			}
			if (list.Count > 0)
			{
				foreach (Module_Unit.Unit item in list)
				{
					m_ModelRequest.SelectedUnits_Add(item, bool_0: false);
				}
			}
			if (list2.Count > 0)
			{
				foreach (Module_Unit.Unit item2 in list2)
				{
					m_ModelRequest.SelectedUnits_Remove(item2);
				}
			}
			if (m_ModelRequest.SelectedUnits.Count <= 1)
			{
				if (m_ModelRequest.SelectedUnits.Count == 1)
				{
					if (!Information.IsNothing(SelectedUnit))
					{
						if (SelectedUnit.DisableWriter())
						{
							m_ModelRequest.Contacts.Remove(SelectedUnit.ObjectID);
							m_ModelRequest.BaseContacts.Remove(SelectedUnit.ObjectID);
						}
						else
						{
							composerRequest.DeleteUnitImmediately(SelectedUnit.ObjectID, bool_0: true, "Unit deleted");
						}
						SelectThisUnit(null, bool_0: true);
						MustRefreshMainForm = true;
					}
				}
				else
				{
					SelectThisUnit(selectedUnit, bool_0: true);
				}
			}
			else if (DarkMessageBox.ShowWarning("确定要删除 " + Conversions.ToString(m_ModelRequest.SelectedUnits.Count) + " 个单元？", "即将删除多个单元", DarkDialogButton.OkCancel) == DialogResult.OK)
			{
				List<ActiveUnit> list3 = new List<ActiveUnit>();
				foreach (Module_Unit.Unit selectedUnit3 in m_ModelRequest.SelectedUnits)
				{
					if (selectedUnit3.IsActiveUnit)
					{
						list3.Add((ActiveUnit)selectedUnit3);
					}
					else if (selectedUnit3.DisableWriter())
					{
						m_ModelRequest.Contacts.Remove(selectedUnit3.ObjectID);
						m_ModelRequest.BaseContacts.Remove(selectedUnit3.ObjectID);
					}
				}
				foreach (ActiveUnit item3 in list3)
				{
					composerRequest.DeleteUnitImmediately(item3.ObjectID, bool_0: true, "Unit deleted");
				}
				List<ActiveUnit> list4 = new List<ActiveUnit>();
				foreach (ActiveUnit morituriUnit in composerRequest.MorituriUnits)
				{
					if (morituriUnit.IsGroup)
					{
						list4.Add(morituriUnit);
					}
				}
				foreach (ActiveUnit item4 in list4)
				{
					composerRequest.DeleteUnitImmediately(item4.ObjectID, bool_0: true, "编组已被删除");
				}
				SelectThisUnit(null, bool_0: true);
				MustRefreshMainForm = true;
			}
			else
			{
				if (list.Count <= 0)
				{
					return;
				}
				{
					foreach (Module_Unit.Unit item5 in list)
					{
						m_ModelRequest.SelectedUnits_Remove(item5);
					}
					return;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101144", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void DeleteAllUnit(HashSet<Module_Unit.Unit> hashSet_0 = null)
	{
		try
		{
			if (hashSet_0 != null)
			{
				HashSet<Module_Unit.Unit> hashSet = new HashSet<Module_Unit.Unit>();
				foreach (Module_Unit.Unit item in hashSet_0)
				{
					if (item.DisableWriter())
					{
						ActiveUnit actualUnit = ((Contact)item).ActualUnit;
						if (!hashSet.Contains(actualUnit) && !hashSet_0.Contains(actualUnit))
						{
							hashSet.Add(actualUnit);
						}
					}
				}
				hashSet_0.UnionWith(hashSet);
			}
			if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
			{
				return;
			}
			Side[] sides_ReadOnly = composerRequest.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i++)
			{
				foreach (ActiveUnit item2 in sides_ReadOnly[i].Units.ToList())
				{
					if (hashSet_0 == null || !hashSet_0.Contains(item2))
					{
						composerRequest.DeleteUnitImmediately(item2.ObjectID, bool_0: true, "Unit deleted");
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101144_b", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static void PushConfiguration(Scenario scenario_0, bool bool_0, string string_0)
	{
		try
		{
			if (bool_0 && scenario_0.SecondIsChangingOnThisPulse)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Clear();
				List<LoggedMessage> list = GameGeneral.ViewInvocation(scenario_0);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					try
					{
						LoggedMessage loggedMessage = list[i];
						string text = ((loggedMessage.Side == null) ? "" : ("[" + loggedMessage.Side.Name + "] "));
						stringBuilder.Append(loggedMessage.Timestamp.ToString() + " - " + text + loggedMessage.Text + "\r\n\r\n");
						loggedMessage.ProcessedByClient = true;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				StreamWriter obj = (string.IsNullOrEmpty(string_0) ? File.AppendText(Path.Combine(GameGeneral.LogsPath, CurrentGame.AALog_Name + ".txt")) : File.AppendText(string_0));
				obj.Write(stringBuilder.ToString());
				obj.Close();
			}
			int count = scenario_0.MessageLog.Count;
			List<LoggedMessage> list2 = new List<LoggedMessage>(count);
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				try
				{
					LoggedMessage loggedMessage2 = scenario_0.MessageLog[j];
					if (loggedMessage2 != null)
					{
						list2.Add(loggedMessage2);
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			List<LoggedMessage> list3 = (from theMes in list2
				orderby theMes.Timestamp descending, theMes.Increment descending
				select theMes).ToList();
			count = list3.Count;
			testsRequest.Clear();
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			int num3;
			foreach (Side side in array)
			{
				num3 = 0;
				int num4 = count - 1;
				for (int k = 0; k <= num4; k++)
				{
					LoggedMessage loggedMessage3 = list3[k];
					if (loggedMessage3.Side != null && loggedMessage3.Side == side)
					{
						num3++;
						if (num3 > ruleRequest)
						{
							testsRequest.Add(loggedMessage3);
						}
					}
				}
			}
			num3 = 0;
			int num5 = count - 1;
			for (int l = 0; l <= num5; l++)
			{
				LoggedMessage loggedMessage4 = list3[l];
				if (loggedMessage4.Side == null && num3 > ruleRequest)
				{
					testsRequest.Add(loggedMessage4);
				}
			}
			interpreterRequest = new ConcurrentQueue<int>();
			if (testsRequest.Count <= 0)
			{
				return;
			}
			Parallel.ForEach(testsRequest, delegate(LoggedMessage theMess)
			{
				int num6 = IndexOf_Fast(scenario_0.MessageLog, theMess);
				if (num6 >= 0)
				{
					interpreterRequest.Enqueue(num6);
				}
			});
			if (interpreterRequest.Count <= 0)
			{
				return;
			}
			List<int> list4 = new List<int>(interpreterRequest);
			list4.Sort();
			list4.Reverse();
			foreach (int item in list4)
			{
				if (item < scenario_0.MessageLog.Count)
				{
					scenario_0.MessageLog.RemoveAt(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200367", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static int IndexOf_Fast(List<LoggedMessage> list_0, LoggedMessage loggedMessage_0)
	{
		int num = list_0.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (list_0[i] == loggedMessage_0)
			{
				return i;
			}
		}
		return -1;
	}

	public static bool CanBeShownGhosted(ref ActiveUnit activeUnit_0, bool bool_0, Contact contact_0, Module_Unit.Unit unit_0)
	{
		if (bool_0)
		{
			return true;
		}
		if (activeUnit_0.IsGroupMember())
		{
			switch (CurrentMapProfile.ViewMode)
			{
			case MapProfile.MapViewMode.GroupView:
				if (SimConfiguration.DefaultGamePreferences.ShowGhostedGroupMembers == Game.GamePreferences.GhostedGroupMembersVisibilitySetting.All)
				{
					return true;
				}
				if (SimConfiguration.DefaultGamePreferences.ShowGhostedGroupMembers == Game.GamePreferences.GhostedGroupMembersVisibilitySetting.SelectedUnit)
				{
					if (contact_0 == null)
					{
						return activeUnit_0.GetParentGroup() == SelectedUnit;
					}
					if (!activeUnit_0.IsFacility && !activeUnit_0.IsMobileGroundUnit)
					{
						return true;
					}
					if (SelectedUnit != null && SelectedUnit.DisableWriter())
					{
						return activeUnit_0.GetParentGroup() == ((Contact)SelectedUnit).ActualUnit;
					}
					return false;
				}
				if (SimConfiguration.DefaultGamePreferences.ShowGhostedGroupMembers == Game.GamePreferences.GhostedGroupMembersVisibilitySetting.DontShow)
				{
					if (contact_0 == null)
					{
						return false;
					}
					if (!activeUnit_0.IsFacility && !activeUnit_0.IsMobileGroundUnit)
					{
						return true;
					}
					return false;
				}
				break;
			case MapProfile.MapViewMode.UnitView:
				return true;
			}
			return false;
		}
		return true;
	}

	private static bool InvokeConfiguration()
	{
		if (composerRequest.TimeCompression_SimSeconds == 1)
		{
			if (composerRequest.Time.Millisecond - 100 <= 0)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private static void SetupConfiguration(float float_0)
	{
		try
		{
			if (CurrentGame == null || composerRequest.Sides_ReadOnly.Length == 0 || _ProductClass || m_ContainerRequest || !SimConfiguration.DefaultGamePreferences.UseAutosave || !(AutosaveCountdown <= 0.0))
			{
				return;
			}
			AutosaveCountdown = 20000.0;
			Task.Factory.StartNew(delegate
			{
				m_ContainerRequest = true;
				try
				{
					PerformAutosave(CurrentScenario);
					m_ContainerRequest = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					m_ContainerRequest = false;
					ProjectData.ClearProjectError();
				}
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200656", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ExcludeConfiguration()
	{
		try
		{
			if (!_InterceptorClass || !InvokeConfiguration())
			{
				return;
			}
			while (composerRequest.SerializationInProgress)
			{
				Thread.Sleep(20);
			}
			MemoryTributary Local_ScenClone = GameGeneral.PostBridge(composerRequest);
			DateTime Local_ScenTime = composerRequest.Time;
			if (Local_ScenClone.Length > 0)
			{
				Task.Factory.StartNew(delegate
				{
					_DatabaseClass.QueueSnapshotToSave(Local_ScenTime, Local_ScenClone);
				});
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200657", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void PerformAutosave(Scenario scenario_0)
	{
		try
		{
			if (CurrentGame.Status != 0)
			{
				if (string.IsNullOrEmpty(composerRequest.Title))
				{
					composerRequest.Title = "Untitled";
				}
				composerRequest.LastSavedInScenEdit = CurrentGame.GameMode == Game._GameMode.ScenEdit;
				ScenContainer scenContainer = new ScenContainer(composerRequest);
				scenContainer.AttachAndCompressScenarioObject(GameGeneral.PostBridge(composerRequest));
				string text = GameGeneral.ScenariosRootPath + "\\Autosaves";
				string text2 = composerRequest.Title;
				char[] invalidFileNameChars2 = Path.GetInvalidFileNameChars();
				char[] array = invalidFileNameChars2;
				foreach (char c in array)
				{
					text2 = text2.Replace(Conversions.ToString(c), "");
				}
				text2 = text2.TrimEnd(' ');
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				text = text + "\\" + text2;
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				scenContainer.SaveToFile(text + "\\Temp.scen");
				if (FileExistsNative.FileExistsFast(text + "\\Autosave_100sec.scen"))
				{
					File.Delete(text + "\\Autosave_100sec.scen");
				}
				if (FileExistsNative.FileExistsFast(text + "\\Autosave_80sec.scen"))
				{
					File.Move(text + "\\Autosave_80sec.scen", text + "\\Autosave_100sec.scen");
				}
				if (FileExistsNative.FileExistsFast(text + "\\Autosave_60sec.scen"))
				{
					File.Move(text + "\\Autosave_60sec.scen", text + "\\Autosave_80sec.scen");
				}
				if (FileExistsNative.FileExistsFast(text + "\\Autosave_40sec.scen"))
				{
					File.Move(text + "\\Autosave_40sec.scen", text + "\\Autosave_60sec.scen");
				}
				if (FileExistsNative.FileExistsFast(text + "\\Autosave_20sec.scen"))
				{
					File.Move(text + "\\Autosave_20sec.scen", text + "\\Autosave_40sec.scen");
				}
				if (FileExistsNative.FileExistsFast(text + "\\Autosave.scen"))
				{
					File.Move(text + "\\Autosave.scen", text + "\\Autosave_20sec.scen");
				}
				File.Move(text + "\\Temp.scen", text + "\\Autosave.scen");
				File.Delete(GameGeneral.ScenariosRootPath + "\\Autosave.scen");
				File.Copy(text + "\\Autosave.scen", GameGeneral.ScenariosRootPath + "\\Autosave.scen");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			string text3 = GameGeneral.ScenariosRootPath + "\\Autosaves";
			if (Directory.Exists(text3))
			{
				string text4 = composerRequest.Title;
				char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
				char[] array2 = invalidFileNameChars;
				foreach (char c2 in array2)
				{
					text4 = text4.Replace(Conversions.ToString(c2), "");
				}
				text3 = text3 + "\\" + text4;
				if (Directory.Exists(text3) && File.Exists(text3 + "\\Temp.scen"))
				{
					File.Delete(text3 + "\\Temp.scen");
				}
			}
			merchantRequest = ex2;
			MustRefreshMainForm = true;
			ProjectData.ClearProjectError();
		}
	}

	public static void GraphicsCrash()
	{
		if (MessageBox.Show("DirectX has experienced an error with the GPU, attempting to restart graphics engine.", "Command", MessageBoxButtons.AbortRetryIgnore) == DialogResult.Abort)
		{
			if (MessageBox.Show("Attempt to save?", "Command", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				composerRequest.LastSavedInScenEdit = CurrentGame.GameMode == Game._GameMode.ScenEdit;
				ScenContainer scenContainer = new ScenContainer(composerRequest);
				scenContainer.AttachAndCompressScenarioObject(GameGeneral.PostBridge(composerRequest));
				scenContainer.SaveToFile(GameGeneral.ScenariosRootPath + "\\LastDitchAutosave.scen");
			}
			Environment.Exit(0);
		}
	}

	public static void AdjustTransparency(ref float float_0, ref int int_0, ActiveUnit activeUnit_0)
	{
		switch (CurrentMapProfile.ViewMode)
		{
		case MapProfile.MapViewMode.UnitView:
			if (activeUnit_0.IsGroup)
			{
				float_0 = (float)GroupOpacity;
				int_0 = GroupAlpha;
			}
			else
			{
				float_0 = 1f;
				int_0 = 255;
			}
			break;
		case MapProfile.MapViewMode.GroupView:
			if (activeUnit_0.IsGroup)
			{
				float_0 = 1f;
				int_0 = 255;
			}
			else if (activeUnit_0.IsGroupMember())
			{
				float_0 = (float)GroupOpacity;
				int_0 = GroupAlpha;
			}
			else
			{
				float_0 = 1f;
				int_0 = 255;
			}
			break;
		}
		if (activeUnit_0 != null && !activeUnit_0.CommStuff.IsConnectedToSideNetwork && !CurrentMapProfile.GodsEye && !InterpreterObjectListener.CollectInterruptibleTask(activeUnit_0))
		{
			int_0 = 128;
			float_0 = 0.25f;
		}
		if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Sonobuoy && SimConfiguration.DefaultGamePreferences.SonobuoyVisibility == Game.GamePreferences.SonobuoyVisibilitySetting.Ghosted)
		{
			int_0 = 128;
			float_0 = 0.25f;
		}
	}

	public static void Script1()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("NATO", ref scenario_);
		scenario_ = composerRequest;
		AddSide("WP", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Raptor 1", 5.0, 5.0, 691, 4521, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Raptor 2", 5.0, 4.95, 691, 4521, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Flanker 1", 5.8, 5.8, 2099, 2368, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Flanker 2", 5.8, 5.7, 2099, 2368, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Flanker 3", 5.8, 5.6, 2099, 2368, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Flanker 4", 5.8, 5.5, 2099, 2368, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Mainstay 1", 5.82, 5.52, 2149, 8060, 10000f);
		foreach (ActiveUnit activeUnits_ in composerRequest.ActiveUnits_List)
		{
			if (activeUnits_.GetUnitSide() != composerRequest.Sides_ReadOnly[1])
			{
				continue;
			}
			Sensor[] sensors_Cached = activeUnits_.Sensors_Cached;
			Sensor[] array = sensors_Cached;
			foreach (Sensor sensor in array)
			{
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					sensor.GoActive();
				}
			}
		}
		CurrentSide = composerRequest.Sides_ReadOnly[0];
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void Script2()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("NATO", ref scenario_);
		scenario_ = composerRequest;
		AddSide("WP", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 1447, "Perry 1", 5.0, 5.0);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 259, "Tanker 1", 4.9, 5.1);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 42, "Tico 1", 4.85, 5.15);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 1", 8.1, 5.8, 1669, 2423, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 2", 7.6, 5.7, 1669, 2423, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 3", 8.2, 5.6, 1669, 2423, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 4", 7.5, 5.5, 1669, 2423, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 5", 8.3, 5.4, 1669, 2423, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 6", 7.4, 5.3, 1669, 2423, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 7", 8.4, 5.2, 1669, 2423, 10000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 8", 7.3, 5.1, 1669, 2423, 10000f);
		composerRequest.AddNewSubmarine(composerRequest.Sides_ReadOnly[1], 185, "Tomsk", 2.5731, 3.5107);
		CurrentSide = composerRequest.Sides_ReadOnly[0];
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void Script3()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("Australia", ref scenario_);
		scenario_ = composerRequest;
		AddSide("OPFOR", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 956, "Adelaide 1", 5.0, 5.0);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 592, "Anzac 1", 4.85, 5.15);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[1], 1832, "Luhai 1", 5.0, 4.0);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[1], 690, "Guangzhou 1", 4.85, 4.0);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 1", 8.1, 5.8, 1669, 2423, 5000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Backfire 2", 7.6, 5.7, 1669, 2423, 5000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Mirage F.1 #1", 6.1, 5.8, 1203, 7545, 1000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Mirage F.1 #2", 5.6, 5.7, 1203, 7545, 1000f);
		CurrentSide = composerRequest.Sides_ReadOnly[0];
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void Script4()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("USN", ref scenario_);
		scenario_ = composerRequest;
		AddSide("OPFOR", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		Ship ship = composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 272, "Enterprise", -76.1, 37.2);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 42, "Yorktown", -76.11, 37.19);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 521, "Truxtun", -76.2, 37.3);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 761, "King", -76.15, 37.0);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 116, "Underwood", -76.3, 37.25);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 1812, "Wichita", -76.09, 37.21);
		Aircraft aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Tomcat 1", -76.12, 37.2, 10, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Tomcat 2", -76.12, 37.2, 10, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Hornet 1", -76.12, 37.2, 47, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Hornet 2", -76.12, 37.2, 47, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Hornet 3", -76.12, 37.2, 47, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Hornet 4", -76.12, 37.2, 47, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Intruder 1", -76.12, 37.2, 221, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Intruder 2", -76.12, 37.2, 221, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "SeaHawk 1", -76.12, 37.2, 237, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Sea King 1", -76.12, 37.2, 55, 0, 1000f);
		if (ship.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
		{
			ship.AirOps.AddThisAircraft(aircraft_, bool_0: false);
		}
		CurrentSide = composerRequest.Sides_ReadOnly[0];
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void Script7()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("US", ref scenario_);
		scenario_ = composerRequest;
		AddSide("Iran", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport" + Conversions.ToString(Path.DirectorySeparatorChar) + "Iran" + Conversions.ToString(Path.DirectorySeparatorChar) + "Natanz 2008.inst", composerRequest.Sides_ReadOnly[1]);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExpor" + Conversions.ToString(Path.DirectorySeparatorChar) + "Iran" + Conversions.ToString(Path.DirectorySeparatorChar) + "Bandar Abbas.inst", composerRequest.Sides_ReadOnly[1]);
		Group byName = Misc.GetByName(composerRequest.Groups, "Bandar Abbas International/TAB 9");
		int num = 1;
		do
		{
			Aircraft aircraft_ = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Falcon 50 #" + Conversions.ToString(num), -76.12, 37.2, 639, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_, bool_0: false);
			}
			num++;
		}
		while (num <= 4);
		num = 1;
		do
		{
			Aircraft aircraft_12 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "F.27 #" + Conversions.ToString(num), -76.12, 37.2, 2091, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_12) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_12, bool_0: false);
			}
			num++;
		}
		while (num <= 4);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport" + Conversions.ToString(Path.DirectorySeparatorChar) + "Iran" + Conversions.ToString(Path.DirectorySeparatorChar) + "Bushehr.inst", composerRequest.Sides_ReadOnly[1]);
		composerRequest.Sides_ReadOnly[1].Missions_Add(new Strike(composerRequest.Sides_ReadOnly[1], composerRequest, "Mission 1", Mission.MissionCategory.Mission, Strike.StrikeType.Air_Intercept));
		byName = Misc.GetByName(composerRequest.Groups, "Bushehr Airport/TAB 6");
		Mission mission_ = composerRequest.Sides_ReadOnly[1].GetMissionsTotal(composerRequest)[0];
		num = 1;
		do
		{
			Aircraft aircraft = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Bushehr Phantom-D #" + Conversions.ToString(num), -76.12, 37.2, 229, 2173, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft, bool_0: false);
			}
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
			aircraft.Set_AssignedMissionOrPackage(mission_, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
			num++;
		}
		while (num <= 6);
		num = 1;
		do
		{
			Aircraft aircraft2 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Bushehr Phantom-E #" + Conversions.ToString(num), -76.12, 37.2, 1309, 332, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft2) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft2, bool_0: false);
			}
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_2 = Mission.MissionAssignmentAttemptResult.None;
			aircraft2.Set_AssignedMissionOrPackage(mission_, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_2);
			num++;
		}
		while (num <= 18);
		num = 1;
		do
		{
			Aircraft aircraft3 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Bushehr Tomcat #" + Conversions.ToString(num), -76.12, 37.2, 1312, 770, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft3) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft3, bool_0: false);
			}
			Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_3 = Mission.MissionAssignmentAttemptResult.None;
			aircraft3.Set_AssignedMissionOrPackage(mission_, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_3);
			num++;
		}
		while (num <= 12);
		num = 1;
		do
		{
			Aircraft aircraft_15 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Bushehr Falcon 50 #" + Conversions.ToString(num), -76.12, 37.2, 639, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_15) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_15, bool_0: false);
			}
			num++;
		}
		while (num <= 2);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Dezful.inst", composerRequest.Sides_ReadOnly[1]);
		byName = Misc.GetByName(composerRequest.Groups, "Dezful");
		num = 1;
		do
		{
			Aircraft aircraft_16 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Dezful Tiger #" + Conversions.ToString(num), -76.12, 37.2, 1310, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_16) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_16, bool_0: false);
			}
			num++;
		}
		while (num <= 36);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Esfahan.inst", composerRequest.Sides_ReadOnly[1]);
		byName = Misc.GetByName(composerRequest.Groups, "Esfahan");
		num = 1;
		do
		{
			Aircraft aircraft_17 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Esfahan Tiger #" + Conversions.ToString(num), -76.12, 37.2, 1310, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_17) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_17, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		num = 1;
		do
		{
			Aircraft aircraft_18 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Esfahan Fencer #" + Conversions.ToString(num), -76.12, 37.2, 1327, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_18) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_18, bool_0: false);
			}
			num++;
		}
		while (num <= 2);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Hamadan.inst", composerRequest.Sides_ReadOnly[1]);
		byName = Misc.GetByName(composerRequest.Groups, "Hamadan");
		num = 1;
		do
		{
			Aircraft aircraft_19 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Hamadan Phantom-D #" + Conversions.ToString(num), -76.12, 37.2, 229, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_19) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_19, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		num = 1;
		do
		{
			Aircraft aircraft_20 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Hamadan Phantom-E #" + Conversions.ToString(num), -76.12, 37.2, 1309, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_20) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_20, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Mehrabad.inst", composerRequest.Sides_ReadOnly[1]);
		byName = Misc.GetByName(composerRequest.Groups, "Mehrabad");
		num = 1;
		do
		{
			Aircraft aircraft_21 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Mehrabad Fulcrum #" + Conversions.ToString(num), -76.12, 37.2, 1346, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_21) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_21, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		num = 1;
		do
		{
			Aircraft aircraft_2 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Mehrabad Fencer #" + Conversions.ToString(num), -76.12, 37.2, 1327, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_2) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_2, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		num = 1;
		do
		{
			Aircraft aircraft_3 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Mehrabad Tanker-707 #" + Conversions.ToString(num), -76.12, 37.2, 2423, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_3) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_3, bool_0: false);
			}
			num++;
		}
		while (num <= 10);
		num = 1;
		do
		{
			Aircraft aircraft_4 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Mehrabad Tanker-747 #" + Conversions.ToString(num), -76.12, 37.2, 1660, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_4) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_4, bool_0: false);
			}
			num++;
		}
		while (num <= 5);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Omidiyeh.inst", composerRequest.Sides_ReadOnly[1]);
		byName = Misc.GetByName(composerRequest.Groups, "Omidiyeh");
		num = 1;
		do
		{
			Aircraft aircraft_5 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Omidiyeh Airguard #" + Conversions.ToString(num), -76.12, 37.2, 1354, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_5) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_5, bool_0: false);
			}
			num++;
		}
		while (num <= 36);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Shiraz.inst", composerRequest.Sides_ReadOnly[1]);
		byName = Misc.GetByName(composerRequest.Groups, "Shiraz");
		num = 1;
		do
		{
			Aircraft aircraft_6 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Shiraz Fencer #" + Conversions.ToString(num), -76.12, 37.2, 1327, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_6) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_6, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		num = 1;
		do
		{
			Aircraft aircraft_7 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Shiraz Frogfoot #" + Conversions.ToString(num), -76.12, 37.2, 133, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_7) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_7, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Tabriz.inst", composerRequest.Sides_ReadOnly[1]);
		byName = Misc.GetByName(composerRequest.Groups, "Tabriz");
		num = 1;
		do
		{
			Aircraft aircraft_8 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Tabriz Tiger #" + Conversions.ToString(num), -76.12, 37.2, 1310, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_8) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_8, bool_0: false);
			}
			num++;
		}
		while (num <= 24);
		num = 1;
		do
		{
			Aircraft aircraft_9 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Tabriz Fulcrum #" + Conversions.ToString(num), -76.12, 37.2, 1346, 0, 1000f);
			if (byName.AirOps.CanHostThisAircraft(aircraft_9) == AirOpsAttemptResult.Success)
			{
				byName.AirOps.AddThisAircraft(aircraft_9, bool_0: false);
			}
			num++;
		}
		while (num <= 12);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Iran EW.inst", composerRequest.Sides_ReadOnly[1]);
		composerRequest.ImportUnitsFromFile(GameGeneral.TopLevelWritablePath + "\\ImportExport\\Iran\\Iran AD.inst", composerRequest.Sides_ReadOnly[1]);
		Ship ship = composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 1215, "Roosevelt", 51.144952, 27.025);
		num = 1;
		do
		{
			Aircraft aircraft_10 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Super Bug #" + Conversions.ToString(num), -76.12, 37.2, 1089, 0, 1000f);
			if (ship.AirOps.CanHostThisAircraft(aircraft_10) == AirOpsAttemptResult.Success)
			{
				ship.AirOps.AddThisAircraft(aircraft_10, bool_0: false);
			}
			num++;
		}
		while (num <= 24);
		num = 1;
		do
		{
			Aircraft aircraft_11 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Classic Bug #" + Conversions.ToString(num), -76.12, 37.2, 2039, 0, 1000f);
			if (ship.AirOps.CanHostThisAircraft(aircraft_11) == AirOpsAttemptResult.Success)
			{
				ship.AirOps.AddThisAircraft(aircraft_11, bool_0: false);
			}
			num++;
		}
		while (num <= 24);
		num = 1;
		do
		{
			Aircraft aircraft_13 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Prowler #" + Conversions.ToString(num), -76.12, 37.2, 601, 0, 1000f);
			if (ship.AirOps.CanHostThisAircraft(aircraft_13) == AirOpsAttemptResult.Success)
			{
				ship.AirOps.AddThisAircraft(aircraft_13, bool_0: false);
			}
			num++;
		}
		while (num <= 4);
		num = 1;
		do
		{
			Aircraft aircraft_14 = composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Hawkeye #" + Conversions.ToString(num), -76.12, 37.2, 694, 0, 1000f);
			if (ship.AirOps.CanHostThisAircraft(aircraft_14) == AirOpsAttemptResult.Success)
			{
				ship.AirOps.AddThisAircraft(aircraft_14, bool_0: false);
			}
			num++;
		}
		while (num <= 4);
		foreach (ActiveUnit activeUnits_ in composerRequest.ActiveUnits_List)
		{
			if (activeUnits_.GetUnitSide() != composerRequest.Sides_ReadOnly[1])
			{
				continue;
			}
			Sensor[] sensors_Cached = activeUnits_.Sensors_Cached;
			Sensor[] array = sensors_Cached;
			foreach (Sensor sensor in array)
			{
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					sensor.GoActive();
				}
			}
		}
		CurrentSide = composerRequest.Sides_ReadOnly[0];
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void Script8()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("Blue", ref scenario_);
		scenario_ = composerRequest;
		AddSide("Red", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "BUFF 1", MathFunctions.LoginRequest(24.143), MathFunctions.LoginRequest(34.5059), 14, 6995, 1000f);
		composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "BUFF 2", MathFunctions.LoginRequest(24.1714), MathFunctions.LoginRequest(35.243), 14, 6995, 100f);
		composerRequest.AddNewFacility(composerRequest.Sides_ReadOnly[1], 691, "IHAWK Bty", MathFunctions.LoginRequest(24.1454), MathFunctions.LoginRequest(35.1115));
		foreach (ActiveUnit value in composerRequest.ActiveUnits.Values)
		{
			Sensor[] sensors_Cached = value.Sensors_Cached;
			Sensor[] array = sensors_Cached;
			foreach (Sensor sensor in array)
			{
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					sensor.GoActive();
				}
			}
		}
		CurrentSide = composerRequest.Sides_ReadOnly[1];
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void Script9()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("Blue", ref scenario_);
		scenario_ = composerRequest;
		AddSide("Red", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 503, "Ticonderoga", -6.572490124848907, 35.951348412451246);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 1079, "Underwood", -7.059152405025491, 36.3974394215724);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 1079, "Doyle", -6.932765660676145, 35.63246282727665);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[1], 1734, "Charles De Gaulle", -11.548334045232812, 34.5312840865825);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[1], 49, "Tourville", -8.895807599043964, 35.93845658162015);
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[1], 49, "De Grasse", -8.655607102274335, 34.57332893690153);
		foreach (ActiveUnit value in composerRequest.ActiveUnits.Values)
		{
			if (value.GetUnitSide() != composerRequest.Sides_ReadOnly[1])
			{
				continue;
			}
			Sensor[] sensors_Cached = value.Sensors_Cached;
			Sensor[] array = sensors_Cached;
			foreach (Sensor sensor in array)
			{
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					sensor.GoActive();
				}
			}
		}
		CurrentSide = composerRequest.Sides_ReadOnly[0];
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void Script5()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("RN", ref scenario_);
		scenario_ = composerRequest;
		AddSide("OPFOR", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		Facility facility = null;
		facility = composerRequest.AddNewFacility(composerRequest.Sides_ReadOnly[0], 400, "St. Mawgan - Main", MathFunctions.LoginRequest(-5.0), MathFunctions.LoginRequest(50.26));
		list.Add(facility);
		scenario_ = composerRequest;
		Group group = new Group(ref scenario_, ref composerRequest.Sides_ReadOnly[0], list);
		group.Name = "RAF St. Mawgan";
		int num = 1;
		do
		{
			group.AirOps.AddThisAircraft(composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[0], "Lightning #" + Conversions.ToString(num), 6.08, 52.401, 30, 532, 10000f), bool_0: false);
			num++;
		}
		while (num <= 6);
		list.Clear();
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 155, "Devonshire", MathFunctions.LoginRequest(-1.34), MathFunctions.LoginRequest(50.18)));
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 2, "Olwen", MathFunctions.LoginRequest(-1.34), MathFunctions.LoginRequest(50.178)));
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 10061, "Groningen", MathFunctions.LoginRequest(-1.339), MathFunctions.LoginRequest(50.182)));
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 187, "De Zeven Provincien", MathFunctions.LoginRequest(-1.341), MathFunctions.LoginRequest(50.182)));
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 10019, "Dido", MathFunctions.LoginRequest(-1.339), MathFunctions.LoginRequest(50.179)));
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 16, "Caprice", MathFunctions.LoginRequest(-1.337), MathFunctions.LoginRequest(50.177)));
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 50, "Zerstorer 3", MathFunctions.LoginRequest(-1.336), MathFunctions.LoginRequest(50.181)));
		list.Add(composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 658, "Vesole", MathFunctions.LoginRequest(-1.34), MathFunctions.LoginRequest(50.177)));
		scenario_ = composerRequest;
		new Group(ref scenario_, ref composerRequest.Sides_ReadOnly[0], list).Name = "TG 603.01";
		list.Clear();
		facility = composerRequest.AddNewFacility(composerRequest.Sides_ReadOnly[1], 400, "RED BASE #1 - Main", MathFunctions.LoginRequest(-3.08), MathFunctions.LoginRequest(52.4));
		num = 1;
		do
		{
			facility.Weaponry.AddWeaponToMagazines(358, bool_1: false, bool_2: true);
			num++;
		}
		while (num <= 32);
		list.Add(facility);
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("Load");
		dataTable.Columns.Add("Name");
		foreach (WeaponRec weapon in facility.Magazines[0].Weapons)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["Load"] = weapon.CurrentLoad;
			dataRow["Name"] = weapon.GetReferenceWeapon(facility.ParentScen).Name;
			dataTable.Rows.Add(dataRow);
		}
		scenario_ = composerRequest;
		Group group2 = new Group(ref scenario_, ref composerRequest.Sides_ReadOnly[1], list);
		group2.Name = "RED BASE #1";
		num = 1;
		do
		{
			group2.AirOps.AddThisAircraft(composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Badger #" + Conversions.ToString(num), -76.12, 37.2, 685, 528, 1000f), bool_0: false);
			num++;
		}
		while (num <= 3);
		num = 1;
		do
		{
			group2.AirOps.AddThisAircraft(composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Farmer #" + Conversions.ToString(num), -76.12, 37.2, 47, 453, 1000f), bool_0: false);
			num++;
		}
		while (num <= 4);
		num = 5;
		do
		{
			group2.AirOps.AddThisAircraft(composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Farmer #" + Conversions.ToString(num), -76.12, 37.2, 47, 455, 1000f), bool_0: false);
			num++;
		}
		while (num <= 9);
		list.Clear();
		facility = composerRequest.AddNewFacility(composerRequest.Sides_ReadOnly[1], 400, "RED BASE #2 - Main", MathFunctions.LoginRequest(-1.1), MathFunctions.LoginRequest(52.12));
		list.Add(facility);
		scenario_ = composerRequest;
		Group group3 = new Group(ref scenario_, ref composerRequest.Sides_ReadOnly[1], list);
		group3.Name = "RED BASE #2";
		num = 4;
		do
		{
			group3.AirOps.AddThisAircraft(composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Badger #" + Conversions.ToString(num), -76.12, 37.2, 685, 528, 1000f), bool_0: false);
			num++;
		}
		while (num <= 6);
		num = 1;
		do
		{
			group3.AirOps.AddThisAircraft(composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Fitter #" + Conversions.ToString(num), -76.12, 37.2, 167, 468, 1000f), bool_0: false);
			num++;
		}
		while (num <= 4);
		num = 5;
		do
		{
			group3.AirOps.AddThisAircraft(composerRequest.AddNewAircraft(composerRequest.Sides_ReadOnly[1], "Fitter #" + Conversions.ToString(num), -76.12, 37.2, 167, 464, 1000f), bool_0: false);
			num++;
		}
		while (num <= 9);
		CurrentMapProfile.ViewMode = MapProfile.MapViewMode.GroupView;
	}

	public static void Script6()
	{
		CreateNewScenario();
		Scenario scenario_ = composerRequest;
		AddSide("NATO", ref scenario_);
		scenario_ = composerRequest;
		AddSide("USSR", ref scenario_);
		composerRequest.Sides_ReadOnly[0].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[1], Misc.PostureStance.Hostile);
		composerRequest.Sides_ReadOnly[1].SetConsidersThisSideToBe(composerRequest.Sides_ReadOnly[0], Misc.PostureStance.Hostile);
		composerRequest.AddNewSubmarine(composerRequest.Sides_ReadOnly[1], 10077, "K-452", MathFunctions.LoginRequest(25.19081), MathFunctions.LoginRequest(35.831));
		composerRequest.AddNewSubmarine(composerRequest.Sides_ReadOnly[1], 10085, "K-218", MathFunctions.LoginRequest(24.1906), MathFunctions.LoginRequest(36.029));
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 10236, "King", MathFunctions.LoginRequest(24.152), MathFunctions.LoginRequest(36.033));
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 10618, "Lyness", MathFunctions.LoginRequest(24.151), MathFunctions.LoginRequest(36.031));
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 314, "Merchant #1", MathFunctions.LoginRequest(24.152), MathFunctions.LoginRequest(36.032));
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 373, "Merchant #2", MathFunctions.LoginRequest(24.153), MathFunctions.LoginRequest(36.033));
		composerRequest.AddNewShip(composerRequest.Sides_ReadOnly[0], 10273, "Belknap", MathFunctions.LoginRequest(24.154), MathFunctions.LoginRequest(36.034));
		CurrentSide = composerRequest.Sides_ReadOnly[1];
	}

	public static void smethod_3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		List<LoggedMessage> messageLog_Hybrid = m_ModelRequest.GetMessageLog_Hybrid(composerRequest);
		if (!Information.IsNothing(messageLog_Hybrid))
		{
			foreach (LoggedMessage item in messageLog_Hybrid)
			{
				stringBuilder.Append(item.Timestamp.ToString() + ": " + item.Text + "\r\n\r\n");
			}
		}
		StreamWriter streamWriter = File.CreateText(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "AALog.txt");
		streamWriter.Write(stringBuilder.ToString());
		streamWriter.Close();
		DarkMessageBox.ShowInformation("AALog已导出！", "");
	}

	internal static void IncludeConfiguration(string string_0)
	{
		if (Versioned.IsNumeric(string_0))
		{
			string_0 = DBOps.GetHashForMostRecentVersionOfThisDB(Conversions.ToInteger(string_0));
		}
		DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
		CurrentDB = DBOps.GetDBRecordByHash(string_0, ref dbfileCheckResult_);
		if (Information.IsNothing(algoClass))
		{
			DarkMessageBox.ShowError("错误：" + DBOps.PublishImporter(dbfileCheckResult_) + "\r\nAborting...", "Error");
		}
		else
		{
			composerRequest.DBUsed = string_0;
		}
	}

	private static void SearchConfiguration(object object_0, object object_1)
	{
		if (m_WorkerClass)
		{
			CurrentGame.Pause();
			m_WorkerClass = false;
			DarkMessageBox.ShowInformation("想定已经结束。现在，您将看到对你表现的评估。", "想定结束");
			ItemExporter.ConnectInterruptibleTemplate.Evaluation.Show();
		}
	}

	public static void AddFileNameToRecentList(string string_0)
	{
		if (RecentFilenames.Contains(string_0))
		{
			int index = RecentFilenames.IndexOf(string_0);
			RecentFilenames.RemoveAt(index);
			RecentFilenames.Insert(0, string_0);
		}
		else
		{
			RecentFilenames.Insert(0, string_0);
			if (RecentFilenames.Count > 10)
			{
				RecentFilenames.Remove(RecentFilenames.Last());
			}
		}
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, RecentFilenames);
	}

	public static void HandleScenarioLoaded(Scenario scenario_0, string string_0)
	{
		if (CurrentGame.Status == Game._GameStatus.Running)
		{
			CurrentGame.Pause();
		}
		AddFileNameToRecentList(string_0);
		scenario_0.CheckForUndeclaredFeatures();
		List<Scenario.ScenarioFeatureOption> list = new List<Scenario.ScenarioFeatureOption>();
		foreach (Scenario.ScenarioFeatureOption declaredFeature in scenario_0.DeclaredFeatures)
		{
			if (!Licensing.UserHasLicenseForThisFeature(declaredFeature))
			{
				list.Add(declaredFeature);
			}
		}
		if (list.Count > 0)
		{
			if (CurrentGame.GameMode != Game._GameMode.ScenEdit)
			{
				UnlicensedFeaturesWindow unlicensedFeaturesWindow = new UnlicensedFeaturesWindow();
				unlicensedFeaturesWindow.DataContext = new LicenseDialogViewModel(list);
				unlicensedFeaturesWindow.Show();
				return;
			}
			if (DarkMessageBox.ShowWarning("此想定包含未获得许可的功能，您是否要删除未获得许可的任何内容？ （这可能会使想定无法播放，如果您不确定则按否）", "Warning", DarkDialogButton.YesNo) == DialogResult.No)
			{
				UnlicensedFeaturesWindow unlicensedFeaturesWindow2 = new UnlicensedFeaturesWindow();
				unlicensedFeaturesWindow2.DataContext = new LicenseDialogViewModel(list);
				unlicensedFeaturesWindow2.Show();
				return;
			}
			ChangeConfiguration(scenario_0);
			scenario_0.CheckForUndeclaredFeatures();
			List<Scenario.ScenarioFeatureOption> list2 = new List<Scenario.ScenarioFeatureOption>();
			foreach (Scenario.ScenarioFeatureOption declaredFeature2 in scenario_0.DeclaredFeatures)
			{
				if (!Licensing.UserHasLicenseForThisFeature(declaredFeature2))
				{
					list2.Add(declaredFeature2);
				}
			}
			if (list2.Count > 0)
			{
				DarkMessageBox.ShowError("无法完全删除未经许可的功能。", "Error");
				UnlicensedFeaturesWindow unlicensedFeaturesWindow3 = new UnlicensedFeaturesWindow();
				unlicensedFeaturesWindow3.DataContext = new LicenseDialogViewModel(list);
				unlicensedFeaturesWindow3.Show();
				return;
			}
		}
		if (scenario_0.LastSavedInScenEdit)
		{
			ItemExporter.ConnectInterruptibleTemplate.ChooseSide.theSelectedScenario = scenario_0;
			ItemExporter.ConnectInterruptibleTemplate.ChooseSide.selectedScenarioFile = string_0;
			ItemExporter.ConnectInterruptibleTemplate.ChooseSide.Show();
		}
		else
		{
			SetCurrentScenario(scenario_0, bool_0: false);
			CurrentSide = composerRequest.GetCurrentSide();
			if (Information.IsNothing(m_ModelRequest))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = 4000000;
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = (int)Math.Round(m_ModelRequest.CameraAlt);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, m_ModelRequest.MapCenter);
			}
			CurrentGame.Pause();
			MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshCaption();
			if (CurrentGame.Status == Game._GameStatus.Running)
			{
				CurrentGame.Pause();
			}
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleTimeCompressionChanged();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
			StartGameMenuWindow.HideStartWindow();
		}
		if (!string.IsNullOrEmpty(authenticationClass))
		{
			DarkMessageBox.ShowError(authenticationClass, "Error");
			authenticationClass = "";
		}
		if (CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			List<string> list3 = new List<string>();
			int num = 4;
			int num2 = 1;
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				Side side_ = sides_ReadOnly[i];
				if (Information.IsNothing(side_.Missions))
				{
					continue;
				}
				foreach (Mission item in side_.GetMissionsTotal(scenario_0))
				{
					Mission mission_ = item;
					list3.AddRange(scenario_0.CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref side_, ref mission_));
				}
			}
			string text = "";
			if (list3.Count > 0)
			{
				text = "警告！由于任务编队大小限制该想定的某些飞机可能无法起飞！\r\n\r\n您可以修改任务设置（改变任务编队大小、添加更多飞机、更改飞机挂载等）以解决该问题\r\n\r\n";
				foreach (string item2 in list3)
				{
					text = text + "\r\n" + item2;
					num2++;
					if (num2 == num)
					{
						break;
					}
				}
				if (list3.Count > num)
				{
					text = text + "\r\n+" + Conversions.ToString(list3.Count - num) + " more...";
				}
				if (!string.IsNullOrEmpty(text))
				{
					DarkMessageBox.ShowError(text, "Error");
				}
			}
		}
		Side[] sides_ReadOnly2 = scenario_0.Sides_ReadOnly;
		Side[] array = sides_ReadOnly2;
		foreach (Side side in array)
		{
			List<WeaponSalvo> list4 = new List<WeaponSalvo>();
			WeaponSalvo[] weaponSalvos = side.WeaponSalvos;
			WeaponSalvo[] array2 = weaponSalvos;
			foreach (WeaponSalvo weaponSalvo in array2)
			{
				if (weaponSalvo.ShootersList.Length == 0)
				{
					list4.Add(weaponSalvo);
				}
				WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
				WeaponSalvo.Shooter[] array3 = shootersList;
				foreach (WeaponSalvo.Shooter Local_theShooter in array3)
				{
					List<ActiveUnit> units = side.Units;
					if (units == null || units.Count <= 0)
					{
						continue;
					}
					ActiveUnit activeUnit = null;
					IEnumerable<ActiveUnit> source = side.Units.Where((ActiveUnit theUn) => theUn != null && Operators.CompareString(theUn.ObjectID, Local_theShooter.ShooterObjectID, TextCompare: true) == 0);
					if (source.Count() <= 0)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						activeUnit = source.FirstOrDefault();
					}
					if (activeUnit == null)
					{
						continue;
					}
					if (activeUnit.IsAircraft)
					{
						WeaponRec[] weapons = ((Aircraft)activeUnit).Loadout.Weapons;
						WeaponRec[] array4 = weapons;
						foreach (WeaponRec weaponRec in array4)
						{
							if (weaponRec.GetReferenceWeapon(scenario_0).DBID == weaponSalvo.GetReferenceWeapon(scenario_0).DBID && weaponRec.CurrentLoad == 0)
							{
								list4.Add(weaponSalvo);
							}
						}
					}
					foreach (Mount mount in activeUnit.Mounts)
					{
						foreach (WeaponRec mountWeapon in mount.MountWeapons)
						{
							if (mountWeapon.GetReferenceWeapon(scenario_0).DBID == weaponSalvo.GetReferenceWeapon(scenario_0).DBID && mountWeapon.CurrentLoad == 0)
							{
								list4.Add(weaponSalvo);
							}
						}
					}
				}
			}
			foreach (WeaponSalvo item3 in list4)
			{
				ArrayExtensions.Remove(ref side.WeaponSalvos, item3);
			}
		}
		_PolicyClass = string_0;
		EnableConfiguration();
	}

	[SpecialName]
	private static string smethod_4()
	{
		return ("Command_1328.18_" + GameGeneral.ReleaseDate.Date.ToString("yyyy-MM-dd")).Replace(".", "_").Replace("/", "_").Replace(":", "_")
			.Replace("-", "_");
	}

	private static void EnableConfiguration()
	{
		try
		{
			if (!Directory.Exists(smethod_4()))
			{
				return;
			}
			string[] files = Directory.GetFiles(Path.Combine("Lua", smethod_4()), "*.lua");
			LuaSandBox scenario_LuaSandbox = composerRequest.Scenario_LuaSandbox;
			string[] array = files;
			string[] array2 = array;
			foreach (string path in array2)
			{
				try
				{
					string string_ = File.ReadAllText(path);
					LuaUtility.LuaInterpret(new object[1] { LuaUtility.LuaInterpret(scenario_LuaSandbox.RunScript(string_, bool_0: true)) });
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					if (!ex2.Message.Contains("unfinished string near"))
					{
						_ = "内部错误：" + ex2.Message;
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void ChangeConfiguration(object object_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		DarkMessageBox.ShowInformation(string.Format("从想定中删除了以下项目：{0} {1} {2}", "\r\n", "\r\n", stringBuilder.ToString()), "");
	}

	public static void LoadCustomLayer_Dialog()
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().InitialDirectory = GameGeneral.TopLevelWritablePath;
		if (ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string[] fileNames = ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileNames;
		string[] array = fileNames;
		foreach (string string_ in array)
		{
			try
			{
				LoadCustomLayer(string_);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				DarkMessageBox.ShowError(ex.Message, "Error");
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void LoadCustomLayer(string string_0)
	{
		new CultureInfo("en-US");
		string extension = Path.GetExtension(string_0);
		extension = ((extension.Length == 4) ? (Conversions.ToString(extension[0]) + Conversions.ToString(extension[1]) + Conversions.ToString(extension[extension.Length - 1]) + "w") : (extension + "w"));
		string text = Path.ChangeExtension(string_0, extension);
		if (!FileExistsNative.FileExistsFast(text))
		{
			return;
		}
		string text2 = File.ReadAllText(text);
		text2 = text2.Replace(",", ".");
		File.WriteAllText(text, text2);
		TextReader textReader = File.OpenText(text);
		try
		{
			Math2.OrderClass(textReader.ReadLine());
			Math2.OrderClass(textReader.ReadLine());
			Math2.OrderClass(textReader.ReadLine());
			Math2.OrderClass(textReader.ReadLine());
			Math2.OrderClass(textReader.ReadLine());
			Math2.OrderClass(textReader.ReadLine());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200369", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return;
		}
		finally
		{
			textReader.Close();
		}
		Bitmap bitmap = new Bitmap(string_0);
		_ = bitmap.Height;
		_ = bitmap.Width;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Geo();
		Main instance = Main.Instance;
		_ = CurrentMapProfile;
		instance?.LoadCustomOverlay(text, string_0, bitmap.Width, bitmap.Height);
		bitmap.Dispose();
	}

	private static void InitConfiguration(string string_0)
	{
		m_CallbackRequest.Enqueue(string_0);
		MustRefreshMainForm = true;
	}

	private static void CheckConfiguration(Side side_0)
	{
		if (side_0 != m_ModelRequest || !composerRequest.IsRunningInCampaignMode)
		{
			return;
		}
		int? campaignScenarioPassScore = Campaign.GetCampaignScenarioPassScore(composerRequest);
		if (campaignScenarioPassScore.HasValue)
		{
			int totalScore = side_0.GetTotalScore(composerRequest);
			if ((campaignScenarioPassScore.HasValue ? new bool?(totalScore >= campaignScenarioPassScore.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				composerRequest.EndScenario();
			}
		}
	}

	private static void ConcatConfiguration(object object_0, object object_1)
	{
		Task.Factory.StartNew(delegate
		{
			SteamWorkshop.UpdateSubscribedItems();
		});
	}

	private static void InterruptConfiguration(string string_0, bool bool_0)
	{
		string left = string_0.ToLower();
		if (Operators.CompareString(left, "orbat", TextCompare: true) == 0)
		{
			if (bool_0)
			{
				ItemExporter.ConnectInterruptibleTemplate.ORBAT.Show();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.ORBAT.Close();
			}
		}
		else if (Operators.CompareString(left, "missioneditor", TextCompare: true) == 0)
		{
			if (bool_0)
			{
				MissionEditorWindow.Show();
			}
			else
			{
				MissionEditorWindow.Close();
			}
		}
		else if (Operators.CompareString(left, "speedalt", TextCompare: true) == 0)
		{
			if (bool_0)
			{
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Show();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Close();
			}
		}
		else if (Operators.CompareString(left, "exclusionzoneswindow", TextCompare: true) == 0)
		{
			if (bool_0)
			{
				ItemExporter.ConnectInterruptibleTemplate.ExclusionZonesWindow.Show();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.ExclusionZonesWindow.Close();
			}
		}
		else if (Operators.CompareString(left, "nonavzoneswindow", TextCompare: true) == 0)
		{
			if (bool_0)
			{
				ItemExporter.ConnectInterruptibleTemplate.NoNavZonesWindow.Show();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.NoNavZonesWindow.Close();
			}
		}
		else if (Operators.CompareString(left, "consolewindow2", TextCompare: true) == 0)
		{
			if (bool_0)
			{
				ItemExporter.ConnectInterruptibleTemplate.ConsoleWindow2.Show();
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.ConsoleWindow2.Close();
			}
		}
	}

	public static void ConsolidateConfigFiles()
	{
		if (!Directory.Exists(GameGeneral.ConfigFolderPath))
		{
			Directory.CreateDirectory(GameGeneral.ConfigFolderPath);
		}
		string[] files = Directory.GetFiles(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath);
		string[] array = files;
		foreach (string text in array)
		{
			if (Operators.CompareString(Path.GetExtension(text).ToLower(), ".ini", TextCompare: true) == 0)
			{
				string text2 = Path.Combine(GameGeneral.ConfigFolderPath, Path.GetFileNameWithoutExtension(text)) + ".ini";
				if (FileExistsNative.FileExistsFast(text2))
				{
					File.Delete(text2);
				}
				File.Move(text, text2);
			}
		}
	}

	public static string EvaluateScoring()
	{
		string result = "";
		if (m_ModelRequest != null)
		{
			int totalScore = m_ModelRequest.GetTotalScore(composerRequest);
			int? scoring_Triumph;
			if (m_ModelRequest.Scoring_Triumph.HasValue)
			{
				int num = totalScore;
				scoring_Triumph = m_ModelRequest.Scoring_Triumph;
				if ((scoring_Triumph.HasValue ? new bool?(num >= scoring_Triumph.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					result = "Triumph";
				}
			}
			scoring_Triumph = m_ModelRequest.Scoring_Triumph;
			bool? flag = (scoring_Triumph.HasValue ? new bool?(scoring_Triumph.GetValueOrDefault() > totalScore) : null);
			if (flag.GetValueOrDefault(true) && totalScore >= m_ModelRequest.Scoring_MajorVictory && flag.HasValue)
			{
				result = "重大胜利";
			}
			if (m_ModelRequest.Scoring_MajorVictory > totalScore && totalScore >= m_ModelRequest.Scoring_MinorVictory)
			{
				result = "小胜利";
			}
			if (m_ModelRequest.Scoring_MinorVictory > totalScore && totalScore > m_ModelRequest.Scoring_MinorDefeat)
			{
				result = "Average";
			}
			if (m_ModelRequest.Scoring_MinorDefeat >= totalScore && totalScore > m_ModelRequest.Scoring_MajorDefeat)
			{
				result = "小失败";
			}
			if (m_ModelRequest.Scoring_MajorDefeat >= totalScore)
			{
				int num2 = totalScore;
				scoring_Triumph = m_ModelRequest.Scoring_Disaster;
				if ((scoring_Triumph.HasValue ? new bool?(num2 > scoring_Triumph.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					result = "重大失败";
				}
			}
			if (m_ModelRequest.Scoring_Disaster.HasValue)
			{
				int totalScore2 = m_ModelRequest.GetTotalScore(composerRequest);
				scoring_Triumph = m_ModelRequest.Scoring_Disaster;
				if ((scoring_Triumph.HasValue ? new bool?(totalScore2 <= scoring_Triumph.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					result = "Disaster";
				}
			}
		}
		return result;
	}

	public static void UI_InitiatePolygonZoneCreation()
	{
		Zone zone = new Zone(InputDialog.CallDialog("区域名称", "输入区域名称...", "新建区域"), new List<ReferencePoint>());
		m_ModelRequest.StandardZones.Add(zone);
		zone.AreaColor = Color.FromArgb(60, 100, 100, 100);
		AreaInPolygonDraw = zone;
	}
}
