using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public class UnitEMCON_WPF : UserControl, INotifyPropertyChanged, IComponentConnector
{
	[NonSerialized]
	private PropertyChangedEventHandler templateAttr;

	private bool m_MappingAttr;

	internal ToggleButton btnRadarActive;

	internal ToggleButton btnRadarPassive;

	internal ToggleButton btnSonarActive;

	internal ToggleButton btnSonarPassive;

	internal ToggleButton btnOECMActive;

	internal ToggleButton btnOECMPassive;

	private bool _contentLoaded;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = templateAttr;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref templateAttr, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = templateAttr;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref templateAttr, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public UnitEMCON_WPF()
	{
		base.Loaded += NewInterruptiblePrototype;
		InitializeComponent();
	}

	private void NewInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		Doctrine.EmconChanged += PushInterruptiblePrototype;
	}

	private void PushInterruptiblePrototype(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (!bool_2 && Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
		{
			Refresh((ActiveUnit)Client.SelectedUnit);
		}
	}

	public void Refresh(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0 == null)
		{
			base.DataContext = null;
			base.IsEnabled = false;
			return;
		}
		base.IsEnabled = true;
		if (!activeUnit_0.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
		{
			base.Visibility = Visibility.Collapsed;
			return;
		}
		base.Visibility = Visibility.Visible;
		if (base.DataContext == null)
		{
			base.DataContext = new GClass8(activeUnit_0);
			return;
		}
		GClass8 gClass = (GClass8)base.DataContext;
		if (gClass.theUnit == activeUnit_0)
		{
			gClass.Refresh();
			return;
		}
		gClass.theUnit = activeUnit_0;
		gClass.Refresh();
	}

	private void InvokeInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
		{
			((ActiveUnit)Client.SelectedUnit).Doctrine.EMCON_Inherits = ((CheckBox)sender).IsChecked.Value;
			Refresh((ActiveUnit)Client.SelectedUnit);
		}
	}

	private void SetupInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
		Sensor[] array2 = array;
		foreach (Sensor sensor in array2)
		{
			if (sensor.Type == Sensor.Sensor_Type.Radar && !sensor.IsPureIlluminator && (!sensor.IsActive & sensor.CanBeActive))
			{
				sensor.GoActive();
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ExcludeInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
		Sensor[] array2 = array;
		foreach (Sensor sensor in array2)
		{
			if (sensor.Type == Sensor.Sensor_Type.Radar && !sensor.IsPureIlluminator && sensor.IsActive)
			{
				sensor.GoPassive();
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void IncludeInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
		Sensor[] array2 = array;
		foreach (Sensor sensor in array2)
		{
			if (sensor.IsSonar && !sensor.IsPureIlluminator && (!sensor.IsActive & sensor.CanBeActive))
			{
				sensor.GoActive();
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void SearchInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
		Sensor[] array2 = array;
		foreach (Sensor sensor in array2)
		{
			if (sensor.IsSonar && !sensor.IsPureIlluminator && sensor.IsActive)
			{
				sensor.GoPassive();
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void EnableInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
		Sensor[] array2 = array;
		foreach (Sensor sensor in array2)
		{
			if (sensor.IsOECM && !sensor.IsPureIlluminator && (!sensor.IsActive & sensor.CanBeActive))
			{
				sensor.GoActive();
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ChangeInterruptiblePrototype(object sender, RoutedEventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Sensor[] array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
		Sensor[] array2 = array;
		foreach (Sensor sensor in array2)
		{
			if (sensor.IsOECM && !sensor.IsPureIlluminator && sensor.IsActive)
			{
				sensor.GoPassive();
			}
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	public void OnPropertyChanged(string string_0)
	{
		templateAttr?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/unitemcon_wpf.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			((CheckBox)target).Click += InvokeInterruptiblePrototype;
			break;
		case 2:
			btnRadarActive = (ToggleButton)target;
			btnRadarActive.Click += SetupInterruptiblePrototype;
			break;
		case 3:
			btnRadarPassive = (ToggleButton)target;
			btnRadarPassive.Click += ExcludeInterruptiblePrototype;
			break;
		case 4:
			btnSonarActive = (ToggleButton)target;
			btnSonarActive.Click += IncludeInterruptiblePrototype;
			break;
		case 5:
			btnSonarPassive = (ToggleButton)target;
			btnSonarPassive.Click += SearchInterruptiblePrototype;
			break;
		case 6:
			btnOECMActive = (ToggleButton)target;
			btnOECMActive.Click += EnableInterruptiblePrototype;
			break;
		case 7:
			btnOECMPassive = (ToggleButton)target;
			btnOECMPassive.Click += ChangeInterruptiblePrototype;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
