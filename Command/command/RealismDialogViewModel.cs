using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Imaging;
using Command.My.Resources;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using OpenDis.Database;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class RealismDialogViewModel : INotifyPropertyChanged
{
	private RealismDialog merchantUtils;

	[CompilerGenerated]
	private string m_CallbackUtils;

	[CompilerGenerated]
	private ObservableCollection<SpecificRealismSettingViewModel> _DecoratorUtils;

	[CompilerGenerated]
	private RelayCommand _ProcessUtils;

	[CompilerGenerated]
	private BitmapImage threadUtils;

	[CompilerGenerated]
	private BitmapImage m_RuleUtils;

	[NonSerialized]
	private PropertyChangedEventHandler m_CollectionUtils;

	public string ScenarioLength
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackUtils;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_CallbackUtils, value, StringComparison.Ordinal))
			{
				m_CallbackUtils = value;
				OnPropertyChanged("ScenarioLength");
			}
		}
	}

	public ObservableCollection<SpecificRealismSettingViewModel> Items
	{
		[CompilerGenerated]
		get
		{
			return _DecoratorUtils;
		}
		[CompilerGenerated]
		set
		{
			if (_DecoratorUtils != value)
			{
				_DecoratorUtils = value;
				OnPropertyChanged("Items");
			}
		}
	}

	public RelayCommand RelayCommand_0
	{
		[CompilerGenerated]
		get
		{
			return _ProcessUtils;
		}
		[CompilerGenerated]
		set
		{
			if (_ProcessUtils != value)
			{
				_ProcessUtils = value;
				OnPropertyChanged("OKCommand");
			}
		}
	}

	public BitmapImage YesIcon
	{
		[CompilerGenerated]
		get
		{
			return threadUtils;
		}
		[CompilerGenerated]
		set
		{
			if (threadUtils != value)
			{
				threadUtils = value;
				OnPropertyChanged("YesIcon");
			}
		}
	}

	public BitmapImage NoIcon
	{
		[CompilerGenerated]
		get
		{
			return m_RuleUtils;
		}
		[CompilerGenerated]
		set
		{
			if (m_RuleUtils != value)
			{
				m_RuleUtils = value;
				OnPropertyChanged("NoIcon");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_CollectionUtils;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_CollectionUtils, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_CollectionUtils;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_CollectionUtils, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	[Obsolete("Used for design time only", true)]
	public RealismDialogViewModel()
	{
		Items = new ObservableCollection<SpecificRealismSettingViewModel>();
		RelayCommand_0 = new RelayCommand(delegate
		{
			OK();
		});
		YesIcon = StubDecoratorEntry.RemoveInterruptibleMap(Resources.Yes);
		NoIcon = StubDecoratorEntry.RemoveInterruptibleMap(Resources.No);
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "详细的枪支火力控制",
			Subtitle = "枪支和其他非制导武器的准确性受到多种因素的影响（通常是负面的）。",
			Active = true
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "无限弹药",
			Subtitle = "空军和海军基地具有无限弹药。",
			Active = false
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "通信干扰",
			Subtitle = "通信附注。",
			Active = true
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "飞机损坏",
			Subtitle = "更加逼真和详细的飞机战斗损伤模型",
			Active = false
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "可被天气影响空中架次",
			Subtitle = "评论评论评论。",
			Active = true
		});
		ScenarioLength = "持续时间：" + Misc.UpdateRequest((long)Math.Round(new TimeSpan(6, 0, 0).TotalSeconds));
	}

	public RealismDialogViewModel(RealismDialog realismDialog_0, Scenario scenario_0)
	{
		Items = new ObservableCollection<SpecificRealismSettingViewModel>();
		RelayCommand_0 = new RelayCommand(delegate
		{
			OK();
		});
		YesIcon = StubDecoratorEntry.RemoveInterruptibleMap(Resources.Yes);
		NoIcon = StubDecoratorEntry.RemoveInterruptibleMap(Resources.No);
		merchantUtils = realismDialog_0;
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "详细的枪支火力控制",
			Subtitle = "非制导武器的准确性受到各种因素的影响。",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DetailedGunFireControl)
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "无限的基础弹药库",
			Subtitle = "空军和海军基地提供无限弹药。",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines)
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "飞机损坏",
			Subtitle = "更加逼真和详细的飞机战斗损伤模型",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.AircraftDamage)
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "真实的潜艇通信",
			Subtitle = "潜艇下潜时通信连接将中断",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms)
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "地形地貌影响",
			Subtitle = "地形类型影响机动能力、探测器侦察能力和武器毁伤效果",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects)
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "地形类型影响 - 高级",
			Subtitle = "传感器将被本地地貌遮挡（如森林中的树木、城市中的楼宇），除非能够通过其它手段（如天线）扩大探测范围。不要打开该选项除非你确定了解该选项的影响。",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects_Advanced)
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "天气影响船只速度",
			Subtitle = "天气因素（如风力、海况）限制船只的最大速度",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed)
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "夜晚和天气影响空中架次",
			Subtitle = "由于夜间、天气原因飞机可能被延迟或取消",
			Active = false
		});
		Items.Add(new SpecificRealismSettingViewModel
		{
			Title = "Aircraft Weather/TOD Limitation",
			Subtitle = "Weather condition and time of the day will prevent aircrafts from take off and may damage or destroy them during landing",
			Active = scenario_0.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.ACS_NAW_Limitations)
		});
		ScenarioLength = "持续时间：" + Misc.UpdateRequest((long)Math.Round(scenario_0.Duration.TotalSeconds));
	}

	public void OK()
	{
		merchantUtils.Close();
	}

	public void OnPropertyChanged(string string_0)
	{
		m_CollectionUtils?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void InitInterruptibleStatus(object object_0)
	{
		OK();
	}

	[CompilerGenerated]
	private void CheckInterruptibleStatus(object object_0)
	{
		OK();
	}
}
