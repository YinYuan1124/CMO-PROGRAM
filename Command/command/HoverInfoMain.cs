using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DesignerGenerated]
[DoNotPruneType]
public class HoverInfoMain : UserControl, INotifyPropertyChanged, IComponentConnector
{
	[NonSerialized]
	private PropertyChangedEventHandler callbackInterpreter;

	private bool _DecoratorInterpreter;

	internal ContentControl MyContentControl;

	private bool _contentLoaded;

	public HoverInfoViewModel VM
	{
		get
		{
			return (HoverInfoViewModel)base.DataContext;
		}
		set
		{
			if (VM != value)
			{
				base.DataContext = value;
				OnPropertyChanged("VM");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = callbackInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref callbackInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = callbackInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref callbackInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public HoverInfoMain()
	{
		InitializeComponent();
	}

	public void Update(Module_Unit.Unit unit_0)
	{
		HoverInfoViewModel hoverInfoViewModel = new HoverInfoViewModel(MyContentControl, ItemExporter.ConnectInterruptibleTemplate.MainForm.HoverInfoElementHost);
		hoverInfoViewModel.Update(Client.SetConfiguration());
		VM = hoverInfoViewModel;
	}

	public void OnPropertyChanged(string string_0)
	{
		callbackInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/hoverinfomain.xaml", UriKind.Relative);
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
			MyContentControl = (ContentControl)target;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
