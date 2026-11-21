using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using AGaugeApp;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using Command_Core.Lua;
using DarkUI.Controls;
using DarkUI.Forms;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Evaluation : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class InstanceConfigManager
	{
		public DateTime Local_min_t;

		internal double RestartInterruptiblePage(ScoringDatapointViewModel F)
		{
			return (double)(F.DateTime - Local_min_t).Ticks / 10000000.0;
		}
	}

	private IContainer m_PoolList;

	[AccessedThroughProperty("Label_Evaluation")]
	[CompilerGenerated]
	private DarkLabel m_TaskList;

	[AccessedThroughProperty("Label_Score")]
	[CompilerGenerated]
	private DarkLabel m_FilterList;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl testsList;

	[AccessedThroughProperty("TabPage1")]
	[CompilerGenerated]
	private TabPage interpreterList;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage2")]
	private TabPage containerList;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox m_ComposerList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton modelList;

	[AccessedThroughProperty("Button_ContinueCampaign")]
	[CompilerGenerated]
	private DarkUIButton advisorList;

	[AccessedThroughProperty("Label_PassScoreReached")]
	[CompilerGenerated]
	private DarkLabel customerList;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage3")]
	private TabPage serializerList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearScoringLog")]
	private DarkUIButton _ErrorList;

	[AccessedThroughProperty("TabPage4")]
	[CompilerGenerated]
	private TabPage m_ConnectionList;

	[AccessedThroughProperty("ElementHost1")]
	[CompilerGenerated]
	private ElementHost contextList;

	internal ScoringGraphControl _StatusList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RestartScenario")]
	private DarkUIButton strategyList;

	public bool EvaluationInProgress;

	private bool _ConfigurationList;

	internal DarkLabel Label_Evaluation
	{
		[CompilerGenerated]
		get
		{
			return m_TaskList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TaskList = value;
		}
	}

	internal DarkLabel Label_Score
	{
		[CompilerGenerated]
		get
		{
			return m_FilterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FilterList = value;
		}
	}

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return testsList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsList = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return interpreterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interpreterList = value;
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return containerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			containerList = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerList = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return modelList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyMethod;
			DarkUIButton darkUIButton = modelList;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			modelList = value;
			darkUIButton = modelList;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ContinueCampaign
	{
		[CompilerGenerated]
		get
		{
			return advisorList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostMethod;
			DarkUIButton darkUIButton = advisorList;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			advisorList = value;
			darkUIButton = advisorList;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkLabel Label_PassScoreReached
	{
		[CompilerGenerated]
		get
		{
			return customerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			customerList = value;
		}
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return serializerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerList = value;
		}
	}

	[field: AccessedThroughProperty("TextBox_ScoringLog")]
	internal DarkUITextBox TextBox_ScoringLog
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_ClearScoringLog
	{
		[CompilerGenerated]
		get
		{
			return _ErrorList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintMethod;
			DarkUIButton errorList = _ErrorList;
			if (errorList != null)
			{
				errorList.Click -= value2;
			}
			_ErrorList = value;
			errorList = _ErrorList;
			if (errorList != null)
			{
				errorList.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("AGauge1")]
	internal AGauge AGauge1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage4
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConnectionList = value;
		}
	}

	internal ElementHost ElementHost1
	{
		[CompilerGenerated]
		get
		{
			return contextList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			contextList = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_RestartScenario
	{
		[CompilerGenerated]
		get
		{
			return strategyList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineMethod;
			DarkUIButton darkUIButton = strategyList;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			strategyList = value;
			darkUIButton = strategyList;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public Evaluation()
	{
		base.Load += ReflectMethod;
		base.KeyDown += ListMethod;
		base.FormClosing += ResolveMethod;
		_ConfigurationList = false;
		PrepareMethod();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_PoolList != null)
			{
				m_PoolList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PrepareMethod()
	{
		Label_Evaluation = new DarkLabel();
		Label_Score = new DarkLabel();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		Button_RestartScenario = new DarkUIButton();
		Label1 = new Label();
		AGauge1 = new AGauge();
		Label_PassScoreReached = new DarkLabel();
		Button_ContinueCampaign = new DarkUIButton();
		Button1 = new DarkUIButton();
		TabPage2 = new TabPage();
		TextBox1 = new DarkUITextBox();
		TabPage3 = new TabPage();
		Button_ClearScoringLog = new DarkUIButton();
		TextBox_ScoringLog = new DarkUITextBox();
		TabPage4 = new TabPage();
		ElementHost1 = new ElementHost();
		_StatusList = new ScoringGraphControl();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		TabPage2.SuspendLayout();
		TabPage3.SuspendLayout();
		TabPage4.SuspendLayout();
		SuspendLayout();
		Label_Evaluation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Label_Evaluation.AutoSize = true;
		Label_Evaluation.Font = new Font("Segoe UI", 20f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 161);
		Label_Evaluation.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Evaluation.Location = new System.Drawing.Point(3, 267);
		Label_Evaluation.Name = "Label_Evaluation";
		Label_Evaluation.Size = new System.Drawing.Size(216, 37);
		Label_Evaluation.TabIndex = 0;
		Label_Evaluation.Text = "Label_Evaluation";
		Label_Evaluation.TextAlign = ContentAlignment.MiddleCenter;
		Label_Score.AutoSize = true;
		Label_Score.Font = new Font("Segoe UI", 16f, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 161);
		Label_Score.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Score.Location = new System.Drawing.Point(8, 319);
		Label_Score.Name = "Label_Score";
		Label_Score.Size = new System.Drawing.Size(128, 30);
		Label_Score.TabIndex = 1;
		Label_Score.Text = "Label_Score";
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Controls.Add(TabPage3);
		TabControl1.Controls.Add(TabPage4);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Dock = DockStyle.Fill;
		TabControl1.ItemSize = new System.Drawing.Size(80, 20);
		TabControl1.Location = new System.Drawing.Point(0, 0);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new System.Drawing.Size(707, 422);
		TabControl1.TabIndex = 2;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(Button_RestartScenario);
		TabPage1.Controls.Add(Label1);
		TabPage1.Controls.Add(AGauge1);
		TabPage1.Controls.Add(Label_PassScoreReached);
		TabPage1.Controls.Add(Button_ContinueCampaign);
		TabPage1.Controls.Add(Button1);
		TabPage1.Controls.Add(Label_Evaluation);
		TabPage1.Controls.Add(Label_Score);
		TabPage1.Font = new Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 161);
		TabPage1.Location = new System.Drawing.Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new System.Drawing.Size(699, 394);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "评估";
		Button_RestartScenario.BackColor = Color.Transparent;
		Button_RestartScenario.DialogResult = DialogResult.None;
		Button_RestartScenario.ForeColor = System.Drawing.SystemColors.Control;
		Button_RestartScenario.Location = new System.Drawing.Point(544, 321);
		Button_RestartScenario.Name = "Button_RestartScenario";
		Button_RestartScenario.RoundRadius = 0;
		Button_RestartScenario.Size = new System.Drawing.Size(149, 28);
		Button_RestartScenario.TabIndex = 7;
		Button_RestartScenario.Text = "重新开始想定";
		Label1.BorderStyle = BorderStyle.Fixed3D;
		Label1.ForeColor = Color.White;
		Label1.Location = new System.Drawing.Point(10, 310);
		Label1.Name = "Label1";
		Label1.Size = new System.Drawing.Size(683, 2);
		Label1.TabIndex = 6;
		AGauge1.BaseArcColor = Color.Gray;
		AGauge1.BaseArcRadius = 120;
		AGauge1.BaseArcStart = 135;
		AGauge1.BaseArcSweep = 270;
		AGauge1.BaseArcWidth = 1;
		AGauge1.Cap_Idx = 1;
		AGauge1.CapColors = new Color[5]
		{
			Color.Black,
			Color.Black,
			Color.Black,
			Color.Black,
			Color.Black
		};
		AGauge1.CapPosition = new System.Drawing.Point(10, 10);
		AGauge1.CapsPosition = new System.Drawing.Point[5]
		{
			new System.Drawing.Point(10, 10),
			new System.Drawing.Point(10, 10),
			new System.Drawing.Point(10, 10),
			new System.Drawing.Point(10, 10),
			new System.Drawing.Point(10, 10)
		};
		AGauge1.CapsText = new string[5] { "", "", "", "", "" };
		AGauge1.CapText = "";
		AGauge1.Center = new System.Drawing.Point(125, 125);
		AGauge1.Font = new Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, 161);
		AGauge1.Location = new System.Drawing.Point(210, 24);
		AGauge1.MaxValue = 400f;
		AGauge1.MinValue = -100f;
		AGauge1.Name = "AGauge1";
		AGauge1.NeedleColor1 = AGauge.NeedleColorEnum.Gray;
		AGauge1.NeedleColor2 = Color.DimGray;
		AGauge1.NeedleRadius = 80;
		AGauge1.NeedleType = 0;
		AGauge1.NeedleWidth = 4;
		AGauge1.Range_Idx = 2;
		AGauge1.RangeColor = Color.Blue;
		AGauge1.RangeEnabled = true;
		AGauge1.RangeEndValue = 0f;
		AGauge1.RangeInnerRadius = 70;
		AGauge1.RangeOuterRadius = 80;
		AGauge1.RangesColor = new Color[5]
		{
			Color.Red,
			Color.LightGray,
			Color.Blue,
			System.Drawing.SystemColors.Control,
			System.Drawing.SystemColors.Control
		};
		AGauge1.RangesEnabled = new bool[5] { true, true, true, false, false };
		AGauge1.RangesEndValue = new float[5] { 300f, 400f, 0f, 0f, 0f };
		AGauge1.RangesInnerRadius = new int[5] { 70, 70, 70, 70, 70 };
		AGauge1.RangesOuterRadius = new int[5] { 80, 80, 80, 80, 80 };
		AGauge1.RangesStartValue = new float[5] { -100f, 300f, 0f, 0f, 0f };
		AGauge1.RangeStartValue = 0f;
		AGauge1.ScaleLinesInterColor = Color.Transparent;
		AGauge1.ScaleLinesInterInnerRadius = 73;
		AGauge1.ScaleLinesInterOuterRadius = 80;
		AGauge1.ScaleLinesInterWidth = 0;
		AGauge1.ScaleLinesMajorColor = Color.Black;
		AGauge1.ScaleLinesMajorInnerRadius = 70;
		AGauge1.ScaleLinesMajorOuterRadius = 80;
		AGauge1.ScaleLinesMajorStepValue = 50f;
		AGauge1.ScaleLinesMajorWidth = 0;
		AGauge1.ScaleLinesMinorColor = Color.Gray;
		AGauge1.ScaleLinesMinorInnerRadius = 75;
		AGauge1.ScaleLinesMinorNumOf = 0;
		AGauge1.ScaleLinesMinorOuterRadius = 80;
		AGauge1.ScaleLinesMinorWidth = 1;
		AGauge1.ScaleNumbersColor = Color.LightGray;
		AGauge1.ScaleNumbersFormat = "F0";
		AGauge1.ScaleNumbersRadius = 95;
		AGauge1.ScaleNumbersRotation = 0;
		AGauge1.ScaleNumbersStartScaleLine = 0;
		AGauge1.ScaleNumbersStepScaleLines = 1;
		AGauge1.Size = new System.Drawing.Size(257, 235);
		AGauge1.TabIndex = 5;
		AGauge1.Text = "AGauge1";
		AGauge1.Value = 0f;
		Label_PassScoreReached.AutoSize = true;
		Label_PassScoreReached.ForeColor = Color.FromArgb(220, 220, 220);
		Label_PassScoreReached.Location = new System.Drawing.Point(10, 364);
		Label_PassScoreReached.Name = "Label_PassScoreReached";
		Label_PassScoreReached.Size = new System.Drawing.Size(135, 13);
		Label_PassScoreReached.TabIndex = 4;
		Label_PassScoreReached.Text = "Label_PassScoreReached";
		Button_ContinueCampaign.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_ContinueCampaign.BackColor = Color.Transparent;
		Button_ContinueCampaign.DialogResult = DialogResult.None;
		Button_ContinueCampaign.ForeColor = System.Drawing.SystemColors.Control;
		Button_ContinueCampaign.Location = new System.Drawing.Point(544, 364);
		Button_ContinueCampaign.Name = "Button_ContinueCampaign";
		Button_ContinueCampaign.RoundRadius = 0;
		Button_ContinueCampaign.Size = new System.Drawing.Size(149, 27);
		Button_ContinueCampaign.TabIndex = 3;
		Button_ContinueCampaign.Text = "继续战役";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.ForeColor = System.Drawing.SystemColors.Control;
		Button1.Location = new System.Drawing.Point(326, 321);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new System.Drawing.Size(177, 28);
		Button1.TabIndex = 2;
		Button1.Text = "退出想定";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(TextBox1);
		TabPage2.Location = new System.Drawing.Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new System.Drawing.Size(699, 394);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "损失和消耗";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Dock = DockStyle.Fill;
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new System.Drawing.Point(3, 3);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.Vertical;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new System.Drawing.Size(693, 388);
		TextBox1.TabIndex = 0;
		TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(Button_ClearScoringLog);
		TabPage3.Controls.Add(TextBox_ScoringLog);
		TabPage3.Location = new System.Drawing.Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Size = new System.Drawing.Size(699, 394);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "评分日志";
		Button_ClearScoringLog.BackColor = Color.Transparent;
		Button_ClearScoringLog.DialogResult = DialogResult.None;
		Button_ClearScoringLog.ForeColor = System.Drawing.SystemColors.Control;
		Button_ClearScoringLog.Location = new System.Drawing.Point(3, 3);
		Button_ClearScoringLog.Name = "Button_ClearScoringLog";
		Button_ClearScoringLog.RoundRadius = 0;
		Button_ClearScoringLog.Size = new System.Drawing.Size(75, 23);
		Button_ClearScoringLog.TabIndex = 2;
		Button_ClearScoringLog.Text = "清除日志";
		TextBox_ScoringLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox_ScoringLog.AutoCompleteCustomSource = null;
		TextBox_ScoringLog.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_ScoringLog.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_ScoringLog.BackColor = Color.Transparent;
		TextBox_ScoringLog.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_ScoringLog.Image = null;
		TextBox_ScoringLog.Lines = null;
		TextBox_ScoringLog.Location = new System.Drawing.Point(0, 29);
		TextBox_ScoringLog.MaxLength = 32767;
		TextBox_ScoringLog.Multiline = true;
		TextBox_ScoringLog.Name = "TextBox_ScoringLog";
		TextBox_ScoringLog.ReadOnly = false;
		TextBox_ScoringLog.ScrollBars = ScrollBars.Vertical;
		TextBox_ScoringLog.SelectionStart = 0;
		TextBox_ScoringLog.Size = new System.Drawing.Size(699, 367);
		TextBox_ScoringLog.TabIndex = 1;
		TextBox_ScoringLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		TextBox_ScoringLog.UseSystemPasswordChar = false;
		TextBox_ScoringLog.WatermarkText = "";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Controls.Add(ElementHost1);
		TabPage4.Location = new System.Drawing.Point(4, 24);
		TabPage4.Name = "TabPage4";
		TabPage4.Padding = new Padding(3);
		TabPage4.Size = new System.Drawing.Size(699, 394);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "得分图表";
		ElementHost1.Dock = DockStyle.Fill;
		ElementHost1.Location = new System.Drawing.Point(3, 3);
		ElementHost1.Name = "ElementHost1";
		ElementHost1.Size = new System.Drawing.Size(693, 388);
		ElementHost1.TabIndex = 0;
		ElementHost1.Text = "ElementHost1";
		ElementHost1.Child = _StatusList;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(707, 422);
		base.Controls.Add(TabControl1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Evaluation";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "参演方评估";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		TabPage2.ResumeLayout(performLayout: false);
		TabPage3.ResumeLayout(performLayout: false);
		TabPage4.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void ReflectMethod(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (!Client.CurrentSide.Scoring_Disaster.HasValue && !Client.CurrentSide.Scoring_Triumph.HasValue)
		{
			_ConfigurationList = true;
		}
		VisitMethod();
	}

	private void VisitMethod()
	{
		EvaluationInProgress = true;
		if (Client.CurrentScenario.HasEnded)
		{
			AssetMethod(0);
		}
		Label_Evaluation.Text = (_ConfigurationList ? "No thresholds have been defined" : Client.EvaluateScoring());
		StopMethod();
		CancelMethod();
		Button1.Visible = !Client.CurrentScenario.HasEnded;
		if (Client.CurrentScenario.IsRunningInCampaignMode)
		{
			Label_PassScoreReached.Visible = true;
			Button_ContinueCampaign.Visible = true;
			int? campaignScenarioPassScore = Campaign.GetCampaignScenarioPassScore(Client.CurrentScenario);
			if (campaignScenarioPassScore.HasValue)
			{
				int totalScore = Client.CurrentSide.GetTotalScore(Client.CurrentScenario);
				if ((campaignScenarioPassScore.HasValue ? new bool?(totalScore >= campaignScenarioPassScore.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					Label_PassScoreReached.Text = "您已达到此战役想定的及格分数！";
					Button_ContinueCampaign.Enabled = true;
					goto IL_01aa;
				}
			}
			Label_PassScoreReached.Text = "您当前的想定分数（" + Conversions.ToString(Client.CurrentSide.GetTotalScore(Client.CurrentScenario)) + "）仍低于此战役想定的通过分数（" + (campaignScenarioPassScore.HasValue ? Conversions.ToString(campaignScenarioPassScore.GetValueOrDefault()) : null) + ")";
			Button_ContinueCampaign.Enabled = false;
		}
		else
		{
			Label_PassScoreReached.Visible = false;
			Button_ContinueCampaign.Visible = false;
		}
		goto IL_01aa;
		IL_01aa:
		TextBox1.Text = string.Empty;
		if (!Information.IsNothing(Client.CurrentSide))
		{
			if (Client.CurrentScenario.HasEnded)
			{
				Label_Score.Text = "最终分数：" + Conversions.ToString(Client.CurrentSide.GetTotalScore(Client.CurrentScenario));
			}
			else
			{
				Label_Score.Text = "当前分数：" + Conversions.ToString(Client.CurrentSide.GetTotalScore(Client.CurrentScenario));
			}
			TestMethod(Client.CurrentSide);
		}
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side_ in array)
		{
			RestartMethod(side_);
		}
		EvaluationInProgress = false;
	}

	private void RestartMethod(Side side_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("分方：" + side_0.Name + "\r\n===========================================================\r\n\r\n");
		stringBuilder.Append("战损:\r\n-------------------------------\r\n");
		foreach (KeyValuePair<string, HashSet<string>> loss in side_0.AAR.Losses)
		{
			string[] array = loss.Key.ToString().Split('_');
			string text = "";
			bool flag = false;
			if (Conversions.ToDouble(array[1]) < 0.0)
			{
				array[1] = (Conversions.ToInteger(array[1]) * -1).ToString();
				flag = true;
			}
			string left = array[0].ToString();
			if (Operators.CompareString(left, "Aircraft", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(Client.CurrentScenario.Cache_Aircraft_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Ship", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(Client.CurrentScenario.Cache_Ships_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Submarine", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(Client.CurrentScenario.Cache_Subs_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Facility", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(Client.CurrentScenario.Cache_Facilities_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Weapon", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(Client.CurrentScenario.Cache_Weapons_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "GroundUnit", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(Client.CurrentScenario.Cache_GroundUnits_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "FacilityAimpoint", TextCompare: true) == 0)
			{
				if (Operators.CompareString(array[1], "0", TextCompare: true) == 0)
				{
					text = "不可识别的陆地目标点  - 对不起！";
				}
				else
				{
					int int_ = Conversions.ToInteger(array[1]);
					Scenario scenario_ = Client.CurrentScenario;
					text = Misc.ReadRequest(DBFunctions.GetMountName(int_, ref scenario_));
				}
			}
			if (flag)
			{
				text = "[DECOY] " + text;
			}
			stringBuilder.Append(Conversions.ToString(loss.Value.Count) + "x " + text + "\r\n");
		}
		stringBuilder.Append("\r\n\r\n消耗:\r\n------------------\r\n");
		foreach (KeyValuePair<int, int> expenditure in side_0.AAR.Expenditures)
		{
			stringBuilder.Append(expenditure.Value + "x " + side_0.AAR.PublishInterruptibleReg(Client.CurrentScenario, expenditure) + "\r\n");
		}
		stringBuilder.Append("\r\n\r\n\r\n");
		TextBox1.Text += stringBuilder.ToString();
	}

	private void TestMethod(Side side_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in side_0.ScoringLog)
		{
			stringBuilder.Append(item).Append("\r\n").Append("\r\n");
		}
		TextBox_ScoringLog.Text = stringBuilder.ToString();
	}

	private void StopMethod()
	{
		if (Client.CurrentSide.ScoringLog.Count == 0)
		{
			_StatusList.Visibility = Visibility.Hidden;
			return;
		}
		_StatusList.Visibility = Visibility.Visible;
		Regex regex = new Regex("^(\\d\\d)-(\\d\\d)-(\\d\\d\\d\\d) (\\d\\d):(\\d\\d)：分数从 (.+) 变为 (.+)\\。原因：(.+)$");
		List<Tuple<DateTime, int, string>> list = new List<Tuple<DateTime, int, string>>(Client.CurrentSide.ScoringLog.Count * 2 + 1);
		list.Add(new Tuple<DateTime, int, string>(Client.CurrentScenario.StartTime, 0, "初始分数"));
		foreach (string item3 in Client.CurrentSide.ScoringLog)
		{
			Match match = regex.Match(item3);
			if (match.Success)
			{
				DateTime item = new DateTime(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value), 0);
				int.Parse(match.Groups[6].Value);
				int item2 = int.Parse(match.Groups[7].Value);
				string value = match.Groups[8].Value;
				list.Add(new Tuple<DateTime, int, string>(item, item2, value));
			}
		}
		list.Add(new Tuple<DateTime, int, string>(Client.CurrentScenario.Time, Client.CurrentSide.GetTotalScore(null), "当前分数"));
		DateTime Local_min_t = list.Min((Tuple<DateTime, int, string> F) => F.Item1);
		ChartValues<ScoringDatapointViewModel> val = new ChartValues<ScoringDatapointViewModel>();
		foreach (Tuple<DateTime, int, string> item4 in list)
		{
			ScoringDatapointViewModel scoringDatapointViewModel = new ScoringDatapointViewModel();
			scoringDatapointViewModel.DateTime = item4.Item1;
			scoringDatapointViewModel.ScoreValue = item4.Item2;
			scoringDatapointViewModel.Reason = item4.Item3;
			((NoisyCollection<ScoringDatapointViewModel>)val).Add(scoringDatapointViewModel);
		}
		Charting.For<ScoringDatapointViewModel>(Mappers.Xy<ScoringDatapointViewModel>().X((ScoringDatapointViewModel F) => (double)(F.DateTime - Local_min_t).Ticks / 10000000.0).Y((ScoringDatapointViewModel F) => F.ScoreValue));
		ScoringGraphControlViewModel scoringGraphControlViewModel = new ScoringGraphControlViewModel();
		scoringGraphControlViewModel.PlayerScore = val;
		_StatusList.DataContext = scoringGraphControlViewModel;
	}

	private void CancelMethod()
	{
		int totalScore = Client.CurrentSide.GetTotalScore(Client.CurrentScenario);
		AGauge1.MinValue = Math.Min(totalScore, Client.CurrentSide.Scoring_Disaster.HasValue ? Client.CurrentSide.Scoring_Disaster.Value : 0);
		AGauge1.MaxValue = Math.Max(totalScore, Client.CurrentSide.Scoring_Triumph.HasValue ? Client.CurrentSide.Scoring_Triumph.Value : 0);
		AGauge1.MinValue = (Client.CurrentSide.Scoring_Disaster.HasValue ? Client.CurrentSide.Scoring_Disaster.Value : (-100));
		AGauge1.MaxValue = (Client.CurrentSide.Scoring_Triumph.HasValue ? Client.CurrentSide.Scoring_Triumph.Value : 100);
		AGauge1.Value = totalScore;
		int scoring_MinorDefeat = Client.CurrentSide.Scoring_MinorDefeat;
		int scoring_MajorVictory = Client.CurrentSide.Scoring_MajorVictory;
		AGauge1.ScaleLinesMajorStepValue = (float)((double)(Math.Abs(AGauge1.MaxValue) + Math.Abs(AGauge1.MinValue)) / 10.0);
		AGauge1.Range_Idx = 0;
		AGauge1.RangeStartValue = AGauge1.MinValue;
		AGauge1.RangeEndValue = scoring_MinorDefeat;
		AGauge1.Range_Idx = 1;
		AGauge1.RangeStartValue = scoring_MinorDefeat;
		AGauge1.RangeEndValue = scoring_MajorVictory;
		AGauge1.Range_Idx = 2;
		AGauge1.RangeStartValue = scoring_MajorVictory;
		AGauge1.RangeEndValue = AGauge1.MaxValue;
	}

	private void VerifyMethod(object sender, EventArgs e)
	{
		AssetMethod(1);
		Client.CurrentScenario.EndScenario();
		VisitMethod();
	}

	private void ListMethod(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.End && e.KeyCode != Keys.Home && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Add && e.KeyCode != Keys.Subtract && (e.KeyCode != Keys.C || e.Modifiers != Keys.Control) && (e.KeyCode != Keys.X || e.Modifiers != Keys.Control)))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ResolveMethod(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void PostMethod(object sender, EventArgs e)
	{
		if (!Client.CurrentScenario.IsRunningInCampaignMode)
		{
			return;
		}
		List<string> list = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		foreach (string item in list)
		{
			Campaign campaign = Campaign.ReadFromFile(item);
			if (Operators.CompareString(campaign.ID, Client.CurrentScenario.CampaignID, TextCompare: true) != 0)
			{
				continue;
			}
			Campaign.UpdateHistory(item, campaign, Client.CurrentScenario);
			AssetMethod(2);
			{
				foreach (Campaign.CampaignItem campaignItem2 in campaign.CampaignItems)
				{
					if ((object)campaignItem2.GetType() != typeof(Campaign.ScenarioRecord) || Operators.CompareString(((Campaign.ScenarioRecord)campaignItem2).ID, Client.CurrentScenario.ObjectID, TextCompare: true) != 0)
					{
						continue;
					}
					int num = campaign.CampaignItems.IndexOf(campaignItem2);
					if (num != campaign.CampaignItems.Count - 1)
					{
						Campaign.CampaignItem campaignItem = campaign.CampaignItems[num + 1];
						Type type = campaignItem.GetType();
						if (!(type == typeof(Campaign.ScenarioRecord)))
						{
							if (!(type == typeof(Campaign.AttachmentRecord)))
							{
								continue;
							}
							RunMethod(campaignItem, campaign, item);
							if (campaignItem == campaign.CampaignItems.Last())
							{
								StartMethod(campaign);
							}
							else
							{
								RunMethod(campaign.CampaignItems[num + 2], campaign, item);
							}
							break;
						}
						RunMethod(campaignItem, campaign, item);
						break;
					}
					StartMethod(campaign);
					break;
				}
				break;
			}
		}
	}

	private void RunMethod(Campaign.CampaignItem campaignItem_0, Campaign campaign_0, string string_0)
	{
		Type type = campaignItem_0.GetType();
		if (type == typeof(Campaign.ScenarioRecord))
		{
			string scenFileName = Path.GetDirectoryName(string_0) + "\\" + ((Campaign.ScenarioRecord)campaignItem_0).FileName;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.SelectedCampaign = campaign_0;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.ScenFileName = scenFileName;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.CampaignSessionID = Client.CurrentScenario.CampaignSessionID;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.CampaignScore = Client.CurrentScenario.CampaignScore + Client.CurrentSide.GetTotalScore(Client.CurrentScenario);
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.LuaXml = Client.CurrentScenario.LuaXmlPassed;
			ItemExporter.ConnectInterruptibleTemplate.CampaignScenarioWindow.Show();
			Close();
		}
		else if (type == typeof(Campaign.AttachmentRecord))
		{
			LuaSAO.ScenEdit_UseAttachment(((Campaign.AttachmentRecord)campaignItem_0).ID, null);
		}
	}

	private void StartMethod(Campaign campaign_0)
	{
		ItemExporter.ConnectInterruptibleTemplate.CampaignEnd.theCampaign = campaign_0;
		ItemExporter.ConnectInterruptibleTemplate.CampaignEnd.Show();
	}

	private bool AssetMethod(int int_0)
	{
		List<string> list = new List<string>();
		bool result = false;
		string[] array = new string[3] { "Setup", "Quit", "Continue" };
		foreach (Command_Core.EventTrigger value in Client.CurrentScenario.EventTriggers.Values)
		{
			if (value.Type != Command_Core.EventTrigger.EventTriggerType.ScenEnded || !((EventTrigger_ScenEnded)value).GetIsFulfilled(Client.CurrentScenario))
			{
				continue;
			}
			foreach (SimEvent value2 in Client.CurrentScenario.SimEvents.Values)
			{
				if (!value2.IsActive || !value2.Triggers.Contains(value))
				{
					continue;
				}
				if (value2.GetConditionsAreMet(Client.CurrentScenario))
				{
					if (value2.IsShown)
					{
						Client.CurrentScenario.AddMessage("事件：'" + value2.Description + "(" + array[int_0] + "）'受到攻击。", null, LoggedMessage.MessageType.EventEngine, 1, "");
					}
					LuaSandBox.Singleton().SB_Lua()["stage"] = "none";
					foreach (EventAction action in value2.Actions)
					{
						LuaSandBox.Singleton().SB_Lua()["stage"] = int_0;
						action.Execute(Client.CurrentScenario, value2);
						string text = null;
						try
						{
							text = LuaSandBox.Singleton().SB_Lua().GetString("answer");
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						if (text != null)
						{
							list.Add(text);
						}
						result = true;
					}
				}
				else if (value2.IsShown)
				{
					Client.CurrentScenario.AddMessage("事件：'" + value2.Description + "'被触发但没有执行（至少有一个条件不成立）。", null, LoggedMessage.MessageType.EventEngine, 1, "");
				}
			}
		}
		return result;
	}

	private void PrintMethod(object sender, EventArgs e)
	{
		Client.CurrentSide.ScoringLog.Clear();
		TextBox_ScoringLog.Clear();
	}

	private void DefineMethod(object sender, EventArgs e)
	{
		string[] files = Directory.GetFiles(GameGeneral.ScenariosRootPath, "*.scen", SearchOption.AllDirectories);
		int num = 0;
		string text;
		while (true)
		{
			if (num < files.Length)
			{
				text = files[num];
				if (!Path.GetFileName(text).StartsWith("Autosave") && Operators.CompareString(ScenContainer.LoadFromFile(text).ScenTitle, Client.CurrentScenario.Title, TextCompare: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			DarkMessageBox.ShowInformation("无法自动找到开始想定。请手动指定。", "原始想定未找到");
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.myDefaultAction = LoadScenario.DefaultAction.LoadScenario;
			ItemExporter.ConnectInterruptibleTemplate.LoadScenario.Show();
			Close();
			return;
		}
		ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = text;
		ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.CampaignSessionID = Client.CurrentScenario.CampaignSessionID;
		ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
		Close();
	}
}
