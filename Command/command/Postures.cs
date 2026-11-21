using System;
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
public sealed class Postures : DarkSecondaryFormBase
{
	public enum PostureChangeMode
	{
		ScenarioEditor,
		Player
	}

	private IContainer m_SpecificationSchema;

	[AccessedThroughProperty("LB_Sides")]
	[CompilerGenerated]
	private DarkListView _WatcherSchema;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_ReponseSchema;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox m_PoolSchema;

	public Side SelectedSide;

	public Side TargetSide;

	public int Mode;

	internal DarkListView LB_Sides
	{
		[CompilerGenerated]
		get
		{
			return _WatcherSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddInterruptibleConnection;
			DarkListView watcherSchema = _WatcherSchema;
			if (watcherSchema != null)
			{
				watcherSchema.SelectedIndicesChanged -= value2;
			}
			_WatcherSchema = value;
			watcherSchema = _WatcherSchema;
			if (watcherSchema != null)
			{
				watcherSchema.SelectedIndicesChanged += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReponseSchema = value;
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return m_PoolSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyInterruptibleConnection;
			DarkUIComboBox poolSchema = m_PoolSchema;
			if (poolSchema != null)
			{
				poolSchema.SelectionChangeCommitted -= value2;
			}
			m_PoolSchema = value;
			poolSchema = m_PoolSchema;
			if (poolSchema != null)
			{
				poolSchema.SelectionChangeCommitted += value2;
			}
		}
	}

	public Postures()
	{
		base.Load += DeleteInterruptibleConnection;
		base.KeyDown += ComputeInterruptibleConnection;
		base.FormClosing += PatchInterruptibleConnection;
		Mode = 0;
		MoveInterruptibleConnection();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_SpecificationSchema != null)
			{
				m_SpecificationSchema.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void MoveInterruptibleConnection()
	{
		LB_Sides = new DarkListView();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		ComboBox1 = new DarkUIComboBox();
		SuspendLayout();
		LB_Sides.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LB_Sides.Location = new Point(12, 25);
		LB_Sides.Name = "LB_Sides";
		LB_Sides.Size = new Size(214, 147);
		LB_Sides.TabIndex = 1;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(9, 9);
		Label1.Name = "Label1";
		Label1.Size = new Size(99, 15);
		Label1.TabIndex = 4;
		Label1.Text = "选择目标分方：";
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(9, 188);
		Label2.Name = "Label2";
		Label2.Size = new Size(224, 13);
		Label2.TabIndex = 5;
		Label2.AutoSize = true;
		Label2.Text = "对于当前分方这一方是......";
		ComboBox1.BackColor = Color.Transparent;
		ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox1.Font = new Font("Segoe UI", 7f);
		ComboBox1.FormattingEnabled = true;
		ComboBox1.Items.AddRange(new object[4] { "中立", "友方", "非友方", "敌方" });
		ComboBox1.Location = new Point(12, 204);
		ComboBox1.Name = "ComboBox1";
		ComboBox1.Size = new Size(216, 21);
		ComboBox1.TabIndex = 6;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(238, 233);
		base.Controls.Add(ComboBox1);
		base.Controls.Add(Label2);
		base.Controls.Add(Label1);
		base.Controls.Add(LB_Sides);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Postures";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "对抗关系";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void DeleteInterruptibleConnection(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		Text = "分方的对抗关系：" + SelectedSide.Name;
		Label2.Text = SelectedSide.Name + " 认为所选分方是...";
		foreach (Side item in Client.CurrentScenario.Sides_ReadOnly.OrderBy((Side theS) => theS.Name))
		{
			if (item != SelectedSide)
			{
				LB_Sides.Items.Add(new DarkListItem(item.Name));
			}
		}
		if (LB_Sides.Items.Count > 0)
		{
			LB_Sides.SelectItem(0);
		}
	}

	private void AddInterruptibleConnection(object sender, EventArgs e)
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
				TargetSide = side;
				break;
			}
		}
		ComboBox1.SelectedIndex = (int)SelectedSide.GetConsidersThisSideToBe(TargetSide);
	}

	private void DestroyInterruptibleConnection(object sender, EventArgs e)
	{
		if (Information.IsNothing(TargetSide))
		{
			DarkMessageBox.ShowError("首先，选择要应用对抗关系的目标分方。", "没有选择目标分方！");
			return;
		}
		bool flag = true;
		Misc.PostureStance postureStance = (Misc.PostureStance)ComboBox1.SelectedIndex;
		if (Mode == 1 && postureStance != Misc.PostureStance.Hostile && SelectedSide.GetConsidersThisSideToBe(TargetSide) == Misc.PostureStance.Hostile && TargetSide.GetConsidersThisSideToBe(SelectedSide) == Misc.PostureStance.Hostile)
		{
			flag = DarkMessageBox.ShowWarning("You are adopting a non-hostile posture towards a hostile side. This may cause problems in some scenarios where mutual hostility is assumed. Do you wish to set the non-hostile posture anyway?", "Adopting Non-Hostile Posture", DarkDialogButton.OkCancel) == DialogResult.OK;
		}
		if (flag)
		{
			SelectedSide.SetConsidersThisSideToBe(TargetSide, postureStance);
			Client.MustRefreshMainForm = true;
		}
		else
		{
			ComboBox1.SelectedIndex = (int)SelectedSide.GetConsidersThisSideToBe(TargetSide);
		}
	}

	private void ComputeInterruptibleConnection(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void PatchInterruptibleConnection(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}
}
