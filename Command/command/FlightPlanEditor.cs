using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditor : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class StatusDecoratorEntry
	{
		public Mission.Flight Local_theFlight;

		internal bool TestInterruptiblePage(ActiveUnit theAU)
		{
			if (theAU.Navigator.HasFlight && theAU.IsAircraft && !theAU.IsOperating())
			{
				return theAU.Navigator.GetFlight() == Local_theFlight;
			}
			return false;
		}

		internal bool StopInterruptiblePage(ActiveUnit theAU)
		{
			if (theAU.Navigator.HasFlight && theAU.IsAircraft && theAU.IsOperating())
			{
				return theAU.Navigator.GetFlight() == Local_theFlight;
			}
			return false;
		}
	}

	private IContainer prototypePool;

	[AccessedThroughProperty("TabControl_Aircraft")]
	[CompilerGenerated]
	private DarkUITabControl m_ComparatorPool;

	[AccessedThroughProperty("Combo_CurrentPackage")]
	[CompilerGenerated]
	private DarkUIComboBox itemPool;

	[AccessedThroughProperty("Combo_CurrentFlightPlan")]
	[CompilerGenerated]
	private DarkUIComboBox _SetterPool;

	[AccessedThroughProperty("Combo_FlightTask")]
	[CompilerGenerated]
	private DarkUIComboBox m_CreatorPool;

	[AccessedThroughProperty("TextBox_FlightCallsign")]
	[CompilerGenerated]
	private DarkUITextBox _TemplatePool;

	[AccessedThroughProperty("Combo_FlightplanType")]
	[CompilerGenerated]
	private DarkUIComboBox m_MappingPool;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_MockPool;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel tagPool;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel fieldPool;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_QueuePool;

	[AccessedThroughProperty("Button_CopyFlightplan")]
	[CompilerGenerated]
	private DarkButton _RegPool;

	[AccessedThroughProperty("Label_LaunchDateAndTime")]
	[CompilerGenerated]
	private DarkLabel m_ParamPool;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel m_RulesPool;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	private DarkLabel m_MethodPool;

	[AccessedThroughProperty("Button_FillEmptySlots")]
	[CompilerGenerated]
	private DarkButton m_ServicePool;

	[AccessedThroughProperty("Button_ClearSlots")]
	[CompilerGenerated]
	private DarkButton systemPool;

	[AccessedThroughProperty("Label_AircraftType")]
	[CompilerGenerated]
	private DarkLabel candidatePool;

	[AccessedThroughProperty("Button_ChangeAircraftType")]
	[CompilerGenerated]
	private DarkButton m_PolicyPool;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel broadcasterPool;

	[AccessedThroughProperty("Label_ObjectiveDateAndTime")]
	[CompilerGenerated]
	private DarkLabel m_IdentifierPool;

	[AccessedThroughProperty("Label_FlightStatus")]
	[CompilerGenerated]
	private DarkLabel m_ParserPool;

	[AccessedThroughProperty("Button_CreateFlightplanSkeleton")]
	[CompilerGenerated]
	private DarkButton _AlgoPool;

	[AccessedThroughProperty("Button_DeleteFlightplan")]
	[CompilerGenerated]
	private DarkButton _DatabasePool;

	[AccessedThroughProperty("GroupBox_SelectedFlight")]
	[CompilerGenerated]
	private DarkGroupBox m_InterceptorPool;

	[AccessedThroughProperty("Label9")]
	[CompilerGenerated]
	private DarkLabel messagePool;

	[AccessedThroughProperty("Label11")]
	[CompilerGenerated]
	private DarkLabel m_ProductPool;

	[AccessedThroughProperty("Label1_LandingLocation")]
	[CompilerGenerated]
	private DarkLabel m_AnnotationPool;

	[AccessedThroughProperty("Label13")]
	[CompilerGenerated]
	private DarkLabel iteratorPool;

	[AccessedThroughProperty("Label_TakeOffLocation")]
	[CompilerGenerated]
	private DarkLabel m_InitializerPool;

	[AccessedThroughProperty("Label_DiversionAirfield")]
	[CompilerGenerated]
	private DarkLabel factoryPool;

	[AccessedThroughProperty("Button_ChangeTakeOffTime")]
	[CompilerGenerated]
	private DarkButton m_AttributePool;

	[AccessedThroughProperty("Button_ChangeObjectiveTime")]
	[CompilerGenerated]
	private DarkButton eventPool;

	[AccessedThroughProperty("Button_ChangeTakeOffLocation")]
	[CompilerGenerated]
	private DarkButton globalPool;

	[AccessedThroughProperty("Button_ChangeLandingLocation")]
	[CompilerGenerated]
	private DarkButton _WorkerPool;

	[AccessedThroughProperty("Button_ChangeDiversionLocation")]
	[CompilerGenerated]
	private DarkButton m_AccountPool;

	[AccessedThroughProperty("Button_CreateFlightplanFull")]
	[CompilerGenerated]
	private DarkButton m_StatePool;

	[AccessedThroughProperty("lblWeaponUsed")]
	[CompilerGenerated]
	private DarkLabel authenticationPool;

	[AccessedThroughProperty("lblActualWeaponUsage")]
	[CompilerGenerated]
	private DarkLabel paramsPool;

	public bool WaypointList_Refresh;

	public Mission SelectedMission;

	private Mission.Flight infoPool;

	private static bool _HelperPool;

	private Waypoint m_MapperPool;

	public int SelectedRow;

	private bool m_ManagerPool;

	public FlightPlanWaypoints theFlightPlanWaypoints;

	private List<TabPage> _GetterPool;

	private List<FlightPlanWaypoints> _ProducerPool;

	private List<DataTable> m_ProcPool;

	private DataTable structTask;

	private int m_MerchantTask;

	private int m_CallbackTask;

	private int _DecoratorTask;

	private int processTask;

	private int threadTask;

	private int m_RuleTask;

	private int m_CollectionTask;

	private int m_InstanceTask;

	private int _ObjectTask;

	private int m_ParameterTask;

	private int _ExpressionTask;

	private int m_DispatcherTask;

	private int _ListenerTask;

	private int m_ConfigTask;

	private int m_RegistryTask;

	private int definitionTask;

	private int m_ValTask;

	private int _WrapperTask;

	private int observerTask;

	private int issuerTask;

	private int clientTask;

	private int _DicTask;

	private int _ConsumerTask;

	private int _FacadeTask;

	private int _ProxyTask;

	private int m_ReaderTask;

	private int m_PropertyTask;

	private int m_ImporterTask;

	private DataTable repositoryTask;

	private DataTable _BridgeTask;

	private DataTable _InvocationTask;

	private DataTable classTask;

	private DataTable m_RequestTask;

	private DataTable _ValueTask;

	public Bitmap theImageLocked;

	public Bitmap theImageUnlocked;

	public Bitmap theImageNotConfigured;

	public Bitmap theImageNotLockable;

	public Bitmap theImageRelative;

	private bool tokenizerTask;

	[CompilerGenerated]
	private Size m_StubTask;

	internal DarkUITabControl TabControl_Aircraft
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptPolicy;
			DarkUITabControl comparatorPool = m_ComparatorPool;
			if (comparatorPool != null)
			{
				comparatorPool.SelectedIndexChanged -= value2;
			}
			m_ComparatorPool = value;
			comparatorPool = m_ComparatorPool;
			if (comparatorPool != null)
			{
				comparatorPool.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_CurrentPackage
	{
		[CompilerGenerated]
		get
		{
			return itemPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnablePolicy;
			DarkUIComboBox darkUIComboBox = itemPool;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			itemPool = value;
			darkUIComboBox = itemPool;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_CurrentFlightPlan
	{
		[CompilerGenerated]
		get
		{
			return _SetterPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangePolicy;
			DarkUIComboBox setterPool = _SetterPool;
			if (setterPool != null)
			{
				setterPool.SelectionChangeCommitted -= value2;
			}
			_SetterPool = value;
			setterPool = _SetterPool;
			if (setterPool != null)
			{
				setterPool.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_FlightTask
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitPolicy;
			DarkUIComboBox creatorPool = m_CreatorPool;
			if (creatorPool != null)
			{
				creatorPool.SelectionChangeCommitted -= value2;
			}
			m_CreatorPool = value;
			creatorPool = m_CreatorPool;
			if (creatorPool != null)
			{
				creatorPool.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUITextBox TextBox_FlightCallsign
	{
		[CompilerGenerated]
		get
		{
			return _TemplatePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = RemovePolicy;
			EventHandler value3 = FindPolicy;
			EventHandler value4 = SetPolicy;
			DarkUITextBox.TextChangedEventHandler value5 = VisitPolicy;
			DarkUITextBox templatePool = _TemplatePool;
			if (templatePool != null)
			{
				templatePool.KeyPress -= value2;
				templatePool.Enter -= value3;
				templatePool.Leave -= value4;
				templatePool.TextChanged -= value5;
			}
			_TemplatePool = value;
			templatePool = _TemplatePool;
			if (templatePool != null)
			{
				templatePool.KeyPress += value2;
				templatePool.Enter += value3;
				templatePool.Leave += value4;
				templatePool.TextChanged += value5;
			}
		}
	}

	internal DarkUIComboBox Combo_FlightplanType
	{
		[CompilerGenerated]
		get
		{
			return m_MappingPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreatePolicy;
			DarkUIComboBox mappingPool = m_MappingPool;
			if (mappingPool != null)
			{
				mappingPool.SelectionChangeCommitted -= value2;
			}
			m_MappingPool = value;
			mappingPool = m_MappingPool;
			if (mappingPool != null)
			{
				mappingPool.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_MockPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockPool = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return tagPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tagPool = value;
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return fieldPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fieldPool = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_QueuePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_QueuePool = value;
		}
	}

	internal DarkButton Button_CopyFlightplan
	{
		[CompilerGenerated]
		get
		{
			return _RegPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupPolicy;
			DarkButton regPool = _RegPool;
			if (regPool != null)
			{
				regPool.Click -= value2;
			}
			_RegPool = value;
			regPool = _RegPool;
			if (regPool != null)
			{
				regPool.Click += value2;
			}
		}
	}

	internal DarkLabel Label_LaunchDateAndTime
	{
		[CompilerGenerated]
		get
		{
			return m_ParamPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParamPool = value;
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_RulesPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RulesPool = value;
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return m_MethodPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodPool = value;
		}
	}

	internal DarkButton Button_FillEmptySlots
	{
		[CompilerGenerated]
		get
		{
			return m_ServicePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludePolicy;
			DarkButton servicePool = m_ServicePool;
			if (servicePool != null)
			{
				servicePool.Click -= value2;
			}
			m_ServicePool = value;
			servicePool = m_ServicePool;
			if (servicePool != null)
			{
				servicePool.Click += value2;
			}
		}
	}

	internal DarkButton Button_ClearSlots
	{
		[CompilerGenerated]
		get
		{
			return systemPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludePolicy;
			DarkButton darkButton = systemPool;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			systemPool = value;
			darkButton = systemPool;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkLabel Label_AircraftType
	{
		[CompilerGenerated]
		get
		{
			return candidatePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			candidatePool = value;
		}
	}

	[field: AccessedThroughProperty("Label_LoadoutName")]
	internal DarkLabel Label_LoadoutName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkButton Button_ChangeAircraftType
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchPolicy;
			DarkButton policyPool = m_PolicyPool;
			if (policyPool != null)
			{
				policyPool.Click -= value2;
			}
			m_PolicyPool = value;
			policyPool = m_PolicyPool;
			if (policyPool != null)
			{
				policyPool.Click += value2;
			}
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return broadcasterPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			broadcasterPool = value;
		}
	}

	internal DarkLabel Label_ObjectiveDateAndTime
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IdentifierPool = value;
		}
	}

	[field: AccessedThroughProperty("Label10")]
	internal DarkLabel Label10
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_FlightStatus
	{
		[CompilerGenerated]
		get
		{
			return m_ParserPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParserPool = value;
		}
	}

	internal DarkButton Button_CreateFlightplanSkeleton
	{
		[CompilerGenerated]
		get
		{
			return _AlgoPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculatePolicy;
			DarkButton algoPool = _AlgoPool;
			if (algoPool != null)
			{
				algoPool.Click -= value2;
			}
			_AlgoPool = value;
			algoPool = _AlgoPool;
			if (algoPool != null)
			{
				algoPool.Click += value2;
			}
		}
	}

	internal DarkButton Button_DeleteFlightplan
	{
		[CompilerGenerated]
		get
		{
			return _DatabasePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiatePolicy;
			DarkButton databasePool = _DatabasePool;
			if (databasePool != null)
			{
				databasePool.Click -= value2;
			}
			_DatabasePool = value;
			databasePool = _DatabasePool;
			if (databasePool != null)
			{
				databasePool.Click += value2;
			}
		}
	}

	internal DarkGroupBox GroupBox_SelectedFlight
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorPool = value;
		}
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return messagePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			messagePool = value;
		}
	}

	internal DarkLabel Label11
	{
		[CompilerGenerated]
		get
		{
			return m_ProductPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProductPool = value;
		}
	}

	internal DarkLabel Label1_LandingLocation
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationPool = value;
		}
	}

	internal DarkLabel Label13
	{
		[CompilerGenerated]
		get
		{
			return iteratorPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iteratorPool = value;
		}
	}

	internal DarkLabel Label_TakeOffLocation
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InitializerPool = value;
		}
	}

	[field: AccessedThroughProperty("Label15")]
	internal DarkLabel Label15
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_DiversionAirfield
	{
		[CompilerGenerated]
		get
		{
			return factoryPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			factoryPool = value;
		}
	}

	internal DarkButton Button_ChangeTakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return m_AttributePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComparePolicy;
			DarkButton attributePool = m_AttributePool;
			if (attributePool != null)
			{
				attributePool.Click -= value2;
			}
			m_AttributePool = value;
			attributePool = m_AttributePool;
			if (attributePool != null)
			{
				attributePool.Click += value2;
			}
		}
	}

	internal DarkButton Button_ChangeObjectiveTime
	{
		[CompilerGenerated]
		get
		{
			return eventPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadPolicy;
			DarkButton darkButton = eventPool;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			eventPool = value;
			darkButton = eventPool;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkButton Button_ChangeTakeOffLocation
	{
		[CompilerGenerated]
		get
		{
			return globalPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisablePolicy;
			DarkButton darkButton = globalPool;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			globalPool = value;
			darkButton = globalPool;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkButton Button_ChangeLandingLocation
	{
		[CompilerGenerated]
		get
		{
			return _WorkerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdatePolicy;
			DarkButton workerPool = _WorkerPool;
			if (workerPool != null)
			{
				workerPool.Click -= value2;
			}
			_WorkerPool = value;
			workerPool = _WorkerPool;
			if (workerPool != null)
			{
				workerPool.Click += value2;
			}
		}
	}

	internal DarkButton Button_ChangeDiversionLocation
	{
		[CompilerGenerated]
		get
		{
			return m_AccountPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertPolicy;
			DarkButton accountPool = m_AccountPool;
			if (accountPool != null)
			{
				accountPool.Click -= value2;
			}
			m_AccountPool = value;
			accountPool = m_AccountPool;
			if (accountPool != null)
			{
				accountPool.Click += value2;
			}
		}
	}

	internal DarkButton Button_CreateFlightplanFull
	{
		[CompilerGenerated]
		get
		{
			return m_StatePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectPolicy;
			DarkButton statePool = m_StatePool;
			if (statePool != null)
			{
				statePool.Click -= value2;
			}
			m_StatePool = value;
			statePool = m_StatePool;
			if (statePool != null)
			{
				statePool.Click += value2;
			}
		}
	}

	internal DarkLabel lblWeaponUsed
	{
		[CompilerGenerated]
		get
		{
			return authenticationPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			authenticationPool = value;
		}
	}

	internal DarkLabel lblActualWeaponUsage
	{
		[CompilerGenerated]
		get
		{
			return paramsPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramsPool = value;
		}
	}

	public Mission.Flight SelectedFlight
	{
		get
		{
			return infoPool;
		}
		set
		{
			if (_HelperPool)
			{
				infoPool = value;
			}
			else if (!SelectPolicy())
			{
				infoPool = value;
			}
		}
	}

	public static bool DoNotNotifyFlightError { get; set; }

	public Waypoint SelectedWaypoint
	{
		get
		{
			return m_MapperPool;
		}
		set
		{
			m_MapperPool = value;
		}
	}

	public Size theDefaultSize
	{
		[CompilerGenerated]
		get
		{
			return m_StubTask;
		}
		[CompilerGenerated]
		set
		{
			m_StubTask = value;
		}
	}

	static FlightPlanEditor()
	{
		DoNotNotifyFlightError = false;
	}

	public FlightPlanEditor()
	{
		base.FormClosing += PatchPolicy;
		base.FormClosed += CallPolicy;
		base.Load += LogoutPolicy;
		base.VisibleChanged += ViewPolicy;
		base.KeyDown += CheckPolicy;
		base.Shown += ConcatPolicy;
		WaypointList_Refresh = true;
		SelectedRow = 0;
		m_ManagerPool = false;
		_GetterPool = new List<TabPage>();
		_ProducerPool = new List<FlightPlanWaypoints>();
		m_ProcPool = new List<DataTable>();
		structTask = new DataTable();
		repositoryTask = new DataTable();
		_BridgeTask = new DataTable();
		_InvocationTask = new DataTable();
		classTask = new DataTable();
		m_RequestTask = new DataTable();
		_ValueTask = new DataTable();
		theImageLocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Locked_16.png");
		theImageUnlocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Unlocked_16.png");
		theImageNotConfigured = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotConfigured_16.png");
		theImageNotLockable = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotLockable_16.png");
		theImageRelative = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Relative_16.png");
		theDefaultSize = new Size(585, 358);
		AddPolicy();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && prototypePool != null)
			{
				prototypePool.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AddPolicy()
	{
		TabControl_Aircraft = new DarkUITabControl();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		Combo_CurrentPackage = new DarkUIComboBox();
		Combo_CurrentFlightPlan = new DarkUIComboBox();
		Combo_FlightTask = new DarkUIComboBox();
		TextBox_FlightCallsign = new DarkUITextBox();
		Button_CopyFlightplan = new DarkButton();
		Label_LaunchDateAndTime = new DarkLabel();
		Label6 = new DarkLabel();
		Label7 = new DarkLabel();
		Label5 = new DarkLabel();
		Button_FillEmptySlots = new DarkButton();
		Button_ClearSlots = new DarkButton();
		Label_AircraftType = new DarkLabel();
		Label_LoadoutName = new DarkLabel();
		Button_ChangeAircraftType = new DarkButton();
		Label8 = new DarkLabel();
		Label_ObjectiveDateAndTime = new DarkLabel();
		Label10 = new DarkLabel();
		Label_FlightStatus = new DarkLabel();
		Button_CreateFlightplanSkeleton = new DarkButton();
		Button_DeleteFlightplan = new DarkButton();
		GroupBox_SelectedFlight = new DarkGroupBox();
		Combo_FlightplanType = new DarkUIComboBox();
		Label9 = new DarkLabel();
		Label11 = new DarkLabel();
		Label1_LandingLocation = new DarkLabel();
		Label13 = new DarkLabel();
		Label_TakeOffLocation = new DarkLabel();
		Label15 = new DarkLabel();
		Label_DiversionAirfield = new DarkLabel();
		Button_ChangeTakeOffTime = new DarkButton();
		Button_ChangeObjectiveTime = new DarkButton();
		Button_ChangeTakeOffLocation = new DarkButton();
		Button_ChangeLandingLocation = new DarkButton();
		Button_ChangeDiversionLocation = new DarkButton();
		Button_CreateFlightplanFull = new DarkButton();
		lblWeaponUsed = new DarkLabel();
		lblActualWeaponUsage = new DarkLabel();
		GroupBox_SelectedFlight.SuspendLayout();
		SuspendLayout();
		TabControl_Aircraft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl_Aircraft.Cursor = Cursors.Hand;
		TabControl_Aircraft.ItemSize = new Size(80, 20);
		TabControl_Aircraft.Location = new Point(0, 340);
		TabControl_Aircraft.Name = "TabControl_Aircraft";
		TabControl_Aircraft.SelectedIndex = 0;
		TabControl_Aircraft.Size = new Size(500, 492);
		TabControl_Aircraft.TabIndex = 10;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(6, 20);
		Label1.Name = "Label1";
		Label1.Size = new Size(80, 25);
		Label1.TabIndex = 11;
		Label1.Text = "任务包：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(6, 42);
		Label2.Name = "Label2";
		Label2.Size = new Size(60, 25);
		Label2.TabIndex = 11;
		Label2.Text = "编队：";
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(2, 77);
		Label3.Name = "Label3";
		Label3.Size = new Size(77, 25);
		Label3.TabIndex = 11;
		Label3.Text = "呼号：";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(2, 140);
		Label4.Name = "Label4";
		Label4.Size = new Size(49, 25);
		Label4.TabIndex = 11;
		Label4.Text = "任务：";
		Combo_CurrentPackage.BackColor = Color.Transparent;
		Combo_CurrentPackage.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_CurrentPackage.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_CurrentPackage.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_CurrentPackage.FormattingEnabled = true;
		Combo_CurrentPackage.Location = new Point(62, 16);
		Combo_CurrentPackage.Name = "Combo_CurrentPackage";
		Combo_CurrentPackage.Size = new Size(153, 27);
		Combo_CurrentPackage.TabIndex = 12;
		Combo_CurrentFlightPlan.BackColor = Color.Transparent;
		Combo_CurrentFlightPlan.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_CurrentFlightPlan.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_CurrentFlightPlan.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_CurrentFlightPlan.FormattingEnabled = true;
		Combo_CurrentFlightPlan.Location = new Point(62, 38);
		Combo_CurrentFlightPlan.Name = "Combo_CurrentFlightPlan";
		Combo_CurrentFlightPlan.Size = new Size(153, 27);
		Combo_CurrentFlightPlan.TabIndex = 12;
		Combo_FlightTask.BackColor = Color.Transparent;
		Combo_FlightTask.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_FlightTask.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_FlightTask.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_FlightTask.FormattingEnabled = true;
		Combo_FlightTask.Location = new Point(98, 136);
		Combo_FlightTask.Name = "Combo_FlightTask";
		Combo_FlightTask.Size = new Size(122, 27);
		Combo_FlightTask.TabIndex = 12;
		TextBox_FlightCallsign.AutoCompleteCustomSource = null;
		TextBox_FlightCallsign.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_FlightCallsign.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_FlightCallsign.BackColor = Color.Transparent;
		TextBox_FlightCallsign.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FlightCallsign.Image = null;
		TextBox_FlightCallsign.Lines = null;
		TextBox_FlightCallsign.Location = new Point(98, 73);
		TextBox_FlightCallsign.MaxLength = 32767;
		TextBox_FlightCallsign.Multiline = false;
		TextBox_FlightCallsign.Name = "TextBox_FlightCallsign";
		TextBox_FlightCallsign.ReadOnly = false;
		TextBox_FlightCallsign.ScrollBars = ScrollBars.None;
		TextBox_FlightCallsign.SelectionStart = 0;
		TextBox_FlightCallsign.Size = new Size(122, 20);
		TextBox_FlightCallsign.TabIndex = 13;
		TextBox_FlightCallsign.TextAlign = HorizontalAlignment.Left;
		TextBox_FlightCallsign.UseSystemPasswordChar = false;
		TextBox_FlightCallsign.WatermarkText = "";
		Button_CopyFlightplan.Location = new Point(358, 52);
		Button_CopyFlightplan.Name = "Button_CopyFlightplan";
		Button_CopyFlightplan.Padding = new Padding(5);
		Button_CopyFlightplan.Size = new Size(139, 24);
		Button_CopyFlightplan.TabIndex = 14;
		Button_CopyFlightplan.Text = "复制飞行计划";
		Label_LaunchDateAndTime.AutoSize = true;
		Label_LaunchDateAndTime.ForeColor = Color.FromArgb(220, 220, 220);
		Label_LaunchDateAndTime.Location = new Point(98, 203);
		Label_LaunchDateAndTime.Name = "Label_LaunchDateAndTime";
		Label_LaunchDateAndTime.Size = new Size(206, 25);
		Label_LaunchDateAndTime.TabIndex = 16;
		Label_LaunchDateAndTime.Text = "<起飞日期和时间>";
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(2, 161);
		Label6.Name = "Label6";
		Label6.Size = new Size(73, 25);
		Label6.TabIndex = 19;
		Label6.Text = "飞机：";
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(2, 182);
		Label7.Name = "Label7";
		Label7.Size = new Size(82, 25);
		Label7.TabIndex = 21;
		Label7.Text = "挂载：";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(2, 203);
		Label5.Name = "Label5";
		Label5.Size = new Size(158, 25);
		Label5.TabIndex = 23;
		Label5.Text = "祖鲁起飞时间：";
		Button_FillEmptySlots.Location = new Point(358, 102);
		Button_FillEmptySlots.Name = "Button_FillEmptySlots";
		Button_FillEmptySlots.Padding = new Padding(5);
		Button_FillEmptySlots.Size = new Size(139, 24);
		Button_FillEmptySlots.TabIndex = 24;
		Button_FillEmptySlots.Text = "填充飞机空位";
		Button_ClearSlots.Location = new Point(358, 77);
		Button_ClearSlots.Name = "Button_ClearSlots";
		Button_ClearSlots.Padding = new Padding(5);
		Button_ClearSlots.Size = new Size(139, 24);
		Button_ClearSlots.TabIndex = 25;
		Button_ClearSlots.Text = "清空飞机空位";
		Button_ClearSlots.Visible = false;
		Label_AircraftType.AutoSize = true;
		Label_AircraftType.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AircraftType.Location = new Point(98, 161);
		Label_AircraftType.Name = "Label_AircraftType";
		Label_AircraftType.Size = new Size(133, 25);
		Label_AircraftType.TabIndex = 26;
		Label_AircraftType.Text = "<飞机类型>";
		Label_LoadoutName.AutoSize = true;
		Label_LoadoutName.ForeColor = Color.FromArgb(220, 220, 220);
		Label_LoadoutName.Location = new Point(98, 182);
		Label_LoadoutName.Name = "Label_LoadoutName";
		Label_LoadoutName.Size = new Size(151, 25);
		Label_LoadoutName.TabIndex = 27;
		Label_LoadoutName.Text = "<挂载名称>";
		Button_ChangeAircraftType.Enabled = false;
		Button_ChangeAircraftType.Location = new Point(358, 162);
		Button_ChangeAircraftType.Name = "Button_ChangeAircraftType";
		Button_ChangeAircraftType.Padding = new Padding(5);
		Button_ChangeAircraftType.Size = new Size(139, 42);
		Button_ChangeAircraftType.TabIndex = 28;
		Button_ChangeAircraftType.Text = "改变飞机类型和挂载";
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(2, 224);
		Label8.Name = "Label8";
		Label8.Size = new Size(182, 25);
		Label8.TabIndex = 30;
		Label8.Text = "Time on Target (Zulu):";
		Label_ObjectiveDateAndTime.AutoSize = true;
		Label_ObjectiveDateAndTime.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ObjectiveDateAndTime.Location = new Point(98, 224);
		Label_ObjectiveDateAndTime.Name = "Label_ObjectiveDateAndTime";
		Label_ObjectiveDateAndTime.Size = new Size(199, 25);
		Label_ObjectiveDateAndTime.TabIndex = 29;
		Label_ObjectiveDateAndTime.Text = "<到达目标日期和时间>";
		Label10.AutoSize = true;
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(2, 119);
		Label10.Name = "Label10";
		Label10.Size = new Size(64, 25);
		Label10.TabIndex = 32;
		Label10.Text = "状态：";
		Label_FlightStatus.AutoSize = true;
		Label_FlightStatus.ForeColor = Color.FromArgb(220, 220, 220);
		Label_FlightStatus.Location = new Point(98, 119);
		Label_FlightStatus.Name = "Label_FlightStatus";
		Label_FlightStatus.Size = new Size(132, 25);
		Label_FlightStatus.TabIndex = 31;
		Label_FlightStatus.Text = "<编队状态>";
		Button_CreateFlightplanSkeleton.Enabled = false;
		Button_CreateFlightplanSkeleton.Location = new Point(358, 2);
		Button_CreateFlightplanSkeleton.Name = "Button_CreateFlightplanSkeleton";
		Button_CreateFlightplanSkeleton.Padding = new Padding(5);
		Button_CreateFlightplanSkeleton.Size = new Size(139, 24);
		Button_CreateFlightplanSkeleton.TabIndex = 33;
		Button_CreateFlightplanSkeleton.Text = "创建Flightplan";
		Button_DeleteFlightplan.Enabled = false;
		Button_DeleteFlightplan.Location = new Point(358, 27);
		Button_DeleteFlightplan.Name = "Button_DeleteFlightplan";
		Button_DeleteFlightplan.Padding = new Padding(5);
		Button_DeleteFlightplan.Size = new Size(139, 24);
		Button_DeleteFlightplan.TabIndex = 34;
		Button_DeleteFlightplan.Text = "删除Flightplan";
		GroupBox_SelectedFlight.Controls.Add(Combo_CurrentFlightPlan);
		GroupBox_SelectedFlight.Controls.Add(Label1);
		GroupBox_SelectedFlight.Controls.Add(Label2);
		GroupBox_SelectedFlight.Controls.Add(Combo_CurrentPackage);
		GroupBox_SelectedFlight.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_SelectedFlight.Location = new Point(5, 2);
		GroupBox_SelectedFlight.Name = "GroupBox_SelectedFlight";
		GroupBox_SelectedFlight.Size = new Size(225, 68);
		GroupBox_SelectedFlight.TabIndex = 35;
		GroupBox_SelectedFlight.TabStop = false;
		GroupBox_SelectedFlight.Text = "所选编队";
		Combo_FlightplanType.BackColor = Color.Transparent;
		Combo_FlightplanType.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_FlightplanType.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_FlightplanType.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_FlightplanType.FormattingEnabled = true;
		Combo_FlightplanType.Location = new Point(98, 94);
		Combo_FlightplanType.Name = "Combo_FlightplanType";
		Combo_FlightplanType.Size = new Size(122, 27);
		Combo_FlightplanType.TabIndex = 37;
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(2, 98);
		Label9.Name = "Label9";
		Label9.Size = new Size(53, 25);
		Label9.TabIndex = 36;
		Label9.Text = "类型：";
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(2, 266);
		Label11.Name = "Label11";
		Label11.Size = new Size(147, 25);
		Label11.TabIndex = 41;
		Label11.Text = "着陆地点：";
		Label1_LandingLocation.AutoSize = true;
		Label1_LandingLocation.ForeColor = Color.FromArgb(220, 220, 220);
		Label1_LandingLocation.Location = new Point(98, 266);
		Label1_LandingLocation.Name = "Label1_LandingLocation";
		Label1_LandingLocation.Size = new Size(167, 25);
		Label1_LandingLocation.TabIndex = 40;
		Label1_LandingLocation.Text = "<降落位置>";
		Label13.AutoSize = true;
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(2, 245);
		Label13.Name = "Label13";
		Label13.Size = new Size(148, 25);
		Label13.TabIndex = 39;
		Label13.Text = "起飞地点：";
		Label_TakeOffLocation.AutoSize = true;
		Label_TakeOffLocation.ForeColor = Color.FromArgb(220, 220, 220);
		Label_TakeOffLocation.Location = new Point(98, 245);
		Label_TakeOffLocation.Name = "Label_TakeOffLocation";
		Label_TakeOffLocation.Size = new Size(168, 25);
		Label_TakeOffLocation.TabIndex = 38;
		Label_TakeOffLocation.Text = "<起飞位置>";
		Label15.AutoSize = true;
		Label15.ForeColor = Color.FromArgb(220, 220, 220);
		Label15.Location = new Point(2, 287);
		Label15.Name = "Label15";
		Label15.Size = new Size(158, 25);
		Label15.TabIndex = 43;
		Label15.Text = "转移地点：";
		Label_DiversionAirfield.AutoSize = true;
		Label_DiversionAirfield.ForeColor = Color.FromArgb(220, 220, 220);
		Label_DiversionAirfield.Location = new Point(98, 287);
		Label_DiversionAirfield.Name = "Label_DiversionAirfield";
		Label_DiversionAirfield.Size = new Size(178, 25);
		Label_DiversionAirfield.TabIndex = 42;
		Label_DiversionAirfield.Text = "<转移位置>";
		Button_ChangeTakeOffTime.Location = new Point(358, 204);
		Button_ChangeTakeOffTime.Name = "Button_ChangeTakeOffTime";
		Button_ChangeTakeOffTime.Padding = new Padding(5);
		Button_ChangeTakeOffTime.Size = new Size(139, 21);
		Button_ChangeTakeOffTime.TabIndex = 44;
		Button_ChangeTakeOffTime.Text = "改变起飞时间";
		Button_ChangeObjectiveTime.Location = new Point(358, 225);
		Button_ChangeObjectiveTime.Name = "Button_ChangeObjectiveTime";
		Button_ChangeObjectiveTime.Padding = new Padding(5);
		Button_ChangeObjectiveTime.Size = new Size(139, 21);
		Button_ChangeObjectiveTime.TabIndex = 45;
		Button_ChangeObjectiveTime.Text = "改变到达目标时间";
		Button_ChangeTakeOffLocation.Location = new Point(358, 246);
		Button_ChangeTakeOffLocation.Name = "Button_ChangeTakeOffLocation";
		Button_ChangeTakeOffLocation.Padding = new Padding(5);
		Button_ChangeTakeOffLocation.Size = new Size(139, 21);
		Button_ChangeTakeOffLocation.TabIndex = 46;
		Button_ChangeTakeOffLocation.Text = "改变起飞位置";
		Button_ChangeLandingLocation.Location = new Point(358, 267);
		Button_ChangeLandingLocation.Name = "Button_ChangeLandingLocation";
		Button_ChangeLandingLocation.Padding = new Padding(5);
		Button_ChangeLandingLocation.Size = new Size(139, 21);
		Button_ChangeLandingLocation.TabIndex = 47;
		Button_ChangeLandingLocation.Text = "更改着陆位置";
		Button_ChangeDiversionLocation.Location = new Point(358, 288);
		Button_ChangeDiversionLocation.Name = "Button_ChangeDiversionLocation";
		Button_ChangeDiversionLocation.Padding = new Padding(5);
		Button_ChangeDiversionLocation.Size = new Size(139, 21);
		Button_ChangeDiversionLocation.TabIndex = 48;
		Button_ChangeDiversionLocation.Text = "改变转移位置";
		Button_CreateFlightplanFull.Enabled = false;
		Button_CreateFlightplanFull.Location = new Point(226, 27);
		Button_CreateFlightplanFull.Name = "Button_CreateFlightplanFull";
		Button_CreateFlightplanFull.Padding = new Padding(5);
		Button_CreateFlightplanFull.Size = new Size(139, 24);
		Button_CreateFlightplanFull.TabIndex = 33;
		Button_CreateFlightplanFull.Text = "创建完整的飞行计划";
		lblWeaponUsed.AutoSize = true;
		lblWeaponUsed.ForeColor = Color.FromArgb(220, 220, 220);
		lblWeaponUsed.Location = new Point(2, 312);
		lblWeaponUsed.Name = "lblWeaponUsed";
		lblWeaponUsed.Size = new Size(133, 25);
		lblWeaponUsed.TabIndex = 50;
		lblWeaponUsed.Text = "Weapon in use:";
		lblActualWeaponUsage.AutoSize = true;
		lblActualWeaponUsage.ForeColor = Color.FromArgb(220, 220, 220);
		lblActualWeaponUsage.Location = new Point(126, 312);
		lblActualWeaponUsage.Name = "lblActualWeaponUsage";
		lblActualWeaponUsage.Size = new Size(251, 25);
		lblActualWeaponUsage.TabIndex = 49;
		lblActualWeaponUsage.Text = "No Data";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(499, 832);
		base.Controls.Add(lblWeaponUsed);
		base.Controls.Add(lblActualWeaponUsage);
		base.Controls.Add(Button_ChangeDiversionLocation);
		base.Controls.Add(Button_ChangeLandingLocation);
		base.Controls.Add(Button_ChangeTakeOffLocation);
		base.Controls.Add(Button_ChangeObjectiveTime);
		base.Controls.Add(Button_ChangeTakeOffTime);
		base.Controls.Add(Button_ChangeAircraftType);
		base.Controls.Add(Combo_FlightplanType);
		base.Controls.Add(Label9);
		base.Controls.Add(Label_FlightStatus);
		base.Controls.Add(GroupBox_SelectedFlight);
		base.Controls.Add(Button_DeleteFlightplan);
		base.Controls.Add(Button_CreateFlightplanFull);
		base.Controls.Add(Button_CreateFlightplanSkeleton);
		base.Controls.Add(Label10);
		base.Controls.Add(Button_ClearSlots);
		base.Controls.Add(Button_FillEmptySlots);
		base.Controls.Add(Button_CopyFlightplan);
		base.Controls.Add(TextBox_FlightCallsign);
		base.Controls.Add(Combo_FlightTask);
		base.Controls.Add(Label4);
		base.Controls.Add(Label3);
		base.Controls.Add(TabControl_Aircraft);
		base.Controls.Add(Label15);
		base.Controls.Add(Label_DiversionAirfield);
		base.Controls.Add(Label11);
		base.Controls.Add(Label1_LandingLocation);
		base.Controls.Add(Label13);
		base.Controls.Add(Label_TakeOffLocation);
		base.Controls.Add(Label8);
		base.Controls.Add(Label_ObjectiveDateAndTime);
		base.Controls.Add(Label_LoadoutName);
		base.Controls.Add(Label_AircraftType);
		base.Controls.Add(Label5);
		base.Controls.Add(Label7);
		base.Controls.Add(Label6);
		base.Controls.Add(Label_LaunchDateAndTime);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(515, 730);
		base.Name = "FlightPlanEditor";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编队任务编辑器";
		GroupBox_SelectedFlight.ResumeLayout(performLayout: false);
		GroupBox_SelectedFlight.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void DestroyPolicy(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (!Information.IsNothing(scenarioObject_0) && (object)scenarioObject_0.GetType() == typeof(Waypoint) && base.Visible && !bool_2 && (bool_1 || bool_3))
		{
			InvokePolicy();
		}
	}

	private void ComputePolicy(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (!Information.IsNothing(scenarioObject_0) && (object)scenarioObject_0.GetType() == typeof(Waypoint) && base.Visible && !bool_2 && (bool_1 || bool_3))
		{
			InvokePolicy();
		}
	}

	private void PatchPolicy(object sender, FormClosingEventArgs e)
	{
		if (SelectPolicy())
		{
			e.Cancel = true;
			return;
		}
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private bool SelectPolicy()
	{
		try
		{
			if (SelectedFlight == null)
			{
				return false;
			}
			if (_HelperPool)
			{
				return false;
			}
			if (SelectedFlight != null && SelectedFlight.HasCriticalError)
			{
				if (DarkMessageBox.ShowError(Client.CurrentScenario.GetConcatenated_MDSP_Errors("", SelectedFlight.Callsign) + Environment.NewLine + Environment.NewLine + Environment.NewLine + " Do you want to leave the flightplan as it is?", "AT LEAST ONE FLIGH MIGHT NOT TAKE OFF", DarkDialogButton.YesNo) == DialogResult.Yes)
				{
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
			exception_?.Data.Add("Error at 048745658393654432", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return false;
	}

	private void CallPolicy(object sender, FormClosedEventArgs e)
	{
		Doctrine.DoctrineChanged -= DestroyPolicy;
		Doctrine.EmconChanged -= ComputePolicy;
		MissionEditor.SelectedMissionChanged -= ValidatePolicy;
		Client.FlightPlanEditorWindow = null;
	}

	private void LogoutPolicy(object sender, EventArgs e)
	{
		Doctrine.DoctrineChanged += DestroyPolicy;
		Doctrine.EmconChanged += ComputePolicy;
		MissionEditor.SelectedMissionChanged += ValidatePolicy;
	}

	private void ViewPolicy(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			LoadWindow();
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public void LoadWindow()
	{
		NewPolicy();
		InvokePolicy();
		GetPolicy(bool_0: false);
		if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
			Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
			Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
			flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
			flightPlanEditorWindow.SelectedFlight = flight_;
		}
	}

	public void RefreshWindow()
	{
		InvokePolicy();
		if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
			Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
			Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
			flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
			flightPlanEditorWindow.SelectedFlight = flight_;
		}
	}

	public void ReloadWindow()
	{
		LoadWindow();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	private void ValidatePolicy(ScenarioObject scenarioObject_0)
	{
		try
		{
			if (!Information.IsNothing(scenarioObject_0))
			{
				NewPolicy();
				GetPolicy(bool_0: false);
				if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
				{
					FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
					ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
					FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
					Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
					FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
					Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
					flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
					flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
					flightPlanEditorWindow.SelectedFlight = flight_;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200630", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private string LoginPolicy(ref ActiveUnit.Throttle throttle_0)
	{
		switch (throttle_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return throttle_0.ToString();
		case ActiveUnit.Throttle.FullStop:
			return "完全停止";
		case ActiveUnit.Throttle.Loiter:
			return "Loiter";
		case ActiveUnit.Throttle.Cruise:
			return "Cruise";
		case ActiveUnit.Throttle.Full:
			return "Military";
		case ActiveUnit.Throttle.Flank:
			return "Afterburner";
		}
	}

	internal void GetPolicy(bool bool_0)
	{
		try
		{
			Combo_CurrentPackage.Items.Clear();
			int num = 0;
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (mission.Category != Mission.MissionCategory.TaskPool)
				{
					Combo_CurrentPackage.Items.Insert(num, mission.Name);
					if (mission == SelectedMission)
					{
						Combo_CurrentPackage.SelectedIndex = num;
					}
					num++;
				}
			}
			Combo_CurrentFlightPlan.Items.Clear();
			num = 0;
			foreach (Mission.Flight flight in SelectedMission.FlightList)
			{
				Combo_CurrentFlightPlan.Items.Insert(num, flight.Callsign);
				if (!Information.IsNothing(SelectedFlight))
				{
					if (flight == SelectedFlight)
					{
						Combo_CurrentFlightPlan.SelectedIndex = num;
					}
					num++;
				}
			}
			if (Information.IsNothing(SelectedFlight))
			{
				Combo_CurrentFlightPlan.SelectedIndex = -1;
				Combo_CurrentFlightPlan.Text = "";
				TextBox_FlightCallsign.Text = "";
			}
			else
			{
				TextBox_FlightCallsign.Text = SelectedFlight.Callsign;
			}
			if (Information.IsNothing(SelectedFlight))
			{
				Combo_FlightTask.DataSource = null;
				Combo_FlightTask.Items.Clear();
				Combo_FlightTask.SelectedIndex = -1;
				Combo_FlightplanType.DataSource = null;
				Combo_FlightplanType.Items.Clear();
				Combo_FlightplanType.SelectedIndex = -1;
			}
			else
			{
				DataTable dataTable_ = new DataTable();
				Mission.Flight.ComboBoxDataSource_Task(ref dataTable_);
				DarkUIComboBox combo_FlightTask = Combo_FlightTask;
				combo_FlightTask.DataSource = dataTable_;
				combo_FlightTask.DisplayMember = "Description";
				combo_FlightTask.ValueMember = "ID";
				combo_FlightTask.DropDownWidth = 500;
				Combo_FlightTask.SelectedIndex = Mission.Flight.Task_To_TaskSelection((int)SelectedFlight.Task);
				DataTable dataTable_2 = new DataTable();
				Mission.Flight.ComboBoxDataSource_Type(ref dataTable_2);
				DarkUIComboBox combo_FlightplanType = Combo_FlightplanType;
				combo_FlightplanType.DataSource = dataTable_2;
				combo_FlightplanType.DisplayMember = "Description";
				combo_FlightplanType.ValueMember = "ID";
				combo_FlightplanType.DropDownWidth = 500;
				Combo_FlightplanType.SelectedIndex = Mission.Flight.Type_To_TypeSelection((int)SelectedFlight.Type);
			}
			WritePolicy();
			if (bool_0 && !Information.IsNothing(SelectedFlight))
			{
				Label_AircraftType.Text = SelectedFlight.ReferenceUnit_Name;
				Label_LoadoutName.Text = SelectedFlight.GetLoadoutName(Client.CurrentScenario);
			}
			try
			{
				bool flag = false;
				if (SelectedFlight != null)
				{
					Waypoint[] flightPlan = SelectedFlight.FlightPlan;
					Waypoint[] array = flightPlan;
					foreach (Waypoint waypoint in array)
					{
						if (waypoint == null || waypoint.ReferenceWeapon_ID == 0)
						{
							continue;
						}
						Scenario scenario_ = Client.CurrentScenario;
						Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_, waypoint.ReferenceWeapon_ID, bool_0: false);
						if (newWeapon != null)
						{
							float num2 = 1f;
							string text = "mt";
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								num2 = 3.28084f;
								text = "ft";
							}
							lblActualWeaponUsage.Text = newWeapon.Name + " " + Math.Round(newWeapon.MinLaunchAlt_AGL * num2) + " " + text + " - " + Math.Round(newWeapon.MaxLaunchAlt_AGL * num2) + " " + text;
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					lblActualWeaponUsage.Text = "No Data";
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void WritePolicy()
	{
		try
		{
			if (Information.IsNothing(SelectedFlight))
			{
				Button_DeleteFlightplan.Enabled = false;
				Button_CreateFlightplanSkeleton.Enabled = false;
				Button_CreateFlightplanFull.Enabled = false;
				Button_CopyFlightplan.Enabled = false;
				Button_ClearSlots.Enabled = false;
				Button_FillEmptySlots.Enabled = false;
				Button_ChangeAircraftType.Enabled = false;
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ChangeTakeOffLocation.Enabled = false;
				Button_ChangeLandingLocation.Enabled = false;
				Button_ChangeDiversionLocation.Enabled = false;
				return;
			}
			Combo_FlightplanType.Enabled = false;
			if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
			{
				Combo_FlightplanType.Enabled = true;
			}
			else
			{
				Combo_FlightplanType.Enabled = false;
			}
			if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
			{
				if (SelectedFlight.FlightPlan.Count() <= 0)
				{
					Button_CreateFlightplanSkeleton.Enabled = true;
					Button_CreateFlightplanFull.Enabled = true;
				}
				else
				{
					Button_CreateFlightplanSkeleton.Enabled = false;
					Button_CreateFlightplanFull.Enabled = false;
				}
			}
			else
			{
				Button_CreateFlightplanSkeleton.Enabled = false;
				Button_CreateFlightplanFull.Enabled = false;
			}
			if (SelectedFlight.FlightPlan.Count() <= 0)
			{
				Button_DeleteFlightplan.Enabled = false;
			}
			else
			{
				Button_DeleteFlightplan.Enabled = true;
			}
			Button_CopyFlightplan.Enabled = true;
			if (SelectedFlight.Type == Mission._FlightType.Flightplan)
			{
				if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					Button_ClearSlots.Enabled = false;
					foreach (ActiveUnit item in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario))
					{
						if (item.Navigator.HasFlight && item.Navigator.GetFlight() == SelectedFlight)
						{
							Button_ClearSlots.Enabled = true;
							break;
						}
					}
					Button_FillEmptySlots.Enabled = false;
					if (!Information.IsNothing(SelectedMission.EmptySlotsList))
					{
						foreach (Mission.EmptyAircraftSlot emptySlots in SelectedMission.EmptySlotsList)
						{
							if (Operators.CompareString(emptySlots.MissionFlight_ObjectID, SelectedFlight.ObjectID, TextCompare: true) == 0)
							{
								Button_FillEmptySlots.Enabled = true;
								break;
							}
						}
					}
				}
				else
				{
					Button_ClearSlots.Enabled = false;
					Button_FillEmptySlots.Enabled = false;
				}
			}
			else
			{
				Button_ClearSlots.Enabled = false;
				Button_FillEmptySlots.Enabled = false;
			}
			if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
			{
				Button_ChangeAircraftType.Enabled = true;
			}
			else
			{
				Button_ChangeAircraftType.Enabled = false;
			}
			if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
			{
				Button_ChangeTakeOffLocation.Enabled = true;
				if (SelectedFlight.FlightPlan.Count() <= 0)
				{
					Button_ChangeTakeOffTime.Enabled = false;
				}
				else if (SelectedFlight.Type == Mission._FlightType.Flightplan)
				{
					Button_ChangeTakeOffTime.Enabled = true;
				}
				else
				{
					Button_ChangeTakeOffTime.Enabled = false;
				}
			}
			else
			{
				Button_ChangeTakeOffLocation.Enabled = false;
				Button_ChangeTakeOffTime.Enabled = false;
			}
			Button_ChangeObjectiveTime.Enabled = false;
			if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.Completed)
			{
				Button_ChangeLandingLocation.Enabled = false;
				Button_ChangeDiversionLocation.Enabled = false;
				return;
			}
			Button_ChangeLandingLocation.Enabled = true;
			Button_ChangeDiversionLocation.Enabled = true;
			if (SelectedFlight.Type != 0)
			{
				return;
			}
			Waypoint[] flightPlan = SelectedFlight.FlightPlan;
			for (int i = 0; i < flightPlan.Length; i = checked(i + 1))
			{
				Waypoint.WaypointType type = flightPlan[i].Type;
				if (type == Waypoint.WaypointType.Target || (uint)(type - 19) <= 5u)
				{
					Button_ChangeObjectiveTime.Enabled = true;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void NewPolicy(bool bool_0 = false)
	{
		if (!bool_0)
		{
			_GetterPool.Clear();
			_ProducerPool.Clear();
			m_ProcPool.Clear();
			try
			{
				TabControl_Aircraft.TabPages.Clear();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		if (Information.IsNothing(SelectedMission))
		{
			foreach (DataTable item in m_ProcPool)
			{
				item.Clear();
			}
			GetPolicy(bool_0: false);
			return;
		}
		if (Information.IsNothing(SelectedFlight))
		{
			foreach (DataTable item2 in m_ProcPool)
			{
				item2.Clear();
			}
			GetPolicy(bool_0: false);
			return;
		}
		if (SelectedMission.RestartValue())
		{
			try
			{
				bool flag = false;
				if (!bool_0)
				{
					List<ActiveUnit> source = (from x in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario)
						where !Information.IsNothing(x.Navigator.GetFlight())
						select x).ToList();
					source = source.Where((ActiveUnit x) => x.IsAircraft).ToList();
					source = source.Where((ActiveUnit activeUnit_0) => Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, SelectedFlight.Callsign, TextCompare: true) == 0).ToList();
					source = source.OrderByDescending((ActiveUnit theAC) => theAC.IsGroupLead()).ToList();
					int num = source.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						TabPage tabPage = new TabPage();
						tabPage.Size = theDefaultSize;
						string text = "";
						if (source[i].IsGroupLead())
						{
							text = " (Leader)";
						}
						tabPage.Text = source[i].Name + text;
						string string_ = "";
						if (((Aircraft)source[i]).IsAvailableForOps(ref string_) != 0)
						{
							tabPage.Text = tabPage.Text + " " + string_;
						}
						FlightPlanWaypoints flightPlanWaypoints = new FlightPlanWaypoints();
						flightPlanWaypoints.Size = theDefaultSize;
						flightPlanWaypoints.Dock = DockStyle.Fill;
						_ProducerPool.Add(flightPlanWaypoints);
						tabPage.Controls.Add(flightPlanWaypoints);
						m_ProcPool.Add(new DataTable());
						TabControl_Aircraft.TabPages.Add(tabPage);
					}
				}
				int num2;
				if (!Information.IsNothing(theFlightPlanWaypoints) && !Information.IsNothing(theFlightPlanWaypoints.DGV_Waypoints))
				{
					num2 = theFlightPlanWaypoints.DGV_Waypoints.SelectedRows.Count;
					if (num2 > 0)
					{
						SelectedRow = theFlightPlanWaypoints.DGV_Waypoints.SelectedRows[0].Index;
						SelectedWaypoint = (Waypoint)theFlightPlanWaypoints.DGV_Waypoints.Rows[SelectedRow].Tag;
					}
				}
				else
				{
					num2 = 0;
					SelectedRow = 0;
					SelectedWaypoint = null;
				}
				switch (TabControl_Aircraft.SelectedIndex)
				{
				default:
				{
					if (theFlightPlanWaypoints != _ProducerPool[TabControl_Aircraft.SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = _ProducerPool[TabControl_Aircraft.SelectedIndex];
					Mission.Flight.FlightElement flightPlan_Element = ActiveUnit.RetrieveFlightRole(TabControl_Aircraft.SelectedIndex + 1);
					_ProducerPool[TabControl_Aircraft.SelectedIndex].FlightPlan_Element = flightPlan_Element;
					structTask = m_ProcPool[TabControl_Aircraft.SelectedIndex];
					_ = (from activeUnit_0 in (from x in (from x in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario)
								where !Information.IsNothing(x.Navigator.GetFlight())
								select x).ToList()
							where x.IsAircraft
							select x).ToList()
						where Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, SelectedFlight.Callsign, TextCompare: true) == 0
						select activeUnit_0).ToList()[TabControl_Aircraft.SelectedIndex];
					break;
				}
				case -1:
					return;
				case 0:
					if (_ProducerPool == null || theFlightPlanWaypoints == null)
					{
						TabControl_Aircraft.SelectedIndex = 1;
						TabControl_Aircraft.SelectedIndex = 0;
					}
					if (theFlightPlanWaypoints != _ProducerPool[TabControl_Aircraft.SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = _ProducerPool[TabControl_Aircraft.SelectedIndex];
					_ProducerPool[TabControl_Aircraft.SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.LeadElement;
					structTask = m_ProcPool[TabControl_Aircraft.SelectedIndex];
					break;
				case 1:
					if (theFlightPlanWaypoints != _ProducerPool[TabControl_Aircraft.SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = _ProducerPool[TabControl_Aircraft.SelectedIndex];
					_ProducerPool[TabControl_Aircraft.SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.LeadElementWingman;
					structTask = m_ProcPool[TabControl_Aircraft.SelectedIndex];
					break;
				case 2:
					if (theFlightPlanWaypoints != _ProducerPool[TabControl_Aircraft.SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = _ProducerPool[TabControl_Aircraft.SelectedIndex];
					_ProducerPool[TabControl_Aircraft.SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.SecondElement;
					structTask = m_ProcPool[TabControl_Aircraft.SelectedIndex];
					break;
				case 3:
					if (theFlightPlanWaypoints != _ProducerPool[TabControl_Aircraft.SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = _ProducerPool[TabControl_Aircraft.SelectedIndex];
					_ProducerPool[TabControl_Aircraft.SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.SecondElementWingman;
					structTask = m_ProcPool[TabControl_Aircraft.SelectedIndex];
					break;
				case 4:
					if (theFlightPlanWaypoints != _ProducerPool[TabControl_Aircraft.SelectedIndex])
					{
						flag = true;
					}
					theFlightPlanWaypoints = _ProducerPool[TabControl_Aircraft.SelectedIndex];
					_ProducerPool[TabControl_Aircraft.SelectedIndex].FlightPlan_Element = Mission.Flight.FlightElement.ThirdElement;
					structTask = m_ProcPool[TabControl_Aircraft.SelectedIndex];
					break;
				}
				WaypointList_Refresh = false;
				structTask.Clear();
				foreach (DataTable item3 in m_ProcPool)
				{
					item3.Clear();
					WaypointList_Refresh = true;
				}
				if (structTask.Columns.Count == 0)
				{
					if (!structTask.Columns.Contains("ID"))
					{
						structTask.Columns.Add("ID", typeof(string));
						m_MerchantTask = 0;
					}
					if (!structTask.Columns.Contains("ObjectID"))
					{
						structTask.Columns.Add("ObjectID", typeof(string));
						m_CallbackTask = 1;
					}
					if (!structTask.Columns.Contains("Type"))
					{
						structTask.Columns.Add("Type", typeof(int));
						_DecoratorTask = 2;
					}
					if (!structTask.Columns.Contains("Time_Zulu"))
					{
						structTask.Columns.Add("Time_Zulu", typeof(string));
						processTask = 3;
					}
					if (!structTask.Columns.Contains("Time_Local"))
					{
						structTask.Columns.Add("Time_Local", typeof(string));
						threadTask = 4;
					}
					if (!structTask.Columns.Contains("TimeFixedImg"))
					{
						structTask.Columns.Add("TimeFixedImg", typeof(Image));
						m_CollectionTask = 5;
					}
					if (!structTask.Columns.Contains("TimeFixed"))
					{
						structTask.Columns.Add("TimeFixed", typeof(int));
						m_RuleTask = 6;
					}
					if (!structTask.Columns.Contains("DesiredSpeed"))
					{
						structTask.Columns.Add("DesiredSpeed", typeof(string));
						m_InstanceTask = 7;
					}
					if (!structTask.Columns.Contains("SpeedFixedImg"))
					{
						structTask.Columns.Add("SpeedFixedImg", typeof(Image));
						m_ParameterTask = 8;
					}
					if (!structTask.Columns.Contains("SpeedFixed"))
					{
						structTask.Columns.Add("SpeedFixed", typeof(int));
						_ObjectTask = 9;
					}
					if (!structTask.Columns.Contains("DesiredAltitude"))
					{
						structTask.Columns.Add("DesiredAltitude", typeof(string));
						_ExpressionTask = 10;
					}
					if (!structTask.Columns.Contains("Leg_Distance"))
					{
						structTask.Columns.Add("Leg_Distance", typeof(string));
						m_ValTask = 11;
					}
					if (!structTask.Columns.Contains("Leg_TotalDistance"))
					{
						structTask.Columns.Add("Leg_TotalDistance", typeof(string));
						_WrapperTask = 12;
					}
					if (!structTask.Columns.Contains("Leg_Time"))
					{
						structTask.Columns.Add("Leg_Time", typeof(string));
						m_ConfigTask = 13;
					}
					if (!structTask.Columns.Contains("Hold_Time"))
					{
						structTask.Columns.Add("Hold_Time", typeof(string));
						m_RegistryTask = 14;
					}
					if (!structTask.Columns.Contains("Leg_TotalTime"))
					{
						structTask.Columns.Add("Leg_TotalTime", typeof(string));
						definitionTask = 15;
					}
					if (!structTask.Columns.Contains("Leg_FuelRequired"))
					{
						structTask.Columns.Add("Leg_FuelRequired", typeof(string));
						m_DispatcherTask = 16;
					}
					if (!structTask.Columns.Contains("Leg_FuelRemaining"))
					{
						structTask.Columns.Add("Leg_FuelRemaining", typeof(string));
						_ListenerTask = 17;
					}
					if (!structTask.Columns.Contains("SpeedToT"))
					{
						structTask.Columns.Add("SpeedToT", typeof(int));
						m_PropertyTask = 18;
					}
					if (!structTask.Columns.Contains("Formation"))
					{
						structTask.Columns.Add("Formation", typeof(int));
						observerTask = 19;
					}
					if (!structTask.Columns.Contains("AARUsage"))
					{
						structTask.Columns.Add("AARUsage", typeof(int));
						clientTask = 20;
					}
					if (!structTask.Columns.Contains("AARSelection"))
					{
						structTask.Columns.Add("AARSelection", typeof(int));
						_DicTask = 21;
					}
					if (!structTask.Columns.Contains("AARSettings"))
					{
						structTask.Columns.Add("AARSettings", typeof(int));
						issuerTask = 22;
					}
					if (!structTask.Columns.Contains("SensorUsage"))
					{
						structTask.Columns.Add("SensorUsage", typeof(string));
						_ProxyTask = 23;
					}
					if (!structTask.Columns.Contains("Doctrine"))
					{
						structTask.Columns.Add("Doctrine", typeof(string));
						_FacadeTask = 24;
					}
					if (!structTask.Columns.Contains("TurnRate"))
					{
						structTask.Columns.Add("TurnRate", typeof(int));
						_ConsumerTask = 25;
					}
					if (!structTask.Columns.Contains("Coordinates"))
					{
						structTask.Columns.Add("Coordinates", typeof(string));
						m_ReaderTask = 26;
					}
					if (!structTask.Columns.Contains("Weapon"))
					{
						structTask.Columns.Add("Weapon", typeof(string));
						m_ImporterTask = 27;
					}
				}
				if (flag)
				{
					DataGridViewComboBoxColumn obj = (DataGridViewComboBoxColumn)theFlightPlanWaypoints.DGV_Waypoints.Columns[theFlightPlanWaypoints.DGV_Waypoints.Columns[_DecoratorTask].Index];
					Waypoint.ComboBoxDataSource_WaypointType(ref repositoryTask);
					obj.DataSource = repositoryTask;
					obj.DisplayMember = "Description";
					obj.ValueMember = "ID";
					DataGridViewComboBoxColumn obj2 = (DataGridViewComboBoxColumn)theFlightPlanWaypoints.DGV_Waypoints.Columns[theFlightPlanWaypoints.DGV_Waypoints.Columns[clientTask].Index];
					obj2.DataSource = _InvocationTask;
					obj2.DisplayMember = "Description";
					obj2.ValueMember = "ID";
					DataGridViewComboBoxColumn obj3 = (DataGridViewComboBoxColumn)theFlightPlanWaypoints.DGV_Waypoints.Columns[theFlightPlanWaypoints.DGV_Waypoints.Columns[_DicTask].Index];
					obj3.DataSource = classTask;
					obj3.DisplayMember = "Description";
					obj3.ValueMember = "ID";
					DataGridViewComboBoxColumn obj4 = (DataGridViewComboBoxColumn)theFlightPlanWaypoints.DGV_Waypoints.Columns[theFlightPlanWaypoints.DGV_Waypoints.Columns[observerTask].Index];
					Waypoint.ComboBoxDataSource_Formation(ref _BridgeTask);
					obj4.DataSource = _BridgeTask;
					obj4.DisplayMember = "Description";
					obj4.ValueMember = "ID";
					DataGridViewComboBoxColumn obj5 = (DataGridViewComboBoxColumn)theFlightPlanWaypoints.DGV_Waypoints.Columns[theFlightPlanWaypoints.DGV_Waypoints.Columns[_ConsumerTask].Index];
					Waypoint.ComboBoxDataSource_TurnRate(ref m_RequestTask);
					obj5.DataSource = m_RequestTask;
					obj5.DisplayMember = "Description";
					obj5.ValueMember = "ID";
					DataGridViewComboBoxColumn obj6 = (DataGridViewComboBoxColumn)theFlightPlanWaypoints.DGV_Waypoints.Columns[theFlightPlanWaypoints.DGV_Waypoints.Columns[m_PropertyTask].Index];
					Waypoint.ComboBoxDataSource_SpeedToT(ref _ValueTask);
					obj6.DataSource = _ValueTask;
					obj6.DisplayMember = "Description";
					obj6.ValueMember = "ID";
				}
				WaypointList_Refresh = false;
				Waypoint[] flightPlan = SelectedFlight.FlightPlan;
				for (int j = 0; j < flightPlan.Length; j = checked(j + 1))
				{
					DataRow row = structTask.NewRow();
					structTask.Rows.Add(row);
				}
				if (num2 == 0 && theFlightPlanWaypoints.DGV_Waypoints.Rows.Count > 0)
				{
					theFlightPlanWaypoints.DGV_Waypoints.Rows[0].Selected = false;
				}
				WaypointList_Refresh = true;
				InvokePolicy();
				if (SelectedFlight.FlightPlan.Count() > 0)
				{
					SelectedFlight.FlightPlan[0].Doctrine.ComboBox_UseReplenishment(ref _InvocationTask, Client.CurrentScenario, Doctrine._UseUnderwayRefuelAndReplenishment.Never);
					SelectedFlight.FlightPlan[0].Doctrine.ComboBox_ReplenishmentSelection(ref classTask, Client.CurrentScenario, Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround);
				}
				WaypointList_Refresh = false;
				theFlightPlanWaypoints.DGV_Waypoints.DataSource = new DataView(structTask);
				WaypointList_Refresh = true;
				int count = theFlightPlanWaypoints.DGV_Waypoints.Rows.Count;
				int num3 = SelectedFlight.FlightPlan.Count();
				for (int k = count - 1; k >= 0; k += -1)
				{
					if (k <= num3 - 1)
					{
						Waypoint waypoint_ = SelectedFlight.FlightPlan[k];
						if (!Information.IsNothing(waypoint_))
						{
							Waypoint actualWaypoint = FlightPlanWaypoints.GetActualWaypoint(ref waypoint_, theFlightPlanWaypoints.FlightPlan_Element);
							theFlightPlanWaypoints.DGV_Waypoints.Rows[k].Tag = actualWaypoint;
						}
					}
				}
				WaypointList_Refresh = false;
				if (theFlightPlanWaypoints.DGV_Waypoints.RowCount <= 0)
				{
					SelectedWaypoint = null;
				}
				else if (SelectedRow <= theFlightPlanWaypoints.DGV_Waypoints.RowCount - 1)
				{
					theFlightPlanWaypoints.DGV_Waypoints.Rows[0].Selected = false;
					theFlightPlanWaypoints.DGV_Waypoints.Rows[SelectedRow].Selected = true;
					SelectedWaypoint = (Waypoint)theFlightPlanWaypoints.DGV_Waypoints.Rows[SelectedRow].Tag;
				}
				else
				{
					theFlightPlanWaypoints.DGV_Waypoints.Rows[0].Selected = false;
					theFlightPlanWaypoints.DGV_Waypoints.Rows[theFlightPlanWaypoints.DGV_Waypoints.RowCount - 1].Selected = true;
					SelectedWaypoint = (Waypoint)theFlightPlanWaypoints.DGV_Waypoints.Rows[0].Tag;
				}
				WaypointList_Refresh = true;
				WaypointList_Refresh = false;
				theFlightPlanWaypoints.DisplayLocks();
				WaypointList_Refresh = true;
				theFlightPlanWaypoints.EnableAndDisableCells();
				theFlightPlanWaypoints.EnableAndDisableButtons();
				_ProducerPool[TabControl_Aircraft.SelectedIndex].DGV_Waypoints.ResumeLayout();
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		foreach (DataTable item4 in m_ProcPool)
		{
			item4.Clear();
		}
		GetPolicy(bool_0: false);
	}

	private Mission.Flight.FlightElement PushPolicy(int int_0)
	{
		throw new NotImplementedException();
	}

	internal void InvokePolicy()
	{
		try
		{
			if (Information.IsNothing(SelectedMission))
			{
				Text = "飞行编队编辑";
			}
			else if (Information.IsNothing(SelectedFlight))
			{
				Text = "飞行编队编辑";
			}
			else
			{
				if (!SelectedMission.RestartValue())
				{
					return;
				}
				Text = "飞行的飞行计划编辑" + SelectedFlight.Callsign;
				Label_AircraftType.Text = SelectedFlight.ReferenceUnit_Name;
				Label_LoadoutName.Text = SelectedFlight.GetLoadoutName(Client.CurrentScenario);
				Label_TakeOffLocation.Text = SelectedFlight.TakeOffLocation_HostUnitObjectName;
				Label1_LandingLocation.Text = SelectedFlight.LandingLocation_HostUnitObjectName;
				Label_DiversionAirfield.Text = SelectedFlight.AlternativeLandingLocation_HostUnitObjectName;
				Label_FlightStatus.Text = Mission.GetFlightStatusString(SelectedFlight.GetStatus(Client.CurrentScenario));
				if (string.IsNullOrEmpty(Label_AircraftType.Text))
				{
					Label_AircraftType.Text = "没有设置";
				}
				if (string.IsNullOrEmpty(Label_LoadoutName.Text))
				{
					Label_LoadoutName.Text = "没有设置";
				}
				if (string.IsNullOrEmpty(Label_TakeOffLocation.Text))
				{
					Label_TakeOffLocation.Text = "没有设置";
				}
				if (string.IsNullOrEmpty(Label1_LandingLocation.Text))
				{
					Label1_LandingLocation.Text = "没有设置";
				}
				if (string.IsNullOrEmpty(Label_DiversionAirfield.Text))
				{
					Label_DiversionAirfield.Text = "-";
				}
				if (string.IsNullOrEmpty(Label_FlightStatus.Text))
				{
					Label_FlightStatus.Text = "没有设置";
				}
				int num = 1;
				DateTime time = Client.CurrentScenario.Time;
				bool use_DST = Client.CurrentScenario.Use_DST;
				string dST_Start = Client.CurrentScenario.DST_Start;
				string dST_End = Client.CurrentScenario.DST_End;
				bool flag = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				if (Information.IsNothing(theFlightPlanWaypoints))
				{
					return;
				}
				theFlightPlanWaypoints.DGV_Waypoints.SuspendLayout();
				try
				{
					int num5 = SelectedFlight.FlightPlan.Count() - 1;
					DateTime? dateTime = null;
					Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
					Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = null;
					int num6 = 0;
					int num7 = 0;
					for (int num8 = 0; num8 <= num5; num8++)
					{
						Waypoint waypoint;
						Waypoint waypoint2;
						if (TabControl_Aircraft.SelectedIndex == 0)
						{
							waypoint = SelectedFlight.FlightPlan[num8];
							waypoint2 = SelectedFlight.FlightPlan[num8];
						}
						else if (TabControl_Aircraft.SelectedIndex == 1)
						{
							if (Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_LeadElementWingman))
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8];
							}
							else if (!Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_LeadElementWingman) && SelectedFlight.FlightPlan[num8].FlightFormation != Waypoint.Formation.Split)
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_LeadElementWingman;
							}
							else
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_LeadElementWingman;
							}
						}
						else if (TabControl_Aircraft.SelectedIndex == 2)
						{
							if (Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_SecondElement))
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8];
							}
							else if (!Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_SecondElement) && SelectedFlight.FlightPlan[num8].FlightFormation != Waypoint.Formation.Split)
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_SecondElement;
							}
							else
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_SecondElement;
							}
						}
						else if (TabControl_Aircraft.SelectedIndex == 3)
						{
							if (Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_SecondElementWingman))
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8];
							}
							else if (!Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_SecondElementWingman) && SelectedFlight.FlightPlan[num8].FlightFormation != Waypoint.Formation.Split)
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_SecondElementWingman;
							}
							else
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_SecondElementWingman;
							}
						}
						else if (TabControl_Aircraft.SelectedIndex == 4)
						{
							if (Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_ThirdElement))
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8];
							}
							else if (!Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_ThirdElement) && SelectedFlight.FlightPlan[num8].FlightFormation != Waypoint.Formation.Split)
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_ThirdElement;
							}
							else
							{
								waypoint = SelectedFlight.FlightPlan[num8];
								waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_ThirdElement;
							}
						}
						else if (Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_ThirdElementWingman))
						{
							waypoint = SelectedFlight.FlightPlan[num8];
							waypoint2 = SelectedFlight.FlightPlan[num8];
						}
						else if (!Information.IsNothing(SelectedFlight.FlightPlan[num8].Waypoint_ThirdElementWingman) && SelectedFlight.FlightPlan[num8].FlightFormation != Waypoint.Formation.Split)
						{
							waypoint = SelectedFlight.FlightPlan[num8];
							waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_ThirdElementWingman;
						}
						else
						{
							waypoint = SelectedFlight.FlightPlan[num8];
							waypoint2 = SelectedFlight.FlightPlan[num8].Waypoint_ThirdElementWingman;
						}
						DataRow dataRow = structTask.Rows[num8];
						Waypoint waypoint3 = (waypoint.SetupReponse() ? waypoint2 : waypoint);
						int num9 = Waypoint.WaypointType_To_WaypointTypeSelection(waypoint.Type);
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_DecoratorTask]), num9))
						{
							dataRow[_DecoratorTask] = num9;
						}
						if (waypoint.Type == Waypoint.WaypointType.StationEnd && waypoint.Station_Time == 0f)
						{
							flag = true;
							flag4 = true;
						}
						string text = (string.IsNullOrEmpty(waypoint.Description) ? Conversions.ToString(num) : waypoint.Description);
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_MerchantTask]), text))
						{
							dataRow[m_MerchantTask] = text;
						}
						num++;
						dataRow[m_CallbackTask] = waypoint.ObjectID;
						string text10;
						if (Information.IsNothing(waypoint3.Time_Zulu) || flag)
						{
							text10 = "-";
						}
						else
						{
							dateTime = (Information.IsNothing(waypoint3.Time_Zulu_Weapon) ? waypoint3.Time_Zulu : waypoint3.Time_Zulu_Weapon);
							text10 = ((dateTime.Value.Hour < 10) ? ("0" + dateTime.Value.Hour + ":") : (dateTime.Value.Hour + ":"));
							text10 = ((dateTime.Value.Minute < 10) ? (text10 + "0" + dateTime.Value.Minute + ":") : (text10 + dateTime.Value.Minute + ":"));
							text10 = ((dateTime.Value.Second < 10) ? (text10 + "0" + dateTime.Value.Second) : (text10 + dateTime.Value.Second));
							if (waypoint3.Type == Waypoint.WaypointType.TakeOff)
							{
								string text11 = dateTime.Value.Year + "-";
								text11 = ((dateTime.Value.Month < 10) ? (text11 + "0" + dateTime.Value.Month + "-") : (text11 + dateTime.Value.Month + "-"));
								text11 = ((dateTime.Value.Day < 10) ? (text11 + "0" + dateTime.Value.Day) : (text11 + dateTime.Value.Day));
								string left = text11 + ", " + text10;
								if (Operators.CompareString(left, Label_LaunchDateAndTime.Text, TextCompare: true) != 0)
								{
									Label_LaunchDateAndTime.Text = left;
								}
								flag5 = true;
							}
							else if (waypoint3.Type == Waypoint.WaypointType.Target || waypoint3.Type == Waypoint.WaypointType.WeaponTarget || waypoint3.SearchReponse())
							{
								string text12 = dateTime.Value.Year + "-";
								text12 = ((dateTime.Value.Month < 10) ? (text12 + "0" + dateTime.Value.Month + "-") : (text12 + dateTime.Value.Month + "-"));
								text12 = ((dateTime.Value.Day < 10) ? (text12 + "0" + dateTime.Value.Day) : (text12 + dateTime.Value.Day));
								string left2 = text12 + ", " + text10;
								if (Operators.CompareString(left2, Label_ObjectiveDateAndTime.Text, TextCompare: true) != 0)
								{
									Label_ObjectiveDateAndTime.Text = left2;
								}
								flag6 = true;
							}
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[processTask]), text10))
						{
							dataRow[processTask] = text10;
						}
						string text13;
						if (Information.IsNothing(dateTime) || Information.IsNothing(waypoint3.Time_Local) || flag)
						{
							text13 = "-";
						}
						else
						{
							DateTime? dateTime2 = (Information.IsNothing(waypoint3.Time_Zulu_Weapon) ? waypoint3.Time_Local : waypoint3.Time_Local_Weapon);
							text13 = ((dateTime2.Value.Hour < 10) ? ("0" + dateTime2.Value.Hour + ":") : (dateTime2.Value.Hour + ":"));
							text13 = ((dateTime2.Value.Minute < 10) ? (text13 + "0" + dateTime2.Value.Minute + ":") : (text13 + dateTime2.Value.Minute + ":"));
							text13 = ((dateTime2.Value.Second < 10) ? (text13 + "0" + dateTime2.Value.Second) : (text13 + dateTime2.Value.Second));
							waypoint3.TimeOfDay = SunModule.CollectSpecification(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, bool_0: false, waypoint3.Latitude, waypoint3.Longitude, 0.0);
							if (Information.IsNothing(waypoint3.Time_Zulu_Weapon))
							{
								waypoint3.Time_Local = Misc.DisableRequest(waypoint3.Time_Zulu.Value, waypoint3.Longitude, use_DST, dST_Start, dST_End);
							}
							else
							{
								waypoint3.Time_Local = Misc.DisableRequest(waypoint3.Time_Zulu_Weapon.Value, waypoint3.Longitude, use_DST, dST_Start, dST_End);
							}
							text13 = text13 + " (" + SunModule.ForgotSpecification(waypoint3.TimeOfDay, time, waypoint3.Longitude, use_DST, dST_Start, dST_End) + ")";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[threadTask]), text13))
						{
							dataRow[threadTask] = text13;
						}
						Waypoint.FixedFree fixedFree = ((Information.IsNothing(dateTime) || flag) ? Waypoint.FixedFree.None : waypoint3.TimeFixed);
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_RuleTask]), fixedFree))
						{
							dataRow[m_RuleTask] = fixedFree;
						}
						if (waypoint2.Doctrine.EMCON_Inherits)
						{
							dataRow[_ProxyTask] = "未配置";
						}
						else if (waypoint2.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && waypoint2.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && waypoint2.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
						{
							dataRow[_ProxyTask] = "使用任务EMCON";
						}
						else
						{
							string text14 = "";
							if (waypoint2.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active)
							{
								text14 = "雷达有效";
							}
							else if (waypoint2.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Passive)
							{
								text14 = "雷达被动";
							}
							if (waypoint2.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active)
							{
								if (!string.IsNullOrEmpty(text14))
								{
									text14 += ", ";
								}
								text14 += "声纳活跃";
							}
							else if (waypoint2.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Passive)
							{
								if (!string.IsNullOrEmpty(text14))
								{
									text14 += ", ";
								}
								text14 += "声纳被动";
							}
							if (waypoint2.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Active)
							{
								if (!string.IsNullOrEmpty(text14))
								{
									text14 += ", ";
								}
								text14 += "OECM活跃";
							}
							else if (waypoint2.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Passive)
							{
								if (!string.IsNullOrEmpty(text14))
								{
									text14 += ", ";
								}
								text14 += "OECM被动";
							}
							if (string.IsNullOrEmpty(text14))
							{
								text14 = "未配置";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ProxyTask]), text14))
							{
								dataRow[_ProxyTask] = text14;
							}
						}
						string text15 = Misc.CoordsToEnglish(waypoint3.Latitude, waypoint3.Longitude);
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ReaderTask]), text15))
						{
							dataRow[m_ReaderTask] = text15;
						}
						string text16 = "No Weapon";
						if (waypoint3.ReferenceWeapon_ID != 0)
						{
							Scenario scenario_ = Client.CurrentScenario;
							text16 = Weapon.GetNewWeapon(ref scenario_, waypoint3.ReferenceWeapon_ID, bool_0: false).Name;
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ImporterTask]), text16))
						{
							dataRow[m_ImporterTask] = text16;
						}
						string text17 = ((waypoint.Leg_FuelRequired < -2.1474836E+09f) ? "未设置未知，飞机类型和挂载类型" : (((Information.IsNothing(waypoint.Time_Zulu) && (waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd)) || waypoint.Type == Waypoint.WaypointType.TakeOff) ? "-" : (Conversions.ToString((int)Math.Round(waypoint2.Leg_FuelRequired)) + "千克")));
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_DispatcherTask]), text17))
						{
							dataRow[m_DispatcherTask] = text17;
						}
						string text2;
						if (waypoint.Leg_FuelRemaining <= 2.1474836E+09f)
						{
							byte? b = (byte?)useUnderwayRefuelAndReplenishment;
							bool? flag7 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
							bool? flag8 = (!flag7) ?? flag7;
							if (flag8.GetValueOrDefault(true))
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag9;
								bool? flag10 = (flag9 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
								bool? flag11;
								flag9 = (flag11 = ((flag10.HasValue && !flag9.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment2) ? new bool?(false) : flag9)));
								bool? flag2;
								if (flag9.HasValue && !flag11.GetValueOrDefault())
								{
									flag2 = false;
								}
								else
								{
									b = (byte?)useUnderwayRefuelAndReplenishment2;
									bool? flag3;
									flag9 = (flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
									flag2 = ((!flag9.HasValue) ? null : (flag3.GetValueOrDefault() & flag11));
								}
								flag7 = flag2;
								if (((!flag7) ?? flag7).GetValueOrDefault() && flag8.HasValue)
								{
									text2 = "未知，AAR允许";
									flag4 = false;
									goto IL_17a5;
								}
							}
							text2 = (flag4 ? "未知，巡逻时间未设置" : ((TabControl_Aircraft.SelectedIndex == 0) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining)) + "千克") : ((!waypoint.InvokeReponse()) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining)) + "千克") : ((TabControl_Aircraft.SelectedIndex == 1) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining_LeadElementWingman)) + "千克") : ((TabControl_Aircraft.SelectedIndex == 2) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining_SecondElement)) + "千克") : ((TabControl_Aircraft.SelectedIndex == 3) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining_SecondElementWingman)) + "千克") : ((TabControl_Aircraft.SelectedIndex == 4) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining_ThirdElement)) + "千克") : ((TabControl_Aircraft.SelectedIndex == 5) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining_ThirdElementWingman)) + "千克") : (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRemaining)) + "千克")))))))));
						}
						else
						{
							text2 = "Unknown";
						}
						goto IL_17a5;
						IL_17a5:
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ListenerTask]), text2))
						{
							dataRow[_ListenerTask] = text2;
						}
						useUnderwayRefuelAndReplenishment2 = useUnderwayRefuelAndReplenishment;
						useUnderwayRefuelAndReplenishment = waypoint2.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						string text3 = Misc.UpdateRequest((long)Math.Round(waypoint2.Leg_Time_Straight + waypoint2.Leg_Time_Turn), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
						if (waypoint2.Leg_Time_Weapon <= 0f)
						{
							if (waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd || waypoint.Type == Waypoint.WaypointType.TakeOff)
							{
								text3 = "-";
							}
						}
						else
						{
							text3 = text3 + "（武器：" + Misc.UpdateRequest((long)Math.Round(waypoint2.Leg_Time_Weapon), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ")";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ConfigTask]), text3))
						{
							dataRow[m_ConfigTask] = text3;
						}
						string text4 = ((flag || waypoint.Type == Waypoint.WaypointType.TakeOff) ? "-" : Misc.UpdateRequest((long)Math.Round(waypoint2.Leg_TotalTime), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true));
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[definitionTask]), text4))
						{
							dataRow[definitionTask] = text4;
						}
						string text5 = ((waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd || waypoint.Type == Waypoint.WaypointType.TakeOff || (int)Math.Round(waypoint2.Leg_Distance_Straight + waypoint2.Leg_Distance_Turn) == 0) ? "-" : (Conversions.ToString((int)Math.Round(waypoint2.Leg_Distance_Straight + waypoint2.Leg_Distance_Turn)) + "海里"));
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ValTask]), text5))
						{
							dataRow[m_ValTask] = text5;
						}
						string text6 = ((flag || waypoint.Type == Waypoint.WaypointType.TakeOff) ? "-" : ((TabControl_Aircraft.SelectedIndex == 0) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance)) + "海里") : ((!waypoint.InvokeReponse()) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance)) + "海里") : ((TabControl_Aircraft.SelectedIndex == 1 && !(waypoint.Leg_TotalDistance_LeadElementWingman <= 0f)) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance_LeadElementWingman)) + "海里") : ((TabControl_Aircraft.SelectedIndex == 2 && !(waypoint.Leg_TotalDistance_SecondElement <= 0f)) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance_SecondElement)) + "海里") : ((TabControl_Aircraft.SelectedIndex == 3 && !(waypoint.Leg_TotalDistance_SecondElementWingman <= 0f)) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance_SecondElementWingman)) + "海里") : ((TabControl_Aircraft.SelectedIndex == 4 && !(waypoint.Leg_TotalDistance_ThirdElement <= 0f)) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance_ThirdElement)) + "海里") : ((TabControl_Aircraft.SelectedIndex != 5 || waypoint.Leg_TotalDistance_ThirdElementWingman <= 0f) ? (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance)) + "海里") : (Conversions.ToString((int)Math.Round(waypoint.Leg_TotalDistance_ThirdElementWingman)) + "海里")))))))));
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_WrapperTask]), text6))
						{
							dataRow[_WrapperTask] = text6;
						}
						string text7 = ((!(waypoint3.Hold_Time > 0f) || waypoint3.Station_Time != 0f || waypoint3.SpacingManeuver_Time != 0f) ? ((waypoint3.Hold_Time == 0f && waypoint3.Station_Time == 0f && !(waypoint3.SpacingManeuver_Time <= 0f)) ? ((waypoint3.Separation_Time <= 0f) ? (Misc.UpdateRequest((long)Math.Round(waypoint3.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距") : (Misc.UpdateRequest((long)Math.Round(waypoint3.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " 90/90, " + Misc.UpdateRequest((long)Math.Round(waypoint3.Separation_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "分割")) : ((waypoint3.Hold_Time > 0f && waypoint3.Station_Time == 0f && !(waypoint3.SpacingManeuver_Time <= 0f)) ? (Information.IsNothing(dateTime) ? ("无待命，" + Misc.UpdateRequest((long)Math.Round(waypoint3.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距") : (Misc.UpdateRequest((long)Math.Round(waypoint3.Hold_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "保持，" + Misc.UpdateRequest((long)Math.Round(waypoint3.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距")) : ((waypoint3.Station_Time > 0f && SelectedFlight.Type == Mission._FlightType.FlightplanTemplate) ? (Misc.UpdateRequest((long)Math.Round(waypoint3.Station_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " 巡逻") : ((waypoint3.Hold_Time == 0f && waypoint3.Station_Time > 0f && waypoint3.SpacingManeuver_Time == 0f) ? (Information.IsNothing(dateTime) ? "N/A" : (Misc.UpdateRequest((long)Math.Round(waypoint3.Station_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " 巡逻")) : ((waypoint3.Hold_Time != 0f || !(waypoint3.Station_Time > 0f) || waypoint3.SpacingManeuver_Time <= 0f) ? "-" : (Information.IsNothing(dateTime) ? ("无警戒，" + Misc.UpdateRequest((long)Math.Round(waypoint3.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距") : (Misc.UpdateRequest((long)Math.Round(waypoint3.Station_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " 巡逻，" + Misc.UpdateRequest((long)Math.Round(waypoint3.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距"))))))) : (Information.IsNothing(dateTime) ? "N/A" : (Misc.UpdateRequest((long)Math.Round(waypoint3.Hold_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "保持")));
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_RegistryTask]), text7))
						{
							dataRow[m_RegistryTask] = text7;
						}
						Doctrine._UseUnderwayRefuelAndReplenishment value;
						if (waypoint.Doctrine.UseReplenishment_Inherits())
						{
							num6 = 3;
							value = waypoint.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
						}
						else
						{
							value = waypoint.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
							switch (value)
							{
							case Doctrine._UseUnderwayRefuelAndReplenishment.Always_ExceptTankersRefuellingTankers:
								num6 = 1;
								break;
							case Doctrine._UseUnderwayRefuelAndReplenishment.Never:
								num6 = 2;
								break;
							case Doctrine._UseUnderwayRefuelAndReplenishment.Always_IncludingTankersRefuellingTankers:
								num6 = 0;
								break;
							case Doctrine._UseUnderwayRefuelAndReplenishment.NotConfigured:
								num6 = 4;
								break;
							}
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[clientTask]), num6))
						{
							dataRow[clientTask] = num6;
						}
						if (!waypoint.Doctrine.UseReplenishment_Inherits() && value != Doctrine._UseUnderwayRefuelAndReplenishment.Never)
						{
							if (waypoint.Doctrine.ReplenishmentSelection_Inherits())
							{
								num7 = 3;
							}
							else
							{
								switch (waypoint.Doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value)
								{
								case Doctrine._UnderwayRefuelAndReplenishmentSelection.PickNearest:
									num7 = 0;
									break;
								case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveOnly:
									num7 = 1;
									break;
								case Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround:
									num7 = 2;
									break;
								case Doctrine._UnderwayRefuelAndReplenishmentSelection.NotConfigured:
									num7 = 4;
									break;
								}
							}
						}
						else
						{
							num7 = 0;
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_DicTask]), num7))
						{
							dataRow[_DicTask] = num7;
						}
						if (waypoint.Type == Waypoint.WaypointType.WeaponTarget)
						{
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ExpressionTask]), "-"))
							{
								dataRow[_ExpressionTask] = "-";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_InstanceTask]), "-"))
							{
								dataRow[m_InstanceTask] = "-";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ObjectTask]), Waypoint.FixedFree.None))
							{
								dataRow[_ObjectTask] = Waypoint.FixedFree.None;
							}
							int num10 = Waypoint.Formation_To_FormationSelection(waypoint.FlightFormation);
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[observerTask]), num10))
							{
								dataRow[observerTask] = num10;
							}
							int tankerMaxDistance_Airborne = waypoint.TankerMaxDistance_Airborne;
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[issuerTask]), tankerMaxDistance_Airborne))
							{
								dataRow[issuerTask] = tankerMaxDistance_Airborne;
							}
							Waypoint.TurnRateCategory turnRate_Navigation = waypoint3.TurnRate_Navigation;
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ConsumerTask]), turnRate_Navigation))
							{
								dataRow[_ConsumerTask] = turnRate_Navigation;
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_PropertyTask]), Waypoint.SpeedToT.No))
							{
								dataRow[m_PropertyTask] = Waypoint.SpeedToT.No;
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_FacadeTask]), "-"))
							{
								dataRow[_FacadeTask] = "-";
							}
						}
						else
						{
							string text8;
							if (!Information.IsNothing(waypoint3.DesiredSpeedOverride) && !Information.IsNothing(waypoint3.DesiredSpeed))
							{
								float? desiredSpeed;
								float? num11 = (desiredSpeed = waypoint3.DesiredSpeed);
								text8 = (num11.HasValue ? Conversions.ToString(desiredSpeed.GetValueOrDefault()) : null) + "节";
								if (!Information.IsNothing(SelectedFlight.GetReferenceUnit(Client.CurrentScenario)) && waypoint3.DesiredAltitudeOverride)
								{
									if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
									{
										string obj = text8;
										ActiveUnit.Throttle throttle_ = SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetThrottleSuitableForThisSpeed(waypoint3.DesiredAltitude_TerrainFollowing.Value, waypoint3.DesiredSpeed.Value);
										text8 = obj + " (" + LoginPolicy(ref throttle_) + ")";
									}
									else if (!Information.IsNothing(waypoint3.DesiredAltitude))
									{
										string obj2 = text8;
										ActiveUnit.Throttle throttle_2 = SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetThrottleSuitableForThisSpeed(waypoint3.DesiredAltitude.Value, waypoint3.DesiredSpeed.Value);
										text8 = obj2 + " (" + LoginPolicy(ref throttle_2) + ")";
									}
								}
							}
							else if (!Information.IsNothing(waypoint3.ThrottlePreset) && waypoint3.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
							{
								ActiveUnit.Throttle throttle_3 = (ActiveUnit.Throttle)waypoint3.ThrottlePreset;
								text8 = LoginPolicy(ref throttle_3);
								if (waypoint3.DesiredAltitudeOverride && !Information.IsNothing(waypoint3.DesiredSpeed))
								{
									string obj3 = text8;
									float? desiredSpeed2;
									float? num12 = (desiredSpeed2 = waypoint3.DesiredSpeed);
									text8 = obj3 + " (" + (num12.HasValue ? Conversions.ToString(desiredSpeed2.GetValueOrDefault()) : null) + "节）";
								}
							}
							else
							{
								text8 = "速度未设定！";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_InstanceTask]), text8))
							{
								dataRow[m_InstanceTask] = text8;
							}
							Waypoint.FixedFree speedFixed = waypoint3.SpeedFixed;
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ObjectTask]), speedFixed))
							{
								dataRow[_ObjectTask] = speedFixed;
							}
							string text9 = "";
							if (!Information.IsNothing(waypoint3.DesiredAltitudeOverride) && (!Information.IsNothing(waypoint3.DesiredAltitude) || (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))))
							{
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
									{
										text9 = (((int)Math.Round(waypoint3.DesiredAltitude_TerrainFollowing.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round((waypoint3.DesiredAltitude_TerrainFollowing * 3.28084f).Value)) + " 英尺 真高"));
									}
									else if (!Information.IsNothing(waypoint3.DesiredAltitude))
									{
										if ((int)Math.Round(waypoint3.DesiredAltitude.Value) == 0)
										{
											text9 = "Minimum";
										}
										else
										{
											float? desiredAltitude = waypoint3.DesiredAltitude;
											float num2 = MissionPlanner.AssetValue(ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude);
											if ((desiredAltitude.HasValue ? new bool?(desiredAltitude.GetValueOrDefault() == num2) : null).GetValueOrDefault())
											{
												waypoint3.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
												text9 = "Maximum";
											}
											else
											{
												text9 = Conversions.ToString((int)Math.Round((waypoint3.DesiredAltitude * 3.28084f).Value)) + " ft ASL";
											}
										}
									}
								}
								else if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
								{
									text9 = (((int)Math.Round(waypoint3.DesiredAltitude_TerrainFollowing.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round(waypoint3.DesiredAltitude_TerrainFollowing.Value)) + " 米 真高"));
								}
								else if (!Information.IsNothing(waypoint3.DesiredAltitude))
								{
									if ((int)Math.Round(waypoint3.DesiredAltitude.Value) == 0)
									{
										text9 = "Minimum";
									}
									else
									{
										float? desiredAltitude2 = waypoint3.DesiredAltitude;
										float num3 = MissionPlanner.AssetValue(ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude);
										if ((desiredAltitude2.HasValue ? new bool?(desiredAltitude2.GetValueOrDefault() == num3) : null).GetValueOrDefault())
										{
											waypoint3.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
											text9 = "Maximum";
										}
										else
										{
											text9 = Conversions.ToString((int)Math.Round(waypoint3.DesiredAltitude.Value)) + " 米 海高";
										}
									}
								}
							}
							else if (!Information.IsNothing(waypoint3.AltitudePreset) && waypoint3.AltitudePreset != 0)
							{
								switch (waypoint3.AltitudePreset)
								{
								case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
									text9 = "Minimum";
									break;
								case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
										{
											text9 = Conversions.ToString(305) + " 英尺 真高";
										}
										else if (!Information.IsNothing(waypoint3.DesiredAltitude))
										{
											text9 = Conversions.ToString(305) + " ft ASL";
										}
									}
									else if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
									{
										text9 = Conversions.ToString(305) + " 米 真高";
									}
									else if (!Information.IsNothing(waypoint3.DesiredAltitude))
									{
										text9 = Conversions.ToString(305) + " 米 海高";
									}
									break;
								case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
										{
											text9 = Conversions.ToString(610) + " 英尺 真高";
										}
										else if (!Information.IsNothing(waypoint3.DesiredAltitude))
										{
											text9 = Conversions.ToString(610) + " ft ASL";
										}
									}
									else if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
									{
										text9 = Conversions.ToString(610) + " 米 真高";
									}
									else if (!Information.IsNothing(waypoint3.DesiredAltitude))
									{
										text9 = Conversions.ToString(610) + " 米 海高";
									}
									break;
								case ActiveUnit_AI.AircraftAltitudePreset.const_4:
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
										{
											text9 = Conversions.ToString(3658) + " 英尺 真高";
										}
										else if (!Information.IsNothing(waypoint3.DesiredAltitude))
										{
											text9 = Conversions.ToString(3658) + " ft ASL";
										}
									}
									else if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
									{
										text9 = Conversions.ToString(3658) + " 米 真高";
									}
									else if (!Information.IsNothing(waypoint3.DesiredAltitude))
									{
										text9 = Conversions.ToString(3658) + " 米 海高";
									}
									break;
								case ActiveUnit_AI.AircraftAltitudePreset.const_5:
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
										{
											text9 = Conversions.ToString(7620) + " 英尺 真高";
										}
										else if (!Information.IsNothing(waypoint3.DesiredAltitude))
										{
											text9 = Conversions.ToString(7620) + " ft ASL";
										}
									}
									else if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
									{
										text9 = Conversions.ToString(7620) + " 米 真高";
									}
									else if (!Information.IsNothing(waypoint3.DesiredAltitude))
									{
										text9 = Conversions.ToString(7620) + " 米 海高";
									}
									break;
								case ActiveUnit_AI.AircraftAltitudePreset.const_6:
									if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
									{
										if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
										{
											text9 = Conversions.ToString(10973) + " 英尺 真高";
										}
										else if (!Information.IsNothing(waypoint3.DesiredAltitude))
										{
											text9 = Conversions.ToString(10973) + " ft ASL";
										}
									}
									else if (waypoint3.TerrainFollowing && !Information.IsNothing(waypoint3.DesiredAltitude_TerrainFollowing))
									{
										text9 = Conversions.ToString(10973) + " 米 真高";
									}
									else if (!Information.IsNothing(waypoint3.DesiredAltitude))
									{
										text9 = Conversions.ToString(10973) + " 米 海高";
									}
									break;
								case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
									text9 = "Maximum";
									break;
								}
							}
							else
							{
								text9 = "海拔高度没有设定！";
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ExpressionTask]), text9))
							{
								dataRow[_ExpressionTask] = text9;
							}
							int num4 = Waypoint.Formation_To_FormationSelection(waypoint.FlightFormation);
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[observerTask]), num4))
							{
								dataRow[observerTask] = num4;
							}
							int tankerMaxDistance_Airborne2 = waypoint.TankerMaxDistance_Airborne;
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[issuerTask]), tankerMaxDistance_Airborne2))
							{
								dataRow[issuerTask] = tankerMaxDistance_Airborne2;
							}
							Waypoint.TurnRateCategory turnRate_Navigation2 = waypoint3.TurnRate_Navigation;
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ConsumerTask]), turnRate_Navigation2))
							{
								dataRow[_ConsumerTask] = turnRate_Navigation2;
							}
							Waypoint.SpeedToT speedAdjustmentToT = waypoint3.SpeedAdjustmentToT;
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_PropertyTask]), speedAdjustmentToT))
							{
								dataRow[m_PropertyTask] = speedAdjustmentToT;
							}
							if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_FacadeTask]), "无论如何"))
							{
								dataRow[_FacadeTask] = "无论如何";
							}
						}
					}
				}
				finally
				{
					theFlightPlanWaypoints.DGV_Waypoints.ResumeLayout();
				}
				if (!flag5)
				{
					Label_LaunchDateAndTime.Text = "-";
				}
				if (!flag6)
				{
					Label_ObjectiveDateAndTime.Text = "-";
				}
				if (theFlightPlanWaypoints.DGV_Waypoints.Rows.Count <= 0)
				{
					SelectedWaypoint = null;
					return;
				}
				WaypointList_Refresh = false;
				if (theFlightPlanWaypoints.DGV_Waypoints.SelectedRows.Count > 0 && theFlightPlanWaypoints.DGV_Waypoints.SelectedRows[0].Index > 0 && SelectedRow != theFlightPlanWaypoints.DGV_Waypoints.SelectedRows[0].Index)
				{
					if (SelectedRow <= theFlightPlanWaypoints.DGV_Waypoints.Rows.Count - 1)
					{
						theFlightPlanWaypoints.DGV_Waypoints.Rows[SelectedRow].Selected = false;
					}
					SelectedRow = theFlightPlanWaypoints.DGV_Waypoints.SelectedRows[0].Index;
				}
				theFlightPlanWaypoints.DGV_Waypoints.Rows[0].Selected = false;
				if (theFlightPlanWaypoints.DGV_Waypoints.RowCount > 0)
				{
					if (SelectedRow <= theFlightPlanWaypoints.DGV_Waypoints.RowCount - 1)
					{
						theFlightPlanWaypoints.DGV_Waypoints.Rows[SelectedRow].Selected = false;
						theFlightPlanWaypoints.DGV_Waypoints.Rows[SelectedRow].Selected = true;
					}
					else
					{
						theFlightPlanWaypoints.DGV_Waypoints.Rows[theFlightPlanWaypoints.DGV_Waypoints.RowCount - 1].Selected = false;
						theFlightPlanWaypoints.DGV_Waypoints.Rows[theFlightPlanWaypoints.DGV_Waypoints.RowCount - 1].Selected = true;
					}
				}
				SelectedWaypoint = (Waypoint)theFlightPlanWaypoints.DGV_Waypoints.SelectedRows[0].Tag;
				WaypointList_Refresh = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SetupPolicy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight))
		{
			Mission.Flight selectedFlight = SelectedFlight;
			Scenario scenario_ = Client.CurrentScenario;
			Mission.Flight flight_ = SelectedFlight;
			Mission.Flight flight_2 = new Mission.Flight();
			ref Mission selectedMission = ref SelectedMission;
			int int_ = (int)SelectedFlight.CreatedBy;
			int int_2 = (int)SelectedFlight.EditedBy;
			selectedFlight.Copy(ref scenario_, ref flight_, ref flight_2, bool_0: false, ref selectedMission, ref int_, ref int_2, bool_1: true, bool_2: true);
			SelectedFlight = flight_;
			GetPolicy(bool_0: false);
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
	}

	private void ExcludePolicy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Mission selectedMission = SelectedMission;
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			Mission.Flight flight_ = SelectedFlight;
			selectedMission.ClearAllAircraft_ReplaceWithEmptySlots(ref scenario_, ref side_, ref flight_);
			SelectedFlight = flight_;
			Client.CurrentSide = side_;
			GetPolicy(bool_0: false);
			InvokePolicy();
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			if (Client.FlightPlanAircraftLoadoutWindow.Visible)
			{
				Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
		}
	}

	private void IncludePolicy(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight) || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
		{
			return;
		}
		if (!SelectedFlight.IsEscort && SelectedFlight.FlightPlan.Count() == 0)
		{
			Interaction.MsgBox("在分配飞机之前请先创建飞行计划");
			return;
		}
		Mission selectedMission = SelectedMission;
		Scenario currentScenario = Client.CurrentScenario;
		Side side_ = Client.CurrentSide;
		bool bool_ = true;
		selectedMission.FillEmptySlots(currentScenario, ref side_, ref bool_, SelectedFlight, bool_1: true);
		Client.CurrentSide = side_;
		GetPolicy(bool_0: false);
		InvokePolicy();
		if (Client.AirTaskingOrderWindow.Visible)
		{
			Client.AirTaskingOrderWindow.ReloadWindow();
		}
		if (Client.FlightPlanAircraftLoadoutWindow.Visible)
		{
			Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
		}
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		NewPolicy();
	}

	private void SearchPolicy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Client.FlightPlanAircraftLoadoutWindow.SelectedMission = SelectedMission;
			Client.FlightPlanAircraftLoadoutWindow.SelectedFlight = SelectedFlight;
			if (Client.FlightPlanAircraftLoadoutWindow.Visible)
			{
				Client.FlightPlanAircraftLoadoutWindow.ReloadWindow();
				Client.FlightPlanAircraftLoadoutWindow.BringToFront();
			}
			else
			{
				Client.FlightPlanAircraftLoadoutWindow.Show();
			}
		}
	}

	private void EnablePolicy(object sender, EventArgs e)
	{
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (Operators.CompareString(mission.Name, Conversions.ToString(Combo_CurrentPackage.SelectedItem), TextCompare: true) == 0)
			{
				SelectedMission = mission;
				break;
			}
		}
		if (SelectedMission.RestartValue())
		{
			SelectedFlight = SelectedMission.FlightList[0];
		}
		NewPolicy();
		GetPolicy(bool_0: false);
		if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
			Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
			Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
			flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
			flightPlanEditorWindow.SelectedFlight = flight_;
		}
	}

	private void ChangePolicy(object sender, EventArgs e)
	{
		foreach (Mission.Flight flight in SelectedMission.FlightList)
		{
			if (Operators.CompareString(flight.Callsign, Conversions.ToString(Combo_CurrentFlightPlan.SelectedItem), TextCompare: true) == 0)
			{
				SelectedFlight = flight;
				break;
			}
		}
		NewPolicy();
		GetPolicy(bool_0: false);
		if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
			Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
			Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
			flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
			flightPlanEditorWindow.SelectedFlight = flight_;
		}
	}

	private void InitPolicy(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedFlight))
		{
			return;
		}
		bool flag = false;
		Mission._FlightTask flightTask = Mission.Flight.TaskSelection_To_Task(Combo_FlightTask.SelectedIndex);
		if (flightTask == Mission._FlightTask.QRA)
		{
			if (SelectedMission.MissionClass != Mission._MissionClass.Patrol && SelectedMission.MissionClass != Mission._MissionClass.Support)
			{
				Interaction.MsgBox("只有巡逻和支援任务可以使用QRA类型的编队。");
				GetPolicy(bool_0: false);
				return;
			}
			if (SelectedMission.MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)SelectedMission;
				if (patrol.ContinousCoverage_Enable)
				{
					if (!patrol.ContinousCoverage_QRAEnable)
					{
						Interaction.MsgBox("任务没有启用QRA，因此QRA编队不会启动！");
					}
				}
				else
				{
					Interaction.MsgBox("任务没有启用持续覆盖，因此QRA编队将无法启动！");
				}
			}
			if (SelectedMission.MissionClass == Mission._MissionClass.Support)
			{
				SupportMission supportMission = (SupportMission)SelectedMission;
				if (supportMission.ContinousCoverage_Enable)
				{
					if (!supportMission.ContinousCoverage_QRAEnable)
					{
						Interaction.MsgBox("任务没有启用QRA，因此QRA编队不会启动！");
					}
				}
				else
				{
					Interaction.MsgBox("任务没有启用持续覆盖，因此QRA编队将无法启动！");
				}
			}
			bool bool_;
			if (bool_ = !Information.IsNothing(SelectedMission) && SelectedMission.Category == Mission.MissionCategory.Package)
			{
				Interaction.MsgBox("套餐不能使用QRA类型的编队。");
				GetPolicy(bool_0: false);
				return;
			}
			if (SelectedFlight.FlightPlan.Count() > 0 && !Information.IsNothing(SelectedFlight.FlightPlan[0].Time_Zulu))
			{
				if (Interaction.MsgBox("将编队任务类型更改为QRA将清除所有航点时间。继续？", MsgBoxStyle.YesNo) != MsgBoxResult.Yes)
				{
					GetPolicy(bool_0: false);
					return;
				}
				AirTaskingOrder.ClearFlightTime(SelectedFlight, bool_);
				flag = true;
			}
		}
		SelectedFlight.Task = flightTask;
		if (SelectedFlight.CheckInterruptibleQueue())
		{
			SelectedFlight.IsEscort = true;
		}
		else
		{
			SelectedFlight.IsEscort = false;
		}
		foreach (ActiveUnit item in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario))
		{
			if (item.Navigator.HasFlight && item.Navigator.GetFlight() == SelectedFlight)
			{
				item.AI.IsEscort = SelectedFlight.IsEscort;
			}
		}
		if (!Information.IsNothing(SelectedMission.EmptySlotsList))
		{
			foreach (Mission.EmptyAircraftSlot emptySlots in SelectedMission.EmptySlotsList)
			{
				if (Operators.CompareString(emptySlots.MissionFlight_ObjectID, SelectedFlight.ObjectID, TextCompare: true) == 0)
				{
					emptySlots.IsEscort = SelectedFlight.IsEscort;
				}
			}
		}
		theFlightPlanWaypoints.EnableAndDisableButtons();
		if (flag)
		{
			if (!Information.IsNothing(SelectedFlight))
			{
				Scenario currentScenario = Client.CurrentScenario;
				Mission selectedMission = SelectedMission;
				ActiveUnit referenceUnit = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
				Mission.Flight selectedFlight = SelectedFlight;
				Mission.Flight selectedFlight2 = SelectedFlight;
				Waypoint[] waypoint_ = selectedFlight2.FlightPlan;
				float float_ = 0f;
				float float_2 = 0f;
				MissionPlanner.ConnectTokenizer(currentScenario, selectedMission, referenceUnit, selectedFlight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
				selectedFlight2.FlightPlan = waypoint_;
			}
			InvokePolicy();
			RegistryParameterMessage.AwakeCustomer();
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		if (Client.AirTaskingOrderWindow.Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
	}

	private void CheckPolicy(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Hide();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ConcatPolicy(object sender, EventArgs e)
	{
	}

	private void InterruptPolicy(object sender, EventArgs e)
	{
		NewPolicy(bool_0: true);
		if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
		{
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
			Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
			Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
			flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
			flightPlanEditorWindow.SelectedFlight = flight_;
		}
	}

	private void RemovePolicy(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void FindPolicy(object sender, EventArgs e)
	{
		m_ManagerPool = true;
	}

	private void SetPolicy(object sender, EventArgs e)
	{
		FillPolicy();
	}

	private void FillPolicy()
	{
		if (m_ManagerPool && !Information.IsNothing(SelectedFlight))
		{
			Mission.Flight selectedFlight = SelectedFlight;
			Scenario scenario_ = Client.CurrentScenario;
			Mission.Flight flight_ = SelectedFlight;
			selectedFlight.RenameFlightplanInFlightplanErrorList(ref scenario_, ref flight_, SelectedFlight.Callsign, TextBox_FlightCallsign.Text);
			SelectedFlight = flight_;
			SelectedFlight.Callsign = TextBox_FlightCallsign.Text;
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		m_ManagerPool = false;
		GetPolicy(bool_0: false);
	}

	private void CalculatePolicy(object sender, EventArgs e)
	{
		try
		{
			if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight) || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
			{
				return;
			}
			SelectedFlight.DesiredAircraftQty = SelectedMission.FlightSize;
			if (SelectedMission.UseFlightSizeHardLimit)
			{
				SelectedFlight.MinimumAircraftQty = SelectedMission.FlightSize;
			}
			else
			{
				SelectedFlight.MinimumAircraftQty = 1;
			}
			if (SelectedFlight.ReferenceUnit_DBID == 0)
			{
				Interaction.MsgBox("在创建飞行计划之前选择飞机和挂载类型。");
			}
			else if (SelectedFlight.int_0 == 0)
			{
				Interaction.MsgBox("在创建飞行计划之前选择挂载类型。");
			}
			else if (PreparePolicy())
			{
				bool value = false;
				bool bool_ = false;
				bool bool_2 = false;
				bool bool_3 = false;
				float float_ = 0f;
				Aircraft aircraft_ = (Aircraft)Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
				bool bool_4 = false;
				float float_2 = 0f;
				Waypoint.TurnRateCategory turnRateCategory_ = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
				if (SelectedFlight.DesiredAircraftQty > 6)
				{
					_ = (int)SelectedFlight.DesiredAircraftQty;
					_ = (int)SelectedFlight.MinimumAircraftQty;
					SelectedFlight.DesiredAircraftQty = 6;
					SelectedFlight.MinimumAircraftQty = 6;
				}
				Scenario scenario_ = Client.CurrentScenario;
				Side side_ = Client.CurrentSide;
				ref Mission selectedMission = ref SelectedMission;
				FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
				Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
				bool? nullable_ = value;
				string string_ = "";
				MissionPlanner.GenerateFlightPlan_Skeleton(ref scenario_, ref side_, ref selectedMission, ref flight_, ref aircraft_, nullable_, ref bool_, bool_2, bool_3, ref float_, ref string_, bool_4, float_2, turnRateCategory_, bool_4: true, SelectedMission.TakeOffTime, SelectedMission.TimeOnTarget, bool_5: false);
				flightPlanEditorWindow.SelectedFlight = flight_;
				Client.CurrentSide = side_;
				List<ActiveUnit> list_ = (from x in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario)
					where Information.IsNothing(x.Navigator.GetFlight())
					select x).ToList();
				PopPolicy(list_);
				LoadWindow();
				if (Client.AirTaskingOrderWindow.Visible)
				{
					Client.AirTaskingOrderWindow.RefreshWindow();
				}
				if (Client.FlightPlanAircraftLoadoutWindow.Visible)
				{
					Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
				}
				if (Client.MissionEditorWindow.Visible)
				{
					Client.MissionEditorWindow.RefreshAssignedUnits();
					Client.MissionEditorWindow.RefreshUnassignedUnits();
				}
				Client.MustRefreshMainForm = true;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PopPolicy(List<ActiveUnit> list_0)
	{
		int num = 0;
		num = (from x in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario)
			where !Information.IsNothing(x.Navigator.GetFlight())
			select x into activeUnit_0
			where Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, SelectedFlight.Callsign, TextCompare: true) == 0
			select activeUnit_0).Count();
		int num2 = list_0.Count - 1;
		for (int i = 0; i <= num2; i++)
		{
			if ((from x in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario)
				where Information.IsNothing(x.Navigator.GetFlight())
				select x).Count() > 0)
			{
				if (!(num < SelectedFlight.DesiredAircraftQty))
				{
					break;
				}
				(from x in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario)
					where Information.IsNothing(x.Navigator.GetFlight())
					select x).ToList().First().SetFlight(SelectedFlight, i);
				num++;
			}
		}
		if (num < SelectedFlight.MinimumAircraftQty)
		{
			DarkMessageBox.ShowWarning("Minimum flight number for flight " + SelectedFlight.Callsign + " cannot be reached", "Minimum flight size not reached");
		}
	}

	private void InstantiatePolicy(object sender, EventArgs e)
	{
		try
		{
			if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight))
			{
				Mission selectedMission = SelectedMission;
				Scenario scenario_ = Client.CurrentScenario;
				Side side_ = Client.CurrentSide;
				FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
				Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
				selectedMission.DeleteFlightplan(ref scenario_, ref side_, ref flight_);
				flightPlanEditorWindow.SelectedFlight = flight_;
				Client.CurrentSide = side_;
				if (Client.AirTaskingOrderWindow.Visible)
				{
					Client.AirTaskingOrderWindow.LoadWindow();
				}
				LoadWindow();
				if (Client.MissionEditorWindow.Visible)
				{
					Client.MissionEditorWindow.RefreshAssignedUnits();
					Client.MissionEditorWindow.RefreshUnassignedUnits();
				}
				Client.MustRefreshMainForm = true;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CreatePolicy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Mission._FlightType flightType_ = Mission.Flight.TypeSelection_To_Type(Combo_FlightplanType.SelectedIndex);
			Mission.Flight selectedFlight = SelectedFlight;
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			AirTaskingOrder.ChangeFlightType(selectedFlight, ref scenario_, ref side_, ref SelectedMission, flightType_);
			Client.CurrentSide = side_;
			GetPolicy(bool_0: false);
			InvokePolicy();
			theFlightPlanWaypoints.EnableAndDisableButtons();
			theFlightPlanWaypoints.DisplayLocks();
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			if (Client.FlightPlanAircraftLoadoutWindow.Visible)
			{
				Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			RegistryParameterMessage.AwakeCustomer();
		}
	}

	private void ComparePolicy(object sender, EventArgs e)
	{
		try
		{
			if (Information.IsNothing(theFlightPlanWaypoints) || Information.IsNothing(theFlightPlanWaypoints.DGV_Waypoints) || Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight) || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
			{
				return;
			}
			bool flag = false;
			int num = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows.Count - 1;
			Waypoint waypoint_ = null;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows[i];
				waypoint_ = (Waypoint)dataGridViewRow.Tag;
				if (waypoint_.Type != Waypoint.WaypointType.TakeOff)
				{
					if (dataGridViewRow.Selected)
					{
						dataGridViewRow.Selected = false;
					}
					continue;
				}
				dataGridViewRow.Selected = true;
				flag = true;
				break;
			}
			if (flag && !Information.IsNothing(waypoint_))
			{
				Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission = ref SelectedMission;
				Mission.Flight flight_ = SelectedFlight;
				flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
				SelectedFlight = flight_;
				Client.FlightPlanTimeWindow.Show();
				Client.FlightPlanTimeWindow.BringToFront();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReadPolicy(object sender, EventArgs e)
	{
		try
		{
			if (Information.IsNothing(theFlightPlanWaypoints) || Information.IsNothing(theFlightPlanWaypoints.DGV_Waypoints) || Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight))
			{
				return;
			}
			bool flag = false;
			int num = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows.Count - 1;
			Waypoint waypoint_ = null;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows[i];
				waypoint_ = (Waypoint)dataGridViewRow.Tag;
				if (waypoint_ == null)
				{
					DarkMessageBox.ShowInformation("Create a flightplan in order to edit the Time on Target", "Flightplan not found");
				}
				Waypoint.WaypointType type = waypoint_.Type;
				if (type != Waypoint.WaypointType.Target && (uint)(type - 19) > 5u)
				{
					if (dataGridViewRow.Selected)
					{
						dataGridViewRow.Selected = false;
					}
					continue;
				}
				dataGridViewRow.Selected = true;
				flag = true;
				break;
			}
			if (flag && !Information.IsNothing(waypoint_))
			{
				Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission = ref SelectedMission;
				Mission.Flight flight_ = SelectedFlight;
				flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
				SelectedFlight = flight_;
				Client.FlightPlanTimeWindow.Show();
				Client.FlightPlanTimeWindow.BringToFront();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DisablePolicy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedFlight))
		{
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			ref Mission selectedMission = ref SelectedMission;
			Mission.Flight selectedFlight = SelectedFlight;
			ref string takeOffLocation_HostUnitObjectName = ref SelectedFlight.TakeOffLocation_HostUnitObjectName;
			ref string takeOffLocation_HostUnitObjectID = ref SelectedFlight.TakeOffLocation_HostUnitObjectID;
			Module_Unit.Unit unit_ = Client.SelectedUnit;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = Client.CurrentSide.SelectedUnits;
			ChangeFlightLocation(ref scenario_, ref side_, ref selectedMission, selectedFlight, ref takeOffLocation_HostUnitObjectName, ref takeOffLocation_HostUnitObjectID, ref unit_, ref readOnlyCollection_, bool_0: true, bool_1: false, bool_2: false);
			Client.CurrentSide = side_;
			LoadWindow();
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
			if (Client.FlightPlanAircraftLoadoutWindow.Visible)
			{
				Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
	}

	private void UpdatePolicy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedFlight))
		{
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			ref Mission selectedMission = ref SelectedMission;
			Mission.Flight selectedFlight = SelectedFlight;
			ref string landingLocation_HostUnitObjectName = ref SelectedFlight.LandingLocation_HostUnitObjectName;
			ref string landingLocation_HostUnitObjectID = ref SelectedFlight.LandingLocation_HostUnitObjectID;
			Module_Unit.Unit unit_ = Client.SelectedUnit;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = Client.CurrentSide.SelectedUnits;
			ChangeFlightLocation(ref scenario_, ref side_, ref selectedMission, selectedFlight, ref landingLocation_HostUnitObjectName, ref landingLocation_HostUnitObjectID, ref unit_, ref readOnlyCollection_, bool_0: false, bool_1: true, bool_2: false);
			Client.CurrentSide = side_;
			LoadWindow();
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
	}

	private void InsertPolicy(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedFlight))
		{
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			ref Mission selectedMission = ref SelectedMission;
			Mission.Flight selectedFlight = SelectedFlight;
			ref string alternativeLandingLocation_HostUnitObjectName = ref SelectedFlight.AlternativeLandingLocation_HostUnitObjectName;
			ref string alternativeLandingLocation_HostUnitObjectID = ref SelectedFlight.AlternativeLandingLocation_HostUnitObjectID;
			Module_Unit.Unit unit_ = Client.SelectedUnit;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = Client.CurrentSide.SelectedUnits;
			ChangeFlightLocation(ref scenario_, ref side_, ref selectedMission, selectedFlight, ref alternativeLandingLocation_HostUnitObjectName, ref alternativeLandingLocation_HostUnitObjectID, ref unit_, ref readOnlyCollection_, bool_0: false, bool_1: false, bool_2: true);
			Client.CurrentSide = side_;
			LoadWindow();
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
	}

	public void RecalculateFlightPlanFuelAndTimes(bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		try
		{
			if (!Information.IsNothing(SelectedFlight))
			{
				Scenario currentScenario = Client.CurrentScenario;
				Mission selectedMission = SelectedMission;
				ActiveUnit referenceUnit = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
				Mission.Flight selectedFlight = SelectedFlight;
				Mission.Flight selectedFlight2 = SelectedFlight;
				Waypoint[] waypoint_ = selectedFlight2.FlightPlan;
				float float_ = 0f;
				float float_2 = 0f;
				MissionPlanner.ConnectTokenizer(currentScenario, selectedMission, referenceUnit, selectedFlight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
				selectedFlight2.FlightPlan = waypoint_;
			}
			if (base.Visible && bool_1)
			{
				if (bool_2)
				{
					Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
					if (bool_3)
					{
						NewPolicy();
					}
					else
					{
						InvokePolicy();
						if (bool_4)
						{
							theFlightPlanWaypoints.DisplayLocks();
						}
					}
					Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
				}
				else if (bool_3)
				{
					NewPolicy();
				}
				else
				{
					InvokePolicy();
					if (bool_4)
					{
						theFlightPlanWaypoints.DisplayLocks();
					}
				}
			}
			if (bool_0)
			{
				RegistryParameterMessage.AwakeCustomer();
				Client.MustRefreshMainForm = true;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool PreparePolicy()
	{
		if (Information.IsNothing(SelectedFlight))
		{
			return false;
		}
		if (Information.IsNothing(Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario)))
		{
			if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.TakeOffLocation_HostUnitObjectID))
			{
				Interaction.MsgBox("没有设置起飞位置。在战术地图上选择起飞的机场或舰船，按“更改起飞位置”按钮，然后再次尝试创建飞行计划。");
				return false;
			}
			if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.LandingLocation_HostUnitObjectID))
			{
				Interaction.MsgBox("没有设置着陆位置。在战术地图上选择起飞的机场或舰船，按“更改起飞位置”按钮，然后再次尝试创建飞行计划。");
				return false;
			}
		}
		else
		{
			Aircraft aircraft = (Aircraft)Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
			if (aircraft.GetLatitude() == 0.0 && aircraft.GetLongitude() == 0.0)
			{
				if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.TakeOffLocation_HostUnitObjectID))
				{
					Interaction.MsgBox("没有设置起飞位置。在战术地图上选择起飞的机场或舰船，按“更改起飞位置”按钮，然后再次尝试创建飞行计划。");
					return false;
				}
				if (string.IsNullOrEmpty(Client.FlightPlanEditorWindow.SelectedFlight.LandingLocation_HostUnitObjectID))
				{
					Interaction.MsgBox("没有设置着陆位置。在战术地图上选择起飞的机场或舰船，按“更改起飞位置”按钮，然后再次尝试创建飞行计划。");
					return false;
				}
			}
		}
		return true;
	}

	private void ReflectPolicy(object sender, EventArgs e)
	{
		try
		{
			if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight) || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
			{
				return;
			}
			if (SelectedFlight.ReferenceUnit_DBID == 0)
			{
				Interaction.MsgBox("在创建飞行计划之前选择飞机和挂载类型。");
			}
			else if (SelectedFlight.int_0 == 0)
			{
				Interaction.MsgBox("在创建飞行计划之前选择挂载类型。");
			}
			else
			{
				if (!PreparePolicy())
				{
					return;
				}
				Aircraft aircraft_ = (Aircraft)SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
				Doctrine._UseShootTourists? shootTourists = SelectedMission.Doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				int num = 6;
				int num2 = 6;
				if (SelectedFlight.DesiredAircraftQty > 6)
				{
					num = SelectedFlight.DesiredAircraftQty;
					num2 = SelectedFlight.MinimumAircraftQty;
					SelectedFlight.DesiredAircraftQty = 6;
					SelectedFlight.MinimumAircraftQty = 6;
				}
				Scenario scenario_ = Client.CurrentScenario;
				Side side_ = Client.CurrentSide;
				Mission selectedMission = SelectedMission;
				Mission.Flight flight_ = SelectedFlight;
				string callsign = SelectedFlight.Callsign;
				Mission._FlightSize desiredAircraftQty = SelectedFlight.DesiredAircraftQty;
				Group group_ = null;
				MissionPlanner.GenerateFlightPlan_ExistingFlight(ref scenario_, ref side_, selectedMission, bool_0: true, bool_1: false, ref flight_, callsign, desiredAircraftQty, ref aircraft_, ref group_, bool_2: true, shootTourists);
				SelectedFlight = flight_;
				Client.CurrentSide = side_;
				List<ActiveUnit> list_ = (from x in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario)
					where Information.IsNothing(x.Navigator.GetFlight())
					select x).ToList();
				if (SelectedFlight.DesiredAircraftQty > num)
				{
					SelectedFlight.DesiredAircraftQty = num;
					SelectedFlight.MinimumAircraftQty = num2;
				}
				PopPolicy(list_);
				LoadWindow();
				if (Client.AirTaskingOrderWindow.Visible)
				{
					Client.AirTaskingOrderWindow.RefreshWindow();
				}
				if (Client.FlightPlanAircraftLoadoutWindow.Visible)
				{
					Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
				}
				if (Client.MissionEditorWindow.Visible)
				{
					Client.MissionEditorWindow.RefreshAssignedUnits();
					Client.MissionEditorWindow.RefreshUnassignedUnits();
				}
				Client.MustRefreshMainForm = true;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
				List<ActiveUnit> list = (from x in (from x in Module_Mission.AssetTokenizer(Client.FlightPlanEditorWindow.SelectedMission, Client.CurrentScenario)
						where !Information.IsNothing(x.Navigator.GetFlight())
						select x).ToList()
					where Operators.CompareString(x.Navigator.GetFlight().Callsign, Client.FlightPlanEditorWindow.SelectedFlight.Callsign, TextCompare: true) == 0
					select x).ToList();
				string text = "";
				foreach (ActiveUnit item in list)
				{
					float num3 = 0f;
					int num4 = item.Navigator.GetFlight().FlightPlan.Count() - 1;
					for (int i = 1; i <= num4; i++)
					{
						num3 += item.Navigator.GetFlight().FlightPlan[i].Leg_Distance_Straight;
					}
					float num5 = item.Kinematics.MaxRange(bool_0: true, null, null);
					if (num3 > num5)
					{
						text = text + Environment.NewLine + "The flightplan distance is " + num3 + " nm while the aircraft " + item.Name + " maximum range is " + num5;
					}
				}
				if (Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					DarkMessageBox.ShowError(text, "ERROR AT LEAST ONE AIRCRAFT WILL CRASH");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ChangeFlightLocation(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, Mission.Flight flight_0, ref string string_0, ref string string_1, ref Module_Unit.Unit unit_0, ref ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_0, bool bool_0, bool bool_1, bool bool_2)
	{
		try
		{
			if (readOnlyCollection_0.Count <= 1)
			{
				if (Information.IsNothing(unit_0))
				{
					Interaction.MsgBox("错误！地图上未选择任何单元。要更改位置，请选择可托管此类型飞机的单个基座或船舶，然后重试。");
					return;
				}
				if (bool_0 && flight_0.GetStatus(scenario_0) != 0)
				{
					Interaction.MsgBox("错误！该编队已经启动，因此无法更改起飞位置！");
					if (!(bool_1 && bool_2))
					{
						return;
					}
					bool_0 = false;
				}
				if (Operators.CompareString(string_1, unit_0.ObjectID, TextCompare: true) == 0)
				{
					return;
				}
				if (unit_0.IsSubmarine)
				{
					Interaction.MsgBox("错误！飞机不能起飞或降落在潜艇上。");
					return;
				}
				if (unit_0.IsGroup)
				{
					Group group = (Group)unit_0;
					if (group.Type == Group.GroupType.SurfaceGroup)
					{
						Interaction.MsgBox("错误！飞机只能在船上起飞或降落，而不能在船编队上起降。");
						return;
					}
					if (group.Type == Group.GroupType.SubGroup)
					{
						Interaction.MsgBox("错误！飞机不能起飞或降落在潜艇上。");
						return;
					}
				}
				if (bool_0)
				{
					List<ActiveUnit> list = new List<ActiveUnit>();
					list.AddRange((from theAU in Module_Mission.AssetTokenizer(mission_0, scenario_0)
						where theAU.Navigator.HasFlight && theAU.IsAircraft && !theAU.IsOperating() && theAU.Navigator.GetFlight() == flight_0
						select theAU).ToList());
					if (list.Count > 0)
					{
						if (Interaction.MsgBox("您已选择更改此编队计划的起飞位置。飞机将从飞行计划中移除，因为它们不在起飞位置，而是由以后可以装满飞机的空槽代替。你要继续吗？", MsgBoxStyle.YesNo) == MsgBoxResult.No)
						{
							return;
						}
						mission_0.ClearAllAircraft_ReplaceWithEmptySlots(ref scenario_0, ref side_0, ref flight_0);
					}
				}
				if (unit_0.IsActiveUnit)
				{
					Aircraft aircraft = (Aircraft)flight_0.GetReferenceUnit(scenario_0);
					bool flag = !unit_0.IsGroup;
					bool flag2 = false;
					bool flag3 = false;
					if (unit_0.IsGroup)
					{
						if (((Group)unit_0).Type == Group.GroupType.AirBase)
						{
							flag3 = true;
						}
						else
						{
							flag2 = true;
						}
					}
					if (Information.IsNothing(aircraft))
					{
						string_0 = unit_0.Name;
						string_1 = unit_0.ObjectID;
					}
					else
					{
						if (flag || flag3)
						{
							if (Operators.CompareString(aircraft.AirOps.ThisUnitCanHostMe((ActiveUnit)unit_0), "OK", TextCompare: true) != 0)
							{
								Interaction.MsgBox("错误！" + unit_0.Name + "不能停靠飞机。要更改位置，请选择可停靠此类型飞机的单个基地或船舶，然后重试。");
								return;
							}
							string_0 = unit_0.Name;
							string_1 = unit_0.ObjectID;
						}
						if (flag2)
						{
							Module_Unit.Unit unit = null;
							foreach (ActiveUnit value in ((Group)unit_0).Units.Values)
							{
								if (Operators.CompareString(aircraft.AirOps.ThisUnitCanHostMe(value), "OK", TextCompare: true) == 0)
								{
									string_0 = unit_0.Name;
									string_1 = unit_0.ObjectID;
									unit = value;
									break;
								}
							}
							if (unit == null)
							{
								Interaction.MsgBox("错误！" + unit_0.Name + "不能停靠飞机。要更改位置，请选择可停靠此类型飞机的单个基地或船舶，然后重试。");
								return;
							}
						}
					}
					if (bool_0)
					{
						if (flight_0.FlightPlan.Count() > 0)
						{
							Waypoint[] flightPlan = flight_0.FlightPlan;
							Waypoint waypoint = null;
							Waypoint waypoint12 = null;
							Waypoint waypoint13 = null;
							Waypoint waypoint14 = null;
							Waypoint waypoint15 = null;
							Waypoint[] array2 = flightPlan;
							Waypoint[] array3 = array2;
							foreach (Waypoint waypoint16 in array3)
							{
								if (waypoint16.Type == Waypoint.WaypointType.Assemble)
								{
									waypoint = waypoint16;
									continue;
								}
								if (waypoint16.Type == Waypoint.WaypointType.HoldStart)
								{
									waypoint12 = waypoint16;
									continue;
								}
								if (waypoint16.Type == Waypoint.WaypointType.HoldEnd)
								{
									waypoint13 = waypoint16;
									continue;
								}
								if (waypoint16.Type == Waypoint.WaypointType.TakeOff)
								{
									waypoint14 = waypoint16;
									continue;
								}
								waypoint15 = waypoint16;
								break;
							}
							if (Information.IsNothing(waypoint14))
							{
								Interaction.MsgBox("错误！在飞行计划中找不到起飞航点！");
								return;
							}
							waypoint14.Latitude = unit_0.GetLatitude();
							waypoint14.Longitude = unit_0.GetLongitude();
							if (!Information.IsNothing(waypoint15))
							{
								float num = Math2.VerifyClass(waypoint14.Latitude, waypoint14.Longitude, waypoint15.Latitude, waypoint15.Longitude);
								float num2 = Math2.PublishClass(waypoint14.Latitude, waypoint14.Longitude, waypoint15.Latitude, waypoint15.Longitude);
								float num3 = GameGeneral.LockRandom_0.Next(-45, 45);
								if (Information.IsNothing(waypoint))
								{
									if (!Information.IsNothing(waypoint12) && !Information.IsNothing(waypoint13))
									{
										if (num <= 30f)
										{
											double longitude = waypoint14.Longitude;
											double latitude = waypoint14.Latitude;
											Waypoint waypoint17 = waypoint12;
											double double_ = waypoint17.Longitude;
											Waypoint waypoint18;
											double double_2 = (waypoint18 = waypoint12).Latitude;
											Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref double_, ref double_2, 10f, Math2.UpdateClass(num2 + 180f + num3));
											waypoint18.Latitude = double_2;
											waypoint17.Longitude = double_;
											double longitude2 = waypoint14.Longitude;
											double latitude2 = waypoint14.Latitude;
											double_2 = (waypoint18 = waypoint13).Longitude;
											Waypoint waypoint19 = waypoint13;
											double_ = waypoint19.Latitude;
											Geodesic_EdWilliams.CalcPoint_Williams(longitude2, latitude2, ref double_2, ref double_, 20f, Math2.UpdateClass(num2 + 180f + num3));
											waypoint19.Latitude = double_;
											waypoint18.Longitude = double_2;
										}
										else
										{
											double longitude3 = waypoint14.Longitude;
											double latitude3 = waypoint14.Latitude;
											Waypoint waypoint2 = waypoint12;
											double double_3 = waypoint2.Longitude;
											Waypoint waypoint3;
											double double_4 = (waypoint3 = waypoint12).Latitude;
											Geodesic_EdWilliams.CalcPoint_Williams(longitude3, latitude3, ref double_3, ref double_4, 10f, Math2.UpdateClass(num2 + num3));
											waypoint3.Latitude = double_4;
											waypoint2.Longitude = double_3;
											float float_ = Math2.PublishClass(waypoint12.Latitude, waypoint12.Longitude, waypoint15.Latitude, waypoint15.Longitude);
											double longitude4 = waypoint12.Longitude;
											double latitude4 = waypoint12.Latitude;
											double_4 = (waypoint3 = waypoint13).Longitude;
											Waypoint waypoint4 = waypoint13;
											double_3 = waypoint4.Latitude;
											Geodesic_EdWilliams.CalcPoint_Williams(longitude4, latitude4, ref double_4, ref double_3, 10f, Math2.UpdateClass(float_));
											waypoint4.Latitude = double_3;
											waypoint3.Longitude = double_4;
										}
									}
								}
								else if (num <= 15f)
								{
									double longitude5 = waypoint14.Longitude;
									double latitude5 = waypoint14.Latitude;
									Waypoint waypoint5;
									double double_5 = (waypoint5 = waypoint).Longitude;
									Waypoint waypoint6 = waypoint;
									double double_6 = waypoint6.Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(longitude5, latitude5, ref double_5, ref double_6, 10f, Math2.UpdateClass(num2 + 180f + num3));
									waypoint6.Latitude = double_6;
									waypoint5.Longitude = double_5;
								}
								else
								{
									double longitude6 = waypoint14.Longitude;
									double latitude6 = waypoint14.Latitude;
									Waypoint waypoint7;
									double double_7 = (waypoint7 = waypoint).Longitude;
									Waypoint waypoint8 = waypoint;
									double double_8 = waypoint8.Latitude;
									Geodesic_EdWilliams.CalcPoint_Williams(longitude6, latitude6, ref double_7, ref double_8, 10f, Math2.UpdateClass(num2 + num3));
									waypoint8.Latitude = double_8;
									waypoint7.Longitude = double_7;
								}
							}
						}
						if (!Information.IsNothing(mission_0.EmptySlotsList))
						{
							for (int i = mission_0.EmptySlotsList.Count - 1; i >= 0; i += -1)
							{
								Mission.EmptyAircraftSlot emptyAircraftSlot = mission_0.EmptySlotsList[i];
								if (Operators.CompareString(emptyAircraftSlot.MissionFlight_ObjectID, flight_0.ObjectID, TextCompare: true) == 0)
								{
									emptyAircraftSlot.SetCurrentHostUnit(scenario_0, (ActiveUnit)unit_0);
									emptyAircraftSlot.CurrentHostUnit_Name = unit_0.Name;
									emptyAircraftSlot.CurrentHostUnit_ObjectID = unit_0.ObjectID;
								}
							}
						}
						flight_0.SetReferenceUnit(scenario_0, null);
					}
					if (bool_1 && flight_0.FlightPlan.Count() > 0)
					{
						Waypoint[] flightPlan2 = flight_0.FlightPlan;
						Waypoint waypoint9 = null;
						Waypoint waypoint10 = null;
						Waypoint[] array = flightPlan2;
						Waypoint[] array4 = array;
						foreach (Waypoint waypoint11 in array4)
						{
							if (waypoint11.Type == Waypoint.WaypointType.LandingMarshal)
							{
								waypoint9 = waypoint11;
							}
							else if (waypoint11.Type == Waypoint.WaypointType.Land)
							{
								waypoint10 = waypoint11;
								break;
							}
						}
						if (Information.IsNothing(waypoint10))
						{
							Interaction.MsgBox("错误！在飞行计划中找不到陆地航点！");
							return;
						}
						waypoint10.Latitude = unit_0.GetLatitude();
						waypoint10.Longitude = unit_0.GetLongitude();
						if (!aircraft.IsHelicopter && !Information.IsNothing(waypoint9))
						{
							Geopoint_Struct landingQueueAssemblyPoint = ((ActiveUnit)unit_0).AirOps.LandingQueueAssemblyPoint;
							waypoint9.Latitude = landingQueueAssemblyPoint.Latitude;
							waypoint9.Longitude = landingQueueAssemblyPoint.Longitude;
						}
						List<ActiveUnit> list2 = new List<ActiveUnit>();
						list2.AddRange((from theAU in Module_Mission.AssetTokenizer(mission_0, scenario_0)
							where theAU.Navigator.HasFlight && theAU.IsAircraft && theAU.IsOperating() && theAU.Navigator.GetFlight() == flight_0
							select theAU).ToList());
						foreach (Aircraft item in list2)
						{
							if (Operators.CompareString(flight_0.LandingLocation_HostUnitObjectID, item.AirOps.GetAssignedHostUnit().ObjectID, TextCompare: true) != 0)
							{
								if (scenario_0.ActiveUnits.ContainsKey(flight_0.LandingLocation_HostUnitObjectID))
								{
									item.AirOps.SetAssignedHostUnit(bool_0: false, scenario_0.ActiveUnits[flight_0.LandingLocation_HostUnitObjectID]);
								}
								else if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
							}
						}
					}
					Scenario scenario_ = scenario_0;
					Mission strike_ = mission_0;
					ActiveUnit referenceUnit = flight_0.GetReferenceUnit(scenario_0);
					Mission.Flight flight;
					Waypoint[] waypoint_ = (flight = flight_0).FlightPlan;
					float float_2 = 0f;
					float float_3 = 0f;
					MissionPlanner.ConnectTokenizer(scenario_, strike_, referenceUnit, flight_0, ref waypoint_, ref float_2, ref float_3, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
					flight.FlightPlan = waypoint_;
				}
				else
				{
					Interaction.MsgBox("错误！地图上未选择任何单元。要更改位置，请选择可托管此类型飞机的单个基座或船舶，然后重试。");
				}
			}
			else
			{
				Interaction.MsgBox("错误！已选择地图上的多个单元。要更改位置，请选择可托管此类型飞机的单个基座或船舶，然后重试。");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void VisitPolicy(object object_0)
	{
		if (!tokenizerTask)
		{
			tokenizerTask = true;
			int num = 1;
			while (RestartPolicy() && Operators.CompareString(TextBox_FlightCallsign.Text, "新编队", TextCompare: true) == 0)
			{
				TextBox_FlightCallsign.Text = "New Flight " + num;
			}
			if (RestartPolicy())
			{
				DarkMessageBox.ShowError("Flight witth such name already exists", "wrong flight name");
			}
			tokenizerTask = false;
		}
	}

	private bool RestartPolicy()
	{
		foreach (Mission.Flight flight in SelectedMission.FlightList)
		{
			if (flight != SelectedFlight && Operators.CompareString(flight.Callsign, TextBox_FlightCallsign.Text, TextCompare: true) == 0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private bool TestPolicy(ActiveUnit activeUnit_0)
	{
		return Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, SelectedFlight.Callsign, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool StopPolicy(ActiveUnit activeUnit_0)
	{
		return Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, SelectedFlight.Callsign, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool CancelPolicy(ActiveUnit activeUnit_0)
	{
		return Operators.CompareString(activeUnit_0.Navigator.GetFlight().Callsign, SelectedFlight.Callsign, TextCompare: true) == 0;
	}
}
