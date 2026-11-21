using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class CargoMissionMothershipCargoMountViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string prototypeInvocation;

	[CompilerGenerated]
	private int m_ComparatorInvocation;

	[CompilerGenerated]
	private int m_ItemInvocation;

	[CompilerGenerated]
	private int _SetterInvocation;

	[CompilerGenerated]
	private bool m_CreatorInvocation;

	[CompilerGenerated]
	private Cargo.CargoObjectType _TemplateInvocation;

	[NonSerialized]
	private PropertyChangedEventHandler mappingInvocation;

	public string Status => Name + " " + Conversions.ToString(ToUnload) + " / " + Conversions.ToString(Available);

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return prototypeInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(prototypeInvocation, value, StringComparison.Ordinal))
			{
				prototypeInvocation = value;
				OnPropertyChanged("Status");
				OnPropertyChanged("Name");
			}
		}
	}

	public int Available
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_ComparatorInvocation != value)
			{
				m_ComparatorInvocation = value;
				OnPropertyChanged("Status");
				OnPropertyChanged("Available");
			}
		}
	}

	public int ToUnload
	{
		[CompilerGenerated]
		get
		{
			return m_ItemInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_ItemInvocation != value)
			{
				m_ItemInvocation = value;
				OnPropertyChanged("Status");
				OnPropertyChanged("ToUnload");
			}
		}
	}

	public int DBID
	{
		[CompilerGenerated]
		get
		{
			return _SetterInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (_SetterInvocation != value)
			{
				_SetterInvocation = value;
				OnPropertyChanged("DBID");
			}
		}
	}

	public bool canMove
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (m_CreatorInvocation != value)
			{
				m_CreatorInvocation = value;
				OnPropertyChanged("canMove");
			}
		}
	}

	public Cargo.CargoObjectType ObjectType
	{
		[CompilerGenerated]
		get
		{
			return _TemplateInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (_TemplateInvocation != value)
			{
				_TemplateInvocation = value;
				OnPropertyChanged("ObjectType");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = mappingInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref mappingInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = mappingInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref mappingInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public CargoMissionMothershipCargoMountViewModel(Cargo.CargoObjectType cargoObjectType_0, int int_0)
	{
		switch (cargoObjectType_0)
		{
		case Cargo.CargoObjectType.Mount:
		{
			Scenario scenario_ = Client.CurrentScenario;
			Name = DBFunctions.GetMountName(int_0, ref scenario_);
			break;
		}
		case Cargo.CargoObjectType.Vehicle:
		{
			SQLiteConnection sqliteConnection_2 = Client.CurrentScenario.DBConnection;
			Name = DBFunctions.GetVehicleName(int_0, ref sqliteConnection_2);
			break;
		}
		case Cargo.CargoObjectType.Facility:
		{
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			Name = DBFunctions.GetFacilityName(int_0, ref sqliteConnection_);
			break;
		}
		}
		ObjectType = cargoObjectType_0;
		DBID = int_0;
	}

	public void OnPropertyChanged(string string_0)
	{
		mappingInvocation?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
