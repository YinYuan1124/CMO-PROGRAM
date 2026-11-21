using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Command.Messages;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class UnitSpeedAltRadioButtonWrapperViewModel : INotifyPropertyChanged
{
	private DarkRadioButton rulesVisitor;

	private UnitSpeedAltViewModel methodVisitor;

	[CompilerGenerated]
	private string m_ServiceVisitor;

	[CompilerGenerated]
	private RelayCommand m_SystemVisitor;

	[CompilerGenerated]
	private Visibility m_CandidateVisitor;

	[CompilerGenerated]
	private bool _BaseVisitor;

	[CompilerGenerated]
	private bool _PolicyVisitor;

	[NonSerialized]
	private PropertyChangedEventHandler broadcasterVisitor;

	public string Content
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_ServiceVisitor, value, StringComparison.Ordinal))
			{
				m_ServiceVisitor = value;
				OnPropertyChanged("Content");
			}
		}
	}

	public RelayCommand Command
	{
		[CompilerGenerated]
		get
		{
			return m_SystemVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (m_SystemVisitor != value)
			{
				m_SystemVisitor = value;
				OnPropertyChanged("Command");
			}
		}
	}

	public Visibility Visible
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (m_CandidateVisitor != value)
			{
				m_CandidateVisitor = value;
				OnPropertyChanged("Visible");
			}
		}
	}

	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return _BaseVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (_BaseVisitor != value)
			{
				_BaseVisitor = value;
				OnPropertyChanged("Enabled");
			}
		}
	}

	public bool Checked
	{
		[CompilerGenerated]
		get
		{
			return _PolicyVisitor;
		}
		[CompilerGenerated]
		set
		{
			if (_PolicyVisitor != value)
			{
				_PolicyVisitor = value;
				OnPropertyChanged("Checked");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = broadcasterVisitor;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref broadcasterVisitor, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = broadcasterVisitor;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref broadcasterVisitor, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	private void WriteInterruptibleSetter()
	{
		rulesVisitor.Checked = true;
		ItemExporter.RevertInterruptibleMap.DoEvents();
		if (Operators.CompareString(rulesVisitor.Parent.Name, "GroupBox_SpeedPresets", TextCompare: true) != 0)
		{
			ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.CalcInterruptibleSchema(bool_0: true);
			methodVisitor.Refresh(bool_0: false);
		}
	}

	public UnitSpeedAltRadioButtonWrapperViewModel(UnitSpeedAltViewModel unitSpeedAltViewModel_0, DarkRadioButton darkRadioButton_0)
	{
		Command = new RelayCommand(delegate
		{
			WriteInterruptibleSetter();
		});
		rulesVisitor = darkRadioButton_0;
		methodVisitor = unitSpeedAltViewModel_0;
		Refresh();
	}

	public void Refresh()
	{
		Content = rulesVisitor.Text;
		Checked = rulesVisitor.Checked;
		if (rulesVisitor.Parent.Enabled)
		{
			Visible = Visibility.Visible;
		}
		else
		{
			Visible = Visibility.Collapsed;
		}
		Enabled = rulesVisitor.Enabled;
	}

	public void OnPropertyChanged(string string_0)
	{
		broadcasterVisitor?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void NewInterruptibleSetter(object object_0)
	{
		WriteInterruptibleSetter();
	}
}
