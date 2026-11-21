using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class ScoringDatapointViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private int _RequestSingleton;

	[CompilerGenerated]
	private DateTime _ValueSingleton;

	[CompilerGenerated]
	private string m_TokenizerSingleton;

	[NonSerialized]
	private PropertyChangedEventHandler stubSingleton;

	public int ScoreValue
	{
		[CompilerGenerated]
		get
		{
			return _RequestSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (_RequestSingleton != value)
			{
				_RequestSingleton = value;
				OnPropertyChanged("ScoreValue");
			}
		}
	}

	public DateTime DateTime
	{
		[CompilerGenerated]
		get
		{
			return _ValueSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!DateTime.Equals(_ValueSingleton, value))
			{
				_ValueSingleton = value;
				OnPropertyChanged("DateTime");
			}
		}
	}

	public string Reason
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerSingleton;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_TokenizerSingleton, value, StringComparison.Ordinal))
			{
				m_TokenizerSingleton = value;
				OnPropertyChanged("Reason");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = stubSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref stubSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = stubSingleton;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref stubSingleton, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		stubSingleton?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
