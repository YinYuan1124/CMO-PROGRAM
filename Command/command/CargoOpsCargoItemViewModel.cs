using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class CargoOpsCargoItemViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private Cargo _IdentifierInvocation;

	[CompilerGenerated]
	private int m_PrinterInvocation;

	[CompilerGenerated]
	private int parserInvocation;

	[CompilerGenerated]
	private bool _AlgoInvocation;

	[CompilerGenerated]
	private bool _DatabaseInvocation;

	[NonSerialized]
	private PropertyChangedEventHandler m_InterceptorInvocation;

	public Cargo Cargo
	{
		[CompilerGenerated]
		get
		{
			return _IdentifierInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (_IdentifierInvocation != value)
			{
				_IdentifierInvocation = value;
				OnPropertyChanged("Name");
				OnPropertyChanged("CargoType");
				OnPropertyChanged("MassPerUnit");
				OnPropertyChanged("AreaPerUnit");
				OnPropertyChanged("CrewPerUnit");
				OnPropertyChanged("Abilities");
				OnPropertyChanged("Cargo");
			}
		}
	}

	public int Quantity
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_PrinterInvocation != value)
			{
				m_PrinterInvocation = value;
				OnPropertyChanged("Name");
				OnPropertyChanged("Quantity");
			}
		}
	}

	public int InitialQuantity
	{
		[CompilerGenerated]
		get
		{
			return parserInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (parserInvocation != value)
			{
				parserInvocation = value;
				OnPropertyChanged("InitialQuantity");
			}
		}
	}

	public bool CargoTypeLimited
	{
		[CompilerGenerated]
		get
		{
			return _AlgoInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (_AlgoInvocation != value)
			{
				_AlgoInvocation = value;
				OnPropertyChanged("CargoTypeLimitedBrush");
				OnPropertyChanged("CargoTypeLimited");
			}
		}
	}

	public bool IsUnitHeader
	{
		[CompilerGenerated]
		get
		{
			return _DatabaseInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (_DatabaseInvocation != value)
			{
				_DatabaseInvocation = value;
				OnPropertyChanged("DetailsVisibility");
				OnPropertyChanged("CargoTypeLimitedBrush");
				OnPropertyChanged("Name");
				OnPropertyChanged("IsUnitHeader");
			}
		}
	}

	public Visibility DetailsVisibility
	{
		get
		{
			if (IsUnitHeader)
			{
				return Visibility.Hidden;
			}
			return Visibility.Visible;
		}
	}

	public SolidColorBrush CargoTypeLimitedBrush
	{
		get
		{
			if (IsUnitHeader)
			{
				return new SolidColorBrush(Colors.White);
			}
			if (CargoTypeLimited)
			{
				return new SolidColorBrush(Colors.IndianRed);
			}
			return new SolidColorBrush(Colors.White);
		}
	}

	public string Name
	{
		get
		{
			if (IsUnitHeader)
			{
				return "[Group Member] " + Cargo.Name;
			}
			return Conversions.ToString(Quantity) + "x " + Cargo.CargoObjectName;
		}
	}

	public CargoType CargoType => Cargo.RequiredCargoType;

	public double MassPerUnit => Cargo.RequiredMass;

	public double AreaPerUnit => Cargo.RequiredArea;

	public double CrewPerUnit => Cargo.RequiredCrewSpace;

	public string Abilities
	{
		get
		{
			if (Cargo.isParadropCapable)
			{
				return "可用降落伞空投";
			}
			return "";
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_InterceptorInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_InterceptorInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_InterceptorInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_InterceptorInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_InterceptorInvocation?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
