using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
[DesignerGenerated]
public class HoverInfoOptions : UserControl, IComponentConnector
{
	private bool objectInterpreter;

	private bool _contentLoaded;

	private PropertyGrid _propertyGrid;

	public HoverInfoOptions()
	{
		InitializeComponent();
		Localization.LanguageChanged += RefreshLocalization;
	}

	private void RefreshLocalization(object sender, EventArgs e)
	{
		if (!base.Dispatcher.CheckAccess())
		{
			try
			{
				base.Dispatcher.InvokeAsync(delegate
				{
					RefreshLocalization(sender, e);
				});
			}
			catch
			{
			}
			return;
		}
		try
		{
			TypeDescriptor.Refresh(typeof(HoverInfoOptionsViewModel));
			object dataContext = base.DataContext;
			base.DataContext = null;
			base.DataContext = dataContext ?? HoverInfoOptionsViewModel.Singleton;
		}
		catch
		{
		}
	}

	private void RegisterAnnotation(object sender, RoutedEventArgs e)
	{
		if (base.DataContext == null)
		{
			base.DataContext = HoverInfoOptionsViewModel.Singleton;
		}
	}

	private void ManageAnnotation(object sender, PropertyChangedEventArgs e)
	{
		if (base.DataContext != null)
		{
			((HoverInfoOptionsViewModel)base.DataContext).Save();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/hoverinfooptions.xaml", UriKind.Relative);
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
			((HoverInfoOptions)target).Loaded += RegisterAnnotation;
			break;
		case 2:
			_propertyGrid = (PropertyGrid)target;
			_propertyGrid.PropertyChanged += ManageAnnotation;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
