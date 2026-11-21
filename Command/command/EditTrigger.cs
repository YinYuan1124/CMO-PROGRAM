using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditTrigger : DarkSecondaryFormBase
{
	public delegate void EventTriggersChangedEventHandler(Scenario theScen);

	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer _RepositoryDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel bridgeDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox m_InvocationDescriptor;

	[AccessedThroughProperty("Button_OK")]
	[CompilerGenerated]
	private DarkUIButton _ClassDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Cancel")]
	private DarkUIButton _RequestDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private DarkLabel m_ValueDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage m_TokenizerDescriptor;

	[AccessedThroughProperty("UnitFilter_UnitDestroyed")]
	[CompilerGenerated]
	private UnitFilter m_WriterDescriptor;

	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage watcherDescriptor;

	[AccessedThroughProperty("UnitFilter_UnitDamaged")]
	[CompilerGenerated]
	private UnitFilter m_ReponseDescriptor;

	[AccessedThroughProperty("CB_Points_ReachDirection")]
	[CompilerGenerated]
	private DarkUIComboBox m_DescriptorDescriptor;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	private DarkLabel poolDescriptor;

	[AccessedThroughProperty("NUD_Points")]
	[CompilerGenerated]
	private DarkNumericUpDown m_TaskDescriptor;

	[AccessedThroughProperty("CB_Points_Sides")]
	[CompilerGenerated]
	private DarkUIComboBox m_FilterDescriptor;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_TestsDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_InterpreterDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage4")]
	private TabPage containerDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("DTP_StartDate")]
	private DarkMaskedTextBox modelDescriptor;

	[AccessedThroughProperty("Button_SetTime")]
	[CompilerGenerated]
	private DarkUIButton _CustomerDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_DamagePercent")]
	private DarkNumericUpDown serializerDescriptor;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel m_RefDescriptor;

	[AccessedThroughProperty("UnitFilter_UnitInArea")]
	[CompilerGenerated]
	private UnitFilter m_CodeDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("AreaEditor_UnitInArea")]
	private AreaEditor connectionDescriptor;

	[AccessedThroughProperty("TB_Mins")]
	[CompilerGenerated]
	private DarkUITextBox statusDescriptor;

	[AccessedThroughProperty("Label9")]
	[CompilerGenerated]
	private DarkLabel m_TokenDescriptor;

	[AccessedThroughProperty("Label11")]
	[CompilerGenerated]
	private DarkLabel resolverDescriptor;

	[AccessedThroughProperty("TB_Secs")]
	[CompilerGenerated]
	private DarkUITextBox publisherDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage6")]
	private TabPage serverDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	private DarkGroupBox m_AdapterDescriptor;

	[AccessedThroughProperty("Label_UnitEntersArea_Latest")]
	[CompilerGenerated]
	private DarkLabel m_SchemaDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_UnitEntersArea_Earliest")]
	private DarkLabel utilsDescriptor;

	[AccessedThroughProperty("UnitFilter_UnitEntersArea")]
	[CompilerGenerated]
	private UnitFilter m_SingletonDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("DTP_EnterArea_ETOA_Date")]
	private DarkMaskedTextBox m_RecordDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("DTP_EnterArea_LTOA_Date")]
	private DarkMaskedTextBox exceptionDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_UnitEntersArea")]
	private DarkUIButton attrDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UnitEntersArea_ModifierNOT")]
	private DarkCheckBox exporterDescriptor;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private System.Windows.Forms.ToolTip m_ComparatorDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage7")]
	private TabPage m_SetterDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("DTP_LatestDate")]
	private DarkMaskedTextBox m_MappingDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label13")]
	private DarkLabel m_MockDescriptor;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_TagDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("DTP_EarliestTime")]
	private DarkMaskedTextBox queueDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("DTP_EarliestDate")]
	private DarkMaskedTextBox regDescriptor;

	[AccessedThroughProperty("TabPage8")]
	[CompilerGenerated]
	private TabPage paramDescriptor;

	[AccessedThroughProperty("UnitFilter_UnitDetected")]
	[CompilerGenerated]
	private UnitFilter m_PageDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UnitDetected_Sides")]
	private DarkUIComboBox _RulesDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label15")]
	private DarkLabel methodDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage9")]
	private TabPage serviceDescriptor;

	[AccessedThroughProperty("CB_RegularTimeInterval")]
	[CompilerGenerated]
	private DarkUIComboBox systemDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("Label17")]
	private DarkLabel m_CandidateDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MCL")]
	private DarkUIComboBox _BaseDescriptor;

	[AccessedThroughProperty("Label16")]
	[CompilerGenerated]
	private DarkLabel policyDescriptor;

	[AccessedThroughProperty("AreaEditor_DetectedArea")]
	[CompilerGenerated]
	private AreaEditor m_BroadcasterDescriptor;

	[AccessedThroughProperty("UnitFilter_BaseStatusCheck")]
	[CompilerGenerated]
	private UnitFilter _PrinterDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("RandomTimeValue")]
	private DarkLabel m_ParserDescriptor;

	[AccessedThroughProperty("BaseStatusCheck_Base")]
	[CompilerGenerated]
	private DarkLabel databaseDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_BaseStatusCheck_Base")]
	private DarkUIComboBox m_InterceptorDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_BaseStatusCheck_BaseSide")]
	private DarkUIComboBox m_MessageDescriptor;

	[AccessedThroughProperty("BaseStatusCheck_Unit_Label")]
	[CompilerGenerated]
	private DarkLabel m_ProductDescriptor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_BaseStatusCheck_Condition")]
	private DarkUIComboBox iteratorDescriptor;

	public EventTrigger theTrigger;

	public _FormAction Action;

	[CompilerGenerated]
	private static EventTriggersChangedEventHandler m_RoleDescriptor;

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return bridgeDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bridgeDescriptor = value;
		}
	}

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = CloneParam;
			DarkUITextBox invocationDescriptor = m_InvocationDescriptor;
			if (invocationDescriptor != null)
			{
				invocationDescriptor.TextChanged -= value2;
			}
			m_InvocationDescriptor = value;
			invocationDescriptor = m_InvocationDescriptor;
			if (invocationDescriptor != null)
			{
				invocationDescriptor.TextChanged += value2;
			}
		}
	}

	internal DarkUIButton Button_OK
	{
		[CompilerGenerated]
		get
		{
			return _ClassDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeParam;
			DarkUIButton classDescriptor = _ClassDescriptor;
			if (classDescriptor != null)
			{
				classDescriptor.Click -= value2;
			}
			_ClassDescriptor = value;
			classDescriptor = _ClassDescriptor;
			if (classDescriptor != null)
			{
				classDescriptor.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_Cancel
	{
		[CompilerGenerated]
		get
		{
			return _RequestDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountParam;
			DarkUIButton requestDescriptor = _RequestDescriptor;
			if (requestDescriptor != null)
			{
				requestDescriptor.Click -= value2;
			}
			_RequestDescriptor = value;
			requestDescriptor = _RequestDescriptor;
			if (requestDescriptor != null)
			{
				requestDescriptor.Click += value2;
			}
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return m_ValueDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValueDescriptor = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenizerDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TC_TriggerOptions")]
	internal DarkUITabControl TC_TriggerOptions
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal UnitFilter UnitFilter_UnitDestroyed
	{
		[CompilerGenerated]
		get
		{
			return m_WriterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WriterDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal TabPage TabPage2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return watcherDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			watcherDescriptor = value;
		}
	}

	internal UnitFilter UnitFilter_UnitDamaged
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReponseDescriptor = value;
		}
	}

	internal DarkUIComboBox CB_Points_ReachDirection
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveParam;
			DarkUIComboBox descriptorDescriptor = m_DescriptorDescriptor;
			if (descriptorDescriptor != null)
			{
				descriptorDescriptor.SelectedIndexChanged -= value2;
			}
			m_DescriptorDescriptor = value;
			descriptorDescriptor = m_DescriptorDescriptor;
			if (descriptorDescriptor != null)
			{
				descriptorDescriptor.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return poolDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			poolDescriptor = value;
		}
	}

	internal DarkNumericUpDown NUD_Points
	{
		[CompilerGenerated]
		get
		{
			return m_TaskDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteParam;
			DarkNumericUpDown taskDescriptor = m_TaskDescriptor;
			if (taskDescriptor != null)
			{
				taskDescriptor.TextChanged -= value2;
			}
			m_TaskDescriptor = value;
			taskDescriptor = m_TaskDescriptor;
			if (taskDescriptor != null)
			{
				taskDescriptor.TextChanged += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Points_Sides
	{
		[CompilerGenerated]
		get
		{
			return m_FilterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectParam;
			DarkUIComboBox filterDescriptor = m_FilterDescriptor;
			if (filterDescriptor != null)
			{
				filterDescriptor.SelectedIndexChanged -= value2;
			}
			m_FilterDescriptor = value;
			filterDescriptor = m_FilterDescriptor;
			if (filterDescriptor != null)
			{
				filterDescriptor.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_TestsDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TestsDescriptor = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterpreterDescriptor = value;
		}
	}

	internal TabPage TabPage4
	{
		[CompilerGenerated]
		get
		{
			return containerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			containerDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("DTP_StartTime")]
	internal DarkMaskedTextBox DTP_StartTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkMaskedTextBox DTP_StartDate
	{
		[CompilerGenerated]
		get
		{
			return modelDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_SetTime
	{
		[CompilerGenerated]
		get
		{
			return _CustomerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddParam;
			DarkUIButton customerDescriptor = _CustomerDescriptor;
			if (customerDescriptor != null)
			{
				customerDescriptor.Click -= value2;
			}
			_CustomerDescriptor = value;
			customerDescriptor = _CustomerDescriptor;
			if (customerDescriptor != null)
			{
				customerDescriptor.Click += value2;
			}
		}
	}

	internal DarkNumericUpDown NUD_DamagePercent
	{
		[CompilerGenerated]
		get
		{
			return serializerDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyParam;
			DarkNumericUpDown darkNumericUpDown = serializerDescriptor;
			if (darkNumericUpDown != null)
			{
				darkNumericUpDown.TextChanged -= value2;
			}
			serializerDescriptor = value;
			darkNumericUpDown = serializerDescriptor;
			if (darkNumericUpDown != null)
			{
				darkNumericUpDown.TextChanged += value2;
			}
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_RefDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RefDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TabPage5")]
	internal TabPage TabPage5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal UnitFilter UnitFilter_UnitInArea
	{
		[CompilerGenerated]
		get
		{
			return m_CodeDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeDescriptor = value;
		}
	}

	internal AreaEditor AreaEditor_UnitInArea
	{
		[CompilerGenerated]
		get
		{
			return connectionDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal DarkGroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox TB_Mins
	{
		[CompilerGenerated]
		get
		{
			return statusDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			statusDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TB_Hours")]
	internal DarkUITextBox TB_Hours
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label10")]
	internal DarkLabel Label10
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TB_Days")]
	internal DarkUITextBox TB_Days
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return m_TokenDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("Label12")]
	internal DarkLabel Label12
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label11
	{
		[CompilerGenerated]
		get
		{
			return resolverDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			resolverDescriptor = value;
		}
	}

	internal DarkUITextBox TB_Secs
	{
		[CompilerGenerated]
		get
		{
			return publisherDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherDescriptor = value;
		}
	}

	internal TabPage TabPage6
	{
		[CompilerGenerated]
		get
		{
			return serverDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverDescriptor = value;
		}
	}

	internal DarkGroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdapterDescriptor = value;
		}
	}

	internal DarkLabel Label_UnitEntersArea_Latest
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SchemaDescriptor = value;
		}
	}

	internal DarkLabel Label_UnitEntersArea_Earliest
	{
		[CompilerGenerated]
		get
		{
			return utilsDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			utilsDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("AreaEditor_UnitEntersArea")]
	internal AreaEditor AreaEditor_UnitEntersArea
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal UnitFilter UnitFilter_UnitEntersArea
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SingletonDescriptor = value;
		}
	}

	internal DarkMaskedTextBox DTP_EnterArea_ETOA_Date
	{
		[CompilerGenerated]
		get
		{
			return m_RecordDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RecordDescriptor = value;
		}
	}

	internal DarkMaskedTextBox DTP_EnterArea_LTOA_Date
	{
		[CompilerGenerated]
		get
		{
			return exceptionDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exceptionDescriptor = value;
		}
	}

	internal DarkUIButton Button_UnitEntersArea
	{
		[CompilerGenerated]
		get
		{
			return attrDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateParam;
			DarkUIButton darkUIButton = attrDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			attrDescriptor = value;
			darkUIButton = attrDescriptor;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DTP_EnterArea_LTOA_Time")]
	internal DarkMaskedTextBox DTP_EnterArea_LTOA_Time
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_UnitEntersArea_ModifierNOT
	{
		[CompilerGenerated]
		get
		{
			return exporterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("CB_UnitEntersArea_ModifierEXIT")]
	internal DarkCheckBox CB_UnitEntersArea_ModifierEXIT
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DTP_EnterArea_ETOA_Time")]
	internal DarkMaskedTextBox DTP_EnterArea_ETOA_Time
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage7
	{
		[CompilerGenerated]
		get
		{
			return m_SetterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SetterDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("Label14")]
	internal DarkLabel Label14
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DTP_LatestTime")]
	internal DarkMaskedTextBox DTP_LatestTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkMaskedTextBox DTP_LatestDate
	{
		[CompilerGenerated]
		get
		{
			return m_MappingDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingDescriptor = value;
		}
	}

	internal DarkLabel Label13
	{
		[CompilerGenerated]
		get
		{
			return m_MockDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockDescriptor = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_TagDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginParam;
			DarkUIButton tagDescriptor = m_TagDescriptor;
			if (tagDescriptor != null)
			{
				tagDescriptor.Click -= value2;
			}
			m_TagDescriptor = value;
			tagDescriptor = m_TagDescriptor;
			if (tagDescriptor != null)
			{
				tagDescriptor.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal DarkLabel Label8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkMaskedTextBox DTP_EarliestTime
	{
		[CompilerGenerated]
		get
		{
			return queueDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			queueDescriptor = value;
		}
	}

	internal DarkMaskedTextBox DTP_EarliestDate
	{
		[CompilerGenerated]
		get
		{
			return regDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regDescriptor = value;
		}
	}

	internal TabPage TabPage8
	{
		[CompilerGenerated]
		get
		{
			return paramDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramDescriptor = value;
		}
	}

	internal UnitFilter UnitFilter_UnitDetected
	{
		[CompilerGenerated]
		get
		{
			return m_PageDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageDescriptor = value;
		}
	}

	internal DarkUIComboBox CB_UnitDetected_Sides
	{
		[CompilerGenerated]
		get
		{
			return _RulesDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteParam;
			DarkUIComboBox rulesDescriptor = _RulesDescriptor;
			if (rulesDescriptor != null)
			{
				rulesDescriptor.SelectedIndexChanged -= value2;
			}
			_RulesDescriptor = value;
			rulesDescriptor = _RulesDescriptor;
			if (rulesDescriptor != null)
			{
				rulesDescriptor.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkLabel Label15
	{
		[CompilerGenerated]
		get
		{
			return methodDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodDescriptor = value;
		}
	}

	internal TabPage TabPage9
	{
		[CompilerGenerated]
		get
		{
			return serviceDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serviceDescriptor = value;
		}
	}

	internal DarkUIComboBox CB_RegularTimeInterval
	{
		[CompilerGenerated]
		get
		{
			return systemDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeParam;
			DarkUIComboBox darkUIComboBox = systemDescriptor;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			systemDescriptor = value;
			darkUIComboBox = systemDescriptor;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label17
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CandidateDescriptor = value;
		}
	}

	internal DarkUIComboBox CB_MCL
	{
		[CompilerGenerated]
		get
		{
			return _BaseDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushParam;
			DarkUIComboBox baseDescriptor = _BaseDescriptor;
			if (baseDescriptor != null)
			{
				baseDescriptor.SelectionChangeCommitted -= value2;
			}
			_BaseDescriptor = value;
			baseDescriptor = _BaseDescriptor;
			if (baseDescriptor != null)
			{
				baseDescriptor.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label16
	{
		[CompilerGenerated]
		get
		{
			return policyDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			policyDescriptor = value;
		}
	}

	internal AreaEditor AreaEditor_DetectedArea
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BroadcasterDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TabPage10")]
	internal TabPage TabPage_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal UnitFilter UnitFilter_BaseStatusCheck
	{
		[CompilerGenerated]
		get
		{
			return _PrinterDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeParam;
			UnitFilter printerDescriptor = _PrinterDescriptor;
			if (printerDescriptor != null)
			{
				printerDescriptor.Leave -= value2;
			}
			_PrinterDescriptor = value;
			printerDescriptor = _PrinterDescriptor;
			if (printerDescriptor != null)
			{
				printerDescriptor.Leave += value2;
			}
		}
	}

	internal DarkLabel RandomTimeValue
	{
		[CompilerGenerated]
		get
		{
			return m_ParserDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParserDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("TabPage99")]
	internal TabPage TabPage_1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel BaseStatusCheck_Base
	{
		[CompilerGenerated]
		get
		{
			return databaseDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			databaseDescriptor = value;
		}
	}

	internal DarkUIComboBox CB_BaseStatusCheck_Base
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorDescriptor = value;
		}
	}

	internal DarkUIComboBox CB_BaseStatusCheck_BaseSide
	{
		[CompilerGenerated]
		get
		{
			return m_MessageDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MessageDescriptor = value;
		}
	}

	internal DarkLabel BaseStatusCheck_Unit_Label
	{
		[CompilerGenerated]
		get
		{
			return m_ProductDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProductDescriptor = value;
		}
	}

	[field: AccessedThroughProperty("BaseStatusCheck_BaseSide")]
	internal DarkLabel BaseStatusCheck_BaseSide
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_BaseStatusCheck_Condition
	{
		[CompilerGenerated]
		get
		{
			return iteratorDescriptor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupParam;
			DarkUIComboBox darkUIComboBox = iteratorDescriptor;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			iteratorDescriptor = value;
			darkUIComboBox = iteratorDescriptor;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal DarkLabel DarkLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public static event EventTriggersChangedEventHandler EventTriggersChanged
	{
		[CompilerGenerated]
		add
		{
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler = m_RoleDescriptor;
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler2;
			do
			{
				eventTriggersChangedEventHandler2 = eventTriggersChangedEventHandler;
				EventTriggersChangedEventHandler value2 = (EventTriggersChangedEventHandler)Delegate.Combine(eventTriggersChangedEventHandler2, value);
				eventTriggersChangedEventHandler = Interlocked.CompareExchange(ref m_RoleDescriptor, value2, eventTriggersChangedEventHandler2);
			}
			while ((object)eventTriggersChangedEventHandler != eventTriggersChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler = m_RoleDescriptor;
			EventTriggersChangedEventHandler eventTriggersChangedEventHandler2;
			do
			{
				eventTriggersChangedEventHandler2 = eventTriggersChangedEventHandler;
				EventTriggersChangedEventHandler value2 = (EventTriggersChangedEventHandler)Delegate.Remove(eventTriggersChangedEventHandler2, value);
				eventTriggersChangedEventHandler = Interlocked.CompareExchange(ref m_RoleDescriptor, value2, eventTriggersChangedEventHandler2);
			}
			while ((object)eventTriggersChangedEventHandler != eventTriggersChangedEventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal System.Windows.Forms.ToolTip PreparePage()
	{
		return m_ComparatorDescriptor;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ReflectPage(System.Windows.Forms.ToolTip toolTip_0)
	{
		m_ComparatorDescriptor = toolTip_0;
	}

	public EditTrigger()
	{
		base.FormClosing += ManageReg;
		base.Load += RevertReg;
		base.KeyDown += GetParam;
		base.FormClosed += NewParam;
		RegisterReg();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _RepositoryDescriptor != null)
			{
				_RepositoryDescriptor.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RegisterReg()
	{
		_RepositoryDescriptor = new Container();
		Label2 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Button_OK = new DarkUIButton();
		Button_Cancel = new DarkUIButton();
		Label3 = new DarkLabel();
		TabPage1 = new TabPage();
		UnitFilter_UnitDestroyed = new UnitFilter();
		TC_TriggerOptions = new DarkUITabControl();
		TabPage2 = new TabPage();
		NUD_DamagePercent = new DarkNumericUpDown();
		Label7 = new DarkLabel();
		UnitFilter_UnitDamaged = new UnitFilter();
		TabPage3 = new TabPage();
		CB_Points_ReachDirection = new DarkUIComboBox();
		Label5 = new DarkLabel();
		NUD_Points = new DarkNumericUpDown();
		CB_Points_Sides = new DarkUIComboBox();
		Label4 = new DarkLabel();
		Label1 = new DarkLabel();
		TabPage4 = new TabPage();
		Button_SetTime = new DarkUIButton();
		Label6 = new DarkLabel();
		DTP_StartTime = new DarkMaskedTextBox();
		DTP_StartDate = new DarkMaskedTextBox();
		TabPage5 = new TabPage();
		GroupBox1 = new DarkGroupBox();
		Label12 = new DarkLabel();
		Label11 = new DarkLabel();
		TB_Secs = new DarkUITextBox();
		TB_Mins = new DarkUITextBox();
		TB_Hours = new DarkUITextBox();
		Label10 = new DarkLabel();
		TB_Days = new DarkUITextBox();
		Label9 = new DarkLabel();
		AreaEditor_UnitInArea = new AreaEditor();
		UnitFilter_UnitInArea = new UnitFilter();
		TabPage6 = new TabPage();
		CB_UnitEntersArea_ModifierNOT = new DarkCheckBox();
		CB_UnitEntersArea_ModifierEXIT = new DarkCheckBox();
		GroupBox2 = new DarkGroupBox();
		Button_UnitEntersArea = new DarkUIButton();
		DTP_EnterArea_LTOA_Time = new DarkMaskedTextBox();
		DTP_EnterArea_ETOA_Time = new DarkMaskedTextBox();
		DTP_EnterArea_LTOA_Date = new DarkMaskedTextBox();
		DTP_EnterArea_ETOA_Date = new DarkMaskedTextBox();
		Label_UnitEntersArea_Latest = new DarkLabel();
		Label_UnitEntersArea_Earliest = new DarkLabel();
		AreaEditor_UnitEntersArea = new AreaEditor();
		UnitFilter_UnitEntersArea = new UnitFilter();
		TabPage7 = new TabPage();
		RandomTimeValue = new DarkLabel();
		Label14 = new DarkLabel();
		DTP_LatestTime = new DarkMaskedTextBox();
		DTP_LatestDate = new DarkMaskedTextBox();
		Label13 = new DarkLabel();
		Button1 = new DarkUIButton();
		Label8 = new DarkLabel();
		DTP_EarliestTime = new DarkMaskedTextBox();
		DTP_EarliestDate = new DarkMaskedTextBox();
		TabPage8 = new TabPage();
		AreaEditor_DetectedArea = new AreaEditor();
		CB_MCL = new DarkUIComboBox();
		Label16 = new DarkLabel();
		CB_UnitDetected_Sides = new DarkUIComboBox();
		Label15 = new DarkLabel();
		UnitFilter_UnitDetected = new UnitFilter();
		TabPage9 = new TabPage();
		CB_RegularTimeInterval = new DarkUIComboBox();
		Label17 = new DarkLabel();
		TabPage_0 = new TabPage();
		UnitFilter_BaseStatusCheck = new UnitFilter();
		CB_BaseStatusCheck_Base = new DarkUIComboBox();
		CB_BaseStatusCheck_BaseSide = new DarkUIComboBox();
		BaseStatusCheck_Unit_Label = new DarkLabel();
		BaseStatusCheck_BaseSide = new DarkLabel();
		BaseStatusCheck_Base = new DarkLabel();
		CB_BaseStatusCheck_Condition = new DarkUIComboBox();
		DarkLabel1 = new DarkLabel();
		TabPage_1 = new TabPage();
		ReflectPage(new System.Windows.Forms.ToolTip(_RepositoryDescriptor));
		TabPage1.SuspendLayout();
		TC_TriggerOptions.SuspendLayout();
		TabPage2.SuspendLayout();
		((ISupportInitialize)NUD_DamagePercent).BeginInit();
		TabPage3.SuspendLayout();
		((ISupportInitialize)NUD_Points).BeginInit();
		TabPage4.SuspendLayout();
		TabPage5.SuspendLayout();
		GroupBox1.SuspendLayout();
		TabPage6.SuspendLayout();
		GroupBox2.SuspendLayout();
		TabPage7.SuspendLayout();
		TabPage8.SuspendLayout();
		TabPage9.SuspendLayout();
		TabPage_0.SuspendLayout();
		SuspendLayout();
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(4, 10);
		Label2.Name = "Label2";
		Label2.Size = new Size(89, 19);
		Label2.TabIndex = 3;
		Label2.Text = "描述：";
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		TextBox1.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(90, 6);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(451, 20);
		TextBox1.TabIndex = 4;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Button_OK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_OK.BackColor = Color.Transparent;
		Button_OK.DialogResult = DialogResult.None;
		Button_OK.Font = new Font("Segoe UI", 10f);
		Button_OK.ForeColor = SystemColors.Control;
		Button_OK.Location = new Point(2, 402);
		Button_OK.Name = "Button_OK";
		Button_OK.RoundRadius = 0;
		Button_OK.Size = new Size(146, 23);
		Button_OK.TabIndex = 5;
		Button_OK.Text = "确定";
		Button_Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Cancel.BackColor = Color.Transparent;
		Button_Cancel.DialogResult = DialogResult.None;
		Button_Cancel.Font = new Font("Segoe UI", 10f);
		Button_Cancel.ForeColor = SystemColors.Control;
		Button_Cancel.Location = new Point(624, 402);
		Button_Cancel.Name = "Button_Cancel";
		Button_Cancel.RoundRadius = 0;
		Button_Cancel.Size = new Size(155, 23);
		Button_Cancel.TabIndex = 6;
		Button_Cancel.Text = "取消";
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(1, 43);
		Label3.Name = "Label3";
		Label3.Size = new Size(137, 19);
		Label3.TabIndex = 7;
		Label3.Text = "触发器的设置";
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(UnitFilter_UnitDestroyed);
		TabPage1.Location = new Point(4, 68);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(779, 265);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "单元被摧毁";
		UnitFilter_UnitDestroyed.BackColor = Color.Transparent;
		UnitFilter_UnitDestroyed.FilterObject = null;
		UnitFilter_UnitDestroyed.Location = new Point(6, 47);
		UnitFilter_UnitDestroyed.MinimumSize = new Size(311, 177);
		UnitFilter_UnitDestroyed.Name = "UnitFilter_UnitDestroyed";
		UnitFilter_UnitDestroyed.Size = new Size(311, 212);
		UnitFilter_UnitDestroyed.TabIndex = 0;
		TC_TriggerOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TC_TriggerOptions.Controls.Add(TabPage1);
		TC_TriggerOptions.Controls.Add(TabPage2);
		TC_TriggerOptions.Controls.Add(TabPage3);
		TC_TriggerOptions.Controls.Add(TabPage4);
		TC_TriggerOptions.Controls.Add(TabPage5);
		TC_TriggerOptions.Controls.Add(TabPage6);
		TC_TriggerOptions.Controls.Add(TabPage7);
		TC_TriggerOptions.Controls.Add(TabPage8);
		TC_TriggerOptions.Controls.Add(TabPage9);
		TC_TriggerOptions.Controls.Add(TabPage_0);
		TC_TriggerOptions.Controls.Add(TabPage_1);
		TC_TriggerOptions.Cursor = Cursors.Hand;
		TC_TriggerOptions.Font = new Font("Segoe UI", 8f);
		TC_TriggerOptions.ItemSize = new Size(80, 32);
		TC_TriggerOptions.Location = new Point(2, 59);
		TC_TriggerOptions.Multiline = true;
		TC_TriggerOptions.Name = "TC_TriggerOptions";
		TC_TriggerOptions.SelectedIndex = 0;
		TC_TriggerOptions.Size = new Size(787, 337);
		TC_TriggerOptions.SizeMode = TabSizeMode.Fixed;
		TC_TriggerOptions.TabIndex = 20;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(NUD_DamagePercent);
		TabPage2.Controls.Add(Label7);
		TabPage2.Controls.Add(UnitFilter_UnitDamaged);
		TabPage2.Location = new Point(4, 36);
		TabPage2.Name = "TabPage2";
		TabPage2.Size = new Size(779, 297);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "单元被毁伤";
		NUD_DamagePercent.BackColor = Color.FromArgb(69, 73, 74);
		NUD_DamagePercent.BorderStyle = BorderStyle.FixedSingle;
		NUD_DamagePercent.Font = new Font("Segoe UI", 10f);
		NUD_DamagePercent.ForeColor = Color.FromArgb(220, 220, 220);
		NUD_DamagePercent.Location = new Point(200, 208);
		NUD_DamagePercent.Name = "NUD_DamagePercent";
		NUD_DamagePercent.Size = new Size(74, 30);
		NUD_DamagePercent.TabIndex = 3;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(18, 214);
		Label7.Name = "Label7";
		Label7.Size = new Size(176, 19);
		Label7.TabIndex = 2;
		Label7.Text = "毁伤百分比阈值：";
		UnitFilter_UnitDamaged.BackColor = Color.Transparent;
		UnitFilter_UnitDamaged.FilterObject = null;
		UnitFilter_UnitDamaged.Location = new Point(6, 6);
		UnitFilter_UnitDamaged.MinimumSize = new Size(311, 177);
		UnitFilter_UnitDamaged.Name = "UnitFilter_UnitDamaged";
		UnitFilter_UnitDamaged.Size = new Size(311, 196);
		UnitFilter_UnitDamaged.TabIndex = 1;
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(CB_Points_ReachDirection);
		TabPage3.Controls.Add(Label5);
		TabPage3.Controls.Add(NUD_Points);
		TabPage3.Controls.Add(CB_Points_Sides);
		TabPage3.Controls.Add(Label4);
		TabPage3.Controls.Add(Label1);
		TabPage3.Location = new Point(4, 36);
		TabPage3.Name = "TabPage3";
		TabPage3.Size = new Size(779, 297);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "分方分数";
		CB_Points_ReachDirection.BackColor = Color.Transparent;
		CB_Points_ReachDirection.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Points_ReachDirection.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Points_ReachDirection.Font = new Font("Segoe UI", 7f);
		CB_Points_ReachDirection.FormattingEnabled = true;
		CB_Points_ReachDirection.Items.AddRange(new object[3] { "大于", "等于", "小于" });
		CB_Points_ReachDirection.Location = new Point(153, 126);
		CB_Points_ReachDirection.Name = "CB_Points_ReachDirection";
		CB_Points_ReachDirection.Size = new Size(121, 24);
		CB_Points_ReachDirection.TabIndex = 10;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(351, 128);
		Label5.Name = "Label5";
		Label5.Size = new Size(47, 19);
		Label5.TabIndex = 9;
		Label5.Text = "分数";
		NUD_Points.BackColor = Color.FromArgb(69, 73, 74);
		NUD_Points.BorderStyle = BorderStyle.FixedSingle;
		NUD_Points.Font = new Font("Segoe UI", 8f);
		NUD_Points.ForeColor = Color.FromArgb(220, 220, 220);
		NUD_Points.Location = new Point(280, 126);
		NUD_Points.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		NUD_Points.Minimum = new decimal(new int[4] { 999999, 0, 0, -2147483648 });
		NUD_Points.Name = "NUD_Points";
		NUD_Points.Size = new Size(65, 25);
		NUD_Points.TabIndex = 8;
		CB_Points_Sides.BackColor = Color.Transparent;
		CB_Points_Sides.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Points_Sides.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Points_Sides.Font = new Font("Segoe UI", 7f);
		CB_Points_Sides.FormattingEnabled = true;
		CB_Points_Sides.Location = new Point(153, 98);
		CB_Points_Sides.Name = "CB_Points_Sides";
		CB_Points_Sides.Size = new Size(192, 24);
		CB_Points_Sides.TabIndex = 7;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(8, 130);
		Label4.Name = "Label4";
		Label4.Size = new Size(173, 19);
		Label4.TabIndex = 6;
		Label4.Text = "激活触发器当分方分数";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(116, 101);
		Label1.Name = "Label1";
		Label1.Size = new Size(37, 19);
		Label1.TabIndex = 5;
		Label1.Text = "分方：";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Controls.Add(Button_SetTime);
		TabPage4.Controls.Add(Label6);
		TabPage4.Controls.Add(DTP_StartTime);
		TabPage4.Controls.Add(DTP_StartDate);
		TabPage4.Location = new Point(4, 36);
		TabPage4.Name = "TabPage4";
		TabPage4.Padding = new Padding(3);
		TabPage4.Size = new Size(779, 297);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "时间";
		Button_SetTime.BackColor = Color.Transparent;
		Button_SetTime.DialogResult = DialogResult.None;
		Button_SetTime.Font = new Font("Segoe UI", 10f);
		Button_SetTime.ForeColor = SystemColors.Control;
		Button_SetTime.Location = new Point(229, 139);
		Button_SetTime.Name = "Button_SetTime";
		Button_SetTime.RoundRadius = 0;
		Button_SetTime.Size = new Size(75, 23);
		Button_SetTime.TabIndex = 25;
		Button_SetTime.Text = "设置时间";
		Label6.AutoSize = true;
		Label6.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(158, 45);
		Label6.Name = "Label6";
		Label6.Size = new Size(53, 19);
		Label6.TabIndex = 24;
		Label6.Text = "Label6";
		DTP_StartTime.BackColor = Color.FromArgb(31, 31, 31);
		DTP_StartTime.BorderStyle = BorderStyle.FixedSingle;
		DTP_StartTime.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_StartTime.Location = new Point(161, 113);
		DTP_StartTime.Name = "DTP_StartTime";
		DTP_StartTime.Size = new Size(223, 25);
		DTP_StartTime.TabIndex = 23;
		DTP_StartDate.BackColor = Color.FromArgb(31, 31, 31);
		DTP_StartDate.BorderStyle = BorderStyle.FixedSingle;
		DTP_StartDate.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_StartDate.Location = new Point(161, 87);
		DTP_StartDate.Name = "DTP_StartDate";
		DTP_StartDate.Size = new Size(223, 25);
		DTP_StartDate.TabIndex = 22;
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		TabPage5.Controls.Add(GroupBox1);
		TabPage5.Controls.Add(AreaEditor_UnitInArea);
		TabPage5.Controls.Add(UnitFilter_UnitInArea);
		TabPage5.Location = new Point(4, 36);
		TabPage5.Name = "TabPage5";
		TabPage5.Size = new Size(779, 297);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "单元停留在区域内";
		GroupBox1.Controls.Add(Label12);
		GroupBox1.Controls.Add(Label11);
		GroupBox1.Controls.Add(TB_Secs);
		GroupBox1.Controls.Add(TB_Mins);
		GroupBox1.Controls.Add(TB_Hours);
		GroupBox1.Controls.Add(Label10);
		GroupBox1.Controls.Add(TB_Days);
		GroupBox1.Controls.Add(Label9);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(387, 15);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(163, 119);
		GroupBox1.TabIndex = 4;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "要求时间达到";
		Label12.AutoSize = true;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(119, 78);
		Label12.Name = "Label12";
		Label12.Size = new Size(34, 19);
		Label12.TabIndex = 27;
		Label12.Text = "秒";
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(43, 78);
		Label11.Name = "Label11";
		Label11.Size = new Size(38, 19);
		Label11.TabIndex = 26;
		Label11.Text = "分钟";
		TB_Secs.AutoCompleteCustomSource = null;
		TB_Secs.AutoCompleteMode = AutoCompleteMode.None;
		TB_Secs.AutoCompleteSource = AutoCompleteSource.None;
		TB_Secs.BackColor = Color.Transparent;
		TB_Secs.Font = new Font("Segoe UI", 10f);
		TB_Secs.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Secs.Image = null;
		TB_Secs.Lines = null;
		TB_Secs.Location = new Point(78, 75);
		TB_Secs.MaxLength = 32767;
		TB_Secs.Multiline = false;
		TB_Secs.Name = "TB_Secs";
		TB_Secs.ReadOnly = false;
		TB_Secs.ScrollBars = ScrollBars.None;
		TB_Secs.SelectionStart = 0;
		TB_Secs.Size = new Size(39, 20);
		TB_Secs.TabIndex = 25;
		TB_Secs.Text = "0";
		TB_Secs.TextAlign = HorizontalAlignment.Left;
		TB_Secs.UseSystemPasswordChar = false;
		TB_Secs.WatermarkText = "";
		TB_Mins.AutoCompleteCustomSource = null;
		TB_Mins.AutoCompleteMode = AutoCompleteMode.None;
		TB_Mins.AutoCompleteSource = AutoCompleteSource.None;
		TB_Mins.BackColor = Color.Transparent;
		TB_Mins.Font = new Font("Segoe UI", 10f);
		TB_Mins.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Mins.Image = null;
		TB_Mins.Lines = null;
		TB_Mins.Location = new Point(6, 75);
		TB_Mins.MaxLength = 32767;
		TB_Mins.Multiline = false;
		TB_Mins.Name = "TB_Mins";
		TB_Mins.ReadOnly = false;
		TB_Mins.ScrollBars = ScrollBars.None;
		TB_Mins.SelectionStart = 0;
		TB_Mins.Size = new Size(36, 20);
		TB_Mins.TabIndex = 24;
		TB_Mins.Text = "0";
		TB_Mins.TextAlign = HorizontalAlignment.Left;
		TB_Mins.UseSystemPasswordChar = false;
		TB_Mins.WatermarkText = "";
		TB_Hours.AutoCompleteCustomSource = null;
		TB_Hours.AutoCompleteMode = AutoCompleteMode.None;
		TB_Hours.AutoCompleteSource = AutoCompleteSource.None;
		TB_Hours.BackColor = Color.Transparent;
		TB_Hours.Font = new Font("Segoe UI", 10f);
		TB_Hours.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Hours.Image = null;
		TB_Hours.Lines = null;
		TB_Hours.Location = new Point(78, 35);
		TB_Hours.MaxLength = 32767;
		TB_Hours.Multiline = false;
		TB_Hours.Name = "TB_Hours";
		TB_Hours.ReadOnly = false;
		TB_Hours.ScrollBars = ScrollBars.None;
		TB_Hours.SelectionStart = 0;
		TB_Hours.Size = new Size(39, 20);
		TB_Hours.TabIndex = 22;
		TB_Hours.Text = "0";
		TB_Hours.TextAlign = HorizontalAlignment.Left;
		TB_Hours.UseSystemPasswordChar = false;
		TB_Hours.WatermarkText = "";
		Label10.AutoSize = true;
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(40, 39);
		Label10.Name = "Label10";
		Label10.Size = new Size(37, 19);
		Label10.TabIndex = 19;
		Label10.Text = "天";
		TB_Days.AutoCompleteCustomSource = null;
		TB_Days.AutoCompleteMode = AutoCompleteMode.None;
		TB_Days.AutoCompleteSource = AutoCompleteSource.None;
		TB_Days.BackColor = Color.Transparent;
		TB_Days.Font = new Font("Segoe UI", 10f);
		TB_Days.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Days.Image = null;
		TB_Days.Lines = null;
		TB_Days.Location = new Point(7, 35);
		TB_Days.MaxLength = 32767;
		TB_Days.Multiline = false;
		TB_Days.Name = "TB_Days";
		TB_Days.ReadOnly = false;
		TB_Days.ScrollBars = ScrollBars.None;
		TB_Days.SelectionStart = 0;
		TB_Days.Size = new Size(35, 20);
		TB_Days.TabIndex = 20;
		TB_Days.Text = "0";
		TB_Days.TextAlign = HorizontalAlignment.Left;
		TB_Days.UseSystemPasswordChar = false;
		TB_Days.WatermarkText = "";
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(119, 39);
		Label9.Name = "Label9";
		Label9.Size = new Size(44, 19);
		Label9.TabIndex = 21;
		Label9.Text = "小时";
		AreaEditor_UnitInArea.BackColor = Color.FromArgb(60, 63, 65);
		AreaEditor_UnitInArea.Location = new Point(387, 170);
		AreaEditor_UnitInArea.Name = "AreaEditor_UnitInArea";
		AreaEditor_UnitInArea.Size = new Size(351, 124);
		AreaEditor_UnitInArea.TabIndex = 3;
		AreaEditor_UnitInArea.Title = "Area To Be Inside";
		UnitFilter_UnitInArea.BackColor = Color.Transparent;
		UnitFilter_UnitInArea.FilterObject = null;
		UnitFilter_UnitInArea.Location = new Point(6, 6);
		UnitFilter_UnitInArea.MinimumSize = new Size(311, 177);
		UnitFilter_UnitInArea.Name = "UnitFilter_UnitInArea";
		UnitFilter_UnitInArea.Size = new Size(311, 204);
		UnitFilter_UnitInArea.TabIndex = 2;
		TabPage6.BackColor = Color.FromArgb(60, 63, 65);
		TabPage6.Controls.Add(CB_UnitEntersArea_ModifierNOT);
		TabPage6.Controls.Add(CB_UnitEntersArea_ModifierEXIT);
		TabPage6.Controls.Add(GroupBox2);
		TabPage6.Controls.Add(AreaEditor_UnitEntersArea);
		TabPage6.Controls.Add(UnitFilter_UnitEntersArea);
		TabPage6.Location = new Point(4, 36);
		TabPage6.Name = "TabPage6";
		TabPage6.Size = new Size(779, 297);
		TabPage6.TabIndex = 5;
		TabPage6.Text = "单元进入区域";
		CB_UnitEntersArea_ModifierNOT.AutoSize = true;
		CB_UnitEntersArea_ModifierNOT.Location = new Point(201, 222);
		CB_UnitEntersArea_ModifierNOT.Name = "CB_UnitEntersArea_ModifierNOT";
		CB_UnitEntersArea_ModifierNOT.Size = new Size(116, 23);
		CB_UnitEntersArea_ModifierNOT.TabIndex = 8;
		CB_UnitEntersArea_ModifierNOT.Text = "条件：否";
		PreparePage().SetToolTip(CB_UnitEntersArea_ModifierNOT, "\"When checked, the trigger fires if an eligible unit is NOT in the specified area within the specified time frame");
		CB_UnitEntersArea_ModifierEXIT.AutoSize = true;
		CB_UnitEntersArea_ModifierEXIT.Location = new Point(69, 222);
		CB_UnitEntersArea_ModifierEXIT.Name = "CB_UnitEntersArea_ModifierEXIT";
		CB_UnitEntersArea_ModifierEXIT.Size = new Size(115, 23);
		CB_UnitEntersArea_ModifierEXIT.TabIndex = 9;
		CB_UnitEntersArea_ModifierEXIT.Text = "条件：离开";
		PreparePage().SetToolTip(CB_UnitEntersArea_ModifierEXIT, "\"When checked, the trigger fires if an eligible unit EXITs the specified area within the specified time frame");
		GroupBox2.Controls.Add(Button_UnitEntersArea);
		GroupBox2.Controls.Add(DTP_EnterArea_LTOA_Time);
		GroupBox2.Controls.Add(DTP_EnterArea_ETOA_Time);
		GroupBox2.Controls.Add(DTP_EnterArea_LTOA_Date);
		GroupBox2.Controls.Add(DTP_EnterArea_ETOA_Date);
		GroupBox2.Controls.Add(Label_UnitEntersArea_Latest);
		GroupBox2.Controls.Add(Label_UnitEntersArea_Earliest);
		GroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox2.Location = new Point(323, 16);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(415, 130);
		GroupBox2.TabIndex = 7;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "最早时间+最晚时间";
		Button_UnitEntersArea.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_UnitEntersArea.BackColor = Color.Transparent;
		Button_UnitEntersArea.DialogResult = DialogResult.None;
		Button_UnitEntersArea.Font = new Font("Segoe UI", 10f);
		Button_UnitEntersArea.ForeColor = SystemColors.Control;
		Button_UnitEntersArea.Location = new Point(148, 102);
		Button_UnitEntersArea.Name = "Button_UnitEntersArea";
		Button_UnitEntersArea.RoundRadius = 0;
		Button_UnitEntersArea.Size = new Size(142, 22);
		Button_UnitEntersArea.TabIndex = 32;
		Button_UnitEntersArea.Text = "设定时间";
		DTP_EnterArea_LTOA_Time.BackColor = Color.FromArgb(31, 31, 31);
		DTP_EnterArea_LTOA_Time.BorderStyle = BorderStyle.FixedSingle;
		DTP_EnterArea_LTOA_Time.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_EnterArea_LTOA_Time.Location = new Point(301, 63);
		DTP_EnterArea_LTOA_Time.Name = "DTP_EnterArea_LTOA_Time";
		DTP_EnterArea_LTOA_Time.Size = new Size(93, 25);
		DTP_EnterArea_LTOA_Time.TabIndex = 31;
		DTP_EnterArea_ETOA_Time.BackColor = Color.FromArgb(31, 31, 31);
		DTP_EnterArea_ETOA_Time.BorderStyle = BorderStyle.FixedSingle;
		DTP_EnterArea_ETOA_Time.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_EnterArea_ETOA_Time.Location = new Point(104, 63);
		DTP_EnterArea_ETOA_Time.Name = "DTP_EnterArea_ETOA_Time";
		DTP_EnterArea_ETOA_Time.Size = new Size(93, 25);
		DTP_EnterArea_ETOA_Time.TabIndex = 30;
		DTP_EnterArea_LTOA_Date.BackColor = Color.FromArgb(31, 31, 31);
		DTP_EnterArea_LTOA_Date.BorderStyle = BorderStyle.FixedSingle;
		DTP_EnterArea_LTOA_Date.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_EnterArea_LTOA_Date.Location = new Point(203, 37);
		DTP_EnterArea_LTOA_Date.Name = "DTP_EnterArea_LTOA_Date";
		DTP_EnterArea_LTOA_Date.Size = new Size(191, 25);
		DTP_EnterArea_LTOA_Date.TabIndex = 29;
		DTP_EnterArea_ETOA_Date.BackColor = Color.FromArgb(31, 31, 31);
		DTP_EnterArea_ETOA_Date.BorderStyle = BorderStyle.FixedSingle;
		DTP_EnterArea_ETOA_Date.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_EnterArea_ETOA_Date.Location = new Point(6, 37);
		DTP_EnterArea_ETOA_Date.Name = "DTP_EnterArea_ETOA_Date";
		DTP_EnterArea_ETOA_Date.Size = new Size(191, 25);
		DTP_EnterArea_ETOA_Date.TabIndex = 28;
		Label_UnitEntersArea_Latest.AutoSize = true;
		Label_UnitEntersArea_Latest.ForeColor = Color.FromArgb(220, 220, 220);
		Label_UnitEntersArea_Latest.Location = new Point(200, 21);
		Label_UnitEntersArea_Latest.Name = "Label_UnitEntersArea_Latest";
		Label_UnitEntersArea_Latest.Size = new Size(49, 19);
		Label_UnitEntersArea_Latest.TabIndex = 27;
		Label_UnitEntersArea_Latest.Text = "最晚：";
		Label_UnitEntersArea_Earliest.AutoSize = true;
		Label_UnitEntersArea_Earliest.ForeColor = Color.FromArgb(220, 220, 220);
		Label_UnitEntersArea_Earliest.Location = new Point(3, 21);
		Label_UnitEntersArea_Earliest.Name = "Label_UnitEntersArea_Earliest";
		Label_UnitEntersArea_Earliest.Size = new Size(55, 19);
		Label_UnitEntersArea_Earliest.TabIndex = 26;
		Label_UnitEntersArea_Earliest.Text = "最早：";
		AreaEditor_UnitEntersArea.BackColor = Color.FromArgb(60, 63, 65);
		AreaEditor_UnitEntersArea.Location = new Point(387, 172);
		AreaEditor_UnitEntersArea.Name = "AreaEditor_UnitEntersArea";
		AreaEditor_UnitEntersArea.Size = new Size(351, 125);
		AreaEditor_UnitEntersArea.TabIndex = 6;
		AreaEditor_UnitEntersArea.Title = "Area To Be Inside";
		UnitFilter_UnitEntersArea.BackColor = Color.Transparent;
		UnitFilter_UnitEntersArea.FilterObject = null;
		UnitFilter_UnitEntersArea.Location = new Point(6, 6);
		UnitFilter_UnitEntersArea.MinimumSize = new Size(311, 177);
		UnitFilter_UnitEntersArea.Name = "UnitFilter_UnitEntersArea";
		UnitFilter_UnitEntersArea.Size = new Size(311, 194);
		UnitFilter_UnitEntersArea.TabIndex = 5;
		TabPage7.BackColor = Color.FromArgb(60, 63, 65);
		TabPage7.Controls.Add(RandomTimeValue);
		TabPage7.Controls.Add(Label14);
		TabPage7.Controls.Add(DTP_LatestTime);
		TabPage7.Controls.Add(DTP_LatestDate);
		TabPage7.Controls.Add(Label13);
		TabPage7.Controls.Add(Button1);
		TabPage7.Controls.Add(Label8);
		TabPage7.Controls.Add(DTP_EarliestTime);
		TabPage7.Controls.Add(DTP_EarliestDate);
		TabPage7.Location = new Point(4, 36);
		TabPage7.Name = "TabPage7";
		TabPage7.Padding = new Padding(3);
		TabPage7.Size = new Size(779, 297);
		TabPage7.TabIndex = 6;
		TabPage7.Text = "随机时间";
		RandomTimeValue.AutoSize = true;
		RandomTimeValue.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		RandomTimeValue.ForeColor = Color.FromArgb(220, 220, 220);
		RandomTimeValue.Location = new Point(489, 176);
		RandomTimeValue.Name = "RandomTimeValue";
		RandomTimeValue.Size = new Size(98, 19);
		RandomTimeValue.TabIndex = 34;
		RandomTimeValue.Text = "随机时间：";
		RandomTimeValue.Visible = false;
		Label14.AutoSize = true;
		Label14.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label14.ForeColor = Color.FromArgb(220, 220, 220);
		Label14.Location = new Point(169, 154);
		Label14.Name = "Label14";
		Label14.Size = new Size(52, 19);
		Label14.TabIndex = 33;
		Label14.Text = "最晚：";
		DTP_LatestTime.BackColor = Color.FromArgb(31, 31, 31);
		DTP_LatestTime.BorderStyle = BorderStyle.FixedSingle;
		DTP_LatestTime.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_LatestTime.Location = new Point(172, 196);
		DTP_LatestTime.Name = "DTP_LatestTime";
		DTP_LatestTime.Size = new Size(223, 25);
		DTP_LatestTime.TabIndex = 32;
		DTP_LatestDate.BackColor = Color.FromArgb(31, 31, 31);
		DTP_LatestDate.BorderStyle = BorderStyle.FixedSingle;
		DTP_LatestDate.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_LatestDate.Location = new Point(172, 170);
		DTP_LatestDate.Name = "DTP_LatestDate";
		DTP_LatestDate.Size = new Size(223, 25);
		DTP_LatestDate.TabIndex = 31;
		Label13.AutoSize = true;
		Label13.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(169, 77);
		Label13.Name = "Label13";
		Label13.Size = new Size(61, 19);
		Label13.TabIndex = 30;
		Label13.Text = "最早：";
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(221, 235);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(131, 23);
		Button1.TabIndex = 29;
		Button1.Text = "设置随机时间";
		Label8.AutoSize = true;
		Label8.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(170, 23);
		Label8.Name = "Label8";
		Label8.Size = new Size(53, 19);
		Label8.TabIndex = 28;
		Label8.Text = "Label8";
		DTP_EarliestTime.BackColor = Color.FromArgb(31, 31, 31);
		DTP_EarliestTime.BorderStyle = BorderStyle.FixedSingle;
		DTP_EarliestTime.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_EarliestTime.Location = new Point(172, 119);
		DTP_EarliestTime.Name = "DTP_EarliestTime";
		DTP_EarliestTime.Size = new Size(223, 25);
		DTP_EarliestTime.TabIndex = 27;
		DTP_EarliestDate.BackColor = Color.FromArgb(31, 31, 31);
		DTP_EarliestDate.BorderStyle = BorderStyle.FixedSingle;
		DTP_EarliestDate.ForeColor = Color.FromArgb(220, 220, 220);
		DTP_EarliestDate.Location = new Point(172, 93);
		DTP_EarliestDate.Name = "DTP_EarliestDate";
		DTP_EarliestDate.Size = new Size(223, 25);
		DTP_EarliestDate.TabIndex = 26;
		TabPage8.BackColor = Color.FromArgb(60, 63, 65);
		TabPage8.Controls.Add(AreaEditor_DetectedArea);
		TabPage8.Controls.Add(CB_MCL);
		TabPage8.Controls.Add(Label16);
		TabPage8.Controls.Add(CB_UnitDetected_Sides);
		TabPage8.Controls.Add(Label15);
		TabPage8.Controls.Add(UnitFilter_UnitDetected);
		TabPage8.Location = new Point(4, 36);
		TabPage8.Name = "TabPage8";
		TabPage8.Padding = new Padding(3);
		TabPage8.Size = new Size(779, 297);
		TabPage8.TabIndex = 7;
		TabPage8.Text = "单元被探测";
		AreaEditor_DetectedArea.BackColor = Color.FromArgb(60, 63, 65);
		AreaEditor_DetectedArea.Location = new Point(323, 169);
		AreaEditor_DetectedArea.Name = "AreaEditor_DetectedArea";
		AreaEditor_DetectedArea.Size = new Size(351, 125);
		AreaEditor_DetectedArea.TabIndex = 12;
		AreaEditor_DetectedArea.Title = "Area To Be Inside";
		CB_MCL.BackColor = Color.Transparent;
		CB_MCL.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MCL.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MCL.Font = new Font("Segoe UI", 7f);
		CB_MCL.FormattingEnabled = true;
		CB_MCL.Items.AddRange(new object[5] { "未知", "已知类别（如飞机，舰船）", "已知类型（如 护卫舰，轰炸机）", "已知型号（如F-16，尼米兹级）", "精确ID（如空军一号，尼米兹号航母）" });
		CB_MCL.Location = new Point(477, 110);
		CB_MCL.Name = "CB_MCL";
		CB_MCL.Size = new Size(197, 24);
		CB_MCL.TabIndex = 11;
		Label16.AutoSize = true;
		Label16.ForeColor = Color.FromArgb(220, 220, 220);
		Label16.Location = new Point(332, 113);
		Label16.Name = "Label16";
		Label16.Size = new Size(181, 19);
		Label16.TabIndex = 10;
		Label16.Text = "最低分类等级：";
		CB_UnitDetected_Sides.BackColor = Color.Transparent;
		CB_UnitDetected_Sides.DrawMode = DrawMode.OwnerDrawFixed;
		CB_UnitDetected_Sides.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_UnitDetected_Sides.Font = new Font("Segoe UI", 7f);
		CB_UnitDetected_Sides.FormattingEnabled = true;
		CB_UnitDetected_Sides.Location = new Point(482, 81);
		CB_UnitDetected_Sides.Name = "CB_UnitDetected_Sides";
		CB_UnitDetected_Sides.Size = new Size(192, 24);
		CB_UnitDetected_Sides.TabIndex = 9;
		Label15.AutoSize = true;
		Label15.ForeColor = Color.FromArgb(220, 220, 220);
		Label15.Location = new Point(350, 86);
		Label15.Name = "Label15";
		Label15.Size = new Size(94, 19);
		Label15.TabIndex = 8;
		Label15.Text = "探测单元分方：";
		UnitFilter_UnitDetected.BackColor = Color.Transparent;
		UnitFilter_UnitDetected.FilterObject = null;
		UnitFilter_UnitDetected.Location = new Point(6, 6);
		UnitFilter_UnitDetected.MinimumSize = new Size(311, 177);
		UnitFilter_UnitDetected.Name = "UnitFilter_UnitDetected";
		UnitFilter_UnitDetected.Size = new Size(311, 203);
		UnitFilter_UnitDetected.TabIndex = 6;
		TabPage9.BackColor = Color.FromArgb(60, 63, 65);
		TabPage9.Controls.Add(CB_RegularTimeInterval);
		TabPage9.Controls.Add(Label17);
		TabPage9.Location = new Point(4, 36);
		TabPage9.Name = "TabPage9";
		TabPage9.Padding = new Padding(3);
		TabPage9.Size = new Size(779, 297);
		TabPage9.TabIndex = 8;
		TabPage9.Text = "延迟一段时间";
		CB_RegularTimeInterval.BackColor = Color.Transparent;
		CB_RegularTimeInterval.DrawMode = DrawMode.OwnerDrawFixed;
		CB_RegularTimeInterval.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_RegularTimeInterval.Font = new Font("Segoe UI", 7f);
		CB_RegularTimeInterval.FormattingEnabled = true;
		CB_RegularTimeInterval.Items.AddRange(new object[13]
		{
			"Every simulation pulse", "一秒", "五秒", "十五秒", "三十秒", "一分钟", "五分钟", "十五分钟", "三十分钟", "一小时",
			"六小时", "十二小时", "二十四小时"
		});
		CB_RegularTimeInterval.Location = new Point(227, 98);
		CB_RegularTimeInterval.Name = "CB_RegularTimeInterval";
		CB_RegularTimeInterval.Size = new Size(155, 24);
		CB_RegularTimeInterval.TabIndex = 1;
		Label17.AutoSize = true;
		Label17.ForeColor = Color.FromArgb(220, 220, 220);
		Label17.Location = new Point(115, 101);
		Label17.Name = "Label17";
		Label17.Size = new Size(137, 19);
		Label17.TabIndex = 0;
		Label17.Text = "触发器触发条件：";
		TabPage_0.BackColor = Color.FromArgb(60, 63, 65);
		TabPage_0.Controls.Add(UnitFilter_BaseStatusCheck);
		TabPage_0.Controls.Add(CB_BaseStatusCheck_Base);
		TabPage_0.Controls.Add(CB_BaseStatusCheck_BaseSide);
		TabPage_0.Controls.Add(BaseStatusCheck_Unit_Label);
		TabPage_0.Controls.Add(BaseStatusCheck_BaseSide);
		TabPage_0.Controls.Add(BaseStatusCheck_Base);
		TabPage_0.Controls.Add(CB_BaseStatusCheck_Condition);
		TabPage_0.Controls.Add(DarkLabel1);
		TabPage_0.Location = new Point(4, 68);
		TabPage_0.Name = "TabPage10";
		TabPage_0.Padding = new Padding(3);
		TabPage_0.Size = new Size(779, 265);
		TabPage_0.TabIndex = 9;
		TabPage_0.Text = "Air/Dock Status Change";
		UnitFilter_BaseStatusCheck.BackColor = Color.Transparent;
		UnitFilter_BaseStatusCheck.FilterObject = null;
		UnitFilter_BaseStatusCheck.Location = new Point(6, 40);
		UnitFilter_BaseStatusCheck.MinimumSize = new Size(311, 177);
		UnitFilter_BaseStatusCheck.Name = "UnitFilter_BaseStatusCheck";
		UnitFilter_BaseStatusCheck.Size = new Size(311, 203);
		UnitFilter_BaseStatusCheck.TabIndex = 6;
		CB_BaseStatusCheck_Base.BackColor = Color.Transparent;
		CB_BaseStatusCheck_Base.DrawMode = DrawMode.OwnerDrawFixed;
		CB_BaseStatusCheck_Base.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_BaseStatusCheck_Base.Font = new Font("Segoe UI", 7f);
		CB_BaseStatusCheck_Base.FormattingEnabled = true;
		CB_BaseStatusCheck_Base.Location = new Point(470, 57);
		CB_BaseStatusCheck_Base.Name = "CB_BaseStatusCheck_Base";
		CB_BaseStatusCheck_Base.Size = new Size(245, 24);
		CB_BaseStatusCheck_Base.TabIndex = 11;
		CB_BaseStatusCheck_BaseSide.BackColor = Color.Transparent;
		CB_BaseStatusCheck_BaseSide.DrawMode = DrawMode.OwnerDrawFixed;
		CB_BaseStatusCheck_BaseSide.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_BaseStatusCheck_BaseSide.Font = new Font("Segoe UI", 7f);
		CB_BaseStatusCheck_BaseSide.FormattingEnabled = true;
		CB_BaseStatusCheck_BaseSide.Location = new Point(523, 18);
		CB_BaseStatusCheck_BaseSide.Name = "CB_BaseStatusCheck_BaseSide";
		CB_BaseStatusCheck_BaseSide.Size = new Size(192, 24);
		CB_BaseStatusCheck_BaseSide.TabIndex = 10;
		BaseStatusCheck_Unit_Label.AutoSize = true;
		BaseStatusCheck_Unit_Label.ForeColor = Color.FromArgb(220, 220, 220);
		BaseStatusCheck_Unit_Label.Location = new Point(80, 18);
		BaseStatusCheck_Unit_Label.Name = "BaseStatusCheck_Unit_Label";
		BaseStatusCheck_Unit_Label.Size = new Size(66, 19);
		BaseStatusCheck_Unit_Label.TabIndex = 3;
		BaseStatusCheck_Unit_Label.Text = "Unit filter";
		BaseStatusCheck_BaseSide.AutoSize = true;
		BaseStatusCheck_BaseSide.ForeColor = Color.FromArgb(220, 220, 220);
		BaseStatusCheck_BaseSide.Location = new Point(385, 18);
		BaseStatusCheck_BaseSide.Name = "BaseStatusCheck_BaseSide";
		BaseStatusCheck_BaseSide.Size = new Size(140, 19);
		BaseStatusCheck_BaseSide.TabIndex = 2;
		BaseStatusCheck_BaseSide.Text = "Side of Base to Check";
		BaseStatusCheck_Base.AutoSize = true;
		BaseStatusCheck_Base.ForeColor = Color.FromArgb(220, 220, 220);
		BaseStatusCheck_Base.Location = new Point(346, 57);
		BaseStatusCheck_Base.Name = "BaseStatusCheck_Base";
		BaseStatusCheck_Base.Size = new Size(118, 19);
		BaseStatusCheck_Base.TabIndex = 1;
		BaseStatusCheck_Base.Text = "Base to Check On";
		CB_BaseStatusCheck_Condition.BackColor = Color.Transparent;
		CB_BaseStatusCheck_Condition.DrawMode = DrawMode.OwnerDrawFixed;
		CB_BaseStatusCheck_Condition.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_BaseStatusCheck_Condition.Font = new Font("Segoe UI", 7f);
		CB_BaseStatusCheck_Condition.FormattingEnabled = true;
		CB_BaseStatusCheck_Condition.Location = new Point(470, 101);
		CB_BaseStatusCheck_Condition.Name = "CB_BaseStatusCheck_Condition";
		CB_BaseStatusCheck_Condition.Size = new Size(245, 24);
		CB_BaseStatusCheck_Condition.TabIndex = 13;
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(346, 101);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(137, 19);
		DarkLabel1.TabIndex = 12;
		DarkLabel1.Text = "Target Condition to ..";
		TabPage_1.Location = new Point(4, 68);
		TabPage_1.Name = "TabPage99";
		TabPage_1.Padding = new Padding(3);
		TabPage_1.Size = new Size(779, 265);
		TabPage_1.TabIndex = 99;
		TabPage_1.UseVisualStyleBackColor = true;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(782, 428);
		base.Controls.Add(TC_TriggerOptions);
		base.Controls.Add(Label3);
		base.Controls.Add(Button_Cancel);
		base.Controls.Add(Button_OK);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label2);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditTrigger";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑事件触发器";
		TabPage1.ResumeLayout(performLayout: false);
		TC_TriggerOptions.ResumeLayout(performLayout: false);
		TabPage2.ResumeLayout(performLayout: false);
		TabPage2.PerformLayout();
		((ISupportInitialize)NUD_DamagePercent).EndInit();
		TabPage3.ResumeLayout(performLayout: false);
		TabPage3.PerformLayout();
		((ISupportInitialize)NUD_Points).EndInit();
		TabPage4.ResumeLayout(performLayout: false);
		TabPage4.PerformLayout();
		TabPage5.ResumeLayout(performLayout: false);
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		TabPage6.ResumeLayout(performLayout: false);
		TabPage6.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		TabPage7.ResumeLayout(performLayout: false);
		TabPage7.PerformLayout();
		TabPage8.ResumeLayout(performLayout: false);
		TabPage8.PerformLayout();
		TabPage9.ResumeLayout(performLayout: false);
		TabPage9.PerformLayout();
		TabPage_0.ResumeLayout(performLayout: false);
		TabPage_0.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ManageReg(object sender, FormClosingEventArgs e)
	{
		m_RoleDescriptor?.Invoke(Client.CurrentScenario);
		ItemExporter.ConnectInterruptibleTemplate.ListTriggers.RefreshGrid();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			theTrigger = null;
			AreaEditor_UnitInArea.ReleaseReferences();
			AreaEditor_UnitEntersArea.ReleaseReferences();
			AreaEditor_DetectedArea.ReleaseReferences();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void RevertReg(object sender, EventArgs e)
	{
		if (Information.IsNothing(theTrigger))
		{
			Close();
		}
		TextBox1.Text = theTrigger.Description;
		Button_OK.Visible = Action == _FormAction.AddNew;
		Button_Cancel.Visible = Button_OK.Visible;
		switch (theTrigger.Type)
		{
		case EventTrigger.EventTriggerType.UnitDestroyed:
			TC_TriggerOptions.SelectedIndex = 0;
			TC_TriggerOptions.TabPages[0].Enabled = true;
			UnitFilter_UnitDestroyed.FilterObject = ((EventTrigger_UnitDestroyed)theTrigger).TargetFilter;
			break;
		case EventTrigger.EventTriggerType.Points:
		{
			TC_TriggerOptions.SelectedIndex = 2;
			TC_TriggerOptions.TabPages[2].Enabled = true;
			CB_Points_Sides.Items.Clear();
			CB_Points_Sides.DisplayMember = "Content";
			Side[] sides_ReadOnly2 = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array6 = sides_ReadOnly2;
			foreach (Side side2 in array6)
			{
				ComboBoxItem comboBoxItem8 = new ComboBoxItem();
				comboBoxItem8.Content = side2.Name;
				comboBoxItem8.Tag = side2.ObjectID;
				CB_Points_Sides.Items.Add(comboBoxItem8);
			}
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = CB_Points_Sides.Items.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ComboBoxItem comboBoxItem9 = (ComboBoxItem)enumerator2.Current;
					if (Operators.CompareString(Conversions.ToString(comboBoxItem9.Tag), ((EventTrigger_Points)theTrigger).SideID, TextCompare: true) == 0)
					{
						CB_Points_Sides.SelectedItem = comboBoxItem9;
						break;
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
			CB_Points_ReachDirection.SelectedIndex = (int)((EventTrigger_Points)theTrigger).ReachDirection;
			NUD_Points.Value = new decimal(((EventTrigger_Points)theTrigger).PointValue);
			break;
		}
		case EventTrigger.EventTriggerType.Time:
		{
			TC_TriggerOptions.SelectedIndex = 3;
			TC_TriggerOptions.TabPages[3].Enabled = true;
			DateTime dateTime_5 = ((EventTrigger_Time)theTrigger).Time;
			Label6.Text = "目前设定：" + dateTime_5.ToShortDateString() + " - " + dateTime_5.ToShortTimeString();
			string string_10 = "";
			string string_2 = "";
			GameGeneral.PaddedTimeString(ref dateTime_5, ref string_10);
			GameGeneral.PaddedDateString(ref dateTime_5, ref string_2, bool_1: true);
			DTP_StartDate.Text = string_2;
			DTP_StartTime.Text = string_10;
			break;
		}
		case EventTrigger.EventTriggerType.UnitDamaged:
			TC_TriggerOptions.SelectedIndex = 1;
			TC_TriggerOptions.TabPages[1].Enabled = true;
			UnitFilter_UnitDamaged.FilterObject = ((EventTrigger_UnitDamaged)theTrigger).TargetFilter;
			NUD_DamagePercent.Value = new decimal(((EventTrigger_UnitDamaged)theTrigger).DamagePercent);
			break;
		case EventTrigger.EventTriggerType.UnitRemainsInArea:
		{
			TC_TriggerOptions.SelectedIndex = 4;
			TC_TriggerOptions.TabPages[4].Enabled = true;
			UnitFilter_UnitInArea.FilterObject = ((EventTrigger_UnitRemainsInArea)theTrigger).TargetFilter;
			AreaEditor_UnitInArea.AreaPoints = ((EventTrigger_UnitRemainsInArea)theTrigger).Area;
			AreaEditor_UnitInArea.RefreshForm();
			TimeSpan timeSpan = TimeSpan.FromSeconds(((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration);
			TB_Days.Text = Conversions.ToString(timeSpan.Days);
			TB_Hours.Text = Conversions.ToString(timeSpan.Hours);
			TB_Mins.Text = Conversions.ToString(timeSpan.Minutes);
			TB_Secs.Text = Conversions.ToString(timeSpan.Seconds);
			TB_Days.TextChanged += ComputeParam;
			TB_Hours.TextChanged += PatchParam;
			TB_Mins.TextChanged += SelectParam;
			TB_Secs.TextChanged += CallParam;
			break;
		}
		case EventTrigger.EventTriggerType.UnitEntersArea:
		{
			TC_TriggerOptions.SelectedIndex = 5;
			TC_TriggerOptions.TabPages[5].Enabled = true;
			UnitFilter_UnitEntersArea.FilterObject = ((EventTrigger_UnitEntersArea)theTrigger).TargetFilter;
			AreaEditor_UnitEntersArea.AreaPoints = ((EventTrigger_UnitEntersArea)theTrigger).Area;
			AreaEditor_UnitEntersArea.RefreshForm();
			DateTime dateTime_3 = ((EventTrigger_UnitEntersArea)theTrigger).dateTime_0;
			DateTime dateTime_4 = ((EventTrigger_UnitEntersArea)theTrigger).dateTime_1;
			string string_6 = null;
			GameGeneral.PaddedTimeString(ref dateTime_3, ref string_6);
			string string_7 = null;
			GameGeneral.PaddedDateString(ref dateTime_3, ref string_7, bool_1: true);
			DTP_EnterArea_ETOA_Date.Text = string_7;
			DTP_EnterArea_ETOA_Time.Text = string_6;
			string string_8 = null;
			GameGeneral.PaddedTimeString(ref dateTime_4, ref string_8);
			string string_9 = null;
			GameGeneral.PaddedDateString(ref dateTime_4, ref string_9, bool_1: true);
			DTP_EnterArea_LTOA_Date.Text = string_9;
			DTP_EnterArea_LTOA_Time.Text = string_8;
			Label_UnitEntersArea_Earliest.Text = "最早：" + dateTime_3.ToShortDateString() + " - " + dateTime_3.ToShortTimeString();
			Label_UnitEntersArea_Latest.Text = "最新：" + dateTime_4.ToShortDateString() + " - " + dateTime_4.ToShortTimeString();
			CB_UnitEntersArea_ModifierNOT.Checked = ((EventTrigger_UnitEntersArea)theTrigger).Modifier_NOT;
			CB_UnitEntersArea_ModifierNOT.CheckedChanged += LogoutParam;
			CB_UnitEntersArea_ModifierEXIT.Checked = ((EventTrigger_UnitEntersArea)theTrigger).Modifier_EXIT;
			CB_UnitEntersArea_ModifierEXIT.CheckedChanged += ViewParam;
			break;
		}
		case EventTrigger.EventTriggerType.RandomTime:
		{
			TC_TriggerOptions.SelectedIndex = 6;
			TC_TriggerOptions.TabPages[6].Enabled = true;
			DateTime dateTime_ = ((EventTrigger_RandomTime)theTrigger).EarliestTime;
			DateTime dateTime_2 = ((EventTrigger_RandomTime)theTrigger).LatestTime;
			Label8.Text = "当前设置: \r\n最早: " + dateTime_.ToShortDateString() + " - " + dateTime_.ToShortTimeString() + "\r\n最晚： " + dateTime_2.ToShortDateString() + " - " + dateTime_2.ToShortTimeString();
			string string_ = null;
			GameGeneral.PaddedTimeString(ref dateTime_, ref string_);
			string string_3 = null;
			GameGeneral.PaddedDateString(ref dateTime_, ref string_3, bool_1: true);
			DTP_EarliestDate.Text = string_3;
			DTP_EarliestTime.Text = string_;
			string string_4 = null;
			GameGeneral.PaddedTimeString(ref dateTime_2, ref string_4);
			string string_5 = null;
			GameGeneral.PaddedDateString(ref dateTime_2, ref string_5, bool_1: true);
			DTP_LatestDate.Text = string_5;
			DTP_LatestTime.Text = string_4;
			if (((EventTrigger_RandomTime)theTrigger).isActualTimeSet)
			{
				RandomTimeValue.Visible = true;
				RandomTimeValue.Text = "触发器触发时间 " + Conversions.ToString(((EventTrigger_RandomTime)theTrigger).ActualTime);
			}
			else
			{
				RandomTimeValue.Visible = false;
				RandomTimeValue.Text = "";
			}
			break;
		}
		case EventTrigger.EventTriggerType.UnitDetected:
		{
			TC_TriggerOptions.SelectedIndex = 7;
			TC_TriggerOptions.TabPages[7].Enabled = true;
			CB_UnitDetected_Sides.Items.Clear();
			CB_UnitDetected_Sides.DisplayMember = "Content";
			Side[] sides_ReadOnly3 = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array7 = sides_ReadOnly3;
			foreach (Side side3 in array7)
			{
				ComboBoxItem comboBoxItem10 = new ComboBoxItem();
				comboBoxItem10.Content = side3.Name;
				comboBoxItem10.Tag = side3.ObjectID;
				CB_UnitDetected_Sides.Items.Add(comboBoxItem10);
			}
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = CB_UnitDetected_Sides.Items.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					ComboBoxItem comboBoxItem2 = (ComboBoxItem)enumerator3.Current;
					if (Operators.CompareString(Conversions.ToString(comboBoxItem2.Tag), ((EventTrigger_UnitDetected)theTrigger).DetectorSideID, TextCompare: true) == 0)
					{
						CB_UnitDetected_Sides.SelectedItem = comboBoxItem2;
						break;
					}
				}
			}
			finally
			{
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
			UnitFilter_UnitDetected.FilterObject = ((EventTrigger_UnitDetected)theTrigger).TargetFilter;
			AreaEditor_DetectedArea.AreaPoints = ((EventTrigger_UnitDetected)theTrigger).Area;
			AreaEditor_DetectedArea.RefreshForm();
			CB_MCL.SelectedIndex = (int)((EventTrigger_UnitDetected)theTrigger).MinimumClassificationLevel;
			break;
		}
		case EventTrigger.EventTriggerType.RegularTime:
			TC_TriggerOptions.SelectedIndex = 8;
			TC_TriggerOptions.TabPages[8].Enabled = true;
			switch (((EventTrigger_RegularTime)theTrigger).Interval)
			{
			case EventTrigger_RegularTime.RegularTimeInterval.OneSecond:
				CB_RegularTimeInterval.SelectedIndex = 1;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FiveSeconds:
				CB_RegularTimeInterval.SelectedIndex = 2;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FifteenSeconds:
				CB_RegularTimeInterval.SelectedIndex = 3;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.ThirtySeconds:
				CB_RegularTimeInterval.SelectedIndex = 4;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.OneMinute:
				CB_RegularTimeInterval.SelectedIndex = 5;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FiveMinutes:
				CB_RegularTimeInterval.SelectedIndex = 6;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.FifteenMinutes:
				CB_RegularTimeInterval.SelectedIndex = 7;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.ThirtyMinutes:
				CB_RegularTimeInterval.SelectedIndex = 8;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.OneHour:
				CB_RegularTimeInterval.SelectedIndex = 9;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.SixHours:
				CB_RegularTimeInterval.SelectedIndex = 10;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.TwelveHours:
				CB_RegularTimeInterval.SelectedIndex = 11;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.TwentyFourHours:
				CB_RegularTimeInterval.SelectedIndex = 12;
				break;
			case EventTrigger_RegularTime.RegularTimeInterval.EveryPulse:
				CB_RegularTimeInterval.SelectedIndex = 0;
				break;
			}
			break;
		default:
			TC_TriggerOptions.SelectedIndex = 10;
			TC_TriggerOptions.TabPages[10].Enabled = false;
			Label3.Text = theTrigger.Type.ToString();
			break;
		case EventTrigger.EventTriggerType.UnitBaseStatus:
		{
			TC_TriggerOptions.SelectedIndex = 9;
			TC_TriggerOptions.TabPages[9].Enabled = true;
			UnitFilter_BaseStatusCheck.FilterObject = ((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter;
			CB_BaseStatusCheck_Condition.Items.Clear();
			CB_BaseStatusCheck_Condition.DisplayMember = "Content";
			switch (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType)
			{
			default:
			{
				ComboBoxItem comboBoxItem4 = new ComboBoxItem();
				if (CB_BaseStatusCheck_Condition.Items.Count == 0)
				{
					comboBoxItem4.Content = "Not valid for condition check";
					comboBoxItem4.Tag = null;
					CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem4);
					CB_BaseStatusCheck_Condition.SelectedIndex = 0;
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Ship:
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				byte[] array = (byte[])Enum.GetValues(typeof(ActiveUnit_DockingOps._DockingOpsCondition));
				byte[] array4 = array;
				foreach (byte b2 in array4)
				{
					ComboBoxItem comboBoxItem5 = new ComboBoxItem();
					if (CB_BaseStatusCheck_Condition.Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
					{
						comboBoxItem5.Content = "No conditon set";
						comboBoxItem5.Tag = null;
						CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem5);
						CB_BaseStatusCheck_Condition.SelectedIndex = 0;
					}
					comboBoxItem5 = new ComboBoxItem();
					ComboBoxItem comboBoxItem6 = comboBoxItem5;
					ActiveUnit_DockingOps._DockingOpsCondition dockingOpsCondition = (ActiveUnit_DockingOps._DockingOpsCondition)b2;
					comboBoxItem6.Content = dockingOpsCondition.ToString();
					comboBoxItem5.Tag = b2;
					CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem5);
					if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b2 >= 0 && Operators.ConditionalCompareObjectEqual(b2, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, TextCompare: true))
					{
						CB_BaseStatusCheck_Condition.SelectedIndex = CB_BaseStatusCheck_Condition.Items.Count - 1;
					}
				}
				break;
			}
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				byte[] array2 = (byte[])Enum.GetValues(typeof(Aircraft_AirOps._AirOpsCondition));
				byte[] array3 = array2;
				foreach (byte b in array3)
				{
					switch (b)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 10:
					case 12:
					case 17:
					case 18:
					case 22:
					{
						ComboBoxItem comboBoxItem = new ComboBoxItem();
						if (CB_BaseStatusCheck_Condition.Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
						{
							comboBoxItem.Content = "No conditon set";
							comboBoxItem.Tag = null;
							CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem);
							CB_BaseStatusCheck_Condition.SelectedIndex = 0;
						}
						comboBoxItem = new ComboBoxItem();
						ComboBoxItem comboBoxItem3 = comboBoxItem;
						Aircraft_AirOps._AirOpsCondition airOpsCondition = (Aircraft_AirOps._AirOpsCondition)b;
						comboBoxItem3.Content = airOpsCondition.ToString();
						comboBoxItem.Tag = b;
						CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem);
						if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b >= 0 && Operators.ConditionalCompareObjectEqual(b, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, TextCompare: true))
						{
							CB_BaseStatusCheck_Condition.SelectedIndex = CB_BaseStatusCheck_Condition.Items.Count - 1;
						}
						break;
					}
					}
				}
				break;
			}
			}
			string text = null;
			CB_BaseStatusCheck_Base.Items.Clear();
			CB_BaseStatusCheck_Base.DisplayMember = "Content";
			if (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType == GlobalVariables.ActiveUnitType.None)
			{
				break;
			}
			ComboBoxItem comboBoxItem7 = new ComboBoxItem();
			comboBoxItem7.Content = "No unit/base limit";
			comboBoxItem7.Tag = "";
			CB_BaseStatusCheck_Base.Items.Add(comboBoxItem7);
			CB_BaseStatusCheck_Base.SelectedIndex = 0;
			foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
			{
				if (activeUnits_ == null || !activeUnits_.IsActiveUnit || (!activeUnits_.HasAirFacilities && !activeUnits_.HasDockFacilities))
				{
					continue;
				}
				if (activeUnits_.IsGroupMember())
				{
					if (activeUnits_.IsFacility)
					{
						Group parentGroup = activeUnits_.GetParentGroup();
						if (parentGroup != null && parentGroup.HasAirFacilities)
						{
							continue;
						}
					}
					Group parentGroup2 = activeUnits_.GetParentGroup();
					if (parentGroup2 != null && parentGroup2.HasDockFacilities)
					{
						continue;
					}
				}
				GlobalVariables.ActiveUnitType targetType = ((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType;
				if (targetType == GlobalVariables.ActiveUnitType.Aircraft)
				{
					if (!activeUnits_.HasAirFacilities)
					{
						continue;
					}
				}
				else if ((int)(targetType - 2) > 1 || !activeUnits_.HasDockFacilities)
				{
					continue;
				}
				comboBoxItem7 = new ComboBoxItem();
				comboBoxItem7.Content = activeUnits_.Name;
				comboBoxItem7.Tag = activeUnits_.ObjectID;
				CB_BaseStatusCheck_Base.Items.Add(comboBoxItem7);
				string targetBase = ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase;
				if (targetBase != null && targetBase.Length > 0 && (string.Equals(activeUnits_.Name, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, ((EventTrigger_UnitBaseStatus)theTrigger).TargetBase, StringComparison.OrdinalIgnoreCase)))
				{
					CB_BaseStatusCheck_Base.SelectedIndex = CB_BaseStatusCheck_Base.Items.Count - 1;
					text = activeUnits_.GetUnitSide().ObjectID;
				}
			}
			CB_BaseStatusCheck_BaseSide.Items.Clear();
			CB_BaseStatusCheck_BaseSide.DisplayMember = "Content";
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array5 = sides_ReadOnly;
			foreach (Side side in array5)
			{
				comboBoxItem7 = new ComboBoxItem();
				comboBoxItem7.Content = side.Name;
				comboBoxItem7.Tag = side.ObjectID;
				CB_BaseStatusCheck_BaseSide.Items.Add(comboBoxItem7);
				if (text != null && text.Length > 0 && string.Equals(side.ObjectID, text, StringComparison.OrdinalIgnoreCase))
				{
					CB_BaseStatusCheck_BaseSide.SelectedIndex = CB_BaseStatusCheck_BaseSide.Items.Count - 1;
				}
			}
			break;
		}
		}
		TC_TriggerOptions.HideNonSelectedTabs();
	}

	private void CountParam(object sender, EventArgs e)
	{
		Close();
	}

	private void CustomizeParam(object sender, EventArgs e)
	{
		if (Action == _FormAction.AddNew)
		{
			Client.CurrentScenario.EventTriggers.Add(theTrigger.ObjectID, theTrigger);
		}
		Close();
	}

	private void CloneParam(object object_0)
	{
		theTrigger.Description = TextBox1.Text;
	}

	private void ConnectParam(object sender, EventArgs e)
	{
		((EventTrigger_Points)theTrigger).SideID = Conversions.ToString(NewLateBinding.LateGet(CB_Points_Sides.SelectedItem, null, "tag", new object[0], null, null, null));
	}

	private void MoveParam(object sender, EventArgs e)
	{
		((EventTrigger_Points)theTrigger).ReachDirection = (EventTrigger_Points.PointReachDirection)CB_Points_ReachDirection.SelectedIndex;
	}

	private void DeleteParam(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_Points.Value))
		{
			((EventTrigger_Points)theTrigger).PointValue = Convert.ToInt32(NUD_Points.Value);
		}
	}

	private void AddParam(object sender, EventArgs e)
	{
		List<string> list = DTP_StartTime.Text.Split(':').ToList();
		if (Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2]))
		{
			List<string> list2 = DTP_StartDate.Text.Split('-').ToList();
			if (Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1]) & Versioned.IsNumeric(list2[2]))
			{
				((EventTrigger_Time)theTrigger).Time = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
				Label6.Text = "目前设定：" + ((EventTrigger_Time)theTrigger).Time.ToShortDateString() + " - " + ((EventTrigger_Time)theTrigger).Time.ToShortTimeString();
			}
		}
	}

	private void DestroyParam(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_DamagePercent.Value) && !Information.IsNothing(theTrigger))
		{
			((EventTrigger_UnitDamaged)theTrigger).DamagePercent = Convert.ToByte(NUD_DamagePercent.Value);
		}
	}

	private void ComputeParam(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Days.Text))
		{
			TB_Days.Text = "0";
		}
		if (Versioned.IsNumeric(TB_Days.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing(theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void PatchParam(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Hours.Text))
		{
			TB_Hours.Text = "0";
		}
		if (Versioned.IsNumeric(TB_Hours.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing(theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void SelectParam(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Mins.Text))
		{
			TB_Mins.Text = "0";
		}
		if (Versioned.IsNumeric(TB_Mins.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing(theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void CallParam(object object_0)
	{
		if (string.IsNullOrEmpty(TB_Secs.Text))
		{
			TB_Secs.Text = "0";
		}
		if (Versioned.IsNumeric(TB_Secs.Text))
		{
			TimeSpan timeSpan = new TimeSpan(Conversions.ToInteger(TB_Days.Text), Conversions.ToInteger(TB_Hours.Text), Conversions.ToInteger(TB_Mins.Text), Conversions.ToInteger(TB_Secs.Text));
			if (!Information.IsNothing(theTrigger))
			{
				((EventTrigger_UnitRemainsInArea)theTrigger).TimeDuration = (long)Math.Round(timeSpan.TotalSeconds);
			}
		}
	}

	private void LogoutParam(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theTrigger))
		{
			((EventTrigger_UnitEntersArea)theTrigger).Modifier_NOT = CB_UnitEntersArea_ModifierNOT.Checked;
			if (CB_UnitEntersArea_ModifierNOT.Checked)
			{
				CB_UnitEntersArea_ModifierEXIT.Checked = false;
				Refresh();
			}
		}
	}

	private void ViewParam(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theTrigger))
		{
			((EventTrigger_UnitEntersArea)theTrigger).Modifier_EXIT = CB_UnitEntersArea_ModifierEXIT.Checked;
			if (CB_UnitEntersArea_ModifierEXIT.Checked)
			{
				CB_UnitEntersArea_ModifierNOT.Checked = false;
				Refresh();
			}
		}
	}

	private void ValidateParam(object sender, EventArgs e)
	{
		if (Information.IsNothing(theTrigger))
		{
			return;
		}
		List<string> list = DTP_EnterArea_ETOA_Time.Text.Split(':').ToList();
		if (!(Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2])))
		{
			return;
		}
		List<string> list2 = DTP_EnterArea_ETOA_Date.Text.Split('-').ToList();
		if (!(Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1]) & Versioned.IsNumeric(list2[2])))
		{
			return;
		}
		((EventTrigger_UnitEntersArea)theTrigger).dateTime_0 = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
		Label_UnitEntersArea_Earliest.Text = "最早：" + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_0.ToShortDateString() + " - " + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_0.ToShortTimeString();
		List<string> list3 = DTP_EnterArea_LTOA_Time.Text.Split(':').ToList();
		if (Versioned.IsNumeric(list3[0]) & Versioned.IsNumeric(list3[1]) & Versioned.IsNumeric(list3[2]))
		{
			List<string> list4 = DTP_EnterArea_LTOA_Date.Text.Split('-').ToList();
			if (Versioned.IsNumeric(list4[0]) & Versioned.IsNumeric(list4[1]) & Versioned.IsNumeric(list4[2]))
			{
				((EventTrigger_UnitEntersArea)theTrigger).dateTime_1 = new DateTime(Conversions.ToInteger(list4[0]), Conversions.ToInteger(list4[1]), Conversions.ToInteger(list4[2]), Conversions.ToInteger(list3[0]), Conversions.ToInteger(list3[1]), Conversions.ToInteger(list3[2]));
				Label_UnitEntersArea_Latest.Text = "最新：" + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_1.ToShortDateString() + " - " + ((EventTrigger_UnitEntersArea)theTrigger).dateTime_1.ToShortTimeString();
			}
		}
	}

	private void LoginParam(object sender, EventArgs e)
	{
		List<string> list = DTP_EarliestTime.Text.Split(':').ToList();
		if (!(Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2])))
		{
			return;
		}
		List<string> list2 = DTP_EarliestDate.Text.Split('-').ToList();
		if (!(Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1]) & Versioned.IsNumeric(list2[2])))
		{
			return;
		}
		((EventTrigger_RandomTime)theTrigger).EarliestTime = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
		List<string> list3 = DTP_LatestTime.Text.Split(':').ToList();
		if (!(Versioned.IsNumeric(list3[0]) & Versioned.IsNumeric(list3[1]) & Versioned.IsNumeric(list3[2])))
		{
			return;
		}
		List<string> list4 = DTP_LatestDate.Text.Split('-').ToList();
		if (Versioned.IsNumeric(list4[0]) & Versioned.IsNumeric(list4[1]) & Versioned.IsNumeric(list4[2]))
		{
			((EventTrigger_RandomTime)theTrigger).LatestTime = new DateTime(Conversions.ToInteger(list4[0]), Conversions.ToInteger(list4[1]), Conversions.ToInteger(list4[2]), Conversions.ToInteger(list3[0]), Conversions.ToInteger(list3[1]), Conversions.ToInteger(list3[2]));
			if (DateTime.Compare(((EventTrigger_RandomTime)theTrigger).EarliestTime, ((EventTrigger_RandomTime)theTrigger).LatestTime) <= 0)
			{
				Label8.Text = "当前设置: \r\n最早: " + ((EventTrigger_RandomTime)theTrigger).EarliestTime.ToShortDateString() + " - " + ((EventTrigger_RandomTime)theTrigger).EarliestTime.ToShortTimeString() + "\r\n最晚： " + ((EventTrigger_RandomTime)theTrigger).LatestTime.ToShortDateString() + " - " + ((EventTrigger_RandomTime)theTrigger).LatestTime.ToShortTimeString();
			}
			else
			{
				DarkMessageBox.ShowError("错误！最早时间不能超过最晚时间！", "");
				Label8.Text = "错误！最早时间不能超过最晚时间";
			}
		}
	}

	private void GetParam(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void WriteParam(object sender, EventArgs e)
	{
		((EventTrigger_UnitDetected)theTrigger).DetectorSideID = Conversions.ToString(NewLateBinding.LateGet(CB_UnitDetected_Sides.SelectedItem, null, "tag", new object[0], null, null, null));
	}

	private void NewParam(object sender, FormClosedEventArgs e)
	{
		TB_Days.TextChanged -= ComputeParam;
		TB_Hours.TextChanged -= PatchParam;
		TB_Mins.TextChanged -= SelectParam;
		TB_Secs.TextChanged -= CallParam;
	}

	private void PushParam(object sender, EventArgs e)
	{
		((EventTrigger_UnitDetected)theTrigger).MinimumClassificationLevel = (Contact_Base.IdentificationStatus)CB_MCL.SelectedIndex;
	}

	private void InvokeParam(object sender, EventArgs e)
	{
		if (theTrigger != null)
		{
			switch (CB_RegularTimeInterval.SelectedIndex)
			{
			case 0:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.EveryPulse;
				break;
			case 1:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.OneSecond;
				break;
			case 2:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FiveSeconds;
				break;
			case 3:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FifteenSeconds;
				break;
			case 4:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.ThirtySeconds;
				break;
			case 5:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.OneMinute;
				break;
			case 6:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FiveMinutes;
				break;
			case 7:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.FifteenMinutes;
				break;
			case 8:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.ThirtyMinutes;
				break;
			case 9:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.OneHour;
				break;
			case 10:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.SixHours;
				break;
			case 11:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.TwelveHours;
				break;
			case 12:
				((EventTrigger_RegularTime)theTrigger).Interval = EventTrigger_RegularTime.RegularTimeInterval.TwentyFourHours;
				break;
			}
		}
	}

	private void SetupParam(object sender, EventArgs e)
	{
		if (NewLateBinding.LateGet(CB_BaseStatusCheck_Condition.SelectedItem, null, "tag", new object[0], null, null, null) == null)
		{
			DarkMessageBox.ShowError("Error! A condition must be set for the event", "");
		}
		else
		{
			((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(CB_BaseStatusCheck_Condition.SelectedItem, null, "tag", new object[0], null, null, null));
		}
	}

	private void ExcludeParam(object sender, EventArgs e)
	{
		CB_BaseStatusCheck_Condition.Items.Clear();
		CB_BaseStatusCheck_Condition.DisplayMember = "Content";
		switch (((EventTrigger_UnitBaseStatus)theTrigger).TargetFilter.TargetType)
		{
		default:
		{
			ComboBoxItem comboBoxItem3 = new ComboBoxItem();
			if (CB_BaseStatusCheck_Condition.Items.Count == 0)
			{
				comboBoxItem3.Content = "Not valid for condition check";
				comboBoxItem3.Tag = null;
				CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem3);
				CB_BaseStatusCheck_Condition.SelectedIndex = 0;
			}
			break;
		}
		case GlobalVariables.ActiveUnitType.Ship:
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			byte[] array2 = (byte[])Enum.GetValues(typeof(ActiveUnit_DockingOps._DockingOpsCondition));
			byte[] array4 = array2;
			foreach (byte b2 in array4)
			{
				ComboBoxItem comboBoxItem4 = new ComboBoxItem();
				if (CB_BaseStatusCheck_Condition.Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
				{
					comboBoxItem4.Content = "No conditon set";
					comboBoxItem4.Tag = null;
					CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem4);
					CB_BaseStatusCheck_Condition.SelectedIndex = 0;
				}
				comboBoxItem4 = new ComboBoxItem();
				ComboBoxItem comboBoxItem5 = comboBoxItem4;
				ActiveUnit_DockingOps._DockingOpsCondition dockingOpsCondition = (ActiveUnit_DockingOps._DockingOpsCondition)b2;
				comboBoxItem5.Content = dockingOpsCondition.ToString();
				comboBoxItem4.Tag = b2;
				CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem4);
				if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b2 >= 0 && Operators.ConditionalCompareObjectEqual(b2, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, TextCompare: true))
				{
					CB_BaseStatusCheck_Condition.SelectedIndex = CB_BaseStatusCheck_Condition.Items.Count - 1;
				}
			}
			break;
		}
		case GlobalVariables.ActiveUnitType.Aircraft:
		{
			byte[] array = (byte[])Enum.GetValues(typeof(Aircraft_AirOps._AirOpsCondition));
			byte[] array3 = array;
			foreach (byte b in array3)
			{
				switch (b)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 12:
				case 17:
				case 18:
				case 22:
				{
					ComboBoxItem comboBoxItem = new ComboBoxItem();
					if (CB_BaseStatusCheck_Condition.Items.Count == 0 && ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition == null)
					{
						comboBoxItem.Content = "No conditon set";
						comboBoxItem.Tag = null;
						CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem);
						CB_BaseStatusCheck_Condition.SelectedIndex = 0;
					}
					comboBoxItem = new ComboBoxItem();
					ComboBoxItem comboBoxItem2 = comboBoxItem;
					Aircraft_AirOps._AirOpsCondition airOpsCondition = (Aircraft_AirOps._AirOpsCondition)b;
					comboBoxItem2.Content = airOpsCondition.ToString();
					comboBoxItem.Tag = b;
					CB_BaseStatusCheck_Condition.Items.Add(comboBoxItem);
					if (((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition != null && !string.IsNullOrEmpty(((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition.ToString()) && b >= 0 && Operators.ConditionalCompareObjectEqual(b, ((EventTrigger_UnitBaseStatus)theTrigger).TargetCondition, TextCompare: true))
					{
						CB_BaseStatusCheck_Condition.SelectedIndex = CB_BaseStatusCheck_Condition.Items.Count - 1;
					}
					break;
				}
				}
			}
			break;
		}
		}
		Refresh();
	}
}
