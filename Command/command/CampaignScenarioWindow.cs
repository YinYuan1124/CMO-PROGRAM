using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CampaignScenarioWindow : DarkSecondaryFormBase
{
	private IContainer indexerInvocation;

	[AccessedThroughProperty("WebBrowser1")]
	[CompilerGenerated]
	private WebBrowser m_ResolverInvocation;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_ServerInvocation;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton m_AdapterInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("PB_PercentComplete")]
	private DarkUIProgressBar m_SchemaInvocation;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer _PredicateInvocation;

	public Campaign SelectedCampaign;

	public string ScenFileName;

	public string CampaignSessionID;

	public int CampaignScore;

	public string LuaXml;

	private Scenario m_SingletonInvocation;

	[AccessedThroughProperty("theBW")]
	[CompilerGenerated]
	private BackgroundWorker m_RecordInvocation;

	private double exceptionInvocation;

	private ScenContainer m_AttrInvocation;

	internal WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ResolverInvocation = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ServerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetProccesor;
			DarkUIButton serverInvocation = m_ServerInvocation;
			if (serverInvocation != null)
			{
				serverInvocation.Click -= value2;
			}
			m_ServerInvocation = value;
			serverInvocation = m_ServerInvocation;
			if (serverInvocation != null)
			{
				serverInvocation.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginProccesor;
			DarkUIButton adapterInvocation = m_AdapterInvocation;
			if (adapterInvocation != null)
			{
				adapterInvocation.Click -= value2;
			}
			m_AdapterInvocation = value;
			adapterInvocation = m_AdapterInvocation;
			if (adapterInvocation != null)
			{
				adapterInvocation.Click += value2;
			}
		}
	}

	internal DarkUIProgressBar PB_PercentComplete
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SchemaInvocation = value;
		}
	}

	[field: AccessedThroughProperty("Label_Loading")]
	internal DarkLabel Label_Loading
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer RemoveProccesor()
	{
		return _PredicateInvocation;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void FindProccesor(Timer timer_0)
	{
		EventHandler value = ValidateProccesor;
		Timer predicateInvocation = _PredicateInvocation;
		if (predicateInvocation != null)
		{
			predicateInvocation.Tick -= value;
		}
		_PredicateInvocation = timer_0;
		predicateInvocation = _PredicateInvocation;
		if (predicateInvocation != null)
		{
			predicateInvocation.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker FillProccesor()
	{
		return m_RecordInvocation;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void CalculateProccesor(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = CallProccesor;
		RunWorkerCompletedEventHandler value2 = LogoutProccesor;
		BackgroundWorker recordInvocation = m_RecordInvocation;
		if (recordInvocation != null)
		{
			recordInvocation.DoWork -= value;
			recordInvocation.RunWorkerCompleted -= value2;
		}
		m_RecordInvocation = backgroundWorker_0;
		recordInvocation = m_RecordInvocation;
		if (recordInvocation != null)
		{
			recordInvocation.DoWork += value;
			recordInvocation.RunWorkerCompleted += value2;
		}
	}

	public CampaignScenarioWindow()
	{
		base.Shown += SelectProccesor;
		base.Load += WriteProccesor;
		CalculateProccesor(new BackgroundWorker());
		PatchProccesor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && indexerInvocation != null)
			{
				indexerInvocation.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PatchProccesor()
	{
		indexerInvocation = new Container();
		FindProccesor(new Timer(indexerInvocation));
		PB_PercentComplete = new DarkUIProgressBar();
		Label_Loading = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		WebBrowser1 = new WebBrowser();
		SuspendLayout();
		RemoveProccesor().Interval = 50;
		PB_PercentComplete.Anchor = AnchorStyles.Bottom;
		PB_PercentComplete.BackColor = Color.Transparent;
		PB_PercentComplete.CustomForeColor = Color.Transparent;
		PB_PercentComplete.Font = new Font("Segoe UI", 9f);
		PB_PercentComplete.Location = new Point(309, 605);
		PB_PercentComplete.Maximum = 100;
		PB_PercentComplete.Name = "PB_PercentComplete";
		PB_PercentComplete.ShowProgressLines = true;
		PB_PercentComplete.ShowProgressValue = false;
		PB_PercentComplete.ShowText = false;
		PB_PercentComplete.Size = new Size(359, 12);
		PB_PercentComplete.TabIndex = 21;
		PB_PercentComplete.Value = 0;
		Label_Loading.Anchor = AnchorStyles.Bottom;
		Label_Loading.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Loading.Location = new Point(461, 588);
		Label_Loading.Name = "Label_Loading";
		Label_Loading.Size = new Size(54, 13);
		Label_Loading.TabIndex = 22;
		Label_Loading.Text = "载入中...";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(735, 588);
		Button2.Name = "Button2";
		Button2.Padding = new Padding(5);
		Button2.RoundRadius = 0;
		Button2.Size = new Size(249, 29);
		Button2.TabIndex = 20;
		Button2.Text = "取消（返回战役）";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(1, 588);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.RoundRadius = 0;
		Button1.Size = new Size(249, 29);
		Button1.TabIndex = 19;
		Button1.Text = "开始想定";
		Label1.AutoSize = true;
		Label1.Cursor = Cursors.Arrow;
		Label1.Font = new Font("Arial", 36f);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(3, 3);
		Label1.Name = "Label1";
		Label1.Size = new Size(312, 55);
		Label1.TabIndex = 18;
		Label1.Text = "想定标题";
		WebBrowser1.AllowNavigation = false;
		WebBrowser1.AllowWebBrowserDrop = false;
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.IsWebBrowserContextMenuEnabled = false;
		WebBrowser1.Location = new Point(1, 61);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(983, 507);
		WebBrowser1.TabIndex = 17;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(985, 618);
		base.ControlBox = false;
		base.Controls.Add(PB_PercentComplete);
		base.Controls.Add(Label_Loading);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label1);
		base.Controls.Add(WebBrowser1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CampaignScenarioWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "战役想定";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void SelectProccesor(object sender, EventArgs e)
	{
		m_AttrInvocation = ScenContainer.LoadFromFile(ScenFileName);
		RemoveProccesor().Start();
		Button1.Enabled = false;
		Label_Loading.Visible = true;
		PB_PercentComplete.Visible = true;
		string string_ = Scenario.QueryScenario_ScenXML(m_AttrInvocation.GetScenarioObject_AsXML(), "ContentTag");
		if (Licensing.IsUserLicensedForThisContent(string_))
		{
			FillProccesor().RunWorkerAsync();
			WebBrowser1.Visible = true;
			string localizedDescription = Localization.ScenarioText(ScenFileName, "Description", m_AttrInvocation.ScenDescription);
			if (!ViewProccesor(WebBrowser1, localizedDescription, Path.GetDirectoryName(ScenFileName)))
			{
				InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, localizedDescription);
			}
			Label1.Text = Localization.ScenarioText(ScenFileName, "Title", m_AttrInvocation.ScenTitle);
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent(string_) };
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
			Close();
		}
	}

	private void CallProccesor(object sender, DoWorkEventArgs e)
	{
		m_SingletonInvocation = m_AttrInvocation.GetScenarioObject(ref Client.authenticationClass, delegate(double double_0)
		{
			exceptionInvocation = double_0;
		}, bool_0: false);
		if (m_SingletonInvocation.ScenAttachments.Count > 0)
		{
			AttachmentRepoManager.MoveAttachmentsToLocalRepo(m_SingletonInvocation, ScenFileName);
		}
	}

	private void LogoutProccesor(object sender, RunWorkerCompletedEventArgs e)
	{
		Label_Loading.Visible = false;
		PB_PercentComplete.Visible = false;
		Button1.Enabled = true;
	}

	private bool ViewProccesor(WebBrowser webBrowser_0, string string_0, string string_1)
	{
		if (string_0.Contains("[LOADDOC]"))
		{
			int num = Strings.InStr(string_0, "[LOADDOC]", CompareMethod.Text) + "[LOADDOC]".Length - 1;
			int num2 = Strings.InStr(string_0, "[/LOADDOC]", CompareMethod.Text);
			string path = string_0.Substring(num, string_0.Length - num - (string_0.Length - num2 + 1));
			if (FileExistsNative.FileExistsFast(Path.Combine(string_1, path)))
			{
				webBrowser_0.Navigate(Path.Combine(string_1, path));
				return true;
			}
			string text = m_AttrInvocation.CampaignID;
			if (string.IsNullOrEmpty(text))
			{
				text = Scenario.QueryScenario_ScenXML(m_AttrInvocation.GetScenarioObject_AsXML(), "CampaignID");
			}
			Campaign campaignByID = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, text);
			if (Information.IsNothing(campaignByID))
			{
				return false;
			}
			webBrowser_0.Navigate(Path.Combine(campaignByID.FolderPath, path));
			return true;
		}
		return false;
	}

	private void ValidateProccesor(object sender, EventArgs e)
	{
		PB_PercentComplete.Value = (int)Math.Round(exceptionInvocation * 100.0);
	}

	private void LoginProccesor(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.CampaignPlayWindow.Show();
		Close();
	}

	private void GetProccesor(object sender, EventArgs e)
	{
		m_SingletonInvocation.CampaignSessionID = CampaignSessionID;
		m_SingletonInvocation.CampaignID = SelectedCampaign.ID;
		m_SingletonInvocation.CampaignScore = CampaignScore;
		m_SingletonInvocation.LuaXmlPassed = LuaXml;
		Client.SetCurrentScenario(m_SingletonInvocation, bool_0: false);
		Client.HandleScenarioLoaded(Client.CurrentScenario, ScenFileName);
		if (Client.CurrentGame.GameMode != 0)
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		}
		List<string> list = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		string string_ = null;
		foreach (string item in list)
		{
			if (Operators.CompareString(Campaign.ReadFromFile(item).ID, Client.CurrentScenario.CampaignID, TextCompare: true) == 0)
			{
				string_ = Path.Combine(Path.GetDirectoryName(item), Guid.NewGuid().ToString() + ".save");
				break;
			}
		}
		Client.SaveCurrentScenario(bool_0: false, string_, bool_1: true);
		Close();
	}

	private void WriteProccesor(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	[CompilerGenerated]
	private void NewProccesor(double double_0)
	{
		exceptionInvocation = double_0;
	}
}
