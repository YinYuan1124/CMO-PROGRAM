using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command.Messages;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DesignerGenerated]
[DoNotPruneType]
[DoNotObfuscate]
public class UnitSpeedAlt : UserControl, INotifyPropertyChanged, IComponentConnector
{
	[NonSerialized]
	private PropertyChangedEventHandler paramVisitor;

	private bool m_PageVisitor;

	private bool _contentLoaded;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = paramVisitor;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref paramVisitor, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = paramVisitor;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref paramVisitor, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public UnitSpeedAlt()
	{
		InitializeComponent();
	}

	public void Hide()
	{
		if (base.DataContext == null)
		{
			base.DataContext = new UnitSpeedAltViewModel();
			((UnitSpeedAltViewModel)base.DataContext).Visible = Visibility.Collapsed;
		}
		else
		{
			((UnitSpeedAltViewModel)base.DataContext).Visible = Visibility.Collapsed;
		}
	}

	public void Refresh(bool bool_0)
	{
		if (base.DataContext == null)
		{
			UnitSpeedAltViewModel unitSpeedAltViewModel = new UnitSpeedAltViewModel();
			unitSpeedAltViewModel.Refresh(bool_0);
			base.DataContext = unitSpeedAltViewModel;
		}
		else
		{
			((UnitSpeedAltViewModel)base.DataContext).Refresh(bool_0);
		}
		if (ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.Expander_AltSpeed.IsExpanded)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.Expander_AltSpeed.IsExpanded = false;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.Expander_AltSpeed.IsExpanded = true;
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.Expander_AltSpeed.IsExpanded = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.Expander_AltSpeed.IsExpanded = false;
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		paramVisitor?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/unitspeedalt.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		_contentLoaded = true;
	}
}
