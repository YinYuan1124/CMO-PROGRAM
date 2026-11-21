using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Steamworks;

namespace Command;

[DesignerGenerated]
public sealed class SteamPublishScenarioForm : DarkSecondaryFormBase
{
	private IContainer writerException;

	[AccessedThroughProperty("PictureBox1")]
	[CompilerGenerated]
	private PictureBox specificationException;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _WatcherException;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_MapScreenshot")]
	private DarkUIButton m_ReponseException;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton m_DescriptorException;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox m_PoolException;

	[AccessedThroughProperty("TextBox2")]
	[CompilerGenerated]
	private DarkUITextBox m_TaskException;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox3")]
	private DarkUITextBox filterException;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel testsException;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_InterpreterException;

	[AccessedThroughProperty("OFD_CustomImage")]
	[CompilerGenerated]
	private OpenFileDialog containerException;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _ComposerException;

	[AccessedThroughProperty("VisibleOnSteamCB")]
	[CompilerGenerated]
	private DarkUIComboBox _ModelException;

	internal PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return specificationException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			specificationException = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _WatcherException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareInterruptibleRecord;
			DarkUIButton watcherException = _WatcherException;
			if (watcherException != null)
			{
				watcherException.Click -= value2;
			}
			_WatcherException = value;
			watcherException = _WatcherException;
			if (watcherException != null)
			{
				watcherException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_MapScreenshot
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestInterruptibleRecord;
			DarkUIButton reponseException = m_ReponseException;
			if (reponseException != null)
			{
				reponseException.Click -= value2;
			}
			m_ReponseException = value;
			reponseException = m_ReponseException;
			if (reponseException != null)
			{
				reponseException.Click += value2;
			}
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectInterruptibleRecord;
			DarkUIButton descriptorException = m_DescriptorException;
			if (descriptorException != null)
			{
				descriptorException.Click -= value2;
			}
			m_DescriptorException = value;
			descriptorException = m_DescriptorException;
			if (descriptorException != null)
			{
				descriptorException.Click += value2;
			}
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_PoolException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PoolException = value;
		}
	}

	internal DarkUITextBox TextBox2
	{
		[CompilerGenerated]
		get
		{
			return m_TaskException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TaskException = value;
		}
	}

	internal DarkUITextBox TextBox3
	{
		[CompilerGenerated]
		get
		{
			return filterException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			filterException = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return testsException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsException = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterpreterException = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _ComposerException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleRecord;
			DarkUIButton composerException = _ComposerException;
			if (composerException != null)
			{
				composerException.Click -= value2;
			}
			_ComposerException = value;
			composerException = _ComposerException;
			if (composerException != null)
			{
				composerException.Click += value2;
			}
		}
	}

	internal DarkUIComboBox VisibleOnSteamCB
	{
		[CompilerGenerated]
		get
		{
			return _ModelException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleRecord;
			DarkUIComboBox modelException = _ModelException;
			if (modelException != null)
			{
				modelException.SelectedIndexChanged -= value2;
			}
			_ModelException = value;
			modelException = _ModelException;
			if (modelException != null)
			{
				modelException.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("VisibleOnSteamLabel")]
	internal DarkLabel VisibleOnSteamLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog OrderInterruptibleRecord()
	{
		return containerException;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RegisterInterruptibleRecord(OpenFileDialog openFileDialog_0)
	{
		containerException = openFileDialog_0;
	}

	public SteamPublishScenarioForm()
	{
		base.Shown += VisitInterruptibleRecord;
		base.Load += VerifyInterruptibleRecord;
		InsertInterruptibleRecord();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && writerException != null)
			{
				writerException.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InsertInterruptibleRecord()
	{
		PictureBox1 = new PictureBox();
		Button1 = new DarkUIButton();
		Button_MapScreenshot = new DarkUIButton();
		Button3 = new DarkUIButton();
		TextBox1 = new DarkUITextBox();
		TextBox2 = new DarkUITextBox();
		TextBox3 = new DarkUITextBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		RegisterInterruptibleRecord(new OpenFileDialog());
		Button2 = new DarkUIButton();
		VisibleOnSteamCB = new DarkUIComboBox();
		VisibleOnSteamLabel = new DarkLabel();
		((ISupportInitialize)PictureBox1).BeginInit();
		SuspendLayout();
		PictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		PictureBox1.Location = new Point(422, 13);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(256, 256);
		PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
		PictureBox1.TabIndex = 1;
		PictureBox1.TabStop = false;
		Button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(423, 283);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(255, 23);
		Button1.TabIndex = 2;
		Button1.Text = "选择预览图像";
		Button_MapScreenshot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_MapScreenshot.BackColor = Color.Transparent;
		Button_MapScreenshot.DialogResult = DialogResult.None;
		Button_MapScreenshot.Font = new Font("Segoe UI", 10f);
		Button_MapScreenshot.ForeColor = SystemColors.Control;
		Button_MapScreenshot.Location = new Point(422, 313);
		Button_MapScreenshot.Name = "Button_MapScreenshot";
		Button_MapScreenshot.RoundRadius = 0;
		Button_MapScreenshot.Size = new Size(256, 23);
		Button_MapScreenshot.TabIndex = 3;
		Button_MapScreenshot.Text = "使用截图";
		Button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 10f);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(422, 343);
		Button3.Name = "Button3";
		Button3.RoundRadius = 0;
		Button3.Size = new Size(256, 23);
		Button3.TabIndex = 4;
		Button3.Text = "发布新项目";
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(104, 13);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(312, 24);
		TextBox1.TabIndex = 5;
		TextBox1.TextAlign = HorizontalAlignment.Center;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox2.AutoCompleteCustomSource = null;
		TextBox2.AutoCompleteMode = AutoCompleteMode.None;
		TextBox2.AutoCompleteSource = AutoCompleteSource.None;
		TextBox2.BackColor = Color.Transparent;
		TextBox2.Font = new Font("Segoe UI", 8f);
		TextBox2.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox2.Image = null;
		TextBox2.Lines = null;
		TextBox2.Location = new Point(12, 67);
		TextBox2.MaxLength = 32767;
		TextBox2.Multiline = true;
		TextBox2.Name = "TextBox2";
		TextBox2.ReadOnly = false;
		TextBox2.ScrollBars = ScrollBars.None;
		TextBox2.SelectionStart = 0;
		TextBox2.Size = new Size(404, 380);
		TextBox2.TabIndex = 6;
		TextBox2.TextAlign = HorizontalAlignment.Left;
		TextBox2.UseSystemPasswordChar = false;
		TextBox2.WatermarkText = "";
		TextBox3.AutoCompleteCustomSource = null;
		TextBox3.AutoCompleteMode = AutoCompleteMode.None;
		TextBox3.AutoCompleteSource = AutoCompleteSource.None;
		TextBox3.BackColor = Color.Transparent;
		TextBox3.Font = new Font("Segoe UI", 8f);
		TextBox3.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox3.Image = null;
		TextBox3.Lines = null;
		TextBox3.Location = new Point(104, 41);
		TextBox3.MaxLength = 32767;
		TextBox3.Multiline = false;
		TextBox3.Name = "TextBox3";
		TextBox3.ReadOnly = false;
		TextBox3.ScrollBars = ScrollBars.None;
		TextBox3.SelectionStart = 0;
		TextBox3.Size = new Size(312, 20);
		TextBox3.TabIndex = 7;
		TextBox3.TextAlign = HorizontalAlignment.Left;
		TextBox3.UseSystemPasswordChar = false;
		TextBox3.WatermarkText = "";
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(12, 20);
		Label1.Name = "Label1";
		Label1.Size = new Size(86, 17);
		Label1.TabIndex = 8;
		Label1.Text = "想定标题：";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(12, 44);
		Label2.Name = "Label2";
		Label2.Size = new Size(72, 17);
		Label2.TabIndex = 9;
		Label2.Text = "文件名：";
		Button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(423, 373);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(255, 23);
		Button2.TabIndex = 10;
		Button2.Text = "更新现有工作空间项目";
		VisibleOnSteamCB.BackColor = Color.Transparent;
		VisibleOnSteamCB.DrawMode = DrawMode.OwnerDrawFixed;
		VisibleOnSteamCB.DropDownStyle = ComboBoxStyle.DropDownList;
		VisibleOnSteamCB.Font = new Font("Segoe UI", 9f);
		VisibleOnSteamCB.FormattingEnabled = true;
		VisibleOnSteamCB.Items.AddRange(new object[3] { "Public", "Friends", "Hidden" });
		VisibleOnSteamCB.Location = new Point(551, 402);
		VisibleOnSteamCB.MaxDropDownItems = 4;
		VisibleOnSteamCB.Name = "VisibleOnSteamCB";
		VisibleOnSteamCB.Size = new Size(121, 28);
		VisibleOnSteamCB.TabIndex = 11;
		VisibleOnSteamLabel.AutoSize = true;
		VisibleOnSteamLabel.Font = new Font("Segoe UI", 10f);
		VisibleOnSteamLabel.ForeColor = SystemColors.Control;
		VisibleOnSteamLabel.Location = new Point(422, 403);
		VisibleOnSteamLabel.Name = "VisibleOnSteamLabel";
		VisibleOnSteamLabel.Size = new Size(68, 23);
		VisibleOnSteamLabel.TabIndex = 12;
		VisibleOnSteamLabel.Text = "Visibilty";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(684, 455);
		base.Controls.Add(VisibleOnSteamLabel);
		base.Controls.Add(VisibleOnSteamCB);
		base.Controls.Add(Button2);
		base.Controls.Add(Label2);
		base.Controls.Add(Label1);
		base.Controls.Add(TextBox3);
		base.Controls.Add(TextBox2);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Button3);
		base.Controls.Add(Button_MapScreenshot);
		base.Controls.Add(Button1);
		base.Controls.Add(PictureBox1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SteamPublishScenarioForm";
		base.ShowIcon = false;
		Text = "Steam Workshop Publishing";
		((ISupportInitialize)PictureBox1).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PrepareInterruptibleRecord(object sender, EventArgs e)
	{
		OrderInterruptibleRecord().Filter = "";
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		string text = string.Empty;
		ImageCodecInfo[] array = imageEncoders;
		ImageCodecInfo[] array2 = array;
		foreach (ImageCodecInfo imageCodecInfo in array2)
		{
			string text2 = imageCodecInfo.CodecName.Substring(8).Replace("Codec", "Files").Trim();
			OrderInterruptibleRecord().Filter = string.Format("{0}{1}{2} ({3})|{3}", OrderInterruptibleRecord().Filter, text, text2, imageCodecInfo.FilenameExtension);
			text = "|";
		}
		OrderInterruptibleRecord().Filter = string.Format("{0}{1}{2} ({3})|{3}", OrderInterruptibleRecord().Filter, text, "所有的文件", "*.*");
		OrderInterruptibleRecord().FilterIndex = 1;
		if (OrderInterruptibleRecord().ShowDialog() == DialogResult.OK)
		{
			if (FileExistsNative.FileExistsFast(method_0()))
			{
				File.Delete(method_0());
			}
			File.Copy(OrderInterruptibleRecord().FileName, method_0());
			Image image = Image.FromFile(OrderInterruptibleRecord().FileName);
			StopInterruptibleRecord(image, image.RawFormat);
		}
	}

	[SpecialName]
	private string method_0()
	{
		return Path.Combine(GameGeneral.TopLevelWritablePath, "screenshot.png");
	}

	[SpecialName]
	private string method_1()
	{
		return Path.Combine(GameGeneral.TopLevelWritablePath, "screenshot_thumb.png");
	}

	private void ReflectInterruptibleRecord(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(TextBox1.Text))
		{
			DarkMessageBox.ShowError("请输入想定标题！", "No title");
		}
		else if (string.IsNullOrEmpty(TextBox2.Text))
		{
			DarkMessageBox.ShowError("请输入想定说明！", "No description");
		}
		else if (!string.IsNullOrEmpty(TextBox3.Text) && Operators.CompareString(TextBox3.Text, "在这里输入想定文件名", TextCompare: true) != 0)
		{
			SteamWorkshop.SteamWorkshopScenario steamWorkshopScenario_ = new SteamWorkshop.SteamWorkshopScenario
			{
				Name = TextBox1.Text,
				Description = TextBox2.Text,
				PreviewFilePath = method_1(),
				ScenFileName = TextBox3.Text.Replace("/", "").Replace("\\", "").Replace(":", "")
			};
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Timer_SteamWorkshop.Interval = 1000;
			SteamWorkshop.Publish(steamWorkshopScenario_);
			Close();
		}
		else
		{
			DarkMessageBox.ShowError("请输入想定文件名！", "No filename");
		}
	}

	private void VisitInterruptibleRecord(object sender, EventArgs e)
	{
		TextBox1.Text = Client.CurrentScenario.Title;
		if (!string.IsNullOrEmpty(Client.CurrentScenario.Description))
		{
			TextBox2.Text = StripHTML.RemoveSpecification(Client.CurrentScenario.Description);
		}
		if (string.IsNullOrEmpty(Client.SaveScenarioPath))
		{
			TextBox3.Text = "在这里输入想定文件名";
		}
		else
		{
			TextBox3.Text = Path.GetFileNameWithoutExtension(Client.SaveScenarioPath);
		}
		string text = Path.ChangeExtension(Client.SaveScenarioPath, "jpg");
		if (!Information.IsNothing(Client.SaveScenarioPath) && FileExistsNative.FileExistsFast(text))
		{
			Image image = Image.FromFile(text);
			StopInterruptibleRecord(image, image.RawFormat);
		}
		else
		{
			RestartInterruptibleRecord();
		}
		VisibleOnSteamCB.SelectedIndex = 0;
	}

	private void RestartInterruptibleRecord()
	{
		try
		{
			if (FileExistsNative.FileExistsFast(method_0()))
			{
				File.Delete(method_0());
			}
			Bitmap bitmap = new Bitmap(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Width, ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			base.Visible = false;
			Thread.Sleep(50);
			Application.DoEvents();
			base.Visible = false;
			Thread.Sleep(50);
			Application.DoEvents();
			graphics.CopyFromScreen(ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.PointToScreen(default(Point)).X, ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.PointToScreen(default(Point)).Y, 0, 0, bitmap.Size);
			base.Visible = true;
			bitmap.Save(method_0(), ImageFormat.Png);
			StopInterruptibleRecord(bitmap, ImageFormat.Png);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200407", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void TestInterruptibleRecord(object sender, EventArgs e)
	{
		RestartInterruptibleRecord();
	}

	private void StopInterruptibleRecord(Image image_0, ImageFormat imageFormat_0)
	{
		Image image = InterpreterObjectListener.ListInterruptibleTask((Bitmap)image_0, new Size(637, 358));
		image.Save(method_1(), imageFormat_0);
		PictureBox1.Image = InterpreterObjectListener.ListInterruptibleTask((Bitmap)image, new Size(256, 256));
	}

	private void CancelInterruptibleRecord(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(TextBox1.Text))
		{
			DarkMessageBox.ShowError("请输入想定标题！", "Error");
		}
		else if (string.IsNullOrEmpty(TextBox2.Text))
		{
			DarkMessageBox.ShowError("请输入想定说明！", "Error");
		}
		else if (!string.IsNullOrEmpty(TextBox3.Text) && Operators.CompareString(TextBox3.Text, "在这里输入想定文件名", TextCompare: true) != 0)
		{
			SteamWorkshop.SteamWorkshopScenario steam_scenario = new SteamWorkshop.SteamWorkshopScenario
			{
				Name = TextBox1.Text,
				Description = TextBox2.Text,
				PreviewFilePath = method_1(),
				ScenFileName = TextBox3.Text.Replace("/", "").Replace("\\", "").Replace(":", "")
			};
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Timer_SteamWorkshop.Interval = 1000;
			SteamUpdateScenarioForm.steam_scenario = steam_scenario;
			ItemExporter.ConnectInterruptibleTemplate.SteamUpdateScenarioForm.Show();
			Close();
		}
		else
		{
			DarkMessageBox.ShowError("请输入想定文件名！", "Error");
		}
	}

	private void VerifyInterruptibleRecord(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void ListInterruptibleRecord(object sender, EventArgs e)
	{
		switch (VisibleOnSteamCB.SelectedIndex)
		{
		case 0:
			SteamWorkshop.visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic;
			break;
		case 1:
			SteamWorkshop.visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityFriendsOnly;
			break;
		case 2:
			SteamWorkshop.visibiltyWorkshopItem = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
			break;
		}
	}
}
