using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command.My.Resources;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.PowerPacks;

namespace Command;

[DesignerGenerated]
public sealed class SpeedAlt : DarkSecondaryFormBase
{
	private IContainer _InvocationRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_Throttle")]
	private TrackBar m_ClassRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MaxSpeed")]
	private DarkLabel valueRecord;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private DarkLabel tokenizerRecord;

	[AccessedThroughProperty("Label_DesiredSpeed")]
	[CompilerGenerated]
	private DarkLabel stubRecord;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer m_WatcherRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_Altitude")]
	private TrackBar m_ReponseRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel m_DescriptorRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MaxAlt")]
	private DarkLabel m_TaskRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_MinAlt")]
	private DarkLabel filterRecord;

	[AccessedThroughProperty("Label_DesiredAlt")]
	[CompilerGenerated]
	private DarkLabel testsRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_CurrentAlt")]
	private DarkLabel m_InterpreterRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox_Altitude")]
	private DarkGroupBox m_ComposerRecord;

	[AccessedThroughProperty("CB_AltOverride")]
	[CompilerGenerated]
	private DarkCheckBox advisorRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SpeedOverride")]
	private DarkCheckBox _CustomerRecord;

	[AccessedThroughProperty("GroupBox_SubDepthPreset")]
	[CompilerGenerated]
	private DarkGroupBox m_SerializerRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_MaxDepth")]
	private DarkRadioButton _RefRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_UnderLayer")]
	private DarkRadioButton errorRecord;

	[AccessedThroughProperty("RB_OverLayer")]
	[CompilerGenerated]
	private DarkRadioButton _CodeRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Periscope")]
	private DarkRadioButton connectionRecord;

	[AccessedThroughProperty("RB_Shallow")]
	[CompilerGenerated]
	private DarkRadioButton contextRecord;

	[AccessedThroughProperty("RB_MediumAltitude12000")]
	[CompilerGenerated]
	private DarkRadioButton proccesorRecord;

	[AccessedThroughProperty("RB_LowAltitude2000")]
	[CompilerGenerated]
	private DarkRadioButton m_StrategyRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_MinAltitude")]
	private DarkRadioButton configurationRecord;

	[AccessedThroughProperty("RB_LowAltitude1000")]
	[CompilerGenerated]
	private DarkRadioButton tokenRecord;

	[AccessedThroughProperty("RB_HighAltitude25000")]
	[CompilerGenerated]
	private DarkRadioButton m_IndexerRecord;

	[AccessedThroughProperty("RB_HighAltitude36000")]
	[CompilerGenerated]
	private DarkRadioButton _ResolverRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_MaxAltitude")]
	private DarkRadioButton _PublisherRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Surface")]
	private DarkRadioButton _ServerRecord;

	[AccessedThroughProperty("TextBox_EnterSpeed")]
	[CompilerGenerated]
	private DarkUITextBox _AdapterRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_Speed")]
	private DarkLabel m_SchemaRecord;

	[AccessedThroughProperty("TextBox_EnterAltitude")]
	[CompilerGenerated]
	private DarkUITextBox _UtilsRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Full")]
	private DarkRadioButton m_SingletonRecord;

	[AccessedThroughProperty("RB_Cruise")]
	[CompilerGenerated]
	private DarkRadioButton recordRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Creep")]
	private DarkRadioButton _ExceptionRecord;

	[AccessedThroughProperty("RB_Stop")]
	[CompilerGenerated]
	private DarkRadioButton _AttrRecord;

	[AccessedThroughProperty("RB_Flank")]
	[CompilerGenerated]
	private DarkRadioButton _VisitorRecord;

	[AccessedThroughProperty("FlowLayoutPanel_Presets")]
	[CompilerGenerated]
	private FlowLayoutPanel exporterRecord;

	[AccessedThroughProperty("Label_WaypointName")]
	[CompilerGenerated]
	private DarkLabel prototypeRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox_Waypoint")]
	private DarkGroupBox m_ComparatorRecord;

	[AccessedThroughProperty("Label_TTG")]
	[CompilerGenerated]
	private DarkLabel itemRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Label_Fuel")]
	private DarkLabel creatorRecord;

	[AccessedThroughProperty("TextBox_WaypointDescription")]
	[CompilerGenerated]
	private DarkUITextBox templateRecord;

	[AccessedThroughProperty("CB_WaypointType")]
	[CompilerGenerated]
	private DarkUIComboBox mappingRecord;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel m_MockRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("LayerTopPictureBox")]
	private PictureBox m_FieldRecord;

	[AccessedThroughProperty("LayerBottomPictureBox")]
	[CompilerGenerated]
	private PictureBox queueRecord;

	[AccessedThroughProperty("SeaFloorPictureBox")]
	[CompilerGenerated]
	private PictureBox m_RegRecord;

	[AccessedThroughProperty("GroundLevelPictureBox")]
	[CompilerGenerated]
	private PictureBox m_PageRecord;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel m_MethodRecord;

	[AccessedThroughProperty("Label9")]
	[CompilerGenerated]
	private DarkLabel serviceRecord;

	[AccessedThroughProperty("Label10")]
	[CompilerGenerated]
	private DarkLabel m_SystemRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("CloudLowBottomPictureBox")]
	private PictureBox baseRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("CloudHighBottomPictureBox")]
	private PictureBox policyRecord;

	[AccessedThroughProperty("Label_Cavitation")]
	[CompilerGenerated]
	private DarkLabel m_AlgoRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_TerrainFollowing")]
	private DarkCheckBox databaseRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UseLandCoverMasking")]
	private DarkCheckBox m_InterceptorRecord;

	[AccessedThroughProperty("ShapeContainer1")]
	[CompilerGenerated]
	private ShapeContainer messageRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("LineShape1")]
	private LineShape m_AnnotationRecord;

	[AccessedThroughProperty("RB_NoThrottlePreset")]
	[CompilerGenerated]
	private DarkRadioButton _IteratorRecord;

	[AccessedThroughProperty("RB_NoAltitudePreset")]
	[CompilerGenerated]
	private DarkRadioButton initializerRecord;

	[AccessedThroughProperty("RB_NoDepthPreset")]
	[CompilerGenerated]
	private DarkRadioButton m_RoleRecord;

	[AccessedThroughProperty("CB_SprintDrift")]
	[CompilerGenerated]
	private DarkCheckBox factoryRecord;

	[AccessedThroughProperty("CB_AvoidCavitation")]
	[CompilerGenerated]
	private DarkCheckBox attributeRecord;

	[AccessedThroughProperty("Label_SettingsFor")]
	[CompilerGenerated]
	private DarkLabel accountRecord;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Previous")]
	private DarkButton m_StateRecord;

	[AccessedThroughProperty("Button_Next")]
	[CompilerGenerated]
	private DarkButton _AuthenticationRecord;

	public ActiveUnit SpeedAlt_SelectedUnit;

	public Waypoint SpeedAlt_FlightPlanWaypoint;

	public Mission.Flight SpeedAlt_Flight;

	public Mission SpeedAlt_Mission;

	private bool m_InfoRecord;

	private bool helperRecord;

	private bool m_MapperRecord;

	private bool managerRecord;

	private Keys[] getterRecord;

	private Keys[] m_ProducerRecord;

	private Keys[] procRecord;

	private bool _StructException;

	private bool _MerchantException;

	internal TrackBar TrackBar_Throttle
	{
		[CompilerGenerated]
		get
		{
			return m_ClassRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapInterruptibleSchema;
			TrackBar classRecord = m_ClassRecord;
			if (classRecord != null)
			{
				classRecord.Scroll -= value2;
			}
			m_ClassRecord = value;
			classRecord = m_ClassRecord;
			if (classRecord != null)
			{
				classRecord.Scroll += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label_MinSpeed")]
	internal DarkLabel Label_MinSpeed
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_MaxSpeed
	{
		[CompilerGenerated]
		get
		{
			return valueRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valueRecord = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return tokenizerRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenizerRecord = value;
		}
	}

	internal DarkLabel Label_DesiredSpeed
	{
		[CompilerGenerated]
		get
		{
			return stubRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stubRecord = value;
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label_ActualSpeed")]
	internal DarkLabel Label_ActualSpeed
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar TrackBar_Altitude
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortInterruptibleSchema;
			TrackBar reponseRecord = m_ReponseRecord;
			if (reponseRecord != null)
			{
				reponseRecord.Scroll -= value2;
			}
			m_ReponseRecord = value;
			reponseRecord = m_ReponseRecord;
			if (reponseRecord != null)
			{
				reponseRecord.Scroll += value2;
			}
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DescriptorRecord = value;
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_MaxAlt
	{
		[CompilerGenerated]
		get
		{
			return m_TaskRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TaskRecord = value;
		}
	}

	internal DarkLabel Label_MinAlt
	{
		[CompilerGenerated]
		get
		{
			return filterRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			filterRecord = value;
		}
	}

	internal DarkLabel Label_DesiredAlt
	{
		[CompilerGenerated]
		get
		{
			return testsRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsRecord = value;
		}
	}

	internal DarkLabel Label_CurrentAlt
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterpreterRecord = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox_Speed")]
	internal DarkGroupBox GroupBox_Speed
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkGroupBox GroupBox_Altitude
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerRecord = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox_SpeedPresets")]
	internal DarkGroupBox GroupBox_SpeedPresets
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_AltOverride
	{
		[CompilerGenerated]
		get
		{
			return advisorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CB_AltOverride_Click;
			DarkCheckBox darkCheckBox = advisorRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			advisorRecord = value;
			darkCheckBox = advisorRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_SpeedOverride
	{
		[CompilerGenerated]
		get
		{
			return _CustomerRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CB_SpeedOverride_Click;
			DarkCheckBox customerRecord = _CustomerRecord;
			if (customerRecord != null)
			{
				customerRecord.Click -= value2;
			}
			_CustomerRecord = value;
			customerRecord = _CustomerRecord;
			if (customerRecord != null)
			{
				customerRecord.Click += value2;
			}
		}
	}

	internal DarkGroupBox GroupBox_SubDepthPreset
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SerializerRecord = value;
		}
	}

	internal DarkRadioButton RB_MaxDepth
	{
		[CompilerGenerated]
		get
		{
			return _RefRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountInterruptibleUtils;
			DarkRadioButton refRecord = _RefRecord;
			if (refRecord != null)
			{
				refRecord.CheckedChanged -= value2;
			}
			_RefRecord = value;
			refRecord = _RefRecord;
			if (refRecord != null)
			{
				refRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_UnderLayer
	{
		[CompilerGenerated]
		get
		{
			return errorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertInterruptibleSchema;
			DarkRadioButton darkRadioButton = errorRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			errorRecord = value;
			darkRadioButton = errorRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_OverLayer
	{
		[CompilerGenerated]
		get
		{
			return _CodeRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageInterruptibleSchema;
			DarkRadioButton codeRecord = _CodeRecord;
			if (codeRecord != null)
			{
				codeRecord.CheckedChanged -= value2;
			}
			_CodeRecord = value;
			codeRecord = _CodeRecord;
			if (codeRecord != null)
			{
				codeRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_Periscope
	{
		[CompilerGenerated]
		get
		{
			return connectionRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderInterruptibleSchema;
			DarkRadioButton darkRadioButton = connectionRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			connectionRecord = value;
			darkRadioButton = connectionRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_Shallow
	{
		[CompilerGenerated]
		get
		{
			return contextRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterInterruptibleSchema;
			DarkRadioButton darkRadioButton = contextRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			contextRecord = value;
			darkRadioButton = contextRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox_AltitudePresets")]
	internal DarkGroupBox GroupBox_AltitudePresets
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkRadioButton RB_MediumAltitude12000
	{
		[CompilerGenerated]
		get
		{
			return proccesorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddInterruptibleUtils;
			DarkRadioButton darkRadioButton = proccesorRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			proccesorRecord = value;
			darkRadioButton = proccesorRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_LowAltitude2000
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyInterruptibleUtils;
			DarkRadioButton strategyRecord = m_StrategyRecord;
			if (strategyRecord != null)
			{
				strategyRecord.CheckedChanged -= value2;
			}
			m_StrategyRecord = value;
			strategyRecord = m_StrategyRecord;
			if (strategyRecord != null)
			{
				strategyRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_MinAltitude
	{
		[CompilerGenerated]
		get
		{
			return configurationRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchInterruptibleUtils;
			DarkRadioButton darkRadioButton = configurationRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			configurationRecord = value;
			darkRadioButton = configurationRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_LowAltitude1000
	{
		[CompilerGenerated]
		get
		{
			return tokenRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeInterruptibleUtils;
			DarkRadioButton darkRadioButton = tokenRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			tokenRecord = value;
			darkRadioButton = tokenRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_HighAltitude25000
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteInterruptibleUtils;
			DarkRadioButton indexerRecord = m_IndexerRecord;
			if (indexerRecord != null)
			{
				indexerRecord.CheckedChanged -= value2;
			}
			m_IndexerRecord = value;
			indexerRecord = m_IndexerRecord;
			if (indexerRecord != null)
			{
				indexerRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_HighAltitude36000
	{
		[CompilerGenerated]
		get
		{
			return _ResolverRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveInterruptibleUtils;
			DarkRadioButton resolverRecord = _ResolverRecord;
			if (resolverRecord != null)
			{
				resolverRecord.CheckedChanged -= value2;
			}
			_ResolverRecord = value;
			resolverRecord = _ResolverRecord;
			if (resolverRecord != null)
			{
				resolverRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_MaxAltitude
	{
		[CompilerGenerated]
		get
		{
			return _PublisherRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneInterruptibleUtils;
			DarkRadioButton publisherRecord = _PublisherRecord;
			if (publisherRecord != null)
			{
				publisherRecord.CheckedChanged -= value2;
			}
			_PublisherRecord = value;
			publisherRecord = _PublisherRecord;
			if (publisherRecord != null)
			{
				publisherRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_Surface
	{
		[CompilerGenerated]
		get
		{
			return _ServerRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectInterruptibleSchema;
			DarkRadioButton serverRecord = _ServerRecord;
			if (serverRecord != null)
			{
				serverRecord.CheckedChanged -= value2;
			}
			_ServerRecord = value;
			serverRecord = _ServerRecord;
			if (serverRecord != null)
			{
				serverRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkUITextBox TextBox_EnterSpeed
	{
		[CompilerGenerated]
		get
		{
			return _AdapterRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectInterruptibleUtils;
			EventHandler value3 = CallInterruptibleUtils;
			DarkUITextBox adapterRecord = _AdapterRecord;
			if (adapterRecord != null)
			{
				adapterRecord.Enter -= value2;
				adapterRecord.Leave -= value3;
			}
			_AdapterRecord = value;
			adapterRecord = _AdapterRecord;
			if (adapterRecord != null)
			{
				adapterRecord.Enter += value2;
				adapterRecord.Leave += value3;
			}
		}
	}

	internal DarkLabel Label_Speed
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SchemaRecord = value;
		}
	}

	internal DarkUITextBox TextBox_EnterAltitude
	{
		[CompilerGenerated]
		get
		{
			return _UtilsRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutInterruptibleUtils;
			EventHandler value3 = ValidateInterruptibleUtils;
			DarkUITextBox utilsRecord = _UtilsRecord;
			if (utilsRecord != null)
			{
				utilsRecord.Enter -= value2;
				utilsRecord.Leave -= value3;
			}
			_UtilsRecord = value;
			utilsRecord = _UtilsRecord;
			if (utilsRecord != null)
			{
				utilsRecord.Enter += value2;
				utilsRecord.Leave += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label_Altitude")]
	internal DarkLabel Label_Altitude
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkRadioButton RB_Full
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeInterruptibleSchema;
			DarkRadioButton singletonRecord = m_SingletonRecord;
			if (singletonRecord != null)
			{
				singletonRecord.CheckedChanged -= value2;
			}
			m_SingletonRecord = value;
			singletonRecord = m_SingletonRecord;
			if (singletonRecord != null)
			{
				singletonRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_Cruise
	{
		[CompilerGenerated]
		get
		{
			return recordRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishInterruptibleSchema;
			DarkRadioButton darkRadioButton = recordRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			recordRecord = value;
			darkRadioButton = recordRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_Creep
	{
		[CompilerGenerated]
		get
		{
			return _ExceptionRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintInterruptibleSchema;
			DarkRadioButton exceptionRecord = _ExceptionRecord;
			if (exceptionRecord != null)
			{
				exceptionRecord.CheckedChanged -= value2;
			}
			_ExceptionRecord = value;
			exceptionRecord = _ExceptionRecord;
			if (exceptionRecord != null)
			{
				exceptionRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_Stop
	{
		[CompilerGenerated]
		get
		{
			return _AttrRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AssetInterruptibleSchema;
			DarkRadioButton attrRecord = _AttrRecord;
			if (attrRecord != null)
			{
				attrRecord.CheckedChanged -= value2;
			}
			_AttrRecord = value;
			attrRecord = _AttrRecord;
			if (attrRecord != null)
			{
				attrRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_Flank
	{
		[CompilerGenerated]
		get
		{
			return _VisitorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetInterruptibleSchema;
			DarkRadioButton visitorRecord = _VisitorRecord;
			if (visitorRecord != null)
			{
				visitorRecord.CheckedChanged -= value2;
			}
			_VisitorRecord = value;
			visitorRecord = _VisitorRecord;
			if (visitorRecord != null)
			{
				visitorRecord.CheckedChanged += value2;
			}
		}
	}

	internal FlowLayoutPanel FlowLayoutPanel_Presets
	{
		[CompilerGenerated]
		get
		{
			return exporterRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterRecord = value;
		}
	}

	internal DarkLabel Label_WaypointName
	{
		[CompilerGenerated]
		get
		{
			return prototypeRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			prototypeRecord = value;
		}
	}

	internal DarkGroupBox GroupBox_Waypoint
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComparatorRecord = value;
		}
	}

	internal DarkLabel Label_TTG
	{
		[CompilerGenerated]
		get
		{
			return itemRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			itemRecord = value;
		}
	}

	[field: AccessedThroughProperty("Label_DTG")]
	internal DarkLabel Label_DTG
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_Fuel
	{
		[CompilerGenerated]
		get
		{
			return creatorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			creatorRecord = value;
		}
	}

	internal DarkUITextBox TextBox_WaypointDescription
	{
		[CompilerGenerated]
		get
		{
			return templateRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushInterruptibleUtils;
			EventHandler value3 = InvokeInterruptibleUtils;
			DarkUITextBox darkUITextBox = templateRecord;
			if (darkUITextBox != null)
			{
				darkUITextBox.Enter -= value2;
				darkUITextBox.Leave -= value3;
			}
			templateRecord = value;
			darkUITextBox = templateRecord;
			if (darkUITextBox != null)
			{
				darkUITextBox.Enter += value2;
				darkUITextBox.Leave += value3;
			}
		}
	}

	internal DarkUIComboBox CB_WaypointType
	{
		[CompilerGenerated]
		get
		{
			return mappingRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteInterruptibleUtils;
			EventHandler value3 = NewInterruptibleUtils;
			DarkUIComboBox darkUIComboBox = mappingRecord;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.DropDown -= value2;
				darkUIComboBox.SelectionChangeCommitted -= value3;
			}
			mappingRecord = value;
			darkUIComboBox = mappingRecord;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.DropDown += value2;
				darkUIComboBox.SelectionChangeCommitted += value3;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_MockRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockRecord = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal PictureBox LayerTopPictureBox
	{
		[CompilerGenerated]
		get
		{
			return m_FieldRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FieldRecord = value;
		}
	}

	internal PictureBox LayerBottomPictureBox
	{
		[CompilerGenerated]
		get
		{
			return queueRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			queueRecord = value;
		}
	}

	internal PictureBox SeaFloorPictureBox
	{
		[CompilerGenerated]
		get
		{
			return m_RegRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RegRecord = value;
		}
	}

	[field: AccessedThroughProperty("CloudHighTopPictureBox")]
	internal PictureBox CloudHighTopPictureBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal PictureBox GroundLevelPictureBox
	{
		[CompilerGenerated]
		get
		{
			return m_PageRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageRecord = value;
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return m_MethodRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodRecord = value;
		}
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return serviceRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serviceRecord = value;
		}
	}

	internal DarkLabel Label10
	{
		[CompilerGenerated]
		get
		{
			return m_SystemRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SystemRecord = value;
		}
	}

	[field: AccessedThroughProperty("CloudLowTopPictureBox")]
	internal PictureBox CloudLowTopPictureBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal PictureBox CloudLowBottomPictureBox
	{
		[CompilerGenerated]
		get
		{
			return baseRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			baseRecord = value;
		}
	}

	internal PictureBox CloudHighBottomPictureBox
	{
		[CompilerGenerated]
		get
		{
			return policyRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			policyRecord = value;
		}
	}

	[field: AccessedThroughProperty("Label12")]
	internal DarkLabel Label12
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label11")]
	internal DarkLabel Label11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label14")]
	internal DarkLabel Label14
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label13")]
	internal DarkLabel Label13
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_Cavitation
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AlgoRecord = value;
		}
	}

	internal DarkCheckBox CB_TerrainFollowing
	{
		[CompilerGenerated]
		get
		{
			return databaseRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableInterruptibleUtils;
			DarkCheckBox darkCheckBox = databaseRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			databaseRecord = value;
			darkCheckBox = databaseRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_UseLandCoverMasking
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitInterruptibleUtils;
			DarkCheckBox interceptorRecord = m_InterceptorRecord;
			if (interceptorRecord != null)
			{
				interceptorRecord.CheckedChanged -= value2;
			}
			m_InterceptorRecord = value;
			interceptorRecord = m_InterceptorRecord;
			if (interceptorRecord != null)
			{
				interceptorRecord.CheckedChanged += value2;
			}
		}
	}

	private ShapeContainer ShapeContainer1
	{
		[CompilerGenerated]
		get
		{
			return messageRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			messageRecord = value;
		}
	}

	[field: AccessedThroughProperty("LineShape2")]
	private LineShape LineShape2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	private LineShape LineShape1
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationRecord = value;
		}
	}

	internal DarkRadioButton RB_NoThrottlePreset
	{
		[CompilerGenerated]
		get
		{
			return _IteratorRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryInterruptibleSchema;
			DarkRadioButton iteratorRecord = _IteratorRecord;
			if (iteratorRecord != null)
			{
				iteratorRecord.CheckedChanged -= value2;
			}
			_IteratorRecord = value;
			iteratorRecord = _IteratorRecord;
			if (iteratorRecord != null)
			{
				iteratorRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_NoAltitudePreset
	{
		[CompilerGenerated]
		get
		{
			return initializerRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectInterruptibleUtils;
			DarkRadioButton darkRadioButton = initializerRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged -= value2;
			}
			initializerRecord = value;
			darkRadioButton = initializerRecord;
			if (darkRadioButton != null)
			{
				darkRadioButton.CheckedChanged += value2;
			}
		}
	}

	internal DarkRadioButton RB_NoDepthPreset
	{
		[CompilerGenerated]
		get
		{
			return m_RoleRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeInterruptibleUtils;
			DarkRadioButton roleRecord = m_RoleRecord;
			if (roleRecord != null)
			{
				roleRecord.CheckedChanged -= value2;
			}
			m_RoleRecord = value;
			roleRecord = m_RoleRecord;
			if (roleRecord != null)
			{
				roleRecord.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_SprintDrift
	{
		[CompilerGenerated]
		get
		{
			return factoryRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleUtils;
			DarkCheckBox darkCheckBox = factoryRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			factoryRecord = value;
			darkCheckBox = factoryRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_AvoidCavitation
	{
		[CompilerGenerated]
		get
		{
			return attributeRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleUtils;
			DarkCheckBox darkCheckBox = attributeRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			attributeRecord = value;
			darkCheckBox = attributeRecord;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel2")]
	internal FlowLayoutPanel FlowLayoutPanel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label_X")]
	internal DarkLabel Label_X
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("FlowLayoutPanel_SettingsFor")]
	internal FlowLayoutPanel FlowLayoutPanel_SettingsFor
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label_SettingsFor
	{
		[CompilerGenerated]
		get
		{
			return accountRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			accountRecord = value;
		}
	}

	internal DarkButton Button_Previous
	{
		[CompilerGenerated]
		get
		{
			return m_StateRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button_Previous_Click;
			DarkButton stateRecord = m_StateRecord;
			if (stateRecord != null)
			{
				stateRecord.Click -= value2;
			}
			m_StateRecord = value;
			stateRecord = m_StateRecord;
			if (stateRecord != null)
			{
				stateRecord.Click += value2;
			}
		}
	}

	internal DarkButton Button_Next
	{
		[CompilerGenerated]
		get
		{
			return _AuthenticationRecord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button_Next_Click;
			DarkButton authenticationRecord = _AuthenticationRecord;
			if (authenticationRecord != null)
			{
				authenticationRecord.Click -= value2;
			}
			_AuthenticationRecord = value;
			authenticationRecord = _AuthenticationRecord;
			if (authenticationRecord != null)
			{
				authenticationRecord.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LblWeatherWarning")]
	internal DarkLabel LblWeatherWarning
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer PrepareInterruptibleUtils()
	{
		return m_WatcherRecord;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ReflectInterruptibleUtils(Timer timer_0)
	{
		EventHandler value = StartInterruptibleSchema;
		Timer watcherRecord = m_WatcherRecord;
		if (watcherRecord != null)
		{
			watcherRecord.Tick -= value;
		}
		m_WatcherRecord = timer_0;
		watcherRecord = m_WatcherRecord;
		if (watcherRecord != null)
		{
			watcherRecord.Tick += value;
		}
	}

	public SpeedAlt()
	{
		base.Load += ResolveInterruptibleSchema;
		base.KeyDown += GetInterruptibleUtils;
		base.FormClosing += ExcludeInterruptibleUtils;
		base.FormClosed += SearchInterruptibleUtils;
		m_InfoRecord = false;
		helperRecord = false;
		m_MapperRecord = false;
		managerRecord = true;
		getterRecord = new Keys[1] { Keys.E };
		m_ProducerRecord = new Keys[1] { Keys.Q };
		procRecord = new Keys[2]
		{
			Keys.F2,
			Keys.Escape
		};
		_StructException = false;
		_MerchantException = false;
		ListInterruptibleSchema();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _InvocationRecord != null)
			{
				_InvocationRecord.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ListInterruptibleSchema()
	{
		_InvocationRecord = new Container();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(SpeedAlt));
		ReflectInterruptibleUtils(new Timer(_InvocationRecord));
		FlowLayoutPanel2 = new FlowLayoutPanel();
		FlowLayoutPanel_SettingsFor = new FlowLayoutPanel();
		Label_X = new DarkLabel();
		Label_SettingsFor = new DarkLabel();
		Button_Previous = new DarkButton();
		Button_Next = new DarkButton();
		GroupBox_Waypoint = new DarkGroupBox();
		Label4 = new DarkLabel();
		Label1 = new DarkLabel();
		TextBox_WaypointDescription = new DarkUITextBox();
		CB_WaypointType = new DarkUIComboBox();
		Label_Fuel = new DarkLabel();
		Label_TTG = new DarkLabel();
		Label_DTG = new DarkLabel();
		Label_WaypointName = new DarkLabel();
		GroupBox_Speed = new DarkGroupBox();
		LblWeatherWarning = new DarkLabel();
		CB_AvoidCavitation = new DarkCheckBox();
		CB_SprintDrift = new DarkCheckBox();
		TextBox_EnterSpeed = new DarkUITextBox();
		CB_SpeedOverride = new DarkCheckBox();
		GroupBox_SpeedPresets = new DarkGroupBox();
		RB_NoThrottlePreset = new DarkRadioButton();
		RB_Flank = new DarkRadioButton();
		RB_Full = new DarkRadioButton();
		RB_Cruise = new DarkRadioButton();
		RB_Creep = new DarkRadioButton();
		RB_Stop = new DarkRadioButton();
		Label_Speed = new DarkLabel();
		Label_MinSpeed = new DarkLabel();
		TrackBar_Throttle = new TrackBar();
		Label_MaxSpeed = new DarkLabel();
		Label2 = new DarkLabel();
		Label_DesiredSpeed = new DarkLabel();
		Label3 = new DarkLabel();
		Label_ActualSpeed = new DarkLabel();
		Label_Cavitation = new DarkLabel();
		GroupBox_Altitude = new DarkGroupBox();
		Label_DesiredAlt = new DarkLabel();
		CB_TerrainFollowing = new DarkCheckBox();
		CB_UseLandCoverMasking = new DarkCheckBox();
		Label14 = new DarkLabel();
		Label13 = new DarkLabel();
		Label12 = new DarkLabel();
		Label11 = new DarkLabel();
		CloudLowTopPictureBox = new PictureBox();
		CloudLowBottomPictureBox = new PictureBox();
		CloudHighBottomPictureBox = new PictureBox();
		Label7 = new DarkLabel();
		Label10 = new DarkLabel();
		Label9 = new DarkLabel();
		Label8 = new DarkLabel();
		GroundLevelPictureBox = new PictureBox();
		CloudHighTopPictureBox = new PictureBox();
		SeaFloorPictureBox = new PictureBox();
		LayerBottomPictureBox = new PictureBox();
		LayerTopPictureBox = new PictureBox();
		Label_MaxAlt = new DarkLabel();
		Label_MinAlt = new DarkLabel();
		FlowLayoutPanel_Presets = new FlowLayoutPanel();
		GroupBox_AltitudePresets = new DarkGroupBox();
		RB_NoAltitudePreset = new DarkRadioButton();
		RB_MediumAltitude12000 = new DarkRadioButton();
		RB_LowAltitude2000 = new DarkRadioButton();
		RB_MinAltitude = new DarkRadioButton();
		RB_LowAltitude1000 = new DarkRadioButton();
		RB_HighAltitude25000 = new DarkRadioButton();
		RB_HighAltitude36000 = new DarkRadioButton();
		RB_MaxAltitude = new DarkRadioButton();
		GroupBox_SubDepthPreset = new DarkGroupBox();
		RB_NoDepthPreset = new DarkRadioButton();
		RB_Surface = new DarkRadioButton();
		RB_Shallow = new DarkRadioButton();
		RB_MaxDepth = new DarkRadioButton();
		RB_UnderLayer = new DarkRadioButton();
		RB_OverLayer = new DarkRadioButton();
		RB_Periscope = new DarkRadioButton();
		Label_Altitude = new DarkLabel();
		TextBox_EnterAltitude = new DarkUITextBox();
		CB_AltOverride = new DarkCheckBox();
		Label6 = new DarkLabel();
		TrackBar_Altitude = new TrackBar();
		Label_CurrentAlt = new DarkLabel();
		Label5 = new DarkLabel();
		ShapeContainer1 = new ShapeContainer();
		LineShape2 = new LineShape();
		LineShape1 = new LineShape();
		FlowLayoutPanel2.SuspendLayout();
		FlowLayoutPanel_SettingsFor.SuspendLayout();
		GroupBox_Waypoint.SuspendLayout();
		GroupBox_Speed.SuspendLayout();
		GroupBox_SpeedPresets.SuspendLayout();
		((ISupportInitialize)TrackBar_Throttle).BeginInit();
		GroupBox_Altitude.SuspendLayout();
		((ISupportInitialize)CloudLowTopPictureBox).BeginInit();
		((ISupportInitialize)CloudLowBottomPictureBox).BeginInit();
		((ISupportInitialize)CloudHighBottomPictureBox).BeginInit();
		((ISupportInitialize)GroundLevelPictureBox).BeginInit();
		((ISupportInitialize)CloudHighTopPictureBox).BeginInit();
		((ISupportInitialize)SeaFloorPictureBox).BeginInit();
		((ISupportInitialize)LayerBottomPictureBox).BeginInit();
		((ISupportInitialize)LayerTopPictureBox).BeginInit();
		FlowLayoutPanel_Presets.SuspendLayout();
		GroupBox_AltitudePresets.SuspendLayout();
		GroupBox_SubDepthPreset.SuspendLayout();
		((ISupportInitialize)TrackBar_Altitude).BeginInit();
		SuspendLayout();
		PrepareInterruptibleUtils().Interval = 1000;
		FlowLayoutPanel2.Controls.Add(FlowLayoutPanel_SettingsFor);
		FlowLayoutPanel2.Controls.Add(GroupBox_Waypoint);
		FlowLayoutPanel2.Controls.Add(GroupBox_Speed);
		FlowLayoutPanel2.Controls.Add(GroupBox_Altitude);
		FlowLayoutPanel2.Dock = DockStyle.Fill;
		FlowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
		FlowLayoutPanel2.Location = new Point(0, 0);
		FlowLayoutPanel2.Name = "FlowLayoutPanel2";
		FlowLayoutPanel2.Size = new Size(419, 670);
		FlowLayoutPanel2.TabIndex = 19;
		FlowLayoutPanel_SettingsFor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		FlowLayoutPanel_SettingsFor.Controls.Add(Label_X);
		FlowLayoutPanel_SettingsFor.Controls.Add(Label_SettingsFor);
		FlowLayoutPanel_SettingsFor.Controls.Add(Button_Previous);
		FlowLayoutPanel_SettingsFor.Controls.Add(Button_Next);
		FlowLayoutPanel_SettingsFor.Location = new Point(3, 3);
		FlowLayoutPanel_SettingsFor.Name = "FlowLayoutPanel_SettingsFor";
		FlowLayoutPanel_SettingsFor.Size = new Size(409, 27);
		FlowLayoutPanel_SettingsFor.TabIndex = 20;
		Label_X.AutoSize = true;
		Label_X.Font = new Font("Segoe UI", 14f);
		Label_X.ForeColor = Color.FromArgb(220, 220, 220);
		Label_X.Location = new Point(3, 0);
		Label_X.Name = "Label_X";
		Label_X.Size = new Size(165, 38);
		Label_X.TabIndex = 19;
		Label_X.Text = "设置：";
		Label_SettingsFor.AutoSize = true;
		Label_SettingsFor.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
		Label_SettingsFor.ForeColor = Color.FromArgb(220, 220, 220);
		Label_SettingsFor.Location = new Point(174, 0);
		Label_SettingsFor.Name = "Label_SettingsFor";
		Label_SettingsFor.Size = new Size(84, 38);
		Label_SettingsFor.TabIndex = 20;
		Label_SettingsFor.Text = "单元";
		Button_Previous.Image = componentResourceManager.GetObject("Button_Previous.Image");
		Button_Previous.Location = new Point(264, 3);
		Button_Previous.Name = "Button_Previous";
		Button_Previous.Padding = new Padding(5);
		Button_Previous.Size = new Size(15, 23);
		Button_Previous.TabIndex = 21;
		Button_Next.Image = componentResourceManager.GetObject("Button_Next.Image");
		Button_Next.Location = new Point(285, 3);
		Button_Next.Name = "Button_Next";
		Button_Next.Padding = new Padding(5);
		Button_Next.Size = new Size(15, 23);
		Button_Next.TabIndex = 22;
		GroupBox_Waypoint.Controls.Add(Label4);
		GroupBox_Waypoint.Controls.Add(Label1);
		GroupBox_Waypoint.Controls.Add(TextBox_WaypointDescription);
		GroupBox_Waypoint.Controls.Add(CB_WaypointType);
		GroupBox_Waypoint.Controls.Add(Label_Fuel);
		GroupBox_Waypoint.Controls.Add(Label_TTG);
		GroupBox_Waypoint.Controls.Add(Label_DTG);
		GroupBox_Waypoint.Controls.Add(Label_WaypointName);
		GroupBox_Waypoint.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_Waypoint.Location = new Point(3, 36);
		GroupBox_Waypoint.Name = "GroupBox_Waypoint";
		GroupBox_Waypoint.Size = new Size(409, 131);
		GroupBox_Waypoint.TabIndex = 18;
		GroupBox_Waypoint.TabStop = false;
		GroupBox_Waypoint.Text = "航点";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(5, 102);
		Label4.Name = "Label4";
		Label4.Size = new Size(53, 25);
		Label4.TabIndex = 21;
		Label4.Text = "类型：";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(5, 84);
		Label1.Name = "Label1";
		Label1.Size = new Size(106, 25);
		Label1.TabIndex = 20;
		Label1.Text = "描述：";
		TextBox_WaypointDescription.AutoCompleteCustomSource = null;
		TextBox_WaypointDescription.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_WaypointDescription.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_WaypointDescription.BackColor = Color.Transparent;
		TextBox_WaypointDescription.Font = new Font("Segoe UI", 8f);
		TextBox_WaypointDescription.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_WaypointDescription.Image = null;
		TextBox_WaypointDescription.Lines = null;
		TextBox_WaypointDescription.Location = new Point(77, 80);
		TextBox_WaypointDescription.MaxLength = 32767;
		TextBox_WaypointDescription.Multiline = false;
		TextBox_WaypointDescription.Name = "TextBox_WaypointDescription";
		TextBox_WaypointDescription.ReadOnly = false;
		TextBox_WaypointDescription.ScrollBars = ScrollBars.None;
		TextBox_WaypointDescription.SelectionStart = 0;
		TextBox_WaypointDescription.Size = new Size(325, 20);
		TextBox_WaypointDescription.TabIndex = 19;
		TextBox_WaypointDescription.TextAlign = HorizontalAlignment.Left;
		TextBox_WaypointDescription.UseSystemPasswordChar = false;
		TextBox_WaypointDescription.WatermarkText = "";
		CB_WaypointType.BackColor = Color.Transparent;
		CB_WaypointType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_WaypointType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_WaypointType.Font = new Font("Segoe UI", 7f);
		CB_WaypointType.FormattingEnabled = true;
		CB_WaypointType.Items.AddRange(new object[16]
		{
			"组成编队队形", "规划路径/导航", "目标", "转弯点", "Initial Point", "Ingress", "Egress", "TakeOff", "Hold (Start)", "Hold (End)",
			"转弯点", "Landing Marshall", "地面作战", "Patrol Station", "Localization Run", "加油"
		});
		CB_WaypointType.Location = new Point(77, 102);
		CB_WaypointType.Name = "CB_WaypointType";
		CB_WaypointType.Size = new Size(325, 27);
		CB_WaypointType.TabIndex = 18;
		Label_Fuel.AutoSize = true;
		Label_Fuel.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Fuel.Location = new Point(5, 61);
		Label_Fuel.Name = "Label_Fuel";
		Label_Fuel.Size = new Size(92, 25);
		Label_Fuel.TabIndex = 17;
		Label_Fuel.Text = "Label_Fuel";
		Label_TTG.AutoSize = true;
		Label_TTG.ForeColor = Color.FromArgb(220, 220, 220);
		Label_TTG.Location = new Point(88, 43);
		Label_TTG.Name = "Label_TTG";
		Label_TTG.Size = new Size(89, 25);
		Label_TTG.TabIndex = 16;
		Label_TTG.Text = "Label_TTG";
		Label_DTG.AutoSize = true;
		Label_DTG.ForeColor = Color.FromArgb(220, 220, 220);
		Label_DTG.Location = new Point(5, 43);
		Label_DTG.Name = "Label_DTG";
		Label_DTG.Size = new Size(92, 25);
		Label_DTG.TabIndex = 15;
		Label_DTG.Text = "Label_DTG";
		Label_WaypointName.AutoSize = true;
		Label_WaypointName.ForeColor = Color.FromArgb(220, 220, 220);
		Label_WaypointName.Location = new Point(5, 20);
		Label_WaypointName.Name = "Label_WaypointName";
		Label_WaypointName.Size = new Size(135, 25);
		Label_WaypointName.TabIndex = 11;
		Label_WaypointName.Text = "路径点名称";
		GroupBox_Speed.Controls.Add(LblWeatherWarning);
		GroupBox_Speed.Controls.Add(CB_AvoidCavitation);
		GroupBox_Speed.Controls.Add(CB_SprintDrift);
		GroupBox_Speed.Controls.Add(TextBox_EnterSpeed);
		GroupBox_Speed.Controls.Add(CB_SpeedOverride);
		GroupBox_Speed.Controls.Add(GroupBox_SpeedPresets);
		GroupBox_Speed.Controls.Add(Label_Speed);
		GroupBox_Speed.Controls.Add(Label_MinSpeed);
		GroupBox_Speed.Controls.Add(TrackBar_Throttle);
		GroupBox_Speed.Controls.Add(Label_MaxSpeed);
		GroupBox_Speed.Controls.Add(Label2);
		GroupBox_Speed.Controls.Add(Label_DesiredSpeed);
		GroupBox_Speed.Controls.Add(Label3);
		GroupBox_Speed.Controls.Add(Label_ActualSpeed);
		GroupBox_Speed.Controls.Add(Label_Cavitation);
		GroupBox_Speed.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_Speed.Location = new Point(3, 173);
		GroupBox_Speed.Name = "GroupBox_Speed";
		GroupBox_Speed.Size = new Size(409, 181);
		GroupBox_Speed.TabIndex = 16;
		GroupBox_Speed.TabStop = false;
		GroupBox_Speed.Text = "油门";
		LblWeatherWarning.AutoSize = true;
		LblWeatherWarning.ForeColor = Color.Orange;
		LblWeatherWarning.Location = new Point(8, 19);
		LblWeatherWarning.Name = "LblWeatherWarning";
		LblWeatherWarning.Size = new Size(193, 25);
		LblWeatherWarning.TabIndex = 14;
		LblWeatherWarning.Text = "WeatherSpeedWarning";
		CB_AvoidCavitation.AutoSize = true;
		CB_AvoidCavitation.Location = new Point(294, 81);
		CB_AvoidCavitation.Name = "CB_AvoidCavitation";
		CB_AvoidCavitation.Size = new Size(169, 29);
		CB_AvoidCavitation.TabIndex = 13;
		CB_AvoidCavitation.Text = "避免空泡";
		CB_SprintDrift.AutoSize = true;
		CB_SprintDrift.Location = new Point(294, 39);
		CB_SprintDrift.Name = "CB_SprintDrift";
		CB_SprintDrift.Size = new Size(163, 29);
		CB_SprintDrift.TabIndex = 12;
		CB_SprintDrift.Text = "冲刺和漂移";
		TextBox_EnterSpeed.AutoCompleteCustomSource = null;
		TextBox_EnterSpeed.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_EnterSpeed.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_EnterSpeed.BackColor = Color.Transparent;
		TextBox_EnterSpeed.Font = new Font("Segoe UI", 8f);
		TextBox_EnterSpeed.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_EnterSpeed.Image = null;
		TextBox_EnterSpeed.Lines = null;
		TextBox_EnterSpeed.Location = new Point(119, 37);
		TextBox_EnterSpeed.MaxLength = 32767;
		TextBox_EnterSpeed.Multiline = false;
		TextBox_EnterSpeed.Name = "TextBox_EnterSpeed";
		TextBox_EnterSpeed.ReadOnly = false;
		TextBox_EnterSpeed.ScrollBars = ScrollBars.None;
		TextBox_EnterSpeed.SelectionStart = 0;
		TextBox_EnterSpeed.Size = new Size(60, 20);
		TextBox_EnterSpeed.TabIndex = 2;
		TextBox_EnterSpeed.TextAlign = HorizontalAlignment.Left;
		TextBox_EnterSpeed.UseSystemPasswordChar = false;
		TextBox_EnterSpeed.WatermarkText = "";
		CB_SpeedOverride.AutoSize = true;
		CB_SpeedOverride.Location = new Point(9, 39);
		CB_SpeedOverride.Name = "CB_SpeedOverride";
		CB_SpeedOverride.Size = new Size(169, 29);
		CB_SpeedOverride.TabIndex = 1;
		CB_SpeedOverride.Text = "手动覆盖";
		GroupBox_SpeedPresets.Controls.Add(RB_NoThrottlePreset);
		GroupBox_SpeedPresets.Controls.Add(RB_Flank);
		GroupBox_SpeedPresets.Controls.Add(RB_Full);
		GroupBox_SpeedPresets.Controls.Add(RB_Cruise);
		GroupBox_SpeedPresets.Controls.Add(RB_Creep);
		GroupBox_SpeedPresets.Controls.Add(RB_Stop);
		GroupBox_SpeedPresets.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_SpeedPresets.Location = new Point(6, 132);
		GroupBox_SpeedPresets.Name = "GroupBox_SpeedPresets";
		GroupBox_SpeedPresets.Size = new Size(397, 44);
		GroupBox_SpeedPresets.TabIndex = 10;
		GroupBox_SpeedPresets.TabStop = false;
		GroupBox_SpeedPresets.Text = "油门预设";
		RB_NoThrottlePreset.BackColor = Color.Transparent;
		RB_NoThrottlePreset.Cursor = Cursors.Hand;
		RB_NoThrottlePreset.Font = new Font("Segoe UI", 9f);
		RB_NoThrottlePreset.ForeColor = Color.FromArgb(209, 209, 209);
		RB_NoThrottlePreset.Location = new Point(339, 20);
		RB_NoThrottlePreset.Name = "RB_NoThrottlePreset";
		RB_NoThrottlePreset.Size = new Size(51, 21);
		RB_NoThrottlePreset.TabIndex = 5;
		RB_NoThrottlePreset.Text = "无";
		RB_Flank.BackColor = Color.Transparent;
		RB_Flank.Cursor = Cursors.Hand;
		RB_Flank.Font = new Font("Segoe UI", 9f);
		RB_Flank.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Flank.Location = new Point(261, 20);
		RB_Flank.Name = "RB_Flank";
		RB_Flank.Size = new Size(80, 21);
		RB_Flank.TabIndex = 0;
		RB_Flank.Text = "最大";
		RB_Full.BackColor = Color.Transparent;
		RB_Full.Cursor = Cursors.Hand;
		RB_Full.Font = new Font("Segoe UI", 9f);
		RB_Full.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Full.Location = new Point(201, 20);
		RB_Full.Name = "RB_Full";
		RB_Full.Size = new Size(70, 21);
		RB_Full.TabIndex = 4;
		RB_Full.Text = "全速";
		RB_Cruise.BackColor = Color.Transparent;
		RB_Cruise.Cursor = Cursors.Hand;
		RB_Cruise.Font = new Font("Segoe UI", 9f);
		RB_Cruise.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Cruise.Location = new Point(131, 20);
		RB_Cruise.Name = "RB_Cruise";
		RB_Cruise.Size = new Size(60, 21);
		RB_Cruise.TabIndex = 3;
		RB_Cruise.Text = "巡航";
		RB_Creep.BackColor = Color.Transparent;
		RB_Creep.Cursor = Cursors.Hand;
		RB_Creep.Font = new Font("Segoe UI", 9f);
		RB_Creep.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Creep.Location = new Point(70, 20);
		RB_Creep.Name = "RB_Creep";
		RB_Creep.Size = new Size(60, 21);
		RB_Creep.TabIndex = 2;
		RB_Creep.Text = "低速";
		RB_Stop.BackColor = Color.Transparent;
		RB_Stop.Cursor = Cursors.Hand;
		RB_Stop.Font = new Font("Segoe UI", 9f);
		RB_Stop.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Stop.Location = new Point(10, 20);
		RB_Stop.Name = "RB_Stop";
		RB_Stop.Size = new Size(59, 21);
		RB_Stop.TabIndex = 1;
		RB_Stop.Text = "静止";
		Label_Speed.AutoSize = true;
		Label_Speed.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Speed.Location = new Point(183, 40);
		Label_Speed.Name = "Label_Speed";
		Label_Speed.Size = new Size(27, 25);
		Label_Speed.TabIndex = 3;
		Label_Speed.Text = "节";
		Label_MinSpeed.AutoSize = true;
		Label_MinSpeed.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MinSpeed.Location = new Point(3, 102);
		Label_MinSpeed.Name = "Label_MinSpeed";
		Label_MinSpeed.RightToLeft = RightToLeft.No;
		Label_MinSpeed.Size = new Size(92, 25);
		Label_MinSpeed.TabIndex = 4;
		Label_MinSpeed.Text = "最小速度";
		Label_MinSpeed.TextAlign = ContentAlignment.MiddleRight;
		TrackBar_Throttle.AutoSize = false;
		TrackBar_Throttle.LargeChange = 10;
		TrackBar_Throttle.Location = new Point(55, 98);
		TrackBar_Throttle.Name = "TrackBar_Throttle";
		TrackBar_Throttle.Size = new Size(290, 31);
		TrackBar_Throttle.SmallChange = 5;
		TrackBar_Throttle.TabIndex = 0;
		TrackBar_Throttle.TickFrequency = 100;
		Label_MaxSpeed.AutoSize = true;
		Label_MaxSpeed.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MaxSpeed.Location = new Point(343, 102);
		Label_MaxSpeed.Name = "Label_MaxSpeed";
		Label_MaxSpeed.Size = new Size(95, 25);
		Label_MaxSpeed.TabIndex = 3;
		Label_MaxSpeed.Text = "最大速度";
		Label_MaxSpeed.TextAlign = ContentAlignment.MiddleLeft;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(5, 62);
		Label2.Name = "Label2";
		Label2.Size = new Size(131, 25);
		Label2.TabIndex = 4;
		Label2.Text = "期望速度：";
		Label_DesiredSpeed.AutoSize = true;
		Label_DesiredSpeed.ForeColor = Color.FromArgb(220, 220, 220);
		Label_DesiredSpeed.Location = new Point(116, 61);
		Label_DesiredSpeed.Name = "Label_DesiredSpeed";
		Label_DesiredSpeed.Size = new Size(122, 25);
		Label_DesiredSpeed.TabIndex = 5;
		Label_DesiredSpeed.Text = "期望速度";
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(5, 80);
		Label3.Name = "Label3";
		Label3.Size = new Size(129, 25);
		Label3.TabIndex = 6;
		Label3.Text = "当前速度：";
		Label_ActualSpeed.AutoSize = true;
		Label_ActualSpeed.ForeColor = Color.FromArgb(220, 220, 220);
		Label_ActualSpeed.Location = new Point(116, 80);
		Label_ActualSpeed.Name = "Label_ActualSpeed";
		Label_ActualSpeed.Size = new Size(120, 25);
		Label_ActualSpeed.TabIndex = 7;
		Label_ActualSpeed.Text = "当前速度";
		Label_Cavitation.AutoSize = true;
		Label_Cavitation.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Cavitation.Location = new Point(220, 61);
		Label_Cavitation.Name = "Label_Cavitation";
		Label_Cavitation.Size = new Size(137, 25);
		Label_Cavitation.TabIndex = 11;
		Label_Cavitation.Text = "空泡";
		GroupBox_Altitude.Controls.Add(Label_DesiredAlt);
		GroupBox_Altitude.Controls.Add(CB_TerrainFollowing);
		GroupBox_Altitude.Controls.Add(CB_UseLandCoverMasking);
		GroupBox_Altitude.Controls.Add(Label14);
		GroupBox_Altitude.Controls.Add(Label13);
		GroupBox_Altitude.Controls.Add(Label12);
		GroupBox_Altitude.Controls.Add(Label11);
		GroupBox_Altitude.Controls.Add(CloudLowTopPictureBox);
		GroupBox_Altitude.Controls.Add(CloudLowBottomPictureBox);
		GroupBox_Altitude.Controls.Add(CloudHighBottomPictureBox);
		GroupBox_Altitude.Controls.Add(Label7);
		GroupBox_Altitude.Controls.Add(Label10);
		GroupBox_Altitude.Controls.Add(Label9);
		GroupBox_Altitude.Controls.Add(Label8);
		GroupBox_Altitude.Controls.Add(GroundLevelPictureBox);
		GroupBox_Altitude.Controls.Add(CloudHighTopPictureBox);
		GroupBox_Altitude.Controls.Add(SeaFloorPictureBox);
		GroupBox_Altitude.Controls.Add(LayerBottomPictureBox);
		GroupBox_Altitude.Controls.Add(LayerTopPictureBox);
		GroupBox_Altitude.Controls.Add(Label_MaxAlt);
		GroupBox_Altitude.Controls.Add(Label_MinAlt);
		GroupBox_Altitude.Controls.Add(FlowLayoutPanel_Presets);
		GroupBox_Altitude.Controls.Add(Label_Altitude);
		GroupBox_Altitude.Controls.Add(TextBox_EnterAltitude);
		GroupBox_Altitude.Controls.Add(CB_AltOverride);
		GroupBox_Altitude.Controls.Add(Label6);
		GroupBox_Altitude.Controls.Add(TrackBar_Altitude);
		GroupBox_Altitude.Controls.Add(Label_CurrentAlt);
		GroupBox_Altitude.Controls.Add(Label5);
		GroupBox_Altitude.Controls.Add(ShapeContainer1);
		GroupBox_Altitude.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_Altitude.Location = new Point(3, 360);
		GroupBox_Altitude.Name = "GroupBox_Altitude";
		GroupBox_Altitude.Size = new Size(409, 303);
		GroupBox_Altitude.TabIndex = 17;
		GroupBox_Altitude.TabStop = false;
		GroupBox_Altitude.Text = "高度 / 深度";
		Label_DesiredAlt.AutoSize = true;
		Label_DesiredAlt.ForeColor = Color.FromArgb(220, 220, 220);
		Label_DesiredAlt.Location = new Point(109, 43);
		Label_DesiredAlt.Name = "Label_DesiredAlt";
		Label_DesiredAlt.Size = new Size(94, 25);
		Label_DesiredAlt.TabIndex = 14;
		Label_DesiredAlt.Text = "期望高度";
		CB_TerrainFollowing.Location = new Point(9, 276);
		CB_TerrainFollowing.Name = "CB_TerrainFollowing";
		CB_TerrainFollowing.Size = new Size(261, 20);
		CB_TerrainFollowing.TabIndex = 44;
		CB_TerrainFollowing.Text = "地形跟随 - 地面以上（AGL）";
		CB_UseLandCoverMasking.Location = new Point(275, 276);
		CB_UseLandCoverMasking.Name = "CB_UseLandCoverMasking";
		CB_UseLandCoverMasking.Size = new Size(133, 20);
		CB_UseLandCoverMasking.TabIndex = 45;
		CB_UseLandCoverMasking.Text = "地貌影响";
		Label14.AutoSize = true;
		Label14.ForeColor = Color.FromArgb(220, 220, 220);
		Label14.Location = new Point(311, 61);
		Label14.Name = "Label14";
		Label14.Size = new Size(73, 25);
		Label14.TabIndex = 42;
		Label14.Text = "Label14";
		Label13.AutoSize = true;
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(311, 124);
		Label13.Name = "Label13";
		Label13.Size = new Size(73, 25);
		Label13.TabIndex = 41;
		Label13.Text = "Label13";
		Label12.AutoSize = true;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(311, 216);
		Label12.Name = "Label12";
		Label12.Size = new Size(73, 25);
		Label12.TabIndex = 40;
		Label12.Text = "Label12";
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(311, 194);
		Label11.Name = "Label11";
		Label11.Size = new Size(73, 25);
		Label11.TabIndex = 39;
		Label11.Text = "Label11";
		CloudLowTopPictureBox.Image = Resources.CloudTop;
		CloudLowTopPictureBox.Location = new Point(256, 121);
		CloudLowTopPictureBox.Name = "CloudLowTopPictureBox";
		CloudLowTopPictureBox.Size = new Size(28, 12);
		CloudLowTopPictureBox.TabIndex = 38;
		CloudLowTopPictureBox.TabStop = false;
		CloudLowBottomPictureBox.Image = Resources.CloudTop;
		CloudLowBottomPictureBox.Location = new Point(256, 226);
		CloudLowBottomPictureBox.Name = "CloudLowBottomPictureBox";
		CloudLowBottomPictureBox.Size = new Size(28, 12);
		CloudLowBottomPictureBox.TabIndex = 37;
		CloudLowBottomPictureBox.TabStop = false;
		CloudHighBottomPictureBox.Image = Resources.CloudTop;
		CloudHighBottomPictureBox.Location = new Point(256, 208);
		CloudHighBottomPictureBox.Name = "CloudHighBottomPictureBox";
		CloudHighBottomPictureBox.Size = new Size(28, 12);
		CloudHighBottomPictureBox.TabIndex = 36;
		CloudHighBottomPictureBox.TabStop = false;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(311, 81);
		Label7.Name = "Label7";
		Label7.Size = new Size(63, 25);
		Label7.TabIndex = 32;
		Label7.Text = "Label7";
		Label7.TextAlign = ContentAlignment.MiddleLeft;
		Label10.AutoSize = true;
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(311, 168);
		Label10.Name = "Label10";
		Label10.Size = new Size(73, 25);
		Label10.TabIndex = 35;
		Label10.Text = "Label10";
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(311, 146);
		Label9.Name = "Label9";
		Label9.Size = new Size(63, 25);
		Label9.TabIndex = 34;
		Label9.Text = "Label9";
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(311, 104);
		Label8.Name = "Label8";
		Label8.Size = new Size(63, 25);
		Label8.TabIndex = 33;
		Label8.Text = "Label8";
		GroundLevelPictureBox.Image = Resources.GroudLevel;
		GroundLevelPictureBox.Location = new Point(256, 168);
		GroundLevelPictureBox.Name = "GroundLevelPictureBox";
		GroundLevelPictureBox.Size = new Size(28, 12);
		GroundLevelPictureBox.TabIndex = 30;
		GroundLevelPictureBox.TabStop = false;
		CloudHighTopPictureBox.Image = Resources.CloudTop;
		CloudHighTopPictureBox.Location = new Point(256, 190);
		CloudHighTopPictureBox.Name = "CloudHighTopPictureBox";
		CloudHighTopPictureBox.Size = new Size(28, 12);
		CloudHighTopPictureBox.TabIndex = 28;
		CloudHighTopPictureBox.TabStop = false;
		SeaFloorPictureBox.Image = Resources.SeaFloor;
		SeaFloorPictureBox.Location = new Point(256, 146);
		SeaFloorPictureBox.Name = "SeaFloorPictureBox";
		SeaFloorPictureBox.Size = new Size(28, 12);
		SeaFloorPictureBox.TabIndex = 27;
		SeaFloorPictureBox.TabStop = false;
		LayerBottomPictureBox.Image = Resources.LayerBottom;
		LayerBottomPictureBox.Location = new Point(256, 103);
		LayerBottomPictureBox.Name = "LayerBottomPictureBox";
		LayerBottomPictureBox.Size = new Size(28, 12);
		LayerBottomPictureBox.TabIndex = 26;
		LayerBottomPictureBox.TabStop = false;
		LayerTopPictureBox.Image = Resources.LayerTop;
		LayerTopPictureBox.Location = new Point(256, 80);
		LayerTopPictureBox.Name = "LayerTopPictureBox";
		LayerTopPictureBox.Size = new Size(28, 12);
		LayerTopPictureBox.TabIndex = 25;
		LayerTopPictureBox.TabStop = false;
		Label_MaxAlt.AutoSize = true;
		Label_MaxAlt.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MaxAlt.Location = new Point(317, 16);
		Label_MaxAlt.Name = "Label_MaxAlt";
		Label_MaxAlt.RightToLeft = RightToLeft.No;
		Label_MaxAlt.Size = new Size(67, 25);
		Label_MaxAlt.TabIndex = 12;
		Label_MaxAlt.Text = "最高高度";
		Label_MaxAlt.TextAlign = ContentAlignment.MiddleRight;
		Label_MinAlt.AutoSize = true;
		Label_MinAlt.ForeColor = Color.FromArgb(220, 220, 220);
		Label_MinAlt.Location = new Point(317, 247);
		Label_MinAlt.Name = "Label_MinAlt";
		Label_MinAlt.RightToLeft = RightToLeft.No;
		Label_MinAlt.Size = new Size(64, 25);
		Label_MinAlt.TabIndex = 13;
		Label_MinAlt.Text = "最低高度";
		Label_MinAlt.TextAlign = ContentAlignment.MiddleRight;
		FlowLayoutPanel_Presets.Controls.Add(GroupBox_AltitudePresets);
		FlowLayoutPanel_Presets.Controls.Add(GroupBox_SubDepthPreset);
		FlowLayoutPanel_Presets.Location = new Point(8, 77);
		FlowLayoutPanel_Presets.Name = "FlowLayoutPanel_Presets";
		FlowLayoutPanel_Presets.Size = new Size(214, 196);
		FlowLayoutPanel_Presets.TabIndex = 24;
		GroupBox_AltitudePresets.Controls.Add(RB_NoAltitudePreset);
		GroupBox_AltitudePresets.Controls.Add(RB_MediumAltitude12000);
		GroupBox_AltitudePresets.Controls.Add(RB_LowAltitude2000);
		GroupBox_AltitudePresets.Controls.Add(RB_MinAltitude);
		GroupBox_AltitudePresets.Controls.Add(RB_LowAltitude1000);
		GroupBox_AltitudePresets.Controls.Add(RB_HighAltitude25000);
		GroupBox_AltitudePresets.Controls.Add(RB_HighAltitude36000);
		GroupBox_AltitudePresets.Controls.Add(RB_MaxAltitude);
		GroupBox_AltitudePresets.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_AltitudePresets.Location = new Point(3, 3);
		GroupBox_AltitudePresets.Name = "GroupBox_AltitudePresets";
		GroupBox_AltitudePresets.Size = new Size(210, 193);
		GroupBox_AltitudePresets.TabIndex = 21;
		GroupBox_AltitudePresets.TabStop = false;
		GroupBox_AltitudePresets.Text = "高度预设";
		RB_NoAltitudePreset.BackColor = Color.Transparent;
		RB_NoAltitudePreset.Cursor = Cursors.Hand;
		RB_NoAltitudePreset.Font = new Font("Segoe UI", 9f);
		RB_NoAltitudePreset.ForeColor = Color.FromArgb(209, 209, 209);
		RB_NoAltitudePreset.Location = new Point(6, 169);
		RB_NoAltitudePreset.Name = "RB_NoAltitudePreset";
		RB_NoAltitudePreset.Size = new Size(200, 21);
		RB_NoAltitudePreset.TabIndex = 7;
		RB_NoAltitudePreset.Text = "无";
		RB_MediumAltitude12000.BackColor = Color.Transparent;
		RB_MediumAltitude12000.Cursor = Cursors.Hand;
		RB_MediumAltitude12000.Font = new Font("Segoe UI", 9f);
		RB_MediumAltitude12000.ForeColor = Color.FromArgb(209, 209, 209);
		RB_MediumAltitude12000.Location = new Point(6, 83);
		RB_MediumAltitude12000.Name = "RB_MediumAltitude12000";
		RB_MediumAltitude12000.Size = new Size(200, 21);
		RB_MediumAltitude12000.TabIndex = 6;
		RB_MediumAltitude12000.Text = "中等海拔（12000英尺）";
		RB_LowAltitude2000.BackColor = Color.Transparent;
		RB_LowAltitude2000.Cursor = Cursors.Hand;
		RB_LowAltitude2000.Font = new Font("Segoe UI", 9f);
		RB_LowAltitude2000.ForeColor = Color.FromArgb(209, 209, 209);
		RB_LowAltitude2000.Location = new Point(6, 105);
		RB_LowAltitude2000.Name = "RB_LowAltitude2000";
		RB_LowAltitude2000.Size = new Size(200, 21);
		RB_LowAltitude2000.TabIndex = 5;
		RB_LowAltitude2000.Text = "低海拔（2000英尺）";
		RB_MinAltitude.BackColor = Color.Transparent;
		RB_MinAltitude.Cursor = Cursors.Hand;
		RB_MinAltitude.Font = new Font("Segoe UI", 9f);
		RB_MinAltitude.ForeColor = Color.FromArgb(209, 209, 209);
		RB_MinAltitude.Location = new Point(6, 149);
		RB_MinAltitude.Name = "RB_MinAltitude";
		RB_MinAltitude.Size = new Size(200, 21);
		RB_MinAltitude.TabIndex = 4;
		RB_MinAltitude.Text = "最小高度";
		RB_LowAltitude1000.BackColor = Color.Transparent;
		RB_LowAltitude1000.Cursor = Cursors.Hand;
		RB_LowAltitude1000.Font = new Font("Segoe UI", 9f);
		RB_LowAltitude1000.ForeColor = Color.FromArgb(209, 209, 209);
		RB_LowAltitude1000.Location = new Point(6, 127);
		RB_LowAltitude1000.Name = "RB_LowAltitude1000";
		RB_LowAltitude1000.Size = new Size(200, 21);
		RB_LowAltitude1000.TabIndex = 3;
		RB_LowAltitude1000.Text = "低海拔（1000英尺）";
		RB_HighAltitude25000.BackColor = Color.Transparent;
		RB_HighAltitude25000.Cursor = Cursors.Hand;
		RB_HighAltitude25000.Font = new Font("Segoe UI", 9f);
		RB_HighAltitude25000.ForeColor = Color.FromArgb(209, 209, 209);
		RB_HighAltitude25000.Location = new Point(6, 61);
		RB_HighAltitude25000.Name = "RB_HighAltitude25000";
		RB_HighAltitude25000.Size = new Size(200, 21);
		RB_HighAltitude25000.TabIndex = 2;
		RB_HighAltitude25000.Text = "高海拔（25000英尺）";
		RB_HighAltitude36000.BackColor = Color.Transparent;
		RB_HighAltitude36000.Cursor = Cursors.Hand;
		RB_HighAltitude36000.Font = new Font("Segoe UI", 9f);
		RB_HighAltitude36000.ForeColor = Color.FromArgb(209, 209, 209);
		RB_HighAltitude36000.Location = new Point(6, 39);
		RB_HighAltitude36000.Name = "RB_HighAltitude36000";
		RB_HighAltitude36000.Size = new Size(200, 21);
		RB_HighAltitude36000.TabIndex = 1;
		RB_HighAltitude36000.Text = "高海拔（36000英尺）";
		RB_MaxAltitude.BackColor = Color.Transparent;
		RB_MaxAltitude.Cursor = Cursors.Hand;
		RB_MaxAltitude.Font = new Font("Segoe UI", 9f);
		RB_MaxAltitude.ForeColor = Color.FromArgb(209, 209, 209);
		RB_MaxAltitude.Location = new Point(6, 17);
		RB_MaxAltitude.Name = "RB_MaxAltitude";
		RB_MaxAltitude.Size = new Size(200, 21);
		RB_MaxAltitude.TabIndex = 0;
		RB_MaxAltitude.Text = "最高海拔高度";
		GroupBox_SubDepthPreset.Controls.Add(RB_NoDepthPreset);
		GroupBox_SubDepthPreset.Controls.Add(RB_Surface);
		GroupBox_SubDepthPreset.Controls.Add(RB_Shallow);
		GroupBox_SubDepthPreset.Controls.Add(RB_MaxDepth);
		GroupBox_SubDepthPreset.Controls.Add(RB_UnderLayer);
		GroupBox_SubDepthPreset.Controls.Add(RB_OverLayer);
		GroupBox_SubDepthPreset.Controls.Add(RB_Periscope);
		GroupBox_SubDepthPreset.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_SubDepthPreset.Location = new Point(3, 202);
		GroupBox_SubDepthPreset.Name = "GroupBox_SubDepthPreset";
		GroupBox_SubDepthPreset.Size = new Size(210, 193);
		GroupBox_SubDepthPreset.TabIndex = 17;
		GroupBox_SubDepthPreset.TabStop = false;
		GroupBox_SubDepthPreset.Text = "深度预设";
		RB_NoDepthPreset.BackColor = Color.Transparent;
		RB_NoDepthPreset.Cursor = Cursors.Hand;
		RB_NoDepthPreset.Font = new Font("Segoe UI", 9f);
		RB_NoDepthPreset.ForeColor = Color.FromArgb(209, 209, 209);
		RB_NoDepthPreset.Location = new Point(6, 151);
		RB_NoDepthPreset.Name = "RB_NoDepthPreset";
		RB_NoDepthPreset.Size = new Size(200, 21);
		RB_NoDepthPreset.TabIndex = 7;
		RB_NoDepthPreset.Text = "无";
		RB_Surface.BackColor = Color.Transparent;
		RB_Surface.Cursor = Cursors.Hand;
		RB_Surface.Font = new Font("Segoe UI", 9f);
		RB_Surface.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Surface.Location = new Point(6, 19);
		RB_Surface.Name = "RB_Surface";
		RB_Surface.Size = new Size(200, 21);
		RB_Surface.TabIndex = 18;
		RB_Surface.Text = "水面";
		RB_Shallow.BackColor = Color.Transparent;
		RB_Shallow.Cursor = Cursors.Hand;
		RB_Shallow.Font = new Font("Segoe UI", 9f);
		RB_Shallow.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Shallow.Location = new Point(6, 63);
		RB_Shallow.Name = "RB_Shallow";
		RB_Shallow.Size = new Size(200, 21);
		RB_Shallow.TabIndex = 4;
		RB_Shallow.Text = "浅海深度";
		RB_MaxDepth.BackColor = Color.Transparent;
		RB_MaxDepth.Cursor = Cursors.Hand;
		RB_MaxDepth.Font = new Font("Segoe UI", 9f);
		RB_MaxDepth.ForeColor = Color.FromArgb(209, 209, 209);
		RB_MaxDepth.Location = new Point(6, 129);
		RB_MaxDepth.Name = "RB_MaxDepth";
		RB_MaxDepth.Size = new Size(200, 21);
		RB_MaxDepth.TabIndex = 3;
		RB_MaxDepth.Text = "极限潜深";
		RB_UnderLayer.BackColor = Color.Transparent;
		RB_UnderLayer.Cursor = Cursors.Hand;
		RB_UnderLayer.Font = new Font("Segoe UI", 9f);
		RB_UnderLayer.ForeColor = Color.FromArgb(209, 209, 209);
		RB_UnderLayer.Location = new Point(6, 107);
		RB_UnderLayer.Name = "RB_UnderLayer";
		RB_UnderLayer.Size = new Size(200, 21);
		RB_UnderLayer.TabIndex = 2;
		RB_UnderLayer.Text = "温跃层之下";
		RB_OverLayer.BackColor = Color.Transparent;
		RB_OverLayer.Cursor = Cursors.Hand;
		RB_OverLayer.Font = new Font("Segoe UI", 9f);
		RB_OverLayer.ForeColor = Color.FromArgb(209, 209, 209);
		RB_OverLayer.Location = new Point(6, 85);
		RB_OverLayer.Name = "RB_OverLayer";
		RB_OverLayer.Size = new Size(200, 21);
		RB_OverLayer.TabIndex = 1;
		RB_OverLayer.Text = "温跃层之上";
		RB_Periscope.BackColor = Color.Transparent;
		RB_Periscope.Cursor = Cursors.Hand;
		RB_Periscope.Font = new Font("Segoe UI", 9f);
		RB_Periscope.ForeColor = Color.FromArgb(209, 209, 209);
		RB_Periscope.Location = new Point(6, 41);
		RB_Periscope.Name = "RB_Periscope";
		RB_Periscope.Size = new Size(200, 21);
		RB_Periscope.TabIndex = 0;
		RB_Periscope.Text = "潜望镜深度";
		Label_Altitude.AutoSize = true;
		Label_Altitude.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Altitude.Location = new Point(188, 21);
		Label_Altitude.Name = "Label_Altitude";
		Label_Altitude.Size = new Size(122, 25);
		Label_Altitude.TabIndex = 23;
		Label_Altitude.Text = "Label_Altitude";
		TextBox_EnterAltitude.AutoCompleteCustomSource = null;
		TextBox_EnterAltitude.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_EnterAltitude.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_EnterAltitude.BackColor = Color.Transparent;
		TextBox_EnterAltitude.Font = new Font("Segoe UI", 8f);
		TextBox_EnterAltitude.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_EnterAltitude.Image = null;
		TextBox_EnterAltitude.Lines = null;
		TextBox_EnterAltitude.Location = new Point(119, 17);
		TextBox_EnterAltitude.MaxLength = 32767;
		TextBox_EnterAltitude.Multiline = false;
		TextBox_EnterAltitude.Name = "TextBox_EnterAltitude";
		TextBox_EnterAltitude.ReadOnly = false;
		TextBox_EnterAltitude.ScrollBars = ScrollBars.None;
		TextBox_EnterAltitude.SelectionStart = 0;
		TextBox_EnterAltitude.Size = new Size(60, 20);
		TextBox_EnterAltitude.TabIndex = 20;
		TextBox_EnterAltitude.TextAlign = HorizontalAlignment.Left;
		TextBox_EnterAltitude.UseSystemPasswordChar = false;
		TextBox_EnterAltitude.WatermarkText = "";
		CB_AltOverride.AutoSize = true;
		CB_AltOverride.Location = new Point(9, 20);
		CB_AltOverride.Name = "CB_AltOverride";
		CB_AltOverride.Size = new Size(169, 29);
		CB_AltOverride.TabIndex = 16;
		CB_AltOverride.Text = "手动覆盖";
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(5, 43);
		Label6.Name = "Label6";
		Label6.Size = new Size(143, 25);
		Label6.TabIndex = 10;
		Label6.Text = "期望高度：";
		TrackBar_Altitude.LargeChange = 10;
		TrackBar_Altitude.Location = new Point(287, 9);
		TrackBar_Altitude.Name = "TrackBar_Altitude";
		TrackBar_Altitude.Orientation = Orientation.Vertical;
		TrackBar_Altitude.RightToLeft = RightToLeft.No;
		TrackBar_Altitude.Size = new Size(69, 272);
		TrackBar_Altitude.SmallChange = 5;
		TrackBar_Altitude.TabIndex = 9;
		TrackBar_Altitude.TickFrequency = 305;
		Label_CurrentAlt.AutoSize = true;
		Label_CurrentAlt.ForeColor = Color.FromArgb(220, 220, 220);
		Label_CurrentAlt.Location = new Point(109, 61);
		Label_CurrentAlt.Name = "Label_CurrentAlt";
		Label_CurrentAlt.Size = new Size(92, 25);
		Label_CurrentAlt.TabIndex = 15;
		Label_CurrentAlt.Text = "当前高度";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(5, 61);
		Label5.Name = "Label5";
		Label5.Size = new Size(141, 25);
		Label5.TabIndex = 11;
		Label5.Text = "当前高度：";
		((Control)ShapeContainer1).Location = new Point(3, 27);
		((Control)ShapeContainer1).Margin = new Padding(0);
		((Control)ShapeContainer1).Name = "ShapeContainer1";
		ShapeContainer1.Shapes.AddRange(new Shape[2] { LineShape2, LineShape1 });
		((Control)ShapeContainer1).Size = new Size(403, 273);
		((Control)ShapeContainer1).TabIndex = 43;
		((Control)ShapeContainer1).TabStop = false;
		LineShape2.BorderColor = Color.FromArgb(64, 64, 64);
		LineShape2.BorderWidth = 3;
		LineShape2.Name = "LineShape2";
		LineShape2.X1 = 256;
		LineShape2.X2 = 256;
		LineShape2.Y1 = 33;
		LineShape2.Y2 = 179;
		LineShape1.BorderColor = Color.FromArgb(64, 64, 64);
		LineShape1.BorderWidth = 3;
		LineShape1.Name = "LineShape1";
		LineShape1.X1 = 256;
		LineShape1.X2 = 256;
		LineShape1.Y1 = 70;
		LineShape1.Y2 = 216;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(419, 670);
		base.Controls.Add(FlowLayoutPanel2);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(435, 150);
		base.Name = "SpeedAlt";
		base.ShowIcon = false;
		base.SizeGripStyle = SizeGripStyle.Show;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "油门 & 高度：";
		FlowLayoutPanel2.ResumeLayout(performLayout: false);
		FlowLayoutPanel_SettingsFor.ResumeLayout(performLayout: false);
		FlowLayoutPanel_SettingsFor.PerformLayout();
		GroupBox_Waypoint.ResumeLayout(performLayout: false);
		GroupBox_Waypoint.PerformLayout();
		GroupBox_Speed.ResumeLayout(performLayout: false);
		GroupBox_Speed.PerformLayout();
		GroupBox_SpeedPresets.ResumeLayout(performLayout: false);
		((ISupportInitialize)TrackBar_Throttle).EndInit();
		GroupBox_Altitude.ResumeLayout(performLayout: false);
		GroupBox_Altitude.PerformLayout();
		((ISupportInitialize)CloudLowTopPictureBox).EndInit();
		((ISupportInitialize)CloudLowBottomPictureBox).EndInit();
		((ISupportInitialize)CloudHighBottomPictureBox).EndInit();
		((ISupportInitialize)GroundLevelPictureBox).EndInit();
		((ISupportInitialize)CloudHighTopPictureBox).EndInit();
		((ISupportInitialize)SeaFloorPictureBox).EndInit();
		((ISupportInitialize)LayerBottomPictureBox).EndInit();
		((ISupportInitialize)LayerTopPictureBox).EndInit();
		FlowLayoutPanel_Presets.ResumeLayout(performLayout: false);
		GroupBox_AltitudePresets.ResumeLayout(performLayout: false);
		GroupBox_SubDepthPreset.ResumeLayout(performLayout: false);
		((ISupportInitialize)TrackBar_Altitude).EndInit();
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		if (keyData == Keys.Return && (base.ActiveControl.Parent == TextBox_EnterAltitude || base.ActiveControl.Parent == TextBox_EnterSpeed))
		{
			SendKeys.Send("{TAB}");
		}
		Keys[] array = procRecord;
		Keys[] array2 = array;
		foreach (Keys keys in array2)
		{
			if (keyData == keys)
			{
				if (base.ActiveControl == null)
				{
					Activate();
				}
				else
				{
					Close();
				}
				return true;
			}
		}
		if (keyData == getterRecord.First())
		{
			Button_Next_Click(null, null);
			return true;
		}
		if (keyData == m_ProducerRecord.First())
		{
			Button_Previous_Click(null, null);
			return true;
		}
		return false;
	}

	private void ResolveInterruptibleSchema(object sender, EventArgs e)
	{
		LoadForm();
		PrepareInterruptibleUtils().Interval = 250;
		PrepareInterruptibleUtils().Start();
	}

	public void LoadForm()
	{
		try
		{
			RefreshForm(bool_0: true);
			managerRecord = false;
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				Label_Altitude.Text = "英尺";
			}
			else
			{
				Label_Altitude.Text = "米";
				RB_HighAltitude36000.Text = "高海拔（10973米）";
				RB_HighAltitude25000.Text = "高海拔（7620米）";
				RB_MediumAltitude12000.Text = "中等海拔（3658米）";
				RB_LowAltitude2000.Text = "低海拔（610米）";
				RB_LowAltitude1000.Text = "低海拔（305米）";
			}
			if (Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
				{
					RB_Stop.Text = "盘旋";
					RB_Creep.Text = "低速";
					RB_Full.Text = "军用";
					RB_Flank.Text = "加力";
				}
			}
			else if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
			{
				RB_Stop.Text = "盘旋";
				RB_Creep.Text = "低速";
				RB_Full.Text = "军用";
				RB_Flank.Text = "加力";
			}
			else
			{
				RB_Stop.Text = "静止";
				RB_Creep.Text = "低速";
				RB_Full.Text = "全速";
				RB_Flank.Text = "最大";
			}
			Label_Altitude.Visible = false;
			TextBox_EnterAltitude.Visible = false;
			CB_AltOverride.Visible = false;
			Label5.Visible = false;
			Label6.Visible = false;
			Label_DesiredAlt.Visible = false;
			Label_CurrentAlt.Visible = false;
			Label3.Visible = true;
			Label_ActualSpeed.Visible = true;
			RB_HighAltitude36000.Enabled = true;
			RB_HighAltitude25000.Enabled = true;
			RB_MediumAltitude12000.Enabled = true;
			RB_LowAltitude2000.Enabled = true;
			RB_LowAltitude1000.Enabled = true;
			RB_Periscope.Enabled = true;
			RB_Shallow.Enabled = true;
			RB_OverLayer.Enabled = true;
			RB_UnderLayer.Enabled = true;
			RB_Stop.Enabled = true;
			CB_TerrainFollowing.Enabled = true;
			CB_WaypointType.Enabled = false;
			TextBox_WaypointDescription.Enabled = false;
			float num = 0f;
			float num2 = 0f;
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				num = SpeedAlt_SelectedUnit.Kinematics.GetMaximumAltitude();
				num2 = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
			}
			if (TrackBar_Altitude.Maximum != (int)Math.Round(num))
			{
				TrackBar_Altitude.Maximum = (int)Math.Round(num);
			}
			TrackBar_Altitude.Minimum = (int)Math.Round(num2);
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					if (num * 3.28084f < 36000f)
					{
						RB_HighAltitude36000.Enabled = false;
					}
					if (num * 3.28084f < 25000f)
					{
						RB_HighAltitude25000.Enabled = false;
					}
					if (num * 3.28084f < 12000f)
					{
						RB_MediumAltitude12000.Enabled = false;
					}
					if (num * 3.28084f < 2000f)
					{
						RB_LowAltitude2000.Enabled = false;
					}
					if (num * 3.28084f < 1000f)
					{
						RB_LowAltitude1000.Enabled = false;
					}
				}
				else if (SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup))
				{
					if (num2 > -20f)
					{
						RB_Periscope.Enabled = false;
					}
					if (num2 > -40f)
					{
						RB_Shallow.Enabled = false;
					}
					if ((num2 > Submarine_AI.OverLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsSubmarine) | (num2 > Group_AI.OverLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsGroup))
					{
						RB_OverLayer.Enabled = false;
					}
					if ((num2 > Submarine_AI.UnderLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsSubmarine) | (num2 > Group_AI.UnderLayerDepth(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsGroup))
					{
						RB_UnderLayer.Enabled = false;
					}
				}
			}
			if (Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (!Information.IsNothing(SpeedAlt_SelectedUnit))
				{
					if (SpeedAlt_SelectedUnit.IsSubmarine)
					{
						GroupBox_SubDepthPreset.Visible = true;
						GroupBox_SubDepthPreset.Enabled = true;
					}
					else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)
					{
						GroupBox_SubDepthPreset.Visible = true;
						GroupBox_SubDepthPreset.Enabled = true;
					}
					else
					{
						GroupBox_SubDepthPreset.Visible = false;
						GroupBox_SubDepthPreset.Enabled = false;
					}
					if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						GroupBox_AltitudePresets.Visible = true;
						GroupBox_AltitudePresets.Enabled = true;
						CB_TerrainFollowing.Enabled = true;
					}
					else
					{
						GroupBox_AltitudePresets.Visible = false;
						GroupBox_AltitudePresets.Enabled = false;
						CB_TerrainFollowing.Enabled = false;
					}
					if (SpeedAlt_SelectedUnit.IsFacility)
					{
						TrackBar_Throttle.Minimum = 0;
						int maximumSpeed = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed();
						if (TrackBar_Throttle.Maximum != maximumSpeed)
						{
							TrackBar_Throttle.Maximum = maximumSpeed;
						}
						if (SpeedAlt_SelectedUnit.DesiredSpeed <= (float)TrackBar_Throttle.Maximum)
						{
							TrackBar_Throttle.Value = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredSpeed);
						}
						else
						{
							TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
						}
					}
					else if (SpeedAlt_SelectedUnit.SupportsAltitude_Control)
					{
						Label_Altitude.Visible = true;
						TextBox_EnterAltitude.Visible = true;
						Label_DesiredAlt.Visible = true;
						Label_CurrentAlt.Visible = true;
						CB_AltOverride.Visible = true;
						Label5.Visible = true;
						Label6.Visible = true;
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							Label_MaxAlt.Text = Conversions.ToString((int)Math.Round(num * 3.28084f)) + " 英尺";
							Label_MinAlt.Text = Conversions.ToString((int)Math.Round(num2 * 3.28084f)) + " 英尺";
						}
						else
						{
							Label_MaxAlt.Text = Conversions.ToString(num) + " 米";
							Label_MinAlt.Text = Conversions.ToString(num2) + " 米";
						}
					}
					RB_NoThrottlePreset.Visible = false;
					RB_NoDepthPreset.Visible = false;
					RB_NoAltitudePreset.Visible = false;
					if (SpeedAlt_SelectedUnit.IsWeapon && ((Weapon)SpeedAlt_SelectedUnit).Flags.TerrainFollowing)
					{
						CB_TerrainFollowing.Enabled = true;
					}
				}
			}
			else
			{
				RB_Surface.Checked = false;
				RB_Periscope.Checked = false;
				RB_Shallow.Checked = false;
				RB_OverLayer.Checked = false;
				RB_UnderLayer.Checked = false;
				RB_MaxDepth.Checked = false;
				RB_MaxAltitude.Checked = false;
				RB_HighAltitude36000.Checked = false;
				RB_HighAltitude25000.Checked = false;
				RB_MediumAltitude12000.Checked = false;
				RB_LowAltitude2000.Checked = false;
				RB_LowAltitude1000.Checked = false;
				RB_MinAltitude.Checked = false;
				RB_Stop.Checked = false;
				RB_Creep.Checked = false;
				RB_Cruise.Checked = false;
				RB_Full.Checked = false;
				RB_Flank.Checked = false;
				RB_NoThrottlePreset.Checked = false;
				RB_NoDepthPreset.Checked = false;
				RB_NoAltitudePreset.Checked = false;
				if (!Information.IsNothing(SpeedAlt_SelectedUnit))
				{
					if (SpeedAlt_SelectedUnit.IsFacility)
					{
						Label_Altitude.Visible = false;
						TextBox_EnterAltitude.Visible = false;
					}
					else if (SpeedAlt_SelectedUnit.SupportsAltitude_Control)
					{
						Label_Altitude.Visible = true;
						TextBox_EnterAltitude.Visible = true;
					}
					else
					{
						Label_Altitude.Visible = false;
						TextBox_EnterAltitude.Visible = false;
					}
				}
				TextBox_WaypointDescription.Enabled = true;
				Waypoint waypoint = null;
				waypoint = ((Information.IsNothing(Client.SelectedWaypoint) || !Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) ? SpeedAlt_FlightPlanWaypoint : Client.SelectedWaypoint);
				if (waypoint != null)
				{
					switch (waypoint.ThrottlePreset)
					{
					case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
						RB_Stop.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
						RB_Creep.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
						RB_Cruise.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
						RB_Full.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
						RB_Flank.Checked = true;
						break;
					}
					switch (waypoint.AltitudePreset)
					{
					case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
						RB_MinAltitude.Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
						RB_LowAltitude1000.Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
						RB_LowAltitude2000.Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_4:
						RB_MediumAltitude12000.Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_5:
						RB_HighAltitude25000.Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.const_6:
						RB_HighAltitude36000.Checked = true;
						break;
					case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
						RB_MaxAltitude.Checked = true;
						break;
					}
					switch (waypoint.DepthPreset)
					{
					case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
						RB_Periscope.Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
						RB_Shallow.Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
						RB_OverLayer.Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
						RB_UnderLayer.Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
						RB_MaxDepth.Checked = true;
						break;
					case ActiveUnit_AI.SubmarineDepthPreset.Surface:
						RB_Surface.Checked = true;
						break;
					}
				}
				if (Information.IsNothing(SpeedAlt_SelectedUnit))
				{
					if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
					{
						Label6.Visible = true;
						Label_DesiredAlt.Visible = true;
						Label_Altitude.Visible = true;
						TextBox_EnterAltitude.Visible = true;
						CB_AltOverride.Visible = true;
						Label6.Visible = true;
						Label3.Visible = false;
						Label_ActualSpeed.Visible = false;
					}
				}
				else if (SpeedAlt_SelectedUnit.SupportsAltitude_Control)
				{
					Label6.Visible = true;
					Label_DesiredAlt.Visible = true;
					Label_CurrentAlt.Visible = true;
					Label_Altitude.Visible = true;
					TextBox_EnterAltitude.Visible = true;
					CB_AltOverride.Visible = true;
					Label5.Visible = true;
					Label6.Visible = true;
				}
				if (Information.IsNothing(waypoint.DesiredSpeedOverride))
				{
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						RB_NoThrottlePreset.Visible = false;
					}
					else
					{
						RB_NoThrottlePreset.Visible = true;
					}
				}
				else
				{
					RB_NoThrottlePreset.Visible = false;
				}
				RB_NoDepthPreset.Visible = false;
				RB_NoAltitudePreset.Visible = false;
				if (Information.IsNothing(SpeedAlt_SelectedUnit))
				{
					if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
					{
						GroupBox_SubDepthPreset.Visible = false;
						GroupBox_SubDepthPreset.Enabled = false;
					}
				}
				else if (!SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup))
				{
					GroupBox_SubDepthPreset.Visible = false;
					GroupBox_SubDepthPreset.Enabled = false;
				}
				else
				{
					GroupBox_SubDepthPreset.Visible = true;
					GroupBox_SubDepthPreset.Enabled = true;
				}
				if (Information.IsNothing(SpeedAlt_SelectedUnit))
				{
					if (SpeedAlt_FlightPlanWaypoint != null)
					{
						GroupBox_AltitudePresets.Visible = true;
						GroupBox_AltitudePresets.Enabled = true;
					}
				}
				else if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
				{
					GroupBox_AltitudePresets.Visible = true;
					GroupBox_AltitudePresets.Enabled = true;
					if (SpeedAlt_SelectedUnit.IsAircraft && !((Aircraft)SpeedAlt_SelectedUnit).GetCanHover(bool_1: false))
					{
						RB_Stop.Enabled = false;
					}
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						if (Information.IsNothing(((Group)SpeedAlt_SelectedUnit).GroupLead))
						{
							return;
						}
						if (!((Aircraft)((Group)SpeedAlt_SelectedUnit).GroupLead).GetCanHover(bool_1: false))
						{
							RB_Stop.Enabled = false;
						}
					}
					CB_TerrainFollowing.Enabled = true;
				}
				else
				{
					GroupBox_AltitudePresets.Visible = false;
					GroupBox_AltitudePresets.Enabled = false;
				}
				if (!Information.IsNothing(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsWeapon)
				{
					RB_Stop.Enabled = false;
					RB_Creep.Enabled = false;
					if (((Weapon)SpeedAlt_SelectedUnit).Flags.TerrainFollowing)
					{
						CB_TerrainFollowing.Enabled = true;
					}
				}
			}
			if (SpeedAlt_SelectedUnit != null && SpeedAlt_SelectedUnit.IsAircraft && !((Aircraft)SpeedAlt_SelectedUnit).GetCanHover(bool_1: false))
			{
				RB_Stop.Enabled = false;
			}
			if (!_StructException)
			{
				Client.SelectedUnitPreChange += HandleSelectedObjectChanged;
				Client.SelectedWaypointPreChange += HandleSelectedObjectChanged;
				_StructException = true;
			}
			managerRecord = true;
			LblWeatherWarning.Visible = false;
			if (SpeedAlt_SelectedUnit != null && SpeedAlt_SelectedUnit.IsShip)
			{
				Ship ship = (Ship)SpeedAlt_SelectedUnit;
				Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(ship.ParentScen, ship.GetLatitude(), ship.GetLongitude(), 0);
				if (ship.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.WeatherAffectsShipSpeed) && ship.Kinematics.GetMaximumSpeed() > Ship_Kinematics.GetMaximumSpeedForThisSeaState(ship, weatherAtThisTimeAndPlace.SeaState))
				{
					LblWeatherWarning.Visible = true;
					LblWeatherWarning.Text = "MAX Speed for Sea State " + weatherAtThisTimeAndPlace.SeaState + " : " + Conversions.ToString(Ship_Kinematics.GetMaximumSpeedForThisSeaState(ship, weatherAtThisTimeAndPlace.SeaState)) + " 节";
				}
			}
			ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.WPFControl_AltSpeed.Refresh(bool_0: true);
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

	public void HandleSelectedObjectChanged()
	{
		try
		{
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				IncludeInterruptibleUtils(bool_0: false);
				if (m_InfoRecord)
				{
					m_InfoRecord = false;
				}
				if (helperRecord)
				{
					helperRecord = false;
				}
			}
			else if (!Information.IsNothing(Client.SelectedWaypoint) && !Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				IncludeInterruptibleUtils(bool_0: false);
				if (m_InfoRecord)
				{
					m_InfoRecord = false;
				}
				if (helperRecord)
				{
					helperRecord = false;
				}
			}
			else
			{
				if (Information.IsNothing(SpeedAlt_SelectedUnit) || !SpeedAlt_SelectedUnit.IsActiveUnit)
				{
					return;
				}
				Side currentSide = Client.CurrentSide;
				ActiveUnit speedAlt_SelectedUnit = SpeedAlt_SelectedUnit;
				string string_ = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(currentSide, speedAlt_SelectedUnit, bool_1: false, ref string_, Client.CurrentMapProfile.String_0))
				{
					IncludeInterruptibleUtils(bool_0: false);
					if (m_InfoRecord)
					{
						m_InfoRecord = false;
					}
					if (helperRecord)
					{
						helperRecord = false;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200636", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			SpeedAlt_Flight = null;
			SpeedAlt_FlightPlanWaypoint = null;
			SpeedAlt_Mission = null;
			SpeedAlt_SelectedUnit = null;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshForm(bool bool_0 = false)
	{
		managerRecord = false;
		if (Client.SelectedWaypoint == null)
		{
			GroupBox_Waypoint.Visible = false;
			if (SpeedAlt_FlightPlanWaypoint != null)
			{
				SpeedAlt_FlightPlanWaypoint = null;
				SpeedAlt_Flight = null;
				SpeedAlt_Mission = null;
				base.Visible = false;
				Close();
			}
			if (Client.SelectedUnit == null)
			{
				Label_SettingsFor.Text = "没有";
				Button_Next.Enabled = false;
				Button_Previous.Enabled = false;
				return;
			}
			if (Client.SelectedUnit.IsGroup)
			{
				Label_SettingsFor.Text = "组";
			}
			else
			{
				Label_SettingsFor.Text = "单元";
			}
			Button_Next.Enabled = true;
			Button_Previous.Enabled = false;
			if (SpeedAlt_SelectedUnit == null && Client.SelectedUnit.IsActiveUnit)
			{
				SpeedAlt_SelectedUnit = (ActiveUnit)Client.SelectedUnit;
			}
		}
		else
		{
			GroupBox_Waypoint.Visible = true;
			if (Client.SelectedUnit != null && Client.SelectedUnit.IsActiveUnit)
			{
				if (SpeedAlt_FlightPlanWaypoint == null)
				{
					int num = Array.IndexOf(((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse, Client.SelectedWaypoint);
					Label_SettingsFor.Text = "航点 #" + Conversions.ToString(num + 1);
					if (num == ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse.Count() - 1)
					{
						Button_Next.Enabled = false;
					}
					else
					{
						Button_Next.Enabled = true;
					}
				}
				else if (SpeedAlt_Flight == null)
				{
					Label_SettingsFor.Text = "";
					Button_Next.Enabled = false;
				}
				else
				{
					Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
					int num11 = Array.IndexOf(SpeedAlt_Flight.FlightPlan, SpeedAlt_FlightPlanWaypoint);
					Label_WaypointName.Text = "航点：  机组 " + speedAlt_Flight.Callsign + " (" + speedAlt_Flight.ParentMissionOrPackageName + ")";
					Label_SettingsFor.Text = "航点 #" + Conversions.ToString(num11 + 1);
					if (num11 == SpeedAlt_Flight.FlightPlan.Count() - 1)
					{
						Button_Next.Enabled = false;
					}
					else
					{
						Button_Next.Enabled = true;
					}
				}
			}
			else
			{
				Label_SettingsFor.Text = "航点";
			}
			Button_Previous.Enabled = true;
		}
		try
		{
			if (Client.SelectedWaypoint == null)
			{
				if (Client.SelectedUnit == null)
				{
					CB_AvoidCavitation.Visible = false;
				}
				else
				{
					CB_AvoidCavitation.ThreeState = false;
					CB_AvoidCavitation.CheckState = CheckState.Checked;
					if (Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine)
					{
						CB_AvoidCavitation.Visible = true;
						CB_AvoidCavitation.Checked = ((ActiveUnit)Client.SelectedUnit).Navigator.AvoidCavitation;
					}
					else if (Client.SelectedUnit.IsGroup)
					{
						Group group = (Group)Client.SelectedUnit;
						if (group.Units.Count > 0 && (group.Units.Values.ElementAtOrDefault(0).IsShip | group.Units.Values.ElementAtOrDefault(0).IsSubmarine))
						{
							CB_AvoidCavitation.Visible = true;
							CB_AvoidCavitation.Checked = ((ActiveUnit)Client.SelectedUnit).Navigator.AvoidCavitation;
						}
						else
						{
							CB_AvoidCavitation.Visible = false;
						}
					}
					else
					{
						CB_AvoidCavitation.Visible = false;
					}
				}
			}
			else
			{
				CB_AvoidCavitation.ThreeState = true;
				if (Client.SelectedUnit != null && (Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine))
				{
					CB_AvoidCavitation.Visible = true;
					if (Client.SelectedWaypoint.AvoidCavitation.HasValue)
					{
						CB_AvoidCavitation.Checked = Client.SelectedWaypoint.AvoidCavitation.Value;
					}
					else
					{
						CB_AvoidCavitation.CheckState = CheckState.Indeterminate;
					}
				}
				else
				{
					CB_AvoidCavitation.Visible = false;
				}
			}
			if (Client.SelectedWaypoint == null)
			{
				if (Client.SelectedUnit == null)
				{
					CB_SprintDrift.Visible = false;
				}
				else
				{
					CB_SprintDrift.ThreeState = false;
					CB_SprintDrift.CheckState = CheckState.Checked;
					if (Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine)
					{
						CB_SprintDrift.Visible = true;
						CB_SprintDrift.Checked = ((ActiveUnit)Client.SelectedUnit).Navigator.SprintDrift;
					}
					else
					{
						CB_SprintDrift.Visible = false;
					}
				}
			}
			else
			{
				CB_SprintDrift.ThreeState = true;
				if (Client.SelectedUnit != null && (Client.SelectedUnit.IsShip | Client.SelectedUnit.IsSubmarine))
				{
					CB_SprintDrift.Visible = true;
					if (Client.SelectedWaypoint.SprintDrift.HasValue)
					{
						CB_SprintDrift.Checked = Client.SelectedWaypoint.SprintDrift.Value;
					}
					else
					{
						CB_SprintDrift.CheckState = CheckState.Indeterminate;
					}
				}
				else
				{
					CB_SprintDrift.Visible = false;
				}
			}
			if (((SpeedAlt_SelectedUnit == null) & (Client.SelectedWaypoint == null) & (SpeedAlt_FlightPlanWaypoint == null)) || (SpeedAlt_SelectedUnit != null && SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).GroupLead == null))
			{
				return;
			}
			if (Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (!SpeedAlt_SelectedUnit.IsShip && !SpeedAlt_SelectedUnit.IsSubmarine)
				{
					Label_Cavitation.Visible = false;
				}
				else
				{
					Label_Cavitation.Visible = true;
					int num12 = SpeedAlt_SelectedUnit.Kinematics.CavitationSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude());
					if (num12 == int.MaxValue)
					{
						Label_Cavitation.Font = new Font(Label_Cavitation.Font, FontStyle.Regular);
						Label_Cavitation.ForeColor = Color.LightGray;
						Label_Cavitation.Text = "不可能发生空泡";
					}
					else if (SpeedAlt_SelectedUnit.CurrentSpeed < (float)num12)
					{
						Label_Cavitation.Font = new Font(Label_Cavitation.Font, FontStyle.Regular);
						Label_Cavitation.ForeColor = Color.LightGray;
						Label_Cavitation.Text = "空泡发生在" + Conversions.ToString(num12) + " 节";
					}
					else
					{
						Label_Cavitation.Font = new Font(Label_Cavitation.Font, FontStyle.Bold);
						Label_Cavitation.ForeColor = Color.IndianRed;
						Label_Cavitation.Text = "空泡！ （" + Conversions.ToString(num12) + " 节)";
					}
				}
			}
			else
			{
				Label_Cavitation.Visible = false;
			}
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (Operators.CompareString(Client.SelectedWaypoint.Name, "", TextCompare: true) == 0)
				{
					Text = "油门和高度设置：航路点";
				}
				else
				{
					Text = "油门和高度设置：" + Client.SelectedWaypoint.Name;
				}
			}
			else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (!Information.IsNothing(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.IsActiveUnit)
				{
					Text = "油门和高度设置：" + SpeedAlt_SelectedUnit.Name;
				}
			}
			else
			{
				Text = "油门和高度设置：" + SpeedAlt_FlightPlanWaypoint.Name + "（类型：" + Waypoint.GetWaypointTypeString(SpeedAlt_FlightPlanWaypoint.Type) + ")";
			}
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				RB_Flank.Enabled = SpeedAlt_SelectedUnit.MaxPossibleThrottleSetting == ActiveUnit.Throttle.Flank;
				RB_Full.Enabled = (int)SpeedAlt_SelectedUnit.MaxPossibleThrottleSetting >= 3;
			}
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				Label_MaxAlt.Text = Conversions.ToString((int)Math.Round((float)TrackBar_Altitude.Maximum * 3.28084f)) + " 英尺";
				Label_MinAlt.Text = Conversions.ToString((int)Math.Round((float)TrackBar_Altitude.Minimum * 3.28084f)) + " 英尺";
			}
			else
			{
				Label_MaxAlt.Text = Conversions.ToString(TrackBar_Altitude.Maximum) + " 米";
				Label_MinAlt.Text = Conversions.ToString(TrackBar_Altitude.Minimum) + " 米";
			}
			if (Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (SpeedAlt_SelectedUnit.IsTorpedo && ((Torpedo)SpeedAlt_SelectedUnit).DataLinkParent != null)
				{
					if (!TrackBar_Altitude.Visible)
					{
						TrackBar_Altitude.Visible = true;
						Label_MaxAlt.Visible = true;
						Label_MinAlt.Visible = true;
					}
				}
				else
				{
					if (!TrackBar_Throttle.Visible)
					{
						TrackBar_Throttle.Visible = true;
						Label_MaxSpeed.Visible = true;
						Label_MinSpeed.Visible = true;
					}
					if (SpeedAlt_SelectedUnit.SupportsAltitude_Control)
					{
						if (!TrackBar_Altitude.Visible)
						{
							TrackBar_Altitude.Visible = true;
							Label_MaxAlt.Visible = true;
							Label_MinAlt.Visible = true;
						}
					}
					else if (TrackBar_Altitude.Visible)
					{
						TrackBar_Altitude.Visible = false;
						Label_MaxAlt.Visible = false;
						Label_MinAlt.Visible = false;
					}
				}
			}
			else
			{
				if (TrackBar_Throttle.Visible)
				{
					TrackBar_Throttle.Visible = false;
					Label_MaxSpeed.Visible = false;
					Label_MinSpeed.Visible = false;
				}
				if (TrackBar_Altitude.Visible)
				{
					TrackBar_Altitude.Visible = false;
					Label_MaxAlt.Visible = false;
					Label_MinAlt.Visible = false;
				}
			}
			double num13 = 0.0;
			double num14 = 0.0;
			float num15 = 0f;
			float num16 = 0f;
			float num17 = 0f;
			float num18 = 0f;
			float num2 = 0f;
			float num3 = 0f;
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				num2 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumAltitude();
				num3 = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
			}
			if (Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (SpeedAlt_SelectedUnit != null)
				{
					int num4 = Math.Max(SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), SpeedAlt_SelectedUnit.MaxPossibleThrottleSetting, bool_0: false), SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.DesiredAltitude));
					if (TrackBar_Throttle.Maximum != num4)
					{
						TrackBar_Throttle.Maximum = num4;
					}
					if (SpeedAlt_SelectedUnit.Navigator.SprintDrift)
					{
						Label2.Text = "期望平均速度：";
						GroupBox_SpeedPresets.Enabled = false;
					}
					else
					{
						Label2.Text = "期望速度：";
						GroupBox_SpeedPresets.Enabled = true;
					}
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						if (SpeedAlt_SelectedUnit.Navigator.SprintDrift)
						{
							Label_DesiredSpeed.Text = $"{SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value:0} 节";
							Label_ActualSpeed.Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0} 节";
						}
						else
						{
							Label_DesiredSpeed.Text = $"{SpeedAlt_SelectedUnit.DesiredSpeed:0} 节";
							Label_ActualSpeed.Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0} 节";
						}
					}
					else
					{
						if (SpeedAlt_SelectedUnit.Navigator.SprintDrift)
						{
							Label_DesiredSpeed.Text = $"{SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value:0} 节";
						}
						else
						{
							Label_DesiredSpeed.Text = $"{SpeedAlt_SelectedUnit.DesiredSpeed:0} 节";
						}
						Label_ActualSpeed.Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0.0}" + "节（油门：" + RunInterruptibleSchema() + ")";
					}
					if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						bool desiredAltitude_UseTerrainFollowing;
						float desiredAltitude_AGL;
						if (SpeedAlt_SelectedUnit.IsGroupWingman() && !Information.IsNothing(SpeedAlt_SelectedUnit.GetParentGroup().GroupLead) && !SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride)
						{
							desiredAltitude_UseTerrainFollowing = SpeedAlt_SelectedUnit.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit.GetParentGroup().GroupLead);
							desiredAltitude_AGL = SpeedAlt_SelectedUnit.GetParentGroup().GroupLead.DesiredAltitude_AGL;
						}
						else
						{
							desiredAltitude_UseTerrainFollowing = SpeedAlt_SelectedUnit.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit);
							desiredAltitude_AGL = SpeedAlt_SelectedUnit.DesiredAltitude_AGL;
						}
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							if (desiredAltitude_UseTerrainFollowing)
							{
								Label_DesiredAlt.Text = $"{desiredAltitude_AGL * 3.28084f:0}" + " 英尺 真高";
							}
							else
							{
								Label_DesiredAlt.Text = $"{SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f:0}" + " ft ASL";
							}
							if (Module_Unit.ResetTokenizer(SpeedAlt_SelectedUnit))
							{
								Label_CurrentAlt.Text = $"{SpeedAlt_SelectedUnit.GetCurrentAltitude() * 3.28084f:0}" + " 英尺 海高 (" + $"{SpeedAlt_SelectedUnit.CurrentAltitude_AGL * 3.28084f:0}" + "英尺 真高）";
							}
							else
							{
								Label_CurrentAlt.Text = $"{SpeedAlt_SelectedUnit.GetCurrentAltitude() * 3.28084f:0}" + " ft ASL";
							}
						}
						else
						{
							if (desiredAltitude_UseTerrainFollowing)
							{
								Label_DesiredAlt.Text = $"{desiredAltitude_AGL:0.0}" + " 米 真高";
							}
							else
							{
								Label_DesiredAlt.Text = $"{SpeedAlt_SelectedUnit.DesiredAltitude:0.0}" + " 米 海高";
							}
							if (Module_Unit.ResetTokenizer(SpeedAlt_SelectedUnit))
							{
								Label_CurrentAlt.Text = $"{SpeedAlt_SelectedUnit.GetCurrentAltitude():0.0}" + " 米 海高 (" + $"{SpeedAlt_SelectedUnit.CurrentAltitude_AGL:0.0}" + "米 真高）";
							}
							else
							{
								Label_CurrentAlt.Text = $"{SpeedAlt_SelectedUnit.GetCurrentAltitude():0.0}" + " 米 海高";
							}
						}
					}
					else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						Label_DesiredAlt.Text = string.Format("{0:0}", SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f, 0) + " 英尺";
						Label_CurrentAlt.Text = string.Format("{0:0}", SpeedAlt_SelectedUnit.GetCurrentAltitude() * 3.28084f, 0) + " 英尺";
					}
					else
					{
						Label_DesiredAlt.Text = string.Format("{0:0.0}", SpeedAlt_SelectedUnit.DesiredAltitude, 0) + " 米";
						Label_CurrentAlt.Text = string.Format("{0:0.0}", SpeedAlt_SelectedUnit.GetCurrentAltitude(), 0) + " 米";
					}
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						Group group2 = (Group)SpeedAlt_SelectedUnit;
						if (!Information.IsNothing(group2.GroupLead))
						{
							CB_TerrainFollowing.Checked = group2.GroupLead.GetDesiredAltitude_UseTerrainFollowing(group2.GroupLead);
							CB_UseLandCoverMasking.Checked = group2.GroupLead.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
						}
					}
					else
					{
						CB_TerrainFollowing.Checked = SpeedAlt_SelectedUnit.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit);
						CB_UseLandCoverMasking.Checked = SpeedAlt_SelectedUnit.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
					}
					if (!helperRecord)
					{
						bool desiredAltitude_UseTerrainFollowing2;
						float desiredAltitude_AGL2;
						if (SpeedAlt_SelectedUnit.IsGroupWingman() && !Information.IsNothing(SpeedAlt_SelectedUnit.GetParentGroup().GroupLead) && !SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride)
						{
							desiredAltitude_UseTerrainFollowing2 = SpeedAlt_SelectedUnit.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit.GetParentGroup().GroupLead);
							desiredAltitude_AGL2 = SpeedAlt_SelectedUnit.GetParentGroup().GroupLead.DesiredAltitude_AGL;
						}
						else
						{
							desiredAltitude_UseTerrainFollowing2 = SpeedAlt_SelectedUnit.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit);
							desiredAltitude_AGL2 = SpeedAlt_SelectedUnit.DesiredAltitude_AGL;
						}
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							if (SpeedAlt_SelectedUnit.IsGroup && ((((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)))
							{
								if (desiredAltitude_UseTerrainFollowing2)
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(desiredAltitude_AGL2 * 3.28084f));
								}
								else
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f));
								}
							}
							else if (SpeedAlt_SelectedUnit.IsAircraft | SpeedAlt_SelectedUnit.IsSubmarine)
							{
								if (desiredAltitude_UseTerrainFollowing2)
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(desiredAltitude_AGL2 * 3.28084f));
								}
								else
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude * 3.28084f));
								}
							}
						}
						else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
						{
							if (SpeedAlt_SelectedUnit.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit))
							{
								TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude_AGL));
							}
							else
							{
								TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude));
							}
						}
						else if (SpeedAlt_SelectedUnit.IsAircraft | SpeedAlt_SelectedUnit.IsSubmarine)
						{
							if (SpeedAlt_SelectedUnit.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit))
							{
								TextBox_EnterAltitude.Text = Conversions.ToString(SpeedAlt_SelectedUnit.DesiredAltitude_AGL);
							}
							else
							{
								TextBox_EnterAltitude.Text = Conversions.ToString(SpeedAlt_SelectedUnit.DesiredAltitude);
							}
						}
						if (!m_InfoRecord)
						{
							if (CB_SprintDrift.Checked & (SpeedAlt_SelectedUnit != null))
							{
								float? sprintDrift_AverageSpeed = SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed;
								if ((sprintDrift_AverageSpeed.HasValue ? new bool?(sprintDrift_AverageSpeed.GetValueOrDefault() != 0f) : null).GetValueOrDefault())
								{
									TextBox_EnterSpeed.Text = Conversions.ToString(SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value);
									goto IL_3d78;
								}
							}
							TextBox_EnterSpeed.Text = Conversions.ToString(SpeedAlt_SelectedUnit.DesiredSpeed);
						}
					}
					goto IL_3d78;
				}
			}
			else
			{
				Waypoint waypoint = ((Information.IsNothing(Client.SelectedWaypoint) || !Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) ? SpeedAlt_FlightPlanWaypoint : Client.SelectedWaypoint);
				if (waypoint.SprintDrift.GetValueOrDefault())
				{
					Label2.Text = "期望平均速度：";
					GroupBox_SpeedPresets.Enabled = false;
				}
				else
				{
					Label2.Text = "期望速度：";
					GroupBox_SpeedPresets.Enabled = true;
				}
				if (!Information.IsNothing(waypoint) && !Information.IsNothing(waypoint.SprintDrift) && waypoint.SprintDrift.GetValueOrDefault())
				{
					if (Information.IsNothing(waypoint.SprintDrift_AverageSpeed))
					{
						Label_DesiredSpeed.Text = "未输入平均冲刺漂移速度！";
					}
					else
					{
						Label_DesiredSpeed.Text = $"{waypoint.SprintDrift_AverageSpeed.Value:0} 节";
					}
				}
				else if (waypoint.DesiredSpeedOverride.HasValue)
				{
					if (Information.IsNothing(waypoint.DesiredSpeed))
					{
						if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.FullStop)
						{
							Label_DesiredSpeed.Text = "完全停止";
						}
						if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Loiter)
						{
							if (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.UseAerialUnitUI)
							{
								Label_DesiredSpeed.Text = "低速";
							}
							else
							{
								Label_DesiredSpeed.Text = "低速";
							}
						}
						if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Cruise)
						{
							Label_DesiredSpeed.Text = "巡航";
						}
						if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Full)
						{
							if (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.UseAerialUnitUI)
							{
								Label_DesiredSpeed.Text = "全速";
							}
							else
							{
								Label_DesiredSpeed.Text = "军用";
							}
						}
						if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.Flank)
						{
							if (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.UseAerialUnitUI)
							{
								Label_DesiredSpeed.Text = "最大";
							}
							else
							{
								Label_DesiredSpeed.Text = "加力";
							}
						}
					}
					else
					{
						Label_DesiredSpeed.Text = $"{waypoint.DesiredSpeed.Value:0}" + "节";
					}
				}
				else
				{
					Label_DesiredSpeed.Text = "没有设置";
				}
				if (waypoint.DesiredAltitudeOverride && !Information.IsNothing(waypoint.DesiredAltitude))
				{
					if (Information.IsNothing(waypoint.DesiredAltitude) && Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
					{
						if (Information.IsNothing(SpeedAlt_SelectedUnit))
						{
							if (SpeedAlt_FlightPlanWaypoint != null)
							{
								if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
								{
									Label_DesiredAlt.Text = "最高海拔高度";
								}
								if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
								{
									Label_DesiredAlt.Text = "最小高度";
								}
							}
						}
						else
						{
							if (SpeedAlt_SelectedUnit.UseSubmerisbleUnitUI && waypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
							{
								Label_DesiredAlt.Text = "最大深度";
							}
							if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
							{
								if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
								{
									Label_DesiredAlt.Text = "最高海拔高度";
								}
								if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
								{
									Label_DesiredAlt.Text = "最小高度";
								}
							}
						}
					}
					else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						if (SpeedAlt_FlightPlanWaypoint == null && (SpeedAlt_SelectedUnit == null || !SpeedAlt_SelectedUnit.UseAerialUnitUI))
						{
							Label_DesiredAlt.Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value)) + " 英尺";
						}
						else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
						{
							Label_DesiredAlt.Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude_TerrainFollowing * 3.28084f).Value)) + " 英尺 真高";
						}
						else if (!Information.IsNothing(waypoint.DesiredAltitude))
						{
							Label_DesiredAlt.Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value)) + " ft ASL";
						}
					}
					else if (SpeedAlt_FlightPlanWaypoint == null && (SpeedAlt_SelectedUnit == null || !SpeedAlt_SelectedUnit.UseAerialUnitUI))
					{
						Label_DesiredAlt.Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value)) + " 米";
					}
					else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
					{
						Label_DesiredAlt.Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value)) + " 米 真高";
					}
					else if (!Information.IsNothing(waypoint.DesiredAltitude))
					{
						Label_DesiredAlt.Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value)) + " 米 海高";
					}
				}
				else
				{
					Label_DesiredAlt.Text = "没有设置";
				}
				if (!m_InfoRecord)
				{
					TextBox_EnterSpeed.Text = Label_DesiredSpeed.Text;
				}
				if (!helperRecord)
				{
					TextBox_EnterAltitude.Text = Label_DesiredAlt.Text;
				}
				CB_TerrainFollowing.Checked = waypoint.TerrainFollowing;
				CB_UseLandCoverMasking.Checked = waypoint.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
				if (SpeedAlt_SelectedUnit != null)
				{
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						Label_ActualSpeed.Text = $"{((Group)SpeedAlt_SelectedUnit).GroupLead.CurrentSpeed:0} 节";
					}
					else
					{
						Label_ActualSpeed.Text = $"{SpeedAlt_SelectedUnit.CurrentSpeed:0} 节 (油门: {RunInterruptibleSchema()})";
					}
				}
				if (SpeedAlt_SelectedUnit != null)
				{
					if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
						{
							if (Module_Unit.ResetTokenizer(SpeedAlt_SelectedUnit))
							{
								Label_CurrentAlt.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.GetCurrentAltitude() * 3.28084f)) + " 英尺 海高 (" + Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.CurrentAltitude_AGL * 3.28084f)) + "英尺 真高）";
							}
							else
							{
								Label_CurrentAlt.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.GetCurrentAltitude() * 3.28084f)) + " ft ASL";
							}
						}
						else if (Module_Unit.ResetTokenizer(SpeedAlt_SelectedUnit))
						{
							Label_CurrentAlt.Text = $"{SpeedAlt_SelectedUnit.GetCurrentAltitude():0.0}" + " 米 海高 (" + $"{SpeedAlt_SelectedUnit.CurrentAltitude_AGL:0.0}" + "米 真高）";
						}
						else
						{
							Label_CurrentAlt.Text = $"{SpeedAlt_SelectedUnit.GetCurrentAltitude():0.0}" + " 米 海高";
						}
					}
					else if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						Label_CurrentAlt.Text = Conversions.ToString((int)Math.Round(SpeedAlt_SelectedUnit.GetCurrentAltitude() * 3.28084f)) + " 英尺";
					}
					else
					{
						Label_CurrentAlt.Text = $"{SpeedAlt_SelectedUnit.GetCurrentAltitude():0.0}" + " 米";
					}
				}
				if (!helperRecord)
				{
					if (waypoint.DesiredAltitude.HasValue || waypoint.DesiredAltitude_TerrainFollowing.HasValue || waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.None || waypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.None)
					{
						if (waypoint.DesiredAltitudeOverride)
						{
							if (waypoint.DesiredAltitude.HasValue || waypoint.DesiredAltitude_TerrainFollowing.HasValue)
							{
								if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
								{
									if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
									{
										TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude_TerrainFollowing * 3.28084f).Value));
									}
									else if (!Information.IsNothing(waypoint.DesiredAltitude))
									{
										TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round((waypoint.DesiredAltitude * 3.28084f).Value));
									}
								}
								else if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude_TerrainFollowing.Value));
								}
								else if (!Information.IsNothing(waypoint.DesiredAltitude))
								{
									TextBox_EnterAltitude.Text = Conversions.ToString((int)Math.Round(waypoint.DesiredAltitude.Value));
								}
							}
						}
						else
						{
							TextBox_EnterAltitude.Text = "";
						}
					}
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						bool? flag = (Information.IsNothing(waypoint.SprintDrift) ? new bool?(false) : waypoint.SprintDrift);
						if (flag.GetValueOrDefault(true) && !Information.IsNothing(waypoint.SprintDrift_AverageSpeed) && flag.HasValue)
						{
							if (!m_InfoRecord)
							{
								TextBox_EnterSpeed.Text = Conversions.ToString(waypoint.SprintDrift_AverageSpeed.Value);
							}
						}
						else if (waypoint.DesiredSpeedOverride.HasValue)
						{
							if (waypoint.DesiredSpeed.HasValue && !m_InfoRecord)
							{
								TextBox_EnterSpeed.Text = Conversions.ToString(waypoint.DesiredSpeed.Value);
							}
						}
						else if (!m_InfoRecord)
						{
							TextBox_EnterSpeed.Text = "";
						}
					}
				}
				CB_SpeedOverride.Checked = waypoint.DesiredSpeedOverride.HasValue;
				CB_AltOverride.Checked = waypoint.DesiredAltitudeOverride;
				if (Information.IsNothing(waypoint.DesiredSpeedOverride))
				{
					if (waypoint.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						RB_NoThrottlePreset.Visible = false;
					}
					else
					{
						RB_NoThrottlePreset.Visible = true;
					}
				}
				else
				{
					RB_NoThrottlePreset.Visible = false;
				}
				if (waypoint.DesiredAltitudeOverride)
				{
					if (waypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.None)
					{
						RB_NoAltitudePreset.Visible = false;
					}
					else
					{
						RB_NoAltitudePreset.Visible = true;
					}
					if (waypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.None)
					{
						RB_NoDepthPreset.Visible = false;
					}
					else
					{
						RB_NoDepthPreset.Visible = true;
					}
					if (SpeedAlt_SelectedUnit == null)
					{
						RB_Surface.Checked = false;
						RB_Periscope.Checked = false;
						RB_Shallow.Checked = false;
						RB_OverLayer.Checked = false;
						RB_UnderLayer.Checked = false;
						RB_MaxDepth.Checked = false;
						RB_MaxAltitude.Checked = false;
						RB_HighAltitude36000.Checked = false;
						RB_HighAltitude25000.Checked = false;
						RB_MediumAltitude12000.Checked = false;
						RB_LowAltitude2000.Checked = false;
						RB_LowAltitude1000.Checked = false;
						RB_MinAltitude.Checked = false;
						RB_NoDepthPreset.Visible = false;
						RB_NoAltitudePreset.Visible = false;
					}
					else if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
					{
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
						{
							RB_MaxAltitude.Checked = true;
						}
						else
						{
							RB_MaxAltitude.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.const_6)
						{
							RB_HighAltitude36000.Checked = true;
						}
						else
						{
							RB_HighAltitude36000.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.const_5)
						{
							RB_HighAltitude25000.Checked = true;
						}
						else
						{
							RB_HighAltitude25000.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.const_4)
						{
							RB_MediumAltitude12000.Checked = true;
						}
						else
						{
							RB_MediumAltitude12000.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.Low2000)
						{
							RB_LowAltitude2000.Checked = true;
						}
						else
						{
							RB_LowAltitude2000.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.Low1000)
						{
							RB_LowAltitude1000.Checked = true;
						}
						else
						{
							RB_LowAltitude1000.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
						{
							RB_MinAltitude.Checked = true;
						}
						else
						{
							RB_MinAltitude.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset != 0)
						{
							Client.SelectedWaypoint.FollowAltitudePreset();
						}
					}
					else if (SpeedAlt_SelectedUnit.UseSubmerisbleUnitUI)
					{
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Surface)
						{
							RB_Surface.Checked = true;
						}
						else
						{
							RB_Surface.Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Periscope)
						{
							RB_Periscope.Checked = true;
						}
						else
						{
							RB_Periscope.Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Shallow)
						{
							RB_Shallow.Checked = true;
						}
						else
						{
							RB_Shallow.Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.OverLayer)
						{
							RB_OverLayer.Checked = true;
						}
						else
						{
							RB_OverLayer.Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.UnderLayer)
						{
							RB_UnderLayer.Checked = true;
						}
						else
						{
							RB_UnderLayer.Checked = false;
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
						{
							RB_MaxDepth.Checked = true;
						}
						else
						{
							RB_MaxDepth.Checked = false;
						}
						if (Client.SelectedWaypoint.AltitudePreset != 0)
						{
							Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
						}
						if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
						{
							Client.SelectedWaypoint.DesiredAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
						}
					}
				}
				if (Information.IsNothing(waypoint.ThrottlePreset))
				{
					RB_Stop.Checked = false;
					RB_Creep.Checked = false;
					RB_Cruise.Checked = false;
					RB_Full.Checked = false;
					RB_Flank.Checked = false;
					RB_NoThrottlePreset.Checked = false;
				}
				else
				{
					switch (waypoint.ThrottlePreset)
					{
					default:
						if (RB_Stop.Checked)
						{
							RB_Stop.Checked = false;
						}
						if (RB_Creep.Checked)
						{
							RB_Creep.Checked = false;
						}
						if (RB_Cruise.Checked)
						{
							RB_Cruise.Checked = false;
						}
						if (RB_Full.Checked)
						{
							RB_Full.Checked = false;
						}
						if (RB_Flank.Checked)
						{
							RB_Flank.Checked = false;
						}
						if (RB_NoThrottlePreset.Checked)
						{
							RB_NoThrottlePreset.Checked = false;
						}
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
						if (!RB_Stop.Checked)
						{
							RB_Stop.Checked = true;
						}
						CB_SpeedOverride.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
						if (!RB_Creep.Checked)
						{
							RB_Creep.Checked = true;
						}
						CB_SpeedOverride.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
						if (!RB_Cruise.Checked)
						{
							RB_Cruise.Checked = true;
						}
						CB_SpeedOverride.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
						if (!RB_Full.Checked)
						{
							RB_Full.Checked = true;
						}
						CB_SpeedOverride.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
						if (!RB_Flank.Checked)
						{
							RB_Flank.Checked = true;
						}
						CB_SpeedOverride.Checked = true;
						break;
					case ActiveUnit_Kinematics.UnitThrottlePreset.None:
						if (!RB_NoThrottlePreset.Checked)
						{
							RB_NoThrottlePreset.Checked = true;
						}
						break;
					}
				}
				if (!Information.IsNothing(SpeedAlt_SelectedUnit) && SpeedAlt_FlightPlanWaypoint == null)
				{
					int num5 = Array.IndexOf(SpeedAlt_SelectedUnit.Navigator.PlottedCourse, Client.SelectedWaypoint);
					bool flag2 = false;
					if (num5 >= 0)
					{
						if (SpeedAlt_SelectedUnit.IsAircraft || SpeedAlt_SelectedUnit.IsShip || SpeedAlt_SelectedUnit.IsSubmarine)
						{
							flag2 = true;
						}
						if (!flag2 && SpeedAlt_SelectedUnit.IsGroup && ((((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SurfaceGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)))
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						int num6 = 0;
						int num7 = 0;
						try
						{
							int num8 = num5;
							float num9 = 0f;
							float num10 = 0f;
							for (int i = 0; i <= num8; i++)
							{
								if (i == 0)
								{
									num6 = (int)Math.Round(SpeedAlt_SelectedUnit.CurrentSpeed);
									num7 = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredSpeed);
									num9 = SpeedAlt_SelectedUnit.GetCurrentAltitude();
									num10 = SpeedAlt_SelectedUnit.DesiredAltitude;
									num13 = Module_Unit.RangeToPoint_Horiz(SpeedAlt_SelectedUnit, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0]);
									ActiveUnit activeUnit = (SpeedAlt_SelectedUnit.IsGroup ? ((Group)SpeedAlt_SelectedUnit).GroupLead : SpeedAlt_SelectedUnit);
									if (num6 > 0 && num15 < float.MaxValue && num17 < float.MaxValue)
									{
										num15 = (float)(num13 / (double)num6 * 3600.0);
										num17 = num15 * activeUnit.FuelConsumption(activeUnit.Kinematics.GetThrottleSuitableForThisSpeed(num9, num6), null, num6, num9, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
									}
									else
									{
										num15 = float.MaxValue;
										num17 = float.MaxValue;
									}
									if (num7 > 0 && num16 < float.MaxValue && num18 < float.MaxValue)
									{
										num16 = (float)(num13 / (double)num7 * 3600.0);
										num18 = num16 * activeUnit.FuelConsumption(activeUnit.ThrottleSetting, null, num7, num10, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
									}
									else
									{
										num16 = float.MaxValue;
										num18 = float.MaxValue;
									}
								}
								else
								{
									if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Latitude == SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Latitude || SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Longitude == SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Longitude)
									{
										continue;
									}
									num14 = Math2.VerifyClass(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Latitude, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i].Longitude, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Latitude, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].Longitude);
									if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitudeOverride)
									{
										if (Information.IsNothing(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitude))
										{
											if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.None)
											{
												if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].AltitudePreset != 0 && SpeedAlt_SelectedUnit.UseAerialUnitUI)
												{
													if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude)
													{
														num9 = num2;
														num10 = num2;
													}
													if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].AltitudePreset == ActiveUnit_AI.AircraftAltitudePreset.MinAltitude)
													{
														num9 = num3;
														num10 = num3;
													}
												}
											}
											else if (SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup))
											{
												if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.Surface)
												{
													num9 = 0f;
													num10 = 0f;
												}
												if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
												{
													num9 = num3;
													num10 = num3;
												}
											}
										}
										else
										{
											num9 = SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitude.Value;
											num10 = SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredAltitude.Value;
											if (num9 < num3)
											{
												num9 = num3;
											}
											if (num9 > num2)
											{
												num9 = num2;
											}
											if (num10 < num3)
											{
												num10 = num3;
											}
											if (num10 > num2)
											{
												num10 = num2;
											}
										}
									}
									if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeedOverride.HasValue)
									{
										if (!Information.IsNothing(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeed))
										{
											num6 = (int)Math.Round(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeed.Value);
											num7 = (int)Math.Round(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].DesiredSpeed.Value);
											if (num6 > SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num9))
											{
												num6 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num9);
											}
											if (num7 > SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num10))
											{
												num7 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num10);
											}
											if (SpeedAlt_SelectedUnit.IsAircraft)
											{
												if (!((Aircraft)SpeedAlt_SelectedUnit).GetCanHover(bool_1: false))
												{
													if (num6 < ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num9, ActiveUnit.Throttle.Loiter, bool_0: false))
													{
														num6 = ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num9, ActiveUnit.Throttle.Loiter, bool_0: false);
													}
													if (num7 < ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num10, ActiveUnit.Throttle.Loiter, bool_0: false))
													{
														num7 = ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num10, ActiveUnit.Throttle.Loiter, bool_0: false);
													}
												}
											}
											else if (SpeedAlt_SelectedUnit.IsWeapon)
											{
												if (num6 < ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num9, ActiveUnit.Throttle.Cruise, bool_0: false))
												{
													num6 = ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num9, ActiveUnit.Throttle.Cruise, bool_0: false);
												}
												if (num7 < ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num10, ActiveUnit.Throttle.Cruise, bool_0: false))
												{
													num7 = ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(num10, ActiveUnit.Throttle.Cruise, bool_0: false);
												}
											}
											else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
											{
												if (Information.IsNothing(((Group)SpeedAlt_SelectedUnit).GroupLead))
												{
													return;
												}
												Aircraft aircraft = (Aircraft)((Group)SpeedAlt_SelectedUnit).GroupLead;
												if (!aircraft.GetCanHover(bool_1: false))
												{
													if (num6 < aircraft.Kinematics.GetMaximumSpeed(num9, ActiveUnit.Throttle.Loiter, bool_0: false))
													{
														num6 = aircraft.Kinematics.GetMaximumSpeed(num9, ActiveUnit.Throttle.Loiter, bool_0: false);
													}
													if (num7 < aircraft.Kinematics.GetMaximumSpeed(num10, ActiveUnit.Throttle.Loiter, bool_0: false))
													{
														num7 = aircraft.Kinematics.GetMaximumSpeed(num10, ActiveUnit.Throttle.Loiter, bool_0: false);
													}
												}
											}
											else
											{
												if (num6 < (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(num9, bool_0: false)))
												{
													num6 = (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.GetCurrentAltitude(), bool_0: false));
												}
												if (num7 < (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(num10, bool_0: false)))
												{
													num7 = (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.DesiredAltitude, bool_0: false));
												}
											}
										}
									}
									else if (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
									{
										num6 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num9, (ActiveUnit.Throttle)SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].ThrottlePreset, bool_0: false);
										num7 = SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(num10, (ActiveUnit.Throttle)SpeedAlt_SelectedUnit.Navigator.PlottedCourse[i - 1].ThrottlePreset, bool_0: false);
									}
									if (num6 <= 0 || num7 <= 0)
									{
										break;
									}
									num13 += num14;
									ActiveUnit activeUnit2 = (SpeedAlt_SelectedUnit.IsGroup ? ((Group)SpeedAlt_SelectedUnit).GroupLead : SpeedAlt_SelectedUnit);
									if (num6 > 0 && num15 < float.MaxValue && num17 < float.MaxValue)
									{
										num15 = (float)((double)num15 + num14 / (double)num6 * 3600.0);
										num17 = (float)((double)num17 + num14 / (double)num6 * 3600.0 * (double)activeUnit2.FuelConsumption(activeUnit2.Kinematics.GetThrottleSuitableForThisSpeed(num9, num6), null, num6, num9, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false));
									}
									if (num7 > 0 && num16 < float.MaxValue && num18 < float.MaxValue)
									{
										num16 = (float)((double)num16 + num14 / (double)num7 * 3600.0);
										num18 = (float)((double)num18 + num14 / (double)num7 * 3600.0 * (double)activeUnit2.FuelConsumption(activeUnit2.Kinematics.GetThrottleSuitableForThisSpeed(num9, num6), null, num7, num10, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false));
									}
								}
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_.Data.Add("Error at 200412", exception_.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						try
						{
							if (num6 > 0 && num7 > 0 && num16 > 0f && num15 > 0f && (float)num6 < float.MaxValue && (float)num7 < float.MaxValue && num16 < float.MaxValue && num15 < float.MaxValue)
							{
								Label_DTG.Text = "距目标距离：" + $"{num13:0} 海里";
								if ((int)Math.Round(num16) == (int)Math.Round(num15))
								{
									Label_TTG.Text = "距目标时间：" + Misc.UpdateRequest((long)Math.Round(num16));
									Label_Fuel.Text = "所需燃料数量：" + $"{num18:0.0}" + "千克";
								}
								else
								{
									Label_TTG.Text = "距目标时间：" + Misc.UpdateRequest((long)Math.Round(num15)) + "（当前），" + Misc.UpdateRequest((long)Math.Round(num16)) + "（期望的）";
									Label_Fuel.Text = "所需燃料数量：" + $"{num17:0.0}" + "千克（当前），" + $"{num18:0.0}" + "千克（所需）";
								}
								Label_WaypointName.Text = "航点 #" + Conversions.ToString(num5 + 1) + " for " + SpeedAlt_SelectedUnit.Name;
							}
							else
							{
								Label_WaypointName.Text = "有一个或多个速度相关参数设置为0，无法估算到达目标距离/时间/油耗。";
								Label_DTG.Text = "";
								Label_TTG.Text = "";
								Label_Fuel.Text = "";
							}
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2.Data.Add("Error at 200413", exception_2.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						Label_WaypointName.Text = "";
						Label_DTG.Text = "";
						Label_TTG.Text = "";
						Label_Fuel.Text = "";
					}
				}
				else
				{
					Label_DTG.Text = "";
					Label_TTG.Text = "";
					Label_Fuel.Text = "";
				}
				if (!m_MapperRecord)
				{
					TextBox_WaypointDescription.Text = waypoint.Description;
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
						CB_WaypointType.SelectedIndex = 1;
						break;
					case Waypoint.WaypointType.PatrolStation:
						CB_WaypointType.SelectedIndex = 13;
						break;
					case Waypoint.WaypointType.LocalizationRun:
						CB_WaypointType.SelectedIndex = 14;
						break;
					case Waypoint.WaypointType.Assemble:
						CB_WaypointType.SelectedIndex = 0;
						break;
					case Waypoint.WaypointType.TurningPoint:
						CB_WaypointType.SelectedIndex = 3;
						break;
					case Waypoint.WaypointType.InitialPoint:
						CB_WaypointType.SelectedIndex = 4;
						break;
					case Waypoint.WaypointType.LandingMarshal:
						CB_WaypointType.SelectedIndex = 11;
						break;
					case Waypoint.WaypointType.StrikeIngress:
						CB_WaypointType.SelectedIndex = 5;
						break;
					case Waypoint.WaypointType.StrikeEgress:
						CB_WaypointType.SelectedIndex = 6;
						break;
					case Waypoint.WaypointType.Refuel:
						CB_WaypointType.SelectedIndex = 15;
						break;
					case Waypoint.WaypointType.TakeOff:
						CB_WaypointType.SelectedIndex = 7;
						break;
					case Waypoint.WaypointType.Land:
						CB_WaypointType.SelectedIndex = 12;
						break;
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponTarget:
						CB_WaypointType.SelectedIndex = 2;
						break;
					case Waypoint.WaypointType.HoldStart:
						CB_WaypointType.SelectedIndex = 8;
						break;
					case Waypoint.WaypointType.HoldEnd:
						CB_WaypointType.SelectedIndex = 9;
						break;
					}
				}
			}
			goto IL_5c72;
			IL_3d78:
			if (SpeedAlt_SelectedUnit.IsGroup)
			{
				if (Information.IsNothing(((Group)SpeedAlt_SelectedUnit).GroupLead))
				{
					return;
				}
				CB_SpeedOverride.Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride.HasValue;
				CB_AltOverride.Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride;
			}
			else
			{
				CB_SpeedOverride.Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride.HasValue;
				CB_AltOverride.Checked = SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride;
			}
			Label_MinSpeed.Text = TrackBar_Throttle.Minimum + "节";
			Label_MaxSpeed.Text = TrackBar_Throttle.Maximum + "节";
			if (SpeedAlt_SelectedUnit.Navigator.SprintDrift && !Information.IsNothing(SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed))
			{
				if (SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value <= (float)TrackBar_Throttle.Maximum)
				{
					if (SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value < (float)TrackBar_Throttle.Minimum)
					{
						TrackBar_Throttle.Value = TrackBar_Throttle.Minimum;
					}
					else
					{
						TrackBar_Throttle.Value = (int)Math.Round(SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value);
					}
				}
				else
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
			}
			else if (SpeedAlt_SelectedUnit.DesiredSpeed <= (float)TrackBar_Throttle.Maximum)
			{
				if (SpeedAlt_SelectedUnit.DesiredSpeed < (float)TrackBar_Throttle.Minimum)
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Minimum;
				}
				else
				{
					TrackBar_Throttle.Value = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredSpeed);
				}
			}
			else
			{
				TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
			}
			if (SpeedAlt_SelectedUnit.DesiredAltitude <= (float)TrackBar_Altitude.Maximum)
			{
				if (SpeedAlt_SelectedUnit.DesiredAltitude < (float)TrackBar_Altitude.Minimum)
				{
					TrackBar_Altitude.Value = TrackBar_Altitude.Minimum;
				}
				else
				{
					TrackBar_Altitude.Value = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude);
				}
			}
			else
			{
				TrackBar_Altitude.Value = TrackBar_Altitude.Maximum;
			}
			bool flag3 = false;
			if (SpeedAlt_SelectedUnit.IsAircraft | SpeedAlt_SelectedUnit.IsShip | SpeedAlt_SelectedUnit.IsSubmarine)
			{
				flag3 = true;
			}
			if (SpeedAlt_SelectedUnit.IsGroup && ((((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SurfaceGroup) | (((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)))
			{
				flag3 = true;
			}
			if (flag3 && SpeedAlt_SelectedUnit.Navigator.PlottedCourse.Count() > 0)
			{
				try
				{
					if (!(SpeedAlt_SelectedUnit.CurrentSpeed <= 0f) && SpeedAlt_SelectedUnit.DesiredSpeed > 0f)
					{
						num13 = Module_Unit.RangeToPoint_Horiz(SpeedAlt_SelectedUnit, SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0]);
						num15 = (float)(num13 / (double)SpeedAlt_SelectedUnit.CurrentSpeed * 3600.0);
						num16 = (float)(num13 / (double)SpeedAlt_SelectedUnit.DesiredSpeed * 3600.0);
						ActiveUnit activeUnit3 = (SpeedAlt_SelectedUnit.IsGroup ? ((Group)SpeedAlt_SelectedUnit).GroupLead : SpeedAlt_SelectedUnit);
						num17 = num15 * activeUnit3.FuelConsumption(activeUnit3.Kinematics.GetThrottleSuitableForThisSpeed(activeUnit3.GetCurrentAltitude(), (int)Math.Round(activeUnit3.CurrentSpeed)), null, (int)Math.Round(activeUnit3.CurrentSpeed), activeUnit3.GetCurrentAltitude(), bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
						num18 = num16 * activeUnit3.FuelConsumption(activeUnit3.ThrottleSetting, null, (int)Math.Round(activeUnit3.DesiredSpeed), activeUnit3.DesiredAltitude, bool_0: false, bool_1: false, bool_2: false, bool_3: false, bool_4: false);
						Label_DTG.Text = "距目标距离：" + $"{num13:0} 海里";
						if ((int)Math.Round(num16) == (int)Math.Round(num15))
						{
							Label_TTG.Text = "距目标时间：" + Misc.UpdateRequest((long)Math.Round(num16));
							Label_Fuel.Text = "所需燃料数量：" + string.Format("{0:0.0}", num18, 1) + "千克";
						}
						else
						{
							Label_TTG.Text = "距目标时间：" + Misc.UpdateRequest((long)Math.Round(num15)) + "（当前），" + Misc.UpdateRequest((long)Math.Round(num16)) + "（期望的）";
							Label_Fuel.Text = "所需燃料数量：" + string.Format("{0:0.0}", num17, 1) + "千克（当前），" + string.Format("{0:0.0}", num18, 1) + "千克（所需）";
						}
						if (Operators.CompareString(SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Name, "", TextCompare: true) == 0)
						{
							Label_WaypointName.Text = "下一个航点：导航航点";
						}
						else
						{
							Label_WaypointName.Text = "下一个航点：" + SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Name;
						}
					}
					else
					{
						Label_WaypointName.Text = "有一个或多个速度相关参数设置为0，无法估算到达目标距离/时间/油耗。";
						Label_DTG.Text = "";
						Label_TTG.Text = "";
						Label_Fuel.Text = "";
					}
					TextBox_WaypointDescription.Text = SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Description;
					switch (SpeedAlt_SelectedUnit.Navigator.PlottedCourse[0].Type)
					{
					case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
						CB_WaypointType.SelectedIndex = 1;
						break;
					case Waypoint.WaypointType.PatrolStation:
						CB_WaypointType.SelectedIndex = 13;
						break;
					case Waypoint.WaypointType.LocalizationRun:
						CB_WaypointType.SelectedIndex = 14;
						break;
					case Waypoint.WaypointType.Assemble:
						CB_WaypointType.SelectedIndex = 0;
						break;
					case Waypoint.WaypointType.TurningPoint:
						CB_WaypointType.SelectedIndex = 3;
						break;
					case Waypoint.WaypointType.InitialPoint:
						CB_WaypointType.SelectedIndex = 4;
						break;
					case Waypoint.WaypointType.LandingMarshal:
						CB_WaypointType.SelectedIndex = 11;
						break;
					case Waypoint.WaypointType.StrikeIngress:
						CB_WaypointType.SelectedIndex = 5;
						break;
					case Waypoint.WaypointType.StrikeEgress:
						CB_WaypointType.SelectedIndex = 6;
						break;
					case Waypoint.WaypointType.Refuel:
						CB_WaypointType.SelectedIndex = 15;
						break;
					case Waypoint.WaypointType.TakeOff:
						CB_WaypointType.SelectedIndex = 7;
						break;
					case Waypoint.WaypointType.Land:
						CB_WaypointType.SelectedIndex = 12;
						break;
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponTarget:
						CB_WaypointType.SelectedIndex = 2;
						break;
					case Waypoint.WaypointType.HoldStart:
						CB_WaypointType.SelectedIndex = 8;
						break;
					case Waypoint.WaypointType.HoldEnd:
						CB_WaypointType.SelectedIndex = 9;
						break;
					case Waypoint.WaypointType.TerminalPoint:
					case Waypoint.WaypointType.PathfindingPoint:
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.Marshal:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
					case Waypoint.WaypointType.PickupPoint:
						break;
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception exception_3 = ex3;
					exception_3.Data.Add("Error at 200414", exception_3.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_3);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Label_WaypointName.Text = "";
				Label_DTG.Text = "";
				Label_TTG.Text = "";
				Label_Fuel.Text = "";
				TextBox_WaypointDescription.Text = "";
				CB_WaypointType.SelectedIndex = -1;
			}
			if (TrackBar_Altitude.Maximum != (int)Math.Round(num2))
			{
				TrackBar_Altitude.Maximum = (int)Math.Round(num2);
			}
			TrackBar_Altitude.Minimum = (int)Math.Round(num3);
			if (SpeedAlt_SelectedUnit.IsAircraft)
			{
				if (!((Aircraft)SpeedAlt_SelectedUnit).GetCanHover(bool_1: false))
				{
					TrackBar_Throttle.Minimum = ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
					RB_Stop.Enabled = false;
				}
				RB_Cruise.Enabled = true;
				RB_Creep.Enabled = true;
			}
			else if (SpeedAlt_SelectedUnit.IsShip)
			{
				TrackBar_Throttle.Minimum = 0;
				RB_Cruise.Enabled = true;
				RB_Creep.Enabled = true;
				RB_Stop.Enabled = true;
			}
			else if (SpeedAlt_SelectedUnit.IsSubmarine)
			{
				TrackBar_Throttle.Minimum = 0;
				RB_Cruise.Enabled = true;
				RB_Creep.Enabled = true;
				RB_Stop.Enabled = true;
			}
			else if (SpeedAlt_SelectedUnit.IsFacility)
			{
				TrackBar_Throttle.Minimum = 0;
				if (((Facility)SpeedAlt_SelectedUnit).Category != Facility._FacilityCategory.Mobile_Vehicle && ((Facility)SpeedAlt_SelectedUnit).Category != Facility._FacilityCategory.Mobile_Personnel)
				{
					RB_Creep.Enabled = false;
					RB_Cruise.Enabled = false;
					RB_Stop.Enabled = true;
				}
				else
				{
					RB_Creep.Enabled = true;
					RB_Cruise.Enabled = true;
					RB_Stop.Enabled = true;
				}
			}
			else if (SpeedAlt_SelectedUnit.IsWeapon)
			{
				TrackBar_Throttle.Minimum = ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false);
				RB_Stop.Enabled = false;
				RB_Creep.Enabled = false;
				RB_Cruise.Enabled = true;
			}
			else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
			{
				if (Information.IsNothing(((Group)SpeedAlt_SelectedUnit).GroupLead))
				{
					return;
				}
				Aircraft aircraft2 = (Aircraft)((Group)SpeedAlt_SelectedUnit).GroupLead;
				if (!aircraft2.GetCanHover(bool_1: false))
				{
					TrackBar_Throttle.Minimum = aircraft2.Kinematics.GetMaximumSpeed(aircraft2.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
					RB_Stop.Enabled = false;
				}
				RB_Creep.Enabled = true;
				RB_Cruise.Enabled = true;
			}
			else
			{
				TrackBar_Throttle.Minimum = (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.GetCurrentAltitude(), bool_0: false));
			}
			if (SpeedAlt_SelectedUnit.IsSubmarine && !Information.IsNothing(SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset) && SpeedAlt_SelectedUnit.DesiredSpeed != (float)SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), (ActiveUnit.Throttle)SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset, bool_0: false))
			{
				RB_Stop.Checked = false;
				RB_Creep.Checked = false;
				RB_Cruise.Checked = false;
				RB_Full.Checked = false;
				RB_Flank.Checked = false;
				switch (SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset)
				{
				case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
					RB_Stop.Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
					RB_Creep.Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
					RB_Cruise.Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
					RB_Full.Checked = true;
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
					RB_Flank.Checked = true;
					break;
				}
			}
			if (Information.IsNothing(SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset))
			{
				RB_Stop.Checked = false;
				RB_Creep.Checked = false;
				RB_Cruise.Checked = false;
				RB_Full.Checked = false;
				RB_Flank.Checked = false;
				RB_NoThrottlePreset.Checked = false;
			}
			else
			{
				switch (SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset)
				{
				default:
					if (RB_Stop.Checked)
					{
						RB_Stop.Checked = false;
					}
					if (RB_Creep.Checked)
					{
						RB_Creep.Checked = false;
					}
					if (RB_Cruise.Checked)
					{
						RB_Cruise.Checked = false;
					}
					if (RB_Full.Checked)
					{
						RB_Full.Checked = false;
					}
					if (RB_Flank.Checked)
					{
						RB_Flank.Checked = false;
					}
					if (RB_NoThrottlePreset.Checked)
					{
						RB_NoThrottlePreset.Checked = false;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.FullStop:
					if (!RB_Stop.Checked)
					{
						RB_Stop.Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Loiter:
					if (!RB_Creep.Checked)
					{
						RB_Creep.Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Cruise:
					if (!RB_Cruise.Checked)
					{
						RB_Cruise.Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Full:
					if (!RB_Full.Checked)
					{
						RB_Full.Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.Flank:
					if (!RB_Flank.Checked)
					{
						RB_Flank.Checked = true;
					}
					break;
				case ActiveUnit_Kinematics.UnitThrottlePreset.None:
					if (!RB_NoThrottlePreset.Checked)
					{
						RB_NoThrottlePreset.Checked = true;
					}
					break;
				}
			}
			if (SpeedAlt_SelectedUnit.IsAircraft)
			{
				switch (((Aircraft)SpeedAlt_SelectedUnit).AI.AltitudePreset)
				{
				default:
					if (RB_MaxAltitude.Checked)
					{
						RB_MaxAltitude.Checked = false;
					}
					if (RB_HighAltitude36000.Checked)
					{
						RB_HighAltitude36000.Checked = false;
					}
					if (RB_HighAltitude25000.Checked)
					{
						RB_HighAltitude25000.Checked = false;
					}
					if (RB_MediumAltitude12000.Checked)
					{
						RB_MediumAltitude12000.Checked = false;
					}
					if (RB_LowAltitude2000.Checked)
					{
						RB_LowAltitude2000.Checked = false;
					}
					if (RB_LowAltitude1000.Checked)
					{
						RB_LowAltitude1000.Checked = false;
					}
					if (RB_MinAltitude.Checked)
					{
						RB_MinAltitude.Checked = false;
					}
					if (RB_NoAltitudePreset.Checked)
					{
						RB_NoAltitudePreset.Checked = false;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.None:
					if (!RB_NoAltitudePreset.Checked)
					{
						RB_NoAltitudePreset.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
					if (!RB_MinAltitude.Checked)
					{
						RB_MinAltitude.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
					if (!RB_LowAltitude1000.Checked)
					{
						RB_LowAltitude1000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
					if (!RB_LowAltitude2000.Checked)
					{
						RB_LowAltitude2000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_4:
					if (!RB_MediumAltitude12000.Checked)
					{
						RB_MediumAltitude12000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_5:
					if (!RB_HighAltitude25000.Checked)
					{
						RB_HighAltitude25000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_6:
					if (!RB_HighAltitude36000.Checked)
					{
						RB_HighAltitude36000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
					if (!RB_MaxAltitude.Checked)
					{
						RB_MaxAltitude.Checked = true;
					}
					break;
				}
			}
			else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
			{
				switch (((Aircraft_AI)((Group)SpeedAlt_SelectedUnit).GroupLead.AI).AltitudePreset)
				{
				default:
					if (RB_MaxAltitude.Checked)
					{
						RB_MaxAltitude.Checked = false;
					}
					if (RB_HighAltitude36000.Checked)
					{
						RB_HighAltitude36000.Checked = false;
					}
					if (RB_HighAltitude25000.Checked)
					{
						RB_HighAltitude25000.Checked = false;
					}
					if (RB_MediumAltitude12000.Checked)
					{
						RB_MediumAltitude12000.Checked = false;
					}
					if (RB_LowAltitude2000.Checked)
					{
						RB_LowAltitude2000.Checked = false;
					}
					if (RB_LowAltitude1000.Checked)
					{
						RB_LowAltitude1000.Checked = false;
					}
					if (RB_MinAltitude.Checked)
					{
						RB_MinAltitude.Checked = false;
					}
					if (RB_NoAltitudePreset.Checked)
					{
						RB_NoAltitudePreset.Checked = false;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.None:
					if (!RB_NoAltitudePreset.Checked)
					{
						RB_NoAltitudePreset.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.MinAltitude:
					if (!RB_MinAltitude.Checked)
					{
						RB_MinAltitude.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.Low1000:
					if (!RB_LowAltitude1000.Checked)
					{
						RB_LowAltitude1000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.Low2000:
					if (!RB_LowAltitude2000.Checked)
					{
						RB_LowAltitude2000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_4:
					if (!RB_MediumAltitude12000.Checked)
					{
						RB_MediumAltitude12000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_5:
					if (!RB_HighAltitude25000.Checked)
					{
						RB_HighAltitude25000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.const_6:
					if (!RB_HighAltitude36000.Checked)
					{
						RB_HighAltitude36000.Checked = true;
					}
					break;
				case ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude:
					if (!RB_MaxAltitude.Checked)
					{
						RB_MaxAltitude.Checked = true;
					}
					break;
				}
			}
			if (SpeedAlt_SelectedUnit.IsSubmarine)
			{
				switch (((Submarine)SpeedAlt_SelectedUnit).AI.DepthPreset)
				{
				default:
					if (RB_Surface.Checked)
					{
						RB_Surface.Checked = false;
					}
					if (RB_Periscope.Checked)
					{
						RB_Periscope.Checked = false;
					}
					if (RB_Shallow.Checked)
					{
						RB_Shallow.Checked = false;
					}
					if (RB_OverLayer.Checked)
					{
						RB_OverLayer.Checked = false;
					}
					if (RB_UnderLayer.Checked)
					{
						RB_UnderLayer.Checked = false;
					}
					if (RB_MaxDepth.Checked)
					{
						RB_MaxDepth.Checked = false;
					}
					if (RB_NoDepthPreset.Checked)
					{
						RB_NoDepthPreset.Checked = false;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.None:
					if (!RB_NoDepthPreset.Checked)
					{
						RB_NoDepthPreset.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
					if (!RB_Periscope.Checked)
					{
						RB_Periscope.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
					if (!RB_Shallow.Checked)
					{
						RB_Shallow.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
					if (!RB_OverLayer.Checked)
					{
						RB_OverLayer.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
					if (!RB_UnderLayer.Checked)
					{
						RB_UnderLayer.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
					if (!RB_MaxDepth.Checked)
					{
						RB_MaxDepth.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Surface:
					if (!RB_Surface.Checked)
					{
						RB_Surface.Checked = true;
					}
					break;
				}
			}
			else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)
			{
				switch (((Submarine_AI)((Group)SpeedAlt_SelectedUnit).GroupLead.AI).DepthPreset)
				{
				default:
					if (RB_Surface.Checked)
					{
						RB_Surface.Checked = false;
					}
					if (RB_Periscope.Checked)
					{
						RB_Periscope.Checked = false;
					}
					if (RB_Shallow.Checked)
					{
						RB_Shallow.Checked = false;
					}
					if (RB_OverLayer.Checked)
					{
						RB_OverLayer.Checked = false;
					}
					if (RB_UnderLayer.Checked)
					{
						RB_UnderLayer.Checked = false;
					}
					if (RB_MaxDepth.Checked)
					{
						RB_MaxDepth.Checked = false;
					}
					if (RB_NoDepthPreset.Checked)
					{
						RB_NoDepthPreset.Checked = false;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.None:
					if (!RB_NoDepthPreset.Checked)
					{
						RB_NoDepthPreset.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Periscope:
					if (!RB_Periscope.Checked)
					{
						RB_Periscope.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Shallow:
					if (!RB_Shallow.Checked)
					{
						RB_Shallow.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.OverLayer:
					if (!RB_OverLayer.Checked)
					{
						RB_OverLayer.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.UnderLayer:
					if (!RB_UnderLayer.Checked)
					{
						RB_UnderLayer.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.MaxDepth:
					if (!RB_MaxDepth.Checked)
					{
						RB_MaxDepth.Checked = true;
					}
					break;
				case ActiveUnit_AI.SubmarineDepthPreset.Surface:
					if (!RB_Surface.Checked)
					{
						RB_Surface.Checked = true;
					}
					break;
				}
			}
			goto IL_5c72;
			IL_5c72:
			PostInterruptibleSchema();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.m_MapperRef.WPFControl_AltSpeed.Refresh(bool_0: true);
			managerRecord = true;
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception exception_4 = ex4;
			exception_4.Data.Add("Error at 200637", exception_4.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (GroupBox_Waypoint.Visible)
		{
			if (SpeedAlt_SelectedUnit != null && (SpeedAlt_SelectedUnit.IsShip || SpeedAlt_SelectedUnit.IsFacility))
			{
				GroupBox_Altitude.Visible = false;
				base.Height = FlowLayoutPanel_SettingsFor.Height + GroupBox_Speed.Height + 60 + GroupBox_Waypoint.Height;
			}
			else
			{
				GroupBox_Altitude.Visible = true;
				base.Height = FlowLayoutPanel_SettingsFor.Height + GroupBox_Speed.Height + GroupBox_Altitude.Height + 60 + GroupBox_Waypoint.Height;
			}
		}
		else if (SpeedAlt_SelectedUnit != null && (SpeedAlt_SelectedUnit.IsShip || SpeedAlt_SelectedUnit.IsFacility))
		{
			GroupBox_Altitude.Visible = false;
			base.Height = FlowLayoutPanel_SettingsFor.Height + GroupBox_Speed.Height + 60;
		}
		else
		{
			GroupBox_Altitude.Visible = true;
			base.Height = FlowLayoutPanel_SettingsFor.Height + GroupBox_Speed.Height + GroupBox_Altitude.Height + 60;
		}
	}

	private void PostInterruptibleSchema()
	{
		if (TrackBar_Altitude.Visible)
		{
			ActiveUnit activeUnit = SpeedAlt_SelectedUnit;
			if (activeUnit.IsGroup)
			{
				activeUnit = ((Group)activeUnit).GroupLead;
			}
			float num = activeUnit.GetLandElevation(bool_0: false, bool_1: true, bool_2: false, Client.CurrentScenario);
			Weather.WeatherProfile weatherAtThisTimeAndPlace = Weather.GetWeatherAtThisTimeAndPlace(activeUnit.ParentScen, activeUnit.GetLatitude(), activeUnit.GetLongitude(), (int)Math.Round(activeUnit.GetCurrentAltitude(bool_0: true)));
			int int_ = 0;
			int int_2 = 0;
			float float_ = 0f;
			SonarModel.GetThermalLayerAtThisLocation(activeUnit.GetLatitude(), activeUnit.GetLongitude(), (int)Math.Round(activeUnit.GetCurrentAltitude(bool_0: true)), ref int_, ref int_2, ref float_, bool_0: true, Client.CurrentScenario);
			double num12 = TrackBar_Altitude.Top + TrackBar_Altitude.Margin.Top + 10;
			double num16 = TrackBar_Altitude.Top + TrackBar_Altitude.Height - TrackBar_Altitude.Margin.Top - TrackBar_Altitude.Margin.Bottom - 7;
			double num17 = TrackBar_Altitude.Maximum;
			double num18 = TrackBar_Altitude.Minimum;
			double num19 = num17;
			double num20 = num18;
			double num21 = num12;
			double num22 = num16;
			if (activeUnit.UnitType == GlobalVariables.ActiveUnitType.Aircraft)
			{
				LineShape1.Visible = true;
				LineShape2.Visible = true;
				double num2;
				double a;
				if (num >= 0f && (double)num <= num17 && (double)num >= num18)
				{
					num2 = num;
					a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
					GroundLevelPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)GroundLevelPictureBox.Height / 2.0);
					GroundLevelPictureBox.Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num12), Math.Abs((double)(int)Math.Round(a) - num16)) <= 20.0)
					{
						Label10.Visible = false;
					}
					else
					{
						Label10.Visible = true;
						Label10.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)Label10.Height / 2.0 - 1.0);
						Label10.Text = "地面层";
					}
				}
				else
				{
					Label10.Visible = false;
					GroundLevelPictureBox.Visible = false;
				}
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				float num7 = (float)((double)weatherAtThisTimeAndPlace.FractionUnderRain - 0.001);
				if (weatherAtThisTimeAndPlace.FractionUnderRain == 0f)
				{
					num7 = 0f;
				}
				if ((double)num7 <= 0.9)
				{
					if ((double)num7 <= 0.8)
					{
						if ((double)num7 <= 0.7)
						{
							if ((double)num7 <= 0.6)
							{
								if ((double)num7 <= 0.5)
								{
									if ((double)num7 <= 0.4)
									{
										if ((double)num7 <= 0.3)
										{
											if ((double)num7 <= 0.2)
											{
												if ((double)num7 <= 0.1)
												{
													if ((double)num7 <= 0.0)
													{
														num3 = 0.0;
														num4 = 0.0;
														num5 = 0.0;
														num6 = 0.0;
														Label11.Text = "";
														Label12.Text = "";
														Label12.Text = "";
														Label13.Text = "";
													}
													else
													{
														num3 = 0.0;
														num4 = 0.0;
														num5 = 7000.0;
														num6 = 5000.0;
														Label11.Text = "";
														Label12.Text = "";
														Label13.Text = "少量云";
														Label14.Text = "少量云";
													}
												}
												else
												{
													num3 = 0.0;
													num4 = 0.0;
													num5 = 16000.0;
													num6 = 10000.0;
													Label11.Text = "";
													Label12.Text = "";
													Label13.Text = "少量云";
													Label14.Text = "少量云";
												}
											}
											else
											{
												num3 = 0.0;
												num4 = 0.0;
												num5 = 23000.0;
												num6 = 20000.0;
												Label11.Text = "";
												Label12.Text = "";
												Label13.Text = "少量云";
												Label14.Text = "少量云";
											}
										}
										else
										{
											num3 = 0.0;
											num4 = 0.0;
											num5 = 7000.0;
											num6 = 2000.0;
											Label11.Text = "";
											Label12.Text = "";
											Label13.Text = "中等云";
											Label14.Text = "中等云";
										}
									}
									else
									{
										num3 = 0.0;
										num4 = 0.0;
										num5 = 16000.0;
										num6 = 7000.0;
										Label11.Text = "";
										Label12.Text = "";
										Label13.Text = "中等云";
										Label14.Text = "中等云";
									}
								}
								else
								{
									num3 = 0.0;
									num4 = 0.0;
									num5 = 28000.0;
									num6 = 25000.0;
									Label11.Text = "";
									Label12.Text = "";
									Label13.Text = "中等云";
									Label14.Text = "中等云";
								}
							}
							else
							{
								num3 = 30000.0;
								num4 = 27000.0;
								num5 = 16000.0;
								num6 = 7000.0;
								Label11.Text = "少量云";
								Label12.Text = "少量云";
								Label13.Text = "中等云";
								Label14.Text = "中等云";
							}
						}
						else
						{
							num3 = 36000.0;
							num4 = 30000.0;
							num5 = 16000.0;
							num6 = 7000.0;
							Label11.Text = "中等云";
							Label12.Text = "中等云";
							Label13.Text = "大量云";
							Label14.Text = "大量云";
						}
					}
					else
					{
						num3 = 36000.0;
						num4 = 7000.0;
						num5 = 2000.0;
						num6 = 1.0;
						Label11.Text = "大量云";
						Label12.Text = "大量云";
						Label13.Text = "薄雾";
						Label14.Text = "薄雾";
					}
				}
				else
				{
					num3 = 36000.0;
					num4 = 7000.0;
					num5 = 2000.0;
					num6 = 1.0;
					Label11.Text = "大量云";
					Label12.Text = "大量云";
					Label13.Text = "浓雾";
					Label14.Text = "浓雾";
				}
				double num8 = num3 / 3.2808399200439453;
				double num9 = num4 / 3.2808399200439453;
				double num10 = num5 / 3.2808399200439453;
				double num11 = num6 / 3.2808399200439453;
				num2 = num8;
				a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
				LineShape1.Y1 = (int)Math.Round(a - (double)CloudHighTopPictureBox.Height);
				num2 = num9;
				a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
				LineShape1.Y2 = (int)Math.Round(a - (double)CloudHighBottomPictureBox.Height);
				num2 = num10;
				a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
				LineShape2.Y1 = (int)Math.Round(a - (double)CloudLowTopPictureBox.Height);
				num2 = num11;
				a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
				LineShape2.Y2 = (int)Math.Round(a - (double)CloudLowBottomPictureBox.Height);
				if (num8 != 0.0 && num8 >= (double)num && num8 <= num17 && num8 >= num18)
				{
					num2 = num8;
					a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
					CloudHighTopPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)CloudHighTopPictureBox.Height / 2.0);
					CloudHighTopPictureBox.Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num12), Math.Abs((double)(int)Math.Round(a) - num16)) <= 20.0)
					{
						Label11.Visible = false;
					}
					else
					{
						Label11.Visible = true;
						Label11.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)Label11.Height / 2.0 - 1.0);
					}
				}
				else
				{
					CloudHighTopPictureBox.Visible = false;
					Label11.Visible = false;
				}
				if (num9 != 0.0 && num9 >= (double)num && num9 <= num17 && num9 >= num18)
				{
					num2 = num9;
					a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
					CloudHighBottomPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)CloudHighBottomPictureBox.Height / 2.0);
					CloudHighBottomPictureBox.Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num12), Math.Abs((double)(int)Math.Round(a) - num16)) <= 20.0)
					{
						Label12.Visible = false;
					}
					else
					{
						Label12.Visible = true;
						Label12.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)Label12.Height / 2.0 - 1.0);
					}
				}
				else
				{
					CloudHighBottomPictureBox.Visible = false;
					Label12.Visible = false;
				}
				if (num10 != 0.0 && num10 >= (double)num && num10 <= num17 && num10 >= num18)
				{
					num2 = num10;
					a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
					CloudLowTopPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)CloudLowTopPictureBox.Height / 2.0);
					CloudLowTopPictureBox.Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num12), Math.Abs((double)(int)Math.Round(a) - num16)) <= 20.0)
					{
						Label13.Visible = false;
					}
					else
					{
						Label13.Visible = true;
						Label13.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)Label11.Height / 2.0 - 1.0);
					}
				}
				else
				{
					CloudLowTopPictureBox.Visible = false;
					Label13.Visible = false;
				}
				if (num11 != 0.0 && num11 >= (double)num && num11 <= num17 && num11 >= num18)
				{
					num2 = num11;
					a = num21 + (num22 - num21) * ((num2 - num19) / (num20 - num19));
					CloudLowBottomPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)CloudLowBottomPictureBox.Height / 2.0);
					CloudLowBottomPictureBox.Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a) - num12), Math.Abs((double)(int)Math.Round(a) - num16)) <= 20.0)
					{
						Label14.Visible = false;
					}
					else
					{
						Label14.Visible = true;
						Label14.Top = (int)Math.Round((double)(int)Math.Round(a) - (double)Label14.Height / 2.0 - 1.0);
					}
				}
				else
				{
					CloudLowBottomPictureBox.Visible = false;
					Label14.Visible = false;
				}
			}
			else
			{
				CloudHighBottomPictureBox.Visible = false;
				CloudHighTopPictureBox.Visible = false;
				CloudLowBottomPictureBox.Visible = false;
				CloudLowTopPictureBox.Visible = false;
				GroundLevelPictureBox.Visible = false;
				LineShape1.Visible = false;
				LineShape2.Visible = false;
				Label11.Visible = false;
				Label12.Visible = false;
				Label10.Visible = false;
				Label13.Visible = false;
				Label14.Visible = false;
			}
			if (activeUnit.UnitType != GlobalVariables.ActiveUnitType.Submarine && (activeUnit.UnitType != GlobalVariables.ActiveUnitType.Weapon || !activeUnit.IsTorpedo))
			{
				SeaFloorPictureBox.Visible = false;
				LayerTopPictureBox.Visible = false;
				LayerBottomPictureBox.Visible = false;
				Label7.Visible = false;
				Label8.Visible = false;
				Label9.Visible = false;
				return;
			}
			if (float_ == 0f)
			{
				LayerTopPictureBox.Visible = false;
				LayerBottomPictureBox.Visible = false;
				Label7.Visible = false;
				Label8.Visible = false;
			}
			else
			{
				if ((float)int_ >= num && (double)int_ <= num17 && (double)int_ >= num18)
				{
					double num13 = int_;
					double a2 = num21 + (num22 - num21) * ((num13 - num19) / (num20 - num19));
					LayerTopPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a2) - (double)LayerTopPictureBox.Height / 2.0);
					LayerTopPictureBox.Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a2) - num12), Math.Abs((double)(int)Math.Round(a2) - num16)) <= 20.0)
					{
						Label7.Visible = false;
					}
					else
					{
						Label7.Visible = true;
						Label7.Top = (int)Math.Round((double)(int)Math.Round(a2) - (double)Label7.Height / 2.0 - 1.0);
						Label7.Text = "温跃层上限";
					}
				}
				else
				{
					LayerTopPictureBox.Visible = false;
					Label7.Visible = false;
				}
				if ((float)int_2 >= num && (double)int_2 <= num17 && (double)int_2 >= num18)
				{
					double num14 = int_2;
					double a3 = num21 + (num22 - num21) * ((num14 - num19) / (num20 - num19));
					LayerBottomPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a3) - (double)LayerBottomPictureBox.Height / 2.0);
					LayerBottomPictureBox.Visible = true;
					if (Math.Min(Math.Abs((double)(int)Math.Round(a3) - num12), Math.Abs((double)(int)Math.Round(a3) - num16)) <= 20.0)
					{
						Label8.Visible = false;
					}
					else
					{
						Label8.Visible = true;
						Label8.Top = (int)Math.Round((double)(int)Math.Round(a3) - (double)Label8.Height / 2.0 - 1.0);
						Label8.Text = "温跃层下限";
					}
				}
				else
				{
					LayerBottomPictureBox.Visible = false;
					Label8.Visible = false;
				}
			}
			if ((double)num >= num18 && (double)num <= num17 && (double)num >= num18)
			{
				double num15 = num;
				double a4 = num21 + (num22 - num21) * ((num15 - num19) / (num20 - num19));
				SeaFloorPictureBox.Top = (int)Math.Round((double)(int)Math.Round(a4) - (double)SeaFloorPictureBox.Height / 2.0);
				SeaFloorPictureBox.Visible = true;
				if (Math.Min(Math.Abs((double)(int)Math.Round(a4) - num12), Math.Abs((double)(int)Math.Round(a4) - num16)) <= 20.0)
				{
					Label9.Visible = false;
					return;
				}
				Label9.Visible = true;
				Label9.Top = (int)Math.Round((double)(int)Math.Round(a4) - (double)Label9.Height / 2.0 - 1.0);
				Label9.Text = "海底";
			}
			else
			{
				SeaFloorPictureBox.Visible = false;
				Label9.Visible = false;
			}
		}
		else
		{
			CloudHighBottomPictureBox.Visible = false;
			CloudHighTopPictureBox.Visible = false;
			CloudLowBottomPictureBox.Visible = false;
			CloudLowTopPictureBox.Visible = false;
			GroundLevelPictureBox.Visible = false;
			LineShape1.Visible = false;
			LineShape2.Visible = false;
			Label11.Visible = false;
			Label12.Visible = false;
			Label10.Visible = false;
			Label13.Visible = false;
			Label14.Visible = false;
			SeaFloorPictureBox.Visible = false;
			LayerTopPictureBox.Visible = false;
			LayerBottomPictureBox.Visible = false;
			Label7.Visible = false;
			Label8.Visible = false;
			Label9.Visible = false;
		}
	}

	private string RunInterruptibleSchema()
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit))
		{
			return "-";
		}
		switch (SpeedAlt_SelectedUnit.ThrottleSetting)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return SpeedAlt_SelectedUnit.ThrottleSetting.ToString();
		case ActiveUnit.Throttle.FullStop:
			return "完全停止";
		case ActiveUnit.Throttle.Loiter:
			if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
			{
				return "Loiter";
			}
			return "Creep";
		case ActiveUnit.Throttle.Cruise:
			return "Cruise";
		case ActiveUnit.Throttle.Full:
			if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
			{
				return "Military";
			}
			return "Full";
		case ActiveUnit.Throttle.Flank:
			if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
			{
				return "Afterburner";
			}
			return "Flank";
		}
	}

	private void StartInterruptibleSchema(object sender, EventArgs e)
	{
		RefreshForm();
	}

	private void AssetInterruptibleSchema(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit) || !managerRecord || !RB_Stop.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			Client.SelectedWaypoint.DesiredSpeed = null;
			Client.SelectedWaypoint.DesiredSpeedOverride = null;
			Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
				SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
				TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
				SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
		}
		else if (DefineInterruptibleSchema(ref SpeedAlt_FlightPlanWaypoint))
		{
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.FullStop;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
			Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			speedAlt_Flight2.FlightPlan = waypoint_;
			Client.MustRefreshMainForm = true;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		else
		{
			RB_Stop.Checked = false;
		}
	}

	private void PrintInterruptibleSchema(object sender, EventArgs e)
	{
		if (!managerRecord || !RB_Creep.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
			Client.SelectedWaypoint.DesiredSpeed = null;
			Client.SelectedWaypoint.DesiredSpeedOverride = null;
			Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
				SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
				if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) <= (float)TrackBar_Throttle.Maximum)
				{
					TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
				}
				else
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
				SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
		}
		else if (DefineInterruptibleSchema(ref SpeedAlt_FlightPlanWaypoint))
		{
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
			Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			speedAlt_Flight2.FlightPlan = waypoint_;
			Client.MustRefreshMainForm = true;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		else
		{
			RB_Creep.Checked = false;
		}
	}

	private bool DefineInterruptibleSchema(ref Waypoint waypoint_0)
	{
		if (waypoint_0.Category == Waypoint.WaypointCategory.FlightPlan)
		{
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i++)
			{
				foreach (Mission mission in sides_ReadOnly[i].Missions)
				{
					foreach (Mission.Flight flight in mission.FlightList)
					{
						if (flight.FlightPlan.Contains(waypoint_0) && flight.ReferenceUnit_DBID == 0)
						{
							DarkMessageBox.ShowWarning("没有设置飞机类型的飞行计划的航路点不能使用油门预设，只能使用固定速度。", string.Empty);
							return false;
						}
					}
				}
			}
		}
		return true;
	}

	private void PublishInterruptibleSchema(object sender, EventArgs e)
	{
		if (!managerRecord || !RB_Cruise.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
			Client.SelectedWaypoint.DesiredSpeed = null;
			Client.SelectedWaypoint.DesiredSpeedOverride = null;
			Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
				SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
				if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) <= (float)TrackBar_Throttle.Maximum)
				{
					TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
				}
				else
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
			}
		}
		else if (DefineInterruptibleSchema(ref SpeedAlt_FlightPlanWaypoint))
		{
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
			Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			speedAlt_Flight2.FlightPlan = waypoint_;
			Client.MustRefreshMainForm = true;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		else
		{
			RB_Cruise.Checked = false;
		}
	}

	private void AwakeInterruptibleSchema(object sender, EventArgs e)
	{
		if (!managerRecord || !RB_Full.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Full;
			Client.SelectedWaypoint.DesiredSpeed = null;
			Client.SelectedWaypoint.DesiredSpeedOverride = null;
			Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Full;
				SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
				if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) <= (float)TrackBar_Throttle.Maximum)
				{
					TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
				}
				else
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
				SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
		}
		else if (DefineInterruptibleSchema(ref SpeedAlt_FlightPlanWaypoint))
		{
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Full;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
			Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			speedAlt_Flight2.FlightPlan = waypoint_;
			Client.MustRefreshMainForm = true;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		else
		{
			RB_Full.Checked = false;
		}
	}

	private void QueryInterruptibleSchema(object sender, EventArgs e)
	{
		if (!managerRecord || !RB_NoThrottlePreset.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			Client.SelectedWaypoint.DesiredSpeed = null;
			Client.SelectedWaypoint.DesiredSpeedOverride = null;
			Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else
		{
			if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				return;
			}
			if (DefineInterruptibleSchema(ref SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
				SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Free;
				Scenario currentScenario = Client.CurrentScenario;
				Mission speedAlt_Mission = SpeedAlt_Mission;
				ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
				Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
				Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
				Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
				float float_ = 0f;
				float float_2 = 0f;
				MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
				speedAlt_Flight2.FlightPlan = waypoint_;
				Client.MustRefreshMainForm = true;
				if (Client.FlightPlanEditorWindow.Visible)
				{
					Client.FlightPlanEditorWindow.InvokePolicy();
					Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
				}
			}
			else
			{
				RB_NoThrottlePreset.Checked = false;
			}
		}
	}

	private void ResetInterruptibleSchema(object sender, EventArgs e)
	{
		if (!managerRecord || !RB_Flank.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Flank;
			Client.SelectedWaypoint.DesiredSpeed = null;
			Client.SelectedWaypoint.DesiredSpeedOverride = null;
			Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Flank;
				SpeedAlt_SelectedUnit.Kinematics.FollowSpeedPreset();
				if (Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum) <= (float)TrackBar_Throttle.Maximum)
				{
					TrackBar_Throttle.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredSpeed, TrackBar_Throttle.Minimum));
				}
				else
				{
					TrackBar_Throttle.Value = TrackBar_Throttle.Maximum;
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
				SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
		}
		else if (DefineInterruptibleSchema(ref SpeedAlt_FlightPlanWaypoint))
		{
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Flank;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
			Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			speedAlt_Flight2.FlightPlan = waypoint_;
			Client.MustRefreshMainForm = true;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		else
		{
			RB_Flank.Checked = false;
		}
	}

	private void MapInterruptibleSchema(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit))
		{
			return;
		}
		if (SpeedAlt_SelectedUnit.Navigator.SprintDrift)
		{
			if (SpeedAlt_SelectedUnit.Navigator.AvoidCavitation)
			{
				SpeedAlt_SelectedUnit.DesiredSpeed = TrackBar_Throttle.Value;
				SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
			else
			{
				SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed = TrackBar_Throttle.Value;
			}
			SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = null;
		}
		else
		{
			SpeedAlt_SelectedUnit.DesiredSpeed = TrackBar_Throttle.Value;
			SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = TrackBar_Throttle.Value;
		}
		RateInterruptibleSchema();
		SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void SortInterruptibleSchema(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SpeedAlt_SelectedUnit))
		{
			SpeedAlt_SelectedUnit.DesiredAltitude = TrackBar_Altitude.Value;
			CalcInterruptibleSchema();
			SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
		}
	}

	internal void CalcInterruptibleSchema(bool bool_0 = false)
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) & Information.IsNothing(Client.SelectedWaypoint)) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			return;
		}
		if (SpeedAlt_SelectedUnit == null && SpeedAlt_FlightPlanWaypoint == null)
		{
			Module_Unit.Unit selectedUnit = Client.SelectedUnit;
			if (selectedUnit != null && selectedUnit.IsActiveUnit)
			{
				SpeedAlt_SelectedUnit = (ActiveUnit)Client.SelectedUnit;
			}
		}
		if (bool_0 && SpeedAlt_SelectedUnit != null)
		{
			if (Information.IsNothing(Client.SelectedWaypoint))
			{
				if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
				{
					if (RB_MaxAltitude.Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
					}
					if (RB_HighAltitude36000.Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
					}
					if (RB_HighAltitude25000.Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
					}
					if (RB_MediumAltitude12000.Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
					}
					if (RB_LowAltitude2000.Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
					}
					if (RB_LowAltitude1000.Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
					}
					if (RB_MinAltitude.Checked)
					{
						Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
					}
					SpeedAlt_FlightPlanWaypoint.DesiredAltitudeOverride = false;
				}
			}
			else if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
			{
				if (RB_MaxAltitude.Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
				}
				if (RB_HighAltitude36000.Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
				}
				if (RB_HighAltitude25000.Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
				}
				if (RB_MediumAltitude12000.Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
				}
				if (RB_LowAltitude2000.Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
				}
				if (RB_LowAltitude1000.Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
				}
				if (RB_MinAltitude.Checked)
				{
					Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
				}
				Client.SelectedWaypoint.FollowAltitudePreset();
			}
			else if (SpeedAlt_SelectedUnit.UseSubmerisbleUnitUI)
			{
				if (RB_Surface.Checked)
				{
					Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
				}
				if (RB_Periscope.Checked)
				{
					Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
				}
				if (RB_Shallow.Checked)
				{
					Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
				}
				if (RB_OverLayer.Checked)
				{
					Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
				}
				if (RB_UnderLayer.Checked)
				{
					Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
				}
				if (RB_MaxDepth.Checked)
				{
					Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
				}
				Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
				if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
				{
					Client.SelectedWaypoint.DesiredAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
				}
			}
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DesiredAltitudeOverride = true;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride = true;
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DesiredAltitudeOverride = true;
		}
		if (!Information.IsNothing(SpeedAlt_SelectedUnit))
		{
			SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
		}
		CB_AltOverride.Checked = true;
		if (!Information.IsNothing(SpeedAlt_SelectedUnit))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
		}
	}

	internal void RateInterruptibleSchema()
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) & Information.IsNothing(Client.SelectedWaypoint)) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (Client.SelectedWaypoint.SprintDrift.GetValueOrDefault())
			{
				Client.SelectedWaypoint.DesiredSpeedOverride = null;
				Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Free;
			}
			else
			{
				Client.SelectedWaypoint.DesiredSpeedOverride = Client.SelectedWaypoint.DesiredSpeed;
				Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			}
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.Navigator.SprintDrift)
				{
					SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = null;
				}
				else
				{
					SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
				}
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = SpeedAlt_FlightPlanWaypoint.DesiredSpeed;
			SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
			Scenario currentScenario = Client.CurrentScenario;
			Mission speedAlt_Mission = SpeedAlt_Mission;
			ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
			Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
			Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
			Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
			float float_ = 0f;
			float float_2 = 0f;
			MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
			speedAlt_Flight2.FlightPlan = waypoint_;
			Client.MustRefreshMainForm = true;
			if (Client.FlightPlanEditorWindow.Visible)
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
				Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
			}
		}
		FlushInterruptibleSchema();
		if (!Information.IsNothing(SpeedAlt_SelectedUnit))
		{
			SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
		}
		CB_SpeedOverride.Checked = true;
		if (!Information.IsNothing(SpeedAlt_SelectedUnit))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
		}
	}

	private void FlushInterruptibleSchema()
	{
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				SpeedAlt_SelectedUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
		}
		RB_Stop.Checked = false;
		RB_Creep.Checked = false;
		RB_Cruise.Checked = false;
		RB_Full.Checked = false;
		RB_Flank.Checked = false;
	}

	private void ForgotInterruptibleSchema()
	{
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
			RB_Surface.Checked = false;
			RB_Periscope.Checked = false;
			RB_Shallow.Checked = false;
			RB_OverLayer.Checked = false;
			RB_UnderLayer.Checked = false;
			RB_MaxDepth.Checked = false;
			RB_MaxAltitude.Checked = false;
			RB_HighAltitude36000.Checked = false;
			RB_HighAltitude25000.Checked = false;
			RB_MediumAltitude12000.Checked = false;
			RB_LowAltitude2000.Checked = false;
			RB_LowAltitude1000.Checked = false;
			RB_MinAltitude.Checked = false;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				return;
			}
			if (SpeedAlt_SelectedUnit.UseSubmerisbleUnitUI)
			{
				if (SpeedAlt_SelectedUnit.IsSubmarine)
				{
					((Submarine_AI)SpeedAlt_SelectedUnit.AI).DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				}
				else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)
				{
					((Group_AI)SpeedAlt_SelectedUnit.AI).DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				}
				RB_Surface.Checked = false;
				RB_Periscope.Checked = false;
				RB_Shallow.Checked = false;
				RB_OverLayer.Checked = false;
				RB_UnderLayer.Checked = false;
				RB_MaxDepth.Checked = false;
			}
			if (SpeedAlt_SelectedUnit.UseAerialUnitUI)
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					((Aircraft_AI)SpeedAlt_SelectedUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				}
				else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
				{
					((Group_AI)SpeedAlt_SelectedUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				}
				RB_MaxAltitude.Checked = false;
				RB_HighAltitude36000.Checked = false;
				RB_HighAltitude25000.Checked = false;
				RB_MediumAltitude12000.Checked = false;
				RB_LowAltitude2000.Checked = false;
				RB_LowAltitude1000.Checked = false;
				RB_MinAltitude.Checked = false;
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
			RB_Surface.Checked = false;
			RB_Periscope.Checked = false;
			RB_Shallow.Checked = false;
			RB_OverLayer.Checked = false;
			RB_UnderLayer.Checked = false;
			RB_MaxDepth.Checked = false;
			RB_MaxAltitude.Checked = false;
			RB_HighAltitude36000.Checked = false;
			RB_HighAltitude25000.Checked = false;
			RB_MediumAltitude12000.Checked = false;
			RB_LowAltitude2000.Checked = false;
			RB_LowAltitude1000.Checked = false;
			RB_MinAltitude.Checked = false;
		}
	}

	private void CollectInterruptibleSchema(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit) || !managerRecord || (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup)) || !RB_Surface.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
			Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsSubmarine)
				{
					Submarine_AI obj = (Submarine_AI)SpeedAlt_SelectedUnit.AI;
					obj.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
					obj.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj2 = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj2.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
					obj2.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
			SpeedAlt_FlightPlanWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void OrderInterruptibleSchema(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit) || !managerRecord || (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup)) || !RB_Periscope.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
			Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsSubmarine)
				{
					Submarine_AI obj = (Submarine_AI)SpeedAlt_SelectedUnit.AI;
					obj.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
					obj.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj2 = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj2.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
					obj2.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
			SpeedAlt_FlightPlanWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void RegisterInterruptibleSchema(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit) || !managerRecord || (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup)) || !RB_Shallow.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
			Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsSubmarine)
				{
					Submarine_AI obj = (Submarine_AI)SpeedAlt_SelectedUnit.AI;
					obj.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
					obj.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj2 = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj2.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
					obj2.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
			SpeedAlt_FlightPlanWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void ManageInterruptibleSchema(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit) || !managerRecord || (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup)) || !RB_OverLayer.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
			Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsSubmarine)
				{
					Submarine_AI obj = (Submarine_AI)SpeedAlt_SelectedUnit.AI;
					obj.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
					obj.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj2 = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj2.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
					obj2.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
			SpeedAlt_FlightPlanWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void RevertInterruptibleSchema(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit) || !managerRecord || (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup)) || !RB_UnderLayer.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
			Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsSubmarine)
				{
					Submarine_AI obj = (Submarine_AI)SpeedAlt_SelectedUnit.AI;
					obj.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
					obj.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj2 = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj2.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
					obj2.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
			SpeedAlt_FlightPlanWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void CountInterruptibleUtils(object sender, EventArgs e)
	{
		if (Information.IsNothing(SpeedAlt_SelectedUnit) || !managerRecord || (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !SpeedAlt_SelectedUnit.IsSubmarine && (!SpeedAlt_SelectedUnit.IsGroup || ((Group)SpeedAlt_SelectedUnit).Type != Group.GroupType.SubGroup)) || !RB_MaxDepth.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
			Client.SelectedWaypoint.FollowDepthPreset(Client.CurrentScenario);
			if (Client.SelectedWaypoint.DepthPreset == ActiveUnit_AI.SubmarineDepthPreset.MaxDepth)
			{
				Client.SelectedWaypoint.DesiredAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
			}
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsSubmarine)
				{
					Submarine_AI obj = (Submarine_AI)SpeedAlt_SelectedUnit.AI;
					obj.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
					obj.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj2 = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj2.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
					obj2.FollowDepthPreset(bool_0: false);
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.MaxDepth;
			SpeedAlt_FlightPlanWaypoint.FollowDepthPreset(Client.CurrentScenario);
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void CustomizeInterruptibleUtils(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SpeedAlt_SelectedUnit) && managerRecord && (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint) || SpeedAlt_SelectedUnit.IsSubmarine || (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.SubGroup)) && RB_NoDepthPreset.Checked)
		{
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				Client.SelectedWaypoint.DesiredAltitude = null;
				Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
			else if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_FlightPlanWaypoint.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude = null;
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
		}
	}

	private void CloneInterruptibleUtils(object sender, EventArgs e)
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) || !managerRecord || (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.SupportsAltitude_Control) || !RB_MaxAltitude.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
			Client.SelectedWaypoint.DesiredAltitude = null;
			Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = null;
			if (SpeedAlt_SelectedUnit.IsWeapon)
			{
				Client.SelectedWaypoint.DesiredAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMaximumAltitude();
			}
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					Aircraft_AI aI = ((Aircraft)SpeedAlt_SelectedUnit).AI;
					aI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
					aI.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
					obj.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsWeapon)
				{
					SpeedAlt_SelectedUnit.DesiredAltitude = TrackBar_Altitude.Maximum;
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
			SpeedAlt_FlightPlanWaypoint.DesiredAltitude = null;
			SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = null;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void ConnectInterruptibleUtils(object sender, EventArgs e)
	{
		if ((!Information.IsNothing(SpeedAlt_SelectedUnit) || !Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) && managerRecord && (SpeedAlt_FlightPlanWaypoint != null || SpeedAlt_SelectedUnit.SupportsAltitude_Control) && RB_NoAltitudePreset.Checked)
		{
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				Client.SelectedWaypoint.DesiredAltitude = null;
				Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
			else if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude = null;
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
		}
	}

	private void MoveInterruptibleUtils(object sender, EventArgs e)
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) || !managerRecord || (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.SupportsAltitude_Control) || !RB_HighAltitude36000.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
			Client.SelectedWaypoint.FollowAltitudePreset();
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					Aircraft_AI aI = ((Aircraft)SpeedAlt_SelectedUnit).AI;
					aI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
					aI.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					_ = (Group_AI)SpeedAlt_SelectedUnit.AI;
					((Group_AI)SpeedAlt_SelectedUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
					((Group_AI)SpeedAlt_SelectedUnit.AI).FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsWeapon)
				{
					SpeedAlt_SelectedUnit.DesiredAltitude = 10972.8f;
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_6;
			SpeedAlt_FlightPlanWaypoint.FollowAltitudePreset();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void DeleteInterruptibleUtils(object sender, EventArgs e)
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) || !managerRecord || (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.SupportsAltitude_Control) || !RB_HighAltitude25000.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
			Client.SelectedWaypoint.FollowAltitudePreset();
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					Aircraft_AI aI = ((Aircraft)SpeedAlt_SelectedUnit).AI;
					aI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
					aI.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					_ = (Group_AI)SpeedAlt_SelectedUnit.AI;
					((Group_AI)SpeedAlt_SelectedUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
					((Group_AI)SpeedAlt_SelectedUnit.AI).FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsWeapon)
				{
					SpeedAlt_SelectedUnit.DesiredAltitude = 7620f;
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
			SpeedAlt_FlightPlanWaypoint.FollowAltitudePreset();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void AddInterruptibleUtils(object sender, EventArgs e)
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) || !managerRecord || (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.SupportsAltitude_Control) || !RB_MediumAltitude12000.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
			Client.SelectedWaypoint.FollowAltitudePreset();
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					Aircraft_AI aI = ((Aircraft)SpeedAlt_SelectedUnit).AI;
					aI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
					aI.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					_ = (Group_AI)SpeedAlt_SelectedUnit.AI;
					((Group_AI)SpeedAlt_SelectedUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
					((Group_AI)SpeedAlt_SelectedUnit.AI).FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsWeapon)
				{
					SpeedAlt_SelectedUnit.DesiredAltitude = 3657.6f;
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
			SpeedAlt_FlightPlanWaypoint.FollowAltitudePreset();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void DestroyInterruptibleUtils(object sender, EventArgs e)
	{
		if ((SpeedAlt_SelectedUnit == null && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) || !managerRecord || (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.SupportsAltitude_Control) || !RB_LowAltitude2000.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
			Client.SelectedWaypoint.FollowAltitudePreset();
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					Aircraft_AI aI = ((Aircraft)SpeedAlt_SelectedUnit).AI;
					aI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
					aI.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					_ = (Group_AI)SpeedAlt_SelectedUnit.AI;
					((Group_AI)SpeedAlt_SelectedUnit.AI).AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
					((Group_AI)SpeedAlt_SelectedUnit.AI).FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsWeapon)
				{
					SpeedAlt_SelectedUnit.DesiredAltitude = 609.60004f;
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
			SpeedAlt_FlightPlanWaypoint.FollowAltitudePreset();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void ComputeInterruptibleUtils(object sender, EventArgs e)
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) || !managerRecord || (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.SupportsAltitude_Control) || !RB_LowAltitude1000.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
			Client.SelectedWaypoint.FollowAltitudePreset();
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					Aircraft_AI aI = ((Aircraft)SpeedAlt_SelectedUnit).AI;
					aI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
					aI.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
					obj.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsWeapon)
				{
					SpeedAlt_SelectedUnit.DesiredAltitude = 304.80002f;
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low1000;
			SpeedAlt_FlightPlanWaypoint.FollowAltitudePreset();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void PatchInterruptibleUtils(object sender, EventArgs e)
	{
		if ((Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) || !managerRecord || (SpeedAlt_FlightPlanWaypoint == null && !SpeedAlt_SelectedUnit.SupportsAltitude_Control) || !RB_MinAltitude.Checked)
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
			Client.SelectedWaypoint.FollowAltitudePreset();
			if (SpeedAlt_SelectedUnit.IsWeapon)
			{
				Weapon weapon = (Weapon)SpeedAlt_SelectedUnit;
				if (weapon.MinimumSafeHeight.HasValue)
				{
					Client.SelectedWaypoint.DesiredAltitude = weapon.MinimumSafeHeight.Value;
				}
				else
				{
					Client.SelectedWaypoint.DesiredAltitude = TrackBar_Altitude.Minimum;
				}
			}
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				if (SpeedAlt_SelectedUnit.IsAircraft)
				{
					Aircraft_AI aI = ((Aircraft)SpeedAlt_SelectedUnit).AI;
					aI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
					aI.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group_AI obj = (Group_AI)SpeedAlt_SelectedUnit.AI;
					obj.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
					obj.FollowAltitudePreset();
					TrackBar_Altitude.Value = (int)Math.Round(Math.Max(SpeedAlt_SelectedUnit.DesiredAltitude, TrackBar_Altitude.Minimum));
				}
				else if (SpeedAlt_SelectedUnit.IsWeapon)
				{
					Weapon weapon2 = (Weapon)SpeedAlt_SelectedUnit;
					if (weapon2.MinimumSafeHeight.HasValue)
					{
						SpeedAlt_SelectedUnit.DesiredAltitude = weapon2.MinimumSafeHeight.Value;
					}
					else
					{
						SpeedAlt_SelectedUnit.DesiredAltitude = TrackBar_Altitude.Minimum;
					}
					TrackBar_Altitude.Value = (int)Math.Round(SpeedAlt_SelectedUnit.DesiredAltitude);
				}
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
			SpeedAlt_FlightPlanWaypoint.FollowAltitudePreset();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	private void SelectInterruptibleUtils(object sender, EventArgs e)
	{
		m_InfoRecord = true;
	}

	private void CallInterruptibleUtils(object sender, EventArgs e)
	{
		ViewInterruptibleUtils();
	}

	private void LogoutInterruptibleUtils(object sender, EventArgs e)
	{
		helperRecord = true;
	}

	private void ViewInterruptibleUtils()
	{
		if (m_InfoRecord)
		{
			FlushInterruptibleSchema();
			if (!Information.IsNothing(Client.SelectedWaypoint) && Client.SelectedWaypoint.SprintDrift.GetValueOrDefault())
			{
				if (Versioned.IsNumeric(TextBox_EnterSpeed.Text))
				{
					Client.SelectedWaypoint.SprintDrift_AverageSpeed = Conversions.ToSingle(TextBox_EnterSpeed.Text);
					Client.SelectedWaypoint.DesiredSpeedOverride = null;
				}
			}
			else if (Information.IsNothing(Client.SelectedWaypoint) && !Information.IsNothing(SpeedAlt_SelectedUnit) && SpeedAlt_SelectedUnit.Navigator.SprintDrift)
			{
				if (Versioned.IsNumeric(TextBox_EnterSpeed.Text))
				{
					if (SpeedAlt_SelectedUnit.Navigator.AvoidCavitation)
					{
						SpeedAlt_SelectedUnit.DesiredSpeed = Conversions.ToSingle(TextBox_EnterSpeed.Text);
						SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed = SpeedAlt_SelectedUnit.DesiredSpeed;
					}
					else
					{
						SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed = Conversions.ToSingle(TextBox_EnterSpeed.Text);
					}
					SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = null;
				}
			}
			else if (Operators.CompareString(TextBox_EnterSpeed.Text, "", TextCompare: true) == 0 && !Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.DesiredSpeedOverride = null;
				Client.SelectedWaypoint.DesiredSpeed = null;
				CB_SpeedOverride.Checked = false;
				Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				FlushInterruptibleSchema();
			}
			else if (Operators.CompareString(TextBox_EnterSpeed.Text, "", TextCompare: true) == 0 && !Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
				CB_SpeedOverride.Checked = false;
				SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				FlushInterruptibleSchema();
			}
			else if ((Versioned.IsNumeric(TextBox_EnterSpeed.Text) || Information.IsNothing(Client.SelectedWaypoint) || !Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) && (Versioned.IsNumeric(TextBox_EnterSpeed.Text) || Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) && ((Operators.CompareString(TextBox_EnterSpeed.Text, "", TextCompare: true) != 0) & Versioned.IsNumeric(TextBox_EnterSpeed.Text)))
			{
				int num = Conversions.ToInteger(TextBox_EnterSpeed.Text);
				if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
				{
					Client.SelectedWaypoint.DesiredSpeed = num;
					Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				}
				else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
				{
					if (!Information.IsNothing(SpeedAlt_SelectedUnit))
					{
						if (num > Math.Max(SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), SpeedAlt_SelectedUnit.MaxPossibleThrottleSetting, bool_0: false), SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.DesiredAltitude)))
						{
							num = Math.Max(SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), SpeedAlt_SelectedUnit.MaxPossibleThrottleSetting, bool_0: false), SpeedAlt_SelectedUnit.Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.DesiredAltitude));
						}
						if (SpeedAlt_SelectedUnit.IsAircraft)
						{
							if (!((Aircraft)SpeedAlt_SelectedUnit).GetCanHover(bool_1: false) && num < ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false))
							{
								num = ((Aircraft)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
							}
						}
						else if (SpeedAlt_SelectedUnit.IsWeapon)
						{
							if (num < ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false))
							{
								num = ((Weapon)SpeedAlt_SelectedUnit).Kinematics.GetMaximumSpeed(SpeedAlt_SelectedUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Cruise, bool_0: false);
							}
						}
						else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
						{
							if (Information.IsNothing(((Group)SpeedAlt_SelectedUnit).GroupLead))
							{
								return;
							}
							Aircraft aircraft = (Aircraft)((Group)SpeedAlt_SelectedUnit).GroupLead;
							if (!aircraft.GetCanHover(bool_1: false) && num < aircraft.Kinematics.GetMaximumSpeed(aircraft.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false))
							{
								num = aircraft.Kinematics.GetMaximumSpeed(aircraft.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false);
							}
						}
						else if (num < (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.GetCurrentAltitude(), bool_0: false)))
						{
							num = (int)Math.Round(SpeedAlt_SelectedUnit.Kinematics.GetMinimumSpeed_Total(SpeedAlt_SelectedUnit.GetCurrentAltitude(), bool_0: false));
						}
						SpeedAlt_SelectedUnit.DesiredSpeed = num;
					}
				}
				else
				{
					SpeedAlt_FlightPlanWaypoint.DesiredSpeed = num;
					SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
				}
				RateInterruptibleSchema();
			}
		}
		m_InfoRecord = false;
		RefreshForm();
	}

	private void ValidateInterruptibleUtils(object sender, EventArgs e)
	{
		LoginInterruptibleUtils();
	}

	private void LoginInterruptibleUtils()
	{
		if (helperRecord)
		{
			ForgotInterruptibleSchema();
			if (Operators.CompareString(TextBox_EnterAltitude.Text, "", TextCompare: true) == 0 && !Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.DesiredAltitudeOverride = false;
				Client.SelectedWaypoint.DesiredAltitude = null;
				Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
			else if (Operators.CompareString(TextBox_EnterAltitude.Text, "", TextCompare: true) == 0 && !Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_FlightPlanWaypoint.DesiredAltitudeOverride = false;
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude = null;
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
			else if ((Versioned.IsNumeric(TextBox_EnterAltitude.Text) || Information.IsNothing(Client.SelectedWaypoint) || !Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) && (Versioned.IsNumeric(TextBox_EnterAltitude.Text) || Information.IsNothing(SpeedAlt_FlightPlanWaypoint)) && ((Operators.CompareString(TextBox_EnterAltitude.Text, "", TextCompare: true) != 0) & Versioned.IsNumeric(TextBox_EnterAltitude.Text)))
			{
				float num = Conversions.ToSingle(TextBox_EnterAltitude.Text);
				string text = "";
				if (Client.SelectedWaypoint != null && ((Client.SelectedWaypoint.Type == Waypoint.WaypointType.InitialPoint) | ((Client.SelectedWaypoint.Type == Waypoint.WaypointType.Target) & (Client.SelectedWaypoint.ReferenceWeapon_ID != 0))) && SpeedAlt_Mission != null && SpeedAlt_Mission.MissionClass == Mission._MissionClass.Strike)
				{
					Scenario scenario_ = Client.CurrentScenario;
					Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_, Client.SelectedWaypoint.ReferenceWeapon_ID, bool_0: false);
					float num2 = 1f;
					string text2 = "mt";
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						num2 = 0.3048f;
						text2 = "ft";
					}
					if (num * num2 < newWeapon.MinLaunchAlt_AGL)
					{
						text = " Weapon " + newWeapon.Name + " cannot be launch at " + num + " " + text2 + " minimum launch altitude is " + Math.Round(newWeapon.MinLaunchAlt_AGL * 1f / num2) + " " + text2;
					}
					else if ((num * num2 > newWeapon.MaxLaunchAlt_AGL) & (newWeapon.MaxLaunchAlt_AGL != 0f))
					{
						text = " Weapon " + newWeapon.Name + " cannot be launch at " + num + " " + text2 + " maximum launch altitude is " + Math.Round(newWeapon.MaxLaunchAlt_AGL * 1f / num2) + " " + text2;
					}
				}
				if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
				{
					num *= 0.3048f;
				}
				if (Operators.CompareString(text, "", TextCompare: true) != 0)
				{
					DarkMessageBox.ShowWarning(text, "Weapon Altitude Error");
					TextBox_EnterAltitude.Focus();
					_MerchantException = true;
					return;
				}
				if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
				{
					if (Client.SelectedWaypoint.TerrainFollowing)
					{
						Client.SelectedWaypoint.DesiredAltitude = null;
						Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = num;
					}
					else
					{
						Client.SelectedWaypoint.DesiredAltitude = num;
						Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = null;
					}
				}
				else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
				{
					if (!Information.IsNothing(SpeedAlt_SelectedUnit))
					{
						float maximumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMaximumAltitude();
						float minimumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
						if (num < minimumAltitude)
						{
							num = minimumAltitude;
						}
						if (num > maximumAltitude)
						{
							num = maximumAltitude;
						}
						SpeedAlt_SelectedUnit.DesiredAltitude = num;
						if (SpeedAlt_SelectedUnit.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit))
						{
							SpeedAlt_SelectedUnit.DesiredAltitude_AGL = num;
						}
						else
						{
							SpeedAlt_SelectedUnit.DesiredAltitude = num;
						}
					}
				}
				else if (SpeedAlt_FlightPlanWaypoint.TerrainFollowing)
				{
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude = null;
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = num;
				}
				else
				{
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude = num;
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = null;
				}
				CalcInterruptibleSchema();
			}
		}
		helperRecord = false;
		RefreshForm();
	}

	private void GetInterruptibleUtils(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F2 && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Space))
		{
			if ((m_InfoRecord || helperRecord || m_MapperRecord) && (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12))
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
			if (!helperRecord && !m_InfoRecord && !m_MapperRecord)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
	}

	public void CB_AltOverride_Click(object sender, EventArgs e)
	{
		if (!managerRecord || (Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)))
		{
			return;
		}
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.DesiredAltitudeOverride = CB_AltOverride.Checked;
			if (Information.IsNothing(Client.SelectedWaypoint.DesiredAltitude))
			{
				Client.SelectedWaypoint.DesiredAltitude = 0f;
			}
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			SpeedAlt_SelectedUnit.Kinematics.DesiredAltitudeOverride = CB_AltOverride.Checked;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.DesiredAltitudeOverride = CB_AltOverride.Checked;
			if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint.DesiredAltitude))
			{
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude = 0f;
			}
		}
		if (!CB_AltOverride.Checked)
		{
			ForgotInterruptibleSchema();
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.DesiredAltitude = null;
				Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
			else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
			else
			{
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude = null;
				SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = null;
			}
		}
		if (Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
		}
		RefreshForm();
	}

	public void CB_SpeedOverride_Click(object sender, EventArgs e)
	{
		if (!managerRecord || (Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)))
		{
			return;
		}
		if (CB_SpeedOverride.Checked)
		{
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (Client.SelectedWaypoint.DesiredSpeed.HasValue)
				{
					Client.SelectedWaypoint.DesiredSpeedOverride = Client.SelectedWaypoint.DesiredSpeed;
				}
				else
				{
					Client.SelectedWaypoint.DesiredSpeed = 0f;
					Client.SelectedWaypoint.DesiredSpeedOverride = Client.SelectedWaypoint.DesiredSpeed;
				}
			}
			else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
			else if (SpeedAlt_FlightPlanWaypoint.DesiredSpeed.HasValue)
			{
				SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = SpeedAlt_FlightPlanWaypoint.DesiredSpeed;
			}
			else
			{
				SpeedAlt_FlightPlanWaypoint.DesiredSpeed = 0f;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = SpeedAlt_FlightPlanWaypoint.DesiredSpeed;
			}
		}
		else
		{
			FlushInterruptibleSchema();
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.SpeedFixed = Waypoint.FixedFree.Free;
				Client.SelectedWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				Client.SelectedWaypoint.DesiredSpeedOverride = null;
				Client.SelectedWaypoint.DesiredSpeed = null;
			}
			else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_SelectedUnit.Kinematics.DesiredSpeedOverride = null;
				SpeedAlt_SelectedUnit.AI.UpdateSpeedAlt_MatchGroupLead();
			}
			else
			{
				SpeedAlt_FlightPlanWaypoint.SpeedFixed = Waypoint.FixedFree.Free;
				SpeedAlt_FlightPlanWaypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeedOverride = null;
				SpeedAlt_FlightPlanWaypoint.DesiredSpeed = null;
				Scenario currentScenario = Client.CurrentScenario;
				Mission speedAlt_Mission = SpeedAlt_Mission;
				ActiveUnit referenceUnit = SpeedAlt_Flight.GetReferenceUnit(Client.CurrentScenario);
				Mission.Flight speedAlt_Flight = SpeedAlt_Flight;
				Mission.Flight speedAlt_Flight2 = SpeedAlt_Flight;
				Waypoint[] waypoint_ = speedAlt_Flight2.FlightPlan;
				float float_ = 0f;
				float float_2 = 0f;
				MissionPlanner.ConnectTokenizer(currentScenario, speedAlt_Mission, referenceUnit, speedAlt_Flight, ref waypoint_, ref float_, ref float_2, bool_0: false, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
				speedAlt_Flight2.FlightPlan = waypoint_;
				Client.MustRefreshMainForm = true;
				if (Client.FlightPlanEditorWindow.Visible)
				{
					Client.FlightPlanEditorWindow.InvokePolicy();
					Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
				}
			}
		}
		if (Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
		}
		RefreshForm();
	}

	private void WriteInterruptibleUtils(object sender, EventArgs e)
	{
		m_MapperRecord = true;
	}

	private void NewInterruptibleUtils(object sender, EventArgs e)
	{
		switch (CB_WaypointType.SelectedIndex)
		{
		case 0:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.Assemble;
			break;
		case 1:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			break;
		case 2:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.Target;
			break;
		case 3:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.TurningPoint;
			break;
		case 4:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.InitialPoint;
			break;
		case 5:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.StrikeIngress;
			break;
		case 6:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.StrikeEgress;
			break;
		case 7:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.TakeOff;
			break;
		case 8:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.HoldStart;
			break;
		case 9:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.HoldEnd;
			break;
		case 10:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.TurningPoint;
			break;
		case 11:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.LandingMarshal;
			break;
		case 12:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.Land;
			break;
		case 13:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.PatrolStation;
			break;
		case 14:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.LocalizationRun;
			break;
		case 15:
			Client.SelectedWaypoint.Type = Waypoint.WaypointType.Refuel;
			break;
		}
		m_MapperRecord = false;
	}

	private void PushInterruptibleUtils(object sender, EventArgs e)
	{
		m_MapperRecord = true;
	}

	private void InvokeInterruptibleUtils(object sender, EventArgs e)
	{
		SetupInterruptibleUtils();
	}

	private void SetupInterruptibleUtils()
	{
		if (m_MapperRecord)
		{
			if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !Information.IsNothing(Client.SelectedWaypoint))
			{
				Client.SelectedWaypoint.Description = TextBox_WaypointDescription.Text;
			}
			else if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				SpeedAlt_FlightPlanWaypoint.Description = TextBox_WaypointDescription.Text;
			}
		}
		m_MapperRecord = false;
		RefreshForm();
	}

	private void ExcludeInterruptibleUtils(object sender, FormClosingEventArgs e)
	{
		if (IncludeInterruptibleUtils(bool_0: true))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
			e.Cancel = true;
			Hide();
		}
		else
		{
			e.Cancel = true;
		}
	}

	private bool IncludeInterruptibleUtils(bool bool_0)
	{
		if (TextBox_EnterAltitude.Focused || bool_0)
		{
			LoginInterruptibleUtils();
			if (_MerchantException)
			{
				_MerchantException = false;
				return false;
			}
		}
		if (TextBox_EnterSpeed.Focused || bool_0)
		{
			ViewInterruptibleUtils();
		}
		if (TextBox_WaypointDescription.Focused || bool_0)
		{
			SetupInterruptibleUtils();
		}
		if (SpeedAlt_FlightPlanWaypoint != null || Client.SelectedWaypoint != null)
		{
			bool flag = false;
			Waypoint waypoint = ((SpeedAlt_FlightPlanWaypoint == null) ? Client.SelectedWaypoint : SpeedAlt_FlightPlanWaypoint);
			if (waypoint.Category == Waypoint.WaypointCategory.FlightPlan)
			{
				Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
				for (int i = 0; i < sides_ReadOnly.Length; i++)
				{
					foreach (Mission mission in sides_ReadOnly[i].Missions)
					{
						foreach (Mission.Flight flight2 in mission.FlightList)
						{
							if (!flight2.FlightPlan.Contains(waypoint))
							{
								continue;
							}
							Scenario currentScenario = Client.CurrentScenario;
							ActiveUnit referenceUnit = flight2.GetReferenceUnit(Client.CurrentScenario);
							Mission.Flight flight;
							Waypoint[] waypoint_ = (flight = flight2).FlightPlan;
							float float_ = 0f;
							float float_2 = 0f;
							MissionPlanner.ConnectTokenizer(currentScenario, mission, referenceUnit, flight2, ref waypoint_, ref float_, ref float_2, bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: false, bool_5: true, bool_6: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, bool_7: false, bool_8: false, null, null, bool_9: false);
							flight.FlightPlan = waypoint_;
							RegistryParameterMessage.AwakeCustomer();
							flag = true;
							if (Client.FlightPlanEditorWindow.Visible)
							{
								Client.FlightPlanEditorWindow.InvokePolicy();
								if (Client.FlightPlanEditorWindow.SelectedFlight != null && Client.FlightPlanEditorWindow.theFlightPlanWaypoints != null)
								{
									Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
								}
							}
							break;
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (Client.FlightPlanEditorWindow.Visible)
				{
					Client.FlightPlanEditorWindow.GetPolicy(bool_0: false);
					Client.FlightPlanEditorWindow.InvokePolicy();
					if (Client.FlightPlanEditorWindow.theFlightPlanWaypoints != null)
					{
						Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DisplayLocks();
					}
				}
				if (Client.AirTaskingOrderWindow.Visible)
				{
					Client.AirTaskingOrderWindow.RefreshWindow();
				}
			}
		}
		CB_SpeedOverride.Select();
		return true;
	}

	private void SearchInterruptibleUtils(object sender, FormClosedEventArgs e)
	{
		if (_StructException)
		{
			Client.SelectedUnitPreChange -= HandleSelectedObjectChanged;
			Client.SelectedWaypointPreChange -= HandleSelectedObjectChanged;
		}
		_StructException = false;
		SpeedAlt_FlightPlanWaypoint = null;
		SpeedAlt_SelectedUnit = null;
	}

	private void EnableInterruptibleUtils(object sender, EventArgs e)
	{
		if (managerRecord)
		{
			if (Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				return;
			}
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				Client.SelectedWaypoint.TerrainFollowing = CB_TerrainFollowing.Checked;
				if (Client.SelectedWaypoint.TerrainFollowing)
				{
					Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = Client.SelectedWaypoint.DesiredAltitude;
					Client.SelectedWaypoint.DesiredAltitude = null;
				}
				else
				{
					Client.SelectedWaypoint.DesiredAltitude = Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing;
					Client.SelectedWaypoint.DesiredAltitude_TerrainFollowing = null;
				}
			}
			else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (!Information.IsNothing(SpeedAlt_SelectedUnit))
				{
					if (SpeedAlt_SelectedUnit.IsAircraft)
					{
						SpeedAlt_SelectedUnit.SetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit, CB_TerrainFollowing.Checked);
					}
					else if (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup)
					{
						Group group = (Group)SpeedAlt_SelectedUnit;
						if (!Information.IsNothing(group.IsGroupLead()))
						{
							group.GroupLead.SetDesiredAltitude_UseTerrainFollowing(group.GroupLead, CB_TerrainFollowing.Checked);
						}
					}
					if (SpeedAlt_SelectedUnit.IsAircraft | (SpeedAlt_SelectedUnit.IsGroup && ((Group)SpeedAlt_SelectedUnit).Type == Group.GroupType.AirGroup))
					{
						if (SpeedAlt_SelectedUnit.GetDesiredAltitude_UseTerrainFollowing(SpeedAlt_SelectedUnit))
						{
							if (SpeedAlt_SelectedUnit.DesiredAltitude <= 0f)
							{
								if (SpeedAlt_SelectedUnit.IsGroupWingman())
								{
									if (!Information.IsNothing(SpeedAlt_SelectedUnit.GetParentGroup().GroupLead))
									{
										if (SpeedAlt_SelectedUnit.GetParentGroup().GroupLead.DesiredAltitude_AGL <= 0f)
										{
											SpeedAlt_SelectedUnit.DesiredAltitude_AGL = 200f;
										}
										else
										{
											SpeedAlt_SelectedUnit.DesiredAltitude_AGL = SpeedAlt_SelectedUnit.GetParentGroup().GroupLead.DesiredAltitude_AGL;
										}
									}
								}
								else
								{
									SpeedAlt_SelectedUnit.DesiredAltitude_AGL = 200f;
								}
							}
							else
							{
								SpeedAlt_SelectedUnit.DesiredAltitude_AGL = SpeedAlt_SelectedUnit.DesiredAltitude;
							}
						}
						else
						{
							float num = SpeedAlt_SelectedUnit.DesiredAltitude_AGL;
							float maximumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMaximumAltitude();
							float minimumAltitude = SpeedAlt_SelectedUnit.Kinematics.GetMinimumAltitude();
							if (num < minimumAltitude)
							{
								num = minimumAltitude;
							}
							if (num > maximumAltitude)
							{
								num = maximumAltitude;
							}
							SpeedAlt_SelectedUnit.DesiredAltitude = num;
						}
					}
				}
			}
			else
			{
				SpeedAlt_FlightPlanWaypoint.TerrainFollowing = CB_TerrainFollowing.Checked;
				if (SpeedAlt_FlightPlanWaypoint.TerrainFollowing)
				{
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = SpeedAlt_FlightPlanWaypoint.DesiredAltitude;
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude = null;
				}
				else
				{
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude = SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing;
					SpeedAlt_FlightPlanWaypoint.DesiredAltitude_TerrainFollowing = null;
				}
			}
		}
		ChangeInterruptibleUtils(CB_TerrainFollowing.Checked);
	}

	private void ChangeInterruptibleUtils(bool bool_0)
	{
		bool @checked = false;
		bool visible = bool_0;
		if (bool_0)
		{
			if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				@checked = Client.SelectedWaypoint.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
				if (SpeedAlt_SelectedUnit != null)
				{
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						Group group = (Group)SpeedAlt_SelectedUnit;
						if (group.GroupLead == null || !group.GroupLead.LandCoverMaskingCapability)
						{
							visible = false;
						}
					}
					else if (!SpeedAlt_SelectedUnit.LandCoverMaskingCapability)
					{
						visible = false;
					}
				}
			}
			else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
			{
				if (Information.IsNothing(SpeedAlt_SelectedUnit))
				{
					visible = false;
				}
				else if (SpeedAlt_SelectedUnit.IsGroup)
				{
					Group group2 = (Group)SpeedAlt_SelectedUnit;
					if (!Information.IsNothing(group2.GroupLead) && group2.GroupLead.LandCoverMaskingCapability)
					{
						@checked = group2.GroupLead.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
					}
					else
					{
						visible = false;
					}
				}
				else if (SpeedAlt_SelectedUnit.LandCoverMaskingCapability)
				{
					@checked = SpeedAlt_SelectedUnit.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
				}
				else
				{
					visible = false;
				}
			}
			else
			{
				@checked = SpeedAlt_FlightPlanWaypoint.TerrainFollowingType == ActiveUnit.TerrainFollowMode.WithinLandCover;
				if (SpeedAlt_SelectedUnit != null)
				{
					if (SpeedAlt_SelectedUnit.IsGroup)
					{
						Group group3 = (Group)SpeedAlt_SelectedUnit;
						if (group3.GroupLead == null || !group3.GroupLead.LandCoverMaskingCapability)
						{
							visible = false;
						}
					}
					else if (!SpeedAlt_SelectedUnit.LandCoverMaskingCapability)
					{
						visible = false;
					}
				}
			}
		}
		CB_UseLandCoverMasking.Checked = @checked;
		CB_UseLandCoverMasking.Visible = visible;
	}

	private void InitInterruptibleUtils(object sender, EventArgs e)
	{
		if (!managerRecord || (Information.IsNothing(SpeedAlt_SelectedUnit) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint)))
		{
			return;
		}
		ActiveUnit.TerrainFollowMode terrainFollowingType = (CB_UseLandCoverMasking.Checked ? ActiveUnit.TerrainFollowMode.WithinLandCover : ActiveUnit.TerrainFollowMode.IgnoreLandCover);
		if (!Information.IsNothing(Client.SelectedWaypoint) && Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			Client.SelectedWaypoint.TerrainFollowingType = terrainFollowingType;
		}
		else if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint))
		{
			if (Information.IsNothing(SpeedAlt_SelectedUnit))
			{
				return;
			}
			if (SpeedAlt_SelectedUnit.IsGroup)
			{
				Group group = (Group)SpeedAlt_SelectedUnit;
				if (!Information.IsNothing(group.IsGroupLead()))
				{
					group.GroupLead.TerrainFollowingType = terrainFollowingType;
				}
			}
			else
			{
				SpeedAlt_SelectedUnit.TerrainFollowingType = terrainFollowingType;
			}
		}
		else
		{
			SpeedAlt_FlightPlanWaypoint.TerrainFollowingType = terrainFollowingType;
		}
	}

	private void CheckInterruptibleUtils(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedWaypoint))
		{
			if (Information.IsNothing(SpeedAlt_FlightPlanWaypoint) && !Information.IsNothing(Client.SelectedUnit) && Client.SelectedUnit.IsActiveUnit)
			{
				SpeedAlt_SelectedUnit.Navigator.SprintDrift = CB_SprintDrift.Checked;
				RefreshForm();
			}
			return;
		}
		switch (CB_SprintDrift.CheckState)
		{
		case CheckState.Indeterminate:
			Client.SelectedWaypoint.SprintDrift = null;
			Client.SelectedWaypoint.SprintDrift_AverageSpeed = null;
			break;
		case CheckState.Unchecked:
		case CheckState.Checked:
			Client.SelectedWaypoint.SprintDrift = CB_SprintDrift.Checked;
			if (Client.SelectedWaypoint.SprintDrift.GetValueOrDefault())
			{
				if (Information.IsNothing(Client.SelectedWaypoint.SprintDrift_AverageSpeed) && !Information.IsNothing(Client.SelectedWaypoint.DesiredSpeed))
				{
					Client.SelectedWaypoint.SprintDrift_AverageSpeed = Client.SelectedWaypoint.DesiredSpeed;
				}
			}
			else
			{
				Client.SelectedWaypoint.SprintDrift_AverageSpeed = null;
			}
			break;
		}
	}

	private void ConcatInterruptibleUtils(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedWaypoint))
		{
			if (!Information.IsNothing(SpeedAlt_FlightPlanWaypoint) || Information.IsNothing(SpeedAlt_SelectedUnit) || !SpeedAlt_SelectedUnit.IsActiveUnit)
			{
				return;
			}
			SpeedAlt_SelectedUnit.Navigator.AvoidCavitation = CB_AvoidCavitation.Checked;
			if (SpeedAlt_SelectedUnit.IsGroup)
			{
				foreach (ActiveUnit value in ((Group)SpeedAlt_SelectedUnit).Units.Values)
				{
					value.Navigator.AvoidCavitation = CB_AvoidCavitation.Checked;
				}
			}
			if (SpeedAlt_SelectedUnit.Navigator.SprintDrift && SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.HasValue)
			{
				SpeedAlt_SelectedUnit.DesiredSpeed = SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed.Value;
				SpeedAlt_SelectedUnit.Navigator.SprintDrift_AverageSpeed = SpeedAlt_SelectedUnit.DesiredSpeed;
			}
			RefreshForm();
		}
		else
		{
			switch (CB_AvoidCavitation.CheckState)
			{
			case CheckState.Indeterminate:
				Client.SelectedWaypoint.AvoidCavitation = null;
				break;
			case CheckState.Unchecked:
			case CheckState.Checked:
				Client.SelectedWaypoint.AvoidCavitation = CB_AvoidCavitation.Checked;
				break;
			}
		}
	}

	public void Button_Previous_Click(object sender, EventArgs e)
	{
		if (Client.SelectedUnit == null || Client.SelectedWaypoint == null)
		{
			return;
		}
		if (SpeedAlt_FlightPlanWaypoint == null)
		{
			int num = Array.IndexOf(((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse, Client.SelectedWaypoint);
			if (num <= 0)
			{
				Client.SelectedWaypoint = null;
				RefreshForm(bool_0: true);
				return;
			}
			Client.SelectedWaypoint = ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse[num - 1];
		}
		else
		{
			int num2 = Array.IndexOf(SpeedAlt_Flight.FlightPlan, SpeedAlt_FlightPlanWaypoint);
			if (num2 <= 0)
			{
				return;
			}
			SpeedAlt_FlightPlanWaypoint = SpeedAlt_Flight.FlightPlan[num2 - 1];
		}
		RefreshForm(bool_0: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}

	public void Button_Next_Click(object sender, EventArgs e)
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		if (Client.SelectedWaypoint == null)
		{
			if (((ActiveUnit)Client.SelectedUnit).Navigator.HasPlottedCourse())
			{
				Client.SelectedWaypoint = ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse[0];
			}
		}
		else if (SpeedAlt_FlightPlanWaypoint == null)
		{
			int num = Array.IndexOf(((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse, Client.SelectedWaypoint);
			if (num == ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse.Count() - 1)
			{
				return;
			}
			Client.SelectedWaypoint = ((ActiveUnit)Client.SelectedUnit).Navigator.PlottedCourse[num + 1];
		}
		else
		{
			int num2 = Array.IndexOf(SpeedAlt_Flight.FlightPlan, SpeedAlt_FlightPlanWaypoint);
			if (num2 == SpeedAlt_Flight.FlightPlan.Count() - 1)
			{
				return;
			}
			SpeedAlt_FlightPlanWaypoint = SpeedAlt_Flight.FlightPlan[num2 + 1];
		}
		RefreshForm(bool_0: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, SpeedAlt_SelectedUnit, bool_0: false);
	}
}
