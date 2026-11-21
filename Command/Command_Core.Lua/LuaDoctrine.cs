using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
public sealed class LuaDoctrine
{
	private static Dictionary<int, Doctrine.WRA_Weapon> dictionary_0;

	private static Dictionary<string, string> dictionary_1;

	private static Dictionary<string, string> dictionary_2;

	static LuaDoctrine()
	{
		dictionary_1 = new Dictionary<string, string>();
		dictionary_2 = new Dictionary<string, string>();
	}

	private static void smethod_0()
	{
		if (dictionary_1.Count > 0)
		{
			return;
		}
		string value = "Values are: " + Conversions.ToString((byte)0) + " = " + Doctrine._UseNukesAllowed.No.ToString() + " " + Conversions.ToString((byte)1) + " = " + Doctrine._UseNukesAllowed.Yes;
		dictionary_1.Add("Nukes", "use_nuclear_weapons");
		dictionary_2.Add("Nukes", value);
		value = "Values are: " + Conversions.ToString((byte)0) + " = " + Doctrine._WCS.Free.ToString() + " " + Conversions.ToString((byte)1) + " = " + Doctrine._WCS.Tight.ToString() + " " + Conversions.ToString((byte)2) + " = " + Doctrine._WCS.Hold;
		dictionary_1.Add("WCS_Air", "weapon_control_status_air");
		dictionary_2.Add("WCS_Air", value);
		dictionary_1.Add("WCS_Surface", "weapon_control_status_surface");
		dictionary_2.Add("WCS_Surface", value);
		dictionary_1.Add("WCS_Submarine", "weapon_control_status_subsurface");
		dictionary_2.Add("WCS_Submarine", value);
		dictionary_1.Add("WCS_Land", "weapon_control_status_land");
		dictionary_2.Add("WCS_Land", value);
		value = "Values are: " + Conversions.ToString((byte)0) + " = " + Doctrine._UseIgnorePlottedCourse.No.ToString() + " " + Conversions.ToString((byte)1) + " = " + Doctrine._UseIgnorePlottedCourse.Yes;
		dictionary_1.Add("IPCWA", "ignore_plotted_course");
		dictionary_2.Add("IPCWA", value);
		byte[] obj = (byte[])Enum.GetValues(typeof(Doctrine._BehaviorTowardsTargetAmbiguity));
		value = "Values are: ";
		byte[] array = obj;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			byte b = array[i];
			Doctrine._BehaviorTowardsTargetAmbiguity behaviorTowardsTargetAmbiguity = (Doctrine._BehaviorTowardsTargetAmbiguity)b;
			if (Operators.CompareString(behaviorTowardsTargetAmbiguity.ToString(), "Various", TextCompare: false) != 0)
			{
				behaviorTowardsTargetAmbiguity = (Doctrine._BehaviorTowardsTargetAmbiguity)b;
				if (Operators.CompareString(behaviorTowardsTargetAmbiguity.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					behaviorTowardsTargetAmbiguity = (Doctrine._BehaviorTowardsTargetAmbiguity)b;
					string text = string.Format(" {1} = {0} ", behaviorTowardsTargetAmbiguity.ToString(), b.ToString());
					value += text;
				}
			}
		}
		dictionary_1.Add("BTAT", "engaging_ambiguous_targets");
		dictionary_2.Add("BTAT", value);
		byte[] obj12 = (byte[])Enum.GetValues(typeof(Doctrine._UseShootTourists));
		value = "Values are: ";
		byte[] array12 = obj12;
		for (int j = 0; j < array12.Length; j = checked(j + 1))
		{
			byte b12 = array12[j];
			Doctrine._UseShootTourists useShootTourists = (Doctrine._UseShootTourists)b12;
			if (Operators.CompareString(useShootTourists.ToString(), "Various", TextCompare: false) != 0)
			{
				useShootTourists = (Doctrine._UseShootTourists)b12;
				if (Operators.CompareString(useShootTourists.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useShootTourists = (Doctrine._UseShootTourists)b12;
					string text12 = string.Format(" {1} = {0} ", useShootTourists.ToString(), b12.ToString());
					value += text12;
				}
			}
		}
		dictionary_1.Add("ST", "engage_opportunity_targets");
		dictionary_2.Add("ST", value);
		byte[] obj23 = (byte[])Enum.GetValues(typeof(Doctrine._UseIgnoreEMCONunderAttack));
		value = "Values are: ";
		byte[] array23 = obj23;
		for (int k = 0; k < array23.Length; k = checked(k + 1))
		{
			byte b20 = array23[k];
			Doctrine._UseIgnoreEMCONunderAttack useIgnoreEMCONunderAttack = (Doctrine._UseIgnoreEMCONunderAttack)b20;
			if (Operators.CompareString(useIgnoreEMCONunderAttack.ToString(), "Various", TextCompare: false) != 0)
			{
				useIgnoreEMCONunderAttack = (Doctrine._UseIgnoreEMCONunderAttack)b20;
				if (Operators.CompareString(useIgnoreEMCONunderAttack.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useIgnoreEMCONunderAttack = (Doctrine._UseIgnoreEMCONunderAttack)b20;
					string text23 = string.Format(" {1} = {0} ", useIgnoreEMCONunderAttack.ToString(), b20.ToString());
					value += text23;
				}
			}
		}
		dictionary_1.Add("IgnoreEMCONUnderAttack", "ignore_emcon_while_under_attack");
		dictionary_2.Add("IgnoreEMCONUnderAttack", value);
		byte[] obj26 = (byte[])Enum.GetValues(typeof(Doctrine._UseKinematicRangeForTorpedoes));
		value = "Values are: ";
		byte[] array26 = obj26;
		for (int l = 0; l < array26.Length; l = checked(l + 1))
		{
			byte b21 = array26[l];
			Doctrine._UseKinematicRangeForTorpedoes useKinematicRangeForTorpedoes = (Doctrine._UseKinematicRangeForTorpedoes)b21;
			if (Operators.CompareString(useKinematicRangeForTorpedoes.ToString(), "Various", TextCompare: false) != 0)
			{
				useKinematicRangeForTorpedoes = (Doctrine._UseKinematicRangeForTorpedoes)b21;
				if (Operators.CompareString(useKinematicRangeForTorpedoes.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useKinematicRangeForTorpedoes = (Doctrine._UseKinematicRangeForTorpedoes)b21;
					string text26 = string.Format(" {1} = {0} ", useKinematicRangeForTorpedoes.ToString(), b21.ToString());
					value += text26;
				}
			}
		}
		dictionary_1.Add("UseTorpedoesKinematicRange", "kinematic_range_for_torpedoes");
		dictionary_2.Add("UseTorpedoesKinematicRange", value);
		byte[] obj27 = (byte[])Enum.GetValues(typeof(Doctrine._UseAutoEvade));
		value = "Values are: ";
		byte[] array27 = obj27;
		for (int m = 0; m < array27.Length; m = checked(m + 1))
		{
			byte b22 = array27[m];
			Doctrine._UseAutoEvade useAutoEvade = (Doctrine._UseAutoEvade)b22;
			if (Operators.CompareString(useAutoEvade.ToString(), "Various", TextCompare: false) != 0)
			{
				useAutoEvade = (Doctrine._UseAutoEvade)b22;
				if (Operators.CompareString(useAutoEvade.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useAutoEvade = (Doctrine._UseAutoEvade)b22;
					string text27 = string.Format(" {1} = {0} ", useAutoEvade.ToString(), b22.ToString());
					value += text27;
				}
			}
		}
		dictionary_1.Add("AE", "automatic_evasion");
		dictionary_2.Add("AE", value);
		byte[] obj28 = (byte[])Enum.GetValues(typeof(Doctrine._UseUnderwayRefuelAndReplenishment));
		value = "Values are: ";
		byte[] array28 = obj28;
		for (int n = 0; n < array28.Length; n = checked(n + 1))
		{
			byte b23 = array28[n];
			Doctrine._UseUnderwayRefuelAndReplenishment useUnderwayRefuelAndReplenishment = (Doctrine._UseUnderwayRefuelAndReplenishment)b23;
			if (Operators.CompareString(useUnderwayRefuelAndReplenishment.ToString(), "Various", TextCompare: false) != 0)
			{
				useUnderwayRefuelAndReplenishment = (Doctrine._UseUnderwayRefuelAndReplenishment)b23;
				if (Operators.CompareString(useUnderwayRefuelAndReplenishment.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useUnderwayRefuelAndReplenishment = (Doctrine._UseUnderwayRefuelAndReplenishment)b23;
					string text28 = string.Format(" {1} = {0} ", useUnderwayRefuelAndReplenishment.ToString(), b23.ToString());
					value += text28;
				}
			}
		}
		dictionary_1.Add("UR", "use_refuel_unrep");
		dictionary_2.Add("UR", value);
		byte[] obj29 = (byte[])Enum.GetValues(typeof(Doctrine._UnderwayRefuelAndReplenishmentSelection));
		value = "Values are: ";
		byte[] array29 = obj29;
		for (int num = 0; num < array29.Length; num = checked(num + 1))
		{
			byte b24 = array29[num];
			Doctrine._UnderwayRefuelAndReplenishmentSelection underwayRefuelAndReplenishmentSelection = (Doctrine._UnderwayRefuelAndReplenishmentSelection)b24;
			if (Operators.CompareString(underwayRefuelAndReplenishmentSelection.ToString(), "Various", TextCompare: false) != 0)
			{
				underwayRefuelAndReplenishmentSelection = (Doctrine._UnderwayRefuelAndReplenishmentSelection)b24;
				if (Operators.CompareString(underwayRefuelAndReplenishmentSelection.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					underwayRefuelAndReplenishmentSelection = (Doctrine._UnderwayRefuelAndReplenishmentSelection)b24;
					string text29 = string.Format(" {1} = {0} ", underwayRefuelAndReplenishmentSelection.ToString(), b24.ToString());
					value += text29;
				}
			}
		}
		dictionary_1.Add("RS", "unrep_selection");
		dictionary_2.Add("RS", value);
		byte[] obj30 = (byte[])Enum.GetValues(typeof(Doctrine._RefuelAlliedUnits));
		value = "Values are: ";
		byte[] array30 = obj30;
		for (int num12 = 0; num12 < array30.Length; num12 = checked(num12 + 1))
		{
			byte b25 = array30[num12];
			Doctrine._RefuelAlliedUnits refuelAlliedUnits = (Doctrine._RefuelAlliedUnits)b25;
			if (Operators.CompareString(refuelAlliedUnits.ToString(), "Various", TextCompare: false) != 0)
			{
				refuelAlliedUnits = (Doctrine._RefuelAlliedUnits)b25;
				if (Operators.CompareString(refuelAlliedUnits.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					refuelAlliedUnits = (Doctrine._RefuelAlliedUnits)b25;
					string text30 = string.Format(" {1} = {0} ", refuelAlliedUnits.ToString(), b25.ToString());
					value += text30;
				}
			}
		}
		dictionary_1.Add("RefuelAllies", "refuel_unrep_allied");
		dictionary_2.Add("RefuelAllies", value);
		byte[] obj31 = (byte[])Enum.GetValues(typeof(Doctrine._BingoThreshold_E));
		value = "Values are: ";
		byte[] array31 = obj31;
		for (int num23 = 0; num23 < array31.Length; num23 = checked(num23 + 1))
		{
			byte b26 = array31[num23];
			Doctrine._BingoThreshold_E bingoThreshold_E = (Doctrine._BingoThreshold_E)b26;
			if (Operators.CompareString(bingoThreshold_E.ToString(), "Various", TextCompare: false) != 0)
			{
				bingoThreshold_E = (Doctrine._BingoThreshold_E)b26;
				if (Operators.CompareString(bingoThreshold_E.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					bingoThreshold_E = (Doctrine._BingoThreshold_E)b26;
					string text31 = string.Format(" {1} = {0} ", bingoThreshold_E.ToString(), b26.ToString());
					value += text31;
				}
			}
		}
		dictionary_1.Add("BingoThreshold", "bingo_threshold");
		dictionary_2.Add("BingoThreshold", value);
		byte[] obj2 = (byte[])Enum.GetValues(typeof(Doctrine._AirOpsTempo));
		value = "Values are: ";
		byte[] array2 = obj2;
		for (int num25 = 0; num25 < array2.Length; num25 = checked(num25 + 1))
		{
			byte b2 = array2[num25];
			Doctrine._AirOpsTempo airOpsTempo = (Doctrine._AirOpsTempo)b2;
			if (Operators.CompareString(airOpsTempo.ToString(), "Various", TextCompare: false) != 0)
			{
				airOpsTempo = (Doctrine._AirOpsTempo)b2;
				if (Operators.CompareString(airOpsTempo.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					airOpsTempo = (Doctrine._AirOpsTempo)b2;
					string text2 = string.Format(" {1} = {0} ", airOpsTempo.ToString(), b2.ToString());
					value += text2;
				}
			}
		}
		dictionary_1.Add("AirOpsTempo", "air_operations_tempo");
		dictionary_2.Add("AirOpsTempo", value);
		byte[] obj3 = (byte[])Enum.GetValues(typeof(Doctrine._QuickTurnAroundForAicraft));
		value = "Values are: ";
		byte[] array3 = obj3;
		for (int num26 = 0; num26 < array3.Length; num26 = checked(num26 + 1))
		{
			byte b3 = array3[num26];
			Doctrine._QuickTurnAroundForAicraft quickTurnAroundForAicraft = (Doctrine._QuickTurnAroundForAicraft)b3;
			if (Operators.CompareString(quickTurnAroundForAicraft.ToString(), "Various", TextCompare: false) != 0)
			{
				quickTurnAroundForAicraft = (Doctrine._QuickTurnAroundForAicraft)b3;
				if (Operators.CompareString(quickTurnAroundForAicraft.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					quickTurnAroundForAicraft = (Doctrine._QuickTurnAroundForAicraft)b3;
					string text3 = string.Format(" {1} = {0} ", quickTurnAroundForAicraft.ToString(), b3.ToString());
					value += text3;
				}
			}
		}
		dictionary_1.Add("QuickTurnAround", "quick_turnaround_for_aircraft");
		dictionary_2.Add("QuickTurnAround", value);
		byte[] obj4 = (byte[])Enum.GetValues(typeof(Doctrine._FuelState));
		value = "Values are: ";
		byte[] array4 = obj4;
		for (int num27 = 0; num27 < array4.Length; num27 = checked(num27 + 1))
		{
			byte b4 = array4[num27];
			Doctrine._FuelState fuelState = (Doctrine._FuelState)b4;
			if (Operators.CompareString(fuelState.ToString(), "Various", TextCompare: false) != 0)
			{
				fuelState = (Doctrine._FuelState)b4;
				if (Operators.CompareString(fuelState.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					fuelState = (Doctrine._FuelState)b4;
					string text4 = string.Format(" {1} = {0} ", fuelState.ToString(), b4.ToString());
					value += text4;
				}
			}
		}
		dictionary_1.Add("BingoJoker", "fuel_state_planned");
		dictionary_2.Add("BingoJoker", value);
		byte[] obj5 = (byte[])Enum.GetValues(typeof(Doctrine._FuelStateRTB));
		value = "Values are: ";
		byte[] array5 = obj5;
		for (int num28 = 0; num28 < array5.Length; num28 = checked(num28 + 1))
		{
			byte b5 = array5[num28];
			Doctrine._FuelStateRTB fuelStateRTB = (Doctrine._FuelStateRTB)b5;
			if (Operators.CompareString(fuelStateRTB.ToString(), "Various", TextCompare: false) != 0)
			{
				fuelStateRTB = (Doctrine._FuelStateRTB)b5;
				if (Operators.CompareString(fuelStateRTB.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					fuelStateRTB = (Doctrine._FuelStateRTB)b5;
					string text5 = string.Format(" {1} = {0} ", fuelStateRTB.ToString(), b5.ToString());
					value += text5;
				}
			}
		}
		dictionary_1.Add("BingoJokerRTB", "fuel_state_rtb");
		dictionary_2.Add("BingoJokerRTB", value);
		int[] obj6 = (int[])Enum.GetValues(typeof(Doctrine._WeaponState));
		value = "Values are: ";
		int[] array6 = obj6;
		for (int num29 = 0; num29 < array6.Length; num29 = checked(num29 + 1))
		{
			int num30 = array6[num29];
			Doctrine._WeaponState weaponState = (Doctrine._WeaponState)num30;
			if (Operators.CompareString(weaponState.ToString(), "Various", TextCompare: false) != 0)
			{
				weaponState = (Doctrine._WeaponState)num30;
				if (Operators.CompareString(weaponState.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					weaponState = (Doctrine._WeaponState)num30;
					string text6 = string.Format(" {1} = {0} ", weaponState.ToString(), num30.ToString());
					value += text6;
				}
			}
		}
		dictionary_1.Add("WinchesterShotgun", "weapon_state_planned");
		dictionary_2.Add("WinchesterShotgun", value);
		byte[] obj7 = (byte[])Enum.GetValues(typeof(Doctrine._WeaponStateRTB));
		value = "Values are: ";
		byte[] array7 = obj7;
		for (int num2 = 0; num2 < array7.Length; num2 = checked(num2 + 1))
		{
			byte b6 = array7[num2];
			Doctrine._WeaponStateRTB weaponStateRTB = (Doctrine._WeaponStateRTB)b6;
			if (Operators.CompareString(weaponStateRTB.ToString(), "Various", TextCompare: false) != 0)
			{
				weaponStateRTB = (Doctrine._WeaponStateRTB)b6;
				if (Operators.CompareString(weaponStateRTB.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					weaponStateRTB = (Doctrine._WeaponStateRTB)b6;
					string text7 = string.Format(" {1} = {0} ", weaponStateRTB.ToString(), b6.ToString());
					value += text7;
				}
			}
		}
		dictionary_1.Add("WinchesterShotgunRTB", "weapon_state_rtb");
		dictionary_2.Add("WinchesterShotgunRTB", value);
		byte[] obj8 = (byte[])Enum.GetValues(typeof(Doctrine._GunStrafeGroundTargets));
		value = "Values are: ";
		byte[] array8 = obj8;
		for (int num3 = 0; num3 < array8.Length; num3 = checked(num3 + 1))
		{
			byte b7 = array8[num3];
			Doctrine._GunStrafeGroundTargets gunStrafeGroundTargets = (Doctrine._GunStrafeGroundTargets)b7;
			if (Operators.CompareString(gunStrafeGroundTargets.ToString(), "Various", TextCompare: false) != 0)
			{
				gunStrafeGroundTargets = (Doctrine._GunStrafeGroundTargets)b7;
				if (Operators.CompareString(gunStrafeGroundTargets.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					gunStrafeGroundTargets = (Doctrine._GunStrafeGroundTargets)b7;
					string text8 = string.Format(" {1} = {0} ", gunStrafeGroundTargets.ToString(), b7.ToString());
					value += text8;
				}
			}
		}
		dictionary_1.Add("GS", "gun_strafing");
		dictionary_2.Add("GS", value);
		byte[] obj9 = (byte[])Enum.GetValues(typeof(Doctrine._JettisonOrdnance));
		value = "Values are: ";
		byte[] array9 = obj9;
		for (int num4 = 0; num4 < array9.Length; num4 = checked(num4 + 1))
		{
			byte b8 = array9[num4];
			Doctrine._JettisonOrdnance jettisonOrdnance = (Doctrine._JettisonOrdnance)b8;
			if (Operators.CompareString(jettisonOrdnance.ToString(), "Various", TextCompare: false) != 0)
			{
				jettisonOrdnance = (Doctrine._JettisonOrdnance)b8;
				if (Operators.CompareString(jettisonOrdnance.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					jettisonOrdnance = (Doctrine._JettisonOrdnance)b8;
					string text9 = string.Format(" {1} = {0} ", jettisonOrdnance.ToString(), b8.ToString());
					value += text9;
				}
			}
		}
		dictionary_1.Add("JettisonOrdnance", "jettison_ordnance");
		dictionary_2.Add("JettisonOrdnance", value);
		byte[] obj10 = (byte[])Enum.GetValues(typeof(Doctrine._BVRLogicEnum));
		value = "Values are: ";
		byte[] array10 = obj10;
		for (int num5 = 0; num5 < array10.Length; num5 = checked(num5 + 1))
		{
			byte b9 = array10[num5];
			Doctrine._BVRLogicEnum bVRLogicEnum = (Doctrine._BVRLogicEnum)b9;
			if (Operators.CompareString(bVRLogicEnum.ToString(), "Various", TextCompare: false) != 0)
			{
				bVRLogicEnum = (Doctrine._BVRLogicEnum)b9;
				if (Operators.CompareString(bVRLogicEnum.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					bVRLogicEnum = (Doctrine._BVRLogicEnum)b9;
					string text10 = string.Format(" {1} = {0} ", bVRLogicEnum.ToString(), b9.ToString());
					value += text10;
				}
			}
		}
		dictionary_1.Add("BVRLogic", "bvr_logic");
		dictionary_2.Add("BVRLogic", value);
		byte[] obj11 = (byte[])Enum.GetValues(typeof(Doctrine._UseSAMsAgainstShips));
		value = "Values are: ";
		byte[] array11 = obj11;
		for (int num6 = 0; num6 < array11.Length; num6 = checked(num6 + 1))
		{
			byte b10 = array11[num6];
			Doctrine._UseSAMsAgainstShips useSAMsAgainstShips = (Doctrine._UseSAMsAgainstShips)b10;
			if (Operators.CompareString(useSAMsAgainstShips.ToString(), "Various", TextCompare: false) != 0)
			{
				useSAMsAgainstShips = (Doctrine._UseSAMsAgainstShips)b10;
				if (Operators.CompareString(useSAMsAgainstShips.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useSAMsAgainstShips = (Doctrine._UseSAMsAgainstShips)b10;
					string text11 = string.Format(" {1} = {0} ", useSAMsAgainstShips.ToString(), b10.ToString());
					value += text11;
				}
			}
		}
		dictionary_1.Add("SAM_ASUW", "use_sams_in_anti_surface_mode");
		dictionary_2.Add("SAM_ASUW", value);
		byte[] obj13 = (byte[])Enum.GetValues(typeof(Doctrine._UseMaintainStandoff));
		value = "Values are: ";
		byte[] array13 = obj13;
		for (int num7 = 0; num7 < array13.Length; num7 = checked(num7 + 1))
		{
			byte b11 = array13[num7];
			Doctrine._UseMaintainStandoff useMaintainStandoff = (Doctrine._UseMaintainStandoff)b11;
			if (Operators.CompareString(useMaintainStandoff.ToString(), "Various", TextCompare: false) != 0)
			{
				useMaintainStandoff = (Doctrine._UseMaintainStandoff)b11;
				if (Operators.CompareString(useMaintainStandoff.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useMaintainStandoff = (Doctrine._UseMaintainStandoff)b11;
					string text13 = string.Format(" {1} = {0} ", useMaintainStandoff.ToString(), b11.ToString());
					value += text13;
				}
			}
		}
		dictionary_1.Add("MS", "maintain_standoff");
		dictionary_2.Add("MS", value);
		byte[] obj14 = (byte[])Enum.GetValues(typeof(Doctrine._UseWpMissileAgainstShips));
		value = "Values are: ";
		byte[] array14 = obj14;
		for (int num8 = 0; num8 < array14.Length; num8 = checked(num8 + 1))
		{
			byte b13 = array14[num8];
			Doctrine._UseWpMissileAgainstShips useWpMissileAgainstShips = (Doctrine._UseWpMissileAgainstShips)b13;
			if (Operators.CompareString(useWpMissileAgainstShips.ToString(), "Various", TextCompare: false) != 0)
			{
				useWpMissileAgainstShips = (Doctrine._UseWpMissileAgainstShips)b13;
				if (Operators.CompareString(useWpMissileAgainstShips.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					useWpMissileAgainstShips = (Doctrine._UseWpMissileAgainstShips)b13;
					string text14 = string.Format(" {1} = {0} ", useWpMissileAgainstShips.ToString(), b13.ToString());
					value += text14;
				}
			}
		}
		dictionary_1.Add("WP_ASUW", "use_sams_in_anti_surface_mode");
		dictionary_2.Add("WP_ASUW", value);
		byte[] obj15 = (byte[])Enum.GetValues(typeof(Doctrine._AvoidContactWhenPossible));
		value = "Values are: ";
		byte[] array15 = obj15;
		for (int num9 = 0; num9 < array15.Length; num9 = checked(num9 + 1))
		{
			byte b14 = array15[num9];
			Doctrine._AvoidContactWhenPossible avoidContactWhenPossible = (Doctrine._AvoidContactWhenPossible)b14;
			if (Operators.CompareString(avoidContactWhenPossible.ToString(), "Various", TextCompare: false) != 0)
			{
				avoidContactWhenPossible = (Doctrine._AvoidContactWhenPossible)b14;
				if (Operators.CompareString(avoidContactWhenPossible.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					avoidContactWhenPossible = (Doctrine._AvoidContactWhenPossible)b14;
					string text15 = string.Format(" {1} = {0} ", avoidContactWhenPossible.ToString(), b14.ToString());
					value += text15;
				}
			}
		}
		dictionary_1.Add("AvoidContact", "avoid_contact");
		dictionary_2.Add("AvoidContact", value);
		byte[] obj16 = (byte[])Enum.GetValues(typeof(Doctrine._DiveOnContact));
		value = "Values are: ";
		byte[] array16 = obj16;
		for (int num10 = 0; num10 < array16.Length; num10 = checked(num10 + 1))
		{
			byte b15 = array16[num10];
			Doctrine._DiveOnContact diveOnContact = (Doctrine._DiveOnContact)b15;
			if (Operators.CompareString(diveOnContact.ToString(), "Various", TextCompare: false) != 0)
			{
				diveOnContact = (Doctrine._DiveOnContact)b15;
				if (Operators.CompareString(diveOnContact.ToString(), "NotConfigured", TextCompare: false) != 0)
				{
					diveOnContact = (Doctrine._DiveOnContact)b15;
					string text16 = string.Format(" {1} = {0} ", diveOnContact.ToString(), b15.ToString());
					value += text16;
				}
			}
		}
		dictionary_1.Add("DiveWhenThreatsDetected", "dive_on_threat");
		dictionary_2.Add("DiveWhenThreatsDetected", value);
		int[] obj17 = (int[])Enum.GetValues(typeof(Doctrine._RechargeBatteryPercentage));
		value = "Values are: ";
		int[] array17 = obj17;
		for (int num11 = 0; num11 < array17.Length; num11 = checked(num11 + 1))
		{
			int num13 = array17[num11];
			Doctrine._RechargeBatteryPercentage rechargeBatteryPercentage = (Doctrine._RechargeBatteryPercentage)num13;
			string text17 = string.Format(" {1} = {0} ", rechargeBatteryPercentage.ToString(), num13.ToString());
			value += text17;
		}
		dictionary_1.Add("RechargePercentagePatrol", "recharge_on_patrol");
		dictionary_2.Add("RechargePercentagePatrol", value);
		dictionary_1.Add("RechargePercentageAttack", "recharge_on_attack");
		dictionary_2.Add("RechargePercentageAttack", value);
		byte[] obj18 = (byte[])Enum.GetValues(typeof(Doctrine._UseAIP));
		value = "Values are: ";
		byte[] array18 = obj18;
		for (int num14 = 0; num14 < array18.Length; num14 = checked(num14 + 1))
		{
			byte b16 = array18[num14];
			Doctrine._UseAIP useAIP = (Doctrine._UseAIP)b16;
			string text18 = string.Format(" {1} = {0} ", useAIP.ToString(), b16.ToString());
			value += text18;
		}
		dictionary_1.Add("AIPUsage", "use_aip");
		dictionary_2.Add("AIPUsage", value);
		byte[] obj19 = (byte[])Enum.GetValues(typeof(Doctrine._UseDippingSonar));
		value = "Values are: ";
		byte[] array19 = obj19;
		for (int num15 = 0; num15 < array19.Length; num15 = checked(num15 + 1))
		{
			byte b17 = array19[num15];
			Doctrine._UseDippingSonar useDippingSonar = (Doctrine._UseDippingSonar)b17;
			string text19 = string.Format(" {1} = {0} ", useDippingSonar.ToString(), b17.ToString());
			value += text19;
		}
		dictionary_1.Add("DippingSonar", "dipping_sonar");
		dictionary_2.Add("DippingSonar", value);
		short[] obj20 = (short[])Enum.GetValues(typeof(Doctrine._DamageThreshold));
		value = "Values are: ";
		short[] array20 = obj20;
		for (int num16 = 0; num16 < array20.Length; num16 = checked(num16 + 1))
		{
			short num17 = array20[num16];
			Doctrine._DamageThreshold damageThreshold = (Doctrine._DamageThreshold)num17;
			string text20 = string.Format(" {1} = {0} ", damageThreshold.ToString(), num17.ToString());
			value += text20;
		}
		dictionary_1.Add("WithdrawDamageThreshold", "withdraw_on_damage");
		dictionary_2.Add("WithdrawDamageThreshold", value);
		dictionary_1.Add("RedeployDamageThreshold", "deploy_on_damage");
		dictionary_2.Add("RedeployDamageThreshold", value);
		short[] obj21 = (short[])Enum.GetValues(typeof(Doctrine._FuelQuantityThreshold));
		value = "Values are: ";
		short[] array21 = obj21;
		for (int num18 = 0; num18 < array21.Length; num18 = checked(num18 + 1))
		{
			short num19 = array21[num18];
			Doctrine._FuelQuantityThreshold fuelQuantityThreshold = (Doctrine._FuelQuantityThreshold)num19;
			string text21 = string.Format(" {1} = {0} ", fuelQuantityThreshold.ToString(), num19.ToString());
			value += text21;
		}
		dictionary_1.Add("WithdrawFuelThreshold", "withdraw_on_fuel");
		dictionary_2.Add("WithdrawFuelThreshold", value);
		dictionary_1.Add("RedeployFuelThreshold", "deploy_on_fuel");
		dictionary_2.Add("RedeployFuelThreshold", value);
		short[] obj22 = (short[])Enum.GetValues(typeof(Doctrine._WeaponQuantityThreshold));
		value = "Values are: ";
		short[] array22 = obj22;
		for (int num20 = 0; num20 < array22.Length; num20 = checked(num20 + 1))
		{
			short num21 = array22[num20];
			Doctrine._WeaponQuantityThreshold weaponQuantityThreshold = (Doctrine._WeaponQuantityThreshold)num21;
			string text22 = string.Format(" {1} = {0} ", weaponQuantityThreshold.ToString(), num21.ToString());
			value += text22;
		}
		dictionary_1.Add("WithdrawAttackThreshold", "withdraw_on_attack");
		dictionary_2.Add("WithdrawAttackThreshold", value);
		dictionary_1.Add("RedeployAttackThreshold", "deploy_on_attack");
		dictionary_2.Add("RedeployAttackThreshold", value);
		dictionary_1.Add("WithdrawDefenceThreshold", "withdraw_on_defence");
		dictionary_2.Add("WithdrawDefenceThreshold", value);
		dictionary_1.Add("RedeployDefenceThreshold", "deploy_on_defence");
		dictionary_2.Add("RedeployDefenceThreshold", value);
		byte[] obj24 = (byte[])Enum.GetValues(typeof(Doctrine.EMCONSettings._EMCONSetting));
		value = "Values are: ";
		byte[] array24 = obj24;
		for (int num22 = 0; num22 < array24.Length; num22 = checked(num22 + 1))
		{
			byte b18 = array24[num22];
			Doctrine.EMCONSettings._EMCONSetting eMCONSetting = (Doctrine.EMCONSettings._EMCONSetting)b18;
			string text24 = string.Format(" {1} = {0} ", eMCONSetting.ToString(), b18.ToString());
			value += text24;
		}
		dictionary_1.Add("E_Radar", "radar");
		dictionary_2.Add("E_Radar", value);
		dictionary_1.Add("E_Sonar", "sonar");
		dictionary_2.Add("E_Sonar", value);
		dictionary_1.Add("E_OECM", "oecm");
		dictionary_2.Add("E_OECM", value);
		byte[] obj25 = (byte[])Enum.GetValues(typeof(Doctrine._NavigationMethod));
		value = "Values are: ";
		byte[] array25 = obj25;
		for (int num24 = 0; num24 < array25.Length; num24 = checked(num24 + 1))
		{
			byte b19 = array25[num24];
			Doctrine._NavigationMethod navigationMethod = (Doctrine._NavigationMethod)b19;
			string text25 = string.Format(" {1} = {0} ", navigationMethod.ToString(), b19.ToString());
			value += text25;
		}
		dictionary_1.Add("SurfNav", "navigation_surface");
		dictionary_2.Add("SurfNav", value);
		dictionary_1.Add("SubNav", "navigation_sub_surface");
		dictionary_2.Add("SubNav", value);
		dictionary_1.Add("LandNav", "navigation_land");
		dictionary_2.Add("LandNav", value);
	}

	public static LuaTable ScenEdit_SetDoctrine(LuaTable luaTable_0, LuaTable luaTable_1, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Doctrine doctrine = null;
		Side side = null;
		if (dictionary.ContainsKey("GUID"))
		{
			string text = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doctrine = scenario_0.ActiveUnits[text].Doctrine;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("找不到guid'" + text + "'");
			}
		}
		else if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
		{
			if (dictionary.ContainsKey("MISSION"))
			{
				string Local_MissionString = Conversions.ToString(dictionary["MISSION"]);
				if (!dictionary.ContainsKey("SIDE"))
				{
					throw new LuaError("要选择任务，您需要定义一个分方。");
				}
				string text12 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("找不到分方'" + text12 + "'");
				}
				try
				{
					Mission mission = side.Missions.FirstOrDefault((Mission s) => string.Equals(s.Name, Local_MissionString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_MissionString, StringComparison.OrdinalIgnoreCase));
					doctrine = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("找不到任务'" + Local_MissionString + "'");
				}
			}
			else if (dictionary.ContainsKey("SIDE"))
			{
				string text23 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
					doctrine = side.Doctrine;
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("找不到分方'" + text23 + "'");
				}
			}
		}
		else
		{
			string Local_Name = null;
			if (dictionary.ContainsKey("NAME"))
			{
				Local_Name = Conversions.ToString(dictionary["NAME"]);
			}
			else if (dictionary.ContainsKey("UNITNAME"))
			{
				Local_Name = Conversions.ToString(dictionary["UNITNAME"]);
			}
			if (dictionary.ContainsKey("SIDE"))
			{
				string text34 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("找不到分方'" + text34 + "'");
				}
				try
				{
					doctrine = side.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("找不到单元'" + Local_Name + "' 分方 '" + text34 + "'");
				}
			}
			else
			{
				try
				{
					doctrine = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, Local_Name, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					throw new LuaError("找不到单元'" + Local_Name + "'");
				}
			}
		}
		if (doctrine == null)
		{
			throw new LuaError("需要定义一个guid，一个名字，一个分方和名称，一个分方和任务，或者只是一个分方。");
		}
		dictionary = LuaUtility.ToDictLower(luaTable_1.GetEnumerator());
		if (dictionary.Count == 0)
		{
			doctrine.InheritDoctrine(ref scenario_0, ref doctrine.SubjectType);
		}
		if (dictionary.ContainsKey("1") && string.Equals(Conversions.ToString(dictionary["1"]), "inherit", StringComparison.OrdinalIgnoreCase))
		{
			doctrine.InheritDoctrine(ref scenario_0, ref doctrine.SubjectType);
		}
		if (dictionary.ContainsKey("use_nuclear_weapons"))
		{
			Doctrine._UseNukesAllowed result;
			if (Operators.CompareString(Conversions.ToString(dictionary["use_nuclear_weapons"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseNukesAllowed>(Conversions.ToString(dictionary["use_nuclear_weapons"]), ignoreCase: true, out result) & Enum.IsDefined(typeof(Doctrine._UseNukesAllowed), result))
			{
				doctrine.SetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false, result);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["use_nuclear_weapons"])).Value)
			{
				doctrine.SetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseNukesAllowed.Yes);
			}
			else
			{
				doctrine.SetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseNukesAllowed.No);
			}
		}
		if (dictionary.ContainsKey("use_nuclear_weapons_player_editable"))
		{
			doctrine.SetNukesAllowed_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["use_nuclear_weapons_player_editable"]));
		}
		if (dictionary.ContainsKey("weapon_control_status_air"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["weapon_control_status_air"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WCS>(Conversions.ToString(dictionary["weapon_control_status_air"]), ignoreCase: true, out var result12) & Enum.IsDefined(typeof(Doctrine._WCS), result12)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["weapon_control_status_air"]) + "'as weapon_control_status_air允许的值为：'0'，'1'，'2'，对应于Free，Tight和Hold。");
				}
				doctrine.SetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, result12);
			}
		}
		if (dictionary.ContainsKey("weapon_control_status_air_player_editable"))
		{
			doctrine.SetWeaponControlStatus_Air_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["weapon_control_status_air_player_editable"]));
		}
		if (dictionary.ContainsKey("weapon_control_status_surface"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["weapon_control_status_surface"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WCS>(Conversions.ToString(dictionary["weapon_control_status_surface"]), ignoreCase: true, out var result23) & Enum.IsDefined(typeof(Doctrine._WCS), result23)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["weapon_control_status_surface"]) + "'as weapon_control_status_surface允许的值为：'0'，'1'，'2'，对应于Free，Tight和Hold。");
				}
				doctrine.SetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, result23);
			}
		}
		if (dictionary.ContainsKey("weapon_control_status_surface_player_editable"))
		{
			doctrine.SetWeaponControlStatus_Surface_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["weapon_control_status_surface_player_editable"]));
		}
		if (dictionary.ContainsKey("weapon_control_status_subsurface"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["weapon_control_status_subsurface"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WCS>(Conversions.ToString(dictionary["weapon_control_status_subsurface"]), ignoreCase: true, out var result34) & Enum.IsDefined(typeof(Doctrine._WCS), result34)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["weapon_control_status_subsurface"]) + "'as weapon_control_status_subsurface允许的值为：'0'，'1'，'2'，分别对应Free，Tight和Hold。");
				}
				doctrine.SetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, result34);
			}
		}
		if (dictionary.ContainsKey("weapon_control_status_subsurface_player_editable"))
		{
			doctrine.SetWeaponControlStatus_Submarine_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["weapon_control_status_subsurface_player_editable"]));
		}
		if (dictionary.ContainsKey("weapon_control_status_land"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["weapon_control_status_land"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WCS>(Conversions.ToString(dictionary["weapon_control_status_land"]), ignoreCase: true, out var result41) & Enum.IsDefined(typeof(Doctrine._WCS), result41)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["weapon_control_status_land"]) + "'as weapon_control_status_land允许的值为：'0'，'1'，'2'，分别对应Free，Tight和Hold。");
				}
				doctrine.SetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, result41);
			}
		}
		if (dictionary.ContainsKey("weapon_control_status_land_player_editable"))
		{
			doctrine.SetWeaponControlStatus_Land_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["weapon_control_status_land_player_editable"]));
		}
		if (dictionary.ContainsKey("ignore_plotted_course"))
		{
			Doctrine._UseIgnorePlottedCourse result42;
			if (Operators.CompareString(Conversions.ToString(dictionary["ignore_plotted_course"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseIgnorePlottedCourse>(Conversions.ToString(dictionary["ignore_plotted_course"]), ignoreCase: true, out result42) & Enum.IsDefined(typeof(Doctrine._UseIgnorePlottedCourse), result42))
			{
				doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, result42);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["ignore_plotted_course"])).Value)
			{
				doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
			}
			else
			{
				doctrine.SetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.No);
			}
		}
		if (dictionary.ContainsKey("ignore_plotted_course_player_editable"))
		{
			doctrine.SetIgnorePlottedCourse_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["ignore_plotted_course_player_editable"]));
		}
		if (dictionary.ContainsKey("engaging_ambiguous_targets"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["engaging_ambiguous_targets"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._BehaviorTowardsTargetAmbiguity>(Conversions.ToString(dictionary["engaging_ambiguous_targets"]), ignoreCase: true, out var result43) & Enum.IsDefined(typeof(Doctrine._BehaviorTowardsTargetAmbiguity), result43)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["engaging_ambiguous_targets"]) + "'as engage_ambiguous_targets允许的值为：'0'，'1'，'2'对应于Ignore，Optimistic，Pessimistic");
				}
				doctrine.SetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false, result43);
			}
		}
		if (dictionary.ContainsKey("engaging_ambiguous_targets_player_editable"))
		{
			doctrine.SetBehaviorTowardsAmbigousTarget_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["engaging_ambiguous_targets_player_editable"]));
		}
		if (dictionary.ContainsKey("engage_opportunity_targets"))
		{
			Doctrine._UseShootTourists result44;
			if (Operators.CompareString(Conversions.ToString(dictionary["engage_opportunity_targets"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseShootTourists>(Conversions.ToString(dictionary["engage_opportunity_targets"]), ignoreCase: true, out result44) & Enum.IsDefined(typeof(Doctrine._UseShootTourists), result44))
			{
				doctrine.SetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false, result44);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["engage_opportunity_targets"])).Value)
			{
				doctrine.SetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseShootTourists.Yes);
			}
			else
			{
				doctrine.SetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseShootTourists.No);
			}
		}
		if (dictionary.ContainsKey("engage_opportunity_targets_player_editable"))
		{
			doctrine.SetShootTourists_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["engage_opportunity_targets_player_editable"]));
		}
		if (dictionary.ContainsKey("ignore_emcon_while_under_attack"))
		{
			Doctrine._UseIgnoreEMCONunderAttack result45;
			if (Operators.CompareString(Conversions.ToString(dictionary["ignore_emcon_while_under_attack"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseIgnoreEMCONunderAttack>(Conversions.ToString(dictionary["ignore_emcon_while_under_attack"]), ignoreCase: true, out result45) & Enum.IsDefined(typeof(Doctrine._UseIgnoreEMCONunderAttack), result45))
			{
				doctrine.SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false, result45);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["ignore_emcon_while_under_attack"])).Value)
			{
				doctrine.SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseIgnoreEMCONunderAttack.Yes);
			}
			else
			{
				doctrine.SetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseIgnoreEMCONunderAttack.No);
			}
		}
		if (dictionary.ContainsKey("ignore_emcon_while_under_attack_player_editable"))
		{
			doctrine.SetIgnoreEMCONunderAttack_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["ignore_emcon_while_under_attack_player_editable"]));
		}
		if (dictionary.ContainsKey("air_operations_tempo"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["air_operations_tempo"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetAirOpsTempo(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._AirOpsTempo>(Conversions.ToString(dictionary["air_operations_tempo"]), ignoreCase: true, out var result2) & Enum.IsDefined(typeof(Doctrine._AirOpsTempo), result2)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["air_operations_tempo"]) + "'as air_operations_tempo允许值为：'0'，'1'对应于Surge，Sustained。");
				}
				doctrine.SetAirOpsTempo(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, result2);
			}
		}
		if (dictionary.ContainsKey("air_operations_tempo_player_editable"))
		{
			doctrine.SetAirOpsTempo_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["air_operations_tempo_player_editable"]));
		}
		if (dictionary.ContainsKey("quick_turnaround_for_aircraft"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["quick_turnaround_for_aircraft"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._QuickTurnAroundForAicraft>(Conversions.ToString(dictionary["quick_turnaround_for_aircraft"]), ignoreCase: true, out var result3) & Enum.IsDefined(typeof(Doctrine._QuickTurnAroundForAicraft), result3)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["quick_turnaround_for_aircraft"]) + "'as quick_turnaround_for_aircraft允许值为：'0'，'1'，'2'对应于是，战士和ASW，否");
				}
				doctrine.SetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, result3);
			}
		}
		if (dictionary.ContainsKey("quick_turnaround_for_aircraft_player_editable"))
		{
			doctrine.SetQuickTurnAroundForAicraft_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["quick_turnaround_for_aircraft_player_editable"]));
		}
		if (dictionary.ContainsKey("rtb_when_winchester"))
		{
			Doctrine._WeaponStateRTB result4;
			if (Operators.CompareString(Conversions.ToString(dictionary["rtb_when_winchester"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._WeaponStateRTB>(Conversions.ToString(dictionary["rtb_when_winchester"]), ignoreCase: true, out result4) & Enum.IsDefined(typeof(Doctrine._WeaponStateRTB), result4))
			{
				doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, result4);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["rtb_when_winchester"])).Value)
			{
				doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.YesLeaveGroup);
			}
			else
			{
				doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._WeaponStateRTB.No);
			}
		}
		if (dictionary.ContainsKey("rtb_when_winchester_player_editable"))
		{
			doctrine.SetWinchesterShotgunRTB_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["rtb_when_winchester_player_editable"]));
		}
		if (dictionary.ContainsKey("use_sams_in_anti_surface_mode"))
		{
			Doctrine._UseSAMsAgainstShips result5;
			if (Operators.CompareString(Conversions.ToString(dictionary["use_sams_in_anti_surface_mode"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseSAMsAgainstShips>(Conversions.ToString(dictionary["use_sams_in_anti_surface_mode"]), ignoreCase: true, out result5) & Enum.IsDefined(typeof(Doctrine._UseSAMsAgainstShips), result5))
			{
				doctrine.SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, result5);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["use_sams_in_anti_surface_mode"])).Value)
			{
				doctrine.SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseSAMsAgainstShips.Yes);
			}
			else
			{
				doctrine.SetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseSAMsAgainstShips.No);
			}
		}
		if (dictionary.ContainsKey("use_sams_in_anti_surface_mode_player_editable"))
		{
			doctrine.SetUseSAMsOnASuW_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["use_sams_in_anti_surface_mode_player_editable"]));
		}
		if (dictionary.ContainsKey("use_wp_missile_in_anti_surface_mode"))
		{
			Doctrine._UseWpMissileAgainstShips result6;
			if (Operators.CompareString(Conversions.ToString(dictionary["use_wp_missile_in_anti_surface_mode"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseWpMissileAgainstShips>(Conversions.ToString(dictionary["use_wp_missile_in_anti_surface_mode"]), ignoreCase: true, out result6) & Enum.IsDefined(typeof(Doctrine._UseWpMissileAgainstShips), result6))
			{
				doctrine.SetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, result6);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["use_wp_missile_in_anti_surface_mode"])).Value)
			{
				doctrine.SetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseWpMissileAgainstShips.Yes);
			}
			else
			{
				doctrine.SetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseWpMissileAgainstShips.No);
			}
		}
		if (dictionary.ContainsKey("use_wp_missile_in_anti_surface_mode_player_editable"))
		{
			doctrine.SetUseWPMissileOnASuW_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["use_wp_missile_in_anti_surface_mode_player_editable"]));
		}
		if (dictionary.ContainsKey("maintain_standoff"))
		{
			Doctrine._UseMaintainStandoff result7;
			if (Operators.CompareString(Conversions.ToString(dictionary["maintain_standoff"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseMaintainStandoff>(Conversions.ToString(dictionary["maintain_standoff"]), ignoreCase: true, out result7) & Enum.IsDefined(typeof(Doctrine._UseMaintainStandoff), result7))
			{
				doctrine.SetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false, result7);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["maintain_standoff"])).Value)
			{
				doctrine.SetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseMaintainStandoff.Yes);
			}
			else
			{
				doctrine.SetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseMaintainStandoff.No);
			}
		}
		if (dictionary.ContainsKey("maintain_standoff_player_editable"))
		{
			doctrine.SetMaintainStandoff_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["maintain_standoff_player_editable"]));
		}
		if (dictionary.ContainsKey("kinematic_range_for_torpedoes"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["kinematic_range_for_torpedoes"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._UseKinematicRangeForTorpedoes>(Conversions.ToString(dictionary["kinematic_range_for_torpedoes"]), ignoreCase: true, out var result8) & Enum.IsDefined(typeof(Doctrine._UseKinematicRangeForTorpedoes), result8)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["kinematic_range_for_torpedoes"]) + "'作为kinematic_range_for_torpedoes允许的值为：'0'，'1'，'2'对应自动和手动射击，仅手动射击，否");
				}
				doctrine.SetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false, result8);
			}
		}
		if (dictionary.ContainsKey("kinematic_range_for_torpedoes_player_editable"))
		{
			doctrine.SetUseKinematicRangeForTorpedoes_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["kinematic_range_for_torpedoes_player_editable"]));
		}
		if (dictionary.ContainsKey("automatic_evasion"))
		{
			Doctrine._UseAutoEvade result9;
			if (Operators.CompareString(Conversions.ToString(dictionary["automatic_evasion"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else if (Enum.TryParse<Doctrine._UseAutoEvade>(Conversions.ToString(dictionary["automatic_evasion"]), ignoreCase: true, out result9) & Enum.IsDefined(typeof(Doctrine._UseAutoEvade), result9))
			{
				doctrine.SetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false, result9);
			}
			else if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["automatic_evasion"])).Value)
			{
				doctrine.SetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseAutoEvade.Yes);
			}
			else
			{
				doctrine.SetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false, Doctrine._UseAutoEvade.No);
			}
		}
		if (dictionary.ContainsKey("automatic_evasion_player_editable"))
		{
			doctrine.SetAutoEvade_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["automatic_evasion_player_editable"]));
		}
		if (dictionary.ContainsKey("use_refuel_unrep"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["use_refuel_unrep"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._UseUnderwayRefuelAndReplenishment>(Conversions.ToString(dictionary["use_refuel_unrep"]), ignoreCase: true, out var result10) & Enum.IsDefined(typeof(Doctrine._UseUnderwayRefuelAndReplenishment), result10)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["use_refuel_unrep"]) + "'as use_refuel_unrep允许值为：'0'，'1'，'2', 对应Always Excl Tankers，Never，Always Incl Tankers");
				}
				doctrine.SetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, result10);
			}
		}
		if (dictionary.ContainsKey("use_refuel_unrep_player_editable"))
		{
			doctrine.SetUseReplenishment_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["use_refuel_unrep_player_editable"]));
		}
		if (dictionary.ContainsKey("unrep_selection"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["unrep_selection"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._UnderwayRefuelAndReplenishmentSelection>(Conversions.ToString(dictionary["unrep_selection"]), ignoreCase: true, out var result11) & Enum.IsDefined(typeof(Doctrine._UnderwayRefuelAndReplenishmentSelection), result11)))
				{
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["unrep_selection"]) + "'as unrep_selection允许值为：'0'，'1'，'2'对应Pick Nearest，TankersBetweenUsAndObjectiveOnly，TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround");
				}
				doctrine.SetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, result11);
			}
		}
		if (dictionary.ContainsKey("unrep_selection_player_editable"))
		{
			doctrine.SetReplenishmentSelection_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["unrep_selection_player_editable"]));
		}
		if (dictionary.ContainsKey("refuel_unrep_allied"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["refuel_unrep_allied"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._RefuelAlliedUnits>(Conversions.ToString(dictionary["refuel_unrep_allied"]), ignoreCase: true, out var result13) & Enum.IsDefined(typeof(Doctrine._RefuelAlliedUnits), result13)))
				{
					byte[] obj = (byte[])Enum.GetValues(typeof(Doctrine._RefuelAlliedUnits));
					string text45 = ";允许的值是";
					byte[] array = obj;
					for (int i = 0; i < array.Length; i = checked(i + 1))
					{
						byte b = array[i];
						Doctrine._RefuelAlliedUnits refuelAlliedUnits = (Doctrine._RefuelAlliedUnits)b;
						string text53 = " " + refuelAlliedUnits.ToString() + "(" + b + ")";
						text45 += text53;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["refuel_unrep_allied"]) + "' as refuel_unrep_allied" + text45);
				}
				doctrine.SetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false, result13);
			}
		}
		if (dictionary.ContainsKey("refuel_unrep_allied_player_editable"))
		{
			doctrine.SetRefuelAllies_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["refuel_unrep_allied_player_editable"]));
		}
		if (dictionary.ContainsKey("bingo_threshold"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["bingo_threshold"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetBingoThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._BingoThreshold_E>(Conversions.ToString(dictionary["bingo_threshold"]), ignoreCase: true, out var result14) & Enum.IsDefined(typeof(Doctrine._BingoThreshold_E), result14)))
				{
					byte[] obj12 = (byte[])Enum.GetValues(typeof(Doctrine._BingoThreshold_E));
					string text54 = ";允许的值是";
					byte[] array12 = obj12;
					for (int j = 0; j < array12.Length; j = checked(j + 1))
					{
						byte b8 = array12[j];
						Doctrine._BingoThreshold_E bingoThreshold_E = (Doctrine._BingoThreshold_E)b8;
						string text55 = " " + bingoThreshold_E.ToString() + "(" + b8 + ")";
						text54 += text55;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["bingo_threshold"]) + "' as bingo_threshold" + text54);
				}
				doctrine.SetBingoThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result14);
			}
		}
		if (dictionary.ContainsKey("bingo_threshold_player_editable"))
		{
			doctrine.SetBingoRefuel_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["bingo_threshold_player_editable"]));
		}
		if (dictionary.ContainsKey("fuel_state_planned"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["fuel_state_planned"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetBingoJoker(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._FuelState>(Conversions.ToString(dictionary["fuel_state_planned"]), ignoreCase: true, out var result15) & Enum.IsDefined(typeof(Doctrine._FuelState), result15)))
				{
					byte[] obj20 = (byte[])Enum.GetValues(typeof(Doctrine._FuelState));
					string text56 = ";允许的值是";
					byte[] array20 = obj20;
					for (int k = 0; k < array20.Length; k = checked(k + 1))
					{
						byte b9 = array20[k];
						Doctrine._FuelState fuelState = (Doctrine._FuelState)b9;
						string text2 = " " + fuelState.ToString() + "(" + b9 + ")";
						text56 += text2;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["fuel_state_planned"]) + "' as fuel_state_planned" + text56);
				}
				doctrine.SetBingoJoker(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, result15);
			}
		}
		if (dictionary.ContainsKey("fuel_state_planned_player_editable"))
		{
			doctrine.SetBingoJoker_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["fuel_state_planned_player_editable"]));
		}
		if (dictionary.ContainsKey("fuel_state_rtb"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["fuel_state_rtb"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._FuelStateRTB>(Conversions.ToString(dictionary["fuel_state_rtb"]), ignoreCase: true, out var result16) & Enum.IsDefined(typeof(Doctrine._FuelStateRTB), result16)))
				{
					byte[] obj21 = (byte[])Enum.GetValues(typeof(Doctrine._FuelStateRTB));
					string text3 = ";允许的值是";
					byte[] array21 = obj21;
					for (int l = 0; l < array21.Length; l = checked(l + 1))
					{
						byte b10 = array21[l];
						Doctrine._FuelStateRTB fuelStateRTB = (Doctrine._FuelStateRTB)b10;
						string text4 = " " + fuelStateRTB.ToString() + "(" + b10 + ")";
						text3 += text4;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["fuel_state_rtb"]) + "' as fuel_state_rtb" + text3);
				}
				doctrine.SetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, result16);
			}
		}
		if (dictionary.ContainsKey("fuel_state_rtb_player_editable"))
		{
			doctrine.SetBingoJokerRTB_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["fuel_state_rtb_player_editable"]));
		}
		if (dictionary.ContainsKey("weapon_state_planned"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["weapon_state_planned"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWinchesterShotgun(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WeaponState>(Conversions.ToString(dictionary["weapon_state_planned"]), ignoreCase: true, out var result17) & Enum.IsDefined(typeof(Doctrine._WeaponState), result17)))
				{
					int[] obj22 = (int[])Enum.GetValues(typeof(Doctrine._WeaponState));
					string text5 = ";允许的值是";
					int[] array22 = obj22;
					for (int m = 0; m < array22.Length; m = checked(m + 1))
					{
						int num = array22[m];
						Doctrine._WeaponState weaponState = (Doctrine._WeaponState)num;
						string text6 = " " + weaponState.ToString() + "(" + num + ")";
						text5 += text6;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["weapon_state_planned"]) + "' as weapon_state_planned" + text5);
				}
				doctrine.SetWinchesterShotgun(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false, result17);
			}
		}
		if (dictionary.ContainsKey("weapon_state_planned_player_editable"))
		{
			doctrine.SetWinchesterShotgun_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["weapon_state_planned_player_editable"]));
		}
		if (dictionary.ContainsKey("weapon_state_rtb"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["weapon_state_rtb"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WeaponStateRTB>(Conversions.ToString(dictionary["weapon_state_rtb"]), ignoreCase: true, out var result18) & Enum.IsDefined(typeof(Doctrine._WeaponStateRTB), result18)))
				{
					byte[] obj23 = (byte[])Enum.GetValues(typeof(Doctrine._WeaponStateRTB));
					string text7 = ";允许的值是";
					byte[] array23 = obj23;
					for (int n = 0; n < array23.Length; n = checked(n + 1))
					{
						byte b11 = array23[n];
						Doctrine._WeaponStateRTB weaponStateRTB = (Doctrine._WeaponStateRTB)b11;
						string text8 = " " + weaponStateRTB.ToString() + "(" + b11 + ")";
						text7 += text8;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["weapon_state_rtb"]) + "' as weapon_state_rtb" + text7);
				}
				doctrine.SetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false, result18);
			}
		}
		if (dictionary.ContainsKey("weapon_state_rtb_player_editable"))
		{
			doctrine.SetWinchesterShotgunRTB_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["weapon_state_rtb_player_editable"]));
		}
		if (dictionary.ContainsKey("gun_strafing"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["gun_strafing"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._GunStrafeGroundTargets>(Conversions.ToString(dictionary["gun_strafing"]), ignoreCase: true, out var result19) & Enum.IsDefined(typeof(Doctrine._GunStrafeGroundTargets), result19)))
				{
					byte[] obj24 = (byte[])Enum.GetValues(typeof(Doctrine._GunStrafeGroundTargets));
					string text9 = ";允许的值是";
					byte[] array24 = obj24;
					for (int num12 = 0; num12 < array24.Length; num12 = checked(num12 + 1))
					{
						byte b12 = array24[num12];
						Doctrine._GunStrafeGroundTargets gunStrafeGroundTargets = (Doctrine._GunStrafeGroundTargets)b12;
						string text10 = " " + gunStrafeGroundTargets.ToString() + "(" + b12 + ")";
						text9 += text10;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["gun_strafing"]) + "' as gun_strafing" + text9);
				}
				doctrine.SetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false, result19);
			}
		}
		if (dictionary.ContainsKey("gun_strafing_player_editable"))
		{
			doctrine.SetGunStrafing_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["gun_strafing_player_editable"]));
		}
		if (dictionary.ContainsKey("jettison_ordnance"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["jettison_ordnance"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._JettisonOrdnance>(Conversions.ToString(dictionary["jettison_ordnance"]), ignoreCase: true, out var result20) & Enum.IsDefined(typeof(Doctrine._JettisonOrdnance), result20)))
				{
					byte[] obj25 = (byte[])Enum.GetValues(typeof(Doctrine._JettisonOrdnance));
					string text11 = ";允许的值是";
					byte[] array25 = obj25;
					for (int num23 = 0; num23 < array25.Length; num23 = checked(num23 + 1))
					{
						byte b13 = array25[num23];
						Doctrine._JettisonOrdnance jettisonOrdnance = (Doctrine._JettisonOrdnance)b13;
						string text13 = " " + jettisonOrdnance.ToString() + "(" + b13 + ")";
						text11 += text13;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["jettison_ordnance"]) + "' as jettison_ordnance" + text11);
				}
				doctrine.SetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false, result20);
			}
		}
		if (dictionary.ContainsKey("jettison_ordnance_player_editable"))
		{
			doctrine.SetJettisonOrdnance_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["jettison_ordnance_player_editable"]));
		}
		if (dictionary.ContainsKey("bvr_logic"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["bvr_logic"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.method_1(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._BVRLogicEnum>(Conversions.ToString(dictionary["bvr_logic"]), ignoreCase: true, out var result21) & Enum.IsDefined(typeof(Doctrine._BVRLogicEnum), result21)))
				{
					byte[] obj26 = (byte[])Enum.GetValues(typeof(Doctrine._BVRLogicEnum));
					string text14 = ";允许的值是";
					byte[] array26 = obj26;
					for (int num26 = 0; num26 < array26.Length; num26 = checked(num26 + 1))
					{
						byte b14 = array26[num26];
						Doctrine._BVRLogicEnum bVRLogicEnum = (Doctrine._BVRLogicEnum)b14;
						string text15 = " " + bVRLogicEnum.ToString() + "(" + b14 + ")";
						text14 += text15;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["bvr_logic"]) + "' as bvr_logic" + text14);
				}
				doctrine.method_1(scenario_0, bool_0: false, bool_1: false, bool_2: false, result21);
			}
		}
		if (dictionary.ContainsKey("bvr_logic_player_editable"))
		{
			doctrine.SetBVRLogic_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["bvr_logic_player_editable"]));
		}
		if (dictionary.ContainsKey("avoid_contact"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["avoid_contact"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._AvoidContactWhenPossible>(Conversions.ToString(dictionary["avoid_contact"]), ignoreCase: true, out var result22) & Enum.IsDefined(typeof(Doctrine._AvoidContactWhenPossible), result22)))
				{
					byte[] obj2 = (byte[])Enum.GetValues(typeof(Doctrine._AvoidContactWhenPossible));
					string text16 = ";允许的值是";
					byte[] array2 = obj2;
					for (int num27 = 0; num27 < array2.Length; num27 = checked(num27 + 1))
					{
						byte b15 = array2[num27];
						Doctrine._AvoidContactWhenPossible avoidContactWhenPossible = (Doctrine._AvoidContactWhenPossible)b15;
						string text17 = " " + avoidContactWhenPossible.ToString() + "(" + b15 + ")";
						text16 += text17;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["avoid_contact"]) + "' as avoid_contact" + text16);
				}
				doctrine.SetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false, result22);
			}
		}
		if (dictionary.ContainsKey("avoid_contact_player_editable"))
		{
			doctrine.SetAvoidContact_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["avoid_contact_player_editable"]));
		}
		if (dictionary.ContainsKey("dive_on_threat"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["dive_on_threat"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._DiveOnContact>(Conversions.ToString(dictionary["dive_on_threat"]), ignoreCase: true, out var result24) & Enum.IsDefined(typeof(Doctrine._DiveOnContact), result24)))
				{
					byte[] obj3 = (byte[])Enum.GetValues(typeof(Doctrine._DiveOnContact));
					string text18 = ";允许的值是";
					byte[] array3 = obj3;
					for (int num28 = 0; num28 < array3.Length; num28 = checked(num28 + 1))
					{
						byte b2 = array3[num28];
						Doctrine._DiveOnContact diveOnContact = (Doctrine._DiveOnContact)b2;
						string text19 = " " + diveOnContact.ToString() + "(" + b2 + ")";
						text18 += text19;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["dive_on_threat"]) + "' as dive_on_threat" + text18);
				}
				doctrine.SetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false, result24);
			}
		}
		if (dictionary.ContainsKey("dive_on_threat_player_editable"))
		{
			doctrine.SetDiveWhenThreatsDetected_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["dive_on_threat_player_editable"]));
		}
		if (dictionary.ContainsKey("recharge_on_patrol"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["recharge_on_patrol"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._RechargeBatteryPercentage>(Conversions.ToString(dictionary["recharge_on_patrol"]), ignoreCase: true, out var result25) & Enum.IsDefined(typeof(Doctrine._RechargeBatteryPercentage), result25)))
				{
					int[] obj4 = (int[])Enum.GetValues(typeof(Doctrine._RechargeBatteryPercentage));
					string text20 = ";允许的值是";
					int[] array4 = obj4;
					for (int num29 = 0; num29 < array4.Length; num29 = checked(num29 + 1))
					{
						int num30 = array4[num29];
						Doctrine._RechargeBatteryPercentage rechargeBatteryPercentage = (Doctrine._RechargeBatteryPercentage)num30;
						string text21 = " " + rechargeBatteryPercentage.ToString() + "(" + num30 + ")";
						text20 += text21;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["recharge_on_patrol"]) + "' as recharge_on_patrol" + text20);
				}
				doctrine.SetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false, result25);
			}
		}
		if (dictionary.ContainsKey("recharge_on_patrol_player_editable"))
		{
			doctrine.SetRechargePercentagePatrol_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["recharge_on_patrol_player_editable"]));
		}
		if (dictionary.ContainsKey("recharge_on_attack"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["recharge_on_attack"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._RechargeBatteryPercentage>(Conversions.ToString(dictionary["recharge_on_attack"]), ignoreCase: true, out var result26) & Enum.IsDefined(typeof(Doctrine._RechargeBatteryPercentage), result26)))
				{
					int[] obj5 = (int[])Enum.GetValues(typeof(Doctrine._RechargeBatteryPercentage));
					string text22 = ";允许的值是";
					int[] array5 = obj5;
					for (int num31 = 0; num31 < array5.Length; num31 = checked(num31 + 1))
					{
						int num2 = array5[num31];
						Doctrine._RechargeBatteryPercentage rechargeBatteryPercentage2 = (Doctrine._RechargeBatteryPercentage)num2;
						string text24 = " " + rechargeBatteryPercentage2.ToString() + "(" + num2 + ")";
						text22 += text24;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["recharge_on_attack"]) + "' as recharge_on_attack" + text22);
				}
				doctrine.SetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false, result26);
			}
		}
		if (dictionary.ContainsKey("recharge_on_attack_player_editable"))
		{
			doctrine.SetRechargePercentageAttack_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["recharge_on_attack_player_editable"]));
		}
		if (dictionary.ContainsKey("use_aip"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["use_aip"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.method_3(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._UseAIP>(Conversions.ToString(dictionary["use_aip"]), ignoreCase: true, out var result27) & Enum.IsDefined(typeof(Doctrine._UseAIP), result27)))
				{
					byte[] obj6 = (byte[])Enum.GetValues(typeof(Doctrine._UseAIP));
					string text25 = ";允许的值是";
					byte[] array6 = obj6;
					for (int num3 = 0; num3 < array6.Length; num3 = checked(num3 + 1))
					{
						byte b3 = array6[num3];
						Doctrine._UseAIP useAIP = (Doctrine._UseAIP)b3;
						string text26 = " " + useAIP.ToString() + "(" + b3 + ")";
						text25 += text26;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["use_aip"]) + "' as use_aip" + text25);
				}
				doctrine.method_3(scenario_0, bool_0: false, bool_1: false, bool_2: false, result27);
			}
		}
		if (dictionary.ContainsKey("use_aip_player_editable"))
		{
			doctrine.SetAIPUsage_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["use_aip_player_editable"]));
		}
		if (dictionary.ContainsKey("dipping_sonar"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["dipping_sonar"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._UseDippingSonar>(Conversions.ToString(dictionary["dipping_sonar"]), ignoreCase: true, out var result28) & Enum.IsDefined(typeof(Doctrine._UseDippingSonar), result28)))
				{
					byte[] obj7 = (byte[])Enum.GetValues(typeof(Doctrine._UseDippingSonar));
					string text27 = ";允许的值是";
					byte[] array7 = obj7;
					for (int num4 = 0; num4 < array7.Length; num4 = checked(num4 + 1))
					{
						byte b4 = array7[num4];
						Doctrine._UseDippingSonar useDippingSonar = (Doctrine._UseDippingSonar)b4;
						string text28 = " " + useDippingSonar.ToString() + "(" + b4 + ")";
						text27 += text28;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["dipping_sonar"]) + "' as dipping_sonar" + text27);
				}
				doctrine.SetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false, result28);
			}
		}
		if (dictionary.ContainsKey("dipping_sonar_player_editable"))
		{
			doctrine.SetDippingSonar_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["dipping_sonar_player_editable"]));
		}
		if (dictionary.ContainsKey("withdraw_on_damage"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["withdraw_on_damage"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._DamageThreshold>(Conversions.ToString(dictionary["withdraw_on_damage"]), ignoreCase: true, out var result29) & Enum.IsDefined(typeof(Doctrine._DamageThreshold), result29)))
				{
					short[] obj8 = (short[])Enum.GetValues(typeof(Doctrine._DamageThreshold));
					string text29 = ";允许的值是";
					short[] array8 = obj8;
					for (int num5 = 0; num5 < array8.Length; num5 = checked(num5 + 1))
					{
						short num6 = array8[num5];
						Doctrine._DamageThreshold damageThreshold = (Doctrine._DamageThreshold)num6;
						string text30 = " " + damageThreshold.ToString() + "(" + num6 + ")";
						text29 += text30;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["withdraw_on_damage"]) + "' as withdraw_on_damage" + text29);
				}
				doctrine.SetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result29);
			}
		}
		if (dictionary.ContainsKey("withdraw_on_fuel"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["withdraw_on_fuel"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._FuelQuantityThreshold>(Conversions.ToString(dictionary["withdraw_on_fuel"]), ignoreCase: true, out var result30) & Enum.IsDefined(typeof(Doctrine._FuelQuantityThreshold), result30)))
				{
					short[] obj9 = (short[])Enum.GetValues(typeof(Doctrine._FuelQuantityThreshold));
					string text31 = ";允许的值是";
					short[] array9 = obj9;
					for (int num7 = 0; num7 < array9.Length; num7 = checked(num7 + 1))
					{
						short num8 = array9[num7];
						Doctrine._FuelQuantityThreshold fuelQuantityThreshold = (Doctrine._FuelQuantityThreshold)num8;
						string text32 = " " + fuelQuantityThreshold.ToString() + "(" + num8 + ")";
						text31 += text32;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["withdraw_on_fuel"]) + "' as withdraw_on_fuel" + text31);
				}
				doctrine.SetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result30);
			}
		}
		if (dictionary.ContainsKey("withdraw_on_attack"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["withdraw_on_attack"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WeaponQuantityThreshold>(Conversions.ToString(dictionary["withdraw_on_attack"]), ignoreCase: true, out var result31) & Enum.IsDefined(typeof(Doctrine._WeaponQuantityThreshold), result31)))
				{
					short[] obj10 = (short[])Enum.GetValues(typeof(Doctrine._WeaponQuantityThreshold));
					string text33 = ";允许的值是";
					short[] array10 = obj10;
					for (int num9 = 0; num9 < array10.Length; num9 = checked(num9 + 1))
					{
						short num10 = array10[num9];
						Doctrine._WeaponQuantityThreshold weaponQuantityThreshold = (Doctrine._WeaponQuantityThreshold)num10;
						string text35 = " " + weaponQuantityThreshold.ToString() + "(" + num10 + ")";
						text33 += text35;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["withdraw_on_attack"]) + "' as withdraw_on_attack" + text33);
				}
				doctrine.SetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result31);
			}
		}
		if (dictionary.ContainsKey("withdraw_on_defence"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["withdraw_on_defence"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WeaponQuantityThreshold>(Conversions.ToString(dictionary["withdraw_on_defence"]), ignoreCase: true, out var result32) & Enum.IsDefined(typeof(Doctrine._WeaponQuantityThreshold), result32)))
				{
					short[] obj11 = (short[])Enum.GetValues(typeof(Doctrine._WeaponQuantityThreshold));
					string text36 = ";允许的值是";
					short[] array11 = obj11;
					for (int num11 = 0; num11 < array11.Length; num11 = checked(num11 + 1))
					{
						short num13 = array11[num11];
						Doctrine._WeaponQuantityThreshold weaponQuantityThreshold2 = (Doctrine._WeaponQuantityThreshold)num13;
						string text37 = " " + weaponQuantityThreshold2.ToString() + "(" + num13 + ")";
						text36 += text37;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["withdraw_on_defence"]) + "' as withdraw_on_defence" + text36);
				}
				doctrine.SetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result32);
			}
		}
		if (dictionary.ContainsKey("deploy_on_damage"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["deploy_on_damage"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._DamageThreshold>(Conversions.ToString(dictionary["deploy_on_damage"]), ignoreCase: true, out var result33) & Enum.IsDefined(typeof(Doctrine._DamageThreshold), result33)))
				{
					short[] obj13 = (short[])Enum.GetValues(typeof(Doctrine._DamageThreshold));
					string text38 = ";允许的值是";
					short[] array13 = obj13;
					for (int num14 = 0; num14 < array13.Length; num14 = checked(num14 + 1))
					{
						short num15 = array13[num14];
						Doctrine._DamageThreshold damageThreshold2 = (Doctrine._DamageThreshold)num15;
						string text39 = " " + damageThreshold2.ToString() + "(" + num15 + ")";
						text38 += text39;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["deploy_on_damage"]) + "' as deploy_on_damage" + text38);
				}
				doctrine.SetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result33);
			}
		}
		if (dictionary.ContainsKey("deploy_on_fuel"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["deploy_on_fuel"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._FuelQuantityThreshold>(Conversions.ToString(dictionary["deploy_on_fuel"]), ignoreCase: true, out var result35) & Enum.IsDefined(typeof(Doctrine._FuelQuantityThreshold), result35)))
				{
					short[] obj14 = (short[])Enum.GetValues(typeof(Doctrine._FuelQuantityThreshold));
					string text40 = ";允许的值是";
					short[] array14 = obj14;
					for (int num16 = 0; num16 < array14.Length; num16 = checked(num16 + 1))
					{
						short num17 = array14[num16];
						Doctrine._FuelQuantityThreshold fuelQuantityThreshold2 = (Doctrine._FuelQuantityThreshold)num17;
						string text41 = " " + fuelQuantityThreshold2.ToString() + "(" + num17 + ")";
						text40 += text41;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["deploy_on_fuel"]) + "' as deploy_on_fuel" + text40);
				}
				doctrine.SetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result35);
			}
		}
		if (dictionary.ContainsKey("deploy_on_attack"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["deploy_on_attack"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WeaponQuantityThreshold>(Conversions.ToString(dictionary["deploy_on_attack"]), ignoreCase: true, out var result36) & Enum.IsDefined(typeof(Doctrine._WeaponQuantityThreshold), result36)))
				{
					short[] obj15 = (short[])Enum.GetValues(typeof(Doctrine._WeaponQuantityThreshold));
					string text42 = ";允许的值是";
					short[] array15 = obj15;
					for (int num18 = 0; num18 < array15.Length; num18 = checked(num18 + 1))
					{
						short num19 = array15[num18];
						Doctrine._WeaponQuantityThreshold weaponQuantityThreshold3 = (Doctrine._WeaponQuantityThreshold)num19;
						string text43 = " " + weaponQuantityThreshold3.ToString() + "(" + num19 + ")";
						text42 += text43;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["deploy_on_attack"]) + "' as deploy_on_attack" + text42);
				}
				doctrine.SetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result36);
			}
		}
		if (dictionary.ContainsKey("deploy_on_defence"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["deploy_on_defence"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._WeaponQuantityThreshold>(Conversions.ToString(dictionary["deploy_on_defence"]), ignoreCase: true, out var result37) & Enum.IsDefined(typeof(Doctrine._WeaponQuantityThreshold), result37)))
				{
					short[] obj16 = (short[])Enum.GetValues(typeof(Doctrine._WeaponQuantityThreshold));
					string text44 = ";允许的值是";
					short[] array16 = obj16;
					for (int num20 = 0; num20 < array16.Length; num20 = checked(num20 + 1))
					{
						short num21 = array16[num20];
						Doctrine._WeaponQuantityThreshold weaponQuantityThreshold4 = (Doctrine._WeaponQuantityThreshold)num21;
						string text46 = " " + weaponQuantityThreshold4.ToString() + "(" + num21 + ")";
						text44 += text46;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["deploy_on_defence"]) + "' as deploy_on_defence" + text44);
				}
				doctrine.SetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false, result37);
			}
		}
		if (dictionary.ContainsKey("navigation_surface"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["navigation_surface"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._NavigationMethod>(Conversions.ToString(dictionary["navigation_surface"]), ignoreCase: true, out var result38) & Enum.IsDefined(typeof(Doctrine._NavigationMethod), result38)))
				{
					byte[] obj17 = (byte[])Enum.GetValues(typeof(Doctrine._NavigationMethod));
					string text47 = ";允许的值是";
					byte[] array17 = obj17;
					for (int num22 = 0; num22 < array17.Length; num22 = checked(num22 + 1))
					{
						byte b5 = array17[num22];
						Doctrine._NavigationMethod navigationMethod = (Doctrine._NavigationMethod)b5;
						string text48 = " " + navigationMethod.ToString() + "(" + b5 + ")";
						text47 += text48;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["navigation_surface"]) + "' as navigation_surface" + text47);
				}
				doctrine.SetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false, result38);
			}
		}
		if (dictionary.ContainsKey("navigation_surface_player_editable"))
		{
			doctrine.SetSurfaceNavigation_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["navigation_surface_player_editable"]));
		}
		if (dictionary.ContainsKey("navigation_sub_surface"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["navigation_sub_surface"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetSubmarineNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._NavigationMethod>(Conversions.ToString(dictionary["navigation_sub_surface"]), ignoreCase: true, out var result39) & Enum.IsDefined(typeof(Doctrine._NavigationMethod), result39)))
				{
					byte[] obj18 = (byte[])Enum.GetValues(typeof(Doctrine._NavigationMethod));
					string text49 = ";允许的值是";
					byte[] array18 = obj18;
					for (int num24 = 0; num24 < array18.Length; num24 = checked(num24 + 1))
					{
						byte b6 = array18[num24];
						Doctrine._NavigationMethod navigationMethod2 = (Doctrine._NavigationMethod)b6;
						string text50 = " " + navigationMethod2.ToString() + "(" + b6 + ")";
						text49 += text50;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["navigation_sub_surface"]) + "' as navigation_sub_surface" + text49);
				}
				doctrine.SetSubmarineNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false, result39);
			}
		}
		if (dictionary.ContainsKey("navigation_sub_surface_player_editable"))
		{
			doctrine.SetSubmarineNavigation_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["navigation_sub_surface_player_editable"]));
		}
		if (dictionary.ContainsKey("navigation_land"))
		{
			if (Operators.CompareString(Conversions.ToString(dictionary["navigation_land"]).ToLower(), "inherit", TextCompare: false) == 0)
			{
				doctrine.SetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false, null);
			}
			else
			{
				if (!(Enum.TryParse<Doctrine._NavigationMethod>(Conversions.ToString(dictionary["navigation_land"]), ignoreCase: true, out var result40) & Enum.IsDefined(typeof(Doctrine._NavigationMethod), result40)))
				{
					byte[] obj19 = (byte[])Enum.GetValues(typeof(Doctrine._NavigationMethod));
					string text51 = ";允许的值是";
					byte[] array19 = obj19;
					for (int num25 = 0; num25 < array19.Length; num25 = checked(num25 + 1))
					{
						byte b7 = array19[num25];
						Doctrine._NavigationMethod navigationMethod3 = (Doctrine._NavigationMethod)b7;
						string text52 = " " + navigationMethod3.ToString() + "(" + b7 + ")";
						text51 += text52;
					}
					throw new LuaError("无法理解'" + Conversions.ToString(dictionary["navigation_land"]) + "' as navigation_land" + text51);
				}
				doctrine.SetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false, result40);
			}
		}
		if (dictionary.ContainsKey("navigation_land_player_editable"))
		{
			doctrine.SetLandNavigation_PlayerEditable(scenario_0, Conversions.ToBoolean(dictionary["navigation_land_player_editable"]));
		}
		luaTable_1 = ScenEdit_GetDoctrine(luaTable_0, scenario_0);
		return luaTable_1;
	}

	public static LuaTable ScenEdit_GetDoctrine(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Doctrine doctrine = null;
		Side side = null;
		if (dictionary.ContainsKey("GUID"))
		{
			string text4 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doctrine = scenario_0.ActiveUnits[text4].Doctrine;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("找不到guid'" + text4 + "'");
			}
		}
		else if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
		{
			if (dictionary.ContainsKey("MISSION"))
			{
				string text2 = Conversions.ToString(dictionary["MISSION"]);
				if (!dictionary.ContainsKey("SIDE"))
				{
					throw new LuaError("要选择任务，您需要定义一个分方。");
				}
				string text5 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("找不到分方'" + text5 + "'");
				}
				try
				{
					Mission mission = side.Missions.FirstOrDefault((Mission s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
					doctrine = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("找不到任务'" + text2 + "'");
				}
			}
			else if (dictionary.ContainsKey("SIDE"))
			{
				string text6 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
					doctrine = side.Doctrine;
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("找不到分方'" + text6 + "'");
				}
			}
		}
		else
		{
			string text3 = null;
			if (dictionary.ContainsKey("NAME"))
			{
				text3 = Conversions.ToString(dictionary["NAME"]);
			}
			else if (dictionary.ContainsKey("UNITNAME"))
			{
				text3 = Conversions.ToString(dictionary["UNITNAME"]);
			}
			if (dictionary.ContainsKey("SIDE"))
			{
				string text7 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("找不到分方'" + text7 + "'");
				}
				try
				{
					doctrine = side.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, text3, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text3, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("找不到单元'" + text3 + "' 分方 '" + text7 + "'");
				}
			}
			else
			{
				try
				{
					doctrine = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, text3, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text3, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					throw new LuaError("找不到单元'" + text3 + "'");
				}
			}
		}
		if (doctrine == null)
		{
			throw new LuaError("需要定义一个guid，一个名字，一个分方和名称，一个分方和任务，或者只是一个分方。");
		}
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		bool flag = false;
		bool flag2 = false;
		if (dictionary.ContainsKey("ACTUAL"))
		{
			flag2 = true;
		}
		if (dictionary.ContainsKey("PLAYER_EDITABLE"))
		{
			flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["PLAYER_EDITABLE"])).Value;
		}
		if (!doctrine.NukesAllowed_Inherits() || (doctrine.NukesAllowed_Inherits() && flag2))
		{
			val["use_nuclear_weapons"] = ((byte)doctrine.GetNukesAllowed(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.NukesAllowed_Inherits() && flag)
		{
			val["use_nuclear_weapons_player_editable"] = doctrine.GetNukesAllowed_PlayerEditable(scenario_0);
		}
		if (!doctrine.WeaponControlStatus_Air_Inherits() || (doctrine.WeaponControlStatus_Air_Inherits() && flag2))
		{
			val["weapon_control_status_air"] = ((byte)doctrine.GetWeaponControlStatus_Air(scenario_0, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WeaponControlStatus_Air_Inherits() && flag)
		{
			val["weapon_control_status_air_player_editable"] = doctrine.GetWeaponControlStatus_Air_PlayerEditable(scenario_0);
		}
		if (!doctrine.WeaponControlStatus_Surface_Inherits() || (doctrine.WeaponControlStatus_Surface_Inherits() && flag2))
		{
			val["weapon_control_status_surface"] = ((byte)doctrine.GetWeaponControlStatus_Surface(scenario_0, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WeaponControlStatus_Surface_Inherits() && flag)
		{
			val["weapon_control_status_surface_player_editable"] = doctrine.GetWeaponControlStatus_Surface_PlayerEditable(scenario_0);
		}
		if (!doctrine.WeaponControlStatus_Submarine_Inherits() || (doctrine.WeaponControlStatus_Submarine_Inherits() && flag2))
		{
			val["weapon_control_status_subsurface"] = ((byte)doctrine.GetWeaponControlStatus_Submarine(scenario_0, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WeaponControlStatus_Submarine_Inherits() && flag)
		{
			val["weapon_control_status_subsurface_player_editable"] = doctrine.GetWeaponControlStatus_Submarine_PlayerEditable(scenario_0);
		}
		if (!doctrine.WeaponControlStatus_Land_Inherits() || (doctrine.WeaponControlStatus_Land_Inherits() && flag2))
		{
			val["weapon_control_status_land"] = ((byte)doctrine.GetWeaponControlStatus_Land(scenario_0, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WeaponControlStatus_Land_Inherits() && flag)
		{
			val["weapon_control_status_land_player_editable"] = doctrine.GetWeaponControlStatus_Land_PlayerEditable(scenario_0);
		}
		if (!doctrine.IgnorePlottedCourse_Inherits() || (doctrine.IgnorePlottedCourse_Inherits() && flag2))
		{
			val["ignore_plotted_course"] = ((byte)doctrine.GetIgnorePlottedCourse(scenario_0, bool_0: false, false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.IgnorePlottedCourse_Inherits() && flag)
		{
			val["ignore_plotted_course_player_editable"] = doctrine.GetIgnorePlottedCourse_PlayerEditable(scenario_0);
		}
		if (!doctrine.BehaviorTowardsAmbigousTarget_Inherits() || (doctrine.BehaviorTowardsAmbigousTarget_Inherits() && flag2))
		{
			val["engaging_ambiguous_targets"] = ((byte)doctrine.GetBehaviorTowardsAmbigousTarget(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.BehaviorTowardsAmbigousTarget_Inherits() && flag)
		{
			val["engaging_ambiguous_targets_player_editable"] = doctrine.GetBehaviorTowardsAmbigousTarget_PlayerEditable(scenario_0);
		}
		if (!doctrine.ShootTourists_Inherits() || (doctrine.ShootTourists_Inherits() && flag2))
		{
			val["engage_opportunity_targets"] = ((byte)doctrine.GetShootTourists(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.ShootTourists_Inherits() && flag)
		{
			val["engage_opportunity_targets_player_editable"] = doctrine.GetShootTourists_PlayerEditable(scenario_0);
		}
		if (!doctrine.IgnoreEMCONunderAttack_Inherits() || (doctrine.IgnoreEMCONunderAttack_Inherits() && flag2))
		{
			val["ignore_emcon_while_under_attack"] = ((byte)doctrine.GetIgnoreEMCONunderAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.IgnoreEMCONunderAttack_Inherits() && flag)
		{
			val["ignore_emcon_while_under_attack_player_editable"] = doctrine.GetIgnoreEMCONunderAttack_PlayerEditable(scenario_0);
		}
		if (!doctrine.UseKinematicRangeForTorpedoes_Inherits() || (doctrine.UseKinematicRangeForTorpedoes_Inherits() && flag2))
		{
			val["kinematic_range_for_torpedoes"] = ((byte)doctrine.GetUseKinematicRangeForTorpedoes(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.UseKinematicRangeForTorpedoes_Inherits() && flag)
		{
			val["kinematic_range_for_torpedoes_player_editable"] = doctrine.GetUseKinematicRangeForTorpedoes_PlayerEditable(scenario_0);
		}
		if (!doctrine.AutoEvade_Inherits() || (doctrine.AutoEvade_Inherits() && flag2))
		{
			val["automatic_evasion"] = ((byte)doctrine.GetAutoEvade(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.AutoEvade_Inherits() && flag)
		{
			val["automatic_evasion_player_editable"] = doctrine.GetAutoEvade_PlayerEditable(scenario_0);
		}
		if (!doctrine.UseReplenishment_Inherits() || (doctrine.UseReplenishment_Inherits() && flag2))
		{
			val["use_refuel_unrep"] = ((byte)doctrine.GetUseReplenishment(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString();
		}
		if (!doctrine.UseReplenishment_Inherits() && flag)
		{
			val["use_refuel_unrep_player_editable"] = doctrine.GetUseReplenishment_PlayerEditable(scenario_0);
		}
		if (!doctrine.ReplenishmentSelection_Inherits() || (doctrine.ReplenishmentSelection_Inherits() && flag2))
		{
			val["unrep_selection"] = ((byte)doctrine.GetReplenishmentSelection(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString();
		}
		if (!doctrine.ReplenishmentSelection_Inherits() && flag)
		{
			val["unrep_selection_player_editable"] = doctrine.GetReplenishmentSelection_PlayerEditable(scenario_0);
		}
		if (!doctrine.RefuelAllies_Inherits() || (doctrine.RefuelAllies_Inherits() && flag2))
		{
			val["refuel_unrep_allied"] = ((byte)doctrine.GetRefuelAllies(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.RefuelAllies_Inherits() && flag)
		{
			val["refuel_unrep_allied_player_editable"] = doctrine.GetRefuelAllies_PlayerEditable(scenario_0);
		}
		if (!doctrine.BingoThreshold_Inherits || (doctrine.BingoThreshold_Inherits && flag2))
		{
			val["bingo_threshold"] = ((byte)doctrine.GetBingoThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.BingoThreshold_Inherits && flag)
		{
			val["bingo_threshold_player_editable"] = doctrine.GetBingoRefuel_PlayerEditable(scenario_0);
		}
		if (!doctrine.AirOpsTempo_Inherits() || (doctrine.AirOpsTempo_Inherits() && flag2))
		{
			val["air_operations_tempo"] = ((byte)doctrine.GetAirOpsTempo(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString();
		}
		if (!doctrine.AirOpsTempo_Inherits() && flag)
		{
			val["air_operations_tempo_player_editable"] = doctrine.GetAirOpsTempo_PlayerEditable(scenario_0);
		}
		if (!doctrine.QuickTurnAroundForAicraft_Inherits() || (doctrine.QuickTurnAroundForAicraft_Inherits() && flag2))
		{
			val["quick_turnaround_for_aircraft"] = ((byte)doctrine.GetQuickTurnAroundForAicraft(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString();
		}
		if (!doctrine.QuickTurnAroundForAicraft_Inherits() && flag)
		{
			val["quick_turnaround_for_aircraft_player_editable"] = doctrine.GetQuickTurnAroundForAicraft_PlayerEditable(scenario_0);
		}
		if (!doctrine.BingoJoker_Inherits() || (doctrine.BingoJoker_Inherits() && flag2))
		{
			val["fuel_state_planned"] = ((byte)doctrine.GetBingoJoker(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString();
		}
		if (!doctrine.BingoJoker_Inherits() && flag)
		{
			val["fuel_state_planned_player_editable"] = doctrine.GetBingoJoker_PlayerEditable(scenario_0);
		}
		if (!doctrine.BingoJokerRTB_Inherits() || (doctrine.BingoJokerRTB_Inherits() && flag2))
		{
			val["fuel_state_rtb"] = ((byte)doctrine.GetBingoJokerRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.BingoJokerRTB_Inherits() && flag)
		{
			val["fuel_state_rtb_player_editable"] = doctrine.GetBingoJokerRTB_PlayerEditable(scenario_0);
		}
		if (!doctrine.WinchesterShotgun_Inherits() || (doctrine.WinchesterShotgun_Inherits() && flag2))
		{
			val["weapon_state_planned"] = ((int)doctrine.GetWinchesterShotgun(scenario_0, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value).ToString();
		}
		if (!doctrine.WinchesterShotgun_Inherits() && flag)
		{
			val["weapon_state_planned_player_editable"] = doctrine.GetWinchesterShotgun_PlayerEditable(scenario_0);
		}
		if (!doctrine.WinchesterShotgunRTB_Inherits() || (doctrine.WinchesterShotgunRTB_Inherits() && flag2))
		{
			val["weapon_state_rtb"] = ((byte)doctrine.GetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WinchesterShotgunRTB_Inherits() && flag)
		{
			val["weapon_state_rtb_player_editable"] = doctrine.GetWinchesterShotgunRTB_PlayerEditable(scenario_0);
		}
		if (!doctrine.GunStrafing_Inherits() || (doctrine.GunStrafing_Inherits() && flag2))
		{
			val["gun_strafing"] = ((byte)doctrine.GetGunStrafing(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.GunStrafing_Inherits() && flag)
		{
			val["gun_strafing_player_editable"] = doctrine.GetGunStrafing_PlayerEditable(scenario_0);
		}
		if (!doctrine.JettisonOrdnance_Inherits() || (doctrine.JettisonOrdnance_Inherits() && flag2))
		{
			val["jettison_ordnance"] = ((byte)doctrine.GetJettison(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.JettisonOrdnance_Inherits() && flag)
		{
			val["jettison_ordnance_player_editable"] = doctrine.GetJettisonOrdnance_PlayerEditable(scenario_0);
		}
		if (!doctrine.BVRLogic_Inherits() || (doctrine.BVRLogic_Inherits() && flag2))
		{
			val["bvr_logic"] = ((byte)doctrine.method_0(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.BVRLogic_Inherits() && flag)
		{
			val["bvr_logic_player_editable"] = doctrine.GetBVRLogic_PlayerEditable(scenario_0);
		}
		if (!doctrine.WinchesterShotgunRTB_Inherits() || (doctrine.WinchesterShotgunRTB_Inherits() && flag2))
		{
			val["rtb_when_winchester"] = ((byte)doctrine.GetWinchesterShotgunRTB(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WinchesterShotgunRTB_Inherits() && flag)
		{
			val["rtb_when_winchester_player_editable"] = doctrine.GetWinchesterShotgunRTB_PlayerEditable(scenario_0);
		}
		if (!doctrine.UseSAMsOnASuW_Inherits() || (doctrine.UseSAMsOnASuW_Inherits() && flag2))
		{
			val["use_sams_in_anti_surface_mode"] = ((byte)doctrine.GetUseSAMsOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.UseSAMsOnASuW_Inherits() && flag)
		{
			val["use_sams_in_anti_surface_mode_player_editable"] = doctrine.GetUseSAMsOnASuW_PlayerEditable(scenario_0);
		}
		if (!doctrine.UseWPMissileOnASuW_Inherits() || (doctrine.UseWPMissileOnASuW_Inherits() && flag2))
		{
			val["use_wp_missile_in_anti_surface_mode"] = ((byte)doctrine.GetUseWPMissileOnASuW(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.UseWPMissileOnASuW_Inherits() && flag)
		{
			val["use_wp_missile_in_anti_surface_mode_player_editable"] = doctrine.GetUseWPMissileOnASuW_PlayerEditable(scenario_0);
		}
		if (!doctrine.MaintainStandoff_Inherits() || (doctrine.MaintainStandoff_Inherits() && flag2))
		{
			val["maintain_standoff"] = ((byte)doctrine.GetMaintainStandoff(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.MaintainStandoff_Inherits() && flag)
		{
			val["maintain_standoff_player_editable"] = doctrine.GetMaintainStandoff_PlayerEditable(scenario_0);
		}
		if (!doctrine.AvoidContact_Inherits() || (doctrine.AvoidContact_Inherits() && flag2))
		{
			val["avoid_contact"] = ((byte)doctrine.GetAvoidContact(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.AvoidContact_Inherits() && flag)
		{
			val["avoid_contact_player_editable"] = doctrine.GetAvoidContact_PlayerEditable(scenario_0);
		}
		if (!doctrine.DiveWhenThreatsDetected_Inherits() || (doctrine.DiveWhenThreatsDetected_Inherits() && flag2))
		{
			val["dive_on_threat"] = ((byte)doctrine.GetDiveWhenThreatsDetected(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.DiveWhenThreatsDetected_Inherits() && flag)
		{
			val["dive_on_threat_player_editable"] = doctrine.GetDiveWhenThreatsDetected_PlayerEditable(scenario_0);
		}
		if (!doctrine.RechargePercentagePatrol_Inherits() || (doctrine.RechargePercentagePatrol_Inherits() && flag2))
		{
			val["recharge_on_patrol"] = ((int)doctrine.GetRechargePercentagePatrol(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.RechargePercentagePatrol_Inherits() && flag)
		{
			val["recharge_on_patrol_player_editable"] = doctrine.GetRechargePercentagePatrol_PlayerEditable(scenario_0);
		}
		if (!doctrine.RechargePercentageAttack_Inherits() || (doctrine.RechargePercentageAttack_Inherits() && flag2))
		{
			val["recharge_on_attack"] = ((int)doctrine.GetRechargePercentageAttack(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.RechargePercentageAttack_Inherits() && flag)
		{
			val["recharge_on_attack_player_editable"] = doctrine.GetRechargePercentageAttack_PlayerEditable(scenario_0);
		}
		if (!doctrine.AIPUsage_Inherits() || (doctrine.AIPUsage_Inherits() && flag2))
		{
			val["use_aip"] = ((byte)doctrine.method_2(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.AIPUsage_Inherits() && flag)
		{
			val["use_aip_player_editable"] = doctrine.GetAIPUsage_PlayerEditable(scenario_0);
		}
		if (!doctrine.DippingSonar_Inherits() || (doctrine.DippingSonar_Inherits() && flag2))
		{
			val["dipping_sonar"] = ((byte)doctrine.GetDippingSonar(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.DippingSonar_Inherits() && flag)
		{
			val["dipping_sonar_player_editable"] = doctrine.GetDippingSonar_PlayerEditable(scenario_0);
		}
		if (!doctrine.WithdrawDamageThreshold_Inherits() || (doctrine.WithdrawDamageThreshold_Inherits() && flag2))
		{
			val["withdraw_on_damage"] = ((int)doctrine.GetWithdrawDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WithdrawFuelThreshold_Inherits() || (doctrine.WithdrawFuelThreshold_Inherits() && flag2))
		{
			val["withdraw_on_fuel"] = ((int)doctrine.GetWithdrawFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WithdrawAttackThreshold_Inherits() || (doctrine.WithdrawAttackThreshold_Inherits() && flag2))
		{
			val["withdraw_on_attack"] = ((int)doctrine.GetWithdrawAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.WithdrawDefenceThreshold_Inherits() || (doctrine.WithdrawDefenceThreshold_Inherits() && flag2))
		{
			val["withdraw_on_defence"] = ((int)doctrine.GetWithdrawDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.RedeployDamageThreshold_Inherits() || (doctrine.RedeployDamageThreshold_Inherits() && flag2))
		{
			val["deploy_on_damage"] = ((int)doctrine.GetRedeployDamageThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.RedeployFuelThreshold_Inherits() || (doctrine.RedeployFuelThreshold_Inherits() && flag2))
		{
			val["deploy_on_fuel"] = ((int)doctrine.GetRedeployFuelThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.RedeployAttackThreshold_Inherits() || (doctrine.RedeployAttackThreshold_Inherits() && flag2))
		{
			val["deploy_on_attack"] = ((int)doctrine.GetRedeployAttackThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.RedeployDefenceThreshold_Inherits() || (doctrine.RedeployDefenceThreshold_Inherits() && flag2))
		{
			val["deploy_on_defence"] = ((int)doctrine.GetRedeployDefenceThreshold(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.SurfaceNavigation_Inherits() || (doctrine.SurfaceNavigation_Inherits() && flag2))
		{
			val["navigation_surface"] = ((int)doctrine.GetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.SurfaceNavigation_Inherits() && flag)
		{
			val["navigation_surface_player_editable"] = doctrine.GetSurfaceNavigation_PlayerEditable(scenario_0);
		}
		if (!doctrine.SubmarineNavigation_Inherits() || (doctrine.SubmarineNavigation_Inherits() && flag2))
		{
			val["navigation_surface"] = ((int)doctrine.GetSurfaceNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.SubmarineNavigation_Inherits() && flag)
		{
			val["navigation_sub_surface_player_editable"] = doctrine.GetSubmarineNavigation_PlayerEditable(scenario_0);
		}
		if (!doctrine.LandNavigation_Inherits() || (doctrine.LandNavigation_Inherits() && flag2))
		{
			val["navigation_land"] = ((int)doctrine.GetLandNavigation(scenario_0, bool_0: false, bool_1: false, bool_2: false).Value).ToString();
		}
		if (!doctrine.LandNavigation_Inherits() && flag)
		{
			val["navigation_land_player_editable"] = doctrine.GetLandNavigation_PlayerEditable(scenario_0);
		}
		if (!doctrine.EMCON_Inherits || (doctrine.EMCON_Inherits && flag2))
		{
			LuaTable val2 = LuaSandBox.Singleton().CreateTable();
			val2["oecm"] = ((int)doctrine.NewRepository(scenario_0).OECM()).ToString();
			val2["radar"] = ((int)doctrine.NewRepository(scenario_0).LoginInterruptibleField()).ToString();
			val2["sonar"] = ((int)doctrine.NewRepository(scenario_0).GetInterruptibleField()).ToString();
			val["emcon"] = val2;
		}
		return val;
	}

	public static LuaTable ScenEdit_GetDoctrineWRA(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		ActiveUnit activeUnit = null;
		Doctrine doctrine = null;
		Side side = null;
		Contact contact_ = null;
		Weapon weapon_ = null;
		int num = -1;
		Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine._WRA_WeaponTargetType.None;
		string text = null;
		bool flag = false;
		LuaUtility.ParseUnitDict(ref dictionary);
		string Local_NameString = null;
		string text2 = null;
		if (dictionary.ContainsKey("GUID"))
		{
			string text3 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				activeUnit = scenario_0.ActiveUnits[text3];
				side = activeUnit.GetUnitSide();
				doctrine = activeUnit.Doctrine;
				text = "UNIT";
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("找不到攻击者'" + text3 + "'");
			}
		}
		else if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
		{
			if (dictionary.ContainsKey("MISSION"))
			{
				string Local_MissionString = Conversions.ToString(dictionary["MISSION"]);
				if (!dictionary.ContainsKey("SIDE"))
				{
					throw new LuaError("要选择任务，您需要定义一个分方。");
				}
				text2 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("找不到分方'" + text2 + "'");
				}
				try
				{
					Mission mission = side.Missions.FirstOrDefault((Mission s) => string.Equals(s.Name, Local_MissionString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_MissionString, StringComparison.OrdinalIgnoreCase));
					doctrine = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
					text = "MISSION";
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("找不到任务'" + Local_MissionString + "'");
				}
			}
			else if (dictionary.ContainsKey("SIDE"))
			{
				text2 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
					doctrine = side.Doctrine;
					text = "SIDE";
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("找不到分方'" + text2 + "'");
				}
			}
		}
		else
		{
			if (dictionary.ContainsKey("SIDE"))
			{
				text2 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("找不到分方'" + text2 + "'");
				}
			}
			if (dictionary.ContainsKey("NAME"))
			{
				Local_NameString = Conversions.ToString(dictionary["NAME"]);
			}
			if (dictionary.ContainsKey("UNITNAME"))
			{
				Local_NameString = Conversions.ToString(dictionary["UNITNAME"]);
			}
			if (side == null)
			{
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					if (string.Equals(activeUnits_.Name, Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, Local_NameString, StringComparison.OrdinalIgnoreCase))
					{
						activeUnit = activeUnits_;
						side = activeUnit.GetUnitSide();
						doctrine = activeUnit.Doctrine;
						break;
					}
				}
			}
			else
			{
				activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_NameString, StringComparison.OrdinalIgnoreCase));
				doctrine = activeUnit.Doctrine;
			}
			text = "UNIT";
		}
		if (dictionary.ContainsKey("CONTACT_ID"))
		{
			string text4 = Conversions.ToString(dictionary["CONTACT_ID"]);
			try
			{
				Scenario scenario_ = scenario_0;
				Side side_ = null;
				contact_ = LuaUtility.ValidAsContact(text4, scenario_, ref side_);
			}
			catch (Exception projectError6)
			{
				ProjectData.SetProjectError(projectError6);
				throw new LuaError("找不到目标'" + text4 + "'");
			}
		}
		else if (dictionary.ContainsKey("TARGET_TYPE"))
		{
			string text5 = Conversions.ToString(dictionary["TARGET_TYPE"]);
			try
			{
				if (!(Enum.TryParse<Doctrine._WRA_WeaponTargetType>(text5, ignoreCase: true, out var result) & Enum.IsDefined(typeof(Doctrine._WRA_WeaponTargetType), result)))
				{
					throw new LuaError("找不到目标类型'" + text5 + "'");
				}
				wRA_WeaponTargetType = result;
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				throw new LuaError("找不到目标类型'" + text5 + "'");
			}
		}
		if (!dictionary.ContainsKey("WEAPON_ID") && !dictionary.ContainsKey("WEAPON_DBID"))
		{
			if (dictionary.ContainsKey("WEAPON_TYPE"))
			{
				try
				{
					Weapon._WeaponType weaponType = Weapon._WeaponType.None;
					if (dictionary.ContainsKey("WEAPON_TYPE"))
					{
						weaponType = (Weapon._WeaponType)Conversions.ToShort(dictionary["WEAPON_TYPE"]);
					}
					if (activeUnit != null)
					{
						foreach (Mount mount in activeUnit.Mounts)
						{
							if (mount.Status == PlatformComponent._ComponentStatus.Destroyed)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon in mount.MountWeapons)
							{
								if (mountWeapon.PatchDescriptor(scenario_0) == weaponType)
								{
									num = mountWeapon.int_0;
									weapon_ = mountWeapon.GetReferenceWeapon(scenario_0);
									break;
								}
							}
							if (num == -1)
							{
								continue;
							}
							break;
						}
						if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Loadout != null)
						{
							WeaponRec[] weapons2 = ((Aircraft)activeUnit).Loadout.Weapons;
							WeaponRec[] array2 = weapons2;
							foreach (WeaponRec weaponRec in array2)
							{
								if (weaponRec.PatchDescriptor(scenario_0) == weaponType)
								{
									num = weaponRec.int_0;
									weapon_ = weaponRec.GetReferenceWeapon(scenario_0);
									break;
								}
							}
						}
					}
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					throw new LuaError("找不到武器");
				}
			}
		}
		else
		{
			try
			{
				int num12 = 0;
				if (dictionary.ContainsKey("WEAPON_ID"))
				{
					num12 = Conversions.ToInteger(dictionary["WEAPON_ID"]);
				}
				if (dictionary.ContainsKey("WEAPON_DBID"))
				{
					num12 = Conversions.ToInteger(dictionary["WEAPON_DBID"]);
				}
				if (activeUnit == null)
				{
					num = num12;
					if (!scenario_0.Cache_Weapons.TryGetValue(num, out weapon_))
					{
						DataRow[] array = null;
						Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, num, bool_0: false);
						array = scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(num));
						if (array != null && array.Count() > 0)
						{
							DBFunctions.GetWeapon(scenario_0.DBConnection, newWeapon, num, scenario_0);
							weapon_ = newWeapon;
						}
						else
						{
							num = -1;
						}
					}
					if (num == -1)
					{
						throw new LuaError("没有匹配武器" + Conversions.ToString(num12));
					}
				}
				else
				{
					foreach (Mount mount2 in activeUnit.Mounts)
					{
						if (mount2.Status == PlatformComponent._ComponentStatus.Destroyed)
						{
							continue;
						}
						foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
						{
							if (mountWeapon2.int_0 == num12)
							{
								num = num12;
								weapon_ = mountWeapon2.GetReferenceWeapon(scenario_0);
								break;
							}
						}
						if (num == -1)
						{
							continue;
						}
						break;
					}
					if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)activeUnit).Loadout.Weapons;
						WeaponRec[] array3 = weapons;
						foreach (WeaponRec weaponRec2 in array3)
						{
							if (weaponRec2.int_0 == num12)
							{
								num = num12;
								weapon_ = weaponRec2.GetReferenceWeapon(scenario_0);
								break;
							}
						}
					}
				}
			}
			catch (Exception projectError9)
			{
				ProjectData.SetProjectError(projectError9);
				throw new LuaError("找不到武器");
			}
		}
		if (doctrine == null)
		{
			throw new LuaError("单元没有设置条令。");
		}
		if (dictionary.ContainsKey("FULL_WRA"))
		{
			flag = true;
		}
		LuaTable val = LuaSandBox.Singleton().CreateTable();
		if (!flag && wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && contact_ == null)
		{
			return null;
		}
		if (wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && contact_ != null)
		{
			bool? nullable_ = null;
			Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_, ref nullable_);
			wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref contact_, ref _WRA_WeaponTargetType_, side.ObjectID);
		}
		if (!wRA_WeaponTargetType.Equals(Doctrine._WRA_WeaponTargetType.None))
		{
			if (weapon_ == null)
			{
				Dictionary<int, Weapon> dictionary2 = new Dictionary<int, Weapon>();
				if (activeUnit != null)
				{
					foreach (Mount mount3 in activeUnit.Mounts)
					{
						if (mount3.Status == PlatformComponent._ComponentStatus.Destroyed)
						{
							continue;
						}
						foreach (WeaponRec mountWeapon3 in mount3.MountWeapons)
						{
							weapon_ = mountWeapon3.GetReferenceWeapon(scenario_0);
							if (!dictionary2.ContainsKey(weapon_.DBID))
							{
								dictionary2.Add(weapon_.DBID, weapon_);
							}
						}
					}
					if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Loadout != null)
					{
						WeaponRec[] weapons3 = ((Aircraft)activeUnit).Loadout.Weapons;
						for (int i = 0; i < weapons3.Length; i = checked(i + 1))
						{
							weapon_ = weapons3[i].GetReferenceWeapon(scenario_0);
							if (!dictionary2.ContainsKey(weapon_.DBID))
							{
								dictionary2.Add(weapon_.DBID, weapon_);
							}
						}
					}
					int num15 = 1;
					foreach (KeyValuePair<int, Weapon> item in dictionary2)
					{
						Weapon weapon_2 = item.Value;
						if (!doctrine.InsertRepository(ref weapon_2))
						{
							continue;
						}
						int? num16 = Doctrine.WRA_WeaponQty_CurrentTargetType(doctrine, weapon_2.ParentScen, weapon_2, wRA_WeaponTargetType);
						int? num17 = Doctrine.WRA_ShooterQty_CurrentTargetType(doctrine, weapon_2.ParentScen, weapon_2, wRA_WeaponTargetType);
						float? num18 = doctrine.SearchRepository(doctrine, weapon_2.ParentScen, weapon_2.DBID, wRA_WeaponTargetType);
						float? num19 = Doctrine.WRA_SelfDefenceRange_CurrentTargetType(doctrine, weapon_2.ParentScen, weapon_2, wRA_WeaponTargetType);
						if (!num16.HasValue && !num17.HasValue && !num18.HasValue && !num19.HasValue)
						{
							continue;
						}
						LuaTable val2 = LuaSandBox.Singleton().CreateTable();
						if (num16.HasValue)
						{
							int? num20 = num16;
							if ((num20.HasValue ? new bool?(num20.GetValueOrDefault() == 0) : null).GetValueOrDefault())
							{
								val2["QTY_SALVO"] = "DoNotUse";
							}
							else
							{
								num20 = num16;
								if ((num20.HasValue ? new bool?(num20.GetValueOrDefault() == -99) : null).GetValueOrDefault())
								{
									val2["QTY_SALVO"] = "Max";
								}
								else
								{
									val2["QTY_SALVO"] = num16;
								}
							}
						}
						if (num17.HasValue)
						{
							int? num21 = num17;
							if ((num21.HasValue ? new bool?(num21.GetValueOrDefault() == -99) : null).GetValueOrDefault())
							{
								val2["SHOOTER_SALVO"] = "Max";
							}
							else
							{
								val2["SHOOTER_SALVO"] = num17;
							}
						}
						if (num17.HasValue & num16.HasValue)
						{
							if (num18.HasValue)
							{
								float? num2 = num18;
								if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
								{
									val2["FIRING_RANGE"] = "Max";
								}
								else
								{
									num2 = num18;
									if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
									{
										val2["FIRING_RANGE"] = "DoNotUse";
									}
									else
									{
										num2 = num18;
										if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -95f) : null).GetValueOrDefault())
										{
											val2["FIRING_RANGE"] = "25OfMax";
										}
										else
										{
											num2 = num18;
											if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -96f) : null).GetValueOrDefault())
											{
												val2["FIRING_RANGE"] = "50OfMax";
											}
											else
											{
												num2 = num18;
												if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -97f) : null).GetValueOrDefault())
												{
													val2["FIRING_RANGE"] = "75OfMax";
												}
												else
												{
													num2 = num18;
													if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
													{
														val2["FIRING_RANGE"] = "NEZ";
													}
													else
													{
														val2["FIRING_RANGE"] = num18;
													}
												}
											}
										}
									}
								}
							}
							else
							{
								float? num3 = Doctrine.WRA_FiringRange_GetDefaultFiringRange(weapon_2.ParentScen, weapon_2.DBID, wRA_WeaponTargetType);
								if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
								{
									val2["FIRING_RANGE"] = "NEZ";
								}
								else
								{
									val2["FIRING_RANGE"] = "Max";
								}
							}
						}
						if (num19.HasValue)
						{
							float? num4 = num19;
							if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
							{
								val2["SELF_DEFENCE"] = "DoNotUse";
							}
							else
							{
								num4 = num19;
								if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
								{
									val2["SELF_DEFENCE"] = "Max";
								}
								else
								{
									val2["SELF_DEFENCE"] = num19;
								}
							}
						}
						if (val2.Keys.Count > 0)
						{
							val2["WEAPON_DBID"] = weapon_2.DBID;
							val2["WEAPON_NAME"] = weapon_2.Name;
							val["TARGET_TYPE"] = wRA_WeaponTargetType;
							val["LEVEL"] = text;
							val["WRA_" + Conversions.ToString(num15)] = val2;
							num15++;
						}
					}
				}
			}
			else if (doctrine.InsertRepository(ref weapon_))
			{
				int? num5 = Doctrine.WRA_WeaponQty_CurrentTargetType(doctrine, weapon_.ParentScen, weapon_, wRA_WeaponTargetType);
				int? num6 = Doctrine.WRA_ShooterQty_CurrentTargetType(doctrine, weapon_.ParentScen, weapon_, wRA_WeaponTargetType);
				float? num7 = doctrine.SearchRepository(doctrine, weapon_.ParentScen, weapon_.DBID, wRA_WeaponTargetType);
				float? num8 = Doctrine.WRA_SelfDefenceRange_CurrentTargetType(doctrine, weapon_.ParentScen, weapon_, wRA_WeaponTargetType);
				val["WEAPON_DBID"] = weapon_.DBID;
				val["WEAPON_NAME"] = weapon_.Name;
				val["TARGET_TYPE"] = wRA_WeaponTargetType;
				val["LEVEL"] = text;
				LuaTable val3 = LuaSandBox.Singleton().CreateTable();
				if (num5.HasValue)
				{
					int? num9 = num5;
					if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						val3["QTY_SALVO"] = "DoNotUse";
					}
					else
					{
						num9 = num5;
						if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == -99) : null).GetValueOrDefault())
						{
							val3["QTY_SALVO"] = "Max";
						}
						else
						{
							val3["QTY_SALVO"] = num5;
						}
					}
				}
				if (num6.HasValue)
				{
					int? num10 = num6;
					if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == -99) : null).GetValueOrDefault())
					{
						val3["SHOOTER_SALVO"] = "Max";
					}
					else
					{
						val3["SHOOTER_SALVO"] = num6;
					}
				}
				if (num6.HasValue & num5.HasValue)
				{
					if (num7.HasValue)
					{
						float? num11 = num7;
						if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
						{
							val3["FIRING_RANGE"] = "Max";
						}
						else
						{
							num11 = num7;
							if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
							{
								val3["FIRING_RANGE"] = "DoNotUse";
							}
							else
							{
								num11 = num7;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -95f) : null).GetValueOrDefault())
								{
									val3["FIRING_RANGE"] = "25OfMax";
								}
								else
								{
									num11 = num7;
									if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -96f) : null).GetValueOrDefault())
									{
										val3["FIRING_RANGE"] = "50OfMax";
									}
									else
									{
										num11 = num7;
										if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -97f) : null).GetValueOrDefault())
										{
											val3["FIRING_RANGE"] = "75OfMax";
										}
										else
										{
											num11 = num7;
											if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
											{
												val3["FIRING_RANGE"] = "NEZ";
											}
											else
											{
												val3["FIRING_RANGE"] = num7;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						float? num13 = Doctrine.WRA_FiringRange_GetDefaultFiringRange(weapon_.ParentScen, weapon_.DBID, wRA_WeaponTargetType);
						if ((num13.HasValue ? new bool?(num13.GetValueOrDefault() == -102f) : null).GetValueOrDefault())
						{
							val3["FIRING_RANGE"] = "NEZ";
						}
						else
						{
							val3["FIRING_RANGE"] = "Max";
						}
					}
				}
				if (num8.HasValue)
				{
					float? num14 = num8;
					if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
					{
						val3["SELF_DEFENCE"] = "DoNotUse";
					}
					else
					{
						num14 = num8;
						if ((num14.HasValue ? new bool?(num14.GetValueOrDefault() == -99f) : null).GetValueOrDefault())
						{
							val3["SELF_DEFENCE"] = "Max";
						}
						else
						{
							val3["SELF_DEFENCE"] = num8;
						}
					}
				}
				if (val3.Keys.Count > 0)
				{
					val["WRA"] = val3;
				}
			}
		}
		return val;
	}

	public static LuaTable ScenEdit_SetDoctrineWRA(LuaTable luaTable_0, LuaTable luaTable_1, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Doctrine doctrine = null;
		ActiveUnit activeUnit = null;
		Mission mission = null;
		Side side = null;
		Contact contact_ = null;
		Weapon weapon_ = null;
		int num = -1;
		Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine._WRA_WeaponTargetType.None;
		bool flag = false;
		string text = "SIDE";
		LuaUtility.ParseUnitDict(ref dictionary);
		string Local_NameString = null;
		string text4 = null;
		if (dictionary.ContainsKey("GUID"))
		{
			string text5 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				activeUnit = scenario_0.ActiveUnits[text5];
				side = activeUnit.GetUnitSide();
				doctrine = activeUnit.Doctrine;
				text = "UNIT";
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Can't find unit '" + text5 + "'");
			}
		}
		else if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
		{
			if (dictionary.ContainsKey("MISSION"))
			{
				string Local_MissionString = Conversions.ToString(dictionary["MISSION"]);
				if (!dictionary.ContainsKey("SIDE"))
				{
					throw new LuaError("要选择任务，您需要定义一个分方。");
				}
				text4 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("找不到分方'" + text4 + "'");
				}
				try
				{
					mission = side.Missions.FirstOrDefault((Mission s) => string.Equals(s.Name, Local_MissionString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_MissionString, StringComparison.OrdinalIgnoreCase));
					doctrine = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
					text = "MISSION";
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("找不到任务'" + Local_MissionString + "'");
				}
			}
			else if (dictionary.ContainsKey("SIDE"))
			{
				text4 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
					doctrine = side.Doctrine;
					text = "SIDE";
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("找不到分方'" + text4 + "'");
				}
				flag = true;
			}
		}
		else
		{
			if (dictionary.ContainsKey("SIDE"))
			{
				text4 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("找不到分方'" + text4 + "'");
				}
			}
			if (dictionary.ContainsKey("NAME"))
			{
				Local_NameString = Conversions.ToString(dictionary["NAME"]);
			}
			if (dictionary.ContainsKey("UNITNAME"))
			{
				Local_NameString = Conversions.ToString(dictionary["UNITNAME"]);
			}
			if (side == null)
			{
				foreach (ActiveUnit activeUnits_ in scenario_0.ActiveUnits_List)
				{
					if (string.Equals(activeUnits_.Name, Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, Local_NameString, StringComparison.OrdinalIgnoreCase))
					{
						activeUnit = activeUnits_;
						side = activeUnit.GetUnitSide();
						doctrine = activeUnit.Doctrine;
						break;
					}
				}
			}
			else
			{
				activeUnit = side.Units.First((ActiveUnit s) => string.Equals(s.Name, Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, Local_NameString, StringComparison.OrdinalIgnoreCase));
				doctrine = activeUnit.Doctrine;
			}
			if (activeUnit == null)
			{
				throw new LuaError("Can't find unit '" + Local_NameString + "'");
			}
			text = "UNIT";
		}
		dictionary["LEVEL"] = text;
		if (dictionary.ContainsKey("CONTACT_ID"))
		{
			string text6 = Conversions.ToString(dictionary["CONTACT_ID"]);
			try
			{
				Scenario scenario_ = scenario_0;
				Side side_ = null;
				contact_ = LuaUtility.ValidAsContact(text6, scenario_, ref side_);
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				throw new LuaError("找不到目标'" + text6 + "'");
			}
		}
		else if (dictionary.ContainsKey("TARGET_TYPE"))
		{
			string text7 = Conversions.ToString(dictionary["TARGET_TYPE"]);
			try
			{
				if (!(Enum.TryParse<Doctrine._WRA_WeaponTargetType>(text7, ignoreCase: true, out var result) & Enum.IsDefined(typeof(Doctrine._WRA_WeaponTargetType), result)))
				{
					throw new LuaError("找不到目标类型'" + text7 + "'");
				}
				wRA_WeaponTargetType = result;
			}
			catch (Exception projectError8)
			{
				ProjectData.SetProjectError(projectError8);
				throw new LuaError("找不到目标类型'" + text7 + "'");
			}
		}
		if (dictionary.ContainsKey("WEAPON_ID") || dictionary.ContainsKey("WEAPON_DBID"))
		{
			try
			{
				int num2 = 0;
				if (dictionary.ContainsKey("WEAPON_ID"))
				{
					num2 = Conversions.ToInteger(dictionary["WEAPON_ID"]);
				}
				if (dictionary.ContainsKey("WEAPON_DBID"))
				{
					num2 = Conversions.ToInteger(dictionary["WEAPON_DBID"]);
				}
				if (Operators.CompareString(text, "UNIT", TextCompare: false) == 0)
				{
					foreach (Mount mount in activeUnit.Mounts)
					{
						if (mount.Status == PlatformComponent._ComponentStatus.Destroyed)
						{
							continue;
						}
						foreach (WeaponRec mountWeapon in mount.MountWeapons)
						{
							if (mountWeapon.int_0 == num2)
							{
								num = num2;
								weapon_ = mountWeapon.GetReferenceWeapon(scenario_0);
								break;
							}
						}
						if (num == -1)
						{
							continue;
						}
						break;
					}
					if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)activeUnit).Loadout.Weapons;
						WeaponRec[] array = weapons;
						foreach (WeaponRec weaponRec in array)
						{
							if (weaponRec.int_0 == num2)
							{
								num = num2;
								weapon_ = weaponRec.GetReferenceWeapon(scenario_0);
								break;
							}
						}
					}
				}
				else
				{
					num = num2;
					if (weapon_ == null)
					{
						weapon_ = new Weapon(ref scenario_0);
						DBFunctions.GetWeapon(scenario_0.DBConnection, weapon_, num, scenario_0);
					}
				}
				if (num == -1)
				{
					throw new LuaError("没有匹配武器" + Conversions.ToString(num2));
				}
			}
			catch (Exception projectError9)
			{
				ProjectData.SetProjectError(projectError9);
				throw new LuaError("找不到武器");
			}
		}
		if (doctrine == null)
		{
			throw new LuaError("单元没有设置条令。");
		}
		doctrine.ScenarioContext = scenario_0;
		if (wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && contact_ == null)
		{
			return null;
		}
		bool? nullable_ = null;
		if (wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && contact_ != null)
		{
			Doctrine._WRA_WeaponTargetType _WRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_, ref nullable_);
			wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref weapon_, ref contact_, ref _WRA_WeaponTargetType_, side.ObjectID);
		}
		Dictionary<int, Doctrine.WRA_Weapon> dictionary2 = doctrine.WRA;
		Dictionary<string, object> dictionary3 = LuaUtility.ToDictLower(luaTable_1.GetEnumerator());
		if (dictionary3.Count == 4)
		{
			string text8;
			string text9;
			string text10;
			string text11;
			try
			{
				text8 = Conversions.ToString(dictionary3["1"]);
				text9 = Conversions.ToString(dictionary3["2"]);
				text10 = Conversions.ToString(dictionary3["3"]);
				text11 = Conversions.ToString(dictionary3["4"]);
			}
			catch (Exception projectError10)
			{
				ProjectData.SetProjectError(projectError10);
				throw new LuaError("无效的WRA表条目");
			}
			LuaSandBox.Singleton().CreateTable();
			Collection<Doctrine.WRA_FiringDoctrineEntry> collection = new Collection<Doctrine.WRA_FiringDoctrineEntry>();
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
			if (dictionary2 == null)
			{
				dictionary2 = new Dictionary<int, Doctrine.WRA_Weapon>();
			}
			if (!dictionary2.TryGetValue(num, out value))
			{
				dictionary2.Add(num, null);
			}
			dictionary2.TryGetValue(num, out value);
			if (value == null)
			{
				value = new Doctrine.WRA_Weapon();
				if (dictionary2.ContainsKey(num))
				{
					dictionary2[num] = value;
				}
			}
			if (weapon_ == null)
			{
				weapon_ = Weapon.GetNewWeapon(ref scenario_0, num, bool_0: false);
			}
			bool flag2 = false;
			Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = value.WRA_WeaponTargets;
			for (int i = 0; i < wRA_WeaponTargets.Length; i = checked(i + 1))
			{
				if (wRA_WeaponTargets[i].TargetType == wRA_WeaponTargetType)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				Doctrine.WRA_FiringDoctrineEntry theAC = new Doctrine.WRA_FiringDoctrineEntry(wRA_WeaponTargetType);
				ArrayExtensions.Add(ref value.WRA_WeaponTargets, theAC);
			}
			int? nullable_2 = null;
			int? nullable_3 = null;
			float? nullable_4 = null;
			float? nullable_5 = null;
			try
			{
				if (value.WRA_WeaponTargets != null)
				{
					Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets2 = value.WRA_WeaponTargets;
					Doctrine.WRA_FiringDoctrineEntry[] array2 = wRA_WeaponTargets2;
					foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array2)
					{
						if (wRA_FiringDoctrineEntry.TargetType != wRA_WeaponTargetType)
						{
							continue;
						}
						if (Operators.CompareString(text8.ToLower(), "inherit", TextCompare: false) == 0 && Operators.CompareString(text9.ToLower(), "inherit", TextCompare: false) == 0 && Operators.CompareString(text10.ToLower(), "inherit", TextCompare: false) == 0 && Operators.CompareString(text11.ToLower(), "inherit", TextCompare: false) == 0)
						{
							collection.Add(wRA_FiringDoctrineEntry);
							continue;
						}
						int result2;
						if (Operators.CompareString(text8.ToLower(), "inherit", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.WeaponQty = null;
						}
						else if (Operators.CompareString(text8.ToLower(), "system", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.WeaponQty = -1;
						}
						else if (Operators.CompareString(text8.ToLower(), "max", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.WeaponQty = -99;
						}
						else if (Operators.CompareString(text8.ToLower(), "none", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.WeaponQty = 0;
						}
						else if (int.TryParse(text8, out result2))
						{
							wRA_FiringDoctrineEntry.WeaponQty = result2;
						}
						nullable_2 = wRA_FiringDoctrineEntry.WeaponQty;
						int result3;
						if (Operators.CompareString(text9.ToLower(), "inherit", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.ShooterQty = null;
						}
						else if (Operators.CompareString(text9.ToLower(), "system", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.ShooterQty = -1;
						}
						else if (Operators.CompareString(text9.ToLower(), "max", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.ShooterQty = -99;
						}
						else if (int.TryParse(text9, out result3))
						{
							int value2 = validatShooterPerSalvo(result3, doctrine);
							wRA_FiringDoctrineEntry.ShooterQty = value2;
						}
						nullable_3 = wRA_FiringDoctrineEntry.ShooterQty;
						float result4;
						if (Operators.CompareString(text10.ToLower(), "inherit", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.FiringRange = null;
						}
						else if (Operators.CompareString(text10.ToLower(), "max", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.FiringRange = -99f;
						}
						else if (Operators.CompareString(text10.ToLower(), "25ofmax", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.FiringRange = -95f;
						}
						else if (Operators.CompareString(text10.ToLower(), "50ofmax", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.FiringRange = -96f;
						}
						else if (Operators.CompareString(text10.ToLower(), "75ofmax", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.FiringRange = -97f;
						}
						else if (Operators.CompareString(text10.ToLower(), "nez", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.FiringRange = -102f;
						}
						else if (Operators.CompareString(text10.ToLower(), "none", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.FiringRange = 0f;
						}
						else if (float.TryParse(text10, out result4))
						{
							float maxRange_NoTargetType = weapon_.MaxRange_NoTargetType;
							if (result4 < maxRange_NoTargetType)
							{
								float value3 = validateFiringRange(result4, doctrine);
								wRA_FiringDoctrineEntry.FiringRange = value3;
							}
							else
							{
								wRA_FiringDoctrineEntry.FiringRange = -99f;
							}
						}
						nullable_4 = wRA_FiringDoctrineEntry.FiringRange;
						float result5;
						if (Operators.CompareString(text11.ToLower(), "inherit", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.SelfDefenceRange = null;
						}
						else if (Operators.CompareString(text11.ToLower(), "system", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.SelfDefenceRange = -1f;
						}
						else if (Operators.CompareString(text11.ToLower(), "max", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.SelfDefenceRange = -99f;
						}
						else if (Operators.CompareString(text11.ToLower(), "none", TextCompare: false) == 0)
						{
							wRA_FiringDoctrineEntry.SelfDefenceRange = 0f;
						}
						else if (float.TryParse(text11, out result5))
						{
							float num3 = 15f;
							if (result5 < num3)
							{
								wRA_FiringDoctrineEntry.SelfDefenceRange = result5;
							}
							else
							{
								wRA_FiringDoctrineEntry.SelfDefenceRange = -99f;
							}
						}
						nullable_5 = wRA_FiringDoctrineEntry.SelfDefenceRange;
					}
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw new LuaError("无效的WRA值");
			}
			if (collection.Count > 0)
			{
				foreach (Doctrine.WRA_FiringDoctrineEntry item in collection)
				{
					ArrayExtensions.Remove(ref value.WRA_WeaponTargets, item);
				}
			}
			if (value.WRA_WeaponTargets.Count() == 0)
			{
				value.WRA_WeaponTargets = null;
			}
			if (value.WRA_WeaponTargets == null)
			{
				dictionary2.Remove(num);
			}
			if (dictionary2 == null || dictionary2.Count == 0)
			{
				dictionary2 = null;
			}
			doctrine.WRA = dictionary2;
			LuaTable luaTable_2 = LuaSandBox.Singleton().CreateTable();
			LuaUtility.FromDict(dictionary, luaTable_2);
			string text2 = "";
			Side side_2 = null;
			if (activeUnit == null)
			{
				if (mission == null)
				{
					if (side != null)
					{
						text2 = "分方" + side.Name;
						side_2 = side;
					}
				}
				else
				{
					text2 = "任务" + mission.Name;
					side_2 = side;
				}
			}
			else
			{
				text2 = "单元" + activeUnit.Name;
				side_2 = activeUnit.GetUnitSide();
			}
			text2 = text2 + " Doctrine/ROE Change: WRA for weapon #" + Conversions.ToString(num);
			if (weapon_ != null)
			{
				text2 = text2 + " (" + weapon_.Name + ")";
			}
			if (contact_ != null)
			{
				text2 = text2 + " vs " + Doctrine.WRA_TargetType_String(Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_), nullable_.Value) + " is now set to";
			}
			if (dictionary2 == null)
			{
				text2 = (flag ? (text2 + " default for all fields.") : (text2 + " inherit for all fields."));
			}
			else
			{
				string text3 = "'inherit'";
				if (flag)
				{
					text3 = "'default'";
				}
				text2 += ": Weapons per Salvo = ";
				text2 = (nullable_2.HasValue ? (text2 + Doctrine.WRA_WeaponQty_String(nullable_2, activeUnit, contact_, weapon_)) : (text2 + text3));
				text2 += ", Shooters per Salvo = ";
				text2 = (nullable_3.HasValue ? (text2 + Doctrine.WRA_ShooterQtyString(nullable_3, bool_0: false)) : (text2 + text3));
				text2 += ", Automatic Firing Range = ";
				text2 = (nullable_4.HasValue ? (text2 + doctrine.UpdateRepository(nullable_4, bool_0: false)) : (text2 + text3));
				text2 += ", Self Defence Range = ";
				text2 = (nullable_5.HasValue ? (text2 + doctrine.DisableRepository(nullable_5, bool_0: false)) : (text2 + text3));
			}
			Geopoint_Struct geopoint_Struct_ = default(Geopoint_Struct);
			if (activeUnit != null)
			{
				geopoint_Struct_ = new Geopoint_Struct(activeUnit.GetLongitude(), activeUnit.GetLatitude(), activeUnit.GetCurrentAltitude());
			}
			scenario_0.AddMessage(text2, "Doctrine/ROE changed", LoggedMessage.MessageType.const_23, 0, null, side_2, geopoint_Struct_);
			return ScenEdit_GetDoctrineWRA(luaTable_0, scenario_0);
		}
		throw new LuaError("按顺序需要4个值：每个齐射的武器，每个齐射的射击者，射程，自卫范围");
	}

	public static float validateFiringRange(float float_0, Doctrine doctrine_0)
	{
		float result = 0f;
		if (float_0 > 0f && float_0 <= 2000f)
		{
			result = float_0;
		}
		return result;
	}

	public static int validatShooterPerSalvo(int int_0, Doctrine doctrine_0)
	{
		int result = 0;
		if (int_0 != 1)
		{
			if ((uint)(int_0 - 2) > 1u)
			{
				if (int_0 == 4)
				{
					return 4;
				}
				if (int_0 <= 4)
				{
					return result;
				}
				return -99;
			}
			return 2;
		}
		return 1;
	}

	public static string ScenEdit_ExportDoctrineToXML(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Doctrine doctrine_ = null;
		Side side = null;
		string text4 = "SideDoctrine";
		if (!dictionary.ContainsKey("SIDE") && !dictionary.ContainsKey("GUID") && !dictionary.ContainsKey("MISSION"))
		{
			dictionary.Add("SIDE", "playerside");
		}
		if (dictionary.ContainsKey("FILENAME"))
		{
			text4 = Conversions.ToString(dictionary["FILENAME"]);
		}
		if (dictionary.ContainsKey("GUID"))
		{
			string text5 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doctrine_ = scenario_0.ActiveUnits[text5].Doctrine;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("找不到guid'" + text5 + "'");
			}
		}
		else if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
		{
			if (dictionary.ContainsKey("MISSION"))
			{
				string text3 = Conversions.ToString(dictionary["MISSION"]);
				if (!dictionary.ContainsKey("SIDE"))
				{
					throw new LuaError("要选择任务，您需要定义一个分方。");
				}
				string text6 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("找不到分方'" + text6 + "'");
				}
				try
				{
					Mission mission = side.Missions.FirstOrDefault((Mission s) => string.Equals(s.Name, text3, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text3, StringComparison.OrdinalIgnoreCase));
					doctrine_ = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("找不到任务'" + text3 + "'");
				}
			}
			else if (dictionary.ContainsKey("SIDE"))
			{
				string text7 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
					doctrine_ = side.Doctrine;
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("找不到分方'" + text7 + "'");
				}
			}
		}
		else
		{
			string text2 = null;
			if (dictionary.ContainsKey("NAME"))
			{
				text2 = Conversions.ToString(dictionary["NAME"]);
			}
			else if (dictionary.ContainsKey("UNITNAME"))
			{
				text2 = Conversions.ToString(dictionary["UNITNAME"]);
			}
			if (dictionary.ContainsKey("SIDE"))
			{
				string text8 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("找不到分方'" + text8 + "'");
				}
				try
				{
					doctrine_ = side.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("找不到单元'" + text2 + "' 分方 '" + text8 + "'");
				}
			}
			else
			{
				try
				{
					doctrine_ = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					throw new LuaError("找不到单元'" + text2 + "'");
				}
			}
		}
		if (doctrine_ == null)
		{
			throw new LuaError("需要定义一个guid，一个名字，一个分方和名称，一个分方和任务，或者只是一个分方。");
		}
		if (!Directory.Exists(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults"))
		{
			Directory.CreateDirectory(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults");
		}
		FileStream fileStream = File.Create(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults" + Conversions.ToString(Path.DirectorySeparatorChar) + text4 + ".xml");
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		MemoryStream memoryStream_ = memoryStream;
		string result = ToXML_Private(ref doctrine_, ref memoryStream_, ref scenario_0);
		if (memoryStream.Position > 0)
		{
			fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
		}
		fileStream.Close();
		return result;
	}

	public static string ScenEdit_ImportDoctrineFromXML(LuaTable luaTable_0, Scenario scenario_0)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(luaTable_0.GetEnumerator());
		Doctrine doctrine_ = null;
		Side side = null;
		string text4 = "SideDoctrine";
		if (!dictionary.ContainsKey("SIDE") && !dictionary.ContainsKey("GUID") && !dictionary.ContainsKey("MISSION"))
		{
			dictionary.Add("SIDE", "playerside");
		}
		if (dictionary.ContainsKey("FILENAME"))
		{
			text4 = Conversions.ToString(dictionary["FILENAME"]);
		}
		if (dictionary.ContainsKey("GUID"))
		{
			string text5 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doctrine_ = scenario_0.ActiveUnits[text5].Doctrine;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("找不到guid'" + text5 + "'");
			}
		}
		else if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
		{
			if (dictionary.ContainsKey("MISSION"))
			{
				string text2 = Conversions.ToString(dictionary["MISSION"]);
				if (!dictionary.ContainsKey("SIDE"))
				{
					throw new LuaError("要选择任务，您需要定义一个分方。");
				}
				string text6 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("找不到分方'" + text6 + "'");
				}
				try
				{
					Mission mission = side.Missions.FirstOrDefault((Mission s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
					doctrine_ = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("找不到任务'" + text2 + "'");
				}
			}
			else if (dictionary.ContainsKey("SIDE"))
			{
				string text7 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
					doctrine_ = side.Doctrine;
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("找不到分方'" + text7 + "'");
				}
			}
		}
		else
		{
			string text3 = null;
			if (dictionary.ContainsKey("NAME"))
			{
				text3 = Conversions.ToString(dictionary["NAME"]);
			}
			else if (dictionary.ContainsKey("UNITNAME"))
			{
				text3 = Conversions.ToString(dictionary["UNITNAME"]);
			}
			if (dictionary.ContainsKey("SIDE"))
			{
				string text8 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, scenario_0);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("找不到分方'" + text8 + "'");
				}
				try
				{
					doctrine_ = side.Units.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, text3, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("找不到单元'" + text3 + "' 分方 '" + text8 + "'");
				}
			}
			else
			{
				try
				{
					doctrine_ = scenario_0.ActiveUnits_List.FirstOrDefault((ActiveUnit s) => string.Equals(s.Name, text3, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					throw new LuaError("找不到单元'" + text3 + "'");
				}
			}
		}
		if (doctrine_ == null)
		{
			throw new LuaError("需要定义一个guid，一个名字，一个分方和名称，一个分方和任务，或者只是一个分方。");
		}
		if (!Directory.Exists(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults"))
		{
			Directory.CreateDirectory(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults");
		}
		object object_ = doctrine_.Subject;
		string string_ = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults" + Conversions.ToString(Path.DirectorySeparatorChar) + text4 + ".xml";
		return FromXML_Private(ref object_, ref string_, ref doctrine_, ref scenario_0);
	}

	public static string ToXML_Private(ref Doctrine doctrine_0, ref MemoryStream memoryStream_0, ref Scenario scenario_0)
	{
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		XmlWriter xmlWriter_ = XmlWriter.Create(memoryStream_0, xmlWriterSettings);
		doctrine_0.ToXML(ref xmlWriter_, ref scenario_0);
		xmlWriter_.Flush();
		string xml = Misc.AssetRequest(memoryStream_0);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		List<XmlNode> list = new List<XmlNode>();
		xmlDocument.SelectSingleNode("/Doctrine");
		XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("type");
		xmlAttribute.Value = doctrine_0.SubjectType.Name.ToString();
		xmlDocument.DocumentElement.SetAttributeNode(xmlAttribute);
		smethod_0();
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlDocument.ChildNodes.GetEnumerator();
			IEnumerator enumerator2 = null;
			IEnumerator enumerator3 = null;
			IEnumerator enumerator4 = null;
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				if (Operators.CompareString(xmlNode.LocalName, "Doctrine", TextCompare: false) != 0)
				{
					continue;
				}
				try
				{
					enumerator2 = xmlNode.ChildNodes.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
						if (xmlNode2.Name.EndsWith("_Player"))
						{
							list.Add(xmlNode2);
						}
						else if (dictionary_1.ContainsKey(xmlNode2.Name))
						{
							string name = dictionary_1[xmlNode2.Name];
							string text = dictionary_2[xmlNode2.Name];
							if (text.Length > 0)
							{
								XmlComment newChild = xmlDocument.CreateComment(" " + text + " ");
								xmlNode.InsertBefore(newChild, xmlNode2);
							}
							XmlElement xmlElement = xmlDocument.CreateElement(name);
							xmlElement.InnerXml = xmlNode2.InnerXml;
							xmlDocument.DocumentElement.InsertBefore(xmlElement, xmlNode2);
							list.Add(xmlNode2);
						}
						else
						{
							if (Operators.CompareString(xmlNode2.Name, "WRA", TextCompare: false) != 0)
							{
								continue;
							}
							try
							{
								enumerator3 = xmlNode2.ChildNodes.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									XmlNode xmlNode3 = (XmlNode)enumerator3.Current;
									if (!xmlNode3.Name.StartsWith("武器_"))
									{
										continue;
									}
									int int_ = Conversions.ToInteger(xmlNode3.Name.Split('_')[1]);
									Weapon weapon = new Weapon(ref scenario_0);
									DBFunctions.GetWeapon(scenario_0.DBConnection, weapon, int_, scenario_0, bool_0: false);
									XmlComment newChild2 = xmlDocument.CreateComment(weapon.Name);
									xmlNode2.InsertBefore(newChild2, xmlNode3);
									try
									{
										enumerator4 = xmlNode3.ChildNodes.GetEnumerator();
										while (enumerator4.MoveNext())
										{
											XmlNode xmlNode4 = (XmlNode)enumerator4.Current;
											if (xmlNode4.Name.StartsWith("WeaponTarget_"))
											{
												int_ = Conversions.ToInteger(xmlNode4.Name.Split('_')[1]);
												Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = (Doctrine._WRA_WeaponTargetType)int_;
												newChild2 = xmlDocument.CreateComment(wRA_WeaponTargetType.ToString());
												xmlNode3.InsertBefore(newChild2, xmlNode4);
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
							}
							finally
							{
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
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
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		if (list.Count > 0)
		{
			XmlNode xmlNode5 = xmlDocument.SelectSingleNode("/Doctrine");
			foreach (XmlNode item in list)
			{
				xmlNode5.RemoveChild(item);
			}
		}
		memoryStream_0.Position = 0L;
		xmlWriter_.Close();
		xmlWriter_ = XmlWriter.Create(memoryStream_0, xmlWriterSettings);
		xmlDocument.WriteTo(xmlWriter_);
		xmlWriter_.Flush();
		return xmlDocument.InnerXml.ToString();
	}

	public static string FromXML_Private(ref object object_0, ref string string_0, ref Doctrine doctrine_0, ref Scenario scenario_0)
	{
		string xml = "";
		List<XmlNode> list = new List<XmlNode>();
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			XmlWriter xmlWriter_ = XmlWriter.Create(memoryStream, xmlWriterSettings);
			doctrine_0.ToXML(ref xmlWriter_, ref scenario_0);
			xmlWriter_.Flush();
			xml = Misc.AssetRequest(memoryStream);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xml);
		XmlNode xmlNode = xmlDocument.SelectSingleNode("/Doctrine");
		XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("type");
		xmlAttribute.Value = doctrine_0.SubjectType.Name.ToString();
		xmlDocument.DocumentElement.SetAttributeNode(xmlAttribute);
		xml = xmlDocument.InnerXml.ToString();
		XmlDocument xmlDocument2 = new XmlDocument();
		xmlDocument2.Load(string_0);
		xml = xmlDocument2.InnerXml.ToString();
		bool flag = false;
		smethod_0();
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlDocument2.ChildNodes.GetEnumerator();
			IEnumerator enumerator3 = null;
			IEnumerator enumerator4 = null;
			IEnumerator enumerator5 = null;
			IEnumerator enumerator6 = null;
			IEnumerator enumerator7 = null;
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode2 = (XmlNode)enumerator.Current;
				if (Operators.CompareString(xmlNode2.LocalName, "Doctrine", TextCompare: false) != 0)
				{
					continue;
				}
				if (xmlNode2.Attributes != null)
				{
					try
					{
						enumerator3 = xmlNode2.Attributes.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							XmlAttribute xmlAttribute2 = (XmlAttribute)enumerator3.Current;
							if (Operators.CompareString(xmlAttribute2.Name, "inherit", TextCompare: false) != 0 || (Operators.CompareString(xmlAttribute2.Value, "yes", TextCompare: false) != 0 && Operators.CompareString(xmlAttribute2.Value, "true", TextCompare: false) != 0) || (object)doctrine_0.SubjectType == typeof(Side) || (object)doctrine_0.SubjectType == typeof(Waypoint))
							{
								continue;
							}
							xmlNode = xmlDocument.SelectSingleNode("/Doctrine");
							do
							{
								flag = false;
								try
								{
									enumerator4 = xmlNode.ChildNodes.GetEnumerator();
									while (enumerator4.MoveNext())
									{
										XmlNode xmlNode3 = (XmlNode)enumerator4.Current;
										string name = xmlNode3.Name;
										if (Operators.CompareString(name, "WRA", TextCompare: false) != 0 && Operators.CompareString(name, "#comment", TextCompare: false) != 0)
										{
											xmlNode.RemoveChild(xmlNode3);
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
							while (flag);
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
				try
				{
					enumerator5 = xmlNode2.ChildNodes.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						XmlNode xmlNode4 = (XmlNode)enumerator5.Current;
						string name2 = xmlNode4.Name;
						if (Operators.CompareString(name2, "WRA", TextCompare: false) == 0)
						{
							if (xmlNode4.Attributes != null)
							{
								try
								{
									enumerator6 = xmlNode4.Attributes.GetEnumerator();
									while (enumerator6.MoveNext())
									{
										XmlAttribute xmlAttribute3 = (XmlAttribute)enumerator6.Current;
										if (Operators.CompareString(xmlAttribute3.Name, "inherit", TextCompare: false) == 0 && (Operators.CompareString(xmlAttribute3.Value, "yes", TextCompare: false) == 0 || Operators.CompareString(xmlAttribute3.Value, "true", TextCompare: false) == 0) && (object)doctrine_0.SubjectType != typeof(Side) && (object)doctrine_0.SubjectType != typeof(Waypoint))
										{
											xmlDocument.SelectSingleNode("/Doctrine/WRA")?.RemoveAll();
										}
									}
								}
								finally
								{
									if (enumerator6 is IDisposable)
									{
										(enumerator6 as IDisposable).Dispose();
									}
								}
							}
							if (!xmlNode4.HasChildNodes)
							{
								continue;
							}
							try
							{
								enumerator7 = xmlNode4.ChildNodes.GetEnumerator();
								while (enumerator7.MoveNext())
								{
									XmlNode xmlNode5 = (XmlNode)enumerator7.Current;
									string name3 = xmlNode5.Name;
									if (Operators.CompareString(name3, "#comment", TextCompare: false) == 0)
									{
										continue;
									}
									if (Operators.CompareString(name3, "Weapon_All", TextCompare: false) == 0)
									{
										list.Add(xmlNode5);
										continue;
									}
									xmlNode = xmlDocument.SelectSingleNode("/Doctrine/WRA/" + xmlNode5.LocalName);
									if (xmlNode == null)
									{
										xmlNode = xmlDocument.SelectSingleNode("/Doctrine/WRA");
										if (xmlNode == null)
										{
											XmlElement newChild = xmlDocument.CreateElement("WRA");
											xmlDocument.DocumentElement.AppendChild(newChild);
											xmlNode = xmlDocument.SelectSingleNode("/Doctrine/WRA");
										}
										if (xmlNode != null)
										{
											XmlNode newChild2 = xmlDocument.ImportNode(xmlNode5, deep: true);
											xmlNode.AppendChild(newChild2);
										}
									}
									else if (xmlNode.LocalName.Equals(xmlNode5.LocalName) && !xmlNode.InnerXml.Equals(xmlNode5.InnerXml))
									{
										xmlNode.InnerXml = xmlNode5.InnerXml;
									}
								}
							}
							finally
							{
								if (enumerator7 is IDisposable)
								{
									(enumerator7 as IDisposable).Dispose();
								}
							}
						}
						else
						{
							if (Operators.CompareString(name2, "#comment", TextCompare: false) == 0)
							{
								continue;
							}
							string text = xmlNode4.Name;
							if (dictionary_1.ContainsValue(text))
							{
								foreach (KeyValuePair<string, string> item in dictionary_1)
								{
									if (Operators.CompareString(item.Value, text, TextCompare: false) == 0)
									{
										text = item.Key;
										break;
									}
								}
							}
							xmlNode = xmlDocument.SelectSingleNode("/Doctrine/" + text);
							if (xmlNode == null)
							{
								xmlNode = xmlDocument.SelectSingleNode("/Doctrine");
								if (xmlNode != null)
								{
									XmlElement xmlElement = xmlDocument.CreateElement(text);
									xmlElement.InnerXml = xmlNode4.InnerXml;
									xmlNode.AppendChild(xmlElement);
								}
							}
							else if (xmlNode.Name.Equals(text) && !xmlNode.InnerText.Equals(xmlNode4.InnerText))
							{
								xmlNode.InnerText = xmlNode4.InnerText;
							}
						}
					}
				}
				finally
				{
					if (enumerator5 is IDisposable)
					{
						(enumerator5 as IDisposable).Dispose();
					}
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
		if (list.Count > 0)
		{
			xmlNode = xmlDocument.SelectSingleNode("/Doctrine/WRA");
			if (xmlNode == null)
			{
				XmlElement newChild3 = xmlDocument.CreateElement("WRA");
				xmlDocument.DocumentElement.AppendChild(newChild3);
				xmlNode = xmlDocument.SelectSingleNode("/Doctrine/WRA");
			}
			dictionary_0 = new Dictionary<int, Doctrine.WRA_Weapon>();
			switch (doctrine_0.SubjectType.Name)
			{
			case "Side":
			{
				Side Local_mySide = (Side)object_0;
				foreach (ActiveUnit item2 in scenario_0.ActiveUnits_List.Where((ActiveUnit AU) => AU.GetUnitSide() == Local_mySide))
				{
					if (!item2.IsWeapon)
					{
						if (item2.IsAircraft)
						{
							WRA_RetreiveMountWeapons(item2, ref doctrine_0, ref scenario_0);
							WRA_RetreiveLoadoutWeapons(item2, ref doctrine_0, ref scenario_0);
						}
						else if (item2.IsShip || item2.IsSubmarine || item2.IsFacility)
						{
							WRA_RetreiveMountWeapons(item2, ref doctrine_0, ref scenario_0);
							WRA_RetreiveMagazineWeapons(item2, ref doctrine_0, ref scenario_0);
						}
					}
				}
				break;
			}
			case "Aircraft":
			case "Facility":
			case "Ship":
			case "Submarine":
			{
				ActiveUnit activeUnit = (ActiveUnit)object_0;
				if (activeUnit.IsAircraft)
				{
					WRA_RetreiveMountWeapons(activeUnit, ref doctrine_0, ref scenario_0);
					WRA_RetreiveLoadoutWeapons(activeUnit, ref doctrine_0, ref scenario_0);
				}
				else if (activeUnit.IsShip || activeUnit.IsSubmarine || activeUnit.IsFacility)
				{
					WRA_RetreiveMountWeapons(activeUnit, ref doctrine_0, ref scenario_0);
					WRA_RetreiveMagazineWeapons(activeUnit, ref doctrine_0, ref scenario_0);
				}
				break;
			}
			}
			IEnumerator enumerator8 = null;
			IEnumerator enumerator2 = null;
			foreach (XmlNode item3 in list)
			{
				if (Operators.CompareString(item3.Name, "Weapon_All", TextCompare: false) != 0)
				{
					continue;
				}
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item4 in dictionary_0)
				{
					int key = item4.Key;
					Weapon weapon = item4.Value.WriteInterruptibleField(scenario_0, key);
					if (Information.IsNothing(weapon.Doctrine.WRA))
					{
						continue;
					}
					foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item7 in weapon.Doctrine.WRA)
					{
						Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets2 = item7.Value.WRA_WeaponTargets;
						Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets2;
						foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
						{
							Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets3 = item4.Value.WRA_WeaponTargets;
							Doctrine.WRA_FiringDoctrineEntry[] array2 = wRA_WeaponTargets3;
							foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry2 in array2)
							{
								if (wRA_FiringDoctrineEntry2.TargetType == wRA_FiringDoctrineEntry.TargetType)
								{
									wRA_FiringDoctrineEntry2.WeaponQty = -1;
									wRA_FiringDoctrineEntry2.ShooterQty = -1;
									wRA_FiringDoctrineEntry2.SelfDefenceRange = -1f;
									break;
								}
							}
						}
					}
				}
				try
				{
					enumerator8 = item3.ChildNodes.GetEnumerator();
					while (enumerator8.MoveNext())
					{
						XmlNode xmlNode6 = (XmlNode)enumerator8.Current;
						if (Operators.CompareString(xmlNode6.Name, "#comment", TextCompare: false) == 0 || !xmlNode6.Name.StartsWith("WeaponTarget_"))
						{
							continue;
						}
						Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = (Doctrine._WRA_WeaponTargetType)Conversions.ToInteger(xmlNode6.Name.Split('_')[1]);
						int? num = null;
						int? num2 = null;
						int? num3 = null;
						int? num4 = null;
						try
						{
							enumerator2 = xmlNode6.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode7 = (XmlNode)enumerator2.Current;
								switch (xmlNode7.Name)
								{
								case "WeaponQty":
									num = Conversions.ToInteger(xmlNode7.InnerText);
									break;
								case "ShooterQty":
									num2 = Conversions.ToInteger(xmlNode7.InnerText);
									break;
								case "SelfDefenceRange":
									num3 = Conversions.ToInteger(xmlNode7.InnerText);
									break;
								case "FiringRange":
									num4 = Conversions.ToInteger(xmlNode7.InnerText);
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
						foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item5 in dictionary_0)
						{
							int key2 = item5.Key;
							Weapon weapon2 = item5.Value.WriteInterruptibleField(scenario_0, key2);
							string text2 = "/Doctrine/WRA/Weapon_" + key2;
							XmlNode xmlNode8 = xmlDocument.SelectSingleNode(text2);
							if (Information.IsNothing(weapon2.Doctrine.WRA))
							{
								continue;
							}
							foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item6 in weapon2.Doctrine.WRA)
							{
								Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item5.Value.WRA_WeaponTargets;
								Doctrine.WRA_FiringDoctrineEntry[] array3 = wRA_WeaponTargets;
								foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry3 in array3)
								{
									if (wRA_FiringDoctrineEntry3.TargetType != wRA_WeaponTargetType)
									{
										continue;
									}
									if (num.HasValue)
									{
										wRA_FiringDoctrineEntry3.WeaponQty = num;
									}
									if (num2.HasValue)
									{
										wRA_FiringDoctrineEntry3.ShooterQty = num2;
									}
									if (num3.HasValue)
									{
										wRA_FiringDoctrineEntry3.SelfDefenceRange = num3;
									}
									if (num4.HasValue)
									{
										wRA_FiringDoctrineEntry3.FiringRange = num4;
									}
									StringBuilder stringBuilder = new StringBuilder();
									int num5 = (int)wRA_WeaponTargetType;
									XmlNode xmlNode9 = xmlDocument.SelectSingleNode(text2 + "/WeaponTarget_" + num5);
									if (xmlNode9 == null)
									{
										num5 = (int)wRA_WeaponTargetType;
										stringBuilder.Append("<WeaponTarget_" + num5 + ">");
										if (num.HasValue)
										{
											int? num9 = num;
											int? num14 = num9;
											stringBuilder.Append("<WeaponQty>" + num14 + "</WeaponQty>");
										}
										if (num2.HasValue)
										{
											int? num8 = num2;
											int? num14 = num8;
											stringBuilder.Append("<ShooterQty>" + num14 + "</ShooterQty>");
										}
										if (num3.HasValue)
										{
											int? num7 = num3;
											int? num14 = num7;
											stringBuilder.Append("<SelfDefenceRange>" + num14 + "</SelfDefenceRange>");
										}
										if (num4.HasValue)
										{
											int? num6 = num4;
											int? num14 = num6;
											stringBuilder.Append("<FiringRange>" + num14 + "</FiringRange>");
										}
										num5 = (int)wRA_WeaponTargetType;
										stringBuilder.Append("</WeaponTarget_" + num5 + ">");
										if (xmlNode8 == null)
										{
											XmlElement newChild4 = xmlDocument.CreateElement("武器_" + key2);
											xmlNode.AppendChild(newChild4);
											xmlNode8 = xmlDocument.SelectSingleNode("/Doctrine/WRA/Weapon_" + key2);
										}
										XmlDocumentFragment xmlDocumentFragment = xmlDocument.CreateDocumentFragment();
										xmlDocumentFragment.InnerXml = stringBuilder.ToString();
										xmlNode8.AppendChild(xmlDocumentFragment);
										break;
									}
									if (num.HasValue && xmlNode9.SelectSingleNode("WeaponQty") != null)
									{
										xmlNode9.SelectSingleNode("WeaponQty").InnerText = num.ToString();
									}
									else if (num.HasValue)
									{
										int? num13 = num;
										int? num14 = num13;
										stringBuilder.Append("<WeaponQty>" + num14 + "</WeaponQty>");
									}
									if (num2.HasValue && xmlNode9.SelectSingleNode("ShooterQty") != null)
									{
										xmlNode9.SelectSingleNode("WeaponQty").InnerText = num2.ToString();
									}
									else if (num2.HasValue)
									{
										int? num12 = num2;
										int? num14 = num12;
										stringBuilder.Append("<ShooterQty>" + num14 + "</ShooterQty>");
									}
									if (num3.HasValue && xmlNode9.SelectSingleNode("SelfDefenceRange") != null)
									{
										xmlNode9.SelectSingleNode("SelfDefenceRange").InnerText = num3.ToString();
									}
									else if (num3.HasValue)
									{
										int? num11 = num3;
										int? num14 = num11;
										stringBuilder.Append("<SelfDefenceRange>" + num14 + "</SelfDefenceRange>");
									}
									if (num4.HasValue && xmlNode9.SelectSingleNode("FiringRange") != null)
									{
										xmlNode9.SelectSingleNode("FiringRange").InnerText = num4.ToString();
									}
									else if (num4.HasValue)
									{
										int? num10 = num4;
										int? num14 = num10;
										stringBuilder.Append("<FiringRange>" + num14 + "</FiringRange>");
									}
									if (stringBuilder.Length > 0)
									{
										XmlDocumentFragment xmlDocumentFragment2 = xmlDocument.CreateDocumentFragment();
										xmlDocumentFragment2.InnerXml = stringBuilder.ToString();
										xmlNode9.AppendChild(xmlDocumentFragment2);
									}
									break;
								}
							}
						}
					}
				}
				finally
				{
					if (enumerator8 is IDisposable)
					{
						(enumerator8 as IDisposable).Dispose();
					}
				}
			}
		}
		xmlNode = xmlDocument.SelectSingleNode("/Doctrine");
		switch (doctrine_0.SubjectType.Name)
		{
		default:
			if (doctrine_0.Subject.IsMission)
			{
				Mission mission = (Mission)doctrine_0.Subject;
				mission.Doctrine = Doctrine.FromXML(ref xmlNode, mission);
			}
			break;
		case "Submarine":
		{
			Submarine submarine = (Submarine)doctrine_0.Subject;
			submarine.Doctrine = Doctrine.FromXML(ref xmlNode, submarine);
			break;
		}
		case "Side":
		{
			Side side = (Side)doctrine_0.Subject;
			side.Doctrine = Doctrine.FromXML(ref xmlNode, side);
			break;
		}
		case "Ship":
		{
			Ship ship = (Ship)doctrine_0.Subject;
			ship.Doctrine = Doctrine.FromXML(ref xmlNode, ship);
			break;
		}
		case "Group":
		{
			Group group = (Group)doctrine_0.Subject;
			group.Doctrine = Doctrine.FromXML(ref xmlNode, group);
			break;
		}
		case "Facility":
		{
			Facility facility = (Facility)doctrine_0.Subject;
			facility.Doctrine = Doctrine.FromXML(ref xmlNode, facility);
			break;
		}
		case "Aircraft":
		{
			Aircraft aircraft = (Aircraft)doctrine_0.Subject;
			aircraft.Doctrine = Doctrine.FromXML(ref xmlNode, aircraft);
			break;
		}
		}
		return xml;
	}

	public static void WRA_RetreiveLoadoutWeapons(ActiveUnit activeUnit_0, ref Doctrine doctrine_0, ref Scenario scenario_0)
	{
		if (Information.IsNothing(((Aircraft)activeUnit_0).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
		for (int i = 0; i < weapons.Length; i = checked(i + 1))
		{
			Weapon weapon_ = weapons[i].GetReferenceWeapon(scenario_0);
			if (doctrine_0.InsertRepository(ref weapon_))
			{
				WRA_AddWeapon(ref weapon_, ref scenario_0);
			}
		}
	}

	public static void WRA_RetreiveMagazineWeapons(ActiveUnit activeUnit_0, ref Doctrine doctrine_0, ref Scenario scenario_0)
	{
		foreach (Magazine item in activeUnit_0.SharedMagazines.OrderBy((Magazine theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				Weapon weapon_ = weapon.GetReferenceWeapon(scenario_0);
				if (doctrine_0.InsertRepository(ref weapon_))
				{
					WRA_AddWeapon(ref weapon_, ref scenario_0);
				}
			}
		}
	}

	public static void WRA_RetreiveMountWeapons(ActiveUnit activeUnit_0, ref Doctrine doctrine_0, ref Scenario scenario_0)
	{
		foreach (Mount item in activeUnit_0.Mounts.OrderBy((Mount theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon weapon_ = mountWeapon.GetReferenceWeapon(scenario_0);
				if (doctrine_0.InsertRepository(ref weapon_))
				{
					WRA_AddWeapon(ref weapon_, ref scenario_0);
				}
			}
		}
	}

	public static void WRA_AddWeapon(ref Weapon weapon_0, ref Scenario scenario_0)
	{
		if (!dictionary_0.ContainsKey(weapon_0.DBID))
		{
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon(ref weapon_0, scenario_0);
			dictionary_0.Add(weapon_0.DBID, value);
		}
	}
}
