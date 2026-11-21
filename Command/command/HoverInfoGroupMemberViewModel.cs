using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class HoverInfoGroupMemberViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string procTests;

	[CompilerGenerated]
	private int _StructInterpreter;

	[NonSerialized]
	private PropertyChangedEventHandler _MerchantInterpreter;

	public string Header
	{
		[CompilerGenerated]
		get
		{
			return procTests;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(procTests, value, StringComparison.Ordinal))
			{
				procTests = value;
				OnPropertyChanged("Header");
			}
		}
	}

	public int Quantity
	{
		[CompilerGenerated]
		get
		{
			return _StructInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_StructInterpreter != value)
			{
				_StructInterpreter = value;
				OnPropertyChanged("Quantity");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _MerchantInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _MerchantInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _MerchantInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _MerchantInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		_MerchantInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
