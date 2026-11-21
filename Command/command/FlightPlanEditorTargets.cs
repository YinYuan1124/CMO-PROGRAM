using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorTargets : DarkSecondaryFormBase
{
	public enum WeaponeeringLostTargetSelection : byte
	{
		ExpenOrdnancedOnCoordinate,
		FindNewTarget_OtherwiseExpendOrdnanceOnCoordinate,
		BringBackOrJettisonOrdnance,
		FindNewTarget_OtherwiseBringBackOrJettisonOrdnance
	}

	[CompilerGenerated]
	private sealed class RegCallbackCandidate
	{
		public Waypoint Local_theWaypoint;

		internal double CancelInterruptiblePage(Contact theC)
		{
			return Math2.CancelClass(Local_theWaypoint.Latitude, Local_theWaypoint.Longitude, theC.GetLatitude(), theC.GetLongitude());
		}
	}

	[CompilerGenerated]
	private sealed class SpecificationMap
	{
		public Waypoint Local_theWaypoint;

		internal double VerifyInterruptiblePage(Contact theC)
		{
			return Math2.CancelClass(Local_theWaypoint.Latitude, Local_theWaypoint.Longitude, theC.GetLatitude(), theC.GetLongitude());
		}
	}

	private IContainer _WriterTask;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_TargteeringMethod")]
	private DarkUIComboBox specificationTask;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private Label m_WatcherTask;

	[CompilerGenerated]
	[AccessedThroughProperty("SplitContainer1")]
	private SplitContainer reponseTask;

	[AccessedThroughProperty("TargetName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_PoolTask;

	[AccessedThroughProperty("AssignedWeapons")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn taskTask;

	[AccessedThroughProperty("Time_Local")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn testsTask;

	[CompilerGenerated]
	[AccessedThroughProperty("WeaponType")]
	private TreeGridColumn containerTask;

	[AccessedThroughProperty("Target")]
	[CompilerGenerated]
	private DataGridViewComboBoxColumn composerTask;

	[CompilerGenerated]
	[AccessedThroughProperty("LostTarget")]
	private DataGridViewComboBoxColumn modelTask;

	[CompilerGenerated]
	[AccessedThroughProperty("FiringRange")]
	private DataGridViewComboBoxColumn customerTask;

	[AccessedThroughProperty("Button_EditToT")]
	[CompilerGenerated]
	private DarkButton m_RefTask;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Weaponeering")]
	private DarkTreeGridView errorTask;

	[AccessedThroughProperty("Button_EditWRA")]
	[CompilerGenerated]
	private DarkButton m_CodeTask;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Targeteering")]
	private DarkTreeGridView m_ConnectionTask;

	[AccessedThroughProperty("Button_EditArea")]
	[CompilerGenerated]
	private DarkButton contextTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddArea")]
	private DarkButton m_StatusTask;

	[AccessedThroughProperty("Button_EditPreliminaryTargetLocation")]
	[CompilerGenerated]
	private DarkButton _ProccesorTask;

	[AccessedThroughProperty("Button_AddPreliminaryTargetLocation")]
	[CompilerGenerated]
	private DarkButton m_StrategyTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditCoordinate")]
	private DarkButton _ConfigurationTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DecreasePriority")]
	private DarkButton m_IndexerTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_IncreasePriority")]
	private DarkButton m_ResolverTask;

	[AccessedThroughProperty("Button_AddHighlighted")]
	[CompilerGenerated]
	private DarkButton _ServerTask;

	[AccessedThroughProperty("Button_EditRoute")]
	[CompilerGenerated]
	private DarkButton _AdapterTask;

	[AccessedThroughProperty("Button_SetTimeReferenceWeapon")]
	[CompilerGenerated]
	private DarkButton _SchemaTask;

	[AccessedThroughProperty("CB_PreplannedOnly")]
	[CompilerGenerated]
	private DarkCheckBox utilsTask;

	[AccessedThroughProperty("GroupBox_Targeteering")]
	[CompilerGenerated]
	private DarkGroupBox m_PredicateTask;

	[AccessedThroughProperty("GroupBox_Weaponeering")]
	[CompilerGenerated]
	private DarkGroupBox singletonTask;

	public int SelectedTargeteeringTab;

	public int SelectedRow;

	private List<WeaponRec> recordTask;

	private string _ExceptionTask;

	public Waypoint TargetWaypoint_Lead;

	public Waypoint IPWaypoint_Lead;

	private bool m_AttrTask;

	private bool visitorTask;

	private List<string> m_ExporterTask;

	private List<string> m_PrototypeTask;

	public Mission SelectedMission;

	public Mission.Flight SelectedFlight;

	public List<string> AircraftList;

	public string SelectedAircraft;

	internal DarkUIComboBox ComboBox_TargteeringMethod
	{
		[CompilerGenerated]
		get
		{
			return specificationTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortBroadcaster;
			DarkUIComboBox darkUIComboBox = specificationTask;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			specificationTask = value;
			darkUIComboBox = specificationTask;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal Label Label3
	{
		[CompilerGenerated]
		get
		{
			return m_WatcherTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WatcherTask = value;
		}
	}

	internal SplitContainer SplitContainer1
	{
		[CompilerGenerated]
		get
		{
			return reponseTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			reponseTask = value;
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal TreeGridColumn ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn TargetName
	{
		[CompilerGenerated]
		get
		{
			return m_PoolTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PoolTask = value;
		}
	}

	internal DataGridViewTextBoxColumn AssignedWeapons
	{
		[CompilerGenerated]
		get
		{
			return taskTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			taskTask = value;
		}
	}

	[field: AccessedThroughProperty("Time_Zulu")]
	internal DataGridViewTextBoxColumn Time_Zulu
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Time_Local
	{
		[CompilerGenerated]
		get
		{
			return testsTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsTask = value;
		}
	}

	[field: AccessedThroughProperty("Coordinates")]
	internal DataGridViewTextBoxColumn Coordinates
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TreeGridColumn WeaponType
	{
		[CompilerGenerated]
		get
		{
			return containerTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			containerTask = value;
		}
	}

	internal DataGridViewComboBoxColumn Target
	{
		[CompilerGenerated]
		get
		{
			return composerTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			composerTask = value;
		}
	}

	internal DataGridViewComboBoxColumn LostTarget
	{
		[CompilerGenerated]
		get
		{
			return modelTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelTask = value;
		}
	}

	[field: AccessedThroughProperty("WeaponQty")]
	internal DataGridViewComboBoxColumn WeaponQty
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewComboBoxColumn FiringRange
	{
		[CompilerGenerated]
		get
		{
			return customerTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			customerTask = value;
		}
	}

	[field: AccessedThroughProperty("Route")]
	internal DataGridViewTextBoxColumn Route
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkButton Button_EditToT
	{
		[CompilerGenerated]
		get
		{
			return m_RefTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RefTask = value;
		}
	}

	private DarkTreeGridView TGV_Weaponeering
	{
		[CompilerGenerated]
		get
		{
			return errorTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ExpandingEventHandler value2 = ManageBroadcaster;
			CollapsingEventHandler value3 = CountIdentifier;
			DataGridViewCellEventHandler value4 = AddIdentifier;
			DataGridViewCellEventHandler value5 = ComputeIdentifier;
			EventHandler value6 = CallIdentifier;
			DarkTreeGridView darkTreeGridView = errorTask;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding -= value2;
				darkTreeGridView.NodeCollapsing -= value3;
				darkTreeGridView.CellClick -= value4;
				darkTreeGridView.CellValueChanged -= value5;
				darkTreeGridView.CurrentCellDirtyStateChanged -= value6;
			}
			errorTask = value;
			darkTreeGridView = errorTask;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeExpanding += value2;
				darkTreeGridView.NodeCollapsing += value3;
				darkTreeGridView.CellClick += value4;
				darkTreeGridView.CellValueChanged += value5;
				darkTreeGridView.CurrentCellDirtyStateChanged += value6;
			}
		}
	}

	internal DarkButton Button_EditWRA
	{
		[CompilerGenerated]
		get
		{
			return m_CodeTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeTask = value;
		}
	}

	private DarkTreeGridView TGV_Targeteering
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ExpandingEventHandler value2 = RegisterBroadcaster;
			CollapsingEventHandler value3 = RevertBroadcaster;
			DataGridViewCellEventHandler value4 = DeleteIdentifier;
			DataGridViewCellEventHandler value5 = DestroyIdentifier;
			EventHandler value6 = SelectIdentifier;
			DarkTreeGridView connectionTask = m_ConnectionTask;
			if (connectionTask != null)
			{
				connectionTask.NodeExpanding -= value2;
				connectionTask.NodeCollapsing -= value3;
				connectionTask.CellClick -= value4;
				connectionTask.CellValueChanged -= value5;
				connectionTask.CurrentCellDirtyStateChanged -= value6;
			}
			m_ConnectionTask = value;
			connectionTask = m_ConnectionTask;
			if (connectionTask != null)
			{
				connectionTask.NodeExpanding += value2;
				connectionTask.NodeCollapsing += value3;
				connectionTask.CellClick += value4;
				connectionTask.CellValueChanged += value5;
				connectionTask.CurrentCellDirtyStateChanged += value6;
			}
		}
	}

	internal DarkButton Button_EditArea
	{
		[CompilerGenerated]
		get
		{
			return contextTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateIdentifier;
			DarkButton darkButton = contextTask;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			contextTask = value;
			darkButton = contextTask;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkButton Button_AddArea
	{
		[CompilerGenerated]
		get
		{
			return m_StatusTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StatusTask = value;
		}
	}

	internal DarkButton Button_EditPreliminaryTargetLocation
	{
		[CompilerGenerated]
		get
		{
			return _ProccesorTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewIdentifier;
			DarkButton proccesorTask = _ProccesorTask;
			if (proccesorTask != null)
			{
				proccesorTask.Click -= value2;
			}
			_ProccesorTask = value;
			proccesorTask = _ProccesorTask;
			if (proccesorTask != null)
			{
				proccesorTask.Click += value2;
			}
		}
	}

	internal DarkButton Button_AddPreliminaryTargetLocation
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StrategyTask = value;
		}
	}

	internal DarkButton Button_EditCoordinate
	{
		[CompilerGenerated]
		get
		{
			return _ConfigurationTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginIdentifier;
			DarkButton configurationTask = _ConfigurationTask;
			if (configurationTask != null)
			{
				configurationTask.Click -= value2;
			}
			_ConfigurationTask = value;
			configurationTask = _ConfigurationTask;
			if (configurationTask != null)
			{
				configurationTask.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Button_AddCoordinate")]
	internal DarkButton Button_AddCoordinate
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkButton Button_DecreasePriority
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IndexerTask = value;
		}
	}

	internal DarkButton Button_IncreasePriority
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ResolverTask = value;
		}
	}

	[field: AccessedThroughProperty("Button_RemoveSelected")]
	internal DarkButton Button_RemoveSelected
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkButton Button_AddHighlighted
	{
		[CompilerGenerated]
		get
		{
			return _ServerTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutIdentifier;
			DarkButton serverTask = _ServerTask;
			if (serverTask != null)
			{
				serverTask.Click -= value2;
			}
			_ServerTask = value;
			serverTask = _ServerTask;
			if (serverTask != null)
			{
				serverTask.Click += value2;
			}
		}
	}

	internal DarkButton Button_EditRoute
	{
		[CompilerGenerated]
		get
		{
			return _AdapterTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewIdentifier;
			DarkButton adapterTask = _AdapterTask;
			if (adapterTask != null)
			{
				adapterTask.Click -= value2;
			}
			_AdapterTask = value;
			adapterTask = _AdapterTask;
			if (adapterTask != null)
			{
				adapterTask.Click += value2;
			}
		}
	}

	internal DarkButton Button_SetTimeReferenceWeapon
	{
		[CompilerGenerated]
		get
		{
			return _SchemaTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushIdentifier;
			DarkButton schemaTask = _SchemaTask;
			if (schemaTask != null)
			{
				schemaTask.Click -= value2;
			}
			_SchemaTask = value;
			schemaTask = _SchemaTask;
			if (schemaTask != null)
			{
				schemaTask.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_PreplannedOnly
	{
		[CompilerGenerated]
		get
		{
			return utilsTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			utilsTask = value;
		}
	}

	internal DarkGroupBox GroupBox_Targeteering
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PredicateTask = value;
		}
	}

	internal DarkGroupBox GroupBox_Weaponeering
	{
		[CompilerGenerated]
		get
		{
			return singletonTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			singletonTask = value;
		}
	}

	public FlightPlanEditorTargets()
	{
		base.FormClosing += AwakeBroadcaster;
		base.VisibleChanged += QueryBroadcaster;
		base.KeyDown += GetIdentifier;
		SelectedRow = 0;
		m_ExporterTask = new List<string>();
		m_PrototypeTask = new List<string>();
		AircraftList = new List<string>();
		PublishBroadcaster();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _WriterTask != null)
			{
				_WriterTask.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PublishBroadcaster()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		TGV_Weaponeering = new DarkTreeGridView();
		WeaponType = new TreeGridColumn();
		Target = new DataGridViewComboBoxColumn();
		LostTarget = new DataGridViewComboBoxColumn();
		WeaponQty = new DataGridViewComboBoxColumn();
		FiringRange = new DataGridViewComboBoxColumn();
		Route = new DataGridViewTextBoxColumn();
		TGV_Targeteering = new DarkTreeGridView();
		ID = new TreeGridColumn();
		TargetName = new DataGridViewTextBoxColumn();
		AssignedWeapons = new DataGridViewTextBoxColumn();
		Time_Zulu = new DataGridViewTextBoxColumn();
		Time_Local = new DataGridViewTextBoxColumn();
		Coordinates = new DataGridViewTextBoxColumn();
		SplitContainer1 = new SplitContainer();
		GroupBox_Targeteering = new DarkGroupBox();
		Button_EditArea = new DarkButton();
		Button_AddArea = new DarkButton();
		Button_EditToT = new DarkButton();
		Button_EditPreliminaryTargetLocation = new DarkButton();
		Button_AddPreliminaryTargetLocation = new DarkButton();
		Button_EditCoordinate = new DarkButton();
		Button_AddCoordinate = new DarkButton();
		Button_DecreasePriority = new DarkButton();
		Button_IncreasePriority = new DarkButton();
		Button_RemoveSelected = new DarkButton();
		CB_PreplannedOnly = new DarkCheckBox();
		Button_AddHighlighted = new DarkButton();
		ComboBox_TargteeringMethod = new DarkUIComboBox();
		Label3 = new Label();
		GroupBox_Weaponeering = new DarkGroupBox();
		Button_SetTimeReferenceWeapon = new DarkButton();
		Button_EditRoute = new DarkButton();
		Button_EditWRA = new DarkButton();
		((ISupportInitialize)TGV_Weaponeering).BeginInit();
		((ISupportInitialize)TGV_Targeteering).BeginInit();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.Panel2.SuspendLayout();
		SplitContainer1.SuspendLayout();
		GroupBox_Targeteering.SuspendLayout();
		GroupBox_Weaponeering.SuspendLayout();
		SuspendLayout();
		TGV_Weaponeering.AllowUserToAddRows = false;
		TGV_Weaponeering.AllowUserToDeleteRows = false;
		TGV_Weaponeering.AllowUserToOrderColumns = true;
		TGV_Weaponeering.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_Weaponeering.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		TGV_Weaponeering.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
		TGV_Weaponeering.BackgroundColor = Color.FromArgb(43, 43, 43);
		TGV_Weaponeering.BorderStyle = BorderStyle.None;
		TGV_Weaponeering.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Weaponeering.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_Weaponeering.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_Weaponeering.ColumnHeadersHeight = 34;
		TGV_Weaponeering.Columns.AddRange(WeaponType, Target, LostTarget, WeaponQty, FiringRange, Route);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_Weaponeering.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_Weaponeering.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Weaponeering.EnableHeadersVisualStyles = false;
		TGV_Weaponeering.ImageList = null;
		TGV_Weaponeering.Location = new Point(6, 30);
		TGV_Weaponeering.MultiSelect = false;
		TGV_Weaponeering.Name = "TGV_Weaponeering";
		TGV_Weaponeering.RowHeadersVisible = false;
		TGV_Weaponeering.RowHeadersWidth = 20;
		TGV_Weaponeering.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Weaponeering.ShowLines = false;
		TGV_Weaponeering.Size = new Size(1246, 284);
		TGV_Weaponeering.TabIndex = 9;
		WeaponType.DefaultNodeImage = null;
		WeaponType.HeaderText = "武器类型";
		WeaponType.MinimumWidth = 8;
		WeaponType.Name = "WeaponType";
		WeaponType.Resizable = DataGridViewTriState.True;
		WeaponType.SortMode = DataGridViewColumnSortMode.NotSortable;
		Target.HeaderText = "目标";
		Target.MinimumWidth = 8;
		Target.Name = "Target";
		LostTarget.HeaderText = "目标丢失";
		LostTarget.MinimumWidth = 8;
		LostTarget.Name = "LostTarget";
		WeaponQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		WeaponQty.HeaderText = "数量";
		WeaponQty.MinimumWidth = 8;
		WeaponQty.Name = "WeaponQty";
		WeaponQty.Width = 30;
		FiringRange.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		FiringRange.HeaderText = "开火范围";
		FiringRange.MinimumWidth = 8;
		FiringRange.Name = "FiringRange";
		FiringRange.Width = 69;
		Route.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Route.HeaderText = "路径";
		Route.MinimumWidth = 8;
		Route.Name = "Route";
		Route.SortMode = DataGridViewColumnSortMode.NotSortable;
		Route.Width = 42;
		TGV_Targeteering.AllowUserToAddRows = false;
		TGV_Targeteering.AllowUserToDeleteRows = false;
		TGV_Targeteering.AllowUserToOrderColumns = true;
		TGV_Targeteering.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_Targeteering.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		TGV_Targeteering.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
		TGV_Targeteering.BackgroundColor = Color.FromArgb(43, 43, 43);
		TGV_Targeteering.BorderStyle = BorderStyle.None;
		TGV_Targeteering.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Targeteering.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		TGV_Targeteering.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		TGV_Targeteering.ColumnHeadersHeight = 34;
		TGV_Targeteering.Columns.AddRange(ID, TargetName, AssignedWeapons, Time_Zulu, Time_Local, Coordinates);
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
		TGV_Targeteering.DefaultCellStyle = dataGridViewCellStyle4;
		TGV_Targeteering.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Targeteering.EnableHeadersVisualStyles = false;
		TGV_Targeteering.ImageList = null;
		TGV_Targeteering.Location = new Point(12, 51);
		TGV_Targeteering.MultiSelect = false;
		TGV_Targeteering.Name = "TGV_Targeteering";
		TGV_Targeteering.RowHeadersVisible = false;
		TGV_Targeteering.RowHeadersWidth = 20;
		TGV_Targeteering.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Targeteering.ShowLines = false;
		TGV_Targeteering.Size = new Size(1240, 262);
		TGV_Targeteering.TabIndex = 11;
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ID.DefaultNodeImage = null;
		ID.HeaderText = "ID";
		ID.MinimumWidth = 8;
		ID.Name = "ID";
		ID.Resizable = DataGridViewTriState.True;
		ID.SortMode = DataGridViewColumnSortMode.NotSortable;
		ID.Width = 22;
		TargetName.HeaderText = "目标名称";
		TargetName.MinimumWidth = 8;
		TargetName.Name = "TargetName";
		TargetName.SortMode = DataGridViewColumnSortMode.NotSortable;
		AssignedWeapons.HeaderText = "指定武器";
		AssignedWeapons.MinimumWidth = 8;
		AssignedWeapons.Name = "AssignedWeapons";
		AssignedWeapons.SortMode = DataGridViewColumnSortMode.NotSortable;
		Time_Zulu.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Time_Zulu.HeaderText = "祖鲁时间";
		Time_Zulu.MinimumWidth = 8;
		Time_Zulu.Name = "Time_Zulu";
		Time_Zulu.SortMode = DataGridViewColumnSortMode.NotSortable;
		Time_Zulu.Width = 58;
		Time_Local.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Time_Local.HeaderText = "当地时间";
		Time_Local.MinimumWidth = 8;
		Time_Local.Name = "Time_Local";
		Time_Local.SortMode = DataGridViewColumnSortMode.NotSortable;
		Time_Local.Width = 61;
		Coordinates.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Coordinates.HeaderText = "坐标";
		Coordinates.MinimumWidth = 8;
		Coordinates.Name = "Coordinates";
		Coordinates.SortMode = DataGridViewColumnSortMode.NotSortable;
		Coordinates.Width = 75;
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.Location = new Point(0, 0);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Orientation = Orientation.Horizontal;
		SplitContainer1.Panel1.Controls.Add(GroupBox_Targeteering);
		SplitContainer1.Panel2.Controls.Add(GroupBox_Weaponeering);
		SplitContainer1.Size = new Size(1258, 787);
		SplitContainer1.SplitterDistance = 425;
		SplitContainer1.TabIndex = 6;
		GroupBox_Targeteering.Controls.Add(Button_EditArea);
		GroupBox_Targeteering.Controls.Add(Button_AddArea);
		GroupBox_Targeteering.Controls.Add(Button_EditToT);
		GroupBox_Targeteering.Controls.Add(Button_EditPreliminaryTargetLocation);
		GroupBox_Targeteering.Controls.Add(Button_AddPreliminaryTargetLocation);
		GroupBox_Targeteering.Controls.Add(Button_EditCoordinate);
		GroupBox_Targeteering.Controls.Add(Button_AddCoordinate);
		GroupBox_Targeteering.Controls.Add(Button_DecreasePriority);
		GroupBox_Targeteering.Controls.Add(Button_IncreasePriority);
		GroupBox_Targeteering.Controls.Add(Button_RemoveSelected);
		GroupBox_Targeteering.Controls.Add(CB_PreplannedOnly);
		GroupBox_Targeteering.Controls.Add(Button_AddHighlighted);
		GroupBox_Targeteering.Controls.Add(TGV_Targeteering);
		GroupBox_Targeteering.Controls.Add(ComboBox_TargteeringMethod);
		GroupBox_Targeteering.Controls.Add(Label3);
		GroupBox_Targeteering.Dock = DockStyle.Fill;
		GroupBox_Targeteering.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_Targeteering.Location = new Point(0, 0);
		GroupBox_Targeteering.Name = "GroupBox_Targeteering";
		GroupBox_Targeteering.Size = new Size(1258, 425);
		GroupBox_Targeteering.TabIndex = 4;
		GroupBox_Targeteering.TabStop = false;
		GroupBox_Targeteering.Text = "目标";
		Button_EditArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditArea.Location = new Point(462, 370);
		Button_EditArea.Name = "Button_EditArea";
		Button_EditArea.Padding = new Padding(5);
		Button_EditArea.Size = new Size(144, 41);
		Button_EditArea.TabIndex = 51;
		Button_EditArea.Text = "编辑区域目标";
		Button_AddArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_AddArea.Location = new Point(462, 319);
		Button_AddArea.Name = "Button_AddArea";
		Button_AddArea.Padding = new Padding(5);
		Button_AddArea.Size = new Size(144, 41);
		Button_AddArea.TabIndex = 50;
		Button_AddArea.Text = "从地图添加区域目标";
		Button_EditToT.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditToT.Location = new Point(612, 319);
		Button_EditToT.Name = "Button_EditToT";
		Button_EditToT.Padding = new Padding(5);
		Button_EditToT.Size = new Size(144, 41);
		Button_EditToT.TabIndex = 49;
		Button_EditToT.Text = "编辑到达目标时间（ToT）";
		Button_EditPreliminaryTargetLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditPreliminaryTargetLocation.Location = new Point(162, 370);
		Button_EditPreliminaryTargetLocation.Name = "Button_EditPreliminaryTargetLocation";
		Button_EditPreliminaryTargetLocation.Padding = new Padding(5);
		Button_EditPreliminaryTargetLocation.Size = new Size(144, 41);
		Button_EditPreliminaryTargetLocation.TabIndex = 48;
		Button_EditPreliminaryTargetLocation.Text = "编辑预备目标位置";
		Button_AddPreliminaryTargetLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_AddPreliminaryTargetLocation.Location = new Point(162, 319);
		Button_AddPreliminaryTargetLocation.Name = "Button_AddPreliminaryTargetLocation";
		Button_AddPreliminaryTargetLocation.Padding = new Padding(5);
		Button_AddPreliminaryTargetLocation.Size = new Size(144, 41);
		Button_AddPreliminaryTargetLocation.TabIndex = 47;
		Button_AddPreliminaryTargetLocation.Text = "从地图添加预备目标位置";
		Button_EditCoordinate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditCoordinate.Location = new Point(312, 370);
		Button_EditCoordinate.Name = "Button_EditCoordinate";
		Button_EditCoordinate.Padding = new Padding(5);
		Button_EditCoordinate.Size = new Size(144, 41);
		Button_EditCoordinate.TabIndex = 46;
		Button_EditCoordinate.Text = "编辑点目标坐标";
		Button_AddCoordinate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_AddCoordinate.Location = new Point(312, 319);
		Button_AddCoordinate.Name = "Button_AddCoordinate";
		Button_AddCoordinate.Padding = new Padding(5);
		Button_AddCoordinate.Size = new Size(144, 41);
		Button_AddCoordinate.TabIndex = 45;
		Button_AddCoordinate.Text = "从地图添加点目标坐标";
		Button_DecreasePriority.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_DecreasePriority.Location = new Point(1098, 351);
		Button_DecreasePriority.Name = "Button_DecreasePriority";
		Button_DecreasePriority.Padding = new Padding(5);
		Button_DecreasePriority.Size = new Size(154, 24);
		Button_DecreasePriority.TabIndex = 44;
		Button_DecreasePriority.Text = "减少优先级";
		Button_IncreasePriority.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_IncreasePriority.Location = new Point(1098, 321);
		Button_IncreasePriority.Name = "Button_IncreasePriority";
		Button_IncreasePriority.Padding = new Padding(5);
		Button_IncreasePriority.Size = new Size(154, 24);
		Button_IncreasePriority.TabIndex = 43;
		Button_IncreasePriority.Text = "增加优先级";
		Button_RemoveSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_RemoveSelected.Location = new Point(12, 370);
		Button_RemoveSelected.Name = "Button_RemoveSelected";
		Button_RemoveSelected.Padding = new Padding(5);
		Button_RemoveSelected.Size = new Size(144, 41);
		Button_RemoveSelected.TabIndex = 41;
		Button_RemoveSelected.Text = "移除所选目标";
		CB_PreplannedOnly.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_PreplannedOnly.Location = new Point(1092, 381);
		CB_PreplannedOnly.MaximumSize = new Size(200, 200);
		CB_PreplannedOnly.MinimumSize = new Size(0, 40);
		CB_PreplannedOnly.Name = "CB_PreplannedOnly";
		CB_PreplannedOnly.Size = new Size(160, 40);
		CB_PreplannedOnly.TabIndex = 42;
		CB_PreplannedOnly.Text = "预先计划的目标（在目标列表中）";
		Button_AddHighlighted.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_AddHighlighted.Location = new Point(12, 319);
		Button_AddHighlighted.Name = "Button_AddHighlighted";
		Button_AddHighlighted.Padding = new Padding(5);
		Button_AddHighlighted.Size = new Size(144, 41);
		Button_AddHighlighted.TabIndex = 40;
		Button_AddHighlighted.Text = "添加当前在地图上选择的单元";
		ComboBox_TargteeringMethod.BackColor = Color.Transparent;
		ComboBox_TargteeringMethod.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_TargteeringMethod.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_TargteeringMethod.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_TargteeringMethod.FormattingEnabled = true;
		ComboBox_TargteeringMethod.Location = new Point(139, 19);
		ComboBox_TargteeringMethod.Name = "ComboBox_TargteeringMethod";
		ComboBox_TargteeringMethod.Size = new Size(128, 21);
		ComboBox_TargteeringMethod.TabIndex = 3;
		Label3.AutoSize = true;
		Label3.Location = new Point(41, 22);
		Label3.Name = "Label3";
		Label3.Size = new Size(47, 15);
		Label3.TabIndex = 2;
		Label3.Text = "目标：";
		GroupBox_Weaponeering.Controls.Add(Button_SetTimeReferenceWeapon);
		GroupBox_Weaponeering.Controls.Add(Button_EditRoute);
		GroupBox_Weaponeering.Controls.Add(Button_EditWRA);
		GroupBox_Weaponeering.Controls.Add(TGV_Weaponeering);
		GroupBox_Weaponeering.Dock = DockStyle.Fill;
		GroupBox_Weaponeering.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_Weaponeering.Location = new Point(0, 0);
		GroupBox_Weaponeering.Name = "GroupBox_Weaponeering";
		GroupBox_Weaponeering.Size = new Size(1258, 358);
		GroupBox_Weaponeering.TabIndex = 5;
		GroupBox_Weaponeering.TabStop = false;
		GroupBox_Weaponeering.Text = "武器";
		Button_SetTimeReferenceWeapon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_SetTimeReferenceWeapon.Location = new Point(376, 326);
		Button_SetTimeReferenceWeapon.Name = "Button_SetTimeReferenceWeapon";
		Button_SetTimeReferenceWeapon.Padding = new Padding(5);
		Button_SetTimeReferenceWeapon.Size = new Size(176, 26);
		Button_SetTimeReferenceWeapon.TabIndex = 12;
		Button_SetTimeReferenceWeapon.Text = "设置时间参考武器";
		Button_EditRoute.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditRoute.Location = new Point(194, 326);
		Button_EditRoute.Name = "Button_EditRoute";
		Button_EditRoute.Padding = new Padding(5);
		Button_EditRoute.Size = new Size(176, 26);
		Button_EditRoute.TabIndex = 11;
		Button_EditRoute.Text = "编辑巡航导弹路径";
		Button_EditWRA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditWRA.Location = new Point(12, 326);
		Button_EditWRA.Name = "Button_EditWRA";
		Button_EditWRA.Padding = new Padding(5);
		Button_EditWRA.Size = new Size(176, 26);
		Button_EditWRA.TabIndex = 10;
		Button_EditWRA.Text = "编辑IP路径点武器释放授权规则";
		AllowDrop = true;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		base.ClientSize = new Size(1258, 787);
		base.Controls.Add(SplitContainer1);
		base.KeyPreview = true;
		base.Location = new Point(100, 100);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(1024, 730);
		base.Name = "FlightPlanEditorTargets";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "选择编队或单个飞机的目标";
		((ISupportInitialize)TGV_Weaponeering).EndInit();
		((ISupportInitialize)TGV_Targeteering).EndInit();
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		GroupBox_Targeteering.ResumeLayout(performLayout: false);
		GroupBox_Targeteering.PerformLayout();
		GroupBox_Weaponeering.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void AwakeBroadcaster(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void QueryBroadcaster(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			LoadWindow();
			WriteIdentifier();
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public void LoadWindow()
	{
		SelectedAircraft = null;
		TGV_Targeteering.ClearSelection();
		TGV_Weaponeering.ClearSelection();
		MapBroadcaster();
	}

	public void RefreshWindow()
	{
	}

	public void ReloadWindow()
	{
		LoadWindow();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	private void ResetBroadcaster(ScenarioObject scenarioObject_0)
	{
		try
		{
			if (!Information.IsNothing(scenarioObject_0))
			{
				MapBroadcaster();
			}
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

	internal void MapBroadcaster()
	{
		try
		{
			if (Information.IsNothing(SelectedFlight))
			{
				ComboBox_TargteeringMethod.DataSource = null;
				ComboBox_TargteeringMethod.Items.Clear();
				ComboBox_TargteeringMethod.SelectedIndex = -1;
				return;
			}
			DataTable dataTable_ = new DataTable();
			ComboBoxDataSource_TargeteeringMethod(ref dataTable_, SelectedMission.Category);
			DarkUIComboBox comboBox_TargteeringMethod = ComboBox_TargteeringMethod;
			comboBox_TargteeringMethod.DataSource = dataTable_;
			comboBox_TargteeringMethod.DisplayMember = "Description";
			comboBox_TargteeringMethod.ValueMember = "ID";
			comboBox_TargteeringMethod.DropDownWidth = 500;
			ComboBox_TargteeringMethod.SelectedIndex = TargeteeringMethod_To_TargeteeringMethodSelection((int)TargetWaypoint_Lead.TargeteeringMethod);
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

	public void SnapToNearestTarget(ref ActiveUnit activeUnit_0, ref Mission mission_0, bool bool_0, Waypoint waypoint_0)
	{
		try
		{
			if (Control.ModifierKeys == Keys.Alt)
			{
				return;
			}
			List<Contact> list = new List<Contact>();
			foreach (Contact contacts_ in Client.CurrentSide.Contacts_List)
			{
				Doctrine._UseShootTourists? shootTourists = mission_0.Doctrine.GetShootTourists(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false);
				if (!Client.CurrentSide.Cache_ContactStancesOnThisPulse.TryGetValue(contacts_.ObjectID, out var value))
				{
					value = contacts_.GetStance(Client.CurrentSide);
				}
				switch (value)
				{
				case Misc.PostureStance.Unknown:
				{
					ActiveUnit_AI aI2 = activeUnit_0.AI;
					Mission mission_2 = mission_0;
					Misc.PostureStance? nullable_2 = value;
					string string_2 = "";
					int int_2 = 0;
					if (aI2.ContactIsRelevantToMission(contacts_, mission_2, shootTourists, bool_0, bool_1: false, bool_2: true, nullable_2, ref string_2, ref int_2) && (contacts_.Type != Contact_Base.ContactType.Submarine || !SeaIceProvider.PrepareWriter(contacts_.GetLongitude(), contacts_.GetLatitude())))
					{
						list.Add(contacts_);
					}
					break;
				}
				case Misc.PostureStance.Unfriendly:
				case Misc.PostureStance.Hostile:
				{
					ActiveUnit_AI aI = activeUnit_0.AI;
					Mission mission_ = mission_0;
					Misc.PostureStance? nullable_ = value;
					string string_ = "";
					int int_ = 0;
					if (!aI.ContactIsRelevantToMission(contacts_, mission_, shootTourists, bool_0, bool_1: false, bool_2: true, nullable_, ref string_, ref int_))
					{
						break;
					}
					if (contacts_.Type == Contact_Base.ContactType.Submarine)
					{
						if (!contacts_.IsClassifiedFalseTarget && !SeaIceProvider.PrepareWriter(contacts_.GetLongitude(), contacts_.GetLatitude()))
						{
							list.Add(contacts_);
						}
						break;
					}
					Lazy<List<Weapon>> lazy = new Lazy<List<Weapon>>(activeUnit_0.Weaponry.AllDistinctWeaponsAboard_Actual);
					ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
					Doctrine doctrine = activeUnit_0.Doctrine;
					string_ = "";
					int_ = 0;
					if (weaponry.PopConsumer(contacts_, bool_1: true, doctrine, ref string_, ref int_, lazy.Value))
					{
						list.Add(contacts_);
					}
					break;
				}
				}
			}
			if (list.Count > 0)
			{
				IEnumerable<Contact> source = list.OrderBy((Contact theC) => Math2.CancelClass(waypoint_0.Latitude, waypoint_0.Longitude, theC.GetLatitude(), theC.GetLongitude()));
				waypoint_0.Latitude = source.ElementAtOrDefault(0).GetLatitude();
				waypoint_0.Longitude = source.ElementAtOrDefault(0).GetLongitude();
			}
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

	public List<Contact> FindMissionTargets()
	{
		try
		{
			Strike strike = (Strike)SelectedMission;
			new List<Module_Unit.Unit>();
			List<Contact> list = new List<Contact>();
			if (strike.RTB_When_Target_Destroyed)
			{
				if (strike.RTB_When_Target_Destroyed && strike.TargetCount == 0)
				{
					return null;
				}
				foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
				{
					if (specificTarget.GetUnitSide() != Client.CurrentSide && !Module_Side.IsAlliedWithThisSide(Client.CurrentSide, specificTarget.GetUnitSide()) && !specificTarget.IsGroup && !specificTarget.IsActiveUnit)
					{
						Contact contact = (Contact)specificTarget;
						if ((Information.IsNothing(contact.ActualUnit) || !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID)) && !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && !list.Contains(contact))
						{
							list.Add(contact);
						}
					}
				}
				if (list.Count <= 0)
				{
					return null;
				}
				return list;
			}
			Interaction.MsgBox("此任务必须指定提前规划目标！");
			return null;
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
			return null;
		}
	}

	public Contact FindMissionTargetClosestToWaypoint_MissionTargets(Waypoint waypoint_0)
	{
		try
		{
			Strike strike = (Strike)SelectedMission;
			new List<Module_Unit.Unit>();
			List<Contact> list = new List<Contact>();
			if (strike.RTB_When_Target_Destroyed)
			{
				if (strike.RTB_When_Target_Destroyed && strike.TargetCount == 0)
				{
					return null;
				}
				foreach (Module_Unit.Unit specificTarget in strike.SpecificTargets)
				{
					if (specificTarget.GetUnitSide() != Client.CurrentSide && !Module_Side.IsAlliedWithThisSide(Client.CurrentSide, specificTarget.GetUnitSide()) && !specificTarget.IsGroup && !specificTarget.IsActiveUnit)
					{
						Contact contact = (Contact)specificTarget;
						if ((Information.IsNothing(contact.ActualUnit) || !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID)) && !Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID) && !list.Contains(contact))
						{
							list.Add(contact);
						}
					}
				}
				if (list.Count <= 0)
				{
					return null;
				}
				return list.OrderBy((Contact theC) => Math2.CancelClass(waypoint_0.Latitude, waypoint_0.Longitude, theC.GetLatitude(), theC.GetLongitude())).ElementAtOrDefault(0);
			}
			Interaction.MsgBox("此任务必须指定提前规划目标！");
			return null;
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
			return null;
		}
	}

	public void FindMissionTargetClosestToWaypoint_FlightTargets()
	{
	}

	public void FindMissionTargetClosestToWaypoint_IndividualTargets()
	{
	}

	private void SortBroadcaster(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Mission._TargeteeringMethod targeteeringMethod_ = TargeteeringMethodSelection_To_TargeteeringMethod(ComboBox_TargteeringMethod.SelectedIndex);
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			ChangeTargeteeringMethod(ref scenario_, ref side_, ref SelectedMission, targeteeringMethod_);
			Client.CurrentSide = side_;
			FindAllAircraft();
			ForgotBroadcaster(bool_0: true, bool_1: true);
			WriteIdentifier();
			Client.MustRefreshMainForm = true;
		}
	}

	public void ChangeTargeteeringMethod(ref Scenario scenario_0, ref Side side_0, ref Mission mission_0, Mission._TargeteeringMethod _TargeteeringMethod_0)
	{
		try
		{
			if (Interaction.MsgBox("正在修改目标选择方法，这将擦除现有配置，继续吗？", MsgBoxStyle.YesNo) == MsgBoxResult.No)
			{
				return;
			}
			switch (_TargeteeringMethod_0)
			{
			case Mission._TargeteeringMethod.Mission:
				if (TargetWaypoint_Lead.TargeteeringMethod != 0)
				{
					TargetWaypoint_Lead.TargeteeringMethod = Mission._TargeteeringMethod.Mission;
					AircraftList.Clear();
					m_ExporterTask.Clear();
					m_PrototypeTask.Clear();
					TargetWaypoint_Lead.TargeteeringList = null;
					TargetWaypoint_Lead.WeaponeeringList = null;
					if (SelectedFlight.DesiredAircraftQty > 1)
					{
						TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = null;
						TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 2)
					{
						TargetWaypoint_Lead.TargeteeringList_SecondElement = null;
						TargetWaypoint_Lead.WeaponeeringList_SecondElement = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 3)
					{
						TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = null;
						TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 4)
					{
						TargetWaypoint_Lead.TargeteeringList_ThirdElement = null;
						TargetWaypoint_Lead.WeaponeeringList_ThirdElement = null;
					}
					if (SelectedFlight.DesiredAircraftQty > 4)
					{
						TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = null;
						TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman = null;
					}
				}
				break;
			case Mission._TargeteeringMethod.Flight:
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
				{
					break;
				}
				TargetWaypoint_Lead.TargeteeringMethod = Mission._TargeteeringMethod.Flight;
				AircraftList.Clear();
				m_ExporterTask.Clear();
				m_PrototypeTask.Clear();
				TargetWaypoint_Lead.TargeteeringList = new List<Mission.TargeteeringEntry>();
				TargetWaypoint_Lead.WeaponeeringList = null;
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = null;
					TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElement = null;
					TargetWaypoint_Lead.WeaponeeringList_SecondElement = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = null;
					TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					TargetWaypoint_Lead.TargeteeringList_ThirdElement = null;
					TargetWaypoint_Lead.WeaponeeringList_ThirdElement = null;
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = null;
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman = null;
				}
				List<Contact> list = FindMissionTargets();
				if (Information.IsNothing(list) || list.Count <= 0)
				{
					break;
				}
				{
					foreach (Contact item8 in list)
					{
						if (!Information.IsNothing(item8))
						{
							Mission.TargeteeringEntry item7 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, item8.Name, item8.ObjectID, item8.ActualUnit.ObjectID, item8.ActualUnit.DBID, item8.GetLatitude(), item8.GetLongitude(), null, null, null);
							if (!TargetWaypoint_Lead.TargeteeringList.Contains(item7))
							{
								TargetWaypoint_Lead.TargeteeringList.Add(item7);
							}
						}
					}
					break;
				}
			}
			case Mission._TargeteeringMethod.Individual:
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					break;
				}
				TargetWaypoint_Lead.TargeteeringMethod = Mission._TargeteeringMethod.Individual;
				AircraftList.Clear();
				m_ExporterTask.Clear();
				m_PrototypeTask.Clear();
				TargetWaypoint_Lead.TargeteeringList = new List<Mission.TargeteeringEntry>();
				TargetWaypoint_Lead.WeaponeeringList = new List<Mission.WeaponeeringEntry>();
				Contact contact_ = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead);
				ActiveUnit activeUnit_;
				Scenario scenario_;
				if (!Information.IsNothing(contact_))
				{
					Mission.TargeteeringEntry item = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact_.Name, contact_.ObjectID, contact_.ActualUnit.ObjectID, contact_.ActualUnit.DBID, contact_.GetLatitude(), contact_.GetLongitude(), null, null, null);
					if (Information.IsNothing(TargetWaypoint_Lead.TargeteeringList))
					{
						TargetWaypoint_Lead.TargeteeringList = new List<Mission.TargeteeringEntry>();
					}
					if (!TargetWaypoint_Lead.TargeteeringList.Contains(item))
					{
						TargetWaypoint_Lead.TargeteeringList.Add(item);
					}
					scenario_ = Client.CurrentScenario;
					Side side_ = Client.CurrentSide;
					ref Mission selectedMission = ref SelectedMission;
					ref Waypoint waypoint_ = ref SelectedFlight.FlightPlan[0];
					activeUnit_ = null;
					ActiveUnit activeUnit_6 = null;
					Mission.Flight selectedFlight = SelectedFlight;
					Scenario currentScenario;
					ActiveUnit activeUnit_7 = selectedFlight.GetReferenceUnit(currentScenario = Client.CurrentScenario);
					MissionPlanner.UpdateStrikeMissionWaypoints_TargetAndIP_GroupLead(0f, ref scenario_, ref side_, ref selectedMission, ref waypoint_, ref activeUnit_, ref contact_, ref activeUnit_6, bool_0: false, ref activeUnit_7, ref SelectedFlight, ref IPWaypoint_Lead, ref TargetWaypoint_Lead, bool_1: true);
					selectedFlight.SetReferenceUnit(currentScenario, activeUnit_7);
					Client.CurrentSide = side_;
				}
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = new List<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman = new List<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_LeadElementWingman))
					{
						contact_ = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_LeadElementWingman);
					}
					if (!Information.IsNothing(contact_))
					{
						Mission.TargeteeringEntry item2 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact_.Name, contact_.ObjectID, contact_.ActualUnit.ObjectID, contact_.ActualUnit.DBID, contact_.GetLatitude(), contact_.GetLongitude(), null, null, null);
						if (Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_LeadElementWingman))
						{
							TargetWaypoint_Lead.TargeteeringList_LeadElementWingman = new List<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_LeadElementWingman.Contains(item2))
						{
							TargetWaypoint_Lead.TargeteeringList_LeadElementWingman.Add(item2);
						}
						if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_LeadElementWingman))
						{
							Scenario scenario_2 = Client.CurrentScenario;
							Side side_2 = Client.CurrentSide;
							ref Mission selectedMission2 = ref SelectedMission;
							ref Waypoint waypoint_2 = ref SelectedFlight.FlightPlan[0];
							ActiveUnit activeUnit_8 = null;
							ActiveUnit activeUnit_9 = null;
							Mission.Flight selectedFlight10 = SelectedFlight;
							activeUnit_ = selectedFlight10.GetReferenceUnit(scenario_ = Client.CurrentScenario);
							MissionPlanner.UpdateStrikeMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref scenario_2, ref side_2, ref selectedMission2, ref waypoint_2, ref activeUnit_8, ref contact_, ref activeUnit_9, bool_0: false, ref activeUnit_, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_LeadElementWingman, ref TargetWaypoint_Lead.Waypoint_LeadElementWingman, Mission.Flight.FlightElement.LeadElementWingman, bool_1: true);
							selectedFlight10.SetReferenceUnit(scenario_, activeUnit_);
							Client.CurrentSide = side_2;
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElement = new List<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_SecondElement = new List<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElement))
					{
						contact_ = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_SecondElement);
					}
					if (!Information.IsNothing(contact_))
					{
						Mission.TargeteeringEntry item3 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact_.Name, contact_.ObjectID, contact_.ActualUnit.ObjectID, contact_.ActualUnit.DBID, contact_.GetLatitude(), contact_.GetLongitude(), null, null, null);
						if (Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_SecondElement))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElement = new List<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_SecondElement.Contains(item3))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElement.Add(item3);
						}
						if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElement))
						{
							scenario_ = Client.CurrentScenario;
							Side side_3 = Client.CurrentSide;
							ref Mission selectedMission3 = ref SelectedMission;
							ref Waypoint waypoint_3 = ref SelectedFlight.FlightPlan[0];
							activeUnit_ = null;
							ActiveUnit activeUnit_10 = null;
							Mission.Flight selectedFlight11 = SelectedFlight;
							Scenario currentScenario2;
							ActiveUnit activeUnit_11 = selectedFlight11.GetReferenceUnit(currentScenario2 = Client.CurrentScenario);
							MissionPlanner.UpdateStrikeMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref scenario_, ref side_3, ref selectedMission3, ref waypoint_3, ref activeUnit_, ref contact_, ref activeUnit_10, bool_0: false, ref activeUnit_11, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_SecondElement, ref TargetWaypoint_Lead.Waypoint_SecondElement, Mission.Flight.FlightElement.SecondElement, bool_1: true);
							selectedFlight11.SetReferenceUnit(currentScenario2, activeUnit_11);
							Client.CurrentSide = side_3;
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = new List<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman = new List<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElementWingman))
					{
						contact_ = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_SecondElementWingman);
					}
					if (!Information.IsNothing(contact_))
					{
						Mission.TargeteeringEntry item4 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact_.Name, contact_.ObjectID, contact_.ActualUnit.ObjectID, contact_.ActualUnit.DBID, contact_.GetLatitude(), contact_.GetLongitude(), null, null, null);
						if (Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_SecondElementWingman))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElementWingman = new List<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_SecondElementWingman.Contains(item4))
						{
							TargetWaypoint_Lead.TargeteeringList_SecondElementWingman.Add(item4);
						}
						if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElementWingman))
						{
							Scenario scenario_3 = Client.CurrentScenario;
							Side side_4 = Client.CurrentSide;
							ref Mission selectedMission4 = ref SelectedMission;
							ref Waypoint waypoint_4 = ref SelectedFlight.FlightPlan[0];
							ActiveUnit activeUnit_12 = null;
							ActiveUnit activeUnit_13 = null;
							Mission.Flight selectedFlight12 = SelectedFlight;
							activeUnit_ = selectedFlight12.GetReferenceUnit(scenario_ = Client.CurrentScenario);
							MissionPlanner.UpdateStrikeMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref scenario_3, ref side_4, ref selectedMission4, ref waypoint_4, ref activeUnit_12, ref contact_, ref activeUnit_13, bool_0: false, ref activeUnit_, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_SecondElementWingman, ref TargetWaypoint_Lead.Waypoint_SecondElementWingman, Mission.Flight.FlightElement.SecondElementWingman, bool_1: true);
							selectedFlight12.SetReferenceUnit(scenario_, activeUnit_);
							Client.CurrentSide = side_4;
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					TargetWaypoint_Lead.TargeteeringList_ThirdElement = new List<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_ThirdElement = new List<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElement))
					{
						contact_ = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_ThirdElement);
					}
					if (!Information.IsNothing(contact_))
					{
						Mission.TargeteeringEntry item5 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact_.Name, contact_.ObjectID, contact_.ActualUnit.ObjectID, contact_.ActualUnit.DBID, contact_.GetLatitude(), contact_.GetLongitude(), null, null, null);
						if (Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_ThirdElement))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElement = new List<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_ThirdElement.Contains(item5))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElement.Add(item5);
						}
						if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElement))
						{
							scenario_ = Client.CurrentScenario;
							Side side_5 = Client.CurrentSide;
							ref Mission selectedMission5 = ref SelectedMission;
							ref Waypoint waypoint_5 = ref SelectedFlight.FlightPlan[0];
							activeUnit_ = null;
							ActiveUnit activeUnit_2 = null;
							Mission.Flight selectedFlight13 = SelectedFlight;
							Scenario currentScenario3;
							ActiveUnit activeUnit_3 = selectedFlight13.GetReferenceUnit(currentScenario3 = Client.CurrentScenario);
							MissionPlanner.UpdateStrikeMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref scenario_, ref side_5, ref selectedMission5, ref waypoint_5, ref activeUnit_, ref contact_, ref activeUnit_2, bool_0: false, ref activeUnit_3, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_ThirdElement, ref TargetWaypoint_Lead.Waypoint_ThirdElement, Mission.Flight.FlightElement.ThirdElement, bool_1: true);
							selectedFlight13.SetReferenceUnit(currentScenario3, activeUnit_3);
							Client.CurrentSide = side_5;
						}
					}
					TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = new List<Mission.TargeteeringEntry>();
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman = new List<Mission.WeaponeeringEntry>();
					if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElementWingman))
					{
						contact_ = FindMissionTargetClosestToWaypoint_MissionTargets(TargetWaypoint_Lead.Waypoint_ThirdElementWingman);
					}
					if (!Information.IsNothing(contact_))
					{
						Mission.TargeteeringEntry item6 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact_.Name, contact_.ObjectID, contact_.ActualUnit.ObjectID, contact_.ActualUnit.DBID, contact_.GetLatitude(), contact_.GetLongitude(), null, null, null);
						if (Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman = new List<Mission.TargeteeringEntry>();
						}
						if (!TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman.Contains(item6))
						{
							TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman.Add(item6);
						}
						if (!Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElementWingman))
						{
							Scenario scenario_4 = Client.CurrentScenario;
							Side side_6 = Client.CurrentSide;
							ref Mission selectedMission6 = ref SelectedMission;
							ref Waypoint waypoint_6 = ref SelectedFlight.FlightPlan[0];
							ActiveUnit activeUnit_4 = null;
							ActiveUnit activeUnit_5 = null;
							Mission.Flight selectedFlight14 = SelectedFlight;
							activeUnit_ = selectedFlight14.GetReferenceUnit(scenario_ = Client.CurrentScenario);
							MissionPlanner.UpdateStrikeMissionWaypoints_TargetAndIP_WingmenSplitSegment(0f, ref scenario_4, ref side_6, ref selectedMission6, ref waypoint_6, ref activeUnit_4, ref contact_, ref activeUnit_5, bool_0: false, ref activeUnit_, ref SelectedFlight, ref IPWaypoint_Lead.Waypoint_ThirdElementWingman, ref TargetWaypoint_Lead.Waypoint_ThirdElementWingman, Mission.Flight.FlightElement.ThirdElementWingman, bool_1: true);
							selectedFlight14.SetReferenceUnit(scenario_, activeUnit_);
							Client.CurrentSide = side_6;
						}
					}
				}
				CalcBroadcaster();
				Mission.Flight selectedFlight15 = SelectedFlight;
				activeUnit_ = selectedFlight15.GetReferenceUnit(scenario_ = Client.CurrentScenario);
				ref Waypoint targetWaypoint_Lead = ref TargetWaypoint_Lead;
				ref List<Mission.WeaponeeringEntry> weaponeeringList = ref TargetWaypoint_Lead.WeaponeeringList;
				List<Mission.TargeteeringEntry> targeteeringList = TargetWaypoint_Lead.TargeteeringList;
				bool bool_ = false;
				RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref targetWaypoint_Lead, ref weaponeeringList, targeteeringList, ref bool_, bool_1: false, ref SelectedFlight, "a/c #1");
				selectedFlight15.SetReferenceUnit(scenario_, activeUnit_);
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					if (Information.IsNothing(TargetWaypoint_Lead.Waypoint_LeadElementWingman))
					{
						Mission.Flight selectedFlight16 = SelectedFlight;
						activeUnit_ = selectedFlight16.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead2 = ref TargetWaypoint_Lead;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_LeadElementWingman = ref TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman;
						List<Mission.TargeteeringEntry> targeteeringList_LeadElementWingman = TargetWaypoint_Lead.TargeteeringList_LeadElementWingman;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref targetWaypoint_Lead2, ref weaponeeringList_LeadElementWingman, targeteeringList_LeadElementWingman, ref bool_, bool_1: false, ref SelectedFlight, "a/c #2");
						selectedFlight16.SetReferenceUnit(scenario_, activeUnit_);
					}
					else
					{
						Mission.Flight selectedFlight17 = SelectedFlight;
						activeUnit_ = selectedFlight17.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint waypoint_LeadElementWingman = ref TargetWaypoint_Lead.Waypoint_LeadElementWingman;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_LeadElementWingman2 = ref TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman;
						List<Mission.TargeteeringEntry> targeteeringList_LeadElementWingman2 = TargetWaypoint_Lead.TargeteeringList_LeadElementWingman;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref waypoint_LeadElementWingman, ref weaponeeringList_LeadElementWingman2, targeteeringList_LeadElementWingman2, ref bool_, bool_1: false, ref SelectedFlight, "a/c #2");
						selectedFlight17.SetReferenceUnit(scenario_, activeUnit_);
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					if (Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElement))
					{
						Mission.Flight selectedFlight2 = SelectedFlight;
						activeUnit_ = selectedFlight2.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead3 = ref TargetWaypoint_Lead;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_SecondElement = ref TargetWaypoint_Lead.WeaponeeringList_SecondElement;
						List<Mission.TargeteeringEntry> targeteeringList_SecondElement = TargetWaypoint_Lead.TargeteeringList_SecondElement;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref targetWaypoint_Lead3, ref weaponeeringList_SecondElement, targeteeringList_SecondElement, ref bool_, bool_1: false, ref SelectedFlight, "a/c #3");
						selectedFlight2.SetReferenceUnit(scenario_, activeUnit_);
					}
					else
					{
						Mission.Flight selectedFlight3 = SelectedFlight;
						activeUnit_ = selectedFlight3.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint waypoint_SecondElement = ref TargetWaypoint_Lead.Waypoint_SecondElement;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_SecondElement2 = ref TargetWaypoint_Lead.WeaponeeringList_SecondElement;
						List<Mission.TargeteeringEntry> targeteeringList_SecondElement2 = TargetWaypoint_Lead.TargeteeringList_SecondElement;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref waypoint_SecondElement, ref weaponeeringList_SecondElement2, targeteeringList_SecondElement2, ref bool_, bool_1: false, ref SelectedFlight, "a/c #3");
						selectedFlight3.SetReferenceUnit(scenario_, activeUnit_);
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					if (Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElementWingman))
					{
						Mission.Flight selectedFlight4 = SelectedFlight;
						activeUnit_ = selectedFlight4.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead4 = ref TargetWaypoint_Lead;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_SecondElementWingman = ref TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman;
						List<Mission.TargeteeringEntry> targeteeringList_SecondElementWingman = TargetWaypoint_Lead.TargeteeringList_SecondElementWingman;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref targetWaypoint_Lead4, ref weaponeeringList_SecondElementWingman, targeteeringList_SecondElementWingman, ref bool_, bool_1: false, ref SelectedFlight, "a/c #4");
						selectedFlight4.SetReferenceUnit(scenario_, activeUnit_);
					}
					else
					{
						Mission.Flight selectedFlight5 = SelectedFlight;
						activeUnit_ = selectedFlight5.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint waypoint_SecondElementWingman = ref TargetWaypoint_Lead.Waypoint_SecondElementWingman;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_SecondElementWingman2 = ref TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman;
						List<Mission.TargeteeringEntry> targeteeringList_SecondElementWingman2 = TargetWaypoint_Lead.TargeteeringList_SecondElementWingman;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref waypoint_SecondElementWingman, ref weaponeeringList_SecondElementWingman2, targeteeringList_SecondElementWingman2, ref bool_, bool_1: false, ref SelectedFlight, "a/c #4");
						selectedFlight5.SetReferenceUnit(scenario_, activeUnit_);
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					if (Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElement))
					{
						Mission.Flight selectedFlight6 = SelectedFlight;
						activeUnit_ = selectedFlight6.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead5 = ref TargetWaypoint_Lead;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_ThirdElement = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElement;
						List<Mission.TargeteeringEntry> targeteeringList_ThirdElement = TargetWaypoint_Lead.TargeteeringList_ThirdElement;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref targetWaypoint_Lead5, ref weaponeeringList_ThirdElement, targeteeringList_ThirdElement, ref bool_, bool_1: false, ref SelectedFlight, "a/c #5");
						selectedFlight6.SetReferenceUnit(scenario_, activeUnit_);
					}
					else
					{
						Mission.Flight selectedFlight7 = SelectedFlight;
						activeUnit_ = selectedFlight7.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint waypoint_ThirdElement = ref TargetWaypoint_Lead.Waypoint_ThirdElement;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_ThirdElement2 = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElement;
						List<Mission.TargeteeringEntry> targeteeringList_ThirdElement2 = TargetWaypoint_Lead.TargeteeringList_ThirdElement;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref waypoint_ThirdElement, ref weaponeeringList_ThirdElement2, targeteeringList_ThirdElement2, ref bool_, bool_1: false, ref SelectedFlight, "a/c #5");
						selectedFlight7.SetReferenceUnit(scenario_, activeUnit_);
					}
					if (Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElementWingman))
					{
						Mission.Flight selectedFlight8 = SelectedFlight;
						activeUnit_ = selectedFlight8.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint targetWaypoint_Lead6 = ref TargetWaypoint_Lead;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_ThirdElementWingman = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman;
						List<Mission.TargeteeringEntry> targeteeringList_ThirdElementWingman = TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref targetWaypoint_Lead6, ref weaponeeringList_ThirdElementWingman, targeteeringList_ThirdElementWingman, ref bool_, bool_1: false, ref SelectedFlight, "a/c #6");
						selectedFlight8.SetReferenceUnit(scenario_, activeUnit_);
					}
					else
					{
						Mission.Flight selectedFlight9 = SelectedFlight;
						activeUnit_ = selectedFlight9.GetReferenceUnit(scenario_ = Client.CurrentScenario);
						ref Waypoint waypoint_ThirdElementWingman = ref TargetWaypoint_Lead.Waypoint_ThirdElementWingman;
						ref List<Mission.WeaponeeringEntry> weaponeeringList_ThirdElementWingman2 = ref TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman;
						List<Mission.TargeteeringEntry> targeteeringList_ThirdElementWingman2 = TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman;
						bool_ = false;
						RateBroadcaster(ref scenario_0, ref side_0, ref activeUnit_, ref waypoint_ThirdElementWingman, ref weaponeeringList_ThirdElementWingman2, targeteeringList_ThirdElementWingman2, ref bool_, bool_1: false, ref SelectedFlight, "a/c #6");
						selectedFlight9.SetReferenceUnit(scenario_, activeUnit_);
					}
				}
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

	private void CalcBroadcaster()
	{
		try
		{
			if (Information.IsNothing(SelectedFlight.GetReferenceUnit(Client.CurrentScenario)) || !SelectedFlight.GetReferenceUnit(Client.CurrentScenario).IsAircraft)
			{
				return;
			}
			Aircraft activeUnit_ = (Aircraft)SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
			if (Information.IsNothing(recordTask))
			{
				recordTask = new List<WeaponRec>();
			}
			else
			{
				recordTask.Clear();
			}
			Weaponeering_RetreiveLoadoutWeapons(activeUnit_);
			Weaponeering_RetreiveMagazineWeapons(activeUnit_);
			Weaponeering_RetreiveMountWeapons(activeUnit_);
			if (recordTask.Count <= 0)
			{
				return;
			}
			foreach (WeaponRec item5 in recordTask)
			{
				int defaultLoad = item5.DefaultLoad;
				if (defaultLoad <= 0)
				{
					continue;
				}
				Weapon referenceWeapon = item5.GetReferenceWeapon(Client.CurrentScenario);
				string text = ((Information.IsNothing(TargetWaypoint_Lead.TargeteeringList) || TargetWaypoint_Lead.TargeteeringList.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList[0].ObjectID);
				if (!Information.IsNothing(text))
				{
					if (referenceWeapon.Type != Weapon._WeaponType.GuidedWeapon && referenceWeapon.Type != Weapon._WeaponType.GuidedProjectile)
					{
						int int_ = item5.int_0;
						Weapon._WeaponType type = referenceWeapon.Type;
						string name = referenceWeapon.Name;
						float maxRange_NoTargetType = referenceWeapon.MaxRange_NoTargetType;
						float minRange_NoTargetType = referenceWeapon.MinRange_NoTargetType;
						bool bearingOnlyLaunch = referenceWeapon.Flags.BearingOnlyLaunch;
						string string_ = text;
						int defaultLoad2 = item5.DefaultLoad;
						Waypoint[] waypoint_ = null;
						Mission.WeaponeeringEntry item = new Mission.WeaponeeringEntry(int_, type, name, maxRange_NoTargetType, minRange_NoTargetType, bearingOnlyLaunch, string_, 0, -98, defaultLoad2, 0, ref waypoint_);
						TargetWaypoint_Lead.WeaponeeringList.Add(item);
					}
					else
					{
						int num = defaultLoad;
						for (int i = 1; i <= num; i++)
						{
							int int_5 = item5.int_0;
							Weapon._WeaponType type5 = referenceWeapon.Type;
							string name5 = referenceWeapon.Name;
							float maxRange_NoTargetType5 = referenceWeapon.MaxRange_NoTargetType;
							float minRange_NoTargetType5 = referenceWeapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch5 = referenceWeapon.Flags.BearingOnlyLaunch;
							string string_5 = text;
							Waypoint[] waypoint_5 = null;
							Mission.WeaponeeringEntry item6 = new Mission.WeaponeeringEntry(int_5, type5, name5, maxRange_NoTargetType5, minRange_NoTargetType5, bearingOnlyLaunch5, string_5, 0, 0, 0, 0, ref waypoint_5);
							TargetWaypoint_Lead.WeaponeeringList.Add(item6);
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 1)
				{
					text = ((Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_LeadElementWingman) || TargetWaypoint_Lead.TargeteeringList_LeadElementWingman.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_LeadElementWingman[0].ObjectID);
					if (!Information.IsNothing(text))
					{
						if (referenceWeapon.Type != Weapon._WeaponType.GuidedWeapon && referenceWeapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_6 = item5.int_0;
							Weapon._WeaponType type6 = referenceWeapon.Type;
							string name6 = referenceWeapon.Name;
							float maxRange_NoTargetType6 = referenceWeapon.MaxRange_NoTargetType;
							float minRange_NoTargetType6 = referenceWeapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch6 = referenceWeapon.Flags.BearingOnlyLaunch;
							string string_6 = text;
							int defaultLoad3 = item5.DefaultLoad;
							Waypoint[] waypoint_6 = null;
							Mission.WeaponeeringEntry item7 = new Mission.WeaponeeringEntry(int_6, type6, name6, maxRange_NoTargetType6, minRange_NoTargetType6, bearingOnlyLaunch6, string_6, 0, -98, defaultLoad3, 0, ref waypoint_6);
							TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman.Add(item7);
						}
						else
						{
							int num2 = defaultLoad;
							for (int j = 1; j <= num2; j++)
							{
								int int_7 = item5.int_0;
								Weapon._WeaponType type7 = referenceWeapon.Type;
								string name7 = referenceWeapon.Name;
								float maxRange_NoTargetType7 = referenceWeapon.MaxRange_NoTargetType;
								float minRange_NoTargetType7 = referenceWeapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch7 = referenceWeapon.Flags.BearingOnlyLaunch;
								string string_7 = text;
								Waypoint[] waypoint_7 = null;
								Mission.WeaponeeringEntry item8 = new Mission.WeaponeeringEntry(int_7, type7, name7, maxRange_NoTargetType7, minRange_NoTargetType7, bearingOnlyLaunch7, string_7, 0, 0, 0, 0, ref waypoint_7);
								TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman.Add(item8);
							}
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 2)
				{
					text = ((Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_SecondElement) || TargetWaypoint_Lead.TargeteeringList_SecondElement.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_SecondElement[0].ObjectID);
					if (!Information.IsNothing(text))
					{
						if (referenceWeapon.Type != Weapon._WeaponType.GuidedWeapon && referenceWeapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_8 = item5.int_0;
							Weapon._WeaponType type8 = referenceWeapon.Type;
							string name8 = referenceWeapon.Name;
							float maxRange_NoTargetType8 = referenceWeapon.MaxRange_NoTargetType;
							float minRange_NoTargetType8 = referenceWeapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch8 = referenceWeapon.Flags.BearingOnlyLaunch;
							string string_8 = text;
							int defaultLoad4 = item5.DefaultLoad;
							Waypoint[] waypoint_8 = null;
							Mission.WeaponeeringEntry item9 = new Mission.WeaponeeringEntry(int_8, type8, name8, maxRange_NoTargetType8, minRange_NoTargetType8, bearingOnlyLaunch8, string_8, 0, -98, defaultLoad4, 0, ref waypoint_8);
							TargetWaypoint_Lead.WeaponeeringList_SecondElement.Add(item9);
						}
						else
						{
							int num3 = defaultLoad;
							for (int k = 1; k <= num3; k++)
							{
								int int_9 = item5.int_0;
								Weapon._WeaponType type9 = referenceWeapon.Type;
								string name9 = referenceWeapon.Name;
								float maxRange_NoTargetType9 = referenceWeapon.MaxRange_NoTargetType;
								float minRange_NoTargetType9 = referenceWeapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch9 = referenceWeapon.Flags.BearingOnlyLaunch;
								string string_9 = text;
								Waypoint[] waypoint_9 = null;
								Mission.WeaponeeringEntry item10 = new Mission.WeaponeeringEntry(int_9, type9, name9, maxRange_NoTargetType9, minRange_NoTargetType9, bearingOnlyLaunch9, string_9, 0, 0, 0, 0, ref waypoint_9);
								TargetWaypoint_Lead.WeaponeeringList_SecondElement.Add(item10);
							}
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 3)
				{
					text = ((Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_SecondElementWingman) || TargetWaypoint_Lead.TargeteeringList_SecondElementWingman.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_SecondElementWingman[0].ObjectID);
					if (!Information.IsNothing(text))
					{
						if (referenceWeapon.Type != Weapon._WeaponType.GuidedWeapon && referenceWeapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_10 = item5.int_0;
							Weapon._WeaponType type10 = referenceWeapon.Type;
							string name10 = referenceWeapon.Name;
							float maxRange_NoTargetType10 = referenceWeapon.MaxRange_NoTargetType;
							float minRange_NoTargetType10 = referenceWeapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch10 = referenceWeapon.Flags.BearingOnlyLaunch;
							string string_10 = text;
							int defaultLoad5 = item5.DefaultLoad;
							Waypoint[] waypoint_10 = null;
							Mission.WeaponeeringEntry item11 = new Mission.WeaponeeringEntry(int_10, type10, name10, maxRange_NoTargetType10, minRange_NoTargetType10, bearingOnlyLaunch10, string_10, 0, -98, defaultLoad5, 0, ref waypoint_10);
							TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman.Add(item11);
						}
						else
						{
							int num4 = defaultLoad;
							for (int l = 1; l <= num4; l++)
							{
								int int_11 = item5.int_0;
								Weapon._WeaponType type11 = referenceWeapon.Type;
								string name11 = referenceWeapon.Name;
								float maxRange_NoTargetType11 = referenceWeapon.MaxRange_NoTargetType;
								float minRange_NoTargetType11 = referenceWeapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch11 = referenceWeapon.Flags.BearingOnlyLaunch;
								string string_11 = text;
								Waypoint[] waypoint_11 = null;
								Mission.WeaponeeringEntry item12 = new Mission.WeaponeeringEntry(int_11, type11, name11, maxRange_NoTargetType11, minRange_NoTargetType11, bearingOnlyLaunch11, string_11, 0, 0, 0, 0, ref waypoint_11);
								TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman.Add(item12);
							}
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty > 4)
				{
					text = ((Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_ThirdElement) || TargetWaypoint_Lead.TargeteeringList_ThirdElement.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_ThirdElement[0].ObjectID);
					if (!Information.IsNothing(text))
					{
						if (referenceWeapon.Type != Weapon._WeaponType.GuidedWeapon && referenceWeapon.Type != Weapon._WeaponType.GuidedProjectile)
						{
							int int_12 = item5.int_0;
							Weapon._WeaponType type12 = referenceWeapon.Type;
							string name12 = referenceWeapon.Name;
							float maxRange_NoTargetType12 = referenceWeapon.MaxRange_NoTargetType;
							float minRange_NoTargetType12 = referenceWeapon.MinRange_NoTargetType;
							bool bearingOnlyLaunch12 = referenceWeapon.Flags.BearingOnlyLaunch;
							string string_12 = text;
							int defaultLoad6 = item5.DefaultLoad;
							Waypoint[] waypoint_12 = null;
							Mission.WeaponeeringEntry item13 = new Mission.WeaponeeringEntry(int_12, type12, name12, maxRange_NoTargetType12, minRange_NoTargetType12, bearingOnlyLaunch12, string_12, 0, -98, defaultLoad6, 0, ref waypoint_12);
							TargetWaypoint_Lead.WeaponeeringList_ThirdElement.Add(item13);
						}
						else
						{
							int num5 = defaultLoad;
							for (int m = 1; m <= num5; m++)
							{
								int int_2 = item5.int_0;
								Weapon._WeaponType type2 = referenceWeapon.Type;
								string name2 = referenceWeapon.Name;
								float maxRange_NoTargetType2 = referenceWeapon.MaxRange_NoTargetType;
								float minRange_NoTargetType2 = referenceWeapon.MinRange_NoTargetType;
								bool bearingOnlyLaunch2 = referenceWeapon.Flags.BearingOnlyLaunch;
								string string_2 = text;
								Waypoint[] waypoint_2 = null;
								Mission.WeaponeeringEntry item2 = new Mission.WeaponeeringEntry(int_2, type2, name2, maxRange_NoTargetType2, minRange_NoTargetType2, bearingOnlyLaunch2, string_2, 0, 0, 0, 0, ref waypoint_2);
								TargetWaypoint_Lead.WeaponeeringList_ThirdElement.Add(item2);
							}
						}
					}
				}
				if (SelectedFlight.DesiredAircraftQty <= 4)
				{
					continue;
				}
				text = ((Information.IsNothing(TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman) || TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman.Count == 0) ? null : TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman[0].ObjectID);
				if (Information.IsNothing(text))
				{
					continue;
				}
				if (referenceWeapon.Type != Weapon._WeaponType.GuidedWeapon && referenceWeapon.Type != Weapon._WeaponType.GuidedProjectile)
				{
					int int_3 = item5.int_0;
					Weapon._WeaponType type3 = referenceWeapon.Type;
					string name3 = referenceWeapon.Name;
					float maxRange_NoTargetType3 = referenceWeapon.MaxRange_NoTargetType;
					float minRange_NoTargetType3 = referenceWeapon.MinRange_NoTargetType;
					bool bearingOnlyLaunch3 = referenceWeapon.Flags.BearingOnlyLaunch;
					string string_3 = text;
					int defaultLoad7 = item5.DefaultLoad;
					Waypoint[] waypoint_3 = null;
					Mission.WeaponeeringEntry item3 = new Mission.WeaponeeringEntry(int_3, type3, name3, maxRange_NoTargetType3, minRange_NoTargetType3, bearingOnlyLaunch3, string_3, 0, -98, defaultLoad7, 0, ref waypoint_3);
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman.Add(item3);
					continue;
				}
				int num6 = defaultLoad;
				for (int n = 1; n <= num6; n++)
				{
					int int_4 = item5.int_0;
					Weapon._WeaponType type4 = referenceWeapon.Type;
					string name4 = referenceWeapon.Name;
					float maxRange_NoTargetType4 = referenceWeapon.MaxRange_NoTargetType;
					float minRange_NoTargetType4 = referenceWeapon.MinRange_NoTargetType;
					bool bearingOnlyLaunch4 = referenceWeapon.Flags.BearingOnlyLaunch;
					string string_4 = text;
					Waypoint[] waypoint_4 = null;
					Mission.WeaponeeringEntry item4 = new Mission.WeaponeeringEntry(int_4, type4, name4, maxRange_NoTargetType4, minRange_NoTargetType4, bearingOnlyLaunch4, string_4, 0, 0, 0, 0, ref waypoint_4);
					TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman.Add(item4);
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

	private void RateBroadcaster(ref Scenario scenario_0, ref Side side_0, ref ActiveUnit activeUnit_0, ref Waypoint waypoint_0, ref List<Mission.WeaponeeringEntry> list_0, List<Mission.TargeteeringEntry> list_1, ref bool bool_0, bool bool_1, ref Mission.Flight flight_0, string string_0)
	{
		try
		{
			if (TargetWaypoint_Lead.TargeteeringMethod != Mission._TargeteeringMethod.Individual)
			{
				return;
			}
			bool flag = false;
			if (Information.IsNothing(waypoint_0) || waypoint_0.FlightplanPointsList.Count <= 0)
			{
				return;
			}
			int count = waypoint_0.FlightplanPointsList.Count;
			double double_;
			double double_2;
			if (waypoint_0.Type == Waypoint.WaypointType.Target)
			{
				double_ = waypoint_0.FlightplanPointsList[count - 1].StartLatitude;
				double_2 = waypoint_0.FlightplanPointsList[count - 1].StartLongitude;
			}
			else
			{
				if (waypoint_0.Type != Waypoint.WaypointType.WeaponTarget)
				{
					return;
				}
				double_ = waypoint_0.FlightplanPointsList[count - 1].EndLatitude;
				double_2 = waypoint_0.FlightplanPointsList[count - 1].EndLongitude;
			}
			Mission.TargeteeringEntry targeteeringEntry_ = null;
			foreach (Mission.WeaponeeringEntry item in list_0)
			{
				Mission.WeaponeeringEntry weaponeeringEntry_ = item;
				if (flag)
				{
					weaponeeringEntry_.IsRouteReference = false;
				}
				else
				{
					weaponeeringEntry_.IsRouteReference = true;
					flag = true;
				}
				foreach (Mission.TargeteeringEntry item2 in list_1)
				{
					if (Operators.CompareString(weaponeeringEntry_.TargeteeringEntryObjectID, item2.ObjectID, TextCompare: true) == 0)
					{
						targeteeringEntry_ = item2;
						break;
					}
				}
				Weapon weapon_ = Weapon.GetNewWeapon(ref scenario_0, weaponeeringEntry_.int_0, bool_0: false);
				Contact contact_ = null;
				if (side_0.Contacts.ContainsKey(targeteeringEntry_.Target_ActualUnitObjectID))
				{
					side_0.Contacts.TryGetValue(targeteeringEntry_.Target_ActualUnitObjectID, ref contact_);
				}
				double latitude = contact_.GetLatitude();
				double longitude = contact_.GetLongitude();
				float float_ = (contact_.AltitudeIsKnown ? contact_.GetCurrentAltitude() : ((float)Terrain.GetElevation(latitude, longitude, bool_0: false, scenario_0)));
				float float_2 = 10000f;
				MissionPlanner.CreateWeaponRoute(ref scenario_0, ref activeUnit_0, ref targeteeringEntry_, ref weaponeeringEntry_, ref waypoint_0, ref IPWaypoint_Lead, ref weaponeeringEntry_.Route, ref weapon_, ref targeteeringEntry_.Target_Type, ref contact_, double_, double_2, float_2, latitude, longitude, float_, ref bool_0, bool_1, ref flight_0, string_0);
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

	private void FlushBroadcaster()
	{
	}

	internal void ForgotBroadcaster(bool bool_0, bool bool_1)
	{
		try
		{
			if (Client.CurrentSide != null || Client.CurrentSide.Units.Count == 0)
			{
				return;
			}
			CloneIdentifier();
			int num = 0;
			int index = 0;
			int firstDisplayedScrollingRowIndex = TGV_Targeteering.FirstDisplayedScrollingRowIndex;
			if (TGV_Targeteering.SelectedCells.Count > 0)
			{
				num = TGV_Targeteering.SelectedCells[0].RowIndex;
				index = TGV_Targeteering.SelectedCells[0].ColumnIndex;
			}
			TGV_Targeteering.Nodes.Clear();
			int num2 = 0;
			int index2 = 0;
			int firstDisplayedScrollingRowIndex2 = TGV_Weaponeering.FirstDisplayedScrollingRowIndex;
			if (TGV_Weaponeering.SelectedCells.Count > 0)
			{
				num2 = TGV_Weaponeering.SelectedCells[0].RowIndex;
				index2 = TGV_Weaponeering.SelectedCells[0].ColumnIndex;
			}
			TGV_Weaponeering.Nodes.Clear();
			string string_ = "此名称未找到！";
			switch (TargetWaypoint_Lead.TargeteeringMethod)
			{
			case Mission._TargeteeringMethod.Mission:
				string_ = "Mission";
				break;
			case Mission._TargeteeringMethod.Flight:
				string_ = "Flight";
				break;
			case Mission._TargeteeringMethod.Individual:
				string_ = "飞机＃1";
				break;
			}
			CollectBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList, ref TargetWaypoint_Lead);
			OrderBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList, ref TargetWaypoint_Lead.WeaponeeringList, ref TargetWaypoint_Lead);
			if (AircraftList.Contains("Aircraft #2"))
			{
				Waypoint waypoint_ = (Information.IsNothing(TargetWaypoint_Lead.Waypoint_LeadElementWingman) ? TargetWaypoint_Lead : TargetWaypoint_Lead.Waypoint_LeadElementWingman);
				string_ = "Aircraft #2";
				CollectBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_LeadElementWingman, ref waypoint_);
				OrderBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_LeadElementWingman, ref TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman, ref waypoint_);
			}
			if (AircraftList.Contains("Aircraft #3"))
			{
				Waypoint waypoint_2 = (Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElement) ? TargetWaypoint_Lead : TargetWaypoint_Lead.Waypoint_SecondElement);
				string_ = "Aircraft #3";
				CollectBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElement, ref waypoint_2);
				OrderBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElement, ref TargetWaypoint_Lead.WeaponeeringList_SecondElement, ref waypoint_2);
			}
			if (AircraftList.Contains("Aircraft #4"))
			{
				Waypoint waypoint_3 = (Information.IsNothing(TargetWaypoint_Lead.Waypoint_SecondElementWingman) ? TargetWaypoint_Lead : TargetWaypoint_Lead.Waypoint_SecondElementWingman);
				string_ = "Aircraft #4";
				CollectBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElementWingman, ref waypoint_3);
				OrderBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_SecondElementWingman, ref TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman, ref waypoint_3);
			}
			if (AircraftList.Contains("Aircraft #5"))
			{
				Waypoint waypoint_4 = (Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElement) ? TargetWaypoint_Lead : TargetWaypoint_Lead.Waypoint_ThirdElement);
				string_ = "Aircraft #5";
				CollectBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElement, ref waypoint_4);
				OrderBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElement, ref TargetWaypoint_Lead.WeaponeeringList_ThirdElement, ref waypoint_4);
			}
			if (AircraftList.Contains("Aircraft #6"))
			{
				Waypoint waypoint_5 = (Information.IsNothing(TargetWaypoint_Lead.Waypoint_ThirdElementWingman) ? TargetWaypoint_Lead : TargetWaypoint_Lead.Waypoint_ThirdElementWingman);
				string_ = "Aircraft #6";
				CollectBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman, ref waypoint_5);
				OrderBroadcaster(string_, ref TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman, ref TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman, ref waypoint_5);
			}
			if (bool_0)
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					if (!m_ExporterTask.Contains("飞机＃1"))
					{
						m_ExporterTask.Add("飞机＃1");
					}
					if (!m_ExporterTask.Contains("Aircraft #2"))
					{
						m_ExporterTask.Add("Aircraft #2");
					}
					if (!m_ExporterTask.Contains("Aircraft #3"))
					{
						m_ExporterTask.Add("Aircraft #3");
					}
					if (!m_ExporterTask.Contains("Aircraft #4"))
					{
						m_ExporterTask.Add("Aircraft #4");
					}
					if (!m_ExporterTask.Contains("Aircraft #5"))
					{
						m_ExporterTask.Add("Aircraft #5");
					}
					if (!m_ExporterTask.Contains("Aircraft #6"))
					{
						m_ExporterTask.Add("Aircraft #6");
					}
				}
				else if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
				{
					if (!m_ExporterTask.Contains("Flight"))
					{
						m_ExporterTask.Add("Flight");
					}
				}
				else if (!m_ExporterTask.Contains("Mission"))
				{
					m_ExporterTask.Add("Mission");
				}
			}
			if (bool_1)
			{
				if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
				{
					if (!m_PrototypeTask.Contains("飞机＃1"))
					{
						m_PrototypeTask.Add("飞机＃1");
					}
					if (!m_PrototypeTask.Contains("Aircraft #2"))
					{
						m_PrototypeTask.Add("Aircraft #2");
					}
					if (!m_PrototypeTask.Contains("Aircraft #3"))
					{
						m_PrototypeTask.Add("Aircraft #3");
					}
					if (!m_PrototypeTask.Contains("Aircraft #4"))
					{
						m_PrototypeTask.Add("Aircraft #4");
					}
					if (!m_PrototypeTask.Contains("Aircraft #5"))
					{
						m_PrototypeTask.Add("Aircraft #5");
					}
					if (!m_PrototypeTask.Contains("Aircraft #6"))
					{
						m_PrototypeTask.Add("Aircraft #6");
					}
				}
				else if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
				{
					if (!m_PrototypeTask.Contains("Flight"))
					{
						m_PrototypeTask.Add("Flight");
					}
				}
				else if (!m_PrototypeTask.Contains("Mission"))
				{
					m_PrototypeTask.Add("Mission");
				}
			}
			foreach (string item in m_ExporterTask)
			{
				foreach (TreeGridNode node in TGV_Targeteering.Nodes)
				{
					try
					{
						if ((object)(string)node.Tag == item)
						{
							node.Expand();
							break;
						}
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
			}
			foreach (string item2 in m_PrototypeTask)
			{
				foreach (TreeGridNode node2 in TGV_Weaponeering.Nodes)
				{
					try
					{
						if ((object)(string)node2.Tag == item2)
						{
							node2.Expand();
							break;
						}
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 999999", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			foreach (TreeGridNode node3 in TGV_Weaponeering.Nodes)
			{
				try
				{
					foreach (TreeGridNode node4 in node3.Nodes)
					{
						Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)node4.Tag;
						if ((weaponeeringEntry.WeaponType == Weapon._WeaponType.GuidedWeapon) | (weaponeeringEntry.WeaponType == Weapon._WeaponType.GuidedProjectile))
						{
							DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
							dataGridViewTextBoxCell.Value = "";
							TGV_Weaponeering[WeaponQty.Index, node4.RowIndex] = dataGridViewTextBoxCell;
							dataGridViewTextBoxCell.ReadOnly = true;
						}
						if (Conversions.ToInteger(TGV_Weaponeering[Target.Index, node4.RowIndex].Value) == 0)
						{
							DataGridViewTextBoxCell dataGridViewTextBoxCell2 = new DataGridViewTextBoxCell();
							DataGridViewTextBoxCell dataGridViewTextBoxCell3 = new DataGridViewTextBoxCell();
							DataGridViewTextBoxCell dataGridViewTextBoxCell4 = new DataGridViewTextBoxCell();
							dataGridViewTextBoxCell2.Value = "";
							dataGridViewTextBoxCell3.Value = "";
							dataGridViewTextBoxCell4.Value = "";
							TGV_Weaponeering[WeaponQty.Index, node4.RowIndex] = dataGridViewTextBoxCell2;
							TGV_Weaponeering[FiringRange.Index, node4.RowIndex] = dataGridViewTextBoxCell4;
							TGV_Weaponeering[LostTarget.Index, node4.RowIndex] = dataGridViewTextBoxCell3;
							dataGridViewTextBoxCell2.ReadOnly = true;
							dataGridViewTextBoxCell3.ReadOnly = true;
							dataGridViewTextBoxCell4.ReadOnly = true;
						}
					}
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
					ProjectData.ClearProjectError();
				}
			}
			if (TGV_Targeteering.Rows.Count != 0 && num != 0)
			{
				TGV_Targeteering.Rows[num].Cells[index].Selected = true;
				if (firstDisplayedScrollingRowIndex != -1)
				{
					TGV_Targeteering.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
				}
			}
			if (TGV_Weaponeering.Rows.Count != 0 && num2 != 0)
			{
				TGV_Weaponeering.Rows[num2].Cells[index2].Selected = true;
				if (firstDisplayedScrollingRowIndex2 != -1)
				{
					TGV_Weaponeering.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex2;
				}
			}
			WriteIdentifier();
			ConnectIdentifier();
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CollectBroadcaster(string string_0, ref List<Mission.TargeteeringEntry> list_0, ref Waypoint waypoint_0)
	{
		try
		{
			int num = 0;
			TreeGridNode treeGridNode = TGV_Targeteering.Nodes.Add(string_0, null, null);
			treeGridNode.Tag = string_0;
			if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Mission)
			{
				List<Contact> list = FindMissionTargets();
				if (!Information.IsNothing(list) && list.Count > 0)
				{
					DateTime? dateTime = null;
					foreach (Contact item in list)
					{
						if (Information.IsNothing(item))
						{
							continue;
						}
						string text;
						if (Information.IsNothing(waypoint_0.Time_Zulu))
						{
							text = "-";
						}
						else
						{
							dateTime = (Information.IsNothing(waypoint_0.Time_Zulu_Weapon) ? waypoint_0.Time_Zulu : waypoint_0.Time_Zulu_Weapon);
							text = ((dateTime.Value.Hour < 10) ? ("0" + dateTime.Value.Hour + ":") : (dateTime.Value.Hour + ":"));
							text = ((dateTime.Value.Minute < 10) ? (text + "0" + dateTime.Value.Minute + ":") : (text + dateTime.Value.Minute + ":"));
							text = ((dateTime.Value.Second < 10) ? (text + "0" + dateTime.Value.Second) : (text + dateTime.Value.Second));
							if (waypoint_0.Type == Waypoint.WaypointType.Target || waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
							{
								string text3 = dateTime.Value.Year + "-";
								text3 = ((dateTime.Value.Month < 10) ? (text3 + "0" + dateTime.Value.Month + "-") : (text3 + dateTime.Value.Month + "-"));
								if (dateTime.Value.Day < 10)
								{
									text3 = text3 + "0" + dateTime.Value.Day;
								}
								else
								{
									text3 += dateTime.Value.Day;
								}
							}
						}
						string text4;
						if (!Information.IsNothing(dateTime) && !Information.IsNothing(waypoint_0.Time_Local))
						{
							DateTime time = Client.CurrentScenario.Time;
							bool use_DST = Client.CurrentScenario.Use_DST;
							string dST_Start = Client.CurrentScenario.DST_Start;
							string dST_End = Client.CurrentScenario.DST_End;
							DateTime? dateTime2 = (Information.IsNothing(waypoint_0.Time_Zulu_Weapon) ? waypoint_0.Time_Local : waypoint_0.Time_Local_Weapon);
							text4 = ((dateTime2.Value.Hour < 10) ? ("0" + dateTime2.Value.Hour + ":") : (dateTime2.Value.Hour + ":"));
							text4 = ((dateTime2.Value.Minute < 10) ? (text4 + "0" + dateTime2.Value.Minute + ":") : (text4 + dateTime2.Value.Minute + ":"));
							text4 = ((dateTime2.Value.Second < 10) ? (text4 + "0" + dateTime2.Value.Second) : (text4 + dateTime2.Value.Second));
							waypoint_0.TimeOfDay = SunModule.CollectSpecification(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, bool_0: false, waypoint_0.Latitude, waypoint_0.Longitude, 0.0);
							if (Information.IsNothing(waypoint_0.Time_Zulu_Weapon))
							{
								waypoint_0.Time_Local = Misc.DisableRequest(waypoint_0.Time_Zulu.Value, waypoint_0.Longitude, use_DST, dST_Start, dST_End);
							}
							else
							{
								waypoint_0.Time_Local = Misc.DisableRequest(waypoint_0.Time_Zulu_Weapon.Value, waypoint_0.Longitude, use_DST, dST_Start, dST_End);
							}
							text4 = text4 + " (" + SunModule.ForgotSpecification(waypoint_0.TimeOfDay, time, waypoint_0.Longitude, use_DST, dST_Start, dST_End) + ")";
						}
						else
						{
							text4 = "-";
						}
						string text5 = Misc.CoordsToEnglish(waypoint_0.Latitude, waypoint_0.Longitude);
						string text6 = "使用武器释放授权WRA";
						num++;
						treeGridNode.Nodes.Add(num, item.Name, text6, text, text4, text5);
					}
				}
			}
			else if (!Information.IsNothing(list_0))
			{
				DateTime? dateTime3 = null;
				foreach (Mission.TargeteeringEntry item2 in list_0)
				{
					string text7;
					if (Information.IsNothing(waypoint_0.Time_Zulu))
					{
						text7 = "-";
					}
					else
					{
						dateTime3 = (Information.IsNothing(waypoint_0.Time_Zulu_Weapon) ? waypoint_0.Time_Zulu : waypoint_0.Time_Zulu_Weapon);
						text7 = ((dateTime3.Value.Hour < 10) ? ("0" + dateTime3.Value.Hour + ":") : (dateTime3.Value.Hour + ":"));
						text7 = ((dateTime3.Value.Minute < 10) ? (text7 + "0" + dateTime3.Value.Minute + ":") : (text7 + dateTime3.Value.Minute + ":"));
						text7 = ((dateTime3.Value.Second < 10) ? (text7 + "0" + dateTime3.Value.Second) : (text7 + dateTime3.Value.Second));
						if (waypoint_0.Type == Waypoint.WaypointType.Target || waypoint_0.Type == Waypoint.WaypointType.WeaponTarget)
						{
							string text8 = dateTime3.Value.Year + "-";
							text8 = ((dateTime3.Value.Month < 10) ? (text8 + "0" + dateTime3.Value.Month + "-") : (text8 + dateTime3.Value.Month + "-"));
							if (dateTime3.Value.Day < 10)
							{
								text8 = text8 + "0" + dateTime3.Value.Day;
							}
							else
							{
								text8 += dateTime3.Value.Day;
							}
						}
					}
					string text9;
					if (!Information.IsNothing(dateTime3) && !Information.IsNothing(waypoint_0.Time_Local))
					{
						DateTime time2 = Client.CurrentScenario.Time;
						bool use_DST2 = Client.CurrentScenario.Use_DST;
						string dST_Start2 = Client.CurrentScenario.DST_Start;
						string dST_End2 = Client.CurrentScenario.DST_End;
						DateTime? dateTime4 = (Information.IsNothing(waypoint_0.Time_Zulu_Weapon) ? waypoint_0.Time_Local : waypoint_0.Time_Local_Weapon);
						text9 = ((dateTime4.Value.Hour < 10) ? ("0" + dateTime4.Value.Hour + ":") : (dateTime4.Value.Hour + ":"));
						text9 = ((dateTime4.Value.Minute < 10) ? (text9 + "0" + dateTime4.Value.Minute + ":") : (text9 + dateTime4.Value.Minute + ":"));
						text9 = ((dateTime4.Value.Second < 10) ? (text9 + "0" + dateTime4.Value.Second) : (text9 + dateTime4.Value.Second));
						waypoint_0.TimeOfDay = SunModule.CollectSpecification(null, dateTime3.Value.Year, dateTime3.Value.Month, dateTime3.Value.Day, dateTime3.Value.Hour, dateTime3.Value.Minute, dateTime3.Value.Second, bool_0: false, waypoint_0.Latitude, waypoint_0.Longitude, 0.0);
						if (Information.IsNothing(waypoint_0.Time_Zulu_Weapon))
						{
							waypoint_0.Time_Local = Misc.DisableRequest(waypoint_0.Time_Zulu.Value, waypoint_0.Longitude, use_DST2, dST_Start2, dST_End2);
						}
						else
						{
							waypoint_0.Time_Local = Misc.DisableRequest(waypoint_0.Time_Zulu_Weapon.Value, waypoint_0.Longitude, use_DST2, dST_Start2, dST_End2);
						}
						text9 = text9 + " (" + SunModule.ForgotSpecification(waypoint_0.TimeOfDay, time2, waypoint_0.Longitude, use_DST2, dST_Start2, dST_End2) + ")";
					}
					else
					{
						text9 = "-";
					}
					string text10 = Misc.CoordsToEnglish(waypoint_0.Latitude, waypoint_0.Longitude);
					string text2 = "未配置";
					switch (TargetWaypoint_Lead.TargeteeringMethod)
					{
					case Mission._TargeteeringMethod.Mission:
						text2 = "使用武器释放授权WRA";
						break;
					case Mission._TargeteeringMethod.Flight:
						text2 = "使用武器释放授权WRA";
						break;
					case Mission._TargeteeringMethod.Individual:
						text2 = "未指定武器";
						break;
					}
					num++;
					treeGridNode.Nodes.Add(num, item2.Target_Description, text2, text7, text9, text10).Tag = item2;
				}
			}
			DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell2 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell3 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell4 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell5 = new DataGridViewTextBoxCell();
			dataGridViewTextBoxCell.Value = "";
			dataGridViewTextBoxCell2.Value = "";
			dataGridViewTextBoxCell3.Value = "";
			dataGridViewTextBoxCell4.Value = "";
			dataGridViewTextBoxCell5.Value = "";
			TGV_Targeteering[TargetName.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell;
			TGV_Targeteering[AssignedWeapons.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell2;
			TGV_Targeteering[Time_Zulu.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell3;
			TGV_Targeteering[Time_Local.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell4;
			TGV_Targeteering[Coordinates.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell5;
			dataGridViewTextBoxCell.ReadOnly = true;
			dataGridViewTextBoxCell2.ReadOnly = true;
			dataGridViewTextBoxCell3.ReadOnly = true;
			dataGridViewTextBoxCell4.ReadOnly = true;
			dataGridViewTextBoxCell5.ReadOnly = true;
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

	private void OrderBroadcaster(string string_0, ref List<Mission.TargeteeringEntry> list_0, ref List<Mission.WeaponeeringEntry> list_1, ref Waypoint waypoint_0)
	{
		try
		{
			if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Mission || TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
			{
				return;
			}
			TreeGridNode treeGridNode = TGV_Weaponeering.Nodes.Add(string_0, null, null, null, null, null);
			treeGridNode.Tag = string_0;
			if (!Information.IsNothing(list_1))
			{
				foreach (Mission.WeaponeeringEntry item in list_1)
				{
					int num = Target_To_TargetSelection(item.TargeteeringEntryObjectID, ref list_0);
					string text = "-";
					if (!Information.IsNothing(item.Route) && item.Route.Count() > 0)
					{
						string text2 = "";
						if (!Information.IsNothing(item.Route[item.Route.Count() - 1].Time_Zulu))
						{
							text2 = "到达目标时间：" + item.Route[item.Route.Count() - 1].Time_Zulu.ToString() + ", ";
						}
						string text3 = "飞行时间：" + Conversions.ToString(item.Route[item.Route.Count() - 1].Leg_TotalTime) + ", ";
						string text4 = " 路径点：" + Conversions.ToString(item.Route.Count());
						text = text2 + text3 + text4;
					}
					string text5 = item.WeaponName;
					if (item.IsRouteReference)
					{
						text5 = "参考时间：" + text5;
					}
					treeGridNode.Nodes.Add(text5, num, item.LostTarget, WeaponQty_To_WeaponQtySelection(item.WeaponQty), item.FiringRange, text).Tag = item;
				}
			}
			DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell2 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell3 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell4 = new DataGridViewTextBoxCell();
			DataGridViewTextBoxCell dataGridViewTextBoxCell5 = new DataGridViewTextBoxCell();
			dataGridViewTextBoxCell.Value = "";
			dataGridViewTextBoxCell2.Value = "";
			dataGridViewTextBoxCell3.Value = "";
			dataGridViewTextBoxCell4.Value = "";
			dataGridViewTextBoxCell5.Value = "";
			TGV_Weaponeering[Target.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell;
			TGV_Weaponeering[LostTarget.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell2;
			TGV_Weaponeering[WeaponQty.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell3;
			TGV_Weaponeering[FiringRange.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell4;
			TGV_Weaponeering[Route.Index, treeGridNode.RowIndex] = dataGridViewTextBoxCell5;
			dataGridViewTextBoxCell.ReadOnly = true;
			dataGridViewTextBoxCell2.ReadOnly = true;
			dataGridViewTextBoxCell3.ReadOnly = true;
			dataGridViewTextBoxCell4.ReadOnly = true;
			dataGridViewTextBoxCell5.ReadOnly = true;
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

	private void RegisterBroadcaster(object sender, ExpandingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			string item = (string)e.Node.Tag;
			if (!m_ExporterTask.Contains(item))
			{
				m_ExporterTask.Add(item);
			}
		}
	}

	private void ManageBroadcaster(object sender, ExpandingEventArgs e)
	{
		try
		{
			if (e.Node.Level != 1)
			{
				return;
			}
			string text = (string)e.Node.Tag;
			if (!m_PrototypeTask.Contains(text))
			{
				m_PrototypeTask.Add(text);
			}
			foreach (TreeGridNode node in e.Node.Nodes)
			{
				DataTable dataTable_ = new DataTable();
				DataTable dataTable_2 = new DataTable();
				DataTable dataTable_3 = new DataTable();
				DataTable dataTable_4 = new DataTable();
				DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)node.Cells[WeaponQty.Index];
				DataGridViewComboBoxCell dataGridViewComboBoxCell2 = (DataGridViewComboBoxCell)node.Cells[Target.Index];
				DataGridViewComboBoxCell dataGridViewComboBoxCell3 = (DataGridViewComboBoxCell)node.Cells[LostTarget.Index];
				DataGridViewComboBoxCell dataGridViewComboBoxCell4 = (DataGridViewComboBoxCell)node.Cells[FiringRange.Index];
				Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)node.Tag;
				Weapon weapon_ = null;
				ComboBoxDataSource_WeaponQty(ref dataTable_, null, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell.Value), weaponeeringEntry.WeaponMaxQty);
				List<Mission.TargeteeringEntry> list_ = ((Operators.CompareString(text, "飞机＃1", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList : ((Operators.CompareString(text, "Aircraft #2", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_LeadElementWingman : ((Operators.CompareString(text, "Aircraft #3", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_SecondElement : ((Operators.CompareString(text, "Aircraft #4", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_SecondElementWingman : ((Operators.CompareString(text, "Aircraft #5", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_ThirdElement : ((Operators.CompareString(text, "Aircraft #6", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman : TargetWaypoint_Lead.TargeteeringList))))));
				ComboBoxDataSource_Target(ref dataTable_2, Conversions.ToInteger(dataGridViewComboBoxCell2.Value), ref list_);
				ComboBoxDataSource_LostTarget(ref dataTable_3, Conversions.ToInteger(dataGridViewComboBoxCell3.Value), weaponeeringEntry.bool_0);
				ComboBoxDataSource_FiringRange(ref dataTable_4, weaponeeringEntry.WeaponMaxRange, weaponeeringEntry.WeaponMinRange, Conversions.ToInteger(dataGridViewComboBoxCell4.Value));
				dataGridViewComboBoxCell.DataSource = dataTable_;
				dataGridViewComboBoxCell.DisplayMember = "Description";
				dataGridViewComboBoxCell.ValueMember = "ID";
				dataGridViewComboBoxCell4.DataSource = dataTable_4;
				dataGridViewComboBoxCell4.DisplayMember = "Description";
				dataGridViewComboBoxCell4.ValueMember = "ID";
				dataGridViewComboBoxCell3.DataSource = dataTable_3;
				dataGridViewComboBoxCell3.DisplayMember = "Description";
				dataGridViewComboBoxCell3.ValueMember = "ID";
				dataGridViewComboBoxCell2.DataSource = dataTable_2;
				dataGridViewComboBoxCell2.DisplayMember = "Description";
				dataGridViewComboBoxCell2.ValueMember = "ID";
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

	private void RevertBroadcaster(object sender, CollapsingEventArgs e)
	{
		string item = (string)e.Node.Tag;
		if (e.Node.Level == 1)
		{
			m_ExporterTask.Remove(item);
		}
	}

	private void CountIdentifier(object sender, CollapsingEventArgs e)
	{
		string item = (string)e.Node.Tag;
		if (e.Node.Level == 1)
		{
			m_PrototypeTask.Remove(item);
		}
	}

	public void FindAllAircraft()
	{
		try
		{
			AircraftList.Clear();
			if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Flight)
			{
				if (!AircraftList.Contains("Flight"))
				{
					AircraftList.Add("Flight");
				}
			}
			else if (TargetWaypoint_Lead.TargeteeringMethod == Mission._TargeteeringMethod.Individual)
			{
				if (!AircraftList.Contains("飞机＃1"))
				{
					AircraftList.Add("飞机＃1");
				}
				if (SelectedFlight.DesiredAircraftQty > 1 && !AircraftList.Contains("Aircraft #2"))
				{
					AircraftList.Add("Aircraft #2");
				}
				if (SelectedFlight.DesiredAircraftQty > 2 && !AircraftList.Contains("Aircraft #3"))
				{
					AircraftList.Add("Aircraft #3");
				}
				if (SelectedFlight.DesiredAircraftQty > 3 && !AircraftList.Contains("Aircraft #4"))
				{
					AircraftList.Add("Aircraft #4");
				}
				if (SelectedFlight.DesiredAircraftQty > 4 && !AircraftList.Contains("Aircraft #5"))
				{
					AircraftList.Add("Aircraft #5");
				}
				if (SelectedFlight.DesiredAircraftQty > 4 && !AircraftList.Contains("Aircraft #6"))
				{
					AircraftList.Add("Aircraft #6");
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

	public void Weaponeering_RetreiveLoadoutWeapons(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(((Aircraft)activeUnit_0).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
		WeaponRec[] array = weapons;
		foreach (WeaponRec weaponRec in array)
		{
			Weapon weapon_ = weaponRec.GetReferenceWeapon(Client.CurrentScenario);
			if (StrikeMissionIsSuitableForThisTarget(Client.CurrentScenario, ref weapon_))
			{
				recordTask.Add(weaponRec);
			}
		}
	}

	public void Weaponeering_RetreiveMagazineWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Magazine item in activeUnit_0.SharedMagazines.OrderBy((Magazine theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				Weapon weapon_ = weapon.GetReferenceWeapon(Client.CurrentScenario);
				if (StrikeMissionIsSuitableForThisTarget(Client.CurrentScenario, ref weapon_))
				{
					recordTask.Add(weapon);
				}
			}
		}
	}

	public void Weaponeering_RetreiveMountWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Mount item in activeUnit_0.Mounts.OrderBy((Mount theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon weapon_ = mountWeapon.GetReferenceWeapon(Client.CurrentScenario);
				if (StrikeMissionIsSuitableForThisTarget(Client.CurrentScenario, ref weapon_))
				{
					recordTask.Add(mountWeapon);
				}
			}
		}
	}

	public bool StrikeMissionIsSuitableForThisTarget(Scenario scenario_0, ref Weapon weapon_0)
	{
		try
		{
			switch (((Strike)SelectedMission).Type)
			{
			default:
				return false;
			case Strike.StrikeType.Maritime_Strike:
				if (weapon_0.ValidTargets.SurfaceVessel)
				{
					return true;
				}
				return false;
			case Strike.StrikeType.Land_Strike:
				if (!weapon_0.ValidTargets.LandStructure_Hard && !weapon_0.ValidTargets.LandStructure_Soft && !weapon_0.ValidTargets.MobileTarget_Hard && !weapon_0.ValidTargets.LandStructure_Soft && !weapon_0.ValidTargets.Radar && !weapon_0.ValidTargets.Runway)
				{
					return false;
				}
				return true;
			}
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
			return false;
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	private void CloneIdentifier()
	{
		SendMessage(base.Handle, 11, new IntPtr(0), IntPtr.Zero);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.SuspendRefresh();
	}

	private void ConnectIdentifier(bool bool_0 = true)
	{
		SendMessage(base.Handle, 11, new IntPtr(-1), IntPtr.Zero);
		if (bool_0)
		{
			Refresh();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.ResumeRefresh();
	}

	internal void MoveIdentifier()
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
			else if (SelectedMission.RestartValue())
			{
				Text = "飞行的飞行计划编辑" + SelectedFlight.Callsign;
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

	private void DeleteIdentifier(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1 || e.ColumnIndex == -1)
			{
				return;
			}
			foreach (TreeGridNode node in TGV_Targeteering.Nodes)
			{
				if (node.Selected)
				{
					break;
				}
				foreach (TreeGridNode node2 in node.Nodes)
				{
					_ = node2.Selected;
				}
			}
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

	private void AddIdentifier(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1 || e.ColumnIndex == -1)
			{
				return;
			}
			foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
			{
				if (node.Selected)
				{
					break;
				}
				string left = (string)node.Tag;
				foreach (TreeGridNode node2 in node.Nodes)
				{
					if (!node2.Selected)
					{
						continue;
					}
					DataTable dataTable_ = new DataTable();
					DataTable dataTable_2 = new DataTable();
					DataTable dataTable_3 = new DataTable();
					DataTable dataTable_4 = new DataTable();
					DataGridViewColumn dataGridViewColumn = TGV_Weaponeering.Columns[e.ColumnIndex];
					if (Operators.CompareString(dataGridViewColumn.Name, "Target", TextCompare: true) != 0)
					{
						if (Operators.CompareString(dataGridViewColumn.Name, "LostTarget", TextCompare: true) != 0)
						{
							if (Operators.CompareString(dataGridViewColumn.Name, "WeaponQty", TextCompare: true) != 0)
							{
								if (Operators.CompareString(dataGridViewColumn.Name, "FiringRange", TextCompare: true) != 0)
								{
									continue;
								}
								if (TGV_Weaponeering[FiringRange.Index, node2.RowIndex].GetType().ToString().Contains("ComboBoxCell"))
								{
									Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)node2.Tag;
									DataGridViewComboBoxCell dataGridViewComboBoxCell = (DataGridViewComboBoxCell)node2.Cells[FiringRange.Index];
									ComboBoxDataSource_FiringRange(ref dataTable_4, weaponeeringEntry.WeaponMaxRange, weaponeeringEntry.WeaponMinRange, Conversions.ToInteger(dataGridViewComboBoxCell.Value));
									dataGridViewComboBoxCell.DataSource = dataTable_4;
									dataGridViewComboBoxCell.DropDownWidth = 500;
									dataGridViewComboBoxCell.DisplayMember = "Description";
									dataGridViewComboBoxCell.ValueMember = "ID";
									TGV_Weaponeering.BeginEdit(selectAll: true);
									((DataGridViewComboBoxEditingControl)TGV_Weaponeering.EditingControl).DroppedDown = true;
								}
								break;
							}
							if (TGV_Weaponeering[WeaponQty.Index, node2.RowIndex].GetType().ToString().Contains("ComboBoxCell"))
							{
								Mission.WeaponeeringEntry weaponeeringEntry2 = (Mission.WeaponeeringEntry)node2.Tag;
								DataGridViewComboBoxCell dataGridViewComboBoxCell2 = (DataGridViewComboBoxCell)node2.Cells[WeaponQty.Index];
								Weapon weapon_ = null;
								ComboBoxDataSource_WeaponQty(ref dataTable_2, null, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell2.Value), weaponeeringEntry2.WeaponMaxQty);
								dataGridViewComboBoxCell2.DataSource = dataTable_2;
								dataGridViewComboBoxCell2.DropDownWidth = 500;
								dataGridViewComboBoxCell2.DisplayMember = "Description";
								dataGridViewComboBoxCell2.ValueMember = "ID";
								TGV_Weaponeering.BeginEdit(selectAll: true);
								((DataGridViewComboBoxEditingControl)TGV_Weaponeering.EditingControl).DroppedDown = true;
							}
							break;
						}
						if (TGV_Weaponeering[LostTarget.Index, node2.RowIndex].GetType().ToString().Contains("ComboBoxCell"))
						{
							Mission.WeaponeeringEntry weaponeeringEntry3 = (Mission.WeaponeeringEntry)node2.Tag;
							DataGridViewComboBoxCell dataGridViewComboBoxCell3 = (DataGridViewComboBoxCell)node2.Cells[LostTarget.Index];
							ComboBoxDataSource_LostTarget(ref dataTable_3, Conversions.ToInteger(dataGridViewComboBoxCell3.Value), weaponeeringEntry3.bool_0);
							dataGridViewComboBoxCell3.DataSource = dataTable_3;
							dataGridViewComboBoxCell3.DisplayMember = "Description";
							dataGridViewComboBoxCell3.ValueMember = "ID";
							dataGridViewComboBoxCell3.DropDownWidth = 500;
							TGV_Weaponeering.BeginEdit(selectAll: true);
							((DataGridViewComboBoxEditingControl)TGV_Weaponeering.EditingControl).DroppedDown = true;
						}
						break;
					}
					List<Mission.TargeteeringEntry> list_ = ((Operators.CompareString(left, "飞机＃1", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList : ((Operators.CompareString(left, "Aircraft #2", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_LeadElementWingman : ((Operators.CompareString(left, "Aircraft #3", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_SecondElement : ((Operators.CompareString(left, "Aircraft #4", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_SecondElementWingman : ((Operators.CompareString(left, "Aircraft #5", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_ThirdElement : ((Operators.CompareString(left, "Aircraft #6", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman : TargetWaypoint_Lead.TargeteeringList))))));
					DataGridViewComboBoxCell dataGridViewComboBoxCell4 = (DataGridViewComboBoxCell)node2.Cells[Target.Index];
					ComboBoxDataSource_Target(ref dataTable_, Conversions.ToInteger(dataGridViewComboBoxCell4.Value), ref list_);
					dataGridViewComboBoxCell4.DataSource = dataTable_;
					dataGridViewComboBoxCell4.DisplayMember = "Description";
					dataGridViewComboBoxCell4.ValueMember = "ID";
					dataGridViewComboBoxCell4.DropDownWidth = 500;
					TGV_Weaponeering.BeginEdit(selectAll: true);
					((DataGridViewComboBoxEditingControl)TGV_Weaponeering.EditingControl).DroppedDown = true;
					break;
				}
			}
			WriteIdentifier();
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

	private void DestroyIdentifier(object sender, DataGridViewCellEventArgs e)
	{
		if (!m_AttrTask || TGV_Targeteering.SelectedRows.Count == 0)
		{
			return;
		}
		TreeGridNode treeGridNode = null;
		bool flag = false;
		foreach (TreeGridNode node in TGV_Targeteering.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					treeGridNode = node2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!Information.IsNothing(treeGridNode) && !Information.IsNothing(treeGridNode.Parent))
		{
			_ = treeGridNode.Parent;
		}
	}

	private void ComputeIdentifier(object sender, DataGridViewCellEventArgs e)
	{
		if (!m_AttrTask || TGV_Weaponeering.SelectedRows.Count == 0)
		{
			return;
		}
		TreeGridNode treeGridNode = null;
		bool flag = false;
		foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					treeGridNode = node2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!Information.IsNothing(treeGridNode) && !Information.IsNothing(treeGridNode.Parent))
		{
			TreeGridNode treeGridNode_ = treeGridNode.Parent;
			PatchIdentifier(e, treeGridNode, treeGridNode_);
		}
	}

	private void PatchIdentifier(DataGridViewCellEventArgs dataGridViewCellEventArgs_0, TreeGridNode treeGridNode_0, TreeGridNode treeGridNode_1)
	{
		RuntimeHelpers.GetObjectValue(TGV_Weaponeering[dataGridViewCellEventArgs_0.ColumnIndex, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue = RuntimeHelpers.GetObjectValue(TGV_Weaponeering[Target.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue2 = RuntimeHelpers.GetObjectValue(TGV_Weaponeering[WeaponQty.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue3 = RuntimeHelpers.GetObjectValue(TGV_Weaponeering[LostTarget.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		object objectValue4 = RuntimeHelpers.GetObjectValue(TGV_Weaponeering[FiringRange.Index, dataGridViewCellEventArgs_0.RowIndex].Value);
		Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)treeGridNode_0.Tag;
		bool flag = false;
		Mission.TargeteeringEntry targeteeringEntry = null;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == Target.Index)
		{
			string right = (string)treeGridNode_1.Tag;
			foreach (string aircraft in AircraftList)
			{
				if (Operators.CompareString(aircraft, right, TextCompare: true) != 0)
				{
					continue;
				}
				flag = true;
				List<Mission.TargeteeringEntry> list_ = ((Operators.CompareString(aircraft, "飞机＃1", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList : ((Operators.CompareString(aircraft, "Aircraft #2", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_LeadElementWingman : ((Operators.CompareString(aircraft, "Aircraft #3", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_SecondElement : ((Operators.CompareString(aircraft, "Aircraft #4", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_SecondElementWingman : ((Operators.CompareString(aircraft, "Aircraft #5", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_ThirdElement : ((Operators.CompareString(aircraft, "Aircraft #6", TextCompare: true) == 0) ? TargetWaypoint_Lead.TargeteeringList_ThirdElementWingman : TargetWaypoint_Lead.TargeteeringList))))));
				targeteeringEntry = TargetSelection_To_Target(RuntimeHelpers.GetObjectValue(objectValue), ref list_);
				if (Information.IsNothing(targeteeringEntry))
				{
					DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell();
					DataGridViewTextBoxCell dataGridViewTextBoxCell2 = new DataGridViewTextBoxCell();
					DataGridViewTextBoxCell dataGridViewTextBoxCell3 = new DataGridViewTextBoxCell();
					dataGridViewTextBoxCell.Value = "";
					dataGridViewTextBoxCell2.Value = "";
					dataGridViewTextBoxCell3.Value = "";
					TGV_Weaponeering[WeaponQty.Index, treeGridNode_0.RowIndex] = dataGridViewTextBoxCell;
					TGV_Weaponeering[FiringRange.Index, treeGridNode_0.RowIndex] = dataGridViewTextBoxCell3;
					TGV_Weaponeering[LostTarget.Index, treeGridNode_0.RowIndex] = dataGridViewTextBoxCell2;
					dataGridViewTextBoxCell.ReadOnly = true;
					dataGridViewTextBoxCell2.ReadOnly = true;
					dataGridViewTextBoxCell3.ReadOnly = true;
					break;
				}
				Mission.WeaponeeringEntry weaponeeringEntry2 = (Mission.WeaponeeringEntry)treeGridNode_0.Tag;
				if ((weaponeeringEntry2.WeaponType == Weapon._WeaponType.GuidedWeapon) | (weaponeeringEntry2.WeaponType == Weapon._WeaponType.GuidedProjectile))
				{
					DataGridViewTextBoxCell dataGridViewTextBoxCell4 = new DataGridViewTextBoxCell();
					dataGridViewTextBoxCell4.Value = "";
					TGV_Weaponeering[WeaponQty.Index, treeGridNode_0.RowIndex] = dataGridViewTextBoxCell4;
					dataGridViewTextBoxCell4.ReadOnly = true;
				}
				else
				{
					if (TGV_Weaponeering[WeaponQty.Index, treeGridNode_0.RowIndex].GetType().ToString().Contains("TextBoxCell"))
					{
						DataGridViewComboBoxCell dataGridViewComboBoxCell = new DataGridViewComboBoxCell();
						TGV_Weaponeering[WeaponQty.Index, treeGridNode_0.RowIndex] = dataGridViewComboBoxCell;
						dataGridViewComboBoxCell.ReadOnly = false;
					}
					DataTable dataTable_ = new DataTable();
					DataGridViewComboBoxCell dataGridViewComboBoxCell2 = (DataGridViewComboBoxCell)treeGridNode_0.Cells[WeaponQty.Index];
					Weapon weapon_ = null;
					ComboBoxDataSource_WeaponQty(ref dataTable_, null, ref weapon_, Conversions.ToInteger(dataGridViewComboBoxCell2.Value), weaponeeringEntry.WeaponMaxQty);
					dataGridViewComboBoxCell2.DataSource = dataTable_;
					dataGridViewComboBoxCell2.DisplayMember = "Description";
					dataGridViewComboBoxCell2.ValueMember = "ID";
					treeGridNode_0.Cells[WeaponQty.Index].Value = WeaponQty_To_WeaponQtySelection(weaponeeringEntry.WeaponQty);
				}
				if (TGV_Weaponeering[LostTarget.Index, treeGridNode_0.RowIndex].GetType().ToString().Contains("TextBoxCell"))
				{
					DataGridViewComboBoxCell dataGridViewComboBoxCell3 = new DataGridViewComboBoxCell();
					TGV_Weaponeering[LostTarget.Index, treeGridNode_0.RowIndex] = dataGridViewComboBoxCell3;
					dataGridViewComboBoxCell3.ReadOnly = false;
				}
				if (TGV_Weaponeering[FiringRange.Index, treeGridNode_0.RowIndex].GetType().ToString().Contains("TextBoxCell"))
				{
					DataGridViewComboBoxCell dataGridViewComboBoxCell4 = new DataGridViewComboBoxCell();
					TGV_Weaponeering[FiringRange.Index, treeGridNode_0.RowIndex] = dataGridViewComboBoxCell4;
					dataGridViewComboBoxCell4.ReadOnly = false;
				}
				DataTable dataTable_2 = new DataTable();
				DataTable dataTable_3 = new DataTable();
				DataGridViewComboBoxCell dataGridViewComboBoxCell5 = (DataGridViewComboBoxCell)treeGridNode_0.Cells[LostTarget.Index];
				DataGridViewComboBoxCell dataGridViewComboBoxCell6 = (DataGridViewComboBoxCell)treeGridNode_0.Cells[FiringRange.Index];
				ComboBoxDataSource_LostTarget(ref dataTable_2, Conversions.ToInteger(dataGridViewComboBoxCell5.Value), weaponeeringEntry.bool_0);
				ComboBoxDataSource_FiringRange(ref dataTable_3, weaponeeringEntry.WeaponMaxRange, weaponeeringEntry.WeaponMinRange, Conversions.ToInteger(dataGridViewComboBoxCell6.Value));
				dataGridViewComboBoxCell6.DataSource = dataTable_3;
				dataGridViewComboBoxCell6.DisplayMember = "Description";
				dataGridViewComboBoxCell6.ValueMember = "ID";
				dataGridViewComboBoxCell5.DataSource = dataTable_2;
				dataGridViewComboBoxCell5.DisplayMember = "Description";
				dataGridViewComboBoxCell5.ValueMember = "ID";
				treeGridNode_0.Cells[LostTarget.Index].Value = weaponeeringEntry.LostTarget;
				treeGridNode_0.Cells[FiringRange.Index].Value = FiringRange_To_FiringRangeSelection(weaponeeringEntry.FiringRange);
				break;
			}
		}
		bool flag2 = false;
		int weaponQty = 0;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == WeaponQty.Index)
		{
			flag2 = true;
			weaponQty = WeaponQtySelection_To_WeaponQty(RuntimeHelpers.GetObjectValue(objectValue2));
		}
		bool flag3 = false;
		int firingRange = 0;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == FiringRange.Index)
		{
			flag3 = true;
			firingRange = FiringRangeSelection_To_FiringRange(RuntimeHelpers.GetObjectValue(objectValue4));
		}
		bool flag4 = false;
		int lostTarget = 0;
		if (dataGridViewCellEventArgs_0.RowIndex != -1 && dataGridViewCellEventArgs_0.ColumnIndex == LostTarget.Index)
		{
			flag4 = true;
			lostTarget = (int)LostTargetSelection_To_LostTarget(RuntimeHelpers.GetObjectValue(objectValue3));
		}
		if (Information.IsNothing(weaponeeringEntry))
		{
			return;
		}
		if (flag)
		{
			if (Information.IsNothing(targeteeringEntry))
			{
				weaponeeringEntry.TargeteeringEntryObjectID = "";
			}
			else
			{
				weaponeeringEntry.TargeteeringEntryObjectID = targeteeringEntry.ObjectID;
			}
		}
		else if (flag2)
		{
			weaponeeringEntry.WeaponQty = weaponQty;
		}
		else if (flag4)
		{
			weaponeeringEntry.LostTarget = lostTarget;
		}
		else if (flag3)
		{
			weaponeeringEntry.FiringRange = firingRange;
		}
	}

	private void SelectIdentifier(object sender, EventArgs e)
	{
		m_AttrTask = true;
		if (TGV_Targeteering.IsCurrentCellDirty)
		{
			TGV_Targeteering.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void CallIdentifier(object sender, EventArgs e)
	{
		m_AttrTask = true;
		if (TGV_Weaponeering.IsCurrentCellDirty)
		{
			TGV_Weaponeering.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void LogoutIdentifier(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedMission) || SelectedMission.MissionClass != Mission._MissionClass.Strike)
		{
			return;
		}
		if (Information.IsNothing(SelectedAircraft))
		{
			SelectedAircraft = "飞机＃1";
		}
		if (!m_ExporterTask.Contains(SelectedAircraft))
		{
			m_ExporterTask.Add(SelectedAircraft);
		}
		Waypoint waypoint = ((Operators.CompareString(SelectedAircraft, "飞机＃1", TextCompare: true) == 0) ? TargetWaypoint_Lead : ((Operators.CompareString(SelectedAircraft, "Aircraft #2", TextCompare: true) == 0) ? TargetWaypoint_Lead.Waypoint_LeadElementWingman : ((Operators.CompareString(SelectedAircraft, "Aircraft #3", TextCompare: true) == 0) ? TargetWaypoint_Lead.Waypoint_SecondElement : ((Operators.CompareString(SelectedAircraft, "Aircraft #4", TextCompare: true) == 0) ? TargetWaypoint_Lead.Waypoint_SecondElementWingman : ((Operators.CompareString(SelectedAircraft, "Aircraft #5", TextCompare: true) == 0) ? TargetWaypoint_Lead.Waypoint_ThirdElement : ((Operators.CompareString(SelectedAircraft, "Aircraft #6", TextCompare: true) == 0) ? TargetWaypoint_Lead.Waypoint_ThirdElementWingman : TargetWaypoint_Lead))))));
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.GetUnitSide() == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit.GetUnitSide()))
			{
				continue;
			}
			if (selectedUnit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
				{
					bool flag = false;
					foreach (Mission.TargeteeringEntry targeteering in waypoint.TargeteeringList)
					{
						if (Operators.CompareString(targeteering.Target_ActualUnitObjectID, value.ObjectID, TextCompare: true) == 0)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Mission.TargeteeringEntry item = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, value.Name, "", value.ObjectID, value.DBID, value.GetLatitude(), value.GetLongitude(), null, null, null);
						waypoint.TargeteeringList.Add(item);
					}
				}
				if (SelectedMission.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(selectedUnit.GetUnitSide()) != Misc.PostureStance.Hostile)
				{
					Client.CurrentSide.SetConsidersThisSideToBe(selectedUnit.GetUnitSide(), Misc.PostureStance.Hostile);
				}
			}
			else if (selectedUnit.IsActiveUnit)
			{
				bool flag2 = false;
				foreach (Mission.TargeteeringEntry targeteering2 in waypoint.TargeteeringList)
				{
					if (Operators.CompareString(targeteering2.Target_ActualUnitObjectID, selectedUnit.ObjectID, TextCompare: true) == 0)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					Mission.TargeteeringEntry item2 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, selectedUnit.Name, "", ((ActiveUnit)selectedUnit).ObjectID, ((ActiveUnit)selectedUnit).DBID, selectedUnit.GetLatitude(), selectedUnit.GetLongitude(), null, null, null);
					waypoint.TargeteeringList.Add(item2);
				}
				if (SelectedMission.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(selectedUnit.GetUnitSide()) != Misc.PostureStance.Hostile)
				{
					Client.CurrentSide.SetConsidersThisSideToBe(selectedUnit.GetUnitSide(), Misc.PostureStance.Hostile);
				}
			}
			else
			{
				Contact contact = (Contact)selectedUnit;
				if (!Information.IsNothing(contact.ActualUnit) && Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
				{
					foreach (ActiveUnit value2 in ((Group)contact.ActualUnit).Units.Values)
					{
						bool flag3 = false;
						foreach (Mission.TargeteeringEntry targeteering3 in waypoint.TargeteeringList)
						{
							if (Operators.CompareString(targeteering3.Target_ContactObjectID, contact.ObjectID, TextCompare: true) == 0 || Operators.CompareString(targeteering3.Target_ActualUnitObjectID, contact.ActualUnit.ObjectID, TextCompare: true) == 0)
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							Mission.TargeteeringEntry item3 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact.Name, contact.ObjectID, value2.ObjectID, value2.DBID, contact.GetLatitude(), contact.GetLongitude(), null, null, null);
							waypoint.TargeteeringList.Add(item3);
						}
					}
				}
				else
				{
					if (Client.CurrentSide.BaseContacts.ContainsKey(contact.ActualUnit.ObjectID))
					{
						continue;
					}
					bool flag4 = false;
					foreach (Mission.TargeteeringEntry targeteering4 in waypoint.TargeteeringList)
					{
						if (Operators.CompareString(targeteering4.Target_ContactObjectID, contact.ObjectID, TextCompare: true) == 0 || Operators.CompareString(targeteering4.Target_ActualUnitObjectID, contact.ActualUnit.ObjectID, TextCompare: true) == 0)
						{
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						Mission.TargeteeringEntry item4 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, contact.Name, contact.ObjectID, contact.ActualUnit.ObjectID, contact.ActualUnit.DBID, contact.GetLatitude(), contact.GetLongitude(), null, null, null);
						waypoint.TargeteeringList.Add(item4);
					}
				}
				if (SelectedMission.IsActive && contact.GetStance(Client.CurrentSide) != Misc.PostureStance.Hostile)
				{
					contact.SetStance(Client.CurrentSide, bool_0: false, Misc.PostureStance.Hostile);
				}
			}
			foreach (TreeGridNode node in TGV_Targeteering.Nodes)
			{
				try
				{
					if (Operators.CompareString((string)node.Tag, SelectedAircraft, TextCompare: true) == 0)
					{
						node.Expand();
					}
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
		}
		ForgotBroadcaster(bool_0: false, bool_1: false);
		SelectedMission.TimeSincePlayerNotification = 0;
		Client.MustRefreshMainForm = true;
	}

	private void ViewIdentifier(object sender, EventArgs e)
	{
		Client.FlightPlanEditorTargetsPreliminaryWindow.Show();
	}

	private void ValidateIdentifier(object sender, EventArgs e)
	{
		Client.FlightPlanEditorTargetsAreaWindow.Show();
	}

	private void LoginIdentifier(object sender, EventArgs e)
	{
		Client.FlightPlanEditorTargetsAreaWindow.Show();
	}

	public void ComboBoxDataSource_WeaponQty(ref DataTable dataTable_0, ActiveUnit activeUnit_0, ref Weapon weapon_0, int int_0, int int_1)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, "使用武器释放授权WRA");
		dataTable_0.Rows.Add(1, "所有武器");
		dataTable_0.Rows.Add(2, "不使用武器");
		dataTable_0.Rows.Add(3, "1轮");
		if (int_1 < 2)
		{
			return;
		}
		dataTable_0.Rows.Add(4, "2轮");
		if (int_1 < 3)
		{
			return;
		}
		dataTable_0.Rows.Add(5, "3轮");
		if (int_1 < 4)
		{
			return;
		}
		dataTable_0.Rows.Add(6, "4轮");
		if (int_1 < 5)
		{
			return;
		}
		dataTable_0.Rows.Add(7, "5轮");
		if (int_1 < 6)
		{
			return;
		}
		dataTable_0.Rows.Add(8, "6轮");
		if (int_1 >= 7)
		{
			dataTable_0.Rows.Add(9, "7轮");
			if (int_1 >= 8)
			{
				dataTable_0.Rows.Add(10, "8轮");
			}
		}
	}

	public static int WeaponQtySelection_To_WeaponQty(object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int result = num switch
			{
				0 => -99, 
				1 => -98, 
				2 => -97, 
				3 => 1, 
				4 => 2, 
				5 => 3, 
				6 => 4, 
				7 => 5, 
				8 => 6, 
				9 => 7, 
				_ => -99, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return 0;
		}
	}

	public static int WeaponQty_To_WeaponQtySelection(int int_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = int_0 switch
			{
				1 => 3, 
				2 => 4, 
				3 => 5, 
				4 => 6, 
				5 => 7, 
				6 => 8, 
				7 => 9, 
				8 => 10, 
				-99 => 0, 
				-98 => 1, 
				-97 => 2, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return 0;
		}
	}

	public void ComboBoxDataSource_LostTarget(ref DataTable dataTable_0, int int_0, bool bool_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && bool_0)
		{
			dataTable_0.Rows.Add(0, "向最后已知位置进行纯方位攻击BOL");
		}
		else
		{
			dataTable_0.Rows.Add(0, "向最后已知位置进行附加火力攻击");
		}
		switch (TargetWaypoint_Lead.TargeteeringMethod)
		{
		case Mission._TargeteeringMethod.Mission:
			if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && bool_0)
			{
				dataTable_0.Rows.Add(1, "如果可能在任务目标列表中寻找新目标，否则向最后已知位置进行纯方位攻击");
			}
			else
			{
				dataTable_0.Rows.Add(1, "如果可能在任务目标列表中寻找新目标，否则向最后已知位置进行附加火力攻击");
			}
			break;
		case Mission._TargeteeringMethod.Flight:
			if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && bool_0)
			{
				dataTable_0.Rows.Add(1, "如果可能在编队目标列表中寻找新目标，否则向最后已知位置进行纯方位攻击");
			}
			else
			{
				dataTable_0.Rows.Add(1, "如果可能在编队目标列表中寻找新目标，否则向最后已知位置进行附加火力攻击");
			}
			break;
		case Mission._TargeteeringMethod.Individual:
			if (((Strike)SelectedMission).Type == Strike.StrikeType.Maritime_Strike && bool_0)
			{
				dataTable_0.Rows.Add(1, "如果可能在飞机目标列表中寻找新目标，否则向最后已知位置进行纯方位攻击");
			}
			else
			{
				dataTable_0.Rows.Add(1, "如果可能在飞机目标列表中寻找新目标，否则向最后已知位置进行附加火力攻击");
			}
			break;
		}
		dataTable_0.Rows.Add(2, "根据任务设置取消火力攻击");
		switch (TargetWaypoint_Lead.TargeteeringMethod)
		{
		case Mission._TargeteeringMethod.Mission:
			dataTable_0.Rows.Add(1, "如果可能在任务目标列表中寻找新目标，否则根据任务设置取消火力攻击");
			break;
		case Mission._TargeteeringMethod.Flight:
			dataTable_0.Rows.Add(1, "如果可能在编队目标列表中寻找新目标，否则根据任务设置取消火力攻击");
			break;
		case Mission._TargeteeringMethod.Individual:
			dataTable_0.Rows.Add(1, "如果可能在飞机目标列表中寻找新目标，否则根据任务设置取消火力攻击");
			break;
		}
	}

	public static WeaponeeringLostTargetSelection LostTargetSelection_To_LostTarget(object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			WeaponeeringLostTargetSelection result = num switch
			{
				0 => WeaponeeringLostTargetSelection.ExpenOrdnancedOnCoordinate, 
				1 => WeaponeeringLostTargetSelection.FindNewTarget_OtherwiseExpendOrdnanceOnCoordinate, 
				2 => WeaponeeringLostTargetSelection.BringBackOrJettisonOrdnance, 
				3 => WeaponeeringLostTargetSelection.FindNewTarget_OtherwiseBringBackOrJettisonOrdnance, 
				_ => WeaponeeringLostTargetSelection.ExpenOrdnancedOnCoordinate, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return WeaponeeringLostTargetSelection.ExpenOrdnancedOnCoordinate;
		}
	}

	public static int LostTarget_To_LostTargetSelection(WeaponeeringLostTargetSelection weaponeeringLostTargetSelection_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = weaponeeringLostTargetSelection_0 switch
			{
				WeaponeeringLostTargetSelection.ExpenOrdnancedOnCoordinate => 0, 
				WeaponeeringLostTargetSelection.FindNewTarget_OtherwiseExpendOrdnanceOnCoordinate => 1, 
				WeaponeeringLostTargetSelection.BringBackOrJettisonOrdnance => 2, 
				WeaponeeringLostTargetSelection.FindNewTarget_OtherwiseBringBackOrJettisonOrdnance => 3, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return 0;
		}
	}

	public void ComboBoxDataSource_Target(ref DataTable dataTable_0, int int_0, ref List<Mission.TargeteeringEntry> list_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, "无选定目标（将不使用武器）");
		if (!Information.IsNothing(list_0) && list_0.Count != 0)
		{
			int num = list_0.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Mission.TargeteeringEntry targeteeringEntry = list_0[i];
				dataTable_0.Rows.Add(i + 1, targeteeringEntry.Target_Description);
			}
		}
	}

	public static Mission.TargeteeringEntry TargetSelection_To_Target(object object_0, ref List<Mission.TargeteeringEntry> list_0)
	{
		try
		{
			int num = (int)object_0;
			if (num == 0)
			{
				return null;
			}
			if (list_0.Count < num)
			{
				return null;
			}
			return list_0[num - 1];
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
			return null;
		}
	}

	public static int Target_To_TargetSelection(string string_0, ref List<Mission.TargeteeringEntry> list_0)
	{
		try
		{
			if (!Information.IsNothing(list_0) && list_0.Count != 0)
			{
				int num = list_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.CompareString(list_0[i].ObjectID, string_0, TextCompare: true) == 0)
					{
						return i + 1;
					}
				}
				return 0;
			}
			return 0;
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
			return 0;
		}
	}

	public void ComboBoxDataSource_FiringRange(ref DataTable dataTable_0, float float_0, float float_1, int int_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, "最大范围");
		if (float_0 > 2f && float_1 < 2f)
		{
			dataTable_0.Rows.Add(1, "2海里");
		}
		if (float_0 > 5f && float_1 < 5f)
		{
			dataTable_0.Rows.Add(2, "5海里");
		}
		if (float_0 > 10f && float_1 < 10f)
		{
			dataTable_0.Rows.Add(3, "10海里");
		}
		if (float_0 > 15f && float_1 < 15f)
		{
			dataTable_0.Rows.Add(4, "15海里");
		}
		if (float_0 > 20f && float_1 < 20f)
		{
			dataTable_0.Rows.Add(5, "20海里");
		}
		if (float_0 > 25f && float_1 < 25f)
		{
			dataTable_0.Rows.Add(6, "25海里");
		}
		if (float_0 > 30f && float_1 < 30f)
		{
			dataTable_0.Rows.Add(7, "30海里");
		}
		if (float_0 > 35f && float_1 < 35f)
		{
			dataTable_0.Rows.Add(8, "35海里");
		}
		if (float_0 > 40f && float_1 < 40f)
		{
			dataTable_0.Rows.Add(9, "40海里");
		}
		if (float_0 > 45f && float_1 < 45f)
		{
			dataTable_0.Rows.Add(10, "45海里");
		}
		if (float_0 > 50f && float_1 < 50f)
		{
			dataTable_0.Rows.Add(11, "50海里");
		}
		if (float_0 > 60f && float_1 < 60f)
		{
			dataTable_0.Rows.Add(12, "60海里");
		}
		if (float_0 > 70f && float_1 < 70f)
		{
			dataTable_0.Rows.Add(13, "70海里");
		}
		if (float_0 > 80f && float_1 < 80f)
		{
			dataTable_0.Rows.Add(14, "80海里");
		}
		if (float_0 > 90f && float_1 < 90f)
		{
			dataTable_0.Rows.Add(15, "90海里");
		}
		if (float_0 > 100f && float_1 < 100f)
		{
			dataTable_0.Rows.Add(16, "100海里");
		}
		if (float_0 > 125f && float_1 < 125f)
		{
			dataTable_0.Rows.Add(17, "125海里");
		}
		if (float_0 > 150f && float_1 < 150f)
		{
			dataTable_0.Rows.Add(18, "150海里");
		}
		if (float_0 > 175f && float_1 < 175f)
		{
			dataTable_0.Rows.Add(19, "175海里");
		}
		if (float_0 > 200f && float_1 < 200f)
		{
			dataTable_0.Rows.Add(20, "200海里");
		}
		if (float_0 > 250f && float_1 < 250f)
		{
			dataTable_0.Rows.Add(21, "250海里");
		}
		if (float_0 > 300f && float_1 < 300f)
		{
			dataTable_0.Rows.Add(22, "300海里");
		}
		if (float_0 > 500f && float_1 < 500f)
		{
			dataTable_0.Rows.Add(23, "500海里");
		}
		if (float_0 > 750f && float_1 < 750f)
		{
			dataTable_0.Rows.Add(24, "750海里");
		}
		if (float_0 > 1000f && float_1 < 1000f)
		{
			dataTable_0.Rows.Add(25, "1000海里");
		}
		if (float_0 > 1500f && float_1 < 1500f)
		{
			dataTable_0.Rows.Add(26, "1500海里");
		}
		if (float_0 > 2000f && float_1 < 2000f)
		{
			dataTable_0.Rows.Add(27, "2000海里");
		}
	}

	public static int FiringRangeSelection_To_FiringRange(object object_0)
	{
		try
		{
			int num = Conversions.ToInteger(object_0);
			if (1 == 0)
			{
			}
			int result = num switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				5 => 5, 
				6 => 6, 
				7 => 7, 
				8 => 8, 
				9 => 9, 
				10 => 10, 
				11 => 11, 
				12 => 12, 
				13 => 13, 
				14 => 14, 
				15 => 15, 
				16 => 16, 
				17 => 17, 
				18 => 18, 
				19 => 19, 
				20 => 20, 
				21 => 21, 
				22 => 22, 
				23 => 23, 
				24 => 24, 
				25 => 25, 
				26 => 26, 
				27 => 27, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return 0;
		}
	}

	public static int FiringRange_To_FiringRangeSelection(int int_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = int_0 switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				5 => 5, 
				6 => 6, 
				7 => 7, 
				8 => 8, 
				9 => 9, 
				10 => 10, 
				11 => 11, 
				12 => 12, 
				13 => 13, 
				14 => 14, 
				15 => 15, 
				16 => 16, 
				17 => 17, 
				18 => 18, 
				19 => 19, 
				20 => 20, 
				21 => 21, 
				22 => 22, 
				23 => 23, 
				24 => 24, 
				25 => 25, 
				26 => 26, 
				27 => 27, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return 0;
		}
	}

	[SpecialName]
	public static string GetTargeteeringMethodtring(Mission._TargeteeringMethod _TargeteeringMethod_0, Mission.MissionCategory missionCategory_0)
	{
		switch (_TargeteeringMethod_0)
		{
		default:
			return "None";
		case Mission._TargeteeringMethod.Mission:
			if (missionCategory_0 == Mission.MissionCategory.Package)
			{
				return "使用任务包目标";
			}
			return "使用任务目标";
		case Mission._TargeteeringMethod.Flight:
			return "使用编队目标";
		case Mission._TargeteeringMethod.Individual:
			return "使用单个飞机目标";
		}
	}

	public static void ComboBoxDataSource_TargeteeringMethod(ref DataTable dataTable_0, Mission.MissionCategory missionCategory_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, GetTargeteeringMethodtring(Mission._TargeteeringMethod.Mission, missionCategory_0));
		dataTable_0.Rows.Add(1, GetTargeteeringMethodtring(Mission._TargeteeringMethod.Flight, missionCategory_0));
		dataTable_0.Rows.Add(2, GetTargeteeringMethodtring(Mission._TargeteeringMethod.Individual, missionCategory_0));
	}

	public static Mission._TargeteeringMethod TargeteeringMethodSelection_To_TargeteeringMethod(int int_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			Mission._TargeteeringMethod result = int_0 switch
			{
				0 => Mission._TargeteeringMethod.Mission, 
				1 => Mission._TargeteeringMethod.Flight, 
				2 => Mission._TargeteeringMethod.Individual, 
				_ => Mission._TargeteeringMethod.Mission, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return Mission._TargeteeringMethod.Mission;
		}
	}

	public static int TargeteeringMethod_To_TargeteeringMethodSelection(int int_0)
	{
		try
		{
			if (1 == 0)
			{
			}
			int result = int_0 switch
			{
				0 => 0, 
				1 => 1, 
				2 => 2, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			return result;
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
			return 0;
		}
	}

	private void GetIdentifier(object sender, KeyEventArgs e)
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

	private void WriteIdentifier()
	{
		try
		{
			if (!Information.IsNothing(SelectedFlight) && !Information.IsNothing(SelectedMission) && !Information.IsNothing(IPWaypoint_Lead) && !Information.IsNothing(TargetWaypoint_Lead))
			{
				switch (TargetWaypoint_Lead.TargeteeringMethod)
				{
				case Mission._TargeteeringMethod.Mission:
					ComboBox_TargteeringMethod.Enabled = true;
					Button_AddHighlighted.Enabled = false;
					Button_RemoveSelected.Enabled = false;
					Button_AddPreliminaryTargetLocation.Enabled = false;
					Button_EditPreliminaryTargetLocation.Enabled = false;
					Button_AddCoordinate.Enabled = false;
					Button_EditCoordinate.Enabled = false;
					Button_AddArea.Enabled = false;
					Button_EditArea.Enabled = false;
					Button_EditToT.Enabled = false;
					Button_IncreasePriority.Enabled = false;
					Button_DecreasePriority.Enabled = false;
					CB_PreplannedOnly.Enabled = false;
					Button_EditWRA.Enabled = false;
					Button_EditRoute.Enabled = false;
					Button_SetTimeReferenceWeapon.Enabled = false;
					break;
				case Mission._TargeteeringMethod.Flight:
					ComboBox_TargteeringMethod.Enabled = true;
					Button_AddHighlighted.Enabled = true;
					Button_RemoveSelected.Enabled = true;
					Button_AddPreliminaryTargetLocation.Enabled = false;
					Button_EditPreliminaryTargetLocation.Enabled = false;
					Button_AddCoordinate.Enabled = false;
					Button_EditCoordinate.Enabled = false;
					Button_AddArea.Enabled = false;
					Button_EditArea.Enabled = false;
					Button_EditToT.Enabled = false;
					Button_IncreasePriority.Enabled = false;
					Button_DecreasePriority.Enabled = false;
					CB_PreplannedOnly.Enabled = false;
					Button_EditWRA.Enabled = false;
					Button_EditRoute.Enabled = false;
					Button_SetTimeReferenceWeapon.Enabled = false;
					break;
				case Mission._TargeteeringMethod.Individual:
				{
					ComboBox_TargteeringMethod.Enabled = true;
					Button_AddHighlighted.Enabled = true;
					Button_RemoveSelected.Enabled = true;
					Button_AddPreliminaryTargetLocation.Enabled = true;
					Button_EditPreliminaryTargetLocation.Enabled = true;
					Button_AddCoordinate.Enabled = true;
					Button_EditCoordinate.Enabled = true;
					Button_AddArea.Enabled = true;
					Button_EditArea.Enabled = true;
					Button_EditToT.Enabled = true;
					Button_IncreasePriority.Enabled = true;
					Button_DecreasePriority.Enabled = true;
					CB_PreplannedOnly.Enabled = true;
					Button_EditWRA.Enabled = true;
					if (TGV_Weaponeering.SelectedRows.Count <= 0)
					{
						break;
					}
					string left = "";
					TreeGridNode treeGridNode = null;
					bool flag = false;
					foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
					{
						foreach (TreeGridNode node2 in node.Nodes)
						{
							if (node2.Selected)
							{
								left = (string)node.Tag;
								treeGridNode = node2;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (!Information.IsNothing(treeGridNode) && !Information.IsNothing(treeGridNode.Parent))
					{
						Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)treeGridNode.Tag;
						if (Information.IsNothing(weaponeeringEntry))
						{
							Button_EditRoute.Enabled = false;
							Button_SetTimeReferenceWeapon.Enabled = false;
							break;
						}
						if (Information.IsNothing(weaponeeringEntry.Route))
						{
							Button_EditRoute.Enabled = false;
						}
						else
						{
							Button_EditRoute.Enabled = true;
						}
						if (TargetWaypoint_Lead.FlightFormation == Waypoint.Formation.Split)
						{
							Button_SetTimeReferenceWeapon.Enabled = true;
						}
						else if (((Operators.CompareString(left, "飞机＃1", TextCompare: true) == 0) ? 1 : ((Operators.CompareString(left, "Aircraft #2", TextCompare: true) == 0) ? 2 : ((Operators.CompareString(left, "Aircraft #3", TextCompare: true) == 0) ? 3 : ((Operators.CompareString(left, "Aircraft #4", TextCompare: true) == 0) ? 4 : ((Operators.CompareString(left, "Aircraft #5", TextCompare: true) == 0) ? 5 : ((Operators.CompareString(left, "Aircraft #6", TextCompare: true) != 0) ? 1 : 6)))))) == 1)
						{
							Button_SetTimeReferenceWeapon.Enabled = true;
						}
						else
						{
							Button_SetTimeReferenceWeapon.Enabled = false;
						}
					}
					else
					{
						Button_EditRoute.Enabled = false;
						Button_SetTimeReferenceWeapon.Enabled = false;
					}
					break;
				}
				}
			}
			else
			{
				ComboBox_TargteeringMethod.Enabled = false;
				Button_AddHighlighted.Enabled = false;
				Button_RemoveSelected.Enabled = false;
				Button_AddPreliminaryTargetLocation.Enabled = false;
				Button_EditPreliminaryTargetLocation.Enabled = false;
				Button_AddCoordinate.Enabled = false;
				Button_EditCoordinate.Enabled = false;
				Button_AddArea.Enabled = false;
				Button_EditArea.Enabled = false;
				Button_EditToT.Enabled = false;
				Button_IncreasePriority.Enabled = false;
				Button_DecreasePriority.Enabled = false;
				CB_PreplannedOnly.Enabled = false;
				Button_EditWRA.Enabled = false;
				Button_EditRoute.Enabled = false;
				Button_SetTimeReferenceWeapon.Enabled = false;
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

	private void NewIdentifier(object sender, EventArgs e)
	{
		TreeGridNode treeGridNode = null;
		foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
		{
			if (node.Selected)
			{
				return;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					treeGridNode = node2;
				}
			}
		}
		if (Information.IsNothing(treeGridNode))
		{
			return;
		}
		Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)treeGridNode.Tag;
		if (!Information.IsNothing(weaponeeringEntry))
		{
			if (Information.IsNothing(weaponeeringEntry.Route))
			{
				Interaction.MsgBox("武器路径不存在");
			}
			Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute = weaponeeringEntry.Route;
			FlightPlanEditorWeaponRoute flightPlanEditorWeaponRouteWindow = Client.FlightPlanEditorWeaponRouteWindow;
			Scenario scenario_ = Client.CurrentScenario;
			flightPlanEditorWeaponRouteWindow.SelectedWeapon = Weapon.GetNewWeapon(ref scenario_, weaponeeringEntry.int_0, bool_0: false);
			if (Client.FlightPlanEditorWeaponRouteWindow.Visible)
			{
				Client.FlightPlanEditorWeaponRouteWindow.ReloadWindow();
				Client.FlightPlanEditorWeaponRouteWindow.BringToFront();
			}
			else
			{
				Client.FlightPlanEditorWeaponRouteWindow.Show();
			}
		}
	}

	private void PushIdentifier(object sender, EventArgs e)
	{
		if (TGV_Weaponeering.SelectedRows.Count <= 0)
		{
			return;
		}
		string left = "";
		TreeGridNode treeGridNode = null;
		bool flag = false;
		foreach (TreeGridNode node in TGV_Weaponeering.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					left = (string)node.Tag;
					treeGridNode = node2;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (Information.IsNothing(treeGridNode) || Information.IsNothing(treeGridNode.Parent))
		{
			return;
		}
		Mission.WeaponeeringEntry weaponeeringEntry = (Mission.WeaponeeringEntry)treeGridNode.Tag;
		if (Information.IsNothing(weaponeeringEntry))
		{
			return;
		}
		if (Operators.CompareString(left, "飞机＃1", TextCompare: true) == 0 && !Information.IsNothing(TargetWaypoint_Lead.WeaponeeringList))
		{
			foreach (Mission.WeaponeeringEntry weaponeering in TargetWaypoint_Lead.WeaponeeringList)
			{
				if (weaponeering == weaponeeringEntry)
				{
					weaponeering.IsRouteReference = true;
				}
				else
				{
					weaponeering.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(left, "Aircraft #2", TextCompare: true) == 0 && !Information.IsNothing(TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman))
		{
			foreach (Mission.WeaponeeringEntry item in TargetWaypoint_Lead.WeaponeeringList_LeadElementWingman)
			{
				if (item == weaponeeringEntry)
				{
					item.IsRouteReference = true;
				}
				else
				{
					item.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(left, "Aircraft #3", TextCompare: true) == 0 && !Information.IsNothing(TargetWaypoint_Lead.WeaponeeringList_SecondElement))
		{
			foreach (Mission.WeaponeeringEntry item2 in TargetWaypoint_Lead.WeaponeeringList_SecondElement)
			{
				if (item2 == weaponeeringEntry)
				{
					item2.IsRouteReference = true;
				}
				else
				{
					item2.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(left, "Aircraft #4", TextCompare: true) == 0 && !Information.IsNothing(TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman))
		{
			foreach (Mission.WeaponeeringEntry item3 in TargetWaypoint_Lead.WeaponeeringList_SecondElementWingman)
			{
				if (item3 == weaponeeringEntry)
				{
					item3.IsRouteReference = true;
				}
				else
				{
					item3.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(left, "Aircraft #5", TextCompare: true) == 0 && !Information.IsNothing(TargetWaypoint_Lead.WeaponeeringList_ThirdElement))
		{
			foreach (Mission.WeaponeeringEntry item4 in TargetWaypoint_Lead.WeaponeeringList_ThirdElement)
			{
				if (item4 == weaponeeringEntry)
				{
					item4.IsRouteReference = true;
				}
				else
				{
					item4.IsRouteReference = false;
				}
			}
		}
		else if (Operators.CompareString(left, "Aircraft #6", TextCompare: true) == 0 && !Information.IsNothing(TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman))
		{
			foreach (Mission.WeaponeeringEntry item5 in TargetWaypoint_Lead.WeaponeeringList_ThirdElementWingman)
			{
				if (item5 == weaponeeringEntry)
				{
					item5.IsRouteReference = true;
				}
				else
				{
					item5.IsRouteReference = false;
				}
			}
		}
		else
		{
			foreach (Mission.WeaponeeringEntry weaponeering2 in TargetWaypoint_Lead.WeaponeeringList)
			{
				weaponeering2.IsRouteReference = false;
			}
		}
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
		ForgotBroadcaster(bool_0: false, bool_1: false);
	}
}
