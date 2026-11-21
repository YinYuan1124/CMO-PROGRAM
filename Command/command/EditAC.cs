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
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditAC : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class ImporterProcessProducer
	{
		public int Local_theDBID;

		internal bool EnableInterruptiblePage(Aircraft AC)
		{
			return AC.DBID == Local_theDBID;
		}
	}

	private IContainer _ModelSpecification;

	[AccessedThroughProperty("ListView1")]
	[CompilerGenerated]
	private DarkListView m_AdvisorSpecification;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_SerializerSpecification;

	[AccessedThroughProperty("TB_Callsign")]
	[CompilerGenerated]
	private DarkUITextBox errorSpecification;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_CodeSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton m_ConnectionSpecification;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton proccesorSpecification;

	[AccessedThroughProperty("Button_RemoveAC")]
	[CompilerGenerated]
	private DarkUIButton configurationSpecification;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView tokenSpecification;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private DarkGroupBox indexerSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Country")]
	private DarkUIComboBox _ResolverSpecification;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel publisherSpecification;

	[AccessedThroughProperty("TB_Class")]
	[CompilerGenerated]
	private DarkUITextBox adapterSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_FilterSizeAndTODLAD")]
	private DarkCheckBox schemaSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Hypothetical")]
	private DarkUIComboBox m_UtilsSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SubType")]
	private DarkUIComboBox m_SingletonSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("DBID")]
	private DataGridViewTextBoxColumn m_RecordSpecification;

	[AccessedThroughProperty("LongName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ExceptionSpecification;

	[AccessedThroughProperty("AcName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn attrSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Country")]
	private DataGridViewTextBoxColumn m_VisitorSpecification;

	[AccessedThroughProperty("IOC")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn exporterSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Hypothetical")]
	private DataGridViewCheckBoxColumn m_ComparatorSpecification;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel m_CreatorSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("AcType")]
	private DataGridViewTextBoxColumn templateSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("AcSize")]
	private DataGridViewTextBoxColumn m_MappingSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("RunwaySizeNeeded")]
	private DataGridViewTextBoxColumn m_MockSpecification;

	[AccessedThroughProperty("Deprecated")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_TagSpecification;

	public ActiveUnit SelectedHost;

	private DataTable _FieldSpecification;

	internal DarkListView ListView1
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareSetter;
			EventHandler value3 = TestSetter;
			DarkListView advisorSpecification = m_AdvisorSpecification;
			if (advisorSpecification != null)
			{
				advisorSpecification.SelectedIndicesChanged -= value2;
				advisorSpecification.SelectedIndicesChanged -= value3;
			}
			m_AdvisorSpecification = value;
			advisorSpecification = m_AdvisorSpecification;
			if (advisorSpecification != null)
			{
				advisorSpecification.SelectedIndicesChanged += value2;
				advisorSpecification.SelectedIndicesChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SerializerSpecification = value;
		}
	}

	[field: AccessedThroughProperty("NUD1")]
	internal DarkNumericUpDown NUD1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TB_Callsign
	{
		[CompilerGenerated]
		get
		{
			return errorSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			errorSpecification = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_CodeSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeSpecification = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadSetter;
			DarkUIButton connectionSpecification = m_ConnectionSpecification;
			if (connectionSpecification != null)
			{
				connectionSpecification.Click -= value2;
			}
			m_ConnectionSpecification = value;
			connectionSpecification = m_ConnectionSpecification;
			if (connectionSpecification != null)
			{
				connectionSpecification.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TB_Quantity")]
	internal DarkUITextBox TB_Quantity
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return proccesorSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableSetter;
			DarkUIButton darkUIButton = proccesorSpecification;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			proccesorSpecification = value;
			darkUIButton = proccesorSpecification;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Quantity")]
	internal DarkGroupBox Quantity
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_RemoveAC
	{
		[CompilerGenerated]
		get
		{
			return configurationSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateSetter;
			DarkUIButton darkUIButton = configurationSpecification;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			configurationSpecification = value;
			darkUIButton = configurationSpecification;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return tokenSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = InsertSetter;
			DataGridViewCellEventHandler value3 = PostSetter;
			DarkDataGridView darkDataGridView = tokenSpecification;
			if (darkDataGridView != null)
			{
				darkDataGridView.KeyPress -= value2;
				darkDataGridView.CellContentDoubleClick -= value3;
			}
			tokenSpecification = value;
			darkDataGridView = tokenSpecification;
			if (darkDataGridView != null)
			{
				darkDataGridView.KeyPress += value2;
				darkDataGridView.CellContentDoubleClick += value3;
			}
		}
	}

	internal DarkGroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return indexerSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			indexerSpecification = value;
		}
	}

	internal DarkUIComboBox CB_Country
	{
		[CompilerGenerated]
		get
		{
			return _ResolverSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelSetter;
			DarkUIComboBox resolverSpecification = _ResolverSpecification;
			if (resolverSpecification != null)
			{
				resolverSpecification.SelectionChangeCommitted -= value2;
			}
			_ResolverSpecification = value;
			resolverSpecification = _ResolverSpecification;
			if (resolverSpecification != null)
			{
				resolverSpecification.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return publisherSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherSpecification = value;
		}
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
			return adapterSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = ReflectSetter;
			DarkUITextBox darkUITextBox = adapterSpecification;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			adapterSpecification = value;
			darkUITextBox = adapterSpecification;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_FilterSizeAndTODLAD
	{
		[CompilerGenerated]
		get
		{
			return schemaSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunSetter;
			DarkCheckBox darkCheckBox = schemaSpecification;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			schemaSpecification = value;
			darkCheckBox = schemaSpecification;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return m_UtilsSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifySetter;
			DarkUIComboBox utilsSpecification = m_UtilsSpecification;
			if (utilsSpecification != null)
			{
				utilsSpecification.SelectionChangeCommitted -= value2;
			}
			m_UtilsSpecification = value;
			utilsSpecification = m_UtilsSpecification;
			if (utilsSpecification != null)
			{
				utilsSpecification.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_SubType
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveSetter;
			DarkUIComboBox singletonSpecification = m_SingletonSpecification;
			if (singletonSpecification != null)
			{
				singletonSpecification.SelectionChangeCommitted -= value2;
			}
			m_SingletonSpecification = value;
			singletonSpecification = m_SingletonSpecification;
			if (singletonSpecification != null)
			{
				singletonSpecification.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn DBID
	{
		[CompilerGenerated]
		get
		{
			return m_RecordSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RecordSpecification = value;
		}
	}

	internal DataGridViewTextBoxColumn LongName
	{
		[CompilerGenerated]
		get
		{
			return m_ExceptionSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExceptionSpecification = value;
		}
	}

	internal DataGridViewTextBoxColumn Country
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_VisitorSpecification = value;
		}
	}

	internal DataGridViewTextBoxColumn IOC
	{
		[CompilerGenerated]
		get
		{
			return exporterSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterSpecification = value;
		}
	}

	[field: AccessedThroughProperty("Retired")]
	internal DataGridViewTextBoxColumn Retired
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewCheckBoxColumn Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComparatorSpecification = value;
		}
	}

	[field: AccessedThroughProperty("CountryNumber")]
	internal DataGridViewTextBoxColumn CountryNumber
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Column2")]
	internal DataGridViewTextBoxColumn Column2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorSpecification = value;
		}
	}

	internal DataGridViewTextBoxColumn RunwaySizeNeeded
	{
		[CompilerGenerated]
		get
		{
			return m_MockSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockSpecification = value;
		}
	}

	internal DataGridViewTextBoxColumn Deprecated
	{
		[CompilerGenerated]
		get
		{
			return m_TagSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TagSpecification = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal DataGridViewTextBoxColumn SetCreator()
	{
		return attrSpecification;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void FillCreator(DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0)
	{
		attrSpecification = dataGridViewTextBoxColumn_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal DataGridViewTextBoxColumn CancelCreator()
	{
		return templateSpecification;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void VerifyCreator(DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0)
	{
		templateSpecification = dataGridViewTextBoxColumn_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal DataGridViewTextBoxColumn ResolveCreator()
	{
		return m_MappingSpecification;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void PostCreator(DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0)
	{
		m_MappingSpecification = dataGridViewTextBoxColumn_0;
	}

	public EditAC()
	{
		base.FormClosing += PopSetter;
		base.Load += InstantiateSetter;
		base.KeyDown += RestartSetter;
		base.Shown += StopSetter;
		CalculateSetter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ModelSpecification != null)
			{
				_ModelSpecification.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalculateSetter()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		ListView1 = new DarkListView();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		NUD1 = new DarkNumericUpDown();
		TB_Callsign = new DarkUITextBox();
		Label4 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label5 = new DarkLabel();
		TB_Quantity = new DarkUITextBox();
		Button2 = new DarkUIButton();
		Quantity = new DarkGroupBox();
		Button_RemoveAC = new DarkUIButton();
		DataGridView1 = new DarkDataGridView();
		DBID = new DataGridViewTextBoxColumn();
		LongName = new DataGridViewTextBoxColumn();
		FillCreator(new DataGridViewTextBoxColumn());
		Country = new DataGridViewTextBoxColumn();
		IOC = new DataGridViewTextBoxColumn();
		Retired = new DataGridViewTextBoxColumn();
		Hypothetical = new DataGridViewCheckBoxColumn();
		CountryNumber = new DataGridViewTextBoxColumn();
		VerifyCreator(new DataGridViewTextBoxColumn());
		PostCreator(new DataGridViewTextBoxColumn());
		RunwaySizeNeeded = new DataGridViewTextBoxColumn();
		Deprecated = new DataGridViewTextBoxColumn();
		Column2 = new DataGridViewTextBoxColumn();
		GroupBox1 = new DarkGroupBox();
		DarkLabel1 = new DarkLabel();
		CB_Hypothetical = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_FilterSizeAndTODLAD = new DarkCheckBox();
		CB_Country = new DarkUIComboBox();
		Label3 = new DarkLabel();
		Label6 = new DarkLabel();
		TB_Class = new DarkUITextBox();
		CB_SubType = new DarkUIComboBox();
		((ISupportInitialize)NUD1).BeginInit();
		Quantity.SuspendLayout();
		((ISupportInitialize)DataGridView1).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		ListView1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ListView1.Location = new Point(12, 34);
		ListView1.Name = "ListView1";
		ListView1.RelatedInfos = null;
		ListView1.Size = new Size(278, 583);
		ListView1.TabIndex = 0;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(12, 15);
		Label1.Name = "Label1";
		Label1.Size = new Size(87, 13);
		Label1.TabIndex = 1;
		Label1.Text = "目前的库存";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(294, 15);
		Label2.Name = "Label2";
		Label2.Size = new Size(111, 13);
		Label2.TabIndex = 8;
		Label2.Text = "增加飞机：";
		NUD1.BackColor = Color.FromArgb(69, 73, 74);
		NUD1.BorderStyle = BorderStyle.FixedSingle;
		NUD1.ForeColor = Color.FromArgb(220, 220, 220);
		NUD1.Location = new Point(6, 15);
		NUD1.Maximum = new decimal(new int[4] { 99999999, 0, 0, 0 });
		NUD1.Name = "NUD1";
		NUD1.Size = new Size(74, 27);
		NUD1.TabIndex = 10;
		TB_Callsign.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TB_Callsign.AutoCompleteCustomSource = null;
		TB_Callsign.AutoCompleteMode = AutoCompleteMode.None;
		TB_Callsign.AutoCompleteSource = AutoCompleteSource.None;
		TB_Callsign.BackColor = Color.FromArgb(69, 73, 74);
		TB_Callsign.Font = new Font("Segoe UI", 8f);
		TB_Callsign.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Callsign.Image = null;
		TB_Callsign.Lines = null;
		TB_Callsign.Location = new Point(423, 638);
		TB_Callsign.MaxLength = 32767;
		TB_Callsign.Multiline = false;
		TB_Callsign.Name = "TB_Callsign";
		TB_Callsign.ReadOnly = false;
		TB_Callsign.ScrollBars = ScrollBars.None;
		TB_Callsign.SelectionStart = 0;
		TB_Callsign.Size = new Size(135, 20);
		TB_Callsign.TabIndex = 11;
		TB_Callsign.TextAlign = HorizontalAlignment.Left;
		TB_Callsign.UseSystemPasswordChar = false;
		TB_Callsign.WatermarkText = "";
		Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(370, 641);
		Label4.Name = "Label4";
		Label4.Size = new Size(64, 20);
		Label4.TabIndex = 12;
		Label4.Text = "呼号：";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(844, 638);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.RoundRadius = 0;
		Button1.Size = new Size(111, 22);
		Button1.TabIndex = 13;
		Button1.Text = "添加所选项";
		Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(564, 642);
		Label5.Name = "Label5";
		Label5.Size = new Size(83, 20);
		Label5.TabIndex = 14;
		Label5.Text = "数量：";
		TB_Quantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TB_Quantity.AutoCompleteCustomSource = null;
		TB_Quantity.AutoCompleteMode = AutoCompleteMode.None;
		TB_Quantity.AutoCompleteSource = AutoCompleteSource.None;
		TB_Quantity.BackColor = Color.FromArgb(69, 73, 74);
		TB_Quantity.Font = new Font("Segoe UI", 8f);
		TB_Quantity.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Quantity.Image = null;
		TB_Quantity.Lines = null;
		TB_Quantity.Location = new Point(632, 638);
		TB_Quantity.MaxLength = 32767;
		TB_Quantity.Multiline = false;
		TB_Quantity.Name = "TB_Quantity";
		TB_Quantity.ReadOnly = false;
		TB_Quantity.ScrollBars = ScrollBars.None;
		TB_Quantity.SelectionStart = 0;
		TB_Quantity.Size = new Size(114, 20);
		TB_Quantity.TabIndex = 12;
		TB_Quantity.TextAlign = HorizontalAlignment.Left;
		TB_Quantity.UseSystemPasswordChar = false;
		TB_Quantity.WatermarkText = "";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(85, 15);
		Button2.Name = "Button2";
		Button2.Padding = new Padding(5);
		Button2.RoundRadius = 0;
		Button2.Size = new Size(65, 22);
		Button2.TabIndex = 16;
		Button2.Text = "应用";
		Quantity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Quantity.Controls.Add(NUD1);
		Quantity.Controls.Add(Button2);
		Quantity.ForeColor = Color.FromArgb(220, 220, 220);
		Quantity.Location = new Point(12, 624);
		Quantity.Name = "Quantity";
		Quantity.Size = new Size(155, 41);
		Quantity.TabIndex = 17;
		Quantity.TabStop = false;
		Quantity.Text = "数量";
		Button_RemoveAC.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_RemoveAC.BackColor = Color.IndianRed;
		Button_RemoveAC.DialogResult = DialogResult.None;
		Button_RemoveAC.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_RemoveAC.ForeColor = Color.IndianRed;
		Button_RemoveAC.Location = new Point(190, 638);
		Button_RemoveAC.Name = "Button_RemoveAC";
		Button_RemoveAC.Padding = new Padding(5);
		Button_RemoveAC.RoundRadius = 0;
		Button_RemoveAC.Size = new Size(100, 22);
		Button_RemoveAC.TabIndex = 18;
		Button_RemoveAC.Text = "删除选定";
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
		DataGridView1.Columns.AddRange(DBID, LongName, Country, IOC, Retired, Hypothetical, CancelCreator(), ResolveCreator(), RunwaySizeNeeded, Deprecated, SetCreator(), CountryNumber);
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
		DataGridView1.Location = new Point(297, 131);
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
		DataGridView1.Size = new Size(658, 486);
		DataGridView1.TabIndex = 21;
		DBID.DataPropertyName = "ID";
		DBID.HeaderText = "ID";
		DBID.MinimumWidth = 6;
		DBID.Name = "DBID";
		DBID.ReadOnly = true;
		DBID.Visible = false;
		DBID.Width = 125;
		SetCreator().AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		SetCreator().DataPropertyName = "Name";
		SetCreator().HeaderText = "飞机";
		SetCreator().MinimumWidth = 6;
		SetCreator().Name = "Name";
		SetCreator().ReadOnly = true;
		SetCreator().Visible = false;
		LongName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		LongName.DataPropertyName = "LongName";
		LongName.HeaderText = "飞机";
		LongName.MinimumWidth = 6;
		LongName.Name = "LongName";
		LongName.ReadOnly = true;
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
		CancelCreator().AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		CancelCreator().DataPropertyName = "Type";
		CancelCreator().HeaderText = "类型";
		CancelCreator().MinimumWidth = 6;
		CancelCreator().Name = "Type";
		CancelCreator().ReadOnly = true;
		CancelCreator().Width = 67;
		CancelCreator().Visible = false;
		ResolveCreator().AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ResolveCreator().DataPropertyName = "Size";
		ResolveCreator().HeaderText = "尺寸";
		ResolveCreator().MinimumWidth = 6;
		ResolveCreator().Name = "Size";
		ResolveCreator().ReadOnly = true;
		ResolveCreator().Width = 67;
		ResolveCreator().Visible = false;
		RunwaySizeNeeded.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		RunwaySizeNeeded.DataPropertyName = "RunwaySizeNeeded";
		RunwaySizeNeeded.HeaderText = "跑道";
		RunwaySizeNeeded.MinimumWidth = 6;
		RunwaySizeNeeded.Name = "RunwaySizeNeeded";
		RunwaySizeNeeded.ReadOnly = true;
		RunwaySizeNeeded.Width = 67;
		RunwaySizeNeeded.Visible = false;
		Hypothetical.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		Hypothetical.DataPropertyName = "Hypothetical";
		Hypothetical.FalseValue = "False";
		Hypothetical.HeaderText = "假想";
		Hypothetical.MinimumWidth = 6;
		Hypothetical.Name = "Hypothetical";
		Hypothetical.ReadOnly = true;
		Hypothetical.TrueValue = "True";
		Hypothetical.Width = 49;
		Hypothetical.Visible = false;
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
		Deprecated.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Deprecated.DataPropertyName = "Deprecated";
		Deprecated.HeaderText = "Deprecated";
		Deprecated.MinimumWidth = 6;
		Deprecated.Name = "Deprecated";
		Deprecated.ReadOnly = true;
		Deprecated.Width = 67;
		Deprecated.Visible = false;
		GroupBox1.Controls.Add(DarkLabel1);
		GroupBox1.Controls.Add(CB_Hypothetical);
		GroupBox1.Controls.Add(Label7);
		GroupBox1.Controls.Add(CB_FilterSizeAndTODLAD);
		GroupBox1.Controls.Add(CB_Country);
		GroupBox1.Controls.Add(Label3);
		GroupBox1.Controls.Add(Label6);
		GroupBox1.Controls.Add(TB_Class);
		GroupBox1.Controls.Add(CB_SubType);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(296, 34);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(659, 91);
		GroupBox1.TabIndex = 22;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "过滤...";
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(341, 53);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(61, 17);
		DarkLabel1.TabIndex = 20;
		DarkLabel1.Text = "子类型：";
		CB_Hypothetical.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Hypothetical.BackColor = Color.Transparent;
		CB_Hypothetical.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Hypothetical.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Hypothetical.Font = new Font("Segoe UI", 7f);
		CB_Hypothetical.Location = new Point(83, 41);
		CB_Hypothetical.Name = "CB_Hypothetical";
		CB_Hypothetical.Size = new Size(252, 24);
		CB_Hypothetical.TabIndex = 16;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(6, 45);
		Label7.Name = "Label7";
		Label7.Size = new Size(85, 20);
		Label7.TabIndex = 15;
		Label7.Text = "假想：";
		CB_FilterSizeAndTODLAD.Location = new Point(10, 68);
		CB_FilterSizeAndTODLAD.Name = "CB_FilterSizeAndTODLAD";
		CB_FilterSizeAndTODLAD.Size = new Size(252, 18);
		CB_FilterSizeAndTODLAD.TabIndex = 14;
		CB_FilterSizeAndTODLAD.Text = "仅显示能够在此起飞/降落的飞机";
		CB_FilterSizeAndTODLAD.Visible = true;
		CB_Country.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Country.BackColor = Color.Transparent;
		CB_Country.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Country.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Country.Font = new Font("Segoe UI", 7f);
		CB_Country.Location = new Point(398, 16);
		CB_Country.Name = "CB_Country";
		CB_Country.Size = new Size(255, 24);
		CB_Country.TabIndex = 13;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(341, 20);
		Label3.Name = "Label3";
		Label3.Size = new Size(61, 17);
		Label3.TabIndex = 12;
		Label3.Text = "国家：";
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(7, 20);
		Label6.Name = "Label6";
		Label6.Size = new Size(41, 17);
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
		TB_Class.Location = new Point(83, 17);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		TB_Class.Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = ScrollBars.None;
		TB_Class.SelectionStart = 0;
		TB_Class.Size = new Size(252, 20);
		TB_Class.TabIndex = 10;
		TB_Class.TextAlign = HorizontalAlignment.Left;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		CB_SubType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_SubType.BackColor = Color.Transparent;
		CB_SubType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_SubType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_SubType.Font = new Font("Segoe UI", 7f);
		CB_SubType.FormattingEnabled = true;
		CB_SubType.Location = new Point(452, 46);
		CB_SubType.Name = "CB_SubType";
		CB_SubType.Size = new Size(201, 24);
		CB_SubType.TabIndex = 19;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(967, 673);
		base.Controls.Add(GroupBox1);
		base.Controls.Add(DataGridView1);
		base.Controls.Add(Button_RemoveAC);
		base.Controls.Add(Quantity);
		base.Controls.Add(TB_Quantity);
		base.Controls.Add(Label5);
		base.Controls.Add(Button1);
		base.Controls.Add(Label4);
		base.Controls.Add(TB_Callsign);
		base.Controls.Add(Label2);
		base.Controls.Add(Label1);
		base.Controls.Add(ListView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditAC";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑飞机：";
		((ISupportInitialize)NUD1).EndInit();
		Quantity.ResumeLayout(performLayout: false);
		((ISupportInitialize)DataGridView1).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PopSetter(object sender, FormClosingEventArgs e)
	{
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void InstantiateSetter(object sender, EventArgs e)
	{
		_FieldSpecification = Client.CurrentScenario.Cache_Aircraft_DT.Copy();
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		CB_Country.SuspendLayout();
		CB_Country.DataSource = cache_OperatorCountries_DT;
		CB_Country.DisplayMember = "Description";
		CB_Country.ValueMember = "ID";
		CB_Country.SelectedIndex = 0;
		CB_Country.ResumeLayout();
		CB_Hypothetical.Items.Clear();
		CB_Hypothetical.Items.Add("真实和假想");
		CB_Hypothetical.Items.Add("仅真实平台");
		CB_Hypothetical.Items.Add("仅假想平台");
		CB_Hypothetical.SelectedItem = RuntimeHelpers.GetObjectValue(CB_Hypothetical.Items[0]);
		ListSetter();
	}

	private void CreateSetter()
	{
		Client.MustRefreshMainForm = true;
		ListView1.Items.Clear();
		foreach (int item in SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Select((Aircraft AC) => AC.DBID).Distinct())
		{
			int Local_theDBID = item;
			IEnumerable<Aircraft> source = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where((Aircraft AC) => AC.DBID == Local_theDBID);
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Tag = Local_theDBID;
			darkListItem.Text = Conversions.ToString(source.Count()) + "x " + source.ElementAtOrDefault(0).UnitClass;
			ListView1.Items.Add(darkListItem);
		}
		Button_RemoveAC.Visible = ListView1.SelectedIndices.Count > 0;
		Button_RemoveAC.Enabled = Button_RemoveAC.Visible;
	}

	private void CompareSetter(object sender, EventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			int value = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where((Aircraft aircraft_0) => string.CompareOrdinal(Conversions.ToString(aircraft_0.DBID), ListView1.SelectedItems[0].Tag.ToString()) == 0).Count();
			NUD1.Value = new decimal(value);
		}
	}

	private void ReadSetter(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count == 0)
		{
			return;
		}
		int num = Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
		if (num == 10000 || num == 10001 || num == 10002)
		{
			return;
		}
		string text = (string.IsNullOrEmpty(TB_Callsign.Text) ? Callsigns.InstantiateProperty() : TB_Callsign.Text);
		if (!Versioned.IsNumeric(TB_Quantity.Text))
		{
			return;
		}
		Button1.Text = "工作中...";
		Button1.Enabled = false;
		bool flag = true;
		bool flag2 = true;
		int num2 = Conversions.ToInteger(TB_Quantity.Text);
		for (int i = 1; i <= num2; i++)
		{
			Aircraft aircraft = Client.CurrentScenario.AddNewAircraft(Client.CurrentSide, text + " #" + Conversions.ToString(i), 0.0, 0.0, num, 0, 0f);
			if (i == 1)
			{
				if ((SelectedHost.IsGroup ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, bool_0: true, bool_1: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : ((SelectedHost.GetParentGroup() == null) ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, bool_0: true, bool_1: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, bool_0: true, bool_1: true, SelectedHost.GetParentGroup(), aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac))).Count() < 1)
				{
					if (DarkMessageBox.ShowWarning("Unable to take-off from this facility due to runway/access/launcher.", "Air ops restriction", DarkDialogButton.OkCancel) == DialogResult.Cancel)
					{
						break;
					}
				}
				else
				{
					flag2 = false;
				}
				if ((SelectedHost.IsGroup ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, bool_0: false, bool_1: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : ((SelectedHost.GetParentGroup() == null) ? (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, bool_0: false, bool_1: true, SelectedHost, aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac) : (from theAirFac in Aircraft_AirOps.RunwaysInOperationOnMe_myUnitSize(aircraft, bool_0: false, bool_1: true, SelectedHost.GetParentGroup(), aircraft.CanLandVertically)
					orderby theAirFac.MaxAircraftSize, theAirFac.EffectiveRunwaySize
					select theAirFac))).Count() < 1)
				{
					if (DarkMessageBox.ShowWarning("Unable to land on this facility due to runway/access.", "Air ops restriction", DarkDialogButton.OkCancel) == DialogResult.Cancel)
					{
						break;
					}
				}
				else
				{
					flag = false;
				}
			}
			if (SelectedHost.AirOps.CanHostThisAircraft(aircraft) == AirOpsAttemptResult.Success)
			{
				SelectedHost.AirOps.AddThisAircraft(aircraft, bool_0: false);
				continue;
			}
			Client.CurrentScenario.DeleteUnitImmediately(aircraft.ObjectID, bool_0: true, "Aircraft deleted");
			if (!flag || !flag2)
			{
				DarkMessageBox.ShowWarning("无法将所有飞机添加到基地 - 超过最大飞机停放空间。", "空间不足！");
			}
			break;
		}
		Button1.Text = "添加所选项";
		Button1.Enabled = true;
		CreateSetter();
	}

	private void DisableSetter(object sender, EventArgs e)
	{
		if (ListView1.SelectedIndices.Count == 0)
		{
			return;
		}
		Button2.Text = "工作中...";
		Button2.Enabled = false;
		IEnumerable<Aircraft> source = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where((Aircraft aircraft_0) => aircraft_0.DBID == Conversions.ToInteger(ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString()));
		if (decimal.Compare(NUD1.Value, new decimal(source.Count())) < 0)
		{
			int num = source.Count() - 1;
			int num2 = Convert.ToInt32(NUD1.Value);
			for (int i = num; i >= num2; i += -1)
			{
				Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(i).ObjectID, bool_0: true, "Aircraft deleted");
			}
		}
		if (decimal.Compare(NUD1.Value, new decimal(source.Count())) > 0)
		{
			int int_ = source.Select((Aircraft AC) => AC.DBID).ElementAtOrDefault(0);
			string text = Callsigns.InstantiateProperty();
			int num3 = source.Count() + 1;
			int num4 = Convert.ToInt32(NUD1.Value);
			for (int j = num3; j <= num4; j++)
			{
				Aircraft aircraft = Client.CurrentScenario.AddNewAircraft(Client.CurrentSide, text + " " + Conversions.ToString(j), 0.0, 0.0, int_, 0, 0f);
				if (SelectedHost.AirOps.CanHostThisAircraft(aircraft) == AirOpsAttemptResult.Success)
				{
					SelectedHost.AirOps.AddThisAircraft(aircraft, bool_0: false);
					continue;
				}
				Client.CurrentScenario.DeleteUnitImmediately(aircraft.ObjectID, bool_0: true, "Aircraft deleted");
				DarkMessageBox.ShowWarning("无法将所有飞机添加到基地 - 超过最大飞机停放空间。", "空间不足！");
				break;
			}
		}
		Button2.Text = "应用";
		Button2.Enabled = true;
		CreateSetter();
	}

	private void UpdateSetter(object sender, EventArgs e)
	{
		IEnumerable<Aircraft> source = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where((Aircraft aircraft_0) => aircraft_0.DBID == Conversions.ToInteger(ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString()));
		for (int i = source.Count() - 1; i >= 0; i += -1)
		{
			Client.CurrentScenario.DeleteUnitImmediately(source.ElementAtOrDefault(i).ObjectID, bool_0: true, "Aircraft deleted");
		}
		CreateSetter();
	}

	private void InsertSetter(object sender, KeyPressEventArgs e)
	{
		DataView dataView = new DataView(_FieldSpecification);
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

	private void PrepareSetter()
	{
		DataView dataView = new DataView(_FieldSpecification);
		dataView.Sort = "Name ASC";
		DataGridView1.DataSource = dataView;
	}

	private void ReflectSetter(object object_0)
	{
		if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0)
		{
			VisitSetter();
		}
	}

	private void VisitSetter()
	{
		if (CB_FilterSizeAndTODLAD.Checked || CB_Hypothetical.SelectedIndex != 0 || CB_SubType.SelectedIndex > 0)
		{
			_FieldSpecification = Client.CurrentScenario.Cache_Aircraft_DT.Copy();
		}
		DataView dataView = new DataView(_FieldSpecification);
		dataView.Sort = "Name ASC";
		if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0 || CB_Country.SelectedIndex != 0 || CB_Hypothetical.SelectedIndex != 0 || CB_SubType.SelectedIndex != 0 || CB_FilterSizeAndTODLAD.Checked)
		{
			string text = "1=1 ";
			if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0)
			{
				string text2 = TB_Class.Text.Replace("'", "''");
				text = text + " AND Name LIKE '%" + text2 + "%' ";
			}
			if (CB_Country.SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + Conversions.ToString(CB_Country.SelectedValue);
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
			text = text.Replace("]]", "[]]");
			if (CB_FilterSizeAndTODLAD.Checked && dataView.Table.Columns.Contains("Size") && dataView.Table.Columns.Contains("RunwaySizeNeeded"))
			{
				GlobalVariables.RunwayLengthClass longestRunwayLengthClass = SelectedHost.AirOps.LongestRunwayLengthClass;
				GlobalVariables.AircraftSizeClass largestAircraftSizeForTOL = SelectedHost.AirOps.LargestAircraftSizeForTOL;
				text = text + " AND Size >= " + Conversions.ToString((byte)largestAircraftSizeForTOL) + " AND RunwaySizeNeeded <= " + Conversions.ToString((int)longestRunwayLengthClass);
			}
			dataView.RowFilter = text;
		}
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	private void RestartSetter(object sender, KeyEventArgs e)
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

	private void TestSetter(object sender, EventArgs e)
	{
		if (ListView1.SelectedIndices.Count > 0)
		{
			int value = SelectedHost.AirOps.EmbarkedAircraft_ReadOnly.Where((Aircraft aircraft_0) => string.CompareOrdinal(Conversions.ToString(aircraft_0.DBID), ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString()) == 0).Count();
			NUD1.Value = new decimal(value);
		}
		Button_RemoveAC.Visible = ListView1.SelectedIndices.Count > 0;
		Button_RemoveAC.Enabled = Button_RemoveAC.Visible;
	}

	private void StopSetter(object sender, EventArgs e)
	{
		Text = "编辑飞机" + SelectedHost.Name;
		VisitSetter();
		CreateSetter();
	}

	private void CancelSetter(object sender, EventArgs e)
	{
		if (CB_Hypothetical.Items.Count != 0 && CB_Country.Items.Count != 0)
		{
			VisitSetter();
		}
	}

	private void VerifySetter(object sender, EventArgs e)
	{
		if (CB_Hypothetical.Items.Count != 0 && CB_Country.Items.Count != 0)
		{
			VisitSetter();
		}
	}

	private void ListSetter()
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
		IEnumerator enumerator = null;
		try
		{
			enumerator = Enum.GetValues(typeof(Aircraft._AircraftType)).GetEnumerator();
			while (enumerator.MoveNext())
			{
				Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(enumerator.Current);
				if (aircraftType < (Aircraft._AircraftType)9000 || aircraftType > (Aircraft._AircraftType)9009)
				{
					string text = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(aircraftType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)aircraftType, text);
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

	private void ResolveSetter(object sender, EventArgs e)
	{
		VisitSetter();
	}

	private void PostSetter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1)
		{
			int num = Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
			if (num != 10000 && num != 10001 && num != 10002)
			{
				Client.smethod_0("Aircraft", num);
			}
		}
	}

	private void RunSetter(object sender, EventArgs e)
	{
		VisitSetter();
	}

	[CompilerGenerated]
	private bool StartSetter(Aircraft aircraft_0)
	{
		return string.CompareOrdinal(Conversions.ToString(aircraft_0.DBID), ListView1.SelectedItems[0].Tag.ToString()) == 0;
	}

	[CompilerGenerated]
	private bool AssetSetter(Aircraft aircraft_0)
	{
		return aircraft_0.DBID == Conversions.ToInteger(ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString());
	}

	[CompilerGenerated]
	private bool PrintSetter(Aircraft aircraft_0)
	{
		return aircraft_0.DBID == Conversions.ToInteger(ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString());
	}

	[CompilerGenerated]
	private bool DefineSetter(Aircraft aircraft_0)
	{
		return string.CompareOrdinal(Conversions.ToString(aircraft_0.DBID), ListView1.Items[ListView1.SelectedIndices[0]].Tag.ToString()) == 0;
	}
}
