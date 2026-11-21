using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Collections;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SatPredictionForm : DarkSecondaryFormBase
{
	private sealed class RegThreadBridge
	{
		public Satellite _CandidateMap;

		public DateTime _BaseMap;

		public long m_PolicyMap;
	}

	[CompilerGenerated]
	private sealed class StrategyObjectListener
	{
		public SatPredictionForm Me;

		public DataGridViewRow Local_row;

		public DarkListItem Local_item;

		internal void IncludeInterruptibleMethod()
		{
			Me.DataGridView1.Rows.Add(Local_row);
			Me.ListView1.Items.Add(Local_item);
			Me.DarkUIProgressBar_0.Value = (int)Math.Round(100.0 * ((double)Me._ServerPredicate / (double)Me.publisherPredicate));
		}
	}

	private IContainer poolPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl m_TaskPredicate;

	[AccessedThroughProperty("TabPage2")]
	[CompilerGenerated]
	private TabPage m_TestsPredicate;

	[AccessedThroughProperty("ListView1")]
	[CompilerGenerated]
	private DarkListView containerPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	private DataGridViewTextBoxColumn m_ModelPredicate;

	[AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_AdvisorPredicate;

	[AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_CustomerPredicate;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_SerializerPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("NumericUpDown1")]
	private GControl1 m_RefPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel m_ErrorPredicate;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton codePredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("Satellite")]
	private DataGridViewTextBoxColumn connectionPredicate;

	[AccessedThroughProperty("Side")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ContextPredicate;

	[AccessedThroughProperty("CoverageStart")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_StatusPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("DwellTime")]
	private DataGridViewTextBoxColumn m_ProccesorPredicate;

	public double LocationLatitude;

	public double LocationLongitude;

	private int m_ConfigurationPredicate;

	[CompilerGenerated]
	[AccessedThroughProperty("theBW")]
	private BackgroundWorker m_TokenPredicate;

	[AccessedThroughProperty("CovRecords")]
	[CompilerGenerated]
	private ObservableList<RegThreadBridge> indexerPredicate;

	private bool _ResolverPredicate;

	private int publisherPredicate;

	private int _ServerPredicate;

	private int _AdapterPredicate;

	private Keys[] m_SchemaPredicate;

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return m_TaskPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TaskPredicate = value;
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_TestsPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TestsPredicate = value;
		}
	}

	[field: AccessedThroughProperty("DataGridView1")]
	internal DarkDataGridView DataGridView1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkListView ListView1
	{
		[CompilerGenerated]
		get
		{
			return containerPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = delegate(object sender, EventArgs e)
			{
				DrawListViewItem(RuntimeHelpers.GetObjectValue(sender), (DrawDarkListViewListItemEventArgs)e);
			};
			DarkListView darkListView = containerPredicate;
			if (darkListView != null)
			{
				darkListView.DrawListItem -= value2;
			}
			containerPredicate = value;
			darkListView = containerPredicate;
			if (darkListView != null)
			{
				darkListView.DrawListItem += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[CompilerGenerated]
		get
		{
			return m_ModelPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ModelPredicate = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn3
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorPredicate = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn4
	{
		[CompilerGenerated]
		get
		{
			return m_CustomerPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CustomerPredicate = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SerializerPredicate = value;
		}
	}

	internal GControl1 NumericUpDown1
	{
		[CompilerGenerated]
		get
		{
			return m_RefPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleIndexer;
			GControl1.ValueChangedEventHandler value3 = InterruptInterruptibleIndexer;
			GControl1 refPredicate = m_RefPredicate;
			if (refPredicate != null)
			{
				refPredicate.TextChanged -= value2;
				refPredicate.ValueChanged -= value3;
			}
			m_RefPredicate = value;
			refPredicate = m_RefPredicate;
			if (refPredicate != null)
			{
				refPredicate.TextChanged += value2;
				refPredicate.ValueChanged += value3;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ErrorPredicate = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return codePredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleIndexer;
			DarkUIButton darkUIButton = codePredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			codePredicate = value;
			darkUIButton = codePredicate;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn Satellite
	{
		[CompilerGenerated]
		get
		{
			return connectionPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionPredicate = value;
		}
	}

	internal DataGridViewTextBoxColumn Side
	{
		[CompilerGenerated]
		get
		{
			return m_ContextPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ContextPredicate = value;
		}
	}

	internal DataGridViewTextBoxColumn CoverageStart
	{
		[CompilerGenerated]
		get
		{
			return m_StatusPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StatusPredicate = value;
		}
	}

	internal DataGridViewTextBoxColumn DwellTime
	{
		[CompilerGenerated]
		get
		{
			return m_ProccesorPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProccesorPredicate = value;
		}
	}

	[field: AccessedThroughProperty("DarkUIProgressBar1")]
	internal DarkUIProgressBar DarkUIProgressBar_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker CountInterruptibleResolver()
	{
		return m_TokenPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void CustomizeInterruptibleResolver(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = SetInterruptibleIndexer;
		RunWorkerCompletedEventHandler value2 = FillInterruptibleIndexer;
		BackgroundWorker tokenPredicate = m_TokenPredicate;
		if (tokenPredicate != null)
		{
			tokenPredicate.DoWork -= value;
			tokenPredicate.RunWorkerCompleted -= value2;
		}
		m_TokenPredicate = backgroundWorker_0;
		tokenPredicate = m_TokenPredicate;
		if (tokenPredicate != null)
		{
			tokenPredicate.DoWork += value;
			tokenPredicate.RunWorkerCompleted += value2;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private ObservableList<RegThreadBridge> ConnectInterruptibleResolver()
	{
		return indexerPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void MoveInterruptibleResolver(ObservableList<RegThreadBridge> observableList_0)
	{
		EventHandler<ObservableListModified<RegThreadBridge>> value = InstantiateInterruptibleIndexer;
		ObservableList<RegThreadBridge> observableList = indexerPredicate;
		if (observableList != null)
		{
			observableList.ItemsAdded -= value;
		}
		indexerPredicate = observableList_0;
		observableList = indexerPredicate;
		if (observableList != null)
		{
			observableList.ItemsAdded += value;
		}
	}

	public SatPredictionForm()
	{
		base.Shown += FindInterruptibleIndexer;
		base.FormClosing += CalculateInterruptibleIndexer;
		base.Load += PopInterruptibleIndexer;
		_ResolverPredicate = false;
		m_SchemaPredicate = new Keys[1] { Keys.Escape };
		CheckInterruptibleIndexer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && poolPredicate != null)
			{
				poolPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CheckInterruptibleIndexer()
	{
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridView1 = new DarkDataGridView();
		Satellite = new DataGridViewTextBoxColumn();
		Side = new DataGridViewTextBoxColumn();
		CoverageStart = new DataGridViewTextBoxColumn();
		DwellTime = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		ListView1 = new DarkListView();
		Label1 = new DarkLabel();
		NumericUpDown1 = new GControl1();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		DarkUIProgressBar_0 = new DarkUIProgressBar();
		((ISupportInitialize)DataGridView1).BeginInit();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		TabPage2.SuspendLayout();
		ListView1.SuspendLayout();
		SuspendLayout();
		TabControl1.Location = new Point(0, 44);
		TabControl1.Size = new Size(804, 440);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.TabIndex = 0;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(DataGridView1);
		TabPage1.Location = new Point(0, 0);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(804, 420);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Log";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(ListView1);
		TabPage2.Location = new Point(0, 0);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(804, 420);
		TabPage2.TabIndex = 0;
		TabPage2.Text = "Chart";
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
		DataGridView1.Columns.AddRange(Satellite, Side, CoverageStart, DwellTime);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(0, 0);
		DataGridView1.Name = "DataGridView1";
		DataGridView1.ReadOnly = true;
		DataGridView1.RowHeadersVisible = false;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.Size = new Size(804, 420);
		DataGridView1.TabIndex = 0;
		Satellite.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Satellite.HeaderText = "卫星";
		Satellite.Name = "Satellite";
		Satellite.ReadOnly = true;
		Satellite.Width = 71;
		Side.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Side.HeaderText = "分方";
		Side.Name = "Side";
		Side.ReadOnly = true;
		Side.Width = 52;
		CoverageStart.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		CoverageStart.HeaderText = "进入区域：";
		CoverageStart.Name = "CoverageStart";
		CoverageStart.ReadOnly = true;
		CoverageStart.Width = 106;
		DwellTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		DwellTime.HeaderText = "停留时间";
		DwellTime.Name = "DwellTime";
		DwellTime.ReadOnly = true;
		DataGridViewTextBoxColumn1.HeaderText = "卫星";
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.ReadOnly = true;
		DataGridViewTextBoxColumn2.HeaderText = "分方";
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		DataGridViewTextBoxColumn2.ReadOnly = true;
		DataGridViewTextBoxColumn3.HeaderText = "进入区域：";
		DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
		DataGridViewTextBoxColumn3.ReadOnly = true;
		DataGridViewTextBoxColumn4.HeaderText = "停留时间";
		DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
		DataGridViewTextBoxColumn4.ReadOnly = true;
		ListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		ListView1.Dock = DockStyle.Fill;
		ListView1.Location = new Point(0, 0);
		ListView1.Name = "ListView1";
		ListView1.Size = new Size(804, 420);
		ListView1.HideScrollBars = true;
		ListView1.TabIndex = 2;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(12, 17);
		Label1.Name = "Label1";
		Label1.Size = new Size(107, 15);
		Label1.TabIndex = 1;
		Label1.Text = "预测下一个";
		NumericUpDown1.BackColor = Color.Transparent;
		NumericUpDown1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		NumericUpDown1.Location = new Point(120, 12);
		NumericUpDown1.Maximum = 30;
		NumericUpDown1.Minimum = 1;
		NumericUpDown1.Name = "NumericUpDown1";
		NumericUpDown1.Size = new Size(58, 26);
		NumericUpDown1.TabIndex = 2;
		NumericUpDown1.Value = 0;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(194, 17);
		Label2.Name = "Label2";
		Label2.Size = new Size(31, 15);
		Label2.TabIndex = 3;
		Label2.Text = "天";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(242, 12);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 26);
		Button1.TabIndex = 4;
		Button1.Text = "重新计算";
		DarkUIProgressBar_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkUIProgressBar_0.BackColor = Color.Transparent;
		DarkUIProgressBar_0.Location = new Point(323, 12);
		DarkUIProgressBar_0.Maximum = 100;
		DarkUIProgressBar_0.Name = "DarkUIProgressBar1";
		DarkUIProgressBar_0.ShowProgressLines = true;
		DarkUIProgressBar_0.ShowProgressValue = true;
		DarkUIProgressBar_0.Size = new Size(469, 26);
		DarkUIProgressBar_0.TabIndex = 5;
		DarkUIProgressBar_0.Text = "计算...";
		DarkUIProgressBar_0.Value = 0;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(804, 492);
		base.Controls.Add(DarkUIProgressBar_0);
		base.Controls.Add(Button1);
		base.Controls.Add(Label2);
		base.Controls.Add(NumericUpDown1);
		base.Controls.Add(Label1);
		base.Controls.Add(TabControl1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SatPredictionForm";
		base.ShowIcon = false;
		Text = "卫星过顶预测";
		((ISupportInitialize)DataGridView1).EndInit();
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		TabPage2.ResumeLayout(performLayout: false);
		TabPage2.PerformLayout();
		ListView1.ResumeLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] schemaPredicate = m_SchemaPredicate;
		Keys[] array = schemaPredicate;
		foreach (Keys keys in array)
		{
			if (keyData == keys)
			{
				Close();
				return true;
			}
		}
		return false;
	}

	public void DoPredictions()
	{
		if (!_ResolverPredicate)
		{
			_AdapterPredicate = m_ConfigurationPredicate * 24 * 60;
			Button1.Text = "计算...";
			Button1.Enabled = false;
			NumericUpDown1.Enabled = false;
			DataGridView1.Rows.Clear();
			ListView1.Items.Clear();
			CustomizeInterruptibleResolver(new BackgroundWorker());
			CountInterruptibleResolver().WorkerSupportsCancellation = true;
			CountInterruptibleResolver().RunWorkerAsync();
		}
	}

	private void ConcatInterruptibleIndexer(object sender, EventArgs e)
	{
		m_ConfigurationPredicate = NumericUpDown1.Value;
	}

	private void InterruptInterruptibleIndexer()
	{
		m_ConfigurationPredicate = NumericUpDown1.Value;
	}

	private void RemoveInterruptibleIndexer(object sender, EventArgs e)
	{
		DoPredictions();
	}

	private void FindInterruptibleIndexer(object sender, EventArgs e)
	{
		m_ConfigurationPredicate = 2;
		NumericUpDown1.Value = m_ConfigurationPredicate;
		DoPredictions();
	}

	private void SetInterruptibleIndexer(object sender, DoWorkEventArgs e)
	{
		try
		{
			_ResolverPredicate = true;
			Geopoint_Struct geopoint_Struct_ = new Geopoint_Struct(LocationLongitude, LocationLatitude);
			Module_Unit.Unit unit = new Module_Unit.Unit();
			bool flag = false;
			MoveInterruptibleResolver(new ObservableList<RegThreadBridge>());
			int num = m_ConfigurationPredicate * 24 * 3600;
			List<ActiveUnit> list = Client.CurrentScenario.ActiveUnits_List.Where((ActiveUnit theAU) => theAU.IsSatellite).ToList();
			publisherPredicate = (int)Math.Round((double)(list.Count * (1 + num)) / 10.0);
			_ServerPredicate = 0;
			double double_ = 0.0;
			double double_2 = 0.0;
			RegThreadBridge regThreadBridge = null;
			foreach (ActiveUnit item in list)
			{
				if (Information.IsNothing(item))
				{
					continue;
				}
				Satellite satellite = (Satellite)item;
				float num2 = satellite.Sensors_Cached.Select((Sensor theS) => theS.maxRange).Max();
				flag = false;
				int num3 = num;
				for (int i = 0; i <= num3; i += 10)
				{
					if (CountInterruptibleResolver().CancellationPending)
					{
						return;
					}
					DateTime dateTime = Client.CurrentScenario.Time.AddSeconds(i);
					Satellite_Kinematics kinematics = satellite.Kinematics;
					Module_Unit.Unit unit2;
					Module_Unit.Unit unit3 = (unit2 = unit);
					bool? nullable_ = null;
					double double_3 = unit3.GetLatitude(nullable_);
					bool? nullable_2 = null;
					double double_4 = unit.GetLongitude(nullable_2);
					kinematics.PredictPosition(dateTime, ref double_3, ref double_4, ref double_, ref double_2);
					unit.SetLongitude(nullable_2, double_4);
					unit2.SetLatitude(nullable_, double_3);
					unit.SetCurrentAltitude(bool_0: false, (float)(double_ * 1000.0));
					if (Module_Unit.RangeToPoint_Slant(unit, geopoint_Struct_) < num2)
					{
						if (flag)
						{
							regThreadBridge.m_PolicyMap += 10L;
						}
						else
						{
							regThreadBridge = new RegThreadBridge();
							regThreadBridge._CandidateMap = satellite;
							regThreadBridge._BaseMap = dateTime;
							regThreadBridge.m_PolicyMap = 0L;
							flag = true;
						}
					}
					else if (flag)
					{
						regThreadBridge.m_PolicyMap += 10L;
						ConnectInterruptibleResolver().Add(regThreadBridge);
						regThreadBridge = null;
						flag = false;
					}
					_ServerPredicate++;
				}
				if (regThreadBridge != null)
				{
					ConnectInterruptibleResolver().Add(regThreadBridge);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200403", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_ResolverPredicate = false;
			ProjectData.ClearProjectError();
		}
	}

	private void FillInterruptibleIndexer(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			Button1.Text = "重新计算";
			Button1.Enabled = true;
			NumericUpDown1.Enabled = true;
			DarkUIProgressBar_0.Value = 100;
			_ResolverPredicate = false;
			List<DarkListItem> list = ListView1.Items.OrderBy((DarkListItem theItem) => ((Tuple<long, long>)theItem.Tag).Item2).ToList();
			ListView1.Items.Clear();
			foreach (DarkListItem item in list)
			{
				ListView1.Items.Add(item);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200404", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_ResolverPredicate = false;
			ProjectData.ClearProjectError();
		}
	}

	private void CalculateInterruptibleIndexer(object sender, FormClosingEventArgs e)
	{
		CountInterruptibleResolver().CancelAsync();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void PopInterruptibleIndexer(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void InstantiateInterruptibleIndexer(object object_0, ObservableListModified<RegThreadBridge> observableListModified_0)
	{
		foreach (RegThreadBridge item in observableListModified_0.Items)
		{
			long num = (long)Math.Round((item._BaseMap - Client.CurrentScenario.Time).TotalSeconds);
			string text = Misc.UpdateRequest(num);
			DataGridViewRow Local_row = new DataGridViewRow();
			Local_row.Tag = item._CandidateMap;
			Local_row.CreateCells(DataGridView1);
			Local_row.Cells[0].Value = item._CandidateMap.Name + " (" + item._CandidateMap.UnitClass + ")";
			Local_row.Cells[1].Value = item._CandidateMap.GetUnitSide().Name;
			if (DateTime.Compare(item._BaseMap, Client.CurrentScenario.Time) <= 0)
			{
				Local_row.Cells[2].Value = Strings.Format(item._BaseMap, "yyyy/MM/dd HH:mm:ss") + " (NOW)";
			}
			else
			{
				Local_row.Cells[2].Value = Strings.Format(item._BaseMap, "yyyy/MM/dd HH:mm:ss") + " (" + text + "现在起）";
			}
			Local_row.Cells[3].Value = Misc.UpdateRequest(item.m_PolicyMap);
			DarkListItem Local_item = new DarkListItem();
			if (num <= 0)
			{
				Local_item.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Local_row.Cells[0].Value, " - dwell "), Local_row.Cells[3].Value), " (NOW)"));
			}
			else
			{
				Local_item.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(item._CandidateMap.Name + " - dwell ", Local_row.Cells[3].Value), " (in "), text), ")"));
			}
			Local_item.TextColor = Client.GetColorFromStance(Client.CurrentScenario.GetCurrentSide().GetConsidersThisSideToBe(item._CandidateMap.GetUnitSide()));
			Local_item.Tag = Tuple.Create(item.m_PolicyMap, num);
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				DataGridView1.Rows.Add(Local_row);
				ListView1.Items.Add(Local_item);
				DarkUIProgressBar_0.Value = (int)Math.Round(100.0 * ((double)_ServerPredicate / (double)publisherPredicate));
			});
		}
	}

	public void DrawListViewItem(object sender, DrawDarkListViewListItemEventArgs e)
	{
		if (_ResolverPredicate || e.m_item == null || e.m_item.Tag == null)
		{
			return;
		}
		Graphics graphics = e.m_graphics;
		Rectangle rect = e.m_rect;
		Tuple<long, long> tuple = (Tuple<long, long>)e.m_item.Tag;
		int num = Math.Max(1, (int)Math.Round(new TimeSpan(0, 0, (int)tuple.Item1).TotalMinutes * (double)rect.Width / (double)_AdapterPredicate));
		TimeSpan timeSpan = new TimeSpan(0, 0, (int)tuple.Item2);
		int num2 = rect.Left + Math.Max(0, (int)Math.Round(timeSpan.TotalMinutes * (double)rect.Width / (double)_AdapterPredicate));
		SolidBrush brush = new SolidBrush(e.m_item.TextColor);
		graphics.FillRectangle(brush, num2, rect.Top, num, rect.Height);
		Brush brush2 = Brushes.LightGray;
		int num3 = num2;
		int num4 = (int)Math.Round(1f + graphics.MeasureString(e.m_item.Text, ListView1.Font).Width);
		if (num3 + num + num4 > rect.Width)
		{
			num3 = Math.Max(2, num3 - num4);
			if (num3 == 2 && (double)num > (double)num4 / 4.0 && (double)e.m_item.TextColor.GetBrightness() > 0.5)
			{
				brush2 = Brushes.Black;
			}
			num = 0;
		}
		graphics.DrawString(e.m_item.Text, ListView1.Font, brush2, num3 + num, e.m_rect.Top);
	}

	[SpecialName]
	[CompilerGenerated]
	private void ListView1_DrawListItem(object sender, EventArgs e)
	{
		DrawListViewItem(RuntimeHelpers.GetObjectValue(sender), (DrawDarkListViewListItemEventArgs)e);
	}

	[CompilerGenerated]
	private void CreateInterruptibleIndexer(object sender, EventArgs e)
	{
		DrawListViewItem(RuntimeHelpers.GetObjectValue(sender), (DrawDarkListViewListItemEventArgs)e);
	}
}
