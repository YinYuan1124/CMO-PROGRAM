using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TimeUnderway : DarkSecondaryFormBase
{
	private IContainer _ClassAttr;

	[AccessedThroughProperty("BtnCancel")]
	[CompilerGenerated]
	private DarkUIButton m_RequestAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOK")]
	private DarkUIButton valueAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("DaysUnderway_TextBox")]
	private DarkUITextBox stubAttr;

	[AccessedThroughProperty("HoursUnderway_TextBox")]
	[CompilerGenerated]
	private DarkUITextBox _WriterAttr;

	[AccessedThroughProperty("MinUnderway_TextBox")]
	[CompilerGenerated]
	private DarkUITextBox m_SpecificationAttr;

	[AccessedThroughProperty("SecUnderway_TextBox")]
	[CompilerGenerated]
	private DarkUITextBox _WatcherAttr;

	[AccessedThroughProperty("DarkLabel2")]
	[CompilerGenerated]
	private DarkLabel descriptorAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("lblsec")]
	private DarkLabel taskAttr;

	public ActiveUnit theAU;

	internal DarkUIButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return m_RequestAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptibleVisitor;
			DarkUIButton requestAttr = m_RequestAttr;
			if (requestAttr != null)
			{
				requestAttr.Click -= value2;
			}
			m_RequestAttr = value;
			requestAttr = m_RequestAttr;
			if (requestAttr != null)
			{
				requestAttr.Click += value2;
			}
		}
	}

	internal DarkUIButton BtnOK
	{
		[CompilerGenerated]
		get
		{
			return valueAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleVisitor;
			DarkUIButton darkUIButton = valueAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			valueAttr = value;
			darkUIButton = valueAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox DaysUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return stubAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = ReadInterruptibleVisitor;
			DarkUITextBox darkUITextBox = stubAttr;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			stubAttr = value;
			darkUITextBox = stubAttr;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal DarkUITextBox HoursUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _WriterAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = DisableInterruptibleVisitor;
			DarkUITextBox writerAttr = _WriterAttr;
			if (writerAttr != null)
			{
				writerAttr.TextChanged -= value2;
			}
			_WriterAttr = value;
			writerAttr = _WriterAttr;
			if (writerAttr != null)
			{
				writerAttr.TextChanged += value2;
			}
		}
	}

	internal DarkUITextBox MinUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return m_SpecificationAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = UpdateInterruptibleVisitor;
			DarkUITextBox specificationAttr = m_SpecificationAttr;
			if (specificationAttr != null)
			{
				specificationAttr.TextChanged -= value2;
			}
			m_SpecificationAttr = value;
			specificationAttr = m_SpecificationAttr;
			if (specificationAttr != null)
			{
				specificationAttr.TextChanged += value2;
			}
		}
	}

	internal DarkUITextBox SecUnderway_TextBox
	{
		[CompilerGenerated]
		get
		{
			return _WatcherAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = InsertInterruptibleVisitor;
			DarkUITextBox watcherAttr = _WatcherAttr;
			if (watcherAttr != null)
			{
				watcherAttr.TextChanged -= value2;
			}
			_WatcherAttr = value;
			watcherAttr = _WatcherAttr;
			if (watcherAttr != null)
			{
				watcherAttr.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel2
	{
		[CompilerGenerated]
		get
		{
			return descriptorAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			descriptorAttr = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal DarkLabel DarkLabel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel lblsec
	{
		[CompilerGenerated]
		get
		{
			return taskAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			taskAttr = value;
		}
	}

	public TimeUnderway()
	{
		base.Shown += InstantiateInterruptibleVisitor;
		PopInterruptibleVisitor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ClassAttr != null)
			{
				_ClassAttr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PopInterruptibleVisitor()
	{
		BtnCancel = new DarkUIButton();
		BtnOK = new DarkUIButton();
		Label1 = new DarkLabel();
		DaysUnderway_TextBox = new DarkUITextBox();
		HoursUnderway_TextBox = new DarkUITextBox();
		MinUnderway_TextBox = new DarkUITextBox();
		SecUnderway_TextBox = new DarkUITextBox();
		DarkLabel1 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		lblsec = new DarkLabel();
		SuspendLayout();
		BtnCancel.BackColor = Color.Transparent;
		BtnCancel.DialogResult = DialogResult.Cancel;
		BtnCancel.ForeColor = SystemColors.Control;
		BtnCancel.Location = new Point(267, 89);
		BtnCancel.Name = "BtnCancel";
		BtnCancel.RoundRadius = 0;
		BtnCancel.Size = new Size(75, 23);
		BtnCancel.TabIndex = 4;
		BtnCancel.Text = "取消";
		BtnOK.BackColor = Color.Transparent;
		BtnOK.DialogResult = DialogResult.None;
		BtnOK.ForeColor = SystemColors.Control;
		BtnOK.Location = new Point(24, 89);
		BtnOK.Name = "BtnOK";
		BtnOK.RoundRadius = 0;
		BtnOK.Size = new Size(75, 23);
		BtnOK.TabIndex = 5;
		BtnOK.Text = "确定";
		Label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(19, 9);
		Label1.Name = "Label1";
		Label1.Size = new Size(321, 25);
		Label1.TabIndex = 4;
		Label1.Text = "Set time underway for the selected unit";
		DaysUnderway_TextBox.AutoCompleteCustomSource = null;
		DaysUnderway_TextBox.AutoCompleteMode = AutoCompleteMode.None;
		DaysUnderway_TextBox.AutoCompleteSource = AutoCompleteSource.None;
		DaysUnderway_TextBox.BackColor = Color.Transparent;
		DaysUnderway_TextBox.ForeColor = Color.FromArgb(189, 189, 189);
		DaysUnderway_TextBox.Image = null;
		DaysUnderway_TextBox.Lines = null;
		DaysUnderway_TextBox.Location = new Point(24, 60);
		DaysUnderway_TextBox.MaxLength = 2;
		DaysUnderway_TextBox.Multiline = false;
		DaysUnderway_TextBox.Name = "DaysUnderway_TextBox";
		DaysUnderway_TextBox.ReadOnly = false;
		DaysUnderway_TextBox.ScrollBars = ScrollBars.None;
		DaysUnderway_TextBox.SelectionStart = 0;
		DaysUnderway_TextBox.Size = new Size(57, 23);
		DaysUnderway_TextBox.TabIndex = 0;
		DaysUnderway_TextBox.Text = "0";
		DaysUnderway_TextBox.TextAlign = HorizontalAlignment.Center;
		DaysUnderway_TextBox.UseSystemPasswordChar = false;
		DaysUnderway_TextBox.WatermarkText = "";
		HoursUnderway_TextBox.AutoCompleteCustomSource = null;
		HoursUnderway_TextBox.AutoCompleteMode = AutoCompleteMode.None;
		HoursUnderway_TextBox.AutoCompleteSource = AutoCompleteSource.None;
		HoursUnderway_TextBox.BackColor = Color.Transparent;
		HoursUnderway_TextBox.ForeColor = Color.FromArgb(189, 189, 189);
		HoursUnderway_TextBox.Image = null;
		HoursUnderway_TextBox.Lines = null;
		HoursUnderway_TextBox.Location = new Point(108, 60);
		HoursUnderway_TextBox.MaxLength = 2;
		HoursUnderway_TextBox.Multiline = false;
		HoursUnderway_TextBox.Name = "HoursUnderway_TextBox";
		HoursUnderway_TextBox.ReadOnly = false;
		HoursUnderway_TextBox.ScrollBars = ScrollBars.None;
		HoursUnderway_TextBox.SelectionStart = 0;
		HoursUnderway_TextBox.Size = new Size(57, 23);
		HoursUnderway_TextBox.TabIndex = 1;
		HoursUnderway_TextBox.Text = "0";
		HoursUnderway_TextBox.TextAlign = HorizontalAlignment.Center;
		HoursUnderway_TextBox.UseSystemPasswordChar = false;
		HoursUnderway_TextBox.WatermarkText = "";
		MinUnderway_TextBox.AutoCompleteCustomSource = null;
		MinUnderway_TextBox.AutoCompleteMode = AutoCompleteMode.None;
		MinUnderway_TextBox.AutoCompleteSource = AutoCompleteSource.None;
		MinUnderway_TextBox.BackColor = Color.Transparent;
		MinUnderway_TextBox.ForeColor = Color.FromArgb(189, 189, 189);
		MinUnderway_TextBox.Image = null;
		MinUnderway_TextBox.Lines = null;
		MinUnderway_TextBox.Location = new Point(194, 60);
		MinUnderway_TextBox.MaxLength = 2;
		MinUnderway_TextBox.Multiline = false;
		MinUnderway_TextBox.Name = "MinUnderway_TextBox";
		MinUnderway_TextBox.ReadOnly = false;
		MinUnderway_TextBox.ScrollBars = ScrollBars.None;
		MinUnderway_TextBox.SelectionStart = 0;
		MinUnderway_TextBox.Size = new Size(57, 23);
		MinUnderway_TextBox.TabIndex = 2;
		MinUnderway_TextBox.Text = "0";
		MinUnderway_TextBox.TextAlign = HorizontalAlignment.Center;
		MinUnderway_TextBox.UseSystemPasswordChar = false;
		MinUnderway_TextBox.WatermarkText = "";
		SecUnderway_TextBox.AutoCompleteCustomSource = null;
		SecUnderway_TextBox.AutoCompleteMode = AutoCompleteMode.None;
		SecUnderway_TextBox.AutoCompleteSource = AutoCompleteSource.None;
		SecUnderway_TextBox.BackColor = Color.Transparent;
		SecUnderway_TextBox.ForeColor = Color.FromArgb(189, 189, 189);
		SecUnderway_TextBox.Image = null;
		SecUnderway_TextBox.Lines = null;
		SecUnderway_TextBox.Location = new Point(285, 60);
		SecUnderway_TextBox.MaxLength = 2;
		SecUnderway_TextBox.Multiline = false;
		SecUnderway_TextBox.Name = "SecUnderway_TextBox";
		SecUnderway_TextBox.ReadOnly = false;
		SecUnderway_TextBox.ScrollBars = ScrollBars.None;
		SecUnderway_TextBox.SelectionStart = 0;
		SecUnderway_TextBox.Size = new Size(57, 23);
		SecUnderway_TextBox.TabIndex = 3;
		SecUnderway_TextBox.Text = "0";
		SecUnderway_TextBox.TextAlign = HorizontalAlignment.Center;
		SecUnderway_TextBox.UseSystemPasswordChar = false;
		SecUnderway_TextBox.WatermarkText = "";
		DarkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(19, 34);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(51, 25);
		DarkLabel1.Text = "天";
		DarkLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(103, 34);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(60, 25);
		DarkLabel2.TabIndex = 2;
		DarkLabel2.Text = "Hours";
		DarkLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(189, 34);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(75, 25);
		DarkLabel3.TabIndex = 1;
		DarkLabel3.Text = "Minutes";
		lblsec.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		lblsec.AutoSize = true;
		lblsec.ForeColor = Color.FromArgb(220, 220, 220);
		lblsec.Location = new Point(280, 34);
		lblsec.Name = "lblsec";
		lblsec.Size = new Size(79, 25);
		lblsec.TabIndex = 0;
		lblsec.Text = "Seconds";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(358, 122);
		base.Controls.Add(lblsec);
		base.Controls.Add(DarkLabel3);
		base.Controls.Add(DarkLabel2);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(SecUnderway_TextBox);
		base.Controls.Add(MinUnderway_TextBox);
		base.Controls.Add(HoursUnderway_TextBox);
		base.Controls.Add(DaysUnderway_TextBox);
		base.Controls.Add(Label1);
		base.Controls.Add(BtnCancel);
		base.Controls.Add(BtnOK);
		base.FormBorderStyle = FormBorderStyle.None;
		base.MaximizeBox = false;
		MaximumSize = new Size(358, 122);
		base.MinimizeBox = false;
		MinimumSize = new Size(358, 122);
		base.Name = "TimeUnderway";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "Time Underway";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void InstantiateInterruptibleVisitor(object sender, EventArgs e)
	{
		if (theAU != null)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(theAU.TimeUnderway);
			string text = timeSpan.Days.ToString();
			string text2 = timeSpan.Hours.ToString();
			string text3 = timeSpan.Minutes.ToString();
			string text4 = timeSpan.Seconds.ToString();
			DaysUnderway_TextBox.Text = text;
			HoursUnderway_TextBox.Text = text2;
			MinUnderway_TextBox.Text = text3;
			SecUnderway_TextBox.Text = text4;
			DaysUnderway_TextBox.Select();
			SelectNextControl(base.ActiveControl, forward: true, tabStopOnly: true, nested: true, wrap: false);
		}
	}

	private void CreateInterruptibleVisitor(object sender, EventArgs e)
	{
		Close();
	}

	private void CompareInterruptibleVisitor(object sender, EventArgs e)
	{
		try
		{
			if (!int.TryParse(DaysUnderway_TextBox.Text, out var result) && DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == DialogResult.OK)
			{
				DaysUnderway_TextBox.Text = "0";
				return;
			}
			if (!int.TryParse(HoursUnderway_TextBox.Text, out var result2) && DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == DialogResult.OK)
			{
				HoursUnderway_TextBox.Text = "0";
				return;
			}
			if (!int.TryParse(MinUnderway_TextBox.Text, out var result3) && DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == DialogResult.OK)
			{
				MinUnderway_TextBox.Text = "0";
				return;
			}
			if (!int.TryParse(SecUnderway_TextBox.Text, out var result4) && DarkMessageBox.ShowError("Invalid input. Enter a number.", "Error") == DialogResult.OK)
			{
				SecUnderway_TextBox.Text = "0";
				return;
			}
			result = Conversions.ToInteger(DaysUnderway_TextBox.Text) * 3600 * 24;
			result2 = Conversions.ToInteger(HoursUnderway_TextBox.Text) * 3600;
			result3 = Conversions.ToInteger(MinUnderway_TextBox.Text) * 60;
			result4 = Conversions.ToInteger(SecUnderway_TextBox.Text);
			float num = result + result2 + result3 + result4;
			if (theAU.GetType().Equals(typeof(Aircraft)))
			{
				((Aircraft)theAU).AirborneTime = num;
			}
			theAU.TimeUnderway = num;
			Close();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReadInterruptibleVisitor(object object_0)
	{
		if (int.TryParse(DaysUnderway_TextBox.Text, out var result) && result < 0)
		{
			result = 0;
		}
	}

	private void DisableInterruptibleVisitor(object object_0)
	{
		if (int.TryParse(HoursUnderway_TextBox.Text, out var result) && result < 0)
		{
			result = 0;
		}
	}

	private void UpdateInterruptibleVisitor(object object_0)
	{
		if (int.TryParse(MinUnderway_TextBox.Text, out var result) && result < 0)
		{
			result = 0;
		}
	}

	private void InsertInterruptibleVisitor(object object_0)
	{
		if (int.TryParse(lblsec.Text, out var result) && result < 0)
		{
			result = 0;
		}
	}
}
