using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public class AircraftFuelViewModel : PlatFormViewModel
{
	[CompilerGenerated]
	private double bridgeImporter;

	[CompilerGenerated]
	private string m_InvocationImporter;

	private StringBuilder _ClassImporter;

	public double Percentage
	{
		[CompilerGenerated]
		get
		{
			return bridgeImporter;
		}
		[CompilerGenerated]
		set
		{
			if (bridgeImporter != value)
			{
				bridgeImporter = value;
				OnPropertyChanged("Percentage");
			}
		}
	}

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationImporter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_InvocationImporter, value, StringComparison.Ordinal))
			{
				m_InvocationImporter = value;
				OnPropertyChanged("Text");
			}
		}
	}

	[Obsolete("Used for design time only", true)]
	public AircraftFuelViewModel()
	{
		_ClassImporter = new StringBuilder();
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void Refresh()
	{
		try
		{
			base.UnitName = theUnit.Name;
			_ClassImporter.Clear();
			Aircraft aircraft = (Aircraft)theUnit;
			Aircraft_AirOps airOps = aircraft.AirOps;
			ActiveUnit._ActiveUnitFuelState isBingoOrJoker = theUnit.GetIsBingoOrJoker(null, theUnit.Doctrine.GetBingoJoker(theUnit.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false));
			ActiveUnit activeUnit = theUnit;
			double double_ = 0.0;
			double double_2 = 0.0;
			Percentage = (int)Math.Round(activeUnit.FuelPercent(ref double_2, ref double_, bool_0: false) * 100.0);
			float num = aircraft.FuelConsumption(theUnit.ThrottleSetting, null, (int)Math.Round(theUnit.DesiredSpeed), theUnit.GetCurrentAltitude(), bool_1: false, bool_2: false, bool_3: false, bool_4: false, bool_5: false);
			long num2 = ((theUnit.ThrottleSetting != 0) ? aircraft.GetFuelEndurance(theUnit.ThrottleSetting, null, theUnit.CurrentSpeed, theUnit.GetCurrentAltitude()) : (theUnit.Kinematics.GetCurrentAltBand(theUnit.GetCurrentAltitude(), bool_0: false).Speed_Full.HasValue ? aircraft.GetFuelEndurance(ActiveUnit.Throttle.Full, null, theUnit.CurrentSpeed, theUnit.GetCurrentAltitude()) : 0));
			long num3 = ((num == 0f) ? long.MaxValue : (float.IsInfinity(aircraft.FuelState_RemainingFuelToBingo) ? long.MaxValue : ((long)Math.Round(aircraft.FuelState_RemainingFuelToBingo / num))));
			long num4 = ((num == 0f) ? long.MaxValue : (float.IsInfinity(aircraft.FuelState_RemainingFuelToJoker) ? long.MaxValue : ((long)Math.Round(aircraft.FuelState_RemainingFuelToJoker / num))));
			double num5 = Conversions.ToDouble(string.Format("{0:0.0}", double_2 - (double)theUnit.Kinematics.ReserveFuel, 0));
			string value = ((num2 <= 0) ? (string.Format("{0:0.0}", double_2, 0) + "千克燃料") : ((theUnit.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? (string.Format("{0:0.0}", double_2, 0) + "千克燃料，" + Misc.UpdateRequest(num2, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: true)) : (string.Format("{0:0.0}", double_2, 0) + "千克燃料，" + Misc.UpdateRequest(num2, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: true) + ", " + string.Format("{0:0.0}", (float)num2 * theUnit.CurrentSpeed / 3600f, 0) + "海里")));
			string value2 = ((num5 <= 0.0) ? "没有任务燃料剩余，使用储备燃料。" : (Conversions.ToString(num5) + "千克任务燃料，" + string.Format("{0:0.0}", theUnit.Kinematics.ReserveFuel, 0) + "公斤剩余"));
			string value3 = string.Format("{0:0.00}", num * 60f, 1) + " 千克/分钟 燃料消耗";
			Doctrine._FuelState? bingoJoker = aircraft.Doctrine.GetBingoJoker(aircraft.ParentScen, bool_0: false, bool_1: true, bool_2: false, bool_3: false);
			string value4;
			if (airOps.GetAssignedHostUnit() == null)
			{
				value4 = "飞机没有选择基地！";
			}
			else
			{
				byte? b = (byte?)bingoJoker;
				bool? flag;
				bool? flag2 = (flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null));
				bool? flag3 = ((flag2.HasValue && !flag.GetValueOrDefault()) ? new bool?(false) : ((isBingoOrJoker == ActiveUnit._ActiveUnitFuelState.IsBingo) ? new bool?(false) : flag));
				if (flag3.GetValueOrDefault(true) && num3 > 0 && flag3.HasValue)
				{
					value4 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + "公斤Bingo燃料，" + Misc.UpdateRequest(num3, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)num3 * theUnit.CurrentSpeed / 3600f, 0) + "海里";
				}
				else if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker && num4 > 0)
				{
					value4 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToJoker, 0) + "千克Joker燃料，" + Misc.UpdateRequest(num4, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)num4 * theUnit.CurrentSpeed / 3600f, 0) + "海里";
				}
				else
				{
					b = (byte?)bingoJoker;
					value4 = ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? "已达到BINGO燃料！" : ("已达到JOKER燃料！" + string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + "公斤Bingo燃料"));
				}
			}
			string value5 = "";
			if (airOps.GetAssignedHostUnit() == null)
			{
				value5 = "";
			}
			else if (airOps.A2AR_Destination == null)
			{
				if (aircraft.IsGroupWingman())
				{
					if (aircraft.GetParentGroup().GroupLead != null)
					{
						Aircraft_AirOps airOps2 = ((Aircraft)aircraft.GetParentGroup().GroupLead).AirOps;
						value5 = ((airOps2.A2AR_Destination != null) ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + airOps2.A2AR_Destination.Name) : ((aircraft.FuelState_Destination == null) ? "没有选择Bingo燃料目的地。" : (aircraft.FuelState_Destination.IsAircraft ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到基地：" + aircraft.FuelState_Destination.Name))));
					}
				}
				else
				{
					value5 = ((aircraft.FuelState_Destination == null) ? "没有选择Bingo燃料目的地。" : (aircraft.FuelState_Destination.IsAircraft ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到基地：" + aircraft.FuelState_Destination.Name)));
				}
			}
			else
			{
				value5 = string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + "海里到加油机：" + airOps.A2AR_Destination.Name;
			}
			List<Tuple<string, int, float>> fuelByTank = aircraft.FuelByTank;
			string text = "";
			if (fuelByTank.Count > 0)
			{
				foreach (Tuple<string, int, float> item in fuelByTank)
				{
					text = text + "\r\nTank #" + Conversions.ToString(item.Item2) + ": " + string.Format("{0:0}", (int)Math.Round(item.Item3), 0) + " kg remaining fuel";
				}
			}
			_ClassImporter.Append(value).Append("\r\n").Append(value2)
				.Append("\r\n")
				.Append(value3)
				.Append("\r\n")
				.Append(value4)
				.Append("\r\n")
				.Append(value5)
				.Append("\r\n")
				.Append(text);
			Text = _ClassImporter.ToString();
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

	public AircraftFuelViewModel(Aircraft aircraft_0)
	{
		_ClassImporter = new StringBuilder();
		theUnit = aircraft_0;
		Refresh();
	}
}
