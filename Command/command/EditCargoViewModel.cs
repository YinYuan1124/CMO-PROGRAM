using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class EditCargoViewModel : INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class ContextDecoratorEntry
	{
		public Cargo.CargoObjectType cargoObjectType;

		public int num;

		internal bool PrepareInterruptiblePage(CargoManifestItem i)
		{
			return (i.objectType == cargoObjectType) & (i.DBID == num);
		}
	}

	[CompilerGenerated]
	private sealed class WriterMap
	{
		public CargoManifestItem Local_item;

		internal bool ReflectInterruptiblePage(Cargo C)
		{
			return C.CurrentType == Local_item.objectType;
		}

		internal bool VisitInterruptiblePage(Cargo C)
		{
			return C.CargoObjectDBID == Local_item.DBID;
		}
	}

	[CompilerGenerated]
	private ActiveUnit listenerReponse;

	[CompilerGenerated]
	private ObservableCollection<CargoManifestItem> _ConfigReponse;

	[CompilerGenerated]
	private DataTable _RegistryReponse;

	[CompilerGenerated]
	private DataRowView definitionReponse;

	[CompilerGenerated]
	private int m_ValReponse;

	[CompilerGenerated]
	private CargoManifestItem _WrapperReponse;

	[CompilerGenerated]
	private EditCargo _ObserverReponse;

	[CompilerGenerated]
	private EditCargoControl issuerReponse;

	[CompilerGenerated]
	private RelayCommand m_ClientReponse;

	[CompilerGenerated]
	private RelayCommand m_DicReponse;

	[CompilerGenerated]
	private RelayCommand consumerReponse;

	[CompilerGenerated]
	private RelayCommand facadeReponse;

	[CompilerGenerated]
	private string m_ProxyReponse;

	private static string m_ReaderReponse;

	private static string m_PropertyReponse;

	private static string _ImporterReponse;

	private static string _RepositoryReponse;

	private static string m_BridgeReponse;

	private static string invocationReponse;

	[NonSerialized]
	private PropertyChangedEventHandler m_ClassReponse;

	public ActiveUnit ActiveUnit
	{
		[CompilerGenerated]
		get
		{
			return listenerReponse;
		}
		[CompilerGenerated]
		set
		{
			if (listenerReponse != value)
			{
				listenerReponse = value;
				OnPropertyChanged("ActiveUnit");
			}
		}
	}

	public ObservableCollection<CargoManifestItem> Inventory
	{
		[CompilerGenerated]
		get
		{
			return _ConfigReponse;
		}
		[CompilerGenerated]
		set
		{
			if (_ConfigReponse != value)
			{
				_ConfigReponse = value;
				OnPropertyChanged("Inventory");
			}
		}
	}

	public DataTable AllCargoItems
	{
		[CompilerGenerated]
		get
		{
			return _RegistryReponse;
		}
		[CompilerGenerated]
		set
		{
			if (_RegistryReponse != value)
			{
				_RegistryReponse = value;
				OnPropertyChanged("AllCargoItems");
			}
		}
	}

	public DataRowView SelectedMountToAdd
	{
		[CompilerGenerated]
		get
		{
			return definitionReponse;
		}
		[CompilerGenerated]
		set
		{
			if (definitionReponse != value)
			{
				definitionReponse = value;
				OnPropertyChanged("SelectedMountToAdd");
			}
		}
	}

	public int Quantity
	{
		[CompilerGenerated]
		get
		{
			return m_ValReponse;
		}
		[CompilerGenerated]
		set
		{
			if (m_ValReponse != value)
			{
				m_ValReponse = value;
				OnPropertyChanged("Quantity");
			}
		}
	}

	public CargoManifestItem SelectedCargoToRemove
	{
		[CompilerGenerated]
		get
		{
			return _WrapperReponse;
		}
		[CompilerGenerated]
		set
		{
			if (_WrapperReponse != value)
			{
				_WrapperReponse = value;
				OnPropertyChanged("SelectedCargoToRemove");
			}
		}
	}

	public EditCargo Form
	{
		[CompilerGenerated]
		get
		{
			return _ObserverReponse;
		}
		[CompilerGenerated]
		set
		{
			if (_ObserverReponse != value)
			{
				_ObserverReponse = value;
				OnPropertyChanged("Form");
			}
		}
	}

	public EditCargoControl parentControl
	{
		[CompilerGenerated]
		get
		{
			return issuerReponse;
		}
		[CompilerGenerated]
		set
		{
			if (issuerReponse != value)
			{
				issuerReponse = value;
				OnPropertyChanged("parentControl");
			}
		}
	}

	public RelayCommand AddCargoCommand
	{
		[CompilerGenerated]
		get
		{
			return m_ClientReponse;
		}
		[CompilerGenerated]
		set
		{
			if (m_ClientReponse != value)
			{
				m_ClientReponse = value;
				OnPropertyChanged("AddCargoCommand");
			}
		}
	}

	public RelayCommand RemoveCargoCommand
	{
		[CompilerGenerated]
		get
		{
			return m_DicReponse;
		}
		[CompilerGenerated]
		set
		{
			if (m_DicReponse != value)
			{
				m_DicReponse = value;
				OnPropertyChanged("RemoveCargoCommand");
			}
		}
	}

	public RelayCommand RelayCommand_0
	{
		[CompilerGenerated]
		get
		{
			return consumerReponse;
		}
		[CompilerGenerated]
		set
		{
			if (consumerReponse != value)
			{
				consumerReponse = value;
				OnPropertyChanged("OKCommand");
			}
		}
	}

	public RelayCommand CancelCommand
	{
		[CompilerGenerated]
		get
		{
			return facadeReponse;
		}
		[CompilerGenerated]
		set
		{
			if (facadeReponse != value)
			{
				facadeReponse = value;
				OnPropertyChanged("CancelCommand");
			}
		}
	}

	public string LastError
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyReponse;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(m_ProxyReponse, value, StringComparison.Ordinal))
			{
				m_ProxyReponse = value;
				OnPropertyChanged("LastError");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ClassReponse;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ClassReponse, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = m_ClassReponse;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref m_ClassReponse, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	static EditCargoViewModel()
	{
		m_ReaderReponse = "不能装载货物";
		m_PropertyReponse = "人员（小队，MANPADS，ATGM）";
		_ImporterReponse = "小型货物（汽车，AAA枪）";
		_RepositoryReponse = "中型货物（APC，Towed Arty）";
		m_BridgeReponse = "大型货物（坦克，电话，拖车）";
		invocationReponse = "超大货物（IRBM / ICBM TEL发射架）";
	}

	public void AddCargo()
	{
		if (SelectedMountToAdd == null)
		{
			return;
		}
		Cargo.CargoObjectType cargoObjectType = Cargo.CargoObjectType.None;
		int num = Conversions.ToInteger(SelectedMountToAdd["ID"]);
		CargoType cargoType = CargoType.NoCargo;
		object left = SelectedMountToAdd["UnitType"];
		if (Operators.ConditionalCompareObjectEqual(left, "Mount", TextCompare: true))
		{
			cargoObjectType = Cargo.CargoObjectType.Mount;
		}
		else if (Operators.ConditionalCompareObjectEqual(left, "地面单元", TextCompare: true))
		{
			cargoObjectType = Cargo.CargoObjectType.Vehicle;
		}
		else if (Operators.ConditionalCompareObjectEqual(left, "可机动设施", TextCompare: true))
		{
			cargoObjectType = Cargo.CargoObjectType.Facility;
		}
		if (cargoObjectType == Cargo.CargoObjectType.None)
		{
			return;
		}
		CargoManifestItem cargoManifestItem = Inventory.Where((CargoManifestItem i) => (i.objectType == cargoObjectType) & (i.DBID == num)).FirstOrDefault();
		if (cargoManifestItem == null)
		{
			object left2 = SelectedMountToAdd["Cargo_Type"];
			if (Operators.ConditionalCompareObjectEqual(left2, m_PropertyReponse, TextCompare: true))
			{
				cargoType = CargoType.Personnel;
			}
			else if (Operators.ConditionalCompareObjectEqual(left2, _ImporterReponse, TextCompare: true))
			{
				cargoType = CargoType.SmallCargo;
			}
			else if (Operators.ConditionalCompareObjectEqual(left2, _RepositoryReponse, TextCompare: true))
			{
				cargoType = CargoType.MediumCargo;
			}
			else if (Operators.ConditionalCompareObjectEqual(left2, m_BridgeReponse, TextCompare: true))
			{
				cargoType = CargoType.LargeCargo;
			}
			else if (Operators.ConditionalCompareObjectEqual(left2, invocationReponse, TextCompare: true))
			{
				cargoType = CargoType.const_5;
			}
			ICargoHost cargoHost = (ICargoHost)ActiveUnit;
			if (cargoType > cargoHost.GetCargo_Type())
			{
				LastError = "由于货物类型的限制，无法将货物添加到平台。";
				return;
			}
			CargoManifestItem cargoManifestItem2 = new CargoManifestItem(cargoObjectType, num);
			cargoManifestItem2.quantity = Quantity;
			cargoManifestItem2.GenerateName(ActiveUnit.ParentScen);
			Inventory.Add(cargoManifestItem2);
		}
		else
		{
			cargoManifestItem.quantity += Quantity;
		}
		ObservableCollection<CargoManifestItem> inventory = Inventory;
		Inventory = null;
		Inventory = inventory;
	}

	public void RemoveCargo()
	{
		if (SelectedCargoToRemove != null)
		{
			SelectedCargoToRemove.quantity -= Quantity;
			if (SelectedCargoToRemove.quantity <= 0)
			{
				Inventory.Remove(SelectedCargoToRemove);
			}
			ObservableCollection<CargoManifestItem> inventory = Inventory;
			Inventory = null;
			Inventory = inventory;
		}
	}

	public void OK()
	{
		Cargo[] gparam_ = ActiveUnit.OnboardCargo;
		Cargo[] gparam_2 = new Cargo[0];
		foreach (CargoManifestItem Local_item in Inventory)
		{
			IEnumerator<Cargo> enumerator2 = (from C in ActiveUnit.OnboardCargo
				where C.CurrentType == Local_item.objectType
				where C.CargoObjectDBID == Local_item.DBID
				select (C)).GetEnumerator();
			for (int num = Local_item.quantity; num > 0; num--)
			{
				if (enumerator2.MoveNext())
				{
					ArrayExtensions.Add(ref gparam_2, enumerator2.Current);
				}
				else
				{
					ArrayExtensions.Add(ref gparam_2, Cargo.CreateNewCargo(Local_item.objectType, Local_item.DBID, ActiveUnit, ActiveUnit.ParentScen));
				}
			}
		}
		ICargoHost obj = (ICargoHost)ActiveUnit;
		float num2 = obj.GetCargo_Mass();
		float num3 = obj.GetCargo_Area();
		float num4 = obj.GetCargo_Crew();
		Cargo[] array = gparam_2;
		Cargo[] array2 = array;
		foreach (Cargo cargo in array2)
		{
			num2 -= cargo.RequiredMass;
			num3 -= cargo.RequiredArea;
			num4 -= cargo.RequiredCrewSpace;
		}
		if (!(num2 < 0f) && !(num3 < 0f) && num4 >= 0f)
		{
			ArrayExtensions.Clear(ref gparam_);
			ActiveUnit.OnboardCargo = gparam_2;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.AddInterruptibleIndexer(Client.SelectedUnit, Client.SelectedUnit);
			Form.Close();
		}
		else
		{
			LastError = "已超过该单元的货物载荷限制。";
		}
	}

	public void Cancel()
	{
		Form.Close();
	}

	private DataTrigger MapMock(object object_0)
	{
		DataTrigger obj = new DataTrigger
		{
			Binding = new Binding("Cargo_Type"),
			Value = RuntimeHelpers.GetObjectValue(object_0)
		};
		Setter setter = new Setter();
		obj.Setters.Add(setter);
		setter.Property = Control.BackgroundProperty;
		setter.Value = Brushes.Red;
		return obj;
	}

	public EditCargoViewModel(EditCargo editCargo_0, EditCargoControl editCargoControl_0, ActiveUnit activeUnit_0)
	{
		Inventory = new ObservableCollection<CargoManifestItem>();
		AddCargoCommand = new RelayCommand(delegate
		{
			AddCargo();
		});
		RemoveCargoCommand = new RelayCommand(delegate
		{
			RemoveCargo();
		});
		RelayCommand_0 = new RelayCommand(delegate
		{
			OK();
		});
		CancelCommand = new RelayCommand(delegate
		{
			Cancel();
		});
		Form = editCargo_0;
		Quantity = 1;
		ActiveUnit = activeUnit_0;
		ICargoHost cargoHost = (ICargoHost)ActiveUnit;
		Style style = new Style();
		if (cargoHost.GetCargo_Type() < CargoType.const_5)
		{
			style.Triggers.Add(MapMock(RuntimeHelpers.GetObjectValue(invocationReponse)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.LargeCargo)
		{
			style.Triggers.Add(MapMock(RuntimeHelpers.GetObjectValue(m_BridgeReponse)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.MediumCargo)
		{
			style.Triggers.Add(MapMock(RuntimeHelpers.GetObjectValue(_RepositoryReponse)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.SmallCargo)
		{
			style.Triggers.Add(MapMock(RuntimeHelpers.GetObjectValue(_ImporterReponse)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.Personnel)
		{
			style.Triggers.Add(MapMock(RuntimeHelpers.GetObjectValue(m_PropertyReponse)));
		}
		if (cargoHost.GetCargo_Type() < CargoType.NoCargo)
		{
			style.Triggers.Add(MapMock(RuntimeHelpers.GetObjectValue(m_ReaderReponse)));
		}
		editCargoControl_0.MyDataGrid.RowStyle = style;
		editCargo_0.Text = "编辑货物" + activeUnit_0.Name;
		bool flag = false;
		DataTable dataTable = null;
		try
		{
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			dataTable = DBFunctions.GetAllCargoItems(ref sqliteConnection_);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			flag = true;
			ProjectData.ClearProjectError();
		}
		if (!flag && dataTable.Rows.Count != 0)
		{
			AllCargoItems = dataTable.Clone();
			AllCargoItems.Columns["Cargo_Type"].DataType = typeof(string);
			AllCargoItems.Columns["Cargo_Type"].Caption = "货物类型";
			AllCargoItems.Columns["Cargo_Mass"].Caption = "货物质量 (吨)";
			AllCargoItems.Columns["Cargo_Area"].Caption = "货物面积（平方米）";
			AllCargoItems.Columns["Cargo_Crew"].Caption = "Personnel";
			AllCargoItems.Columns["Cargo_ParadropCapable"].Caption = "可用降落伞空投";
			IEnumerator enumerator = null;
			try
			{
				enumerator = dataTable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow row = (DataRow)enumerator.Current;
					AllCargoItems.ImportRow(row);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = AllCargoItems.Rows.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator2.Current;
					string left = Conversions.ToString(dataRow["Cargo_Type"]);
					if (Operators.CompareString(left, "0", TextCompare: true) == 0)
					{
						dataRow["Cargo_Type"] = RuntimeHelpers.GetObjectValue(m_ReaderReponse);
					}
					else if (Operators.CompareString(left, "1000", TextCompare: true) == 0)
					{
						dataRow["Cargo_Type"] = RuntimeHelpers.GetObjectValue(m_PropertyReponse);
					}
					else if (Operators.CompareString(left, "2000", TextCompare: true) == 0)
					{
						dataRow["Cargo_Type"] = RuntimeHelpers.GetObjectValue(_ImporterReponse);
					}
					else if (Operators.CompareString(left, "3000", TextCompare: true) == 0)
					{
						dataRow["Cargo_Type"] = RuntimeHelpers.GetObjectValue(_RepositoryReponse);
					}
					else if (Operators.CompareString(left, "4000", TextCompare: true) == 0)
					{
						dataRow["Cargo_Type"] = RuntimeHelpers.GetObjectValue(m_BridgeReponse);
					}
					else if (Operators.CompareString(left, "5000", TextCompare: true) == 0)
					{
						dataRow["Cargo_Type"] = RuntimeHelpers.GetObjectValue(invocationReponse);
					}
					else if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			foreach (CargoManifestItem item in Cargo.GenerateCargoManifest(ActiveUnit))
			{
				item.GenerateName(ActiveUnit.ParentScen);
				Inventory.Add(item);
			}
			if (cargoHost.GetCargo_Type() == CargoType.NoCargo)
			{
				LastError = "该单元无法运载货物。";
			}
		}
		else
		{
			DarkMessageBox.ShowError("无法使用当前加载的数据库进行货物相关任务。请将想定升级到最新数据库。", "Error");
			editCargo_0.Close();
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		m_ClassReponse?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void SortMock(object object_0)
	{
		AddCargo();
	}

	[CompilerGenerated]
	private void CalcMock(object object_0)
	{
		RemoveCargo();
	}

	[CompilerGenerated]
	private void RateMock(object object_0)
	{
		OK();
	}

	[CompilerGenerated]
	private void FlushMock(object object_0)
	{
		Cancel();
	}
}
