using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ResumeFromSave : DarkSecondaryFormBase
{
	private IContainer _ProxyPredicate;

	private ScenContainer _PropertyPredicate;

	public string SelectedFilename;

	public string CampaignSessionID;

	private string _ImporterPredicate;

	[AccessedThroughProperty("BW_LoadScen")]
	[CompilerGenerated]
	private BackgroundWorker m_RepositoryPredicate;

	private Scenario bridgePredicate;

	private bool m_InvocationPredicate;

	private double _ClassPredicate;

	private string _RequestPredicate;

	[field: AccessedThroughProperty("PB_PercentComplete")]
	internal DarkUIProgressBar PB_PercentComplete
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker ConnectInterruptibleIndexer()
	{
		return m_RepositoryPredicate;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void MoveInterruptibleIndexer(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = RegisterInterruptibleToken;
		RunWorkerCompletedEventHandler value2 = ManageInterruptibleToken;
		BackgroundWorker repositoryPredicate = m_RepositoryPredicate;
		if (repositoryPredicate != null)
		{
			repositoryPredicate.DoWork -= value;
			repositoryPredicate.RunWorkerCompleted -= value2;
		}
		m_RepositoryPredicate = backgroundWorker_0;
		repositoryPredicate = m_RepositoryPredicate;
		if (repositoryPredicate != null)
		{
			repositoryPredicate.DoWork += value;
			repositoryPredicate.RunWorkerCompleted += value2;
		}
	}

	public ResumeFromSave()
	{
		base.Shown += OrderInterruptibleToken;
		base.FormClosing += RevertInterruptibleToken;
		MoveInterruptibleIndexer(new BackgroundWorker());
		CollectInterruptibleToken();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ProxyPredicate != null)
			{
				_ProxyPredicate.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CollectInterruptibleToken()
	{
		PB_PercentComplete = new DarkUIProgressBar();
		SuspendLayout();
		PB_PercentComplete.BackColor = Color.Transparent;
		PB_PercentComplete.Dock = DockStyle.Fill;
		PB_PercentComplete.Font = new Font("Segoe UI", 9f);
		PB_PercentComplete.Location = new Point(0, 0);
		PB_PercentComplete.Maximum = 100;
		PB_PercentComplete.Name = "PB_PercentComplete";
		PB_PercentComplete.ShowProgressLines = true;
		PB_PercentComplete.ShowProgressValue = false;
		PB_PercentComplete.Size = new Size(298, 65);
		PB_PercentComplete.TabIndex = 0;
		PB_PercentComplete.Value = 0;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(298, 65);
		base.ControlBox = false;
		base.Controls.Add(PB_PercentComplete);
		DoubleBuffered = true;
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ResumeFromSave";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "加载中...";
		ResumeLayout(performLayout: false);
	}

	private void OrderInterruptibleToken(object sender, EventArgs e)
	{
		MainForm.KillAllRendering = true;
		if (string.IsNullOrEmpty(CampaignSessionID))
		{
			_ImporterPredicate = null;
		}
		else
		{
			_ImporterPredicate = CampaignSessionID;
			CampaignSessionID = null;
		}
		try
		{
			_PropertyPredicate = ScenContainer.LoadFromFile(SelectedFilename);
			string scenarioObject_AsXML = _PropertyPredicate.GetScenarioObject_AsXML();
			_RequestPredicate = Scenario.QueryScenario_ScenXML(scenarioObject_AsXML, "ContentTag");
			if (string.IsNullOrEmpty(_RequestPredicate))
			{
				_RequestPredicate = "";
			}
			if (!Licensing.IsUserLicensedForThisContent(_RequestPredicate))
			{
				ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent(_RequestPredicate) };
				ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
				Close();
				return;
			}
			m_InvocationPredicate = false;
			bridgePredicate = null;
			ItemExporter.ConnectInterruptibleTemplate.ORBAT?.ReleaseReferences();
			ConnectInterruptibleIndexer().RunWorkerAsync();
			PB_PercentComplete.Visible = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.ScenarioReferenceCleanup();
			while (!m_InvocationPredicate)
			{
				Application.DoEvents();
				PB_PercentComplete.Value = (int)Math.Round(_ClassPredicate * 100.0);
				Thread.Sleep(50);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MainForm.KillAllRendering = false;
			ConnectInterruptibleIndexer().WorkerSupportsCancellation = true;
			ConnectInterruptibleIndexer().CancelAsync();
			Close();
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("错误：" + ex2.Message, "加载时出错");
			ProjectData.ClearProjectError();
		}
		MainForm.KillAllRendering = false;
	}

	private void RegisterInterruptibleToken(object sender, DoWorkEventArgs e)
	{
		try
		{
			Scenario scenarioObject = _PropertyPredicate.GetScenarioObject(ref Client.authenticationClass, delegate(double double_0)
			{
				_ClassPredicate = double_0;
			}, bool_0: false);
			if (!Path.GetFileName(SelectedFilename).StartsWith("Autosave"))
			{
				scenarioObject.FileName = Path.GetFileName(SelectedFilename);
				scenarioObject.FileNamePath = Path.GetDirectoryName(SelectedFilename);
			}
			bridgePredicate = scenarioObject;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200106", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("错误：" + exception_.Message, "加载时出错");
			ProjectData.ClearProjectError();
		}
	}

	private void ManageInterruptibleToken(object sender, RunWorkerCompletedEventArgs e)
	{
		try
		{
			if (!Information.IsNothing(bridgePredicate))
			{
				if (!string.IsNullOrEmpty(_ImporterPredicate))
				{
					bridgePredicate.CampaignSessionID = _ImporterPredicate;
					_ImporterPredicate = null;
				}
				Client.HandleScenarioLoaded(bridgePredicate, SelectedFilename);
				m_InvocationPredicate = true;
				if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
				{
					Client.SaveScenarioPath = SelectedFilename;
				}
				else
				{
					Client.SaveScenarioPath = null;
				}
				Close();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("错误：" + ex2.Message, "加载时出错");
			ProjectData.ClearProjectError();
		}
	}

	private void RevertInterruptibleToken(object sender, FormClosingEventArgs e)
	{
		_PropertyPredicate = null;
		bridgePredicate = null;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	[CompilerGenerated]
	private void CountInterruptibleIndexer(double double_0)
	{
		_ClassPredicate = double_0;
	}
}
