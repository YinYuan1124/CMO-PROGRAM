using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DesignerGenerated]
[DoNotPruneType]
[DoNotObfuscate]
public class EditCargoControl : UserControl, IComponentConnector
{
	private bool m_BaseWatcher;

	internal DataGrid MyDataGrid;

	internal ListBox InventoryList;

	private bool _contentLoaded;

	public EditCargoControl()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/editcargocontrol.xaml", UriKind.Relative);
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
			MyDataGrid = (DataGrid)target;
			break;
		case 2:
			InventoryList = (ListBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
