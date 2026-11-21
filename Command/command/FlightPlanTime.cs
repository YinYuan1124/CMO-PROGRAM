using System;
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
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanTime : DarkSecondaryFormBase
{
	private IContainer _ValFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_Date")]
	private DarkMaskedTextBox m_WrapperFilter;

	[AccessedThroughProperty("DateTimePicker_Time")]
	[CompilerGenerated]
	private DarkMaskedTextBox _ObserverFilter;

	[AccessedThroughProperty("DateTimePicker_Hold")]
	[CompilerGenerated]
	private DarkMaskedTextBox issuerFilter;

	[AccessedThroughProperty("DateTimePicker_Spacing")]
	[CompilerGenerated]
	private DarkMaskedTextBox clientFilter;

	[AccessedThroughProperty("DateTimePicker_Station")]
	[CompilerGenerated]
	private DarkMaskedTextBox _DicFilter;

	[AccessedThroughProperty("ComboBox_AttackMethod")]
	[CompilerGenerated]
	private DarkUIComboBox _ConsumerFilter;

	[AccessedThroughProperty("DateTimePicker_Separation")]
	[CompilerGenerated]
	private DarkMaskedTextBox facadeFilter;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_ProxyFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel m_ImporterFilter;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel m_InvocationFilter;

	public Waypoint SelectedWaypoint;

	public Mission.Flight SelectedFlight;

	public Mission SelectedMission;

	public Mission.Flight.FlightElement FlightElement;

	public bool ViaFlightPlanEditor;

	private bool _ClassFilter;

	internal DarkMaskedTextBox DateTimePicker_Date
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunParser;
			EventHandler value3 = StartParser;
			KeyPressEventHandler value4 = DefineParser;
			DarkMaskedTextBox wrapperFilter = m_WrapperFilter;
			if (wrapperFilter != null)
			{
				wrapperFilter.Enter -= value2;
				wrapperFilter.Leave -= value3;
				wrapperFilter.KeyPress -= value4;
			}
			m_WrapperFilter = value;
			wrapperFilter = m_WrapperFilter;
			if (wrapperFilter != null)
			{
				wrapperFilter.Enter += value2;
				wrapperFilter.Leave += value3;
				wrapperFilter.KeyPress += value4;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_Time
	{
		[CompilerGenerated]
		get
		{
			return _ObserverFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareParser;
			EventHandler value3 = ReflectParser;
			KeyPressEventHandler value4 = PublishParser;
			DarkMaskedTextBox observerFilter = _ObserverFilter;
			if (observerFilter != null)
			{
				observerFilter.Enter -= value2;
				observerFilter.Leave -= value3;
				observerFilter.KeyPress -= value4;
			}
			_ObserverFilter = value;
			observerFilter = _ObserverFilter;
			if (observerFilter != null)
			{
				observerFilter.Enter += value2;
				observerFilter.Leave += value3;
				observerFilter.KeyPress += value4;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_Hold
	{
		[CompilerGenerated]
		get
		{
			return issuerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitParser;
			EventHandler value3 = RestartParser;
			KeyPressEventHandler value4 = AwakeParser;
			DarkMaskedTextBox darkMaskedTextBox = issuerFilter;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter -= value2;
				darkMaskedTextBox.Leave -= value3;
				darkMaskedTextBox.KeyPress -= value4;
			}
			issuerFilter = value;
			darkMaskedTextBox = issuerFilter;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter += value2;
				darkMaskedTextBox.Leave += value3;
				darkMaskedTextBox.KeyPress += value4;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_Spacing
	{
		[CompilerGenerated]
		get
		{
			return clientFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelParser;
			EventHandler value3 = VerifyParser;
			KeyPressEventHandler value4 = QueryParser;
			DarkMaskedTextBox darkMaskedTextBox = clientFilter;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter -= value2;
				darkMaskedTextBox.Leave -= value3;
				darkMaskedTextBox.KeyPress -= value4;
			}
			clientFilter = value;
			darkMaskedTextBox = clientFilter;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter += value2;
				darkMaskedTextBox.Leave += value3;
				darkMaskedTextBox.KeyPress += value4;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_Station
	{
		[CompilerGenerated]
		get
		{
			return _DicFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestParser;
			EventHandler value3 = StopParser;
			KeyPressEventHandler value4 = ResetParser;
			DarkMaskedTextBox dicFilter = _DicFilter;
			if (dicFilter != null)
			{
				dicFilter.Enter -= value2;
				dicFilter.Leave -= value3;
				dicFilter.KeyPress -= value4;
			}
			_DicFilter = value;
			dicFilter = _DicFilter;
			if (dicFilter != null)
			{
				dicFilter.Enter += value2;
				dicFilter.Leave += value3;
				dicFilter.KeyPress += value4;
			}
		}
	}

	internal DarkUIComboBox ComboBox_AttackMethod
	{
		[CompilerGenerated]
		get
		{
			return _ConsumerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateParser;
			DarkUIComboBox consumerFilter = _ConsumerFilter;
			if (consumerFilter != null)
			{
				consumerFilter.SelectionChangeCommitted -= value2;
			}
			_ConsumerFilter = value;
			consumerFilter = _ConsumerFilter;
			if (consumerFilter != null)
			{
				consumerFilter.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_Separation
	{
		[CompilerGenerated]
		get
		{
			return facadeFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListParser;
			EventHandler value3 = ResolveParser;
			KeyPressEventHandler value4 = MapParser;
			DarkMaskedTextBox darkMaskedTextBox = facadeFilter;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter -= value2;
				darkMaskedTextBox.Leave -= value3;
				darkMaskedTextBox.KeyPress -= value4;
			}
			facadeFilter = value;
			darkMaskedTextBox = facadeFilter;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter += value2;
				darkMaskedTextBox.Leave += value3;
				darkMaskedTextBox.KeyPress += value4;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProxyFilter = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_ImporterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ImporterFilter = value;
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
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

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationFilter = value;
		}
	}

	public FlightPlanTime()
	{
		base.Load += DisableParser;
		base.KeyDown += SortParser;
		base.FormClosing += CalcParser;
		_ClassFilter = false;
		CompareParser();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ValFilter != null)
			{
				_ValFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CompareParser()
	{
		Label7 = new DarkLabel();
		DateTimePicker_Separation = new DarkMaskedTextBox();
		Label6 = new DarkLabel();
		ComboBox_AttackMethod = new DarkUIComboBox();
		Label5 = new DarkLabel();
		DateTimePicker_Station = new DarkMaskedTextBox();
		Label4 = new DarkLabel();
		DateTimePicker_Spacing = new DarkMaskedTextBox();
		Label3 = new DarkLabel();
		DateTimePicker_Hold = new DarkMaskedTextBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		DateTimePicker_Time = new DarkMaskedTextBox();
		DateTimePicker_Date = new DarkMaskedTextBox();
		SuspendLayout();
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(13, 172);
		Label7.Name = "Label7";
		Label7.Size = new Size(107, 15);
		Label7.TabIndex = 22;
		Label7.Text = "飞机分离：";
		DateTimePicker_Separation.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_Separation.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_Separation.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker_Separation.Location = new Point(198, 168);
		DateTimePicker_Separation.Name = "DateTimePicker_Separation";
		DateTimePicker_Separation.Size = new Size(115, 23);
		DateTimePicker_Separation.TabIndex = 21;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(323, 175);
		Label6.Name = "Label6";
		Label6.Size = new Size(52, 15);
		Label6.TabIndex = 20;
		Label6.Text = "方法：";
		ComboBox_AttackMethod.BackColor = Color.Transparent;
		ComboBox_AttackMethod.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_AttackMethod.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_AttackMethod.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_AttackMethod.FormattingEnabled = true;
		ComboBox_AttackMethod.Location = new Point(381, 169);
		ComboBox_AttackMethod.Name = "ComboBox_AttackMethod";
		ComboBox_AttackMethod.Size = new Size(121, 21);
		ComboBox_AttackMethod.TabIndex = 19;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(13, 120);
		Label5.Name = "Label5";
		Label5.Size = new Size(95, 15);
		Label5.TabIndex = 18;
		Label5.Text = "巡逻时长：";
		DateTimePicker_Station.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_Station.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_Station.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker_Station.Location = new Point(198, 116);
		DateTimePicker_Station.Name = "DateTimePicker_Station";
		DateTimePicker_Station.Size = new Size(115, 23);
		DateTimePicker_Station.TabIndex = 17;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(13, 146);
		Label4.Name = "Label4";
		Label4.Size = new Size(139, 15);
		Label4.TabIndex = 16;
		Label4.Text = "间距机动延迟：";
		DateTimePicker_Spacing.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_Spacing.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_Spacing.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker_Spacing.Location = new Point(198, 142);
		DateTimePicker_Spacing.Name = "DateTimePicker_Spacing";
		DateTimePicker_Spacing.Size = new Size(115, 23);
		DateTimePicker_Spacing.TabIndex = 15;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(13, 95);
		Label3.Name = "Label3";
		Label3.Size = new Size(84, 15);
		Label3.TabIndex = 14;
		Label3.Text = "保持时间：";
		DateTimePicker_Hold.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_Hold.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_Hold.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker_Hold.Location = new Point(198, 91);
		DateTimePicker_Hold.Name = "DateTimePicker_Hold";
		DateTimePicker_Hold.Size = new Size(115, 23);
		DateTimePicker_Hold.TabIndex = 13;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(13, 37);
		Label1.Name = "Label1";
		Label1.Size = new Size(119, 15);
		Label1.TabIndex = 12;
		Label1.Text = "日期和时间（祖鲁）：";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(13, 13);
		Label2.Name = "Label2";
		Label2.Size = new Size(41, 13);
		Label2.TabIndex = 10;
		Label2.Text = "Label2";
		DateTimePicker_Time.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_Time.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_Time.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker_Time.Location = new Point(198, 61);
		DateTimePicker_Time.Name = "DateTimePicker_Time";
		DateTimePicker_Time.Size = new Size(115, 23);
		DateTimePicker_Time.TabIndex = 3;
		DateTimePicker_Date.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_Date.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_Date.ForeColor = Color.FromArgb(220, 220, 220);
		DateTimePicker_Date.Location = new Point(198, 37);
		DateTimePicker_Date.Name = "DateTimePicker_Date";
		DateTimePicker_Date.Size = new Size(115, 23);
		DateTimePicker_Date.TabIndex = 2;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(541, 205);
		base.Controls.Add(Label7);
		base.Controls.Add(DateTimePicker_Separation);
		base.Controls.Add(Label6);
		base.Controls.Add(ComboBox_AttackMethod);
		base.Controls.Add(Label5);
		base.Controls.Add(DateTimePicker_Station);
		base.Controls.Add(Label4);
		base.Controls.Add(DateTimePicker_Spacing);
		base.Controls.Add(Label3);
		base.Controls.Add(DateTimePicker_Hold);
		base.Controls.Add(Label1);
		base.Controls.Add(Label2);
		base.Controls.Add(DateTimePicker_Time);
		base.Controls.Add(DateTimePicker_Date);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(557, 244);
		base.Name = "FlightPlanTime";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "航点时间";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ReadParser()
	{
		if (Information.IsNothing(SelectedFlight))
		{
			Label2.Text = "没有编队选择！";
			Client.FlightPlanTimeWindow.Text = "编队路径点时间";
			return;
		}
		if (Information.IsNothing(SelectedWaypoint))
		{
			Label2.Text = "没有选择航点！";
			Client.FlightPlanTimeWindow.Text = "编队路径点时间";
			return;
		}
		if (SelectedWaypoint.Time_Zulu.HasValue)
		{
			if (SelectedFlight.GetIsActive(SelectedFlight.GetAUCurrentlyAssigned(SelectedMission, Client.CurrentScenario)))
			{
				Label2.Text = "任务已经激活（开始时间：" + SelectedWaypoint.Time_Zulu.Value.ToShortDateString() + " - " + SelectedWaypoint.Time_Zulu.Value.ToLongTimeString() + " Zulu)";
			}
			else
			{
				Label2.Text = "正在计划任务。";
			}
		}
		else
		{
			Label2.Text = "任务没有设定航点时间。";
		}
		Text = "航点时间" + SelectedFlight.Callsign + "， 航点" + SelectedWaypoint.Description + " (" + Waypoint.GetWaypointTypeString(SelectedWaypoint.Type) + ")";
	}

	private void DisableParser(object sender, EventArgs e)
	{
		_ClassFilter = false;
		DateTimePicker_Date.Enabled = true;
		DateTimePicker_Time.Enabled = true;
		_ClassFilter = true;
	}

	public void RefreshStats(ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, Mission.Flight.FlightElement flightElement_0, bool bool_0)
	{
		try
		{
			if (bool_0 && _ClassFilter)
			{
				_ClassFilter = false;
				Mission mission_ = null;
				Mission.Flight flight_ = null;
				Waypoint waypoint_ = null;
				PrintParser(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None);
			}
			if (!Information.IsNothing(mission_0))
			{
				SelectedMission = mission_0;
			}
			if (!Information.IsNothing(flight_0))
			{
				SelectedFlight = flight_0;
			}
			if (!Information.IsNothing(waypoint_0))
			{
				SelectedWaypoint = waypoint_0;
			}
			if (flightElement_0 != 0)
			{
				FlightElement = flightElement_0;
			}
			ReadParser();
			if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight) || Information.IsNothing(SelectedWaypoint))
			{
				return;
			}
			if (SelectedFlight.Type == Mission._FlightType.FlightplanTemplate)
			{
				DateTime dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
				DateTimePicker_Date.Enabled = false;
				dateTime = new DateTime(2000, 1, 1, 0, 0, 0);
				DateTimePicker_Time.Enabled = false;
				string string_ = null;
				GameGeneral.PaddedTimeString(ref dateTime, ref string_);
				string string_10 = null;
				GameGeneral.PaddedDateString(ref dateTime, ref string_10, bool_1: false);
				DateTimePicker_Date.Text = string_10;
				DateTimePicker_Time.Text = string_;
			}
			else if (SelectedWaypoint.Time_Zulu_Weapon.HasValue && SelectedWaypoint.Leg_Time_Weapon > 0f)
			{
				DateTime dateTime_ = SelectedWaypoint.Time_Zulu_Weapon.Value;
				string string_11 = null;
				GameGeneral.PaddedTimeString(ref dateTime_, ref string_11);
				string string_12 = null;
				GameGeneral.PaddedDateString(ref dateTime_, ref string_12, bool_1: false);
				DateTimePicker_Date.Text = string_12;
				DateTimePicker_Time.Text = string_11;
			}
			else if (SelectedWaypoint.Time_Zulu.HasValue)
			{
				DateTime dateTime_2 = SelectedWaypoint.Time_Zulu.Value;
				string string_13 = null;
				GameGeneral.PaddedTimeString(ref dateTime_2, ref string_13);
				string string_14 = null;
				GameGeneral.PaddedDateString(ref dateTime_2, ref string_14, bool_1: false);
				DateTimePicker_Date.Text = string_14;
				DateTimePicker_Time.Text = string_13;
			}
			else
			{
				DateTime dateTime_3 = Client.CurrentScenario.StartTime;
				string string_15 = null;
				GameGeneral.PaddedTimeString(ref dateTime_3, ref string_15);
				string string_16 = null;
				GameGeneral.PaddedDateString(ref dateTime_3, ref string_16, bool_1: false);
				DateTimePicker_Date.Text = string_16;
				DateTimePicker_Time.Text = string_15;
			}
			if (SelectedFlight.Type != Mission._FlightType.FlightplanTemplate && (SelectedWaypoint.Type == Waypoint.WaypointType.Assemble || SelectedWaypoint.Type == Waypoint.WaypointType.HoldEnd))
			{
				DateTime dateTime2 = new DateTime(2000, 1, 1, 0, 0, 1);
				DateTimePicker_Hold.Enabled = true;
				dateTime2 = dateTime2.AddSeconds(SelectedWaypoint.Hold_Time - 1f);
				string string_17 = null;
				GameGeneral.PaddedTimeString(ref dateTime2, ref string_17);
				DateTimePicker_Hold.Text = string_17;
			}
			else
			{
				DateTime dateTime_4 = new DateTime(2000, 1, 1, 0, 0, 0);
				DateTimePicker_Hold.Enabled = false;
				string string_2 = null;
				GameGeneral.PaddedTimeString(ref dateTime_4, ref string_2);
				DateTimePicker_Hold.Text = string_2;
			}
			if (SelectedWaypoint.Type == Waypoint.WaypointType.StationEnd)
			{
				DateTime dateTime3 = new DateTime(2000, 1, 1, 0, 0, 1);
				DateTimePicker_Station.Enabled = true;
				dateTime3 = dateTime3.AddSeconds(SelectedWaypoint.Station_Time - 1f);
				string string_3 = null;
				GameGeneral.PaddedTimeString(ref dateTime3, ref string_3);
				DateTimePicker_Station.Text = string_3;
			}
			else
			{
				DateTime dateTime_5 = new DateTime(2000, 1, 1, 0, 0, 0);
				DateTimePicker_Station.Enabled = false;
				string string_4 = null;
				GameGeneral.PaddedTimeString(ref dateTime_5, ref string_4);
				DateTimePicker_Station.Text = string_4;
			}
			if (SelectedFlight.Type != Mission._FlightType.FlightplanTemplate && !SelectedWaypoint.IncludeReponse() && SelectedWaypoint.Type != Waypoint.WaypointType.TakeOff && SelectedWaypoint.Type != Waypoint.WaypointType.Land && SelectedWaypoint.Type != Waypoint.WaypointType.LandingMarshal && !SelectedWaypoint.ConcatReponse())
			{
				DateTime dateTime4 = new DateTime(2000, 1, 1, 0, 0, 1);
				if (UpdateParser())
				{
					DataTable dataTable_ = new DataTable();
					DarkUIComboBox darkUIComboBox_ = ComboBox_AttackMethod;
					MissionEditor.BindComboBox_AttackMethod(ref darkUIComboBox_, ref dataTable_, SelectedWaypoint.AttackMethod);
					ComboBox_AttackMethod = darkUIComboBox_;
					ComboBox_AttackMethod.Enabled = true;
				}
				else
				{
					ComboBox_AttackMethod.DataSource = null;
					ComboBox_AttackMethod.Items.Clear();
					ComboBox_AttackMethod.Enabled = false;
				}
				if (InsertParser())
				{
					DateTimePicker_Separation.Enabled = true;
					DateTime dateTime_6 = dateTime4.AddSeconds(SelectedWaypoint.Separation_Time - 1f);
					string string_5 = null;
					GameGeneral.PaddedTimeString(ref dateTime_6, ref string_5);
					DateTimePicker_Separation.Text = string_5;
				}
				else
				{
					DateTime dateTime_7 = new DateTime(2000, 1, 1, 0, 0, 0);
					DateTimePicker_Separation.Enabled = false;
					string string_6 = null;
					GameGeneral.PaddedTimeString(ref dateTime_7, ref string_6);
					DateTimePicker_Separation.Text = string_6;
				}
				DateTimePicker_Spacing.Enabled = true;
				DateTime dateTime_8 = dateTime4.AddSeconds(SelectedWaypoint.SpacingManeuver_Time - 1f);
				string string_7 = null;
				GameGeneral.PaddedTimeString(ref dateTime_8, ref string_7);
				DateTimePicker_Spacing.Text = string_7;
			}
			else
			{
				DateTime dateTime_9 = new DateTime(2000, 1, 1, 0, 0, 0);
				DateTimePicker_Spacing.Enabled = false;
				DateTimePicker_Separation.Enabled = false;
				ComboBox_AttackMethod.DataSource = null;
				ComboBox_AttackMethod.Items.Clear();
				ComboBox_AttackMethod.Enabled = false;
				string string_8 = null;
				GameGeneral.PaddedTimeString(ref dateTime_9, ref string_8);
				string string_9 = null;
				GameGeneral.PaddedTimeString(ref dateTime_9, ref string_9);
				DateTimePicker_Spacing.Text = string_8;
				DateTimePicker_Separation.Text = string_9;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101344", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool UpdateParser()
	{
		try
		{
			if (Information.IsNothing(SelectedWaypoint))
			{
				return false;
			}
			if (SelectedWaypoint.Type == Waypoint.WaypointType.Target && !SelectedWaypoint.InvokeReponse() && !SelectedWaypoint.SetupReponse())
			{
				if (!Information.IsNothing(SelectedFlight) && SelectedFlight.FlightPlan.Count() > 0)
				{
					Waypoint[] flightPlan = SelectedFlight.FlightPlan;
					Waypoint[] array = flightPlan;
					foreach (Waypoint waypoint in array)
					{
						if (waypoint != SelectedWaypoint)
						{
							if (Information.IsNothing(waypoint.Waypoint_LeadElementWingman) || waypoint.Waypoint_LeadElementWingman != SelectedWaypoint)
							{
								if (Information.IsNothing(waypoint.Waypoint_SecondElement) || waypoint.Waypoint_SecondElement != SelectedWaypoint)
								{
									if (Information.IsNothing(waypoint.Waypoint_SecondElementWingman) || waypoint.Waypoint_SecondElementWingman != SelectedWaypoint)
									{
										if (Information.IsNothing(waypoint.Waypoint_ThirdElement) || waypoint.Waypoint_ThirdElement != SelectedWaypoint)
										{
											if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman) && waypoint.Waypoint_ThirdElementWingman == SelectedWaypoint)
											{
												return false;
											}
											continue;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return true;
					}
				}
				return true;
			}
			return false;
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
			return false;
		}
	}

	private bool InsertParser()
	{
		try
		{
			if (SelectedWaypoint.Type != Waypoint.WaypointType.Target && SelectedWaypoint.Type != Waypoint.WaypointType.WeaponTarget)
			{
				return false;
			}
			if (!SelectedWaypoint.InvokeReponse() && SelectedWaypoint.AttackMethod != Mission._AttackMethod.EchelonAtActionPoint && SelectedWaypoint.AttackMethod != Mission._AttackMethod.SplitAtActionPoint)
			{
				return false;
			}
			if (!Information.IsNothing(SelectedFlight) && SelectedFlight.FlightPlan.Count() > 0)
			{
				Waypoint[] flightPlan = SelectedFlight.FlightPlan;
				Waypoint[] array = flightPlan;
				foreach (Waypoint waypoint in array)
				{
					if (Information.IsNothing(waypoint.Waypoint_LeadElementWingman) || waypoint.Waypoint_LeadElementWingman != SelectedWaypoint)
					{
						if (Information.IsNothing(waypoint.Waypoint_SecondElement) || waypoint.Waypoint_SecondElement != SelectedWaypoint)
						{
							if (Information.IsNothing(waypoint.Waypoint_SecondElementWingman) || waypoint.Waypoint_SecondElementWingman != SelectedWaypoint)
							{
								if (Information.IsNothing(waypoint.Waypoint_ThirdElement) || waypoint.Waypoint_ThirdElement != SelectedWaypoint)
								{
									if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman) && waypoint.Waypoint_ThirdElementWingman == SelectedWaypoint)
									{
										return false;
									}
									continue;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
			}
			return true;
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
			return false;
		}
	}

	private void PrepareParser(object sender, EventArgs e)
	{
		_ClassFilter = true;
	}

	private void ReflectParser(object sender, EventArgs e)
	{
		PostParser();
	}

	private void VisitParser(object sender, EventArgs e)
	{
		_ClassFilter = true;
	}

	private void RestartParser(object sender, EventArgs e)
	{
		PostParser();
	}

	private void TestParser(object sender, EventArgs e)
	{
		_ClassFilter = true;
	}

	private void StopParser(object sender, EventArgs e)
	{
		PostParser();
	}

	private void CancelParser(object sender, EventArgs e)
	{
		_ClassFilter = true;
	}

	private void VerifyParser(object sender, EventArgs e)
	{
		PostParser();
	}

	private void ListParser(object sender, EventArgs e)
	{
		_ClassFilter = true;
	}

	private void ResolveParser(object sender, EventArgs e)
	{
		PostParser();
	}

	private void PostParser()
	{
		if (_ClassFilter)
		{
			_ClassFilter = false;
			Mission mission_ = null;
			Mission.Flight flight_ = null;
			Waypoint waypoint_ = null;
			PrintParser(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None);
		}
	}

	private void RunParser(object sender, EventArgs e)
	{
		_ClassFilter = true;
	}

	private void StartParser(object sender, EventArgs e)
	{
		AssetParser();
	}

	private void AssetParser()
	{
		if (_ClassFilter)
		{
			_ClassFilter = false;
			Mission mission_ = null;
			Mission.Flight flight_ = null;
			Waypoint waypoint_ = null;
			PrintParser(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None);
		}
	}

	private void PrintParser(ref Mission mission_0, ref Mission.Flight flight_0, ref Waypoint waypoint_0, Mission.Flight.FlightElement flightElement_0)
	{
		try
		{
			Waypoint[] waypoint_;
			Mission.Flight selectedFlight2;
			if (SelectedFlight.Type == Mission._FlightType.FlightplanTemplate)
			{
				DateTime dateTime = new DateTime(2000, 1, 1, 0, 0, 1);
				List<string> list = DateTimePicker_Station.Text.Split(':').ToList();
				if (!(Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2])))
				{
					return;
				}
				double a = Math.Abs((new DateTime(2000, 1, 1, Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2])) - dateTime).TotalSeconds + 1.0);
				if (SelectedWaypoint.Type == Waypoint.WaypointType.StationEnd)
				{
					SelectedWaypoint.Station_Time = (long)Math.Round(a);
				}
			}
			else
			{
				if (!Information.IsNothing(mission_0))
				{
					SelectedMission = mission_0;
				}
				if (!Information.IsNothing(flight_0))
				{
					SelectedFlight = flight_0;
				}
				if (!Information.IsNothing(waypoint_0))
				{
					SelectedWaypoint = waypoint_0;
				}
				if (flightElement_0 != 0)
				{
					FlightElement = flightElement_0;
				}
				List<string> list2 = DateTimePicker_Time.Text.Split(':').ToList();
				if (!(Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1]) & Versioned.IsNumeric(list2[2])))
				{
					return;
				}
				List<string> list3 = DateTimePicker_Date.Text.Split('-').ToList();
				if (!(Versioned.IsNumeric(list3[0]) & Versioned.IsNumeric(list3[1]) & Versioned.IsNumeric(list3[2])))
				{
					return;
				}
				DateTime dateTime2 = new DateTime(Conversions.ToInteger(list3[0]), Conversions.ToInteger(list3[1]), Conversions.ToInteger(list3[2]), Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]));
				DateTime t = (Information.IsNothing(SelectedWaypoint.Time_Zulu) ? new DateTime(Client.CurrentScenario.StartTime.Year, Client.CurrentScenario.StartTime.Month, Client.CurrentScenario.StartTime.Day, Client.CurrentScenario.StartTime.Hour, Client.CurrentScenario.StartTime.Minute, Client.CurrentScenario.StartTime.Second) : new DateTime(SelectedWaypoint.Time_Zulu.Value.Year, SelectedWaypoint.Time_Zulu.Value.Month, SelectedWaypoint.Time_Zulu.Value.Day, SelectedWaypoint.Time_Zulu.Value.Hour, SelectedWaypoint.Time_Zulu.Value.Minute, SelectedWaypoint.Time_Zulu.Value.Second));
				DateTime t2 = (Information.IsNothing(SelectedWaypoint.Time_Zulu_Weapon) ? new DateTime(Client.CurrentScenario.StartTime.Year, Client.CurrentScenario.StartTime.Month, Client.CurrentScenario.StartTime.Day, Client.CurrentScenario.StartTime.Hour, Client.CurrentScenario.StartTime.Minute, Client.CurrentScenario.StartTime.Second) : new DateTime(SelectedWaypoint.Time_Zulu_Weapon.Value.Year, SelectedWaypoint.Time_Zulu_Weapon.Value.Month, SelectedWaypoint.Time_Zulu_Weapon.Value.Day, SelectedWaypoint.Time_Zulu_Weapon.Value.Hour, SelectedWaypoint.Time_Zulu_Weapon.Value.Minute, SelectedWaypoint.Time_Zulu_Weapon.Value.Second));
				DateTime dateTime3 = new DateTime(2000, 1, 1, 0, 0, 1);
				List<string> list4 = DateTimePicker_Hold.Text.Split(':').ToList();
				if (!(Versioned.IsNumeric(list4[0]) & Versioned.IsNumeric(list4[1]) & Versioned.IsNumeric(list4[2])))
				{
					return;
				}
				double num = Math.Abs((new DateTime(2000, 1, 1, Conversions.ToInteger(list4[0]), Conversions.ToInteger(list4[1]), Conversions.ToInteger(list4[2])) - dateTime3).TotalSeconds + 1.0);
				List<string> list5 = DateTimePicker_Station.Text.Split(':').ToList();
				if (!(Versioned.IsNumeric(list5[0]) & Versioned.IsNumeric(list5[1]) & Versioned.IsNumeric(list5[2])))
				{
					return;
				}
				double num2 = Math.Abs((new DateTime(2000, 1, 1, Conversions.ToInteger(list5[0]), Conversions.ToInteger(list5[1]), Conversions.ToInteger(list5[2])) - dateTime3).TotalSeconds + 1.0);
				List<string> list6 = DateTimePicker_Spacing.Text.Split(':').ToList();
				if (!(Versioned.IsNumeric(list6[0]) & Versioned.IsNumeric(list6[1]) & Versioned.IsNumeric(list6[2])))
				{
					return;
				}
				double num3 = Math.Abs((new DateTime(2000, 1, 1, Conversions.ToInteger(list6[0]), Conversions.ToInteger(list6[1]), Conversions.ToInteger(list6[2])) - dateTime3).TotalSeconds + 1.0);
				List<string> list7 = DateTimePicker_Separation.Text.Split(':').ToList();
				if (!(Versioned.IsNumeric(list7[0]) & Versioned.IsNumeric(list7[1]) & Versioned.IsNumeric(list7[2])))
				{
					return;
				}
				double num4 = Math.Abs((new DateTime(2000, 1, 1, Conversions.ToInteger(list7[0]), Conversions.ToInteger(list7[1]), Conversions.ToInteger(list7[2])) - dateTime3).TotalSeconds + 1.0);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				int num5 = SelectedFlight.FlightPlan.Count();
				if (SelectedWaypoint.Leg_Time_Weapon <= 0f)
				{
					if (DateTime.Compare(t, dateTime2) != 0)
					{
						flag = true;
					}
				}
				else if (DateTime.Compare(t2, dateTime2) != 0 && (dateTime2.Year != Client.CurrentScenario.StartTime.Year || dateTime2.Month != Client.CurrentScenario.StartTime.Month || dateTime2.Day != Client.CurrentScenario.StartTime.Day || dateTime2.Hour != Client.CurrentScenario.StartTime.Hour || dateTime2.Minute != Client.CurrentScenario.StartTime.Minute || dateTime2.Second != Client.CurrentScenario.StartTime.Second))
				{
					flag = true;
				}
				if ((double)SelectedWaypoint.Hold_Time != num)
				{
					flag2 = true;
					if (Information.IsNothing(SelectedWaypoint.Time_Zulu))
					{
						flag = true;
					}
				}
				if ((double)SelectedWaypoint.Station_Time != num2)
				{
					flag3 = true;
					if (Information.IsNothing(SelectedWaypoint.Time_Zulu))
					{
						flag = true;
					}
				}
				if ((double)SelectedWaypoint.SpacingManeuver_Time != num3)
				{
					flag4 = true;
				}
				if ((double)SelectedWaypoint.Separation_Time != num4)
				{
					flag5 = true;
				}
				if (!(flag || flag2 || flag3 || flag4 || flag5))
				{
					return;
				}
				if (flag5)
				{
					SelectedWaypoint.Separation_Time = (long)Math.Round(num4);
				}
				if (flag)
				{
					if (SelectedWaypoint.Leg_Time_Weapon <= 0f)
					{
						SelectedWaypoint.Time_Zulu = dateTime2;
						SelectedWaypoint.Time_Zulu_Weapon = null;
						SelectedWaypoint.TimeFixed = Waypoint.FixedFree.Fixed;
					}
					else
					{
						SelectedWaypoint.Time_Zulu = dateTime2.AddSeconds(0f - SelectedWaypoint.Leg_Time_Weapon);
						SelectedWaypoint.Time_Zulu_Weapon = dateTime2;
						SelectedWaypoint.TimeFixed = Waypoint.FixedFree.Fixed;
					}
					if (!flag3 && SelectedWaypoint.Type == Waypoint.WaypointType.StationEnd)
					{
						int num6 = num5 - 1;
						Waypoint waypoint = null;
						Waypoint waypoint2 = null;
						for (int i = 0; i <= num6; i++)
						{
							waypoint = SelectedFlight.FlightPlan[i];
							if (!Information.IsNothing(waypoint))
							{
								if (waypoint == SelectedWaypoint)
								{
									break;
								}
								if (waypoint.SearchReponse())
								{
									waypoint2 = waypoint;
								}
							}
						}
						if (!Information.IsNothing(waypoint2) && !Information.IsNothing(waypoint2.Time_Zulu) && !Information.IsNothing(waypoint.Time_Zulu.Value))
						{
							double a2 = Math.Max((SelectedWaypoint.Time_Zulu.Value - waypoint2.Time_Zulu.Value).TotalSeconds, 0.0);
							SelectedWaypoint.Station_Time = (long)Math.Round(a2);
						}
						else
						{
							Interaction.MsgBox("在设置祖鲁时间之前，将站末端航点指定为警戒时间。");
						}
					}
					if (SelectedWaypoint.CheckReponse() && Information.IsNothing(SelectedWaypoint.Time_Zulu))
					{
						SelectedWaypoint.Time_Zulu = dateTime2;
					}
					Mission.Flight selectedFlight = SelectedFlight;
					ref Waypoint selectedWaypoint = ref SelectedWaypoint;
					ref Mission selectedMission = ref SelectedMission;
					waypoint_ = (selectedFlight2 = SelectedFlight).FlightPlan;
					AirTaskingOrder.UpdateWingmanWaypoints(selectedFlight, ref selectedWaypoint, ref selectedMission, ref waypoint_, FlightElement);
					selectedFlight2.FlightPlan = waypoint_;
					if (SelectedWaypoint.FlightFormation != Waypoint.Formation.Split)
					{
						if (!Information.IsNothing(SelectedWaypoint.Waypoint_LeadElementWingman))
						{
							SelectedWaypoint.Waypoint_LeadElementWingman.Time_Zulu = SelectedWaypoint.Time_Zulu;
							SelectedWaypoint.Waypoint_LeadElementWingman.Time_Zulu_Weapon = SelectedWaypoint.Time_Zulu_Weapon;
							SelectedWaypoint.Waypoint_LeadElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
						}
						if (!Information.IsNothing(SelectedWaypoint.Waypoint_SecondElement))
						{
							SelectedWaypoint.Waypoint_SecondElement.Time_Zulu = SelectedWaypoint.Time_Zulu;
							SelectedWaypoint.Waypoint_SecondElement.Time_Zulu_Weapon = SelectedWaypoint.Time_Zulu_Weapon;
							SelectedWaypoint.Waypoint_SecondElement.TimeFixed = Waypoint.FixedFree.Fixed;
						}
						if (!Information.IsNothing(SelectedWaypoint.Waypoint_SecondElementWingman))
						{
							SelectedWaypoint.Waypoint_SecondElementWingman.Time_Zulu = SelectedWaypoint.Time_Zulu;
							SelectedWaypoint.Waypoint_SecondElementWingman.Time_Zulu_Weapon = SelectedWaypoint.Time_Zulu_Weapon;
							SelectedWaypoint.Waypoint_SecondElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
						}
						if (!Information.IsNothing(SelectedWaypoint.Waypoint_ThirdElement))
						{
							SelectedWaypoint.Waypoint_ThirdElement.Time_Zulu = SelectedWaypoint.Time_Zulu;
							SelectedWaypoint.Waypoint_ThirdElement.Time_Zulu_Weapon = SelectedWaypoint.Time_Zulu_Weapon;
							SelectedWaypoint.Waypoint_ThirdElement.TimeFixed = Waypoint.FixedFree.Fixed;
						}
						if (!Information.IsNothing(SelectedWaypoint.Waypoint_ThirdElementWingman))
						{
							SelectedWaypoint.Waypoint_ThirdElementWingman.Time_Zulu = SelectedWaypoint.Time_Zulu;
							SelectedWaypoint.Waypoint_ThirdElementWingman.Time_Zulu_Weapon = SelectedWaypoint.Time_Zulu_Weapon;
							SelectedWaypoint.Waypoint_ThirdElementWingman.TimeFixed = Waypoint.FixedFree.Fixed;
						}
					}
				}
				else if (flag5)
				{
					Mission.Flight selectedFlight3 = SelectedFlight;
					ref Waypoint selectedWaypoint2 = ref SelectedWaypoint;
					ref Mission selectedMission2 = ref SelectedMission;
					waypoint_ = (selectedFlight2 = SelectedFlight).FlightPlan;
					AirTaskingOrder.UpdateWingmanWaypoints(selectedFlight3, ref selectedWaypoint2, ref selectedMission2, ref waypoint_, FlightElement);
					selectedFlight2.FlightPlan = waypoint_;
				}
				if (flag2 && (SelectedWaypoint.Type == Waypoint.WaypointType.Assemble || SelectedWaypoint.Type == Waypoint.WaypointType.HoldEnd) && !Information.IsNothing(SelectedWaypoint.Time_Zulu))
				{
					SelectedWaypoint.Hold_Time = (long)Math.Round(num);
				}
				if (flag3 && SelectedWaypoint.Type == Waypoint.WaypointType.StationEnd && !Information.IsNothing(SelectedWaypoint.Time_Zulu))
				{
					SelectedWaypoint.Station_Time = (long)Math.Round(num2);
				}
				if (flag4)
				{
					SelectedWaypoint.SpacingManeuver_Time = (long)Math.Round(num3);
				}
				if (flag5)
				{
					SelectedWaypoint.Separation_Time = (long)Math.Round(num4);
					Mission.Flight selectedFlight4 = SelectedFlight;
					ref Waypoint selectedWaypoint3 = ref SelectedWaypoint;
					ref Mission selectedMission3 = ref SelectedMission;
					waypoint_ = (selectedFlight2 = SelectedFlight).FlightPlan;
					AirTaskingOrder.UpdateWingmanWaypoints(selectedFlight4, ref selectedWaypoint3, ref selectedMission3, ref waypoint_, FlightElement);
					selectedFlight2.FlightPlan = waypoint_;
				}
				if (flag2 || flag3)
				{
					int num7 = num5 - 1;
					for (int j = 0; j <= num7; j++)
					{
						Waypoint waypoint3 = SelectedFlight.FlightPlan[j];
						if (!Information.IsNothing(waypoint3) && waypoint3.TimeFixed != Waypoint.FixedFree.Fixed && Information.IsNothing(waypoint3.Time_Zulu))
						{
							waypoint3.Time_Zulu = dateTime2;
						}
					}
				}
			}
			Scenario currentScenario = Client.CurrentScenario;
			Mission selectedMission4 = SelectedMission;
			ActiveUnit referenceUnit = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight selectedFlight5 = SelectedFlight;
			waypoint_ = (selectedFlight2 = SelectedFlight).FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, selectedMission4, referenceUnit, selectedFlight5, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			selectedFlight2.FlightPlan = waypoint_;
			RegistryParameterMessage.AwakeCustomer();
			if (Client.FlightPlanEditorWindow.Visible)
			{
				if (Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.SelectedRows.Count > 0)
				{
					Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
					Client.FlightPlanEditorWindow.SelectedRow = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.SelectedRows[0].Index;
					Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows[Client.FlightPlanEditorWindow.SelectedRow].Tag;
					Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows[0].Selected = false;
					Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
				}
				Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
				Client.FlightPlanEditorWindow.InvokePolicy();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			Mission mission_ = null;
			selectedFlight2 = null;
			Waypoint waypoint_2 = null;
			RefreshStats(ref mission_, ref selectedFlight2, ref waypoint_2, Mission.Flight.FlightElement.None, bool_0: true);
			Client.MustRefreshMainForm = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101345", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DefineParser(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void PublishParser(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void AwakeParser(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void QueryParser(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void ResetParser(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void MapParser(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void SortParser(object sender, KeyEventArgs e)
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

	private void CalcParser(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		if (DateTimePicker_Date.Focused)
		{
			AssetParser();
		}
		if (DateTimePicker_Time.Focused)
		{
			PostParser();
		}
		if (DateTimePicker_Hold.Focused)
		{
			PostParser();
		}
		if (DateTimePicker_Spacing.Focused)
		{
			PostParser();
		}
		if (DateTimePicker_Separation.Focused)
		{
			PostParser();
		}
		Label2.Select();
		Hide();
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshMissions();
		}
		if (Client.AirTaskingOrderWindow.Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void RateParser(object sender, EventArgs e)
	{
		DarkUIComboBox comboBox_AttackMethod = ComboBox_AttackMethod;
		int int_ = comboBox_AttackMethod.SelectedIndex;
		Mission.Flight.Combobox_AttackMethod(ref int_, ref SelectedWaypoint.AttackMethod);
		comboBox_AttackMethod.SelectedIndex = int_;
		Scenario currentScenario = Client.CurrentScenario;
		Mission selectedMission = SelectedMission;
		ActiveUnit referenceUnit = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
		Mission.Flight selectedFlight = SelectedFlight;
		Mission.Flight selectedFlight2;
		Waypoint[] waypoint_ = (selectedFlight2 = SelectedFlight).FlightPlan;
		float float_ = 0f;
		float float_2 = 0f;
		MissionPlanner.ConnectTokenizer(currentScenario, selectedMission, referenceUnit, selectedFlight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
		selectedFlight2.FlightPlan = waypoint_;
		RegistryParameterMessage.AwakeCustomer();
		if (Client.FlightPlanEditorWindow.Visible)
		{
			if (Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.SelectedRows.Count > 0)
			{
				Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
				Client.FlightPlanEditorWindow.SelectedRow = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.SelectedRows[0].Index;
				Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows[Client.FlightPlanEditorWindow.SelectedRow].Tag;
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows[0].Selected = false;
				Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
			}
			Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
			Client.FlightPlanEditorWindow.InvokePolicy();
			Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
		}
		if (Client.AirTaskingOrderWindow.Visible)
		{
			Client.AirTaskingOrderWindow.LoadWindow();
		}
		Mission mission_ = null;
		selectedFlight2 = null;
		Waypoint waypoint_2 = null;
		RefreshStats(ref mission_, ref selectedFlight2, ref waypoint_2, Mission.Flight.FlightElement.None, bool_0: true);
		Client.MustRefreshMainForm = true;
	}
}
