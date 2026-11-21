using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command.My.Resources;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class UnitSelection : Form
{
	public class UnitSelectionConfig
	{
		public enum Condition
		{
			IsAirbase,
			IsDock,
			IsMobileGroundUnit,
			IsFacility,
			IsAircraft,
			IsSatellite,
			IsShip,
			IsBoat,
			IsWeapon,
			IsGroup,
			IsAirbaseFacility,
			IsRP,
			IsStandardZone,
			IsDockFacility,
			IsCargoMissionDestination,
			IsDestroyedOrSinking,
			IsOperating
		}

		private Dictionary<Condition, bool> Conditions;

		public List<ActiveUnit> SortUnits(List<ActiveUnit> list_0)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit item in list_0)
			{
				if (FulfillConditions(item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		public bool FulfillConditions(Module_Unit.Unit unit_0)
		{
			ActiveUnit activeUnit = null;
			if (unit_0.IsActiveUnit)
			{
				activeUnit = (ActiveUnit)unit_0;
			}
			else if (unit_0.DisableWriter())
			{
				activeUnit = ((Contact)unit_0).ActualUnit;
			}
			foreach (KeyValuePair<Condition, bool> condition in Conditions)
			{
				switch (condition.Key)
				{
				case Condition.IsAirbase:
					if (condition.Value)
					{
						if (activeUnit == null || (!unit_0.IsSingleUnitAirbase && (!activeUnit.HasAirFacilities || (!unit_0.IsGroup && !unit_0.IsShip && !unit_0.IsBoat))))
						{
							return false;
						}
					}
					else if (unit_0.IsSingleUnitAirbase || (activeUnit.HasAirFacilities && (unit_0.IsGroup || unit_0.IsShip || unit_0.IsBoat)))
					{
						return false;
					}
					break;
				case Condition.IsDock:
					if (condition.Value)
					{
						if (activeUnit == null || !activeUnit.HasDockFacilities || (!unit_0.IsGroup && !unit_0.IsBoat && !unit_0.IsShip))
						{
							return false;
						}
					}
					else if (activeUnit.HasDockFacilities && (unit_0.IsGroup || unit_0.IsBoat || unit_0.IsShip))
					{
						return false;
					}
					break;
				case Condition.IsMobileGroundUnit:
					if (condition.Value)
					{
						if (!unit_0.IsMobileGroundUnit)
						{
							return false;
						}
					}
					else if (unit_0.IsMobileGroundUnit)
					{
						return false;
					}
					break;
				case Condition.IsFacility:
					if (condition.Value)
					{
						if (!unit_0.IsFacility)
						{
							return false;
						}
					}
					else if (unit_0.IsFacility)
					{
						return false;
					}
					break;
				case Condition.IsAircraft:
					if (condition.Value)
					{
						if (!unit_0.IsAircraft)
						{
							return false;
						}
					}
					else if (unit_0.IsAircraft)
					{
						return false;
					}
					break;
				case Condition.IsSatellite:
					if (condition.Value)
					{
						if (!unit_0.IsSatellite)
						{
							return false;
						}
					}
					else if (unit_0.IsSatellite)
					{
						return false;
					}
					break;
				case Condition.IsShip:
					if (condition.Value)
					{
						if (!unit_0.IsShip)
						{
							return false;
						}
					}
					else if (unit_0.IsShip)
					{
						return false;
					}
					break;
				case Condition.IsBoat:
					if (condition.Value)
					{
						if (!unit_0.IsBoat)
						{
							return false;
						}
					}
					else if (unit_0.IsBoat)
					{
						return false;
					}
					break;
				case Condition.IsWeapon:
					if (condition.Value)
					{
						if (!unit_0.IsWeapon)
						{
							return false;
						}
					}
					else if (unit_0.IsWeapon)
					{
						return false;
					}
					break;
				case Condition.IsGroup:
					if (condition.Value)
					{
						if (!unit_0.IsGroup)
						{
							return false;
						}
					}
					else if (unit_0.IsGroup)
					{
						return false;
					}
					break;
				case Condition.IsAirbaseFacility:
					if (condition.Value)
					{
						if (activeUnit == null || !activeUnit.HasAirFacilities)
						{
							return false;
						}
					}
					else if (activeUnit.HasAirFacilities)
					{
						return false;
					}
					break;
				case Condition.IsDockFacility:
					if (condition.Value)
					{
						if (activeUnit == null || !activeUnit.HasDockFacilities)
						{
							return false;
						}
					}
					else if (activeUnit.HasDockFacilities)
					{
						return false;
					}
					break;
				case Condition.IsCargoMissionDestination:
					if (condition.Value)
					{
						if (!CargoMission.IsValidDestinationUnit(unit_0, bool_0: true))
						{
							return false;
						}
					}
					else if (CargoMission.IsValidDestinationUnit(unit_0, bool_0: true))
					{
						return false;
					}
					break;
				case Condition.IsDestroyedOrSinking:
					if (condition.Value)
					{
						if (activeUnit == null || activeUnit.IsDestroyed || (activeUnit.IsShip && ((Ship)activeUnit).IsSinking))
						{
							return true;
						}
						break;
					}
					return true;
				case Condition.IsOperating:
					if (condition.Value)
					{
						if (activeUnit != null && !activeUnit.IsOperating())
						{
							return false;
						}
						break;
					}
					return true;
				}
			}
			return true;
		}

		public UnitSelectionConfig(Dictionary<Condition, bool> dictionary_0 = null)
		{
			Conditions = new Dictionary<Condition, bool>();
			if (dictionary_0 != null)
			{
				Conditions = dictionary_0;
			}
		}

		public static UnitSelectionConfig DefaultUnitSelection(bool? nullable_0 = null)
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			dictionary.Add(Condition.IsGroup, value: false);
			dictionary.Add(Condition.IsWeapon, value: false);
			dictionary.Add(Condition.IsStandardZone, value: false);
			dictionary.Add(Condition.IsRP, value: false);
			if (nullable_0.HasValue)
			{
				dictionary.Add(Condition.IsDestroyedOrSinking, !nullable_0.Value);
				dictionary.Add(Condition.IsOperating, !nullable_0.Value);
			}
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultAirbase(bool bool_0 = true)
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			if (bool_0)
			{
				dictionary.Add(Condition.IsAirbaseFacility, value: true);
			}
			dictionary.Add(Condition.IsAirbase, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultDock(bool bool_0 = true)
		{
			Dictionary<Condition, bool> dictionary = new Dictionary<Condition, bool>();
			if (bool_0)
			{
				dictionary.Add(Condition.IsDockFacility, value: true);
			}
			dictionary.Add(Condition.IsDock, value: true);
			return new UnitSelectionConfig(dictionary);
		}

		public static UnitSelectionConfig DefaultZone()
		{
			return new UnitSelectionConfig(new Dictionary<Condition, bool> { 
			{
				Condition.IsStandardZone,
				true
			} });
		}

		public static UnitSelectionConfig DefaultRP()
		{
			return new UnitSelectionConfig(new Dictionary<Condition, bool> { 
			{
				Condition.IsRP,
				true
			} });
		}

		public static UnitSelectionConfig DefaultCargoMissionDestination()
		{
			return new UnitSelectionConfig(new Dictionary<Condition, bool> { 
			{
				Condition.IsCargoMissionDestination,
				true
			} });
		}

		public static UnitSelectionConfig DefaultGroup()
		{
			return new UnitSelectionConfig(new Dictionary<Condition, bool> { 
			{
				Condition.IsGroup,
				true
			} });
		}

		public bool? GetConditionValue(Condition condition_0)
		{
			if (!Conditions.ContainsKey(condition_0))
			{
				return null;
			}
			return Conditions[condition_0];
		}

		public void MustBe(Condition condition_0)
		{
			if (Conditions.ContainsKey(condition_0))
			{
				Conditions[condition_0] = true;
			}
			else
			{
				Conditions.Add(condition_0, value: true);
			}
		}

		public void MustNotBe(Condition condition_0)
		{
			if (Conditions.ContainsKey(condition_0))
			{
				Conditions[condition_0] = false;
			}
			else
			{
				Conditions.Add(condition_0, value: false);
			}
		}

		public void NoCondition(Condition condition_0)
		{
			if (Conditions.ContainsKey(condition_0))
			{
				Conditions.Remove(condition_0);
			}
		}
	}

	private IContainer m_StateAttr;

	[AccessedThroughProperty("ButtonToggle_ShowSpaceUnit_Unassigned")]
	[CompilerGenerated]
	private Button m_AuthenticationAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowLandUnit_Unassigned")]
	private Button paramsAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowAirUnit_Unassigned")]
	private Button infoAttr;

	[AccessedThroughProperty("ButtonToggle_ShowNavalUnit_Unassigned")]
	[CompilerGenerated]
	private Button m_HelperAttr;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Confirm")]
	private DarkUIButton m_MapperAttr;

	[AccessedThroughProperty("ButtonCancel")]
	[CompilerGenerated]
	private DarkUIButton managerAttr;

	[AccessedThroughProperty("LV_Units")]
	[CompilerGenerated]
	private DarkListView m_GetterAttr;

	[AccessedThroughProperty("Button_Filter")]
	[CompilerGenerated]
	private DarkUIButton procAttr;

	[AccessedThroughProperty("FlowLayoutPanel1")]
	[CompilerGenerated]
	private FlowLayoutPanel m_StructVisitor;

	[AccessedThroughProperty("FlowLayoutPanel2")]
	[CompilerGenerated]
	private FlowLayoutPanel m_MerchantVisitor;

	[AccessedThroughProperty("Button_Action_Delete")]
	[CompilerGenerated]
	private DarkUIButton m_CallbackVisitor;

	[AccessedThroughProperty("ButtonToggle_ShowRP")]
	[CompilerGenerated]
	private Button decoratorVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonToggle_ShowStandardZone")]
	private Button m_ProcessVisitor;

	private bool m_ThreadVisitor;

	private bool m_RuleVisitor;

	private bool _CollectionVisitor;

	private bool _InstanceVisitor;

	private bool _ObjectVisitor;

	private bool parameterVisitor;

	private bool _ExpressionVisitor;

	public UnitSelectionConfig Configuration;

	private List<Side> dispatcherVisitor;

	internal virtual Button ButtonToggle_ShowSpaceUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return m_AuthenticationAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleComparator;
			Button authenticationAttr = m_AuthenticationAttr;
			if (authenticationAttr != null)
			{
				authenticationAttr.Click -= value2;
			}
			m_AuthenticationAttr = value;
			authenticationAttr = m_AuthenticationAttr;
			if (authenticationAttr != null)
			{
				authenticationAttr.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowLandUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return paramsAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleComparator;
			Button button = paramsAttr;
			if (button != null)
			{
				button.Click -= value2;
			}
			paramsAttr = value;
			button = paramsAttr;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowAirUnit_Unassigned
	{
		[CompilerGenerated]
		get
		{
			return infoAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleComparator;
			Button button = infoAttr;
			if (button != null)
			{
				button.Click -= value2;
			}
			infoAttr = value;
			button = infoAttr;
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
			return m_HelperAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopInterruptibleComparator;
			Button helperAttr = m_HelperAttr;
			if (helperAttr != null)
			{
				helperAttr.Click -= value2;
			}
			m_HelperAttr = value;
			helperAttr = m_HelperAttr;
			if (helperAttr != null)
			{
				helperAttr.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_Confirm
	{
		[CompilerGenerated]
		get
		{
			return m_MapperAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeInterruptibleComparator;
			DarkUIButton mapperAttr = m_MapperAttr;
			if (mapperAttr != null)
			{
				mapperAttr.Click -= value2;
			}
			m_MapperAttr = value;
			mapperAttr = m_MapperAttr;
			if (mapperAttr != null)
			{
				mapperAttr.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonCancel
	{
		[CompilerGenerated]
		get
		{
			return managerAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryInterruptibleComparator;
			DarkUIButton darkUIButton = managerAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			managerAttr = value;
			darkUIButton = managerAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkListView LV_Units
	{
		[CompilerGenerated]
		get
		{
			return m_GetterAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineInterruptibleComparator;
			DarkListView getterAttr = m_GetterAttr;
			if (getterAttr != null)
			{
				getterAttr.SelectedIndicesChanged -= value2;
			}
			m_GetterAttr = value;
			getterAttr = m_GetterAttr;
			if (getterAttr != null)
			{
				getterAttr.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TB_Filter")]
	internal virtual DarkUITextBox TB_Filter
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton Button_Filter
	{
		[CompilerGenerated]
		get
		{
			return procAttr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishInterruptibleComparator;
			DarkUIButton darkUIButton = procAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			procAttr = value;
			darkUIButton = procAttr;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return m_StructVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StructVisitor = value;
		}
	}

	internal virtual FlowLayoutPanel FlowLayoutPanel2
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MerchantVisitor = value;
		}
	}

	internal virtual DarkUIButton Button_Action_Delete
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetInterruptibleComparator;
			DarkUIButton callbackVisitor = m_CallbackVisitor;
			if (callbackVisitor != null)
			{
				callbackVisitor.Click -= value2;
			}
			m_CallbackVisitor = value;
			callbackVisitor = m_CallbackVisitor;
			if (callbackVisitor != null)
			{
				callbackVisitor.Click += value2;
			}
		}
	}

	internal virtual Button ButtonToggle_ShowRP
	{
		[CompilerGenerated]
		get
		{
			return decoratorVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapInterruptibleComparator;
			Button button = decoratorVisitor;
			if (button != null)
			{
				button.Click -= value2;
			}
			decoratorVisitor = value;
			button = decoratorVisitor;
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
			return m_ProcessVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortInterruptibleComparator;
			Button processVisitor = m_ProcessVisitor;
			if (processVisitor != null)
			{
				processVisitor.Click -= value2;
			}
			m_ProcessVisitor = value;
			processVisitor = m_ProcessVisitor;
			if (processVisitor != null)
			{
				processVisitor.Click += value2;
			}
		}
	}

	public UnitSelection()
	{
		m_ThreadVisitor = true;
		m_RuleVisitor = true;
		_CollectionVisitor = true;
		_InstanceVisitor = true;
		_ObjectVisitor = true;
		parameterVisitor = true;
		_ExpressionVisitor = true;
		dispatcherVisitor = new List<Side>();
		RestartInterruptibleComparator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_StateAttr != null)
			{
				m_StateAttr.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RestartInterruptibleComparator()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(UnitSelection));
		ButtonToggle_ShowSpaceUnit_Unassigned = new Button();
		ButtonToggle_ShowLandUnit_Unassigned = new Button();
		ButtonToggle_ShowAirUnit_Unassigned = new Button();
		ButtonToggle_ShowNavalUnit_Unassigned = new Button();
		LV_Units = new DarkListView();
		Button_Filter = new DarkUIButton();
		TB_Filter = new DarkUITextBox();
		ButtonCancel = new DarkUIButton();
		Button_Confirm = new DarkUIButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		ButtonToggle_ShowStandardZone = new Button();
		ButtonToggle_ShowRP = new Button();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		Button_Action_Delete = new DarkUIButton();
		FlowLayoutPanel1.SuspendLayout();
		FlowLayoutPanel2.SuspendLayout();
		SuspendLayout();
		ButtonToggle_ShowSpaceUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowSpaceUnit_Unassigned.BackgroundImage = Resources.sattelite;
		ButtonToggle_ShowSpaceUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowSpaceUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowSpaceUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowSpaceUnit_Unassigned.Location = new Point(159, 3);
		ButtonToggle_ShowSpaceUnit_Unassigned.Name = "ButtonToggle_ShowSpaceUnit_Unassigned";
		ButtonToggle_ShowSpaceUnit_Unassigned.Size = new Size(46, 19);
		ButtonToggle_ShowSpaceUnit_Unassigned.TabIndex = 36;
		ButtonToggle_ShowSpaceUnit_Unassigned.UseVisualStyleBackColor = false;
		ButtonToggle_ShowLandUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowLandUnit_Unassigned.BackgroundImage = Resources.Tank1;
		ButtonToggle_ShowLandUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowLandUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowLandUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowLandUnit_Unassigned.Location = new Point(3, 3);
		ButtonToggle_ShowLandUnit_Unassigned.Name = "ButtonToggle_ShowLandUnit_Unassigned";
		ButtonToggle_ShowLandUnit_Unassigned.Size = new Size(46, 19);
		ButtonToggle_ShowLandUnit_Unassigned.TabIndex = 35;
		ButtonToggle_ShowLandUnit_Unassigned.UseVisualStyleBackColor = false;
		ButtonToggle_ShowAirUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowAirUnit_Unassigned.BackgroundImage = Resources.Aircraft;
		ButtonToggle_ShowAirUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowAirUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowAirUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowAirUnit_Unassigned.Location = new Point(107, 3);
		ButtonToggle_ShowAirUnit_Unassigned.Name = "ButtonToggle_ShowAirUnit_Unassigned";
		ButtonToggle_ShowAirUnit_Unassigned.Size = new Size(46, 19);
		ButtonToggle_ShowAirUnit_Unassigned.TabIndex = 34;
		ButtonToggle_ShowAirUnit_Unassigned.UseVisualStyleBackColor = false;
		ButtonToggle_ShowNavalUnit_Unassigned.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowNavalUnit_Unassigned.BackgroundImage = Resources.Ship;
		ButtonToggle_ShowNavalUnit_Unassigned.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowNavalUnit_Unassigned.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowNavalUnit_Unassigned.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowNavalUnit_Unassigned.Location = new Point(55, 3);
		ButtonToggle_ShowNavalUnit_Unassigned.Name = "ButtonToggle_ShowNavalUnit_Unassigned";
		ButtonToggle_ShowNavalUnit_Unassigned.Size = new Size(46, 19);
		ButtonToggle_ShowNavalUnit_Unassigned.TabIndex = 33;
		ButtonToggle_ShowNavalUnit_Unassigned.UseVisualStyleBackColor = false;
		LV_Units.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		LV_Units.BackColor = Color.FromArgb(40, 43, 45);
		LV_Units.Location = new Point(12, 37);
		LV_Units.MinimumSize = new Size(401, 268);
		LV_Units.Name = "LV_Units";
		LV_Units.RelatedInfos = null;
		LV_Units.Size = new Size(520, 268);
		LV_Units.TabIndex = 41;
		LV_Units.Text = "LV_Units";
		Button_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Filter.BackColor = Color.Transparent;
		Button_Filter.DialogResult = DialogResult.None;
		Button_Filter.Font = new Font("Segoe UI", 8.25f);
		Button_Filter.ForeColor = SystemColors.Control;
		Button_Filter.Location = new Point(505, 12);
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
		TB_Filter.Location = new Point(359, 12);
		TB_Filter.MaxLength = 32767;
		TB_Filter.Multiline = false;
		TB_Filter.Name = "TB_Filter";
		TB_Filter.ReadOnly = false;
		TB_Filter.ScrollBars = ScrollBars.None;
		TB_Filter.SelectionStart = 0;
		TB_Filter.Size = new Size(140, 19);
		TB_Filter.TabIndex = 42;
		TB_Filter.TextAlign = HorizontalAlignment.Left;
		TB_Filter.UseSystemPasswordChar = false;
		TB_Filter.WatermarkText = "Filter by name, class, side.";
		ButtonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ButtonCancel.BackColor = Color.Transparent;
		ButtonCancel.DialogResult = DialogResult.Cancel;
		ButtonCancel.Font = new Font("Segoe UI", 8.25f);
		ButtonCancel.ForeColor = SystemColors.Control;
		ButtonCancel.Location = new Point(74, 3);
		ButtonCancel.Name = "ButtonCancel";
		ButtonCancel.Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		ButtonCancel.Size = new Size(75, 28);
		ButtonCancel.TabIndex = 40;
		ButtonCancel.Text = "取消";
		Button_Confirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Confirm.BackColor = Color.Transparent;
		Button_Confirm.DialogResult = DialogResult.OK;
		Button_Confirm.Font = new Font("Segoe UI", 8.25f);
		Button_Confirm.ForeColor = SystemColors.Control;
		Button_Confirm.Location = new Point(155, 3);
		Button_Confirm.Name = "Button_Confirm";
		Button_Confirm.Padding = new Padding(5);
		Button_Confirm.RoundRadius = 0;
		Button_Confirm.Size = new Size(352, 28);
		Button_Confirm.TabIndex = 38;
		Button_Confirm.Text = "确认";
		FlowLayoutPanel1.Controls.Add(ButtonToggle_ShowLandUnit_Unassigned);
		FlowLayoutPanel1.Controls.Add(ButtonToggle_ShowNavalUnit_Unassigned);
		FlowLayoutPanel1.Controls.Add(ButtonToggle_ShowAirUnit_Unassigned);
		FlowLayoutPanel1.Controls.Add(ButtonToggle_ShowSpaceUnit_Unassigned);
		FlowLayoutPanel1.Controls.Add(ButtonToggle_ShowStandardZone);
		FlowLayoutPanel1.Controls.Add(ButtonToggle_ShowRP);
		FlowLayoutPanel1.Location = new Point(13, 10);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(317, 25);
		FlowLayoutPanel1.TabIndex = 44;
		ButtonToggle_ShowStandardZone.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowStandardZone.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowStandardZone.BackgroundImage");
		ButtonToggle_ShowStandardZone.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowStandardZone.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowStandardZone.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowStandardZone.Location = new Point(211, 3);
		ButtonToggle_ShowStandardZone.Name = "ButtonToggle_ShowStandardZone";
		ButtonToggle_ShowStandardZone.Size = new Size(46, 19);
		ButtonToggle_ShowStandardZone.TabIndex = 38;
		ButtonToggle_ShowStandardZone.UseVisualStyleBackColor = false;
		ButtonToggle_ShowRP.BackColor = Color.FromArgb(64, 64, 64);
		ButtonToggle_ShowRP.BackgroundImage = componentResourceManager.GetObject("ButtonToggle_ShowRP.BackgroundImage");
		ButtonToggle_ShowRP.BackgroundImageLayout = ImageLayout.Stretch;
		ButtonToggle_ShowRP.FlatAppearance.BorderColor = Color.LimeGreen;
		ButtonToggle_ShowRP.FlatStyle = FlatStyle.Flat;
		ButtonToggle_ShowRP.Location = new Point(263, 3);
		ButtonToggle_ShowRP.Name = "ButtonToggle_ShowRP";
		ButtonToggle_ShowRP.Size = new Size(47, 19);
		ButtonToggle_ShowRP.TabIndex = 37;
		ButtonToggle_ShowRP.UseVisualStyleBackColor = false;
		FlowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		FlowLayoutPanel2.Controls.Add(Button_Action_Delete);
		FlowLayoutPanel2.Controls.Add(ButtonCancel);
		FlowLayoutPanel2.Controls.Add(Button_Confirm);
		FlowLayoutPanel2.Location = new Point(12, 311);
		FlowLayoutPanel2.Name = "FlowLayoutPanel2";
		FlowLayoutPanel2.Size = new Size(520, 33);
		FlowLayoutPanel2.TabIndex = 45;
		Button_Action_Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Action_Delete.BackColor = Color.Transparent;
		Button_Action_Delete.DialogResult = DialogResult.OK;
		Button_Action_Delete.Font = new Font("Segoe UI", 8.25f);
		Button_Action_Delete.ForeColor = SystemColors.Control;
		Button_Action_Delete.Location = new Point(3, 3);
		Button_Action_Delete.Name = "Button_Action_Delete";
		Button_Action_Delete.Padding = new Padding(5);
		Button_Action_Delete.RoundRadius = 0;
		Button_Action_Delete.Size = new Size(65, 28);
		Button_Action_Delete.TabIndex = 41;
		Button_Action_Delete.Text = "删除";
		base.AcceptButton = Button_Confirm;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.CancelButton = ButtonCancel;
		base.ClientSize = new Size(544, 356);
		base.Controls.Add(FlowLayoutPanel2);
		base.Controls.Add(FlowLayoutPanel1);
		base.Controls.Add(Button_Filter);
		base.Controls.Add(TB_Filter);
		base.Controls.Add(LV_Units);
		MinimumSize = new Size(441, 343);
		base.Name = "UnitSelection";
		Text = "选择单元";
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		FlowLayoutPanel2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	public static void CallDialogWithUnits(List<ActiveUnit> list_0, bool bool_0, ref List<ActiveUnit> list_1)
	{
		UnitSelection unitSelection = new UnitSelection();
		unitSelection.Configuration = UnitSelectionConfig.DefaultUnitSelection();
		unitSelection.Button_Action_Delete.Visible = false;
		unitSelection.LV_Units.MultiSelect = bool_0;
		unitSelection.dispatcherVisitor.Add(Client.CurrentSide);
		unitSelection.RefreshFilter();
		unitSelection.RefreshUnitList(list_0);
		if (unitSelection.ShowDialog() == DialogResult.OK)
		{
			List<ReferencePoint> list_2 = null;
			List<Zone> list_3 = null;
			unitSelection.FetchSelectedUnits(ref list_1, ref list_2, ref list_3);
		}
	}

	public static void CallDialog(List<Side> list_0, bool bool_0, ref List<ActiveUnit> list_1, ref List<ReferencePoint> list_2, ref List<Zone> list_3, UnitSelectionConfig unitSelectionConfig_0 = null, bool bool_1 = true)
	{
		UnitSelection unitSelection = new UnitSelection();
		if (unitSelectionConfig_0 == null)
		{
			unitSelection.Configuration = UnitSelectionConfig.DefaultUnitSelection();
		}
		else
		{
			unitSelection.Configuration = unitSelectionConfig_0;
		}
		unitSelection.Button_Action_Delete.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit || Client.CurrentGame.GameMode == Game._GameMode.MultiplayerScenEdit;
		if (!bool_1)
		{
			unitSelection.Button_Action_Delete.Visible = false;
		}
		unitSelection.LV_Units.MultiSelect = bool_0;
		unitSelection.dispatcherVisitor = list_0;
		unitSelection.RefreshFilter();
		unitSelection.RefreshUnitList();
		if (unitSelection.ShowDialog() == DialogResult.OK)
		{
			unitSelection.FetchSelectedUnits(ref list_1, ref list_2, ref list_3);
		}
	}

	public static void CallDialog(Side side_0, bool bool_0, ref List<ActiveUnit> list_0, ref List<ReferencePoint> list_1, ref List<Zone> list_2, UnitSelectionConfig unitSelectionConfig_0 = null, bool bool_1 = true)
	{
		CallDialog(new List<Side> { side_0 }, bool_0, ref list_0, ref list_1, ref list_2, unitSelectionConfig_0, bool_1);
	}

	public static void CallDialog(bool bool_0, ref List<ActiveUnit> list_0, ref List<ReferencePoint> list_1, ref List<Zone> list_2, UnitSelectionConfig unitSelectionConfig_0 = null, bool bool_1 = true)
	{
		CallDialog(new List<Side> { Client.CurrentSide }, bool_0, ref list_0, ref list_1, ref list_2, unitSelectionConfig_0, bool_1);
	}

	public void FetchSelectedUnits(ref List<ActiveUnit> list_0, ref List<ReferencePoint> list_1, ref List<Zone> list_2)
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
				if (!activeUnit.IsDestroyed)
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

	private bool TestInterruptibleComparator(ActiveUnit activeUnit_0, string string_0, bool bool_0 = true)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return true;
		}
		if (bool_0)
		{
			string[] array = string_0.Split(' ');
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					string value = array[num];
					if (!string.IsNullOrWhiteSpace(value) && !activeUnit_0.Name.ToLower().Contains(value) && !activeUnit_0.UnitClass.ToLower().Contains(value) && !activeUnit_0.GetUnitSide().Name.ToLower().Contains(value))
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
		if (activeUnit_0.Name.ToLower().Contains(string_0))
		{
			return true;
		}
		if (activeUnit_0.UnitClass.ToLower().Contains(string_0))
		{
			return true;
		}
		if (activeUnit_0.GetUnitSide().Name.ToLower().Contains(string_0))
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
		m_ThreadVisitor = false;
		m_RuleVisitor = false;
		_CollectionVisitor = false;
		_InstanceVisitor = false;
		_ObjectVisitor = false;
		parameterVisitor = false;
		_ExpressionVisitor = false;
		if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAircraft).GetValueOrDefault())
		{
			ButtonToggle_ShowAirUnit_Unassigned.Visible = true;
			m_ThreadVisitor = true;
		}
		else if (!Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsBoat).GetValueOrDefault() && !Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsShip).GetValueOrDefault())
		{
			if (!Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsFacility).GetValueOrDefault() && !Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsMobileGroundUnit).GetValueOrDefault())
			{
				if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsSatellite).GetValueOrDefault())
				{
					ButtonToggle_ShowSpaceUnit_Unassigned.Visible = true;
					_InstanceVisitor = true;
				}
				else if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsRP).GetValueOrDefault())
				{
					ButtonToggle_ShowRP.Visible = true;
					parameterVisitor = true;
				}
				else if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsStandardZone).GetValueOrDefault())
				{
					ButtonToggle_ShowStandardZone.Visible = true;
					_ExpressionVisitor = true;
				}
				else if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsGroup).GetValueOrDefault())
				{
					_ObjectVisitor = true;
				}
				else if (!Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAirbase).GetValueOrDefault() && !Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsDock).GetValueOrDefault())
				{
					if (Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsCargoMissionDestination).GetValueOrDefault())
					{
						ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
						_CollectionVisitor = true;
						ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
						m_RuleVisitor = true;
						return;
					}
					ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
					ButtonToggle_ShowAirUnit_Unassigned.Visible = true;
					ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
					ButtonToggle_ShowSpaceUnit_Unassigned.Visible = true;
					ButtonToggle_ShowStandardZone.Visible = true;
					ButtonToggle_ShowRP.Visible = true;
					m_ThreadVisitor = true;
					m_RuleVisitor = true;
					_CollectionVisitor = true;
					_InstanceVisitor = true;
					parameterVisitor = true;
					_ExpressionVisitor = true;
					bool? conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAircraft);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowAirUnit_Unassigned.Visible = false;
						m_ThreadVisitor = false;
						return;
					}
					bool? conditionValue2 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsBoat);
					conditionValue = (!conditionValue2) ?? conditionValue2;
					if (conditionValue.GetValueOrDefault(true))
					{
						conditionValue2 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsShip);
						if (((!conditionValue2) ?? conditionValue2).GetValueOrDefault() && conditionValue.HasValue)
						{
							ButtonToggle_ShowNavalUnit_Unassigned.Visible = false;
							_CollectionVisitor = false;
							return;
						}
					}
					bool? conditionValue3 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsFacility);
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
						conditionValue3 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsMobileGroundUnit);
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
						flag3 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsAirbase);
						bool? flag5;
						flag3 = (flag5 = (!flag3) ?? flag3);
						flag4 = ((!flag3.HasValue) ? null : (flag5.GetValueOrDefault() & conditionValue2));
					}
					conditionValue = flag4;
					if (conditionValue.GetValueOrDefault(true))
					{
						bool? conditionValue4 = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsDock);
						if (((!conditionValue4) ?? conditionValue4).GetValueOrDefault() && conditionValue.HasValue)
						{
							ButtonToggle_ShowLandUnit_Unassigned.Visible = false;
							m_RuleVisitor = false;
							return;
						}
					}
					conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsSatellite);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowSpaceUnit_Unassigned.Visible = false;
						_InstanceVisitor = false;
						return;
					}
					conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsStandardZone);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowStandardZone.Visible = false;
						_ExpressionVisitor = false;
						return;
					}
					conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsRP);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						ButtonToggle_ShowRP.Visible = false;
						parameterVisitor = false;
						return;
					}
					conditionValue = Configuration.GetConditionValue(UnitSelectionConfig.Condition.IsGroup);
					if (((!conditionValue) ?? conditionValue).GetValueOrDefault())
					{
						_ObjectVisitor = false;
					}
				}
				else
				{
					ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
					_CollectionVisitor = true;
					ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
					m_RuleVisitor = true;
				}
			}
			else
			{
				ButtonToggle_ShowLandUnit_Unassigned.Visible = true;
				m_RuleVisitor = true;
			}
		}
		else
		{
			ButtonToggle_ShowNavalUnit_Unassigned.Visible = true;
			_CollectionVisitor = true;
		}
	}

	public void RefreshUnitList(List<ActiveUnit> list_0)
	{
		LV_Units.Items.Clear();
		string text = TB_Filter.Text.ToLower();
		foreach (ActiveUnit item in list_0)
		{
			if ((!item.IsAircraft || m_ThreadVisitor) && ((!item.IsFacility && !item.IsMobileGroundUnit) || m_RuleVisitor) && ((!item.IsShip && !item.IsBoat) || _CollectionVisitor) && (!item.IsSatellite || _InstanceVisitor) && (string.IsNullOrWhiteSpace(text) || TestInterruptibleComparator(item, text)) && Configuration.FulfillConditions(item))
			{
				DarkListItem darkListItem = (item.IsGroup ? new DarkListItem(item.Name + " - " + item.SubTypeDescription) : new DarkListItem(item.Name + " - " + item.UnitClass));
				darkListItem.Tag = item;
				LV_Units.Items.Add(darkListItem);
			}
		}
		Refresh();
	}

	public void RefreshUnitList()
	{
		int num = -1;
		if (LV_Units.SelectedIndices.Count > 0)
		{
			num = LV_Units.SelectedIndices.ElementAt(0);
		}
		LV_Units.Items.Clear();
		string text = TB_Filter.Text.ToLower();
		foreach (Side item in dispatcherVisitor)
		{
			foreach (ActiveUnit unit in item.Units)
			{
				if ((unit.IsAircraft && !m_ThreadVisitor) || ((unit.IsFacility || unit.IsMobileGroundUnit) && !m_RuleVisitor) || ((unit.IsShip || unit.IsBoat) && !_CollectionVisitor) || (unit.IsSatellite && !_InstanceVisitor) || (unit.IsGroup && !_ObjectVisitor) || (!string.IsNullOrWhiteSpace(text) && !TestInterruptibleComparator(unit, text)) || !Configuration.FulfillConditions(unit))
				{
					continue;
				}
				DarkListItem darkListItem;
				if (dispatcherVisitor.Count <= 1)
				{
					darkListItem = (unit.IsGroup ? new DarkListItem(unit.Name + " - " + unit.SubTypeDescription) : new DarkListItem(unit.Name + " - " + unit.UnitClass));
				}
				else
				{
					darkListItem = new DarkListItem("[" + unit.GetUnitSide().Name + "] " + unit.Name + " - " + unit.UnitClass);
					if (unit.GetUnitSide().AssignedFixedColor.HasValue)
					{
						darkListItem.TextColor = unit.GetUnitSide().AssignedFixedColor.Value;
					}
				}
				darkListItem.Tag = unit;
				LV_Units.Items.Add(darkListItem);
			}
			if (parameterVisitor)
			{
				foreach (ReferencePoint refPoint in item.RefPoints)
				{
					DarkListItem darkListItem2;
					if (dispatcherVisitor.Count <= 1)
					{
						darkListItem2 = new DarkListItem(refPoint.Name);
					}
					else
					{
						darkListItem2 = new DarkListItem("[" + item.Name + "] " + refPoint.Name);
						if (item.AssignedFixedColor.HasValue)
						{
							darkListItem2.TextColor = item.AssignedFixedColor.Value;
						}
					}
					darkListItem2.Tag = refPoint;
					LV_Units.Items.Add(darkListItem2);
				}
			}
			if (!_ExpressionVisitor)
			{
				continue;
			}
			foreach (Zone standardZone in item.StandardZones)
			{
				DarkListItem darkListItem3;
				if (dispatcherVisitor.Count <= 1)
				{
					darkListItem3 = new DarkListItem(standardZone.Description);
				}
				else
				{
					darkListItem3 = new DarkListItem("[" + item.Name + "] " + standardZone.Description);
					if (item.AssignedFixedColor.HasValue)
					{
						darkListItem3.TextColor = item.AssignedFixedColor.Value;
					}
				}
				darkListItem3.Tag = standardZone;
				LV_Units.Items.Add(darkListItem3);
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
		Refresh();
	}

	private void StopInterruptibleComparator(object sender, EventArgs e)
	{
		ResolveInterruptibleComparator();
	}

	private void CancelInterruptibleComparator(object sender, EventArgs e)
	{
		PostInterruptibleComparator();
	}

	private void VerifyInterruptibleComparator(object sender, EventArgs e)
	{
		RunInterruptibleComparator();
	}

	private void ListInterruptibleComparator(object sender, EventArgs e)
	{
		StartInterruptibleComparator();
	}

	private void ResolveInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			_CollectionVisitor = !_CollectionVisitor;
		}
		else
		{
			_CollectionVisitor = int_0 != 0;
		}
		if (_CollectionVisitor)
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

	private void PostInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			m_ThreadVisitor = !m_ThreadVisitor;
		}
		else
		{
			m_ThreadVisitor = int_0 != 0;
		}
		if (m_ThreadVisitor)
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

	private void RunInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			m_RuleVisitor = !m_RuleVisitor;
		}
		else
		{
			m_RuleVisitor = int_0 != 0;
		}
		if (m_RuleVisitor)
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

	private void StartInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			_InstanceVisitor = !_InstanceVisitor;
		}
		else
		{
			_InstanceVisitor = int_0 != 0;
		}
		if (_InstanceVisitor)
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

	private void AssetInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			parameterVisitor = !parameterVisitor;
		}
		else
		{
			parameterVisitor = int_0 != 0;
		}
		if (parameterVisitor)
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

	private void PrintInterruptibleComparator(int int_0 = -1)
	{
		if (int_0 == -1)
		{
			_ExpressionVisitor = !_ExpressionVisitor;
		}
		else
		{
			_ExpressionVisitor = int_0 != 0;
		}
		if (_ExpressionVisitor)
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

	private void DefineInterruptibleComparator(object sender, EventArgs e)
	{
		if (LV_Units.SelectedItems.Count == 0)
		{
			return;
		}
		if (LV_Units.SelectedItems.ElementAt(0).Tag is ActiveUnit)
		{
			ActiveUnit activeUnit = (ActiveUnit)LV_Units.SelectedItems.ElementAt(0).Tag;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.SetMapCenter(bool_0: true, new GeoPoint(activeUnit.GetLongitude(), activeUnit.GetLatitude()));
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

	private void PublishInterruptibleComparator(object sender, EventArgs e)
	{
		RefreshUnitList();
	}

	private void AwakeInterruptibleComparator(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void QueryInterruptibleComparator(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void ResetInterruptibleComparator(object sender, EventArgs e)
	{
		List<ActiveUnit> list_ = null;
		List<ReferencePoint> list_2 = null;
		List<Zone> list_3 = null;
		FetchSelectedUnits(ref list_, ref list_2, ref list_3);
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
		RefreshUnitList();
	}

	private void MapInterruptibleComparator(object sender, EventArgs e)
	{
		AssetInterruptibleComparator();
	}

	private void SortInterruptibleComparator(object sender, EventArgs e)
	{
		PrintInterruptibleComparator();
	}
}
