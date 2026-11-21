using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class HoverInfoTemplateSelector : DataTemplateSelector, INotifyPropertyChanged
{
	[CompilerGenerated]
	private DataTemplate importerInterpreter;

	[CompilerGenerated]
	private DataTemplate _RepositoryInterpreter;

	[CompilerGenerated]
	private DataTemplate m_BridgeInterpreter;

	[CompilerGenerated]
	private DataTemplate _InvocationInterpreter;

	[CompilerGenerated]
	private DataTemplate m_ClassInterpreter;

	[CompilerGenerated]
	private DataTemplate _RequestInterpreter;

	[CompilerGenerated]
	private DataTemplate m_ValueInterpreter;

	[CompilerGenerated]
	private DataTemplate tokenizerInterpreter;

	[CompilerGenerated]
	private DataTemplate m_StubInterpreter;

	[CompilerGenerated]
	private DataTemplate _WriterInterpreter;

	[CompilerGenerated]
	private DataTemplate specificationInterpreter;

	[CompilerGenerated]
	private DataTemplate watcherInterpreter;

	[NonSerialized]
	private PropertyChangedEventHandler m_ReponseInterpreter;

	public DataTemplate ShipTemplate
	{
		[CompilerGenerated]
		get
		{
			return importerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (importerInterpreter != value)
			{
				importerInterpreter = value;
				OnPropertyChanged("ShipTemplate");
			}
		}
	}

	public DataTemplate SubTemplate
	{
		[CompilerGenerated]
		get
		{
			return _RepositoryInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_RepositoryInterpreter != value)
			{
				_RepositoryInterpreter = value;
				OnPropertyChanged("SubTemplate");
			}
		}
	}

	public DataTemplate AircraftTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_BridgeInterpreter != value)
			{
				m_BridgeInterpreter = value;
				OnPropertyChanged("AircraftTemplate");
			}
		}
	}

	public DataTemplate GroundUnitTemplate
	{
		[CompilerGenerated]
		get
		{
			return _InvocationInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_InvocationInterpreter != value)
			{
				_InvocationInterpreter = value;
				OnPropertyChanged("GroundUnitTemplate");
			}
		}
	}

	public DataTemplate SatelliteTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_ClassInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ClassInterpreter != value)
			{
				m_ClassInterpreter = value;
				OnPropertyChanged("SatelliteTemplate");
			}
		}
	}

	public DataTemplate WeaponTemplate
	{
		[CompilerGenerated]
		get
		{
			return _RequestInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_RequestInterpreter != value)
			{
				_RequestInterpreter = value;
				OnPropertyChanged("WeaponTemplate");
			}
		}
	}

	public DataTemplate AirbaseTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_ValueInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ValueInterpreter != value)
			{
				m_ValueInterpreter = value;
				OnPropertyChanged("AirbaseTemplate");
			}
		}
	}

	public DataTemplate GroundGroupTemplate
	{
		[CompilerGenerated]
		get
		{
			return tokenizerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (tokenizerInterpreter != value)
			{
				tokenizerInterpreter = value;
				OnPropertyChanged("GroundGroupTemplate");
			}
		}
	}

	public DataTemplate NavalGroupTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_StubInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_StubInterpreter != value)
			{
				m_StubInterpreter = value;
				OnPropertyChanged("NavalGroupTemplate");
			}
		}
	}

	public DataTemplate AirGroupTemplate
	{
		[CompilerGenerated]
		get
		{
			return _WriterInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_WriterInterpreter != value)
			{
				_WriterInterpreter = value;
				OnPropertyChanged("AirGroupTemplate");
			}
		}
	}

	public DataTemplate ContactTemplate
	{
		[CompilerGenerated]
		get
		{
			return specificationInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (specificationInterpreter != value)
			{
				specificationInterpreter = value;
				OnPropertyChanged("ContactTemplate");
			}
		}
	}

	public DataTemplate FallbackTemplate
	{
		[CompilerGenerated]
		get
		{
			return watcherInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (watcherInterpreter != value)
			{
				watcherInterpreter = value;
				OnPropertyChanged("FallbackTemplate");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ReponseInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ReponseInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ReponseInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ReponseInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public override DataTemplate SelectTemplate(object item, DependencyObject container)
	{
		HoverInfoViewModel hoverInfoViewModel = (HoverInfoViewModel)item;
		if (hoverInfoViewModel.Unit is Contact)
		{
			return ContactTemplate;
		}
		if (hoverInfoViewModel.Unit is Weapon)
		{
			return WeaponTemplate;
		}
		if (hoverInfoViewModel.Unit is Group)
		{
			Group group = (Group)hoverInfoViewModel.Unit;
			if (group.Units.Values.Any((ActiveUnit F) => F.UnitType == GlobalVariables.ActiveUnitType.Facility))
			{
				if (group.Units.Values.Any((ActiveUnit F) => F.AirFacilities_ReadOnly.Any((AirFacility airFacility_0) => airFacility_0.AirFacType != AirFacility._AirFacType.None)))
				{
					return AirbaseTemplate;
				}
				if (group.Units.Values.Any((ActiveUnit F) => F.DockFacilities_ReadOnly.Any((DockFacility dockFacility_0) => dockFacility_0.Type != DockFacility.DockFacilityType.None)))
				{
					return AirbaseTemplate;
				}
				return GroundGroupTemplate;
			}
			if (group.Units.Values.Any((ActiveUnit F) => (F.UnitType == GlobalVariables.ActiveUnitType.Ship) | (F.UnitType == GlobalVariables.ActiveUnitType.Submarine)))
			{
				return NavalGroupTemplate;
			}
			if (group.Units.Values.Any((ActiveUnit F) => F.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
			{
				return AirGroupTemplate;
			}
		}
		if (hoverInfoViewModel.Unit is ActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)hoverInfoViewModel.Unit;
			if (activeUnit is Ship)
			{
				return ShipTemplate;
			}
			if (activeUnit is Aircraft)
			{
				return AircraftTemplate;
			}
			if (activeUnit is Submarine)
			{
				return SubTemplate;
			}
			if (activeUnit is Facility)
			{
				return GroundUnitTemplate;
			}
			if (activeUnit is Satellite)
			{
				return SatelliteTemplate;
			}
		}
		return FallbackTemplate;
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ReponseInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
