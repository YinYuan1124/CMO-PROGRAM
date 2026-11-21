using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Losses : DarkSecondaryFormBase
{
	public enum DecoyRetrieval
	{
		All,
		DecoyOnly,
		NotDecoy
	}

	[CompilerGenerated]
	private sealed class ConnectionMap
	{
		public Scenario Local_theScen;

		public Side Local_theSide;

		internal string CustomizeInterruptibleRules(KeyValuePair<string, HashSet<string>> theKVP)
		{
			return CancelEvent(Local_theScen, theKVP, DecoyRetrieval.All);
		}

		internal string CloneInterruptibleRules(KeyValuePair<int, int> theKVP)
		{
			return Local_theSide.AAR.PublishInterruptibleReg(Local_theScen, theKVP);
		}

		internal string ConnectInterruptibleRules(KeyValuePair<int, int> theKVP)
		{
			return Local_theSide.AAR.PublishInterruptibleReg(Local_theScen, theKVP);
		}
	}

	private IContainer publisherModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox serverModel;

	[AccessedThroughProperty("TS1")]
	[CompilerGenerated]
	private DarkToolStrip m_AdapterModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_ResetAll")]
	private ToolStripButton schemaModel;

	[AccessedThroughProperty("TSMI_ResetScore")]
	[CompilerGenerated]
	private ToolStripButton _UtilsModel;

	[CompilerGenerated]
	[AccessedThroughProperty("txtCSVSeparator")]
	private ToolStripTextBox singletonModel;

	[CompilerGenerated]
	[AccessedThroughProperty("ExportDesignSeparator")]
	private ToolStripSeparator m_RecordModel;

	[AccessedThroughProperty("lblCSVSeparator")]
	[CompilerGenerated]
	private ToolStripLabel exceptionModel;

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return serverModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverModel = value;
		}
	}

	internal DarkToolStrip TS1
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdapterModel = value;
		}
	}

	internal ToolStripButton TSB_ResetAll
	{
		[CompilerGenerated]
		get
		{
			return schemaModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveEvent;
			ToolStripButton toolStripButton = schemaModel;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			schemaModel = value;
			toolStripButton = schemaModel;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSMI_ResetScore
	{
		[CompilerGenerated]
		get
		{
			return _UtilsModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartEvent;
			ToolStripButton utilsModel = _UtilsModel;
			if (utilsModel != null)
			{
				utilsModel.Click -= value2;
			}
			_UtilsModel = value;
			utilsModel = _UtilsModel;
			if (utilsModel != null)
			{
				utilsModel.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TSDD_Export")]
	internal ToolStripDropDownButton TSDD_Export
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripTextBox txtCSVSeparator
	{
		[CompilerGenerated]
		get
		{
			return singletonModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			singletonModel = value;
		}
	}

	internal ToolStripSeparator ExportDesignSeparator
	{
		[CompilerGenerated]
		get
		{
			return m_RecordModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RecordModel = value;
		}
	}

	internal ToolStripLabel lblCSVSeparator
	{
		[CompilerGenerated]
		get
		{
			return exceptionModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exceptionModel = value;
		}
	}

	[field: AccessedThroughProperty("DTSMI_XML")]
	internal DarkToolStripMenuItem DTSMI_XML
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DTSMI_CSV")]
	internal DarkToolStripMenuItem DTSMI_CSV
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Losses()
	{
		base.Load += StopEvent;
		base.KeyDown += PostEvent;
		base.FormClosing += RunEvent;
		TestEvent();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && publisherModel != null)
			{
				publisherModel.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void TestEvent()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(Losses));
		TextBox1 = new DarkUITextBox();
		TS1 = new DarkToolStrip();
		TSB_ResetAll = new ToolStripButton();
		TSMI_ResetScore = new ToolStripButton();
		ExportDesignSeparator = new ToolStripSeparator();
		lblCSVSeparator = new ToolStripLabel();
		txtCSVSeparator = new ToolStripTextBox();
		TSDD_Export = new ToolStripDropDownButton();
		DTSMI_XML = new DarkToolStripMenuItem();
		DTSMI_CSV = new DarkToolStripMenuItem();
		TS1.SuspendLayout();
		SuspendLayout();
		TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(0, 28);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = true;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.Vertical;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(500, 316);
		TextBox1.TabIndex = 0;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TS1.AutoSize = false;
		TS1.BackColor = Color.FromArgb(60, 63, 65);
		TS1.ForeColor = Color.FromArgb(220, 220, 220);
		TS1.GripStyle = ToolStripGripStyle.Hidden;
		TS1.ImageScalingSize = new Size(24, 24);
		TS1.Items.AddRange(new ToolStripItem[6] { TSB_ResetAll, TSMI_ResetScore, ExportDesignSeparator, lblCSVSeparator, txtCSVSeparator, TSDD_Export });
		TS1.Location = new Point(0, 0);
		TS1.Name = "TS1";
		TS1.Padding = new Padding(5, 0, 1, 0);
		TS1.Size = new Size(500, 25);
		TS1.TabIndex = 1;
		TS1.Text = "ToolStrip1";
		TSB_ResetAll.BackColor = Color.FromArgb(60, 63, 65);
		TSB_ResetAll.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_ResetAll.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_ResetAll.Image = componentResourceManager.GetObject("TSB_ResetAll.Image");
		TSB_ResetAll.ImageTransparentColor = Color.Magenta;
		TSB_ResetAll.Name = "TSB_ResetAll";
		TSB_ResetAll.Size = new Size(248, 20);
		TSB_ResetAll.Text = "重置所有战损/消耗";
		TSMI_ResetScore.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_ResetScore.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSMI_ResetScore.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_ResetScore.Image = componentResourceManager.GetObject("TSMI_ResetScore.Image");
		TSMI_ResetScore.ImageTransparentColor = Color.Magenta;
		TSMI_ResetScore.Name = "TSMI_ResetScore";
		TSMI_ResetScore.Size = new Size(179, 20);
		TSMI_ResetScore.Text = "重置所有分方得分";
		ExportDesignSeparator.BackColor = Color.FromArgb(60, 63, 65);
		ExportDesignSeparator.ForeColor = Color.FromArgb(220, 220, 220);
		ExportDesignSeparator.Margin = new Padding(0, 0, 2, 0);
		ExportDesignSeparator.Name = "ExportDesignSeparator";
		ExportDesignSeparator.Size = new Size(6, 25);
		lblCSVSeparator.BackColor = Color.FromArgb(60, 63, 65);
		lblCSVSeparator.ForeColor = Color.FromArgb(220, 220, 220);
		lblCSVSeparator.Name = "lblCSVSeparator";
		lblCSVSeparator.Size = new Size(126, 25);
		lblCSVSeparator.Text = "CSV Separator";
		txtCSVSeparator.BackColor = Color.FromArgb(60, 63, 65);
		txtCSVSeparator.ForeColor = Color.FromArgb(220, 220, 220);
		txtCSVSeparator.MaxLength = 1;
		txtCSVSeparator.Name = "txtCSVSeparator";
		txtCSVSeparator.Size = new Size(25, 31);
		txtCSVSeparator.Text = ",";
		TSDD_Export.BackColor = Color.FromArgb(60, 63, 65);
		TSDD_Export.DropDownItems.AddRange(new ToolStripItem[2] { DTSMI_XML, DTSMI_CSV });
		TSDD_Export.ForeColor = Color.FromArgb(220, 220, 220);
		TSDD_Export.Name = "TSDD_Export";
		TSDD_Export.Size = new Size(81, 29);
		TSDD_Export.Text = "导出";
		DTSMI_XML.BackColor = Color.FromArgb(60, 63, 65);
		DTSMI_XML.ForeColor = Color.FromArgb(220, 220, 220);
		DTSMI_XML.Name = "DTSMI_XML";
		DTSMI_XML.Size = new Size(169, 34);
		DTSMI_XML.Text = "To Xml";
		DTSMI_CSV.BackColor = Color.FromArgb(60, 63, 65);
		DTSMI_CSV.ForeColor = Color.FromArgb(220, 220, 220);
		DTSMI_CSV.Name = "DTSMI_CSV";
		DTSMI_CSV.Size = new Size(169, 34);
		DTSMI_CSV.Text = "To CSV";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(500, 344);
		base.Controls.Add(TS1);
		base.Controls.Add(TextBox1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Losses";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "损失和消耗";
		TS1.ResumeLayout(performLayout: false);
		TS1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void StopEvent(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Client.CurrentGame.GameMode != Game._GameMode.MultiplayerScenEdit)
		{
			TS1.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
			TextBox1.Text = string.Empty;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array = sides_ReadOnly;
			foreach (Side side_ in array)
			{
				ListEvent(side_);
			}
		}
		TSDD_Export.Visible = false;
		TSDD_Export.Enabled = false;
		DTSMI_XML.Visible = false;
		DTSMI_XML.Enabled = false;
		DTSMI_CSV.Visible = false;
		DTSMI_CSV.Enabled = false;
		txtCSVSeparator.Visible = false;
		txtCSVSeparator.Enabled = false;
		lblCSVSeparator.Visible = false;
		lblCSVSeparator.Enabled = false;
		ExportDesignSeparator.Visible = false;
		ExportDesignSeparator.Enabled = false;
	}

	private static string CancelEvent(Scenario scenario_0, KeyValuePair<string, HashSet<string>> keyValuePair_0, DecoyRetrieval decoyRetrieval_0)
	{
		string[] array = keyValuePair_0.Key.ToString().Split('_');
		string text = "";
		string text2 = "";
		bool flag = false;
		if (Conversions.ToDouble(array[1]) < 0.0)
		{
			array[1] = (Conversions.ToInteger(array[1]) * -1).ToString();
			flag = true;
			if (decoyRetrieval_0 == DecoyRetrieval.NotDecoy)
			{
				goto IL_02c3;
			}
			text2 = "[DECOY] ";
		}
		if (flag || decoyRetrieval_0 != DecoyRetrieval.DecoyOnly)
		{
			string left = array[0].ToString();
			if (Operators.CompareString(left, "Aircraft", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(scenario_0.Cache_Aircraft_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Ship", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(scenario_0.Cache_Ships_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Submarine", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(scenario_0.Cache_Subs_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Facility", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(scenario_0.Cache_Facilities_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "Weapon", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(scenario_0.Cache_Weapons_DT.Select("ID=" + array[1])[0]["Name"].ToString());
			}
			else if (Operators.CompareString(left, "GroundUnit", TextCompare: true) == 0)
			{
				text = Misc.ReadRequest(scenario_0.Cache_GroundUnits_DT.Select("ID=" + array[1])[0]["Name"].ToString());
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
			return text2 + text;
		}
		goto IL_02c3;
		IL_02c3:
		return null;
	}

	private static string VerifyEvent(Scenario scenario_0, KeyValuePair<int, int> keyValuePair_0)
	{
		return Misc.ReadRequest(scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(keyValuePair_0.Key))[0]["Name"].ToString());
	}

	private void ListEvent(Side side_0)
	{
		TextBox1.Text += SideLosses_AsString(side_0, Client.CurrentScenario);
	}

	public static string SideLosses_AsString(Side side_0, Scenario scenario_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("分方：" + side_0.Name + "\r\n===========================================================\r\n\r\n");
		stringBuilder.Append("战损:\r\n-------------------------------\r\n");
		List<KeyValuePair<string, HashSet<string>>> list = side_0.AAR.Losses.OrderBy((KeyValuePair<string, HashSet<string>> theKVP) => CancelEvent(scenario_0, theKVP, DecoyRetrieval.All)).ToList();
		foreach (KeyValuePair<string, HashSet<string>> item in list)
		{
			string text = CancelEvent(scenario_0, item, DecoyRetrieval.NotDecoy);
			if (text != null && Operators.CompareString(text, "", TextCompare: true) != 0)
			{
				stringBuilder.Append(Conversions.ToString(item.Value.Count) + "x " + text + "\r\n");
			}
		}
		stringBuilder.Append("\r\n\r\n");
		stringBuilder.Append("诱饵单元:\r\n-------------------------------\r\n");
		foreach (KeyValuePair<string, HashSet<string>> item2 in list)
		{
			string text2 = CancelEvent(scenario_0, item2, DecoyRetrieval.DecoyOnly);
			if (text2 != null && Operators.CompareString(text2, "", TextCompare: true) != 0)
			{
				stringBuilder.Append(Conversions.ToString(item2.Value.Count) + "x " + text2 + "\r\n");
			}
		}
		stringBuilder.Append("\r\n\r\n消耗:\r\n------------------\r\n");
		foreach (KeyValuePair<int, int> item3 in side_0.AAR.Expenditures.OrderBy((KeyValuePair<int, int> theKVP) => side_0.AAR.PublishInterruptibleReg(scenario_0, theKVP)).ToList())
		{
			stringBuilder.Append(item3.Value + "x " + side_0.AAR.PublishInterruptibleReg(scenario_0, item3) + "\r\n");
		}
		stringBuilder.Append("\r\n武器/弹仓 损失:\r\n-----------------------------\r\n");
		foreach (KeyValuePair<int, int> item4 in side_0.AAR.WeaponsLost.OrderBy((KeyValuePair<int, int> theKVP) => side_0.AAR.PublishInterruptibleReg(scenario_0, theKVP)).ToList())
		{
			string text3 = side_0.AAR.PublishInterruptibleReg(scenario_0, item4);
			if (!string.IsNullOrEmpty(text3))
			{
				stringBuilder.Append(item4.Value + "x " + text3 + "\r\n");
			}
		}
		stringBuilder.Append("\r\n\r\n\r\n");
		return stringBuilder.ToString();
	}

	private void ResolveEvent(object sender, EventArgs e)
	{
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side obj in array)
		{
			obj.AAR.Losses.Clear();
			obj.AAR.Expenditures.Clear();
			obj.AAR.WeaponsLost.Clear();
		}
		TextBox1.Text = string.Empty;
		sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array2 = sides_ReadOnly;
		foreach (Side side_ in array2)
		{
			ListEvent(side_);
		}
	}

	private void PostEvent(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.End && e.KeyCode != Keys.Home && (e.KeyCode != Keys.C || e.Modifiers != Keys.Control) && (e.KeyCode != Keys.X || e.Modifiers != Keys.Control) && (e.KeyCode != Keys.V || e.Modifiers != Keys.Control)))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void RunEvent(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void StartEvent(object sender, EventArgs e)
	{
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side obj in array)
		{
			obj.SetTotalScore(Client.CurrentScenario, null, 0);
			obj.ScoringLog.Clear();
		}
		DarkMessageBox.ShowInformation("所有分方的得分点已重置为0。", "");
	}
}
