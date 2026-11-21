using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddSide : DarkSecondaryFormBase
{
	private IContainer rulesProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox _ServiceProperty;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_SystemProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton m_CandidateProperty;

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _ServiceProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = SelectTests;
			DarkUITextBox serviceProperty = _ServiceProperty;
			if (serviceProperty != null)
			{
				serviceProperty.TextChanged -= value2;
			}
			_ServiceProperty = value;
			serviceProperty = _ServiceProperty;
			if (serviceProperty != null)
			{
				serviceProperty.TextChanged += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_SystemProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeTests;
			EventHandler value3 = PatchTests;
			DarkUIButton systemProperty = m_SystemProperty;
			if (systemProperty != null)
			{
				systemProperty.Click -= value2;
				systemProperty.DoubleClick -= value3;
			}
			m_SystemProperty = value;
			systemProperty = m_SystemProperty;
			if (systemProperty != null)
			{
				systemProperty.Click += value2;
				systemProperty.DoubleClick += value3;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewTests;
			DarkUIButton candidateProperty = m_CandidateProperty;
			if (candidateProperty != null)
			{
				candidateProperty.Click -= value2;
			}
			m_CandidateProperty = value;
			candidateProperty = m_CandidateProperty;
			if (candidateProperty != null)
			{
				candidateProperty.Click += value2;
			}
		}
	}

	public AddSide()
	{
		base.FormClosing += CallTests;
		base.Load += LogoutTests;
		base.KeyDown += ValidateTests;
		DestroyTests();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && rulesProperty != null)
			{
				rulesProperty.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DestroyTests()
	{
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		SuspendLayout();
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(13, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(54, 17);
		Label1.TabIndex = 0;
		Label1.Text = "名称:";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(57, 10);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(212, 20);
		TextBox1.TabIndex = 0;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(57, 36);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 2;
		Button1.Text = "确定";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.Cancel;
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(194, 36);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 3;
		Button2.Text = "取消";
		base.AcceptButton = Button1;
		base.AutoScaleMode = AutoScaleMode.None;
		base.CancelButton = Button2;
		base.ClientSize = new Size(281, 68);
		base.ControlBox = false;
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddSide";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "创建一个新分方";
		ResumeLayout(performLayout: false);
	}

	private void ComputeTests(object sender, EventArgs e)
	{
		string string_ = TextBox1.Text;
		Scenario scenario_ = Client.CurrentScenario;
		Client.AddSide(string_, ref scenario_);
		Close();
	}

	private void PatchTests(object sender, EventArgs e)
	{
		string string_ = TextBox1.Text;
		Scenario scenario_ = Client.CurrentScenario;
		Client.AddSide(string_, ref scenario_);
		Close();
	}

	private void SelectTests(object object_0)
	{
		Button1.Enabled = Operators.CompareString(TextBox1.Text, "", TextCompare: true) != 0;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			if (Operators.CompareString(Strings.LCase(sides_ReadOnly[i].Name), Strings.LCase(TextBox1.Text), TextCompare: true) == 0)
			{
				Button1.Enabled = false;
			}
		}
	}

	private void CallTests(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void LogoutTests(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		Button1.Enabled = Operators.CompareString(TextBox1.Text, "", TextCompare: true) != 0;
		SendKeys.Send("{TAB}");
	}

	private void ViewTests(object sender, EventArgs e)
	{
		Close();
	}

	private void ValidateTests(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}
}
