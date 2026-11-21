using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Command.Listeners;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
[DesignerGenerated]
public class UnitWeapons_WPF : UserControl, INotifyPropertyChanged, IComponentConnector
{
	[NonSerialized]
	private PropertyChangedEventHandler _ExpressionExporter;

	private bool m_DispatcherExporter;

	private bool _contentLoaded;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _ExpressionExporter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _ExpressionExporter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _ExpressionExporter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _ExpressionExporter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public UnitWeapons_WPF()
	{
		InitializeComponent();
	}

	public void Refresh(ActiveUnit activeUnit_0, ref bool bool_0, ref bool bool_1)
	{
		if (base.DataContext == null)
		{
			base.DataContext = new UnitWeaponViewModel(activeUnit_0);
			bool_0 = ((UnitWeaponViewModel)base.DataContext).HasWeapons;
			return;
		}
		UnitWeaponViewModel unitWeaponViewModel = (UnitWeaponViewModel)base.DataContext;
		if (activeUnit_0 != null && !activeUnit_0.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
		{
			base.DataContext = new UnitWeaponViewModel(activeUnit_0);
			bool_0 = false;
			return;
		}
		if (unitWeaponViewModel.theUnit == activeUnit_0)
		{
			unitWeaponViewModel.Refresh();
			bool_0 = unitWeaponViewModel.HasWeapons;
			return;
		}
		if (activeUnit_0 == null)
		{
			base.DataContext = new UnitWeaponViewModel(activeUnit_0);
			bool_0 = false;
			return;
		}
		base.DataContext = new UnitWeaponViewModel(activeUnit_0);
		bool_0 = ((UnitWeaponViewModel)base.DataContext).HasWeapons;
		if (bool_0 && unitWeaponViewModel.Weapons_Sorted != null && unitWeaponViewModel.Weapons_Sorted.Count < ((UnitWeaponViewModel)base.DataContext).Weapons_Sorted.Count)
		{
			bool_1 = true;
		}
		else
		{
			bool_1 = false;
		}
	}

	private void ResetInterruptibleSetter(object sender, MouseEventArgs e)
	{
		try
		{
			((UnitWeaponViewModel)base.DataContext).mouseOverPanel = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void MapInterruptibleSetter(object sender, MouseEventArgs e)
	{
		try
		{
			((UnitWeaponViewModel)base.DataContext).mouseOverPanel = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		_ExpressionExporter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/unitweapons_wpf.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		if (connectionId == 1)
		{
			((UnitWeapons_WPF)target).MouseEnter += ResetInterruptibleSetter;
			((UnitWeapons_WPF)target).MouseLeave += MapInterruptibleSetter;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
