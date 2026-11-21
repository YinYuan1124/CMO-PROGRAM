using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class LandingPlanner : Form
{
	public enum Priority
	{
		Critical,
		High,
		Medium,
		Low,
		Excluded,
		Unavailable
	}

	[DoNotPruneType]
	[DoNotObfuscateType]
	[DoNotPrune]
	private class MissionZoneComboWrapper
	{
		private LandingZoneWrapper _FilterMap;

		public LandingZoneWrapper ID
		{
			get
			{
				return _FilterMap;
			}
			set
			{
				_FilterMap = value;
			}
		}

		public string Label
		{
			get
			{
				if (Information.IsNothing(_FilterMap))
				{
					return "Unallocated";
				}
				if (_FilterMap.LandingZoneType == LandingType.Airborne)
				{
					return _FilterMap.LandingZone.Description + " (LZ)";
				}
				if (_FilterMap.LandingZoneType == LandingType.Amphibious)
				{
					return _FilterMap.LandingZone.Description + " (CLZ)";
				}
				return _FilterMap.LandingZone.Description;
			}
			set
			{
			}
		}

		public MissionZoneComboWrapper(LandingZoneWrapper landingZoneWrapper_0)
		{
			_FilterMap = landingZoneWrapper_0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscateType]
	[DoNotPruneType]
	private class UnitTransportComboboxWrapper
	{
		private ActiveUnit m_TestsMap;

		public ActiveUnit ID
		{
			get
			{
				return m_TestsMap;
			}
			set
			{
				m_TestsMap = value;
			}
		}

		public string Label
		{
			get
			{
				if (Information.IsNothing(m_TestsMap))
				{
					return "None";
				}
				return m_TestsMap.Name;
			}
			set
			{
			}
		}

		public UnitTransportComboboxWrapper(ActiveUnit activeUnit_0)
		{
			m_TestsMap = activeUnit_0;
		}
	}

	[DoNotPrune]
	[DoNotPruneType]
	[DoNotObfuscateType]
	private class MothershipItem
	{
		public ActiveUnit interpreterMap;

		public string Label
		{
			get
			{
				return interpreterMap.Name;
			}
			set
			{
			}
		}

		public ActiveUnit ID
		{
			get
			{
				return interpreterMap;
			}
			set
			{
				interpreterMap = value;
			}
		}

		public MothershipItem(ActiveUnit activeUnit_0)
		{
			interpreterMap = activeUnit_0;
		}
	}

	private enum EditionMode
	{

	}

	private IContainer mapperContainer;

	[AccessedThroughProperty("DarkLabel7")]
	[CompilerGenerated]
	private DarkLabel managerContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboMothership")]
	private DarkUIComboBox _GetterContainer;

	[AccessedThroughProperty("DarkGroupBox1")]
	[CompilerGenerated]
	private DarkGroupBox producerContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox3")]
	private DarkGroupBox m_ProcContainer;

	[AccessedThroughProperty("LV_Transports")]
	[CompilerGenerated]
	private DarkListView _StructComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox2")]
	private DarkGroupBox m_MerchantComposer;

	[AccessedThroughProperty("ButtonClearDGVmain")]
	[CompilerGenerated]
	private DarkUIButton m_CallbackComposer;

	[AccessedThroughProperty("ButtonExportToCSV")]
	[CompilerGenerated]
	private DarkUIButton m_DecoratorComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonLoad")]
	private DarkUIButton m_ProcessComposer;

	[AccessedThroughProperty("DGVMain")]
	[CompilerGenerated]
	private DataGridView threadComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirmPlan")]
	private DarkUIButton ruleComposer;

	[AccessedThroughProperty("ComboBoxLandingType")]
	[CompilerGenerated]
	private DarkUIComboBox m_CollectionComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_MissionPrep")]
	private DarkListView m_InstanceComposer;

	[AccessedThroughProperty("FlowLayoutPanel3")]
	[CompilerGenerated]
	private FlowLayoutPanel m_ObjectComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelSelectedTransport")]
	private DarkLabel expressionComposer;

	[AccessedThroughProperty("LabelUnitListForWave")]
	[CompilerGenerated]
	private DarkLabel dispatcherComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonAllowTransport")]
	private DarkUIButton listenerComposer;

	[AccessedThroughProperty("ButtonGeneratePlan")]
	[CompilerGenerated]
	private DarkUIButton m_ConfigComposer;

	[AccessedThroughProperty("LV_TransportWaveManifest")]
	[CompilerGenerated]
	private ListView m_RegistryComposer;

	[AccessedThroughProperty("Area")]
	[CompilerGenerated]
	private ColumnHeader valComposer;

	[AccessedThroughProperty("Weight")]
	[CompilerGenerated]
	private ColumnHeader m_WrapperComposer;

	[AccessedThroughProperty("Crew")]
	[CompilerGenerated]
	private ColumnHeader observerComposer;

	[AccessedThroughProperty("ColumnHeader1")]
	[CompilerGenerated]
	private ColumnHeader m_ClientComposer;

	[AccessedThroughProperty("ColumnHeader4")]
	[CompilerGenerated]
	private ColumnHeader facadeComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("ColumnHeader6")]
	private ColumnHeader m_ReaderComposer;

	[AccessedThroughProperty("ButtonToggleEditionMode")]
	[CompilerGenerated]
	private DarkUIButton _PropertyComposer;

	[AccessedThroughProperty("ButtonProhibitTransport")]
	[CompilerGenerated]
	private DarkUIButton _BridgeComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("GeneralTooltip")]
	private ToolTip m_InvocationComposer;

	[CompilerGenerated]
	[AccessedThroughProperty("button_exportSpredsheet")]
	private DarkUIButton _ClassComposer;

	[AccessedThroughProperty("DarkGroupBox4")]
	[CompilerGenerated]
	private DarkGroupBox m_RequestComposer;

	[AccessedThroughProperty("ButtonOpenExportFolder")]
	[CompilerGenerated]
	private DarkUIButton _ValueComposer;

	public LandingPlan LandingPlan;

	public LandingPlan_ImportWrapper LandingPlanImport;

	public Dictionary<LandingZoneWrapper, LandingZoneWrapper> AssignedZones;

	public Dictionary<ActiveUnit, Transport> AllowedTransport;

	private BindingSource _TokenizerComposer;

	public ActiveUnit CurrentMothership;

	private Transport m_StubComposer;

	private TransportWave writerComposer;

	private Dictionary<string, TransportAvailability> m_SpecificationComposer;

	public Dictionary<ActiveUnit, Transport> TransportList;

	private Dictionary<string, List<Transport>> m_WatcherComposer;

	private Dictionary<string, LandingType> reponseComposer;

	private List<ChalkUnit> descriptorComposer;

	public Dictionary<Chalk, List<UnitLineWrapper>> ChalkContainer;

	private Dictionary<int, UnitLineWrapper> m_PoolComposer;

	private EditionMode taskComposer;

	private bool m_FilterComposer;

	public Dictionary<Mission, LandingType> GeneratedMissions;

	private ComboBox _TestsComposer;

	public bool ForceClose;

	internal virtual DarkLabel DarkLabel7
	{
		[CompilerGenerated]
		get
		{
			return managerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			managerContainer = value;
		}
	}

	internal virtual DarkUIComboBox ComboMothership
	{
		[CompilerGenerated]
		get
		{
			return _GetterContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterInitializer;
			DarkUIComboBox getterContainer = _GetterContainer;
			if (getterContainer != null)
			{
				getterContainer.SelectedIndexChanged -= value2;
			}
			_GetterContainer = value;
			getterContainer = _GetterContainer;
			if (getterContainer != null)
			{
				getterContainer.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual DarkGroupBox DarkGroupBox1
	{
		[CompilerGenerated]
		get
		{
			return producerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			producerContainer = value;
		}
	}

	internal virtual DarkGroupBox DarkGroupBox3
	{
		[CompilerGenerated]
		get
		{
			return m_ProcContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProcContainer = value;
		}
	}

	internal virtual DarkListView LV_Transports
	{
		[CompilerGenerated]
		get
		{
			return _StructComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectRole;
			DarkListView structComposer = _StructComposer;
			if (structComposer != null)
			{
				structComposer.SelectedIndicesChanged -= value2;
			}
			_StructComposer = value;
			structComposer = _StructComposer;
			if (structComposer != null)
			{
				structComposer.SelectedIndicesChanged += value2;
			}
		}
	}

	internal virtual DarkGroupBox DarkGroupBox2
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MerchantComposer = value;
		}
	}

	internal virtual DarkUIButton DarkUIButton_0
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallRole;
			DarkUIButton callbackComposer = m_CallbackComposer;
			if (callbackComposer != null)
			{
				callbackComposer.Click -= value2;
			}
			m_CallbackComposer = value;
			callbackComposer = m_CallbackComposer;
			if (callbackComposer != null)
			{
				callbackComposer.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonExportToCSV
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteRole;
			DarkUIButton decoratorComposer = m_DecoratorComposer;
			if (decoratorComposer != null)
			{
				decoratorComposer.Click -= value2;
			}
			m_DecoratorComposer = value;
			decoratorComposer = m_DecoratorComposer;
			if (decoratorComposer != null)
			{
				decoratorComposer.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonLoad
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeRole;
			DarkUIButton processComposer = m_ProcessComposer;
			if (processComposer != null)
			{
				processComposer.Click -= value2;
			}
			m_ProcessComposer = value;
			processComposer = m_ProcessComposer;
			if (processComposer != null)
			{
				processComposer.Click += value2;
			}
		}
	}

	internal virtual DataGridView DGVMain
	{
		[CompilerGenerated]
		get
		{
			return threadComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotInitializer;
			DataGridViewEditingControlShowingEventHandler value3 = OrderInitializer;
			EventHandler value4 = PatchRole;
			DataGridViewCellEventHandler value5 = SelectRole;
			DataGridView dataGridView = threadComposer;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
				dataGridView.EditingControlShowing -= value3;
				dataGridView.CurrentCellDirtyStateChanged -= value4;
				dataGridView.CellValueChanged -= value5;
			}
			threadComposer = value;
			dataGridView = threadComposer;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
				dataGridView.EditingControlShowing += value3;
				dataGridView.CurrentCellDirtyStateChanged += value4;
				dataGridView.CellValueChanged += value5;
			}
		}
	}

	internal virtual DarkUIButton ButtonConfirmPlan
	{
		[CompilerGenerated]
		get
		{
			return ruleComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateRole;
			DarkUIButton darkUIButton = ruleComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			ruleComposer = value;
			darkUIButton = ruleComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBoxLandingType
	{
		[CompilerGenerated]
		get
		{
			return m_CollectionComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewRole;
			DarkUIComboBox collectionComposer = m_CollectionComposer;
			if (collectionComposer != null)
			{
				collectionComposer.SelectionChangeCommitted -= value2;
			}
			m_CollectionComposer = value;
			collectionComposer = m_CollectionComposer;
			if (collectionComposer != null)
			{
				collectionComposer.SelectionChangeCommitted += value2;
			}
		}
	}

	internal virtual DarkListView LV_MissionPrep
	{
		[CompilerGenerated]
		get
		{
			return m_InstanceComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneRole;
			EventHandler value3 = PushRole;
			DarkListView instanceComposer = m_InstanceComposer;
			if (instanceComposer != null)
			{
				instanceComposer.SelectedIndicesChanged -= value2;
				instanceComposer.Click -= value3;
			}
			m_InstanceComposer = value;
			instanceComposer = m_InstanceComposer;
			if (instanceComposer != null)
			{
				instanceComposer.SelectedIndicesChanged += value2;
				instanceComposer.Click += value3;
			}
		}
	}

	internal virtual FlowLayoutPanel FlowLayoutPanel3
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObjectComposer = value;
		}
	}

	[field: AccessedThroughProperty("Button5")]
	internal virtual Button Button5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel LabelSelectedTransport
	{
		[CompilerGenerated]
		get
		{
			return expressionComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			expressionComposer = value;
		}
	}

	internal virtual DarkLabel LabelUnitListForWave
	{
		[CompilerGenerated]
		get
		{
			return dispatcherComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dispatcherComposer = value;
		}
	}

	internal virtual DarkUIButton ButtonAllowTransport
	{
		[CompilerGenerated]
		get
		{
			return listenerComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountRole;
			DarkUIButton darkUIButton = listenerComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			listenerComposer = value;
			darkUIButton = listenerComposer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonGeneratePlan
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutRole;
			DarkUIButton configComposer = m_ConfigComposer;
			if (configComposer != null)
			{
				configComposer.Click -= value2;
			}
			m_ConfigComposer = value;
			configComposer = m_ConfigComposer;
			if (configComposer != null)
			{
				configComposer.Click += value2;
			}
		}
	}

	internal virtual ListView LV_TransportWaveManifest
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveRole;
			ListView registryComposer = m_RegistryComposer;
			if (registryComposer != null)
			{
				registryComposer.SelectedIndexChanged -= value2;
			}
			m_RegistryComposer = value;
			registryComposer = m_RegistryComposer;
			if (registryComposer != null)
			{
				registryComposer.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Wave")]
	internal virtual ColumnHeader Wave
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ColumnHeader Area
	{
		[CompilerGenerated]
		get
		{
			return valComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valComposer = value;
		}
	}

	internal virtual ColumnHeader Weight
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WrapperComposer = value;
		}
	}

	internal virtual ColumnHeader Crew
	{
		[CompilerGenerated]
		get
		{
			return observerComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			observerComposer = value;
		}
	}

	[field: AccessedThroughProperty("LVUnitListInWave")]
	internal virtual ListView LVUnitListInWave
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ColumnHeader ColumnHeader1
	{
		[CompilerGenerated]
		get
		{
			return m_ClientComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClientComposer = value;
		}
	}

	[field: AccessedThroughProperty("ColumnHeader2")]
	internal virtual ColumnHeader ColumnHeader2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader3")]
	internal virtual ColumnHeader ColumnHeader3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ColumnHeader ColumnHeader4
	{
		[CompilerGenerated]
		get
		{
			return facadeComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			facadeComposer = value;
		}
	}

	[field: AccessedThroughProperty("ColumnHeader5")]
	internal virtual ColumnHeader ColumnHeader5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ColumnHeader ColumnHeader6
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReaderComposer = value;
		}
	}

	internal virtual DarkUIButton ButtonToggleEditionMode
	{
		[CompilerGenerated]
		get
		{
			return _PropertyComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginRole;
			DarkUIButton propertyComposer = _PropertyComposer;
			if (propertyComposer != null)
			{
				propertyComposer.Click -= value2;
			}
			_PropertyComposer = value;
			propertyComposer = _PropertyComposer;
			if (propertyComposer != null)
			{
				propertyComposer.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("CB_SerialIntegrity")]
	internal virtual DarkCheckBox CB_SerialIntegrity
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ButtonProhibitTransport
	{
		[CompilerGenerated]
		get
		{
			return _BridgeComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeRole;
			DarkUIButton bridgeComposer = _BridgeComposer;
			if (bridgeComposer != null)
			{
				bridgeComposer.Click -= value2;
			}
			_BridgeComposer = value;
			bridgeComposer = _BridgeComposer;
			if (bridgeComposer != null)
			{
				bridgeComposer.Click += value2;
			}
		}
	}

	internal virtual ToolTip GeneralTooltip
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationComposer = value;
		}
	}

	internal virtual DarkUIButton button_exportSpredsheet
	{
		[CompilerGenerated]
		get
		{
			return _ClassComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupRole;
			DarkUIButton classComposer = _ClassComposer;
			if (classComposer != null)
			{
				classComposer.Click -= value2;
			}
			_ClassComposer = value;
			classComposer = _ClassComposer;
			if (classComposer != null)
			{
				classComposer.Click += value2;
			}
		}
	}

	internal virtual DarkGroupBox DarkGroupBox4
	{
		[CompilerGenerated]
		get
		{
			return m_RequestComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RequestComposer = value;
		}
	}

	internal virtual DarkUIButton ButtonOpenExportFolder
	{
		[CompilerGenerated]
		get
		{
			return _ValueComposer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeRole;
			DarkUIButton valueComposer = _ValueComposer;
			if (valueComposer != null)
			{
				valueComposer.Click -= value2;
			}
			_ValueComposer = value;
			valueComposer = _ValueComposer;
			if (valueComposer != null)
			{
				valueComposer.Click += value2;
			}
		}
	}

	private Transport CurrentTransport
	{
		get
		{
			return m_StubComposer;
		}
		set
		{
			writerComposer = null;
			m_StubComposer = value;
		}
	}

	public LandingPlanner()
	{
		base.Closing += delegate(object sender, CancelEventArgs e)
		{
			OperationPlannerForm_Quit(RuntimeHelpers.GetObjectValue(sender), (FormClosingEventArgs)e);
		};
		base.Load += DefineInitializer;
		LandingPlan = null;
		LandingPlanImport = null;
		AssignedZones = new Dictionary<LandingZoneWrapper, LandingZoneWrapper>();
		AllowedTransport = new Dictionary<ActiveUnit, Transport>();
		_TokenizerComposer = new BindingSource();
		m_SpecificationComposer = new Dictionary<string, TransportAvailability>();
		TransportList = new Dictionary<ActiveUnit, Transport>();
		m_WatcherComposer = new Dictionary<string, List<Transport>>();
		reponseComposer = new Dictionary<string, LandingType>();
		descriptorComposer = new List<ChalkUnit>();
		ChalkContainer = new Dictionary<Chalk, List<UnitLineWrapper>>();
		m_PoolComposer = new Dictionary<int, UnitLineWrapper>();
		taskComposer = (EditionMode)1;
		GeneratedMissions = new Dictionary<Mission, LandingType>();
		PrintInitializer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && mapperContainer != null)
			{
				mapperContainer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PrintInitializer()
	{
		mapperContainer = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DarkGroupBox2 = new DarkGroupBox();
		DarkGroupBox4 = new DarkGroupBox();
		ButtonOpenExportFolder = new DarkUIButton();
		ButtonExportToCSV = new DarkUIButton();
		button_exportSpredsheet = new DarkUIButton();
		ButtonLoad = new DarkUIButton();
		CB_SerialIntegrity = new DarkCheckBox();
		ButtonToggleEditionMode = new DarkUIButton();
		ButtonGeneratePlan = new DarkUIButton();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		Button5 = new Button();
		DarkUIButton_0 = new DarkUIButton();
		DGVMain = new DataGridView();
		ButtonConfirmPlan = new DarkUIButton();
		DarkGroupBox3 = new DarkGroupBox();
		ButtonProhibitTransport = new DarkUIButton();
		LVUnitListInWave = new ListView();
		ColumnHeader1 = new ColumnHeader();
		ColumnHeader6 = new ColumnHeader();
		ColumnHeader2 = new ColumnHeader();
		ColumnHeader3 = new ColumnHeader();
		ColumnHeader4 = new ColumnHeader();
		ColumnHeader5 = new ColumnHeader();
		LV_TransportWaveManifest = new ListView();
		Wave = new ColumnHeader();
		Area = new ColumnHeader();
		Weight = new ColumnHeader();
		Crew = new ColumnHeader();
		ButtonAllowTransport = new DarkUIButton();
		LabelUnitListForWave = new DarkLabel();
		LabelSelectedTransport = new DarkLabel();
		LV_Transports = new DarkListView();
		DarkGroupBox1 = new DarkGroupBox();
		DarkLabel1 = new DarkLabel();
		LV_MissionPrep = new DarkListView();
		DarkLabel7 = new DarkLabel();
		ComboMothership = new DarkUIComboBox();
		ComboBoxLandingType = new DarkUIComboBox();
		GeneralTooltip = new ToolTip(mapperContainer);
		DarkGroupBox2.SuspendLayout();
		DarkGroupBox4.SuspendLayout();
		FlowLayoutPanel3.SuspendLayout();
		((ISupportInitialize)DGVMain).BeginInit();
		DarkGroupBox3.SuspendLayout();
		DarkGroupBox1.SuspendLayout();
		SuspendLayout();
		DarkGroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox2.Controls.Add(DarkGroupBox4);
		DarkGroupBox2.Controls.Add(CB_SerialIntegrity);
		DarkGroupBox2.Controls.Add(ButtonToggleEditionMode);
		DarkGroupBox2.Controls.Add(ButtonGeneratePlan);
		DarkGroupBox2.Controls.Add(FlowLayoutPanel3);
		DarkGroupBox2.Controls.Add(DarkUIButton_0);
		DarkGroupBox2.Controls.Add(DGVMain);
		DarkGroupBox2.Controls.Add(ButtonConfirmPlan);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(12, 200);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(1210, 441);
		DarkGroupBox2.TabIndex = 0;
		DarkGroupBox2.TabStop = false;
		DarkGroupBox2.Text = "Units Assignment";
		DarkGroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DarkGroupBox4.Controls.Add(ButtonOpenExportFolder);
		DarkGroupBox4.Controls.Add(ButtonExportToCSV);
		DarkGroupBox4.Controls.Add(button_exportSpredsheet);
		DarkGroupBox4.Controls.Add(ButtonLoad);
		DarkGroupBox4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox4.Location = new Point(6, 401);
		DarkGroupBox4.Name = "DarkGroupBox4";
		DarkGroupBox4.Size = new Size(519, 34);
		DarkGroupBox4.TabIndex = 17;
		DarkGroupBox4.TabStop = false;
		ButtonOpenExportFolder.BackColor = Color.Transparent;
		ButtonOpenExportFolder.DialogResult = DialogResult.None;
		ButtonOpenExportFolder.ForeColor = SystemColors.Control;
		ButtonOpenExportFolder.Location = new Point(404, 9);
		ButtonOpenExportFolder.Name = "ButtonOpenExportFolder";
		ButtonOpenExportFolder.RoundRadius = 0;
		ButtonOpenExportFolder.Size = new Size(109, 22);
		ButtonOpenExportFolder.TabIndex = 17;
		ButtonOpenExportFolder.Text = "Open folder";
		ButtonExportToCSV.BackColor = Color.Transparent;
		ButtonExportToCSV.DialogResult = DialogResult.None;
		ButtonExportToCSV.ForeColor = SystemColors.Control;
		ButtonExportToCSV.Location = new Point(6, 9);
		ButtonExportToCSV.Name = "ButtonExportToCSV";
		ButtonExportToCSV.RoundRadius = 0;
		ButtonExportToCSV.Size = new Size(92, 22);
		ButtonExportToCSV.TabIndex = 7;
		ButtonExportToCSV.Text = "Save to file";
		button_exportSpredsheet.BackColor = Color.Transparent;
		button_exportSpredsheet.DialogResult = DialogResult.None;
		button_exportSpredsheet.ForeColor = SystemColors.Control;
		button_exportSpredsheet.Location = new Point(267, 9);
		button_exportSpredsheet.Name = "button_exportSpredsheet";
		button_exportSpredsheet.RoundRadius = 0;
		button_exportSpredsheet.Size = new Size(133, 22);
		button_exportSpredsheet.TabIndex = 16;
		button_exportSpredsheet.Text = "Export To Spreadsheet";
		ButtonLoad.BackColor = Color.Transparent;
		ButtonLoad.DialogResult = DialogResult.None;
		ButtonLoad.ForeColor = SystemColors.Control;
		ButtonLoad.Location = new Point(104, 9);
		ButtonLoad.Name = "ButtonLoad";
		ButtonLoad.RoundRadius = 0;
		ButtonLoad.Size = new Size(106, 22);
		ButtonLoad.TabIndex = 6;
		ButtonLoad.Text = "Load from file";
		CB_SerialIntegrity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		CB_SerialIntegrity.AutoSize = true;
		CB_SerialIntegrity.Checked = true;
		CB_SerialIntegrity.CheckState = CheckState.Checked;
		CB_SerialIntegrity.Location = new Point(907, 21);
		CB_SerialIntegrity.Margin = new Padding(2, 3, 2, 3);
		CB_SerialIntegrity.Name = "CB_SerialIntegrity";
		CB_SerialIntegrity.Size = new Size(117, 17);
		CB_SerialIntegrity.TabIndex = 15;
		CB_SerialIntegrity.Text = "Keep serial integrity";
		GeneralTooltip.SetToolTip(CB_SerialIntegrity, "Disabling this will allow serials to be separated accross multiple transports");
		ButtonToggleEditionMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		ButtonToggleEditionMode.BackColor = Color.Transparent;
		ButtonToggleEditionMode.DialogResult = DialogResult.None;
		ButtonToggleEditionMode.ForeColor = SystemColors.Control;
		ButtonToggleEditionMode.Location = new Point(1026, 14);
		ButtonToggleEditionMode.Name = "ButtonToggleEditionMode";
		ButtonToggleEditionMode.RoundRadius = 0;
		ButtonToggleEditionMode.Size = new Size(178, 31);
		ButtonToggleEditionMode.TabIndex = 14;
		ButtonToggleEditionMode.Text = "Edition Mode : Individual Units";
		ButtonGeneratePlan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonGeneratePlan.BackColor = Color.Transparent;
		ButtonGeneratePlan.DialogResult = DialogResult.None;
		ButtonGeneratePlan.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonGeneratePlan.ForeColor = SystemColors.Control;
		ButtonGeneratePlan.Location = new Point(698, 407);
		ButtonGeneratePlan.Name = "ButtonGeneratePlan";
		ButtonGeneratePlan.RoundRadius = 0;
		ButtonGeneratePlan.Size = new Size(157, 25);
		ButtonGeneratePlan.TabIndex = 13;
		ButtonGeneratePlan.Text = "Generate Landing Plan";
		FlowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		FlowLayoutPanel3.AutoScroll = true;
		FlowLayoutPanel3.Controls.Add(Button5);
		FlowLayoutPanel3.Location = new Point(9, 19);
		FlowLayoutPanel3.Name = "FlowLayoutPanel3";
		FlowLayoutPanel3.Size = new Size(703, 31);
		FlowLayoutPanel3.TabIndex = 12;
		FlowLayoutPanel3.WrapContents = false;
		Button5.BackColor = Color.FromArgb(90, 63, 64);
		Button5.FlatStyle = FlatStyle.Flat;
		Button5.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button5.Location = new Point(3, 3);
		Button5.Name = "Button5";
		Button5.Size = new Size(65, 23);
		Button5.TabIndex = 12;
		Button5.Text = "Unallocated";
		Button5.UseVisualStyleBackColor = false;
		Button5.Visible = false;
		DarkUIButton_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		DarkUIButton_0.BackColor = Color.Transparent;
		DarkUIButton_0.DialogResult = DialogResult.None;
		DarkUIButton_0.ForeColor = SystemColors.Control;
		DarkUIButton_0.Location = new Point(590, 407);
		DarkUIButton_0.Name = "ButtonClearDGVmain";
		DarkUIButton_0.RoundRadius = 0;
		DarkUIButton_0.Size = new Size(102, 25);
		DarkUIButton_0.TabIndex = 8;
		DarkUIButton_0.Text = "清空";
		DGVMain.AllowUserToAddRows = false;
		DGVMain.AllowUserToDeleteRows = false;
		DGVMain.AllowUserToResizeColumns = false;
		DGVMain.AllowUserToResizeRows = false;
		DGVMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGVMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGVMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = Color.FromArgb(220, 220, 220);
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGVMain.DefaultCellStyle = dataGridViewCellStyle2;
		DGVMain.EditMode = DataGridViewEditMode.EditOnEnter;
		DGVMain.Location = new Point(9, 51);
		DGVMain.Name = "DGVMain";
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		DGVMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		DGVMain.RowHeadersVisible = false;
		DGVMain.RowHeadersWidth = 62;
		DGVMain.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DGVMain.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
		DGVMain.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
		DGVMain.Size = new Size(1195, 350);
		DGVMain.TabIndex = 0;
		ButtonConfirmPlan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonConfirmPlan.BackColor = Color.Transparent;
		ButtonConfirmPlan.DialogResult = DialogResult.None;
		ButtonConfirmPlan.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonConfirmPlan.ForeColor = SystemColors.Control;
		ButtonConfirmPlan.Location = new Point(1053, 407);
		ButtonConfirmPlan.Name = "ButtonConfirmPlan";
		ButtonConfirmPlan.RoundRadius = 0;
		ButtonConfirmPlan.Size = new Size(151, 25);
		ButtonConfirmPlan.TabIndex = 5;
		ButtonConfirmPlan.Text = "确认着陆计划";
		DarkGroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox3.Controls.Add(ButtonProhibitTransport);
		DarkGroupBox3.Controls.Add(LVUnitListInWave);
		DarkGroupBox3.Controls.Add(LV_TransportWaveManifest);
		DarkGroupBox3.Controls.Add(ButtonAllowTransport);
		DarkGroupBox3.Controls.Add(LabelUnitListForWave);
		DarkGroupBox3.Controls.Add(LabelSelectedTransport);
		DarkGroupBox3.Controls.Add(LV_Transports);
		DarkGroupBox3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox3.Location = new Point(302, 3);
		DarkGroupBox3.Name = "DarkGroupBox3";
		DarkGroupBox3.Size = new Size(920, 191);
		DarkGroupBox3.TabIndex = 10;
		DarkGroupBox3.TabStop = false;
		DarkGroupBox3.Text = "Transports";
		ButtonProhibitTransport.BackColor = Color.Transparent;
		ButtonProhibitTransport.DialogResult = DialogResult.None;
		ButtonProhibitTransport.ForeColor = SystemColors.Control;
		ButtonProhibitTransport.Location = new Point(120, 21);
		ButtonProhibitTransport.Margin = new Padding(2, 1, 2, 1);
		ButtonProhibitTransport.Name = "ButtonProhibitTransport";
		ButtonProhibitTransport.RoundRadius = 0;
		ButtonProhibitTransport.Size = new Size(115, 19);
		ButtonProhibitTransport.TabIndex = 19;
		ButtonProhibitTransport.Text = "取消";
		LVUnitListInWave.Activation = ItemActivation.OneClick;
		LVUnitListInWave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		LVUnitListInWave.Columns.AddRange(new ColumnHeader[6] { ColumnHeader1, ColumnHeader6, ColumnHeader2, ColumnHeader3, ColumnHeader4, ColumnHeader5 });
		LVUnitListInWave.FullRowSelect = true;
		LVUnitListInWave.GridLines = true;
		LVUnitListInWave.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		LVUnitListInWave.HideSelection = false;
		LVUnitListInWave.ImeMode = ImeMode.NoControl;
		LVUnitListInWave.Location = new Point(538, 45);
		LVUnitListInWave.Margin = new Padding(2, 1, 2, 1);
		LVUnitListInWave.MultiSelect = false;
		LVUnitListInWave.Name = "LVUnitListInWave";
		LVUnitListInWave.Size = new Size(377, 143);
		LVUnitListInWave.TabIndex = 18;
		LVUnitListInWave.UseCompatibleStateImageBehavior = false;
		ColumnHeader1.Text = "Serial";
		ColumnHeader6.Text = "单元";
		ColumnHeader6.TextAlign = HorizontalAlignment.Center;
		ColumnHeader2.Text = "区域";
		ColumnHeader3.Text = "重量";
		ColumnHeader4.Text = "PAX";
		ColumnHeader5.Text = "Size Type";
		LV_TransportWaveManifest.Activation = ItemActivation.OneClick;
		LV_TransportWaveManifest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LV_TransportWaveManifest.Columns.AddRange(new ColumnHeader[4] { Wave, Area, Weight, Crew });
		LV_TransportWaveManifest.FullRowSelect = true;
		LV_TransportWaveManifest.GridLines = true;
		LV_TransportWaveManifest.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		LV_TransportWaveManifest.HideSelection = false;
		LV_TransportWaveManifest.ImeMode = ImeMode.NoControl;
		LV_TransportWaveManifest.Location = new Point(240, 45);
		LV_TransportWaveManifest.Margin = new Padding(2, 1, 2, 1);
		LV_TransportWaveManifest.MultiSelect = false;
		LV_TransportWaveManifest.Name = "LV_TransportWaveManifest";
		LV_TransportWaveManifest.Size = new Size(294, 143);
		LV_TransportWaveManifest.TabIndex = 17;
		LV_TransportWaveManifest.UseCompatibleStateImageBehavior = false;
		Wave.Text = "Wave";
		Area.Text = "区域";
		Weight.Text = "重量";
		Crew.Text = "PAX";
		ButtonAllowTransport.BackColor = Color.Transparent;
		ButtonAllowTransport.DialogResult = DialogResult.None;
		ButtonAllowTransport.ForeColor = SystemColors.Control;
		ButtonAllowTransport.Location = new Point(5, 21);
		ButtonAllowTransport.Margin = new Padding(2, 1, 2, 1);
		ButtonAllowTransport.Name = "ButtonAllowTransport";
		ButtonAllowTransport.RoundRadius = 0;
		ButtonAllowTransport.Size = new Size(111, 19);
		ButtonAllowTransport.TabIndex = 14;
		ButtonAllowTransport.Text = "Assign";
		LabelUnitListForWave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		LabelUnitListForWave.AutoSize = true;
		LabelUnitListForWave.ForeColor = Color.FromArgb(220, 220, 220);
		LabelUnitListForWave.Location = new Point(535, 30);
		LabelUnitListForWave.Name = "LabelUnitListForWave";
		LabelUnitListForWave.Size = new Size(113, 13);
		LabelUnitListForWave.TabIndex = 16;
		LabelUnitListForWave.Text = "List of units for wave 1";
		LabelSelectedTransport.AutoSize = true;
		LabelSelectedTransport.ForeColor = Color.FromArgb(220, 220, 220);
		LabelSelectedTransport.Location = new Point(237, 30);
		LabelSelectedTransport.Name = "LabelSelectedTransport";
		LabelSelectedTransport.Size = new Size(43, 13);
		LabelSelectedTransport.TabIndex = 15;
		LabelSelectedTransport.Text = "LCAC 1";
		LV_Transports.BackColor = Color.FromArgb(50, 53, 55);
		LV_Transports.Location = new Point(5, 45);
		LV_Transports.MultiSelect = true;
		LV_Transports.Name = "LV_Transports";
		LV_Transports.RelatedInfos = null;
		LV_Transports.Size = new Size(230, 140);
		LV_Transports.TabIndex = 0;
		LV_Transports.Text = "LV_Transports";
		DarkGroupBox1.Controls.Add(DarkLabel1);
		DarkGroupBox1.Controls.Add(LV_MissionPrep);
		DarkGroupBox1.Controls.Add(DarkLabel7);
		DarkGroupBox1.Controls.Add(ComboMothership);
		DarkGroupBox1.Controls.Add(ComboBoxLandingType);
		DarkGroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox1.Location = new Point(12, 3);
		DarkGroupBox1.Name = "DarkGroupBox1";
		DarkGroupBox1.Size = new Size(284, 191);
		DarkGroupBox1.TabIndex = 6;
		DarkGroupBox1.TabStop = false;
		DarkGroupBox1.Text = "Mission Preparation";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(9, 168);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(61, 13);
		DarkLabel1.TabIndex = 13;
		DarkLabel1.Text = "Zone type :";
		LV_MissionPrep.BackColor = Color.FromArgb(50, 53, 55);
		LV_MissionPrep.Location = new Point(6, 45);
		LV_MissionPrep.Name = "LV_MissionPrep";
		LV_MissionPrep.RelatedInfos = null;
		LV_MissionPrep.Size = new Size(273, 116);
		LV_MissionPrep.TabIndex = 12;
		LV_MissionPrep.Text = "LV_MissionPrep";
		DarkLabel7.AutoSize = true;
		DarkLabel7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel7.Location = new Point(9, 21);
		DarkLabel7.Name = "DarkLabel7";
		DarkLabel7.Size = new Size(59, 13);
		DarkLabel7.TabIndex = 3;
		DarkLabel7.Text = "Mothership";
		ComboMothership.BackColor = Color.Transparent;
		ComboMothership.DrawMode = DrawMode.OwnerDrawFixed;
		ComboMothership.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboMothership.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboMothership.FormattingEnabled = true;
		ComboMothership.Location = new Point(132, 17);
		ComboMothership.Name = "ComboMothership";
		ComboMothership.Size = new Size(147, 21);
		ComboMothership.TabIndex = 2;
		ComboBoxLandingType.BackColor = Color.Transparent;
		ComboBoxLandingType.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBoxLandingType.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBoxLandingType.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBoxLandingType.FormattingEnabled = true;
		ComboBoxLandingType.Items.AddRange(new object[3] { "未分配", "Amphibious (CLZ)", "Airborne (LZ)" });
		ComboBoxLandingType.Location = new Point(94, 164);
		ComboBoxLandingType.Name = "ComboBoxLandingType";
		ComboBoxLandingType.Size = new Size(184, 21);
		ComboBoxLandingType.TabIndex = 10;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(1234, 649);
		base.Controls.Add(DarkGroupBox2);
		base.Controls.Add(DarkGroupBox3);
		base.Controls.Add(DarkGroupBox1);
		MinimumSize = new Size(1250, 688);
		base.Name = "LandingPlanner";
		base.ShowIcon = false;
		Text = "LandingPlanner";
		DarkGroupBox2.ResumeLayout(performLayout: false);
		DarkGroupBox2.PerformLayout();
		DarkGroupBox4.ResumeLayout(performLayout: false);
		FlowLayoutPanel3.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGVMain).EndInit();
		DarkGroupBox3.ResumeLayout(performLayout: false);
		DarkGroupBox3.PerformLayout();
		DarkGroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	public void OperationPlannerForm_Quit(object sender, FormClosingEventArgs e)
	{
		if (!ForceClose && DarkMessageBox.ShowWarning("You will lose any progress done in the landing planner, are you sure to close this window?", "Closing landing planner", DarkDialogButton.YesNo) == DialogResult.No)
		{
			e.Cancel = true;
		}
	}

	private void DefineInitializer(object sender, EventArgs e)
	{
		foreach (Zone standardZone in Client.CurrentSide.StandardZones)
		{
			LandingZoneWrapper landingZoneWrapper = new LandingZoneWrapper(standardZone, LandingType.Unassigned);
			AssignedZones.Add(landingZoneWrapper, landingZoneWrapper);
		}
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			chalk.Priority = 0;
		}
		if (LandingPlanImport != null)
		{
			foreach (Chalk chalk2 in Client.CurrentSide.Chalks)
			{
				if (LandingPlanImport.SerialToPriority.ContainsKey(chalk2))
				{
					chalk2.Priority = LandingPlanImport.SerialToPriority[chalk2];
				}
			}
		}
		PublishInitializer();
		ResetInitializer();
		QueryInitializer();
		GetRole();
		AddRole();
		AwakeInitializer();
		if (CurrentMothership != null)
		{
			Text = "Landing planner for  " + CurrentMothership.Name;
		}
		if (LandingPlanImport != null)
		{
			foreach (ChalkUnit item in descriptorComposer)
			{
				if (LandingPlanImport.SerialToZoneAssociation.ContainsKey(item.AssociatedChalk))
				{
					foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in AssignedZones)
					{
						if (Operators.CompareString(assignedZone.Key.LandingZone.ObjectID, LandingPlanImport.SerialToZoneAssociation[item.AssociatedChalk].ObjectID, TextCompare: true) != 0)
						{
							continue;
						}
						item.LandingZone = assignedZone.Value;
						if (!ChalkContainer.ContainsKey(item.AssociatedChalk))
						{
							continue;
						}
						foreach (UnitLineWrapper item2 in ChalkContainer[item.AssociatedChalk])
						{
							DGVMain.Rows[item2.Index].Cells["Landing Zone"].Value = item.LandingZone;
						}
					}
				}
				else if (item.AssociatedChalk.Preboat != null && LandingPlanImport.Preboated.ContainsKey(item.AssociatedChalk.Preboat.ActualTransport))
				{
					foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone2 in AssignedZones)
					{
						if (Operators.CompareString(assignedZone2.Key.LandingZone.ObjectID, LandingPlanImport.Preboated[item.AssociatedChalk.Preboat.ActualTransport].ObjectID, TextCompare: true) != 0)
						{
							continue;
						}
						item.LandingZone = assignedZone2.Value;
						if (!ChalkContainer.ContainsKey(item.AssociatedChalk))
						{
							continue;
						}
						foreach (UnitLineWrapper item3 in ChalkContainer[item.AssociatedChalk])
						{
							DGVMain.Rows[item3.Index].Cells["Landing Zone"].Value = item.LandingZone;
						}
					}
				}
				if (ChalkContainer.Count <= 0 || !LandingPlanImport.SerialAllowedTransportClasses.ContainsKey(item.AssociatedChalk.ID.ToString()))
				{
					continue;
				}
				foreach (KeyValuePair<string, TransportAvailability> item4 in m_SpecificationComposer)
				{
					bool flag = LandingPlanImport.SerialAllowedTransportClasses[item.AssociatedChalk.ID.ToString()].Contains(item4.Key);
					foreach (UnitLineWrapper item5 in ChalkContainer[item.AssociatedChalk])
					{
						if (flag)
						{
							item5.ChalkUnit.TransportAvailable[item4.Key] = TransportAvailability.UseTransport;
						}
						else
						{
							item5.ChalkUnit.TransportAvailable[item4.Key] = TransportAvailability.DontUseTransport;
						}
					}
				}
			}
			SortInitializer();
		}
		LandingPlanImport = null;
	}

	private void PublishInitializer()
	{
		ComboMothership.ValueMember = "ID";
		ComboMothership.DisplayMember = "Label";
		int selectedIndex = 0;
		foreach (ActiveUnit unit in Client.CurrentSide.Units)
		{
			if (unit.IsShip && unit.HasCargo && Information.IsNothing(unit.DockingOps.CurrentHostUnit))
			{
				ComboMothership.Items.Add(new MothershipItem(unit));
				if (LandingPlanImport != null && LandingPlanImport.Mothership != null && Operators.CompareString(LandingPlanImport.Mothership.ObjectID, unit.ObjectID, TextCompare: true) == 0)
				{
					selectedIndex = ComboMothership.Items.Count - 1;
				}
			}
		}
		if (ComboMothership.Items.Count > 0)
		{
			ComboMothership.SelectedIndex = selectedIndex;
		}
	}

	private void AwakeInitializer()
	{
		ButtonConfirmPlan.Enabled = m_FilterComposer;
	}

	private void QueryInitializer()
	{
		LV_Transports.Items.Clear();
		if (CurrentMothership == null)
		{
			return;
		}
		if (LandingPlanImport != null)
		{
			foreach (ActiveUnit allowedTransport in LandingPlanImport.AllowedTransports)
			{
				if (!AllowedTransport.ContainsKey(allowedTransport) && TransportList.ContainsKey(allowedTransport))
				{
					AllowedTransport.Add(allowedTransport, TransportList[allowedTransport]);
				}
			}
			if (LandingPlanImport.AllowedTransportClasses != null)
			{
				foreach (string allowedTransportClass in LandingPlanImport.AllowedTransportClasses)
				{
					foreach (KeyValuePair<ActiveUnit, Transport> transport in TransportList)
					{
						if (Operators.CompareString(transport.Key.UnitClass, allowedTransportClass, TextCompare: true) == 0 && !AllowedTransport.ContainsKey(transport.Key))
						{
							AllowedTransport.Add(transport.Key, transport.Value);
						}
					}
				}
			}
		}
		foreach (KeyValuePair<ActiveUnit, Transport> item in TransportList.OrderBy((KeyValuePair<ActiveUnit, Transport> x) => x.Value.ActualTransport.Name).ToList())
		{
			if (((ICargoHost)item.Key).GetCargo_Type() != 0)
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Tag = item.Value;
				darkListItem.Text = item.Key.Name;
				if (item.Value.ActualTransport.HasCargo)
				{
					darkListItem.Text += " [Pre-loaded]";
				}
				if (AllowedTransport.ContainsKey(item.Key))
				{
					darkListItem.TextColor = Color.FromArgb(255, 0, 255, 0);
				}
				else
				{
					darkListItem.TextColor = Color.White;
				}
				LV_Transports.Items.Add(darkListItem);
			}
		}
	}

	private void ResetInitializer()
	{
		LV_MissionPrep.Items.Clear();
		if (LandingPlanImport != null)
		{
			foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> item in AssignedZones.ToList())
			{
				if (LandingPlanImport.LandingZones.ContainsKey(item.Key.LandingZone))
				{
					item.Key.LandingZoneType = LandingPlanImport.LandingZones[item.Key.LandingZone].LandingZoneType;
				}
			}
		}
		ComboBoxLandingType.Text = "No Selection";
		foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> item2 in AssignedZones.OrderBy((KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> x) => x.Key.LandingZone.Description).ToList())
		{
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Tag = item2.Key;
			darkListItem.Text = item2.Key.LandingZone.Description;
			if (item2.Key.LandingZoneType == LandingType.Unassigned)
			{
				darkListItem.TextColor = Color.White;
				darkListItem.Text += " (Unassigned)";
			}
			else
			{
				darkListItem.TextColor = Color.FromArgb(255, 0, 255, 0);
				if (item2.Key.LandingZoneType == LandingType.Airborne)
				{
					darkListItem.Text += " (LZ)";
				}
				else
				{
					darkListItem.Text += " (CLZ)";
				}
			}
			LV_MissionPrep.Items.Add(darkListItem);
		}
	}

	private bool MapInitializer(Chalk chalk_0)
	{
		if (ChalkContainer[chalk_0].Count == 0)
		{
			return false;
		}
		foreach (UnitLineWrapper item in ChalkContainer[chalk_0])
		{
			if (!item.ChalkUnit.IsAmphibious)
			{
				return false;
			}
		}
		return true;
	}

	private void SortInitializer()
	{
		DGVMain.CellValueChanged -= SelectRole;
		int num = m_SpecificationComposer.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			m_SpecificationComposer[m_SpecificationComposer.ElementAt(i).Key] = TransportAvailability.CantUseTransport;
			foreach (KeyValuePair<ActiveUnit, Transport> item in AllowedTransport)
			{
				if (Operators.CompareString(item.Key.UnitClass, m_SpecificationComposer.ElementAt(i).Key, TextCompare: true) == 0)
				{
					m_SpecificationComposer[m_SpecificationComposer.ElementAt(i).Key] = TransportAvailability.UseTransport;
					break;
				}
			}
		}
		int num2 = DGVMain.Rows.Count - 1;
		for (int j = 0; j <= num2; j++)
		{
			UnitLineWrapper unitLineWrapper = (UnitLineWrapper)_TokenizerComposer[j];
			int num3 = unitLineWrapper.ChalkUnit.TransportAvailable.Count - 1;
			for (int k = 0; k <= num3; k++)
			{
				if (Operators.CompareString(unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key, "Self", TextCompare: true) == 0)
				{
					if (unitLineWrapper.ChalkUnit.IsAmphibious && MapInitializer(unitLineWrapper.ChalkUnit.AssociatedChalk) && unitLineWrapper.ChalkUnit.LandingZone != null && unitLineWrapper.ChalkUnit.LandingZone.LandingZoneType == reponseComposer[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key])
					{
						if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.DontUseTransport && unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.UseTransport)
						{
							unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.DontUseTransport;
						}
					}
					else
					{
						unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.CantUseTransport;
					}
				}
				else if (m_SpecificationComposer[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] == TransportAvailability.CantUseTransport)
				{
					unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.CantUseTransport;
				}
				else if (unitLineWrapper.ChalkUnit.LandingZone != null && unitLineWrapper.ChalkUnit.LandingZone.LandingZoneType == reponseComposer[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key])
				{
					if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.UseTransport && unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] != TransportAvailability.DontUseTransport)
					{
						unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.UseTransport;
					}
				}
				else
				{
					unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = TransportAvailability.CantUseTransport;
				}
				if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] == TransportAvailability.CantUseTransport)
				{
					if (DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].GetType() == typeof(DataGridViewCheckBoxCell))
					{
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = true;
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = new DataGridViewTextBoxCell();
					}
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Style.BackColor = Color.LightGray;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].ReadOnly = true;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = "";
				}
				else if (unitLineWrapper.ChalkUnit.TransportAvailable[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] == TransportAvailability.DontUseTransport)
				{
					if (DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].GetType() == typeof(DataGridViewTextBoxCell))
					{
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = "";
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = new DataGridViewCheckBoxCell();
					}
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = false;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Style.BackColor = Color.White;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].ReadOnly = false;
				}
				else
				{
					if (DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].GetType() == typeof(DataGridViewTextBoxCell))
					{
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = "";
						DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key] = new DataGridViewCheckBoxCell();
					}
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Value = true;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].Style.BackColor = Color.White;
					DGVMain.Rows[j].Cells[unitLineWrapper.ChalkUnit.TransportAvailable.ElementAt(k).Key].ReadOnly = false;
				}
			}
			DGVMain.Rows[j].Cells["CurrentTransport"].ToolTipText = unitLineWrapper.ChalkUnit.TransportErrorMessagTooltip;
		}
		DGVMain.CellValueChanged += SelectRole;
		DGVMain.Refresh();
	}

	private void CalcInitializer()
	{
		DGVMain.DataSource = null;
		DGVMain.Rows.Clear();
		DGVMain.Columns.Clear();
		_TokenizerComposer.Clear();
		if (CurrentMothership == null)
		{
			return;
		}
		DGVMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		DGVMain.AutoGenerateColumns = true;
		_TokenizerComposer.DataSource = typeof(UnitLineWrapper);
		new List<DataGridViewCheckBoxColumn>();
		m_SpecificationComposer = new Dictionary<string, TransportAvailability>();
		m_WatcherComposer = new Dictionary<string, List<Transport>>();
		reponseComposer = new Dictionary<string, LandingType>();
		TransportList = new Dictionary<ActiveUnit, Transport>();
		ChalkContainer = new Dictionary<Chalk, List<UnitLineWrapper>>();
		m_PoolComposer = new Dictionary<int, UnitLineWrapper>();
		descriptorComposer = new List<ChalkUnit>();
		foreach (ActiveUnit embarkedBoat in CurrentMothership.DockingOps.EmbarkedBoats)
		{
			Transport transport = new Transport(embarkedBoat);
			if (((ICargoHost)embarkedBoat).GetCargo_Type() != 0)
			{
				if (m_WatcherComposer.ContainsKey(embarkedBoat.UnitClass))
				{
					m_WatcherComposer[embarkedBoat.UnitClass].Add(transport);
				}
				else
				{
					m_WatcherComposer.Add(embarkedBoat.UnitClass, new List<Transport>());
					m_WatcherComposer[embarkedBoat.UnitClass].Add(transport);
				}
				if (!TransportList.ContainsKey(embarkedBoat))
				{
					TransportList.Add(transport.ActualTransport, transport);
				}
				if (!m_SpecificationComposer.ContainsKey(embarkedBoat.UnitClass))
				{
					DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
					dataGridViewCheckBoxColumn.DataPropertyName = "Transport";
					dataGridViewCheckBoxColumn.Name = embarkedBoat.UnitClass;
					dataGridViewCheckBoxColumn.HeaderText = "Use " + embarkedBoat.UnitClass;
					DGVMain.Columns.Add(dataGridViewCheckBoxColumn);
					m_SpecificationComposer.Add(embarkedBoat.UnitClass, TransportAvailability.Unknown);
					reponseComposer.Add(embarkedBoat.UnitClass, LandingType.Amphibious);
				}
			}
		}
		foreach (Aircraft item in CurrentMothership.AirOps.EmbarkedAircraft_ReadOnly)
		{
			Transport transport2 = new Transport(item);
			if (((ICargoHost)item).GetCargo_Type() != 0)
			{
				if (m_WatcherComposer.ContainsKey(item.UnitClass))
				{
					m_WatcherComposer[item.UnitClass].Add(transport2);
				}
				else
				{
					m_WatcherComposer.Add(item.UnitClass, new List<Transport>());
					m_WatcherComposer[item.UnitClass].Add(transport2);
				}
				if (!TransportList.ContainsKey(item))
				{
					TransportList.Add(transport2.ActualTransport, transport2);
				}
				if (!m_SpecificationComposer.ContainsKey(item.UnitClass))
				{
					DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
					dataGridViewCheckBoxColumn2.DataPropertyName = "Transport";
					dataGridViewCheckBoxColumn2.Name = item.UnitClass;
					dataGridViewCheckBoxColumn2.HeaderText = "Use " + item.UnitClass;
					DGVMain.Columns.Add(dataGridViewCheckBoxColumn2);
					m_SpecificationComposer.Add(item.UnitClass, TransportAvailability.Unknown);
					reponseComposer.Add(item.UnitClass, LandingType.Airborne);
				}
			}
		}
		List<Chalk> list = new List<Chalk>();
		foreach (Chalk chalk2 in Client.CurrentSide.Chalks)
		{
			if (chalk2.AssociatedMothership != null && Operators.CompareString(chalk2.AssociatedMothership.ObjectID, CurrentMothership.ObjectID, TextCompare: true) == 0)
			{
				list.Add(chalk2);
			}
		}
		RateInitializer(list);
		foreach (Transport item2 in TransportList.Values.ToList())
		{
			if (item2.ActualTransport.OnboardCargo.Length != 0)
			{
				Chalk chalk = new Chalk(-1, CurrentMothership);
				chalk.Preboat = item2;
				Cargo[] onboardCargo = item2.ActualTransport.OnboardCargo;
				Cargo[] array = onboardCargo;
				foreach (Cargo cargo_ in array)
				{
					chalk.AddCargo(cargo_);
				}
				list.Add(chalk);
			}
		}
		int num = 0;
		foreach (Chalk item3 in list)
		{
			if (Operators.CompareString(item3.AssociatedMothership.ObjectID, CurrentMothership.ObjectID, TextCompare: true) != 0)
			{
				continue;
			}
			bool bool_ = false;
			ChalkContainer.Add(item3, new List<UnitLineWrapper>());
			foreach (KeyValuePair<Cargo, int> item4 in item3.Cargo)
			{
				UnitLineWrapper unitLineWrapper = null;
				unitLineWrapper = (Information.IsNothing(item3.Preboat) ? new UnitLineWrapper(item3, item4.Key, 0, 0, null, bool_, m_SpecificationComposer, null, num) : new UnitLineWrapper(item3, item4.Key, 0, 0, item3.Preboat.ActualTransport, bool_, m_SpecificationComposer, null, num));
				m_PoolComposer.Add(num, unitLineWrapper);
				ChalkContainer[item3].Add(unitLineWrapper);
				descriptorComposer.Add(unitLineWrapper.ChalkUnit);
				_TokenizerComposer.Add(unitLineWrapper);
				bool_ = true;
				num++;
			}
		}
		new List<DataGridViewCheckBoxColumn>();
		DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
		dataGridViewComboBoxColumn.DataPropertyName = "Landing Zone";
		dataGridViewComboBoxColumn.Name = "Landing Zone";
		dataGridViewComboBoxColumn.ValueMember = "ID";
		dataGridViewComboBoxColumn.DisplayMember = "Label";
		dataGridViewComboBoxColumn.Items.Add(new MissionZoneComboWrapper(null));
		foreach (KeyValuePair<LandingZoneWrapper, LandingZoneWrapper> assignedZone in AssignedZones)
		{
			dataGridViewComboBoxColumn.Items.Add(new MissionZoneComboWrapper(assignedZone.Key));
		}
		DGVMain.DataSource = _TokenizerComposer;
		DGVMain.AutoGenerateColumns = false;
		DGVMain.Columns.Add(dataGridViewComboBoxColumn);
		DataGridView dGVMain = DGVMain;
		dGVMain.Columns["Priority"].DisplayIndex = 0;
		dGVMain.Columns["Priority"].ReadOnly = false;
		dGVMain.Columns["Priority"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dGVMain.Columns["Priority"].Width = 60;
		dGVMain.Columns["Serial"].HeaderText = "Serial (m2 | Tons | PAX)";
		dGVMain.Columns["Serial"].DisplayIndex = 1;
		dGVMain.Columns["Serial"].ReadOnly = true;
		dGVMain.Columns["Serial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dGVMain.Columns["Serial"].Width = 155;
		dGVMain.Columns["Unit"].DisplayIndex = 2;
		dGVMain.Columns["Unit"].ReadOnly = true;
		dGVMain.Columns["Landing Zone"].DisplayIndex = 3;
		dGVMain.Columns["Wave"].ReadOnly = true;
		dGVMain.Columns["Wave"].DisplayIndex = 4;
		dGVMain.Columns["Wave"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dGVMain.Columns["Wave"].Width = 45;
		dGVMain.Columns["CurrentTransport"].ReadOnly = true;
		dGVMain.Columns["CurrentTransport"].DisplayIndex = 5;
		dGVMain.Columns["CurrentTransport"].HeaderText = "Current Transport (m2 | Tons | PAX)";
		if (Conversions.ToBoolean(Operators.NotObject(CollectInitializer("Priority"))))
		{
			DGVMain.Columns["Priority"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(CollectInitializer("Serial"))))
		{
			DGVMain.Columns["Serial"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(CollectInitializer("Unit"))))
		{
			DGVMain.Columns["Unit"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(CollectInitializer("Wave"))))
		{
			DGVMain.Columns["Wave"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(CollectInitializer("Landing Zone"))))
		{
			DGVMain.Columns["Landing Zone"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		if (Conversions.ToBoolean(Operators.NotObject(CollectInitializer("CurrentTransport"))))
		{
			DGVMain.Columns["CurrentTransport"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		}
		IEnumerator enumerator7 = null;
		try
		{
			enumerator7 = DGVMain.Columns.GetEnumerator();
			while (enumerator7.MoveNext())
			{
				((DataGridViewColumn)enumerator7.Current).SortMode = DataGridViewColumnSortMode.Automatic;
			}
		}
		finally
		{
			if (enumerator7 is IDisposable)
			{
				(enumerator7 as IDisposable).Dispose();
			}
		}
		SortInitializer();
	}

	private void RateInitializer(List<Chalk> list_0)
	{
		foreach (Chalk item in list_0)
		{
			foreach (KeyValuePair<Cargo, int> item2 in item.Cargo)
			{
				if (item2.Key.CurrentType == Cargo.CargoObjectType.Vehicle && ((Vehicle)item2.Key.CargoObjectActiveUnit).IsOutOfFuel)
				{
					DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
					dataGridViewCheckBoxColumn.DataPropertyName = "Transport";
					dataGridViewCheckBoxColumn.Name = "Self";
					dataGridViewCheckBoxColumn.HeaderText = "Self";
					DGVMain.Columns.Add(dataGridViewCheckBoxColumn);
					m_SpecificationComposer.Add("Self", TransportAvailability.Unknown);
					reponseComposer.Add("Self", LandingType.Amphibious);
					return;
				}
			}
		}
	}

	private void FlushInitializer()
	{
		LV_TransportWaveManifest.GridLines = true;
		LV_TransportWaveManifest.View = View.Details;
		LV_TransportWaveManifest.Items.Clear();
		DeleteRole();
		if (CurrentTransport == null)
		{
			LabelSelectedTransport.Text = "无";
			writerComposer = null;
		}
		else
		{
			LabelSelectedTransport.Text = CurrentTransport.ActualTransport.Name;
			foreach (TransportWave wave in CurrentTransport.Waves)
			{
				ListViewItem listViewItem = new ListViewItem(new string[5]
				{
					wave.Wave.ToString(),
					Math.Round(wave.DisableWatcher(), 1) + "/" + Math.Round(CurrentTransport.AreaCapacity, 1),
					Math.Round(wave.UpdateWatcher(), 1) + "/" + Math.Round(CurrentTransport.MassCapacity, 1),
					Math.Round(wave.InsertWatcher(), 1) + "/" + Math.Round(CurrentTransport.CrewCapacity, 1),
					null
				});
				listViewItem.Tag = wave;
				LV_TransportWaveManifest.Items.Add(listViewItem);
			}
			if (CurrentTransport.Waves.Count > 0)
			{
				writerComposer = CurrentTransport.Waves[CurrentTransport.Waves.Count - 1];
			}
		}
		DeleteRole();
	}

	private void ForgotInitializer(object sender, EventArgs e)
	{
		if (DGVMain.CurrentCell != null)
		{
			DGVMain.CurrentCell.Selected = Conversions.ToBoolean(CollectInitializer(DGVMain.Columns[DGVMain.CurrentCell.ColumnIndex].Name));
		}
	}

	private object CollectInitializer(string string_0)
	{
		if (Operators.CompareString(string_0, "Priority", TextCompare: true) == 0)
		{
			return true;
		}
		if (Operators.CompareString(string_0, "Landing Zone", TextCompare: true) == 0)
		{
			return true;
		}
		if (Operators.CompareString(string_0, "Serial", TextCompare: true) == 0)
		{
			return false;
		}
		if (Operators.CompareString(string_0, "Unit", TextCompare: true) == 0)
		{
			return false;
		}
		if (Operators.CompareString(string_0, "Wave", TextCompare: true) == 0)
		{
			return false;
		}
		if (Operators.CompareString(string_0, "CurrentTransport", TextCompare: true) == 0)
		{
			return false;
		}
		return true;
	}

	private void OrderInitializer(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		ComboBox comboBox = DGVMain.EditingControl as ComboBox;
		if (_TestsComposer != null)
		{
			_TestsComposer.SelectionChangeCommitted -= ManageInitializer;
		}
		if (comboBox != null)
		{
			comboBox.SelectionChangeCommitted += ManageInitializer;
			_TestsComposer = comboBox;
		}
	}

	private void RegisterInitializer(object sender, EventArgs e)
	{
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(ComboMothership.SelectedItem)))
		{
			ActiveUnit currentMothership = CurrentMothership;
			CurrentMothership = ((MothershipItem)ComboMothership.SelectedItem).ID;
			if (currentMothership == null)
			{
				CalcInitializer();
			}
			else if (Operators.CompareString(currentMothership.ObjectID, CurrentMothership.ObjectID, TextCompare: true) != 0 && DarkMessageBox.ShowWarning("You will lose any progress done in the landing planner as a landing plan is tied to a mothership, do you really want to switch mothership ?", "Switching mothership", DarkDialogButton.YesNo) == DialogResult.Yes)
			{
				CalcInitializer();
			}
			QueryInitializer();
			SortInitializer();
		}
	}

	private void ManageInitializer(object sender, EventArgs e)
	{
		MissionZoneComboWrapper missionZoneComboWrapper = (MissionZoneComboWrapper)(sender as DataGridViewComboBoxEditingControl).SelectedItem;
		ChalkUnit chalkUnit = null;
		if (missionZoneComboWrapper.ID == null)
		{
			chalkUnit = ((UnitLineWrapper)_TokenizerComposer[DGVMain.CurrentCell.RowIndex]).ChalkUnit;
			if (taskComposer == (EditionMode)1)
			{
				if (ChalkContainer.ContainsKey(chalkUnit.AssociatedChalk))
				{
					foreach (UnitLineWrapper item in ChalkContainer[chalkUnit.AssociatedChalk])
					{
						DGVMain.Rows[item.Index].Cells["Landing Zone"].Value = null;
						item.ChalkUnit.LandingZone = null;
					}
				}
			}
			else
			{
				chalkUnit.LandingZone = null;
			}
		}
		else
		{
			LandingZoneWrapper iD = missionZoneComboWrapper.ID;
			chalkUnit = ((UnitLineWrapper)_TokenizerComposer[DGVMain.CurrentCell.RowIndex]).ChalkUnit;
			if (taskComposer == (EditionMode)1)
			{
				if (ChalkContainer.ContainsKey(chalkUnit.AssociatedChalk))
				{
					foreach (UnitLineWrapper item2 in ChalkContainer[chalkUnit.AssociatedChalk])
					{
						DGVMain.Rows[item2.Index].Cells["Landing Zone"].Value = iD;
						item2.ChalkUnit.LandingZone = iD;
					}
				}
			}
			else
			{
				chalkUnit.LandingZone = iD;
			}
		}
		SortInitializer();
	}

	private void RevertInitializer(object sender, EventArgs e)
	{
	}

	private void CountRole(object sender, EventArgs e)
	{
		if (LV_Transports.SelectedItems.Count == 0)
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_Transports.SelectedItems)
		{
			if (selectedItem != null)
			{
				Transport transport = (Transport)selectedItem.Tag;
				if (transport == null)
				{
					return;
				}
				if (!AllowedTransport.ContainsKey(transport.ActualTransport))
				{
					AllowedTransport.Add(transport.ActualTransport, transport);
				}
			}
		}
		AddRole();
		QueryInitializer();
		SortInitializer();
	}

	private void CustomizeRole(object sender, EventArgs e)
	{
		if (LV_Transports.SelectedItems.Count == 0)
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_Transports.SelectedItems)
		{
			if (selectedItem != null)
			{
				Transport transport = (Transport)selectedItem.Tag;
				if (transport == null)
				{
					return;
				}
				if (AllowedTransport.ContainsKey(transport.ActualTransport))
				{
					AllowedTransport.Remove(transport.ActualTransport);
				}
			}
		}
		AddRole();
		QueryInitializer();
		SortInitializer();
	}

	private void CloneRole(object sender, EventArgs e)
	{
		if (LV_MissionPrep.SelectedItems.Count != 0 && LV_MissionPrep.SelectedItems.ElementAt(0) != null)
		{
			_ = (LandingZoneWrapper)LV_MissionPrep.SelectedItems.ElementAt(0).Tag;
		}
	}

	private void ConnectRole(object sender, EventArgs e)
	{
		if (LV_Transports.SelectedItems.Count != 0 && LV_Transports.SelectedItems.ElementAt(0) != null)
		{
			CurrentTransport = (Transport)LV_Transports.SelectedItems.ElementAt(0).Tag;
			AddRole();
			FlushInitializer();
			_ = CurrentTransport;
		}
	}

	private void MoveRole(object sender, EventArgs e)
	{
		if (LV_TransportWaveManifest.SelectedItems.Count != 0 && LV_TransportWaveManifest.SelectedItems[0] != null)
		{
			writerComposer = (TransportWave)LV_TransportWaveManifest.SelectedItems[0].Tag;
			DeleteRole();
		}
	}

	private void DeleteRole()
	{
		LVUnitListInWave.Items.Clear();
		LVUnitListInWave.GridLines = true;
		LVUnitListInWave.View = View.Details;
		LabelUnitListForWave.Text = "";
		if (writerComposer == null || CurrentTransport == null)
		{
			return;
		}
		LabelUnitListForWave.Text = "Transport Manifest For Wave #" + writerComposer.Wave;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in writerComposer.UnitsInWave)
		{
			string[] array = new string[7];
			if (item.Key.AssociatedChalk.ID == -1)
			{
				array[0] = "Preboated";
			}
			else
			{
				array[0] = item.Key.AssociatedChalk.ID.ToString();
			}
			array[1] = item.Key.Unit.CargoObjectName;
			array[2] = item.Key.Unit.RequiredArea.ToString();
			array[3] = item.Key.Unit.RequiredMass.ToString();
			array[4] = item.Key.Unit.RequiredCrewSpace.ToString();
			array[5] = item.Key.Unit.RequiredCargoType.ToString();
			ListViewItem value = new ListViewItem(array);
			LVUnitListInWave.Items.Add(value);
		}
	}

	private void AddRole()
	{
		if (LV_Transports.SelectedItems.Count <= 0)
		{
			ButtonAllowTransport.Visible = false;
			ButtonProhibitTransport.Visible = false;
		}
		else
		{
			ButtonAllowTransport.Visible = true;
			ButtonProhibitTransport.Visible = true;
		}
		ButtonAllowTransport.Refresh();
	}

	private Mission DestroyRole(Chalk chalk_0, int int_0 = 0)
	{
		if (ChalkContainer[chalk_0].Count == 0)
		{
			return null;
		}
		Zone landingZone = ChalkContainer[chalk_0].ElementAt(0).ChalkUnit.LandingZone.LandingZone;
		if (landingZone == null)
		{
			return null;
		}
		List<ReferencePoint> list_ = new List<ReferencePoint>();
		Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(landingZone.Area);
		ReferencePoint referencePoint = new ReferencePoint(geopoint_Struct.Longitude, geopoint_Struct.Latitude);
		list_.Add(referencePoint);
		referencePoint.IsHighlighted = true;
		Client.CurrentSide.RefPoints.Add(referencePoint);
		Client.MustRefreshMainForm = true;
		Side side_ = Client.CurrentSide;
		Scenario scenario_ = Client.CurrentScenario;
		SupportMission supportMission = new SupportMission(ref side_, ref scenario_, "", Mission.MissionCategory.Mission, ref list_, bool_0: false);
		Client.CurrentSide = side_;
		SupportMission supportMission2 = supportMission;
		supportMission2.MarkAsSatisfiedUponReachingDestination = true;
		supportMission2.RTBUponCompletion = false;
		supportMission2.PriorityWeight = int_0;
		supportMission2.CreationMode = MissionCreationType.LandingPlanner;
		supportMission2.OperationName = "Amphibious Landing - Serials";
		supportMission2.NavigationLoopType = SupportMission.SupportMissionNavigationLoopType.SingleLoop;
		supportMission2.StationThrottle_Facility = ActiveUnit.Throttle.Flank;
		supportMission2.TransitThrottle_Facility = ActiveUnit.Throttle.Flank;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (UnitLineWrapper item in ChalkContainer[chalk_0])
		{
			if (!dictionary.ContainsKey(item.ChalkUnit.AssociatedChalk.ID))
			{
				SupportMission supportMission3;
				(supportMission3 = supportMission2).OperationName = supportMission3.OperationName + " #" + item.ChalkUnit.AssociatedChalk.ID;
				dictionary.Add(item.ChalkUnit.AssociatedChalk.ID, item.ChalkUnit.AssociatedChalk.ID);
			}
		}
		supportMission2.Name = supportMission2.OperationName;
		referencePoint.Name = supportMission2.OperationName;
		foreach (UnitLineWrapper item2 in ChalkContainer[chalk_0])
		{
			item2.ChalkUnit.CurrentTransport.ActualTransport.AssignMissionInQueue(supportMission2);
		}
		return supportMission2;
	}

	private Mission ComputeRole(TransportWave transportWave_0, Mission mission_0 = null, int int_0 = 0)
	{
		Client.CurrentSide.RefPoints.Where((ReferencePoint theRP) => theRP.IsHighlighted);
		Zone zone = transportWave_0.ReadWatcher();
		if (zone == null)
		{
			return null;
		}
		CargoMission cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, zone.Description + " " + transportWave_0.AssociatedTransport.ActualTransport.Name + " Wave " + transportWave_0.Wave, Mission.MissionCategory.Mission, zone.Area, bool_0: true);
		transportWave_0.AssociatedTransport.ActualTransport.AssignMissionInQueue(cargoMission);
		cargoMission.MissionCompletedTrigger_LUA = "return(ScenEdit_GetMission('" + Client.CurrentSide.ObjectID + "', '" + cargoMission.ObjectID + "').cargomission.IsFulfilled)";
		cargoMission.MissionCompletedTrigger_LUA_Enabled = true;
		cargoMission.MissionCompletedTrigger_LUADescription = "Unloaded From Mothership";
		cargoMission.PriorityWeight = int_0;
		cargoMission.CreationMode = MissionCreationType.LandingPlanner;
		cargoMission.OperationName = transportWave_0.AssociatedTransport.ActualTransport.Name + " - Serials";
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item in transportWave_0.UnitsInWave)
		{
			if (!dictionary.ContainsKey(item.Key.AssociatedChalk.ID))
			{
				CargoMission cargoMission2;
				(cargoMission2 = cargoMission).OperationName = cargoMission2.OperationName + " #" + item.Key.AssociatedChalk.ID;
				dictionary.Add(item.Key.AssociatedChalk.ID, item.Key.AssociatedChalk.ID);
			}
		}
		if (mission_0 == null)
		{
			transportWave_0.IsFirstWave = true;
		}
		else
		{
			cargoMission.MissionStartTrigger_MissionCompleted.Add(mission_0, mission_0);
			cargoMission.MissionStartTrigger_MissionCompleted_Enabled = true;
			transportWave_0.IsFirstWave = false;
		}
		cargoMission.TransportWaveManifest = transportWave_0;
		foreach (KeyValuePair<ChalkUnit, ChalkUnit> item2 in transportWave_0.UnitsInWave)
		{
			CargoManifestItem.Add(item2.Key.Unit, cargoMission.CargoToUnload);
		}
		return cargoMission;
	}

	private void PatchRole(object sender, EventArgs e)
	{
		if (DGVMain.IsCurrentCellDirty)
		{
			DGVMain.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void SelectRole(object sender, DataGridViewCellEventArgs e)
	{
		if (!(DGVMain.CurrentCell is DataGridViewCheckBoxCell dataGridViewCheckBoxCell))
		{
			return;
		}
		foreach (KeyValuePair<string, TransportAvailability> item in m_SpecificationComposer)
		{
			if (e.ColumnIndex != DGVMain.Columns[item.Key].Index)
			{
				continue;
			}
			UnitLineWrapper unitLineWrapper = (UnitLineWrapper)_TokenizerComposer[DGVMain.CurrentCell.RowIndex];
			if (Conversions.ToBoolean(dataGridViewCheckBoxCell.Value))
			{
				if (taskComposer == (EditionMode)1)
				{
					if (!ChalkContainer.ContainsKey(unitLineWrapper.ChalkUnit.AssociatedChalk))
					{
						continue;
					}
					foreach (UnitLineWrapper item2 in ChalkContainer[unitLineWrapper.ChalkUnit.AssociatedChalk])
					{
						item2.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.UseTransport;
					}
				}
				else
				{
					unitLineWrapper.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.UseTransport;
				}
			}
			else if (taskComposer == (EditionMode)1)
			{
				if (!ChalkContainer.ContainsKey(unitLineWrapper.ChalkUnit.AssociatedChalk))
				{
					continue;
				}
				foreach (UnitLineWrapper item3 in ChalkContainer[unitLineWrapper.ChalkUnit.AssociatedChalk])
				{
					item3.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.DontUseTransport;
				}
			}
			else
			{
				unitLineWrapper.ChalkUnit.TransportAvailable[item.Key] = TransportAvailability.DontUseTransport;
			}
		}
		SortInitializer();
	}

	private void CallRole(object sender, EventArgs e)
	{
		CalcInitializer();
	}

	private void LogoutRole(object sender, EventArgs e)
	{
		ViewRole();
	}

	private void ViewRole()
	{
		List<Transport> list = new List<Transport>();
		List<Transport> list2 = new List<Transport>();
		new List<ChalkUnit>();
		m_FilterComposer = false;
		foreach (Transport item in AllowedTransport.Values.ToList())
		{
			item.Waves = new List<TransportWave>();
			list.Add(item);
		}
		foreach (Transport item7 in list)
		{
			foreach (ChalkUnit item8 in descriptorComposer)
			{
				if (item8.AssociatedChalk.ID == -1 && item8.AssociatedChalk.Preboat == item7)
				{
					if (item8.LandingZone == null)
					{
						DarkMessageBox.ShowWarning("Pre-boated serials MUST have a landing zone. Aborting generation.", "Assign a landing zone");
						return;
					}
					if (item7.Waves.Count == 0)
					{
						item7.Waves.Add(new TransportWave(item7, item7.Waves.Count + 1, item8.LandingZone));
					}
					item7.Waves.ElementAt(0).CompareWatcher(item8);
				}
			}
		}
		foreach (Chalk key in ChalkContainer.Keys)
		{
			bool flag = true;
			foreach (UnitLineWrapper item9 in ChalkContainer[key])
			{
				if (!item9.ChalkUnit.TransportAvailable.ContainsKey("Self") || item9.ChalkUnit.TransportAvailable["Self"] != TransportAvailability.UseTransport)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			foreach (UnitLineWrapper item10 in ChalkContainer[key])
			{
				item10.ChalkUnit.CurrentTransport = new Transport(item10.ChalkUnit.Unit.CargoObjectActiveUnit);
				item10.ChalkUnit.Wave = 0;
				item10.ChalkUnit.AssociatedChalk.SelfTransport = true;
				m_FilterComposer = true;
			}
		}
		if (CB_SerialIntegrity.Checked)
		{
			foreach (Chalk key2 in ChalkContainer.Keys)
			{
				if (ChalkContainer[key2].Count == 0)
				{
					continue;
				}
				LandingZoneWrapper landingZone = ChalkContainer[key2][0].ChalkUnit.LandingZone;
				Dictionary<string, TransportAvailability> transportAvailable = ChalkContainer[key2][0].ChalkUnit.TransportAvailable;
				foreach (UnitLineWrapper item11 in ChalkContainer[key2])
				{
					if (landingZone == item11.ChalkUnit.LandingZone)
					{
						foreach (KeyValuePair<string, TransportAvailability> item12 in transportAvailable)
						{
							if (!item11.ChalkUnit.TransportAvailable.ContainsKey(item12.Key) || item11.ChalkUnit.TransportAvailable[item12.Key] != item12.Value)
							{
								DarkMessageBox.ShowWarning("ERROR," + item11.ChalkUnit.Unit.CargoObjectName + " in serial # " + key2.ID + " : In 'Serial Integrity' mode, the serial's units must share the same allowed transport configuration. Aborting . . .", "Error Generating Landing Plan");
								return;
							}
						}
						continue;
					}
					DarkMessageBox.ShowWarning("ERROR," + item11.ChalkUnit.Unit.CargoObjectName + " in serial # " + key2.ID + " : In 'Serial Integrity' mode, the serial's units must share the same landing zone. Aborting . . .", "Error Generating Landing Plan");
					return;
				}
			}
			new List<Chalk>();
			foreach (Chalk item13 in (from x in ChalkContainer.Keys.ToList()
				orderby x.Priority
				select x).ToList())
			{
				if (item13.Cargo.Count == 0 || item13.SelfTransport)
				{
					continue;
				}
				Transport preboat = item13.Preboat;
				ChalkUnit chalkUnit = ChalkContainer[item13][0].ChalkUnit;
				List<string> list3 = new List<string>();
				if (preboat == null)
				{
					list2 = new List<Transport>();
					foreach (Transport item14 in list)
					{
						if (!chalkUnit.CallImporter(item14) || chalkUnit.TransportAvailable[item14.ActualTransport.UnitClass] != TransportAvailability.UseTransport)
						{
							continue;
						}
						int num = -1;
						ActiveUnit actualTransport = item14.ActualTransport;
						float float_ = -1f;
						string obj = item13.AddImporter(actualTransport, ref float_);
						num = (int)Math.Round(float_);
						string text = obj;
						if (Operators.CompareString(text, "OK", TextCompare: true) == 0)
						{
							if ((float)num <= 1f)
							{
								list2.Add(item14);
							}
							else if ((float)num > 1f)
							{
								list3.Add(item14.ActualTransport.Name + " : Requires " + num + " runs (Serial Integrity Mode)");
							}
						}
						else
						{
							list3.Add(item14.ActualTransport.Name + " : " + text);
						}
					}
					foreach (UnitLineWrapper item2 in ChalkContainer[item13])
					{
						item2.ChalkUnit.TransportErrorMessagTooltip = "Serial Integrity Mode : the serial will not spread accross multiple transports";
						foreach (string item3 in list3)
						{
							ref string transportErrorMessagTooltip = ref item2.ChalkUnit.TransportErrorMessagTooltip;
							transportErrorMessagTooltip = transportErrorMessagTooltip + item3 + Environment.NewLine;
						}
					}
					if (list2.Count == 0)
					{
						foreach (UnitLineWrapper item4 in ChalkContainer[item13])
						{
							if (list3.Count == 0)
							{
								item4.ChalkUnit.TransportErrorMessage = "None";
							}
							else
							{
								item4.ChalkUnit.TransportErrorMessage = "Impossible (" + list3.Count + " issues...)";
							}
						}
						continue;
					}
				}
				else
				{
					list2.Add(preboat);
				}
				bool bool_ = false;
				bool flag2 = true;
				int num2 = 0;
				int num3 = 1;
				while (true)
				{
					Transport transport = list2.ElementAt(num2);
					if (chalkUnit.AssociatedChalk.ID != -1)
					{
						switch (transport.PopWatcher(item13, chalkUnit.LandingZone, ChalkContainer, bool_, num3))
						{
						default:
							flag2 = false;
							num2++;
							if (num2 < list2.Count)
							{
								continue;
							}
							if (!flag2)
							{
								num2 = 0;
								bool_ = true;
								num3++;
								continue;
							}
							break;
						case AddCargoReturnValue.Success:
							m_FilterComposer = true;
							break;
						case AddCargoReturnValue.Impossible:
							break;
						}
					}
					else
					{
						m_FilterComposer = true;
					}
					break;
				}
			}
		}
		else
		{
			new List<ChalkUnit>();
			foreach (ChalkUnit item5 in descriptorComposer.OrderBy((ChalkUnit x) => x.AssociatedChalk.Priority).ToList())
			{
				if (item5.AssociatedChalk.SelfTransport)
				{
					continue;
				}
				item5.CurrentTransport = null;
				item5.Wave = 0;
				if (item5.AssociatedChalk.Preboat == null)
				{
					list2 = new List<Transport>();
					foreach (Transport item6 in list)
					{
						if (item5.CallImporter(item6) && item5.TransportAvailable[item6.ActualTransport.UnitClass] == TransportAvailability.UseTransport)
						{
							list2.Add(item6);
						}
					}
					if (list2.Count == 0)
					{
						continue;
					}
				}
				else
				{
					list2.Add(item5.AssociatedChalk.Preboat);
				}
				bool bool_2 = false;
				bool flag3 = true;
				int num4 = 0;
				int num5 = 1;
				while (true)
				{
					Transport transport2 = list2.ElementAt(num4);
					if (item5.AssociatedChalk.ID != -1)
					{
						switch (transport2.InstantiateWatcher(item5, bool_2, num5))
						{
						default:
							flag3 = false;
							num4++;
							if (num4 < list2.Count)
							{
								continue;
							}
							if (!flag3)
							{
								num4 = 0;
								bool_2 = true;
								num5++;
								continue;
							}
							break;
						case AddCargoReturnValue.Success:
							m_FilterComposer = true;
							break;
						case AddCargoReturnValue.Impossible:
							break;
						}
					}
					else
					{
						m_FilterComposer = true;
					}
					break;
				}
			}
		}
		SortInitializer();
		FlushInitializer();
		AwakeInitializer();
	}

	private void ValidateRole(object sender, EventArgs e)
	{
		GeneratedMissions.Clear();
		foreach (KeyValuePair<ActiveUnit, Transport> transport in TransportList)
		{
			Mission mission = null;
			int num = transport.Value.Waves.Count * 10;
			foreach (TransportWave item in transport.Value.Waves.ToList())
			{
				mission = ComputeRole(item, mission, num);
				item.AssociatedMission = (CargoMission)mission;
				GeneratedMissions.Add(mission, item.AssociatedTransport.LandingType);
				num--;
			}
		}
		foreach (KeyValuePair<Chalk, List<UnitLineWrapper>> item2 in ChalkContainer)
		{
			if (item2.Key.SelfTransport)
			{
				GeneratedMissions.Add(DestroyRole(item2.Key), LandingType.Amphibious);
			}
		}
		if (GeneratedMissions.Count <= 0)
		{
			MessageBox.Show("The landing plan was not able to generate any mission", "Landing Planner Generation", MessageBoxButtons.OK);
			return;
		}
		LandingPlan = new LandingPlan(Client.CurrentSide, GeneratedMissions.Keys.ToList(), "Landing from " + CurrentMothership.Name);
		Client.CurrentSide.LandingPlans.Add(LandingPlan);
		ConfirmLandingPlanDialog confirmLandingPlanDialog = new ConfirmLandingPlanDialog();
		confirmLandingPlanDialog.landingPlannerWindow = this;
		confirmLandingPlanDialog.ShowDialog();
	}

	private void LoginRole(object sender, EventArgs e)
	{
		if (taskComposer == (EditionMode)0)
		{
			taskComposer = (EditionMode)1;
		}
		else
		{
			taskComposer = (EditionMode)0;
		}
		GetRole();
	}

	private void GetRole()
	{
		if (taskComposer == (EditionMode)0)
		{
			ButtonToggleEditionMode.Text = "Edition Mode : Individual Units";
		}
		else
		{
			ButtonToggleEditionMode.Text = "Edition Mode : Serial";
		}
	}

	private void WriteRole(object sender, EventArgs e)
	{
		ExportImportTool.ExportLandingPlan_Simplified(this, null, bool_0: true, DarkMessageBox.ShowInformation("Would you like to make this savefile into a more accessible, and human-readable format ?" + Environment.NewLine + "In this less reliable format, you must avoid identical names between transports, zones and motherships.", "Export mode", DarkDialogButton.YesNo) == DialogResult.Yes);
	}

	private void NewRole(object sender, EventArgs e)
	{
		if (LV_MissionPrep.SelectedItems.Count == 0 || LV_MissionPrep.SelectedItems.ElementAt(0) == null)
		{
			return;
		}
		LandingZoneWrapper landingZoneWrapper = (LandingZoneWrapper)LV_MissionPrep.SelectedItems.ElementAt(0).Tag;
		if (landingZoneWrapper != null)
		{
			if (ComboBoxLandingType.SelectedIndex == 0)
			{
				AssignedZones[landingZoneWrapper].LandingZoneType = LandingType.Unassigned;
			}
			else if (ComboBoxLandingType.SelectedIndex == 1)
			{
				AssignedZones[landingZoneWrapper].LandingZoneType = LandingType.Amphibious;
			}
			else if (ComboBoxLandingType.SelectedIndex == 2)
			{
				AssignedZones[landingZoneWrapper].LandingZoneType = LandingType.Airborne;
			}
			SortInitializer();
			ResetInitializer();
		}
	}

	private void PushRole(object sender, EventArgs e)
	{
		if (LV_MissionPrep.SelectedItems.Count != 0 && LV_MissionPrep.SelectedItems.ElementAt(0) != null)
		{
			LandingZoneWrapper landingZoneWrapper = (LandingZoneWrapper)LV_MissionPrep.SelectedItems.ElementAt(0).Tag;
			if (landingZoneWrapper.LandingZoneType == LandingType.Airborne)
			{
				ComboBoxLandingType.Text = "Airborne (LZ)";
			}
			else if (landingZoneWrapper.LandingZoneType == LandingType.Amphibious)
			{
				ComboBoxLandingType.Text = "Amphibious (CLZ)";
			}
			else if (landingZoneWrapper.LandingZoneType == LandingType.Unassigned)
			{
				ComboBoxLandingType.Text = "未分配";
			}
		}
	}

	private void InvokeRole(object sender, EventArgs e)
	{
		ExportImportTool.ImportLandingPlan(this, null, bool_0: true);
	}

	private void SetupRole(object sender, EventArgs e)
	{
		try
		{
			List<DataGridViewColumn> list = new List<DataGridViewColumn>();
			IEnumerator enumerator = null;
			try
			{
				enumerator = DGVMain.Columns.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataGridViewColumn item = (DataGridViewColumn)enumerator.Current;
					list.Add(item);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			list = list.OrderBy((DataGridViewColumn c) => c.DisplayIndex).ToList();
			List<string> list2 = new List<string>();
			string[] value = (from DataGridViewColumn header in list
				select header.HeaderText).ToArray();
			list2.Add(string.Join(";", value));
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = ((IEnumerable)DGVMain.Rows).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator2.Current;
					List<string> list3 = new List<string>();
					foreach (DataGridViewColumn item2 in list)
					{
						list3.Add(dataGridViewRow.Cells[item2.Index].FormattedValue.ToString());
					}
					list2.Add(string.Join(";", list3.ToArray()));
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			list2.Add("");
			list2.Add("");
			foreach (Transport value2 in AllowedTransport.Values)
			{
				if (value2.Waves.Count == 0)
				{
					continue;
				}
				list2.Add("");
				list2.Add("---- " + value2.ActualTransport.Name + " ----");
				list2.Add("Wave;Area;Weight;PAX");
				foreach (TransportWave wave in value2.Waves)
				{
					list2.Add("");
					list2.Add("Transport Manifest for wave #" + wave.Wave);
					string[] array = new string[7] { "Chalk", "Unit Name", "Area", "Weight", "PAX", "货物类型", null };
					list2.Add(string.Join(";", array));
					foreach (KeyValuePair<ChalkUnit, ChalkUnit> item3 in wave.UnitsInWave)
					{
						if (item3.Key.AssociatedChalk == null)
						{
							array[0] = "Preboated";
						}
						else
						{
							array[0] = item3.Key.AssociatedChalk.ID.ToString();
						}
						array[1] = item3.Key.Unit.CargoObjectName;
						array[2] = item3.Key.Unit.RequiredArea.ToString();
						array[3] = item3.Key.Unit.RequiredMass.ToString();
						array[4] = item3.Key.Unit.RequiredCrewSpace.ToString();
						array[5] = item3.Key.Unit.RequiredCargoType.ToString();
						list2.Add(string.Join(";", array));
					}
					list2.Add("TOTAL ; --- ;" + Math.Round(wave.DisableWatcher(), 1) + ";" + Math.Round(wave.UpdateWatcher(), 1) + ";" + Math.Round(wave.InsertWatcher(), 1));
				}
			}
			string text = Path.Combine(ExportImportTool.CreateDestinationFolder_LandingPlanner(), "LandingPlan_Report_" + CurrentMothership.Name);
			string text2 = "csv";
			int num = 0;
			string path = text + "." + text2;
			while (File.Exists(path))
			{
				num++;
				path = text + " - " + Conversions.ToString(num) + "." + text2;
			}
			File.WriteAllLines(path, list2.ToArray());
			DarkMessageBox.ShowInformation("The landing plan details was successfully exported to LandingPlan_Report_" + CurrentMothership.Name, "Landing Planner Generation");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("The landing plan details failed to export - ERROR : " + ex2.Message, "Landing Planner Generation", MessageBoxButtons.OK);
			ProjectData.ClearProjectError();
		}
	}

	private void ExcludeRole(object sender, EventArgs e)
	{
		Process.Start(ExportImportTool.CreateDestinationFolder_LandingPlanner());
	}

	[CompilerGenerated]
	private void IncludeRole(object sender, CancelEventArgs e)
	{
		OperationPlannerForm_Quit(RuntimeHelpers.GetObjectValue(sender), (FormClosingEventArgs)e);
	}
}
