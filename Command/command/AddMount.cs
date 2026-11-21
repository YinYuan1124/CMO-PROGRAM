using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
public sealed class AddMount : DarkSecondaryFormBase
{
	private IContainer m_FacadeProperty;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView m_ProxyProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private BackgroundWorker _ReaderProperty;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton propertyProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Filter1")]
	private DarkCheckBox importerProperty;

	[AccessedThroughProperty("TB_Find")]
	[CompilerGenerated]
	private DarkUITextBox m_RepositoryProperty;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel m_InvocationProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("ID")]
	private DataGridViewTextBoxColumn m_ClassProperty;

	[AccessedThroughProperty("Description")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn requestProperty;

	private DataTable _ValueProperty;

	private DataView _TokenizerProperty;

	private bool _StubProperty;

	public Form FormThatCalledMe;

	public ActiveUnit targetUnit;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProxyProperty = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return propertyProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutTask;
			DarkUIButton darkUIButton = propertyProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			propertyProperty = value;
			darkUIButton = propertyProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Filter1
	{
		[CompilerGenerated]
		get
		{
			return importerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupTask;
			DarkCheckBox darkCheckBox = importerProperty;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			importerProperty = value;
			darkCheckBox = importerProperty;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkUITextBox TB_Find
	{
		[CompilerGenerated]
		get
		{
			return m_RepositoryProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = LoginTask;
			EventHandler value3 = PushTask;
			EventHandler value4 = InvokeTask;
			DarkUITextBox repositoryProperty = m_RepositoryProperty;
			if (repositoryProperty != null)
			{
				repositoryProperty.TextChanged -= value2;
				repositoryProperty.Enter -= value3;
				repositoryProperty.Leave -= value4;
			}
			m_RepositoryProperty = value;
			repositoryProperty = m_RepositoryProperty;
			if (repositoryProperty != null)
			{
				repositoryProperty.TextChanged += value2;
				repositoryProperty.Enter += value3;
				repositoryProperty.Leave += value4;
			}
		}
	}

	[field: AccessedThroughProperty("ArcControl1")]
	internal PlatformComponentArcControl ArcControl1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationProperty = value;
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return m_ClassProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClassProperty = value;
		}
	}

	internal DataGridViewTextBoxColumn Description
	{
		[CompilerGenerated]
		get
		{
			return requestProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			requestProperty = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker EnableTask()
	{
		return _ReaderProperty;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ChangeTask(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = ViewTask;
		RunWorkerCompletedEventHandler value2 = ValidateTask;
		BackgroundWorker readerProperty = _ReaderProperty;
		if (readerProperty != null)
		{
			readerProperty.DoWork -= value;
			readerProperty.RunWorkerCompleted -= value2;
		}
		_ReaderProperty = backgroundWorker_0;
		readerProperty = _ReaderProperty;
		if (readerProperty != null)
		{
			readerProperty.DoWork += value;
			readerProperty.RunWorkerCompleted += value2;
		}
	}

	public AddMount()
	{
		base.Load += CallTask;
		base.KeyDown += NewTask;
		base.FormClosing += ExcludeTask;
		targetUnit = null;
		SelectTask();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_FacadeProperty != null)
			{
				m_FacadeProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SelectTask()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		ChangeTask(new BackgroundWorker());
		Button1 = new DarkUIButton();
		CB_Filter1 = new DarkCheckBox();
		TB_Find = new DarkUITextBox();
		ArcControl1 = new PlatformComponentArcControl();
		Label3 = new DarkLabel();
		((ISupportInitialize)DataGridView1).BeginInit();
		SuspendLayout();
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
		DataGridView1.Columns.AddRange(ID, Description);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(0, 110);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.Size = new Size(503, 404);
		DataGridView1.TabIndex = 1;
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Width = 41;
		Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Description.DataPropertyName = "Name";
		Description.HeaderText = "名称";
		Description.Name = "Description";
		Description.ReadOnly = true;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(7, 5);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(89, 23);
		Button1.TabIndex = 3;
		Button1.Text = "添加所选项";
		CB_Filter1.AutoSize = true;
		CB_Filter1.Location = new Point(7, 62);
		CB_Filter1.Name = "CB_Filter1";
		CB_Filter1.Size = new Size(119, 19);
		CB_Filter1.TabIndex = 13;
		CB_Filter1.Text = "按关键字过滤：";
		TB_Find.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = AutoCompleteMode.None;
		TB_Find.AutoCompleteSource = AutoCompleteSource.None;
		TB_Find.BackColor = Color.Transparent;
		TB_Find.Font = new Font("Segoe UI", 10f);
		TB_Find.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		TB_Find.Location = new Point(7, 85);
		TB_Find.MaxLength = 32767;
		TB_Find.Multiline = false;
		TB_Find.Name = "TB_Find";
		TB_Find.ReadOnly = false;
		TB_Find.ScrollBars = ScrollBars.None;
		TB_Find.SelectionStart = 0;
		TB_Find.Size = new Size(386, 20);
		TB_Find.TabIndex = 12;
		TB_Find.TextAlign = HorizontalAlignment.Left;
		TB_Find.UseSystemPasswordChar = false;
		TB_Find.WatermarkText = "";
		ArcControl1.AutoSize = true;
		ArcControl1.BackColor = Color.FromArgb(60, 63, 65);
		ArcControl1.Location = new Point(399, 4);
		ArcControl1.Name = "ArcControl1";
		ArcControl1.Size = new Size(103, 100);
		ArcControl1.TabIndex = 14;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(179, 10);
		Label3.Name = "Label3";
		Label3.Size = new Size(226, 13);
		Label3.TabIndex = 19;
		Label3.Text = "提示：双击以选择或取消选择所有角度";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(503, 514);
		base.Controls.Add(Label3);
		base.Controls.Add(ArcControl1);
		base.Controls.Add(CB_Filter1);
		base.Controls.Add(TB_Find);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddMount";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "添加武器挂载点";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CallTask(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		EnableTask().RunWorkerAsync();
	}

	private void LogoutTask(object sender, EventArgs e)
	{
		ActiveUnit activeUnit = null;
		if (targetUnit == null)
		{
			if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
			{
				activeUnit = (ActiveUnit)Client.SelectedUnit;
			}
		}
		else
		{
			activeUnit = targetUnit;
		}
		if (activeUnit == null)
		{
			return;
		}
		if (ArcControl1.NoArcsSelected)
		{
			DarkMessageBox.ShowError("您必须为此弹药选择覆盖角度", "没有选择覆盖角度！");
			return;
		}
		int int_ = Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value);
		Scenario scenario_ = Client.CurrentScenario;
		Mount mount_ = DBFunctions.GetMount(int_, ref scenario_);
		mount_.Coverage = ArcControl1.theCoverage.Clone();
		activeUnit.Mounts.Add(mount_);
		mount_.ParentPlatform = activeUnit;
		Sensor[] sensors_ReadOnly = mount_.Sensors_ReadOnly;
		Sensor[] array2 = sensors_ReadOnly;
		foreach (Sensor obj in array2)
		{
			obj.ParentPlatform = activeUnit;
			obj.Coverage = mount_.Coverage;
			obj.Coverage_Illuminate = mount_.Coverage;
		}
		bool flag = false;
		if (mount_.CompatibleDirectors.Count <= 0)
		{
			flag = true;
		}
		else
		{
			Sensor[] array = activeUnit.Sensors_ReadOnly();
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				if (flag = array[i].CanDirectThisMount(ref mount_))
				{
					break;
				}
			}
		}
		if (!flag && mount_.CompatibleDirectors.Count > 0 && DarkMessageBox.ShowWarning("The mount you have added misses a director, do you want to add one ?", "Director Needed", DarkDialogButton.YesNo) == DialogResult.Yes)
		{
			Client.theSensorsWindow = new UnitSensors();
			Client.theSensorsWindow.Show();
			ItemExporter.ConnectInterruptibleTemplate.AddSensor.FormThatCalledMe = Client.theSensorsWindow;
			ItemExporter.ConnectInterruptibleTemplate.AddSensor.Show();
			Client.MustRefreshMainForm = true;
			AddSensor addSensor = ItemExporter.ConnectInterruptibleTemplate.AddSensor;
			int int_2 = mount_.CompatibleDirectors.ElementAtOrDefault(0);
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			addSensor.InjectFilterByKeyword(DBFunctions.GetSensor(int_2, ref sqliteConnection_).Name);
		}
	}

	private void ViewTask(object sender, DoWorkEventArgs e)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		_ValueProperty = DBFunctions.GetAllMounts(ref sqliteConnection_);
	}

	private void ValidateTask(object sender, RunWorkerCompletedEventArgs e)
	{
		WriteTask();
	}

	private void LoginTask(object object_0)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			GetTask();
		}
	}

	private void GetTask()
	{
		DataView dataView = new DataView(_ValueProperty);
		dataView.Sort = "Name ASC";
		dataView.RowFilter = "Name LIKE '%" + Misc.PatchValue(TB_Find.Text) + "%'";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	private void WriteTask()
	{
		_TokenizerProperty = new DataView(_ValueProperty);
		_TokenizerProperty.Sort = "Name ASC";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = _TokenizerProperty;
	}

	private void NewTask(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (_StubProperty)
		{
			if (e.KeyValue == 13 && base.Visible)
			{
				CB_Filter1.Select();
				return;
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!_StubProperty && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PushTask(object sender, EventArgs e)
	{
		_StubProperty = true;
	}

	private void InvokeTask(object sender, EventArgs e)
	{
		_StubProperty = false;
		CB_Filter1.Select();
	}

	private void SetupTask(object sender, EventArgs e)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			GetTask();
		}
		else
		{
			WriteTask();
		}
	}

	private void ExcludeTask(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
