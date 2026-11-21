using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddRangeSymbol : DarkSecondaryFormBase
{
	private IContainer filterProperty;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel testsProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox interpreterProperty;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox containerProperty;

	[AccessedThroughProperty("TextBox2")]
	[CompilerGenerated]
	private DarkUITextBox m_AdvisorProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel m_CustomerProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton refProperty;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel m_ConnectionProperty;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _ProccesorProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton strategyProperty;

	[CompilerGenerated]
	[AccessedThroughProperty("ColorDialog1")]
	private ColorDialog _ConfigurationProperty;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return testsProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsProperty = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return interpreterProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interpreterProperty = value;
		}
	}

	internal DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return containerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcTask;
			DarkUIComboBox darkUIComboBox = containerProperty;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectedIndexChanged -= value2;
			}
			containerProperty = value;
			darkUIComboBox = containerProperty;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TextBox2
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorProperty = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_CustomerProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CustomerProperty = value;
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return refProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryTask;
			DarkUIButton darkUIButton = refProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			refProperty = value;
			darkUIButton = refProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox3")]
	internal DarkUITextBox TextBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConnectionProperty = value;
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal DarkLabel Label8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox4")]
	internal DarkUITextBox TextBox4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _ProccesorProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetTask;
			DarkUIButton proccesorProperty = _ProccesorProperty;
			if (proccesorProperty != null)
			{
				proccesorProperty.Click -= value2;
			}
			_ProccesorProperty = value;
			proccesorProperty = _ProccesorProperty;
			if (proccesorProperty != null)
			{
				proccesorProperty.Click += value2;
			}
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return strategyProperty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapTask;
			DarkUIButton darkUIButton = strategyProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			strategyProperty = value;
			darkUIButton = strategyProperty;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal ColorDialog SearchFilter()
	{
		return _ConfigurationProperty;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void EnableFilter(ColorDialog colorDialog_0)
	{
		_ConfigurationProperty = colorDialog_0;
	}

	public AddRangeSymbol()
	{
		base.FormClosing += PublishTask;
		base.Load += AwakeTask;
		base.KeyDown += SortTask;
		DefineTask();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && filterProperty != null)
		{
			filterProperty.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void DefineTask()
	{
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		ComboBox1 = new DarkUIComboBox();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		TextBox2 = new DarkUITextBox();
		Label4 = new DarkLabel();
		Label5 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label6 = new DarkLabel();
		TextBox3 = new DarkUITextBox();
		Label7 = new DarkLabel();
		Label8 = new DarkLabel();
		TextBox4 = new DarkUITextBox();
		Button2 = new DarkUIButton();
		Button3 = new DarkUIButton();
		EnableFilter(new ColorDialog());
		SuspendLayout();
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(12, 9);
		Label1.Name = "Label1";
		Label1.Size = new Size(60, 13);
		Label1.TabIndex = 0;
		Label1.Text = "描述";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(86, 6);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(191, 24);
		TextBox1.TabIndex = 1;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		ComboBox1.BackColor = Color.Transparent;
		ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox1.Font = new Font("Segoe UI", 7f);
		ComboBox1.FormattingEnabled = true;
		ComboBox1.Items.AddRange(new object[1] { "Circle" });
		ComboBox1.Location = new Point(86, 33);
		ComboBox1.Name = "ComboBox1";
		ComboBox1.Size = new Size(190, 21);
		ComboBox1.TabIndex = 2;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(12, 36);
		Label2.Name = "Label2";
		Label2.Size = new Size(68, 13);
		Label2.TabIndex = 3;
		Label2.Text = "Symbol Type";
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(12, 91);
		Label3.Name = "Label3";
		Label3.Size = new Size(62, 13);
		Label3.TabIndex = 4;
		Label3.Text = "Range (nm)";
		TextBox2.AutoCompleteCustomSource = null;
		TextBox2.AutoCompleteMode = AutoCompleteMode.None;
		TextBox2.AutoCompleteSource = AutoCompleteSource.None;
		TextBox2.BackColor = Color.Transparent;
		TextBox2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TextBox2.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox2.Image = null;
		TextBox2.Lines = null;
		TextBox2.Location = new Point(86, 88);
		TextBox2.MaxLength = 32767;
		TextBox2.Multiline = false;
		TextBox2.Name = "TextBox2";
		TextBox2.ReadOnly = false;
		TextBox2.SelectionStart = 0;
		TextBox2.Size = new Size(100, 24);
		TextBox2.TabIndex = 5;
		TextBox2.TextAlign = HorizontalAlignment.Left;
		TextBox2.UseSystemPasswordChar = false;
		TextBox2.WatermarkText = "";
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(12, 119);
		Label4.Name = "Label4";
		Label4.Size = new Size(31, 13);
		Label4.TabIndex = 6;
		Label4.Text = "颜色";
		Label5.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(83, 119);
		Label5.Name = "Label5";
		Label5.Size = new Size(45, 13);
		Label5.TabIndex = 7;
		Label5.Text = "Label5";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(201, 114);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 8;
		Button1.Text = "Change...";
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(12, 62);
		Label6.Name = "Label6";
		Label6.Size = new Size(28, 13);
		Label6.TabIndex = 9;
		Label6.Text = "Arcs";
		TextBox3.AutoCompleteCustomSource = null;
		TextBox3.AutoCompleteMode = AutoCompleteMode.None;
		TextBox3.AutoCompleteSource = AutoCompleteSource.None;
		TextBox3.BackColor = Color.Transparent;
		TextBox3.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TextBox3.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox3.Image = null;
		TextBox3.Lines = null;
		TextBox3.Location = new Point(134, 59);
		TextBox3.MaxLength = 32767;
		TextBox3.Multiline = false;
		TextBox3.Name = "TextBox3";
		TextBox3.ReadOnly = false;
		TextBox3.SelectionStart = 0;
		TextBox3.Size = new Size(42, 24);
		TextBox3.TabIndex = 10;
		TextBox3.TextAlign = HorizontalAlignment.Left;
		TextBox3.UseSystemPasswordChar = false;
		TextBox3.WatermarkText = "";
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(83, 62);
		Label7.Name = "Label7";
		Label7.Size = new Size(48, 13);
		Label7.TabIndex = 11;
		Label7.Text = "LeftMost";
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(181, 64);
		Label8.Name = "Label8";
		Label8.Size = new Size(55, 13);
		Label8.TabIndex = 12;
		Label8.Text = "RightMost";
		TextBox4.AutoCompleteCustomSource = null;
		TextBox4.AutoCompleteMode = AutoCompleteMode.None;
		TextBox4.AutoCompleteSource = AutoCompleteSource.None;
		TextBox4.BackColor = Color.Transparent;
		TextBox4.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TextBox4.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox4.Image = null;
		TextBox4.Lines = null;
		TextBox4.Location = new Point(235, 59);
		TextBox4.MaxLength = 32767;
		TextBox4.Multiline = false;
		TextBox4.Name = "TextBox4";
		TextBox4.ReadOnly = false;
		TextBox4.SelectionStart = 0;
		TextBox4.Size = new Size(42, 24);
		TextBox4.TabIndex = 13;
		TextBox4.TextAlign = HorizontalAlignment.Left;
		TextBox4.UseSystemPasswordChar = false;
		TextBox4.WatermarkText = "";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(15, 157);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 14;
		Button2.Text = "添加";
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 10f);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(201, 157);
		Button3.Name = "Button3";
		Button3.RoundRadius = 0;
		Button3.Size = new Size(75, 23);
		Button3.TabIndex = 15;
		Button3.Text = "取消";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(284, 196);
		base.Controls.Add(Button3);
		base.Controls.Add(Button2);
		base.Controls.Add(TextBox4);
		base.Controls.Add(Label8);
		base.Controls.Add(Label7);
		base.Controls.Add(TextBox3);
		base.Controls.Add(Label6);
		base.Controls.Add(Button1);
		base.Controls.Add(Label5);
		base.Controls.Add(Label4);
		base.Controls.Add(TextBox2);
		base.Controls.Add(Label3);
		base.Controls.Add(Label2);
		base.Controls.Add(ComboBox1);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddRangeSymbol";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = "Add Range Symbol";
		ResumeLayout(performLayout: false);
	}

	private void PublishTask(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void AwakeTask(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		Label5.ForeColor = Color.White;
		Label5.Text = Label5.ForeColor.ToString();
	}

	private void QueryTask(object sender, EventArgs e)
	{
		if (SearchFilter().ShowDialog() == DialogResult.OK)
		{
			Label5.Text = SearchFilter().Color.ToString();
			Label5.ForeColor = SearchFilter().Color;
		}
	}

	private void ResetTask(object sender, EventArgs e)
	{
		RangeSymbol item = null;
		switch (ComboBox1.SelectedIndex)
		{
		case 1:
			item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, TextBox1.Text, Conversions.ToDouble(TextBox2.Text), Conversions.ToSingle(TextBox3.Text), Conversions.ToSingle(TextBox4.Text), Label5.ForeColor);
			break;
		case 0:
			item = new RangeSymbol(RangeSymbol.SymbolType.Circle, TextBox1.Text, Conversions.ToDouble(TextBox2.Text), Label5.ForeColor);
			break;
		}
		Client.SelectedUnit.RangeSymbols.Add(item);
		Client.MustRefreshMainForm = true;
		Client.MustRefreshMainForm = true;
		Close();
	}

	private void MapTask(object sender, EventArgs e)
	{
		Close();
	}

	private void SortTask(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void CalcTask(object sender, EventArgs e)
	{
		TextBox3.Enabled = ComboBox1.SelectedIndex == 1;
		TextBox4.Enabled = TextBox3.Enabled;
	}
}
