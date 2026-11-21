using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class HoverInfoWeaponViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string m_AccountInterpreter;

	[CompilerGenerated]
	private int _StateInterpreter;

	[NonSerialized]
	private PropertyChangedEventHandler _AuthenticationInterpreter;

	public string Header
	{
		[CompilerGenerated]
		get
		{
			return m_AccountInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_AccountInterpreter, value, StringComparison.Ordinal))
			{
				m_AccountInterpreter = value;
				OnPropertyChanged("Header");
			}
		}
	}

	public int Quantity
	{
		[CompilerGenerated]
		get
		{
			return _StateInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (_StateInterpreter != value)
			{
				_StateInterpreter = value;
				OnPropertyChanged("Quantity");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _AuthenticationInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _AuthenticationInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _AuthenticationInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _AuthenticationInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		_AuthenticationInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
