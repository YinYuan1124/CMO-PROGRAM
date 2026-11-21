using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class UnitSelection_UC : UserControl
{
	private IContainer m_ListenerVisitor;

	[AccessedThroughProperty("ButtonToggle_ShowSpaceUnit_Unassigned")]
	[CompilerGenerated]
	private Button _ConfigVisitor;

	[AccessedThroughProperty("ButtonToggle_ShowLandUnit_Unassigned")]
	[CompilerGenerated]
	private Button _RegistryVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowAirUnit_Unassigned")]
	private Button definitionVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowNavalUnit_Unassigned")]
	private Button _ValVisitor;

	[AccessedThroughProperty("LV_Units")]
	[CompilerGenerated]
	private DarkListView m_ObserverVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Filter")]
	private DarkUITextBox m_IssuerVisitor;

	[AccessedThroughProperty("Button_Filter")]
	[CompilerGenerated]
	private DarkUIButton m_ClientVisitor;

	[AccessedThroughProperty("Button_Action_Delete")]
	[CompilerGenerated]
	private DarkUIButton dicVisitor;

	[AccessedThroughProperty("ButtonToggle_ShowRP")]
	[CompilerGenerated]
	private Button consumerVisitor;

	[AccessedThroughProperty("ButtonToggle_ShowStandardZone")]
	[CompilerGenerated]
	private Button facadeVisitor;

	[AccessedThroughProperty("TableLayoutPanel1")]
	[CompilerGenerated]
	private TableLayoutPanel m_ProxyVisitor;

	[AccessedThroughProperty("Button_AddSelected")]
	[CompilerGenerated]
	private DarkUIButton propertyVisitor;

	private bool _ImporterVisitor;

	private bool m_RepositoryVisitor;

	private bool bridgeVisitor;

	private bool _InvocationVisitor;

	private bool _ClassVisitor;

	private bool _RequestVisitor;

	private bool valueVisitor;

	public UnitSelection.UnitSelectionConfig Configuration;

	public Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)> StaticUnitList;

	private List<Side> _TokenizerVisitor;

	private E_UnitSelectionMode _StubVisitor;

	internal virtual Button ButtonToggle_ShowSpaceUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return _ConfigVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderInterruptibleComparator;
			Button configVisitor = _ConfigVisitor;
			if (configVisitor != null)
			{
				configVisitor.Click -= value2;
			}
			_ConfigVisitor = value;
			configVisitor = _ConfigVisitor;
			if (configVisitor != null)
			{
				configVisitor.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowLandUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return _RegistryVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectInterruptibleComparator;
			Button registryVisitor = _RegistryVisitor;
			if (registryVisitor != null)
			{
				registryVisitor.Click -= value2;
			}
			_RegistryVisitor = value;
			registryVisitor = _RegistryVisitor;
			if (registryVisitor != null)
			{
				registryVisitor.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowAirUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return definitionVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotInterruptibleComparator;
			Button button = definitionVisitor;
			if (button != null)
			{
				button.Click -= value2;
			}
			definitionVisitor = value;
			button = definitionVisitor;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowNavalUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return _ValVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushInterruptibleComparator;
			Button valVisitor = _ValVisitor;
			if (valVisitor != null)
			{
				valVisitor.Click -= value2;
			}
			_ValVisitor = value;
			valVisitor = _ValVisitor;
			if (valVisitor != null)
			{
				valVisitor.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Button_Confirm")]
	internal virtual DarkUIButton Button_Confirm
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkListView LV_Units
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectInterruptibleItem;
			EventHandler value3 = ComputeInterruptibleItem;
			DarkListView observerVisitor = m_ObserverVisitor;
			if (observerVisitor != null)
			{
				observerVisitor.SelectedIndicesChanged -= value2;
				observerVisitor.SelectedIndicesChanged -= value3;
			}
			m_ObserverVisitor = value;
			observerVisitor = m_ObserverVisitor;
			if (observerVisitor != null)
			{
				observerVisitor.SelectedIndicesChanged += value2;
				observerVisitor.SelectedIndicesChanged += value3;
			}
		}
	}

	internal virtual DarkUITextBox TB_Filter
	{
		[CompilerGenerated]
		get
		{
			return m_IssuerVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IssuerVisitor = value;
		}
	}

	internal virtual DarkUIButton Button_Filter
	{
		[CompilerGenerated]
		get
		{
			return m_ClientVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveInterruptibleItem;
			DarkUIButton clientVisitor = m_ClientVisitor;
			if (clientVisitor != null)
			{
				clientVisitor.Click -= value2;
			}
			m_ClientVisitor = value;
			clientVisitor = m_ClientVisitor;
			if (clientVisitor != null)
			{
				clientVisitor.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_Action_Delete
	{
		[CompilerGenerated]
		get
		{
			return dicVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteInterruptibleItem;
			DarkUIButton darkUIButton = dicVisitor;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			dicVisitor = value;
			darkUIButton = dicVisitor;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowRP
	{
		[CompilerGenerated]
		get
		{
			return consumerVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddInterruptibleItem;
			Button button = consumerVisitor;
			if (button != null)
			{
				button.Click -= value2;
			}
			consumerVisitor = value;
			button = consumerVisitor;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowStandardZone
	{
		[CompilerGenerated]
		get
		{
			return facadeVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyInterruptibleItem;
			Button button = facadeVisitor;
			if (button != null)
			{
				button.Click -= value2;
			}
			facadeVisitor = value;
			button = facadeVisitor;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProxyVisitor = value;
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel2")]
	internal virtual TableLayoutPanel TableLayoutPanel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton Button_AddSelected
	{
		[CompilerGenerated]
		get
		{
			return propertyVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			propertyVisitor = value;
		}
	}

	public E_UnitSelectionMode Mode
	{
		get
		{
			return _StubVisitor;
		}
		set
		{
			_StubVisitor = value;
		}
	}

	public UnitSelection_UC()
	{
		_ImporterVisitor = true;
		m_RepositoryVisitor = true;
		bridgeVisitor = true;
		_InvocationVisitor = true;
		_ClassVisitor = true;
		_RequestVisitor = true;
		valueVisitor = true;
		StaticUnitList = new Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)>();
		_TokenizerVisitor = new List<Side>();
		CalcInterruptibleComparator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ListenerVisitor != null)
			{
				m_ListenerVisitor.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalcInterruptibleComparator()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(UnitSelection_UC));
		TableLayoutPanel1 = new TableLayoutPanel();
		ButtonToggle_ShowRP = new Button();
		ButtonToggle_ShowNavalUnit_Unassigned = new Button();
		ButtonToggle_ShowSpaceUnit_Unassigned = new Button();
		ButtonToggle_ShowLandUnit_Unassigned = new Button();
		ButtonToggle_ShowStandardZone = new Button();
		ButtonToggle_ShowAirUnit_Unassigned = new Button();
		TableLayoutPanel2 = new TableLayoutPanel();
		Button_AddSelected = new DarkUIButton();
		Button_Confirm = new DarkUIButton();
		Button_Action_Delete = new DarkUIButton();
		LV_Units = new DarkListView();
		Button_Filter = new DarkUIButton();
		TB_Filter = new DarkUITextBox();
		TableLayoutPanel1.SuspendLayout();
		TableLayoutPanel2.SuspendLayout();
		SuspendLayout();
		TableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TableLayoutPanel1.ColumnCount = 6;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667f));
		TableLayoutPanel1.Controls.Add(ButtonToggle_ShowRP, 5, 0);
		TableLayoutPanel1.Controls.Add(ButtonToggle_ShowNavalUnit_Unassigned, 1, 0);
		TableLayoutPanel1.Controls.Add(ButtonToggle_ShowSpaceUnit_Unassigned, 2, 0);
		TableLayoutPanel1.Controls.Add(ButtonToggle_ShowLandUnit_Unassigned, 0, 0);
		TableLayoutPanel1.Controls.Add(ButtonToggle_ShowStandardZone, 4, 0);
		TableLayoutPanel1.Controls.Add(ButtonToggle_ShowAirUnit_Unassigned, 3, 0);
		TableLayoutPanel1.Location = new Point(3, 0);
		TableLayoutPanel1.MaximumSize = new Size(250, 31);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel1.Size = new Size(247, 31);
		TableLayoutPanel1.TabIndex = 46;
		ButtonToggle_ShowRP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonToggle_ShowRP.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowRP.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowRP.BackgroundImage");
		ButtonToggle_ShowRP.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowRP.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowRP.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowRP.Location = new Point(208, 3);
		ButtonToggle_ShowRP.Name = "ButtonToggle_ShowRP";
		ButtonToggle_ShowRP.Size = new Size(36, 25);
		ButtonToggle_ShowRP.TabIndex = 37;
		ButtonToggle_ShowRP.UseVisualStyleBackColor = false;
		ButtonToggle_ShowNavalUnit_Unassigned.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonToggle_ShowNavalUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowNavalUnit_Unassigned.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowNavalUnit_Unassigned.BackgroundImage");
		ButtonToggle_ShowNavalUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowNavalUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowNavalUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowNavalUnit_Unassigned.Location = new Point(44, 3);
		ButtonToggle_ShowNavalUnit_Unassigned.Name = "ButtonToggle_ShowNavalUnit_Unassigned";
		ButtonToggle_ShowNavalUnit_Unassigned.Size = new Size(35, 25);
		ButtonToggle_ShowNavalUnit_Unassigned.TabIndex = 33;
		ButtonToggle_ShowNavalUnit_Unassigned.UseVisualStyleBackColor = false;
		ButtonToggle_ShowSpaceUnit_Unassigned.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonToggle_ShowSpaceUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowSpaceUnit_Unassigned.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowSpaceUnit_Unassigned.BackgroundImage");
		ButtonToggle_ShowSpaceUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowSpaceUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowSpaceUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowSpaceUnit_Unassigned.Location = new Point(85, 3);
		ButtonToggle_ShowSpaceUnit_Unassigned.Name = "ButtonToggle_ShowSpaceUnit_Unassigned";
		ButtonToggle_ShowSpaceUnit_Unassigned.Size = new Size(35, 25);
		ButtonToggle_ShowSpaceUnit_Unassigned.TabIndex = 36;
		ButtonToggle_ShowSpaceUnit_Unassigned.UseVisualStyleBackColor = false;
		ButtonToggle_ShowLandUnit_Unassigned.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonToggle_ShowLandUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowLandUnit_Unassigned.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowLandUnit_Unassigned.BackgroundImage");
		ButtonToggle_ShowLandUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowLandUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowLandUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowLandUnit_Unassigned.Location = new Point(3, 3);
		ButtonToggle_ShowLandUnit_Unassigned.Name = "ButtonToggle_ShowLandUnit_Unassigned";
		ButtonToggle_ShowLandUnit_Unassigned.Size = new Size(35, 25);
		ButtonToggle_ShowLandUnit_Unassigned.TabIndex = 35;
		ButtonToggle_ShowLandUnit_Unassigned.UseVisualStyleBackColor = false;
		ButtonToggle_ShowStandardZone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonToggle_ShowStandardZone.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowStandardZone.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowStandardZone.BackgroundImage");
		ButtonToggle_ShowStandardZone.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowStandardZone.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowStandardZone.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowStandardZone.Location = new Point(167, 3);
		ButtonToggle_ShowStandardZone.Name = "ButtonToggle_ShowStandardZone";
		ButtonToggle_ShowStandardZone.Size = new Size(35, 25);
		ButtonToggle_ShowStandardZone.TabIndex = 38;
		ButtonToggle_ShowStandardZone.UseVisualStyleBackColor = false;
		ButtonToggle_ShowAirUnit_Unassigned.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonToggle_ShowAirUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowAirUnit_Unassigned.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowAirUnit_Unassigned.BackgroundImage");
		ButtonToggle_ShowAirUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowAirUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowAirUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowAirUnit_Unassigned.Location = new Point(126, 3);
		ButtonToggle_ShowAirUnit_Unassigned.Name = "ButtonToggle_ShowAirUnit_Unassigned";
		ButtonToggle_ShowAirUnit_Unassigned.Size = new Size(35, 25);
		ButtonToggle_ShowAirUnit_Unassigned.TabIndex = 34;
		ButtonToggle_ShowAirUnit_Unassigned.UseVisualStyleBackColor = false;
		TableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TableLayoutPanel2.ColumnCount = 4;
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
		TableLayoutPanel2.Controls.Add(Button_AddSelected, 0, 0);
		TableLayoutPanel2.Controls.Add(Button_Confirm, 2, 0);
		TableLayoutPanel2.Controls.Add(Button_Action_Delete, 0, 0);
		TableLayoutPanel2.Location = new Point(0, 320);
		TableLayoutPanel2.Name = "TableLayoutPanel2";
		TableLayoutPanel2.RowCount = 1;
		TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel2.Size = new Size(259, 25);
		TableLayoutPanel2.TabIndex = 47;
		Button_AddSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_AddSelected.BackColor = Color.Transparent;
		Button_AddSelected.DialogResult = DialogResult.OK;
		Button_AddSelected.Font = new Font("Segoe UI", 8.25f);
		Button_AddSelected.ForeColor = SystemColors.Control;
		Button_AddSelected.Location = new Point(73, 3);
		Button_AddSelected.Name = "Button_AddSelected";
		Button_AddSelected.Padding = new Padding(5);
		Button_AddSelected.RoundRadius = 0;
		Button_AddSelected.Size = new Size(111, 19);
		Button_AddSelected.TabIndex = 43;
		Button_AddSelected.Text = "Add Selected (map)";
		Button_Confirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Confirm.BackColor = Color.Transparent;
		Button_Confirm.DialogResult = DialogResult.OK;
		Button_Confirm.Font = new Font("Segoe UI", 8.25f);
		Button_Confirm.ForeColor = SystemColors.Control;
		Button_Confirm.Location = new Point(190, 3);
		Button_Confirm.Name = "Button_Confirm";
		Button_Confirm.Padding = new Padding(5);
		Button_Confirm.RoundRadius = 0;
		Button_Confirm.Size = new Size(68, 19);
		Button_Confirm.TabIndex = 38;
		Button_Confirm.Text = "确认";
		Button_Action_Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Action_Delete.BackColor = Color.Transparent;
		Button_Action_Delete.DialogResult = DialogResult.OK;
		Button_Action_Delete.Font = new Font("Segoe UI", 8.25f);
		Button_Action_Delete.ForeColor = SystemColors.Control;
		Button_Action_Delete.Location = new Point(3, 3);
		Button_Action_Delete.Name = "Button_Action_Delete";
		Button_Action_Delete.Padding = new Padding(5);
		Button_Action_Delete.RoundRadius = 0;
		Button_Action_Delete.Size = new Size(64, 19);
		Button_Action_Delete.TabIndex = 41;
		Button_Action_Delete.Text = "删除";
		LV_Units.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LV_Units.BackColor = Color.FromArgb(40, 43, 45);
		LV_Units.Location = new Point(3, 59);
		LV_Units.Name = "LV_Units";
		LV_Units.RelatedInfos = null;
		LV_Units.Size = new Size(256, 256);
		LV_Units.TabIndex = 41;
		LV_Units.Text = "LV_Units";
		Button_Filter.BackColor = Color.Transparent;
		Button_Filter.DialogResult = DialogResult.None;
		Button_Filter.Font = new Font("Segoe UI", 8.25f);
		Button_Filter.ForeColor = SystemColors.Control;
		Button_Filter.Location = new Point(172, 34);
		Button_Filter.Name = "Button_Filter";
		Button_Filter.Padding = new Padding(5);
		Button_Filter.RoundRadius = 0;
		Button_Filter.Size = new Size(27, 19);
		Button_Filter.TabIndex = 43;
		Button_Filter.Text = "开始";
		TB_Filter.AutoCompleteCustomSource = null;
		TB_Filter.AutoCompleteMode = AutoCompleteMode.None;
		TB_Filter.AutoCompleteSource = AutoCompleteSource.None;
		TB_Filter.BackColor = Color.Transparent;
		TB_Filter.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Filter.Image = null;
		TB_Filter.Lines = null;
		TB_Filter.Location = new Point(3, 34);
		TB_Filter.MaxLength = 32767;
		TB_Filter.Multiline = false;
		TB_Filter.Name = "TB_Filter";
		TB_Filter.ReadOnly = false;
		TB_Filter.ScrollBars = ScrollBars.None;
		TB_Filter.SelectionStart = 0;
		TB_Filter.Size = new Size(161, 19);
		TB_Filter.TabIndex = 42;
		TB_Filter.TextAlign = HorizontalAlignment.Left;
		TB_Filter.UseSystemPasswordChar = false;
		TB_Filter.WatermarkText = "Filter by name, class, side.";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.Controls.Add(TableLayoutPanel2);
		base.Controls.Add(TableLayoutPanel1);
		base.Controls.Add(Button_Filter);
		base.Controls.Add(TB_Filter);
		base.Controls.Add(LV_Units);
		base.Name = "UnitSelection_UC";
		base.Size = new Size(262, 348);
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		TableLayoutPanel2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	public void Initialise(UnitSelection.UnitSelectionConfig unitSelectionConfig_0, List<ActiveUnit> list_0, List<Side> list_1, bool bool_0 = true)
	{
		if (unitSelectionConfig_0 == null)
		{
			Configuration = UnitSelection.UnitSelectionConfig.DefaultUnitSelection();
		}
		else
		{
			Configuration = unitSelectionConfig_0;
		}
		Button_Action_Delete.Visible = list_0.Count > 0 || Client.CurrentGame.GameMode == Game._GameMode.ScenEdit || Client.CurrentGame.GameMode == Game._GameMode.MultiplayerScenEdit;
		LV_Units.MultiSelect = bool_0;
		_TokenizerVisitor = list_1;
		RefreshFilter();
		RefreshUnitList();
	}

	public void FetchSelectedUnits(ref List<ActiveUnit> list_0, ref List<ReferencePoint> list_1, ref List<Zone> list_2, bool bool_0 = false)
	{
		list_0 = new List<ActiveUnit>();
		list_1 = new List<ReferencePoint>();
		list_2 = new List<Zone>();
		foreach (DarkListItem selectedItem in LV_Units.SelectedItems)
		{
			if (selectedItem.Tag == null)
			{
				continue;
			}
			if (selectedItem.Tag is ActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)selectedItem.Tag;
				if ((!bool_0 || Configuration.FulfillConditions(activeUnit)) && !activeUnit.IsDestroyed)
				{
					list_0.Add(activeUnit);
				}
			}
			else if (selectedItem.Tag is ReferencePoint)
			{
				ReferencePoint item = (ReferencePoint)selectedItem.Tag;
				list_1.Add(item);
			}
			else if (selectedItem.Tag is Zone)
			{
				Zone item2 = (Zone)selectedItem.Tag;
				list_2.Add(item2);
			}
		}
	}

	public List<ActiveUnit> FetchSelectedUnits()
	{
		List<ActiveUnit> list_ = new List<ActiveUnit>();
		List<ReferencePoint> list_2 = null;
		List<Zone> list_3 = null;
		FetchSelectedUnits(ref list_, ref list_2, ref list_3);
		return list_;
	}

	public List<Contact> FetchSelectedContact(bool bool_0 = false)
	{
		List<Contact> list = new List<Contact>();
		foreach (DarkListItem selectedItem in LV_Units.SelectedItems)
		{
			if (selectedItem.Tag != null && selectedItem.Tag is Contact)
			{
				Contact contact = (Contact)selectedItem.Tag;
				if (!bool_0 || Configuration.FulfillConditions(contact))
				{
					list.Add(contact);
				}
			}
		}
		return list;
	}

	public List<ActiveUnit> FetchUnits(bool bool_0 = false)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (Module_Unit.Unit key in StaticUnitList.Keys)
		{
			if (key != null && key is ActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)key;
				if (!bool_0 || Configuration.FulfillConditions(activeUnit))
				{
					list.Add(activeUnit);
				}
			}
		}
		return list;
	}

	public List<Contact> FetchContacts(bool bool_0 = false)
	{
		List<Contact> list = new List<Contact>();
		foreach (Module_Unit.Unit key in StaticUnitList.Keys)
		{
			if (key != null && key is Contact)
			{
				Contact contact = (Contact)key;
				if (!bool_0 || Configuration.FulfillConditions(contact))
				{
					list.Add(contact);
				}
			}
		}
		return list;
	}

	private bool RateInterruptibleComparator(Module_Unit.Unit unit_0, string string_0, bool bool_0 = true)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return true;
		}
		if (bool_0)
		{
			string[] array = string_0.Split(' ');
			string text = unit_0.Name.ToLower();
			if (unit_0.UnitClass != null)
			{
				text += unit_0.UnitClass.ToLower();
			}
			if (unit_0.GetUnitSide() != null)
			{
				text += unit_0.GetUnitSide().Name.ToLower();
			}
			string[] array2 = array;
			int num = 0;
			while (true)
			{
				if (num < array2.Length)
				{
					string value = array2[num];
					if (!string.IsNullOrWhiteSpace(value) && !text.Contains(value))
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
		if (unit_0.Name.ToLower().Contains(string_0))
		{
			return true;
		}
		if (unit_0.UnitClass.ToLower().Contains(string_0))
		{
			return true;
		}
		if (unit_0.GetUnitSide().Name.ToLower().Contains(string_0))
		{
			return true;
		}
		return false;
	}

	public void RefreshFilter()
	{
		ButtonToggle_ShowLandUnit_Unassigned.Visible = false;
		ButtonToggle_ShowAirUnit_Unassigned.Visible = false;
		ButtonToggle_ShowNavalUnit_Unassigned.Visible = false;
		ButtonToggle_ShowSpaceUnit_Unassigned.Visible = false;
		ButtonToggle_ShowStandardZone.Visible = false;
		ButtonToggle_ShowRP.Visible = false;
		_ImporterVisitor = false;
		m_RepositoryVisitor = false;
		bridgeVisitor = false;
		_InvocationVisitor = false;
		_ClassVisitor = false;
		_RequestVisitor = false;
		valueVisitor = false;
		if (Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsAircraft).GetValueOrDefault())
		{
			ButtonToggle_ShowAirUnit_Unassigned.Visible = true;
			_ImporterVisitor = true;
		}
		else if (!Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsBoat).GetValueOrDefault() && !Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsShip).GetValueOrDefault())
		{
			if (!Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsFacility).GetValueOrDefault() && !Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsMobileGroundUnit).GetValueOrDefault())
			{
				if (Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsSatellite).GetValueOrDefault())
				{
					ButtonToggle_ShowSpaceUnit_Unassigned.Visible = true;
					_InvocationVisitor = true;
				}
				else if (Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsRP).GetValueOrDefault())
				{
					ButtonToggle_ShowRP.Visible = true;
					_RequestVisitor = true;
				}
				else if (Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsStandardZone).GetValueOrDefault())
				{
					ButtonToggle_ShowStandardZone.Visible = true;
					valueVisitor = true;
				}
				else if (Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsGroup).GetValueOrDefault())
				{
					_ClassVisitor = true;
				}
				else if (!Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsAirbase).GetValueOrDefault() && !Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsDock).GetValueOrDefault())
				{
					if (Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsCargoMissionDestination).GetValueOrDefault())
					{
						ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
						bridgeVisitor = true;
						ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
						m_RepositoryVisitor = true;
						return;
					}
					ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
					ButtonToggle_ShowAirUnit_Unassigned.Visible = true;
					ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
					ButtonToggle_ShowSpaceUnit_Unassigned.Visible = true;
					ButtonToggle_ShowStandardZone.Visible = true;
					ButtonToggle_ShowRP.Visible = true;
					_ImporterVisitor = true;
					m_RepositoryVisitor = true;
					bridgeVisitor = true;
					_InvocationVisitor = true;
					_RequestVisitor = true;
					valueVisitor = true;
					bool? conditionValue = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsAircraft);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowAirUnit_Unassigned.Visible = false;
						_ImporterVisitor = false;
					}
					bool? conditionValue2 = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsBoat);
					conditionValue = (!conditionValue2) ?? conditionValue2;
					if (conditionValue.GetValueOrDefault(true))
					{
						conditionValue2 = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsShip);
						if (((!conditionValue2) ?? conditionValue2).GetValueOrDefault() && conditionValue.HasValue)
						{
							ButtonToggle_ShowNavalUnit_Unassigned.Visible = false;
							bridgeVisitor = false;
						}
					}
					bool? conditionValue3 = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsFacility);
					bool? flag;
					conditionValue3 = (flag = (!conditionValue3) ?? conditionValue3);
					bool? flag2;
					bool? flag3;
					if (conditionValue3.HasValue && !flag.GetValueOrDefault())
					{
						flag2 = false;
					}
					else
					{
						conditionValue3 = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsMobileGroundUnit);
						conditionValue3 = (flag3 = (!conditionValue3) ?? conditionValue3);
						flag2 = ((!conditionValue3.HasValue) ? null : (flag3.GetValueOrDefault() & flag));
					}
					conditionValue2 = flag2;
					flag3 = flag2;
					bool? flag4;
					if (flag3.HasValue && !conditionValue2.GetValueOrDefault())
					{
						flag4 = false;
					}
					else
					{
						flag3 = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsAirbase);
						bool? flag5;
						flag3 = (flag5 = (!flag3) ?? flag3);
						flag4 = ((!flag3.HasValue) ? null : (flag5.GetValueOrDefault() & conditionValue2));
					}
					conditionValue = flag4;
					if (conditionValue.GetValueOrDefault(true))
					{
						bool? conditionValue4 = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsDock);
						if (((!conditionValue4) ?? conditionValue4).GetValueOrDefault() && conditionValue.HasValue)
						{
							ButtonToggle_ShowLandUnit_Unassigned.Visible = false;
							m_RepositoryVisitor = false;
						}
					}
					conditionValue = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsSatellite);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowSpaceUnit_Unassigned.Visible = false;
						_InvocationVisitor = false;
					}
					conditionValue = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsStandardZone);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowStandardZone.Visible = false;
						valueVisitor = false;
					}
					conditionValue = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsRP);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowRP.Visible = false;
						_RequestVisitor = false;
					}
					conditionValue = Configuration.GetConditionValue(UnitSelection.UnitSelectionConfig.Condition.IsGroup);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						_ClassVisitor = false;
					}
				}
				else
				{
					ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
					bridgeVisitor = true;
					ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
					m_RepositoryVisitor = true;
				}
			}
			else
			{
				ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
				m_RepositoryVisitor = true;
			}
		}
		else
		{
			ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
			bridgeVisitor = true;
		}
	}

	public void AddUnit(Module_Unit.Unit unit_0, string string_0 = "")
	{
		if (!StaticUnitList.ContainsKey(unit_0))
		{
			StaticUnitList.Add(unit_0, (unit_0, string_0));
		}
	}

	public void RemoveUnit(Module_Unit.Unit unit_0)
	{
		if (!StaticUnitList.ContainsKey(unit_0))
		{
			StaticUnitList.Remove(unit_0);
		}
	}

	public void RemoveUnitFromList(Module_Unit.Unit unit_0)
	{
		List<DarkListItem> list = new List<DarkListItem>();
		foreach (DarkListItem item in LV_Units.Items)
		{
			if (item.Tag != null && item.Tag is Module_Unit.Unit && unit_0 == (Module_Unit.Unit)item.Tag)
			{
				list.Add(item);
			}
		}
		foreach (DarkListItem item2 in list)
		{
			LV_Units.Items.Remove(item2);
		}
	}

	public void AddUnitToList(Module_Unit.Unit unit_0, string string_0 = "")
	{
		string text = TB_Filter.Text.ToLower();
		Module_Unit.Unit unit = null;
		if (unit_0.DisableWriter())
		{
			Contact contact = (Contact)unit_0;
			if (contact.IDStatus == Contact_Base.IdentificationStatus.KnownDomain && contact.ActualUnit != null)
			{
				unit = contact.ActualUnit;
			}
		}
		else
		{
			unit = unit_0;
		}
		if ((unit != null && ((unit_0.IsAircraft && !_ImporterVisitor) || ((unit_0.IsFacility || unit_0.IsMobileGroundUnit) && !m_RepositoryVisitor) || ((unit_0.IsShip || unit_0.IsBoat) && !bridgeVisitor) || (unit_0.IsSatellite && !_InvocationVisitor) || (unit_0.IsGroup && !_ClassVisitor))) || (!string.IsNullOrWhiteSpace(text) && !RateInterruptibleComparator(unit_0, text)) || !Configuration.FulfillConditions(unit_0))
		{
			return;
		}
		string text2 = string_0;
		if (string.IsNullOrEmpty(text2))
		{
			text2 = unit_0.Name + " - " + unit_0.UnitClass;
			if (unit_0.IsGroup)
			{
				text2 = unit_0.Name + " - " + ((ActiveUnit)unit_0).SubTypeDescription;
			}
		}
		DarkListItem darkListItem;
		if (_TokenizerVisitor.Count <= 1)
		{
			darkListItem = new DarkListItem(text2);
		}
		else
		{
			darkListItem = new DarkListItem("[" + unit_0.GetUnitSide().Name + "] " + text2);
			if (unit_0.GetUnitSide().AssignedFixedColor.HasValue)
			{
				darkListItem.TextColor = unit_0.GetUnitSide().AssignedFixedColor.Value;
			}
		}
		darkListItem.Tag = unit_0;
		LV_Units.Items.Add(darkListItem);
	}

	public void RefreshUnitList(List<ActiveUnit> list_0)
	{
		Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)> dictionary = new Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)>();
		foreach (ActiveUnit item in list_0)
		{
			dictionary.Add(item, (item, ""));
		}
		RefreshUnitList(dictionary);
	}

	public void RefreshUnitList(List<Module_Unit.Unit> list_0)
	{
		Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)> dictionary = new Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)>();
		foreach (Module_Unit.Unit item in list_0)
		{
			dictionary.Add(item, (item, ""));
		}
		RefreshUnitList(dictionary);
	}

	public void RefreshUnitList(Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)> dictionary_0 = null)
	{
		int num = -1;
		if (LV_Units.SelectedIndices.Count > 0)
		{
			num = LV_Units.SelectedIndices.ElementAt(0);
		}
		LV_Units.Items.Clear();
		if (dictionary_0 != null)
		{
			StaticUnitList = dictionary_0;
		}
		if (StaticUnitList.Count <= 0)
		{
			foreach (Side item in _TokenizerVisitor)
			{
				foreach (ActiveUnit unit in item.Units)
				{
					AddUnitToList(unit);
				}
				if (_RequestVisitor && StaticUnitList.Count == 0)
				{
					foreach (ReferencePoint refPoint in item.RefPoints)
					{
						DarkListItem darkListItem;
						if (_TokenizerVisitor.Count <= 1)
						{
							darkListItem = new DarkListItem(refPoint.Name);
						}
						else
						{
							darkListItem = new DarkListItem("[" + item.Name + "] " + refPoint.Name);
							if (item.AssignedFixedColor.HasValue)
							{
								darkListItem.TextColor = item.AssignedFixedColor.Value;
							}
						}
						darkListItem.Tag = refPoint;
						LV_Units.Items.Add(darkListItem);
					}
				}
				if (!valueVisitor || StaticUnitList.Count != 0)
				{
					continue;
				}
				foreach (Zone standardZone in item.StandardZones)
				{
					DarkListItem darkListItem2;
					if (_TokenizerVisitor.Count <= 1)
					{
						darkListItem2 = new DarkListItem(standardZone.Description);
					}
					else
					{
						darkListItem2 = new DarkListItem("[" + item.Name + "] " + standardZone.Description);
						if (item.AssignedFixedColor.HasValue)
						{
							darkListItem2.TextColor = item.AssignedFixedColor.Value;
						}
					}
					darkListItem2.Tag = standardZone;
					LV_Units.Items.Add(darkListItem2);
				}
			}
		}
		else
		{
			foreach (KeyValuePair<Module_Unit.Unit, (Module_Unit.Unit, string)> staticUnit in StaticUnitList)
			{
				AddUnitToList(staticUnit.Key, staticUnit.Value.Item2);
			}
		}
		if (LV_Units.Items.Count > 0)
		{
			if (num == -1)
			{
				LV_Units.SelectItem(0);
			}
			else if (num <= LV_Units.Items.Count - 1)
			{
				LV_Units.SelectItem(num);
			}
			else
			{
				LV_Units.SelectItem(LV_Units.Items.Count - 1);
			}
		}
		Button_Confirm.Visible = Mode == E_UnitSelectionMode.Fetch;
		Button_Action_Delete.Visible = Mode == E_UnitSelectionMode.Assign || Client.CurrentGame.GameMode == Game._GameMode.ScenEdit || Client.CurrentGame.GameMode == Game._GameMode.MultiplayerScenEdit;
		Refresh();
	}

	private void FlushInterruptibleComparator(object sender, EventArgs e)
	{
		RegisterInterruptibleComparator();
	}

	private void ForgotInterruptibleComparator(object sender, EventArgs e)
	{
		ManageInterruptibleComparator();
	}

	private void CollectInterruptibleComparator(object sender, EventArgs e)
	{
		RevertInterruptibleComparator();
	}

	private void OrderInterruptibleComparator(object sender, EventArgs e)
	{
		CountInterruptibleItem();
	}

	private void RegisterInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			bridgeVisitor = !bridgeVisitor;
		}
		else
		{
			bridgeVisitor = int_0 != 0;
		}
		if (bridgeVisitor)
		{
			ButtonToggle_ShowNavalUnit_Unassigned.FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			ButtonToggle_ShowNavalUnit_Unassigned.FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void ManageInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			_ImporterVisitor = !_ImporterVisitor;
		}
		else
		{
			_ImporterVisitor = int_0 != 0;
		}
		if (_ImporterVisitor)
		{
			ButtonToggle_ShowAirUnit_Unassigned.FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			ButtonToggle_ShowAirUnit_Unassigned.FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void RevertInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			m_RepositoryVisitor = !m_RepositoryVisitor;
		}
		else
		{
			m_RepositoryVisitor = int_0 != 0;
		}
		if (m_RepositoryVisitor)
		{
			ButtonToggle_ShowLandUnit_Unassigned.FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			ButtonToggle_ShowLandUnit_Unassigned.FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void CountInterruptibleItem(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			_InvocationVisitor = !_InvocationVisitor;
		}
		else
		{
			_InvocationVisitor = int_0 != 0;
		}
		if (_InvocationVisitor)
		{
			ButtonToggle_ShowSpaceUnit_Unassigned.FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			ButtonToggle_ShowSpaceUnit_Unassigned.FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void CustomizeInterruptibleItem(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			_RequestVisitor = !_RequestVisitor;
		}
		else
		{
			_RequestVisitor = int_0 != 0;
		}
		if (_RequestVisitor)
		{
			ButtonToggle_ShowRP.FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			ButtonToggle_ShowRP.FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void CloneInterruptibleItem(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			valueVisitor = !valueVisitor;
		}
		else
		{
			valueVisitor = int_0 != 0;
		}
		if (valueVisitor)
		{
			ButtonToggle_ShowStandardZone.FlatAppearance.BorderColor = Color.Lime;
		}
		else
		{
			ButtonToggle_ShowStandardZone.FlatAppearance.BorderColor = Color.Red;
		}
		if (int_0 == -1)
		{
			RefreshUnitList();
		}
	}

	private void ConnectInterruptibleItem(object sender, EventArgs e)
	{
		if (LV_Units.SelectedItems.Count == 0)
		{
			return;
		}
		if (LV_Units.SelectedItems.ElementAt(0).Tag is Module_Unit.Unit)
		{
			Module_Unit.Unit unit = (Module_Unit.Unit)LV_Units.SelectedItems.ElementAt(0).Tag;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(unit.GetLongitude(), unit.GetLatitude()));
		}
		else if (LV_Units.SelectedItems.ElementAt(0).Tag is ReferencePoint)
		{
			ReferencePoint referencePoint = (ReferencePoint)LV_Units.SelectedItems.ElementAt(0).Tag;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(referencePoint.Longitude, referencePoint.Latitude));
		}
		else if (LV_Units.SelectedItems.ElementAt(0).Tag is Zone)
		{
			Zone zone = (Zone)LV_Units.SelectedItems.ElementAt(0).Tag;
			if (zone.Area.Count > 0)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(zone.Area.ElementAt(0).Longitude, zone.Area.ElementAt(0).Latitude));
			}
		}
		Button_Confirm.Text = "确认 (" + LV_Units.SelectedItems.Count + ")";
		Refresh();
	}

	private void MoveInterruptibleItem(object sender, EventArgs e)
	{
		RefreshUnitList();
	}

	private void DeleteInterruptibleItem(object sender, EventArgs e)
	{
		List<ActiveUnit> list_ = null;
		List<ReferencePoint> list_2 = null;
		List<Zone> list_3 = null;
		FetchSelectedUnits(ref list_, ref list_2, ref list_3);
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit && Client.CurrentGame.GameMode != Game._GameMode.MultiplayerScenEdit)
		{
			if (LV_Units.SelectedItems.Count > 0)
			{
				foreach (DarkListItem selectedItem in LV_Units.SelectedItems)
				{
					if (selectedItem.Tag is Module_Unit.Unit)
					{
						Module_Unit.Unit key = (Module_Unit.Unit)selectedItem.Tag;
						if (StaticUnitList.ContainsKey(key))
						{
							StaticUnitList.Remove(key);
						}
					}
				}
			}
		}
		else
		{
			foreach (ActiveUnit item in list_)
			{
				item.Destroy(bool_0: true, Module_ActiveUnit.CancelTokenizer(item), bool_2: true, "Editor");
			}
			foreach (ReferencePoint item2 in list_2)
			{
			}
			foreach (Zone item3 in list_3)
			{
			}
		}
		RefreshUnitList();
	}

	private void AddInterruptibleItem(object sender, EventArgs e)
	{
		CustomizeInterruptibleItem();
	}

	private void DestroyInterruptibleItem(object sender, EventArgs e)
	{
		CloneInterruptibleItem();
	}

	private void ComputeInterruptibleItem(object sender, EventArgs e)
	{
	}
}
