using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditEvent : DarkSecondaryFormBase
{
	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer _InterceptorReponse;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox m_MessageReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel productReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_Triggers")]
	private DarkDataGridView iteratorReponse;

	[AccessedThroughProperty("DGV_Conditions")]
	[CompilerGenerated]
	private DarkDataGridView initializerReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_Actions")]
	private DarkDataGridView factoryReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel attributeReponse;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _EventReponse;

	[AccessedThroughProperty("CB_Triggers")]
	[CompilerGenerated]
	private DarkUIComboBox globalReponse;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton m_WorkerReponse;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton m_AccountReponse;

	[AccessedThroughProperty("CB_Conditions")]
	[CompilerGenerated]
	private DarkUIComboBox m_StateReponse;

	[AccessedThroughProperty("Button4")]
	[CompilerGenerated]
	private DarkUIButton authenticationReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Button5")]
	private DarkUIButton m_ParamsReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Actions")]
	private DarkUIComboBox infoReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Button6")]
	private DarkUIButton helperReponse;

	[AccessedThroughProperty("Button7")]
	[CompilerGenerated]
	private DarkUIButton mapperReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Button8")]
	private DarkUIButton managerReponse;

	[AccessedThroughProperty("CheckBox_IsRepeatable")]
	[CompilerGenerated]
	private DarkCheckBox getterReponse;

	[AccessedThroughProperty("CheckBox_IsActive")]
	[CompilerGenerated]
	private DarkCheckBox _ProducerReponse;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	private DarkLabel procReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_Probability")]
	private DarkUITextBox _StructDescriptor;

	[AccessedThroughProperty("Button_EditTriggers")]
	[CompilerGenerated]
	private DarkUIButton _MerchantDescriptor;

	[AccessedThroughProperty("Button_EditActions")]
	[CompilerGenerated]
	private DarkUIButton _CallbackDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditConditions")]
	private DarkUIButton decoratorDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBox_IsShown")]
	private DarkCheckBox processDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("ID")]
	private DataGridViewTextBoxColumn m_ThreadDescriptor;

	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn instanceDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	private DataGridViewTextBoxColumn objectDescriptor;

	private SimEvent _ConfigDescriptor;

	public _FormAction Action;

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_MessageReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = InitQueue;
			DarkUITextBox messageReponse = m_MessageReponse;
			if (messageReponse != null)
			{
				messageReponse.TextChanged -= value2;
			}
			m_MessageReponse = value;
			messageReponse = m_MessageReponse;
			if (messageReponse != null)
			{
				messageReponse.TextChanged += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return productReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productReponse = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkDataGridView DGV_Triggers
	{
		[CompilerGenerated]
		get
		{
			return iteratorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopQueue;
			DarkDataGridView darkDataGridView = iteratorReponse;
			if (darkDataGridView != null)
			{
				darkDataGridView.DoubleClick -= value2;
			}
			iteratorReponse = value;
			darkDataGridView = iteratorReponse;
			if (darkDataGridView != null)
			{
				darkDataGridView.DoubleClick += value2;
			}
		}
	}

	internal DarkDataGridView DGV_Conditions
	{
		[CompilerGenerated]
		get
		{
			return initializerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateQueue;
			DarkDataGridView darkDataGridView = initializerReponse;
			if (darkDataGridView != null)
			{
				darkDataGridView.DoubleClick -= value2;
			}
			initializerReponse = value;
			darkDataGridView = initializerReponse;
			if (darkDataGridView != null)
			{
				darkDataGridView.DoubleClick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkDataGridView DGV_Actions
	{
		[CompilerGenerated]
		get
		{
			return factoryReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateQueue;
			DarkDataGridView darkDataGridView = factoryReponse;
			if (darkDataGridView != null)
			{
				darkDataGridView.DoubleClick -= value2;
			}
			factoryReponse = value;
			darkDataGridView = factoryReponse;
			if (darkDataGridView != null)
			{
				darkDataGridView.DoubleClick += value2;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return attributeReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			attributeReponse = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _EventReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupQueue;
			DarkUIButton eventReponse = _EventReponse;
			if (eventReponse != null)
			{
				eventReponse.Click -= value2;
			}
			_EventReponse = value;
			eventReponse = _EventReponse;
			if (eventReponse != null)
			{
				eventReponse.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Triggers
	{
		[CompilerGenerated]
		get
		{
			return globalReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			globalReponse = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_WorkerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeQueue;
			DarkUIButton workerReponse = m_WorkerReponse;
			if (workerReponse != null)
			{
				workerReponse.Click -= value2;
			}
			m_WorkerReponse = value;
			workerReponse = m_WorkerReponse;
			if (workerReponse != null)
			{
				workerReponse.Click += value2;
			}
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return m_AccountReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckQueue;
			DarkUIButton accountReponse = m_AccountReponse;
			if (accountReponse != null)
			{
				accountReponse.Click -= value2;
			}
			m_AccountReponse = value;
			accountReponse = m_AccountReponse;
			if (accountReponse != null)
			{
				accountReponse.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Conditions
	{
		[CompilerGenerated]
		get
		{
			return m_StateReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StateReponse = value;
		}
	}

	internal DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return authenticationReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveQueue;
			DarkUIButton darkUIButton = authenticationReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			authenticationReponse = value;
			darkUIButton = authenticationReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button5
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchQueue;
			DarkUIButton paramsReponse = m_ParamsReponse;
			if (paramsReponse != null)
			{
				paramsReponse.Click -= value2;
			}
			m_ParamsReponse = value;
			paramsReponse = m_ParamsReponse;
			if (paramsReponse != null)
			{
				paramsReponse.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Actions
	{
		[CompilerGenerated]
		get
		{
			return infoReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			infoReponse = value;
		}
	}

	internal DarkUIButton Button6
	{
		[CompilerGenerated]
		get
		{
			return helperReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeQueue;
			DarkUIButton darkUIButton = helperReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			helperReponse = value;
			darkUIButton = helperReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button7
	{
		[CompilerGenerated]
		get
		{
			return mapperReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeQueue;
			DarkUIButton darkUIButton = mapperReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			mapperReponse = value;
			darkUIButton = mapperReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button8
	{
		[CompilerGenerated]
		get
		{
			return managerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableQueue;
			DarkUIButton darkUIButton = managerReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			managerReponse = value;
			darkUIButton = managerReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkCheckBox CheckBox_IsRepeatable
	{
		[CompilerGenerated]
		get
		{
			return getterReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewQueue;
			DarkCheckBox darkCheckBox = getterReponse;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			getterReponse = value;
			darkCheckBox = getterReponse;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CheckBox_IsActive
	{
		[CompilerGenerated]
		get
		{
			return _ProducerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushQueue;
			DarkCheckBox producerReponse = _ProducerReponse;
			if (producerReponse != null)
			{
				producerReponse.CheckedChanged -= value2;
			}
			_ProducerReponse = value;
			producerReponse = _ProducerReponse;
			if (producerReponse != null)
			{
				producerReponse.CheckedChanged += value2;
			}
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return procReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			procReponse = value;
		}
	}

	internal DarkUITextBox NUD_Probability
	{
		[CompilerGenerated]
		get
		{
			return _StructDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateQueue;
			DarkUITextBox structDescriptor = _StructDescriptor;
			if (structDescriptor != null)
			{
				structDescriptor.Leave -= value2;
			}
			_StructDescriptor = value;
			structDescriptor = _StructDescriptor;
			if (structDescriptor != null)
			{
				structDescriptor.Leave += value2;
			}
		}
	}

	internal DarkUIButton Button_EditTriggers
	{
		[CompilerGenerated]
		get
		{
			return _MerchantDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatQueue;
			DarkUIButton merchantDescriptor = _MerchantDescriptor;
			if (merchantDescriptor != null)
			{
				merchantDescriptor.Click -= value2;
			}
			_MerchantDescriptor = value;
			merchantDescriptor = _MerchantDescriptor;
			if (merchantDescriptor != null)
			{
				merchantDescriptor.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_EditActions
	{
		[CompilerGenerated]
		get
		{
			return _CallbackDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptQueue;
			DarkUIButton callbackDescriptor = _CallbackDescriptor;
			if (callbackDescriptor != null)
			{
				callbackDescriptor.Click -= value2;
			}
			_CallbackDescriptor = value;
			callbackDescriptor = _CallbackDescriptor;
			if (callbackDescriptor != null)
			{
				callbackDescriptor.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_EditConditions
	{
		[CompilerGenerated]
		get
		{
			return decoratorDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindQueue;
			DarkUIButton darkUIButton = decoratorDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			decoratorDescriptor = value;
			darkUIButton = decoratorDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkCheckBox CheckBox_IsShown
	{
		[CompilerGenerated]
		get
		{
			return processDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeQueue;
			DarkCheckBox darkCheckBox = processDescriptor;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			processDescriptor = value;
			darkCheckBox = processDescriptor;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ThreadDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("Description")]
	internal DataGridViewTextBoxColumn Description
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DGV_Trigger_Type")]
	internal DataGridViewTextBoxColumn DGV_Trigger_Type
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[CompilerGenerated]
		get
		{
			return instanceDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			instanceDescriptor = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[CompilerGenerated]
		get
		{
			return objectDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			objectDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("DGV_Condition_Type")]
	internal DataGridViewTextBoxColumn DGV_Condition_Type
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DGV_Action_Type")]
	internal DataGridViewTextBoxColumn DGV_Action_Type
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public SimEvent theEvent
	{
		get
		{
			return _ConfigDescriptor;
		}
		set
		{
			_ConfigDescriptor = value;
			TextBox1.Text = theEvent.Description;
			WriteQueue();
			RefreshCombos();
			CheckBox_IsRepeatable.Checked = _ConfigDescriptor.IsRepeatable;
			CheckBox_IsActive.Checked = _ConfigDescriptor.IsActive;
			CheckBox_IsShown.Checked = _ConfigDescriptor.IsShown;
			NUD_Probability.Text = Conversions.ToString((int)_ConfigDescriptor.Probability);
		}
	}

	public EditEvent()
	{
		base.FormClosing += ValidateQueue;
		base.Load += LoginQueue;
		base.KeyDown += SetQueue;
		base.FormClosed += FillQueue;
		ViewQueue();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _InterceptorReponse != null)
			{
				_InterceptorReponse.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ViewQueue()
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
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		DGV_Triggers = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		DGV_Trigger_Type = new DataGridViewTextBoxColumn();
		DGV_Conditions = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DGV_Condition_Type = new DataGridViewTextBoxColumn();
		Label3 = new DarkLabel();
		DGV_Actions = new DarkDataGridView();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		DGV_Action_Type = new DataGridViewTextBoxColumn();
		Label4 = new DarkLabel();
		Button1 = new DarkUIButton();
		CB_Triggers = new DarkUIComboBox();
		Button2 = new DarkUIButton();
		Button3 = new DarkUIButton();
		CB_Conditions = new DarkUIComboBox();
		Button4 = new DarkUIButton();
		Button5 = new DarkUIButton();
		CB_Actions = new DarkUIComboBox();
		Button6 = new DarkUIButton();
		Button7 = new DarkUIButton();
		Button8 = new DarkUIButton();
		CheckBox_IsRepeatable = new DarkCheckBox();
		CheckBox_IsActive = new DarkCheckBox();
		Label5 = new DarkLabel();
		NUD_Probability = new DarkUITextBox();
		Button_EditTriggers = new DarkUIButton();
		Button_EditActions = new DarkUIButton();
		Button_EditConditions = new DarkUIButton();
		CheckBox_IsShown = new DarkCheckBox();
		((ISupportInitialize)DGV_Triggers).BeginInit();
		((ISupportInitialize)DGV_Conditions).BeginInit();
		((ISupportInitialize)DGV_Actions).BeginInit();
		SuspendLayout();
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(91, 3);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(691, 20);
		TextBox1.TabIndex = 8;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(5, 7);
		Label2.Name = "Label2";
		Label2.Size = new Size(69, 13);
		Label2.TabIndex = 7;
		Label2.Text = "描述：";
		Label1.AutoSize = true;
		Label1.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(5, 67);
		Label1.Name = "Label1";
		Label1.Size = new Size(51, 13);
		Label1.TabIndex = 9;
		Label1.Text = "触发器：";
		DGV_Triggers.AllowUserToAddRows = false;
		DGV_Triggers.AllowUserToDeleteRows = false;
		DGV_Triggers.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Triggers.BorderStyle = BorderStyle.Fixed3D;
		DGV_Triggers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Triggers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_Triggers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_Triggers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Triggers.Columns.AddRange(ID, Description, DGV_Trigger_Type);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_Triggers.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_Triggers.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_Triggers.EnableHeadersVisualStyles = false;
		DGV_Triggers.Location = new Point(8, 83);
		DGV_Triggers.MultiSelect = false;
		DGV_Triggers.Name = "DGV_Triggers";
		DGV_Triggers.ReadOnly = true;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_Triggers.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_Triggers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Triggers.ShowCellToolTips = false;
		DGV_Triggers.ShowEditingIcon = false;
		DGV_Triggers.ShowRowErrors = false;
		DGV_Triggers.Size = new Size(766, 100);
		DGV_Triggers.TabIndex = 10;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		ID.Width = 10;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Description";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
		DGV_Trigger_Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		DGV_Trigger_Type.DataPropertyName = "Type";
		DGV_Trigger_Type.HeaderText = "类型";
		DGV_Trigger_Type.MinimumWidth = 50;
		DGV_Trigger_Type.Name = "DGV_Trigger_Type";
		DGV_Trigger_Type.ReadOnly = true;
		DGV_Trigger_Type.Width = 54;
		DGV_Conditions.AllowUserToAddRows = false;
		DGV_Conditions.AllowUserToDeleteRows = false;
		DGV_Conditions.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Conditions.BorderStyle = BorderStyle.Fixed3D;
		DGV_Conditions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Conditions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		DGV_Conditions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		DGV_Conditions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Conditions.Columns.AddRange(DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DGV_Condition_Type);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		DGV_Conditions.DefaultCellStyle = dataGridViewCellStyle5;
		DGV_Conditions.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_Conditions.EnableHeadersVisualStyles = false;
		DGV_Conditions.Location = new Point(8, 241);
		DGV_Conditions.MultiSelect = false;
		DGV_Conditions.Name = "DGV_Conditions";
		DGV_Conditions.ReadOnly = true;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		DGV_Conditions.RowsDefaultCellStyle = dataGridViewCellStyle6;
		DGV_Conditions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Conditions.ShowCellToolTips = false;
		DGV_Conditions.ShowEditingIcon = false;
		DGV_Conditions.ShowRowErrors = false;
		DGV_Conditions.Size = new Size(766, 100);
		DGV_Conditions.TabIndex = 12;
		DataGridViewTextBoxColumn1.DataPropertyName = "ID";
		DataGridViewTextBoxColumn1.HeaderText = "ID";
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.ReadOnly = true;
		DataGridViewTextBoxColumn1.Visible = false;
		DataGridViewTextBoxColumn1.Width = 10;
		DataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		DataGridViewTextBoxColumn2.DataPropertyName = "Description";
		DataGridViewTextBoxColumn2.HeaderText = "描述";
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		DataGridViewTextBoxColumn2.ReadOnly = true;
		DGV_Condition_Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		DGV_Condition_Type.DataPropertyName = "Type";
		DGV_Condition_Type.HeaderText = "类型";
		DGV_Condition_Type.MinimumWidth = 50;
		DGV_Condition_Type.Name = "DGV_Condition_Type";
		DGV_Condition_Type.ReadOnly = true;
		DGV_Condition_Type.Width = 54;
		Label3.AutoSize = true;
		Label3.Enabled = false;
		Label3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(5, 225);
		Label3.Name = "Label3";
		Label3.Size = new Size(67, 13);
		Label3.TabIndex = 11;
		Label3.Text = "条件：";
		DGV_Actions.AllowUserToAddRows = false;
		DGV_Actions.AllowUserToDeleteRows = false;
		DGV_Actions.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Actions.BorderStyle = BorderStyle.Fixed3D;
		DGV_Actions.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Actions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle7.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle7.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle7.ForeColor = Color.LightGray;
		dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		DGV_Actions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		DGV_Actions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Actions.Columns.AddRange(DataGridViewTextBoxColumn3, DataGridViewTextBoxColumn4, DGV_Action_Type);
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle8.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle8.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle8.ForeColor = Color.LightGray;
		dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
		DGV_Actions.DefaultCellStyle = dataGridViewCellStyle8;
		DGV_Actions.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_Actions.EnableHeadersVisualStyles = false;
		DGV_Actions.Location = new Point(8, 399);
		DGV_Actions.MultiSelect = false;
		DGV_Actions.Name = "DGV_Actions";
		DGV_Actions.ReadOnly = true;
		dataGridViewCellStyle9.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle9.ForeColor = Color.LightGray;
		dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle9.SelectionForeColor = Color.LightGray;
		DGV_Actions.RowsDefaultCellStyle = dataGridViewCellStyle9;
		DGV_Actions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Actions.ShowCellToolTips = false;
		DGV_Actions.ShowEditingIcon = false;
		DGV_Actions.ShowRowErrors = false;
		DGV_Actions.Size = new Size(766, 100);
		DGV_Actions.TabIndex = 14;
		DataGridViewTextBoxColumn3.DataPropertyName = "ID";
		DataGridViewTextBoxColumn3.HeaderText = "ID";
		DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
		DataGridViewTextBoxColumn3.ReadOnly = true;
		DataGridViewTextBoxColumn3.Visible = false;
		DataGridViewTextBoxColumn3.Width = 10;
		DataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		DataGridViewTextBoxColumn4.DataPropertyName = "Description";
		DataGridViewTextBoxColumn4.HeaderText = "描述";
		DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
		DataGridViewTextBoxColumn4.ReadOnly = true;
		DGV_Action_Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
		DGV_Action_Type.DataPropertyName = "Type";
		DGV_Action_Type.HeaderText = "类型";
		DGV_Action_Type.MinimumWidth = 50;
		DGV_Action_Type.Name = "DGV_Action_Type";
		DGV_Action_Type.ReadOnly = true;
		DGV_Action_Type.Width = 54;
		Label4.AutoSize = true;
		Label4.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(5, 383);
		Label4.Name = "Label4";
		Label4.Size = new Size(49, 13);
		Label4.TabIndex = 13;
		Label4.Text = "动作：";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 9f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(8, 190);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(93, 21);
		Button1.TabIndex = 15;
		Button1.Text = "添加触发器：";
		CB_Triggers.BackColor = Color.Transparent;
		CB_Triggers.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Triggers.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Triggers.Font = new Font("Segoe UI", 7f);
		CB_Triggers.FormattingEnabled = true;
		CB_Triggers.Location = new Point(107, 189);
		CB_Triggers.Name = "CB_Triggers";
		CB_Triggers.Size = new Size(424, 21);
		CB_Triggers.TabIndex = 16;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 9f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(638, 190);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(144, 21);
		Button2.TabIndex = 17;
		Button2.Text = "删除选定";
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 9f);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(638, 348);
		Button3.Name = "Button3";
		Button3.RoundRadius = 0;
		Button3.Size = new Size(144, 21);
		Button3.TabIndex = 20;
		Button3.Text = "删除选定";
		CB_Conditions.BackColor = Color.Transparent;
		CB_Conditions.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Conditions.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Conditions.Font = new Font("Segoe UI", 7f);
		CB_Conditions.FormattingEnabled = true;
		CB_Conditions.Location = new Point(107, 348);
		CB_Conditions.Name = "CB_Conditions";
		CB_Conditions.Size = new Size(424, 21);
		CB_Conditions.TabIndex = 19;
		Button4.BackColor = Color.Transparent;
		Button4.DialogResult = DialogResult.None;
		Button4.Font = new Font("Segoe UI", 9f);
		Button4.ForeColor = SystemColors.Control;
		Button4.Location = new Point(8, 348);
		Button4.Name = "Button4";
		Button4.RoundRadius = 0;
		Button4.Size = new Size(93, 21);
		Button4.TabIndex = 18;
		Button4.Text = "添加条件：";
		Button5.BackColor = Color.Transparent;
		Button5.DialogResult = DialogResult.None;
		Button5.Font = new Font("Segoe UI", 9f);
		Button5.ForeColor = SystemColors.Control;
		Button5.Location = new Point(638, 506);
		Button5.Name = "Button5";
		Button5.RoundRadius = 0;
		Button5.Size = new Size(144, 21);
		Button5.TabIndex = 23;
		Button5.Text = "删除选定";
		CB_Actions.BackColor = Color.Transparent;
		CB_Actions.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Actions.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Actions.Font = new Font("Segoe UI", 7f);
		CB_Actions.FormattingEnabled = true;
		CB_Actions.Location = new Point(107, 506);
		CB_Actions.Name = "CB_Actions";
		CB_Actions.Size = new Size(424, 21);
		CB_Actions.TabIndex = 22;
		Button6.BackColor = Color.Transparent;
		Button6.DialogResult = DialogResult.None;
		Button6.Font = new Font("Segoe UI", 9f);
		Button6.ForeColor = SystemColors.Control;
		Button6.Location = new Point(8, 506);
		Button6.Name = "Button6";
		Button6.RoundRadius = 0;
		Button6.Size = new Size(93, 21);
		Button6.TabIndex = 21;
		Button6.Text = "添加动作：";
		Button7.BackColor = Color.Transparent;
		Button7.DialogResult = DialogResult.None;
		Button7.Font = new Font("Segoe UI", 10f);
		Button7.ForeColor = SystemColors.Control;
		Button7.Location = new Point(707, 556);
		Button7.Name = "Button7";
		Button7.RoundRadius = 0;
		Button7.Size = new Size(75, 23);
		Button7.TabIndex = 25;
		Button7.Text = "取消";
		Button8.BackColor = Color.Transparent;
		Button8.DialogResult = DialogResult.None;
		Button8.Font = new Font("Segoe UI", 10f);
		Button8.ForeColor = SystemColors.Control;
		Button8.Location = new Point(8, 556);
		Button8.Name = "Button8";
		Button8.RoundRadius = 0;
		Button8.Size = new Size(75, 23);
		Button8.TabIndex = 24;
		Button8.Text = "确定";
		CheckBox_IsRepeatable.AutoSize = true;
		CheckBox_IsRepeatable.Location = new Point(8, 39);
		CheckBox_IsRepeatable.Name = "CheckBox_IsRepeatable";
		CheckBox_IsRepeatable.Size = new Size(124, 19);
		CheckBox_IsRepeatable.TabIndex = 26;
		CheckBox_IsRepeatable.Text = "事件可重复激活";
		CheckBox_IsActive.AutoSize = true;
		CheckBox_IsActive.Location = new Point(131, 39);
		CheckBox_IsActive.Name = "CheckBox_IsActive";
		CheckBox_IsActive.Size = new Size(100, 19);
		CheckBox_IsActive.TabIndex = 27;
		CheckBox_IsActive.Text = "事件已启用";
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(456, 43);
		Label5.Name = "Label5";
		Label5.Size = new Size(75, 13);
		Label5.TabIndex = 28;
		Label5.Text = "概率（％）：";
		NUD_Probability.AutoCompleteCustomSource = null;
		NUD_Probability.AutoCompleteMode = AutoCompleteMode.None;
		NUD_Probability.AutoCompleteSource = AutoCompleteSource.None;
		NUD_Probability.BackColor = Color.Transparent;
		NUD_Probability.Font = new Font("Segoe UI", 10f);
		NUD_Probability.ForeColor = Color.FromArgb(189, 189, 189);
		NUD_Probability.Image = null;
		NUD_Probability.Lines = null;
		NUD_Probability.Location = new Point(532, 37);
		NUD_Probability.MaxLength = 3;
		NUD_Probability.Multiline = false;
		NUD_Probability.Name = "NUD_Probability";
		NUD_Probability.ReadOnly = false;
		NUD_Probability.ScrollBars = ScrollBars.None;
		NUD_Probability.SelectionStart = 0;
		NUD_Probability.Size = new Size(53, 26);
		NUD_Probability.TabIndex = 29;
		NUD_Probability.Text = "100";
		NUD_Probability.TextAlign = HorizontalAlignment.Left;
		NUD_Probability.UseSystemPasswordChar = false;
		NUD_Probability.WatermarkText = "";
		Button_EditTriggers.BackColor = Color.Transparent;
		Button_EditTriggers.DialogResult = DialogResult.None;
		Button_EditTriggers.Font = new Font("Segoe UI", 9f);
		Button_EditTriggers.ForeColor = SystemColors.Control;
		Button_EditTriggers.Location = new Point(537, 190);
		Button_EditTriggers.Name = "Button_EditTriggers";
		Button_EditTriggers.RoundRadius = 0;
		Button_EditTriggers.Size = new Size(93, 21);
		Button_EditTriggers.TabIndex = 30;
		Button_EditTriggers.Text = "编辑触发器";
		Button_EditActions.BackColor = Color.Transparent;
		Button_EditActions.DialogResult = DialogResult.None;
		Button_EditActions.Font = new Font("Segoe UI", 9f);
		Button_EditActions.ForeColor = SystemColors.Control;
		Button_EditActions.Location = new Point(537, 506);
		Button_EditActions.Name = "Button_EditActions";
		Button_EditActions.RoundRadius = 0;
		Button_EditActions.Size = new Size(95, 21);
		Button_EditActions.TabIndex = 31;
		Button_EditActions.Text = "编辑动作";
		Button_EditConditions.BackColor = Color.Transparent;
		Button_EditConditions.DialogResult = DialogResult.None;
		Button_EditConditions.Font = new Font("Segoe UI", 9f);
		Button_EditConditions.ForeColor = SystemColors.Control;
		Button_EditConditions.Location = new Point(537, 348);
		Button_EditConditions.Name = "Button_EditConditions";
		Button_EditConditions.RoundRadius = 0;
		Button_EditConditions.Size = new Size(95, 21);
		Button_EditConditions.TabIndex = 32;
		Button_EditConditions.Text = "编辑条件";
		CheckBox_IsShown.AutoSize = true;
		CheckBox_IsShown.Location = new Point(233, 39);
		CheckBox_IsShown.Name = "CheckBox_IsShown";
		CheckBox_IsShown.Size = new Size(140, 19);
		CheckBox_IsShown.TabIndex = 33;
		CheckBox_IsShown.Text = "事件显示在日志中";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(786, 580);
		base.Controls.Add(CheckBox_IsShown);
		base.Controls.Add(Button_EditConditions);
		base.Controls.Add(Button_EditActions);
		base.Controls.Add(Button_EditTriggers);
		base.Controls.Add(NUD_Probability);
		base.Controls.Add(Label5);
		base.Controls.Add(CheckBox_IsActive);
		base.Controls.Add(CheckBox_IsRepeatable);
		base.Controls.Add(Button7);
		base.Controls.Add(Button8);
		base.Controls.Add(Button5);
		base.Controls.Add(CB_Actions);
		base.Controls.Add(Button6);
		base.Controls.Add(Button3);
		base.Controls.Add(CB_Conditions);
		base.Controls.Add(Button4);
		base.Controls.Add(Button2);
		base.Controls.Add(CB_Triggers);
		base.Controls.Add(Button1);
		base.Controls.Add(DGV_Actions);
		base.Controls.Add(Label4);
		base.Controls.Add(DGV_Conditions);
		base.Controls.Add(Label3);
		base.Controls.Add(DGV_Triggers);
		base.Controls.Add(Label1);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label2);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditEvent";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑事件";
		((ISupportInitialize)DGV_Triggers).EndInit();
		((ISupportInitialize)DGV_Conditions).EndInit();
		((ISupportInitialize)DGV_Actions).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			_ConfigDescriptor = null;
			CB_Triggers.Items.Clear();
			CB_Conditions.Items.Clear();
			CB_Actions.Items.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void ValidateQueue(object sender, FormClosingEventArgs e)
	{
		if (Action == _FormAction.EditExisting)
		{
			if (theEvent.Triggers.Count == 0)
			{
				DarkMessageBox.ShowError("该事件应至少分配一个触发器。", "没有分配触发器！");
				e.Cancel = true;
				return;
			}
			if (theEvent.Actions.Count == 0)
			{
				DarkMessageBox.ShowError("该事件应至少分配一个动作。", "没有分配动作！");
				e.Cancel = true;
				return;
			}
		}
		CalculateQueue(RuntimeHelpers.GetObjectValue(sender), e);
		ItemExporter.ConnectInterruptibleTemplate.ListEvents.RefreshGrid();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void LoginQueue(object sender, EventArgs e)
	{
		Scenario.EventTriggersChanged += GetQueue;
		Scenario.EventConditionsChanged += GetQueue;
		Scenario.EventActionsChanged += GetQueue;
		EditTrigger.EventTriggersChanged += GetQueue;
		EditCondition.EventConditionsChanged += GetQueue;
		EditAction.EventActionsChanged += GetQueue;
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Information.IsNothing(theEvent))
		{
			Close();
		}
	}

	internal void GetQueue(Scenario scenario_0)
	{
		if (scenario_0 == Client.CurrentScenario)
		{
			WriteQueue();
			RefreshCombos();
		}
	}

	private void WriteQueue()
	{
		DGV_Triggers.SuspendLayout();
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("Type", typeof(string));
		foreach (EventTrigger trigger in theEvent.Triggers)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["ID"] = trigger.ObjectID;
			dataRow["Description"] = trigger.Description;
			dataRow["Type"] = trigger.Type.ToString();
			dataTable.Rows.Add(dataRow);
		}
		DGV_Triggers.DataSource = dataTable;
		DGV_Triggers.ResumeLayout();
		DGV_Conditions.SuspendLayout();
		dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("Type", typeof(string));
		foreach (EventCondition condition in theEvent.Conditions)
		{
			DataRow dataRow2 = dataTable.NewRow();
			dataRow2["ID"] = condition.ObjectID;
			dataRow2["Description"] = condition.Description;
			dataRow2["Type"] = condition.Type.ToString();
			dataTable.Rows.Add(dataRow2);
		}
		DGV_Conditions.DataSource = dataTable;
		DGV_Conditions.ResumeLayout();
		DGV_Actions.SuspendLayout();
		dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("Type", typeof(string));
		foreach (EventAction action in theEvent.Actions)
		{
			DataRow dataRow3 = dataTable.NewRow();
			dataRow3["ID"] = action.ObjectID;
			dataRow3["Description"] = action.Description;
			dataRow3["Type"] = action.Type.ToString();
			dataTable.Rows.Add(dataRow3);
		}
		DGV_Actions.DataSource = dataTable;
		DGV_Actions.ResumeLayout();
	}

	public void RefreshCombos()
	{
		CB_Triggers.Items.Clear();
		CB_Triggers.DisplayMember = "Content";
		foreach (EventTrigger item in Client.CurrentScenario.EventTriggers.Values.OrderBy((EventTrigger theT) => theT.Description))
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Content = item.Description;
			comboBoxItem.Tag = item;
			CB_Triggers.Items.Add(comboBoxItem);
		}
		CB_Conditions.Items.Clear();
		CB_Conditions.DisplayMember = "Content";
		foreach (EventCondition item2 in Client.CurrentScenario.EventConditions.Values.OrderBy((EventCondition theT) => theT.Description))
		{
			ComboBoxItem comboBoxItem2 = new ComboBoxItem();
			comboBoxItem2.Content = item2.Description;
			comboBoxItem2.Tag = item2;
			CB_Conditions.Items.Add(comboBoxItem2);
		}
		CB_Actions.Items.Clear();
		CB_Actions.DisplayMember = "Content";
		foreach (EventAction item3 in Client.CurrentScenario.EventActions.Values.OrderBy((EventAction theT) => theT.Description))
		{
			ComboBoxItem comboBoxItem3 = new ComboBoxItem();
			comboBoxItem3.Content = item3.Description;
			comboBoxItem3.Tag = item3;
			CB_Actions.Items.Add(comboBoxItem3);
		}
	}

	private void NewQueue(object sender, EventArgs e)
	{
		theEvent.IsRepeatable = CheckBox_IsRepeatable.Checked;
	}

	private void PushQueue(object sender, EventArgs e)
	{
		theEvent.IsActive = CheckBox_IsActive.Checked;
	}

	private void InvokeQueue(object sender, EventArgs e)
	{
		theEvent.IsShown = CheckBox_IsShown.Checked;
	}

	private void SetupQueue(object sender, EventArgs e)
	{
		if (CB_Triggers.SelectedIndex >= 0)
		{
			EventTrigger item = (EventTrigger)((ComboBoxItem)CB_Triggers.SelectedItem).Tag;
			if (!theEvent.Triggers.Contains(item))
			{
				theEvent.Triggers.Add(item);
				WriteQueue();
			}
		}
	}

	private void ExcludeQueue(object sender, EventArgs e)
	{
		if (CB_Actions.SelectedIndex >= 0)
		{
			EventAction item = (EventAction)((ComboBoxItem)CB_Actions.SelectedItem).Tag;
			if (!theEvent.Actions.Contains(item))
			{
				theEvent.Actions.Add(item);
				WriteQueue();
			}
		}
	}

	private void IncludeQueue(object sender, EventArgs e)
	{
		if (DGV_Triggers.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DGV_Triggers.SelectedRows[0].Cells[0].Value);
			EventTrigger item = Client.CurrentScenario.EventTriggers[text];
			theEvent.Triggers.Remove(item);
			WriteQueue();
		}
	}

	private void SearchQueue(object sender, EventArgs e)
	{
		if (DGV_Actions.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DGV_Actions.SelectedRows[0].Cells[0].Value);
			EventAction item = Client.CurrentScenario.EventActions[text];
			theEvent.Actions.Remove(item);
			WriteQueue();
		}
	}

	private void EnableQueue(object sender, EventArgs e)
	{
		if (theEvent.Triggers.Count == 0)
		{
			DarkMessageBox.ShowError("该事件应至少分配一个触发器。", "没有分配触发器！");
			return;
		}
		if (theEvent.Actions.Count == 0)
		{
			DarkMessageBox.ShowError("该事件应至少分配一个动作。", "没有分配动作！");
			return;
		}
		if (Action == _FormAction.AddNew)
		{
			Client.CurrentScenario.SimEvents.Add(theEvent.ObjectID, theEvent);
		}
		Close();
	}

	private void ChangeQueue(object sender, EventArgs e)
	{
		Close();
	}

	private void InitQueue(object object_0)
	{
		theEvent.Description = TextBox1.Text;
	}

	private void CheckQueue(object sender, EventArgs e)
	{
		if (DGV_Conditions.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DGV_Conditions.SelectedRows[0].Cells[0].Value);
			EventCondition item = Client.CurrentScenario.EventConditions[text];
			theEvent.Conditions.Remove(item);
			WriteQueue();
		}
	}

	private void ConcatQueue(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.ListTriggers.Show();
	}

	private void InterruptQueue(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.ListActions.Show();
	}

	private void RemoveQueue(object sender, EventArgs e)
	{
		if (CB_Conditions.SelectedIndex >= 0)
		{
			EventCondition item = (EventCondition)((ComboBoxItem)CB_Conditions.SelectedItem).Tag;
			if (!theEvent.Conditions.Contains(item))
			{
				theEvent.Conditions.Add(item);
				WriteQueue();
			}
		}
	}

	private void FindQueue(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.ListConditions.Show();
	}

	private void SetQueue(object sender, KeyEventArgs e)
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

	private void FillQueue(object sender, FormClosedEventArgs e)
	{
		Scenario.EventTriggersChanged -= GetQueue;
		Scenario.EventConditionsChanged -= GetQueue;
		Scenario.EventActionsChanged -= GetQueue;
		EditTrigger.EventTriggersChanged -= GetQueue;
		EditCondition.EventConditionsChanged -= GetQueue;
		EditAction.EventActionsChanged -= GetQueue;
	}

	private void CalculateQueue(object sender, EventArgs e)
	{
		if (theEvent != null)
		{
			if (Versioned.IsNumeric(NUD_Probability.Text) && Conversions.ToDouble(NUD_Probability.Text) > 1.0 && Conversions.ToDouble(NUD_Probability.Text) <= 100.0)
			{
				theEvent.Probability = Conversions.ToShort(NUD_Probability.Text);
			}
			else
			{
				NUD_Probability.Text = Conversions.ToString((int)theEvent.Probability);
			}
		}
	}

	private void PopQueue(object sender, EventArgs e)
	{
		if (DGV_Triggers.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DGV_Triggers.SelectedRows[0].Cells[0].Value);
			EventTrigger eventTrigger_ = Client.CurrentScenario.EventTriggers[text];
			ItemExporter.ConnectInterruptibleTemplate.ListTriggers.ShowEditTrigger(eventTrigger_);
		}
	}

	private void InstantiateQueue(object sender, EventArgs e)
	{
		if (DGV_Conditions.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DGV_Conditions.SelectedRows[0].Cells[0].Value);
			EventCondition eventCondition_ = Client.CurrentScenario.EventConditions[text];
			ItemExporter.ConnectInterruptibleTemplate.ListConditions.ShowEditTrigger(eventCondition_);
		}
	}

	private void CreateQueue(object sender, EventArgs e)
	{
		if (DGV_Actions.SelectedRows.Count != 0)
		{
			string text = Conversions.ToString(DGV_Actions.SelectedRows[0].Cells[0].Value);
			EventAction eventAction_ = Client.CurrentScenario.EventActions[text];
			ItemExporter.ConnectInterruptibleTemplate.ListActions.ShowEditTrigger(eventAction_);
		}
	}
}
