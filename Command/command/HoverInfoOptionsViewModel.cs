using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
[TypeDescriptionProvider(typeof(HoverInfoLocalizedTypeDescriptionProvider))]
public sealed class HoverInfoOptionsViewModel : INotifyPropertyChanged
{
	private static HoverInfoOptionsViewModel _ParameterInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableDetailedEnum expressionInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum _DispatcherInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum _ListenerInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum m_ConfigInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum m_RegistryInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum m_DefinitionInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableDetailedEnum valInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum wrapperInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum m_ObserverInterpreter;

	[CompilerGenerated]
	private HoverInfoEnableEnum _IssuerInterpreter;

	[NonSerialized]
	private PropertyChangedEventHandler m_ClientInterpreter;

	public static HoverInfoOptionsViewModel Singleton => _ParameterInterpreter;

	[DefaultValue(1)]
	[Description("Weapon")]
	[DisplayName("Weapon")]
	[Category("Hover Info Settings")]
	public HoverInfoEnableDetailedEnum Weapons
	{
		[CompilerGenerated]
		get
		{
			return expressionInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (expressionInterpreter != value)
			{
				expressionInterpreter = value;
				OnPropertyChanged("Weapons");
			}
		}
	}

	[DefaultValue(0)]
	[Description("Sensor")]
	[DisplayName("Sensor")]
	[Category("Hover Info Settings")]
	public HoverInfoEnableEnum Sensor
	{
		[CompilerGenerated]
		get
		{
			return _DispatcherInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_DispatcherInterpreter != value)
			{
				_DispatcherInterpreter = value;
				OnPropertyChanged("Sensor");
			}
		}
	}

	[DefaultValue(0)]
	[Description("Cargo")]
	[Category("Hover Info Settings")]
	[DisplayName("Cargo")]
	public HoverInfoEnableEnum Cargo
	{
		[CompilerGenerated]
		get
		{
			return _ListenerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_ListenerInterpreter != value)
			{
				_ListenerInterpreter = value;
				OnPropertyChanged("Cargo");
			}
		}
	}

	[Description("Damage")]
	[DisplayName("Damage")]
	[Category("Hover Info Settings")]
	[DefaultValue(0)]
	public HoverInfoEnableEnum Damage
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ConfigInterpreter != value)
			{
				m_ConfigInterpreter = value;
				OnPropertyChanged("Damage");
			}
		}
	}

	[DefaultValue(0)]
	[DisplayName("Landed Aircraft")]
	[Category("Hover Info Settings")]
	[Description("Aircraft landed on carrier/airbase")]
	public HoverInfoEnableEnum AirParasite
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_RegistryInterpreter != value)
			{
				m_RegistryInterpreter = value;
				OnPropertyChanged("AirParasite");
			}
		}
	}

	[DefaultValue(0)]
	[DisplayName("Docked Boats")]
	[Category("Hover Info Settings")]
	[Description("Boats docked to mothership")]
	public HoverInfoEnableEnum BoatParasite
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_DefinitionInterpreter != value)
			{
				m_DefinitionInterpreter = value;
				OnPropertyChanged("BoatParasite");
			}
		}
	}

	[DisplayName("Fuel Information")]
	[Category("Hover Info Settings")]
	[Description("Fuel Information")]
	[DefaultValue(1)]
	public HoverInfoEnableDetailedEnum Fuel
	{
		[CompilerGenerated]
		get
		{
			return valInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (valInterpreter != value)
			{
				valInterpreter = value;
				OnPropertyChanged("Fuel");
			}
		}
	}

	[DefaultValue(0)]
	[Category("Hover Info Settings")]
	[Description("Mission Information")]
	[DisplayName("Mission Information")]
	public HoverInfoEnableEnum Mission
	{
		[CompilerGenerated]
		get
		{
			return wrapperInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (wrapperInterpreter != value)
			{
				wrapperInterpreter = value;
				OnPropertyChanged("Mission");
			}
		}
	}

	[DefaultValue(0)]
	[Category("Hover Info Settings")]
	[DisplayName("Vehicle Information")]
	[Description("Ground unit vehicles")]
	public HoverInfoEnableEnum Vehicles
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_ObserverInterpreter != value)
			{
				m_ObserverInterpreter = value;
				OnPropertyChanged("Vehicles");
			}
		}
	}

	[Description("Group Members")]
	[DefaultValue(0)]
	[DisplayName("Group Members")]
	[Category("Hover Info Settings")]
	public HoverInfoEnableEnum GroupMembers
	{
		[CompilerGenerated]
		get
		{
			return _IssuerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_IssuerInterpreter != value)
			{
				_IssuerInterpreter = value;
				OnPropertyChanged("GroupMembers");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ClientInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ClientInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ClientInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ClientInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	static HoverInfoOptionsViewModel()
	{
		_ParameterInterpreter = new HoverInfoOptionsViewModel();
	}

	private HoverInfoOptionsViewModel()
	{
		Load();
	}

	[SpecialName]
	private string method_0()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "HoverInfo.ini");
	}

	private void RevertAnnotation()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		IConfig config = iniConfigSource.AddConfig("HoverInfo");
		PropertyInfo[] properties = typeof(HoverInfoOptionsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			DefaultValueAttribute defaultValueAttribute = propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), inherit: true).Cast<DefaultValueAttribute>().First();
			config.Set(propertyInfo.Name, RuntimeHelpers.GetObjectValue(defaultValueAttribute.Value));
		}
		iniConfigSource.Save(method_0());
	}

	public void Load()
	{
		try
		{
			if (!FileExistsNative.FileExistsFast(method_0()))
			{
				RevertAnnotation();
			}
			IniConfigSource iniConfigSource = new IniConfigSource(method_0());
			PropertyInfo[] properties = typeof(HoverInfoOptionsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				string value = iniConfigSource.Configs["HoverInfo"].Get(propertyInfo.Name);
				object objectValue = RuntimeHelpers.GetObjectValue(Enum.Parse(propertyInfo.PropertyType, value));
				propertyInfo.SetValue(this, RuntimeHelpers.GetObjectValue(objectValue), null);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			RevertAnnotation();
			ProjectData.ClearProjectError();
		}
	}

	public void Save()
	{
		try
		{
			if (!FileExistsNative.FileExistsFast(method_0()))
			{
				RevertAnnotation();
			}
			IniConfigSource iniConfigSource = new IniConfigSource(method_0());
			PropertyInfo[] properties = typeof(HoverInfoOptionsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				iniConfigSource.Configs["HoverInfo"].Set(propertyInfo.Name, RuntimeHelpers.GetObjectValue(propertyInfo.GetValue(this, null)));
			}
			iniConfigSource.Save(method_0());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			RevertAnnotation();
			ProjectData.ClearProjectError();
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ClientInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
