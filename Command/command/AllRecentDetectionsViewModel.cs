using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class AllRecentDetectionsViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private ObservableCollection<RecentDetectionViewModel> m_SetterRepository;

	[NonSerialized]
	private PropertyChangedEventHandler creatorRepository;

	public ObservableCollection<RecentDetectionViewModel> Items
	{
		[CompilerGenerated]
		get
		{
			return m_SetterRepository;
		}
		[CompilerGenerated]
		set
		{
			if (m_SetterRepository != value)
			{
				m_SetterRepository = value;
				OnPropertyChanged("Items");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = creatorRepository;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref creatorRepository, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = creatorRepository;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref creatorRepository, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public AllRecentDetectionsViewModel()
	{
		Items = new ObservableCollection<RecentDetectionViewModel>();
		Items.Add(new RecentDetectionViewModel
		{
			PlatformName = "平台名称1",
			SensorName = "传感器名称123",
			PlatformDBID = 133,
			Int32_0 = 1536,
			TimeSinceDetection_String = "2天7小时",
			DetectionRange_String = "7.5nm"
		});
		Items.Add(new RecentDetectionViewModel
		{
			PlatformName = "平台名称2",
			SensorName = "传感器名称456",
			PlatformDBID = 141,
			Int32_0 = 1136,
			TimeSinceDetection_String = "2天7小时",
			DetectionRange_String = "7.5nm"
		});
		Items.Add(new RecentDetectionViewModel
		{
			PlatformName = "平台名称3",
			SensorName = "传感器名称789",
			PlatformDBID = 11465,
			Int32_0 = 1136,
			TimeSinceDetection_String = "2天7小时",
			DetectionRange_String = "7.5nm"
		});
	}

	public void OnPropertyChanged(string string_0)
	{
		creatorRepository?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
