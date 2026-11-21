using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Command_Core;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class CargoOpsViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class ComposerRuleWatcher
	{
		public Cargo Local_c;

		internal bool ConnectInterruptiblePage(CargoOpsCargoItemViewModel i)
		{
			if (i.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return i.Cargo.CargoObjectDBID == Local_c.CargoObjectDBID;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class ClientMap
	{
		public CargoOpsCargoItemViewModel Item;

		internal bool MoveInterruptiblePage(CargoOpsCargoItemViewModel I)
		{
			if (I.Cargo.CurrentType == Item.Cargo.CurrentType && I.Cargo.CargoObjectDBID == Item.Cargo.CargoObjectDBID)
			{
				if (Item.Cargo.CurrentType != Cargo.CargoObjectType.Mount)
				{
					return Operators.CompareString(I.Cargo.CargoObjectID, Item.Cargo.CargoObjectID, TextCompare: true) == 0;
				}
				return true;
			}
			return false;
		}

		internal bool DeleteInterruptiblePage(CargoOpsCargoItemViewModel I)
		{
			if (I.Cargo.CurrentType == Item.Cargo.CurrentType && I.Cargo.CargoObjectDBID == Item.Cargo.CargoObjectDBID)
			{
				if (Item.Cargo.CurrentType != Cargo.CargoObjectType.Mount)
				{
					return Operators.CompareString(I.Cargo.CargoObjectID, Item.Cargo.CargoObjectID, TextCompare: true) == 0;
				}
				return true;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class FieldCallbackCandidate
	{
		public Cargo Local_thisCargo;

		internal bool AddInterruptiblePage(Cargo oc)
		{
			if (oc.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return oc.CargoObjectDBID == Local_thisCargo.CargoObjectDBID;
			}
			return false;
		}

		internal bool DestroyInterruptiblePage(Cargo oc)
		{
			return Operators.CompareString(oc.CargoObjectID, Local_thisCargo.CargoObjectID, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class DicMap
	{
		public CargoOpsCargoItemViewModel Local_C;

		internal bool ComputeInterruptiblePage(Cargo OC)
		{
			if (OC.CurrentType == Local_C.Cargo.CurrentType && OC.CargoObjectDBID == Local_C.Cargo.CargoObjectDBID && Local_C.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return true;
			}
			return Operators.CompareString(OC.CargoObjectID, Local_C.Cargo.CargoObjectID, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class ConsumerMap
	{
		public CargoOpsCargoItemViewModel Local_C0;

		internal bool PatchInterruptiblePage(Cargo OC)
		{
			if (OC.CurrentType == Local_C0.Cargo.CurrentType && OC.CargoObjectDBID == Local_C0.Cargo.CargoObjectDBID && Local_C0.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return true;
			}
			return Operators.CompareString(OC.CargoObjectID, Local_C0.Cargo.CargoObjectID, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class QueueCallbackCandidate
	{
		public CargoOpsCargoItemViewModel Local_C00;

		internal bool SelectInterruptiblePage(Cargo OC)
		{
			if (OC.CurrentType == Local_C00.Cargo.CurrentType && OC.CargoObjectDBID == Local_C00.Cargo.CargoObjectDBID && Local_C00.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return true;
			}
			return Operators.CompareString(OC.CargoObjectID, Local_C00.Cargo.CargoObjectID, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private CargoOps specificationClass;

	[CompilerGenerated]
	private ActiveUnit m_WatcherClass;

	[CompilerGenerated]
	private ActiveUnit reponseClass;

	[CompilerGenerated]
	private ObservableCollection<CargoOpsCargoItemViewModel> descriptorClass;

	[CompilerGenerated]
	private CargoOpsCargoItemViewModel _PoolClass;

	[CompilerGenerated]
	private double m_TaskClass;

	[CompilerGenerated]
	private double _FilterClass;

	[CompilerGenerated]
	private double testsClass;

	[CompilerGenerated]
	private double interpreterClass;

	[CompilerGenerated]
	private double _ContainerClass;

	[CompilerGenerated]
	private double _ComposerClass;

	[CompilerGenerated]
	private CargoType m_ModelClass;

	[CompilerGenerated]
	private string advisorClass;

	[CompilerGenerated]
	private bool _CustomerClass;

	private Cargo[] _SerializerClass;

	private Collection<ActiveUnit> refClass;

	[CompilerGenerated]
	private ObservableCollection<CargoOpsCargoItemViewModel> m_ErrorClass;

	[CompilerGenerated]
	private CargoOpsCargoItemViewModel m_CodeClass;

	[CompilerGenerated]
	private double m_ConnectionClass;

	[CompilerGenerated]
	private double _ContextClass;

	[CompilerGenerated]
	private double _StatusClass;

	[CompilerGenerated]
	private double proccesorClass;

	[CompilerGenerated]
	private double strategyClass;

	[CompilerGenerated]
	private double m_ConfigurationClass;

	[CompilerGenerated]
	private CargoType tokenClass;

	[CompilerGenerated]
	private string _IndexerClass;

	[CompilerGenerated]
	private bool m_ResolverClass;

	[CompilerGenerated]
	private DataTable m_PublisherClass;

	[CompilerGenerated]
	private RelayCommand _ServerClass;

	[CompilerGenerated]
	private RelayCommand m_AdapterClass;

	[CompilerGenerated]
	private RelayCommand _SchemaClass;

	[CompilerGenerated]
	private RelayCommand _UtilsClass;

	[CompilerGenerated]
	private RelayCommand _PredicateClass;

	[CompilerGenerated]
	private RelayCommand m_SingletonClass;

	[NonSerialized]
	private PropertyChangedEventHandler m_RecordClass;

	public CargoOps Form
	{
		[CompilerGenerated]
		get
		{
			return specificationClass;
		}
		[CompilerGenerated]
		set
		{
			if (specificationClass != value)
			{
				specificationClass = value;
				OnPropertyChanged("Form");
			}
		}
	}

	public ActiveUnit Host
	{
		[CompilerGenerated]
		get
		{
			return m_WatcherClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_WatcherClass != value)
			{
				m_WatcherClass = value;
				OnPropertyChanged("Host");
			}
		}
	}

	public ActiveUnit Target
	{
		[CompilerGenerated]
		get
		{
			return reponseClass;
		}
		[CompilerGenerated]
		set
		{
			if (reponseClass != value)
			{
				reponseClass = value;
				OnPropertyChanged("Target");
			}
		}
	}

	public ObservableCollection<CargoOpsCargoItemViewModel> HostInventory
	{
		[CompilerGenerated]
		get
		{
			return descriptorClass;
		}
		[CompilerGenerated]
		set
		{
			if (descriptorClass != value)
			{
				descriptorClass = value;
				OnPropertyChanged("HostInventory");
			}
		}
	}

	public CargoOpsCargoItemViewModel HostSelectedItem
	{
		[CompilerGenerated]
		get
		{
			return _PoolClass;
		}
		[CompilerGenerated]
		set
		{
			if (_PoolClass != value)
			{
				_PoolClass = value;
				OnPropertyChanged("LoadVisibility");
				OnPropertyChanged("UnloadVisibility");
				OnPropertyChanged("HostSelectedItem");
			}
		}
	}

	public double HostRequiredMass
	{
		[CompilerGenerated]
		get
		{
			return m_TaskClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_TaskClass != value)
			{
				m_TaskClass = value;
				OnPropertyChanged("HostRequiredMass");
			}
		}
	}

	public double HostRequiredArea
	{
		[CompilerGenerated]
		get
		{
			return _FilterClass;
		}
		[CompilerGenerated]
		set
		{
			if (_FilterClass != value)
			{
				_FilterClass = value;
				OnPropertyChanged("HostRequiredArea");
			}
		}
	}

	public double HostRequiredCrew
	{
		[CompilerGenerated]
		get
		{
			return testsClass;
		}
		[CompilerGenerated]
		set
		{
			if (testsClass != value)
			{
				testsClass = value;
				OnPropertyChanged("HostRequiredCrew");
			}
		}
	}

	public double HostTotalMass
	{
		[CompilerGenerated]
		get
		{
			return interpreterClass;
		}
		[CompilerGenerated]
		set
		{
			if (interpreterClass != value)
			{
				interpreterClass = value;
				OnPropertyChanged("HostTotalMass");
			}
		}
	}

	public double HostTotalArea
	{
		[CompilerGenerated]
		get
		{
			return _ContainerClass;
		}
		[CompilerGenerated]
		set
		{
			if (_ContainerClass != value)
			{
				_ContainerClass = value;
				OnPropertyChanged("HostTotalArea");
			}
		}
	}

	public double HostTotalCrew
	{
		[CompilerGenerated]
		get
		{
			return _ComposerClass;
		}
		[CompilerGenerated]
		set
		{
			if (_ComposerClass != value)
			{
				_ComposerClass = value;
				OnPropertyChanged("HostTotalCrew");
			}
		}
	}

	public CargoType HostType
	{
		[CompilerGenerated]
		get
		{
			return m_ModelClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_ModelClass != value)
			{
				m_ModelClass = value;
				OnPropertyChanged("HostType");
			}
		}
	}

	public string HostName
	{
		[CompilerGenerated]
		get
		{
			return advisorClass;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(advisorClass, value, StringComparison.Ordinal))
			{
				advisorClass = value;
				OnPropertyChanged("HostName");
			}
		}
	}

	public bool HostIsGroup
	{
		[CompilerGenerated]
		get
		{
			return _CustomerClass;
		}
		[CompilerGenerated]
		set
		{
			if (_CustomerClass != value)
			{
				_CustomerClass = value;
				OnPropertyChanged("HostIsGroup");
			}
		}
	}

	public ObservableCollection<CargoOpsCargoItemViewModel> TargetInventory
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_ErrorClass != value)
			{
				m_ErrorClass = value;
				OnPropertyChanged("TargetInventory");
			}
		}
	}

	public CargoOpsCargoItemViewModel TargetSelectedItem
	{
		[CompilerGenerated]
		get
		{
			return m_CodeClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_CodeClass != value)
			{
				m_CodeClass = value;
				OnPropertyChanged("LoadVisibility");
				OnPropertyChanged("UnloadVisibility");
				OnPropertyChanged("TargetSelectedItem");
			}
		}
	}

	public double TargetRequiredMass
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_ConnectionClass != value)
			{
				m_ConnectionClass = value;
				OnPropertyChanged("TargetRequiredMass");
			}
		}
	}

	public double TargetRequiredArea
	{
		[CompilerGenerated]
		get
		{
			return _ContextClass;
		}
		[CompilerGenerated]
		set
		{
			if (_ContextClass != value)
			{
				_ContextClass = value;
				OnPropertyChanged("TargetRequiredArea");
			}
		}
	}

	public double TargetRequiredCrew
	{
		[CompilerGenerated]
		get
		{
			return _StatusClass;
		}
		[CompilerGenerated]
		set
		{
			if (_StatusClass != value)
			{
				_StatusClass = value;
				OnPropertyChanged("TargetRequiredCrew");
			}
		}
	}

	public double TargetTotalMass
	{
		[CompilerGenerated]
		get
		{
			return proccesorClass;
		}
		[CompilerGenerated]
		set
		{
			if (proccesorClass != value)
			{
				proccesorClass = value;
				OnPropertyChanged("TargetTotalMass");
			}
		}
	}

	public double TargetTotalArea
	{
		[CompilerGenerated]
		get
		{
			return strategyClass;
		}
		[CompilerGenerated]
		set
		{
			if (strategyClass != value)
			{
				strategyClass = value;
				OnPropertyChanged("TargetTotalArea");
			}
		}
	}

	public double TargetTotalCrew
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_ConfigurationClass != value)
			{
				m_ConfigurationClass = value;
				OnPropertyChanged("TargetTotalCrew");
			}
		}
	}

	public CargoType TargetType
	{
		[CompilerGenerated]
		get
		{
			return tokenClass;
		}
		[CompilerGenerated]
		set
		{
			if (tokenClass != value)
			{
				tokenClass = value;
				OnPropertyChanged("TargetType");
			}
		}
	}

	public string TargetName
	{
		[CompilerGenerated]
		get
		{
			return _IndexerClass;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_IndexerClass, value, StringComparison.Ordinal))
			{
				_IndexerClass = value;
				OnPropertyChanged("TargetName");
			}
		}
	}

	public bool Exchange
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_ResolverClass != value)
			{
				m_ResolverClass = value;
				OnPropertyChanged("ExchangeVisibility");
				OnPropertyChanged("ExchangeVisibilityInverse");
				OnPropertyChanged("LoadVisibility");
				OnPropertyChanged("UnloadVisibility");
				OnPropertyChanged("Exchange");
			}
		}
	}

	public Visibility ExchangeVisibility
	{
		get
		{
			if (Exchange)
			{
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}
	}

	public Visibility ExchangeVisibilityInverse
	{
		get
		{
			if (Exchange)
			{
				return Visibility.Collapsed;
			}
			return Visibility.Visible;
		}
	}

	public Visibility LoadVisibility
	{
		get
		{
			if (TargetSelectedItem != null && (TargetSelectedItem.CargoTypeLimited || TargetSelectedItem.IsUnitHeader))
			{
				return Visibility.Collapsed;
			}
			if (HostSelectedItem != null && HostSelectedItem.IsUnitHeader)
			{
				return Visibility.Collapsed;
			}
			if (Exchange)
			{
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}
	}

	public Visibility UnloadVisibility
	{
		get
		{
			if (TargetSelectedItem != null && (TargetSelectedItem.CargoTypeLimited || TargetSelectedItem.IsUnitHeader))
			{
				return Visibility.Collapsed;
			}
			if (HostSelectedItem != null && HostSelectedItem.IsUnitHeader)
			{
				return Visibility.Collapsed;
			}
			if (Exchange)
			{
				return Visibility.Visible;
			}
			return Visibility.Collapsed;
		}
	}

	public DataTable AllCargoItems
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_PublisherClass != value)
			{
				m_PublisherClass = value;
				OnPropertyChanged("AllCargoItems");
			}
		}
	}

	public RelayCommand UnloadAllCommand
	{
		[CompilerGenerated]
		get
		{
			return _ServerClass;
		}
		[CompilerGenerated]
		set
		{
			if (_ServerClass != value)
			{
				_ServerClass = value;
				OnPropertyChanged("UnloadAllCommand");
			}
		}
	}

	public RelayCommand UnloadOneCommand
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_AdapterClass != value)
			{
				m_AdapterClass = value;
				OnPropertyChanged("UnloadOneCommand");
			}
		}
	}

	public RelayCommand LoadOneCommand
	{
		[CompilerGenerated]
		get
		{
			return _SchemaClass;
		}
		[CompilerGenerated]
		set
		{
			if (_SchemaClass != value)
			{
				_SchemaClass = value;
				OnPropertyChanged("LoadOneCommand");
			}
		}
	}

	public RelayCommand LoadAllCommand
	{
		[CompilerGenerated]
		get
		{
			return _UtilsClass;
		}
		[CompilerGenerated]
		set
		{
			if (_UtilsClass != value)
			{
				_UtilsClass = value;
				OnPropertyChanged("LoadAllCommand");
			}
		}
	}

	public RelayCommand RelayCommand_0
	{
		[CompilerGenerated]
		get
		{
			return _PredicateClass;
		}
		[CompilerGenerated]
		set
		{
			if (_PredicateClass != value)
			{
				_PredicateClass = value;
				OnPropertyChanged("OKCommand");
			}
		}
	}

	public RelayCommand CancelCommand
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonClass;
		}
		[CompilerGenerated]
		set
		{
			if (m_SingletonClass != value)
			{
				m_SingletonClass = value;
				OnPropertyChanged("CancelCommand");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_RecordClass;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_RecordClass, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_RecordClass;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_RecordClass, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	private void LoginStrategy()
	{
		HostRequiredMass = HostInventory.Select((CargoOpsCargoItemViewModel C) => C.Cargo.RequiredMass * (float)C.Quantity).Sum((float x) => x);
		HostRequiredArea = HostInventory.Select((CargoOpsCargoItemViewModel C) => C.Cargo.RequiredArea * (float)C.Quantity).Sum((float x) => x);
		HostRequiredCrew = HostInventory.Select((CargoOpsCargoItemViewModel C) => C.Cargo.RequiredCrewSpace * (float)C.Quantity).Sum((float x) => x);
		if (Target == null)
		{
			return;
		}
		ICargoHost obj = (ICargoHost)Target;
		float cargo_Mass = obj.GetCargo_Mass();
		float cargo_Area = obj.GetCargo_Area();
		float cargo_Crew = obj.GetCargo_Crew();
		TargetRequiredMass = TargetInventory.Select((CargoOpsCargoItemViewModel C) => C.Cargo.RequiredMass * (float)C.Quantity).Sum((float x) => x);
		TargetRequiredArea = TargetInventory.Select((CargoOpsCargoItemViewModel C) => C.Cargo.RequiredArea * (float)C.Quantity).Sum((float x) => x);
		TargetRequiredCrew = TargetInventory.Select((CargoOpsCargoItemViewModel C) => C.Cargo.RequiredCrewSpace * (float)C.Quantity).Sum((float x) => x);
		foreach (CargoOpsCargoItemViewModel item in TargetInventory)
		{
			if ((item.CargoType > HostType) | (item.CargoType > TargetType))
			{
				item.CargoTypeLimited = true;
			}
		}
		cargo_Mass = (float)((double)cargo_Mass - TargetRequiredMass);
		cargo_Area = (float)((double)cargo_Area - TargetRequiredArea);
		cargo_Crew = (float)((double)cargo_Crew - TargetRequiredCrew);
		foreach (CargoOpsCargoItemViewModel item2 in HostInventory)
		{
			if (!item2.CargoTypeLimited && (item2.CrewPerUnit > (double)cargo_Crew || item2.MassPerUnit > (double)cargo_Mass || item2.AreaPerUnit > (double)cargo_Area))
			{
				item2.CargoTypeLimited = true;
			}
		}
	}

	private void GetStrategy(ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_0, List<ActiveUnit> list_0)
	{
		bool flag = list_0.Count > 1;
		foreach (ActiveUnit item3 in list_0)
		{
			if (item3.OnboardCargo.Count() == 0)
			{
				continue;
			}
			if (flag)
			{
				Cargo cargo = new Cargo(item3);
				cargo.Name = item3.Name;
				CargoOpsCargoItemViewModel item = new CargoOpsCargoItemViewModel
				{
					Cargo = cargo,
					Quantity = 0,
					InitialQuantity = 0,
					IsUnitHeader = true
				};
				observableCollection_0.Add(item);
			}
			Cargo[] onboardCargo = item3.OnboardCargo;
			Cargo[] array = onboardCargo;
			foreach (Cargo Local_c in array)
			{
				if (Local_c.CurrentType == Cargo.CargoObjectType.Mount)
				{
					CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel = null;
					List<CargoOpsCargoItemViewModel> list = observableCollection_0.Where((CargoOpsCargoItemViewModel i) => i.Cargo.CurrentType == Cargo.CargoObjectType.Mount && i.Cargo.CargoObjectDBID == Local_c.CargoObjectDBID).ToList();
					if (list.Count > 0)
					{
						cargoOpsCargoItemViewModel = list.First();
					}
					if (cargoOpsCargoItemViewModel == null)
					{
						cargoOpsCargoItemViewModel = new CargoOpsCargoItemViewModel
						{
							Cargo = Local_c,
							Quantity = 1,
							InitialQuantity = 1
						};
						observableCollection_0.Add(cargoOpsCargoItemViewModel);
					}
					else
					{
						cargoOpsCargoItemViewModel.Quantity++;
						cargoOpsCargoItemViewModel.InitialQuantity++;
					}
				}
				else
				{
					CargoOpsCargoItemViewModel item2 = new CargoOpsCargoItemViewModel
					{
						Cargo = Local_c,
						Quantity = 1,
						InitialQuantity = 1
					};
					observableCollection_0.Add(item2);
				}
			}
		}
	}

	public CargoOpsViewModel(CargoOps cargoOps_0, ActiveUnit activeUnit_0, ActiveUnit activeUnit_1)
	{
		HostInventory = new ObservableCollection<CargoOpsCargoItemViewModel>();
		_SerializerClass = new Cargo[0];
		refClass = new Collection<ActiveUnit>();
		TargetInventory = new ObservableCollection<CargoOpsCargoItemViewModel>();
		UnloadAllCommand = new RelayCommand(delegate
		{
			UnloadAll();
		});
		UnloadOneCommand = new RelayCommand(delegate
		{
			UnloadOne();
		});
		LoadOneCommand = new RelayCommand(delegate
		{
			LoadOne();
		});
		LoadAllCommand = new RelayCommand(delegate
		{
			LoadAll();
		});
		RelayCommand_0 = new RelayCommand(delegate
		{
			OK();
		});
		CancelCommand = new RelayCommand(delegate
		{
			Cancel();
		});
		Form = cargoOps_0;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		AllCargoItems = DBFunctions.GetAllCargoItems(ref sqliteConnection_);
		Host = activeUnit_0;
		Target = activeUnit_1;
		if (Target == null)
		{
			Exchange = false;
		}
		else
		{
			Exchange = true;
		}
		if (Host == null)
		{
			if (Target is Aircraft)
			{
				Aircraft_AirOps airOps = ((Aircraft)Target).AirOps;
				Host = airOps.CurrentHostUnit;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (Host.IsGroup)
		{
			cargoOps_0.Text = "Cargo " + Host.Name + " [Group]";
		}
		else
		{
			cargoOps_0.Text = "货物" + Host.Name;
		}
		HostName = Host.Name;
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (Host is Group)
		{
			Group obj = (Group)Host;
			_SerializerClass = new Cargo[0];
			HostTotalMass = 0.0;
			HostTotalArea = 0.0;
			HostTotalCrew = 0.0;
			HostType = CargoType.const_5;
			HostIsGroup = true;
			foreach (KeyValuePair<string, ActiveUnit> unit in obj.Units)
			{
				ICargoHost cargoHost = (ICargoHost)unit.Value;
				HostTotalMass += cargoHost.GetCargo_Mass();
				HostTotalArea += cargoHost.GetCargo_Area();
				HostTotalCrew += cargoHost.GetCargo_Crew();
				Cargo[] onboardCargo = unit.Value.OnboardCargo;
				Cargo[] array = onboardCargo;
				foreach (Cargo theAC in array)
				{
					ArrayExtensions.Add(ref _SerializerClass, theAC);
				}
				refClass.Add(unit.Value);
				list.Add(unit.Value);
			}
		}
		else
		{
			ICargoHost cargoHost2 = (ICargoHost)Host;
			HostTotalMass = cargoHost2.GetCargo_Mass();
			HostTotalArea = cargoHost2.GetCargo_Area();
			HostTotalCrew = cargoHost2.GetCargo_Crew();
			HostType = cargoHost2.GetCargo_Type();
			_SerializerClass = Host.OnboardCargo;
			list.Add(Host);
		}
		GetStrategy(HostInventory, list);
		if (Target != null)
		{
			cargoOps_0.Text = "Cargo Exchange " + Host.Name + " <=> " + Target.Name;
			TargetName = Target.Name;
			ICargoHost cargoHost3 = (ICargoHost)Target;
			TargetTotalMass = cargoHost3.GetCargo_Mass();
			TargetTotalArea = cargoHost3.GetCargo_Area();
			TargetTotalCrew = cargoHost3.GetCargo_Crew();
			TargetType = cargoHost3.GetCargo_Type();
			list.Clear();
			list.Add(Target);
			GetStrategy(TargetInventory, list);
		}
		LoginStrategy();
	}

	private void WriteStrategy(CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel_0, ActiveUnit activeUnit_0, ref ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_0, ref ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_1, int int_0, double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		if (cargoOpsCargoItemViewModel_0 == null || cargoOpsCargoItemViewModel_0.IsUnitHeader || cargoOpsCargoItemViewModel_0.Quantity <= 0 || cargoOpsCargoItemViewModel_0.CargoTypeLimited)
		{
			return;
		}
		double massPerUnit = cargoOpsCargoItemViewModel_0.MassPerUnit;
		double areaPerUnit = cargoOpsCargoItemViewModel_0.AreaPerUnit;
		double crewPerUnit = cargoOpsCargoItemViewModel_0.CrewPerUnit;
		double num = (double_1 - double_0) / massPerUnit;
		double num2 = (double_3 - double_2) / areaPerUnit;
		double num3 = (double_5 - double_4) / crewPerUnit;
		CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel = observableCollection_0.First((CargoOpsCargoItemViewModel I) => I.Cargo.CurrentType == cargoOpsCargoItemViewModel_0.Cargo.CurrentType && I.Cargo.CargoObjectDBID == cargoOpsCargoItemViewModel_0.Cargo.CargoObjectDBID && (cargoOpsCargoItemViewModel_0.Cargo.CurrentType == Cargo.CargoObjectType.Mount || Operators.CompareString(I.Cargo.CargoObjectID, cargoOpsCargoItemViewModel_0.Cargo.CargoObjectID, TextCompare: true) == 0));
		int num4 = (int)Math.Floor(new double[5] { int_0, num, num2, num3, cargoOpsCargoItemViewModel.Quantity }.Where((double s) => !double.IsNaN(s)).ToArray().Min());
		if (num4 != 0)
		{
			CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel2 = observableCollection_1.FirstOrDefault((CargoOpsCargoItemViewModel I) => I.Cargo.CurrentType == cargoOpsCargoItemViewModel_0.Cargo.CurrentType && I.Cargo.CargoObjectDBID == cargoOpsCargoItemViewModel_0.Cargo.CargoObjectDBID && (cargoOpsCargoItemViewModel_0.Cargo.CurrentType == Cargo.CargoObjectType.Mount || Operators.CompareString(I.Cargo.CargoObjectID, cargoOpsCargoItemViewModel_0.Cargo.CargoObjectID, TextCompare: true) == 0));
			if (cargoOpsCargoItemViewModel2 == null)
			{
				cargoOpsCargoItemViewModel2 = new CargoOpsCargoItemViewModel
				{
					Cargo = cargoOpsCargoItemViewModel_0.Cargo,
					Quantity = 0,
					InitialQuantity = 0
				};
				observableCollection_1.Add(cargoOpsCargoItemViewModel2);
			}
			cargoOpsCargoItemViewModel2.Quantity += num4;
			cargoOpsCargoItemViewModel.Quantity -= num4;
			LoginStrategy();
		}
	}

	public void UnloadAll()
	{
		if (TargetSelectedItem != null)
		{
			CargoOpsCargoItemViewModel targetSelectedItem = TargetSelectedItem;
			ActiveUnit host = Host;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = TargetInventory;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = HostInventory;
			WriteStrategy(targetSelectedItem, host, ref observableCollection_, ref observableCollection_2, TargetSelectedItem.Quantity, HostRequiredMass, HostTotalMass, HostRequiredArea, HostTotalArea, HostRequiredCrew, HostTotalCrew);
			HostInventory = observableCollection_2;
			TargetInventory = observableCollection_;
		}
	}

	public void UnloadOne()
	{
		CargoOpsCargoItemViewModel targetSelectedItem = TargetSelectedItem;
		ActiveUnit host = Host;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = TargetInventory;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = HostInventory;
		WriteStrategy(targetSelectedItem, host, ref observableCollection_, ref observableCollection_2, 1, HostRequiredMass, HostTotalMass, HostRequiredArea, HostTotalArea, HostRequiredCrew, HostTotalCrew);
		HostInventory = observableCollection_2;
		TargetInventory = observableCollection_;
	}

	public void LoadOne()
	{
		CargoOpsCargoItemViewModel hostSelectedItem = HostSelectedItem;
		ActiveUnit target = Target;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = HostInventory;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = TargetInventory;
		WriteStrategy(hostSelectedItem, target, ref observableCollection_, ref observableCollection_2, 1, TargetRequiredMass, TargetTotalMass, TargetRequiredArea, TargetTotalArea, TargetRequiredCrew, TargetTotalCrew);
		TargetInventory = observableCollection_2;
		HostInventory = observableCollection_;
	}

	public void LoadAll()
	{
		if (HostSelectedItem != null)
		{
			CargoOpsCargoItemViewModel hostSelectedItem = HostSelectedItem;
			ActiveUnit target = Target;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = HostInventory;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = TargetInventory;
			WriteStrategy(hostSelectedItem, target, ref observableCollection_, ref observableCollection_2, HostSelectedItem.Quantity, TargetRequiredMass, TargetTotalMass, TargetRequiredArea, TargetTotalArea, TargetRequiredCrew, TargetTotalCrew);
			TargetInventory = observableCollection_2;
			HostInventory = observableCollection_;
		}
	}

	public void OK()
	{
		if (HostIsGroup)
		{
			Dictionary<Cargo, int> dictionary = new Dictionary<Cargo, int>();
			Dictionary<Cargo, int> dictionary2 = new Dictionary<Cargo, int>();
			foreach (CargoOpsCargoItemViewModel item in HostInventory)
			{
				if (item.Quantity < item.InitialQuantity)
				{
					int value = item.InitialQuantity - item.Quantity;
					dictionary[item.Cargo] = value;
				}
			}
			foreach (CargoOpsCargoItemViewModel item2 in TargetInventory)
			{
				if (item2.Quantity < item2.InitialQuantity)
				{
					int value2 = item2.InitialQuantity - item2.Quantity;
					dictionary2[item2.Cargo] = value2;
				}
			}
			foreach (ActiveUnit item3 in refClass)
			{
				List<Cargo> list = new List<Cargo>();
				int num = dictionary.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Cargo Local_thisCargo = dictionary.Keys.ElementAtOrDefault(i);
					int num2 = dictionary.Values.ElementAtOrDefault(i);
					if (num2 > 0)
					{
						Cargo[] source = ((Local_thisCargo.CurrentType == Cargo.CargoObjectType.Mount) ? item3.OnboardCargo.Where((Cargo oc) => oc.CurrentType == Cargo.CargoObjectType.Mount && oc.CargoObjectDBID == Local_thisCargo.CargoObjectDBID).ToArray() : item3.OnboardCargo.Where((Cargo oc) => Operators.CompareString(oc.CargoObjectID, Local_thisCargo.CargoObjectID, TextCompare: true) == 0).ToArray());
						num2 = Math.Min(num2, source.Count());
						if (num2 > 0)
						{
							list.AddRange(source.Take(num2));
							dictionary[Local_thisCargo] -= num2;
						}
					}
				}
				if (list.Count <= 0)
				{
					continue;
				}
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(item3, Target, list);
				if (!(Target is Ship) && !(Target is Vehicle))
				{
					if (Target is Aircraft)
					{
						((Aircraft)Target).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
						((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list));
					}
				}
				else
				{
					Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list));
				}
			}
			List<Cargo> list2 = new List<Cargo>();
			ActiveUnit value3 = ((Group)Host).Units.First().Value;
			foreach (CargoOpsCargoItemViewModel Local_C in TargetInventory)
			{
				if (Local_C.Quantity < Local_C.InitialQuantity)
				{
					int count = Local_C.InitialQuantity - Local_C.Quantity;
					list2.AddRange(Target.OnboardCargo.Where((Cargo OC) => (OC.CurrentType == Local_C.Cargo.CurrentType && OC.CargoObjectDBID == Local_C.Cargo.CargoObjectDBID && Local_C.Cargo.CurrentType == Cargo.CargoObjectType.Mount) || Operators.CompareString(OC.CargoObjectID, Local_C.Cargo.CargoObjectID, TextCompare: true) == 0).Take(count));
				}
			}
			if (list2.Count > 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(Target, value3, list2);
				if (!(Target is Ship) && !(Target is Vehicle))
				{
					if (Target is Aircraft)
					{
						((Aircraft)Target).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
						((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list2));
					}
				}
				else
				{
					Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list2));
				}
			}
		}
		else
		{
			List<Cargo> list3 = new List<Cargo>();
			List<Cargo> list4 = new List<Cargo>();
			foreach (CargoOpsCargoItemViewModel Local_C2 in HostInventory)
			{
				if (Local_C2.Quantity < Local_C2.InitialQuantity)
				{
					int count2 = Local_C2.InitialQuantity - Local_C2.Quantity;
					list3.AddRange(Host.OnboardCargo.Where((Cargo OC) => (OC.CurrentType == Local_C2.Cargo.CurrentType && OC.CargoObjectDBID == Local_C2.Cargo.CargoObjectDBID && Local_C2.Cargo.CurrentType == Cargo.CargoObjectType.Mount) || Operators.CompareString(OC.CargoObjectID, Local_C2.Cargo.CargoObjectID, TextCompare: true) == 0).Take(count2));
				}
			}
			foreach (CargoOpsCargoItemViewModel Local_C3 in TargetInventory)
			{
				if (Local_C3.Quantity < Local_C3.InitialQuantity)
				{
					int count3 = Local_C3.InitialQuantity - Local_C3.Quantity;
					list4.AddRange(Target.OnboardCargo.Where((Cargo OC) => (OC.CurrentType == Local_C3.Cargo.CurrentType && OC.CargoObjectDBID == Local_C3.Cargo.CargoObjectDBID && Local_C3.Cargo.CurrentType == Cargo.CargoObjectType.Mount) || Operators.CompareString(OC.CargoObjectID, Local_C3.Cargo.CargoObjectID, TextCompare: true) == 0).Take(count3));
				}
			}
			if (list3.Count != 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(Host, Target, list3);
			}
			if (list4.Count != 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(Target, Host, list4);
			}
			if (list3.Count > 0 || list4.Count > 0)
			{
				if (Target is Ship)
				{
					Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list3));
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list4));
				}
				else if (Target is Aircraft)
				{
					((Aircraft)Target).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
					((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list3));
					((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list4));
				}
				else if (Target is Vehicle)
				{
					Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list3));
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list4));
				}
			}
		}
		AllCargoItems.Dispose();
		Form.Close();
	}

	public void Cancel()
	{
		AllCargoItems.Dispose();
		Form.Close();
	}

	public void OnPropertyChanged(string string_0)
	{
		m_RecordClass?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void NewStrategy(object object_0)
	{
		UnloadAll();
	}

	[CompilerGenerated]
	private void PushStrategy(object object_0)
	{
		UnloadOne();
	}

	[CompilerGenerated]
	private void InvokeStrategy(object object_0)
	{
		LoadOne();
	}

	[CompilerGenerated]
	private void SetupStrategy(object object_0)
	{
		LoadAll();
	}

	[CompilerGenerated]
	private void ExcludeStrategy(object object_0)
	{
		OK();
	}

	[CompilerGenerated]
	private void IncludeStrategy(object object_0)
	{
		Cancel();
	}
}
