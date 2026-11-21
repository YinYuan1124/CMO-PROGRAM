using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class HoverInfoCargoViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string m_AuthenticationTests;

	[CompilerGenerated]
	private int m_ParamsTests;

	[NonSerialized]
	private PropertyChangedEventHandler infoTests;

	public string Header
	{
		[CompilerGenerated]
		get
		{
			return m_AuthenticationTests;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_AuthenticationTests, value, StringComparison.Ordinal))
			{
				m_AuthenticationTests = value;
				OnPropertyChanged("Header");
			}
		}
	}

	public int Quantity
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsTests;
		}
		[CompilerGenerated]
		set
		{
			if (m_ParamsTests != value)
			{
				m_ParamsTests = value;
				OnPropertyChanged("Quantity");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = infoTests;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref infoTests, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = infoTests;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref infoTests, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		infoTests?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
