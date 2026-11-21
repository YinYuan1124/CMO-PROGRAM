using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class MLDetailViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private LoggedMessage m_TestsResolver;

	[CompilerGenerated]
	private string interpreterResolver;

	[CompilerGenerated]
	private string _ContainerResolver;

	[CompilerGenerated]
	private string composerResolver;

	[CompilerGenerated]
	private DateTime modelResolver;

	[CompilerGenerated]
	private double m_AdvisorResolver;

	[CompilerGenerated]
	private double customerResolver;

	[CompilerGenerated]
	private bool m_SerializerResolver;

	[CompilerGenerated]
	private Brush _RefResolver;

	[CompilerGenerated]
	private Visibility _ErrorResolver;

	[CompilerGenerated]
	private bool codeResolver;

	[CompilerGenerated]
	private RelayCommand _ConnectionResolver;

	[CompilerGenerated]
	private RelayCommand contextResolver;

	[NonSerialized]
	private PropertyChangedEventHandler _StatusResolver;

	public LoggedMessage LoggedMessage
	{
		[CompilerGenerated]
		get
		{
			return m_TestsResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_TestsResolver != value)
			{
				m_TestsResolver = value;
				OnPropertyChanged("RawDisplay");
				OnPropertyChanged("LoggedMessage");
			}
		}
	}

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return interpreterResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(interpreterResolver, value, StringComparison.Ordinal))
			{
				interpreterResolver = value;
				OnPropertyChanged("RawDisplay");
				OnPropertyChanged("Text");
			}
		}
	}

	public string LongText
	{
		[CompilerGenerated]
		get
		{
			return _ContainerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ContainerResolver, value, StringComparison.Ordinal))
			{
				_ContainerResolver = value;
				OnPropertyChanged("RawDisplay");
				OnPropertyChanged("LongText");
			}
		}
	}

	public string Summary
	{
		[CompilerGenerated]
		get
		{
			return composerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(composerResolver, value, StringComparison.Ordinal))
			{
				composerResolver = value;
				OnPropertyChanged("Summary");
			}
		}
	}

	public DateTime Timestamp
	{
		[CompilerGenerated]
		get
		{
			return modelResolver;
		}
		[CompilerGenerated]
		set
		{
			if (!DateTime.Equals(modelResolver, value))
			{
				modelResolver = value;
				OnPropertyChanged("RawDisplay");
				OnPropertyChanged("Timestamp");
			}
		}
	}

	public double Lat
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_AdvisorResolver != value)
			{
				m_AdvisorResolver = value;
				OnPropertyChanged("Lat");
			}
		}
	}

	public double Lon
	{
		[CompilerGenerated]
		get
		{
			return customerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (customerResolver != value)
			{
				customerResolver = value;
				OnPropertyChanged("Lon");
			}
		}
	}

	public bool Read
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerResolver;
		}
		[CompilerGenerated]
		set
		{
			if (m_SerializerResolver != value)
			{
				m_SerializerResolver = value;
				OnPropertyChanged("Read");
			}
		}
	}

	public Brush Brush
	{
		[CompilerGenerated]
		get
		{
			return _RefResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_RefResolver != value)
			{
				_RefResolver = value;
				OnPropertyChanged("Brush");
			}
		}
	}

	public Visibility PlusVisibility
	{
		[CompilerGenerated]
		get
		{
			return _ErrorResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_ErrorResolver != value)
			{
				_ErrorResolver = value;
				OnPropertyChanged("PlusVisibility");
			}
		}
	}

	public bool Expanded
	{
		[CompilerGenerated]
		get
		{
			return codeResolver;
		}
		[CompilerGenerated]
		set
		{
			if (codeResolver != value)
			{
				codeResolver = value;
				OnPropertyChanged("Expanded");
			}
		}
	}

	public RelayCommand ExpandCommand
	{
		[CompilerGenerated]
		get
		{
			return _ConnectionResolver;
		}
		[CompilerGenerated]
		set
		{
			if (_ConnectionResolver != value)
			{
				_ConnectionResolver = value;
				OnPropertyChanged("ExpandCommand");
			}
		}
	}

	public RelayCommand OpenHyperlinkCommand
	{
		[CompilerGenerated]
		get
		{
			return contextResolver;
		}
		[CompilerGenerated]
		set
		{
			if (contextResolver != value)
			{
				contextResolver = value;
				OnPropertyChanged("OpenHyperlinkCommand");
			}
		}
	}

	public string RawDisplay
	{
		get
		{
			string text = "";
			if (LoggedMessage.Side != null)
			{
				text = LoggedMessage.Side.ObjectID;
			}
			if (!string.IsNullOrEmpty(text) && Operators.CompareString(text, Client.CurrentSide.ObjectID, TextCompare: true) != 0)
			{
				return Timestamp.ToLongTimeString() + " - [" + LoggedMessage.Side.Name + "] " + Text;
			}
			return Timestamp.ToLongTimeString() + " - " + LongText;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _StatusResolver;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _StatusResolver, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _StatusResolver;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref _StatusResolver, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public MLDetailViewModel()
	{
		ExpandCommand = new RelayCommand(delegate
		{
			DisableInterruptibleTask();
		});
		OpenHyperlinkCommand = new RelayCommand(delegate
		{
			ReadInterruptibleTask();
		});
	}

	private void ReadInterruptibleTask()
	{
		Client.CurrentScenario.UnhandledPopUpMessages.Enqueue(LoggedMessage);
	}

	private void DisableInterruptibleTask()
	{
		if (Expanded)
		{
			PlusVisibility = Visibility.Visible;
			Expanded = false;
			Text = StripHTML.InterruptSpecification(Summary);
		}
		else
		{
			PlusVisibility = Visibility.Collapsed;
			Expanded = true;
			Text = StripHTML.InterruptSpecification(LongText);
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		_StatusResolver?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void UpdateInterruptibleTask(object object_0)
	{
		DisableInterruptibleTask();
	}

	[CompilerGenerated]
	private void InsertInterruptibleTask(object object_0)
	{
		ReadInterruptibleTask();
	}
}
