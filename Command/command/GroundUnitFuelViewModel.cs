using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public class GroundUnitFuelViewModel : PlatFormViewModel
{
	[CompilerGenerated]
	private double m_CandidateTests;

	[CompilerGenerated]
	private string _BaseTests;

	public double Percentage
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateTests;
		}
		[CompilerGenerated]
		set
		{
			if (m_CandidateTests != value)
			{
				m_CandidateTests = value;
				OnPropertyChanged("Percentage");
			}
		}
	}

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return _BaseTests;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_BaseTests, value, StringComparison.Ordinal))
			{
				_BaseTests = value;
				OnPropertyChanged("Text");
			}
		}
	}

	[Obsolete("Used for design time only", true)]
	public GroundUnitFuelViewModel()
	{
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void Refresh()
	{
		base.UnitName = theUnit.Name;
		double double_ = 0.0;
		double double_2 = 0.0;
		Percentage = (int)Math.Round(theUnit.FuelPercent(ref double_, ref double_2, bool_0: false) * 100.0);
		long fuelEndurance = ((Vehicle)theUnit).GetFuelEndurance(theUnit.ThrottleSetting, null, (int)Math.Round(theUnit.DesiredSpeed), 0f);
		HashSet<string> hashSet = new HashSet<string>();
		string text = "";
		foreach (FuelRec item in theUnit.Fuel_ReadOnly)
		{
			hashSet.Add(item.FuelType.ToString());
		}
		if (hashSet.Count > 0)
		{
			text = " (" + string.Join(", ", hashSet.ToArray()) + ")";
			if (hashSet.Count > 1)
			{
				text = "\r\n" + text;
			}
		}
		string text2 = Conversions.ToString(Math.Round(double_, 0)) + "燃料单元剩余";
		if (!string.IsNullOrEmpty(text))
		{
			text2 += text;
		}
		string text3 = ((theUnit.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? "单元完全停止" : (Misc.UpdateRequest(fuelEndurance, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + Conversions.ToString(Math.Round((float)fuelEndurance * theUnit.CurrentSpeed / 3600f, 0)) + "海里"));
		Text = text2 + "\r\n" + text3;
	}

	public GroundUnitFuelViewModel(Vehicle vehicle_0)
	{
		theUnit = vehicle_0;
		Refresh();
	}
}
