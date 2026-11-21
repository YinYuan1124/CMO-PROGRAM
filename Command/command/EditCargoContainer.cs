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
public class EditCargoContainer : DarkSecondaryFormBase
{
	private class RepositoryProcessProducer
	{
		[CompilerGenerated]
		private string tokenizerMap;

		[CompilerGenerated]
		private int m_StubMap;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return tokenizerMap;
			}
			[CompilerGenerated]
			set
			{
				tokenizerMap = value;
			}
		}

		public int ID
		{
			[CompilerGenerated]
			get
			{
				return m_StubMap;
			}
			[CompilerGenerated]
			set
			{
				m_StubMap = value;
			}
		}

		public RepositoryProcessProducer(string string_0, int int_0)
		{
			Name = string_0;
			ID = int_0;
		}
	}

	private IContainer m_DescriptorWatcher;

	[AccessedThroughProperty("DarkSectionPanel1")]
	[CompilerGenerated]
	private DarkSectionPanel taskWatcher;

	[AccessedThroughProperty("CrewBar")]
	[CompilerGenerated]
	private DarkUIProgressBar m_FilterWatcher;

	[AccessedThroughProperty("AreaBar")]
	[CompilerGenerated]
	private DarkUIProgressBar m_TestsWatcher;

	[AccessedThroughProperty("MassBar")]
	[CompilerGenerated]
	private DarkUIProgressBar m_InterpreterWatcher;

	[AccessedThroughProperty("InventoryGridView")]
	[CompilerGenerated]
	private DarkDataGridView composerWatcher;

	[AccessedThroughProperty("InvColName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn modelWatcher;

	[AccessedThroughProperty("InvColArea")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn customerWatcher;

	[AccessedThroughProperty("InvColCrew")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn serializerWatcher;

	[AccessedThroughProperty("RemoveButton")]
	[CompilerGenerated]
	private DarkUIButton m_RefWatcher;

	[AccessedThroughProperty("RemoveCounter")]
	[CompilerGenerated]
	private DarkNumericUpDown errorWatcher;

	[AccessedThroughProperty("ContentsSourceTabControl")]
	[CompilerGenerated]
	private DarkUITabControl m_ConnectionWatcher;

	[AccessedThroughProperty("AmmunitionTab")]
	[CompilerGenerated]
	private TabPage statusWatcher;

	[AccessedThroughProperty("DBGrid")]
	[CompilerGenerated]
	private DarkDataGridView _ProccesorWatcher;

	[AccessedThroughProperty("AddButton")]
	[CompilerGenerated]
	private DarkUIButton strategyWatcher;

	[AccessedThroughProperty("AddCounter")]
	[CompilerGenerated]
	private DarkNumericUpDown configurationWatcher;

	[AccessedThroughProperty("UserDefinedTab")]
	[CompilerGenerated]
	private TabPage tokenWatcher;

	[AccessedThroughProperty("FuelTrackBar")]
	[CompilerGenerated]
	private TrackBar m_ResolverWatcher;

	[AccessedThroughProperty("Label_FuelSlider")]
	[CompilerGenerated]
	private DarkLabel publisherWatcher;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel serverWatcher;

	[AccessedThroughProperty("FuelTypeComboBox")]
	[CompilerGenerated]
	private DarkUIComboBox m_AdapterWatcher;

	[AccessedThroughProperty("FuelVolumeMaxLabel")]
	[CompilerGenerated]
	private DarkLabel singletonWatcher;

	[AccessedThroughProperty("UserContentLengthTextbox")]
	[CompilerGenerated]
	private DarkUITextBox m_ExceptionWatcher;

	[AccessedThroughProperty("UserContentCargoSizeLabel")]
	[CompilerGenerated]
	private DarkLabel attrWatcher;

	[AccessedThroughProperty("DarkLabel9")]
	[CompilerGenerated]
	private DarkLabel visitorWatcher;

	[AccessedThroughProperty("DarkLabel3")]
	[CompilerGenerated]
	private DarkLabel comparatorWatcher;

	[AccessedThroughProperty("UserContentMassTextbox")]
	[CompilerGenerated]
	private DarkUITextBox m_ItemWatcher;

	[AccessedThroughProperty("UserContentHeightTextBox")]
	[CompilerGenerated]
	private DarkUITextBox _SetterWatcher;

	[AccessedThroughProperty("UserContentWidthTextBox")]
	[CompilerGenerated]
	private DarkUITextBox creatorWatcher;

	[AccessedThroughProperty("LabelCustomAreaUnits")]
	[CompilerGenerated]
	private DarkLabel m_MappingWatcher;

	[AccessedThroughProperty("FuelMassLabel")]
	[CompilerGenerated]
	private DarkLabel tagWatcher;

	[AccessedThroughProperty("FuelVolumeLabel")]
	[CompilerGenerated]
	private DarkLabel fieldWatcher;

	[AccessedThroughProperty("LabelFuelVolumeUnits")]
	[CompilerGenerated]
	private DarkLabel queueWatcher;

	public ActiveUnit SelectedActiveUnit;

	public CargoContainer SelectedContainer;

	private ICargoHost _RegWatcher;

	private float m_ParamWatcher;

	private float _PageWatcher;

	private float _RulesWatcher;

	private float methodWatcher;

	private CargoContainerContent _ServiceWatcher;

	private bool m_SystemWatcher;

	private Keys[] candidateWatcher;

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkSectionPanel DarkSectionPanel1
	{
		[CompilerGenerated]
		get
		{
			return taskWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			taskWatcher = value;
		}
	}

	internal virtual DarkUIProgressBar CrewBar
	{
		[CompilerGenerated]
		get
		{
			return m_FilterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FilterWatcher = value;
		}
	}

	internal virtual DarkUIProgressBar AreaBar
	{
		[CompilerGenerated]
		get
		{
			return m_TestsWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TestsWatcher = value;
		}
	}

	internal virtual DarkUIProgressBar MassBar
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterpreterWatcher = value;
		}
	}

	[field: AccessedThroughProperty("SizeLabel")]
	internal virtual DarkLabel SizeLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkDataGridView InventoryGridView
	{
		[CompilerGenerated]
		get
		{
			return composerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareMapping;
			DarkDataGridView darkDataGridView = composerWatcher;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged -= value2;
			}
			composerWatcher = value;
			darkDataGridView = composerWatcher;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridViewTextBoxColumn InvColName
	{
		[CompilerGenerated]
		get
		{
			return modelWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelWatcher = value;
		}
	}

	[field: AccessedThroughProperty("InvColMass")]
	internal virtual DataGridViewTextBoxColumn InvColMass
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DataGridViewTextBoxColumn InvColArea
	{
		[CompilerGenerated]
		get
		{
			return customerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			customerWatcher = value;
		}
	}

	internal virtual DataGridViewTextBoxColumn InvColCrew
	{
		[CompilerGenerated]
		get
		{
			return serializerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerWatcher = value;
		}
	}

	internal virtual DarkUIButton RemoveButton
	{
		[CompilerGenerated]
		get
		{
			return m_RefWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertMapping;
			DarkUIButton refWatcher = m_RefWatcher;
			if (refWatcher != null)
			{
				refWatcher.Click -= value2;
			}
			m_RefWatcher = value;
			refWatcher = m_RefWatcher;
			if (refWatcher != null)
			{
				refWatcher.Click += value2;
			}
		}
	}

	internal virtual DarkNumericUpDown RemoveCounter
	{
		[CompilerGenerated]
		get
		{
			return errorWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			errorWatcher = value;
		}
	}

	[field: AccessedThroughProperty("DarkSectionPanel2")]
	internal virtual DarkSectionPanel DarkSectionPanel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUITabControl ContentsSourceTabControl
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateMapping;
			DarkUITabControl connectionWatcher = m_ConnectionWatcher;
			if (connectionWatcher != null)
			{
				connectionWatcher.SelectedIndexChanged -= value2;
			}
			m_ConnectionWatcher = value;
			connectionWatcher = m_ConnectionWatcher;
			if (connectionWatcher != null)
			{
				connectionWatcher.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("FuelTab")]
	internal virtual TabPage FuelTab
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TabPage AmmunitionTab
	{
		[CompilerGenerated]
		get
		{
			return statusWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			statusWatcher = value;
		}
	}

	internal virtual DarkDataGridView DBGrid
	{
		[CompilerGenerated]
		get
		{
			return _ProccesorWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateMapping;
			DarkDataGridView proccesorWatcher = _ProccesorWatcher;
			if (proccesorWatcher != null)
			{
				proccesorWatcher.SelectionChanged -= value2;
			}
			_ProccesorWatcher = value;
			proccesorWatcher = _ProccesorWatcher;
			if (proccesorWatcher != null)
			{
				proccesorWatcher.SelectionChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton AddButton
	{
		[CompilerGenerated]
		get
		{
			return strategyWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareMapping;
			DarkUIButton darkUIButton = strategyWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			strategyWatcher = value;
			darkUIButton = strategyWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkNumericUpDown AddCounter
	{
		[CompilerGenerated]
		get
		{
			return configurationWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationWatcher = value;
		}
	}

	internal virtual TabPage UserDefinedTab
	{
		[CompilerGenerated]
		get
		{
			return tokenWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenWatcher = value;
		}
	}

	[field: AccessedThroughProperty("LabelFuelMassUnits")]
	internal virtual DarkLabel LabelFuelMassUnits
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TrackBar FuelTrackBar
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitMapping;
			TrackBar resolverWatcher = m_ResolverWatcher;
			if (resolverWatcher != null)
			{
				resolverWatcher.ValueChanged -= value2;
			}
			m_ResolverWatcher = value;
			resolverWatcher = m_ResolverWatcher;
			if (resolverWatcher != null)
			{
				resolverWatcher.ValueChanged += value2;
			}
		}
	}

	internal virtual DarkLabel Label_FuelSlider
	{
		[CompilerGenerated]
		get
		{
			return publisherWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherWatcher = value;
		}
	}

	internal virtual DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return serverWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverWatcher = value;
		}
	}

	internal virtual DarkUIComboBox FuelTypeComboBox
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartMapping;
			DarkUIComboBox adapterWatcher = m_AdapterWatcher;
			if (adapterWatcher != null)
			{
				adapterWatcher.SelectedIndexChanged -= value2;
			}
			m_AdapterWatcher = value;
			adapterWatcher = m_AdapterWatcher;
			if (adapterWatcher != null)
			{
				adapterWatcher.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("UserContentNameTextBox")]
	internal virtual DarkUITextBox UserContentNameTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel7")]
	internal virtual DarkLabel DarkLabel7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel FuelVolumeMaxLabel
	{
		[CompilerGenerated]
		get
		{
			return singletonWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			singletonWatcher = value;
		}
	}

	[field: AccessedThroughProperty("FuelVolumeMinLabel")]
	internal virtual DarkLabel FuelVolumeMinLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUITextBox UserContentLengthTextbox
	{
		[CompilerGenerated]
		get
		{
			return m_ExceptionWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestMapping;
			DarkUITextBox exceptionWatcher = m_ExceptionWatcher;
			if (exceptionWatcher != null)
			{
				exceptionWatcher.LostFocus -= value2;
			}
			m_ExceptionWatcher = value;
			exceptionWatcher = m_ExceptionWatcher;
			if (exceptionWatcher != null)
			{
				exceptionWatcher.LostFocus += value2;
			}
		}
	}

	internal virtual DarkLabel UserContentCargoSizeLabel
	{
		[CompilerGenerated]
		get
		{
			return attrWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			attrWatcher = value;
		}
	}

	internal virtual DarkLabel DarkLabel9
	{
		[CompilerGenerated]
		get
		{
			return visitorWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			visitorWatcher = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel8")]
	internal virtual DarkLabel DarkLabel8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel DarkLabel3
	{
		[CompilerGenerated]
		get
		{
			return comparatorWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			comparatorWatcher = value;
		}
	}

	internal virtual DarkUITextBox UserContentMassTextbox
	{
		[CompilerGenerated]
		get
		{
			return m_ItemWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ItemWatcher = value;
		}
	}

	internal virtual DarkUITextBox UserContentHeightTextBox
	{
		[CompilerGenerated]
		get
		{
			return _SetterWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelMapping;
			DarkUITextBox setterWatcher = _SetterWatcher;
			if (setterWatcher != null)
			{
				setterWatcher.LostFocus -= value2;
			}
			_SetterWatcher = value;
			setterWatcher = _SetterWatcher;
			if (setterWatcher != null)
			{
				setterWatcher.LostFocus += value2;
			}
		}
	}

	internal virtual DarkUITextBox UserContentWidthTextBox
	{
		[CompilerGenerated]
		get
		{
			return creatorWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopMapping;
			DarkUITextBox darkUITextBox = creatorWatcher;
			if (darkUITextBox != null)
			{
				darkUITextBox.LostFocus -= value2;
			}
			creatorWatcher = value;
			darkUITextBox = creatorWatcher;
			if (darkUITextBox != null)
			{
				darkUITextBox.LostFocus += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelCustomMassUnits")]
	internal virtual DarkLabel LabelCustomMassUnits
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel LabelCustomAreaUnits
	{
		[CompilerGenerated]
		get
		{
			return m_MappingWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingWatcher = value;
		}
	}

	[field: AccessedThroughProperty("FuelWarningLabel")]
	internal virtual DarkLabel FuelWarningLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel FuelMassLabel
	{
		[CompilerGenerated]
		get
		{
			return tagWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tagWatcher = value;
		}
	}

	internal virtual DarkLabel FuelVolumeLabel
	{
		[CompilerGenerated]
		get
		{
			return fieldWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fieldWatcher = value;
		}
	}

	internal virtual DarkLabel LabelFuelVolumeUnits
	{
		[CompilerGenerated]
		get
		{
			return queueWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			queueWatcher = value;
		}
	}

	public EditCargoContainer()
	{
		base.Load += InterruptMapping;
		base.Shown += RemoveMapping;
		base.FormClosing += FindMapping;
		_ServiceWatcher = new CargoContainerContent();
		m_SystemWatcher = false;
		candidateWatcher = new Keys[1] { Keys.Escape };
		ConcatMapping();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_DescriptorWatcher != null)
			{
				m_DescriptorWatcher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ConcatMapping()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		TableLayoutPanel1 = new TableLayoutPanel();
		DarkSectionPanel1 = new DarkSectionPanel();
		CrewBar = new DarkUIProgressBar();
		AreaBar = new DarkUIProgressBar();
		MassBar = new DarkUIProgressBar();
		SizeLabel = new DarkLabel();
		InventoryGridView = new DarkDataGridView();
		InvColName = new DataGridViewTextBoxColumn();
		InvColMass = new DataGridViewTextBoxColumn();
		InvColArea = new DataGridViewTextBoxColumn();
		InvColCrew = new DataGridViewTextBoxColumn();
		RemoveButton = new DarkUIButton();
		RemoveCounter = new DarkNumericUpDown();
		DarkSectionPanel2 = new DarkSectionPanel();
		ContentsSourceTabControl = new DarkUITabControl();
		AmmunitionTab = new TabPage();
		DBGrid = new DarkDataGridView();
		FuelTab = new TabPage();
		FuelVolumeLabel = new DarkLabel();
		LabelFuelVolumeUnits = new DarkLabel();
		FuelWarningLabel = new DarkLabel();
		FuelMassLabel = new DarkLabel();
		FuelVolumeMaxLabel = new DarkLabel();
		FuelVolumeMinLabel = new DarkLabel();
		LabelFuelMassUnits = new DarkLabel();
		FuelTrackBar = new TrackBar();
		Label_FuelSlider = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		FuelTypeComboBox = new DarkUIComboBox();
		UserDefinedTab = new TabPage();
		LabelCustomAreaUnits = new DarkLabel();
		LabelCustomMassUnits = new DarkLabel();
		UserContentMassTextbox = new DarkUITextBox();
		UserContentHeightTextBox = new DarkUITextBox();
		UserContentWidthTextBox = new DarkUITextBox();
		UserContentLengthTextbox = new DarkUITextBox();
		UserContentCargoSizeLabel = new DarkLabel();
		DarkLabel9 = new DarkLabel();
		DarkLabel8 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		UserContentNameTextBox = new DarkUITextBox();
		DarkLabel6 = new DarkLabel();
		DarkLabel7 = new DarkLabel();
		AddButton = new DarkUIButton();
		AddCounter = new DarkNumericUpDown();
		TableLayoutPanel1.SuspendLayout();
		DarkSectionPanel1.SuspendLayout();
		((ISupportInitialize)InventoryGridView).BeginInit();
		((ISupportInitialize)RemoveCounter).BeginInit();
		DarkSectionPanel2.SuspendLayout();
		ContentsSourceTabControl.SuspendLayout();
		AmmunitionTab.SuspendLayout();
		((ISupportInitialize)DBGrid).BeginInit();
		FuelTab.SuspendLayout();
		((ISupportInitialize)FuelTrackBar).BeginInit();
		UserDefinedTab.SuspendLayout();
		((ISupportInitialize)AddCounter).BeginInit();
		SuspendLayout();
		TableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 306f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 700f));
		TableLayoutPanel1.Controls.Add(DarkSectionPanel1, 0, 0);
		TableLayoutPanel1.Controls.Add(DarkSectionPanel2, 1, 0);
		TableLayoutPanel1.Location = new Point(0, 0);
		TableLayoutPanel1.Margin = new Padding(0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel1.Size = new Size(1008, 464);
		TableLayoutPanel1.TabIndex = 9;
		DarkSectionPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DarkSectionPanel1.Controls.Add(CrewBar);
		DarkSectionPanel1.Controls.Add(AreaBar);
		DarkSectionPanel1.Controls.Add(MassBar);
		DarkSectionPanel1.Controls.Add(SizeLabel);
		DarkSectionPanel1.Controls.Add(InventoryGridView);
		DarkSectionPanel1.Controls.Add(RemoveButton);
		DarkSectionPanel1.Controls.Add(RemoveCounter);
		DarkSectionPanel1.Location = new Point(0, 0);
		DarkSectionPanel1.Margin = new Padding(0);
		DarkSectionPanel1.Name = "DarkSectionPanel1";
		DarkSectionPanel1.SectionHeader = "Current Contents:";
		DarkSectionPanel1.Size = new Size(306, 464);
		DarkSectionPanel1.TabIndex = 0;
		CrewBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		CrewBar.BackColor = Color.Transparent;
		CrewBar.CustomForeColor = Color.Transparent;
		CrewBar.Location = new Point(8, 412);
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
		AreaBar.Location = new Point(8, 389);
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
		MassBar.Location = new Point(8, 366);
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
		SizeLabel.Location = new Point(8, 343);
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
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		InventoryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		InventoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		InventoryGridView.Columns.AddRange(InvColName, InvColMass, InvColArea, InvColCrew);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		InventoryGridView.DefaultCellStyle = dataGridViewCellStyle2;
		InventoryGridView.EnableHeadersVisualStyles = false;
		InventoryGridView.Location = new Point(0, 28);
		InventoryGridView.Name = "InventoryGridView";
		InventoryGridView.ReadOnly = true;
		InventoryGridView.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		InventoryGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
		InventoryGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		InventoryGridView.Size = new Size(306, 307);
		InventoryGridView.TabIndex = 12;
		InvColName.HeaderText = "名称";
		InvColName.Name = "InvColName";
		InvColName.ReadOnly = true;
		InvColName.SortMode = DataGridViewColumnSortMode.NotSortable;
		InvColName.Width = 162;
		InvColMass.HeaderText = "Mass";
		InvColMass.Name = "InvColMass";
		InvColMass.ReadOnly = true;
		InvColMass.Width = 48;
		InvColArea.HeaderText = "区域";
		InvColArea.Name = "InvColArea";
		InvColArea.ReadOnly = true;
		InvColArea.Width = 48;
		InvColCrew.HeaderText = "PAX";
		InvColCrew.Name = "InvColCrew";
		InvColCrew.ReadOnly = true;
		InvColCrew.Width = 36;
		RemoveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		RemoveButton.BackColor = Color.Transparent;
		RemoveButton.DialogResult = DialogResult.None;
		RemoveButton.ForeColor = SystemColors.Control;
		RemoveButton.Location = new Point(82, 438);
		RemoveButton.Name = "RemoveButton";
		RemoveButton.Padding = new Padding(5);
		RemoveButton.RoundRadius = 0;
		RemoveButton.Size = new Size(124, 23);
		RemoveButton.TabIndex = 2;
		RemoveButton.Text = "删除选定";
		RemoveCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		RemoveCounter.BackColor = Color.FromArgb(43, 43, 43);
		RemoveCounter.BorderStyle = BorderStyle.None;
		RemoveCounter.Font = new Font("Segoe UI", 12f);
		RemoveCounter.ForeColor = Color.FromArgb(220, 220, 220);
		RemoveCounter.Location = new Point(24, 436);
		RemoveCounter.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		RemoveCounter.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		RemoveCounter.Name = "RemoveCounter";
		RemoveCounter.Size = new Size(54, 25);
		RemoveCounter.TabIndex = 3;
		RemoveCounter.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		DarkSectionPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DarkSectionPanel2.Controls.Add(ContentsSourceTabControl);
		DarkSectionPanel2.Controls.Add(AddButton);
		DarkSectionPanel2.Controls.Add(AddCounter);
		DarkSectionPanel2.Location = new Point(306, 0);
		DarkSectionPanel2.Margin = new Padding(0);
		DarkSectionPanel2.Name = "DarkSectionPanel2";
		DarkSectionPanel2.SectionHeader = "Available Contents:";
		DarkSectionPanel2.Size = new Size(702, 464);
		DarkSectionPanel2.TabIndex = 1;
		ContentsSourceTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ContentsSourceTabControl.Controls.Add(AmmunitionTab);
		ContentsSourceTabControl.Controls.Add(FuelTab);
		ContentsSourceTabControl.Controls.Add(UserDefinedTab);
		ContentsSourceTabControl.Cursor = Cursors.Hand;
		ContentsSourceTabControl.ItemSize = new Size(80, 20);
		ContentsSourceTabControl.Location = new Point(4, 28);
		ContentsSourceTabControl.Name = "ContentsSourceTabControl";
		ContentsSourceTabControl.SelectedIndex = 0;
		ContentsSourceTabControl.Size = new Size(638, 401);
		ContentsSourceTabControl.TabIndex = 4;
		AmmunitionTab.BackColor = Color.FromArgb(60, 63, 65);
		AmmunitionTab.Controls.Add(DBGrid);
		AmmunitionTab.Location = new Point(4, 24);
		AmmunitionTab.Name = "AmmunitionTab";
		AmmunitionTab.Padding = new Padding(3);
		AmmunitionTab.Size = new Size(630, 373);
		AmmunitionTab.TabIndex = 0;
		AmmunitionTab.Text = "Munitions";
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
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		DBGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		DBGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f);
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
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		DBGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
		DBGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DBGrid.Size = new Size(627, 413);
		DBGrid.TabIndex = 0;
		FuelTab.BackColor = Color.FromArgb(60, 63, 65);
		FuelTab.Controls.Add(FuelVolumeLabel);
		FuelTab.Controls.Add(LabelFuelVolumeUnits);
		FuelTab.Controls.Add(FuelWarningLabel);
		FuelTab.Controls.Add(FuelMassLabel);
		FuelTab.Controls.Add(FuelVolumeMaxLabel);
		FuelTab.Controls.Add(FuelVolumeMinLabel);
		FuelTab.Controls.Add(LabelFuelMassUnits);
		FuelTab.Controls.Add(FuelTrackBar);
		FuelTab.Controls.Add(Label_FuelSlider);
		FuelTab.Controls.Add(DarkLabel1);
		FuelTab.Controls.Add(FuelTypeComboBox);
		FuelTab.Location = new Point(4, 24);
		FuelTab.Name = "FuelTab";
		FuelTab.Padding = new Padding(3);
		FuelTab.Size = new Size(630, 373);
		FuelTab.TabIndex = 1;
		FuelTab.Text = "燃料";
		FuelVolumeLabel.ForeColor = Color.FromArgb(220, 220, 220);
		FuelVolumeLabel.Location = new Point(133, 116);
		FuelVolumeLabel.Name = "FuelVolumeLabel";
		FuelVolumeLabel.Size = new Size(89, 15);
		FuelVolumeLabel.TabIndex = 13;
		FuelVolumeLabel.Text = "0";
		FuelVolumeLabel.TextAlign = ContentAlignment.MiddleRight;
		LabelFuelVolumeUnits.AutoSize = true;
		LabelFuelVolumeUnits.ForeColor = Color.FromArgb(220, 220, 220);
		LabelFuelVolumeUnits.Location = new Point(228, 116);
		LabelFuelVolumeUnits.Name = "LabelFuelVolumeUnits";
		LabelFuelVolumeUnits.Size = new Size(32, 15);
		LabelFuelVolumeUnits.TabIndex = 12;
		LabelFuelVolumeUnits.Text = "liters";
		FuelWarningLabel.ForeColor = Color.Red;
		FuelWarningLabel.Location = new Point(101, 161);
		FuelWarningLabel.Name = "FuelWarningLabel";
		FuelWarningLabel.Size = new Size(327, 22);
		FuelWarningLabel.TabIndex = 11;
		FuelWarningLabel.TextAlign = ContentAlignment.MiddleCenter;
		FuelMassLabel.ForeColor = Color.FromArgb(220, 220, 220);
		FuelMassLabel.Location = new Point(133, 141);
		FuelMassLabel.Name = "FuelMassLabel";
		FuelMassLabel.Size = new Size(89, 15);
		FuelMassLabel.TabIndex = 10;
		FuelMassLabel.Text = "0";
		FuelMassLabel.TextAlign = ContentAlignment.MiddleRight;
		FuelVolumeMaxLabel.ForeColor = Color.FromArgb(220, 220, 220);
		FuelVolumeMaxLabel.Location = new Point(192, 98);
		FuelVolumeMaxLabel.Name = "FuelVolumeMaxLabel";
		FuelVolumeMaxLabel.Size = new Size(200, 15);
		FuelVolumeMaxLabel.TabIndex = 9;
		FuelVolumeMaxLabel.Text = "20000";
		FuelVolumeMaxLabel.TextAlign = ContentAlignment.MiddleCenter;
		FuelVolumeMinLabel.AutoSize = true;
		FuelVolumeMinLabel.ForeColor = Color.FromArgb(220, 220, 220);
		FuelVolumeMinLabel.Location = new Point(101, 98);
		FuelVolumeMinLabel.Name = "FuelVolumeMinLabel";
		FuelVolumeMinLabel.Size = new Size(13, 15);
		FuelVolumeMinLabel.TabIndex = 8;
		FuelVolumeMinLabel.Text = "0";
		FuelVolumeMinLabel.TextAlign = ContentAlignment.MiddleCenter;
		LabelFuelMassUnits.AutoSize = true;
		LabelFuelMassUnits.ForeColor = Color.FromArgb(220, 220, 220);
		LabelFuelMassUnits.Location = new Point(228, 141);
		LabelFuelMassUnits.Name = "LabelFuelMassUnits";
		LabelFuelMassUnits.Size = new Size(59, 15);
		LabelFuelMassUnits.TabIndex = 5;
		LabelFuelMassUnits.Text = "kilograms";
		FuelTrackBar.LargeChange = 1000;
		FuelTrackBar.Location = new Point(95, 68);
		FuelTrackBar.Maximum = 20000;
		FuelTrackBar.Name = "FuelTrackBar";
		FuelTrackBar.Size = new Size(209, 45);
		FuelTrackBar.SmallChange = 500;
		FuelTrackBar.TabIndex = 3;
		FuelTrackBar.TickFrequency = 1000;
		Label_FuelSlider.AutoSize = true;
		Label_FuelSlider.ForeColor = Color.FromArgb(220, 220, 220);
		Label_FuelSlider.Location = new Point(20, 71);
		Label_FuelSlider.Name = "Label_FuelSlider";
		Label_FuelSlider.Size = new Size(63, 15);
		Label_FuelSlider.TabIndex = 2;
		Label_FuelSlider.Text = "Fuel Liters:";
		Label_FuelSlider.TextAlign = ContentAlignment.MiddleRight;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(24, 22);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(59, 15);
		DarkLabel1.TabIndex = 1;
		DarkLabel1.Text = "Fuel Type:";
		DarkLabel1.TextAlign = ContentAlignment.MiddleRight;
		FuelTypeComboBox.BackColor = Color.Transparent;
		FuelTypeComboBox.DrawMode = DrawMode.OwnerDrawFixed;
		FuelTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		FuelTypeComboBox.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		FuelTypeComboBox.FormattingEnabled = true;
		FuelTypeComboBox.Location = new Point(95, 19);
		FuelTypeComboBox.Name = "FuelTypeComboBox";
		FuelTypeComboBox.Size = new Size(209, 21);
		FuelTypeComboBox.TabIndex = 0;
		UserDefinedTab.BackColor = Color.FromArgb(60, 63, 65);
		UserDefinedTab.Controls.Add(LabelCustomAreaUnits);
		UserDefinedTab.Controls.Add(LabelCustomMassUnits);
		UserDefinedTab.Controls.Add(UserContentMassTextbox);
		UserDefinedTab.Controls.Add(UserContentHeightTextBox);
		UserDefinedTab.Controls.Add(UserContentWidthTextBox);
		UserDefinedTab.Controls.Add(UserContentLengthTextbox);
		UserDefinedTab.Controls.Add(UserContentCargoSizeLabel);
		UserDefinedTab.Controls.Add(DarkLabel9);
		UserDefinedTab.Controls.Add(DarkLabel8);
		UserDefinedTab.Controls.Add(DarkLabel5);
		UserDefinedTab.Controls.Add(DarkLabel3);
		UserDefinedTab.Controls.Add(UserContentNameTextBox);
		UserDefinedTab.Controls.Add(DarkLabel6);
		UserDefinedTab.Controls.Add(DarkLabel7);
		UserDefinedTab.Location = new Point(4, 24);
		UserDefinedTab.Name = "UserDefinedTab";
		UserDefinedTab.Padding = new Padding(3);
		UserDefinedTab.Size = new Size(630, 373);
		UserDefinedTab.TabIndex = 2;
		UserDefinedTab.Text = "User Defined";
		LabelCustomAreaUnits.AutoSize = true;
		LabelCustomAreaUnits.ForeColor = Color.FromArgb(220, 220, 220);
		LabelCustomAreaUnits.Location = new Point(347, 72);
		LabelCustomAreaUnits.Name = "LabelCustomAreaUnits";
		LabelCustomAreaUnits.Size = new Size(43, 15);
		LabelCustomAreaUnits.TabIndex = 24;
		LabelCustomAreaUnits.Text = "meters";
		LabelCustomAreaUnits.TextAlign = ContentAlignment.MiddleLeft;
		LabelCustomMassUnits.AutoSize = true;
		LabelCustomMassUnits.ForeColor = Color.FromArgb(220, 220, 220);
		LabelCustomMassUnits.Location = new Point(161, 140);
		LabelCustomMassUnits.Name = "LabelCustomMassUnits";
		LabelCustomMassUnits.Size = new Size(59, 15);
		LabelCustomMassUnits.TabIndex = 25;
		LabelCustomMassUnits.Text = "kilograms";
		LabelCustomMassUnits.TextAlign = ContentAlignment.MiddleLeft;
		UserContentMassTextbox.AutoCompleteCustomSource = null;
		UserContentMassTextbox.AutoCompleteMode = AutoCompleteMode.None;
		UserContentMassTextbox.AutoCompleteSource = AutoCompleteSource.None;
		UserContentMassTextbox.BackColor = Color.Transparent;
		UserContentMassTextbox.ForeColor = Color.FromArgb(189, 189, 189);
		UserContentMassTextbox.Image = null;
		UserContentMassTextbox.Lines = null;
		UserContentMassTextbox.Location = new Point(112, 137);
		UserContentMassTextbox.MaxLength = 32767;
		UserContentMassTextbox.Multiline = false;
		UserContentMassTextbox.Name = "UserContentMassTextbox";
		UserContentMassTextbox.ReadOnly = false;
		UserContentMassTextbox.ScrollBars = ScrollBars.None;
		UserContentMassTextbox.SelectionStart = 0;
		UserContentMassTextbox.Size = new Size(47, 18);
		UserContentMassTextbox.TabIndex = 17;
		UserContentMassTextbox.Text = "1";
		UserContentMassTextbox.TextAlign = HorizontalAlignment.Left;
		UserContentMassTextbox.UseSystemPasswordChar = false;
		UserContentMassTextbox.WatermarkText = "";
		UserContentHeightTextBox.AutoCompleteCustomSource = null;
		UserContentHeightTextBox.AutoCompleteMode = AutoCompleteMode.None;
		UserContentHeightTextBox.AutoCompleteSource = AutoCompleteSource.None;
		UserContentHeightTextBox.BackColor = Color.Transparent;
		UserContentHeightTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		UserContentHeightTextBox.Image = null;
		UserContentHeightTextBox.Lines = null;
		UserContentHeightTextBox.Location = new Point(312, 70);
		UserContentHeightTextBox.MaxLength = 32767;
		UserContentHeightTextBox.Multiline = false;
		UserContentHeightTextBox.Name = "UserContentHeightTextBox";
		UserContentHeightTextBox.ReadOnly = false;
		UserContentHeightTextBox.ScrollBars = ScrollBars.None;
		UserContentHeightTextBox.SelectionStart = 0;
		UserContentHeightTextBox.Size = new Size(34, 18);
		UserContentHeightTextBox.TabIndex = 16;
		UserContentHeightTextBox.Text = "1";
		UserContentHeightTextBox.TextAlign = HorizontalAlignment.Left;
		UserContentHeightTextBox.UseSystemPasswordChar = false;
		UserContentHeightTextBox.WatermarkText = "";
		UserContentWidthTextBox.AutoCompleteCustomSource = null;
		UserContentWidthTextBox.AutoCompleteMode = AutoCompleteMode.None;
		UserContentWidthTextBox.AutoCompleteSource = AutoCompleteSource.None;
		UserContentWidthTextBox.BackColor = Color.Transparent;
		UserContentWidthTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		UserContentWidthTextBox.Image = null;
		UserContentWidthTextBox.Lines = null;
		UserContentWidthTextBox.Location = new Point(207, 70);
		UserContentWidthTextBox.MaxLength = 32767;
		UserContentWidthTextBox.Multiline = false;
		UserContentWidthTextBox.Name = "UserContentWidthTextBox";
		UserContentWidthTextBox.ReadOnly = false;
		UserContentWidthTextBox.ScrollBars = ScrollBars.None;
		UserContentWidthTextBox.SelectionStart = 0;
		UserContentWidthTextBox.Size = new Size(34, 18);
		UserContentWidthTextBox.TabIndex = 15;
		UserContentWidthTextBox.Text = "1";
		UserContentWidthTextBox.TextAlign = HorizontalAlignment.Left;
		UserContentWidthTextBox.UseSystemPasswordChar = false;
		UserContentWidthTextBox.WatermarkText = "";
		UserContentLengthTextbox.AutoCompleteCustomSource = null;
		UserContentLengthTextbox.AutoCompleteMode = AutoCompleteMode.None;
		UserContentLengthTextbox.AutoCompleteSource = AutoCompleteSource.None;
		UserContentLengthTextbox.BackColor = Color.Transparent;
		UserContentLengthTextbox.ForeColor = Color.FromArgb(189, 189, 189);
		UserContentLengthTextbox.Image = null;
		UserContentLengthTextbox.Lines = null;
		UserContentLengthTextbox.Location = new Point(112, 70);
		UserContentLengthTextbox.MaxLength = 32767;
		UserContentLengthTextbox.Multiline = false;
		UserContentLengthTextbox.Name = "UserContentLengthTextbox";
		UserContentLengthTextbox.ReadOnly = false;
		UserContentLengthTextbox.ScrollBars = ScrollBars.None;
		UserContentLengthTextbox.SelectionStart = 0;
		UserContentLengthTextbox.Size = new Size(34, 18);
		UserContentLengthTextbox.TabIndex = 14;
		UserContentLengthTextbox.Text = "1";
		UserContentLengthTextbox.TextAlign = HorizontalAlignment.Left;
		UserContentLengthTextbox.UseSystemPasswordChar = false;
		UserContentLengthTextbox.WatermarkText = "";
		UserContentCargoSizeLabel.AutoSize = true;
		UserContentCargoSizeLabel.ForeColor = Color.FromArgb(220, 220, 220);
		UserContentCargoSizeLabel.Location = new Point(110, 99);
		UserContentCargoSizeLabel.Name = "UserContentCargoSizeLabel";
		UserContentCargoSizeLabel.Size = new Size(36, 15);
		UserContentCargoSizeLabel.TabIndex = 23;
		UserContentCargoSizeLabel.Text = "无";
		UserContentCargoSizeLabel.TextAlign = ContentAlignment.MiddleLeft;
		DarkLabel9.AutoSize = true;
		DarkLabel9.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel9.Location = new Point(263, 72);
		DarkLabel9.Name = "DarkLabel9";
		DarkLabel9.Size = new Size(46, 15);
		DarkLabel9.TabIndex = 21;
		DarkLabel9.Text = "Height:";
		DarkLabel9.TextAlign = ContentAlignment.MiddleRight;
		DarkLabel8.AutoSize = true;
		DarkLabel8.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel8.Location = new Point(162, 72);
		DarkLabel8.Name = "DarkLabel8";
		DarkLabel8.Size = new Size(42, 15);
		DarkLabel8.TabIndex = 20;
		DarkLabel8.Text = "Width:";
		DarkLabel8.TextAlign = ContentAlignment.MiddleRight;
		DarkLabel5.AutoSize = true;
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(62, 72);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(47, 15);
		DarkLabel5.TabIndex = 19;
		DarkLabel5.Text = "Length:";
		DarkLabel5.TextAlign = ContentAlignment.MiddleRight;
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(44, 99);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(65, 15);
		DarkLabel3.TabIndex = 22;
		DarkLabel3.Text = "Cargo Size:";
		DarkLabel3.TextAlign = ContentAlignment.MiddleRight;
		UserContentNameTextBox.AutoCompleteCustomSource = null;
		UserContentNameTextBox.AutoCompleteMode = AutoCompleteMode.None;
		UserContentNameTextBox.AutoCompleteSource = AutoCompleteSource.None;
		UserContentNameTextBox.BackColor = Color.Transparent;
		UserContentNameTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		UserContentNameTextBox.Image = null;
		UserContentNameTextBox.Lines = null;
		UserContentNameTextBox.Location = new Point(112, 36);
		UserContentNameTextBox.MaxLength = 32767;
		UserContentNameTextBox.Multiline = false;
		UserContentNameTextBox.Name = "UserContentNameTextBox";
		UserContentNameTextBox.ReadOnly = false;
		UserContentNameTextBox.ScrollBars = ScrollBars.None;
		UserContentNameTextBox.SelectionStart = 0;
		UserContentNameTextBox.Size = new Size(264, 18);
		UserContentNameTextBox.TabIndex = 13;
		UserContentNameTextBox.Text = "Generic Cargo";
		UserContentNameTextBox.TextAlign = HorizontalAlignment.Left;
		UserContentNameTextBox.UseSystemPasswordChar = false;
		UserContentNameTextBox.WatermarkText = "";
		DarkLabel6.AutoSize = true;
		DarkLabel6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel6.Location = new Point(73, 139);
		DarkLabel6.Name = "DarkLabel6";
		DarkLabel6.Size = new Size(37, 15);
		DarkLabel6.TabIndex = 24;
		DarkLabel6.Text = "Mass:";
		DarkLabel6.TextAlign = ContentAlignment.MiddleRight;
		DarkLabel7.AutoSize = true;
		DarkLabel7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel7.Location = new Point(11, 36);
		DarkLabel7.Name = "DarkLabel7";
		DarkLabel7.Size = new Size(88, 15);
		DarkLabel7.TabIndex = 18;
		DarkLabel7.Text = "Content Name:";
		DarkLabel7.TextAlign = ContentAlignment.MiddleRight;
		AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		AddButton.BackColor = Color.Transparent;
		AddButton.DialogResult = DialogResult.None;
		AddButton.ForeColor = SystemColors.Control;
		AddButton.Location = new Point(312, 438);
		AddButton.Name = "AddButton";
		AddButton.Padding = new Padding(5);
		AddButton.RoundRadius = 0;
		AddButton.Size = new Size(124, 23);
		AddButton.TabIndex = 5;
		AddButton.Text = "添加所选项";
		AddCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		AddCounter.BackColor = Color.FromArgb(43, 43, 43);
		AddCounter.BorderStyle = BorderStyle.None;
		AddCounter.Font = new Font("Segoe UI", 12f);
		AddCounter.ForeColor = Color.FromArgb(220, 220, 220);
		AddCounter.Location = new Point(253, 436);
		AddCounter.Margin = new Padding(0);
		AddCounter.Maximum = new decimal(new int[4] { 9999999, 0, 0, 0 });
		AddCounter.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		AddCounter.Name = "AddCounter";
		AddCounter.Size = new Size(54, 25);
		AddCounter.TabIndex = 6;
		AddCounter.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1054, 471);
		base.Controls.Add(TableLayoutPanel1);
		base.Name = "EditCargoContainer";
		Text = "`";
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		DarkSectionPanel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)InventoryGridView).EndInit();
		((ISupportInitialize)RemoveCounter).EndInit();
		DarkSectionPanel2.ResumeLayout(performLayout: false);
		ContentsSourceTabControl.ResumeLayout(performLayout: false);
		AmmunitionTab.ResumeLayout(performLayout: false);
		((ISupportInitialize)DBGrid).EndInit();
		FuelTab.ResumeLayout(performLayout: false);
		FuelTab.PerformLayout();
		((ISupportInitialize)FuelTrackBar).EndInit();
		UserDefinedTab.ResumeLayout(performLayout: false);
		UserDefinedTab.PerformLayout();
		((ISupportInitialize)AddCounter).EndInit();
		ResumeLayout(performLayout: false);
	}

	public void UpdateDisplayedUnitsOfMeasure()
	{
		LabelFuelVolumeUnits.Text = Strings.StrConv(Cargo.CargoLiquidVolumeLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), VbStrConv.ProperCase);
		LabelFuelMassUnits.Text = Strings.StrConv(Cargo.CargoSmallMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), VbStrConv.ProperCase);
		LabelCustomAreaUnits.Text = Strings.StrConv(Cargo.CargoDistanceLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), VbStrConv.ProperCase);
		LabelCustomMassUnits.Text = Strings.StrConv(Cargo.CargoSmallMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo), VbStrConv.ProperCase);
		Label_FuelSlider.Text = "Fuel " + Cargo.CargoLiquidVolumeLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = candidateWatcher;
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

	private void InterruptMapping(object sender, EventArgs e)
	{
		FuelTypeComboBox.Items.Clear();
		FuelTypeComboBox.Items.Add(new RepositoryProcessProducer("Aviation Fuel", 2001));
		FuelTypeComboBox.Items.Add(new RepositoryProcessProducer("Diesel", 3001));
		FuelTypeComboBox.Items.Add(new RepositoryProcessProducer("Oil Fuel", 3002));
		FuelTypeComboBox.Items.Add(new RepositoryProcessProducer("Gas Fuel", 3003));
		FuelTypeComboBox.Items.Add(new RepositoryProcessProducer("Gasoline", 3006));
		FuelTypeComboBox.DisplayMember = "Name";
		FuelTypeComboBox.ValueMember = "ID";
		FuelTypeComboBox.SelectedIndex = 0;
	}

	private void RemoveMapping(object sender, EventArgs e)
	{
		_RegWatcher = SelectedContainer;
		Text = "Edit Contents for " + SelectedContainer.Name;
		if (SelectedContainer.ContainerType == CargoContainer.CargoContainerType.Tank)
		{
			FuelTab.Enabled = true;
			AmmunitionTab.Enabled = false;
			UserDefinedTab.Enabled = false;
			ContentsSourceTabControl.SelectedIndex = 1;
		}
		else
		{
			FuelTab.Enabled = false;
			AmmunitionTab.Enabled = true;
			UserDefinedTab.Enabled = true;
			if (ContentsSourceTabControl.SelectedIndex == 1)
			{
				ContentsSourceTabControl.SelectedIndex = 0;
			}
			if (DBGrid.DataSource == null)
			{
				UpdateMapping(null, null);
			}
		}
		AddButton.Enabled = false;
		AddCounter.Visible = false;
		RemoveButton.Enabled = false;
		RemoveCounter.Visible = false;
		UpdateDisplayedUnitsOfMeasure();
		CalculateMapping();
		SetMapping();
		FillMapping();
		DisableMapping();
		ReadMapping();
		UpdateMapping(null, null);
	}

	private void FindMapping(object sender, FormClosingEventArgs e)
	{
		if (ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.Show();
		}
	}

	public void RefreshForm()
	{
		UpdateDisplayedUnitsOfMeasure();
		CalculateMapping();
		SetMapping();
		FillMapping();
		if (m_SystemWatcher != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			UpdateMapping(null, null);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.AddInterruptibleIndexer(Client.SelectedUnit, Client.SelectedUnit);
	}

	private void SetMapping()
	{
		m_ParamWatcher = _RegWatcher.GetCargo_Mass();
		_PageWatcher = _RegWatcher.GetCargo_Area();
		_RulesWatcher = _RegWatcher.GetCargo_Crew();
		methodWatcher = SelectedContainer.PayloadVolume;
		Cargo[] cargoArray = _RegWatcher.CargoArray;
		Cargo[] array = cargoArray;
		foreach (Cargo cargo in array)
		{
			m_ParamWatcher -= cargo.RequiredMass;
			_PageWatcher -= cargo.RequiredArea;
			_RulesWatcher -= cargo.RequiredCrewSpace;
		}
	}

	private void FillMapping()
	{
		SizeLabel.Text = "Max Size: ";
		switch (_RegWatcher.GetCargo_Type())
		{
		case CargoType.SmallCargo:
			SizeLabel.Text += CargoHostHelper.c2000;
			break;
		case CargoType.Personnel:
			SizeLabel.Text += CargoHostHelper.c1000;
			break;
		case CargoType.NoCargo:
			SizeLabel.Text += CargoHostHelper.c0000;
			break;
		case CargoType.const_5:
			SizeLabel.Text += CargoHostHelper.c5000;
			break;
		case CargoType.LargeCargo:
			SizeLabel.Text += CargoHostHelper.c4000;
			break;
		case CargoType.MediumCargo:
			SizeLabel.Text += CargoHostHelper.c3000;
			break;
		}
		float cargo_Mass = _RegWatcher.GetCargo_Mass();
		float num = Cargo.DisplayValueMass(cargo_Mass - m_ParamWatcher, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		float num2 = Cargo.DisplayValueMass(cargo_Mass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		MassBar.Text = "质量：" + num.ToString("N") + " / " + num2.ToString("N") + " " + Cargo.CargoMassLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (cargo_Mass == 0f)
		{
			MassBar.Value = 100;
		}
		else
		{
			MassBar.Value = (int)Math.Round(100f * ((cargo_Mass - m_ParamWatcher) / cargo_Mass));
		}
		if (m_ParamWatcher == 0f)
		{
			MassBar.ForeColor = Color.LightGray;
			MassBar.Text = "[FULL] " + MassBar.Text;
		}
		else
		{
			MassBar.ForeColor = Color.White;
		}
		cargo_Mass = _RegWatcher.GetCargo_Area();
		num = Cargo.DisplayValueArea(cargo_Mass - _PageWatcher, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		num2 = Cargo.DisplayValueArea(cargo_Mass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		AreaBar.Text = "区域：" + num.ToString("N") + " / " + num2.ToString("N") + " " + Cargo.CargoAreaLabel(SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
		if (cargo_Mass == 0f)
		{
			AreaBar.Value = 100;
		}
		else
		{
			AreaBar.Value = (int)Math.Round(100f * ((cargo_Mass - _PageWatcher) / cargo_Mass));
		}
		if (_PageWatcher == 0f)
		{
			AreaBar.ForeColor = Color.LightGray;
			AreaBar.Text = "[FULL] " + AreaBar.Text;
		}
		else
		{
			AreaBar.ForeColor = Color.White;
		}
		cargo_Mass = _RegWatcher.GetCargo_Crew();
		CrewBar.Text = "PAX: " + (cargo_Mass - _RulesWatcher) + " / " + cargo_Mass.ToString("N0") + " Pers.";
		if (cargo_Mass == 0f)
		{
			CrewBar.Value = 100;
		}
		else
		{
			CrewBar.Value = (int)Math.Round(100f * ((cargo_Mass - _RulesWatcher) / cargo_Mass));
		}
		if (_RulesWatcher == 0f)
		{
			CrewBar.ForeColor = Color.LightGray;
			CrewBar.Text = "[FULL] " + CrewBar.Text;
		}
		else
		{
			CrewBar.ForeColor = Color.White;
		}
	}

	private void CalculateMapping()
	{
		int num = -1;
		if (InventoryGridView.SelectedRows.Count > 0)
		{
			num = InventoryGridView.SelectedRows[0].Index;
		}
		InventoryGridView.Rows.Clear();
		if (SelectedContainer.CargoArray.Count() < 1)
		{
			return;
		}
		int num2 = 0;
		InventoryGridView.Rows.Add(_RegWatcher.CargoArray.Count());
		Cargo[] cargoArray = _RegWatcher.CargoArray;
		Cargo[] array = cargoArray;
		foreach (Cargo cargo in array)
		{
			DataGridViewRow dataGridViewRow = InventoryGridView.Rows[num2];
			dataGridViewRow.Cells[0].Value = cargo.CargoObjectName;
			dataGridViewRow.Cells[1].Value = Cargo.DisplayValueMass(cargo.RequiredMass, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N");
			dataGridViewRow.Cells[2].Value = Cargo.DisplayValueArea(cargo.RequiredArea, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N");
			dataGridViewRow.Cells[3].Value = cargo.RequiredCrewSpace.ToString();
			dataGridViewRow.Tag = cargo;
			num2++;
		}
		if (InventoryGridView.Rows.Count > 0 && num > -1)
		{
			InventoryGridView.ClearSelection();
			if (num >= InventoryGridView.Rows.Count)
			{
				num = InventoryGridView.Rows.Count - 1;
			}
			InventoryGridView.Rows[num].Selected = true;
		}
		InventoryGridView.Refresh();
		CompareMapping(null, null);
	}

	private bool PopMapping(DataGridViewRow dataGridViewRow_0, int int_0, float float_0, float float_1, float float_2)
	{
		if (Cargo.InputValueMass(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Mass"].Value), SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) <= float_0)
		{
			if (Cargo.InputValueArea(Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Area"].Value), SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo) <= float_1)
			{
				if (Conversions.ToSingle(dataGridViewRow_0.Cells["Cargo_Crew"].Value) <= float_2)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private void InstantiateMapping()
	{
		int int_ = 1;
		if (AddCounter.Enabled)
		{
			int_ = Convert.ToInt32(AddCounter.Value);
		}
		SetMapping();
		IEnumerator enumerator = null;
		try
		{
			enumerator = ((IEnumerable)DBGrid.Rows).GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if (PopMapping(dataGridViewRow, int_, m_ParamWatcher, _PageWatcher, _RulesWatcher))
				{
					dataGridViewRow.DefaultCellStyle.ForeColor = DBGrid.DefaultCellStyle.ForeColor;
					dataGridViewRow.DefaultCellStyle.SelectionForeColor = DBGrid.DefaultCellStyle.SelectionForeColor;
				}
				else
				{
					dataGridViewRow.DefaultCellStyle.ForeColor = Color.Red;
					dataGridViewRow.DefaultCellStyle.SelectionForeColor = Color.Red;
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

	private void CreateMapping(object sender, EventArgs e)
	{
		int int_ = 1;
		if (AddCounter.Visible)
		{
			int_ = Convert.ToInt32(AddCounter.Value);
		}
		AddButton.Enabled = false;
		SetMapping();
		IEnumerator enumerator = null;
		try
		{
			enumerator = DBGrid.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow_ = (DataGridViewRow)enumerator.Current;
				if (PopMapping(dataGridViewRow_, int_, m_ParamWatcher, _PageWatcher, _RulesWatcher))
				{
					AddButton.Enabled = true;
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

	private void CompareMapping(object sender, EventArgs e)
	{
		RemoveButton.Enabled = false;
		RemoveCounter.Visible = false;
		IEnumerator enumerator = null;
		try
		{
			enumerator = InventoryGridView.SelectedRows.GetEnumerator();
			if (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				RemoveButton.Enabled = true;
				if (dataGridViewRow.Tag != null && dataGridViewRow.Tag is CargoManifestItem)
				{
					RemoveCounter.Visible = true;
					RemoveCounter.Maximum = new decimal(((CargoManifestItem)dataGridViewRow.Tag).quantity);
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

	private void ReadMapping()
	{
		if (SelectedContainer == null || SelectedContainer.ContainerType != CargoContainer.CargoContainerType.Tank)
		{
			return;
		}
		bool flag = false;
		int maximum = (int)Math.Round(Cargo.DisplayValueLiquidVolume(1000f * SelectedContainer.PayloadVolume, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo));
		FuelVolumeMinLabel.Text = "0";
		FuelVolumeMaxLabel.Text = maximum.ToString();
		FuelTrackBar.Maximum = maximum;
		if (SelectedContainer.OnboardCargo.Count() > 0)
		{
			CargoContainerContent cargoObjectContainerContents = SelectedContainer.OnboardCargo[0].CargoObjectContainerContents;
			if (cargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel)
			{
				CargoLiquidFuel cargoLiquidFuel = (CargoLiquidFuel)cargoObjectContainerContents;
				int num = FuelTypeComboBox.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (((RepositoryProcessProducer)FuelTypeComboBox.Items[i]).ID == (int)cargoLiquidFuel.FuelType)
					{
						FuelTypeComboBox.SelectedIndex = i;
						break;
					}
				}
				FuelTrackBar.Value = (int)Math.Round(Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo));
				flag = true;
			}
		}
		if (!flag)
		{
			FuelTypeComboBox.SelectedIndex = 0;
			FuelTrackBar.Value = 0;
			FuelVolumeLabel.Text = "0";
			FuelMassLabel.Text = "0";
		}
	}

	private void DisableMapping()
	{
		if (SelectedContainer != null)
		{
			_ServiceWatcher.Name = UserContentNameTextBox.Text;
			if (!float.TryParse(UserContentMassTextbox.Text, out _ServiceWatcher.Mass))
			{
				_ServiceWatcher.Mass = 1f;
				UserContentMassTextbox.Text = "1";
			}
			if (!float.TryParse(UserContentLengthTextbox.Text, out var result))
			{
				result = 1f;
				UserContentLengthTextbox.Text = "1";
			}
			if (!float.TryParse(UserContentWidthTextBox.Text, out var result2))
			{
				result2 = 1f;
				UserContentWidthTextBox.Text = "1";
			}
			if (!float.TryParse(UserContentHeightTextBox.Text, out var result3))
			{
				result3 = 1f;
				UserContentHeightTextBox.Text = "1";
			}
			if (SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
			{
				_ServiceWatcher.Mass = Cargo.InputValueSmallMass(_ServiceWatcher.Mass, bool_0: true);
				result = Cargo.InputValueDistance(result, bool_0: true);
				result2 = Cargo.InputValueDistance(result2, bool_0: true);
				result3 = Cargo.InputValueDistance(result3, bool_0: true);
			}
			_ServiceWatcher.Mass /= 1000f;
			_ServiceWatcher.Area = result * result2;
			_ServiceWatcher.Volume = _ServiceWatcher.Area * result3;
			_ServiceWatcher.Size = DBFunctions.RestartList(result, result2, result3);
			switch (_ServiceWatcher.Size)
			{
			case CargoType.SmallCargo:
				UserContentCargoSizeLabel.Text = MapperListenerManager.visitorClass;
				break;
			case CargoType.Personnel:
				UserContentCargoSizeLabel.Text = MapperListenerManager._AttrClass;
				break;
			case CargoType.NoCargo:
				UserContentCargoSizeLabel.Text = MapperListenerManager._ExceptionClass;
				break;
			case CargoType.const_5:
				UserContentCargoSizeLabel.Text = MapperListenerManager.m_ComparatorClass;
				break;
			case CargoType.LargeCargo:
				UserContentCargoSizeLabel.Text = MapperListenerManager._PrototypeClass;
				break;
			case CargoType.MediumCargo:
				UserContentCargoSizeLabel.Text = MapperListenerManager.m_ExporterClass;
				break;
			}
		}
	}

	private void UpdateMapping(object sender, EventArgs e)
	{
		if (m_SystemWatcher != SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo)
		{
			DBGrid.DataSource = null;
			m_SystemWatcher = SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo;
		}
		switch (ContentsSourceTabControl.SelectedIndex)
		{
		case 0:
			AddCounter.Visible = true;
			if (SelectedActiveUnit != null && DBGrid.DataSource == null)
			{
				DataTable dataTable = null;
				try
				{
					SQLiteConnection sqliteConnection_ = SelectedActiveUnit.ParentScen.DBConnection;
					dataTable = DBFunctions.GetAllCargoWeapons(ref sqliteConnection_);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					DarkMessageBox.ShowError("无法使用当前加载的数据库进行货物相关任务。请将想定升级到最新数据库。", "Error");
					Close();
					ProjectData.ClearProjectError();
					break;
				}
				DataTable dataTable2 = dataTable.Clone();
				dataTable2.Columns.Remove("Deprecated");
				dataTable2.Columns["Cargo_Type"].DataType = typeof(string);
				IEnumerator enumerator = null;
				try
				{
					enumerator = dataTable.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataRow row = (DataRow)enumerator.Current;
						dataTable2.ImportRow(row);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				_RegWatcher.GetCargo_Type();
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
				InstantiateMapping();
			}
			AddButton.Text = "Load Selected";
			break;
		case 1:
			ReadMapping();
			AddButton.Text = "Set Fuel Content";
			AddButton.Enabled = true;
			break;
		case 2:
			DisableMapping();
			AddButton.Enabled = true;
			AddCounter.Visible = true;
			AddButton.Text = "Load Selected";
			break;
		}
	}

	private void InsertMapping(object sender, EventArgs e)
	{
		List<Cargo> list = new List<Cargo>();
		List<Cargo> list2 = new List<Cargo>();
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
					if (RemoveCounter.Visible)
					{
						num = Convert.ToInt32(RemoveCounter.Value);
						if (num > cargoManifestItem.quantity)
						{
							num = cargoManifestItem.quantity;
						}
					}
					else
					{
						num = 1;
					}
					for (num2 = 0; num2 < SelectedContainer.CargoArray.Count(); num2++)
					{
						if (num <= 0)
						{
							break;
						}
						if (SelectedContainer.CargoArray[num2].CurrentType == cargoManifestItem.objectType && SelectedContainer.CargoArray[num2].CargoObjectDBID == cargoManifestItem.DBID)
						{
							list2.Add(SelectedContainer.CargoArray[num2]);
							num--;
						}
					}
				}
				else
				{
					Cargo cargo = (Cargo)dataGridViewRow.Tag;
					if ((uint)(cargo.CurrentType - 4) <= 1u)
					{
						list2.Add(cargo);
					}
					else
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
				if (SelectedActiveUnit.ParentScen.ActiveUnits.TryGetValue(cargoObjectID, ref activeUnit))
				{
					list3.Add(item);
					double latitude_old = activeUnit.Latitude_old;
					double longitude_old = activeUnit.Longitude_old;
					ActiveUnit selectedActiveUnit = SelectedActiveUnit;
					CargoContainer selectedContainer;
					Cargo[] cargo_ = (selectedContainer = SelectedContainer).CargoArray;
					Cargo.UnloadCargoAtLocation(selectedActiveUnit, ref cargo_, list3, latitude_old, longitude_old, SelectedActiveUnit.ParentScen, SelectedActiveUnit.GetUnitSide(), bool_0: false, bool_1: true);
					selectedContainer.CargoArray = cargo_;
				}
			}
		}
		if (list2.Count > 0)
		{
			foreach (Cargo item2 in list2)
			{
				SelectedContainer.Remove(item2);
			}
		}
		SetMapping();
		RefreshForm();
		if (ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.RefreshForm();
		}
	}

	private void PrepareMapping(object sender, EventArgs e)
	{
		new List<Cargo>();
		int num = 1;
		SetMapping();
		string text = AddButton.Text;
		AddButton.Enabled = false;
		AddButton.Text = "工作中...";
		if (AddCounter.Visible)
		{
			num = Convert.ToInt32(AddCounter.Value);
		}
		switch (ContentsSourceTabControl.SelectedIndex)
		{
		case 0:
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = DBGrid.SelectedRows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					CargoAmmunition cargoAmmunition = new CargoAmmunition(Conversions.ToInteger(((DataGridViewRow)enumerator.Current).Cells["ID"].Value), num, SelectedActiveUnit.ParentScen);
					if (SelectedContainer.PrintProperty(cargoAmmunition))
					{
						Cargo cargo_2 = new Cargo(SelectedActiveUnit, cargoAmmunition, SelectedContainer);
						SelectedContainer.Add(cargo_2);
						continue;
					}
					DarkMessageBox.ShowWarning("Unable to add " + cargoAmmunition.Name + " to this container - maximum capacity exceeded.", "空间不足！");
					break;
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
		case 1:
		{
			CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
			float currentQuantity = Cargo.InputValueLiquidVolume(FuelTrackBar.Value, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			cargoLiquidFuel.FuelType = (FuelRec._FuelType)((RepositoryProcessProducer)FuelTypeComboBox.SelectedItem).ID;
			cargoLiquidFuel.CurrentQuantity = currentQuantity;
			Cargo cargo = null;
			if (SelectedContainer.CargoArray.Count() > 0)
			{
				cargo = SelectedContainer.CargoArray[0];
				SelectedContainer.Remove(cargo);
			}
			if (SelectedContainer.PrintProperty(cargoLiquidFuel))
			{
				if (cargoLiquidFuel.CurrentQuantity > 0f)
				{
					Cargo cargo_3 = new Cargo(SelectedActiveUnit, cargoLiquidFuel, SelectedContainer);
					SelectedContainer.Add(cargo_3);
				}
			}
			else
			{
				DarkMessageBox.ShowWarning("Unable to add " + cargoLiquidFuel.Name + " to this container - check maximum capacity and current fuel type.", "空间不足！");
				if (cargo != null)
				{
					SelectedContainer.Add(cargo);
				}
			}
			break;
		}
		case 2:
		{
			DisableMapping();
			int num2 = num;
			for (int i = 1; i <= num2; i++)
			{
				CargoContainerContent cargoContainerContent = new CargoContainerContent();
				cargoContainerContent.Name = _ServiceWatcher.Name;
				cargoContainerContent.Mass = _ServiceWatcher.Mass;
				cargoContainerContent.Area = _ServiceWatcher.Area;
				cargoContainerContent.Volume = _ServiceWatcher.Volume;
				cargoContainerContent.Size = _ServiceWatcher.Size;
				if (SelectedContainer.PrintProperty(cargoContainerContent))
				{
					Cargo cargo_ = new Cargo(SelectedActiveUnit, cargoContainerContent, SelectedContainer);
					SelectedContainer.Add(cargo_);
					continue;
				}
				DarkMessageBox.ShowWarning("Unable to add all requested " + cargoContainerContent.Name + " to this container - maximum capacity exceeded.", "空间不足！");
				break;
			}
			break;
		}
		}
		AddButton.Text = text;
		AddButton.Enabled = true;
		SetMapping();
		RefreshForm();
		if (ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.RefreshForm();
		}
	}

	private void ReflectMapping()
	{
		CargoLiquidFuel cargoLiquidFuel = new CargoLiquidFuel();
		int selectedIndex = FuelTypeComboBox.SelectedIndex;
		string text = "";
		float num = 0f;
		if (selectedIndex >= 0)
		{
			float currentQuantity = Cargo.InputValueLiquidVolume(FuelTrackBar.Value, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo);
			cargoLiquidFuel.FuelType = (FuelRec._FuelType)((RepositoryProcessProducer)FuelTypeComboBox.Items[selectedIndex]).ID;
			cargoLiquidFuel.CurrentQuantity = currentQuantity;
			float num2 = cargoLiquidFuel.GetRequiredMass();
			if (SelectedContainer.CargoArray.Count() > 0 && SelectedContainer.CargoArray[0].CargoObjectContainerContents != null && SelectedContainer.CargoArray[0].CargoObjectContainerContents.ContentType == CargoContainerContent.CargoContainerContentType.LiquidFuel)
			{
				num = ((CargoLiquidFuel)SelectedContainer.CargoArray[0].CargoObjectContainerContents).GetRequiredMass();
			}
			float num3 = ((ICargoHost)SelectedActiveUnit).GetCargo_MassAvailable() + num;
			if (num3 <= SelectedContainer.ResolveProperty())
			{
				text = "Quantity constrained by transporting unit's weight limit!";
			}
			else
			{
				num3 = SelectedContainer.ResolveProperty();
				text = "Quantity constrained by container weight limit!";
			}
			if (num2 <= num3)
			{
				FuelWarningLabel.Text = "";
			}
			else
			{
				num2 = num3;
				cargoLiquidFuel.CurrentQuantity = cargoLiquidFuel.MoveImporter(1000f * num2);
				FuelTrackBar.Value = (int)Math.Round(Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo));
				FuelWarningLabel.Text = text;
			}
			FuelVolumeLabel.Text = Cargo.DisplayValueLiquidVolume(cargoLiquidFuel.CurrentQuantity, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N2");
			FuelMassLabel.Text = Cargo.DisplayValueSmallMass(1000f * num2, SimConfiguration.DefaultGamePreferences.ShowUSUnitsForEditCargo).ToString("N2");
		}
	}

	private void VisitMapping(object sender, EventArgs e)
	{
		ReflectMapping();
	}

	private void RestartMapping(object sender, EventArgs e)
	{
		ReflectMapping();
	}

	private void TestMapping(object sender, EventArgs e)
	{
		DisableMapping();
	}

	private void StopMapping(object sender, EventArgs e)
	{
		DisableMapping();
	}

	private void CancelMapping(object sender, EventArgs e)
	{
		DisableMapping();
	}
}
