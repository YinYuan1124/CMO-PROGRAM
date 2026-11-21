using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class GClass8 : INotifyPropertyChanged
{
	public delegate void SensorsFormRequestedEventHandler();

	[CompilerGenerated]
	private InvertableBool utilsAttr;

	[CompilerGenerated]
	private InvertableBool predicateAttr;

	[CompilerGenerated]
	private InvertableBool _SingletonAttr;

	[CompilerGenerated]
	private InvertableBool m_RecordAttr;

	[CompilerGenerated]
	private InvertableBool m_ExceptionAttr;

	[CompilerGenerated]
	private RelayCommand attrAttr;

	[CompilerGenerated]
	private RelayCommand _VisitorAttr;

	[CompilerGenerated]
	private RelayCommand exporterAttr;

	[CompilerGenerated]
	private bool _PrototypeAttr;

	[CompilerGenerated]
	private bool _ComparatorAttr;

	[CompilerGenerated]
	private bool m_ItemAttr;

	public ActiveUnit theUnit;

	[NonSerialized]
	private PropertyChangedEventHandler setterAttr;

	[CompilerGenerated]
	private static SensorsFormRequestedEventHandler _CreatorAttr;

	public InvertableBool Inherit
	{
		[CompilerGenerated]
		get
		{
			return utilsAttr;
		}
		[CompilerGenerated]
		set
		{
			if (utilsAttr != value)
			{
				utilsAttr = value;
				OnPropertyChanged("Inherit");
			}
		}
	}

	public InvertableBool RadarActive
	{
		[CompilerGenerated]
		get
		{
			return predicateAttr;
		}
		[CompilerGenerated]
		set
		{
			if (predicateAttr != value)
			{
				predicateAttr = value;
				OnPropertyChanged("RadarActive");
			}
		}
	}

	public InvertableBool SonarActive
	{
		[CompilerGenerated]
		get
		{
			return _SingletonAttr;
		}
		[CompilerGenerated]
		set
		{
			if (_SingletonAttr != value)
			{
				_SingletonAttr = value;
				OnPropertyChanged("SonarActive");
			}
		}
	}

	public InvertableBool InvertableBool_0
	{
		[CompilerGenerated]
		get
		{
			return m_RecordAttr;
		}
		[CompilerGenerated]
		set
		{
			if (m_RecordAttr != value)
			{
				m_RecordAttr = value;
				OnPropertyChanged("OECMActive");
			}
		}
	}

	public InvertableBool InvertableBool_1
	{
		[CompilerGenerated]
		get
		{
			return m_ExceptionAttr;
		}
		[CompilerGenerated]
		set
		{
			if (m_ExceptionAttr != value)
			{
				m_ExceptionAttr = value;
				OnPropertyChanged("EmconObeyVisibility");
				OnPropertyChanged("ObeysEMCON");
			}
		}
	}

	public RelayCommand RelayCommand_0
	{
		[CompilerGenerated]
		get
		{
			return attrAttr;
		}
		[CompilerGenerated]
		set
		{
			if (attrAttr != value)
			{
				attrAttr = value;
				OnPropertyChanged("EMCONWindowCommand");
			}
		}
	}

	public RelayCommand SensorsWindowCommand
	{
		[CompilerGenerated]
		get
		{
			return _VisitorAttr;
		}
		[CompilerGenerated]
		set
		{
			if (_VisitorAttr != value)
			{
				_VisitorAttr = value;
				OnPropertyChanged("SensorsWindowCommand");
			}
		}
	}

	public RelayCommand EMCONWRAWindowCommand
	{
		[CompilerGenerated]
		get
		{
			return exporterAttr;
		}
		[CompilerGenerated]
		set
		{
			if (exporterAttr != value)
			{
				exporterAttr = value;
				OnPropertyChanged("EMCONWRAWindowCommand");
			}
		}
	}

	public bool HasRadarSensor
	{
		[CompilerGenerated]
		get
		{
			return _PrototypeAttr;
		}
		[CompilerGenerated]
		set
		{
			if (_PrototypeAttr != value)
			{
				_PrototypeAttr = value;
				OnPropertyChanged("HasRadarSensor");
			}
		}
	}

	public bool HasSonarSensor
	{
		[CompilerGenerated]
		get
		{
			return _ComparatorAttr;
		}
		[CompilerGenerated]
		set
		{
			if (_ComparatorAttr != value)
			{
				_ComparatorAttr = value;
				OnPropertyChanged("HasSonarSensor");
			}
		}
	}

	public bool HasOECMSensor
	{
		[CompilerGenerated]
		get
		{
			return m_ItemAttr;
		}
		[CompilerGenerated]
		set
		{
			if (m_ItemAttr != value)
			{
				m_ItemAttr = value;
				OnPropertyChanged("HasOECMSensor");
			}
		}
	}

	public Visibility EmconObeyVisibility
	{
		get
		{
			if ((bool)InvertableBool_1)
			{
				return Visibility.Visible;
			}
			return Visibility.Hidden;
		}
	}

	public static event SensorsFormRequestedEventHandler SensorsFormRequested
	{
		[CompilerGenerated]
		add
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = _CreatorAttr;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Combine(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref _CreatorAttr, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = _CreatorAttr;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Remove(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref _CreatorAttr, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = setterAttr;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref setterAttr, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = setterAttr;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref setterAttr, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void EMCONWindowWRACommand()
	{
		DoctrineForm doctrineForm = new DoctrineForm();
		doctrineForm.Subject = theUnit;
		doctrineForm.Show();
		doctrineForm.TabControl1A.SelectedIndex = 2;
	}

	public void method_0()
	{
		DoctrineForm doctrineForm = new DoctrineForm();
		doctrineForm.Subject = theUnit;
		doctrineForm.Show();
		doctrineForm.TabControl1A.SelectedIndex = 1;
	}

	public void SensorsWindow()
	{
		_CreatorAttr?.Invoke();
	}

	public void Refresh()
	{
		Inherit = theUnit.Doctrine.EMCON_Inherits;
		InvertableBool_1 = theUnit.Sensory.Boolean_0;
		if ((bool)InvertableBool_1)
		{
			RadarActive = theUnit.Doctrine.NewRepository(Client.CurrentScenario).LoginInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.Passive;
			SonarActive = theUnit.Doctrine.NewRepository(Client.CurrentScenario).GetInterruptibleField() != Doctrine.EMCONSettings._EMCONSetting.Passive;
			InvertableBool_0 = theUnit.Doctrine.NewRepository(Client.CurrentScenario).OECM() != Doctrine.EMCONSettings._EMCONSetting.Passive;
		}
		else
		{
			bool flag = false;
			bool flag2 = false;
			Sensor[] array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
			Sensor[] array2 = array;
			foreach (Sensor sensor in array2)
			{
				if (sensor != null && sensor.Type == Sensor.Sensor_Type.Radar && !sensor.IsPureIlluminator)
				{
					if (sensor.IsActive)
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
				}
			}
			if (flag && flag2)
			{
				RadarActive = null;
			}
			else if (flag && !flag2)
			{
				RadarActive = true;
			}
			else
			{
				RadarActive = false;
			}
			flag = false;
			flag2 = false;
			array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
			Sensor[] array3 = array;
			foreach (Sensor sensor2 in array3)
			{
				if (sensor2.IsSonar && !sensor2.IsPureIlluminator)
				{
					if (sensor2.IsActive)
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
				}
			}
			if (flag && flag2)
			{
				SonarActive = null;
			}
			else if (flag && !flag2)
			{
				SonarActive = true;
			}
			else
			{
				SonarActive = false;
			}
			flag = false;
			flag2 = false;
			array = ((ActiveUnit)Client.SelectedUnit).Sensors_ReadOnly();
			Sensor[] array4 = array;
			foreach (Sensor sensor3 in array4)
			{
				if (sensor3.IsOECM && !sensor3.IsPureIlluminator)
				{
					if (sensor3.IsActive)
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
				}
			}
			if (flag && flag2)
			{
				InvertableBool_0 = null;
			}
			else if (flag && !flag2)
			{
				InvertableBool_0 = true;
			}
			else
			{
				InvertableBool_0 = false;
			}
		}
		HasRadarSensor = theUnit.HasRadarSensor;
		HasSonarSensor = theUnit.HasSonarSensor;
		HasOECMSensor = theUnit.HasOECMSensor;
	}

	public GClass8(ActiveUnit activeUnit_0)
	{
		RelayCommand_0 = new RelayCommand(delegate
		{
			method_0();
		});
		SensorsWindowCommand = new RelayCommand(delegate
		{
			SensorsWindow();
		});
		EMCONWRAWindowCommand = new RelayCommand(delegate
		{
			EMCONWindowWRACommand();
		});
		try
		{
			theUnit = activeUnit_0;
			Refresh();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void OnPropertyChanged(string string_0)
	{
		setterAttr?.Invoke(this, new PropertyChangedEventArgs(string_0));
	}

	[CompilerGenerated]
	private void LoginInterruptiblePrototype(object object_0)
	{
		method_0();
	}

	[CompilerGenerated]
	private void GetInterruptiblePrototype(object object_0)
	{
		SensorsWindow();
	}

	[CompilerGenerated]
	private void WriteInterruptiblePrototype(object object_0)
	{
		EMCONWindowWRACommand();
	}
}
