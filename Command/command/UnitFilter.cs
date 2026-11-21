using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class UnitFilter : DarkUserControl
{
	[CompilerGenerated]
	private sealed class MapperProcessResolver
	{
		public int Local_TargetUnitClass_DBID;

		public string Local_TargetSide_ObjectID;

		public UnitFilter Me;

		internal bool CompareInterruptibleMethod(ActiveUnit theAU)
		{
			return !theAU.IsGroup & (theAU.DBID == Local_TargetUnitClass_DBID);
		}

		internal bool ReadInterruptibleMethod(ActiveUnit theAU)
		{
			return Operators.CompareString(theAU.GetUnitSide().ObjectID, Local_TargetSide_ObjectID, TextCompare: true) == 0;
		}

		internal bool DisableInterruptibleMethod(ActiveUnit theAU)
		{
			return !theAU.IsGroup & (theAU.UnitType == Me.TargetType) & (theAU.DBID == Local_TargetUnitClass_DBID);
		}

		internal bool UpdateInterruptibleMethod(ActiveUnit theAU)
		{
			return Operators.CompareString(theAU.GetUnitSide().ObjectID, Local_TargetSide_ObjectID, TextCompare: true) == 0;
		}
	}

	private IContainer _MockAttr;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_TagAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetSide")]
	private DarkUIComboBox m_FieldAttr;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel paramAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel pageAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetType")]
	private DarkUIComboBox m_RulesAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TargetSubtype")]
	private DarkUIComboBox methodAttr;

	[AccessedThroughProperty("CB_TargetUnitClass")]
	[CompilerGenerated]
	private DarkUIComboBox _ServiceAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SpecificUnit")]
	private DarkUIComboBox systemAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShowAllTypes")]
	private DarkCheckBox candidateAttr;

	private UnitFilterObject m_BaseAttr;

	private HashSet<Weapon> m_PolicyAttr;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_TagAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TagAttr = value;
		}
	}

	internal DarkUIComboBox CB_TargetSide
	{
		[CompilerGenerated]
		get
		{
			return m_FieldAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopInterruptiblePrototype;
			DarkUIComboBox fieldAttr = m_FieldAttr;
			if (fieldAttr != null)
			{
				fieldAttr.SelectionChangeCommitted -= value2;
			}
			m_FieldAttr = value;
			fieldAttr = m_FieldAttr;
			if (fieldAttr != null)
			{
				fieldAttr.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return paramAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramAttr = value;
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return pageAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pageAttr = value;
		}
	}

	internal DarkUIComboBox CB_TargetType
	{
		[CompilerGenerated]
		get
		{
			return m_RulesAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptiblePrototype;
			DarkUIComboBox rulesAttr = m_RulesAttr;
			if (rulesAttr != null)
			{
				rulesAttr.SelectionChangeCommitted -= value2;
			}
			m_RulesAttr = value;
			rulesAttr = m_RulesAttr;
			if (rulesAttr != null)
			{
				rulesAttr.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox CB_TargetSubtype
	{
		[CompilerGenerated]
		get
		{
			return methodAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillInterruptiblePrototype;
			DarkUIComboBox darkUIComboBox = methodAttr;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			methodAttr = value;
			darkUIComboBox = methodAttr;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox CB_TargetUnitClass
	{
		[CompilerGenerated]
		get
		{
			return _ServiceAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateInterruptiblePrototype;
			DarkUIComboBox serviceAttr = _ServiceAttr;
			if (serviceAttr != null)
			{
				serviceAttr.SelectionChangeCommitted -= value2;
			}
			_ServiceAttr = value;
			serviceAttr = _ServiceAttr;
			if (serviceAttr != null)
			{
				serviceAttr.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox CB_SpecificUnit
	{
		[CompilerGenerated]
		get
		{
			return systemAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateInterruptiblePrototype;
			DarkUIComboBox darkUIComboBox = systemAttr;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			systemAttr = value;
			darkUIComboBox = systemAttr;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkCheckBox CB_ShowAllTypes
	{
		[CompilerGenerated]
		get
		{
			return candidateAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptiblePrototype;
			DarkCheckBox darkCheckBox = candidateAttr;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			candidateAttr = value;
			darkCheckBox = candidateAttr;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	public GlobalVariables.ActiveUnitType TargetType => (GlobalVariables.ActiveUnitType)CB_TargetType.SelectedIndex;

	public int TargetSubType
	{
		get
		{
			switch (CB_TargetType.SelectedIndex)
			{
			case 0:
				return 0;
			case 1:
				return Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedValue, null, "Tag", new object[0], null, null, null));
			case 2:
				return Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedValue, null, "Tag", new object[0], null, null, null));
			case 3:
				return Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedValue, null, "Tag", new object[0], null, null, null));
			case 4:
				return Conversions.ToShort(NewLateBinding.LateGet(CB_TargetSubtype.SelectedValue, null, "Tag", new object[0], null, null, null));
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return 0;
			case 6:
				return Conversions.ToShort(NewLateBinding.LateGet(CB_TargetSubtype.SelectedValue, null, "Tag", new object[0], null, null, null));
			case 7:
				return Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedValue, null, "Tag", new object[0], null, null, null));
			case 8:
				return Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedValue, null, "Tag", new object[0], null, null, null));
			}
		}
	}

	public string SpecificUnitClass => Conversions.ToString(((ComboBoxItem)CB_TargetUnitClass.SelectedItem).Tag);

	public ActiveUnit SpecificUnit
	{
		get
		{
			int selectedIndex = CB_SpecificUnit.SelectedIndex;
			if (selectedIndex == 0)
			{
				return null;
			}
			if (selectedIndex <= 0)
			{
				return null;
			}
			return (ActiveUnit)NewLateBinding.LateGet(CB_SpecificUnit.SelectedItem, null, "Tag", new object[0], null, null, null);
		}
	}

	public string TargetSide
	{
		get
		{
			if (CB_TargetSide.SelectedIndex == 0)
			{
				return "";
			}
			return Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "tag", new object[0], null, null, null));
		}
	}

	public UnitFilterObject FilterObject
	{
		get
		{
			return m_BaseAttr;
		}
		set
		{
			bool num = value != m_BaseAttr;
			m_BaseAttr = value;
			if (num)
			{
				CheckInterruptiblePrototype();
			}
		}
	}

	public UnitFilter()
	{
		base.Load += ConcatInterruptiblePrototype;
		m_PolicyAttr = new HashSet<Weapon>();
		InitInterruptiblePrototype();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _MockAttr != null)
			{
				_MockAttr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InitInterruptiblePrototype()
	{
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Label4 = new DarkLabel();
		Label5 = new DarkLabel();
		CB_ShowAllTypes = new DarkCheckBox();
		CB_SpecificUnit = new DarkUIComboBox();
		CB_TargetUnitClass = new DarkUIComboBox();
		CB_TargetSubtype = new DarkUIComboBox();
		CB_TargetType = new DarkUIComboBox();
		CB_TargetSide = new DarkUIComboBox();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(13, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(84, 17);
		Label1.TabIndex = 0;
		Label1.Text = "目标方：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(13, 46);
		Label2.Name = "Label2";
		Label2.Size = new Size(85, 17);
		Label2.TabIndex = 2;
		Label2.Text = "目标类别：";
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(13, 104);
		Label3.Name = "Label3";
		Label3.Size = new Size(108, 17);
		Label3.TabIndex = 3;
		Label3.Text = "目标子类型：";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(13, 136);
		Label4.Name = "Label4";
		Label4.Size = new Size(90, 17);
		Label4.TabIndex = 4;
		Label4.Text = "目标类型：";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(13, 171);
		Label5.Name = "Label5";
		Label5.Size = new Size(88, 17);
		Label5.TabIndex = 5;
		Label5.Text = "具体单元：";
		CB_ShowAllTypes.AutoSize = true;
		CB_ShowAllTypes.Location = new Point(102, 74);
		CB_ShowAllTypes.Name = "CB_ShowAllTypes";
		CB_ShowAllTypes.Size = new Size(121, 21);
		CB_ShowAllTypes.TabIndex = 10;
		CB_ShowAllTypes.Text = "显示所有类型";
		CB_SpecificUnit.BackColor = Color.Transparent;
		CB_SpecificUnit.DrawMode = DrawMode.OwnerDrawFixed;
		CB_SpecificUnit.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_SpecificUnit.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_SpecificUnit.FormattingEnabled = true;
		CB_SpecificUnit.Location = new Point(102, 168);
		CB_SpecificUnit.Name = "CB_SpecificUnit";
		CB_SpecificUnit.Size = new Size(196, 24);
		CB_SpecificUnit.TabIndex = 9;
		CB_TargetUnitClass.BackColor = Color.Transparent;
		CB_TargetUnitClass.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetUnitClass.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetUnitClass.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_TargetUnitClass.FormattingEnabled = true;
		CB_TargetUnitClass.Location = new Point(102, 133);
		CB_TargetUnitClass.Name = "CB_TargetUnitClass";
		CB_TargetUnitClass.Size = new Size(196, 24);
		CB_TargetUnitClass.TabIndex = 8;
		CB_TargetSubtype.BackColor = Color.Transparent;
		CB_TargetSubtype.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetSubtype.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetSubtype.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_TargetSubtype.FormattingEnabled = true;
		CB_TargetSubtype.Location = new Point(102, 101);
		CB_TargetSubtype.Name = "CB_TargetSubtype";
		CB_TargetSubtype.Size = new Size(196, 24);
		CB_TargetSubtype.TabIndex = 7;
		CB_TargetType.BackColor = Color.Transparent;
		CB_TargetType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetType.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_TargetType.FormattingEnabled = true;
		CB_TargetType.Items.AddRange(new object[9] { "无", "飞机", "水面舰艇", "潜艇", "地面设施", "-------", "武器", "卫星", "地面单元" });
		CB_TargetType.Location = new Point(102, 43);
		CB_TargetType.Name = "CB_TargetType";
		CB_TargetType.Size = new Size(196, 24);
		CB_TargetType.TabIndex = 6;
		CB_TargetSide.BackColor = Color.Transparent;
		CB_TargetSide.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetSide.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetSide.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_TargetSide.FormattingEnabled = true;
		CB_TargetSide.Location = new Point(102, 10);
		CB_TargetSide.Name = "CB_TargetSide";
		CB_TargetSide.Size = new Size(196, 24);
		CB_TargetSide.TabIndex = 1;
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(CB_ShowAllTypes);
		base.Controls.Add(CB_SpecificUnit);
		base.Controls.Add(CB_TargetUnitClass);
		base.Controls.Add(CB_TargetSubtype);
		base.Controls.Add(CB_TargetType);
		base.Controls.Add(Label5);
		base.Controls.Add(Label4);
		base.Controls.Add(Label3);
		base.Controls.Add(Label2);
		base.Controls.Add(CB_TargetSide);
		base.Controls.Add(Label1);
		base.Name = "UnitFilter";
		base.Size = new Size(311, 215);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CheckInterruptiblePrototype()
	{
		if (Client.CurrentScenario == null || m_BaseAttr == null)
		{
			return;
		}
		CB_TargetSide.Items.Clear();
		CB_TargetSide.DisplayMember = "Content";
		CB_ShowAllTypes.Checked = m_BaseAttr.ShowAllTypes;
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			if (CB_TargetSide.Items.Count == 0)
			{
				ComboBoxItem comboBoxItem2 = new ComboBoxItem();
				comboBoxItem2.Content = "任意分方";
				comboBoxItem2.Tag = null;
				CB_TargetSide.Items.Add(comboBoxItem2);
			}
			comboBoxItem.Content = side.Name;
			comboBoxItem.Tag = side.ObjectID;
			CB_TargetSide.Items.Add(comboBoxItem);
		}
		if (string.IsNullOrEmpty(m_BaseAttr.TargetSide))
		{
			CB_TargetSide.SelectedIndex = 0;
		}
		else
		{
			IEnumerator enumerator = null;
			try
			{
				enumerator = CB_TargetSide.Items.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ComboBoxItem comboBoxItem3 = (ComboBoxItem)enumerator.Current;
					if (Operators.CompareString(Conversions.ToString(comboBoxItem3.Tag), m_BaseAttr.TargetSide, TextCompare: true) == 0)
					{
						CB_TargetSide.SelectedItem = comboBoxItem3;
						break;
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
			if (CB_TargetSide.SelectedItem == null)
			{
				return;
			}
		}
		if (m_BaseAttr.TargetType == GlobalVariables.ActiveUnitType.None)
		{
			CB_TargetType.SelectedIndex = 0;
			InterruptInterruptiblePrototype(bool_0: true);
			RemoveInterruptiblePrototype(bool_0: true);
			FindInterruptiblePrototype(bool_0: true);
			return;
		}
		CB_TargetType.SelectedIndex = (int)m_BaseAttr.TargetType;
		InterruptInterruptiblePrototype();
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = CB_TargetSubtype.Items.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				ComboBoxItem comboBoxItem4 = (ComboBoxItem)enumerator2.Current;
				if (m_BaseAttr.TargetSubType == Conversions.ToInteger(comboBoxItem4.Tag))
				{
					CB_TargetSubtype.SelectedItem = comboBoxItem4;
					break;
				}
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		if (CB_TargetSubtype.SelectedItem == null)
		{
			return;
		}
		RemoveInterruptiblePrototype();
		IEnumerator enumerator3 = null;
		try
		{
			enumerator3 = CB_TargetUnitClass.Items.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				ComboBoxItem comboBoxItem5 = (ComboBoxItem)enumerator3.Current;
				if (m_BaseAttr.SpecificUnitClass == Conversions.ToInteger(comboBoxItem5.Tag))
				{
					CB_TargetUnitClass.SelectedItem = comboBoxItem5;
					break;
				}
			}
		}
		finally
		{
			if (enumerator3 is IDisposable)
			{
				(enumerator3 as IDisposable).Dispose();
			}
		}
		if (CB_TargetUnitClass.SelectedItem == null)
		{
			return;
		}
		FindInterruptiblePrototype();
		if (CB_TargetSubtype.Items.Count == 1)
		{
			m_BaseAttr.TargetSubType = 0;
		}
		if (CB_TargetUnitClass.Items.Count == 1)
		{
			m_BaseAttr.SpecificUnitClass = 0;
		}
		if (CB_SpecificUnit.Items.Count == 1)
		{
			m_BaseAttr.SpecificUnitID = null;
		}
		bool flag = false;
		if (m_BaseAttr.SpecificUnitID != null)
		{
			IEnumerator enumerator4 = null;
			try
			{
				enumerator4 = CB_SpecificUnit.Items.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					ComboBoxItem comboBoxItem6 = (ComboBoxItem)enumerator4.Current;
					if (comboBoxItem6.Tag != null && Operators.CompareString(m_BaseAttr.SpecificUnitID, ((ScenarioObject)comboBoxItem6.Tag).ObjectID, TextCompare: true) == 0)
					{
						CB_SpecificUnit.SelectedItem = comboBoxItem6;
						flag = true;
						break;
					}
				}
			}
			finally
			{
				if (enumerator4 is IDisposable)
				{
					(enumerator4 as IDisposable).Dispose();
				}
			}
		}
		if (!flag & (m_BaseAttr.SpecificUnitID != null))
		{
			ComboBoxItem comboBoxItem7 = new ComboBoxItem();
			comboBoxItem7.Content = m_BaseAttr.SpecificUnitID + "[未找到！]";
			comboBoxItem7.Tag = m_BaseAttr.SpecificUnitID;
			CB_SpecificUnit.Items.Add(comboBoxItem7);
			CB_SpecificUnit.SelectedItem = comboBoxItem7;
			DarkMessageBox.ShowError("在此想定中不存在特定单元。请选择其他单元。", "Error");
		}
	}

	private void ConcatInterruptiblePrototype(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void InterruptInterruptiblePrototype(bool bool_0 = false)
	{
		CB_TargetSubtype.Items.Clear();
		CB_TargetSubtype.DisplayMember = "Content";
		ComboBoxItem comboBoxItem = new ComboBoxItem();
		comboBoxItem.Content = "None";
		CB_TargetSubtype.Items.Add(comboBoxItem);
		if (!bool_0)
		{
			switch (m_BaseAttr.TargetType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				if (m_BaseAttr.ShowAllTypes)
				{
					CB_TargetSubtype.Items.Remove(comboBoxItem);
					IEnumerator enumerator5 = null;
					try
					{
						enumerator5 = Enum.GetValues(typeof(Aircraft._AircraftType)).GetEnumerator();
						while (enumerator5.MoveNext())
						{
							Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(enumerator5.Current);
							string text2 = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
							if (string.IsNullOrEmpty(text2))
							{
								text2 = aircraftType.ToString();
							}
							ComboBoxItem comboBoxItem10 = new ComboBoxItem();
							comboBoxItem10.Content = text2;
							comboBoxItem10.Tag = aircraftType;
							CB_TargetSubtype.Items.Add(comboBoxItem10);
						}
					}
					finally
					{
						if (enumerator5 is IDisposable)
						{
							(enumerator5 as IDisposable).Dispose();
						}
					}
					break;
				}
				IEnumerable<ActiveUnit> source2 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsAircraft
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					source2 = source2.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (Aircraft._AircraftType item in source2.Select((ActiveUnit theAC) => ((Aircraft)theAC).Type).Distinct())
				{
					ComboBoxItem comboBoxItem11 = new ComboBoxItem();
					comboBoxItem11.Content = item.ToString();
					comboBoxItem11.Tag = item;
					CB_TargetSubtype.Items.Add(comboBoxItem11);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Ship:
			{
				if (m_BaseAttr.ShowAllTypes)
				{
					CB_TargetSubtype.Items.Remove(comboBoxItem);
					IEnumerator enumerator2 = null;
					try
					{
						enumerator2 = Enum.GetValues(typeof(Ship._ShipType)).GetEnumerator();
						while (enumerator2.MoveNext())
						{
							Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(enumerator2.Current);
							string text4 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
							if (string.IsNullOrEmpty(text4))
							{
								text4 = shipType.ToString();
							}
							ComboBoxItem comboBoxItem2 = new ComboBoxItem();
							comboBoxItem2.Content = text4;
							comboBoxItem2.Tag = shipType;
							CB_TargetSubtype.Items.Add(comboBoxItem2);
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
					break;
				}
				IEnumerable<ActiveUnit> source4 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsShip
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					source4 = source4.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (Ship._ShipType item2 in source4.Select((ActiveUnit theAU) => ((Ship)theAU).Type).Distinct())
				{
					ComboBoxItem comboBoxItem3 = new ComboBoxItem();
					comboBoxItem3.Content = item2.ToString();
					comboBoxItem3.Tag = item2;
					CB_TargetSubtype.Items.Add(comboBoxItem3);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				if (m_BaseAttr.ShowAllTypes)
				{
					CB_TargetSubtype.Items.Remove(comboBoxItem);
					IEnumerator enumerator7 = null;
					try
					{
						enumerator7 = Enum.GetValues(typeof(Submarine._SubmarineType)).GetEnumerator();
						while (enumerator7.MoveNext())
						{
							Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(enumerator7.Current);
							string text3 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
							if (string.IsNullOrEmpty(text3))
							{
								text3 = submarineType.ToString();
							}
							ComboBoxItem comboBoxItem14 = new ComboBoxItem();
							comboBoxItem14.Content = text3;
							comboBoxItem14.Tag = submarineType;
							CB_TargetSubtype.Items.Add(comboBoxItem14);
						}
					}
					finally
					{
						if (enumerator7 is IDisposable)
						{
							(enumerator7 as IDisposable).Dispose();
						}
					}
					break;
				}
				IEnumerable<ActiveUnit> source3 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsSubmarine
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					source3 = source3.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (Submarine._SubmarineType item3 in source3.Select((ActiveUnit theAU) => ((Submarine)theAU).Type).Distinct())
				{
					ComboBoxItem comboBoxItem15 = new ComboBoxItem();
					comboBoxItem15.Content = item3.ToString();
					comboBoxItem15.Tag = item3;
					CB_TargetSubtype.Items.Add(comboBoxItem15);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Facility:
			{
				if (m_BaseAttr.ShowAllTypes)
				{
					CB_TargetSubtype.Items.Remove(comboBoxItem);
					IEnumerator enumerator4 = null;
					try
					{
						enumerator4 = Enum.GetValues(typeof(Facility._FacilityCategory)).GetEnumerator();
						while (enumerator4.MoveNext())
						{
							Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(enumerator4.Current);
							string text6 = Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection);
							if (string.IsNullOrEmpty(text6))
							{
								text6 = facilityCategory.ToString();
							}
							ComboBoxItem comboBoxItem6 = new ComboBoxItem();
							comboBoxItem6.Content = text6;
							comboBoxItem6.Tag = facilityCategory;
							CB_TargetSubtype.Items.Add(comboBoxItem6);
						}
					}
					finally
					{
						if (enumerator4 is IDisposable)
						{
							(enumerator4 as IDisposable).Dispose();
						}
					}
					break;
				}
				IEnumerable<ActiveUnit> source6 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsFacility
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					source6 = source6.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (Facility._FacilityCategory item4 in source6.Select((ActiveUnit theAU) => ((Facility)theAU).Category).Distinct())
				{
					ComboBoxItem comboBoxItem7 = new ComboBoxItem();
					comboBoxItem7.Content = item4.ToString();
					comboBoxItem7.Tag = item4;
					CB_TargetSubtype.Items.Add(comboBoxItem7);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Weapon:
			{
				if (m_BaseAttr.ShowAllTypes)
				{
					CB_TargetSubtype.Items.Remove(comboBoxItem);
					IEnumerator enumerator6 = null;
					try
					{
						enumerator6 = Enum.GetValues(typeof(Weapon._WeaponType)).GetEnumerator();
						while (enumerator6.MoveNext())
						{
							Weapon._WeaponType weaponType = (Weapon._WeaponType)Conversions.ToShort(enumerator6.Current);
							ComboBoxItem comboBoxItem12 = new ComboBoxItem();
							comboBoxItem12.Content = weaponType.ToString();
							comboBoxItem12.Tag = weaponType;
							CB_TargetSubtype.Items.Add(comboBoxItem12);
						}
					}
					finally
					{
						if (enumerator6 is IDisposable)
						{
							(enumerator6 as IDisposable).Dispose();
						}
					}
					break;
				}
				m_PolicyAttr.Clear();
				IEnumerable<ActiveUnit> enumerable = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsActiveUnit
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					enumerable = enumerable.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (ActiveUnit item5 in enumerable)
				{
					if (!item5.IsWeapon && !item5.IsWaypoint)
					{
						if (item5.IsAircraft)
						{
							WRA_RetreiveMountWeapons(item5);
							WRA_RetreiveLoadoutWeapons(item5);
						}
						else if (item5.IsShip || item5.IsSubmarine || item5.IsFacility)
						{
							WRA_RetreiveMountWeapons(item5);
							WRA_RetreiveMagazineWeapons(item5);
						}
					}
				}
				IEnumerable<UnguidedWeapon> enumerable2 = from theUW in Client.CurrentScenario.UnguidedWeapons.Values
					where theUW.IsMine
					select (theUW);
				if (enumerable2.Count() > 0)
				{
					if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
					{
						enumerable2 = enumerable2.Where((UnguidedWeapon unguidedWeapon_0) => Operators.ConditionalCompareObjectEqual(unguidedWeapon_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
					}
					foreach (UnguidedWeapon item6 in enumerable2)
					{
						WRA_RetreiveUnguidedWeapons(item6);
					}
				}
				if (m_PolicyAttr.Count <= 0)
				{
					break;
				}
				foreach (Weapon._WeaponType item7 in m_PolicyAttr.Select((Weapon theW) => theW.Type).Distinct().OrderBy(delegate(Weapon._WeaponType s)
				{
					Weapon._WeaponType weaponType2 = s;
					return weaponType2.ToString();
				}))
				{
					ComboBoxItem comboBoxItem13 = new ComboBoxItem();
					comboBoxItem13.Content = item7.ToString();
					comboBoxItem13.Tag = item7;
					CB_TargetSubtype.Items.Add(comboBoxItem13);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Satellite:
			{
				if (m_BaseAttr.ShowAllTypes)
				{
					CB_TargetSubtype.Items.Remove(comboBoxItem);
					IEnumerator enumerator3 = null;
					try
					{
						enumerator3 = Enum.GetValues(typeof(Satellite._SatelliteType)).GetEnumerator();
						while (enumerator3.MoveNext())
						{
							Satellite._SatelliteType satelliteType = (Satellite._SatelliteType)Conversions.ToInteger(enumerator3.Current);
							string text5 = Misc.Description(satelliteType, Client.CurrentScenario.DBConnection);
							if (string.IsNullOrEmpty(text5))
							{
								text5 = satelliteType.ToString();
							}
							ComboBoxItem comboBoxItem4 = new ComboBoxItem();
							comboBoxItem4.Content = text5;
							comboBoxItem4.Tag = satelliteType;
							CB_TargetSubtype.Items.Add(comboBoxItem4);
						}
					}
					finally
					{
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
					}
					break;
				}
				IEnumerable<ActiveUnit> source5 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsSatellite
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					source5 = source5.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (Satellite._SatelliteType item8 in source5.Select((ActiveUnit theAU) => ((Satellite)theAU).Type).Distinct())
				{
					ComboBoxItem comboBoxItem5 = new ComboBoxItem();
					comboBoxItem5.Content = item8.ToString();
					comboBoxItem5.Tag = item8;
					CB_TargetSubtype.Items.Add(comboBoxItem5);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Vehicle:
			{
				if (m_BaseAttr.ShowAllTypes)
				{
					CB_TargetSubtype.Items.Remove(comboBoxItem);
					IEnumerator enumerator = null;
					try
					{
						enumerator = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)).GetEnumerator();
						while (enumerator.MoveNext())
						{
							IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(enumerator.Current);
							string text = Misc.ToEnglishString(mobileUnitCategory);
							if (string.IsNullOrEmpty(text))
							{
								text = mobileUnitCategory.ToString();
							}
							ComboBoxItem comboBoxItem8 = new ComboBoxItem();
							comboBoxItem8.Content = text;
							comboBoxItem8.Tag = mobileUnitCategory;
							CB_TargetSubtype.Items.Add(comboBoxItem8);
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
					break;
				}
				IEnumerable<ActiveUnit> source = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsMobileGroundUnit
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					source = source.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (IMobileGroundUnit._MobileUnitCategory item9 in source.Select((ActiveUnit theAU) => ((IMobileGroundUnit)theAU).MobileUnitCategory).Distinct())
				{
					ComboBoxItem comboBoxItem9 = new ComboBoxItem();
					comboBoxItem9.Content = item9.ToString();
					comboBoxItem9.Tag = item9;
					CB_TargetSubtype.Items.Add(comboBoxItem9);
				}
				break;
			}
			}
		}
		if (CB_TargetSubtype.Items.Count == 0)
		{
			CB_TargetSubtype.Items.Add(comboBoxItem);
		}
		CB_TargetSubtype.SelectedIndex = 0;
	}

	private void RemoveInterruptiblePrototype(bool bool_0 = false)
	{
		CB_TargetUnitClass.Items.Clear();
		CB_TargetUnitClass.DisplayMember = "Content";
		ComboBoxItem comboBoxItem = new ComboBoxItem();
		comboBoxItem.Content = "None";
		CB_TargetUnitClass.Items.Add(comboBoxItem);
		if (!bool_0)
		{
			HashSet<int> hashSet = new HashSet<int>();
			switch (CB_TargetType.SelectedIndex)
			{
			case 1:
			{
				IEnumerable<ActiveUnit> enumerable3 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsAircraft
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					enumerable3 = enumerable3.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (ActiveUnit item in enumerable3)
				{
					if (((Aircraft)item).Type == (Aircraft._AircraftType)Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "Tag", new object[0], null, null, null)) && !hashSet.Contains(item.DBID))
					{
						hashSet.Add(item.DBID);
						ComboBoxItem comboBoxItem4 = new ComboBoxItem();
						comboBoxItem4.Content = item.UnitClass;
						comboBoxItem4.Tag = item.DBID;
						CB_TargetUnitClass.Items.Add(comboBoxItem4);
					}
				}
				break;
			}
			case 2:
			{
				IEnumerable<ActiveUnit> enumerable5 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsShip
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					enumerable5 = enumerable5.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (ActiveUnit item2 in enumerable5)
				{
					if (((Ship)item2).Type == (Ship._ShipType)Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "Tag", new object[0], null, null, null)) && !hashSet.Contains(item2.DBID))
					{
						hashSet.Add(item2.DBID);
						ComboBoxItem comboBoxItem6 = new ComboBoxItem();
						comboBoxItem6.Content = item2.UnitClass;
						comboBoxItem6.Tag = item2.DBID;
						CB_TargetUnitClass.Items.Add(comboBoxItem6);
					}
				}
				break;
			}
			case 3:
			{
				IEnumerable<ActiveUnit> enumerable6 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsSubmarine
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					enumerable6 = enumerable6.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (ActiveUnit item3 in enumerable6)
				{
					if (((Submarine)item3).Type == (Submarine._SubmarineType)Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "Tag", new object[0], null, null, null)) && !hashSet.Contains(item3.DBID))
					{
						hashSet.Add(item3.DBID);
						ComboBoxItem comboBoxItem8 = new ComboBoxItem();
						comboBoxItem8.Content = item3.UnitClass;
						comboBoxItem8.Tag = item3.DBID;
						CB_TargetUnitClass.Items.Add(comboBoxItem8);
					}
				}
				break;
			}
			case 4:
			{
				IEnumerable<ActiveUnit> enumerable4 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsFacility
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					enumerable4 = enumerable4.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (ActiveUnit item4 in enumerable4)
				{
					if ((int)((Facility)item4).Category == Conversions.ToShort(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "Tag", new object[0], null, null, null)) && !hashSet.Contains(item4.DBID))
					{
						hashSet.Add(item4.DBID);
						ComboBoxItem comboBoxItem5 = new ComboBoxItem();
						comboBoxItem5.Content = item4.UnitClass;
						comboBoxItem5.Tag = item4.DBID;
						CB_TargetUnitClass.Items.Add(comboBoxItem5);
					}
				}
				break;
			}
			case 6:
			{
				IOrderedEnumerable<Weapon> orderedEnumerable = m_PolicyAttr.OrderBy((Weapon s) => s.Name);
				if (orderedEnumerable.Count() <= 0)
				{
					break;
				}
				foreach (Weapon item5 in orderedEnumerable)
				{
					if ((int)item5.Type == Conversions.ToShort(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "Tag", new object[0], null, null, null)) && !hashSet.Contains(item5.DBID))
					{
						hashSet.Add(item5.DBID);
						ComboBoxItem comboBoxItem7 = new ComboBoxItem();
						comboBoxItem7.Content = item5.Name;
						comboBoxItem7.Tag = item5.DBID;
						CB_TargetUnitClass.Items.Add(comboBoxItem7);
					}
				}
				break;
			}
			case 7:
			{
				IEnumerable<ActiveUnit> enumerable2 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsSatellite
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					enumerable2 = enumerable2.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (ActiveUnit item6 in enumerable2)
				{
					if (((Satellite)item6).Type == (Satellite._SatelliteType)Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "Tag", new object[0], null, null, null)) && !hashSet.Contains(item6.DBID))
					{
						hashSet.Add(item6.DBID);
						ComboBoxItem comboBoxItem3 = new ComboBoxItem();
						comboBoxItem3.Content = item6.UnitClass;
						comboBoxItem3.Tag = item6.DBID;
						CB_TargetUnitClass.Items.Add(comboBoxItem3);
					}
				}
				break;
			}
			case 8:
			{
				IEnumerable<ActiveUnit> enumerable = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where theAU.IsMobileGroundUnit
					select (theAU);
				if (CB_TargetSide.SelectedItem != null && !string.IsNullOrEmpty(Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null))))
				{
					enumerable = enumerable.Where((ActiveUnit activeUnit_0) => Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true));
				}
				foreach (ActiveUnit item7 in enumerable)
				{
					if (((IMobileGroundUnit)item7).MobileUnitCategory == (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "Tag", new object[0], null, null, null)) && !hashSet.Contains(item7.DBID))
					{
						hashSet.Add(item7.DBID);
						ComboBoxItem comboBoxItem2 = new ComboBoxItem();
						comboBoxItem2.Content = item7.UnitClass;
						comboBoxItem2.Tag = item7.DBID;
						CB_TargetUnitClass.Items.Add(comboBoxItem2);
					}
				}
				break;
			}
			}
		}
		CB_TargetUnitClass.SelectedIndex = 0;
	}

	private void FindInterruptiblePrototype(bool bool_0 = false)
	{
		CB_SpecificUnit.Items.Clear();
		CB_SpecificUnit.DisplayMember = "Content";
		ComboBoxItem comboBoxItem = new ComboBoxItem();
		comboBoxItem.Content = "None";
		CB_SpecificUnit.Items.Add(comboBoxItem);
		if (!bool_0)
		{
			string Local_TargetSide_ObjectID = "";
			if (CB_TargetSide.SelectedItem != null && NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null) != null)
			{
				Local_TargetSide_ObjectID = Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null));
			}
			int Local_TargetUnitClass_DBID = 0;
			if (CB_TargetUnitClass.SelectedItem != null && ((ComboBoxItem)CB_TargetUnitClass.SelectedItem).Tag != null)
			{
				Local_TargetUnitClass_DBID = Conversions.ToInteger(((ComboBoxItem)CB_TargetUnitClass.SelectedItem).Tag);
			}
			switch (m_BaseAttr.TargetType)
			{
			case GlobalVariables.ActiveUnitType.Aimpoint:
			{
				IEnumerable<ActiveUnit> enumerable2 = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where !theAU.IsGroup & (theAU.DBID == Local_TargetUnitClass_DBID)
					select (theAU) into theAU
					orderby theAU.Name
					select theAU;
				if (!string.IsNullOrEmpty(Local_TargetSide_ObjectID))
				{
					enumerable2 = enumerable2.Where((ActiveUnit theAU) => Operators.CompareString(theAU.GetUnitSide().ObjectID, Local_TargetSide_ObjectID, TextCompare: true) == 0);
				}
				foreach (ActiveUnit item in enumerable2)
				{
					ComboBoxItem comboBoxItem3 = new ComboBoxItem();
					comboBoxItem3.Content = item.Name;
					comboBoxItem3.Tag = item;
					CB_SpecificUnit.Items.Add(comboBoxItem3);
				}
				break;
			}
			default:
			{
				IEnumerable<ActiveUnit> enumerable = from theAU in Client.CurrentScenario.ActiveUnits.Values
					where !theAU.IsGroup & (theAU.UnitType == TargetType) & (theAU.DBID == Local_TargetUnitClass_DBID)
					select (theAU) into theAU
					orderby theAU.Name
					select theAU;
				if (!string.IsNullOrEmpty(Local_TargetSide_ObjectID))
				{
					enumerable = enumerable.Where((ActiveUnit theAU) => Operators.CompareString(theAU.GetUnitSide().ObjectID, Local_TargetSide_ObjectID, TextCompare: true) == 0);
				}
				foreach (ActiveUnit item2 in enumerable)
				{
					ComboBoxItem comboBoxItem2 = new ComboBoxItem();
					comboBoxItem2.Content = item2.Name;
					comboBoxItem2.Tag = item2;
					CB_SpecificUnit.Items.Add(comboBoxItem2);
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.None:
				break;
			}
		}
		CB_SpecificUnit.SelectedIndex = 0;
	}

	private void SetInterruptiblePrototype(object sender, EventArgs e)
	{
		GlobalVariables.ActiveUnitType activeUnitType = m_BaseAttr.TargetType;
		switch (CB_TargetType.SelectedIndex)
		{
		case 0:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.None;
			break;
		case 1:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.Aircraft;
			break;
		case 2:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.Ship;
			break;
		case 3:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.Submarine;
			break;
		case 4:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.Facility;
			break;
		case 5:
			activeUnitType = GlobalVariables.ActiveUnitType.None;
			break;
		case 6:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.Weapon;
			break;
		case 7:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.Satellite;
			break;
		case 8:
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.Vehicle;
			break;
		}
		if (m_BaseAttr.TargetType != activeUnitType)
		{
			m_BaseAttr.TargetSubType = 0;
			m_BaseAttr.SpecificUnitClass = 0;
			m_BaseAttr.SpecificUnitID = null;
			if (Operators.CompareString(base.ParentForm.Name, "EditTrigger", TextCompare: true) == 0 && ((EditTrigger)base.ParentForm).TabPage_0.Visible)
			{
				((EditTrigger)base.ParentForm).CB_BaseStatusCheck_Condition.Items.Clear();
				((EventTrigger_UnitBaseStatus)((EditTrigger)base.ParentForm).theTrigger).TargetCondition = null;
			}
			CheckInterruptiblePrototype();
		}
	}

	private void FillInterruptiblePrototype(object sender, EventArgs e)
	{
		if (CB_TargetSubtype.Items.Count != 0 && Operators.ConditionalCompareObjectNotEqual(m_BaseAttr.TargetSubType, NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "tag", new object[0], null, null, null), TextCompare: true))
		{
			m_BaseAttr.TargetSubType = Conversions.ToInteger(NewLateBinding.LateGet(CB_TargetSubtype.SelectedItem, null, "tag", new object[0], null, null, null));
			m_BaseAttr.SpecificUnitClass = 0;
			m_BaseAttr.SpecificUnitID = null;
			CheckInterruptiblePrototype();
		}
	}

	private void CalculateInterruptiblePrototype(object sender, EventArgs e)
	{
		if (CB_TargetUnitClass.Items.Count != 0 && m_BaseAttr.SpecificUnitClass != Conversions.ToInteger(((ComboBoxItem)CB_TargetUnitClass.SelectedItem).Tag))
		{
			m_BaseAttr.SpecificUnitClass = Conversions.ToInteger(((ComboBoxItem)CB_TargetUnitClass.SelectedItem).Tag);
			m_BaseAttr.SpecificUnitID = null;
			CheckInterruptiblePrototype();
		}
	}

	private void PopInterruptiblePrototype(object sender, EventArgs e)
	{
		if (Operators.ConditionalCompareObjectNotEqual(m_BaseAttr.TargetSide, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "tag", new object[0], null, null, null), TextCompare: true))
		{
			m_BaseAttr.TargetSide = Conversions.ToString(NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "tag", new object[0], null, null, null));
			m_BaseAttr.TargetType = GlobalVariables.ActiveUnitType.None;
			m_BaseAttr.TargetSubType = 0;
			m_BaseAttr.SpecificUnitClass = 0;
			m_BaseAttr.SpecificUnitID = null;
			CheckInterruptiblePrototype();
		}
	}

	private void InstantiateInterruptiblePrototype(object sender, EventArgs e)
	{
		if (NewLateBinding.LateGet(CB_SpecificUnit.SelectedItem, null, "tag", new object[0], null, null, null) is ActiveUnit)
		{
			m_BaseAttr.SpecificUnitID = ((ActiveUnit)NewLateBinding.LateGet(CB_SpecificUnit.SelectedItem, null, "tag", new object[0], null, null, null)).ObjectID;
		}
		else
		{
			m_BaseAttr.SpecificUnitID = null;
		}
	}

	public void WRA_RetreiveLoadoutWeapons(ActiveUnit activeUnit_0)
	{
		if (!Information.IsNothing(((Aircraft)activeUnit_0).Loadout))
		{
			WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
			for (int i = 0; i < weapons.Length; i = checked(i + 1))
			{
				Weapon weapon_ = weapons[i].GetReferenceWeapon(Client.CurrentScenario);
				WRA_AddWeapon(ref weapon_);
			}
		}
	}

	public void WRA_RetreiveMagazineWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Magazine item in activeUnit_0.SharedMagazines.OrderBy((Magazine theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				Weapon weapon_ = weapon.GetReferenceWeapon(Client.CurrentScenario);
				WRA_AddWeapon(ref weapon_);
			}
		}
	}

	public void WRA_RetreiveMountWeapons(ActiveUnit activeUnit_0)
	{
		foreach (Mount item in activeUnit_0.Mounts.OrderBy((Mount theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon weapon_ = mountWeapon.GetReferenceWeapon(Client.CurrentScenario);
				WRA_AddWeapon(ref weapon_);
			}
		}
	}

	public void WRA_RetreiveUnguidedWeapons(UnguidedWeapon unguidedWeapon_0)
	{
		Weapon weapon_ = unguidedWeapon_0.ReferenceWeapon;
		WRA_AddWeapon(ref weapon_);
	}

	public void WRA_AddWeapon(ref Weapon weapon_0)
	{
		if (!m_PolicyAttr.Contains(weapon_0))
		{
			m_PolicyAttr.Add(weapon_0);
		}
	}

	private void CreateInterruptiblePrototype(object sender, EventArgs e)
	{
		m_BaseAttr.ShowAllTypes = CB_ShowAllTypes.Checked;
		InterruptInterruptiblePrototype();
	}

	[CompilerGenerated]
	private bool CompareInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool ReadInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool DisableInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool UpdateInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool InsertInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool PrepareInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool ReflectInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool VisitInterruptiblePrototype(UnguidedWeapon unguidedWeapon_0)
	{
		return Operators.ConditionalCompareObjectEqual(unguidedWeapon_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool RestartInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool TestInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool StopInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool CancelInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool VerifyInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}

	[CompilerGenerated]
	private bool ListInterruptiblePrototype(ActiveUnit activeUnit_0)
	{
		return Operators.ConditionalCompareObjectEqual(activeUnit_0.GetUnitSide().ObjectID, NewLateBinding.LateGet(CB_TargetSide.SelectedItem, null, "Tag", new object[0], null, null, null), TextCompare: true);
	}
}
