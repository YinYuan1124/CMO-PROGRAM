using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using MSDN.Html.Editor;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TitleAndDescription : DarkSecondaryFormBase
{
	private IContainer m_FilterAttr;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton m_InterpreterAttr;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton containerAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox m_ModelAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditHTML")]
	private DarkUIButton _CustomerAttr;

	public string Title;

	public string Description;

	[field: AccessedThroughProperty("Editor1")]
	private HtmlEditorControl Editor1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushInterruptibleVisitor;
			DarkUIButton interpreterAttr = m_InterpreterAttr;
			if (interpreterAttr != null)
			{
				interpreterAttr.Click -= value2;
			}
			m_InterpreterAttr = value;
			interpreterAttr = m_InterpreterAttr;
			if (interpreterAttr != null)
			{
				interpreterAttr.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return containerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateInterruptibleVisitor;
			DarkUIButton darkUIButton = containerAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			containerAttr = value;
			darkUIButton = containerAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ModelAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ModelAttr = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_EditHTML
	{
		[CompilerGenerated]
		get
		{
			return _CustomerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectInterruptibleVisitor;
			DarkUIButton customerAttr = _CustomerAttr;
			if (customerAttr != null)
			{
				customerAttr.Click -= value2;
			}
			_CustomerAttr = value;
			customerAttr = _CustomerAttr;
			if (customerAttr != null)
			{
				customerAttr.Click += value2;
			}
		}
	}

	public TitleAndDescription()
	{
		base.Shown += ForgotInterruptibleVisitor;
		base.Load += OrderInterruptibleVisitor;
		CalcInterruptibleVisitor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_FilterAttr != null)
			{
				m_FilterAttr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalcInterruptibleVisitor()
	{
		Editor1 = new HtmlEditorControl();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label2 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Label1 = new DarkLabel();
		Button_EditHTML = new DarkUIButton();
		SuspendLayout();
		((Control)Editor1).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		((Control)Editor1).BackColor = Color.FromArgb(69, 73, 74);
		Editor1.BodyBackColor = Color.FromArgb(43, 43, 43);
		Editor1.BodyForeColor = Color.FromArgb(220, 220, 220);
		Editor1.BorderSize = 0;
		((UserControl)Editor1).BorderStyle = BorderStyle.FixedSingle;
		((Control)Editor1).ForeColor = Color.FromArgb(220, 220, 220);
		Editor1.InnerText = null;
		((Control)Editor1).Location = new Point(6, 67);
		((Control)Editor1).Name = "Editor1";
		((Control)Editor1).Size = new Size(869, 414);
		((Control)Editor1).TabIndex = 33;
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(800, 487);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 32;
		Button2.Text = "取消";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(6, 487);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 31;
		Button1.Text = "确定";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(3, 51);
		Label2.Name = "Label2";
		Label2.Size = new Size(63, 13);
		Label2.TabIndex = 30;
		Label2.Text = "描述：";
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(43, 12);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(832, 20);
		TextBox1.TabIndex = 29;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(3, 15);
		Label1.Name = "Label1";
		Label1.Size = new Size(30, 13);
		Label1.TabIndex = 28;
		Label1.Text = "标题：";
		Button_EditHTML.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_EditHTML.BackColor = Color.Transparent;
		Button_EditHTML.DialogResult = DialogResult.None;
		Button_EditHTML.Font = new Font(Client.CommandDefaultFont.FontFamily, 10f);
		Button_EditHTML.ForeColor = SystemColors.Control;
		Button_EditHTML.Location = new Point(745, 41);
		Button_EditHTML.Name = "Button_EditHTML";
		Button_EditHTML.RoundRadius = 0;
		Button_EditHTML.Size = new Size(130, 23);
		Button_EditHTML.TabIndex = 34;
		Button_EditHTML.Text = "编辑HTML源代码";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(878, 513);
		base.Controls.Add(Button_EditHTML);
		base.Controls.Add(Editor1);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label2);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "TitleAndDescription";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "标题和描述";
		ResumeLayout(performLayout: false);
	}

	private void RateInterruptibleVisitor(object sender, EventArgs e)
	{
		Title = TextBox1.Text;
		Description = Editor1.BodyHtml;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void FlushInterruptibleVisitor(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void ForgotInterruptibleVisitor(object sender, EventArgs e)
	{
		TextBox1.Text = Title;
		if (!string.IsNullOrEmpty(Description))
		{
			Editor1.BodyHtml = Description;
		}
	}

	private void CollectInterruptibleVisitor(object sender, EventArgs e)
	{
		Editor1.HtmlContentsEdit();
	}

	private void OrderInterruptibleVisitor(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}
}
