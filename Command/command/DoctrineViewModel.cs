using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Data;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class DoctrineViewModel : INotifyPropertyChanged
{
	public bool mouseOverPanel;

	public ActiveUnit theUnit;

	[CompilerGenerated]
	private ObservableCollection<SpecificDoctrineViewModel> _InterpreterSpecification;

	[CompilerGenerated]
	private ListCollectionView _ContainerSpecification;

	[NonSerialized]
	private PropertyChangedEventHandler m_ComposerSpecification;

	public ObservableCollection<SpecificDoctrineViewModel> SpecificDoctrines
	{
		[CompilerGenerated]
		get
		{
			return _InterpreterSpecification;
		}
		[CompilerGenerated]
		set
		{
			if (_InterpreterSpecification != value)
			{
				_InterpreterSpecification = value;
				OnPropertyChanged("SpecificDoctrines");
			}
		}
	}

	public ListCollectionView GroupedCollection
	{
		[CompilerGenerated]
		get
		{
			return _ContainerSpecification;
		}
		[CompilerGenerated]
		set
		{
			if (_ContainerSpecification != value)
			{
				_ContainerSpecification = value;
				OnPropertyChanged("GroupedCollection");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ComposerSpecification;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ComposerSpecification, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ComposerSpecification;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ComposerSpecification, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public DoctrineViewModel(ActiveUnit activeUnit_0, List<SpecificDoctrineViewModel> list_0)
	{
		mouseOverPanel = false;
		theUnit = activeUnit_0;
		SpecificDoctrines = new ObservableCollection<SpecificDoctrineViewModel>(list_0);
		GroupedCollection = (ListCollectionView)CollectionViewSource.GetDefaultView(SpecificDoctrines);
		GroupedCollection.GroupDescriptions.Add(new PropertyGroupDescription("DoctrineGroup"));
		Refresh();
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void Refresh()
	{
		if (mouseOverPanel)
		{
			return;
		}
		foreach (SpecificDoctrineViewModel specificDoctrine in SpecificDoctrines)
		{
			specificDoctrine.theUnit = theUnit;
			specificDoctrine.Refresh();
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ComposerSpecification?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
