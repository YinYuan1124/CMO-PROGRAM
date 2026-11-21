using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using Command.Messages;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class TerrainTypeLegendWindow : Window, IComponentConnector
{
	private bool _ManagerException;

	private bool _contentLoaded;

	public TerrainTypeLegendWindow()
	{
		InitializeComponent();
	}

	private void SetInterruptibleAttr(object sender, MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		DragMove();
	}

	private void FillInterruptibleAttr(object sender, RoutedEventArgs e)
	{
		new WindowInteropHelper(this).Owner = ItemExporter.ConnectInterruptibleTemplate.MainForm.Handle;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/terraintypelegendwindow.xaml", UriKind.Relative);
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
			((TerrainTypeLegendWindow)target).MouseLeftButtonDown += SetInterruptibleAttr;
			((TerrainTypeLegendWindow)target).Loaded += FillInterruptibleAttr;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
