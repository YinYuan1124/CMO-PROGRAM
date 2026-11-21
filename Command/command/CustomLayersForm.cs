using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using DXRenderer;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CustomLayersForm : DarkSecondaryFormBase
{
	private IContainer m_BridgeValue;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton classValue;

	[AccessedThroughProperty("ToolStripButton2")]
	[CompilerGenerated]
	private ToolStripButton _RequestValue;

	[CompilerGenerated]
	[AccessedThroughProperty("ListBox1")]
	private DarkListView m_ValueValue;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal DarkToolStrip ToolStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return classValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallPublisher;
			ToolStripButton toolStripButton = classValue;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			classValue = value;
			toolStripButton = classValue;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton ToolStripButton2
	{
		[CompilerGenerated]
		get
		{
			return _RequestValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutPublisher;
			ToolStripButton requestValue = _RequestValue;
			if (requestValue != null)
			{
				requestValue.Click -= value2;
			}
			_RequestValue = value;
			requestValue = _RequestValue;
			if (requestValue != null)
			{
				requestValue.Click += value2;
			}
		}
	}

	internal DarkListView ListBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ValueValue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValueValue = value;
		}
	}

	public CustomLayersForm()
	{
		base.Shown += SelectPublisher;
		base.KeyDown += ViewPublisher;
		base.FormClosing += ValidatePublisher;
		base.Load += LoginPublisher;
		PatchPublisher();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_BridgeValue != null)
			{
				m_BridgeValue.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PatchPublisher()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(CustomLayersForm));
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		ToolStripButton2 = new ToolStripButton();
		ListBox1 = new DarkListView();
		ToolStrip1.SuspendLayout();
		SuspendLayout();
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[2] { ToolStripButton1, ToolStripButton2 });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(727, 25);
		ToolStrip1.TabIndex = 0;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripButton1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton1.Image = componentResourceManager.GetObject("ToolStripButton1.Image");
		ToolStripButton1.ImageTransparentColor = Color.Magenta;
		ToolStripButton1.Name = "ToolStripButton1";
		ToolStripButton1.Size = new Size(80, 22);
		ToolStripButton1.Text = "添加图层";
		ToolStripButton2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton2.Image = componentResourceManager.GetObject("ToolStripButton2.Image");
		ToolStripButton2.ImageTransparentColor = Color.Magenta;
		ToolStripButton2.Name = "ToolStripButton2";
		ToolStripButton2.Size = new Size(117, 22);
		ToolStripButton2.Text = "删除选定";
		ListBox1.Dock = DockStyle.Fill;
		ListBox1.Location = new Point(0, 25);
		ListBox1.Name = "ListBox1";
		ListBox1.Size = new Size(727, 282);
		ListBox1.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(727, 307);
		base.Controls.Add(ListBox1);
		base.Controls.Add(ToolStrip1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CustomLayersForm";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "定制层管理";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	public void RefreshCustomLayers()
	{
		ListBox1.Items.Clear();
		string[] array = Main.Instance.CustomOverlayNames();
		string[] array2 = array;
		foreach (string text in array2)
		{
			DarkListItem darkListItem = new DarkListItem(text);
			darkListItem.Tag = text;
			ListBox1.Items.Add(darkListItem);
		}
	}

	private void SelectPublisher(object sender, EventArgs e)
	{
		RefreshCustomLayers();
	}

	private void CallPublisher(object sender, EventArgs e)
	{
		Client.LoadCustomLayer_Dialog();
		RefreshCustomLayers();
	}

	private void LogoutPublisher(object sender, EventArgs e)
	{
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			Main instance = Main.Instance;
			_ = Client.CurrentMapProfile;
			instance?.RemoveCustomOverlay(selectedItem.Tag.ToString());
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Geo();
		RefreshCustomLayers();
	}

	private void ViewPublisher(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ValidatePublisher(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void LoginPublisher(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
