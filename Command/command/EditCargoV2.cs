using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Managers;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditCargoV2 : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class ProxyParameterMessage
	{
		public EditCargoV2 _003C_003E4__this;

		public Scenario theScen;

		public string theUnitObjectID;

		internal void UpdateInterruptiblePage()
		{
			_003C_003E4__this.HandleUnitAdded(theScen, theUnitObjectID);
		}
	}

	[CompilerGenerated]
	private sealed class CollectionConfigManager
	{
		public EditCargoV2 _003C_003E4__this;

		public Scenario theScen;

		public ActiveUnit theUnit;

		internal void InsertInterruptiblePage()
		{
			_003C_003E4__this.HandleUnitRemoved(theScen, theUnit);
		}
	}

	private IContainer policyWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("UnloadButton")]
	private DarkUIButton m_BroadcasterWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("UnloadCounter")]
	private DarkNumericUpDown identifierWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("CargoSourceTabControl")]
	private DarkUITabControl m_PrinterWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("UnitsTab")]
	private TabPage m_ParserWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("DBGrid")]
	private DarkDataGridView _DatabaseWatcher;

	[AccessedThroughProperty("LoadCounter")]
	[CompilerGenerated]
	private DarkNumericUpDown m_InterceptorWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadButton")]
	private DarkUIButton _MessageWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel productWatcher;

	[AccessedThroughProperty("Panel_LoadedCargo")]
	[CompilerGenerated]
	private DarkSectionPanel m_AnnotationWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("Panel_AvailableCargo")]
	private DarkSectionPanel m_IteratorWatcher;

	[AccessedThroughProperty("InventoryGridView")]
	[CompilerGenerated]
	private DarkDataGridView m_InitializerWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("ExistingUnitsGridView")]
	private DarkDataGridView m_RoleWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("ExistingUnitTypeCol")]
	private DataGridViewTextBoxColumn m_AttributeWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	private DataGridViewTextBoxColumn eventWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("ExistingUnitSizeCol")]
	private DataGridViewTextBoxColumn m_GlobalWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	private DataGridViewTextBoxColumn m_AccountWatcher;

	[AccessedThroughProperty("NoUnitsWarningLabel")]
	[CompilerGenerated]
	private DarkLabel authenticationWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("CustomNameLabel")]
	private DarkLabel m_InfoWatcher;

	[AccessedThroughProperty("CrewBar")]
	[CompilerGenerated]
	private DarkUIProgressBar m_MapperWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("AreaBar")]
	private DarkUIProgressBar m_ManagerWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("DeleteButton")]
	private DarkUIButton getterWatcher;

	[AccessedThroughProperty("CB_Filter")]
	[CompilerGenerated]
	private DarkCheckBox m_ProducerWatcher;

	[AccessedThroughProperty("TB_Filter")]
	[CompilerGenerated]
	private DarkUITextBox _ProcWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("EditContainerButton")]
	private DarkUIButton _StructReponse;

	[AccessedThroughProperty("InvColMass")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn callbackReponse;

	[AccessedThroughProperty("InvColArea")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_DecoratorReponse;

	public ActiveUnit SelectedHost;

	private ICargoHost threadReponse;

	private CargoType ruleReponse;

	private float m_CollectionReponse;

	private float m_InstanceReponse;

	private float m_ObjectReponse;

	private string m_ParameterReponse;

	public static bool AllowCargoContainers;

	private bool _ExpressionReponse;

	private Keys[] dispatcherReponse;

	internal DarkUIButton UnloadButton
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapMapping;
			DarkUIButton broadcasterWatcher = m_BroadcasterWatcher;
			if (broadcasterWatcher != null)
			{
				broadcasterWatcher.Click -= value2;
			}
			m_BroadcasterWatcher = value;
			broadcasterWatcher = m_BroadcasterWatcher;
			if (broadcasterWatcher != null)
			{
				broadcasterWatcher.Click += value2;
			}
		}
	}

	internal DarkNumericUpDown UnloadCounter
	{
		[CompilerGenerated]
		get
		{
			return identifierWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			identifierWatcher = value;
		}
	}

	internal DarkUITabControl CargoSourceTabControl
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryMapping;
			DarkUITabControl printerWatcher = m_PrinterWatcher;
			if (printerWatcher != null)
			{
				printerWatcher.SelectedIndexChanged -= value2;
			}
			m_PrinterWatcher = value;
			printerWatcher = m_PrinterWatcher;
			if (printerWatcher != null)
			{
				printerWatcher.SelectedIndexChanged += value2;
			}
		}
	}

	internal TabPage UnitsTab
	{
		[CompilerGenerated]
		get
		{
			return m_ParserWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParserWatcher = value;
		}
	}

	[field: AccessedThroughProperty("DatabaseTab")]
	internal TabPage DatabaseTab
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkDataGridView DBGrid
	{
		[CompilerGenerated]
		get
		{
			return _DatabaseWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeMapping;
			DarkDataGridView databaseWatcher = _DatabaseWatcher;
			if (databaseWatcher != null)
			{
				databaseWatcher.SelectionChanged -= value2;
			}
			_DatabaseWatcher = value;
			databaseWatcher = _DatabaseWatcher;
			if (databaseWatcher != null)
			{
				databaseWatcher.SelectionChanged += value2;
			}
		}
	}

	internal DarkNumericUpDown LoadCounter
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorWatcher = value;
		}
	}

	internal DarkUIButton LoadButton
	{
		[CompilerGenerated]
		get
		{
			return _MessageWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetMapping;
			DarkUIButton messageWatcher = _MessageWatcher;
			if (messageWatcher != null)
			{
				messageWatcher.Click -= value2;
			}
			_MessageWatcher = value;
			messageWatcher = _MessageWatcher;
			if (messageWatcher != null)
			{
				messageWatcher.Click += value2;
			}
		}
	}

	internal TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return productWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productWatcher = value;
		}
	}

	internal DarkSectionPanel Panel_LoadedCargo
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationWatcher = value;
		}
	}

	internal DarkSectionPanel Panel_AvailableCargo
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IteratorWatcher = value;
		}
	}

	internal DarkDataGridView InventoryGridView
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineMapping;
			EventHandler value3 = CollectMapping;
			DarkDataGridView initializerWatcher = m_InitializerWatcher;
			if (initializerWatcher != null)
			{
				initializerWatcher.SelectionChanged -= value2;
				initializerWatcher.MouseHover -= value3;
			}
			m_InitializerWatcher = value;
			initializerWatcher = m_InitializerWatcher;
			if (initializerWatcher != null)
			{
				initializerWatcher.SelectionChanged += value2;
				initializerWatcher.MouseHover += value3;
			}
		}
	}

	internal DarkDataGridView ExistingUnitsGridView
	{
		[CompilerGenerated]
		get
		{
			return m_RoleWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishMapping;
			DarkDataGridView roleWatcher = m_RoleWatcher;
			if (roleWatcher != null)
			{
				roleWatcher.SelectionChanged -= value2;
			}
			m_RoleWatcher = value;
			roleWatcher = m_RoleWatcher;
			if (roleWatcher != null)
			{
				roleWatcher.SelectionChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("SizeLabel")]
	internal DarkLabel SizeLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn ExistingUnitTypeCol
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeWatcher = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[CompilerGenerated]
		get
		{
			return eventWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eventWatcher = value;
		}
	}

	internal DataGridViewTextBoxColumn ExistingUnitSizeCol
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalWatcher = value;
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn3
	{
		[CompilerGenerated]
		get
		{
			return m_AccountWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AccountWatcher = value;
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel NoUnitsWarningLabel
	{
		[CompilerGenerated]
		get
		{
			return authenticationWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			authenticationWatcher = value;
		}
	}

	[field: AccessedThroughProperty("CustomNameTextBox")]
	internal DarkUITextBox CustomNameTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel CustomNameLabel
	{
		[CompilerGenerated]
		get
		{
			return m_InfoWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InfoWatcher = value;
		}
	}

	[field: AccessedThroughProperty("MassBar")]
	internal DarkUIProgressBar MassBar
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIProgressBar CrewBar
	{
		[CompilerGenerated]
		get
		{
			return m_MapperWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MapperWatcher = value;
		}
	}

	internal DarkUIProgressBar AreaBar
	{
		[CompilerGenerated]
		get
		{
			return m_ManagerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ManagerWatcher = value;
		}
	}

	internal DarkUIButton DeleteButton
	{
		[CompilerGenerated]
		get
		{
			return getterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcMapping;
			DarkUIButton darkUIButton = getterWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			getterWatcher = value;
			darkUIButton = getterWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Filter
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateMapping;
			DarkCheckBox producerWatcher = m_ProducerWatcher;
			if (producerWatcher != null)
			{
				producerWatcher.CheckedChanged -= value2;
			}
			m_ProducerWatcher = value;
			producerWatcher = m_ProducerWatcher;
			if (producerWatcher != null)
			{
				producerWatcher.CheckedChanged += value2;
			}
		}
	}

	internal DarkUITextBox TB_Filter
	{
		[CompilerGenerated]
		get
		{
			return _ProcWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = FlushMapping;
			DarkUITextBox procWatcher = _ProcWatcher;
			if (procWatcher != null)
			{
				procWatcher.TextChanged -= value2;
			}
			_ProcWatcher = value;
			procWatcher = _ProcWatcher;
			if (procWatcher != null)
			{
				procWatcher.TextChanged += value2;
			}
		}
	}

	internal DarkUIButton EditContainerButton
	{
		[CompilerGenerated]
		get
		{
			return _StructReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotMapping;
			DarkUIButton structReponse = _StructReponse;
			if (structReponse != null)
			{
				structReponse.Click -= value2;
			}
			_StructReponse = value;
			structReponse = _StructReponse;
			if (structReponse != null)
			{
				structReponse.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("InvColName")]
	internal DataGridViewTextBoxColumn InvColName
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn InvColMass
	{
		[CompilerGenerated]
		get
		{
			return callbackReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackReponse = value;
		}
	}

	internal DataGridViewTextBoxColumn InvColArea
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DecoratorReponse = value;
		}
	}

	[field: AccessedThroughProperty("InvColCrew")]
	internal DataGridViewTextBoxColumn InvColCrew
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	static EditCargoV2()
	{
		AllowCargoContainers = true;
	}

	public EditCargoV2()
	{
		base.Load += ListMapping;
		base.Shown += ResolveMapping;
		m_ParameterReponse = "";
		_ExpressionReponse = false;
		dispatcherReponse = new Keys[1] { Keys.Escape };
		VerifyMapping();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && policyWatcher != null)
			{
				policyWatcher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void VerifyMapping()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		UnloadButton = new DarkUIButton();
		UnloadCounter = new DarkNumericUpDown();
		CargoSourceTabControl = new DarkUITabControl();
		UnitsTab = new TabPage();
		NoUnitsWarningLabel = new DarkLabel();
		ExistingUnitsGridView = new DarkDataGridView();
		ExistingUnitTypeCol = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		ExistingUnitSizeCol = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		DatabaseTab = new TabPage();
		DBGrid = new DarkDataGridView();
		LoadCounter = new DarkNumericUpDown();
		LoadButton = new DarkUIButton();
		TableLayoutPanel1 = new TableLayoutPanel();
		Panel_LoadedCargo = new DarkSectionPanel();
		DeleteButton = new DarkUIButton();
		EditContainerButton = new DarkUIButton();
		CrewBar = new DarkUIProgressBar();
		AreaBar = new DarkUIProgressBar();
		MassBar = new DarkUIProgressBar();
		SizeLabel = new DarkLabel();
		InventoryGridView = new DarkDataGridView();
		InvColName = new DataGridViewTextBoxColumn();
		InvColMass = new DataGridViewTextBoxColumn();
		InvColArea = new DataGridViewTextBoxColumn();
		InvColCrew = new DataGridViewTextBoxColumn();
		Panel_AvailableCargo = new DarkSectionPanel();
		CB_Filter = new DarkCheckBox();
		TB_Filter = new DarkUITextBox();
		CustomNameLabel = new DarkLabel();
		CustomNameTextBox = new DarkUITextBox();
		((ISupportInitialize)UnloadCounter).BeginInit();
		CargoSourceTabControl.SuspendLayout();
		UnitsTab.SuspendLayout();
		((ISupportInitialize)ExistingUnitsGridView).BeginInit();
		DatabaseTab.SuspendLayout();
		((ISupportInitialize)DBGrid).BeginInit();
		((ISupportInitialize)LoadCounter).BeginInit();
		TableLayoutPanel1.SuspendLayout();
		Panel_LoadedCargo.SuspendLayout();
		((ISupportInitialize)InventoryGridView).BeginInit();
		Panel_AvailableCargo.SuspendLayout();
		SuspendLayout();
		UnloadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		UnloadButton.BackColor = Color.Transparent;
		UnloadButton.DialogResult = DialogResult.None;
		UnloadButton.ForeColor = SystemColors.Control;
		UnloadButton.Location = new Point(71, 548);
		UnloadButton.Name = "UnloadButton";
		UnloadButton.Padding = new Padding(5);
		UnloadButton.RoundRadius = 0;
		UnloadButton.Size = new Size(108, 23);
		UnloadButton.TabIndex = 2;
		UnloadButton.Text = "Unload Selected";
		UnloadCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		UnloadCounter.BackColor = Color.FromArgb(43, 43, 43);
		UnloadCounter.BorderStyle = BorderStyle.None;
		UnloadCounter.Font = new Font("Segoe UI", 12f);
		UnloadCounter.ForeColor = Color.FromArgb(220, 220, 220);
		UnloadCounter.Location = new Point(9, 546);
		UnloadCounter.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		UnloadCounter.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		UnloadCounter.Name = "UnloadCounter";
		UnloadCounter.Size = new Size(54, 25);
		UnloadCounter.TabIndex = 3;
		UnloadCounter.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		CargoSourceTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		CargoSourceTabControl.Controls.Add(UnitsTab);
		CargoSourceTabControl.Controls.Add(DatabaseTab);
		CargoSourceTabControl.Cursor = Cursors.Hand;
		CargoSourceTabControl.ItemSize = new Size(80, 20);
		CargoSourceTabControl.Location = new Point(4, 28);
		CargoSourceTabControl.Name = "CargoSourceTabControl";
		CargoSourceTabControl.SelectedIndex = 0;
		CargoSourceTabControl.Size = new Size(724, 511);
		CargoSourceTabControl.TabIndex = 4;
		UnitsTab.BackColor = Color.FromArgb(60, 63, 65);
		UnitsTab.Controls.Add(NoUnitsWarningLabel);
		UnitsTab.Controls.Add(ExistingUnitsGridView);
		UnitsTab.Location = new Point(4, 24);
		UnitsTab.Name = "UnitsTab";
		UnitsTab.Padding = new Padding(3);
		UnitsTab.Size = new Size(716, 483);
		UnitsTab.TabIndex = 0;
		UnitsTab.Text = "单元";
		NoUnitsWarningLabel.ForeColor = Color.FromArgb(220, 220, 220);
		NoUnitsWarningLabel.Location = new Point(3, 22);
		NoUnitsWarningLabel.Name = "NoUnitsWarningLabel";
		NoUnitsWarningLabel.Size = new Size(700, 460);
		NoUnitsWarningLabel.TabIndex = 14;
		NoUnitsWarningLabel.Text = "(You must create units capable of being loaded as cargo for this host.)";
		NoUnitsWarningLabel.TextAlign = ContentAlignment.MiddleCenter;
		NoUnitsWarningLabel.Visible = false;
		ExistingUnitsGridView.AllowUserToAddRows = false;
		ExistingUnitsGridView.AllowUserToDeleteRows = false;
		ExistingUnitsGridView.AllowUserToOrderColumns = true;
		ExistingUnitsGridView.AllowUserToResizeRows = false;
		ExistingUnitsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ExistingUnitsGridView.BackgroundColor = Color.FromArgb(60, 63, 65);
		ExistingUnitsGridView.BorderStyle = BorderStyle.None;
		ExistingUnitsGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		ExistingUnitsGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		ExistingUnitsGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		ExistingUnitsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		ExistingUnitsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		ExistingUnitsGridView.Columns.AddRange(ExistingUnitTypeCol, DataGridViewTextBoxColumn1, ExistingUnitSizeCol, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		ExistingUnitsGridView.DefaultCellStyle = dataGridViewCellStyle2;
		ExistingUnitsGridView.EnableHeadersVisualStyles = false;
		ExistingUnitsGridView.Location = new Point(0, 0);
		ExistingUnitsGridView.Name = "ExistingUnitsGridView";
		ExistingUnitsGridView.ReadOnly = true;
		ExistingUnitsGridView.RowHeadersVisible = false;
		ExistingUnitsGridView.RowHeadersWidth = 51;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		ExistingUnitsGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
		ExistingUnitsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		ExistingUnitsGridView.Size = new Size(713, 480);
		ExistingUnitsGridView.TabIndex = 13;
		ExistingUnitTypeCol.HeaderText = "类型";
		ExistingUnitTypeCol.MinimumWidth = 6;
		ExistingUnitTypeCol.Name = "ExistingUnitTypeCol";
		ExistingUnitTypeCol.ReadOnly = true;
		ExistingUnitTypeCol.Width = 90;
		DataGridViewTextBoxColumn1.HeaderText = "名称";
		DataGridViewTextBoxColumn1.MinimumWidth = 6;
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.ReadOnly = true;
		DataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
		DataGridViewTextBoxColumn1.Width = 390;
		ExistingUnitSizeCol.HeaderText = "尺寸";
		ExistingUnitSizeCol.MinimumWidth = 6;
		ExistingUnitSizeCol.Name = "ExistingUnitSizeCol";
		ExistingUnitSizeCol.ReadOnly = true;
		ExistingUnitSizeCol.Width = 78;
		DataGridViewTextBoxColumn2.HeaderText = "Mass";
		DataGridViewTextBoxColumn2.MinimumWidth = 6;
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		DataGridViewTextBoxColumn2.ReadOnly = true;
		DataGridViewTextBoxColumn2.Width = 48;
		DataGridViewTextBoxColumn3.HeaderText = "区域";
		DataGridViewTextBoxColumn3.MinimumWidth = 6;
		DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
		DataGridViewTextBoxColumn3.ReadOnly = true;
		DataGridViewTextBoxColumn3.Width = 48;
		DataGridViewTextBoxColumn4.HeaderText = "PAX";
		DataGridViewTextBoxColumn4.MinimumWidth = 6;
		DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
		DataGridViewTextBoxColumn4.ReadOnly = true;
		DataGridViewTextBoxColumn4.Width = 46;
		DatabaseTab.BackColor = Color.FromArgb(60, 63, 65);
		DatabaseTab.Controls.Add(DBGrid);
		DatabaseTab.Location = new Point(4, 24);
		DatabaseTab.Name = "DatabaseTab";
		DatabaseTab.Padding = new Padding(3);
		DatabaseTab.Size = new Size(716, 483);
		DatabaseTab.TabIndex = 1;
		DatabaseTab.Text = "数据库";
		DBGrid.AllowUserToAddRows = false;
		DBGrid.AllowUserToDeleteRows = false;
		DBGrid.AllowUserToOrderColumns = true;
		DBGrid.AllowUserToResizeRows = false;
		DBGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DBGrid.BackgroundColor = Color.FromArgb(60, 63, 65);
		DBGrid.BorderStyle = BorderStyle.None;
		DBGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DBGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		DBGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		DBGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		DBGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		DBGrid.DefaultCellStyle = dataGridViewCellStyle5;
		DBGrid.EnableHeadersVisualStyles = false;
		DBGrid.Location = new Point(2, 2);
		DBGrid.Name = "DBGrid";
		DBGrid.ReadOnly = true;
		DBGrid.RowHeadersVisible = false;
		DBGrid.RowHeadersWidth = 51;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		DBGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
		DBGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DBGrid.Size = new Size(713, 523);
		DBGrid.TabIndex = 0;
		LoadCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LoadCounter.BackColor = Color.FromArgb(43, 43, 43);
		LoadCounter.BorderStyle = BorderStyle.None;
		LoadCounter.Font = new Font("Segoe UI", 12f);
		LoadCounter.ForeColor = Color.FromArgb(220, 220, 220);
		LoadCounter.Location = new Point(253, 546);
		LoadCounter.Margin = new Padding(0);
		LoadCounter.Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		LoadCounter.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		LoadCounter.Name = "LoadCounter";
		LoadCounter.Size = new Size(54, 25);
		LoadCounter.TabIndex = 6;
		LoadCounter.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		LoadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LoadButton.BackColor = Color.Transparent;
		LoadButton.DialogResult = DialogResult.None;
		LoadButton.ForeColor = SystemColors.Control;
		LoadButton.Location = new Point(312, 548);
		LoadButton.Name = "LoadButton";
		LoadButton.Padding = new Padding(5);
		LoadButton.RoundRadius = 0;
		LoadButton.Size = new Size(124, 23);
		LoadButton.TabIndex = 5;
		LoadButton.Text = "Load Selected";
		TableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 306f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 732f));
		TableLayoutPanel1.Controls.Add(Panel_LoadedCargo, 0, 0);
		TableLayoutPanel1.Controls.Add(Panel_AvailableCargo, 1, 0);
		TableLayoutPanel1.Location = new Point(0, 0);
		TableLayoutPanel1.Margin = new Padding(0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel1.Size = new Size(1034, 574);
		TableLayoutPanel1.TabIndex = 8;
		Panel_LoadedCargo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel_LoadedCargo.Controls.Add(DeleteButton);
		Panel_LoadedCargo.Controls.Add(EditContainerButton);
		Panel_LoadedCargo.Controls.Add(CrewBar);
		Panel_LoadedCargo.Controls.Add(AreaBar);
		Panel_LoadedCargo.Controls.Add(MassBar);
		Panel_LoadedCargo.Controls.Add(SizeLabel);
		Panel_LoadedCargo.Controls.Add(InventoryGridView);
		Panel_LoadedCargo.Controls.Add(UnloadButton);
		Panel_LoadedCargo.Controls.Add(UnloadCounter);
		Panel_LoadedCargo.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Panel_LoadedCargo.Location = new Point(0, 0);
		Panel_LoadedCargo.Margin = new Padding(0);
		Panel_LoadedCargo.Name = "Panel_LoadedCargo";
		Panel_LoadedCargo.SectionHeader = "Current Cargo at ";
		Panel_LoadedCargo.Size = new Size(306, 574);
		Panel_LoadedCargo.TabIndex = 0;
		DeleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DeleteButton.BackColor = Color.Transparent;
		DeleteButton.DialogResult = DialogResult.None;
		DeleteButton.ForeColor = Color.Red;
		DeleteButton.Location = new Point(197, 548);
		DeleteButton.Name = "DeleteButton";
		DeleteButton.Padding = new Padding(5);
		DeleteButton.RoundRadius = 0;
		DeleteButton.Size = new Size(101, 23);
		DeleteButton.TabIndex = 17;
		DeleteButton.Text = "Delete Selected";
		EditContainerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		EditContainerButton.BackColor = Color.Transparent;
		EditContainerButton.DialogResult = DialogResult.None;
		EditContainerButton.ForeColor = SystemColors.Control;
		EditContainerButton.Location = new Point(197, 548);
		EditContainerButton.Name = "EditContainerButton";
		EditContainerButton.Padding = new Padding(5);
		EditContainerButton.RoundRadius = 0;
		EditContainerButton.Size = new Size(101, 23);
		EditContainerButton.TabIndex = 17;
		EditContainerButton.Text = "Edit Container";
		CrewBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		CrewBar.BackColor = Color.Transparent;
		CrewBar.CustomForeColor = Color.Transparent;
		CrewBar.Location = new Point(8, 522);
		CrewBar.Maximum = 100;
		CrewBar.Name = "CrewBar";
		CrewBar.ShowProgressLines = false;
		CrewBar.ShowProgressValue = false;
		CrewBar.ShowText = true;
		CrewBar.Size = new Size(290, 20);
		CrewBar.TabIndex = 16;
		CrewBar.Text = "PAX:";
		CrewBar.Value = 0;
		AreaBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		AreaBar.BackColor = Color.Transparent;
		AreaBar.CustomForeColor = Color.Transparent;
		AreaBar.Location = new Point(8, 499);
		AreaBar.Maximum = 100;
		AreaBar.Name = "AreaBar";
		AreaBar.ShowProgressLines = false;
		AreaBar.ShowProgressValue = false;
		AreaBar.ShowText = true;
		AreaBar.Size = new Size(290, 20);
		AreaBar.TabIndex = 15;
		AreaBar.Text = "Area:";
		AreaBar.Value = 0;
		MassBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		MassBar.BackColor = Color.Transparent;
		MassBar.CustomForeColor = Color.Transparent;
		MassBar.Location = new Point(8, 476);
		MassBar.Maximum = 100;
		MassBar.Name = "MassBar";
		MassBar.ShowProgressLines = false;
		MassBar.ShowProgressValue = false;
		MassBar.ShowText = true;
		MassBar.Size = new Size(290, 20);
		MassBar.TabIndex = 14;
		MassBar.Text = "Mass:";
		MassBar.Value = 0;
		SizeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		SizeLabel.ForeColor = Color.White;
		SizeLabel.Location = new Point(8, 453);
		SizeLabel.Name = "SizeLabel";
		SizeLabel.Size = new Size(290, 20);
		SizeLabel.TabIndex = 13;
		SizeLabel.Text = "最大尺寸：";
		SizeLabel.TextAlign = ContentAlignment.MiddleLeft;
		InventoryGridView.AllowUserToAddRows = false;
		InventoryGridView.AllowUserToDeleteRows = false;
		InventoryGridView.AllowUserToOrderColumns = true;
		InventoryGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		InventoryGridView.BackgroundColor = Color.FromArgb(60, 63, 65);
		InventoryGridView.BorderStyle = BorderStyle.None;
		InventoryGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		InventoryGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		InventoryGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle7.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle7.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle7.ForeColor = Color.LightGray;
		dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		InventoryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		InventoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		InventoryGridView.Columns.AddRange(InvColName, InvColMass, InvColArea, InvColCrew);
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle8.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle8.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle8.ForeColor = Color.LightGray;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
		InventoryGridView.DefaultCellStyle = dataGridViewCellStyle8;
		InventoryGridView.EnableHeadersVisualStyles = false;
		InventoryGridView.Location = new Point(0, 28);
		InventoryGridView.Name = "InventoryGridView";
		InventoryGridView.ReadOnly = true;
		InventoryGridView.RowHeadersVisible = false;
		InventoryGridView.RowHeadersWidth = 51;
		dataGridViewCellStyle9.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle9.ForeColor = Color.LightGray;
		dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle9.SelectionForeColor = Color.LightGray;
		InventoryGridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
		InventoryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		InventoryGridView.Size = new Size(308, 417);
		InventoryGridView.TabIndex = 12;
		InvColName.HeaderText = "名称";
		InvColName.MinimumWidth = 6;
		InvColName.Name = "InvColName";
		InvColName.ReadOnly = true;
		InvColName.SortMode = DataGridViewColumnSortMode.NotSortable;
		InvColName.Width = 162;
		InvColMass.HeaderText = "Mass";
		InvColMass.MinimumWidth = 6;
		InvColMass.Name = "InvColMass";
		InvColMass.ReadOnly = true;
		InvColMass.Width = 48;
		InvColArea.HeaderText = "区域";
		InvColArea.MinimumWidth = 6;
		InvColArea.Name = "InvColArea";
		InvColArea.ReadOnly = true;
		InvColArea.Width = 48;
		InvColCrew.HeaderText = "PAX";
		InvColCrew.MinimumWidth = 6;
		InvColCrew.Name = "InvColCrew";
		InvColCrew.ReadOnly = true;
		InvColCrew.Width = 32;
		Panel_AvailableCargo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel_AvailableCargo.Controls.Add(CB_Filter);
		Panel_AvailableCargo.Controls.Add(TB_Filter);
		Panel_AvailableCargo.Controls.Add(CustomNameLabel);
		Panel_AvailableCargo.Controls.Add(CustomNameTextBox);
		Panel_AvailableCargo.Controls.Add(CargoSourceTabControl);
		Panel_AvailableCargo.Controls.Add(LoadButton);
		Panel_AvailableCargo.Controls.Add(LoadCounter);
		Panel_AvailableCargo.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Panel_AvailableCargo.Location = new Point(306, 0);
		Panel_AvailableCargo.Margin = new Padding(0);
		Panel_AvailableCargo.Name = "Panel_AvailableCargo";
		Panel_AvailableCargo.SectionHeader = "Load or Create Cargo (Units, Mounts, Containers and Contents)";
		Panel_AvailableCargo.Size = new Size(732, 574);
		Panel_AvailableCargo.TabIndex = 1;
		CB_Filter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		CB_Filter.AutoSize = true;
		CB_Filter.Location = new Point(460, 551);
		CB_Filter.Name = "CB_Filter";
		CB_Filter.Size = new Size(74, 19);
		CB_Filter.TabIndex = 15;
		CB_Filter.Text = "过滤：";
		TB_Filter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		TB_Filter.AutoCompleteCustomSource = null;
		TB_Filter.AutoCompleteMode = AutoCompleteMode.None;
		TB_Filter.AutoCompleteSource = AutoCompleteSource.None;
		TB_Filter.BackColor = Color.Transparent;
		TB_Filter.Font = new Font("Segoe UI", 10f);
		TB_Filter.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Filter.Image = null;
		TB_Filter.Lines = null;
		TB_Filter.Location = new Point(537, 550);
		TB_Filter.MaxLength = 32767;
		TB_Filter.Multiline = false;
		TB_Filter.Name = "TB_Filter";
		TB_Filter.ReadOnly = false;
		TB_Filter.ScrollBars = ScrollBars.None;
		TB_Filter.SelectionStart = 0;
		TB_Filter.Size = new Size(186, 20);
		TB_Filter.TabIndex = 14;
		TB_Filter.TextAlign = HorizontalAlignment.Left;
		TB_Filter.UseSystemPasswordChar = false;
		TB_Filter.WatermarkText = "";
		CustomNameLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CustomNameLabel.AutoSize = true;
		CustomNameLabel.ForeColor = Color.FromArgb(220, 220, 220);
		CustomNameLabel.Location = new Point(0, 549);
		CustomNameLabel.Name = "CustomNameLabel";
		CustomNameLabel.Size = new Size(88, 15);
		CustomNameLabel.TabIndex = 8;
		CustomNameLabel.Text = "Custom Name:";
		CustomNameLabel.TextAlign = ContentAlignment.MiddleRight;
		CustomNameTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CustomNameTextBox.AutoCompleteCustomSource = null;
		CustomNameTextBox.AutoCompleteMode = AutoCompleteMode.None;
		CustomNameTextBox.AutoCompleteSource = AutoCompleteSource.None;
		CustomNameTextBox.BackColor = Color.Transparent;
		CustomNameTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		CustomNameTextBox.Image = null;
		CustomNameTextBox.Lines = null;
		CustomNameTextBox.Location = new Point(97, 547);
		CustomNameTextBox.MaxLength = 256;
		CustomNameTextBox.Multiline = false;
		CustomNameTextBox.Name = "CustomNameTextBox";
		CustomNameTextBox.ReadOnly = false;
		CustomNameTextBox.ScrollBars = ScrollBars.None;
		CustomNameTextBox.SelectionStart = 0;
		CustomNameTextBox.Size = new Size(147, 23);
		CustomNameTextBox.TabIndex = 7;
		CustomNameTextBox.TextAlign = HorizontalAlignment.Left;
		CustomNameTextBox.UseSystemPasswordChar = false;
		CustomNameTextBox.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1034, 583);
		base.Controls.Add(TableLayoutPanel1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditCargoV2";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑货物";
		((ISupportInitialize)UnloadCounter).EndInit();
		CargoSourceTabControl.ResumeLayout(performLayout: false);
		UnitsTab.ResumeLayout(performLayout: false);
		((ISupportInitialize)ExistingUnitsGridView).EndInit();
		DatabaseTab.ResumeLayout(performLayout: false);
		((ISupportInitialize)DBGrid).EndInit();
		((ISupportInitialize)LoadCounter).EndInit();
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		Panel_LoadedCargo.ResumeLayout(performLayout: false);
		((ISupportInitialize)InventoryGridView).EndInit();
		Panel_AvailableCargo.ResumeLayout(performLayout: false);
		Panel_AvailableCargo.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			SelectedHost = null;
			threadReponse = null;
			InventoryGridView.Rows.Clear();
			ExistingUnitsGridView.Rows.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = dispatcherReponse;
		Keys[] array2 = array;
		foreach (Keys keys in array2)
		{
			if (keyData == keys)
			{
				Close();
				return true;
			}
		}
		return false;
	}

	private void ListMapping(object sender, EventArgs e)
	{
		Scenario.UnitAdded += HandleUnitAdded;
		Scenario.UnitRemoved += HandleUnitRemoved;
		_ExpressionReponse = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
	}

	private void ResolveMapping(object sender, EventArgs e)
	{
		if (SelectedHost is Group)
		{
			DarkMessageBox.ShowError("请选择一个单元，而不是一个编组。", "Error");
			Close();
			return;
		}
		threadReponse = (ICargoHost)SelectedHost;
		Text = "编辑货物" + SelectedHost.Name;
		Panel_LoadedCargo.SectionHeader = "Current Cargo at " + SelectedHost.Name;
		LoadButton.Enabled = false;
		LoadCounter.Visible = false;
		UnloadButton.Enabled = false;
		DeleteButton.Visible = false;
		UnloadCounter.Visible = false;
		CustomNameLabel.Visible = false;
		CustomNameTextBox.Visible = false;
		EditContainerButton.Enabled = false;
		if (!AllowCargoContainers)
		{
			EditContainerButton.Visible = false;
		}
		PopulateInventory();
		DefineMapping(null, null);
		StartMapping();
		PostMapping();
		RunMapping();
	}

	public void RefreshForm()
	{
		PopulateInventory();
		StartMapping();
		PrintMapping();
		RunMapping();
		if (_ExpressionReponse != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			if (ItemExporter.ConnectInterruptibleTemplate.EditCargoContainer.Visible)
			{
				ItemExporter.ConnectInterruptibleTemplate.EditCargoContainer.Close();
			}
			QueryMapping(null, null);
			_ExpressionReponse = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.AddInterruptibleIndexer(Client.SelectedUnit, Client.SelectedUnit);
	}

	private void PostMapping()
	{
		ruleReponse = threadReponse.GetCargo_Type();
		m_CollectionReponse = threadReponse.GetCargo_Mass();
		m_InstanceReponse = threadReponse.GetCargo_Area();
		m_ObjectReponse = threadReponse.GetCargo_Crew();
		Cargo[] cargoArray = threadReponse.CargoArray;
		Cargo[] array = cargoArray;
		foreach (Cargo cargo in array)
		{
			m_CollectionReponse -= cargo.RequiredMass;
			m_InstanceReponse -= cargo.RequiredArea;
			m_ObjectReponse -= cargo.RequiredCrewSpace;
		}
	}

	private void RunMapping()
	{
		MapperListenerManager.InterruptStrategy(SelectedHost, SizeLabel, MassBar, m_CollectionReponse, AreaBar, m_InstanceReponse, CrewBar, m_ObjectReponse);
	}

	protected void PopulateInventory()
	{
		MapperListenerManager.CheckStrategy(InventoryGridView, SelectedHost, SelectedHost.OnboardCargo.ToList());
		DefineMapping(null, null);
	}

	private void StartMapping()
	{
		int num = -1;
		bool flag = !string.IsNullOrEmpty(m_ParameterReponse);
		if (ExistingUnitsGridView.SelectedRows.Count > 0)
		{
			num = ExistingUnitsGridView.SelectedRows[0].Index;
		}
		ExistingUnitsGridView.Rows.Clear();
		foreach (ActiveUnit activeUnits_ in SelectedHost.ParentScen.ActiveUnits_List)
		{
			if (activeUnits_ == SelectedHost || activeUnits_.GetUnitSide() != SelectedHost.GetUnitSide() || !activeUnits_.IsOperating() || !(activeUnits_ is ICargoClient))
			{
				continue;
			}
			ICargoClient cargoClient = (ICargoClient)activeUnits_;
			int requiredCargoType = (int)cargoClient.GetRequiredCargoType();
			if (requiredCargoType != 0 && (!flag || LikeOperator.LikeString(activeUnits_.Name, m_ParameterReponse, CompareMethod.Text)))
			{
				int index = ExistingUnitsGridView.Rows.Add();
				DataGridViewRow dataGridViewRow = ExistingUnitsGridView.Rows[index];
				dataGridViewRow.Tag = activeUnits_;
				dataGridViewRow.Cells[0].Value = activeUnits_.UnitType_String;
				dataGridViewRow.Cells[1].Value = activeUnits_.Name;
				if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					dataGridViewRow.Cells[3].Value = Cargo.DisplayValueMass(cargoClient.GetRequiredMass(), bool_0: true).ToString("N");
					dataGridViewRow.Cells[4].Value = Cargo.DisplayValueArea(cargoClient.GetRequiredArea(), bool_0: true).ToString("N");
				}
				else
				{
					dataGridViewRow.Cells[3].Value = cargoClient.GetRequiredMass().ToString("N");
					dataGridViewRow.Cells[4].Value = cargoClient.GetRequiredArea().ToString("N");
				}
				dataGridViewRow.Cells[5].Value = cargoClient.GetRequiredCrewSpace().ToString();
				dataGridViewRow.Cells[2].Value = MapperListenerManager.SearchStrategy(requiredCargoType);
				if (!threadReponse.CanLoad(cargoClient) && !threadReponse.CanTow(cargoClient))
				{
					dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
					dataGridViewRow.DefaultCellStyle.SelectionForeColor = Color.Red;
				}
			}
		}
		if (ExistingUnitsGridView.Rows.Count <= 0)
		{
			NoUnitsWarningLabel.Visible = true;
		}
		else
		{
			NoUnitsWarningLabel.Visible = false;
			if (num > -1)
			{
				ExistingUnitsGridView.ClearSelection();
				if (num >= ExistingUnitsGridView.Rows.Count)
				{
					num = ExistingUnitsGridView.Rows.Count - 1;
				}
				ExistingUnitsGridView.Rows[num].Selected = true;
			}
		}
		ExistingUnitsGridView.Refresh();
		if (CargoSourceTabControl.SelectedIndex == 0)
		{
			PublishMapping(null, null);
		}
	}

	private bool AssetMapping(DataGridViewRow dataGridViewRow_0, int int_0, CargoType cargoType_0, float float_0, float float_1, float float_2)
	{
		if (Cargo.InputValueMass(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Mass"].Value) * (float)int_0, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) <= float_0)
		{
			if (Cargo.InputValueArea(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Area"].Value) * (float)int_0, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) <= float_1)
			{
				if (Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Crew"].Value) * (float)int_0 <= float_2)
				{
					int num = MapperListenerManager.EnableStrategy(Conversions.ToString(dataGridViewRow_0.Cells["Cargo_Type"].Value));
					if (num != 0 && num <= (int)cargoType_0)
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

	private void PrintMapping()
	{
		int int_ = 1;
		bool flag = true;
		bool flag2 = !string.IsNullOrEmpty(m_ParameterReponse);
		if (LoadCounter.Enabled)
		{
			int_ = Convert.ToInt32(LoadCounter.Value);
		}
		PostMapping();
		if (flag2 && DBGrid.CurrentCell != null)
		{
			DBGrid.CurrentCell = null;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = ((IEnumerable)DBGrid.Rows).GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				flag = true;
				if (flag2)
				{
					flag = LikeOperator.LikeString(Conversions.ToString(dataGridViewRow.Cells[2].Value), m_ParameterReponse, CompareMethod.Text);
				}
				if (AssetMapping(dataGridViewRow, int_, ruleReponse, m_CollectionReponse, m_InstanceReponse, m_ObjectReponse))
				{
					dataGridViewRow.DefaultCellStyle.ForeColor = DBGrid.DefaultCellStyle.ForeColor;
					dataGridViewRow.DefaultCellStyle.SelectionForeColor = DBGrid.DefaultCellStyle.SelectionForeColor;
				}
				else
				{
					dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
					dataGridViewRow.DefaultCellStyle.SelectionForeColor = Color.Red;
				}
				dataGridViewRow.Visible = flag;
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		AwakeMapping(null, null);
	}

	private void DefineMapping(object sender, EventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		IEnumerator enumerator = null;
		try
		{
			enumerator = InventoryGridView.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (dataGridViewRow.Tag != null)
				{
					if (dataGridViewRow.Tag is CargoManifestItem)
					{
						flag2 = true;
						num = Math.Max(num, ((CargoManifestItem)dataGridViewRow.Tag).quantity);
					}
					else if (dataGridViewRow.Tag is Cargo && ((Cargo)dataGridViewRow.Tag).CargoObjectActiveUnit != null)
					{
						flag = true;
					}
					else if (dataGridViewRow.Tag is Cargo && ((Cargo)dataGridViewRow.Tag).CurrentType == Cargo.CargoObjectType.CargoContainer)
					{
						flag3 = true;
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
		if (flag3)
		{
			UnloadButton.Visible = false;
			DeleteButton.Left = UnloadButton.Left;
			DeleteButton.Visible = true;
			EditContainerButton.Visible = true;
		}
		else if (flag2 || flag)
		{
			DeleteButton.Left = EditContainerButton.Left;
			UnloadButton.Visible = true;
			DeleteButton.Visible = true;
			EditContainerButton.Visible = false;
		}
		DeleteButton.Enabled = flag2 || flag || flag3;
		UnloadCounter.Visible = flag2;
		UnloadButton.Enabled = flag;
		EditContainerButton.Enabled = flag3;
		if (flag2)
		{
			UnloadCounter.Maximum = new decimal(num);
		}
	}

	private void PublishMapping(object sender, EventArgs e)
	{
		LoadButton.Enabled = false;
		IEnumerator enumerator = null;
		try
		{
			enumerator = ExistingUnitsGridView.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (dataGridViewRow.Tag != null && (threadReponse.CanLoad((ICargoClient)dataGridViewRow.Tag) || threadReponse.CanTow((ICargoClient)dataGridViewRow.Tag)))
				{
					LoadButton.Enabled = true;
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
	}

	private void AwakeMapping(object sender, EventArgs e)
	{
		int int_ = 1;
		if (LoadCounter.Visible)
		{
			int_ = Convert.ToInt32(LoadCounter.Value);
		}
		LoadButton.Enabled = false;
		PostMapping();
		IEnumerator enumerator = null;
		try
		{
			enumerator = DBGrid.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow_ = (DataGridViewRow)enumerator.Current;
				if (AssetMapping(dataGridViewRow_, int_, ruleReponse, m_CollectionReponse, m_InstanceReponse, m_ObjectReponse))
				{
					LoadButton.Enabled = true;
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
	}

	private void QueryMapping(object sender, EventArgs e)
	{
		if (CargoSourceTabControl.SelectedIndex == 1)
		{
			LoadCounter.Visible = true;
			CustomNameLabel.Visible = true;
			CustomNameTextBox.Visible = true;
			if (_ExpressionReponse != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
			{
				DBGrid.DataSource = null;
				_ExpressionReponse = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
			}
			if (SelectedHost == null || DBGrid.DataSource != null)
			{
				return;
			}
			DataTable dataTable = null;
			bool flag = false;
			try
			{
				SQLiteConnection sqliteConnection_ = SelectedHost.ParentScen.DBConnection;
				dataTable = DBFunctions.GetAllCargoItems(ref sqliteConnection_);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				flag = true;
				ProjectData.ClearProjectError();
			}
			if (!flag && dataTable.Rows.Count != 0)
			{
				DataTable dataTable2 = dataTable.Clone();
				if (dataTable2.Columns.Contains("Deprecated"))
				{
					dataTable2.Columns.Remove("Deprecated");
				}
				dataTable2.Columns["Cargo_Type"].DataType = typeof(string);
				IEnumerator enumerator = null;
				try
				{
					enumerator = dataTable.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						if (AllowCargoContainers || Operators.CompareString(dataRow["UnitType"].ToString(), "Container", TextCompare: true) != 0)
						{
							dataTable2.ImportRow(dataRow);
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
				threadReponse.GetCargo_Type();
				IEnumerator enumerator2 = null;
				try
				{
					enumerator2 = dataTable2.Rows.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						DataRow obj = (DataRow)enumerator2.Current;
						int int_ = int.Parse(Conversions.ToString(obj["Cargo_Type"]));
						obj["Cargo_Type"] = MapperListenerManager.SearchStrategy(int_);
					}
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
				DBGrid.DataSource = new DataView(dataTable2);
				DBGrid.Columns["UnitType"].HeaderText = "类型";
				DBGrid.Columns["Cargo_Type"].HeaderText = "Cargo Size";
				DBGrid.Columns["Cargo_Mass"].HeaderText = "块";
				DBGrid.Columns["Cargo_Mass"].DefaultCellStyle.Format = "N";
				DBGrid.Columns["Cargo_Area"].HeaderText = "区域";
				DBGrid.Columns["Cargo_Area"].DefaultCellStyle.Format = "N";
				DBGrid.Columns["Cargo_Crew"].HeaderText = "PAX";
				DBGrid.Columns["Cargo_ParadropCapable"].HeaderText = "Airdrop";
				DBGrid.AutoResizeColumns();
				if (DBGrid.Columns["Name"].Width > 300)
				{
					DBGrid.Columns["Name"].Width = 300;
				}
				if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
				{
					IEnumerator enumerator3 = null;
					try
					{
						enumerator3 = ((IEnumerable)DBGrid.Rows).GetEnumerator();
						while (enumerator3.MoveNext())
						{
							DataGridViewRow obj2 = (DataGridViewRow)enumerator3.Current;
							float float_ = Conversions.ToSingle(obj2.Cells["Cargo_Mass"].Value);
							obj2.Cells["Cargo_Mass"].Value = Cargo.DisplayValueMass(float_, bool_0: true);
							float_ = Conversions.ToSingle(obj2.Cells["Cargo_Area"].Value);
							obj2.Cells["Cargo_Area"].Value = Cargo.DisplayValueArea(float_, bool_0: true);
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
				DBGrid.Refresh();
				PrintMapping();
			}
			else
			{
				DarkMessageBox.ShowError("无法使用当前加载的数据库进行货物相关任务。请将想定升级到最新数据库。", "Error");
				Close();
			}
		}
		else
		{
			LoadCounter.Visible = false;
			CustomNameLabel.Visible = false;
			CustomNameTextBox.Visible = false;
			StartMapping();
		}
	}

	private void ResetMapping(object sender, EventArgs e)
	{
		new List<Cargo>();
		int num = 1;
		string text = "";
		bool flag = false;
		bool flag2 = false;
		PostMapping();
		string text2 = LoadButton.Text;
		LoadButton.Enabled = false;
		LoadButton.Text = "工作中...";
		if (CargoSourceTabControl.SelectedIndex == 1)
		{
			Mount mount = null;
			Vehicle vehicle = null;
			Facility facility = null;
			int num2 = 1;
			if (LoadCounter.Visible)
			{
				num = Convert.ToInt32(LoadCounter.Value);
			}
			if (CustomNameTextBox.Visible)
			{
				text = CustomNameTextBox.Text;
				flag = !string.IsNullOrEmpty(text);
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = DBGrid.SelectedRows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					int num3 = Conversions.ToInteger(dataGridViewRow.Cells["ID"].Value);
					if (num3 > 0)
					{
						int num4 = num - 1;
						for (int i = 0; i <= num4; i++)
						{
							string left = dataGridViewRow.Cells["UnitType"].Value.ToString();
							if (Operators.CompareString(left, "地面单元", TextCompare: true) == 0)
							{
								if (flag)
								{
									vehicle = Client.CurrentScenario.AddNewVehicle(Client.CurrentSide, num3, text + " #" + Conversions.ToString(num2), SelectedHost.GetLongitude(), SelectedHost.GetLatitude(), bool_0: true);
									num2++;
								}
								else
								{
									SQLiteConnection sqliteConnection_ = SelectedHost.ParentScen.DBConnection;
									text = DBFunctions.GetVehicleName(num3, ref sqliteConnection_);
									text = text + " #" + Conversions.ToString(SelectedHost.ParentScen.UnitsAutoIncrement);
									vehicle = Client.CurrentScenario.AddNewVehicle(Client.CurrentSide, num3, text, SelectedHost.GetLongitude(), SelectedHost.GetLatitude(), bool_0: true);
								}
								if (threadReponse.CanLoad(vehicle))
								{
									Cargo cargo_ = new Cargo(SelectedHost, vehicle);
									vehicle.DockingOps.LoadIntoCargo(SelectedHost);
									threadReponse.Add(cargo_);
									continue;
								}
								if (!threadReponse.CanTow(vehicle))
								{
									SelectedHost.ParentScen.DeleteUnitImmediately(vehicle.ObjectID, bool_0: true, "Failed to load into cargo.");
									flag2 = true;
									break;
								}
								Cargo cargo = new Cargo(SelectedHost, vehicle);
								cargo.StorageType = Cargo.CargoStorageType.TowedExternal;
								vehicle.DockingOps.LoadIntoCargo(SelectedHost);
								threadReponse.Add(cargo);
							}
							else if (Operators.CompareString(left, "可机动设施", TextCompare: true) == 0)
							{
								if (flag)
								{
									facility = Client.CurrentScenario.AddNewFacility(Client.CurrentSide, num3, text + " #" + Conversions.ToString(num2), SelectedHost.GetLongitude(), SelectedHost.GetLatitude(), bool_0: true);
									num2++;
								}
								else
								{
									SQLiteConnection sqliteConnection_2 = SelectedHost.ParentScen.DBConnection;
									text = DBFunctions.GetFacilityName(num3, ref sqliteConnection_2);
									text = text + " #" + Conversions.ToString(SelectedHost.ParentScen.UnitsAutoIncrement);
									facility = Client.CurrentScenario.AddNewFacility(Client.CurrentSide, num3, text, SelectedHost.GetLongitude(), SelectedHost.GetLatitude(), bool_0: true);
								}
								if (!threadReponse.CanLoad(facility))
								{
									SelectedHost.ParentScen.DeleteUnitImmediately(facility.ObjectID, bool_0: true, "Failed to load into cargo.");
									flag2 = true;
									break;
								}
								Cargo cargo_2 = new Cargo(SelectedHost, facility);
								facility.DockingOps.LoadIntoCargo(SelectedHost);
								threadReponse.Add(cargo_2);
							}
							else if (Operators.CompareString(left, "Mount", TextCompare: true) == 0)
							{
								mount = DBFunctions.GetMount(num3, ref SelectedHost.ParentScen);
								if (!threadReponse.CanLoad(mount))
								{
									flag2 = true;
									break;
								}
								Cargo cargo_3 = new Cargo(SelectedHost, mount);
								threadReponse.Add(cargo_3);
							}
							else if (Operators.CompareString(left, "Container", TextCompare: true) == 0)
							{
								CargoContainer cargoContainer = DBFunctions.GetCargoContainer(num3, ref SelectedHost.ParentScen);
								if (!threadReponse.CanLoad(cargoContainer))
								{
									flag2 = true;
									break;
								}
								Cargo cargo_4 = new Cargo(SelectedHost, cargoContainer, (ICargoHost)SelectedHost);
								threadReponse.Add(cargo_4);
							}
						}
					}
					if (flag2)
					{
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
			CustomNameTextBox.Text = "";
		}
		else
		{
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = ExistingUnitsGridView.SelectedRows.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ActiveUnit activeUnit = (ActiveUnit)((DataGridViewRow)enumerator2.Current).Tag;
					ICargoClient icargoClient_ = (ICargoClient)activeUnit;
					if (threadReponse.CanLoad(icargoClient_))
					{
						Cargo cargo_5 = new Cargo(SelectedHost, activeUnit);
						activeUnit.DockingOps.LoadIntoCargo(SelectedHost);
						threadReponse.Add(cargo_5);
						continue;
					}
					if (threadReponse.CanTow(icargoClient_))
					{
						Cargo cargo2 = new Cargo(SelectedHost, activeUnit);
						cargo2.StorageType = Cargo.CargoStorageType.TowedExternal;
						activeUnit.DockingOps.LoadIntoCargo(SelectedHost);
						threadReponse.Add(cargo2);
						continue;
					}
					flag2 = true;
					break;
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
		LoadButton.Text = text2;
		LoadButton.Enabled = true;
		if (flag2)
		{
			DarkMessageBox.ShowWarning("Unable to add all of the selected cargo to host - maximum capacity exceeded.", "空间不足！");
		}
		RefreshForm();
	}

	private void MapMapping(object sender, EventArgs e)
	{
		List<Cargo> list = new List<Cargo>();
		List<Cargo> list2 = new List<Cargo>();
		IEnumerator enumerator = null;
		try
		{
			enumerator = InventoryGridView.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (!(dataGridViewRow.Tag is CargoManifestItem))
				{
					Cargo cargo = (Cargo)dataGridViewRow.Tag;
					if ((uint)(cargo.CurrentType - 4) > 1u)
					{
						list.Add(cargo);
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
		if (list.Count > 0)
		{
			List<Cargo> list3 = new List<Cargo>();
			ActiveUnit activeUnit = null;
			foreach (Cargo item in list)
			{
				list3.Clear();
				string cargoObjectID = item.CargoObjectID;
				if (SelectedHost.ParentScen.ActiveUnits.TryGetValue(cargoObjectID, ref activeUnit))
				{
					list3.Add(item);
					double latitude_old = activeUnit.Latitude_old;
					double longitude_old = activeUnit.Longitude_old;
					ActiveUnit selectedHost = SelectedHost;
					ICargoHost cargoHost;
					Cargo[] cargo_ = (cargoHost = threadReponse).CargoArray;
					Cargo.UnloadCargoAtLocation(selectedHost, ref cargo_, list3, latitude_old, longitude_old, SelectedHost.ParentScen, SelectedHost.GetUnitSide(), bool_0: false, bool_1: true);
					cargoHost.CargoArray = cargo_;
				}
			}
		}
		if (list2.Count > 0)
		{
			foreach (Cargo item2 in list2)
			{
				threadReponse.Remove(item2);
			}
		}
		PostMapping();
		RefreshForm();
	}

	public void HandleUnitAdded(Scenario scenario_0, string string_0)
	{
		if (base.InvokeRequired)
		{
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				HandleUnitAdded(scenario_0, string_0);
			});
		}
		else if (base.Visible)
		{
			RefreshForm();
		}
	}

	public void HandleUnitRemoved(Scenario scenario_0, ActiveUnit activeUnit_0)
	{
		if (base.InvokeRequired)
		{
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				HandleUnitRemoved(scenario_0, activeUnit_0);
			});
		}
		else if (base.Visible)
		{
			if (activeUnit_0 == SelectedHost)
			{
				SelectedHost = null;
				threadReponse = null;
				Close();
			}
			else
			{
				RefreshForm();
			}
		}
	}

	private void SortMapping()
	{
		StartMapping();
		PrintMapping();
	}

	private void CalcMapping(object sender, EventArgs e)
	{
		List<Cargo> list = new List<Cargo>();
		int num = 0;
		int num2 = 0;
		IEnumerator enumerator = null;
		try
		{
			enumerator = InventoryGridView.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (dataGridViewRow.Tag is CargoManifestItem)
				{
					CargoManifestItem cargoManifestItem = (CargoManifestItem)dataGridViewRow.Tag;
					if (UnloadCounter.Visible)
					{
						num = Convert.ToInt32(UnloadCounter.Value);
						if (num > cargoManifestItem.quantity)
						{
							num = cargoManifestItem.quantity;
						}
					}
					else
					{
						num = 1;
					}
					for (num2 = 0; num2 < SelectedHost.OnboardCargo.Count(); num2++)
					{
						if (num <= 0)
						{
							break;
						}
						if (SelectedHost.OnboardCargo[num2].CurrentType == cargoManifestItem.objectType && SelectedHost.OnboardCargo[num2].CargoObjectDBID == cargoManifestItem.DBID)
						{
							list.Add(SelectedHost.OnboardCargo[num2]);
							num--;
						}
					}
				}
				else
				{
					list.Add((Cargo)dataGridViewRow.Tag);
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
		if (list.Count > 0)
		{
			foreach (Cargo item in list)
			{
				ArrayExtensions.Remove(ref SelectedHost.OnboardCargo, item);
				ActiveUnit cargoObjectActiveUnit = item.CargoObjectActiveUnit;
				if (cargoObjectActiveUnit != null)
				{
					Client.CurrentScenario.DeleteUnitImmediately(cargoObjectActiveUnit.ObjectID, bool_0: true, "Unit was deleted while editing cargo.");
				}
			}
		}
		PostMapping();
		RefreshForm();
	}

	private void RateMapping(object sender, EventArgs e)
	{
		if (CB_Filter.Checked)
		{
			m_ParameterReponse = "*" + Misc.PatchValue(TB_Filter.Text) + "*";
		}
		else
		{
			m_ParameterReponse = "";
		}
		if (CargoSourceTabControl.SelectedIndex == 1)
		{
			PrintMapping();
		}
		else
		{
			StartMapping();
		}
	}

	private void FlushMapping(object object_0)
	{
		if (CB_Filter.Checked && Operators.CompareString(TB_Filter.Text, "", TextCompare: true) != 0)
		{
			m_ParameterReponse = "*" + Misc.PatchValue(TB_Filter.Text) + "*";
			if (CargoSourceTabControl.SelectedIndex == 1)
			{
				PrintMapping();
			}
			else
			{
				StartMapping();
			}
		}
	}

	private void ForgotMapping(object sender, EventArgs e)
	{
		if (InventoryGridView.SelectedRows.Count <= 0)
		{
			return;
		}
		int num = InventoryGridView.SelectedRows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (InventoryGridView.SelectedRows[i].Tag is Cargo)
			{
				Cargo cargo = (Cargo)InventoryGridView.SelectedRows[i].Tag;
				if (cargo.CurrentType == Cargo.CargoObjectType.CargoContainer)
				{
					ItemExporter.ConnectInterruptibleTemplate.EditCargoContainer.SelectedActiveUnit = SelectedHost;
					ItemExporter.ConnectInterruptibleTemplate.EditCargoContainer.SelectedContainer = cargo.CargoObjectContainer;
					ItemExporter.ConnectInterruptibleTemplate.EditCargoContainer.ShowDialog();
					break;
				}
			}
		}
	}

	private void CollectMapping(object sender, EventArgs e)
	{
	}
}
