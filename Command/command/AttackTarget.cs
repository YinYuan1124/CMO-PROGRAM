using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AttackTarget : DarkSecondaryFormBase, GInterface9
{
	[CompilerGenerated]
	private sealed class ErrorDecoratorEntry
	{
		public ActiveUnit Local_theAttacker;

		public Func<Warhead, int> _003C_003E9__0;

		internal int TestInterruptibleParam(Warhead CW)
		{
			return CW.GetCarriedWeapon(Local_theAttacker.ParentScen).DBID;
		}
	}

	private IContainer _CandidateRepository;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel policyRepository;

	[AccessedThroughProperty("TabControl4")]
	[CompilerGenerated]
	private DarkUITabControl m_BroadcasterRepository;

	[AccessedThroughProperty("Tab_Target_BySelected")]
	[CompilerGenerated]
	private TabPage identifierRepository;

	[AccessedThroughProperty("Tab_Target_ByAnyone")]
	[CompilerGenerated]
	private TabPage printerRepository;

	[AccessedThroughProperty("LB_Targets")]
	[CompilerGenerated]
	private DarkListView _ParserRepository;

	[AccessedThroughProperty("TV_Allocations_ByAttackersOnly")]
	[CompilerGenerated]
	private DarkTreeView m_AlgoRepository;

	[AccessedThroughProperty("TV_Allocations_ByAnyone")]
	[CompilerGenerated]
	private DarkTreeView _DatabaseRepository;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer _InterceptorRepository;

	[AccessedThroughProperty("TabControl2")]
	[CompilerGenerated]
	private DarkUITabControl productRepository;

	[AccessedThroughProperty("Tab_Attacker_ToSelectedOnly")]
	[CompilerGenerated]
	private TabPage annotationRepository;

	[AccessedThroughProperty("TV_Allocations_ToTargetsOnly")]
	[CompilerGenerated]
	private DarkTreeView m_IteratorRepository;

	[AccessedThroughProperty("Tab_Attacker_ToAnyone")]
	[CompilerGenerated]
	private TabPage m_InitializerRepository;

	[AccessedThroughProperty("TV_Allocations_ToAnyone")]
	[CompilerGenerated]
	private DarkTreeView m_RoleRepository;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_FactoryRepository;

	[AccessedThroughProperty("LB_Attackers")]
	[CompilerGenerated]
	private DarkListView attributeRepository;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	private DarkLabel m_EventRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_AvailableWeapons")]
	private DarkTreeView _GlobalRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Allocate")]
	private DarkUIButton workerRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AllocateAllWeapons")]
	private DarkUIButton _AccountRepository;

	[AccessedThroughProperty("Button_UnitWRA")]
	[CompilerGenerated]
	private DarkUIButton stateRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddAttacker")]
	private DarkUIButton authenticationRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddTarget")]
	private DarkUIButton _ParamsRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveAttacker")]
	private DarkUIButton m_InfoRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveTargets")]
	private DarkUIButton m_HelperRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AllocateSalvo")]
	private DarkUIButton m_MapperRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveWeapons_Target")]
	private DarkUIButton m_ManagerRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveWeapons_Attacker")]
	private DarkUIButton _GetterRepository;

	[AccessedThroughProperty("TableLayoutPanel2")]
	[CompilerGenerated]
	private TableLayoutPanel procRepository;

	[CompilerGenerated]
	[AccessedThroughProperty("Panel3")]
	private Panel decoratorBridge;

	[AccessedThroughProperty("Panel4")]
	[CompilerGenerated]
	private Panel m_ProcessBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Panel5")]
	private Panel threadBridge;

	[AccessedThroughProperty("CB_AllowTimeout")]
	[CompilerGenerated]
	private DarkCheckBox _RuleBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShowAutomaticFireInfo")]
	private DarkCheckBox _CollectionBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearCourse_Attacker")]
	private DarkUIButton _InstanceBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_PlotCourse_Attacker")]
	private DarkUIButton _ObjectBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearCourse_Target")]
	private DarkUIButton parameterBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_PlotCourse_Target")]
	private DarkUIButton m_ExpressionBridge;

	[AccessedThroughProperty("SalvoContextMenu")]
	[CompilerGenerated]
	private DarkContextMenu _DispatcherBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_NumberOfWeapons")]
	private DarkNumericUpDown listenerBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("TSMI_HighAltitudeDetonation")]
	private DarkToolStripMenuItem m_ConfigBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("SplitContainerOuter")]
	private SplitContainer registryBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("SplitContainerInner")]
	private SplitContainer m_DefinitionBridge;

	private bool valBridge;

	public List<Contact> Targets;

	public List<ActiveUnit> Attackers;

	private List<ActiveUnit> _WrapperBridge;

	private int m_ObserverBridge;

	private List<Contact> issuerBridge;

	private int clientBridge;

	private DarkTreeNode dicBridge;

	private int? consumerBridge;

	private int _FacadeBridge;

	private bool proxyBridge;

	private bool m_ReaderBridge;

	private string propertyBridge;

	private WeaponSalvo m_ImporterBridge;

	private Keys[] m_RepositoryBridge;

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return policyRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			policyRepository = value;
		}
	}

	internal DarkUITabControl TabControl4
	{
		[CompilerGenerated]
		get
		{
			return m_BroadcasterRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapSerializer;
			DarkUITabControl broadcasterRepository = m_BroadcasterRepository;
			if (broadcasterRepository != null)
			{
				broadcasterRepository.SelectedIndexChanged -= value2;
			}
			m_BroadcasterRepository = value;
			broadcasterRepository = m_BroadcasterRepository;
			if (broadcasterRepository != null)
			{
				broadcasterRepository.SelectedIndexChanged += value2;
			}
		}
	}

	internal TabPage Tab_Target_BySelected
	{
		[CompilerGenerated]
		get
		{
			return identifierRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			identifierRepository = value;
		}
	}

	internal TabPage Tab_Target_ByAnyone
	{
		[CompilerGenerated]
		get
		{
			return printerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerRepository = value;
		}
	}

	internal DarkListView LB_Targets
	{
		[CompilerGenerated]
		get
		{
			return _ParserRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareSerializer;
			DarkListView parserRepository = _ParserRepository;
			if (parserRepository != null)
			{
				parserRepository.SelectedIndicesChanged -= value2;
			}
			_ParserRepository = value;
			parserRepository = _ParserRepository;
			if (parserRepository != null)
			{
				parserRepository.SelectedIndicesChanged += value2;
			}
		}
	}

	internal DarkTreeView TV_Allocations_ByAttackersOnly
	{
		[CompilerGenerated]
		get
		{
			return m_AlgoRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = RevertSerializer;
			MouseEventHandler value3 = AddRef;
			EventHandler value4 = PatchRef;
			DarkTreeView algoRepository = m_AlgoRepository;
			if (algoRepository != null)
			{
				algoRepository.MouseClick -= value2;
				algoRepository.MouseDoubleClick -= value3;
				algoRepository.SelectedNodesChanged -= value4;
			}
			m_AlgoRepository = value;
			algoRepository = m_AlgoRepository;
			if (algoRepository != null)
			{
				algoRepository.MouseClick += value2;
				algoRepository.MouseDoubleClick += value3;
				algoRepository.SelectedNodesChanged += value4;
			}
		}
	}

	internal DarkTreeView TV_Allocations_ByAnyone
	{
		[CompilerGenerated]
		get
		{
			return _DatabaseRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = ManageSerializer;
			MouseEventHandler value3 = DestroyRef;
			EventHandler value4 = CallRef;
			DarkTreeView databaseRepository = _DatabaseRepository;
			if (databaseRepository != null)
			{
				databaseRepository.MouseClick -= value2;
				databaseRepository.MouseDoubleClick -= value3;
				databaseRepository.SelectedNodesChanged -= value4;
			}
			_DatabaseRepository = value;
			databaseRepository = _DatabaseRepository;
			if (databaseRepository != null)
			{
				databaseRepository.MouseClick += value2;
				databaseRepository.MouseDoubleClick += value3;
				databaseRepository.SelectedNodesChanged += value4;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITabControl TabControl2
	{
		[CompilerGenerated]
		get
		{
			return productRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadSerializer;
			DarkUITabControl darkUITabControl = productRepository;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged -= value2;
			}
			productRepository = value;
			darkUITabControl = productRepository;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged += value2;
			}
		}
	}

	internal TabPage Tab_Attacker_ToSelectedOnly
	{
		[CompilerGenerated]
		get
		{
			return annotationRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			annotationRepository = value;
		}
	}

	internal DarkTreeView TV_Allocations_ToTargetsOnly
	{
		[CompilerGenerated]
		get
		{
			return m_IteratorRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = CustomizeRef;
			MouseEventHandler value3 = ConnectRef;
			EventHandler value4 = ComputeRef;
			DarkTreeView iteratorRepository = m_IteratorRepository;
			if (iteratorRepository != null)
			{
				iteratorRepository.MouseClick -= value2;
				iteratorRepository.MouseDoubleClick -= value3;
				iteratorRepository.SelectedNodesChanged -= value4;
			}
			m_IteratorRepository = value;
			iteratorRepository = m_IteratorRepository;
			if (iteratorRepository != null)
			{
				iteratorRepository.MouseClick += value2;
				iteratorRepository.MouseDoubleClick += value3;
				iteratorRepository.SelectedNodesChanged += value4;
			}
		}
	}

	internal TabPage Tab_Attacker_ToAnyone
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InitializerRepository = value;
		}
	}

	internal DarkTreeView TV_Allocations_ToAnyone
	{
		[CompilerGenerated]
		get
		{
			return m_RoleRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = CountRef;
			MouseEventHandler value3 = MoveRef;
			EventHandler value4 = SelectRef;
			DarkTreeView roleRepository = m_RoleRepository;
			if (roleRepository != null)
			{
				roleRepository.MouseClick -= value2;
				roleRepository.MouseDoubleClick -= value3;
				roleRepository.SelectedNodesChanged -= value4;
			}
			m_RoleRepository = value;
			roleRepository = m_RoleRepository;
			if (roleRepository != null)
			{
				roleRepository.MouseClick += value2;
				roleRepository.MouseDoubleClick += value3;
				roleRepository.SelectedNodesChanged += value4;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_FactoryRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FactoryRepository = value;
		}
	}

	internal DarkListView LB_Attackers
	{
		[CompilerGenerated]
		get
		{
			return attributeRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateSerializer;
			DarkListView darkListView = attributeRepository;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			attributeRepository = value;
			darkListView = attributeRepository;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return m_EventRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventRepository = value;
		}
	}

	internal DarkTreeView TV_AvailableWeapons
	{
		[CompilerGenerated]
		get
		{
			return _GlobalRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = AssetSerializer;
			EventHandler value3 = DeleteRef;
			DarkTreeView globalRepository = _GlobalRepository;
			if (globalRepository != null)
			{
				globalRepository.MouseDoubleClick -= value2;
				globalRepository.SelectedNodesChanged -= value3;
			}
			_GlobalRepository = value;
			globalRepository = _GlobalRepository;
			if (globalRepository != null)
			{
				globalRepository.MouseDoubleClick += value2;
				globalRepository.SelectedNodesChanged += value3;
			}
		}
	}

	internal DarkUIButton Button_Allocate
	{
		[CompilerGenerated]
		get
		{
			return workerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListSerializer;
			DarkUIButton darkUIButton = workerRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			workerRepository = value;
			darkUIButton = workerRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_AllocateAllWeapons
	{
		[CompilerGenerated]
		get
		{
			return _AccountRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostSerializer;
			DarkUIButton accountRepository = _AccountRepository;
			if (accountRepository != null)
			{
				accountRepository.Click -= value2;
			}
			_AccountRepository = value;
			accountRepository = _AccountRepository;
			if (accountRepository != null)
			{
				accountRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_UnitWRA
	{
		[CompilerGenerated]
		get
		{
			return stateRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectSerializer;
			DarkUIButton darkUIButton = stateRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			stateRepository = value;
			darkUIButton = stateRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_AddAttacker
	{
		[CompilerGenerated]
		get
		{
			return authenticationRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitSerializer;
			DarkUIButton darkUIButton = authenticationRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			authenticationRepository = value;
			darkUIButton = authenticationRepository;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_AddTarget
	{
		[CompilerGenerated]
		get
		{
			return _ParamsRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestSerializer;
			DarkUIButton paramsRepository = _ParamsRepository;
			if (paramsRepository != null)
			{
				paramsRepository.Click -= value2;
			}
			_ParamsRepository = value;
			paramsRepository = _ParamsRepository;
			if (paramsRepository != null)
			{
				paramsRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_RemoveAttacker
	{
		[CompilerGenerated]
		get
		{
			return m_InfoRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartSerializer;
			DarkUIButton infoRepository = m_InfoRepository;
			if (infoRepository != null)
			{
				infoRepository.Click -= value2;
			}
			m_InfoRepository = value;
			infoRepository = m_InfoRepository;
			if (infoRepository != null)
			{
				infoRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_RemoveTargets
	{
		[CompilerGenerated]
		get
		{
			return m_HelperRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopSerializer;
			DarkUIButton helperRepository = m_HelperRepository;
			if (helperRepository != null)
			{
				helperRepository.Click -= value2;
			}
			m_HelperRepository = value;
			helperRepository = m_HelperRepository;
			if (helperRepository != null)
			{
				helperRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_AllocateSalvo
	{
		[CompilerGenerated]
		get
		{
			return m_MapperRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelSerializer;
			DarkUIButton mapperRepository = m_MapperRepository;
			if (mapperRepository != null)
			{
				mapperRepository.Click -= value2;
			}
			m_MapperRepository = value;
			mapperRepository = m_MapperRepository;
			if (mapperRepository != null)
			{
				mapperRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_RemoveWeapons_Target
	{
		[CompilerGenerated]
		get
		{
			return m_ManagerRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartSerializer;
			DarkUIButton managerRepository = m_ManagerRepository;
			if (managerRepository != null)
			{
				managerRepository.Click -= value2;
			}
			m_ManagerRepository = value;
			managerRepository = m_ManagerRepository;
			if (managerRepository != null)
			{
				managerRepository.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_RemoveWeapons_Attacker
	{
		[CompilerGenerated]
		get
		{
			return _GetterRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunSerializer;
			DarkUIButton getterRepository = _GetterRepository;
			if (getterRepository != null)
			{
				getterRepository.Click -= value2;
			}
			_GetterRepository = value;
			getterRepository = _GetterRepository;
			if (getterRepository != null)
			{
				getterRepository.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal TableLayoutPanel TableLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TableLayoutPanel TableLayoutPanel2
	{
		[CompilerGenerated]
		get
		{
			return procRepository;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			procRepository = value;
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel3")]
	internal TableLayoutPanel TableLayoutPanel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Panel1")]
	internal Panel Panel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Panel2")]
	internal Panel Panel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Panel Panel3
	{
		[CompilerGenerated]
		get
		{
			return decoratorBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			decoratorBridge = value;
		}
	}

	internal Panel Panel4
	{
		[CompilerGenerated]
		get
		{
			return m_ProcessBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProcessBridge = value;
		}
	}

	internal Panel Panel5
	{
		[CompilerGenerated]
		get
		{
			return threadBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			threadBridge = value;
		}
	}

	internal DarkCheckBox CB_AllowTimeout
	{
		[CompilerGenerated]
		get
		{
			return _RuleBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortSerializer;
			DarkCheckBox ruleBridge = _RuleBridge;
			if (ruleBridge != null)
			{
				ruleBridge.CheckedChanged -= value2;
			}
			_RuleBridge = value;
			ruleBridge = _RuleBridge;
			if (ruleBridge != null)
			{
				ruleBridge.CheckedChanged += value2;
			}
		}
	}

	internal DarkCheckBox CB_ShowAutomaticFireInfo
	{
		[CompilerGenerated]
		get
		{
			return _CollectionBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcSerializer;
			DarkCheckBox collectionBridge = _CollectionBridge;
			if (collectionBridge != null)
			{
				collectionBridge.CheckedChanged -= value2;
			}
			_CollectionBridge = value;
			collectionBridge = _CollectionBridge;
			if (collectionBridge != null)
			{
				collectionBridge.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIButton Button_ClearCourse_Attacker
	{
		[CompilerGenerated]
		get
		{
			return _InstanceBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushSerializer;
			DarkUIButton instanceBridge = _InstanceBridge;
			if (instanceBridge != null)
			{
				instanceBridge.Click -= value2;
			}
			_InstanceBridge = value;
			instanceBridge = _InstanceBridge;
			if (instanceBridge != null)
			{
				instanceBridge.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_PlotCourse_Attacker
	{
		[CompilerGenerated]
		get
		{
			return _ObjectBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateSerializer;
			DarkUIButton objectBridge = _ObjectBridge;
			if (objectBridge != null)
			{
				objectBridge.Click -= value2;
			}
			_ObjectBridge = value;
			objectBridge = _ObjectBridge;
			if (objectBridge != null)
			{
				objectBridge.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ClearCourse_Target
	{
		[CompilerGenerated]
		get
		{
			return parameterBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectSerializer;
			DarkUIButton darkUIButton = parameterBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			parameterBridge = value;
			darkUIButton = parameterBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_PlotCourse_Target
	{
		[CompilerGenerated]
		get
		{
			return m_ExpressionBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotSerializer;
			DarkUIButton expressionBridge = m_ExpressionBridge;
			if (expressionBridge != null)
			{
				expressionBridge.Click -= value2;
			}
			m_ExpressionBridge = value;
			expressionBridge = m_ExpressionBridge;
			if (expressionBridge != null)
			{
				expressionBridge.Click += value2;
			}
		}
	}

	internal DarkNumericUpDown NUD_NumberOfWeapons
	{
		[CompilerGenerated]
		get
		{
			return listenerBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			listenerBridge = value;
		}
	}

	internal DarkToolStripMenuItem TSMI_HighAltitudeDetonation
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderSerializer;
			DarkToolStripMenuItem configBridge = m_ConfigBridge;
			if (configBridge != null)
			{
				configBridge.Click -= value2;
			}
			m_ConfigBridge = value;
			configBridge = m_ConfigBridge;
			if (configBridge != null)
			{
				configBridge.Click += value2;
			}
		}
	}

	internal SplitContainer SplitContainerOuter
	{
		[CompilerGenerated]
		get
		{
			return registryBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			registryBridge = value;
		}
	}

	internal SplitContainer SplitContainerInner
	{
		[CompilerGenerated]
		get
		{
			return m_DefinitionBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DefinitionBridge = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer CheckRef()
	{
		return _InterceptorRepository;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ConcatRef(Timer timer_0)
	{
		EventHandler value = SearchSerializer;
		Timer interceptorRepository = _InterceptorRepository;
		if (interceptorRepository != null)
		{
			interceptorRepository.Tick -= value;
		}
		_InterceptorRepository = timer_0;
		interceptorRepository = _InterceptorRepository;
		if (interceptorRepository != null)
		{
			interceptorRepository.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal DarkContextMenu SearchError()
	{
		return _DispatcherBridge;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void EnableError(DarkContextMenu darkContextMenu_0)
	{
		_DispatcherBridge = darkContextMenu_0;
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _CandidateRepository != null)
			{
				_CandidateRepository.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InvokeSerializer()
	{
		_CandidateRepository = new Container();
		ConcatRef(new Timer(_CandidateRepository));
		TableLayoutPanel1 = new TableLayoutPanel();
		Panel1 = new Panel();
		Button_RemoveAttacker = new DarkUIButton();
		Label1 = new DarkLabel();
		LB_Attackers = new DarkListView();
		Button_UnitWRA = new DarkUIButton();
		Button_AddAttacker = new DarkUIButton();
		Panel5 = new Panel();
		Button_RemoveTargets = new DarkUIButton();
		Button_AddTarget = new DarkUIButton();
		LB_Targets = new DarkListView();
		Label3 = new DarkLabel();
		TableLayoutPanel2 = new TableLayoutPanel();
		Panel2 = new Panel();
		CB_ShowAutomaticFireInfo = new DarkCheckBox();
		CB_AllowTimeout = new DarkCheckBox();
		Button_AllocateSalvo = new DarkUIButton();
		Button_AllocateAllWeapons = new DarkUIButton();
		Label5 = new DarkLabel();
		Button_Allocate = new DarkUIButton();
		NUD_NumberOfWeapons = new DarkNumericUpDown();
		TV_AvailableWeapons = new DarkTreeView();
		TableLayoutPanel3 = new TableLayoutPanel();
		Panel3 = new Panel();
		Button_ClearCourse_Attacker = new DarkUIButton();
		Button_PlotCourse_Attacker = new DarkUIButton();
		Button_RemoveWeapons_Attacker = new DarkUIButton();
		TabControl2 = new DarkUITabControl();
		Tab_Attacker_ToSelectedOnly = new TabPage();
		TV_Allocations_ToTargetsOnly = new DarkTreeView();
		Tab_Attacker_ToAnyone = new TabPage();
		TV_Allocations_ToAnyone = new DarkTreeView();
		Label2 = new DarkLabel();
		Panel4 = new Panel();
		Button_ClearCourse_Target = new DarkUIButton();
		Button_RemoveWeapons_Target = new DarkUIButton();
		Button_PlotCourse_Target = new DarkUIButton();
		TabControl4 = new DarkUITabControl();
		Tab_Target_BySelected = new TabPage();
		TV_Allocations_ByAttackersOnly = new DarkTreeView();
		Tab_Target_ByAnyone = new TabPage();
		TV_Allocations_ByAnyone = new DarkTreeView();
		Label4 = new DarkLabel();
		EnableError(new DarkContextMenu());
		TSMI_HighAltitudeDetonation = new DarkToolStripMenuItem();
		SplitContainerOuter = new SplitContainer();
		SplitContainerInner = new SplitContainer();
		TableLayoutPanel1.SuspendLayout();
		Panel1.SuspendLayout();
		Panel5.SuspendLayout();
		TableLayoutPanel2.SuspendLayout();
		Panel2.SuspendLayout();
		((ISupportInitialize)NUD_NumberOfWeapons).BeginInit();
		TableLayoutPanel3.SuspendLayout();
		Panel3.SuspendLayout();
		TabControl2.SuspendLayout();
		Tab_Attacker_ToSelectedOnly.SuspendLayout();
		Tab_Attacker_ToAnyone.SuspendLayout();
		Panel4.SuspendLayout();
		TabControl4.SuspendLayout();
		Tab_Target_BySelected.SuspendLayout();
		Tab_Target_ByAnyone.SuspendLayout();
		SearchError().SuspendLayout();
		((ISupportInitialize)SplitContainerOuter).BeginInit();
		SplitContainerOuter.Panel1.SuspendLayout();
		SplitContainerOuter.Panel2.SuspendLayout();
		SplitContainerOuter.SuspendLayout();
		((ISupportInitialize)SplitContainerInner).BeginInit();
		SplitContainerInner.Panel1.SuspendLayout();
		SplitContainerInner.Panel2.SuspendLayout();
		SplitContainerInner.SuspendLayout();
		SuspendLayout();
		TableLayoutPanel1.ColumnCount = 1;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.Controls.Add(Panel1, 0, 0);
		TableLayoutPanel1.Controls.Add(Panel5, 0, 1);
		TableLayoutPanel1.Dock = DockStyle.Fill;
		TableLayoutPanel1.Location = new Point(0, 0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 2;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.Size = new Size(322, 661);
		TableLayoutPanel1.TabIndex = 17;
		Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel1.Controls.Add(Button_RemoveAttacker);
		Panel1.Controls.Add(Label1);
		Panel1.Controls.Add(LB_Attackers);
		Panel1.Controls.Add(Button_UnitWRA);
		Panel1.Controls.Add(Button_AddAttacker);
		Panel1.Location = new Point(3, 3);
		Panel1.Name = "Panel1";
		Panel1.Size = new Size(316, 324);
		Panel1.TabIndex = 0;
		Button_RemoveAttacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_RemoveAttacker.BackColor = Color.Transparent;
		Button_RemoveAttacker.DialogResult = DialogResult.None;
		Button_RemoveAttacker.Font = new Font("Segoe UI", 10f);
		Button_RemoveAttacker.ForeColor = SystemColors.Control;
		Button_RemoveAttacker.Location = new Point(-1, 302);
		Button_RemoveAttacker.Name = "Button_RemoveAttacker";
		Button_RemoveAttacker.RoundRadius = 0;
		Button_RemoveAttacker.Size = new Size(317, 23);
		Button_RemoveAttacker.TabIndex = 11;
		Button_RemoveAttacker.Text = "从列表中删除选定的单元";
		Label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label1.AutoSize = true;
		Label1.Font = new Font("Segoe UI", 12f);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(0, 0);
		Label1.Name = "Label1";
		Label1.Size = new Size(123, 21);
		Label1.TabIndex = 1;
		Label1.Text = "攻击单元";
		LB_Attackers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LB_Attackers.Font = new Font("Segoe UI", 9f);
		LB_Attackers.ItemHeight = 15;
		LB_Attackers.Location = new Point(0, 25);
		LB_Attackers.Name = "LB_Attackers";
		LB_Attackers.RelatedInfos = null;
		LB_Attackers.Size = new Size(315, 230);
		LB_Attackers.TabIndex = 2;
		Button_UnitWRA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_UnitWRA.BackColor = Color.Transparent;
		Button_UnitWRA.DialogResult = DialogResult.None;
		Button_UnitWRA.Font = new Font("Segoe UI", 10f);
		Button_UnitWRA.ForeColor = SystemColors.Control;
		Button_UnitWRA.Location = new Point(-1, 256);
		Button_UnitWRA.Name = "Button_UnitWRA";
		Button_UnitWRA.RoundRadius = 0;
		Button_UnitWRA.Size = new Size(317, 23);
		Button_UnitWRA.TabIndex = 8;
		Button_UnitWRA.Text = "武器投放授权（WRA）";
		Button_AddAttacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_AddAttacker.BackColor = Color.Transparent;
		Button_AddAttacker.DialogResult = DialogResult.None;
		Button_AddAttacker.Font = new Font("Segoe UI", 10f);
		Button_AddAttacker.ForeColor = SystemColors.Control;
		Button_AddAttacker.Location = new Point(-1, 279);
		Button_AddAttacker.Name = "Button_AddAttacker";
		Button_AddAttacker.RoundRadius = 0;
		Button_AddAttacker.Size = new Size(317, 23);
		Button_AddAttacker.TabIndex = 9;
		Button_AddAttacker.Text = "从战术地图添加选定的单元";
		Panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel5.Controls.Add(Button_RemoveTargets);
		Panel5.Controls.Add(Button_AddTarget);
		Panel5.Controls.Add(LB_Targets);
		Panel5.Controls.Add(Label3);
		Panel5.Location = new Point(3, 333);
		Panel5.Name = "Panel5";
		Panel5.Size = new Size(316, 325);
		Panel5.TabIndex = 4;
		Button_RemoveTargets.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_RemoveTargets.BackColor = Color.Transparent;
		Button_RemoveTargets.DialogResult = DialogResult.None;
		Button_RemoveTargets.Font = new Font("Segoe UI", 10f);
		Button_RemoveTargets.ForeColor = SystemColors.Control;
		Button_RemoveTargets.Location = new Point(-1, 303);
		Button_RemoveTargets.Name = "Button_RemoveTargets";
		Button_RemoveTargets.RoundRadius = 0;
		Button_RemoveTargets.Size = new Size(317, 23);
		Button_RemoveTargets.TabIndex = 12;
		Button_RemoveTargets.Text = "从列表中删除选定的目标";
		Button_AddTarget.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_AddTarget.BackColor = Color.Transparent;
		Button_AddTarget.DialogResult = DialogResult.None;
		Button_AddTarget.Font = new Font("Segoe UI", 10f);
		Button_AddTarget.ForeColor = SystemColors.Control;
		Button_AddTarget.Location = new Point(-1, 280);
		Button_AddTarget.Name = "Button_AddTarget";
		Button_AddTarget.RoundRadius = 0;
		Button_AddTarget.Size = new Size(317, 23);
		Button_AddTarget.TabIndex = 10;
		Button_AddTarget.Text = "从战术地图添加选定的目标";
		LB_Targets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LB_Targets.Font = new Font("Segoe UI", 9f);
		LB_Targets.ItemHeight = 15;
		LB_Targets.Location = new Point(0, 25);
		LB_Targets.MultiSelect = true;
		LB_Targets.Name = "LB_Targets";
		LB_Targets.RelatedInfos = null;
		LB_Targets.Size = new Size(315, 254);
		LB_Targets.TabIndex = 4;
		Label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 12f);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(0, 0);
		Label3.Name = "Label3";
		Label3.Size = new Size(142, 21);
		Label3.TabIndex = 3;
		Label3.Text = "可选择的目标";
		TableLayoutPanel2.ColumnCount = 1;
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		TableLayoutPanel2.Controls.Add(Panel2, 0, 0);
		TableLayoutPanel2.Dock = DockStyle.Fill;
		TableLayoutPanel2.Location = new Point(0, 0);
		TableLayoutPanel2.Name = "TableLayoutPanel2";
		TableLayoutPanel2.RowCount = 1;
		TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel2.Size = new Size(348, 661);
		TableLayoutPanel2.TabIndex = 18;
		Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel2.Controls.Add(CB_ShowAutomaticFireInfo);
		Panel2.Controls.Add(CB_AllowTimeout);
		Panel2.Controls.Add(Button_AllocateSalvo);
		Panel2.Controls.Add(Button_AllocateAllWeapons);
		Panel2.Controls.Add(Label5);
		Panel2.Controls.Add(Button_Allocate);
		Panel2.Controls.Add(NUD_NumberOfWeapons);
		Panel2.Controls.Add(TV_AvailableWeapons);
		Panel2.Location = new Point(3, 3);
		Panel2.Name = "Panel2";
		Panel2.Size = new Size(342, 655);
		Panel2.TabIndex = 1;
		CB_ShowAutomaticFireInfo.Location = new Point(167, 4);
		CB_ShowAutomaticFireInfo.Name = "CB_ShowAutomaticFireInfo";
		CB_ShowAutomaticFireInfo.Size = new Size(190, 17);
		CB_ShowAutomaticFireInfo.TabIndex = 15;
		CB_ShowAutomaticFireInfo.Text = "显示自动开火信息";
		CB_AllowTimeout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		CB_AllowTimeout.Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point, 161);
		CB_AllowTimeout.Location = new Point(74, 631);
		CB_AllowTimeout.MaximumSize = new Size(350, 0);
		CB_AllowTimeout.Name = "CB_AllowTimeout";
		CB_AllowTimeout.Size = new Size(180, 15);
		CB_AllowTimeout.TabIndex = 14;
		CB_AllowTimeout.Text = "允许自动齐射超时";
		Button_AllocateSalvo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_AllocateSalvo.BackColor = Color.Transparent;
		Button_AllocateSalvo.DialogResult = DialogResult.None;
		Button_AllocateSalvo.Font = new Font("Segoe UI", 10f);
		Button_AllocateSalvo.ForeColor = SystemColors.Control;
		Button_AllocateSalvo.Location = new Point(-1, 573);
		Button_AllocateSalvo.Name = "Button_AllocateSalvo";
		Button_AllocateSalvo.RoundRadius = 0;
		Button_AllocateSalvo.Size = new Size(347, 23);
		Button_AllocateSalvo.TabIndex = 13;
		Button_AllocateSalvo.Text = "按条令为选定的目标分配一个齐射";
		Button_AllocateAllWeapons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_AllocateAllWeapons.BackColor = Color.Transparent;
		Button_AllocateAllWeapons.DialogResult = DialogResult.None;
		Button_AllocateAllWeapons.Font = new Font("Segoe UI", 10f);
		Button_AllocateAllWeapons.ForeColor = SystemColors.Control;
		Button_AllocateAllWeapons.Location = new Point(-1, 602);
		Button_AllocateAllWeapons.Name = "Button_AllocateAllWeapons";
		Button_AllocateAllWeapons.RoundRadius = 0;
		Button_AllocateAllWeapons.Size = new Size(347, 23);
		Button_AllocateAllWeapons.TabIndex = 6;
		Button_AllocateAllWeapons.Text = "分配这种类型的所有武器";
		Label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label5.AutoSize = true;
		Label5.Font = new Font("Segoe UI", 12f);
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(0, 0);
		Label5.Name = "Label5";
		Label5.Size = new Size(132, 21);
		Label5.TabIndex = 3;
		Label5.Text = "适合的武器";
		Button_Allocate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Allocate.BackColor = Color.Transparent;
		Button_Allocate.DialogResult = DialogResult.None;
		Button_Allocate.Font = new Font("Segoe UI", 10f);
		Button_Allocate.ForeColor = SystemColors.Control;
		Button_Allocate.Location = new Point(-1, 541);
		Button_Allocate.Name = "Button_Allocate";
		Button_Allocate.RoundRadius = 0;
		Button_Allocate.Size = new Size(268, 26);
		Button_Allocate.TabIndex = 5;
		Button_Allocate.Text = "将武器分配给选定的目标：";
		NUD_NumberOfWeapons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		NUD_NumberOfWeapons.BackColor = Color.FromArgb(69, 73, 74);
		NUD_NumberOfWeapons.BorderStyle = BorderStyle.FixedSingle;
		NUD_NumberOfWeapons.Font = new Font("Segoe UI", 10f);
		NUD_NumberOfWeapons.ForeColor = Color.FromArgb(220, 220, 220);
		NUD_NumberOfWeapons.Location = new Point(268, 541);
		NUD_NumberOfWeapons.Name = "NUD_NumberOfWeapons";
		NUD_NumberOfWeapons.Size = new Size(76, 25);
		NUD_NumberOfWeapons.TabIndex = 7;
		TV_AvailableWeapons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TV_AvailableWeapons.Font = new Font("Segoe UI", 9f);
		TV_AvailableWeapons.Location = new Point(0, 25);
		TV_AvailableWeapons.MaxDragChange = 20;
		TV_AvailableWeapons.Name = "TV_AvailableWeapons";
		TV_AvailableWeapons.Size = new Size(347, 510);
		TV_AvailableWeapons.TabIndex = 4;
		TableLayoutPanel3.ColumnCount = 1;
		TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		TableLayoutPanel3.Controls.Add(Panel3, 0, 0);
		TableLayoutPanel3.Controls.Add(Panel4, 0, 1);
		TableLayoutPanel3.Dock = DockStyle.Fill;
		TableLayoutPanel3.Location = new Point(0, 0);
		TableLayoutPanel3.Name = "TableLayoutPanel3";
		TableLayoutPanel3.RowCount = 2;
		TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel3.Size = new Size(324, 661);
		TableLayoutPanel3.TabIndex = 19;
		Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel3.Controls.Add(Button_ClearCourse_Attacker);
		Panel3.Controls.Add(Button_PlotCourse_Attacker);
		Panel3.Controls.Add(Button_RemoveWeapons_Attacker);
		Panel3.Controls.Add(TabControl2);
		Panel3.Controls.Add(Label2);
		Panel3.Location = new Point(3, 3);
		Panel3.Name = "Panel3";
		Panel3.Size = new Size(318, 324);
		Panel3.TabIndex = 2;
		Button_ClearCourse_Attacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ClearCourse_Attacker.BackColor = Color.Transparent;
		Button_ClearCourse_Attacker.DialogResult = DialogResult.None;
		Button_ClearCourse_Attacker.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ClearCourse_Attacker.ForeColor = SystemColors.Control;
		Button_ClearCourse_Attacker.Location = new Point(80, 302);
		Button_ClearCourse_Attacker.Name = "Button_ClearCourse_Attacker";
		Button_ClearCourse_Attacker.RoundRadius = 0;
		Button_ClearCourse_Attacker.Size = new Size(76, 23);
		Button_ClearCourse_Attacker.TabIndex = 17;
		Button_ClearCourse_Attacker.Text = "明确的做法";
		Button_PlotCourse_Attacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_PlotCourse_Attacker.BackColor = Color.Transparent;
		Button_PlotCourse_Attacker.DialogResult = DialogResult.None;
		Button_PlotCourse_Attacker.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_PlotCourse_Attacker.ForeColor = SystemColors.Control;
		Button_PlotCourse_Attacker.Location = new Point(0, 302);
		Button_PlotCourse_Attacker.Name = "Button_PlotCourse_Attacker";
		Button_PlotCourse_Attacker.RoundRadius = 0;
		Button_PlotCourse_Attacker.Size = new Size(76, 23);
		Button_PlotCourse_Attacker.TabIndex = 16;
		Button_PlotCourse_Attacker.Text = "规划路径";
		Button_RemoveWeapons_Attacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_RemoveWeapons_Attacker.BackColor = Color.Transparent;
		Button_RemoveWeapons_Attacker.DialogResult = DialogResult.None;
		Button_RemoveWeapons_Attacker.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_RemoveWeapons_Attacker.ForeColor = SystemColors.Control;
		Button_RemoveWeapons_Attacker.Location = new Point(206, 302);
		Button_RemoveWeapons_Attacker.Name = "Button_RemoveWeapons_Attacker";
		Button_RemoveWeapons_Attacker.RoundRadius = 0;
		Button_RemoveWeapons_Attacker.Size = new Size(112, 23);
		Button_RemoveWeapons_Attacker.TabIndex = 15;
		Button_RemoveWeapons_Attacker.Text = "取消分配已选中";
		TabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl2.Controls.Add(Tab_Attacker_ToSelectedOnly);
		TabControl2.Controls.Add(Tab_Attacker_ToAnyone);
		TabControl2.Cursor = Cursors.Hand;
		TabControl2.Font = new Font("Segoe UI", 10f);
		TabControl2.ItemSize = new Size(80, 20);
		TabControl2.Location = new Point(0, 25);
		TabControl2.Name = "TabControl2";
		TabControl2.SelectedIndex = 0;
		TabControl2.Size = new Size(318, 276);
		TabControl2.TabIndex = 2;
		Tab_Attacker_ToSelectedOnly.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Attacker_ToSelectedOnly.Controls.Add(TV_Allocations_ToTargetsOnly);
		Tab_Attacker_ToSelectedOnly.Location = new Point(4, 24);
		Tab_Attacker_ToSelectedOnly.Name = "Tab_Attacker_ToSelectedOnly";
		Tab_Attacker_ToSelectedOnly.Padding = new Padding(3);
		Tab_Attacker_ToSelectedOnly.Size = new Size(310, 248);
		Tab_Attacker_ToSelectedOnly.TabIndex = 0;
		Tab_Attacker_ToSelectedOnly.Text = "仅限选定目标";
		TV_Allocations_ToTargetsOnly.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ToTargetsOnly.Dock = DockStyle.Fill;
		TV_Allocations_ToTargetsOnly.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ToTargetsOnly.Location = new Point(3, 3);
		TV_Allocations_ToTargetsOnly.MaxDragChange = 20;
		TV_Allocations_ToTargetsOnly.Name = "TV_Allocations_ToTargetsOnly";
		TV_Allocations_ToTargetsOnly.Size = new Size(304, 242);
		TV_Allocations_ToTargetsOnly.TabIndex = 5;
		Tab_Attacker_ToAnyone.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Attacker_ToAnyone.Controls.Add(TV_Allocations_ToAnyone);
		Tab_Attacker_ToAnyone.Location = new Point(4, 24);
		Tab_Attacker_ToAnyone.Name = "Tab_Attacker_ToAnyone";
		Tab_Attacker_ToAnyone.Padding = new Padding(3);
		Tab_Attacker_ToAnyone.Size = new Size(310, 248);
		Tab_Attacker_ToAnyone.TabIndex = 1;
		Tab_Attacker_ToAnyone.Text = "对任何人";
		TV_Allocations_ToAnyone.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ToAnyone.Dock = DockStyle.Fill;
		TV_Allocations_ToAnyone.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ToAnyone.Location = new Point(3, 3);
		TV_Allocations_ToAnyone.MaxDragChange = 20;
		TV_Allocations_ToAnyone.Name = "TV_Allocations_ToAnyone";
		TV_Allocations_ToAnyone.Size = new Size(304, 242);
		TV_Allocations_ToAnyone.TabIndex = 6;
		Label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 12f);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(0, 0);
		Label2.Name = "Label2";
		Label2.Size = new Size(297, 21);
		Label2.TabIndex = 3;
		Label2.Text = "由选定的攻击者分配的武器";
		Panel4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Panel4.Controls.Add(Button_ClearCourse_Target);
		Panel4.Controls.Add(Button_RemoveWeapons_Target);
		Panel4.Controls.Add(Button_PlotCourse_Target);
		Panel4.Controls.Add(TabControl4);
		Panel4.Controls.Add(Label4);
		Panel4.Location = new Point(3, 333);
		Panel4.Name = "Panel4";
		Panel4.Size = new Size(318, 325);
		Panel4.TabIndex = 3;
		Button_ClearCourse_Target.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ClearCourse_Target.BackColor = Color.Transparent;
		Button_ClearCourse_Target.DialogResult = DialogResult.None;
		Button_ClearCourse_Target.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ClearCourse_Target.ForeColor = SystemColors.Control;
		Button_ClearCourse_Target.Location = new Point(80, 302);
		Button_ClearCourse_Target.Name = "Button_ClearCourse_Target";
		Button_ClearCourse_Target.RoundRadius = 0;
		Button_ClearCourse_Target.Size = new Size(76, 23);
		Button_ClearCourse_Target.TabIndex = 19;
		Button_ClearCourse_Target.Text = "明确的做法";
		Button_RemoveWeapons_Target.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_RemoveWeapons_Target.BackColor = Color.Transparent;
		Button_RemoveWeapons_Target.DialogResult = DialogResult.None;
		Button_RemoveWeapons_Target.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_RemoveWeapons_Target.ForeColor = SystemColors.Control;
		Button_RemoveWeapons_Target.Location = new Point(206, 302);
		Button_RemoveWeapons_Target.Name = "Button_RemoveWeapons_Target";
		Button_RemoveWeapons_Target.RoundRadius = 0;
		Button_RemoveWeapons_Target.Size = new Size(112, 23);
		Button_RemoveWeapons_Target.TabIndex = 14;
		Button_RemoveWeapons_Target.Text = "取消分配已选中";
		Button_PlotCourse_Target.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_PlotCourse_Target.BackColor = Color.Transparent;
		Button_PlotCourse_Target.DialogResult = DialogResult.None;
		Button_PlotCourse_Target.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_PlotCourse_Target.ForeColor = SystemColors.Control;
		Button_PlotCourse_Target.Location = new Point(0, 302);
		Button_PlotCourse_Target.Name = "Button_PlotCourse_Target";
		Button_PlotCourse_Target.RoundRadius = 0;
		Button_PlotCourse_Target.Size = new Size(76, 23);
		Button_PlotCourse_Target.TabIndex = 18;
		Button_PlotCourse_Target.Text = "规划路径";
		TabControl4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl4.Controls.Add(Tab_Target_BySelected);
		TabControl4.Controls.Add(Tab_Target_ByAnyone);
		TabControl4.Cursor = Cursors.Hand;
		TabControl4.Font = new Font("Segoe UI", 10f);
		TabControl4.ItemSize = new Size(80, 20);
		TabControl4.Location = new Point(0, 25);
		TabControl4.Name = "TabControl4";
		TabControl4.SelectedIndex = 0;
		TabControl4.Size = new Size(318, 277);
		TabControl4.TabIndex = 2;
		Tab_Target_BySelected.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Target_BySelected.Controls.Add(TV_Allocations_ByAttackersOnly);
		Tab_Target_BySelected.Location = new Point(4, 24);
		Tab_Target_BySelected.Name = "Tab_Target_BySelected";
		Tab_Target_BySelected.Padding = new Padding(3);
		Tab_Target_BySelected.Size = new Size(310, 249);
		Tab_Target_BySelected.TabIndex = 0;
		Tab_Target_BySelected.Text = "仅由选定的攻击者提供";
		TV_Allocations_ByAttackersOnly.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ByAttackersOnly.Dock = DockStyle.Fill;
		TV_Allocations_ByAttackersOnly.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ByAttackersOnly.Location = new Point(3, 3);
		TV_Allocations_ByAttackersOnly.MaxDragChange = 20;
		TV_Allocations_ByAttackersOnly.Name = "TV_Allocations_ByAttackersOnly";
		TV_Allocations_ByAttackersOnly.Size = new Size(304, 243);
		TV_Allocations_ByAttackersOnly.TabIndex = 6;
		Tab_Target_ByAnyone.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Target_ByAnyone.Controls.Add(TV_Allocations_ByAnyone);
		Tab_Target_ByAnyone.Location = new Point(4, 24);
		Tab_Target_ByAnyone.Name = "Tab_Target_ByAnyone";
		Tab_Target_ByAnyone.Padding = new Padding(3);
		Tab_Target_ByAnyone.Size = new Size(310, 249);
		Tab_Target_ByAnyone.TabIndex = 1;
		Tab_Target_ByAnyone.Text = "任何人";
		TV_Allocations_ByAnyone.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ByAnyone.Dock = DockStyle.Fill;
		TV_Allocations_ByAnyone.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ByAnyone.Location = new Point(3, 3);
		TV_Allocations_ByAnyone.MaxDragChange = 20;
		TV_Allocations_ByAnyone.Name = "TV_Allocations_ByAnyone";
		TV_Allocations_ByAnyone.Size = new Size(304, 243);
		TV_Allocations_ByAnyone.TabIndex = 7;
		Label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label4.AutoSize = true;
		Label4.Font = new Font("Segoe UI", 12f);
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(0, 0);
		Label4.Name = "Label4";
		Label4.Size = new Size(263, 21);
		Label4.TabIndex = 3;
		Label4.Text = "武器分配给选定的目标";
		SearchError().BackColor = Color.FromArgb(60, 63, 65);
		SearchError().ForeColor = Color.FromArgb(220, 220, 220);
		SearchError().Items.AddRange(new ToolStripItem[1] { TSMI_HighAltitudeDetonation });
		SearchError().Name = "ContextMenuStrip1";
		SearchError().Size = new Size(251, 26);
		TSMI_HighAltitudeDetonation.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_HighAltitudeDetonation.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_HighAltitudeDetonation.Name = "TSMI_HighAltitudeDetonation";
		TSMI_HighAltitudeDetonation.Size = new Size(250, 22);
		TSMI_HighAltitudeDetonation.Text = "特别：高海拔爆炸";
		SplitContainerOuter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		SplitContainerOuter.Location = new Point(0, 0);
		SplitContainerOuter.Name = "SplitContainerOuter";
		SplitContainerOuter.Panel1.Controls.Add(TableLayoutPanel1);
		SplitContainerOuter.Panel1MinSize = 322;
		SplitContainerOuter.Panel2.Controls.Add(SplitContainerInner);
		SplitContainerOuter.Panel2MinSize = 670;
		SplitContainerOuter.Size = new Size(1008, 661);
		SplitContainerOuter.SplitterDistance = 322;
		SplitContainerOuter.TabIndex = 1;
		SplitContainerInner.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		SplitContainerInner.Location = new Point(0, 0);
		SplitContainerInner.Name = "SplitContainerInner";
		SplitContainerInner.Panel1.Controls.Add(TableLayoutPanel2);
		SplitContainerInner.Panel1MinSize = 348;
		SplitContainerInner.Panel2.Controls.Add(TableLayoutPanel3);
		SplitContainerInner.Panel2MinSize = 324;
		SplitContainerInner.Size = new Size(676, 661);
		SplitContainerInner.SplitterDistance = 348;
		SplitContainerInner.TabIndex = 0;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1008, 661);
		base.Controls.Add(SplitContainerOuter);
		base.KeyPreview = true;
		base.Location = new Point(0, 0);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AttackTarget";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "武器分配";
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		Panel1.ResumeLayout(performLayout: false);
		Panel1.PerformLayout();
		Panel5.ResumeLayout(performLayout: false);
		Panel5.PerformLayout();
		TableLayoutPanel2.ResumeLayout(performLayout: false);
		Panel2.ResumeLayout(performLayout: false);
		Panel2.PerformLayout();
		((ISupportInitialize)NUD_NumberOfWeapons).EndInit();
		TableLayoutPanel3.ResumeLayout(performLayout: false);
		Panel3.ResumeLayout(performLayout: false);
		Panel3.PerformLayout();
		TabControl2.ResumeLayout(performLayout: false);
		Tab_Attacker_ToSelectedOnly.ResumeLayout(performLayout: false);
		Tab_Attacker_ToAnyone.ResumeLayout(performLayout: false);
		Panel4.ResumeLayout(performLayout: false);
		Panel4.PerformLayout();
		TabControl4.ResumeLayout(performLayout: false);
		Tab_Target_BySelected.ResumeLayout(performLayout: false);
		Tab_Target_ByAnyone.ResumeLayout(performLayout: false);
		SearchError().ResumeLayout(performLayout: false);
		SplitContainerOuter.Panel1.ResumeLayout(performLayout: false);
		SplitContainerOuter.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainerOuter).EndInit();
		SplitContainerOuter.ResumeLayout(performLayout: false);
		SplitContainerInner.Panel1.ResumeLayout(performLayout: false);
		SplitContainerInner.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainerInner).EndInit();
		SplitContainerInner.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			Targets.Clear();
			Attackers.Clear();
			_WrapperBridge.Clear();
			issuerBridge.Clear();
			m_ImporterBridge = null;
			LB_Attackers.Items.Clear();
			LB_Targets.Items.Clear();
			TV_Allocations_ToTargetsOnly.Nodes.Clear();
			TV_Allocations_ToAnyone.Nodes.Clear();
			TV_Allocations_ByAttackersOnly.Nodes.Clear();
			TV_AvailableWeapons.Nodes.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void SetupSerializer(object sender, FormClosingEventArgs e)
	{
		if (proxyBridge && Client.CurrentUserAction != Client.UserAction.PlottingCourseForSalvo)
		{
			Client.CurrentGame.Run();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] repositoryBridge = m_RepositoryBridge;
		Keys[] array = repositoryBridge;
		foreach (Keys keys in array)
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
		return false;
	}

	private void ExcludeSerializer()
	{
		Color darkBackground = Colors.DarkBackground;
		Color backColor = SplitContainerOuter.Panel1.BackColor;
		Color backColor2 = SplitContainerOuter.Panel2.BackColor;
		SplitContainerOuter.Panel1.BackColor = darkBackground;
		SplitContainerOuter.Panel2.BackColor = darkBackground;
		SplitContainerOuter.BackColor = darkBackground;
		SplitContainerOuter.Panel1.BackColor = backColor;
		SplitContainerOuter.Panel2.BackColor = backColor2;
		backColor = SplitContainerInner.Panel1.BackColor;
		backColor2 = SplitContainerInner.Panel2.BackColor;
		SplitContainerInner.Panel1.BackColor = darkBackground;
		SplitContainerInner.Panel2.BackColor = darkBackground;
		SplitContainerInner.BackColor = darkBackground;
		SplitContainerInner.Panel1.BackColor = backColor;
		SplitContainerInner.Panel2.BackColor = backColor2;
	}

	public void LoadForm()
	{
		proxyBridge = Client.CurrentGame.Status == Game._GameStatus.Running;
		if (proxyBridge)
		{
			Client.CurrentGame.Pause();
		}
		ExcludeSerializer();
		InitSerializer();
		CheckSerializer();
		if (Targets.Count > 0 && Attackers.Count > 0 && TV_AvailableWeapons.Nodes.Count > 0)
		{
			m_ReaderBridge = false;
			TV_AvailableWeapons.SelectNode(TV_AvailableWeapons.Nodes[0]);
			TV_AvailableWeapons.Select();
			m_ReaderBridge = true;
		}
		m_ReaderBridge = false;
		CB_AllowTimeout.Checked = SimConfiguration.DefaultGamePreferences.SalvoTimeout;
		CB_ShowAutomaticFireInfo.Checked = SimConfiguration.DefaultGamePreferences.ShowAutomaticFireInfo;
		m_ReaderBridge = true;
		new ToolTip().SetToolTip(CB_AllowTimeout, "Enable automatic salvo cancellation when last weapon in first volley impacts, or after 40 seconds if weapons cannot be fired. Note! Disabling salvo cancellation will not drop salvos until all weapons have been fired, and may prevent other units from automatically firing at a contact should it move out of firing parameters!");
	}

	public void RefreshForm()
	{
		if (base.IsDisposed)
		{
			return;
		}
		try
		{
			InsertSerializer();
			FillSerializer();
			ChangeSerializer();
			if (Information.IsNothing(_WrapperBridge) && Attackers.Count > 0)
			{
				_WrapperBridge.Add(Attackers[0]);
				issuerBridge.Add(Targets[0]);
			}
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit attacker in Attackers)
			{
				if (Information.IsNothing(attacker) || attacker.IsDestroyed || (attacker.IsShip && ((Ship)attacker).IsSinking))
				{
					list.Add(attacker);
				}
				if (!attacker.IsOperating())
				{
					list.Add(attacker);
				}
			}
			if (list.Count > 0)
			{
				foreach (ActiveUnit item in list)
				{
					Attackers.Remove(item);
				}
				InitSerializer();
			}
			List<Contact> list2 = new List<Contact>();
			foreach (Contact target in Targets)
			{
				if (Information.IsNothing(target) || (!Information.IsNothing(target.ActualUnit) && target.ActualUnit.IsDestroyed))
				{
					list2.Add(target);
				}
			}
			if (list2.Count > 0)
			{
				foreach (Contact item2 in list2)
				{
					Targets.Remove(item2);
					CheckSerializer();
				}
			}
			PrepareSerializer();
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

	private void IncludeSerializer(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		CheckRef().Interval = 1000;
		CheckRef().Start();
		LoadForm();
	}

	private void SearchSerializer(object sender, EventArgs e)
	{
		if (Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			RefreshForm();
		}
	}

	private void EnableSerializer()
	{
		DarkTreeNode darkTreeNode = null;
		Button_RemoveWeapons_Attacker.Enabled = false;
		bool flag = false;
		bool flag2 = false;
		if (TabControl2.SelectedIndex == 0)
		{
			if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count > 0)
			{
				darkTreeNode = TV_Allocations_ToTargetsOnly.SelectedNodes[0];
			}
		}
		else if (TV_Allocations_ToAnyone.SelectedNodes.Count > 0)
		{
			darkTreeNode = TV_Allocations_ToAnyone.SelectedNodes[0];
		}
		if (darkTreeNode != null && darkTreeNode.Tag != null)
		{
			if ((object)darkTreeNode.Tag.GetType() == typeof(WeaponSalvo))
			{
				Button_RemoveWeapons_Attacker.Enabled = true;
				WeaponSalvo obj = (WeaponSalvo)darkTreeNode.Tag;
				flag = obj.PlottedCourse.Count() > 0;
				flag2 = obj.GetReferenceWeapon(Client.CurrentScenario).SupportsWaypoints;
			}
			else if (darkTreeNode.Tag is ActiveUnit && darkTreeNode.Nodes.Count > 0)
			{
				Button_RemoveWeapons_Attacker.Enabled = true;
			}
		}
		Button_PlotCourse_Attacker.Enabled = flag2;
		Button_ClearCourse_Attacker.Enabled = flag2 && flag;
		darkTreeNode = null;
		Button_RemoveWeapons_Target.Enabled = false;
		flag = false;
		flag2 = false;
		if (TabControl4.SelectedIndex == 0)
		{
			if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count > 0)
			{
				darkTreeNode = TV_Allocations_ByAttackersOnly.SelectedNodes[0];
			}
		}
		else if (TV_Allocations_ByAnyone.SelectedNodes.Count > 0)
		{
			darkTreeNode = TV_Allocations_ByAnyone.SelectedNodes[0];
		}
		if (darkTreeNode != null && darkTreeNode.Tag != null)
		{
			if ((object)darkTreeNode.Tag.GetType() == typeof(WeaponSalvo))
			{
				Button_RemoveWeapons_Target.Enabled = true;
				WeaponSalvo obj2 = (WeaponSalvo)darkTreeNode.Tag;
				flag = obj2.PlottedCourse.Count() > 0;
				flag2 = obj2.GetReferenceWeapon(Client.CurrentScenario).SupportsWaypoints;
			}
			else if (darkTreeNode.Tag is ActiveUnit && darkTreeNode.Nodes.Count > 0)
			{
				Button_RemoveWeapons_Target.Enabled = true;
			}
		}
		Button_PlotCourse_Target.Enabled = flag2;
		Button_ClearCourse_Target.Enabled = flag2 && flag;
	}

	private void ChangeSerializer()
	{
		PrintSerializer();
		if (TabControl2.SelectedIndex == 0)
		{
			ConcatSerializer();
		}
		else
		{
			InterruptSerializer();
		}
		if (TabControl4.SelectedIndex == 0)
		{
			RemoveSerializer();
		}
		else
		{
			FindSerializer();
		}
		EnableSerializer();
	}

	private void InitSerializer()
	{
		LB_Attackers.Items.Clear();
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		Attackers = Attackers.OrderBy((ActiveUnit theAu) => theAu.Name).ToList();
		foreach (ActiveUnit attacker in Attackers)
		{
			if (!attacker.IsGroup)
			{
				continue;
			}
			foreach (ActiveUnit value in ((Group)attacker).Units.Values)
			{
				Side currentSide = Client.CurrentSide;
				string string_ = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(currentSide, value, bool_1: false, ref string_, Client.CurrentMapProfile.String_0) && !Attackers.Contains(value))
				{
					list.Add(value);
				}
			}
			list2.Add(attacker);
		}
		foreach (ActiveUnit item in list2)
		{
			Attackers.Remove(item);
		}
		foreach (ActiveUnit item2 in list)
		{
			Attackers.Add(item2);
		}
		foreach (ActiveUnit attacker2 in Attackers)
		{
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = attacker2.Name + " (" + Misc.ReadRequest(attacker2.UnitClass) + ")";
			darkListItem.Tag = attacker2;
			LB_Attackers.Items.Add(darkListItem);
		}
		if (LB_Attackers.Items.Count > 0)
		{
			if (m_ObserverBridge <= LB_Attackers.Items.Count - 1)
			{
				LB_Attackers.SelectItem(m_ObserverBridge);
			}
			else
			{
				LB_Attackers.SelectItem(LB_Attackers.Items.Count - 1);
			}
		}
	}

	private void CheckSerializer()
	{
		LB_Targets.Items.Clear();
		Targets = Targets.OrderBy((Contact theC) => theC.Name).ToList();
		string text = null;
		foreach (Contact target in Targets)
		{
			string text2 = "";
			if (target.IncludeImporter(Client.CurrentSide).Count > 0)
			{
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				foreach (Contact.HostedUnitReconRecord item in target.IncludeImporter(Client.CurrentSide))
				{
					switch (item.IDStatus)
					{
					case Contact_Base.IdentificationStatus.Unknown:
						text = "未知单元";
						break;
					case Contact_Base.IdentificationStatus.KnownDomain:
						try
						{
							ActiveUnit activeUnit2 = Client.CurrentScenario.ActiveUnits[item.UnitID];
							text = Misc.CollectRequest(activeUnit2.VisualSizeClass) + " " + activeUnit2.UnitType_String;
						}
						catch (Exception ex4)
						{
							ProjectData.SetProjectError(ex4);
							Exception exception_4 = ex4;
							exception_4.Data.Add("Error at 999999", exception_4.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "未知单元";
							ProjectData.ClearProjectError();
						}
						break;
					case Contact_Base.IdentificationStatus.KnownType:
						try
						{
							ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[item.UnitID];
							text = Misc.CollectRequest(activeUnit.VisualSizeClass) + " " + activeUnit.SubTypeDescription;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception exception_3 = ex3;
							exception_3.Data.Add("Error at 200409", exception_3.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_3);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "未知单元";
							ProjectData.ClearProjectError();
						}
						break;
					case Contact_Base.IdentificationStatus.KnownClass:
						try
						{
							text = Client.CurrentScenario.ActiveUnits[item.UnitID].UnitClass;
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception exception_2 = ex2;
							exception_2.Data.Add("Error at 200410", exception_2.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "未知单元";
							ProjectData.ClearProjectError();
						}
						break;
					case Contact_Base.IdentificationStatus.PreciseID:
						try
						{
							text = Client.CurrentScenario.ActiveUnits[item.UnitID].Name;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_.Data.Add("Error at 200411", exception_.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							text = "未知单元";
							ProjectData.ClearProjectError();
						}
						break;
					}
					text = text + "（最后一次侦察：" + Conversions.ToString(Interaction.IIf(item.ReconAge > 0f, Misc.UpdateRequest((long)Math.Round(item.ReconAge), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "前）", "Now)"));
					if (dictionary.ContainsKey(text))
					{
						dictionary[text]++;
					}
					else
					{
						dictionary.Add(text, 1);
					}
				}
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, int> item2 in dictionary)
				{
					list.Add(Conversions.ToString(item2.Value) + "x " + item2.Key);
				}
				text2 = " - " + string.Join(" - ", list);
			}
			DarkListItem darkListItem = new DarkListItem();
			darkListItem.Text = target.Name + text2;
			darkListItem.Tag = target;
			LB_Targets.Items.Add(darkListItem);
		}
		if (LB_Targets.Items.Count > 0)
		{
			if (clientBridge <= LB_Targets.Items.Count - 1)
			{
				LB_Targets.SelectItem(clientBridge);
			}
			else
			{
				LB_Targets.SelectItem(LB_Targets.Items.Count - 1);
			}
		}
	}

	private void ConcatSerializer()
	{
		TV_Allocations_ToTargetsOnly.Nodes.Clear();
		if (_WrapperBridge.Count == 0 || issuerBridge.Count != 1)
		{
			return;
		}
		foreach (ActiveUnit item in _WrapperBridge)
		{
			ActiveUnit activeUnit_ = item;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ToTargetsOnly.Nodes.Add(darkTreeNode);
			Side unitSide = activeUnit_.GetUnitSide();
			List<Contact> list;
			Contact contact_ = (list = issuerBridge)[0];
			List<WeaponSalvo> list2 = unitSide.WeaponSalvosFromThisUnitToThisTarget(ref activeUnit_, ref contact_);
			list[0] = contact_;
			foreach (WeaponSalvo item2 in list2)
			{
				WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(activeUnit_.ObjectID, shooter.ShooterObjectID, TextCompare: true) != 0)
					{
						continue;
					}
					if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						string text = ((shooter.QuantityAssigned <= 2147473647) ? (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ") : "所有武器");
						DarkTreeNode darkTreeNode2 = new DarkTreeNode();
						propertyBridge = "";
						if (item2.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
						{
							propertyBridge += "[HIGH ALT]";
						}
						if (item2.PlottedCourse.Count() > 0)
						{
							ref string reference = ref propertyBridge;
							reference = reference + "[" + Conversions.ToString(item2.PlottedCourse.Count()) + "航段]";
						}
						darkTreeNode2.Text = "Alloc: " + propertyBridge + " " + text + item2.GetReferenceWeapon(activeUnit_.ParentScen).Name;
						darkTreeNode2.Tag = item2;
						darkTreeNode.Nodes.Add(darkTreeNode2);
					}
					if (shooter.QuantityFired > 0)
					{
						DarkTreeNode darkTreeNode3 = new DarkTreeNode();
						darkTreeNode3.Text = "射击：" + Conversions.ToString(shooter.QuantityFired) + "x " + item2.GetReferenceWeapon(activeUnit_.ParentScen).Name;
						darkTreeNode.Nodes.Add(darkTreeNode3);
					}
				}
			}
			darkTreeNode.Expanded = true;
		}
	}

	private void InterruptSerializer()
	{
		TV_Allocations_ToAnyone.Nodes.Clear();
		if (_WrapperBridge.Count == 0)
		{
			return;
		}
		foreach (ActiveUnit item in _WrapperBridge)
		{
			ActiveUnit activeUnit_ = item;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ToAnyone.Nodes.Add(darkTreeNode);
			foreach (WeaponSalvo item2 in activeUnit_.GetUnitSide().WeaponSalvosFromThisUnitToAnyTarget(ref activeUnit_))
			{
				WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(activeUnit_.ObjectID, shooter.ShooterObjectID, TextCompare: true) == 0)
					{
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							string text = ((shooter.QuantityAssigned <= 2147473647) ? (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ") : "所有武器");
							DarkTreeNode darkTreeNode2 = new DarkTreeNode();
							darkTreeNode2.Text = (item2.ManualFire ? "*" : "") + "分配给" + item2.Target.Name + ": " + text + item2.GetReferenceWeapon(activeUnit_.ParentScen).Name;
							darkTreeNode2.Tag = item2;
							darkTreeNode.Nodes.Add(darkTreeNode2);
						}
						if (shooter.QuantityFired > 0)
						{
							DarkTreeNode darkTreeNode3 = new DarkTreeNode();
							darkTreeNode3.Text = "攻击了" + item2.Target.Name + ": " + Conversions.ToString(shooter.QuantityFired) + "x " + item2.GetReferenceWeapon(activeUnit_.ParentScen).Name;
							darkTreeNode.Nodes.Add(darkTreeNode3);
						}
					}
				}
			}
			darkTreeNode.Expanded = true;
		}
	}

	private void RemoveSerializer()
	{
		TV_Allocations_ByAttackersOnly.Nodes.Clear();
		if (_WrapperBridge.Count == 0 || issuerBridge.Count != 1)
		{
			return;
		}
		foreach (ActiveUnit item in _WrapperBridge)
		{
			ActiveUnit activeUnit_ = item;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ByAttackersOnly.Nodes.Add(darkTreeNode);
			Side unitSide = activeUnit_.GetUnitSide();
			List<Contact> list;
			Contact contact_ = (list = issuerBridge)[0];
			List<WeaponSalvo> list2 = unitSide.WeaponSalvosFromThisUnitToThisTarget(ref activeUnit_, ref contact_);
			list[0] = contact_;
			foreach (WeaponSalvo item2 in list2)
			{
				WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(activeUnit_.ObjectID, shooter.ShooterObjectID, TextCompare: true) != 0)
					{
						continue;
					}
					if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						string text = ((shooter.QuantityAssigned <= 2147473647) ? (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ") : "所有武器");
						propertyBridge = "";
						if (item2.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
						{
							propertyBridge += "[HIGH ALT]";
						}
						if (item2.PlottedCourse.Count() > 0)
						{
							ref string reference = ref propertyBridge;
							reference = reference + "[" + Conversions.ToString(item2.PlottedCourse.Count()) + "航段]";
						}
						DarkTreeNode darkTreeNode2 = new DarkTreeNode();
						darkTreeNode2.Text = "Alloc: " + propertyBridge + text + item2.GetReferenceWeapon(activeUnit_.ParentScen).Name;
						darkTreeNode2.Tag = item2;
						darkTreeNode.Nodes.Add(darkTreeNode2);
					}
					if (shooter.QuantityFired > 0)
					{
						DarkTreeNode darkTreeNode3 = new DarkTreeNode();
						darkTreeNode3.Text = "射击：" + Conversions.ToString(shooter.QuantityFired) + "x " + item2.GetReferenceWeapon(activeUnit_.ParentScen).Name;
						darkTreeNode.Nodes.Add(darkTreeNode3);
					}
				}
			}
			darkTreeNode.Expanded = true;
		}
	}

	private void FindSerializer()
	{
		TV_Allocations_ByAnyone.Nodes.Clear();
		foreach (ActiveUnit activeUnits_ in Client.CurrentScenario.ActiveUnits_List)
		{
			ActiveUnit activeUnit_ = activeUnits_;
			if (Information.IsNothing(activeUnit_) || activeUnit_.IsWeapon || activeUnit_.IsGroup)
			{
				continue;
			}
			Side unitSide = activeUnit_.GetUnitSide();
			List<Contact> list;
			Contact contact_ = (list = issuerBridge)[0];
			List<WeaponSalvo> list2 = unitSide.WeaponSalvosFromThisUnitToThisTarget(ref activeUnit_, ref contact_);
			list[0] = contact_;
			List<WeaponSalvo> list3 = list2;
			if (list3.Count <= 0)
			{
				continue;
			}
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ByAnyone.Nodes.Add(darkTreeNode);
			foreach (WeaponSalvo item in list3)
			{
				WeaponSalvo.Shooter[] shootersList = item.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(activeUnit_.ObjectID, shooter.ShooterObjectID, TextCompare: true) != 0)
					{
						continue;
					}
					if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						string text = ((shooter.QuantityAssigned <= 2147473647) ? (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ") : "所有武器");
						propertyBridge = "";
						if (item.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
						{
							propertyBridge += "[HIGH ALT]";
						}
						if (item.PlottedCourse.Count() > 0)
						{
							ref string reference = ref propertyBridge;
							reference = reference + "[" + Conversions.ToString(item.PlottedCourse.Count()) + "航段]";
						}
						DarkTreeNode darkTreeNode2 = new DarkTreeNode();
						darkTreeNode2.Text = "Alloc: " + propertyBridge + text + item.GetReferenceWeapon(activeUnit_.ParentScen).Name;
						darkTreeNode2.Tag = item;
						darkTreeNode.Nodes.Add(darkTreeNode2);
					}
					if (shooter.QuantityFired > 0)
					{
						DarkTreeNode darkTreeNode3 = new DarkTreeNode();
						darkTreeNode3.Text = "射击：" + Conversions.ToString(shooter.QuantityFired) + "x " + item.GetReferenceWeapon(activeUnit_.ParentScen).Name;
						darkTreeNode.Nodes.Add(darkTreeNode3);
					}
				}
			}
			darkTreeNode.Expanded = true;
		}
		TV_Allocations_ByAnyone.Refresh();
	}

	private void SetSerializer()
	{
		if (TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			Button_Allocate.Enabled = false;
			Button_AllocateAllWeapons.Enabled = false;
			Button_AllocateSalvo.Enabled = false;
			return;
		}
		if (_WrapperBridge.Count <= 0)
		{
			Button_Allocate.Enabled = false;
			Button_AllocateAllWeapons.Enabled = false;
			Button_AllocateSalvo.Enabled = false;
			return;
		}
		if (issuerBridge.Count == 1)
		{
			Button_AllocateAllWeapons.Enabled = true;
		}
		else
		{
			Button_AllocateAllWeapons.Enabled = false;
		}
		Weapon weapon_ = (((object)TV_AvailableWeapons.SelectedNodes[0].Tag.GetType() == typeof(string)) ? ((Weapon)TV_AvailableWeapons.SelectedNodes[0].ParentNode.Tag) : ((Weapon)TV_AvailableWeapons.SelectedNodes[0].Tag));
		if (issuerBridge.Count <= 0)
		{
			Button_AllocateSalvo.Enabled = false;
			Button_Allocate.Enabled = false;
			return;
		}
		if (_WrapperBridge[0].Doctrine.InsertRepository(ref weapon_))
		{
			Button_AllocateSalvo.Enabled = true;
		}
		else
		{
			Button_AllocateSalvo.Enabled = false;
		}
		Button_Allocate.Enabled = true;
	}

	private void FillSerializer()
	{
		TV_AvailableWeapons.Nodes.Clear();
		SetSerializer();
		if (_WrapperBridge.Count == 1)
		{
			if (issuerBridge.Count == 0)
			{
				TV_AvailableWeapons.Enabled = false;
				return;
			}
			if (issuerBridge.Count > 1)
			{
				int num = 0;
				Contact_Base.ContactType contactType = Contact_Base.ContactType.Air;
				foreach (Contact item in issuerBridge)
				{
					if (num == 0)
					{
						contactType = item.Type;
					}
					else if (contactType != item.Type)
					{
						TV_AvailableWeapons.Enabled = false;
						return;
					}
					num++;
				}
			}
			TV_AvailableWeapons.Enabled = true;
			foreach (ActiveUnit item2 in _WrapperBridge)
			{
				Weapon[] array = item2.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
				Weapon[] array2 = array;
				foreach (Weapon weapon_ in array2)
				{
					CalculateSerializer(item2, weapon_);
				}
			}
			if (Information.IsNothing(consumerBridge) || TV_AvailableWeapons.SelectedNodes.Count != 0)
			{
				return;
			}
			{
				foreach (DarkTreeNode node in TV_AvailableWeapons.Nodes)
				{
					if (node.VisibleIndex == _FacadeBridge)
					{
						foreach (DarkTreeNode node2 in node.Nodes)
						{
							if (node2.VisibleIndex == consumerBridge.Value)
							{
								m_ReaderBridge = false;
								TV_AvailableWeapons.SelectNode(node2);
								m_ReaderBridge = true;
								break;
							}
						}
					}
					if (TV_AvailableWeapons.SelectedNodes.Count != 0)
					{
						break;
					}
				}
				return;
			}
		}
		TV_AvailableWeapons.Enabled = false;
	}

	private void CalculateSerializer(ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		bool? nullable_ = null;
		if (!weapon_0.IsPalletWeapon)
		{
			List<Contact> list;
			Contact contact_ = (list = issuerBridge)[0];
			bool num = weapon_0.QueryReponse(activeUnit_0, ref contact_, ref nullable_);
			list[0] = contact_;
			if (!num)
			{
				return;
			}
		}
		PopSerializer(activeUnit_0, weapon_0);
	}

	private void PopSerializer(ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		bool bool_ = true;
		int dBID = weapon_0.DBID;
		int num = activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(dBID, bool_1: true);
		int num2 = 0;
		if (activeUnit_0.IsWeapon)
		{
			foreach (WeaponRec weaponWeapon in ((Weapon)activeUnit_0).WeaponWeapons)
			{
				if (weaponWeapon.int_0 == dBID)
				{
					num2 = weaponWeapon.MaxLoad - weaponWeapon.CurrentLoad;
				}
			}
		}
		else
		{
			foreach (WeaponSalvo item5 in activeUnit_0.GetUnitSide().WeaponSalvosFromThisUnitToAnyTarget(ref activeUnit_0))
			{
				if (item5.int_0 != dBID)
				{
					continue;
				}
				WeaponSalvo.Shooter[] shootersList = item5.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(activeUnit_0.ObjectID, shooter.ShooterObjectID, TextCompare: true) == 0)
					{
						num2 += shooter.QuantityAssigned;
					}
				}
			}
		}
		string text = Conversions.ToString(num) + "x " + Misc.ReadRequest(weapon_0.Name);
		if (num2 <= 2147473647)
		{
			if (num2 > 0 && num2 < num)
			{
				text = text + " (" + Conversions.ToString(num2) + "x已分配）";
			}
		}
		else
		{
			text += "（所有武器分配）";
		}
		DarkTreeNode darkTreeNode = new DarkTreeNode(text);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		darkTreeNode.Tag = weapon_0;
		TV_AvailableWeapons.Nodes.Add(darkTreeNode);
		short? nullable_ = null;
		foreach (Mount mount in activeUnit_0.Mounts)
		{
			int num3 = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMountTotal(mount, dBID);
			if (num3 > 0)
			{
				ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
				Contact contact_ = issuerBridge[0];
				Sensor sensor_ = null;
				string item = weaponry.CanThisWeaponEngageThisTarget(weapon_0, contact_, ref nullable_, bool_, bool_2: false, bool_3: true, mount, ref sensor_).EvaluationString;
				if (dictionary.ContainsKey(item))
				{
					dictionary[item] += num3;
				}
				else
				{
					dictionary.Add(item, num3);
				}
			}
		}
		if (activeUnit_0.IsAircraft)
		{
			if (weapon_0.IsPalletWeapon)
			{
				{
					foreach (IGrouping<int, Warhead> item6 in (from CW in weapon_0.Warheads
						group CW by CW.GetCarriedWeapon(activeUnit_0.ParentScen).DBID).ToList())
					{
						if (item6.ElementAtOrDefault(0).GetCarriedWeapon(activeUnit_0.ParentScen) == null)
						{
							continue;
						}
						if (!Information.IsNothing(((Aircraft)activeUnit_0).Loadout))
						{
							int num4 = activeUnit_0.Weaponry.HowManyOfThisWeaponOnLoadout(((Aircraft)activeUnit_0).Loadout, item6.ElementAtOrDefault(0).GetCarriedWeapon(activeUnit_0.ParentScen).DBID, weapon_0.DBID, activeUnit_0.ParentScen);
							if (num4 > 0)
							{
								ActiveUnit_Weaponry weaponry2 = activeUnit_0.Weaponry;
								Weapon carriedWeapon = item6.ElementAtOrDefault(0).GetCarriedWeapon(activeUnit_0.ParentScen);
								Contact contact_2 = issuerBridge[0];
								Sensor sensor_2 = null;
								string item2 = weaponry2.CanThisWeaponEngageThisTarget(carriedWeapon, contact_2, ref nullable_, bool_, bool_2: false, bool_3: true, null, ref sensor_2).EvaluationString;
								if (dictionary.ContainsKey(item2))
								{
									dictionary[item2] += num4;
								}
								else
								{
									dictionary.Add(item2, num4);
								}
							}
						}
						InstantiateSerializer(activeUnit_0, item6.ElementAtOrDefault(0).GetCarriedWeapon(activeUnit_0.ParentScen), dictionary, darkTreeNode, weapon_0);
					}
					return;
				}
			}
			if (((Aircraft)activeUnit_0).Loadout != null)
			{
				int num5 = activeUnit_0.Weaponry.HowManyOfThisWeaponOnLoadout(((Aircraft)activeUnit_0).Loadout, dBID);
				if (num5 > 0)
				{
					ActiveUnit_Weaponry weaponry3 = activeUnit_0.Weaponry;
					Contact contact_3 = issuerBridge[0];
					Sensor sensor_3 = null;
					string item3 = weaponry3.CanThisWeaponEngageThisTarget(weapon_0, contact_3, ref nullable_, bool_, bool_2: false, bool_3: true, null, ref sensor_3).EvaluationString;
					if (dictionary.ContainsKey(item3))
					{
						dictionary[item3] += num5;
					}
					else
					{
						dictionary.Add(item3, num5);
					}
				}
			}
		}
		if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0).IsPalletWeapon)
		{
			foreach (WeaponRec weaponWeapon2 in ((Weapon)activeUnit_0).WeaponWeapons)
			{
				int currentLoad = weaponWeapon2.CurrentLoad;
				if (currentLoad > 0)
				{
					ActiveUnit_Weaponry weaponry4 = activeUnit_0.Weaponry;
					Weapon referenceWeapon = weaponWeapon2.GetReferenceWeapon(activeUnit_0.ParentScen);
					Contact contact_4 = issuerBridge[0];
					Sensor sensor_4 = null;
					string item4 = weaponry4.CanThisWeaponEngageThisTarget(referenceWeapon, contact_4, ref nullable_, bool_, bool_2: false, bool_3: true, null, ref sensor_4).EvaluationString;
					if (dictionary.ContainsKey(item4))
					{
						dictionary[item4] += currentLoad;
					}
					else
					{
						dictionary.Add(item4, currentLoad);
					}
				}
			}
			return;
		}
		InstantiateSerializer(activeUnit_0, weapon_0, dictionary, darkTreeNode);
	}

	private void InstantiateSerializer(ActiveUnit activeUnit_0, Weapon weapon_0, Dictionary<string, int> dictionary_0, DarkTreeNode darkTreeNode_0, Weapon weapon_1 = null)
	{
		weapon_0.FiringParent = activeUnit_0;
		int num = 0;
		num = ((weapon_1 == null) ? activeUnit_0.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0) : activeUnit_0.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_1));
		int num3 = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMagazines(weapon_0.DBID);
		if (num3 > 0)
		{
			dictionary_0.Add("武器在弹药库上", num3);
		}
		string text = null;
		bool flag;
		string text2;
		Doctrine._WCS wCS;
		string text3;
		float? num6;
		int? num7;
		string text4;
		string text5;
		if (SimConfiguration.DefaultGamePreferences.ShowAutomaticFireInfo)
		{
			flag = true;
			text2 = "";
			text2 = ((weapon_1 == null) ? "不允许自动射击" : "Automatic fire with pallettized weapon is not allowed");
			wCS = activeUnit_0.Weaponry.InstantiateConsumer(issuerBridge[0].Type);
			if (1 == 0)
			{
			}
			string text8 = wCS switch
			{
				Doctrine._WCS.Tight => (weapon_1 == null) ? "谨慎开火" : "PALLETTIZED WEAPONS TIGHT", 
				Doctrine._WCS.Free => (weapon_1 == null) ? "自由开火" : "PALLETTIZED WEAPONS FREE", 
				_ => (weapon_1 == null) ? "控制开火" : "PALLETTIZED WEAPONS HOLD", 
			};
			if (1 == 0)
			{
			}
			text3 = text8;
			List<Contact> list;
			Contact contact_ = (list = issuerBridge)[0];
			bool? nullable_ = false;
			Doctrine._WRA_WeaponTargetType num4 = Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_);
			list[0] = contact_;
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = num4;
			bool? nullable_2 = null;
			List<Contact> list2 = issuerBridge;
			contact_ = list2[0];
			Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_2);
			list2[0] = contact_;
			contact_ = (list = issuerBridge)[0];
			Doctrine._WRA_WeaponTargetType num5 = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_0, ref nullable_2);
			list[0] = contact_;
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_2 = num5;
			if (issuerBridge[0].ActualUnit != null)
			{
				text = " 目标类型是" + Doctrine.WRA_TargetType_String(wRA_WeaponTargetType_, nullable_2.Value);
			}
			Doctrine doctrine = activeUnit_0.Doctrine;
			Doctrine doctrine2 = activeUnit_0.Doctrine;
			Scenario parentScen = activeUnit_0.ParentScen;
			int dBID = weapon_0.DBID;
			float? nullable_3 = null;
			float? nullable_4 = null;
			num6 = doctrine.IncludeRepository(doctrine2, parentScen, dBID, wRA_WeaponTargetType_2, bool_0: false, ref nullable_3, ref nullable_4);
			if (Information.IsNothing(num6))
			{
				num6 = Doctrine.WRA_FiringRange_GetDefaultFiringRange(activeUnit_0.ParentScen, weapon_0.DBID, wRA_WeaponTargetType_2);
			}
			nullable_4 = num6;
			nullable_ = (nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == 0f) : null);
			if (((!nullable_) ?? nullable_).GetValueOrDefault())
			{
				Doctrine doctrine3 = activeUnit_0.Doctrine;
				Scenario parentScen2 = activeUnit_0.ParentScen;
				int? nullable_5 = null;
				int? nullable_6 = null;
				num7 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine3, parentScen2, weapon_0, wRA_WeaponTargetType_2, bool_0: false, ref nullable_5, ref nullable_6);
				if (Information.IsNothing(num7))
				{
					num7 = 0;
				}
			}
			else
			{
				num7 = 0;
			}
			if (Information.IsNothing(num7))
			{
				text4 = ((weapon_1 == null) ? "不要对此目标类型使用武器类型" : "Do not use the pallettized weapon type against this target type");
				text5 = "";
			}
			else
			{
				nullable_4 = num6;
				text4 = ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == 0f) : null).GetValueOrDefault() ? "" : (Doctrine.WRA_WeaponQty_String(num7, activeUnit_0, issuerBridge[0], weapon_0) + ". "));
				int? num8 = num7;
				nullable_ = (num8.HasValue ? new bool?(num8.GetValueOrDefault() == 0) : null);
				if (nullable_.GetValueOrDefault(true))
				{
					nullable_4 = num6;
					bool? flag2 = (nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == 0f) : null);
					if (((!flag2) ?? flag2).GetValueOrDefault() && nullable_.HasValue)
					{
						text5 = "";
						goto IL_0487;
					}
				}
				text5 = activeUnit_0.Doctrine.FindRepository(num6) + ". ";
			}
			goto IL_0487;
		}
		goto IL_0862;
		IL_0862:
		foreach (KeyValuePair<string, int> item in dictionary_0)
		{
			if (weapon_1 == null)
			{
				DarkTreeNode darkTreeNode4 = new DarkTreeNode();
				string key = item.Key;
				string text6 = Conversions.ToString(item.Value);
				if (string.CompareOrdinal(key, "OK") == 0)
				{
					darkTreeNode4.Text = text6 + "x 可以开火（手动武器分配）";
					darkTreeNode4.ForeColor = Color.LightGreen;
				}
				else
				{
					darkTreeNode4.Text = text6 + "x 不能开火。" + key;
					darkTreeNode4.ForeColor = Color.IndianRed;
				}
				darkTreeNode4.Tag = weapon_0;
				darkTreeNode_0.Nodes.Add(darkTreeNode4);
				continue;
			}
			DarkTreeNode darkTreeNode5 = new DarkTreeNode();
			string key2 = item.Key;
			string text7 = Conversions.ToString(item.Value);
			if (string.CompareOrdinal(key2, "OK") == 0)
			{
				int num2 = activeUnit_0.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0);
				darkTreeNode5.Text = text7 + "x " + weapon_0.Name + " can FIRE (manual weapon allocation)  (" + Conversions.ToString(num2) + "x已分配）";
				darkTreeNode5.ForeColor = Color.LightGreen;
			}
			else
			{
				darkTreeNode5.Text = text7 + "x " + weapon_0.Name + " can NOT fire. " + key2 + " (" + Conversions.ToString(num) + "x已分配）";
				darkTreeNode5.ForeColor = Color.IndianRed;
			}
			darkTreeNode5.Tag = weapon_0;
			darkTreeNode_0.Nodes.Add(darkTreeNode5);
		}
		darkTreeNode_0.Expanded = true;
		return;
		IL_0487:
		if (issuerBridge[0].Type == Contact_Base.ContactType.ActivationPoint)
		{
			flag = false;
			text2 = ((weapon_1 == null) ? "无法自动射击，目标是仅方位攻击（BOL）点或落点！" : "Automatic fire with pallettized weapon is NOT possible, target is Bearing Only Launch (BOL) point or Impact point!");
		}
		else
		{
			Misc.PostureStance stance = issuerBridge[0].GetStance(activeUnit_0.GetUnitSide());
			if (Information.IsNothing(stance))
			{
				flag = false;
				text2 = "可能无法确定目标对抗关系！";
			}
			else
			{
				switch (stance)
				{
				case Misc.PostureStance.Hostile:
					if (wCS == Doctrine._WCS.Hold)
					{
						flag = false;
						text2 = ((weapon_1 == null) ? "不允许自动射击，武器控制状态（WCS）是控制开火" : "Automatic fire is NOT allowed, Weapon Control Status for pallettized weapon (WCS) is WEAPONS HOLD");
					}
					break;
				case Misc.PostureStance.Unfriendly:
				case Misc.PostureStance.Unknown:
					switch (wCS)
					{
					case Doctrine._WCS.Hold:
						flag = false;
						text2 = ((weapon_1 == null) ? "不允许自动射击，武器控制状态（WCS）是控制开火" : "Automatic fire is NOT allowed, Weapon Control Status for pallkettized weapon (WCS) is WEAPONS HOLD");
						break;
					case Doctrine._WCS.Tight:
						flag = false;
						text2 = ((weapon_1 == null) ? "不允许自动射击，武器控制状态（WCS）是谨慎开火，目标未被识别为敌对" : "Automatic fire is NOT allowed, Weapon Control Status for pallettized weapon (WCS) is WEAPONS TIGHT and target is not identified as Hostile");
						break;
					}
					break;
				}
			}
		}
		if (flag)
		{
			float? num9 = num6;
			if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
			{
				flag = false;
				text2 = ((weapon_1 == null) ? ("武器释放授权（WRA）不允许自动射击" + text5) : ("Automatic fire is NOT allowed, Weapon Release Authorization (WRA) for the pallettized weapon says " + text5));
			}
			else
			{
				int? num10 = num7;
				if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 0) : null).GetValueOrDefault())
				{
					flag = false;
					text2 = ((weapon_1 == null) ? ("武器释放授权（WRA）不允许自动射击" + text4) : ("Automatic fire is NOT allowed, Weapon Release Authorization (WRA) for the pallettized weapon says " + text4));
				}
			}
		}
		if (activeUnit_0.IsAircraft && weapon_0.Type == Weapon._WeaponType.Gun && issuerBridge[0].IsSurfaceContact)
		{
			Doctrine._GunStrafeGroundTargets? gunStrafeGroundTargets = null;
			if (Information.IsNothing(gunStrafeGroundTargets))
			{
				gunStrafeGroundTargets = activeUnit_0.Doctrine.GetGunStrafing(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			}
			byte? b = (byte?)gunStrafeGroundTargets;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				flag = false;
				text2 = "根据条令“不要对地面和舰船目标使用枪支”，不允许自动射击";
			}
		}
		if (flag)
		{
			if (dictionary_0.ContainsKey("OK"))
			{
				text2 = ((weapon_1 == null) ? "允许自动射击。" : "Automatic fire with the pallettized weapon is allowed.");
			}
			else
			{
				flag = false;
				text2 = ((weapon_1 == null) ? ("不能自动射击，" + dictionary_0.Keys.ElementAtOrDefault(0)) : ("Automatic fire with the pallettized weapon is NOT possible, " + dictionary_0.Keys.ElementAtOrDefault(0)));
			}
		}
		DarkTreeNode darkTreeNode = new DarkTreeNode();
		darkTreeNode.Text = text2;
		darkTreeNode.Tag = "";
		if (flag)
		{
			darkTreeNode.ForeColor = Color.LightGreen;
		}
		else
		{
			darkTreeNode.ForeColor = Color.IndianRed;
		}
		darkTreeNode_0.Nodes.Add(darkTreeNode);
		DarkTreeNode darkTreeNode2 = new DarkTreeNode();
		darkTreeNode2.Text = "武器控制状态（WCS）：" + text3;
		darkTreeNode2.Tag = "";
		darkTreeNode2.ForeColor = Color.DarkGray;
		darkTreeNode_0.Nodes.Add(darkTreeNode2);
		DarkTreeNode darkTreeNode3 = new DarkTreeNode();
		darkTreeNode3.Text = "武器释放授权（WRA）：" + text4 + text5 + text;
		darkTreeNode3.Tag = "";
		darkTreeNode3.ForeColor = Color.DarkGray;
		darkTreeNode_0.Nodes.Add(darkTreeNode3);
		goto IL_0862;
	}

	private void CreateSerializer(object sender, EventArgs e)
	{
		_WrapperBridge.Clear();
		foreach (DarkListItem selectedItem in LB_Attackers.SelectedItems)
		{
			_WrapperBridge.Add((ActiveUnit)selectedItem.Tag);
			_WrapperBridge.Last().ParentScen = Client.CurrentScenario;
		}
		if (_WrapperBridge.Count == 1)
		{
			Button_UnitWRA.Enabled = true;
		}
		else
		{
			Button_UnitWRA.Enabled = false;
		}
		if (m_ReaderBridge)
		{
			if (LB_Attackers.SelectedIndices.Count > 0)
			{
				m_ObserverBridge = LB_Attackers.SelectedIndices[0];
			}
			FillSerializer();
			ChangeSerializer();
			TV_Allocations_ByAttackersOnly.Refresh();
			TV_Allocations_ByAnyone.Refresh();
			TV_Allocations_ToTargetsOnly.Refresh();
			TV_Allocations_ToAnyone.Refresh();
		}
	}

	private void CompareSerializer(object sender, EventArgs e)
	{
		issuerBridge.Clear();
		foreach (DarkListItem selectedItem in LB_Targets.SelectedItems)
		{
			issuerBridge.Add((Contact)selectedItem.Tag);
		}
		if (m_ReaderBridge)
		{
			if (LB_Targets.SelectedIndices.Count != 0)
			{
				clientBridge = LB_Targets.SelectedIndices[0];
			}
			FillSerializer();
			ChangeSerializer();
		}
	}

	private void ReadSerializer(object sender, EventArgs e)
	{
		ChangeSerializer();
	}

	private void DisableSerializer(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 && e.Modifiers == Keys.Shift && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	public AttackTarget()
	{
		base.FormClosing += SetupSerializer;
		base.Load += IncludeSerializer;
		base.KeyDown += DisableSerializer;
		Targets = new List<Contact>();
		Attackers = new List<ActiveUnit>();
		_WrapperBridge = new List<ActiveUnit>();
		issuerBridge = new List<Contact>();
		m_ReaderBridge = true;
		m_RepositoryBridge = new Keys[2]
		{
			Keys.F1,
			Keys.Escape
		};
		InvokeSerializer();
	}

	private void InsertSerializer()
	{
		try
		{
			SendMessage(base.Handle, 11, new IntPtr(0), IntPtr.Zero);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200372", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PrepareSerializer(bool bool_0 = true)
	{
		try
		{
			SendMessage(base.Handle, 11, new IntPtr(-1), IntPtr.Zero);
			if (bool_0)
			{
				Refresh();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 200373", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReflectSerializer(object sender, EventArgs e)
	{
		if (_WrapperBridge.Count == 1)
		{
			DoctrineForm doctrineForm = new DoctrineForm();
			doctrineForm.Subject = _WrapperBridge[0];
			doctrineForm.Show();
			doctrineForm.TabControl1A.SelectedIndex = 2;
		}
	}

	private void VisitSerializer(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedUnit) || Information.IsNothing(Client.SelectedUnit.GetUnitSide()) || ((Client.CurrentSide.SelectedUnits.Count <= 0 || Information.IsNothing(Client.SelectedUnit)) && (Client.CurrentSide.SelectedUnits.Count != 0 || Information.IsNothing(Client.SelectedUnit) || !Information.IsNothing(Client.SelectedWaypoint))))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && !selectedUnit.IsWeapon && selectedUnit.GetUnitSide() == Client.CurrentSide)
			{
				ActiveUnit item = (ActiveUnit)selectedUnit;
				if (!Attackers.Contains(item))
				{
					Attackers.Add(item);
				}
			}
		}
		InitSerializer();
	}

	private void RestartSerializer(object sender, EventArgs e)
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (_WrapperBridge.Count > 0)
		{
			foreach (ActiveUnit item in _WrapperBridge)
			{
				list.Add(item);
			}
		}
		foreach (ActiveUnit item2 in list)
		{
			Attackers.Remove(item2);
		}
		_WrapperBridge.Clear();
		InitSerializer();
		FillSerializer();
	}

	private void TestSerializer(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedUnit) || Client.CurrentSide.SelectedUnits.Count <= 0 || Information.IsNothing(Client.SelectedUnit))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.DisableWriter())
			{
				Contact item = (Contact)selectedUnit;
				if (!Targets.Contains(item))
				{
					Targets.Add(item);
				}
			}
		}
		CheckSerializer();
	}

	private void StopSerializer(object sender, EventArgs e)
	{
		List<Contact> list = new List<Contact>();
		if (issuerBridge.Count > 0)
		{
			foreach (Contact item in issuerBridge)
			{
				list.Add(item);
			}
		}
		foreach (Contact item2 in list)
		{
			Targets.Remove(item2);
		}
		issuerBridge.Clear();
		CheckSerializer();
		FillSerializer();
	}

	private void CancelSerializer(object sender, EventArgs e)
	{
		if (TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
		Weapon weapon_ = (((object)darkTreeNode.Tag.GetType() == typeof(string)) ? ((Weapon)darkTreeNode.ParentNode.Tag) : ((Weapon)darkTreeNode.Tag));
		foreach (Contact item in issuerBridge)
		{
			Contact contact_ = item;
			List<ActiveUnit> wrapperBridge = _WrapperBridge;
			ActiveUnit activeUnit_ = wrapperBridge[0];
			VerifySerializer(ref activeUnit_, ref contact_, ref weapon_, bool_0: true);
			wrapperBridge[0] = activeUnit_;
		}
		FillSerializer();
		ChangeSerializer();
	}

	private void VerifySerializer(ref ActiveUnit activeUnit_0, ref Contact contact_0, ref Weapon weapon_0, bool bool_0 = false)
	{
		try
		{
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType;
			if (weapon_0.ValidTargets.Radar)
			{
				wRA_WeaponTargetType = Doctrine._WRA_WeaponTargetType.Radar_Unspecified;
			}
			else
			{
				Weapon weapon_ = weapon_0;
				bool? nullable_ = null;
				wRA_WeaponTargetType = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_, ref nullable_);
			}
			if (activeUnit_0.IsAircraft)
			{
				WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					if (!weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).IsPalletWeapon)
					{
						continue;
					}
					if (weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons.Count == 0)
					{
						weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons)
					{
						if (weaponWeapon.int_0 == weapon_0.DBID)
						{
							weapon_0 = weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen);
						}
					}
				}
			}
			int? num = null;
			int? nullable_3;
			if (weapon_0.IsPalletWeapon)
			{
				if (weapon_0.WeaponWeapons.Count == 0)
				{
					weapon_0.InitializeWeaponWeaponsPallet();
				}
				int? nullable_2 = null;
				foreach (WeaponRec weaponWeapon2 in weapon_0.WeaponWeapons)
				{
					Doctrine doctrine = activeUnit_0.Doctrine;
					Scenario parentScen = activeUnit_0.ParentScen;
					Weapon referenceWeapon = weaponWeapon2.GetReferenceWeapon(activeUnit_0.ParentScen);
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = wRA_WeaponTargetType;
					nullable_3 = null;
					int? nullable_4 = null;
					num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine, parentScen, referenceWeapon, wRA_WeaponTargetType_, bool_0: false, ref nullable_3, ref nullable_4);
					nullable_4 = num;
					if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -99) : null).GetValueOrDefault())
					{
						num = int.MaxValue;
					}
					if (!num.HasValue)
					{
						continue;
					}
					nullable_4 = num;
					if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() < 0) : null).GetValueOrDefault())
					{
						num = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(nullable_2, ref activeUnit_0, ref contact_0, ref weapon_0);
						nullable_4 = num;
						if ((nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == -99) : null).GetValueOrDefault())
						{
							num = int.MaxValue;
						}
					}
					if (!num.HasValue)
					{
						return;
					}
					nullable_4 = num;
					if (!(nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						nullable_4 = num;
						if (!(nullable_4.HasValue ? new bool?(nullable_4.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							List<ActiveUnit> wrapperBridge = _WrapperBridge;
							ActiveUnit activeUnit_ = wrapperBridge[0];
							Weapon weapon_2 = weaponWeapon2.GetReferenceWeapon(activeUnit_0.ParentScen);
							int int_ = num.Value;
							ResolveSerializer(ref activeUnit_, ref contact_0, ref weapon_2, ref int_, weapon_0);
							wrapperBridge[0] = activeUnit_;
							break;
						}
					}
					return;
				}
			}
			else
			{
				Doctrine doctrine2 = activeUnit_0.Doctrine;
				Scenario parentScen2 = activeUnit_0.ParentScen;
				Weapon weapon_3 = weapon_0;
				Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_2 = wRA_WeaponTargetType;
				int? nullable_5 = null;
				nullable_3 = null;
				num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine2, parentScen2, weapon_3, wRA_WeaponTargetType_2, bool_0: false, ref nullable_5, ref nullable_3);
			}
			if (Information.IsNothing(num))
			{
				return;
			}
			nullable_3 = num;
			if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				return;
			}
			nullable_3 = num;
			if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == -99) : null).GetValueOrDefault())
			{
				num = int.MaxValue;
			}
			else
			{
				nullable_3 = num;
				if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() < 0) : null).GetValueOrDefault())
				{
					num = activeUnit_0.GetUnitSide().ConvertSalvoWeaponQty_To_ActualQuantity(num, ref activeUnit_0, ref contact_0, ref weapon_0);
				}
			}
			int num2 = (weapon_0.IsPalletWeapon ? activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(weapon_0.DBID, bool_1: false, weapon_0) : activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(weapon_0.DBID, bool_1: false));
			num2 -= activeUnit_0.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0);
			nullable_3 = num;
			if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() > num2) : null).GetValueOrDefault())
			{
				num = num2;
			}
			nullable_3 = num;
			if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() > 0) : null).GetValueOrDefault())
			{
				ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
				Contact contact_ = contact_0;
				int dBID = weapon_0.DBID;
				int value = num.Value;
				Doctrine._GunStrafeGroundTargets? nullable_6 = null;
				weaponry.CreateSalvo(contact_, dBID, value, bool_1: true, ref nullable_6, DateTime.MinValue, bool_0, bool_3: true);
				ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101234", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ListSerializer(object sender, EventArgs e)
	{
		int int_ = Convert.ToInt32(NUD_NumberOfWeapons.Value);
		if (!Versioned.IsNumeric(NUD_NumberOfWeapons.Value) || decimal.Compare(NUD_NumberOfWeapons.Value, 0m) <= 0 || TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
		Weapon weapon_ = (((object)darkTreeNode.Tag.GetType() == typeof(string)) ? ((Weapon)darkTreeNode.ParentNode.Tag) : ((Weapon)darkTreeNode.Tag));
		foreach (Contact item in issuerBridge)
		{
			Contact contact_ = item;
			if (darkTreeNode.ParentNode == null)
			{
				List<ActiveUnit> wrapperBridge = _WrapperBridge;
				ActiveUnit activeUnit_ = wrapperBridge[0];
				ResolveSerializer(ref activeUnit_, ref contact_, ref weapon_, ref int_);
				wrapperBridge[0] = activeUnit_;
				continue;
			}
			Weapon weapon = (Weapon)darkTreeNode.ParentNode.Tag;
			if (weapon.IsPalletWeapon)
			{
				List<ActiveUnit> wrapperBridge2 = _WrapperBridge;
				ActiveUnit activeUnit_2 = wrapperBridge2[0];
				ResolveSerializer(ref activeUnit_2, ref contact_, ref weapon_, ref int_, weapon);
				wrapperBridge2[0] = activeUnit_2;
			}
			else
			{
				List<ActiveUnit> wrapperBridge3 = _WrapperBridge;
				ActiveUnit activeUnit_3 = wrapperBridge3[0];
				ResolveSerializer(ref activeUnit_3, ref contact_, ref weapon_, ref int_);
				wrapperBridge3[0] = activeUnit_3;
			}
		}
		FillSerializer();
		ChangeSerializer();
	}

	private void ResolveSerializer(ref ActiveUnit activeUnit_0, ref Contact contact_0, ref Weapon weapon_0, ref int int_0, Weapon weapon_1 = null)
	{
		try
		{
			int num = activeUnit_0.Weaponry.TotalAvailableInventoryForThisWeapon(weapon_0.DBID, bool_1: false, weapon_1);
			int num2 = num - activeUnit_0.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0);
			if (int_0 > num2)
			{
				int_0 = num2;
			}
			int num3 = 0;
			if (activeUnit_0.IsAircraft)
			{
				WeaponRec[] weapons = ((Aircraft)activeUnit_0).Loadout.Weapons;
				WeaponRec[] array = weapons;
				foreach (WeaponRec weaponRec in array)
				{
					if (!weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).IsPalletWeapon)
					{
						continue;
					}
					if (weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons.Count == 0)
					{
						weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).InitializeWeaponWeaponsPallet();
					}
					foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen).WeaponWeapons)
					{
						if (weaponWeapon.int_0 == weapon_0.DBID)
						{
							weapon_1 = weaponRec.GetReferenceWeapon(activeUnit_0.ParentScen);
							num3 = weaponRec.CurrentLoad;
						}
					}
				}
			}
			int num4 = 0;
			int num5 = 0;
			if (weapon_1 != null)
			{
				int num6 = 0;
				num4 = weapon_1.WeaponWeapons.FirstOrDefault().CurrentLoad;
				foreach (WeaponRec weaponWeapon2 in weapon_1.WeaponWeapons)
				{
					num6 = weaponWeapon2.CurrentLoad - (int_0 + activeUnit_0.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_0, weapon_0));
					if (num6 == 0)
					{
						continue;
					}
					if (num6 <= 0)
					{
						if (num6 % num4 != 0)
						{
							DarkMessageBox.ShowWarning("the WHOLE pallet will be dropped even if the pallet contains unallocated weapon(s) " + (weaponWeapon2.CurrentLoad + num6) + " weapon(s) unallocated", "Pallet contains unallocated weapon(s)");
						}
					}
					else
					{
						DarkMessageBox.ShowWarning("the WHOLE pallet will be dropped even if the pallet contains unallocated weapon(s) " + num6 + " weapon(s) unallocated", "Pallet contains unallocated weapon(s)");
					}
				}
			}
			if (int_0 <= 0)
			{
				return;
			}
			if (weapon_1 == null)
			{
				ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
				Contact contact_ = contact_0;
				int dBID = weapon_0.DBID;
				int int_ = int_0;
				Doctrine._GunStrafeGroundTargets? nullable_ = null;
				weaponry.CreateSalvo(contact_, dBID, int_, bool_1: true, ref nullable_, DateTime.MinValue, bool_2: false, bool_3: true);
			}
			else
			{
				int num7 = 0;
				while (num5 <= num3)
				{
					num7 += num4;
					num5++;
					if (num7 >= int_0)
					{
						break;
					}
				}
				Doctrine._GunStrafeGroundTargets? nullable_2;
				if ((num - num2 == 0) | (num - num2 + int_0 > num4))
				{
					ActiveUnit_Weaponry weaponry2 = activeUnit_0.Weaponry;
					Contact contact_2 = contact_0;
					int dBID2 = weapon_1.DBID;
					int int_2 = num5;
					nullable_2 = null;
					weaponry2.CreateSalvo(contact_2, dBID2, int_2, bool_1: true, ref nullable_2, DateTime.MinValue, bool_2: false, bool_3: false, bool_4: false, bool_5: true);
				}
				ActiveUnit_Weaponry weaponry3 = activeUnit_0.Weaponry;
				Contact contact_3 = contact_0;
				int dBID3 = weapon_0.DBID;
				int int_3 = int_0;
				nullable_2 = null;
				weaponry3.CreateSalvo(contact_3, dBID3, int_3, bool_1: true, ref nullable_2, DateTime.MaxValue);
			}
			Client.MustRefreshMainForm = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101235", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PostSerializer(object sender, EventArgs e)
	{
		try
		{
			if (TV_AvailableWeapons.SelectedNodes.Count == 0)
			{
				return;
			}
			DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
			Weapon weapon = (((object)darkTreeNode.Tag.GetType() == typeof(string)) ? ((Weapon)darkTreeNode.ParentNode.Tag) : ((Weapon)darkTreeNode.Tag));
			int num = _WrapperBridge[0].Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, bool_1: false);
			int num2 = num;
			Side unitSide = _WrapperBridge[0].GetUnitSide();
			List<ActiveUnit> wrapperBridge;
			ActiveUnit activeUnit_ = (wrapperBridge = _WrapperBridge)[0];
			int num3 = unitSide.NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_, weapon);
			wrapperBridge[0] = activeUnit_;
			num = num2 - num3;
			if (num > 0)
			{
				bool flag = false;
				if (_WrapperBridge[0].IsAircraft)
				{
					WeaponRec[] weapons = ((Aircraft)_WrapperBridge[0]).Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						if (!weaponRec.GetReferenceWeapon(_WrapperBridge[0].ParentScen).IsPalletWeapon)
						{
							continue;
						}
						if (weaponRec.GetReferenceWeapon(_WrapperBridge[0].ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.GetReferenceWeapon(_WrapperBridge[0].ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(_WrapperBridge[0].ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_0 == weapon.DBID)
							{
								flag = true;
								Weapon referenceWeapon = weaponRec.GetReferenceWeapon(_WrapperBridge[0].ParentScen);
								int currentLoad = weaponRec.CurrentLoad;
								ActiveUnit_Weaponry weaponry = _WrapperBridge[0].Weaponry;
								Contact contact_ = issuerBridge[0];
								int dBID = referenceWeapon.DBID;
								Doctrine._GunStrafeGroundTargets? nullable_ = null;
								weaponry.CreateSalvo(contact_, dBID, currentLoad, bool_1: true, ref nullable_, DateTime.MinValue, bool_2: false, bool_3: true);
							}
						}
					}
				}
				if (!flag)
				{
					ActiveUnit_Weaponry weaponry2 = _WrapperBridge[0].Weaponry;
					Contact contact_2 = issuerBridge[0];
					int dBID2 = weapon.DBID;
					int int_ = num;
					Doctrine._GunStrafeGroundTargets? nullable_2 = null;
					weaponry2.CreateSalvo(contact_2, dBID2, int_, bool_1: true, ref nullable_2, DateTime.MinValue, bool_2: false, bool_3: true);
				}
				Client.MustRefreshMainForm = true;
			}
			FillSerializer();
			ChangeSerializer();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_.Data.Add("Error at 101236", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RunSerializer(object sender, EventArgs e)
	{
		if (TabControl2.SelectedIndex == 0)
		{
			PublishSerializer(bool_0: true);
		}
		else
		{
			AwakeSerializer(bool_0: true);
		}
	}

	private void StartSerializer(object sender, EventArgs e)
	{
		if (TabControl4.SelectedIndex == 0)
		{
			QuerySerializer(bool_0: true);
		}
		else
		{
			ResetSerializer(bool_0: true);
		}
	}

	private void AssetSerializer(object sender, MouseEventArgs e)
	{
		try
		{
			if (TV_AvailableWeapons.SelectedNodes.Count != 0 && issuerBridge.Count <= 1)
			{
				if ((object)TV_AvailableWeapons.SelectedNodes[0].Tag.GetType() == typeof(string))
				{
					_ = (Weapon)TV_AvailableWeapons.SelectedNodes[0].ParentNode.Tag;
				}
				else
				{
					_ = (Weapon)TV_AvailableWeapons.SelectedNodes[0].Tag;
				}
				if (!_WrapperBridge[0].AI.Targets_ReadOnly.Contains(issuerBridge[0]))
				{
					_WrapperBridge[0].AI.TargetThisContact(issuerBridge[0], bool_0: true, bool_1: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
				}
				decimal value = NUD_NumberOfWeapons.Value;
				NUD_NumberOfWeapons.Value = 1m;
				ListSerializer(Button_Allocate, null);
				NUD_NumberOfWeapons.Value = value;
				Client.MustRefreshMainForm = true;
				FillSerializer();
				ChangeSerializer();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex.Data.Add("Error at 101237", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PrintSerializer()
	{
		if (_WrapperBridge.Count <= 0)
		{
			return;
		}
		_WrapperBridge = _WrapperBridge.Where((ActiveUnit x) => x.GetUnitSide() != null).ToList();
		foreach (WeaponSalvo item in _WrapperBridge[0].GetUnitSide().WeaponSalvos.ToList())
		{
			if (item.ShootersList.Length == 0 && item.WpnQuantityAssigned == 0 && item.WpnQuantityFired == 0)
			{
				ArrayExtensions.Remove(ref _WrapperBridge[0].GetUnitSide().WeaponSalvos, item);
			}
		}
	}

	private void DefineSerializer(DarkTreeNode darkTreeNode_0)
	{
		if (darkTreeNode_0 == null)
		{
			return;
		}
		ActiveUnit activeUnit = (ActiveUnit)darkTreeNode_0.Tag;
		foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
		{
			if (node == null || node.Tag == null || (object)node.Tag.GetType() != typeof(WeaponSalvo))
			{
				continue;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)node.Tag;
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			WeaponSalvo.Shooter[] array = shootersList;
			foreach (WeaponSalvo.Shooter shooter in array)
			{
				if (Operators.CompareString(shooter.ShooterObjectID, activeUnit.ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
				{
					shooter.QuantityAssigned = shooter.QuantityFired;
					Side unitSide = _WrapperBridge[0].GetUnitSide();
					Scenario scenario_ = Client.CurrentScenario;
					unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo, bool_0: true);
				}
			}
		}
		FillSerializer();
		ChangeSerializer();
	}

	private void PublishSerializer(bool bool_0)
	{
		if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag is ActiveUnit)
		{
			DefineSerializer(TV_Allocations_ToTargetsOnly.SelectedNodes[0]);
		}
		else
		{
			if ((object)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			WeaponSalvo.Shooter[] array = shootersList;
			foreach (WeaponSalvo.Shooter shooter in array)
			{
				foreach (ActiveUnit item in _WrapperBridge)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, item.ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						if (bool_0)
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
						}
						else
						{
							shooter.QuantityAssigned--;
						}
						Side unitSide = _WrapperBridge[0].GetUnitSide();
						Scenario scenario_ = Client.CurrentScenario;
						unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
					}
				}
			}
			FillSerializer();
			ChangeSerializer();
		}
	}

	private void AwakeSerializer(bool bool_0)
	{
		if (TV_Allocations_ToAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToAnyone.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ToAnyone.SelectedNodes[0].Tag is ActiveUnit)
		{
			DefineSerializer(TV_Allocations_ToAnyone.SelectedNodes[0]);
		}
		else
		{
			if ((object)TV_Allocations_ToAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ToAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			WeaponSalvo.Shooter[] array = shootersList;
			foreach (WeaponSalvo.Shooter shooter in array)
			{
				foreach (ActiveUnit item in _WrapperBridge)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, item.ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						if (bool_0)
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
						}
						else
						{
							shooter.QuantityAssigned--;
						}
						Side unitSide = _WrapperBridge[0].GetUnitSide();
						Scenario scenario_ = Client.CurrentScenario;
						unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
					}
				}
			}
			FillSerializer();
			ChangeSerializer();
		}
	}

	private void QuerySerializer(bool bool_0)
	{
		if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag is ActiveUnit)
		{
			DefineSerializer(TV_Allocations_ByAttackersOnly.SelectedNodes[0]);
		}
		else
		{
			if ((object)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			WeaponSalvo.Shooter[] array = shootersList;
			foreach (WeaponSalvo.Shooter shooter in array)
			{
				if (Operators.CompareString(shooter.ShooterObjectID, _WrapperBridge[0].ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
				{
					if (bool_0)
					{
						shooter.QuantityAssigned = shooter.QuantityFired;
					}
					else
					{
						shooter.QuantityAssigned--;
					}
					Side unitSide = _WrapperBridge[0].GetUnitSide();
					Scenario scenario_ = Client.CurrentScenario;
					unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
				}
			}
			FillSerializer();
			ChangeSerializer();
		}
	}

	private void ResetSerializer(bool bool_0)
	{
		if (TV_Allocations_ByAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ByAnyone.SelectedNodes[0].Tag is ActiveUnit)
		{
			DefineSerializer(TV_Allocations_ByAnyone.SelectedNodes[0]);
		}
		else
		{
			if (Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].ParentNode.Tag)) || (object)TV_Allocations_ByAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			WeaponSalvo weaponSalvo = (WeaponSalvo)TV_Allocations_ByAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
			WeaponSalvo.Shooter[] shootersList = weaponSalvo.ShootersList;
			WeaponSalvo.Shooter[] array = shootersList;
			foreach (WeaponSalvo.Shooter shooter in array)
			{
				if (Operators.CompareString(shooter.ShooterObjectID, ((ActiveUnit)TV_Allocations_ByAnyone.SelectedNodes[0].ParentNode.Tag).ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
				{
					if (bool_0)
					{
						shooter.QuantityAssigned = shooter.QuantityFired;
					}
					else
					{
						shooter.QuantityAssigned--;
					}
					Side unitSide = _WrapperBridge[0].GetUnitSide();
					Scenario scenario_ = Client.CurrentScenario;
					unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
				}
			}
			FillSerializer();
			ChangeSerializer();
		}
	}

	private void MapSerializer(object sender, EventArgs e)
	{
		ChangeSerializer();
	}

	private void SortSerializer(object sender, EventArgs e)
	{
		if (m_ReaderBridge)
		{
			SimConfiguration.DefaultGamePreferences.SalvoTimeout = CB_AllowTimeout.Checked;
		}
	}

	private void CalcSerializer(object sender, EventArgs e)
	{
		if (m_ReaderBridge)
		{
			SimConfiguration.DefaultGamePreferences.ShowAutomaticFireInfo = CB_ShowAutomaticFireInfo.Checked;
			FillSerializer();
		}
	}

	private void RateSerializer(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (TabControl2.SelectedIndex == 0)
		{
			if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ToAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		Client.getterClass = weaponSalvo;
		Client.CurrentUserAction = Client.UserAction.PlottingCourseForSalvo;
	}

	private void FlushSerializer(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (TabControl2.SelectedIndex == 0)
		{
			if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ToAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ToAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ToAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		if (!Information.IsNothing(weaponSalvo))
		{
			ArrayExtensions.Clear(ref weaponSalvo.PlottedCourse);
			RefreshForm();
		}
	}

	private void ForgotSerializer(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (TabControl4.SelectedIndex == 0)
		{
			if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ByAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		Client.getterClass = weaponSalvo;
		Client.CurrentUserAction = Client.UserAction.PlottingCourseForSalvo;
	}

	private void CollectSerializer(object sender, EventArgs e)
	{
		WeaponSalvo weaponSalvo;
		if (TabControl4.SelectedIndex == 0)
		{
			if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		else
		{
			if (TV_Allocations_ByAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].Tag)) || (object)TV_Allocations_ByAnyone.SelectedNodes[0].Tag.GetType() != typeof(WeaponSalvo))
			{
				return;
			}
			weaponSalvo = (WeaponSalvo)TV_Allocations_ByAnyone.SelectedNodes[0].Tag;
			if (Information.IsNothing(weaponSalvo))
			{
				return;
			}
		}
		if (!Information.IsNothing(weaponSalvo))
		{
			ArrayExtensions.Clear(ref weaponSalvo.PlottedCourse);
			RefreshForm();
		}
	}

	private void OrderSerializer(object sender, EventArgs e)
	{
		if (!Information.IsNothing(m_ImporterBridge))
		{
			TSMI_HighAltitudeDetonation.Checked = !TSMI_HighAltitudeDetonation.Checked;
			if (TSMI_HighAltitudeDetonation.Checked)
			{
				m_ImporterBridge.ActiveSpecialMode = Weapon.WeaponSpecialMode.HighAltitudeDetonation;
			}
			else
			{
				m_ImporterBridge.ActiveSpecialMode = Weapon.WeaponSpecialMode.None;
			}
			RefreshForm();
		}
	}

	private void RegisterSerializer()
	{
		Weapon referenceWeapon = m_ImporterBridge.GetReferenceWeapon(Client.CurrentScenario);
		TSMI_HighAltitudeDetonation.Enabled = referenceWeapon.ValidSpecialModes.Contains(Weapon.WeaponSpecialMode.HighAltitudeDetonation);
		TSMI_HighAltitudeDetonation.Checked = m_ImporterBridge.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation;
	}

	private void ManageSerializer(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			CloneRef(TV_Allocations_ByAnyone, e);
		}
	}

	private void RevertSerializer(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			CloneRef(TV_Allocations_ByAttackersOnly, e);
		}
	}

	private void CountRef(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			CloneRef(TV_Allocations_ToAnyone, e);
		}
	}

	private void CustomizeRef(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			CloneRef(TV_Allocations_ToTargetsOnly, e);
		}
	}

	private void CloneRef(DarkTreeView darkTreeView_0, MouseEventArgs mouseEventArgs_0)
	{
		if (darkTreeView_0.SelectedNodes.Count != 0 && !Information.IsNothing(RuntimeHelpers.GetObjectValue(darkTreeView_0.SelectedNodes[0].Tag)) && (object)darkTreeView_0.SelectedNodes[0].Tag.GetType() == typeof(WeaponSalvo))
		{
			m_ImporterBridge = (WeaponSalvo)darkTreeView_0.SelectedNodes[0].Tag;
			RegisterSerializer();
			SearchError().Show(darkTreeView_0, mouseEventArgs_0.X, mouseEventArgs_0.Y);
		}
	}

	private void ConnectRef(object sender, MouseEventArgs e)
	{
		PublishSerializer(bool_0: false);
	}

	private void MoveRef(object sender, MouseEventArgs e)
	{
		AwakeSerializer(bool_0: false);
	}

	private void DeleteRef(object sender, EventArgs e)
	{
		if (m_ReaderBridge && TV_AvailableWeapons.SelectedNodes.Count > 0)
		{
			consumerBridge = TV_AvailableWeapons.SelectedNodes[0].VisibleIndex;
			if (!Information.IsNothing(TV_AvailableWeapons.SelectedNodes[0].ParentNode))
			{
				_FacadeBridge = TV_AvailableWeapons.SelectedNodes[0].ParentNode.VisibleIndex;
			}
		}
		SetSerializer();
	}

	private void AddRef(object sender, MouseEventArgs e)
	{
		QuerySerializer(bool_0: false);
	}

	private void DestroyRef(object sender, MouseEventArgs e)
	{
		ResetSerializer(bool_0: false);
	}

	private void ComputeRef(object sender, EventArgs e)
	{
		EnableSerializer();
	}

	private void PatchRef(object sender, EventArgs e)
	{
		EnableSerializer();
	}

	private void SelectRef(object sender, EventArgs e)
	{
		EnableSerializer();
	}

	private void CallRef(object sender, EventArgs e)
	{
		EnableSerializer();
	}
}
