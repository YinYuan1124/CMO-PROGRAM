using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using Command.Listeners;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class UnitDoctrine_WPF : System.Windows.Controls.UserControl, IComponentConnector
{
	public List<SpecificDoctrineViewModel> SpecificDoctrineCache;

	[CompilerGenerated]
	private bool m_AdapterAttr;

	private bool schemaAttr;

	private bool _contentLoaded;

	public bool SelectionChangedByUser
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterAttr;
		}
		[CompilerGenerated]
		set
		{
			m_AdapterAttr = value;
		}
	}

	public UnitDoctrine_WPF()
	{
		SelectionChangedByUser = true;
		InitializeComponent();
	}

	private void VerifyInterruptibleExporter()
	{
		SpecificDoctrineCache = new List<SpecificDoctrineViewModel>();
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("核武器", "Strategic", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_UseNukes(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_35 = 0;
				doctrine_0.SelectionChanged_Combo_UseNukes(comboBox_0, ref scenario_0, ref int_35, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetNukesAllowed_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("空中武器控制状态", "ROE", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_WeaponControlStatus_Air(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_34 = 0;
				doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Air(comboBox_0, ref scenario_0, ref int_34, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetWeaponControlStatus_Air_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("海面武器控制状态", "ROE", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_WeaponControlStatus_Surface(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_33 = 0;
				doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Surface(comboBox_0, ref scenario_0, ref int_33, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetWeaponControlStatus_Surface_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("水下武器控制状态", "ROE", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_WeaponControlStatus_Submarine(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_32 = 0;
				doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Submarine(comboBox_0, ref scenario_0, ref int_32, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetWeaponControlStatus_Submarine_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("地面武器控制状态", "ROE", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_WeaponControlStatus_Land(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_31 = 0;
				doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Land(comboBox_0, ref scenario_0, ref int_31, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetWeaponControlStatus_Land_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("忽略规划的路径", "ROE", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_IgnorePlottedCourse(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_30 = 0;
				doctrine_0.SelectionChanged_Combo_IgnorePlottedCourse(comboBox_0, ref scenario_0, ref int_30, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetIgnorePlottedCourse_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("与不明确目标交战", "ROE", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_BehaviorTowardsAmbigousTarget(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_29 = 0;
				doctrine_0.SelectionChanged_Combo_BehaviorTowardsAmbigousTarget(comboBox_0, ref scenario_0, ref int_29, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetBehaviorTowardsAmbigousTarget_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("与机会目标交战", "ROE", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_ShootTourists(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_28 = 0;
				doctrine_0.SelectionChanged_Combo_ShootTourists(comboBox_0, ref scenario_0, ref int_28, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetShootTourists_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("受到攻击时忽略", "EMCON", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_IgnoreEMCONunderAttack(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_27 = 0;
				doctrine_0.SelectionChanged_Combo_IgnoreEMCONunderAttack(comboBox_0, ref scenario_0, ref int_27, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetIgnoreEMCONunderAttack_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("鱼雷射程", "Misc", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_UseKinematicRangeForTorpedoes(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_26 = 0;
				doctrine_0.SelectionChanged_Combo_UseKinematicRangeForTorpedoes(comboBox_0, ref scenario_0, ref int_26, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetUseKinematicRangeForTorpedoes_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("自动逃避", "Misc", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_AutoEvade(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_25 = 0;
				doctrine_0.SelectionChanged_Combo_AutoEvade(comboBox_0, ref scenario_0, ref int_25, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetAutoEvade_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("使用加油", "Misc", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_UseRefuel(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int selectedIndex2 = comboBox_0.SelectedIndex;
				int int_24 = 0;
				doctrine_0.SelectionChanged_Combo_UseRefuel(selectedIndex2, ref scenario_0, ref int_24, bool_0: false, bool_1: true, bool_2: false);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetUseReplenishment_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("重新加油选择", "Misc", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_ReplenishmentSelection(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int selectedIndex = comboBox_0.SelectedIndex;
				int int_23 = 0;
				doctrine_0.SelectionChanged_Combo_ReplenishmentSelection(selectedIndex, ref scenario_0, ref int_23, bool_0: false, bool_1: true, bool_2: false);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetReplenishmentSelection_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("为盟友加油", "Misc", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_RefuelAllies(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_22 = 0;
				doctrine_0.SelectionChanged_Combo_RefuelAllies(comboBox_0, ref scenario_0, ref int_22, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetRefuelAllies_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("空中行动强度", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			bool bool_9 = true;
			myDoctrine.Populate_Combo_AirOpsTempo(myWinformsComboBox, ref myScenario, ref bool_9, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_21 = 0;
				bool bool_8 = true;
				doctrine_0.SelectionChanged_Combo_AirOpsTempo(comboBox_0, ref scenario_0, ref int_21, ref bool_8, bool_1: false, bool_2: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetAirOpsTempo_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("快速再次出动", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			bool bool_7 = true;
			myDoctrine.Populate_Combo_QuickTurnAroundForAicraft(myWinformsComboBox, ref myScenario, ref bool_7, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_20 = 0;
				bool bool_6 = true;
				doctrine_0.SelectionChanged_Combo_QuickTurnAroundForAicraft(comboBox_0, ref scenario_0, ref int_20, ref bool_6, bool_1: false, bool_2: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetQuickTurnAroundForAicraft_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("燃料状态", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			bool bool_5 = true;
			myDoctrine.Populate_Combo_BingoJoker(myWinformsComboBox, ref myScenario, ref bool_5, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_19 = 0;
				bool bool_3 = true;
				bool bool_4 = false;
				doctrine_0.SelectionChanged_Combo_BingoJoker(comboBox_0, ref scenario_0, ref int_19, ref bool_3, ref bool_4, bool_2: false, bool_3: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetBingoJoker_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("燃料状态，返回基地RTB", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_BingoJokerRTB(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_18 = 0;
				doctrine_0.SelectionChanged_Combo_BingoJokerRTB(comboBox_0, ref scenario_0, ref int_18, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetBingoJokerRTB_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("武器状态", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			bool bool_2 = true;
			myDoctrine.Populate_Combo_WinchesterShotgun(myWinformsComboBox, ref myScenario, ref bool_2, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_17 = 0;
				bool bool_ = true;
				doctrine_0.SelectionChanged_Combo_WinchesterShotgun(comboBox_0, ref scenario_0, ref int_17, ref bool_, bool_1: false, bool_2: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetWinchesterShotgun_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("武器状态，返回基地RTB", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_WinchesterShotgunRTB(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_16 = 0;
				doctrine_0.SelectionChanged_Combo_WinchesterShotgunRTB(comboBox_0, ref scenario_0, ref int_16, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetWinchesterShotgunRTB_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("空对地扫射 (航炮)", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_GunStrafing(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_15 = 0;
				doctrine_0.SelectionChanged_Combo_GunStrafing(comboBox_0, ref scenario_0, ref int_15, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetGunStrafing_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("丢弃军械", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_JettisonOrdnance(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_14 = 0;
				doctrine_0.SelectionChanged_Combo_JettisonOrdnance(comboBox_0, ref scenario_0, ref int_14, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetJettisonOrdnance_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("超视距BVR交战逻辑", "空中作战", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_BVRLogic(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_13 = 0;
				doctrine_0.SelectionChanged_Combo_BVRLogic(comboBox_0, ref scenario_0, ref int_13, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetBVRLogic_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("对地火箭", "ASuW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_UseSAMsOnASuW(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_12 = 0;
				doctrine_0.SelectionChanged_Combo_UseSAMsOnASuW(comboBox_0, ref scenario_0, ref int_12, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetUseSAMsOnASuW_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("Anti-Surface WP Missiles", "ASuW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_UseWPWeaponOnASuW(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_11 = 0;
				doctrine_0.SelectionChanged_Combo_UseWPMissilesOnASuW(comboBox_0, ref scenario_0, ref int_11, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetUseWPMissileOnASuW_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("维持躲避", "ASuW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_Standoff(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_10 = 0;
				doctrine_0.SelectionChanged_Combo_Standoff(comboBox_0, ref scenario_0, ref int_10, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetMaintainStandoff_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("Navigation", "ASuW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_SurfaceNavigation(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_9 = 0;
				doctrine_0.SelectionChanged_Combo_SurfaceNavigation(comboBox_0, ref scenario_0, ref int_9, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetSurfaceNavigation_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("避免目标", "ASW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_AvoidContact(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_8 = 0;
				doctrine_0.SelectionChanged_Combo_AvoidContact(comboBox_0, ref scenario_0, ref int_8, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetAvoidContact_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("探测到威胁时潜水", "ASW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_DiveWhenThreatsDetected(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_7 = 0;
				doctrine_0.SelectionChanged_Combo_DiveWhenThreatsDetected(comboBox_0, ref scenario_0, ref int_7, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetDiveWhenThreatsDetected_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("充电，巡逻", "ASW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_RechargePercentagePatrol(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_6 = 0;
				doctrine_0.SelectionChanged_Combo_RechargePercentagePatrol(comboBox_0, ref scenario_0, ref int_6, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetRechargePercentagePatrol_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("充电，攻击", "ASW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_RechargePercentageAttack(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_5 = 0;
				doctrine_0.SelectionChanged_Combo_RechargePercentageAttack(comboBox_0, ref scenario_0, ref int_5, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetRechargePercentageAttack_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("不依赖空气推进AIP用法", "ASW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_AIPUsage(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_4 = 0;
				doctrine_0.SelectionChanged_Combo_AIPUsage(comboBox_0, ref scenario_0, ref int_4, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetAIPUsage_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("侵入声纳", "ASW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_DippingSonar(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_3 = 0;
				doctrine_0.SelectionChanged_Combo_DippingSonar(comboBox_0, ref scenario_0, ref int_3, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetDippingSonar_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("Navigation", "ASW", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_SubmarineNavigation(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_2 = 0;
				doctrine_0.SelectionChanged_Combo_SubmarineNavigation(comboBox_0, ref scenario_0, ref int_2, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetSubmarineNavigation_PlayerEditable(myScenario0)));
		SpecificDoctrineCache.Add(new SpecificDoctrineViewModel("Navigation", "Land", delegate(Doctrine myDoctrine, System.Windows.Forms.ComboBox myWinformsComboBox, Scenario myScenario)
		{
			myDoctrine.Populate_Combo_LandNavigation(myWinformsComboBox, ref myScenario, null);
		}, delegate(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
		{
			if (SelectionChangedByUser)
			{
				int int_ = 0;
				doctrine_0.SelectionChanged_Combo_LandNavigation(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
			}
		}, (Doctrine myDoctrine0, Scenario myScenario0) => myDoctrine0.GetLandNavigation_PlayerEditable(myScenario0)));
	}

	public void Refresh(ActiveUnit activeUnit_0)
	{
		if (SpecificDoctrineCache == null)
		{
			VerifyInterruptibleExporter();
		}
		if (activeUnit_0 != null)
		{
			if (!activeUnit_0.CommStuff.IsConnectedToSideNetwork && !InterpreterObjectListener.CollectInterruptibleTask(activeUnit_0) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
			{
				base.Visibility = Visibility.Collapsed;
				return;
			}
			base.Visibility = Visibility.Visible;
		}
		SelectionChangedByUser = false;
		if (base.DataContext == null)
		{
			base.DataContext = new DoctrineViewModel(activeUnit_0, SpecificDoctrineCache);
		}
		else
		{
			DoctrineViewModel doctrineViewModel = (DoctrineViewModel)base.DataContext;
			if (doctrineViewModel.theUnit == activeUnit_0)
			{
				doctrineViewModel.Refresh();
			}
			else
			{
				base.DataContext = new DoctrineViewModel(activeUnit_0, SpecificDoctrineCache);
			}
		}
		SelectionChangedByUser = true;
	}

	private void ListInterruptibleExporter(object sender, RoutedEventArgs e)
	{
		DoctrineViewModel doctrineViewModel = (DoctrineViewModel)base.DataContext;
		if (doctrineViewModel != null && doctrineViewModel.theUnit != null)
		{
			DoctrineForm doctrineForm = new DoctrineForm();
			doctrineForm.Subject = doctrineViewModel.theUnit;
			doctrineForm.Show();
		}
	}

	private void ResolveInterruptibleExporter(object sender, System.Windows.Input.MouseEventArgs e)
	{
		try
		{
			((DoctrineViewModel)base.DataContext).mouseOverPanel = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void PostInterruptibleExporter(object sender, System.Windows.Input.MouseEventArgs e)
	{
		try
		{
			((DoctrineViewModel)base.DataContext).mouseOverPanel = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[CompilerGenerated]
	private void RunInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_UseNukes(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void StartInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Air(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void AssetInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Surface(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void PrintInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Submarine(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void DefineInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_WeaponControlStatus_Land(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void PublishInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_IgnorePlottedCourse(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void AwakeInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_BehaviorTowardsAmbigousTarget(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void QueryInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_ShootTourists(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void ResetInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_IgnoreEMCONunderAttack(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void MapInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_UseKinematicRangeForTorpedoes(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void SortInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_AutoEvade(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void CalcInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int selectedIndex = comboBox_0.SelectedIndex;
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_UseRefuel(selectedIndex, ref scenario_0, ref int_, bool_0: false, bool_1: true, bool_2: false);
		}
	}

	[CompilerGenerated]
	private void RateInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int selectedIndex = comboBox_0.SelectedIndex;
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_ReplenishmentSelection(selectedIndex, ref scenario_0, ref int_, bool_0: false, bool_1: true, bool_2: false);
		}
	}

	[CompilerGenerated]
	private void FlushInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_RefuelAllies(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void ForgotInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			bool bool_ = true;
			doctrine_0.SelectionChanged_Combo_AirOpsTempo(comboBox_0, ref scenario_0, ref int_, ref bool_, bool_1: false, bool_2: true);
		}
	}

	[CompilerGenerated]
	private void CollectInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			bool bool_ = true;
			doctrine_0.SelectionChanged_Combo_QuickTurnAroundForAicraft(comboBox_0, ref scenario_0, ref int_, ref bool_, bool_1: false, bool_2: true);
		}
	}

	[CompilerGenerated]
	private void OrderInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			bool bool_ = true;
			bool bool_2 = false;
			doctrine_0.SelectionChanged_Combo_BingoJoker(comboBox_0, ref scenario_0, ref int_, ref bool_, ref bool_2, bool_2: false, bool_3: true);
		}
	}

	[CompilerGenerated]
	private void RegisterInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_BingoJokerRTB(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void ManageInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			bool bool_ = true;
			doctrine_0.SelectionChanged_Combo_WinchesterShotgun(comboBox_0, ref scenario_0, ref int_, ref bool_, bool_1: false, bool_2: true);
		}
	}

	[CompilerGenerated]
	private void RevertInterruptibleExporter(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_WinchesterShotgunRTB(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void CountInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_GunStrafing(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void CustomizeInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_JettisonOrdnance(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void CloneInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_BVRLogic(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void ConnectInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_UseSAMsOnASuW(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void MoveInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_UseWPMissilesOnASuW(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void DeleteInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_Standoff(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void AddInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_SurfaceNavigation(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void DestroyInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_AvoidContact(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void ComputeInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_DiveWhenThreatsDetected(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void PatchInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_RechargePercentagePatrol(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void SelectInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_RechargePercentageAttack(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void CallInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_AIPUsage(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void LogoutInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_DippingSonar(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void ViewInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_SubmarineNavigation(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[CompilerGenerated]
	private void ValidateInterruptiblePrototype(Doctrine doctrine_0, System.Windows.Forms.ComboBox comboBox_0, Scenario scenario_0)
	{
		if (SelectionChangedByUser)
		{
			int int_ = 0;
			doctrine_0.SelectionChanged_Combo_LandNavigation(comboBox_0, ref scenario_0, ref int_, bool_0: false, bool_1: true);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri resourceLocater = new Uri("/Command;component/command/unitdoctrine_wpf.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocater);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		switch (connectionId)
		{
		case 1:
			((UnitDoctrine_WPF)target).MouseEnter += ResolveInterruptibleExporter;
			((UnitDoctrine_WPF)target).MouseLeave += PostInterruptibleExporter;
			break;
		case 2:
			((System.Windows.Controls.Button)target).Click += ListInterruptibleExporter;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
