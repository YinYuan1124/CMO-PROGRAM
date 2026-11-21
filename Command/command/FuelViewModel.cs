using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class FuelViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class BridgeProcessProducer
	{
		public ActiveUnit theUnit;

		internal bool ListInterruptiblePage(PlatFormViewModel s)
		{
			if (s != null)
			{
				return s.theUnit == theUnit;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private ObservableCollection<PlatFormViewModel> _PublisherTests;

	[CompilerGenerated]
	private object serverTests;

	public ActiveUnit theUnit;

	[NonSerialized]
	private PropertyChangedEventHandler m_AdapterTests;

	public ObservableCollection<PlatFormViewModel> Items
	{
		[CompilerGenerated]
		get
		{
			return _PublisherTests;
		}
		[CompilerGenerated]
		set
		{
			if (_PublisherTests != value)
			{
				_PublisherTests = value;
				OnPropertyChanged("Items");
			}
		}
	}

	public object SelectedItem
	{
		[CompilerGenerated]
		get
		{
			return serverTests;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(serverTests, value))
			{
				serverTests = RuntimeHelpers.GetObjectValue(value);
				OnPropertyChanged("SelectedItem");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_AdapterTests;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_AdapterTests, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_AdapterTests;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_AdapterTests, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	[Obsolete("Used for design time only", true)]
	public FuelViewModel()
	{
		Items = new ObservableCollection<PlatFormViewModel>();
		AircraftFuelViewModel item = new AircraftFuelViewModel
		{
			Percentage = 50.0,
			Text = "测试文本",
			UnitName = "空战单元"
		};
		Items.Add(item);
		ShipFuelViewModel item2 = new ShipFuelViewModel
		{
			Percentage = 25.0,
			Text = "测试文本",
			UnitName = "舰船单元"
		};
		Items.Add(item2);
		SubmarineFuelViewModel item3 = new SubmarineFuelViewModel
		{
			Percentage = 50.0,
			EnduranceText = "测试文本",
			UnitName = "潜艇单元"
		};
		Items.Add(item3);
		GroundUnitFuelViewModel item4 = new GroundUnitFuelViewModel
		{
			Percentage = 25.0,
			Text = "测试文本",
			UnitName = "地面单元"
		};
		Items.Add(item4);
		SupplyFacilityUnitFuelViewModel item5 = new SupplyFacilityUnitFuelViewModel
		{
			Percentage = 25.0,
			Text = "测试文本",
			UnitName = "补给设施"
		};
		Items.Add(item5);
		SelectedItem = Items.First();
	}

	private void SelectAnnotation(ActiveUnit activeUnit_0)
	{
		try
		{
			PlatFormViewModel platFormViewModel = Items.FirstOrDefault((PlatFormViewModel s) => s != null && s.theUnit == activeUnit_0);
			if (platFormViewModel == null)
			{
				if (activeUnit_0 is Aircraft)
				{
					platFormViewModel = new AircraftFuelViewModel((Aircraft)activeUnit_0);
					Items.Add(platFormViewModel);
				}
				else if (activeUnit_0 is Submarine)
				{
					platFormViewModel = new SubmarineFuelViewModel((Submarine)activeUnit_0);
					Items.Add(platFormViewModel);
				}
				else if (activeUnit_0 is Ship)
				{
					platFormViewModel = new ShipFuelViewModel((Ship)activeUnit_0);
					Items.Add(platFormViewModel);
				}
				else if (activeUnit_0 is Vehicle)
				{
					platFormViewModel = new GroundUnitFuelViewModel((Vehicle)activeUnit_0);
					Items.Add(platFormViewModel);
				}
				else if (activeUnit_0 is Facility && activeUnit_0.Fuel_ReadOnly.Count > 0)
				{
					platFormViewModel = new SupplyFacilityUnitFuelViewModel((Facility)activeUnit_0);
					Items.Add(platFormViewModel);
				}
			}
			else if (platFormViewModel is AircraftFuelViewModel)
			{
				((AircraftFuelViewModel)platFormViewModel).Refresh();
			}
			else if (platFormViewModel is SubmarineFuelViewModel)
			{
				((SubmarineFuelViewModel)platFormViewModel).Refresh();
			}
			else if (platFormViewModel is ShipFuelViewModel)
			{
				((ShipFuelViewModel)platFormViewModel).Refresh();
			}
			else if (platFormViewModel is GroundUnitFuelViewModel)
			{
				((GroundUnitFuelViewModel)platFormViewModel).Refresh();
			}
			else if (platFormViewModel is SupplyFacilityUnitFuelViewModel)
			{
				((SupplyFacilityUnitFuelViewModel)platFormViewModel).Refresh();
			}
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

	[DoNotObfuscate]
	[DoNotPrune]
	public void Refresh()
	{
		try
		{
			if (theUnit is Group)
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)theUnit).Units)
				{
					SelectAnnotation(unit.Value);
				}
			}
			else
			{
				SelectAnnotation(theUnit);
			}
			if ((SelectedItem == null) & (Items.Count != 0))
			{
				SelectedItem = Items.First();
			}
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

	public FuelViewModel(ActiveUnit activeUnit_0)
	{
		Items = new ObservableCollection<PlatFormViewModel>();
		theUnit = activeUnit_0;
		Refresh();
	}

	public void OnPropertyChanged(string string_0)
	{
		m_AdapterTests?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
