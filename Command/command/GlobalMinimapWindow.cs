using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DesignerGenerated]
[DoNotPrune]
public class GlobalMinimapWindow : Window, IComponentConnector
{
	private GlobalMinimapViewModel _FieldTests;

	private Thread m_QueueTests;

	private bool m_RegTests;

	private Thread paramTests;

	private bool m_PageTests;

	private bool _RulesTests;

	private bool _MethodTests;

	internal Grid MainGrid;

	internal Image TerrainImage;

	internal Image UnitsImage;

	private bool _contentLoaded;

	public GlobalMinimapWindow()
	{
		m_RegTests = false;
		m_PageTests = false;
		_RulesTests = false;
		InitializeComponent();
	}

	private void IncludeAnnotation(object sender, RoutedEventArgs e)
	{
		if (m_RegTests && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (m_PageTests && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		_FieldTests = new GlobalMinimapViewModel();
		_FieldTests.Dispatcher = base.Dispatcher;
		_FieldTests.GridControl = MainGrid;
		base.DataContext = _FieldTests;
		m_QueueTests = new Thread(delegate(object object_0)
		{
			SearchAnnotation((Scenario)object_0);
		});
		m_QueueTests.Name = "Minimap Terrain Thread";
		m_QueueTests.Priority = ThreadPriority.Lowest;
		m_QueueTests.Start();
		paramTests = new Thread(EnableAnnotation);
		paramTests.Name = "Minimap Unit Thread";
		paramTests.Priority = ThreadPriority.Lowest;
		paramTests.Start();
		new WindowInteropHelper(this).Owner = ItemExporter.ConnectInterruptibleTemplate.MainForm.Handle;
	}

	private void SearchAnnotation(Scenario scenario_0)
	{
		m_RegTests = true;
		while (!_RulesTests)
		{
			_FieldTests.UpdateTerrain(scenario_0);
			Thread.Sleep(20000);
		}
		m_RegTests = false;
	}

	private void EnableAnnotation()
	{
		m_PageTests = true;
		while (!_RulesTests)
		{
			_FieldTests.UpdateUnits();
			Thread.Sleep(5000);
		}
		m_PageTests = false;
	}

	private void ChangeAnnotation(object sender, EventArgs e)
	{
		_RulesTests = true;
	}

	private void InitAnnotation(object sender, MouseButtonEventArgs e)
	{
		if (e.ChangedButton != 0)
		{
			_FieldTests.PanMapToPixel((int)Math.Round(e.GetPosition((IInputElement)sender).X), (int)Math.Round(e.GetPosition((IInputElement)sender).Y));
		}
	}

	private void CheckAnnotation(object sender, MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		DragMove();
	}

	private void ConcatAnnotation(object sender, MouseEventArgs e)
	{
		if (e.RightButton == MouseButtonState.Pressed)
		{
			_FieldTests.PanMapToPixel((int)Math.Round(e.GetPosition((IInputElement)sender).X), (int)Math.Round(e.GetPosition((IInputElement)sender).Y));
		}
	}

	private void InterruptAnnotation(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.GlobalMinimapToolStripMenuItem_Click(this, null);
	}

	[CompilerGenerated]
	private void RemoveAnnotation(object object_0)
	{
		SearchAnnotation((Scenario)object_0);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/globalminimapwindow.xaml", UriKind.Relative);
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
			((GlobalMinimapWindow)target).Loaded += IncludeAnnotation;
			((GlobalMinimapWindow)target).Closed += ChangeAnnotation;
			((GlobalMinimapWindow)target).MouseLeftButtonDown += CheckAnnotation;
			break;
		case 2:
			((Button)target).Click += InterruptAnnotation;
			break;
		case 3:
			MainGrid = (Grid)target;
			break;
		case 4:
			TerrainImage = (Image)target;
			break;
		case 5:
			UnitsImage = (Image)target;
			UnitsImage.MouseDown += InitAnnotation;
			UnitsImage.MouseMove += ConcatAnnotation;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
