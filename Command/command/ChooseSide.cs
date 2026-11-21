using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ChooseSide : DarkSecondaryFormBase
{
	private IContainer _TagClass;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox _QueueClass;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton m_ParamClass;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton pageClass;

	[CompilerGenerated]
	[AccessedThroughProperty("WebBrowser1")]
	private WebBrowser rulesClass;

	[AccessedThroughProperty("lblSideNumber")]
	[CompilerGenerated]
	private DarkLabel m_MethodClass;

	public Scenario theSelectedScenario;

	public string selectedScenarioFile;

	private List<Side> m_ServiceClass;

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return _QueueClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListStrategy;
			DarkUIComboBox queueClass = _QueueClass;
			if (queueClass != null)
			{
				queueClass.SelectionChangeCommitted -= value2;
			}
			_QueueClass = value;
			queueClass = _QueueClass;
			if (queueClass != null)
			{
				queueClass.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ParamClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestStrategy;
			DarkUIButton paramClass = m_ParamClass;
			if (paramClass != null)
			{
				paramClass.Click -= value2;
			}
			m_ParamClass = value;
			paramClass = m_ParamClass;
			if (paramClass != null)
			{
				paramClass.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return pageClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveStrategy;
			DarkUIButton darkUIButton = pageClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			pageClass = value;
			darkUIButton = pageClass;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return rulesClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rulesClass = value;
		}
	}

	internal DarkLabel lblSideNumber
	{
		[CompilerGenerated]
		get
		{
			return m_MethodClass;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodClass = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _TagClass != null)
			{
				_TagClass.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RestartStrategy()
	{
		Label1 = new DarkLabel();
		ComboBox1 = new DarkUIComboBox();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		WebBrowser1 = new WebBrowser();
		lblSideNumber = new DarkLabel();
		SuspendLayout();
		Label1.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(9, 15);
		Label1.Name = "Label1";
		Label1.Size = new Size(98, 13);
		Label1.TabIndex = 0;
		Label1.Text = "可用分方：";
		ComboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ComboBox1.BackColor = Color.Transparent;
		ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox1.Font = new Font("Segoe UI", 7f);
		ComboBox1.FormattingEnabled = true;
		ComboBox1.Location = new Point(117, 10);
		ComboBox1.Name = "ComboBox1";
		ComboBox1.Size = new Size(452, 21);
		ComboBox1.TabIndex = 1;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(9, 48);
		Label2.Name = "Label2";
		Label2.Size = new Size(152, 13);
		Label2.TabIndex = 2;
		Label2.Text = "选定分方的简报：";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(12, 433);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(169, 27);
		Button1.TabIndex = 4;
		Button1.Text = "进入想定";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(482, 433);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(191, 27);
		Button2.TabIndex = 5;
		Button2.Text = "取消（返回主菜单）";
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.Location = new Point(12, 64);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(661, 363);
		WebBrowser1.TabIndex = 16;
		lblSideNumber.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		lblSideNumber.ForeColor = Color.FromArgb(220, 220, 220);
		lblSideNumber.Location = new Point(575, 15);
		lblSideNumber.Name = "lblSideNumber";
		lblSideNumber.Size = new Size(98, 13);
		lblSideNumber.TabIndex = 17;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(685, 472);
		base.Controls.Add(lblSideNumber);
		base.Controls.Add(WebBrowser1);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label2);
		base.Controls.Add(ComboBox1);
		base.Controls.Add(Label1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ChooseSide";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "分方选择和简报";
		ResumeLayout(performLayout: false);
	}

	public ChooseSide()
	{
		base.FormClosing += VerifyStrategy;
		base.KeyDown += PostStrategy;
		base.FormClosed += RunStrategy;
		base.Shown += StartStrategy;
		base.Load += AssetStrategy;
		m_ServiceClass = new List<Side>();
		RestartStrategy();
		tokenValue = false;
		_IndexerValue = false;
		int num = (int)Math.Round((double)Screen.PrimaryScreen.Bounds.Width * 0.8);
		int num2 = (int)Math.Round((double)Screen.PrimaryScreen.Bounds.Height * 0.8);
		base.Size = new Size(num, num2 - 50);
	}

	private void TestStrategy(object sender, EventArgs e)
	{
		try
		{
			StopStrategy();
			StartGameMenuWindow.HideStartWindow();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			StartGameMenuWindow.ShowStartWindow();
			Close();
			ProjectData.ClearProjectError();
		}
	}

	private void StopStrategy()
	{
		Client.CurrentGame.Pause();
		Button1.Enabled = false;
		Side[] sides_ReadOnly = theSelectedScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (Operators.CompareString(side.Name, ComboBox1.SelectedItem.ToString(), TextCompare: true) == 0)
			{
				theSelectedScenario.SetCurrentSide(side);
				break;
			}
		}
		Client.SetCurrentScenario(theSelectedScenario, bool_0: false);
		if (Information.IsNothing(Client.CurrentSide))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = 3000000;
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, Client.CurrentSide.MapCenter);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.CameraAltitude = (int)Math.Round(Client.CurrentSide.CameraAlt);
		}
		Client.MustRefreshMainForm = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshCaption();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleTimeCompressionChanged();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Geo();
		if (Client.CurrentScenario.LastSavedInScenEdit && Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			ItemExporter.ConnectInterruptibleTemplate.RealismDialog.SetScenario(Client.CurrentScenario);
			ItemExporter.ConnectInterruptibleTemplate.RealismDialog.Show();
		}
		Close();
	}

	private bool CancelStrategy(WebBrowser webBrowser_0, string string_0, string string_1)
	{
		if (string_0.Contains("[LOADDOC]"))
		{
			int num = Strings.InStr(string_0, "[LOADDOC]", CompareMethod.Text) + "[LOADDOC]".Length - 1;
			int num2 = Strings.InStr(string_0, "[/LOADDOC]", CompareMethod.Text);
			string path;
			try
			{
				path = string_0.Substring(num, string_0.Length - num - (string_0.Length - num2 + 1));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return false;
			}
			if (FileExistsNative.FileExistsFast(Path.Combine(string_1, path)))
			{
				webBrowser_0.Navigate(Path.Combine(string_1, path));
				return true;
			}
			string campaignID = theSelectedScenario.CampaignID;
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

	private void VerifyStrategy(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
	}

	private void ListStrategy(object sender, EventArgs e)
	{
		Side side = m_ServiceClass[ComboBox1.SelectedIndex];
		if (string.IsNullOrEmpty(side.Briefing))
		{
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, "对该分方当前无简介。");
		}
		else if (!CancelStrategy(WebBrowser1, side.Briefing.ToString(), Path.GetDirectoryName(selectedScenarioFile)))
		{
			string text = side.Briefing.ToString();
			if (string.IsNullOrEmpty(text))
			{
				InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, "对该分方当前无简介。");
			}
			else
			{
				InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, text);
			}
		}
	}

	private void ResolveStrategy(object sender, EventArgs e)
	{
		StartGameMenuWindow.ShowStartWindow();
		Close();
	}

	private void PostStrategy(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
			Close();
		}
	}

	private void RunStrategy(object sender, FormClosedEventArgs e)
	{
		ComboBox1.Items.Clear();
		theSelectedScenario = null;
		m_ServiceClass = null;
	}

	private void StartStrategy(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		Side side = null;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		m_ServiceClass = theSelectedScenario.Sides_ReadOnly.Where((Side theSide) => !theSide.IsAIOnly).ToList();
		if (m_ServiceClass.Count == 0)
		{
			theSelectedScenario.Sides_ReadOnly[0].IsAIOnly = false;
			m_ServiceClass.Add(theSelectedScenario.Sides_ReadOnly[0]);
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				DarkMessageBox.ShowWarning("警告 - 该想定没有参演方可选择的分方。可将分方：" + theSelectedScenario.Sides_ReadOnly[0].Name + "设置为参演方可选择的。请查看仅限AI的分方状态！", "");
			}
		}
		Side[] sides_ReadOnly;
		if (m_ServiceClass.Count == 1)
		{
			side = m_ServiceClass[0];
			ComboBox1.Enabled = false;
			ComboBox1.Items.Add(m_ServiceClass[0].Name);
			ComboBox1.SelectedIndex = 0;
			ComboBox1.Size = new Size(556, 21);
			lblSideNumber.Visible = false;
		}
		else
		{
			ComboBox1.Size = new Size(452, 21);
			lblSideNumber.Text = m_ServiceClass.Count + " selectable sides";
			ComboBox1.Visible = true;
			foreach (Side item in m_ServiceClass)
			{
				ComboBox1.Items.Add(item.Name);
			}
			if (ComboBox1.Items.Count > 0)
			{
				ComboBox1.SelectedIndex = 0;
			}
			sides_ReadOnly = theSelectedScenario.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side2 in array)
			{
				if (Operators.CompareString(side2.Name, ComboBox1.SelectedItem.ToString(), TextCompare: true) == 0)
				{
					side = side2;
					break;
				}
			}
		}
		sides_ReadOnly = theSelectedScenario.Sides_ReadOnly;
		Side[] array2 = sides_ReadOnly;
		foreach (Side side3 in array2)
		{
			if (Operators.CompareString(side3.Name, ComboBox1.SelectedItem.ToString(), TextCompare: true) == 0)
			{
				side = side3;
				break;
			}
		}
		if (Information.IsNothing(side))
		{
			return;
		}
		if (string.IsNullOrEmpty(side.Briefing))
		{
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, "对该分方当前无简介。");
		}
		else if (!CancelStrategy(WebBrowser1, side.Briefing.ToString(), Path.GetDirectoryName(selectedScenarioFile)))
		{
			string text = side.Briefing.ToString();
			if (string.IsNullOrEmpty(text))
			{
				InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, "对该分方当前无简介。");
			}
			else
			{
				InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, text);
			}
		}
	}

	private void AssetStrategy(object sender, EventArgs e)
	{
		Label1.ForeColor = Color.Gainsboro;
	}
}
