using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class SatelliteCustomOrbit : CommandSecondaryFormBase
{
	private IContainer _SpecificationPredicate;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private TextBox watcherPredicate;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private Button m_ReponsePredicate;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private Button descriptorPredicate;

	public string SatelliteObjectID;

	internal TextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return watcherPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			watcherPredicate = value;
		}
	}

	internal Button Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ReponsePredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewInterruptibleIndexer;
			Button reponsePredicate = m_ReponsePredicate;
			if (reponsePredicate != null)
			{
				reponsePredicate.Click -= value2;
			}
			m_ReponsePredicate = value;
			reponsePredicate = m_ReponsePredicate;
			if (reponsePredicate != null)
			{
				reponsePredicate.Click += value2;
			}
		}
	}

	internal Button Button2
	{
		[CompilerGenerated]
		get
		{
			return descriptorPredicate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushInterruptibleIndexer;
			Button button = descriptorPredicate;
			if (button != null)
			{
				button.Click -= value2;
			}
			descriptorPredicate = value;
			button = descriptorPredicate;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public SatelliteCustomOrbit()
	{
		base.FormClosing += GetInterruptibleIndexer;
		base.Load += WriteInterruptibleIndexer;
		base.KeyDown += InvokeInterruptibleIndexer;
		LoginInterruptibleIndexer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _SpecificationPredicate != null)
			{
				_SpecificationPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void LoginInterruptibleIndexer()
	{
		SuspendLayout();
		base.ClientSize = new Size(428, 352);
		base.Name = "SatelliteCustomOrbit";
		ResumeLayout(performLayout: false);
	}

	private void GetInterruptibleIndexer(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
		if (!Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.AirOps) && ItemExporter.ConnectInterruptibleTemplate.AirOps.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AirOps.RefreshForm();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		if (ItemExporter.ConnectInterruptibleTemplate.ScenAttachmentsWindow.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.ScenAttachmentsWindow.RefreshForm();
		}
	}

	private void WriteInterruptibleIndexer(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
	}

	private void NewInterruptibleIndexer(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Close();
	}

	private void PushInterruptibleIndexer(object sender, EventArgs e)
	{
		Close();
	}

	private void InvokeInterruptibleIndexer(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void SetupInterruptibleIndexer(object sender, EventArgs e)
	{
	}
}
