using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class GClass7 : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string m_ProccesorResolver;

	[CompilerGenerated]
	private System.Drawing.Brush _StrategyResolver;

	[CompilerGenerated]
	private FastObservableCollection<MLDetailViewModel> _ConfigurationResolver;

	[CompilerGenerated]
	private DateTime _TokenResolver;

	[CompilerGenerated]
	private bool indexerResolver;

	[CompilerGenerated]
	private string resolverResolver;

	[CompilerGenerated]
	private MessageLogControlViewModel m_PublisherResolver;

	[CompilerGenerated]
	private ICommand m_ServerResolver;

	private ICommand m_AdapterResolver;

	[NonSerialized]
	private PropertyChangedEventHandler schemaResolver;

	public string Header
	{
		[CompilerGenerated]
		get
		{
			return m_ProccesorResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_ProccesorResolver, value, StringComparison.Ordinal))
			{
				m_ProccesorResolver = value;
				OnPropertyChanged("Header");
			}
		}
	}

	public System.Drawing.Brush Brush
	{
		[CompilerGenerated]
		get
		{
			return _StrategyResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_StrategyResolver != value)
			{
				_StrategyResolver = value;
				OnPropertyChanged("Brush");
			}
		}
	}

	public FastObservableCollection<MLDetailViewModel> Details
	{
		[CompilerGenerated]
		get
		{
			return _ConfigurationResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_ConfigurationResolver != value)
			{
				_ConfigurationResolver = value;
				OnPropertyChanged("Details");
			}
		}
	}

	public DateTime Timestamp
	{
		[CompilerGenerated]
		get
		{
			return _TokenResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!DateTime.Equals(_TokenResolver, value))
			{
				_TokenResolver = value;
				OnPropertyChanged("Timestamp");
			}
		}
	}

	public bool Expanded
	{
		[CompilerGenerated]
		get
		{
			return indexerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (indexerResolver != value)
			{
				indexerResolver = value;
				OnPropertyChanged("Expanded");
			}
		}
	}

	public string Summary
	{
		[CompilerGenerated]
		get
		{
			return resolverResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(resolverResolver, value, StringComparison.Ordinal))
			{
				resolverResolver = value;
				OnPropertyChanged("BackGroundColor");
				OnPropertyChanged("Summary");
			}
		}
	}

	public MessageLogControlViewModel MessageLogVM
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_PublisherResolver != value)
			{
				m_PublisherResolver = value;
				OnPropertyChanged("BackGroundColor");
				OnPropertyChanged("MessageLogVM");
			}
		}
	}

	public ICommand ClickMeCommand
	{
		[CompilerGenerated]
		get
		{
			return m_ServerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_ServerResolver != value)
			{
				m_ServerResolver = value;
				OnPropertyChanged("ClickMeCommand");
			}
		}
	}

	public System.Windows.Media.Brush BackGroundColor
	{
		get
		{
			if (MessageLogVM.HeaderToShow[Summary])
			{
				return new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 63, 83, 63));
			}
			if (MessageLogVM.HeaderToShow[Summary])
			{
				return new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 63, 63, 63));
			}
			return new SolidColorBrush(System.Windows.Media.Color.FromArgb(byte.MaxValue, 83, 63, 63));
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = schemaResolver;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref schemaResolver, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = schemaResolver;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref schemaResolver, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public GClass7()
	{
		Details = new FastObservableCollection<MLDetailViewModel>();
		Expanded = false;
		ClickMeCommand = new RelayCommand(delegate
		{
			PrepareInterruptibleTask();
		});
	}

	private void PrepareInterruptibleTask()
	{
		MessageLogVM.HeaderToShow[Summary] = !MessageLogVM.HeaderToShow[Summary];
		MessageLogVM.RefreshLoggedMessages();
	}

	public void OnPropertyChanged(string string_0)
	{
		schemaResolver?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void ReflectInterruptibleTask(object object_0)
	{
		PrepareInterruptibleTask();
	}
}
