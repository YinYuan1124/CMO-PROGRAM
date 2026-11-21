using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class ExportImportTool : Form
{
	public enum LogType
	{
		Success,
		Info,
		Warning,
		Issue
	}

	private IContainer m_QueueList;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Export")]
	private DarkUIButton m_RegList;

	[AccessedThroughProperty("DarkGroupBox1")]
	[CompilerGenerated]
	private DarkGroupBox m_ParamList;

	[AccessedThroughProperty("FlowLayoutPanel3")]
	[CompilerGenerated]
	private FlowLayoutPanel rulesList;

	[AccessedThroughProperty("CB_Rp")]
	[CompilerGenerated]
	private CheckBox m_MethodList;

	[AccessedThroughProperty("CB_Zones")]
	[CompilerGenerated]
	private CheckBox serviceList;

	[AccessedThroughProperty("CB_Cargo")]
	[CompilerGenerated]
	private CheckBox candidateList;

	[AccessedThroughProperty("OpenFolder")]
	[CompilerGenerated]
	private DarkUIButton _BaseList;

	[AccessedThroughProperty("Panel1")]
	[CompilerGenerated]
	private Panel m_PolicyList;

	[AccessedThroughProperty("CB_Units")]
	[CompilerGenerated]
	private CheckBox broadcasterList;

	[AccessedThroughProperty("CB_Missions")]
	[CompilerGenerated]
	private CheckBox m_IdentifierList;

	[AccessedThroughProperty("CB_Side")]
	[CompilerGenerated]
	private CheckBox m_PrinterList;

	[AccessedThroughProperty("CB_ExclZones")]
	[CompilerGenerated]
	private CheckBox parserList;

	[AccessedThroughProperty("CB_NONAVZones")]
	[CompilerGenerated]
	private CheckBox m_AlgoList;

	[AccessedThroughProperty("CB_EnvZones")]
	[CompilerGenerated]
	private CheckBox databaseList;

	[AccessedThroughProperty("CB_CreateSeparateFiles")]
	[CompilerGenerated]
	private CheckBox m_InterceptorList;

	[AccessedThroughProperty("Button_ImportSerials")]
	[CompilerGenerated]
	private DarkUIButton m_MessageList;

	[AccessedThroughProperty("LV_Log")]
	[CompilerGenerated]
	private DarkListView m_ProductList;

	[AccessedThroughProperty("Button_ImportLandingPlan")]
	[CompilerGenerated]
	private DarkUIButton annotationList;

	internal virtual DarkUIButton Button_Export
	{
		[CompilerGenerated]
		get
		{
			return m_RegList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallSystem;
			DarkUIButton regList = m_RegList;
			if (regList != null)
			{
				regList.Click -= value2;
			}
			m_RegList = value;
			regList = m_RegList;
			if (regList != null)
			{
				regList.Click += value2;
			}
		}
	}

	internal virtual DarkGroupBox DarkGroupBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ParamList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParamList = value;
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual FlowLayoutPanel FlowLayoutPanel3
	{
		[CompilerGenerated]
		get
		{
			return rulesList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rulesList = value;
		}
	}

	internal virtual CheckBox CB_Rp
	{
		[CompilerGenerated]
		get
		{
			return m_MethodList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodList = value;
		}
	}

	internal virtual CheckBox CB_Zones
	{
		[CompilerGenerated]
		get
		{
			return serviceList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serviceList = value;
		}
	}

	[field: AccessedThroughProperty("CB_Serials")]
	internal virtual CheckBox CB_Serials
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CB_Cargo
	{
		[CompilerGenerated]
		get
		{
			return candidateList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			candidateList = value;
		}
	}

	internal virtual DarkUIButton OpenFolder
	{
		[CompilerGenerated]
		get
		{
			return _BaseList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutSystem;
			DarkUIButton baseList = _BaseList;
			if (baseList != null)
			{
				baseList.Click -= value2;
			}
			_BaseList = value;
			baseList = _BaseList;
			if (baseList != null)
			{
				baseList.Click += value2;
			}
		}
	}

	internal virtual Panel Panel1
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PolicyList = value;
		}
	}

	internal virtual CheckBox CB_Units
	{
		[CompilerGenerated]
		get
		{
			return broadcasterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			broadcasterList = value;
		}
	}

	internal virtual CheckBox CB_Missions
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IdentifierList = value;
		}
	}

	internal virtual CheckBox CB_Side
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PrinterList = value;
		}
	}

	internal virtual CheckBox CB_ExclZones
	{
		[CompilerGenerated]
		get
		{
			return parserList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			parserList = value;
		}
	}

	internal virtual CheckBox CB_NONAVZones
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AlgoList = value;
		}
	}

	internal virtual CheckBox CB_EnvZones
	{
		[CompilerGenerated]
		get
		{
			return databaseList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			databaseList = value;
		}
	}

	internal virtual CheckBox CB_CreateSeparateFiles
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorList = value;
		}
	}

	internal virtual DarkUIButton Button_ImportSerials
	{
		[CompilerGenerated]
		get
		{
			return m_MessageList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewSystem;
			DarkUIButton messageList = m_MessageList;
			if (messageList != null)
			{
				messageList.Click -= value2;
			}
			m_MessageList = value;
			messageList = m_MessageList;
			if (messageList != null)
			{
				messageList.Click += value2;
			}
		}
	}

	internal virtual DarkListView LV_Log
	{
		[CompilerGenerated]
		get
		{
			return m_ProductList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProductList = value;
		}
	}

	internal virtual DarkUIButton Button_ImportLandingPlan
	{
		[CompilerGenerated]
		get
		{
			return annotationList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateSystem;
			DarkUIButton darkUIButton = annotationList;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			annotationList = value;
			darkUIButton = annotationList;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public ExportImportTool()
	{
		base.Load += LoginSystem;
		SelectSystem();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_QueueList != null)
			{
				m_QueueList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SelectSystem()
	{
		DarkGroupBox2 = new DarkGroupBox();
		LV_Log = new DarkListView();
		DarkGroupBox1 = new DarkGroupBox();
		CB_CreateSeparateFiles = new CheckBox();
		Panel1 = new Panel();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		CB_Units = new CheckBox();
		CB_Missions = new CheckBox();
		CB_Rp = new CheckBox();
		CB_Zones = new CheckBox();
		CB_ExclZones = new CheckBox();
		CB_NONAVZones = new CheckBox();
		CB_EnvZones = new CheckBox();
		CB_Serials = new CheckBox();
		CB_Cargo = new CheckBox();
		CB_Side = new CheckBox();
		Button_ImportLandingPlan = new DarkUIButton();
		Button_ImportSerials = new DarkUIButton();
		Button_Export = new DarkUIButton();
		OpenFolder = new DarkUIButton();
		DarkGroupBox2.SuspendLayout();
		DarkGroupBox1.SuspendLayout();
		Panel1.SuspendLayout();
		FlowLayoutPanel3.SuspendLayout();
		SuspendLayout();
		DarkGroupBox2.Controls.Add(Button_ImportLandingPlan);
		DarkGroupBox2.Controls.Add(Button_ImportSerials);
		DarkGroupBox2.Controls.Add(LV_Log);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(434, 12);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(416, 260);
		DarkGroupBox2.TabIndex = 2;
		DarkGroupBox2.TabStop = false;
		DarkGroupBox2.Text = "导入";
		LV_Log.BackColor = Color.FromArgb(20, 23, 25);
		LV_Log.Location = new Point(6, 97);
		LV_Log.Name = "LV_Log";
		LV_Log.RelatedInfos = null;
		LV_Log.Size = new Size(401, 154);
		LV_Log.TabIndex = 5;
		LV_Log.Text = "LV_Report";
		DarkGroupBox1.Controls.Add(CB_CreateSeparateFiles);
		DarkGroupBox1.Controls.Add(Panel1);
		DarkGroupBox1.Controls.Add(FlowLayoutPanel3);
		DarkGroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox1.Location = new Point(12, 12);
		DarkGroupBox1.Name = "DarkGroupBox1";
		DarkGroupBox1.Size = new Size(416, 260);
		DarkGroupBox1.TabIndex = 1;
		DarkGroupBox1.TabStop = false;
		DarkGroupBox1.Text = "导出";
		CB_CreateSeparateFiles.AutoSize = true;
		CB_CreateSeparateFiles.Location = new Point(6, 193);
		CB_CreateSeparateFiles.Name = "CB_CreateSeparateFiles";
		CB_CreateSeparateFiles.Size = new Size(132, 17);
		CB_CreateSeparateFiles.TabIndex = 8;
		CB_CreateSeparateFiles.Text = "导出到拆分的文件中";
		CB_CreateSeparateFiles.UseVisualStyleBackColor = true;
		Panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Panel1.BackColor = Color.FromArgb(70, 73, 75);
		Panel1.Controls.Add(Button_Export);
		Panel1.Controls.Add(OpenFolder);
		Panel1.Location = new Point(6, 216);
		Panel1.Name = "Panel1";
		Panel1.Size = new Size(404, 38);
		Panel1.TabIndex = 7;
		FlowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		FlowLayoutPanel3.Controls.Add(CB_Units);
		FlowLayoutPanel3.Controls.Add(CB_Missions);
		FlowLayoutPanel3.Controls.Add(CB_Rp);
		FlowLayoutPanel3.Controls.Add(CB_Zones);
		FlowLayoutPanel3.Controls.Add(CB_ExclZones);
		FlowLayoutPanel3.Controls.Add(CB_NONAVZones);
		FlowLayoutPanel3.Controls.Add(CB_EnvZones);
		FlowLayoutPanel3.Controls.Add(CB_Serials);
		FlowLayoutPanel3.Controls.Add(CB_Cargo);
		FlowLayoutPanel3.Controls.Add(CB_Side);
		FlowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
		FlowLayoutPanel3.Location = new Point(9, 31);
		FlowLayoutPanel3.Name = "FlowLayoutPanel3";
		FlowLayoutPanel3.Size = new Size(398, 141);
		FlowLayoutPanel3.TabIndex = 3;
		CB_Units.AutoSize = true;
		CB_Units.Location = new Point(3, 3);
		CB_Units.Name = "CB_Units";
		CB_Units.Size = new Size(50, 17);
		CB_Units.TabIndex = 2;
		CB_Units.Text = "单元";
		CB_Units.UseVisualStyleBackColor = true;
		CB_Missions.AutoSize = true;
		CB_Missions.Location = new Point(3, 26);
		CB_Missions.Name = "CB_Missions";
		CB_Missions.Size = new Size(66, 17);
		CB_Missions.TabIndex = 3;
		CB_Missions.Text = "任务";
		CB_Missions.UseVisualStyleBackColor = true;
		CB_Rp.AutoSize = true;
		CB_Rp.Location = new Point(3, 49);
		CB_Rp.Name = "CB_Rp";
		CB_Rp.Size = new Size(108, 17);
		CB_Rp.TabIndex = 2;
		CB_Rp.Text = "参考点";
		CB_Rp.UseVisualStyleBackColor = true;
		CB_Zones.AutoSize = true;
		CB_Zones.Location = new Point(3, 72);
		CB_Zones.Name = "CB_Zones";
		CB_Zones.Size = new Size(102, 17);
		CB_Zones.TabIndex = 1;
		CB_Zones.Text = "标准区域";
		CB_Zones.UseVisualStyleBackColor = true;
		CB_ExclZones.AutoSize = true;
		CB_ExclZones.Location = new Point(3, 95);
		CB_ExclZones.Name = "CB_ExclZones";
		CB_ExclZones.Size = new Size(104, 17);
		CB_ExclZones.TabIndex = 5;
		CB_ExclZones.Text = "封锁区";
		CB_ExclZones.UseVisualStyleBackColor = true;
		CB_NONAVZones.AutoSize = true;
		CB_NONAVZones.Location = new Point(3, 118);
		CB_NONAVZones.Name = "CB_NONAVZones";
		CB_NONAVZones.Size = new Size(96, 17);
		CB_NONAVZones.TabIndex = 6;
		CB_NONAVZones.Text = "禁航区域";
		CB_NONAVZones.UseVisualStyleBackColor = true;
		CB_EnvZones.AutoSize = true;
		CB_EnvZones.Location = new Point(117, 3);
		CB_EnvZones.Name = "CB_EnvZones";
		CB_EnvZones.Size = new Size(156, 17);
		CB_EnvZones.TabIndex = 7;
		CB_EnvZones.Text = "自定义环境区域";
		CB_EnvZones.UseVisualStyleBackColor = true;
		CB_Serials.AutoSize = true;
		CB_Serials.Location = new Point(117, 26);
		CB_Serials.Name = "CB_Serials";
		CB_Serials.Size = new Size(57, 17);
		CB_Serials.TabIndex = 1;
		CB_Serials.Text = "货物序列";
		CB_Serials.UseVisualStyleBackColor = true;
		CB_Cargo.AutoSize = true;
		CB_Cargo.Location = new Point(117, 49);
		CB_Cargo.Name = "CB_Cargo";
		CB_Cargo.Size = new Size(54, 17);
		CB_Cargo.TabIndex = 1;
		CB_Cargo.Text = "运输";
		CB_Cargo.UseVisualStyleBackColor = true;
		CB_Side.AutoSize = true;
		CB_Side.Location = new Point(117, 72);
		CB_Side.Name = "CB_Side";
		CB_Side.Size = new Size(52, 17);
		CB_Side.TabIndex = 4;
		CB_Side.Text = "分方";
		CB_Side.UseVisualStyleBackColor = true;
		Button_ImportLandingPlan.BackColor = Color.Transparent;
		Button_ImportLandingPlan.DialogResult = DialogResult.None;
		Button_ImportLandingPlan.ForeColor = SystemColors.Control;
		Button_ImportLandingPlan.Location = new Point(6, 57);
		Button_ImportLandingPlan.Name = "Button_ImportLandingPlan";
		Button_ImportLandingPlan.RoundRadius = 0;
		Button_ImportLandingPlan.Size = new Size(401, 34);
		Button_ImportLandingPlan.TabIndex = 7;
		Button_ImportLandingPlan.Text = "导入着陆计划";
		Button_ImportLandingPlan.Visible = false;
		Button_ImportSerials.BackColor = Color.Transparent;
		Button_ImportSerials.DialogResult = DialogResult.None;
		Button_ImportSerials.ForeColor = SystemColors.Control;
		Button_ImportSerials.Location = new Point(6, 19);
		Button_ImportSerials.Name = "Button_ImportSerials";
		Button_ImportSerials.RoundRadius = 0;
		Button_ImportSerials.Size = new Size(401, 34);
		Button_ImportSerials.TabIndex = 6;
		Button_ImportSerials.Text = "导入货物序列";
		Button_ImportSerials.Visible = false;
		Button_Export.BackColor = Color.Transparent;
		Button_Export.DialogResult = DialogResult.None;
		Button_Export.ForeColor = SystemColors.Control;
		Button_Export.Location = new Point(6, 3);
		Button_Export.Name = "Button_Export";
		Button_Export.RoundRadius = 0;
		Button_Export.Size = new Size(285, 32);
		Button_Export.TabIndex = 0;
		Button_Export.Text = "导出";
		OpenFolder.BackColor = Color.Transparent;
		OpenFolder.DialogResult = DialogResult.None;
		OpenFolder.ForeColor = SystemColors.Control;
		OpenFolder.Location = new Point(315, 3);
		OpenFolder.Name = "OpenFolder";
		OpenFolder.RoundRadius = 0;
		OpenFolder.Size = new Size(86, 32);
		OpenFolder.TabIndex = 6;
		OpenFolder.Text = "打开目录";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(861, 283);
		base.Controls.Add(DarkGroupBox2);
		base.Controls.Add(DarkGroupBox1);
		base.Name = "ExportImportTool";
		Text = "CsvExporter";
		DarkGroupBox2.ResumeLayout(performLayout: false);
		DarkGroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox1.PerformLayout();
		Panel1.ResumeLayout(performLayout: false);
		FlowLayoutPanel3.ResumeLayout(performLayout: false);
		FlowLayoutPanel3.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void CallSystem(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			if (CB_Units.Checked)
			{
				dictionary.Add("Units", CreateExportString_Units());
			}
			if (CB_Missions.Checked)
			{
				dictionary.Add("Missions", CreateExportString_Missions());
			}
			if (CB_Rp.Checked)
			{
				dictionary.Add("参考点", CreateExportString_RP());
			}
			if (CB_Zones.Checked)
			{
				dictionary.Add("标准区域", CreateExportString_StandardZones());
			}
			if (CB_EnvZones.Checked)
			{
				dictionary.Add("Environment Zones", CreateExportString_EnvironmentZone());
			}
			if (CB_NONAVZones.Checked)
			{
				dictionary.Add("NONAV Zones", CreateExportString_NoNavZones());
			}
			if (CB_ExclZones.Checked)
			{
				dictionary.Add("封锁区", CreateExportString_ExclusionZones());
			}
			if (CB_Side.Checked)
			{
				dictionary.Add("Sides", CreateExportString_Sides());
			}
			if (CB_Serials.Checked)
			{
				dictionary.Add("Serials", CreateExportString_Serials());
			}
			if (CB_Cargo.Checked)
			{
				dictionary.Add("Cargo", CreateExportString_Cargo());
			}
			string path = CreateDestinationFolder_ImportExport();
			foreach (KeyValuePair<string, List<string>> item in dictionary)
			{
				if (CB_CreateSeparateFiles.Checked)
				{
					File.WriteAllLines(Path.Combine(path, item.Key + ".csv"), item.Value.ToArray());
				}
				else
				{
					list.AddRange(item.Value);
				}
			}
			File.WriteAllLines(Path.Combine(path, "All_Exports.csv"), list.ToArray());
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Failed to export - ERROR : " + ex2.Message, "Export failure", MessageBoxButtons.OK);
			ProjectData.ClearProjectError();
		}
	}

	public static string CreateDestinationFolder_ImportExport()
	{
		string obj = Path.Combine(GameGeneral.TopLevelWritablePath, "ExportTool");
		Directory.CreateDirectory(obj);
		string path = (string.IsNullOrEmpty(Client.CurrentScenario.Title) ? "Untitled" : Misc.ReplaceIllegalCharacters(Client.CurrentScenario.Title, "_"));
		string text = Path.Combine(obj, path);
		Directory.CreateDirectory(text);
		return Path.Combine(obj, text);
	}

	public static string CreateDestinationFolder_LandingPlanner()
	{
		string obj = Path.Combine(GameGeneral.TopLevelWritablePath, "LandingPlanner");
		Directory.CreateDirectory(obj);
		string path = (string.IsNullOrEmpty(Client.CurrentScenario.Title) ? "Untitled" : Misc.ReplaceIllegalCharacters(Client.CurrentScenario.Title, "_"));
		string text = Path.Combine(obj, path);
		Directory.CreateDirectory(text);
		return Path.Combine(obj, text);
	}

	public List<string> CreateExportString_Units()
	{
		List<string> list = new List<string>();
		list.Add("Units");
		list.Add("GUID;SIDE;NAME;CLASS;TYPE;ASSIGNED MISSIONS;QUEUED TO MISSION;MOTHERSHIP;ASSOCIATED SERIAL");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			Dictionary<ActiveUnit, int> dictionary = new Dictionary<ActiveUnit, int>();
			foreach (Chalk chalk in side.Chalks)
			{
				foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
				{
					if (item.Key.CargoObjectActiveUnit != null)
					{
						dictionary.Add(item.Key.CargoObjectActiveUnit, chalk.Priority);
					}
				}
			}
			foreach (ActiveUnit unit in side.Units)
			{
				List<string> list2 = new List<string>();
				list2.Add(unit.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(unit.Name);
				list2.Add(unit.UnitClass);
				list2.Add(unit.UnitType_String);
				Mission mission = unit.AssignedMissionOrPackage();
				if (mission == null)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(mission.Name + " (" + mission.ObjectID + ")");
				}
				List<string> list3 = new List<string>();
				foreach (Mission value in unit.AssignedMissionsQueue.Values)
				{
					list3.Add(value.Name + " (" + value.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				if (unit.DockingOps.CurrentHostUnit == null)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(unit.DockingOps.CurrentHostUnit.Name + "(" + unit.DockingOps.CurrentHostUnit.ObjectID + ")");
				}
				if (dictionary.ContainsKey(unit))
				{
					list2.Add(dictionary[unit].ToString());
				}
				else
				{
					list2.Add("None");
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Missions()
	{
		List<string> list = new List<string>();
		list.Add("Missions");
		list.Add("GUID;SIDE;NAME;CLASS;ASSIGNED UNITS;QUEUED UNITS;PRIORITY");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (Mission mission in side.Missions)
			{
				List<string> list2 = new List<string>();
				list2.Add(mission.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(mission.Name);
				list2.Add(mission.MissionClass.ToString());
				List<string> list3 = new List<string>();
				foreach (ActiveUnit value in mission.UnitsAssignedToMission.Values)
				{
					list3.Add(value.Name + " (" + value.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				foreach (ActiveUnit value2 in mission.UnitsQueuedToMission.Values)
				{
					list3.Add(value2.Name + " (" + value2.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_RP()
	{
		List<string> list = new List<string>();
		list.Add("参考点");
		list.Add("GUID;SIDE;NAME;LATITUDE;LONGITUDE");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (ReferencePoint refPoint in side.RefPoints)
			{
				List<string> list2 = new List<string>();
				list2.Add(refPoint.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(refPoint.Name);
				list2.Add(refPoint.Latitude.ToString());
				list2.Add(refPoint.Longitude.ToString());
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_StandardZones()
	{
		List<string> list = new List<string>();
		list.Add("标准区域");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (Zone standardZone in side.StandardZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(standardZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(standardZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in standardZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_EnvironmentZone()
	{
		List<string> list = new List<string>();
		list.Add("自定义环境区域");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (CustomEnvironmentZone customEnvironmentZone in side.CustomEnvironmentZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(customEnvironmentZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(customEnvironmentZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in customEnvironmentZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_NoNavZones()
	{
		List<string> list = new List<string>();
		list.Add("禁航区域");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (NoNavZone noNavZone in side.NoNavZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(noNavZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(noNavZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in noNavZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_ExclusionZones()
	{
		List<string> list = new List<string>();
		list.Add("封锁区");
		list.Add("GUID;SIDE;NAME;Reference Points");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (ExclusionZone exclusionZone in side.ExclusionZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(exclusionZone.ObjectID);
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(exclusionZone.Name);
				List<string> list3 = new List<string>();
				foreach (ReferencePoint item in exclusionZone.Area)
				{
					list3.Add(item.Name + " (" + item.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Sides()
	{
		List<string> list = new List<string>();
		list.Add("Sides");
		list.Add("GUID;NAME");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		for (int i = 0; i < sides_ReadOnly.Length; i++)
		{
			foreach (ExclusionZone exclusionZone in sides_ReadOnly[i].ExclusionZones)
			{
				List<string> list2 = new List<string>();
				list2.Add(exclusionZone.ObjectID);
				list2.Add(exclusionZone.Name);
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Serials()
	{
		List<string> list = new List<string>();
		list.Add("Serials");
		list.Add("ID;SIDE;MOTHERSHIP;CARGO");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			foreach (Chalk chalk in side.Chalks)
			{
				List<string> list2 = new List<string>();
				list2.Add(chalk.ID.ToString());
				list2.Add(side.Name + " (" + side.ObjectID + ")");
				list2.Add(chalk.AssociatedMothership.Name + "(" + chalk.AssociatedMothership.ObjectID + ")");
				List<string> list3 = new List<string>();
				foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
				{
					list3.Add(item.Key.CargoObjectName + " (" + item.Key.ObjectID + ")");
				}
				if (list3.Count <= 0)
				{
					list2.Add("None");
				}
				else
				{
					list2.Add(string.Join("|", list3));
				}
				list3.Clear();
				list.Add(string.Join(";", string.Join(";", list2.ToArray())));
			}
		}
		return list;
	}

	public List<string> CreateExportString_Cargo()
	{
		List<string> list = new List<string>();
		list.Add("Cargo");
		list.Add("GUID;SIDE;NAME;PARENT PLATFORM;CARGO SIZE;MASS;AREA;PAX;ASSOCIATED SERIAL");
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			Dictionary<Cargo, int> dictionary = new Dictionary<Cargo, int>();
			foreach (Chalk chalk in side.Chalks)
			{
				foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
				{
					dictionary.Add(item.Key, chalk.ID);
				}
			}
			foreach (ActiveUnit unit in side.Units)
			{
				Cargo[] onboardCargo = unit.OnboardCargo;
				Cargo[] array2 = onboardCargo;
				foreach (Cargo cargo in array2)
				{
					List<string> list2 = new List<string>();
					list2.Add(cargo.ObjectID);
					list2.Add(side.Name + " (" + side.ObjectID + ")");
					list2.Add(cargo.CargoObjectName);
					list2.Add(cargo.ParentPlatform.Name + "(" + cargo.ParentPlatform.ObjectID + ")");
					list2.Add(cargo.RequiredCargoType.ToString());
					list2.Add(cargo.RequiredMass.ToString());
					list2.Add(cargo.RequiredArea.ToString());
					list2.Add(cargo.RequiredCrewSpace.ToString());
					if (dictionary.ContainsKey(cargo))
					{
						list2.Add(dictionary[cargo].ToString());
					}
					else
					{
						list2.Add("None");
					}
					list.Add(string.Join(";", string.Join(";", list2.ToArray())));
				}
			}
		}
		return list;
	}

	private void LogoutSystem(object sender, EventArgs e)
	{
		Process.Start(CreateDestinationFolder_ImportExport());
	}

	private void ViewSystem(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			string expression = new StreamReader(openFileDialog.FileName).ReadToEnd();
			List<Dictionary<SerialColumn_E, string>> list = new List<Dictionary<SerialColumn_E, string>>();
			string[] array = Strings.Split(expression, "\r\n", -1, CompareMethod.Text);
			string[] array3 = array;
			foreach (string text in array3)
			{
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				List<string> list2 = Strings.Split(text, ";", -1, CompareMethod.Text).ToList();
				if (list2.Count >= 4 && Operators.CompareString(list2.ElementAt(0).ToLower(), "#serial", TextCompare: true) == 0)
				{
					list2.RemoveAt(0);
					Dictionary<SerialColumn_E, string> dictionary = new Dictionary<SerialColumn_E, string>();
					int num = list2.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						dictionary.Add((SerialColumn_E)i, list2[i]);
					}
					list.Add(dictionary);
				}
			}
			foreach (Dictionary<SerialColumn_E, string> item in list)
			{
				if (string.IsNullOrEmpty(item[SerialColumn_E.Side]))
				{
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.Side.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
					continue;
				}
				Side side = null;
				try
				{
					side = LuaUtility.QuerySideObject(item[SerialColumn_E.Side], Client.CurrentScenario);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.Side.ToString() + " field (Side not found)", LV_Log, LogType.Issue);
					ProjectData.ClearProjectError();
				}
				if (side == null)
				{
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.Side.ToString() + " field (Side not found)", LV_Log, LogType.Issue);
					continue;
				}
				if (string.IsNullOrEmpty(item[SerialColumn_E.ID]))
				{
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
					continue;
				}
				int result = -1;
				if (int.TryParse(item[SerialColumn_E.ID], out result))
				{
					if (Chalk.ValidateChalkID(result, side))
					{
						if (string.IsNullOrEmpty(item[SerialColumn_E.AssociatedMothership]))
						{
							AddLogEntry("Serial " + item[SerialColumn_E.AssociatedMothership] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
							continue;
						}
						ActiveUnit activeUnit = PrivateMethods.smethod_0(item[SerialColumn_E.AssociatedMothership], Client.CurrentScenario);
						if (activeUnit == null)
						{
							AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.AssociatedMothership.ToString() + " field (mothership not found)", LV_Log, LogType.Issue);
							continue;
						}
						string[] array2 = Strings.Split(item[SerialColumn_E.CargoIDs], "|", -1, CompareMethod.Text);
						List<Cargo> list3 = new List<Cargo>();
						array = array2;
						string[] array4 = array;
						foreach (string text2 in array4)
						{
							if (string.IsNullOrEmpty(text2))
							{
								AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.CargoIDs.ToString() + " field (Empty field)", LV_Log, LogType.Issue);
								continue;
							}
							Cargo cargo = FetchCargoInMotherShip(text2, activeUnit);
							if (cargo == null)
							{
								AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.CargoIDs.ToString() + " field (Cargo #" + text2 + " not found in mothership)", LV_Log, LogType.Issue);
							}
							else
							{
								list3.Add(cargo);
							}
						}
						Chalk chalk = new Chalk(result, activeUnit);
						foreach (Cargo item2 in list3)
						{
							chalk.AddCargo(item2);
						}
						side.Chalks.Add(chalk);
						if (list3.Count == 0)
						{
							AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has no cargo .", LV_Log, LogType.Warning);
						}
						AddLogEntry("Serial " + item[SerialColumn_E.ID] + " was successfully added to mothership " + activeUnit.Name, LV_Log, LogType.Success);
					}
					else
					{
						AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (chalk ID validation issue)", LV_Log, LogType.Issue);
					}
				}
				else
				{
					AddLogEntry("Serial " + item[SerialColumn_E.ID] + " has an issue with the " + SerialColumn_E.ID.ToString() + " field (int parsing failed)", LV_Log, LogType.Issue);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Security error.\\n\\nError message: " + ex2.Message + "\\n\\nDetails:\\n\\n" + ex2.StackTrace);
			ProjectData.ClearProjectError();
		}
	}

	public Cargo FetchCargoInMotherShip(string string_0, ActiveUnit activeUnit_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return null;
		}
		Cargo[] onboardCargo = activeUnit_0.OnboardCargo;
		int num = 0;
		Cargo cargo;
		while (true)
		{
			if (num < onboardCargo.Length)
			{
				cargo = onboardCargo[num];
				if (Operators.CompareString(cargo.ObjectID, string_0, TextCompare: true) == 0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return cargo;
	}

	public static void AddLogEntry(string string_0, DarkListView darkListView_0, LogType logType_0 = LogType.Info)
	{
		if (darkListView_0 != null)
		{
			Color textColor = default(Color);
			switch (logType_0)
			{
			case LogType.Success:
				textColor = Color.Green;
				break;
			case LogType.Info:
				textColor = Color.White;
				break;
			case LogType.Warning:
				textColor = Color.Orange;
				break;
			case LogType.Issue:
				textColor = Color.OrangeRed;
				break;
			}
			DarkListItem darkListItem = new DarkListItem(logType_0.ToString() + ": " + string_0);
			darkListItem.TextColor = textColor;
			darkListView_0.Items.Add(darkListItem);
		}
	}

	public static void ImportLandingPlan(LandingPlanner landingPlanner_0 = null, DarkListView darkListView_0 = null, bool bool_0 = false)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = CreateDestinationFolder_LandingPlanner();
		Export_ImportFeedback export_ImportFeedback = null;
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			if (bool_0 && darkListView_0 == null)
			{
				export_ImportFeedback = new Export_ImportFeedback();
				darkListView_0 = export_ImportFeedback.LV_Main;
			}
			string[] array = Strings.Split(new StreamReader(openFileDialog.FileName).ReadToEnd(), "\r\n", -1, CompareMethod.Text);
			Dictionary<DataObject_E, bool> dictionary = new Dictionary<DataObject_E, bool>();
			dictionary.Add(DataObject_E.mothership, value: true);
			dictionary.Add(DataObject_E.transport, value: true);
			dictionary.Add(DataObject_E.transportClass, value: true);
			dictionary.Add(DataObject_E.zone, value: true);
			dictionary.Add(DataObject_E.serial, value: true);
			LandingPlan_ImportWrapper landingPlan_ImportWrapper = new LandingPlan_ImportWrapper();
			try
			{
				foreach (KeyValuePair<DataObject_E, bool> item in dictionary)
				{
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						Import_ProcessLandingPlanLine(array2[i], landingPlan_ImportWrapper, darkListView_0, item.Key);
					}
				}
				if (!bool_0)
				{
					AddLogEntry("Landing plan was successfully imported : ", darkListView_0, LogType.Success);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				AddLogEntry("Critical issue when importing landing plan " + ex2.Message, darkListView_0, LogType.Issue);
				ProjectData.ClearProjectError();
			}
			landingPlanner_0?.Close();
			LandingPlanner landingPlanner = new LandingPlanner();
			landingPlanner.LandingPlanImport = landingPlan_ImportWrapper;
			landingPlanner.Show();
			if (export_ImportFeedback != null && export_ImportFeedback.LV_Main.Items.Count > 0)
			{
				export_ImportFeedback.ShowDialog();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			AddLogEntry("Issue when loading landing plan : " + ex4.Message, darkListView_0, LogType.Issue);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportLandingPlan_Simplified(LandingPlanner landingPlanner_0, DarkListView darkListView_0 = null, bool bool_0 = false, bool bool_1 = false)
	{
		Export_ImportFeedback export_ImportFeedback = null;
		string text = "";
		try
		{
			if (bool_0 && darkListView_0 == null)
			{
				export_ImportFeedback = new Export_ImportFeedback();
				darkListView_0 = export_ImportFeedback.LV_Main;
			}
			new LandingPlan_ImportWrapper();
			try
			{
				text = text + "sep =;" + Environment.NewLine;
				if (bool_1)
				{
					text = text + "; [NON-EDITABLE];;" + Environment.NewLine;
				}
				text = (bool_1 ? (text + "#Mothership;" + landingPlanner_0.CurrentMothership.Name + ";" + Environment.NewLine) : (text + "#Mothership;" + landingPlanner_0.CurrentMothership.ObjectID + ";" + Environment.NewLine));
				Dictionary<string, Transport> dictionary = new Dictionary<string, Transport>();
				Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
				Dictionary<string, bool> dictionary3 = new Dictionary<string, bool>();
				foreach (ActiveUnit key in landingPlanner_0.TransportList.Keys)
				{
					if (dictionary2.ContainsKey(key.UnitClass))
					{
						dictionary2[key.UnitClass]++;
						continue;
					}
					dictionary2.Add(key.UnitClass, 1);
					dictionary3.Add(key.UnitClass, value: true);
					dictionary.Add(key.UnitClass, landingPlanner_0.TransportList[key]);
				}
				if (bool_1)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + ";Transports;;;" + Environment.NewLine;
					text = text + ";Type [NON-EDITABLE];Amount [NON-EDITABLE];PAX capacity [NON-EDITABLE];Weight capacity (Tons) [NON-EDITABLE];Area capacity (M2) [NON-EDITABLE]; Max type capacity [NON-EDITABLE]" + Environment.NewLine;
				}
				foreach (KeyValuePair<string, Transport> item in dictionary)
				{
					text = text + "#Transport;" + item.Key + ";" + dictionary2[item.Key] + ";" + item.Value.CrewCapacity + ";" + item.Value.MassCapacity + ";" + item.Value.AreaCapacity + ";" + item.Value.MaxSize.ToString() + ";" + Environment.NewLine;
				}
				if (bool_1)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Zones;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Type  [NON-EDITABLE];" + Environment.NewLine;
				}
				foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in landingPlanner_0.AssignedZones)
				{
					if (assignedZone.Value.LandingZoneType != 0)
					{
						text = (bool_1 ? (text + "#Zone;" + assignedZone.Key.LandingZone.Description + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine) : (text + "#Zone;" + assignedZone.Key.LandingZone.ObjectID + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine));
					}
				}
				if (bool_1)
				{
					List<string> list = new List<string>();
					foreach (KeyValuePair<string, int> item2 in dictionary2)
					{
						list.Add("Use " + item2.Key + " (x" + item2.Value + ")");
					}
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Serials;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Priority;Assigned Landing Zone;" + string.Join(";", list) + ";Serial's units & cargo [NON-EDITABLE];PAX [NON-EDITABLE];Weight (Tons) [NON-EDITABLE];Area (M2) [NON-EDITABLE];Cargo Type [NON-EDITABLE]" + Environment.NewLine;
				}
				foreach (KeyValuePair<Chalk, List<UnitLineWrapper>> item3 in landingPlanner_0.ChalkContainer)
				{
					if (item3.Value.Count <= 0 || item3.Value.ElementAt(0).ChalkUnit.LandingZone == null)
					{
						continue;
					}
					Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
					foreach (ActiveUnit key2 in landingPlanner_0.TransportList.Keys)
					{
						dictionary3[key2.UnitClass] = true;
						foreach (UnitLineWrapper item4 in item3.Value)
						{
							if (!item4.ChalkUnit.TransportAvailable.ContainsKey(key2.UnitClass) || item4.ChalkUnit.TransportAvailable[key2.UnitClass] != TransportAvailability.UseTransport)
							{
								dictionary3[key2.UnitClass] = false;
							}
						}
					}
					foreach (KeyValuePair<string, bool> item5 in dictionary3)
					{
						dictionary4.Add(item5.Key, Bool2HumanReadableString(item5.Value));
					}
					string text2 = string.Join(";", dictionary4.Values);
					string text3 = "";
					string text4 = "";
					List<string> list2 = new List<string>();
					foreach (KeyValuePair<Cargo, int> item6 in item3.Key.Cargo)
					{
						list2.Add("(x" + item6.Key.CargoObjectQuantity + ") " + item6.Key.CargoObjectName);
					}
					text4 = text4 + string.Join(", ", list2) + ";";
					text4 = text4 + item3.Key.SelectImporter() + ";" + item3.Key.ComputeImporter() + ";" + item3.Key.PatchImporter() + ";" + item3.Key.DestroyImporter();
					text3 = (bool_1 ? item3.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.Description : item3.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.ObjectID);
					text = ((item3.Key.Preboat == null) ? (text + "#Serial;" + item3.Key.ID + ";" + item3.Value.ElementAt(0).ChalkUnit.Priority + ";" + text3 + ";" + text2 + ";" + text4 + ";" + Environment.NewLine) : (text + "#Serial;" + item3.Key.Preboat.ActualTransport.Name + ";" + item3.Value.ElementAt(0).ChalkUnit.Priority + ";" + text3 + ";" + text2 + ";" + text4 + ";" + Environment.NewLine));
				}
				string text5 = Path.Combine(CreateDestinationFolder_LandingPlanner(), "LandingPlan_" + landingPlanner_0.CurrentMothership.Name);
				string text6 = "csv";
				int num = 0;
				string path = text5 + "." + text6;
				while (File.Exists(path))
				{
					num++;
					path = text5 + " - " + Conversions.ToString(num) + "." + text6;
				}
				File.WriteAllText(path, text);
				if (!bool_0)
				{
					AddLogEntry("Landing plan was successfully exported : ", darkListView_0, LogType.Success);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				AddLogEntry("Critical issue when exporting landing plan " + ex2.Message, darkListView_0, LogType.Issue);
				ProjectData.ClearProjectError();
			}
			if (export_ImportFeedback != null && export_ImportFeedback.LV_Main.Items.Count > 0)
			{
				export_ImportFeedback.ShowDialog();
			}
			DarkMessageBox.ShowInformation("LandingPlan_" + landingPlanner_0.CurrentMothership.Name + " was successfully saved.", "Landing plan saved");
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			AddLogEntry("Issue when loading landing plan : " + ex4.Message, darkListView_0, LogType.Issue);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static string Bool2HumanReadableString(bool bool_0)
	{
		if (bool_0)
		{
			return "yes";
		}
		return "no";
	}

	public static bool HumanReadableString2Bool(string string_0)
	{
		return new string[7] { "yes", "true", "allow", "allowed", "use", "used", "1" }.Contains(string_0.ToLower());
	}

	public static void ExportLandingPlan(LandingPlanner landingPlanner_0, DarkListView darkListView_0 = null, bool bool_0 = false, bool bool_1 = false)
	{
		Export_ImportFeedback export_ImportFeedback = null;
		string text = "";
		try
		{
			if (bool_0 && darkListView_0 == null)
			{
				export_ImportFeedback = new Export_ImportFeedback();
				darkListView_0 = export_ImportFeedback.LV_Main;
			}
			new LandingPlan_ImportWrapper();
			try
			{
				if (bool_1)
				{
					text = text + "; [NON-EDITABLE];;" + Environment.NewLine;
				}
				text = (bool_1 ? (text + "#Mothership;" + landingPlanner_0.CurrentMothership.Name + ";" + Environment.NewLine) : (text + "#Mothership;" + landingPlanner_0.CurrentMothership.ObjectID + ";" + Environment.NewLine));
				List<string> list = new List<string>();
				if (bool_1)
				{
					foreach (ActiveUnit key in landingPlanner_0.AllowedTransport.Keys)
					{
						list.Add(key.Name);
					}
				}
				else
				{
					foreach (ActiveUnit key2 in landingPlanner_0.AllowedTransport.Keys)
					{
						list.Add(key2.ObjectID);
					}
				}
				text = text + "#Transports;" + string.Join("|", list) + ";" + Environment.NewLine;
				if (bool_1)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Zones;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Type  [NON-EDITABLE];" + Environment.NewLine;
				}
				foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in landingPlanner_0.AssignedZones)
				{
					if (assignedZone.Value.LandingZoneType != 0)
					{
						text = (bool_1 ? (text + "#Zone;" + assignedZone.Key.LandingZone.Description + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine) : (text + "#Zone;" + assignedZone.Key.LandingZone.ObjectID + ";" + assignedZone.Value.LandingZoneType.ToString().ToLower() + ";" + Environment.NewLine));
					}
				}
				if (bool_1)
				{
					text = text + ";;;" + Environment.NewLine;
					text = text + ";;;" + Environment.NewLine;
					text = text + "Serials;;;" + Environment.NewLine;
					text = text + ";Name  [NON-EDITABLE];Priority;Assigned Landing Zone" + Environment.NewLine;
				}
				foreach (KeyValuePair<Chalk, List<UnitLineWrapper>> item in landingPlanner_0.ChalkContainer)
				{
					if (item.Value.Count > 0 && item.Value.ElementAt(0).ChalkUnit.LandingZone != null)
					{
						text = ((item.Key.Preboat == null) ? (bool_1 ? (text + "#Serial;" + item.Key.ID + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.Description + ";" + Environment.NewLine) : (text + "#Serial;" + item.Key.ID + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.ObjectID + ";" + Environment.NewLine)) : (bool_1 ? (text + "#Serial;" + item.Key.Preboat.ActualTransport.Name + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.Description + ";" + Environment.NewLine) : (text + "#Serial;" + item.Key.Preboat.ActualTransport.Name + ";" + item.Value.ElementAt(0).ChalkUnit.Priority + ";" + item.Value.ElementAt(0).ChalkUnit.LandingZone.LandingZone.ObjectID + ";" + Environment.NewLine)));
					}
				}
				string text2 = Path.Combine(CreateDestinationFolder_LandingPlanner(), "LandingPlan_" + landingPlanner_0.CurrentMothership.Name);
				string text3 = "csv";
				int num = 0;
				string path = text2 + "." + text3;
				while (File.Exists(path))
				{
					num++;
					path = text2 + " - " + Conversions.ToString(num) + "." + text3;
				}
				File.WriteAllText(path, text);
				if (!bool_0)
				{
					AddLogEntry("Landing plan was successfully exported : ", darkListView_0, LogType.Success);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				AddLogEntry("Critical issue when exporting landing plan " + ex2.Message, darkListView_0, LogType.Issue);
				ProjectData.ClearProjectError();
			}
			if (export_ImportFeedback != null && export_ImportFeedback.LV_Main.Items.Count > 0)
			{
				export_ImportFeedback.ShowDialog();
			}
			DarkMessageBox.ShowInformation("LandingPlan_" + landingPlanner_0.CurrentMothership.Name + " was successfully saved.", "Landing plan saved");
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			AddLogEntry("Issue when loading landing plan : " + ex4.Message, darkListView_0, LogType.Issue);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ValidateSystem(object sender, EventArgs e)
	{
		ImportLandingPlan(null, LV_Log);
	}

	public static void Import_ProcessLandingPlanLine(string string_0, LandingPlan_ImportWrapper landingPlan_ImportWrapper_0, DarkListView darkListView_0 = null, DataObject_E? nullable_0 = null)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return;
		}
		string[] source = Strings.Split(string_0, ";", -1, CompareMethod.Text);
		if (source.Count() != 0)
		{
			string left = source.ElementAt(0).ToLower();
			if (Operators.CompareString(left, "#serial", TextCompare: true) == 0 && (!nullable_0.HasValue || nullable_0.Value == DataObject_E.serial))
			{
				Import_ProcessLandingPlanLine_Serial(string_0, landingPlan_ImportWrapper_0, darkListView_0);
			}
			else if (Operators.CompareString(left, "#transports", TextCompare: true) == 0 && (!nullable_0.HasValue || nullable_0.Value == DataObject_E.transport))
			{
				Import_ProcessLandingPlanLine_Transports(string_0, landingPlan_ImportWrapper_0, darkListView_0);
			}
			else if (Operators.CompareString(left, "#transport", TextCompare: true) == 0 && (!nullable_0.HasValue || nullable_0.Value == DataObject_E.transportClass))
			{
				Import_ProcessLandingPlanLine_Transport(string_0, landingPlan_ImportWrapper_0, darkListView_0);
			}
			else if (Operators.CompareString(left, "#zone", TextCompare: true) == 0 && (!nullable_0.HasValue || nullable_0.Value == DataObject_E.zone))
			{
				Import_ProcessLandingPlanLine_Zone(string_0, landingPlan_ImportWrapper_0, darkListView_0);
			}
			else if (Operators.CompareString(left, "#mothership", TextCompare: true) == 0 && (!nullable_0.HasValue || nullable_0.Value == DataObject_E.mothership))
			{
				Import_ProcessLandingPlanLine_Mothership(string_0, landingPlan_ImportWrapper_0, darkListView_0);
			}
		}
	}

	public static void Import_ProcessLandingPlanLine_Zone(string string_0, LandingPlan_ImportWrapper landingPlan_ImportWrapper_0, DarkListView darkListView_0 = null)
	{
		if (landingPlan_ImportWrapper_0 == null || landingPlan_ImportWrapper_0.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(string_0, ";", -1, CompareMethod.Text).ToList();
		if (list.Count < 3)
		{
			return;
		}
		list.RemoveAt(0);
		string text = list.ElementAt(0);
		Zone zone = null;
		if (string.IsNullOrEmpty(text))
		{
			AddLogEntry("A zone entry has an empty ID", darkListView_0, LogType.Issue);
			return;
		}
		Side unitSide = landingPlan_ImportWrapper_0.Mothership.GetUnitSide();
		foreach (Zone standardZone in unitSide.StandardZones)
		{
			if (Operators.CompareString(standardZone.ObjectID, text, TextCompare: true) == 0 || Operators.CompareString(standardZone.Description, text, TextCompare: true) == 0)
			{
				zone = standardZone;
			}
		}
		if (zone == null)
		{
			AddLogEntry("区" + text + " not found in side " + unitSide.Name, darkListView_0, LogType.Issue);
			return;
		}
		string left = list.ElementAt(1).ToLower();
		LandingZoneWrapper landingZoneWrapper = ((Operators.CompareString(left, "amphibious", TextCompare: true) == 0) ? new LandingZoneWrapper(zone, LandingType.Amphibious) : ((Operators.CompareString(left, "airborne", TextCompare: true) == 0) ? new LandingZoneWrapper(zone, LandingType.Airborne) : new LandingZoneWrapper(zone, LandingType.Unassigned)));
		if (!landingPlan_ImportWrapper_0.LandingZones.ContainsKey(landingZoneWrapper.LandingZone))
		{
			landingPlan_ImportWrapper_0.LandingZones.Add(landingZoneWrapper.LandingZone, landingZoneWrapper);
		}
	}

	public static void Import_ProcessLandingPlanLine_Transport(string string_0, LandingPlan_ImportWrapper landingPlan_ImportWrapper_0, DarkListView darkListView_0 = null)
	{
		if (landingPlan_ImportWrapper_0 == null || landingPlan_ImportWrapper_0.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(string_0, ";", -1, CompareMethod.Text).ToList();
		if (list.Count >= 2)
		{
			list.RemoveAt(0);
			new HashSet<string>();
			string text = list.ElementAt(0);
			if (!string.IsNullOrEmpty(text) && !landingPlan_ImportWrapper_0.AllowedTransportClasses.Contains(text))
			{
				landingPlan_ImportWrapper_0.AllowedTransportClasses.Add(text);
			}
		}
	}

	public static void Import_ProcessLandingPlanLine_Transports(string string_0, LandingPlan_ImportWrapper landingPlan_ImportWrapper_0, DarkListView darkListView_0 = null)
	{
		if (landingPlan_ImportWrapper_0 == null || landingPlan_ImportWrapper_0.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(string_0, ";", -1, CompareMethod.Text).ToList();
		if (list.Count < 2)
		{
			return;
		}
		list.RemoveAt(0);
		string[] array = Strings.Split(list.ElementAt(0), "|", -1, CompareMethod.Text);
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		if (array.Count() == 0)
		{
			AddLogEntry("No transport has been allowed for this landing plan", darkListView_0, LogType.Warning);
		}
		else
		{
			string[] array2 = array;
			string[] array3 = array2;
			foreach (string text in array3)
			{
				ActiveUnit activeUnit = PrivateMethods.smethod_0(text, Client.CurrentScenario);
				if (activeUnit == null)
				{
					AddLogEntry("Transport ID " + text + " is not valid.", darkListView_0, LogType.Issue);
				}
				else
				{
					list2.Add(activeUnit);
				}
			}
		}
		landingPlan_ImportWrapper_0.AllowedTransports = list2;
	}

	public static void Import_ProcessLandingPlanLine_Serial(string string_0, LandingPlan_ImportWrapper landingPlan_ImportWrapper_0, DarkListView darkListView_0 = null)
	{
		if (landingPlan_ImportWrapper_0 == null || landingPlan_ImportWrapper_0.Mothership == null)
		{
			return;
		}
		List<string> list = Strings.Split(string_0, ";", -1, CompareMethod.Text).ToList();
		if (list.Count < 4)
		{
			return;
		}
		list.RemoveAt(0);
		Dictionary<LandingPlanSerialColumn_E, string> dictionary = new Dictionary<LandingPlanSerialColumn_E, string>();
		int num = list.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			dictionary.Add((LandingPlanSerialColumn_E)i, list[i]);
		}
		Dictionary<int, Chalk> dictionary2 = new Dictionary<int, Chalk>();
		foreach (Chalk chalk in landingPlan_ImportWrapper_0.Mothership.GetUnitSide().Chalks)
		{
			if (Operators.CompareString(chalk.AssociatedMothership.ObjectID, landingPlan_ImportWrapper_0.Mothership.ObjectID, TextCompare: true) == 0)
			{
				dictionary2.Add(chalk.ID, chalk);
			}
		}
		new Dictionary<Chalk, Zone>();
		ActiveUnit activeUnit = PrivateMethods.smethod_0(dictionary[LandingPlanSerialColumn_E.ID], Client.CurrentScenario);
		int result = 0;
		if (activeUnit == null)
		{
			if (int.TryParse(dictionary[LandingPlanSerialColumn_E.ID], out result))
			{
				if (dictionary2.ContainsKey(result))
				{
					Chalk key = dictionary2[result];
					int result2 = 0;
					if (!int.TryParse(dictionary[LandingPlanSerialColumn_E.Priority], out result2))
					{
						AddLogEntry("Unable to parse serial priority " + dictionary[LandingPlanSerialColumn_E.Priority] + " for serial #" + result, darkListView_0, LogType.Warning);
						result2 = 0;
					}
					Zone zone = null;
					if (string.IsNullOrEmpty(dictionary[LandingPlanSerialColumn_E.Zone]))
					{
						AddLogEntry("No zone defined for serial #" + result, darkListView_0, LogType.Warning);
					}
					else
					{
						foreach (Zone standardZone in landingPlan_ImportWrapper_0.Mothership.GetUnitSide().StandardZones)
						{
							zone = standardZone;
							if (Operators.CompareString(zone.ObjectID, dictionary[LandingPlanSerialColumn_E.Zone], TextCompare: true) == 0 || Operators.CompareString(zone.Description, dictionary[LandingPlanSerialColumn_E.Zone], TextCompare: true) == 0)
							{
								zone = zone;
								break;
							}
						}
					}
					if (zone == null)
					{
						AddLogEntry("Zone ID" + dictionary[LandingPlanSerialColumn_E.Zone] + " defined for serial #" + result + " is not valid.", darkListView_0, LogType.Warning);
					}
					int num2 = 3;
					string text = result.ToString();
					landingPlan_ImportWrapper_0.SerialAllowedTransportClasses.Add(text, new HashSet<string>());
					foreach (string allowedTransportClass in landingPlan_ImportWrapper_0.AllowedTransportClasses)
					{
						if (num2 <= list.Count - 1)
						{
							if (HumanReadableString2Bool(list[num2]) && !landingPlan_ImportWrapper_0.SerialAllowedTransportClasses[text].Contains(allowedTransportClass))
							{
								landingPlan_ImportWrapper_0.SerialAllowedTransportClasses[text].Add(allowedTransportClass);
							}
							num2++;
							continue;
						}
						AddLogEntry("There are more transport columns in serial #" + text + " than the actual defined transport class count", darkListView_0, LogType.Issue);
						break;
					}
					if (!landingPlan_ImportWrapper_0.SerialToZoneAssociation.ContainsKey(key))
					{
						landingPlan_ImportWrapper_0.SerialToZoneAssociation.Add(key, zone);
					}
					if (!landingPlan_ImportWrapper_0.SerialToPriority.ContainsKey(key))
					{
						landingPlan_ImportWrapper_0.SerialToPriority.Add(key, result2);
					}
				}
				else
				{
					AddLogEntry("Serial ID " + dictionary[LandingPlanSerialColumn_E.ID] + " is not part of mothership " + landingPlan_ImportWrapper_0.Mothership.Name, darkListView_0, LogType.Issue);
				}
			}
			else
			{
				AddLogEntry("Unable to parse serial ID " + dictionary[LandingPlanSerialColumn_E.ID], darkListView_0, LogType.Issue);
			}
			return;
		}
		Zone zone2 = null;
		if (string.IsNullOrEmpty(dictionary[LandingPlanSerialColumn_E.Zone]))
		{
			AddLogEntry("No zone defined for preboated serial " + activeUnit.Name.ToString(), darkListView_0, LogType.Warning);
		}
		else
		{
			foreach (Zone standardZone2 in landingPlan_ImportWrapper_0.Mothership.GetUnitSide().StandardZones)
			{
				if (Operators.CompareString(standardZone2.ObjectID, dictionary[LandingPlanSerialColumn_E.Zone], TextCompare: true) == 0 || Operators.CompareString(standardZone2.Description, dictionary[LandingPlanSerialColumn_E.Zone], TextCompare: true) == 0)
				{
					zone2 = standardZone2;
					break;
				}
			}
		}
		if (zone2 == null)
		{
			AddLogEntry("Zone ID" + dictionary[LandingPlanSerialColumn_E.Zone] + " defined for serial #" + result + " is not valid.", darkListView_0, LogType.Warning);
		}
		else
		{
			landingPlan_ImportWrapper_0.Preboated.Add(activeUnit, zone2);
		}
	}

	public static void Import_ProcessLandingPlanLine_Mothership(string string_0, LandingPlan_ImportWrapper landingPlan_ImportWrapper_0, DarkListView darkListView_0 = null)
	{
		landingPlan_ImportWrapper_0.Mothership = null;
		string[] source = Strings.Split(string_0, ";", -1, CompareMethod.Text);
		if (source.Count() == 0)
		{
			return;
		}
		string text = source.ElementAt(1);
		if (string.IsNullOrEmpty(text))
		{
			AddLogEntry("Mothership ID is empty", darkListView_0, LogType.Issue);
			return;
		}
		landingPlan_ImportWrapper_0.Mothership = PrivateMethods.smethod_0(text, Client.CurrentScenario);
		if (landingPlan_ImportWrapper_0.Mothership == null)
		{
			AddLogEntry("Mothership ID " + text + " is not valid.", darkListView_0, LogType.Issue);
		}
	}

	private void LoginSystem(object sender, EventArgs e)
	{
		Button_ImportSerials.Visible = false;
		Button_ImportLandingPlan.Visible = false;
		CB_Serials.Checked = false;
	}
}
