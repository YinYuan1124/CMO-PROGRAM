using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command.Dictionaries;
using Command.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using OpenDis.Candidates;
using OpenDis.Common;
using OpenDis.Pages;
using OpenDis.Resolver;
using OpenDis.Services;

namespace Command.Messages;

[HideModuleName]
[StandardModule]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class ItemExporter
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	internal sealed class WatcherListenerMapping
	{
		[CompilerGenerated]
		private sealed class PublisherMapping<T> where T : Form, new()
		{
			public TargetInvocationException ex;

			internal bool PrepareInterruptiblePolicy()
			{
				ProjectData.SetProjectError(ex);
				return ex.InnerException != null;
			}
		}

		[ThreadStatic]
		private static Hashtable ruleTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AboutBox1 m_CollectionTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddComms _InstanceTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddHostingFacility _ObjectTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddMagazine m_ParameterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddMount _ExpressionTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddPatrol m_DispatcherTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddRangeSymbol _ListenerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddReferencePointAtLocation m_ConfigTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddSatellite registryTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddSensor _DefinitionTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddSide _ValTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddUnit wrapperTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AddWeaponRecord observerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AdvancedDialog m_IssuerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AirOps clientTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AirTaskingOrder m_DicTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AttackTarget _ConsumerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public AttackTarget_V2 facadeTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BenchmarkForm _ProxyTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BrowseScenarioPlatforms _ReaderTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignEditorWindow propertyTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignEnd m_ImporterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignPlayWindow repositoryTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CampaignScenarioWindow bridgeTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CargoOps invocationTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CargoOpsContainer classTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CargoOpsV2 _RequestTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ChanceOfAppearance valueTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ChooseSide tokenizerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CommandSecondaryFormBase _StubTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConfirmLandingPlanDialog writerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ConsoleWindow2 specificationTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ContactReport watcherTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CustomLayersForm _ReponseTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DamageControlWindow m_DescriptorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DarkSecondaryFormBase poolTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DebugForm taskTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DebugTool m_FilterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MockExpressionDic _TestsTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CallbackMerchantPage m_InterpreterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DockingOps m_ContainerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public DoctrineForm composerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditAC modelTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditAction m_AdvisorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditBoats _CustomerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditBriefing serializerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCargo _RefTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCargoContainer _ErrorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCargoV2 m_CodeTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCondition connectionTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditCustomEnvironmentArea _ContextTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditEvent _StatusTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditSpecialAction m_ProccesorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditTrigger _StrategyTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public EditWeather configurationTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ErrorForm _TokenTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Evaluation _IndexerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ExclusionZonesWindow _ResolverTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Export_ImportFeedback _PublisherTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ExportImportTool serverTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FixedFacilityOrientation adapterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanAircraftLoadout schemaTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditor m_UtilsTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorTargets m_PredicateTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorTargetsArea _SingletonTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorTargetsPreliminary m_RecordTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorWaypointDetails m_ExceptionTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanEditorWeaponRoute attrTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanErrors _VisitorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanTargets exporterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FlightPlanTime _PrototypeTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FloatingLicenseErrorForm _ComparatorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form1 m_ItemTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_QuickTurnaround m_SetterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Form_SetFuelAndAirborneTime m_CreatorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public FormationEditor _TemplateTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Hotkeys m_MappingTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public IconeCustomizer _MockTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InputDialog tagTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InsufficientLicenseWindow _FieldTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InterceptorProcessResolver queueTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InteractiveManual m_RegTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public InternalDBViewer _ParamTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LandingPlanner m_PageTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListActions rulesTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListConditions methodTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListEvents m_ServiceTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListSpecialActions m_SystemTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListTriggers m_CandidateTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LoadGroup _BaseTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LoadScenario policyTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Losses m_BroadcasterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LOSTool m_IdentifierTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LuaEditorOperationPlanner printerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public LuaSocketClient m_ParserTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Magazines _AlgoTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MainForm databaseTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MainSplash _InterceptorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MCMWindow messageTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MessageLogWindow_RawText productTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Migration annotationTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MinefieldForm _IteratorTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MissionActivationTime initializerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MissionEditor _RoleTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiplayerCompletedScenarioForm factoryTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultiplayerForm attributeTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ExpressionPublisher _EventTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MultipleUnitSensors m_GlobalTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NewMessageForm _WorkerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NewMission accountTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public NoNavZonesWindow stateTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OperationPlanner m_AuthenticationTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Options paramsTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ORBAT m_InfoTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MerchantSchema _HelperTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public CollectionSchema m_MapperTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Postures _ManagerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public PriorityTargetForm m_GetterTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public QuickBattle _ProducerTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ReadyAircraft m_ProcTemplate;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RealismDialog m_StructMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RecorderForm _MerchantMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ReferencePointManager callbackMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RegressionTests m_DecoratorMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RenameObject _ProcessMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RenameSide m_ThreadMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ResumeFromSave ruleMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SatelliteCustomOrbit _CollectionMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SatPredictionForm _InstanceMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SaveGroup _ObjectMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScenarioMerge m_ParameterMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScenarioTitle _ExpressionMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScenAttachmentsWindow m_DispatcherMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ScoringWindow m_ListenerMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SelectLoadout configMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SelectSAO registryMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Sides definitionMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SpecialActionsForm _ValMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SpeedAlt _WrapperMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SplitUnit _ObserverMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public StartGame issuerMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SteamPublishScenarioForm m_ClientMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public SteamUpdateScenarioForm _DicMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TankerPlanner consumerMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TimesAndDuration _FacadeMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TimeToReadyWindow m_ProxyMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TimeUnderway _ReaderMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TitleAndDescription propertyMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitComms m_ImporterMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitMessageLog repositoryMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitSelection bridgeMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitSensors m_InvocationMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UnitSerialEditor m_ClassMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public VerticalProfilerRenderer m_RequestMapping;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public WeaponsWindow m_ValueMapping;

		public AboutBox1 AboutBox1
		{
			get
			{
				m_CollectionTemplate = CountInterruptibleService(m_CollectionTemplate);
				return m_CollectionTemplate;
			}
			set
			{
				if (value != m_CollectionTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_CollectionTemplate);
				}
			}
		}

		public AddComms AddComms
		{
			get
			{
				_InstanceTemplate = CountInterruptibleService(_InstanceTemplate);
				return _InstanceTemplate;
			}
			set
			{
				if (value != _InstanceTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _InstanceTemplate);
				}
			}
		}

		public AddHostingFacility AddHostingFacility
		{
			get
			{
				_ObjectTemplate = CountInterruptibleService(_ObjectTemplate);
				return _ObjectTemplate;
			}
			set
			{
				if (value != _ObjectTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ObjectTemplate);
				}
			}
		}

		public AddMagazine AddMagazine
		{
			get
			{
				m_ParameterTemplate = CountInterruptibleService(m_ParameterTemplate);
				return m_ParameterTemplate;
			}
			set
			{
				if (value != m_ParameterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ParameterTemplate);
				}
			}
		}

		public AddMount AddMount
		{
			get
			{
				_ExpressionTemplate = CountInterruptibleService(_ExpressionTemplate);
				return _ExpressionTemplate;
			}
			set
			{
				if (value != _ExpressionTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ExpressionTemplate);
				}
			}
		}

		public AddPatrol AddPatrol
		{
			get
			{
				m_DispatcherTemplate = CountInterruptibleService(m_DispatcherTemplate);
				return m_DispatcherTemplate;
			}
			set
			{
				if (value != m_DispatcherTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_DispatcherTemplate);
				}
			}
		}

		public AddRangeSymbol AddRangeSymbol
		{
			get
			{
				_ListenerTemplate = CountInterruptibleService(_ListenerTemplate);
				return _ListenerTemplate;
			}
			set
			{
				if (value != _ListenerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ListenerTemplate);
				}
			}
		}

		public AddReferencePointAtLocation AddReferencePointAtLocation
		{
			get
			{
				m_ConfigTemplate = CountInterruptibleService(m_ConfigTemplate);
				return m_ConfigTemplate;
			}
			set
			{
				if (value != m_ConfigTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ConfigTemplate);
				}
			}
		}

		public AddSatellite AddSatellite
		{
			get
			{
				registryTemplate = CountInterruptibleService(registryTemplate);
				return registryTemplate;
			}
			set
			{
				if (value != registryTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref registryTemplate);
				}
			}
		}

		public AddSensor AddSensor
		{
			get
			{
				_DefinitionTemplate = CountInterruptibleService(_DefinitionTemplate);
				return _DefinitionTemplate;
			}
			set
			{
				if (value != _DefinitionTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _DefinitionTemplate);
				}
			}
		}

		public AddSide AddSide
		{
			get
			{
				_ValTemplate = CountInterruptibleService(_ValTemplate);
				return _ValTemplate;
			}
			set
			{
				if (value != _ValTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ValTemplate);
				}
			}
		}

		public AddUnit AddUnit
		{
			get
			{
				wrapperTemplate = CountInterruptibleService(wrapperTemplate);
				return wrapperTemplate;
			}
			set
			{
				if (value != wrapperTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref wrapperTemplate);
				}
			}
		}

		public AddWeaponRecord AddWeaponRecord
		{
			get
			{
				observerTemplate = CountInterruptibleService(observerTemplate);
				return observerTemplate;
			}
			set
			{
				if (value != observerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref observerTemplate);
				}
			}
		}

		public AdvancedDialog AdvancedDialog
		{
			get
			{
				m_IssuerTemplate = CountInterruptibleService(m_IssuerTemplate);
				return m_IssuerTemplate;
			}
			set
			{
				if (value != m_IssuerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_IssuerTemplate);
				}
			}
		}

		public AirOps AirOps
		{
			get
			{
				clientTemplate = CountInterruptibleService(clientTemplate);
				return clientTemplate;
			}
			set
			{
				if (value != clientTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref clientTemplate);
				}
			}
		}

		public AirTaskingOrder AirTaskingOrder
		{
			get
			{
				m_DicTemplate = CountInterruptibleService(m_DicTemplate);
				return m_DicTemplate;
			}
			set
			{
				if (value != m_DicTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_DicTemplate);
				}
			}
		}

		public AttackTarget AttackTarget
		{
			get
			{
				_ConsumerTemplate = CountInterruptibleService(_ConsumerTemplate);
				return _ConsumerTemplate;
			}
			set
			{
				if (value != _ConsumerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ConsumerTemplate);
				}
			}
		}

		public AttackTarget_V2 AttackTarget_V2
		{
			get
			{
				facadeTemplate = CountInterruptibleService(facadeTemplate);
				return facadeTemplate;
			}
			set
			{
				if (value != facadeTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref facadeTemplate);
				}
			}
		}

		public BenchmarkForm BenchmarkForm
		{
			get
			{
				_ProxyTemplate = CountInterruptibleService(_ProxyTemplate);
				return _ProxyTemplate;
			}
			set
			{
				if (value != _ProxyTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ProxyTemplate);
				}
			}
		}

		public BrowseScenarioPlatforms BrowseScenarioPlatforms
		{
			get
			{
				_ReaderTemplate = CountInterruptibleService(_ReaderTemplate);
				return _ReaderTemplate;
			}
			set
			{
				if (value != _ReaderTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ReaderTemplate);
				}
			}
		}

		public CampaignEditorWindow CampaignEditorWindow
		{
			get
			{
				propertyTemplate = CountInterruptibleService(propertyTemplate);
				return propertyTemplate;
			}
			set
			{
				if (value != propertyTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref propertyTemplate);
				}
			}
		}

		public CampaignEnd CampaignEnd
		{
			get
			{
				m_ImporterTemplate = CountInterruptibleService(m_ImporterTemplate);
				return m_ImporterTemplate;
			}
			set
			{
				if (value != m_ImporterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ImporterTemplate);
				}
			}
		}

		public CampaignPlayWindow CampaignPlayWindow
		{
			get
			{
				repositoryTemplate = CountInterruptibleService(repositoryTemplate);
				return repositoryTemplate;
			}
			set
			{
				if (value != repositoryTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref repositoryTemplate);
				}
			}
		}

		public CampaignScenarioWindow CampaignScenarioWindow
		{
			get
			{
				bridgeTemplate = CountInterruptibleService(bridgeTemplate);
				return bridgeTemplate;
			}
			set
			{
				if (value != bridgeTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref bridgeTemplate);
				}
			}
		}

		public CargoOps CargoOps
		{
			get
			{
				invocationTemplate = CountInterruptibleService(invocationTemplate);
				return invocationTemplate;
			}
			set
			{
				if (value != invocationTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref invocationTemplate);
				}
			}
		}

		public CargoOpsContainer CargoOpsContainer
		{
			get
			{
				classTemplate = CountInterruptibleService(classTemplate);
				return classTemplate;
			}
			set
			{
				if (value != classTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref classTemplate);
				}
			}
		}

		public CargoOpsV2 CargoOpsV2_0
		{
			get
			{
				_RequestTemplate = CountInterruptibleService(_RequestTemplate);
				return _RequestTemplate;
			}
			set
			{
				if (value != _RequestTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _RequestTemplate);
				}
			}
		}

		public ChanceOfAppearance ChanceOfAppearance
		{
			get
			{
				valueTemplate = CountInterruptibleService(valueTemplate);
				return valueTemplate;
			}
			set
			{
				if (value != valueTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref valueTemplate);
				}
			}
		}

		public ChooseSide ChooseSide
		{
			get
			{
				tokenizerTemplate = CountInterruptibleService(tokenizerTemplate);
				return tokenizerTemplate;
			}
			set
			{
				if (value != tokenizerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref tokenizerTemplate);
				}
			}
		}

		public CommandSecondaryFormBase CommandSecondaryFormBase
		{
			get
			{
				_StubTemplate = CountInterruptibleService(_StubTemplate);
				return _StubTemplate;
			}
			set
			{
				if (value != _StubTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _StubTemplate);
				}
			}
		}

		public ConfirmLandingPlanDialog ConfirmLandingPlanDialog
		{
			get
			{
				writerTemplate = CountInterruptibleService(writerTemplate);
				return writerTemplate;
			}
			set
			{
				if (value != writerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref writerTemplate);
				}
			}
		}

		public ConsoleWindow2 ConsoleWindow2
		{
			get
			{
				specificationTemplate = CountInterruptibleService(specificationTemplate);
				return specificationTemplate;
			}
			set
			{
				if (value != specificationTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref specificationTemplate);
				}
			}
		}

		public ContactReport ContactReport
		{
			get
			{
				watcherTemplate = CountInterruptibleService(watcherTemplate);
				return watcherTemplate;
			}
			set
			{
				if (value != watcherTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref watcherTemplate);
				}
			}
		}

		public CustomLayersForm CustomLayersForm
		{
			get
			{
				_ReponseTemplate = CountInterruptibleService(_ReponseTemplate);
				return _ReponseTemplate;
			}
			set
			{
				if (value != _ReponseTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ReponseTemplate);
				}
			}
		}

		public DamageControlWindow DamageControlWindow
		{
			get
			{
				m_DescriptorTemplate = CountInterruptibleService(m_DescriptorTemplate);
				return m_DescriptorTemplate;
			}
			set
			{
				if (value != m_DescriptorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_DescriptorTemplate);
				}
			}
		}

		public DarkSecondaryFormBase DarkSecondaryFormBase
		{
			get
			{
				poolTemplate = CountInterruptibleService(poolTemplate);
				return poolTemplate;
			}
			set
			{
				if (value != poolTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref poolTemplate);
				}
			}
		}

		public DebugForm DebugForm
		{
			get
			{
				taskTemplate = CountInterruptibleService(taskTemplate);
				return taskTemplate;
			}
			set
			{
				if (value != taskTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref taskTemplate);
				}
			}
		}

		public DebugTool DebugTool
		{
			get
			{
				m_FilterTemplate = CountInterruptibleService(m_FilterTemplate);
				return m_FilterTemplate;
			}
			set
			{
				if (value != m_FilterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_FilterTemplate);
				}
			}
		}

		public MockExpressionDic DISAdapterSelectionForm
		{
			get
			{
				_TestsTemplate = CountInterruptibleService(_TestsTemplate);
				return _TestsTemplate;
			}
			set
			{
				if (value != _TestsTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _TestsTemplate);
				}
			}
		}

		public CallbackMerchantPage DISForm
		{
			get
			{
				m_InterpreterTemplate = CountInterruptibleService(m_InterpreterTemplate);
				return m_InterpreterTemplate;
			}
			set
			{
				if (value != m_InterpreterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_InterpreterTemplate);
				}
			}
		}

		public DockingOps DockingOps
		{
			get
			{
				m_ContainerTemplate = CountInterruptibleService(m_ContainerTemplate);
				return m_ContainerTemplate;
			}
			set
			{
				if (value != m_ContainerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ContainerTemplate);
				}
			}
		}

		public DoctrineForm DoctrineForm
		{
			get
			{
				composerTemplate = CountInterruptibleService(composerTemplate);
				return composerTemplate;
			}
			set
			{
				if (value != composerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref composerTemplate);
				}
			}
		}

		public EditAC EditAC
		{
			get
			{
				modelTemplate = CountInterruptibleService(modelTemplate);
				return modelTemplate;
			}
			set
			{
				if (value != modelTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref modelTemplate);
				}
			}
		}

		public EditAction EditAction
		{
			get
			{
				m_AdvisorTemplate = CountInterruptibleService(m_AdvisorTemplate);
				return m_AdvisorTemplate;
			}
			set
			{
				if (value != m_AdvisorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_AdvisorTemplate);
				}
			}
		}

		public EditBoats EditBoats
		{
			get
			{
				_CustomerTemplate = CountInterruptibleService(_CustomerTemplate);
				return _CustomerTemplate;
			}
			set
			{
				if (value != _CustomerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _CustomerTemplate);
				}
			}
		}

		public EditBriefing EditBriefing
		{
			get
			{
				serializerTemplate = CountInterruptibleService(serializerTemplate);
				return serializerTemplate;
			}
			set
			{
				if (value != serializerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref serializerTemplate);
				}
			}
		}

		public EditCargo EditCargo
		{
			get
			{
				_RefTemplate = CountInterruptibleService(_RefTemplate);
				return _RefTemplate;
			}
			set
			{
				if (value != _RefTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _RefTemplate);
				}
			}
		}

		public EditCargoContainer EditCargoContainer
		{
			get
			{
				_ErrorTemplate = CountInterruptibleService(_ErrorTemplate);
				return _ErrorTemplate;
			}
			set
			{
				if (value != _ErrorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ErrorTemplate);
				}
			}
		}

		public EditCargoV2 EditCargoV2_0
		{
			get
			{
				m_CodeTemplate = CountInterruptibleService(m_CodeTemplate);
				return m_CodeTemplate;
			}
			set
			{
				if (value != m_CodeTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_CodeTemplate);
				}
			}
		}

		public EditCondition EditCondition
		{
			get
			{
				connectionTemplate = CountInterruptibleService(connectionTemplate);
				return connectionTemplate;
			}
			set
			{
				if (value != connectionTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref connectionTemplate);
				}
			}
		}

		public EditCustomEnvironmentArea EditCustomEnvironmentArea
		{
			get
			{
				_ContextTemplate = CountInterruptibleService(_ContextTemplate);
				return _ContextTemplate;
			}
			set
			{
				if (value != _ContextTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ContextTemplate);
				}
			}
		}

		public EditEvent EditEvent
		{
			get
			{
				_StatusTemplate = CountInterruptibleService(_StatusTemplate);
				return _StatusTemplate;
			}
			set
			{
				if (value != _StatusTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _StatusTemplate);
				}
			}
		}

		public EditSpecialAction EditSpecialAction
		{
			get
			{
				m_ProccesorTemplate = CountInterruptibleService(m_ProccesorTemplate);
				return m_ProccesorTemplate;
			}
			set
			{
				if (value != m_ProccesorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ProccesorTemplate);
				}
			}
		}

		public EditTrigger EditTrigger
		{
			get
			{
				_StrategyTemplate = CountInterruptibleService(_StrategyTemplate);
				return _StrategyTemplate;
			}
			set
			{
				if (value != _StrategyTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _StrategyTemplate);
				}
			}
		}

		public EditWeather EditWeather
		{
			get
			{
				configurationTemplate = CountInterruptibleService(configurationTemplate);
				return configurationTemplate;
			}
			set
			{
				if (value != configurationTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref configurationTemplate);
				}
			}
		}

		public ErrorForm ErrorForm
		{
			get
			{
				_TokenTemplate = CountInterruptibleService(_TokenTemplate);
				return _TokenTemplate;
			}
			set
			{
				if (value != _TokenTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _TokenTemplate);
				}
			}
		}

		public Evaluation Evaluation
		{
			get
			{
				_IndexerTemplate = CountInterruptibleService(_IndexerTemplate);
				return _IndexerTemplate;
			}
			set
			{
				if (value != _IndexerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _IndexerTemplate);
				}
			}
		}

		public ExclusionZonesWindow ExclusionZonesWindow
		{
			get
			{
				_ResolverTemplate = CountInterruptibleService(_ResolverTemplate);
				return _ResolverTemplate;
			}
			set
			{
				if (value != _ResolverTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ResolverTemplate);
				}
			}
		}

		public Export_ImportFeedback Export_ImportFeedback
		{
			get
			{
				_PublisherTemplate = CountInterruptibleService(_PublisherTemplate);
				return _PublisherTemplate;
			}
			set
			{
				if (value != _PublisherTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _PublisherTemplate);
				}
			}
		}

		public ExportImportTool ExportImportTool
		{
			get
			{
				serverTemplate = CountInterruptibleService(serverTemplate);
				return serverTemplate;
			}
			set
			{
				if (value != serverTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref serverTemplate);
				}
			}
		}

		public FixedFacilityOrientation FixedFacilityOrientation
		{
			get
			{
				adapterTemplate = CountInterruptibleService(adapterTemplate);
				return adapterTemplate;
			}
			set
			{
				if (value != adapterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref adapterTemplate);
				}
			}
		}

		public FlightPlanAircraftLoadout FlightPlanAircraftLoadout
		{
			get
			{
				schemaTemplate = CountInterruptibleService(schemaTemplate);
				return schemaTemplate;
			}
			set
			{
				if (value != schemaTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref schemaTemplate);
				}
			}
		}

		public FlightPlanEditor FlightPlanEditor
		{
			get
			{
				m_UtilsTemplate = CountInterruptibleService(m_UtilsTemplate);
				return m_UtilsTemplate;
			}
			set
			{
				if (value != m_UtilsTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_UtilsTemplate);
				}
			}
		}

		public FlightPlanEditorTargets FlightPlanEditorTargets
		{
			get
			{
				m_PredicateTemplate = CountInterruptibleService(m_PredicateTemplate);
				return m_PredicateTemplate;
			}
			set
			{
				if (value != m_PredicateTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_PredicateTemplate);
				}
			}
		}

		public FlightPlanEditorTargetsArea FlightPlanEditorTargetsArea
		{
			get
			{
				_SingletonTemplate = CountInterruptibleService(_SingletonTemplate);
				return _SingletonTemplate;
			}
			set
			{
				if (value != _SingletonTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _SingletonTemplate);
				}
			}
		}

		public FlightPlanEditorTargetsPreliminary FlightPlanEditorTargetsPreliminary
		{
			get
			{
				m_RecordTemplate = CountInterruptibleService(m_RecordTemplate);
				return m_RecordTemplate;
			}
			set
			{
				if (value != m_RecordTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_RecordTemplate);
				}
			}
		}

		public FlightPlanEditorWaypointDetails FlightPlanEditorWaypointDetails
		{
			get
			{
				m_ExceptionTemplate = CountInterruptibleService(m_ExceptionTemplate);
				return m_ExceptionTemplate;
			}
			set
			{
				if (value != m_ExceptionTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ExceptionTemplate);
				}
			}
		}

		public FlightPlanEditorWeaponRoute FlightPlanEditorWeaponRoute
		{
			get
			{
				attrTemplate = CountInterruptibleService(attrTemplate);
				return attrTemplate;
			}
			set
			{
				if (value != attrTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref attrTemplate);
				}
			}
		}

		public FlightPlanErrors FlightPlanErrors
		{
			get
			{
				_VisitorTemplate = CountInterruptibleService(_VisitorTemplate);
				return _VisitorTemplate;
			}
			set
			{
				if (value != _VisitorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _VisitorTemplate);
				}
			}
		}

		public FlightPlanTargets FlightPlanTargets
		{
			get
			{
				exporterTemplate = CountInterruptibleService(exporterTemplate);
				return exporterTemplate;
			}
			set
			{
				if (value != exporterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref exporterTemplate);
				}
			}
		}

		public FlightPlanTime FlightPlanTime
		{
			get
			{
				_PrototypeTemplate = CountInterruptibleService(_PrototypeTemplate);
				return _PrototypeTemplate;
			}
			set
			{
				if (value != _PrototypeTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _PrototypeTemplate);
				}
			}
		}

		public FloatingLicenseErrorForm FloatingLicenseErrorForm
		{
			get
			{
				_ComparatorTemplate = CountInterruptibleService(_ComparatorTemplate);
				return _ComparatorTemplate;
			}
			set
			{
				if (value != _ComparatorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ComparatorTemplate);
				}
			}
		}

		public Form1 Form1
		{
			get
			{
				m_ItemTemplate = CountInterruptibleService(m_ItemTemplate);
				return m_ItemTemplate;
			}
			set
			{
				if (value != m_ItemTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ItemTemplate);
				}
			}
		}

		public Form_QuickTurnaround Form_QuickTurnaround
		{
			get
			{
				m_SetterTemplate = CountInterruptibleService(m_SetterTemplate);
				return m_SetterTemplate;
			}
			set
			{
				if (value != m_SetterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_SetterTemplate);
				}
			}
		}

		public Form_SetFuelAndAirborneTime Form_SetFuelAndAirborneTime
		{
			get
			{
				m_CreatorTemplate = CountInterruptibleService(m_CreatorTemplate);
				return m_CreatorTemplate;
			}
			set
			{
				if (value != m_CreatorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_CreatorTemplate);
				}
			}
		}

		public FormationEditor FormationEditor
		{
			get
			{
				_TemplateTemplate = CountInterruptibleService(_TemplateTemplate);
				return _TemplateTemplate;
			}
			set
			{
				if (value != _TemplateTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _TemplateTemplate);
				}
			}
		}

		public Hotkeys Hotkeys
		{
			get
			{
				m_MappingTemplate = CountInterruptibleService(m_MappingTemplate);
				return m_MappingTemplate;
			}
			set
			{
				if (value != m_MappingTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_MappingTemplate);
				}
			}
		}

		public IconeCustomizer IconeCustomizer
		{
			get
			{
				_MockTemplate = CountInterruptibleService(_MockTemplate);
				return _MockTemplate;
			}
			set
			{
				if (value != _MockTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _MockTemplate);
				}
			}
		}

		public InputDialog InputDialog
		{
			get
			{
				tagTemplate = CountInterruptibleService(tagTemplate);
				return tagTemplate;
			}
			set
			{
				if (value != tagTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref tagTemplate);
				}
			}
		}

		public InsufficientLicenseWindow InsufficientLicenseWindow
		{
			get
			{
				_FieldTemplate = CountInterruptibleService(_FieldTemplate);
				return _FieldTemplate;
			}
			set
			{
				if (value != _FieldTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _FieldTemplate);
				}
			}
		}

		public InterceptorProcessResolver InteractiveAnalysisForm
		{
			get
			{
				queueTemplate = CountInterruptibleService(queueTemplate);
				return queueTemplate;
			}
			set
			{
				if (value != queueTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref queueTemplate);
				}
			}
		}

		public InteractiveManual InteractiveManual
		{
			get
			{
				m_RegTemplate = CountInterruptibleService(m_RegTemplate);
				return m_RegTemplate;
			}
			set
			{
				if (value != m_RegTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_RegTemplate);
				}
			}
		}

		public InternalDBViewer InternalDBViewer
		{
			get
			{
				_ParamTemplate = CountInterruptibleService(_ParamTemplate);
				return _ParamTemplate;
			}
			set
			{
				if (value != _ParamTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ParamTemplate);
				}
			}
		}

		public LandingPlanner LandingPlanner
		{
			get
			{
				m_PageTemplate = CountInterruptibleService(m_PageTemplate);
				return m_PageTemplate;
			}
			set
			{
				if (value != m_PageTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_PageTemplate);
				}
			}
		}

		public ListActions ListActions
		{
			get
			{
				rulesTemplate = CountInterruptibleService(rulesTemplate);
				return rulesTemplate;
			}
			set
			{
				if (value != rulesTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref rulesTemplate);
				}
			}
		}

		public ListConditions ListConditions
		{
			get
			{
				methodTemplate = CountInterruptibleService(methodTemplate);
				return methodTemplate;
			}
			set
			{
				if (value != methodTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref methodTemplate);
				}
			}
		}

		public ListEvents ListEvents
		{
			get
			{
				m_ServiceTemplate = CountInterruptibleService(m_ServiceTemplate);
				return m_ServiceTemplate;
			}
			set
			{
				if (value != m_ServiceTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ServiceTemplate);
				}
			}
		}

		public ListSpecialActions ListSpecialActions
		{
			get
			{
				m_SystemTemplate = CountInterruptibleService(m_SystemTemplate);
				return m_SystemTemplate;
			}
			set
			{
				if (value != m_SystemTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_SystemTemplate);
				}
			}
		}

		public ListTriggers ListTriggers
		{
			get
			{
				m_CandidateTemplate = CountInterruptibleService(m_CandidateTemplate);
				return m_CandidateTemplate;
			}
			set
			{
				if (value != m_CandidateTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_CandidateTemplate);
				}
			}
		}

		public LoadGroup LoadGroup
		{
			get
			{
				_BaseTemplate = CountInterruptibleService(_BaseTemplate);
				return _BaseTemplate;
			}
			set
			{
				if (value != _BaseTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _BaseTemplate);
				}
			}
		}

		public LoadScenario LoadScenario
		{
			get
			{
				policyTemplate = CountInterruptibleService(policyTemplate);
				return policyTemplate;
			}
			set
			{
				if (value != policyTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref policyTemplate);
				}
			}
		}

		public Losses Losses
		{
			get
			{
				m_BroadcasterTemplate = CountInterruptibleService(m_BroadcasterTemplate);
				return m_BroadcasterTemplate;
			}
			set
			{
				if (value != m_BroadcasterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_BroadcasterTemplate);
				}
			}
		}

		public LOSTool LOSTool
		{
			get
			{
				m_IdentifierTemplate = CountInterruptibleService(m_IdentifierTemplate);
				return m_IdentifierTemplate;
			}
			set
			{
				if (value != m_IdentifierTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_IdentifierTemplate);
				}
			}
		}

		public LuaEditorOperationPlanner LuaEditorOperationPlanner
		{
			get
			{
				printerTemplate = CountInterruptibleService(printerTemplate);
				return printerTemplate;
			}
			set
			{
				if (value != printerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref printerTemplate);
				}
			}
		}

		public LuaSocketClient LuaSocketClient
		{
			get
			{
				m_ParserTemplate = CountInterruptibleService(m_ParserTemplate);
				return m_ParserTemplate;
			}
			set
			{
				if (value != m_ParserTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ParserTemplate);
				}
			}
		}

		public Magazines Magazines
		{
			get
			{
				_AlgoTemplate = CountInterruptibleService(_AlgoTemplate);
				return _AlgoTemplate;
			}
			set
			{
				if (value != _AlgoTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _AlgoTemplate);
				}
			}
		}

		public MainForm MainForm
		{
			get
			{
				databaseTemplate = CountInterruptibleService(databaseTemplate);
				return databaseTemplate;
			}
			set
			{
				if (value != databaseTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref databaseTemplate);
				}
			}
		}

		public MainSplash MainSplash
		{
			get
			{
				_InterceptorTemplate = CountInterruptibleService(_InterceptorTemplate);
				return _InterceptorTemplate;
			}
			set
			{
				if (value != _InterceptorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _InterceptorTemplate);
				}
			}
		}

		public MCMWindow MCMWindow_0
		{
			get
			{
				messageTemplate = CountInterruptibleService(messageTemplate);
				return messageTemplate;
			}
			set
			{
				if (value != messageTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref messageTemplate);
				}
			}
		}

		public Migration Migration
		{
			get
			{
				annotationTemplate = CountInterruptibleService(annotationTemplate);
				return annotationTemplate;
			}
			set
			{
				if (value != annotationTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref annotationTemplate);
				}
			}
		}

		public MinefieldForm MinefieldForm
		{
			get
			{
				_IteratorTemplate = CountInterruptibleService(_IteratorTemplate);
				return _IteratorTemplate;
			}
			set
			{
				if (value != _IteratorTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _IteratorTemplate);
				}
			}
		}

		public MissionActivationTime MissionActivationTime
		{
			get
			{
				initializerTemplate = CountInterruptibleService(initializerTemplate);
				return initializerTemplate;
			}
			set
			{
				if (value != initializerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref initializerTemplate);
				}
			}
		}

		public MissionEditor MissionEditor
		{
			get
			{
				_RoleTemplate = CountInterruptibleService(_RoleTemplate);
				return _RoleTemplate;
			}
			set
			{
				if (value != _RoleTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _RoleTemplate);
				}
			}
		}

		public MultiplayerCompletedScenarioForm MultiplayerCompletedScenarioForm
		{
			get
			{
				factoryTemplate = CountInterruptibleService(factoryTemplate);
				return factoryTemplate;
			}
			set
			{
				if (value != factoryTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref factoryTemplate);
				}
			}
		}

		public MultiplayerForm MultiplayerForm
		{
			get
			{
				attributeTemplate = CountInterruptibleService(attributeTemplate);
				return attributeTemplate;
			}
			set
			{
				if (value != attributeTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref attributeTemplate);
				}
			}
		}

		public ExpressionPublisher MultiplayerTimings
		{
			get
			{
				_EventTemplate = CountInterruptibleService(_EventTemplate);
				return _EventTemplate;
			}
			set
			{
				if (value != _EventTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _EventTemplate);
				}
			}
		}

		public MultipleUnitSensors MultipleUnitSensors
		{
			get
			{
				m_GlobalTemplate = CountInterruptibleService(m_GlobalTemplate);
				return m_GlobalTemplate;
			}
			set
			{
				if (value != m_GlobalTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_GlobalTemplate);
				}
			}
		}

		public NewMessageForm NewMessageForm
		{
			get
			{
				_WorkerTemplate = CountInterruptibleService(_WorkerTemplate);
				return _WorkerTemplate;
			}
			set
			{
				if (value != _WorkerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _WorkerTemplate);
				}
			}
		}

		public NewMission NewMission
		{
			get
			{
				accountTemplate = CountInterruptibleService(accountTemplate);
				return accountTemplate;
			}
			set
			{
				if (value != accountTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref accountTemplate);
				}
			}
		}

		public NoNavZonesWindow NoNavZonesWindow
		{
			get
			{
				stateTemplate = CountInterruptibleService(stateTemplate);
				return stateTemplate;
			}
			set
			{
				if (value != stateTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref stateTemplate);
				}
			}
		}

		public OperationPlanner OperationPlanner
		{
			get
			{
				m_AuthenticationTemplate = CountInterruptibleService(m_AuthenticationTemplate);
				return m_AuthenticationTemplate;
			}
			set
			{
				if (value != m_AuthenticationTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_AuthenticationTemplate);
				}
			}
		}

		public Options Options
		{
			get
			{
				paramsTemplate = CountInterruptibleService(paramsTemplate);
				return paramsTemplate;
			}
			set
			{
				if (value != paramsTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref paramsTemplate);
				}
			}
		}

		public ORBAT ORBAT
		{
			get
			{
				m_InfoTemplate = CountInterruptibleService(m_InfoTemplate);
				return m_InfoTemplate;
			}
			set
			{
				if (value != m_InfoTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_InfoTemplate);
				}
			}
		}

		public MerchantSchema PE_LicenseRevoke
		{
			get
			{
				_HelperTemplate = CountInterruptibleService(_HelperTemplate);
				return _HelperTemplate;
			}
			set
			{
				if (value != _HelperTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _HelperTemplate);
				}
			}
		}

		public CollectionSchema PE_LicensingForm
		{
			get
			{
				m_MapperTemplate = CountInterruptibleService(m_MapperTemplate);
				return m_MapperTemplate;
			}
			set
			{
				if (value != m_MapperTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_MapperTemplate);
				}
			}
		}

		public Postures Postures
		{
			get
			{
				_ManagerTemplate = CountInterruptibleService(_ManagerTemplate);
				return _ManagerTemplate;
			}
			set
			{
				if (value != _ManagerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ManagerTemplate);
				}
			}
		}

		public PriorityTargetForm PriorityTargetForm
		{
			get
			{
				m_GetterTemplate = CountInterruptibleService(m_GetterTemplate);
				return m_GetterTemplate;
			}
			set
			{
				if (value != m_GetterTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_GetterTemplate);
				}
			}
		}

		public QuickBattle QuickBattle
		{
			get
			{
				_ProducerTemplate = CountInterruptibleService(_ProducerTemplate);
				return _ProducerTemplate;
			}
			set
			{
				if (value != _ProducerTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ProducerTemplate);
				}
			}
		}

		public ReadyAircraft ReadyAircraft
		{
			get
			{
				m_ProcTemplate = CountInterruptibleService(m_ProcTemplate);
				return m_ProcTemplate;
			}
			set
			{
				if (value != m_ProcTemplate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ProcTemplate);
				}
			}
		}

		public RealismDialog RealismDialog
		{
			get
			{
				m_StructMapping = CountInterruptibleService(m_StructMapping);
				return m_StructMapping;
			}
			set
			{
				if (value != m_StructMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_StructMapping);
				}
			}
		}

		public RecorderForm RecorderForm
		{
			get
			{
				_MerchantMapping = CountInterruptibleService(_MerchantMapping);
				return _MerchantMapping;
			}
			set
			{
				if (value != _MerchantMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _MerchantMapping);
				}
			}
		}

		public ReferencePointManager ReferencePointManager
		{
			get
			{
				callbackMapping = CountInterruptibleService(callbackMapping);
				return callbackMapping;
			}
			set
			{
				if (value != callbackMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref callbackMapping);
				}
			}
		}

		public RegressionTests RegressionTests
		{
			get
			{
				m_DecoratorMapping = CountInterruptibleService(m_DecoratorMapping);
				return m_DecoratorMapping;
			}
			set
			{
				if (value != m_DecoratorMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_DecoratorMapping);
				}
			}
		}

		public RenameObject RenameObject
		{
			get
			{
				_ProcessMapping = CountInterruptibleService(_ProcessMapping);
				return _ProcessMapping;
			}
			set
			{
				if (value != _ProcessMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ProcessMapping);
				}
			}
		}

		public RenameSide RenameSide
		{
			get
			{
				m_ThreadMapping = CountInterruptibleService(m_ThreadMapping);
				return m_ThreadMapping;
			}
			set
			{
				if (value != m_ThreadMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ThreadMapping);
				}
			}
		}

		public ResumeFromSave ResumeFromSave
		{
			get
			{
				ruleMapping = CountInterruptibleService(ruleMapping);
				return ruleMapping;
			}
			set
			{
				if (value != ruleMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref ruleMapping);
				}
			}
		}

		public SatelliteCustomOrbit SatelliteCustomOrbit
		{
			get
			{
				_CollectionMapping = CountInterruptibleService(_CollectionMapping);
				return _CollectionMapping;
			}
			set
			{
				if (value != _CollectionMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _CollectionMapping);
				}
			}
		}

		public SatPredictionForm SatPredictionForm
		{
			get
			{
				_InstanceMapping = CountInterruptibleService(_InstanceMapping);
				return _InstanceMapping;
			}
			set
			{
				if (value != _InstanceMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _InstanceMapping);
				}
			}
		}

		public SaveGroup SaveGroup
		{
			get
			{
				_ObjectMapping = CountInterruptibleService(_ObjectMapping);
				return _ObjectMapping;
			}
			set
			{
				if (value != _ObjectMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ObjectMapping);
				}
			}
		}

		public ScenarioMerge ScenarioMerge
		{
			get
			{
				m_ParameterMapping = CountInterruptibleService(m_ParameterMapping);
				return m_ParameterMapping;
			}
			set
			{
				if (value != m_ParameterMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ParameterMapping);
				}
			}
		}

		public ScenarioTitle ScenarioTitle
		{
			get
			{
				_ExpressionMapping = CountInterruptibleService(_ExpressionMapping);
				return _ExpressionMapping;
			}
			set
			{
				if (value != _ExpressionMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ExpressionMapping);
				}
			}
		}

		public ScenAttachmentsWindow ScenAttachmentsWindow
		{
			get
			{
				m_DispatcherMapping = CountInterruptibleService(m_DispatcherMapping);
				return m_DispatcherMapping;
			}
			set
			{
				if (value != m_DispatcherMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_DispatcherMapping);
				}
			}
		}

		public ScoringWindow ScoringWindow
		{
			get
			{
				m_ListenerMapping = CountInterruptibleService(m_ListenerMapping);
				return m_ListenerMapping;
			}
			set
			{
				if (value != m_ListenerMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ListenerMapping);
				}
			}
		}

		public SelectLoadout SelectLoadout
		{
			get
			{
				configMapping = CountInterruptibleService(configMapping);
				return configMapping;
			}
			set
			{
				if (value != configMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref configMapping);
				}
			}
		}

		public Sides Sides
		{
			get
			{
				definitionMapping = CountInterruptibleService(definitionMapping);
				return definitionMapping;
			}
			set
			{
				if (value != definitionMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref definitionMapping);
				}
			}
		}

		public SpecialActionsForm SpecialActionsForm
		{
			get
			{
				_ValMapping = CountInterruptibleService(_ValMapping);
				return _ValMapping;
			}
			set
			{
				if (value != _ValMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ValMapping);
				}
			}
		}

		public SpeedAlt SpeedAlt
		{
			get
			{
				_WrapperMapping = CountInterruptibleService(_WrapperMapping);
				return _WrapperMapping;
			}
			set
			{
				if (value != _WrapperMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _WrapperMapping);
				}
			}
		}

		public SplitUnit SplitUnit
		{
			get
			{
				_ObserverMapping = CountInterruptibleService(_ObserverMapping);
				return _ObserverMapping;
			}
			set
			{
				if (value != _ObserverMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ObserverMapping);
				}
			}
		}

		public StartGame StartGame
		{
			get
			{
				issuerMapping = CountInterruptibleService(issuerMapping);
				return issuerMapping;
			}
			set
			{
				if (value != issuerMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref issuerMapping);
				}
			}
		}

		public SteamPublishScenarioForm SteamPublishScenarioForm
		{
			get
			{
				m_ClientMapping = CountInterruptibleService(m_ClientMapping);
				return m_ClientMapping;
			}
			set
			{
				if (value != m_ClientMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ClientMapping);
				}
			}
		}

		public SteamUpdateScenarioForm SteamUpdateScenarioForm
		{
			get
			{
				_DicMapping = CountInterruptibleService(_DicMapping);
				return _DicMapping;
			}
			set
			{
				if (value != _DicMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _DicMapping);
				}
			}
		}

		public TankerPlanner TankerPlanner
		{
			get
			{
				consumerMapping = CountInterruptibleService(consumerMapping);
				return consumerMapping;
			}
			set
			{
				if (value != consumerMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref consumerMapping);
				}
			}
		}

		public TimesAndDuration TimesAndDuration
		{
			get
			{
				_FacadeMapping = CountInterruptibleService(_FacadeMapping);
				return _FacadeMapping;
			}
			set
			{
				if (value != _FacadeMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _FacadeMapping);
				}
			}
		}

		public TimeToReadyWindow TimeToReadyWindow
		{
			get
			{
				m_ProxyMapping = CountInterruptibleService(m_ProxyMapping);
				return m_ProxyMapping;
			}
			set
			{
				if (value != m_ProxyMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ProxyMapping);
				}
			}
		}

		public TimeUnderway TimeUnderway
		{
			get
			{
				_ReaderMapping = CountInterruptibleService(_ReaderMapping);
				return _ReaderMapping;
			}
			set
			{
				if (value != _ReaderMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref _ReaderMapping);
				}
			}
		}

		public TitleAndDescription TitleAndDescription
		{
			get
			{
				propertyMapping = CountInterruptibleService(propertyMapping);
				return propertyMapping;
			}
			set
			{
				if (value != propertyMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref propertyMapping);
				}
			}
		}

		public UnitComms UnitComms
		{
			get
			{
				m_ImporterMapping = CountInterruptibleService(m_ImporterMapping);
				return m_ImporterMapping;
			}
			set
			{
				if (value != m_ImporterMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ImporterMapping);
				}
			}
		}

		public UnitMessageLog UnitMessageLog
		{
			get
			{
				repositoryMapping = CountInterruptibleService(repositoryMapping);
				return repositoryMapping;
			}
			set
			{
				if (value != repositoryMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref repositoryMapping);
				}
			}
		}

		public UnitSelection UnitSelection
		{
			get
			{
				bridgeMapping = CountInterruptibleService(bridgeMapping);
				return bridgeMapping;
			}
			set
			{
				if (value != bridgeMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref bridgeMapping);
				}
			}
		}

		public UnitSensors UnitSensors
		{
			get
			{
				m_InvocationMapping = CountInterruptibleService(m_InvocationMapping);
				return m_InvocationMapping;
			}
			set
			{
				if (value != m_InvocationMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_InvocationMapping);
				}
			}
		}

		public UnitSerialEditor UnitSerialEditor
		{
			get
			{
				m_ClassMapping = CountInterruptibleService(m_ClassMapping);
				return m_ClassMapping;
			}
			set
			{
				if (value != m_ClassMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ClassMapping);
				}
			}
		}

		public WeaponsWindow WeaponsWindow
		{
			get
			{
				m_ValueMapping = CountInterruptibleService(m_ValueMapping);
				return m_ValueMapping;
			}
			set
			{
				if (value != m_ValueMapping)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					CustomizeInterruptibleService(ref m_ValueMapping);
				}
			}
		}

		[SpecialName]
		public MessageLogWindow_RawText VerifyInterruptibleCandidate()
		{
			productTemplate = CountInterruptibleService(productTemplate);
			return productTemplate;
		}

		[SpecialName]
		public void ListInterruptibleCandidate(MessageLogWindow_RawText messageLogWindow_RawText_0)
		{
			if (messageLogWindow_RawText_0 != productTemplate)
			{
				if (messageLogWindow_RawText_0 != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				CustomizeInterruptibleService(ref productTemplate);
			}
		}

		[SpecialName]
		public SelectSAO StopInterruptibleBase()
		{
			registryMapping = CountInterruptibleService(registryMapping);
			return registryMapping;
		}

		[SpecialName]
		public void CancelInterruptibleBase(SelectSAO selectSAO_0)
		{
			if (selectSAO_0 != registryMapping)
			{
				if (selectSAO_0 != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				CustomizeInterruptibleService(ref registryMapping);
			}
		}

		[SpecialName]
		public VerticalProfilerRenderer CallInterruptiblePolicy()
		{
			m_RequestMapping = CountInterruptibleService(m_RequestMapping);
			return m_RequestMapping;
		}

		[SpecialName]
		public void LogoutInterruptiblePolicy(VerticalProfilerRenderer verticalProfilerRenderer_0)
		{
			if (verticalProfilerRenderer_0 != m_RequestMapping)
			{
				if (verticalProfilerRenderer_0 != null)
				{
					throw new ArgumentException("Property can only be set to Nothing");
				}
				CustomizeInterruptibleService(ref m_RequestMapping);
			}
		}

		[DebuggerHidden]
		private static T CountInterruptibleService<T>(T gparam_0) where T : Form, new()
		{
			if (gparam_0 != null && !gparam_0.IsDisposed)
			{
				return gparam_0;
			}
			if (ruleTemplate == null)
			{
				ruleTemplate = new Hashtable();
			}
			else if (ruleTemplate.ContainsKey(typeof(T)))
			{
				throw new InvalidOperationException(Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_RecursiveFormCreate"));
			}
			ruleTemplate.Add(typeof(T), null);
			TargetInvocationException ex = null;
			try
			{
				return new T();
			}
			catch (TargetInvocationException ex3) when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				TargetInvocationException ex2 = ex3;
				return ((Func<bool>)delegate
				{
					ex = ex2;
					return ((Func<bool>)delegate
					{
						ProjectData.SetProjectError(ex);
						return ex.InnerException != null;
					})();
				})();
			}).Invoke())
			{
				throw new InvalidOperationException(Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_SeeInnerException", ex.InnerException.Message), ex.InnerException);
			}
			finally
			{
				ruleTemplate.Remove(typeof(T));
			}
		}

		[DebuggerHidden]
		private void CustomizeInterruptibleService<T>(ref T gparam_0) where T : Form
		{
			gparam_0.Dispose();
			gparam_0 = null;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public WatcherListenerMapping()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(obj));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type CloneInterruptibleService()
		{
			return typeof(WatcherListenerMapping);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}

	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal sealed class MethodCallbackCandidate
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object obj)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(obj));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Type GetInterruptiblePolicy()
		{
			return typeof(MethodCallbackCandidate);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T WriteInterruptiblePolicy<T>(T gparam_0) where T : new()
		{
			if (gparam_0 == null)
			{
				return new T();
			}
			return gparam_0;
		}

		[DebuggerHidden]
		private void NewInterruptiblePolicy<T>(ref T gparam_0)
		{
			gparam_0 = default(T);
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MethodCallbackCandidate()
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class CustomerRuleWatcher<T> where T : new()
	{
		internal static object m_StubMapping;

		private static T _TokenizerMapping;

		[SpecialName]
		[DebuggerHidden]
		internal T PushInterruptiblePolicy()
		{
			if (_TokenizerMapping == null)
			{
				_TokenizerMapping = new T();
			}
			return _TokenizerMapping;
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public CustomerRuleWatcher()
		{
		}
	}

	private static readonly CustomerRuleWatcher<ComparatorExporter> setterExporter;

	private static readonly CustomerRuleWatcher<AdapterCallbackCandidate> _CreatorExporter;

	private static readonly CustomerRuleWatcher<User> _TemplateExporter;

	private static CustomerRuleWatcher<WatcherListenerMapping> m_MappingExporter;

	private static readonly CustomerRuleWatcher<MethodCallbackCandidate> _MockExporter;

	[HelpKeyword("My.Computer")]
	internal static ComparatorExporter RegisterInterruptibleMap
	{
		[DebuggerHidden]
		get
		{
			return setterExporter.PushInterruptiblePolicy();
		}
	}

	[HelpKeyword("My.Application")]
	internal static AdapterCallbackCandidate RevertInterruptibleMap
	{
		[DebuggerHidden]
		get
		{
			return _CreatorExporter.PushInterruptiblePolicy();
		}
	}

	[HelpKeyword("My.User")]
	internal static User CustomizeInterruptibleTemplate
	{
		[DebuggerHidden]
		get
		{
			return _TemplateExporter.PushInterruptiblePolicy();
		}
	}

	[HelpKeyword("My.Forms")]
	internal static WatcherListenerMapping ConnectInterruptibleTemplate
	{
		[DebuggerHidden]
		get
		{
			return m_MappingExporter.PushInterruptiblePolicy();
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static MethodCallbackCandidate DeleteInterruptibleTemplate
	{
		[DebuggerHidden]
		get
		{
			return _MockExporter.PushInterruptiblePolicy();
		}
	}

	static ItemExporter()
	{
		setterExporter = new CustomerRuleWatcher<ComparatorExporter>();
		_CreatorExporter = new CustomerRuleWatcher<AdapterCallbackCandidate>();
		_TemplateExporter = new CustomerRuleWatcher<User>();
		m_MappingExporter = new CustomerRuleWatcher<WatcherListenerMapping>();
		_MockExporter = new CustomerRuleWatcher<MethodCallbackCandidate>();
	}
}
