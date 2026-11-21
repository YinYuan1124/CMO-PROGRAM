using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;
using LiveCharts;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class ScoringGraphControlViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private ChartValues<ScoringDatapointViewModel> m_WatcherSingleton;

	[NonSerialized]
	private PropertyChangedEventHandler _ReponseSingleton;

	public ChartValues<ScoringDatapointViewModel> PlayerScore
	{
		[CompilerGenerated]
		get
		{
			return m_WatcherSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (m_WatcherSingleton != value)
			{
				m_WatcherSingleton = value;
				OnPropertyChanged("PlayerScore");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _ReponseSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _ReponseSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _ReponseSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _ReponseSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		_ReponseSingleton?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
