using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class CargoAmmunition : CargoContainerContent
{
	public int int_0;

	public int WeaponQuantity;

	public CargoAmmunition()
	{
		ContentType = CargoContainerContentType.Ammunition;
	}

	public CargoAmmunition(CargoAmmunition cargoAmmunition_0)
		: base(cargoAmmunition_0)
	{
		int_0 = cargoAmmunition_0.int_0;
		WeaponQuantity = cargoAmmunition_0.WeaponQuantity;
	}

	public CargoAmmunition(int int_1, int int_2, Scenario scenario_0)
	{
		ContentType = CargoContainerContentType.Ammunition;
		int_0 = int_1;
		WeaponQuantity = int_2;
		SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
		CargoAmmunition cargoAmmunition_ = this;
		DBFunctions.GetWeaponCargoData(ref sqliteConnection_, int_1, ref cargoAmmunition_);
	}

	public override bool TransferToUnit(ActiveUnit activeUnit_0, ActiveUnit activeUnit_1, Cargo cargo_0 = null, float float_0 = 0f)
	{
		int num = 1423;
		Magazine[] sharedMagazines = activeUnit_1.SharedMagazines;
		Magazine magazine = null;
		WeaponRec weaponRec = null;
		if (float_0 == 0f || float_0 > (float)WeaponQuantity)
		{
			float_0 = WeaponQuantity;
		}
		int num2 = (int)Math.Round(float_0);
		int num3 = 0;
		int num4 = 0;
		Magazine[] array = sharedMagazines;
		Magazine[] array2 = array;
		foreach (Magazine magazine2 in array2)
		{
			if (magazine2.ParentPlatform != activeUnit_1)
			{
				continue;
			}
			foreach (WeaponRec item in magazine2.Weapons.ToList())
			{
				if (item.int_0 == int_0)
				{
					num3 = item.MaxLoad - item.CurrentLoad;
					if (num3 >= num2)
					{
						num4 = num2;
						weaponRec = item;
						magazine = magazine2;
						break;
					}
					if (!activeUnit_1.IsFixedFacility && num3 > num4)
					{
						num4 = num3;
						weaponRec = item;
						magazine = magazine2;
					}
				}
			}
		}
		if (num4 > 0)
		{
			num2 = num4;
		}
		if (activeUnit_1.IsFixedFacility)
		{
			if (magazine == null)
			{
				magazine = DBFunctions.GetMagazine(num, ref activeUnit_1.ParentScen, bool_0: false);
				((Platform)activeUnit_1).AddSharedMagazine(magazine);
			}
			if (weaponRec == null)
			{
				weaponRec = new WeaponRec(ref activeUnit_1.ParentScen, int_0, 0, 10000, magazine.ROF, 1, bool_0: false, bool_1: false);
				magazine.Weapons.Add(weaponRec);
			}
		}
		if (weaponRec == null)
		{
			return false;
		}
		weaponRec.CurrentLoad += num2;
		WeaponQuantity -= num2;
		return true;
	}

	public override bool TransferFromUnit(CargoContainer cargoContainer_0, ActiveUnit activeUnit_0, Cargo cargo_0 = null, float float_0 = 0f)
	{
		Magazine[] sharedMagazines = activeUnit_0.SharedMagazines;
		if (float_0 == 0f || float_0 > (float)WeaponQuantity)
		{
			float_0 = WeaponQuantity;
		}
		int num = (int)Math.Round(float_0);
		Magazine[] array = sharedMagazines;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (WeaponRec item in array[i].Weapons.ToList())
			{
				if (item.int_0 == int_0 && item.CurrentLoad > 0)
				{
					item.CurrentLoad -= num;
					if (item.CurrentLoad >= 0)
					{
						num = 0;
						break;
					}
					num = -1 * item.CurrentLoad;
					item.CurrentLoad = 0;
				}
			}
			if (num < 1)
			{
				break;
			}
		}
		if (num > 0)
		{
			WeaponQuantity -= num;
		}
		if (WeaponQuantity <= 0)
		{
			return false;
		}
		return true;
	}

	public override void DestroyCargoObject(Side side_0, bool bool_0, bool bool_1, bool bool_2, string string_0, string string_1 = null)
	{
		if (WeaponQuantity > 0)
		{
			side_0.AAR.AddToWeaponsLost(int_0, WeaponQuantity);
		}
		WeaponQuantity = 0;
	}

	public override float GetRequiredCrewSpace()
	{
		return (float)WeaponQuantity * Crew;
	}

	public override float GetRequiredArea()
	{
		if (IsStackable() && Parent != null && Parent.CanStackCargo())
		{
			return GetRequiredAreaStacked(Parent, WeaponQuantity);
		}
		return (float)WeaponQuantity * Area;
	}

	public override float GetRequiredAreaStacked(ICargoHost icargoHost_0, int int_1)
	{
		int num = (int)Math.Floor(icargoHost_0.GetCargo_Height() / Height);
		if (num < 2)
		{
			return Area * (float)int_1;
		}
		if (int_1 <= num)
		{
			return Area;
		}
		return (float)(int)Math.Ceiling((double)int_1 / (double)num) * Area;
	}

	public override float GetRequiredMass()
	{
		return (float)WeaponQuantity * Mass;
	}

	public override string GetCargoName()
	{
		string text = WeaponQuantity + "x " + Name;
		if (WeaponQuantity > 1 && IsStackable() && Parent != null && Parent.CanStackCargo() && Parent.GetCargo_Height() >= 2f * GetRequiredHeight())
		{
			text += " (Stacked)";
		}
		return text;
	}

	public override int imethod_0()
	{
		return int_0;
	}

	public override string GetCargoObjectLossString()
	{
		return "武器_" + int_0;
	}

	public override bool IsStackable()
	{
		return Height > 0f;
	}

	public override float GetRequiredHeight()
	{
		return Height;
	}

	public override int GetCargoQuantity()
	{
		return WeaponQuantity;
	}

	public override bool isMatch(Cargo cargo_0)
	{
		if (cargo_0.CargoObjectContainerContents != null && cargo_0.CargoObjectContainerContents.ContentType == CargoContainerContentType.Ammunition && ((CargoAmmunition)cargo_0.CargoObjectContainerContents).int_0 == int_0)
		{
			return true;
		}
		return false;
	}

	public override bool isMatch(CargoContainerContent cargoContainerContent_0)
	{
		if (cargoContainerContent_0.ContentType == CargoContainerContentType.Ammunition && ((CargoAmmunition)cargoContainerContent_0).int_0 == int_0)
		{
			return true;
		}
		return false;
	}

	public override bool isExactMatch(CargoContainerContent cargoContainerContent_0)
	{
		if (cargoContainerContent_0.ContentType == CargoContainerContentType.Ammunition)
		{
			CargoAmmunition cargoAmmunition = (CargoAmmunition)cargoContainerContent_0;
			if (cargoAmmunition.int_0 == int_0 && cargoAmmunition.WeaponQuantity == WeaponQuantity)
			{
				return true;
			}
		}
		return false;
	}

	public override float GetQuantityDifference(CargoContainerContent cargoContainerContent_0)
	{
		if (isMatch(cargoContainerContent_0))
		{
			return WeaponQuantity - ((CargoAmmunition)cargoContainerContent_0).WeaponQuantity;
		}
		return 0f;
	}

	public override void SetQuantity(float float_0)
	{
		WeaponQuantity = (int)Math.Round(float_0);
	}

	internal string StopProperty(HashSet<string> hashSet_0, Scenario scenario_0)
	{
		return "<WDBID>" + int_0 + "</WDBID><WNUM>" + WeaponQuantity + "</WNUM>";
	}

	public void SubclassFromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0)
	{
		IEnumerator enumerator = null;
		try
		{
			enumerator = xmlNode_0.ChildNodes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				try
				{
					string name = xmlNode.Name;
					if (Operators.CompareString(name, "WDBID", TextCompare: false) == 0)
					{
						int_0 = Conversions.ToInteger(xmlNode.InnerText);
					}
					else if (Operators.CompareString(name, "WNUM", TextCompare: false) == 0)
					{
						WeaponQuantity = Conversions.ToInteger(xmlNode.InnerText);
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
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
	}
}
