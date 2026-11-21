using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command;
using Microsoft.VisualBasic.CompilerServices;

namespace OpenDis.Services;

[DesignerGenerated]
internal class MerchantSchema : DarkSecondaryFormBase
{
	private IDisposable m_CallbackSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox m_ThreadSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("LinkLabel2")]
	private LinkLabel m_RuleSchema;

	[field: AccessedThroughProperty("LinkLabel1")]
	internal virtual LinkLabel LinkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button1")]
	internal virtual DarkUIButton Button1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ThreadSchema = value;
		}
	}

	internal virtual LinkLabel LinkLabel2
	{
		[CompilerGenerated]
		get
		{
			return m_RuleSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RuleSchema = value;
		}
	}

	public MerchantSchema()
	{
		PushInterruptibleCode();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_CallbackSchema != null)
			{
				m_CallbackSchema.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PushInterruptibleCode()
	{
		LinkLabel1 = new LinkLabel();
		Button1 = new DarkUIButton();
		TextBox1 = new DarkUITextBox();
		LinkLabel2 = new LinkLabel();
		SuspendLayout();
		LinkLabel1.AutoSize = true;
		LinkLabel1.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, 161);
		LinkLabel1.ForeColor = SystemColors.Control;
		LinkLabel1.LinkArea = new LinkArea(90, 19);
		LinkLabel1.Location = new Point(12, 9);
		LinkLabel1.MaximumSize = new Size(350, 0);
		LinkLabel1.Name = "LinkLabel1";
		LinkLabel1.Size = new Size(126, 23);
		LinkLabel1.TabIndex = 0;
		LinkLabel1.Text = "Your revoke code is:";
		LinkLabel1.UseCompatibleTextRendering = true;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(144, 175);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 34);
		Button1.TabIndex = 1;
		Button1.Text = "确定";
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(12, 35);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = true;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(360, 77);
		TextBox1.TabIndex = 2;
		TextBox1.Text = "XXXX-XXXX-XXXX-XXXX";
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		LinkLabel2.AutoSize = true;
		LinkLabel2.Font = new Font("Segoe UI", 10f);
		LinkLabel2.ForeColor = SystemColors.Control;
		LinkLabel2.LinkArea = new LinkArea(0, 0);
		LinkLabel2.LinkColor = Color.SkyBlue;
		LinkLabel2.Location = new Point(8, 115);
		LinkLabel2.MaximumSize = new Size(360, 0);
		LinkLabel2.Name = "LinkLabel2";
		LinkLabel2.Size = new Size(350, 57);
		LinkLabel2.TabIndex = 3;
		LinkLabel2.Text = "Navigate to https://pro.matrixgames.com/ and follow the steps detailed in the CPE manual for a replacement license. The program will now exit.";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(384, 221);
		base.ControlBox = false;
		base.Controls.Add(LinkLabel2);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Button1);
		base.Controls.Add(LinkLabel1);
		base.FormBorderStyle = FormBorderStyle.None;
		base.MinimizeBox = false;
		base.Name = "PE_LicenseRevoke";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "License file missing!";
		base.TopMost = true;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
