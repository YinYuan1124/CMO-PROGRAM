using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Threading;
using Command.Messages;
using Command_Core;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class SoundHandler_Effects : DispatcherObject
{
	[CompilerGenerated]
	private sealed class PrinterMap
	{
		public SoundHandler_Effects Me;

		public int Local_index;

		internal void RemoveInterruptibleMethod(object sender, EventArgs e)
		{
			Me.Dispatcher.Invoke(delegate
			{
				Me.m_ManagerSingleton[Local_index] = false;
				Me.m_GetterSingleton[Local_index] = "";
			});
		}

		internal void FindInterruptibleMethod()
		{
			Me.m_ManagerSingleton[Local_index] = false;
			Me.m_GetterSingleton[Local_index] = "";
		}

		internal void SetInterruptibleMethod(object sender, EventArgs e)
		{
			Me.Dispatcher.Invoke(delegate
			{
				Me.m_ManagerSingleton[Local_index] = true;
			});
		}

		internal void FillInterruptibleMethod()
		{
			Me.m_ManagerSingleton[Local_index] = true;
		}
	}

	[CompilerGenerated]
	private sealed class ParserMap
	{
		public SoundHandler_Effects _003C_003E4__this;

		public string string_1;

		internal void CalculateInterruptibleMethod()
		{
			_003C_003E4__this.EnableInterruptibleSchema(string_1);
		}
	}

	private string helperSingleton;

	private List<MediaPlayer> mapperSingleton;

	private List<bool> m_ManagerSingleton;

	private List<string> m_GetterSingleton;

	private double _ProducerSingleton;

	private int _ProcSingleton;

	public int Volume
	{
		get
		{
			return _ProcSingleton;
		}
		set
		{
			_ProcSingleton = value;
			_ProducerSingleton = (double)value / 100.0;
			SimConfiguration.DefaultGamePreferences.Int32_0 = value;
		}
	}

	public SoundHandler_Effects()
	{
		mapperSingleton = null;
		m_ManagerSingleton = null;
		m_GetterSingleton = null;
		helperSingleton = ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Sound\\Effects\\";
		ActiveUnit_Weaponry.FiredWeapon += IncludeInterruptibleSchema;
		Weapon.WeaponImpact += SearchInterruptibleSchema;
		Aircraft_AirOps.TookOff += ExcludeInterruptibleSchema;
		ActiveUnit_Sensory.NewContactDetected += SetupInterruptibleSchema;
		PrivateMethods.LuaLocalSound += ChangeInterruptibleSchema;
	}

	private void SetupInterruptibleSchema(Side side_0, Contact_Base.ContactType contactType_0)
	{
		if (SimConfiguration.DefaultGamePreferences.GameSounds && !Information.IsNothing(Client.CurrentSide) && !Information.IsNothing(Client.CurrentSide) && (side_0 == Client.CurrentSide || side_0.GetConsidersThisSideToBe(Client.CurrentSide) == Misc.PostureStance.Friendly))
		{
			switch (contactType_0)
			{
			case Contact_Base.ContactType.Air:
				InitInterruptibleSchema(helperSingleton + "contact_air.mp3");
				break;
			case Contact_Base.ContactType.Missile:
				InitInterruptibleSchema(helperSingleton + "Alert_missile.mp3");
				break;
			case Contact_Base.ContactType.Surface:
				InitInterruptibleSchema(helperSingleton + "contact_surface.mp3");
				break;
			case Contact_Base.ContactType.Submarine:
				InitInterruptibleSchema(helperSingleton + "contact_underwater.mp3");
				break;
			default:
				InitInterruptibleSchema(helperSingleton + "contact_new.mp3");
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
				InitInterruptibleSchema(helperSingleton + "contact_ground.mp3");
				break;
			case Contact_Base.ContactType.Torpedo:
				InitInterruptibleSchema(helperSingleton + "Alert_torpedo.mp3");
				break;
			}
		}
	}

	private void ExcludeInterruptibleSchema(Aircraft aircraft_0)
	{
		if (!SimConfiguration.DefaultGamePreferences.GameSounds || Information.IsNothing(Client.CurrentSide) || aircraft_0.GetUnitSide() != Client.CurrentSide)
		{
			return;
		}
		if (aircraft_0.IsHelicopter)
		{
			InitInterruptibleSchema(helperSingleton + "helo_takeoff.mp3");
		}
		else if (aircraft_0.AirOps.GetAssignedHostUnit().IsShip & !Module_Unit.ResetTokenizer(aircraft_0))
		{
			if ((aircraft_0.Propulsion[0].Type == Engine.EngineType.Turboprop) | (aircraft_0.Propulsion[0].Type == Engine.EngineType.Piston))
			{
				InitInterruptibleSchema(helperSingleton + "airplane_carriertakeoff_prop.mp3");
			}
			else
			{
				InitInterruptibleSchema(helperSingleton + "airplane_carriertakeoff.mp3");
			}
		}
		else if ((aircraft_0.Propulsion[0].Type == Engine.EngineType.Turboprop) | (aircraft_0.Propulsion[0].Type == Engine.EngineType.Piston))
		{
			InitInterruptibleSchema(helperSingleton + "airplane_takeoff_prop.mp3");
		}
		else
		{
			InitInterruptibleSchema(helperSingleton + "airplane_takeoff.mp3");
		}
	}

	private void IncludeInterruptibleSchema(Scenario scenario_0, ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		if (Client.CurrentSide == null || !SimConfiguration.DefaultGamePreferences.GameSounds || !((activeUnit_0.GetUnitSide() == Client.CurrentSide) | Module_Side.IsAlliedWithThisSide(activeUnit_0.GetUnitSide(), Client.CurrentSide)) || scenario_0 != Client.CurrentScenario)
		{
			return;
		}
		switch (weapon_0.Type)
		{
		case Weapon._WeaponType.Laser:
		case Weapon._WeaponType.Microwave:
			InitInterruptibleSchema(helperSingleton + "Gunfire_laser.mp3");
			break;
		case Weapon._WeaponType.Torpedo:
			InitInterruptibleSchema(helperSingleton + "Torpedo_launch.mp3");
			break;
		case Weapon._WeaponType.GuidedWeapon:
			if (weapon_0.Fuel_ReadOnly.Count > 0 && weapon_0.Fuel_ReadOnly[0].FuelType == FuelRec._FuelType.WeaponCoast)
			{
				break;
			}
			if (activeUnit_0.IsAircraft & weapon_0.IsAAW)
			{
				if (weapon_0.HasInfraredSensor)
				{
					InitInterruptibleSchema(helperSingleton + "AAM_IR.mp3");
				}
				else
				{
					InitInterruptibleSchema(helperSingleton + "AAM_Other.mp3");
				}
			}
			else if (activeUnit_0.IsShip)
			{
				InitInterruptibleSchema(helperSingleton + "ship_missilelaunch.mp3");
			}
			else if (activeUnit_0.IsFacility)
			{
				InitInterruptibleSchema(helperSingleton + "ground_missilelaunch.mp3");
			}
			else if (weapon_0.MaxRange_NoTargetType < 10f)
			{
				InitInterruptibleSchema(helperSingleton + "Missile_small.mp3");
			}
			else
			{
				InitInterruptibleSchema(helperSingleton + "Missile_medium.mp3");
			}
			break;
		case Weapon._WeaponType.Rocket:
			InitInterruptibleSchema(helperSingleton + "Rocket_small.mp3");
			break;
		case Weapon._WeaponType.Gun:
			switch (weapon_0.Warheads[0].Caliber)
			{
			default:
				InitInterruptibleSchema(helperSingleton + "Gunfire_152mm.mp3");
				break;
			case Warhead.WarheadCaliber.Gun_6_15mm:
				InitInterruptibleSchema(helperSingleton + "Gunfire_machinegun.mp3");
				break;
			case Warhead.WarheadCaliber.Gun_16_24mm:
				InitInterruptibleSchema(helperSingleton + "Gunfire_20mm.mp3");
				break;
			case Warhead.WarheadCaliber.Gun_25_60mm:
				InitInterruptibleSchema(helperSingleton + "Gunfire_40mm.mp3");
				break;
			case Warhead.WarheadCaliber.Gun_61_80mm:
				InitInterruptibleSchema(helperSingleton + "Gunfire_76mm.mp3");
				break;
			case Warhead.WarheadCaliber.Gun_81_150mm:
				InitInterruptibleSchema(helperSingleton + "Gunfire_100mm.mp3");
				break;
			}
			break;
		}
	}

	private void SearchInterruptibleSchema(Scenario scenario_0, Weapon weapon_0, Module_Unit.Unit unit_0, bool bool_0)
	{
		if (!SimConfiguration.DefaultGamePreferences.GameSounds || Client.CurrentSide == null || ((weapon_0.GetUnitSide() != Client.CurrentSide && weapon_0.GetUnitSide() != null) | (unit_0.GetUnitSide() != null && unit_0.GetUnitSide() == Client.CurrentSide)) || scenario_0 != Client.CurrentScenario)
		{
			return;
		}
		if (weapon_0.Warheads[0].IsCluster)
		{
			InitInterruptibleSchema(helperSingleton + "Impact_cluster.mp3");
		}
		else if (bool_0)
		{
			switch (weapon_0.Type)
			{
			case Weapon._WeaponType.GuidedWeapon:
			case Weapon._WeaponType.IronBomb:
			{
				if (unit_0.IsAircraft)
				{
					InitInterruptibleSchema(helperSingleton + "Explosion_air_medium.mp3");
					break;
				}
				float dP = weapon_0.Warheads[0].DP;
				if (dP < 5f)
				{
					InitInterruptibleSchema(helperSingleton + "Impact_directhit_vsmall.mp3");
				}
				else if (dP < 50f)
				{
					InitInterruptibleSchema(helperSingleton + "Impact_directhit_small.mp3");
				}
				else if (dP < 200f)
				{
					InitInterruptibleSchema(helperSingleton + "Impact_directhit_medium.mp3");
				}
				else
				{
					InitInterruptibleSchema(helperSingleton + "Impact_directhit_large.mp3");
				}
				break;
			}
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.Gun:
				switch (weapon_0.Warheads[0].Caliber)
				{
				case Warhead.WarheadCaliber.Gun_81_150mm:
				case Warhead.WarheadCaliber.Gun_151_200mm:
					InitInterruptibleSchema(helperSingleton + "Impact_directhit_medium.mp3");
					break;
				default:
					InitInterruptibleSchema(helperSingleton + "Impact_directhit_large.mp3");
					break;
				case Warhead.WarheadCaliber.Gun_6_15mm:
				case Warhead.WarheadCaliber.Gun_16_24mm:
				case Warhead.WarheadCaliber.Gun_25_60mm:
				case Warhead.WarheadCaliber.Gun_61_80mm:
					InitInterruptibleSchema(helperSingleton + "Impact_directhit_small.mp3");
					break;
				}
				break;
			}
		}
		else if (Module_Unit.ResetTokenizer(weapon_0))
		{
			switch (weapon_0.Type)
			{
			case Weapon._WeaponType.GuidedWeapon:
			case Weapon._WeaponType.IronBomb:
			{
				float dP2 = weapon_0.Warheads[0].DP;
				if (dP2 < 50f)
				{
					InitInterruptibleSchema(helperSingleton + "Impact_miss_land_small.mp3");
				}
				else if (dP2 < 200f)
				{
					InitInterruptibleSchema(helperSingleton + "Impact_miss_land_medium.mp3");
				}
				else
				{
					InitInterruptibleSchema(helperSingleton + "Impact_miss_land_large.mp3");
				}
				break;
			}
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.Gun:
				switch (weapon_0.Warheads[0].Caliber)
				{
				case Warhead.WarheadCaliber.Gun_81_150mm:
				case Warhead.WarheadCaliber.Gun_151_200mm:
					InitInterruptibleSchema(helperSingleton + "Impact_miss_land_medium.mp3");
					break;
				default:
					InitInterruptibleSchema(helperSingleton + "Impact_miss_land_large.mp3");
					break;
				case Warhead.WarheadCaliber.Gun_6_15mm:
				case Warhead.WarheadCaliber.Gun_16_24mm:
				case Warhead.WarheadCaliber.Gun_25_60mm:
				case Warhead.WarheadCaliber.Gun_61_80mm:
					InitInterruptibleSchema(helperSingleton + "Impact_miss_land_small.mp3");
					break;
				}
				break;
			}
		}
		else
		{
			InitInterruptibleSchema(helperSingleton + "Watersplash_large.mp3");
		}
	}

	private void EnableInterruptibleSchema(string string_0)
	{
		if (mapperSingleton == null)
		{
			mapperSingleton = new List<MediaPlayer>();
			mapperSingleton.AddRange(from s in Enumerable.Range(0, 8)
				select new MediaPlayer());
			m_ManagerSingleton = new List<bool>();
			m_ManagerSingleton.AddRange(from s in Enumerable.Range(0, 8)
				select false);
			m_GetterSingleton = new List<string>();
			m_GetterSingleton.AddRange(from s in Enumerable.Range(0, 8)
				select "");
			int num = 0;
			do
			{
				int Local_index = num;
				mapperSingleton[num].MediaEnded += delegate
				{
					base.Dispatcher.Invoke(delegate
					{
						m_ManagerSingleton[Local_index] = false;
						m_GetterSingleton[Local_index] = "";
					});
				};
				mapperSingleton[num].MediaOpened += delegate
				{
					base.Dispatcher.Invoke(delegate
					{
						m_ManagerSingleton[Local_index] = true;
					});
				};
				m_ManagerSingleton[Local_index] = false;
				num++;
			}
			while (num <= 7);
		}
		if (!m_GetterSingleton.Contains(string_0))
		{
			int num2 = m_ManagerSingleton.IndexOf(item: false);
			if (num2 != -1)
			{
				MediaPlayer mediaPlayer = mapperSingleton.Skip(num2).First();
				mediaPlayer.Volume = _ProducerSingleton;
				mediaPlayer.Open(new Uri(string_0));
				mediaPlayer.Play();
				m_GetterSingleton[num2] = string_0;
			}
		}
	}

	private void ChangeInterruptibleSchema(string string_0, int int_0)
	{
		if (SimConfiguration.DefaultGamePreferences.GameSounds)
		{
			InitInterruptibleSchema(string_0);
		}
	}

	private void InitInterruptibleSchema(string string_0)
	{
		try
		{
			base.Dispatcher.Invoke(delegate
			{
				EnableInterruptibleSchema(string_0);
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200421", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
