using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class SplitUnit : Form
{
	private IContainer _CallbackException;

	[AccessedThroughProperty("LV_SourceUnit")]
	[CompilerGenerated]
	private DarkListView m_DecoratorException;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ToDestination")]
	private DarkUIButton m_ThreadException;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ToSource")]
	private DarkUIButton ruleException;

	[AccessedThroughProperty("TB_RenameSource")]
	[CompilerGenerated]
	private DarkUITextBox collectionException;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonRenameSource")]
	private DarkUIButton instanceException;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_RenameDestination")]
	private DarkUITextBox objectException;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonSplit")]
	private DarkUIButton parameterException;

	[AccessedThroughProperty("ButtonBreakIntoIndividualUnits")]
	[CompilerGenerated]
	private DarkUIButton expressionException;

	public ActiveUnit SourceUnit;

	public Dictionary<Mount, Mount> TransferedMounts;

	internal virtual DarkListView LV_SourceUnit
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DecoratorException = value;
		}
	}

	[field: AccessedThroughProperty("LV_TargetUnit")]
	internal virtual DarkListView LV_TargetUnit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton Button_ToDestination
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineInterruptibleSingleton;
			DarkUIButton threadException = m_ThreadException;
			if (threadException != null)
			{
				threadException.Click -= value2;
			}
			m_ThreadException = value;
			threadException = m_ThreadException;
			if (threadException != null)
			{
				threadException.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_ToSource
	{
		[CompilerGenerated]
		get
		{
			return ruleException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishInterruptibleSingleton;
			DarkUIButton darkUIButton = ruleException;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			ruleException = value;
			darkUIButton = ruleException;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUITextBox TB_RenameSource
	{
		[CompilerGenerated]
		get
		{
			return collectionException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			collectionException = value;
		}
	}

	internal virtual DarkUIButton ButtonRenameSource
	{
		[CompilerGenerated]
		get
		{
			return instanceException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeInterruptibleSingleton;
			DarkUIButton darkUIButton = instanceException;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			instanceException = value;
			darkUIButton = instanceException;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUITextBox TB_RenameDestination
	{
		[CompilerGenerated]
		get
		{
			return objectException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			objectException = value;
		}
	}

	internal virtual DarkUIButton ButtonSplit
	{
		[CompilerGenerated]
		get
		{
			return parameterException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetInterruptibleSingleton;
			DarkUIButton darkUIButton = parameterException;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			parameterException = value;
			darkUIButton = parameterException;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonBreakIntoIndividualUnits
	{
		[CompilerGenerated]
		get
		{
			return expressionException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapInterruptibleSingleton;
			DarkUIButton darkUIButton = expressionException;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			expressionException = value;
			darkUIButton = expressionException;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public SplitUnit()
	{
		base.Load += PrintInterruptibleSingleton;
		TransferedMounts = new Dictionary<Mount, Mount>();
		AssetInterruptibleSingleton();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _CallbackException != null)
			{
				_CallbackException.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AssetInterruptibleSingleton()
	{
		LV_SourceUnit = new DarkListView();
		LV_TargetUnit = new DarkListView();
		ButtonSplit = new DarkUIButton();
		TB_RenameDestination = new DarkUITextBox();
		ButtonRenameSource = new DarkUIButton();
		TB_RenameSource = new DarkUITextBox();
		Button_ToSource = new DarkUIButton();
		Button_ToDestination = new DarkUIButton();
		ButtonBreakIntoIndividualUnits = new DarkUIButton();
		SuspendLayout();
		LV_SourceUnit.BackColor = Color.FromArgb(50, 53, 55);
		LV_SourceUnit.Location = new Point(14, 48);
		LV_SourceUnit.Margin = new Padding(3, 4, 3, 4);
		LV_SourceUnit.Name = "LV_SourceUnit";
		LV_SourceUnit.Size = new Size(259, 288);
		LV_SourceUnit.TabIndex = 0;
		LV_SourceUnit.Text = "LV_SourceUnit";
		LV_TargetUnit.BackColor = Color.FromArgb(50, 53, 55);
		LV_TargetUnit.Location = new Point(338, 48);
		LV_TargetUnit.Margin = new Padding(3, 4, 3, 4);
		LV_TargetUnit.Name = "LV_TargetUnit";
		LV_TargetUnit.Size = new Size(259, 288);
		LV_TargetUnit.TabIndex = 1;
		LV_TargetUnit.Text = "LV_TargetUnit";
		ButtonSplit.BackColor = Color.Transparent;
		ButtonSplit.DialogResult = DialogResult.None;
		ButtonSplit.ForeColor = SystemColors.Control;
		ButtonSplit.Location = new Point(338, 342);
		ButtonSplit.Margin = new Padding(3, 4, 3, 4);
		ButtonSplit.Name = "ButtonSplit";
		ButtonSplit.RoundRadius = 0;
		ButtonSplit.Size = new Size(259, 40);
		ButtonSplit.TabIndex = 8;
		ButtonSplit.Text = "SPLIT";
		TB_RenameDestination.AutoCompleteCustomSource = null;
		TB_RenameDestination.AutoCompleteMode = AutoCompleteMode.None;
		TB_RenameDestination.AutoCompleteSource = AutoCompleteSource.None;
		TB_RenameDestination.BackColor = Color.Transparent;
		TB_RenameDestination.ForeColor = Color.FromArgb(189, 189, 189);
		TB_RenameDestination.Image = null;
		TB_RenameDestination.Lines = null;
		TB_RenameDestination.Location = new Point(338, 11);
		TB_RenameDestination.Margin = new Padding(3, 4, 3, 4);
		TB_RenameDestination.MaxLength = 32767;
		TB_RenameDestination.Multiline = false;
		TB_RenameDestination.Name = "TB_RenameDestination";
		TB_RenameDestination.ReadOnly = false;
		TB_RenameDestination.ScrollBars = ScrollBars.None;
		TB_RenameDestination.SelectionStart = 0;
		TB_RenameDestination.Size = new Size(258, 26);
		TB_RenameDestination.TabIndex = 6;
		TB_RenameDestination.Text = "---";
		TB_RenameDestination.TextAlign = HorizontalAlignment.Left;
		TB_RenameDestination.UseSystemPasswordChar = false;
		TB_RenameDestination.WatermarkText = "";
		ButtonRenameSource.BackColor = Color.Transparent;
		ButtonRenameSource.DialogResult = DialogResult.None;
		ButtonRenameSource.ForeColor = SystemColors.Control;
		ButtonRenameSource.Location = new Point(196, 11);
		ButtonRenameSource.Margin = new Padding(3, 4, 3, 4);
		ButtonRenameSource.Name = "ButtonRenameSource";
		ButtonRenameSource.RoundRadius = 0;
		ButtonRenameSource.Size = new Size(76, 29);
		ButtonRenameSource.TabIndex = 5;
		ButtonRenameSource.Text = "改名";
		TB_RenameSource.AutoCompleteCustomSource = null;
		TB_RenameSource.AutoCompleteMode = AutoCompleteMode.None;
		TB_RenameSource.AutoCompleteSource = AutoCompleteSource.None;
		TB_RenameSource.BackColor = Color.Transparent;
		TB_RenameSource.ForeColor = Color.FromArgb(189, 189, 189);
		TB_RenameSource.Image = null;
		TB_RenameSource.Lines = null;
		TB_RenameSource.Location = new Point(14, 11);
		TB_RenameSource.Margin = new Padding(3, 4, 3, 4);
		TB_RenameSource.MaxLength = 32767;
		TB_RenameSource.Multiline = false;
		TB_RenameSource.Name = "TB_RenameSource";
		TB_RenameSource.ReadOnly = false;
		TB_RenameSource.ScrollBars = ScrollBars.None;
		TB_RenameSource.SelectionStart = 0;
		TB_RenameSource.Size = new Size(176, 26);
		TB_RenameSource.TabIndex = 4;
		TB_RenameSource.Text = "---";
		TB_RenameSource.TextAlign = HorizontalAlignment.Left;
		TB_RenameSource.UseSystemPasswordChar = false;
		TB_RenameSource.WatermarkText = "";
		Button_ToSource.BackColor = Color.Transparent;
		Button_ToSource.DialogResult = DialogResult.None;
		Button_ToSource.ForeColor = SystemColors.Control;
		Button_ToSource.Location = new Point(280, 94);
		Button_ToSource.Margin = new Padding(3, 4, 3, 4);
		Button_ToSource.Name = "Button_ToSource";
		Button_ToSource.RoundRadius = 0;
		Button_ToSource.Size = new Size(51, 85);
		Button_ToSource.TabIndex = 3;
		Button_ToSource.Text = "<";
		Button_ToDestination.BackColor = Color.Transparent;
		Button_ToDestination.DialogResult = DialogResult.None;
		Button_ToDestination.ForeColor = SystemColors.Control;
		Button_ToDestination.Location = new Point(280, 186);
		Button_ToDestination.Margin = new Padding(3, 4, 3, 4);
		Button_ToDestination.Name = "Button_ToDestination";
		Button_ToDestination.RoundRadius = 0;
		Button_ToDestination.Size = new Size(51, 85);
		Button_ToDestination.TabIndex = 2;
		Button_ToDestination.Text = ">";
		ButtonBreakIntoIndividualUnits.BackColor = Color.Transparent;
		ButtonBreakIntoIndividualUnits.DialogResult = DialogResult.None;
		ButtonBreakIntoIndividualUnits.ForeColor = SystemColors.Control;
		ButtonBreakIntoIndividualUnits.Location = new Point(14, 342);
		ButtonBreakIntoIndividualUnits.Margin = new Padding(3, 4, 3, 4);
		ButtonBreakIntoIndividualUnits.Name = "ButtonBreakIntoIndividualUnits";
		ButtonBreakIntoIndividualUnits.RoundRadius = 0;
		ButtonBreakIntoIndividualUnits.Size = new Size(259, 40);
		ButtonBreakIntoIndividualUnits.TabIndex = 9;
		ButtonBreakIntoIndividualUnits.Text = "Break into individual units";
		base.AutoScaleDimensions = new SizeF(9f, 20f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(609, 391);
		base.Controls.Add(ButtonBreakIntoIndividualUnits);
		base.Controls.Add(ButtonSplit);
		base.Controls.Add(TB_RenameDestination);
		base.Controls.Add(ButtonRenameSource);
		base.Controls.Add(TB_RenameSource);
		base.Controls.Add(Button_ToSource);
		base.Controls.Add(Button_ToDestination);
		base.Controls.Add(LV_TargetUnit);
		base.Controls.Add(LV_SourceUnit);
		base.Margin = new Padding(3, 4, 3, 4);
		MaximumSize = new Size(625, 430);
		MinimumSize = new Size(625, 430);
		base.Name = "SplitUnit";
		base.ShowIcon = false;
		Text = "SplitUnit";
		ResumeLayout(performLayout: false);
	}

	private void PrintInterruptibleSingleton(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SourceUnit))
		{
			RefreshSourceUnit();
			RefreshTargetUnit();
			if (LV_SourceUnit.Items.Count > 0)
			{
				LV_SourceUnit.SelectItem(0);
			}
			TB_RenameDestination.Text = "New Detachement";
			TB_RenameSource.Text = SourceUnit.Name;
		}
	}

	public void RefreshSourceUnit()
	{
		LV_SourceUnit.Items.Clear();
		foreach (Mount mount in SourceUnit.Mounts)
		{
			if (!TransferedMounts.ContainsKey(mount))
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = mount.Name;
				darkListItem.Tag = mount;
				LV_SourceUnit.Items.Add(darkListItem);
			}
		}
	}

	public void RefreshTargetUnit()
	{
		LV_TargetUnit.Items.Clear();
		foreach (Mount mount in SourceUnit.Mounts)
		{
			if (TransferedMounts.ContainsKey(mount))
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = mount.Name;
				darkListItem.Tag = mount;
				LV_TargetUnit.Items.Add(darkListItem);
			}
		}
	}

	public List<Mount> FetchTransferableMounts()
	{
		List<Mount> list = new List<Mount>();
		foreach (Mount mount in SourceUnit.Mounts)
		{
			if (!TransferedMounts.ContainsKey(mount))
			{
				list.Add(mount);
			}
		}
		return list;
	}

	private void DefineInterruptibleSingleton(object sender, EventArgs e)
	{
		if (LV_SourceUnit.SelectedItems.Count > 0)
		{
			Mount mount = (Mount)LV_SourceUnit.SelectedItems.ElementAt(0).Tag;
			if (!TransferedMounts.ContainsKey(mount))
			{
				TransferedMounts.Add(mount, mount);
			}
		}
		RefreshSourceUnit();
		RefreshTargetUnit();
	}

	private void PublishInterruptibleSingleton(object sender, EventArgs e)
	{
		if (LV_TargetUnit.SelectedItems.Count > 0)
		{
			Mount key = (Mount)LV_TargetUnit.SelectedItems.ElementAt(0).Tag;
			if (TransferedMounts.ContainsKey(key))
			{
				TransferedMounts.Remove(key);
			}
		}
		RefreshSourceUnit();
		RefreshTargetUnit();
	}

	private void AwakeInterruptibleSingleton(object sender, EventArgs e)
	{
		SourceUnit.Name = TB_RenameSource.Text;
	}

	private void QueryInterruptibleSingleton(object sender, EventArgs e)
	{
	}

	private void ResetInterruptibleSingleton(object sender, EventArgs e)
	{
		if (SourceUnit.Mounts.Count < 2)
		{
			Close();
			return;
		}
		Cargo[] cargo_ = new Cargo[0];
		for (int i = SourceUnit.Mounts.Count - 1; i >= 0; i += -1)
		{
			foreach (KeyValuePair<Mount, Mount> transferedMount in TransferedMounts)
			{
				if (SourceUnit.Mounts.ElementAt(i) == transferedMount.Key)
				{
					ArrayExtensions.Add(ref cargo_, new Cargo(SourceUnit, transferedMount.Key));
					SourceUnit.Mounts.RemoveAt(i);
					break;
				}
			}
		}
		List<ActiveUnit> list = Cargo.UnloadCargoAtLocation(SourceUnit, ref cargo_, null, SourceUnit.GetLatitude(), SourceUnit.GetLongitude(), SourceUnit.ParentScen, SourceUnit.GetUnitSide(), bool_0: false, bool_1: true);
		if (list.Count > 0)
		{
			list.ElementAt(0).Name = TB_RenameDestination.Text;
		}
		Close();
	}

	private void MapInterruptibleSingleton(object sender, EventArgs e)
	{
		Cargo[] gparam_ = new Cargo[0];
		if (SourceUnit.Mounts.Count < 2)
		{
			Close();
			return;
		}
		for (int i = SourceUnit.Mounts.Count - 1; i >= 1; i += -1)
		{
			ArrayExtensions.Add(ref gparam_, new Cargo(SourceUnit, SourceUnit.Mounts.ElementAt(i)));
			SourceUnit.Mounts.RemoveAt(i);
			List<ActiveUnit> list = Cargo.UnloadCargoAtLocation(SourceUnit, ref gparam_, null, SourceUnit.GetLatitude(), SourceUnit.GetLongitude(), SourceUnit.ParentScen, SourceUnit.GetUnitSide(), bool_0: false, bool_1: true);
			if (list.Count > 0)
			{
				list.ElementAt(0).Name = "New Detachment";
			}
		}
		Close();
	}
}
