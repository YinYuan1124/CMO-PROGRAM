using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using MSDN.Html.Editor;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditBriefing : DarkSecondaryFormBase
{
	private IContainer bridgeWatcher;

	[AccessedThroughProperty("SplitContainer1")]
	[CompilerGenerated]
	private SplitContainer invocationWatcher;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _ClassWatcher;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton requestWatcher;

	[AccessedThroughProperty("Editor1")]
	[CompilerGenerated]
	private HtmlEditorControl valueWatcher;

	[AccessedThroughProperty("Button_EditHTML")]
	[CompilerGenerated]
	private DarkUIButton tokenizerWatcher;

	public Side theSelectedSide;

	private Keys[] m_StubWatcher;

	internal SplitContainer SplitContainer1
	{
		[CompilerGenerated]
		get
		{
			return invocationWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			invocationWatcher = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _ClassWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyMapping;
			DarkUIButton classWatcher = _ClassWatcher;
			if (classWatcher != null)
			{
				classWatcher.Click -= value2;
			}
			_ClassWatcher = value;
			classWatcher = _ClassWatcher;
			if (classWatcher != null)
			{
				classWatcher.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return requestWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchMapping;
			DarkUIButton darkUIButton = requestWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			requestWatcher = value;
			darkUIButton = requestWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	private HtmlEditorControl Editor1
	{
		[CompilerGenerated]
		get
		{
			return valueWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valueWatcher = value;
		}
	}

	internal DarkUIButton Button_EditHTML
	{
		[CompilerGenerated]
		get
		{
			return tokenizerWatcher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewMapping;
			DarkUIButton darkUIButton = tokenizerWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			tokenizerWatcher = value;
			darkUIButton = tokenizerWatcher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public EditBriefing()
	{
		base.Load += ComputeMapping;
		base.Shown += SelectMapping;
		base.ResizeEnd += CallMapping;
		base.FormClosing += LogoutMapping;
		m_StubWatcher = new Keys[1] { Keys.Escape };
		AddMapping();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && bridgeWatcher != null)
			{
				bridgeWatcher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AddMapping()
	{
		SplitContainer1 = new SplitContainer();
		Editor1 = new HtmlEditorControl();
		Button_EditHTML = new DarkUIButton();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.Panel2.SuspendLayout();
		SplitContainer1.SuspendLayout();
		SuspendLayout();
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.FixedPanel = FixedPanel.Panel2;
		SplitContainer1.Location = new Point(0, 0);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Orientation = Orientation.Horizontal;
		SplitContainer1.Panel1.Controls.Add(Editor1);
		SplitContainer1.Panel2.Controls.Add(Button_EditHTML);
		SplitContainer1.Panel2.Controls.Add(Button2);
		SplitContainer1.Panel2.Controls.Add(Button1);
		SplitContainer1.Size = new Size(709, 516);
		SplitContainer1.SplitterDistance = 476;
		SplitContainer1.TabIndex = 0;
		((Control)Editor1).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		((Control)Editor1).BackColor = Color.FromArgb(69, 73, 74);
		Editor1.BodyBackColor = Color.FromArgb(43, 43, 43);
		Editor1.BodyForeColor = Color.FromArgb(220, 220, 220);
		((Control)Editor1).ForeColor = Color.FromArgb(220, 220, 220);
		Editor1.InnerText = null;
		((Control)Editor1).Location = new Point(0, 0);
		((Control)Editor1).Name = "Editor1";
		((Control)Editor1).Size = new Size(709, 476);
		((Control)Editor1).TabIndex = 28;
		Button_EditHTML.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_EditHTML.Location = new Point(278, 7);
		Button_EditHTML.Name = "Button_EditHTML";
		Button_EditHTML.Size = new Size(144, 23);
		Button_EditHTML.TabIndex = 2;
		Button_EditHTML.Text = "编辑HTML";
		Button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.Location = new Point(629, 7);
		Button2.Name = "Button2";
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 1;
		Button2.Text = "取消";
		Button1.Location = new Point(9, 7);
		Button1.Name = "Button1";
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 0;
		Button1.Text = "确定";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.CancelButton = Button2;
		base.ClientSize = new Size(709, 516);
		base.Controls.Add(SplitContainer1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditBriefing";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "简报";
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] stubWatcher = m_StubWatcher;
		int num = 0;
		while (true)
		{
			if (num < stubWatcher.Length)
			{
				Keys keys = stubWatcher[num];
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

	private void DestroyMapping(object sender, EventArgs e)
	{
		Close();
	}

	private void ComputeMapping(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			Text = "编辑分方简报：" + theSelectedSide.Name;
			Button2.Visible = true;
			Button_EditHTML.Visible = true;
		}
		else
		{
			Text = "分方简报";
			Button2.Visible = false;
			Button_EditHTML.Visible = false;
		}
		if (!string.IsNullOrEmpty(theSelectedSide.Briefing))
		{
			if (string.IsNullOrEmpty(Client._PolicyClass))
			{
				Editor1.BodyHtml = theSelectedSide.Briefing.ToString();
			}
			else if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				Editor1.BodyHtml = theSelectedSide.Briefing.ToString();
			}
			else if (!ValidateMapping(Editor1, theSelectedSide.Briefing.ToString(), Path.GetDirectoryName(Client._PolicyClass)))
			{
				Editor1.BodyHtml = theSelectedSide.Briefing.ToString();
			}
		}
		Editor1.ToolbarVisible = true;
	}

	private void PatchMapping(object sender, EventArgs e)
	{
		if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			theSelectedSide.Briefing = Editor1.BodyHtml.Replace("<BODY scroll=auto><P>", "").Replace("</P></BODY>", "");
		}
		Close();
	}

	private void SelectMapping(object sender, EventArgs e)
	{
		if (base.Height != 510)
		{
			base.Width--;
			base.Width++;
		}
	}

	private void CallMapping(object sender, EventArgs e)
	{
		base.Width--;
		base.Width++;
	}

	private void LogoutMapping(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ViewMapping(object sender, EventArgs e)
	{
		Editor1.HtmlContentsEdit();
	}

	private bool ValidateMapping(HtmlEditorControl htmlEditorControl_0, string string_0, string string_1)
	{
		if (string_0.Contains("[LOADDOC]"))
		{
			int num = Strings.InStr(string_0, "[LOADDOC]", CompareMethod.Text) + "[LOADDOC]".Length - 1;
			int num2 = Strings.InStr(string_0, "[/LOADDOC]", CompareMethod.Text);
			string path = string_0.Substring(num, string_0.Length - num - (string_0.Length - num2 + 1));
			if (FileExistsNative.FileExistsFast(Path.Combine(string_1, path)))
			{
				htmlEditorControl_0.NavigateToUrl(Path.Combine(string_1, path));
				return true;
			}
			string campaignID = Client.CurrentScenario.CampaignID;
			Campaign campaignByID = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, campaignID);
			if (Information.IsNothing(campaignByID))
			{
				return false;
			}
			htmlEditorControl_0.NavigateToUrl(Path.Combine(campaignByID.FolderPath, path));
			return true;
		}
		return false;
	}
}
