using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ScenAttachmentsWindow : DarkSecondaryFormBase
{
	private IContainer consumerSingleton;

	[AccessedThroughProperty("ListBox1")]
	[CompilerGenerated]
	private DarkListView facadeSingleton;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton readerSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton2")]
	private ToolStripButton m_PropertySingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("TSCB1")]
	private ToolStripComboBox importerSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton3")]
	private ToolStripButton _RepositorySingleton;

	[AccessedThroughProperty("PropertyGrid1")]
	[CompilerGenerated]
	private PropertyGrid m_BridgeSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_InvocationSingleton;

	private Keys[] classSingleton;

	internal DarkListView ListBox1
	{
		[CompilerGenerated]
		get
		{
			return facadeSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeInterruptiblePublisher;
			DarkListView darkListView = facadeSingleton;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			facadeSingleton = value;
			darkListView = facadeSingleton;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

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
			return readerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintInterruptiblePublisher;
			ToolStripButton toolStripButton = readerSingleton;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			readerSingleton = value;
			toolStripButton = readerSingleton;
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
			return m_PropertySingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineInterruptiblePublisher;
			ToolStripButton propertySingleton = m_PropertySingleton;
			if (propertySingleton != null)
			{
				propertySingleton.Click -= value2;
			}
			m_PropertySingleton = value;
			propertySingleton = m_PropertySingleton;
			if (propertySingleton != null)
			{
				propertySingleton.Click += value2;
			}
		}
	}

	internal ToolStripComboBox TSCB1
	{
		[CompilerGenerated]
		get
		{
			return importerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			importerSingleton = value;
		}
	}

	internal ToolStripButton ToolStripButton3
	{
		[CompilerGenerated]
		get
		{
			return _RepositorySingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishInterruptiblePublisher;
			ToolStripButton repositorySingleton = _RepositorySingleton;
			if (repositorySingleton != null)
			{
				repositorySingleton.Click -= value2;
			}
			_RepositorySingleton = value;
			repositorySingleton = _RepositorySingleton;
			if (repositorySingleton != null)
			{
				repositorySingleton.Click += value2;
			}
		}
	}

	internal PropertyGrid PropertyGrid1
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BridgeSingleton = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationSingleton = value;
		}
	}

	public ScenAttachmentsWindow()
	{
		base.Shown += AssetInterruptiblePublisher;
		base.Load += QueryInterruptiblePublisher;
		classSingleton = new Keys[1] { Keys.Escape };
		StartInterruptiblePublisher();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && consumerSingleton != null)
			{
				consumerSingleton.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void StartInterruptiblePublisher()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(ScenAttachmentsWindow));
		ListBox1 = new DarkListView();
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		TSCB1 = new ToolStripComboBox();
		ToolStripButton3 = new ToolStripButton();
		ToolStripButton2 = new ToolStripButton();
		PropertyGrid1 = new PropertyGrid();
		Label1 = new DarkLabel();
		ToolStrip1.SuspendLayout();
		SuspendLayout();
		ListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ListBox1.Location = new Point(0, 25);
		ListBox1.Name = "ListBox1";
		ListBox1.Size = new Size(530, 264);
		ListBox1.TabIndex = 3;
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[4] { ToolStripButton1, TSCB1, ToolStripButton3, ToolStripButton2 });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(742, 25);
		ToolStrip1.TabIndex = 2;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripButton1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton1.ImageTransparentColor = Color.Magenta;
		ToolStripButton1.Name = "ToolStripButton1";
		ToolStripButton1.Size = new Size(119, 22);
		ToolStripButton1.Text = "创建新类型：";
		TSCB1.BackColor = Color.FromArgb(60, 63, 65);
		TSCB1.DropDownStyle = ComboBoxStyle.DropDownList;
		TSCB1.ForeColor = Color.FromArgb(220, 220, 220);
		TSCB1.Items.AddRange(new object[6] { "地图叠加（单个图像）", "Lua脚本", "导入Inst", "本地视频", "本地音频", "Local HTML" });
		TSCB1.Name = "TSCB1";
		TSCB1.Size = new Size(180, 25);
		ToolStripButton3.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton3.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton3.Image = componentResourceManager.GetObject("ToolStripButton3.Image");
		ToolStripButton3.ImageTransparentColor = Color.Magenta;
		ToolStripButton3.Name = "ToolStripButton3";
		ToolStripButton3.Size = new Size(92, 22);
		ToolStripButton3.Text = "添加现有";
		ToolStripButton2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton2.Image = componentResourceManager.GetObject("ToolStripButton2.Image");
		ToolStripButton2.ImageTransparentColor = Color.Magenta;
		ToolStripButton2.Name = "ToolStripButton2";
		ToolStripButton2.Size = new Size(117, 22);
		ToolStripButton2.Text = "删除选定";
		PropertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		PropertyGrid1.CategoryForeColor = SystemColors.InactiveCaptionText;
		PropertyGrid1.Location = new Point(536, 25);
		PropertyGrid1.Name = "PropertyGrid1";
		PropertyGrid1.Size = new Size(206, 264);
		PropertyGrid1.TabIndex = 4;
		Label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label1.BackColor = Color.Transparent;
		Label1.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(535, 4);
		Label1.Name = "Label1";
		Label1.Size = new Size(128, 15);
		Label1.TabIndex = 5;
		Label1.Text = "所选属性：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(742, 288);
		base.Controls.Add(Label1);
		base.Controls.Add(PropertyGrid1);
		base.Controls.Add(ListBox1);
		base.Controls.Add(ToolStrip1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ScenAttachmentsWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "想定附件";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = classSingleton;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys keys = array[num];
				if (keyData == keys)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		Close();
		return true;
	}

	private void AssetInterruptiblePublisher(object sender, EventArgs e)
	{
		TSCB1.SelectedIndex = 0;
		RefreshAttachments();
	}

	public void RefreshAttachments()
	{
		ListBox1.Items.Clear();
		foreach (KeyValuePair<string, ScenAttachmentObject> scenAttachment in Client.CurrentScenario.ScenAttachments)
		{
			DarkListItem darkListItem = new DarkListItem(scenAttachment.Value.Description);
			darkListItem.Tag = scenAttachment.Key;
			ListBox1.Items.Add(darkListItem);
		}
	}

	private void PrintInterruptiblePublisher(object sender, EventArgs e)
	{
		LoadAttachment();
		RefreshAttachments();
	}

	public void LoadAttachment()
	{
		switch (TSCB1.SelectedIndex)
		{
		case 0:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().InitialDirectory = GameGeneral.TopLevelWritablePath;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().Filter = "Image file (*.*)|*.*";
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName = "";
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				string fileName4 = ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName;
				SAO_OverlaySingle sAO_OverlaySingle = new SAO_OverlaySingle();
				sAO_OverlaySingle.ImageFileName = Path.GetFileName(fileName4);
				sAO_OverlaySingle.Description = "地图叠加图片：" + sAO_OverlaySingle.ImageFileName;
				sAO_OverlaySingle.CopyToLocalRepository(fileName4);
				sAO_OverlaySingle.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_OverlaySingle.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_OverlaySingle.ObjectID, sAO_OverlaySingle);
				break;
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception exception_4 = ex4;
				exception_4?.Data.Add("Error at 200395", exception_4.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 1:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().InitialDirectory = GameGeneral.TopLevelWritablePath;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().Filter = "Lua脚本文件 (*.lua)|* .lua";
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName = "";
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				string fileName6 = ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName;
				SAO_LuaScript sAO_LuaScript = new SAO_LuaScript();
				sAO_LuaScript.ScriptFileName = Path.GetFileName(fileName6);
				sAO_LuaScript.Description = "Lua脚本：" + sAO_LuaScript.ScriptFileName;
				sAO_LuaScript.CopyToLocalRepository(fileName6);
				sAO_LuaScript.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LuaScript.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LuaScript.ObjectID, sAO_LuaScript);
				break;
			}
			catch (Exception ex6)
			{
				ProjectData.SetProjectError(ex6);
				Exception exception_6 = ex6;
				exception_6?.Data.Add("Error at 200396", exception_6.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 2:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().InitialDirectory = GameGeneral.TopLevelWritablePath;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().Filter = "Inst 导入文件 (*.inst)|*.inst";
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName = "";
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				string fileName2 = ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName;
				SAO_Inst sAO_Inst = new SAO_Inst();
				sAO_Inst.InstFileName = Path.GetFileName(fileName2);
				sAO_Inst.Description = "Inst文件：" + sAO_Inst.InstFileName;
				sAO_Inst.CopyToLocalRepository(fileName2);
				sAO_Inst.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_Inst.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_Inst.ObjectID, sAO_Inst);
				break;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 200397", exception_2.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 3:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().InitialDirectory = GameGeneral.TopLevelWritablePath;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().Filter = "视频文件（*.*）| *.*";
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName = "";
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				string fileName5 = ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName;
				SAO_LocalVideo sAO_LocalVideo = new SAO_LocalVideo();
				sAO_LocalVideo.VideoFileName = Path.GetFileName(fileName5);
				sAO_LocalVideo.Description = "本地视频：" + sAO_LocalVideo.VideoFileName;
				sAO_LocalVideo.CopyToLocalRepository(fileName5);
				sAO_LocalVideo.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LocalVideo.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LocalVideo.ObjectID, sAO_LocalVideo);
				break;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception exception_5 = ex5;
				exception_5?.Data.Add("Error at 200398", exception_5.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_5);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 4:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().InitialDirectory = GameGeneral.TopLevelWritablePath;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().Filter = "声音文件 (*.*)|*.*";
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName = "";
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				string fileName3 = ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName;
				SAO_LocalSound sAO_LocalSound = new SAO_LocalSound();
				sAO_LocalSound.SoundFileName = Path.GetFileName(fileName3);
				sAO_LocalSound.Description = "本地声音：" + sAO_LocalSound.SoundFileName;
				sAO_LocalSound.CopyToLocalRepository(fileName3);
				sAO_LocalSound.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LocalSound.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LocalSound.ObjectID, sAO_LocalSound);
				break;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception_3 = ex3;
				exception_3?.Data.Add("Error at 200399", exception_3.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_3);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		case 5:
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().InitialDirectory = GlobalVariables.ApplicationStartupPath;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().Filter = "HTML file (*.*)|*.*";
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().ShowDialog() != DialogResult.OK)
			{
				break;
			}
			try
			{
				string fileName = ItemExporter.ConnectInterruptibleTemplate.MainForm.FlushProducer().FileName;
				SAO_LocalHTML sAO_LocalHTML = new SAO_LocalHTML();
				sAO_LocalHTML.HTMLFileName = Path.GetFileName(fileName);
				sAO_LocalHTML.Description = "Local HTML: " + sAO_LocalHTML.HTMLFileName;
				sAO_LocalHTML.CopyToLocalRepository(fileName);
				sAO_LocalHTML.vmethod_0(Path.Combine(GameGeneral.AttachmentRepoPath, sAO_LocalHTML.ObjectID));
				Client.CurrentScenario.ScenAttachments.Add(sAO_LocalHTML.ObjectID, sAO_LocalHTML);
				break;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 200399", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				break;
			}
		}
	}

	private void DefineInterruptiblePublisher(object sender, EventArgs e)
	{
		foreach (DarkListItem selectedItem in ListBox1.SelectedItems)
		{
			Client.CurrentScenario.ScenAttachments.Remove(selectedItem.Tag.ToString());
		}
		RefreshAttachments();
	}

	public void RefreshForm()
	{
		RefreshAttachments();
	}

	private void PublishInterruptiblePublisher(object sender, EventArgs e)
	{
		bool flag = false;
		if (ItemExporter.ConnectInterruptibleTemplate.StopInterruptibleBase().ShowDialog() == DialogResult.OK)
		{
			foreach (ScenAttachmentObject selectedSAO in ItemExporter.ConnectInterruptibleTemplate.StopInterruptibleBase().SelectedSAOs)
			{
				if (!Client.CurrentScenario.ScenAttachments.ContainsKey(selectedSAO.ObjectID))
				{
					Client.CurrentScenario.ScenAttachments.Add(selectedSAO.ObjectID, selectedSAO);
					flag = true;
				}
			}
			RefreshAttachments();
		}
		if (flag)
		{
			RefreshAttachments();
		}
	}

	private void AwakeInterruptiblePublisher(object sender, EventArgs e)
	{
		if (ListBox1.SelectedItems.Count <= 0)
		{
			PropertyGrid1.SelectedObject = null;
		}
		else
		{
			PropertyGrid1.SelectedObject = Client.CurrentScenario.ScenAttachments[Conversions.ToString(ListBox1.SelectedItems[0].Tag).ToString()];
		}
	}

	private void QueryInterruptiblePublisher(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
