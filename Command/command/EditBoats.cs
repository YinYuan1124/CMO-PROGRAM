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
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditBoats : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class InvocationMap
	{
		public int Local_theDBID;

		internal bool ChangeInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == Local_theDBID);
		}
	}

	[CompilerGenerated]
	private sealed class HelperCollectionRecord
	{
		public int Local_theDBID0;

		internal bool InitInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == Local_theDBID0);
		}
	}

	[CompilerGenerated]
	private sealed class ClassMap
	{
		public int Local_theDBID00;

		internal bool CheckInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == Local_theDBID00);
		}
	}

	[CompilerGenerated]
	private sealed class TagInstanceFilter
	{
		public int num;

		internal bool ConcatInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == num);
		}

		internal bool InterruptInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == num);
		}

		internal bool RemoveInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == num);
		}
	}

	[CompilerGenerated]
	private sealed class RequestMap
	{
		public int Local_BoatDBID;

		internal bool FindInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == Local_BoatDBID);
		}

		internal bool SetInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == Local_BoatDBID);
		}

		internal bool FillInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == Local_BoatDBID);
		}
	}

	[CompilerGenerated]
	private sealed class ValueMap
	{
		public int Local_BoatDBID;

		internal bool CalculateInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == Local_BoatDBID);
		}

		internal bool PopInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == Local_BoatDBID);
		}

		internal bool InstantiateInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == Local_BoatDBID);
		}
	}

	private IContainer _ProcSpecification;

	[AccessedThroughProperty("CB_Country")]
	[CompilerGenerated]
	private DarkUIComboBox m_MerchantWatcher;

	[AccessedThroughProperty("TB_Class")]
	[CompilerGenerated]
	private DarkUITextBox m_ProcessWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView _ThreadWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveBoat")]
	private DarkUIButton _RuleWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("Quantity")]
	private DarkGroupBox m_CollectionWatcher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _ObjectWatcher;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton dispatcherWatcher;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel listenerWatcher;

	[AccessedThroughProperty("ListView1")]
	[CompilerGenerated]
	private DarkListView m_RegistryWatcher;

	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_DefinitionWatcher;

	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn valWatcher;

	[AccessedThroughProperty("IOC")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn observerWatcher;

	[AccessedThroughProperty("CountryNumber")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn clientWatcher;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox consumerWatcher;

	[AccessedThroughProperty("CB_SubType")]
	[CompilerGenerated]
	private DarkUIComboBox proxyWatcher;

	[AccessedThroughProperty("CB_Hypothetical")]
	[CompilerGenerated]
	private DarkUIComboBox m_ReaderWatcher;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel m_ImporterWatcher;

	public ActiveUnit SelectedHost;

	private DataTable _RepositoryWatcher;

	[field: AccessedThroughProperty("GroupBox1")]
	internal DarkGroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_Country
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewTemplate;
			DarkUIComboBox merchantWatcher = m_MerchantWatcher;
			if (merchantWatcher != null)
			{
				merchantWatcher.SelectedIndexChanged -= value2;
			}
			m_MerchantWatcher = value;
			merchantWatcher = m_MerchantWatcher;
			if (merchantWatcher != null)
			{
				merchantWatcher.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TB_Class
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = ValidateTemplate;
			DarkUITextBox processWatcher = m_ProcessWatcher;
			if (processWatcher != null)
			{
				processWatcher.TextChanged -= value2;
			}
			m_ProcessWatcher = value;
			processWatcher = m_ProcessWatcher;
			if (processWatcher != null)
			{
				processWatcher.TextChanged += value2;
			}
		}
	}

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return _ThreadWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = LogoutTemplate;
			DataGridViewCellEventHandler value3 = ExcludeTemplate;
			DarkDataGridView threadWatcher = _ThreadWatcher;
			if (threadWatcher != null)
			{
				threadWatcher.KeyPress -= value2;
				threadWatcher.CellContentDoubleClick -= value3;
			}
			_ThreadWatcher = value;
			threadWatcher = _ThreadWatcher;
			if (threadWatcher != null)
			{
				threadWatcher.KeyPress += value2;
				threadWatcher.CellContentDoubleClick += value3;
			}
		}
	}

	internal DarkUIButton Button_RemoveBoat
	{
		[CompilerGenerated]
		get
		{
			return _RuleWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallTemplate;
			DarkUIButton ruleWatcher = _RuleWatcher;
			if (ruleWatcher != null)
			{
				ruleWatcher.Click -= value2;
			}
			_RuleWatcher = value;
			ruleWatcher = _RuleWatcher;
			if (ruleWatcher != null)
			{
				ruleWatcher.Click += value2;
			}
		}
	}

	internal DarkGroupBox Quantity
	{
		[CompilerGenerated]
		get
		{
			return m_CollectionWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CollectionWatcher = value;
		}
	}

	[field: AccessedThroughProperty("NUD1")]
	internal DarkNumericUpDown NUD1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _ObjectWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectTemplate;
			DarkUIButton objectWatcher = _ObjectWatcher;
			if (objectWatcher != null)
			{
				objectWatcher.Click -= value2;
			}
			_ObjectWatcher = value;
			objectWatcher = _ObjectWatcher;
			if (objectWatcher != null)
			{
				objectWatcher.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TB_Quantity")]
	internal DarkUITextBox TB_Quantity
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return dispatcherWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchTemplate;
			DarkUIButton darkUIButton = dispatcherWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			dispatcherWatcher = value;
			darkUIButton = dispatcherWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return listenerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			listenerWatcher = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkListView ListView1
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyTemplate;
			DarkListView registryWatcher = m_RegistryWatcher;
			if (registryWatcher != null)
			{
				registryWatcher.SelectedIndicesChanged -= value2;
			}
			m_RegistryWatcher = value;
			registryWatcher = m_RegistryWatcher;
			if (registryWatcher != null)
			{
				registryWatcher.SelectedIndicesChanged += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DefinitionWatcher = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[CompilerGenerated]
		get
		{
			return valWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valWatcher = value;
		}
	}

	[field: AccessedThroughProperty("Country")]
	internal DataGridViewTextBoxColumn Country
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn IOC
	{
		[CompilerGenerated]
		get
		{
			return observerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			observerWatcher = value;
		}
	}

	[field: AccessedThroughProperty("Retired")]
	internal DataGridViewTextBoxColumn Retired
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn CountryNumber
	{
		[CompilerGenerated]
		get
		{
			return clientWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			clientWatcher = value;
		}
	}

	[field: AccessedThroughProperty("Column2")]
	internal DataGridViewTextBoxColumn Column2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return consumerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetTemplate;
			DarkUIComboBox darkUIComboBox = consumerWatcher;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			consumerWatcher = value;
			darkUIComboBox = consumerWatcher;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal DarkLabel Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_SubType
	{
		[CompilerGenerated]
		get
		{
			return proxyWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupTemplate;
			DarkUIComboBox darkUIComboBox = proxyWatcher;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			proxyWatcher = value;
			darkUIComboBox = proxyWatcher;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushTemplate;
			DarkUIComboBox readerWatcher = m_ReaderWatcher;
			if (readerWatcher != null)
			{
				readerWatcher.SelectionChangeCommitted -= value2;
			}
			m_ReaderWatcher = value;
			readerWatcher = m_ReaderWatcher;
			if (readerWatcher != null)
			{
				readerWatcher.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label11")]
	internal DarkLabel Label11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_ImporterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ImporterWatcher = value;
		}
	}

	public EditBoats()
	{
		base.Load += ConnectTemplate;
		base.FormClosing += DeleteTemplate;
		base.KeyDown += WriteTemplate;
		CloneTemplate();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ProcSpecification != null)
			{
				_ProcSpecification.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CloneTemplate()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		GroupBox1 = new DarkGroupBox();
		ComboBox1 = new DarkUIComboBox();
		Label4 = new DarkLabel();
		CB_Country = new DarkUIComboBox();
		Label3 = new DarkLabel();
		Label6 = new DarkLabel();
		TB_Class = new DarkUITextBox();
		Label7 = new DarkLabel();
		CB_SubType = new DarkUIComboBox();
		Label11 = new DarkLabel();
		CB_Hypothetical = new DarkUIComboBox();
		DataGridView1 = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		Country = new DataGridViewTextBoxColumn();
		IOC = new DataGridViewTextBoxColumn();
		Retired = new DataGridViewTextBoxColumn();
		CountryNumber = new DataGridViewTextBoxColumn();
		Column2 = new DataGridViewTextBoxColumn();
		Button_RemoveBoat = new DarkUIButton();
		Quantity = new DarkGroupBox();
		NUD1 = new DarkNumericUpDown();
		Button2 = new DarkUIButton();
		TB_Quantity = new DarkUITextBox();
		Label5 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		ListView1 = new DarkListView();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)DataGridView1).BeginInit();
		Quantity.SuspendLayout();
		((ISupportInitialize)NUD1).BeginInit();
		SuspendLayout();
		GroupBox1.Controls.Add(ComboBox1);
		GroupBox1.Controls.Add(Label4);
		GroupBox1.Controls.Add(CB_Country);
		GroupBox1.Controls.Add(Label3);
		GroupBox1.Controls.Add(Label6);
		GroupBox1.Controls.Add(TB_Class);
		GroupBox1.Controls.Add(Label7);
		GroupBox1.Controls.Add(CB_SubType);
		GroupBox1.Controls.Add(Label11);
		GroupBox1.Controls.Add(CB_Hypothetical);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(296, 29);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(604, 110);
		GroupBox1.TabIndex = 34;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "过滤...";
		ComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		ComboBox1.BackColor = Color.Transparent;
		ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox1.Font = new Font("Segoe UI", 7f);
		ComboBox1.Items.AddRange(new object[3] { "舰船", "潜艇", "Amphibious Vehicles" });
		ComboBox1.Location = new Point(111, 70);
		ComboBox1.Name = "ComboBox1";
		ComboBox1.Size = new Size(196, 24);
		ComboBox1.TabIndex = 15;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(7, 75);
		Label4.Name = "Label4";
		Label4.Size = new Size(61, 19);
		Label4.TabIndex = 14;
		Label4.Text = "类型：";
		CB_Country.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Country.BackColor = Color.Transparent;
		CB_Country.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Country.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Country.Font = new Font("Segoe UI", 7f);
		CB_Country.Location = new Point(393, 14);
		CB_Country.Name = "CB_Country";
		CB_Country.Size = new Size(205, 24);
		CB_Country.TabIndex = 13;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(313, 20);
		Label3.Name = "Label3";
		Label3.Size = new Size(74, 17);
		Label3.TabIndex = 12;
		Label3.Text = "国家：";
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(7, 20);
		Label6.Name = "Label6";
		Label6.Size = new Size(61, 17);
		Label6.TabIndex = 11;
		Label6.Text = "类别：";
		TB_Class.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Class.AutoCompleteCustomSource = null;
		TB_Class.AutoCompleteMode = AutoCompleteMode.None;
		TB_Class.AutoCompleteSource = AutoCompleteSource.None;
		TB_Class.BackColor = Color.FromArgb(69, 73, 74);
		TB_Class.Font = new Font("Segoe UI", 8f);
		TB_Class.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Class.Image = null;
		TB_Class.Lines = null;
		TB_Class.Location = new Point(111, 13);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		TB_Class.Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = ScrollBars.None;
		TB_Class.SelectionStart = 0;
		TB_Class.Size = new Size(196, 24);
		TB_Class.TabIndex = 10;
		TB_Class.TextAlign = HorizontalAlignment.Left;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(6, 45);
		Label7.Name = "Label7";
		Label7.Size = new Size(104, 20);
		Label7.TabIndex = 15;
		Label7.Text = "假想：";
		CB_SubType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_SubType.BackColor = Color.Transparent;
		CB_SubType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_SubType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_SubType.Font = new Font("Segoe UI", 7f);
		CB_SubType.FormattingEnabled = true;
		CB_SubType.Location = new Point(393, 44);
		CB_SubType.Name = "CB_SubType";
		CB_SubType.Size = new Size(205, 24);
		CB_SubType.TabIndex = 19;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(314, 48);
		Label11.Name = "Label11";
		Label11.Size = new Size(73, 17);
		Label11.TabIndex = 20;
		Label11.Text = "子类型：";
		CB_Hypothetical.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Hypothetical.BackColor = Color.Transparent;
		CB_Hypothetical.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Hypothetical.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Hypothetical.Font = new Font("Segoe UI", 7f);
		CB_Hypothetical.Location = new Point(111, 41);
		CB_Hypothetical.Name = "CB_Hypothetical";
		CB_Hypothetical.Size = new Size(196, 24);
		CB_Hypothetical.TabIndex = 16;
		DataGridView1.AllowUserToAddRows = false;
		DataGridView1.AllowUserToDeleteRows = false;
		DataGridView1.AllowUserToOrderColumns = true;
		DataGridView1.AllowUserToResizeColumns = false;
		DataGridView1.AllowUserToResizeRows = false;
		DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DataGridView1.BackgroundColor = Color.FromArgb(60, 63, 65);
		DataGridView1.BorderStyle = BorderStyle.Fixed3D;
		DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
		DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridView1.Columns.AddRange(DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, Country, IOC, Retired, CountryNumber, Column2);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(297, 145);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.ReadOnly = true;
		DataGridView1.RowHeadersVisible = false;
		DataGridView1.RowHeadersWidth = 51;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.Size = new Size(603, 481);
		DataGridView1.TabIndex = 33;
		DataGridViewTextBoxColumn1.DataPropertyName = "ID";
		DataGridViewTextBoxColumn1.HeaderText = "ID";
		DataGridViewTextBoxColumn1.MinimumWidth = 6;
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.ReadOnly = true;
		DataGridViewTextBoxColumn1.Visible = false;
		DataGridViewTextBoxColumn1.Width = 125;
		DataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		DataGridViewTextBoxColumn2.DataPropertyName = "LongName";
		DataGridViewTextBoxColumn2.HeaderText = "类型";
		DataGridViewTextBoxColumn2.MinimumWidth = 6;
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		DataGridViewTextBoxColumn2.ReadOnly = true;
		Country.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Country.DataPropertyName = "CountryString";
		Country.HeaderText = "国家";
		Country.MinimumWidth = 6;
		Country.Name = "Country";
		Country.ReadOnly = true;
		Country.Width = 87;
		IOC.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		IOC.DataPropertyName = "YearCommissioned";
		IOC.HeaderText = "从";
		IOC.MinimumWidth = 6;
		IOC.Name = "IOC";
		IOC.ReadOnly = true;
		IOC.Width = 70;
		Retired.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Retired.DataPropertyName = "YearDecommissioned";
		Retired.HeaderText = "直到";
		Retired.MinimumWidth = 6;
		Retired.Name = "Retired";
		Retired.ReadOnly = true;
		Retired.Width = 67;
		CountryNumber.DataPropertyName = "OperatorCountry";
		CountryNumber.HeaderText = "列1";
		CountryNumber.MinimumWidth = 6;
		CountryNumber.Name = "CountryNumber";
		CountryNumber.ReadOnly = true;
		CountryNumber.Visible = false;
		CountryNumber.Width = 125;
		Column2.DataPropertyName = "Name";
		Column2.HeaderText = "列2";
		Column2.MinimumWidth = 6;
		Column2.Name = "Column2";
		Column2.ReadOnly = true;
		Column2.Visible = false;
		Column2.Width = 125;
		Button_RemoveBoat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_RemoveBoat.BackColor = Color.IndianRed;
		Button_RemoveBoat.DialogResult = DialogResult.None;
		Button_RemoveBoat.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button_RemoveBoat.ForeColor = SystemColors.ControlText;
		Button_RemoveBoat.Location = new Point(190, 647);
		Button_RemoveBoat.Name = "Button_RemoveBoat";
		Button_RemoveBoat.Padding = new Padding(5);
		Button_RemoveBoat.RoundRadius = 0;
		Button_RemoveBoat.Size = new Size(100, 22);
		Button_RemoveBoat.TabIndex = 32;
		Button_RemoveBoat.Text = "删除选定";
		Quantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Quantity.Controls.Add(NUD1);
		Quantity.Controls.Add(Button2);
		Quantity.ForeColor = Color.FromArgb(220, 220, 220);
		Quantity.Location = new Point(12, 632);
		Quantity.Name = "Quantity";
		Quantity.Size = new Size(155, 41);
		Quantity.TabIndex = 31;
		Quantity.TabStop = false;
		Quantity.Text = "数量";
		NUD1.BackColor = Color.FromArgb(69, 73, 74);
		NUD1.BorderStyle = BorderStyle.FixedSingle;
		NUD1.ForeColor = Color.FromArgb(220, 220, 220);
		NUD1.Location = new Point(6, 16);
		NUD1.Maximum = new decimal(new int[4] { 99999999, 0, 0, 0 });
		NUD1.Name = "NUD1";
		NUD1.Size = new Size(74, 27);
		NUD1.TabIndex = 10;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(85, 15);
		Button2.Name = "Button2";
		Button2.Padding = new Padding(5);
		Button2.RoundRadius = 0;
		Button2.Size = new Size(65, 22);
		Button2.TabIndex = 16;
		Button2.Text = "应用";
		TB_Quantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TB_Quantity.AutoCompleteCustomSource = null;
		TB_Quantity.AutoCompleteMode = AutoCompleteMode.None;
		TB_Quantity.AutoCompleteSource = AutoCompleteSource.None;
		TB_Quantity.BackColor = Color.FromArgb(69, 73, 74);
		TB_Quantity.Font = new Font("Segoe UI", 8f);
		TB_Quantity.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Quantity.Image = null;
		TB_Quantity.Lines = null;
		TB_Quantity.Location = new Point(630, 644);
		TB_Quantity.MaxLength = 32767;
		TB_Quantity.Multiline = false;
		TB_Quantity.Name = "TB_Quantity";
		TB_Quantity.ReadOnly = false;
		TB_Quantity.ScrollBars = ScrollBars.None;
		TB_Quantity.SelectionStart = 0;
		TB_Quantity.Size = new Size(114, 20);
		TB_Quantity.TabIndex = 30;
		TB_Quantity.TextAlign = HorizontalAlignment.Left;
		TB_Quantity.UseSystemPasswordChar = false;
		TB_Quantity.WatermarkText = "";
		Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(559, 646);
		Label5.Name = "Label5";
		Label5.Size = new Size(83, 20);
		Label5.TabIndex = 29;
		Label5.Text = "数量：";
		Label5.TextAlign = ContentAlignment.MiddleRight;
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(769, 644);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.RoundRadius = 0;
		Button1.Size = new Size(111, 20);
		Button1.TabIndex = 28;
		Button1.Text = "添加所选项";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(294, 10);
		Label2.Name = "Label2";
		Label2.Size = new Size(112, 13);
		Label2.TabIndex = 25;
		Label2.Text = "要添加的船：";
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(12, 10);
		Label1.Name = "Label1";
		Label1.Size = new Size(87, 13);
		Label1.TabIndex = 24;
		Label1.Text = "目前的库存";
		ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		ListView1.Location = new Point(16, 29);
		ListView1.Name = "ListView1";
		ListView1.RelatedInfos = null;
		ListView1.Size = new Size(278, 597);
		ListView1.TabIndex = 23;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(912, 679);
		base.Controls.Add(GroupBox1);
		base.Controls.Add(DataGridView1);
		base.Controls.Add(Button_RemoveBoat);
		base.Controls.Add(Quantity);
		base.Controls.Add(TB_Quantity);
		base.Controls.Add(Label5);
		base.Controls.Add(Button1);
		base.Controls.Add(Label2);
		base.Controls.Add(Label1);
		base.Controls.Add(ListView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditBoats";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑停靠船只";
		GroupBox1.ResumeLayout(performLayout: false);
		((ISupportInitialize)DataGridView1).EndInit();
		Quantity.ResumeLayout(performLayout: false);
		((ISupportInitialize)NUD1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ConnectTemplate(object sender, EventArgs e)
	{
		ComboBox1.SelectedIndex = 0;
		MoveTemplate();
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		CB_Country.DataSource = cache_OperatorCountries_DT;
		CB_Country.DisplayMember = "Description";
		CB_Country.ValueMember = "ID";
		CB_Country.SelectedIndex = 0;
		CB_Hypothetical.Items.Clear();
		CB_Hypothetical.Items.Add("真实和假想");
		CB_Hypothetical.Items.Add("仅真实平台");
		CB_Hypothetical.Items.Add("仅假想平台");
		CB_Hypothetical.SelectedItem = RuntimeHelpers.GetObjectValue(CB_Hypothetical.Items[0]);
		InvokeTemplate();
		Text = "编辑停靠的船只" + SelectedHost.Name;
		LoginTemplate();
		AddTemplate();
	}

	private void MoveTemplate()
	{
		switch (ComboBox1.SelectedIndex)
		{
		case 0:
			_RepositoryWatcher = Client.CurrentScenario.Cache_Ships_DT.Copy();
			break;
		case 1:
			_RepositoryWatcher = Client.CurrentScenario.Cache_Subs_DT.Copy();
			break;
		case 2:
			_RepositoryWatcher = Client.CurrentScenario.Cache_GroundUnits_DT.Copy();
			break;
		}
		List<DataRow> list = new List<DataRow>();
		IEnumerator enumerator = null;
		try
		{
			enumerator = _RepositoryWatcher.Rows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				short num = Conversions.ToShort(dataRow["Length"]);
				DockFacility.DockingPhysicalSize dockingPhysicalSize_;
				if (ComboBox1.SelectedIndex == 2)
				{
					if (!DBFunctions.IsSeaworthyAmphibiousVehicle(Client.CurrentScenario, Conversions.ToInteger(dataRow["ID"])))
					{
						list.Add(dataRow);
						continue;
					}
					dockingPhysicalSize_ = DBFunctions.DisableList(num);
				}
				else
				{
					dockingPhysicalSize_ = (DockFacility.DockingPhysicalSize)Conversions.ToShort(dataRow["PhysicalSizeCode"]);
				}
				if (SelectedHost.DockingOps.CanHostThisBoat(num, dockingPhysicalSize_) != 0)
				{
					dataRow["ID"].ToString();
					list.Add(dataRow);
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
		foreach (DataRow item in list)
		{
			_RepositoryWatcher.Rows.Remove(item);
		}
		InvokeTemplate();
		if (CB_SubType.SelectedIndex > 0)
		{
			CB_SubType.SelectedIndex = 0;
			LoginTemplate();
		}
	}

	private void DeleteTemplate(object sender, FormClosingEventArgs e)
	{
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void AddTemplate()
	{
		Client.MustRefreshMainForm = true;
		ListView1.Items.Clear();
		IEnumerable<int> enumerable = (from theBoat in SelectedHost.DockingOps.EmbarkedBoats
			where theBoat.IsShip
			select theBoat.DBID).Distinct();
		IEnumerable<int> enumerable2 = (from theBoat in SelectedHost.DockingOps.EmbarkedBoats
			where theBoat.IsSubmarine
			select theBoat.DBID).Distinct();
		IEnumerable<int> enumerable3 = (from theBoat in SelectedHost.DockingOps.EmbarkedBoats
			where theBoat.IsVehicle
			select theBoat.DBID).Distinct();
		foreach (int item in enumerable)
		{
			int Local_theDBID = item;
			IEnumerable<ActiveUnit> source = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsShip & (theBoat.DBID == Local_theDBID));
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Tag = "舰船_" + Conversions.ToString(Local_theDBID);
			darkListItem.Text = Conversions.ToString(source.Count()) + "x " + source.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem);
		}
		foreach (int item2 in enumerable2)
		{
			int Local_theDBID2 = item2;
			IEnumerable<ActiveUnit> source2 = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsSubmarine & (theBoat.DBID == Local_theDBID2));
			DarkListItem darkListItem2 = new DarkListItem();
			darkListItem2.Tag = "Sub_" + Conversions.ToString(Local_theDBID2);
			darkListItem2.Text = Conversions.ToString(source2.Count()) + "x " + source2.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem2);
		}
		foreach (int item3 in enumerable3)
		{
			int Local_theDBID3 = item3;
			IEnumerable<ActiveUnit> source3 = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsVehicle & (theBoat.DBID == Local_theDBID3));
			DarkListItem darkListItem3 = new DarkListItem();
			darkListItem3.Tag = "Amphib_" + Conversions.ToString(Local_theDBID3);
			darkListItem3.Text = Conversions.ToString(source3.Count()) + "x " + source3.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem3);
		}
		Button_RemoveBoat.Visible = ListView1.SelectedIndices.Count > 0;
		Button_RemoveBoat.Enabled = Button_RemoveBoat.Visible;
	}

	private void DestroyTemplate(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			string text = ListView1.SelectedItems[0].Tag.ToString();
			int num = Conversions.ToInteger(text.Split(Conversions.ToCharArrayRankOne("_"))[1]);
			string left = text.Split(Conversions.ToCharArrayRankOne("_"))[0];
			int value;
			if (Operators.CompareString(left, "Ship", TextCompare: true) == 0)
			{
				value = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsShip & (theBoat.DBID == num)).Count();
			}
			else if (Operators.CompareString(left, "Sub", TextCompare: true) == 0)
			{
				value = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsSubmarine & (theBoat.DBID == num)).Count();
			}
			else
			{
				if (Operators.CompareString(left, "Amphib", TextCompare: true) != 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				value = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsVehicle & (theBoat.DBID == num)).Count();
			}
			NUD1.Value = new decimal(value);
		}
		Button_RemoveBoat.Visible = ListView1.SelectedItems.Count > 0;
		Button_RemoveBoat.Enabled = Button_RemoveBoat.Visible;
	}

	private void ComputeTemplate(int int_0, ref bool bool_0, string string_0 = null)
	{
		int selectedIndex = ComboBox1.SelectedIndex;
		if (Operators.CompareString(string_0, "Ship", TextCompare: true) == 0)
		{
			selectedIndex = 0;
		}
		else
		{
			if (Operators.CompareString(string_0, "Sub", TextCompare: true) == 0)
			{
				selectedIndex = 1;
				goto IL_01f2;
			}
			if (Operators.CompareString(string_0, "Amphib", TextCompare: true) == 0)
			{
				selectedIndex = 2;
				goto IL_013d;
			}
			switch (selectedIndex)
			{
			default:
				return;
			case 0:
				break;
			case 2:
				goto IL_013d;
			case 1:
				goto IL_01f2;
			}
		}
		Ship ship = Client.CurrentScenario.AddNewShip(Client.CurrentSide, int_0, "", 0.0, 0.0);
		ship.Name = ship.UnitClass + " #" + Conversions.ToString(Client.CurrentScenario.UnitsAutoIncrement);
		ActiveUnit_DockingOps dockingOps = SelectedHost.DockingOps;
		DockFacility dockFacility_ = null;
		if (dockingOps.CanHostThisBoat(ship, ref dockFacility_))
		{
			SelectedHost.DockingOps.AddThisBoat(ship);
		}
		else
		{
			Client.CurrentScenario.DeleteUnitImmediately(ship.ObjectID, bool_0: true, "Ship deleted");
			bool_0 = true;
		}
		_ = Debugger.IsAttached;
		return;
		IL_013d:
		Vehicle vehicle = Client.CurrentScenario.AddNewVehicle(Client.CurrentSide, int_0, "", 0.0, 0.0);
		vehicle.Name = vehicle.UnitClass + " #" + Conversions.ToString(Client.CurrentScenario.UnitsAutoIncrement);
		ActiveUnit_DockingOps dockingOps2 = SelectedHost.DockingOps;
		dockFacility_ = null;
		if (dockingOps2.CanHostThisBoat(vehicle, ref dockFacility_))
		{
			SelectedHost.DockingOps.AddThisBoat(vehicle);
		}
		else
		{
			Client.CurrentScenario.DeleteUnitImmediately(vehicle.ObjectID, bool_0: true, "Amphibious Vehicle deleted");
			bool_0 = true;
		}
		_ = Debugger.IsAttached;
		return;
		IL_01f2:
		Submarine submarine = Client.CurrentScenario.AddNewSubmarine(Client.CurrentSide, int_0, "", 0.0, 0.0);
		submarine.Name = submarine.UnitClass + " #" + Conversions.ToString(Client.CurrentScenario.UnitsAutoIncrement);
		ActiveUnit_DockingOps dockingOps3 = SelectedHost.DockingOps;
		dockFacility_ = null;
		if (dockingOps3.CanHostThisBoat(submarine, ref dockFacility_))
		{
			SelectedHost.DockingOps.AddThisBoat(submarine);
		}
		else
		{
			Client.CurrentScenario.DeleteUnitImmediately(submarine.ObjectID, bool_0: true, "Submarine deleted");
			bool_0 = true;
		}
		_ = Debugger.IsAttached;
	}

	private void PatchTemplate(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count == 0)
		{
			return;
		}
		int num = Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
		if (num != 10000 && num != 10001 && num != 10002 && Versioned.IsNumeric(TB_Quantity.Text))
		{
			Button1.Text = "工作中...";
			Button1.Enabled = false;
			bool bool_ = false;
			int num2 = Conversions.ToInteger(TB_Quantity.Text);
			for (int i = 1; i <= num2; i++)
			{
				ComputeTemplate(num, ref bool_);
			}
			if (bool_)
			{
				DarkMessageBox.ShowWarning("无法将所有船只添加到主机 - 超出最大停靠空间。", "空间不足！");
			}
			Button1.Text = "添加所选项";
			Button1.Enabled = true;
			AddTemplate();
		}
	}

	private void SelectTemplate(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count == 0)
		{
			return;
		}
		Button2.Text = "工作中...";
		Button2.Enabled = false;
		string text = ListView1.SelectedItems[0].Tag.ToString();
		int Local_BoatDBID = Conversions.ToInteger(text.Split(Conversions.ToCharArrayRankOne("_"))[1]);
		string text2 = text.Split(Conversions.ToCharArrayRankOne("_"))[0];
		string left = text2;
		IEnumerable<ActiveUnit> source;
		if (Operators.CompareString(left, "Ship", TextCompare: true) == 0)
		{
			source = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsShip & (theBoat.DBID == Local_BoatDBID));
		}
		else if (Operators.CompareString(left, "Sub", TextCompare: true) == 0)
		{
			source = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsSubmarine & (theBoat.DBID == Local_BoatDBID));
		}
		else
		{
			if (Operators.CompareString(left, "Amphib", TextCompare: true) != 0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			source = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsVehicle & (theBoat.DBID == Local_BoatDBID));
		}
		if (decimal.Compare(NUD1.Value, new decimal(source.Count())) < 0)
		{
			int num = source.Count() - 1;
			int num2 = Convert.ToInt32(NUD1.Value);
			for (int i = num; i >= num2; i += -1)
			{
				Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(i).ObjectID, bool_0: true, "Unit deleted");
			}
		}
		bool bool_ = false;
		if (decimal.Compare(NUD1.Value, new decimal(source.Count())) > 0)
		{
			source.Select((ActiveUnit theBoat) => theBoat.DBID).ElementAtOrDefault(0);
			int num3 = source.Count() + 1;
			int num4 = Convert.ToInt32(NUD1.Value);
			for (int j = num3; j <= num4; j++)
			{
				ComputeTemplate(Local_BoatDBID, ref bool_, text2);
			}
		}
		if (bool_)
		{
			DarkMessageBox.ShowWarning("无法将所有船只添加到主机 - 超出最大停靠空间。", "空间不足！");
		}
		Button2.Text = "应用";
		Button2.Enabled = true;
		AddTemplate();
	}

	private void CallTemplate(object sender, EventArgs e)
	{
		string text = ListView1.SelectedItems[0].Tag.ToString();
		int Local_BoatDBID = Conversions.ToInteger(text.Split('_')[1]);
		string left = text.Split('_')[0];
		IEnumerable<ActiveUnit> source;
		if (Operators.CompareString(left, "Ship", TextCompare: true) == 0)
		{
			source = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsShip & (theBoat.DBID == Local_BoatDBID));
		}
		else if (Operators.CompareString(left, "Sub", TextCompare: true) == 0)
		{
			source = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsSubmarine & (theBoat.DBID == Local_BoatDBID));
		}
		else
		{
			if (Operators.CompareString(left, "Amphib", TextCompare: true) != 0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return;
			}
			source = SelectedHost.DockingOps.EmbarkedBoats.Where((ActiveUnit theBoat) => theBoat.IsVehicle & (theBoat.DBID == Local_BoatDBID));
		}
		for (int i = source.Count() - 1; i >= 0; i += -1)
		{
			Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(i).ObjectID, bool_0: true, "Unit deleted");
		}
		ComboBox1.SelectedIndex = 0;
		InvokeTemplate();
		LoginTemplate();
		MoveTemplate();
		AddTemplate();
	}

	private void LogoutTemplate(object sender, KeyPressEventArgs e)
	{
		DataView dataView = new DataView(_RepositoryWatcher);
		dataView.Sort = "Name ASC";
		dataView.RowFilter = "Name LIKE '" + Conversions.ToString(e.KeyChar) + "%'";
		if (dataView.Count <= 0)
		{
			return;
		}
		int num = Conversions.ToInteger(dataView[0][0]);
		IEnumerator enumerator = null;
		int firstDisplayedScrollingRowIndex = 0;
		try
		{
			enumerator = ((IEnumerable)DataGridView1.Rows).GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (Conversions.ToInteger(dataGridViewRow.Cells[0].Value) == num)
				{
					firstDisplayedScrollingRowIndex = dataGridViewRow.Index;
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
		DataGridView1.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
	}

	private void ViewTemplate()
	{
		DataView dataView = new DataView(_RepositoryWatcher);
		dataView.Sort = "Name ASC";
		DataGridView1.DataSource = dataView;
	}

	private void ValidateTemplate(object object_0)
	{
		if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0)
		{
			LoginTemplate();
		}
	}

	private void LoginTemplate()
	{
		DataView dataView = new DataView(_RepositoryWatcher);
		dataView.Sort = "Name ASC";
		if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0 || CB_Country.SelectedIndex != 0 || CB_Hypothetical.SelectedIndex != 0 || CB_SubType.SelectedIndex != 0)
		{
			string text = "1=1 ";
			if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0)
			{
				string text2 = TB_Class.Text.Replace("'", "''");
				text = text + " AND Name LIKE '%" + text2 + "%' ";
			}
			if (CB_Country.SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + CB_Country.SelectedValue.ToString();
			}
			if (CB_Hypothetical.SelectedIndex == 1)
			{
				text += " AND Hypothetical=FALSE";
			}
			else if (CB_Hypothetical.SelectedIndex == 2)
			{
				text += " AND Hypothetical=TRUE";
			}
			if (CB_SubType.SelectedIndex > 0)
			{
				text = text + " AND type=" + CB_SubType.SelectedValue.ToString();
			}
			text = text.Replace("[", "[[");
			text = text.Replace("]", "]]");
			text = text.Replace("[[", "[[]");
			string text5 = (dataView.RowFilter = text.Replace("]]", "[]]"));
			string text3 = text5;
			text = text3;
		}
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	private void GetTemplate(object sender, EventArgs e)
	{
		MoveTemplate();
		LoginTemplate();
	}

	private void WriteTemplate(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void NewTemplate(object sender, EventArgs e)
	{
		LoginTemplate();
	}

	private void PushTemplate(object sender, EventArgs e)
	{
		if (CB_Hypothetical.Items.Count != 0 && CB_Country.Items.Count != 0)
		{
			LoginTemplate();
		}
	}

	private void InvokeTemplate()
	{
		DataTable dataTable = new DataTable();
		if (!dataTable.Columns.Contains("ID"))
		{
			dataTable.Columns.Add("ID", typeof(int));
		}
		if (!dataTable.Columns.Contains("Description"))
		{
			dataTable.Columns.Add("Description", typeof(string));
		}
		dataTable.Rows.Clear();
		switch (ComboBox1.SelectedIndex)
		{
		case 0:
		{
			int num3 = 0;
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = Enum.GetValues(typeof(Ship._ShipType)).GetEnumerator();
				while (enumerator3.MoveNext())
				{
					Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(enumerator3.Current);
					string text3 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
					Misc.Description(shipType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(shipType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)shipType, shipType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)shipType, text3);
					}
					num3++;
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
		}
		case 1:
		{
			int num2 = 0;
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = Enum.GetValues(typeof(Submarine._SubmarineType)).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(enumerator2.Current);
					string text2 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(submarineType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)submarineType, submarineType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)submarineType, text2);
					}
					num2++;
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
		}
		case 2:
		{
			int num = 0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)).GetEnumerator();
				while (enumerator.MoveNext())
				{
					IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(enumerator.Current);
					string text = Misc.ToEnglishString(mobileUnitCategory);
					if (string.IsNullOrEmpty(text))
					{
						dataTable.Rows.Add((int)mobileUnitCategory, mobileUnitCategory.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)mobileUnitCategory, text);
					}
					num++;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			break;
		}
		}
		if (dataTable.Rows.Count <= 0)
		{
			dataTable.Rows.Add(0, "None");
			DarkUIComboBox cB_SubType = CB_SubType;
			cB_SubType.DataSource = dataTable;
			cB_SubType.DisplayMember = "Description";
			cB_SubType.ValueMember = "ID";
			cB_SubType.SelectedIndex = 0;
			cB_SubType.Enabled = false;
			cB_SubType.Visible = false;
		}
		else
		{
			DarkUIComboBox cB_SubType2 = CB_SubType;
			cB_SubType2.DataSource = dataTable;
			cB_SubType2.DisplayMember = "Description";
			cB_SubType2.ValueMember = "ID";
			cB_SubType2.SelectedIndex = 0;
			cB_SubType2.Enabled = true;
			cB_SubType2.Visible = true;
		}
	}

	private void SetupTemplate(object sender, EventArgs e)
	{
		LoginTemplate();
	}

	private void ExcludeTemplate(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1)
		{
			return;
		}
		int num = Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
		if (num != 10000 && num != 10001 && num != 10002)
		{
			switch (ComboBox1.SelectedIndex)
			{
			case 0:
				Client.smethod_0("Ship", num);
				break;
			case 1:
				Client.smethod_0("Submarine", num);
				break;
			case 2:
				Client.smethod_0("地面单元", num);
				break;
			}
		}
	}
}
