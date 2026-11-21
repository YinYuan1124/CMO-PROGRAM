using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
[DesignerGenerated]
public class ScenarioMinimapWindow : Window, IComponentConnector
{
	private ScenarioMinimapViewModel _ManagerPredicate;

	private Thread getterPredicate;

	private bool _ProducerPredicate;

	private Thread procPredicate;

	private bool _StructSingleton;

	private bool merchantSingleton;

	private bool callbackSingleton;

	internal Grid MainGrid;

	internal Image TerrainImage;

	internal Image UnitsImage;

	private bool _contentLoaded;

	public ScenarioMinimapWindow()
	{
		_ProducerPredicate = false;
		_StructSingleton = false;
		merchantSingleton = false;
		InitializeComponent();
	}

	private void InvokeInterruptiblePublisher(object sender, RoutedEventArgs e)
	{
		if (_ProducerPredicate && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (_StructSingleton && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		_ManagerPredicate = new ScenarioMinimapViewModel();
		_ManagerPredicate.Dispatcher = base.Dispatcher;
		_ManagerPredicate.GridControl = MainGrid;
		base.DataContext = _ManagerPredicate;
		getterPredicate = new Thread(SetupInterruptiblePublisher);
		getterPredicate.Name = "Minimap Terrain Thread";
		getterPredicate.Priority = ThreadPriority.Lowest;
		getterPredicate.Start();
		procPredicate = new Thread(ExcludeInterruptiblePublisher);
		procPredicate.Name = "Minimap Unit Thread";
		procPredicate.Priority = ThreadPriority.Lowest;
		procPredicate.Start();
		new WindowInteropHelper(this).Owner = ItemExporter.ConnectInterruptibleTemplate.MainForm.Handle;
	}

	private void SetupInterruptiblePublisher()
	{
		_ProducerPredicate = true;
		while (!merchantSingleton)
		{
			_ManagerPredicate.UpdateTerrain();
			Thread.Sleep(5000);
		}
		_ProducerPredicate = false;
	}

	private void ExcludeInterruptiblePublisher()
	{
		_StructSingleton = true;
		while (!merchantSingleton)
		{
			_ManagerPredicate.UpdateUnits();
			Thread.Sleep(5000);
		}
		_StructSingleton = false;
	}

	private void IncludeInterruptiblePublisher(object sender, EventArgs e)
	{
		merchantSingleton = true;
	}

	private void SearchInterruptiblePublisher(object sender, MouseButtonEventArgs e)
	{
		if (e.ChangedButton != 0)
		{
			_ManagerPredicate.PanMapToPixel((int)Math.Round(e.GetPosition((IInputElement)sender).X), (int)Math.Round(e.GetPosition((IInputElement)sender).Y));
		}
	}

	private void EnableInterruptiblePublisher(object sender, MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		DragMove();
	}

	private void ChangeInterruptiblePublisher(object sender, MouseEventArgs e)
	{
		if (e.RightButton == MouseButtonState.Pressed)
		{
			_ManagerPredicate.PanMapToPixel((int)Math.Round(e.GetPosition((IInputElement)sender).X), (int)Math.Round(e.GetPosition((IInputElement)sender).Y));
		}
	}

	private void InitInterruptiblePublisher(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.ScenarioMinimapToolStripMenuItem_Click(this, null);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/scenariominimapwindow.xaml", UriKind.Relative);
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
			((ScenarioMinimapWindow)target).Loaded += InvokeInterruptiblePublisher;
			((ScenarioMinimapWindow)target).Closed += IncludeInterruptiblePublisher;
			((ScenarioMinimapWindow)target).MouseLeftButtonDown += EnableInterruptiblePublisher;
			break;
		case 2:
			((Button)target).Click += InitInterruptiblePublisher;
			break;
		case 3:
			MainGrid = (Grid)target;
			break;
		case 4:
			TerrainImage = (Image)target;
			break;
		case 5:
			UnitsImage = (Image)target;
			UnitsImage.MouseDown += SearchInterruptiblePublisher;
			UnitsImage.MouseMove += ChangeInterruptiblePublisher;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
