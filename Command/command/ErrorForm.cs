using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class ErrorForm : Form
{
	private IContainer m_ReaderList;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Error")]
	private DarkRichTextBox propertyList;

	[CompilerGenerated]
	[AccessedThroughProperty("buttonOK")]
	private DarkUIButton _RepositoryList;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonOK_NONOTIF")]
	private DarkUIButton bridgeList;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel2")]
	private DarkLabel classList;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel3")]
	private DarkLabel requestList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_TechnicalSupport")]
	private DarkUIButton m_ValueList;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel5")]
	private DarkLabel m_StubList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OpenFolder_Exception")]
	private DarkUIButton m_WriterList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OpenFolderScenario")]
	private DarkUIButton _WatcherList;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel7")]
	private DarkLabel m_ReponseList;

	internal virtual DarkRichTextBox TB_Error
	{
		[CompilerGenerated]
		get
		{
			return propertyList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			propertyList = value;
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton buttonOK
	{
		[CompilerGenerated]
		get
		{
			return _RepositoryList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateMethod;
			DarkUIButton repositoryList = _RepositoryList;
			if (repositoryList != null)
			{
				repositoryList.Click -= value2;
			}
			_RepositoryList = value;
			repositoryList = _RepositoryList;
			if (repositoryList != null)
			{
				repositoryList.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonOK_NONOTIF
	{
		[CompilerGenerated]
		get
		{
			return bridgeList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertMethod;
			DarkUIButton darkUIButton = bridgeList;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			bridgeList = value;
			darkUIButton = bridgeList;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel DarkLabel2
	{
		[CompilerGenerated]
		get
		{
			return classList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			classList = value;
		}
	}

	internal virtual DarkLabel DarkLabel3
	{
		[CompilerGenerated]
		get
		{
			return requestList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			requestList = value;
		}
	}

	internal virtual DarkUIButton Button_TechnicalSupport
	{
		[CompilerGenerated]
		get
		{
			return m_ValueList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareMethod;
			DarkUIButton valueList = m_ValueList;
			if (valueList != null)
			{
				valueList.Click -= value2;
			}
			m_ValueList = value;
			valueList = m_ValueList;
			if (valueList != null)
			{
				valueList.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel DarkLabel5
	{
		[CompilerGenerated]
		get
		{
			return m_StubList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StubList = value;
		}
	}

	internal virtual DarkUIButton Button_OpenFolder_Exception
	{
		[CompilerGenerated]
		get
		{
			return m_WriterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadMethod;
			DarkUIButton writerList = m_WriterList;
			if (writerList != null)
			{
				writerList.Click -= value2;
			}
			m_WriterList = value;
			writerList = m_WriterList;
			if (writerList != null)
			{
				writerList.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel6")]
	internal virtual DarkLabel DarkLabel6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton Button_OpenFolderScenario
	{
		[CompilerGenerated]
		get
		{
			return _WatcherList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableMethod;
			DarkUIButton watcherList = _WatcherList;
			if (watcherList != null)
			{
				watcherList.Click -= value2;
			}
			_WatcherList = value;
			watcherList = _WatcherList;
			if (watcherList != null)
			{
				watcherList.Click += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel7
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReponseList = value;
		}
	}

	[field: AccessedThroughProperty("Panel1")]
	internal virtual Panel Panel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public ErrorForm()
	{
		CreateMethod();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ReaderList != null)
			{
				m_ReaderList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CreateMethod()
	{
		TB_Error = new DarkRichTextBox();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		DarkLabel1 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		DarkLabel6 = new DarkLabel();
		DarkLabel7 = new DarkLabel();
		Panel1 = new Panel();
		Button_TechnicalSupport = new DarkUIButton();
		Button_OpenFolderScenario = new DarkUIButton();
		Button_OpenFolder_Exception = new DarkUIButton();
		buttonOK = new DarkUIButton();
		ButtonOK_NONOTIF = new DarkUIButton();
		FlowLayoutPanel1.SuspendLayout();
		Panel1.SuspendLayout();
		SuspendLayout();
		TB_Error.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TB_Error.BackColor = Color.FromArgb(60, 63, 65);
		TB_Error.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Error.Location = new Point(12, 25);
		TB_Error.Name = "TB_Error";
		TB_Error.Size = new Size(257, 247);
		TB_Error.TabIndex = 0;
		TB_Error.Text = "";
		FlowLayoutPanel1.Controls.Add(buttonOK);
		FlowLayoutPanel1.Controls.Add(ButtonOK_NONOTIF);
		FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
		FlowLayoutPanel1.Location = new Point(12, 278);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(492, 28);
		FlowLayoutPanel1.TabIndex = 1;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(12, 6);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(229, 13);
		DarkLabel1.TabIndex = 2;
		DarkLabel1.Text = "Command has encountered the following error :";
		DarkLabel2.AutoSize = true;
		DarkLabel2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(35, 7);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(162, 20);
		DarkLabel2.TabIndex = 0;
		DarkLabel2.Text = "How to report a bug ?";
		DarkLabel2.TextAlign = ContentAlignment.TopCenter;
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(7, 30);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(208, 13);
		DarkLabel3.TabIndex = 0;
		DarkLabel3.Text = "Create a thread on technical support forum";
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(7, 87);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(29, 13);
		DarkLabel4.TabIndex = 4;
		DarkLabel4.Text = "With";
		DarkLabel5.AutoSize = true;
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(7, 107);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(139, 13);
		DarkLabel5.TabIndex = 5;
		DarkLabel5.Text = "1.The exception log located";
		DarkLabel6.AutoSize = true;
		DarkLabel6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel6.Location = new Point(7, 126);
		DarkLabel6.Name = "DarkLabel6";
		DarkLabel6.Size = new Size(116, 13);
		DarkLabel6.TabIndex = 7;
		DarkLabel6.Text = "2.The scenario located";
		DarkLabel7.AutoSize = true;
		DarkLabel7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel7.Location = new Point(7, 145);
		DarkLabel7.Name = "DarkLabel7";
		DarkLabel7.Size = new Size(194, 13);
		DarkLabel7.TabIndex = 9;
		DarkLabel7.Text = "3. Any factual details or any impressions";
		Panel1.BackColor = Color.FromArgb(40, 40, 40);
		Panel1.Controls.Add(Button_TechnicalSupport);
		Panel1.Controls.Add(DarkLabel7);
		Panel1.Controls.Add(DarkLabel2);
		Panel1.Controls.Add(Button_OpenFolderScenario);
		Panel1.Controls.Add(DarkLabel3);
		Panel1.Controls.Add(DarkLabel6);
		Panel1.Controls.Add(DarkLabel4);
		Panel1.Controls.Add(Button_OpenFolder_Exception);
		Panel1.Controls.Add(DarkLabel5);
		Panel1.Location = new Point(275, 25);
		Panel1.Name = "Panel1";
		Panel1.Size = new Size(229, 250);
		Panel1.TabIndex = 10;
		Button_TechnicalSupport.BackColor = Color.Transparent;
		Button_TechnicalSupport.DialogResult = DialogResult.None;
		Button_TechnicalSupport.ForeColor = SystemColors.Control;
		Button_TechnicalSupport.Location = new Point(13, 46);
		Button_TechnicalSupport.Name = "Button_TechnicalSupport";
		Button_TechnicalSupport.RoundRadius = 0;
		Button_TechnicalSupport.Size = new Size(205, 33);
		Button_TechnicalSupport.TabIndex = 3;
		Button_TechnicalSupport.Text = "Technical Support";
		Button_OpenFolderScenario.BackColor = Color.Transparent;
		Button_OpenFolderScenario.DialogResult = DialogResult.None;
		Button_OpenFolderScenario.ForeColor = SystemColors.Control;
		Button_OpenFolderScenario.Location = new Point(123, 124);
		Button_OpenFolderScenario.Name = "Button_OpenFolderScenario";
		Button_OpenFolderScenario.RoundRadius = 0;
		Button_OpenFolderScenario.Size = new Size(30, 19);
		Button_OpenFolderScenario.TabIndex = 8;
		Button_OpenFolderScenario.Text = "here";
		Button_OpenFolder_Exception.BackColor = Color.Transparent;
		Button_OpenFolder_Exception.DialogResult = DialogResult.None;
		Button_OpenFolder_Exception.ForeColor = SystemColors.Control;
		Button_OpenFolder_Exception.Location = new Point(146, 104);
		Button_OpenFolder_Exception.Name = "Button_OpenFolder_Exception";
		Button_OpenFolder_Exception.RoundRadius = 0;
		Button_OpenFolder_Exception.Size = new Size(30, 19);
		Button_OpenFolder_Exception.TabIndex = 6;
		Button_OpenFolder_Exception.Text = "here";
		buttonOK.BackColor = Color.Transparent;
		buttonOK.DialogResult = DialogResult.OK;
		buttonOK.ForeColor = SystemColors.Control;
		buttonOK.Location = new Point(3, 3);
		buttonOK.Name = "buttonOK";
		buttonOK.RoundRadius = 0;
		buttonOK.Size = new Size(240, 23);
		buttonOK.TabIndex = 0;
		buttonOK.Text = "确定";
		ButtonOK_NONOTIF.BackColor = Color.Transparent;
		ButtonOK_NONOTIF.DialogResult = DialogResult.Ignore;
		ButtonOK_NONOTIF.ForeColor = SystemColors.Control;
		ButtonOK_NONOTIF.Location = new Point(249, 3);
		ButtonOK_NONOTIF.Name = "ButtonOK_NONOTIF";
		ButtonOK_NONOTIF.RoundRadius = 0;
		ButtonOK_NONOTIF.Size = new Size(240, 23);
		ButtonOK_NONOTIF.TabIndex = 1;
		ButtonOK_NONOTIF.Text = "OK (don't get notified again)";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 60, 60);
		base.ClientSize = new Size(516, 309);
		base.Controls.Add(Panel1);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(FlowLayoutPanel1);
		base.Controls.Add(TB_Error);
		MaximumSize = new Size(532, 348);
		base.Name = "ErrorForm";
		Text = "错误";
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		Panel1.ResumeLayout(performLayout: false);
		Panel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public static void Open(ExceptionEntry exceptionEntry_0, string string_0 = "")
	{
		ErrorForm errorForm = new ErrorForm();
		if (string.IsNullOrEmpty(string_0))
		{
			errorForm.TB_Error.Text = exceptionEntry_0.Content;
		}
		else
		{
			errorForm.TB_Error.Text = string_0;
		}
		DialogResult dialogResult = errorForm.ShowDialog();
		if (dialogResult != DialogResult.OK && dialogResult == DialogResult.Ignore)
		{
			exceptionEntry_0.UI_Ignored = true;
		}
	}

	public static bool Open(string string_0, bool bool_0 = false)
	{
		if (new ErrorForm
		{
			TB_Error = 
			{
				Text = string_0
			},
			ButtonOK_NONOTIF = 
			{
				Visible = bool_0
			}
		}.ShowDialog() == DialogResult.OK)
		{
			return true;
		}
		return false;
	}

	private void CompareMethod(object sender, EventArgs e)
	{
		try
		{
			Process.Start("https://www.matrixgames.com/forums/viewforum.php?f=10230");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void ReadMethod(object sender, EventArgs e)
	{
		try
		{
			Process.Start(GameGeneral.LogsPath);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void DisableMethod(object sender, EventArgs e)
	{
		try
		{
			Process.Start(GameGeneral.ScenariosRootPath);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void UpdateMethod(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void InsertMethod(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Ignore;
	}
}
