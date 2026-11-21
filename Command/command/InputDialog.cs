using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class InputDialog : Form
{
	private IContainer modelContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton customerContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_OK")]
	private DarkUIButton m_SerializerContainer;

	[field: AccessedThroughProperty("TB_Main")]
	internal virtual DarkUITextBox TB_Main
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return customerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillIterator;
			DarkUIButton darkUIButton = customerContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			customerContainer = value;
			darkUIButton = customerContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetIterator;
			DarkUIButton serializerContainer = m_SerializerContainer;
			if (serializerContainer != null)
			{
				serializerContainer.Click -= value2;
			}
			m_SerializerContainer = value;
			serializerContainer = m_SerializerContainer;
			if (serializerContainer != null)
			{
				serializerContainer.Click += value2;
			}
		}
	}

	public InputDialog()
	{
		FindIterator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && modelContainer != null)
			{
				modelContainer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void FindIterator()
	{
		TB_Main = new DarkUITextBox();
		Button_Cancel = new DarkUIButton();
		Button_OK = new DarkUIButton();
		SuspendLayout();
		TB_Main.AutoCompleteCustomSource = null;
		TB_Main.AutoCompleteMode = AutoCompleteMode.None;
		TB_Main.AutoCompleteSource = AutoCompleteSource.None;
		TB_Main.BackColor = Color.Transparent;
		TB_Main.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Main.Image = null;
		TB_Main.Lines = null;
		TB_Main.Location = new Point(12, 12);
		TB_Main.MaxLength = 32767;
		TB_Main.Multiline = false;
		TB_Main.Name = "TB_Main";
		TB_Main.ReadOnly = false;
		TB_Main.ScrollBars = ScrollBars.None;
		TB_Main.SelectionStart = 0;
		TB_Main.Size = new Size(200, 24);
		TB_Main.TabIndex = 0;
		TB_Main.TextAlign = HorizontalAlignment.Left;
		TB_Main.UseSystemPasswordChar = false;
		TB_Main.WatermarkText = "Enter text . . .";
		Button_Cancel.BackColor = Color.Transparent;
		Button_Cancel.DialogResult = DialogResult.Cancel;
		Button_Cancel.ForeColor = SystemColors.Control;
		Button_Cancel.Location = new Point(294, 11);
		Button_Cancel.Name = "Button_Cancel";
		Button_Cancel.RoundRadius = 0;
		Button_Cancel.Size = new Size(70, 23);
		Button_Cancel.TabIndex = 1;
		Button_Cancel.Text = "取消";
		Button_OK.BackColor = Color.Transparent;
		Button_OK.DialogResult = DialogResult.None;
		Button_OK.ForeColor = SystemColors.Control;
		Button_OK.Location = new Point(218, 11);
		Button_OK.Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		Button_OK.Size = new Size(70, 23);
		Button_OK.TabIndex = 2;
		Button_OK.Text = "确定";
		base.AcceptButton = Button_OK;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.CancelButton = Button_Cancel;
		base.ClientSize = new Size(373, 46);
		base.Controls.Add(Button_OK);
		base.Controls.Add(Button_Cancel);
		base.Controls.Add(TB_Main);
		base.Name = "InputDialog";
		Text = "输入对话框";
		ResumeLayout(performLayout: false);
	}

	private void SetIterator(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void FillIterator(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	public static string CallDialog(string string_0 = "User input dialog", string string_1 = "Enter Text . . .", string string_2 = "")
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.TB_Main.WatermarkText = string_1;
		inputDialog.Text = string_0;
		if (inputDialog.ShowDialog() == DialogResult.OK)
		{
			if (string.IsNullOrEmpty(inputDialog.TB_Main.Text))
			{
				return string_2;
			}
			return inputDialog.TB_Main.Text;
		}
		return string_2;
	}
}
