using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Command_Core;

public sealed class CargoHostHelper
{
	public static string c0000;

	public static string c1000;

	public static string c2000;

	public static string c3000;

	public static string c4000;

	public static string c5000;

	static CargoHostHelper()
	{
		c0000 = "不能装载货物";
		c1000 = "人员（小队，MANPADS，ATGM）";
		c2000 = "小型货物（汽车，AAA枪）";
		c3000 = "中型货物（APC，Towed Arty）";
		c4000 = "大型货物（坦克，电话，拖车）";
		c5000 = "超大货物（IRBM / ICBM TEL发射架）";
	}

	public static string TroopCapacityString(ICargoHost icargoHost_0)
	{
		if (icargoHost_0.GetCargo_Type() == CargoType.NoCargo)
		{
			return "None";
		}
		if (icargoHost_0.GetCargo_Crew() == 0f)
		{
			return "None";
		}
		return icargoHost_0.GetCargo_Crew() + "军队";
	}

	public static string CargoCapacityString(ICargoHost icargoHost_0)
	{
		if (icargoHost_0.GetCargo_Type() == CargoType.NoCargo)
		{
			return "None";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Clear();
		if (icargoHost_0.GetCargo_Type() == CargoType.Personnel)
		{
			stringBuilder.Append(c1000);
		}
		else if (icargoHost_0.GetCargo_Type() == CargoType.SmallCargo)
		{
			stringBuilder.Append(c2000);
		}
		else if (icargoHost_0.GetCargo_Type() == CargoType.MediumCargo)
		{
			stringBuilder.Append(c3000);
		}
		else if (icargoHost_0.GetCargo_Type() == CargoType.LargeCargo)
		{
			stringBuilder.Append(c4000);
		}
		else if (icargoHost_0.GetCargo_Type() == CargoType.const_5)
		{
			stringBuilder.Append(c5000);
		}
		stringBuilder.Append("<br/>");
		stringBuilder.Append("质量：").Append(icargoHost_0.GetCargo_Mass()).Append("吨。");
		stringBuilder.Append("<br/>");
		stringBuilder.Append("区域：").Append(icargoHost_0.GetCargo_Area()).Append("平方米");
		return stringBuilder.ToString();
	}

	public static float GetAvailableMass(ICargoHost icargoHost_0, Cargo[] cargo_0)
	{
		float num = icargoHost_0.GetCargo_Mass();
		if (cargo_0 != null)
		{
			foreach (Cargo cargo in cargo_0)
			{
				num -= cargo.RequiredMass;
			}
		}
		return num;
	}

	public static float GetAvailableCrewSpace(ICargoHost icargoHost_0, Cargo[] cargo_0)
	{
		float num = icargoHost_0.GetCargo_Crew();
		if (cargo_0 != null)
		{
			foreach (Cargo cargo in cargo_0)
			{
				num -= cargo.RequiredCrewSpace;
			}
		}
		return num;
	}

	public static float GetAvailableArea(ICargoHost icargoHost_0, Cargo[] cargo_0)
	{
		float num = icargoHost_0.GetCargo_Area();
		if (cargo_0 != null)
		{
			foreach (Cargo cargo in cargo_0)
			{
				num -= cargo.RequiredArea;
			}
		}
		return num;
	}

	public static float GetCurrentLoadTotalMass(ICargoHost icargoHost_0, Cargo[] cargo_0)
	{
		float num = 0f;
		if (cargo_0 != null)
		{
			foreach (Cargo cargo in cargo_0)
			{
				num += cargo.RequiredMass;
			}
		}
		return num;
	}

	public static float GetCurrentLoadTotalCrewSpace(ICargoHost icargoHost_0, Cargo[] cargo_0)
	{
		float num = 0f;
		if (cargo_0 != null)
		{
			foreach (Cargo cargo in cargo_0)
			{
				num += cargo.RequiredCrewSpace;
			}
		}
		return num;
	}

	public static bool CanLoad(ICargoHost icargoHost_0, Cargo[] cargo_0, ICargoClient icargoClient_0)
	{
		if (icargoClient_0.GetRequiredCargoType() <= icargoHost_0.GetCargo_Type())
		{
			float num = icargoHost_0.GetCargo_Mass();
			float num2 = icargoHost_0.GetCargo_Area();
			float num3 = icargoHost_0.GetCargo_Crew();
			bool flag = icargoHost_0.CanStackCargo() && icargoClient_0.IsStackable() && icargoHost_0.GetCargo_Height() >= 2f * icargoClient_0.GetRequiredHeight();
			int num4 = 0;
			if (cargo_0 != null)
			{
				foreach (Cargo cargo in cargo_0)
				{
					num -= cargo.RequiredMass;
					num3 -= cargo.RequiredCrewSpace;
					if (flag && icargoClient_0.isMatch(cargo))
					{
						num4 += cargo.CargoObjectQuantity;
					}
					else
					{
						num2 -= cargo.RequiredArea;
					}
				}
			}
			if (num >= icargoClient_0.GetRequiredMass() && num3 >= icargoClient_0.GetRequiredCrewSpace())
			{
				float num5 = icargoClient_0.GetRequiredArea();
				if (flag && num4 > 0)
				{
					num5 = icargoClient_0.GetRequiredAreaStacked(icargoHost_0, num4 + icargoClient_0.GetCargoQuantity());
				}
				if (num2 >= num5)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool Add(ICargoHost icargoHost_0, Cargo cargo_0)
	{
		if (icargoHost_0.CargoArray.Contains(cargo_0))
		{
			return false;
		}
		Cargo[] gparam_ = icargoHost_0.CargoArray;
		ArrayExtensions.Add(ref gparam_, cargo_0);
		icargoHost_0.CargoArray = gparam_;
		return true;
	}

	public static bool Remove(ICargoHost icargoHost_0, Cargo cargo_0)
	{
		if (icargoHost_0.CargoArray.Contains(cargo_0))
		{
			Cargo[] gparam_ = icargoHost_0.CargoArray;
			ArrayExtensions.Remove(ref gparam_, cargo_0);
			icargoHost_0.CargoArray = gparam_;
			return true;
		}
		return false;
	}

	public static Cargo GetTowedCargo(ICargoHost icargoHost_0)
	{
		Cargo[] cargoArray = icargoHost_0.CargoArray;
		int num = 0;
		Cargo cargo;
		while (true)
		{
			if (num < cargoArray.Length)
			{
				cargo = cargoArray[num];
				if (cargo.StorageType == Cargo.CargoStorageType.TowedExternal)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return cargo;
	}

	public static int GetPercentFull(ICargoHost icargoHost_0)
	{
		int num = 0;
		if (icargoHost_0.CargoArray.Count() > 0)
		{
			int num2 = (int)Math.Round(100f * (1f - GetAvailableMass(icargoHost_0, icargoHost_0.CargoArray) / icargoHost_0.GetCargo_Mass()));
			num = num2;
			if (num < 100)
			{
				num2 = (int)Math.Round(100f * (1f - GetAvailableCrewSpace(icargoHost_0, icargoHost_0.CargoArray) / icargoHost_0.GetCargo_Crew()));
				if (num2 > num)
				{
					num = num2;
				}
				if (num < 100)
				{
					num2 = (int)Math.Round(100f * (1f - GetAvailableArea(icargoHost_0, icargoHost_0.CargoArray) / icargoHost_0.GetCargo_Area()));
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
		}
		return num;
	}

	public static string CanUnloadUnitAtPresentPosition(ActiveUnit activeUnit_0, Cargo cargo_0)
	{
		if (activeUnit_0.DockingOps.CurrentHostUnit == null)
		{
			if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).AirOps.CurrentHostUnit != null)
			{
				return "Use the Air Ops window to transfer cargo for hosted aircraft.";
			}
			if (activeUnit_0.OnboardCargo.Contains(cargo_0))
			{
				bool flag = Module_Unit.ResetTokenizer(activeUnit_0);
				if (activeUnit_0.IsAircraft)
				{
					if (flag)
					{
						Aircraft aircraft = (Aircraft)activeUnit_0;
						if (aircraft.IsHelicopter)
						{
							return "Ok";
						}
						if (aircraft.InitFacade())
						{
							if (cargo_0.isParadropCapable)
							{
								return "Ok";
							}
							return "This aircraft can paradrop cargo but the specified cargo item cannot be paradropped.";
						}
						return "This aircraft's current loadout cannot paradrop cargo.";
					}
					return "Aircraft must be over land to unload cargo.";
				}
				if (activeUnit_0.IsFixedFacility)
				{
					if (flag)
					{
						return "Ok";
					}
					return "Facilities must be on land to unload cargo.";
				}
				if (activeUnit_0.IsVehicle)
				{
					if (flag)
					{
						return "Ok";
					}
					return "Vehicles must be on land to unload cargo.";
				}
				if (activeUnit_0.IsShip)
				{
					ActiveUnit cargoObjectActiveUnit = cargo_0.CargoObjectActiveUnit;
					if (((Ship)activeUnit_0).Flags.CanLaunchCargoDirectlyToSea && cargoObjectActiveUnit.IsVehicle && ((Vehicle)cargoObjectActiveUnit).IsOutOfFuel)
					{
						return "Ok";
					}
					if (activeUnit_0.DockingOps.RegisterClient())
					{
						if (activeUnit_0.DockingOps.RevertClient().Count == 0)
						{
							return "This ship can unload cargo to shore but is currently too far from shore (beyond 2nm.)";
						}
						return "Ok";
					}
					if (activeUnit_0.DockFacilities_ReadOnly.Count() > 0 && cargoObjectActiveUnit.IsVehicle && ((Vehicle)cargoObjectActiveUnit).IsOutOfFuel)
					{
						Vehicle vehicle = (Vehicle)cargoObjectActiveUnit;
						if (activeUnit_0.DockingOps.CanHostThisBoat((short)Math.Round(vehicle.Length), vehicle.DockingPhysicalSize) == DockingOpsAttemptResult.Success)
						{
							ActiveUnit_DockingOps dockingOps = activeUnit_0.DockingOps;
							DockFacility dockFacility_ = null;
							if (dockingOps.CanHostThisBoat(cargoObjectActiveUnit, ref dockFacility_))
							{
								return "Ok";
							}
							return "All of this ship's docking facilities that can host that amphibious vehicle are full.";
						}
						return "This ship does not have any docking facilities that can host that amphibious vehicle. Dock at a port facility to unload it.";
					}
					return "Host ship must dock at a port facility to unload the specified cargo item.";
				}
			}
			return "Host unit cannot unload cargo at present location.";
		}
		return "Use the Docking Ops window to transfer cargo for docked units.";
	}

	public static Cargo FindMatchingCargo(List<Cargo> list_0, CargoManifestItem cargoManifestItem_0)
	{
		if (list_0 != null && cargoManifestItem_0 != null)
		{
			foreach (Cargo item in list_0)
			{
				if (cargoManifestItem_0.IsMatch(item))
				{
					return item;
				}
			}
			return null;
		}
		return null;
	}
}
