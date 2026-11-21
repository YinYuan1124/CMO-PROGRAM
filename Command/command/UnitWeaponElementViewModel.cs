using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class UnitWeaponElementViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private int threadExporter;

	[CompilerGenerated]
	private string m_RuleExporter;

	[CompilerGenerated]
	private int m_CollectionExporter;

	[CompilerGenerated]
	private int instanceExporter;

	[CompilerGenerated]
	private RelayCommand objectExporter;

	[NonSerialized]
	private PropertyChangedEventHandler parameterExporter;

	public int Int32_0
	{
		[CompilerGenerated]
		get
		{
			return threadExporter;
		}
		[CompilerGenerated]
		set
		{
			if (threadExporter != value)
			{
				threadExporter = value;
				OnPropertyChanged("WeaponDBID");
			}
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return m_RuleExporter;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_RuleExporter, value, StringComparison.Ordinal))
			{
				m_RuleExporter = value;
				OnPropertyChanged("Name");
			}
		}
	}

	public int Qty
	{
		[CompilerGenerated]
		get
		{
			return m_CollectionExporter;
		}
		[CompilerGenerated]
		set
		{
			if (m_CollectionExporter != value)
			{
				m_CollectionExporter = value;
				OnPropertyChanged("Qty");
			}
		}
	}

	public int Type
	{
		[CompilerGenerated]
		get
		{
			return instanceExporter;
		}
		[CompilerGenerated]
		set
		{
			if (instanceExporter != value)
			{
				instanceExporter = value;
				OnPropertyChanged("Type");
			}
		}
	}

	public RelayCommand RelayCommand_0
	{
		[CompilerGenerated]
		get
		{
			return objectExporter;
		}
		[CompilerGenerated]
		set
		{
			if (objectExporter != value)
			{
				objectExporter = value;
				OnPropertyChanged("OpenDBViewerCommand");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = parameterExporter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref parameterExporter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = parameterExporter;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref parameterExporter, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public UnitWeaponElementViewModel()
	{
		RelayCommand_0 = new RelayCommand(delegate
		{
			OpenDBViewer();
		});
	}

	public void OpenDBViewer()
	{
		Client.smethod_0("Weapon", Int32_0);
	}

	public void OnPropertyChanged(string string_0)
	{
		parameterExporter?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void QueryInterruptibleSetter(object object_0)
	{
		OpenDBViewer();
	}
}
