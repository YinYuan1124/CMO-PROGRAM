using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
[DesignerGenerated]
public class ScenarioSelectControl : UserControl, INotifyPropertyChanged, IComponentConnector
{
	[NonSerialized]
	private PropertyChangedEventHandler _DecoratorSingleton;

	private bool processSingleton;

	private bool _contentLoaded;

	public ScenarioSelectControlViewModel VM => (ScenarioSelectControlViewModel)base.DataContext;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _DecoratorSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _DecoratorSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _DecoratorSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _DecoratorSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public ScenarioSelectControl()
	{
		InitializeComponent();
		base.DataContext = new ScenarioSelectControlViewModel();
	}

	private void CheckInterruptiblePublisher(object sender, RoutedEventArgs e)
	{
		VM.Update();
	}

	private void ConcatInterruptiblePublisher(object sender, SelectionChangedEventArgs e)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(e.AddedItems[0]);
		if (objectValue != null)
		{
			((SteamScenarioViewModel)objectValue).SelectSubroutine();
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		_DecoratorSingleton?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/scenarioselectcontrol.xaml", UriKind.Relative);
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
			((ScenarioSelectControl)target).Loaded += CheckInterruptiblePublisher;
			break;
		case 2:
			((ListBox)target).SelectionChanged += ConcatInterruptiblePublisher;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
