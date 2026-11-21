using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Command.Messages;
using Command_Core;
using DarkUI.Collections;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class NoNavZonesWindow : DarkSecondaryFormBase
{
	private IContainer _BroadcasterPublisher;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView _IdentifierPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel printerPublisher;

	[AccessedThroughProperty("CB_Facility")]
	[CompilerGenerated]
	private DarkCheckBox _AlgoPublisher;

	[AccessedThroughProperty("CB_Submarine")]
	[CompilerGenerated]
	private DarkCheckBox _DatabasePublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Ship")]
	private DarkCheckBox _InterceptorPublisher;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_MessagePublisher;

	[AccessedThroughProperty("CB_Aircraft")]
	[CompilerGenerated]
	private DarkCheckBox productPublisher;

	[AccessedThroughProperty("TB_Description")]
	[CompilerGenerated]
	private DarkUITextBox _AnnotationPublisher;

	[AccessedThroughProperty("Button_SetDescription")]
	[CompilerGenerated]
	private DarkUIButton initializerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton m_RolePublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_IsLocked")]
	private DarkCheckBox factoryPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("ExportZone")]
	private DarkUIButton m_AttributePublisher;

	[AccessedThroughProperty("ImportZone")]
	[CompilerGenerated]
	private DarkUIButton m_EventPublisher;

	[AccessedThroughProperty("ID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_GlobalPublisher;

	[AccessedThroughProperty("Description")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_WorkerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Active")]
	private DataGridViewCheckBoxColumn accountPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_VisibleRP")]
	private DarkCheckBox _StatePublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_NoFireZone")]
	private DarkCheckBox _AuthenticationPublisher;

	private NoNavZone paramsPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("FD_LoadNoNavZone")]
	private OpenFileDialog infoPublisher;

	[AccessedThroughProperty("FD_ExportNoNavZone")]
	[CompilerGenerated]
	private SaveFileDialog _HelperPublisher;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return _IdentifierPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetInterruptibleComposer;
			DataGridViewCellEventHandler value3 = CheckInterruptibleComposer;
			DarkDataGridView identifierPublisher = _IdentifierPublisher;
			if (identifierPublisher != null)
			{
				identifierPublisher.SelectionChanged -= value2;
				identifierPublisher.CellClick -= value3;
			}
			_IdentifierPublisher = value;
			identifierPublisher = _IdentifierPublisher;
			if (identifierPublisher != null)
			{
				identifierPublisher.SelectionChanged += value2;
				identifierPublisher.CellClick += value3;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return printerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerPublisher = value;
		}
	}

	[field: AccessedThroughProperty("AreaEditor1")]
	internal AreaEditor AreaEditor1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_Facility
	{
		[CompilerGenerated]
		get
		{
			return _AlgoPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = SetupInterruptibleComposer;
			DarkCheckBox algoPublisher = _AlgoPublisher;
			if (algoPublisher != null)
			{
				algoPublisher.MouseClick -= value2;
			}
			_AlgoPublisher = value;
			algoPublisher = _AlgoPublisher;
			if (algoPublisher != null)
			{
				algoPublisher.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox CB_Submarine
	{
		[CompilerGenerated]
		get
		{
			return _DatabasePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = IncludeInterruptibleComposer;
			DarkCheckBox databasePublisher = _DatabasePublisher;
			if (databasePublisher != null)
			{
				databasePublisher.MouseClick -= value2;
			}
			_DatabasePublisher = value;
			databasePublisher = _DatabasePublisher;
			if (databasePublisher != null)
			{
				databasePublisher.MouseClick += value2;
			}
		}
	}

	internal DarkCheckBox CB_Ship
	{
		[CompilerGenerated]
		get
		{
			return _InterceptorPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = ExcludeInterruptibleComposer;
			DarkCheckBox interceptorPublisher = _InterceptorPublisher;
			if (interceptorPublisher != null)
			{
				interceptorPublisher.MouseClick -= value2;
			}
			_InterceptorPublisher = value;
			interceptorPublisher = _InterceptorPublisher;
			if (interceptorPublisher != null)
			{
				interceptorPublisher.MouseClick += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_MessagePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MessagePublisher = value;
		}
	}

	internal DarkCheckBox CB_Aircraft
	{
		[CompilerGenerated]
		get
		{
			return productPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = InvokeInterruptibleComposer;
			DarkCheckBox darkCheckBox = productPublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick -= value2;
			}
			productPublisher = value;
			darkCheckBox = productPublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.MouseClick += value2;
			}
		}
	}

	internal DarkUITextBox TB_Description
	{
		[CompilerGenerated]
		get
		{
			return _AnnotationPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateInterruptibleComposer;
			DarkUITextBox annotationPublisher = _AnnotationPublisher;
			if (annotationPublisher != null)
			{
				annotationPublisher.Leave -= value2;
			}
			_AnnotationPublisher = value;
			annotationPublisher = _AnnotationPublisher;
			if (annotationPublisher != null)
			{
				annotationPublisher.Leave += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_SetDescription
	{
		[CompilerGenerated]
		get
		{
			return initializerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			initializerPublisher = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_RolePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginInterruptibleComposer;
			DarkUIButton rolePublisher = m_RolePublisher;
			if (rolePublisher != null)
			{
				rolePublisher.Click -= value2;
			}
			m_RolePublisher = value;
			rolePublisher = m_RolePublisher;
			if (rolePublisher != null)
			{
				rolePublisher.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_IsLocked
	{
		[CompilerGenerated]
		get
		{
			return factoryPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushInterruptibleComposer;
			DarkCheckBox darkCheckBox = factoryPublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			factoryPublisher = value;
			darkCheckBox = factoryPublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIButton ExportZone
	{
		[CompilerGenerated]
		get
		{
			return m_AttributePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableInterruptibleComposer;
			DarkUIButton attributePublisher = m_AttributePublisher;
			if (attributePublisher != null)
			{
				attributePublisher.Click -= value2;
			}
			m_AttributePublisher = value;
			attributePublisher = m_AttributePublisher;
			if (attributePublisher != null)
			{
				attributePublisher.Click += value2;
			}
		}
	}

	internal DarkUIButton ImportZone
	{
		[CompilerGenerated]
		get
		{
			return m_EventPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleComposer;
			DarkUIButton eventPublisher = m_EventPublisher;
			if (eventPublisher != null)
			{
				eventPublisher.Click -= value2;
			}
			m_EventPublisher = value;
			eventPublisher = m_EventPublisher;
			if (eventPublisher != null)
			{
				eventPublisher.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalPublisher = value;
		}
	}

	internal DataGridViewTextBoxColumn Description
	{
		[CompilerGenerated]
		get
		{
			return m_WorkerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WorkerPublisher = value;
		}
	}

	internal DataGridViewCheckBoxColumn Active
	{
		[CompilerGenerated]
		get
		{
			return accountPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			accountPublisher = value;
		}
	}

	internal DarkCheckBox CB_VisibleRP
	{
		[CompilerGenerated]
		get
		{
			return _StatePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitInterruptibleComposer;
			DarkCheckBox statePublisher = _StatePublisher;
			if (statePublisher != null)
			{
				statePublisher.Click -= value2;
			}
			_StatePublisher = value;
			statePublisher = _StatePublisher;
			if (statePublisher != null)
			{
				statePublisher.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_NoFireZone
	{
		[CompilerGenerated]
		get
		{
			return _AuthenticationPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleComposer;
			DarkCheckBox authenticationPublisher = _AuthenticationPublisher;
			if (authenticationPublisher != null)
			{
				authenticationPublisher.CheckedChanged -= value2;
			}
			_AuthenticationPublisher = value;
			authenticationPublisher = _AuthenticationPublisher;
			if (authenticationPublisher != null)
			{
				authenticationPublisher.CheckedChanged += value2;
			}
		}
	}

	public NoNavZone SelectedZone
	{
		get
		{
			return paramsPublisher;
		}
		set
		{
			paramsPublisher = value;
			if (!Information.IsNothing(value))
			{
				TB_Description.Text = value.Description;
				CB_Aircraft.Checked = paramsPublisher.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Aircraft);
				CB_Ship.Checked = paramsPublisher.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Ship);
				CB_Submarine.Checked = paramsPublisher.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Submarine);
				CB_Facility.Checked = paramsPublisher.AffectedUnitTypes.Contains(GlobalVariables.ActiveUnitType.Facility);
				CB_IsLocked.Checked = paramsPublisher.IsLocked;
				CB_NoFireZone.Checked = paramsPublisher.NoFireZone;
				AreaEditor1.AreaPoints = paramsPublisher.Area;
				AreaEditor1.Title = "区域";
				AreaEditor1.RefreshForm();
				LogoutInterruptibleComposer();
			}
			bool flag = false;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side in array)
			{
				foreach (NoNavZone noNavZone in side.NoNavZones)
				{
					if (noNavZone != SelectedZone)
					{
						continue;
					}
					foreach (ReferencePoint item in SelectedZone.Area)
					{
						if (side.RefPoints.Contains(item))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
					break;
				}
				if (flag)
				{
					break;
				}
			}
			CB_VisibleRP.Checked = flag;
			Client.MustRefreshMainForm = true;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog CollectInterruptibleComposer()
	{
		return infoPublisher;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void OrderInterruptibleComposer(OpenFileDialog openFileDialog_0)
	{
		infoPublisher = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog ManageInterruptibleComposer()
	{
		return _HelperPublisher;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RevertInterruptibleComposer(SaveFileDialog saveFileDialog_0)
	{
		_HelperPublisher = saveFileDialog_0;
	}

	public NoNavZonesWindow()
	{
		base.FormClosing += CallInterruptibleComposer;
		base.Load += NewInterruptibleComposer;
		base.KeyDown += SearchInterruptibleComposer;
		SelectInterruptibleComposer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _BroadcasterPublisher != null)
			{
				_BroadcasterPublisher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SelectInterruptibleComposer()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		Active = new DataGridViewCheckBoxColumn();
		Label4 = new DarkLabel();
		CB_Facility = new DarkCheckBox();
		CB_Submarine = new DarkCheckBox();
		CB_Ship = new DarkCheckBox();
		Label1 = new DarkLabel();
		CB_Aircraft = new DarkCheckBox();
		TB_Description = new DarkUITextBox();
		Label3 = new DarkLabel();
		Button_SetDescription = new DarkUIButton();
		Button2 = new DarkUIButton();
		CB_IsLocked = new DarkCheckBox();
		AreaEditor1 = new AreaEditor();
		ExportZone = new DarkUIButton();
		ImportZone = new DarkUIButton();
		CB_VisibleRP = new DarkCheckBox();
		CB_NoFireZone = new DarkCheckBox();
		((ISupportInitialize)DataGridView1).BeginInit();
		SuspendLayout();
		DataGridView1.AllowUserToAddRows = false;
		DataGridView1.AllowUserToDeleteRows = false;
		DataGridView1.AllowUserToOrderColumns = true;
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
		DataGridView1.Columns.AddRange(ID, Description, Active);
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
		DataGridView1.Location = new Point(0, -1);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.ReadOnly = true;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.ShowCellToolTips = false;
		DataGridView1.ShowEditingIcon = false;
		DataGridView1.ShowRowErrors = false;
		DataGridView1.Size = new Size(654, 373);
		DataGridView1.TabIndex = 1;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Visible = false;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Description";
		Description.HeaderText = "描述";
		Description.Name = "Description";
		Description.ReadOnly = true;
		Active.DataPropertyName = "IsActive";
		Active.HeaderText = "启用";
		Active.Name = "Active";
		Active.ReadOnly = true;
		Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label4.AutoSize = true;
		Label4.Font = new Font("Segoe UI", 11f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(6, 385);
		Label4.Name = "Label4";
		Label4.Size = new Size(106, 20);
		Label4.TabIndex = 26;
		Label4.Text = "选区";
		CB_Facility.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Facility.AutoSize = true;
		CB_Facility.Location = new Point(97, 450);
		CB_Facility.Name = "CB_Facility";
		CB_Facility.Size = new Size(81, 19);
		CB_Facility.TabIndex = 24;
		CB_Facility.Text = "地面单元";
		CB_Submarine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Submarine.AutoSize = true;
		CB_Submarine.Location = new Point(14, 450);
		CB_Submarine.Name = "CB_Submarine";
		CB_Submarine.Size = new Size(88, 19);
		CB_Submarine.TabIndex = 23;
		CB_Submarine.Text = "潜艇";
		CB_Ship.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Ship.AutoSize = true;
		CB_Ship.Location = new Point(97, 427);
		CB_Ship.Name = "CB_Ship";
		CB_Ship.Size = new Size(54, 19);
		CB_Ship.TabIndex = 22;
		CB_Ship.Text = "舰船";
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(15, 526);
		Label1.Name = "Label1";
		Label1.Size = new Size(70, 15);
		Label1.TabIndex = 14;
		Label1.Text = "描述：";
		CB_Aircraft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_Aircraft.AutoSize = true;
		CB_Aircraft.Location = new Point(14, 427);
		CB_Aircraft.Name = "CB_Aircraft";
		CB_Aircraft.Size = new Size(65, 19);
		CB_Aircraft.TabIndex = 21;
		CB_Aircraft.Text = "飞机";
		TB_Description.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TB_Description.AutoCompleteCustomSource = null;
		TB_Description.AutoCompleteMode = AutoCompleteMode.None;
		TB_Description.AutoCompleteSource = AutoCompleteSource.None;
		TB_Description.BackColor = Color.Transparent;
		TB_Description.Font = new Font("Segoe UI", 10f);
		TB_Description.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Description.Image = null;
		TB_Description.Lines = null;
		TB_Description.Location = new Point(84, 523);
		TB_Description.MaxLength = 32767;
		TB_Description.Multiline = false;
		TB_Description.Name = "TB_Description";
		TB_Description.ReadOnly = false;
		TB_Description.ScrollBars = ScrollBars.None;
		TB_Description.SelectionStart = 0;
		TB_Description.Size = new Size(205, 20);
		TB_Description.TabIndex = 15;
		TB_Description.TextAlign = HorizontalAlignment.Left;
		TB_Description.UseSystemPasswordChar = false;
		TB_Description.WatermarkText = "";
		Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(13, 414);
		Label3.Name = "Label3";
		Label3.Size = new Size(64, 15);
		Label3.TabIndex = 20;
		Label3.Text = "适用于：";
		Button_SetDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_SetDescription.BackColor = Color.Transparent;
		Button_SetDescription.DialogResult = DialogResult.None;
		Button_SetDescription.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_SetDescription.ForeColor = SystemColors.Control;
		Button_SetDescription.Location = new Point(295, 523);
		Button_SetDescription.Name = "Button_SetDescription";
		Button_SetDescription.RoundRadius = 0;
		Button_SetDescription.Size = new Size(49, 24);
		Button_SetDescription.TabIndex = 19;
		Button_SetDescription.Text = "保存";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.IndianRed;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button2.ForeColor = Color.IndianRed;
		Button2.Location = new Point(369, 523);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 18;
		Button2.Text = "删除";
		CB_IsLocked.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_IsLocked.Location = new Point(14, 482);
		CB_IsLocked.Name = "CB_IsLocked";
		CB_IsLocked.Size = new Size(250, 17);
		CB_IsLocked.TabIndex = 27;
		CB_IsLocked.Text = "区域已锁定（参演方不可编辑）";
		AreaEditor1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		AreaEditor1.BackColor = Color.FromArgb(60, 63, 65);
		AreaEditor1.Location = new Point(303, 373);
		AreaEditor1.Name = "AreaEditor1";
		AreaEditor1.Size = new Size(351, 124);
		AreaEditor1.TabIndex = 25;
		AreaEditor1.Title = null;
		ExportZone.BackColor = Color.Transparent;
		ExportZone.DialogResult = DialogResult.None;
		ExportZone.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ExportZone.ForeColor = SystemColors.Control;
		ExportZone.Location = new Point(467, 523);
		ExportZone.Name = "ExportZone";
		ExportZone.RoundRadius = 0;
		ExportZone.Size = new Size(75, 23);
		ExportZone.TabIndex = 28;
		ExportZone.Text = "导出";
		ImportZone.BackColor = Color.Transparent;
		ImportZone.DialogResult = DialogResult.None;
		ImportZone.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ImportZone.ForeColor = SystemColors.Control;
		ImportZone.Location = new Point(571, 524);
		ImportZone.Name = "ImportZone";
		ImportZone.RoundRadius = 0;
		ImportZone.Size = new Size(75, 22);
		ImportZone.TabIndex = 29;
		ImportZone.Text = "导入";
		CB_VisibleRP.AutoSize = true;
		CB_VisibleRP.Location = new Point(295, 503);
		CB_VisibleRP.Name = "CB_VisibleRP";
		CB_VisibleRP.Size = new Size(151, 19);
		CB_VisibleRP.TabIndex = 30;
		CB_VisibleRP.Text = "显示参考点";
		CB_NoFireZone.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CB_NoFireZone.Location = new Point(14, 500);
		CB_NoFireZone.Name = "CB_NoFireZone";
		CB_NoFireZone.Size = new Size(250, 17);
		CB_NoFireZone.TabIndex = 31;
		CB_NoFireZone.Text = "禁止开火区域（舍弃区域内目标）";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(655, 552);
		base.Controls.Add(CB_NoFireZone);
		base.Controls.Add(CB_VisibleRP);
		base.Controls.Add(ImportZone);
		base.Controls.Add(ExportZone);
		base.Controls.Add(CB_IsLocked);
		base.Controls.Add(Label4);
		base.Controls.Add(AreaEditor1);
		base.Controls.Add(CB_Facility);
		base.Controls.Add(CB_Submarine);
		base.Controls.Add(CB_Ship);
		base.Controls.Add(Label1);
		base.Controls.Add(CB_Aircraft);
		base.Controls.Add(TB_Description);
		base.Controls.Add(Label3);
		base.Controls.Add(Button_SetDescription);
		base.Controls.Add(Button2);
		base.Controls.Add(DataGridView1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "NoNavZonesWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑禁航区";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CallInterruptibleComposer(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		SelectedZone = null;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void LogoutInterruptibleComposer()
	{
		if (!Information.IsNothing(SelectedZone) && Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			CB_IsLocked.Visible = SelectedZone.IsLocked;
			CB_IsLocked.Enabled = false;
			TB_Description.Enabled = !SelectedZone.IsLocked;
			CB_Aircraft.Enabled = !SelectedZone.IsLocked;
			CB_Ship.Enabled = !SelectedZone.IsLocked;
			CB_Submarine.Enabled = !SelectedZone.IsLocked;
			CB_Facility.Enabled = !SelectedZone.IsLocked;
			CB_IsLocked.Checked = SelectedZone.IsLocked;
			AreaEditor1.Enabled = !SelectedZone.IsLocked;
			Button_SetDescription.Enabled = !SelectedZone.IsLocked;
			Button2.Enabled = !SelectedZone.IsLocked;
		}
	}

	private void ViewInterruptibleComposer()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("ID", typeof(string));
		dataTable.Columns.Add("Description", typeof(string));
		dataTable.Columns.Add("IsActive", typeof(bool));
		foreach (NoNavZone noNavZone in Client.CurrentSide.NoNavZones)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["ID"] = noNavZone.ObjectID;
			dataRow["Description"] = noNavZone.Description;
			dataRow["IsActive"] = noNavZone.IsActive;
			dataTable.Rows.Add(dataRow);
		}
		DataGridView1.DataSource = dataTable;
	}

	private void ValidateInterruptibleComposer(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedZone))
		{
			SelectedZone.Description = TB_Description.Text;
			ViewInterruptibleComposer();
		}
	}

	private void LoginInterruptibleComposer(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedZone))
		{
			Client.CurrentSide.NoNavZones.Remove(SelectedZone);
			SelectedZone = null;
			ViewInterruptibleComposer();
		}
	}

	private void GetInterruptibleComposer(object sender, EventArgs e)
	{
		if (DataGridView1.SelectedRows.Count != 0)
		{
			int num = DataGridView1.Rows.IndexOf(DataGridView1.SelectedRows[0]);
			if (num != -1)
			{
				SelectedZone = Client.CurrentSide.NoNavZones[num];
			}
		}
	}

	private void WriteInterruptibleComposer()
	{
		if (Information.IsNothing(SelectedZone))
		{
			if (Client.CurrentSide.NoNavZones.Count <= 0)
			{
				return;
			}
			SelectedZone = Client.CurrentSide.NoNavZones[0];
		}
		SelectedZone.AffectedUnitTypes.Clear();
		if (CB_Aircraft.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Aircraft);
		}
		if (CB_Ship.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Ship);
		}
		if (CB_Submarine.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Submarine);
		}
		if (CB_Facility.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Facility);
		}
		if (CB_Facility.Checked)
		{
			SelectedZone.AffectedUnitTypes.Add(GlobalVariables.ActiveUnitType.Vehicle);
		}
	}

	private void NewInterruptibleComposer(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ViewInterruptibleComposer();
		if (Client.CurrentSide.NoNavZones.Count > 0 && Information.IsNothing(SelectedZone))
		{
			SelectedZone = Client.CurrentSide.NoNavZones[0];
		}
	}

	private void PushInterruptibleComposer(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedZone))
		{
			SelectedZone.IsLocked = CB_IsLocked.Checked;
		}
	}

	private void InvokeInterruptibleComposer(object sender, MouseEventArgs e)
	{
		WriteInterruptibleComposer();
	}

	private void SetupInterruptibleComposer(object sender, MouseEventArgs e)
	{
		WriteInterruptibleComposer();
	}

	private void ExcludeInterruptibleComposer(object sender, MouseEventArgs e)
	{
		WriteInterruptibleComposer();
	}

	private void IncludeInterruptibleComposer(object sender, MouseEventArgs e)
	{
		WriteInterruptibleComposer();
	}

	private void SearchInterruptibleComposer(object sender, KeyEventArgs e)
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

	private void EnableInterruptibleComposer(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedZone))
		{
			DarkMessageBox.ShowError("Please select a No Novigation Zone.", "未选择区域");
			return;
		}
		RevertInterruptibleComposer(new SaveFileDialog());
		ManageInterruptibleComposer().InitialDirectory = GameGeneral.ScenariosRootPath;
		if (ManageInterruptibleComposer().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			FileStream fileStream = File.Create(ManageInterruptibleComposer().FileName);
			XmlWriterSettings settings = new XmlWriterSettings();
			using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
			using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
			{
				xmlWriter.WriteStartElement("NoNavZone");
				xmlWriter.WriteElementString("Description", SelectedZone.Description);
				xmlWriter.WriteStartElement("Area");
				foreach (ReferencePoint item in SelectedZone.Area)
				{
					HashSet<string> hashSet_ = null;
					xmlWriter.WriteRaw(item.ToXML(ref hashSet_));
					xmlWriter.Flush();
				}
				xmlWriter.WriteEndElement();
				xmlWriter.WriteElementString("AffectedUnitTypes", string.Join("_", SelectedZone.AffectedUnitTypes.Select(delegate(GlobalVariables.ActiveUnitType theType)
				{
					int num = (int)theType;
					return num.ToString();
				})));
				xmlWriter.WriteElementString("IsLocked", SelectedZone.IsLocked.ToString());
				xmlWriter.WriteEndElement();
			}
			fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
			fileStream.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101279", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void ChangeInterruptibleComposer(object sender, EventArgs e)
	{
		if (SelectedZone != null)
		{
			switch (DarkMessageBox.ShowInformation("请选择禁航区。", "未选择区域", DarkDialogButton.YesNoCancel))
			{
			case DialogResult.Yes:
				SelectedZone = null;
				break;
			case DialogResult.Cancel:
				return;
			}
		}
		OrderInterruptibleComposer(new OpenFileDialog());
		CollectInterruptibleComposer().InitialDirectory = GameGeneral.ScenariosRootPath;
		if (CollectInterruptibleComposer().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		FileStream fileStream = new FileStream(CollectInterruptibleComposer().FileName, FileMode.Open, FileAccess.Read);
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			using (fileStream)
			{
				try
				{
					xmlDocument.Load(fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					DarkMessageBox.ShowError("文件格式不正确，读取失败！", "读取错误");
					ProjectData.ClearProjectError();
				}
			}
			Zone zone = new Zone();
			bool isLocked = false;
			bool flag = true;
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/NoNavZone");
			if (Information.IsNothing(xmlNode))
			{
				xmlNode = xmlDocument.SelectSingleNode("/ExclusionZone");
				flag = false;
			}
			if (xmlNode == null)
			{
				DarkMessageBox.ShowError("找不到XML数据。", "Error");
			}
			else
			{
				IEnumerator enumerator = null;
				try
				{
					enumerator = xmlNode.ChildNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator.Current;
						string name = xmlNode2.Name;
						if (Operators.CompareString(name, "Description", TextCompare: true) == 0)
						{
							zone.Description = xmlNode2.InnerText;
						}
						else if (Operators.CompareString(name, "Area", TextCompare: true) == 0)
						{
							try
							{
								enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									XmlNode xmlNode_ = (XmlNode)enumerator2.Current;
									ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_ = null;
									ReferencePoint referencePoint = ReferencePoint.FromXML(ref xmlNode_, ref concurrentDictionary_);
									if (!flag)
									{
										referencePoint.ResetIDs();
									}
									zone.Area.Add(referencePoint);
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
						else if (Operators.CompareString(name, "AffectedUnitTypes", TextCompare: true) == 0)
						{
							zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
							string[] array = xmlNode2.InnerText.Split('_');
							string[] array2 = array;
							foreach (string text in array2)
							{
								if (Versioned.IsNumeric(text))
								{
									int num = Conversions.ToInteger(text);
									zone.AffectedUnitTypes.Add((GlobalVariables.ActiveUnitType)num);
								}
							}
						}
						else if (Operators.CompareString(name, "IsLocked", TextCompare: true) == 0)
						{
							isLocked = Conversions.ToBoolean(xmlNode2.InnerText);
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
				if (Information.IsNothing(zone.AffectedUnitTypes))
				{
					zone.AffectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
					{
						GlobalVariables.ActiveUnitType.Aircraft,
						GlobalVariables.ActiveUnitType.Ship,
						GlobalVariables.ActiveUnitType.Submarine,
						GlobalVariables.ActiveUnitType.Facility
					};
				}
				if (SelectedZone == null)
				{
					NoNavZone noNavZone = new NoNavZone(zone.Description, zone.Area, Client.CurrentScenario, Client.CurrentSide, zone.AffectedUnitTypes);
					noNavZone.IsLocked = isLocked;
					Client.CurrentSide.NoNavZones.Add(noNavZone);
					SelectedZone = noNavZone;
				}
				else
				{
					SelectedZone.Description = zone.Description;
					SelectedZone.Area = zone.Area;
					SelectedZone.AffectedUnitTypes = zone.AffectedUnitTypes;
					SelectedZone.IsLocked = isLocked;
				}
				AreaEditor1.RefreshForm();
				bool flag2 = false;
				Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
				Side[] array3 = sides_ReadOnly;
				foreach (Side side in array3)
				{
					foreach (NoNavZone noNavZone2 in side.NoNavZones)
					{
						if (noNavZone2 != SelectedZone)
						{
							continue;
						}
						foreach (ReferencePoint item in SelectedZone.Area)
						{
							if (!side.RefPoints.Contains(item))
							{
								side.RefPoints.Add(item);
							}
						}
						flag2 = true;
						break;
					}
					if (flag2)
					{
						break;
					}
				}
				ViewInterruptibleComposer();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101278", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		Client.MustRefreshMainForm = true;
	}

	private void InitInterruptibleComposer(object sender, EventArgs e)
	{
		bool flag = false;
		flag = CB_VisibleRP.Checked;
		bool flag2 = false;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				if (noNavZone != SelectedZone)
				{
					continue;
				}
				foreach (ReferencePoint item in SelectedZone.Area)
				{
					if (flag)
					{
						if (!side.RefPoints.Contains(item))
						{
							side.RefPoints.Add(item);
						}
					}
					else if (side.RefPoints.Contains(item))
					{
						side.RefPoints.Remove(item);
					}
				}
				flag2 = true;
				break;
			}
			if (flag2)
			{
				break;
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void CheckInterruptibleComposer(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1 || Operators.CompareString(DataGridView1.Columns[e.ColumnIndex].Name, "Active", TextCompare: true) != 0)
		{
			return;
		}
		DataGridViewCheckBoxCell dataGridViewCheckBoxCell = (DataGridViewCheckBoxCell)DataGridView1[e.ColumnIndex, e.RowIndex];
		NoNavZone noNavZone = null;
		string right = Conversions.ToString(DataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
		foreach (NoNavZone noNavZone2 in Client.CurrentSide.NoNavZones)
		{
			if (Operators.CompareString(noNavZone2.ObjectID, right, TextCompare: true) == 0)
			{
				noNavZone = noNavZone2;
				break;
			}
		}
		if (!Information.IsNothing(noNavZone))
		{
			if (noNavZone.IsActive)
			{
				dataGridViewCheckBoxCell.Value = false;
				noNavZone.IsActive = false;
			}
			else
			{
				dataGridViewCheckBoxCell.Value = true;
				noNavZone.IsActive = true;
			}
			Client.MustRefreshMainForm = true;
			ViewInterruptibleComposer();
		}
	}

	private void ConcatInterruptibleComposer(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedZone))
		{
			SelectedZone.NoFireZone = CB_NoFireZone.Checked;
		}
	}
}
