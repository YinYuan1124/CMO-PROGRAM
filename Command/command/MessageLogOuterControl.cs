using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Command.Messages;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class MessageLogOuterControl : UserControl, IComponentConnector
{
	private bool _GetterConnection;

	private bool _contentLoaded;

	public MessageLogControlViewModel VM => (MessageLogControlViewModel)base.DataContext;

	public MessageLogOuterControl()
	{
		base.KeyDown += ComputeInterruptibleRegistry;
		InitializeComponent();
	}

	public void MessageLogExpandCollapseButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (VM != null)
		{
			if (VM.LogCollapsed)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.MaximumSize = new System.Drawing.Size(VM.MainFormLogWidth, 400);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.MinimumSize = new System.Drawing.Size(VM.MainFormLogWidth, 400);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Location = new System.Drawing.Point(ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Location.X, ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Location.Y - 370);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Height = 400;
				VM.LogCollapsed = false;
				VM.LogCollapseButtonRotation = 0.0;
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.MaximumSize = new System.Drawing.Size(VM.MainFormLogWidth, 30);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.MinimumSize = new System.Drawing.Size(VM.MainFormLogWidth, 30);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Location = new System.Drawing.Point(ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Location.X, ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Location.Y + 370);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MessageLogControlElementHost1.Height = 30;
				VM.LogCollapsed = true;
				VM.LogCollapseButtonRotation = 180.0;
			}
		}
	}

	private void ComputeInterruptibleRegistry(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.M && e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ToggleMessageLogInSeparateWindow();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/messagelogoutercontrol.xaml", UriKind.Relative);
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
			((Button)target).Click += MessageLogExpandCollapseButton_OnClick;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
