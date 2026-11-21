using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public class ShipFuelViewModel : PlatFormViewModel
{
	[CompilerGenerated]
	private double m_RegSingleton;

	[CompilerGenerated]
	private string _ParamSingleton;

	public double Percentage
	{
		[CompilerGenerated]
		get
		{
			return m_RegSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (m_RegSingleton != value)
			{
				m_RegSingleton = value;
				OnPropertyChanged("Percentage");
			}
		}
	}

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return _ParamSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ParamSingleton, value, StringComparison.Ordinal))
			{
				_ParamSingleton = value;
				OnPropertyChanged("Text");
			}
		}
	}

	[Obsolete("Used for design time only", true)]
	public ShipFuelViewModel()
	{
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void Refresh()
	{
		base.UnitName = theUnit.Name;
		double double_ = 0.0;
		double double_2 = 0.0;
		Percentage = (int)Math.Round(theUnit.FuelPercent(ref double_, ref double_2, bool_0: false) * 100.0);
		long fuelEndurance = ((Ship)theUnit).GetFuelEndurance(theUnit.ThrottleSetting, null, (int)Math.Round(theUnit.DesiredSpeed), 0f);
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
		string text2 = string.Format("{0:0.0}", double_, 0) + "燃料单元剩余";
		if (!string.IsNullOrEmpty(text))
		{
			text2 += text;
		}
		string text3 = ((theUnit.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? "单元完全停止" : (Misc.UpdateRequest(fuelEndurance, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)fuelEndurance * theUnit.CurrentSpeed / 3600f, 0) + "海里"));
		Text = text2 + "\r\n" + text3;
	}

	public ShipFuelViewModel(Ship ship_0)
	{
		theUnit = ship_0;
		Refresh();
	}
}
