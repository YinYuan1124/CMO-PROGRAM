using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command.SmartAssembly.Attributes;
using Command_Core;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class LicenseDialogViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private bool interpreterComposer;

	[CompilerGenerated]
	private ObservableCollection<LicenseViewModel> containerComposer;

	[NonSerialized]
	private PropertyChangedEventHandler composerComposer;

	public bool BeginScenarioEnabled
	{
		[CompilerGenerated]
		get
		{
			return interpreterComposer;
		}
		[CompilerGenerated]
		set
		{
			if (interpreterComposer != value)
			{
				interpreterComposer = value;
				OnPropertyChanged("BeginScenarioEnabled");
			}
		}
	}

	public ObservableCollection<LicenseViewModel> Items
	{
		[CompilerGenerated]
		get
		{
			return containerComposer;
		}
		[CompilerGenerated]
		set
		{
			if (containerComposer != value)
			{
				containerComposer = value;
				OnPropertyChanged("Items");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = composerComposer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref composerComposer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = composerComposer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref composerComposer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	[Obsolete("Used for design time only", true)]
	public LicenseDialogViewModel()
	{
		Items = new ObservableCollection<LicenseViewModel>();
		Items.Add(new LicenseViewModel
		{
			Title = "飞机毁伤模型",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "货运操作",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "通信中断",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "战术EMP（全向）",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "高能激光器（第2阶段）",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		Items.Add(new LicenseViewModel
		{
			Title = "Railguns / HVPs",
			Subtitle = "",
			Required = true,
			Owned = false,
			AssociatedLicense = Licensing.ModuleLicense.ChainsOfWar
		});
		BeginScenarioEnabled = false;
	}

	public LicenseDialogViewModel(List<Scenario.ScenarioFeatureOption> list_0)
	{
		Items = new ObservableCollection<LicenseViewModel>();
		foreach (Scenario.ScenarioFeatureOption item in list_0)
		{
			if (item == Scenario.ScenarioFeatureOption.CommsJamming)
			{
				Items.Add(new LicenseViewModel
				{
					Title = "通信干扰",
					Subtitle = "",
					Required = true,
					Owned = false,
					AssociatedLicense = Licensing.ModuleLicense.CommandPE
				});
			}
		}
		BeginScenarioEnabled = false;
	}

	public void OnPropertyChanged(string string_0)
	{
		composerComposer?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
