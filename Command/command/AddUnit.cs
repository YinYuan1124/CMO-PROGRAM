using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddUnit : DarkSecondaryFormBase
{
	public delegate void theAddedUnitChangedEventHandler(ActiveUnit theAddedUnit);

	private IContainer _BaseProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel policyProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Type")]
	private DarkUIComboBox broadcasterProperty;

	[AccessedThroughProperty("BtnOK")]
	[CompilerGenerated]
	private DarkUIButton printerProperty;

	[AccessedThroughProperty("BtnCancel")]
	[CompilerGenerated]
	private DarkUIButton m_ParserProperty;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView algoProperty;

	[AccessedThroughProperty("CB_Sides")]
	[CompilerGenerated]
	private DarkUIComboBox interceptorProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton m_MessageProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	private DarkGroupBox m_AnnotationProperty;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	private DarkLabel m_IteratorProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel initializerProperty;

	[AccessedThroughProperty("CB_Country")]
	[CompilerGenerated]
	private DarkUIComboBox roleProperty;

	[AccessedThroughProperty("txt_name")]
	[CompilerGenerated]
	private DarkUITextBox m_FactoryProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Hypothetical")]
	private DarkUIComboBox _AttributeProperty;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel m_EventProperty;

	[AccessedThroughProperty("Column_Name")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn globalProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_CustomGUID")]
	private DarkUITextBox m_WorkerProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Name2")]
	private DataGridViewTextBoxColumn accountProperty;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private DarkLabel stateProperty;

	[AccessedThroughProperty("Name3")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_AuthenticationProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("FullName")]
	private DataGridViewLinkColumn m_InfoProperty;

	[AccessedThroughProperty("ShortName")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn helperProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Country")]
	private DataGridViewTextBoxColumn mapperProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Retired")]
	private DataGridViewTextBoxColumn getterProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Hypothetical")]
	private DataGridViewCheckBoxColumn producerProperty;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel structImporter;

	[AccessedThroughProperty("CB_SubType")]
	[CompilerGenerated]
	private DarkUIComboBox merchantImporter;

	[AccessedThroughProperty("CB_Decoy_Unarmed")]
	[CompilerGenerated]
	private DarkUICheckBox _CallbackImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_decoy_Immobile")]
	private DarkUICheckBox decoratorImporter;

	private DataTable m_ProcessImporter;

	private DateTime _ThreadImporter;

	public string string_0;

	public static bool Unarmed;

	[CompilerGenerated]
	private static theAddedUnitChangedEventHandler m_RuleImporter;

	private static ActiveUnit collectionImporter;

	[CompilerGenerated]
	private static bool instanceImporter;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return policyProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			policyProperty = value;
		}
	}

	internal DarkUIComboBox CB_Type
	{
		[CompilerGenerated]
		get
		{
			return broadcasterProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateTests;
			DarkUIComboBox darkUIComboBox = broadcasterProperty;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			broadcasterProperty = value;
			darkUIComboBox = broadcasterProperty;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton BtnOK
	{
		[CompilerGenerated]
		get
		{
			return printerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchTests;
			DarkUIButton darkUIButton = printerProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			printerProperty = value;
			darkUIButton = printerProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return m_ParserProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitTests;
			DarkUIButton parserProperty = m_ParserProperty;
			if (parserProperty != null)
			{
				parserProperty.Click -= value2;
			}
			m_ParserProperty = value;
			parserProperty = m_ParserProperty;
			if (parserProperty != null)
			{
				parserProperty.Click += value2;
			}
		}
	}

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return algoProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = ConcatTests;
			EventHandler value3 = FindTests;
			DataGridViewCellEventHandler value4 = CompareTests;
			DarkDataGridView darkDataGridView = algoProperty;
			if (darkDataGridView != null)
			{
				darkDataGridView.KeyPress -= value2;
				darkDataGridView.SelectionChanged -= value3;
				darkDataGridView.CellContentClick -= value4;
			}
			algoProperty = value;
			darkDataGridView = algoProperty;
			if (darkDataGridView != null)
			{
				darkDataGridView.KeyPress += value2;
				darkDataGridView.SelectionChanged += value3;
				darkDataGridView.CellContentClick += value4;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_Sides
	{
		[CompilerGenerated]
		get
		{
			return interceptorProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interceptorProperty = value;
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return m_MessageProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckTests;
			DarkUIButton messageProperty = m_MessageProperty;
			if (messageProperty != null)
			{
				messageProperty.Click -= value2;
			}
			m_MessageProperty = value;
			messageProperty = m_MessageProperty;
			if (messageProperty != null)
			{
				messageProperty.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TB_Class")]
	internal DarkUITextBox TB_Class
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkGroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationProperty = value;
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IteratorProperty = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return initializerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			initializerProperty = value;
		}
	}

	internal DarkUIComboBox CB_Country
	{
		[CompilerGenerated]
		get
		{
			return roleProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateTests;
			DarkUIComboBox darkUIComboBox = roleProperty;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			roleProperty = value;
			darkUIComboBox = roleProperty;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUITextBox txt_name
	{
		[CompilerGenerated]
		get
		{
			return m_FactoryProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = ChangeTests;
			DarkUITextBox factoryProperty = m_FactoryProperty;
			if (factoryProperty != null)
			{
				factoryProperty.TextChanged -= value2;
			}
			m_FactoryProperty = value;
			factoryProperty = m_FactoryProperty;
			if (factoryProperty != null)
			{
				factoryProperty.TextChanged += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return _AttributeProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableTests;
			DarkUIComboBox attributeProperty = _AttributeProperty;
			if (attributeProperty != null)
			{
				attributeProperty.SelectionChangeCommitted -= value2;
			}
			_AttributeProperty = value;
			attributeProperty = _AttributeProperty;
			if (attributeProperty != null)
			{
				attributeProperty.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_EventProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventProperty = value;
		}
	}

	internal DataGridViewTextBoxColumn Column_Name
	{
		[CompilerGenerated]
		get
		{
			return globalProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			globalProperty = value;
		}
	}

	internal DarkUITextBox TB_CustomGUID
	{
		[CompilerGenerated]
		get
		{
			return m_WorkerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WorkerProperty = value;
		}
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return stateProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stateProperty = value;
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal DataGridViewTextBoxColumn ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewLinkColumn FullName
	{
		[CompilerGenerated]
		get
		{
			return m_InfoProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InfoProperty = value;
		}
	}

	internal DataGridViewTextBoxColumn ShortName
	{
		[CompilerGenerated]
		get
		{
			return helperProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			helperProperty = value;
		}
	}

	internal DataGridViewTextBoxColumn Country
	{
		[CompilerGenerated]
		get
		{
			return mapperProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mapperProperty = value;
		}
	}

	[field: AccessedThroughProperty("IOC")]
	internal DataGridViewTextBoxColumn IOC
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Retired
	{
		[CompilerGenerated]
		get
		{
			return getterProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			getterProperty = value;
		}
	}

	internal DataGridViewCheckBoxColumn Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return producerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			producerProperty = value;
		}
	}

	[field: AccessedThroughProperty("CountryNumber")]
	internal DataGridViewTextBoxColumn CountryNumber
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return structImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			structImporter = value;
		}
	}

	internal DarkUIComboBox CB_SubType
	{
		[CompilerGenerated]
		get
		{
			return merchantImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopTests;
			DarkUIComboBox darkUIComboBox = merchantImporter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			merchantImporter = value;
			darkUIComboBox = merchantImporter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUICheckBox CB_Decoy_Unarmed
	{
		[CompilerGenerated]
		get
		{
			return _CallbackImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = InsertTests;
			DarkUICheckBox callbackImporter = _CallbackImporter;
			if (callbackImporter != null)
			{
				callbackImporter.CheckedChanged -= value2;
			}
			_CallbackImporter = value;
			callbackImporter = _CallbackImporter;
			if (callbackImporter != null)
			{
				callbackImporter.CheckedChanged += value2;
			}
		}
	}

	internal DarkUICheckBox CB_decoy_Immobile
	{
		[CompilerGenerated]
		get
		{
			return decoratorImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			decoratorImporter = value;
		}
	}

	public static ActiveUnit theAddedUnit
	{
		get
		{
			return collectionImporter;
		}
		set
		{
			collectionImporter = value;
			m_RuleImporter?.Invoke(collectionImporter);
		}
	}

	public static bool CalledFromAirOps
	{
		[CompilerGenerated]
		get
		{
			return instanceImporter;
		}
		[CompilerGenerated]
		set
		{
			instanceImporter = value;
		}
	}

	public static event theAddedUnitChangedEventHandler theAddedUnitChanged
	{
		[CompilerGenerated]
		add
		{
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler = m_RuleImporter;
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler2;
			do
			{
				theAddedUnitChangedEventHandler2 = theAddedUnitChangedEventHandler;
				theAddedUnitChangedEventHandler value2 = (theAddedUnitChangedEventHandler)Delegate.Combine(theAddedUnitChangedEventHandler2, value);
				theAddedUnitChangedEventHandler = Interlocked.CompareExchange(ref m_RuleImporter, value2, theAddedUnitChangedEventHandler2);
			}
			while ((object)theAddedUnitChangedEventHandler != theAddedUnitChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler = m_RuleImporter;
			theAddedUnitChangedEventHandler theAddedUnitChangedEventHandler2;
			do
			{
				theAddedUnitChangedEventHandler2 = theAddedUnitChangedEventHandler;
				theAddedUnitChangedEventHandler value2 = (theAddedUnitChangedEventHandler)Delegate.Remove(theAddedUnitChangedEventHandler2, value);
				theAddedUnitChangedEventHandler = Interlocked.CompareExchange(ref m_RuleImporter, value2, theAddedUnitChangedEventHandler2);
			}
			while ((object)theAddedUnitChangedEventHandler != theAddedUnitChangedEventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal DataGridViewTextBoxColumn DestroyInterpreter()
	{
		return accountProperty;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ComputeInterpreter(DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0)
	{
		accountProperty = dataGridViewTextBoxColumn_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal DataGridViewTextBoxColumn LogoutInterpreter()
	{
		return m_AuthenticationProperty;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ViewInterpreter(DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0)
	{
		m_AuthenticationProperty = dataGridViewTextBoxColumn_0;
	}

	static AddUnit()
	{
		Unarmed = false;
		CalledFromAirOps = false;
	}

	public AddUnit()
	{
		base.FormClosing += EnableTests;
		base.Shown += SetTests;
		base.KeyDown += CreateTests;
		base.FormClosed += ReadTests;
		base.Load += UpdateTests;
		m_ProcessImporter = new DataTable();
		_ThreadImporter = default(DateTime);
		string_0 = null;
		IncludeTests();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && _BaseProperty != null)
		{
			_BaseProperty.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void IncludeTests()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		Label1 = new DarkLabel();
		CB_Type = new DarkUIComboBox();
		Label2 = new DarkLabel();
		BtnOK = new DarkUIButton();
		BtnCancel = new DarkUIButton();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		FullName = new DataGridViewLinkColumn();
		ShortName = new DataGridViewTextBoxColumn();
		Country = new DataGridViewTextBoxColumn();
		IOC = new DataGridViewTextBoxColumn();
		Retired = new DataGridViewTextBoxColumn();
		Hypothetical = new DataGridViewCheckBoxColumn();
		CountryNumber = new DataGridViewTextBoxColumn();
		Label3 = new DarkLabel();
		CB_Sides = new DarkUIComboBox();
		Button3 = new DarkUIButton();
		TB_Class = new DarkUITextBox();
		GroupBox1 = new DarkGroupBox();
		DarkLabel1 = new DarkLabel();
		CB_SubType = new DarkUIComboBox();
		CB_Hypothetical = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_Country = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		txt_name = new DarkUITextBox();
		Label6 = new DarkLabel();
		TB_CustomGUID = new DarkUITextBox();
		CB_Decoy_Unarmed = new DarkUICheckBox();
		CB_decoy_Immobile = new DarkUICheckBox();
		((ISupportInitialize)DataGridView1).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(9, 15);
		Label1.Name = "Label1";
		Label1.Size = new Size(53, 25);
		Label1.TabIndex = 0;
		Label1.Text = "类型：";
		CB_Type.BackColor = Color.Transparent;
		CB_Type.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Type.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Type.Font = new Font("Segoe UI", 7f);
		CB_Type.FormattingEnabled = true;
		CB_Type.Items.AddRange(new object[4] { "飞机", "水面舰艇", "潜艇", "设施" });
		CB_Type.Location = new Point(54, 13);
		CB_Type.Name = "CB_Type";
		CB_Type.Size = new Size(326, 27);
		CB_Type.TabIndex = 1;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(9, 67);
		Label2.Name = "Label2";
		Label2.Size = new Size(63, 25);
		Label2.TabIndex = 2;
		Label2.Text = "名称:";
		BtnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BtnOK.BackColor = Color.Transparent;
		BtnOK.DialogResult = DialogResult.None;
		BtnOK.Font = new Font("Segoe UI", 10f);
		BtnOK.ForeColor = SystemColors.Control;
		BtnOK.Location = new Point(12, 585);
		BtnOK.Name = "BtnOK";
		BtnOK.RoundRadius = 0;
		BtnOK.Size = new Size(75, 23);
		BtnOK.TabIndex = 4;
		BtnOK.Text = "确定";
		BtnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BtnCancel.BackColor = Color.Transparent;
		BtnCancel.DialogResult = DialogResult.None;
		BtnCancel.Font = new Font("Segoe UI", 10f);
		BtnCancel.ForeColor = SystemColors.Control;
		BtnCancel.Location = new Point(678, 585);
		BtnCancel.Name = "BtnCancel";
		BtnCancel.RoundRadius = 0;
		BtnCancel.Size = new Size(75, 23);
		BtnCancel.TabIndex = 5;
		BtnCancel.Text = "取消";
		DataGridView1.AllowUserToAddRows = false;
		DataGridView1.AllowUserToDeleteRows = false;
		DataGridView1.AllowUserToOrderColumns = true;
		DataGridView1.AllowUserToResizeColumns = false;
		DataGridView1.AllowUserToResizeRows = false;
		DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DataGridView1.BackgroundColor = Color.FromArgb(60, 63, 65);
		DataGridView1.BorderStyle = BorderStyle.Fixed3D;
		DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
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
		DataGridView1.Columns.AddRange(ID, FullName, ShortName, Country, IOC, Retired, Hypothetical, CountryNumber);
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
		DataGridView1.Location = new Point(12, 223);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.ReadOnly = true;
		DataGridView1.RowHeadersVisible = false;
		DataGridView1.RowHeadersWidth = 62;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.Size = new Size(741, 356);
		DataGridView1.TabIndex = 6;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.MinimumWidth = 8;
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		ID.Width = 150;
		FullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		FullName.DataPropertyName = "LongName";
		FullName.HeaderText = "平台";
		FullName.LinkColor = Color.LightBlue;
		FullName.MinimumWidth = 8;
		FullName.Name = "FullName";
		FullName.ReadOnly = true;
		FullName.Resizable = DataGridViewTriState.True;
		FullName.SortMode = DataGridViewColumnSortMode.Automatic;
		FullName.Width = 230;
		ShortName.DataPropertyName = "Name";
		ShortName.HeaderText = "简称";
		ShortName.MinimumWidth = 8;
		ShortName.Name = "ShortName";
		ShortName.ReadOnly = true;
		ShortName.Visible = false;
		ShortName.Width = 150;
		Country.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Country.DataPropertyName = "CountryString";
		Country.HeaderText = "国家";
		Country.MinimumWidth = 8;
		Country.Name = "Country";
		Country.ReadOnly = true;
		Country.Width = 109;
		IOC.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		IOC.DataPropertyName = "YearCommissioned";
		IOC.HeaderText = "从";
		IOC.MinimumWidth = 8;
		IOC.Name = "IOC";
		IOC.ReadOnly = true;
		IOC.Width = 88;
		Retired.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Retired.DataPropertyName = "YearDecommissioned";
		Retired.HeaderText = "直到";
		Retired.MinimumWidth = 8;
		Retired.Name = "Retired";
		Retired.ReadOnly = true;
		Retired.Width = 82;
		Hypothetical.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
		Hypothetical.DataPropertyName = "Hypothetical";
		Hypothetical.FalseValue = "False";
		Hypothetical.HeaderText = "假想";
		Hypothetical.MinimumWidth = 8;
		Hypothetical.Name = "Hypothetical";
		Hypothetical.ReadOnly = true;
		Hypothetical.Resizable = DataGridViewTriState.True;
		Hypothetical.SortMode = DataGridViewColumnSortMode.Automatic;
		Hypothetical.TrueValue = "True";
		Hypothetical.Width = 90;
		CountryNumber.DataPropertyName = "OperatorCountry";
		CountryNumber.HeaderText = "国家";
		CountryNumber.MinimumWidth = 8;
		CountryNumber.Name = "CountryNumber";
		CountryNumber.ReadOnly = true;
		CountryNumber.Visible = false;
		CountryNumber.Width = 150;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(9, 43);
		Label3.Name = "Label3";
		Label3.Size = new Size(50, 25);
		Label3.TabIndex = 7;
		Label3.Text = "分方：";
		CB_Sides.BackColor = Color.Transparent;
		CB_Sides.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Sides.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Sides.Font = new Font("Segoe UI", 7f);
		CB_Sides.FormattingEnabled = true;
		CB_Sides.Items.AddRange(new object[1] { "飞机" });
		CB_Sides.Location = new Point(54, 38);
		CB_Sides.Name = "CB_Sides";
		CB_Sides.Size = new Size(326, 27);
		CB_Sides.TabIndex = 8;
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 10f);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(386, 38);
		Button3.Name = "Button3";
		Button3.RoundRadius = 0;
		Button3.Size = new Size(83, 21);
		Button3.TabIndex = 9;
		Button3.Text = "编辑分方...";
		TB_Class.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Class.AutoCompleteCustomSource = null;
		TB_Class.AutoCompleteMode = AutoCompleteMode.None;
		TB_Class.AutoCompleteSource = AutoCompleteSource.None;
		TB_Class.BackColor = Color.Transparent;
		TB_Class.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TB_Class.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Class.Image = null;
		TB_Class.Lines = null;
		TB_Class.Location = new Point(88, 15);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		TB_Class.Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = ScrollBars.None;
		TB_Class.SelectionStart = 0;
		TB_Class.Size = new Size(132, 22);
		TB_Class.TabIndex = 10;
		TB_Class.TextAlign = HorizontalAlignment.Left;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		GroupBox1.Controls.Add(DarkLabel1);
		GroupBox1.Controls.Add(CB_SubType);
		GroupBox1.Controls.Add(CB_Hypothetical);
		GroupBox1.Controls.Add(Label7);
		GroupBox1.Controls.Add(CB_Country);
		GroupBox1.Controls.Add(Label5);
		GroupBox1.Controls.Add(Label4);
		GroupBox1.Controls.Add(TB_Class);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(12, 89);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(457, 94);
		GroupBox1.TabIndex = 12;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "过滤...";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(7, 49);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(84, 25);
		DarkLabel1.TabIndex = 20;
		DarkLabel1.Text = "子类型：";
		CB_SubType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_SubType.BackColor = Color.Transparent;
		CB_SubType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_SubType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_SubType.Font = new Font("Segoe UI", 7f);
		CB_SubType.FormattingEnabled = true;
		CB_SubType.Location = new Point(88, 43);
		CB_SubType.Name = "CB_SubType";
		CB_SubType.Size = new Size(201, 27);
		CB_SubType.TabIndex = 19;
		CB_Hypothetical.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Hypothetical.BackColor = Color.Transparent;
		CB_Hypothetical.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Hypothetical.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Hypothetical.Font = new Font("Segoe UI", 7f);
		CB_Hypothetical.FormattingEnabled = true;
		CB_Hypothetical.Items.AddRange(new object[1] { "飞机" });
		CB_Hypothetical.Location = new Point(88, 67);
		CB_Hypothetical.Name = "CB_Hypothetical";
		CB_Hypothetical.Size = new Size(363, 27);
		CB_Hypothetical.TabIndex = 18;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(4, 73);
		Label7.Name = "Label7";
		Label7.Size = new Size(116, 25);
		Label7.TabIndex = 17;
		Label7.Text = "假想：";
		CB_Country.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Country.BackColor = Color.Transparent;
		CB_Country.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Country.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Country.Font = new Font("Segoe UI", 7f);
		CB_Country.FormattingEnabled = true;
		CB_Country.Items.AddRange(new object[1] { "飞机" });
		CB_Country.Location = new Point(278, 15);
		CB_Country.Name = "CB_Country";
		CB_Country.Size = new Size(173, 27);
		CB_Country.TabIndex = 13;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(226, 20);
		Label5.Name = "Label5";
		Label5.Size = new Size(79, 25);
		Label5.TabIndex = 12;
		Label5.Text = "国家：";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(7, 20);
		Label4.Name = "Label4";
		Label4.Size = new Size(56, 25);
		Label4.TabIndex = 11;
		Label4.Text = "类别：";
		txt_name.AutoCompleteCustomSource = null;
		txt_name.AutoCompleteMode = AutoCompleteMode.None;
		txt_name.AutoCompleteSource = AutoCompleteSource.None;
		txt_name.BackColor = Color.Transparent;
		txt_name.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		txt_name.ForeColor = Color.FromArgb(189, 189, 189);
		txt_name.Image = null;
		txt_name.Lines = null;
		txt_name.Location = new Point(54, 64);
		txt_name.MaxLength = 32767;
		txt_name.Multiline = false;
		txt_name.Name = "txt_name";
		txt_name.ReadOnly = false;
		txt_name.ScrollBars = ScrollBars.None;
		txt_name.SelectionStart = 0;
		txt_name.Size = new Size(415, 24);
		txt_name.TabIndex = 3;
		txt_name.TextAlign = HorizontalAlignment.Left;
		txt_name.UseSystemPasswordChar = false;
		txt_name.WatermarkText = "";
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(9, 196);
		Label6.Name = "Label6";
		Label6.Size = new Size(125, 25);
		Label6.TabIndex = 13;
		Label6.Text = "自定义GUID：";
		TB_CustomGUID.AutoCompleteCustomSource = null;
		TB_CustomGUID.AutoCompleteMode = AutoCompleteMode.None;
		TB_CustomGUID.AutoCompleteSource = AutoCompleteSource.None;
		TB_CustomGUID.BackColor = Color.Transparent;
		TB_CustomGUID.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TB_CustomGUID.ForeColor = Color.FromArgb(189, 189, 189);
		TB_CustomGUID.Image = null;
		TB_CustomGUID.Lines = null;
		TB_CustomGUID.Location = new Point(94, 189);
		TB_CustomGUID.MaxLength = 32767;
		TB_CustomGUID.Multiline = false;
		TB_CustomGUID.Name = "TB_CustomGUID";
		TB_CustomGUID.ReadOnly = false;
		TB_CustomGUID.ScrollBars = ScrollBars.None;
		TB_CustomGUID.SelectionStart = 0;
		TB_CustomGUID.Size = new Size(369, 22);
		TB_CustomGUID.TabIndex = 14;
		TB_CustomGUID.TextAlign = HorizontalAlignment.Left;
		TB_CustomGUID.UseSystemPasswordChar = false;
		TB_CustomGUID.WatermarkText = "";
		CB_Decoy_Unarmed.BackColor = Color.Transparent;
		CB_Decoy_Unarmed.Checked = false;
		CB_Decoy_Unarmed.Cursor = Cursors.Hand;
		CB_Decoy_Unarmed.ForeColor = Color.FromArgb(209, 209, 209);
		CB_Decoy_Unarmed.Location = new Point(554, 43);
		CB_Decoy_Unarmed.Name = "CB_Decoy_Unarmed";
		CB_Decoy_Unarmed.Size = new Size(129, 18);
		CB_Decoy_Unarmed.TabIndex = 16;
		CB_Decoy_Unarmed.Text = "无挂载武器";
		CB_decoy_Immobile.BackColor = Color.Transparent;
		CB_decoy_Immobile.Checked = false;
		CB_decoy_Immobile.Cursor = Cursors.Hand;
		CB_decoy_Immobile.ForeColor = Color.FromArgb(209, 209, 209);
		CB_decoy_Immobile.Location = new Point(554, 67);
		CB_decoy_Immobile.Name = "CB_decoy_Immobile";
		CB_decoy_Immobile.Size = new Size(129, 18);
		CB_decoy_Immobile.TabIndex = 17;
		CB_decoy_Immobile.Text = "不可移动";
		CB_decoy_Immobile.Visible = false;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(765, 620);
		base.Controls.Add(CB_decoy_Immobile);
		base.Controls.Add(CB_Decoy_Unarmed);
		base.Controls.Add(TB_CustomGUID);
		base.Controls.Add(Label6);
		base.Controls.Add(GroupBox1);
		base.Controls.Add(Button3);
		base.Controls.Add(CB_Sides);
		base.Controls.Add(Label3);
		base.Controls.Add(DataGridView1);
		base.Controls.Add(BtnCancel);
		base.Controls.Add(BtnOK);
		base.Controls.Add(txt_name);
		base.Controls.Add(Label2);
		base.Controls.Add(CB_Type);
		base.Controls.Add(Label1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddUnit";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "添加新单元";
		((ISupportInitialize)DataGridView1).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void SearchTests(object sender, EventArgs e)
	{
		if (Operators.CompareString(txt_name.Text, "", TextCompare: true) == 0)
		{
			DarkMessageBox.ShowWarning("您需要为新单元提供名称。", "No name?");
		}
		else
		{
			if (DataGridView1.SelectedRows.Count == 0)
			{
				return;
			}
			if (!string.IsNullOrEmpty(TB_CustomGUID.Text))
			{
				if (Misc.CreateRequest(TB_CustomGUID.Text, ' '))
				{
					TB_CustomGUID.Text = TB_CustomGUID.Text.Replace(" ", "-");
				}
				string_0 = TB_CustomGUID.Text;
			}
			Geopoint_Struct mapperCode = ItemExporter.ConnectInterruptibleTemplate.MainForm.mapperCode;
			switch (CB_Type.SelectedIndex)
			{
			case 0:
			{
				new DataTable();
				int int_ = Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				Scenario currentScenario = Client.CurrentScenario;
				bool bool_ = false;
				Scenario scenario_ = null;
				Aircraft aircraft_ = null;
				int int_2 = 0;
				bool bool_2 = false;
				if (DBFunctions.LoadoutsForThisAircraft_DT(int_, null, ref sqliteConnection_, currentScenario, ref bool_, ref scenario_, ref aircraft_, ref int_2, ref bool_2).Rows.Count == 0)
				{
					theAddedUnit = Client.CurrentScenario.AddNewAircraft(Client.CurrentScenario.Sides_ReadOnly[CB_Sides.SelectedIndex], txt_name.Text, mapperCode.Longitude, mapperCode.Latitude, Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString()), 0, 1000f, (Module_Unit.Unit.RemoteSimEntityTypeEnum)Conversions.ToShort(string_0));
					Close();
					return;
				}
				ItemExporter.ConnectInterruptibleTemplate.SelectLoadout.AircraftName = txt_name.Text;
				ItemExporter.ConnectInterruptibleTemplate.SelectLoadout.AircraftID = Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
				ItemExporter.ConnectInterruptibleTemplate.SelectLoadout.AircraftSide = Client.CurrentScenario.Sides_ReadOnly[CB_Sides.SelectedIndex];
				ItemExporter.ConnectInterruptibleTemplate.SelectLoadout.Show();
				return;
			}
			case 1:
				try
				{
					theAddedUnit = Client.CurrentScenario.AddNewShip(Client.CurrentScenario.Sides_ReadOnly[CB_Sides.SelectedIndex], Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapperCode.Longitude, mapperCode.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					DarkMessageBox.ShowError("错误：" + ex8.Message, "Error");
					ProjectData.ClearProjectError();
					return;
				}
				break;
			case 2:
				try
				{
					theAddedUnit = Client.CurrentScenario.AddNewSubmarine(Client.CurrentScenario.Sides_ReadOnly[CB_Sides.SelectedIndex], Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapperCode.Longitude, mapperCode.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					DarkMessageBox.ShowError("错误：" + ex6.Message, "Error");
					ProjectData.ClearProjectError();
					return;
				}
				break;
			case 3:
				try
				{
					theAddedUnit = Client.CurrentScenario.AddNewFacility(Client.CurrentScenario.Sides_ReadOnly[CB_Sides.SelectedIndex], Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapperCode.Longitude, mapperCode.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					DarkMessageBox.ShowError("错误：" + ex4.Message, "Error");
					ProjectData.ClearProjectError();
					return;
				}
				break;
			case 4:
				try
				{
					theAddedUnit = Client.CurrentScenario.AddNewVehicle(Client.CurrentScenario.Sides_ReadOnly[CB_Sides.SelectedIndex], Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString()), txt_name.Text, mapperCode.Longitude, mapperCode.Latitude, bool_0: false, Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, string_0);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Interaction.MsgBox("错误：" + ex2.Message);
					ProjectData.ClearProjectError();
					return;
				}
				break;
			}
			if (Client.AddingDecoyPlatform & Unarmed)
			{
				collectionImporter.Decoy = true;
				collectionImporter.Weaponry.Disarm();
			}
			if (Client.CurrentScenario.Sides_ReadOnly.Length == 1)
			{
				Client.CurrentSide = Client.CurrentScenario.Sides_ReadOnly[0];
			}
			Close();
		}
	}

	private void EnableTests(object sender, FormClosingEventArgs e)
	{
		Client.CurrentUserAction = Client.UserAction.None;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ChangeTests(object object_0)
	{
		BtnOK.Enabled = Operators.CompareString(txt_name.Text, "", TextCompare: true) != 0;
	}

	private void InitTests(object sender, EventArgs e)
	{
		Close();
	}

	private void CheckTests(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.Sides.Show();
	}

	public void RefreshSides()
	{
		CB_Sides.Items.Clear();
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			CB_Sides.Items.Add(side.Name);
		}
		if (CB_Sides.Items.Count > 0)
		{
			CB_Sides.SelectedIndex = Array.IndexOf(Client.CurrentScenario.Sides_ReadOnly, Client.CurrentSide);
		}
		BtnOK.Enabled = (CB_Sides.Items.Count > 0) & !Information.IsNothing(CB_Sides.SelectedIndex);
	}

	private void ConcatTests(object sender, KeyPressEventArgs e)
	{
		DataView dataView = new DataView(m_ProcessImporter);
		dataView.Sort = "LongName ASC";
		dataView.RowFilter = "LongName LIKE '" + Conversions.ToString(e.KeyChar) + "%'";
		if (dataView.Count <= 0)
		{
			return;
		}
		int num = Conversions.ToInteger(dataView[0][0].ToString());
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

	private void InterruptTests(object object_0)
	{
		RemoveTests();
	}

	private void RemoveTests()
	{
		Client._ProxyRequest = (byte)CB_Type.SelectedIndex;
		Client.m_ReaderRequest = Conversions.ToInteger(CB_Country.SelectedValue);
		Client.facadeRequest = TB_Class.Text.Replace("'", "''");
		switch (CB_Type.SelectedIndex)
		{
		default:
			return;
		case 0:
			m_ProcessImporter = Client.CurrentScenario.Cache_Aircraft_DT;
			break;
		case 1:
			m_ProcessImporter = Client.CurrentScenario.Cache_Ships_DT;
			break;
		case 2:
			m_ProcessImporter = Client.CurrentScenario.Cache_Subs_DT;
			break;
		case 3:
			m_ProcessImporter = Client.CurrentScenario.Cache_Facilities_DT;
			break;
		case 4:
			m_ProcessImporter = Client.CurrentScenario.Cache_GroundUnits_DT;
			break;
		}
		if (m_ProcessImporter.Rows.Count == 0)
		{
			return;
		}
		DataView dataView = new DataView(m_ProcessImporter);
		dataView.Sort = "LongName ASC";
		if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0 || CB_Country.SelectedIndex != 0 || CB_Hypothetical.SelectedIndex != 0 || CB_SubType.SelectedIndex != 0)
		{
			string text = "1=1 ";
			if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0)
			{
				string text2 = TB_Class.Text.Replace("'", "''");
				text = text + " AND LongName LIKE '%" + text2 + "%' ";
			}
			if (CB_Country.SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + Conversions.ToString(Conversions.ToInteger(CB_Country.SelectedValue));
			}
			if (CB_SubType.SelectedIndex > 0 && CB_SubType.SelectedIndex > 0)
			{
				text = ((CB_Type.SelectedIndex == 3) ? (text + " AND category=" + CB_SubType.SelectedValue.ToString()) : ((CB_Type.SelectedIndex == 4) ? (text + " AND category=" + CB_SubType.SelectedValue.ToString()) : (text + " AND type=" + CB_SubType.SelectedValue.ToString())));
			}
			if (CB_Hypothetical.SelectedIndex == 1)
			{
				text += " AND Hypothetical=FALSE";
			}
			else if (CB_Hypothetical.SelectedIndex == 2)
			{
				text += " AND Hypothetical=TRUE";
			}
			text = text.Replace("[", "[[");
			text = text.Replace("]", "]]");
			text = text.Replace("[[", "[[]");
			string text5 = (dataView.RowFilter = text.Replace("]]", "[]]"));
			string text3 = text5;
			text = text3;
		}
		DataGridView1.SuspendLayout();
		DataGridView1.Enabled = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		DataGridView1.Refresh();
		DataGridView1.Enabled = true;
		DataGridView1.ResumeLayout();
	}

	private void FindTests(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count > 0)
		{
			txt_name.Text = Misc.ReadRequest(Conversions.ToString(DataGridView1.SelectedRows[0].Cells[2].Value));
		}
	}

	private void SetTests(object sender, EventArgs e)
	{
		_ThreadImporter = DateTime.UtcNow;
		TB_Class.TextChanged += InterruptTests;
		DataGridView1.AutoGenerateColumns = false;
		if (Client.CurrentScenario.Cache_GroundUnits_DT.Rows.Count > 0)
		{
			CB_Type.Items.Add("地面单元");
		}
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		CB_Country.DataSource = cache_OperatorCountries_DT;
		CB_Country.DisplayMember = "Description";
		CB_Country.ValueMember = "ID";
		CB_Country.SelectedIndex = 0;
		CB_Hypothetical.Items.Clear();
		CB_Hypothetical.Items.Add("显示所有平台，包括真实和假想");
		CB_Hypothetical.Items.Add("仅显示真实平台");
		CB_Hypothetical.Items.Add("仅显示假想平台");
		CB_Hypothetical.SelectedIndex = 0;
		BtnOK.Enabled = Operators.CompareString(txt_name.Text, "", TextCompare: true) != 0;
		CB_Type.SelectedIndex = 0;
		BtnOK.Enabled = false;
		RefreshSides();
		if (Client.m_ReaderRequest.HasValue | !string.IsNullOrEmpty(Client.facadeRequest) | Client._ProxyRequest.HasValue)
		{
			if (Client.m_ReaderRequest.HasValue)
			{
				CB_Country.SelectedValue = Client.m_ReaderRequest;
			}
			if (Client._ProxyRequest.HasValue)
			{
				try
				{
					CB_Type.SelectedIndex = Client._ProxyRequest.Value;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					CB_Type.SelectedIndex = 0;
					ProjectData.ClearProjectError();
				}
			}
			if (!string.IsNullOrEmpty(Client.facadeRequest))
			{
				TB_Class.Text = Client.facadeRequest;
			}
		}
		FillTests();
		RemoveTests();
	}

	private void FillTests()
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
		switch (CB_Type.SelectedIndex)
		{
		default:
			return;
		case 0:
		{
			IEnumerator enumerator5 = null;
			try
			{
				enumerator5 = Enum.GetValues(typeof(Aircraft._AircraftType)).GetEnumerator();
				while (enumerator5.MoveNext())
				{
					Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(enumerator5.Current);
					string text5 = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(aircraftType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)aircraftType, text5);
					}
				}
			}
			finally
			{
				if (enumerator5 is IDisposable)
				{
					(enumerator5 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 1:
		{
			IEnumerator enumerator4 = null;
			try
			{
				enumerator4 = Enum.GetValues(typeof(Ship._ShipType)).GetEnumerator();
				while (enumerator4.MoveNext())
				{
					Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(enumerator4.Current);
					string text4 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(shipType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)shipType, shipType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)shipType, text4);
					}
				}
			}
			finally
			{
				if (enumerator4 is IDisposable)
				{
					(enumerator4 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 2:
		{
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = Enum.GetValues(typeof(Submarine._SubmarineType)).GetEnumerator();
				while (enumerator3.MoveNext())
				{
					Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(enumerator3.Current);
					string text3 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(submarineType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)submarineType, submarineType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)submarineType, text3);
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
			break;
		}
		case 3:
		{
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = Enum.GetValues(typeof(Facility._FacilityCategory)).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(enumerator2.Current);
					string text2 = Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)facilityCategory, facilityCategory.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)facilityCategory, text2);
					}
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
		case 4:
		{
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
		CB_SubType.SelectedIndex = 0;
	}

	private void CalculateTests(object sender, EventArgs e)
	{
		TB_Class.Clear();
		FillTests();
		RemoveTests();
	}

	private void PopTests(object sender, EventArgs e)
	{
		RemoveTests();
	}

	private void InstantiateTests(object sender, EventArgs e)
	{
		RemoveTests();
	}

	private void CreateTests(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void CompareTests(object sender, DataGridViewCellEventArgs e)
	{
		if (DateTime.UtcNow - _ThreadImporter >= TimeSpan.FromMilliseconds(500.0) && e.RowIndex != -1 && (object)DataGridView1.Columns[e.ColumnIndex].CellType == typeof(DataGridViewLinkCell))
		{
			int int_ = Conversions.ToInteger(DataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
			string text = null;
			switch (CB_Type.SelectedIndex)
			{
			case 0:
				text = "Aircraft";
				break;
			case 1:
				text = "Ship";
				break;
			case 2:
				text = "Submarine";
				break;
			case 3:
				text = "Facility";
				break;
			case 4:
				text = "GroundUnit";
				break;
			}
			Client.smethod_0(text, int_);
		}
	}

	private void ReadTests(object sender, FormClosedEventArgs e)
	{
		TB_Class.TextChanged -= InterruptTests;
		CalledFromAirOps = false;
	}

	private void DisableTests(object sender, EventArgs e)
	{
		RemoveTests();
	}

	private void UpdateTests(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Client.AddingDecoyPlatform)
		{
			Text = "添加新诱饵单元";
			CB_Decoy_Unarmed.Visible = true;
			CB_Decoy_Unarmed.Checked = true;
			Unarmed = true;
		}
		else
		{
			CB_Decoy_Unarmed.Visible = false;
			Unarmed = false;
		}
	}

	private void InsertTests(object object_0)
	{
		Unarmed = CB_Decoy_Unarmed.Checked;
	}
}
