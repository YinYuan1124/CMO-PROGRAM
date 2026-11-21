using System;
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
public sealed class FlightPlanEditorWeaponRoute : DarkSecondaryFormBase
{
	private IContainer m_SystemTask;

	[AccessedThroughProperty("Button_ClearRoute")]
	[CompilerGenerated]
	private DarkButton candidateTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_CopyRouteFromWeapon1")]
	private DarkButton m_BaseTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Label8")]
	private DarkLabel printerTask;

	[AccessedThroughProperty("Label_ImpactDateAndTime")]
	[CompilerGenerated]
	private DarkLabel parserTask;

	[AccessedThroughProperty("Label_LaunchDateAndTime")]
	[CompilerGenerated]
	private DarkLabel m_DatabaseTask;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox_SelectedFlight")]
	private DarkGroupBox m_InterceptorTask;

	[AccessedThroughProperty("Combo_CurrentWeapon")]
	[CompilerGenerated]
	private DarkUIComboBox messageTask;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_ProductTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel annotationTask;

	public bool WaypointList_Refresh;

	public Weapon SelectedWeapon;

	public Waypoint[] SelectedRoute;

	public Waypoint SelectedWaypoint;

	public int SelectedRow;

	public FlightPlanWaypointsWeapon theFlightPlanWaypointsWeapon;

	private DataTable roleTask;

	private int m_FactoryTask;

	private int _AttributeTask;

	private int eventTask;

	private int m_GlobalTask;

	private int m_WorkerTask;

	private int _AccountTask;

	private int m_StateTask;

	private int authenticationTask;

	private int m_ParamsTask;

	private int m_InfoTask;

	private int _HelperTask;

	private int mapperTask;

	private int m_ManagerTask;

	private int m_GetterTask;

	private int producerTask;

	private int _ProcTask;

	private int m_StructFilter;

	private int m_MerchantFilter;

	private int callbackFilter;

	private DataTable m_DecoratorFilter;

	public Bitmap theImageLocked;

	public Bitmap theImageUnlocked;

	public Bitmap theImageNotConfigured;

	public Bitmap theImageNotLockable;

	public Bitmap theImageRelative;

	internal DarkButton Button_ClearRoute
	{
		[CompilerGenerated]
		get
		{
			return candidateTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			candidateTask = value;
		}
	}

	internal DarkButton Button_CopyRouteFromWeapon1
	{
		[CompilerGenerated]
		get
		{
			return m_BaseTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BaseTask = value;
		}
	}

	[field: AccessedThroughProperty("FlightPlanWaypointsWeapon1")]
	internal FlightPlanWaypointsWeapon FlightPlanWaypointsWeapon1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label_AircraftType")]
	internal DarkLabel Label_AircraftType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return printerTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerTask = value;
		}
	}

	internal DarkLabel Label_ImpactDateAndTime
	{
		[CompilerGenerated]
		get
		{
			return parserTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			parserTask = value;
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_LaunchDateAndTime
	{
		[CompilerGenerated]
		get
		{
			return m_DatabaseTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DatabaseTask = value;
		}
	}

	internal DarkGroupBox GroupBox_SelectedFlight
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorTask = value;
		}
	}

	internal DarkUIComboBox Combo_CurrentWeapon
	{
		[CompilerGenerated]
		get
		{
			return messageTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			messageTask = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_ProductTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProductTask = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return annotationTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			annotationTask = value;
		}
	}

	[field: AccessedThroughProperty("Combo_CurrentAircraft")]
	internal DarkUIComboBox Combo_CurrentAircraft
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button_CopyRouteToAllWeapons")]
	internal DarkButton Button_CopyRouteToAllWeapons
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FlightPlanEditorWeaponRoute()
	{
		base.FormClosing += VisitPrinter;
		base.VisibleChanged += RestartPrinter;
		base.KeyDown += ResolvePrinter;
		base.Shown += PostPrinter;
		WaypointList_Refresh = true;
		SelectedRow = 0;
		roleTask = new DataTable();
		m_DecoratorFilter = new DataTable();
		theImageLocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Locked_16.png");
		theImageUnlocked = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Unlocked_16.png");
		theImageNotConfigured = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotConfigured_16.png");
		theImageNotLockable = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\NotLockable_16.png");
		theImageRelative = (Bitmap)Image.FromFile(GlobalVariables.ApplicationStartupPath + "\\symbols\\menu\\Relative_16.png");
		ReflectPrinter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_SystemTask != null)
			{
				m_SystemTask.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ReflectPrinter()
	{
		Button_ClearRoute = new DarkButton();
		Button_CopyRouteFromWeapon1 = new DarkButton();
		FlightPlanWaypointsWeapon1 = new FlightPlanWaypointsWeapon();
		Label_AircraftType = new DarkLabel();
		Label6 = new DarkLabel();
		Label8 = new DarkLabel();
		Label_ImpactDateAndTime = new DarkLabel();
		Label5 = new DarkLabel();
		Label_LaunchDateAndTime = new DarkLabel();
		GroupBox_SelectedFlight = new DarkGroupBox();
		Combo_CurrentWeapon = new DarkUIComboBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Combo_CurrentAircraft = new DarkUIComboBox();
		Button_CopyRouteToAllWeapons = new DarkButton();
		GroupBox_SelectedFlight.SuspendLayout();
		SuspendLayout();
		Button_ClearRoute.Enabled = false;
		Button_ClearRoute.Location = new Point(302, 49);
		Button_ClearRoute.Name = "Button_ClearRoute";
		Button_ClearRoute.Padding = new Padding(5);
		Button_ClearRoute.Size = new Size(185, 24);
		Button_ClearRoute.TabIndex = 37;
		Button_ClearRoute.Text = "清除路径";
		Button_CopyRouteFromWeapon1.Location = new Point(302, 80);
		Button_CopyRouteFromWeapon1.Name = "Button_CopyRouteFromWeapon1";
		Button_CopyRouteFromWeapon1.Padding = new Padding(5);
		Button_CopyRouteFromWeapon1.Size = new Size(185, 24);
		Button_CopyRouteFromWeapon1.TabIndex = 35;
		Button_CopyRouteFromWeapon1.Text = "从武器1复制路径";
		FlightPlanWaypointsWeapon1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		FlightPlanWaypointsWeapon1.BackColor = Color.Transparent;
		FlightPlanWaypointsWeapon1.Dock = DockStyle.Bottom;
		FlightPlanWaypointsWeapon1.Location = new Point(0, 282);
		FlightPlanWaypointsWeapon1.MinimumSize = new Size(500, 500);
		FlightPlanWaypointsWeapon1.Name = "FlightPlanWaypointsWeapon1";
		FlightPlanWaypointsWeapon1.Size = new Size(629, 500);
		FlightPlanWaypointsWeapon1.TabIndex = 38;
		Label_AircraftType.AutoSize = true;
		Label_AircraftType.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AircraftType.Location = new Point(125, 147);
		Label_AircraftType.Name = "Label_AircraftType";
		Label_AircraftType.Size = new Size(93, 15);
		Label_AircraftType.TabIndex = 40;
		Label_AircraftType.Text = "<武器类型>";
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(18, 147);
		Label6.Name = "Label6";
		Label6.Size = new Size(54, 15);
		Label6.TabIndex = 39;
		Label6.Text = "武器：";
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(18, 226);
		Label8.Name = "Label8";
		Label8.Size = new Size(101, 15);
		Label8.TabIndex = 44;
		Label8.Text = "祖鲁命中时间：";
		Label_ImpactDateAndTime.AutoSize = true;
		Label_ImpactDateAndTime.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ImpactDateAndTime.Location = new Point(125, 226);
		Label_ImpactDateAndTime.Name = "Label_ImpactDateAndTime";
		Label_ImpactDateAndTime.Size = new Size(136, 15);
		Label_ImpactDateAndTime.TabIndex = 43;
		Label_ImpactDateAndTime.Text = "<命中日期和时间>";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(18, 198);
		Label5.Name = "Label5";
		Label5.Size = new Size(100, 15);
		Label5.TabIndex = 42;
		Label5.Text = "祖鲁发射时间：";
		Label_LaunchDateAndTime.AutoSize = true;
		Label_LaunchDateAndTime.ForeColor = Color.FromArgb(220, 220, 220);
		Label_LaunchDateAndTime.Location = new Point(125, 198);
		Label_LaunchDateAndTime.Name = "Label_LaunchDateAndTime";
		Label_LaunchDateAndTime.Size = new Size(138, 15);
		Label_LaunchDateAndTime.TabIndex = 41;
		Label_LaunchDateAndTime.Text = "<起飞日期和时间>";
		GroupBox_SelectedFlight.Controls.Add(Combo_CurrentWeapon);
		GroupBox_SelectedFlight.Controls.Add(Label1);
		GroupBox_SelectedFlight.Controls.Add(Label2);
		GroupBox_SelectedFlight.Controls.Add(Combo_CurrentAircraft);
		GroupBox_SelectedFlight.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_SelectedFlight.Location = new Point(14, 11);
		GroupBox_SelectedFlight.Name = "GroupBox_SelectedFlight";
		GroupBox_SelectedFlight.Size = new Size(240, 84);
		GroupBox_SelectedFlight.TabIndex = 45;
		GroupBox_SelectedFlight.TabStop = false;
		GroupBox_SelectedFlight.Text = "所选武器路径";
		Combo_CurrentWeapon.BackColor = Color.Transparent;
		Combo_CurrentWeapon.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_CurrentWeapon.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_CurrentWeapon.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_CurrentWeapon.FormattingEnabled = true;
		Combo_CurrentWeapon.Location = new Point(69, 48);
		Combo_CurrentWeapon.Name = "Combo_CurrentWeapon";
		Combo_CurrentWeapon.Size = new Size(153, 21);
		Combo_CurrentWeapon.TabIndex = 12;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(9, 25);
		Label1.Name = "Label1";
		Label1.Size = new Size(49, 15);
		Label1.TabIndex = 11;
		Label1.Text = "飞机：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(9, 53);
		Label2.Name = "Label2";
		Label2.Size = new Size(54, 15);
		Label2.TabIndex = 11;
		Label2.Text = "武器：";
		Combo_CurrentAircraft.BackColor = Color.Transparent;
		Combo_CurrentAircraft.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_CurrentAircraft.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_CurrentAircraft.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_CurrentAircraft.FormattingEnabled = true;
		Combo_CurrentAircraft.Location = new Point(69, 24);
		Combo_CurrentAircraft.Name = "Combo_CurrentAircraft";
		Combo_CurrentAircraft.Size = new Size(153, 21);
		Combo_CurrentAircraft.TabIndex = 12;
		Button_CopyRouteToAllWeapons.Location = new Point(302, 110);
		Button_CopyRouteToAllWeapons.Name = "Button_CopyRouteToAllWeapons";
		Button_CopyRouteToAllWeapons.Padding = new Padding(5);
		Button_CopyRouteToAllWeapons.Size = new Size(185, 24);
		Button_CopyRouteToAllWeapons.TabIndex = 46;
		Button_CopyRouteToAllWeapons.Text = "将路径复制到所有武器";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(629, 782);
		base.Controls.Add(Button_CopyRouteToAllWeapons);
		base.Controls.Add(GroupBox_SelectedFlight);
		base.Controls.Add(Label8);
		base.Controls.Add(Label_ImpactDateAndTime);
		base.Controls.Add(Label5);
		base.Controls.Add(Label_LaunchDateAndTime);
		base.Controls.Add(Label_AircraftType);
		base.Controls.Add(Label6);
		base.Controls.Add(FlightPlanWaypointsWeapon1);
		base.Controls.Add(Button_ClearRoute);
		base.Controls.Add(Button_CopyRouteFromWeapon1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(515, 821);
		base.Name = "FlightPlanEditorWeaponRoute";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑武器路径";
		GroupBox_SelectedFlight.ResumeLayout(performLayout: false);
		GroupBox_SelectedFlight.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void VisitPrinter(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void RestartPrinter(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			LoadWindow();
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public void LoadWindow()
	{
		VerifyPrinter();
		StopPrinter(bool_0: false);
		_ = Client.FlightPlanTimeWindow.Visible;
	}

	public void RefreshWindow()
	{
		ListPrinter();
		_ = Client.FlightPlanTimeWindow.Visible;
	}

	public void ReloadWindow()
	{
		LoadWindow();
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	private string TestPrinter(ref ActiveUnit.Throttle throttle_0)
	{
		switch (throttle_0)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return throttle_0.ToString();
		case ActiveUnit.Throttle.FullStop:
			return "完全停止";
		case ActiveUnit.Throttle.Loiter:
			return "Loiter";
		case ActiveUnit.Throttle.Cruise:
			return "Cruise";
		case ActiveUnit.Throttle.Full:
			return "Military";
		case ActiveUnit.Throttle.Flank:
			return "Afterburner";
		}
	}

	internal void StopPrinter(bool bool_0)
	{
		try
		{
			CancelPrinter();
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

	private void CancelPrinter()
	{
	}

	internal void VerifyPrinter()
	{
		theFlightPlanWaypointsWeapon = FlightPlanWaypointsWeapon1;
		SelectedRow = 0;
		SelectedWaypoint = null;
		WaypointList_Refresh = false;
		roleTask.Clear();
		WaypointList_Refresh = true;
		if (roleTask.Columns.Count == 0)
		{
			if (!roleTask.Columns.Contains("ID"))
			{
				roleTask.Columns.Add("ID", typeof(string));
				m_FactoryTask = 0;
			}
			if (!roleTask.Columns.Contains("ObjectID"))
			{
				roleTask.Columns.Add("ObjectID", typeof(string));
				_AttributeTask = 1;
			}
			if (!roleTask.Columns.Contains("Type"))
			{
				roleTask.Columns.Add("Type", typeof(int));
				eventTask = 2;
			}
			if (!roleTask.Columns.Contains("Time_Zulu"))
			{
				roleTask.Columns.Add("Time_Zulu", typeof(string));
				m_GlobalTask = 3;
			}
			if (!roleTask.Columns.Contains("Time_Local"))
			{
				roleTask.Columns.Add("Time_Local", typeof(string));
				m_WorkerTask = 4;
			}
			if (!roleTask.Columns.Contains("TimeFixedImg"))
			{
				roleTask.Columns.Add("TimeFixedImg", typeof(Image));
				m_StateTask = 5;
			}
			if (!roleTask.Columns.Contains("TimeFixed"))
			{
				roleTask.Columns.Add("TimeFixed", typeof(int));
				_AccountTask = 6;
			}
			if (!roleTask.Columns.Contains("DesiredSpeed"))
			{
				roleTask.Columns.Add("DesiredSpeed", typeof(string));
				authenticationTask = 7;
			}
			if (!roleTask.Columns.Contains("SpeedFixedImg"))
			{
				roleTask.Columns.Add("SpeedFixedImg", typeof(Image));
				m_InfoTask = 8;
			}
			if (!roleTask.Columns.Contains("SpeedFixed"))
			{
				roleTask.Columns.Add("SpeedFixed", typeof(int));
				m_ParamsTask = 9;
			}
			if (!roleTask.Columns.Contains("DesiredAltitude"))
			{
				roleTask.Columns.Add("DesiredAltitude", typeof(string));
				_HelperTask = 10;
			}
			if (!roleTask.Columns.Contains("Leg_Distance"))
			{
				roleTask.Columns.Add("Leg_Distance", typeof(string));
				m_StructFilter = 11;
			}
			if (!roleTask.Columns.Contains("Leg_TotalDistance"))
			{
				roleTask.Columns.Add("Leg_TotalDistance", typeof(string));
				m_MerchantFilter = 12;
			}
			if (!roleTask.Columns.Contains("Leg_Time"))
			{
				roleTask.Columns.Add("Leg_Time", typeof(string));
				m_GetterTask = 13;
			}
			if (!roleTask.Columns.Contains("Hold_Time"))
			{
				roleTask.Columns.Add("Hold_Time", typeof(string));
				producerTask = 14;
			}
			if (!roleTask.Columns.Contains("Leg_TotalTime"))
			{
				roleTask.Columns.Add("Leg_TotalTime", typeof(string));
				_ProcTask = 15;
			}
			if (!roleTask.Columns.Contains("Leg_FuelRequired"))
			{
				roleTask.Columns.Add("Leg_FuelRequired", typeof(string));
				mapperTask = 16;
			}
			if (!roleTask.Columns.Contains("Leg_FuelRemaining"))
			{
				roleTask.Columns.Add("Leg_FuelRemaining", typeof(string));
				m_ManagerTask = 17;
			}
			if (!roleTask.Columns.Contains("Coordinates"))
			{
				roleTask.Columns.Add("Coordinates", typeof(string));
				callbackFilter = 18;
			}
		}
		DataGridViewComboBoxColumn obj = (DataGridViewComboBoxColumn)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Columns[theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Columns[eventTask].Index];
		Waypoint.ComboBoxDataSource_WaypointType_WeaponRoute(ref m_DecoratorFilter);
		obj.DataSource = m_DecoratorFilter;
		obj.DisplayMember = "Description";
		obj.ValueMember = "ID";
		WaypointList_Refresh = false;
		Waypoint[] selectedRoute = SelectedRoute;
		for (int i = 0; i < selectedRoute.Length; i = checked(i + 1))
		{
			DataRow row = roleTask.NewRow();
			roleTask.Rows.Add(row);
		}
		WaypointList_Refresh = true;
		ListPrinter();
		WaypointList_Refresh = false;
		theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.DataSource = new DataView(roleTask);
		WaypointList_Refresh = true;
		int count = theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows.Count;
		int num = SelectedRoute.Count();
		for (int j = count - 1; j >= 0; j += -1)
		{
			if (j <= num - 1)
			{
				Information.IsNothing(SelectedRoute[j]);
			}
		}
		WaypointList_Refresh = false;
		if (theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.RowCount <= 0)
		{
			SelectedWaypoint = null;
		}
		else if (SelectedRow <= theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.RowCount - 1)
		{
			theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[0].Selected = false;
			theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[SelectedRow].Selected = true;
			SelectedWaypoint = (Waypoint)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[SelectedRow].Tag;
		}
		else
		{
			theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[0].Selected = false;
			theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.RowCount - 1].Selected = true;
			SelectedWaypoint = (Waypoint)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[0].Tag;
		}
		WaypointList_Refresh = true;
		WaypointList_Refresh = false;
		theFlightPlanWaypointsWeapon.DisplayLocks();
		WaypointList_Refresh = true;
		theFlightPlanWaypointsWeapon.EnableAndDisableCells();
		theFlightPlanWaypointsWeapon.EnableAndDisableButtons();
	}

	internal void ListPrinter()
	{
		try
		{
			if (Information.IsNothing(SelectedWeapon))
			{
				Text = "飞机和武器的武器路径编辑";
				return;
			}
			if (Information.IsNothing(SelectedRoute))
			{
				Text = "飞行编队编辑";
				return;
			}
			Text = "飞行的飞行计划编辑";
			int num = 1;
			DateTime time = Client.CurrentScenario.Time;
			bool use_DST = Client.CurrentScenario.Use_DST;
			string dST_Start = Client.CurrentScenario.DST_Start;
			string dST_End = Client.CurrentScenario.DST_End;
			bool flag = false;
			bool flag2 = false;
			theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.SuspendLayout();
			try
			{
				int num2 = SelectedRoute.Count() - 1;
				DateTime? dateTime = null;
				string text = null;
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment2 = null;
				string text9 = null;
				for (int num3 = 0; num3 <= num2; num3++)
				{
					Waypoint waypoint = SelectedRoute[num3];
					DataRow dataRow = roleTask.Rows[num3];
					int num4 = Waypoint.WaypointType_To_WaypointTypeSelection_WeaponRoute(waypoint.Type);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[eventTask]), num4))
					{
						dataRow[eventTask] = num4;
					}
					string text10 = (string.IsNullOrEmpty(waypoint.Description) ? Conversions.ToString(num) : waypoint.Description);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_FactoryTask]), text10))
					{
						dataRow[m_FactoryTask] = text10;
					}
					num++;
					dataRow[_AttributeTask] = waypoint.ObjectID;
					string text11;
					if (Information.IsNothing(waypoint.Time_Zulu) || flag)
					{
						text11 = "-";
					}
					else
					{
						dateTime = (Information.IsNothing(waypoint.Time_Zulu_Weapon) ? waypoint.Time_Zulu : waypoint.Time_Zulu_Weapon);
						text11 = ((dateTime.Value.Hour < 10) ? ("0" + dateTime.Value.Hour + ":") : (dateTime.Value.Hour + ":"));
						text11 = ((dateTime.Value.Minute < 10) ? (text11 + "0" + dateTime.Value.Minute + ":") : (text11 + dateTime.Value.Minute + ":"));
						text11 = ((dateTime.Value.Second < 10) ? (text11 + "0" + dateTime.Value.Second) : (text11 + dateTime.Value.Second));
						if (waypoint.Type == Waypoint.WaypointType.TakeOff)
						{
							string text12 = dateTime.Value.Year + "-";
							text12 = ((dateTime.Value.Month < 10) ? (text12 + "0" + dateTime.Value.Month + "-") : (text12 + dateTime.Value.Month + "-"));
							text12 = ((dateTime.Value.Day < 10) ? (text12 + "0" + dateTime.Value.Day) : (text12 + dateTime.Value.Day));
							_ = text12 + ", " + text11;
						}
						else if (waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget || waypoint.SearchReponse())
						{
							string text13 = dateTime.Value.Year + "-";
							text13 = ((dateTime.Value.Month < 10) ? (text13 + "0" + dateTime.Value.Month + "-") : (text13 + dateTime.Value.Month + "-"));
							text13 = ((dateTime.Value.Day < 10) ? (text13 + "0" + dateTime.Value.Day) : (text13 + dateTime.Value.Day));
							_ = text13 + ", " + text11;
						}
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_GlobalTask]), text11))
					{
						dataRow[m_GlobalTask] = text11;
					}
					string text14;
					if (Information.IsNothing(dateTime) || Information.IsNothing(waypoint.Time_Local) || flag)
					{
						text14 = "-";
					}
					else
					{
						DateTime? dateTime2 = (Information.IsNothing(waypoint.Time_Zulu_Weapon) ? waypoint.Time_Local : waypoint.Time_Local_Weapon);
						text14 = ((dateTime2.Value.Hour < 10) ? ("0" + dateTime2.Value.Hour + ":") : (dateTime2.Value.Hour + ":"));
						text14 = ((dateTime2.Value.Minute < 10) ? (text14 + "0" + dateTime2.Value.Minute + ":") : (text14 + dateTime2.Value.Minute + ":"));
						text14 = ((dateTime2.Value.Second < 10) ? (text14 + "0" + dateTime2.Value.Second) : (text14 + dateTime2.Value.Second));
						waypoint.TimeOfDay = SunModule.CollectSpecification(null, dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day, dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second, bool_0: false, waypoint.Latitude, waypoint.Longitude, 0.0);
						if (Information.IsNothing(waypoint.Time_Zulu_Weapon))
						{
							waypoint.Time_Local = Misc.DisableRequest(waypoint.Time_Zulu.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
						}
						else
						{
							waypoint.Time_Local = Misc.DisableRequest(waypoint.Time_Zulu_Weapon.Value, waypoint.Longitude, use_DST, dST_Start, dST_End);
						}
						text14 = text14 + " (" + SunModule.ForgotSpecification(waypoint.TimeOfDay, time, waypoint.Longitude, use_DST, dST_Start, dST_End) + ")";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_WorkerTask]), text14))
					{
						dataRow[m_WorkerTask] = text14;
					}
					Waypoint.FixedFree fixedFree = ((Information.IsNothing(dateTime) || flag) ? Waypoint.FixedFree.None : waypoint.TimeFixed);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_AccountTask]), fixedFree))
					{
						dataRow[_AccountTask] = fixedFree;
					}
					if (!waypoint.Doctrine.EMCON_Inherits && (waypoint.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured || waypoint.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured || waypoint.Doctrine.NewRepository(Client.CurrentScenario).OECM() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured))
					{
						string text15 = "";
						if (waypoint.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active)
						{
							text15 = "雷达有效";
						}
						else if (waypoint.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Passive)
						{
							text15 = "雷达被动";
						}
						if (waypoint.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Active)
						{
							if (!string.IsNullOrEmpty(text15))
							{
								text15 += ", ";
							}
							text15 += "声纳活跃";
						}
						else if (waypoint.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() == Doctrine.EMCONSettings._EMCONSetting.Passive)
						{
							if (!string.IsNullOrEmpty(text15))
							{
								text15 += ", ";
							}
							text15 += "声纳被动";
						}
						if (waypoint.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Active)
						{
							if (!string.IsNullOrEmpty(text15))
							{
								text15 += ", ";
							}
							text15 += "OECM活跃";
						}
						else if (waypoint.Doctrine.NewRepository(Client.CurrentScenario).OECM() == Doctrine.EMCONSettings._EMCONSetting.Passive)
						{
							if (!string.IsNullOrEmpty(text15))
							{
								text15 += ", ";
							}
							text15 += "OECM被动";
						}
						if (string.IsNullOrEmpty(text15))
						{
							text15 = "未配置";
						}
					}
					string text16 = Misc.CoordsToEnglish(waypoint.Latitude, waypoint.Longitude);
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[callbackFilter]), text16))
					{
						dataRow[callbackFilter] = text16;
					}
					string text2 = ((waypoint.Leg_FuelRequired < -2.1474836E+09f) ? "未设置未知，飞机类型和挂载类型" : (((Information.IsNothing(waypoint.Time_Zulu) && (waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd)) || waypoint.Type == Waypoint.WaypointType.TakeOff) ? "-" : (Conversions.ToString((int)Math.Round(waypoint.Leg_FuelRequired)) + "千克")));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[mapperTask]), text2))
					{
						dataRow[mapperTask] = text2;
					}
					if (waypoint.Leg_FuelRemaining <= 2.1474836E+09f)
					{
						byte? b = (byte?)useUnderwayRefuelAndReplenishment;
						bool? flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						bool? flag4 = (!flag3) ?? flag3;
						if (flag4.GetValueOrDefault(true))
						{
							b = (byte?)useUnderwayRefuelAndReplenishment;
							bool? flag5;
							bool? flag6 = (flag5 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							bool? flag7;
							flag5 = (flag7 = ((flag6.HasValue && !flag5.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment2) ? new bool?(false) : flag5)));
							bool? flag8;
							if (flag5.HasValue && !flag7.GetValueOrDefault())
							{
								flag8 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment2;
								bool? flag9;
								flag5 = (flag9 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag8 = ((!flag5.HasValue) ? null : (flag9.GetValueOrDefault() & flag7));
							}
							flag3 = flag8;
							if (((!flag3) ?? flag3).GetValueOrDefault() && flag4.HasValue)
							{
								text = "未知，AAR允许";
								flag2 = false;
								goto IL_0e38;
							}
						}
						if (flag2)
						{
							text = "未知，巡逻时间未设置";
						}
					}
					else
					{
						text = "Unknown";
					}
					goto IL_0e38;
					IL_0e38:
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ManagerTask]), text))
					{
						dataRow[m_ManagerTask] = text;
					}
					useUnderwayRefuelAndReplenishment2 = useUnderwayRefuelAndReplenishment;
					useUnderwayRefuelAndReplenishment = waypoint.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					string text3 = Misc.UpdateRequest((long)Math.Round(waypoint.Leg_Time_Straight + waypoint.Leg_Time_Turn), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
					if (waypoint.Leg_Time_Weapon <= 0f)
					{
						if (waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd || waypoint.Type == Waypoint.WaypointType.TakeOff)
						{
							text3 = "-";
						}
					}
					else
					{
						text3 = text3 + "（武器：" + Misc.UpdateRequest((long)Math.Round(waypoint.Leg_Time_Weapon), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ")";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_GetterTask]), text3))
					{
						dataRow[m_GetterTask] = text3;
					}
					string text4 = ((flag || waypoint.Type == Waypoint.WaypointType.TakeOff) ? "-" : Misc.UpdateRequest((long)Math.Round(waypoint.Leg_TotalTime), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_ProcTask]), text4))
					{
						dataRow[_ProcTask] = text4;
					}
					string text5 = ((waypoint.Type == Waypoint.WaypointType.HoldEnd || waypoint.Type == Waypoint.WaypointType.StationEnd || waypoint.Type == Waypoint.WaypointType.TakeOff || (int)Math.Round(waypoint.Leg_Distance_Straight + waypoint.Leg_Distance_Turn) == 0) ? "-" : (Conversions.ToString((int)Math.Round(waypoint.Leg_Distance_Straight + waypoint.Leg_Distance_Turn)) + "海里"));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_StructFilter]), text5))
					{
						dataRow[m_StructFilter] = text5;
					}
					if (flag || waypoint.Type == Waypoint.WaypointType.TakeOff)
					{
						text9 = "-";
					}
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_MerchantFilter]), text9))
					{
						dataRow[m_MerchantFilter] = text9;
					}
					string text6 = ((!(waypoint.Hold_Time > 0f) || waypoint.Station_Time != 0f || waypoint.SpacingManeuver_Time != 0f) ? ((waypoint.Hold_Time == 0f && waypoint.Station_Time == 0f && !(waypoint.SpacingManeuver_Time <= 0f)) ? ((waypoint.Separation_Time <= 0f) ? (Misc.UpdateRequest((long)Math.Round(waypoint.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距") : (Misc.UpdateRequest((long)Math.Round(waypoint.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " 90/90, " + Misc.UpdateRequest((long)Math.Round(waypoint.Separation_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "分割")) : ((waypoint.Hold_Time > 0f && waypoint.Station_Time == 0f && !(waypoint.SpacingManeuver_Time <= 0f)) ? (Information.IsNothing(dateTime) ? ("无待命，" + Misc.UpdateRequest((long)Math.Round(waypoint.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距") : (Misc.UpdateRequest((long)Math.Round(waypoint.Hold_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "保持，" + Misc.UpdateRequest((long)Math.Round(waypoint.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距")) : ((waypoint.Hold_Time == 0f && waypoint.Station_Time > 0f && waypoint.SpacingManeuver_Time == 0f) ? (Information.IsNothing(dateTime) ? "N/A" : (Misc.UpdateRequest((long)Math.Round(waypoint.Station_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " 巡逻")) : ((waypoint.Hold_Time != 0f || !(waypoint.Station_Time > 0f) || waypoint.SpacingManeuver_Time <= 0f) ? "-" : (Information.IsNothing(dateTime) ? ("无警戒，" + Misc.UpdateRequest((long)Math.Round(waypoint.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距") : (Misc.UpdateRequest((long)Math.Round(waypoint.Station_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + " 巡逻，" + Misc.UpdateRequest((long)Math.Round(waypoint.SpacingManeuver_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "间距")))))) : (Information.IsNothing(dateTime) ? "N/A" : (Misc.UpdateRequest((long)Math.Round(waypoint.Hold_Time), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "保持")));
					if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[producerTask]), text6))
					{
						dataRow[producerTask] = text6;
					}
					if (waypoint.Type == Waypoint.WaypointType.WeaponTarget)
					{
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_HelperTask]), "-"))
						{
							dataRow[_HelperTask] = "-";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[authenticationTask]), "-"))
						{
							dataRow[authenticationTask] = "-";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ParamsTask]), Waypoint.FixedFree.None))
						{
							dataRow[m_ParamsTask] = Waypoint.FixedFree.None;
						}
					}
					else
					{
						string text7;
						if (!Information.IsNothing(waypoint.DesiredSpeedOverride) && !Information.IsNothing(waypoint.DesiredSpeed))
						{
							float? desiredSpeed;
							float? num5 = (desiredSpeed = waypoint.DesiredSpeed);
							text7 = (num5.HasValue ? Conversions.ToString(desiredSpeed.GetValueOrDefault()) : null) + "节";
						}
						else if (!Information.IsNothing(waypoint.ThrottlePreset) && waypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							ActiveUnit.Throttle throttle_ = (ActiveUnit.Throttle)waypoint.ThrottlePreset;
							text7 = TestPrinter(ref throttle_);
							if (waypoint.DesiredAltitudeOverride && !Information.IsNothing(waypoint.DesiredSpeed))
							{
								string obj = text7;
								float? desiredSpeed2;
								float? num6 = (desiredSpeed2 = waypoint.DesiredSpeed);
								text7 = obj + " (" + (num6.HasValue ? Conversions.ToString(desiredSpeed2.GetValueOrDefault()) : null) + "节）";
							}
						}
						else
						{
							text7 = "速度未设定！";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[authenticationTask]), text7))
						{
							dataRow[authenticationTask] = text7;
						}
						Waypoint.FixedFree speedFixed = waypoint.SpeedFixed;
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[m_ParamsTask]), speedFixed))
						{
							dataRow[m_ParamsTask] = speedFixed;
						}
						string text8 = "";
						if (!Information.IsNothing(waypoint.DesiredAltitudeOverride) && (!Information.IsNothing(waypoint.DesiredAltitude) || (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))))
						{
							if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
							{
								if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									text8 = (((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude_TerrainFollowing * 3.28084f).Value)) + " 英尺 真高"));
								}
								else if (!Information.IsNothing(waypoint.DesiredAltitude))
								{
									text8 = (((int)Math.Round(waypoint.DesiredAltitude.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value)) + " ft ASL"));
								}
							}
							else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
							{
								text8 = (((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value)) + " 米 真高"));
							}
							else if (!Information.IsNothing(waypoint.DesiredAltitude))
							{
								text8 = (((int)Math.Round(waypoint.DesiredAltitude.Value) == 0) ? "Minimum" : (Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value)) + " 米 海高"));
							}
						}
						else if (!Information.IsNothing(waypoint.AltitudePreset) && waypoint.AltitudePreset != 0)
						{
							switch (waypoint.AltitudePreset)
							{
							case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
								text8 = "Minimum";
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
									{
										text8 = Conversions.ToString(305) + " 英尺 真高";
									}
									else if (!Information.IsNothing(waypoint.DesiredAltitude))
									{
										text8 = Conversions.ToString(305) + " ft ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									text8 = Conversions.ToString(305) + " 米 真高";
								}
								else if (!Information.IsNothing(waypoint.DesiredAltitude))
								{
									text8 = Conversions.ToString(305) + " 米 海高";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
									{
										text8 = Conversions.ToString(610) + " 英尺 真高";
									}
									else if (!Information.IsNothing(waypoint.DesiredAltitude))
									{
										text8 = Conversions.ToString(610) + " ft ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									text8 = Conversions.ToString(610) + " 米 真高";
								}
								else if (!Information.IsNothing(waypoint.DesiredAltitude))
								{
									text8 = Conversions.ToString(610) + " 米 海高";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.const_4:
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
									{
										text8 = Conversions.ToString(3658) + " 英尺 真高";
									}
									else if (!Information.IsNothing(waypoint.DesiredAltitude))
									{
										text8 = Conversions.ToString(3658) + " ft ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									text8 = Conversions.ToString(3658) + " 米 真高";
								}
								else if (!Information.IsNothing(waypoint.DesiredAltitude))
								{
									text8 = Conversions.ToString(3658) + " 米 海高";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.const_5:
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
									{
										text8 = Conversions.ToString(7620) + " 英尺 真高";
									}
									else if (!Information.IsNothing(waypoint.DesiredAltitude))
									{
										text8 = Conversions.ToString(7620) + " ft ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									text8 = Conversions.ToString(7620) + " 米 真高";
								}
								else if (!Information.IsNothing(waypoint.DesiredAltitude))
								{
									text8 = Conversions.ToString(7620) + " 米 海高";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.const_6:
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
									{
										text8 = Conversions.ToString(10973) + " 英尺 真高";
									}
									else if (!Information.IsNothing(waypoint.DesiredAltitude))
									{
										text8 = Conversions.ToString(10973) + " ft ASL";
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									text8 = Conversions.ToString(10973) + " 米 真高";
								}
								else if (!Information.IsNothing(waypoint.DesiredAltitude))
								{
									text8 = Conversions.ToString(10973) + " 米 海高";
								}
								break;
							case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
								text8 = "Maximum";
								break;
							}
						}
						else
						{
							text8 = "海拔高度没有设定！";
						}
						if (!object.Equals(RuntimeHelpers.GetObjectValue(dataRow[_HelperTask]), text8))
						{
							dataRow[_HelperTask] = text8;
						}
					}
				}
			}
			finally
			{
				theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.ResumeLayout();
			}
			if (theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows.Count <= 0)
			{
				SelectedWaypoint = null;
				return;
			}
			WaypointList_Refresh = false;
			if (theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.SelectedRows.Count > 0 && theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.SelectedRows[0].Index > 0 && SelectedRow != theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.SelectedRows[0].Index)
			{
				if (SelectedRow <= theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows.Count - 1)
				{
					theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[SelectedRow].Selected = false;
				}
				SelectedRow = theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.SelectedRows[0].Index;
			}
			theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[0].Selected = false;
			if (theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.RowCount > 0)
			{
				if (SelectedRow <= theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.RowCount - 1)
				{
					theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[SelectedRow].Selected = false;
					theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[SelectedRow].Selected = true;
				}
				else
				{
					theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.RowCount - 1].Selected = false;
					theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.Rows[theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.RowCount - 1].Selected = true;
				}
			}
			SelectedWaypoint = (Waypoint)theFlightPlanWaypointsWeapon.DGV_WaypointsWeapon.SelectedRows[0].Tag;
			WaypointList_Refresh = true;
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

	private void ResolvePrinter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Hide();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PostPrinter(object sender, EventArgs e)
	{
	}

	public void RecalculateFlightPlanFuelAndTimes(bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		try
		{
			if (base.Visible && bool_1)
			{
				if (bool_2)
				{
					Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = false;
					if (bool_3)
					{
						VerifyPrinter();
					}
					else
					{
						ListPrinter();
						if (bool_4)
						{
							theFlightPlanWaypointsWeapon.DisplayLocks();
						}
					}
					Client.FlightPlanEditorWeaponRouteWindow.WaypointList_Refresh = true;
				}
				else if (bool_3)
				{
					VerifyPrinter();
				}
				else
				{
					ListPrinter();
					if (bool_4)
					{
						theFlightPlanWaypointsWeapon.DisplayLocks();
					}
				}
			}
			if (bool_0)
			{
				RegistryParameterMessage.AwakeCustomer();
				Client.MustRefreshMainForm = true;
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
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
}
