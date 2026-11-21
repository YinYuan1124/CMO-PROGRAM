using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Hotkeys : DarkSecondaryFormBase
{
	private IContainer _PolicyTests;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel m_IdentifierTests;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_PrinterTests;

	[CompilerGenerated]
	[AccessedThroughProperty("Label6")]
	private DarkLabel m_ParserTests;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel m_AlgoTests;

	[CompilerGenerated]
	[AccessedThroughProperty("Label7")]
	private DarkLabel databaseTests;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_InterceptorTests;

	[AccessedThroughProperty("RichTextBox7")]
	[CompilerGenerated]
	private DarkRichTextBox m_MessageTests;

	[AccessedThroughProperty("RichTextBox3")]
	[CompilerGenerated]
	private DarkRichTextBox productTests;

	[AccessedThroughProperty("RichTextBox5")]
	[CompilerGenerated]
	private DarkRichTextBox m_AnnotationTests;

	[AccessedThroughProperty("RichTextBox4")]
	[CompilerGenerated]
	private DarkRichTextBox m_InitializerTests;

	[CompilerGenerated]
	[AccessedThroughProperty("RichTextBox2")]
	private DarkRichTextBox m_RoleTests;

	[CompilerGenerated]
	[AccessedThroughProperty("RichTextBox1")]
	private DarkRichTextBox factoryTests;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel m_AttributeTests;

	[AccessedThroughProperty("RichTextBox8")]
	[CompilerGenerated]
	private DarkRichTextBox m_EventTests;

	[CompilerGenerated]
	[AccessedThroughProperty("RichTextBoxL_AMP")]
	private DarkRichTextBox m_GlobalTests;

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IdentifierTests = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PrinterTests = value;
		}
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return m_ParserTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParserTests = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AlgoTests = value;
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return databaseTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			databaseTests = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorTests = value;
		}
	}

	internal DarkRichTextBox RichTextBox7
	{
		[CompilerGenerated]
		get
		{
			return m_MessageTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MessageTests = value;
		}
	}

	internal DarkRichTextBox RichTextBox3
	{
		[CompilerGenerated]
		get
		{
			return productTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productTests = value;
		}
	}

	internal DarkRichTextBox RichTextBox5
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationTests = value;
		}
	}

	[field: AccessedThroughProperty("RichTextBox6")]
	internal DarkRichTextBox RichTextBox6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkRichTextBox RichTextBox4
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InitializerTests = value;
		}
	}

	internal DarkRichTextBox RichTextBox2
	{
		[CompilerGenerated]
		get
		{
			return m_RoleTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RoleTests = value;
		}
	}

	internal DarkRichTextBox RichTextBox1
	{
		[CompilerGenerated]
		get
		{
			return factoryTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			factoryTests = value;
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeTests = value;
		}
	}

	internal DarkRichTextBox RichTextBox8
	{
		[CompilerGenerated]
		get
		{
			return m_EventTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventTests = value;
		}
	}

	internal DarkRichTextBox RichTextBoxL_AMP
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalTests = value;
		}
	}

	[field: AccessedThroughProperty("Label_AMP_Header")]
	internal DarkLabel Label_AMP_Header
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Hotkeys()
	{
		base.KeyDown += SetAnnotation;
		base.FormClosing += FillAnnotation;
		base.Load += CalculateAnnotation;
		FindAnnotation();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _PolicyTests != null)
			{
				_PolicyTests.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void FindAnnotation()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(Hotkeys));
		Label3 = new DarkLabel();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		Label6 = new DarkLabel();
		Label2 = new DarkLabel();
		Label7 = new DarkLabel();
		Label1 = new DarkLabel();
		RichTextBox7 = new DarkRichTextBox();
		RichTextBox3 = new DarkRichTextBox();
		RichTextBox5 = new DarkRichTextBox();
		RichTextBox6 = new DarkRichTextBox();
		RichTextBox4 = new DarkRichTextBox();
		RichTextBox2 = new DarkRichTextBox();
		RichTextBox1 = new DarkRichTextBox();
		Label8 = new DarkLabel();
		RichTextBox8 = new DarkRichTextBox();
		Label_AMP_Header = new DarkLabel();
		RichTextBoxL_AMP = new DarkRichTextBox();
		SuspendLayout();
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(15, 0);
		Label3.Name = "Label3";
		Label3.Size = new Size(56, 25);
		Label3.TabIndex = 9;
		Label3.Text = "基本";
		Label5.AutoSize = true;
		Label5.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(393, 661);
		Label5.Name = "Label5";
		Label5.Size = new Size(89, 25);
		Label5.TabIndex = 12;
		Label5.Text = "目标";
		Label4.AutoSize = true;
		Label4.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(393, 302);
		Label4.Name = "Label4";
		Label4.Size = new Size(104, 25);
		Label4.TabIndex = 11;
		Label4.Text = "子单元";
		Label6.AutoSize = true;
		Label6.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(15, 581);
		Label6.Name = "Label6";
		Label6.Size = new Size(148, 25);
		Label6.TabIndex = 10;
		Label6.Text = "想定编辑器";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(15, 112);
		Label2.Name = "Label2";
		Label2.Size = new Size(121, 25);
		Label2.TabIndex = 15;
		Label2.Text = "战术地图";
		Label7.AutoSize = true;
		Label7.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(832, 4);
		Label7.Name = "Label7";
		Label7.Size = new Size(220, 25);
		Label7.TabIndex = 14;
		Label7.Text = "专家诀窍和技巧";
		Label1.AutoSize = true;
		Label1.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(393, 2);
		Label1.Name = "Label1";
		Label1.Size = new Size(136, 25);
		Label1.TabIndex = 13;
		Label1.Text = "功能键";
		RichTextBox7.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox7.BorderStyle = BorderStyle.None;
		RichTextBox7.Font = new Font("Segoe UI", 10f);
		RichTextBox7.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox7.Location = new Point(835, 25);
		RichTextBox7.Name = "RichTextBox7";
		RichTextBox7.ReadOnly = true;
		RichTextBox7.Size = new Size(414, 246);
		RichTextBox7.TabIndex = 4;
		RichTextBox7.Text = componentResourceManager.GetString("RichTextBox7.Text");
		RichTextBox3.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox3.BorderStyle = BorderStyle.None;
		RichTextBox3.Font = new Font("Segoe UI", 10f);
		RichTextBox3.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox3.Location = new Point(18, 21);
		RichTextBox3.Name = "RichTextBox3";
		RichTextBox3.ReadOnly = true;
		RichTextBox3.Size = new Size(380, 106);
		RichTextBox3.TabIndex = 5;
		RichTextBox3.Text = "空格，Ctrl + Enter\t\t开始 / 继续 / 暂停\n+ (加)\t\t\t增加时间压缩\n- (减)\t\t减少时间压缩\nEnter\t\t\t实时模式 (1:1 )\nCtrl + S\t\t\t保存想定\n";
		RichTextBox5.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox5.BorderStyle = BorderStyle.None;
		RichTextBox5.Font = new Font("Segoe UI", 10f);
		RichTextBox5.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox5.Location = new Point(396, 682);
		RichTextBox5.Name = "RichTextBox5";
		RichTextBox5.ReadOnly = true;
		RichTextBox5.Size = new Size(367, 105);
		RichTextBox5.TabIndex = 2;
		RichTextBox5.Text = "P, PgDn , Num 3\t            丢弃目标\nH\t\t\t标记为敌方\nCtrl + H\t\t\t标记为非友方\nN\t\t\t标记为中立\nF\t\t\t标记为友方\nR\t\t\t重命名";
		RichTextBox6.AutoSize = true;
		RichTextBox6.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox6.BorderStyle = BorderStyle.None;
		RichTextBox6.Font = new Font("Segoe UI", 10f);
		RichTextBox6.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox6.Location = new Point(18, 600);
		RichTextBox6.Name = "RichTextBox6";
		RichTextBox6.ReadOnly = true;
		RichTextBox6.Size = new Size(380, 217);
		RichTextBox6.TabIndex = 3;
		RichTextBox6.Text = componentResourceManager.GetString("RichTextBox6.Text");
		RichTextBox4.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox4.BorderStyle = BorderStyle.None;
		RichTextBox4.Font = new Font("Segoe UI", 10f);
		RichTextBox4.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox4.Location = new Point(396, 323);
		RichTextBox4.Name = "RichTextBox4";
		RichTextBox4.ReadOnly = true;
		RichTextBox4.Size = new Size(561, 312);
		RichTextBox4.TabIndex = 8;
		RichTextBox4.Text = componentResourceManager.GetString("RichTextBox4.Text");
		RichTextBox2.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox2.BorderStyle = BorderStyle.None;
		RichTextBox2.Font = new Font("Segoe UI", 10f);
		RichTextBox2.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox2.Location = new Point(18, 133);
		RichTextBox2.Name = "RichTextBox2";
		RichTextBox2.ReadOnly = true;
		RichTextBox2.Size = new Size(380, 461);
		RichTextBox2.TabIndex = 7;
		RichTextBox2.Text = componentResourceManager.GetString("RichTextBox2.Text");
		RichTextBox1.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox1.BorderStyle = BorderStyle.None;
		RichTextBox1.Font = new Font("Segoe UI", 10f);
		RichTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox1.Location = new Point(396, 23);
		RichTextBox1.Name = "RichTextBox1";
		RichTextBox1.ReadOnly = true;
		RichTextBox1.Size = new Size(433, 277);
		RichTextBox1.TabIndex = 6;
		RichTextBox1.Text = componentResourceManager.GetString("RichTextBox1.Text");
		Label8.AutoSize = true;
		Label8.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(832, 148);
		Label8.Name = "Label8";
		Label8.Size = new Size(52, 25);
		Label8.TabIndex = 17;
		Label8.Text = "其它";
		RichTextBox8.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBox8.BorderStyle = BorderStyle.None;
		RichTextBox8.Font = new Font("Segoe UI", 10f);
		RichTextBox8.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBox8.Location = new Point(835, 169);
		RichTextBox8.Name = "RichTextBox8";
		RichTextBox8.Size = new Size(391, 187);
		RichTextBox8.TabIndex = 16;
		RichTextBox8.Text = "Ctrl + Shift + C\tLua 脚本控制台\nCtrl + C\t\t复制所选单元的Lua数值到剪切板\nCtrl + Z\t\t复制所选参考点的Lua数值到剪切板";
		Label_AMP_Header.AutoSize = true;
		Label_AMP_Header.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label_AMP_Header.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AMP_Header.Location = new Point(834, 239);
		Label_AMP_Header.Margin = new Padding(2, 0, 2, 0);
		Label_AMP_Header.Name = "Label_AMP_Header";
		Label_AMP_Header.Size = new Size(247, 25);
		Label_AMP_Header.TabIndex = 17;
		Label_AMP_Header.Text = "高级任务计划";
		RichTextBoxL_AMP.BackColor = Color.FromArgb(60, 63, 65);
		RichTextBoxL_AMP.BorderStyle = BorderStyle.None;
		RichTextBoxL_AMP.Font = new Font("Segoe UI", 10f);
		RichTextBoxL_AMP.ForeColor = Color.FromArgb(220, 220, 220);
		RichTextBoxL_AMP.Location = new Point(836, 254);
		RichTextBoxL_AMP.Margin = new Padding(2);
		RichTextBoxL_AMP.Name = "RichTextBoxL_AMP";
		RichTextBoxL_AMP.Size = new Size(390, 57);
		RichTextBoxL_AMP.TabIndex = 16;
		RichTextBoxL_AMP.Text = "Ctrl + Shift + F11\t空中任务指令 (ATO)";
		base.AutoScaleDimensions = new SizeF(8f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		base.ClientSize = new Size(1258, 817);
		base.Controls.Add(Label_AMP_Header);
		base.Controls.Add(Label8);
		base.Controls.Add(RichTextBoxL_AMP);
		base.Controls.Add(RichTextBox8);
		base.Controls.Add(Label3);
		base.Controls.Add(Label5);
		base.Controls.Add(Label4);
		base.Controls.Add(Label6);
		base.Controls.Add(Label2);
		base.Controls.Add(Label7);
		base.Controls.Add(Label1);
		base.Controls.Add(RichTextBox7);
		base.Controls.Add(RichTextBox3);
		base.Controls.Add(RichTextBox5);
		base.Controls.Add(RichTextBox6);
		base.Controls.Add(RichTextBox4);
		base.Controls.Add(RichTextBox2);
		base.Controls.Add(RichTextBox1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.Location = new Point(0, 0);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Hotkeys";
		base.Padding = new Padding(9);
		base.ShowIcon = false;
		Text = "热键";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void SetAnnotation(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void FillAnnotation(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CalculateAnnotation(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		RichTextBoxL_AMP.Visible = true;
		Label_AMP_Header.Visible = true;
	}
}
