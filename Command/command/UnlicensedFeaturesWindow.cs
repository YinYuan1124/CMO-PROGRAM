using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DesignerGenerated]
[DoNotPrune]
public class UnlicensedFeaturesWindow : Window, IComponentConnector
{
	private bool _WrapperExporter;

	private bool _contentLoaded;

	public UnlicensedFeaturesWindow()
	{
		InitializeComponent();
	}

	private void CollectInterruptibleSetter(object sender, RoutedEventArgs e)
	{
		Close();
		ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/unlicensedfeatureswindow.xaml", UriKind.Relative);
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
			((Button)target).Click += CollectInterruptibleSetter;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
