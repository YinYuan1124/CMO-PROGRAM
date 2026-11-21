using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class DatabaseControlTypeViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string _InterceptorValue;

	[NonSerialized]
	private PropertyChangedEventHandler messageValue;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _InterceptorValue;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_InterceptorValue, value, StringComparison.Ordinal))
			{
				_InterceptorValue = value;
				OnPropertyChanged("Name");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = messageValue;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref messageValue, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = messageValue;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref messageValue, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		messageValue?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
