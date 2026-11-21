using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class CoreClientCode
{
	public static void UnloadCargoAction_Core(List<Module_Unit.Unit> list_0, List<Cargo> list_1 = null)
	{
		foreach (Module_Unit.Unit item in list_0)
		{
			bool flag = false;
			if (Information.IsNothing(item) || !item.IsActiveUnit)
			{
				continue;
			}
			ActiveUnit activeUnit = (ActiveUnit)item;
			if (activeUnit.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)activeUnit;
				if (aircraft.Loadout.Cargo_ParadropCapable)
				{
					aircraft.AirOps.UnloadCargoParadrop();
					flag = true;
				}
				if (aircraft.OnboardCargo.Count() != 0 && aircraft.IsHelicopter)
				{
					aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.TransferringCargo;
					aircraft.AirOps.ConditionTimer = Math.Max(120, ActiveUnit_DockingOps.TimeToUnloadCargo(aircraft, aircraft.OnboardCargo.ToList()));
					flag = true;
				}
			}
			else if (activeUnit.IsGroup)
			{
				if ((activeUnit is Group) & ((Group)activeUnit).IsLandInstallation)
				{
					foreach (ActiveUnit value in ((Group)activeUnit).Units.Values)
					{
						if (value.OnboardCargo.Count() > 0)
						{
							if (value.CargoTransferList == null)
							{
								Cargo.UnloadCargoAtLocation(value, ref value.OnboardCargo, list_1, value.GetLatitude(), value.GetLongitude(), value.ParentScen, value.GetUnitSide(), bool_0: false);
								break;
							}
							Cargo.UnloadCargoAtLocation(value, ref value.OnboardCargo, value.CargoTransferList, value.GetLatitude(), value.GetLongitude(), value.ParentScen, value.GetUnitSide(), bool_0: false);
							value.CargoTransferList = null;
						}
					}
				}
			}
			else if (list_1 == null)
			{
				if (activeUnit.DockingOps.RegisterClient())
				{
					activeUnit.DockingOps.SettleForCargoTransfer();
					flag = true;
				}
			}
			else
			{
				Cargo.UnloadCargoAtLocation(activeUnit, ref activeUnit.OnboardCargo, list_1, activeUnit.GetLatitude(), activeUnit.GetLongitude(), activeUnit.ParentScen, activeUnit.GetUnitSide(), bool_0: false);
				flag = true;
			}
			if (!item.IsGroup && ((ActiveUnit)item).OnboardCargo.Count() > 0 && !flag)
			{
				((ActiveUnit)item).AddMessage(item.Name + "无法在这里卸货", "Cannot unload cargo", LoggedMessage.MessageType.UI, 0, bool_0: false, new Geopoint_Struct(item.GetLongitude(), item.GetLatitude()));
			}
		}
	}

	public static void CargoOpsAction_Core(List<ActiveUnit> list_0, ActiveUnit activeUnit_0, List<Cargo> list_1)
	{
		if (list_0 == null || list_1 == null)
		{
			return;
		}
		if (activeUnit_0 == null)
		{
			List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
			foreach (ActiveUnit item in list_0)
			{
				item.CargoTransferList = null;
				if (item.OnboardCargo.Count() > 0)
				{
					List<Cargo> list2 = list_1.Intersect(item.OnboardCargo).ToList();
					if (list2.Count > 0)
					{
						item.CargoTransferList = list2;
						list.Add(item);
					}
				}
			}
			UnloadCargoAction_Core(list);
			return;
		}
		foreach (ActiveUnit item2 in list_0)
		{
			item2.CargoTransferList = null;
			if (item2.OnboardCargo.Count() <= 0)
			{
				continue;
			}
			List<Cargo> list3 = list_1.Intersect(item2.OnboardCargo).ToList();
			if (list3.Count <= 0)
			{
				continue;
			}
			ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(item2, activeUnit_0, list3);
			if (item2.IsOperating())
			{
				if (activeUnit_0.IsOperating())
				{
					if (item2.IsVehicle)
					{
						item2.DockingOps.SettleForCargoTransfer();
						item2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo;
						item2.DockingOps.ConditionTimer = Math.Max(item2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(item2, list3));
					}
					else if (activeUnit_0.IsVehicle)
					{
						activeUnit_0.DockingOps.SettleForCargoTransfer();
						activeUnit_0.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo;
						activeUnit_0.DockingOps.ConditionTimer = Math.Max(activeUnit_0.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit_0, list3));
					}
				}
				else if (!activeUnit_0.IsShip && !activeUnit_0.IsVehicle)
				{
					if (activeUnit_0.IsAircraft)
					{
						Aircraft aircraft = (Aircraft)activeUnit_0;
						aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
						aircraft.AirOps.ConditionTimer = Math.Max(aircraft.AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit_0, list3));
					}
				}
				else
				{
					activeUnit_0.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					activeUnit_0.DockingOps.ConditionTimer = Math.Max(activeUnit_0.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(activeUnit_0, list3));
				}
			}
			else if (!item2.IsShip && !item2.IsVehicle)
			{
				if (item2.IsAircraft)
				{
					Aircraft aircraft2 = (Aircraft)item2;
					aircraft2.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
					aircraft2.AirOps.ConditionTimer = Math.Max(aircraft2.AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(item2, list3));
				}
			}
			else
			{
				item2.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
				item2.DockingOps.ConditionTimer = Math.Max(item2.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(item2, list3));
			}
		}
	}
}
