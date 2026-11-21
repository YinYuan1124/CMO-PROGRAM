using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class HoverInfoMountViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string _RuleInterpreter;

	[CompilerGenerated]
	private int m_CollectionInterpreter;

	[NonSerialized]
	private PropertyChangedEventHandler m_InstanceInterpreter;

	public string Header
	{
		[CompilerGenerated]
		get
		{
			return _RuleInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_RuleInterpreter, value, StringComparison.Ordinal))
			{
				_RuleInterpreter = value;
				OnPropertyChanged("Header");
			}
		}
	}

	public int Quantity
	{
		[CompilerGenerated]
		get
		{
			return m_CollectionInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (m_CollectionInterpreter != value)
			{
				m_CollectionInterpreter = value;
				OnPropertyChanged("Quantity");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_InstanceInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_InstanceInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_InstanceInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_InstanceInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_InstanceInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
