using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class InvertableBool : INotifyPropertyChanged
{
	[CompilerGenerated]
	private PropertyChangedEventHandler infoContainer;

	private bool helperContainer;

	public bool Value
	{
		get
		{
			return helperContainer;
		}
		set
		{
			if (helperContainer != value)
			{
				helperContainer = value;
				AssetInitializer("Value");
				AssetInitializer("Invert");
			}
		}
	}

	public bool Invert
	{
		get
		{
			return !helperContainer;
		}
		set
		{
			helperContainer = !value;
			AssetInitializer("Value");
			AssetInitializer("Invert");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = infoContainer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref infoContainer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = infoContainer;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref infoContainer, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	private void AssetInitializer(string string_0)
	{
		infoContainer?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	public InvertableBool(bool bool_0)
	{
		helperContainer = false;
		helperContainer = bool_0;
	}

	public static implicit operator InvertableBool(bool bool_0)
	{
		return new InvertableBool(bool_0);
	}

	public static implicit operator bool(InvertableBool invertableBool_0)
	{
		return invertableBool_0.Value;
	}
}
