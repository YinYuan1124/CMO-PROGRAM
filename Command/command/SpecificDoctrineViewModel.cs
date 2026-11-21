using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class SpecificDoctrineViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private RelayCommand m_ConfigRecord;

	public ActiveUnit theUnit;

	[CompilerGenerated]
	private DataTable _RegistryRecord;

	[CompilerGenerated]
	private int _DefinitionRecord;

	[CompilerGenerated]
	private bool valRecord;

	[CompilerGenerated]
	private string m_WrapperRecord;

	[CompilerGenerated]
	private string _ObserverRecord;

	private ComboBox m_IssuerRecord;

	private Action<Doctrine, ComboBox, Scenario> _ClientRecord;

	private Action<Doctrine, ComboBox, Scenario> m_DicRecord;

	private Func<Doctrine, Scenario, bool> m_ConsumerRecord;

	[NonSerialized]
	private PropertyChangedEventHandler m_FacadeRecord;

	public RelayCommand SelectionChangedCommand
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigRecord;
		}
		[CompilerGenerated]
		set
		{
			if (m_ConfigRecord != value)
			{
				m_ConfigRecord = value;
				OnPropertyChanged("SelectionChangedCommand");
			}
		}
	}

	public DataTable DataTable
	{
		[CompilerGenerated]
		get
		{
			return _RegistryRecord;
		}
		[CompilerGenerated]
		set
		{
			if (_RegistryRecord != value)
			{
				_RegistryRecord = value;
				OnPropertyChanged("DataTable");
			}
		}
	}

	public int SelectedIndex
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionRecord;
		}
		[CompilerGenerated]
		set
		{
			if (_DefinitionRecord != value)
			{
				_DefinitionRecord = value;
				OnPropertyChanged("SelectedIndex");
			}
		}
	}

	public bool IsEnabled
	{
		[CompilerGenerated]
		get
		{
			return valRecord;
		}
		[CompilerGenerated]
		set
		{
			if (valRecord != value)
			{
				valRecord = value;
				OnPropertyChanged("IsEnabled");
			}
		}
	}

	public string DoctrineName
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperRecord;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_WrapperRecord, value, StringComparison.Ordinal))
			{
				m_WrapperRecord = value;
				OnPropertyChanged("DoctrineName");
			}
		}
	}

	public string DoctrineGroup
	{
		[CompilerGenerated]
		get
		{
			return _ObserverRecord;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ObserverRecord, value, StringComparison.Ordinal))
			{
				_ObserverRecord = value;
				OnPropertyChanged("DoctrineGroup");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_FacadeRecord;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_FacadeRecord, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_FacadeRecord;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_FacadeRecord, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public SpecificDoctrineViewModel(string string_0, string string_1, Action<Doctrine, ComboBox, Scenario> action_0, Action<Doctrine, ComboBox, Scenario> action_1, Func<Doctrine, Scenario, bool> func_0)
	{
		SelectionChangedCommand = new RelayCommand(delegate
		{
			SelectionChanged();
		});
		DoctrineName = string_0;
		DoctrineGroup = string_1;
		_ClientRecord = action_0;
		m_DicRecord = action_1;
		m_ConsumerRecord = func_0;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void SelectionChanged()
	{
		if (theUnit != null && m_IssuerRecord != null && Client.CurrentScenario != null && theUnit.Doctrine != null)
		{
			m_IssuerRecord.SelectedIndex = SelectedIndex;
			m_DicRecord(theUnit.Doctrine, m_IssuerRecord, Client.CurrentScenario);
		}
	}

	private object CancelInterruptibleSchema(DataTable dataTable_0, DataTable dataTable_1)
	{
		if (dataTable_0 == null)
		{
			return true;
		}
		if (dataTable_1 == null)
		{
			return false;
		}
		if (dataTable_0.Rows.Count == dataTable_1.Rows.Count)
		{
			int index = dataTable_0.Rows.Count - 1;
			int columnIndex = dataTable_0.Columns.Count - 1;
			if (Operators.ConditionalCompareObjectNotEqual(dataTable_0.Rows[index][columnIndex], dataTable_1.Rows[index][columnIndex], TextCompare: true))
			{
				return true;
			}
			return false;
		}
		return true;
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void Refresh()
	{
		try
		{
			if (theUnit == null)
			{
				return;
			}
			if (m_IssuerRecord == null)
			{
				m_IssuerRecord = new ComboBox();
				int num = 1;
				do
				{
					m_IssuerRecord.Items.Add("Dummy");
					num++;
				}
				while (num <= 25);
			}
			int num2 = 5;
			do
			{
				num2--;
				if (num2 < 0)
				{
					break;
				}
				_ClientRecord(theUnit.Doctrine, m_IssuerRecord, Client.CurrentScenario);
				DataTable dataTable = (DataTable)m_IssuerRecord.DataSource;
				if (Conversions.ToBoolean(CancelInterruptibleSchema(DataTable, dataTable)))
				{
					DataTable = dataTable;
				}
				if (SelectedIndex != m_IssuerRecord.SelectedIndex)
				{
					SelectedIndex = m_IssuerRecord.SelectedIndex;
				}
			}
			while (SelectedIndex == -1);
			IsEnabled = m_ConsumerRecord(theUnit.Doctrine, Client.CurrentScenario);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			m_IssuerRecord = null;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_FacadeRecord?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void VerifyInterruptibleSchema(object object_0)
	{
		SelectionChanged();
	}
}
