using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class MessageLogControlTemplateSelector : DataTemplateSelector, INotifyPropertyChanged
{
	[CompilerGenerated]
	private DataTemplate productConnection;

	[CompilerGenerated]
	private DataTemplate m_AnnotationConnection;

	[NonSerialized]
	private PropertyChangedEventHandler m_IteratorConnection;

	public DataTemplate DefaultMessageLogTemplate
	{
		[CompilerGenerated]
		get
		{
			return productConnection;
		}
		[CompilerGenerated]
		set
		{
			if (productConnection != value)
			{
				productConnection = value;
				OnPropertyChanged("DefaultMessageLogTemplate");
			}
		}
	}

	public DataTemplate HTMLMessageLogTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationConnection;
		}
		[CompilerGenerated]
		set
		{
			if (m_AnnotationConnection != value)
			{
				m_AnnotationConnection = value;
				OnPropertyChanged("HTMLMessageLogTemplate");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_IteratorConnection;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_IteratorConnection, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_IteratorConnection;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_IteratorConnection, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public override DataTemplate SelectTemplate(object item, DependencyObject container)
	{
		if (((MLDetailViewModel)item).LongText.StartsWith("<BODY"))
		{
			return HTMLMessageLogTemplate;
		}
		return DefaultMessageLogTemplate;
	}

	public void OnPropertyChanged(string string_0)
	{
		m_IteratorConnection?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
