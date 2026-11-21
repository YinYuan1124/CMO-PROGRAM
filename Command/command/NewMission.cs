using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Filter;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class NewMission : DarkSecondaryFormBase
{
	private IContainer m_FilterPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_TestsPublisher;

	[AccessedThroughProperty("TextBox_Name")]
	[CompilerGenerated]
	private DarkUITextBox interpreterPublisher;

	[AccessedThroughProperty("CB_MissionClass")]
	[CompilerGenerated]
	private DarkUIComboBox _ContainerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MissionClass")]
	private DarkLabel composerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MissionType")]
	private DarkLabel modelPublisher;

	[AccessedThroughProperty("CB_MissionType")]
	[CompilerGenerated]
	private DarkUIComboBox m_AdvisorPublisher;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _CustomerPublisher;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton m_SerializerPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MissionStatus")]
	private DarkUIComboBox refPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MissionStatus")]
	private DarkLabel errorPublisher;

	[AccessedThroughProperty("Label_Category")]
	[CompilerGenerated]
	private DarkLabel m_CodePublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Category")]
	private DarkUIComboBox m_ConnectionPublisher;

	[AccessedThroughProperty("GroupBox_ActivationTime")]
	[CompilerGenerated]
	private DarkGroupBox statusPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Clear_ActivationTime")]
	private DarkUIButton proccesorPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_ActivationTime")]
	private DarkMaskedTextBox strategyPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_ActivationDate")]
	private DarkMaskedTextBox _ConfigurationPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox_DeactivationTime")]
	private DarkGroupBox resolverPublisher;

	[AccessedThroughProperty("CheckBox_OrderRTB")]
	[CompilerGenerated]
	private DarkCheckBox serverPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Clear_DeactivationTime")]
	private DarkUIButton m_SchemaPublisher;

	[AccessedThroughProperty("DateTimePicker_DeactivationTime")]
	[CompilerGenerated]
	private DarkMaskedTextBox _UtilsPublisher;

	[AccessedThroughProperty("DateTimePicker_DeactivationDate")]
	[CompilerGenerated]
	private DarkMaskedTextBox singletonPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label114")]
	private DarkLabel recordPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox_TakeOffTime")]
	private DarkGroupBox exceptionPublisher;

	[AccessedThroughProperty("DateTimePicker_TakeOffTime")]
	[CompilerGenerated]
	private DarkMaskedTextBox _AttrPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("DateTimePicker_TakeOffDate")]
	private DarkMaskedTextBox m_VisitorPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Label162")]
	private DarkLabel m_ExporterPublisher;

	[AccessedThroughProperty("Label169")]
	[CompilerGenerated]
	private DarkLabel prototypePublisher;

	[AccessedThroughProperty("DateTimePicker_TimeOnTargetTime")]
	[CompilerGenerated]
	private DarkMaskedTextBox m_ItemPublisher;

	[AccessedThroughProperty("DateTimePicker_TimeOnTargetDate")]
	[CompilerGenerated]
	private DarkMaskedTextBox m_SetterPublisher;

	[AccessedThroughProperty("Label170")]
	[CompilerGenerated]
	private DarkLabel creatorPublisher;

	[AccessedThroughProperty("Label171")]
	[CompilerGenerated]
	private DarkLabel templatePublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Clear_TakeOffTime")]
	private DarkUIButton m_MappingPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Clear_TimeOnTarget")]
	private DarkUIButton mockPublisher;

	[AccessedThroughProperty("CB_ParentPool")]
	[CompilerGenerated]
	private DarkUIComboBox tagPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_OpenMissionEditor")]
	private DarkCheckBox queuePublisher;

	private bool regPublisher;

	private bool paramPublisher;

	private bool _PagePublisher;

	private bool rulesPublisher;

	private bool methodPublisher;

	private DateTime? m_ServicePublisher;

	private DateTime? systemPublisher;

	private DateTime? candidatePublisher;

	private DateTime? basePublisher;

	private Keys[] m_PolicyPublisher;

	public static bool CreatingNewMission;

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_TestsPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TestsPublisher = value;
		}
	}

	internal DarkUITextBox TextBox_Name
	{
		[CompilerGenerated]
		get
		{
			return interpreterPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = InitInterruptibleInterpreter;
			DarkUITextBox darkUITextBox = interpreterPublisher;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			interpreterPublisher = value;
			darkUITextBox = interpreterPublisher;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal DarkUIComboBox CB_MissionClass
	{
		[CompilerGenerated]
		get
		{
			return _ContainerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleInterpreter;
			DarkUIComboBox containerPublisher = _ContainerPublisher;
			if (containerPublisher != null)
			{
				containerPublisher.SelectedIndexChanged -= value2;
			}
			_ContainerPublisher = value;
			containerPublisher = _ContainerPublisher;
			if (containerPublisher != null)
			{
				containerPublisher.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkLabel Label_MissionClass
	{
		[CompilerGenerated]
		get
		{
			return composerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			composerPublisher = value;
		}
	}

	internal DarkLabel Label_MissionType
	{
		[CompilerGenerated]
		get
		{
			return modelPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelPublisher = value;
		}
	}

	internal DarkUIComboBox CB_MissionType
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorPublisher = value;
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _CustomerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleInterpreter;
			DarkUIButton customerPublisher = _CustomerPublisher;
			if (customerPublisher != null)
			{
				customerPublisher.Click -= value2;
			}
			_CustomerPublisher = value;
			customerPublisher = _CustomerPublisher;
			if (customerPublisher != null)
			{
				customerPublisher.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleInterpreter;
			DarkUIButton serializerPublisher = m_SerializerPublisher;
			if (serializerPublisher != null)
			{
				serializerPublisher.Click -= value2;
			}
			m_SerializerPublisher = value;
			serializerPublisher = m_SerializerPublisher;
			if (serializerPublisher != null)
			{
				serializerPublisher.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_MissionStatus
	{
		[CompilerGenerated]
		get
		{
			return refPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			refPublisher = value;
		}
	}

	internal DarkLabel Label_MissionStatus
	{
		[CompilerGenerated]
		get
		{
			return errorPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			errorPublisher = value;
		}
	}

	internal DarkLabel Label_Category
	{
		[CompilerGenerated]
		get
		{
			return m_CodePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodePublisher = value;
		}
	}

	internal DarkUIComboBox CB_Category
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleInterpreter;
			DarkUIComboBox connectionPublisher = m_ConnectionPublisher;
			if (connectionPublisher != null)
			{
				connectionPublisher.SelectedIndexChanged -= value2;
			}
			m_ConnectionPublisher = value;
			connectionPublisher = m_ConnectionPublisher;
			if (connectionPublisher != null)
			{
				connectionPublisher.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal FlowLayoutPanel FlowLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkGroupBox GroupBox_ActivationTime
	{
		[CompilerGenerated]
		get
		{
			return statusPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			statusPublisher = value;
		}
	}

	internal DarkUIButton Button_Clear_ActivationTime
	{
		[CompilerGenerated]
		get
		{
			return proccesorPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcInterruptibleInterpreter;
			DarkUIButton darkUIButton = proccesorPublisher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			proccesorPublisher = value;
			darkUIButton = proccesorPublisher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_ActivationTime
	{
		[CompilerGenerated]
		get
		{
			return strategyPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertInterruptibleInterpreter;
			EventHandler value3 = PrepareInterruptibleInterpreter;
			DarkMaskedTextBox darkMaskedTextBox = strategyPublisher;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter -= value2;
				darkMaskedTextBox.Leave -= value3;
			}
			strategyPublisher = value;
			darkMaskedTextBox = strategyPublisher;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter += value2;
				darkMaskedTextBox.Leave += value3;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_ActivationDate
	{
		[CompilerGenerated]
		get
		{
			return _ConfigurationPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableInterruptibleInterpreter;
			EventHandler value3 = UpdateInterruptibleInterpreter;
			EventHandler value4 = CollectInterruptibleInterpreter;
			DarkMaskedTextBox configurationPublisher = _ConfigurationPublisher;
			if (configurationPublisher != null)
			{
				configurationPublisher.Enter -= value2;
				configurationPublisher.Leave -= value3;
				configurationPublisher.Leave -= value4;
			}
			_ConfigurationPublisher = value;
			configurationPublisher = _ConfigurationPublisher;
			if (configurationPublisher != null)
			{
				configurationPublisher.Enter += value2;
				configurationPublisher.Leave += value3;
				configurationPublisher.Leave += value4;
			}
		}
	}

	[field: AccessedThroughProperty("Label101")]
	internal DarkLabel Label101
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label102")]
	internal DarkLabel Label102
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkGroupBox GroupBox_DeactivationTime
	{
		[CompilerGenerated]
		get
		{
			return resolverPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			resolverPublisher = value;
		}
	}

	[field: AccessedThroughProperty("CheckBox_DeleteMission")]
	internal DarkCheckBox CheckBox_DeleteMission
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CheckBox_OrderRTB
	{
		[CompilerGenerated]
		get
		{
			return serverPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverPublisher = value;
		}
	}

	[field: AccessedThroughProperty("CheckBox_UnassignUnits")]
	internal DarkCheckBox CheckBox_UnassignUnits
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_Clear_DeactivationTime
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateInterruptibleInterpreter;
			DarkUIButton schemaPublisher = m_SchemaPublisher;
			if (schemaPublisher != null)
			{
				schemaPublisher.Click -= value2;
			}
			m_SchemaPublisher = value;
			schemaPublisher = m_SchemaPublisher;
			if (schemaPublisher != null)
			{
				schemaPublisher.Click += value2;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_DeactivationTime
	{
		[CompilerGenerated]
		get
		{
			return _UtilsPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartInterruptibleInterpreter;
			EventHandler value3 = TestInterruptibleInterpreter;
			DarkMaskedTextBox utilsPublisher = _UtilsPublisher;
			if (utilsPublisher != null)
			{
				utilsPublisher.Enter -= value2;
				utilsPublisher.Leave -= value3;
			}
			_UtilsPublisher = value;
			utilsPublisher = _UtilsPublisher;
			if (utilsPublisher != null)
			{
				utilsPublisher.Enter += value2;
				utilsPublisher.Leave += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label112")]
	internal DarkLabel Label112
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkMaskedTextBox DateTimePicker_DeactivationDate
	{
		[CompilerGenerated]
		get
		{
			return singletonPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectInterruptibleInterpreter;
			EventHandler value3 = VisitInterruptibleInterpreter;
			EventHandler value4 = OrderInterruptibleInterpreter;
			DarkMaskedTextBox darkMaskedTextBox = singletonPublisher;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter -= value2;
				darkMaskedTextBox.Leave -= value3;
				darkMaskedTextBox.Leave -= value4;
			}
			singletonPublisher = value;
			darkMaskedTextBox = singletonPublisher;
			if (darkMaskedTextBox != null)
			{
				darkMaskedTextBox.Enter += value2;
				darkMaskedTextBox.Leave += value3;
				darkMaskedTextBox.Leave += value4;
			}
		}
	}

	internal DarkLabel Label114
	{
		[CompilerGenerated]
		get
		{
			return recordPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			recordPublisher = value;
		}
	}

	internal DarkGroupBox GroupBox_TakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return exceptionPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exceptionPublisher = value;
		}
	}

	internal DarkMaskedTextBox DateTimePicker_TakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return _AttrPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleInterpreter;
			EventHandler value3 = ListInterruptibleInterpreter;
			DarkMaskedTextBox attrPublisher = _AttrPublisher;
			if (attrPublisher != null)
			{
				attrPublisher.Enter -= value2;
				attrPublisher.Leave -= value3;
			}
			_AttrPublisher = value;
			attrPublisher = _AttrPublisher;
			if (attrPublisher != null)
			{
				attrPublisher.Enter += value2;
				attrPublisher.Leave += value3;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_TakeOffDate
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopInterruptibleInterpreter;
			EventHandler value3 = CancelInterruptibleInterpreter;
			EventHandler value4 = RegisterInterruptibleInterpreter;
			DarkMaskedTextBox visitorPublisher = m_VisitorPublisher;
			if (visitorPublisher != null)
			{
				visitorPublisher.Enter -= value2;
				visitorPublisher.Leave -= value3;
				visitorPublisher.Leave -= value4;
			}
			m_VisitorPublisher = value;
			visitorPublisher = m_VisitorPublisher;
			if (visitorPublisher != null)
			{
				visitorPublisher.Enter += value2;
				visitorPublisher.Leave += value3;
				visitorPublisher.Leave += value4;
			}
		}
	}

	internal DarkLabel Label162
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterPublisher = value;
		}
	}

	internal DarkLabel Label169
	{
		[CompilerGenerated]
		get
		{
			return prototypePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			prototypePublisher = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox_TimeOnTarget")]
	internal DarkGroupBox GroupBox_TimeOnTarget
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkMaskedTextBox DateTimePicker_TimeOnTargetTime
	{
		[CompilerGenerated]
		get
		{
			return m_ItemPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterruptibleInterpreter;
			EventHandler value3 = StartInterruptibleInterpreter;
			DarkMaskedTextBox itemPublisher = m_ItemPublisher;
			if (itemPublisher != null)
			{
				itemPublisher.Enter -= value2;
				itemPublisher.Leave -= value3;
			}
			m_ItemPublisher = value;
			itemPublisher = m_ItemPublisher;
			if (itemPublisher != null)
			{
				itemPublisher.Enter += value2;
				itemPublisher.Leave += value3;
			}
		}
	}

	internal DarkMaskedTextBox DateTimePicker_TimeOnTargetDate
	{
		[CompilerGenerated]
		get
		{
			return m_SetterPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveInterruptibleInterpreter;
			EventHandler value3 = PostInterruptibleInterpreter;
			EventHandler value4 = ManageInterruptibleInterpreter;
			DarkMaskedTextBox setterPublisher = m_SetterPublisher;
			if (setterPublisher != null)
			{
				setterPublisher.Enter -= value2;
				setterPublisher.Leave -= value3;
				setterPublisher.Leave -= value4;
			}
			m_SetterPublisher = value;
			setterPublisher = m_SetterPublisher;
			if (setterPublisher != null)
			{
				setterPublisher.Enter += value2;
				setterPublisher.Leave += value3;
				setterPublisher.Leave += value4;
			}
		}
	}

	internal DarkLabel Label170
	{
		[CompilerGenerated]
		get
		{
			return creatorPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			creatorPublisher = value;
		}
	}

	internal DarkLabel Label171
	{
		[CompilerGenerated]
		get
		{
			return templatePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			templatePublisher = value;
		}
	}

	internal DarkUIButton Button_Clear_TakeOffTime
	{
		[CompilerGenerated]
		get
		{
			return m_MappingPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushInterruptibleInterpreter;
			DarkUIButton mappingPublisher = m_MappingPublisher;
			if (mappingPublisher != null)
			{
				mappingPublisher.Click -= value2;
			}
			m_MappingPublisher = value;
			mappingPublisher = m_MappingPublisher;
			if (mappingPublisher != null)
			{
				mappingPublisher.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_Clear_TimeOnTarget
	{
		[CompilerGenerated]
		get
		{
			return mockPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotInterruptibleInterpreter;
			DarkUIButton darkUIButton = mockPublisher;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			mockPublisher = value;
			darkUIButton = mockPublisher;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_ParentPool
	{
		[CompilerGenerated]
		get
		{
			return tagPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tagPublisher = value;
		}
	}

	[field: AccessedThroughProperty("Label_ParentPool")]
	internal DarkLabel Label_ParentPool
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_OpenMissionEditor
	{
		[CompilerGenerated]
		get
		{
			return queuePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptibleInterpreter;
			DarkCheckBox darkCheckBox = queuePublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			queuePublisher = value;
			darkCheckBox = queuePublisher;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	static NewMission()
	{
		CreatingNewMission = false;
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_FilterPublisher != null)
			{
				m_FilterPublisher.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ChangeInterruptibleInterpreter()
	{
		Label1 = new DarkLabel();
		TextBox_Name = new DarkUITextBox();
		CB_MissionClass = new DarkUIComboBox();
		Label_MissionClass = new DarkLabel();
		Label_MissionType = new DarkLabel();
		CB_MissionType = new DarkUIComboBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		CB_OpenMissionEditor = new DarkCheckBox();
		CB_MissionStatus = new DarkUIComboBox();
		Label_MissionStatus = new DarkLabel();
		Label_Category = new DarkLabel();
		CB_Category = new DarkUIComboBox();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		GroupBox_ActivationTime = new DarkGroupBox();
		Button_Clear_ActivationTime = new DarkUIButton();
		DateTimePicker_ActivationTime = new DarkMaskedTextBox();
		DateTimePicker_ActivationDate = new DarkMaskedTextBox();
		Label101 = new DarkLabel();
		Label102 = new DarkLabel();
		GroupBox_DeactivationTime = new DarkGroupBox();
		CheckBox_DeleteMission = new DarkCheckBox();
		CheckBox_OrderRTB = new DarkCheckBox();
		CheckBox_UnassignUnits = new DarkCheckBox();
		Button_Clear_DeactivationTime = new DarkUIButton();
		DateTimePicker_DeactivationTime = new DarkMaskedTextBox();
		Label112 = new DarkLabel();
		DateTimePicker_DeactivationDate = new DarkMaskedTextBox();
		Label114 = new DarkLabel();
		GroupBox_TakeOffTime = new DarkGroupBox();
		Button_Clear_TakeOffTime = new DarkUIButton();
		DateTimePicker_TakeOffTime = new DarkMaskedTextBox();
		DateTimePicker_TakeOffDate = new DarkMaskedTextBox();
		Label162 = new DarkLabel();
		Label169 = new DarkLabel();
		GroupBox_TimeOnTarget = new DarkGroupBox();
		Button_Clear_TimeOnTarget = new DarkUIButton();
		DateTimePicker_TimeOnTargetTime = new DarkMaskedTextBox();
		DateTimePicker_TimeOnTargetDate = new DarkMaskedTextBox();
		Label170 = new DarkLabel();
		Label171 = new DarkLabel();
		CB_ParentPool = new DarkUIComboBox();
		Label_ParentPool = new DarkLabel();
		FlowLayoutPanel1.SuspendLayout();
		GroupBox_ActivationTime.SuspendLayout();
		GroupBox_DeactivationTime.SuspendLayout();
		GroupBox_TakeOffTime.SuspendLayout();
		GroupBox_TimeOnTarget.SuspendLayout();
		SuspendLayout();
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(2, 42);
		Label1.Name = "Label1";
		Label1.Size = new Size(56, 23);
		Label1.TabIndex = 0;
		Label1.Text = "名称:";
		TextBox_Name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox_Name.AutoCompleteCustomSource = null;
		TextBox_Name.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_Name.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_Name.BackColor = Color.Transparent;
		TextBox_Name.Font = new Font("Segoe UI", 10f);
		TextBox_Name.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_Name.Image = null;
		TextBox_Name.Lines = null;
		TextBox_Name.Location = new Point(78, 38);
		TextBox_Name.MaxLength = 32767;
		TextBox_Name.Multiline = false;
		TextBox_Name.Name = "TextBox_Name";
		TextBox_Name.ReadOnly = false;
		TextBox_Name.ScrollBars = ScrollBars.None;
		TextBox_Name.SelectionStart = 0;
		TextBox_Name.Size = new Size(266, 20);
		TextBox_Name.TabIndex = 1;
		TextBox_Name.TextAlign = HorizontalAlignment.Left;
		TextBox_Name.UseSystemPasswordChar = false;
		TextBox_Name.WatermarkText = "";
		CB_MissionClass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_MissionClass.BackColor = Color.Transparent;
		CB_MissionClass.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MissionClass.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MissionClass.Font = new Font("Segoe UI", 7f);
		CB_MissionClass.FormattingEnabled = true;
		CB_MissionClass.Location = new Point(78, 64);
		CB_MissionClass.Name = "CB_MissionClass";
		CB_MissionClass.Size = new Size(266, 21);
		CB_MissionClass.TabIndex = 2;
		Label_MissionClass.AutoSize = true;
		Label_MissionClass.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MissionClass.Location = new Point(2, 68);
		Label_MissionClass.Name = "Label_MissionClass";
		Label_MissionClass.Size = new Size(37, 15);
		Label_MissionClass.TabIndex = 3;
		Label_MissionClass.Text = "类别：";
		Label_MissionType.AutoSize = true;
		Label_MissionType.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MissionType.Location = new Point(1, 97);
		Label_MissionType.Name = "Label_MissionType";
		Label_MissionType.Size = new Size(34, 15);
		Label_MissionType.TabIndex = 4;
		Label_MissionType.Text = "类型：";
		CB_MissionType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_MissionType.BackColor = Color.Transparent;
		CB_MissionType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MissionType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MissionType.Font = new Font("Segoe UI", 7f);
		CB_MissionType.FormattingEnabled = true;
		CB_MissionType.Location = new Point(78, 93);
		CB_MissionType.Name = "CB_MissionType";
		CB_MissionType.Size = new Size(266, 21);
		CB_MissionType.TabIndex = 5;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(5, 200);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 6;
		Button1.Text = "确定";
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(461, 202);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 7;
		Button2.Text = "取消";
		CB_OpenMissionEditor.AutoSize = true;
		CB_OpenMissionEditor.Location = new Point(5, 179);
		CB_OpenMissionEditor.Name = "CB_OpenMissionEditor";
		CB_OpenMissionEditor.Size = new Size(178, 19);
		CB_OpenMissionEditor.TabIndex = 8;
		CB_OpenMissionEditor.Text = "打开Mission Editor窗口";
		CB_MissionStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_MissionStatus.BackColor = Color.Transparent;
		CB_MissionStatus.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MissionStatus.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MissionStatus.Font = new Font("Segoe UI", 7f);
		CB_MissionStatus.FormattingEnabled = true;
		CB_MissionStatus.Items.AddRange(new object[2] { "启用", "未启用" });
		CB_MissionStatus.Location = new Point(78, 123);
		CB_MissionStatus.Name = "CB_MissionStatus";
		CB_MissionStatus.Size = new Size(266, 21);
		CB_MissionStatus.TabIndex = 30;
		Label_MissionStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Label_MissionStatus.AutoSize = true;
		Label_MissionStatus.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MissionStatus.Location = new Point(1, 127);
		Label_MissionStatus.Name = "Label_MissionStatus";
		Label_MissionStatus.Size = new Size(42, 15);
		Label_MissionStatus.TabIndex = 29;
		Label_MissionStatus.Text = "状态：";
		Label_Category.AutoSize = true;
		Label_Category.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Category.Location = new Point(2, 12);
		Label_Category.Name = "Label_Category";
		Label_Category.Size = new Size(58, 15);
		Label_Category.TabIndex = 32;
		Label_Category.Text = "类别：";
		CB_Category.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Category.BackColor = Color.Transparent;
		CB_Category.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Category.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Category.Font = new Font("Segoe UI", 7f);
		CB_Category.FormattingEnabled = true;
		CB_Category.Location = new Point(78, 8);
		CB_Category.Name = "CB_Category";
		CB_Category.Size = new Size(266, 21);
		CB_Category.TabIndex = 31;
		FlowLayoutPanel1.Controls.Add(GroupBox_ActivationTime);
		FlowLayoutPanel1.Controls.Add(GroupBox_DeactivationTime);
		FlowLayoutPanel1.Controls.Add(GroupBox_TakeOffTime);
		FlowLayoutPanel1.Controls.Add(GroupBox_TimeOnTarget);
		FlowLayoutPanel1.Location = new Point(347, 8);
		FlowLayoutPanel1.Margin = new Padding(0);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(188, 195);
		FlowLayoutPanel1.TabIndex = 47;
		GroupBox_ActivationTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox_ActivationTime.Controls.Add(Button_Clear_ActivationTime);
		GroupBox_ActivationTime.Controls.Add(DateTimePicker_ActivationTime);
		GroupBox_ActivationTime.Controls.Add(DateTimePicker_ActivationDate);
		GroupBox_ActivationTime.Controls.Add(Label101);
		GroupBox_ActivationTime.Controls.Add(Label102);
		GroupBox_ActivationTime.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_ActivationTime.Location = new Point(3, 3);
		GroupBox_ActivationTime.Name = "GroupBox_ActivationTime";
		GroupBox_ActivationTime.Size = new Size(183, 61);
		GroupBox_ActivationTime.TabIndex = 45;
		GroupBox_ActivationTime.TabStop = false;
		GroupBox_ActivationTime.Text = "启用时间";
		Button_Clear_ActivationTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Clear_ActivationTime.BackColor = Color.Transparent;
		Button_Clear_ActivationTime.DialogResult = DialogResult.None;
		Button_Clear_ActivationTime.Font = new Font("Segoe UI", 10f);
		Button_Clear_ActivationTime.ForeColor = SystemColors.Control;
		Button_Clear_ActivationTime.Location = new Point(133, 14);
		Button_Clear_ActivationTime.Name = "Button_Clear_ActivationTime";
		Button_Clear_ActivationTime.RoundRadius = 0;
		Button_Clear_ActivationTime.Size = new Size(47, 22);
		Button_Clear_ActivationTime.TabIndex = 43;
		Button_Clear_ActivationTime.Text = "清空";
		DateTimePicker_ActivationTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_ActivationTime.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_ActivationTime.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_ActivationTime.ForeColor = Color.DimGray;
		DateTimePicker_ActivationTime.Location = new Point(39, 36);
		DateTimePicker_ActivationTime.Name = "DateTimePicker_ActivationTime";
		DateTimePicker_ActivationTime.Size = new Size(88, 23);
		DateTimePicker_ActivationTime.TabIndex = 37;
		DateTimePicker_ActivationDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_ActivationDate.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_ActivationDate.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_ActivationDate.ForeColor = Color.DimGray;
		DateTimePicker_ActivationDate.Location = new Point(39, 15);
		DateTimePicker_ActivationDate.Name = "DateTimePicker_ActivationDate";
		DateTimePicker_ActivationDate.Size = new Size(88, 23);
		DateTimePicker_ActivationDate.TabIndex = 36;
		Label101.AutoSize = true;
		Label101.ForeColor = Color.FromArgb(220, 220, 220);
		Label101.Location = new Point(4, 19);
		Label101.Name = "Label101";
		Label101.Size = new Size(34, 15);
		Label101.TabIndex = 38;
		Label101.Text = "日期：";
		Label102.AutoSize = true;
		Label102.ForeColor = Color.FromArgb(220, 220, 220);
		Label102.Location = new Point(4, 39);
		Label102.Name = "Label102";
		Label102.Size = new Size(36, 15);
		Label102.TabIndex = 38;
		Label102.Text = "时间：";
		GroupBox_DeactivationTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox_DeactivationTime.Controls.Add(CheckBox_DeleteMission);
		GroupBox_DeactivationTime.Controls.Add(CheckBox_OrderRTB);
		GroupBox_DeactivationTime.Controls.Add(CheckBox_UnassignUnits);
		GroupBox_DeactivationTime.Controls.Add(Button_Clear_DeactivationTime);
		GroupBox_DeactivationTime.Controls.Add(DateTimePicker_DeactivationTime);
		GroupBox_DeactivationTime.Controls.Add(Label112);
		GroupBox_DeactivationTime.Controls.Add(DateTimePicker_DeactivationDate);
		GroupBox_DeactivationTime.Controls.Add(Label114);
		GroupBox_DeactivationTime.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_DeactivationTime.Location = new Point(3, 70);
		GroupBox_DeactivationTime.Name = "GroupBox_DeactivationTime";
		GroupBox_DeactivationTime.Size = new Size(183, 119);
		GroupBox_DeactivationTime.TabIndex = 44;
		GroupBox_DeactivationTime.TabStop = false;
		GroupBox_DeactivationTime.Text = "停用时间";
		CheckBox_DeleteMission.AutoSize = true;
		CheckBox_DeleteMission.Location = new Point(8, 98);
		CheckBox_DeleteMission.Name = "CheckBox_DeleteMission";
		CheckBox_DeleteMission.Size = new Size(103, 19);
		CheckBox_DeleteMission.TabIndex = 46;
		CheckBox_DeleteMission.Text = "删除任务";
		CheckBox_OrderRTB.AutoSize = true;
		CheckBox_OrderRTB.Location = new Point(8, 79);
		CheckBox_OrderRTB.Name = "CheckBox_OrderRTB";
		CheckBox_OrderRTB.Size = new Size(78, 19);
		CheckBox_OrderRTB.TabIndex = 45;
		CheckBox_OrderRTB.Text = "订购RTB";
		CheckBox_UnassignUnits.AutoSize = true;
		CheckBox_UnassignUnits.Location = new Point(8, 60);
		CheckBox_UnassignUnits.Name = "CheckBox_UnassignUnits";
		CheckBox_UnassignUnits.Size = new Size(104, 19);
		CheckBox_UnassignUnits.TabIndex = 44;
		CheckBox_UnassignUnits.Text = "取消分配单元";
		Button_Clear_DeactivationTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Clear_DeactivationTime.BackColor = Color.Transparent;
		Button_Clear_DeactivationTime.DialogResult = DialogResult.None;
		Button_Clear_DeactivationTime.Font = new Font("Segoe UI", 10f);
		Button_Clear_DeactivationTime.ForeColor = SystemColors.Control;
		Button_Clear_DeactivationTime.Location = new Point(133, 14);
		Button_Clear_DeactivationTime.Name = "Button_Clear_DeactivationTime";
		Button_Clear_DeactivationTime.RoundRadius = 0;
		Button_Clear_DeactivationTime.Size = new Size(45, 22);
		Button_Clear_DeactivationTime.TabIndex = 43;
		Button_Clear_DeactivationTime.Text = "清空";
		DateTimePicker_DeactivationTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_DeactivationTime.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_DeactivationTime.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_DeactivationTime.ForeColor = Color.DimGray;
		DateTimePicker_DeactivationTime.Location = new Point(39, 36);
		DateTimePicker_DeactivationTime.Name = "DateTimePicker_DeactivationTime";
		DateTimePicker_DeactivationTime.Size = new Size(88, 23);
		DateTimePicker_DeactivationTime.TabIndex = 40;
		Label112.AutoSize = true;
		Label112.ForeColor = Color.FromArgb(220, 220, 220);
		Label112.Location = new Point(4, 40);
		Label112.Name = "Label112";
		Label112.Size = new Size(36, 15);
		Label112.TabIndex = 41;
		Label112.Text = "时间：";
		DateTimePicker_DeactivationDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_DeactivationDate.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_DeactivationDate.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_DeactivationDate.ForeColor = Color.DimGray;
		DateTimePicker_DeactivationDate.Location = new Point(39, 15);
		DateTimePicker_DeactivationDate.Name = "DateTimePicker_DeactivationDate";
		DateTimePicker_DeactivationDate.Size = new Size(88, 23);
		DateTimePicker_DeactivationDate.TabIndex = 39;
		Label114.AutoSize = true;
		Label114.ForeColor = Color.FromArgb(220, 220, 220);
		Label114.Location = new Point(4, 19);
		Label114.Name = "Label114";
		Label114.Size = new Size(34, 15);
		Label114.TabIndex = 42;
		Label114.Text = "日期：";
		GroupBox_TakeOffTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox_TakeOffTime.Controls.Add(Button_Clear_TakeOffTime);
		GroupBox_TakeOffTime.Controls.Add(DateTimePicker_TakeOffTime);
		GroupBox_TakeOffTime.Controls.Add(DateTimePicker_TakeOffDate);
		GroupBox_TakeOffTime.Controls.Add(Label162);
		GroupBox_TakeOffTime.Controls.Add(Label169);
		GroupBox_TakeOffTime.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_TakeOffTime.Location = new Point(3, 195);
		GroupBox_TakeOffTime.Name = "GroupBox_TakeOffTime";
		GroupBox_TakeOffTime.Size = new Size(183, 61);
		GroupBox_TakeOffTime.TabIndex = 46;
		GroupBox_TakeOffTime.TabStop = false;
		GroupBox_TakeOffTime.Text = "起飞时间";
		Button_Clear_TakeOffTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Clear_TakeOffTime.BackColor = Color.Transparent;
		Button_Clear_TakeOffTime.DialogResult = DialogResult.None;
		Button_Clear_TakeOffTime.Font = new Font("Segoe UI", 10f);
		Button_Clear_TakeOffTime.ForeColor = SystemColors.Control;
		Button_Clear_TakeOffTime.Location = new Point(118, 14);
		Button_Clear_TakeOffTime.Name = "Button_Clear_TakeOffTime";
		Button_Clear_TakeOffTime.RoundRadius = 0;
		Button_Clear_TakeOffTime.Size = new Size(60, 22);
		Button_Clear_TakeOffTime.TabIndex = 44;
		Button_Clear_TakeOffTime.Text = "清空";
		DateTimePicker_TakeOffTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_TakeOffTime.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_TakeOffTime.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_TakeOffTime.ForeColor = Color.DimGray;
		DateTimePicker_TakeOffTime.Location = new Point(39, 36);
		DateTimePicker_TakeOffTime.Name = "DateTimePicker_TakeOffTime";
		DateTimePicker_TakeOffTime.Size = new Size(79, 23);
		DateTimePicker_TakeOffTime.TabIndex = 37;
		DateTimePicker_TakeOffDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_TakeOffDate.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_TakeOffDate.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_TakeOffDate.ForeColor = Color.DimGray;
		DateTimePicker_TakeOffDate.Location = new Point(39, 15);
		DateTimePicker_TakeOffDate.Name = "DateTimePicker_TakeOffDate";
		DateTimePicker_TakeOffDate.Size = new Size(79, 23);
		DateTimePicker_TakeOffDate.TabIndex = 36;
		Label162.AutoSize = true;
		Label162.ForeColor = Color.FromArgb(220, 220, 220);
		Label162.Location = new Point(4, 19);
		Label162.Name = "Label162";
		Label162.Size = new Size(34, 15);
		Label162.TabIndex = 38;
		Label162.Text = "日期：";
		Label169.AutoSize = true;
		Label169.ForeColor = Color.FromArgb(220, 220, 220);
		Label169.Location = new Point(4, 39);
		Label169.Name = "Label169";
		Label169.Size = new Size(36, 15);
		Label169.TabIndex = 38;
		Label169.Text = "时间：";
		GroupBox_TimeOnTarget.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox_TimeOnTarget.Controls.Add(Button_Clear_TimeOnTarget);
		GroupBox_TimeOnTarget.Controls.Add(DateTimePicker_TimeOnTargetTime);
		GroupBox_TimeOnTarget.Controls.Add(DateTimePicker_TimeOnTargetDate);
		GroupBox_TimeOnTarget.Controls.Add(Label170);
		GroupBox_TimeOnTarget.Controls.Add(Label171);
		GroupBox_TimeOnTarget.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_TimeOnTarget.Location = new Point(3, 262);
		GroupBox_TimeOnTarget.Name = "GroupBox_TimeOnTarget";
		GroupBox_TimeOnTarget.Size = new Size(183, 61);
		GroupBox_TimeOnTarget.TabIndex = 47;
		GroupBox_TimeOnTarget.TabStop = false;
		GroupBox_TimeOnTarget.Text = "目标时间（ToT）";
		Button_Clear_TimeOnTarget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_Clear_TimeOnTarget.BackColor = Color.Transparent;
		Button_Clear_TimeOnTarget.DialogResult = DialogResult.None;
		Button_Clear_TimeOnTarget.Font = new Font("Segoe UI", 10f);
		Button_Clear_TimeOnTarget.ForeColor = SystemColors.Control;
		Button_Clear_TimeOnTarget.Location = new Point(118, 14);
		Button_Clear_TimeOnTarget.Name = "Button_Clear_TimeOnTarget";
		Button_Clear_TimeOnTarget.RoundRadius = 0;
		Button_Clear_TimeOnTarget.Size = new Size(60, 22);
		Button_Clear_TimeOnTarget.TabIndex = 44;
		Button_Clear_TimeOnTarget.Text = "清空";
		DateTimePicker_TimeOnTargetTime.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_TimeOnTargetTime.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_TimeOnTargetTime.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_TimeOnTargetTime.ForeColor = Color.DimGray;
		DateTimePicker_TimeOnTargetTime.Location = new Point(39, 36);
		DateTimePicker_TimeOnTargetTime.Name = "DateTimePicker_TimeOnTargetTime";
		DateTimePicker_TimeOnTargetTime.Size = new Size(79, 23);
		DateTimePicker_TimeOnTargetTime.TabIndex = 37;
		DateTimePicker_TimeOnTargetDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DateTimePicker_TimeOnTargetDate.BackColor = Color.FromArgb(31, 31, 31);
		DateTimePicker_TimeOnTargetDate.BorderStyle = BorderStyle.FixedSingle;
		DateTimePicker_TimeOnTargetDate.ForeColor = Color.DimGray;
		DateTimePicker_TimeOnTargetDate.Location = new Point(39, 15);
		DateTimePicker_TimeOnTargetDate.Name = "DateTimePicker_TimeOnTargetDate";
		DateTimePicker_TimeOnTargetDate.Size = new Size(79, 23);
		DateTimePicker_TimeOnTargetDate.TabIndex = 36;
		Label170.AutoSize = true;
		Label170.ForeColor = Color.FromArgb(220, 220, 220);
		Label170.Location = new Point(4, 19);
		Label170.Name = "Label170";
		Label170.Size = new Size(34, 15);
		Label170.TabIndex = 38;
		Label170.Text = "日期：";
		Label171.AutoSize = true;
		Label171.ForeColor = Color.FromArgb(220, 220, 220);
		Label171.Location = new Point(4, 39);
		Label171.Name = "Label171";
		Label171.Size = new Size(36, 15);
		Label171.TabIndex = 38;
		Label171.Text = "时间：";
		CB_ParentPool.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_ParentPool.BackColor = Color.Transparent;
		CB_ParentPool.DrawMode = DrawMode.OwnerDrawFixed;
		CB_ParentPool.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_ParentPool.Font = new Font("Segoe UI", 7f);
		CB_ParentPool.FormattingEnabled = true;
		CB_ParentPool.Items.AddRange(new object[2] { "启用", "未启用" });
		CB_ParentPool.Location = new Point(78, 153);
		CB_ParentPool.Name = "CB_ParentPool";
		CB_ParentPool.Size = new Size(266, 21);
		CB_ParentPool.TabIndex = 49;
		Label_ParentPool.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Label_ParentPool.AutoSize = true;
		Label_ParentPool.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ParentPool.Location = new Point(1, 158);
		Label_ParentPool.Name = "Label_ParentPool";
		Label_ParentPool.Size = new Size(71, 15);
		Label_ParentPool.TabIndex = 48;
		Label_ParentPool.Text = "父池：";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(541, 229);
		base.Controls.Add(CB_ParentPool);
		base.Controls.Add(Label_ParentPool);
		base.Controls.Add(FlowLayoutPanel1);
		base.Controls.Add(Label_Category);
		base.Controls.Add(CB_Category);
		base.Controls.Add(CB_MissionStatus);
		base.Controls.Add(Label_MissionStatus);
		base.Controls.Add(CB_OpenMissionEditor);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(CB_MissionType);
		base.Controls.Add(Label_MissionType);
		base.Controls.Add(Label_MissionClass);
		base.Controls.Add(CB_MissionClass);
		base.Controls.Add(TextBox_Name);
		base.Controls.Add(Label1);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "NewMission";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "新建任务/任务池/任务包";
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		GroupBox_ActivationTime.ResumeLayout(performLayout: false);
		GroupBox_ActivationTime.PerformLayout();
		GroupBox_DeactivationTime.ResumeLayout(performLayout: false);
		GroupBox_DeactivationTime.PerformLayout();
		GroupBox_TakeOffTime.ResumeLayout(performLayout: false);
		GroupBox_TakeOffTime.PerformLayout();
		GroupBox_TimeOnTarget.ResumeLayout(performLayout: false);
		GroupBox_TimeOnTarget.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] policyPublisher = m_PolicyPublisher;
		int num = 0;
		while (true)
		{
			if (num < policyPublisher.Length)
			{
				Keys keys = policyPublisher[num];
				if (keyData == keys)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		Close();
		return true;
	}

	public NewMission()
	{
		base.FormClosing += SetInterruptibleInterpreter;
		base.Load += FillInterruptibleInterpreter;
		base.VisibleChanged += CalculateInterruptibleInterpreter;
		base.KeyDown += InstantiateInterruptibleInterpreter;
		regPublisher = true;
		paramPublisher = false;
		_PagePublisher = false;
		rulesPublisher = false;
		methodPublisher = false;
		m_PolicyPublisher = new Keys[2]
		{
			Keys.F11,
			Keys.Escape
		};
		ChangeInterruptibleInterpreter();
		_IndexerValue = false;
	}

	private void InitInterruptibleInterpreter(object object_0)
	{
		Button1.Enabled = Operators.CompareString(TextBox_Name.Text, "", TextCompare: true) != 0;
	}

	private void CheckInterruptibleInterpreter(object sender, EventArgs e)
	{
		if (CB_MissionClass.SelectedIndex == -1)
		{
			return;
		}
		switch (CB_MissionClass.SelectedIndex)
		{
		case 0:
			CB_MissionType.Enabled = true;
			Label_MissionType.Enabled = true;
			CB_MissionType.Items.Clear();
			CB_MissionType.Items.Add("空中拦截");
			CB_MissionType.Items.Add("攻击地面目标");
			CB_MissionType.Items.Add("攻击海面目标");
			CB_MissionType.Items.Add("攻击水下目标");
			if (CB_MissionType.Items.Count > 0 && CB_MissionType.SelectedIndex < 0)
			{
				CB_MissionType.SelectedIndex = 0;
			}
			break;
		case 1:
			CB_MissionType.Enabled = true;
			Label_MissionType.Enabled = true;
			CB_MissionType.Items.Clear();
			CB_MissionType.Items.Add("反空中目标AAW巡逻");
			CB_MissionType.Items.Add("反海面目标ASuW巡逻（海军）");
			CB_MissionType.Items.Add("反地面目标ASuW巡逻（陆军）");
			CB_MissionType.Items.Add("反地面和海面目标ASuW巡逻（联合）");
			CB_MissionType.Items.Add("反潜ASW巡逻");
			CB_MissionType.Items.Add("防空压制SEAD巡逻");
			CB_MissionType.Items.Add("海域控制巡逻");
			if (CB_MissionType.Items.Count > 0 && CB_MissionType.SelectedIndex < 0)
			{
				CB_MissionType.SelectedIndex = 0;
			}
			break;
		case 2:
		case 3:
		case 4:
		case 5:
			CB_MissionType.Items.Clear();
			CB_MissionType.Enabled = false;
			Label_MissionType.Enabled = true;
			break;
		case 6:
			CB_MissionType.Enabled = true;
			Label_MissionType.Enabled = true;
			CB_MissionType.Items.Clear();
			CB_MissionType.Items.Add("Delivery");
			CB_MissionType.Items.Add("Transfer");
			if (CargoMission.IsValidDestinationUnit(Client.SelectedUnit))
			{
				CB_MissionType.SelectedIndex = 1;
			}
			else
			{
				CB_MissionType.SelectedIndex = 0;
			}
			break;
		}
	}

	private void ConcatInterruptibleInterpreter(object sender, EventArgs e)
	{
		InterruptInterruptibleInterpreter();
	}

	private void InterruptInterruptibleInterpreter()
	{
		CreatingNewMission = true;
		try
		{
			if (CB_Category.SelectedIndex == -1)
			{
				return;
			}
			if (CB_Category.SelectedIndex != 1 && CB_MissionClass.SelectedIndex == -1)
			{
				DarkMessageBox.ShowError("请给包类一个类。", "无类型");
				return;
			}
			if (Operators.CompareString(TextBox_Name.Text, "", TextCompare: true) == 0)
			{
				DarkMessageBox.ShowError("请输入一个名称！", "无名称");
				return;
			}
			foreach (Mission mission5 in Client.CurrentSide.Missions)
			{
				if (Operators.CompareString(mission5.Name, TextBox_Name.Text, TextCompare: true) == 0)
				{
					DarkMessageBox.ShowError("同名任务已存在！", "名称错误");
					return;
				}
			}
			PrintInterruptibleInterpreter();
			PublishInterruptibleInterpreter();
			QueryInterruptibleInterpreter();
			MapInterruptibleInterpreter();
			switch (CB_Category.SelectedIndex)
			{
			case 1:
			{
				Side side_2 = Client.CurrentSide;
				Scenario scenario_2 = Client.CurrentScenario;
				TaskPool taskPool = new TaskPool(ref side_2, ref scenario_2, TextBox_Name.Text, Mission.MissionCategory.TaskPool);
				Client.CurrentSide = side_2;
				TaskPool selectedMissionLink = taskPool;
				if (regPublisher)
				{
					Client.MissionEditorWindow.SelectedMissionLink = selectedMissionLink;
					if (Client.MissionEditorWindow.Visible)
					{
						Client.MissionEditorWindow.RefreshAll();
					}
					else
					{
						Client.MissionEditorWindow.Show();
					}
				}
				Close();
				break;
			}
			case 0:
			case 2:
			{
				Mission.MissionCategory missionCategory_;
				if (CB_Category.SelectedIndex == 2)
				{
					if (CB_ParentPool.Items.Count == 0 || CB_ParentPool.SelectedIndex < 0)
					{
						DarkMessageBox.ShowError("您必须选择父飞机任务池！如果不存在，请先创建一个。", "");
						return;
					}
					missionCategory_ = Mission.MissionCategory.Package;
					Client.CurrentSide.MapOrder();
				}
				else
				{
					missionCategory_ = Mission.MissionCategory.Mission;
				}
				switch (CB_MissionClass.SelectedIndex)
				{
				case 0:
					switch (CB_MissionType.SelectedIndex)
					{
					default:
						DarkMessageBox.ShowError("请选择一种类型。", "无所选类型");
						return;
					case 0:
					{
						Strike strike2 = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, Strike.StrikeType.Air_Intercept);
						strike2.FlightSize = 2;
						if (strike2.Category == Mission.MissionCategory.Package)
						{
							string right7 = CB_ParentPool.SelectedItem.ToString();
							foreach (Mission mission6 in Client.CurrentSide.Missions)
							{
								if (Operators.CompareString(mission6.Name, right7, TextCompare: true) == 0)
								{
									((TaskPool)mission6).PackageList.Add(strike2);
									strike2.SetParentTaskPoolID(Client.CurrentSide, mission6.ObjectID);
									break;
								}
							}
						}
						if (CB_MissionStatus.SelectedIndex == 1)
						{
							strike2.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
						}
						strike2.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
						strike2.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
						strike2.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
						if (strike2.Category == Mission.MissionCategory.Mission)
						{
							if (m_ServicePublisher.HasValue)
							{
								strike2.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
							}
							if (systemPublisher.HasValue)
							{
								strike2.EndTime_Set(systemPublisher, Client.CurrentScenario);
							}
						}
						else
						{
							if (candidatePublisher.HasValue)
							{
								strike2.TakeOffTime = candidatePublisher;
							}
							if (basePublisher.HasValue)
							{
								strike2.TimeOnTarget = basePublisher;
							}
						}
						RemoveInterruptibleInterpreter(strike2);
						if (regPublisher)
						{
							Client.MissionEditorWindow.SelectedMissionLink = strike2;
							if (Client.MissionEditorWindow.Visible)
							{
								Client.MissionEditorWindow.RefreshAll();
							}
							else
							{
								Client.MissionEditorWindow.Show();
							}
						}
						Close();
						break;
					}
					case 1:
					{
						Strike strike3 = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, Strike.StrikeType.Land_Strike);
						strike3.FlightSize = 4;
						if (strike3.Category == Mission.MissionCategory.Package)
						{
							string right8 = CB_ParentPool.SelectedItem.ToString();
							foreach (Mission mission7 in Client.CurrentSide.Missions)
							{
								if (Operators.CompareString(mission7.Name, right8, TextCompare: true) == 0)
								{
									((TaskPool)mission7).PackageList.Add(strike3);
									strike3.SetParentTaskPoolID(Client.CurrentSide, mission7.ObjectID);
									break;
								}
							}
						}
						if (CB_MissionStatus.SelectedIndex == 1)
						{
							strike3.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
						}
						RemoveInterruptibleInterpreter(strike3);
						if (strike3.TargetCount > 0)
						{
							List<Module_Unit.Unit> collection2 = strike3.SpecificTargets.OrderBy((Module_Unit.Unit theUnit) => theUnit.Name).ToList();
							strike3.SpecificTargets = new HashSet<Module_Unit.Unit>(collection2);
							strike3.RTB_When_Target_Destroyed = true;
						}
						strike3.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
						strike3.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
						strike3.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
						if (strike3.Category == Mission.MissionCategory.Mission)
						{
							if (m_ServicePublisher.HasValue)
							{
								strike3.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
							}
							if (systemPublisher.HasValue)
							{
								strike3.EndTime_Set(systemPublisher, Client.CurrentScenario);
							}
						}
						else
						{
							if (candidatePublisher.HasValue)
							{
								strike3.TakeOffTime = candidatePublisher;
							}
							if (basePublisher.HasValue)
							{
								strike3.TimeOnTarget = basePublisher;
							}
						}
						if (regPublisher)
						{
							Client.MissionEditorWindow.SelectedMissionLink = strike3;
							if (Client.MissionEditorWindow.Visible)
							{
								Client.MissionEditorWindow.RefreshAll();
							}
							else
							{
								Client.MissionEditorWindow.Show();
							}
							Client.MissionEditorWindow.Show();
						}
						Close();
						break;
					}
					case 2:
					{
						Strike strike4 = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, Strike.StrikeType.Maritime_Strike);
						strike4.FlightSize = 4;
						if (strike4.Category == Mission.MissionCategory.Package)
						{
							string right9 = CB_ParentPool.SelectedItem.ToString();
							foreach (Mission mission8 in Client.CurrentSide.Missions)
							{
								if (Operators.CompareString(mission8.Name, right9, TextCompare: true) == 0)
								{
									((TaskPool)mission8).PackageList.Add(strike4);
									strike4.SetParentTaskPoolID(Client.CurrentSide, mission8.ObjectID);
									break;
								}
							}
						}
						if (CB_MissionStatus.SelectedIndex == 1)
						{
							strike4.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
						}
						Contact contact3 = null;
						foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
						{
							if (selectedUnit.GetUnitSide() == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit.GetUnitSide()))
							{
								continue;
							}
							if (selectedUnit.IsGroup)
							{
								foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
								{
									strike4.SpecificTargets.Add(value);
									if (strike4.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(value.GetUnitSide()) != Misc.PostureStance.Hostile)
									{
										Client.CurrentSide.SetConsidersThisSideToBe(value.GetUnitSide(), Misc.PostureStance.Hostile);
									}
								}
								continue;
							}
							if (selectedUnit.IsActiveUnit)
							{
								strike4.SpecificTargets.Add(selectedUnit);
								if (strike4.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(selectedUnit.GetUnitSide()) != Misc.PostureStance.Hostile)
								{
									Client.CurrentSide.SetConsidersThisSideToBe(selectedUnit.GetUnitSide(), Misc.PostureStance.Hostile);
								}
								continue;
							}
							Contact contact4 = (Contact)selectedUnit;
							if (contact4.ActualUnit == null)
							{
								continue;
							}
							if (Client.CurrentSide.BaseContacts.ContainsKey(contact4.ActualUnit.ObjectID))
							{
								foreach (ActiveUnit value2 in ((Group)contact4.ActualUnit).Units.Values)
								{
									if (!Client.CurrentSide.Contacts.ContainsKey(value2.ObjectID))
									{
										continue;
									}
									Client.CurrentSide.Contacts.TryGetValue(value2.ObjectID, ref contact3);
									if (!Information.IsNothing(contact3))
									{
										strike4.SpecificTargets.Add(contact3);
										if (strike4.IsActive && contact4.GetStance(Client.CurrentSide) != Misc.PostureStance.Hostile)
										{
											contact4.SetStance(Client.CurrentSide, bool_0: false, Misc.PostureStance.Hostile);
										}
									}
								}
							}
							else
							{
								strike4.SpecificTargets.Add(contact4);
								if (strike4.IsActive && contact4.GetStance(Client.CurrentSide) != Misc.PostureStance.Hostile)
								{
									contact4.SetStance(Client.CurrentSide, bool_0: false, Misc.PostureStance.Hostile);
								}
							}
						}
						if (strike4.TargetCount > 0)
						{
							List<Module_Unit.Unit> collection3 = strike4.SpecificTargets.OrderBy((Module_Unit.Unit theUnit) => theUnit.Name).ToList();
							strike4.SpecificTargets = new HashSet<Module_Unit.Unit>(collection3);
							strike4.RTB_When_Target_Destroyed = true;
						}
						strike4.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
						strike4.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
						strike4.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
						if (strike4.Category == Mission.MissionCategory.Mission)
						{
							if (m_ServicePublisher.HasValue)
							{
								strike4.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
							}
							if (systemPublisher.HasValue)
							{
								strike4.EndTime_Set(systemPublisher, Client.CurrentScenario);
							}
						}
						else
						{
							if (candidatePublisher.HasValue)
							{
								strike4.TakeOffTime = candidatePublisher;
							}
							if (basePublisher.HasValue)
							{
								strike4.TimeOnTarget = basePublisher;
							}
						}
						if (regPublisher)
						{
							Client.MissionEditorWindow.SelectedMissionLink = strike4;
							if (Client.MissionEditorWindow.Visible)
							{
								Client.MissionEditorWindow.RefreshAll();
							}
							else
							{
								Client.MissionEditorWindow.Show();
							}
							Client.MissionEditorWindow.Show();
						}
						Close();
						break;
					}
					case 3:
					{
						Strike strike = new Strike(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, Strike.StrikeType.Sub_Strike);
						strike.FlightSize = 1;
						if (strike.Category == Mission.MissionCategory.Package)
						{
							string right6 = CB_ParentPool.SelectedItem.ToString();
							foreach (Mission mission9 in Client.CurrentSide.Missions)
							{
								if (Operators.CompareString(mission9.Name, right6, TextCompare: true) == 0)
								{
									((TaskPool)mission9).PackageList.Add(strike);
									strike.SetParentTaskPoolID(Client.CurrentSide, mission9.ObjectID);
									break;
								}
							}
						}
						if (CB_MissionStatus.SelectedIndex == 1)
						{
							strike.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
						}
						Contact contact = null;
						foreach (Module_Unit.Unit selectedUnit2 in Client.CurrentSide.SelectedUnits)
						{
							if (selectedUnit2.GetUnitSide() == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit2.GetUnitSide()))
							{
								continue;
							}
							if (selectedUnit2.IsGroup)
							{
								foreach (ActiveUnit value3 in ((Group)selectedUnit2).Units.Values)
								{
									strike.SpecificTargets.Add(value3);
									if (strike.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(value3.GetUnitSide()) != Misc.PostureStance.Hostile)
									{
										Client.CurrentSide.SetConsidersThisSideToBe(value3.GetUnitSide(), Misc.PostureStance.Hostile);
									}
								}
								continue;
							}
							if (selectedUnit2.IsActiveUnit)
							{
								strike.SpecificTargets.Add(selectedUnit2);
								if (strike.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(selectedUnit2.GetUnitSide()) != Misc.PostureStance.Hostile)
								{
									Client.CurrentSide.SetConsidersThisSideToBe(selectedUnit2.GetUnitSide(), Misc.PostureStance.Hostile);
								}
								continue;
							}
							Contact contact2 = (Contact)selectedUnit2;
							if (Information.IsNothing(contact2.ActualUnit))
							{
								continue;
							}
							if (Client.CurrentSide.BaseContacts.ContainsKey(contact2.ActualUnit.ObjectID))
							{
								foreach (ActiveUnit value4 in ((Group)contact2.ActualUnit).Units.Values)
								{
									if (!Client.CurrentSide.Contacts.ContainsKey(value4.ObjectID))
									{
										continue;
									}
									Client.CurrentSide.Contacts.TryGetValue(value4.ObjectID, ref contact);
									if (!Information.IsNothing(contact))
									{
										strike.SpecificTargets.Add(contact);
										if (strike.IsActive && contact2.GetStance(Client.CurrentSide) != Misc.PostureStance.Hostile)
										{
											contact2.SetStance(Client.CurrentSide, bool_0: false, Misc.PostureStance.Hostile);
										}
									}
								}
							}
							else
							{
								strike.SpecificTargets.Add(contact2);
								if (strike.IsActive && contact2.GetStance(Client.CurrentSide) != Misc.PostureStance.Hostile)
								{
									contact2.SetStance(Client.CurrentSide, bool_0: false, Misc.PostureStance.Hostile);
								}
							}
						}
						if (strike.TargetCount > 0)
						{
							List<Module_Unit.Unit> collection = strike.SpecificTargets.OrderBy((Module_Unit.Unit theUnit) => theUnit.Name).ToList();
							strike.SpecificTargets = new HashSet<Module_Unit.Unit>(collection);
							strike.RTB_When_Target_Destroyed = true;
						}
						strike.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
						strike.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
						strike.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
						if (strike.Category == Mission.MissionCategory.Mission)
						{
							if (m_ServicePublisher.HasValue)
							{
								strike.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
							}
							if (systemPublisher.HasValue)
							{
								strike.EndTime_Set(systemPublisher, Client.CurrentScenario);
							}
						}
						else
						{
							if (candidatePublisher.HasValue)
							{
								strike.TakeOffTime = candidatePublisher;
							}
							if (basePublisher.HasValue)
							{
								strike.TimeOnTarget = basePublisher;
							}
						}
						if (regPublisher)
						{
							Client.MissionEditorWindow.SelectedMissionLink = strike;
							if (Client.MissionEditorWindow.Visible)
							{
								Client.MissionEditorWindow.RefreshAll();
							}
							else
							{
								Client.MissionEditorWindow.Show();
							}
							Client.MissionEditorWindow.Show();
						}
						Close();
						break;
					}
					}
					break;
				case 1:
				{
					IEnumerable<ReferencePoint> enumerable2 = Client.CurrentSide.RefPoints.Where((ReferencePoint theRP) => theRP.IsHighlighted);
					if (enumerable2.Count() == 0)
					{
						DarkMessageBox.ShowError("在创建巡逻任务之前，您必须至少选择一个参考点。", "没有选择参考点！");
						return;
					}
					List<ReferencePoint> list2 = new List<ReferencePoint>();
					list2.AddRange(enumerable2);
					Mission mission = null;
					switch (CB_MissionType.SelectedIndex)
					{
					default:
						DarkMessageBox.ShowError("请选择一种类型。", "无所选类型");
						return;
					case 0:
						mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list2, GlobalVariables.PatrolType.AAW, bool_0: true);
						mission.FlightSize = 2;
						break;
					case 1:
						mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list2, GlobalVariables.PatrolType.ASuW_Naval, bool_0: true);
						mission.FlightSize = 1;
						break;
					case 2:
						mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list2, GlobalVariables.PatrolType.ASuW_Land, bool_0: true);
						mission.FlightSize = 2;
						break;
					case 3:
						mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list2, GlobalVariables.PatrolType.ASuW_Mixed, bool_0: true);
						mission.FlightSize = 2;
						break;
					case 4:
						mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list2, GlobalVariables.PatrolType.ASW, bool_0: true);
						mission.FlightSize = 1;
						break;
					case 5:
						mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list2, GlobalVariables.PatrolType.SEAD, bool_0: true);
						mission.FlightSize = 2;
						break;
					case 6:
						mission = new Patrol(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list2, GlobalVariables.PatrolType.SeaControl, bool_0: true);
						mission.FlightSize = 1;
						break;
					}
					if (Information.IsNothing(mission))
					{
						DarkMessageBox.ShowError("请选择一种巡逻类型。", "没有选择巡逻类型！");
						break;
					}
					if (mission.Category == Mission.MissionCategory.Package)
					{
						string right3 = CB_ParentPool.SelectedItem.ToString();
						foreach (Mission mission10 in Client.CurrentSide.Missions)
						{
							if (Operators.CompareString(mission10.Name, right3, TextCompare: true) == 0)
							{
								((TaskPool)mission10).PackageList.Add(mission);
								mission.SetParentTaskPoolID(Client.CurrentSide, mission10.ObjectID);
								break;
							}
						}
					}
					if (CB_MissionStatus.SelectedIndex == 1)
					{
						mission.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
					}
					mission.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
					mission.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
					mission.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
					if (mission.Category == Mission.MissionCategory.Mission)
					{
						if (m_ServicePublisher.HasValue)
						{
							mission.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
						}
						if (systemPublisher.HasValue)
						{
							mission.EndTime_Set(systemPublisher, Client.CurrentScenario);
						}
					}
					else
					{
						if (candidatePublisher.HasValue)
						{
							mission.TakeOffTime = candidatePublisher;
						}
						if (basePublisher.HasValue)
						{
							mission.TimeOnTarget = basePublisher;
						}
					}
					if (regPublisher)
					{
						Client.MissionEditorWindow.SelectedMissionLink = mission;
						if (Client.MissionEditorWindow.Visible)
						{
							Client.MissionEditorWindow.RefreshAll();
						}
						else
						{
							Client.MissionEditorWindow.Show();
						}
					}
					Close();
					break;
				}
				case 2:
				{
					IEnumerable<ReferencePoint> enumerable3 = Client.CurrentSide.RefPoints.Where((ReferencePoint theRP) => theRP.IsHighlighted);
					if (enumerable3.Count() == 0 && DarkMessageBox.ShowError("You should select at least one reference point before creating a support mission. Do you want to continue ?", "没有选择参考点！", DarkDialogButton.YesNo) == DialogResult.No)
					{
						return;
					}
					List<ReferencePoint> list_3 = new List<ReferencePoint>();
					list_3.AddRange(enumerable3);
					Side side_ = Client.CurrentSide;
					Scenario scenario_ = Client.CurrentScenario;
					SupportMission supportMission = new SupportMission(ref side_, ref scenario_, TextBox_Name.Text, missionCategory_, ref list_3, bool_0: true);
					Client.CurrentSide = side_;
					SupportMission supportMission2 = supportMission;
					supportMission2.FlightSize = 1;
					if (supportMission2.Category == Mission.MissionCategory.Package)
					{
						string right10 = CB_ParentPool.SelectedItem.ToString();
						foreach (Mission mission11 in Client.CurrentSide.Missions)
						{
							if (Operators.CompareString(mission11.Name, right10, TextCompare: true) == 0)
							{
								((TaskPool)mission11).PackageList.Add(supportMission2);
								supportMission2.SetParentTaskPoolID(Client.CurrentSide, mission11.ObjectID);
								break;
							}
						}
					}
					if (CB_MissionStatus.SelectedIndex == 1)
					{
						supportMission2.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
					}
					supportMission2.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
					supportMission2.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
					supportMission2.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
					if (supportMission2.Category == Mission.MissionCategory.Mission)
					{
						if (m_ServicePublisher.HasValue)
						{
							supportMission2.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
						}
						if (systemPublisher.HasValue)
						{
							supportMission2.EndTime_Set(systemPublisher, Client.CurrentScenario);
						}
					}
					else
					{
						if (candidatePublisher.HasValue)
						{
							supportMission2.TakeOffTime = candidatePublisher;
						}
						if (basePublisher.HasValue)
						{
							supportMission2.TimeOnTarget = basePublisher;
						}
					}
					if (regPublisher)
					{
						Client.MissionEditorWindow.SelectedMissionLink = supportMission2;
						if (Client.MissionEditorWindow.Visible)
						{
							Client.MissionEditorWindow.RefreshAll();
						}
						else
						{
							Client.MissionEditorWindow.Show();
						}
					}
					Close();
					break;
				}
				case 3:
					if (!Information.IsNothing(Client.SelectedUnit) && Client.SelectedUnit.IsActiveUnit)
					{
						FerryMission ferryMission = new FerryMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, (ActiveUnit)Client.SelectedUnit);
						ferryMission.FlightSize = 4;
						if (ferryMission.Category == Mission.MissionCategory.Package)
						{
							string right2 = CB_ParentPool.SelectedItem.ToString();
							foreach (Mission mission12 in Client.CurrentSide.Missions)
							{
								if (Operators.CompareString(mission12.Name, right2, TextCompare: true) == 0)
								{
									((TaskPool)mission12).PackageList.Add(ferryMission);
									ferryMission.SetParentTaskPoolID(Client.CurrentSide, mission12.ObjectID);
									break;
								}
							}
						}
						if (CB_MissionStatus.SelectedIndex == 1)
						{
							ferryMission.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
						}
						ferryMission.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
						ferryMission.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
						ferryMission.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
						if (ferryMission.Category == Mission.MissionCategory.Mission)
						{
							if (m_ServicePublisher.HasValue)
							{
								ferryMission.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
							}
							if (systemPublisher.HasValue)
							{
								ferryMission.EndTime_Set(systemPublisher, Client.CurrentScenario);
							}
						}
						else
						{
							if (candidatePublisher.HasValue)
							{
								ferryMission.TakeOffTime = candidatePublisher;
							}
							if (basePublisher.HasValue)
							{
								ferryMission.TimeOnTarget = basePublisher;
							}
						}
						if (regPublisher)
						{
							Client.MissionEditorWindow.SelectedMissionLink = ferryMission;
							if (Client.MissionEditorWindow.Visible)
							{
								Client.MissionEditorWindow.RefreshAll();
							}
							else
							{
								Client.MissionEditorWindow.Show();
							}
						}
						Close();
						break;
					}
					DarkMessageBox.ShowError("在创建转场任务之前，您必须选择有效的目的地。", "未选择有效目的地！");
					return;
				case 4:
				{
					IEnumerable<ReferencePoint> source2 = Client.CurrentSide.RefPoints.Where((ReferencePoint theRP) => theRP.IsHighlighted);
					if (source2.Count() < 2)
					{
						DarkMessageBox.ShowError("在创建挖掘任务之前，您必须至少选择两个参考点。", "没有选择足够的参考点！");
						return;
					}
					List<ReferencePoint> list_2 = source2.ToList();
					MiningMission miningMission = new MiningMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list_2, bool_0: true);
					miningMission.FlightSize = 4;
					if (miningMission.Category == Mission.MissionCategory.Package)
					{
						string right5 = CB_ParentPool.SelectedItem.ToString();
						foreach (Mission mission2 in Client.CurrentSide.Missions)
						{
							if (Operators.CompareString(mission2.Name, right5, TextCompare: true) == 0)
							{
								((TaskPool)mission2).PackageList.Add(miningMission);
								miningMission.SetParentTaskPoolID(Client.CurrentSide, mission2.ObjectID);
								break;
							}
						}
					}
					if (CB_MissionStatus.SelectedIndex == 1)
					{
						miningMission.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
					}
					miningMission.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
					miningMission.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
					miningMission.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
					if (miningMission.Category == Mission.MissionCategory.Mission)
					{
						if (m_ServicePublisher.HasValue)
						{
							miningMission.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
						}
						if (systemPublisher.HasValue)
						{
							miningMission.EndTime_Set(systemPublisher, Client.CurrentScenario);
						}
					}
					else
					{
						if (candidatePublisher.HasValue)
						{
							miningMission.TakeOffTime = candidatePublisher;
						}
						if (basePublisher.HasValue)
						{
							miningMission.TimeOnTarget = basePublisher;
						}
					}
					if (regPublisher)
					{
						Client.MissionEditorWindow.SelectedMissionLink = miningMission;
						if (Client.MissionEditorWindow.Visible)
						{
							Client.MissionEditorWindow.RefreshAll();
						}
						else
						{
							Client.MissionEditorWindow.Show();
						}
					}
					Close();
					break;
				}
				case 5:
				{
					IEnumerable<ReferencePoint> source = Client.CurrentSide.RefPoints.Where((ReferencePoint theRP) => theRP.IsHighlighted);
					if (source.Count() < 2)
					{
						DarkMessageBox.ShowError("在创建排雷任务之前，您必须至少选择两个参考点。", "没有选择足够的参考点！");
						return;
					}
					List<ReferencePoint> list_ = source.ToList();
					MineClearingMission mineClearingMission = new MineClearingMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list_, bool_0: true);
					mineClearingMission.FlightSize = 1;
					if (mineClearingMission.Category == Mission.MissionCategory.Package)
					{
						string right4 = CB_ParentPool.SelectedItem.ToString();
						foreach (Mission mission3 in Client.CurrentSide.Missions)
						{
							if (Operators.CompareString(mission3.Name, right4, TextCompare: true) == 0)
							{
								((TaskPool)mission3).PackageList.Add(mineClearingMission);
								mineClearingMission.SetParentTaskPoolID(Client.CurrentSide, mission3.ObjectID);
								break;
							}
						}
					}
					if (CB_MissionStatus.SelectedIndex == 1)
					{
						mineClearingMission.SetStatus(Client.CurrentScenario, Mission.MissionStatus.Inactive);
					}
					mineClearingMission.Deactivation_UnassignUnits = CheckBox_UnassignUnits.Checked;
					mineClearingMission.Deactivation_OrderRTB = CheckBox_OrderRTB.Checked;
					mineClearingMission.Deactivation_DeleteMission = CheckBox_DeleteMission.Checked;
					if (mineClearingMission.Category == Mission.MissionCategory.Mission)
					{
						if (m_ServicePublisher.HasValue)
						{
							mineClearingMission.StartTime_Set(m_ServicePublisher, Client.CurrentScenario);
						}
						if (systemPublisher.HasValue)
						{
							mineClearingMission.EndTime_Set(systemPublisher, Client.CurrentScenario);
						}
					}
					else
					{
						if (candidatePublisher.HasValue)
						{
							mineClearingMission.TakeOffTime = candidatePublisher;
						}
						if (basePublisher.HasValue)
						{
							mineClearingMission.TimeOnTarget = basePublisher;
						}
					}
					if (regPublisher)
					{
						Client.MissionEditorWindow.SelectedMissionLink = mineClearingMission;
						if (Client.MissionEditorWindow.Visible)
						{
							Client.MissionEditorWindow.RefreshAll();
						}
						else
						{
							Client.MissionEditorWindow.Show();
						}
					}
					Close();
					break;
				}
				case 6:
					{
						CargoMission cargoMission = null;
						List<ReferencePoint> list = new List<ReferencePoint>();
						switch (CB_MissionType.SelectedIndex)
						{
						case 1:
						{
							ActiveUnit activeUnit = null;
							if (CargoMission.IsValidDestinationUnit(Client.SelectedUnit))
							{
								activeUnit = (ActiveUnit)Client.SelectedUnit;
								cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list, bool_0: false, activeUnit);
								if (cargoMission.Category == Mission.MissionCategory.Package)
								{
									string right = CB_ParentPool.SelectedItem.ToString();
									foreach (Mission mission4 in Client.CurrentSide.Missions)
									{
										if (Operators.CompareString(mission4.Name, right, TextCompare: true) == 0)
										{
											((TaskPool)mission4).PackageList.Add(cargoMission);
											cargoMission.SetParentTaskPoolID(Client.CurrentSide, mission4.ObjectID);
											break;
										}
									}
								}
								goto default;
							}
							DarkMessageBox.ShowError("You must select a fixed facility unit, ship, airbase, or naval base that can host cargo before creating a cargo transfer mission.", "未选择有效目的地！");
							return;
						}
						case 0:
						{
							IEnumerable<ReferencePoint> enumerable = Client.CurrentSide.RefPoints.Where((ReferencePoint theRP) => theRP.IsHighlighted);
							if (enumerable == null || enumerable.Count() == 0)
							{
								break;
							}
							list.AddRange(enumerable);
							cargoMission = new CargoMission(Client.CurrentSide, Client.CurrentScenario, TextBox_Name.Text, missionCategory_, list, bool_0: true);
							goto default;
						}
						default:
							if (Information.IsNothing(cargoMission))
							{
								DarkMessageBox.ShowError("请选择一种巡逻类型。", "没有选择巡逻类型！");
								goto end_IL_0240;
							}
							cargoMission.Name = TextBox_Name.Text;
							if (regPublisher)
							{
								Client.MissionEditorWindow.SelectedMissionLink = cargoMission;
								if (Client.MissionEditorWindow.Visible)
								{
									Client.MissionEditorWindow.RefreshAll();
								}
								else
								{
									Client.MissionEditorWindow.Show();
								}
							}
							Close();
							goto end_IL_0240;
						}
						DarkMessageBox.ShowError("You must select one or more reference points before creating a cargo delivery mission.", "未选择有效目的地！");
						return;
					}
					end_IL_0240:
					break;
				}
				break;
			}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		CreatingNewMission = false;
		if (Client.MissionEditorWindow.Visible)
		{
			Client.MissionEditorWindow.RefreshMissions();
		}
		Client.MustRefreshMainForm = true;
	}

	private void RemoveInterruptibleInterpreter(Strike strike_0)
	{
		Contact contact = null;
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.GetUnitSide() == Client.CurrentSide || Module_Side.IsAlliedWithThisSide(Client.CurrentSide, selectedUnit.GetUnitSide()))
			{
				continue;
			}
			if (selectedUnit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)selectedUnit).Units.Values)
				{
					strike_0.SpecificTargets.Add(value);
					if (strike_0.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(value.GetUnitSide()) != Misc.PostureStance.Hostile)
					{
						Client.CurrentSide.SetConsidersThisSideToBe(value.GetUnitSide(), Misc.PostureStance.Hostile);
					}
				}
				continue;
			}
			if (selectedUnit.IsActiveUnit)
			{
				strike_0.SpecificTargets.Add(selectedUnit);
				if (strike_0.IsActive && Client.CurrentSide.GetConsidersThisSideToBe(selectedUnit.GetUnitSide()) != Misc.PostureStance.Hostile)
				{
					Client.CurrentSide.SetConsidersThisSideToBe(selectedUnit.GetUnitSide(), Misc.PostureStance.Hostile);
				}
				continue;
			}
			Contact contact2 = (Contact)selectedUnit;
			if (contact2.ActualUnit == null)
			{
				continue;
			}
			if (Client.CurrentSide.BaseContacts.ContainsKey(contact2.ActualUnit.ObjectID))
			{
				foreach (ActiveUnit value2 in ((Group)contact2.ActualUnit).Units.Values)
				{
					if (!Client.CurrentSide.Contacts.ContainsKey(value2.ObjectID))
					{
						continue;
					}
					Client.CurrentSide.Contacts.TryGetValue(value2.ObjectID, ref contact);
					if (contact != null)
					{
						strike_0.SpecificTargets.Add(contact);
						if (strike_0.IsActive && contact2.GetStance(Client.CurrentSide) != Misc.PostureStance.Hostile)
						{
							contact2.SetStance(Client.CurrentSide, bool_0: false, Misc.PostureStance.Hostile);
						}
					}
				}
			}
			else
			{
				strike_0.SpecificTargets.Add(contact2);
				if (strike_0.IsActive && contact2.GetStance(Client.CurrentSide) != Misc.PostureStance.Hostile)
				{
					contact2.SetStance(Client.CurrentSide, bool_0: false, Misc.PostureStance.Hostile);
				}
			}
		}
		if (strike_0.TargetCount > 0)
		{
			List<Module_Unit.Unit> collection = strike_0.SpecificTargets.OrderBy((Module_Unit.Unit theUnit) => theUnit.Name).ToList();
			strike_0.SpecificTargets = new HashSet<Module_Unit.Unit>(collection);
			strike_0.RTB_When_Target_Destroyed = true;
		}
	}

	private void FindInterruptibleInterpreter(object sender, EventArgs e)
	{
		Close();
	}

	private void SetInterruptibleInterpreter(object sender, FormClosingEventArgs e)
	{
		DateTimePicker_ActivationDate.ForeColor = Color.DimGray;
		DateTimePicker_ActivationTime.ForeColor = Color.DimGray;
		DateTimePicker_DeactivationDate.ForeColor = Color.DimGray;
		DateTimePicker_DeactivationTime.ForeColor = Color.DimGray;
		DateTimePicker_TakeOffDate.ForeColor = Color.DimGray;
		DateTimePicker_TakeOffTime.ForeColor = Color.DimGray;
		DateTimePicker_TimeOnTargetDate.ForeColor = Color.DimGray;
		DateTimePicker_TimeOnTargetTime.ForeColor = Color.DimGray;
		TextBox_Name.Focus();
		e.Cancel = true;
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	public static void ComboBoxDataSource_Category(ref DataTable dataTable_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, "Mission");
		if (InterpreterObjectListener.attrResolver)
		{
			dataTable_0.Rows.Add(1, "任务池");
			dataTable_0.Rows.Add(2, "Package");
		}
	}

	private void FillInterruptibleInterpreter(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		DataTable dataTable_ = new DataTable();
		ComboBoxDataSource_Category(ref dataTable_);
		DarkUIComboBox cB_Category = CB_Category;
		cB_Category.DataSource = dataTable_;
		cB_Category.DropDownWidth = 500;
		cB_Category.DisplayMember = "Description";
		cB_Category.ValueMember = "ID";
		CB_ParentPool.Visible = true;
		CheckBox_UnassignUnits.Visible = true;
		CheckBox_OrderRTB.Visible = true;
		CheckBox_DeleteMission.Visible = true;
		Label_ParentPool.Visible = true;
		PopInterruptibleInterpreter();
		Button1.Enabled = Operators.CompareString(TextBox_Name.Text, "", TextCompare: true) != 0;
	}

	private void CalculateInterruptibleInterpreter(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			TextBox_Name.Text = "";
			PopInterruptibleInterpreter();
		}
	}

	private void PopInterruptibleInterpreter()
	{
		TextBox_Name.Text = "";
		m_ServicePublisher = null;
		systemPublisher = null;
		candidatePublisher = null;
		basePublisher = null;
		if (CB_Category.Items.Count > 0)
		{
			CB_Category.SelectedIndex = 0;
		}
		ReadInterruptibleInterpreter();
		if (CB_MissionClass.Items.Count > 0)
		{
			CB_MissionClass.SelectedIndex = 0;
		}
		if (CB_MissionType.Items.Count > 0)
		{
			CB_MissionType.SelectedIndex = 0;
		}
		CB_OpenMissionEditor.Checked = regPublisher;
		if (CB_MissionStatus.Items.Count > 0)
		{
			CB_MissionStatus.SelectedIndex = 0;
		}
		GroupBox_ActivationTime.Visible = true;
		GroupBox_DeactivationTime.Visible = true;
		GroupBox_TakeOffTime.Visible = false;
		GroupBox_TimeOnTarget.Visible = false;
		DateTimePicker_ActivationDate.Mask = "YYYY-MM-DD";
		DateTimePicker_ActivationTime.Mask = "hh:mm:ss";
		DateTimePicker_DeactivationDate.Mask = "YYYY-MM-DD";
		DateTimePicker_DeactivationTime.Mask = "hh:mm:ss";
		DateTimePicker_TakeOffDate.Mask = "YYYY-MM-DD";
		DateTimePicker_TakeOffTime.Mask = "hh:mm:ss";
		DateTimePicker_TimeOnTargetDate.Mask = "YYYY-MM-DD";
		DateTimePicker_TimeOnTargetTime.Mask = "hh:mm:ss";
		SortInterruptibleInterpreter();
	}

	private void InstantiateInterruptibleInterpreter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (e.KeyCode == Keys.F11 && e.Modifiers == Keys.Control && base.Visible)
		{
			Close();
			return;
		}
		if (e.KeyCode == Keys.Return && base.Visible && Button1.Enabled)
		{
			InterruptInterruptibleInterpreter();
		}
		if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CreateInterruptibleInterpreter(object sender, EventArgs e)
	{
		regPublisher = CB_OpenMissionEditor.Checked;
	}

	private void CompareInterruptibleInterpreter(object sender, EventArgs e)
	{
		ReadInterruptibleInterpreter();
		if (CB_MissionClass.Items.Count > 0 && CB_MissionClass.SelectedIndex < 0)
		{
			CB_MissionClass.SelectedIndex = 0;
		}
		if (CB_MissionType.Items.Count > 0 && CB_MissionType.SelectedIndex < 0)
		{
			CB_MissionType.SelectedIndex = 0;
		}
	}

	private void ReadInterruptibleInterpreter()
	{
		if (CB_Category.SelectedIndex == -1)
		{
			return;
		}
		switch (CB_Category.SelectedIndex)
		{
		case 1:
			GroupBox_ActivationTime.Visible = false;
			GroupBox_DeactivationTime.Visible = false;
			GroupBox_TakeOffTime.Visible = false;
			GroupBox_TimeOnTarget.Visible = false;
			CB_ParentPool.Enabled = false;
			Label_ParentPool.Enabled = false;
			CB_ParentPool.Items.Clear();
			CB_MissionClass.Items.Clear();
			CB_MissionClass.Enabled = false;
			Label_MissionClass.Enabled = false;
			CB_MissionType.Items.Clear();
			CB_MissionType.Enabled = false;
			Label_MissionType.Enabled = false;
			TextBox_Name.Text = "任务池: <name>";
			break;
		case 0:
		case 2:
			if (CB_Category.SelectedIndex == 2)
			{
				TextBox_Name.Text = "任务包" + Conversions.ToString(Client.CurrentSide.PackageID);
				GroupBox_ActivationTime.Visible = false;
				GroupBox_DeactivationTime.Visible = false;
				GroupBox_TakeOffTime.Visible = true;
				GroupBox_TimeOnTarget.Visible = true;
				CB_ParentPool.Enabled = true;
				Label_ParentPool.Enabled = true;
				CB_ParentPool.Items.Clear();
				foreach (Mission mission in Client.CurrentSide.Missions)
				{
					if (mission.Category == Mission.MissionCategory.TaskPool)
					{
						CB_ParentPool.Items.Add(mission.Name);
					}
				}
				if (CB_ParentPool.Items.Count > 0)
				{
					CB_ParentPool.SelectedIndex = 0;
				}
			}
			else
			{
				TextBox_Name.Text = "任务: <name>";
				GroupBox_ActivationTime.Visible = true;
				GroupBox_DeactivationTime.Visible = true;
				GroupBox_TakeOffTime.Visible = false;
				GroupBox_TimeOnTarget.Visible = false;
				CB_ParentPool.Enabled = false;
				Label_ParentPool.Enabled = true;
				CB_ParentPool.Items.Clear();
			}
			CB_MissionType.Items.Clear();
			CB_MissionType.Enabled = false;
			Label_MissionType.Enabled = false;
			CB_MissionClass.Enabled = true;
			Label_MissionClass.Enabled = true;
			CB_MissionClass.Items.Clear();
			CB_MissionClass.Items.Add("攻击（包括空中拦截）");
			CB_MissionClass.Items.Add("Patrol");
			CB_MissionClass.Items.Add("Support");
			CB_MissionClass.Items.Add("Ferry");
			CB_MissionClass.Items.Add("Mining");
			CB_MissionClass.Items.Add("Mine-clearing");
			CB_MissionClass.Items.Add("Cargo");
			break;
		}
		SortInterruptibleInterpreter();
	}

	private void DisableInterruptibleInterpreter(object sender, EventArgs e)
	{
		paramPublisher = true;
		AssetInterruptibleInterpreter();
	}

	private void UpdateInterruptibleInterpreter(object sender, EventArgs e)
	{
		PrintInterruptibleInterpreter();
	}

	private void InsertInterruptibleInterpreter(object sender, EventArgs e)
	{
		paramPublisher = true;
		AssetInterruptibleInterpreter();
	}

	private void PrepareInterruptibleInterpreter(object sender, EventArgs e)
	{
		PrintInterruptibleInterpreter();
	}

	private void ReflectInterruptibleInterpreter(object sender, EventArgs e)
	{
		_PagePublisher = true;
		DefineInterruptibleInterpreter();
	}

	private void VisitInterruptibleInterpreter(object sender, EventArgs e)
	{
		PublishInterruptibleInterpreter();
	}

	private void RestartInterruptibleInterpreter(object sender, EventArgs e)
	{
		_PagePublisher = true;
		DefineInterruptibleInterpreter();
	}

	private void TestInterruptibleInterpreter(object sender, EventArgs e)
	{
		PublishInterruptibleInterpreter();
	}

	private void StopInterruptibleInterpreter(object sender, EventArgs e)
	{
		rulesPublisher = true;
		AwakeInterruptibleInterpreter();
	}

	private void CancelInterruptibleInterpreter(object sender, EventArgs e)
	{
		QueryInterruptibleInterpreter();
	}

	private void VerifyInterruptibleInterpreter(object sender, EventArgs e)
	{
		rulesPublisher = true;
		AwakeInterruptibleInterpreter();
	}

	private void ListInterruptibleInterpreter(object sender, EventArgs e)
	{
		QueryInterruptibleInterpreter();
	}

	private void ResolveInterruptibleInterpreter(object sender, EventArgs e)
	{
		methodPublisher = true;
		ResetInterruptibleInterpreter();
	}

	private void PostInterruptibleInterpreter(object sender, EventArgs e)
	{
		MapInterruptibleInterpreter();
	}

	private void RunInterruptibleInterpreter(object sender, EventArgs e)
	{
		methodPublisher = true;
		ResetInterruptibleInterpreter();
	}

	private void StartInterruptibleInterpreter(object sender, EventArgs e)
	{
		MapInterruptibleInterpreter();
	}

	private void AssetInterruptibleInterpreter()
	{
		if (Information.IsNothing(m_ServicePublisher))
		{
			DateTimePicker_ActivationDate.ForeColor = Color.White;
			DateTimePicker_ActivationTime.ForeColor = Color.White;
			DateTimePicker_ActivationDate.Mask = "0000-00-00";
			DateTimePicker_ActivationTime.Mask = "00:00:00";
			DateTime dateTime_ = Client.CurrentScenario.Time;
			string string_ = "";
			string string_2 = "";
			GameGeneral.PaddedTimeString(ref dateTime_, ref string_);
			GameGeneral.PaddedDateString(ref dateTime_, ref string_2, bool_1: false);
			DateTimePicker_ActivationTime.Text = string_;
			DateTimePicker_ActivationDate.Text = string_2;
		}
	}

	private void PrintInterruptibleInterpreter()
	{
		try
		{
			if (!paramPublisher)
			{
				return;
			}
			DateTime dateTime_ = default(DateTime);
			int num = RuleTokenizer.ChangeServer(DateTimePicker_ActivationDate.Text, DateTimePicker_ActivationTime.Text, ref dateTime_);
			if (num == 0)
			{
				m_ServicePublisher = dateTime_;
				paramPublisher = false;
				return;
			}
			Interaction.Beep();
			if (num == 1)
			{
				DateTimePicker_ActivationDate.Select();
			}
			else
			{
				DateTimePicker_ActivationTime.Select();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DarkMessageBox.ShowError("Time format must be hh:mm:ss", "ToT Date or format error");
			ProjectData.ClearProjectError();
		}
	}

	private void DefineInterruptibleInterpreter()
	{
		if (Information.IsNothing(systemPublisher))
		{
			DateTimePicker_DeactivationDate.ForeColor = Color.White;
			DateTimePicker_DeactivationTime.ForeColor = Color.White;
			DateTimePicker_DeactivationDate.Mask = "0000-00-00";
			DateTimePicker_DeactivationTime.Mask = "00:00:00";
			DateTime dateTime_ = Client.CurrentScenario.Time.AddHours(3.0);
			string string_ = "";
			string string_2 = "";
			GameGeneral.PaddedTimeString(ref dateTime_, ref string_);
			GameGeneral.PaddedDateString(ref dateTime_, ref string_2, bool_1: false);
			DateTimePicker_DeactivationTime.Text = string_;
			DateTimePicker_DeactivationDate.Text = string_2;
		}
	}

	private void PublishInterruptibleInterpreter()
	{
		if (!_PagePublisher)
		{
			return;
		}
		DateTime dateTime_ = default(DateTime);
		int num = RuleTokenizer.ChangeServer(DateTimePicker_DeactivationDate.Text, DateTimePicker_DeactivationTime.Text, ref dateTime_);
		if (num == 0)
		{
			systemPublisher = dateTime_;
			_PagePublisher = false;
			return;
		}
		Interaction.Beep();
		if (num == 1)
		{
			DateTimePicker_DeactivationDate.Select();
		}
		else
		{
			DateTimePicker_DeactivationTime.Select();
		}
	}

	private void AwakeInterruptibleInterpreter()
	{
		if (Information.IsNothing(candidatePublisher))
		{
			DateTimePicker_TakeOffDate.ForeColor = Color.White;
			DateTimePicker_TakeOffTime.ForeColor = Color.White;
			DateTimePicker_TakeOffDate.Mask = "0000-00-00";
			DateTimePicker_TakeOffTime.Mask = "00:00:00";
			DateTime dateTime_ = Client.CurrentScenario.Time.AddMinutes(30.0);
			string string_ = "";
			string string_2 = "";
			GameGeneral.PaddedTimeString(ref dateTime_, ref string_);
			GameGeneral.PaddedDateString(ref dateTime_, ref string_2, bool_1: false);
			DateTimePicker_TakeOffDate.Text = string_2;
			DateTimePicker_TakeOffTime.Text = string_;
		}
	}

	private void QueryInterruptibleInterpreter()
	{
		try
		{
			if (!rulesPublisher)
			{
				return;
			}
			DateTimePicker_TakeOffDate.Mask = "0000-00-00";
			DateTimePicker_TakeOffTime.Mask = "00:00:00";
			List<string> list = DateTimePicker_TakeOffTime.Text.Split(':').ToList();
			if (Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2]))
			{
				List<string> list2 = DateTimePicker_TakeOffDate.Text.Split('-').ToList();
				if (Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1]) & Versioned.IsNumeric(list2[2]))
				{
					candidatePublisher = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
					SortInterruptibleInterpreter();
					rulesPublisher = false;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DarkMessageBox.ShowError("Date time format must be YYYY-MM-DD/ hh:mm:ss", "Take off  Date or format error");
			ProjectData.ClearProjectError();
		}
	}

	private void ResetInterruptibleInterpreter()
	{
		if (Information.IsNothing(basePublisher))
		{
			DateTimePicker_TimeOnTargetDate.ForeColor = Color.White;
			DateTimePicker_TimeOnTargetTime.ForeColor = Color.White;
			DateTimePicker_TimeOnTargetDate.Mask = "0000-00-00";
			DateTimePicker_TimeOnTargetTime.Mask = "00:00:00";
			DateTime dateTime_ = Client.CurrentScenario.Time.AddHours(3.0);
			string string_ = "";
			string string_2 = "";
			GameGeneral.PaddedTimeString(ref dateTime_, ref string_);
			GameGeneral.PaddedDateString(ref dateTime_, ref string_2, bool_1: false);
			DateTimePicker_TimeOnTargetDate.Text = string_2;
			DateTimePicker_TimeOnTargetTime.Text = string_;
		}
	}

	private void MapInterruptibleInterpreter()
	{
		try
		{
			if (!methodPublisher)
			{
				return;
			}
			DateTimePicker_TimeOnTargetDate.Mask = "0000-00-00";
			DateTimePicker_TimeOnTargetTime.Mask = "00:00:00";
			List<string> list = DateTimePicker_TimeOnTargetTime.Text.Split(':').ToList();
			if (Versioned.IsNumeric(list[0]) & Versioned.IsNumeric(list[1]) & Versioned.IsNumeric(list[2]))
			{
				List<string> list2 = DateTimePicker_TimeOnTargetDate.Text.Split('-').ToList();
				if (Versioned.IsNumeric(list2[0]) & Versioned.IsNumeric(list2[1]) & Versioned.IsNumeric(list2[2]))
				{
					basePublisher = new DateTime(Conversions.ToInteger(list2[0]), Conversions.ToInteger(list2[1]), Conversions.ToInteger(list2[2]), Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
					SortInterruptibleInterpreter();
					methodPublisher = false;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DarkMessageBox.ShowError("Date time format must be YYYY-MM-DD/ hh:mm:ss", "ToT Date or format error");
			ProjectData.ClearProjectError();
		}
	}

	private void SortInterruptibleInterpreter()
	{
		if (basePublisher.HasValue)
		{
			DateTimePicker_TakeOffDate.Enabled = false;
			DateTimePicker_TakeOffTime.Enabled = false;
			Button_Clear_TakeOffTime.Enabled = false;
			DateTimePicker_TimeOnTargetDate.Enabled = true;
			DateTimePicker_TimeOnTargetTime.Enabled = true;
			Button_Clear_TimeOnTarget.Enabled = true;
		}
		else if (candidatePublisher.HasValue)
		{
			DateTimePicker_TakeOffDate.Enabled = true;
			DateTimePicker_TakeOffTime.Enabled = true;
			Button_Clear_TakeOffTime.Enabled = true;
			DateTimePicker_TimeOnTargetDate.Enabled = false;
			DateTimePicker_TimeOnTargetTime.Enabled = false;
			Button_Clear_TimeOnTarget.Enabled = false;
		}
		else
		{
			DateTimePicker_TakeOffDate.Enabled = true;
			DateTimePicker_TakeOffTime.Enabled = true;
			Button_Clear_TakeOffTime.Enabled = true;
			DateTimePicker_TimeOnTargetDate.Enabled = true;
			DateTimePicker_TimeOnTargetTime.Enabled = true;
			Button_Clear_TimeOnTarget.Enabled = true;
		}
	}

	private void CalcInterruptibleInterpreter(object sender, EventArgs e)
	{
		m_ServicePublisher = null;
		DateTimePicker_ActivationDate.Mask = "";
		DateTimePicker_ActivationTime.Mask = "";
		DateTimePicker_ActivationDate.Text = "YYYY-MM-DD";
		DateTimePicker_ActivationTime.Text = "hh:mm:ss";
	}

	private void RateInterruptibleInterpreter(object sender, EventArgs e)
	{
		systemPublisher = null;
		DateTimePicker_DeactivationDate.Mask = "";
		DateTimePicker_DeactivationTime.Mask = "";
		DateTimePicker_DeactivationDate.Text = "YYYY-MM-DD";
		DateTimePicker_DeactivationTime.Text = "hh:mm:ss";
	}

	private void FlushInterruptibleInterpreter(object sender, EventArgs e)
	{
		candidatePublisher = null;
		DateTimePicker_TakeOffDate.Mask = "";
		DateTimePicker_TakeOffTime.Mask = "";
		DateTimePicker_TakeOffDate.Text = "YYYY-MM-DD";
		DateTimePicker_TakeOffTime.Text = "hh:mm:ss";
		SortInterruptibleInterpreter();
	}

	private void ForgotInterruptibleInterpreter(object sender, EventArgs e)
	{
		basePublisher = null;
		DateTimePicker_TimeOnTargetDate.Mask = "";
		DateTimePicker_TimeOnTargetTime.Mask = "";
		DateTimePicker_TimeOnTargetDate.Text = "YYYY-MM-DD";
		DateTimePicker_TimeOnTargetTime.Text = "hh:mm:ss";
		SortInterruptibleInterpreter();
	}

	private void CollectInterruptibleInterpreter(object sender, EventArgs e)
	{
		paramPublisher = true;
		PrintInterruptibleInterpreter();
	}

	private void OrderInterruptibleInterpreter(object sender, EventArgs e)
	{
		_PagePublisher = true;
		PublishInterruptibleInterpreter();
	}

	private void RegisterInterruptibleInterpreter(object sender, EventArgs e)
	{
		rulesPublisher = true;
		QueryInterruptibleInterpreter();
	}

	private void ManageInterruptibleInterpreter(object sender, EventArgs e)
	{
		methodPublisher = true;
		MapInterruptibleInterpreter();
	}
}
