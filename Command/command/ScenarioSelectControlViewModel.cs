using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class ScenarioSelectControlViewModel : INotifyPropertyChanged
{
	public LoadScenario LoadScenarioForm;

	[CompilerGenerated]
	private ObservableCollection<ScenarioViewModel> m_ThreadSingleton;

	[NonSerialized]
	private PropertyChangedEventHandler ruleSingleton;

	public ObservableCollection<ScenarioViewModel> Scenarios
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (m_ThreadSingleton != value)
			{
				m_ThreadSingleton = value;
				OnPropertyChanged("Scenarios");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = ruleSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref ruleSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = ruleSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref ruleSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void Update()
	{
		List<ScenarioViewModel> list = new List<ScenarioViewModel>();
		foreach (SteamWorkshop.WorkshopItem subscribedWorkshopItem in SteamWorkshop.SubscribedWorkshopItems)
		{
			if (!subscribedWorkshopItem.GoodToGo || subscribedWorkshopItem.pchFolder == null)
			{
				continue;
			}
			foreach (string item in Directory.EnumerateFiles(subscribedWorkshopItem.pchFolder, "*.scen", SearchOption.AllDirectories))
			{
				if (Operators.CompareString(Path.GetExtension(item), ".scen", TextCompare: true) == 0)
				{
					SteamScenarioViewModel steamScenarioViewModel = new SteamScenarioViewModel();
					steamScenarioViewModel.ScenarioSelectControlViewModel = this;
					steamScenarioViewModel.ScenarioName = Path.GetFileName(item);
					steamScenarioViewModel.ScenarioDate = ScenContainer.QueryScenContainer(item, "ScenDate");
					steamScenarioViewModel.ScenarioDifficulty = ScenContainer.QueryScenContainer(item, "Difficulty");
					steamScenarioViewModel.ScenarioComplexity = ScenContainer.QueryScenContainer(item, "Complexity");
					steamScenarioViewModel.ScenarioPath = item;
					list.Add(steamScenarioViewModel);
				}
			}
		}
		Scenarios = new ObservableCollection<ScenarioViewModel>(list);
		Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy((ScenarioViewModel F) => F.ScenarioName, new NaturalSortComparer<string[]>()));
	}

	public void OrderingChange(int int_0)
	{
		switch (int_0)
		{
		case 0:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy((ScenarioViewModel F) => F.ScenarioName));
			break;
		case 1:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy((ScenarioViewModel F) => F.ScenarioDate));
			break;
		case 2:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy((ScenarioViewModel F) => F.ScenarioDifficulty));
			break;
		case 3:
			Scenarios = new ObservableCollection<ScenarioViewModel>(Scenarios.OrderBy((ScenarioViewModel F) => F.ScenarioComplexity));
			break;
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		ruleSingleton?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
