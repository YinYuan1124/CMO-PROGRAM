using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FloatingLicenseErrorForm : Form
{
	private IContainer m_InitializerFilter;

	[AccessedThroughProperty("Panel1")]
	[CompilerGenerated]
	private Panel roleFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private Button attributeFilter;

	[AccessedThroughProperty("BackgroundWorker1")]
	[CompilerGenerated]
	private BackgroundWorker m_EventFilter;

	public string ErrorReason;

	public Scenario ScenarioToSave;

	internal Panel Panel1
	{
		[CompilerGenerated]
		get
		{
			return roleFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			roleFilter = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Button Button1
	{
		[CompilerGenerated]
		get
		{
			return attributeFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineInterceptor;
			Button button = attributeFilter;
			if (button != null)
			{
				button.Click -= value2;
			}
			attributeFilter = value;
			button = attributeFilter;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal BackgroundWorker CalcInterceptor()
	{
		return m_EventFilter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RateInterceptor(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = RunInterceptor;
		RunWorkerCompletedEventHandler value2 = StartInterceptor;
		BackgroundWorker eventFilter = m_EventFilter;
		if (eventFilter != null)
		{
			eventFilter.DoWork -= value;
			eventFilter.RunWorkerCompleted -= value2;
		}
		m_EventFilter = backgroundWorker_0;
		eventFilter = m_EventFilter;
		if (eventFilter != null)
		{
			eventFilter.DoWork += value;
			eventFilter.RunWorkerCompleted += value2;
		}
	}

	public FloatingLicenseErrorForm()
	{
		base.Shown += PostInterceptor;
		base.Closed += AssetInterceptor;
		base.Closing += PrintInterceptor;
		ResolveInterceptor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_InitializerFilter != null)
			{
				m_InitializerFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ResolveInterceptor()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(FloatingLicenseErrorForm));
		Panel1 = new Panel();
		Label1 = new Label();
		Button1 = new Button();
		RateInterceptor(new BackgroundWorker());
		Panel1.SuspendLayout();
		SuspendLayout();
		Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel1.Controls.Add(Label1);
		Panel1.Location = new Point(12, 12);
		Panel1.Name = "Panel1";
		Panel1.Size = new Size(400, 112);
		Panel1.TabIndex = 1;
		Label1.AutoSize = true;
		Label1.Dock = DockStyle.Fill;
		Label1.Location = new Point(0, 0);
		Label1.MaximumSize = new Size(400, 0);
		Label1.Name = "Label1";
		Label1.Size = new Size(399, 52);
		Label1.TabIndex = 0;
		Label1.Text = componentResourceManager.GetString("Label1.Text");
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button1.Location = new Point(166, 139);
		Button1.Name = "Button1";
		Button1.Size = new Size(77, 23);
		Button1.TabIndex = 2;
		Button1.Text = "确定";
		Button1.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		base.ClientSize = new Size(424, 165);
		base.Controls.Add(Button1);
		base.Controls.Add(Panel1);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FloatingLicenseErrorForm";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "Error in validating floating license!";
		base.TopMost = true;
		Panel1.ResumeLayout(performLayout: false);
		Panel1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void PostInterceptor(object sender, EventArgs e)
	{
		Client.CurrentGame.Pause();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		string text = "There has been a problem in validating your floating license. The error message is: " + ErrorReason + "\r\n\r\nCommand is now saving the current state of your scenario to Autosave.scen...";
		Label1.Text = text;
		Button1.Enabled = false;
		CalcInterceptor().RunWorkerAsync();
	}

	private void RunInterceptor(object sender, DoWorkEventArgs e)
	{
		if (ScenarioToSave != null)
		{
			while (ScenarioToSave.ExecutionInProgress)
			{
				Thread.Sleep(10);
			}
			Client.PerformAutosave(ScenarioToSave);
		}
	}

	private void StartInterceptor(object sender, RunWorkerCompletedEventArgs e)
	{
		string text = "There has been a problem in validating your floating license. The error message is: \r\n\r\n";
		if (ScenarioToSave != null)
		{
			text += "Command saved the current state of your scenario to Autosave.scen.";
		}
		text += "Please click on 'OK' or close this window to exit the application.";
		Label1.Text = text;
		Button1.Enabled = true;
	}

	private void AssetInterceptor(object sender, EventArgs e)
	{
		ItemExporter.RevertInterruptibleMap.SortInterruptibleMap();
	}

	private void PrintInterceptor(object sender, CancelEventArgs e)
	{
		if (CalcInterceptor().IsBusy)
		{
			e.Cancel = true;
		}
	}

	private void DefineInterceptor(object sender, EventArgs e)
	{
		Close();
	}
}
