using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Threading;
using Command.Messages;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DesignerGenerated]
[DoNotPrune]
public class DatabaseWindow : Window, INotifyPropertyChanged, IComponentConnector
{
	private Thread _GetterValue;

	private static List<Thread> _ProducerValue;

	public Dispatcher ThreadDispatcher;

	private static string m_ProcValue;

	private static int m_StructTokenizer;

	private static int merchantTokenizer;

	private static string m_CallbackTokenizer;

	private static object _DecoratorTokenizer;

	[NonSerialized]
	private PropertyChangedEventHandler m_ProcessTokenizer;

	private bool _ThreadTokenizer;

	internal DatabaseControl DatabaseControl1;

	private bool _contentLoaded;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ProcessTokenizer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ProcessTokenizer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ProcessTokenizer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ProcessTokenizer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	static DatabaseWindow()
	{
		_ProducerValue = new List<Thread>();
		_DecoratorTokenizer = RuntimeHelpers.GetObjectValue(new object());
	}

	public DatabaseWindow()
	{
		InitializeComponent();
	}

	public static void OpenNewDatabaseWindow(string string_0, int int_0, string string_1 = null)
	{
		object decoratorTokenizer = _DecoratorTokenizer;
		ObjectFlowControl.CheckForSyncLockOnValueType(decoratorTokenizer);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(decoratorTokenizer, ref lockTaken);
			m_ProcValue = string_0;
			m_StructTokenizer = int_0;
			m_CallbackTokenizer = string_1;
			merchantTokenizer = (int)ItemExporter.ConnectInterruptibleTemplate.MainForm.Handle;
			Thread thread = new Thread(ExcludeServer);
			_ProducerValue.Add(thread);
			thread.Name = "Database Viewer Thread";
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(decoratorTokenizer);
			}
		}
	}

	private static void ExcludeServer()
	{
		object decoratorTokenizer = _DecoratorTokenizer;
		ObjectFlowControl.CheckForSyncLockOnValueType(decoratorTokenizer);
		bool lockTaken = false;
		DatabaseControlViewModel databaseControlViewModel;
		try
		{
			Monitor.Enter(decoratorTokenizer, ref lockTaken);
			databaseControlViewModel = new DatabaseControlViewModel();
			databaseControlViewModel.SelectedObjectType = m_ProcValue;
			databaseControlViewModel.SelectedObjectID = m_StructTokenizer;
			databaseControlViewModel.HighlightTarget = m_CallbackTokenizer;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(decoratorTokenizer);
			}
		}
		DatabaseWindow databaseWindow = new DatabaseWindow();
		new WindowInteropHelper(databaseWindow).Owner = (IntPtr)merchantTokenizer;
		databaseWindow._GetterValue = Thread.CurrentThread;
		databaseWindow.DatabaseControl1.DataContext = databaseControlViewModel;
		databaseWindow.DataContext = databaseControlViewModel;
		databaseControlViewModel.DatabaseControl = databaseWindow.DatabaseControl1;
		databaseControlViewModel.Populate();
		databaseWindow.Show();
		databaseWindow.ThreadDispatcher = Dispatcher.CurrentDispatcher;
		Dispatcher.Run();
	}

	private void IncludeServer(object sender, EventArgs e)
	{
		ThreadDispatcher.InvokeShutdown();
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ProcessTokenizer?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/databasewindow.xaml", UriKind.Relative);
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
			((DatabaseWindow)target).Closed += IncludeServer;
			break;
		case 2:
			DatabaseControl1 = (DatabaseControl)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
