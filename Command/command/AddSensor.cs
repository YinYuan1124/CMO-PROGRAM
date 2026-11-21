using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
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
public sealed class AddSensor : DarkSecondaryFormBase
{
	private IContainer _VisitorProperty;

	[AccessedThroughProperty("DataGridView1")]
	[CompilerGenerated]
	private DarkDataGridView m_ExporterProperty;

	[AccessedThroughProperty("BW1")]
	[CompilerGenerated]
	private BackgroundWorker _PrototypeProperty;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_ComparatorProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Filter1")]
	private DarkCheckBox itemProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Find")]
	private DarkUITextBox setterProperty;

	[AccessedThroughProperty("ArcControl_Illumination")]
	[CompilerGenerated]
	private PlatformComponentArcControl m_CreatorProperty;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel templateProperty;

	[AccessedThroughProperty("ArcControl_Detection")]
	[CompilerGenerated]
	private PlatformComponentArcControl m_MappingProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel m_MockProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("ID")]
	private DataGridViewTextBoxColumn m_FieldProperty;

	private DataTable regProperty;

	private DataView paramProperty;

	private bool m_PageProperty;

	public Form FormThatCalledMe;

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterProperty = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitFilter;
			DarkUIButton comparatorProperty = m_ComparatorProperty;
			if (comparatorProperty != null)
			{
				comparatorProperty.Click -= value2;
			}
			m_ComparatorProperty = value;
			comparatorProperty = m_ComparatorProperty;
			if (comparatorProperty != null)
			{
				comparatorProperty.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Filter1
	{
		[CompilerGenerated]
		get
		{
			return itemProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunFilter;
			DarkCheckBox darkCheckBox = itemProperty;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			itemProperty = value;
			darkCheckBox = itemProperty;
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
			return setterProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = StopFilter;
			EventHandler value3 = ResolveFilter;
			EventHandler value4 = PostFilter;
			DarkUITextBox darkUITextBox = setterProperty;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
				darkUITextBox.Enter -= value3;
				darkUITextBox.Leave -= value4;
			}
			setterProperty = value;
			darkUITextBox = setterProperty;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
				darkUITextBox.Enter += value3;
				darkUITextBox.Leave += value4;
			}
		}
	}

	internal PlatformComponentArcControl ArcControl_Illumination
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorProperty = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return templateProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			templateProperty = value;
		}
	}

	internal PlatformComponentArcControl ArcControl_Detection
	{
		[CompilerGenerated]
		get
		{
			return m_MappingProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingProperty = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_MockProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockProperty = value;
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return m_FieldProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FieldProperty = value;
		}
	}

	[field: AccessedThroughProperty("Description")]
	internal DataGridViewTextBoxColumn Description
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker DefineFilter()
	{
		return _PrototypeProperty;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void PublishFilter(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = RestartFilter;
		RunWorkerCompletedEventHandler value2 = TestFilter;
		BackgroundWorker prototypeProperty = _PrototypeProperty;
		if (prototypeProperty != null)
		{
			prototypeProperty.DoWork -= value;
			prototypeProperty.RunWorkerCompleted -= value2;
		}
		_PrototypeProperty = backgroundWorker_0;
		prototypeProperty = _PrototypeProperty;
		if (prototypeProperty != null)
		{
			prototypeProperty.DoWork += value;
			prototypeProperty.RunWorkerCompleted += value2;
		}
	}

	public AddSensor()
	{
		base.Load += ReflectFilter;
		base.KeyDown += ListFilter;
		base.FormClosing += StartFilter;
		PrepareFilter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _VisitorProperty != null)
			{
				_VisitorProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PrepareFilter()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Description = new DataGridViewTextBoxColumn();
		PublishFilter(new BackgroundWorker());
		Button1 = new DarkUIButton();
		CB_Filter1 = new DarkCheckBox();
		TB_Find = new DarkUITextBox();
		Label1 = new DarkLabel();
		ArcControl_Illumination = new PlatformComponentArcControl();
		ArcControl_Detection = new PlatformComponentArcControl();
		Label2 = new DarkLabel();
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
		DataGridView1.Location = new Point(0, 159);
		DataGridView1.MultiSelect = false;
		DataGridView1.Name = "DataGridView1";
		DataGridView1.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DataGridView1.Size = new Size(503, 355);
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
		CB_Filter1.Location = new Point(7, 111);
		CB_Filter1.Name = "CB_Filter1";
		CB_Filter1.Size = new Size(119, 19);
		CB_Filter1.TabIndex = 13;
		CB_Filter1.Text = "按关键字过滤：";
		TB_Find.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TB_Find.AutoCompleteCustomSource = null;
		TB_Find.AutoCompleteMode = AutoCompleteMode.None;
		TB_Find.AutoCompleteSource = AutoCompleteSource.None;
		TB_Find.BackColor = Color.Transparent;
		TB_Find.Font = new Font("Segoe UI", 8f);
		TB_Find.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Find.Image = null;
		TB_Find.Lines = null;
		TB_Find.Location = new Point(6, 134);
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
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(309, 1);
		Label1.Name = "Label1";
		Label1.Size = new Size(53, 13);
		Label1.TabIndex = 15;
		Label1.Text = "探测";
		ArcControl_Illumination.AutoSize = true;
		ArcControl_Illumination.BackColor = Color.FromArgb(60, 63, 65);
		ArcControl_Illumination.Location = new Point(394, 13);
		ArcControl_Illumination.Name = "ArcControl_Illumination";
		ArcControl_Illumination.Size = new Size(103, 100);
		ArcControl_Illumination.TabIndex = 14;
		ArcControl_Detection.AutoSize = true;
		ArcControl_Detection.BackColor = Color.FromArgb(60, 63, 65);
		ArcControl_Detection.Location = new Point(288, 12);
		ArcControl_Detection.Name = "ArcControl_Detection";
		ArcControl_Detection.Size = new Size(103, 100);
		ArcControl_Detection.TabIndex = 16;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(386, 2);
		Label2.Name = "Label2";
		Label2.Size = new Size(112, 13);
		Label2.TabIndex = 17;
		Label2.Text = "跟踪/照射";
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(271, 111);
		Label3.Name = "Label3";
		Label3.Size = new Size(226, 13);
		Label3.TabIndex = 18;
		Label3.Text = "提示：双击以选择或取消选择所有角度";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(503, 514);
		base.Controls.Add(Label3);
		base.Controls.Add(Label2);
		base.Controls.Add(ArcControl_Detection);
		base.Controls.Add(Label1);
		base.Controls.Add(ArcControl_Illumination);
		base.Controls.Add(CB_Filter1);
		base.Controls.Add(TB_Find);
		base.Controls.Add(Button1);
		base.Controls.Add(DataGridView1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddSensor";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "添加传感器";
		((ISupportInitialize)DataGridView1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ReflectFilter(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		DefineFilter().RunWorkerAsync();
	}

	private void VisitFilter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(Client.SelectedUnit) && Client.SelectedUnit.IsActiveUnit && (!ArcControl_Detection.NoArcsSelected || DarkMessageBox.ShowWarning("您没有为此传感器定义探测角度。你确定吗？", "没有定义探测角度！", DarkDialogButton.YesNo) != DialogResult.No))
		{
			int int_ = Conversions.ToInteger(DataGridView1.CurrentRow.Cells["ID"].Value);
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			Sensor sensor = DBFunctions.GetSensor(int_, ref sqliteConnection_);
			sensor.Coverage = ArcControl_Detection.theCoverage.Clone();
			sensor.Coverage_Illuminate = ArcControl_Illumination.theCoverage.Clone();
			((ActiveUnit)Client.SelectedUnit).AddSensor(sensor);
			sensor.ParentPlatform = (ActiveUnit)Client.SelectedUnit;
			if (!Information.IsNothing(Client.theSensorsWindow) && Client.theSensorsWindow.Visible)
			{
				Client.theSensorsWindow.BuildForm();
			}
		}
	}

	private void RestartFilter(object sender, DoWorkEventArgs e)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		regProperty = DBFunctions.GetAllSensors(ref sqliteConnection_);
	}

	private void TestFilter(object sender, RunWorkerCompletedEventArgs e)
	{
		VerifyFilter();
	}

	private void StopFilter(object object_0)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			CancelFilter();
		}
	}

	private void CancelFilter()
	{
		DataView dataView = new DataView(regProperty);
		dataView.Sort = "Name ASC";
		dataView.RowFilter = "Name LIKE '%" + TB_Find.Text + "%'";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = dataView;
		DataGridView1.Refresh();
	}

	public void InjectFilterByKeyword(string string_0)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		regProperty = DBFunctions.GetAllSensors(ref sqliteConnection_);
		CB_Filter1.Checked = false;
		TB_Find.Text = string_0;
		CancelFilter();
	}

	private void VerifyFilter()
	{
		paramProperty = new DataView(regProperty);
		paramProperty.Sort = "Name ASC";
		DataGridView1.AutoGenerateColumns = false;
		DataGridView1.DataSource = paramProperty;
	}

	private void ListFilter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (m_PageProperty)
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
		if (!m_PageProperty && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ResolveFilter(object sender, EventArgs e)
	{
		m_PageProperty = true;
	}

	private void PostFilter(object sender, EventArgs e)
	{
		m_PageProperty = false;
		CB_Filter1.Select();
	}

	private void RunFilter(object sender, EventArgs e)
	{
		if (CB_Filter1.Checked & (Operators.CompareString(TB_Find.Text, "", TextCompare: true) != 0))
		{
			CancelFilter();
		}
		else
		{
			VerifyFilter();
		}
	}

	private void StartFilter(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
