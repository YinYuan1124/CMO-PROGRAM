using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorTargetsPreliminary : DarkSecondaryFormBase
{
	private IContainer _SetterTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_CreatorTask;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox m_TemplateTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_Strike_MinimumContactStanceToTrigger")]
	private DarkUIComboBox mappingTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Label7")]
	private DarkLabel mockTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel m_TagTask;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkButton queueTask;

	[AccessedThroughProperty("UnitFilter_UnitDestroyed")]
	[CompilerGenerated]
	private UnitFilter regTask;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorTask = value;
		}
	}

	internal DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TemplateTask = value;
		}
	}

	internal DarkUIComboBox Combo_Strike_MinimumContactStanceToTrigger
	{
		[CompilerGenerated]
		get
		{
			return mappingTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mappingTask = value;
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return mockTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mockTask = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_TagTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TagTask = value;
		}
	}

	[field: AccessedThroughProperty("TextBox1")]
	internal DarkUITextBox TextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkButton Button1
	{
		[CompilerGenerated]
		get
		{
			return queueTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			queueTask = value;
		}
	}

	internal UnitFilter UnitFilter_UnitDestroyed
	{
		[CompilerGenerated]
		get
		{
			return regTask;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regTask = value;
		}
	}

	public FlightPlanEditorTargetsPreliminary()
	{
		GetPrinter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _SetterTask != null)
			{
				_SetterTask.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void GetPrinter()
	{
		Label1 = new DarkLabel();
		ComboBox1 = new DarkUIComboBox();
		Combo_Strike_MinimumContactStanceToTrigger = new DarkUIComboBox();
		Label7 = new DarkLabel();
		Label2 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button1 = new DarkButton();
		UnitFilter_UnitDestroyed = new UnitFilter();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(28, 61);
		Label1.Name = "Label1";
		Label1.Size = new Size(220, 15);
		Label1.TabIndex = 0;
		Label1.Text = "获取任务相关目标在：";
		ComboBox1.BackColor = Color.Transparent;
		ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox1.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox1.FormattingEnabled = true;
		ComboBox1.Items.AddRange(new object[6] { "2海里", "5海里", "10海里", "50海里", "200海里", "距离无限制" });
		ComboBox1.Location = new Point(321, 55);
		ComboBox1.Name = "ComboBox1";
		ComboBox1.Size = new Size(183, 21);
		ComboBox1.TabIndex = 1;
		Combo_Strike_MinimumContactStanceToTrigger.BackColor = Color.Transparent;
		Combo_Strike_MinimumContactStanceToTrigger.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Strike_MinimumContactStanceToTrigger.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Strike_MinimumContactStanceToTrigger.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Strike_MinimumContactStanceToTrigger.FormattingEnabled = true;
		Combo_Strike_MinimumContactStanceToTrigger.Items.AddRange(new object[3] { "未知", "非友方", "敌方" });
		Combo_Strike_MinimumContactStanceToTrigger.Location = new Point(321, 90);
		Combo_Strike_MinimumContactStanceToTrigger.Name = "Combo_Strike_MinimumContactStanceToTrigger";
		Combo_Strike_MinimumContactStanceToTrigger.Size = new Size(183, 21);
		Combo_Strike_MinimumContactStanceToTrigger.TabIndex = 10;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(28, 96);
		Label7.Name = "Label7";
		Label7.Size = new Size(198, 15);
		Label7.TabIndex = 9;
		Label7.Text = "攻击目标最小条件：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(28, 26);
		Label2.Name = "Label2";
		Label2.Size = new Size(150, 15);
		Label2.TabIndex = 11;
		Label2.Text = "预备目标位置：";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(321, 20);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(183, 21);
		TextBox1.TabIndex = 12;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Button1.Location = new Point(527, 15);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.Size = new Size(140, 26);
		Button1.TabIndex = 13;
		Button1.Text = "从地图选择点";
		UnitFilter_UnitDestroyed.BackColor = Color.FromArgb(60, 63, 65);
		UnitFilter_UnitDestroyed.FilterObject = null;
		UnitFilter_UnitDestroyed.Location = new Point(9, 144);
		UnitFilter_UnitDestroyed.MinimumSize = new Size(311, 177);
		UnitFilter_UnitDestroyed.Name = "UnitFilter_UnitDestroyed";
		UnitFilter_UnitDestroyed.Size = new Size(413, 211);
		UnitFilter_UnitDestroyed.TabIndex = 14;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(685, 348);
		base.Controls.Add(UnitFilter_UnitDestroyed);
		base.Controls.Add(Button1);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label2);
		base.Controls.Add(Combo_Strike_MinimumContactStanceToTrigger);
		base.Controls.Add(Label7);
		base.Controls.Add(ComboBox1);
		base.Controls.Add(Label1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FlightPlanEditorTargetsPreliminary";
		base.ShowIcon = false;
		Text = "FlightPlanEditorTargetsPreliminary";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
