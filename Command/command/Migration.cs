using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Command.Messages;
using Command_Core;
using Command_Core.LoadSave;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Migration : DarkSecondaryFormBase
{
	private IContainer _RuleContext;

	[AccessedThroughProperty("MigrationAllScenarios")]
	[CompilerGenerated]
	private DarkGroupBox m_CollectionContext;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton m_InstanceContext;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox m_ParameterContext;

	[AccessedThroughProperty("MigrationSingleScenario")]
	[CompilerGenerated]
	private DarkGroupBox expressionContext;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DeepRebuild")]
	private DarkCheckBox m_ListenerContext;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel m_RegistryContext;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel definitionContext;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _ValContext;

	[AccessedThroughProperty("Button_BatchRebuildManual")]
	[CompilerGenerated]
	private DarkUIButton m_WrapperContext;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_Default_AAW_WRA_Range")]
	private DarkUIComboBox consumerContext;

	[AccessedThroughProperty("FD_LoadINI")]
	[CompilerGenerated]
	private OpenFileDialog _ProxyContext;

	[AccessedThroughProperty("FD_ManualSelect")]
	[CompilerGenerated]
	private OpenFileDialog readerContext;

	private string _PropertyContext;

	public DBRecord TargetDB;

	internal DarkGroupBox MigrationAllScenarios
	{
		[CompilerGenerated]
		get
		{
			return m_CollectionContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CollectionContext = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_InstanceContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleRegistry;
			DarkUIButton instanceContext = m_InstanceContext;
			if (instanceContext != null)
			{
				instanceContext.Click -= value2;
			}
			m_InstanceContext = value;
			instanceContext = m_InstanceContext;
			if (instanceContext != null)
			{
				instanceContext.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ParameterContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParameterContext = value;
		}
	}

	internal DarkGroupBox MigrationSingleScenario
	{
		[CompilerGenerated]
		get
		{
			return expressionContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			expressionContext = value;
		}
	}

	[field: AccessedThroughProperty("CB_ApplyINI")]
	internal DarkCheckBox CB_ApplyINI
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_DeepRebuild
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ListenerContext = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RegistryContext = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return definitionContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			definitionContext = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _ValContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableInterruptibleRegistry;
			DarkUIButton valContext = _ValContext;
			if (valContext != null)
			{
				valContext.Click -= value2;
			}
			_ValContext = value;
			valContext = _ValContext;
			if (valContext != null)
			{
				valContext.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_BatchRebuildManual
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertInterruptibleRegistry;
			DarkUIButton wrapperContext = m_WrapperContext;
			if (wrapperContext != null)
			{
				wrapperContext.Click -= value2;
			}
			m_WrapperContext = value;
			wrapperContext = m_WrapperContext;
			if (wrapperContext != null)
			{
				wrapperContext.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal DarkLabel Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CB_KeepOODA")]
	internal DarkCheckBox CB_KeepOODA
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal DarkLabel DarkLabel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_Default_AAW_WRA_Range
	{
		[CompilerGenerated]
		get
		{
			return consumerContext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			consumerContext = value;
		}
	}

	[field: AccessedThroughProperty("LBL_AAW_DEF_RANGE")]
	internal DarkLabel LBL_AAW_DEF_RANGE
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog ComputeInterruptibleDefinition()
	{
		return _ProxyContext;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void PatchInterruptibleDefinition(OpenFileDialog openFileDialog_0)
	{
		_ProxyContext = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog CallInterruptibleDefinition()
	{
		return readerContext;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void LogoutInterruptibleDefinition(OpenFileDialog openFileDialog_0)
	{
		readerContext = openFileDialog_0;
	}

	public Migration()
	{
		base.Load += PopInterruptibleRegistry;
		base.Shown += InstantiateInterruptibleRegistry;
		base.KeyDown += ReflectInterruptibleRegistry;
		base.FormClosing += VisitInterruptibleRegistry;
		FindInterruptibleRegistry();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _RuleContext != null)
			{
				_RuleContext.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void FindInterruptibleRegistry()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(Migration));
		MigrationAllScenarios = new DarkGroupBox();
		Button_BatchRebuildManual = new DarkUIButton();
		Label4 = new DarkLabel();
		Button2 = new DarkUIButton();
		Label3 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		MigrationSingleScenario = new DarkGroupBox();
		DarkLabel2 = new DarkLabel();
		CB_KeepOODA = new DarkCheckBox();
		DarkLabel1 = new DarkLabel();
		CB_ApplyINI = new DarkCheckBox();
		CB_DeepRebuild = new DarkCheckBox();
		Label1 = new DarkLabel();
		Label5 = new DarkLabel();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		LBL_AAW_DEF_RANGE = new DarkLabel();
		Combo_Default_AAW_WRA_Range = new DarkUIComboBox();
		MigrationAllScenarios.SuspendLayout();
		MigrationSingleScenario.SuspendLayout();
		SuspendLayout();
		MigrationAllScenarios.Controls.Add(Button_BatchRebuildManual);
		MigrationAllScenarios.Controls.Add(Label4);
		MigrationAllScenarios.Controls.Add(Button2);
		MigrationAllScenarios.Controls.Add(Label3);
		MigrationAllScenarios.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		MigrationAllScenarios.ForeColor = Color.FromArgb(220, 220, 220);
		MigrationAllScenarios.Location = new Point(12, 308);
		MigrationAllScenarios.Name = "MigrationAllScenarios";
		MigrationAllScenarios.Size = new Size(680, 73);
		MigrationAllScenarios.TabIndex = 7;
		MigrationAllScenarios.TabStop = false;
		MigrationAllScenarios.Text = "批量重构多个想定";
		Button_BatchRebuildManual.BackColor = Color.Transparent;
		Button_BatchRebuildManual.DialogResult = DialogResult.None;
		Button_BatchRebuildManual.ForeColor = SystemColors.Control;
		Button_BatchRebuildManual.Location = new Point(388, 45);
		Button_BatchRebuildManual.Name = "Button_BatchRebuildManual";
		Button_BatchRebuildManual.RoundRadius = 0;
		Button_BatchRebuildManual.Size = new Size(231, 23);
		Button_BatchRebuildManual.TabIndex = 6;
		Button_BatchRebuildManual.Text = "深度重构（手动选择）";
		Label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(363, 15);
		Label4.Name = "Label4";
		Label4.Size = new Size(313, 52);
		Label4.TabIndex = 5;
		Label4.Text = "手动选择然后重构多个想定文件并应用INI文件（如果存在）";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(33, 45);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(239, 23);
		Button2.TabIndex = 4;
		Button2.Text = "深度重建列表中的所有想定";
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(9, 16);
		Label3.Name = "Label3";
		Label3.Size = new Size(313, 51);
		Label3.TabIndex = 2;
		Label3.Text = "从想定列表文件读取然后重构多个想定文件并应用INI文件（如果存在）";
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(-2, 387);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(706, 260);
		TextBox1.TabIndex = 6;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		MigrationSingleScenario.Controls.Add(Combo_Default_AAW_WRA_Range);
		MigrationSingleScenario.Controls.Add(LBL_AAW_DEF_RANGE);
		MigrationSingleScenario.Controls.Add(DarkLabel2);
		MigrationSingleScenario.Controls.Add(CB_KeepOODA);
		MigrationSingleScenario.Controls.Add(DarkLabel1);
		MigrationSingleScenario.Controls.Add(CB_ApplyINI);
		MigrationSingleScenario.Controls.Add(CB_DeepRebuild);
		MigrationSingleScenario.Controls.Add(Label1);
		MigrationSingleScenario.Controls.Add(Label5);
		MigrationSingleScenario.Controls.Add(Label2);
		MigrationSingleScenario.Controls.Add(Button1);
		MigrationSingleScenario.ForeColor = Color.FromArgb(220, 220, 220);
		MigrationSingleScenario.Location = new Point(12, 11);
		MigrationSingleScenario.Name = "MigrationSingleScenario";
		MigrationSingleScenario.Size = new Size(680, 291);
		MigrationSingleScenario.TabIndex = 8;
		MigrationSingleScenario.TabStop = false;
		MigrationSingleScenario.Text = "重建当前想定";
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(6, 201);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(668, 35);
		DarkLabel2.TabIndex = 8;
		DarkLabel2.Text = componentResourceManager.GetString("DarkLabel2.Text");
		CB_KeepOODA.AutoSize = true;
		CB_KeepOODA.Location = new Point(299, 237);
		CB_KeepOODA.Name = "CB_KeepOODA";
		CB_KeepOODA.Size = new Size(143, 19);
		CB_KeepOODA.TabIndex = 6;
		CB_KeepOODA.Text = "Preserve OODA Values";
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(6, 166);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(668, 35);
		DarkLabel1.TabIndex = 5;
		DarkLabel1.Text = componentResourceManager.GetString("DarkLabel1.Text");
		CB_ApplyINI.AutoSize = true;
		CB_ApplyINI.Location = new Point(193, 237);
		CB_ApplyINI.Name = "CB_ApplyINI";
		CB_ApplyINI.Size = new Size(96, 19);
		CB_ApplyINI.TabIndex = 4;
		CB_ApplyINI.Text = "应用INI文件";
		CB_DeepRebuild.AutoSize = true;
		CB_DeepRebuild.Location = new Point(53, 237);
		CB_DeepRebuild.Name = "CB_DeepRebuild";
		CB_DeepRebuild.Size = new Size(130, 19);
		CB_DeepRebuild.TabIndex = 3;
		CB_DeepRebuild.Text = "强制深度重建";
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(6, 16);
		Label1.Name = "Label1";
		Label1.Size = new Size(668, 63);
		Label1.TabIndex = 1;
		Label1.Text = componentResourceManager.GetString("Label1.Text");
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(6, 130);
		Label5.Name = "Label5";
		Label5.Size = new Size(668, 32);
		Label5.TabIndex = 2;
		Label5.Text = componentResourceManager.GetString("Label5.Text");
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(6, 79);
		Label2.Name = "Label2";
		Label2.Size = new Size(668, 47);
		Label2.TabIndex = 2;
		Label2.Text = componentResourceManager.GetString("Label2.Text");
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(208, 262);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(217, 23);
		Button1.TabIndex = 3;
		Button1.Text = "我明白了 - 重建当前想定";
		LBL_AAW_DEF_RANGE.AutoSize = true;
		LBL_AAW_DEF_RANGE.ForeColor = Color.FromArgb(220, 220, 220);
		LBL_AAW_DEF_RANGE.Location = new Point(460, 238);
		LBL_AAW_DEF_RANGE.Name = "LBL_AAW_DEF_RANGE";
		LBL_AAW_DEF_RANGE.Size = new Size(171, 15);
		LBL_AAW_DEF_RANGE.TabIndex = 9;
		LBL_AAW_DEF_RANGE.Text = "Default AA Missile WRA Range:";
		Combo_Default_AAW_WRA_Range.BackColor = Color.Transparent;
		Combo_Default_AAW_WRA_Range.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Default_AAW_WRA_Range.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Default_AAW_WRA_Range.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Default_AAW_WRA_Range.FormattingEnabled = true;
		Combo_Default_AAW_WRA_Range.Location = new Point(463, 256);
		Combo_Default_AAW_WRA_Range.Name = "Combo_Default_AAW_WRA_Range";
		Combo_Default_AAW_WRA_Range.Size = new Size(196, 21);
		Combo_Default_AAW_WRA_Range.TabIndex = 10;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(704, 644);
		base.Controls.Add(MigrationAllScenarios);
		base.Controls.Add(TextBox1);
		base.Controls.Add(MigrationSingleScenario);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Migration";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "想定迁移";
		MigrationAllScenarios.ResumeLayout(performLayout: false);
		MigrationSingleScenario.ResumeLayout(performLayout: false);
		MigrationSingleScenario.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void SetInterruptibleRegistry()
	{
		Combo_Default_AAW_WRA_Range.Items.Clear();
		Combo_Default_AAW_WRA_Range.Items.Add("Default (max range)");
		Combo_Default_AAW_WRA_Range.Items.Add("75% of max");
		Combo_Default_AAW_WRA_Range.Items.Add("50% of max");
		Combo_Default_AAW_WRA_Range.Items.Add("25% of max");
		Combo_Default_AAW_WRA_Range.Items.Add("不可逃逸区NEZ");
		Combo_Default_AAW_WRA_Range.SelectedIndex = 0;
	}

	private void FillInterruptibleRegistry(int int_0)
	{
		switch (int_0)
		{
		case -97:
			Combo_Default_AAW_WRA_Range.SelectedIndex = 1;
			break;
		case -96:
			Combo_Default_AAW_WRA_Range.SelectedIndex = 2;
			break;
		case -95:
			Combo_Default_AAW_WRA_Range.SelectedIndex = 3;
			break;
		case -102:
			Combo_Default_AAW_WRA_Range.SelectedIndex = 4;
			break;
		}
	}

	private int CalculateInterruptibleRegistry()
	{
		int selectedIndex = Combo_Default_AAW_WRA_Range.SelectedIndex;
		if (1 == 0)
		{
		}
		int result = selectedIndex switch
		{
			1 => -97, 
			2 => -96, 
			3 => -95, 
			4 => -102, 
			_ => -101, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private void PopInterruptibleRegistry(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		SetInterruptibleRegistry();
	}

	private void InstantiateInterruptibleRegistry(object sender, EventArgs e)
	{
		DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
		if (TargetDB == null)
		{
			TargetDB = DBOps.GetDBRecordByHash(DBOps.GetHashForMostRecentVersionOfThisDB(Client.CurrentDB.DBID), ref dbfileCheckResult_);
		}
		if (TargetDB == null)
		{
			DarkMessageBox.ShowError("准备迁移时出错：" + Conversions.ToString((int)dbfileCheckResult_) + "\r\nAborting...", "Error");
		}
		_PropertyContext = TargetDB.FileName;
		Text = "想定迁移（选定的数据库：" + _PropertyContext + ")";
		FillInterruptibleRegistry(Client.CurrentScenario.DefaultGuidedWeaponsVsAirTargetWRASetting);
	}

	private static void CreateInterruptibleRegistry(Scenario scenario_0, int int_0)
	{
		if (scenario_0 != null)
		{
			scenario_0.DefaultGuidedWeaponsVsAirTargetWRASetting = int_0;
		}
	}

	private static void CompareInterruptibleRegistry(Scenario scenario_0)
	{
		if (scenario_0 == null)
		{
			return;
		}
		foreach (ActiveUnit item in scenario_0.ActiveUnits.Values.ToList())
		{
			item.HasCustomOODA = true;
		}
	}

	private void ReadInterruptibleRegistry()
	{
		bool @checked = CB_KeepOODA.Checked;
		int int_ = CalculateInterruptibleRegistry();
		TextBox1.Text = "开始迁移... \r\n\r\n";
		DarkUITextBox textBox;
		(textBox = TextBox1).Text = textBox.Text + "将当前想定的副本保存到[" + GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + Client.CurrentScenario.FileName + ".OLD]... ";
		TextBox1.Update();
		if (@checked)
		{
			CompareInterruptibleRegistry(Client.CurrentScenario);
		}
		CreateInterruptibleRegistry(Client.CurrentScenario, int_);
		Client.SaveCurrentScenario(bool_0: true, GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + Client.CurrentScenario.FileName + ".OLD");
		if (@checked)
		{
			TextBox1.Text += "Original OODA values preserved... ";
		}
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Text += "Switching DB version to selected... ";
		TextBox1.Update();
		Client.IncludeConfiguration(TargetDB.Hash);
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Text += "自动保存...";
		TextBox1.Update();
		LoadSave.SaveScenario(Client.CurrentScenario, Client.CurrentScenario.Sides_ReadOnly[0], GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen", bool_0: false);
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Text += "重新加载迁移的想定......";
		TextBox1.Update();
		Scenario scenario_ = Client.CurrentScenario;
		GameGeneral.DestroyPreviousScenario(ref scenario_, bool_1: false);
		scenario_ = null;
		ScenContainer scenContainer = ScenContainer.LoadFromFile(GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen");
		string string_ = "";
		Scenario scenarioObject = scenContainer.GetScenarioObject(ref string_, null, CB_DeepRebuild.Checked);
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Update();
		string text;
		if (CB_ApplyINI.Checked)
		{
			TextBox1.Text += "选择INI配置文件...";
			TextBox1.Update();
			PatchInterruptibleDefinition(new OpenFileDialog());
			ComputeInterruptibleDefinition().InitialDirectory = scenarioObject.FileNamePath;
			ComputeInterruptibleDefinition().FileName = "*.ini";
			DialogResult dialogResult = ComputeInterruptibleDefinition().ShowDialog(this);
			switch (dialogResult)
			{
			case DialogResult.Cancel:
				TextBox1.Text += "被用户取消.\r\n\r\n";
				break;
			default:
				(textBox = TextBox1).Text = textBox.Text + "失败 (" + dialogResult.ToString() + ")\r\n\r\n";
				break;
			case DialogResult.OK:
			{
				TextBox1.Text += "Done.\r\n\r\n";
				(textBox = TextBox1).Text = textBox.Text + "应用INI配置从" + ComputeInterruptibleDefinition().FileName + "]... ";
				TextBox1.Update();
				if (!Directory.Exists(GameGeneral.LogsPath))
				{
					Directory.CreateDirectory(GameGeneral.LogsPath);
				}
				text = "\r\n\r\n想定 : " + scenarioObject.Title + "\r\nConfig file: " + ComputeInterruptibleDefinition().FileName;
				StreamWriter streamWriter = File.AppendText(Path.Combine(GameGeneral.SBRLogFilePath));
				streamWriter.Write("\r\n\r\n" + text);
				streamWriter.Close();
				SBR.ApplyScriptToScenario(scenarioObject, ComputeInterruptibleDefinition().FileName, bool_0: false);
				text = "想定" + scenarioObject.Title + "：重建完成";
				StreamWriter streamWriter2 = File.AppendText(Path.Combine(GameGeneral.SBRLogFilePath));
				streamWriter2.Write("\r\n" + text);
				streamWriter2.Close();
				LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen", bool_0: true);
				scenario_ = Client.CurrentScenario;
				GameGeneral.DestroyPreviousScenario(ref scenario_, bool_1: false);
				scenario_ = null;
				ScenContainer scenContainer2 = ScenContainer.LoadFromFile(GameGeneral.ScenariosRootPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR.scen");
				string_ = "";
				scenarioObject = scenContainer2.GetScenarioObject(ref string_, null, bool_0: false);
				TextBox1.Text += "Done.\r\n\r\n";
				break;
			}
			}
			TextBox1.Update();
		}
		TextBox1.Text += "验证更新... ";
		TextBox1.Update();
		text = "\r\n\r\n想定 : " + scenarioObject.Title;
		StreamWriter streamWriter3 = File.AppendText(Path.Combine(GameGeneral.LogsPath, "SBR plaform list.txt"));
		streamWriter3.Write("\r\n\r\n" + text);
		streamWriter3.Close();
		SBR.GenerateScenarioContentsList(scenarioObject);
		foreach (ActiveUnit activeUnits_ in scenarioObject.ActiveUnits_List)
		{
			activeUnits_?.Sensory.vmethod_0(activeUnits_.Sensors_Cached);
		}
		text = "想定" + scenarioObject.Title + "：重建完成";
		StreamWriter streamWriter4 = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt");
		streamWriter4.Write(text);
		streamWriter4.Close();
		List<string> list = SBR.CheckForAircraftCarryingIllegalLoadouts(scenarioObject);
		if (list.Count > 0)
		{
			text = "想定" + scenarioObject.Title + ": WARNING - ONE OR MORE AIRCRAFT FEATURED IN THIS SCENARIO CARRY A LOADOUT THAT IS NOT IN THE AIRCRAFT'S LOADOUT LIST.\r\n  PLATFORMS ARE AS FOLLOWS:\r\n";
			foreach (string item in list)
			{
				text = text + "  " + item + "\r\n";
			}
			StreamWriter streamWriter5 = File.AppendText(Path.Combine(GameGeneral.LogsPath, "SBR illegal loadouts.txt"));
			streamWriter5.Write("\r\n" + text + "\r\n--------------------------------------------");
			streamWriter5.Close();
			text += "  Please contact the author of this DB in order to have this problem rectified.\r\n";
			DarkMessageBox.ShowWarning(text, "缺少新数据库的平台！");
		}
		List<string> list2 = new List<string>();
		Side[] sides_ReadOnly = scenarioObject.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
		{
			Side side_ = sides_ReadOnly[i];
			if (side_.Missions == null)
			{
				continue;
			}
			foreach (Mission item2 in side_.GetMissionsTotal(scenarioObject))
			{
				Mission mission_ = item2;
				list2.AddRange(scenarioObject.CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref side_, ref mission_));
			}
		}
		if (list2.Count > 0)
		{
			text = "警告！由于任务编队大小限制该想定的某些飞机可能无法起飞！\r\n\r\n您可以修改任务设置（改变任务编队大小、添加更多飞机、更改飞机挂载等）以解决该问题\r\n\r\n";
			foreach (string item3 in list2)
			{
				text = text + "\r\n" + item3;
			}
			DarkMessageBox.ShowWarning(text, "缺少新数据库的平台！");
		}
		TextBox1.Text += "Done.\r\n\r\n";
		TextBox1.Update();
		if (scenarioObject.LoadingNotices.Count > 0)
		{
			TextBox1.Text += "警告:\r\n";
			TextBox1.Text += "--------\r\n";
			foreach (string loadingNotice in Client.CurrentScenario.LoadingNotices)
			{
				(textBox = TextBox1).Text = textBox.Text + loadingNotice + "\r\n";
			}
			TextBox1.Text += "--------\r\n";
			TextBox1.Update();
		}
		scenarioObject.FeatureCompatibility = default(Scenario._FeatureCompatibility);
		Client.SetCurrentScenario(scenarioObject, bool_0: false);
		Client.CurrentGame.Pause();
		(textBox = TextBox1).Text = textBox.Text + "All done! The scenario has been migrated to database version: " + TargetDB.DBName + ". You can now close this window.";
		TextBox1.Update();
	}

	private void DisableInterruptibleRegistry(object sender, EventArgs e)
	{
		if (Client.CurrentScenario.Sides_ReadOnly.Any())
		{
			string hash = TargetDB.Hash;
			List<string> list = SBR.CheckForPlatFormsMissingFromDB(Client.CurrentScenario, hash, !CB_DeepRebuild.Checked);
			if (list.Count <= 0)
			{
				list.Clear();
				list = null;
				ReadInterruptibleRegistry();
				return;
			}
			string text = "One or more platforms featured in this scenario are missing from the DB you are attempting to migrate to. The missing platforms are as follows:\r\n\r\n";
			foreach (string item in list)
			{
				text = text + item + "\r\n";
			}
			text += "\r\n";
			text += "Please contact the author of this DB in order to have this problem rectified. The platform(s) have been deleted from the new database.\r\n\r\n";
			text += "......迁移中止......";
			DarkMessageBox.ShowError(text, "缺少新数据库的平台！");
		}
		else
		{
			DarkMessageBox.ShowError("该想定必须至少有一方存在！", "无分方");
		}
	}

	private void UpdateInterruptibleRegistry(object sender, EventArgs e)
	{
		bool @checked = CB_KeepOODA.Checked;
		int int_ = CalculateInterruptibleRegistry();
		TextBox1.Text = "选择想定列表文件...";
		Application.DoEvents();
		PatchInterruptibleDefinition(new OpenFileDialog());
		ComputeInterruptibleDefinition().InitialDirectory = GameGeneral.ScenariosRootPath;
		if (ComputeInterruptibleDefinition().ShowDialog() == DialogResult.OK)
		{
			TextBox1.Text += "Done!\r\n\r\n";
			Application.DoEvents();
			DarkUITextBox textBox;
			(textBox = TextBox1).Text = textBox.Text + "开始重建列出的所有想定：" + ComputeInterruptibleDefinition().FileName + "'.\r\n\r\n";
			Application.DoEvents();
			AllInOne(ComputeInterruptibleDefinition().FileName, @checked, int_);
			(textBox = TextBox1).Text = textBox.Text + "重建完成！请检查 '" + GameGeneral.SBRLogFilePath + " for errors.\r\n\r\n";
			Application.DoEvents();
		}
	}

	private void InsertInterruptibleRegistry(object sender, EventArgs e)
	{
		bool @checked = CB_KeepOODA.Checked;
		int int_ = CalculateInterruptibleRegistry();
		TextBox1.Text = "选择想定文件...";
		Application.DoEvents();
		LogoutInterruptibleDefinition(new OpenFileDialog());
		CallInterruptibleDefinition().InitialDirectory = GameGeneral.ScenariosRootPath;
		CallInterruptibleDefinition().Multiselect = true;
		if (CallInterruptibleDefinition().ShowDialog() == DialogResult.OK)
		{
			DarkUITextBox textBox;
			(textBox = TextBox1).Text = textBox.Text + Conversions.ToString(CallInterruptibleDefinition().FileNames.Length) + " files selected\r\n\r\n";
			Application.DoEvents();
			TextBox1.Text += "Starting rebuilding all selected scenarios.\r\n\r\n";
			Application.DoEvents();
			int int_2 = 0;
			string[] fileNames = CallInterruptibleDefinition().FileNames;
			string[] array = fileNames;
			foreach (string text in array)
			{
				string string_ = Path.GetDirectoryName(text) + Conversions.ToString(Path.DirectorySeparatorChar) + Path.GetFileNameWithoutExtension(Path.GetFullPath(text)) + ".ini";
				int_2++;
				PrepareInterruptibleRegistry(text, string_, ref int_2, @checked, int_);
			}
			(textBox = TextBox1).Text = textBox.Text + "重建完成！请检查 '" + GameGeneral.SBRLogFilePath + " for errors.\r\n\r\n";
			Application.DoEvents();
		}
	}

	public static void AllInOne(string string_0, bool bool_0 = false, int int_0 = -101)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			using (fileStream)
			{
				try
				{
					xmlDocument.Load(fileStream);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					DarkMessageBox.ShowError("想定列表文件格式不正确，读取失败！", "Error");
					ProjectData.ClearProjectError();
				}
			}
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/ScenarioList");
			if (xmlNode != null)
			{
				XmlNodeList childNodes = xmlNode.ChildNodes;
				IEnumerator enumerator = null;
				try
				{
					enumerator = childNodes.GetEnumerator();
					IEnumerator enumerator2 = null;
					IEnumerator enumerator3 = null;
					string text = null;
					IEnumerator enumerator4 = null;
					string text2 = null;
					int int_ = 0;
					while (enumerator.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator.Current;
						if (!Client.infoClass)
						{
							try
							{
								try
								{
									enumerator2 = xmlNode2.ChildNodes.GetEnumerator();
									while (enumerator2.MoveNext())
									{
										XmlNode xmlNode3 = (XmlNode)enumerator2.Current;
										string left = xmlNode3.Name.Split('_')[0];
										if (Operators.CompareString(left, "ScenarioFilePath", TextCompare: true) == 0)
										{
											try
											{
												try
												{
													enumerator3 = xmlNode3.ChildNodes.GetEnumerator();
													while (enumerator3.MoveNext())
													{
														XmlNode xmlNode4 = (XmlNode)enumerator3.Current;
														if (Operators.CompareString(xmlNode4.Name.Split('_')[0], "#comment", TextCompare: true) == 0)
														{
															text = xmlNode4.InnerText;
															text = text.Trim();
															Application.DoEvents();
														}
													}
												}
												finally
												{
													if (enumerator3 is IDisposable)
													{
														(enumerator3 as IDisposable).Dispose();
													}
												}
											}
											catch (Exception projectError2)
											{
												ProjectData.SetProjectError(projectError2);
												DarkMessageBox.ShowError("找不到想定文件路径。", "Error");
												ProjectData.ClearProjectError();
											}
										}
										else
										{
											if (Operators.CompareString(left, "ConfigFilePath", TextCompare: true) != 0)
											{
												continue;
											}
											try
											{
												try
												{
													enumerator4 = xmlNode3.ChildNodes.GetEnumerator();
													while (enumerator4.MoveNext())
													{
														XmlNode xmlNode5 = (XmlNode)enumerator4.Current;
														if (Operators.CompareString(xmlNode5.Name.Split('_')[0], "#comment", TextCompare: true) == 0)
														{
															text2 = xmlNode5.InnerText;
															text2 = text2.Trim();
														}
													}
												}
												finally
												{
													if (enumerator4 is IDisposable)
													{
														(enumerator4 as IDisposable).Dispose();
													}
												}
											}
											catch (Exception projectError3)
											{
												ProjectData.SetProjectError(projectError3);
												DarkMessageBox.ShowError("找不到配置文件路径。", "Error");
												ProjectData.ClearProjectError();
											}
										}
									}
								}
								finally
								{
									if (enumerator2 is IDisposable)
									{
										(enumerator2 as IDisposable).Dispose();
									}
								}
								int_++;
								PrepareInterruptibleRegistry(text, text2, ref int_, bool_0, int_0);
							}
							catch (Exception projectError4)
							{
								ProjectData.SetProjectError(projectError4);
								string text3 = "想定" + Conversions.ToString(int_) + "：错误：加载失败！";
								File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text3);
								ProjectData.ClearProjectError();
							}
							continue;
						}
						File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\nSCENARIO MIGRATION TERMINATED DUE TO APP SHUTDOWN.");
						break;
					}
					return;
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			DarkMessageBox.ShowError("找不到XML数据。", "Error");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101120", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static void PrepareInterruptibleRegistry(string string_0, string string_1, ref int int_0, bool bool_0 = false, int int_1 = -101)
	{
		if (FileExistsNative.FileExistsFast(string_0))
		{
			ScenContainer scenContainer = ScenContainer.LoadFromFile(string_0);
			string string_2 = "";
			Scenario scenarioObject = scenContainer.GetScenarioObject(ref string_2, null, bool_0: false);
			if (bool_0)
			{
				CompareInterruptibleRegistry(scenarioObject);
			}
			CreateInterruptibleRegistry(scenarioObject, int_1);
			string text = "想定" + Conversions.ToString(int_0) + ": " + scenarioObject.Title + "\r\nScenario file: " + string_0 + "\r\nConfig file:   " + string_1;
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
			File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", "\r\n\r\n" + text);
			DBOps.DBFileCheckResult dbfileCheckResult_ = DBOps.DBFileCheckResult.Undefined;
			DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(scenarioObject.DBUsed, ref dbfileCheckResult_);
			if (Information.IsNothing(dBRecordByHash))
			{
				Interaction.MsgBox("错误：" + DBOps.PublishImporter(dbfileCheckResult_) + "\r\nAborting...");
				return;
			}
			_ = scenarioObject.DBUsed;
			string text4 = (scenarioObject.DBUsed = DBOps.GetHashForMostRecentVersionOfThisDB(dBRecordByHash.DBID));
			string text2 = text4;
			string string_3 = text2;
			List<string> list = SBR.CheckForPlatFormsMissingFromDB(scenarioObject, string_3, bool_0: false);
			if (list.Count <= 0)
			{
				scenarioObject.LastSavedInScenEdit = true;
				LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], string_0, bool_0: true);
				Scenario scenario_ = scenarioObject;
				if (!Information.IsNothing(scenario_))
				{
					GameGeneral.DestroyPreviousScenario(ref scenario_, bool_1: false);
				}
				scenarioObject = null;
				scenario_ = null;
				ScenContainer scenContainer2 = ScenContainer.LoadFromFile(string_0);
				string_2 = "";
				scenarioObject = scenContainer2.GetScenarioObject(ref string_2, null, bool_0: true);
				List<string> list2 = SBR.CheckForAircraftCarryingIllegalLoadouts(scenarioObject);
				if (list2.Count > 0)
				{
					text = "  错误：一个或多个飞机的指定挂载不在飞机的可用挂载列表中\r\n 这些飞机包括：\r\n";
					foreach (string item in list2)
					{
						text = text + "  " + item + "\r\n";
					}
					text += "请联系此数据库的作者以解决此问题。";
					File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
				}
				List<string> list3 = new List<string>();
				Side[] sides_ReadOnly = scenarioObject.Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
				{
					Side side_ = sides_ReadOnly[i];
					if (Information.IsNothing(side_.Missions))
					{
						continue;
					}
					foreach (Mission item2 in side_.GetMissionsTotal(scenarioObject))
					{
						Mission mission_ = item2;
						list3.AddRange(scenarioObject.CheckForAircraftNotTakingOffDueToFlightSizeRestrictions(ref side_, ref mission_));
					}
				}
				if (list3.Count > 0)
				{
					text = "  警告！由于任务编队大小限制该想定的某些飞机可能无法起飞！\r\n\r\n您可以修改任务设置（改变任务编队大小、添加更多飞机、更改飞机挂载等）以解决该问题\r\n\r\n";
					foreach (string item3 in list3)
					{
						text = text + "\r\n    " + item3;
					}
					File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
				}
				text = "";
				Client.ValidateScenarioAreas(scenarioObject, bool_0: true, ref text);
				if (!string.IsNullOrEmpty(text))
				{
					text = "  ERROR: SOME AREAS IN THIS SCENARIO HAS PROBLEMS!\r\n" + text;
					File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
				}
				if (FileExistsNative.FileExistsFast(string_1))
				{
					SBR.ApplyScriptToScenario(scenarioObject, string_1, bool_0: false);
				}
				SBR.GenerateScenarioContentsList(scenarioObject);
				foreach (ActiveUnit activeUnits_ in scenarioObject.ActiveUnits_List)
				{
					if (!Information.IsNothing(activeUnits_))
					{
						activeUnits_.Sensory.vmethod_0(activeUnits_.Sensors_Cached);
					}
				}
				scenarioObject.LastSavedInScenEdit = true;
				LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], string_0, bool_0: true);
				text = "想定" + Conversions.ToString(int_0) + "：重建完成";
				File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n" + text);
				File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", text);
				return;
			}
			text = "  ERROR: ONE OR MORE PLATFORMS FEATURED IN THIS SCENARIO IS MISSING FROM THE DATABASE YOU ARE ATTEMPTING TO MIGRATE TO.\r\n  THE MISSING PLATFORMS ARE AS FOLLOWS:\r\n";
			foreach (string item4 in list)
			{
				text = text + "  " + item4 + "\r\n";
			}
			text += "  Please contact the author of this DB in order to have this problem rectified. The unit(s) have to be deleted and replaced with units that actually exist in the database.\r\n";
			text += "迁移中止！";
			File.AppendAllText(GameGeneral.SBRLogFilePath, text);
			text = "想定" + Conversions.ToString(int_0) + "：错误：重建失败！";
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text);
		}
		else
		{
			string text3 = "想定" + Conversions.ToString(int_0) + "：错误：未找到文件！";
			File.AppendAllText(GameGeneral.SBRLogFilePath, "\r\n\r\n" + text3);
			File.AppendAllText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "SBR plaform list.txt", "\r\n\r\n" + text3);
		}
	}

	private void ReflectInterruptibleRegistry(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode != Keys.Space || !base.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void VisitInterruptibleRegistry(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
