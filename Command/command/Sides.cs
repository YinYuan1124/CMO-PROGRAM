using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Sides : DarkSecondaryFormBase, GInterface9
{
	private IContainer pageSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("LB_Sides")]
	private DarkListView rulesSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton methodSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton m_ServiceSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton m_SystemSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AIOnly")]
	private DarkCheckBox _CandidateSingleton;

	[CompilerGenerated]
	[AccessedThroughProperty("Button4")]
	private DarkUIButton m_BaseSingleton;

	[AccessedThroughProperty("Button5")]
	[CompilerGenerated]
	private DarkUIButton m_PolicySingleton;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel broadcasterSingleton;

	[AccessedThroughProperty("CB_Awareness")]
	[CompilerGenerated]
	private DarkUIComboBox identifierSingleton;

	[AccessedThroughProperty("CB_CollRespons")]
	[CompilerGenerated]
	private DarkCheckBox _PrinterSingleton;

	[AccessedThroughProperty("Label_Proficiency")]
	[CompilerGenerated]
	private DarkLabel parserSingleton;

	[AccessedThroughProperty("TrackBar_Proficiency")]
	[CompilerGenerated]
	private TrackBar m_AlgoSingleton;

	[AccessedThroughProperty("CB_AutoTrackCivs")]
	[CompilerGenerated]
	private DarkCheckBox m_DatabaseSingleton;

	[AccessedThroughProperty("Button_SideBriefing")]
	[CompilerGenerated]
	private DarkUIButton _ProductSingleton;

	[AccessedThroughProperty("Panel_SideColor")]
	[CompilerGenerated]
	private Panel m_AnnotationSingleton;

	[AccessedThroughProperty("check_FixedSideColor")]
	[CompilerGenerated]
	private CheckBox m_IteratorSingleton;

	[AccessedThroughProperty("Button_ChangeColor")]
	[CompilerGenerated]
	private DarkUIButton m_InitializerSingleton;

	[AccessedThroughProperty("btnNature")]
	[CompilerGenerated]
	private DarkUIButton m_RoleSingleton;

	private Side factorySingleton;

	private bool _AttributeSingleton;

	private int[] _EventSingleton;

	internal DarkListView LB_Sides
	{
		[CompilerGenerated]
		get
		{
			return rulesSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = SearchInterruptibleAdapter;
			EventHandler value3 = EnableInterruptibleAdapter;
			DarkListView darkListView = rulesSingleton;
			if (darkListView != null)
			{
				darkListView.MouseDoubleClick -= value2;
				darkListView.SelectedIndicesChanged -= value3;
			}
			rulesSingleton = value;
			darkListView = rulesSingleton;
			if (darkListView != null)
			{
				darkListView.MouseDoubleClick += value2;
				darkListView.SelectedIndicesChanged += value3;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return methodSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeInterruptibleAdapter;
			DarkUIButton darkUIButton = methodSingleton;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			methodSingleton = value;
			darkUIButton = methodSingleton;
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
			return m_ServiceSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleAdapter;
			DarkUIButton serviceSingleton = m_ServiceSingleton;
			if (serviceSingleton != null)
			{
				serviceSingleton.Click -= value2;
			}
			m_ServiceSingleton = value;
			serviceSingleton = m_ServiceSingleton;
			if (serviceSingleton != null)
			{
				serviceSingleton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return m_SystemSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitInterruptibleAdapter;
			DarkUIButton systemSingleton = m_SystemSingleton;
			if (systemSingleton != null)
			{
				systemSingleton.Click -= value2;
			}
			m_SystemSingleton = value;
			systemSingleton = m_SystemSingleton;
			if (systemSingleton != null)
			{
				systemSingleton.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_AIOnly
	{
		[CompilerGenerated]
		get
		{
			return _CandidateSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleAdapter;
			DarkCheckBox candidateSingleton = _CandidateSingleton;
			if (candidateSingleton != null)
			{
				candidateSingleton.CheckedChanged -= value2;
			}
			_CandidateSingleton = value;
			candidateSingleton = _CandidateSingleton;
			if (candidateSingleton != null)
			{
				candidateSingleton.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return m_BaseSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleAdapter;
			DarkUIButton baseSingleton = m_BaseSingleton;
			if (baseSingleton != null)
			{
				baseSingleton.Click -= value2;
			}
			m_BaseSingleton = value;
			baseSingleton = m_BaseSingleton;
			if (baseSingleton != null)
			{
				baseSingleton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button5
	{
		[CompilerGenerated]
		get
		{
			return m_PolicySingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptInterruptibleAdapter;
			DarkUIButton policySingleton = m_PolicySingleton;
			if (policySingleton != null)
			{
				policySingleton.Click -= value2;
			}
			m_PolicySingleton = value;
			policySingleton = m_PolicySingleton;
			if (policySingleton != null)
			{
				policySingleton.Click += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return broadcasterSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			broadcasterSingleton = value;
		}
	}

	internal DarkUIComboBox CB_Awareness
	{
		[CompilerGenerated]
		get
		{
			return identifierSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleAdapter;
			EventHandler value3 = CalculateInterruptibleAdapter;
			EventHandler value4 = PopInterruptibleAdapter;
			DarkUIComboBox darkUIComboBox = identifierSingleton;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
				darkUIComboBox.Enter -= value3;
				darkUIComboBox.Leave -= value4;
			}
			identifierSingleton = value;
			darkUIComboBox = identifierSingleton;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
				darkUIComboBox.Enter += value3;
				darkUIComboBox.Leave += value4;
			}
		}
	}

	internal DarkCheckBox CB_CollRespons
	{
		[CompilerGenerated]
		get
		{
			return _PrinterSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleAdapter;
			DarkCheckBox printerSingleton = _PrinterSingleton;
			if (printerSingleton != null)
			{
				printerSingleton.CheckedChanged -= value2;
			}
			_PrinterSingleton = value;
			printerSingleton = _PrinterSingleton;
			if (printerSingleton != null)
			{
				printerSingleton.CheckedChanged += value2;
			}
		}
	}

	internal DarkLabel Label_Proficiency
	{
		[CompilerGenerated]
		get
		{
			return parserSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			parserSingleton = value;
		}
	}

	internal TrackBar TrackBar_Proficiency
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptibleAdapter;
			TrackBar algoSingleton = m_AlgoSingleton;
			if (algoSingleton != null)
			{
				algoSingleton.Scroll -= value2;
			}
			m_AlgoSingleton = value;
			algoSingleton = m_AlgoSingleton;
			if (algoSingleton != null)
			{
				algoSingleton.Scroll += value2;
			}
		}
	}

	internal DarkCheckBox CB_AutoTrackCivs
	{
		[CompilerGenerated]
		get
		{
			return m_DatabaseSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateInterruptibleAdapter;
			DarkCheckBox databaseSingleton = m_DatabaseSingleton;
			if (databaseSingleton != null)
			{
				databaseSingleton.CheckedChanged -= value2;
			}
			m_DatabaseSingleton = value;
			databaseSingleton = m_DatabaseSingleton;
			if (databaseSingleton != null)
			{
				databaseSingleton.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkToolStrip1")]
	internal DarkToolStrip DarkToolStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal ToolStripLabel ToolStripLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_SideBriefing
	{
		[CompilerGenerated]
		get
		{
			return _ProductSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptibleAdapter;
			DarkUIButton productSingleton = _ProductSingleton;
			if (productSingleton != null)
			{
				productSingleton.Click -= value2;
			}
			_ProductSingleton = value;
			productSingleton = _ProductSingleton;
			if (productSingleton != null)
			{
				productSingleton.Click += value2;
			}
		}
	}

	internal Panel Panel_SideColor
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationSingleton = value;
		}
	}

	internal CheckBox check_FixedSideColor
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleAdapter;
			CheckBox iteratorSingleton = m_IteratorSingleton;
			if (iteratorSingleton != null)
			{
				iteratorSingleton.Click -= value2;
			}
			m_IteratorSingleton = value;
			iteratorSingleton = m_IteratorSingleton;
			if (iteratorSingleton != null)
			{
				iteratorSingleton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ChangeColor
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadInterruptibleAdapter;
			DarkUIButton initializerSingleton = m_InitializerSingleton;
			if (initializerSingleton != null)
			{
				initializerSingleton.Click -= value2;
			}
			m_InitializerSingleton = value;
			initializerSingleton = m_InitializerSingleton;
			if (initializerSingleton != null)
			{
				initializerSingleton.Click += value2;
			}
		}
	}

	internal DarkUIButton btnNature
	{
		[CompilerGenerated]
		get
		{
			return m_RoleSingleton;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableInterruptibleAdapter;
			DarkUIButton roleSingleton = m_RoleSingleton;
			if (roleSingleton != null)
			{
				roleSingleton.Click -= value2;
			}
			m_RoleSingleton = value;
			roleSingleton = m_RoleSingleton;
			if (roleSingleton != null)
			{
				roleSingleton.Click += value2;
			}
		}
	}

	public Sides()
	{
		base.FormClosing += SetupInterruptibleAdapter;
		base.Load += ExcludeInterruptibleAdapter;
		base.KeyDown += FillInterruptibleAdapter;
		InvokeInterruptibleAdapter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && pageSingleton != null)
		{
			pageSingleton.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void InvokeInterruptibleAdapter()
	{
		LB_Sides = new DarkListView();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		Button3 = new DarkUIButton();
		CB_AIOnly = new DarkCheckBox();
		Button4 = new DarkUIButton();
		Button5 = new DarkUIButton();
		Label1 = new DarkLabel();
		CB_Awareness = new DarkUIComboBox();
		CB_CollRespons = new DarkCheckBox();
		Label_Proficiency = new DarkLabel();
		TrackBar_Proficiency = new TrackBar();
		CB_AutoTrackCivs = new DarkCheckBox();
		DarkToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		Button_SideBriefing = new DarkUIButton();
		Panel_SideColor = new Panel();
		check_FixedSideColor = new CheckBox();
		Button_ChangeColor = new DarkUIButton();
		btnNature = new DarkUIButton();
		((ISupportInitialize)TrackBar_Proficiency).BeginInit();
		DarkToolStrip1.SuspendLayout();
		SuspendLayout();
		LB_Sides.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		LB_Sides.Location = new Point(1, 9);
		LB_Sides.Name = "LB_Sides";
		LB_Sides.RelatedInfos = null;
		LB_Sides.Size = new Size(213, 435);
		LB_Sides.TabIndex = 0;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(220, 9);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(134, 23);
		Button1.TabIndex = 1;
		Button1.Text = "添加";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(220, 38);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(133, 23);
		Button2.TabIndex = 2;
		Button2.Text = "删除";
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 10f);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(221, 162);
		Button3.Name = "Button3";
		Button3.RoundRadius = 0;
		Button3.Size = new Size(133, 23);
		Button3.TabIndex = 3;
		Button3.Text = "对抗关系";
		CB_AIOnly.AutoSize = true;
		CB_AIOnly.Enabled = false;
		CB_AIOnly.Location = new Point(221, 220);
		CB_AIOnly.Name = "CB_AIOnly";
		CB_AIOnly.Size = new Size(142, 19);
		CB_AIOnly.TabIndex = 4;
		CB_AIOnly.Text = "分方是AI控制的";
		Button4.BackColor = Color.Transparent;
		Button4.DialogResult = DialogResult.None;
		Button4.Font = new Font("Segoe UI", 10f);
		Button4.ForeColor = SystemColors.Control;
		Button4.Location = new Point(221, 104);
		Button4.Name = "Button4";
		Button4.RoundRadius = 0;
		Button4.Size = new Size(132, 23);
		Button4.TabIndex = 5;
		Button4.Text = "改名";
		Button5.BackColor = Color.Transparent;
		Button5.DialogResult = DialogResult.None;
		Button5.Font = new Font("Segoe UI", 10f);
		Button5.ForeColor = SystemColors.Control;
		Button5.Location = new Point(221, 191);
		Button5.Name = "Button5";
		Button5.RoundRadius = 0;
		Button5.Size = new Size(133, 23);
		Button5.TabIndex = 6;
		Button5.Text = "条令 -  ROE";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(217, 283);
		Label1.Name = "Label1";
		Label1.Size = new Size(96, 15);
		Label1.TabIndex = 8;
		Label1.Text = "视野水平：";
		CB_Awareness.BackColor = Color.Transparent;
		CB_Awareness.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Awareness.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Awareness.Font = new Font("Segoe UI", 7f);
		CB_Awareness.FormattingEnabled = true;
		CB_Awareness.Items.AddRange(new object[5] { "无视野", "正常", "自动感知分方", "自动感知分方及单元", "无所不知" });
		CB_Awareness.Location = new Point(220, 299);
		CB_Awareness.Name = "CB_Awareness";
		CB_Awareness.Size = new Size(133, 21);
		CB_Awareness.TabIndex = 9;
		CB_CollRespons.Location = new Point(221, 240);
		CB_CollRespons.Name = "CB_CollRespons";
		CB_CollRespons.Size = new Size(150, 17);
		CB_CollRespons.TabIndex = 10;
		CB_CollRespons.Text = "集体责任";
		Label_Proficiency.AutoSize = true;
		Label_Proficiency.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Proficiency.Location = new Point(219, 330);
		Label_Proficiency.Name = "Label_Proficiency";
		Label_Proficiency.Size = new Size(69, 15);
		Label_Proficiency.TabIndex = 11;
		Label_Proficiency.Text = "能力：";
		TrackBar_Proficiency.Location = new Point(220, 346);
		TrackBar_Proficiency.Maximum = 4;
		TrackBar_Proficiency.Name = "TrackBar_Proficiency";
		TrackBar_Proficiency.Size = new Size(133, 45);
		TrackBar_Proficiency.TabIndex = 12;
		CB_AutoTrackCivs.Location = new Point(221, 259);
		CB_AutoTrackCivs.Name = "CB_AutoTrackCivs";
		CB_AutoTrackCivs.Size = new Size(150, 17);
		CB_AutoTrackCivs.TabIndex = 13;
		CB_AutoTrackCivs.Text = "可自动探测民用目标";
		DarkToolStrip1.AutoSize = false;
		DarkToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		DarkToolStrip1.Dock = DockStyle.Bottom;
		DarkToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		DarkToolStrip1.Items.AddRange(new ToolStripItem[1] { ToolStripLabel1 });
		DarkToolStrip1.Location = new Point(0, 438);
		DarkToolStrip1.Name = "DarkToolStrip1";
		DarkToolStrip1.Padding = new Padding(5, 0, 1, 0);
		DarkToolStrip1.Size = new Size(368, 28);
		DarkToolStrip1.TabIndex = 14;
		DarkToolStrip1.Text = "DarkToolStrip1";
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(314, 25);
		ToolStripLabel1.Text = "双击一个分方以选择它并关闭此窗口";
		Button_SideBriefing.BackColor = Color.Transparent;
		Button_SideBriefing.DialogResult = DialogResult.None;
		Button_SideBriefing.Font = new Font("Segoe UI", 10f);
		Button_SideBriefing.ForeColor = SystemColors.Control;
		Button_SideBriefing.Location = new Point(220, 133);
		Button_SideBriefing.Name = "Button_SideBriefing";
		Button_SideBriefing.RoundRadius = 0;
		Button_SideBriefing.Size = new Size(132, 23);
		Button_SideBriefing.TabIndex = 15;
		Button_SideBriefing.Text = "简报";
		Panel_SideColor.BackColor = SystemColors.Control;
		Panel_SideColor.BorderStyle = BorderStyle.FixedSingle;
		Panel_SideColor.Location = new Point(306, 381);
		Panel_SideColor.Name = "Panel_SideColor";
		Panel_SideColor.Size = new Size(54, 19);
		Panel_SideColor.TabIndex = 17;
		check_FixedSideColor.AutoSize = true;
		check_FixedSideColor.ForeColor = SystemColors.ButtonHighlight;
		check_FixedSideColor.Location = new Point(217, 381);
		check_FixedSideColor.Name = "check_FixedSideColor";
		check_FixedSideColor.Size = new Size(89, 19);
		check_FixedSideColor.TabIndex = 15;
		check_FixedSideColor.Text = "固定颜色：";
		Button_ChangeColor.BackColor = Color.Transparent;
		Button_ChangeColor.DialogResult = DialogResult.None;
		Button_ChangeColor.Font = new Font("Segoe UI", 10f);
		Button_ChangeColor.ForeColor = SystemColors.Control;
		Button_ChangeColor.Location = new Point(222, 406);
		Button_ChangeColor.Name = "Button_ChangeColor";
		Button_ChangeColor.RoundRadius = 0;
		Button_ChangeColor.Size = new Size(133, 23);
		Button_ChangeColor.TabIndex = 18;
		Button_ChangeColor.Text = "改变颜色";
		btnNature.BackColor = Color.Transparent;
		btnNature.DialogResult = DialogResult.None;
		btnNature.Font = new Font("Segoe UI", 8f);
		btnNature.ForeColor = SystemColors.Control;
		btnNature.Location = new Point(221, 75);
		btnNature.Name = "btnNature";
		btnNature.RoundRadius = 0;
		btnNature.Size = new Size(132, 23);
		btnNature.TabIndex = 19;
		btnNature.Text = "添加自然分方（对于CEZ）";
		base.AutoScaleMode = AutoScaleMode.None;
		AutoSize = true;
		base.ClientSize = new Size(368, 466);
		base.Controls.Add(btnNature);
		base.Controls.Add(Button_ChangeColor);
		base.Controls.Add(check_FixedSideColor);
		base.Controls.Add(Panel_SideColor);
		base.Controls.Add(Button_SideBriefing);
		base.Controls.Add(CB_AutoTrackCivs);
		base.Controls.Add(TrackBar_Proficiency);
		base.Controls.Add(Label_Proficiency);
		base.Controls.Add(CB_CollRespons);
		base.Controls.Add(CB_Awareness);
		base.Controls.Add(Label1);
		base.Controls.Add(Button5);
		base.Controls.Add(Button4);
		base.Controls.Add(CB_AIOnly);
		base.Controls.Add(Button3);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(LB_Sides);
		base.Controls.Add(DarkToolStrip1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Sides";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑分方";
		((ISupportInitialize)TrackBar_Proficiency).EndInit();
		DarkToolStrip1.ResumeLayout(performLayout: false);
		DarkToolStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			factorySingleton = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void SetupInterruptibleAdapter(object sender, FormClosingEventArgs e)
	{
		factorySingleton = null;
		if (!ItemExporter.ConnectInterruptibleTemplate.AddUnit.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ExcludeInterruptibleAdapter(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		RefreshForm();
	}

	private void IncludeInterruptibleAdapter(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.AddSide.Show();
	}

	public void RefreshSideColorControls()
	{
		Panel_SideColor.Visible = false;
		Button_ChangeColor.Visible = false;
		check_FixedSideColor.Visible = false;
	}

	public void RefreshForm()
	{
		LB_Sides.Items.Clear();
		foreach (Side item in Client.CurrentScenario.Sides_ReadOnly.OrderBy((Side theS) => theS.Name))
		{
			LB_Sides.Items.Add(new DarkListItem(item.Name));
		}
		Button2.Enabled = (LB_Sides.Items.Count > 0) & (LB_Sides.SelectedIndices.Count > 0);
		Button3.Enabled = (LB_Sides.Items.Count > 0) & (LB_Sides.SelectedIndices.Count > 0);
		Label_Proficiency.Visible = (LB_Sides.Items.Count > 0) & (LB_Sides.SelectedIndices.Count > 0);
		TrackBar_Proficiency.Visible = (LB_Sides.Items.Count > 0) & (LB_Sides.SelectedIndices.Count > 0);
		RefreshSideColorControls();
		if (ItemExporter.ConnectInterruptibleTemplate.AddUnit.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.AddUnit.RefreshSides();
		}
	}

	private void SearchInterruptibleAdapter(object sender, MouseEventArgs e)
	{
		if (LB_Sides.SelectedIndices.Count == 0)
		{
			return;
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (Operators.CompareString(side.Name, LB_Sides.SelectedItems[0].Text, TextCompare: true) == 0)
			{
				Client.CurrentSide = side;
				break;
			}
		}
		Close();
	}

	private void EnableInterruptibleAdapter(object sender, EventArgs e)
	{
		if (LB_Sides.SelectedIndices.Count == 0)
		{
			return;
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (Operators.CompareString(side.Name, LB_Sides.SelectedItems[0].Text, TextCompare: true) == 0)
			{
				factorySingleton = side;
				break;
			}
		}
		Button2.Enabled = LB_Sides.Items.Count > 0;
		Button3.Enabled = LB_Sides.Items.Count > 0;
		CB_AIOnly.Enabled = LB_Sides.Items.Count > 0;
		CB_CollRespons.Enabled = LB_Sides.Items.Count > 0;
		CB_AIOnly.Checked = factorySingleton.IsAIOnly;
		CB_CollRespons.Checked = factorySingleton.AssignsCollectiveResponsibility;
		CB_AutoTrackCivs.Checked = factorySingleton.CanAutoTrackCivs;
		switch (factorySingleton.AwarenessLevel)
		{
		case Side.AwarenessLevel_Enum.Blind:
			CB_Awareness.SelectedIndex = 0;
			break;
		case Side.AwarenessLevel_Enum.Normal:
			CB_Awareness.SelectedIndex = 1;
			break;
		case Side.AwarenessLevel_Enum.AutoSideID:
			CB_Awareness.SelectedIndex = 2;
			break;
		case Side.AwarenessLevel_Enum.AutoSideAndUnitID:
			CB_Awareness.SelectedIndex = 3;
			break;
		case Side.AwarenessLevel_Enum.Omniscient:
			CB_Awareness.SelectedIndex = 4;
			break;
		}
		Label_Proficiency.Visible = true;
		TrackBar_Proficiency.Visible = true;
		Label_Proficiency.Text = "能力：" + Misc.TestRequest(factorySingleton.Proficiency);
		TrackBar_Proficiency.Value = (int)factorySingleton.Proficiency;
		RefreshSideColorControls();
	}

	private void ChangeInterruptibleAdapter(object sender, EventArgs e)
	{
		if (DarkMessageBox.ShowWarning("你确定吗？所有单元，任务和该方的任何其他对象将被删除！", "删除分方：" + factorySingleton.Name, DarkDialogButton.OkCancel) != DialogResult.OK)
		{
			return;
		}
		Collection<ActiveUnit> collection = new Collection<ActiveUnit>();
		foreach (ActiveUnit unit in factorySingleton.Units)
		{
			collection.Add(unit);
		}
		foreach (ActiveUnit item in collection)
		{
			Client.CurrentScenario.DeleteUnitImmediately(item.ObjectID, bool_0: true, "Unit deleted");
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, UnguidedWeapon> unguidedWeapon in Client.CurrentScenario.UnguidedWeapons)
		{
			if (unguidedWeapon.Value.GetUnitSide() == factorySingleton)
			{
				list.Add(unguidedWeapon.Key);
			}
		}
		foreach (string item2 in list)
		{
			string string_ = item2;
			Client.CurrentScenario.UnguidedWeapons.Remove(string_);
			Side side = factorySingleton;
			Scenario scenario_ = Client.CurrentScenario;
			side.RemoveWeaponFromSalvos(ref scenario_, ref string_);
		}
		Client.CurrentScenario.RemoveSide(factorySingleton);
		Client.MustRefreshMainForm = true;
		RefreshForm();
	}

	private void InitInterruptibleAdapter(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.Postures.SelectedSide = factorySingleton;
		ItemExporter.ConnectInterruptibleTemplate.Postures.Mode = 0;
		ItemExporter.ConnectInterruptibleTemplate.Postures.Show();
	}

	private void CheckInterruptibleAdapter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(factorySingleton))
		{
			factorySingleton.IsAIOnly = CB_AIOnly.Checked;
		}
	}

	private void ConcatInterruptibleAdapter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(factorySingleton))
		{
			RenameSide renameSide = new RenameSide();
			renameSide.SelectedSide = factorySingleton;
			renameSide.Show();
		}
	}

	private void InterruptInterruptibleAdapter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(factorySingleton))
		{
			DoctrineForm doctrineForm = new DoctrineForm();
			doctrineForm.Subject = factorySingleton;
			doctrineForm.Show();
		}
	}

	private void RemoveInterruptibleAdapter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(factorySingleton))
		{
			switch (CB_Awareness.SelectedIndex)
			{
			case 0:
				factorySingleton.AwarenessLevel = Side.AwarenessLevel_Enum.Blind;
				break;
			case 1:
				factorySingleton.AwarenessLevel = Side.AwarenessLevel_Enum.Normal;
				break;
			case 2:
				factorySingleton.AwarenessLevel = Side.AwarenessLevel_Enum.AutoSideID;
				break;
			case 3:
				factorySingleton.AwarenessLevel = Side.AwarenessLevel_Enum.AutoSideAndUnitID;
				break;
			case 4:
				factorySingleton.AwarenessLevel = Side.AwarenessLevel_Enum.Omniscient;
				break;
			}
		}
	}

	private void FindInterruptibleAdapter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(factorySingleton))
		{
			factorySingleton.AssignsCollectiveResponsibility = CB_CollRespons.Checked;
		}
	}

	private void SetInterruptibleAdapter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(factorySingleton))
		{
			factorySingleton.Proficiency = (GlobalVariables.ProficiencyLevel)TrackBar_Proficiency.Value;
			Label_Proficiency.Text = "能力：" + Misc.TestRequest(factorySingleton.Proficiency);
		}
	}

	private void FillInterruptibleAdapter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (_AttributeSingleton)
		{
			if (e.KeyValue == 13 && base.Visible)
			{
				CB_CollRespons.Select();
				return;
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!_AttributeSingleton && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CalculateInterruptibleAdapter(object sender, EventArgs e)
	{
		_AttributeSingleton = true;
	}

	private void PopInterruptibleAdapter(object sender, EventArgs e)
	{
		_AttributeSingleton = false;
		CB_CollRespons.Select();
	}

	private void InstantiateInterruptibleAdapter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(factorySingleton))
		{
			factorySingleton.CanAutoTrackCivs = CB_AutoTrackCivs.Checked;
		}
	}

	private void CreateInterruptibleAdapter(object sender, EventArgs e)
	{
		if (Information.IsNothing(factorySingleton))
		{
			DarkMessageBox.ShowError("在编辑简报之前，必须选择一个分方", "没有选择分方！");
			return;
		}
		try
		{
			ItemExporter.ConnectInterruptibleTemplate.EditBriefing.theSelectedSide = factorySingleton;
			ItemExporter.ConnectInterruptibleTemplate.EditBriefing.Show();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200202", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CompareInterruptibleAdapter(object sender, EventArgs e)
	{
		if (check_FixedSideColor.Checked)
		{
			Panel_SideColor.Visible = true;
			Button_ChangeColor.Visible = true;
			return;
		}
		Panel_SideColor.BackColor = Color.Gray;
		Panel_SideColor.Visible = false;
		Button_ChangeColor.Visible = false;
		factorySingleton.AssignedFixedColor = null;
	}

	private void ReadInterruptibleAdapter(object sender, EventArgs e)
	{
		ColorDialog colorDialog = new ColorDialog();
		colorDialog.AllowFullOpen = true;
		colorDialog.AnyColor = true;
		colorDialog.Color = Panel_SideColor.BackColor;
		colorDialog.CustomColors = _EventSingleton;
		if (colorDialog.ShowDialog() == DialogResult.OK)
		{
			Panel_SideColor.BackColor = colorDialog.Color;
			factorySingleton.AssignedFixedColor = colorDialog.Color;
			_EventSingleton = colorDialog.CustomColors;
		}
	}

	private void DisableInterruptibleAdapter(object sender, EventArgs e)
	{
		Client.CurrentScenario.CreateNatureSideIfNeeded();
		RefreshForm();
	}
}
