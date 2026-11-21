using System;
using System.ComponentModel;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class CargoMissionAssignedUnitViewModel : INotifyPropertyChanged
{
	public ActiveUnit theUnit;

	[NonSerialized]
	private PropertyChangedEventHandler m_VisitorInvocation;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_VisitorInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_VisitorInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_VisitorInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_VisitorInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public CargoMissionAssignedUnitViewModel(ActiveUnit activeUnit_0)
	{
		theUnit = activeUnit_0;
	}

	public void OnPropertyChanged(string string_0)
	{
		m_VisitorInvocation?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
