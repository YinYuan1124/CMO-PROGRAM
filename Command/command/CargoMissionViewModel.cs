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
public sealed class CargoMissionViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class WrapperMap
	{
		public ActiveUnit Local_m;

		internal bool MapInterruptibleParam(CargoMissionMothershipUnitViewModel s)
		{
			return s.theUnit == Local_m;
		}
	}

	[CompilerGenerated]
	private sealed class ObserverMap
	{
		public ActiveUnit Local_m0;

		internal bool SortInterruptibleParam(CargoMissionMothershipUnitViewModel s)
		{
			return s.theUnit == Local_m0;
		}
	}

	[CompilerGenerated]
	private sealed class MappingInstanceFilter
	{
		public ActiveUnit Local_m00;

		internal bool CalcInterruptibleParam(CargoMissionMothershipUnitViewModel s)
		{
			return s.theUnit == Local_m00;
		}
	}

	[CompilerGenerated]
	private sealed class ParamsProcessResolver
	{
		public Cargo Local_m_cargo;

		public Func<Ship, bool> _003C_003E9__17;

		public Func<Aircraft, bool> _003C_003E9__19;

		public Func<Vehicle, bool> _003C_003E9__21;

		internal bool RateInterruptibleParam(CargoMissionMothershipCargoMountViewModel s)
		{
			if (s.ObjectType == Local_m_cargo.CurrentType)
			{
				return s.DBID == Local_m_cargo.CargoObjectDBID;
			}
			return false;
		}

		internal bool FlushInterruptibleParam(Ship s)
		{
			return s.Cargo_Type >= Local_m_cargo.RequiredCargoType;
		}

		internal bool ForgotInterruptibleParam(Aircraft s)
		{
			return s.Loadout.Cargo_Type >= Local_m_cargo.RequiredCargoType;
		}

		internal bool CollectInterruptibleParam(Vehicle s)
		{
			return s.Cargo_Type >= Local_m_cargo.RequiredCargoType;
		}
	}

	[CompilerGenerated]
	private sealed class IssuerMap
	{
		public Cargo Local_m_cargo0;

		public Func<Ship, bool> _003C_003E9__24;

		public Func<Aircraft, bool> _003C_003E9__26;

		public Func<Vehicle, bool> _003C_003E9__28;

		internal bool OrderInterruptibleParam(CargoMissionMothershipCargoMountViewModel s)
		{
			if (s.ObjectType == Local_m_cargo0.CurrentType)
			{
				return s.DBID == Local_m_cargo0.CargoObjectDBID;
			}
			return false;
		}

		internal bool RegisterInterruptibleParam(Ship s)
		{
			return s.Cargo_Type >= Local_m_cargo0.RequiredCargoType;
		}

		internal bool ManageInterruptibleParam(Aircraft s)
		{
			return s.Loadout.Cargo_Type >= Local_m_cargo0.RequiredCargoType;
		}

		internal bool RevertInterruptibleParam(Vehicle s)
		{
			return s.Cargo_Type >= Local_m_cargo0.RequiredCargoType;
		}
	}

	[CompilerGenerated]
	private sealed class MockInstanceFilter
	{
		public Ship Local_unit;

		internal float CountInterruptiblePage(ReferencePoint s)
		{
			return s.RangeToPoint_Horiz(Local_unit.DockingOps.GetAssignedHostUnit().GetLongitude(), Local_unit.DockingOps.GetAssignedHostUnit().GetLatitude());
		}
	}

	[CompilerGenerated]
	private sealed class FacadeProcessProducer
	{
		public ActiveUnit Local_theUnit;

		internal bool CustomizeInterruptiblePage(CargoMissionAssignedUnitViewModel s)
		{
			return s.theUnit == Local_theUnit;
		}
	}

	[CompilerGenerated]
	private sealed class InfoCollectionRecord
	{
		public ActiveUnit theUnit;

		internal bool CloneInterruptiblePage(CargoMissionAssignedUnitViewModel s)
		{
			return s.theUnit == theUnit;
		}
	}

	public CargoMission theMission;

	[CompilerGenerated]
	private ObservableCollection<CargoMissionAssignedUnitViewModel> fieldInvocation;

	[CompilerGenerated]
	private ObservableCollection<CargoMissionMothershipUnitViewModel> m_QueueInvocation;

	[CompilerGenerated]
	private ObservableCollection<string> _RegInvocation;

	[CompilerGenerated]
	private ObservableCollection<CargoMissionMothershipCargoMountViewModel> paramInvocation;

	[CompilerGenerated]
	private CargoMissionMothershipCargoMountViewModel m_PageInvocation;

	[CompilerGenerated]
	private RelayCommand m_RulesInvocation;

	[CompilerGenerated]
	private RelayCommand methodInvocation;

	[CompilerGenerated]
	private RelayCommand m_ServiceInvocation;

	[CompilerGenerated]
	private RelayCommand m_SystemInvocation;

	[NonSerialized]
	private PropertyChangedEventHandler candidateInvocation;

	public ObservableCollection<CargoMissionAssignedUnitViewModel> AssignedUnits
	{
		[CompilerGenerated]
		get
		{
			return fieldInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (fieldInvocation != value)
			{
				fieldInvocation = value;
				OnPropertyChanged("AssignedUnits");
			}
		}
	}

	public ObservableCollection<CargoMissionMothershipUnitViewModel> Motherships
	{
		[CompilerGenerated]
		get
		{
			return m_QueueInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_QueueInvocation != value)
			{
				m_QueueInvocation = value;
				OnPropertyChanged("Motherships");
			}
		}
	}

	public ObservableCollection<string> Issues
	{
		[CompilerGenerated]
		get
		{
			return _RegInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (_RegInvocation != value)
			{
				_RegInvocation = value;
				OnPropertyChanged("Issues");
			}
		}
	}

	public ObservableCollection<CargoMissionMothershipCargoMountViewModel> CargoObjects
	{
		[CompilerGenerated]
		get
		{
			return paramInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (paramInvocation != value)
			{
				paramInvocation = value;
				OnPropertyChanged("CargoObjects");
			}
		}
	}

	public CargoMissionMothershipCargoMountViewModel SelectedCargoObject
	{
		[CompilerGenerated]
		get
		{
			return m_PageInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_PageInvocation != value)
			{
				m_PageInvocation = value;
				OnPropertyChanged("SelectedCargoObject");
			}
		}
	}

	public string Units
	{
		get
		{
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				return "ft";
			}
			return "m";
		}
	}

	public float TransitAltitude_Aircraft
	{
		get
		{
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				return 3.28084f * theMission.TransitAltitude_Aircraft;
			}
			return theMission.TransitAltitude_Aircraft;
		}
		set
		{
			if (TransitAltitude_Aircraft != value)
			{
				theMission.TransitAltitude_Aircraft = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (value / 3.28084f) : value);
				OnPropertyChanged("TransitAltitude_Aircraft");
			}
		}
	}

	public float StationAltitude_Aircraft
	{
		get
		{
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				return 3.28084f * theMission.StationAltitude_Aircraft;
			}
			return theMission.StationAltitude_Aircraft;
		}
		set
		{
			if (StationAltitude_Aircraft != value)
			{
				theMission.StationAltitude_Aircraft = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (value / 3.28084f) : value);
				OnPropertyChanged("StationAltitude_Aircraft");
			}
		}
	}

	public int TransitThrottle_Aircraft
	{
		get
		{
			return (int)(theMission.TransitThrottle_Aircraft - 1);
		}
		set
		{
			if (TransitThrottle_Aircraft != value)
			{
				theMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)(value + 1);
				OnPropertyChanged("TransitThrottle_Aircraft");
			}
		}
	}

	public int StationThrottle_Aircraft
	{
		get
		{
			return (int)(theMission.StationThrottle_Aircraft - 1);
		}
		set
		{
			if (StationThrottle_Aircraft != value)
			{
				theMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)(value + 1);
				OnPropertyChanged("StationThrottle_Aircraft");
			}
		}
	}

	public int TransitThrottle_Ship
	{
		get
		{
			return (int)(theMission.TransitThrottle_Ship - 1);
		}
		set
		{
			if (TransitThrottle_Ship != value)
			{
				theMission.TransitThrottle_Ship = (ActiveUnit.Throttle)(value + 1);
				OnPropertyChanged("TransitThrottle_Ship");
			}
		}
	}

	public int StationThrottle_Ship
	{
		get
		{
			return (int)(theMission.StationThrottle_Ship - 1);
		}
		set
		{
			if (StationThrottle_Ship != value)
			{
				theMission.StationThrottle_Ship = (ActiveUnit.Throttle)(value + 1);
				OnPropertyChanged("StationThrottle_Ship");
			}
		}
	}

	public RelayCommand MountUnloadAllCommand
	{
		[CompilerGenerated]
		get
		{
			return m_RulesInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_RulesInvocation != value)
			{
				m_RulesInvocation = value;
				OnPropertyChanged("MountUnloadAllCommand");
			}
		}
	}

	public RelayCommand MountUnloadOneCommand
	{
		[CompilerGenerated]
		get
		{
			return methodInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (methodInvocation != value)
			{
				methodInvocation = value;
				OnPropertyChanged("MountUnloadOneCommand");
			}
		}
	}

	public RelayCommand MountLoadOneCommand
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_ServiceInvocation != value)
			{
				m_ServiceInvocation = value;
				OnPropertyChanged("MountLoadOneCommand");
			}
		}
	}

	public RelayCommand MountLoadAllCommand
	{
		[CompilerGenerated]
		get
		{
			return m_SystemInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_SystemInvocation != value)
			{
				m_SystemInvocation = value;
				OnPropertyChanged("MountLoadAllCommand");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = candidateInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref candidateInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = candidateInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref candidateInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public CargoMissionViewModel(CargoMission cargoMission_0)
	{
		AssignedUnits = new ObservableCollection<CargoMissionAssignedUnitViewModel>();
		Motherships = new ObservableCollection<CargoMissionMothershipUnitViewModel>();
		Issues = new ObservableCollection<string>();
		CargoObjects = new ObservableCollection<CargoMissionMothershipCargoMountViewModel>();
		MountUnloadAllCommand = new RelayCommand(delegate
		{
			MountUnloadAll();
		});
		MountUnloadOneCommand = new RelayCommand(delegate
		{
			MountUnloadOne();
		});
		MountLoadOneCommand = new RelayCommand(delegate
		{
			MountLoadOne();
		});
		MountLoadAllCommand = new RelayCommand(delegate
		{
			MountLoadAll();
		});
		theMission = cargoMission_0;
		foreach (CargoManifestItem item2 in cargoMission_0.CargoToUnload)
		{
			CargoMissionMothershipCargoMountViewModel item = new CargoMissionMothershipCargoMountViewModel(item2.objectType, item2.DBID)
			{
				ToUnload = item2.quantity
			};
			CargoObjects.Add(item);
		}
		foreach (ActiveUnit item3 in Module_Mission.AssetTokenizer(cargoMission_0, Client.CurrentScenario))
		{
			Add(item3);
		}
		InstantiateProccesor();
	}

	private void InstantiateProccesor()
	{
		Issues.Clear();
		if (AssignedUnits.Count == 0)
		{
			Issues.Add("任务中的零个单元");
		}
		if (AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>().Any((Ship s) => s.Cargo_Type == CargoType.NoCargo))
		{
			Issues.Add("已添加一艘无法接收货物的船舶。请仅为此任务添加载货船。");
		}
		if (AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>().Any((Aircraft s) => s.Loadout.Cargo_Type == CargoType.NoCargo))
		{
			Issues.Add("添加了一架根据其挂载情况无法运载货物的飞机");
		}
		if (AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>().Any((Vehicle s) => s.Cargo_Type == CargoType.NoCargo))
		{
			Issues.Add("添加了一个无法运载货物的地面单元。请将能运载货物的单元加入此任务。");
		}
		if (!theMission.IsActive)
		{
			Issues.Add("该任务目前无效。");
		}
		Motherships.Clear();
		foreach (Ship item in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>()
			where s.Cargo_Type != CargoType.NoCargo
			select s)
		{
			ActiveUnit Local_m = item.DockingOps.GetAssignedHostUnit();
			if (Local_m != null && !Motherships.Any((CargoMissionMothershipUnitViewModel s) => s.theUnit == Local_m))
			{
				Motherships.Add(new CargoMissionMothershipUnitViewModel(Local_m));
			}
		}
		foreach (Aircraft item2 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>()
			where s.Loadout.Cargo_Type != CargoType.NoCargo
			select s)
		{
			ActiveUnit Local_m2 = item2.AirOps.GetAssignedHostUnit();
			if (Local_m2 != null && !Motherships.Any((CargoMissionMothershipUnitViewModel s) => s.theUnit == Local_m2))
			{
				Motherships.Add(new CargoMissionMothershipUnitViewModel(Local_m2));
			}
		}
		foreach (Vehicle item3 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>()
			where s.Cargo_Type != CargoType.NoCargo
			select s)
		{
			ActiveUnit Local_m3 = item3.DockingOps.GetAssignedHostUnit();
			if (Local_m3 != null && !Motherships.Any((CargoMissionMothershipUnitViewModel s) => s.theUnit == Local_m3))
			{
				Motherships.Add(new CargoMissionMothershipUnitViewModel(Local_m3));
			}
		}
		foreach (CargoMissionMothershipCargoMountViewModel cargoObject in CargoObjects)
		{
			cargoObject.Available = 0;
		}
		foreach (CargoMissionMothershipUnitViewModel mothership in Motherships)
		{
			if (mothership.theUnit is Group)
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)mothership.theUnit).Units)
				{
					Cargo[] onboardCargo = unit.Value.OnboardCargo;
					Cargo[] array = onboardCargo;
					foreach (Cargo Local_m_cargo in array)
					{
						CargoMissionMothershipCargoMountViewModel cargoMissionMothershipCargoMountViewModel = CargoObjects.FirstOrDefault((CargoMissionMothershipCargoMountViewModel s) => s.ObjectType == Local_m_cargo.CurrentType && s.DBID == Local_m_cargo.CargoObjectDBID);
						if (cargoMissionMothershipCargoMountViewModel == null)
						{
							cargoMissionMothershipCargoMountViewModel = new CargoMissionMothershipCargoMountViewModel(Local_m_cargo.CurrentType, Local_m_cargo.CargoObjectDBID);
							CargoObjects.Add(cargoMissionMothershipCargoMountViewModel);
						}
						cargoMissionMothershipCargoMountViewModel.Available++;
						if (cargoMissionMothershipCargoMountViewModel.Available <= 0)
						{
							continue;
						}
						bool flag = false;
						foreach (Ship item4 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>()
							where s.Cargo_Type >= Local_m_cargo.RequiredCargoType
							select s)
						{
							flag = true;
						}
						foreach (Aircraft item5 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>()
							where s.Loadout.Cargo_Type >= Local_m_cargo.RequiredCargoType
							select s)
						{
							flag = true;
						}
						foreach (Vehicle item6 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>()
							where s.Cargo_Type >= Local_m_cargo.RequiredCargoType
							select s)
						{
							flag = true;
						}
						if (flag)
						{
							cargoMissionMothershipCargoMountViewModel.canMove = true;
						}
						else
						{
							cargoMissionMothershipCargoMountViewModel.canMove = false;
						}
					}
				}
				continue;
			}
			Cargo[] onboardCargo2 = mothership.theUnit.OnboardCargo;
			Cargo[] array2 = onboardCargo2;
			foreach (Cargo Local_m_cargo2 in array2)
			{
				CargoMissionMothershipCargoMountViewModel cargoMissionMothershipCargoMountViewModel2 = CargoObjects.FirstOrDefault((CargoMissionMothershipCargoMountViewModel s) => s.ObjectType == Local_m_cargo2.CurrentType && s.DBID == Local_m_cargo2.CargoObjectDBID);
				if (cargoMissionMothershipCargoMountViewModel2 == null)
				{
					cargoMissionMothershipCargoMountViewModel2 = new CargoMissionMothershipCargoMountViewModel(Local_m_cargo2.CurrentType, Local_m_cargo2.CargoObjectDBID);
					CargoObjects.Add(cargoMissionMothershipCargoMountViewModel2);
				}
				cargoMissionMothershipCargoMountViewModel2.Available++;
				if (cargoMissionMothershipCargoMountViewModel2.Available <= 0)
				{
					continue;
				}
				bool flag2 = false;
				foreach (Ship item7 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>()
					where s.Cargo_Type >= Local_m_cargo2.RequiredCargoType
					select s)
				{
					flag2 = true;
				}
				foreach (Aircraft item8 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>()
					where s.Loadout.Cargo_Type >= Local_m_cargo2.RequiredCargoType
					select s)
				{
					flag2 = true;
				}
				foreach (Vehicle item9 in from s in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>()
					where s.Cargo_Type >= Local_m_cargo2.RequiredCargoType
					select s)
				{
					flag2 = true;
				}
				if (flag2)
				{
					cargoMissionMothershipCargoMountViewModel2.canMove = true;
				}
				else
				{
					cargoMissionMothershipCargoMountViewModel2.canMove = false;
				}
			}
		}
		foreach (Ship Local_unit in AssignedUnits.Select((CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>())
		{
			_ = Local_unit.DockingOps;
			if (Local_unit.OnboardCargo.Count() > 0 && Local_unit.DockingOps.GetAssignedHostUnit() != null)
			{
				float num = Local_unit.Kinematics.TacticalRadius() / 2f;
				CargoMission cargoMission = (CargoMission)Local_unit.AssignedMissionOrPackage();
				float num2 = 0f;
				num2 = ((cargoMission.DestinationUnit == null) ? cargoMission.Area.Select((ReferencePoint s) => s.RangeToPoint_Horiz(Local_unit.DockingOps.GetAssignedHostUnit().GetLongitude(), Local_unit.DockingOps.GetAssignedHostUnit().GetLatitude())).Average() : Module_Unit.RangeToUnit_Horiz(cargoMission.DestinationUnit, Local_unit.DockingOps.GetAssignedHostUnit()));
				if ((double)num2 >= (double)num * 0.75)
				{
					Issues.Add("单元" + Local_unit.Name + "离目的地太远了" + $"{Math.Abs((double)num * 0.75 - (double)num2):0.0}" + "海里发射。");
				}
			}
		}
		foreach (CargoMissionMothershipCargoMountViewModel cargoObject2 in CargoObjects)
		{
			if (cargoObject2.Available > 0 && !cargoObject2.canMove)
			{
				Issues.Add("没有指定单元可以携带" + cargoObject2.Name + ".");
			}
		}
	}

	public void Remove(ActiveUnit activeUnit_0)
	{
		bool flag = false;
		CargoMissionAssignedUnitViewModel[] array = AssignedUnits.Where((CargoMissionAssignedUnitViewModel s) => s.theUnit == activeUnit_0).ToArray();
		CargoMissionAssignedUnitViewModel[] array2 = array;
		foreach (CargoMissionAssignedUnitViewModel item in array2)
		{
			AssignedUnits.Remove(item);
			flag = true;
		}
		if (flag)
		{
			InstantiateProccesor();
		}
	}

	public void Add(ActiveUnit activeUnit_0)
	{
		bool flag = false;
		if (!AssignedUnits.Any((CargoMissionAssignedUnitViewModel s) => s.theUnit == activeUnit_0))
		{
			AssignedUnits.Add(new CargoMissionAssignedUnitViewModel(activeUnit_0));
			flag = true;
		}
		if (flag)
		{
			InstantiateProccesor();
		}
	}

	public void MountUnloadAll()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload = 0;
			CreateProccesor();
		}
	}

	public void MountUnloadOne()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload--;
			if (SelectedCargoObject.ToUnload < 0)
			{
				SelectedCargoObject.ToUnload = 0;
			}
			CreateProccesor();
		}
	}

	public void MountLoadOne()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload++;
			if (SelectedCargoObject.ToUnload > SelectedCargoObject.Available)
			{
				SelectedCargoObject.ToUnload = SelectedCargoObject.Available;
			}
			CreateProccesor();
		}
	}

	public void MountLoadAll()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload = SelectedCargoObject.Available;
			CreateProccesor();
		}
	}

	private void CreateProccesor()
	{
		theMission.CargoToUnload.Clear();
		foreach (CargoMissionMothershipCargoMountViewModel cargoObject in CargoObjects)
		{
			CargoManifestItem cargoManifestItem = new CargoManifestItem(cargoObject.ObjectType, cargoObject.DBID);
			cargoManifestItem.quantity = cargoObject.ToUnload;
			theMission.CargoToUnload.Add(cargoManifestItem);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		candidateInvocation?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void CompareProccesor(object object_0)
	{
		MountUnloadAll();
	}

	[CompilerGenerated]
	private void ReadProccesor(object object_0)
	{
		MountUnloadOne();
	}

	[CompilerGenerated]
	private void DisableProccesor(object object_0)
	{
		MountLoadOne();
	}

	[CompilerGenerated]
	private void UpdateProccesor(object object_0)
	{
		MountLoadAll();
	}
}
