using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class HoverInfoParasiteViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string _ConsumerInterpreter;

	[CompilerGenerated]
	private string m_FacadeInterpreter;

	[NonSerialized]
	private PropertyChangedEventHandler proxyInterpreter;

	public string Header
	{
		[CompilerGenerated]
		get
		{
			return _ConsumerInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ConsumerInterpreter, value, StringComparison.Ordinal))
			{
				_ConsumerInterpreter = value;
				OnPropertyChanged("Header");
			}
		}
	}

	public string Ready
	{
		[CompilerGenerated]
		get
		{
			return m_FacadeInterpreter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_FacadeInterpreter, value, StringComparison.Ordinal))
			{
				m_FacadeInterpreter = value;
				OnPropertyChanged("Ready");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = proxyInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref proxyInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = proxyInterpreter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref proxyInterpreter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		proxyInterpreter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
