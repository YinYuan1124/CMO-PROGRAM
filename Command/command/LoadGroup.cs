using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace Command;

[DesignerGenerated]
public sealed class LoadGroup : DarkSecondaryFormBase
{
	private IContainer m_MerchantModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TV1")]
	private TreeView m_CallbackModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_Name")]
	private DarkLabel m_ProcessModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private DarkLabel m_ThreadModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel ruleModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_ValidFrom")]
	private DarkLabel collectionModel;

	[AccessedThroughProperty("label_ValidUntil")]
	[CompilerGenerated]
	private DarkLabel m_InstanceModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label7")]
	private DarkLabel objectModel;

	[AccessedThroughProperty("Label_Notes")]
	[CompilerGenerated]
	private DarkLabel expressionModel;

	[AccessedThroughProperty("Label9")]
	[CompilerGenerated]
	private DarkLabel dispatcherModel;

	[CompilerGenerated]
	[AccessedThroughProperty("ListView1")]
	private DarkListView m_ListenerModel;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _ConfigModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _RegistryModel;

	[AccessedThroughProperty("ToolStrip1")]
	[CompilerGenerated]
	private DarkToolStrip definitionModel;

	[AccessedThroughProperty("CheckBox_DoNotCheckDBCompatibility")]
	[CompilerGenerated]
	private DarkCheckBox m_WrapperModel;

	[AccessedThroughProperty("CheckBox_No_Delta_Load")]
	[CompilerGenerated]
	private DarkCheckBox m_ObserverModel;

	private ImportExportRecord _ClientModel;

	internal TreeView TV1
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TreeNodeMouseClickEventHandler value2 = SortFactory;
			TreeView callbackModel = m_CallbackModel;
			if (callbackModel != null)
			{
				callbackModel.NodeMouseClick -= value2;
			}
			m_CallbackModel = value;
			callbackModel = m_CallbackModel;
			if (callbackModel != null)
			{
				callbackModel.NodeMouseClick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_Name
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProcessModel = value;
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ThreadModel = value;
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return ruleModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ruleModel = value;
		}
	}

	internal DarkLabel Label_ValidFrom
	{
		[CompilerGenerated]
		get
		{
			return collectionModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			collectionModel = value;
		}
	}

	internal DarkLabel label_ValidUntil
	{
		[CompilerGenerated]
		get
		{
			return m_InstanceModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InstanceModel = value;
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return objectModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			objectModel = value;
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal FlowLayoutPanel FlowLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_Notes
	{
		[CompilerGenerated]
		get
		{
			return expressionModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			expressionModel = value;
		}
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return dispatcherModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dispatcherModel = value;
		}
	}

	internal DarkListView ListView1
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ListenerModel = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _ConfigModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushFactory;
			DarkUIButton configModel = _ConfigModel;
			if (configModel != null)
			{
				configModel.Click -= value2;
			}
			_ConfigModel = value;
			configModel = _ConfigModel;
			if (configModel != null)
			{
				configModel.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _RegistryModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcFactory;
			DarkUIButton registryModel = _RegistryModel;
			if (registryModel != null)
			{
				registryModel.Click -= value2;
			}
			_RegistryModel = value;
			registryModel = _RegistryModel;
			if (registryModel != null)
			{
				registryModel.Click += value2;
			}
		}
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return definitionModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			definitionModel = value;
		}
	}

	[field: AccessedThroughProperty("TSL_Loadingtext")]
	internal ToolStripLabel TSL_Loadingtext
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CheckBox_DoNotCheckDBCompatibility
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WrapperModel = value;
		}
	}

	internal DarkCheckBox CheckBox_No_Delta_Load
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObserverModel = value;
		}
	}

	[field: AccessedThroughProperty("Label_Template")]
	internal DarkLabel Label_Template
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public LoadGroup()
	{
		base.FormClosing += AwakeFactory;
		base.Load += QueryFactory;
		base.VisibleChanged += ForgotFactory;
		base.KeyDown += CollectFactory;
		PublishFactory();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_MerchantModel != null)
			{
				m_MerchantModel.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PublishFactory()
	{
		TV1 = new TreeView();
		Label1 = new DarkLabel();
		Label_Name = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		Label_ValidFrom = new DarkLabel();
		label_ValidUntil = new DarkLabel();
		Label7 = new DarkLabel();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Label_Notes = new DarkLabel();
		Label9 = new DarkLabel();
		ListView1 = new DarkListView();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		ToolStrip1 = new DarkToolStrip();
		TSL_Loadingtext = new ToolStripLabel();
		CheckBox_DoNotCheckDBCompatibility = new DarkCheckBox();
		CheckBox_No_Delta_Load = new DarkCheckBox();
		Label_Template = new DarkLabel();
		FlowLayoutPanel1.SuspendLayout();
		ToolStrip1.SuspendLayout();
		SuspendLayout();
		TV1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		TV1.BackColor = Color.FromArgb(43, 43, 43);
		TV1.CheckBoxes = true;
		TV1.ForeColor = Color.LightGray;
		TV1.Location = new Point(12, 61);
		TV1.Name = "TV1";
		TV1.Size = new Size(457, 498);
		TV1.TabIndex = 0;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(476, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(70, 13);
		Label1.TabIndex = 1;
		Label1.Text = "编队名字：";
		Label_Name.AutoSize = true;
		Label_Name.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label_Name.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Name.Location = new Point(598, 13);
		Label_Name.Name = "Label_Name";
		Label_Name.Size = new Size(15, 19);
		Label_Name.TabIndex = 2;
		Label_Name.Text = "?";
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(476, 38);
		Label3.Name = "Label3";
		Label3.Size = new Size(70, 13);
		Label3.TabIndex = 3;
		Label3.Text = "有效期自：";
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(475, 61);
		Label4.Name = "Label4";
		Label4.Size = new Size(89, 13);
		Label4.TabIndex = 4;
		Label4.Text = "有效期至：";
		Label_ValidFrom.AutoSize = true;
		Label_ValidFrom.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label_ValidFrom.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ValidFrom.Location = new Point(598, 38);
		Label_ValidFrom.Name = "Label_ValidFrom";
		Label_ValidFrom.Size = new Size(15, 19);
		Label_ValidFrom.TabIndex = 5;
		Label_ValidFrom.Text = "?";
		label_ValidUntil.AutoSize = true;
		label_ValidUntil.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		label_ValidUntil.ForeColor = Color.FromArgb(220, 220, 220);
		label_ValidUntil.Location = new Point(598, 61);
		label_ValidUntil.Name = "label_ValidUntil";
		label_ValidUntil.Size = new Size(15, 19);
		label_ValidUntil.TabIndex = 6;
		label_ValidUntil.Text = "?";
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(3, 0);
		Label7.Name = "Label7";
		Label7.Size = new Size(38, 13);
		Label7.TabIndex = 7;
		Label7.Text = "注意：";
		FlowLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		FlowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
		FlowLayoutPanel1.Controls.Add(Label7);
		FlowLayoutPanel1.Controls.Add(Label_Notes);
		FlowLayoutPanel1.Location = new Point(479, 95);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(764, 165);
		FlowLayoutPanel1.TabIndex = 8;
		Label_Notes.AutoSize = true;
		Label_Notes.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Notes.Location = new Point(47, 0);
		Label_Notes.Name = "Label_Notes";
		Label_Notes.Size = new Size(16, 20);
		Label_Notes.TabIndex = 0;
		Label_Notes.Text = "?";
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(479, 263);
		Label9.Name = "Label9";
		Label9.Size = new Size(85, 13);
		Label9.TabIndex = 9;
		Label9.Text = "编队成员：";
		ListView1.Location = new Point(482, 280);
		ListView1.Name = "ListView1";
		ListView1.RelatedInfos = null;
		ListView1.Size = new Size(335, 238);
		ListView1.TabIndex = 10;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(482, 534);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(146, 25);
		Button1.TabIndex = 11;
		Button1.Text = "加载选定的装置";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(742, 534);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 25);
		Button2.TabIndex = 12;
		Button2.Text = "关闭";
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.Dock = DockStyle.Bottom;
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.ImageScalingSize = new Size(20, 20);
		ToolStrip1.Items.AddRange(new ToolStripItem[1] { TSL_Loadingtext });
		ToolStrip1.Location = new Point(0, 562);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(1255, 25);
		ToolStrip1.TabIndex = 13;
		ToolStrip1.Text = "ToolStrip1";
		TSL_Loadingtext.BackColor = Color.FromArgb(60, 63, 65);
		TSL_Loadingtext.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_Loadingtext.Name = "TSL_Loadingtext";
		TSL_Loadingtext.Size = new Size(119, 22);
		TSL_Loadingtext.Text = "TSL_LoadingText";
		CheckBox_DoNotCheckDBCompatibility.AutoSize = true;
		CheckBox_DoNotCheckDBCompatibility.Location = new Point(12, 13);
		CheckBox_DoNotCheckDBCompatibility.Name = "CheckBox_DoNotCheckDBCompatibility";
		CheckBox_DoNotCheckDBCompatibility.Size = new Size(257, 24);
		CheckBox_DoNotCheckDBCompatibility.TabIndex = 14;
		CheckBox_DoNotCheckDBCompatibility.Text = "不检查数据库兼容性";
		CheckBox_No_Delta_Load.AutoSize = true;
		CheckBox_No_Delta_Load.Location = new Point(12, 36);
		CheckBox_No_Delta_Load.Name = "CheckBox_No_Delta_Load";
		CheckBox_No_Delta_Load.Size = new Size(176, 24);
		CheckBox_No_Delta_Load.TabIndex = 15;
		CheckBox_No_Delta_Load.Text = "Do not load any delta";
		Label_Template.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Template.Location = new Point(713, 60);
		Label_Template.Name = "Label_Template";
		Label_Template.Size = new Size(70, 13);
		Label_Template.TabIndex = 16;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1255, 587);
		base.Controls.Add(Label_Template);
		base.Controls.Add(CheckBox_No_Delta_Load);
		base.Controls.Add(CheckBox_DoNotCheckDBCompatibility);
		base.Controls.Add(ToolStrip1);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(ListView1);
		base.Controls.Add(Label9);
		base.Controls.Add(FlowLayoutPanel1);
		base.Controls.Add(label_ValidUntil);
		base.Controls.Add(Label_ValidFrom);
		base.Controls.Add(Label4);
		base.Controls.Add(Label3);
		base.Controls.Add(Label_Name);
		base.Controls.Add(Label1);
		base.Controls.Add(TV1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "LoadGroup";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "从文件加载编队";
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		FlowLayoutPanel1.PerformLayout();
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void AwakeFactory(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void QueryFactory(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ResetFactory();
	}

	private void ResetFactory()
	{
		TreeNode treeNode_ = TV1.Nodes.Add("Main");
		treeNode_.Tag = "";
		MapFactory(ref treeNode_, GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "ImportExport");
		TSL_Loadingtext.Visible = false;
	}

	private void MapFactory(ref TreeNode treeNode_0, string string_0)
	{
		TreeNode treeNode_ = treeNode_0.Nodes.Add(Path.GetFullPath(string_0), Path.GetFileName(string_0));
		treeNode_.Tag = string_0;
		string[] directories = Directory.GetDirectories(string_0);
		string[] array = directories;
		foreach (string string_ in array)
		{
			MapFactory(ref treeNode_, string_);
		}
		directories = Directory.GetFiles(string_0);
		string[] array2 = directories;
		foreach (string text in array2)
		{
			treeNode_.Nodes.Add(Path.GetFullPath(text), Path.GetFileName(text)).Tag = text;
		}
	}

	private void SortFactory(object sender, TreeNodeMouseClickEventArgs e)
	{
		try
		{
			if (Conversions.ToString(e.Node.Tag).Contains(".inst"))
			{
				ListView1.Items.Clear();
				StreamReader streamReader = new StreamReader(Conversions.ToString(e.Node.Tag));
				using (streamReader)
				{
					string text = streamReader.ReadToEnd().Replace("\\\"", "");
					text = text.Replace("\\", "/");
					_ClientModel = (ImportExportRecord)JsonConvert.DeserializeObject(text, typeof(ImportExportRecord));
				}
				if (_ClientModel.DB_ID != Client.CurrentDB.DBID && !CheckBox_DoNotCheckDBCompatibility.Checked)
				{
					Label_Name.Text = "不能使用 - 不兼容的数据库";
					e.Node.Checked = false;
					return;
				}
				Label_Name.Text = _ClientModel.Name;
				Label_ValidFrom.Text = _ClientModel.ValidFrom;
				label_ValidUntil.Text = _ClientModel.ValidUntil;
				Label_Notes.Text = _ClientModel.Comments;
				Label_Template.Text = "";
				if (_ClientModel.Template)
				{
					Label_Template.Text = "Template";
					Label_Notes.Text += "\r\nIf the template contains a 'Group', the Group will need to be renamed before the template is imported again, else the imported units will be appended to the existing Group.";
				}
				{
					foreach (ImportExportRecord.MemberRecord memberRecord in _ClientModel.MemberRecords)
					{
						if (memberRecord.Member_SBR != null && memberRecord.Member_SBR.Length > 0)
						{
							DarkListItem item = new DarkListItem(memberRecord.MemberName + " [w/delta]");
							ListView1.Items.Add(item);
						}
						else
						{
							DarkListItem item2 = new DarkListItem(memberRecord.MemberName);
							ListView1.Items.Add(item2);
						}
					}
					return;
				}
			}
			IEnumerator enumerator2 = null;
			if (e.Node.Checked)
			{
				try
				{
					enumerator2 = e.Node.Nodes.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						TreeNode treeNode = (TreeNode)enumerator2.Current;
						StreamReader streamReader2 = new StreamReader(Conversions.ToString(treeNode.Tag));
						using (streamReader2)
						{
							string text2 = streamReader2.ReadToEnd().Replace("\\\"", "");
							text2 = text2.Replace("\\", "/");
							_ClientModel = (ImportExportRecord)JsonConvert.DeserializeObject(text2, typeof(ImportExportRecord));
						}
						if (_ClientModel.DB_ID != Client.CurrentDB.DBID && !CheckBox_DoNotCheckDBCompatibility.Checked)
						{
							treeNode.Checked = false;
						}
						else
						{
							treeNode.Checked = true;
						}
					}
					return;
				}
				finally
				{
					if (enumerator2 is IDisposable)
					{
						(enumerator2 as IDisposable).Dispose();
					}
				}
			}
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = e.Node.Nodes.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					((TreeNode)enumerator3.Current).Checked = false;
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200272", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CalcFactory(object sender, EventArgs e)
	{
		Close();
	}

	private void RateFactory(TreeNode treeNode_0)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = treeNode_0.Nodes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TreeNode treeNode = (TreeNode)enumerator.Current;
				if (Conversions.ToString(treeNode.Tag).Contains(".inst"))
				{
					if (treeNode.Checked)
					{
						TSL_Loadingtext.Visible = true;
						TSL_Loadingtext.Text = "加载：" + treeNode.Text;
						Client.CurrentScenario.ImportUnitsFromFile(Conversions.ToString(treeNode.Tag), Client.CurrentSide);
						Client.MustRefreshMainForm = true;
					}
				}
				else
				{
					RateFactory(treeNode);
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
	}

	private void FlushFactory(object sender, EventArgs e)
	{
		if (TV1.Nodes.Count == 0)
		{
			return;
		}
		RateFactory(TV1.Nodes[0]);
		TSL_Loadingtext.Text = "已完成！";
		foreach (TreeNode item in InterpreterObjectListener.ResolveInterruptibleTask(TV1))
		{
			if (item.Checked)
			{
				item.Checked = false;
			}
		}
		Client.MustRefreshMainForm = true;
	}

	private void ForgotFactory(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		}
	}

	private void CollectFactory(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}
}
