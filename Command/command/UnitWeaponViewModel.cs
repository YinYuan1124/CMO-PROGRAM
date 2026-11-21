using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class UnitWeaponViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class AuthenticationMap
	{
		public Weapon Weapon;

		internal bool TestInterruptibleMethod(UnitWeaponElementViewModel s)
		{
			return s.Int32_0 == Weapon.DBID;
		}
	}

	public bool mouseOverPanel;

	[CompilerGenerated]
	private List<UnitWeaponElementViewModel> _ListenerExporter;

	[CompilerGenerated]
	private bool _ConfigExporter;

	[CompilerGenerated]
	private List<UnitWeaponElementViewModel> _RegistryExporter;

	[CompilerGenerated]
	private ObservableCollection<UnitWeaponElementViewModel> m_DefinitionExporter;

	public ActiveUnit theUnit;

	public ActiveUnit Last_theUnit;

	[NonSerialized]
	private PropertyChangedEventHandler m_ValExporter;

	private List<UnitWeaponElementViewModel> Weapons
	{
		[CompilerGenerated]
		get
		{
			return _ListenerExporter;
		}
		[CompilerGenerated]
		set
		{
			if (_ListenerExporter != value)
			{
				_ListenerExporter = value;
				OnPropertyChanged("Weapons");
			}
		}
	}

	public bool HasWeapons
	{
		[CompilerGenerated]
		get
		{
			return _ConfigExporter;
		}
		[CompilerGenerated]
		set
		{
			if (_ConfigExporter != value)
			{
				_ConfigExporter = value;
				OnPropertyChanged("HasWeapons");
			}
		}
	}

	public List<UnitWeaponElementViewModel> Weapons_Sorted
	{
		[CompilerGenerated]
		get
		{
			return _RegistryExporter;
		}
		[CompilerGenerated]
		set
		{
			if (_RegistryExporter != value)
			{
				_RegistryExporter = value;
				OnPropertyChanged("Weapons_Sorted");
			}
		}
	}

	public ObservableCollection<UnitWeaponElementViewModel> WeaponsCollection_Sorted
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionExporter;
		}
		[CompilerGenerated]
		set
		{
			if (m_DefinitionExporter != value)
			{
				m_DefinitionExporter = value;
				OnPropertyChanged("WeaponsCollection_Sorted");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ValExporter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ValExporter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ValExporter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ValExporter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	private void SortInterruptibleSetter(Weapon weapon_0, int int_0)
	{
		UnitWeaponElementViewModel unitWeaponElementViewModel = Weapons.FirstOrDefault((UnitWeaponElementViewModel s) => s.Int32_0 == weapon_0.DBID);
		if (unitWeaponElementViewModel == null)
		{
			unitWeaponElementViewModel = new UnitWeaponElementViewModel();
			unitWeaponElementViewModel.Int32_0 = weapon_0.DBID;
			unitWeaponElementViewModel.Name = weapon_0.Name;
			unitWeaponElementViewModel.Qty = 0;
			unitWeaponElementViewModel.Type = (int)weapon_0.Type;
			Weapons.Add(unitWeaponElementViewModel);
		}
		unitWeaponElementViewModel.Qty += int_0;
	}

	public void AddLoadoutWeapons(ActiveUnit activeUnit_0)
	{
		if (((Aircraft)activeUnit_0).Loadout == null)
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
		WeaponRec[] array = weapons;
		foreach (WeaponRec weaponRec in array)
		{
			if (weaponRec.CurrentLoad <= 0)
			{
				continue;
			}
			Weapon referenceWeapon = weaponRec.GetReferenceWeapon(Client.CurrentScenario);
			switch (referenceWeapon.Type)
			{
			case Weapon._WeaponType.SensorPod:
				foreach (WeaponRec weaponWeapon in referenceWeapon.WeaponWeapons)
				{
					if (weaponWeapon.CurrentLoad > 0)
					{
						Weapon referenceWeapon2 = weaponWeapon.GetReferenceWeapon(Client.CurrentScenario);
						SortInterruptibleSetter(referenceWeapon2, weaponWeapon.CurrentLoad);
					}
				}
				break;
			default:
				SortInterruptibleSetter(referenceWeapon, weaponRec.CurrentLoad);
				break;
			case Weapon._WeaponType.TrainingRound:
			case Weapon._WeaponType.DropTank:
			case Weapon._WeaponType.BuddyStore:
			case Weapon._WeaponType.FerryTank:
			case Weapon._WeaponType.HeliTowedPackage:
				break;
			}
		}
	}

	private void CalcInterruptibleSetter(ActiveUnit activeUnit_0)
	{
		foreach (Magazine item in activeUnit_0.SharedMagazines.OrderBy((Magazine theM) => theM.Name))
		{
			if (item.IsAviationMag || item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				if (weapon.CurrentLoad > 0)
				{
					Weapon referenceWeapon = weapon.GetReferenceWeapon(Client.CurrentScenario);
					if (referenceWeapon.Type != Weapon._WeaponType.TrainingRound)
					{
						int currentLoad = weapon.CurrentLoad;
						SortInterruptibleSetter(referenceWeapon, currentLoad);
					}
				}
			}
		}
	}

	private void RateInterruptibleSetter(ActiveUnit activeUnit_0)
	{
		foreach (Mount item in activeUnit_0.Mounts.OrderBy((Mount theM) => theM.Name))
		{
			if (item.Status != 0)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon referenceWeapon = mountWeapon.GetReferenceWeapon(Client.CurrentScenario);
				if (referenceWeapon.Type != Weapon._WeaponType.TrainingRound)
				{
					int num = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMountMagazine(item, mountWeapon.int_0);
					int currentLoad = mountWeapon.CurrentLoad;
					if (num > 0 || currentLoad > 0)
					{
						SortInterruptibleSetter(referenceWeapon, currentLoad + num);
					}
				}
			}
		}
	}

	public UnitWeaponViewModel(ActiveUnit activeUnit_0)
	{
		mouseOverPanel = false;
		Weapons = new List<UnitWeaponElementViewModel>();
		HasWeapons = false;
		WeaponsCollection_Sorted = new ObservableCollection<UnitWeaponElementViewModel>();
		theUnit = activeUnit_0;
		Refresh();
	}

	public void Refresh()
	{
		if (mouseOverPanel || theUnit == null || (theUnit.IsShip && ((Ship)theUnit).IsSinking))
		{
			return;
		}
		if (theUnit.IsActiveUnit)
		{
			if (!theUnit.IsAircraft && !theUnit.IsShip && !theUnit.IsSubmarine && !theUnit.IsFacility && !theUnit.IsSingleUnitAirbase && !theUnit.IsGroup && !theUnit.IsVehicle)
			{
				Weapons.Clear();
				if (Weapons_Sorted != null)
				{
					Weapons_Sorted.Clear();
				}
				WeaponsCollection_Sorted.Clear();
			}
			else
			{
				if (theUnit == Last_theUnit)
				{
					foreach (UnitWeaponElementViewModel weapon in Weapons)
					{
						weapon.Qty = 0;
					}
				}
				else
				{
					Weapons.Clear();
					WeaponsCollection_Sorted.Clear();
				}
				if (theUnit.IsAircraft)
				{
					RateInterruptibleSetter(theUnit);
					AddLoadoutWeapons(theUnit);
				}
				else if (!theUnit.IsShip && !theUnit.IsSubmarine && !theUnit.IsFacility && !theUnit.IsVehicle)
				{
					if (theUnit.IsGroup && ((Group)theUnit).Type == Group.GroupType.AirGroup)
					{
						foreach (ActiveUnit value in ((Group)theUnit).Units.Values)
						{
							RateInterruptibleSetter(value);
							AddLoadoutWeapons(value);
						}
					}
					else if (theUnit.IsGroup)
					{
						foreach (ActiveUnit value2 in ((Group)theUnit).Units.Values)
						{
							RateInterruptibleSetter(value2);
							CalcInterruptibleSetter(value2);
						}
					}
				}
				else
				{
					RateInterruptibleSetter(theUnit);
					CalcInterruptibleSetter(theUnit);
				}
				WeaponsCollection_Sorted.Clear();
				Weapons_Sorted = (from theRec in Weapons
					orderby theRec.Type, theRec.Name
					select theRec).ToList();
				foreach (UnitWeaponElementViewModel item in Weapons_Sorted)
				{
					WeaponsCollection_Sorted.Add(item);
				}
			}
		}
		if (Weapons.Count <= 0)
		{
			HasWeapons = false;
		}
		else
		{
			HasWeapons = true;
		}
		Last_theUnit = theUnit;
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ValExporter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
