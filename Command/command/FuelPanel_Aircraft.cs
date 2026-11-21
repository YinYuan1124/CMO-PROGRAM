using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanel_Aircraft : DarkUserControl
{
	private IContainer testsTests;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel interpreterTests;

	[AccessedThroughProperty("Splitter1")]
	[CompilerGenerated]
	private Splitter m_ComposerTests;

	private int ActualWidth;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return interpreterTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interpreterTests = value;
		}
	}

	[field: AccessedThroughProperty("ProgressBar1")]
	internal DarkUIProgressBar ProgressBar1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Splitter Splitter1
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerTests = value;
		}
	}

	[field: AccessedThroughProperty("LblAirborneTime")]
	internal DarkLabel LblAirborneTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public FuelPanel_Aircraft()
	{
		base.Load += ResolveProduct;
		ListProduct();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && testsTests != null)
			{
				testsTests.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ListProduct()
	{
		Label1 = new DarkLabel();
		ProgressBar1 = new DarkUIProgressBar();
		Splitter1 = new Splitter();
		LblAirborneTime = new DarkLabel();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(3, 26);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 2;
		Label1.Text = "Label1";
		ProgressBar1.BackColor = Color.Transparent;
		ProgressBar1.CustomForeColor = Color.Transparent;
		ProgressBar1.Location = new Point(0, 0);
		ProgressBar1.Maximum = 100;
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.ShowProgressLines = true;
		ProgressBar1.ShowProgressValue = true;
		ProgressBar1.ShowText = false;
		ProgressBar1.Size = new Size(231, 23);
		ProgressBar1.TabIndex = 1;
		ProgressBar1.Value = 0;
		Splitter1.Dock = DockStyle.Bottom;
		Splitter1.Location = new Point(0, 100);
		Splitter1.Name = "Splitter1";
		Splitter1.Size = new Size(232, 25);
		Splitter1.TabIndex = 3;
		Splitter1.TabStop = false;
		LblAirborneTime.AutoSize = true;
		LblAirborneTime.ForeColor = Color.FromArgb(220, 220, 220);
		LblAirborneTime.Location = new Point(3, 107);
		LblAirborneTime.Name = "LblAirborneTime";
		LblAirborneTime.Size = new Size(62, 13);
		LblAirborneTime.TabIndex = 4;
		LblAirborneTime.Text = "DarkLabel1";
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(LblAirborneTime);
		base.Controls.Add(Splitter1);
		base.Controls.Add(Label1);
		base.Controls.Add(ProgressBar1);
		base.Margin = new Padding(0);
		base.Name = "FuelPanel_Aircraft";
		base.Size = new Size(232, 125);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void RefreshPanel(ActiveUnit activeUnit_0)
	{
		try
		{
			if (Client._StateClass != 1f)
			{
				if (ActualWidth == 0)
				{
					ActualWidth = base.Width;
				}
				if (ActualWidth == base.Width)
				{
					base.Width = (int)Math.Round((float)base.Width * Client._StateClass);
				}
			}
			if (!activeUnit_0.IsAircraft)
			{
				return;
			}
			Aircraft aircraft = (Aircraft)activeUnit_0;
			Aircraft_AirOps airOps = aircraft.AirOps;
			ActiveUnit._ActiveUnitFuelState isBingoOrJoker = activeUnit_0.GetIsBingoOrJoker(null, activeUnit_0.Doctrine.GetBingoJoker(activeUnit_0.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
			DarkUIProgressBar progressBar = ProgressBar1;
			double double_ = 0.0;
			double double_2 = 0.0;
			progressBar.Value = (int)Math.Round(activeUnit_0.FuelPercent(ref double_2, ref double_, bool_0: false) * 100.0);
			ActiveUnit.Throttle throttle_ = ((!aircraft.GetCanHover(bool_1: false) || activeUnit_0.DesiredSpeed >= (float)activeUnit_0.Kinematics.GetMaximumSpeed(activeUnit_0.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false)) ? activeUnit_0.ThrottleSetting : (activeUnit_0.Kinematics.CanApplyFlankThrottle() ? ActiveUnit.Throttle.Flank : ActiveUnit.Throttle.Full));
			float num = aircraft.FuelConsumption(activeUnit_0.ThrottleSetting, null, (int)Math.Round(activeUnit_0.DesiredSpeed), activeUnit_0.GetCurrentAltitude(), bool_1: false, bool_2: false, bool_3: false, bool_4: false, bool_5: false);
			long fuelEndurance = aircraft.GetFuelEndurance(throttle_, null, activeUnit_0.CurrentSpeed, activeUnit_0.GetCurrentAltitude());
			long num2 = ((num == 0f) ? long.MaxValue : ((long)Math.Round(aircraft.FuelState_RemainingFuelToBingo / num)));
			long num3 = ((num == 0f) ? long.MaxValue : ((long)Math.Round(aircraft.FuelState_RemainingFuelToJoker / num)));
			double num4 = double_2 - (double)activeUnit_0.Kinematics.ReserveFuel;
			string text = string.Format("{0:0.0}", double_2, 0) + "千克燃料，" + Misc.UpdateRequest(fuelEndurance, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: true) + ", " + string.Format("{0:0.0}", (float)fuelEndurance * activeUnit_0.CurrentSpeed / 3600f, 0) + "海里";
			string text2 = ((num4 <= 0.0) ? "没有任务燃料剩余，使用储备燃料。" : ($"{num4:1} kg mission fuel, " + string.Format("{0:0.0}", activeUnit_0.Kinematics.ReserveFuel, 0) + "公斤剩余"));
			string text3 = string.Format("{0:0.00}", num * 60f, 1) + " 千克/分钟 燃料消耗";
			Doctrine._FuelState? bingoJoker = aircraft.Doctrine.GetBingoJoker(aircraft.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			string text4;
			if (Information.IsNothing(airOps.GetAssignedHostUnit()))
			{
				text4 = "飞机没有选择基地！";
			}
			else
			{
				byte? b = (byte?)bingoJoker;
				bool? flag;
				bool? flag2 = (flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null));
				bool? flag3 = ((flag2.HasValue && !flag.GetValueOrDefault()) ? new bool?(false) : ((isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo) ? new bool?(false) : flag));
				if (flag3.GetValueOrDefault(true) && num2 > 0 && flag3.HasValue)
				{
					text4 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + "公斤Bingo燃料，" + Misc.UpdateRequest(num2, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)num2 * activeUnit_0.CurrentSpeed / 3600f, 0) + "海里";
				}
				else if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker && num3 > 0)
				{
					text4 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToJoker, 0) + "千克Joker燃料，" + Misc.UpdateRequest(num3, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)num3 * activeUnit_0.CurrentSpeed / 3600f, 0) + "海里";
				}
				else
				{
					b = (byte?)bingoJoker;
					text4 = ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? "已达到BINGO燃料！" : ("已达到JOKER燃料！" + string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + "公斤Bingo燃料"));
				}
			}
			string text5 = null;
			if (Information.IsNothing(airOps.GetAssignedHostUnit()))
			{
				text5 = "";
			}
			else if (Information.IsNothing(airOps.A2AR_Destination))
			{
				if (aircraft.IsGroupWingman())
				{
					if (!Information.IsNothing(aircraft.GetParentGroup().GroupLead))
					{
						Aircraft_AirOps airOps2 = ((Aircraft)aircraft.GetParentGroup().GroupLead).AirOps;
						text5 = ((!Information.IsNothing(airOps2.A2AR_Destination)) ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + airOps2.A2AR_Destination.Name) : (Information.IsNothing(aircraft.FuelState_Destination) ? "没有选择Bingo燃料目的地。" : (aircraft.FuelState_Destination.IsAircraft ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到基地：" + aircraft.FuelState_Destination.Name))));
					}
				}
				else
				{
					text5 = (Information.IsNothing(aircraft.FuelState_Destination) ? "没有选择Bingo燃料目的地。" : (aircraft.FuelState_Destination.IsAircraft ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到基地：" + aircraft.FuelState_Destination.Name)));
				}
			}
			else
			{
				text5 = string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + airOps.A2AR_Destination.Name;
			}
			if (aircraft.AirborneTime <= 0f)
			{
				LblAirborneTime.Visible = false;
			}
			else
			{
				LblAirborneTime.Visible = true;
				string text6 = Misc.UpdateRequest((long)Math.Round(aircraft.AirborneTime), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true);
				if (aircraft.MAX_Exhaustion == float.MaxValue)
				{
					LblAirborneTime.ForeColor = Color.White;
					LblAirborneTime.Text = text6 + " 飞行时间";
				}
				else
				{
					float current_Exhaustion = ((Aircraft)activeUnit_0).Current_Exhaustion;
					float mAX_Exhaustion = ((Aircraft)activeUnit_0).MAX_Exhaustion;
					float num5 = current_Exhaustion * 100f / mAX_Exhaustion;
					if (num5 >= 0.7f && num5 <= 1f)
					{
						LblAirborneTime.ForeColor = Color.LightGreen;
					}
					else if (num5 >= 0.5f && num5 <= 0.7f)
					{
						LblAirborneTime.ForeColor = Color.Lime;
					}
					else if (num5 >= 0.3f && num5 <= 0.5f)
					{
						LblAirborneTime.ForeColor = Color.Yellow;
					}
					else if (num5 >= 0.1f && num5 <= 0.3f)
					{
						LblAirborneTime.ForeColor = Color.Orange;
					}
					else if (num5 >= 0f && num5 <= 0.1f)
					{
						LblAirborneTime.ForeColor = Color.Red;
					}
					LblAirborneTime.Text = "飞行时间：" + text6 + " / " + Misc.UpdateRequest((long)Math.Round(mAX_Exhaustion));
				}
			}
			_ = aircraft.FuelByTank;
			Label1.Text = text + "\r\n" + text2 + "\r\n" + text3 + "\r\n" + text4 + "\r\n" + text5;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200118", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ResolveProduct(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
