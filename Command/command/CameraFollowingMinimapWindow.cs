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

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
[DesignerGenerated]
public class CameraFollowingMinimapWindow : Window, IComponentConnector
{
	private CameraFollowingMinimapViewModel m_DispatcherInvocation;

	private Thread m_ListenerInvocation;

	private bool configInvocation;

	private Thread _RegistryInvocation;

	private bool m_DefinitionInvocation;

	private bool valInvocation;

	private bool wrapperInvocation;

	internal Grid MainGrid;

	internal Image TerrainImage;

	internal Image UnitsImage;

	private bool _contentLoaded;

	public CameraFollowingMinimapWindow()
	{
		configInvocation = false;
		m_DefinitionInvocation = false;
		valInvocation = false;
		InitializeComponent();
	}

	private void SetContext(object sender, RoutedEventArgs e)
	{
		if (configInvocation && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (m_DefinitionInvocation && Debugger.IsAttached)
		{
			Debugger.Break();
		}
		m_DispatcherInvocation = new CameraFollowingMinimapViewModel();
		m_DispatcherInvocation.Dispatcher = base.Dispatcher;
		m_DispatcherInvocation.GridControl = MainGrid;
		base.DataContext = m_DispatcherInvocation;
		m_ListenerInvocation = new Thread(FillContext);
		m_ListenerInvocation.Name = "Minimap Terrain Thread";
		m_ListenerInvocation.Priority = ThreadPriority.Lowest;
		m_ListenerInvocation.Start();
		_RegistryInvocation = new Thread(CalculateContext);
		_RegistryInvocation.Name = "Minimap Unit Thread";
		_RegistryInvocation.Priority = ThreadPriority.Lowest;
		_RegistryInvocation.Start();
		new WindowInteropHelper(this).Owner = ItemExporter.ConnectInterruptibleTemplate.MainForm.Handle;
	}

	private void FillContext()
	{
		configInvocation = true;
		while (!valInvocation)
		{
			m_DispatcherInvocation.UpdateTerrain();
			Thread.Sleep(5000);
		}
		configInvocation = false;
	}

	private void CalculateContext()
	{
		m_DefinitionInvocation = true;
		while (!valInvocation)
		{
			m_DispatcherInvocation.UpdateUnits();
			Thread.Sleep(5000);
		}
		m_DefinitionInvocation = false;
	}

	private void PopContext(object sender, EventArgs e)
	{
		valInvocation = true;
	}

	private void InstantiateContext(object sender, MouseButtonEventArgs e)
	{
		if (e.ChangedButton != 0)
		{
			m_DispatcherInvocation.PanMapToPixel((int)Math.Round(e.GetPosition((IInputElement)sender).X), (int)Math.Round(e.GetPosition((IInputElement)sender).Y));
		}
	}

	private void CreateContext(object sender, MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		DragMove();
	}

	private void CompareContext(object sender, MouseEventArgs e)
	{
		if (e.RightButton == MouseButtonState.Pressed)
		{
			m_DispatcherInvocation.PanMapToPixel((int)Math.Round(e.GetPosition((IInputElement)sender).X), (int)Math.Round(e.GetPosition((IInputElement)sender).Y));
		}
	}

	private void ReadContext(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraMinimapToolStripMenuItem_Click(this, null);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/camerafollowingminimapwindow.xaml", UriKind.Relative);
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
			((CameraFollowingMinimapWindow)target).Loaded += SetContext;
			((CameraFollowingMinimapWindow)target).Closed += PopContext;
			((CameraFollowingMinimapWindow)target).MouseLeftButtonDown += CreateContext;
			break;
		case 2:
			((Button)target).Click += ReadContext;
			break;
		case 3:
			MainGrid = (Grid)target;
			break;
		case 4:
			TerrainImage = (Image)target;
			break;
		case 5:
			UnitsImage = (Image)target;
			UnitsImage.MouseDown += InstantiateContext;
			UnitsImage.MouseMove += CompareContext;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
