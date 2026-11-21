using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command.Bridges;
using Command.Messages;
using Command.Records;
using Command_Core;
using CoordinateSharp;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Options : DarkSecondaryFormBase
{
	private TabPage _LanguageTab;

	private Label _LanguageLabel;

	private ComboBox _LanguageCombo;

	public sealed class CoordinateComboMember
	{
		public Parse_Format_Type CoordType;

		public CoordinateComboMember(Parse_Format_Type parse_Format_Type_0)
		{
			CoordType = parse_Format_Type_0;
		}

		public override string ToString()
		{
			Parse_Format_Type coordType = CoordType;
			int num = (int)(coordType - 1);
			if (1 == 0)
			{
			}
			string result = num switch
			{
				0 => "Signed Degree", 
				3 => "Degrees", 
				4 => "UTM", 
				5 => "MGRS", 
				7 => "ECEF", 
				_ => "ERROR - Not Found", 
			};
			if (1 == 0)
			{
			}
			return result;
		}
	}

	private IContainer databaseServer;

	[AccessedThroughProperty("TabPage2")]
	[CompilerGenerated]
	private TabPage m_InterceptorServer;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridView1")]
	private DarkDataGridView m_MessageServer;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage productServer;

	[AccessedThroughProperty("CB_UseAutosave")]
	[CompilerGenerated]
	private DarkCheckBox m_AnnotationServer;

	[AccessedThroughProperty("CB_MessageLogInWindow")]
	[CompilerGenerated]
	private DarkCheckBox initializerServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AltitudeInFeet")]
	private DarkCheckBox roleServer;

	[AccessedThroughProperty("CB_ZoomOnCursor")]
	[CompilerGenerated]
	private DarkCheckBox m_FactoryServer;

	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage m_AttributeServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Sounds")]
	private DarkCheckBox _EventServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Music")]
	private DarkCheckBox globalServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ResetWindowPlacement")]
	private DarkUIButton _WorkerServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MapCursorBox")]
	private DarkUIComboBox stateServer;

	[AccessedThroughProperty("CB_RefPointVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox m_AuthenticationServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel paramsServer;

	[AccessedThroughProperty("CB_SonobuoyVisibility")]
	[CompilerGenerated]
	private DarkUIComboBox m_InfoServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel helperServer;

	[AccessedThroughProperty("CB_MapSymbols")]
	[CompilerGenerated]
	private DarkUIComboBox m_MapperServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel managerServer;

	[CompilerGenerated]
	[AccessedThroughProperty("CP_ShowPlottedPaths")]
	private DarkUIComboBox getterServer;

	[AccessedThroughProperty("CP_ShowGhostedGroupMembers")]
	[CompilerGenerated]
	private DarkUIComboBox m_ProcServer;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel structAdapter;

	[AccessedThroughProperty("CB_UnitStatusImage")]
	[CompilerGenerated]
	private DarkCheckBox m_CallbackAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AllowPowerScemeSwitch")]
	private DarkCheckBox m_DecoratorAdapter;

	[AccessedThroughProperty("TB_Navigation_ThresholdDistanceDeg")]
	[CompilerGenerated]
	private DarkUITextBox m_ProcessAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Navigation_MaxDistanceNM")]
	private DarkUITextBox threadAdapter;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel ruleAdapter;

	[AccessedThroughProperty("CB_ShowDiagnostics")]
	[CompilerGenerated]
	private DarkCheckBox _InstanceAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage5")]
	private TabPage objectAdapter;

	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	private DarkGroupBox m_ParameterAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Autosave")]
	private DarkCheckBox _ExpressionAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	private DarkGroupBox m_DispatcherAdapter;

	[AccessedThroughProperty("CB_FriendlyRangeSymbols")]
	[CompilerGenerated]
	private DarkCheckBox listenerAdapter;

	[AccessedThroughProperty("CB_DisplayIlluminationVectors")]
	[CompilerGenerated]
	private DarkCheckBox configAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayContactEmissions")]
	private DarkCheckBox registryAdapter;

	[AccessedThroughProperty("CB_DisplayTargetingVectors")]
	[CompilerGenerated]
	private DarkCheckBox m_ValAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisallowHighPerformancePowerScheme")]
	private DarkCheckBox _WrapperAdapter;

	[AccessedThroughProperty("CB_ShowGhostedGroupMembers")]
	[CompilerGenerated]
	private DarkCheckBox m_ObserverAdapter;

	[AccessedThroughProperty("CB_DisplayDatalinks")]
	[CompilerGenerated]
	private DarkCheckBox _IssuerAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayMissionAreas")]
	private DarkCheckBox m_ClientAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DisplayCountryAndCityNames")]
	private DarkCheckBox _DicAdapter;

	[AccessedThroughProperty("CB_CustomFineGrainedNavigation")]
	[CompilerGenerated]
	private DarkCheckBox _ConsumerAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_NonFriendlyRangeSymbols")]
	private DarkCheckBox m_FacadeAdapter;

	[AccessedThroughProperty("CB_LogDebugInfoToFile")]
	[CompilerGenerated]
	private DarkCheckBox _ReaderAdapter;

	[AccessedThroughProperty("CP_ShowFlightPlans")]
	[CompilerGenerated]
	private DarkUIComboBox _ImporterAdapter;

	[AccessedThroughProperty("CP_ShowFlightPlans_Airborne")]
	[CompilerGenerated]
	private DarkUIComboBox m_RepositoryAdapter;

	[AccessedThroughProperty("CP_ShowFlightPlans_Planned")]
	[CompilerGenerated]
	private DarkUIComboBox _InvocationAdapter;

	[AccessedThroughProperty("Label11")]
	[CompilerGenerated]
	private DarkLabel m_ClassAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage6")]
	private TabPage m_RequestAdapter;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel m_ValueAdapter;

	[AccessedThroughProperty("Button_TacviewPath")]
	[CompilerGenerated]
	private DarkUIButton m_StubAdapter;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog m_WriterAdapter;

	[AccessedThroughProperty("Button_SetPersonalMapProfile")]
	[CompilerGenerated]
	private DarkUIButton _SpecificationAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_UsePersonalMapProfile")]
	private DarkCheckBox _WatcherAdapter;

	[AccessedThroughProperty("CB_ColorDatablocks")]
	[CompilerGenerated]
	private DarkCheckBox m_ReponseAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage7")]
	private TabPage m_DescriptorAdapter;

	internal HoverInfoOptions _TaskAdapter;

	[AccessedThroughProperty("TB_MusicVolumeBar")]
	[CompilerGenerated]
	private TrackBar filterAdapter;

	[AccessedThroughProperty("TB_SFXVolumeBar")]
	[CompilerGenerated]
	private TrackBar _TestsAdapter;

	[AccessedThroughProperty("SFXVolumeLabel")]
	[CompilerGenerated]
	private DarkLabel m_ContainerAdapter;

	[AccessedThroughProperty("MessageLog")]
	[CompilerGenerated]
	private DataGridViewCheckBoxColumn advisorAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("Timescale_X1")]
	private DataGridViewCheckBoxColumn m_RefAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_GroundSpeedUnit")]
	private DarkUIComboBox errorAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel2")]
	private DarkLabel codeAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("GB_PauseBehaviour")]
	private DarkGroupBox m_ConnectionAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DVViewerPauseBehaviour")]
	private DarkUIComboBox _ContextAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AirDockPauseBehaviour")]
	private DarkUIComboBox _StatusAdapter;

	[AccessedThroughProperty("DarkLabel4")]
	[CompilerGenerated]
	private DarkLabel proccesorAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel3")]
	private DarkLabel m_StrategyAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox1")]
	private DarkGroupBox m_ConfigurationAdapter;

	[AccessedThroughProperty("Combo_CoordinateUnit")]
	[CompilerGenerated]
	private DarkUIComboBox tokenAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("GeocentricCoordLabel")]
	private DarkLabel indexerAdapter;

	[AccessedThroughProperty("CB_RMB_MoveOrder")]
	[CompilerGenerated]
	private DarkCheckBox resolverAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox2")]
	private DarkGroupBox publisherAdapter;

	[AccessedThroughProperty("DarkLabel5")]
	[CompilerGenerated]
	private DarkLabel m_ServerAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SlugTrail_Hostile")]
	private DarkCheckBox m_AdapterAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SlugTrail_Neutral")]
	private DarkCheckBox schemaAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SlugTrail_Friendly")]
	private DarkCheckBox m_UtilsAdapter;

	[AccessedThroughProperty("CB_SlugTrail_Own")]
	[CompilerGenerated]
	private DarkCheckBox m_PredicateAdapter;

	[AccessedThroughProperty("CB_SlugTrail_UseSlugTrail")]
	[CompilerGenerated]
	private DarkCheckBox singletonAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_SlugTrailFreq")]
	private DarkUIComboBox _RecordAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_SlugTrail_Unfriendly")]
	private DarkCheckBox m_AttrAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel6")]
	private DarkLabel visitorAdapter;

	[AccessedThroughProperty("Num_SlugTrailLifetime")]
	[CompilerGenerated]
	private NumericUpDown _ExporterAdapter;

	[AccessedThroughProperty("CB_SlugTrail_Unknown")]
	[CompilerGenerated]
	private DarkCheckBox _PrototypeAdapter;

	[AccessedThroughProperty("CB_CargoShowUSUnits")]
	[CompilerGenerated]
	private DarkCheckBox _ComparatorAdapter;

	[AccessedThroughProperty("ChkASWNoise")]
	[CompilerGenerated]
	private DarkCheckBox itemAdapter;

	[AccessedThroughProperty("CP_ShowAU_Behaviour_Bark")]
	[CompilerGenerated]
	private DarkUIComboBox m_SetterAdapter;

	[AccessedThroughProperty("DarkLabel7")]
	[CompilerGenerated]
	private DarkLabel m_CreatorAdapter;

	[AccessedThroughProperty("ClearSlugTrail")]
	[CompilerGenerated]
	private DarkUIButton _TemplateAdapter;

	[AccessedThroughProperty("lbl_GU_Zoom")]
	[CompilerGenerated]
	private DarkLabel mappingAdapter;

	[AccessedThroughProperty("TB_GrounUnit_Zoom")]
	[CompilerGenerated]
	private TrackBar _MockAdapter;

	[AccessedThroughProperty("DarkLabel10")]
	[CompilerGenerated]
	private DarkLabel m_TagAdapter;

	[AccessedThroughProperty("TB_Flower_Zoom")]
	[CompilerGenerated]
	private TrackBar _FieldAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Rectangle_Zoom")]
	private TrackBar _RegAdapter;

	[AccessedThroughProperty("TB_Diamond_Zoom")]
	[CompilerGenerated]
	private TrackBar _PageAdapter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DrawOutlines")]
	private DarkCheckBox _RulesAdapter;

	private Game.GamePreferences m_MethodAdapter;

	private bool m_ServiceAdapter;

	private bool m_SystemAdapter;

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterceptorServer = value;
		}
	}

	internal DarkDataGridView DataGridView1
	{
		[CompilerGenerated]
		get
		{
			return m_MessageServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = ReadInterruptibleAdvisor;
			DarkDataGridView messageServer = m_MessageServer;
			if (messageServer != null)
			{
				messageServer.CellContentClick -= value2;
			}
			m_MessageServer = value;
			messageServer = m_MessageServer;
			if (messageServer != null)
			{
				messageServer.CellContentClick += value2;
			}
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return productServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productServer = value;
		}
	}

	internal DarkCheckBox CB_UseAutosave
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewInterruptibleAdvisor;
			DarkCheckBox annotationServer = m_AnnotationServer;
			if (annotationServer != null)
			{
				annotationServer.Click -= value2;
			}
			m_AnnotationServer = value;
			annotationServer = m_AnnotationServer;
			if (annotationServer != null)
			{
				annotationServer.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabControl1")]
	internal DarkUITabControl TabControl1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_MessageLogInWindow
	{
		[CompilerGenerated]
		get
		{
			return initializerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = initializerServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			initializerServer = value;
			darkCheckBox = initializerServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_AltitudeInFeet
	{
		[CompilerGenerated]
		get
		{
			return roleServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = roleServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			roleServer = value;
			darkCheckBox = roleServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_ZoomOnCursor
	{
		[CompilerGenerated]
		get
		{
			return m_FactoryServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableInterruptibleAdvisor;
			DarkCheckBox factoryServer = m_FactoryServer;
			if (factoryServer != null)
			{
				factoryServer.Click -= value2;
			}
			m_FactoryServer = value;
			factoryServer = m_FactoryServer;
			if (factoryServer != null)
			{
				factoryServer.Click += value2;
			}
		}
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeServer = value;
		}
	}

	internal DarkCheckBox CB_Sounds
	{
		[CompilerGenerated]
		get
		{
			return _EventServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopInterruptibleAdvisor;
			DarkCheckBox eventServer = _EventServer;
			if (eventServer != null)
			{
				eventServer.Click -= value2;
			}
			_EventServer = value;
			eventServer = _EventServer;
			if (eventServer != null)
			{
				eventServer.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_Music
	{
		[CompilerGenerated]
		get
		{
			return globalServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = globalServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			globalServer = value;
			darkCheckBox = globalServer;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ResetWindowPlacement
	{
		[CompilerGenerated]
		get
		{
			return _WorkerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterInterruptibleModel;
			DarkUIButton workerServer = _WorkerServer;
			if (workerServer != null)
			{
				workerServer.Click -= value2;
			}
			_WorkerServer = value;
			workerServer = _WorkerServer;
			if (workerServer != null)
			{
				workerServer.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal TabPage TabPage4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_MapCursorBox
	{
		[CompilerGenerated]
		get
		{
			return stateServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatInterruptibleAdvisor;
			DarkUIComboBox darkUIComboBox = stateServer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			stateServer = value;
			darkUIComboBox = stateServer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox CB_RefPointVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_AuthenticationServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckInterruptibleAdvisor;
			DarkUIComboBox authenticationServer = m_AuthenticationServer;
			if (authenticationServer != null)
			{
				authenticationServer.SelectionChangeCommitted -= value2;
			}
			m_AuthenticationServer = value;
			authenticationServer = m_AuthenticationServer;
			if (authenticationServer != null)
			{
				authenticationServer.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return paramsServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramsServer = value;
		}
	}

	internal DarkUIComboBox CB_SonobuoyVisibility
	{
		[CompilerGenerated]
		get
		{
			return m_InfoServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitInterruptibleAdvisor;
			DarkUIComboBox infoServer = m_InfoServer;
			if (infoServer != null)
			{
				infoServer.SelectionChangeCommitted -= value2;
			}
			m_InfoServer = value;
			infoServer = m_InfoServer;
			if (infoServer != null)
			{
				infoServer.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return helperServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			helperServer = value;
		}
	}

	internal DarkUIComboBox CB_MapSymbols
	{
		[CompilerGenerated]
		get
		{
			return m_MapperServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptInterruptibleAdvisor;
			DarkUIComboBox mapperServer = m_MapperServer;
			if (mapperServer != null)
			{
				mapperServer.SelectionChangeCommitted -= value2;
			}
			m_MapperServer = value;
			mapperServer = m_MapperServer;
			if (mapperServer != null)
			{
				mapperServer.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return managerServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			managerServer = value;
		}
	}

	internal DarkUIComboBox CP_ShowPlottedPaths
	{
		[CompilerGenerated]
		get
		{
			return getterServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleAdvisor;
			DarkUIComboBox darkUIComboBox = getterServer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			getterServer = value;
			darkUIComboBox = getterServer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label6")]
	internal DarkLabel Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CP_ShowGhostedGroupMembers
	{
		[CompilerGenerated]
		get
		{
			return m_ProcServer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeInterruptibleAdvisor;
			DarkUIComboBox procServer = m_ProcServer;
			if (procServer != null)
			{
				procServer.SelectionChangeCommitted -= value2;
			}
			m_ProcServer = value;
			procServer = m_ProcServer;
			if (procServer != null)
			{
				procServer.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return structAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			structAdapter = value;
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_UnitStatusImage
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeInterruptibleAdvisor;
			DarkCheckBox callbackAdapter = m_CallbackAdapter;
			if (callbackAdapter != null)
			{
				callbackAdapter.Click -= value2;
			}
			m_CallbackAdapter = value;
			callbackAdapter = m_CallbackAdapter;
			if (callbackAdapter != null)
			{
				callbackAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_AllowPowerScemeSwitch
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteInterruptibleAdvisor;
			DarkCheckBox decoratorAdapter = m_DecoratorAdapter;
			if (decoratorAdapter != null)
			{
				decoratorAdapter.Click -= value2;
			}
			m_DecoratorAdapter = value;
			decoratorAdapter = m_DecoratorAdapter;
			if (decoratorAdapter != null)
			{
				decoratorAdapter.Click += value2;
			}
		}
	}

	internal DarkUITextBox TB_Navigation_ThresholdDistanceDeg
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeInterruptibleAdvisor;
			EventHandler value3 = CloneInterruptibleAdvisor;
			DarkUITextBox processAdapter = m_ProcessAdapter;
			if (processAdapter != null)
			{
				processAdapter.Enter -= value2;
				processAdapter.Leave -= value3;
			}
			m_ProcessAdapter = value;
			processAdapter = m_ProcessAdapter;
			if (processAdapter != null)
			{
				processAdapter.Enter += value2;
				processAdapter.Leave += value3;
			}
		}
	}

	internal DarkUITextBox TB_Navigation_MaxDistanceNM
	{
		[CompilerGenerated]
		get
		{
			return threadAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertInterruptibleModel;
			EventHandler value3 = CountInterruptibleAdvisor;
			DarkUITextBox darkUITextBox = threadAdapter;
			if (darkUITextBox != null)
			{
				darkUITextBox.Enter -= value2;
				darkUITextBox.Leave -= value3;
			}
			threadAdapter = value;
			darkUITextBox = threadAdapter;
			if (darkUITextBox != null)
			{
				darkUITextBox.Enter += value2;
				darkUITextBox.Leave += value3;
			}
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return ruleAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ruleAdapter = value;
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_ShowDiagnostics
	{
		[CompilerGenerated]
		get
		{
			return _InstanceAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleAdvisor;
			DarkCheckBox instanceAdapter = _InstanceAdapter;
			if (instanceAdapter != null)
			{
				instanceAdapter.Click -= value2;
			}
			_InstanceAdapter = value;
			instanceAdapter = _InstanceAdapter;
			if (instanceAdapter != null)
			{
				instanceAdapter.Click += value2;
			}
		}
	}

	internal TabPage TabPage5
	{
		[CompilerGenerated]
		get
		{
			return objectAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			objectAdapter = value;
		}
	}

	internal DarkGroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return m_ParameterAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParameterAdapter = value;
		}
	}

	internal DarkCheckBox CB_Autosave
	{
		[CompilerGenerated]
		get
		{
			return _ExpressionAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginInterruptibleAdvisor;
			DarkCheckBox expressionAdapter = _ExpressionAdapter;
			if (expressionAdapter != null)
			{
				expressionAdapter.Click -= value2;
			}
			_ExpressionAdapter = value;
			expressionAdapter = _ExpressionAdapter;
			if (expressionAdapter != null)
			{
				expressionAdapter.Click += value2;
			}
		}
	}

	internal DarkGroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DispatcherAdapter = value;
		}
	}

	internal DarkCheckBox CB_FriendlyRangeSymbols
	{
		[CompilerGenerated]
		get
		{
			return listenerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = listenerAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			listenerAdapter = value;
			darkCheckBox = listenerAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_DisplayIlluminationVectors
	{
		[CompilerGenerated]
		get
		{
			return configAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = configAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			configAdapter = value;
			darkCheckBox = configAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_DisplayContactEmissions
	{
		[CompilerGenerated]
		get
		{
			return registryAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = registryAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			registryAdapter = value;
			darkCheckBox = registryAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal DarkGroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_DisplayTargetingVectors
	{
		[CompilerGenerated]
		get
		{
			return m_ValAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchInterruptibleAdvisor;
			DarkCheckBox valAdapter = m_ValAdapter;
			if (valAdapter != null)
			{
				valAdapter.Click -= value2;
			}
			m_ValAdapter = value;
			valAdapter = m_ValAdapter;
			if (valAdapter != null)
			{
				valAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_DisallowHighPerformancePowerScheme
	{
		[CompilerGenerated]
		get
		{
			return _WrapperAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallInterruptibleAdvisor;
			DarkCheckBox wrapperAdapter = _WrapperAdapter;
			if (wrapperAdapter != null)
			{
				wrapperAdapter.Click -= value2;
			}
			_WrapperAdapter = value;
			wrapperAdapter = _WrapperAdapter;
			if (wrapperAdapter != null)
			{
				wrapperAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_ShowGhostedGroupMembers
	{
		[CompilerGenerated]
		get
		{
			return m_ObserverAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetInterruptibleAdvisor;
			DarkCheckBox observerAdapter = m_ObserverAdapter;
			if (observerAdapter != null)
			{
				observerAdapter.Click -= value2;
			}
			m_ObserverAdapter = value;
			observerAdapter = m_ObserverAdapter;
			if (observerAdapter != null)
			{
				observerAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_DisplayDatalinks
	{
		[CompilerGenerated]
		get
		{
			return _IssuerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectInterruptibleAdvisor;
			DarkCheckBox issuerAdapter = _IssuerAdapter;
			if (issuerAdapter != null)
			{
				issuerAdapter.Click -= value2;
			}
			_IssuerAdapter = value;
			issuerAdapter = _IssuerAdapter;
			if (issuerAdapter != null)
			{
				issuerAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_DisplayMissionAreas
	{
		[CompilerGenerated]
		get
		{
			return m_ClientAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeInterruptibleAdvisor;
			DarkCheckBox clientAdapter = m_ClientAdapter;
			if (clientAdapter != null)
			{
				clientAdapter.Click -= value2;
			}
			m_ClientAdapter = value;
			clientAdapter = m_ClientAdapter;
			if (clientAdapter != null)
			{
				clientAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_DisplayCountryAndCityNames
	{
		[CompilerGenerated]
		get
		{
			return _DicAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyInterruptibleAdvisor;
			DarkCheckBox dicAdapter = _DicAdapter;
			if (dicAdapter != null)
			{
				dicAdapter.Click -= value2;
			}
			_DicAdapter = value;
			dicAdapter = _DicAdapter;
			if (dicAdapter != null)
			{
				dicAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_CustomFineGrainedNavigation
	{
		[CompilerGenerated]
		get
		{
			return _ConsumerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddInterruptibleAdvisor;
			DarkCheckBox consumerAdapter = _ConsumerAdapter;
			if (consumerAdapter != null)
			{
				consumerAdapter.Click -= value2;
			}
			_ConsumerAdapter = value;
			consumerAdapter = _ConsumerAdapter;
			if (consumerAdapter != null)
			{
				consumerAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_NonFriendlyRangeSymbols
	{
		[CompilerGenerated]
		get
		{
			return m_FacadeAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteInterruptibleAdvisor;
			DarkCheckBox facadeAdapter = m_FacadeAdapter;
			if (facadeAdapter != null)
			{
				facadeAdapter.Click -= value2;
			}
			m_FacadeAdapter = value;
			facadeAdapter = m_FacadeAdapter;
			if (facadeAdapter != null)
			{
				facadeAdapter.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label9")]
	internal DarkLabel Label9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_LogDebugInfoToFile
	{
		[CompilerGenerated]
		get
		{
			return _ReaderAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupInterruptibleAdvisor;
			DarkCheckBox readerAdapter = _ReaderAdapter;
			if (readerAdapter != null)
			{
				readerAdapter.Click -= value2;
			}
			_ReaderAdapter = value;
			readerAdapter = _ReaderAdapter;
			if (readerAdapter != null)
			{
				readerAdapter.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("CB_ExtraMemoryProtection")]
	internal DarkCheckBox CB_ExtraMemoryProtection
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CP_ShowFlightPlans_Airborne
	{
		[CompilerGenerated]
		get
		{
			return m_RepositoryAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetInterruptibleAdvisor;
			DarkUIComboBox repositoryAdapter = m_RepositoryAdapter;
			if (repositoryAdapter != null)
			{
				repositoryAdapter.SelectionChangeCommitted -= value2;
			}
			m_RepositoryAdapter = value;
			repositoryAdapter = m_RepositoryAdapter;
			if (repositoryAdapter != null)
			{
				repositoryAdapter.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label20")]
	internal DarkLabel Label20
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CP_ShowFlightPlans_Planned
	{
		[CompilerGenerated]
		get
		{
			return _InvocationAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillInterruptibleAdvisor;
			DarkUIComboBox invocationAdapter = _InvocationAdapter;
			if (invocationAdapter != null)
			{
				invocationAdapter.SelectionChangeCommitted -= value2;
			}
			_InvocationAdapter = value;
			invocationAdapter = _InvocationAdapter;
			if (invocationAdapter != null)
			{
				invocationAdapter.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label11
	{
		[CompilerGenerated]
		get
		{
			return m_ClassAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClassAdapter = value;
		}
	}

	internal TabPage TabPage6
	{
		[CompilerGenerated]
		get
		{
			return m_RequestAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RequestAdapter = value;
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_ValueAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValueAdapter = value;
		}
	}

	[field: AccessedThroughProperty("TB_TacviewPath")]
	internal DarkUITextBox TB_TacviewPath
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_TacviewPath
	{
		[CompilerGenerated]
		get
		{
			return m_StubAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DisableInterruptibleAdvisor;
			DarkUIButton stubAdapter = m_StubAdapter;
			if (stubAdapter != null)
			{
				stubAdapter.Click -= value2;
			}
			m_StubAdapter = value;
			stubAdapter = m_StubAdapter;
			if (stubAdapter != null)
			{
				stubAdapter.Click += value2;
			}
		}
	}

	internal OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return m_WriterAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WriterAdapter = value;
		}
	}

	internal DarkUIButton Button_SetPersonalMapProfile
	{
		[CompilerGenerated]
		get
		{
			return _SpecificationAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertInterruptibleAdvisor;
			DarkUIButton specificationAdapter = _SpecificationAdapter;
			if (specificationAdapter != null)
			{
				specificationAdapter.Click -= value2;
			}
			_SpecificationAdapter = value;
			specificationAdapter = _SpecificationAdapter;
			if (specificationAdapter != null)
			{
				specificationAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_UsePersonalMapProfile
	{
		[CompilerGenerated]
		get
		{
			return _WatcherAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateInterruptibleAdvisor;
			DarkCheckBox watcherAdapter = _WatcherAdapter;
			if (watcherAdapter != null)
			{
				watcherAdapter.Click -= value2;
			}
			_WatcherAdapter = value;
			watcherAdapter = _WatcherAdapter;
			if (watcherAdapter != null)
			{
				watcherAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_ColorDatablocks
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareInterruptibleAdvisor;
			DarkCheckBox reponseAdapter = m_ReponseAdapter;
			if (reponseAdapter != null)
			{
				reponseAdapter.Click -= value2;
			}
			m_ReponseAdapter = value;
			reponseAdapter = m_ReponseAdapter;
			if (reponseAdapter != null)
			{
				reponseAdapter.Click += value2;
			}
		}
	}

	internal TabPage TabPage7
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DescriptorAdapter = value;
		}
	}

	[field: AccessedThroughProperty("ElementHost1")]
	internal ElementHost ElementHost1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar TB_MusicVolumeBar
	{
		[CompilerGenerated]
		get
		{
			return filterAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptibleAdvisor;
			TrackBar trackBar = filterAdapter;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
			}
			filterAdapter = value;
			trackBar = filterAdapter;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
			}
		}
	}

	internal TrackBar TB_SFXVolumeBar
	{
		[CompilerGenerated]
		get
		{
			return _TestsAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareInterruptibleAdvisor;
			TrackBar testsAdapter = _TestsAdapter;
			if (testsAdapter != null)
			{
				testsAdapter.Scroll -= value2;
			}
			_TestsAdapter = value;
			testsAdapter = _TestsAdapter;
			if (testsAdapter != null)
			{
				testsAdapter.Scroll += value2;
			}
		}
	}

	[field: AccessedThroughProperty("MusicVolumeLabel")]
	internal DarkLabel MusicVolumeLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel SFXVolumeLabel
	{
		[CompilerGenerated]
		get
		{
			return m_ContainerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ContainerAdapter = value;
		}
	}

	[field: AccessedThroughProperty("MessageType_Hidden")]
	internal DataGridViewTextBoxColumn MessageType_Hidden
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("MessageType")]
	internal DataGridViewTextBoxColumn MessageType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewCheckBoxColumn MessageLog
	{
		[CompilerGenerated]
		get
		{
			return advisorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			advisorAdapter = value;
		}
	}

	[field: AccessedThroughProperty("PopUp")]
	internal DataGridViewCheckBoxColumn PopUp
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Column_ShowBalloon")]
	internal DataGridViewCheckBoxColumn Column_ShowBalloon
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewCheckBoxColumn Timescale_X1
	{
		[CompilerGenerated]
		get
		{
			return m_RefAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RefAdapter = value;
		}
	}

	internal DarkUIComboBox Combo_GroundSpeedUnit
	{
		[CompilerGenerated]
		get
		{
			return errorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectInterruptibleAdvisor;
			DarkUIComboBox darkUIComboBox = errorAdapter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			errorAdapter = value;
			darkUIComboBox = errorAdapter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel DarkLabel2
	{
		[CompilerGenerated]
		get
		{
			return codeAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			codeAdapter = value;
		}
	}

	internal DarkGroupBox GB_PauseBehaviour
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConnectionAdapter = value;
		}
	}

	internal DarkUIComboBox CB_DVViewerPauseBehaviour
	{
		[CompilerGenerated]
		get
		{
			return _ContextAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartInterruptibleAdvisor;
			DarkUIComboBox contextAdapter = _ContextAdapter;
			if (contextAdapter != null)
			{
				contextAdapter.SelectedIndexChanged -= value2;
			}
			_ContextAdapter = value;
			contextAdapter = _ContextAdapter;
			if (contextAdapter != null)
			{
				contextAdapter.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkUIComboBox CB_AirDockPauseBehaviour
	{
		[CompilerGenerated]
		get
		{
			return _StatusAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitInterruptibleAdvisor;
			DarkUIComboBox statusAdapter = _StatusAdapter;
			if (statusAdapter != null)
			{
				statusAdapter.SelectedIndexChanged -= value2;
			}
			_StatusAdapter = value;
			statusAdapter = _StatusAdapter;
			if (statusAdapter != null)
			{
				statusAdapter.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkLabel DarkLabel4
	{
		[CompilerGenerated]
		get
		{
			return proccesorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorAdapter = value;
		}
	}

	internal DarkLabel DarkLabel3
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StrategyAdapter = value;
		}
	}

	internal DarkGroupBox DarkGroupBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConfigurationAdapter = value;
		}
	}

	internal DarkUIComboBox Combo_CoordinateUnit
	{
		[CompilerGenerated]
		get
		{
			return tokenAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestInterruptibleAdvisor;
			DarkUIComboBox darkUIComboBox = tokenAdapter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			tokenAdapter = value;
			darkUIComboBox = tokenAdapter;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel GeocentricCoordLabel
	{
		[CompilerGenerated]
		get
		{
			return indexerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			indexerAdapter = value;
		}
	}

	internal DarkCheckBox CB_RMB_MoveOrder
	{
		[CompilerGenerated]
		get
		{
			return resolverAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = resolverAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			resolverAdapter = value;
			darkCheckBox = resolverAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkGroupBox DarkGroupBox2
	{
		[CompilerGenerated]
		get
		{
			return publisherAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherAdapter = value;
		}
	}

	internal DarkLabel DarkLabel5
	{
		[CompilerGenerated]
		get
		{
			return m_ServerAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ServerAdapter = value;
		}
	}

	internal DarkCheckBox CB_SlugTrail_Hostile
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleAdvisor;
			DarkCheckBox adapterAdapter = m_AdapterAdapter;
			if (adapterAdapter != null)
			{
				adapterAdapter.Click -= value2;
			}
			m_AdapterAdapter = value;
			adapterAdapter = m_AdapterAdapter;
			if (adapterAdapter != null)
			{
				adapterAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_SlugTrail_Neutral
	{
		[CompilerGenerated]
		get
		{
			return schemaAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = schemaAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			schemaAdapter = value;
			darkCheckBox = schemaAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_SlugTrail_Friendly
	{
		[CompilerGenerated]
		get
		{
			return m_UtilsAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleAdvisor;
			DarkCheckBox utilsAdapter = m_UtilsAdapter;
			if (utilsAdapter != null)
			{
				utilsAdapter.Click -= value2;
			}
			m_UtilsAdapter = value;
			utilsAdapter = m_UtilsAdapter;
			if (utilsAdapter != null)
			{
				utilsAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_SlugTrail_Own
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartInterruptibleAdvisor;
			DarkCheckBox predicateAdapter = m_PredicateAdapter;
			if (predicateAdapter != null)
			{
				predicateAdapter.Click -= value2;
			}
			m_PredicateAdapter = value;
			predicateAdapter = m_PredicateAdapter;
			if (predicateAdapter != null)
			{
				predicateAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_SlugTrail_UseSlugTrail
	{
		[CompilerGenerated]
		get
		{
			return singletonAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = singletonAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			singletonAdapter = value;
			darkCheckBox = singletonAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_SlugTrailFreq
	{
		[CompilerGenerated]
		get
		{
			return _RecordAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AssetInterruptibleAdvisor;
			DarkUIComboBox recordAdapter = _RecordAdapter;
			if (recordAdapter != null)
			{
				recordAdapter.SelectionChangeCommitted -= value2;
			}
			_RecordAdapter = value;
			recordAdapter = _RecordAdapter;
			if (recordAdapter != null)
			{
				recordAdapter.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkRichTextBox1")]
	internal DarkRichTextBox DarkRichTextBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_SlugTrail_Unfriendly
	{
		[CompilerGenerated]
		get
		{
			return m_AttrAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveInterruptibleAdvisor;
			DarkCheckBox attrAdapter = m_AttrAdapter;
			if (attrAdapter != null)
			{
				attrAdapter.Click -= value2;
			}
			m_AttrAdapter = value;
			attrAdapter = m_AttrAdapter;
			if (attrAdapter != null)
			{
				attrAdapter.Click += value2;
			}
		}
	}

	internal DarkLabel DarkLabel6
	{
		[CompilerGenerated]
		get
		{
			return visitorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			visitorAdapter = value;
		}
	}

	private NumericUpDown Num_SlugTrailLifetime
	{
		[CompilerGenerated]
		get
		{
			return _ExporterAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintInterruptibleAdvisor;
			EventHandler value3 = DefineInterruptibleAdvisor;
			NumericUpDown exporterAdapter = _ExporterAdapter;
			if (exporterAdapter != null)
			{
				exporterAdapter.Click -= value2;
				exporterAdapter.LostFocus -= value3;
			}
			_ExporterAdapter = value;
			exporterAdapter = _ExporterAdapter;
			if (exporterAdapter != null)
			{
				exporterAdapter.Click += value2;
				exporterAdapter.LostFocus += value3;
			}
		}
	}

	internal DarkCheckBox CB_SlugTrail_Unknown
	{
		[CompilerGenerated]
		get
		{
			return _PrototypeAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostInterruptibleAdvisor;
			DarkCheckBox prototypeAdapter = _PrototypeAdapter;
			if (prototypeAdapter != null)
			{
				prototypeAdapter.Click -= value2;
			}
			_PrototypeAdapter = value;
			prototypeAdapter = _PrototypeAdapter;
			if (prototypeAdapter != null)
			{
				prototypeAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox CB_CargoShowUSUnits
	{
		[CompilerGenerated]
		get
		{
			return _ComparatorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchInterruptibleAdvisor;
			DarkCheckBox comparatorAdapter = _ComparatorAdapter;
			if (comparatorAdapter != null)
			{
				comparatorAdapter.Click -= value2;
			}
			_ComparatorAdapter = value;
			comparatorAdapter = _ComparatorAdapter;
			if (comparatorAdapter != null)
			{
				comparatorAdapter.Click += value2;
			}
		}
	}

	internal DarkCheckBox DarkCheckBox_0
	{
		[CompilerGenerated]
		get
		{
			return itemAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishInterruptibleAdvisor;
			DarkCheckBox darkCheckBox = itemAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			itemAdapter = value;
			darkCheckBox = itemAdapter;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CP_ShowAU_Behaviour_Bark
	{
		[CompilerGenerated]
		get
		{
			return m_SetterAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateInterruptibleAdvisor;
			DarkUIComboBox setterAdapter = m_SetterAdapter;
			if (setterAdapter != null)
			{
				setterAdapter.SelectionChangeCommitted -= value2;
			}
			m_SetterAdapter = value;
			setterAdapter = m_SetterAdapter;
			if (setterAdapter != null)
			{
				setterAdapter.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel DarkLabel7
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorAdapter = value;
		}
	}

	internal DarkUIButton ClearSlugTrail
	{
		[CompilerGenerated]
		get
		{
			return _TemplateAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeInterruptibleAdvisor;
			DarkUIButton templateAdapter = _TemplateAdapter;
			if (templateAdapter != null)
			{
				templateAdapter.Click -= value2;
			}
			_TemplateAdapter = value;
			templateAdapter = _TemplateAdapter;
			if (templateAdapter != null)
			{
				templateAdapter.Click += value2;
			}
		}
	}

	internal DarkLabel lbl_GU_Zoom
	{
		[CompilerGenerated]
		get
		{
			return mappingAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mappingAdapter = value;
		}
	}

	internal TrackBar TB_GrounUnit_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _MockAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetInterruptibleAdvisor;
			TrackBar mockAdapter = _MockAdapter;
			if (mockAdapter != null)
			{
				mockAdapter.Scroll -= value2;
			}
			_MockAdapter = value;
			mockAdapter = _MockAdapter;
			if (mockAdapter != null)
			{
				mockAdapter.Scroll += value2;
			}
		}
	}

	internal DarkLabel DarkLabel_0
	{
		[CompilerGenerated]
		get
		{
			return m_TagAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TagAdapter = value;
		}
	}

	internal TrackBar TB_Flower_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _FieldAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcInterruptibleAdvisor;
			TrackBar fieldAdapter = _FieldAdapter;
			if (fieldAdapter != null)
			{
				fieldAdapter.Scroll -= value2;
			}
			_FieldAdapter = value;
			fieldAdapter = _FieldAdapter;
			if (fieldAdapter != null)
			{
				fieldAdapter.Scroll += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel9")]
	internal DarkLabel DarkLabel9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar TB_Rectangle_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _RegAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortInterruptibleAdvisor;
			TrackBar regAdapter = _RegAdapter;
			if (regAdapter != null)
			{
				regAdapter.Scroll -= value2;
			}
			_RegAdapter = value;
			regAdapter = _RegAdapter;
			if (regAdapter != null)
			{
				regAdapter.Scroll += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel8")]
	internal DarkLabel DarkLabel8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar TB_Diamond_Zoom
	{
		[CompilerGenerated]
		get
		{
			return _PageAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapInterruptibleAdvisor;
			TrackBar pageAdapter = _PageAdapter;
			if (pageAdapter != null)
			{
				pageAdapter.Scroll -= value2;
			}
			_PageAdapter = value;
			pageAdapter = _PageAdapter;
			if (pageAdapter != null)
			{
				pageAdapter.Scroll += value2;
			}
		}
	}

	internal DarkCheckBox CB_DrawOutlines
	{
		[CompilerGenerated]
		get
		{
			return _RulesAdapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateInterruptibleAdvisor;
			DarkCheckBox rulesAdapter = _RulesAdapter;
			if (rulesAdapter != null)
			{
				rulesAdapter.CheckedChanged -= value2;
			}
			_RulesAdapter = value;
			rulesAdapter = _RulesAdapter;
			if (rulesAdapter != null)
			{
				rulesAdapter.CheckedChanged += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal DarkUIComboBox InvokeInterruptibleSerializer()
	{
		return _ImporterAdapter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void SetupInterruptibleSerializer(DarkUIComboBox darkUIComboBox_0)
	{
		_ImporterAdapter = darkUIComboBox_0;
	}

	public Options()
	{
		base.Load += FlushInterruptibleModel;
		base.KeyDown += OrderInterruptibleModel;
		base.FormClosing += ManageInterruptibleModel;
		m_ServiceAdapter = false;
		m_SystemAdapter = false;
		RateInterruptibleModel();
		InitializeLanguageTab();
	}

	private void InitializeLanguageTab()
	{
		_LanguageTab = new TabPage
		{
			Name = "TabPageLanguage",
			Text = Localization.T("语言", "Language"),
			BackColor = Color.FromArgb(60, 63, 65),
			Location = new Point(4, 24),
			Padding = new Padding(3),
			Size = new Size(694, 641),
			TabIndex = 8
		};
		_LanguageLabel = new Label
		{
			AutoSize = true,
			ForeColor = Color.White,
			Location = new Point(24, 28),
			Text = Localization.T("界面语言（重启后生效）：", "UI language (restart required):")
		};
		_LanguageCombo = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Location = new Point(24, 60),
			Size = new Size(220, 24)
		};
		_LanguageCombo.Items.Add("中文");
		_LanguageCombo.Items.Add("English");
		_LanguageCombo.SelectedIndex = ((Localization.SavedLanguage == AppLanguage.English) ? 1 : 0);
		_LanguageCombo.SelectedIndexChanged += LanguageCombo_SelectedIndexChanged;
		_LanguageTab.Controls.Add(_LanguageLabel);
		_LanguageTab.Controls.Add(_LanguageCombo);
		TabControl1.Controls.Add(_LanguageTab);
	}

	private void LanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
	{
		AppLanguage selected = ((_LanguageCombo.SelectedIndex == 1) ? AppLanguage.English : AppLanguage.Chinese);
		if (selected == Localization.SavedLanguage)
		{
			return;
		}
		Localization.SaveLanguagePreference(selected);
		string message = ((selected == AppLanguage.English)
			? "语言已保存为 English，重启游戏后生效。"
			: "语言已保存为中文，重启游戏后生效。") + "\r\n\r\nLanguage saved. Restart the game to apply.";
		MessageBox.Show(this, message, "语言 / Language", MessageBoxButtons.OK, MessageBoxIcon.Information);
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && databaseServer != null)
		{
			databaseServer.Dispose();
		}
		base.Dispose(disposing);
	}

	[DebuggerStepThrough]
	private void RateInterruptibleModel()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		CB_RMB_MoveOrder = new DarkCheckBox();
		DarkGroupBox1 = new DarkGroupBox();
		CB_CargoShowUSUnits = new DarkCheckBox();
		Combo_CoordinateUnit = new DarkUIComboBox();
		GeocentricCoordLabel = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		CB_AltitudeInFeet = new DarkCheckBox();
		Combo_GroundSpeedUnit = new DarkUIComboBox();
		GB_PauseBehaviour = new DarkGroupBox();
		CB_DVViewerPauseBehaviour = new DarkUIComboBox();
		CB_AirDockPauseBehaviour = new DarkUIComboBox();
		DarkLabel4 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		CB_LogDebugInfoToFile = new DarkCheckBox();
		TB_Navigation_ThresholdDistanceDeg = new DarkUITextBox();
		TB_Navigation_MaxDistanceNM = new DarkUITextBox();
		Label8 = new DarkLabel();
		Label7 = new DarkLabel();
		CB_AllowPowerScemeSwitch = new DarkCheckBox();
		CB_UnitStatusImage = new DarkCheckBox();
		Button_ResetWindowPlacement = new DarkUIButton();
		CB_ZoomOnCursor = new DarkCheckBox();
		CB_MessageLogInWindow = new DarkCheckBox();
		CB_UseAutosave = new DarkCheckBox();
		TabPage4 = new TabPage();
		CB_DrawOutlines = new DarkCheckBox();
		DarkLabel_0 = new DarkLabel();
		TB_Flower_Zoom = new TrackBar();
		DarkLabel9 = new DarkLabel();
		TB_Rectangle_Zoom = new TrackBar();
		DarkLabel8 = new DarkLabel();
		TB_Diamond_Zoom = new TrackBar();
		lbl_GU_Zoom = new DarkLabel();
		TB_GrounUnit_Zoom = new TrackBar();
		CP_ShowAU_Behaviour_Bark = new DarkUIComboBox();
		DarkLabel7 = new DarkLabel();
		DarkCheckBox_0 = new DarkCheckBox();
		DarkGroupBox2 = new DarkGroupBox();
		ClearSlugTrail = new DarkUIButton();
		CB_SlugTrail_Unknown = new DarkCheckBox();
		Num_SlugTrailLifetime = new NumericUpDown();
		DarkLabel6 = new DarkLabel();
		CB_SlugTrail_Unfriendly = new DarkCheckBox();
		DarkRichTextBox1 = new DarkRichTextBox();
		DarkLabel5 = new DarkLabel();
		CB_SlugTrail_Hostile = new DarkCheckBox();
		CB_SlugTrail_Neutral = new DarkCheckBox();
		CB_SlugTrail_Friendly = new DarkCheckBox();
		CB_SlugTrail_Own = new DarkCheckBox();
		CB_SlugTrail_UseSlugTrail = new DarkCheckBox();
		Combo_SlugTrailFreq = new DarkUIComboBox();
		CB_ColorDatablocks = new DarkCheckBox();
		Button_SetPersonalMapProfile = new DarkUIButton();
		CB_UsePersonalMapProfile = new DarkCheckBox();
		CP_ShowFlightPlans_Planned = new DarkUIComboBox();
		Label11 = new DarkLabel();
		CP_ShowFlightPlans_Airborne = new DarkUIComboBox();
		Label20 = new DarkLabel();
		CB_ShowDiagnostics = new DarkCheckBox();
		CP_ShowPlottedPaths = new DarkUIComboBox();
		Label6 = new DarkLabel();
		CP_ShowGhostedGroupMembers = new DarkUIComboBox();
		Label5 = new DarkLabel();
		CB_MapSymbols = new DarkUIComboBox();
		Label4 = new DarkLabel();
		CB_MapCursorBox = new DarkUIComboBox();
		Label3 = new DarkLabel();
		CB_RefPointVisibility = new DarkUIComboBox();
		Label2 = new DarkLabel();
		CB_SonobuoyVisibility = new DarkUIComboBox();
		Label1 = new DarkLabel();
		TabPage2 = new TabPage();
		DataGridView1 = new DarkDataGridView();
		MessageType_Hidden = new DataGridViewTextBoxColumn();
		MessageType = new DataGridViewTextBoxColumn();
		MessageLog = new DataGridViewCheckBoxColumn();
		PopUp = new DataGridViewCheckBoxColumn();
		Column_ShowBalloon = new DataGridViewCheckBoxColumn();
		Timescale_X1 = new DataGridViewCheckBoxColumn();
		TabPage3 = new TabPage();
		SFXVolumeLabel = new DarkLabel();
		MusicVolumeLabel = new DarkLabel();
		TB_SFXVolumeBar = new TrackBar();
		TB_MusicVolumeBar = new TrackBar();
		CB_Music = new DarkCheckBox();
		CB_Sounds = new DarkCheckBox();
		TabPage5 = new TabPage();
		GroupBox3 = new DarkGroupBox();
		CB_Autosave = new DarkCheckBox();
		GroupBox2 = new DarkGroupBox();
		CB_FriendlyRangeSymbols = new DarkCheckBox();
		CB_DisplayIlluminationVectors = new DarkCheckBox();
		CB_DisplayContactEmissions = new DarkCheckBox();
		GroupBox1 = new DarkGroupBox();
		CB_ExtraMemoryProtection = new DarkCheckBox();
		CB_DisplayTargetingVectors = new DarkCheckBox();
		CB_DisallowHighPerformancePowerScheme = new DarkCheckBox();
		CB_ShowGhostedGroupMembers = new DarkCheckBox();
		CB_DisplayDatalinks = new DarkCheckBox();
		CB_DisplayMissionAreas = new DarkCheckBox();
		CB_DisplayCountryAndCityNames = new DarkCheckBox();
		CB_CustomFineGrainedNavigation = new DarkCheckBox();
		CB_NonFriendlyRangeSymbols = new DarkCheckBox();
		Label9 = new DarkLabel();
		TabPage6 = new TabPage();
		TB_TacviewPath = new DarkUITextBox();
		Button_TacviewPath = new DarkUIButton();
		DarkLabel1 = new DarkLabel();
		TabPage7 = new TabPage();
		ElementHost1 = new ElementHost();
		OpenFileDialog1 = new OpenFileDialog();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		DarkGroupBox1.SuspendLayout();
		GB_PauseBehaviour.SuspendLayout();
		TabPage4.SuspendLayout();
		((ISupportInitialize)TB_Flower_Zoom).BeginInit();
		((ISupportInitialize)TB_Rectangle_Zoom).BeginInit();
		((ISupportInitialize)TB_Diamond_Zoom).BeginInit();
		((ISupportInitialize)TB_GrounUnit_Zoom).BeginInit();
		DarkGroupBox2.SuspendLayout();
		((ISupportInitialize)Num_SlugTrailLifetime).BeginInit();
		TabPage2.SuspendLayout();
		((ISupportInitialize)DataGridView1).BeginInit();
		TabPage3.SuspendLayout();
		((ISupportInitialize)TB_SFXVolumeBar).BeginInit();
		((ISupportInitialize)TB_MusicVolumeBar).BeginInit();
		TabPage5.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox1.SuspendLayout();
		TabPage6.SuspendLayout();
		TabPage7.SuspendLayout();
		SuspendLayout();
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage4);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Controls.Add(TabPage3);
		TabControl1.Controls.Add(TabPage5);
		TabControl1.Controls.Add(TabPage6);
		TabControl1.Controls.Add(TabPage7);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Font = new Font("Segoe UI", 8f);
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(0, 0);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(702, 669);
		TabControl1.TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(CB_RMB_MoveOrder);
		TabPage1.Controls.Add(DarkGroupBox1);
		TabPage1.Controls.Add(GB_PauseBehaviour);
		TabPage1.Controls.Add(CB_LogDebugInfoToFile);
		TabPage1.Controls.Add(TB_Navigation_ThresholdDistanceDeg);
		TabPage1.Controls.Add(TB_Navigation_MaxDistanceNM);
		TabPage1.Controls.Add(Label8);
		TabPage1.Controls.Add(Label7);
		TabPage1.Controls.Add(CB_AllowPowerScemeSwitch);
		TabPage1.Controls.Add(CB_UnitStatusImage);
		TabPage1.Controls.Add(Button_ResetWindowPlacement);
		TabPage1.Controls.Add(CB_ZoomOnCursor);
		TabPage1.Controls.Add(CB_MessageLogInWindow);
		TabPage1.Controls.Add(CB_UseAutosave);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(694, 641);
		TabPage1.TabIndex = 1;
		TabPage1.Text = "通用";
		CB_RMB_MoveOrder.AutoSize = true;
		CB_RMB_MoveOrder.Location = new Point(8, 370);
		CB_RMB_MoveOrder.Name = "CB_RMB_MoveOrder";
		CB_RMB_MoveOrder.Size = new Size(218, 17);
		CB_RMB_MoveOrder.TabIndex = 29;
		CB_RMB_MoveOrder.Text = "通过鼠标右键点击下达机动命令";
		DarkGroupBox1.Controls.Add(CB_CargoShowUSUnits);
		DarkGroupBox1.Controls.Add(Combo_CoordinateUnit);
		DarkGroupBox1.Controls.Add(GeocentricCoordLabel);
		DarkGroupBox1.Controls.Add(DarkLabel2);
		DarkGroupBox1.Controls.Add(CB_AltitudeInFeet);
		DarkGroupBox1.Controls.Add(Combo_GroundSpeedUnit);
		DarkGroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox1.Location = new Point(8, 174);
		DarkGroupBox1.Name = "DarkGroupBox1";
		DarkGroupBox1.Size = new Size(346, 111);
		DarkGroupBox1.TabIndex = 28;
		DarkGroupBox1.TabStop = false;
		DarkGroupBox1.Text = "显示单位";
		CB_CargoShowUSUnits.AutoSize = true;
		CB_CargoShowUSUnits.Location = new Point(8, 87);
		CB_CargoShowUSUnits.Name = "CB_CargoShowUSUnits";
		CB_CargoShowUSUnits.Size = new Size(180, 17);
		CB_CargoShowUSUnits.TabIndex = 29;
		CB_CargoShowUSUnits.Text = "在货物编辑器中使用美式单位";
		Combo_CoordinateUnit.BackColor = Color.Transparent;
		Combo_CoordinateUnit.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_CoordinateUnit.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_CoordinateUnit.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_CoordinateUnit.FormattingEnabled = true;
		Combo_CoordinateUnit.Location = new Point(230, 65);
		Combo_CoordinateUnit.Name = "Combo_CoordinateUnit";
		Combo_CoordinateUnit.Size = new Size(110, 21);
		Combo_CoordinateUnit.TabIndex = 28;
		GeocentricCoordLabel.AutoSize = true;
		GeocentricCoordLabel.ForeColor = Color.FromArgb(220, 220, 220);
		GeocentricCoordLabel.Location = new Point(6, 65);
		GeocentricCoordLabel.Name = "GeocentricCoordLabel";
		GeocentricCoordLabel.Size = new Size(170, 13);
		GeocentricCoordLabel.TabIndex = 27;
		GeocentricCoordLabel.Text = "Geocentric Coordinate System : ";
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(6, 43);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(218, 13);
		DarkLabel2.TabIndex = 25;
		DarkLabel2.Text = "地面单元/目标的速度单位：";
		CB_AltitudeInFeet.AutoSize = true;
		CB_AltitudeInFeet.Location = new Point(8, 20);
		CB_AltitudeInFeet.Name = "CB_AltitudeInFeet";
		CB_AltitudeInFeet.Size = new Size(136, 17);
		CB_AltitudeInFeet.TabIndex = 6;
		CB_AltitudeInFeet.Text = "以英尺显示海拔高度";
		Combo_GroundSpeedUnit.BackColor = Color.Transparent;
		Combo_GroundSpeedUnit.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_GroundSpeedUnit.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_GroundSpeedUnit.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_GroundSpeedUnit.FormattingEnabled = true;
		Combo_GroundSpeedUnit.Items.AddRange(new object[3] { "节", "千米每小时", "英里每小时" });
		Combo_GroundSpeedUnit.Location = new Point(230, 41);
		Combo_GroundSpeedUnit.Name = "Combo_GroundSpeedUnit";
		Combo_GroundSpeedUnit.Size = new Size(110, 21);
		Combo_GroundSpeedUnit.TabIndex = 26;
		GB_PauseBehaviour.Controls.Add(CB_DVViewerPauseBehaviour);
		GB_PauseBehaviour.Controls.Add(CB_AirDockPauseBehaviour);
		GB_PauseBehaviour.Controls.Add(DarkLabel4);
		GB_PauseBehaviour.Controls.Add(DarkLabel3);
		GB_PauseBehaviour.ForeColor = Color.FromArgb(220, 220, 220);
		GB_PauseBehaviour.Location = new Point(8, 291);
		GB_PauseBehaviour.Name = "GB_PauseBehaviour";
		GB_PauseBehaviour.Size = new Size(346, 77);
		GB_PauseBehaviour.TabIndex = 27;
		GB_PauseBehaviour.TabStop = false;
		GB_PauseBehaviour.Text = "窗口打开时操作";
		CB_DVViewerPauseBehaviour.BackColor = Color.Transparent;
		CB_DVViewerPauseBehaviour.DrawMode = DrawMode.OwnerDrawFixed;
		CB_DVViewerPauseBehaviour.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_DVViewerPauseBehaviour.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_DVViewerPauseBehaviour.FormattingEnabled = true;
		CB_DVViewerPauseBehaviour.Items.AddRange(new object[3] { "自动暂停", "降到实时", "当前推演速度" });
		CB_DVViewerPauseBehaviour.Location = new Point(163, 45);
		CB_DVViewerPauseBehaviour.Name = "CB_DVViewerPauseBehaviour";
		CB_DVViewerPauseBehaviour.Size = new Size(176, 21);
		CB_DVViewerPauseBehaviour.TabIndex = 3;
		CB_AirDockPauseBehaviour.BackColor = Color.Transparent;
		CB_AirDockPauseBehaviour.DrawMode = DrawMode.OwnerDrawFixed;
		CB_AirDockPauseBehaviour.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_AirDockPauseBehaviour.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_AirDockPauseBehaviour.FormattingEnabled = true;
		CB_AirDockPauseBehaviour.Items.AddRange(new object[3] { "自动暂停", "降到实时", "当前推演速度" });
		CB_AirDockPauseBehaviour.Location = new Point(164, 18);
		CB_AirDockPauseBehaviour.Name = "CB_AirDockPauseBehaviour";
		CB_AirDockPauseBehaviour.Size = new Size(175, 21);
		CB_AirDockPauseBehaviour.TabIndex = 2;
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(6, 47);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(93, 13);
		DarkLabel4.TabIndex = 1;
		DarkLabel4.Text = "数据库查看器";
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(6, 20);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(155, 13);
		DarkLabel3.TabIndex = 0;
		DarkLabel3.Text = "空中行动/停靠操作窗口";
		CB_LogDebugInfoToFile.AutoSize = true;
		CB_LogDebugInfoToFile.Location = new Point(8, 119);
		CB_LogDebugInfoToFile.Name = "CB_LogDebugInfoToFile";
		CB_LogDebugInfoToFile.Size = new Size(289, 17);
		CB_LogDebugInfoToFile.TabIndex = 24;
		CB_LogDebugInfoToFile.Text = "将调试信息记录到文件中（仅用于调试）";
		TB_Navigation_ThresholdDistanceDeg.AutoCompleteCustomSource = null;
		TB_Navigation_ThresholdDistanceDeg.AutoCompleteMode = AutoCompleteMode.None;
		TB_Navigation_ThresholdDistanceDeg.AutoCompleteSource = AutoCompleteSource.None;
		TB_Navigation_ThresholdDistanceDeg.BackColor = Color.Transparent;
		TB_Navigation_ThresholdDistanceDeg.Font = new Font("Segoe UI", 8f);
		TB_Navigation_ThresholdDistanceDeg.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Navigation_ThresholdDistanceDeg.Image = null;
		TB_Navigation_ThresholdDistanceDeg.Lines = null;
		TB_Navigation_ThresholdDistanceDeg.Location = new Point(416, 148);
		TB_Navigation_ThresholdDistanceDeg.MaxLength = 32767;
		TB_Navigation_ThresholdDistanceDeg.Multiline = false;
		TB_Navigation_ThresholdDistanceDeg.Name = "TB_Navigation_ThresholdDistanceDeg";
		TB_Navigation_ThresholdDistanceDeg.ReadOnly = false;
		TB_Navigation_ThresholdDistanceDeg.ScrollBars = ScrollBars.None;
		TB_Navigation_ThresholdDistanceDeg.SelectionStart = 0;
		TB_Navigation_ThresholdDistanceDeg.Size = new Size(30, 20);
		TB_Navigation_ThresholdDistanceDeg.TabIndex = 22;
		TB_Navigation_ThresholdDistanceDeg.TextAlign = HorizontalAlignment.Left;
		TB_Navigation_ThresholdDistanceDeg.UseSystemPasswordChar = false;
		TB_Navigation_ThresholdDistanceDeg.WatermarkText = "";
		TB_Navigation_MaxDistanceNM.AutoCompleteCustomSource = null;
		TB_Navigation_MaxDistanceNM.AutoCompleteMode = AutoCompleteMode.None;
		TB_Navigation_MaxDistanceNM.AutoCompleteSource = AutoCompleteSource.None;
		TB_Navigation_MaxDistanceNM.BackColor = Color.Transparent;
		TB_Navigation_MaxDistanceNM.Font = new Font("Segoe UI", 8f);
		TB_Navigation_MaxDistanceNM.ForeColor = Color.FromArgb(189, 189, 189);
		TB_Navigation_MaxDistanceNM.Image = null;
		TB_Navigation_MaxDistanceNM.Lines = null;
		TB_Navigation_MaxDistanceNM.Location = new Point(241, 148);
		TB_Navigation_MaxDistanceNM.MaxLength = 32767;
		TB_Navigation_MaxDistanceNM.Multiline = false;
		TB_Navigation_MaxDistanceNM.Name = "TB_Navigation_MaxDistanceNM";
		TB_Navigation_MaxDistanceNM.ReadOnly = false;
		TB_Navigation_MaxDistanceNM.ScrollBars = ScrollBars.None;
		TB_Navigation_MaxDistanceNM.SelectionStart = 0;
		TB_Navigation_MaxDistanceNM.Size = new Size(41, 20);
		TB_Navigation_MaxDistanceNM.TabIndex = 22;
		TB_Navigation_MaxDistanceNM.TextAlign = HorizontalAlignment.Left;
		TB_Navigation_MaxDistanceNM.UseSystemPasswordChar = false;
		TB_Navigation_MaxDistanceNM.WatermarkText = "";
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(283, 151);
		Label8.Name = "Label8";
		Label8.Size = new Size(137, 13);
		Label8.TabIndex = 21;
		Label8.Text = "阈值距离（度）：";
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(8, 149);
		Label7.Name = "Label7";
		Label7.Size = new Size(231, 13);
		Label7.TabIndex = 20;
		Label7.Text = "细粒度导航，最大距离（海里）：";
		CB_AllowPowerScemeSwitch.AutoSize = true;
		CB_AllowPowerScemeSwitch.Location = new Point(8, 96);
		CB_AllowPowerScemeSwitch.Name = "CB_AllowPowerScemeSwitch";
		CB_AllowPowerScemeSwitch.Size = new Size(295, 17);
		CB_AllowPowerScemeSwitch.TabIndex = 18;
		CB_AllowPowerScemeSwitch.Text = "允许切换到高性能电源想定";
		CB_UnitStatusImage.AutoSize = true;
		CB_UnitStatusImage.Location = new Point(8, 74);
		CB_UnitStatusImage.Name = "CB_UnitStatusImage";
		CB_UnitStatusImage.Size = new Size(155, 17);
		CB_UnitStatusImage.TabIndex = 17;
		CB_UnitStatusImage.Text = "显示单元状态图像";
		Button_ResetWindowPlacement.BackColor = Color.Transparent;
		Button_ResetWindowPlacement.DialogResult = DialogResult.None;
		Button_ResetWindowPlacement.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ResetWindowPlacement.ForeColor = SystemColors.Control;
		Button_ResetWindowPlacement.Location = new Point(9, 411);
		Button_ResetWindowPlacement.Name = "Button_ResetWindowPlacement";
		Button_ResetWindowPlacement.RoundRadius = 0;
		Button_ResetWindowPlacement.Size = new Size(202, 23);
		Button_ResetWindowPlacement.TabIndex = 11;
		Button_ResetWindowPlacement.Text = "重置辅助窗口的位置";
		CB_ZoomOnCursor.AutoSize = true;
		CB_ZoomOnCursor.Location = new Point(8, 52);
		CB_ZoomOnCursor.Name = "CB_ZoomOnCursor";
		CB_ZoomOnCursor.Size = new Size(174, 17);
		CB_ZoomOnCursor.TabIndex = 7;
		CB_ZoomOnCursor.Text = "鼠标控制地图缩放";
		CB_MessageLogInWindow.AutoSize = true;
		CB_MessageLogInWindow.Location = new Point(8, 29);
		CB_MessageLogInWindow.Name = "CB_MessageLogInWindow";
		CB_MessageLogInWindow.Size = new Size(285, 17);
		CB_MessageLogInWindow.TabIndex = 4;
		CB_MessageLogInWindow.Text = "消息日志显示在单独的窗口中 [Ctrl + Shift + M]";
		CB_UseAutosave.AutoSize = true;
		CB_UseAutosave.BackColor = Color.FromArgb(39, 39, 39);
		CB_UseAutosave.Location = new Point(8, 7);
		CB_UseAutosave.Name = "CB_UseAutosave";
		CB_UseAutosave.Size = new Size(95, 17);
		CB_UseAutosave.TabIndex = 0;
		CB_UseAutosave.Text = "使用自动保存";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Controls.Add(CB_DrawOutlines);
		TabPage4.Controls.Add(DarkLabel_0);
		TabPage4.Controls.Add(TB_Flower_Zoom);
		TabPage4.Controls.Add(DarkLabel9);
		TabPage4.Controls.Add(TB_Rectangle_Zoom);
		TabPage4.Controls.Add(DarkLabel8);
		TabPage4.Controls.Add(TB_Diamond_Zoom);
		TabPage4.Controls.Add(lbl_GU_Zoom);
		TabPage4.Controls.Add(TB_GrounUnit_Zoom);
		TabPage4.Controls.Add(CP_ShowAU_Behaviour_Bark);
		TabPage4.Controls.Add(DarkLabel7);
		TabPage4.Controls.Add(DarkCheckBox_0);
		TabPage4.Controls.Add(DarkGroupBox2);
		TabPage4.Controls.Add(CB_ColorDatablocks);
		TabPage4.Controls.Add(Button_SetPersonalMapProfile);
		TabPage4.Controls.Add(CB_UsePersonalMapProfile);
		TabPage4.Controls.Add(CP_ShowFlightPlans_Planned);
		TabPage4.Controls.Add(Label11);
		TabPage4.Controls.Add(CP_ShowFlightPlans_Airborne);
		TabPage4.Controls.Add(Label20);
		TabPage4.Controls.Add(CB_ShowDiagnostics);
		TabPage4.Controls.Add(CP_ShowPlottedPaths);
		TabPage4.Controls.Add(Label6);
		TabPage4.Controls.Add(CP_ShowGhostedGroupMembers);
		TabPage4.Controls.Add(Label5);
		TabPage4.Controls.Add(CB_MapSymbols);
		TabPage4.Controls.Add(Label4);
		TabPage4.Controls.Add(CB_MapCursorBox);
		TabPage4.Controls.Add(Label3);
		TabPage4.Controls.Add(CB_RefPointVisibility);
		TabPage4.Controls.Add(Label2);
		TabPage4.Controls.Add(CB_SonobuoyVisibility);
		TabPage4.Controls.Add(Label1);
		TabPage4.Location = new Point(4, 24);
		TabPage4.Name = "TabPage4";
		TabPage4.Padding = new Padding(3);
		TabPage4.Size = new Size(694, 641);
		TabPage4.TabIndex = 4;
		TabPage4.Text = "地图显示";
		CB_DrawOutlines.AutoSize = true;
		CB_DrawOutlines.Location = new Point(240, 423);
		CB_DrawOutlines.Name = "CB_DrawOutlines";
		CB_DrawOutlines.Size = new Size(193, 17);
		CB_DrawOutlines.TabIndex = 50;
		CB_DrawOutlines.Text = "显示文字和图标轮廓（会导致性能下降）";
		DarkLabel_0.AutoSize = true;
		DarkLabel_0.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel_0.Location = new Point(10, 370);
		DarkLabel_0.Name = "DarkLabel10";
		DarkLabel_0.Size = new Size(141, 13);
		DarkLabel_0.TabIndex = 49;
		DarkLabel_0.Text = "星形图标缩放";
		TB_Flower_Zoom.AutoSize = false;
		TB_Flower_Zoom.LargeChange = 20;
		TB_Flower_Zoom.Location = new Point(240, 370);
		TB_Flower_Zoom.Maximum = 100;
		TB_Flower_Zoom.Minimum = 10;
		TB_Flower_Zoom.Name = "TB_Flower_Zoom";
		TB_Flower_Zoom.Size = new Size(239, 31);
		TB_Flower_Zoom.SmallChange = 10;
		TB_Flower_Zoom.TabIndex = 48;
		TB_Flower_Zoom.TickFrequency = 10;
		TB_Flower_Zoom.Value = 20;
		DarkLabel9.AutoSize = true;
		DarkLabel9.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel9.Location = new Point(10, 333);
		DarkLabel9.Name = "DarkLabel9";
		DarkLabel9.Size = new Size(157, 13);
		DarkLabel9.TabIndex = 47;
		DarkLabel9.Text = "矩形图标缩放";
		TB_Rectangle_Zoom.AutoSize = false;
		TB_Rectangle_Zoom.LargeChange = 20;
		TB_Rectangle_Zoom.Location = new Point(240, 333);
		TB_Rectangle_Zoom.Maximum = 100;
		TB_Rectangle_Zoom.Minimum = 10;
		TB_Rectangle_Zoom.Name = "TB_Rectangle_Zoom";
		TB_Rectangle_Zoom.Size = new Size(239, 31);
		TB_Rectangle_Zoom.SmallChange = 10;
		TB_Rectangle_Zoom.TabIndex = 46;
		TB_Rectangle_Zoom.TickFrequency = 10;
		TB_Rectangle_Zoom.Value = 20;
		DarkLabel8.AutoSize = true;
		DarkLabel8.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel8.Location = new Point(10, 296);
		DarkLabel8.Name = "DarkLabel8";
		DarkLabel8.Size = new Size(153, 13);
		DarkLabel8.TabIndex = 45;
		DarkLabel8.Text = "菱形图标缩放";
		TB_Diamond_Zoom.AutoSize = false;
		TB_Diamond_Zoom.LargeChange = 20;
		TB_Diamond_Zoom.Location = new Point(240, 296);
		TB_Diamond_Zoom.Maximum = 100;
		TB_Diamond_Zoom.Minimum = 10;
		TB_Diamond_Zoom.Name = "TB_Diamond_Zoom";
		TB_Diamond_Zoom.Size = new Size(239, 31);
		TB_Diamond_Zoom.SmallChange = 10;
		TB_Diamond_Zoom.TabIndex = 44;
		TB_Diamond_Zoom.TickFrequency = 10;
		TB_Diamond_Zoom.Value = 20;
		lbl_GU_Zoom.AutoSize = true;
		lbl_GU_Zoom.ForeColor = Color.FromArgb(220, 220, 220);
		lbl_GU_Zoom.Location = new Point(10, 259);
		lbl_GU_Zoom.Name = "lbl_GU_Zoom";
		lbl_GU_Zoom.Size = new Size(104, 13);
		lbl_GU_Zoom.TabIndex = 43;
		lbl_GU_Zoom.Text = "地面单元缩放";
		TB_GrounUnit_Zoom.AutoSize = false;
		TB_GrounUnit_Zoom.LargeChange = 20;
		TB_GrounUnit_Zoom.Location = new Point(240, 259);
		TB_GrounUnit_Zoom.Maximum = 100;
		TB_GrounUnit_Zoom.Minimum = 10;
		TB_GrounUnit_Zoom.Name = "TB_GrounUnit_Zoom";
		TB_GrounUnit_Zoom.Size = new Size(239, 31);
		TB_GrounUnit_Zoom.SmallChange = 10;
		TB_GrounUnit_Zoom.TabIndex = 42;
		TB_GrounUnit_Zoom.TickFrequency = 10;
		TB_GrounUnit_Zoom.Value = 20;
		CP_ShowAU_Behaviour_Bark.BackColor = Color.Transparent;
		CP_ShowAU_Behaviour_Bark.DrawMode = DrawMode.OwnerDrawFixed;
		CP_ShowAU_Behaviour_Bark.DropDownStyle = ComboBoxStyle.DropDownList;
		CP_ShowAU_Behaviour_Bark.Font = new Font("Segoe UI", 7f);
		CP_ShowAU_Behaviour_Bark.FormattingEnabled = true;
		CP_ShowAU_Behaviour_Bark.Items.AddRange(new object[3] { "所有", "选定单元", "不显示" });
		CP_ShowAU_Behaviour_Bark.Location = new Point(182, 226);
		CP_ShowAU_Behaviour_Bark.Name = "CP_ShowAU_Behaviour_Bark";
		CP_ShowAU_Behaviour_Bark.Size = new Size(297, 21);
		CP_ShowAU_Behaviour_Bark.TabIndex = 41;
		DarkLabel7.AutoSize = true;
		DarkLabel7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel7.Location = new Point(7, 229);
		DarkLabel7.Name = "DarkLabel7";
		DarkLabel7.Size = new Size(146, 13);
		DarkLabel7.TabIndex = 40;
		DarkLabel7.Text = "显示单元行为威胁";
		DarkCheckBox_0.AutoSize = true;
		DarkCheckBox_0.Location = new Point(10, 492);
		DarkCheckBox_0.Name = "ChkASWNoise";
		DarkCheckBox_0.Size = new Size(332, 17);
		DarkCheckBox_0.TabIndex = 39;
		DarkCheckBox_0.Text = "当对海武器范围打开时显示动态噪音值";
		DarkGroupBox2.Controls.Add(ClearSlugTrail);
		DarkGroupBox2.Controls.Add(CB_SlugTrail_Unknown);
		DarkGroupBox2.Controls.Add(Num_SlugTrailLifetime);
		DarkGroupBox2.Controls.Add(DarkLabel6);
		DarkGroupBox2.Controls.Add(CB_SlugTrail_Unfriendly);
		DarkGroupBox2.Controls.Add(DarkRichTextBox1);
		DarkGroupBox2.Controls.Add(DarkLabel5);
		DarkGroupBox2.Controls.Add(CB_SlugTrail_Hostile);
		DarkGroupBox2.Controls.Add(CB_SlugTrail_Neutral);
		DarkGroupBox2.Controls.Add(CB_SlugTrail_Friendly);
		DarkGroupBox2.Controls.Add(CB_SlugTrail_Own);
		DarkGroupBox2.Controls.Add(CB_SlugTrail_UseSlugTrail);
		DarkGroupBox2.Controls.Add(Combo_SlugTrailFreq);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(10, 521);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(677, 100);
		DarkGroupBox2.TabIndex = 38;
		DarkGroupBox2.TabStop = false;
		ClearSlugTrail.BackColor = Color.Transparent;
		ClearSlugTrail.DialogResult = DialogResult.None;
		ClearSlugTrail.ForeColor = SystemColors.Control;
		ClearSlugTrail.Location = new Point(172, 0);
		ClearSlugTrail.Name = "ClearSlugTrail";
		ClearSlugTrail.RoundRadius = 0;
		ClearSlugTrail.Size = new Size(130, 18);
		ClearSlugTrail.TabIndex = 42;
		ClearSlugTrail.Text = "清空所有当前尾迹";
		CB_SlugTrail_Unknown.AutoSize = true;
		CB_SlugTrail_Unknown.Location = new Point(325, 67);
		CB_SlugTrail_Unknown.Name = "CB_SlugTrail_Unknown";
		CB_SlugTrail_Unknown.Size = new Size(77, 17);
		CB_SlugTrail_Unknown.TabIndex = 44;
		CB_SlugTrail_Unknown.Text = "未知";
		Num_SlugTrailLifetime.BackColor = Color.FromArgb(34, 34, 34);
		Num_SlugTrailLifetime.ForeColor = SystemColors.Info;
		Num_SlugTrailLifetime.Location = new Point(87, 63);
		Num_SlugTrailLifetime.Maximum = new decimal(new int[4] { 1000000, 0, 0, 0 });
		Num_SlugTrailLifetime.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		Num_SlugTrailLifetime.Name = "Num_SlugTrailLifetime";
		Num_SlugTrailLifetime.Size = new Size(132, 22);
		Num_SlugTrailLifetime.TabIndex = 43;
		Num_SlugTrailLifetime.ThousandsSeparator = true;
		Num_SlugTrailLifetime.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		DarkLabel6.AutoSize = true;
		DarkLabel6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel6.Location = new Point(9, 65);
		DarkLabel6.Name = "DarkLabel6";
		DarkLabel6.Size = new Size(72, 13);
		DarkLabel6.TabIndex = 42;
		DarkLabel6.Text = "显示时间(秒)";
		CB_SlugTrail_Unfriendly.AutoSize = true;
		CB_SlugTrail_Unfriendly.Location = new Point(325, 21);
		CB_SlugTrail_Unfriendly.Name = "CB_SlugTrail_Unfriendly";
		CB_SlugTrail_Unfriendly.Size = new Size(80, 17);
		CB_SlugTrail_Unfriendly.TabIndex = 40;
		CB_SlugTrail_Unfriendly.Text = "非友方";
		DarkRichTextBox1.BackColor = Color.FromArgb(60, 63, 65);
		DarkRichTextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkRichTextBox1.Location = new Point(411, 13);
		DarkRichTextBox1.Name = "DarkRichTextBox1";
		DarkRichTextBox1.ReadOnly = true;
		DarkRichTextBox1.Size = new Size(260, 81);
		DarkRichTextBox1.TabIndex = 39;
		DarkRichTextBox1.Text = "通过被探测目标的尾迹参考点来可视化其运动轨迹和最近探测位置。";
		DarkLabel5.AutoSize = true;
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(9, 29);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(60, 13);
		DarkLabel5.TabIndex = 8;
		DarkLabel5.Text = "频率";
		CB_SlugTrail_Hostile.AutoSize = true;
		CB_SlugTrail_Hostile.Location = new Point(325, 44);
		CB_SlugTrail_Hostile.Name = "CB_SlugTrail_Hostile";
		CB_SlugTrail_Hostile.Size = new Size(62, 17);
		CB_SlugTrail_Hostile.TabIndex = 6;
		CB_SlugTrail_Hostile.Text = "敌方";
		CB_SlugTrail_Neutral.AutoSize = true;
		CB_SlugTrail_Neutral.Location = new Point(229, 67);
		CB_SlugTrail_Neutral.Name = "CB_SlugTrail_Neutral";
		CB_SlugTrail_Neutral.Size = new Size(64, 17);
		CB_SlugTrail_Neutral.TabIndex = 5;
		CB_SlugTrail_Neutral.Text = "中立";
		CB_SlugTrail_Friendly.AutoSize = true;
		CB_SlugTrail_Friendly.Location = new Point(229, 44);
		CB_SlugTrail_Friendly.Name = "CB_SlugTrail_Friendly";
		CB_SlugTrail_Friendly.Size = new Size(67, 17);
		CB_SlugTrail_Friendly.TabIndex = 4;
		CB_SlugTrail_Friendly.Text = "友方";
		CB_SlugTrail_Own.AutoSize = true;
		CB_SlugTrail_Own.Location = new Point(229, 21);
		CB_SlugTrail_Own.Name = "CB_SlugTrail_Own";
		CB_SlugTrail_Own.Size = new Size(90, 17);
		CB_SlugTrail_Own.TabIndex = 2;
		CB_SlugTrail_Own.Text = "本方 / 盟友";
		CB_SlugTrail_UseSlugTrail.AutoSize = true;
		CB_SlugTrail_UseSlugTrail.Location = new Point(9, -1);
		CB_SlugTrail_UseSlugTrail.Name = "CB_SlugTrail_UseSlugTrail";
		CB_SlugTrail_UseSlugTrail.Size = new Size(151, 17);
		CB_SlugTrail_UseSlugTrail.TabIndex = 1;
		CB_SlugTrail_UseSlugTrail.Text = "目标和单元尾迹";
		Combo_SlugTrailFreq.BackColor = Color.Transparent;
		Combo_SlugTrailFreq.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_SlugTrailFreq.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_SlugTrailFreq.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_SlugTrailFreq.FormattingEnabled = true;
		Combo_SlugTrailFreq.Items.AddRange(new object[3] { "每5秒", "每15秒", "每60秒" });
		Combo_SlugTrailFreq.Location = new Point(87, 27);
		Combo_SlugTrailFreq.Name = "Combo_SlugTrailFreq";
		Combo_SlugTrailFreq.Size = new Size(132, 21);
		Combo_SlugTrailFreq.TabIndex = 0;
		CB_ColorDatablocks.AutoSize = true;
		CB_ColorDatablocks.Location = new Point(10, 446);
		CB_ColorDatablocks.Name = "CB_ColorDatablocks";
		CB_ColorDatablocks.Size = new Size(146, 17);
		CB_ColorDatablocks.TabIndex = 37;
		CB_ColorDatablocks.Text = "单元信息按分方颜色显示";
		Button_SetPersonalMapProfile.BackColor = Color.Transparent;
		Button_SetPersonalMapProfile.DialogResult = DialogResult.None;
		Button_SetPersonalMapProfile.ForeColor = SystemColors.Control;
		Button_SetPersonalMapProfile.Location = new Point(492, 492);
		Button_SetPersonalMapProfile.Name = "Button_SetPersonalMapProfile";
		Button_SetPersonalMapProfile.RoundRadius = 0;
		Button_SetPersonalMapProfile.Size = new Size(195, 23);
		Button_SetPersonalMapProfile.TabIndex = 36;
		Button_SetPersonalMapProfile.Text = "将当前地图选项保存为“个人”";
		CB_UsePersonalMapProfile.AutoSize = true;
		CB_UsePersonalMapProfile.Location = new Point(10, 469);
		CB_UsePersonalMapProfile.Name = "CB_UsePersonalMapProfile";
		CB_UsePersonalMapProfile.Size = new Size(155, 17);
		CB_UsePersonalMapProfile.TabIndex = 35;
		CB_UsePersonalMapProfile.Text = "使用个人地图设置";
		CP_ShowFlightPlans_Planned.BackColor = Color.Transparent;
		CP_ShowFlightPlans_Planned.DrawMode = DrawMode.OwnerDrawFixed;
		CP_ShowFlightPlans_Planned.DropDownStyle = ComboBoxStyle.DropDownList;
		CP_ShowFlightPlans_Planned.Font = new Font("Segoe UI", 7f);
		CP_ShowFlightPlans_Planned.FormattingEnabled = true;
		CP_ShowFlightPlans_Planned.Items.AddRange(new object[5] { "所有", "选定的任务池", "选定的任务包", "所选编队", "不显示" });
		CP_ShowFlightPlans_Planned.Location = new Point(182, 199);
		CP_ShowFlightPlans_Planned.Name = "CP_ShowFlightPlans_Planned";
		CP_ShowFlightPlans_Planned.Size = new Size(297, 21);
		CP_ShowFlightPlans_Planned.TabIndex = 34;
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(7, 202);
		Label11.Name = "Label11";
		Label11.Size = new Size(150, 13);
		Label11.TabIndex = 33;
		Label11.Text = "显示飞行计划（计划）：";
		CP_ShowFlightPlans_Airborne.BackColor = Color.Transparent;
		CP_ShowFlightPlans_Airborne.DrawMode = DrawMode.OwnerDrawFixed;
		CP_ShowFlightPlans_Airborne.DropDownStyle = ComboBoxStyle.DropDownList;
		CP_ShowFlightPlans_Airborne.Font = new Font("Segoe UI", 7f);
		CP_ShowFlightPlans_Airborne.FormattingEnabled = true;
		CP_ShowFlightPlans_Airborne.Items.AddRange(new object[3] { "所有", "选定单元", "不显示" });
		CP_ShowFlightPlans_Airborne.Location = new Point(182, 172);
		CP_ShowFlightPlans_Airborne.Name = "CP_ShowFlightPlans_Airborne";
		CP_ShowFlightPlans_Airborne.Size = new Size(297, 21);
		CP_ShowFlightPlans_Airborne.TabIndex = 32;
		Label20.AutoSize = true;
		Label20.ForeColor = Color.FromArgb(220, 220, 220);
		Label20.Location = new Point(7, 175);
		Label20.Name = "Label20";
		Label20.Size = new Size(169, 13);
		Label20.TabIndex = 31;
		Label20.Text = "显示飞行计划（空中飞机）：";
		CB_ShowDiagnostics.AutoSize = true;
		CB_ShowDiagnostics.Location = new Point(10, 423);
		CB_ShowDiagnostics.Name = "CB_ShowDiagnostics";
		CB_ShowDiagnostics.Size = new Size(118, 17);
		CB_ShowDiagnostics.TabIndex = 29;
		CB_ShowDiagnostics.Text = "显示诊断";
		CP_ShowPlottedPaths.BackColor = Color.Transparent;
		CP_ShowPlottedPaths.DrawMode = DrawMode.OwnerDrawFixed;
		CP_ShowPlottedPaths.DropDownStyle = ComboBoxStyle.DropDownList;
		CP_ShowPlottedPaths.Font = new Font("Segoe UI", 7f);
		CP_ShowPlottedPaths.FormattingEnabled = true;
		CP_ShowPlottedPaths.Items.AddRange(new object[3] { "所有", "选定单元", "不显示" });
		CP_ShowPlottedPaths.Location = new Point(182, 145);
		CP_ShowPlottedPaths.Name = "CP_ShowPlottedPaths";
		CP_ShowPlottedPaths.Size = new Size(297, 21);
		CP_ShowPlottedPaths.TabIndex = 26;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(7, 148);
		Label6.Name = "Label6";
		Label6.Size = new Size(112, 13);
		Label6.TabIndex = 25;
		Label6.Text = "显示绘制的路径：";
		CP_ShowGhostedGroupMembers.BackColor = Color.Transparent;
		CP_ShowGhostedGroupMembers.DrawMode = DrawMode.OwnerDrawFixed;
		CP_ShowGhostedGroupMembers.DropDownStyle = ComboBoxStyle.DropDownList;
		CP_ShowGhostedGroupMembers.Font = new Font("Segoe UI", 7f);
		CP_ShowGhostedGroupMembers.FormattingEnabled = true;
		CP_ShowGhostedGroupMembers.Items.AddRange(new object[3] { "所有编队", "选定的编队", "不显示" });
		CP_ShowGhostedGroupMembers.Location = new Point(182, 118);
		CP_ShowGhostedGroupMembers.Name = "CP_ShowGhostedGroupMembers";
		CP_ShowGhostedGroupMembers.Size = new Size(297, 21);
		CP_ShowGhostedGroupMembers.TabIndex = 27;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(7, 121);
		Label5.Name = "Label5";
		Label5.Size = new Size(169, 13);
		Label5.TabIndex = 24;
		Label5.Text = "显示幻影组成员：";
		CB_MapSymbols.BackColor = Color.Transparent;
		CB_MapSymbols.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MapSymbols.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MapSymbols.Font = new Font("Segoe UI", 7f);
		CB_MapSymbols.FormattingEnabled = true;
		CB_MapSymbols.Items.AddRange(new object[3] { "NTDS + NATO APP-6", "程式化", "定向风格化" });
		CB_MapSymbols.Location = new Point(182, 91);
		CB_MapSymbols.Name = "CB_MapSymbols";
		CB_MapSymbols.Size = new Size(297, 21);
		CB_MapSymbols.TabIndex = 23;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(7, 94);
		Label4.Name = "Label4";
		Label4.Size = new Size(78, 13);
		Label4.TabIndex = 22;
		Label4.Text = "地图符号：";
		CB_MapCursorBox.BackColor = Color.Transparent;
		CB_MapCursorBox.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MapCursorBox.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MapCursorBox.Font = new Font("Segoe UI", 7f);
		CB_MapCursorBox.FormattingEnabled = true;
		CB_MapCursorBox.Items.AddRange(new object[3] { "在光标上显示", "显示在底部", "不显示" });
		CB_MapCursorBox.Location = new Point(182, 64);
		CB_MapCursorBox.Name = "CB_MapCursorBox";
		CB_MapCursorBox.Size = new Size(297, 21);
		CB_MapCursorBox.TabIndex = 21;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(7, 67);
		Label3.Name = "Label3";
		Label3.Size = new Size(162, 13);
		Label3.TabIndex = 20;
		Label3.Text = "地图鼠标数据盒可见性：";
		CB_RefPointVisibility.BackColor = Color.Transparent;
		CB_RefPointVisibility.DrawMode = DrawMode.OwnerDrawFixed;
		CB_RefPointVisibility.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_RefPointVisibility.Font = new Font("Segoe UI", 7f);
		CB_RefPointVisibility.FormattingEnabled = true;
		CB_RefPointVisibility.Items.AddRange(new object[3] { "正常", "小号", "不显示" });
		CB_RefPointVisibility.Location = new Point(182, 37);
		CB_RefPointVisibility.Name = "CB_RefPointVisibility";
		CB_RefPointVisibility.Size = new Size(297, 21);
		CB_RefPointVisibility.TabIndex = 19;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(7, 40);
		Label2.Name = "Label2";
		Label2.Size = new Size(137, 13);
		Label2.TabIndex = 18;
		Label2.Text = "参考点可见性：";
		CB_SonobuoyVisibility.BackColor = Color.Transparent;
		CB_SonobuoyVisibility.DrawMode = DrawMode.OwnerDrawFixed;
		CB_SonobuoyVisibility.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_SonobuoyVisibility.Font = new Font("Segoe UI", 7f);
		CB_SonobuoyVisibility.FormattingEnabled = true;
		CB_SonobuoyVisibility.Items.AddRange(new object[3] { "正常", "透明", "不显示" });
		CB_SonobuoyVisibility.Location = new Point(182, 10);
		CB_SonobuoyVisibility.Name = "CB_SonobuoyVisibility";
		CB_SonobuoyVisibility.Size = new Size(297, 21);
		CB_SonobuoyVisibility.TabIndex = 17;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(7, 13);
		Label1.Name = "Label1";
		Label1.Size = new Size(109, 13);
		Label1.TabIndex = 16;
		Label1.Text = "声纳浮标能见度：";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(DataGridView1);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(694, 641);
		TabPage2.TabIndex = 2;
		TabPage2.Text = "消息日志";
		DataGridView1.AllowUserToAddRows = false;
		DataGridView1.AllowUserToDeleteRows = false;
		DataGridView1.AllowUserToOrderColumns = true;
		DataGridView1.AllowUserToResizeColumns = false;
		DataGridView1.AllowUserToResizeRows = false;
		DataGridView1.BackgroundColor = Color.FromArgb(60, 63, 65);
		DataGridView1.BorderStyle = BorderStyle.None;
		DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DataGridView1.Columns.AddRange(MessageType_Hidden, MessageType, MessageLog, PopUp, Column_ShowBalloon, Timescale_X1);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
		DataGridView1.Dock = DockStyle.Fill;
		DataGridView1.EnableHeadersVisualStyles = false;
		DataGridView1.Location = new Point(3, 3);
		DataGridView1.Name = "DataGridView1";
		DataGridView1.RowHeadersVisible = false;
		DataGridView1.RowHeadersWidth = 62;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DataGridView1.Size = new Size(688, 635);
		DataGridView1.TabIndex = 0;
		MessageType_Hidden.DataPropertyName = "MessageType_Hidden";
		MessageType_Hidden.HeaderText = "MessageType_Hidden";
		MessageType_Hidden.MinimumWidth = 8;
		MessageType_Hidden.Name = "MessageType_Hidden";
		MessageType_Hidden.ReadOnly = true;
		MessageType_Hidden.Visible = false;
		MessageType_Hidden.Width = 150;
		MessageType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		MessageType.DataPropertyName = "MessageType";
		MessageType.HeaderText = "消息类型";
		MessageType.MinimumWidth = 8;
		MessageType.Name = "MessageType";
		MessageType.ReadOnly = true;
		MessageType.Width = 93;
		MessageLog.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		MessageLog.DataPropertyName = "MessageLog";
		MessageLog.HeaderText = "在消息日志上显示";
		MessageLog.MinimumWidth = 8;
		MessageLog.Name = "MessageLog";
		PopUp.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		PopUp.DataPropertyName = "PopUp";
		PopUp.HeaderText = "置顶弹出窗口";
		PopUp.MinimumWidth = 8;
		PopUp.Name = "PopUp";
		Column_ShowBalloon.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Column_ShowBalloon.DataPropertyName = "ShowBalloon";
		Column_ShowBalloon.HeaderText = "显示气泡提示";
		Column_ShowBalloon.MinimumWidth = 8;
		Column_ShowBalloon.Name = "Column_ShowBalloon";
		Timescale_X1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Timescale_X1.DataPropertyName = "TimescaleX1";
		Timescale_X1.HeaderText = "加速比改为1倍";
		Timescale_X1.MinimumWidth = 8;
		Timescale_X1.Name = "Timescale_X1";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(SFXVolumeLabel);
		TabPage3.Controls.Add(MusicVolumeLabel);
		TabPage3.Controls.Add(TB_SFXVolumeBar);
		TabPage3.Controls.Add(TB_MusicVolumeBar);
		TabPage3.Controls.Add(CB_Music);
		TabPage3.Controls.Add(CB_Sounds);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Size = new Size(694, 641);
		TabPage3.TabIndex = 3;
		TabPage3.Text = "音乐/音效";
		SFXVolumeLabel.AutoSize = true;
		SFXVolumeLabel.ForeColor = Color.FromArgb(220, 220, 220);
		SFXVolumeLabel.Location = new Point(278, 67);
		SFXVolumeLabel.Name = "SFXVolumeLabel";
		SFXVolumeLabel.Size = new Size(119, 13);
		SFXVolumeLabel.TabIndex = 17;
		SFXVolumeLabel.Text = "音效音量";
		SFXVolumeLabel.TextAlign = ContentAlignment.TopCenter;
		MusicVolumeLabel.AutoSize = true;
		MusicVolumeLabel.ForeColor = Color.FromArgb(220, 220, 220);
		MusicVolumeLabel.Location = new Point(296, 167);
		MusicVolumeLabel.Name = "MusicVolumeLabel";
		MusicVolumeLabel.Size = new Size(78, 13);
		MusicVolumeLabel.TabIndex = 16;
		MusicVolumeLabel.Text = "音乐音量";
		MusicVolumeLabel.TextAlign = ContentAlignment.TopCenter;
		TB_SFXVolumeBar.Location = new Point(8, 35);
		TB_SFXVolumeBar.Maximum = 100;
		TB_SFXVolumeBar.Name = "TB_SFXVolumeBar";
		TB_SFXVolumeBar.Size = new Size(678, 45);
		TB_SFXVolumeBar.TabIndex = 15;
		TB_SFXVolumeBar.TickFrequency = 5;
		TB_MusicVolumeBar.Location = new Point(8, 135);
		TB_MusicVolumeBar.Maximum = 100;
		TB_MusicVolumeBar.Name = "TB_MusicVolumeBar";
		TB_MusicVolumeBar.Size = new Size(678, 45);
		TB_MusicVolumeBar.TabIndex = 14;
		TB_MusicVolumeBar.TickFrequency = 5;
		CB_Music.AutoSize = true;
		CB_Music.Location = new Point(8, 112);
		CB_Music.Name = "CB_Music";
		CB_Music.Size = new Size(143, 17);
		CB_Music.TabIndex = 7;
		CB_Music.Text = "使用背景音乐";
		CB_Sounds.AutoSize = true;
		CB_Sounds.Location = new Point(8, 12);
		CB_Sounds.Name = "CB_Sounds";
		CB_Sounds.Size = new Size(117, 17);
		CB_Sounds.TabIndex = 6;
		CB_Sounds.Text = "使用声音";
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		TabPage5.Controls.Add(GroupBox3);
		TabPage5.Controls.Add(GroupBox2);
		TabPage5.Controls.Add(GroupBox1);
		TabPage5.Controls.Add(Label9);
		TabPage5.Location = new Point(4, 24);
		TabPage5.Name = "TabPage5";
		TabPage5.Padding = new Padding(3);
		TabPage5.Size = new Size(694, 641);
		TabPage5.TabIndex = 5;
		TabPage5.Text = "推演速度";
		GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox3.Controls.Add(CB_Autosave);
		GroupBox3.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox3.Location = new Point(0, 320);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(694, 46);
		GroupBox3.TabIndex = 7;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "可选：这些是非常有用的功能，可以在禁用时释放额外的CPU周期以执行推演";
		CB_Autosave.Location = new Point(10, 18);
		CB_Autosave.Name = "CB_Autosave";
		CB_Autosave.Size = new Size(660, 17);
		CB_Autosave.TabIndex = 0;
		CB_Autosave.Text = "自动保存：以20秒时间间隔保存当前想定到 Scenarios/Autosaves/\"当前想定名称\"";
		GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox2.Controls.Add(CB_FriendlyRangeSymbols);
		GroupBox2.Controls.Add(CB_DisplayIlluminationVectors);
		GroupBox2.Controls.Add(CB_DisplayContactEmissions);
		GroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox2.Location = new Point(0, 236);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(694, 78);
		GroupBox2.TabIndex = 6;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "建议：禁用这些设置可以提高大型想定或在高时间压缩下运行的小想定中的速度";
		CB_FriendlyRangeSymbols.AutoSize = true;
		CB_FriendlyRangeSymbols.Location = new Point(10, 17);
		CB_FriendlyRangeSymbols.Name = "CB_FriendlyRangeSymbols";
		CB_FriendlyRangeSymbols.Size = new Size(144, 17);
		CB_FriendlyRangeSymbols.TabIndex = 0;
		CB_FriendlyRangeSymbols.Text = "友军的范围符号";
		CB_DisplayIlluminationVectors.AutoSize = true;
		CB_DisplayIlluminationVectors.Location = new Point(10, 36);
		CB_DisplayIlluminationVectors.Name = "CB_DisplayIlluminationVectors";
		CB_DisplayIlluminationVectors.Size = new Size(167, 17);
		CB_DisplayIlluminationVectors.TabIndex = 0;
		CB_DisplayIlluminationVectors.Text = "显示照射矢量";
		CB_DisplayContactEmissions.AutoSize = true;
		CB_DisplayContactEmissions.Location = new Point(10, 55);
		CB_DisplayContactEmissions.Name = "CB_DisplayContactEmissions";
		CB_DisplayContactEmissions.Size = new Size(172, 17);
		CB_DisplayContactEmissions.TabIndex = 0;
		CB_DisplayContactEmissions.Text = "显示所有目标辐射";
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox1.Controls.Add(CB_ExtraMemoryProtection);
		GroupBox1.Controls.Add(CB_DisplayTargetingVectors);
		GroupBox1.Controls.Add(CB_DisallowHighPerformancePowerScheme);
		GroupBox1.Controls.Add(CB_ShowGhostedGroupMembers);
		GroupBox1.Controls.Add(CB_DisplayDatalinks);
		GroupBox1.Controls.Add(CB_DisplayMissionAreas);
		GroupBox1.Controls.Add(CB_DisplayCountryAndCityNames);
		GroupBox1.Controls.Add(CB_CustomFineGrainedNavigation);
		GroupBox1.Controls.Add(CB_NonFriendlyRangeSymbols);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(0, 31);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(694, 199);
		GroupBox1.TabIndex = 5;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "强烈推荐：这些设置对速度有很大影响，应取消选择";
		CB_ExtraMemoryProtection.AutoSize = true;
		CB_ExtraMemoryProtection.Location = new Point(10, 21);
		CB_ExtraMemoryProtection.Name = "CB_ExtraMemoryProtection";
		CB_ExtraMemoryProtection.Size = new Size(151, 17);
		CB_ExtraMemoryProtection.TabIndex = 1;
		CB_ExtraMemoryProtection.Text = "额外的内存保护";
		CB_DisplayTargetingVectors.AutoSize = true;
		CB_DisplayTargetingVectors.Location = new Point(10, 116);
		CB_DisplayTargetingVectors.Name = "CB_DisplayTargetingVectors";
		CB_DisplayTargetingVectors.Size = new Size(171, 17);
		CB_DisplayTargetingVectors.TabIndex = 0;
		CB_DisplayTargetingVectors.Text = "显示所有定位向量";
		CB_DisallowHighPerformancePowerScheme.AutoSize = true;
		CB_DisallowHighPerformancePowerScheme.Location = new Point(10, 173);
		CB_DisallowHighPerformancePowerScheme.Name = "CB_DisallowHighPerformancePowerScheme";
		CB_DisallowHighPerformancePowerScheme.Size = new Size(310, 17);
		CB_DisallowHighPerformancePowerScheme.TabIndex = 0;
		CB_DisallowHighPerformancePowerScheme.Text = "禁止切换到高性能电源想定";
		CB_ShowGhostedGroupMembers.AutoSize = true;
		CB_ShowGhostedGroupMembers.Location = new Point(10, 154);
		CB_ShowGhostedGroupMembers.Name = "CB_ShowGhostedGroupMembers";
		CB_ShowGhostedGroupMembers.Size = new Size(185, 17);
		CB_ShowGhostedGroupMembers.TabIndex = 0;
		CB_ShowGhostedGroupMembers.Text = "显示隐藏组成员";
		CB_DisplayDatalinks.AutoSize = true;
		CB_DisplayDatalinks.Location = new Point(10, 135);
		CB_DisplayDatalinks.Name = "CB_DisplayDatalinks";
		CB_DisplayDatalinks.Size = new Size(128, 17);
		CB_DisplayDatalinks.TabIndex = 0;
		CB_DisplayDatalinks.Text = "显示所有数据链接";
		CB_DisplayMissionAreas.AutoSize = true;
		CB_DisplayMissionAreas.Location = new Point(10, 97);
		CB_DisplayMissionAreas.Name = "CB_DisplayMissionAreas";
		CB_DisplayMissionAreas.Size = new Size(202, 17);
		CB_DisplayMissionAreas.TabIndex = 0;
		CB_DisplayMissionAreas.Text = "显示所有任务区域/路径";
		CB_DisplayCountryAndCityNames.AutoSize = true;
		CB_DisplayCountryAndCityNames.Location = new Point(10, 78);
		CB_DisplayCountryAndCityNames.Name = "CB_DisplayCountryAndCityNames";
		CB_DisplayCountryAndCityNames.Size = new Size(184, 17);
		CB_DisplayCountryAndCityNames.TabIndex = 0;
		CB_DisplayCountryAndCityNames.Text = "显示国家和城市名称";
		CB_CustomFineGrainedNavigation.AutoSize = true;
		CB_CustomFineGrainedNavigation.Location = new Point(10, 59);
		CB_CustomFineGrainedNavigation.Name = "CB_CustomFineGrainedNavigation";
		CB_CustomFineGrainedNavigation.Size = new Size(234, 17);
		CB_CustomFineGrainedNavigation.TabIndex = 0;
		CB_CustomFineGrainedNavigation.Text = "自定义细粒度导航设置";
		CB_NonFriendlyRangeSymbols.AutoSize = true;
		CB_NonFriendlyRangeSymbols.Location = new Point(10, 40);
		CB_NonFriendlyRangeSymbols.Name = "CB_NonFriendlyRangeSymbols";
		CB_NonFriendlyRangeSymbols.Size = new Size(168, 17);
		CB_NonFriendlyRangeSymbols.TabIndex = 0;
		CB_NonFriendlyRangeSymbols.Text = "非友军范围符号";
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(5, 10);
		Label9.Name = "Label9";
		Label9.Size = new Size(513, 13);
		Label9.TabIndex = 4;
		Label9.Text = "取消选择CPU密集型功能以减少计算机工作负载并提高推演执行速度：";
		TabPage6.BackColor = Color.FromArgb(60, 63, 65);
		TabPage6.Controls.Add(TB_TacviewPath);
		TabPage6.Controls.Add(Button_TacviewPath);
		TabPage6.Controls.Add(DarkLabel1);
		TabPage6.Location = new Point(4, 24);
		TabPage6.Name = "TabPage6";
		TabPage6.Padding = new Padding(3);
		TabPage6.Size = new Size(694, 641);
		TabPage6.TabIndex = 6;
		TabPage6.Text = "Tacview";
		TB_TacviewPath.AutoCompleteCustomSource = null;
		TB_TacviewPath.AutoCompleteMode = AutoCompleteMode.None;
		TB_TacviewPath.AutoCompleteSource = AutoCompleteSource.None;
		TB_TacviewPath.BackColor = Color.Transparent;
		TB_TacviewPath.ForeColor = Color.FromArgb(189, 189, 189);
		TB_TacviewPath.Image = null;
		TB_TacviewPath.Lines = null;
		TB_TacviewPath.Location = new Point(140, 11);
		TB_TacviewPath.MaxLength = 32767;
		TB_TacviewPath.Multiline = false;
		TB_TacviewPath.Name = "TB_TacviewPath";
		TB_TacviewPath.ReadOnly = false;
		TB_TacviewPath.ScrollBars = ScrollBars.None;
		TB_TacviewPath.SelectionStart = 0;
		TB_TacviewPath.Size = new Size(467, 20);
		TB_TacviewPath.TabIndex = 3;
		TB_TacviewPath.TextAlign = HorizontalAlignment.Left;
		TB_TacviewPath.UseSystemPasswordChar = false;
		TB_TacviewPath.WatermarkText = "";
		Button_TacviewPath.BackColor = Color.Transparent;
		Button_TacviewPath.DialogResult = DialogResult.None;
		Button_TacviewPath.ForeColor = SystemColors.Control;
		Button_TacviewPath.Location = new Point(613, 11);
		Button_TacviewPath.Name = "Button_TacviewPath";
		Button_TacviewPath.RoundRadius = 0;
		Button_TacviewPath.Size = new Size(75, 20);
		Button_TacviewPath.TabIndex = 4;
		Button_TacviewPath.Text = "选择...";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(6, 14);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(134, 13);
		DarkLabel1.TabIndex = 0;
		DarkLabel1.Text = "Tacview可执行文件路径：";
		TabPage7.BackColor = Color.FromArgb(60, 63, 65);
		TabPage7.Controls.Add(ElementHost1);
		TabPage7.Location = new Point(4, 24);
		TabPage7.Name = "TabPage7";
		TabPage7.Padding = new Padding(3);
		TabPage7.Size = new Size(694, 641);
		TabPage7.TabIndex = 7;
		TabPage7.Text = "鼠标悬浮信息";
		ElementHost1.Dock = DockStyle.Fill;
		ElementHost1.Location = new Point(3, 3);
		ElementHost1.Name = "ElementHost1";
		ElementHost1.Size = new Size(688, 635);
		ElementHost1.TabIndex = 0;
		ElementHost1.Text = "ElementHost1";
		ElementHost1.Child = null;
		OpenFileDialog1.FileName = "OpenFileDialog1";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(702, 669);
		base.Controls.Add(TabControl1);
		base.KeyPreview = true;
		base.Location = new Point(0, 0);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(718, 708);
		base.Name = "Options";
		base.ShowIcon = false;
		Text = "选项";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		DarkGroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox1.PerformLayout();
		GB_PauseBehaviour.ResumeLayout(performLayout: false);
		GB_PauseBehaviour.PerformLayout();
		TabPage4.ResumeLayout(performLayout: false);
		TabPage4.PerformLayout();
		((ISupportInitialize)TB_Flower_Zoom).EndInit();
		((ISupportInitialize)TB_Rectangle_Zoom).EndInit();
		((ISupportInitialize)TB_Diamond_Zoom).EndInit();
		((ISupportInitialize)TB_GrounUnit_Zoom).EndInit();
		DarkGroupBox2.ResumeLayout(performLayout: false);
		DarkGroupBox2.PerformLayout();
		((ISupportInitialize)Num_SlugTrailLifetime).EndInit();
		TabPage2.ResumeLayout(performLayout: false);
		((ISupportInitialize)DataGridView1).EndInit();
		TabPage3.ResumeLayout(performLayout: false);
		TabPage3.PerformLayout();
		((ISupportInitialize)TB_SFXVolumeBar).EndInit();
		((ISupportInitialize)TB_MusicVolumeBar).EndInit();
		TabPage5.ResumeLayout(performLayout: false);
		TabPage5.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		TabPage6.ResumeLayout(performLayout: false);
		TabPage6.PerformLayout();
		TabPage7.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void FlushInterruptibleModel(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (!GameGeneral.TacviewPipeEnabled)
		{
			TabControl1.TabPages.RemoveAt(5);
		}
		m_MethodAdapter = SimConfiguration.DefaultGamePreferences;
		_TaskAdapter = new HoverInfoOptions();
		ElementHost1.Child = _TaskAdapter;
		Localization.ApplyToControl(this);
		ForgotInterruptibleModel();
	}

	private void ForgotInterruptibleModel()
	{
		CB_UseAutosave.Checked = m_MethodAdapter.UseAutosave;
		CB_ShowDiagnostics.Checked = m_MethodAdapter.ShowDiagnostics;
		CB_MessageLogInWindow.Checked = m_MethodAdapter.MessageLogInWindow;
		CB_Sounds.Checked = m_MethodAdapter.GameSounds;
		CB_Music.Checked = m_MethodAdapter.GameMusic;
		CB_RMB_MoveOrder.Checked = m_MethodAdapter.RMB_MoveOrder_Enabled;
		TB_SFXVolumeBar.Value = m_MethodAdapter.Int32_0;
		TB_MusicVolumeBar.Value = m_MethodAdapter.MusicVolume;
		CB_AltitudeInFeet.Checked = m_MethodAdapter.ShowAltitudeInFeet;
		CB_CargoShowUSUnits.Checked = m_MethodAdapter.ShowUSUnitsForEditCargo;
		Combo_GroundSpeedUnit.SelectedIndex = (int)m_MethodAdapter.GroundUnitsSpeedUnit;
		Combo_CoordinateUnit.Visible = false;
		GeocentricCoordLabel.Visible = false;
		CB_ZoomOnCursor.Checked = m_MethodAdapter.ZoomOnCursor;
		CB_SonobuoyVisibility.SelectedIndex = (int)m_MethodAdapter.SonobuoyVisibility;
		CB_RefPointVisibility.SelectedIndex = (int)m_MethodAdapter.RefPointVisibility;
		CB_MapSymbols.SelectedIndex = (int)m_MethodAdapter.MapSymbolsSet;
		CB_MapCursorBox.SelectedIndex = (int)m_MethodAdapter.MapCursorBox;
		CP_ShowGhostedGroupMembers.SelectedIndex = (int)m_MethodAdapter.ShowGhostedGroupMembers;
		CP_ShowPlottedPaths.SelectedIndex = (int)m_MethodAdapter.ShowPlottedPaths;
		CP_ShowFlightPlans_Airborne.SelectedIndex = (int)m_MethodAdapter.ShowFlightPlans_Airborne;
		CP_ShowFlightPlans_Planned.SelectedIndex = (int)m_MethodAdapter.ShowFlightPlans_Planned;
		CP_ShowAU_Behaviour_Bark.SelectedIndex = (int)m_MethodAdapter.ShowAU_Behaviour_Bark;
		TB_Navigation_MaxDistanceNM.Text = Conversions.ToString(m_MethodAdapter.NavigationMaxDistanceNMSetting);
		TB_Navigation_ThresholdDistanceDeg.Text = Conversions.ToString(m_MethodAdapter.NavigationThresholdDistanceDegSetting);
		CB_LogDebugInfoToFile.Checked = m_MethodAdapter.LogDebugInfoToFile;
		CB_UnitStatusImage.Checked = m_MethodAdapter.UnitStatusImage;
		CB_RMB_MoveOrder.Checked = m_MethodAdapter.RMB_MoveOrder_Enabled;
		CB_DrawOutlines.Checked = m_MethodAdapter.PlacenameVisibility;
		CB_AllowPowerScemeSwitch.Enabled = RecordThreadBridge.InvokeInterruptibleConnection();
		CB_AllowPowerScemeSwitch.Checked = m_MethodAdapter.AllowPowerPlanSwitch && RecordThreadBridge.InvokeInterruptibleConnection();
		CB_UsePersonalMapProfile.Checked = m_MethodAdapter.UsePersonalMapProfile;
		CB_ColorDatablocks.Checked = Client.CurrentMapProfile.ColorDatablocks;
		TB_GrounUnit_Zoom.Value = m_MethodAdapter.GroundUnitZoom;
		CB_AirDockPauseBehaviour.SelectedIndex = (byte)m_MethodAdapter.PauseOnAirDockOps;
		CB_DVViewerPauseBehaviour.SelectedIndex = (byte)m_MethodAdapter.PauseOnDBView;
		m_MethodAdapter.PauseOnAirDockOps = (SimConfiguration.WindowPauseBehaviour)CB_AirDockPauseBehaviour.SelectedIndex;
		CB_SlugTrail_UseSlugTrail.Checked = m_MethodAdapter.SlugTrail_Use;
		CB_SlugTrail_Friendly.Checked = m_MethodAdapter.SlugTrail_Friendly;
		CB_SlugTrail_Hostile.Checked = m_MethodAdapter.SlugTrail_Hostile;
		try
		{
			Num_SlugTrailLifetime.Value = new decimal(m_MethodAdapter.SlugTrail_LifeTime);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Num_SlugTrailLifetime.Value = 1m;
			ProjectData.ClearProjectError();
		}
		CB_SlugTrail_Unfriendly.Checked = m_MethodAdapter.SlugTrail_Unfriendly;
		CB_SlugTrail_Unknown.Checked = m_MethodAdapter.SlugTrail_UnKnown;
		CB_SlugTrail_Neutral.Checked = m_MethodAdapter.SlugTrail_Neutral;
		CB_SlugTrail_Own.Checked = m_MethodAdapter.SlugTrail_OwnAndAllied;
		Combo_SlugTrailFreq.SelectedIndex = (int)m_MethodAdapter.SlugTrailTimeFrequency;
		DarkCheckBox_0.Checked = Client.CurrentMapProfile.ShowDynamicNoiseSignature;
		CollectInterruptibleModel();
		CB_NonFriendlyRangeSymbols.Checked = Client.CurrentMapProfile.ShowNonFriendly;
		if (m_MethodAdapter.NavigationMaxDistanceNMSetting == 8f && (double)m_MethodAdapter.NavigationThresholdDistanceDegSetting == 0.5)
		{
			CB_CustomFineGrainedNavigation.Checked = false;
			CB_CustomFineGrainedNavigation.Text = "Custom fine-grained navigation settings [CUSTOM VALUES ARE ALREADY EQUIVALENT TO DEFAULT ONES]";
			CB_CustomFineGrainedNavigation.Enabled = false;
		}
		else
		{
			CB_CustomFineGrainedNavigation.Checked = true;
			CB_CustomFineGrainedNavigation.Text = "Custom fine-grained navigation settings ";
			CB_CustomFineGrainedNavigation.Enabled = true;
		}
		CB_DisplayCountryAndCityNames.Checked = m_MethodAdapter.PlacenameVisibility;
		if (SimConfiguration.DefaultGamePreferences.ShowMissionArea == Game.GamePreferences.ObjectVisibilitySetting.All)
		{
			CB_DisplayMissionAreas.Checked = true;
			CB_DisplayMissionAreas.Text = "显示所有任务区域/路径";
			CB_DisplayMissionAreas.Enabled = true;
		}
		else
		{
			CB_DisplayMissionAreas.Checked = false;
			CB_DisplayMissionAreas.Text = "Display all mission areas / courses [CUSTOM VALUE SET IN 'MAP DISPLAY' IS ALREADY EQUIVALENT TO DEFAULT ONE]";
			CB_DisplayMissionAreas.Enabled = false;
		}
		CB_DisplayTargetingVectors.Checked = Client.CurrentMapProfile.ShowTargetingVectors == MapProfile._ShowElement.All;
		CB_DisplayDatalinks.Checked = Client.CurrentMapProfile.ShowDatalinks == MapProfile._ShowElement.All;
		if (m_MethodAdapter.ShowGhostedGroupMembers != 0 && m_MethodAdapter.ShowGhostedGroupMembers != Game.GamePreferences.GhostedGroupMembersVisibilitySetting.SelectedUnit)
		{
			CB_ShowGhostedGroupMembers.Checked = false;
			CB_ShowGhostedGroupMembers.Text = "Show ghosted group members [CUSTOM VALUE SET IN 'MAP DISPLAY' IS ALREADY EQUIVALENT TO DEFAULT ONE]";
			CB_ShowGhostedGroupMembers.Enabled = false;
		}
		else
		{
			CB_ShowGhostedGroupMembers.Checked = true;
			CB_ShowGhostedGroupMembers.Text = "显示隐藏组成员";
			CB_ShowGhostedGroupMembers.Enabled = true;
		}
		CB_DisallowHighPerformancePowerScheme.Enabled = RecordThreadBridge.InvokeInterruptibleConnection();
		CB_DisallowHighPerformancePowerScheme.Checked = !m_MethodAdapter.AllowPowerPlanSwitch && RecordThreadBridge.InvokeInterruptibleConnection();
		CB_FriendlyRangeSymbols.Checked = Client.CurrentMapProfile.ShowRangeSymbols == MapProfile._ShowElement.All;
		CB_DisplayIlluminationVectors.Checked = Client.CurrentMapProfile.ShowIlluminationVectors == MapProfile._ShowElement.All;
		CB_DisplayContactEmissions.Checked = Client.CurrentMapProfile.ShowContactEmissions == MapProfile._ShowElement.All;
		CB_Autosave.Checked = m_MethodAdapter.UseAutosave;
		if (!string.IsNullOrEmpty(SimConfiguration.DefaultGamePreferences.TacviewExePath))
		{
			TB_TacviewPath.Text = SimConfiguration.DefaultGamePreferences.TacviewExePath;
		}
		QueryInterruptibleAdvisor(TB_GrounUnit_Zoom, m_MethodAdapter.GroundUnitZoom);
		QueryInterruptibleAdvisor(TB_Diamond_Zoom, m_MethodAdapter.DiamondZoom);
		QueryInterruptibleAdvisor(TB_Rectangle_Zoom, m_MethodAdapter.RectangleZoom);
		QueryInterruptibleAdvisor(TB_Flower_Zoom, m_MethodAdapter.FlowerZoom);
	}

	private void CollectInterruptibleModel()
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("MessageType_Hidden", typeof(string));
		dataTable.Columns.Add("MessageType", typeof(string));
		dataTable.Columns.Add("MessageLog", typeof(bool));
		dataTable.Columns.Add("PopUp", typeof(bool));
		dataTable.Columns.Add("ShowBalloon", typeof(bool));
		dataTable.Columns.Add("TimescaleX1", typeof(bool));
		foreach (LoggedMessage.MessageType key in SimConfiguration.DefaultGamePreferences.MessageLogSettings.Keys)
		{
			if ((key != LoggedMessage.MessageType.CommsIsolatedMessage || Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.CommsDisruption)) && key != LoggedMessage.MessageType.UnguidedWeaponModifiers)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["MessageType_Hidden"] = key.ToString();
				dataRow["MessageType"] = Misc.ToEnglishString(key);
				dataRow["MessageLog"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].ShowOnMessageLog;
				dataRow["PopUp"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].PopUp;
				dataRow["ShowBalloon"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].ShowBaloon;
				dataRow["TimescaleX1"] = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key].bool_0;
				dataTable.Rows.Add(dataRow);
			}
		}
		DataGridView1.DataSource = dataTable;
	}

	private void OrderInterruptibleModel(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void RegisterInterruptibleModel(object sender, EventArgs e)
	{
		WindowPlacement.WindowPlacementSettings.Clear();
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
		DarkMessageBox.ShowInformation("辅助窗口的位置和大小已重置为默认值", "");
	}

	private void ManageInterruptibleModel(object sender, FormClosingEventArgs e)
	{
		ConnectInterruptibleAdvisor();
		MoveInterruptibleAdvisor();
		SimConfiguration.SaveSettings(WindowPlacement.WindowPlacementSettings, Client.RecentFilenames);
		Hide();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void RevertInterruptibleModel(object sender, EventArgs e)
	{
		m_ServiceAdapter = true;
		ForgotInterruptibleModel();
	}

	private void CountInterruptibleAdvisor(object sender, EventArgs e)
	{
		ConnectInterruptibleAdvisor();
		ForgotInterruptibleModel();
	}

	private void CustomizeInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_SystemAdapter = true;
		ForgotInterruptibleModel();
	}

	private void CloneInterruptibleAdvisor(object sender, EventArgs e)
	{
		MoveInterruptibleAdvisor();
		ForgotInterruptibleModel();
	}

	private void ConnectInterruptibleAdvisor()
	{
		if (m_ServiceAdapter)
		{
			m_ServiceAdapter = false;
			if (!string.IsNullOrEmpty(TB_Navigation_MaxDistanceNM.Text) && Versioned.IsNumeric(TB_Navigation_MaxDistanceNM.Text))
			{
				if (Conversions.ToSingle(TB_Navigation_MaxDistanceNM.Text) != Client.CurrentScenario.Navigation_FinegrainedMaxDistance)
				{
					DarkMessageBox.ShowWarning("重要的提示！您已选择使用细粒度导航到距离达" + TB_Navigation_MaxDistanceNM.Text + "海里，并寻找路径达" + TB_Navigation_ThresholdDistanceDeg.Text + " 度在开始和结束点外。细粒度导航将非常耗时，默认设置是8海里和0.5度。", "");
				}
				m_MethodAdapter.NavigationMaxDistanceNMSetting = Conversions.ToSingle(TB_Navigation_MaxDistanceNM.Text);
				if (!Information.IsNothing(Client.CurrentScenario))
				{
					Client.CurrentScenario.Navigation_FinegrainedMaxDistance = Conversions.ToSingle(TB_Navigation_MaxDistanceNM.Text);
				}
			}
			else
			{
				m_MethodAdapter.NavigationMaxDistanceNMSetting = 0f;
				if (!Information.IsNothing(Client.CurrentScenario))
				{
					Client.CurrentScenario.Navigation_FinegrainedMaxDistance = 0f;
				}
				TB_Navigation_MaxDistanceNM.Text = "0";
			}
		}
		else
		{
			m_ServiceAdapter = false;
		}
	}

	private void MoveInterruptibleAdvisor()
	{
		if (m_SystemAdapter)
		{
			m_SystemAdapter = false;
			if (!string.IsNullOrEmpty(TB_Navigation_ThresholdDistanceDeg.Text) && Versioned.IsNumeric(TB_Navigation_ThresholdDistanceDeg.Text))
			{
				if (Conversions.ToSingle(TB_Navigation_ThresholdDistanceDeg.Text) != Client.CurrentScenario.Navigation_FinegrainedThresholdDistance)
				{
					DarkMessageBox.ShowWarning("重要的提示！您已选择使用细粒度导航到距离达" + TB_Navigation_MaxDistanceNM.Text + "海里，并寻找路径达" + TB_Navigation_ThresholdDistanceDeg.Text + " 度在开始和结束点外。细粒度导航将非常耗时，默认设置是8海里和0.5度。", "");
				}
				m_MethodAdapter.NavigationThresholdDistanceDegSetting = Conversions.ToSingle(TB_Navigation_ThresholdDistanceDeg.Text);
				if (!Information.IsNothing(Client.CurrentScenario))
				{
					Client.CurrentScenario.Navigation_FinegrainedThresholdDistance = Conversions.ToSingle(TB_Navigation_ThresholdDistanceDeg.Text);
				}
			}
			else
			{
				m_MethodAdapter.NavigationThresholdDistanceDegSetting = 0f;
				if (!Information.IsNothing(Client.CurrentScenario))
				{
					Client.CurrentScenario.Navigation_FinegrainedThresholdDistance = 0f;
				}
				TB_Navigation_ThresholdDistanceDeg.Text = "0";
			}
		}
		else
		{
			m_SystemAdapter = false;
		}
	}

	private void DeleteInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (!CB_NonFriendlyRangeSymbols.Checked)
		{
			Client.CurrentMapProfile.ShowNonFriendly = false;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void AddInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (!CB_CustomFineGrainedNavigation.Checked)
		{
			m_MethodAdapter.NavigationMaxDistanceNMSetting = 8f;
			m_MethodAdapter.NavigationThresholdDistanceDegSetting = 0.5f;
			Client.CurrentScenario.Navigation_FinegrainedMaxDistance = 8f;
			Client.CurrentScenario.Navigation_FinegrainedThresholdDistance = 0.5f;
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void DestroyInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.PlacenameVisibility = CB_DisplayCountryAndCityNames.Checked;
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void ComputeInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (!CB_DisplayMissionAreas.Checked)
		{
			m_MethodAdapter.ShowMissionArea = Game.GamePreferences.ObjectVisibilitySetting.DontShow;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void PatchInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (CB_DisplayTargetingVectors.Checked)
		{
			Client.CurrentMapProfile.ShowTargetingVectors = MapProfile._ShowElement.All;
		}
		else
		{
			Client.CurrentMapProfile.ShowTargetingVectors = MapProfile._ShowElement.DontShow;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void SelectInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (CB_DisplayDatalinks.Checked)
		{
			Client.CurrentMapProfile.ShowDatalinks = MapProfile._ShowElement.All;
		}
		else
		{
			Client.CurrentMapProfile.ShowDatalinks = MapProfile._ShowElement.DontShow;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void CallInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.AllowPowerPlanSwitch = !CB_DisallowHighPerformancePowerScheme.Checked;
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void LogoutInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (CB_FriendlyRangeSymbols.Checked)
		{
			Client.CurrentMapProfile.ShowRangeSymbols = MapProfile._ShowElement.All;
		}
		else
		{
			Client.CurrentMapProfile.ShowRangeSymbols = MapProfile._ShowElement.DontShow;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void ViewInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (CB_DisplayIlluminationVectors.Checked)
		{
			Client.CurrentMapProfile.ShowIlluminationVectors = MapProfile._ShowElement.All;
		}
		else
		{
			Client.CurrentMapProfile.ShowIlluminationVectors = MapProfile._ShowElement.DontShow;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void ValidateInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (CB_DisplayContactEmissions.Checked)
		{
			Client.CurrentMapProfile.ShowContactEmissions = MapProfile._ShowElement.All;
		}
		else
		{
			Client.CurrentMapProfile.ShowContactEmissions = MapProfile._ShowElement.DontShow;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void LoginInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.UseAutosave = CB_Autosave.Checked;
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void GetInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (!CB_ShowGhostedGroupMembers.Checked)
		{
			m_MethodAdapter.ShowGhostedGroupMembers = Game.GamePreferences.GhostedGroupMembersVisibilitySetting.DontShow;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void WriteInterruptibleAdvisor(object sender, EventArgs e)
	{
		bool num = m_MethodAdapter.AllowPowerPlanSwitch != CB_AllowPowerScemeSwitch.Checked;
		m_MethodAdapter.AllowPowerPlanSwitch = CB_AllowPowerScemeSwitch.Checked;
		if (num)
		{
			if (m_MethodAdapter.AllowPowerPlanSwitch)
			{
				RecordThreadBridge.NewInterruptibleConnection();
			}
			else
			{
				RecordThreadBridge.PushInterruptibleConnection();
			}
		}
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void NewInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.UseAutosave = CB_UseAutosave.Checked;
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void PushInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.PlacenameVisibility = CB_DrawOutlines.Checked;
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void InvokeInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowGhostedGroupMembers = (Game.GamePreferences.GhostedGroupMembersVisibilitySetting)CP_ShowGhostedGroupMembers.SelectedIndex;
		Client.MustRefreshMainForm = true;
		ForgotInterruptibleModel();
	}

	private void SetupInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.LogDebugInfoToFile = CB_LogDebugInfoToFile.Checked;
	}

	private void ExcludeInterruptibleAdvisor(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.ToggleMessageLogInSeparateWindow();
	}

	private void IncludeInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowAltitudeInFeet = CB_AltitudeInFeet.Checked;
	}

	private void SearchInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowUSUnitsForEditCargo = CB_CargoShowUSUnits.Checked;
		if (ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.EditCargoV2_0.RefreshForm();
		}
		if (ItemExporter.ConnectInterruptibleTemplate.EditCargoContainer.Visible)
		{
			ItemExporter.ConnectInterruptibleTemplate.EditCargoContainer.RefreshForm();
		}
	}

	private void EnableInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ZoomOnCursor = CB_ZoomOnCursor.Checked;
	}

	private void ChangeInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.UnitStatusImage = CB_UnitStatusImage.Checked;
	}

	private void InitInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SonobuoyVisibility = (Game.GamePreferences.SonobuoyVisibilitySetting)CB_SonobuoyVisibility.SelectedIndex;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void CheckInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.RefPointVisibility = (Game.GamePreferences.RefPointVisibilitySetting)CB_RefPointVisibility.SelectedIndex;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void ConcatInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.MapCursorBox = (Game.GamePreferences.MapCursorBoxVisibilitySetting)CB_MapCursorBox.SelectedIndex;
	}

	private void InterruptInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.MapSymbolsSet = (Game.GamePreferences.MapSymbolsSetting)CB_MapSymbols.SelectedIndex;
		Client.CacheMapUnitSymbols();
	}

	private void RemoveInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowPlottedPaths = (Game.GamePreferences.PlottedPathsVisibilitySetting)CP_ShowPlottedPaths.SelectedIndex;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void FindInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowDiagnostics = CB_ShowDiagnostics.Checked;
	}

	private void SetInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowFlightPlans_Airborne = (Game.GamePreferences.FlightPlansVisibilitySetting_Airborne)CP_ShowFlightPlans_Airborne.SelectedIndex;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void FillInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowFlightPlans_Planned = (Game.GamePreferences.FlightPlansVisibilitySetting_Planned)CP_ShowFlightPlans_Planned.SelectedIndex;
		Client.MustRefreshMainForm = true;
	}

	private void CalculateInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.ShowAU_Behaviour_Bark = (Game.GamePreferences.Unit_Behaviour_Bark)CP_ShowAU_Behaviour_Bark.SelectedIndex;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
		Client.MustRefreshMainForm = true;
	}

	private void PopInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.GameSounds = CB_Sounds.Checked;
	}

	private void InstantiateInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.GameMusic = CB_Music.Checked;
		if (m_MethodAdapter.GameMusic)
		{
			AuthenticationSingleton.PushInterruptibleSchema();
		}
		else
		{
			AuthenticationSingleton.m_ParamsSingleton.StopPlayingMusic();
		}
	}

	private void CreateInterruptibleAdvisor(object sender, EventArgs e)
	{
		AuthenticationSingleton.m_ParamsSingleton.Volume = TB_MusicVolumeBar.Value;
	}

	private void CompareInterruptibleAdvisor(object sender, EventArgs e)
	{
		AuthenticationSingleton.m_InfoSingleton.Volume = TB_SFXVolumeBar.Value;
	}

	private void ReadInterruptibleAdvisor(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && e.ColumnIndex >= 2)
		{
			DataGridViewRow dataGridViewRow = DataGridView1.Rows[e.RowIndex];
			dataGridViewRow.Cells[e.ColumnIndex].Value = !Conversions.ToBoolean(dataGridViewRow.Cells[e.ColumnIndex].Value);
			string value = Conversions.ToString(dataGridViewRow.Cells[0].Value);
			LoggedMessage.MessageType key = (LoggedMessage.MessageType)Conversions.ToByte(Enum.Parse(typeof(LoggedMessage.MessageType), value, ignoreCase: true));
			LoggedMessage.MessageSettings messageSettings = SimConfiguration.DefaultGamePreferences.MessageLogSettings[key];
			messageSettings.ShowOnMessageLog = Conversions.ToBoolean(dataGridViewRow.Cells[2].Value);
			messageSettings.PopUp = Conversions.ToBoolean(dataGridViewRow.Cells[3].Value);
			messageSettings.ShowBaloon = Conversions.ToBoolean(dataGridViewRow.Cells[4].Value);
			messageSettings.bool_0 = Conversions.ToBoolean(dataGridViewRow.Cells[5].Value);
		}
	}

	private void DisableInterruptibleAdvisor(object sender, EventArgs e)
	{
		OpenFileDialog1.InitialDirectory = ItemExporter.RevertInterruptibleMap.Info.DirectoryPath;
		OpenFileDialog1.Title = "请指定Tacview可执行文件：";
		OpenFileDialog1.DefaultExt = "*.exe";
		OpenFileDialog1.FileName = "*.exe";
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			SimConfiguration.DefaultGamePreferences.TacviewExePath = OpenFileDialog1.FileName;
			TB_TacviewPath.Text = OpenFileDialog1.FileName;
		}
	}

	private void UpdateInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.UsePersonalMapProfile = CB_UsePersonalMapProfile.Checked;
		if (m_MethodAdapter.UsePersonalMapProfile && m_MethodAdapter.PersonalMapProfile == null)
		{
			m_MethodAdapter.PersonalMapProfile = Client.CurrentMapProfile;
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.HandleMapProfileSettingsChange();
	}

	private void InsertInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.PersonalMapProfile = Client.CurrentMapProfile;
	}

	private void PrepareInterruptibleAdvisor(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ColorDatablocks = CB_ColorDatablocks.Checked;
		Client.MustRefreshMainForm = true;
	}

	private void ReflectInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.GroundUnitsSpeedUnit = (Game.GamePreferences.SpeedUnitSetting)Combo_GroundSpeedUnit.SelectedIndex;
		Client.MustRefreshMainForm = true;
	}

	private void VisitInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.PauseOnAirDockOps = (SimConfiguration.WindowPauseBehaviour)CB_AirDockPauseBehaviour.SelectedIndex;
	}

	private void RestartInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.PauseOnDBView = (SimConfiguration.WindowPauseBehaviour)CB_DVViewerPauseBehaviour.SelectedIndex;
	}

	private void TestInterruptibleAdvisor(object sender, EventArgs e)
	{
		if (Combo_CoordinateUnit.SelectedItem != null)
		{
			CoordinateComboMember coordinateComboMember = (CoordinateComboMember)Combo_CoordinateUnit.SelectedItem;
			m_MethodAdapter.GeoCoordinateType = coordinateComboMember.CoordType;
		}
		Client.MustRefreshMainForm = true;
	}

	private void StopInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.RMB_MoveOrder_Enabled = CB_RMB_MoveOrder.Checked;
		Client.MustRefreshMainForm = true;
	}

	private void CancelInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_Use = CB_SlugTrail_UseSlugTrail.Checked;
	}

	private void VerifyInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_Friendly = CB_SlugTrail_Friendly.Checked;
	}

	private void ListInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_Hostile = CB_SlugTrail_Hostile.Checked;
	}

	private void ResolveInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_Unfriendly = CB_SlugTrail_Unfriendly.Checked;
	}

	private void PostInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_UnKnown = CB_SlugTrail_Unknown.Checked;
	}

	private void RunInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_Neutral = CB_SlugTrail_Neutral.Checked;
	}

	private void StartInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_OwnAndAllied = CB_SlugTrail_Own.Checked;
	}

	private void AssetInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrailTimeFrequency = (SlugTrailTimeFrequency)Combo_SlugTrailFreq.SelectedIndex;
	}

	private void PrintInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_LifeTime = Convert.ToInt32(Num_SlugTrailLifetime.Value);
	}

	private void DefineInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.SlugTrail_LifeTime = Convert.ToInt32(Num_SlugTrailLifetime.Value);
	}

	private void PublishInterruptibleAdvisor(object sender, EventArgs e)
	{
		Client.CurrentMapProfile.ShowDynamicNoiseSignature = DarkCheckBox_0.Checked;
	}

	private void AwakeInterruptibleAdvisor(object sender, EventArgs e)
	{
		Client.CurrentSide.RefPoints_Slugtrail.Clear();
	}

	private void QueryInterruptibleAdvisor(TrackBar trackBar_0, int int_0)
	{
		trackBar_0.Value = Math.Min(trackBar_0.Maximum, Math.Max(trackBar_0.Minimum, int_0));
	}

	private void ResetInterruptibleAdvisor(object sender, EventArgs e)
	{
		int num = m_MethodAdapter.GroundUnitZoom - TB_GrounUnit_Zoom.Value;
		m_MethodAdapter.GroundUnitZoom = TB_GrounUnit_Zoom.Value;
		QueryInterruptibleAdvisor(TB_Diamond_Zoom, m_MethodAdapter.DiamondZoom - num);
		QueryInterruptibleAdvisor(TB_Rectangle_Zoom, m_MethodAdapter.RectangleZoom - num);
		QueryInterruptibleAdvisor(TB_Flower_Zoom, m_MethodAdapter.FlowerZoom - num);
		m_MethodAdapter.DiamondZoom = TB_Diamond_Zoom.Value;
		m_MethodAdapter.RectangleZoom = TB_Rectangle_Zoom.Value;
		m_MethodAdapter.FlowerZoom = TB_Flower_Zoom.Value;
		Client.MustRefreshMainForm = true;
	}

	private void MapInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.DiamondZoom = TB_Diamond_Zoom.Value;
		Client.MustRefreshMainForm = true;
	}

	private void SortInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.RectangleZoom = TB_Rectangle_Zoom.Value;
		Client.MustRefreshMainForm = true;
	}

	private void CalcInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.FlowerZoom = TB_Flower_Zoom.Value;
		Client.MustRefreshMainForm = true;
	}

	private void RateInterruptibleAdvisor(object sender, EventArgs e)
	{
		m_MethodAdapter.PlacenameVisibility = CB_DrawOutlines.Checked;
	}
}
