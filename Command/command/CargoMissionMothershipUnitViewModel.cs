using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class CargoMissionMothershipUnitViewModel : INotifyPropertyChanged
{
	public ActiveUnit theUnit;

	[CompilerGenerated]
	private string _MockInvocation;

	[NonSerialized]
	private PropertyChangedEventHandler _TagInvocation;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _MockInvocation;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_MockInvocation, value, StringComparison.Ordinal))
			{
				_MockInvocation = value;
				OnPropertyChanged("Name");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _TagInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _TagInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _TagInvocation;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _TagInvocation, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public CargoMissionMothershipUnitViewModel(ActiveUnit activeUnit_0)
	{
		theUnit = activeUnit_0;
		Name = activeUnit_0.Name;
	}

	public void OnPropertyChanged(string string_0)
	{
		_TagInvocation?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
