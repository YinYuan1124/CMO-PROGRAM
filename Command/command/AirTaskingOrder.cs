using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AirTaskingOrder : DarkSecondaryFormBase
{
	public enum AirTaskingOrderSortType : byte
	{
		MissionOrPackageName_TakeOffTime_Task_Aircraft_Loadout,
		TakeOffTime_Task_Aircraft_Loadout,
		ObjectiveTime_Task_Aircraft_Loadout
	}

	[CompilerGenerated]
	private sealed class AttributeMerchantService
	{
		public Mission.Flight Local_theFlight;

		internal bool RestartInterruptibleParam(Mission theM)
		{
			return Operators.CompareString(theM.Name, Local_theFlight.ParentMissionOrPackageName, TextCompare: true) == 0;
		}
	}

	private IContainer m_StructRepository;

	[AccessedThroughProperty("DGV_AirTaskingOrder")]
	[CompilerGenerated]
	private DarkDataGridView merchantRepository;

	[AccessedThroughProperty("ComboBox_PlannedFlightPlanVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox decoratorRepository;

	[AccessedThroughProperty("Button_CreateFlight")]
	[CompilerGenerated]
	private DarkUIButton _ProcessRepository;

	[AccessedThroughProperty("Button_FlightPlanEditor")]
	[CompilerGenerated]
	private DarkUIButton _ThreadRepository;

	[AccessedThroughProperty("Button_ChangeAircraftType")]
	[CompilerGenerated]
	private DarkUIButton m_RuleRepository;

	[AccessedThroughProperty("Button_DeleteFlight")]
	[CompilerGenerated]
	private DarkUIButton _CollectionRepository;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel instanceRepository;

	[AccessedThroughProperty("ComboBox_AirborneFlightPlanVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox m_ObjectRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CopyFlight")]
	private DarkUIButton _ParameterRepository;

	[AccessedThroughProperty("Button_ChangeTakeOffTime")]
	[CompilerGenerated]
	private DarkUIButton m_ExpressionRepository;

	[AccessedThroughProperty("Button_ChangeObjectiveTime")]
	[CompilerGenerated]
	private DarkUIButton _DispatcherRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearTime")]
	private DarkUIButton _ListenerRepository;

	[AccessedThroughProperty("ComboBox_AirTaskingOrderSorting")]
	[CompilerGenerated]
	private DarkUIComboBox m_ConfigRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_AirTaskingOrderFilter")]
	private DarkUIComboBox _RegistryRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private DarkLabel definitionRepository;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel valRepository;

	[AccessedThroughProperty("MissionOrPackage")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ObserverRepository;

	[AccessedThroughProperty("Task")]
	[CompilerGenerated]
	private DataGridViewComboBoxColumn consumerRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("AircraftType")]
	private DataGridViewTextBoxColumn m_FacadeRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("TakeOffTimeFixed")]
	private DataGridViewTextBoxColumn importerRepository;

	[AccessedThroughProperty("TakeOffTimeImg")]
	[CompilerGenerated]
	private DataGridViewImageColumn repositoryRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("ObjectiveTimeFixed")]
	private DataGridViewTextBoxColumn classRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("ObjectiveTimeImg")]
	private DataGridViewImageColumn requestRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("TakeOffLocation")]
	private DataGridViewTextBoxColumn valueRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("LandingLocation")]
	private DataGridViewTextBoxColumn tokenizerRepository;

	[AccessedThroughProperty("AlternativeLandingLocation")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn stubRepository;

	[AccessedThroughProperty("DesiredAircraftQty")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn writerRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("MinimumAircraftQty")]
	private DataGridViewTextBoxColumn m_SpecificationRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("AssignedAircraftQty")]
	private DataGridViewTextBoxColumn watcherRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("ReadyAircraftQty")]
	private DataGridViewTextBoxColumn reponseRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("EditedBy")]
	private DataGridViewTextBoxColumn taskRepository;

	public Mission SelectedMission;

	public Mission.Flight SelectedFlight;

	public List<Mission.Flight> SelectedFlightsList;

	private bool _FilterRepository;

	private string m_TestsRepository;

	private int interpreterRepository;

	private DataTable _ContainerRepository;

	private AirTaskingOrderSortType m_ComposerRepository;

	public string AirTaskingOrderFilterSetting;

	private int modelRepository;

	private int m_AdvisorRepository;

	private int _CustomerRepository;

	private int _SerializerRepository;

	private int m_RefRepository;

	private int _ErrorRepository;

	private int _CodeRepository;

	private int _ConnectionRepository;

	private int m_ContextRepository;

	private int m_StatusRepository;

	private int m_ProccesorRepository;

	private int m_StrategyRepository;

	private int configurationRepository;

	private int m_TokenRepository;

	private int indexerRepository;

	private int resolverRepository;

	private int m_PublisherRepository;

	private int m_ServerRepository;

	private int m_AdapterRepository;

	private int schemaRepository;

	private int utilsRepository;

	private int predicateRepository;

	private int m_SingletonRepository;

	private int m_RecordRepository;

	private int exceptionRepository;

	private int m_AttrRepository;

	private Bitmap _VisitorRepository;

	private Bitmap exporterRepository;

	private Bitmap m_PrototypeRepository;

	private Bitmap _ComparatorRepository;

	private Bitmap m_ItemRepository;

	internal DarkDataGridView DGV_AirTaskingOrder
	{
		[CompilerGenerated]
		get
		{
			return merchantRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellPaintingEventHandler value2 = InvokeAdvisor;
			DataGridViewCellEventHandler value3 = SetupAdvisor;
			DataGridViewCellEventHandler value4 = ExcludeAdvisor;
			EventHandler value5 = IncludeAdvisor;
			EventHandler value6 = ChangeAdvisor;
			DarkDataGridView darkDataGridView = merchantRepository;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellPainting -= value2;
				darkDataGridView.CellClick -= value3;
				darkDataGridView.CellValueChanged -= value4;
				darkDataGridView.CurrentCellDirtyStateChanged -= value5;
				darkDataGridView.SelectionChanged -= value6;
			}
			merchantRepository = value;
			darkDataGridView = merchantRepository;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellPainting += value2;
				darkDataGridView.CellClick += value3;
				darkDataGridView.CellValueChanged += value4;
				darkDataGridView.CurrentCellDirtyStateChanged += value5;
				darkDataGridView.SelectionChanged += value6;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox ComboBox_PlannedFlightPlanVisibility
	{
		[CompilerGenerated]
		get
		{
			return decoratorRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveAdvisor;
			DarkUIComboBox darkUIComboBox = decoratorRepository;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			decoratorRepository = value;
			darkUIComboBox = decoratorRepository;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIButton Button_CreateFlight
	{
		[CompilerGenerated]
		get
		{
			return _ProcessRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitAdvisor;
			DarkUIButton processRepository = _ProcessRepository;
			if (processRepository != null)
			{
				processRepository.Click -= value2;
			}
			_ProcessRepository = value;
			processRepository = _ProcessRepository;
			if (processRepository != null)
			{
				processRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_FlightPlanEditor
	{
		[CompilerGenerated]
		get
		{
			return _ThreadRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableAdvisor;
			DarkUIButton threadRepository = _ThreadRepository;
			if (threadRepository != null)
			{
				threadRepository.Click -= value2;
			}
			_ThreadRepository = value;
			threadRepository = _ThreadRepository;
			if (threadRepository != null)
			{
				threadRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ChangeAircraftType
	{
		[CompilerGenerated]
		get
		{
			return m_RuleRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillAdvisor;
			DarkUIButton ruleRepository = m_RuleRepository;
			if (ruleRepository != null)
			{
				ruleRepository.Click -= value2;
			}
			m_RuleRepository = value;
			ruleRepository = m_RuleRepository;
			if (ruleRepository != null)
			{
				ruleRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_DeleteFlight
	{
		[CompilerGenerated]
		get
		{
			return _CollectionRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptAdvisor;
			DarkUIButton collectionRepository = _CollectionRepository;
			if (collectionRepository != null)
			{
				collectionRepository.Click -= value2;
			}
			_CollectionRepository = value;
			collectionRepository = _CollectionRepository;
			if (collectionRepository != null)
			{
				collectionRepository.Click += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return instanceRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			instanceRepository = value;
		}
	}

	internal DarkUIComboBox ComboBox_AirborneFlightPlanVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetAdvisor;
			DarkUIComboBox objectRepository = m_ObjectRepository;
			if (objectRepository != null)
			{
				objectRepository.SelectionChangeCommitted -= value2;
			}
			m_ObjectRepository = value;
			objectRepository = m_ObjectRepository;
			if (objectRepository != null)
			{
				objectRepository.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIButton Button_CopyFlight
	{
		[CompilerGenerated]
		get
		{
			return _ParameterRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatAdvisor;
			DarkUIButton parameterRepository = _ParameterRepository;
			if (parameterRepository != null)
			{
				parameterRepository.Click -= value2;
			}
			_ParameterRepository = value;
			parameterRepository = _ParameterRepository;
			if (parameterRepository != null)
			{
				parameterRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ChangeTakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return m_ExpressionRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateAdvisor;
			DarkUIButton expressionRepository = m_ExpressionRepository;
			if (expressionRepository != null)
			{
				expressionRepository.Click -= value2;
			}
			m_ExpressionRepository = value;
			expressionRepository = m_ExpressionRepository;
			if (expressionRepository != null)
			{
				expressionRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ChangeObjectiveTime
	{
		[CompilerGenerated]
		get
		{
			return _DispatcherRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopAdvisor;
			DarkUIButton dispatcherRepository = _DispatcherRepository;
			if (dispatcherRepository != null)
			{
				dispatcherRepository.Click -= value2;
			}
			_DispatcherRepository = value;
			dispatcherRepository = _DispatcherRepository;
			if (dispatcherRepository != null)
			{
				dispatcherRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ClearTime
	{
		[CompilerGenerated]
		get
		{
			return _ListenerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateAdvisor;
			DarkUIButton listenerRepository = _ListenerRepository;
			if (listenerRepository != null)
			{
				listenerRepository.Click -= value2;
			}
			_ListenerRepository = value;
			listenerRepository = _ListenerRepository;
			if (listenerRepository != null)
			{
				listenerRepository.Click += value2;
			}
		}
	}

	internal DarkUIComboBox ComboBox_AirTaskingOrderSorting
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareAdvisor;
			DarkUIComboBox configRepository = m_ConfigRepository;
			if (configRepository != null)
			{
				configRepository.SelectionChangeCommitted -= value2;
			}
			m_ConfigRepository = value;
			configRepository = m_ConfigRepository;
			if (configRepository != null)
			{
				configRepository.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox ComboBox_AirTaskingOrderFilter
	{
		[CompilerGenerated]
		get
		{
			return _RegistryRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateAdvisor;
			DarkUIComboBox registryRepository = _RegistryRepository;
			if (registryRepository != null)
			{
				registryRepository.SelectionChangeCommitted -= value2;
			}
			_RegistryRepository = value;
			registryRepository = _RegistryRepository;
			if (registryRepository != null)
			{
				registryRepository.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return definitionRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			definitionRepository = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return valRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valRepository = value;
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal DataGridViewTextBoxColumn ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn MissionOrPackage
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObserverRepository = value;
		}
	}

	[field: AccessedThroughProperty("Callsign")]
	internal DataGridViewTextBoxColumn Callsign
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Type")]
	internal DataGridViewComboBoxColumn Type
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Status")]
	internal DataGridViewTextBoxColumn Status
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewComboBoxColumn Task
	{
		[CompilerGenerated]
		get
		{
			return consumerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			consumerRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn AircraftType
	{
		[CompilerGenerated]
		get
		{
			return m_FacadeRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FacadeRepository = value;
		}
	}

	[field: AccessedThroughProperty("LoadoutType")]
	internal DataGridViewTextBoxColumn LoadoutType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TakeOffTimeZulu")]
	internal DataGridViewTextBoxColumn TakeOffTimeZulu
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TakeOffTimeLocal")]
	internal DataGridViewTextBoxColumn TakeOffTimeLocal
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn TakeOffTimeFixed
	{
		[CompilerGenerated]
		get
		{
			return importerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			importerRepository = value;
		}
	}

	internal DataGridViewImageColumn TakeOffTimeImg
	{
		[CompilerGenerated]
		get
		{
			return repositoryRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			repositoryRepository = value;
		}
	}

	[field: AccessedThroughProperty("ObjectiveTimeZulu")]
	internal DataGridViewTextBoxColumn ObjectiveTimeZulu
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ObjectiveTimeLocal")]
	internal DataGridViewTextBoxColumn ObjectiveTimeLocal
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn ObjectiveTimeFixed
	{
		[CompilerGenerated]
		get
		{
			return classRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			classRepository = value;
		}
	}

	internal DataGridViewImageColumn ObjectiveTimeImg
	{
		[CompilerGenerated]
		get
		{
			return requestRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			requestRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn TakeOffLocation
	{
		[CompilerGenerated]
		get
		{
			return valueRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valueRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn LandingLocation
	{
		[CompilerGenerated]
		get
		{
			return tokenizerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenizerRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn AlternativeLandingLocation
	{
		[CompilerGenerated]
		get
		{
			return stubRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stubRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn DesiredAircraftQty
	{
		[CompilerGenerated]
		get
		{
			return writerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			writerRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn MinimumAircraftQty
	{
		[CompilerGenerated]
		get
		{
			return m_SpecificationRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SpecificationRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn AssignedAircraftQty
	{
		[CompilerGenerated]
		get
		{
			return watcherRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			watcherRepository = value;
		}
	}

	internal DataGridViewTextBoxColumn ReadyAircraftQty
	{
		[CompilerGenerated]
		get
		{
			return reponseRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			reponseRepository = value;
		}
	}

	[field: AccessedThroughProperty("Priority")]
	internal DataGridViewComboBoxColumn Priority
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CreatedBy")]
	internal DataGridViewTextBoxColumn CreatedBy
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn EditedBy
	{
		[CompilerGenerated]
		get
		{
			return taskRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			taskRepository = value;
		}
	}

	public AirTaskingOrder()
	{
		base.FormClosing += SelectAdvisor;
		base.FormClosed += CallAdvisor;
		base.Load += LogoutAdvisor;
		base.VisibleChanged += ValidateAdvisor;
		base.KeyDown += FindAdvisor;
		SelectedFlightsList = new List<Mission.Flight>();
		_FilterRepository = true;
		m_TestsRepository = "";
		interpreterRepository = 0;
		_ContainerRepository = new DataTable();
		m_ComposerRepository = AirTaskingOrderSortType.MissionOrPackageName_TakeOffTime_Task_Aircraft_Loadout;
		AirTaskingOrderFilterSetting = "";
		_VisitorRepository = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Locked_16.png");
		exporterRepository = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Unlocked_16.png");
		m_PrototypeRepository = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotConfigured_16.png");
		_ComparatorRepository = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotLockable_16.png");
		m_ItemRepository = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Relative_16.png");
		ComputeAdvisor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_StructRepository != null)
			{
				m_StructRepository.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ComputeAdvisor()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		Button_DeleteFlight = new DarkUIButton();
		Button_ChangeAircraftType = new DarkUIButton();
		Button_FlightPlanEditor = new DarkUIButton();
		Button_CreateFlight = new DarkUIButton();
		ComboBox_AirborneFlightPlanVisibility = new DarkUIComboBox();
		ComboBox_PlannedFlightPlanVisibility = new DarkUIComboBox();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		DGV_AirTaskingOrder = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		MissionOrPackage = new DataGridViewTextBoxColumn();
		Callsign = new DataGridViewTextBoxColumn();
		Type = new DataGridViewComboBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		Task = new DataGridViewComboBoxColumn();
		AircraftType = new DataGridViewTextBoxColumn();
		LoadoutType = new DataGridViewTextBoxColumn();
		TakeOffTimeZulu = new DataGridViewTextBoxColumn();
		TakeOffTimeLocal = new DataGridViewTextBoxColumn();
		TakeOffTimeFixed = new DataGridViewTextBoxColumn();
		TakeOffTimeImg = new DataGridViewImageColumn();
		ObjectiveTimeZulu = new DataGridViewTextBoxColumn();
		ObjectiveTimeLocal = new DataGridViewTextBoxColumn();
		ObjectiveTimeFixed = new DataGridViewTextBoxColumn();
		ObjectiveTimeImg = new DataGridViewImageColumn();
		TakeOffLocation = new DataGridViewTextBoxColumn();
		LandingLocation = new DataGridViewTextBoxColumn();
		AlternativeLandingLocation = new DataGridViewTextBoxColumn();
		DesiredAircraftQty = new DataGridViewTextBoxColumn();
		MinimumAircraftQty = new DataGridViewTextBoxColumn();
		AssignedAircraftQty = new DataGridViewTextBoxColumn();
		ReadyAircraftQty = new DataGridViewTextBoxColumn();
		Priority = new DataGridViewComboBoxColumn();
		CreatedBy = new DataGridViewTextBoxColumn();
		EditedBy = new DataGridViewTextBoxColumn();
		Button_CopyFlight = new DarkUIButton();
		Button_ChangeTakeOffTime = new DarkUIButton();
		Button_ChangeObjectiveTime = new DarkUIButton();
		Button_ClearTime = new DarkUIButton();
		ComboBox_AirTaskingOrderSorting = new DarkUIComboBox();
		ComboBox_AirTaskingOrderFilter = new DarkUIComboBox();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		((ISupportInitialize)DGV_AirTaskingOrder).BeginInit();
		SuspendLayout();
		Button_DeleteFlight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_DeleteFlight.BackColor = Color.Transparent;
		Button_DeleteFlight.DialogResult = DialogResult.None;
		Button_DeleteFlight.ForeColor = SystemColors.Control;
		Button_DeleteFlight.Location = new Point(297, 631);
		Button_DeleteFlight.Name = "Button_DeleteFlight";
		Button_DeleteFlight.RoundRadius = 0;
		Button_DeleteFlight.Size = new Size(146, 28);
		Button_DeleteFlight.TabIndex = 15;
		Button_DeleteFlight.Text = "删除编队";
		Button_ChangeAircraftType.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ChangeAircraftType.BackColor = Color.Transparent;
		Button_ChangeAircraftType.DialogResult = DialogResult.None;
		Button_ChangeAircraftType.ForeColor = SystemColors.Control;
		Button_ChangeAircraftType.Location = new Point(3, 660);
		Button_ChangeAircraftType.Name = "Button_ChangeAircraftType";
		Button_ChangeAircraftType.RoundRadius = 0;
		Button_ChangeAircraftType.Size = new Size(172, 28);
		Button_ChangeAircraftType.TabIndex = 14;
		Button_ChangeAircraftType.Text = "改变飞机类型和挂载";
		Button_FlightPlanEditor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_FlightPlanEditor.BackColor = Color.Transparent;
		Button_FlightPlanEditor.DialogResult = DialogResult.None;
		Button_FlightPlanEditor.ForeColor = SystemColors.Control;
		Button_FlightPlanEditor.Location = new Point(444, 631);
		Button_FlightPlanEditor.Name = "Button_FlightPlanEditor";
		Button_FlightPlanEditor.RoundRadius = 0;
		Button_FlightPlanEditor.Size = new Size(146, 28);
		Button_FlightPlanEditor.TabIndex = 13;
		Button_FlightPlanEditor.Text = "编辑飞行计划";
		Button_CreateFlight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_CreateFlight.BackColor = Color.Transparent;
		Button_CreateFlight.DialogResult = DialogResult.None;
		Button_CreateFlight.ForeColor = SystemColors.Control;
		Button_CreateFlight.Location = new Point(3, 631);
		Button_CreateFlight.Name = "Button_CreateFlight";
		Button_CreateFlight.RoundRadius = 0;
		Button_CreateFlight.Size = new Size(146, 28);
		Button_CreateFlight.TabIndex = 12;
		Button_CreateFlight.Text = "创建编队";
		ComboBox_AirborneFlightPlanVisibility.BackColor = Color.Transparent;
		ComboBox_AirborneFlightPlanVisibility.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_AirborneFlightPlanVisibility.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_AirborneFlightPlanVisibility.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_AirborneFlightPlanVisibility.FormattingEnabled = true;
		ComboBox_AirborneFlightPlanVisibility.Items.AddRange(new object[3] { "所有", "所选单元", "不显示" });
		ComboBox_AirborneFlightPlanVisibility.Location = new Point(787, 3);
		ComboBox_AirborneFlightPlanVisibility.Name = "ComboBox_AirborneFlightPlanVisibility";
		ComboBox_AirborneFlightPlanVisibility.Size = new Size(214, 21);
		ComboBox_AirborneFlightPlanVisibility.TabIndex = 11;
		ComboBox_PlannedFlightPlanVisibility.BackColor = Color.Transparent;
		ComboBox_PlannedFlightPlanVisibility.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_PlannedFlightPlanVisibility.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_PlannedFlightPlanVisibility.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_PlannedFlightPlanVisibility.FormattingEnabled = true;
		ComboBox_PlannedFlightPlanVisibility.Items.AddRange(new object[5] { "所有", "所选任务池（或任务）", "所选任务包（或任务）", "所选编队", "不显示" });
		ComboBox_PlannedFlightPlanVisibility.Location = new Point(787, 26);
		ComboBox_PlannedFlightPlanVisibility.Name = "ComboBox_PlannedFlightPlanVisibility";
		ComboBox_PlannedFlightPlanVisibility.Size = new Size(214, 21);
		ComboBox_PlannedFlightPlanVisibility.TabIndex = 11;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(554, 7);
		Label2.Name = "Label2";
		Label2.Size = new Size(230, 15);
		Label2.TabIndex = 10;
		Label2.Text = "在战术地图上显示进行中的飞行计划：";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(554, 30);
		Label1.Name = "Label1";
		Label1.Size = new Size(229, 15);
		Label1.TabIndex = 10;
		Label1.Text = "在战术地图上显示计划的飞行计划：";
		DGV_AirTaskingOrder.AllowUserToAddRows = false;
		DGV_AirTaskingOrder.AllowUserToDeleteRows = false;
		DGV_AirTaskingOrder.AllowUserToResizeRows = false;
		DGV_AirTaskingOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_AirTaskingOrder.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_AirTaskingOrder.BorderStyle = BorderStyle.None;
		DGV_AirTaskingOrder.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_AirTaskingOrder.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_AirTaskingOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_AirTaskingOrder.ColumnHeadersHeight = 18;
		DGV_AirTaskingOrder.Columns.AddRange(ID, MissionOrPackage, Callsign, Type, Status, Task, AircraftType, LoadoutType, TakeOffTimeZulu, TakeOffTimeLocal, TakeOffTimeFixed, TakeOffTimeImg, ObjectiveTimeZulu, ObjectiveTimeLocal, ObjectiveTimeFixed, ObjectiveTimeImg, TakeOffLocation, LandingLocation, AlternativeLandingLocation, DesiredAircraftQty, MinimumAircraftQty, AssignedAircraftQty, ReadyAircraftQty, Priority, CreatedBy, EditedBy);
		DGV_AirTaskingOrder.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_AirTaskingOrder.EnableHeadersVisualStyles = false;
		DGV_AirTaskingOrder.Location = new Point(0, 53);
		DGV_AirTaskingOrder.Name = "DGV_AirTaskingOrder";
		DGV_AirTaskingOrder.RowHeadersVisible = false;
		DGV_AirTaskingOrder.RowHeadersWidth = 10;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.LightGray;
		DGV_AirTaskingOrder.RowsDefaultCellStyle = dataGridViewCellStyle2;
		DGV_AirTaskingOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_AirTaskingOrder.Size = new Size(1008, 576);
		DGV_AirTaskingOrder.TabIndex = 9;
		ID.DataPropertyName = "ID";
		ID.Frozen = true;
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.Visible = false;
		MissionOrPackage.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		MissionOrPackage.DataPropertyName = "MissionOrPackage";
		MissionOrPackage.Frozen = true;
		MissionOrPackage.HeaderText = "任务/任务包";
		MissionOrPackage.Name = "MissionOrPackage";
		MissionOrPackage.Width = 120;
		Callsign.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Callsign.DataPropertyName = "Callsign";
		Callsign.Frozen = true;
		Callsign.HeaderText = "编队呼号";
		Callsign.Name = "Callsign";
		Callsign.Width = 105;
		Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Type.DataPropertyName = "Type";
		Type.FlatStyle = FlatStyle.Flat;
		Type.HeaderText = "类型";
		Type.Name = "Type";
		Type.SortMode = DataGridViewColumnSortMode.Automatic;
		Type.Width = 55;
		Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Status.DataPropertyName = "Status";
		Status.HeaderText = "状态";
		Status.Name = "Status";
		Status.Width = 62;
		Task.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Task.DataPropertyName = "Task";
		Task.FlatStyle = FlatStyle.Flat;
		Task.HeaderText = "任务";
		Task.Name = "Task";
		Task.Resizable = DataGridViewTriState.True;
		Task.SortMode = DataGridViewColumnSortMode.Automatic;
		Task.Width = 53;
		AircraftType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		AircraftType.DataPropertyName = "AircraftType";
		AircraftType.HeaderText = "飞机类型";
		AircraftType.Name = "AircraftType";
		AircraftType.ReadOnly = true;
		AircraftType.Width = 97;
		LoadoutType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		LoadoutType.DataPropertyName = "LoadoutType";
		LoadoutType.HeaderText = "挂载类型";
		LoadoutType.Name = "LoadoutType";
		LoadoutType.Width = 102;
		TakeOffTimeZulu.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		TakeOffTimeZulu.DataPropertyName = "TakeOffTimeZulu";
		TakeOffTimeZulu.HeaderText = "祖鲁起飞时间";
		TakeOffTimeZulu.Name = "TakeOffTimeZulu";
		TakeOffTimeZulu.Width = 133;
		TakeOffTimeLocal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		TakeOffTimeLocal.DataPropertyName = "TakeOffTimeLocal";
		TakeOffTimeLocal.HeaderText = "本地起飞时间";
		TakeOffTimeLocal.Name = "TakeOffTimeLocal";
		TakeOffTimeLocal.Width = 137;
		TakeOffTimeFixed.DataPropertyName = "TakeOffTimeFixed";
		TakeOffTimeFixed.HeaderText = "修改后起飞时间";
		TakeOffTimeFixed.Name = "TakeOffTimeFixed";
		TakeOffTimeFixed.Visible = false;
		TakeOffTimeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		TakeOffTimeImg.DataPropertyName = "TakeOffTimeImg";
		TakeOffTimeImg.HeaderText = "";
		TakeOffTimeImg.Name = "TakeOffTimeImg";
		TakeOffTimeImg.Resizable = DataGridViewTriState.True;
		TakeOffTimeImg.SortMode = DataGridViewColumnSortMode.Automatic;
		TakeOffTimeImg.Width = 5;
		ObjectiveTimeZulu.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ObjectiveTimeZulu.DataPropertyName = "ObjectiveTimeZulu";
		ObjectiveTimeZulu.HeaderText = "到达目标时间（祖鲁）";
		ObjectiveTimeZulu.Name = "ObjectiveTimeZulu";
		ObjectiveTimeZulu.Width = 137;
		ObjectiveTimeLocal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ObjectiveTimeLocal.DataPropertyName = "ObjectiveTimeLocal";
		ObjectiveTimeLocal.HeaderText = "到达目标时间（本地）";
		ObjectiveTimeLocal.Name = "ObjectiveTimeLocal";
		ObjectiveTimeLocal.Width = 141;
		ObjectiveTimeFixed.DataPropertyName = "ObjectiveTimeFixed";
		ObjectiveTimeFixed.HeaderText = "修改后到达时间";
		ObjectiveTimeFixed.Name = "ObjectiveTimeFixed";
		ObjectiveTimeFixed.Visible = false;
		ObjectiveTimeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		ObjectiveTimeImg.DataPropertyName = "ObjectiveTimeImg";
		ObjectiveTimeImg.HeaderText = "";
		ObjectiveTimeImg.Name = "ObjectiveTimeImg";
		ObjectiveTimeImg.Resizable = DataGridViewTriState.True;
		ObjectiveTimeImg.SortMode = DataGridViewColumnSortMode.Automatic;
		ObjectiveTimeImg.Width = 5;
		TakeOffLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		TakeOffLocation.DataPropertyName = "TakeOffLocation";
		TakeOffLocation.HeaderText = "起飞位置";
		TakeOffLocation.Name = "TakeOffLocation";
		TakeOffLocation.Width = 123;
		LandingLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		LandingLocation.DataPropertyName = "LandingLocation";
		LandingLocation.HeaderText = "着陆地点";
		LandingLocation.Name = "LandingLocation";
		LandingLocation.Width = 122;
		AlternativeLandingLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		AlternativeLandingLocation.DataPropertyName = "AlternativeLandingLocation";
		AlternativeLandingLocation.HeaderText = "转移位置";
		AlternativeLandingLocation.Name = "AlternativeLandingLocation";
		AlternativeLandingLocation.Width = 128;
		DesiredAircraftQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DesiredAircraftQty.DataPropertyName = "DesiredAircraftQty";
		DesiredAircraftQty.HeaderText = "所需的编队大小";
		DesiredAircraftQty.Name = "DesiredAircraftQty";
		DesiredAircraftQty.Resizable = DataGridViewTriState.True;
		DesiredAircraftQty.SortMode = DataGridViewColumnSortMode.Automatic;
		DesiredAircraftQty.Width = 125;
		MinimumAircraftQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		MinimumAircraftQty.DataPropertyName = "MinimumAircraftQty";
		MinimumAircraftQty.HeaderText = "最小飞行大小";
		MinimumAircraftQty.Name = "MinimumAircraftQty";
		MinimumAircraftQty.Resizable = DataGridViewTriState.True;
		MinimumAircraftQty.SortMode = DataGridViewColumnSortMode.Automatic;
		MinimumAircraftQty.Width = 139;
		AssignedAircraftQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		AssignedAircraftQty.DataPropertyName = "AssignedAircraftQty";
		AssignedAircraftQty.HeaderText = "指派的飞机";
		AssignedAircraftQty.Name = "AssignedAircraftQty";
		AssignedAircraftQty.ReadOnly = true;
		AssignedAircraftQty.Resizable = DataGridViewTriState.True;
		AssignedAircraftQty.Width = 98;
		ReadyAircraftQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ReadyAircraftQty.DataPropertyName = "ReadyAircraftQty";
		ReadyAircraftQty.HeaderText = "就绪飞机";
		ReadyAircraftQty.Name = "ReadyAircraftQty";
		ReadyAircraftQty.ReadOnly = true;
		ReadyAircraftQty.Resizable = DataGridViewTriState.True;
		ReadyAircraftQty.Width = 82;
		Priority.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Priority.DataPropertyName = "Priority";
		Priority.FlatStyle = FlatStyle.Flat;
		Priority.HeaderText = "优先";
		Priority.Name = "Priority";
		Priority.Resizable = DataGridViewTriState.True;
		Priority.SortMode = DataGridViewColumnSortMode.Automatic;
		Priority.Width = 68;
		CreatedBy.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		CreatedBy.DataPropertyName = "CreatedBy";
		CreatedBy.HeaderText = "由...制作";
		CreatedBy.Name = "CreatedBy";
		CreatedBy.Width = 87;
		EditedBy.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		EditedBy.DataPropertyName = "EditedBy";
		EditedBy.HeaderText = "编辑";
		EditedBy.Name = "EditedBy";
		EditedBy.Width = 79;
		Button_CopyFlight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_CopyFlight.BackColor = Color.Transparent;
		Button_CopyFlight.DialogResult = DialogResult.None;
		Button_CopyFlight.ForeColor = SystemColors.Control;
		Button_CopyFlight.Location = new Point(150, 631);
		Button_CopyFlight.Name = "Button_CopyFlight";
		Button_CopyFlight.RoundRadius = 0;
		Button_CopyFlight.Size = new Size(146, 28);
		Button_CopyFlight.TabIndex = 16;
		Button_CopyFlight.Text = "复制编队";
		Button_ChangeTakeOffTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ChangeTakeOffTime.BackColor = Color.Transparent;
		Button_ChangeTakeOffTime.DialogResult = DialogResult.None;
		Button_ChangeTakeOffTime.Enabled = false;
		Button_ChangeTakeOffTime.ForeColor = SystemColors.Control;
		Button_ChangeTakeOffTime.Location = new Point(176, 660);
		Button_ChangeTakeOffTime.Name = "Button_ChangeTakeOffTime";
		Button_ChangeTakeOffTime.RoundRadius = 0;
		Button_ChangeTakeOffTime.Size = new Size(162, 28);
		Button_ChangeTakeOffTime.TabIndex = 17;
		Button_ChangeTakeOffTime.Text = "改变起飞时间";
		Button_ChangeObjectiveTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ChangeObjectiveTime.BackColor = Color.Transparent;
		Button_ChangeObjectiveTime.DialogResult = DialogResult.None;
		Button_ChangeObjectiveTime.Enabled = false;
		Button_ChangeObjectiveTime.ForeColor = SystemColors.Control;
		Button_ChangeObjectiveTime.Location = new Point(339, 660);
		Button_ChangeObjectiveTime.Name = "Button_ChangeObjectiveTime";
		Button_ChangeObjectiveTime.RoundRadius = 0;
		Button_ChangeObjectiveTime.Size = new Size(162, 28);
		Button_ChangeObjectiveTime.TabIndex = 18;
		Button_ChangeObjectiveTime.Text = "改变到达目标时间";
		Button_ClearTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ClearTime.BackColor = Color.Transparent;
		Button_ClearTime.DialogResult = DialogResult.None;
		Button_ClearTime.Enabled = false;
		Button_ClearTime.ForeColor = SystemColors.Control;
		Button_ClearTime.Location = new Point(502, 660);
		Button_ClearTime.Name = "Button_ClearTime";
		Button_ClearTime.RoundRadius = 0;
		Button_ClearTime.Size = new Size(88, 28);
		Button_ClearTime.TabIndex = 18;
		Button_ClearTime.Text = "清除时间";
		ComboBox_AirTaskingOrderSorting.BackColor = Color.Transparent;
		ComboBox_AirTaskingOrderSorting.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_AirTaskingOrderSorting.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_AirTaskingOrderSorting.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_AirTaskingOrderSorting.FormattingEnabled = true;
		ComboBox_AirTaskingOrderSorting.Items.AddRange(new object[3] { "所有", "所选单元", "不显示" });
		ComboBox_AirTaskingOrderSorting.Location = new Point(93, 26);
		ComboBox_AirTaskingOrderSorting.Name = "ComboBox_AirTaskingOrderSorting";
		ComboBox_AirTaskingOrderSorting.Size = new Size(451, 21);
		ComboBox_AirTaskingOrderSorting.TabIndex = 21;
		ComboBox_AirTaskingOrderFilter.BackColor = Color.Transparent;
		ComboBox_AirTaskingOrderFilter.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_AirTaskingOrderFilter.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_AirTaskingOrderFilter.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_AirTaskingOrderFilter.FormattingEnabled = true;
		ComboBox_AirTaskingOrderFilter.Items.AddRange(new object[5] { "所有", "所选任务池（或任务）", "所选任务包（或任务）", "所选编队", "不显示" });
		ComboBox_AirTaskingOrderFilter.Location = new Point(93, 3);
		ComboBox_AirTaskingOrderFilter.Name = "ComboBox_AirTaskingOrderFilter";
		ComboBox_AirTaskingOrderFilter.Size = new Size(451, 21);
		ComboBox_AirTaskingOrderFilter.TabIndex = 22;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(1, 30);
		Label3.Name = "Label3";
		Label3.Size = new Size(89, 15);
		Label3.TabIndex = 19;
		Label3.Text = "排序编队按";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(1, 7);
		Label4.Name = "Label4";
		Label4.Size = new Size(99, 15);
		Label4.TabIndex = 20;
		Label4.Text = "显示...的编队";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1008, 691);
		base.Controls.Add(ComboBox_AirTaskingOrderSorting);
		base.Controls.Add(ComboBox_AirTaskingOrderFilter);
		base.Controls.Add(Label3);
		base.Controls.Add(Label4);
		base.Controls.Add(Button_ClearTime);
		base.Controls.Add(Button_ChangeObjectiveTime);
		base.Controls.Add(Button_ChangeTakeOffTime);
		base.Controls.Add(Button_CopyFlight);
		base.Controls.Add(Button_DeleteFlight);
		base.Controls.Add(Button_ChangeAircraftType);
		base.Controls.Add(Button_FlightPlanEditor);
		base.Controls.Add(Button_CreateFlight);
		base.Controls.Add(ComboBox_AirborneFlightPlanVisibility);
		base.Controls.Add(ComboBox_PlannedFlightPlanVisibility);
		base.Controls.Add(Label2);
		base.Controls.Add(Label1);
		base.Controls.Add(DGV_AirTaskingOrder);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AirTaskingOrder";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "空中任务清单（ATO）";
		((ISupportInitialize)DGV_AirTaskingOrder).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PatchAdvisor(ScenarioObject scenarioObject_0)
	{
		try
		{
			if (!Information.IsNothing(scenarioObject_0))
			{
				RefreshWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200631", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SelectAdvisor(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CallAdvisor(object sender, FormClosedEventArgs e)
	{
		MissionEditor.SelectedMissionChanged -= PatchAdvisor;
	}

	private void LogoutAdvisor(object sender, EventArgs e)
	{
		MissionEditor.SelectedMissionChanged += PatchAdvisor;
		Side.MissionsChanged += ViewAdvisor;
	}

	private void ViewAdvisor(Side side_0)
	{
		if (Operators.CompareString(Client.CurrentSide.ObjectID, side_0.ObjectID, TextCompare: true) == 0)
		{
			LoadWindow();
		}
	}

	private void ValidateAdvisor(object sender, EventArgs e)
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
		GetAdvisor();
		RefreshStats();
		LoginAdvisor();
	}

	private void LoginAdvisor()
	{
		Button_ChangeObjectiveTime.Visible = InterpreterObjectListener.singletonResolver;
		Button_ChangeTakeOffTime.Visible = InterpreterObjectListener.singletonResolver;
		Button_FlightPlanEditor.Visible = InterpreterObjectListener._PredicateResolver;
	}

	public void RefreshWindow()
	{
		WriteAdvisor();
	}

	public void ReloadWindow()
	{
		LoadWindow();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public void RefreshStats()
	{
		try
		{
			ComboBox_AirborneFlightPlanVisibility.SelectedIndex = (int)SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Airborne;
			ComboBox_PlannedFlightPlanVisibility.SelectedIndex = (int)SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Planned;
			ComboBox_AirTaskingOrderFilter.Items.Clear();
			ComboBox_AirTaskingOrderFilter.Items.Insert(0, "ATO中包含的任务和任务包");
			ComboBox_AirTaskingOrderFilter.Items.Insert(1, "所有任务和任务包，包括那些不在ATO中的任务和任务包");
			int num = 2;
			bool flag = false;
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (mission.Category != Mission.MissionCategory.TaskPool)
				{
					if (mission.Name == null)
					{
						mission.Name = "";
					}
					ComboBox_AirTaskingOrderFilter.Items.Insert(num, mission.Name);
					if (Operators.CompareString(mission.ObjectID, AirTaskingOrderFilterSetting, TextCompare: true) == 0)
					{
						ComboBox_AirTaskingOrderFilter.SelectedIndex = num;
						flag = true;
					}
					num++;
				}
			}
			if (!flag)
			{
				ComboBox_AirTaskingOrderFilter.SelectedIndex = 0;
			}
			ComboBox_AirTaskingOrderSorting.Items.Clear();
			ComboBox_AirTaskingOrderSorting.Items.Insert(0, "任务/包/任务池 - 起飞时间 - 任务类型 - 飞机 - 挂载");
			ComboBox_AirTaskingOrderSorting.Items.Insert(1, "起飞时间 - 任务类型 - 飞机 - 挂载");
			ComboBox_AirTaskingOrderSorting.Items.Insert(2, "到达目标时间 - 任务类型 - 飞机 - 挂载");
			ComboBox_AirTaskingOrderSorting.SelectedIndex = (int)m_ComposerRepository;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 0284654521", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void GetAdvisor()
	{
		try
		{
			int num;
			if (Information.IsNothing(DGV_AirTaskingOrder))
			{
				num = 0;
				interpreterRepository = 0;
				m_TestsRepository = "";
				SelectedFlight = null;
				SelectedMission = null;
			}
			else
			{
				num = DGV_AirTaskingOrder.SelectedRows.Count;
				if (num > 0)
				{
					interpreterRepository = DGV_AirTaskingOrder.SelectedRows[0].Index;
					SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
					if (!Information.IsNothing(SelectedFlight))
					{
						m_TestsRepository = SelectedFlight.ObjectID;
						SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
					}
				}
			}
			_FilterRepository = false;
			_ContainerRepository.Clear();
			SelectedFlightsList.Clear();
			_FilterRepository = true;
			if (!_ContainerRepository.Columns.Contains("ID"))
			{
				_ContainerRepository.Columns.Add("ID", typeof(string));
				modelRepository = 0;
			}
			if (!_ContainerRepository.Columns.Contains("MissionOrPackage"))
			{
				_ContainerRepository.Columns.Add("MissionOrPackage", typeof(string));
				m_AdvisorRepository = 1;
			}
			if (!_ContainerRepository.Columns.Contains("Callsign"))
			{
				_ContainerRepository.Columns.Add("Callsign", typeof(string));
				_CustomerRepository = 2;
			}
			if (!_ContainerRepository.Columns.Contains("Type"))
			{
				_ContainerRepository.Columns.Add("Type", typeof(int));
				_SerializerRepository = 3;
			}
			if (!_ContainerRepository.Columns.Contains("Status"))
			{
				_ContainerRepository.Columns.Add("Status", typeof(string));
				_ErrorRepository = 4;
			}
			if (!_ContainerRepository.Columns.Contains("Task"))
			{
				_ContainerRepository.Columns.Add("Task", typeof(int));
				m_RefRepository = 5;
			}
			if (!_ContainerRepository.Columns.Contains("AircraftType"))
			{
				_ContainerRepository.Columns.Add("AircraftType", typeof(string));
				_CodeRepository = 6;
			}
			if (!_ContainerRepository.Columns.Contains("LoadoutType"))
			{
				_ContainerRepository.Columns.Add("LoadoutType", typeof(string));
				_ConnectionRepository = 7;
			}
			if (!_ContainerRepository.Columns.Contains("TakeOffTimeZulu"))
			{
				_ContainerRepository.Columns.Add("TakeOffTimeZulu", typeof(string));
				m_ContextRepository = 8;
			}
			if (!_ContainerRepository.Columns.Contains("TakeOffTimeLocal"))
			{
				_ContainerRepository.Columns.Add("TakeOffTimeLocal", typeof(string));
				m_StatusRepository = 9;
			}
			if (!_ContainerRepository.Columns.Contains("TakeOffTimeFixed"))
			{
				_ContainerRepository.Columns.Add("TakeOffTimeFixed", typeof(int));
				exceptionRepository = 10;
			}
			if (!_ContainerRepository.Columns.Contains("TakeOffTimeImg"))
			{
				_ContainerRepository.Columns.Add("TakeOffTimeImg", typeof(Image));
				m_ProccesorRepository = 11;
			}
			if (!_ContainerRepository.Columns.Contains("ObjectiveTimeZulu"))
			{
				_ContainerRepository.Columns.Add("ObjectiveTimeZulu", typeof(string));
				m_StrategyRepository = 12;
			}
			if (!_ContainerRepository.Columns.Contains("ObjectiveTimeLocal"))
			{
				_ContainerRepository.Columns.Add("ObjectiveTimeLocal", typeof(string));
				configurationRepository = 13;
			}
			if (!_ContainerRepository.Columns.Contains("ObjectiveTimeFixed"))
			{
				_ContainerRepository.Columns.Add("ObjectiveTimeFixed", typeof(int));
				m_AttrRepository = 14;
			}
			if (!_ContainerRepository.Columns.Contains("ObjectiveTimeImg"))
			{
				_ContainerRepository.Columns.Add("ObjectiveTimeImg", typeof(Image));
				m_TokenRepository = 15;
			}
			if (!_ContainerRepository.Columns.Contains("TakeOffLocation"))
			{
				_ContainerRepository.Columns.Add("TakeOffLocation", typeof(string));
				indexerRepository = 16;
			}
			if (!_ContainerRepository.Columns.Contains("LandingLocation"))
			{
				_ContainerRepository.Columns.Add("LandingLocation", typeof(string));
				resolverRepository = 17;
			}
			if (!_ContainerRepository.Columns.Contains("AlternativeLandingLocation"))
			{
				_ContainerRepository.Columns.Add("AlternativeLandingLocation", typeof(string));
				m_PublisherRepository = 18;
			}
			if (!_ContainerRepository.Columns.Contains("DesiredAircraftQty"))
			{
				_ContainerRepository.Columns.Add("DesiredAircraftQty", typeof(int));
				m_ServerRepository = 19;
			}
			if (!_ContainerRepository.Columns.Contains("MinimumAircraftQty"))
			{
				_ContainerRepository.Columns.Add("MinimumAircraftQty", typeof(int));
				m_AdapterRepository = 20;
			}
			if (!_ContainerRepository.Columns.Contains("AssignedAircraftQty"))
			{
				_ContainerRepository.Columns.Add("AssignedAircraftQty", typeof(int));
				schemaRepository = 21;
			}
			if (!_ContainerRepository.Columns.Contains("ReadyAircraftQty"))
			{
				_ContainerRepository.Columns.Add("ReadyAircraftQty", typeof(int));
				utilsRepository = 22;
			}
			if (!_ContainerRepository.Columns.Contains("Priority"))
			{
				_ContainerRepository.Columns.Add("Priority", typeof(int));
				predicateRepository = 23;
			}
			if (!_ContainerRepository.Columns.Contains("CreatedBy"))
			{
				_ContainerRepository.Columns.Add("CreatedBy", typeof(string));
				m_SingletonRepository = 24;
			}
			if (!_ContainerRepository.Columns.Contains("EditedBy"))
			{
				_ContainerRepository.Columns.Add("EditedBy", typeof(string));
				m_RecordRepository = 25;
			}
			DataTable dataTable_ = new DataTable();
			DataTable dataTable_2 = new DataTable();
			DataTable dataTable_3 = new DataTable();
			new DataTable();
			new DataTable();
			DataGridViewComboBoxColumn dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)DGV_AirTaskingOrder.Columns[DGV_AirTaskingOrder.Columns["Task"].Index];
			DataGridViewComboBoxColumn dataGridViewComboBoxColumn2 = (DataGridViewComboBoxColumn)DGV_AirTaskingOrder.Columns[DGV_AirTaskingOrder.Columns["Priority"].Index];
			_ = (DataGridViewTextBoxColumn)DGV_AirTaskingOrder.Columns[DGV_AirTaskingOrder.Columns["DesiredAircraftQty"].Index];
			_ = (DataGridViewTextBoxColumn)DGV_AirTaskingOrder.Columns[DGV_AirTaskingOrder.Columns["MinimumAircraftQty"].Index];
			DataGridViewComboBoxColumn obj = (DataGridViewComboBoxColumn)DGV_AirTaskingOrder.Columns[DGV_AirTaskingOrder.Columns["Type"].Index];
			Mission.Flight.ComboBoxDataSource_Type(ref dataTable_);
			Mission.Flight.ComboBoxDataSource_Task(ref dataTable_2);
			Mission.Flight.ComboBoxDataSource_Priority(ref dataTable_3);
			dataGridViewComboBoxColumn.DataSource = dataTable_2;
			dataGridViewComboBoxColumn.DisplayMember = "Description";
			dataGridViewComboBoxColumn.ValueMember = "ID";
			dataGridViewComboBoxColumn2.DataSource = dataTable_3;
			dataGridViewComboBoxColumn2.DisplayMember = "Description";
			dataGridViewComboBoxColumn2.ValueMember = "ID";
			obj.DataSource = dataTable_;
			obj.DisplayMember = "Description";
			obj.ValueMember = "ID";
			_FilterRepository = false;
			if (!string.IsNullOrEmpty(AirTaskingOrderFilterSetting) && Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_ATO_Only", TextCompare: true) != 0 && Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_All", TextCompare: true) != 0)
			{
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if ((Operators.CompareString(mission.ObjectID, AirTaskingOrderFilterSetting, TextCompare: true) != 0 && Operators.CompareString(mission.GetParentTaskPoolID(Client.CurrentSide), AirTaskingOrderFilterSetting, TextCompare: true) != 0) || mission.Category == Mission.MissionCategory.TaskPool)
					{
						continue;
					}
					foreach (Mission.Flight flight in mission.FlightList)
					{
						SelectedFlightsList.Add(flight);
					}
					break;
				}
			}
			else
			{
				foreach (Mission mission2 in Client.CurrentSide.Missions)
				{
					if (Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_ATO_Only", TextCompare: true) == 0 && !mission2.IncludeInATO)
					{
						continue;
					}
					foreach (Mission.Flight flight2 in mission2.FlightList)
					{
						SelectedFlightsList.Add(flight2);
					}
				}
			}
			if (SelectedFlightsList.Count == 0)
			{
				return;
			}
			foreach (Mission.Flight selectedFlights in SelectedFlightsList)
			{
				Scenario scenario_ = Client.CurrentScenario;
				selectedFlights.SetTakeOffAndObjectiveTimeString(ref scenario_);
			}
			switch (m_ComposerRepository)
			{
			default:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.ParentMissionOrPackageName, theF.TakeOffTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.GetLoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			case AirTaskingOrderSortType.MissionOrPackageName_TakeOffTime_Task_Aircraft_Loadout:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.ParentMissionOrPackageName, theF.TakeOffTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.GetLoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			case AirTaskingOrderSortType.TakeOffTime_Task_Aircraft_Loadout:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.TakeOffTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.GetLoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			case AirTaskingOrderSortType.ObjectiveTime_Task_Aircraft_Loadout:
				SelectedFlightsList = (from theF in SelectedFlightsList
					orderby theF.ObjectiveTimeZuluString, theF.Task, theF.ReferenceUnit_Name, theF.GetLoadoutName(Client.CurrentScenario)
					select theF).ToList();
				break;
			}
			foreach (Mission.Flight selectedFlights2 in SelectedFlightsList)
			{
				DataRow row = _ContainerRepository.NewRow();
				_ContainerRepository.Rows.Add(row);
			}
			if (num == 0 && DGV_AirTaskingOrder.Rows.Count > 0)
			{
				DGV_AirTaskingOrder.Rows[0].Selected = false;
			}
			_FilterRepository = true;
			WriteAdvisor();
			_FilterRepository = false;
			DGV_AirTaskingOrder.DataSource = new DataView(_ContainerRepository);
			_FilterRepository = true;
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = ((IEnumerable)DGV_AirTaskingOrder.Rows).GetEnumerator();
				while (enumerator3.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator3.Current;
					foreach (Mission.Flight selectedFlights3 in SelectedFlightsList)
					{
						if (Operators.CompareString(selectedFlights3.ObjectID, Conversions.ToString(dataGridViewRow.Cells["ID"].Value), TextCompare: true) == 0)
						{
							dataGridViewRow.Tag = selectedFlights3;
							break;
						}
					}
				}
			}
			finally
			{
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
			_FilterRepository = false;
			if (DGV_AirTaskingOrder.RowCount <= 0)
			{
				SelectedFlight = null;
				SelectedMission = null;
			}
			else if (interpreterRepository <= DGV_AirTaskingOrder.RowCount - 1)
			{
				DGV_AirTaskingOrder.Rows[0].Selected = false;
				DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = true;
				SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
				if (!Information.IsNothing(SelectedFlight))
				{
					m_TestsRepository = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
				}
			}
			else
			{
				DGV_AirTaskingOrder.Rows[0].Selected = false;
				DGV_AirTaskingOrder.Rows[DGV_AirTaskingOrder.RowCount - 1].Selected = true;
				SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
				if (!Information.IsNothing(SelectedFlight))
				{
					m_TestsRepository = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
				}
			}
			_FilterRepository = true;
			if (Information.IsNothing(SelectedFlight) && DGV_AirTaskingOrder.SelectedRows.Count > 0)
			{
				SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
				if (!Information.IsNothing(SelectedFlight))
				{
					m_TestsRepository = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
				}
			}
			DisplayLocks();
			EnableAndDisableButtons();
			EnableAndDisableCells();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void WriteAdvisor()
	{
		try
		{
			if (Information.IsNothing(SelectedFlightsList) || SelectedFlightsList.Count == 0)
			{
				return;
			}
			DGV_AirTaskingOrder.SuspendLayout();
			int count = _ContainerRepository.Rows.Count;
			try
			{
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					DataRow dataRow = _ContainerRepository.Rows[i];
					Mission.Flight Local_theFlight = SelectedFlightsList[i];
					string objectID = Local_theFlight.ObjectID;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[modelRepository]), objectID))
					{
						dataRow[modelRepository] = objectID;
					}
					if (string.IsNullOrEmpty(Local_theFlight.ParentMissionOrPackageName))
					{
						foreach (Mission mission2 in Client.CurrentSide.Missions)
						{
							if (mission2.FlightList.Contains(Local_theFlight))
							{
								Local_theFlight.ParentMissionOrPackageObjectID = mission2.ObjectID;
								Local_theFlight.ParentMissionOrPackageName = mission2.Name;
								break;
							}
						}
					}
					string parentMissionOrPackageName = Local_theFlight.ParentMissionOrPackageName;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_AdvisorRepository]), parentMissionOrPackageName))
					{
						dataRow[m_AdvisorRepository] = parentMissionOrPackageName;
					}
					string callsign = Local_theFlight.Callsign;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_CustomerRepository]), callsign))
					{
						dataRow[_CustomerRepository] = callsign;
					}
					int num2 = Mission.Flight.Type_To_TypeSelection((int)Local_theFlight.Type);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_SerializerRepository]), num2))
					{
						dataRow[_SerializerRepository] = num2;
					}
					int num3 = Mission.Flight.Task_To_TaskSelection((int)Local_theFlight.Task);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_RefRepository]), num3))
					{
						dataRow[m_RefRepository] = num3;
					}
					Scenario scenario_ = Client.CurrentScenario;
					Local_theFlight.SetTakeOffAndObjectiveTimeString(ref scenario_);
					string takeOffTimeZuluString = Local_theFlight.TakeOffTimeZuluString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ContextRepository]), takeOffTimeZuluString))
					{
						dataRow[m_ContextRepository] = takeOffTimeZuluString;
					}
					string takeOffTimeLocalString = Local_theFlight.TakeOffTimeLocalString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_StatusRepository]), takeOffTimeLocalString))
					{
						dataRow[m_StatusRepository] = takeOffTimeLocalString;
					}
					string objectiveTimeZuluString = Local_theFlight.ObjectiveTimeZuluString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_StrategyRepository]), objectiveTimeZuluString))
					{
						dataRow[m_StrategyRepository] = objectiveTimeZuluString;
					}
					string objectiveTimeLocalString = Local_theFlight.ObjectiveTimeLocalString;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[configurationRepository]), objectiveTimeLocalString))
					{
						dataRow[configurationRepository] = objectiveTimeLocalString;
					}
					int takeOffWaypointFixedTime = (int)Local_theFlight.TakeOffWaypointFixedTime;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[exceptionRepository]), takeOffWaypointFixedTime))
					{
						dataRow[exceptionRepository] = takeOffWaypointFixedTime;
					}
					int objectiveWaypointFixedTime = (int)Local_theFlight.ObjectiveWaypointFixedTime;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_AttrRepository]), objectiveWaypointFixedTime))
					{
						dataRow[m_AttrRepository] = objectiveWaypointFixedTime;
					}
					string text = Local_theFlight.ReferenceUnit_Name;
					if (string.IsNullOrEmpty(text))
					{
						text = "没有设置";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_CodeRepository]), text))
					{
						dataRow[_CodeRepository] = text;
					}
					string loadoutName = Local_theFlight.GetLoadoutName(Client.CurrentScenario);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ConnectionRepository]), loadoutName))
					{
						dataRow[_ConnectionRepository] = loadoutName;
					}
					string text2 = Local_theFlight.TakeOffLocation_HostUnitObjectName;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = "没有设置";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[indexerRepository]), text2))
					{
						dataRow[indexerRepository] = text2;
					}
					string text3 = Local_theFlight.LandingLocation_HostUnitObjectName;
					if (string.IsNullOrEmpty(text3))
					{
						text3 = "没有设置";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[resolverRepository]), text3))
					{
						dataRow[resolverRepository] = text3;
					}
					string value = Local_theFlight.AlternativeLandingLocation_HostUnitObjectName;
					if (string.IsNullOrEmpty(value))
					{
						value = "-";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_PublisherRepository]), loadoutName))
					{
						dataRow[m_PublisherRepository] = value;
					}
					string flightStatusString = Mission.GetFlightStatusString(Local_theFlight.GetStatus(Client.CurrentScenario));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ErrorRepository]), flightStatusString))
					{
						dataRow[_ErrorRepository] = flightStatusString;
					}
					int num4 = Mission.Flight.Priority_To_PrioritySelection((int)Local_theFlight.Priority);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[predicateRepository]), num4))
					{
						dataRow[predicateRepository] = num4;
					}
					int createdBy = (int)Local_theFlight.CreatedBy;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_SingletonRepository]), createdBy))
					{
						dataRow[m_SingletonRepository] = Local_theFlight.CreatedBy;
					}
					int editedBy = (int)Local_theFlight.EditedBy;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_RecordRepository]), editedBy))
					{
						dataRow[m_RecordRepository] = Local_theFlight.EditedBy;
					}
					int num5 = Mission.Flight.AircraftQty_To_AircraftQtySelection(Local_theFlight.DesiredAircraftQty);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ServerRepository]), num5))
					{
						dataRow[m_ServerRepository] = num5;
					}
					int num6 = Mission.Flight.AircraftQty_To_AircraftQtySelection(Local_theFlight.MinimumAircraftQty);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_AdapterRepository]), num6))
					{
						dataRow[m_AdapterRepository] = num6;
					}
					Mission mission = Client.CurrentSide.Missions.Where((Mission theM) => Operators.CompareString(theM.Name, Local_theFlight.ParentMissionOrPackageName, TextCompare: true) == 0).ElementAtOrDefault(0);
					mission.ResetFlightReadyAicraftCount(Client.CurrentScenario, Local_theFlight);
					int count2 = Local_theFlight.GetAUCurrentlyAssigned(mission, Client.CurrentScenario).Count;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[schemaRepository]), count2))
					{
						dataRow[schemaRepository] = count2;
					}
					int readyAircraftQty = Local_theFlight.ReadyAircraftQty;
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[utilsRepository]), readyAircraftQty))
					{
						dataRow[utilsRepository] = readyAircraftQty;
					}
				}
			}
			finally
			{
				DGV_AirTaskingOrder.ResumeLayout();
			}
			if (DGV_AirTaskingOrder.Rows.Count <= 0)
			{
				SelectedFlight = null;
				SelectedMission = null;
				return;
			}
			_FilterRepository = false;
			NewAdvisor();
			if (DGV_AirTaskingOrder.SelectedRows.Count > 0 && DGV_AirTaskingOrder.SelectedRows[0].Index > 0 && interpreterRepository != DGV_AirTaskingOrder.SelectedRows[0].Index)
			{
				if (interpreterRepository <= DGV_AirTaskingOrder.Rows.Count - 1)
				{
					DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = false;
				}
				interpreterRepository = DGV_AirTaskingOrder.SelectedRows[0].Index;
			}
			DGV_AirTaskingOrder.Rows[0].Selected = false;
			if (DGV_AirTaskingOrder.RowCount > 0)
			{
				if (interpreterRepository <= DGV_AirTaskingOrder.RowCount - 1)
				{
					DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = false;
					DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = true;
				}
				else
				{
					DGV_AirTaskingOrder.Rows[DGV_AirTaskingOrder.RowCount - 1].Selected = false;
					DGV_AirTaskingOrder.Rows[DGV_AirTaskingOrder.RowCount - 1].Selected = true;
				}
			}
			SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
			if (!Information.IsNothing(SelectedFlight))
			{
				m_TestsRepository = SelectedFlight.ObjectID;
				SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
			}
			_FilterRepository = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200583", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void NewAdvisor()
	{
		try
		{
			int count = _ContainerRepository.Rows.Count;
			if (string.IsNullOrEmpty(m_TestsRepository))
			{
				return;
			}
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				Mission.Flight flight = SelectedFlightsList[i];
				if (!Information.IsNothing(flight) && Operators.CompareString(flight.ObjectID, m_TestsRepository, TextCompare: true) == 0)
				{
					int count2 = DGV_AirTaskingOrder.SelectedRows.Count;
					for (int j = count2 - 1; j >= 0; j += -1)
					{
						DataGridViewRow dataGridViewRow = DGV_AirTaskingOrder.SelectedRows[j];
						DGV_AirTaskingOrder.Rows[dataGridViewRow.Index].Selected = false;
					}
					if (interpreterRepository <= count2 - 1)
					{
						DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = false;
					}
					DGV_AirTaskingOrder.Rows[i].Selected = true;
					interpreterRepository = i;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at \u00a8999999", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PushAdvisor()
	{
		try
		{
			int num = DGV_AirTaskingOrder.Rows.Count - 1;
			if (string.IsNullOrEmpty(m_TestsRepository))
			{
				return;
			}
			int num2 = num;
			for (int i = 0; i <= num2; i++)
			{
				Mission.Flight flight = SelectedFlightsList[i];
				if (!Information.IsNothing(flight) && Operators.CompareString(flight.ObjectID, m_TestsRepository, TextCompare: true) == 0)
				{
					int count = DGV_AirTaskingOrder.SelectedRows.Count;
					for (int j = count - 1; j >= 0; j += -1)
					{
						DataGridViewRow dataGridViewRow = DGV_AirTaskingOrder.SelectedRows[j];
						DGV_AirTaskingOrder.Rows[dataGridViewRow.Index].Selected = false;
					}
					if (interpreterRepository <= count - 1)
					{
						DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = false;
					}
					DGV_AirTaskingOrder.Rows[i].Selected = true;
					interpreterRepository = i;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at \u00a8999999", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InvokeAdvisor(object sender, DataGridViewCellPaintingEventArgs e)
	{
		try
		{
			if (e.RowIndex == 0 && e.ColumnIndex == m_StatusRepository)
			{
				Rectangle cellBounds = e.CellBounds;
				cellBounds.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds, cellsPaintSelectionBackground: true);
				e.PaintContent(cellBounds);
			}
			else if (e.RowIndex == 0 && e.ColumnIndex == configurationRepository)
			{
				Rectangle cellBounds2 = e.CellBounds;
				cellBounds2.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds2.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds2, cellsPaintSelectionBackground: true);
				e.PaintContent(cellBounds2);
			}
			else if (e.RowIndex == 0)
			{
				_ = e.ColumnIndex;
				_ = e.ColumnIndex;
			}
			if (m_StatusRepository == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				if (DGV_AirTaskingOrder.SelectedRows.Count > 0 && DGV_AirTaskingOrder.SelectedRows[0].Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.SelectionBackColor, 1, ButtonBorderStyle.Solid, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None);
				}
				Rectangle cellBounds3 = e.CellBounds;
				int num = DGV_AirTaskingOrder.GetCellDisplayRectangle(m_ProccesorRepository, e.RowIndex, cutOverflow: true).Width;
				cellBounds3.Width += num;
				ControlPaint.DrawBorder(e.Graphics, cellBounds3, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, Color.Red, 0, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (configurationRepository == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				if (DGV_AirTaskingOrder.SelectedRows.Count > 0 && DGV_AirTaskingOrder.SelectedRows[0].Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.SelectionBackColor, 1, ButtonBorderStyle.Solid, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None);
				}
				Rectangle cellBounds4 = e.CellBounds;
				int num2 = DGV_AirTaskingOrder.GetCellDisplayRectangle(m_TokenRepository, e.RowIndex, cutOverflow: true).Width;
				cellBounds4.Width += num2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds4, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, Color.Red, 0, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (m_StatusRepository == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds5 = e.CellBounds;
				cellBounds5.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds5.Y++;
				cellBounds5.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (configurationRepository == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds6 = e.CellBounds;
				cellBounds6.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds6.Y++;
				cellBounds6.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (m_ProccesorRepository == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds7 = e.CellBounds;
				cellBounds7.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds7.Height -= 2;
				cellBounds7.Y++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (m_TokenRepository == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds8 = e.CellBounds;
				cellBounds8.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds8.Y++;
				cellBounds8.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, DGV_AirTaskingOrder.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
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

	public void DisplayLocks()
	{
		try
		{
			_VisitorRepository.MakeTransparent(Color.White);
			exporterRepository.MakeTransparent(Color.White);
			m_PrototypeRepository.MakeTransparent(Color.White);
			_ComparatorRepository.MakeTransparent(Color.White);
			m_ItemRepository.MakeTransparent(Color.White);
			bool filterRepository = _FilterRepository;
			_FilterRepository = false;
			IEnumerator enumerator = null;
			try
			{
				enumerator = ((IEnumerable)DGV_AirTaskingOrder.Rows).GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[exceptionRepository].Value), 1))
					{
						if (dataGridViewRow.Cells[m_ProccesorRepository].Value != _VisitorRepository)
						{
							dataGridViewRow.Cells[m_ProccesorRepository].Value = _VisitorRepository;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[exceptionRepository].Value), 0))
					{
						if (dataGridViewRow.Cells[m_ProccesorRepository].Value != exporterRepository)
						{
							dataGridViewRow.Cells[m_ProccesorRepository].Value = exporterRepository;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[exceptionRepository].Value), 2))
					{
						if (dataGridViewRow.Cells[m_ProccesorRepository].Value != _ComparatorRepository)
						{
							dataGridViewRow.Cells[m_ProccesorRepository].Value = _ComparatorRepository;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[exceptionRepository].Value), 3))
					{
						if (dataGridViewRow.Cells[m_ProccesorRepository].Value != m_ItemRepository)
						{
							dataGridViewRow.Cells[m_ProccesorRepository].Value = m_ItemRepository;
						}
					}
					else if (dataGridViewRow.Cells[m_ProccesorRepository].Value != m_PrototypeRepository)
					{
						dataGridViewRow.Cells[m_ProccesorRepository].Value = m_PrototypeRepository;
					}
					if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[m_AttrRepository].Value), 1))
					{
						if (dataGridViewRow.Cells[m_TokenRepository].Value != _VisitorRepository)
						{
							dataGridViewRow.Cells[m_TokenRepository].Value = _VisitorRepository;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[m_AttrRepository].Value), 0))
					{
						if (dataGridViewRow.Cells[m_TokenRepository].Value != exporterRepository)
						{
							dataGridViewRow.Cells[m_TokenRepository].Value = exporterRepository;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[m_AttrRepository].Value), 2))
					{
						if (dataGridViewRow.Cells[m_TokenRepository].Value != _ComparatorRepository)
						{
							dataGridViewRow.Cells[m_TokenRepository].Value = _ComparatorRepository;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[m_AttrRepository].Value), 3))
					{
						if (dataGridViewRow.Cells[m_TokenRepository].Value != m_ItemRepository)
						{
							dataGridViewRow.Cells[m_TokenRepository].Value = m_ItemRepository;
						}
					}
					else if (dataGridViewRow.Cells[m_TokenRepository].Value != m_PrototypeRepository)
					{
						dataGridViewRow.Cells[m_TokenRepository].Value = m_PrototypeRepository;
					}
					dataGridViewRow.Cells[m_ServerRepository].Value = SelectedFlight.DesiredAircraftQty.value;
					dataGridViewRow.Cells[m_AdapterRepository].Value = SelectedFlight.MinimumAircraftQty.value;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			_FilterRepository = filterRepository;
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

	private void SetupAdvisor(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			int num = DGV_AirTaskingOrder.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow = DGV_AirTaskingOrder.Rows[i];
				if (!dataGridViewRow.Selected)
				{
					continue;
				}
				interpreterRepository = i;
				DataGridViewRow dataGridViewRow2 = dataGridViewRow;
				SelectedFlight = (Mission.Flight)dataGridViewRow2.Tag;
				if (!Information.IsNothing(SelectedFlight))
				{
					m_TestsRepository = SelectedFlight.ObjectID;
					SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
				}
				DataGridViewColumn dataGridViewColumn = DGV_AirTaskingOrder.Columns[e.ColumnIndex];
				if (Operators.CompareString(dataGridViewColumn.Name, "Type", TextCompare: true) != 0)
				{
					if (Operators.CompareString(dataGridViewColumn.Name, "Task", TextCompare: true) != 0)
					{
						if (Operators.CompareString(dataGridViewColumn.Name, "Priority", TextCompare: true) != 0)
						{
							if (dataGridViewColumn.Index != m_ProccesorRepository)
							{
								if (dataGridViewColumn.Index != m_TokenRepository)
								{
									continue;
								}
								if (SelectedFlight.FlightPlan.Count() <= 0)
								{
									break;
								}
								int num2 = SelectedFlight.FlightPlan.Count() - 1;
								for (int j = 0; j <= num2; j++)
								{
									Waypoint waypoint_ = SelectedFlight.FlightPlan[j];
									if (Information.IsNothing(waypoint_.Time_Zulu))
									{
										break;
									}
									if (((waypoint_.Type == Waypoint.WaypointType.Target) | (waypoint_.Type == Waypoint.WaypointType.WeaponTarget)) || waypoint_.SearchReponse())
									{
										if (waypoint_.TimeFixed == Waypoint.FixedFree.Free)
										{
											waypoint_.TimeFixed = Waypoint.FixedFree.Fixed;
											SelectedFlight.ObjectiveWaypointFixedTime = waypoint_.TimeFixed;
											Mission.Flight selectedFlight = SelectedFlight;
											ref Mission selectedMission = ref SelectedMission;
											Mission.Flight selectedFlight2 = SelectedFlight;
											Waypoint[] waypoint_2 = selectedFlight2.FlightPlan;
											UpdateWingmanWaypoints(selectedFlight, ref waypoint_, ref selectedMission, ref waypoint_2, Mission.Flight.FlightElement.LeadElement);
											selectedFlight2.FlightPlan = waypoint_2;
										}
										else if (waypoint_.TimeFixed == Waypoint.FixedFree.Fixed)
										{
											waypoint_.TimeFixed = Waypoint.FixedFree.Free;
											SelectedFlight.ObjectiveWaypointFixedTime = waypoint_.TimeFixed;
										}
										else if (waypoint_.TimeFixed == Waypoint.FixedFree.Relative)
										{
											waypoint_.TimeFixed = Waypoint.FixedFree.Free;
											SelectedFlight.ObjectiveWaypointFixedTime = waypoint_.TimeFixed;
										}
										break;
									}
								}
								flag = true;
								flag2 = true;
								flag5 = true;
								flag3 = true;
								break;
							}
							if (SelectedFlight.FlightPlan.Count() <= 0)
							{
								break;
							}
							int num3 = SelectedFlight.FlightPlan.Count() - 1;
							for (int k = 0; k <= num3; k++)
							{
								Waypoint waypoint_3 = SelectedFlight.FlightPlan[k];
								if (Information.IsNothing(waypoint_3.Time_Zulu))
								{
									break;
								}
								if (waypoint_3.Type == Waypoint.WaypointType.TakeOff)
								{
									if (waypoint_3.TimeFixed == Waypoint.FixedFree.Free)
									{
										waypoint_3.TimeFixed = Waypoint.FixedFree.Fixed;
										SelectedFlight.TakeOffWaypointFixedTime = waypoint_3.TimeFixed;
										Mission.Flight selectedFlight3 = SelectedFlight;
										ref Mission selectedMission2 = ref SelectedMission;
										Mission.Flight selectedFlight4 = SelectedFlight;
										Waypoint[] waypoint_4 = selectedFlight4.FlightPlan;
										UpdateWingmanWaypoints(selectedFlight3, ref waypoint_3, ref selectedMission2, ref waypoint_4, Mission.Flight.FlightElement.LeadElement);
										selectedFlight4.FlightPlan = waypoint_4;
									}
									else if (waypoint_3.TimeFixed == Waypoint.FixedFree.Fixed)
									{
										waypoint_3.TimeFixed = Waypoint.FixedFree.Free;
										SelectedFlight.TakeOffWaypointFixedTime = waypoint_3.TimeFixed;
									}
									else if (waypoint_3.TimeFixed == Waypoint.FixedFree.Relative)
									{
										waypoint_3.TimeFixed = Waypoint.FixedFree.Free;
										SelectedFlight.TakeOffWaypointFixedTime = waypoint_3.TimeFixed;
									}
									break;
								}
							}
							flag = true;
							flag2 = true;
							flag5 = true;
							flag3 = true;
							break;
						}
						if (!DGV_AirTaskingOrder[dataGridViewColumn.Index, dataGridViewRow.Index].IsInEditMode)
						{
							DataTable dataTable_ = new DataTable();
							DataGridViewComboBoxCell obj = (DataGridViewComboBoxCell)DGV_AirTaskingOrder[dataGridViewColumn.Index, dataGridViewRow.Index];
							Mission.Flight.ComboBoxDataSource_Priority(ref dataTable_);
							obj.DataSource = dataTable_;
							obj.DisplayMember = "Description";
							obj.ValueMember = "ID";
							obj.DropDownWidth = 500;
						}
						DGV_AirTaskingOrder.BeginEdit(selectAll: true);
						if (DGV_AirTaskingOrder.Rows[e.RowIndex].Cells[Task.Name].Selected && !Information.IsNothing(DGV_AirTaskingOrder.EditingControl))
						{
							((DataGridViewComboBoxEditingControl)DGV_AirTaskingOrder.EditingControl).DroppedDown = true;
						}
						break;
					}
					if (!DGV_AirTaskingOrder[dataGridViewColumn.Index, dataGridViewRow.Index].IsInEditMode)
					{
						DataTable dataTable_2 = new DataTable();
						DataGridViewComboBoxCell obj2 = (DataGridViewComboBoxCell)DGV_AirTaskingOrder[dataGridViewColumn.Index, dataGridViewRow.Index];
						Mission.Flight.ComboBoxDataSource_Task(ref dataTable_2);
						obj2.DataSource = dataTable_2;
						obj2.DisplayMember = "Description";
						obj2.ValueMember = "ID";
						obj2.DropDownWidth = 500;
					}
					DGV_AirTaskingOrder.BeginEdit(selectAll: true);
					if (DGV_AirTaskingOrder.Rows[e.RowIndex].Cells[Task.Name].Selected && !Information.IsNothing(DGV_AirTaskingOrder.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_AirTaskingOrder.EditingControl).DroppedDown = true;
					}
					break;
				}
				if (!DGV_AirTaskingOrder[dataGridViewColumn.Index, dataGridViewRow.Index].IsInEditMode)
				{
					DataTable dataTable_3 = new DataTable();
					DataGridViewComboBoxCell obj3 = (DataGridViewComboBoxCell)DGV_AirTaskingOrder[dataGridViewColumn.Index, dataGridViewRow.Index];
					Mission.Flight.ComboBoxDataSource_Type(ref dataTable_3);
					obj3.DataSource = dataTable_3;
					obj3.DisplayMember = "Description";
					obj3.ValueMember = "ID";
					obj3.DropDownWidth = 200;
				}
				DGV_AirTaskingOrder.BeginEdit(selectAll: true);
				if (DGV_AirTaskingOrder.Rows[e.RowIndex].Cells[Task.Name].Selected && !Information.IsNothing(DGV_AirTaskingOrder.EditingControl))
				{
					((DataGridViewComboBoxEditingControl)DGV_AirTaskingOrder.EditingControl).DroppedDown = true;
				}
				break;
			}
			if (flag)
			{
				RecalculateFlightPlanFuelAndTimes(bool_0: true, flag2, flag4, flag5);
			}
			else if (flag4)
			{
				if (Client.FlightPlanEditorWindow.Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
				{
					Client.FlightPlanEditorWindow.NewPolicy();
				}
			}
			else if (flag2 && Client.FlightPlanEditorWindow.Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
				if (flag5)
				{
					Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
				}
			}
			if (flag3)
			{
				WriteAdvisor();
				DisplayLocks();
			}
			EnableAndDisableButtons();
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200583", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RecalculateFlightPlanFuelAndTimes(bool bool_0, bool bool_1, bool bool_2, bool bool_3)
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
			if (Client.FlightPlanEditorWindow.Visible && bool_1)
			{
				if (bool_2)
				{
					Client.FlightPlanEditorWindow.NewPolicy();
				}
				else
				{
					Client.FlightPlanEditorWindow.InvokePolicy();
					if (bool_3)
					{
						Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
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

	private void ExcludeAdvisor(object sender, DataGridViewCellEventArgs e)
	{
		if (DGV_AirTaskingOrder.SelectedRows.Count != 0 && _FilterRepository)
		{
			SearchAdvisor(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void IncludeAdvisor(object sender, EventArgs e)
	{
		_FilterRepository = true;
		if (DGV_AirTaskingOrder.IsCurrentCellDirty)
		{
			DGV_AirTaskingOrder.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void SearchAdvisor(object sender, DataGridViewCellEventArgs e)
	{
		Mission.Flight flight = (Mission.Flight)DGV_AirTaskingOrder.Rows[e.RowIndex].Tag;
		if (Information.IsNothing(flight))
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		bool flag8 = false;
		if (e.RowIndex != -1 && e.ColumnIndex == _SerializerRepository)
		{
			Mission._FlightType flightType_ = Mission.Flight.TypeSelection_To_Type(Conversions.ToInteger(DGV_AirTaskingOrder[e.ColumnIndex, e.RowIndex].Value));
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			ChangeFlightType(flight, ref scenario_, ref side_, ref SelectedMission, flightType_);
			Client.CurrentSide = side_;
			flag = true;
			flag3 = true;
			flag4 = true;
			flag5 = true;
			flag6 = true;
			flag7 = true;
		}
		if (e.RowIndex != -1 && e.ColumnIndex == m_RefRepository)
		{
			Mission._FlightTask flightTask = Mission.Flight.TaskSelection_To_Task(Conversions.ToInteger(DGV_AirTaskingOrder[e.ColumnIndex, e.RowIndex].Value));
			if (flightTask == Mission._FlightTask.QRA)
			{
				if (SelectedMission.MissionClass != Mission._MissionClass.Patrol && SelectedMission.MissionClass != Mission._MissionClass.Support)
				{
					Interaction.MsgBox("只有巡逻和支援任务可以使用QRA类型的编队。");
					RefreshWindow();
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
					RefreshWindow();
					return;
				}
				if (SelectedFlight.FlightPlan.Count() > 0 && !Information.IsNothing(SelectedFlight.FlightPlan[0].Time_Zulu))
				{
					if (Interaction.MsgBox("将编队任务类型更改为QRA将清除所有航点时间。继续？", MsgBoxStyle.YesNo) != MsgBoxResult.Yes)
					{
						RefreshWindow();
						return;
					}
					ClearFlightTime(SelectedFlight, bool_);
				}
			}
			flight.Task = flightTask;
			if (flight.CheckInterruptibleQueue())
			{
				flight.IsEscort = true;
			}
			else
			{
				flight.IsEscort = false;
			}
			foreach (ActiveUnit item in Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario))
			{
				if (item.Navigator.HasFlight && item.Navigator.GetFlight() == flight)
				{
					item.AI.IsEscort = flight.IsEscort;
				}
			}
			if (!Information.IsNothing(SelectedMission.EmptySlotsList))
			{
				foreach (Mission.EmptyAircraftSlot emptySlots in SelectedMission.EmptySlotsList)
				{
					if (Operators.CompareString(emptySlots.MissionFlight_ObjectID, flight.ObjectID, TextCompare: true) == 0)
					{
						emptySlots.IsEscort = flight.IsEscort;
					}
				}
			}
			flag8 = true;
			flag2 = true;
			flag = true;
			flag3 = true;
		}
		if (e.RowIndex != -1 && e.ColumnIndex == predicateRepository)
		{
			flight.Priority = Mission.Flight.PrioritySelection_To_Priority(Conversions.ToInteger(DGV_AirTaskingOrder[e.ColumnIndex, e.RowIndex].Value));
		}
		if (e.RowIndex != -1 && e.ColumnIndex == m_ServerRepository)
		{
			Mission._FlightSize flightSize_ = Mission.Flight.AircraftQtySelection_To_AircraftQty(Conversions.ToInteger(DGV_AirTaskingOrder[e.ColumnIndex, e.RowIndex].Value));
			if (!Information.IsNothing(SelectedFlight))
			{
				Mission.Flight selectedFlight = SelectedFlight;
				Scenario scenario_2 = Client.CurrentScenario;
				selectedFlight.ChangeDesiredFlightSize(ref scenario_2, ref SelectedMission, Client.CurrentSide, flightSize_);
				flag = true;
				flag4 = true;
				flag3 = true;
			}
			RegistryParameterMessage.AwakeCustomer();
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		if (e.RowIndex != -1 && e.ColumnIndex == m_AdapterRepository)
		{
			Mission._FlightSize flightSize_2 = Mission.Flight.AircraftQtySelection_To_AircraftQty(Conversions.ToInteger(DGV_AirTaskingOrder[e.ColumnIndex, e.RowIndex].Value));
			if (!Information.IsNothing(SelectedFlight))
			{
				Mission.Flight selectedFlight2 = SelectedFlight;
				Scenario scenario_3 = Client.CurrentScenario;
				selectedFlight2.ChangeMinimumFlightSize(ref scenario_3, ref SelectedMission, Client.CurrentSide, flightSize_2);
				flag = true;
				flag4 = true;
			}
		}
		if (flag8 && !Information.IsNothing(SelectedFlight))
		{
			Scenario currentScenario = Client.CurrentScenario;
			Mission selectedMission = SelectedMission;
			ActiveUnit referenceUnit = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight selectedFlight3 = SelectedFlight;
			Mission.Flight selectedFlight4 = SelectedFlight;
			Waypoint[] waypoint_ = selectedFlight4.FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, selectedMission, referenceUnit, selectedFlight3, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			selectedFlight4.FlightPlan = waypoint_;
			RegistryParameterMessage.AwakeCustomer();
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		if (flag3)
		{
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
				Client.FlightPlanEditorWindow.NewPolicy();
			}
		}
		else if (flag2 && Client.FlightPlanEditorWindow.Visible)
		{
			Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
			Client.FlightPlanEditorWindow.InvokePolicy();
		}
		if (flag && Client.AirTaskingOrderWindow.Visible)
		{
			Client.AirTaskingOrderWindow.RefreshWindow();
			Client.AirTaskingOrderWindow.EnableAndDisableButtons();
			if (flag6)
			{
				DisplayLocks();
			}
		}
		if (flag4 && Client.FlightPlanAircraftLoadoutWindow.Visible)
		{
			Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
		}
		if (flag5)
		{
			EnableAndDisableCells();
		}
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		if (flag7)
		{
			RegistryParameterMessage.AwakeCustomer();
		}
		_FilterRepository = false;
	}

	private void EnableAdvisor(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight))
		{
			Client.FlightPlanEditorWindow.SelectedMission = SelectedMission;
			Client.FlightPlanEditorWindow.SelectedFlight = SelectedFlight;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.ReloadWindow();
				Client.FlightPlanEditorWindow.BringToFront();
			}
			else
			{
				Client.FlightPlanEditorWindow.Show();
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("select a Mission and create at least one flight", "Missing mission or flight");
		}
	}

	private void ChangeAdvisor(object sender, EventArgs e)
	{
		if (!_FilterRepository || DGV_AirTaskingOrder.SelectedRows.Count == 0 || DGV_AirTaskingOrder.Rows.Count <= 0)
		{
			return;
		}
		if (DGV_AirTaskingOrder.SelectedRows[0].Tag == null)
		{
			DGV_AirTaskingOrder.ClearSelection();
			int num = DGV_AirTaskingOrder.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow = DGV_AirTaskingOrder.Rows[0];
				if (!dataGridViewRow.Visible)
				{
					continue;
				}
				int num2 = dataGridViewRow.Cells.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (dataGridViewRow.Cells[j].Visible)
					{
						DGV_AirTaskingOrder.SelectionChanged -= ChangeAdvisor;
						DGV_AirTaskingOrder.CurrentCell = DGV_AirTaskingOrder.Rows[i].Cells[j];
						DGV_AirTaskingOrder.Rows[i].Selected = true;
						DGV_AirTaskingOrder.SelectionChanged += ChangeAdvisor;
					}
				}
			}
		}
		SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
		if (!Information.IsNothing(SelectedFlight))
		{
			m_TestsRepository = SelectedFlight.ObjectID;
			SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
		}
		EnableAndDisableButtons();
	}

	private void InitAdvisor(object sender, EventArgs e)
	{
		if (Client.CurrentSide.Missions.Count == 0)
		{
			return;
		}
		if (Information.IsNothing(SelectedMission))
		{
			if (Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_ATO_Only", TextCompare: true) == 0 || Operators.CompareString(AirTaskingOrderFilterSetting, "Filter_All", TextCompare: true) == 0 || Operators.CompareString(AirTaskingOrderFilterSetting, "", TextCompare: true) == 0)
			{
				Interaction.MsgBox("无法确定为其创建编队的任务。选择现有编队为同一任务创建新编队，或过滤特定任务的ATO。");
				return;
			}
			foreach (Mission mission in Client.CurrentSide.Missions)
			{
				if (Operators.CompareString(AirTaskingOrderFilterSetting, mission.ObjectID, TextCompare: true) == 0)
				{
					SelectedMission = mission;
				}
			}
		}
		if (Information.IsNothing(SelectedMission))
		{
			Interaction.MsgBox("无法生成新编队。该方是否有任务，ATO过滤器设置是否正确？");
			return;
		}
		string string_ = "新编队";
		int num = 0;
		while (CheckAdvisor(string_))
		{
			num++;
			string_ = "New Flight " + num;
		}
		Scenario scenario_ = Client.CurrentScenario;
		ref Mission selectedMission = ref SelectedMission;
		Mission.Flight flight_ = null;
		Mission.Flight flight_2 = new Mission.Flight(ref scenario_, ref selectedMission, ref flight_, string_, null, null, SelectedMission.FlightSize, bool_0: false);
		flight_2.ReferenceUnit_Name = "任意类型";
		flight_2.SetLoadoutName(Client.CurrentScenario, "任何挂载");
		if (Client.CurrentScenario.ActiveUnits.ContainsKey(flight_2.TakeOffLocation_HostUnitObjectID))
		{
			_ = Client.CurrentScenario.ActiveUnits[flight_2.TakeOffLocation_HostUnitObjectID];
		}
		SelectedMission.AddFlight(ref flight_2);
		GetAdvisor();
		if (Client.FlightPlanEditorWindow.Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
		{
			Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
		}
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		if (DGV_AirTaskingOrder.SelectedRows.Count <= 0)
		{
			return;
		}
		interpreterRepository = DGV_AirTaskingOrder.SelectedRows[0].Index;
		SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
		if (!Information.IsNothing(SelectedFlight))
		{
			m_TestsRepository = SelectedFlight.ObjectID;
			SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
		}
		if (interpreterRepository > 0)
		{
			DGV_AirTaskingOrder.Rows[0].Selected = false;
			DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = false;
		}
	}

	private bool CheckAdvisor(string string_0)
	{
		foreach (Mission.Flight flight in SelectedMission.FlightList)
		{
			if (Operators.CompareString(flight.Callsign, string_0, TextCompare: true) == 0)
			{
				return true;
			}
		}
		return false;
	}

	private void ConcatAdvisor(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedFlight))
		{
			Mission.Flight selectedFlight = SelectedFlight;
			Scenario scenario_ = Client.CurrentScenario;
			ref Mission.Flight selectedFlight2 = ref SelectedFlight;
			Mission.Flight flight_ = new Mission.Flight();
			ref Mission selectedMission = ref SelectedMission;
			int int_ = (int)SelectedFlight.CreatedBy;
			int int_2 = (int)SelectedFlight.EditedBy;
			selectedFlight.Copy(ref scenario_, ref selectedFlight2, ref flight_, bool_0: false, ref selectedMission, ref int_, ref int_2, bool_1: true, bool_2: true);
		}
		GetAdvisor();
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		if (Client.FlightPlanEditorWindow.Visible && SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
		{
			Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
		}
		RegistryParameterMessage.AwakeCustomer();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		if (DGV_AirTaskingOrder.SelectedRows.Count <= 0)
		{
			return;
		}
		PushAdvisor();
		interpreterRepository = DGV_AirTaskingOrder.SelectedRows[0].Index;
		SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
		if (!Information.IsNothing(SelectedFlight))
		{
			m_TestsRepository = SelectedFlight.ObjectID;
			SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
		}
		if (interpreterRepository > 0)
		{
			DGV_AirTaskingOrder.Rows[0].Selected = false;
			DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = true;
		}
	}

	private void InterruptAdvisor(object sender, EventArgs e)
	{
		if (DGV_AirTaskingOrder.SelectedRows.Count == 0)
		{
			return;
		}
		if (DGV_AirTaskingOrder.SelectedRows.Count == 1)
		{
			if (Information.IsNothing(SelectedFlight))
			{
				return;
			}
			if (Information.IsNothing(SelectedFlight))
			{
				GetAdvisor();
				return;
			}
			Mission selectedMission = SelectedMission;
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			selectedMission.DeleteFlight(ref scenario_, ref side_, ref SelectedFlight, SelectedFlight.ObjectID);
			Client.CurrentSide = side_;
			for (int i = DGV_AirTaskingOrder.Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow dataGridViewRow = DGV_AirTaskingOrder.Rows[i];
				if (dataGridViewRow.Selected && !Information.IsNothing((Mission.Flight)dataGridViewRow.Tag))
				{
					DGV_AirTaskingOrder.Rows.RemoveAt(i);
				}
			}
			SelectedFlight = null;
		}
		else
		{
			for (int j = DGV_AirTaskingOrder.Rows.Count - 1; j >= 0; j += -1)
			{
				DataGridViewRow dataGridViewRow2 = DGV_AirTaskingOrder.Rows[j];
				if (!dataGridViewRow2.Selected)
				{
					continue;
				}
				Mission.Flight flight_ = (Mission.Flight)dataGridViewRow2.Tag;
				if (Information.IsNothing(flight_))
				{
					continue;
				}
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (mission.FlightList.Contains(flight_))
					{
						Scenario scenario_2 = Client.CurrentScenario;
						Side side_2 = Client.CurrentSide;
						mission.DeleteFlight(ref scenario_2, ref side_2, ref flight_, flight_.ObjectID);
						Client.CurrentSide = side_2;
						break;
					}
				}
			}
		}
		LoadWindow();
		if (Client.FlightPlanEditorWindow.Visible && !SelectedMission.FlightList.Contains(Client.FlightPlanEditorWindow.SelectedFlight))
		{
			Client.FlightPlanEditorWindow.SelectedFlight = null;
			Client.FlightPlanEditorWindow.NewPolicy();
		}
		if (Client.FlightPlanAircraftLoadoutWindow.Visible && !SelectedMission.FlightList.Contains(Client.FlightPlanAircraftLoadoutWindow.SelectedFlight))
		{
			Client.FlightPlanAircraftLoadoutWindow.SelectedFlight = null;
			Client.FlightPlanAircraftLoadoutWindow.ReadSystem();
		}
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshAssignedUnits();
			Client.MissionEditorWindow.RefreshUnassignedUnits();
		}
		RegistryParameterMessage.AwakeCustomer();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		if (DGV_AirTaskingOrder.SelectedRows.Count <= 0)
		{
			return;
		}
		interpreterRepository = DGV_AirTaskingOrder.SelectedRows[0].Index;
		SelectedFlight = (Mission.Flight)DGV_AirTaskingOrder.SelectedRows[0].Tag;
		if (!Information.IsNothing(SelectedFlight))
		{
			m_TestsRepository = SelectedFlight.ObjectID;
			SelectedMission = Client.CurrentSide.Missions.Where((Mission mission_0) => Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0).ElementAtOrDefault(0);
		}
		if (interpreterRepository > 0)
		{
			DGV_AirTaskingOrder.Rows[0].Selected = false;
			DGV_AirTaskingOrder.Rows[interpreterRepository].Selected = true;
		}
	}

	private void RemoveAdvisor(object sender, EventArgs e)
	{
		SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Planned = (Game.GamePreferences.FlightPlansVisibilitySetting_Planned)ComboBox_PlannedFlightPlanVisibility.SelectedIndex;
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	private void FindAdvisor(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F11 && e.Control && e.Shift && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void SetAdvisor(object sender, EventArgs e)
	{
		SimConfiguration.DefaultGamePreferences.ShowFlightPlans_Airborne = (Game.GamePreferences.FlightPlansVisibilitySetting_Airborne)ComboBox_AirborneFlightPlanVisibility.SelectedIndex;
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	private void FillAdvisor(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight))
		{
			if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
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
		else
		{
			DarkMessageBox.ShowWarning("select a Mission and create at least one flight", "Missing mission or flight");
		}
	}

	private void CalculateAdvisor(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight) || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
		{
			return;
		}
		bool flag = false;
		int num = SelectedFlight.FlightPlan.Count() - 1;
		Waypoint waypoint_ = null;
		for (int i = 0; i <= num; i++)
		{
			waypoint_ = SelectedFlight.FlightPlan[i];
			if (waypoint_.Type == Waypoint.WaypointType.TakeOff)
			{
				flag = true;
				break;
			}
		}
		if (flag && !Information.IsNothing(waypoint_))
		{
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = false;
			Client.FlightPlanTimeWindow.RefreshStats(ref SelectedMission, ref SelectedFlight, ref waypoint_, Mission.Flight.FlightElement.LeadElement, bool_0: true);
			Client.FlightPlanTimeWindow.Show();
			Client.FlightPlanTimeWindow.BringToFront();
		}
	}

	private void PopAdvisor(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight) || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
		{
			return;
		}
		bool flag = false;
		int num = SelectedFlight.FlightPlan.Count() - 1;
		Waypoint waypoint_ = null;
		for (int i = 0; i <= num; i++)
		{
			waypoint_ = SelectedFlight.FlightPlan[i];
			if (waypoint_.Type == Waypoint.WaypointType.Target || waypoint_.Type == Waypoint.WaypointType.WeaponTarget || waypoint_.SearchReponse())
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = false;
			Client.FlightPlanTimeWindow.RefreshStats(ref SelectedMission, ref SelectedFlight, ref waypoint_, Mission.Flight.FlightElement.LeadElement, bool_0: true);
			Client.FlightPlanTimeWindow.Show();
			Client.FlightPlanTimeWindow.BringToFront();
		}
	}

	private void InstantiateAdvisor(object sender, EventArgs e)
	{
		bool bool_ = !Information.IsNothing(SelectedMission) && SelectedMission.Category == Mission.MissionCategory.Package;
		ClearFlightTime(SelectedFlight, bool_);
		RecalculateFlightPlanFuelAndTimes(bool_0: false, bool_1: true, bool_2: false, bool_3: true);
		FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
		Mission mission_ = null;
		Mission.Flight flight_ = null;
		Waypoint waypoint_ = null;
		flightPlanTimeWindow.RefreshStats(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None, bool_0: false);
		GetAdvisor();
		RegistryParameterMessage.AwakeCustomer();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public void EnableAndDisableButtons()
	{
		try
		{
			if (DGV_AirTaskingOrder.SelectedRows.Count == 1)
			{
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				if (Information.IsNothing(SelectedFlight))
				{
					Button_CopyFlight.Enabled = false;
					Button_DeleteFlight.Enabled = false;
					Button_FlightPlanEditor.Enabled = false;
					Button_ChangeAircraftType.Enabled = false;
					return;
				}
				Button_CopyFlight.Enabled = true;
				Button_DeleteFlight.Enabled = true;
				Button_FlightPlanEditor.Enabled = true;
				if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					Button_ChangeAircraftType.Enabled = true;
				}
				else
				{
					Button_ChangeAircraftType.Enabled = false;
				}
				if (SelectedFlight.Type != 0 || SelectedFlight.Task == Mission._FlightTask.QRA)
				{
					return;
				}
				int num = DGV_AirTaskingOrder.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!DGV_AirTaskingOrder.Rows[i].Selected || Information.IsNothing(SelectedFlight))
					{
						continue;
					}
					if (SelectedFlight.FlightPlan.Count() <= 0)
					{
						break;
					}
					int num2 = SelectedFlight.FlightPlan.Count() - 1;
					bool flag = false;
					int num3 = num2;
					for (int j = 0; j <= num3; j++)
					{
						Waypoint waypoint = SelectedFlight.FlightPlan[j];
						if (!flag && !Information.IsNothing(waypoint.Time_Zulu))
						{
							flag = true;
						}
						if (waypoint.Type == Waypoint.WaypointType.TakeOff)
						{
							if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
							{
								Button_ChangeTakeOffTime.Enabled = true;
							}
							else
							{
								Button_ChangeTakeOffTime.Enabled = false;
							}
						}
						else if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget || waypoint.SearchReponse())
						{
							Button_ChangeObjectiveTime.Enabled = true;
							break;
						}
					}
					if (flag)
					{
						Button_ClearTime.Enabled = true;
					}
					break;
				}
			}
			else if (DGV_AirTaskingOrder.SelectedRows.Count <= 1)
			{
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_CopyFlight.Enabled = false;
				Button_DeleteFlight.Enabled = false;
				Button_FlightPlanEditor.Enabled = false;
				Button_ChangeAircraftType.Enabled = false;
			}
			else
			{
				Button_ChangeTakeOffTime.Enabled = false;
				Button_ChangeObjectiveTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_CopyFlight.Enabled = false;
				Button_DeleteFlight.Enabled = true;
				Button_FlightPlanEditor.Enabled = false;
				Button_ChangeAircraftType.Enabled = false;
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

	public void EnableAndDisableCells()
	{
		try
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = ((IEnumerable)DGV_AirTaskingOrder.Rows).GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					Mission.Flight flight = (Mission.Flight)dataGridViewRow.Tag;
					if (Information.IsNothing(flight))
					{
						continue;
					}
					if (flight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
					{
						if (dataGridViewRow.Cells["Type"].ReadOnly)
						{
							dataGridViewRow.Cells["Type"].ReadOnly = false;
							dataGridViewRow.Cells["Type"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["Type"].Style.SelectionBackColor = default(Color);
						}
						if (dataGridViewRow.Cells["Priority"].ReadOnly)
						{
							dataGridViewRow.Cells["Priority"].ReadOnly = false;
							dataGridViewRow.Cells["Priority"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["Priority"].Style.SelectionBackColor = default(Color);
						}
						if (dataGridViewRow.Cells["DesiredAircraftQty"].ReadOnly)
						{
							dataGridViewRow.Cells["DesiredAircraftQty"].ReadOnly = false;
							dataGridViewRow.Cells["DesiredAircraftQty"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["DesiredAircraftQty"].Style.SelectionBackColor = default(Color);
						}
						if (dataGridViewRow.Cells["MinimumAircraftQty"].ReadOnly)
						{
							dataGridViewRow.Cells["MinimumAircraftQty"].ReadOnly = false;
							dataGridViewRow.Cells["MinimumAircraftQty"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["MinimumAircraftQty"].Style.SelectionBackColor = default(Color);
						}
					}
					else
					{
						dataGridViewRow.Cells["Type"].ReadOnly = true;
						dataGridViewRow.Cells["Type"].Style.BackColor = Color.LightGray;
						dataGridViewRow.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
						dataGridViewRow.Cells["Type"].Style.SelectionForeColor = Color.Black;
						dataGridViewRow.Cells["Priority"].ReadOnly = true;
						dataGridViewRow.Cells["Priority"].Style.BackColor = Color.LightGray;
						dataGridViewRow.Cells["Priority"].Style.SelectionBackColor = Color.LightGray;
						dataGridViewRow.Cells["Priority"].Style.SelectionForeColor = Color.Black;
						dataGridViewRow.Cells["DesiredAircraftQty"].ReadOnly = true;
						dataGridViewRow.Cells["DesiredAircraftQty"].Style.BackColor = Color.LightGray;
						dataGridViewRow.Cells["DesiredAircraftQty"].Style.SelectionBackColor = Color.LightGray;
						dataGridViewRow.Cells["DesiredAircraftQty"].Style.SelectionForeColor = Color.Black;
						dataGridViewRow.Cells["MinimumAircraftQty"].ReadOnly = true;
						dataGridViewRow.Cells["MinimumAircraftQty"].Style.BackColor = Color.LightGray;
						dataGridViewRow.Cells["MinimumAircraftQty"].Style.SelectionBackColor = Color.LightGray;
						dataGridViewRow.Cells["MinimumAircraftQty"].Style.SelectionForeColor = Color.Black;
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

	private void CreateAdvisor(object sender, EventArgs e)
	{
		if (ComboBox_AirTaskingOrderFilter.SelectedIndex == 0)
		{
			AirTaskingOrderFilterSetting = "Filter_ATO_Only";
			GetAdvisor();
			return;
		}
		if (ComboBox_AirTaskingOrderFilter.SelectedIndex == 1)
		{
			AirTaskingOrderFilterSetting = "Filter_All";
			GetAdvisor();
			return;
		}
		string right = Conversions.ToString(ComboBox_AirTaskingOrderFilter.SelectedItem);
		bool flag = false;
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (Operators.CompareString(mission.Name, right, TextCompare: true) == 0)
			{
				SelectedMission = mission;
				AirTaskingOrderFilterSetting = mission.ObjectID;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			AirTaskingOrderFilterSetting = "";
		}
		if (flag && Operators.CompareString(SelectedMission.Name, right, TextCompare: true) == 0)
		{
			interpreterRepository = 0;
			SelectedFlight = null;
			m_TestsRepository = "";
		}
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = ((IEnumerable)DGV_AirTaskingOrder.Rows).GetEnumerator();
			while (enumerator2.MoveNext())
			{
				((DataGridViewRow)enumerator2.Current).Selected = false;
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		GetAdvisor();
	}

	private void CompareAdvisor(object sender, EventArgs e)
	{
		m_ComposerRepository = (AirTaskingOrderSortType)ComboBox_AirTaskingOrderSorting.SelectedIndex;
		GetAdvisor();
	}

	public static void UpdateWingmanWaypoints(Mission.Flight flight_0, ref Waypoint waypoint_0, ref Mission mission_0, ref Waypoint[] waypoint_1, Mission.Flight.FlightElement flightElement_0)
	{
		try
		{
			LockWingmanTargetWaypoints(flight_0, ref mission_0, ref waypoint_0, bool_0: true);
			if (flightElement_0 == Mission.Flight.FlightElement.LeadElement)
			{
				return;
			}
			bool? flag = null;
			bool bool_ = true;
			Waypoint[] array = waypoint_1;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				Waypoint waypoint_2 = array[i];
				bool flag2 = mission_0.MissionClass == Mission._MissionClass.Strike && (waypoint_2.Type == Waypoint.WaypointType.Target || waypoint_2.Type == Waypoint.WaypointType.WeaponTarget);
				if (Information.IsNothing(waypoint_2.Waypoint_LeadElementWingman) || waypoint_2.Waypoint_LeadElementWingman != waypoint_0)
				{
					if (Information.IsNothing(waypoint_2.Waypoint_SecondElement) || waypoint_2.Waypoint_SecondElement != waypoint_0)
					{
						if (Information.IsNothing(waypoint_2.Waypoint_SecondElementWingman) || waypoint_2.Waypoint_SecondElementWingman != waypoint_0)
						{
							if (Information.IsNothing(waypoint_2.Waypoint_ThirdElement) || waypoint_2.Waypoint_ThirdElement != waypoint_0)
							{
								if (Information.IsNothing(waypoint_2.Waypoint_ThirdElementWingman) || waypoint_2.Waypoint_ThirdElementWingman != waypoint_0)
								{
									continue;
								}
								if (Information.IsNothing(flag))
								{
									if (Information.IsNothing(waypoint_2.Time_Zulu))
									{
										flag = true;
									}
									else if (flag2 && Interaction.MsgBox("You have chosen To Set the time For a Target waypoint. Would you also Like To update Target waypoint times For wingmen waypoints?") == MsgBoxResult.Yes)
									{
										flag = true;
										bool_ = false;
									}
									else
									{
										flag = false;
									}
								}
								if (!flag.GetValueOrDefault())
								{
									break;
								}
								if (flag2)
								{
									if (waypoint_0.Leg_Time_Weapon <= 0f)
									{
										waypoint_2.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 5f);
										waypoint_2.Time_Zulu_Weapon = null;
									}
									else
									{
										waypoint_2.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 5f);
										waypoint_2.Time_Zulu = waypoint_2.Time_Zulu_Weapon.Value.AddSeconds(0f - waypoint_2.Leg_Time_Weapon);
									}
								}
								else
								{
									waypoint_2.Time_Zulu = waypoint_0.Time_Zulu;
									waypoint_2.Time_Zulu_Weapon = null;
								}
								waypoint_2.TimeFixed = waypoint_0.TimeFixed;
								LockWingmanTargetWaypoints(flight_0, ref mission_0, ref waypoint_2, bool_);
								break;
							}
							if (Information.IsNothing(flag))
							{
								if (Information.IsNothing(waypoint_2.Time_Zulu))
								{
									flag = true;
								}
								else if (flag2 && Interaction.MsgBox("You have chosen To Set the time For a Target waypoint. Would you also Like To update Target waypoint times For wingmen waypoints?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
								{
									flag = true;
									bool_ = false;
								}
								else
								{
									flag = false;
								}
							}
							if (!flag.GetValueOrDefault())
							{
								break;
							}
							if (flag2)
							{
								if (waypoint_0.Leg_Time_Weapon <= 0f)
								{
									waypoint_2.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 4f);
									waypoint_2.Time_Zulu_Weapon = null;
								}
								else
								{
									waypoint_2.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 4f);
									waypoint_2.Time_Zulu = waypoint_2.Time_Zulu_Weapon.Value.AddSeconds(0f - waypoint_2.Leg_Time_Weapon);
								}
							}
							else
							{
								waypoint_2.Time_Zulu = waypoint_0.Time_Zulu;
								waypoint_2.Time_Zulu_Weapon = null;
							}
							waypoint_2.TimeFixed = waypoint_0.TimeFixed;
							LockWingmanTargetWaypoints(flight_0, ref mission_0, ref waypoint_2, bool_);
							break;
						}
						if (Information.IsNothing(flag))
						{
							if (Information.IsNothing(waypoint_2.Time_Zulu))
							{
								flag = true;
							}
							else if (flag2 && Interaction.MsgBox("You have chosen To Set the time For a Target waypoint. Would you also Like To update Target waypoint times For wingmen waypoints?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
							{
								flag = true;
								bool_ = false;
							}
							else
							{
								flag = false;
							}
						}
						if (!flag.GetValueOrDefault())
						{
							break;
						}
						if (flag2)
						{
							if (waypoint_0.Leg_Time_Weapon <= 0f)
							{
								waypoint_2.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 3f);
								waypoint_2.Time_Zulu_Weapon = null;
							}
							else
							{
								waypoint_2.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 3f);
								waypoint_2.Time_Zulu = waypoint_2.Time_Zulu_Weapon.Value.AddSeconds(0f - waypoint_2.Leg_Time_Weapon);
							}
						}
						else
						{
							waypoint_2.Time_Zulu = waypoint_0.Time_Zulu;
							waypoint_2.Time_Zulu_Weapon = null;
						}
						waypoint_2.TimeFixed = waypoint_0.TimeFixed;
						LockWingmanTargetWaypoints(flight_0, ref mission_0, ref waypoint_2, bool_);
						break;
					}
					if (Information.IsNothing(flag))
					{
						if (Information.IsNothing(waypoint_2.Time_Zulu))
						{
							flag = true;
						}
						else if (flag2 && Interaction.MsgBox("You have chosen To Set the time For a Target waypoint. Would you also Like To update Target waypoint times For wingmen waypoints?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
						{
							flag = true;
							bool_ = false;
						}
						else
						{
							flag = false;
						}
					}
					if (!flag.GetValueOrDefault())
					{
						break;
					}
					if (flag2)
					{
						if (waypoint_0.Leg_Time_Weapon <= 0f)
						{
							waypoint_2.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 2f);
							waypoint_2.Time_Zulu_Weapon = null;
						}
						else
						{
							waypoint_2.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds((0f - waypoint_2.Separation_Time) * 2f);
							waypoint_2.Time_Zulu = waypoint_2.Time_Zulu_Weapon.Value.AddSeconds(0f - waypoint_2.Leg_Time_Weapon);
						}
					}
					else
					{
						waypoint_2.Time_Zulu = waypoint_0.Time_Zulu;
						waypoint_2.Time_Zulu_Weapon = null;
					}
					waypoint_2.TimeFixed = waypoint_0.TimeFixed;
					LockWingmanTargetWaypoints(flight_0, ref mission_0, ref waypoint_2, bool_);
					break;
				}
				if (Information.IsNothing(flag))
				{
					if (Information.IsNothing(waypoint_2.Time_Zulu))
					{
						flag = true;
					}
					else if (flag2 && Interaction.MsgBox("You have chosen To Set the time For a Target waypoint. Would you also Like To update Target waypoint times For wingmen waypoints?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
					{
						flag = true;
						bool_ = false;
					}
					else
					{
						flag = false;
					}
				}
				if (!flag.GetValueOrDefault())
				{
					break;
				}
				if (flag2)
				{
					if (waypoint_0.Leg_Time_Weapon <= 0f)
					{
						waypoint_2.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds(0f - waypoint_2.Separation_Time);
						waypoint_2.Time_Zulu_Weapon = null;
					}
					else
					{
						waypoint_2.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds(0f - waypoint_2.Separation_Time);
						waypoint_2.Time_Zulu = waypoint_2.Time_Zulu_Weapon.Value.AddSeconds(0f - waypoint_2.Leg_Time_Weapon);
					}
				}
				else
				{
					waypoint_2.Time_Zulu = waypoint_0.Time_Zulu;
					waypoint_2.Time_Zulu_Weapon = null;
				}
				waypoint_2.TimeFixed = waypoint_0.TimeFixed;
				LockWingmanTargetWaypoints(flight_0, ref mission_0, ref waypoint_2, bool_);
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101343", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ChangeFlightType(Mission.Flight flight_0, ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, Mission._FlightType _FlightType_0)
	{
		try
		{
			switch (_FlightType_0)
			{
			case Mission._FlightType.FlightplanTemplate:
				if (Interaction.MsgBox("You have selected To change the flightplan To Template. This will remove all aircraft (If any) from the flight And remove flightplan waypoint times (If Set). Do you wish To proceed?", MsgBoxStyle.YesNo) == MsgBoxResult.Yes)
				{
					ClearFlightTime(flight_0, bool_0: false);
					mission_0.ClearAllAircraft_ReplaceWithEmptySlots(ref scenario_0, ref side_0, ref flight_0);
					flight_0.Type = _FlightType_0;
					Scenario scenario_ = scenario_0;
					Mission strike_ = mission_0;
					ActiveUnit referenceUnit = flight_0.GetReferenceUnit(scenario_0);
					Mission.Flight flight_ = flight_0;
					Mission.Flight flight;
					Waypoint[] waypoint_ = (flight = flight_0).FlightPlan;
					float float_ = 0f;
					float float_2 = 0f;
					MissionPlanner.ConnectTokenizer(scenario_, strike_, referenceUnit, flight_, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
					flight.FlightPlan = waypoint_;
				}
				break;
			case Mission._FlightType.Flightplan:
				flight_0.Type = _FlightType_0;
				break;
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

	public static void LockWingmanTargetWaypoints(Mission.Flight flight_0, ref Mission mission_0, ref Waypoint waypoint_0, bool bool_0)
	{
		try
		{
			if ((waypoint_0.Type != Waypoint.WaypointType.Target && waypoint_0.Type != Waypoint.WaypointType.WeaponTarget) || !waypoint_0.InvokeReponse())
			{
				return;
			}
			bool flag = true;
			if (!Information.IsNothing(waypoint_0.Waypoint_LeadElementWingman) && waypoint_0.Waypoint_LeadElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_SecondElement) && waypoint_0.Waypoint_SecondElement.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_SecondElementWingman) && waypoint_0.Waypoint_SecondElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElement) && waypoint_0.Waypoint_ThirdElement.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElementWingman) && waypoint_0.Waypoint_ThirdElementWingman.TimeFixed != Waypoint.FixedFree.Relative)
			{
				flag = false;
			}
			if (flag)
			{
				bool_0 = false;
			}
			if ((bool_0 && Interaction.MsgBox("You have chosen To Set And lock the time For a Target waypoint. Would you also Like To Set relative times For wingman waypoints? The mission's default time separation interval between aircraft will be used: " + Conversions.ToString(waypoint_0.Separation_Time) + "秒。") != MsgBoxResult.Yes) || Information.IsNothing(mission_0))
			{
				return;
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_LeadElementWingman))
			{
				waypoint_0.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
				waypoint_0.Waypoint_LeadElementWingman.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds(waypoint_0.Separation_Time);
				if (Information.IsNothing(waypoint_0.Time_Zulu_Weapon))
				{
					waypoint_0.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
				}
				else
				{
					waypoint_0.Waypoint_LeadElementWingman.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds(waypoint_0.Separation_Time);
				}
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_SecondElement))
			{
				waypoint_0.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Relative;
				waypoint_0.Waypoint_SecondElement.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds(waypoint_0.Separation_Time * 2f);
				if (Information.IsNothing(waypoint_0.Time_Zulu_Weapon))
				{
					waypoint_0.Waypoint_SecondElement.Time_Zulu_Weapon = null;
				}
				else
				{
					waypoint_0.Waypoint_SecondElement.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds(waypoint_0.Separation_Time * 2f);
				}
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_SecondElementWingman))
			{
				waypoint_0.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
				waypoint_0.Waypoint_SecondElementWingman.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds(waypoint_0.Separation_Time * 3f);
				if (Information.IsNothing(waypoint_0.Time_Zulu_Weapon))
				{
					waypoint_0.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
				}
				else
				{
					waypoint_0.Waypoint_SecondElementWingman.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds(waypoint_0.Separation_Time * 3f);
				}
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElement))
			{
				waypoint_0.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Relative;
				waypoint_0.Waypoint_ThirdElement.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds(waypoint_0.Separation_Time * 4f);
				if (Information.IsNothing(waypoint_0.Time_Zulu_Weapon))
				{
					waypoint_0.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
				}
				else
				{
					waypoint_0.Waypoint_ThirdElement.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds(waypoint_0.Separation_Time * 4f);
				}
			}
			if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElementWingman))
			{
				waypoint_0.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Relative;
				waypoint_0.Waypoint_ThirdElementWingman.Time_Zulu = waypoint_0.Time_Zulu.Value.AddSeconds(waypoint_0.Separation_Time * 5f);
				if (Information.IsNothing(waypoint_0.Time_Zulu_Weapon))
				{
					waypoint_0.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
				}
				else
				{
					waypoint_0.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = waypoint_0.Time_Zulu_Weapon.Value.AddSeconds(waypoint_0.Separation_Time * 5f);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101342", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ClearFlightTime(Mission.Flight flight_0, bool bool_0)
	{
		try
		{
			if (bool_0 && Interaction.MsgBox("任务包中的飞行计划应始终设置航点时间！您确定要清除航点时间吗？", MsgBoxStyle.OkCancel) == MsgBoxResult.Cancel)
			{
				return;
			}
			int num = flight_0.FlightPlan.Count() - 1;
			for (int i = 0; i <= num; i++)
			{
				Waypoint waypoint = flight_0.FlightPlan[i];
				waypoint.Time_Zulu = null;
				waypoint.Time_Zulu_Weapon = null;
				waypoint.Station_Time = 0f;
				waypoint.TimeFixed = Waypoint.FixedFree.Free;
				if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
				{
					waypoint.Waypoint_LeadElementWingman.Time_Zulu = null;
					waypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = null;
					waypoint.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
				{
					waypoint.Waypoint_SecondElement.Time_Zulu = null;
					waypoint.Waypoint_SecondElement.Time_Zulu_Weapon = null;
					waypoint.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
				{
					waypoint.Waypoint_SecondElementWingman.Time_Zulu = null;
					waypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = null;
					waypoint.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
				{
					waypoint.Waypoint_ThirdElement.Time_Zulu = null;
					waypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = null;
					waypoint.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Free;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
				{
					waypoint.Waypoint_ThirdElementWingman.Time_Zulu = null;
					waypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = null;
					waypoint.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Free;
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

	[CompilerGenerated]
	private bool ReadAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool DisableAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool UpdateAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool InsertAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool PrepareAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool ReflectAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool VisitAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool RestartAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool TestAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}

	[CompilerGenerated]
	private bool StopAdvisor(Mission mission_0)
	{
		return Operators.CompareString(mission_0.ObjectID, SelectedFlight.ParentMissionOrPackageObjectID, TextCompare: true) == 0;
	}
}
