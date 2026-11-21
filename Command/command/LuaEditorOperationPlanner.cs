using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using NLua.Exceptions;

namespace Command;

[DesignerGenerated]
public class LuaEditorOperationPlanner : Form
{
	[DoNotPruneType]
	[DoNotPrune]
	[DoNotObfuscateType]
	private class LuaTemplateItem
	{
		public string _ContextMap;

		public string m_StatusMap;

		public string Label => m_StatusMap;

		public string Content => _ContextMap;

		public LuaTemplateItem(string string_0, string string_1)
		{
			_ContextMap = string_0;
			m_StatusMap = string_1;
		}
	}

	private IContainer m_AnnotationModel;

	[AccessedThroughProperty("RichTextBox1")]
	[CompilerGenerated]
	private RichTextBox m_IteratorModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TBScriptPanel")]
	private RichTextBox initializerModel;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirmScript")]
	private DarkUIButton roleModel;

	[AccessedThroughProperty("TBError")]
	[CompilerGenerated]
	private RichTextBox m_AttributeModel;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel1")]
	private DarkLabel eventModel;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonDeleteScript")]
	private DarkUIButton m_AccountModel;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_LuaTemplate")]
	private DarkUIComboBox authenticationModel;

	public List<string> Errors;

	public string TheScript;

	public string TheDescription;

	internal virtual RichTextBox RichTextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IteratorModel = value;
		}
	}

	internal virtual RichTextBox TBScriptPanel
	{
		[CompilerGenerated]
		get
		{
			return initializerModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			initializerModel = value;
		}
	}

	internal virtual DarkUIButton ButtonConfirmScript
	{
		[CompilerGenerated]
		get
		{
			return roleModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintGlobal;
			DarkUIButton darkUIButton = roleModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			roleModel = value;
			darkUIButton = roleModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TBDescription")]
	internal virtual DarkUITextBox TBDescription
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual RichTextBox TBError
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeModel = value;
		}
	}

	internal virtual DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return eventModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eventModel = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ButtonDeleteScript
	{
		[CompilerGenerated]
		get
		{
			return m_AccountModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishGlobal;
			DarkUIButton accountModel = m_AccountModel;
			if (accountModel != null)
			{
				accountModel.Click -= value2;
			}
			m_AccountModel = value;
			accountModel = m_AccountModel;
			if (accountModel != null)
			{
				accountModel.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIComboBox ComboBox_LuaTemplate
	{
		[CompilerGenerated]
		get
		{
			return authenticationModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeGlobal;
			DarkUIComboBox darkUIComboBox = authenticationModel;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectedIndexChanged -= value2;
			}
			authenticationModel = value;
			darkUIComboBox = authenticationModel;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectedIndexChanged += value2;
			}
		}
	}

	public LuaEditorOperationPlanner()
	{
		base.Load += DefineGlobal;
		Errors = new List<string>();
		TheScript = "";
		TheDescription = "";
		AssetGlobal();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_AnnotationModel != null)
			{
				m_AnnotationModel.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AssetGlobal()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(LuaEditorOperationPlanner));
		RichTextBox1 = new RichTextBox();
		TBScriptPanel = new RichTextBox();
		TBError = new RichTextBox();
		DarkLabel1 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		TBDescription = new DarkUITextBox();
		ButtonConfirmScript = new DarkUIButton();
		ButtonDeleteScript = new DarkUIButton();
		DarkLabel4 = new DarkLabel();
		ComboBox_LuaTemplate = new DarkUIComboBox();
		SuspendLayout();
		RichTextBox1.BackColor = Color.FromArgb(40, 40, 40);
		RichTextBox1.ForeColor = SystemColors.Info;
		RichTextBox1.Location = new Point(12, 28);
		RichTextBox1.Name = "RichTextBox1";
		RichTextBox1.ReadOnly = true;
		RichTextBox1.Size = new Size(323, 143);
		RichTextBox1.TabIndex = 0;
		RichTextBox1.Text = componentResourceManager.GetString("RichTextBox1.Text");
		TBScriptPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TBScriptPanel.BackColor = Color.FromArgb(80, 83, 85);
		TBScriptPanel.ForeColor = SystemColors.Menu;
		TBScriptPanel.Location = new Point(12, 201);
		TBScriptPanel.Name = "TBScriptPanel";
		TBScriptPanel.Size = new Size(629, 258);
		TBScriptPanel.TabIndex = 1;
		TBScriptPanel.Text = "";
		TBError.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TBError.BackColor = Color.FromArgb(40, 40, 40);
		TBError.ForeColor = Color.FromArgb(255, 128, 128);
		TBError.Location = new Point(341, 28);
		TBError.Name = "TBError";
		TBError.ReadOnly = true;
		TBError.Size = new Size(300, 167);
		TBError.TabIndex = 41;
		TBError.Text = "";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(12, 9);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(72, 13);
		DarkLabel1.TabIndex = 42;
		DarkLabel1.Text = "向导";
		DarkLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(338, 9);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(53, 13);
		DarkLabel2.TabIndex = 43;
		DarkLabel2.Text = "错误";
		DarkLabel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(12, 469);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(66, 13);
		DarkLabel3.TabIndex = 44;
		DarkLabel3.Text = "描述：";
		TBDescription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBDescription.AutoCompleteCustomSource = null;
		TBDescription.AutoCompleteMode = AutoCompleteMode.None;
		TBDescription.AutoCompleteSource = AutoCompleteSource.None;
		TBDescription.BackColor = Color.Transparent;
		TBDescription.ForeColor = Color.FromArgb(189, 189, 189);
		TBDescription.Image = null;
		TBDescription.Lines = null;
		TBDescription.Location = new Point(84, 465);
		TBDescription.MaxLength = 25;
		TBDescription.Multiline = false;
		TBDescription.Name = "TBDescription";
		TBDescription.ReadOnly = false;
		TBDescription.ScrollBars = ScrollBars.None;
		TBDescription.SelectionStart = 0;
		TBDescription.Size = new Size(267, 24);
		TBDescription.TabIndex = 40;
		TBDescription.TextAlign = HorizontalAlignment.Left;
		TBDescription.UseSystemPasswordChar = false;
		TBDescription.WatermarkText = "Enter a short description of your script (25 char MAX)";
		ButtonConfirmScript.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonConfirmScript.BackColor = Color.Transparent;
		ButtonConfirmScript.DialogResult = DialogResult.None;
		ButtonConfirmScript.ForeColor = SystemColors.Control;
		ButtonConfirmScript.Location = new Point(520, 465);
		ButtonConfirmScript.Name = "ButtonConfirmScript";
		ButtonConfirmScript.RoundRadius = 0;
		ButtonConfirmScript.Size = new Size(120, 24);
		ButtonConfirmScript.TabIndex = 39;
		ButtonConfirmScript.Text = "确认脚本";
		ButtonDeleteScript.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonDeleteScript.BackColor = Color.Transparent;
		ButtonDeleteScript.DialogResult = DialogResult.None;
		ButtonDeleteScript.ForeColor = SystemColors.Control;
		ButtonDeleteScript.Location = new Point(394, 465);
		ButtonDeleteScript.Name = "ButtonDeleteScript";
		ButtonDeleteScript.RoundRadius = 0;
		ButtonDeleteScript.Size = new Size(120, 24);
		ButtonDeleteScript.TabIndex = 45;
		ButtonDeleteScript.Text = "删除脚本";
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(12, 180);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(65, 13);
		DarkLabel4.TabIndex = 46;
		DarkLabel4.Text = "模板：";
		ComboBox_LuaTemplate.BackColor = Color.Transparent;
		ComboBox_LuaTemplate.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_LuaTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_LuaTemplate.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_LuaTemplate.FormattingEnabled = true;
		ComboBox_LuaTemplate.Location = new Point(83, 176);
		ComboBox_LuaTemplate.Name = "ComboBox_LuaTemplate";
		ComboBox_LuaTemplate.Size = new Size(251, 21);
		ComboBox_LuaTemplate.TabIndex = 47;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(653, 498);
		base.Controls.Add(ComboBox_LuaTemplate);
		base.Controls.Add(DarkLabel4);
		base.Controls.Add(ButtonDeleteScript);
		base.Controls.Add(DarkLabel3);
		base.Controls.Add(DarkLabel2);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(TBError);
		base.Controls.Add(TBDescription);
		base.Controls.Add(ButtonConfirmScript);
		base.Controls.Add(TBScriptPanel);
		base.Controls.Add(RichTextBox1);
		MinimumSize = new Size(560, 400);
		base.Name = "LuaEditorOperationPlanner";
		base.ShowIcon = false;
		Text = "Lua编辑器";
		base.TopMost = true;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PrintGlobal(object sender, EventArgs e)
	{
		TheDescription = TBDescription.Text;
		TheScript = TBScriptPanel.Text;
		if (!CheckLuaScriptForErrors())
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	public bool CheckLuaScriptForErrors()
	{
		Errors = new List<string>();
		if (string.IsNullOrEmpty(TBDescription.Text))
		{
			Errors.Add("Your script has no description.");
		}
		if (string.IsNullOrEmpty(TBScriptPanel.Text))
		{
			Errors.Add("Your script is empty");
		}
		else
		{
			object[] array = Client.CurrentScenario.Scenario_LuaSandbox.RunScript(TBScriptPanel.Text, bool_0: true);
			if (array != null && array[0] != null)
			{
				if ((object)array[0].GetType() == typeof(LuaScriptException))
				{
					Errors.Add("错误：" + ((LuaScriptException)array[0]).Message);
				}
				else if ((object)array[0].GetType() != typeof(bool))
				{
					Errors.Add("ERROR: the script in mission start trigger MUST return a boolean");
				}
			}
		}
		DisplayLuaScriptErrors();
		return Errors.Count > 0;
	}

	public void DisplayLuaScriptErrors()
	{
		TBError.Text = "";
		foreach (string error in Errors)
		{
			TBError.Text += error;
			TBError.AppendText(Environment.NewLine);
		}
	}

	private void DefineGlobal(object sender, EventArgs e)
	{
		TBDescription.Text = TheDescription;
		TBScriptPanel.Text = TheScript;
		ComboBox_LuaTemplate.ValueMember = "Content";
		ComboBox_LuaTemplate.DisplayMember = "Label";
		List<LuaTemplateItem> list = new List<LuaTemplateItem>();
		list.Add(new LuaTemplateItem("", "None"));
		list.Add(new LuaTemplateItem("--TEXT BETWEEN # SHOULD BE REPLACED WITH PROPER VALUES " + Environment.NewLine + "    return(ScenEdit_GetMission('#SIDE NAME OR ID#', '#MISSION NAME OR ID#').cargomission.IsFulfilled)", "Cargo Mission Fulfilled"));
		list.Add(new LuaTemplateItem("--TEXT BETWEEN # SHOULD BE REPLACED WITH PROPER VALUES " + Environment.NewLine + "local Unit = ScenEdit_GetUnit({ guid= '#UNIT'S GUID#'})" + Environment.NewLine + "-- or use :  local Unit = ScenEdit_GetUnit({ side='#UNIT'S SIDE#', unitname='#UNIT'S NAME#'})" + Environment.NewLine + "return (Unit == nil or Unit.IsDestroyed)", "Unit(s) destroyed"));
		list.Add(new LuaTemplateItem("--TEXT BETWEEN # SHOULD BE REPLACED WITH PROPER VALUES " + Environment.NewLine + "return ScenEdit_IsUnitInZone('#UNIT NAME OR GUID#','#ZONE NAME OR GUID#','#SIDE NAME OR GUID#')", "Unit in Zone"));
		ComboBox_LuaTemplate.Items.Clear();
		foreach (LuaTemplateItem item in list)
		{
			ComboBox_LuaTemplate.Items.Add(item);
		}
		ComboBox_LuaTemplate.SelectedIndexChanged -= AwakeGlobal;
		ComboBox_LuaTemplate.SelectedIndex = 0;
		ComboBox_LuaTemplate.SelectedIndexChanged += AwakeGlobal;
	}

	private void PublishGlobal(object sender, EventArgs e)
	{
		TheDescription = "";
		TheScript = "";
		base.DialogResult = DialogResult.OK;
	}

	private void AwakeGlobal(object sender, EventArgs e)
	{
		if (DarkMessageBox.ShowInformation("Do you want to replace the current script with a template ?", "Lua Template", DarkDialogButton.YesNo) == DialogResult.Yes || Operators.CompareString(TBScriptPanel.Text, "", TextCompare: true) == 0)
		{
			TBScriptPanel.Text = ((LuaTemplateItem)ComboBox_LuaTemplate.SelectedItem).Content;
		}
		TBScriptPanel.Refresh();
	}
}
