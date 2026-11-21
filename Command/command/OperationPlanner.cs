using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class OperationPlanner : Form
{
	public enum SortOrderType
	{
		EstimatedExecutionTime,
		Phase,
		Operation,
		Name
	}

	public class ComboFilterWrapper
	{
		private SortOrderType m_CreatorMap;

		private string Text;

		public SortOrderType Type
		{
			get
			{
				return m_CreatorMap;
			}
			set
			{
				m_CreatorMap = value;
			}
		}

		public string Label => Text;

		public ComboFilterWrapper(SortOrderType sortOrderType_0, string string_0)
		{
			m_CreatorMap = sortOrderType_0;
			Text = string_0;
		}
	}

	[DoNotObfuscateType]
	[DoNotPruneType]
	[DoNotPrune]
	private class MissionPhaseComboWrapper
	{
		private MissionPhase _TemplateMap;

		private string mappingMap;

		public MissionPhase ID
		{
			get
			{
				return _TemplateMap;
			}
			set
			{
			}
		}

		public string Label
		{
			get
			{
				return mappingMap;
			}
			set
			{
			}
		}

		public MissionPhaseComboWrapper(MissionPhase missionPhase_0, string string_0)
		{
			mappingMap = string_0;
			_TemplateMap = missionPhase_0;
		}
	}

	[DoNotPrune]
	[DoNotObfuscateType]
	[DoNotPruneType]
	private class MissionHL_HourComboWrapper
	{
		private Mission mockMap;

		public Mission ID
		{
			get
			{
				return mockMap;
			}
			set
			{
			}
		}

		public string Label
		{
			get
			{
				if (Information.IsNothing(mockMap))
				{
					return "None";
				}
				return mockMap.Name;
			}
			set
			{
			}
		}

		public MissionHL_HourComboWrapper(Mission mission_0)
		{
			mockMap = mission_0;
		}
	}

	[DoNotPrune]
	[DoNotPruneType]
	[DoNotObfuscateType]
	private class MissionWrapper
	{
		public Mission tagMap;

		public int Priority
		{
			get
			{
				return tagMap.PriorityWeight;
			}
			set
			{
				tagMap.PriorityWeight = value;
			}
		}

		public string OperationName
		{
			get
			{
				string text = "";
				if (string.IsNullOrEmpty(tagMap.OperationName))
				{
					text = " Mobilised/Assigned Units [" + tagMap.UnitsAssignedToMission.Count + "/" + (tagMap.UnitsQueuedToMission.Count + tagMap.UnitsAssignedToMission.Count) + "]";
				}
				return tagMap.OperationName + text;
			}
			set
			{
				tagMap.OperationName = value;
			}
		}

		public string Name
		{
			get
			{
				return tagMap.Name;
			}
			set
			{
				tagMap.Name = value;
			}
		}

		public bool BulkSelection
		{
			get
			{
				return tagMap.MarkedForBulkEdition;
			}
			set
			{
				tagMap.MarkedForBulkEdition = value;
			}
		}

		public bool Activation
		{
			get
			{
				return tagMap.IsActive;
			}
			set
			{
				if (value)
				{
					tagMap.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Active);
				}
				else
				{
					tagMap.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
				}
			}
		}

		public string ExecutionTime
		{
			get
			{
				if (tagMap.EstimatedExecutionTime == -500)
				{
					return "- Unpredictable -";
				}
				return "H+ " + new TimeSpan(0, 0, tagMap.EstimatedExecutionTime).ToString();
			}
			set
			{
			}
		}

		public string Type
		{
			get
			{
				string text = tagMap.GetDescriptionString(Client.CurrentScenario);
				if (tagMap.CreationMode == MissionCreationType.LandingPlanner)
				{
					text += " (Landing plan)";
				}
				else if (tagMap.CreationMode == MissionCreationType.Generated)
				{
					text += " (generated)";
				}
				return text;
			}
			set
			{
			}
		}

		public MissionWrapper(Mission mission_0)
		{
			tagMap = mission_0;
		}
	}

	private IContainer mapperPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_SerialEditor")]
	private DarkUIButton managerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_LandingPlanner")]
	private DarkUIButton _GetterPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private FlowLayoutPanel producerPublisher;

	[AccessedThroughProperty("MainDGV")]
	[CompilerGenerated]
	private DataGridView _ProcPublisher;

	[AccessedThroughProperty("Button_MissionEditor")]
	[CompilerGenerated]
	private DarkUIButton m_StructServer;

	[CompilerGenerated]
	[AccessedThroughProperty("GP_MissionTriggers")]
	private DarkGroupBox merchantServer;

	[AccessedThroughProperty("StartOfMission_DateTimeReachedPanel")]
	[CompilerGenerated]
	private Panel m_DecoratorServer;

	[AccessedThroughProperty("CB_StartOfMission_DateTimeReachedPanel")]
	[CompilerGenerated]
	private DarkCheckBox processServer;

	[AccessedThroughProperty("FlowLayoutPanel2")]
	[CompilerGenerated]
	private FlowLayoutPanel m_InstanceServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DateTimeEndMission")]
	private DarkCheckBox _ParameterServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DatePicker_HHourDate")]
	private DateTimePicker _DispatcherServer;

	[AccessedThroughProperty("Button_MissionFinishedCriteriaAdd")]
	[CompilerGenerated]
	private DarkUIButton _ListenerServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_StartOfMission_UnitUnloadedPctPanel")]
	private DarkCheckBox m_RegistryServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Combobox_OperatorDateAndTime")]
	private ComboBox _DefinitionServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Combobox_OperatorMissionFinished")]
	private ComboBox _ValServer;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboMissionEndElapsed")]
	private ComboBox _WrapperServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DatePicker_HHourTime")]
	private DateTimePicker m_ObserverServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_StartMission_Time")]
	private DateTimePicker issuerServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DatePicker_LHourTime")]
	private DateTimePicker clientServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DatePicker_LHourDate")]
	private DateTimePicker dicServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Combobox_OperatorLuaScript")]
	private ComboBox _FacadeServer;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelStatic_LuaScript")]
	private DarkLabel proxyServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_LuaScript")]
	private DarkCheckBox _ReaderServer;

	[AccessedThroughProperty("ComboBox_HHourMissionStart")]
	[CompilerGenerated]
	private DarkUIComboBox _ImporterServer;

	[AccessedThroughProperty("LHourGroupBox")]
	[CompilerGenerated]
	private DarkGroupBox repositoryServer;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_LHourMissionStart")]
	private DarkUIComboBox _BridgeServer;

	[AccessedThroughProperty("UiUpdateTimer")]
	[CompilerGenerated]
	private Timer m_InvocationServer;

	[AccessedThroughProperty("LV_MissionFinishedCriteria_ToCheck")]
	[CompilerGenerated]
	private DarkListView m_RequestServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_MissionFinishedCriteriaRemove")]
	private DarkUIButton m_ValueServer;

	[AccessedThroughProperty("DarkLabel2")]
	[CompilerGenerated]
	private DarkLabel tokenizerServer;

	[AccessedThroughProperty("ButtonConfirmScript")]
	[CompilerGenerated]
	private DarkUIButton writerServer;

	[AccessedThroughProperty("EndMissionTimeElapsedProgressBar")]
	[CompilerGenerated]
	private DarkUIProgressBar specificationServer;

	[AccessedThroughProperty("ButtonConfirmScriptMissionComplete")]
	[CompilerGenerated]
	private DarkUIButton reponseServer;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBox_EndMissionLuaScript")]
	private ComboBox m_DescriptorServer;

	[AccessedThroughProperty("CB_EndMissionLua")]
	[CompilerGenerated]
	private DarkCheckBox taskServer;

	[AccessedThroughProperty("DarkRichTextBox1")]
	[CompilerGenerated]
	private DarkRichTextBox m_InterpreterServer;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private ComboBox containerServer;

	[AccessedThroughProperty("ButtonResetTimer")]
	[CompilerGenerated]
	private DarkUIButton composerServer;

	[AccessedThroughProperty("DateTimePicker1")]
	[CompilerGenerated]
	private DateTimePicker modelServer;

	[AccessedThroughProperty("LabelEstimatedTotalTime")]
	[CompilerGenerated]
	private DarkLabel customerServer;

	[AccessedThroughProperty("LabelLPlus")]
	[CompilerGenerated]
	private DarkLabel m_SerializerServer;

	[AccessedThroughProperty("DarkLabel6")]
	[CompilerGenerated]
	private DarkLabel m_ErrorServer;

	[AccessedThroughProperty("ButtonSImulate")]
	[CompilerGenerated]
	private DarkUIButton codeServer;

	[AccessedThroughProperty("DarkLabel5")]
	[CompilerGenerated]
	private DarkLabel connectionServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_StartMission_Time_DaysCount")]
	private NumericUpDown statusServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel7")]
	private DarkLabel proccesorServer;

	[AccessedThroughProperty("TimeElpasedFulfillTrigger_DayCOunt")]
	[CompilerGenerated]
	private NumericUpDown _StrategyServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel8")]
	private DarkLabel configurationServer;

	[AccessedThroughProperty("CB_LockHhour_LHour")]
	[CompilerGenerated]
	private CheckBox m_IndexerServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel9")]
	private DarkLabel resolverServer;

	[AccessedThroughProperty("StarLuaDescription")]
	[CompilerGenerated]
	private DarkLabel publisherServer;

	[AccessedThroughProperty("DarkLabel10")]
	[CompilerGenerated]
	private DarkLabel m_ServerServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel12")]
	private DarkLabel schemaServer;

	[AccessedThroughProperty("LabelInitialMission")]
	[CompilerGenerated]
	private DarkLabel predicateServer;

	[AccessedThroughProperty("CB_AUTOSIMULATEt")]
	[CompilerGenerated]
	private DarkUICheckBox singletonServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIButton2")]
	private DarkUIButton recordServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AUTOSIMULATE")]
	private DarkUIButton _ExceptionServer;

	[AccessedThroughProperty("DarkLabel11")]
	[CompilerGenerated]
	private DarkLabel m_AttrServer;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonStartTriggerPlusMinusToggle")]
	private DarkUIButton m_VisitorServer;

	[AccessedThroughProperty("TB_FilterMissions")]
	[CompilerGenerated]
	private DarkTextBox m_ExporterServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel13")]
	private DarkLabel m_PrototypeServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_PerformFilter")]
	private DarkUIButton comparatorServer;

	[AccessedThroughProperty("ComboSortOrder")]
	[CompilerGenerated]
	private DarkUIComboBox m_ItemServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox1")]
	private DarkGroupBox m_CreatorServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox2")]
	private DarkGroupBox templateServer;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private Label mappingServer;

	[CompilerGenerated]
	[AccessedThroughProperty("FlowLayoutPanel3")]
	private FlowLayoutPanel m_MockServer;

	[AccessedThroughProperty("Button_BulkAction_Delete")]
	[CompilerGenerated]
	private DarkUIButton m_TagServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BulkAction_UnassignAll")]
	private DarkUIButton fieldServer;

	[AccessedThroughProperty("Button_BulkAction_Activate")]
	[CompilerGenerated]
	private DarkUIButton _QueueServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BulkAction_Desactivate")]
	private DarkUIButton regServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_BulkAction_UnassignAllQueud")]
	private DarkUIButton paramServer;

	[AccessedThroughProperty("Button_CheckAll")]
	[CompilerGenerated]
	private DarkUIButton pageServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_UnCheckAll")]
	private DarkUIButton rulesServer;

	[AccessedThroughProperty("ComboBox_BulkPhase")]
	[CompilerGenerated]
	private DarkUIComboBox methodServer;

	private BindingSource _ServiceServer;

	private MissionWrapper _SystemServer;

	private Dictionary<Mission, MissionWrapper> m_CandidateServer;

	private Dictionary<Mission, Mission> m_BaseServer;

	private bool m_PolicyServer;

	private bool broadcasterServer;

	private bool identifierServer;

	private bool printerServer;

	private int m_ParserServer;

	private int _AlgoServer;

	internal virtual DarkUIButton Button_SerialEditor
	{
		[CompilerGenerated]
		get
		{
			return managerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteInterruptibleModel;
			DarkUIButton darkUIButton = managerPublisher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			managerPublisher = value;
			darkUIButton = managerPublisher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_LandingPlanner
	{
		[CompilerGenerated]
		get
		{
			return _GetterPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleModel;
			DarkUIButton getterPublisher = _GetterPublisher;
			if (getterPublisher != null)
			{
				getterPublisher.Click -= value2;
			}
			_GetterPublisher = value;
			getterPublisher = _GetterPublisher;
			if (getterPublisher != null)
			{
				getterPublisher.Click += value2;
			}
		}
	}

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return producerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			producerPublisher = value;
		}
	}

	internal virtual DataGridView MainDGV
	{
		[CompilerGenerated]
		get
		{
			return _ProcPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewEditingControlShowingEventHandler value2 = EnableInterruptibleModel;
			EventHandler value3 = CheckInterruptibleModel;
			DataGridViewCellMouseEventHandler value4 = StartInterruptibleModel;
			DataGridViewCellEventHandler value5 = AssetInterruptibleModel;
			DataGridView procPublisher = _ProcPublisher;
			if (procPublisher != null)
			{
				procPublisher.EditingControlShowing -= value2;
				procPublisher.SelectionChanged -= value3;
				procPublisher.CellMouseUp -= value4;
				procPublisher.CellValueChanged -= value5;
			}
			_ProcPublisher = value;
			procPublisher = _ProcPublisher;
			if (procPublisher != null)
			{
				procPublisher.EditingControlShowing += value2;
				procPublisher.SelectionChanged += value3;
				procPublisher.CellMouseUp += value4;
				procPublisher.CellValueChanged += value5;
			}
		}
	}

	internal virtual DarkUIButton Button_MissionEditor
	{
		[CompilerGenerated]
		get
		{
			return m_StructServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewInterruptibleModel;
			DarkUIButton structServer = m_StructServer;
			if (structServer != null)
			{
				structServer.Click -= value2;
			}
			m_StructServer = value;
			structServer = m_StructServer;
			if (structServer != null)
			{
				structServer.Click += value2;
			}
		}
	}

	internal virtual DarkGroupBox GP_MissionTriggers
	{
		[CompilerGenerated]
		get
		{
			return merchantServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			merchantServer = value;
		}
	}

	[field: AccessedThroughProperty("PanelMissionTrigger")]
	internal virtual FlowLayoutPanel PanelMissionTrigger
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Panel StartOfMission_DateTimeReachedPanel
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DecoratorServer = value;
		}
	}

	internal virtual DarkCheckBox CB_StartOfMission_DateTimeReachedPanel
	{
		[CompilerGenerated]
		get
		{
			return processServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleModel;
			DarkCheckBox darkCheckBox = processServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			processServer = value;
			darkCheckBox = processServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelStatic_DateAndTime")]
	internal virtual DarkLabel LabelStatic_DateAndTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("EndOfMission_UnitUnloadedPctPanel")]
	internal virtual Panel EndOfMission_UnitUnloadedPctPanel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GP_EndMissionCriteria")]
	internal virtual DarkGroupBox GP_EndMissionCriteria
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual FlowLayoutPanel FlowLayoutPanel2
	{
		[CompilerGenerated]
		get
		{
			return m_InstanceServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InstanceServer = value;
		}
	}

	[field: AccessedThroughProperty("Panel_DateTimeEndMissionCriteria")]
	internal virtual Panel Panel_DateTimeEndMissionCriteria
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkCheckBox CB_DateTimeEndMission
	{
		[CompilerGenerated]
		get
		{
			return _ParameterServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateInterruptibleModel;
			DarkCheckBox parameterServer = _ParameterServer;
			if (parameterServer != null)
			{
				parameterServer.CheckedChanged -= value2;
			}
			_ParameterServer = value;
			parameterServer = _ParameterServer;
			if (parameterServer != null)
			{
				parameterServer.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelStatic_DateAndTimeEndMIssion")]
	internal virtual DarkLabel LabelStatic_DateAndTimeEndMIssion
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DateTimePicker DatePicker_HHourDate
	{
		[CompilerGenerated]
		get
		{
			return _DispatcherServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushInterruptibleModel;
			DateTimePicker dispatcherServer = _DispatcherServer;
			if (dispatcherServer != null)
			{
				dispatcherServer.ValueChanged -= value2;
			}
			_DispatcherServer = value;
			dispatcherServer = _DispatcherServer;
			if (dispatcherServer != null)
			{
				dispatcherServer.ValueChanged += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_MissionFinishedCriteriaAdd
	{
		[CompilerGenerated]
		get
		{
			return _ListenerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleModel;
			DarkUIButton listenerServer = _ListenerServer;
			if (listenerServer != null)
			{
				listenerServer.Click -= value2;
			}
			_ListenerServer = value;
			listenerServer = _ListenerServer;
			if (listenerServer != null)
			{
				listenerServer.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelStatic_MIssionFinished")]
	internal virtual DarkLabel LabelStatic_MIssionFinished
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkCheckBox CB_StartOfMission_UnitUnloadedPctPanel
	{
		[CompilerGenerated]
		get
		{
			return m_RegistryServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptInterruptibleModel;
			DarkCheckBox registryServer = m_RegistryServer;
			if (registryServer != null)
			{
				registryServer.CheckedChanged -= value2;
			}
			m_RegistryServer = value;
			registryServer = m_RegistryServer;
			if (registryServer != null)
			{
				registryServer.CheckedChanged += value2;
			}
		}
	}

	internal virtual ComboBox Combobox_OperatorDateAndTime
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertInterruptibleModel;
			ComboBox definitionServer = _DefinitionServer;
			if (definitionServer != null)
			{
				definitionServer.SelectedIndexChanged -= value2;
			}
			_DefinitionServer = value;
			definitionServer = _DefinitionServer;
			if (definitionServer != null)
			{
				definitionServer.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual ComboBox Combobox_OperatorMissionFinished
	{
		[CompilerGenerated]
		get
		{
			return _ValServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartInterruptibleModel;
			ComboBox valServer = _ValServer;
			if (valServer != null)
			{
				valServer.SelectedIndexChanged -= value2;
			}
			_ValServer = value;
			valServer = _ValServer;
			if (valServer != null)
			{
				valServer.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual ComboBox ComboMissionEndElapsed
	{
		[CompilerGenerated]
		get
		{
			return _WrapperServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectInterruptibleModel;
			ComboBox wrapperServer = _WrapperServer;
			if (wrapperServer != null)
			{
				wrapperServer.SelectedIndexChanged -= value2;
			}
			_WrapperServer = value;
			wrapperServer = _WrapperServer;
			if (wrapperServer != null)
			{
				wrapperServer.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_HHourTime
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeInterruptibleModel;
			DateTimePicker observerServer = m_ObserverServer;
			if (observerServer != null)
			{
				observerServer.ValueChanged -= value2;
			}
			m_ObserverServer = value;
			observerServer = m_ObserverServer;
			if (observerServer != null)
			{
				observerServer.ValueChanged += value2;
			}
		}
	}

	internal virtual DateTimePicker DateTimePicker_StartMission_Time
	{
		[CompilerGenerated]
		get
		{
			return issuerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleModel;
			DateTimePicker dateTimePicker = issuerServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged -= value2;
			}
			issuerServer = value;
			dateTimePicker = issuerServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged += value2;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_LHourTime
	{
		[CompilerGenerated]
		get
		{
			return clientServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeInterruptibleModel;
			DateTimePicker dateTimePicker = clientServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged -= value2;
			}
			clientServer = value;
			dateTimePicker = clientServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged += value2;
			}
		}
	}

	internal virtual DateTimePicker DatePicker_LHourDate
	{
		[CompilerGenerated]
		get
		{
			return dicServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupInterruptibleModel;
			DateTimePicker dateTimePicker = dicServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged -= value2;
			}
			dicServer = value;
			dateTimePicker = dicServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Panel_LuaScriptCriteria")]
	internal virtual Panel Panel_LuaScriptCriteria
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox Combobox_OperatorLuaScript
	{
		[CompilerGenerated]
		get
		{
			return _FacadeServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareInterruptibleModel;
			ComboBox facadeServer = _FacadeServer;
			if (facadeServer != null)
			{
				facadeServer.SelectedIndexChanged -= value2;
			}
			_FacadeServer = value;
			facadeServer = _FacadeServer;
			if (facadeServer != null)
			{
				facadeServer.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual DarkLabel LabelStatic_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return proxyServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proxyServer = value;
		}
	}

	internal virtual DarkCheckBox CB_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return _ReaderServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillInterruptibleModel;
			DarkCheckBox readerServer = _ReaderServer;
			if (readerServer != null)
			{
				readerServer.CheckedChanged -= value2;
			}
			_ReaderServer = value;
			readerServer = _ReaderServer;
			if (readerServer != null)
			{
				readerServer.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("HHourGroupBox")]
	internal virtual DarkGroupBox HHourGroupBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIComboBox ComboBox_HHourMissionStart
	{
		[CompilerGenerated]
		get
		{
			return _ImporterServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeInterruptibleModel;
			DarkUIComboBox importerServer = _ImporterServer;
			if (importerServer != null)
			{
				importerServer.SelectionChangeCommitted -= value2;
			}
			_ImporterServer = value;
			importerServer = _ImporterServer;
			if (importerServer != null)
			{
				importerServer.SelectionChangeCommitted += value2;
			}
		}
	}

	internal virtual DarkGroupBox LHourGroupBox
	{
		[CompilerGenerated]
		get
		{
			return repositoryServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			repositoryServer = value;
		}
	}

	internal virtual DarkUIComboBox ComboBox_LHourMissionStart
	{
		[CompilerGenerated]
		get
		{
			return _BridgeServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchInterruptibleModel;
			DarkUIComboBox bridgeServer = _BridgeServer;
			if (bridgeServer != null)
			{
				bridgeServer.SelectionChangeCommitted -= value2;
			}
			_BridgeServer = value;
			bridgeServer = _BridgeServer;
			if (bridgeServer != null)
			{
				bridgeServer.SelectionChangeCommitted += value2;
			}
		}
	}

	internal virtual Timer UiUpdateTimer
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitInterruptibleModel;
			Timer invocationServer = m_InvocationServer;
			if (invocationServer != null)
			{
				invocationServer.Tick -= value2;
			}
			m_InvocationServer = value;
			invocationServer = m_InvocationServer;
			if (invocationServer != null)
			{
				invocationServer.Tick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LV_MissionFinishedCriteriaPool")]
	internal virtual DarkListView LV_MissionFinishedCriteriaPool
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkListView LV_MissionFinishedCriteria_ToCheck
	{
		[CompilerGenerated]
		get
		{
			return m_RequestServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RequestServer = value;
		}
	}

	internal virtual DarkUIButton Button_MissionFinishedCriteriaRemove
	{
		[CompilerGenerated]
		get
		{
			return m_ValueServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptibleModel;
			DarkUIButton valueServer = m_ValueServer;
			if (valueServer != null)
			{
				valueServer.Click -= value2;
			}
			m_ValueServer = value;
			valueServer = m_ValueServer;
			if (valueServer != null)
			{
				valueServer.Click += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel2
	{
		[CompilerGenerated]
		get
		{
			return tokenizerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenizerServer = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ButtonConfirmScript
	{
		[CompilerGenerated]
		get
		{
			return writerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateInterruptibleModel;
			DarkUIButton darkUIButton = writerServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			writerServer = value;
			darkUIButton = writerServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIProgressBar EndMissionTimeElapsedProgressBar
	{
		[CompilerGenerated]
		get
		{
			return specificationServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			specificationServer = value;
		}
	}

	[field: AccessedThroughProperty("Panel_EndMissionLua")]
	internal virtual Panel Panel_EndMissionLua
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ButtonConfirmScriptMissionComplete
	{
		[CompilerGenerated]
		get
		{
			return reponseServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleModel;
			DarkUIButton darkUIButton = reponseServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			reponseServer = value;
			darkUIButton = reponseServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual ComboBox ComboBox_EndMissionLuaScript
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitInterruptibleModel;
			ComboBox descriptorServer = m_DescriptorServer;
			if (descriptorServer != null)
			{
				descriptorServer.SelectedIndexChanged -= value2;
			}
			m_DescriptorServer = value;
			descriptorServer = m_DescriptorServer;
			if (descriptorServer != null)
			{
				descriptorServer.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkCheckBox CB_EndMissionLua
	{
		[CompilerGenerated]
		get
		{
			return taskServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptibleModel;
			DarkCheckBox darkCheckBox = taskServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			taskServer = value;
			darkCheckBox = taskServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkUITextBox1")]
	internal virtual DarkUITextBox DarkUITextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Darox1")]
	internal virtual DarkUITextBox Darox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkRichTextBox DarkRichTextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterpreterServer = value;
		}
	}

	internal virtual ComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return containerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			containerServer = value;
		}
	}

	internal virtual DarkUIButton ButtonResetTimer
	{
		[CompilerGenerated]
		get
		{
			return composerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableInterruptibleModel;
			DarkUIButton darkUIButton = composerServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			composerServer = value;
			darkUIButton = composerServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DateTimePicker DateTimePicker1
	{
		[CompilerGenerated]
		get
		{
			return modelServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopInterruptibleModel;
			DateTimePicker dateTimePicker = modelServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged -= value2;
			}
			modelServer = value;
			dateTimePicker = modelServer;
			if (dateTimePicker != null)
			{
				dateTimePicker.ValueChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LabelHPlus")]
	internal virtual DarkLabel DarkLabel_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel LabelEstimatedTotalTime
	{
		[CompilerGenerated]
		get
		{
			return customerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			customerServer = value;
		}
	}

	internal virtual DarkLabel DarkLabel_1
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SerializerServer = value;
		}
	}

	[field: AccessedThroughProperty("Button2")]
	internal virtual Button Button2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel DarkLabel6
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ErrorServer = value;
		}
	}

	internal virtual DarkUIButton ButtonSImulate
	{
		[CompilerGenerated]
		get
		{
			return codeServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleModel;
			DarkUIButton darkUIButton = codeServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			codeServer = value;
			darkUIButton = codeServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel5
	{
		[CompilerGenerated]
		get
		{
			return connectionServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionServer = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual NumericUpDown DateTimePicker_StartMission_Time_DaysCount
	{
		[CompilerGenerated]
		get
		{
			return statusServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestInterruptibleModel;
			NumericUpDown numericUpDown = statusServer;
			if (numericUpDown != null)
			{
				numericUpDown.ValueChanged -= value2;
			}
			statusServer = value;
			numericUpDown = statusServer;
			if (numericUpDown != null)
			{
				numericUpDown.ValueChanged += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel7
	{
		[CompilerGenerated]
		get
		{
			return proccesorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorServer = value;
		}
	}

	internal virtual NumericUpDown TimeElpasedFulfillTrigger_DayCOunt
	{
		[CompilerGenerated]
		get
		{
			return _StrategyServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleModel;
			NumericUpDown strategyServer = _StrategyServer;
			if (strategyServer != null)
			{
				strategyServer.ValueChanged -= value2;
			}
			_StrategyServer = value;
			strategyServer = _StrategyServer;
			if (strategyServer != null)
			{
				strategyServer.ValueChanged += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel8
	{
		[CompilerGenerated]
		get
		{
			return configurationServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationServer = value;
		}
	}

	[field: AccessedThroughProperty("ProgressBarHPlusTriggerStartTime")]
	internal virtual DarkUIProgressBar ProgressBarHPlusTriggerStartTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox CB_LockHhour_LHour
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleModel;
			CheckBox indexerServer = m_IndexerServer;
			if (indexerServer != null)
			{
				indexerServer.CheckedChanged -= value2;
			}
			m_IndexerServer = value;
			indexerServer = m_IndexerServer;
			if (indexerServer != null)
			{
				indexerServer.CheckedChanged += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel9
	{
		[CompilerGenerated]
		get
		{
			return resolverServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			resolverServer = value;
		}
	}

	internal virtual DarkLabel StarLuaDescription
	{
		[CompilerGenerated]
		get
		{
			return publisherServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherServer = value;
		}
	}

	internal virtual DarkLabel DarkLabel_2
	{
		[CompilerGenerated]
		get
		{
			return m_ServerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ServerServer = value;
		}
	}

	[field: AccessedThroughProperty("EndMissionLuaDescription")]
	internal virtual DarkLabel EndMissionLuaDescription
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel DarkLabel_3
	{
		[CompilerGenerated]
		get
		{
			return schemaServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			schemaServer = value;
		}
	}

	[field: AccessedThroughProperty("LabelLHourInitialMission")]
	internal virtual DarkLabel LabelLHourInitialMission
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel LabelInitialMission
	{
		[CompilerGenerated]
		get
		{
			return predicateServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			predicateServer = value;
		}
	}

	internal virtual DarkUICheckBox CB_AUTOSIMULATEt
	{
		[CompilerGenerated]
		get
		{
			return singletonServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			singletonServer = value;
		}
	}

	internal virtual DarkUIButton DarkUIButton2
	{
		[CompilerGenerated]
		get
		{
			return recordServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleModel;
			DarkUIButton darkUIButton = recordServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			recordServer = value;
			darkUIButton = recordServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton CB_AUTOSIMULATE
	{
		[CompilerGenerated]
		get
		{
			return _ExceptionServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleModel;
			DarkUIButton exceptionServer = _ExceptionServer;
			if (exceptionServer != null)
			{
				exceptionServer.Click -= value2;
			}
			_ExceptionServer = value;
			exceptionServer = _ExceptionServer;
			if (exceptionServer != null)
			{
				exceptionServer.Click += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel_4
	{
		[CompilerGenerated]
		get
		{
			return m_AttrServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttrServer = value;
		}
	}

	internal virtual DarkUIButton ButtonStartTriggerPlusMinusToggle
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveInterruptibleModel;
			DarkUIButton visitorServer = m_VisitorServer;
			if (visitorServer != null)
			{
				visitorServer.Click -= value2;
			}
			m_VisitorServer = value;
			visitorServer = m_VisitorServer;
			if (visitorServer != null)
			{
				visitorServer.Click += value2;
			}
		}
	}

	internal virtual DarkTextBox TB_FilterMissions
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterServer = value;
		}
	}

	internal virtual DarkLabel DarkLabel_5
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PrototypeServer = value;
		}
	}

	internal virtual DarkUIButton Button_PerformFilter
	{
		[CompilerGenerated]
		get
		{
			return comparatorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostInterruptibleModel;
			DarkUIButton darkUIButton = comparatorServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			comparatorServer = value;
			darkUIButton = comparatorServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIComboBox ComboSortOrder
	{
		[CompilerGenerated]
		get
		{
			return m_ItemServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterruptibleModel;
			DarkUIComboBox itemServer = m_ItemServer;
			if (itemServer != null)
			{
				itemServer.SelectedIndexChanged -= value2;
			}
			m_ItemServer = value;
			itemServer = m_ItemServer;
			if (itemServer != null)
			{
				itemServer.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel14")]
	internal virtual DarkLabel DarkLabel_6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkGroupBox DarkGroupBox1
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorServer = value;
		}
	}

	internal virtual DarkGroupBox DarkGroupBox2
	{
		[CompilerGenerated]
		get
		{
			return templateServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			templateServer = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return mappingServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mappingServer = value;
		}
	}

	internal virtual FlowLayoutPanel FlowLayoutPanel3
	{
		[CompilerGenerated]
		get
		{
			return m_MockServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockServer = value;
		}
	}

	internal virtual DarkUIButton Button_BulkAction_Delete
	{
		[CompilerGenerated]
		get
		{
			return m_TagServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintInterruptibleModel;
			DarkUIButton tagServer = m_TagServer;
			if (tagServer != null)
			{
				tagServer.Click -= value2;
			}
			m_TagServer = value;
			tagServer = m_TagServer;
			if (tagServer != null)
			{
				tagServer.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_UnassignAll
	{
		[CompilerGenerated]
		get
		{
			return fieldServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineInterruptibleModel;
			DarkUIButton darkUIButton = fieldServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			fieldServer = value;
			darkUIButton = fieldServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_Activate
	{
		[CompilerGenerated]
		get
		{
			return _QueueServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishInterruptibleModel;
			DarkUIButton queueServer = _QueueServer;
			if (queueServer != null)
			{
				queueServer.Click -= value2;
			}
			_QueueServer = value;
			queueServer = _QueueServer;
			if (queueServer != null)
			{
				queueServer.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_Desactivate
	{
		[CompilerGenerated]
		get
		{
			return regServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeInterruptibleModel;
			DarkUIButton darkUIButton = regServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			regServer = value;
			darkUIButton = regServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_BulkAction_UnassignAllQueud
	{
		[CompilerGenerated]
		get
		{
			return paramServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryInterruptibleModel;
			DarkUIButton darkUIButton = paramServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			paramServer = value;
			darkUIButton = paramServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_CheckAll
	{
		[CompilerGenerated]
		get
		{
			return pageServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapInterruptibleModel;
			DarkUIButton darkUIButton = pageServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			pageServer = value;
			darkUIButton = pageServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton Button_UnCheckAll
	{
		[CompilerGenerated]
		get
		{
			return rulesServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortInterruptibleModel;
			DarkUIButton darkUIButton = rulesServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			rulesServer = value;
			darkUIButton = rulesServer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkUIComboBox ComboBox_BulkPhase
	{
		[CompilerGenerated]
		get
		{
			return methodServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcInterruptibleModel;
			DarkUIComboBox darkUIComboBox = methodServer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectedIndexChanged -= value2;
			}
			methodServer = value;
			darkUIComboBox = methodServer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectedIndexChanged += value2;
			}
		}
	}

	public OperationPlanner()
	{
		base.Load += CloneInterruptibleModel;
		base.Shown += ResetInterruptibleModel;
		_ServiceServer = new BindingSource();
		m_CandidateServer = new Dictionary<Mission, MissionWrapper>();
		m_BaseServer = new Dictionary<Mission, Mission>();
		m_ParserServer = 0;
		_AlgoServer = 0;
		CustomizeInterruptibleModel();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && mapperPublisher != null)
			{
				mapperPublisher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CustomizeInterruptibleModel()
	{
		mapperPublisher = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Button_SerialEditor = new DarkUIButton();
		Button_LandingPlanner = new DarkUIButton();
		Button_MissionEditor = new DarkUIButton();
		MainDGV = new DataGridView();
		UiUpdateTimer = new Timer(mapperPublisher);
		ComboBox1 = new ComboBox();
		Button2 = new Button();
		DarkLabel_1 = new DarkLabel();
		LabelEstimatedTotalTime = new DarkLabel();
		DarkLabel_0 = new DarkLabel();
		LHourGroupBox = new DarkGroupBox();
		LabelLHourInitialMission = new DarkLabel();
		ComboBox_LHourMissionStart = new DarkUIComboBox();
		DatePicker_LHourDate = new DateTimePicker();
		DatePicker_LHourTime = new DateTimePicker();
		HHourGroupBox = new DarkGroupBox();
		LabelInitialMission = new DarkLabel();
		ComboBox_HHourMissionStart = new DarkUIComboBox();
		DatePicker_HHourDate = new DateTimePicker();
		DatePicker_HHourTime = new DateTimePicker();
		GP_EndMissionCriteria = new DarkGroupBox();
		DarkLabel5 = new DarkLabel();
		FlowLayoutPanel2 = new FlowLayoutPanel();
		Panel_DateTimeEndMissionCriteria = new Panel();
		TimeElpasedFulfillTrigger_DayCOunt = new NumericUpDown();
		DarkLabel8 = new DarkLabel();
		DateTimePicker1 = new DateTimePicker();
		ButtonResetTimer = new DarkUIButton();
		EndMissionTimeElapsedProgressBar = new DarkUIProgressBar();
		ComboMissionEndElapsed = new ComboBox();
		CB_DateTimeEndMission = new DarkCheckBox();
		LabelStatic_DateAndTimeEndMIssion = new DarkLabel();
		Panel_EndMissionLua = new Panel();
		EndMissionLuaDescription = new DarkLabel();
		DarkLabel_3 = new DarkLabel();
		ButtonConfirmScriptMissionComplete = new DarkUIButton();
		ComboBox_EndMissionLuaScript = new ComboBox();
		DarkLabel3 = new DarkLabel();
		CB_EndMissionLua = new DarkCheckBox();
		GP_MissionTriggers = new DarkGroupBox();
		PanelMissionTrigger = new FlowLayoutPanel();
		StartOfMission_DateTimeReachedPanel = new Panel();
		DarkLabel_4 = new DarkLabel();
		ButtonStartTriggerPlusMinusToggle = new DarkUIButton();
		ProgressBarHPlusTriggerStartTime = new DarkUIProgressBar();
		DateTimePicker_StartMission_Time_DaysCount = new NumericUpDown();
		DarkLabel7 = new DarkLabel();
		DateTimePicker_StartMission_Time = new DateTimePicker();
		Combobox_OperatorDateAndTime = new ComboBox();
		CB_StartOfMission_DateTimeReachedPanel = new DarkCheckBox();
		LabelStatic_DateAndTime = new DarkLabel();
		EndOfMission_UnitUnloadedPctPanel = new Panel();
		LV_MissionFinishedCriteriaPool = new DarkListView();
		Button_MissionFinishedCriteriaRemove = new DarkUIButton();
		DarkLabel2 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		LV_MissionFinishedCriteria_ToCheck = new DarkListView();
		Combobox_OperatorMissionFinished = new ComboBox();
		Button_MissionFinishedCriteriaAdd = new DarkUIButton();
		LabelStatic_MIssionFinished = new DarkLabel();
		CB_StartOfMission_UnitUnloadedPctPanel = new DarkCheckBox();
		Panel_LuaScriptCriteria = new Panel();
		StarLuaDescription = new DarkLabel();
		DarkLabel_2 = new DarkLabel();
		ButtonConfirmScript = new DarkUIButton();
		Combobox_OperatorLuaScript = new ComboBox();
		LabelStatic_LuaScript = new DarkLabel();
		CB_LuaScript = new DarkCheckBox();
		DarkLabel4 = new DarkLabel();
		DarkRichTextBox1 = new DarkRichTextBox();
		DarkLabel6 = new DarkLabel();
		CB_LockHhour_LHour = new CheckBox();
		DarkLabel9 = new DarkLabel();
		TB_FilterMissions = new DarkTextBox();
		DarkLabel_5 = new DarkLabel();
		DarkLabel_6 = new DarkLabel();
		DarkGroupBox1 = new DarkGroupBox();
		ButtonSImulate = new DarkUIButton();
		CB_AUTOSIMULATEt = new DarkUICheckBox();
		DarkGroupBox2 = new DarkGroupBox();
		Button_UnCheckAll = new DarkUIButton();
		Button_CheckAll = new DarkUIButton();
		Label1 = new Label();
		FlowLayoutPanel3 = new FlowLayoutPanel();
		Button_BulkAction_Delete = new DarkUIButton();
		Button_BulkAction_UnassignAll = new DarkUIButton();
		Button_BulkAction_UnassignAllQueud = new DarkUIButton();
		Button_BulkAction_Activate = new DarkUIButton();
		Button_BulkAction_Desactivate = new DarkUIButton();
		ComboBox_BulkPhase = new DarkUIComboBox();
		ComboSortOrder = new DarkUIComboBox();
		Button_PerformFilter = new DarkUIButton();
		DarkUITextBox1 = new DarkUITextBox();
		Darox1 = new DarkUITextBox();
		DarkUIButton2 = new DarkUIButton();
		CB_AUTOSIMULATE = new DarkUIButton();
		FlowLayoutPanel1.SuspendLayout();
		((ISupportInitialize)MainDGV).BeginInit();
		LHourGroupBox.SuspendLayout();
		HHourGroupBox.SuspendLayout();
		GP_EndMissionCriteria.SuspendLayout();
		FlowLayoutPanel2.SuspendLayout();
		Panel_DateTimeEndMissionCriteria.SuspendLayout();
		((ISupportInitialize)TimeElpasedFulfillTrigger_DayCOunt).BeginInit();
		Panel_EndMissionLua.SuspendLayout();
		GP_MissionTriggers.SuspendLayout();
		PanelMissionTrigger.SuspendLayout();
		StartOfMission_DateTimeReachedPanel.SuspendLayout();
		((ISupportInitialize)DateTimePicker_StartMission_Time_DaysCount).BeginInit();
		EndOfMission_UnitUnloadedPctPanel.SuspendLayout();
		Panel_LuaScriptCriteria.SuspendLayout();
		DarkGroupBox1.SuspendLayout();
		DarkGroupBox2.SuspendLayout();
		FlowLayoutPanel3.SuspendLayout();
		SuspendLayout();
		FlowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		FlowLayoutPanel1.Controls.Add(Button_SerialEditor);
		FlowLayoutPanel1.Controls.Add(Button_LandingPlanner);
		FlowLayoutPanel1.Controls.Add(Button_MissionEditor);
		FlowLayoutPanel1.Location = new Point(922, 5);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(326, 70);
		FlowLayoutPanel1.TabIndex = 52;
		Button_SerialEditor.BackColor = Color.Transparent;
		Button_SerialEditor.DialogResult = DialogResult.None;
		Button_SerialEditor.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button_SerialEditor.ForeColor = SystemColors.Control;
		Button_SerialEditor.Location = new Point(3, 3);
		Button_SerialEditor.Name = "Button_SerialEditor";
		Button_SerialEditor.RoundRadius = 0;
		Button_SerialEditor.Size = new Size(91, 31);
		Button_SerialEditor.TabIndex = 49;
		Button_SerialEditor.Text = "货物序列编辑";
		Button_LandingPlanner.BackColor = Color.Transparent;
		Button_LandingPlanner.DialogResult = DialogResult.None;
		Button_LandingPlanner.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button_LandingPlanner.ForeColor = SystemColors.Control;
		Button_LandingPlanner.Location = new Point(100, 3);
		Button_LandingPlanner.Name = "Button_LandingPlanner";
		Button_LandingPlanner.RoundRadius = 0;
		Button_LandingPlanner.Size = new Size(110, 32);
		Button_LandingPlanner.TabIndex = 50;
		Button_LandingPlanner.Text = "着陆规划";
		Button_MissionEditor.BackColor = Color.Transparent;
		Button_MissionEditor.DialogResult = DialogResult.None;
		Button_MissionEditor.Font = new Font("Microsoft Sans Serif", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button_MissionEditor.ForeColor = SystemColors.Control;
		Button_MissionEditor.Location = new Point(216, 3);
		Button_MissionEditor.Name = "Button_MissionEditor";
		Button_MissionEditor.RoundRadius = 0;
		Button_MissionEditor.Size = new Size(104, 32);
		Button_MissionEditor.TabIndex = 51;
		Button_MissionEditor.Text = "任务编辑";
		MainDGV.AllowUserToAddRows = false;
		MainDGV.AllowUserToDeleteRows = false;
		MainDGV.AllowUserToResizeColumns = false;
		MainDGV.AllowUserToResizeRows = false;
		MainDGV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		MainDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		MainDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		MainDGV.DefaultCellStyle = dataGridViewCellStyle2;
		MainDGV.EditMode = DataGridViewEditMode.EditOnEnter;
		MainDGV.Location = new Point(8, 106);
		MainDGV.MinimumSize = new Size(803, 514);
		MainDGV.MultiSelect = false;
		MainDGV.Name = "MainDGV";
		MainDGV.RowHeadersVisible = false;
		MainDGV.RowHeadersWidth = 62;
		MainDGV.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		MainDGV.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
		MainDGV.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
		MainDGV.Size = new Size(903, 552);
		MainDGV.TabIndex = 53;
		UiUpdateTimer.Interval = 250;
		ComboBox1.FormattingEnabled = true;
		ComboBox1.Items.AddRange(new object[2] { "OR", "AND" });
		ComboBox1.Location = new Point(226, 3);
		ComboBox1.Name = "ComboBox1";
		ComboBox1.Size = new Size(55, 21);
		ComboBox1.TabIndex = 36;
		Button2.BackColor = Color.Firebrick;
		Button2.FlatStyle = FlatStyle.Flat;
		Button2.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(128, 40);
		Button2.Name = "Button2";
		Button2.Size = new Size(71, 23);
		Button2.TabIndex = 69;
		Button2.Text = "立即开始！";
		Button2.UseVisualStyleBackColor = false;
		DarkLabel_1.AutoSize = true;
		DarkLabel_1.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel_1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_1.Location = new Point(6, 43);
		DarkLabel_1.Name = "LabelLPlus";
		DarkLabel_1.Size = new Size(106, 24);
		DarkLabel_1.TabIndex = 68;
		DarkLabel_1.Text = "L+ 00:00:00";
		LabelEstimatedTotalTime.AutoSize = true;
		LabelEstimatedTotalTime.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LabelEstimatedTotalTime.ForeColor = Color.FromArgb(220, 220, 220);
		LabelEstimatedTotalTime.Location = new Point(6, 69);
		LabelEstimatedTotalTime.Name = "LabelEstimatedTotalTime";
		LabelEstimatedTotalTime.Size = new Size(163, 24);
		LabelEstimatedTotalTime.TabIndex = 67;
		LabelEstimatedTotalTime.Text = "预估 无法预测";
		LabelEstimatedTotalTime.TextAlign = ContentAlignment.MiddleCenter;
		DarkLabel_0.AutoSize = true;
		DarkLabel_0.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel_0.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_0.Location = new Point(6, 17);
		DarkLabel_0.Name = "LabelHPlus";
		DarkLabel_0.Size = new Size(110, 24);
		DarkLabel_0.TabIndex = 66;
		DarkLabel_0.Text = "H+ 50:35:25";
		LHourGroupBox.Controls.Add(LabelLHourInitialMission);
		LHourGroupBox.Controls.Add(ComboBox_LHourMissionStart);
		LHourGroupBox.Controls.Add(DatePicker_LHourDate);
		LHourGroupBox.Controls.Add(DatePicker_LHourTime);
		LHourGroupBox.ForeColor = Color.FromArgb(220, 220, 220);
		LHourGroupBox.Location = new Point(266, 1);
		LHourGroupBox.Name = "LHourGroupBox";
		LHourGroupBox.Size = new Size(221, 68);
		LHourGroupBox.TabIndex = 65;
		LHourGroupBox.TabStop = false;
		LHourGroupBox.Text = "机动开始时间（祖鲁）";
		LabelLHourInitialMission.AutoSize = true;
		LabelLHourInitialMission.ForeColor = Color.FromArgb(220, 220, 220);
		LabelLHourInitialMission.Location = new Point(6, 47);
		LabelLHourInitialMission.Name = "LabelLHourInitialMission";
		LabelLHourInitialMission.Size = new Size(75, 13);
		LabelLHourInitialMission.TabIndex = 64;
		LabelLHourInitialMission.Text = "初始任务：";
		ComboBox_LHourMissionStart.BackColor = Color.Transparent;
		ComboBox_LHourMissionStart.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_LHourMissionStart.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_LHourMissionStart.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_LHourMissionStart.FormattingEnabled = true;
		ComboBox_LHourMissionStart.Location = new Point(87, 42);
		ComboBox_LHourMissionStart.Name = "ComboBox_LHourMissionStart";
		ComboBox_LHourMissionStart.Size = new Size(128, 21);
		ComboBox_LHourMissionStart.TabIndex = 62;
		DatePicker_LHourDate.CustomFormat = "d/MM/yyyy";
		DatePicker_LHourDate.Format = DateTimePickerFormat.Short;
		DatePicker_LHourDate.Location = new Point(6, 18);
		DatePicker_LHourDate.Name = "DatePicker_LHourDate";
		DatePicker_LHourDate.Size = new Size(116, 20);
		DatePicker_LHourDate.TabIndex = 62;
		DatePicker_LHourTime.CustomFormat = "HH:mm:ss";
		DatePicker_LHourTime.Format = DateTimePickerFormat.Custom;
		DatePicker_LHourTime.Location = new Point(128, 18);
		DatePicker_LHourTime.Name = "DatePicker_LHourTime";
		DatePicker_LHourTime.ShowUpDown = true;
		DatePicker_LHourTime.Size = new Size(87, 20);
		DatePicker_LHourTime.TabIndex = 63;
		HHourGroupBox.Controls.Add(LabelInitialMission);
		HHourGroupBox.Controls.Add(ComboBox_HHourMissionStart);
		HHourGroupBox.Controls.Add(DatePicker_HHourDate);
		HHourGroupBox.Controls.Add(DatePicker_HHourTime);
		HHourGroupBox.ForeColor = Color.FromArgb(220, 220, 220);
		HHourGroupBox.Location = new Point(13, 2);
		HHourGroupBox.Name = "HHourGroupBox";
		HHourGroupBox.Size = new Size(221, 68);
		HHourGroupBox.TabIndex = 64;
		HHourGroupBox.TabStop = false;
		HHourGroupBox.Text = "攻击开始时间（祖鲁）";
		LabelInitialMission.AutoSize = true;
		LabelInitialMission.ForeColor = Color.FromArgb(220, 220, 220);
		LabelInitialMission.Location = new Point(6, 45);
		LabelInitialMission.Name = "LabelInitialMission";
		LabelInitialMission.Size = new Size(75, 13);
		LabelInitialMission.TabIndex = 63;
		LabelInitialMission.Text = "初始任务：";
		ComboBox_HHourMissionStart.BackColor = Color.Transparent;
		ComboBox_HHourMissionStart.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_HHourMissionStart.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_HHourMissionStart.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_HHourMissionStart.FormattingEnabled = true;
		ComboBox_HHourMissionStart.Location = new Point(87, 41);
		ComboBox_HHourMissionStart.Name = "ComboBox_HHourMissionStart";
		ComboBox_HHourMissionStart.Size = new Size(129, 21);
		ComboBox_HHourMissionStart.TabIndex = 62;
		DatePicker_HHourDate.CustomFormat = "d/MM/yyyy";
		DatePicker_HHourDate.Format = DateTimePickerFormat.Short;
		DatePicker_HHourDate.Location = new Point(6, 18);
		DatePicker_HHourDate.Name = "DatePicker_HHourDate";
		DatePicker_HHourDate.Size = new Size(116, 20);
		DatePicker_HHourDate.TabIndex = 57;
		DatePicker_HHourTime.CustomFormat = "HH:mm:ss";
		DatePicker_HHourTime.Format = DateTimePickerFormat.Custom;
		DatePicker_HHourTime.Location = new Point(128, 18);
		DatePicker_HHourTime.Name = "DatePicker_HHourTime";
		DatePicker_HHourTime.ShowUpDown = true;
		DatePicker_HHourTime.Size = new Size(88, 20);
		DatePicker_HHourTime.TabIndex = 61;
		GP_EndMissionCriteria.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		GP_EndMissionCriteria.Controls.Add(DarkLabel5);
		GP_EndMissionCriteria.Controls.Add(FlowLayoutPanel2);
		GP_EndMissionCriteria.ForeColor = Color.FromArgb(220, 220, 220);
		GP_EndMissionCriteria.Location = new Point(922, 541);
		GP_EndMissionCriteria.Name = "GP_EndMissionCriteria";
		GP_EndMissionCriteria.Size = new Size(322, 158);
		GP_EndMissionCriteria.TabIndex = 56;
		GP_EndMissionCriteria.TabStop = false;
		DarkLabel5.AutoSize = true;
		DarkLabel5.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(6, -4);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(259, 20);
		DarkLabel5.TabIndex = 34;
		DarkLabel5.Text = "将任务标记为已完成的触发器";
		FlowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
		FlowLayoutPanel2.Controls.Add(Panel_DateTimeEndMissionCriteria);
		FlowLayoutPanel2.Controls.Add(Panel_EndMissionLua);
		FlowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
		FlowLayoutPanel2.Location = new Point(6, 19);
		FlowLayoutPanel2.Name = "FlowLayoutPanel2";
		FlowLayoutPanel2.Size = new Size(311, 133);
		FlowLayoutPanel2.TabIndex = 32;
		FlowLayoutPanel2.WrapContents = false;
		Panel_DateTimeEndMissionCriteria.BorderStyle = BorderStyle.FixedSingle;
		Panel_DateTimeEndMissionCriteria.Controls.Add(TimeElpasedFulfillTrigger_DayCOunt);
		Panel_DateTimeEndMissionCriteria.Controls.Add(DarkLabel8);
		Panel_DateTimeEndMissionCriteria.Controls.Add(DateTimePicker1);
		Panel_DateTimeEndMissionCriteria.Controls.Add(ButtonResetTimer);
		Panel_DateTimeEndMissionCriteria.Controls.Add(EndMissionTimeElapsedProgressBar);
		Panel_DateTimeEndMissionCriteria.Controls.Add(ComboMissionEndElapsed);
		Panel_DateTimeEndMissionCriteria.Controls.Add(CB_DateTimeEndMission);
		Panel_DateTimeEndMissionCriteria.Controls.Add(LabelStatic_DateAndTimeEndMIssion);
		Panel_DateTimeEndMissionCriteria.Location = new Point(3, 6);
		Panel_DateTimeEndMissionCriteria.Margin = new Padding(3, 6, 3, 6);
		Panel_DateTimeEndMissionCriteria.Name = "Panel_DateTimeEndMissionCriteria";
		Panel_DateTimeEndMissionCriteria.Size = new Size(304, 51);
		Panel_DateTimeEndMissionCriteria.TabIndex = 9;
		TimeElpasedFulfillTrigger_DayCOunt.Location = new Point(102, 4);
		TimeElpasedFulfillTrigger_DayCOunt.Name = "TimeElpasedFulfillTrigger_DayCOunt";
		TimeElpasedFulfillTrigger_DayCOunt.Size = new Size(35, 20);
		TimeElpasedFulfillTrigger_DayCOunt.TabIndex = 69;
		DarkLabel8.AutoSize = true;
		DarkLabel8.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel8.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel8.Location = new Point(138, 6);
		DarkLabel8.Name = "DarkLabel8";
		DarkLabel8.Size = new Size(34, 15);
		DarkLabel8.TabIndex = 68;
		DarkLabel8.Text = "天";
		DarkLabel8.TextAlign = ContentAlignment.MiddleLeft;
		DateTimePicker1.CustomFormat = "HH:mm:ss";
		DateTimePicker1.Format = DateTimePickerFormat.Custom;
		DateTimePicker1.Location = new Point(175, 5);
		DateTimePicker1.MaxDate = new DateTime(2000, 2, 1, 0, 0, 0, 0);
		DateTimePicker1.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		DateTimePicker1.Name = "DateTimePicker1";
		DateTimePicker1.ShowUpDown = true;
		DateTimePicker1.Size = new Size(66, 20);
		DateTimePicker1.TabIndex = 66;
		DateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		ButtonResetTimer.BackColor = Color.Transparent;
		ButtonResetTimer.DialogResult = DialogResult.None;
		ButtonResetTimer.ForeColor = SystemColors.Control;
		ButtonResetTimer.Location = new Point(244, 28);
		ButtonResetTimer.Name = "ButtonResetTimer";
		ButtonResetTimer.RoundRadius = 0;
		ButtonResetTimer.Size = new Size(55, 18);
		ButtonResetTimer.TabIndex = 39;
		ButtonResetTimer.Text = "重置";
		EndMissionTimeElapsedProgressBar.BackColor = Color.Transparent;
		EndMissionTimeElapsedProgressBar.CustomForeColor = Color.Transparent;
		EndMissionTimeElapsedProgressBar.Location = new Point(6, 28);
		EndMissionTimeElapsedProgressBar.Maximum = 100;
		EndMissionTimeElapsedProgressBar.Name = "EndMissionTimeElapsedProgressBar";
		EndMissionTimeElapsedProgressBar.ShowProgressLines = true;
		EndMissionTimeElapsedProgressBar.ShowProgressValue = true;
		EndMissionTimeElapsedProgressBar.ShowText = false;
		EndMissionTimeElapsedProgressBar.Size = new Size(235, 18);
		EndMissionTimeElapsedProgressBar.TabIndex = 40;
		EndMissionTimeElapsedProgressBar.Text = "DarkUIProgressBar1";
		EndMissionTimeElapsedProgressBar.Value = 0;
		ComboMissionEndElapsed.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboMissionEndElapsed.FormattingEnabled = true;
		ComboMissionEndElapsed.Items.AddRange(new object[2] { "OR", "AND" });
		ComboMissionEndElapsed.Location = new Point(244, 5);
		ComboMissionEndElapsed.Name = "ComboMissionEndElapsed";
		ComboMissionEndElapsed.Size = new Size(55, 21);
		ComboMissionEndElapsed.TabIndex = 35;
		CB_DateTimeEndMission.AutoSize = true;
		CB_DateTimeEndMission.Location = new Point(7, 7);
		CB_DateTimeEndMission.Name = "CB_DateTimeEndMission";
		CB_DateTimeEndMission.Size = new Size(15, 14);
		CB_DateTimeEndMission.TabIndex = 34;
		LabelStatic_DateAndTimeEndMIssion.AutoSize = true;
		LabelStatic_DateAndTimeEndMIssion.ForeColor = Color.FromArgb(220, 220, 220);
		LabelStatic_DateAndTimeEndMIssion.Location = new Point(21, 8);
		LabelStatic_DateAndTimeEndMIssion.Name = "LabelStatic_DateAndTimeEndMIssion";
		LabelStatic_DateAndTimeEndMIssion.Size = new Size(71, 13);
		LabelStatic_DateAndTimeEndMIssion.TabIndex = 32;
		LabelStatic_DateAndTimeEndMIssion.Text = "已流逝时间";
		Panel_EndMissionLua.BorderStyle = BorderStyle.FixedSingle;
		Panel_EndMissionLua.Controls.Add(EndMissionLuaDescription);
		Panel_EndMissionLua.Controls.Add(DarkLabel_3);
		Panel_EndMissionLua.Controls.Add(ButtonConfirmScriptMissionComplete);
		Panel_EndMissionLua.Controls.Add(ComboBox_EndMissionLuaScript);
		Panel_EndMissionLua.Controls.Add(DarkLabel3);
		Panel_EndMissionLua.Controls.Add(CB_EndMissionLua);
		Panel_EndMissionLua.Location = new Point(3, 69);
		Panel_EndMissionLua.Margin = new Padding(3, 6, 3, 6);
		Panel_EndMissionLua.Name = "Panel_EndMissionLua";
		Panel_EndMissionLua.Size = new Size(304, 60);
		Panel_EndMissionLua.TabIndex = 12;
		EndMissionLuaDescription.AutoSize = true;
		EndMissionLuaDescription.ForeColor = Color.FromArgb(220, 220, 220);
		EndMissionLuaDescription.Location = new Point(81, 33);
		EndMissionLuaDescription.Name = "EndMissionLuaDescription";
		EndMissionLuaDescription.Size = new Size(74, 13);
		EndMissionLuaDescription.TabIndex = 42;
		EndMissionLuaDescription.Text = " （最大25个字符）";
		DarkLabel_3.AutoSize = true;
		DarkLabel_3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_3.Location = new Point(8, 33);
		DarkLabel_3.Name = "DarkLabel12";
		DarkLabel_3.Size = new Size(66, 13);
		DarkLabel_3.TabIndex = 41;
		DarkLabel_3.Text = "描述：";
		ButtonConfirmScriptMissionComplete.BackColor = Color.Transparent;
		ButtonConfirmScriptMissionComplete.DialogResult = DialogResult.None;
		ButtonConfirmScriptMissionComplete.ForeColor = SystemColors.Control;
		ButtonConfirmScriptMissionComplete.Location = new Point(123, 4);
		ButtonConfirmScriptMissionComplete.Name = "ButtonConfirmScriptMissionComplete";
		ButtonConfirmScriptMissionComplete.RoundRadius = 0;
		ButtonConfirmScriptMissionComplete.Size = new Size(117, 22);
		ButtonConfirmScriptMissionComplete.TabIndex = 38;
		ButtonConfirmScriptMissionComplete.Text = "编辑脚本";
		ComboBox_EndMissionLuaScript.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_EndMissionLuaScript.FormattingEnabled = true;
		ComboBox_EndMissionLuaScript.Items.AddRange(new object[2] { "OR", "AND" });
		ComboBox_EndMissionLuaScript.Location = new Point(244, 4);
		ComboBox_EndMissionLuaScript.Name = "ComboBox_EndMissionLuaScript";
		ComboBox_EndMissionLuaScript.Size = new Size(55, 21);
		ComboBox_EndMissionLuaScript.TabIndex = 36;
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(22, 8);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(53, 13);
		DarkLabel3.TabIndex = 13;
		DarkLabel3.Text = "Lua脚本";
		CB_EndMissionLua.AutoSize = true;
		CB_EndMissionLua.Location = new Point(6, 7);
		CB_EndMissionLua.Name = "CB_EndMissionLua";
		CB_EndMissionLua.Size = new Size(15, 14);
		CB_EndMissionLua.TabIndex = 11;
		GP_MissionTriggers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GP_MissionTriggers.Controls.Add(PanelMissionTrigger);
		GP_MissionTriggers.Controls.Add(DarkLabel4);
		GP_MissionTriggers.ForeColor = Color.FromArgb(220, 220, 220);
		GP_MissionTriggers.Location = new Point(922, 81);
		GP_MissionTriggers.Name = "GP_MissionTriggers";
		GP_MissionTriggers.Size = new Size(322, 401);
		GP_MissionTriggers.TabIndex = 55;
		GP_MissionTriggers.TabStop = false;
		PanelMissionTrigger.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
		PanelMissionTrigger.Controls.Add(StartOfMission_DateTimeReachedPanel);
		PanelMissionTrigger.Controls.Add(EndOfMission_UnitUnloadedPctPanel);
		PanelMissionTrigger.Controls.Add(Panel_LuaScriptCriteria);
		PanelMissionTrigger.FlowDirection = FlowDirection.TopDown;
		PanelMissionTrigger.Location = new Point(6, 19);
		PanelMissionTrigger.Name = "PanelMissionTrigger";
		PanelMissionTrigger.Size = new Size(311, 376);
		PanelMissionTrigger.TabIndex = 32;
		PanelMissionTrigger.WrapContents = false;
		StartOfMission_DateTimeReachedPanel.BorderStyle = BorderStyle.FixedSingle;
		StartOfMission_DateTimeReachedPanel.Controls.Add(DarkLabel_4);
		StartOfMission_DateTimeReachedPanel.Controls.Add(ButtonStartTriggerPlusMinusToggle);
		StartOfMission_DateTimeReachedPanel.Controls.Add(ProgressBarHPlusTriggerStartTime);
		StartOfMission_DateTimeReachedPanel.Controls.Add(DateTimePicker_StartMission_Time_DaysCount);
		StartOfMission_DateTimeReachedPanel.Controls.Add(DarkLabel7);
		StartOfMission_DateTimeReachedPanel.Controls.Add(DateTimePicker_StartMission_Time);
		StartOfMission_DateTimeReachedPanel.Controls.Add(Combobox_OperatorDateAndTime);
		StartOfMission_DateTimeReachedPanel.Controls.Add(CB_StartOfMission_DateTimeReachedPanel);
		StartOfMission_DateTimeReachedPanel.Controls.Add(LabelStatic_DateAndTime);
		StartOfMission_DateTimeReachedPanel.Location = new Point(3, 6);
		StartOfMission_DateTimeReachedPanel.Margin = new Padding(3, 6, 3, 6);
		StartOfMission_DateTimeReachedPanel.Name = "StartOfMission_DateTimeReachedPanel";
		StartOfMission_DateTimeReachedPanel.Size = new Size(304, 60);
		StartOfMission_DateTimeReachedPanel.TabIndex = 9;
		DarkLabel_4.AutoSize = true;
		DarkLabel_4.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel_4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_4.Location = new Point(59, 9);
		DarkLabel_4.Name = "DarkLabel11";
		DarkLabel_4.Size = new Size(18, 17);
		DarkLabel_4.TabIndex = 70;
		DarkLabel_4.Text = "H";
		ButtonStartTriggerPlusMinusToggle.BackColor = Color.Transparent;
		ButtonStartTriggerPlusMinusToggle.DialogResult = DialogResult.None;
		ButtonStartTriggerPlusMinusToggle.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonStartTriggerPlusMinusToggle.ForeColor = SystemColors.Control;
		ButtonStartTriggerPlusMinusToggle.Location = new Point(77, 7);
		ButtonStartTriggerPlusMinusToggle.Name = "ButtonStartTriggerPlusMinusToggle";
		ButtonStartTriggerPlusMinusToggle.RoundRadius = 0;
		ButtonStartTriggerPlusMinusToggle.Size = new Size(20, 22);
		ButtonStartTriggerPlusMinusToggle.TabIndex = 69;
		ButtonStartTriggerPlusMinusToggle.Text = "+";
		ProgressBarHPlusTriggerStartTime.BackColor = Color.Transparent;
		ProgressBarHPlusTriggerStartTime.CustomForeColor = Color.Transparent;
		ProgressBarHPlusTriggerStartTime.Location = new Point(5, 35);
		ProgressBarHPlusTriggerStartTime.Maximum = 100;
		ProgressBarHPlusTriggerStartTime.Name = "ProgressBarHPlusTriggerStartTime";
		ProgressBarHPlusTriggerStartTime.ShowProgressLines = true;
		ProgressBarHPlusTriggerStartTime.ShowProgressValue = true;
		ProgressBarHPlusTriggerStartTime.ShowText = false;
		ProgressBarHPlusTriggerStartTime.Size = new Size(294, 18);
		ProgressBarHPlusTriggerStartTime.TabIndex = 68;
		ProgressBarHPlusTriggerStartTime.Text = "DarkUIProgressBar1";
		ProgressBarHPlusTriggerStartTime.Value = 0;
		DateTimePicker_StartMission_Time_DaysCount.Location = new Point(102, 8);
		DateTimePicker_StartMission_Time_DaysCount.Name = "DateTimePicker_StartMission_Time_DaysCount";
		DateTimePicker_StartMission_Time_DaysCount.Size = new Size(33, 20);
		DateTimePicker_StartMission_Time_DaysCount.TabIndex = 67;
		DarkLabel7.AutoSize = true;
		DarkLabel7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel7.Location = new Point(135, 10);
		DarkLabel7.Name = "DarkLabel7";
		DarkLabel7.Size = new Size(34, 15);
		DarkLabel7.TabIndex = 66;
		DarkLabel7.Text = "天";
		DarkLabel7.TextAlign = ContentAlignment.MiddleLeft;
		DateTimePicker_StartMission_Time.CustomFormat = "HH:mm:ss";
		DateTimePicker_StartMission_Time.Format = DateTimePickerFormat.Custom;
		DateTimePicker_StartMission_Time.Location = new Point(172, 8);
		DateTimePicker_StartMission_Time.MaxDate = new DateTime(2000, 2, 1, 0, 0, 0, 0);
		DateTimePicker_StartMission_Time.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		DateTimePicker_StartMission_Time.Name = "DateTimePicker_StartMission_Time";
		DateTimePicker_StartMission_Time.ShowUpDown = true;
		DateTimePicker_StartMission_Time.Size = new Size(66, 20);
		DateTimePicker_StartMission_Time.TabIndex = 65;
		DateTimePicker_StartMission_Time.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
		Combobox_OperatorDateAndTime.DropDownStyle = ComboBoxStyle.DropDownList;
		Combobox_OperatorDateAndTime.FormattingEnabled = true;
		Combobox_OperatorDateAndTime.Items.AddRange(new object[2] { "OR", "AND" });
		Combobox_OperatorDateAndTime.Location = new Point(244, 7);
		Combobox_OperatorDateAndTime.Name = "Combobox_OperatorDateAndTime";
		Combobox_OperatorDateAndTime.Size = new Size(55, 21);
		Combobox_OperatorDateAndTime.TabIndex = 37;
		CB_StartOfMission_DateTimeReachedPanel.AutoSize = true;
		CB_StartOfMission_DateTimeReachedPanel.Location = new Point(7, 10);
		CB_StartOfMission_DateTimeReachedPanel.Name = "CB_StartOfMission_DateTimeReachedPanel";
		CB_StartOfMission_DateTimeReachedPanel.Size = new Size(15, 14);
		CB_StartOfMission_DateTimeReachedPanel.TabIndex = 34;
		LabelStatic_DateAndTime.AutoSize = true;
		LabelStatic_DateAndTime.ForeColor = Color.FromArgb(220, 220, 220);
		LabelStatic_DateAndTime.Location = new Point(21, 11);
		LabelStatic_DateAndTime.Name = "LabelStatic_DateAndTime";
		LabelStatic_DateAndTime.Size = new Size(39, 13);
		LabelStatic_DateAndTime.TabIndex = 32;
		LabelStatic_DateAndTime.Text = "时间 >";
		EndOfMission_UnitUnloadedPctPanel.BackColor = Color.FromArgb(40, 43, 45);
		EndOfMission_UnitUnloadedPctPanel.BorderStyle = BorderStyle.FixedSingle;
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(LV_MissionFinishedCriteriaPool);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(Button_MissionFinishedCriteriaRemove);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(DarkLabel2);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(DarkLabel1);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(LV_MissionFinishedCriteria_ToCheck);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(Combobox_OperatorMissionFinished);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(Button_MissionFinishedCriteriaAdd);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(LabelStatic_MIssionFinished);
		EndOfMission_UnitUnloadedPctPanel.Controls.Add(CB_StartOfMission_UnitUnloadedPctPanel);
		EndOfMission_UnitUnloadedPctPanel.Location = new Point(3, 78);
		EndOfMission_UnitUnloadedPctPanel.Margin = new Padding(3, 6, 3, 6);
		EndOfMission_UnitUnloadedPctPanel.Name = "EndOfMission_UnitUnloadedPctPanel";
		EndOfMission_UnitUnloadedPctPanel.Size = new Size(304, 222);
		EndOfMission_UnitUnloadedPctPanel.TabIndex = 10;
		LV_MissionFinishedCriteriaPool.BackColor = Color.FromArgb(60, 63, 65);
		LV_MissionFinishedCriteriaPool.Location = new Point(164, 48);
		LV_MissionFinishedCriteriaPool.Name = "LV_MissionFinishedCriteriaPool";
		LV_MissionFinishedCriteriaPool.RelatedInfos = null;
		LV_MissionFinishedCriteriaPool.Size = new Size(135, 150);
		LV_MissionFinishedCriteriaPool.TabIndex = 40;
		Button_MissionFinishedCriteriaRemove.BackColor = Color.Transparent;
		Button_MissionFinishedCriteriaRemove.DialogResult = DialogResult.None;
		Button_MissionFinishedCriteriaRemove.ForeColor = SystemColors.Control;
		Button_MissionFinishedCriteriaRemove.Location = new Point(142, 121);
		Button_MissionFinishedCriteriaRemove.Name = "Button_MissionFinishedCriteriaRemove";
		Button_MissionFinishedCriteriaRemove.RoundRadius = 0;
		Button_MissionFinishedCriteriaRemove.Size = new Size(19, 40);
		Button_MissionFinishedCriteriaRemove.TabIndex = 43;
		Button_MissionFinishedCriteriaRemove.Text = ">";
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(178, 33);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(66, 13);
		DarkLabel2.TabIndex = 42;
		DarkLabel2.Text = "任务池";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(19, 32);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(92, 13);
		DarkLabel1.TabIndex = 41;
		DarkLabel1.Text = "需要检查的任务";
		LV_MissionFinishedCriteria_ToCheck.BackColor = Color.FromArgb(60, 63, 65);
		LV_MissionFinishedCriteria_ToCheck.Location = new Point(4, 48);
		LV_MissionFinishedCriteria_ToCheck.Name = "LV_MissionFinishedCriteria_ToCheck";
		LV_MissionFinishedCriteria_ToCheck.RelatedInfos = null;
		LV_MissionFinishedCriteria_ToCheck.Size = new Size(135, 150);
		LV_MissionFinishedCriteria_ToCheck.TabIndex = 39;
		Combobox_OperatorMissionFinished.DropDownStyle = ComboBoxStyle.DropDownList;
		Combobox_OperatorMissionFinished.FormattingEnabled = true;
		Combobox_OperatorMissionFinished.Items.AddRange(new object[2] { "OR", "AND" });
		Combobox_OperatorMissionFinished.Location = new Point(244, 3);
		Combobox_OperatorMissionFinished.Name = "Combobox_OperatorMissionFinished";
		Combobox_OperatorMissionFinished.Size = new Size(55, 21);
		Combobox_OperatorMissionFinished.TabIndex = 36;
		Button_MissionFinishedCriteriaAdd.BackColor = Color.Transparent;
		Button_MissionFinishedCriteriaAdd.DialogResult = DialogResult.None;
		Button_MissionFinishedCriteriaAdd.ForeColor = SystemColors.Control;
		Button_MissionFinishedCriteriaAdd.Location = new Point(142, 80);
		Button_MissionFinishedCriteriaAdd.Name = "Button_MissionFinishedCriteriaAdd";
		Button_MissionFinishedCriteriaAdd.RoundRadius = 0;
		Button_MissionFinishedCriteriaAdd.Size = new Size(19, 40);
		Button_MissionFinishedCriteriaAdd.TabIndex = 14;
		Button_MissionFinishedCriteriaAdd.Text = "<";
		LabelStatic_MIssionFinished.AutoSize = true;
		LabelStatic_MIssionFinished.ForeColor = Color.FromArgb(220, 220, 220);
		LabelStatic_MIssionFinished.Location = new Point(19, 8);
		LabelStatic_MIssionFinished.Name = "LabelStatic_MIssionFinished";
		LabelStatic_MIssionFinished.Size = new Size(96, 13);
		LabelStatic_MIssionFinished.TabIndex = 13;
		LabelStatic_MIssionFinished.Text = "已完成任务";
		CB_StartOfMission_UnitUnloadedPctPanel.AutoSize = true;
		CB_StartOfMission_UnitUnloadedPctPanel.Location = new Point(6, 7);
		CB_StartOfMission_UnitUnloadedPctPanel.Name = "CB_StartOfMission_UnitUnloadedPctPanel";
		CB_StartOfMission_UnitUnloadedPctPanel.Size = new Size(15, 14);
		CB_StartOfMission_UnitUnloadedPctPanel.TabIndex = 11;
		Panel_LuaScriptCriteria.BorderStyle = BorderStyle.FixedSingle;
		Panel_LuaScriptCriteria.Controls.Add(StarLuaDescription);
		Panel_LuaScriptCriteria.Controls.Add(DarkLabel_2);
		Panel_LuaScriptCriteria.Controls.Add(ButtonConfirmScript);
		Panel_LuaScriptCriteria.Controls.Add(Combobox_OperatorLuaScript);
		Panel_LuaScriptCriteria.Controls.Add(LabelStatic_LuaScript);
		Panel_LuaScriptCriteria.Controls.Add(CB_LuaScript);
		Panel_LuaScriptCriteria.Location = new Point(3, 312);
		Panel_LuaScriptCriteria.Margin = new Padding(3, 6, 3, 6);
		Panel_LuaScriptCriteria.Name = "Panel_LuaScriptCriteria";
		Panel_LuaScriptCriteria.Size = new Size(305, 61);
		Panel_LuaScriptCriteria.TabIndex = 11;
		StarLuaDescription.AutoSize = true;
		StarLuaDescription.ForeColor = Color.FromArgb(220, 220, 220);
		StarLuaDescription.Location = new Point(78, 31);
		StarLuaDescription.Name = "StarLuaDescription";
		StarLuaDescription.Size = new Size(74, 13);
		StarLuaDescription.TabIndex = 40;
		StarLuaDescription.Text = " （最大25个字符）";
		DarkLabel_2.AutoSize = true;
		DarkLabel_2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_2.Location = new Point(5, 31);
		DarkLabel_2.Name = "DarkLabel10";
		DarkLabel_2.Size = new Size(66, 13);
		DarkLabel_2.TabIndex = 39;
		DarkLabel_2.Text = "描述：";
		ButtonConfirmScript.BackColor = Color.Transparent;
		ButtonConfirmScript.DialogResult = DialogResult.None;
		ButtonConfirmScript.ForeColor = SystemColors.Control;
		ButtonConfirmScript.Location = new Point(121, 3);
		ButtonConfirmScript.Name = "ButtonConfirmScript";
		ButtonConfirmScript.RoundRadius = 0;
		ButtonConfirmScript.Size = new Size(117, 21);
		ButtonConfirmScript.TabIndex = 38;
		ButtonConfirmScript.Text = "编辑脚本";
		Combobox_OperatorLuaScript.DropDownStyle = ComboBoxStyle.DropDownList;
		Combobox_OperatorLuaScript.FormattingEnabled = true;
		Combobox_OperatorLuaScript.Items.AddRange(new object[2] { "OR", "AND" });
		Combobox_OperatorLuaScript.Location = new Point(244, 3);
		Combobox_OperatorLuaScript.Name = "Combobox_OperatorLuaScript";
		Combobox_OperatorLuaScript.Size = new Size(55, 21);
		Combobox_OperatorLuaScript.TabIndex = 36;
		LabelStatic_LuaScript.AutoSize = true;
		LabelStatic_LuaScript.ForeColor = Color.FromArgb(220, 220, 220);
		LabelStatic_LuaScript.Location = new Point(23, 8);
		LabelStatic_LuaScript.Name = "LabelStatic_LuaScript";
		LabelStatic_LuaScript.Size = new Size(53, 13);
		LabelStatic_LuaScript.TabIndex = 13;
		LabelStatic_LuaScript.Text = "Lua脚本";
		CB_LuaScript.AutoSize = true;
		CB_LuaScript.Location = new Point(7, 7);
		CB_LuaScript.Name = "CB_LuaScript";
		CB_LuaScript.Size = new Size(15, 14);
		CB_LuaScript.TabIndex = 11;
		DarkLabel4.AutoSize = true;
		DarkLabel4.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(2, -3);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(180, 20);
		DarkLabel4.TabIndex = 33;
		DarkLabel4.Text = "触发任务执行的触发器";
		DarkRichTextBox1.BackColor = Color.FromArgb(60, 63, 65);
		DarkRichTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkRichTextBox1.Location = new Point(5, 27);
		DarkRichTextBox1.Name = "DarkRichTextBox1";
		DarkRichTextBox1.Size = new Size(276, 101);
		DarkRichTextBox1.TabIndex = 37;
		DarkRichTextBox1.Text = "";
		DarkLabel6.AutoSize = true;
		DarkLabel6.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel6.Location = new Point(537, 47);
		DarkLabel6.Name = "DarkLabel6";
		DarkLabel6.Size = new Size(93, 20);
		DarkLabel6.TabIndex = 68;
		DarkLabel6.Text = "L+ 00:00:00";
		CB_LockHhour_LHour.AutoSize = true;
		CB_LockHhour_LHour.Location = new Point(243, 33);
		CB_LockHhour_LHour.Name = "CB_LockHhour_LHour";
		CB_LockHhour_LHour.Size = new Size(15, 14);
		CB_LockHhour_LHour.TabIndex = 70;
		CB_LockHhour_LHour.UseVisualStyleBackColor = true;
		DarkLabel9.AutoSize = true;
		DarkLabel9.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkLabel9.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel9.Location = new Point(232, 30);
		DarkLabel9.Name = "DarkLabel9";
		DarkLabel9.Size = new Size(39, 18);
		DarkLabel9.TabIndex = 71;
		DarkLabel9.Text = "> >>";
		TB_FilterMissions.BackColor = Color.FromArgb(69, 73, 74);
		TB_FilterMissions.BorderStyle = BorderStyle.FixedSingle;
		TB_FilterMissions.ForeColor = Color.FromArgb(220, 220, 220);
		TB_FilterMissions.Location = new Point(45, 78);
		TB_FilterMissions.Name = "TB_FilterMissions";
		TB_FilterMissions.Size = new Size(155, 20);
		TB_FilterMissions.TabIndex = 73;
		DarkLabel_5.AutoSize = true;
		DarkLabel_5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_5.Location = new Point(10, 80);
		DarkLabel_5.Name = "DarkLabel13";
		DarkLabel_5.Size = new Size(29, 13);
		DarkLabel_5.TabIndex = 74;
		DarkLabel_5.Text = "过滤";
		DarkLabel_6.AutoSize = true;
		DarkLabel_6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_6.Location = new Point(242, 82);
		DarkLabel_6.Name = "DarkLabel14";
		DarkLabel_6.Size = new Size(53, 13);
		DarkLabel_6.TabIndex = 77;
		DarkLabel_6.Text = "排序顺序";
		DarkGroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox1.Controls.Add(DarkLabel_1);
		DarkGroupBox1.Controls.Add(DarkLabel_0);
		DarkGroupBox1.Controls.Add(LabelEstimatedTotalTime);
		DarkGroupBox1.Controls.Add(ButtonSImulate);
		DarkGroupBox1.Controls.Add(CB_AUTOSIMULATEt);
		DarkGroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox1.Location = new Point(493, 2);
		DarkGroupBox1.Name = "DarkGroupBox1";
		DarkGroupBox1.Size = new Size(418, 100);
		DarkGroupBox1.TabIndex = 78;
		DarkGroupBox1.TabStop = false;
		DarkGroupBox1.Text = "模拟";
		ButtonSImulate.BackColor = Color.Transparent;
		ButtonSImulate.DialogResult = DialogResult.None;
		ButtonSImulate.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonSImulate.ForeColor = SystemColors.Control;
		ButtonSImulate.Location = new Point(269, 10);
		ButtonSImulate.Name = "ButtonSImulate";
		ButtonSImulate.RoundRadius = 0;
		ButtonSImulate.Size = new Size(143, 32);
		ButtonSImulate.TabIndex = 69;
		ButtonSImulate.Text = "模拟";
		CB_AUTOSIMULATEt.BackColor = Color.Transparent;
		CB_AUTOSIMULATEt.Checked = false;
		CB_AUTOSIMULATEt.Cursor = Cursors.Hand;
		CB_AUTOSIMULATEt.ForeColor = Color.FromArgb(209, 209, 209);
		CB_AUTOSIMULATEt.Location = new Point(269, 48);
		CB_AUTOSIMULATEt.Name = "CB_AUTOSIMULATEt";
		CB_AUTOSIMULATEt.Size = new Size(101, 18);
		CB_AUTOSIMULATEt.TabIndex = 72;
		CB_AUTOSIMULATEt.Text = " 自动刷新";
		DarkGroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox2.Controls.Add(Button_UnCheckAll);
		DarkGroupBox2.Controls.Add(Button_CheckAll);
		DarkGroupBox2.Controls.Add(Label1);
		DarkGroupBox2.Controls.Add(FlowLayoutPanel3);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(8, 649);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(903, 57);
		DarkGroupBox2.TabIndex = 79;
		DarkGroupBox2.TabStop = false;
		DarkGroupBox2.Text = "批处理";
		Button_UnCheckAll.BackColor = Color.Transparent;
		Button_UnCheckAll.DialogResult = DialogResult.None;
		Button_UnCheckAll.ForeColor = SystemColors.Control;
		Button_UnCheckAll.Location = new Point(6, 34);
		Button_UnCheckAll.Name = "Button_UnCheckAll";
		Button_UnCheckAll.RoundRadius = 0;
		Button_UnCheckAll.Size = new Size(77, 19);
		Button_UnCheckAll.TabIndex = 81;
		Button_UnCheckAll.Text = "全部取消勾选";
		Button_CheckAll.BackColor = Color.Transparent;
		Button_CheckAll.DialogResult = DialogResult.None;
		Button_CheckAll.ForeColor = SystemColors.Control;
		Button_CheckAll.Location = new Point(6, 14);
		Button_CheckAll.Name = "Button_CheckAll";
		Button_CheckAll.RoundRadius = 0;
		Button_CheckAll.Size = new Size(77, 19);
		Button_CheckAll.TabIndex = 80;
		Button_CheckAll.Text = "全部勾选";
		Label1.AutoSize = true;
		Label1.Location = new Point(93, 26);
		Label1.Name = "Label1";
		Label1.Size = new Size(140, 13);
		Label1.TabIndex = 1;
		Label1.Text = "对于勾选任务 >";
		FlowLayoutPanel3.Controls.Add(Button_BulkAction_Delete);
		FlowLayoutPanel3.Controls.Add(Button_BulkAction_UnassignAll);
		FlowLayoutPanel3.Controls.Add(Button_BulkAction_UnassignAllQueud);
		FlowLayoutPanel3.Controls.Add(Button_BulkAction_Activate);
		FlowLayoutPanel3.Controls.Add(Button_BulkAction_Desactivate);
		FlowLayoutPanel3.Controls.Add(ComboBox_BulkPhase);
		FlowLayoutPanel3.Location = new Point(237, 14);
		FlowLayoutPanel3.Name = "FlowLayoutPanel3";
		FlowLayoutPanel3.Size = new Size(660, 35);
		FlowLayoutPanel3.TabIndex = 0;
		Button_BulkAction_Delete.BackColor = Color.Transparent;
		Button_BulkAction_Delete.DialogResult = DialogResult.None;
		Button_BulkAction_Delete.ForeColor = SystemColors.Control;
		Button_BulkAction_Delete.Location = new Point(3, 3);
		Button_BulkAction_Delete.Name = "Button_BulkAction_Delete";
		Button_BulkAction_Delete.RoundRadius = 0;
		Button_BulkAction_Delete.Size = new Size(75, 28);
		Button_BulkAction_Delete.TabIndex = 0;
		Button_BulkAction_Delete.Text = "删除";
		Button_BulkAction_UnassignAll.BackColor = Color.Transparent;
		Button_BulkAction_UnassignAll.DialogResult = DialogResult.None;
		Button_BulkAction_UnassignAll.ForeColor = SystemColors.Control;
		Button_BulkAction_UnassignAll.Location = new Point(84, 3);
		Button_BulkAction_UnassignAll.Name = "Button_BulkAction_UnassignAll";
		Button_BulkAction_UnassignAll.RoundRadius = 0;
		Button_BulkAction_UnassignAll.Size = new Size(114, 28);
		Button_BulkAction_UnassignAll.TabIndex = 1;
		Button_BulkAction_UnassignAll.Text = "取消分配所有单元";
		Button_BulkAction_UnassignAllQueud.BackColor = Color.Transparent;
		Button_BulkAction_UnassignAllQueud.DialogResult = DialogResult.None;
		Button_BulkAction_UnassignAllQueud.ForeColor = SystemColors.Control;
		Button_BulkAction_UnassignAllQueud.Location = new Point(204, 3);
		Button_BulkAction_UnassignAllQueud.Name = "Button_BulkAction_UnassignAllQueud";
		Button_BulkAction_UnassignAllQueud.RoundRadius = 0;
		Button_BulkAction_UnassignAllQueud.Size = new Size(161, 28);
		Button_BulkAction_UnassignAllQueud.TabIndex = 4;
		Button_BulkAction_UnassignAllQueud.Text = "取消分配所有队列中单元";
		Button_BulkAction_Activate.BackColor = Color.Transparent;
		Button_BulkAction_Activate.DialogResult = DialogResult.None;
		Button_BulkAction_Activate.ForeColor = SystemColors.Control;
		Button_BulkAction_Activate.Location = new Point(371, 3);
		Button_BulkAction_Activate.Name = "Button_BulkAction_Activate";
		Button_BulkAction_Activate.RoundRadius = 0;
		Button_BulkAction_Activate.Size = new Size(59, 28);
		Button_BulkAction_Activate.TabIndex = 2;
		Button_BulkAction_Activate.Text = "激活";
		Button_BulkAction_Desactivate.BackColor = Color.Transparent;
		Button_BulkAction_Desactivate.DialogResult = DialogResult.None;
		Button_BulkAction_Desactivate.ForeColor = SystemColors.Control;
		Button_BulkAction_Desactivate.Location = new Point(436, 3);
		Button_BulkAction_Desactivate.Name = "Button_BulkAction_Desactivate";
		Button_BulkAction_Desactivate.RoundRadius = 0;
		Button_BulkAction_Desactivate.Size = new Size(74, 28);
		Button_BulkAction_Desactivate.TabIndex = 3;
		Button_BulkAction_Desactivate.Text = "取消激活";
		ComboBox_BulkPhase.BackColor = Color.Transparent;
		ComboBox_BulkPhase.DrawMode = DrawMode.OwnerDrawFixed;
		ComboBox_BulkPhase.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboBox_BulkPhase.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboBox_BulkPhase.FormattingEnabled = true;
		ComboBox_BulkPhase.Items.AddRange(new object[3] { "已完成", "等待触发器", "已触发" });
		ComboBox_BulkPhase.Location = new Point(516, 7);
		ComboBox_BulkPhase.Margin = new Padding(3, 7, 3, 3);
		ComboBox_BulkPhase.Name = "ComboBox_BulkPhase";
		ComboBox_BulkPhase.Size = new Size(121, 21);
		ComboBox_BulkPhase.TabIndex = 5;
		ComboSortOrder.BackColor = Color.Transparent;
		ComboSortOrder.DrawMode = DrawMode.OwnerDrawFixed;
		ComboSortOrder.DropDownStyle = ComboBoxStyle.DropDownList;
		ComboSortOrder.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		ComboSortOrder.FormattingEnabled = true;
		ComboSortOrder.Location = new Point(301, 77);
		ComboSortOrder.Name = "ComboSortOrder";
		ComboSortOrder.Size = new Size(186, 21);
		ComboSortOrder.TabIndex = 76;
		Button_PerformFilter.BackColor = Color.Transparent;
		Button_PerformFilter.DialogResult = DialogResult.None;
		Button_PerformFilter.ForeColor = SystemColors.Control;
		Button_PerformFilter.Location = new Point(206, 78);
		Button_PerformFilter.Name = "Button_PerformFilter";
		Button_PerformFilter.RoundRadius = 0;
		Button_PerformFilter.Size = new Size(28, 20);
		Button_PerformFilter.TabIndex = 75;
		Button_PerformFilter.Text = "开始";
		DarkUITextBox1.AutoCompleteCustomSource = null;
		DarkUITextBox1.AutoCompleteMode = AutoCompleteMode.None;
		DarkUITextBox1.AutoCompleteSource = AutoCompleteSource.None;
		DarkUITextBox1.BackColor = Color.Transparent;
		DarkUITextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		DarkUITextBox1.Image = null;
		DarkUITextBox1.Lines = null;
		DarkUITextBox1.Location = new Point(92, 4);
		DarkUITextBox1.MaxLength = 32767;
		DarkUITextBox1.Multiline = false;
		DarkUITextBox1.Name = "DarkUITextBox1";
		DarkUITextBox1.ReadOnly = false;
		DarkUITextBox1.ScrollBars = ScrollBars.None;
		DarkUITextBox1.SelectionStart = 0;
		DarkUITextBox1.Size = new Size(59, 21);
		DarkUITextBox1.TabIndex = 38;
		DarkUITextBox1.TextAlign = HorizontalAlignment.Left;
		DarkUITextBox1.UseSystemPasswordChar = false;
		DarkUITextBox1.WatermarkText = "Hours . . .";
		Darox1.AutoCompleteCustomSource = null;
		Darox1.AutoCompleteMode = AutoCompleteMode.None;
		Darox1.AutoCompleteSource = AutoCompleteSource.None;
		Darox1.BackColor = Color.Transparent;
		Darox1.ForeColor = Color.FromArgb(189, 189, 189);
		Darox1.Image = null;
		Darox1.Lines = null;
		Darox1.Location = new Point(92, 4);
		Darox1.MaxLength = 32767;
		Darox1.Multiline = false;
		Darox1.Name = "Darox1";
		Darox1.ReadOnly = false;
		Darox1.ScrollBars = ScrollBars.None;
		Darox1.SelectionStart = 0;
		Darox1.Size = new Size(59, 21);
		Darox1.TabIndex = 38;
		Darox1.TextAlign = HorizontalAlignment.Left;
		Darox1.UseSystemPasswordChar = false;
		Darox1.WatermarkText = "Hours . . .";
		DarkUIButton2.BackColor = Color.Transparent;
		DarkUIButton2.DialogResult = DialogResult.None;
		DarkUIButton2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DarkUIButton2.ForeColor = SystemColors.Control;
		DarkUIButton2.Location = new Point(632, 43);
		DarkUIButton2.Name = "DarkUIButton2";
		DarkUIButton2.RoundRadius = 0;
		DarkUIButton2.Size = new Size(75, 24);
		DarkUIButton2.TabIndex = 69;
		DarkUIButton2.Text = "模拟";
		CB_AUTOSIMULATE.BackColor = Color.Transparent;
		CB_AUTOSIMULATE.DialogResult = DialogResult.None;
		CB_AUTOSIMULATE.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
		CB_AUTOSIMULATE.ForeColor = SystemColors.Control;
		CB_AUTOSIMULATE.Location = new Point(632, 43);
		CB_AUTOSIMULATE.Name = "CB_AUTOSIMULATE";
		CB_AUTOSIMULATE.RoundRadius = 0;
		CB_AUTOSIMULATE.Size = new Size(75, 24);
		CB_AUTOSIMULATE.TabIndex = 69;
		CB_AUTOSIMULATE.Text = "模拟";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(1251, 711);
		base.Controls.Add(DarkGroupBox2);
		base.Controls.Add(DarkGroupBox1);
		base.Controls.Add(DarkLabel_6);
		base.Controls.Add(ComboSortOrder);
		base.Controls.Add(Button_PerformFilter);
		base.Controls.Add(DarkLabel_5);
		base.Controls.Add(TB_FilterMissions);
		base.Controls.Add(CB_LockHhour_LHour);
		base.Controls.Add(DarkLabel9);
		base.Controls.Add(LHourGroupBox);
		base.Controls.Add(HHourGroupBox);
		base.Controls.Add(GP_EndMissionCriteria);
		base.Controls.Add(GP_MissionTriggers);
		base.Controls.Add(MainDGV);
		base.Controls.Add(FlowLayoutPanel1);
		MinimumSize = new Size(1267, 750);
		base.Name = "OperationPlanner";
		base.ShowIcon = false;
		Text = "战术规划";
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)MainDGV).EndInit();
		LHourGroupBox.ResumeLayout(performLayout: false);
		LHourGroupBox.PerformLayout();
		HHourGroupBox.ResumeLayout(performLayout: false);
		HHourGroupBox.PerformLayout();
		GP_EndMissionCriteria.ResumeLayout(performLayout: false);
		GP_EndMissionCriteria.PerformLayout();
		FlowLayoutPanel2.ResumeLayout(performLayout: false);
		Panel_DateTimeEndMissionCriteria.ResumeLayout(performLayout: false);
		Panel_DateTimeEndMissionCriteria.PerformLayout();
		((ISupportInitialize)TimeElpasedFulfillTrigger_DayCOunt).EndInit();
		Panel_EndMissionLua.ResumeLayout(performLayout: false);
		Panel_EndMissionLua.PerformLayout();
		GP_MissionTriggers.ResumeLayout(performLayout: false);
		GP_MissionTriggers.PerformLayout();
		PanelMissionTrigger.ResumeLayout(performLayout: false);
		StartOfMission_DateTimeReachedPanel.ResumeLayout(performLayout: false);
		StartOfMission_DateTimeReachedPanel.PerformLayout();
		((ISupportInitialize)DateTimePicker_StartMission_Time_DaysCount).EndInit();
		EndOfMission_UnitUnloadedPctPanel.ResumeLayout(performLayout: false);
		EndOfMission_UnitUnloadedPctPanel.PerformLayout();
		Panel_LuaScriptCriteria.ResumeLayout(performLayout: false);
		Panel_LuaScriptCriteria.PerformLayout();
		DarkGroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox1.PerformLayout();
		DarkGroupBox2.ResumeLayout(performLayout: false);
		DarkGroupBox2.PerformLayout();
		FlowLayoutPanel3.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	private bool method_0()
	{
		return broadcasterServer;
	}

	[SpecialName]
	private void method_1(bool bool_0)
	{
		broadcasterServer = bool_0;
		ButtonSImulate.Enabled = !bool_0;
	}

	private void CloneInterruptibleModel(object sender, EventArgs e)
	{
		if (Client.CurrentSide == null)
		{
			DarkMessageBox.ShowError("No side defined, exiting operation planner", "No side defined");
			Close();
			return;
		}
		LabelEstimatedTotalTime.Text = "Est. " + new TimeSpan(0, 0, Client.CurrentSide.Operation.InitStub(Client.CurrentScenario, 60)).ToString("hh\\:mm\\:ss");
		base.TopMost = true;
		UiUpdateTimer.Start();
		ComboSortOrder.DisplayMember = "Label";
		ComboSortOrder.Items.Add(new ComboFilterWrapper(SortOrderType.EstimatedExecutionTime, "估算的执行时间"));
		ComboSortOrder.Items.Add(new ComboFilterWrapper(SortOrderType.Operation, "Description"));
		ComboSortOrder.Items.Add(new ComboFilterWrapper(SortOrderType.Name, "Name"));
		ComboSortOrder.Items.Add(new ComboFilterWrapper(SortOrderType.Phase, "Phase"));
		ComboSortOrder.SelectedIndexChanged -= RunInterruptibleModel;
		ComboSortOrder.SelectedIndex = 0;
		ComboSortOrder.SelectedIndexChanged += RunInterruptibleModel;
		ComboBox_BulkPhase.SelectedIndexChanged -= CalcInterruptibleModel;
		ComboBox_BulkPhase.SelectedIndex = 0;
		ComboBox_BulkPhase.SelectedIndexChanged += CalcInterruptibleModel;
		ComboBox_HHourMissionStart.ValueMember = "ID";
		ComboBox_HHourMissionStart.DisplayMember = "Label";
		ComboBox_LHourMissionStart.ValueMember = "ID";
		ComboBox_LHourMissionStart.DisplayMember = "Label";
		Side.MissionsChanged += DeleteInterruptibleModel;
		DeleteInterruptibleModel(Client.CurrentSide);
		DestroyInterruptibleModel();
		AddInterruptibleModel();
		SelectInterruptibleModel();
		LoginInterruptibleModel();
	}

	private void ConnectInterruptibleModel(bool bool_0 = true)
	{
		method_1(bool_0: true);
		if (bool_0)
		{
			Client.CurrentSide.Operation.InitStub(Client.CurrentScenario, 60);
			MainDGV.Refresh();
		}
	}

	private bool MoveInterruptibleModel(Mission mission_0, string string_0)
	{
		if (mission_0.Name.ToLower().Contains(string_0))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(mission_0.OperationName) && mission_0.OperationName.ToLower().Contains(string_0))
		{
			return true;
		}
		return false;
	}

	private void DeleteInterruptibleModel(Side side_0)
	{
		Dictionary<Mission, int> dictionary = new Dictionary<Mission, int>();
		Dictionary<Mission, int> dictionary2 = new Dictionary<Mission, int>();
		ComboBox_HHourMissionStart.Items.Clear();
		ComboBox_LHourMissionStart.Items.Clear();
		ComboBox_HHourMissionStart.Items.Add(new MissionHL_HourComboWrapper(null));
		ComboBox_LHourMissionStart.Items.Add(new MissionHL_HourComboWrapper(null));
		CB_LockHhour_LHour.Checked = Client.CurrentSide.Operation.H_LHourAreRelative;
		int num = 1;
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			ComboBox_HHourMissionStart.Items.Add(new MissionHL_HourComboWrapper(mission));
			ComboBox_LHourMissionStart.Items.Add(new MissionHL_HourComboWrapper(mission));
			dictionary.Add(mission, num);
			dictionary2.Add(mission, num);
			num++;
		}
		if (ComboBox_HHourMissionStart.Items.Count > 0)
		{
			if (Client.CurrentSide.Operation.HHourMission == null)
			{
				ComboBox_HHourMissionStart.SelectedIndex = 0;
			}
			else
			{
				ComboBox_HHourMissionStart.SelectedIndex = dictionary[Client.CurrentSide.Operation.HHourMission];
			}
			if (Client.CurrentSide.Operation.LHourMission == null)
			{
				ComboBox_LHourMissionStart.SelectedIndex = 0;
			}
			else
			{
				ComboBox_LHourMissionStart.SelectedIndex = dictionary2[Client.CurrentSide.Operation.LHourMission];
			}
		}
	}

	private void AddInterruptibleModel()
	{
		m_PolicyServer = true;
		_SystemServer = null;
		MainDGV.DataSource = null;
		MainDGV.Rows.Clear();
		MainDGV.Columns.Clear();
		_ServiceServer.Clear();
		MainDGV.Refresh();
		MainDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		MainDGV.AutoGenerateColumns = true;
		_ServiceServer.DataSource = typeof(MissionWrapper);
		List<Mission> list = new List<Mission>();
		SortOrderType type = ((ComboFilterWrapper)ComboSortOrder.SelectedItem).Type;
		if (1 == 0)
		{
		}
		List<Mission> list2 = type switch
		{
			SortOrderType.EstimatedExecutionTime => Client.CurrentSide.Missions.OrderBy((Mission x) => x.EstimatedExecutionTime).ToList(), 
			SortOrderType.Phase => Client.CurrentSide.Missions.OrderBy((Mission x) => x.GetPhase(Client.CurrentScenario, Client.CurrentSide)).ToList(), 
			SortOrderType.Operation => Client.CurrentSide.Missions.OrderBy((Mission x) => x.OperationName).ToList(), 
			SortOrderType.Name => Client.CurrentSide.Missions.OrderBy((Mission x) => x.Name).ToList(), 
			_ => Client.CurrentSide.Missions.OrderBy((Mission x) => x.EstimatedExecutionTime).ToList(), 
		};
		if (1 == 0)
		{
		}
		list = list2;
		m_CandidateServer.Clear();
		m_BaseServer.Clear();
		string string_ = TB_FilterMissions.Text.ToLower();
		foreach (Mission item in list)
		{
			if (!m_BaseServer.ContainsKey(item))
			{
				m_BaseServer.Add(item, item);
			}
			if (string.IsNullOrWhiteSpace(TB_FilterMissions.Text) || MoveInterruptibleModel(item, string_))
			{
				MissionWrapper value = new MissionWrapper(item);
				_ServiceServer.Add(value);
				if (!m_CandidateServer.ContainsKey(item))
				{
					m_CandidateServer.Add(item, value);
				}
			}
		}
		DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn();
		dataGridViewComboBoxColumn.DataPropertyName = "Phase";
		dataGridViewComboBoxColumn.Name = "Phase";
		dataGridViewComboBoxColumn.ValueMember = "ID";
		dataGridViewComboBoxColumn.DisplayMember = "Label";
		dataGridViewComboBoxColumn.Items.Add(new MissionPhaseComboWrapper(MissionPhase.Completed, "Satisfied"));
		dataGridViewComboBoxColumn.Items.Add(new MissionPhaseComboWrapper(MissionPhase.OnHold, "等待触发器"));
		dataGridViewComboBoxColumn.Items.Add(new MissionPhaseComboWrapper(MissionPhase.Active, "Triggered"));
		MainDGV.DataSource = _ServiceServer;
		MainDGV.AutoGenerateColumns = false;
		MainDGV.Columns.Add(dataGridViewComboBoxColumn);
		GetInterruptibleModel();
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = MainDGV.Columns.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				((DataGridViewColumn)enumerator2.Current).SortMode = DataGridViewColumnSortMode.Automatic;
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
		MainDGV.Refresh();
	}

	private void DestroyInterruptibleModel()
	{
		DatePicker_LHourTime.ValueChanged -= ExcludeInterruptibleModel;
		DatePicker_LHourDate.ValueChanged -= SetupInterruptibleModel;
		DatePicker_HHourTime.ValueChanged -= InvokeInterruptibleModel;
		DatePicker_HHourDate.ValueChanged -= PushInterruptibleModel;
		if (DateTime.Compare(Client.CurrentSide.Operation.HHour, DateTime.MinValue) == 0)
		{
			DatePicker_HHourDate.Value = Client.CurrentScenario.Time;
			DatePicker_HHourTime.Value = Client.CurrentScenario.Time;
		}
		else
		{
			DatePicker_HHourDate.Value = Client.CurrentSide.Operation.HHour;
			DatePicker_HHourTime.Value = Client.CurrentSide.Operation.HHour;
		}
		try
		{
			DatePicker_LHourTime.Value = Client.CurrentSide.Operation.LHour;
			DatePicker_LHourDate.Value = Client.CurrentSide.Operation.LHour;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DatePicker_LHourTime.Value = Client.CurrentScenario.Time;
			DatePicker_LHourDate.Value = Client.CurrentScenario.Time;
			ProjectData.ClearProjectError();
		}
		DatePicker_LHourTime.ValueChanged += ExcludeInterruptibleModel;
		DatePicker_LHourDate.ValueChanged += SetupInterruptibleModel;
		DatePicker_HHourTime.ValueChanged += InvokeInterruptibleModel;
		DatePicker_HHourDate.ValueChanged += PushInterruptibleModel;
		m_PolicyServer = false;
	}

	private void ComputeInterruptibleModel()
	{
		if (_SystemServer == null)
		{
			return;
		}
		Color backColor = Color.FromArgb(255, 43, 43, 43);
		Color backColor2 = Color.FromArgb(255, 43, 83, 43);
		Color backColor3 = Color.FromArgb(255, 83, 43, 43);
		if (_SystemServer.tagMap.MissionStartTrigger_Time_Enabled)
		{
			if (_SystemServer.tagMap.MissionStartTrigger_Time_LastResult)
			{
				StartOfMission_DateTimeReachedPanel.BackColor = backColor2;
			}
			else
			{
				StartOfMission_DateTimeReachedPanel.BackColor = backColor3;
			}
		}
		else
		{
			StartOfMission_DateTimeReachedPanel.BackColor = backColor;
		}
		if (_SystemServer.tagMap.MissionStartTrigger_MissionCompleted_Enabled)
		{
			if (_SystemServer.tagMap.MissionStartTrigger_MissionCompleted_LastResult)
			{
				EndOfMission_UnitUnloadedPctPanel.BackColor = backColor2;
			}
			else
			{
				EndOfMission_UnitUnloadedPctPanel.BackColor = backColor3;
			}
		}
		else
		{
			EndOfMission_UnitUnloadedPctPanel.BackColor = backColor;
		}
		if (_SystemServer.tagMap.MissionStartTrigger_LUA_Enabled)
		{
			if (_SystemServer.tagMap.MissionStartTrigger_LUA_LastResult)
			{
				Panel_LuaScriptCriteria.BackColor = backColor2;
			}
			else
			{
				Panel_LuaScriptCriteria.BackColor = backColor3;
			}
		}
		else
		{
			Panel_LuaScriptCriteria.BackColor = backColor;
		}
		if (_SystemServer.tagMap.MissionCompletedTrigger_LUA_Enabled)
		{
			if (_SystemServer.tagMap.MissionCompletedTrigger_LUA_LastResult)
			{
				Panel_EndMissionLua.BackColor = backColor2;
			}
			else
			{
				Panel_EndMissionLua.BackColor = backColor3;
			}
		}
		else
		{
			Panel_EndMissionLua.BackColor = backColor;
		}
		if (_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Enabled)
		{
			if (_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_LastResult)
			{
				Panel_DateTimeEndMissionCriteria.BackColor = backColor2;
			}
			else
			{
				Panel_DateTimeEndMissionCriteria.BackColor = backColor3;
			}
		}
		else
		{
			Panel_DateTimeEndMissionCriteria.BackColor = backColor;
		}
	}

	private void PatchInterruptibleModel()
	{
		DateTimePicker_StartMission_Time_DaysCount.ValueChanged -= TestInterruptibleModel;
		DateTimePicker_StartMission_Time.ValueChanged -= RemoveInterruptibleModel;
		DateTimePicker1.ValueChanged -= StopInterruptibleModel;
		TimeElpasedFulfillTrigger_DayCOunt.ValueChanged -= CancelInterruptibleModel;
		TimeSpan timeSpan = new TimeSpan(0, 0, Math.Abs((int)Math.Round(_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime / 86400f)));
		TimeSpan timeSpan2 = new TimeSpan(0, 0, Math.Abs((int)Math.Round(_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime)));
		DateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0).AddSeconds(timeSpan2.TotalSeconds - timeSpan.TotalSeconds);
		TimeElpasedFulfillTrigger_DayCOunt.Value = new decimal((int)Math.Round(timeSpan.TotalDays));
		timeSpan = new TimeSpan(0, 0, Math.Abs((int)Math.Round((double)_SystemServer.tagMap.MissionStartTrigger_Time / 86400.0)));
		timeSpan2 = new TimeSpan(0, 0, Math.Abs(_SystemServer.tagMap.MissionStartTrigger_Time));
		DateTimePicker_StartMission_Time.Value = new DateTime(2000, 1, 1, 0, 0, 0).AddSeconds(timeSpan2.TotalSeconds - timeSpan.TotalSeconds);
		DateTimePicker_StartMission_Time_DaysCount.Value = new decimal((int)Math.Round(timeSpan.TotalDays));
		if (_SystemServer.tagMap.MissionStartTrigger_Time < 0)
		{
			ButtonStartTriggerPlusMinusToggle.Text = "-";
		}
		else
		{
			ButtonStartTriggerPlusMinusToggle.Text = "+";
		}
		DateTimePicker_StartMission_Time_DaysCount.ValueChanged += TestInterruptibleModel;
		DateTimePicker_StartMission_Time.ValueChanged += RemoveInterruptibleModel;
		DateTimePicker1.ValueChanged += StopInterruptibleModel;
		TimeElpasedFulfillTrigger_DayCOunt.ValueChanged += CancelInterruptibleModel;
	}

	private void SelectInterruptibleModel()
	{
		if (Information.IsNothing(_SystemServer))
		{
			LogoutInterruptibleModel(bool_0: false);
			return;
		}
		LogoutInterruptibleModel(bool_0: true);
		CB_StartOfMission_DateTimeReachedPanel.Checked = _SystemServer.tagMap.MissionStartTrigger_Time_Enabled;
		CB_StartOfMission_UnitUnloadedPctPanel.Checked = _SystemServer.tagMap.MissionStartTrigger_MissionCompleted_Enabled;
		CB_LuaScript.Checked = _SystemServer.tagMap.MissionStartTrigger_LUA_Enabled;
		CB_DateTimeEndMission.Checked = _SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Enabled;
		CB_EndMissionLua.Checked = _SystemServer.tagMap.MissionCompletedTrigger_LUA_Enabled;
		PatchInterruptibleModel();
		ComboBox_EndMissionLuaScript.TextChanged -= VisitInterruptibleModel;
		Combobox_OperatorLuaScript.TextChanged -= PrepareInterruptibleModel;
		Combobox_OperatorMissionFinished.TextChanged -= RestartInterruptibleModel;
		ComboMissionEndElapsed.TextChanged -= ReflectInterruptibleModel;
		Combobox_OperatorDateAndTime.TextChanged -= InsertInterruptibleModel;
		if (_SystemServer.tagMap.MissionCompletedTrigger_LUA_Operator)
		{
			ComboBox_EndMissionLuaScript.SelectedIndex = 1;
		}
		else
		{
			ComboBox_EndMissionLuaScript.SelectedIndex = 0;
		}
		if (_SystemServer.tagMap.MissionStartTrigger_LUA_Operator)
		{
			Combobox_OperatorLuaScript.SelectedIndex = 1;
		}
		else
		{
			Combobox_OperatorLuaScript.SelectedIndex = 0;
		}
		if (_SystemServer.tagMap.MissionStartTrigger_MissionCompleted_Operator)
		{
			Combobox_OperatorMissionFinished.SelectedIndex = 1;
		}
		else
		{
			Combobox_OperatorMissionFinished.SelectedIndex = 0;
		}
		if (_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Operator)
		{
			ComboMissionEndElapsed.SelectedIndex = 1;
		}
		else
		{
			ComboMissionEndElapsed.SelectedIndex = 0;
		}
		if (_SystemServer.tagMap.MissionStartTrigger_Time_Operator)
		{
			Combobox_OperatorDateAndTime.SelectedIndex = 1;
		}
		else
		{
			Combobox_OperatorDateAndTime.SelectedIndex = 0;
		}
		ComboBox_EndMissionLuaScript.TextChanged += VisitInterruptibleModel;
		Combobox_OperatorLuaScript.TextChanged += PrepareInterruptibleModel;
		Combobox_OperatorMissionFinished.TextChanged += RestartInterruptibleModel;
		ComboMissionEndElapsed.TextChanged += ReflectInterruptibleModel;
		Combobox_OperatorDateAndTime.TextChanged += InsertInterruptibleModel;
		if (string.IsNullOrEmpty(_SystemServer.tagMap.MissionStartTrigger_LUADescription))
		{
			StarLuaDescription.Text = "(25 char max)";
		}
		else
		{
			StarLuaDescription.Text = _SystemServer.tagMap.MissionStartTrigger_LUADescription;
		}
		if (string.IsNullOrEmpty(_SystemServer.tagMap.MissionCompletedTrigger_LUADescription))
		{
			EndMissionLuaDescription.Text = "(25 char max)";
		}
		else
		{
			EndMissionLuaDescription.Text = _SystemServer.tagMap.MissionCompletedTrigger_LUADescription;
		}
		CallInterruptibleModel();
		ViewInterruptibleModel();
		ValidateInterruptibleModel();
		ComputeInterruptibleModel();
	}

	private void CallInterruptibleModel()
	{
		LV_MissionFinishedCriteria_ToCheck.Items.Clear();
		foreach (KeyValuePair<Mission, Mission> item in _SystemServer.tagMap.MissionStartTrigger_MissionCompleted)
		{
			DarkListItem darkListItem = new DarkListItem(item.Key.Name);
			darkListItem.Tag = item.Key;
			LV_MissionFinishedCriteria_ToCheck.Items.Add(darkListItem);
		}
		LV_MissionFinishedCriteriaPool.Items.Clear();
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (!_SystemServer.tagMap.MissionStartTrigger_MissionCompleted.ContainsKey(mission))
			{
				DarkListItem darkListItem2 = new DarkListItem(mission.Name);
				darkListItem2.Tag = mission;
				LV_MissionFinishedCriteriaPool.Items.Add(darkListItem2);
			}
		}
	}

	private void LogoutInterruptibleModel(bool bool_0)
	{
		GP_EndMissionCriteria.Visible = bool_0;
		GP_MissionTriggers.Visible = bool_0;
	}

	private void ViewInterruptibleModel(bool bool_0 = true)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			int value = 0;
			if (_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Current > 0f && _SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime > 0f)
			{
				value = (int)Math.Round(_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Current / _SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime * 100f);
			}
			EndMissionTimeElapsedProgressBar.Value = value;
		}
	}

	private void ValidateInterruptibleModel(bool bool_0 = true)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			int num = 0;
			int num2 = ((DateTime.Compare(Client.CurrentSide.Operation.HHourEffectiveStartTime, DateTime.MinValue) != 0) ? ((int)Math.Round((Client.CurrentScenario.Time - Client.CurrentSide.Operation.HHourEffectiveStartTime).TotalSeconds)) : 0);
			num = ((num2 != 0 && _SystemServer.tagMap.MissionStartTrigger_Time != 0) ? ((int)Math.Round((float)num2 / (float)_SystemServer.tagMap.MissionStartTrigger_Time * 100f)) : 0);
			if (num < 0)
			{
				ProgressBarHPlusTriggerStartTime.Value = 100;
			}
			else
			{
				ProgressBarHPlusTriggerStartTime.Value = num;
			}
		}
	}

	private void LoginInterruptibleModel(bool bool_0 = true)
	{
		if (!Client.CurrentSide.Operation.PhasesValidation || bool_0)
		{
			int num = MainDGV.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				MainDGV.Rows[i].Cells["Phase"].Value = ((MissionWrapper)_ServiceServer[i]).tagMap.GetPhase(Client.CurrentScenario, Client.CurrentSide);
			}
		}
	}

	private void GetInterruptibleModel()
	{
		DataGridView mainDGV = MainDGV;
		mainDGV.Columns["BulkSelection"].DisplayIndex = 0;
		mainDGV.Columns["BulkSelection"].HeaderText = "批量动作";
		mainDGV.Columns["BulkSelection"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		mainDGV.Columns["BulkSelection"].Width = 60;
		mainDGV.Columns["Name"].DisplayIndex = 1;
		mainDGV.Columns["Type"].DisplayIndex = 2;
		mainDGV.Columns["Type"].ReadOnly = true;
		mainDGV.Columns["Type"].Width = 110;
		mainDGV.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		mainDGV.Columns["Type"].ToolTipText = "Mission type as defined when creating a mission.";
		mainDGV.Columns["Type"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		mainDGV.Columns["OperationName"].DisplayIndex = 3;
		mainDGV.Columns["OperationName"].HeaderText = "描述";
		mainDGV.Columns["OperationName"].Width = 180;
		mainDGV.Columns["OperationName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		mainDGV.Columns["OperationName"].ToolTipText = "Information to organize missions in categories.";
		mainDGV.Columns["Priority"].DisplayIndex = 4;
		mainDGV.Columns["Priority"].Width = 60;
		mainDGV.Columns["Priority"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		mainDGV.Columns["Priority"].ToolTipText = "How important a mission is when assigning a mission to a multi-mission unit. Lowest value has highest priority.";
		mainDGV.Columns["Phase"].DisplayIndex = 5;
		mainDGV.Columns["Phase"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		mainDGV.Columns["Phase"].Width = 120;
		mainDGV.Columns["Phase"].ToolTipText = "The current phase of the mission.";
		mainDGV.Columns["ExecutionTime"].HeaderText = "执行时间";
		mainDGV.Columns["ExecutionTime"].DisplayIndex = 6;
		mainDGV.Columns["ExecutionTime"].ReadOnly = true;
		mainDGV.Columns["ExecutionTime"].Width = 120;
		mainDGV.Columns["ExecutionTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		mainDGV.Columns["ExecutionTime"].ToolTipText = "Estimated time for the mission to start relative to H hour.";
		mainDGV.Columns["ExecutionTime"].DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230, 230);
		mainDGV.Columns["Activation"].DisplayIndex = 7;
		mainDGV.Columns["Activation"].HeaderText = "已激活";
		mainDGV.Columns["Activation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		mainDGV.Columns["Activation"].Width = 60;
		m_ParserServer = MainDGV.Columns["BulkSelection"].Index;
		_AlgoServer = MainDGV.Columns["Activation"].Index;
	}

	private void WriteInterruptibleModel(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.UnitSerialEditor.Show();
	}

	private void NewInterruptibleModel(object sender, EventArgs e)
	{
		Client.MissionEditorWindow.Show();
		if (_SystemServer != null && _SystemServer.tagMap != null)
		{
			Client.MissionEditorWindow.SelectedMission = _SystemServer.tagMap;
		}
	}

	private void PushInterruptibleModel(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.HHour = new DateTime(DatePicker_HHourDate.Value.Year, DatePicker_HHourDate.Value.Month, DatePicker_HHourDate.Value.Day, DatePicker_HHourTime.Value.Hour, DatePicker_HHourTime.Value.Minute, DatePicker_HHourTime.Value.Second);
		method_1(bool_0: false);
		DestroyInterruptibleModel();
	}

	private void InvokeInterruptibleModel(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.HHour = new DateTime(DatePicker_HHourDate.Value.Year, DatePicker_HHourDate.Value.Month, DatePicker_HHourDate.Value.Day, DatePicker_HHourTime.Value.Hour, DatePicker_HHourTime.Value.Minute, DatePicker_HHourTime.Value.Second);
		method_1(bool_0: false);
		DestroyInterruptibleModel();
	}

	private void SetupInterruptibleModel(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.LHour = new DateTime(DatePicker_LHourDate.Value.Year, DatePicker_LHourDate.Value.Month, DatePicker_LHourDate.Value.Day, DatePicker_LHourTime.Value.Hour, DatePicker_LHourTime.Value.Minute, DatePicker_LHourTime.Value.Second);
		method_1(bool_0: false);
		DestroyInterruptibleModel();
	}

	private void ExcludeInterruptibleModel(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.LHour = new DateTime(DatePicker_LHourDate.Value.Year, DatePicker_LHourDate.Value.Month, DatePicker_LHourDate.Value.Day, DatePicker_LHourTime.Value.Hour, DatePicker_LHourTime.Value.Minute, DatePicker_LHourTime.Value.Second);
		method_1(bool_0: false);
		DestroyInterruptibleModel();
	}

	private void IncludeInterruptibleModel(object sender, EventArgs e)
	{
		Mission iD = ((MissionHL_HourComboWrapper)ComboBox_HHourMissionStart.SelectedItem).ID;
		Client.CurrentSide.Operation.HHourMission = iD;
		method_1(bool_0: false);
		DestroyInterruptibleModel();
	}

	private void SearchInterruptibleModel(object sender, EventArgs e)
	{
		Mission iD = ((MissionHL_HourComboWrapper)ComboBox_LHourMissionStart.SelectedItem).ID;
		Client.CurrentSide.Operation.LHourMission = iD;
		method_1(bool_0: false);
		DestroyInterruptibleModel();
	}

	private void EnableInterruptibleModel(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (MainDGV.EditingControl is ComboBox comboBox)
		{
			comboBox.SelectionChangeCommitted += ChangeInterruptibleModel;
		}
	}

	private void ChangeInterruptibleModel(object sender, EventArgs e)
	{
		MissionPhase iD = ((MissionPhaseComboWrapper)(sender as DataGridViewComboBoxEditingControl).SelectedItem).ID;
		((MissionWrapper)_ServiceServer[MainDGV.CurrentCell.RowIndex]).tagMap.SetPhase(Client.CurrentScenario, Client.CurrentSide, iD);
		method_1(bool_0: false);
	}

	public void RefreshMainTimerLabels()
	{
		Operation operation = Client.CurrentSide.Operation;
		string text = "H+";
		string text2 = "L+";
		text = ((DateTime.Compare(operation.HHourEffectiveStartTime, DateTime.MinValue) == 0) ? (text + " - - -") : (text + (operation.HHourEffectiveStartTime - Client.CurrentScenario.Time).ToString("hh\\:mm\\:ss")));
		text2 = ((DateTime.Compare(operation.LHourEffectiveStartTime, DateTime.MinValue) == 0) ? (text2 + " - - -") : (text2 + (operation.LHourEffectiveStartTime - Client.CurrentScenario.Time).ToString("hh\\:mm\\:ss")));
		if (Operators.CompareString(DarkLabel_0.Text, text, TextCompare: true) != 0)
		{
			DarkLabel_0.Text = text;
		}
		if (Operators.CompareString(DarkLabel_1.Text, text2, TextCompare: true) != 0)
		{
			DarkLabel_1.Text = text2;
		}
	}

	private void InitInterruptibleModel(object sender, EventArgs e)
	{
		UiRealtimeRefreshTick();
	}

	public void UiRealtimeRefreshTick(bool bool_0 = false)
	{
		if (!bool_0)
		{
			RefreshMainTimerLabels();
			LoginInterruptibleModel(bool_0: false);
		}
		MainDGV.Refresh();
		ValidateInterruptibleModel();
		ComputeInterruptibleModel();
		ViewInterruptibleModel();
		foreach (Mission mission in Client.CurrentSide.Missions)
		{
			if (!m_BaseServer.ContainsKey(mission))
			{
				AddInterruptibleModel();
				break;
			}
		}
		foreach (KeyValuePair<Mission, Mission> item in m_BaseServer)
		{
			if (!Client.CurrentSide.Missions.Contains(item.Key))
			{
				AddInterruptibleModel();
				break;
			}
		}
		if (!m_PolicyServer)
		{
			AddInterruptibleModel();
		}
		if (!method_0() && CB_AUTOSIMULATEt.Checked)
		{
			ConnectInterruptibleModel();
		}
		if (!printerServer && Client.CurrentSide.Operation.Boolean_1 && Client.CurrentSide.Operation.HHourMission != null)
		{
			ComboBox_HHourMissionStart.Visible = false;
			printerServer = true;
			LabelInitialMission.Text = "Initial Mission : " + Client.CurrentSide.Operation.HHourMission.Name;
		}
		if (!identifierServer && Client.CurrentSide.Operation.Boolean_0 && Client.CurrentSide.Operation.LHourMission != null)
		{
			ComboBox_LHourMissionStart.Visible = false;
			identifierServer = true;
			LabelLHourInitialMission.Text = "Initial Mission : " + Client.CurrentSide.Operation.LHourMission.Name;
		}
		UiUpdateTimer.Stop();
		UiUpdateTimer.Start();
	}

	private void CheckInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(MainDGV.CurrentCell))
		{
			_SystemServer = (MissionWrapper)_ServiceServer[MainDGV.CurrentCell.RowIndex];
			SelectInterruptibleModel();
		}
	}

	private void ConcatInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			_SystemServer.tagMap.MissionStartTrigger_Time_Enabled = CB_StartOfMission_DateTimeReachedPanel.Checked;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void InterruptInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			_SystemServer.tagMap.MissionStartTrigger_MissionCompleted_Enabled = CB_StartOfMission_UnitUnloadedPctPanel.Checked;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void RemoveInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			int num = (int)Math.Round((DateTimePicker_StartMission_Time.Value - new DateTime(2000, 1, 1, 0, 0, 0)).TotalSeconds) + (int)Math.Round(Convert.ToSingle(DateTimePicker_StartMission_Time_DaysCount.Value) * 86400f);
			if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", TextCompare: true) == 0)
			{
				num = -num;
			}
			_SystemServer.tagMap.MissionStartTrigger_Time = num;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
			PatchInterruptibleModel();
		}
	}

	private void FindInterruptibleModel(object sender, EventArgs e)
	{
		if (Information.IsNothing(_SystemServer))
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_MissionFinishedCriteriaPool.SelectedItems)
		{
			Mission mission = (Mission)selectedItem.Tag;
			if (!_SystemServer.tagMap.MissionStartTrigger_MissionCompleted.ContainsKey(mission))
			{
				_SystemServer.tagMap.MissionStartTrigger_MissionCompleted.Add(mission, mission);
			}
		}
		method_1(bool_0: false);
		CallInterruptibleModel();
		UiRealtimeRefreshTick(bool_0: true);
	}

	private void SetInterruptibleModel(object sender, EventArgs e)
	{
		if (Information.IsNothing(_SystemServer))
		{
			return;
		}
		foreach (DarkListItem selectedItem in LV_MissionFinishedCriteria_ToCheck.SelectedItems)
		{
			Mission key = (Mission)selectedItem.Tag;
			if (_SystemServer.tagMap.MissionStartTrigger_MissionCompleted.ContainsKey(key))
			{
				_SystemServer.tagMap.MissionStartTrigger_MissionCompleted.Remove(key);
			}
		}
		method_1(bool_0: false);
		CallInterruptibleModel();
		UiRealtimeRefreshTick(bool_0: true);
	}

	private void FillInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			_SystemServer.tagMap.MissionStartTrigger_LUA_Enabled = CB_LuaScript.Checked;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void CalculateInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			LuaEditorOperationPlanner luaEditorOperationPlanner = new LuaEditorOperationPlanner();
			luaEditorOperationPlanner.TheDescription = _SystemServer.tagMap.MissionStartTrigger_LUADescription;
			luaEditorOperationPlanner.TheScript = _SystemServer.tagMap.MissionStartTrigger_LUA;
			if (luaEditorOperationPlanner.ShowDialog() == DialogResult.OK)
			{
				StarLuaDescription.Text = luaEditorOperationPlanner.TheDescription;
				_SystemServer.tagMap.MissionStartTrigger_LUADescription = luaEditorOperationPlanner.TheDescription;
				_SystemServer.tagMap.MissionStartTrigger_LUA = luaEditorOperationPlanner.TheScript;
			}
			method_1(bool_0: false);
		}
	}

	private void PopInterruptibleModel(object sender, EventArgs e)
	{
		if (!ButtonConfirmScript.Enabled)
		{
			ButtonConfirmScript.Enabled = true;
		}
		method_1(bool_0: false);
		UiRealtimeRefreshTick(bool_0: true);
	}

	private void InstantiateInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Enabled = CB_DateTimeEndMission.Checked;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void CreateInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			_SystemServer.tagMap.MissionCompletedTrigger_LUA_Enabled = CB_EndMissionLua.Checked;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void CompareInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			LuaEditorOperationPlanner luaEditorOperationPlanner = new LuaEditorOperationPlanner();
			luaEditorOperationPlanner.TheDescription = _SystemServer.tagMap.MissionCompletedTrigger_LUADescription;
			luaEditorOperationPlanner.TheScript = _SystemServer.tagMap.MissionCompletedTrigger_LUA;
			if (luaEditorOperationPlanner.ShowDialog() == DialogResult.OK)
			{
				EndMissionLuaDescription.Text = luaEditorOperationPlanner.TheDescription;
				_SystemServer.tagMap.MissionCompletedTrigger_LUADescription = luaEditorOperationPlanner.TheDescription;
				_SystemServer.tagMap.MissionCompletedTrigger_LUA = luaEditorOperationPlanner.TheScript;
			}
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void ReadInterruptibleModel(object sender, EventArgs e)
	{
		if (!ButtonConfirmScriptMissionComplete.Enabled)
		{
			ButtonConfirmScriptMissionComplete.Enabled = true;
		}
		method_1(bool_0: false);
		UiRealtimeRefreshTick(bool_0: true);
	}

	private void DisableInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Current = 0f;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void UpdateInterruptibleModel(object sender, EventArgs e)
	{
		method_1(bool_0: true);
		LabelEstimatedTotalTime.Text = "Est. " + new TimeSpan(0, 0, Client.CurrentSide.Operation.InitStub(Client.CurrentScenario, 60)).ToString("hh\\:mm\\:ss");
		AddInterruptibleModel();
	}

	private void InsertInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			if (Combobox_OperatorDateAndTime.SelectedIndex == 0)
			{
				_SystemServer.tagMap.MissionStartTrigger_Time_Operator = false;
			}
			else
			{
				_SystemServer.tagMap.MissionStartTrigger_Time_Operator = true;
			}
			method_1(bool_0: false);
		}
	}

	private void PrepareInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			if (Combobox_OperatorLuaScript.SelectedIndex == 0)
			{
				_SystemServer.tagMap.MissionStartTrigger_LUA_Operator = false;
			}
			else
			{
				_SystemServer.tagMap.MissionStartTrigger_LUA_Operator = true;
			}
			method_1(bool_0: false);
		}
	}

	private void ReflectInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			if (ComboMissionEndElapsed.SelectedIndex == 0)
			{
				_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Operator = false;
			}
			else
			{
				_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime_Operator = true;
			}
			method_1(bool_0: false);
		}
	}

	private void VisitInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			if (ComboBox_EndMissionLuaScript.SelectedIndex == 0)
			{
				_SystemServer.tagMap.MissionCompletedTrigger_LUA_Operator = false;
			}
			else
			{
				_SystemServer.tagMap.MissionCompletedTrigger_LUA_Operator = true;
			}
			method_1(bool_0: false);
		}
	}

	private void RestartInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			if (Combobox_OperatorMissionFinished.SelectedIndex == 0)
			{
				_SystemServer.tagMap.MissionStartTrigger_MissionCompleted_Operator = false;
			}
			else
			{
				_SystemServer.tagMap.MissionStartTrigger_MissionCompleted_Operator = true;
			}
			method_1(bool_0: false);
		}
	}

	private void TestInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			int num = (int)Math.Round((DateTimePicker_StartMission_Time.Value - new DateTime(2000, 1, 1, 0, 0, 0)).TotalSeconds) + (int)Math.Round(Convert.ToSingle(DateTimePicker_StartMission_Time_DaysCount.Value) * 86400f);
			if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", TextCompare: true) == 0)
			{
				num = -num;
			}
			if (num < 0)
			{
				DateTime.Compare(Client.CurrentSide.Operation.HHour.AddSeconds(num), Client.CurrentScenario.Time);
			}
			_SystemServer.tagMap.MissionStartTrigger_Time = num;
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void StopInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			TimeSpan timeSpan = DateTimePicker1.Value - new DateTime(2000, 1, 1, 0, 0, 0);
			_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime = (int)Math.Round(timeSpan.TotalSeconds) + (int)Math.Round(Convert.ToSingle(TimeElpasedFulfillTrigger_DayCOunt.Value) * 86400f);
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void CancelInterruptibleModel(object sender, EventArgs e)
	{
		if (!Information.IsNothing(_SystemServer))
		{
			TimeSpan timeSpan = DateTimePicker1.Value - new DateTime(2000, 1, 1, 0, 0, 0);
			_SystemServer.tagMap.MissionCompletedTrigger_ElapsedTime = (int)Math.Round(timeSpan.TotalSeconds) + (int)Math.Round(Convert.ToSingle(TimeElpasedFulfillTrigger_DayCOunt.Value) * 86400f);
			method_1(bool_0: false);
			UiRealtimeRefreshTick(bool_0: true);
		}
	}

	private void VerifyInterruptibleModel(object sender, EventArgs e)
	{
		Client.CurrentSide.Operation.H_LHourAreRelative = CB_LockHhour_LHour.Checked;
		method_1(bool_0: false);
	}

	private void ListInterruptibleModel(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.LandingPlanner.Show();
	}

	private void ResolveInterruptibleModel(object sender, EventArgs e)
	{
		if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", TextCompare: true) == 0)
		{
			ButtonStartTriggerPlusMinusToggle.Text = "+";
		}
		else
		{
			ButtonStartTriggerPlusMinusToggle.Text = "-";
		}
		int num = (int)Math.Round((DateTimePicker_StartMission_Time.Value - new DateTime(2000, 1, 1, 0, 0, 0)).TotalSeconds) + (int)Math.Round(Convert.ToSingle(DateTimePicker_StartMission_Time_DaysCount.Value) * 86400f);
		if (Operators.CompareString(ButtonStartTriggerPlusMinusToggle.Text, "-", TextCompare: true) == 0)
		{
			num = -num;
		}
		_SystemServer.tagMap.MissionStartTrigger_Time = num;
		PatchInterruptibleModel();
		ButtonStartTriggerPlusMinusToggle.Refresh();
		method_1(bool_0: false);
	}

	private void PostInterruptibleModel(object sender, EventArgs e)
	{
		AddInterruptibleModel();
	}

	private void RunInterruptibleModel(object sender, EventArgs e)
	{
		AddInterruptibleModel();
	}

	private void StartInterruptibleModel(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == _AlgoServer || e.ColumnIndex == m_ParserServer)
		{
			MainDGV.EndEdit();
		}
	}

	private void AssetInterruptibleModel(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == _AlgoServer || e.ColumnIndex == m_ParserServer)
		{
			MainDGV.EndEdit();
		}
	}

	private void PrintInterruptibleModel(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in m_CandidateServer.ToList())
		{
			if (item.Key.MarkedForBulkEdition && Client.WarnAboutDeletedMissionDependencies(item.Key) != DialogResult.No)
			{
				Mission key = item.Key;
				Scenario scenario_ = Client.CurrentScenario;
				Side side_ = Client.CurrentSide;
				key.DeleteMission(ref scenario_, ref side_);
				Client.CurrentSide = side_;
			}
		}
		AddInterruptibleModel();
	}

	private void DefineInterruptibleModel(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item3 in m_CandidateServer.ToList())
		{
			if (!item3.Key.MarkedForBulkEdition)
			{
				continue;
			}
			foreach (ActiveUnit item2 in Client.CurrentScenario.ActiveUnits.Values.ToList())
			{
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				item2.Set_AssignedMissionOrPackage(null, bool_0: true, bool_1: true, ref missionAssignmentAttemptResult_);
			}
		}
		AddInterruptibleModel();
	}

	private void PublishInterruptibleModel(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in m_CandidateServer.ToList())
		{
			if (item.Key.MarkedForBulkEdition)
			{
				item.Key.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Active);
			}
		}
		AddInterruptibleModel();
	}

	private void AwakeInterruptibleModel(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in m_CandidateServer.ToList())
		{
			if (item.Key.MarkedForBulkEdition)
			{
				item.Key.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
			}
		}
		AddInterruptibleModel();
	}

	private void QueryInterruptibleModel(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in m_CandidateServer.ToList())
		{
			if (!item.Key.MarkedForBulkEdition)
			{
				continue;
			}
			foreach (ActiveUnit item2 in Client.CurrentScenario.ActiveUnits.Values.ToList())
			{
				item2.UnassignMissionInQueue(item.Key);
			}
		}
		AddInterruptibleModel();
	}

	private void ResetInterruptibleModel(object sender, EventArgs e)
	{
		Button_SerialEditor.Visible = GameGeneral.LicenseTierContext != GameGeneral._ProLicenseTier.None;
		Button_LandingPlanner.Visible = GameGeneral.LicenseTierContext != GameGeneral._ProLicenseTier.None;
	}

	private void MapInterruptibleModel(object sender, EventArgs e)
	{
		if (MainDGV.Rows.Count > 0)
		{
			int num = MainDGV.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				MainDGV.Rows[i].Cells["BulkSelection"].Value = true;
			}
			MainDGV.Refresh();
		}
	}

	private void SortInterruptibleModel(object sender, EventArgs e)
	{
		if (MainDGV.Rows.Count > 0)
		{
			int num = MainDGV.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				MainDGV.Rows[i].Cells["BulkSelection"].Value = false;
			}
			MainDGV.Refresh();
		}
	}

	private void CalcInterruptibleModel(object sender, EventArgs e)
	{
		foreach (KeyValuePair<Mission, MissionWrapper> item in m_CandidateServer.ToList())
		{
			if (item.Key.MarkedForBulkEdition)
			{
				switch (ComboBox_BulkPhase.SelectedIndex)
				{
				case 0:
					item.Key.SetPhase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Completed);
					break;
				case 1:
					item.Key.SetPhase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.OnHold);
					break;
				case 2:
					item.Key.SetPhase(Client.CurrentScenario, Client.CurrentSide, MissionPhase.Active);
					break;
				}
			}
		}
		AddInterruptibleModel();
	}
}
