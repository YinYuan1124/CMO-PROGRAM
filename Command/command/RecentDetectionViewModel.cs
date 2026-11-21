using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class RecentDetectionViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string parameterUtils;

	[CompilerGenerated]
	private int _ExpressionUtils;

	[CompilerGenerated]
	private string _DispatcherUtils;

	[CompilerGenerated]
	private string m_ListenerUtils;

	[CompilerGenerated]
	private int _ConfigUtils;

	[CompilerGenerated]
	private long m_RegistryUtils;

	[CompilerGenerated]
	private string _DefinitionUtils;

	[CompilerGenerated]
	private string _ValUtils;

	[CompilerGenerated]
	private string wrapperUtils;

	[CompilerGenerated]
	private RelayCommand _ObserverUtils;

	[CompilerGenerated]
	private RelayCommand _IssuerUtils;

	[NonSerialized]
	private PropertyChangedEventHandler clientUtils;

	public string SensorName
	{
		[CompilerGenerated]
		get
		{
			return parameterUtils;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(parameterUtils, value, StringComparison.Ordinal))
			{
				parameterUtils = value;
				OnPropertyChanged("SensorName");
			}
		}
	}

	public int Int32_0
	{
		[CompilerGenerated]
		get
		{
			return _ExpressionUtils;
		}
		[CompilerGenerated]
		set
		{
			if (_ExpressionUtils != value)
			{
				_ExpressionUtils = value;
				OnPropertyChanged("SensorDBID");
			}
		}
	}

	public string PlatformGUID
	{
		[CompilerGenerated]
		get
		{
			return _DispatcherUtils;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_DispatcherUtils, value, StringComparison.Ordinal))
			{
				_DispatcherUtils = value;
				OnPropertyChanged("PlatformGUID");
			}
		}
	}

	public string PlatformName
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerUtils;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_ListenerUtils, value, StringComparison.Ordinal))
			{
				m_ListenerUtils = value;
				OnPropertyChanged("PlatformName");
			}
		}
	}

	public int PlatformDBID
	{
		[CompilerGenerated]
		get
		{
			return _ConfigUtils;
		}
		[CompilerGenerated]
		set
		{
			if (_ConfigUtils != value)
			{
				_ConfigUtils = value;
				OnPropertyChanged("PlatformDBID");
			}
		}
	}

	public long TimeSinceDetection
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryUtils;
		}
		[CompilerGenerated]
		set
		{
			if (m_RegistryUtils != value)
			{
				m_RegistryUtils = value;
				OnPropertyChanged("TimeSinceDetection");
			}
		}
	}

	public string TimeSinceDetection_String
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionUtils;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_DefinitionUtils, value, StringComparison.Ordinal))
			{
				_DefinitionUtils = value;
				OnPropertyChanged("TimeSinceDetection_String");
			}
		}
	}

	public string DetectionRange_String
	{
		[CompilerGenerated]
		get
		{
			return _ValUtils;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ValUtils, value, StringComparison.Ordinal))
			{
				_ValUtils = value;
				OnPropertyChanged("DetectionRange_String");
			}
		}
	}

	public string CoreUnitGUID
	{
		[CompilerGenerated]
		get
		{
			return wrapperUtils;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(wrapperUtils, value, StringComparison.Ordinal))
			{
				wrapperUtils = value;
				OnPropertyChanged("CoreUnitGUID");
			}
		}
	}

	public RelayCommand SensorClickCommand
	{
		[CompilerGenerated]
		get
		{
			return _ObserverUtils;
		}
		[CompilerGenerated]
		set
		{
			if (_ObserverUtils != value)
			{
				_ObserverUtils = value;
				OnPropertyChanged("SensorClickCommand");
			}
		}
	}

	public RelayCommand PlatformClickCommand
	{
		[CompilerGenerated]
		get
		{
			return _IssuerUtils;
		}
		[CompilerGenerated]
		set
		{
			if (_IssuerUtils != value)
			{
				_IssuerUtils = value;
				OnPropertyChanged("PlatformClickCommand");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = clientUtils;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref clientUtils, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = clientUtils;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref clientUtils, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void SensorClick()
	{
		if (string.IsNullOrEmpty(PlatformGUID))
		{
			return;
		}
		ActiveUnit activeUnit = null;
		foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
		{
			if (activeUnits_ != null && Operators.CompareString(activeUnits_.ObjectID, PlatformGUID, TextCompare: true) == 0)
			{
				activeUnit = activeUnits_;
				break;
			}
		}
		if (activeUnit == null && Operators.CompareString(CoreUnitGUID, "", TextCompare: true) != 0)
		{
			foreach (ActiveUnit activeUnits_2 in Client.CurrentScenario.ActiveUnits_List)
			{
				if (activeUnits_2 != null && Operators.CompareString(activeUnits_2.ObjectID, CoreUnitGUID, TextCompare: true) == 0)
				{
					activeUnit = activeUnits_2;
					break;
				}
			}
			if (activeUnit != null)
			{
				if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Int32_0 > 0)
				{
					Client.smethod_1(activeUnit, "Loadout" + Conversions.ToString(((Aircraft)activeUnit).Int32_0));
				}
				else
				{
					Client.smethod_1(activeUnit);
				}
				return;
			}
		}
		if (activeUnit != null)
		{
			Client.smethod_1(activeUnit, "Sensor" + Conversions.ToString(Int32_0));
		}
	}

	public void PlatformClick()
	{
		if (string.IsNullOrEmpty(PlatformGUID))
		{
			return;
		}
		ActiveUnit activeUnit = null;
		foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
		{
			if (activeUnits_ != null && Operators.CompareString(activeUnits_.ObjectID, PlatformGUID, TextCompare: true) == 0)
			{
				activeUnit = activeUnits_;
				break;
			}
		}
		if (activeUnit == null && Operators.CompareString(CoreUnitGUID, "", TextCompare: true) != 0)
		{
			foreach (ActiveUnit activeUnits_2 in Client.CurrentScenario.ActiveUnits_List)
			{
				if (activeUnits_2 != null && Operators.CompareString(activeUnits_2.ObjectID, CoreUnitGUID, TextCompare: true) == 0)
				{
					activeUnit = activeUnits_2;
					break;
				}
			}
			if (activeUnit != null)
			{
				if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Int32_0 > 0)
				{
					Client.smethod_1(activeUnit, "Loadout" + Conversions.ToString(((Aircraft)activeUnit).Int32_0));
				}
				else
				{
					Client.smethod_1(activeUnit);
				}
				return;
			}
		}
		if (activeUnit != null)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
			Client.SelectThisUnit(activeUnit, bool_0: true);
		}
	}

	public RecentDetectionViewModel()
	{
		SensorClickCommand = new RelayCommand(delegate
		{
			SensorClick();
		});
		PlatformClickCommand = new RelayCommand(delegate
		{
			PlatformClick();
		});
	}

	public void OnPropertyChanged(string string_0)
	{
		clientUtils?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void ConcatInterruptibleStatus(object object_0)
	{
		SensorClick();
	}

	[CompilerGenerated]
	private void InterruptInterruptibleStatus(object object_0)
	{
		PlatformClick();
	}
}
