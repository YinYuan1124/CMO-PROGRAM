using System;
using System.Collections;
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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanWaypointsWeapon : UserControl
{
	private IContainer m_MappingFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_WaypointsWeapon")]
	private DarkDataGridView mockFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearTime")]
	private DarkButton tagFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditSpeedAltitude")]
	private DarkButton m_FieldFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditTime")]
	private DarkButton _QueueFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_DeleteWaypoint")]
	private DarkButton regFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_InsertWaypoint")]
	private DarkButton _ParamFilter;

	[AccessedThroughProperty("ID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_PageFilter;

	[AccessedThroughProperty("ObjectID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn rulesFilter;

	[AccessedThroughProperty("Time_Zulu")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn serviceFilter;

	[AccessedThroughProperty("Time_Local")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_SystemFilter;

	[AccessedThroughProperty("TimeFixedImg")]
	[CompilerGenerated]
	private DataGridViewImageColumn m_CandidateFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("TimeFixed")]
	private DataGridViewTextBoxColumn baseFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("SpeedFixed")]
	private DataGridViewTextBoxColumn identifierFilter;

	[AccessedThroughProperty("DesiredAltitude")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_PrinterFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Leg_TotalDistance")]
	private DataGridViewTextBoxColumn algoFilter;

	[AccessedThroughProperty("Leg_Time")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn databaseFilter;

	[AccessedThroughProperty("Hold_Time")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_InterceptorFilter;

	[AccessedThroughProperty("Leg_TotalTime")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_MessageFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Leg_FuelRemaining")]
	private DataGridViewTextBoxColumn annotationFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Coordinates")]
	private DataGridViewTextBoxColumn iteratorFilter;

	internal DarkDataGridView DGV_WaypointsWeapon
	{
		[CompilerGenerated]
		get
		{
			return mockFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellPaintingEventHandler value5 = SortDatabase;
			DataGridViewColumnEventHandler value6 = CalcDatabase;
			PaintEventHandler value7 = RateDatabase;
			ScrollEventHandler value8 = FlushDatabase;
			EventHandler value9 = ForgotDatabase;
			EventHandler value10 = CollectDatabase;
			EventHandler value11 = OrderDatabase;
			DataGridViewCellEventHandler value12 = RegisterDatabase;
			DataGridViewCellEventHandler value2 = ManageDatabase;
			EventHandler value3 = RevertDatabase;
			EventHandler value4 = CustomizeInterceptor;
			DarkDataGridView darkDataGridView = mockFilter;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellPainting -= value5;
				darkDataGridView.ColumnWidthChanged -= value6;
				darkDataGridView.Paint -= value7;
				darkDataGridView.Scroll -= value8;
				darkDataGridView.MouseHover -= value9;
				darkDataGridView.Enter -= value10;
				darkDataGridView.SelectionChanged -= value11;
				darkDataGridView.CellClick -= value12;
				darkDataGridView.CellValueChanged -= value2;
				darkDataGridView.CurrentCellDirtyStateChanged -= value3;
				darkDataGridView.SelectionChanged -= value4;
			}
			mockFilter = value;
			darkDataGridView = mockFilter;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellPainting += value5;
				darkDataGridView.ColumnWidthChanged += value6;
				darkDataGridView.Paint += value7;
				darkDataGridView.Scroll += value8;
				darkDataGridView.MouseHover += value9;
				darkDataGridView.Enter += value10;
				darkDataGridView.SelectionChanged += value11;
				darkDataGridView.CellClick += value12;
				darkDataGridView.CellValueChanged += value2;
				darkDataGridView.CurrentCellDirtyStateChanged += value3;
				darkDataGridView.SelectionChanged += value4;
			}
		}
	}

	internal DarkButton Button_ClearTime
	{
		[CompilerGenerated]
		get
		{
			return tagFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneInterceptor;
			DarkButton darkButton = tagFilter;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			tagFilter = value;
			darkButton = tagFilter;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkButton Button_EditSpeedAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_FieldFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapDatabase;
			DarkButton fieldFilter = m_FieldFilter;
			if (fieldFilter != null)
			{
				fieldFilter.Click -= value2;
			}
			m_FieldFilter = value;
			fieldFilter = m_FieldFilter;
			if (fieldFilter != null)
			{
				fieldFilter.Click += value2;
			}
		}
	}

	internal DarkButton Button_EditTime
	{
		[CompilerGenerated]
		get
		{
			return _QueueFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetDatabase;
			DarkButton queueFilter = _QueueFilter;
			if (queueFilter != null)
			{
				queueFilter.Click -= value2;
			}
			_QueueFilter = value;
			queueFilter = _QueueFilter;
			if (queueFilter != null)
			{
				queueFilter.Click += value2;
			}
		}
	}

	internal DarkButton Button_DeleteWaypoint
	{
		[CompilerGenerated]
		get
		{
			return regFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryDatabase;
			DarkButton darkButton = regFilter;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			regFilter = value;
			darkButton = regFilter;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkButton Button_InsertWaypoint
	{
		[CompilerGenerated]
		get
		{
			return _ParamFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeDatabase;
			DarkButton paramFilter = _ParamFilter;
			if (paramFilter != null)
			{
				paramFilter.Click -= value2;
			}
			_ParamFilter = value;
			paramFilter = _ParamFilter;
			if (paramFilter != null)
			{
				paramFilter.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn ID
	{
		[CompilerGenerated]
		get
		{
			return m_PageFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn ObjectID
	{
		[CompilerGenerated]
		get
		{
			return rulesFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rulesFilter = value;
		}
	}

	[field: AccessedThroughProperty("Type")]
	internal DataGridViewComboBoxColumn Type
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Time_Zulu
	{
		[CompilerGenerated]
		get
		{
			return serviceFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serviceFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Time_Local
	{
		[CompilerGenerated]
		get
		{
			return m_SystemFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SystemFilter = value;
		}
	}

	internal DataGridViewImageColumn TimeFixedImg
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CandidateFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn TimeFixed
	{
		[CompilerGenerated]
		get
		{
			return baseFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			baseFilter = value;
		}
	}

	[field: AccessedThroughProperty("DesiredSpeed")]
	internal DataGridViewTextBoxColumn DesiredSpeed
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SpeedFixedImg")]
	internal DataGridViewImageColumn SpeedFixedImg
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn SpeedFixed
	{
		[CompilerGenerated]
		get
		{
			return identifierFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			identifierFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn DesiredAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PrinterFilter = value;
		}
	}

	[field: AccessedThroughProperty("Leg_Distance")]
	internal DataGridViewTextBoxColumn Leg_Distance
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Leg_TotalDistance
	{
		[CompilerGenerated]
		get
		{
			return algoFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			algoFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Leg_Time
	{
		[CompilerGenerated]
		get
		{
			return databaseFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			databaseFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Hold_Time
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Leg_TotalTime
	{
		[CompilerGenerated]
		get
		{
			return m_MessageFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MessageFilter = value;
		}
	}

	[field: AccessedThroughProperty("Leg_FuelRequired")]
	internal DataGridViewTextBoxColumn Leg_FuelRequired
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Leg_FuelRemaining
	{
		[CompilerGenerated]
		get
		{
			return annotationFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			annotationFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Coordinates
	{
		[CompilerGenerated]
		get
		{
			return iteratorFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iteratorFilter = value;
		}
	}

	public FlightPlanWaypointsWeapon()
	{
		PublishDatabase();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_MappingFilter != null)
			{
				m_MappingFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PublishDatabase()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		Button_ClearTime = new DarkButton();
		Button_EditSpeedAltitude = new DarkButton();
		Button_EditTime = new DarkButton();
		Button_DeleteWaypoint = new DarkButton();
		Button_InsertWaypoint = new DarkButton();
		DGV_WaypointsWeapon = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		ObjectID = new DataGridViewTextBoxColumn();
		Type = new DataGridViewComboBoxColumn();
		Time_Zulu = new DataGridViewTextBoxColumn();
		Time_Local = new DataGridViewTextBoxColumn();
		TimeFixedImg = new DataGridViewImageColumn();
		TimeFixed = new DataGridViewTextBoxColumn();
		DesiredSpeed = new DataGridViewTextBoxColumn();
		SpeedFixedImg = new DataGridViewImageColumn();
		SpeedFixed = new DataGridViewTextBoxColumn();
		DesiredAltitude = new DataGridViewTextBoxColumn();
		Leg_Distance = new DataGridViewTextBoxColumn();
		Leg_TotalDistance = new DataGridViewTextBoxColumn();
		Leg_Time = new DataGridViewTextBoxColumn();
		Hold_Time = new DataGridViewTextBoxColumn();
		Leg_TotalTime = new DataGridViewTextBoxColumn();
		Leg_FuelRequired = new DataGridViewTextBoxColumn();
		Leg_FuelRemaining = new DataGridViewTextBoxColumn();
		Coordinates = new DataGridViewTextBoxColumn();
		((ISupportInitialize)DGV_WaypointsWeapon).BeginInit();
		SuspendLayout();
		Button_ClearTime.Anchor = AnchorStyles.Left;
		Button_ClearTime.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		Button_ClearTime.Location = new Point(371, 301);
		Button_ClearTime.Name = "Button_ClearTime";
		Button_ClearTime.Padding = new Padding(5);
		Button_ClearTime.Size = new Size(86, 33);
		Button_ClearTime.TabIndex = 26;
		Button_ClearTime.Text = "清除时间";
		Button_EditSpeedAltitude.Anchor = AnchorStyles.Left;
		Button_EditSpeedAltitude.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		Button_EditSpeedAltitude.Location = new Point(187, 301);
		Button_EditSpeedAltitude.Name = "Button_EditSpeedAltitude";
		Button_EditSpeedAltitude.Padding = new Padding(5);
		Button_EditSpeedAltitude.Size = new Size(86, 33);
		Button_EditSpeedAltitude.TabIndex = 25;
		Button_EditSpeedAltitude.Text = "编辑速度/高度";
		Button_EditTime.Anchor = AnchorStyles.Left;
		Button_EditTime.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		Button_EditTime.Location = new Point(279, 301);
		Button_EditTime.Name = "Button_EditTime";
		Button_EditTime.Padding = new Padding(5);
		Button_EditTime.Size = new Size(86, 33);
		Button_EditTime.TabIndex = 24;
		Button_EditTime.Text = "编辑时间";
		Button_DeleteWaypoint.Anchor = AnchorStyles.Left;
		Button_DeleteWaypoint.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		Button_DeleteWaypoint.Location = new Point(95, 301);
		Button_DeleteWaypoint.Name = "Button_DeleteWaypoint";
		Button_DeleteWaypoint.Padding = new Padding(5);
		Button_DeleteWaypoint.Size = new Size(86, 33);
		Button_DeleteWaypoint.TabIndex = 23;
		Button_DeleteWaypoint.Text = "删除航点";
		Button_InsertWaypoint.Anchor = AnchorStyles.Left;
		Button_InsertWaypoint.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		Button_InsertWaypoint.Location = new Point(3, 301);
		Button_InsertWaypoint.Name = "Button_InsertWaypoint";
		Button_InsertWaypoint.Padding = new Padding(5);
		Button_InsertWaypoint.Size = new Size(86, 33);
		Button_InsertWaypoint.TabIndex = 22;
		Button_InsertWaypoint.Text = "插入航点";
		DGV_WaypointsWeapon.AllowUserToAddRows = false;
		DGV_WaypointsWeapon.AllowUserToDeleteRows = false;
		DGV_WaypointsWeapon.AllowUserToOrderColumns = true;
		DGV_WaypointsWeapon.AllowUserToResizeColumns = false;
		DGV_WaypointsWeapon.AllowUserToResizeRows = false;
		DGV_WaypointsWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DGV_WaypointsWeapon.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_WaypointsWeapon.BorderStyle = BorderStyle.None;
		DGV_WaypointsWeapon.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_WaypointsWeapon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_WaypointsWeapon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_WaypointsWeapon.ColumnHeadersHeight = 22;
		DGV_WaypointsWeapon.Columns.AddRange(ID, ObjectID, Type, Time_Zulu, Time_Local, TimeFixedImg, TimeFixed, DesiredSpeed, SpeedFixedImg, SpeedFixed, DesiredAltitude, Leg_Distance, Leg_TotalDistance, Leg_Time, Hold_Time, Leg_TotalTime, Leg_FuelRequired, Leg_FuelRemaining, Coordinates);
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle10.BackColor = SystemColors.Window;
		dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
		DGV_WaypointsWeapon.DefaultCellStyle = dataGridViewCellStyle10;
		DGV_WaypointsWeapon.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_WaypointsWeapon.EnableHeadersVisualStyles = false;
		DGV_WaypointsWeapon.Location = new Point(0, 0);
		DGV_WaypointsWeapon.Name = "DGV_WaypointsWeapon";
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle11.BackColor = SystemColors.Control;
		dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
		DGV_WaypointsWeapon.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
		DGV_WaypointsWeapon.RowHeadersVisible = false;
		DGV_WaypointsWeapon.RowHeadersWidth = 10;
		dataGridViewCellStyle12.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle12.ForeColor = Color.LightGray;
		dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle12.SelectionForeColor = Color.LightGray;
		DGV_WaypointsWeapon.RowsDefaultCellStyle = dataGridViewCellStyle12;
		DGV_WaypointsWeapon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_WaypointsWeapon.Size = new Size(501, 295);
		DGV_WaypointsWeapon.TabIndex = 11;
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		ID.DataPropertyName = "ID";
		dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleRight;
		ID.DefaultCellStyle = dataGridViewCellStyle13;
		ID.Frozen = true;
		ID.HeaderText = "#";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Width = 5;
		ObjectID.DataPropertyName = "ObjectID";
		ObjectID.HeaderText = "对象ID";
		ObjectID.Name = "ObjectID";
		ObjectID.Visible = false;
		Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Type.DataPropertyName = "Type";
		Type.Frozen = true;
		Type.HeaderText = "类型";
		Type.Name = "Type";
		Type.Resizable = DataGridViewTriState.True;
		Type.SortMode = DataGridViewColumnSortMode.Automatic;
		Type.Width = 54;
		Time_Zulu.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Time_Zulu.DataPropertyName = "Time_Zulu";
		dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.BottomCenter;
		Time_Zulu.DefaultCellStyle = dataGridViewCellStyle14;
		Time_Zulu.HeaderText = "祖鲁时间";
		Time_Zulu.Name = "Time_Zulu";
		Time_Zulu.ReadOnly = true;
		Time_Zulu.Width = 77;
		Time_Local.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Time_Local.DataPropertyName = "Time_Local";
		dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.BottomCenter;
		Time_Local.DefaultCellStyle = dataGridViewCellStyle15;
		Time_Local.HeaderText = "当地时间";
		Time_Local.Name = "Time_Local";
		Time_Local.ReadOnly = true;
		Time_Local.Width = 82;
		TimeFixedImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		TimeFixedImg.DataPropertyName = "TimeFixedImg";
		TimeFixedImg.HeaderText = " ";
		TimeFixedImg.Name = "TimeFixedImg";
		TimeFixedImg.Width = 5;
		TimeFixed.DataPropertyName = "TimeFixed";
		TimeFixed.HeaderText = "TimeFixed";
		TimeFixed.Name = "TimeFixed";
		TimeFixed.Resizable = DataGridViewTriState.True;
		TimeFixed.Visible = false;
		TimeFixed.Width = 5;
		DesiredSpeed.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DesiredSpeed.DataPropertyName = "DesiredSpeed";
		dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleRight;
		DesiredSpeed.DefaultCellStyle = dataGridViewCellStyle16;
		DesiredSpeed.HeaderText = "速度";
		DesiredSpeed.Name = "DesiredSpeed";
		DesiredSpeed.ReadOnly = true;
		DesiredSpeed.Width = 64;
		SpeedFixedImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		SpeedFixedImg.DataPropertyName = "SpeedFixedImg";
		SpeedFixedImg.HeaderText = " ";
		SpeedFixedImg.Name = "SpeedFixedImg";
		SpeedFixedImg.Width = 5;
		SpeedFixed.DataPropertyName = "SpeedFixed";
		dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleRight;
		SpeedFixed.DefaultCellStyle = dataGridViewCellStyle17;
		SpeedFixed.HeaderText = "SpeedFixed";
		SpeedFixed.Name = "SpeedFixed";
		SpeedFixed.Resizable = DataGridViewTriState.True;
		SpeedFixed.Visible = false;
		SpeedFixed.Width = 5;
		DesiredAltitude.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DesiredAltitude.DataPropertyName = "DesiredAltitude";
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
		DesiredAltitude.DefaultCellStyle = dataGridViewCellStyle2;
		DesiredAltitude.HeaderText = "高度";
		DesiredAltitude.Name = "DesiredAltitude";
		DesiredAltitude.ReadOnly = true;
		DesiredAltitude.Width = 65;
		Leg_Distance.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_Distance.DataPropertyName = "Leg_Distance";
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_Distance.DefaultCellStyle = dataGridViewCellStyle3;
		Leg_Distance.HeaderText = "航段距离";
		Leg_Distance.Name = "Leg_Distance";
		Leg_Distance.Width = 93;
		Leg_TotalDistance.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_TotalDistance.DataPropertyName = "Leg_TotalDistance";
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_TotalDistance.DefaultCellStyle = dataGridViewCellStyle4;
		Leg_TotalDistance.HeaderText = "总距离";
		Leg_TotalDistance.Name = "Leg_TotalDistance";
		Leg_TotalDistance.Width = 99;
		Leg_Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_Time.DataPropertyName = "Leg_Time";
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_Time.DefaultCellStyle = dataGridViewCellStyle5;
		Leg_Time.HeaderText = "航段时间";
		Leg_Time.Name = "Leg_Time";
		Leg_Time.ToolTipText = "Time needed to fly this leg.";
		Leg_Time.Width = 74;
		Hold_Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Hold_Time.DataPropertyName = "Hold_Time";
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
		Hold_Time.DefaultCellStyle = dataGridViewCellStyle6;
		Hold_Time.HeaderText = "保持时间";
		Hold_Time.Name = "Hold_Time";
		Hold_Time.ToolTipText = "Loiter time at waypoint to allow flight to form up (Push Point).";
		Hold_Time.Width = 78;
		Leg_TotalTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_TotalTime.DataPropertyName = "Leg_TotalTime";
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_TotalTime.DefaultCellStyle = dataGridViewCellStyle7;
		Leg_TotalTime.HeaderText = "总时间";
		Leg_TotalTime.Name = "Leg_TotalTime";
		Leg_TotalTime.Width = 80;
		Leg_FuelRequired.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_FuelRequired.DataPropertyName = "Leg_FuelRequired";
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_FuelRequired.DefaultCellStyle = dataGridViewCellStyle8;
		Leg_FuelRequired.HeaderText = "航段燃料";
		Leg_FuelRequired.Name = "Leg_FuelRequired";
		Leg_FuelRequired.ToolTipText = "Fuel neeed to fly this leg.";
		Leg_FuelRequired.Width = 71;
		Leg_FuelRemaining.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_FuelRemaining.DataPropertyName = "Leg_FuelRemaining";
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_FuelRemaining.DefaultCellStyle = dataGridViewCellStyle9;
		Leg_FuelRemaining.HeaderText = "剩余燃料";
		Leg_FuelRemaining.Name = "Leg_FuelRemaining";
		Leg_FuelRemaining.ToolTipText = "Remaining mission fuel (i.e. total fuel minus reserves) after this leg has been completed.";
		Leg_FuelRemaining.Width = 103;
		Coordinates.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Coordinates.DataPropertyName = "Coordinates";
		Coordinates.HeaderText = "坐标";
		Coordinates.Name = "Coordinates";
		Coordinates.Width = 86;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		BackColor = Color.Transparent;
		base.Controls.Add(Button_ClearTime);
		base.Controls.Add(Button_EditSpeedAltitude);
		base.Controls.Add(Button_EditTime);
		base.Controls.Add(Button_DeleteWaypoint);
		base.Controls.Add(Button_InsertWaypoint);
		base.Controls.Add(DGV_WaypointsWeapon);
		base.Name = "FlightPlanWaypointsWeapon";
		base.Size = new Size(505, 424);
		((ISupportInitialize)DGV_WaypointsWeapon).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void AwakeDatabase(object sender, EventArgs e)
	{
		try
		{
			bool flag = false;
			int count = DGV_WaypointsWeapon.Rows.Count;
			int num = count - 1;
			int i = 0;
			Waypoint waypoint_ = null;
			Waypoint waypoint = null;
			for (; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow = DGV_WaypointsWeapon.Rows[i];
				if (!dataGridViewRow.Selected)
				{
					continue;
				}
				waypoint_ = (Waypoint)dataGridViewRow.Tag;
				if (waypoint_.SearchReponse() || waypoint_.ChangeReponse())
				{
					Interaction.MsgBox("无法在开始和终止巡逻点之间插入新的航点！");
					continue;
				}
				if (!waypoint_.SetupReponse())
				{
					Waypoint.WaypointType type;
					switch (waypoint_.Type)
					{
					case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
						type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
						break;
					case Waypoint.WaypointType.TurningPoint:
						type = Waypoint.WaypointType.TurningPoint;
						break;
					case Waypoint.WaypointType.StrikeIngress:
						type = Waypoint.WaypointType.StrikeIngress;
						break;
					case Waypoint.WaypointType.StrikeEgress:
						type = Waypoint.WaypointType.StrikeEgress;
						break;
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.WeaponLaunch:
						type = Waypoint.WaypointType.StrikeIngress;
						break;
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponTarget:
						type = Waypoint.WaypointType.StrikeEgress;
						break;
					default:
						type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
						break;
					case Waypoint.WaypointType.PatrolStation:
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.Refuel:
					case Waypoint.WaypointType.TakeOff:
					case Waypoint.WaypointType.Marshal:
					case Waypoint.WaypointType.Land:
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
					case Waypoint.WaypointType.HoldStart:
					case Waypoint.WaypointType.HoldEnd:
						type = Waypoint.WaypointType.TurningPoint;
						break;
					}
					GeoPoint geoPoint = new GeoPoint();
					GeoPoint geoPoint2 = new GeoPoint();
					GeoPoint geoPoint3 = new GeoPoint();
					GeoPoint geoPoint4 = new GeoPoint();
					GeoPoint geoPoint5 = new GeoPoint();
					GeoPoint geoPoint6 = new GeoPoint();
					if (i + 1 <= count - 1)
					{
						Waypoint waypoint4 = Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute[i + 1];
						double double_ = Math2.PublishClass(waypoint_.Latitude, waypoint_.Longitude, waypoint4.Latitude, waypoint4.Longitude);
						double num2 = Math2.VerifyClass(waypoint_.Latitude, waypoint_.Longitude, waypoint4.Latitude, waypoint4.Longitude);
						Waypoint waypoint5 = waypoint_;
						double double_4 = waypoint5.Longitude;
						Waypoint waypoint6 = waypoint_;
						double double_5 = waypoint6.Latitude;
						double double_6 = geoPoint.Longitude;
						double double_7 = geoPoint.Latitude;
						double double_8 = num2 / 2.0;
						double double_9 = Math2.DisableClass(double_);
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_4, ref double_5, ref double_6, ref double_7, ref double_8, ref double_9);
						geoPoint.Latitude = double_7;
						geoPoint.Longitude = double_6;
						waypoint6.Latitude = double_5;
						waypoint5.Longitude = double_4;
						if (!Information.IsNothing(waypoint_.Waypoint_LeadElementWingman))
						{
							Waypoint waypoint_LeadElementWingman = waypoint_.Waypoint_LeadElementWingman;
							Waypoint waypoint7 = (Information.IsNothing(waypoint4.Waypoint_LeadElementWingman) ? waypoint4 : waypoint4.Waypoint_LeadElementWingman);
							double_ = Math2.PublishClass(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint7.Latitude, waypoint7.Longitude);
							num2 = Math2.VerifyClass(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint7.Latitude, waypoint7.Longitude);
							double_9 = waypoint_LeadElementWingman.Longitude;
							double_8 = waypoint_LeadElementWingman.Latitude;
							double_7 = geoPoint2.Longitude;
							double_6 = geoPoint2.Latitude;
							double_5 = num2 / 2.0;
							double_4 = Math2.DisableClass(double_);
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_9, ref double_8, ref double_7, ref double_6, ref double_5, ref double_4);
							geoPoint2.Latitude = double_6;
							geoPoint2.Longitude = double_7;
							waypoint_LeadElementWingman.Latitude = double_8;
							waypoint_LeadElementWingman.Longitude = double_9;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_SecondElement))
						{
							Waypoint waypoint_SecondElement = waypoint_.Waypoint_SecondElement;
							Waypoint waypoint8 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
							double_ = Math2.PublishClass(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint8.Latitude, waypoint8.Longitude);
							num2 = Math2.VerifyClass(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint8.Latitude, waypoint8.Longitude);
							double_4 = waypoint_SecondElement.Longitude;
							double_5 = waypoint_SecondElement.Latitude;
							double_6 = geoPoint.Longitude;
							double_7 = geoPoint.Latitude;
							double_8 = num2 / 2.0;
							double_9 = Math2.DisableClass(double_);
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_4, ref double_5, ref double_6, ref double_7, ref double_8, ref double_9);
							geoPoint.Latitude = double_7;
							geoPoint.Longitude = double_6;
							waypoint_SecondElement.Latitude = double_5;
							waypoint_SecondElement.Longitude = double_4;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_SecondElementWingman))
						{
							Waypoint waypoint_SecondElement2 = waypoint_.Waypoint_SecondElement;
							Waypoint waypoint9 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
							double_ = Math2.PublishClass(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint9.Latitude, waypoint9.Longitude);
							num2 = Math2.VerifyClass(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint9.Latitude, waypoint9.Longitude);
							double_9 = waypoint_SecondElement2.Longitude;
							double_8 = waypoint_SecondElement2.Latitude;
							double_7 = geoPoint.Longitude;
							double_6 = geoPoint.Latitude;
							double_5 = num2 / 2.0;
							double_4 = Math2.DisableClass(double_);
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_9, ref double_8, ref double_7, ref double_6, ref double_5, ref double_4);
							geoPoint.Latitude = double_6;
							geoPoint.Longitude = double_7;
							waypoint_SecondElement2.Latitude = double_8;
							waypoint_SecondElement2.Longitude = double_9;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_ThirdElement))
						{
							Waypoint waypoint_SecondElement3 = waypoint_.Waypoint_SecondElement;
							Waypoint waypoint10 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
							double_ = Math2.PublishClass(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint10.Latitude, waypoint10.Longitude);
							num2 = Math2.VerifyClass(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint10.Latitude, waypoint10.Longitude);
							double_4 = waypoint_SecondElement3.Longitude;
							double_5 = waypoint_SecondElement3.Latitude;
							double_6 = geoPoint.Longitude;
							double_7 = geoPoint.Latitude;
							double_8 = num2 / 2.0;
							double_9 = Math2.DisableClass(double_);
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_4, ref double_5, ref double_6, ref double_7, ref double_8, ref double_9);
							geoPoint.Latitude = double_7;
							geoPoint.Longitude = double_6;
							waypoint_SecondElement3.Latitude = double_5;
							waypoint_SecondElement3.Longitude = double_4;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_ThirdElementWingman))
						{
							Waypoint waypoint_SecondElement4 = waypoint_.Waypoint_SecondElement;
							Waypoint waypoint11 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
							double_ = Math2.PublishClass(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint11.Latitude, waypoint11.Longitude);
							num2 = Math2.VerifyClass(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint11.Latitude, waypoint11.Longitude);
							double_9 = waypoint_SecondElement4.Longitude;
							double_8 = waypoint_SecondElement4.Latitude;
							double_7 = geoPoint.Longitude;
							double_6 = geoPoint.Latitude;
							double_5 = num2 / 2.0;
							double_4 = Math2.DisableClass(double_);
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_9, ref double_8, ref double_7, ref double_6, ref double_5, ref double_4);
							geoPoint.Latitude = double_6;
							geoPoint.Longitude = double_7;
							waypoint_SecondElement4.Latitude = double_8;
							waypoint_SecondElement4.Longitude = double_9;
						}
					}
					else
					{
						Waypoint waypoint2 = waypoint_;
						double double_10 = waypoint2.Longitude;
						Waypoint waypoint3 = waypoint_;
						double double_11 = waypoint3.Latitude;
						double double_2 = geoPoint.Longitude;
						double double_3 = geoPoint.Latitude;
						int int_ = 10;
						int int_2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_10, ref double_11, ref double_2, ref double_3, ref int_, ref int_2);
						geoPoint.Latitude = double_3;
						geoPoint.Longitude = double_2;
						waypoint3.Latitude = double_11;
						waypoint2.Longitude = double_10;
						if (!Information.IsNothing(waypoint_.Waypoint_LeadElementWingman))
						{
							Waypoint waypoint_LeadElementWingman2 = waypoint_.Waypoint_LeadElementWingman;
							double_3 = waypoint_LeadElementWingman2.Longitude;
							Waypoint waypoint_LeadElementWingman3 = waypoint_.Waypoint_LeadElementWingman;
							double_2 = waypoint_LeadElementWingman3.Latitude;
							double_11 = geoPoint.Longitude;
							double_10 = geoPoint.Latitude;
							int_2 = 10;
							int_ = 0;
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_3, ref double_2, ref double_11, ref double_10, ref int_2, ref int_);
							geoPoint.Latitude = double_10;
							geoPoint.Longitude = double_11;
							waypoint_LeadElementWingman3.Latitude = double_2;
							waypoint_LeadElementWingman2.Longitude = double_3;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_SecondElement))
						{
							Waypoint waypoint_SecondElement5 = waypoint_.Waypoint_SecondElement;
							double_10 = waypoint_SecondElement5.Longitude;
							Waypoint waypoint_SecondElement6 = waypoint_.Waypoint_SecondElement;
							double_11 = waypoint_SecondElement6.Latitude;
							double_2 = geoPoint.Longitude;
							double_3 = geoPoint.Latitude;
							int_ = 10;
							int_2 = 0;
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_10, ref double_11, ref double_2, ref double_3, ref int_, ref int_2);
							geoPoint.Latitude = double_3;
							geoPoint.Longitude = double_2;
							waypoint_SecondElement6.Latitude = double_11;
							waypoint_SecondElement5.Longitude = double_10;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_SecondElementWingman))
						{
							Waypoint waypoint_SecondElementWingman = waypoint_.Waypoint_SecondElementWingman;
							double_3 = waypoint_SecondElementWingman.Longitude;
							Waypoint waypoint_SecondElementWingman2 = waypoint_.Waypoint_SecondElementWingman;
							double_2 = waypoint_SecondElementWingman2.Latitude;
							double_11 = geoPoint.Longitude;
							double_10 = geoPoint.Latitude;
							int_2 = 10;
							int_ = 0;
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_3, ref double_2, ref double_11, ref double_10, ref int_2, ref int_);
							geoPoint.Latitude = double_10;
							geoPoint.Longitude = double_11;
							waypoint_SecondElementWingman2.Latitude = double_2;
							waypoint_SecondElementWingman.Longitude = double_3;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_ThirdElement))
						{
							Waypoint waypoint_ThirdElement = waypoint_.Waypoint_ThirdElement;
							double_10 = waypoint_ThirdElement.Longitude;
							Waypoint waypoint_ThirdElement2 = waypoint_.Waypoint_ThirdElement;
							double_11 = waypoint_ThirdElement2.Latitude;
							double_2 = geoPoint.Longitude;
							double_3 = geoPoint.Latitude;
							int_ = 10;
							int_2 = 0;
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_10, ref double_11, ref double_2, ref double_3, ref int_, ref int_2);
							geoPoint.Latitude = double_3;
							geoPoint.Longitude = double_2;
							waypoint_ThirdElement2.Latitude = double_11;
							waypoint_ThirdElement.Longitude = double_10;
						}
						if (!Information.IsNothing(waypoint_.Waypoint_ThirdElementWingman))
						{
							Waypoint waypoint_ThirdElementWingman = waypoint_.Waypoint_ThirdElementWingman;
							double_3 = waypoint_ThirdElementWingman.Longitude;
							Waypoint waypoint_ThirdElementWingman2 = waypoint_.Waypoint_ThirdElementWingman;
							double_2 = waypoint_ThirdElementWingman2.Latitude;
							double_11 = geoPoint.Longitude;
							double_10 = geoPoint.Latitude;
							int_2 = 10;
							int_ = 0;
							Geodesic_EdWilliams.CalcPoint_Williams(ref double_3, ref double_2, ref double_11, ref double_10, ref int_2, ref int_);
							geoPoint.Latitude = double_10;
							geoPoint.Longitude = double_11;
							waypoint_ThirdElementWingman2.Latitude = double_2;
							waypoint_ThirdElementWingman.Longitude = double_3;
						}
					}
					Scenario scenario_ = Client.CurrentScenario;
					Doctrine doctrine_ = null;
					waypoint = Waypoint.CopyWaypoint(ref scenario_, ref waypoint_, bool_0: true, bool_1: false, ref doctrine_);
					waypoint.Type = type;
					waypoint.Latitude = geoPoint.Latitude;
					waypoint.Longitude = geoPoint.Longitude;
					waypoint.Hold_Time = 0f;
					waypoint.Station_Time = 0f;
					waypoint.SpacingManeuver_Time = 0f;
					if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
					{
						Waypoint waypoint_LeadElementWingman4 = waypoint.Waypoint_LeadElementWingman;
						waypoint_LeadElementWingman4.Type = type;
						waypoint_LeadElementWingman4.Latitude = geoPoint2.Latitude;
						waypoint_LeadElementWingman4.Longitude = geoPoint2.Longitude;
					}
					if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
					{
						Waypoint waypoint_SecondElement7 = waypoint.Waypoint_SecondElement;
						waypoint_SecondElement7.Type = type;
						waypoint_SecondElement7.Latitude = geoPoint3.Latitude;
						waypoint_SecondElement7.Longitude = geoPoint3.Longitude;
					}
					if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
					{
						Waypoint waypoint_SecondElementWingman3 = waypoint.Waypoint_SecondElementWingman;
						waypoint_SecondElementWingman3.Type = type;
						waypoint_SecondElementWingman3.Latitude = geoPoint4.Latitude;
						waypoint_SecondElementWingman3.Longitude = geoPoint4.Longitude;
					}
					if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
					{
						Waypoint waypoint_ThirdElement3 = waypoint.Waypoint_ThirdElement;
						waypoint_ThirdElement3.Type = type;
						waypoint_ThirdElement3.Latitude = geoPoint5.Latitude;
						waypoint_ThirdElement3.Longitude = geoPoint5.Longitude;
					}
					if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
					{
						Waypoint waypoint_ThirdElementWingman3 = waypoint.Waypoint_ThirdElementWingman;
						waypoint_ThirdElementWingman3.Type = type;
						waypoint_ThirdElementWingman3.Latitude = geoPoint6.Latitude;
						waypoint_ThirdElementWingman3.Longitude = geoPoint6.Longitude;
					}
					ActiveUnit_Navigator.AddWaypoint(ref Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute, i + 1, waypoint);
					break;
				}
				Interaction.MsgBox("无法插入编队分解航点。改变队型，然后再试一次。");
				return;
			}
			if (!Information.IsNothing(waypoint_) && !Information.IsNothing(waypoint))
			{
				for (int j = Client.CurrentScenario.ActiveUnits_List.Count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits_List[j];
					if (Information.IsNothing(activeUnit) || !activeUnit.IsOperating())
					{
						continue;
					}
					if ((activeUnit.IsAircraft || (activeUnit.IsGroup && ((Group)activeUnit).Type == Group.GroupType.AirGroup)) && activeUnit.Navigator.HasFlightPlan && !Information.IsNothing(activeUnit.GetUnitSide()) && activeUnit.GetUnitSide() == Client.CurrentSide)
					{
						int num3 = activeUnit.Navigator.PlottedCourse.Count() - 1;
						for (int k = 0; k <= num3; k++)
						{
							if (activeUnit.Navigator.PlottedCourse[k] == waypoint_ && k >= 0)
							{
								ActiveUnit_Navigator navigator = activeUnit.Navigator;
								Waypoint[] waypoint_2 = navigator.PlottedCourse;
								ActiveUnit_Navigator.AddWaypoint(ref waypoint_2, k + 1, waypoint);
								navigator.PlottedCourse = waypoint_2;
								flag = true;
							}
							if (flag)
							{
								break;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			if (DGV_WaypointsWeapon.SelectedRows.Count > 0)
			{
				Client.FlightPlanEditorWeaponRouteWindow.SelectedRow = DGV_WaypointsWeapon.SelectedRows[0].Index;
				Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint = (Waypoint)DGV_WaypointsWeapon.Rows[Client.FlightPlanEditorWeaponRouteWindow.SelectedRow].Tag;
				DGV_WaypointsWeapon.Rows[0].Selected = false;
			}
			Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: false);
			_ = Client.FlightPlanTimeWindow.Visible;
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void QueryDatabase(object sender, EventArgs e)
	{
		try
		{
			if (DGV_WaypointsWeapon.SelectedRows.Count == 0)
			{
				return;
			}
			for (int i = DGV_WaypointsWeapon.Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow dataGridViewRow = DGV_WaypointsWeapon.Rows[i];
				if (!dataGridViewRow.Selected)
				{
					continue;
				}
				Waypoint waypoint = (Waypoint)dataGridViewRow.Tag;
				switch (waypoint.Type)
				{
				default:
					if (waypoint.CheckReponse())
					{
						Interaction.MsgBox("无法删除开始警戒或结束警戒航点！");
					}
					else if (waypoint.IncludeReponse())
					{
						Interaction.MsgBox("无法删除开始警戒或结束警戒航点！");
					}
					else
					{
						Interaction.MsgBox("无法删除航点！");
					}
					break;
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
					if (waypoint.SetupReponse())
					{
						Interaction.MsgBox("无法删除编队分解航点。改变队型，然后再试一次。");
					}
					else
					{
						if (Information.IsNothing(waypoint))
						{
							break;
						}
						foreach (ActiveUnit unit in Client.CurrentSide.Units)
						{
							if (unit.Navigator.HasPlottedCourse())
							{
								if (unit.Navigator.PlottedCourse.Contains(waypoint))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint, bool_1: true);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_LeadElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_LeadElementWingman, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_SecondElement) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_SecondElement))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_SecondElement, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_SecondElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_SecondElementWingman, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_ThirdElement) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_ThirdElement))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_ThirdElement, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_ThirdElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_ThirdElementWingman, bool_1: false);
								}
							}
						}
					}
					break;
				}
			}
			if (DGV_WaypointsWeapon.SelectedRows.Count > 0)
			{
				Client.FlightPlanEditorWeaponRouteWindow.SelectedRow = DGV_WaypointsWeapon.SelectedRows[0].Index;
				Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint = (Waypoint)DGV_WaypointsWeapon.Rows[Client.FlightPlanEditorWeaponRouteWindow.SelectedRow].Tag;
				DGV_WaypointsWeapon.Rows[0].Selected = false;
			}
			Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: false);
			_ = Client.FlightPlanTimeWindow.Visible;
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ResetDatabase(object sender, EventArgs e)
	{
		Waypoint expression = null;
		for (int i = Client.FlightPlanEditorWeaponRouteWindow.theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows.Count - 1; i >= 0; i += -1)
		{
			DataGridViewRow dataGridViewRow = Client.FlightPlanEditorWeaponRouteWindow.theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[i];
			if (dataGridViewRow.Selected)
			{
				expression = (Waypoint)dataGridViewRow.Tag;
				break;
			}
		}
		if (!Information.IsNothing(expression))
		{
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
			Client.FlightPlanTimeWindow.Show();
			Client.FlightPlanTimeWindow.BringToFront();
		}
	}

	private void MapDatabase(object sender, EventArgs e)
	{
		int num = DGV_WaypointsWeapon.Rows.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			DataGridViewRow dataGridViewRow = DGV_WaypointsWeapon.Rows[i];
			if (dataGridViewRow.Selected)
			{
				Waypoint speedAlt_FlightPlanWaypoint = (Waypoint)dataGridViewRow.Tag;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint = speedAlt_FlightPlanWaypoint;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_SelectedUnit = null;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Flight = null;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Mission = null;
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
				ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Show();
				break;
			}
		}
	}

	private void SortDatabase(object sender, DataGridViewCellPaintingEventArgs e)
	{
		try
		{
			if (e.RowIndex == 0 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["Time_Zulu"].Index)
			{
				Rectangle cellBounds = e.CellBounds;
				cellBounds.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds, cellsPaintSelectionBackground: true);
				e.PaintContent(cellBounds);
			}
			else if (e.RowIndex == 0 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["DesiredSpeed"].Index)
			{
				Rectangle cellBounds2 = e.CellBounds;
				cellBounds2.Y += (int)Math.Round((double)e.CellBounds.Height / 2.0);
				cellBounds2.Height = (int)Math.Round((double)e.CellBounds.Height / 2.0);
				e.PaintBackground(cellBounds2, cellsPaintSelectionBackground: true);
				e.PaintContent(cellBounds2);
			}
			else if (e.RowIndex == 0)
			{
				_ = e.ColumnIndex;
				_ = e.ColumnIndex;
			}
			if (DGV_WaypointsWeapon.Columns["Time_Local"].Index == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				if (DGV_WaypointsWeapon.SelectedRows.Count > 0 && DGV_WaypointsWeapon.SelectedRows[0].Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.SelectionBackColor, 1, ButtonBorderStyle.Solid, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None);
				}
				Rectangle cellBounds3 = e.CellBounds;
				int num = DGV_WaypointsWeapon.GetCellDisplayRectangle(DGV_WaypointsWeapon.Columns["TimeFixedImg"].Index, e.RowIndex, cutOverflow: true).Width;
				cellBounds3.Width += num;
				ControlPaint.DrawBorder(e.Graphics, cellBounds3, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, Color.Red, 0, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (DGV_WaypointsWeapon.Columns["DesiredSpeed"].Index == e.ColumnIndex && e.RowIndex >= 0)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				if (DGV_WaypointsWeapon.SelectedRows.Count > 0 && DGV_WaypointsWeapon.SelectedRows[0].Index == e.RowIndex)
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.SelectionBackColor, 1, ButtonBorderStyle.Solid, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None);
				}
				else
				{
					ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None);
				}
				Rectangle cellBounds4 = e.CellBounds;
				int num2 = DGV_WaypointsWeapon.GetCellDisplayRectangle(DGV_WaypointsWeapon.Columns["SpeedFixedImg"].Index, e.RowIndex, cutOverflow: true).Width;
				cellBounds4.Width += num2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds4, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, Color.Red, 0, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (DGV_WaypointsWeapon.Columns["Time_Local"].Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds5 = e.CellBounds;
				cellBounds5.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds5.Y++;
				cellBounds5.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds5, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (DGV_WaypointsWeapon.Columns["DesiredSpeed"].Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds6 = e.CellBounds;
				cellBounds6.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds6.Y++;
				cellBounds6.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds6, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (DGV_WaypointsWeapon.Columns["TimeFixedImg"].Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds7 = e.CellBounds;
				cellBounds7.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds7.Height -= 2;
				cellBounds7.Y++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds7, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
			else if (DGV_WaypointsWeapon.Columns["SpeedFixedImg"].Index == e.ColumnIndex && e.RowIndex == -1)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
				ControlPaint.DrawBorder(e.Graphics, e.CellBounds, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.Solid, e.CellStyle.BackColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.DefaultCellStyle.BackColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.None);
				Rectangle cellBounds8 = e.CellBounds;
				cellBounds8.Width++;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.Solid);
				cellBounds8.Y++;
				cellBounds8.Height -= 2;
				ControlPaint.DrawBorder(e.Graphics, cellBounds8, DGV_WaypointsWeapon.GridColor, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 2, ButtonBorderStyle.Solid, Color.Red, 1, ButtonBorderStyle.None, e.CellStyle.BackColor, 1, ButtonBorderStyle.Solid);
				e.Handled = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalcDatabase(object sender, DataGridViewColumnEventArgs e)
	{
		Rectangle displayRectangle = DGV_WaypointsWeapon.DisplayRectangle;
		DGV_WaypointsWeapon.Invalidate(displayRectangle);
	}

	private void RateDatabase(object sender, PaintEventArgs e)
	{
	}

	private void FlushDatabase(object sender, ScrollEventArgs e)
	{
	}

	private void ForgotDatabase(object sender, EventArgs e)
	{
	}

	private void CollectDatabase(object sender, EventArgs e)
	{
	}

	private void OrderDatabase(object sender, EventArgs e)
	{
		if (Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh)
		{
			DisplayLocks();
			EnableAndDisableCells();
			EnableAndDisableButtons();
		}
	}

	public void DisplayLocks()
	{
		try
		{
			Client.FlightPlanEditorWeaponRouteWindow.theImageLocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable.MakeTransparent(Color.White);
			Client.FlightPlanEditorWeaponRouteWindow.theImageRelative.MakeTransparent(Color.White);
			bool waypointList_Refresh = Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh;
			Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = false;
			IEnumerator enumerator = null;
			try
			{
				enumerator = ((IEnumerable)DGV_WaypointsWeapon.Rows).GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 1))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageLocked)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageLocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 0))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 2))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 3))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageRelative)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageRelative;
						}
					}
					else if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured)
					{
						dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured;
					}
					if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 1))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageLocked)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageLocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 0))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageUnlocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 2))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotLockable;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 3))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageRelative)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageRelative;
						}
					}
					else if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured)
					{
						dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWeaponRouteWindow.theImageNotConfigured;
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
			Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = waypointList_Refresh;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EnableAndDisableCells()
	{
		try
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = ((IEnumerable)DGV_WaypointsWeapon.Rows).GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					Waypoint waypoint = (Waypoint)dataGridViewRow.Tag;
					if (!Information.IsNothing(waypoint))
					{
						if (waypoint.Type == Waypoint.WaypointType.StationEnd)
						{
							dataGridViewRow.Cells["Type"].ReadOnly = true;
							dataGridViewRow.Cells["Type"].Style.BackColor = Color.LightGray;
							dataGridViewRow.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
							dataGridViewRow.Cells["Type"].Style.SelectionForeColor = Color.Black;
						}
						else if (dataGridViewRow.Cells["Type"].ReadOnly)
						{
							dataGridViewRow.Cells["Type"].ReadOnly = false;
							dataGridViewRow.Cells["Type"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["Type"].Style.SelectionBackColor = default(Color);
						}
						if (waypoint.Type == Waypoint.WaypointType.HoldEnd)
						{
							dataGridViewRow.Cells["Type"].ReadOnly = true;
							dataGridViewRow.Cells["Type"].Style.BackColor = Color.LightGray;
							dataGridViewRow.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
							dataGridViewRow.Cells["Type"].Style.SelectionForeColor = Color.Black;
						}
						else if (dataGridViewRow.Cells["Type"].ReadOnly)
						{
							dataGridViewRow.Cells["Type"].ReadOnly = false;
							dataGridViewRow.Cells["Type"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["Type"].Style.SelectionBackColor = default(Color);
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
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EnableAndDisableButtons()
	{
		try
		{
			Button_InsertWaypoint.Enabled = false;
			Button_DeleteWaypoint.Enabled = false;
			Button_EditSpeedAltitude.Enabled = false;
			Button_EditTime.Enabled = false;
			Button_ClearTime.Enabled = false;
			if (DGV_WaypointsWeapon.SelectedRows.Count == 1)
			{
				int num = DGV_WaypointsWeapon.Rows.Count - 1;
				int num2 = 0;
				Waypoint waypoint;
				while (true)
				{
					if (num2 > num)
					{
						return;
					}
					DataGridViewRow dataGridViewRow = DGV_WaypointsWeapon.Rows[num2];
					if (dataGridViewRow.Selected)
					{
						waypoint = (Waypoint)dataGridViewRow.Tag;
						if (!Information.IsNothing(waypoint))
						{
							break;
						}
					}
					num2++;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldEnd:
					Button_InsertWaypoint.Enabled = true;
					break;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
					Button_DeleteWaypoint.Enabled = true;
					break;
				}
				switch (waypoint.Type)
				{
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.LandingMarshal:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
				case Waypoint.WaypointType.StationStart_Racetrack:
				case Waypoint.WaypointType.StationStart_FigureEight:
				case Waypoint.WaypointType.StationStart_Area:
				case Waypoint.WaypointType.StationStart_RaceTrackRandom:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldStart:
				case Waypoint.WaypointType.HoldEnd:
					Button_EditSpeedAltitude.Enabled = true;
					break;
				}
				Button_EditTime.Enabled = true;
			}
			else if (DGV_WaypointsWeapon.SelectedRows.Count <= 1)
			{
				if (DGV_WaypointsWeapon.Rows.Count > 0)
				{
					Button_ClearTime.Enabled = true;
				}
			}
			else if (DGV_WaypointsWeapon.Rows.Count > 0)
			{
				Button_ClearTime.Enabled = true;
				Button_DeleteWaypoint.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RegisterDatabase(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int num = DGV_WaypointsWeapon.Rows.Count - 1;
			DataGridViewRow dataGridViewRow = null;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow2 = DGV_WaypointsWeapon.Rows[i];
				if (!dataGridViewRow2.Selected)
				{
					continue;
				}
				dataGridViewRow = dataGridViewRow2;
				Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint = (Waypoint)dataGridViewRow.Tag;
				Client.SelectedWaypoint = Client.FlightPlanEditorWeaponRouteWindow.SelectedWaypoint;
				DataGridViewColumn dataGridViewColumn = DGV_WaypointsWeapon.Columns[e.ColumnIndex];
				if (Operators.CompareString(dataGridViewColumn.Name, "Type", TextCompare: true) == 0)
				{
					if (!DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_ = new DataTable();
						DataGridViewComboBoxCell obj = (DataGridViewComboBoxCell)DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_WaypointType_WeaponRoute(ref dataTable_);
						obj.DataSource = dataTable_;
						obj.DisplayMember = "Description";
						obj.ValueMember = "ID";
						obj.DropDownWidth = 500;
					}
					DGV_WaypointsWeapon.BeginEdit(selectAll: true);
					if (DGV_WaypointsWeapon.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_WaypointsWeapon.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_WaypointsWeapon.EditingControl).DroppedDown = true;
					}
					break;
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "Formation", TextCompare: true) == 0)
				{
					if (!DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_2 = new DataTable();
						DataGridViewComboBoxCell obj2 = (DataGridViewComboBoxCell)DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_Formation(ref dataTable_2);
						obj2.DataSource = dataTable_2;
						obj2.DisplayMember = "Description";
						obj2.ValueMember = "ID";
						obj2.DropDownWidth = 500;
					}
					DGV_WaypointsWeapon.BeginEdit(selectAll: true);
					if (DGV_WaypointsWeapon.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_WaypointsWeapon.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_WaypointsWeapon.EditingControl).DroppedDown = true;
					}
					break;
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "AARUsage", TextCompare: true) == 0)
				{
					Waypoint waypoint = (Waypoint)dataGridViewRow2.Tag;
					if (!Information.IsNothing(waypoint))
					{
						if (!DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
						{
							DataTable dataTable_3 = new DataTable();
							waypoint.Doctrine.ComboBox_UseReplenishment(ref dataTable_3, Client.CurrentScenario, null);
							DataGridViewComboBoxCell obj3 = (DataGridViewComboBoxCell)DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index];
							obj3.DataSource = dataTable_3;
							obj3.DisplayMember = "Description";
							obj3.ValueMember = "ID";
							obj3.DropDownWidth = 500;
						}
						DGV_WaypointsWeapon.BeginEdit(selectAll: true);
						if (DGV_WaypointsWeapon.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_WaypointsWeapon.EditingControl))
						{
							((DataGridViewComboBoxEditingControl)DGV_WaypointsWeapon.EditingControl).DroppedDown = true;
						}
						break;
					}
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "AARSelection", TextCompare: true) == 0)
				{
					Waypoint waypoint2 = (Waypoint)dataGridViewRow2.Tag;
					if (!Information.IsNothing(waypoint2))
					{
						if (!DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
						{
							DataTable dataTable_4 = new DataTable();
							waypoint2.Doctrine.ComboBox_ReplenishmentSelection(ref dataTable_4, Client.CurrentScenario, null);
							DataGridViewComboBoxCell obj4 = (DataGridViewComboBoxCell)DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index];
							obj4.DataSource = dataTable_4;
							obj4.DisplayMember = "Description";
							obj4.ValueMember = "ID";
							obj4.DropDownWidth = 500;
						}
						DGV_WaypointsWeapon.BeginEdit(selectAll: true);
						if (DGV_WaypointsWeapon.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_WaypointsWeapon.EditingControl))
						{
							((DataGridViewComboBoxEditingControl)DGV_WaypointsWeapon.EditingControl).DroppedDown = true;
						}
						break;
					}
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "SpeedToT", TextCompare: true) == 0)
				{
					if (!DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_5 = new DataTable();
						DataGridViewComboBoxCell obj5 = (DataGridViewComboBoxCell)DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_SpeedToT(ref dataTable_5);
						obj5.DataSource = dataTable_5;
						obj5.DisplayMember = "Description";
						obj5.ValueMember = "ID";
						obj5.DropDownWidth = 500;
					}
					DGV_WaypointsWeapon.BeginEdit(selectAll: true);
					if (DGV_WaypointsWeapon.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_WaypointsWeapon.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_WaypointsWeapon.EditingControl).DroppedDown = true;
					}
				}
				else if (Operators.CompareString(dataGridViewColumn.Name, "TurnRate", TextCompare: true) == 0)
				{
					if (!DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_6 = new DataTable();
						DataGridViewComboBoxCell obj6 = (DataGridViewComboBoxCell)DGV_WaypointsWeapon[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_TurnRate(ref dataTable_6);
						obj6.DataSource = dataTable_6;
						obj6.DisplayMember = "Description";
						obj6.ValueMember = "ID";
						obj6.DropDownWidth = 500;
					}
					DGV_WaypointsWeapon.BeginEdit(selectAll: true);
					if (DGV_WaypointsWeapon.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_WaypointsWeapon.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_WaypointsWeapon.EditingControl).DroppedDown = true;
					}
				}
				else if (Operators.CompareString(dataGridViewColumn.Name, "TimeFixedImg", TextCompare: true) == 0)
				{
					Waypoint waypoint3 = (Waypoint)dataGridViewRow2.Tag;
					if (Information.IsNothing(waypoint3.Time_Zulu))
					{
						break;
					}
					if (waypoint3.TimeFixed == Waypoint.FixedFree.Free)
					{
						waypoint3.TimeFixed = Waypoint.FixedFree.Fixed;
						dataGridViewRow2.Cells["TimeFixed"].Value = waypoint3.TimeFixed;
					}
					else if (waypoint3.TimeFixed == Waypoint.FixedFree.Fixed)
					{
						if (waypoint3.FlightFormation == Waypoint.Formation.Split)
						{
							waypoint3.TimeFixed = Waypoint.FixedFree.Relative;
							dataGridViewRow2.Cells["TimeFixed"].Value = waypoint3.TimeFixed;
						}
						else
						{
							waypoint3.TimeFixed = Waypoint.FixedFree.Free;
							dataGridViewRow2.Cells["TimeFixed"].Value = waypoint3.TimeFixed;
						}
					}
					else if (waypoint3.TimeFixed == Waypoint.FixedFree.Relative)
					{
						waypoint3.TimeFixed = Waypoint.FixedFree.Free;
						dataGridViewRow2.Cells["TimeFixed"].Value = waypoint3.TimeFixed;
					}
					flag = true;
					flag2 = true;
					flag4 = true;
				}
				else
				{
					if (Operators.CompareString(dataGridViewColumn.Name, "SpeedFixedImg", TextCompare: true) != 0)
					{
						break;
					}
					Waypoint waypoint4 = (Waypoint)dataGridViewRow2.Tag;
					if (waypoint4.SpeedFixed == Waypoint.FixedFree.Free)
					{
						if (!Information.IsNothing(waypoint4.DesiredSpeed) || waypoint4.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							waypoint4.SpeedFixed = Waypoint.FixedFree.Fixed;
						}
					}
					else if (waypoint4.SpeedFixed == Waypoint.FixedFree.Fixed)
					{
						if (waypoint4.Type != Waypoint.WaypointType.TakeOff && waypoint4.Type != Waypoint.WaypointType.Land)
						{
							waypoint4.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
							waypoint4.DesiredSpeed = null;
							waypoint4.DesiredSpeedOverride = null;
							waypoint4.SpeedFixed = Waypoint.FixedFree.Free;
						}
						else
						{
							waypoint4.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
							waypoint4.DesiredSpeed = null;
							waypoint4.DesiredSpeedOverride = null;
							waypoint4.SpeedFixed = Waypoint.FixedFree.Fixed;
						}
					}
					else if (waypoint4.SpeedFixed == Waypoint.FixedFree.Relative)
					{
						waypoint4.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
						waypoint4.DesiredSpeed = null;
						waypoint4.DesiredSpeedOverride = null;
						waypoint4.SpeedFixed = Waypoint.FixedFree.Free;
					}
					flag = true;
					flag2 = true;
				}
				break;
			}
			if (Information.IsNothing(dataGridViewRow))
			{
				Button_InsertWaypoint.Enabled = false;
				Button_DeleteWaypoint.Enabled = false;
				Button_EditTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_EditSpeedAltitude.Enabled = false;
			}
			else
			{
				Button_InsertWaypoint.Enabled = true;
				Button_DeleteWaypoint.Enabled = true;
				Button_EditTime.Enabled = true;
				Button_ClearTime.Enabled = true;
				Button_EditSpeedAltitude.Enabled = true;
			}
			if (flag)
			{
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, flag2, bool_2: false, flag3, bool_4: false);
			}
			else if (flag3)
			{
				Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
			}
			else if (flag2)
			{
				Client.FlightPlanEditorWeaponRouteWindow.ListPrinter();
			}
			if (flag || flag3 || flag2)
			{
				DisplayLocks();
				EnableAndDisableCells();
			}
			_ = Client.FlightPlanTimeWindow.Visible;
			if (flag4 && Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
				Client.AirTaskingOrderWindow.DisplayLocks();
			}
			EnableAndDisableButtons();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200588", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Waypoint GetActualWaypoint(ref Waypoint waypoint_0, Mission.Flight.FlightElement flightElement_0)
	{
		try
		{
			if (flightElement_0 == Mission.Flight.FlightElement.LeadElement)
			{
				return waypoint_0;
			}
			if (waypoint_0.FlightFormation == Waypoint.Formation.Spread)
			{
				return waypoint_0;
			}
			switch (flightElement_0)
			{
			case Mission.Flight.FlightElement.LeadElementWingman:
				if (!Information.IsNothing(waypoint_0.Waypoint_LeadElementWingman))
				{
					return waypoint_0.Waypoint_LeadElementWingman;
				}
				break;
			case Mission.Flight.FlightElement.SecondElement:
				if (!Information.IsNothing(waypoint_0.Waypoint_SecondElement))
				{
					return waypoint_0.Waypoint_SecondElement;
				}
				break;
			case Mission.Flight.FlightElement.SecondElementWingman:
				if (!Information.IsNothing(waypoint_0.Waypoint_SecondElementWingman))
				{
					return waypoint_0.Waypoint_SecondElementWingman;
				}
				break;
			case Mission.Flight.FlightElement.ThirdElement:
				if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElement))
				{
					return waypoint_0.Waypoint_ThirdElement;
				}
				break;
			case Mission.Flight.FlightElement.ThirdElementWingman:
				if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElementWingman))
				{
					return waypoint_0.Waypoint_ThirdElementWingman;
				}
				break;
			}
			return waypoint_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private void ManageDatabase(object sender, DataGridViewCellEventArgs e)
	{
		if (DGV_WaypointsWeapon.SelectedRows.Count != 0 && Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh)
		{
			CountInterceptor(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void RevertDatabase(object sender, EventArgs e)
	{
		Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = true;
		if (DGV_WaypointsWeapon.IsCurrentCellDirty)
		{
			DGV_WaypointsWeapon.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void CountInterceptor(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			bool flag = false;
			if (Information.IsNothing(Client.FlightPlanEditorWeaponRouteWindow.SelectedWeapon) || e.RowIndex > Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute.Count() - 1)
			{
				return;
			}
			Waypoint waypoint = Client.FlightPlanEditorWeaponRouteWindow.SelectedRoute[e.RowIndex];
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["Type"].Index)
			{
				DataGridViewCell dataGridViewCell = DGV_WaypointsWeapon[e.ColumnIndex, e.RowIndex];
				object object_ = RuntimeHelpers.GetObjectValue(dataGridViewCell.Value);
				int? num = Waypoint.WaypointTypeSelection_To_WaypointType_WeaponRoute(ref object_);
				dataGridViewCell.Value = RuntimeHelpers.GetObjectValue(object_);
				Waypoint.WaypointType value = (Waypoint.WaypointType)num.Value;
				if (e.RowIndex == 0)
				{
					if (value == Waypoint.WaypointType.TakeOff)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("飞行计划中的第一个航点必须是起飞航路点！");
					}
				}
				else if (e.RowIndex == DGV_WaypointsWeapon.Rows.Count - 1)
				{
					if (value == Waypoint.WaypointType.Land)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("飞行计划中的最后一个航点必须是着陆航点！");
					}
				}
				else if (e.RowIndex == DGV_WaypointsWeapon.Rows.Count - 2)
				{
					if (value == Waypoint.WaypointType.LandingMarshal)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("飞行计划中的倒数第二个航点必须是着陆集结航点！");
					}
				}
				else
				{
					switch (value)
					{
					case Waypoint.WaypointType.LandingMarshal:
						if (e.RowIndex == DGV_WaypointsWeapon.Rows.Count - 2)
						{
							waypoint.Type = value;
							break;
						}
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("着陆集结航点必须是飞行计划中的第二个航点！");
						break;
					case Waypoint.WaypointType.TakeOff:
						if (e.RowIndex == 0)
						{
							waypoint.Type = value;
							break;
						}
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("起飞航点必须是飞行计划中的第一个航点！");
						break;
					case Waypoint.WaypointType.Land:
						if (e.RowIndex == DGV_WaypointsWeapon.Rows.Count - 1)
						{
							waypoint.Type = value;
							break;
						}
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("登陆航点必须是飞行计划中的最后一个航点！");
						break;
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
						if (e.RowIndex < 1)
						{
							Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
							Interaction.MsgBox("飞行计划中的第一个航路点不能是开始巡逻航点！");
						}
						else if (e.RowIndex > DGV_WaypointsWeapon.Rows.Count - 4)
						{
							Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
							Interaction.MsgBox("飞行计划中的最后三个航路点不能是开始巡逻航点！原因：着陆和着陆集结航点都不能作为结束巡逻航点。注意！ 开始巡逻航后的航点自动变为结束巡逻航点。");
						}
						break;
					case Waypoint.WaypointType.StationEnd:
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("配置了开始巡逻航点时，将自动设置结束巡逻航点。请选择开始巡逻。");
						break;
					default:
					{
						if (waypoint.ChangeReponse() || waypoint.SearchReponse())
						{
							flag = true;
						}
						bool flag2 = false;
						bool flag3 = false;
						if (waypoint.Type != Waypoint.WaypointType.WeaponTarget && value != Waypoint.WaypointType.WeaponTarget && waypoint.Type != Waypoint.WaypointType.Target && value != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.InitialPoint && value != Waypoint.WaypointType.InitialPoint && waypoint.Type != Waypoint.WaypointType.WeaponLaunch && value != Waypoint.WaypointType.WeaponLaunch)
						{
							if (waypoint.Type == Waypoint.WaypointType.TurningPoint || value == Waypoint.WaypointType.TurningPoint || waypoint.Type == Waypoint.WaypointType.StrikeIngress || value == Waypoint.WaypointType.StrikeIngress || waypoint.Type == Waypoint.WaypointType.StrikeEgress || value == Waypoint.WaypointType.StrikeEgress)
							{
								flag3 = true;
							}
						}
						else
						{
							flag2 = true;
						}
						waypoint.Type = value;
						switch (value)
						{
						default:
							if (flag2)
							{
								Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
								flag = true;
							}
							else if (flag3)
							{
								Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
							}
							break;
						case Waypoint.WaypointType.Refuel:
							Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
							break;
						case Waypoint.WaypointType.Assemble:
							waypoint.Hold_Time = 600f;
							flag = true;
							break;
						}
						break;
					}
					case Waypoint.WaypointType.HoldStart:
						if (e.RowIndex < 1)
						{
							Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
							Interaction.MsgBox("飞行计划中的第一个航路点不能是开始警戒航点！");
						}
						else if (e.RowIndex > DGV_WaypointsWeapon.Rows.Count - 4)
						{
							Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
							Interaction.MsgBox("飞行计划中的倒数第三个航路点不能是开始警戒航点！原因：着陆和着陆集结航路点都不能是结束警戒航点。注意！开始警戒后的航点自动变为结束警戒航路点。");
						}
						break;
					case Waypoint.WaypointType.HoldEnd:
						Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
						Interaction.MsgBox("配置开始警戒航点时，会自动设置结束警戒航点。请选择开始警戒。");
						break;
					}
				}
				if (waypoint.Type != Waypoint.WaypointType.Assemble && waypoint.Type != Waypoint.WaypointType.HoldEnd)
				{
					if (waypoint.Hold_Time > 0f)
					{
						waypoint.Hold_Time = 0f;
						Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
						flag = true;
					}
				}
				else
				{
					Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
					flag = true;
				}
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["Formation"].Index)
			{
				DataGridViewCell dataGridViewCell2 = DGV_WaypointsWeapon[e.ColumnIndex, e.RowIndex];
				object object_2 = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Value);
				int? num2 = Waypoint.FormationSelection_To_Formation(ref object_2);
				dataGridViewCell2.Value = RuntimeHelpers.GetObjectValue(object_2);
				Waypoint.Formation value2 = (Waypoint.Formation)num2.Value;
				if (value2 == Waypoint.Formation.Split && waypoint.IncludeReponse())
				{
					Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
					Interaction.MsgBox("巡逻航点无法设置为拆分编队。");
				}
				else if (value2 == Waypoint.Formation.Split && waypoint.ConcatReponse())
				{
					Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
					Interaction.MsgBox("警戒和集合航点无法设置为拆分编队。");
				}
				else if (value2 == Waypoint.Formation.Split && e.RowIndex <= 1)
				{
					Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
					Interaction.MsgBox("飞行计划中的前两个航路点不能设置为拆分编队。");
				}
				else if (value2 == Waypoint.Formation.Split && e.RowIndex >= DGV_WaypointsWeapon.Rows.Count - 1)
				{
					Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
					Interaction.MsgBox("飞行计划中的最后一个航路点不能设置为拆分编队。");
				}
				else if (value2 == Waypoint.Formation.Split && waypoint.Type == Waypoint.WaypointType.LandingMarshal)
				{
					Client.FlightPlanEditorWeaponRouteWindow.VerifyPrinter();
					Interaction.MsgBox("着陆集合航路点不能设置为拆分编队。");
				}
				else
				{
					Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: false);
					flag = true;
				}
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["TurnRate"].Index)
			{
				DataGridViewCell dataGridViewCell3 = DGV_WaypointsWeapon[e.ColumnIndex, e.RowIndex];
				object object_3 = RuntimeHelpers.GetObjectValue(dataGridViewCell3.Value);
				int? num3 = Waypoint.TurnRateSelection_To_TurnRate(ref object_3);
				dataGridViewCell3.Value = RuntimeHelpers.GetObjectValue(object_3);
				waypoint.TurnRate_Navigation = (Waypoint.TurnRateCategory)num3.Value;
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: false, bool_4: false);
				flag = true;
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["AARUsage"].Index)
			{
				Doctrine doctrine = waypoint.Doctrine;
				int int_ = Conversions.ToInteger(DGV_WaypointsWeapon[e.ColumnIndex, e.RowIndex].Value);
				Scenario scenario_ = Client.CurrentScenario;
				int int_2 = 0;
				doctrine.SelectionChanged_Combo_UseRefuel(int_, ref scenario_, ref int_2, bool_0: false, bool_1: false, bool_2: false);
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["AARSelection"].Index)
			{
				Doctrine doctrine2 = waypoint.Doctrine;
				int int_3 = Conversions.ToInteger(DGV_WaypointsWeapon[e.ColumnIndex, e.RowIndex].Value);
				Scenario scenario_2 = Client.CurrentScenario;
				int int_4 = 0;
				doctrine2.SelectionChanged_Combo_ReplenishmentSelection(int_3, ref scenario_2, ref int_4, bool_0: false, bool_1: false, bool_2: false);
				Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_WaypointsWeapon.Columns["SpeedToT"].Index)
			{
				DataGridViewCell dataGridViewCell4 = DGV_WaypointsWeapon[e.ColumnIndex, e.RowIndex];
				object object_4 = RuntimeHelpers.GetObjectValue(dataGridViewCell4.Value);
				int? num4 = Waypoint.SpeedToTSelection_To_SpeedToT(ref object_4);
				dataGridViewCell4.Value = RuntimeHelpers.GetObjectValue(object_4);
				waypoint.SpeedAdjustmentToT = (Waypoint.SpeedToT)num4.Value;
			}
			DisplayLocks();
			EnableAndDisableCells();
			EnableAndDisableButtons();
			if (flag && Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
				Client.AirTaskingOrderWindow.EnableAndDisableButtons();
			}
			Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CustomizeInterceptor(object sender, EventArgs e)
	{
		if (Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh)
		{
			_ = DGV_WaypointsWeapon.SelectedRows.Count;
		}
	}

	private void CloneInterceptor(object sender, EventArgs e)
	{
		try
		{
			Client.FlightPlanEditorWeaponRouteWindow.RecalculateFlightPlanFuelAndTimes(bool_0: false, bool_1: true, bool_2: false, bool_3: false, bool_4: true);
			EnableAndDisableCells();
			EnableAndDisableButtons();
			RegistryParameterMessage.AwakeCustomer();
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			Mission mission_ = null;
			Mission.Flight flight_ = null;
			Waypoint waypoint_ = null;
			flightPlanTimeWindow.RefreshStats(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None, bool_0: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
