using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class resources_icons_xaml : ResourceDictionary, IComponentConnector
{
	private bool _FacadePredicate;

	private bool _contentLoaded;

	public resources_icons_xaml()
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
			Uri resourceLocater = new Uri("/Command;component/command/resources_icons_xaml.xaml", UriKind.Relative);
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
