using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class InsufficientLicenseWindow : DarkForm
{
	private IContainer m_RefContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("SplitContainer1")]
	private SplitContainer m_CodeContainer;

	[AccessedThroughProperty("FlowLayoutPanel1")]
	[CompilerGenerated]
	private FlowLayoutPanel connectionContainer;

	private List<Licensing.ModuleLicense> contextContainer;

	private string m_StatusContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("theButton")]
	private Button m_ProccesorContainer;

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal SplitContainer SplitContainer1
	{
		[CompilerGenerated]
		get
		{
			return m_CodeContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeContainer = value;
		}
	}

	internal FlowLayoutPanel FlowLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return connectionContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionContainer = value;
		}
	}

	public List<Licensing.ModuleLicense> theNeededModules
	{
		get
		{
			return contextContainer;
		}
		set
		{
			contextContainer = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private Button TestIterator()
	{
		return m_ProccesorContainer;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void StopIterator(Button button_0)
	{
		m_ProccesorContainer = button_0;
	}

	public InsufficientLicenseWindow()
	{
		base.Shown += PopIterator;
		base.Load += InstantiateIterator;
		base.Closing += DisableIterator;
		CalculateIterator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_RefContainer != null)
			{
				m_RefContainer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalculateIterator()
	{
		Label1 = new DarkLabel();
		SplitContainer1 = new SplitContainer();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.Panel2.SuspendLayout();
		SplitContainer1.SuspendLayout();
		SuspendLayout();
		Label1.BackColor = Color.Transparent;
		Label1.Dock = DockStyle.Fill;
		Label1.Font = new Font("Arial", 12f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.White;
		Label1.Location = new Point(0, 0);
		Label1.MaximumSize = new Size(700, 0);
		Label1.Name = "Label1";
		Label1.Size = new Size(374, 85);
		Label1.TabIndex = 3;
		Label1.Text = "要执行请求的操作，您需要获得以下产品的许可。单击产品图标以获取其许可证。";
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.FixedPanel = FixedPanel.Panel1;
		SplitContainer1.Location = new Point(0, 0);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Orientation = Orientation.Horizontal;
		SplitContainer1.Panel1.BackColor = Color.FromArgb(32, 32, 32);
		SplitContainer1.Panel1.Controls.Add(Label1);
		SplitContainer1.Panel2.Controls.Add(FlowLayoutPanel1);
		SplitContainer1.Size = new Size(374, 292);
		SplitContainer1.SplitterDistance = 85;
		SplitContainer1.TabIndex = 4;
		FlowLayoutPanel1.AutoScroll = true;
		FlowLayoutPanel1.BackColor = SystemColors.ControlDark;
		FlowLayoutPanel1.Dock = DockStyle.Fill;
		FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
		FlowLayoutPanel1.Location = new Point(0, 0);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(374, 203);
		FlowLayoutPanel1.TabIndex = 0;
		FlowLayoutPanel1.WrapContents = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		BackgroundImageLayout = ImageLayout.Center;
		base.ClientSize = new Size(374, 292);
		base.Controls.Add(SplitContainer1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "InsufficientLicenseWindow";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		base.TopMost = true;
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void PopIterator(object sender, EventArgs e)
	{
		List<Licensing.InfoProcessResolver> list = Licensing.RunRole(theNeededModules);
		string text = "要执行请求的操作，您需要许可证";
		text = ((list.Count == 1) ? (text + "以下产品。单击产品图标以获取其许可证。") : (text + "以下任何产品。单击任何产品图标以获取其许可证。"));
		Label1.Text = text;
		int num = 0;
		foreach (Licensing.InfoProcessResolver item in list)
		{
			StopIterator(new Button());
			TestIterator().Height = 161;
			TestIterator().Width = 345;
			num += TestIterator().Height + 30;
			try
			{
				Bitmap image_ = (Bitmap)Image.FromFile(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Symbols\\Menu\\" + item._RefMap);
				image_ = InterpreterObjectListener.ListInterruptibleTask(image_, new Size(345, 161));
				TestIterator().Image = image_;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			m_StatusContainer = item._SerializerMap;
			if (Client.RunningInSteamMode)
			{
				m_StatusContainer = "http://store.steampowered.com/app/" + Conversions.ToString(item._ModelMap.m_AppId);
			}
			TestIterator().Tag = m_StatusContainer;
			FlowLayoutPanel1.Controls.Add(TestIterator());
			TestIterator().Click += CreateIterator;
			TestIterator().MouseEnter += CompareIterator;
			TestIterator().MouseLeave += ReadIterator;
		}
		base.Height = SplitContainer1.Panel1.Height + num;
		if (base.Height < 300)
		{
			base.Height = 300;
		}
		InterpreterObjectListener.ShowScrollBar(FlowLayoutPanel1.Handle, 1, bool_0: true);
	}

	private void InstantiateIterator(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void CreateIterator(object sender, EventArgs e)
	{
		Process.Start(Conversions.ToString(((Button)sender).Tag));
	}

	private void CompareIterator(object sender, EventArgs e)
	{
		Cursor = Cursors.Hand;
	}

	private void ReadIterator(object sender, EventArgs e)
	{
		Cursor = Cursors.Arrow;
	}

	private void DisableIterator(object sender, CancelEventArgs e)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = FlowLayoutPanel1.Controls.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
				StopIterator((Button)objectValue);
				TestIterator().Click -= CreateIterator;
				TestIterator().MouseEnter -= CompareIterator;
				TestIterator().MouseLeave -= ReadIterator;
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}
}
