using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using Command.Messages;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DesignerGenerated]
[DoNotPruneType]
public class GClass5 : Window, IComponentConnector
{
	private bool threadContext;

	public GClass5()
	{
		InitializeComponent();
	}

	private void CheckInterruptibleRegistry(object sender, RoutedEventArgs e)
	{
		new WindowInteropHelper(this).Owner = ItemExporter.ConnectInterruptibleTemplate.MainForm.Handle;
	}

	private void ConcatInterruptibleRegistry(object sender, EventArgs e)
	{
		if (!ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Visible && !Client.infoClass)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlViewModel.LogCollapsed = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ShowEmbeddedMessageLog();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.gclass5_0 = null;
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void InterruptInterruptibleRegistry(object sender, RoutedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Show();
		ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Left = (int)Math.Round(base.Left);
		ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Top = (int)Math.Round(base.Top);
		ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Width = (int)Math.Round(base.Width);
		ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().Height = (int)Math.Round(base.Height);
		ItemExporter.ConnectInterruptibleTemplate.VerifyInterruptibleCandidate().MinimumSize = new System.Drawing.Size(200, 200);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.CloseMessageLogWindowWPF(bool_0: false);
	}

	[GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
	[DebuggerNonUserCode]
	public void InitializeComponent()
	{
		if (!threadContext)
		{
			threadContext = true;
			Uri resourceLocator = new Uri("/Command;component/forms/messagelog/messagelogwpfwindow.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
	[DebuggerNonUserCode]
	internal Delegate RemoveInterruptibleRegistry(Type type_0, string string_0)
	{
		return Delegate.CreateDelegate(type_0, this, string_0);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
	[DebuggerNonUserCode]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		if (connectionId == 1)
		{
			((GClass5)target).Loaded += CheckInterruptibleRegistry;
			((GClass5)target).Closed += ConcatInterruptibleRegistry;
		}
		else
		{
			threadContext = true;
		}
	}
}
