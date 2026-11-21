using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Command.Messages;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class UnitSpeedAltViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> identifierVisitor;

	[CompilerGenerated]
	private ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> printerVisitor;

	[CompilerGenerated]
	private Visibility _ParserVisitor;

	[CompilerGenerated]
	private Visibility _AlgoVisitor;

	[CompilerGenerated]
	private Visibility databaseVisitor;

	[CompilerGenerated]
	private RelayCommand interceptorVisitor;

	[CompilerGenerated]
	private RelayCommand messageVisitor;

	[CompilerGenerated]
	private bool m_ProductVisitor;

	[CompilerGenerated]
	private bool annotationVisitor;

	[CompilerGenerated]
	private string m_IteratorVisitor;

	[CompilerGenerated]
	private string m_InitializerVisitor;

	[CompilerGenerated]
	private Visibility _RoleVisitor;

	[CompilerGenerated]
	private Visibility factoryVisitor;

	[CompilerGenerated]
	private RelayCommand attributeVisitor;

	[CompilerGenerated]
	private string m_EventVisitor;

	[CompilerGenerated]
	private RelayCommand m_GlobalVisitor;

	[NonSerialized]
	private PropertyChangedEventHandler m_WorkerVisitor;

	public ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> Alts
	{
		[CompilerGenerated]
		get
		{
			return identifierVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (identifierVisitor != value)
			{
				identifierVisitor = value;
				OnPropertyChanged("Alts");
			}
		}
	}

	public ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel> Speeds
	{
		[CompilerGenerated]
		get
		{
			return printerVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (printerVisitor != value)
			{
				printerVisitor = value;
				OnPropertyChanged("Speeds");
			}
		}
	}

	public Visibility Visible
	{
		[CompilerGenerated]
		get
		{
			return _ParserVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (_ParserVisitor != value)
			{
				_ParserVisitor = value;
				OnPropertyChanged("Visible");
			}
		}
	}

	public Visibility SpeedVis
	{
		[CompilerGenerated]
		get
		{
			return _AlgoVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (_AlgoVisitor != value)
			{
				_AlgoVisitor = value;
				OnPropertyChanged("SpeedVis");
			}
		}
	}

	public Visibility AltVis
	{
		[CompilerGenerated]
		get
		{
			return databaseVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (databaseVisitor != value)
			{
				databaseVisitor = value;
				OnPropertyChanged("AltVis");
			}
		}
	}

	public RelayCommand ManualSpeedCommand
	{
		[CompilerGenerated]
		get
		{
			return interceptorVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (interceptorVisitor != value)
			{
				interceptorVisitor = value;
				OnPropertyChanged("ManualSpeedCommand");
			}
		}
	}

	public RelayCommand ManualAltCommand
	{
		[CompilerGenerated]
		get
		{
			return messageVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (messageVisitor != value)
			{
				messageVisitor = value;
				OnPropertyChanged("ManualAltCommand");
			}
		}
	}

	public bool ManualAltChecked
	{
		[CompilerGenerated]
		get
		{
			return m_ProductVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (m_ProductVisitor != value)
			{
				m_ProductVisitor = value;
				OnPropertyChanged("ManualAltChecked");
			}
		}
	}

	public bool ManualSpeedChecked
	{
		[CompilerGenerated]
		get
		{
			return annotationVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (annotationVisitor != value)
			{
				annotationVisitor = value;
				OnPropertyChanged("ManualSpeedChecked");
			}
		}
	}

	public string ManualAltText
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_IteratorVisitor, value, StringComparison.Ordinal))
			{
				m_IteratorVisitor = value;
				OnPropertyChanged("ManualAltText");
			}
		}
	}

	public string ManualSpeedText
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_InitializerVisitor, value, StringComparison.Ordinal))
			{
				m_InitializerVisitor = value;
				OnPropertyChanged("ManualSpeedText");
			}
		}
	}

	public Visibility ManualAltVis
	{
		[CompilerGenerated]
		get
		{
			return _RoleVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (_RoleVisitor != value)
			{
				_RoleVisitor = value;
				OnPropertyChanged("ManualAltVis");
			}
		}
	}

	public Visibility ManualSpeedVis
	{
		[CompilerGenerated]
		get
		{
			return factoryVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (factoryVisitor != value)
			{
				factoryVisitor = value;
				OnPropertyChanged("ManualSpeedVis");
			}
		}
	}

	public RelayCommand PreviousWaypointCommand
	{
		[CompilerGenerated]
		get
		{
			return attributeVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (attributeVisitor != value)
			{
				attributeVisitor = value;
				OnPropertyChanged("PreviousWaypointCommand");
			}
		}
	}

	public string CurrentWaypointString
	{
		[CompilerGenerated]
		get
		{
			return m_EventVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_EventVisitor, value, StringComparison.Ordinal))
			{
				m_EventVisitor = value;
				OnPropertyChanged("CurrentWaypointString");
			}
		}
	}

	public RelayCommand NextWaypointCommand
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (m_GlobalVisitor != value)
			{
				m_GlobalVisitor = value;
				OnPropertyChanged("NextWaypointCommand");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_WorkerVisitor;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_WorkerVisitor, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_WorkerVisitor;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_WorkerVisitor, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	private void PushInterruptibleSetter()
	{
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Button_Previous_Click(null, null);
		Refresh(bool_0: false);
	}

	private void InvokeInterruptibleSetter()
	{
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Button_Next_Click(null, null);
		Refresh(bool_0: false);
	}

	public UnitSpeedAltViewModel()
	{
		Alts = new ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel>(new List<UnitSpeedAltRadioButtonWrapperViewModel>
		{
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_MaxAltitude),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_HighAltitude36000),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_HighAltitude25000),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_MediumAltitude12000),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_LowAltitude2000),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_LowAltitude1000),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_MinAltitude),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Surface),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Periscope),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Shallow),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_OverLayer),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_UnderLayer),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_MaxDepth)
		});
		Speeds = new ObservableCollection<UnitSpeedAltRadioButtonWrapperViewModel>(new List<UnitSpeedAltRadioButtonWrapperViewModel>
		{
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Stop),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Creep),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Cruise),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Full),
			new UnitSpeedAltRadioButtonWrapperViewModel(this, ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RB_Flank)
		});
		Visible = Visibility.Collapsed;
		ManualSpeedCommand = new RelayCommand(delegate
		{
			SetupInterruptibleSetter();
		});
		ManualAltCommand = new RelayCommand(delegate
		{
			ExcludeInterruptibleSetter();
		});
		PreviousWaypointCommand = new RelayCommand(delegate
		{
			PushInterruptibleSetter();
		});
		NextWaypointCommand = new RelayCommand(delegate
		{
			InvokeInterruptibleSetter();
		});
		Refresh(bool_0: false);
	}

	private void SetupInterruptibleSetter()
	{
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.CB_SpeedOverride.Checked = false;
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.CB_SpeedOverride_Click(null, null);
		Refresh(bool_0: false);
	}

	private void ExcludeInterruptibleSetter()
	{
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.CB_AltOverride.Checked = false;
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.CB_AltOverride_Click(null, null);
		Refresh(bool_0: false);
	}

	public void Refresh(bool bool_0)
	{
		if (Client.SelectedUnit == null)
		{
			Visible = Visibility.Collapsed;
			return;
		}
		Visible = Visibility.Visible;
		foreach (UnitSpeedAltRadioButtonWrapperViewModel speed in Speeds)
		{
			speed.Refresh();
		}
		foreach (UnitSpeedAltRadioButtonWrapperViewModel alt in Alts)
		{
			alt.Refresh();
		}
		if (Speeds.Any((UnitSpeedAltRadioButtonWrapperViewModel F) => F.Visible == Visibility.Visible))
		{
			SpeedVis = Visibility.Visible;
		}
		else
		{
			SpeedVis = Visibility.Collapsed;
		}
		if (Alts.Any((UnitSpeedAltRadioButtonWrapperViewModel F) => F.Visible == Visibility.Visible))
		{
			AltVis = Visibility.Visible;
		}
		else
		{
			AltVis = Visibility.Collapsed;
		}
		if (!bool_0)
		{
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.RefreshForm(bool_0: true);
		}
		ManualSpeedChecked = ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.CB_SpeedOverride.Checked;
		ManualAltChecked = ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.CB_AltOverride.Checked;
		CurrentWaypointString = ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Label_SettingsFor.Text;
		if (ManualSpeedChecked)
		{
			ManualSpeedVis = Visibility.Visible;
			ManualSpeedText = "高度 - 取消手动设置";
		}
		else
		{
			ManualSpeedVis = Visibility.Hidden;
			ManualSpeedText = "";
		}
		if (ManualAltChecked)
		{
			ManualAltVis = Visibility.Visible;
			ManualAltText = "高度 - 取消手动设置";
		}
		else
		{
			ManualAltVis = Visibility.Hidden;
			ManualAltText = "";
		}
		if (AltVis == Visibility.Collapsed)
		{
			ManualAltVis = Visibility.Collapsed;
		}
		if (SpeedVis == Visibility.Collapsed)
		{
			ManualSpeedVis = Visibility.Collapsed;
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_WorkerVisitor?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void IncludeInterruptibleSetter(object object_0)
	{
		SetupInterruptibleSetter();
	}

	[CompilerGenerated]
	private void SearchInterruptibleSetter(object object_0)
	{
		ExcludeInterruptibleSetter();
	}

	[CompilerGenerated]
	private void EnableInterruptibleSetter(object object_0)
	{
		PushInterruptibleSetter();
	}

	[CompilerGenerated]
	private void ChangeInterruptibleSetter(object object_0)
	{
		InvokeInterruptibleSetter();
	}
}
