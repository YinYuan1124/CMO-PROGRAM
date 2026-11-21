using System;
using System.Collections;
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
public sealed class CampaignEnd : DarkSecondaryFormBase
{
	private IContainer m_DescriptorInvocation;

	[AccessedThroughProperty("WebBrowser1")]
	[CompilerGenerated]
	private WebBrowser poolInvocation;

	public Campaign theCampaign;

	internal WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return poolInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PreviewKeyDownEventHandler value2 = ConcatStatus;
			WebBrowser webBrowser = poolInvocation;
			if (webBrowser != null)
			{
				webBrowser.PreviewKeyDown -= value2;
			}
			poolInvocation = value;
			webBrowser = poolInvocation;
			if (webBrowser != null)
			{
				webBrowser.PreviewKeyDown += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public CampaignEnd()
	{
		base.Shown += EnableStatus;
		base.KeyDown += CheckStatus;
		base.Load += RemoveStatus;
		SearchStatus();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_DescriptorInvocation != null)
			{
				m_DescriptorInvocation.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SearchStatus()
	{
		WebBrowser1 = new WebBrowser();
		Label1 = new DarkLabel();
		SuspendLayout();
		WebBrowser1.AllowNavigation = false;
		WebBrowser1.AllowWebBrowserDrop = false;
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.IsWebBrowserContextMenuEnabled = false;
		WebBrowser1.Location = new Point(2, 2);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(1080, 606);
		WebBrowser1.TabIndex = 18;
		Label1.Anchor = AnchorStyles.Bottom;
		Label1.AutoSize = true;
		Label1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Italic, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(479, 614);
		Label1.Name = "Label1";
		Label1.Size = new Size(129, 13);
		Label1.TabIndex = 19;
		Label1.Text = "按任意键继续";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1085, 653);
		base.ControlBox = false;
		base.Controls.Add(Label1);
		base.Controls.Add(WebBrowser1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CampaignEnd";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "战役结束";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void EnableStatus(object sender, EventArgs e)
	{
		string localizedEnding = Localization.ScenarioText(theCampaign.FilePath, "EndingText", theCampaign.EndingText);
		if (!InitStatus(WebBrowser1, localizedEnding, theCampaign.FolderPath))
		{
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, localizedEnding);
		}
		ChangeStatus();
	}

	private void ChangeStatus()
	{
		base.TopMost = true;
		base.FormBorderStyle = FormBorderStyle.None;
		base.WindowState = FormWindowState.Maximized;
	}

	private bool InitStatus(WebBrowser webBrowser_0, string string_0, string string_1)
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
			string campaignID = Client.CurrentScenario.CampaignID;
			Campaign campaignByID = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, campaignID);
			if (Information.IsNothing(campaignByID))
			{
				return false;
			}
			webBrowser_0.Navigate(Path.Combine(campaignByID.FolderPath, path));
			return true;
		}
		return false;
	}

	private void CheckStatus(object sender, KeyEventArgs e)
	{
		InterruptStatus();
	}

	private void ConcatStatus(object sender, PreviewKeyDownEventArgs e)
	{
		InterruptStatus();
	}

	private void InterruptStatus()
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = ItemExporter.RevertInterruptibleMap.OpenForms.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Form form = (Form)enumerator.Current;
				if (form != this && form != ItemExporter.ConnectInterruptibleTemplate.databaseTemplate && form.Visible)
				{
					form.Hide();
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		StartGameMenuWindow.ShowStartWindow();
		Close();
	}

	private void RemoveStatus(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
