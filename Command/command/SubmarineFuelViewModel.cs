using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public class SubmarineFuelViewModel : PlatFormViewModel
{
	[CompilerGenerated]
	private Visibility visitorException;

	[CompilerGenerated]
	private double _ExporterException;

	[CompilerGenerated]
	private string m_PrototypeException;

	[CompilerGenerated]
	private FontWeight _ComparatorException;

	[CompilerGenerated]
	private Visibility m_ItemException;

	[CompilerGenerated]
	private double _SetterException;

	[CompilerGenerated]
	private string _CreatorException;

	[CompilerGenerated]
	private FontWeight _TemplateException;

	[CompilerGenerated]
	private Visibility _MappingException;

	[CompilerGenerated]
	private double _MockException;

	[CompilerGenerated]
	private string m_TagException;

	[CompilerGenerated]
	private FontWeight m_FieldException;

	[CompilerGenerated]
	private string queueException;

	[CompilerGenerated]
	private double m_RegException;

	public Visibility VisibilityDiesel
	{
		[CompilerGenerated]
		get
		{
			return visitorException;
		}
		[CompilerGenerated]
		set
		{
			if (visitorException != value)
			{
				visitorException = value;
				OnPropertyChanged("VisibilityDiesel");
			}
		}
	}

	public double PercentageDiesel
	{
		[CompilerGenerated]
		get
		{
			return _ExporterException;
		}
		[CompilerGenerated]
		set
		{
			if (_ExporterException != value)
			{
				_ExporterException = value;
				OnPropertyChanged("PercentageDiesel");
			}
		}
	}

	public string PercentageDieselText
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeException;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_PrototypeException, value, StringComparison.Ordinal))
			{
				m_PrototypeException = value;
				OnPropertyChanged("PercentageDieselText");
			}
		}
	}

	public FontWeight FontWeightDiesel
	{
		[CompilerGenerated]
		get
		{
			return _ComparatorException;
		}
		[CompilerGenerated]
		set
		{
			if (_ComparatorException != value)
			{
				_ComparatorException = value;
				OnPropertyChanged("FontWeightDiesel");
			}
		}
	}

	public Visibility VisibilityBattery
	{
		[CompilerGenerated]
		get
		{
			return m_ItemException;
		}
		[CompilerGenerated]
		set
		{
			if (m_ItemException != value)
			{
				m_ItemException = value;
				OnPropertyChanged("VisibilityBattery");
			}
		}
	}

	public double PercentageBattery
	{
		[CompilerGenerated]
		get
		{
			return _SetterException;
		}
		[CompilerGenerated]
		set
		{
			if (_SetterException != value)
			{
				_SetterException = value;
				OnPropertyChanged("PercentageBattery");
			}
		}
	}

	public string PercentageBatteryText
	{
		[CompilerGenerated]
		get
		{
			return _CreatorException;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_CreatorException, value, StringComparison.Ordinal))
			{
				_CreatorException = value;
				OnPropertyChanged("PercentageBatteryText");
			}
		}
	}

	public FontWeight FontWeightBattery
	{
		[CompilerGenerated]
		get
		{
			return _TemplateException;
		}
		[CompilerGenerated]
		set
		{
			if (_TemplateException != value)
			{
				_TemplateException = value;
				OnPropertyChanged("FontWeightBattery");
			}
		}
	}

	public Visibility VisibilityAIP
	{
		[CompilerGenerated]
		get
		{
			return _MappingException;
		}
		[CompilerGenerated]
		set
		{
			if (_MappingException != value)
			{
				_MappingException = value;
				OnPropertyChanged("VisibilityAIP");
			}
		}
	}

	public double PercentageAIP
	{
		[CompilerGenerated]
		get
		{
			return _MockException;
		}
		[CompilerGenerated]
		set
		{
			if (_MockException != value)
			{
				_MockException = value;
				OnPropertyChanged("PercentageAIP");
			}
		}
	}

	public string PercentageAIPText
	{
		[CompilerGenerated]
		get
		{
			return m_TagException;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_TagException, value, StringComparison.Ordinal))
			{
				m_TagException = value;
				OnPropertyChanged("PercentageAIPText");
			}
		}
	}

	public FontWeight FontWeightAIP
	{
		[CompilerGenerated]
		get
		{
			return m_FieldException;
		}
		[CompilerGenerated]
		set
		{
			if (m_FieldException != value)
			{
				m_FieldException = value;
				OnPropertyChanged("FontWeightAIP");
			}
		}
	}

	public string EnduranceText
	{
		[CompilerGenerated]
		get
		{
			return queueException;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(queueException, value, StringComparison.Ordinal))
			{
				queueException = value;
				OnPropertyChanged("EnduranceText");
			}
		}
	}

	public double Percentage
	{
		[CompilerGenerated]
		get
		{
			return m_RegException;
		}
		[CompilerGenerated]
		set
		{
			if (m_RegException != value)
			{
				m_RegException = value;
				OnPropertyChanged("Percentage");
			}
		}
	}

	[Obsolete("Used for design time only", true)]
	public SubmarineFuelViewModel()
	{
	}

	[DoNotObfuscate]
	[DoNotPrune]
	public void Refresh()
	{
		base.UnitName = theUnit.Name;
		if (theUnit.Fuel_ReadOnly.Count == 0)
		{
			return;
		}
		Submarine submarine = (Submarine)theUnit;
		if (submarine.IsNuke)
		{
			VisibilityDiesel = Visibility.Collapsed;
			VisibilityBattery = Visibility.Collapsed;
			VisibilityAIP = Visibility.Collapsed;
			return;
		}
		VisibilityDiesel = Visibility.Hidden;
		FuelRec fuelRec = theUnit.Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.DieselFuel).ElementAtOrDefault(0);
		if (fuelRec != null)
		{
			PercentageDiesel = (int)Math.Round(fuelRec.PercentFull * 100f);
			PercentageDieselText = string.Format("{0:0.0}", fuelRec.CurrentQuantity, 0) + "燃料单元剩余";
			VisibilityDiesel = Visibility.Visible;
		}
		VisibilityBattery = Visibility.Visible;
		FuelRec fuelRec2 = theUnit.Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
		if (fuelRec2 != null)
		{
			PercentageBattery = (int)Math.Round(fuelRec2.PercentFull * 100f);
			PercentageBatteryText = string.Format("{0:0.0}", fuelRec2.CurrentQuantity, 0) + "燃料单元剩余";
		}
		if (submarine.IsAIP)
		{
			VisibilityAIP = Visibility.Visible;
			FuelRec fuelRec3 = theUnit.Fuel_ReadOnly.Where((FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.AirIndepedent).ElementAtOrDefault(0);
			PercentageAIP = (int)Math.Round(fuelRec3.PercentFull * 100f);
			PercentageAIPText = string.Format("{0:0.0}", fuelRec3.CurrentQuantity, 0) + "燃料单元剩余";
		}
		else
		{
			VisibilityAIP = Visibility.Collapsed;
		}
		FontWeightDiesel = FontWeights.Normal;
		FontWeightAIP = FontWeights.Normal;
		FontWeightBattery = FontWeights.Normal;
		foreach (Engine value in submarine.SelectedEngines.Values)
		{
			switch (submarine.AI.SelectFuelTypeToConsume(value))
			{
			case FuelRec._FuelType.AirIndepedent:
				FontWeightAIP = FontWeights.Bold;
				Percentage = PercentageAIP;
				break;
			case FuelRec._FuelType.Battery:
				FontWeightBattery = FontWeights.Bold;
				Percentage = PercentageBattery;
				break;
			case FuelRec._FuelType.DieselFuel:
				FontWeightDiesel = FontWeights.Bold;
				Percentage = PercentageDiesel;
				break;
			}
		}
		long fuelEndurance = submarine.GetFuelEndurance(theUnit.ThrottleSetting, null, (int)Math.Round(theUnit.DesiredSpeed), theUnit.GetCurrentAltitude(), submarine.PrimaryEngine, submarine.PrimaryEngineNo);
		string text = ((theUnit.ThrottleSetting == ActiveUnit.Throttle.FullStop) ? "单元完全停止" : (Misc.UpdateRequest(fuelEndurance, Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + ", " + string.Format("{0:0.0}", (float)fuelEndurance * theUnit.CurrentSpeed / 3600f, 0) + "海里"));
		EnduranceText = "续航：" + text;
	}

	public SubmarineFuelViewModel(Submarine submarine_0)
	{
		theUnit = submarine_0;
		Refresh();
	}
}
