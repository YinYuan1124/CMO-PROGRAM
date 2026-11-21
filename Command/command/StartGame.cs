using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command.Records;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class StartGame : DarkSecondaryFormBase
{
	private IContainer m_DispatcherException;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	private DarkGroupBox m_ListenerException;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	private DarkGroupBox m_ConfigException;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton _DefinitionException;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _ValException;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton wrapperException;

	[AccessedThroughProperty("Button4")]
	[CompilerGenerated]
	private DarkUIButton m_ObserverException;

	[AccessedThroughProperty("Button5")]
	[CompilerGenerated]
	private DarkUIButton m_IssuerException;

	[CompilerGenerated]
	[AccessedThroughProperty("Button6")]
	private DarkUIButton _ClientException;

	[AccessedThroughProperty("Button_Campaign")]
	[CompilerGenerated]
	private DarkUIButton _DicException;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_QuickBattle")]
	private DarkUIButton _ConsumerException;

	internal DarkGroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ListenerException = value;
		}
	}

	internal DarkGroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConfigException = value;
		}
	}

	[field: AccessedThroughProperty("PictureBox1")]
	internal PictureBox PictureBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateInterruptibleSingleton;
			DarkUIButton definitionException = _DefinitionException;
			if (definitionException != null)
			{
				definitionException.Click -= value2;
			}
			_DefinitionException = value;
			definitionException = _DefinitionException;
			if (definitionException != null)
			{
				definitionException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _ValException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotInterruptibleSingleton;
			DarkUIButton valException = _ValException;
			if (valException != null)
			{
				valException.Click -= value2;
			}
			_ValException = value;
			valException = _ValException;
			if (valException != null)
			{
				valException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return wrapperException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcInterruptibleSingleton;
			DarkUIButton darkUIButton = wrapperException;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			wrapperException = value;
			darkUIButton = wrapperException;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushInterruptibleSingleton;
			DarkUIButton observerException = m_ObserverException;
			if (observerException != null)
			{
				observerException.Click -= value2;
			}
			m_ObserverException = value;
			observerException = m_ObserverException;
			if (observerException != null)
			{
				observerException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button5
	{
		[CompilerGenerated]
		get
		{
			return m_IssuerException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectInterruptibleSingleton;
			DarkUIButton issuerException = m_IssuerException;
			if (issuerException != null)
			{
				issuerException.Click -= value2;
			}
			m_IssuerException = value;
			issuerException = m_IssuerException;
			if (issuerException != null)
			{
				issuerException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button6
	{
		[CompilerGenerated]
		get
		{
			return _ClientException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageInterruptibleSingleton;
			DarkUIButton clientException = _ClientException;
			if (clientException != null)
			{
				clientException.Click -= value2;
			}
			_ClientException = value;
			clientException = _ClientException;
			if (clientException != null)
			{
				clientException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_Campaign
	{
		[CompilerGenerated]
		get
		{
			return _DicException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeInterruptibleRecord;
			DarkUIButton dicException = _DicException;
			if (dicException != null)
			{
				dicException.Click -= value2;
			}
			_DicException = value;
			dicException = _DicException;
			if (dicException != null)
			{
				dicException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_QuickBattle
	{
		[CompilerGenerated]
		get
		{
			return _ConsumerException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneInterruptibleRecord;
			DarkUIButton consumerException = _ConsumerException;
			if (consumerException != null)
			{
				consumerException.Click -= value2;
			}
			_ConsumerException = value;
			consumerException = _ConsumerException;
			if (consumerException != null)
			{
				consumerException.Click += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_DispatcherException != null)
			{
				m_DispatcherException.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SortInterruptibleSingleton()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(StartGame));
		GroupBox1 = new DarkGroupBox();
		Button_QuickBattle = new DarkUIButton();
		Button_Campaign = new DarkUIButton();
		Button6 = new DarkUIButton();
		Button4 = new DarkUIButton();
		Button3 = new DarkUIButton();
		GroupBox2 = new DarkGroupBox();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Button5 = new DarkUIButton();
		PictureBox1 = new PictureBox();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)PictureBox1).BeginInit();
		SuspendLayout();
		GroupBox1.Controls.Add(Button_QuickBattle);
		GroupBox1.Controls.Add(Button_Campaign);
		GroupBox1.Controls.Add(Button6);
		GroupBox1.Controls.Add(Button4);
		GroupBox1.Controls.Add(Button3);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(491, 3);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(211, 160);
		GroupBox1.TabIndex = 0;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "开始推演";
		Button_QuickBattle.BackColor = Color.Transparent;
		Button_QuickBattle.DialogResult = DialogResult.None;
		Button_QuickBattle.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button_QuickBattle.Location = new Point(5, 15);
		Button_QuickBattle.Name = "Button_QuickBattle";
		Button_QuickBattle.RoundRadius = 0;
		Button_QuickBattle.Size = new Size(200, 23);
		Button_QuickBattle.TabIndex = 6;
		Button_QuickBattle.Text = "快速生成想定";
		Button_Campaign.BackColor = Color.Transparent;
		Button_Campaign.DialogResult = DialogResult.None;
		Button_Campaign.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button_Campaign.Location = new Point(5, 43);
		Button_Campaign.Name = "Button_Campaign";
		Button_Campaign.Padding = new Padding(5);
		Button_Campaign.RoundRadius = 0;
		Button_Campaign.Size = new Size(200, 23);
		Button_Campaign.TabIndex = 5;
		Button_Campaign.Text = "战役";
		Button6.BackColor = Color.Transparent;
		Button6.DialogResult = DialogResult.None;
		Button6.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button6.Location = new Point(5, 128);
		Button6.Name = "Button6";
		Button6.Padding = new Padding(5);
		Button6.RoundRadius = 0;
		Button6.Size = new Size(200, 25);
		Button6.TabIndex = 4;
		Button6.Text = "从上次自动保存恢复";
		Button4.BackColor = Color.Transparent;
		Button4.DialogResult = DialogResult.None;
		Button4.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button4.Location = new Point(5, 98);
		Button4.Name = "Button4";
		Button4.Padding = new Padding(5);
		Button4.RoundRadius = 0;
		Button4.Size = new Size(200, 25);
		Button4.TabIndex = 3;
		Button4.Text = "加载已保存的推演";
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button3.Location = new Point(5, 71);
		Button3.Name = "Button3";
		Button3.Padding = new Padding(5);
		Button3.RoundRadius = 0;
		Button3.Size = new Size(200, 23);
		Button3.TabIndex = 2;
		Button3.Text = "开始新的想定";
		GroupBox2.Controls.Add(Button2);
		GroupBox2.Controls.Add(Button1);
		GroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox2.Location = new Point(491, 169);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(211, 81);
		GroupBox2.TabIndex = 1;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "想定编辑器";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button2.Location = new Point(5, 50);
		Button2.Name = "Button2";
		Button2.Padding = new Padding(5);
		Button2.RoundRadius = 0;
		Button2.Size = new Size(200, 25);
		Button2.TabIndex = 2;
		Button2.Text = "加载现有想定";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button1.Location = new Point(5, 20);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.RoundRadius = 0;
		Button1.Size = new Size(200, 25);
		Button1.TabIndex = 0;
		Button1.Text = "创建新的空白想定";
		Button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button5.BackColor = Color.Transparent;
		Button5.DialogResult = DialogResult.None;
		Button5.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button5.Location = new Point(613, 263);
		Button5.Name = "Button5";
		Button5.Padding = new Padding(5);
		Button5.RoundRadius = 0;
		Button5.Size = new Size(89, 33);
		Button5.TabIndex = 2;
		Button5.Text = "退出推演";
		PictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		PictureBox1.Image = componentResourceManager.GetObject("PictureBox1.Image");
		PictureBox1.Location = new Point(3, 4);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(483, 292);
		PictureBox1.TabIndex = 3;
		PictureBox1.TabStop = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(704, 299);
		base.Controls.Add(GroupBox2);
		base.Controls.Add(GroupBox1);
		base.Controls.Add(PictureBox1);
		base.Controls.Add(Button5);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "StartGame";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "开始菜单";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox2.ResumeLayout(performLayout: false);
		((ISupportInitialize)PictureBox1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public StartGame()
	{
		base.FormClosed += OrderInterruptibleSingleton;
		base.Load += RegisterInterruptibleSingleton;
		base.KeyDown += RevertInterruptibleSingleton;
		base.Shown += CountInterruptibleRecord;
		SortInterruptibleSingleton();
		tokenValue = false;
		_IndexerValue = false;
	}

	private void CalcInterruptibleSingleton(object sender, EventArgs e)
	{
		if (Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
		{
			Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
			Client.CreateNewScenario();
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleLicense.CommandFullVersion };
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
		}
	}

	private void RateInterruptibleSingleton(object sender, EventArgs e)
	{
		Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		ItemExporter.ConnectInterruptibleTemplate.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
		ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
	}

	private void FlushInterruptibleSingleton(object sender, EventArgs e)
	{
		Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		ItemExporter.ConnectInterruptibleTemplate.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadSavedGame;
		ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
	}

	private void ForgotInterruptibleSingleton(object sender, EventArgs e)
	{
		if (Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
		{
			Client.CurrentGame.GameMode = Game._GameMode.ScenEdit;
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleLicense.CommandFullVersion };
			ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
		}
	}

	private void CollectInterruptibleSingleton(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Close();
	}

	private void OrderInterruptibleSingleton(object sender, FormClosedEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void RegisterInterruptibleSingleton(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		PictureBox1.Image = (Image)InterpreterObjectListener.exporterResolver;
		Button_Campaign.Visible = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		Client.CurrentGame.Pause();
	}

	private void ManageInterruptibleSingleton(object sender, EventArgs e)
	{
		if (FileExistsNative.FileExistsFast(GameGeneral.ScenariosRootPath + "\\Autosave.scen"))
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
			ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = GameGeneral.ScenariosRootPath + "\\Autosave.scen";
			ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
			Close();
		}
		else
		{
			DarkMessageBox.ShowError("No autosave file was found at the path \\Scenarios\\Autosave.scen", "没有找到自动保存存档");
		}
	}

	private void RevertInterruptibleSingleton(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void CountInterruptibleRecord(object sender, EventArgs e)
	{
		if (SimConfiguration.DefaultGamePreferences.GameMusic)
		{
			AuthenticationSingleton.PushInterruptibleSchema();
		}
		Close();
	}

	private void CustomizeInterruptibleRecord(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.CampaignPlayWindow.Show();
		Close();
	}

	private void CloneInterruptibleRecord(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.QuickBattle.Show();
		Close();
	}
}
