using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class DatabaseControlViewModel : INotifyPropertyChanged
{
	public static object InternalDBViewer_LockObj;

	[CompilerGenerated]
	private string _ProductValue;

	[CompilerGenerated]
	private DatabaseControl _AnnotationValue;

	[CompilerGenerated]
	private string m_IteratorValue;

	[CompilerGenerated]
	private int initializerValue;

	[CompilerGenerated]
	private string m_RoleValue;

	[CompilerGenerated]
	private string m_FactoryValue;

	[CompilerGenerated]
	private List<DatabaseControlTypeViewModel> attributeValue;

	[CompilerGenerated]
	private DataView _EventValue;

	private long m_GlobalValue;

	private long _WorkerValue;

	[CompilerGenerated]
	private DataView accountValue;

	private string _StateValue;

	[CompilerGenerated]
	private DataView _AuthenticationValue;

	private long _ParamsValue;

	[CompilerGenerated]
	private bool m_InfoValue;

	private DatabaseControlTypeViewModel helperValue;

	private bool _MapperValue;

	[NonSerialized]
	private PropertyChangedEventHandler m_ManagerValue;

	public string WindowTitle
	{
		[CompilerGenerated]
		get
		{
			return _ProductValue;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_ProductValue, value, StringComparison.Ordinal))
			{
				_ProductValue = value;
				OnPropertyChanged("WindowTitle");
			}
		}
	}

	public DatabaseControl DatabaseControl
	{
		[CompilerGenerated]
		get
		{
			return _AnnotationValue;
		}
		[CompilerGenerated]
		set
		{
			if (_AnnotationValue != value)
			{
				_AnnotationValue = value;
				OnPropertyChanged("DatabaseControl");
			}
		}
	}

	public string SelectedObjectType
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorValue;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_IteratorValue, value, StringComparison.Ordinal))
			{
				m_IteratorValue = value;
				OnPropertyChanged("SelectedObjectType");
			}
		}
	}

	public int SelectedObjectID
	{
		[CompilerGenerated]
		get
		{
			return initializerValue;
		}
		[CompilerGenerated]
		set
		{
			if (initializerValue != value)
			{
				initializerValue = value;
				OnPropertyChanged("SelectedObjectID");
			}
		}
	}

	public string SelectedObjectName
	{
		[CompilerGenerated]
		get
		{
			return m_RoleValue;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_RoleValue, value, StringComparison.Ordinal))
			{
				m_RoleValue = value;
				OnPropertyChanged("SelectedObjectName");
			}
		}
	}

	public string HighlightTarget
	{
		[CompilerGenerated]
		get
		{
			return m_FactoryValue;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_FactoryValue, value, StringComparison.Ordinal))
			{
				m_FactoryValue = value;
				OnPropertyChanged("HighlightTarget");
			}
		}
	}

	public List<DatabaseControlTypeViewModel> Types
	{
		[CompilerGenerated]
		get
		{
			return attributeValue;
		}
		[CompilerGenerated]
		set
		{
			if (attributeValue != value)
			{
				attributeValue = value;
				OnPropertyChanged("Types");
			}
		}
	}

	public DataView Countries
	{
		[CompilerGenerated]
		get
		{
			return _EventValue;
		}
		[CompilerGenerated]
		set
		{
			if (_EventValue != value)
			{
				_EventValue = value;
				OnPropertyChanged("Countries");
			}
		}
	}

	public long UnitsDataViewSelectedUnitID
	{
		get
		{
			return m_GlobalValue;
		}
		set
		{
			if (m_GlobalValue != value)
			{
				m_GlobalValue = value;
				OnPropertyChanged("UnitsDataViewSelectedUnitID");
				SelectedObjectID = (int)value;
				Populate();
			}
		}
	}

	public long SelectedCountryID
	{
		get
		{
			return _WorkerValue;
		}
		set
		{
			if (_WorkerValue != value)
			{
				_WorkerValue = value;
				OnPropertyChanged("SelectedCountryID");
				Populate();
			}
		}
	}

	public DataView UnitsDataView
	{
		[CompilerGenerated]
		get
		{
			return accountValue;
		}
		[CompilerGenerated]
		set
		{
			if (accountValue != value)
			{
				accountValue = value;
				OnPropertyChanged("UnitsDataView");
			}
		}
	}

	public string SearchString
	{
		get
		{
			return _StateValue;
		}
		set
		{
			if (!string.Equals(_StateValue, value, StringComparison.Ordinal) && Operators.CompareString(_StateValue, value, TextCompare: true) != 0)
			{
				_StateValue = value;
				OnPropertyChanged("SearchString");
				Populate();
			}
		}
	}

	public DataView UnitTypes
	{
		[CompilerGenerated]
		get
		{
			return _AuthenticationValue;
		}
		[CompilerGenerated]
		set
		{
			if (_AuthenticationValue != value)
			{
				_AuthenticationValue = value;
				OnPropertyChanged("UnitTypes");
			}
		}
	}

	public long SelectedUnitTypeID
	{
		get
		{
			return _ParamsValue;
		}
		set
		{
			if (_ParamsValue != value)
			{
				_ParamsValue = value;
				OnPropertyChanged("SelectedUnitTypeID");
				Populate();
			}
		}
	}

	public bool ShowHypothetical
	{
		[CompilerGenerated]
		get
		{
			return m_InfoValue;
		}
		[CompilerGenerated]
		set
		{
			if (m_InfoValue != value)
			{
				m_InfoValue = value;
				OnPropertyChanged("ShowHypothetical");
			}
		}
	}

	public DatabaseControlTypeViewModel SelectedType
	{
		get
		{
			return helperValue;
		}
		set
		{
			if (helperValue != value)
			{
				bool flag = false;
				if (helperValue == null)
				{
					flag = true;
				}
				else if (value != null && Operators.CompareString(helperValue.Name, value.Name, TextCompare: true) != 0)
				{
					flag = true;
				}
				if (flag)
				{
					helperValue = value;
					OnPropertyChanged("SelectedType");
					SelectedObjectType = value.Name;
					Populate();
				}
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ManagerValue;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ManagerValue, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ManagerValue;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ManagerValue, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	static DatabaseControlViewModel()
	{
		InternalDBViewer_LockObj = RuntimeHelpers.GetObjectValue(new object());
	}

	public DatabaseControlViewModel()
	{
		HighlightTarget = null;
	}

	public void Populate()
	{
		if (_MapperValue)
		{
			return;
		}
		_MapperValue = true;
		if (Types == null)
		{
			Types = new List<DatabaseControlTypeViewModel>();
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Aircraft"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Ship"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Submarine"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Facility"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Satellite"
			});
			Types.Add(new DatabaseControlTypeViewModel
			{
				Name = "Weapon"
			});
		}
		if (string.IsNullOrWhiteSpace(SelectedObjectType))
		{
			SelectedObjectType = "Aircraft";
		}
		SelectedType = Types.FirstOrDefault((DatabaseControlTypeViewModel databaseControlTypeViewModel_0) => Operators.CompareString(databaseControlTypeViewModel_0.Name, SelectedObjectType, TextCompare: true) == 0);
		Countries = Client.CurrentScenario.Cache_OperatorCountries_DT.DefaultView;
		if (SelectedCountryID == 0)
		{
			SelectedCountryID = 1001L;
		}
		string string_ = "";
		string selectedObjectType = SelectedObjectType;
		if (Operators.CompareString(selectedObjectType, "Aircraft", TextCompare: true) != 0 && Operators.CompareString(selectedObjectType, "Ship", TextCompare: true) != 0 && Operators.CompareString(selectedObjectType, "Submarine", TextCompare: true) != 0 && Operators.CompareString(selectedObjectType, "Satellite", TextCompare: true) != 0 && Operators.CompareString(selectedObjectType, "Weapon", TextCompare: true) != 0)
		{
			if (Operators.CompareString(selectedObjectType, "Facility", TextCompare: true) == 0)
			{
				string_ = "SELECT ID, Description from Enum" + SelectedObjectType + "Category ORDER BY CASE WHEN ID >= 2000 THEN Description END ASC, CASE WHEN ID < 2000 THEN ID END ASC ";
			}
		}
		else
		{
			string_ = "SELECT ID, Description from Enum" + SelectedObjectType + "Type ORDER BY CASE WHEN ID >= 2000 THEN Description END ASC, CASE WHEN ID < 2000 THEN ID END ASC ";
		}
		UnitTypes = DBCache.GetDatatable(new SQLiteHelper(Client.CurrentScenario.DBConnection), string_).DefaultView;
		if (SelectedUnitTypeID == 0)
		{
			SelectedUnitTypeID = 1001L;
		}
		string name = SelectedType.Name;
		DataTable table;
		if (Operators.CompareString(name, "Aircraft", TextCompare: true) == 0)
		{
			table = Client.CurrentScenario.Cache_Aircraft_DT;
		}
		else if (Operators.CompareString(name, "Ship", TextCompare: true) == 0)
		{
			table = Client.CurrentScenario.Cache_Ships_DT;
		}
		else if (Operators.CompareString(name, "Submarine", TextCompare: true) == 0)
		{
			table = Client.CurrentScenario.Cache_Subs_DT;
		}
		else if (Operators.CompareString(name, "Facility", TextCompare: true) == 0)
		{
			table = Client.CurrentScenario.Cache_Facilities_DT;
		}
		else if (Operators.CompareString(name, "Satellite", TextCompare: true) == 0)
		{
			table = Client.CurrentScenario.Cache_Satellites_DT;
		}
		else
		{
			if (Operators.CompareString(name, "Weapon", TextCompare: true) != 0)
			{
				throw new Exception();
			}
			table = Client.CurrentScenario.Cache_Weapons_DT;
		}
		DataView dataView = new DataView(table);
		dataView.Sort = "LongName ASC";
		if (!string.IsNullOrWhiteSpace(SearchString) || SelectedCountryID != 1001 || SelectedUnitTypeID != 1001)
		{
			string text = "1=1 ";
			if (!string.IsNullOrWhiteSpace(SearchString))
			{
				string text2 = SearchString.Replace("'", "''");
				text = text + " AND LongName LIKE '%" + text2 + "%' ";
			}
			if (SelectedCountryID != 1001)
			{
				text += $" AND OperatorCountry={SelectedCountryID}";
			}
			if (!ShowHypothetical)
			{
				text += " AND Hypothetical=FALSE";
			}
			text = text.Replace("[", "[[");
			text = text.Replace("]", "]]");
			text = text.Replace("[[", "[[]");
			string text5 = (dataView.RowFilter = text.Replace("]]", "[]]"));
			string text3 = text5;
			text = text3;
		}
		UnitsDataView = dataView;
		object internalDBViewer_LockObj = InternalDBViewer_LockObj;
		ObjectFlowControl.CheckForSyncLockOnValueType(internalDBViewer_LockObj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(internalDBViewer_LockObj, ref lockTaken);
			if (SelectedObjectID == 0)
			{
				DatabaseControl.WebBrowser1.NavigateToString("<html><body style='background-color:#555555;color:white;'></body></html>");
			}
			else
			{
				ItemExporter.ConnectInterruptibleTemplate.InternalDBViewer.SelectedObjectType = SelectedObjectType;
				ItemExporter.ConnectInterruptibleTemplate.InternalDBViewer.SelectedObjectID = SelectedObjectID;
				ItemExporter.ConnectInterruptibleTemplate.InternalDBViewer.HighlightTarget = HighlightTarget;
				ItemExporter.ConnectInterruptibleTemplate.InternalDBViewer.DisplaySelection(bool_0: false);
				SelectedObjectName = ItemExporter.ConnectInterruptibleTemplate.InternalDBViewer.DatabaseObjectName;
				WindowTitle = "DB: " + SelectedObjectName;
				DatabaseControl.WebBrowser1.NavigateToString("<html><body style='background-color:#555555;color:white;'>" + ItemExporter.ConnectInterruptibleTemplate.InternalDBViewer.string_0 + "</body></html>");
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(internalDBViewer_LockObj);
			}
		}
		_MapperValue = false;
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ManagerValue?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private bool SetupServer(DatabaseControlTypeViewModel databaseControlTypeViewModel_0)
	{
		return Operators.CompareString(databaseControlTypeViewModel_0.Name, SelectedObjectType, TextCompare: true) == 0;
	}
}
