using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Imaging;
using Command.Messages;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class SpecificRealismSettingViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private string m_ProxyRecord;

	[CompilerGenerated]
	private string _ReaderRecord;

	[CompilerGenerated]
	private bool m_PropertyRecord;

	private static BitmapImage m_ImporterRecord;

	private static BitmapImage m_RepositoryRecord;

	[NonSerialized]
	private PropertyChangedEventHandler bridgeRecord;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyRecord;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_ProxyRecord, value, StringComparison.Ordinal))
			{
				m_ProxyRecord = value;
				OnPropertyChanged("Title");
			}
		}
	}

	public string Subtitle
	{
		[CompilerGenerated]
		get
		{
			return _ReaderRecord;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ReaderRecord, value, StringComparison.Ordinal))
			{
				_ReaderRecord = value;
				OnPropertyChanged("Subtitle");
			}
		}
	}

	public bool Active
	{
		[CompilerGenerated]
		get
		{
			return m_PropertyRecord;
		}
		[CompilerGenerated]
		set
		{
			if (m_PropertyRecord != value)
			{
				m_PropertyRecord = value;
				OnPropertyChanged("Active");
			}
		}
	}

	public static BitmapImage NegativeImageSource => m_RepositoryRecord;

	public static BitmapImage PositiveImageSource => m_ImporterRecord;

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = bridgeRecord;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref bridgeRecord, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = bridgeRecord;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref bridgeRecord, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	static SpecificRealismSettingViewModel()
	{
		m_ImporterRecord = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Positive.png"));
		m_RepositoryRecord = new BitmapImage(new Uri(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "/Symbols/Negative.png"));
	}

	public void OnPropertyChanged(string string_0)
	{
		bridgeRecord?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}
}
