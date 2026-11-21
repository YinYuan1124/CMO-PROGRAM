using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public class SupplyFacilityUnitFuelViewModel : PlatFormViewModel
{
	[CompilerGenerated]
	private double paramException;

	[CompilerGenerated]
	private string m_PageException;

	public double Percentage
	{
		[CompilerGenerated]
		get
		{
			return paramException;
		}
		[CompilerGenerated]
		set
		{
			if (paramException != value)
			{
				paramException = value;
				OnPropertyChanged("Percentage");
			}
		}
	}

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return m_PageException;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_PageException, value, StringComparison.Ordinal))
			{
				m_PageException = value;
				OnPropertyChanged("Text");
			}
		}
	}

	[Obsolete("Used for design time only", true)]
	public SupplyFacilityUnitFuelViewModel()
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
		Text = text2;
	}

	public SupplyFacilityUnitFuelViewModel(Facility facility_0)
	{
		theUnit = facility_0;
		Refresh();
	}
}
