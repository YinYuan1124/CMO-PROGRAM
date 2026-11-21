using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public class PlatFormViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string _InvocationSchema;

	public ActiveUnit theUnit;

	[NonSerialized]
	private PropertyChangedEventHandler classSchema;

	[DoNotPrune]
	public string UnitName
	{
		[CompilerGenerated]
		get
		{
			return _InvocationSchema;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_InvocationSchema, value, StringComparison.Ordinal))
			{
				_InvocationSchema = value;
				OnPropertyChanged("UnitName");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = classSchema;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref classSchema, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = classSchema;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref classSchema, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public virtual void OnPropertyChanged(string string_0)
	{
		classSchema?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
