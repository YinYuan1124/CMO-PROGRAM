using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Form_QuickTurnaround : DarkSecondaryFormBase
{
	private IContainer dicTests;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_QuickTurnaround")]
	private DarkCheckBox m_ConsumerTests;

	[AccessedThroughProperty("Combo_NumberOfSorties")]
	[CompilerGenerated]
	private DarkUIComboBox _FacadeTests;

	private Aircraft m_ReaderTests;

	private int _PropertyTests;

	private int m_ImporterTests;

	private bool _RepositoryTests;

	internal DarkCheckBox CB_QuickTurnaround
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteProduct;
			DarkCheckBox consumerTests = m_ConsumerTests;
			if (consumerTests != null)
			{
				consumerTests.CheckedChanged -= value2;
			}
			m_ConsumerTests = value;
			consumerTests = m_ConsumerTests;
			if (consumerTests != null)
			{
				consumerTests.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_NumberOfSorties
	{
		[CompilerGenerated]
		get
		{
			return _FacadeTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchProduct;
			DarkUIComboBox facadeTests = _FacadeTests;
			if (facadeTests != null)
			{
				facadeTests.SelectedIndexChanged -= value2;
			}
			_FacadeTests = value;
			facadeTests = _FacadeTests;
			if (facadeTests != null)
			{
				facadeTests.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_QuickTurnaroundInfo")]
	internal DarkLabel Label_QuickTurnaroundInfo
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public Form_QuickTurnaround()
	{
		base.FormClosing += ConnectProduct;
		base.Load += MoveProduct;
		base.KeyDown += ComputeProduct;
		CloneProduct();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && dicTests != null)
			{
				dicTests.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CloneProduct()
	{
		CB_QuickTurnaround = new DarkCheckBox();
		Combo_NumberOfSorties = new DarkUIComboBox();
		Label_QuickTurnaroundInfo = new DarkLabel();
		SuspendLayout();
		CB_QuickTurnaround.AutoSize = true;
		CB_QuickTurnaround.Location = new Point(11, 12);
		CB_QuickTurnaround.Name = "CB_QuickTurnaround";
		CB_QuickTurnaround.Size = new Size(161, 19);
		CB_QuickTurnaround.TabIndex = 0;
		CB_QuickTurnaround.Text = "启用快速再次出动";
		Combo_NumberOfSorties.BackColor = Color.Transparent;
		Combo_NumberOfSorties.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_NumberOfSorties.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_NumberOfSorties.Font = new Font("Segoe UI", 7f);
		Combo_NumberOfSorties.FormattingEnabled = true;
		Combo_NumberOfSorties.Location = new Point(178, 11);
		Combo_NumberOfSorties.Name = "Combo_NumberOfSorties";
		Combo_NumberOfSorties.Size = new Size(147, 21);
		Combo_NumberOfSorties.TabIndex = 1;
		Label_QuickTurnaroundInfo.AutoSize = true;
		Label_QuickTurnaroundInfo.ForeColor = Color.FromArgb(220, 220, 220);
		Label_QuickTurnaroundInfo.Location = new Point(331, 16);
		Label_QuickTurnaroundInfo.Name = "Label_QuickTurnaroundInfo";
		Label_QuickTurnaroundInfo.Size = new Size(155, 15);
		Label_QuickTurnaroundInfo.TabIndex = 2;
		Label_QuickTurnaroundInfo.Text = "Label_QuickTurnaroundInfo";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(483, 44);
		base.Controls.Add(Label_QuickTurnaroundInfo);
		base.Controls.Add(Combo_NumberOfSorties);
		base.Controls.Add(CB_QuickTurnaround);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Form_QuickTurnaround";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Hide;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "机载飞机的快速再次出动配置";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ConnectProduct(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Client.MustRefreshMainForm = true;
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
		}
	}

	private void MoveProduct(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		Text = Text + " " + Client.SelectedUnit.Name;
		_RepositoryTests = false;
		Label_QuickTurnaroundInfo.Text = "";
		CB_QuickTurnaround.Enabled = false;
		Combo_NumberOfSorties.Enabled = false;
		if (!Information.IsNothing(Client.SelectedUnit) && Client.SelectedUnit.IsAircraft)
		{
			m_ReaderTests = (Aircraft)Client.SelectedUnit;
			if (!Information.IsNothing(m_ReaderTests.Loadout) && m_ReaderTests.Loadout.QuickTurnaround)
			{
				Aircraft_AirOps airOps = m_ReaderTests.AirOps;
				m_ImporterTests = m_ReaderTests.Loadout.QuickTurnaround_MaxSorties;
				CB_QuickTurnaround.Enabled = true;
				CB_QuickTurnaround.Checked = airOps.QuickTurnaround_Enabled;
				Combo_NumberOfSorties.Enabled = airOps.QuickTurnaround_Enabled;
				AddProduct(airOps.QuickTurnaround_SortiesTotal, ref m_ReaderTests);
			}
		}
		_RepositoryTests = true;
	}

	private void DeleteProduct(object sender, EventArgs e)
	{
		if (_RepositoryTests)
		{
			AddProduct(m_ImporterTests, ref m_ReaderTests);
		}
	}

	private void AddProduct(int? nullable_0, ref Aircraft aircraft_0)
	{
		Aircraft_AirOps airOps = aircraft_0.AirOps;
		if (airOps.QuickTurnaround_SortiesFlown <= 0)
		{
			airOps.QuickTurnaround_SortiesFlown = 1;
		}
		if (CB_QuickTurnaround.Checked)
		{
			Combo_NumberOfSorties.Enabled = true;
			DestroyProduct(nullable_0);
			Label_QuickTurnaroundInfo.Enabled = true;
			Label_QuickTurnaroundInfo.Text = ItemExporter.ConnectInterruptibleTemplate.AirOps.QuickTurnaroundPenaltyText();
			if (_RepositoryTests)
			{
				airOps.QuickTurnaround_Enabled = true;
			}
		}
		else
		{
			Combo_NumberOfSorties.Enabled = false;
			DestroyProduct(nullable_0);
			Label_QuickTurnaroundInfo.Enabled = false;
			Label_QuickTurnaroundInfo.Text = "";
			if (_RepositoryTests)
			{
				airOps.QuickTurnaround_Enabled = false;
			}
		}
	}

	private void DestroyProduct(int? nullable_0)
	{
		Combo_NumberOfSorties.Items.Clear();
		Combo_NumberOfSorties.SelectedIndex = -1;
		if (CB_QuickTurnaround.Checked)
		{
			int importerTests = m_ImporterTests;
			for (int i = 2; i <= importerTests; i++)
			{
				if (i == m_ImporterTests)
				{
					Combo_NumberOfSorties.Items.Add(Conversions.ToString(i) + "架次（最大）");
				}
				else
				{
					Combo_NumberOfSorties.Items.Add(Conversions.ToString(i) + "架次");
				}
			}
			Aircraft_AirOps airOps = m_ReaderTests.AirOps;
			if (_RepositoryTests)
			{
				Combo_NumberOfSorties.SelectedIndex = m_ImporterTests - 2;
			}
			else
			{
				Combo_NumberOfSorties.SelectedIndex = airOps.QuickTurnaround_SortiesTotal - 2;
			}
			if (Combo_NumberOfSorties.SelectedIndex + 2 <= m_ReaderTests.Loadout.QuickTurnaround_MaxSorties)
			{
				airOps.QuickTurnaround_SortiesTotal = Combo_NumberOfSorties.SelectedIndex + 2;
			}
		}
		Label_QuickTurnaroundInfo.Text = ItemExporter.ConnectInterruptibleTemplate.AirOps.QuickTurnaroundPenaltyText();
	}

	private void ComputeProduct(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PatchProduct(object sender, EventArgs e)
	{
		Label_QuickTurnaroundInfo.Text = ItemExporter.ConnectInterruptibleTemplate.AirOps.QuickTurnaroundPenaltyText();
		if (_RepositoryTests)
		{
			Aircraft_AirOps airOps = m_ReaderTests.AirOps;
			if (Combo_NumberOfSorties.SelectedIndex + 2 <= m_ReaderTests.Loadout.QuickTurnaround_MaxSorties)
			{
				airOps.QuickTurnaround_SortiesTotal = Combo_NumberOfSorties.SelectedIndex + 2;
			}
		}
	}
}
