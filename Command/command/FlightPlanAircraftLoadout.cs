using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanAircraftLoadout : DarkSecondaryFormBase
{
	private IContainer _AuthenticationList;

	[AccessedThroughProperty("ListBox_AircraftTypes")]
	[CompilerGenerated]
	private DarkListView _ParamsList;

	[AccessedThroughProperty("ListBox_Loadouts")]
	[CompilerGenerated]
	private DarkListView _InfoList;

	[AccessedThroughProperty("ListBox_AssignedAircraft")]
	[CompilerGenerated]
	private DarkListView m_HelperList;

	[AccessedThroughProperty("ComboBox_FlightplanType")]
	[CompilerGenerated]
	private DarkUIComboBox _MapperList;

	[AccessedThroughProperty("TextBox_FormUpTime")]
	[CompilerGenerated]
	private DarkUITextBox m_ManagerList;

	[AccessedThroughProperty("SplitContainer3")]
	[CompilerGenerated]
	private SplitContainer getterList;

	[AccessedThroughProperty("SplitContainer1")]
	[CompilerGenerated]
	private SplitContainer m_ProducerList;

	[AccessedThroughProperty("SplitContainer2")]
	[CompilerGenerated]
	private SplitContainer procList;

	[AccessedThroughProperty("TextBox_ReserveLoiterAltitude")]
	[CompilerGenerated]
	private DarkUITextBox m_StructPool;

	[AccessedThroughProperty("TextBox_ReservePercetage")]
	[CompilerGenerated]
	private DarkUITextBox callbackPool;

	[AccessedThroughProperty("TextBox_CombatAltitude")]
	[CompilerGenerated]
	private DarkUITextBox m_ProcessPool;

	[AccessedThroughProperty("TextBox_StationAltitude")]
	[CompilerGenerated]
	private DarkUITextBox m_ThreadPool;

	[AccessedThroughProperty("AttackEgressDistance")]
	[CompilerGenerated]
	private DarkUITextBox m_CollectionPool;

	[AccessedThroughProperty("TextBox_AttackIngressAltitude")]
	[CompilerGenerated]
	private DarkUITextBox instancePool;

	[AccessedThroughProperty("TextBox_AttackIngressDistance")]
	[CompilerGenerated]
	private DarkUITextBox m_ObjectPool;

	[AccessedThroughProperty("CB_CruiseEgressAltitude")]
	[CompilerGenerated]
	private DarkUITextBox m_ParameterPool;

	[AccessedThroughProperty("TextBox_CruiseIngressAltitude")]
	[CompilerGenerated]
	private DarkUITextBox expressionPool;

	[AccessedThroughProperty("TextBox_FormUpAltitude")]
	[CompilerGenerated]
	private DarkUITextBox m_DispatcherPool;

	[AccessedThroughProperty("CB_StationThrottle")]
	[CompilerGenerated]
	private DarkUIComboBox listenerPool;

	[AccessedThroughProperty("CB_AttackEgressThrottle")]
	[CompilerGenerated]
	private DarkUIComboBox m_ConfigPool;

	[AccessedThroughProperty("CB_AttackIngressThrottle")]
	[CompilerGenerated]
	private DarkUIComboBox m_RegistryPool;

	[AccessedThroughProperty("CB_CruiseIngressThrottle")]
	[CompilerGenerated]
	private DarkUIComboBox valPool;

	[AccessedThroughProperty("Label9")]
	[CompilerGenerated]
	private DarkLabel issuerPool;

	[AccessedThroughProperty("Button_ClearSlots")]
	[CompilerGenerated]
	private DarkUIButton m_ClientPool;

	[AccessedThroughProperty("Button_FillEmptySlots")]
	[CompilerGenerated]
	private DarkUIButton _DicPool;

	[AccessedThroughProperty("Label19")]
	[CompilerGenerated]
	private DarkLabel m_ConsumerPool;

	[AccessedThroughProperty("Label15")]
	[CompilerGenerated]
	private DarkLabel m_ProxyPool;

	[AccessedThroughProperty("Label17")]
	[CompilerGenerated]
	private DarkLabel m_ReaderPool;

	[AccessedThroughProperty("Label12")]
	[CompilerGenerated]
	private DarkLabel propertyPool;

	[AccessedThroughProperty("Label14")]
	[CompilerGenerated]
	private DarkLabel importerPool;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel repositoryPool;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private DarkLabel invocationPool;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel classPool;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel requestPool;

	[AccessedThroughProperty("Label27")]
	[CompilerGenerated]
	private DarkLabel m_ValuePool;

	[AccessedThroughProperty("Label_ReserveLoiterTime")]
	[CompilerGenerated]
	private DarkLabel m_TokenizerPool;

	[AccessedThroughProperty("Label29")]
	[CompilerGenerated]
	private DarkLabel m_StubPool;

	[AccessedThroughProperty("Label25")]
	[CompilerGenerated]
	private DarkLabel specificationPool;

	[AccessedThroughProperty("Label23")]
	[CompilerGenerated]
	private DarkLabel m_ReponsePool;

	[AccessedThroughProperty("Label31")]
	[CompilerGenerated]
	private DarkLabel poolPool;

	[CompilerGenerated]
	[AccessedThroughProperty("Label32")]
	private DarkLabel taskPool;

	[AccessedThroughProperty("Label30")]
	[CompilerGenerated]
	private DarkLabel m_FilterPool;

	[AccessedThroughProperty("Label33")]
	[CompilerGenerated]
	private DarkLabel m_TestsPool;

	[AccessedThroughProperty("Button_ChangeTakeOffLocation")]
	[CompilerGenerated]
	private DarkUIButton interpreterPool;

	[AccessedThroughProperty("Label_TakeOffLocation")]
	[CompilerGenerated]
	private DarkLabel composerPool;

	[AccessedThroughProperty("CB_AttackEgressTerrainFollowing")]
	[CompilerGenerated]
	private DarkCheckBox serializerPool;

	[AccessedThroughProperty("CB_AttackIngressTerrainFollowing")]
	[CompilerGenerated]
	private DarkCheckBox m_RefPool;

	[AccessedThroughProperty("Label43")]
	[CompilerGenerated]
	private DarkLabel m_StrategyPool;

	[AccessedThroughProperty("Label42")]
	[CompilerGenerated]
	private DarkLabel configurationPool;

	[AccessedThroughProperty("Label40")]
	[CompilerGenerated]
	private DarkLabel indexerPool;

	[AccessedThroughProperty("CB_CruiseOneWayOnly")]
	[CompilerGenerated]
	private DarkCheckBox m_AdapterPool;

	[AccessedThroughProperty("Label_FormUpAltitude")]
	[CompilerGenerated]
	private DarkLabel m_SchemaPool;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel predicatePool;

	[AccessedThroughProperty("TxtDesiredSize")]
	[CompilerGenerated]
	private DarkUITextBox m_RecordPool;

	[AccessedThroughProperty("TxtMinimumSize")]
	[CompilerGenerated]
	private DarkUITextBox m_ExceptionPool;

	[AccessedThroughProperty("Button_Change_Landing_location")]
	[CompilerGenerated]
	private DarkUIButton _AttrPool;

	[AccessedThroughProperty("Label_LandingLocation")]
	[CompilerGenerated]
	private DarkLabel exporterPool;

	public Mission SelectedMission;

	public Mission.Flight SelectedFlight;

	public bool SelectedAircraftChanged;

	public bool SelectedLoadoutChanged;

	public bool SelectedAssignedAircraftChanged;

	internal DarkListView ListBox_AircraftTypes
	{
		[CompilerGenerated]
		get
		{
			return _ParamsList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListSystem;
			MouseEventHandler value3 = PostSystem;
			DarkListView paramsList = _ParamsList;
			if (paramsList != null)
			{
				paramsList.SelectedIndicesChanged -= value2;
				paramsList.MouseDown -= value3;
			}
			_ParamsList = value;
			paramsList = _ParamsList;
			if (paramsList != null)
			{
				paramsList.SelectedIndicesChanged += value2;
				paramsList.MouseDown += value3;
			}
		}
	}

	internal DarkListView ListBox_Loadouts
	{
		[CompilerGenerated]
		get
		{
			return _InfoList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveSystem;
			MouseEventHandler value3 = RunSystem;
			DarkListView infoList = _InfoList;
			if (infoList != null)
			{
				infoList.SelectedIndicesChanged -= value2;
				infoList.MouseDown -= value3;
			}
			_InfoList = value;
			infoList = _InfoList;
			if (infoList != null)
			{
				infoList.SelectedIndicesChanged += value2;
				infoList.MouseDown += value3;
			}
		}
	}

	internal DarkListView ListBox_AssignedAircraft
	{
		[CompilerGenerated]
		get
		{
			return m_HelperList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartSystem;
			MouseEventHandler value3 = AssetSystem;
			DarkListView helperList = m_HelperList;
			if (helperList != null)
			{
				helperList.SelectedIndicesChanged -= value2;
				helperList.MouseDown -= value3;
			}
			m_HelperList = value;
			helperList = m_HelperList;
			if (helperList != null)
			{
				helperList.SelectedIndicesChanged += value2;
				helperList.MouseDown += value3;
			}
		}
	}

	internal DarkUIComboBox ComboBox_FlightplanType
	{
		[CompilerGenerated]
		get
		{
			return _MapperList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitSystem;
			DarkUIComboBox mapperList = _MapperList;
			if (mapperList != null)
			{
				mapperList.SelectionChangeCommitted -= value2;
			}
			_MapperList = value;
			mapperList = _MapperList;
			if (mapperList != null)
			{
				mapperList.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUITextBox TextBox_FormUpTime
	{
		[CompilerGenerated]
		get
		{
			return m_ManagerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ManagerList = value;
		}
	}

	internal SplitContainer SplitContainer3
	{
		[CompilerGenerated]
		get
		{
			return getterList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			getterList = value;
		}
	}

	internal SplitContainer SplitContainer1
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProducerList = value;
		}
	}

	internal SplitContainer SplitContainer2
	{
		[CompilerGenerated]
		get
		{
			return procList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			procList = value;
		}
	}

	internal DarkUITextBox TextBox_ReserveLoiterAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_StructPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StructPool = value;
		}
	}

	[field: AccessedThroughProperty("TextBox18")]
	internal DarkUITextBox DarkUITextBox_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TextBox_ReservePercetage
	{
		[CompilerGenerated]
		get
		{
			return callbackPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackPool = value;
		}
	}

	[field: AccessedThroughProperty("TextBox_CombatDuration")]
	internal DarkUITextBox TextBox_CombatDuration
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TextBox_CombatAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProcessPool = value;
		}
	}

	internal DarkUITextBox TextBox_StationAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ThreadPool = value;
		}
	}

	[field: AccessedThroughProperty("TextBox_AttackEgressAltitude")]
	internal DarkUITextBox TextBox_AttackEgressAltitude
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox AttackEgressDistance
	{
		[CompilerGenerated]
		get
		{
			return m_CollectionPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CollectionPool = value;
		}
	}

	internal DarkUITextBox TextBox_AttackIngressAltitude
	{
		[CompilerGenerated]
		get
		{
			return instancePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			instancePool = value;
		}
	}

	internal DarkUITextBox TextBox_AttackIngressDistance
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObjectPool = value;
		}
	}

	internal DarkUITextBox CB_CruiseEgressAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_ParameterPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParameterPool = value;
		}
	}

	internal DarkUITextBox TextBox_CruiseIngressAltitude
	{
		[CompilerGenerated]
		get
		{
			return expressionPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			expressionPool = value;
		}
	}

	internal DarkUITextBox TextBox_FormUpAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DispatcherPool = value;
		}
	}

	internal DarkUIComboBox CB_StationThrottle
	{
		[CompilerGenerated]
		get
		{
			return listenerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			listenerPool = value;
		}
	}

	internal DarkUIComboBox CB_AttackEgressThrottle
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConfigPool = value;
		}
	}

	internal DarkUIComboBox CB_AttackIngressThrottle
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RegistryPool = value;
		}
	}

	[field: AccessedThroughProperty("CB_CruiseEgressThrottle")]
	internal DarkUIComboBox CB_CruiseEgressThrottle
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_CruiseIngressThrottle
	{
		[CompilerGenerated]
		get
		{
			return valPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valPool = value;
		}
	}

	[field: AccessedThroughProperty("CB_CombatThrottle")]
	internal DarkUIComboBox CB_CombatThrottle
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return issuerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			issuerPool = value;
		}
	}

	internal DarkUIButton Button_ClearSlots
	{
		[CompilerGenerated]
		get
		{
			return m_ClientPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartSystem;
			DarkUIButton clientPool = m_ClientPool;
			if (clientPool != null)
			{
				clientPool.Click -= value2;
			}
			m_ClientPool = value;
			clientPool = m_ClientPool;
			if (clientPool != null)
			{
				clientPool.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_FillEmptySlots
	{
		[CompilerGenerated]
		get
		{
			return _DicPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopSystem;
			DarkUIButton dicPool = _DicPool;
			if (dicPool != null)
			{
				dicPool.Click -= value2;
			}
			_DicPool = value;
			dicPool = _DicPool;
			if (dicPool != null)
			{
				dicPool.Click += value2;
			}
		}
	}

	internal DarkLabel Label19
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConsumerPool = value;
		}
	}

	[field: AccessedThroughProperty("Label18")]
	internal DarkLabel Label18
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label15
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProxyPool = value;
		}
	}

	internal DarkLabel Label17
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReaderPool = value;
		}
	}

	internal DarkLabel Label12
	{
		[CompilerGenerated]
		get
		{
			return propertyPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			propertyPool = value;
		}
	}

	internal DarkLabel Label14
	{
		[CompilerGenerated]
		get
		{
			return importerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			importerPool = value;
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return repositoryPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			repositoryPool = value;
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return invocationPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			invocationPool = value;
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return classPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			classPool = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return requestPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			requestPool = value;
		}
	}

	internal DarkLabel Label27
	{
		[CompilerGenerated]
		get
		{
			return m_ValuePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValuePool = value;
		}
	}

	internal DarkLabel Label_ReserveLoiterTime
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenizerPool = value;
		}
	}

	internal DarkLabel Label29
	{
		[CompilerGenerated]
		get
		{
			return m_StubPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StubPool = value;
		}
	}

	[field: AccessedThroughProperty("Label26")]
	internal DarkLabel Label26
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label25
	{
		[CompilerGenerated]
		get
		{
			return specificationPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			specificationPool = value;
		}
	}

	[field: AccessedThroughProperty("Label24")]
	internal DarkLabel Label24
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label23
	{
		[CompilerGenerated]
		get
		{
			return m_ReponsePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReponsePool = value;
		}
	}

	[field: AccessedThroughProperty("Label21")]
	internal DarkLabel Label21
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label31
	{
		[CompilerGenerated]
		get
		{
			return poolPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			poolPool = value;
		}
	}

	internal DarkLabel Label32
	{
		[CompilerGenerated]
		get
		{
			return taskPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			taskPool = value;
		}
	}

	internal DarkLabel Label30
	{
		[CompilerGenerated]
		get
		{
			return m_FilterPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FilterPool = value;
		}
	}

	internal DarkLabel Label33
	{
		[CompilerGenerated]
		get
		{
			return m_TestsPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TestsPool = value;
		}
	}

	internal DarkUIButton Button_ChangeTakeOffLocation
	{
		[CompilerGenerated]
		get
		{
			return interpreterPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifySystem;
			DarkUIButton darkUIButton = interpreterPool;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			interpreterPool = value;
			darkUIButton = interpreterPool;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label34")]
	internal DarkLabel Label34
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_TakeOffLocation
	{
		[CompilerGenerated]
		get
		{
			return composerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			composerPool = value;
		}
	}

	[field: AccessedThroughProperty("Label35")]
	internal DarkLabel Label35
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CB_CruiseAtOptimumAltitude")]
	internal DarkCheckBox CB_CruiseAtOptimumAltitude
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CB_StationTerrainFollowing")]
	internal DarkCheckBox CB_StationTerrainFollowing
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_AttackEgressTerrainFollowing
	{
		[CompilerGenerated]
		get
		{
			return serializerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerPool = value;
		}
	}

	internal DarkCheckBox CB_AttackIngressTerrainFollowing
	{
		[CompilerGenerated]
		get
		{
			return m_RefPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RefPool = value;
		}
	}

	[field: AccessedThroughProperty("CB_CruiseEgressTerrainFollowing")]
	internal DarkCheckBox CB_CruiseEgressTerrainFollowing
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CB_CruiseIngressTerrainFollowing")]
	internal DarkCheckBox CB_CruiseIngressTerrainFollowing
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CB_DropOrdnanceAtMaxRange")]
	internal DarkCheckBox CB_DropOrdnanceAtMaxRange
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label47")]
	internal DarkLabel Label47
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label45")]
	internal DarkLabel Label45
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label44")]
	internal DarkLabel Label44
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label43
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StrategyPool = value;
		}
	}

	internal DarkLabel Label42
	{
		[CompilerGenerated]
		get
		{
			return configurationPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationPool = value;
		}
	}

	[field: AccessedThroughProperty("Label41")]
	internal DarkLabel Label41
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label40
	{
		[CompilerGenerated]
		get
		{
			return indexerPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			indexerPool = value;
		}
	}

	[field: AccessedThroughProperty("Label39")]
	internal DarkLabel Label39
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label_CruiseIngressAltitude")]
	internal DarkLabel Label_CruiseIngressAltitude
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label_FormUpTime")]
	internal DarkLabel Label_FormUpTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_CruiseOneWayOnly
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdapterPool = value;
		}
	}

	internal DarkLabel Label_FormUpAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SchemaPool = value;
		}
	}

	[field: AccessedThroughProperty("Label_PatrolTransitAltitude_Aircraft")]
	internal DarkLabel Label_PatrolTransitAltitude_Aircraft
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return predicatePool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			predicatePool = value;
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TxtDesiredSize
	{
		[CompilerGenerated]
		get
		{
			return m_RecordPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = PrintSystem;
			DarkUITextBox recordPool = m_RecordPool;
			if (recordPool != null)
			{
				recordPool.TextChanged -= value2;
			}
			m_RecordPool = value;
			recordPool = m_RecordPool;
			if (recordPool != null)
			{
				recordPool.TextChanged += value2;
			}
		}
	}

	internal DarkUITextBox TxtMinimumSize
	{
		[CompilerGenerated]
		get
		{
			return m_ExceptionPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = DefineSystem;
			DarkUITextBox exceptionPool = m_ExceptionPool;
			if (exceptionPool != null)
			{
				exceptionPool.TextChanged -= value2;
			}
			m_ExceptionPool = value;
			exceptionPool = m_ExceptionPool;
			if (exceptionPool != null)
			{
				exceptionPool.TextChanged += value2;
			}
		}
	}

	internal DarkUIButton Button_Change_Landing_location
	{
		[CompilerGenerated]
		get
		{
			return _AttrPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishSystem;
			DarkUIButton attrPool = _AttrPool;
			if (attrPool != null)
			{
				attrPool.Click -= value2;
			}
			_AttrPool = value;
			attrPool = _AttrPool;
			if (attrPool != null)
			{
				attrPool.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_LandingLocation
	{
		[CompilerGenerated]
		get
		{
			return exporterPool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterPool = value;
		}
	}

	public FlightPlanAircraftLoadout()
	{
		base.FormClosing += PopSystem;
		base.FormClosed += InstantiateSystem;
		base.Load += CreateSystem;
		base.KeyDown += CompareSystem;
		base.VisibleChanged += ReflectSystem;
		SelectedAircraftChanged = false;
		SelectedLoadoutChanged = false;
		SelectedAssignedAircraftChanged = false;
		CalculateSystem();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _AuthenticationList != null)
			{
				_AuthenticationList.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalculateSystem()
	{
		Label1 = new DarkLabel();
		ListBox_AircraftTypes = new DarkListView();
		ListBox_Loadouts = new DarkListView();
		ListBox_AssignedAircraft = new DarkListView();
		ComboBox_FlightplanType = new DarkUIComboBox();
		Label9 = new DarkLabel();
		Button_ClearSlots = new DarkUIButton();
		Button_FillEmptySlots = new DarkUIButton();
		TextBox_FormUpTime = new DarkUITextBox();
		Label27 = new DarkLabel();
		Label_ReserveLoiterTime = new DarkLabel();
		Label29 = new DarkLabel();
		Label26 = new DarkLabel();
		Label25 = new DarkLabel();
		Label19 = new DarkLabel();
		Label18 = new DarkLabel();
		Label15 = new DarkLabel();
		Label17 = new DarkLabel();
		Label12 = new DarkLabel();
		Label14 = new DarkLabel();
		Label8 = new DarkLabel();
		Label24 = new DarkLabel();
		Label23 = new DarkLabel();
		Label7 = new DarkLabel();
		Label6 = new DarkLabel();
		Label21 = new DarkLabel();
		Label3 = new DarkLabel();
		Label2 = new DarkLabel();
		SplitContainer3 = new SplitContainer();
		SplitContainer1 = new SplitContainer();
		SplitContainer2 = new SplitContainer();
		Label31 = new DarkLabel();
		Label32 = new DarkLabel();
		Label30 = new DarkLabel();
		Label4 = new DarkLabel();
		CB_StationThrottle = new DarkUIComboBox();
		CB_AttackEgressThrottle = new DarkUIComboBox();
		CB_AttackIngressThrottle = new DarkUIComboBox();
		CB_CruiseEgressThrottle = new DarkUIComboBox();
		CB_CruiseIngressThrottle = new DarkUIComboBox();
		CB_CombatThrottle = new DarkUIComboBox();
		Label47 = new DarkLabel();
		Label45 = new DarkLabel();
		Label44 = new DarkLabel();
		Label43 = new DarkLabel();
		Label42 = new DarkLabel();
		Label41 = new DarkLabel();
		Label40 = new DarkLabel();
		Label39 = new DarkLabel();
		Label_CruiseIngressAltitude = new DarkLabel();
		Label_FormUpTime = new DarkLabel();
		CB_CruiseOneWayOnly = new DarkCheckBox();
		Label_FormUpAltitude = new DarkLabel();
		Label_PatrolTransitAltitude_Aircraft = new DarkLabel();
		TextBox_ReserveLoiterAltitude = new DarkUITextBox();
		DarkUITextBox_0 = new DarkUITextBox();
		TextBox_ReservePercetage = new DarkUITextBox();
		TextBox_CombatDuration = new DarkUITextBox();
		TextBox_CombatAltitude = new DarkUITextBox();
		TextBox_StationAltitude = new DarkUITextBox();
		TextBox_AttackEgressAltitude = new DarkUITextBox();
		AttackEgressDistance = new DarkUITextBox();
		TextBox_AttackIngressAltitude = new DarkUITextBox();
		TextBox_AttackIngressDistance = new DarkUITextBox();
		CB_CruiseEgressAltitude = new DarkUITextBox();
		TextBox_CruiseIngressAltitude = new DarkUITextBox();
		TextBox_FormUpAltitude = new DarkUITextBox();
		CB_CruiseAtOptimumAltitude = new DarkCheckBox();
		CB_StationTerrainFollowing = new DarkCheckBox();
		CB_AttackEgressTerrainFollowing = new DarkCheckBox();
		CB_AttackIngressTerrainFollowing = new DarkCheckBox();
		CB_CruiseEgressTerrainFollowing = new DarkCheckBox();
		CB_CruiseIngressTerrainFollowing = new DarkCheckBox();
		CB_DropOrdnanceAtMaxRange = new DarkCheckBox();
		Label33 = new DarkLabel();
		Button_ChangeTakeOffLocation = new DarkUIButton();
		Label34 = new DarkLabel();
		Label_TakeOffLocation = new DarkLabel();
		Label35 = new DarkLabel();
		Label5 = new DarkLabel();
		TxtDesiredSize = new DarkUITextBox();
		TxtMinimumSize = new DarkUITextBox();
		Button_Change_Landing_location = new DarkUIButton();
		DarkLabel1 = new DarkLabel();
		Label_LandingLocation = new DarkLabel();
		((ISupportInitialize)SplitContainer3).BeginInit();
		SplitContainer3.Panel1.SuspendLayout();
		SplitContainer3.Panel2.SuspendLayout();
		SplitContainer3.SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.Panel2.SuspendLayout();
		SplitContainer1.SuspendLayout();
		((ISupportInitialize)SplitContainer2).BeginInit();
		SplitContainer2.Panel1.SuspendLayout();
		SplitContainer2.Panel2.SuspendLayout();
		SplitContainer2.SuspendLayout();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(3, 35);
		Label1.Name = "Label1";
		Label1.Size = new Size(84, 15);
		Label1.TabIndex = 0;
		Label1.Text = "上架时间：";
		ListBox_AircraftTypes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ListBox_AircraftTypes.Location = new Point(3, 26);
		ListBox_AircraftTypes.Name = "ListBox_AircraftTypes";
		ListBox_AircraftTypes.RelatedInfos = null;
		ListBox_AircraftTypes.Size = new Size(290, 267);
		ListBox_AircraftTypes.TabIndex = 16;
		ListBox_Loadouts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ListBox_Loadouts.Location = new Point(3, 26);
		ListBox_Loadouts.Name = "ListBox_Loadouts";
		ListBox_Loadouts.RelatedInfos = null;
		ListBox_Loadouts.Size = new Size(414, 267);
		ListBox_Loadouts.TabIndex = 17;
		ListBox_AssignedAircraft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ListBox_AssignedAircraft.Location = new Point(8, 26);
		ListBox_AssignedAircraft.Name = "ListBox_AssignedAircraft";
		ListBox_AssignedAircraft.RelatedInfos = null;
		ListBox_AssignedAircraft.Size = new Size(709, 285);
		ListBox_AssignedAircraft.TabIndex = 18;
		ComboBox_FlightplanType.BackColor = Color.Transparent;
		ComboBox_FlightplanType.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_FlightplanType.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_FlightplanType.Font = new Font("Segoe UI", 7f);
		ComboBox_FlightplanType.FormattingEnabled = true;
		ComboBox_FlightplanType.Location = new Point(98, 6);
		ComboBox_FlightplanType.Name = "ComboBox_FlightplanType";
		ComboBox_FlightplanType.Size = new Size(184, 21);
		ComboBox_FlightplanType.TabIndex = 39;
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(3, 8);
		Label9.Name = "Label9";
		Label9.Size = new Size(89, 15);
		Label9.TabIndex = 38;
		Label9.Text = "飞行计划类型：";
		Button_ClearSlots.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ClearSlots.BackColor = Color.Transparent;
		Button_ClearSlots.DialogResult = DialogResult.None;
		Button_ClearSlots.Font = new Font("Segoe UI", 10f);
		Button_ClearSlots.ForeColor = SystemColors.Control;
		Button_ClearSlots.Location = new Point(-1, 317);
		Button_ClearSlots.Name = "Button_ClearSlots";
		Button_ClearSlots.Padding = new Padding(5);
		Button_ClearSlots.RoundRadius = 0;
		Button_ClearSlots.Size = new Size(139, 24);
		Button_ClearSlots.TabIndex = 41;
		Button_ClearSlots.Text = "清空飞机空位";
		Button_ClearSlots.Visible = false;
		Button_FillEmptySlots.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_FillEmptySlots.BackColor = Color.Transparent;
		Button_FillEmptySlots.DialogResult = DialogResult.None;
		Button_FillEmptySlots.Font = new Font("Segoe UI", 10f);
		Button_FillEmptySlots.ForeColor = SystemColors.Control;
		Button_FillEmptySlots.Location = new Point(139, 317);
		Button_FillEmptySlots.Name = "Button_FillEmptySlots";
		Button_FillEmptySlots.Padding = new Padding(5);
		Button_FillEmptySlots.RoundRadius = 0;
		Button_FillEmptySlots.Size = new Size(139, 24);
		Button_FillEmptySlots.TabIndex = 40;
		Button_FillEmptySlots.Text = "填充飞机空位";
		Button_FillEmptySlots.Visible = false;
		TextBox_FormUpTime.AutoCompleteCustomSource = null;
		TextBox_FormUpTime.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_FormUpTime.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_FormUpTime.BackColor = Color.Transparent;
		TextBox_FormUpTime.Font = new Font("Segoe UI", 8f);
		TextBox_FormUpTime.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FormUpTime.Image = null;
		TextBox_FormUpTime.Lines = null;
		TextBox_FormUpTime.Location = new Point(150, 30);
		TextBox_FormUpTime.MaxLength = 32767;
		TextBox_FormUpTime.Multiline = false;
		TextBox_FormUpTime.Name = "TextBox_FormUpTime";
		TextBox_FormUpTime.ReadOnly = false;
		TextBox_FormUpTime.ScrollBars = ScrollBars.None;
		TextBox_FormUpTime.SelectionStart = 0;
		TextBox_FormUpTime.Size = new Size(122, 20);
		TextBox_FormUpTime.TabIndex = 43;
		TextBox_FormUpTime.TextAlign = HorizontalAlignment.Left;
		TextBox_FormUpTime.UseSystemPasswordChar = false;
		TextBox_FormUpTime.WatermarkText = "";
		Label27.AutoSize = true;
		Label27.ForeColor = Color.FromArgb(220, 220, 220);
		Label27.Location = new Point(3, 614);
		Label27.Name = "Label27";
		Label27.Size = new Size(145, 15);
		Label27.TabIndex = 19;
		Label27.Text = "燃料储备海拔高度：";
		Label_ReserveLoiterTime.AutoSize = true;
		Label_ReserveLoiterTime.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ReserveLoiterTime.Location = new Point(3, 593);
		Label_ReserveLoiterTime.Name = "Label_ReserveLoiterTime";
		Label_ReserveLoiterTime.Size = new Size(129, 15);
		Label_ReserveLoiterTime.TabIndex = 18;
		Label_ReserveLoiterTime.Text = "燃料储备时间：";
		Label29.AutoSize = true;
		Label29.ForeColor = Color.FromArgb(220, 220, 220);
		Label29.Location = new Point(3, 572);
		Label29.Name = "Label29";
		Label29.Size = new Size(134, 15);
		Label29.TabIndex = 17;
		Label29.Text = "燃油储备百分比：";
		Label26.AutoSize = true;
		Label26.ForeColor = Color.FromArgb(220, 220, 220);
		Label26.Location = new Point(3, 550);
		Label26.Name = "Label26";
		Label26.Size = new Size(101, 15);
		Label26.TabIndex = 16;
		Label26.Text = "战斗持续时间：";
		Label25.AutoSize = true;
		Label25.ForeColor = Color.FromArgb(220, 220, 220);
		Label25.Location = new Point(3, 530);
		Label25.Name = "Label25";
		Label25.Size = new Size(95, 15);
		Label25.TabIndex = 16;
		Label25.Text = "战斗油门：";
		Label19.AutoSize = true;
		Label19.ForeColor = Color.FromArgb(220, 220, 220);
		Label19.Location = new Point(3, 337);
		Label19.Name = "Label19";
		Label19.Size = new Size(127, 15);
		Label19.TabIndex = 15;
		Label19.Text = "攻击离开距离：";
		Label18.AutoSize = true;
		Label18.ForeColor = Color.FromArgb(220, 220, 220);
		Label18.Location = new Point(2, 251);
		Label18.Name = "Label18";
		Label18.Size = new Size(131, 15);
		Label18.TabIndex = 14;
		Label18.Text = "攻击进入距离：";
		Label15.AutoSize = true;
		Label15.ForeColor = Color.FromArgb(220, 220, 220);
		Label15.Location = new Point(2, 396);
		Label15.Name = "Label15";
		Label15.Size = new Size(122, 15);
		Label15.TabIndex = 13;
		Label15.Text = "攻击离开油门：";
		Label17.AutoSize = true;
		Label17.ForeColor = Color.FromArgb(220, 220, 220);
		Label17.Location = new Point(3, 357);
		Label17.Name = "Label17";
		Label17.Size = new Size(123, 15);
		Label17.TabIndex = 11;
		Label17.Text = "攻击离开高度：";
		Label12.AutoSize = true;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(3, 315);
		Label12.Name = "Label12";
		Label12.Size = new Size(126, 15);
		Label12.TabIndex = 10;
		Label12.Text = "攻击进入油门：";
		Label14.AutoSize = true;
		Label14.ForeColor = Color.FromArgb(220, 220, 220);
		Label14.Location = new Point(2, 272);
		Label14.Name = "Label14";
		Label14.Size = new Size(127, 15);
		Label14.TabIndex = 8;
		Label14.Text = "攻击进入高度：";
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(2, 230);
		Label8.Name = "Label8";
		Label8.Size = new Size(121, 15);
		Label8.TabIndex = 7;
		Label8.Text = "巡航离开油门：";
		Label24.AutoSize = true;
		Label24.ForeColor = Color.FromArgb(220, 220, 220);
		Label24.Location = new Point(3, 508);
		Label24.Name = "Label24";
		Label24.Size = new Size(96, 15);
		Label24.TabIndex = 6;
		Label24.Text = "战斗高度：";
		Label23.AutoSize = true;
		Label23.ForeColor = Color.FromArgb(220, 220, 220);
		Label23.Location = new Point(3, 486);
		Label23.Name = "Label23";
		Label23.Size = new Size(89, 15);
		Label23.TabIndex = 6;
		Label23.Text = "驻扎油门：";
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(2, 166);
		Label7.Name = "Label7";
		Label7.Size = new Size(125, 15);
		Label7.TabIndex = 6;
		Label7.Text = "巡航进入油门：";
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(2, 188);
		Label6.Name = "Label6";
		Label6.Size = new Size(122, 15);
		Label6.TabIndex = 4;
		Label6.Text = "巡航离开高度：";
		Label21.AutoSize = true;
		Label21.ForeColor = Color.FromArgb(220, 220, 220);
		Label21.Location = new Point(3, 441);
		Label21.Name = "Label21";
		Label21.Size = new Size(90, 15);
		Label21.TabIndex = 2;
		Label21.Text = "驻扎高度：";
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(3, 120);
		Label3.Name = "Label3";
		Label3.Size = new Size(126, 15);
		Label3.TabIndex = 2;
		Label3.Text = "巡航进入高度：";
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(3, 56);
		Label2.Name = "Label2";
		Label2.Size = new Size(100, 15);
		Label2.TabIndex = 1;
		Label2.Text = "组合高度：";
		SplitContainer3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		SplitContainer3.Location = new Point(4, 74);
		SplitContainer3.Name = "SplitContainer3";
		SplitContainer3.Panel1.Controls.Add(SplitContainer1);
		SplitContainer3.Panel2.Controls.Add(Label4);
		SplitContainer3.Panel2.Controls.Add(CB_StationThrottle);
		SplitContainer3.Panel2.Controls.Add(CB_AttackEgressThrottle);
		SplitContainer3.Panel2.Controls.Add(CB_AttackIngressThrottle);
		SplitContainer3.Panel2.Controls.Add(CB_CruiseEgressThrottle);
		SplitContainer3.Panel2.Controls.Add(CB_CruiseIngressThrottle);
		SplitContainer3.Panel2.Controls.Add(CB_CombatThrottle);
		SplitContainer3.Panel2.Controls.Add(Label47);
		SplitContainer3.Panel2.Controls.Add(Label45);
		SplitContainer3.Panel2.Controls.Add(Label44);
		SplitContainer3.Panel2.Controls.Add(Label43);
		SplitContainer3.Panel2.Controls.Add(Label42);
		SplitContainer3.Panel2.Controls.Add(Label41);
		SplitContainer3.Panel2.Controls.Add(Label40);
		SplitContainer3.Panel2.Controls.Add(Label39);
		SplitContainer3.Panel2.Controls.Add(Label_CruiseIngressAltitude);
		SplitContainer3.Panel2.Controls.Add(Label_FormUpTime);
		SplitContainer3.Panel2.Controls.Add(CB_CruiseOneWayOnly);
		SplitContainer3.Panel2.Controls.Add(Label_FormUpAltitude);
		SplitContainer3.Panel2.Controls.Add(Label_PatrolTransitAltitude_Aircraft);
		SplitContainer3.Panel2.Controls.Add(TextBox_ReserveLoiterAltitude);
		SplitContainer3.Panel2.Controls.Add(DarkUITextBox_0);
		SplitContainer3.Panel2.Controls.Add(TextBox_ReservePercetage);
		SplitContainer3.Panel2.Controls.Add(TextBox_CombatDuration);
		SplitContainer3.Panel2.Controls.Add(TextBox_CombatAltitude);
		SplitContainer3.Panel2.Controls.Add(TextBox_StationAltitude);
		SplitContainer3.Panel2.Controls.Add(TextBox_AttackEgressAltitude);
		SplitContainer3.Panel2.Controls.Add(AttackEgressDistance);
		SplitContainer3.Panel2.Controls.Add(TextBox_AttackIngressAltitude);
		SplitContainer3.Panel2.Controls.Add(TextBox_AttackIngressDistance);
		SplitContainer3.Panel2.Controls.Add(CB_CruiseEgressAltitude);
		SplitContainer3.Panel2.Controls.Add(TextBox_CruiseIngressAltitude);
		SplitContainer3.Panel2.Controls.Add(TextBox_FormUpAltitude);
		SplitContainer3.Panel2.Controls.Add(CB_CruiseAtOptimumAltitude);
		SplitContainer3.Panel2.Controls.Add(CB_StationTerrainFollowing);
		SplitContainer3.Panel2.Controls.Add(CB_AttackEgressTerrainFollowing);
		SplitContainer3.Panel2.Controls.Add(CB_AttackIngressTerrainFollowing);
		SplitContainer3.Panel2.Controls.Add(CB_CruiseEgressTerrainFollowing);
		SplitContainer3.Panel2.Controls.Add(CB_CruiseIngressTerrainFollowing);
		SplitContainer3.Panel2.Controls.Add(CB_DropOrdnanceAtMaxRange);
		SplitContainer3.Panel2.Controls.Add(Label33);
		SplitContainer3.Panel2.Controls.Add(Label27);
		SplitContainer3.Panel2.Controls.Add(TextBox_FormUpTime);
		SplitContainer3.Panel2.Controls.Add(Label_ReserveLoiterTime);
		SplitContainer3.Panel2.Controls.Add(Label29);
		SplitContainer3.Panel2.Controls.Add(Label26);
		SplitContainer3.Panel2.Controls.Add(Label1);
		SplitContainer3.Panel2.Controls.Add(Label25);
		SplitContainer3.Panel2.Controls.Add(Label2);
		SplitContainer3.Panel2.Controls.Add(Label24);
		SplitContainer3.Panel2.Controls.Add(Label3);
		SplitContainer3.Panel2.Controls.Add(Label19);
		SplitContainer3.Panel2.Controls.Add(Label21);
		SplitContainer3.Panel2.Controls.Add(Label18);
		SplitContainer3.Panel2.Controls.Add(Label15);
		SplitContainer3.Panel2.Controls.Add(Label6);
		SplitContainer3.Panel2.Controls.Add(Label17);
		SplitContainer3.Panel2.Controls.Add(Label12);
		SplitContainer3.Panel2.Controls.Add(Label7);
		SplitContainer3.Panel2.Controls.Add(Label23);
		SplitContainer3.Panel2.Controls.Add(Label14);
		SplitContainer3.Panel2.Controls.Add(Label8);
		SplitContainer3.Size = new Size(1043, 641);
		SplitContainer3.SplitterDistance = 720;
		SplitContainer3.TabIndex = 44;
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.Location = new Point(0, 0);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Orientation = Orientation.Horizontal;
		SplitContainer1.Panel1.Controls.Add(SplitContainer2);
		SplitContainer1.Panel2.Controls.Add(Label30);
		SplitContainer1.Panel2.Controls.Add(Button_ClearSlots);
		SplitContainer1.Panel2.Controls.Add(ListBox_AssignedAircraft);
		SplitContainer1.Panel2.Controls.Add(Button_FillEmptySlots);
		SplitContainer1.Size = new Size(720, 641);
		SplitContainer1.SplitterDistance = 296;
		SplitContainer1.TabIndex = 45;
		SplitContainer2.Dock = DockStyle.Fill;
		SplitContainer2.Location = new Point(0, 0);
		SplitContainer2.Name = "SplitContainer2";
		SplitContainer2.Panel1.Controls.Add(Label31);
		SplitContainer2.Panel1.Controls.Add(ListBox_AircraftTypes);
		SplitContainer2.Panel2.Controls.Add(Label32);
		SplitContainer2.Panel2.Controls.Add(ListBox_Loadouts);
		SplitContainer2.Size = new Size(720, 296);
		SplitContainer2.SplitterDistance = 296;
		SplitContainer2.TabIndex = 0;
		Label31.AutoSize = true;
		Label31.Font = new Font("Segoe UI", 12f);
		Label31.ForeColor = Color.FromArgb(220, 220, 220);
		Label31.Location = new Point(3, 3);
		Label31.Name = "Label31";
		Label31.Size = new Size(95, 21);
		Label31.TabIndex = 17;
		Label31.Text = "飞机类型";
		Label32.AutoSize = true;
		Label32.Font = new Font("Segoe UI", 12f);
		Label32.ForeColor = Color.FromArgb(220, 220, 220);
		Label32.Location = new Point(3, 3);
		Label32.Name = "Label32";
		Label32.Size = new Size(101, 21);
		Label32.TabIndex = 18;
		Label32.Text = "挂载类型";
		Label30.AutoSize = true;
		Label30.Font = new Font("Segoe UI", 12f);
		Label30.ForeColor = Color.FromArgb(220, 220, 220);
		Label30.Location = new Point(3, 3);
		Label30.Name = "Label30";
		Label30.Size = new Size(126, 21);
		Label30.TabIndex = 19;
		Label30.Text = "指定的飞机";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(278, 590);
		Label4.Name = "Label4";
		Label4.Size = new Size(28, 15);
		Label4.TabIndex = 89;
		Label4.Text = "最小";
		CB_StationThrottle.BackColor = Color.Transparent;
		CB_StationThrottle.DrawMode = DrawMode.OwnerDrawFixed;
		CB_StationThrottle.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_StationThrottle.Font = new Font("Segoe UI", 7f);
		CB_StationThrottle.FormattingEnabled = true;
		CB_StationThrottle.Location = new Point(150, 480);
		CB_StationThrottle.Name = "CB_StationThrottle";
		CB_StationThrottle.Size = new Size(122, 21);
		CB_StationThrottle.TabIndex = 88;
		CB_AttackEgressThrottle.BackColor = Color.Transparent;
		CB_AttackEgressThrottle.DrawMode = DrawMode.OwnerDrawFixed;
		CB_AttackEgressThrottle.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_AttackEgressThrottle.Font = new Font("Segoe UI", 7f);
		CB_AttackEgressThrottle.FormattingEnabled = true;
		CB_AttackEgressThrottle.Location = new Point(150, 395);
		CB_AttackEgressThrottle.Name = "CB_AttackEgressThrottle";
		CB_AttackEgressThrottle.Size = new Size(122, 21);
		CB_AttackEgressThrottle.TabIndex = 87;
		CB_AttackIngressThrottle.BackColor = Color.Transparent;
		CB_AttackIngressThrottle.DrawMode = DrawMode.OwnerDrawFixed;
		CB_AttackIngressThrottle.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_AttackIngressThrottle.Font = new Font("Segoe UI", 7f);
		CB_AttackIngressThrottle.FormattingEnabled = true;
		CB_AttackIngressThrottle.Location = new Point(150, 309);
		CB_AttackIngressThrottle.Name = "CB_AttackIngressThrottle";
		CB_AttackIngressThrottle.Size = new Size(122, 21);
		CB_AttackIngressThrottle.TabIndex = 86;
		CB_CruiseEgressThrottle.BackColor = Color.Transparent;
		CB_CruiseEgressThrottle.DrawMode = DrawMode.OwnerDrawFixed;
		CB_CruiseEgressThrottle.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_CruiseEgressThrottle.Font = new Font("Segoe UI", 7f);
		CB_CruiseEgressThrottle.FormattingEnabled = true;
		CB_CruiseEgressThrottle.Location = new Point(149, 223);
		CB_CruiseEgressThrottle.Name = "CB_CruiseEgressThrottle";
		CB_CruiseEgressThrottle.Size = new Size(122, 21);
		CB_CruiseEgressThrottle.TabIndex = 85;
		CB_CruiseIngressThrottle.BackColor = Color.Transparent;
		CB_CruiseIngressThrottle.DrawMode = DrawMode.OwnerDrawFixed;
		CB_CruiseIngressThrottle.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_CruiseIngressThrottle.Font = new Font("Segoe UI", 7f);
		CB_CruiseIngressThrottle.FormattingEnabled = true;
		CB_CruiseIngressThrottle.Location = new Point(149, 160);
		CB_CruiseIngressThrottle.Name = "CB_CruiseIngressThrottle";
		CB_CruiseIngressThrottle.Size = new Size(122, 21);
		CB_CruiseIngressThrottle.TabIndex = 84;
		CB_CombatThrottle.BackColor = Color.Transparent;
		CB_CombatThrottle.DrawMode = DrawMode.OwnerDrawFixed;
		CB_CombatThrottle.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_CombatThrottle.Font = new Font("Segoe UI", 7f);
		CB_CombatThrottle.FormattingEnabled = true;
		CB_CombatThrottle.Location = new Point(150, 523);
		CB_CombatThrottle.Name = "CB_CombatThrottle";
		CB_CombatThrottle.Size = new Size(122, 21);
		CB_CombatThrottle.TabIndex = 47;
		Label47.AutoSize = true;
		Label47.ForeColor = Color.FromArgb(220, 220, 220);
		Label47.Location = new Point(278, 611);
		Label47.Name = "Label47";
		Label47.Size = new Size(18, 15);
		Label47.TabIndex = 83;
		Label47.Text = "米";
		Label45.AutoSize = true;
		Label45.ForeColor = Color.FromArgb(220, 220, 220);
		Label45.Location = new Point(278, 548);
		Label45.Name = "Label45";
		Label45.Size = new Size(28, 15);
		Label45.TabIndex = 81;
		Label45.Text = "最小";
		Label44.AutoSize = true;
		Label44.ForeColor = Color.FromArgb(220, 220, 220);
		Label44.Location = new Point(278, 506);
		Label44.Name = "Label44";
		Label44.Size = new Size(18, 15);
		Label44.TabIndex = 80;
		Label44.Text = "米";
		Label43.AutoSize = true;
		Label43.ForeColor = Color.FromArgb(220, 220, 220);
		Label43.Location = new Point(278, 335);
		Label43.Name = "Label43";
		Label43.Size = new Size(25, 15);
		Label43.TabIndex = 79;
		Label43.Text = "海里";
		Label42.AutoSize = true;
		Label42.ForeColor = Color.FromArgb(220, 220, 220);
		Label42.Location = new Point(278, 354);
		Label42.Name = "Label42";
		Label42.Size = new Size(18, 15);
		Label42.TabIndex = 78;
		Label42.Text = "米";
		Label41.AutoSize = true;
		Label41.ForeColor = Color.FromArgb(220, 220, 220);
		Label41.Location = new Point(277, 269);
		Label41.Name = "Label41";
		Label41.Size = new Size(18, 15);
		Label41.TabIndex = 77;
		Label41.Text = "米";
		Label40.AutoSize = true;
		Label40.ForeColor = Color.FromArgb(220, 220, 220);
		Label40.Location = new Point(277, 248);
		Label40.Name = "Label40";
		Label40.Size = new Size(25, 15);
		Label40.TabIndex = 76;
		Label40.Text = "海里";
		Label39.AutoSize = true;
		Label39.ForeColor = Color.FromArgb(220, 220, 220);
		Label39.Location = new Point(277, 185);
		Label39.Name = "Label39";
		Label39.Size = new Size(18, 15);
		Label39.TabIndex = 75;
		Label39.Text = "米";
		Label_CruiseIngressAltitude.AutoSize = true;
		Label_CruiseIngressAltitude.ForeColor = Color.FromArgb(220, 220, 220);
		Label_CruiseIngressAltitude.Location = new Point(278, 117);
		Label_CruiseIngressAltitude.Name = "Label_CruiseIngressAltitude";
		Label_CruiseIngressAltitude.Size = new Size(18, 15);
		Label_CruiseIngressAltitude.TabIndex = 74;
		Label_CruiseIngressAltitude.Text = "米";
		Label_FormUpTime.AutoSize = true;
		Label_FormUpTime.ForeColor = Color.FromArgb(220, 220, 220);
		Label_FormUpTime.Location = new Point(278, 35);
		Label_FormUpTime.Name = "Label_FormUpTime";
		Label_FormUpTime.Size = new Size(28, 15);
		Label_FormUpTime.TabIndex = 73;
		Label_FormUpTime.Text = "最小";
		CB_CruiseOneWayOnly.AutoSize = true;
		CB_CruiseOneWayOnly.Location = new Point(6, 97);
		CB_CruiseOneWayOnly.Name = "CB_CruiseOneWayOnly";
		CB_CruiseOneWayOnly.Size = new Size(132, 19);
		CB_CruiseOneWayOnly.TabIndex = 72;
		CB_CruiseOneWayOnly.Text = "仅限单程";
		Label_FormUpAltitude.AutoSize = true;
		Label_FormUpAltitude.ForeColor = Color.FromArgb(220, 220, 220);
		Label_FormUpAltitude.Location = new Point(278, 54);
		Label_FormUpAltitude.Name = "Label_FormUpAltitude";
		Label_FormUpAltitude.Size = new Size(18, 15);
		Label_FormUpAltitude.TabIndex = 71;
		Label_FormUpAltitude.Text = "米";
		Label_PatrolTransitAltitude_Aircraft.AutoSize = true;
		Label_PatrolTransitAltitude_Aircraft.ForeColor = Color.FromArgb(220, 220, 220);
		Label_PatrolTransitAltitude_Aircraft.Location = new Point(278, 441);
		Label_PatrolTransitAltitude_Aircraft.Name = "Label_PatrolTransitAltitude_Aircraft";
		Label_PatrolTransitAltitude_Aircraft.Size = new Size(18, 15);
		Label_PatrolTransitAltitude_Aircraft.TabIndex = 70;
		Label_PatrolTransitAltitude_Aircraft.Text = "米";
		TextBox_ReserveLoiterAltitude.AutoCompleteCustomSource = null;
		TextBox_ReserveLoiterAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_ReserveLoiterAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_ReserveLoiterAltitude.BackColor = Color.Transparent;
		TextBox_ReserveLoiterAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_ReserveLoiterAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_ReserveLoiterAltitude.Image = null;
		TextBox_ReserveLoiterAltitude.Lines = null;
		TextBox_ReserveLoiterAltitude.Location = new Point(150, 608);
		TextBox_ReserveLoiterAltitude.MaxLength = 32767;
		TextBox_ReserveLoiterAltitude.Multiline = false;
		TextBox_ReserveLoiterAltitude.Name = "TextBox_ReserveLoiterAltitude";
		TextBox_ReserveLoiterAltitude.ReadOnly = false;
		TextBox_ReserveLoiterAltitude.ScrollBars = ScrollBars.None;
		TextBox_ReserveLoiterAltitude.SelectionStart = 0;
		TextBox_ReserveLoiterAltitude.Size = new Size(122, 20);
		TextBox_ReserveLoiterAltitude.TabIndex = 69;
		TextBox_ReserveLoiterAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_ReserveLoiterAltitude.UseSystemPasswordChar = false;
		TextBox_ReserveLoiterAltitude.WatermarkText = "";
		DarkUITextBox_0.AutoCompleteCustomSource = null;
		DarkUITextBox_0.AutoCompleteMode = AutoCompleteMode.None;
		DarkUITextBox_0.AutoCompleteSource = AutoCompleteSource.None;
		DarkUITextBox_0.BackColor = Color.Transparent;
		DarkUITextBox_0.Font = new Font("Segoe UI", 8f);
		DarkUITextBox_0.ForeColor = Color.FromArgb(189, 189, 189);
		DarkUITextBox_0.Image = null;
		DarkUITextBox_0.Lines = null;
		DarkUITextBox_0.Location = new Point(150, 587);
		DarkUITextBox_0.MaxLength = 32767;
		DarkUITextBox_0.Multiline = false;
		DarkUITextBox_0.Name = "TextBox18";
		DarkUITextBox_0.ReadOnly = false;
		DarkUITextBox_0.ScrollBars = ScrollBars.None;
		DarkUITextBox_0.SelectionStart = 0;
		DarkUITextBox_0.Size = new Size(122, 20);
		DarkUITextBox_0.TabIndex = 68;
		DarkUITextBox_0.TextAlign = HorizontalAlignment.Left;
		DarkUITextBox_0.UseSystemPasswordChar = false;
		DarkUITextBox_0.WatermarkText = "";
		TextBox_ReservePercetage.AutoCompleteCustomSource = null;
		TextBox_ReservePercetage.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_ReservePercetage.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_ReservePercetage.BackColor = Color.Transparent;
		TextBox_ReservePercetage.Font = new Font("Segoe UI", 8f);
		TextBox_ReservePercetage.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_ReservePercetage.Image = null;
		TextBox_ReservePercetage.Lines = null;
		TextBox_ReservePercetage.Location = new Point(150, 566);
		TextBox_ReservePercetage.MaxLength = 32767;
		TextBox_ReservePercetage.Multiline = false;
		TextBox_ReservePercetage.Name = "TextBox_ReservePercetage";
		TextBox_ReservePercetage.ReadOnly = false;
		TextBox_ReservePercetage.ScrollBars = ScrollBars.None;
		TextBox_ReservePercetage.SelectionStart = 0;
		TextBox_ReservePercetage.Size = new Size(122, 20);
		TextBox_ReservePercetage.TabIndex = 67;
		TextBox_ReservePercetage.TextAlign = HorizontalAlignment.Left;
		TextBox_ReservePercetage.UseSystemPasswordChar = false;
		TextBox_ReservePercetage.WatermarkText = "";
		TextBox_CombatDuration.AutoCompleteCustomSource = null;
		TextBox_CombatDuration.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_CombatDuration.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_CombatDuration.BackColor = Color.Transparent;
		TextBox_CombatDuration.Font = new Font("Segoe UI", 8f);
		TextBox_CombatDuration.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_CombatDuration.Image = null;
		TextBox_CombatDuration.Lines = null;
		TextBox_CombatDuration.Location = new Point(150, 545);
		TextBox_CombatDuration.MaxLength = 32767;
		TextBox_CombatDuration.Multiline = false;
		TextBox_CombatDuration.Name = "TextBox_CombatDuration";
		TextBox_CombatDuration.ReadOnly = false;
		TextBox_CombatDuration.ScrollBars = ScrollBars.None;
		TextBox_CombatDuration.SelectionStart = 0;
		TextBox_CombatDuration.Size = new Size(122, 20);
		TextBox_CombatDuration.TabIndex = 66;
		TextBox_CombatDuration.TextAlign = HorizontalAlignment.Left;
		TextBox_CombatDuration.UseSystemPasswordChar = false;
		TextBox_CombatDuration.WatermarkText = "";
		TextBox_CombatAltitude.AutoCompleteCustomSource = null;
		TextBox_CombatAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_CombatAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_CombatAltitude.BackColor = Color.Transparent;
		TextBox_CombatAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_CombatAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_CombatAltitude.Image = null;
		TextBox_CombatAltitude.Lines = null;
		TextBox_CombatAltitude.Location = new Point(150, 502);
		TextBox_CombatAltitude.MaxLength = 32767;
		TextBox_CombatAltitude.Multiline = false;
		TextBox_CombatAltitude.Name = "TextBox_CombatAltitude";
		TextBox_CombatAltitude.ReadOnly = false;
		TextBox_CombatAltitude.ScrollBars = ScrollBars.None;
		TextBox_CombatAltitude.SelectionStart = 0;
		TextBox_CombatAltitude.Size = new Size(122, 20);
		TextBox_CombatAltitude.TabIndex = 65;
		TextBox_CombatAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_CombatAltitude.UseSystemPasswordChar = false;
		TextBox_CombatAltitude.WatermarkText = "";
		TextBox_StationAltitude.AutoCompleteCustomSource = null;
		TextBox_StationAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_StationAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_StationAltitude.BackColor = Color.Transparent;
		TextBox_StationAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_StationAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_StationAltitude.Image = null;
		TextBox_StationAltitude.Lines = null;
		TextBox_StationAltitude.Location = new Point(150, 436);
		TextBox_StationAltitude.MaxLength = 32767;
		TextBox_StationAltitude.Multiline = false;
		TextBox_StationAltitude.Name = "TextBox_StationAltitude";
		TextBox_StationAltitude.ReadOnly = false;
		TextBox_StationAltitude.ScrollBars = ScrollBars.None;
		TextBox_StationAltitude.SelectionStart = 0;
		TextBox_StationAltitude.Size = new Size(122, 20);
		TextBox_StationAltitude.TabIndex = 63;
		TextBox_StationAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_StationAltitude.UseSystemPasswordChar = false;
		TextBox_StationAltitude.WatermarkText = "";
		TextBox_AttackEgressAltitude.AutoCompleteCustomSource = null;
		TextBox_AttackEgressAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_AttackEgressAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_AttackEgressAltitude.BackColor = Color.Transparent;
		TextBox_AttackEgressAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_AttackEgressAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_AttackEgressAltitude.Image = null;
		TextBox_AttackEgressAltitude.Lines = null;
		TextBox_AttackEgressAltitude.Location = new Point(150, 352);
		TextBox_AttackEgressAltitude.MaxLength = 32767;
		TextBox_AttackEgressAltitude.Multiline = false;
		TextBox_AttackEgressAltitude.Name = "TextBox_AttackEgressAltitude";
		TextBox_AttackEgressAltitude.ReadOnly = false;
		TextBox_AttackEgressAltitude.ScrollBars = ScrollBars.None;
		TextBox_AttackEgressAltitude.SelectionStart = 0;
		TextBox_AttackEgressAltitude.Size = new Size(122, 20);
		TextBox_AttackEgressAltitude.TabIndex = 61;
		TextBox_AttackEgressAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_AttackEgressAltitude.UseSystemPasswordChar = false;
		TextBox_AttackEgressAltitude.WatermarkText = "";
		AttackEgressDistance.AutoCompleteCustomSource = null;
		AttackEgressDistance.AutoCompleteMode = AutoCompleteMode.None;
		AttackEgressDistance.AutoCompleteSource = AutoCompleteSource.None;
		AttackEgressDistance.BackColor = Color.Transparent;
		AttackEgressDistance.Font = new Font("Segoe UI", 8f);
		AttackEgressDistance.ForeColor = Color.FromArgb(189, 189, 189);
		AttackEgressDistance.Image = null;
		AttackEgressDistance.Lines = null;
		AttackEgressDistance.Location = new Point(150, 331);
		AttackEgressDistance.MaxLength = 32767;
		AttackEgressDistance.Multiline = false;
		AttackEgressDistance.Name = "AttackEgressDistance";
		AttackEgressDistance.ReadOnly = false;
		AttackEgressDistance.ScrollBars = ScrollBars.None;
		AttackEgressDistance.SelectionStart = 0;
		AttackEgressDistance.Size = new Size(122, 20);
		AttackEgressDistance.TabIndex = 60;
		AttackEgressDistance.TextAlign = HorizontalAlignment.Left;
		AttackEgressDistance.UseSystemPasswordChar = false;
		AttackEgressDistance.WatermarkText = "";
		TextBox_AttackIngressAltitude.AutoCompleteCustomSource = null;
		TextBox_AttackIngressAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_AttackIngressAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_AttackIngressAltitude.BackColor = Color.Transparent;
		TextBox_AttackIngressAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_AttackIngressAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_AttackIngressAltitude.Image = null;
		TextBox_AttackIngressAltitude.Lines = null;
		TextBox_AttackIngressAltitude.Location = new Point(149, 266);
		TextBox_AttackIngressAltitude.MaxLength = 32767;
		TextBox_AttackIngressAltitude.Multiline = false;
		TextBox_AttackIngressAltitude.Name = "TextBox_AttackIngressAltitude";
		TextBox_AttackIngressAltitude.ReadOnly = false;
		TextBox_AttackIngressAltitude.ScrollBars = ScrollBars.None;
		TextBox_AttackIngressAltitude.SelectionStart = 0;
		TextBox_AttackIngressAltitude.Size = new Size(122, 20);
		TextBox_AttackIngressAltitude.TabIndex = 58;
		TextBox_AttackIngressAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_AttackIngressAltitude.UseSystemPasswordChar = false;
		TextBox_AttackIngressAltitude.WatermarkText = "";
		TextBox_AttackIngressDistance.AutoCompleteCustomSource = null;
		TextBox_AttackIngressDistance.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_AttackIngressDistance.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_AttackIngressDistance.BackColor = Color.Transparent;
		TextBox_AttackIngressDistance.Font = new Font("Segoe UI", 8f);
		TextBox_AttackIngressDistance.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_AttackIngressDistance.Image = null;
		TextBox_AttackIngressDistance.Lines = null;
		TextBox_AttackIngressDistance.Location = new Point(149, 245);
		TextBox_AttackIngressDistance.MaxLength = 32767;
		TextBox_AttackIngressDistance.Multiline = false;
		TextBox_AttackIngressDistance.Name = "TextBox_AttackIngressDistance";
		TextBox_AttackIngressDistance.ReadOnly = false;
		TextBox_AttackIngressDistance.ScrollBars = ScrollBars.None;
		TextBox_AttackIngressDistance.SelectionStart = 0;
		TextBox_AttackIngressDistance.Size = new Size(122, 20);
		TextBox_AttackIngressDistance.TabIndex = 57;
		TextBox_AttackIngressDistance.TextAlign = HorizontalAlignment.Left;
		TextBox_AttackIngressDistance.UseSystemPasswordChar = false;
		TextBox_AttackIngressDistance.WatermarkText = "";
		CB_CruiseEgressAltitude.AutoCompleteCustomSource = null;
		CB_CruiseEgressAltitude.AutoCompleteMode = AutoCompleteMode.None;
		CB_CruiseEgressAltitude.AutoCompleteSource = AutoCompleteSource.None;
		CB_CruiseEgressAltitude.BackColor = Color.Transparent;
		CB_CruiseEgressAltitude.Font = new Font("Segoe UI", 8f);
		CB_CruiseEgressAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		CB_CruiseEgressAltitude.Image = null;
		CB_CruiseEgressAltitude.Lines = null;
		CB_CruiseEgressAltitude.Location = new Point(149, 182);
		CB_CruiseEgressAltitude.MaxLength = 32767;
		CB_CruiseEgressAltitude.Multiline = false;
		CB_CruiseEgressAltitude.Name = "CB_CruiseEgressAltitude";
		CB_CruiseEgressAltitude.ReadOnly = false;
		CB_CruiseEgressAltitude.ScrollBars = ScrollBars.None;
		CB_CruiseEgressAltitude.SelectionStart = 0;
		CB_CruiseEgressAltitude.Size = new Size(122, 20);
		CB_CruiseEgressAltitude.TabIndex = 55;
		CB_CruiseEgressAltitude.TextAlign = HorizontalAlignment.Left;
		CB_CruiseEgressAltitude.UseSystemPasswordChar = false;
		CB_CruiseEgressAltitude.WatermarkText = "";
		TextBox_CruiseIngressAltitude.AutoCompleteCustomSource = null;
		TextBox_CruiseIngressAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_CruiseIngressAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_CruiseIngressAltitude.BackColor = Color.Transparent;
		TextBox_CruiseIngressAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_CruiseIngressAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_CruiseIngressAltitude.Image = null;
		TextBox_CruiseIngressAltitude.Lines = null;
		TextBox_CruiseIngressAltitude.Location = new Point(150, 114);
		TextBox_CruiseIngressAltitude.MaxLength = 32767;
		TextBox_CruiseIngressAltitude.Multiline = false;
		TextBox_CruiseIngressAltitude.Name = "TextBox_CruiseIngressAltitude";
		TextBox_CruiseIngressAltitude.ReadOnly = false;
		TextBox_CruiseIngressAltitude.ScrollBars = ScrollBars.None;
		TextBox_CruiseIngressAltitude.SelectionStart = 0;
		TextBox_CruiseIngressAltitude.Size = new Size(122, 20);
		TextBox_CruiseIngressAltitude.TabIndex = 53;
		TextBox_CruiseIngressAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_CruiseIngressAltitude.UseSystemPasswordChar = false;
		TextBox_CruiseIngressAltitude.WatermarkText = "";
		TextBox_FormUpAltitude.AutoCompleteCustomSource = null;
		TextBox_FormUpAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_FormUpAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_FormUpAltitude.BackColor = Color.Transparent;
		TextBox_FormUpAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_FormUpAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FormUpAltitude.Image = null;
		TextBox_FormUpAltitude.Lines = null;
		TextBox_FormUpAltitude.Location = new Point(150, 51);
		TextBox_FormUpAltitude.MaxLength = 32767;
		TextBox_FormUpAltitude.Multiline = false;
		TextBox_FormUpAltitude.Name = "TextBox_FormUpAltitude";
		TextBox_FormUpAltitude.ReadOnly = false;
		TextBox_FormUpAltitude.ScrollBars = ScrollBars.None;
		TextBox_FormUpAltitude.SelectionStart = 0;
		TextBox_FormUpAltitude.Size = new Size(122, 20);
		TextBox_FormUpAltitude.TabIndex = 51;
		TextBox_FormUpAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_FormUpAltitude.UseSystemPasswordChar = false;
		TextBox_FormUpAltitude.WatermarkText = "";
		CB_CruiseAtOptimumAltitude.Location = new Point(6, 75);
		CB_CruiseAtOptimumAltitude.Name = "CB_CruiseAtOptimumAltitude";
		CB_CruiseAtOptimumAltitude.Size = new Size(226, 16);
		CB_CruiseAtOptimumAltitude.TabIndex = 50;
		CB_CruiseAtOptimumAltitude.Text = "在最佳高度巡航";
		CB_StationTerrainFollowing.AutoSize = true;
		CB_StationTerrainFollowing.Location = new Point(6, 459);
		CB_StationTerrainFollowing.Name = "CB_StationTerrainFollowing";
		CB_StationTerrainFollowing.Size = new Size(155, 19);
		CB_StationTerrainFollowing.TabIndex = 49;
		CB_StationTerrainFollowing.Text = "地形跟随";
		CB_AttackEgressTerrainFollowing.Location = new Point(6, 376);
		CB_AttackEgressTerrainFollowing.Name = "CB_AttackEgressTerrainFollowing";
		CB_AttackEgressTerrainFollowing.Size = new Size(226, 17);
		CB_AttackEgressTerrainFollowing.TabIndex = 48;
		CB_AttackEgressTerrainFollowing.Text = "攻击离开地形跟随";
		CB_AttackIngressTerrainFollowing.Location = new Point(6, 290);
		CB_AttackIngressTerrainFollowing.Name = "CB_AttackIngressTerrainFollowing";
		CB_AttackIngressTerrainFollowing.Size = new Size(271, 20);
		CB_AttackIngressTerrainFollowing.TabIndex = 47;
		CB_AttackIngressTerrainFollowing.Text = "攻击进入地形跟随";
		CB_CruiseEgressTerrainFollowing.Location = new Point(5, 206);
		CB_CruiseEgressTerrainFollowing.Name = "CB_CruiseEgressTerrainFollowing";
		CB_CruiseEgressTerrainFollowing.Size = new Size(272, 21);
		CB_CruiseEgressTerrainFollowing.TabIndex = 46;
		CB_CruiseEgressTerrainFollowing.Text = "巡航离开地形跟随";
		CB_CruiseIngressTerrainFollowing.Location = new Point(5, 140);
		CB_CruiseIngressTerrainFollowing.Name = "CB_CruiseIngressTerrainFollowing";
		CB_CruiseIngressTerrainFollowing.Size = new Size(251, 20);
		CB_CruiseIngressTerrainFollowing.TabIndex = 45;
		CB_CruiseIngressTerrainFollowing.Text = "巡航进入地形跟随";
		CB_DropOrdnanceAtMaxRange.AutoSize = true;
		CB_DropOrdnanceAtMaxRange.Location = new Point(6, 414);
		CB_DropOrdnanceAtMaxRange.Name = "CB_DropOrdnanceAtMaxRange";
		CB_DropOrdnanceAtMaxRange.Size = new Size(177, 19);
		CB_DropOrdnanceAtMaxRange.TabIndex = 44;
		CB_DropOrdnanceAtMaxRange.Text = "丢弃弹药最大范围";
		Label33.AutoSize = true;
		Label33.Font = new Font("Segoe UI", 12f);
		Label33.ForeColor = Color.FromArgb(220, 220, 220);
		Label33.Location = new Point(21, 3);
		Label33.Name = "Label33";
		Label33.Size = new Size(55, 21);
		Label33.TabIndex = 19;
		Label33.Text = "轮廓";
		Button_ChangeTakeOffLocation.BackColor = Color.Transparent;
		Button_ChangeTakeOffLocation.DialogResult = DialogResult.None;
		Button_ChangeTakeOffLocation.Font = new Font("Segoe UI", 10f);
		Button_ChangeTakeOffLocation.ForeColor = SystemColors.Control;
		Button_ChangeTakeOffLocation.Location = new Point(543, 7);
		Button_ChangeTakeOffLocation.Name = "Button_ChangeTakeOffLocation";
		Button_ChangeTakeOffLocation.Padding = new Padding(5);
		Button_ChangeTakeOffLocation.RoundRadius = 0;
		Button_ChangeTakeOffLocation.Size = new Size(157, 21);
		Button_ChangeTakeOffLocation.TabIndex = 49;
		Button_ChangeTakeOffLocation.Text = "改变起飞位置";
		Label34.AutoSize = true;
		Label34.ForeColor = Color.FromArgb(220, 220, 220);
		Label34.Location = new Point(706, 13);
		Label34.Name = "Label34";
		Label34.Size = new Size(99, 15);
		Label34.TabIndex = 48;
		Label34.Text = "起飞地点：";
		Label_TakeOffLocation.AutoSize = true;
		Label_TakeOffLocation.ForeColor = Color.FromArgb(220, 220, 220);
		Label_TakeOffLocation.Location = new Point(811, 13);
		Label_TakeOffLocation.Name = "Label_TakeOffLocation";
		Label_TakeOffLocation.Size = new Size(112, 15);
		Label_TakeOffLocation.TabIndex = 47;
		Label_TakeOffLocation.Text = "<起飞位置>";
		Label35.AutoSize = true;
		Label35.ForeColor = Color.FromArgb(220, 220, 220);
		Label35.Location = new Point(302, 7);
		Label35.Name = "Label35";
		Label35.Size = new Size(102, 15);
		Label35.TabIndex = 45;
		Label35.Text = "所需编队大小：";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(302, 29);
		Label5.Name = "Label5";
		Label5.Size = new Size(116, 15);
		Label5.TabIndex = 90;
		Label5.Text = "最小编队尺寸：";
		TxtDesiredSize.AutoCompleteCustomSource = null;
		TxtDesiredSize.AutoCompleteMode = AutoCompleteMode.None;
		TxtDesiredSize.AutoCompleteSource = AutoCompleteSource.None;
		TxtDesiredSize.BackColor = Color.Transparent;
		TxtDesiredSize.ForeColor = Color.FromArgb(189, 189, 189);
		TxtDesiredSize.Image = null;
		TxtDesiredSize.Lines = null;
		TxtDesiredSize.Location = new Point(430, 6);
		TxtDesiredSize.MaxLength = 32767;
		TxtDesiredSize.Multiline = false;
		TxtDesiredSize.Name = "TxtDesiredSize";
		TxtDesiredSize.ReadOnly = false;
		TxtDesiredSize.ScrollBars = ScrollBars.None;
		TxtDesiredSize.SelectionStart = 0;
		TxtDesiredSize.Size = new Size(93, 17);
		TxtDesiredSize.TabIndex = 91;
		TxtDesiredSize.TextAlign = HorizontalAlignment.Left;
		TxtDesiredSize.UseSystemPasswordChar = false;
		TxtDesiredSize.WatermarkText = "";
		TxtMinimumSize.AutoCompleteCustomSource = null;
		TxtMinimumSize.AutoCompleteMode = AutoCompleteMode.None;
		TxtMinimumSize.AutoCompleteSource = AutoCompleteSource.None;
		TxtMinimumSize.BackColor = Color.Transparent;
		TxtMinimumSize.ForeColor = Color.FromArgb(189, 189, 189);
		TxtMinimumSize.Image = null;
		TxtMinimumSize.Lines = null;
		TxtMinimumSize.Location = new Point(430, 29);
		TxtMinimumSize.MaxLength = 32767;
		TxtMinimumSize.Multiline = false;
		TxtMinimumSize.Name = "TxtMinimumSize";
		TxtMinimumSize.ReadOnly = false;
		TxtMinimumSize.ScrollBars = ScrollBars.None;
		TxtMinimumSize.SelectionStart = 0;
		TxtMinimumSize.Size = new Size(93, 17);
		TxtMinimumSize.TabIndex = 92;
		TxtMinimumSize.TextAlign = HorizontalAlignment.Left;
		TxtMinimumSize.UseSystemPasswordChar = false;
		TxtMinimumSize.WatermarkText = "";
		Button_Change_Landing_location.BackColor = Color.Transparent;
		Button_Change_Landing_location.DialogResult = DialogResult.None;
		Button_Change_Landing_location.Font = new Font("Segoe UI", 10f);
		Button_Change_Landing_location.ForeColor = SystemColors.Control;
		Button_Change_Landing_location.Location = new Point(543, 47);
		Button_Change_Landing_location.Name = "Button_Change_Landing_location";
		Button_Change_Landing_location.Padding = new Padding(5);
		Button_Change_Landing_location.RoundRadius = 0;
		Button_Change_Landing_location.Size = new Size(157, 21);
		Button_Change_Landing_location.TabIndex = 93;
		Button_Change_Landing_location.Text = "更改着陆位置";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(706, 53);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(99, 15);
		DarkLabel1.TabIndex = 95;
		DarkLabel1.Text = "着陆地点：";
		Label_LandingLocation.AutoSize = true;
		Label_LandingLocation.ForeColor = Color.FromArgb(220, 220, 220);
		Label_LandingLocation.Location = new Point(811, 53);
		Label_LandingLocation.Name = "Label_LandingLocation";
		Label_LandingLocation.Size = new Size(112, 15);
		Label_LandingLocation.TabIndex = 94;
		Label_LandingLocation.Text = "<降落位置>";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1044, 717);
		base.Controls.Add(DarkLabel1);
		base.Controls.Add(Label_LandingLocation);
		base.Controls.Add(Button_Change_Landing_location);
		base.Controls.Add(TxtMinimumSize);
		base.Controls.Add(TxtDesiredSize);
		base.Controls.Add(Button_ChangeTakeOffLocation);
		base.Controls.Add(Label34);
		base.Controls.Add(Label_TakeOffLocation);
		base.Controls.Add(Label5);
		base.Controls.Add(Label35);
		base.Controls.Add(SplitContainer3);
		base.Controls.Add(ComboBox_FlightplanType);
		base.Controls.Add(Label9);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(1024, 730);
		base.Name = "FlightPlanAircraftLoadout";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "选择编队的飞机和挂载";
		SplitContainer3.Panel1.ResumeLayout(performLayout: false);
		SplitContainer3.Panel2.ResumeLayout(performLayout: false);
		SplitContainer3.Panel2.PerformLayout();
		((ISupportInitialize)SplitContainer3).EndInit();
		SplitContainer3.ResumeLayout(performLayout: false);
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.PerformLayout();
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		SplitContainer2.Panel1.ResumeLayout(performLayout: false);
		SplitContainer2.Panel1.PerformLayout();
		SplitContainer2.Panel2.ResumeLayout(performLayout: false);
		SplitContainer2.Panel2.PerformLayout();
		((ISupportInitialize)SplitContainer2).EndInit();
		SplitContainer2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void PopSystem(object sender, FormClosingEventArgs e)
	{
		PrintSystem(null);
		DefineSystem(null);
		e.Cancel = true;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void InstantiateSystem(object sender, FormClosedEventArgs e)
	{
	}

	private void CreateSystem(object sender, EventArgs e)
	{
	}

	private void CompareSystem(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Hide();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	public void ReloadWindow()
	{
		LoadWindow();
	}

	public void LoadWindow()
	{
		TxtMinimumSize.Text = SelectedFlight.MinimumAircraftQty.value.ToString();
		TxtDesiredSize.Text = SelectedFlight.DesiredAircraftQty.value.ToString();
		ReadSystem();
	}

	internal void ReadSystem()
	{
		try
		{
			if (Information.IsNothing(SelectedMission))
			{
				Text = "飞行编队编辑";
				return;
			}
			if (Information.IsNothing(SelectedFlight))
			{
				Text = "飞行编队编辑";
			}
			else
			{
				Text = "飞行计划编辑" + SelectedFlight.Callsign;
			}
			if (!Information.IsNothing(SelectedFlight) && SelectedMission.RestartValue())
			{
				if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
				{
					new DataTable();
					new DataTable();
					DataTable dataTable_ = new DataTable();
					Mission.Flight.ComboBoxDataSource_Type(ref dataTable_);
					DarkUIComboBox comboBox_FlightplanType = ComboBox_FlightplanType;
					comboBox_FlightplanType.DataSource = dataTable_;
					comboBox_FlightplanType.DisplayMember = "Description";
					comboBox_FlightplanType.ValueMember = "ID";
					comboBox_FlightplanType.DropDownWidth = 500;
					ComboBox_FlightplanType.SelectedIndex = Mission.Flight.Type_To_TypeSelection((int)SelectedFlight.Type);
					UpdateSystem();
					if (ListBox_AircraftTypes.Items.Count > 0)
					{
						InsertSystem();
					}
					PrepareSystem();
					Label_TakeOffLocation.Text = SelectedFlight.TakeOffLocation_HostUnitObjectName;
					Label_LandingLocation.Text = SelectedFlight.LandingLocation_HostUnitObjectName;
				}
			}
			else
			{
				TxtDesiredSize.Text = "";
				TxtMinimumSize.Text = "";
				ComboBox_FlightplanType.DataSource = null;
				ComboBox_FlightplanType.Items.Clear();
				ComboBox_FlightplanType.SelectedIndex = -1;
				ListBox_AircraftTypes.Items.Clear();
				ListBox_Loadouts.Items.Clear();
				ListBox_AssignedAircraft.Items.Clear();
				Label_TakeOffLocation.Text = "";
				Label_LandingLocation.Text = "";
			}
			DisableSystem();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void DisableSystem()
	{
		if (!Information.IsNothing(SelectedFlight) && SelectedFlight.Type == Mission._FlightType.Flightplan)
		{
			Button_ClearSlots.Enabled = true;
			Button_FillEmptySlots.Enabled = true;
			ListBox_AssignedAircraft.Enabled = true;
			Label30.Enabled = true;
		}
		else
		{
			Button_ClearSlots.Enabled = false;
			Button_FillEmptySlots.Enabled = false;
			ListBox_AssignedAircraft.Enabled = false;
			Label30.Enabled = false;
		}
		Button_FillEmptySlots.Visible = false;
		Button_ClearSlots.Visible = false;
	}

	private void UpdateSystem()
	{
		try
		{
			ListBox_AircraftTypes.Items.Clear();
			List<ActiveUnit> list = Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario);
			int count = list.Count;
			DarkListItem item = new DarkListItem
			{
				Text = "任意类型",
				Tag = 0
			};
			ListBox_AircraftTypes.Items.Add(item);
			list = list.Select((ActiveUnit theAC) => theAC).OrderBy((ActiveUnit theAirc) => theAirc.Name, new NaturalSortComparer<string[]>()).ToList();
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (Information.IsNothing(activeUnit) || !activeUnit.IsAircraft)
				{
					continue;
				}
				int dBID = activeUnit.DBID;
				bool flag = false;
				int num2 = ListBox_AircraftTypes.Items.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					object obj = ListBox_AircraftTypes.Items[j];
					if (activeUnit.DBID == (int)((DarkListItem)obj).Tag)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					DarkListItem darkListItem = new DarkListItem();
					darkListItem.Text = activeUnit.UnitClass;
					darkListItem.Tag = dBID;
					ListBox_AircraftTypes.Items.Add(darkListItem);
				}
			}
			ListBox_AircraftTypes.SelectedIndices.Clear();
			int num3 = ListBox_AircraftTypes.Items.Count - 1;
			for (int k = 0; k <= num3; k++)
			{
				object obj2 = ListBox_AircraftTypes.Items[k];
				if (SelectedFlight.ReferenceUnit_DBID == (int)((DarkListItem)obj2).Tag)
				{
					ListBox_AircraftTypes.SelectItem(0);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void InsertSystem()
	{
		try
		{
			ListBox_Loadouts.Items.Clear();
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = "任何挂载";
			darkListItem.Tag = 0;
			ListBox_Loadouts.Items.Add(darkListItem);
			ListBox_Loadouts.SelectItem(0);
			if (SelectedFlight.ReferenceUnit_DBID == 0)
			{
				return;
			}
			List<Loadout> list = DBFunctions.LoadoutsForThisAircraft(SelectedFlight.ReferenceUnit_DBID, Client.CurrentScenario);
			int count = list.Count;
			list = list.Select((Loadout theL) => theL).OrderBy((Loadout theLoadO) => theLoadO.Name, new NaturalSortComparer<string[]>()).ToList();
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				Loadout loadout = list[i];
				DarkListItem darkListItem2 = new DarkListItem();
				darkListItem2.Text = loadout.Name;
				darkListItem2.Tag = loadout.DBID;
				ListBox_Loadouts.Items.Add(darkListItem2);
			}
			ListBox_AircraftTypes.SelectedIndices.Clear();
			int num2 = ListBox_Loadouts.Items.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				object obj = ListBox_Loadouts.Items[j];
				if (SelectedFlight.int_0 == (int)((DarkListItem)obj).Tag)
				{
					ListBox_Loadouts.SelectItem(j);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PrepareSystem()
	{
		try
		{
			ListBox_AssignedAircraft.Items.Clear();
			if (SelectedFlight.Type == Mission._FlightType.FlightplanTemplate)
			{
				return;
			}
			List<ActiveUnit> list = Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario);
			if (SelectedMission.Category == Mission.MissionCategory.Package)
			{
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (Operators.CompareString(mission.ObjectID, SelectedMission.GetParentTaskPoolID(Client.CurrentSide), TextCompare: true) != 0)
					{
						continue;
					}
					foreach (ActiveUnit item in mission.GetUnitsAssignedToTaskPool(Client.CurrentScenario))
					{
						if (item.IsAircraft && Information.IsNothing(item.AssignedMissionOrPackage()))
						{
							list.Add(item);
						}
					}
				}
			}
			list = list.Select((ActiveUnit theAC) => theAC).OrderBy((ActiveUnit theAirc) => theAirc.Name, new NaturalSortComparer<string[]>()).ToList();
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (Information.IsNothing(activeUnit) || !activeUnit.IsAircraft || (SelectedFlight.ReferenceUnit_DBID > 0 && activeUnit.DBID != SelectedFlight.ReferenceUnit_DBID) || activeUnit.IsOperating())
				{
					continue;
				}
				Aircraft aircraft = (Aircraft)activeUnit;
				if (Information.IsNothing(aircraft.Loadout) || (SelectedFlight.int_0 > 0 && aircraft.Int32_0 != SelectedFlight.int_0))
				{
					continue;
				}
				ActiveUnit currentHostUnit = aircraft.AirOps.CurrentHostUnit;
				if (Information.IsNothing(currentHostUnit) || Operators.CompareString(currentHostUnit.ObjectID, SelectedFlight.TakeOffLocation_HostUnitObjectID, TextCompare: true) != 0)
				{
					continue;
				}
				bool flag = false;
				if (activeUnit.Navigator.HasFlight)
				{
					if (activeUnit.Navigator.GetFlight() != SelectedFlight)
					{
						continue;
					}
					flag = true;
				}
				else
				{
					flag = false;
				}
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = activeUnit.Name;
				if (flag)
				{
					darkListItem.Tag = true;
				}
				else
				{
					darkListItem.Tag = false;
				}
				ListBox_AssignedAircraft.Items.Add(darkListItem);
			}
			ListBox_AircraftTypes.SelectedIndices.Clear();
			int num2 = ListBox_AssignedAircraft.Items.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if ((bool)ListBox_AssignedAircraft.Items[j].Tag)
				{
					ListBox_AssignedAircraft.SelectItem(j);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReflectSystem(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			LoadWindow();
			SelectedAircraftChanged = false;
			SelectedLoadoutChanged = false;
		}
	}

	private void VisitSystem(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Mission._FlightType flightType_ = Mission.Flight.TypeSelection_To_Type(ComboBox_FlightplanType.SelectedIndex);
			Mission.Flight selectedFlight = SelectedFlight;
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			AirTaskingOrder.ChangeFlightType(selectedFlight, ref scenario_, ref side_, ref SelectedMission, flightType_);
			Client.CurrentSide = side_;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
				Client.FlightPlanEditorWindow.InvokePolicy();
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			ReadSystem();
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
		}
	}

	private void RestartSystem(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			TestSystem();
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
				Client.FlightPlanEditorWindow.InvokePolicy();
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			ReadSystem();
		}
	}

	private void TestSystem()
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Mission selectedMission = SelectedMission;
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			selectedMission.ClearAllAircraft_ReplaceWithEmptySlots(ref scenario_, ref side_, ref SelectedFlight);
			Client.CurrentSide = side_;
		}
	}

	private void StopSystem(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			CancelSystem();
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
				Client.FlightPlanEditorWindow.InvokePolicy();
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.ReloadWindow();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			ReadSystem();
		}
	}

	private void CancelSystem()
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (!SelectedFlight.IsEscort && SelectedFlight.FlightPlan.Count() == 0)
			{
				Interaction.MsgBox("在分配飞机之前请先创建飞行计划");
				return;
			}
			Mission selectedMission = SelectedMission;
			Scenario currentScenario = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			bool bool_ = true;
			selectedMission.FillEmptySlots(currentScenario, ref side_, ref bool_, SelectedFlight, bool_1: true);
			Client.CurrentSide = side_;
		}
	}

	private void VerifySystem(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			ref Mission selectedMission = ref SelectedMission;
			Mission.Flight selectedFlight = SelectedFlight;
			ref string takeOffLocation_HostUnitObjectName = ref SelectedFlight.TakeOffLocation_HostUnitObjectName;
			ref string takeOffLocation_HostUnitObjectID = ref SelectedFlight.TakeOffLocation_HostUnitObjectID;
			Module_Unit.Unit unit_ = Client.SelectedUnit;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = Client.CurrentSide.SelectedUnits;
			FlightPlanEditor.ChangeFlightLocation(ref scenario_, ref side_, ref selectedMission, selectedFlight, ref takeOffLocation_HostUnitObjectName, ref takeOffLocation_HostUnitObjectID, ref unit_, ref readOnlyCollection_, bool_0: true, bool_1: false, bool_2: false);
			Client.CurrentSide = side_;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.LoadWindow();
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
			ReadSystem();
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			Client.MustRefreshMainForm = true;
		}
	}

	private void ListSystem(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight))
		{
			return;
		}
		if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (!SelectedAircraftChanged)
			{
				return;
			}
			SelectedAircraftChanged = false;
			if (ListBox_AircraftTypes.SelectedIndices.Count < 0 || ListBox_AircraftTypes.SelectedItems.Count <= 0 || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
			{
				return;
			}
			bool flag = false;
			List<ActiveUnit> list = Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario);
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (!Information.IsNothing(activeUnit) && activeUnit.IsAircraft && activeUnit.DBID == SelectedFlight.ReferenceUnit_DBID && activeUnit.Navigator.HasFlight && activeUnit.Navigator.GetFlight() == SelectedFlight)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				if (Interaction.MsgBox("改变飞机类型将从飞行编队中移除现有飞机。继续？", MsgBoxStyle.YesNo) == MsgBoxResult.No)
				{
					SelectedAircraftChanged = false;
					ReloadWindow();
					return;
				}
				TestSystem();
			}
			int num2 = Conversions.ToInteger(ListBox_AircraftTypes.SelectedItems[0].Tag);
			if (SelectedFlight.ReferenceUnit_DBID != num2)
			{
				SelectedFlight.ReferenceUnit_DBID = num2;
				SelectedFlight.SetReferenceUnit(Client.CurrentScenario, null);
				SelectedFlight.ReferenceUnit_ObjectID = "";
				if (num2 <= 0)
				{
					SelectedFlight.int_0 = 0;
					SelectedFlight.SetLoadoutName(Client.CurrentScenario, "任何挂载");
				}
				else
				{
					SelectedFlight.int_0 = 0;
					SelectedFlight.SetLoadoutName(Client.CurrentScenario, "任何挂载");
				}
				ActiveUnit referenceUnit = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
				if (num2 <= 0)
				{
					SelectedFlight.ReferenceUnit_Name = "任意类型";
				}
				else
				{
					SelectedFlight.ReferenceUnit_Name = referenceUnit.UnitClass;
				}
				if (!Information.IsNothing(SelectedMission.EmptySlotsList))
				{
					for (int j = SelectedMission.EmptySlotsList.Count - 1; j >= 0; j += -1)
					{
						Mission.EmptyAircraftSlot emptyAircraftSlot = SelectedMission.EmptySlotsList[j];
						if (!Information.IsNothing(emptyAircraftSlot.GetMissionFlight(Client.CurrentScenario)) && (Information.IsNothing(SelectedFlight) || Operators.CompareString(SelectedFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, TextCompare: true) == 0))
						{
							emptyAircraftSlot.SetReferenceUnit(Client.CurrentScenario, null, SelectedFlight.GetReferenceUnit(Client.CurrentScenario));
							if (Information.IsNothing(SelectedFlight.GetReferenceUnit(Client.CurrentScenario)))
							{
								emptyAircraftSlot.ReferenceUnit_UnitClass = "任意类型";
								emptyAircraftSlot.ReferenceUnit_DBID = 0;
							}
							else
							{
								emptyAircraftSlot.ReferenceUnit_UnitClass = SelectedFlight.GetReferenceUnit(Client.CurrentScenario).UnitClass;
								emptyAircraftSlot.ReferenceUnit_DBID = SelectedFlight.GetReferenceUnit(Client.CurrentScenario).DBID;
							}
							emptyAircraftSlot.int_0 = SelectedFlight.int_0;
							emptyAircraftSlot.LoadoutName = SelectedFlight.GetLoadoutName(Client.CurrentScenario);
						}
					}
				}
				if (SelectedFlight.ReferenceUnit_DBID == 0 && SelectedFlight.FlightPlan.Count() > 0)
				{
					Interaction.MsgBox("飞行计划可以被任何类型的飞机使用，因此将所有速度设置为固定...");
					SetSpeedsFixed();
				}
				Scenario currentScenario = Client.CurrentScenario;
				Mission selectedMission = SelectedMission;
				ActiveUnit referenceUnit2 = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
				Mission.Flight selectedFlight = SelectedFlight;
				Mission.Flight selectedFlight2 = SelectedFlight;
				Waypoint[] waypoint_ = selectedFlight2.FlightPlan;
				float float_ = 0f;
				float float_2 = 0f;
				MissionPlanner.ConnectTokenizer(currentScenario, selectedMission, referenceUnit2, selectedFlight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
				selectedFlight2.FlightPlan = waypoint_;
				if (Client.FlightPlanEditorWindow.Visible)
				{
					if (SelectedFlight.ReferenceUnit_DBID == 0)
					{
						Client.FlightPlanEditorWindow.ReloadWindow();
					}
					else
					{
						Client.FlightPlanEditorWindow.GetPolicy(bool_0: true);
						if (!Information.IsNothing(Client.FlightPlanEditorWindow.theFlightPlanWaypoints))
						{
							Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
						}
						Client.FlightPlanEditorWindow.InvokePolicy();
					}
				}
				if (Client.AirTaskingOrderWindow.Visible)
				{
					Client.AirTaskingOrderWindow.ReloadWindow();
				}
				if (Client.MissionEditorWindow.Visible)
				{
					Client.MissionEditorWindow.RefreshAssignedUnits();
					Client.MissionEditorWindow.RefreshUnassignedUnits();
				}
				PrepareSystem();
			}
			InsertSystem();
		}
		else
		{
			SelectedAircraftChanged = false;
		}
	}

	private void ResolveSystem(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight))
		{
			return;
		}
		if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (!SelectedLoadoutChanged)
			{
				return;
			}
			SelectedLoadoutChanged = false;
			if (ListBox_Loadouts.SelectedIndices.Count < 0 || ListBox_Loadouts.SelectedItems.Count <= 0 || SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
			{
				return;
			}
			bool flag = false;
			List<ActiveUnit> list = Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario);
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				ActiveUnit activeUnit = list[i];
				if (!Information.IsNothing(activeUnit) && activeUnit.IsAircraft && activeUnit.DBID == SelectedFlight.ReferenceUnit_DBID && activeUnit.Navigator.HasFlight && activeUnit.Navigator.GetFlight() == SelectedFlight)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				if (Interaction.MsgBox("更改挂载类型将从飞行编队中移除现有飞机。继续？", MsgBoxStyle.YesNo) == MsgBoxResult.No)
				{
					SelectedLoadoutChanged = false;
					ReloadWindow();
					return;
				}
				TestSystem();
			}
			object obj = ListBox_Loadouts.SelectedItems[0];
			int num2 = Conversions.ToInteger(((DarkListItem)obj).Tag);
			if (SelectedFlight.int_0 == num2)
			{
				return;
			}
			SelectedFlight.SetReferenceUnit(Client.CurrentScenario, null);
			SelectedFlight.ReferenceUnit_ObjectID = "";
			if (num2 <= 0)
			{
				num2 = 0;
				SelectedFlight.int_0 = 0;
				SelectedFlight.SetLoadoutName(Client.CurrentScenario, "任何挂载");
			}
			else
			{
				SelectedFlight.int_0 = num2;
				SelectedFlight.SetLoadoutName(Client.CurrentScenario, ((DarkListItem)obj).Text);
			}
			SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
			if (!Information.IsNothing(SelectedMission.EmptySlotsList))
			{
				for (int j = SelectedMission.EmptySlotsList.Count - 1; j >= 0; j += -1)
				{
					Mission.EmptyAircraftSlot emptyAircraftSlot = SelectedMission.EmptySlotsList[j];
					if (!Information.IsNothing(emptyAircraftSlot.GetMissionFlight(Client.CurrentScenario)) && Operators.CompareString(SelectedFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, TextCompare: true) == 0)
					{
						emptyAircraftSlot.int_0 = SelectedFlight.int_0;
						emptyAircraftSlot.LoadoutName = SelectedFlight.GetLoadoutName(Client.CurrentScenario);
					}
				}
			}
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.GetPolicy(bool_0: true);
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.ReloadWindow();
			}
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			PrepareSystem();
		}
		else
		{
			SelectedLoadoutChanged = false;
		}
	}

	private void PostSystem(object sender, MouseEventArgs e)
	{
		SelectedAircraftChanged = true;
	}

	private void RunSystem(object sender, MouseEventArgs e)
	{
		SelectedLoadoutChanged = true;
	}

	private void StartSystem(object sender, EventArgs e)
	{
		if (Information.IsNothing(SelectedMission) || Information.IsNothing(SelectedFlight))
		{
			return;
		}
		if (SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			if (!SelectedAssignedAircraftChanged)
			{
				return;
			}
			SelectedAssignedAircraftChanged = false;
			if (ListBox_AssignedAircraft.SelectedIndices.Count < 0)
			{
				if (ListBox_AssignedAircraft.SelectedItems.Count != 0)
				{
					return;
				}
				List<ActiveUnit> list = Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					ActiveUnit activeUnit_ = list[i];
					if (!Information.IsNothing(activeUnit_) && activeUnit_.IsAircraft && activeUnit_.DBID == SelectedFlight.ReferenceUnit_DBID && activeUnit_.Navigator.HasFlight && activeUnit_.Navigator.GetFlight() == SelectedFlight)
					{
						Mission selectedMission = SelectedMission;
						Scenario scenario_ = Client.CurrentScenario;
						selectedMission.ClearAircraft_ReplaceWithEmptySlot(ref scenario_, ref SelectedFlight, ref activeUnit_);
					}
				}
			}
			else
			{
				if (SelectedFlight.GetStatus(Client.CurrentScenario) != 0)
				{
					return;
				}
				List<ActiveUnit> list2 = Module_Mission.AssetTokenizer(SelectedMission, Client.CurrentScenario);
				if (SelectedMission.Category == Mission.MissionCategory.Package)
				{
					foreach (Mission mission in Client.CurrentSide.Missions)
					{
						if (Operators.CompareString(mission.ObjectID, SelectedMission.GetParentTaskPoolID(Client.CurrentSide), TextCompare: true) != 0)
						{
							continue;
						}
						foreach (ActiveUnit item in mission.GetUnitsAssignedToTaskPool(Client.CurrentScenario))
						{
							if (item.IsAircraft && Information.IsNothing(item.AssignedMissionOrPackage()))
							{
								list2.Add(item);
							}
						}
					}
				}
				int count = list2.Count;
				if (SelectedFlight.ReferenceUnit_DBID == 0 || SelectedFlight.int_0 == 0)
				{
					bool flag = false;
					int num4 = count - 1;
					for (int j = 0; j <= num4; j++)
					{
						ActiveUnit activeUnit = list2[j];
						if (Information.IsNothing(activeUnit) || !activeUnit.IsAircraft || (SelectedFlight.ReferenceUnit_DBID > 0 && activeUnit.DBID != SelectedFlight.ReferenceUnit_DBID))
						{
							continue;
						}
						int num5 = ListBox_AssignedAircraft.SelectedItems.Count - 1;
						for (int k = 0; k <= num5; k++)
						{
							object obj = ListBox_AssignedAircraft.SelectedItems[k];
							if (Operators.CompareString(activeUnit.Name, ((DarkListItem)obj).Text, TextCompare: true) != 0)
							{
								if (flag)
								{
									break;
								}
								continue;
							}
							if (SelectedFlight.ReferenceUnit_DBID == 0)
							{
								SelectedFlight.SetReferenceUnit(Client.CurrentScenario, activeUnit);
								SelectedFlight.ReferenceUnit_DBID = activeUnit.DBID;
								SelectedFlight.ReferenceUnit_ObjectID = activeUnit.ObjectID;
								Interaction.MsgBox("该编队的飞机类型已设置为" + activeUnit.UnitClass + ".");
							}
							if (SelectedFlight.int_0 == 0)
							{
								Aircraft aircraft = (Aircraft)activeUnit;
								if (!Information.IsNothing(aircraft.Loadout))
								{
									SelectedFlight.int_0 = aircraft.Loadout.DBID;
									SelectedFlight.SetLoadoutName(Client.CurrentScenario, aircraft.Loadout.Name);
									Interaction.MsgBox("飞行任务将使用挂载" + aircraft.Loadout.Name);
								}
							}
							flag = true;
							break;
						}
					}
				}
				bool flag2 = false;
				int num6 = 0;
				int num7 = SelectedFlight.DesiredAircraftQty;
				int num8 = count - 1;
				for (int l = 0; l <= num8; l++)
				{
					ActiveUnit activeUnit_2 = list2[l];
					if (Information.IsNothing(activeUnit_2) || !activeUnit_2.IsAircraft || activeUnit_2.DBID != SelectedFlight.ReferenceUnit_DBID)
					{
						continue;
					}
					if (activeUnit_2.Navigator.HasFlight)
					{
						if (activeUnit_2.Navigator.GetFlight() != SelectedFlight)
						{
							continue;
						}
						int count2 = ListBox_AssignedAircraft.SelectedItems.Count;
						flag2 = false;
						int num9 = count2 - 1;
						for (int m = 0; m <= num9; m++)
						{
							object obj2 = ListBox_AssignedAircraft.SelectedItems[m];
							if (Operators.CompareString(activeUnit_2.Name, ((DarkListItem)obj2).Text, TextCompare: true) == 0)
							{
								flag2 = true;
								num6++;
								break;
							}
						}
						if (!flag2)
						{
							Mission selectedMission2 = SelectedMission;
							Scenario scenario_2 = Client.CurrentScenario;
							selectedMission2.ClearAircraft_ReplaceWithEmptySlot(ref scenario_2, ref SelectedFlight, ref activeUnit_2);
						}
						continue;
					}
					int count3 = ListBox_AssignedAircraft.SelectedItems.Count;
					flag2 = false;
					int num10 = count3 - 1;
					for (int n = 0; n <= num10; n++)
					{
						object obj3 = ListBox_AssignedAircraft.SelectedItems[n];
						if (Operators.CompareString(activeUnit_2.Name, ((DarkListItem)obj3).Text, TextCompare: true) == 0)
						{
							activeUnit_2.Navigator.SetFlight(bool_1: true, SelectedFlight);
							activeUnit_2.AI.IsEscort = SelectedFlight.IsEscort;
							if (Information.IsNothing(activeUnit_2.AssignedMissionOrPackage()))
							{
								ActiveUnit activeUnit2 = activeUnit_2;
								Mission selectedMission3 = SelectedMission;
								Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
								activeUnit2.Set_AssignedMissionOrPackage(selectedMission3, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
								Interaction.MsgBox("已将此飞机从任务池中取出并分配给选定的任务包。");
							}
							flag2 = true;
							num6++;
							break;
						}
					}
				}
				int num11 = num7 - num6;
				int num2 = 0;
				if (!Information.IsNothing(SelectedMission.EmptySlotsList))
				{
					for (int num3 = SelectedMission.EmptySlotsList.Count - 1; num3 >= 0; num3 += -1)
					{
						Mission.EmptyAircraftSlot emptyAircraftSlot = SelectedMission.EmptySlotsList[num3];
						if (!Information.IsNothing(emptyAircraftSlot.GetMissionFlight(Client.CurrentScenario)) && (Information.IsNothing(SelectedFlight) || Operators.CompareString(SelectedFlight.ObjectID, emptyAircraftSlot.MissionFlight_ObjectID, TextCompare: true) == 0))
						{
							num2++;
							if (num2 > num11)
							{
								SelectedMission.EmptySlotsList.Remove(emptyAircraftSlot);
							}
						}
					}
				}
				SelectedMission.ResetFlightReadyAicraftCount(Client.CurrentScenario, SelectedFlight);
				Scenario currentScenario = Client.CurrentScenario;
				Mission selectedMission4 = SelectedMission;
				ActiveUnit referenceUnit = SelectedFlight.GetReferenceUnit(Client.CurrentScenario);
				Mission.Flight selectedFlight = SelectedFlight;
				Mission.Flight selectedFlight2 = SelectedFlight;
				Waypoint[] waypoint_ = selectedFlight2.FlightPlan;
				float float_ = 0f;
				float float_2 = 0f;
				MissionPlanner.ConnectTokenizer(currentScenario, selectedMission4, referenceUnit, selectedFlight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
				selectedFlight2.FlightPlan = waypoint_;
				if (Client.FlightPlanEditorWindow.Visible)
				{
					Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
					Client.FlightPlanEditorWindow.InvokePolicy();
				}
				if (Client.AirTaskingOrderWindow.Visible)
				{
					Client.AirTaskingOrderWindow.LoadWindow();
				}
				SelectedAssignedAircraftChanged = false;
				ReadSystem();
				if (Client.MissionEditorWindow.Visible)
				{
					Client.MissionEditorWindow.RefreshAssignedUnits();
					Client.MissionEditorWindow.RefreshUnassignedUnits();
				}
				Client.MustRefreshMainForm = true;
			}
		}
		else
		{
			SelectedAssignedAircraftChanged = false;
		}
	}

	private void AssetSystem(object sender, MouseEventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			SelectedAssignedAircraftChanged = true;
		}
	}

	public void SetSpeedsFixed()
	{
		int num = SelectedFlight.FlightPlan.Count() - 1;
		for (int i = 0; i <= num; i++)
		{
			Waypoint waypoint = SelectedFlight.FlightPlan[i];
			waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			if (waypoint.SpeedFixed == Waypoint.FixedFree.Fixed)
			{
				waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
			}
			else
			{
				float? desiredSpeed = waypoint.DesiredSpeed;
				if ((desiredSpeed.HasValue ? new bool?(desiredSpeed.GetValueOrDefault() > 0f) : null).GetValueOrDefault())
				{
					waypoint.DesiredSpeedOverride = waypoint.DesiredSpeed;
				}
				else
				{
					waypoint.DesiredSpeed = waypoint.ActualSpeed;
					waypoint.DesiredSpeedOverride = waypoint.ActualSpeed;
				}
				waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
			Information.IsNothing(waypoint.DesiredSpeedOverride);
		}
	}

	private void PrintSystem(object object_0)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && Versioned.IsNumeric(TxtDesiredSize.Text) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			int num = int.Parse(TxtDesiredSize.Text);
			if (1 == 0)
			{
			}
			Mission._FlightSize flightSize = num switch
			{
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				6 => 6, 
				_ => new Mission._FlightSize(num), 
			};
			if (1 == 0)
			{
			}
			Mission._FlightSize flightSize_ = flightSize;
			Mission.Flight selectedFlight = SelectedFlight;
			Scenario scenario_ = Client.CurrentScenario;
			selectedFlight.ChangeDesiredFlightSize(ref scenario_, ref SelectedMission, Client.CurrentSide, flightSize_);
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.NewPolicy();
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			ReadSystem();
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			RegistryParameterMessage.AwakeCustomer();
			Client.MustRefreshMainForm = true;
		}
	}

	private void DefineSystem(object object_0)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && Versioned.IsNumeric(TxtMinimumSize.Text) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			int num = int.Parse(TxtMinimumSize.Text);
			if (1 == 0)
			{
			}
			Mission._FlightSize flightSize = num switch
			{
				1 => 1, 
				2 => 2, 
				3 => 3, 
				4 => 4, 
				6 => 6, 
				_ => new Mission._FlightSize(num), 
			};
			if (1 == 0)
			{
			}
			Mission._FlightSize flightSize_ = flightSize;
			Mission.Flight selectedFlight = SelectedFlight;
			Scenario scenario_ = Client.CurrentScenario;
			selectedFlight.ChangeMinimumFlightSize(ref scenario_, ref SelectedMission, Client.CurrentSide, flightSize_);
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
			ReadSystem();
		}
	}

	private void PublishSystem(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedMission) && !Information.IsNothing(SelectedFlight) && SelectedFlight.GetStatus(Client.CurrentScenario) == Mission._FlightStatus.None)
		{
			Scenario scenario_ = Client.CurrentScenario;
			Side side_ = Client.CurrentSide;
			ref Mission selectedMission = ref SelectedMission;
			Mission.Flight selectedFlight = SelectedFlight;
			ref string landingLocation_HostUnitObjectName = ref SelectedFlight.LandingLocation_HostUnitObjectName;
			ref string landingLocation_HostUnitObjectID = ref SelectedFlight.LandingLocation_HostUnitObjectID;
			Module_Unit.Unit unit_ = Client.SelectedUnit;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = Client.CurrentSide.SelectedUnits;
			FlightPlanEditor.ChangeFlightLocation(ref scenario_, ref side_, ref selectedMission, selectedFlight, ref landingLocation_HostUnitObjectName, ref landingLocation_HostUnitObjectID, ref unit_, ref readOnlyCollection_, bool_0: false, bool_1: true, bool_2: false);
			Client.CurrentSide = side_;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.LoadWindow();
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
			ReadSystem();
			if (Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAssignedUnits();
				Client.MissionEditorWindow.RefreshUnassignedUnits();
			}
			Client.MustRefreshMainForm = true;
		}
	}
}
