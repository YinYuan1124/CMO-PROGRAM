using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Weapon_Damage : ActiveUnit_Damage
{
	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
	}

	public new static Weapon_Damage FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			return new Weapon_Damage(ref activeUnit_0)
			{
				myUnit = activeUnit_0
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100977", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Weapon_Damage result = new Weapon_Damage(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public Weapon_Damage(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
	}

	public override void ResolveDamageFromWeapon(Weapon weapon_0, GeoPoint geoPoint_0, float float_0, float float_1, ActiveUnit activeUnit_0, double? nullable_0, double? nullable_1, float? nullable_2, ref string string_0, bool bool_0)
	{
		if (Module_Unit.AwakeTokenizer(myUnit))
		{
			return;
		}
		try
		{
			if (weapon_0.Flags.Fuze_Proximity)
			{
				int num;
				int num2 = (num = (int)Math.Round(GameGeneral.LockRandom_0.NextDouble() * 100.0));
				int num3 = 0;
				if (num <= 20)
				{
					myUnit.ParentScen.DestroyThisUnit(myUnit, weapon_0.Name + " has involved in the destruction of this unit/weapon, export WeaponEndgame data for more information.", "Weapon Interaction");
				}
				else
				{
					num3 = ((num <= 40) ? 80 : ((num <= 60) ? 40 : ((num <= 80) ? 20 : 10)));
				}
				if (num2 > 20)
				{
					if ((int)Math.Round(GameGeneral.LockRandom_0.NextDouble() * 100.0) <= num3)
					{
						LastWeaponHit = weapon_0;
						myUnit.ParentScen.DestroyThisUnit(myUnit, weapon_0.Name + " has involved in the destruction of this unit/weapon, export WeaponEndgame data for more information.", "Weapon Interaction");
					}
					else
					{
						myUnit.ParentScen.AddMessage("武器：" + weapon_0.Name + " caused no or unsufficient proximity frag damage to target: " + myUnit.Name, "Insufficient frag damage", LoggedMessage.MessageType.WeaponDamage, 0, weapon_0.ObjectID, weapon_0.GetUnitSide(), new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
				}
			}
			else if (weapon_0.Type == Weapon._WeaponType.LaserDazzler)
			{
				double num4 = Module_Unit.RangeToPoint_Slant(myUnit, geoPoint_0) / weapon_0.MaxRange_NoTargetType;
				double num5 = 1.0 - num4;
				ResolveDamageFromDazzler((float)num5);
			}
			else
			{
				LastWeaponHit = weapon_0;
				myUnit.ParentScen.DestroyThisUnit(myUnit, weapon_0.Name + " has involved in the destruction of this unit/weapon, export WeaponEndgame data for more information.", "Weapon Interaction");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100978", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
