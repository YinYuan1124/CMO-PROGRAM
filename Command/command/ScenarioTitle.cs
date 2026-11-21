using System;
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
using DarkUI.Forms;
using MSDN.Html.Editor;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ScenarioTitle : DarkSecondaryFormBase
{
	private IContainer collectionSingleton;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel instanceSingleton;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox _ObjectSingleton;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton expressionSingleton;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _DispatcherSingleton;

	[AccessedThroughProperty("Editor1")]
	[CompilerGenerated]
	private HtmlEditorControl listenerSingleton;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton _ConfigSingleton;

	private bool m_RegistrySingleton;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return instanceSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			instanceSingleton = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _ObjectSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = RemoveInterruptiblePublisher;
			DarkUITextBox objectSingleton = _ObjectSingleton;
			if (objectSingleton != null)
			{
				objectSingleton.TextChanged -= value2;
			}
			_ObjectSingleton = value;
			objectSingleton = _ObjectSingleton;
			if (objectSingleton != null)
			{
				objectSingleton.TextChanged += value2;
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
			return expressionSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptiblePublisher;
			DarkUIButton darkUIButton = expressionSingleton;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			expressionSingleton = value;
			darkUIButton = expressionSingleton;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _DispatcherSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopInterruptiblePublisher;
			DarkUIButton dispatcherSingleton = _DispatcherSingleton;
			if (dispatcherSingleton != null)
			{
				dispatcherSingleton.Click -= value2;
			}
			_DispatcherSingleton = value;
			dispatcherSingleton = _DispatcherSingleton;
			if (dispatcherSingleton != null)
			{
				dispatcherSingleton.Click += value2;
			}
		}
	}

	private HtmlEditorControl Editor1
	{
		[CompilerGenerated]
		get
		{
			return listenerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			listenerSingleton = value;
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _ConfigSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadInterruptiblePublisher;
			DarkUIButton configSingleton = _ConfigSingleton;
			if (configSingleton != null)
			{
				configSingleton.Click -= value2;
			}
			_ConfigSingleton = value;
			configSingleton = _ConfigSingleton;
			if (configSingleton != null)
			{
				configSingleton.Click += value2;
			}
		}
	}

	public ScenarioTitle()
	{
		base.FormClosing += SetInterruptiblePublisher;
		base.Load += FillInterruptiblePublisher;
		base.KeyDown += InstantiateInterruptiblePublisher;
		base.Shown += CreateInterruptiblePublisher;
		base.ResizeEnd += CompareInterruptiblePublisher;
		InterruptInterruptiblePublisher();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && collectionSingleton != null)
		{
			collectionSingleton.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void InterruptInterruptiblePublisher()
	{
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		Editor1 = new HtmlEditorControl();
		Button3 = new DarkUIButton();
		SuspendLayout();
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(9, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(30, 13);
		Label1.TabIndex = 0;
		Label1.Text = "标题：";
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(49, 10);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(601, 20);
		TextBox1.TabIndex = 1;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(9, 49);
		Label2.Name = "Label2";
		Label2.Size = new Size(78, 22);
		Label2.TabIndex = 2;
		Label2.Text = "描述：";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(12, 458);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 4;
		Button1.Text = "确定";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(575, 458);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 5;
		Button2.Text = "取消";
		((Control)Editor1).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		((Control)Editor1).BackColor = Color.FromArgb(69, 73, 74);
		Editor1.BodyBackColor = Color.FromArgb(43, 43, 43);
		Editor1.BodyForeColor = Color.FromArgb(220, 220, 220);
		((Control)Editor1).ForeColor = Color.FromArgb(220, 220, 220);
		Editor1.InnerText = null;
		((Control)Editor1).Location = new Point(12, 65);
		((Control)Editor1).Name = "Editor1";
		((Control)Editor1).Size = new Size(638, 387);
		((Control)Editor1).TabIndex = 27;
		Button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 10f);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(575, 39);
		Button3.Name = "Button3";
		Button3.RoundRadius = 0;
		Button3.Size = new Size(75, 23);
		Button3.TabIndex = 28;
		Button3.Text = "编辑HTML";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(662, 485);
		base.Controls.Add(Button3);
		base.Controls.Add(Editor1);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label2);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ScenarioTitle";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "创建新想定";
		ResumeLayout(performLayout: false);
	}

	private void RemoveInterruptiblePublisher(object object_0)
	{
		if (Client.CurrentUserAction == Client.UserAction.CreatingNewScenario)
		{
			Button1.Enabled = Operators.CompareString(TextBox1.Text, "", TextCompare: true) != 0;
		}
	}

	private void FindInterruptiblePublisher(object sender, EventArgs e)
	{
		string text = InterpreterObjectListener.TestInterruptibleTask(TextBox1.Text);
		if (Operators.CompareString(text, "", TextCompare: true) == 0)
		{
			DarkMessageBox.ShowError("请为想定名称使用有效的文件名字符", "");
			return;
		}
		switch (Client.CurrentUserAction)
		{
		case Client.UserAction.PackingScenarioForDistribution:
			Client.CurrentScenario.Title = TextBox1.Text;
			Client.CurrentScenario.FileName = text;
			Client.CurrentScenario.Description = Editor1.BodyHtml;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName = text;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().AddExtension = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().Filter = "打包想定文件（* .zip）| * .zip";
			if (string.IsNullOrEmpty(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory = GameGeneral.ScenariosRootPath;
			}
			else if (!Path.GetFullPath(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory).StartsWith(GameGeneral.ScenariosRootPath))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory = GameGeneral.ScenariosRootPath;
			}
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().ShowDialog() == DialogResult.OK)
			{
				AttachmentRepoManager.PackageScenarioForDistribution(Client.CurrentScenario, Client.CurrentSide, ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
				Close();
			}
			else
			{
				DarkMessageBox.ShowError(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().ShowDialog().ToString(), "");
			}
			Client.SaveScenarioPath = ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName;
			break;
		case Client.UserAction.SavingScenario:
			Client.CurrentScenario.Title = TextBox1.Text;
			Client.CurrentScenario.FileName = text;
			Client.CurrentScenario.Description = Editor1.BodyHtml;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName = text;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().AddExtension = true;
			if (GameGeneral.PE_SaveAsXML)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().Filter = "Command scenario file as XML (*.xml)|*.xml";
			}
			else if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().Filter = "想定文件|*.scen|存档文件|*.save|所有文件|*.*";
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().Filter = "存档文件|*.save|想定文件|*.scen|所有文件|*.*";
			}
			if (string.IsNullOrEmpty(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory = GameGeneral.ScenariosRootPath;
			}
			else if (!Path.GetFullPath(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory).StartsWith(GameGeneral.ScenariosRootPath))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().InitialDirectory = GameGeneral.ScenariosRootPath;
			}
			if (ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().ShowDialog() == DialogResult.OK)
			{
				Client.SaveCurrentScenario(bool_0: true);
				Client.AddFileNameToRecentList(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
				Close();
			}
			else
			{
				DarkMessageBox.ShowError(ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().ShowDialog().ToString(), "");
			}
			Client.SaveScenarioPath = ItemExporter.ConnectInterruptibleTemplate.MainForm.AwakeGetter().FileName;
			Client.CurrentScenario.FileNamePath = Path.GetDirectoryName(Client.SaveScenarioPath);
			break;
		case Client.UserAction.EditingScenarioTitleDescription:
			Client.CurrentScenario.Title = TextBox1.Text;
			Client.CurrentScenario.Description = Editor1.BodyHtml.Replace("<BODY scroll=auto><P>", "").Replace("</P></BODY>", "");
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
			Close();
			break;
		}
	}

	private void SetInterruptiblePublisher(object sender, FormClosingEventArgs e)
	{
		if (m_RegistrySingleton)
		{
			Client.CurrentGame.Run();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Client.CurrentUserAction = Client.UserAction.None;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void FillInterruptiblePublisher(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		m_RegistrySingleton = Client.CurrentGame.Status == Game._GameStatus.Running;
		if (m_RegistrySingleton)
		{
			Client.CurrentGame.Pause();
		}
		switch (Client.CurrentUserAction)
		{
		case Client.UserAction.CreatingNewScenario:
			Text = "创建新想定";
			Button1.Enabled = Operators.CompareString(TextBox1.Text, "", TextCompare: true) != 0;
			TextBox1.Enabled = true;
			Button1.Visible = true;
			Button2.Visible = true;
			return;
		case Client.UserAction.EditingScenarioTitleDescription:
			if (!Information.IsNothing(Client.CurrentScenario.Title))
			{
				TextBox1.Text = Client.CurrentScenario.Title.ToString();
			}
			if (!Information.IsNothing(Client.CurrentScenario.Description))
			{
				Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
			}
			TextBox1.Enabled = true;
			Button1.Visible = true;
			Button2.Visible = true;
			return;
		case Client.UserAction.SavingScenario:
			Text = "保存想定";
			if (!Information.IsNothing(Client.CurrentScenario.Title))
			{
				TextBox1.Text = Client.CurrentScenario.Title.ToString();
			}
			if (!Information.IsNothing(Client.CurrentScenario.Description))
			{
				Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
			}
			TextBox1.Enabled = true;
			Button1.Visible = true;
			Button2.Visible = true;
			return;
		}
		if (!Information.IsNothing(Client.CurrentScenario.Title))
		{
			TextBox1.Text = Client.CurrentScenario.Title.ToString();
		}
		if (!Information.IsNothing(Client.CurrentScenario.Description))
		{
			if (string.IsNullOrEmpty(Client._PolicyClass))
			{
				Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
			}
			else if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
			}
			else if (!CalculateInterruptiblePublisher(Editor1, Client.CurrentScenario.Description.ToString(), Path.GetDirectoryName(Client._PolicyClass)))
			{
				Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
			}
		}
		Text = "想定描述";
		TextBox1.Enabled = false;
		Button1.Visible = false;
		Button2.Visible = false;
	}

	private bool CalculateInterruptiblePublisher(HtmlEditorControl htmlEditorControl_0, string string_0, string string_1)
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

	private void PopInterruptiblePublisher(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Close();
	}

	private void InstantiateInterruptiblePublisher(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
			Close();
		}
	}

	private void CreateInterruptiblePublisher(object sender, EventArgs e)
	{
		if (base.Height != 510)
		{
			base.Width--;
			base.Width++;
		}
	}

	private void CompareInterruptiblePublisher(object sender, EventArgs e)
	{
		base.Width--;
		base.Width++;
	}

	private void ReadInterruptiblePublisher(object sender, EventArgs e)
	{
		Editor1.HtmlContentsEdit();
	}
}
