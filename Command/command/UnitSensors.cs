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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitSensors : DarkSecondaryFormBase, GInterface9
{
	private IContainer writerVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ObeyEMCON")]
	private DarkCheckBox m_SpecificationVisitor;

	[AccessedThroughProperty("CB_ECM")]
	[CompilerGenerated]
	private DarkCheckBox watcherVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_radar")]
	private DarkCheckBox _ReponseVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Sonar")]
	private DarkCheckBox descriptorVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddSensor")]
	private ToolStripButton _FilterVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveSensor")]
	private ToolStripButton testsVisitor;

	[AccessedThroughProperty("TSB_RemoveMCM")]
	[CompilerGenerated]
	private ToolStripButton interpreterVisitor;

	[AccessedThroughProperty("Timer_Refresh")]
	[CompilerGenerated]
	private Timer _ContainerVisitor;

	[AccessedThroughProperty("DGV_Sensors")]
	[CompilerGenerated]
	private DarkDataGridView m_ComposerVisitor;

	[AccessedThroughProperty("ObjectID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ModelVisitor;

	[AccessedThroughProperty("SensorColumn")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn advisorVisitor;

	[AccessedThroughProperty("Active")]
	[CompilerGenerated]
	private DataGridViewCheckBoxColumn m_SerializerVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("lbl_decoy_emitter")]
	private DarkLabel m_ErrorVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("btn_relink_decoy")]
	private DarkUIButton m_CodeVisitor;

	private DataTable _ContextVisitor;

	private List<Sensor> statusVisitor;

	private List<Sensor> proccesorVisitor;

	private List<Sensor> _StrategyVisitor;

	private bool configurationVisitor;

	private string tokenVisitor;

	private ActiveUnit m_IndexerVisitor;

	private Keys[] _ResolverVisitor;

	internal DarkCheckBox CB_ObeyEMCON
	{
		[CompilerGenerated]
		get
		{
			return m_SpecificationVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleItem;
			DarkCheckBox specificationVisitor = m_SpecificationVisitor;
			if (specificationVisitor != null)
			{
				specificationVisitor.Click -= value2;
			}
			m_SpecificationVisitor = value;
			specificationVisitor = m_SpecificationVisitor;
			if (specificationVisitor != null)
			{
				specificationVisitor.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_ECM
	{
		[CompilerGenerated]
		get
		{
			return watcherVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableInterruptibleItem;
			DarkCheckBox darkCheckBox = watcherVisitor;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			watcherVisitor = value;
			darkCheckBox = watcherVisitor;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_radar
	{
		[CompilerGenerated]
		get
		{
			return _ReponseVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeInterruptibleItem;
			DarkCheckBox reponseVisitor = _ReponseVisitor;
			if (reponseVisitor != null)
			{
				reponseVisitor.Click -= value2;
			}
			_ReponseVisitor = value;
			reponseVisitor = _ReponseVisitor;
			if (reponseVisitor != null)
			{
				reponseVisitor.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Sonar
	{
		[CompilerGenerated]
		get
		{
			return descriptorVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchInterruptibleItem;
			DarkCheckBox darkCheckBox = descriptorVisitor;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			descriptorVisitor = value;
			darkCheckBox = descriptorVisitor;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TS_Edit")]
	internal DarkToolStrip TS_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_AddSensor
	{
		[CompilerGenerated]
		get
		{
			return _FilterVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleItem;
			ToolStripButton filterVisitor = _FilterVisitor;
			if (filterVisitor != null)
			{
				filterVisitor.Click -= value2;
			}
			_FilterVisitor = value;
			filterVisitor = _FilterVisitor;
			if (filterVisitor != null)
			{
				filterVisitor.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_RemoveSensor
	{
		[CompilerGenerated]
		get
		{
			return testsVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptInterruptibleItem;
			ToolStripButton toolStripButton = testsVisitor;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			testsVisitor = value;
			toolStripButton = testsVisitor;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_RemoveMCM
	{
		[CompilerGenerated]
		get
		{
			return interpreterVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleItem;
			ToolStripButton toolStripButton = interpreterVisitor;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			interpreterVisitor = value;
			toolStripButton = interpreterVisitor;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal DarkDataGridView DGV_Sensors
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = NewInterruptibleItem;
			DataGridViewCellEventHandler value3 = PushInterruptibleItem;
			DataGridViewCellEventHandler value4 = InvokeInterruptibleItem;
			DataGridViewCellPaintingEventHandler value5 = InitInterruptibleItem;
			EventHandler value6 = CheckInterruptibleItem;
			EventHandler value7 = ConcatInterruptibleItem;
			DarkDataGridView composerVisitor = m_ComposerVisitor;
			if (composerVisitor != null)
			{
				composerVisitor.CellClick -= value2;
				composerVisitor.CellContentClick -= value3;
				composerVisitor.CellContentDoubleClick -= value4;
				composerVisitor.CellPainting -= value5;
				composerVisitor.ReadOnlyChanged -= value6;
				composerVisitor.SelectionChanged -= value7;
			}
			m_ComposerVisitor = value;
			composerVisitor = m_ComposerVisitor;
			if (composerVisitor != null)
			{
				composerVisitor.CellClick += value2;
				composerVisitor.CellContentClick += value3;
				composerVisitor.CellContentDoubleClick += value4;
				composerVisitor.CellPainting += value5;
				composerVisitor.ReadOnlyChanged += value6;
				composerVisitor.SelectionChanged += value7;
			}
		}
	}

	internal DataGridViewTextBoxColumn ObjectID
	{
		[CompilerGenerated]
		get
		{
			return m_ModelVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ModelVisitor = value;
		}
	}

	internal DataGridViewTextBoxColumn SensorColumn
	{
		[CompilerGenerated]
		get
		{
			return advisorVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			advisorVisitor = value;
		}
	}

	[field: AccessedThroughProperty("SensorType")]
	internal DataGridViewTextBoxColumn SensorType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewCheckBoxColumn Active
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SerializerVisitor = value;
		}
	}

	[field: AccessedThroughProperty("Status")]
	internal DataGridViewTextBoxColumn Status
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel lbl_decoy_emitter
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ErrorVisitor = value;
		}
	}

	internal DarkUIButton btn_relink_decoy
	{
		[CompilerGenerated]
		get
		{
			return m_CodeVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopInterruptibleItem;
			DarkUIButton codeVisitor = m_CodeVisitor;
			if (codeVisitor != null)
			{
				codeVisitor.Click -= value2;
			}
			m_CodeVisitor = value;
			codeVisitor = m_CodeVisitor;
			if (codeVisitor != null)
			{
				codeVisitor.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("cmb_relink_decoy")]
	internal DarkUIComboBox cmb_relink_decoy
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer RunInterruptibleItem()
	{
		return _ContainerVisitor;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void StartInterruptibleItem(Timer timer_0)
	{
		EventHandler value = SetInterruptibleItem;
		Timer containerVisitor = _ContainerVisitor;
		if (containerVisitor != null)
		{
			containerVisitor.Tick -= value;
		}
		_ContainerVisitor = timer_0;
		containerVisitor = _ContainerVisitor;
		if (containerVisitor != null)
		{
			containerVisitor.Tick += value;
		}
	}

	public UnitSensors()
	{
		base.FormClosing += SelectInterruptibleItem;
		base.Load += CallInterruptibleItem;
		base.Shown += ViewInterruptibleItem;
		base.SizeChanged += ValidateInterruptibleItem;
		base.KeyDown += FillInterruptibleItem;
		base.FormClosed += CalculateInterruptibleItem;
		_ContextVisitor = new DataTable();
		statusVisitor = new List<Sensor>();
		proccesorVisitor = new List<Sensor>();
		_StrategyVisitor = new List<Sensor>();
		_ResolverVisitor = new Keys[2]
		{
			Keys.F9,
			Keys.Escape
		};
		PatchInterruptibleItem();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && writerVisitor != null)
		{
			writerVisitor.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void PatchInterruptibleItem()
	{
		writerVisitor = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(UnitSensors));
		StartInterruptibleItem(new Timer(writerVisitor));
		DGV_Sensors = new DarkDataGridView();
		ObjectID = new DataGridViewTextBoxColumn();
		SensorColumn = new DataGridViewTextBoxColumn();
		SensorType = new DataGridViewTextBoxColumn();
		Active = new DataGridViewCheckBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TS_Edit = new DarkToolStrip();
		TSB_AddSensor = new ToolStripButton();
		TSB_RemoveSensor = new ToolStripButton();
		TSB_RemoveMCM = new ToolStripButton();
		Label1 = new DarkLabel();
		CB_ECM = new DarkCheckBox();
		CB_radar = new DarkCheckBox();
		CB_Sonar = new DarkCheckBox();
		CB_ObeyEMCON = new DarkCheckBox();
		lbl_decoy_emitter = new DarkLabel();
		btn_relink_decoy = new DarkUIButton();
		cmb_relink_decoy = new DarkUIComboBox();
		((ISupportInitialize)DGV_Sensors).BeginInit();
		TS_Edit.SuspendLayout();
		SuspendLayout();
		DGV_Sensors.AllowUserToAddRows = false;
		DGV_Sensors.AllowUserToDeleteRows = false;
		DGV_Sensors.AllowUserToOrderColumns = true;
		DGV_Sensors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_Sensors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		DGV_Sensors.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		DGV_Sensors.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Sensors.BorderStyle = BorderStyle.Fixed3D;
		DGV_Sensors.CausesValidation = false;
		DGV_Sensors.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Sensors.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_Sensors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_Sensors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Sensors.Columns.AddRange(ObjectID, SensorColumn, SensorType, Active, Status);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.LightGray;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_Sensors.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_Sensors.EnableHeadersVisualStyles = false;
		DGV_Sensors.Location = new Point(0, 50);
		DGV_Sensors.MultiSelect = false;
		DGV_Sensors.Name = "DGV_Sensors";
		DGV_Sensors.RowHeadersVisible = false;
		DGV_Sensors.RowHeadersWidth = 4;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_Sensors.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_Sensors.RowTemplate.Height = 20;
		DGV_Sensors.RowTemplate.Resizable = DataGridViewTriState.False;
		DGV_Sensors.ScrollBars = ScrollBars.Vertical;
		DGV_Sensors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Sensors.Size = new Size(681, 223);
		DGV_Sensors.TabIndex = 8;
		ObjectID.DataPropertyName = "ObjectID";
		ObjectID.HeaderText = "对象ID";
		ObjectID.MinimumWidth = 8;
		ObjectID.Name = "ObjectID";
		ObjectID.ReadOnly = true;
		ObjectID.Visible = false;
		SensorColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		SensorColumn.DataPropertyName = "Sensor";
		SensorColumn.FillWeight = 92.72417f;
		SensorColumn.HeaderText = "传感器";
		SensorColumn.MinimumWidth = 8;
		SensorColumn.Name = "SensorColumn";
		SensorColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
		SensorType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		SensorType.DataPropertyName = "SensorType";
		SensorType.FillWeight = 92.72417f;
		SensorType.HeaderText = "传感器类型";
		SensorType.MinimumWidth = 8;
		SensorType.Name = "SensorType";
		SensorType.SortMode = DataGridViewColumnSortMode.NotSortable;
		Active.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		Active.DataPropertyName = "Active";
		Active.FillWeight = 121.8274f;
		Active.HeaderText = "启用";
		Active.MinimumWidth = 60;
		Active.Name = "Active";
		Active.Width = 60;
		Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Status.DataPropertyName = "Status";
		Status.FillWeight = 92.72417f;
		Status.HeaderText = "状态";
		Status.MinimumWidth = 8;
		Status.Name = "Status";
		Status.Resizable = DataGridViewTriState.True;
		Status.SortMode = DataGridViewColumnSortMode.NotSortable;
		TS_Edit.AutoSize = false;
		TS_Edit.BackColor = Color.FromArgb(60, 63, 65);
		TS_Edit.Dock = DockStyle.Bottom;
		TS_Edit.ForeColor = Color.FromArgb(220, 220, 220);
		TS_Edit.GripStyle = ToolStripGripStyle.Hidden;
		TS_Edit.ImageScalingSize = new Size(24, 24);
		TS_Edit.Items.AddRange(new ToolStripItem[3] { TSB_AddSensor, TSB_RemoveSensor, TSB_RemoveMCM });
		TS_Edit.Location = new Point(0, 313);
		TS_Edit.Name = "TS_Edit";
		TS_Edit.Padding = new Padding(5, 0, 1, 0);
		TS_Edit.Size = new Size(681, 25);
		TS_Edit.TabIndex = 14;
		TS_Edit.Text = "ToolStrip1";
		TSB_AddSensor.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddSensor.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddSensor.Image = componentResourceManager.GetObject("TSB_AddSensor.Image");
		TSB_AddSensor.ImageTransparentColor = Color.Magenta;
		TSB_AddSensor.Name = "TSB_AddSensor";
		TSB_AddSensor.Padding = new Padding(0, 0, 0, 20);
		TSB_AddSensor.Size = new Size(133, 20);
		TSB_AddSensor.Text = "添加传感器";
		TSB_RemoveSensor.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveSensor.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveSensor.Image = componentResourceManager.GetObject("TSB_RemoveSensor.Image");
		TSB_RemoveSensor.ImageTransparentColor = Color.Magenta;
		TSB_RemoveSensor.Name = "TSB_RemoveSensor";
		TSB_RemoveSensor.Size = new Size(163, 20);
		TSB_RemoveSensor.Text = "移除传感器";
		TSB_RemoveMCM.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveMCM.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveMCM.Image = componentResourceManager.GetObject("TSB_RemoveMCM.Image");
		TSB_RemoveMCM.ImageTransparentColor = Color.Magenta;
		TSB_RemoveMCM.Name = "TSB_RemoveMCM";
		TSB_RemoveMCM.Size = new Size(152, 20);
		TSB_RemoveMCM.Text = "移除扫雷传感器";
		Label1.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(3, 27);
		Label1.Name = "Label1";
		Label1.Size = new Size(99, 13);
		Label1.TabIndex = 13;
		Label1.Text = "快速选择：";
		CB_ECM.AutoSize = true;
		CB_ECM.CheckAlign = ContentAlignment.BottomRight;
		CB_ECM.Location = new Point(279, 26);
		CB_ECM.Name = "CB_ECM";
		CB_ECM.RightToLeft = RightToLeft.Yes;
		CB_ECM.Size = new Size(154, 29);
		CB_ECM.TabIndex = 12;
		CB_ECM.Text = "进攻性ECM";
		CB_radar.AutoSize = true;
		CB_radar.CheckAlign = ContentAlignment.BottomRight;
		CB_radar.Location = new Point(116, 26);
		CB_radar.Name = "CB_radar";
		CB_radar.RightToLeft = RightToLeft.Yes;
		CB_radar.Size = new Size(92, 29);
		CB_radar.TabIndex = 10;
		CB_radar.Text = "雷达";
		CB_Sonar.AutoSize = true;
		CB_Sonar.CheckAlign = ContentAlignment.BottomRight;
		CB_Sonar.Location = new Point(200, 26);
		CB_Sonar.Name = "CB_Sonar";
		CB_Sonar.RightToLeft = RightToLeft.Yes;
		CB_Sonar.Size = new Size(92, 29);
		CB_Sonar.TabIndex = 11;
		CB_Sonar.Text = "声呐";
		CB_ObeyEMCON.Location = new Point(3, 2);
		CB_ObeyEMCON.Name = "CB_ObeyEMCON";
		CB_ObeyEMCON.Size = new Size(300, 17);
		CB_ObeyEMCON.TabIndex = 9;
		CB_ObeyEMCON.Text = "单元服从EMCON（禁用手动传感器控制）";
		lbl_decoy_emitter.AutoSize = true;
		lbl_decoy_emitter.ForeColor = Color.FromArgb(220, 220, 220);
		lbl_decoy_emitter.Location = new Point(7, 280);
		lbl_decoy_emitter.Name = "lbl_decoy_emitter";
		lbl_decoy_emitter.Size = new Size(123, 25);
		lbl_decoy_emitter.TabIndex = 15;
		lbl_decoy_emitter.Text = "Decoy Emitter";
		btn_relink_decoy.BackColor = Color.Transparent;
		btn_relink_decoy.DialogResult = DialogResult.None;
		btn_relink_decoy.ForeColor = SystemColors.Control;
		btn_relink_decoy.Location = new Point(531, 285);
		btn_relink_decoy.Name = "btn_relink_decoy";
		btn_relink_decoy.RoundRadius = 0;
		btn_relink_decoy.Size = new Size(139, 25);
		btn_relink_decoy.TabIndex = 16;
		btn_relink_decoy.Text = "Relink Decoy";
		cmb_relink_decoy.BackColor = Color.Transparent;
		cmb_relink_decoy.DrawMode = DrawMode.OwnerDrawFixed;
		cmb_relink_decoy.DropDownStyle = ComboBoxStyle.DropDownList;
		cmb_relink_decoy.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		cmb_relink_decoy.FormattingEnabled = true;
		cmb_relink_decoy.Location = new Point(137, 285);
		cmb_relink_decoy.Name = "cmb_relink_decoy";
		cmb_relink_decoy.Size = new Size(388, 27);
		cmb_relink_decoy.TabIndex = 17;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(681, 338);
		base.Controls.Add(cmb_relink_decoy);
		base.Controls.Add(btn_relink_decoy);
		base.Controls.Add(lbl_decoy_emitter);
		base.Controls.Add(DGV_Sensors);
		base.Controls.Add(TS_Edit);
		base.Controls.Add(Label1);
		base.Controls.Add(CB_ECM);
		base.Controls.Add(CB_radar);
		base.Controls.Add(CB_Sonar);
		base.Controls.Add(CB_ObeyEMCON);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(200, 200);
		base.Name = "UnitSensors";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "传感器：";
		((ISupportInitialize)DGV_Sensors).EndInit();
		TS_Edit.ResumeLayout(performLayout: false);
		TS_Edit.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] resolverVisitor = _ResolverVisitor;
		int num = 0;
		while (true)
		{
			if (num < resolverVisitor.Length)
			{
				Keys keys = resolverVisitor[num];
				if (keyData == keys)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		if (base.ActiveControl == null)
		{
			Activate();
		}
		else
		{
			Close();
		}
		return true;
	}

	private void SelectInterruptibleItem(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		if (ItemExporter.ConnectInterruptibleTemplate.AddSensor.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AddSensor.Close();
		}
	}

	private void CallInterruptibleItem(object sender, EventArgs e)
	{
		Doctrine.EmconChanged += LoginInterruptibleItem;
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		lbl_decoy_emitter.Visible = false;
		btn_relink_decoy.Visible = false;
		cmb_relink_decoy.Visible = false;
		if (Client.SelectedUnit.IsActiveUnit)
		{
			m_IndexerVisitor = (ActiveUnit)Client.SelectedUnit;
			if (((ActiveUnit)Client.SelectedUnit).IsDecoy)
			{
				lbl_decoy_emitter.Visible = true;
				btn_relink_decoy.Visible = true;
				cmb_relink_decoy.Visible = true;
				lbl_decoy_emitter.Text = ((ActiveUnit)Client.SelectedUnit).UnitType_String;
				LogoutInterruptibleItem();
			}
		}
		Text = "传感器：" + Client.SelectedUnit.Name;
		Client.SelectedUnitChanged += GetInterruptibleItem;
	}

	private void LogoutInterruptibleItem()
	{
		DataTable dataTable = new DataTable();
		switch (((ActiveUnit)Client.SelectedUnit).UnitType)
		{
		default:
			return;
		case GlobalVariables.ActiveUnitType.Aircraft:
			dataTable = Client.CurrentScenario.Cache_Aircraft_DT;
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			dataTable = Client.CurrentScenario.Cache_Ships_DT;
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			dataTable = Client.CurrentScenario.Cache_Subs_DT;
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			dataTable = Client.CurrentScenario.Cache_Facilities_DT;
			break;
		case GlobalVariables.ActiveUnitType.Aimpoint:
		case GlobalVariables.ActiveUnitType.Weapon:
		case GlobalVariables.ActiveUnitType.Satellite:
			return;
		case GlobalVariables.ActiveUnitType.Vehicle:
			dataTable = Client.CurrentScenario.Cache_GroundUnits_DT;
			break;
		}
		cmb_relink_decoy.DataSource = dataTable;
		cmb_relink_decoy.DisplayMember = "LongName";
	}

	private void ViewInterruptibleItem(object sender, EventArgs e)
	{
		if (DGV_Sensors.ReadOnly)
		{
			DGV_Sensors.ForeColor = Color.Gray;
			DGV_Sensors.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			DGV_Sensors.ForeColor = Color.Black;
			DGV_Sensors.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		BuildForm();
		BuildForm();
	}

	private void ValidateInterruptibleItem(object sender, EventArgs e)
	{
		BuildForm();
	}

	private void LoginInterruptibleItem(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (!bool_3 && scenarioObject_0 != null && scenarioObject_0.IsActiveUnit && (!bool_0 || scenarioObject_0 == Client.SelectedUnit) && nullable_0.HasValue && base.Visible && scenarioObject_0.IsActiveUnit && scenarioObject_0 == m_IndexerVisitor)
		{
			BuildForm();
		}
	}

	private void GetInterruptibleItem(Module_Unit.Unit unit_0)
	{
		if (base.Visible && unit_0 != null && unit_0.IsActiveUnit)
		{
			m_IndexerVisitor = (ActiveUnit)unit_0;
			BuildForm();
		}
	}

	public void BuildForm()
	{
		BuildForm_Detailed();
		WriteInterruptibleItem();
	}

	private void WriteInterruptibleItem()
	{
		if (Information.IsNothing(m_IndexerVisitor))
		{
			return;
		}
		statusVisitor.Clear();
		proccesorVisitor.Clear();
		_StrategyVisitor.Clear();
		if (!m_IndexerVisitor.IsActiveUnit)
		{
			return;
		}
		ActiveUnit indexerVisitor = m_IndexerVisitor;
		Sensor[] array = indexerVisitor.Sensors_ReadOnly();
		Sensor[] array2 = array;
		foreach (Sensor sensor in array2)
		{
			if (sensor.Type == Sensor.Sensor_Type.Radar)
			{
				statusVisitor.Add(sensor);
			}
		}
		IEnumerable<Sensor> source = statusVisitor.Where((Sensor theS) => theS.IsActive);
		if (source.Count() == 0)
		{
			CB_radar.Checked = false;
		}
		else if (source.Count() == statusVisitor.Count)
		{
			CB_radar.Checked = true;
		}
		else
		{
			CB_radar.CheckState = CheckState.Indeterminate;
		}
		array = indexerVisitor.Sensors_ReadOnly();
		Sensor[] array3 = array;
		foreach (Sensor sensor2 in array3)
		{
			if (sensor2.IsSonar)
			{
				proccesorVisitor.Add(sensor2);
			}
		}
		IEnumerable<Sensor> source2 = proccesorVisitor.Where((Sensor theS) => theS.IsActive);
		if (source2.Count() == 0)
		{
			CB_Sonar.Checked = false;
		}
		else if (source2.Count() == proccesorVisitor.Count)
		{
			CB_Sonar.Checked = true;
		}
		else
		{
			CB_Sonar.CheckState = CheckState.Indeterminate;
		}
		array = indexerVisitor.Sensors_ReadOnly();
		Sensor[] array4 = array;
		foreach (Sensor sensor3 in array4)
		{
			if (sensor3.IsOECM)
			{
				_StrategyVisitor.Add(sensor3);
			}
		}
		IEnumerable<Sensor> source3 = _StrategyVisitor.Where((Sensor theS) => theS.IsActive);
		if (source3.Count() == 0)
		{
			CB_ECM.Checked = false;
		}
		else if (source3.Count() == _StrategyVisitor.Count)
		{
			CB_ECM.Checked = true;
		}
		else
		{
			CB_ECM.CheckState = CheckState.Indeterminate;
		}
		CB_radar.Enabled = !DGV_Sensors.ReadOnly;
		CB_Sonar.Enabled = !DGV_Sensors.ReadOnly;
		CB_ECM.Enabled = !DGV_Sensors.ReadOnly;
		if (Client.SelectedUnit.IsActiveUnit)
		{
			if (!((ActiveUnit)Client.SelectedUnit).HasRadarSensor && Client.SelectedUnit.IsActiveUnit)
			{
				CB_radar.Enabled = false;
			}
			if (!((ActiveUnit)Client.SelectedUnit).HasSonarSensor)
			{
				CB_Sonar.Enabled = false;
			}
			if (!((ActiveUnit)Client.SelectedUnit).HasOECMSensor)
			{
				CB_ECM.Enabled = false;
			}
		}
	}

	public void BuildForm_Detailed()
	{
		TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		if (Information.IsNothing(m_IndexerVisitor) || !m_IndexerVisitor.IsActiveUnit)
		{
			return;
		}
		SetupInterruptibleItem();
		if (Information.IsNothing(m_IndexerVisitor) || !m_IndexerVisitor.IsActiveUnit)
		{
			return;
		}
		Text = "传感器：" + m_IndexerVisitor.Name;
		DGV_Sensors.DataSource = _ContextVisitor;
		IEnumerator enumerator = null;
		try
		{
			enumerator = DGV_Sensors.Columns.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((DataGridViewColumn)enumerator.Current).SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		DGV_Sensors.Columns["CanBeActive"].Visible = false;
		DGV_Sensors.Columns["Order#"].Visible = false;
		DGV_Sensors.Columns["ObjectID"].Visible = false;
		DGV_Sensors.Columns["MCM"].Visible = false;
		DGV_Sensors.Columns["POD"].Visible = false;
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = ((IEnumerable)DGV_Sensors.Rows).GetEnumerator();
			while (enumerator2.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator2.Current;
				if (Conversions.ToBoolean(dataGridViewRow.Cells["MCM"].Value))
				{
					if (!m_IndexerVisitor.MineCountermeasures[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)].CanBeActive)
					{
						dataGridViewRow.ReadOnly = true;
					}
				}
				else if (!m_IndexerVisitor.Sensors_ReadOnly()[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)].CanBeActive)
				{
					dataGridViewRow.ReadOnly = true;
				}
				Conversions.ToBoolean(dataGridViewRow.Cells["POD"].Value);
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		DGV_Sensors.Columns["Active"].Width = 40;
		DGV_Sensors.Columns["SensorType"].HeaderText = "传感器类型";
		ExcludeInterruptibleItem();
		CB_ObeyEMCON.Checked = m_IndexerVisitor.Sensory.Boolean_0;
		DGV_Sensors.ReadOnly = m_IndexerVisitor.Sensory.Boolean_0;
	}

	public void RefreshForm()
	{
		if (configurationVisitor)
		{
			return;
		}
		configurationVisitor = true;
		try
		{
			if (Information.IsNothing(m_IndexerVisitor))
			{
				DGV_Sensors.Columns.Clear();
			}
			else if (m_IndexerVisitor.GetUnitSide() == Client.CurrentSide)
			{
				BuildForm();
			}
			else
			{
				DGV_Sensors.Columns.Clear();
			}
			TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200107", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		configurationVisitor = false;
	}

	private void NewInterruptibleItem(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex != -1 && e.ColumnIndex != -1 && !DGV_Sensors.ReadOnly && DGV_Sensors.Rows.Count != 0)
			{
				DataGridViewRow dataGridViewRow = DGV_Sensors.Rows[e.RowIndex];
				if ((Conversions.ToBoolean(DGV_Sensors.Rows[e.RowIndex].Cells["MCM"].Value) ? m_IndexerVisitor.MineCountermeasures[Conversions.ToInteger(DGV_Sensors.Rows[e.RowIndex].Cells["Order#"].Value)] : m_IndexerVisitor.Sensors_ReadOnly()[Conversions.ToInteger(DGV_Sensors.Rows[e.RowIndex].Cells["Order#"].Value)]).Status == PlatformComponent._ComponentStatus.Destroyed)
				{
					dataGridViewRow.Selected = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200108", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PushInterruptibleItem(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			if (e.RowIndex == -1 || DGV_Sensors.ReadOnly || DGV_Sensors.Rows.Count == 0)
			{
				return;
			}
			DataGridViewColumn dataGridViewColumn = DGV_Sensors.Columns[e.ColumnIndex];
			Sensor sensor = null;
			sensor = (Conversions.ToBoolean(DGV_Sensors.Rows[e.RowIndex].Cells["MCM"].Value) ? m_IndexerVisitor.MineCountermeasures[Conversions.ToInteger(DGV_Sensors.Rows[e.RowIndex].Cells["Order#"].Value)] : m_IndexerVisitor.Sensors_ReadOnly()[Conversions.ToInteger(DGV_Sensors.Rows[e.RowIndex].Cells["Order#"].Value)]);
			if (sensor.Status != 0 || Operators.CompareString(dataGridViewColumn.Name, "Active", TextCompare: true) != 0)
			{
				return;
			}
			int num = Conversions.ToInteger(DGV_Sensors.Rows[e.RowIndex].Cells["Order#"].Value);
			if (!sensor.CanBeActive)
			{
				return;
			}
			if (!Conversions.ToBoolean(DGV_Sensors.Rows[e.RowIndex].Cells["Active"].Value) && !sensor.IsActive)
			{
				sensor.GoActive();
				DGV_Sensors.Rows[e.RowIndex].Cells["Active"].Value = true;
			}
			else if (Conversions.ToBoolean(DGV_Sensors.Rows[e.RowIndex].Cells["Active"].Value) && sensor.IsActive)
			{
				sensor.GoPassive();
				DGV_Sensors.Rows[e.RowIndex].Cells["Active"].Value = false;
			}
			if (m_IndexerVisitor.IsAircraft)
			{
				Sensor[] array = m_IndexerVisitor.Sensors_ReadOnly();
				string objectID = array[num].ObjectID;
				for (int i = array.Length - 1; i >= 0; i += -1)
				{
					sensor = array[i];
					if (Operators.CompareString(sensor.ObjectID, objectID, TextCompare: true) == 0)
					{
						DGV_Sensors.Rows[i].Cells["Active"].Value = RuntimeHelpers.GetObjectValue(DGV_Sensors.Rows[e.RowIndex].Cells["Active"].Value);
					}
				}
			}
			BuildForm();
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200109", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InvokeInterruptibleItem(object sender, DataGridViewCellEventArgs e)
	{
		BuildForm();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
	}

	private void SetupInterruptibleItem()
	{
		if (Information.IsNothing(m_IndexerVisitor) || !m_IndexerVisitor.IsActiveUnit)
		{
			return;
		}
		DGV_Sensors.DataSource = null;
		DGV_Sensors.Rows.Clear();
		_ContextVisitor.Columns.Clear();
		_ContextVisitor.Rows.Clear();
		_ContextVisitor.Columns.Add("Sensor", typeof(string));
		_ContextVisitor.Columns.Add("SensorType", typeof(string));
		_ContextVisitor.Columns.Add("Active", typeof(bool));
		_ContextVisitor.Columns.Add("Status", typeof(string));
		_ContextVisitor.Columns.Add("ObjectID", typeof(string));
		_ContextVisitor.Columns.Add("Order#", typeof(int));
		_ContextVisitor.Columns.Add("CanBeActive", typeof(bool));
		_ContextVisitor.Columns.Add("MCM", typeof(bool));
		_ContextVisitor.Columns.Add("POD", typeof(bool));
		Sensor[] array = m_IndexerVisitor.Sensors_ReadOnly();
		int num = array.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor sensor = array[i];
			DataRow dataRow = _ContextVisitor.NewRow();
			dataRow["ObjectID"] = sensor.ObjectID;
			dataRow["Order#"] = i;
			dataRow["CanBeActive"] = sensor.CanBeActive;
			dataRow["Sensor"] = Misc.ReadRequest(sensor.Name + (string)Interaction.IIf(sensor.IsSensorInMount, "^", ""));
			dataRow["SensorType"] = sensor.RoleDescription;
			dataRow["Active"] = sensor.IsActive;
			if (sensor.Status == PlatformComponent._ComponentStatus.Operational && Operators.CompareString(sensor.ReasonForInoperative, "None", TextCompare: true) != 0)
			{
				dataRow["Status"] = "未工作（" + sensor.ReasonForInoperative + ")";
			}
			else
			{
				dataRow["Status"] = sensor.Status.ToString();
			}
			dataRow["MCM"] = false;
			dataRow["POD"] = false;
			if (!m_IndexerVisitor.MineCountermeasures.Contains(sensor))
			{
				if (m_IndexerVisitor.IsAircraft && ((Aircraft)m_IndexerVisitor).Loadout != null && sensor.IsSensorInLoadout)
				{
					dataRow["SensorType"] = "^" + sensor.RoleDescription;
					dataRow["POD"] = true;
				}
				_ContextVisitor.Rows.Add(dataRow);
			}
		}
		if (m_IndexerVisitor.MineCountermeasures.Count <= 0)
		{
			return;
		}
		List<Sensor> mineCountermeasures = m_IndexerVisitor.MineCountermeasures;
		int num2 = mineCountermeasures.Count - 1;
		for (int j = 0; j <= num2; j++)
		{
			Sensor sensor2 = mineCountermeasures[j];
			DataRow dataRow2 = _ContextVisitor.NewRow();
			dataRow2["ObjectID"] = sensor2.ObjectID;
			dataRow2["Order#"] = j;
			dataRow2["CanBeActive"] = sensor2.CanBeActive;
			dataRow2["Sensor"] = Misc.ReadRequest(sensor2.Name);
			dataRow2["SensorType"] = "*" + sensor2.RoleDescription;
			dataRow2["Active"] = sensor2.IsActive;
			if (sensor2.Status == PlatformComponent._ComponentStatus.Operational && Operators.CompareString(sensor2.ReasonForInoperative, "None", TextCompare: true) != 0)
			{
				dataRow2["Status"] = "未工作（" + sensor2.ReasonForInoperative + ")";
			}
			else
			{
				dataRow2["Status"] = sensor2.Status.ToString();
			}
			dataRow2["MCM"] = true;
			dataRow2["POD"] = false;
			if (m_IndexerVisitor.IsAircraft && sensor2.IsSensorInLoadout && sensor2.IsSensorInLoadout)
			{
				dataRow2["POD"] = true;
				dataRow2["SensorType"] = "^*" + sensor2.RoleDescription;
			}
			_ContextVisitor.Rows.Add(dataRow2);
		}
	}

	private void ExcludeInterruptibleItem()
	{
		int num = DGV_Sensors.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataGridViewRow dataGridViewRow = DGV_Sensors.Rows[i];
			Sensor sensor = null;
			sensor = (Conversions.ToBoolean(dataGridViewRow.Cells["MCM"].Value) ? m_IndexerVisitor.MineCountermeasures[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)] : m_IndexerVisitor.Sensors_ReadOnly()[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)]);
			if (sensor.Status == PlatformComponent._ComponentStatus.Operational)
			{
				dataGridViewRow.DefaultCellStyle.ForeColor = Color.LightGray;
			}
			else
			{
				dataGridViewRow.DefaultCellStyle.ForeColor = GetComponentDamageColor(sensor);
				dataGridViewRow.ReadOnly = true;
			}
			DataGridViewCell dataGridViewCell = DGV_Sensors.Rows[Conversions.ToInteger(dataGridViewRow.Cells["Order#"].Value)].Cells["Active"];
			if (!sensor.CanBeActive)
			{
				dataGridViewCell.ReadOnly = true;
				dataGridViewCell.Value = false;
			}
		}
	}

	private void IncludeInterruptibleItem(object sender, EventArgs e)
	{
		bool @checked;
		if (@checked = CB_radar.Checked)
		{
			if (@checked)
			{
				foreach (Sensor item in statusVisitor)
				{
					if (!item.IsPureIlluminator && !item.IsActive)
					{
						item.GoActive();
					}
				}
			}
		}
		else
		{
			foreach (Sensor item2 in statusVisitor)
			{
				if (!item2.IsPureIlluminator && item2.IsActive)
				{
					item2.GoPassive();
				}
			}
		}
		BuildForm_Detailed();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
	}

	private void SearchInterruptibleItem(object sender, EventArgs e)
	{
		bool @checked;
		if (@checked = CB_Sonar.Checked)
		{
			if (@checked)
			{
				foreach (Sensor item in proccesorVisitor)
				{
					if (!item.IsPureIlluminator && (!item.IsActive & item.CanBeActive))
					{
						item.GoActive();
					}
				}
			}
		}
		else
		{
			foreach (Sensor item2 in proccesorVisitor)
			{
				if (!item2.IsPureIlluminator && item2.IsActive)
				{
					item2.GoPassive();
				}
			}
		}
		BuildForm_Detailed();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
	}

	private void EnableInterruptibleItem(object sender, EventArgs e)
	{
		bool @checked;
		if (@checked = CB_ECM.Checked)
		{
			if (@checked)
			{
				foreach (Sensor item in _StrategyVisitor)
				{
					if (!item.IsActive)
					{
						item.GoActive();
					}
				}
			}
		}
		else
		{
			foreach (Sensor item2 in _StrategyVisitor)
			{
				if (item2.IsActive)
				{
					item2.GoPassive();
				}
			}
		}
		BuildForm_Detailed();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
	}

	private void ChangeInterruptibleItem(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.AddSensor.FormThatCalledMe = this;
		ItemExporter.ConnectInterruptibleTemplate.AddSensor.Show();
		Client.MustRefreshMainForm = true;
	}

	private void InitInterruptibleItem(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if (e.RowIndex <= -1 || e.ColumnIndex != DGV_Sensors.Columns.IndexOf(DGV_Sensors.Columns["Active"]))
		{
			return;
		}
		if (Conversions.ToBoolean(DGV_Sensors.Rows[e.RowIndex].Cells["CanBeActive"].Value))
		{
			if (Operators.CompareString(Conversions.ToString(DGV_Sensors.Rows[e.RowIndex].Cells["Status"].Value), "Damaged", TextCompare: true) == 0 || Operators.CompareString(Conversions.ToString(DGV_Sensors.Rows[e.RowIndex].Cells["Status"].Value), "Destroyed", TextCompare: true) == 0)
			{
				e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
				e.Handled = true;
			}
		}
		else
		{
			e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
			e.Handled = true;
		}
	}

	private void CheckInterruptibleItem(object sender, EventArgs e)
	{
		if (DGV_Sensors.ReadOnly)
		{
			DGV_Sensors.ForeColor = Color.Gray;
			DGV_Sensors.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
		else
		{
			DGV_Sensors.ForeColor = Color.Black;
			DGV_Sensors.RowsDefaultCellStyle.SelectionForeColor = Color.Gray;
		}
	}

	private void ConcatInterruptibleItem(object sender, EventArgs e)
	{
		if (DGV_Sensors.SelectedRows.Count > 0)
		{
			tokenVisitor = Conversions.ToString(DGV_Sensors.SelectedRows[0].Cells["ObjectID"].Value);
			if (Operators.CompareString(Conversions.ToString(DGV_Sensors.SelectedRows[0].Cells["POD"].Value), "True", TextCompare: true) == 0)
			{
				TSB_RemoveMCM.Visible = false;
				TSB_RemoveSensor.Visible = false;
			}
			else if (Operators.CompareString(Conversions.ToString(DGV_Sensors.SelectedRows[0].Cells["MCM"].Value), "True", TextCompare: true) == 0)
			{
				TSB_RemoveMCM.Visible = true;
				TSB_RemoveSensor.Visible = false;
			}
			else
			{
				TSB_RemoveMCM.Visible = false;
				TSB_RemoveSensor.Visible = true;
			}
		}
	}

	private void InterruptInterruptibleItem(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(tokenVisitor) || !m_IndexerVisitor.IsActiveUnit)
		{
			return;
		}
		ActiveUnit indexerVisitor = m_IndexerVisitor;
		Sensor[] array = indexerVisitor.Sensors_ReadOnly();
		Sensor sensor = null;
		Sensor[] array2 = array;
		Sensor[] array3 = array2;
		foreach (Sensor sensor2 in array3)
		{
			if (Operators.CompareString(sensor2.ObjectID, tokenVisitor, TextCompare: true) == 0)
			{
				sensor = sensor2;
				break;
			}
		}
		if (!Information.IsNothing(sensor))
		{
			indexerVisitor.RemoveSensor(sensor);
			BuildForm();
		}
		Client.MustRefreshMainForm = true;
	}

	private void RemoveInterruptibleItem(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(tokenVisitor) || !m_IndexerVisitor.IsActiveUnit)
		{
			return;
		}
		ActiveUnit indexerVisitor = m_IndexerVisitor;
		Sensor sensor = null;
		if (indexerVisitor.MineCountermeasures.Count > 0)
		{
			foreach (Sensor mineCountermeasure in indexerVisitor.MineCountermeasures)
			{
				if (Operators.CompareString(mineCountermeasure.ObjectID, tokenVisitor, TextCompare: true) == 0)
				{
					sensor = mineCountermeasure;
					break;
				}
			}
		}
		if (!Information.IsNothing(sensor))
		{
			indexerVisitor.RemoveSensor(sensor);
			BuildForm();
		}
		Client.MustRefreshMainForm = true;
	}

	private void FindInterruptibleItem(object sender, EventArgs e)
	{
		m_IndexerVisitor.Sensory.Boolean_0 = CB_ObeyEMCON.Checked;
		DGV_Sensors.ReadOnly = m_IndexerVisitor.Sensory.Boolean_0;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.EmconControl1.InstantiateMethod(bool_0: true);
		BuildForm();
	}

	private void SetInterruptibleItem(object sender, EventArgs e)
	{
		RefreshForm();
		RunInterruptibleItem().Stop();
	}

	private void FillInterruptibleItem(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F9 && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Space))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CalculateInterruptibleItem(object sender, FormClosedEventArgs e)
	{
		Client.SelectedUnitChanged -= GetInterruptibleItem;
		Doctrine.EmconChanged -= LoginInterruptibleItem;
	}

	private void PopInterruptibleItem(object sender, EventArgs e)
	{
		foreach (ActiveUnit unit in Client.SelectedUnit.GetUnitSide().Units)
		{
			if (Operators.CompareString(unit.ObjectID, Client.SelectedUnit.ObjectID, TextCompare: true) != 0)
			{
				continue;
			}
			switch (unit.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				try
				{
					Scenario scenario_5 = Client.CurrentScenario;
					Aircraft aircraft_ = (Aircraft)unit;
					DBFunctions.GetAircraft(ref scenario_5, ref aircraft_, Conversions.ToInteger(((DataRowView)cmb_relink_decoy.SelectedItem)[0]));
				}
				catch (Exception ex10)
				{
					ProjectData.SetProjectError(ex10);
					Exception ex2 = ex10;
					DarkMessageBox.ShowError("错误：" + ex2.Message, "Error");
					ProjectData.ClearProjectError();
				}
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				try
				{
					Scenario scenario_4 = Client.CurrentScenario;
					Ship ship_ = (Ship)unit;
					DBFunctions.GetShip(ref scenario_4, ref ship_, Conversions.ToInteger(((DataRow)cmb_relink_decoy.SelectedItem).ItemArray[0]));
				}
				catch (Exception ex8)
				{
					ProjectData.SetProjectError(ex8);
					Exception ex9 = ex8;
					DarkMessageBox.ShowError("错误：" + ex9.Message, "Error");
					ProjectData.ClearProjectError();
				}
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				try
				{
					Scenario scenario_3 = Client.CurrentScenario;
					Submarine submarine_ = (Submarine)unit;
					DBFunctions.GetSubmarine(ref scenario_3, ref submarine_, Conversions.ToInteger(((DataRow)cmb_relink_decoy.SelectedItem).ItemArray[0]));
				}
				catch (Exception ex6)
				{
					ProjectData.SetProjectError(ex6);
					Exception ex7 = ex6;
					DarkMessageBox.ShowError("错误：" + ex7.Message, "Error");
					ProjectData.ClearProjectError();
				}
				break;
			case GlobalVariables.ActiveUnitType.Facility:
				try
				{
					Scenario scenario_2 = Client.CurrentScenario;
					Facility facility_ = (Facility)unit;
					DBFunctions.GetFacility(ref scenario_2, ref facility_, Conversions.ToInteger(((DataRow)cmb_relink_decoy.SelectedItem).ItemArray[0]));
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception ex5 = ex4;
					DarkMessageBox.ShowError("错误：" + ex5.Message, "Error");
					ProjectData.ClearProjectError();
				}
				break;
			case GlobalVariables.ActiveUnitType.Vehicle:
				try
				{
					Scenario scenario_ = Client.CurrentScenario;
					Vehicle vehicle_ = (Vehicle)unit;
					DBFunctions.GetVehicle(ref scenario_, ref vehicle_, Conversions.ToInteger(((DataRow)cmb_relink_decoy.SelectedItem).ItemArray[0]));
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex3 = ex;
					Interaction.MsgBox("错误：" + ex3.Message);
					ProjectData.ClearProjectError();
				}
				break;
			}
			unit.Weaponry.Disarm();
			unit.Name = "DECOY " + ((DataRowView)cmb_relink_decoy.SelectedItem)[2].ToString();
			m_IndexerVisitor = unit;
			BuildForm();
			break;
		}
	}
}
