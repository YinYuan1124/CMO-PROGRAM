using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Salamander.Windows.Forms;

namespace Command;

[DesignerGenerated]
public sealed class EmconControl : DarkUserControl
{
	public delegate void SensorsFormRequestedEventHandler();

	private IContainer objectList;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkButton m_ParameterList;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkButton expressionList;

	[AccessedThroughProperty("CB_EMCON_Inherits")]
	[CompilerGenerated]
	private DarkCheckBox dispatcherList;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EMCON_Radar")]
	private DarkUIComboBox m_ListenerList;

	[AccessedThroughProperty("TableLayoutPanel1")]
	[CompilerGenerated]
	private TableLayoutPanel m_ConfigList;

	[AccessedThroughProperty("CB_EMCON_OECM")]
	[CompilerGenerated]
	private DarkUIComboBox registryList;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_EMCON_Sonar")]
	private DarkUIComboBox _DefinitionList;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel valList;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private DarkLabel observerList;

	private ScenarioObject _IssuerList;

	private bool clientList;

	private bool m_DicList;

	private bool _ConsumerList;

	private int facadeList;

	[CompilerGenerated]
	private static SensorsFormRequestedEventHandler proxyList;

	internal DarkButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_ParameterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutMethod;
			DarkButton parameterList = m_ParameterList;
			if (parameterList != null)
			{
				parameterList.Click -= value2;
			}
			m_ParameterList = value;
			parameterList = m_ParameterList;
			if (parameterList != null)
			{
				parameterList.Click += value2;
			}
		}
	}

	internal DarkButton Button2
	{
		[CompilerGenerated]
		get
		{
			return expressionList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewMethod;
			DarkButton darkButton = expressionList;
			if (darkButton != null)
			{
				darkButton.Click -= value2;
			}
			expressionList = value;
			darkButton = expressionList;
			if (darkButton != null)
			{
				darkButton.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_EMCON_Inherits
	{
		[CompilerGenerated]
		get
		{
			return dispatcherList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dispatcherList = value;
		}
	}

	internal DarkUIComboBox CB_EMCON_Radar
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateMethod;
			DarkUIComboBox listenerList = m_ListenerList;
			if (listenerList != null)
			{
				listenerList.SelectionChangeCommitted -= value2;
			}
			m_ListenerList = value;
			listenerList = m_ListenerList;
			if (listenerList != null)
			{
				listenerList.SelectionChangeCommitted += value2;
			}
		}
	}

	internal TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConfigList = value;
		}
	}

	internal DarkUIComboBox CB_EMCON_OECM
	{
		[CompilerGenerated]
		get
		{
			return registryList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginMethod;
			DarkUIComboBox darkUIComboBox = registryList;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			registryList = value;
			darkUIComboBox = registryList;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox CB_EMCON_Sonar
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetMethod;
			DarkUIComboBox definitionList = _DefinitionList;
			if (definitionList != null)
			{
				definitionList.SelectionChangeCommitted -= value2;
			}
			_DefinitionList = value;
			definitionList = _DefinitionList;
			if (definitionList != null)
			{
				definitionList.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return valList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valList = value;
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return observerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			observerList = value;
		}
	}

	public static event SensorsFormRequestedEventHandler SensorsFormRequested
	{
		[CompilerGenerated]
		add
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = proxyList;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Combine(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref proxyList, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = proxyList;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Remove(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref proxyList, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
	}

	public EmconControl()
	{
		base.Load += ComputeMethod;
		base.VisibleChanged += CallMethod;
		clientList = true;
		m_DicList = true;
		_ConsumerList = false;
		DestroyMethod();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && objectList != null)
			{
				objectList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DestroyMethod()
	{
		Button1 = new DarkButton();
		Button2 = new DarkButton();
		CB_EMCON_Inherits = new DarkCheckBox();
		CB_EMCON_Radar = new DarkUIComboBox();
		TableLayoutPanel1 = new TableLayoutPanel();
		CB_EMCON_OECM = new DarkUIComboBox();
		CB_EMCON_Sonar = new DarkUIComboBox();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		TableLayoutPanel1.SuspendLayout();
		SuspendLayout();
		Button1.Location = new Point(0, 0);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.Size = new Size(231, 21);
		Button1.TabIndex = 0;
		Button1.Text = "EMCON电磁管控窗口（Ctrl + F9）";
		Button2.Location = new Point(0, 21);
		Button2.Name = "Button2";
		Button2.Padding = new Padding(5);
		Button2.Size = new Size(231, 21);
		Button2.TabIndex = 1;
		Button2.Text = "传感器窗口（F9）";
		CB_EMCON_Inherits.AutoSize = true;
		CB_EMCON_Inherits.Location = new Point(3, 43);
		CB_EMCON_Inherits.Name = "CB_EMCON_Inherits";
		CB_EMCON_Inherits.Size = new Size(111, 17);
		CB_EMCON_Inherits.TabIndex = 2;
		CB_EMCON_Inherits.Text = "从父级继承";
		CB_EMCON_Radar.BackColor = Color.Transparent;
		CB_EMCON_Radar.DrawMode = DrawMode.OwnerDrawFixed;
		CB_EMCON_Radar.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_EMCON_Radar.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_EMCON_Radar.FormattingEnabled = true;
		CB_EMCON_Radar.Location = new Point(111, 0);
		CB_EMCON_Radar.Margin = new Padding(0, 0, 3, 3);
		CB_EMCON_Radar.Name = "CB_EMCON_Radar";
		CB_EMCON_Radar.Size = new Size(118, 21);
		CB_EMCON_Radar.TabIndex = 3;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121f));
		TableLayoutPanel1.Controls.Add(CB_EMCON_Radar, 1, 0);
		TableLayoutPanel1.Controls.Add(CB_EMCON_OECM, 1, 1);
		TableLayoutPanel1.Controls.Add(CB_EMCON_Sonar, 1, 2);
		TableLayoutPanel1.Controls.Add(Label1, 0, 0);
		TableLayoutPanel1.Controls.Add(Label2, 0, 1);
		TableLayoutPanel1.Controls.Add(Label3, 0, 2);
		TableLayoutPanel1.Location = new Point(0, 62);
		TableLayoutPanel1.Margin = new Padding(0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 4;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.Size = new Size(232, 67);
		TableLayoutPanel1.TabIndex = 4;
		CB_EMCON_OECM.BackColor = Color.Transparent;
		CB_EMCON_OECM.DrawMode = DrawMode.OwnerDrawFixed;
		CB_EMCON_OECM.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_EMCON_OECM.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_EMCON_OECM.FormattingEnabled = true;
		CB_EMCON_OECM.Location = new Point(111, 22);
		CB_EMCON_OECM.Margin = new Padding(0, 0, 3, 3);
		CB_EMCON_OECM.Name = "CB_EMCON_OECM";
		CB_EMCON_OECM.Size = new Size(118, 21);
		CB_EMCON_OECM.TabIndex = 4;
		CB_EMCON_Sonar.BackColor = Color.Transparent;
		CB_EMCON_Sonar.DrawMode = DrawMode.OwnerDrawFixed;
		CB_EMCON_Sonar.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_EMCON_Sonar.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_EMCON_Sonar.FormattingEnabled = true;
		CB_EMCON_Sonar.Location = new Point(111, 44);
		CB_EMCON_Sonar.Margin = new Padding(0, 0, 3, 3);
		CB_EMCON_Sonar.Name = "CB_EMCON_Sonar";
		CB_EMCON_Sonar.Size = new Size(118, 21);
		CB_EMCON_Sonar.TabIndex = 5;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(0, 0);
		Label1.Margin = new Padding(0, 0, 3, 0);
		Label1.Name = "Label1";
		Label1.Padding = new Padding(0, 6, 0, 0);
		Label1.Size = new Size(39, 19);
		Label1.TabIndex = 6;
		Label1.Text = "雷达：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(0, 22);
		Label2.Margin = new Padding(0, 0, 3, 0);
		Label2.Name = "Label2";
		Label2.Padding = new Padding(0, 6, 0, 0);
		Label2.Size = new Size(41, 19);
		Label2.TabIndex = 7;
		Label2.Text = "进攻性电磁武器OECM：";
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(0, 44);
		Label3.Margin = new Padding(0, 0, 3, 0);
		Label3.Name = "Label3";
		Label3.Padding = new Padding(0, 6, 0, 0);
		Label3.Size = new Size(38, 19);
		Label3.TabIndex = 8;
		Label3.Text = "声纳：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(TableLayoutPanel1);
		base.Controls.Add(CB_EMCON_Inherits);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Margin = new Padding(0);
		base.Name = "EmconControl";
		base.Size = new Size(232, 142);
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		TableLayoutPanel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ComputeMethod(object sender, EventArgs e)
	{
		Doctrine.EmconChanged += PatchMethod;
		Client.SelectedUnitChanged += SelectMethod;
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void PatchMethod(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (bool_2 || bool_3 || Information.IsNothing(scenarioObject_0) || !scenarioObject_0.IsActiveUnit || (bool_0 && scenarioObject_0 != Client.SelectedUnit) || !m_DicList || Information.IsNothing(nullable_0) || (object)base.Parent.GetType() != typeof(CollapsiblePanel) || ((CollapsiblePanel)base.Parent).PanelState != 0)
		{
			return;
		}
		Form[] ownedForms = ItemExporter.ConnectInterruptibleTemplate.MainForm.OwnedForms;
		for (int i = 0; i < ownedForms.Length; i = checked(i + 1))
		{
			if ((object)ownedForms[i].GetType() == typeof(DoctrineForm))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.AddInterruptibleIndexer(Client.SelectedUnit, Client.SelectedUnit);
				break;
			}
		}
	}

	private void SelectMethod(Module_Unit.Unit unit_0)
	{
		_IssuerList = unit_0;
		clientList = true;
	}

	[SpecialName]
	private Doctrine GetDocOfHookedUnit()
	{
		if (Information.IsNothing(_IssuerList))
		{
			_IssuerList = Client.SelectedUnit;
			if (Information.IsNothing(_IssuerList))
			{
				_ConsumerList = false;
				return null;
			}
		}
		if ((object)_IssuerList.GetType() == typeof(Side))
		{
			_ConsumerList = false;
			return ((Side)_IssuerList).Doctrine;
		}
		if (_IssuerList.IsMission)
		{
			_ConsumerList = false;
			return ((Mission)_IssuerList).Doctrine;
		}
		if (_IssuerList.IsGroup)
		{
			Group group = (Group)Client.SelectedUnit;
			if (Information.IsNothing(group.GroupLead))
			{
				_ConsumerList = false;
			}
			else
			{
				_ConsumerList = group.GroupLead.AI.IsEscort;
			}
			return ((Group)_IssuerList).Doctrine;
		}
		if (_IssuerList.IsActiveUnit)
		{
			_ConsumerList = ((ActiveUnit)Client.SelectedUnit).AI.IsEscort;
			return ((ActiveUnit)_IssuerList).Doctrine;
		}
		_ConsumerList = false;
		return null;
	}

	public void RefreshPanel(bool bool_0)
	{
		if (Information.IsNothing(Client.SelectedUnit) || Information.IsNothing(GetDocOfHookedUnit()))
		{
			return;
		}
		if (Client._StateClass != 1f)
		{
			if (facadeList == 0)
			{
				facadeList = base.Width;
			}
			if (facadeList == base.Width)
			{
				base.Width = (int)Math.Round((float)base.Width * Client._StateClass);
			}
		}
		base.Enabled = Client.SelectedUnit.GetUnitSide() == Client.CurrentSide;
		Button1.Visible = !Information.IsNothing(_IssuerList);
		Button2.Visible = !Information.IsNothing(_IssuerList);
		if (bool_0)
		{
			Doctrine docOfHookedUnit = GetDocOfHookedUnit();
			DarkCheckBox cB_EMCON_Inherits = CB_EMCON_Inherits;
			ref ScenarioObject issuerList = ref _IssuerList;
			Doctrine doctrine_ = GetDocOfHookedUnit();
			docOfHookedUnit.Set_Checkbox_EMCON_Inherit(cB_EMCON_Inherits, ref issuerList, ref doctrine_);
			Doctrine docOfHookedUnit2 = GetDocOfHookedUnit();
			DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
			Scenario scenario_ = Client.CurrentScenario;
			doctrine_ = GetDocOfHookedUnit();
			docOfHookedUnit2.Populate_Combo_EMCON_Radar(cB_EMCON_Radar, ref scenario_, ref doctrine_);
			Doctrine docOfHookedUnit3 = GetDocOfHookedUnit();
			DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
			scenario_ = Client.CurrentScenario;
			doctrine_ = GetDocOfHookedUnit();
			docOfHookedUnit3.Populate_Combo_EMCON_OECM(cB_EMCON_OECM, ref scenario_, ref doctrine_);
			Doctrine docOfHookedUnit4 = GetDocOfHookedUnit();
			DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
			scenario_ = Client.CurrentScenario;
			doctrine_ = GetDocOfHookedUnit();
			docOfHookedUnit4.Populate_Combo_EMCON_Sonar(cB_EMCON_Sonar, ref scenario_, ref doctrine_);
		}
		clientList = false;
	}

	private void CallMethod(object sender, EventArgs e)
	{
		if (clientList)
		{
			RefreshPanel(bool_0: false);
		}
		CustomPanelsEventRaiser.FireChangeEvent();
	}

	private void LogoutMethod(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_IssuerList))
		{
			DoctrineForm doctrineForm = new DoctrineForm();
			doctrineForm.Subject = _IssuerList;
			doctrineForm.isEscorts = _ConsumerList;
			doctrineForm.Show();
			doctrineForm.TabControl1A.SelectedIndex = 1;
		}
	}

	private void ViewMethod(object sender, EventArgs e)
	{
		proxyList?.Invoke();
	}

	private void ValidateMethod(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Radar = CB_EMCON_Radar;
		Scenario scenario_ = Client.CurrentScenario;
		Doctrine doctrine_ = GetDocOfHookedUnit();
		bool bool_ = true;
		SelectionChanged_Combo_EMCON_Radar(cB_EMCON_Radar, ref scenario_, ref doctrine_, bool_0: false, ref bool_, ref _ConsumerList, bool_3: false, bool_4: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	private void LoginMethod(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_OECM = CB_EMCON_OECM;
		Scenario scenario_ = Client.CurrentScenario;
		Doctrine doctrine_ = GetDocOfHookedUnit();
		bool bool_ = true;
		SelectionChanged_Combo_EMCON_OECM(cB_EMCON_OECM, ref scenario_, ref doctrine_, bool_0: false, ref bool_, ref _ConsumerList, bool_3: false, bool_4: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	private void GetMethod(object sender, EventArgs e)
	{
		DarkUIComboBox cB_EMCON_Sonar = CB_EMCON_Sonar;
		Scenario scenario_ = Client.CurrentScenario;
		Doctrine doctrine_ = GetDocOfHookedUnit();
		bool bool_ = true;
		SelectionChanged_Combo_EMCON_Sonar(cB_EMCON_Sonar, ref scenario_, ref doctrine_, bool_0: false, ref bool_, ref _ConsumerList, bool_3: false, bool_4: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
	}

	public static void SelectionChanged_Combo_EMCON_Radar(ComboBox comboBox_0, ref Scenario scenario_0, ref Doctrine doctrine_0, bool bool_0, ref bool bool_1, ref bool bool_2, bool bool_3, bool bool_4)
	{
		doctrine_0.SetEMCON_Radar(Doctrine.EMCONSettings.EMCONSettingSelection_To_EMCONSetting(comboBox_0.SelectedIndex), scenario_0);
		if (!Information.IsNothing(doctrine_0.SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in doctrine_0.SelectedUnits)
			{
				selectedUnit.Doctrine.SetEMCON_Radar((Doctrine.EMCONSettings._EMCONSetting)comboBox_0.SelectedIndex, scenario_0);
			}
		}
		if (bool_1)
		{
			AskEMCONObedience(ref scenario_0, ref doctrine_0, ref bool_2, bool_3, bool_4);
		}
		Doctrine.RaiseEvent_EMCONChanged(doctrine_0.Subject, false, bool_0, bool_3, bool_4, bool_3: false);
	}

	public static void SelectionChanged_Combo_EMCON_OECM(ComboBox comboBox_0, ref Scenario scenario_0, ref Doctrine doctrine_0, bool bool_0, ref bool bool_1, ref bool bool_2, bool bool_3, bool bool_4)
	{
		doctrine_0.SetEMCON_OECM(Doctrine.EMCONSettings.EMCONSettingSelection_To_EMCONSetting(comboBox_0.SelectedIndex), scenario_0);
		if (!Information.IsNothing(doctrine_0.SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in doctrine_0.SelectedUnits)
			{
				selectedUnit.Doctrine.SetEMCON_OECM((Doctrine.EMCONSettings._EMCONSetting)comboBox_0.SelectedIndex, scenario_0);
			}
		}
		if (bool_1)
		{
			AskEMCONObedience(ref scenario_0, ref doctrine_0, ref bool_2, bool_3, bool_4);
		}
		Doctrine.RaiseEvent_EMCONChanged(doctrine_0.Subject, false, bool_0, bool_3, bool_4, bool_3: false);
	}

	public static void SelectionChanged_Combo_EMCON_Sonar(ComboBox comboBox_0, ref Scenario scenario_0, ref Doctrine doctrine_0, bool bool_0, ref bool bool_1, ref bool bool_2, bool bool_3, bool bool_4)
	{
		doctrine_0.SetEMCON_Sonar(Doctrine.EMCONSettings.EMCONSettingSelection_To_EMCONSetting(comboBox_0.SelectedIndex), scenario_0);
		if (!Information.IsNothing(doctrine_0.SelectedUnits))
		{
			foreach (ActiveUnit selectedUnit in doctrine_0.SelectedUnits)
			{
				selectedUnit.Doctrine.SetEMCON_Sonar((Doctrine.EMCONSettings._EMCONSetting)comboBox_0.SelectedIndex, scenario_0);
			}
		}
		if (bool_1)
		{
			AskEMCONObedience(ref scenario_0, ref doctrine_0, ref bool_2, bool_3, bool_4);
		}
		Doctrine.RaiseEvent_EMCONChanged(doctrine_0.Subject, false, bool_0, bool_3, bool_4, bool_3: false);
	}

	public static void AskEMCONObedience(ref Scenario scenario_0, ref Doctrine doctrine_0, ref bool bool_0, bool bool_1, bool bool_2)
	{
		if ((object)doctrine_0.SubjectType == typeof(Waypoint))
		{
			return;
		}
		if (DarkMessageBox.ShowInformation("Enforce EMCON obedience on all affected units? \r\n\r\nYes: Manual sensor settings for affected missions, groups and/or units will be reset to use the above EMCON settings.\r\nNo: Affected units retain customized EMCON (if any) and will not use the specified EMCON settings.", "EMCON服从", DarkDialogButton.YesNo) == DialogResult.Yes)
		{
			if (Information.IsNothing(doctrine_0.SelectedUnits))
			{
				foreach (ActiveUnit item in doctrine_0.LoginRepository(scenario_0, bool_0))
				{
					item.Sensory.Boolean_0 = true;
				}
			}
			else
			{
				foreach (ActiveUnit selectedUnit in doctrine_0.SelectedUnits)
				{
					foreach (ActiveUnit item2 in selectedUnit.Doctrine.LoginRepository(scenario_0, bool_0))
					{
						item2.Sensory.Boolean_0 = true;
					}
				}
			}
		}
		else if (Information.IsNothing(doctrine_0.SelectedUnits))
		{
			foreach (ActiveUnit item3 in doctrine_0.LoginRepository(scenario_0, bool_0))
			{
				item3.Sensory.vmethod_0(item3.Sensors_Cached);
			}
		}
		else
		{
			foreach (ActiveUnit selectedUnit2 in doctrine_0.SelectedUnits)
			{
				foreach (ActiveUnit item4 in selectedUnit2.Doctrine.LoginRepository(scenario_0, bool_0))
				{
					item4.Sensory.vmethod_0(selectedUnit2.Sensors_Cached);
				}
			}
		}
		if (Information.IsNothing(doctrine_0.SelectedUnits))
		{
			Doctrine.RaiseEvent_EMCONChanged(doctrine_0.Subject, false, bool_0: false, bool_1, bool_2, bool_3: false);
			return;
		}
		foreach (ActiveUnit selectedUnit3 in doctrine_0.SelectedUnits)
		{
			Doctrine.RaiseEvent_EMCONChanged(selectedUnit3, false, bool_0: true, bool_1, bool_2, bool_3: false);
		}
	}
}
