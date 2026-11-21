using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Filter;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TimesAndDuration : DarkSecondaryFormBase
{
	private IContainer structAttr;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_MerchantAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Hours")]
	private DarkUITextBox callbackAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private DarkLabel decoratorAttr;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel threadAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Mins")]
	private DarkUITextBox m_ObjectAttr;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton parameterAttr;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _ExpressionAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("DTP_StartTime")]
	private DarkMaskedTextBox m_DispatcherAttr;

	[AccessedThroughProperty("DTP_CurrentDate")]
	[CompilerGenerated]
	private DarkMaskedTextBox m_ListenerAttr;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private DarkLabel m_ConfigAttr;

	[AccessedThroughProperty("NUD_Complexity")]
	[CompilerGenerated]
	private GControl1 m_ValAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("Label8")]
	private DarkLabel wrapperAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("Label9")]
	private DarkLabel observerAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox issuerAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_Difficulty")]
	private GControl1 m_ClientAttr;

	[AccessedThroughProperty("CB_DaylightSavingTime")]
	[CompilerGenerated]
	private DarkCheckBox dicAttr;

	[AccessedThroughProperty("Label10")]
	[CompilerGenerated]
	private DarkLabel m_ConsumerAttr;

	[AccessedThroughProperty("Label11")]
	[CompilerGenerated]
	private DarkLabel facadeAttr;

	[AccessedThroughProperty("TB_DaylightSavingTime_Start")]
	[CompilerGenerated]
	private MaskedTextBox m_ProxyAttr;

	[AccessedThroughProperty("Button_CopyFromCurrent")]
	[CompilerGenerated]
	private DarkUIButton m_PropertyAttr;

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MerchantAttr = value;
		}
	}

	internal DarkUITextBox TB_Hours
	{
		[CompilerGenerated]
		get
		{
			return callbackAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackAttr = value;
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return decoratorAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			decoratorAttr = value;
		}
	}

	[field: AccessedThroughProperty("TB_Days")]
	internal DarkUITextBox TB_Days
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return threadAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			threadAttr = value;
		}
	}

	[field: AccessedThroughProperty("DTP_StartDate")]
	internal DarkMaskedTextBox DTP_StartDate
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TB_Mins
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObjectAttr = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return parameterAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptibleAttr;
			DarkUIButton darkUIButton = parameterAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			parameterAttr = value;
			darkUIButton = parameterAttr;
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
			return _ExpressionAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleAttr;
			DarkUIButton expressionAttr = _ExpressionAttr;
			if (expressionAttr != null)
			{
				expressionAttr.Click -= value2;
			}
			_ExpressionAttr = value;
			expressionAttr = _ExpressionAttr;
			if (expressionAttr != null)
			{
				expressionAttr.Click += value2;
			}
		}
	}

	internal DarkMaskedTextBox DTP_StartTime
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DispatcherAttr = value;
		}
	}

	internal DarkMaskedTextBox DTP_CurrentDate
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ListenerAttr = value;
		}
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConfigAttr = value;
		}
	}

	[field: AccessedThroughProperty("DTP_CurrentTime")]
	internal DarkMaskedTextBox DTP_CurrentTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GControl1 NUD_Complexity
	{
		[CompilerGenerated]
		get
		{
			return m_ValAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValAttr = value;
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return wrapperAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wrapperAttr = value;
		}
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return observerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			observerAttr = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return issuerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			issuerAttr = value;
		}
	}

	internal GControl1 NUD_Difficulty
	{
		[CompilerGenerated]
		get
		{
			return m_ClientAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClientAttr = value;
		}
	}

	internal DarkCheckBox CB_DaylightSavingTime
	{
		[CompilerGenerated]
		get
		{
			return dicAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleAttr;
			DarkCheckBox darkCheckBox = dicAttr;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			dicAttr = value;
			darkCheckBox = dicAttr;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkLabel Label10
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConsumerAttr = value;
		}
	}

	internal DarkLabel Label11
	{
		[CompilerGenerated]
		get
		{
			return facadeAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			facadeAttr = value;
		}
	}

	internal MaskedTextBox TB_DaylightSavingTime_Start
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProxyAttr = value;
		}
	}

	[field: AccessedThroughProperty("TB_DaylightSavingTime_End")]
	internal MaskedTextBox TB_DaylightSavingTime_End
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_CopyFromCurrent
	{
		[CompilerGenerated]
		get
		{
			return m_PropertyAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareInterruptibleAttr;
			DarkUIButton propertyAttr = m_PropertyAttr;
			if (propertyAttr != null)
			{
				propertyAttr.Click -= value2;
			}
			m_PropertyAttr = value;
			propertyAttr = m_PropertyAttr;
			if (propertyAttr != null)
			{
				propertyAttr.Click += value2;
			}
		}
	}

	public TimesAndDuration()
	{
		base.Load += InstantiateInterruptibleAttr;
		base.KeyDown += DisableInterruptibleAttr;
		base.FormClosing += InsertInterruptibleAttr;
		PopInterruptibleAttr();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && structAttr != null)
			{
				structAttr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PopInterruptibleAttr()
	{
		Label4 = new DarkLabel();
		TB_Hours = new DarkUITextBox();
		Label3 = new DarkLabel();
		TB_Days = new DarkUITextBox();
		Label2 = new DarkLabel();
		DTP_StartDate = new DarkMaskedTextBox();
		Label1 = new DarkLabel();
		Label5 = new DarkLabel();
		TB_Mins = new DarkUITextBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		DTP_StartTime = new DarkMaskedTextBox();
		DTP_CurrentDate = new DarkMaskedTextBox();
		Label6 = new DarkLabel();
		DTP_CurrentTime = new DarkMaskedTextBox();
		Label7 = new DarkLabel();
		NUD_Complexity = new GControl1();
		Label8 = new DarkLabel();
		Label9 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		NUD_Difficulty = new GControl1();
		CB_DaylightSavingTime = new DarkCheckBox();
		Label10 = new DarkLabel();
		Label11 = new DarkLabel();
		TB_DaylightSavingTime_Start = new MaskedTextBox();
		TB_DaylightSavingTime_End = new MaskedTextBox();
		Button_CopyFromCurrent = new DarkUIButton();
		SuspendLayout();
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(211, 240);
		Label4.Name = "Label4";
		Label4.Size = new Size(33, 15);
		Label4.TabIndex = 15;
		Label4.Text = "分钟";
		TB_Hours.AutoCompleteCustomSource = null;
		TB_Hours.AutoCompleteMode = AutoCompleteMode.None;
		TB_Hours.AutoCompleteSource = AutoCompleteSource.None;
		TB_Hours.BackColor = Color.Transparent;
		TB_Hours.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TB_Hours.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Hours.Image = null;
		TB_Hours.Lines = null;
		TB_Hours.Location = new Point(83, 237);
		TB_Hours.MaxLength = 32767;
		TB_Hours.Multiline = false;
		TB_Hours.Name = "TB_Hours";
		TB_Hours.ReadOnly = false;
		TB_Hours.SelectionStart = 0;
		TB_Hours.Size = new Size(39, 24);
		TB_Hours.TabIndex = 14;
		TB_Hours.Text = "0";
		TB_Hours.TextAlign = HorizontalAlignment.Left;
		TB_Hours.UseSystemPasswordChar = false;
		TB_Hours.WatermarkText = "";
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(127, 240);
		Label3.Name = "Label3";
		Label3.Size = new Size(37, 15);
		Label3.TabIndex = 13;
		Label3.Text = "小时";
		TB_Days.AutoCompleteCustomSource = null;
		TB_Days.AutoCompleteMode = AutoCompleteMode.None;
		TB_Days.AutoCompleteSource = AutoCompleteSource.None;
		TB_Days.BackColor = Color.Transparent;
		TB_Days.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TB_Days.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Days.Image = null;
		TB_Days.Lines = null;
		TB_Days.Location = new Point(12, 238);
		TB_Days.MaxLength = 32767;
		TB_Days.Multiline = false;
		TB_Days.Name = "TB_Days";
		TB_Days.ReadOnly = false;
		TB_Days.SelectionStart = 0;
		TB_Days.Size = new Size(35, 24);
		TB_Days.TabIndex = 12;
		TB_Days.Text = "0";
		TB_Days.TextAlign = HorizontalAlignment.Left;
		TB_Days.UseSystemPasswordChar = false;
		TB_Days.WatermarkText = "";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(48, 241);
		Label2.Name = "Label2";
		Label2.Size = new Size(31, 15);
		Label2.TabIndex = 11;
		Label2.Text = "天";
		DTP_StartDate.BackColor = Color.FromArgb(31, 31, 31);
		DTP_StartDate.BorderStyle = BorderStyle.FixedSingle;
		DTP_StartDate.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_StartDate.Location = new Point(12, 167);
		DTP_StartDate.Name = "DTP_StartDate";
		DTP_StartDate.Size = new Size(305, 23);
		DTP_StartDate.TabIndex = 10;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(12, 151);
		Label1.Name = "Label1";
		Label1.Size = new Size(103, 15);
		Label1.TabIndex = 16;
		Label1.Text = "想定开始于：";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(9, 222);
		Label5.Name = "Label5";
		Label5.Size = new Size(76, 15);
		Label5.TabIndex = 17;
		Label5.Text = "持续时间：";
		TB_Mins.AutoCompleteCustomSource = null;
		TB_Mins.AutoCompleteMode = AutoCompleteMode.None;
		TB_Mins.AutoCompleteSource = AutoCompleteSource.None;
		TB_Mins.BackColor = Color.Transparent;
		TB_Mins.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TB_Mins.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Mins.Image = null;
		TB_Mins.Lines = null;
		TB_Mins.Location = new Point(166, 237);
		TB_Mins.MaxLength = 32767;
		TB_Mins.Multiline = false;
		TB_Mins.Name = "TB_Mins";
		TB_Mins.ReadOnly = false;
		TB_Mins.SelectionStart = 0;
		TB_Mins.Size = new Size(39, 24);
		TB_Mins.TabIndex = 18;
		TB_Mins.Text = "0";
		TB_Mins.TextAlign = HorizontalAlignment.Left;
		TB_Mins.UseSystemPasswordChar = false;
		TB_Mins.WatermarkText = "";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(12, 345);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 19;
		Button1.Text = "确定";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(242, 345);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 20;
		Button2.Text = "取消";
		DTP_StartTime.BackColor = Color.FromArgb(31, 31, 31);
		DTP_StartTime.BorderStyle = BorderStyle.FixedSingle;
		DTP_StartTime.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_StartTime.Location = new Point(12, 193);
		DTP_StartTime.Name = "DTP_StartTime";
		DTP_StartTime.Size = new Size(305, 23);
		DTP_StartTime.TabIndex = 21;
		DTP_CurrentDate.BackColor = Color.FromArgb(31, 31, 31);
		DTP_CurrentDate.BorderStyle = BorderStyle.FixedSingle;
		DTP_CurrentDate.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_CurrentDate.Location = new Point(12, 22);
		DTP_CurrentDate.Name = "DTP_CurrentDate";
		DTP_CurrentDate.Size = new Size(305, 23);
		DTP_CurrentDate.TabIndex = 22;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(12, 6);
		Label6.Name = "Label6";
		Label6.Size = new Size(123, 15);
		Label6.TabIndex = 23;
		Label6.Text = "想定当前时间：";
		DTP_CurrentTime.BackColor = Color.FromArgb(31, 31, 31);
		DTP_CurrentTime.BorderStyle = BorderStyle.FixedSingle;
		DTP_CurrentTime.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_CurrentTime.Location = new Point(12, 48);
		DTP_CurrentTime.Name = "DTP_CurrentTime";
		DTP_CurrentTime.Size = new Size(305, 23);
		DTP_CurrentTime.TabIndex = 24;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(9, 290);
		Label7.Name = "Label7";
		Label7.Size = new Size(70, 15);
		Label7.TabIndex = 25;
		Label7.Text = "复杂度：";
		NUD_Complexity.BackColor = Color.Transparent;
		NUD_Complexity.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		NUD_Complexity.Location = new Point(75, 284);
		NUD_Complexity.Maximum = 5;
		NUD_Complexity.Minimum = 1;
		NUD_Complexity.Name = "NUD_Complexity";
		NUD_Complexity.Size = new Size(47, 26);
		NUD_Complexity.TabIndex = 26;
		NUD_Complexity.Value = 1;
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(9, 316);
		Label8.Name = "Label8";
		Label8.Size = new Size(58, 15);
		Label8.TabIndex = 27;
		Label8.Text = "困难度：";
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(143, 295);
		Label9.Name = "Label9";
		Label9.Size = new Size(98, 15);
		Label9.TabIndex = 29;
		Label9.Text = "位置/设置：";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(146, 311);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(171, 24);
		TextBox1.TabIndex = 30;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		NUD_Difficulty.BackColor = Color.Transparent;
		NUD_Difficulty.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		NUD_Difficulty.Location = new Point(75, 311);
		NUD_Difficulty.Maximum = 5;
		NUD_Difficulty.Minimum = 1;
		NUD_Difficulty.Name = "NUD_Difficulty";
		NUD_Difficulty.Size = new Size(47, 26);
		NUD_Difficulty.TabIndex = 31;
		NUD_Difficulty.Value = 1;
		CB_DaylightSavingTime.Location = new Point(12, 75);
		CB_DaylightSavingTime.Name = "CB_DaylightSavingTime";
		CB_DaylightSavingTime.Size = new Size(300, 17);
		CB_DaylightSavingTime.TabIndex = 32;
		CB_DaylightSavingTime.Text = "使用夏令时（DST或夏令时）";
		Label10.AutoSize = true;
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(11, 97);
		Label10.Name = "Label10";
		Label10.Size = new Size(128, 15);
		Label10.TabIndex = 34;
		Label10.Text = "夏令时开始（Day.Month）：";
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(11, 120);
		Label11.Name = "Label11";
		Label11.Size = new Size(124, 15);
		Label11.TabIndex = 35;
		Label11.Text = "夏令时结束（Day.Month）：";
		TB_DaylightSavingTime_Start.BackColor = Color.Black;
		TB_DaylightSavingTime_Start.BorderStyle = BorderStyle.FixedSingle;
		TB_DaylightSavingTime_Start.ForeColor = Color.FromArgb(189, 189, 189);
		TB_DaylightSavingTime_Start.Location = new Point(138, 94);
		TB_DaylightSavingTime_Start.Mask = "00.00";
		TB_DaylightSavingTime_Start.Name = "TB_DaylightSavingTime_Start";
		TB_DaylightSavingTime_Start.Size = new Size(47, 23);
		TB_DaylightSavingTime_Start.TabIndex = 36;
		TB_DaylightSavingTime_End.BackColor = Color.Black;
		TB_DaylightSavingTime_End.BorderStyle = BorderStyle.FixedSingle;
		TB_DaylightSavingTime_End.ForeColor = Color.FromArgb(189, 189, 189);
		TB_DaylightSavingTime_End.Location = new Point(138, 117);
		TB_DaylightSavingTime_End.Mask = "00.00";
		TB_DaylightSavingTime_End.Name = "TB_DaylightSavingTime_End";
		TB_DaylightSavingTime_End.Size = new Size(47, 23);
		TB_DaylightSavingTime_End.TabIndex = 36;
		Button_CopyFromCurrent.BackColor = Color.Transparent;
		Button_CopyFromCurrent.DialogResult = DialogResult.None;
		Button_CopyFromCurrent.Font = new Font("Segoe UI", 6.75f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_CopyFromCurrent.ForeColor = SystemColors.Control;
		Button_CopyFromCurrent.Location = new Point(166, 143);
		Button_CopyFromCurrent.Name = "Button_CopyFromCurrent";
		Button_CopyFromCurrent.RoundRadius = 0;
		Button_CopyFromCurrent.Size = new Size(151, 21);
		Button_CopyFromCurrent.TabIndex = 37;
		Button_CopyFromCurrent.Text = "从当前日期+时间复制";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(329, 378);
		base.Controls.Add(Button_CopyFromCurrent);
		base.Controls.Add(TB_DaylightSavingTime_End);
		base.Controls.Add(TB_DaylightSavingTime_Start);
		base.Controls.Add(Label11);
		base.Controls.Add(Label10);
		base.Controls.Add(CB_DaylightSavingTime);
		base.Controls.Add(NUD_Difficulty);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label9);
		base.Controls.Add(Label8);
		base.Controls.Add(NUD_Complexity);
		base.Controls.Add(Label7);
		base.Controls.Add(DTP_CurrentTime);
		base.Controls.Add(Label6);
		base.Controls.Add(DTP_CurrentDate);
		base.Controls.Add(DTP_StartTime);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(TB_Mins);
		base.Controls.Add(Label5);
		base.Controls.Add(Label1);
		base.Controls.Add(Label4);
		base.Controls.Add(TB_Hours);
		base.Controls.Add(Label3);
		base.Controls.Add(TB_Days);
		base.Controls.Add(Label2);
		base.Controls.Add(DTP_StartDate);
		base.FlatBorder = true;
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "TimesAndDuration";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "时间 - 间隔 - 通用信息";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void InstantiateInterruptibleAttr(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		DTP_CurrentDate.Mask = "0000-00-00";
		DTP_CurrentTime.Mask = "00:00:00";
		DateTime dateTime_ = Client.CurrentScenario.Time;
		string string_ = null;
		GameGeneral.PaddedTimeString(ref dateTime_, ref string_);
		string string_2 = null;
		GameGeneral.PaddedDateString(ref dateTime_, ref string_2, bool_1: false);
		DTP_CurrentDate.Text = string_2;
		DTP_CurrentTime.Text = string_;
		if (!Information.IsNothing(Client.CurrentScenario.DST_Start) && Operators.CompareString(Client.CurrentScenario.DST_Start, "", TextCompare: true) != 0)
		{
			TB_DaylightSavingTime_Start.Text = Client.CurrentScenario.DST_Start;
		}
		else
		{
			TB_DaylightSavingTime_Start.Text = "00.00";
		}
		if (!Information.IsNothing(Client.CurrentScenario.DST_End) && Operators.CompareString(Client.CurrentScenario.DST_End, "", TextCompare: true) != 0)
		{
			TB_DaylightSavingTime_End.Text = Client.CurrentScenario.DST_End;
		}
		else
		{
			TB_DaylightSavingTime_End.Text = "00.00";
		}
		CB_DaylightSavingTime.Checked = Client.CurrentScenario.Use_DST;
		TB_DaylightSavingTime_Start.Enabled = CB_DaylightSavingTime.Checked;
		TB_DaylightSavingTime_End.Enabled = CB_DaylightSavingTime.Checked;
		DTP_StartDate.Mask = "0000-00-00";
		DTP_StartTime.Mask = "00:00:00";
		DateTime dateTime_2 = Client.CurrentScenario.StartTime;
		string string_3 = null;
		GameGeneral.PaddedTimeString(ref dateTime_2, ref string_3);
		string string_4 = null;
		GameGeneral.PaddedDateString(ref dateTime_2, ref string_4, bool_1: false);
		DTP_StartDate.Text = string_4;
		DTP_StartTime.Text = string_3;
		TB_Days.Text = Conversions.ToString(Client.CurrentScenario.Duration.Days);
		TB_Hours.Text = Conversions.ToString(Client.CurrentScenario.Duration.Hours);
		TB_Mins.Text = Conversions.ToString(Client.CurrentScenario.Duration.Minutes);
		NUD_Complexity.Value = Convert.ToInt32(new decimal((Client.CurrentScenario.Meta_Complexity == 0) ? 1 : Client.CurrentScenario.Meta_Complexity));
		NUD_Difficulty.Value = Convert.ToInt32(new decimal((Client.CurrentScenario.Meta_Difficulty == 0) ? 1 : Client.CurrentScenario.Meta_Difficulty));
		TextBox1.Text = Client.CurrentScenario.Meta_ScenSetting;
	}

	private void CreateInterruptibleAttr(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(TB_Days.Text) & Versioned.IsNumeric(TB_Hours.Text) & Versioned.IsNumeric(TB_Mins.Text))
		{
			DateTime dateTime_ = default(DateTime);
			try
			{
				Client.CurrentScenario.Use_DST = CB_DaylightSavingTime.Checked;
				if (Client.CurrentScenario.Use_DST && (!ReadInterruptibleAttr(TB_DaylightSavingTime_Start.Text.Replace(",", ".")) || !ReadInterruptibleAttr(TB_DaylightSavingTime_End.Text.Replace(",", "."))))
				{
					DarkMessageBox.ShowError("请输入有效的夏令时开始和结束日期！", "输入了非法值！");
					return;
				}
				int num = RuleTokenizer.ChangeServer(DTP_CurrentDate.Text, DTP_CurrentTime.Text, ref dateTime_);
				if (num != 0)
				{
					DarkMessageBox.ShowError("Unable to set current scenario date & time: invalid value entered.", "设置想定时间出错");
					if (num == 1)
					{
						DTP_CurrentDate.Select();
					}
					else
					{
						DTP_CurrentTime.Select();
					}
					return;
				}
				Client.CurrentScenario.SetTime(bool_0: true, dateTime_);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DarkMessageBox.ShowError("无法设置当前想定时间日期：" + ex2.Message, "设置想定时间出错");
				ProjectData.ClearProjectError();
				return;
			}
			try
			{
				Client.CurrentScenario.DST_Start = TB_DaylightSavingTime_Start.Text.Replace(",", ".");
				Client.CurrentScenario.DST_End = TB_DaylightSavingTime_End.Text.Replace(",", ".");
				int num2 = RuleTokenizer.ChangeServer(DTP_StartDate.Text, DTP_StartTime.Text, ref dateTime_);
				if (num2 != 0)
				{
					DarkMessageBox.ShowError("Unable to set scenario start date & time: invalid value entered.", "设置想定开始时间出错");
					if (num2 == 1)
					{
						DTP_StartDate.Select();
					}
					else
					{
						DTP_StartTime.Select();
					}
					return;
				}
				Client.CurrentScenario.StartTime = dateTime_;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DarkMessageBox.ShowError("无法设置想定开始时间日期：" + ex4.Message, "设置想定开始时间出错");
				ProjectData.ClearProjectError();
				return;
			}
			try
			{
				Client.CurrentScenario.Duration = new TimeSpan(Conversions.ToInteger(TB_Days.Text) * 24, Conversions.ToInteger(TB_Hours.Text) * 60, Conversions.ToInteger(TB_Mins.Text) * 60);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				DarkMessageBox.ShowError("无法设置想定持续时间：" + ex6.Message, "设置想定持续时间出错");
				ProjectData.ClearProjectError();
				return;
			}
			Client.CurrentScenario.Meta_Complexity = (short)NUD_Complexity.Value;
			Client.CurrentScenario.Meta_Difficulty = (short)NUD_Difficulty.Value;
			Client.CurrentScenario.Meta_ScenSetting = TextBox1.Text;
			Client.CurrentScenario.Cache_TimeOfDay = new Weather.TTimeOfDayType?[360][];
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RefreshCaption();
			Close();
		}
		else
		{
			DarkMessageBox.ShowError("请检查持续时间数字。", "输入非数字值！");
		}
	}

	private void CompareInterruptibleAttr(object sender, EventArgs e)
	{
		Close();
	}

	private bool ReadInterruptibleAttr(string string_0)
	{
		List<string> list = string_0.Split(Conversions.ToCharArrayRankOne(".")).ToList();
		if (Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]))
		{
			if ((Conversions.ToInteger(list[0]) <= 0) | (Conversions.ToInteger(list[0]) > 31))
			{
				return false;
			}
			if ((Conversions.ToInteger(list[1]) <= 0) | (Conversions.ToInteger(list[1]) > 12))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private void DisableInterruptibleAttr(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void UpdateInterruptibleAttr(object sender, EventArgs e)
	{
		TB_DaylightSavingTime_Start.Enabled = CB_DaylightSavingTime.Checked;
		TB_DaylightSavingTime_End.Enabled = CB_DaylightSavingTime.Checked;
	}

	private void InsertInterruptibleAttr(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void PrepareInterruptibleAttr(object sender, EventArgs e)
	{
		DTP_StartDate.Text = DTP_CurrentDate.Text;
		DTP_StartTime.Text = DTP_CurrentTime.Text;
	}
}
