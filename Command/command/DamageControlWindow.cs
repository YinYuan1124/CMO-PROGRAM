using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class DamageControlWindow : DarkSecondaryFormBase, GInterface9
{
	[CompilerGenerated]
	private sealed class ValueListenerMapping
	{
		public PlatformComponent Local_theComponent;

		internal bool WriteInterruptiblePage(Sensor theSensor)
		{
			return Operators.CompareString(theSensor.ObjectID, Local_theComponent.ObjectID, TextCompare: true) == 0;
		}
	}

	private IContainer stubValue;

	[AccessedThroughProperty("TGV_Damage")]
	[CompilerGenerated]
	private DarkTreeGridView m_WriterValue;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStrip1")]
	private DarkToolStrip m_SpecificationValue;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripLabel1")]
	private ToolStripLabel watcherValue;

	[CompilerGenerated]
	[AccessedThroughProperty("Status")]
	private TreeGridColumn reponseValue;

	[AccessedThroughProperty("TS_EditDamage")]
	[CompilerGenerated]
	private DarkToolStrip descriptorValue;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripLabel2")]
	private ToolStripLabel poolValue;

	[AccessedThroughProperty("TSC_ComponentStatus")]
	[CompilerGenerated]
	private ToolStripComboBox m_TaskValue;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer _FilterValue;

	[AccessedThroughProperty("TSTB_Damage")]
	[CompilerGenerated]
	private ToolStripTextBox interpreterValue;

	[AccessedThroughProperty("Timer2")]
	[CompilerGenerated]
	private Timer containerValue;

	[AccessedThroughProperty("ToolStripLabel5")]
	[CompilerGenerated]
	private ToolStripLabel m_ModelValue;

	[CompilerGenerated]
	[AccessedThroughProperty("TSC_Fire")]
	private ToolStripComboBox m_AdvisorValue;

	[CompilerGenerated]
	[AccessedThroughProperty("ComponentName")]
	private TreeGridColumn serializerValue;

	[CompilerGenerated]
	[AccessedThroughProperty("ComponentStatus")]
	private TreeGridColumn m_RefValue;

	public ActiveUnit theSelectedUnit;

	public Game theCurrentGame;

	private PlatformComponent m_ErrorValue;

	[CompilerGenerated]
	[AccessedThroughProperty("CB1")]
	private ComboBox _CodeValue;

	[CompilerGenerated]
	[AccessedThroughProperty("CB2")]
	private ComboBox m_ConnectionValue;

	[CompilerGenerated]
	[AccessedThroughProperty("CB3")]
	private ComboBox _ContextValue;

	private bool _StatusValue;

	private bool proccesorValue;

	private Keys[] strategyValue;

	private DarkTreeGridView TGV_Damage
	{
		[CompilerGenerated]
		get
		{
			return m_WriterValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = ConcatPublisher;
			DarkTreeGridView writerValue = m_WriterValue;
			if (writerValue != null)
			{
				writerValue.CellMouseClick -= value2;
			}
			m_WriterValue = value;
			writerValue = m_WriterValue;
			if (writerValue != null)
			{
				writerValue.CellMouseClick += value2;
			}
		}
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return m_SpecificationValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SpecificationValue = value;
		}
	}

	internal ToolStripLabel ToolStripLabel1
	{
		[CompilerGenerated]
		get
		{
			return watcherValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			watcherValue = value;
		}
	}

	internal TreeGridColumn Status
	{
		[CompilerGenerated]
		get
		{
			return reponseValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			reponseValue = value;
		}
	}

	internal DarkToolStrip TS_EditDamage
	{
		[CompilerGenerated]
		get
		{
			return descriptorValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			descriptorValue = value;
		}
	}

	internal ToolStripLabel ToolStripLabel2
	{
		[CompilerGenerated]
		get
		{
			return poolValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			poolValue = value;
		}
	}

	internal ToolStripComboBox TSC_ComponentStatus
	{
		[CompilerGenerated]
		get
		{
			return m_TaskValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TaskValue = value;
		}
	}

	[field: AccessedThroughProperty("ToolStripLabel3")]
	internal ToolStripLabel ToolStripLabel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripTextBox TSTB_Damage
	{
		[CompilerGenerated]
		get
		{
			return interpreterValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindPublisher;
			EventHandler value3 = PopPublisher;
			EventHandler value4 = InstantiatePublisher;
			ToolStripTextBox toolStripTextBox = interpreterValue;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.TextChanged -= value2;
				toolStripTextBox.Enter -= value3;
				toolStripTextBox.Leave -= value4;
			}
			interpreterValue = value;
			toolStripTextBox = interpreterValue;
			if (toolStripTextBox != null)
			{
				toolStripTextBox.TextChanged += value2;
				toolStripTextBox.Enter += value3;
				toolStripTextBox.Leave += value4;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripLabel4")]
	internal ToolStripLabel ToolStripLabel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripLabel ToolStripLabel5
	{
		[CompilerGenerated]
		get
		{
			return m_ModelValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ModelValue = value;
		}
	}

	internal ToolStripComboBox TSC_Fire
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorValue = value;
		}
	}

	[field: AccessedThroughProperty("TSC_Flood")]
	internal ToolStripComboBox TSC_Flood
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TreeGridColumn ComponentName
	{
		[CompilerGenerated]
		get
		{
			return serializerValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerValue = value;
		}
	}

	internal TreeGridColumn ComponentStatus
	{
		[CompilerGenerated]
		get
		{
			return m_RefValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RefValue = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer PostPublisher()
	{
		return _FilterValue;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RunPublisher(Timer timer_0)
	{
		_FilterValue = timer_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer AwakePublisher()
	{
		return containerValue;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void QueryPublisher(Timer timer_0)
	{
		EventHandler value = SetPublisher;
		Timer timer = containerValue;
		if (timer != null)
		{
			timer.Tick -= value;
		}
		containerValue = timer_0;
		timer = containerValue;
		if (timer != null)
		{
			timer.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ComboBox CustomizeServer()
	{
		return _CodeValue;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void CloneServer(ComboBox comboBox_0)
	{
		EventHandler value = InterruptPublisher;
		ComboBox codeValue = _CodeValue;
		if (codeValue != null)
		{
			codeValue.SelectionChangeCommitted -= value;
		}
		_CodeValue = comboBox_0;
		codeValue = _CodeValue;
		if (codeValue != null)
		{
			codeValue.SelectionChangeCommitted += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ComboBox MoveServer()
	{
		return m_ConnectionValue;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void DeleteServer(ComboBox comboBox_0)
	{
		EventHandler value = CreatePublisher;
		ComboBox connectionValue = m_ConnectionValue;
		if (connectionValue != null)
		{
			connectionValue.SelectionChangeCommitted -= value;
		}
		m_ConnectionValue = comboBox_0;
		connectionValue = m_ConnectionValue;
		if (connectionValue != null)
		{
			connectionValue.SelectionChangeCommitted += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ComboBox DestroyServer()
	{
		return _ContextValue;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void ComputeServer(ComboBox comboBox_0)
	{
		EventHandler value = ComparePublisher;
		ComboBox contextValue = _ContextValue;
		if (contextValue != null)
		{
			contextValue.SelectionChangeCommitted -= value;
		}
		_ContextValue = comboBox_0;
		contextValue = _ContextValue;
		if (contextValue != null)
		{
			contextValue.SelectionChangeCommitted += value;
		}
	}

	public DamageControlWindow()
	{
		base.Load += EnablePublisher;
		base.KeyDown += ChangePublisher;
		base.FormClosing += FillPublisher;
		base.FormClosed += CalculatePublisher;
		strategyValue = new Keys[2]
		{
			Keys.F1,
			Keys.Escape
		};
		SearchPublisher();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && stubValue != null)
			{
				stubValue.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SearchPublisher()
	{
		stubValue = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		TGV_Damage = new DarkTreeGridView();
		Status = new TreeGridColumn();
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TS_EditDamage = new DarkToolStrip();
		ToolStripLabel2 = new ToolStripLabel();
		TSC_ComponentStatus = new ToolStripComboBox();
		ToolStripLabel3 = new ToolStripLabel();
		TSTB_Damage = new ToolStripTextBox();
		ToolStripLabel4 = new ToolStripLabel();
		TSC_Fire = new ToolStripComboBox();
		ToolStripLabel5 = new ToolStripLabel();
		TSC_Flood = new ToolStripComboBox();
		QueryPublisher(new Timer(stubValue));
		ComponentName = new TreeGridColumn();
		ComponentStatus = new TreeGridColumn();
		((ISupportInitialize)TGV_Damage).BeginInit();
		ToolStrip1.SuspendLayout();
		TS_EditDamage.SuspendLayout();
		SuspendLayout();
		TGV_Damage.AllowUserToAddRows = false;
		TGV_Damage.AllowUserToDeleteRows = false;
		TGV_Damage.AllowUserToOrderColumns = true;
		TGV_Damage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_Damage.BackgroundColor = Color.FromArgb(43, 43, 43);
		TGV_Damage.BorderStyle = BorderStyle.None;
		TGV_Damage.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Damage.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_Damage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_Damage.Columns.AddRange(ComponentName, ComponentStatus);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_Damage.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_Damage.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Damage.EnableHeadersVisualStyles = false;
		TGV_Damage.ImageList = null;
		TGV_Damage.Location = new Point(2, 28);
		TGV_Damage.Name = "TGV_Damage";
		TGV_Damage.RowHeadersVisible = false;
		TGV_Damage.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Damage.ShowLines = false;
		TGV_Damage.Size = new Size(471, 233);
		TGV_Damage.TabIndex = 5;
		Status.DefaultNodeImage = null;
		Status.HeaderText = "状态";
		Status.Name = "Status";
		Status.ReadOnly = true;
		Status.Resizable = DataGridViewTriState.True;
		Status.SortMode = DataGridViewColumnSortMode.NotSortable;
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.ImageScalingSize = new Size(20, 20);
		ToolStrip1.Items.AddRange(new ToolStripItem[1] { ToolStripLabel1 });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(475, 25);
		ToolStrip1.TabIndex = 6;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(69, 22);
		ToolStripLabel1.Text = "损伤：";
		TS_EditDamage.AutoSize = false;
		TS_EditDamage.BackColor = Color.FromArgb(60, 63, 65);
		TS_EditDamage.Dock = DockStyle.Bottom;
		TS_EditDamage.ForeColor = Color.FromArgb(220, 220, 220);
		TS_EditDamage.GripStyle = ToolStripGripStyle.Hidden;
		TS_EditDamage.ImageScalingSize = new Size(20, 20);
		TS_EditDamage.Items.AddRange(new ToolStripItem[8] { ToolStripLabel2, TSC_ComponentStatus, ToolStripLabel3, TSTB_Damage, ToolStripLabel4, TSC_Fire, ToolStripLabel5, TSC_Flood });
		TS_EditDamage.Location = new Point(0, 264);
		TS_EditDamage.Name = "TS_EditDamage";
		TS_EditDamage.Padding = new Padding(5, 0, 1, 0);
		TS_EditDamage.Size = new Size(475, 25);
		TS_EditDamage.TabIndex = 7;
		TS_EditDamage.Text = "ToolStrip2";
		ToolStripLabel2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel2.Name = "ToolStripLabel2";
		ToolStripLabel2.Size = new Size(52, 22);
		ToolStripLabel2.Text = "状态：";
		TSC_ComponentStatus.BackColor = Color.FromArgb(60, 63, 65);
		TSC_ComponentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
		TSC_ComponentStatus.ForeColor = Color.FromArgb(220, 220, 220);
		TSC_ComponentStatus.Items.AddRange(new object[5] { "正常工作", "受损（轻度）", "受损（中度）", "受损（重度）", "被摧毁" });
		TSC_ComponentStatus.Name = "TSC_ComponentStatus";
		TSC_ComponentStatus.Size = new Size(121, 25);
		ToolStripLabel3.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel3.Name = "ToolStripLabel3";
		ToolStripLabel3.Size = new Size(120, 22);
		ToolStripLabel3.Text = "整体损伤：";
		TSTB_Damage.BackColor = Color.FromArgb(60, 63, 65);
		TSTB_Damage.ForeColor = Color.FromArgb(220, 220, 220);
		TSTB_Damage.MaxLength = 5;
		TSTB_Damage.Name = "TSTB_Damage";
		TSTB_Damage.Size = new Size(50, 25);
		ToolStripLabel4.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel4.Name = "ToolStripLabel4";
		ToolStripLabel4.Size = new Size(33, 22);
		ToolStripLabel4.Text = "火情";
		TSC_Fire.BackColor = Color.FromArgb(60, 63, 65);
		TSC_Fire.DropDownWidth = 100;
		TSC_Fire.ForeColor = Color.FromArgb(220, 220, 220);
		TSC_Fire.Items.AddRange(new object[5] { "无火情", "轻微", "中度", "严重", "特大火灾" });
		TSC_Fire.Name = "TSC_Fire";
		TSC_Fire.Size = new Size(121, 28);
		ToolStripLabel5.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel5.Name = "ToolStripLabel5";
		ToolStripLabel5.Size = new Size(47, 20);
		ToolStripLabel5.Text = "漏水";
		TSC_Flood.BackColor = Color.FromArgb(60, 63, 65);
		TSC_Flood.DropDownWidth = 100;
		TSC_Flood.ForeColor = Color.FromArgb(220, 220, 220);
		TSC_Flood.Items.AddRange(new object[5] { "无漏水", "轻微", "中度", "严重", "倾覆中" });
		TSC_Flood.Name = "TSC_Flood";
		TSC_Flood.Size = new Size(121, 28);
		ComponentName.DefaultNodeImage = null;
		ComponentName.HeaderText = "名称";
		ComponentName.Name = "ComponentName";
		ComponentName.ReadOnly = true;
		ComponentName.SortMode = DataGridViewColumnSortMode.NotSortable;
		ComponentName.Width = 200;
		ComponentStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		ComponentStatus.DefaultNodeImage = null;
		ComponentStatus.HeaderText = "状态";
		ComponentStatus.Name = "ComponentStatus";
		ComponentStatus.ReadOnly = true;
		ComponentStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(475, 289);
		base.Controls.Add(TS_EditDamage);
		base.Controls.Add(ToolStrip1);
		base.Controls.Add(TGV_Damage);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "DamageControlWindow";
		base.ShowIcon = false;
		Text = "组件状态";
		((ISupportInitialize)TGV_Damage).EndInit();
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		TS_EditDamage.ResumeLayout(performLayout: false);
		TS_EditDamage.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = strategyValue;
		Keys[] array2 = array;
		foreach (Keys keys in array2)
		{
			if (keyData == keys)
			{
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
		}
		return false;
	}

	private void EnablePublisher(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (!Information.IsNothing(theCurrentGame))
		{
			TS_EditDamage.Visible = theCurrentGame.GameMode == Game._GameMode.ScenEdit;
		}
		CloneServer(TSC_ComponentStatus.ComboBox);
		DeleteServer(TSC_Fire.ComboBox);
		ComputeServer(TSC_Flood.ComboBox);
		AwakePublisher().Start();
		InitPublisher();
		m_ErrorValue = (PlatformComponent)TGV_Damage.CurrentNode.Tag;
		PlatformComponent.StatusChanged += RemovePublisher;
	}

	private void ChangePublisher(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (e.KeyCode == Keys.F10 && base.Visible)
		{
			Close();
			return;
		}
		if (proccesorValue && (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (!proccesorValue)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void InitPublisher()
	{
		TGV_Damage.Rows.Clear();
		TGV_Damage.Nodes.Clear();
		ToolStripLabel1.Text = "损伤：" + string.Format("{0:0.0}", theSelectedUnit.Damage.DamagePercent, 1) + "%";
		Text = "组件状态" + Misc.ReadRequest(theSelectedUnit.Name);
		if (theSelectedUnit.Mounts.Count > 0)
		{
			TreeGridNode treeGridNode = new TreeGridNode();
			new TreeGridNode();
			treeGridNode = TGV_Damage.Nodes.Add("Mounts");
			foreach (Mount mount in theSelectedUnit.Mounts)
			{
				TreeGridNode treeGridNode12 = treeGridNode.Nodes.Add(Misc.ReadRequest(mount.Name), mount.Status.ToString());
				treeGridNode12.Tag = mount;
				treeGridNode12.DefaultCellStyle.ForeColor = GetComponentDamageColor(mount);
			}
			treeGridNode.Expand();
		}
		if (((Platform)theSelectedUnit).Magazines.Count() > 0)
		{
			TreeGridNode treeGridNode15 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode15 = TGV_Damage.Nodes.Add("Magazines");
			Magazine[] magazines = ((Platform)theSelectedUnit).Magazines;
			Magazine[] array2 = magazines;
			foreach (Magazine magazine in array2)
			{
				TreeGridNode treeGridNode16 = treeGridNode15.Nodes.Add(Misc.ReadRequest(magazine.Name), magazine.Status.ToString());
				treeGridNode16.Tag = magazine;
				treeGridNode16.DefaultCellStyle.ForeColor = GetComponentDamageColor(magazine);
			}
			treeGridNode15.Expand();
		}
		if (theSelectedUnit.Sensors_ReadOnly().Length != 0)
		{
			TreeGridNode treeGridNode17 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode17 = TGV_Damage.Nodes.Add("Sensors");
			Sensor[] array = theSelectedUnit.Sensors_ReadOnly();
			Sensor[] array3 = array;
			foreach (Sensor sensor in array3)
			{
				TreeGridNode treeGridNode18 = treeGridNode17.Nodes.Add(Misc.ReadRequest(sensor.Name), sensor.Status.ToString());
				treeGridNode18.Tag = sensor;
				treeGridNode18.DefaultCellStyle.ForeColor = GetComponentDamageColor(sensor);
			}
			treeGridNode17.Expand();
		}
		if (theSelectedUnit.Comms_ReadOnly.Count() > 0)
		{
			TreeGridNode treeGridNode19 = new TreeGridNode();
			TreeGridNode treeGridNode20 = new TreeGridNode();
			treeGridNode19 = TGV_Damage.Nodes.Add("通讯和数据链接");
			CommDevice[] comms_ReadOnly = theSelectedUnit.Comms_ReadOnly;
			CommDevice[] array4 = comms_ReadOnly;
			foreach (CommDevice commDevice in array4)
			{
				string text = commDevice.Status.ToString();
				if (commDevice.Status == PlatformComponent._ComponentStatus.Operational && commDevice.IsJammed)
				{
					text += " - 被干扰";
				}
				treeGridNode20 = treeGridNode19.Nodes.Add(Misc.ReadRequest(commDevice.Name), text);
				treeGridNode20.Tag = commDevice;
				treeGridNode20.DefaultCellStyle.ForeColor = GetComponentDamageColor(commDevice);
				if (commDevice.Status == PlatformComponent._ComponentStatus.Operational && commDevice.IsJammed)
				{
					treeGridNode20.DefaultCellStyle.ForeColor = Color.Blue;
				}
			}
			treeGridNode19.Expand();
		}
		if (theSelectedUnit.MineCountermeasures.Count > 0)
		{
			TreeGridNode treeGridNode21 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode21 = TGV_Damage.Nodes.Add("Mine Counter Measures");
			foreach (Sensor mineCountermeasure in theSelectedUnit.MineCountermeasures)
			{
				string text2 = mineCountermeasure.Status.ToString();
				TreeGridNode treeGridNode2 = treeGridNode21.Nodes.Add(Misc.ReadRequest(mineCountermeasure.Name), text2);
				treeGridNode2.Tag = mineCountermeasure;
				treeGridNode2.DefaultCellStyle.ForeColor = GetComponentDamageColor(mineCountermeasure);
			}
			treeGridNode21.Expand();
		}
		if (theSelectedUnit.DockFacilities_ReadOnly.Length != 0)
		{
			TreeGridNode treeGridNode3 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode3 = TGV_Damage.Nodes.Add("停靠设施");
			DockFacility[] dockFacilities_ReadOnly = theSelectedUnit.DockFacilities_ReadOnly;
			DockFacility[] array5 = dockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in array5)
			{
				TreeGridNode treeGridNode4 = treeGridNode3.Nodes.Add(Misc.ReadRequest(dockFacility.Name), dockFacility.Status.ToString());
				treeGridNode4.Tag = dockFacility;
				treeGridNode4.DefaultCellStyle.ForeColor = GetComponentDamageColor(dockFacility);
			}
			treeGridNode3.Expand();
		}
		if (theSelectedUnit.AirFacilities_ReadOnly.Length != 0)
		{
			TreeGridNode treeGridNode5 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode5 = TGV_Damage.Nodes.Add("空军设施");
			for (int i = theSelectedUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
			{
				AirFacility airFacility = theSelectedUnit.AirFacilities_ReadOnly[i];
				string text3 = "";
				text3 = (((int)airFacility.MaxAircraftSize <= (int)airFacility.EffectiveRunwaySize) ? airFacility.Status.ToString() : "可运行，能力减少");
				TreeGridNode treeGridNode6 = treeGridNode5.Nodes.Add(Misc.ReadRequest(airFacility.Name), text3);
				treeGridNode6.Tag = airFacility;
				treeGridNode6.DefaultCellStyle.ForeColor = GetComponentDamageColor(airFacility);
			}
			treeGridNode5.Expand();
		}
		if (((Platform)theSelectedUnit).Propulsion.Count > 0)
		{
			TreeGridNode treeGridNode7 = new TreeGridNode();
			new TreeGridNode();
			treeGridNode7 = TGV_Damage.Nodes.Add("引擎/推进器");
			foreach (Engine item in theSelectedUnit.Propulsion)
			{
				TreeGridNode treeGridNode8 = treeGridNode7.Nodes.Add(Misc.ReadRequest(item.Name), item.Status.ToString());
				treeGridNode8.Tag = item;
				treeGridNode8.DefaultCellStyle.ForeColor = GetComponentDamageColor(item);
			}
			treeGridNode7.Expand();
		}
		switch (theSelectedUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Ship:
		{
			TreeGridNode treeGridNode13 = TGV_Damage.Nodes.Add(((Ship)theSelectedUnit).CIC.Name, ((Ship)theSelectedUnit).CIC.Status.ToString());
			treeGridNode13.Tag = ((Ship)theSelectedUnit).CIC;
			treeGridNode13.DefaultCellStyle.ForeColor = GetComponentDamageColor(((Ship)theSelectedUnit).CIC);
			TreeGridNode treeGridNode14 = TGV_Damage.Nodes.Add(((Ship)theSelectedUnit).Rudder.Name, ((Ship)theSelectedUnit).Rudder.Status.ToString());
			treeGridNode14.Tag = ((Ship)theSelectedUnit).Rudder;
			treeGridNode14.DefaultCellStyle.ForeColor = GetComponentDamageColor(((Ship)theSelectedUnit).Rudder);
			break;
		}
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			TreeGridNode treeGridNode10 = TGV_Damage.Nodes.Add(((Submarine)theSelectedUnit).CIC.Name, ((Submarine)theSelectedUnit).CIC.Status.ToString());
			treeGridNode10.Tag = ((Submarine)theSelectedUnit).CIC;
			treeGridNode10.DefaultCellStyle.ForeColor = GetComponentDamageColor(((Submarine)theSelectedUnit).CIC);
			TreeGridNode treeGridNode11 = TGV_Damage.Nodes.Add(((Submarine)theSelectedUnit).Rudder.Name, ((Submarine)theSelectedUnit).Rudder.Status.ToString());
			treeGridNode11.Tag = ((Submarine)theSelectedUnit).Rudder;
			treeGridNode11.DefaultCellStyle.ForeColor = GetComponentDamageColor(((Submarine)theSelectedUnit).Rudder);
			break;
		}
		case GlobalVariables.ActiveUnitType.Facility:
		{
			TreeGridNode treeGridNode9 = TGV_Damage.Nodes.Add(((Facility)theSelectedUnit).CIC.Name, ((Facility)theSelectedUnit).CIC.Status.ToString());
			treeGridNode9.Tag = ((Facility)theSelectedUnit).CIC;
			treeGridNode9.DefaultCellStyle.ForeColor = GetComponentDamageColor(((Facility)theSelectedUnit).CIC);
			break;
		}
		}
		MoveServer().SelectedIndex = Math.Min(Math.Max(0, (int)theSelectedUnit.Damage.FireIntensity), 4);
		if (!Client.SelectedUnit.IsSubmarine && !Client.SelectedUnit.IsShip)
		{
			DestroyServer().Enabled = false;
			return;
		}
		DestroyServer().Enabled = true;
		DestroyServer().SelectedIndex = (int)theSelectedUnit.Damage.FloodIntensity;
	}

	public void RefreshForm()
	{
		foreach (TreeGridNode node in TGV_Damage.Nodes)
		{
			CheckPublisher(node);
		}
	}

	private void CheckPublisher(TreeGridNode treeGridNode_0)
	{
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(treeGridNode_0.Tag)))
		{
			PlatformComponent platformComponent = (PlatformComponent)treeGridNode_0.Tag;
			string text = platformComponent.Status.ToString();
			if ((object)platformComponent.GetType() == typeof(CommDevice) && platformComponent.Status == PlatformComponent._ComponentStatus.Operational && ((CommDevice)platformComponent).IsJammed)
			{
				text += " - 被干扰";
				treeGridNode_0.DefaultCellStyle.ForeColor = Color.Blue;
			}
			treeGridNode_0.SetValues(platformComponent.Name, text);
			treeGridNode_0.DefaultCellStyle.ForeColor = GetComponentDamageColor(platformComponent);
		}
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			CheckPublisher(node);
		}
	}

	private void ConcatPublisher(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(TGV_Damage.CurrentNode.Tag)))
		{
			return;
		}
		m_ErrorValue = (PlatformComponent)TGV_Damage.CurrentNode.Tag;
		switch (m_ErrorValue.Status)
		{
		case PlatformComponent._ComponentStatus.Operational:
			TSC_ComponentStatus.SelectedIndex = 0;
			break;
		case PlatformComponent._ComponentStatus.Damaged:
			switch (m_ErrorValue.DamageSeverity)
			{
			case PlatformComponent._DamageSeverityFactor.Light:
				TSC_ComponentStatus.SelectedIndex = 1;
				break;
			case PlatformComponent._DamageSeverityFactor.Medium:
				TSC_ComponentStatus.SelectedIndex = 2;
				break;
			case PlatformComponent._DamageSeverityFactor.Heavy:
				TSC_ComponentStatus.SelectedIndex = 3;
				break;
			}
			break;
		case PlatformComponent._ComponentStatus.Destroyed:
			TSC_ComponentStatus.SelectedIndex = 4;
			break;
		}
	}

	private void InterruptPublisher(object sender, EventArgs e)
	{
		foreach (TreeGridNode item in InterpreterObjectListener.FlushInterruptibleTask(TGV_Damage))
		{
			if (!item.Selected || Information.IsNothing(RuntimeHelpers.GetObjectValue(item.Tag)))
			{
				continue;
			}
			m_ErrorValue = (PlatformComponent)item.Tag;
			if (!Information.IsNothing(m_ErrorValue))
			{
				switch (CustomizeServer().SelectedIndex)
				{
				case 0:
					m_ErrorValue.MakeOperational(bool_0: true);
					break;
				case 1:
					m_ErrorValue.Damage(PlatformComponent._DamageSeverityFactor.Light);
					break;
				case 2:
					m_ErrorValue.Damage(PlatformComponent._DamageSeverityFactor.Medium);
					break;
				case 3:
					m_ErrorValue.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
					break;
				case 4:
					m_ErrorValue.Destroy(theSelectedUnit.GetUnitSide(), bool_0: true, bool_1: false);
					break;
				}
			}
		}
	}

	private void RemovePublisher(PlatformComponent platformComponent_0)
	{
		if (platformComponent_0.ParentPlatform == theSelectedUnit)
		{
			_StatusValue = true;
		}
		else
		{
			if ((object)platformComponent_0.GetType() != typeof(Sensor) || platformComponent_0.ParentPlatform == null || !platformComponent_0.ParentPlatform.IsWeapon)
			{
				return;
			}
			using IEnumerator<Sensor> enumerator = (from theSensor in theSelectedUnit.Sensors_ReadOnly()
				where Operators.CompareString(theSensor.ObjectID, platformComponent_0.ObjectID, TextCompare: true) == 0
				select theSensor).GetEnumerator();
			if (enumerator.MoveNext())
			{
				_ = enumerator.Current;
				_StatusValue = true;
			}
		}
	}

	private void FindPublisher(object sender, EventArgs e)
	{
		if (!((Operators.CompareString(TSTB_Damage.Text, "", TextCompare: true) == 0) | !Versioned.IsNumeric(TSTB_Damage.Text)))
		{
			if (Conversions.ToDouble(TSTB_Damage.Text) < 0.0)
			{
				TSTB_Damage.Text = 0.ToString();
			}
			if (Conversions.ToDouble(TSTB_Damage.Text) > 100.0)
			{
				TSTB_Damage.Text = 100.ToString();
			}
			theSelectedUnit.SetDamagePts(bool_0: false, null, (float)((double)theSelectedUnit.InitialDP * ((100.0 - Conversions.ToDouble(TSTB_Damage.Text)) / 100.0)));
			ToolStripLabel1.Text = "损伤：" + string.Format("{0:0.0}", theSelectedUnit.Damage.DamagePercent, 2) + "%";
		}
	}

	private void SetPublisher(object sender, EventArgs e)
	{
		if (_StatusValue)
		{
			RefreshForm();
			_StatusValue = false;
		}
	}

	private void FillPublisher(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
	}

	private void CalculatePublisher(object sender, FormClosedEventArgs e)
	{
		PlatformComponent.StatusChanged -= RemovePublisher;
	}

	private void PopPublisher(object sender, EventArgs e)
	{
		proccesorValue = true;
	}

	private void InstantiatePublisher(object sender, EventArgs e)
	{
		proccesorValue = false;
		ToolStripLabel2.Select();
	}

	private void CreatePublisher(object sender, EventArgs e)
	{
		ActiveUnit_Damage.FireIntensityLevel fireIntensity = theSelectedUnit.Damage.FireIntensity;
		switch (MoveServer().SelectedIndex)
		{
		case 0:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.NoFire;
			break;
		case 1:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Minor;
			break;
		case 2:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Major;
			break;
		case 3:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Severe;
			break;
		case 4:
			fireIntensity = ActiveUnit_Damage.FireIntensityLevel.Conflagration;
			break;
		}
		theSelectedUnit.Damage.FireIntensity = fireIntensity;
	}

	private void ComparePublisher(object sender, EventArgs e)
	{
		ActiveUnit_Damage.FloodingIntensityLevel floodIntensity = theSelectedUnit.Damage.FloodIntensity;
		switch (DestroyServer().SelectedIndex)
		{
		case 0:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.NoFlooding;
			break;
		case 1:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Minor;
			break;
		case 2:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Major;
			break;
		case 3:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Severe;
			break;
		case 4:
			floodIntensity = ActiveUnit_Damage.FloodingIntensityLevel.Capsizing;
			break;
		}
		theSelectedUnit.Damage.FloodIntensity = floodIntensity;
	}
}
