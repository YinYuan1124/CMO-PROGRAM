using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class BrowseScenarioPlatforms : DarkSecondaryFormBase
{
	private IContainer m_AttributeBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStrip1")]
	private DarkToolStrip globalBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("TSCB_Side")]
	private ToolStripComboBox accountBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripLabel2")]
	private ToolStripLabel m_StateBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("TreeView1")]
	private DarkTreeView authenticationBridge;

	private Side infoBridge;

	[AccessedThroughProperty("TSCB_Side_Combobox")]
	[CompilerGenerated]
	private System.Windows.Forms.ComboBox _HelperBridge;

	[field: AccessedThroughProperty("ToolStripContainer1")]
	internal ToolStripContainer ToolStripContainer1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return globalBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			globalBridge = value;
		}
	}

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal ToolStripLabel ToolStripLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripComboBox TSCB_Side
	{
		[CompilerGenerated]
		get
		{
			return accountBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			accountBridge = value;
		}
	}

	internal ToolStripLabel ToolStripLabel2
	{
		[CompilerGenerated]
		get
		{
			return m_StateBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StateBridge = value;
		}
	}

	internal DarkTreeView TreeView1
	{
		[CompilerGenerated]
		get
		{
			return authenticationBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = PatchContext;
			DarkTreeView darkTreeView = authenticationBridge;
			if (darkTreeView != null)
			{
				darkTreeView.MouseDoubleClick -= value2;
			}
			authenticationBridge = value;
			darkTreeView = authenticationBridge;
			if (darkTreeView != null)
			{
				darkTreeView.MouseDoubleClick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripContainer2")]
	internal ToolStripContainer ToolStripContainer2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	private System.Windows.Forms.ComboBox CheckContext()
	{
		return _HelperBridge;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void ConcatContext(System.Windows.Forms.ComboBox comboBox_0)
	{
		EventHandler value = ComputeContext;
		System.Windows.Forms.ComboBox helperBridge = _HelperBridge;
		if (helperBridge != null)
		{
			helperBridge.SelectionChangeCommitted -= value;
		}
		_HelperBridge = comboBox_0;
		helperBridge = _HelperBridge;
		if (helperBridge != null)
		{
			helperBridge.SelectionChangeCommitted += value;
		}
	}

	public BrowseScenarioPlatforms()
	{
		base.Load += AddContext;
		base.KeyDown += SelectContext;
		base.FormClosing += CallContext;
		DeleteContext();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_AttributeBridge != null)
			{
				m_AttributeBridge.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DeleteContext()
	{
		ToolStripContainer1 = new ToolStripContainer();
		TreeView1 = new DarkTreeView();
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSCB_Side = new ToolStripComboBox();
		ToolStripLabel2 = new ToolStripLabel();
		ToolStripContainer2 = new ToolStripContainer();
		ToolStripContainer1.ContentPanel.SuspendLayout();
		ToolStripContainer1.SuspendLayout();
		ToolStrip1.SuspendLayout();
		ToolStripContainer2.ContentPanel.SuspendLayout();
		ToolStripContainer2.TopToolStripPanel.SuspendLayout();
		ToolStripContainer2.SuspendLayout();
		SuspendLayout();
		ToolStripContainer1.ContentPanel.Controls.Add(TreeView1);
		ToolStripContainer1.ContentPanel.Size = new Size(604, 289);
		ToolStripContainer1.Dock = DockStyle.Fill;
		ToolStripContainer1.Location = new Point(0, 0);
		ToolStripContainer1.Name = "ToolStripContainer1";
		ToolStripContainer1.Size = new Size(604, 289);
		ToolStripContainer1.TabIndex = 0;
		ToolStripContainer1.Text = "ToolStripContainer1";
		ToolStripContainer1.TopToolStripPanel.BackColor = Color.FromArgb(64, 64, 64);
		TreeView1.Dock = DockStyle.Fill;
		TreeView1.Location = new Point(0, 0);
		TreeView1.MaxDragChange = 20;
		TreeView1.Name = "TreeView1";
		TreeView1.Size = new Size(604, 289);
		TreeView1.TabIndex = 0;
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[3] { ToolStripLabel1, TSCB_Side, ToolStripLabel2 });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(604, 27);
		ToolStrip1.Stretch = true;
		ToolStrip1.TabIndex = 0;
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(32, 24);
		ToolStripLabel1.Text = "分方：";
		TSCB_Side.BackColor = Color.FromArgb(60, 63, 65);
		TSCB_Side.DropDownStyle = ComboBoxStyle.DropDownList;
		TSCB_Side.ForeColor = Color.FromArgb(220, 220, 220);
		TSCB_Side.Name = "TSCB_Side";
		TSCB_Side.Size = new Size(200, 27);
		ToolStripLabel2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel2.Font = new Font("Segoe UI", 9f, FontStyle.Italic);
		ToolStripLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel2.Name = "ToolStripLabel2";
		ToolStripLabel2.Size = new Size(206, 24);
		ToolStripLabel2.Text = "（双击平台类型查看数据库信息）";
		ToolStripContainer2.ContentPanel.AutoScroll = true;
		ToolStripContainer2.ContentPanel.Controls.Add(ToolStripContainer1);
		ToolStripContainer2.ContentPanel.Size = new Size(604, 289);
		ToolStripContainer2.Dock = DockStyle.Fill;
		ToolStripContainer2.Location = new Point(0, 0);
		ToolStripContainer2.Name = "ToolStripContainer2";
		ToolStripContainer2.Size = new Size(604, 316);
		ToolStripContainer2.TabIndex = 1;
		ToolStripContainer2.Text = "ToolStripContainer2";
		ToolStripContainer2.TopToolStripPanel.Controls.Add(ToolStrip1);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(604, 316);
		base.Controls.Add(ToolStripContainer2);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "BrowseScenarioPlatforms";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "浏览想定平台";
		ToolStripContainer1.ContentPanel.ResumeLayout(performLayout: false);
		ToolStripContainer1.ResumeLayout(performLayout: false);
		ToolStripContainer1.PerformLayout();
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		ToolStripContainer2.ContentPanel.ResumeLayout(performLayout: false);
		ToolStripContainer2.TopToolStripPanel.ResumeLayout(performLayout: false);
		ToolStripContainer2.ResumeLayout(performLayout: false);
		ToolStripContainer2.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void AddContext(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.CurrentSide))
		{
			Close();
			return;
		}
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		infoBridge = Client.CurrentSide;
		ConcatContext(TSCB_Side.ComboBox);
		int num = 0;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Content = side.Name;
			comboBoxItem.Tag = side.ObjectID;
			CheckContext().Items.Add(comboBoxItem);
			if (Operators.CompareString(infoBridge.ObjectID, side.ObjectID, TextCompare: true) == 0)
			{
				CheckContext().SelectedIndex = num;
			}
			num++;
		}
		CheckContext().DisplayMember = "Content";
		CheckContext().ValueMember = "Tag";
		DestroyContext();
		Refresh();
	}

	private void DestroyContext()
	{
		TreeView1.Nodes.Clear();
		IEnumerable<IGrouping<string, ActiveUnit>> enumerable = from activeUnit_0 in Client.CurrentScenario.ActiveUnits_List
			where !Information.IsNothing(activeUnit_0) && activeUnit_0.IsPlatform && activeUnit_0.GetUnitSide() == infoBridge
			select activeUnit_0 into AU
			group AU by AU.GetType().ToString() into theAU
			select (theAU);
		if (enumerable.Count() == 0)
		{
			TreeView1.Refresh();
		}
		foreach (IGrouping<string, ActiveUnit> item in enumerable)
		{
			string unitType_String = item.ElementAtOrDefault(0).UnitType_String;
			DarkTreeNode darkTreeNode = new DarkTreeNode(unitType_String);
			TreeView1.Nodes.Add(darkTreeNode);
			foreach (IGrouping<int, ActiveUnit> item2 in from AU in item
				group AU by AU.DBID)
			{
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(item2.ElementAtOrDefault(0).UnitClass);
				darkTreeNode2.Tag = unitType_String + "_" + Conversions.ToString(item2.ElementAtOrDefault(0).DBID);
				darkTreeNode.Nodes.Add(darkTreeNode2);
			}
		}
	}

	private void ComputeContext(object sender, EventArgs e)
	{
		infoBridge = Client.CurrentScenario.Sides_ReadOnly.Where((Side side_0) => Operators.CompareString(side_0.ObjectID, Conversions.ToString(((ComboBoxItem)CheckContext().SelectedItem).Tag), TextCompare: true) == 0).ElementAtOrDefault(0);
		DestroyContext();
	}

	private void PatchContext(object sender, EventArgs e)
	{
		if (TreeView1.SelectedNodes.Count != 0)
		{
			DarkTreeNode darkTreeNode = TreeView1.SelectedNodes[0];
			if (!string.IsNullOrEmpty(Conversions.ToString(darkTreeNode.Tag)))
			{
				string string_ = darkTreeNode.Tag.ToString().Split(Conversions.ToCharArrayRankOne("_"))[0];
				int int_ = Conversions.ToInteger(darkTreeNode.Tag.ToString().Split(Conversions.ToCharArrayRankOne("_"))[1]);
				Client.smethod_0(string_, int_);
			}
		}
	}

	private void SelectContext(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.End && e.KeyCode != Keys.Home && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Add && e.KeyCode != Keys.Subtract))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CallContext(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	[CompilerGenerated]
	private bool LogoutContext(ActiveUnit activeUnit_0)
	{
		if (!Information.IsNothing(activeUnit_0) && activeUnit_0.IsPlatform)
		{
			return activeUnit_0.GetUnitSide() == infoBridge;
		}
		return false;
	}

	[CompilerGenerated]
	private bool ViewContext(Side side_0)
	{
		return Operators.CompareString(side_0.ObjectID, Conversions.ToString(((ComboBoxItem)CheckContext().SelectedItem).Tag), TextCompare: true) == 0;
	}
}
