using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Salamander.Windows.Forms;

namespace Command;

[DesignerGenerated]
public sealed class DoctrineControl : DarkUserControl
{
	private IContainer m_DefinitionStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private DarkLabel m_ValStub;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel wrapperStub;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkButton _ClientStub;

	[CompilerGenerated]
	[AccessedThroughProperty("TableLayoutPanel1")]
	private TableLayoutPanel consumerStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label6")]
	private DarkLabel proxyStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label10")]
	private DarkLabel m_PropertyStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label11")]
	private DarkLabel m_ImporterStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label14")]
	private DarkLabel m_RepositoryStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label12")]
	private DarkLabel bridgeStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label13")]
	private DarkLabel invocationStub;

	[AccessedThroughProperty("Label16")]
	[CompilerGenerated]
	private DarkLabel requestStub;

	[AccessedThroughProperty("Label17")]
	[CompilerGenerated]
	private DarkLabel valueStub;

	[AccessedThroughProperty("Label18")]
	[CompilerGenerated]
	private DarkLabel tokenizerStub;

	[AccessedThroughProperty("Label20")]
	[CompilerGenerated]
	private DarkLabel m_WriterStub;

	[AccessedThroughProperty("Combo_UseNukes")]
	[CompilerGenerated]
	private DarkUIComboBox _SpecificationStub;

	[AccessedThroughProperty("Combo_WeaponControlStatus_Air")]
	[CompilerGenerated]
	private DarkUIComboBox m_WatcherStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_ShootTourists")]
	private DarkUIComboBox reponseStub;

	[AccessedThroughProperty("Combo_BehaviorTowardsAmbigousTarget")]
	[CompilerGenerated]
	private DarkUIComboBox descriptorStub;

	[AccessedThroughProperty("Combo_IgnoreEMCONunderAttack")]
	[CompilerGenerated]
	private DarkUIComboBox _PoolStub;

	[AccessedThroughProperty("Combo_AirOpsTempo")]
	[CompilerGenerated]
	private DarkUIComboBox taskStub;

	[AccessedThroughProperty("Combo_QuickTurnAroundForAicraft")]
	[CompilerGenerated]
	private DarkUIComboBox m_FilterStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_WinchesterShotgunRTB")]
	private DarkUIComboBox _TestsStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_UseSAMsOnASuW")]
	private DarkUIComboBox interpreterStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_Standoff")]
	private DarkUIComboBox _ContainerStub;

	[AccessedThroughProperty("Combo_UseRefuel")]
	[CompilerGenerated]
	private DarkUIComboBox m_ComposerStub;

	[AccessedThroughProperty("Combo_UseKinematicRangeForTorpedoes")]
	[CompilerGenerated]
	private DarkUIComboBox _ModelStub;

	[AccessedThroughProperty("Label19")]
	[CompilerGenerated]
	private DarkLabel m_AdvisorStub;

	[AccessedThroughProperty("Combo_IgnorePlottedCourse")]
	[CompilerGenerated]
	private DarkUIComboBox _CustomerStub;

	[AccessedThroughProperty("Combo_AutoEvade")]
	[CompilerGenerated]
	private DarkUIComboBox m_SerializerStub;

	[AccessedThroughProperty("Label21")]
	[CompilerGenerated]
	private DarkLabel refStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label22")]
	private DarkLabel errorStub;

	[AccessedThroughProperty("Label23")]
	[CompilerGenerated]
	private DarkLabel codeStub;

	[AccessedThroughProperty("Combo_WeaponControlStatus_Surface")]
	[CompilerGenerated]
	private DarkUIComboBox m_ConnectionStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_WeaponControlStatus_Submarine")]
	private DarkUIComboBox m_ContextStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_WeaponControlStatus_Land")]
	private DarkUIComboBox _StatusStub;

	[AccessedThroughProperty("Combo_GunStrafing")]
	[CompilerGenerated]
	private DarkUIComboBox m_StrategyStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label37")]
	private DarkLabel configurationStub;

	[AccessedThroughProperty("Combo_ReplenishmentSelection")]
	[CompilerGenerated]
	private DarkUIComboBox m_TokenStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label25")]
	private DarkLabel m_IndexerStub;

	[AccessedThroughProperty("Combo_BingoJoker")]
	[CompilerGenerated]
	private DarkUIComboBox _PublisherStub;

	[AccessedThroughProperty("Combo_WinchesterShotgun")]
	[CompilerGenerated]
	private DarkUIComboBox m_ServerStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_JettisonOrdnance")]
	private DarkUIComboBox _AdapterStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label28")]
	private DarkLabel utilsStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_BingoJokerRTB")]
	private DarkUIComboBox m_PredicateStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label29")]
	private DarkLabel m_SingletonStub;

	[AccessedThroughProperty("Combo_RefuelAllies")]
	[CompilerGenerated]
	private DarkUIComboBox _RecordStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label30")]
	private DarkLabel exceptionStub;

	[AccessedThroughProperty("Label32")]
	[CompilerGenerated]
	private DarkLabel visitorStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Label35")]
	private DarkLabel m_ComparatorStub;

	[AccessedThroughProperty("Combo_AvoidContact")]
	[CompilerGenerated]
	private DarkUIComboBox _ItemStub;

	[AccessedThroughProperty("Combo_DiveWhenThreatsDetected")]
	[CompilerGenerated]
	private DarkUIComboBox m_SetterStub;

	[AccessedThroughProperty("Combo_BatteryRechargePatrol")]
	[CompilerGenerated]
	private DarkUIComboBox creatorStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_BatteryRechargeAttack")]
	private DarkUIComboBox templateStub;

	[AccessedThroughProperty("Combo_AIP_Usage")]
	[CompilerGenerated]
	private DarkUIComboBox _MappingStub;

	[AccessedThroughProperty("Label36")]
	[CompilerGenerated]
	private DarkLabel m_MockStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_DippingSonar")]
	private DarkUIComboBox _TagStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_Surface_Navigation")]
	private DarkUIComboBox _FieldStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_Submarine_Navigation")]
	private DarkUIComboBox m_QueueStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_Land_Navigation")]
	private DarkUIComboBox _RegStub;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel1")]
	private DarkLabel paramStub;

	[AccessedThroughProperty("DarkLabel3")]
	[CompilerGenerated]
	private DarkLabel rulesStub;

	[AccessedThroughProperty("DarkLabel5")]
	[CompilerGenerated]
	private DarkLabel methodStub;

	[AccessedThroughProperty("BingoThresholdCombo")]
	[CompilerGenerated]
	private DarkUIComboBox m_ServiceStub;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel4")]
	private DarkLabel systemStub;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel6")]
	private DarkLabel m_CandidateStub;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_USeWPMissilesOnASuW")]
	private DarkUIComboBox baseStub;

	private ScenarioObject m_PolicyStub;

	private bool m_BroadcasterStub;

	private int ActualWidth;

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return m_ValStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValStub = value;
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return wrapperStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wrapperStub = value;
		}
	}

	[field: AccessedThroughProperty("Label9")]
	internal DarkLabel Label9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _ClientStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountUtils;
			DarkButton clientStub = _ClientStub;
			if (clientStub != null)
			{
				clientStub.Click -= value2;
			}
			_ClientStub = value;
			clientStub = _ClientStub;
			if (clientStub != null)
			{
				clientStub.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal DarkLabel Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return consumerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			consumerStub = value;
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return proxyStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proxyStub = value;
		}
	}

	[field: AccessedThroughProperty("Label8")]
	internal DarkLabel Label8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label10
	{
		[CompilerGenerated]
		get
		{
			return m_PropertyStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PropertyStub = value;
		}
	}

	internal DarkLabel Label11
	{
		[CompilerGenerated]
		get
		{
			return m_ImporterStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ImporterStub = value;
		}
	}

	internal DarkLabel Label14
	{
		[CompilerGenerated]
		get
		{
			return m_RepositoryStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RepositoryStub = value;
		}
	}

	internal DarkLabel Label12
	{
		[CompilerGenerated]
		get
		{
			return bridgeStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bridgeStub = value;
		}
	}

	internal DarkLabel Label13
	{
		[CompilerGenerated]
		get
		{
			return invocationStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			invocationStub = value;
		}
	}

	[field: AccessedThroughProperty("Label15")]
	internal DarkLabel Label15
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label16
	{
		[CompilerGenerated]
		get
		{
			return requestStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			requestStub = value;
		}
	}

	internal DarkLabel Label17
	{
		[CompilerGenerated]
		get
		{
			return valueStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valueStub = value;
		}
	}

	internal DarkLabel Label18
	{
		[CompilerGenerated]
		get
		{
			return tokenizerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenizerStub = value;
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label20
	{
		[CompilerGenerated]
		get
		{
			return m_WriterStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WriterStub = value;
		}
	}

	internal DarkUIComboBox Combo_UseNukes
	{
		[CompilerGenerated]
		get
		{
			return _SpecificationStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeUtils;
			DarkUIComboBox specificationStub = _SpecificationStub;
			if (specificationStub != null)
			{
				specificationStub.SelectionChangeCommitted -= value2;
			}
			_SpecificationStub = value;
			specificationStub = _SpecificationStub;
			if (specificationStub != null)
			{
				specificationStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Air
	{
		[CompilerGenerated]
		get
		{
			return m_WatcherStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneUtils;
			DarkUIComboBox watcherStub = m_WatcherStub;
			if (watcherStub != null)
			{
				watcherStub.SelectionChangeCommitted -= value2;
			}
			m_WatcherStub = value;
			watcherStub = m_WatcherStub;
			if (watcherStub != null)
			{
				watcherStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_ShootTourists
	{
		[CompilerGenerated]
		get
		{
			return reponseStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchUtils;
			DarkUIComboBox darkUIComboBox = reponseStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			reponseStub = value;
			darkUIComboBox = reponseStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_BehaviorTowardsAmbigousTarget
	{
		[CompilerGenerated]
		get
		{
			return descriptorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeUtils;
			DarkUIComboBox darkUIComboBox = descriptorStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			descriptorStub = value;
			darkUIComboBox = descriptorStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_IgnoreEMCONunderAttack
	{
		[CompilerGenerated]
		get
		{
			return _PoolStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectUtils;
			DarkUIComboBox poolStub = _PoolStub;
			if (poolStub != null)
			{
				poolStub.SelectionChangeCommitted -= value2;
			}
			_PoolStub = value;
			poolStub = _PoolStub;
			if (poolStub != null)
			{
				poolStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_AirOpsTempo
	{
		[CompilerGenerated]
		get
		{
			return taskStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallUtils;
			DarkUIComboBox darkUIComboBox = taskStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			taskStub = value;
			darkUIComboBox = taskStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_QuickTurnAroundForAicraft
	{
		[CompilerGenerated]
		get
		{
			return m_FilterStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutUtils;
			DarkUIComboBox filterStub = m_FilterStub;
			if (filterStub != null)
			{
				filterStub.SelectionChangeCommitted -= value2;
			}
			m_FilterStub = value;
			filterStub = m_FilterStub;
			if (filterStub != null)
			{
				filterStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_WinchesterShotgunRTB
	{
		[CompilerGenerated]
		get
		{
			return _TestsStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginUtils;
			DarkUIComboBox testsStub = _TestsStub;
			if (testsStub != null)
			{
				testsStub.SelectionChangeCommitted -= value2;
			}
			_TestsStub = value;
			testsStub = _TestsStub;
			if (testsStub != null)
			{
				testsStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_UseSAMsOnASuW
	{
		[CompilerGenerated]
		get
		{
			return interpreterStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewUtils;
			DarkUIComboBox darkUIComboBox = interpreterStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			interpreterStub = value;
			darkUIComboBox = interpreterStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Standoff
	{
		[CompilerGenerated]
		get
		{
			return _ContainerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PushUtils;
			DarkUIComboBox containerStub = _ContainerStub;
			if (containerStub != null)
			{
				containerStub.SelectionChangeCommitted -= value2;
			}
			_ContainerStub = value;
			containerStub = _ContainerStub;
			if (containerStub != null)
			{
				containerStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_UseRefuel
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeUtils;
			DarkUIComboBox composerStub = m_ComposerStub;
			if (composerStub != null)
			{
				composerStub.SelectionChangeCommitted -= value2;
			}
			m_ComposerStub = value;
			composerStub = m_ComposerStub;
			if (composerStub != null)
			{
				composerStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_UseKinematicRangeForTorpedoes
	{
		[CompilerGenerated]
		get
		{
			return _ModelStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeUtils;
			DarkUIComboBox modelStub = _ModelStub;
			if (modelStub != null)
			{
				modelStub.SelectionChangeCommitted -= value2;
			}
			_ModelStub = value;
			modelStub = _ModelStub;
			if (modelStub != null)
			{
				modelStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label19
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorStub = value;
		}
	}

	internal DarkUIComboBox Combo_IgnorePlottedCourse
	{
		[CompilerGenerated]
		get
		{
			return _CustomerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyUtils;
			DarkUIComboBox customerStub = _CustomerStub;
			if (customerStub != null)
			{
				customerStub.SelectionChangeCommitted -= value2;
			}
			_CustomerStub = value;
			customerStub = _CustomerStub;
			if (customerStub != null)
			{
				customerStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_AutoEvade
	{
		[CompilerGenerated]
		get
		{
			return m_SerializerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupUtils;
			DarkUIComboBox serializerStub = m_SerializerStub;
			if (serializerStub != null)
			{
				serializerStub.SelectionChangeCommitted -= value2;
			}
			m_SerializerStub = value;
			serializerStub = m_SerializerStub;
			if (serializerStub != null)
			{
				serializerStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label21
	{
		[CompilerGenerated]
		get
		{
			return refStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			refStub = value;
		}
	}

	internal DarkLabel Label22
	{
		[CompilerGenerated]
		get
		{
			return errorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			errorStub = value;
		}
	}

	internal DarkLabel Label23
	{
		[CompilerGenerated]
		get
		{
			return codeStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			codeStub = value;
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Surface
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConnectUtils;
			DarkUIComboBox connectionStub = m_ConnectionStub;
			if (connectionStub != null)
			{
				connectionStub.SelectionChangeCommitted -= value2;
			}
			m_ConnectionStub = value;
			connectionStub = m_ConnectionStub;
			if (connectionStub != null)
			{
				connectionStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Submarine
	{
		[CompilerGenerated]
		get
		{
			return m_ContextStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveUtils;
			DarkUIComboBox contextStub = m_ContextStub;
			if (contextStub != null)
			{
				contextStub.SelectionChangeCommitted -= value2;
			}
			m_ContextStub = value;
			contextStub = m_ContextStub;
			if (contextStub != null)
			{
				contextStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_WeaponControlStatus_Land
	{
		[CompilerGenerated]
		get
		{
			return _StatusStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteUtils;
			DarkUIComboBox statusStub = _StatusStub;
			if (statusStub != null)
			{
				statusStub.SelectionChangeCommitted -= value2;
			}
			_StatusStub = value;
			statusStub = _StatusStub;
			if (statusStub != null)
			{
				statusStub.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label24")]
	internal DarkLabel Label24
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_GunStrafing
	{
		[CompilerGenerated]
		get
		{
			return m_StrategyStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddUtils;
			DarkUIComboBox strategyStub = m_StrategyStub;
			if (strategyStub != null)
			{
				strategyStub.SelectionChangeCommitted -= value2;
			}
			m_StrategyStub = value;
			strategyStub = m_StrategyStub;
			if (strategyStub != null)
			{
				strategyStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label37
	{
		[CompilerGenerated]
		get
		{
			return configurationStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationStub = value;
		}
	}

	internal DarkUIComboBox Combo_ReplenishmentSelection
	{
		[CompilerGenerated]
		get
		{
			return m_TokenStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeUtils;
			DarkUIComboBox tokenStub = m_TokenStub;
			if (tokenStub != null)
			{
				tokenStub.SelectionChangeCommitted -= value2;
			}
			m_TokenStub = value;
			tokenStub = m_TokenStub;
			if (tokenStub != null)
			{
				tokenStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label25
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IndexerStub = value;
		}
	}

	[field: AccessedThroughProperty("Label26")]
	internal DarkLabel Label26
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_BingoJoker
	{
		[CompilerGenerated]
		get
		{
			return _PublisherStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ViewUtils;
			DarkUIComboBox publisherStub = _PublisherStub;
			if (publisherStub != null)
			{
				publisherStub.SelectionChangeCommitted -= value2;
			}
			_PublisherStub = value;
			publisherStub = _PublisherStub;
			if (publisherStub != null)
			{
				publisherStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_WinchesterShotgun
	{
		[CompilerGenerated]
		get
		{
			return m_ServerStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateUtils;
			DarkUIComboBox serverStub = m_ServerStub;
			if (serverStub != null)
			{
				serverStub.SelectionChangeCommitted -= value2;
			}
			m_ServerStub = value;
			serverStub = m_ServerStub;
			if (serverStub != null)
			{
				serverStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_JettisonOrdnance
	{
		[CompilerGenerated]
		get
		{
			return _AdapterStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteUtils;
			DarkUIComboBox adapterStub = _AdapterStub;
			if (adapterStub != null)
			{
				adapterStub.SelectionChangeCommitted -= value2;
			}
			_AdapterStub = value;
			adapterStub = _AdapterStub;
			if (adapterStub != null)
			{
				adapterStub.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label27")]
	internal DarkLabel Label27
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label28
	{
		[CompilerGenerated]
		get
		{
			return utilsStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			utilsStub = value;
		}
	}

	internal DarkUIComboBox Combo_BingoJokerRTB
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetUtils;
			DarkUIComboBox predicateStub = m_PredicateStub;
			if (predicateStub != null)
			{
				predicateStub.SelectionChangeCommitted -= value2;
			}
			m_PredicateStub = value;
			predicateStub = m_PredicateStub;
			if (predicateStub != null)
			{
				predicateStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label29
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SingletonStub = value;
		}
	}

	internal DarkUIComboBox Combo_RefuelAllies
	{
		[CompilerGenerated]
		get
		{
			return _RecordStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchUtils;
			DarkUIComboBox recordStub = _RecordStub;
			if (recordStub != null)
			{
				recordStub.SelectionChangeCommitted -= value2;
			}
			_RecordStub = value;
			recordStub = _RecordStub;
			if (recordStub != null)
			{
				recordStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label30
	{
		[CompilerGenerated]
		get
		{
			return exceptionStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exceptionStub = value;
		}
	}

	[field: AccessedThroughProperty("Label31")]
	internal DarkLabel Label31
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label32
	{
		[CompilerGenerated]
		get
		{
			return visitorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			visitorStub = value;
		}
	}

	[field: AccessedThroughProperty("Label33")]
	internal DarkLabel Label33
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label34")]
	internal DarkLabel Label34
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label35
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComparatorStub = value;
		}
	}

	internal DarkUIComboBox Combo_AvoidContact
	{
		[CompilerGenerated]
		get
		{
			return _ItemStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeUtils;
			DarkUIComboBox itemStub = _ItemStub;
			if (itemStub != null)
			{
				itemStub.SelectionChangeCommitted -= value2;
			}
			_ItemStub = value;
			itemStub = _ItemStub;
			if (itemStub != null)
			{
				itemStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_DiveWhenThreatsDetected
	{
		[CompilerGenerated]
		get
		{
			return m_SetterStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitUtils;
			DarkUIComboBox setterStub = m_SetterStub;
			if (setterStub != null)
			{
				setterStub.SelectionChangeCommitted -= value2;
			}
			m_SetterStub = value;
			setterStub = m_SetterStub;
			if (setterStub != null)
			{
				setterStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_BatteryRechargePatrol
	{
		[CompilerGenerated]
		get
		{
			return creatorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckUtils;
			DarkUIComboBox darkUIComboBox = creatorStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			creatorStub = value;
			darkUIComboBox = creatorStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_BatteryRechargeAttack
	{
		[CompilerGenerated]
		get
		{
			return templateStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatUtils;
			DarkUIComboBox darkUIComboBox = templateStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			templateStub = value;
			darkUIComboBox = templateStub;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_AIP_Usage
	{
		[CompilerGenerated]
		get
		{
			return _MappingStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InterruptUtils;
			DarkUIComboBox mappingStub = _MappingStub;
			if (mappingStub != null)
			{
				mappingStub.SelectionChangeCommitted -= value2;
			}
			_MappingStub = value;
			mappingStub = _MappingStub;
			if (mappingStub != null)
			{
				mappingStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label36
	{
		[CompilerGenerated]
		get
		{
			return m_MockStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockStub = value;
		}
	}

	internal DarkUIComboBox Combo_DippingSonar
	{
		[CompilerGenerated]
		get
		{
			return _TagStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveUtils;
			DarkUIComboBox tagStub = _TagStub;
			if (tagStub != null)
			{
				tagStub.SelectionChangeCommitted -= value2;
			}
			_TagStub = value;
			tagStub = _TagStub;
			if (tagStub != null)
			{
				tagStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Surface_Navigation
	{
		[CompilerGenerated]
		get
		{
			return _FieldStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindUtils;
			DarkUIComboBox fieldStub = _FieldStub;
			if (fieldStub != null)
			{
				fieldStub.SelectionChangeCommitted -= value2;
			}
			_FieldStub = value;
			fieldStub = _FieldStub;
			if (fieldStub != null)
			{
				fieldStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Submarine_Navigation
	{
		[CompilerGenerated]
		get
		{
			return m_QueueStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetUtils;
			DarkUIComboBox queueStub = m_QueueStub;
			if (queueStub != null)
			{
				queueStub.SelectionChangeCommitted -= value2;
			}
			m_QueueStub = value;
			queueStub = m_QueueStub;
			if (queueStub != null)
			{
				queueStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_Land_Navigation
	{
		[CompilerGenerated]
		get
		{
			return _RegStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillUtils;
			DarkUIComboBox regStub = _RegStub;
			if (regStub != null)
			{
				regStub.SelectionChangeCommitted -= value2;
			}
			_RegStub = value;
			regStub = _RegStub;
			if (regStub != null)
			{
				regStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return paramStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramStub = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal DarkLabel DarkLabel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel DarkLabel3
	{
		[CompilerGenerated]
		get
		{
			return rulesStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rulesStub = value;
		}
	}

	internal DarkLabel DarkLabel5
	{
		[CompilerGenerated]
		get
		{
			return methodStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodStub = value;
		}
	}

	internal DarkUIComboBox BingoThresholdCombo
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableUtils;
			DarkUIComboBox serviceStub = m_ServiceStub;
			if (serviceStub != null)
			{
				serviceStub.SelectionChangeCommitted -= value2;
			}
			m_ServiceStub = value;
			serviceStub = m_ServiceStub;
			if (serviceStub != null)
			{
				serviceStub.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel DarkLabel4
	{
		[CompilerGenerated]
		get
		{
			return systemStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			systemStub = value;
		}
	}

	internal DarkLabel DarkLabel6
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CandidateStub = value;
		}
	}

	internal DarkUIComboBox Combo_USeWPMissilesOnASuW
	{
		[CompilerGenerated]
		get
		{
			return baseStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			baseStub = value;
		}
	}

	public DoctrineControl()
	{
		base.Load += OrderSchema;
		base.VisibleChanged += RevertSchema;
		m_BroadcasterStub = true;
		CollectSchema();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_DefinitionStub != null)
			{
				m_DefinitionStub.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CollectSchema()
	{
		Label3 = new DarkLabel();
		Label1 = new DarkLabel();
		Label9 = new DarkLabel();
		Label7 = new DarkLabel();
		Button1 = new DarkButton();
		Label4 = new DarkLabel();
		TableLayoutPanel1 = new TableLayoutPanel();
		Combo_UseNukes = new DarkUIComboBox();
		Label15 = new DarkLabel();
		Label16 = new DarkLabel();
		Label8 = new DarkLabel();
		Combo_BehaviorTowardsAmbigousTarget = new DarkUIComboBox();
		Label17 = new DarkLabel();
		Label11 = new DarkLabel();
		Combo_IgnoreEMCONunderAttack = new DarkUIComboBox();
		Combo_AirOpsTempo = new DarkUIComboBox();
		Combo_QuickTurnAroundForAicraft = new DarkUIComboBox();
		Combo_WinchesterShotgunRTB = new DarkUIComboBox();
		Combo_UseSAMsOnASuW = new DarkUIComboBox();
		Combo_Standoff = new DarkUIComboBox();
		Combo_ShootTourists = new DarkUIComboBox();
		Label19 = new DarkLabel();
		Combo_IgnorePlottedCourse = new DarkUIComboBox();
		Combo_WeaponControlStatus_Air = new DarkUIComboBox();
		Label21 = new DarkLabel();
		Label22 = new DarkLabel();
		Label23 = new DarkLabel();
		Combo_WeaponControlStatus_Surface = new DarkUIComboBox();
		Combo_WeaponControlStatus_Submarine = new DarkUIComboBox();
		Combo_WeaponControlStatus_Land = new DarkUIComboBox();
		Combo_GunStrafing = new DarkUIComboBox();
		Combo_BingoJoker = new DarkUIComboBox();
		Combo_WinchesterShotgun = new DarkUIComboBox();
		Combo_JettisonOrdnance = new DarkUIComboBox();
		Combo_BingoJokerRTB = new DarkUIComboBox();
		Label20 = new DarkLabel();
		Label13 = new DarkLabel();
		Combo_UseKinematicRangeForTorpedoes = new DarkUIComboBox();
		Combo_AutoEvade = new DarkUIComboBox();
		Label6 = new DarkLabel();
		Label29 = new DarkLabel();
		Combo_UseRefuel = new DarkUIComboBox();
		Combo_RefuelAllies = new DarkUIComboBox();
		Label37 = new DarkLabel();
		Combo_ReplenishmentSelection = new DarkUIComboBox();
		Combo_DippingSonar = new DarkUIComboBox();
		Combo_AIP_Usage = new DarkUIComboBox();
		Combo_BatteryRechargeAttack = new DarkUIComboBox();
		Combo_BatteryRechargePatrol = new DarkUIComboBox();
		Combo_DiveWhenThreatsDetected = new DarkUIComboBox();
		Combo_AvoidContact = new DarkUIComboBox();
		Combo_Surface_Navigation = new DarkUIComboBox();
		Combo_Submarine_Navigation = new DarkUIComboBox();
		Combo_Land_Navigation = new DarkUIComboBox();
		DarkLabel3 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		Label36 = new DarkLabel();
		Label35 = new DarkLabel();
		Label34 = new DarkLabel();
		Label33 = new DarkLabel();
		Label32 = new DarkLabel();
		Label31 = new DarkLabel();
		Label30 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		Label5 = new DarkLabel();
		Label10 = new DarkLabel();
		Label2 = new DarkLabel();
		Label28 = new DarkLabel();
		Label24 = new DarkLabel();
		Label26 = new DarkLabel();
		Label27 = new DarkLabel();
		Label25 = new DarkLabel();
		Label14 = new DarkLabel();
		Label12 = new DarkLabel();
		Label18 = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		BingoThresholdCombo = new DarkUIComboBox();
		DarkLabel4 = new DarkLabel();
		DarkLabel6 = new DarkLabel();
		Combo_USeWPMissilesOnASuW = new DarkUIComboBox();
		TableLayoutPanel1.SuspendLayout();
		SuspendLayout();
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(0, 182);
		Label3.Margin = new Padding(0, 6, 0, 0);
		Label3.Name = "Label3";
		Label3.Size = new Size(104, 13);
		Label3.TabIndex = 26;
		Label3.Text = "Engage ambiguous: ";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(0, 556);
		Label1.Margin = new Padding(0, 6, 0, 0);
		Label1.Name = "Label1";
		Label1.Size = new Size(104, 13);
		Label1.TabIndex = 24;
		Label1.Text = "武器状态，返回基地：";
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(0, 72);
		Label9.Margin = new Padding(0, 6, 0, 0);
		Label9.Name = "Label9";
		Label9.Size = new Size(52, 13);
		Label9.TabIndex = 21;
		Label9.Text = "WCS, air:";
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(0, 28);
		Label7.Margin = new Padding(0, 6, 0, 0);
		Label7.Name = "Label7";
		Label7.Size = new Size(93, 13);
		Label7.TabIndex = 19;
		Label7.Text = "Nuclear weapons:";
		Button1.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.Location = new Point(0, 0);
		Button1.Margin = new Padding(0, 3, 3, 3);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.Size = new Size(231, 21);
		Button1.TabIndex = 23;
		Button1.Text = "Doctrine Window (Ctrl + F9)";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(0, 314);
		Label4.Margin = new Padding(0, 6, 0, 0);
		Label4.Name = "Label4";
		Label4.Size = new Size(100, 13);
		Label4.TabIndex = 28;
		Label4.Text = "Automatic evasion: ";
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121f));
		TableLayoutPanel1.Controls.Add(DarkLabel4, 0, 42);
		TableLayoutPanel1.Controls.Add(Label7, 0, 1);
		TableLayoutPanel1.Controls.Add(Combo_UseNukes, 1, 1);
		TableLayoutPanel1.Controls.Add(Label15, 0, 0);
		TableLayoutPanel1.Controls.Add(Label16, 0, 2);
		TableLayoutPanel1.Controls.Add(Label8, 0, 9);
		TableLayoutPanel1.Controls.Add(Label3, 0, 8);
		TableLayoutPanel1.Controls.Add(Combo_BehaviorTowardsAmbigousTarget, 1, 8);
		TableLayoutPanel1.Controls.Add(Label17, 0, 10);
		TableLayoutPanel1.Controls.Add(Label11, 0, 11);
		TableLayoutPanel1.Controls.Add(Combo_IgnoreEMCONunderAttack, 1, 11);
		TableLayoutPanel1.Controls.Add(Combo_AirOpsTempo, 1, 20);
		TableLayoutPanel1.Controls.Add(Combo_QuickTurnAroundForAicraft, 1, 21);
		TableLayoutPanel1.Controls.Add(Combo_WinchesterShotgunRTB, 1, 25);
		TableLayoutPanel1.Controls.Add(Combo_UseSAMsOnASuW, 1, 29);
		TableLayoutPanel1.Controls.Add(Combo_Standoff, 1, 30);
		TableLayoutPanel1.Controls.Add(Combo_ShootTourists, 1, 9);
		TableLayoutPanel1.Controls.Add(Label19, 0, 7);
		TableLayoutPanel1.Controls.Add(Combo_IgnorePlottedCourse, 1, 7);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Air, 1, 3);
		TableLayoutPanel1.Controls.Add(Label9, 0, 3);
		TableLayoutPanel1.Controls.Add(Label21, 0, 4);
		TableLayoutPanel1.Controls.Add(Label22, 0, 5);
		TableLayoutPanel1.Controls.Add(Label23, 0, 6);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Surface, 1, 4);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Submarine, 1, 5);
		TableLayoutPanel1.Controls.Add(Combo_WeaponControlStatus_Land, 1, 6);
		TableLayoutPanel1.Controls.Add(Combo_GunStrafing, 1, 26);
		TableLayoutPanel1.Controls.Add(Combo_BingoJoker, 1, 22);
		TableLayoutPanel1.Controls.Add(Combo_WinchesterShotgun, 1, 24);
		TableLayoutPanel1.Controls.Add(Combo_JettisonOrdnance, 1, 27);
		TableLayoutPanel1.Controls.Add(Combo_BingoJokerRTB, 1, 23);
		TableLayoutPanel1.Controls.Add(Label20, 0, 12);
		TableLayoutPanel1.Controls.Add(Label13, 0, 13);
		TableLayoutPanel1.Controls.Add(Combo_UseKinematicRangeForTorpedoes, 1, 13);
		TableLayoutPanel1.Controls.Add(Label4, 0, 14);
		TableLayoutPanel1.Controls.Add(Combo_AutoEvade, 1, 14);
		TableLayoutPanel1.Controls.Add(Label6, 0, 15);
		TableLayoutPanel1.Controls.Add(Label29, 0, 17);
		TableLayoutPanel1.Controls.Add(Combo_UseRefuel, 1, 15);
		TableLayoutPanel1.Controls.Add(Combo_RefuelAllies, 1, 17);
		TableLayoutPanel1.Controls.Add(Label37, 0, 16);
		TableLayoutPanel1.Controls.Add(Combo_ReplenishmentSelection, 1, 16);
		TableLayoutPanel1.Controls.Add(Combo_DippingSonar, 1, 38);
		TableLayoutPanel1.Controls.Add(Combo_AIP_Usage, 1, 37);
		TableLayoutPanel1.Controls.Add(Combo_BatteryRechargeAttack, 1, 36);
		TableLayoutPanel1.Controls.Add(Combo_BatteryRechargePatrol, 1, 35);
		TableLayoutPanel1.Controls.Add(Combo_DiveWhenThreatsDetected, 1, 34);
		TableLayoutPanel1.Controls.Add(Combo_AvoidContact, 1, 33);
		TableLayoutPanel1.Controls.Add(Combo_Surface_Navigation, 1, 31);
		TableLayoutPanel1.Controls.Add(Combo_Submarine_Navigation, 1, 39);
		TableLayoutPanel1.Controls.Add(Label36, 0, 38);
		TableLayoutPanel1.Controls.Add(Label35, 0, 37);
		TableLayoutPanel1.Controls.Add(Label34, 0, 36);
		TableLayoutPanel1.Controls.Add(Label33, 0, 35);
		TableLayoutPanel1.Controls.Add(Label32, 0, 34);
		TableLayoutPanel1.Controls.Add(Label31, 0, 33);
		TableLayoutPanel1.Controls.Add(Label30, 0, 32);
		TableLayoutPanel1.Controls.Add(DarkLabel1, 0, 31);
		TableLayoutPanel1.Controls.Add(Label5, 0, 30);
		TableLayoutPanel1.Controls.Add(Label10, 0, 29);
		TableLayoutPanel1.Controls.Add(Label2, 0, 28);
		TableLayoutPanel1.Controls.Add(Label28, 0, 27);
		TableLayoutPanel1.Controls.Add(Label24, 0, 26);
		TableLayoutPanel1.Controls.Add(Label1, 0, 25);
		TableLayoutPanel1.Controls.Add(Label26, 0, 24);
		TableLayoutPanel1.Controls.Add(Label27, 0, 23);
		TableLayoutPanel1.Controls.Add(Label25, 0, 22);
		TableLayoutPanel1.Controls.Add(Label14, 0, 21);
		TableLayoutPanel1.Controls.Add(Label12, 0, 20);
		TableLayoutPanel1.Controls.Add(Label18, 0, 19);
		TableLayoutPanel1.Controls.Add(DarkLabel5, 0, 18);
		TableLayoutPanel1.Controls.Add(BingoThresholdCombo, 1, 18);
		TableLayoutPanel1.Controls.Add(Combo_Land_Navigation, 1, 42);
		TableLayoutPanel1.Controls.Add(DarkLabel3, 0, 41);
		TableLayoutPanel1.Controls.Add(DarkLabel2, 0, 39);
		TableLayoutPanel1.Controls.Add(DarkLabel6, 0, 40);
		TableLayoutPanel1.Controls.Add(Combo_USeWPMissilesOnASuW, 1, 40);
		TableLayoutPanel1.Location = new Point(0, 14);
		TableLayoutPanel1.Margin = new Padding(0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 43;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.Size = new Size(232, 961);
		TableLayoutPanel1.TabIndex = 30;
		Combo_UseNukes.BackColor = Color.Transparent;
		Combo_UseNukes.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseNukes.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseNukes.DropDownWidth = 200;
		Combo_UseNukes.Font = new Font("Segoe UI", 7f);
		Combo_UseNukes.FormattingEnabled = true;
		Combo_UseNukes.Location = new Point(111, 22);
		Combo_UseNukes.Margin = new Padding(0, 0, 3, 3);
		Combo_UseNukes.Name = "Combo_UseNukes";
		Combo_UseNukes.Size = new Size(118, 21);
		Combo_UseNukes.TabIndex = 45;
		Label15.AutoSize = true;
		Label15.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		Label15.ForeColor = Color.FromArgb(220, 220, 220);
		Label15.Location = new Point(0, 0);
		Label15.Margin = new Padding(0, 0, 3, 0);
		Label15.Name = "Label15";
		Label15.Padding = new Padding(0, 9, 0, 0);
		Label15.Size = new Size(52, 22);
		Label15.TabIndex = 58;
		Label15.Text = "战略武器";
		Label16.AutoSize = true;
		Label16.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		Label16.ForeColor = Color.FromArgb(220, 220, 220);
		Label16.Location = new Point(0, 44);
		Label16.Margin = new Padding(0, 0, 3, 0);
		Label16.Name = "Label16";
		Label16.Padding = new Padding(0, 9, 0, 0);
		Label16.Size = new Size(28, 22);
		Label16.TabIndex = 59;
		Label16.Text = "交战规则";
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(0, 204);
		Label8.Margin = new Padding(0, 6, 0, 0);
		Label8.Name = "Label8";
		Label8.Size = new Size(110, 13);
		Label8.TabIndex = 34;
		Label8.Text = "Engage opportunities:";
		Combo_BehaviorTowardsAmbigousTarget.BackColor = Color.Transparent;
		Combo_BehaviorTowardsAmbigousTarget.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BehaviorTowardsAmbigousTarget.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BehaviorTowardsAmbigousTarget.Font = new Font("Segoe UI", 7f);
		Combo_BehaviorTowardsAmbigousTarget.FormattingEnabled = true;
		Combo_BehaviorTowardsAmbigousTarget.Location = new Point(111, 176);
		Combo_BehaviorTowardsAmbigousTarget.Margin = new Padding(0, 0, 3, 3);
		Combo_BehaviorTowardsAmbigousTarget.Name = "Combo_BehaviorTowardsAmbigousTarget";
		Combo_BehaviorTowardsAmbigousTarget.Size = new Size(118, 21);
		Combo_BehaviorTowardsAmbigousTarget.TabIndex = 48;
		Label17.AutoSize = true;
		Label17.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		Label17.ForeColor = Color.FromArgb(220, 220, 220);
		Label17.Location = new Point(0, 220);
		Label17.Margin = new Padding(0, 0, 3, 0);
		Label17.Name = "Label17";
		Label17.Padding = new Padding(0, 9, 0, 0);
		Label17.Size = new Size(48, 22);
		Label17.TabIndex = 60;
		Label17.Text = "电磁管控EMCON";
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(0, 248);
		Label11.Margin = new Padding(0, 6, 0, 0);
		Label11.Name = "Label11";
		Label11.Size = new Size(103, 13);
		Label11.TabIndex = 38;
		Label11.Text = "Ignore under attack:";
		Combo_IgnoreEMCONunderAttack.BackColor = Color.Transparent;
		Combo_IgnoreEMCONunderAttack.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_IgnoreEMCONunderAttack.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_IgnoreEMCONunderAttack.Font = new Font("Segoe UI", 7f);
		Combo_IgnoreEMCONunderAttack.FormattingEnabled = true;
		Combo_IgnoreEMCONunderAttack.Location = new Point(111, 242);
		Combo_IgnoreEMCONunderAttack.Margin = new Padding(0, 0, 3, 3);
		Combo_IgnoreEMCONunderAttack.Name = "Combo_IgnoreEMCONunderAttack";
		Combo_IgnoreEMCONunderAttack.Size = new Size(118, 21);
		Combo_IgnoreEMCONunderAttack.TabIndex = 54;
		Combo_AirOpsTempo.BackColor = Color.Transparent;
		Combo_AirOpsTempo.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AirOpsTempo.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AirOpsTempo.Font = new Font("Segoe UI", 7f);
		Combo_AirOpsTempo.FormattingEnabled = true;
		Combo_AirOpsTempo.Location = new Point(111, 440);
		Combo_AirOpsTempo.Margin = new Padding(0, 0, 3, 3);
		Combo_AirOpsTempo.Name = "Combo_AirOpsTempo";
		Combo_AirOpsTempo.Size = new Size(118, 21);
		Combo_AirOpsTempo.TabIndex = 57;
		Combo_QuickTurnAroundForAicraft.BackColor = Color.Transparent;
		Combo_QuickTurnAroundForAicraft.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_QuickTurnAroundForAicraft.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_QuickTurnAroundForAicraft.Font = new Font("Segoe UI", 7f);
		Combo_QuickTurnAroundForAicraft.FormattingEnabled = true;
		Combo_QuickTurnAroundForAicraft.Location = new Point(111, 462);
		Combo_QuickTurnAroundForAicraft.Margin = new Padding(0, 0, 3, 3);
		Combo_QuickTurnAroundForAicraft.Name = "Combo_QuickTurnAroundForAicraft";
		Combo_QuickTurnAroundForAicraft.Size = new Size(118, 21);
		Combo_QuickTurnAroundForAicraft.TabIndex = 56;
		Combo_WinchesterShotgunRTB.BackColor = Color.Transparent;
		Combo_WinchesterShotgunRTB.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WinchesterShotgunRTB.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WinchesterShotgunRTB.Font = new Font("Segoe UI", 7f);
		Combo_WinchesterShotgunRTB.FormattingEnabled = true;
		Combo_WinchesterShotgunRTB.Location = new Point(111, 550);
		Combo_WinchesterShotgunRTB.Margin = new Padding(0, 0, 3, 3);
		Combo_WinchesterShotgunRTB.Name = "Combo_WinchesterShotgunRTB";
		Combo_WinchesterShotgunRTB.Size = new Size(118, 21);
		Combo_WinchesterShotgunRTB.TabIndex = 47;
		Combo_UseSAMsOnASuW.BackColor = Color.Transparent;
		Combo_UseSAMsOnASuW.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseSAMsOnASuW.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseSAMsOnASuW.Font = new Font("Segoe UI", 7f);
		Combo_UseSAMsOnASuW.FormattingEnabled = true;
		Combo_UseSAMsOnASuW.Location = new Point(111, 638);
		Combo_UseSAMsOnASuW.Margin = new Padding(0, 0, 3, 3);
		Combo_UseSAMsOnASuW.Name = "Combo_UseSAMsOnASuW";
		Combo_UseSAMsOnASuW.Size = new Size(118, 21);
		Combo_UseSAMsOnASuW.TabIndex = 53;
		Combo_Standoff.BackColor = Color.Transparent;
		Combo_Standoff.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Standoff.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Standoff.Font = new Font("Segoe UI", 7f);
		Combo_Standoff.FormattingEnabled = true;
		Combo_Standoff.Location = new Point(111, 660);
		Combo_Standoff.Margin = new Padding(0, 0, 3, 3);
		Combo_Standoff.Name = "Combo_Standoff";
		Combo_Standoff.Size = new Size(118, 21);
		Combo_Standoff.TabIndex = 50;
		Combo_ShootTourists.BackColor = Color.Transparent;
		Combo_ShootTourists.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_ShootTourists.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_ShootTourists.Font = new Font("Segoe UI", 7f);
		Combo_ShootTourists.FormattingEnabled = true;
		Combo_ShootTourists.Location = new Point(111, 198);
		Combo_ShootTourists.Margin = new Padding(0, 0, 3, 3);
		Combo_ShootTourists.Name = "Combo_ShootTourists";
		Combo_ShootTourists.Size = new Size(118, 21);
		Combo_ShootTourists.TabIndex = 52;
		Label19.AutoSize = true;
		Label19.ForeColor = Color.FromArgb(220, 220, 220);
		Label19.Location = new Point(0, 160);
		Label19.Margin = new Padding(0, 6, 0, 0);
		Label19.Name = "Label19";
		Label19.Size = new Size(110, 13);
		Label19.TabIndex = 65;
		Label19.Text = "Ignore plotted course:";
		Combo_IgnorePlottedCourse.BackColor = Color.Transparent;
		Combo_IgnorePlottedCourse.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_IgnorePlottedCourse.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_IgnorePlottedCourse.Font = new Font("Segoe UI", 7f);
		Combo_IgnorePlottedCourse.FormattingEnabled = true;
		Combo_IgnorePlottedCourse.Location = new Point(111, 154);
		Combo_IgnorePlottedCourse.Margin = new Padding(0, 0, 3, 3);
		Combo_IgnorePlottedCourse.Name = "Combo_IgnorePlottedCourse";
		Combo_IgnorePlottedCourse.Size = new Size(118, 21);
		Combo_IgnorePlottedCourse.TabIndex = 66;
		Combo_WeaponControlStatus_Air.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Air.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Air.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Air.DropDownWidth = 450;
		Combo_WeaponControlStatus_Air.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Air.FormattingEnabled = true;
		Combo_WeaponControlStatus_Air.Location = new Point(111, 66);
		Combo_WeaponControlStatus_Air.Margin = new Padding(0, 0, 3, 3);
		Combo_WeaponControlStatus_Air.Name = "Combo_WeaponControlStatus_Air";
		Combo_WeaponControlStatus_Air.Size = new Size(118, 21);
		Combo_WeaponControlStatus_Air.TabIndex = 46;
		Label21.AutoSize = true;
		Label21.ForeColor = Color.FromArgb(220, 220, 220);
		Label21.Location = new Point(0, 94);
		Label21.Margin = new Padding(0, 6, 0, 0);
		Label21.Name = "Label21";
		Label21.Size = new Size(76, 13);
		Label21.TabIndex = 21;
		Label21.Text = "WCS, surface:";
		Label22.AutoSize = true;
		Label22.ForeColor = Color.FromArgb(220, 220, 220);
		Label22.Location = new Point(0, 116);
		Label22.Margin = new Padding(0, 6, 0, 0);
		Label22.Name = "Label22";
		Label22.Size = new Size(96, 13);
		Label22.TabIndex = 21;
		Label22.Text = "WCS, sub-surface:";
		Label23.AutoSize = true;
		Label23.ForeColor = Color.FromArgb(220, 220, 220);
		Label23.Location = new Point(0, 138);
		Label23.Margin = new Padding(0, 6, 0, 0);
		Label23.Name = "Label23";
		Label23.Size = new Size(61, 13);
		Label23.TabIndex = 21;
		Label23.Text = "WCS, land:";
		Combo_WeaponControlStatus_Surface.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Surface.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Surface.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Surface.DropDownWidth = 450;
		Combo_WeaponControlStatus_Surface.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Surface.FormattingEnabled = true;
		Combo_WeaponControlStatus_Surface.Location = new Point(111, 88);
		Combo_WeaponControlStatus_Surface.Margin = new Padding(0, 0, 3, 3);
		Combo_WeaponControlStatus_Surface.Name = "Combo_WeaponControlStatus_Surface";
		Combo_WeaponControlStatus_Surface.Size = new Size(118, 21);
		Combo_WeaponControlStatus_Surface.TabIndex = 46;
		Combo_WeaponControlStatus_Submarine.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Submarine.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Submarine.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Submarine.DropDownWidth = 450;
		Combo_WeaponControlStatus_Submarine.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Submarine.FormattingEnabled = true;
		Combo_WeaponControlStatus_Submarine.Location = new Point(111, 110);
		Combo_WeaponControlStatus_Submarine.Margin = new Padding(0, 0, 3, 3);
		Combo_WeaponControlStatus_Submarine.Name = "Combo_WeaponControlStatus_Submarine";
		Combo_WeaponControlStatus_Submarine.Size = new Size(118, 21);
		Combo_WeaponControlStatus_Submarine.TabIndex = 46;
		Combo_WeaponControlStatus_Land.BackColor = Color.Transparent;
		Combo_WeaponControlStatus_Land.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WeaponControlStatus_Land.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WeaponControlStatus_Land.DropDownWidth = 450;
		Combo_WeaponControlStatus_Land.Font = new Font("Segoe UI", 7f);
		Combo_WeaponControlStatus_Land.FormattingEnabled = true;
		Combo_WeaponControlStatus_Land.Location = new Point(111, 132);
		Combo_WeaponControlStatus_Land.Margin = new Padding(0, 0, 3, 3);
		Combo_WeaponControlStatus_Land.Name = "Combo_WeaponControlStatus_Land";
		Combo_WeaponControlStatus_Land.Size = new Size(118, 21);
		Combo_WeaponControlStatus_Land.TabIndex = 46;
		Combo_GunStrafing.BackColor = Color.Transparent;
		Combo_GunStrafing.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_GunStrafing.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_GunStrafing.Font = new Font("Segoe UI", 7f);
		Combo_GunStrafing.FormattingEnabled = true;
		Combo_GunStrafing.Location = new Point(111, 572);
		Combo_GunStrafing.Margin = new Padding(0, 0, 3, 3);
		Combo_GunStrafing.Name = "Combo_GunStrafing";
		Combo_GunStrafing.Size = new Size(118, 21);
		Combo_GunStrafing.TabIndex = 47;
		Combo_BingoJoker.BackColor = Color.Transparent;
		Combo_BingoJoker.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BingoJoker.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BingoJoker.DropDownWidth = 450;
		Combo_BingoJoker.Font = new Font("Segoe UI", 7f);
		Combo_BingoJoker.FormattingEnabled = true;
		Combo_BingoJoker.Location = new Point(111, 484);
		Combo_BingoJoker.Margin = new Padding(0, 0, 3, 3);
		Combo_BingoJoker.Name = "Combo_BingoJoker";
		Combo_BingoJoker.Size = new Size(118, 21);
		Combo_BingoJoker.TabIndex = 67;
		Combo_WinchesterShotgun.BackColor = Color.Transparent;
		Combo_WinchesterShotgun.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_WinchesterShotgun.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_WinchesterShotgun.DropDownWidth = 450;
		Combo_WinchesterShotgun.Font = new Font("Segoe UI", 7f);
		Combo_WinchesterShotgun.FormattingEnabled = true;
		Combo_WinchesterShotgun.Location = new Point(111, 528);
		Combo_WinchesterShotgun.Margin = new Padding(0, 0, 3, 3);
		Combo_WinchesterShotgun.Name = "Combo_WinchesterShotgun";
		Combo_WinchesterShotgun.Size = new Size(118, 21);
		Combo_WinchesterShotgun.TabIndex = 68;
		Combo_JettisonOrdnance.BackColor = Color.Transparent;
		Combo_JettisonOrdnance.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_JettisonOrdnance.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_JettisonOrdnance.DropDownWidth = 450;
		Combo_JettisonOrdnance.Font = new Font("Segoe UI", 7f);
		Combo_JettisonOrdnance.FormattingEnabled = true;
		Combo_JettisonOrdnance.Location = new Point(111, 594);
		Combo_JettisonOrdnance.Margin = new Padding(0, 0, 3, 3);
		Combo_JettisonOrdnance.Name = "Combo_JettisonOrdnance";
		Combo_JettisonOrdnance.Size = new Size(118, 21);
		Combo_JettisonOrdnance.TabIndex = 70;
		Combo_BingoJokerRTB.BackColor = Color.Transparent;
		Combo_BingoJokerRTB.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BingoJokerRTB.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BingoJokerRTB.DropDownWidth = 450;
		Combo_BingoJokerRTB.Font = new Font("Segoe UI", 7f);
		Combo_BingoJokerRTB.FormattingEnabled = true;
		Combo_BingoJokerRTB.Location = new Point(111, 506);
		Combo_BingoJokerRTB.Margin = new Padding(0, 0, 3, 3);
		Combo_BingoJokerRTB.Name = "Combo_BingoJokerRTB";
		Combo_BingoJokerRTB.Size = new Size(118, 21);
		Combo_BingoJokerRTB.TabIndex = 69;
		Label20.AutoSize = true;
		Label20.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		Label20.ForeColor = Color.FromArgb(220, 220, 220);
		Label20.Location = new Point(0, 264);
		Label20.Margin = new Padding(0, 0, 3, 0);
		Label20.Name = "Label20";
		Label20.Padding = new Padding(0, 9, 0, 0);
		Label20.Size = new Size(31, 22);
		Label20.TabIndex = 64;
		Label20.Text = "其它";
		Label13.AutoSize = true;
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(0, 292);
		Label13.Margin = new Padding(0, 6, 0, 0);
		Label13.Name = "Label13";
		Label13.Size = new Size(80, 13);
		Label13.TabIndex = 43;
		Label13.Text = "Torpedo range:";
		Combo_UseKinematicRangeForTorpedoes.BackColor = Color.Transparent;
		Combo_UseKinematicRangeForTorpedoes.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseKinematicRangeForTorpedoes.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseKinematicRangeForTorpedoes.Font = new Font("Segoe UI", 7f);
		Combo_UseKinematicRangeForTorpedoes.FormattingEnabled = true;
		Combo_UseKinematicRangeForTorpedoes.Location = new Point(111, 286);
		Combo_UseKinematicRangeForTorpedoes.Margin = new Padding(0, 0, 3, 3);
		Combo_UseKinematicRangeForTorpedoes.Name = "Combo_UseKinematicRangeForTorpedoes";
		Combo_UseKinematicRangeForTorpedoes.Size = new Size(118, 21);
		Combo_UseKinematicRangeForTorpedoes.TabIndex = 55;
		Combo_AutoEvade.BackColor = Color.Transparent;
		Combo_AutoEvade.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AutoEvade.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AutoEvade.Font = new Font("Segoe UI", 7f);
		Combo_AutoEvade.FormattingEnabled = true;
		Combo_AutoEvade.Location = new Point(111, 308);
		Combo_AutoEvade.Margin = new Padding(0, 0, 3, 3);
		Combo_AutoEvade.Name = "Combo_AutoEvade";
		Combo_AutoEvade.Size = new Size(118, 21);
		Combo_AutoEvade.TabIndex = 49;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(0, 336);
		Label6.Margin = new Padding(0, 6, 0, 0);
		Label6.Name = "Label6";
		Label6.Size = new Size(44, 13);
		Label6.TabIndex = 32;
		Label6.Text = "Refuel: ";
		Label29.AutoSize = true;
		Label29.ForeColor = Color.FromArgb(220, 220, 220);
		Label29.Location = new Point(0, 380);
		Label29.Margin = new Padding(0, 6, 0, 0);
		Label29.Name = "Label29";
		Label29.Size = new Size(70, 13);
		Label29.TabIndex = 32;
		Label29.Text = "Refuel allies: ";
		Combo_UseRefuel.BackColor = Color.Transparent;
		Combo_UseRefuel.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_UseRefuel.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_UseRefuel.DropDownWidth = 200;
		Combo_UseRefuel.Font = new Font("Segoe UI", 7f);
		Combo_UseRefuel.FormattingEnabled = true;
		Combo_UseRefuel.Location = new Point(111, 330);
		Combo_UseRefuel.Margin = new Padding(0, 0, 3, 3);
		Combo_UseRefuel.Name = "Combo_UseRefuel";
		Combo_UseRefuel.Size = new Size(118, 21);
		Combo_UseRefuel.TabIndex = 51;
		Combo_RefuelAllies.BackColor = Color.Transparent;
		Combo_RefuelAllies.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_RefuelAllies.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_RefuelAllies.DropDownWidth = 200;
		Combo_RefuelAllies.Font = new Font("Segoe UI", 7f);
		Combo_RefuelAllies.FormattingEnabled = true;
		Combo_RefuelAllies.Location = new Point(111, 374);
		Combo_RefuelAllies.Margin = new Padding(0, 0, 3, 3);
		Combo_RefuelAllies.Name = "Combo_RefuelAllies";
		Combo_RefuelAllies.Size = new Size(118, 21);
		Combo_RefuelAllies.TabIndex = 51;
		Label37.AutoSize = true;
		Label37.ForeColor = Color.FromArgb(220, 220, 220);
		Label37.Location = new Point(0, 358);
		Label37.Margin = new Padding(0, 6, 0, 0);
		Label37.Name = "Label37";
		Label37.Size = new Size(89, 13);
		Label37.TabIndex = 32;
		Label37.Text = "Refuel selection: ";
		Combo_ReplenishmentSelection.BackColor = Color.Transparent;
		Combo_ReplenishmentSelection.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_ReplenishmentSelection.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_ReplenishmentSelection.DropDownWidth = 200;
		Combo_ReplenishmentSelection.Font = new Font("Segoe UI", 7f);
		Combo_ReplenishmentSelection.FormattingEnabled = true;
		Combo_ReplenishmentSelection.Location = new Point(111, 352);
		Combo_ReplenishmentSelection.Margin = new Padding(0, 0, 3, 3);
		Combo_ReplenishmentSelection.Name = "Combo_ReplenishmentSelection";
		Combo_ReplenishmentSelection.Size = new Size(118, 21);
		Combo_ReplenishmentSelection.TabIndex = 51;
		Combo_DippingSonar.BackColor = Color.Transparent;
		Combo_DippingSonar.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_DippingSonar.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_DippingSonar.Font = new Font("Segoe UI", 7f);
		Combo_DippingSonar.FormattingEnabled = true;
		Combo_DippingSonar.Location = new Point(111, 836);
		Combo_DippingSonar.Margin = new Padding(0, 0, 3, 3);
		Combo_DippingSonar.Name = "Combo_DippingSonar";
		Combo_DippingSonar.Size = new Size(118, 21);
		Combo_DippingSonar.TabIndex = 50;
		Combo_AIP_Usage.BackColor = Color.Transparent;
		Combo_AIP_Usage.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AIP_Usage.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AIP_Usage.Font = new Font("Segoe UI", 7f);
		Combo_AIP_Usage.FormattingEnabled = true;
		Combo_AIP_Usage.Location = new Point(111, 814);
		Combo_AIP_Usage.Margin = new Padding(0, 0, 3, 3);
		Combo_AIP_Usage.Name = "Combo_AIP_Usage";
		Combo_AIP_Usage.Size = new Size(118, 21);
		Combo_AIP_Usage.TabIndex = 50;
		Combo_BatteryRechargeAttack.BackColor = Color.Transparent;
		Combo_BatteryRechargeAttack.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BatteryRechargeAttack.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BatteryRechargeAttack.Font = new Font("Segoe UI", 7f);
		Combo_BatteryRechargeAttack.FormattingEnabled = true;
		Combo_BatteryRechargeAttack.Location = new Point(111, 792);
		Combo_BatteryRechargeAttack.Margin = new Padding(0, 0, 3, 3);
		Combo_BatteryRechargeAttack.Name = "Combo_BatteryRechargeAttack";
		Combo_BatteryRechargeAttack.Size = new Size(118, 21);
		Combo_BatteryRechargeAttack.TabIndex = 50;
		Combo_BatteryRechargePatrol.BackColor = Color.Transparent;
		Combo_BatteryRechargePatrol.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_BatteryRechargePatrol.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_BatteryRechargePatrol.Font = new Font("Segoe UI", 7f);
		Combo_BatteryRechargePatrol.FormattingEnabled = true;
		Combo_BatteryRechargePatrol.Location = new Point(111, 770);
		Combo_BatteryRechargePatrol.Margin = new Padding(0, 0, 3, 3);
		Combo_BatteryRechargePatrol.Name = "Combo_BatteryRechargePatrol";
		Combo_BatteryRechargePatrol.Size = new Size(118, 21);
		Combo_BatteryRechargePatrol.TabIndex = 50;
		Combo_DiveWhenThreatsDetected.BackColor = Color.Transparent;
		Combo_DiveWhenThreatsDetected.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_DiveWhenThreatsDetected.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_DiveWhenThreatsDetected.Font = new Font("Segoe UI", 7f);
		Combo_DiveWhenThreatsDetected.FormattingEnabled = true;
		Combo_DiveWhenThreatsDetected.Location = new Point(111, 748);
		Combo_DiveWhenThreatsDetected.Margin = new Padding(0, 0, 3, 3);
		Combo_DiveWhenThreatsDetected.Name = "Combo_DiveWhenThreatsDetected";
		Combo_DiveWhenThreatsDetected.Size = new Size(118, 21);
		Combo_DiveWhenThreatsDetected.TabIndex = 50;
		Combo_AvoidContact.BackColor = Color.Transparent;
		Combo_AvoidContact.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_AvoidContact.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_AvoidContact.Font = new Font("Segoe UI", 7f);
		Combo_AvoidContact.FormattingEnabled = true;
		Combo_AvoidContact.Location = new Point(111, 726);
		Combo_AvoidContact.Margin = new Padding(0, 0, 3, 3);
		Combo_AvoidContact.Name = "Combo_AvoidContact";
		Combo_AvoidContact.Size = new Size(118, 21);
		Combo_AvoidContact.TabIndex = 50;
		Combo_Surface_Navigation.BackColor = Color.Transparent;
		Combo_Surface_Navigation.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Surface_Navigation.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Surface_Navigation.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Surface_Navigation.FormattingEnabled = true;
		Combo_Surface_Navigation.Location = new Point(111, 682);
		Combo_Surface_Navigation.Margin = new Padding(0, 0, 3, 3);
		Combo_Surface_Navigation.Name = "Combo_Surface_Navigation";
		Combo_Surface_Navigation.Size = new Size(118, 21);
		Combo_Surface_Navigation.TabIndex = 73;
		Combo_Submarine_Navigation.BackColor = Color.Transparent;
		Combo_Submarine_Navigation.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Submarine_Navigation.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Submarine_Navigation.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Submarine_Navigation.FormattingEnabled = true;
		Combo_Submarine_Navigation.Location = new Point(111, 858);
		Combo_Submarine_Navigation.Margin = new Padding(0, 0, 3, 3);
		Combo_Submarine_Navigation.Name = "Combo_Submarine_Navigation";
		Combo_Submarine_Navigation.Size = new Size(118, 21);
		Combo_Submarine_Navigation.TabIndex = 74;
		Combo_Land_Navigation.BackColor = Color.Transparent;
		Combo_Land_Navigation.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_Land_Navigation.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_Land_Navigation.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_Land_Navigation.FormattingEnabled = true;
		Combo_Land_Navigation.Location = new Point(111, 918);
		Combo_Land_Navigation.Margin = new Padding(0, 0, 3, 3);
		Combo_Land_Navigation.Name = "Combo_Land_Navigation";
		Combo_Land_Navigation.Size = new Size(108, 21);
		Combo_Land_Navigation.TabIndex = 75;
		DarkLabel3.AutoSize = true;
		DarkLabel3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(0, 898);
		DarkLabel3.Margin = new Padding(0, 0, 3, 0);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Padding = new Padding(0, 9, 0, 0);
		DarkLabel3.Size = new Size(33, 20);
		DarkLabel3.TabIndex = 78;
		DarkLabel3.Text = "地面作战";
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(0, 864);
		DarkLabel2.Margin = new Padding(0, 6, 0, 0);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(61, 13);
		DarkLabel2.TabIndex = 77;
		DarkLabel2.Text = "导航：";
		Label36.AutoSize = true;
		Label36.ForeColor = Color.FromArgb(220, 220, 220);
		Label36.Location = new Point(0, 842);
		Label36.Margin = new Padding(0, 6, 0, 0);
		Label36.Name = "Label36";
		Label36.Size = new Size(75, 13);
		Label36.TabIndex = 36;
		Label36.Text = "浸入声纳：";
		Label35.AutoSize = true;
		Label35.ForeColor = Color.FromArgb(220, 220, 220);
		Label35.Location = new Point(0, 820);
		Label35.Margin = new Padding(0, 6, 0, 0);
		Label35.Name = "Label35";
		Label35.Size = new Size(59, 13);
		Label35.TabIndex = 36;
		Label35.Text = "AIP usage:";
		Label34.AutoSize = true;
		Label34.ForeColor = Color.FromArgb(220, 220, 220);
		Label34.Location = new Point(0, 798);
		Label34.Margin = new Padding(0, 6, 0, 0);
		Label34.Name = "Label34";
		Label34.Size = new Size(93, 13);
		Label34.TabIndex = 36;
		Label34.Text = "Recharge, attack:";
		Label33.AutoSize = true;
		Label33.ForeColor = Color.FromArgb(220, 220, 220);
		Label33.Location = new Point(0, 776);
		Label33.Margin = new Padding(0, 6, 0, 0);
		Label33.Name = "Label33";
		Label33.Size = new Size(89, 13);
		Label33.TabIndex = 36;
		Label33.Text = "Recharge, patrol:";
		Label32.AutoSize = true;
		Label32.ForeColor = Color.FromArgb(220, 220, 220);
		Label32.Location = new Point(0, 754);
		Label32.Margin = new Padding(0, 6, 0, 0);
		Label32.Name = "Label32";
		Label32.Size = new Size(77, 13);
		Label32.TabIndex = 36;
		Label32.Text = "Dive on threat:";
		Label31.AutoSize = true;
		Label31.ForeColor = Color.FromArgb(220, 220, 220);
		Label31.Location = new Point(0, 732);
		Label31.Margin = new Padding(0, 6, 0, 0);
		Label31.Name = "Label31";
		Label31.Size = new Size(76, 13);
		Label31.TabIndex = 36;
		Label31.Text = "避免目标：";
		Label30.AutoSize = true;
		Label30.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		Label30.ForeColor = Color.FromArgb(220, 220, 220);
		Label30.Location = new Point(0, 704);
		Label30.Margin = new Padding(0, 0, 3, 0);
		Label30.Name = "Label30";
		Label30.Padding = new Padding(0, 9, 0, 0);
		Label30.Size = new Size(32, 22);
		Label30.TabIndex = 62;
		Label30.Text = "反潜战ASW";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(0, 688);
		DarkLabel1.Margin = new Padding(0, 6, 0, 0);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(61, 13);
		DarkLabel1.TabIndex = 76;
		DarkLabel1.Text = "导航：";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(0, 666);
		Label5.Margin = new Padding(0, 6, 0, 0);
		Label5.Name = "Label5";
		Label5.Size = new Size(94, 13);
		Label5.TabIndex = 30;
		Label5.Text = "Maintain standoff: ";
		Label10.AutoSize = true;
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(0, 644);
		Label10.Margin = new Padding(0, 6, 0, 0);
		Label10.Name = "Label10";
		Label10.Size = new Size(97, 13);
		Label10.TabIndex = 36;
		Label10.Text = "Anti-surface SAMs:";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(0, 616);
		Label2.Margin = new Padding(0, 0, 3, 0);
		Label2.Name = "Label2";
		Label2.Padding = new Padding(0, 9, 0, 0);
		Label2.Size = new Size(39, 22);
		Label2.TabIndex = 62;
		Label2.Text = "反水面战ASuW";
		Label28.AutoSize = true;
		Label28.ForeColor = Color.FromArgb(220, 220, 220);
		Label28.Location = new Point(0, 600);
		Label28.Margin = new Padding(0, 6, 0, 0);
		Label28.Name = "Label28";
		Label28.Size = new Size(96, 13);
		Label28.TabIndex = 72;
		Label28.Text = "丢弃军械：";
		Label24.AutoSize = true;
		Label24.ForeColor = Color.FromArgb(220, 220, 220);
		Label24.Location = new Point(0, 578);
		Label24.Margin = new Padding(0, 6, 0, 0);
		Label24.Name = "Label24";
		Label24.Size = new Size(94, 13);
		Label24.TabIndex = 24;
		Label24.Text = "空对地扫射（航炮）：";
		Label26.AutoSize = true;
		Label26.ForeColor = Color.FromArgb(220, 220, 220);
		Label26.Location = new Point(0, 534);
		Label26.Margin = new Padding(0, 6, 0, 0);
		Label26.Name = "Label26";
		Label26.Size = new Size(79, 13);
		Label26.TabIndex = 41;
		Label26.Text = "Weapon State:";
		Label27.AutoSize = true;
		Label27.ForeColor = Color.FromArgb(220, 220, 220);
		Label27.Location = new Point(0, 512);
		Label27.Margin = new Padding(0, 6, 0, 0);
		Label27.Name = "Label27";
		Label27.Size = new Size(83, 13);
		Label27.TabIndex = 71;
		Label27.Text = "燃料状态，返回基地：";
		Label25.AutoSize = true;
		Label25.ForeColor = Color.FromArgb(220, 220, 220);
		Label25.Location = new Point(0, 490);
		Label25.Margin = new Padding(0, 6, 0, 0);
		Label25.Name = "Label25";
		Label25.Size = new Size(58, 13);
		Label25.TabIndex = 41;
		Label25.Text = "Fuel State:";
		Label14.AutoSize = true;
		Label14.ForeColor = Color.FromArgb(220, 220, 220);
		Label14.Location = new Point(0, 468);
		Label14.Margin = new Padding(0, 6, 0, 0);
		Label14.Name = "Label14";
		Label14.Size = new Size(92, 13);
		Label14.TabIndex = 41;
		Label14.Text = "快速再次出动：";
		Label12.AutoSize = true;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(0, 446);
		Label12.Margin = new Padding(0, 6, 0, 0);
		Label12.Name = "Label12";
		Label12.Size = new Size(80, 13);
		Label12.TabIndex = 39;
		Label12.Text = "Air Ops Tempo:";
		Label18.AutoSize = true;
		Label18.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
		Label18.ForeColor = Color.FromArgb(220, 220, 220);
		Label18.Location = new Point(0, 418);
		Label18.Margin = new Padding(0, 0, 3, 0);
		Label18.Name = "Label18";
		Label18.Padding = new Padding(0, 9, 0, 0);
		Label18.Size = new Size(45, 22);
		Label18.TabIndex = 61;
		Label18.Text = "空中作战";
		DarkLabel5.AutoSize = true;
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(0, 402);
		DarkLabel5.Margin = new Padding(0, 6, 0, 0);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(93, 13);
		DarkLabel5.TabIndex = 80;
		DarkLabel5.Text = "给加油机加油：";
		BingoThresholdCombo.BackColor = Color.Transparent;
		BingoThresholdCombo.DrawMode = DrawMode.OwnerDrawFixed;
		BingoThresholdCombo.DropDownStyle = ComboBoxStyle.DropDownList;
		BingoThresholdCombo.DropDownWidth = 200;
		BingoThresholdCombo.Font = new Font("Segoe UI", 7f);
		BingoThresholdCombo.FormattingEnabled = true;
		BingoThresholdCombo.Location = new Point(111, 396);
		BingoThresholdCombo.Margin = new Padding(0, 0, 3, 3);
		BingoThresholdCombo.Name = "BingoThresholdCombo";
		BingoThresholdCombo.Size = new Size(118, 21);
		BingoThresholdCombo.TabIndex = 81;
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(0, 924);
		DarkLabel4.Margin = new Padding(0, 6, 0, 0);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(61, 13);
		DarkLabel4.TabIndex = 83;
		DarkLabel4.Text = "导航：";
		DarkLabel6.AutoSize = true;
		DarkLabel6.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel6.Location = new Point(0, 884);
		DarkLabel6.Margin = new Padding(0, 6, 0, 0);
		DarkLabel6.Name = "DarkLabel6";
		DarkLabel6.Size = new Size(93, 13);
		DarkLabel6.TabIndex = 84;
		DarkLabel6.Text = "WP Missile ASuW";
		Combo_USeWPMissilesOnASuW.BackColor = Color.Transparent;
		Combo_USeWPMissilesOnASuW.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_USeWPMissilesOnASuW.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_USeWPMissilesOnASuW.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_USeWPMissilesOnASuW.FormattingEnabled = true;
		Combo_USeWPMissilesOnASuW.Location = new Point(111, 878);
		Combo_USeWPMissilesOnASuW.Margin = new Padding(0, 0, 3, 3);
		Combo_USeWPMissilesOnASuW.Name = "Combo_USeWPMissilesOnASuW";
		Combo_USeWPMissilesOnASuW.Size = new Size(118, 21);
		Combo_USeWPMissilesOnASuW.TabIndex = 85;
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(Button1);
		base.Controls.Add(TableLayoutPanel1);
		base.Margin = new Padding(0);
		MinimumSize = new Size(0, 650);
		base.Name = "DoctrineControl";
		base.Size = new Size(232, 960);
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		TableLayoutPanel1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void OrderSchema(object sender, EventArgs e)
	{
		Doctrine.DoctrineChanged += RegisterSchema;
		Client.SelectedUnitChanged += ManageSchema;
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void RegisterSchema(ScenarioObject scenarioObject_0, bool? nullable_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		if (bool_2 || bool_3 || Information.IsNothing(scenarioObject_0) || (!scenarioObject_0.IsActiveUnit && (object)scenarioObject_0.GetType() != typeof(Side)) || (bool_0 && scenarioObject_0 != Client.SelectedUnit) || (scenarioObject_0.IsActiveUnit && (!Client.CurrentScenario.ActiveUnits.ContainsKey(scenarioObject_0.ObjectID) || !((ActiveUnit)scenarioObject_0).IsOperating())) || ((object)scenarioObject_0.GetType() == typeof(Side) && !Client.CurrentScenario.Sides_ReadOnly.Contains((Side)scenarioObject_0)))
		{
			return;
		}
		try
		{
			if (Information.IsNothing(nullable_0) || (object)base.Parent.GetType() != typeof(CollapsiblePanel) || ((CollapsiblePanel)base.Parent).PanelState != 0)
			{
				return;
			}
			if (nullable_0.GetValueOrDefault())
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.AddInterruptibleIndexer(Client.SelectedUnit, Client.SelectedUnit);
				return;
			}
			Form[] ownedForms = ItemExporter.ConnectInterruptibleTemplate.MainForm.OwnedForms;
			for (int i = 0; i < ownedForms.Length; i = checked(i + 1))
			{
				if ((object)ownedForms[i].GetType() == typeof(DoctrineForm))
				{
					ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.AddInterruptibleIndexer(Client.SelectedUnit, Client.SelectedUnit);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200370", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ManageSchema(Module_Unit.Unit unit_0)
	{
		m_PolicyStub = unit_0;
		m_BroadcasterStub = true;
	}

	[SpecialName]
	private Doctrine GetSelectedUnitDoctrine()
	{
		if (Information.IsNothing(m_PolicyStub))
		{
			m_PolicyStub = Client.SelectedUnit;
		}
		if (Information.IsNothing(m_PolicyStub))
		{
			return null;
		}
		if ((object)m_PolicyStub.GetType() == typeof(Side))
		{
			return ((Side)m_PolicyStub).Doctrine;
		}
		if (m_PolicyStub.IsMission)
		{
			return ((Mission)m_PolicyStub).Doctrine;
		}
		if (m_PolicyStub.IsGroup)
		{
			return ((Group)m_PolicyStub).Doctrine;
		}
		if (m_PolicyStub.IsActiveUnit)
		{
			return ((ActiveUnit)m_PolicyStub).Doctrine;
		}
		return null;
	}

	public void RefreshPanel(bool bool_0)
	{
		if (Information.IsNothing(Client.SelectedUnit) || Information.IsNothing(GetSelectedUnitDoctrine()))
		{
			return;
		}
		if (Client._StateClass != 1f)
		{
			if (ActualWidth == 0)
			{
				ActualWidth = base.Width;
			}
			if (ActualWidth == base.Width)
			{
				base.Width = (int)Math.Round((float)base.Width * Client._StateClass);
			}
		}
		base.Enabled = Client.SelectedUnit.GetUnitSide() == Client.CurrentSide;
		Button1.Visible = !Information.IsNothing(m_PolicyStub);
		if (bool_0)
		{
			Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_UseNukes = Combo_UseNukes;
			Scenario scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine.Populate_Combo_UseNukes(combo_UseNukes, ref scenario_, null);
			Doctrine selectedUnitDoctrine12 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_WeaponControlStatus_Air = Combo_WeaponControlStatus_Air;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine12.Populate_Combo_WeaponControlStatus_Air(combo_WeaponControlStatus_Air, ref scenario_, null);
			Doctrine selectedUnitDoctrine23 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_WeaponControlStatus_Surface = Combo_WeaponControlStatus_Surface;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine23.Populate_Combo_WeaponControlStatus_Surface(combo_WeaponControlStatus_Surface, ref scenario_, null);
			Doctrine selectedUnitDoctrine30 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_WeaponControlStatus_Submarine = Combo_WeaponControlStatus_Submarine;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine30.Populate_Combo_WeaponControlStatus_Submarine(combo_WeaponControlStatus_Submarine, ref scenario_, null);
			Doctrine selectedUnitDoctrine31 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_WeaponControlStatus_Land = Combo_WeaponControlStatus_Land;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine31.Populate_Combo_WeaponControlStatus_Land(combo_WeaponControlStatus_Land, ref scenario_, null);
			Doctrine selectedUnitDoctrine32 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_GunStrafing = Combo_GunStrafing;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine32.Populate_Combo_GunStrafing(combo_GunStrafing, ref scenario_, null);
			Doctrine selectedUnitDoctrine33 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_IgnorePlottedCourse = Combo_IgnorePlottedCourse;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine33.Populate_Combo_IgnorePlottedCourse(combo_IgnorePlottedCourse, ref scenario_, null);
			Doctrine selectedUnitDoctrine34 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_BehaviorTowardsAmbigousTarget = Combo_BehaviorTowardsAmbigousTarget;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine34.Populate_Combo_BehaviorTowardsAmbigousTarget(combo_BehaviorTowardsAmbigousTarget, ref scenario_, null);
			Doctrine selectedUnitDoctrine35 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_AutoEvade = Combo_AutoEvade;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine35.Populate_Combo_AutoEvade(combo_AutoEvade, ref scenario_, null);
			Doctrine selectedUnitDoctrine2 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_UseRefuel = Combo_UseRefuel;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine2.Populate_Combo_UseRefuel(combo_UseRefuel, ref scenario_, null);
			Doctrine selectedUnitDoctrine3 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_ReplenishmentSelection = Combo_ReplenishmentSelection;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine3.Populate_Combo_ReplenishmentSelection(combo_ReplenishmentSelection, ref scenario_, null);
			Doctrine selectedUnitDoctrine4 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_Standoff = Combo_Standoff;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine4.Populate_Combo_Standoff(combo_Standoff, ref scenario_, null);
			Doctrine selectedUnitDoctrine5 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_ShootTourists = Combo_ShootTourists;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine5.Populate_Combo_ShootTourists(combo_ShootTourists, ref scenario_, null);
			Doctrine selectedUnitDoctrine6 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_UseSAMsOnASuW = Combo_UseSAMsOnASuW;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine6.Populate_Combo_UseSAMsOnASuW(combo_UseSAMsOnASuW, ref scenario_, null);
			Doctrine selectedUnitDoctrine7 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_USeWPMissilesOnASuW = Combo_USeWPMissilesOnASuW;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine7.Populate_Combo_UseWPWeaponOnASuW(combo_USeWPMissilesOnASuW, ref scenario_, null);
			Doctrine selectedUnitDoctrine8 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_IgnoreEMCONunderAttack = Combo_IgnoreEMCONunderAttack;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine8.Populate_Combo_IgnoreEMCONunderAttack(combo_IgnoreEMCONunderAttack, ref scenario_, null);
			Doctrine selectedUnitDoctrine9 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_QuickTurnAroundForAicraft = Combo_QuickTurnAroundForAicraft;
			scenario_ = Client.CurrentScenario;
			bool bool_ = true;
			selectedUnitDoctrine9.Populate_Combo_QuickTurnAroundForAicraft(combo_QuickTurnAroundForAicraft, ref scenario_, ref bool_, null);
			Doctrine selectedUnitDoctrine10 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_BingoJoker = Combo_BingoJoker;
			scenario_ = Client.CurrentScenario;
			bool_ = true;
			selectedUnitDoctrine10.Populate_Combo_BingoJoker(combo_BingoJoker, ref scenario_, ref bool_, null);
			Doctrine selectedUnitDoctrine11 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_BingoJokerRTB = Combo_BingoJokerRTB;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine11.Populate_Combo_BingoJokerRTB(combo_BingoJokerRTB, ref scenario_, null);
			Doctrine selectedUnitDoctrine13 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_WinchesterShotgun = Combo_WinchesterShotgun;
			scenario_ = Client.CurrentScenario;
			bool_ = true;
			selectedUnitDoctrine13.Populate_Combo_WinchesterShotgun(combo_WinchesterShotgun, ref scenario_, ref bool_, null);
			Doctrine selectedUnitDoctrine14 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_WinchesterShotgunRTB = Combo_WinchesterShotgunRTB;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine14.Populate_Combo_WinchesterShotgunRTB(combo_WinchesterShotgunRTB, ref scenario_, null);
			Doctrine selectedUnitDoctrine15 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_JettisonOrdnance = Combo_JettisonOrdnance;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine15.Populate_Combo_JettisonOrdnance(combo_JettisonOrdnance, ref scenario_, null);
			Doctrine selectedUnitDoctrine16 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_AirOpsTempo = Combo_AirOpsTempo;
			scenario_ = Client.CurrentScenario;
			bool_ = true;
			selectedUnitDoctrine16.Populate_Combo_AirOpsTempo(combo_AirOpsTempo, ref scenario_, ref bool_, null);
			Doctrine selectedUnitDoctrine17 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_UseKinematicRangeForTorpedoes = Combo_UseKinematicRangeForTorpedoes;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine17.Populate_Combo_UseKinematicRangeForTorpedoes(combo_UseKinematicRangeForTorpedoes, ref scenario_, null);
			Doctrine selectedUnitDoctrine18 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_RefuelAllies = Combo_RefuelAllies;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine18.Populate_Combo_RefuelAllies(combo_RefuelAllies, ref scenario_, null);
			Doctrine selectedUnitDoctrine19 = GetSelectedUnitDoctrine();
			DarkUIComboBox bingoThresholdCombo = BingoThresholdCombo;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine19.Populate_Combo_BingoRefuel(bingoThresholdCombo, ref scenario_, null);
			Doctrine selectedUnitDoctrine20 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_AvoidContact = Combo_AvoidContact;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine20.Populate_Combo_AvoidContact(combo_AvoidContact, ref scenario_, null);
			Doctrine selectedUnitDoctrine21 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_DiveWhenThreatsDetected = Combo_DiveWhenThreatsDetected;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine21.Populate_Combo_DiveWhenThreatsDetected(combo_DiveWhenThreatsDetected, ref scenario_, null);
			Doctrine selectedUnitDoctrine22 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_BatteryRechargePatrol = Combo_BatteryRechargePatrol;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine22.Populate_Combo_RechargePercentagePatrol(combo_BatteryRechargePatrol, ref scenario_, null);
			Doctrine selectedUnitDoctrine24 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_BatteryRechargeAttack = Combo_BatteryRechargeAttack;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine24.Populate_Combo_RechargePercentageAttack(combo_BatteryRechargeAttack, ref scenario_, null);
			Doctrine selectedUnitDoctrine25 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_AIP_Usage = Combo_AIP_Usage;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine25.Populate_Combo_AIPUsage(combo_AIP_Usage, ref scenario_, null);
			Doctrine selectedUnitDoctrine26 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_DippingSonar = Combo_DippingSonar;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine26.Populate_Combo_DippingSonar(combo_DippingSonar, ref scenario_, null);
			Doctrine selectedUnitDoctrine27 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_Surface_Navigation = Combo_Surface_Navigation;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine27.Populate_Combo_SurfaceNavigation(combo_Surface_Navigation, ref scenario_, null);
			Doctrine selectedUnitDoctrine28 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_Submarine_Navigation = Combo_Submarine_Navigation;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine28.Populate_Combo_SubmarineNavigation(combo_Submarine_Navigation, ref scenario_, null);
			Doctrine selectedUnitDoctrine29 = GetSelectedUnitDoctrine();
			DarkUIComboBox combo_Land_Navigation = Combo_Land_Navigation;
			scenario_ = Client.CurrentScenario;
			selectedUnitDoctrine29.Populate_Combo_LandNavigation(combo_Land_Navigation, ref scenario_, null);
		}
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			Combo_UseNukes.Enabled = GetSelectedUnitDoctrine().GetNukesAllowed_PlayerEditable(Client.CurrentScenario);
			Combo_WeaponControlStatus_Air.Enabled = GetSelectedUnitDoctrine().GetWeaponControlStatus_Air_PlayerEditable(Client.CurrentScenario);
			Combo_WeaponControlStatus_Surface.Enabled = GetSelectedUnitDoctrine().GetWeaponControlStatus_Surface_PlayerEditable(Client.CurrentScenario);
			Combo_WeaponControlStatus_Submarine.Enabled = GetSelectedUnitDoctrine().GetWeaponControlStatus_Submarine_PlayerEditable(Client.CurrentScenario);
			Combo_WeaponControlStatus_Land.Enabled = GetSelectedUnitDoctrine().GetWeaponControlStatus_Land_PlayerEditable(Client.CurrentScenario);
			Combo_GunStrafing.Enabled = GetSelectedUnitDoctrine().GetGunStrafing_PlayerEditable(Client.CurrentScenario);
			Combo_IgnorePlottedCourse.Enabled = GetSelectedUnitDoctrine().GetIgnorePlottedCourse_PlayerEditable(Client.CurrentScenario);
			Combo_BehaviorTowardsAmbigousTarget.Enabled = GetSelectedUnitDoctrine().GetBehaviorTowardsAmbigousTarget_PlayerEditable(Client.CurrentScenario);
			Combo_AutoEvade.Enabled = GetSelectedUnitDoctrine().GetAutoEvade_PlayerEditable(Client.CurrentScenario);
			Combo_UseRefuel.Enabled = GetSelectedUnitDoctrine().GetUseReplenishment_PlayerEditable(Client.CurrentScenario);
			Combo_ReplenishmentSelection.Enabled = GetSelectedUnitDoctrine().GetReplenishmentSelection_PlayerEditable(Client.CurrentScenario);
			Combo_Standoff.Enabled = GetSelectedUnitDoctrine().GetMaintainStandoff_PlayerEditable(Client.CurrentScenario);
			Combo_ShootTourists.Enabled = GetSelectedUnitDoctrine().GetShootTourists_PlayerEditable(Client.CurrentScenario);
			Combo_UseSAMsOnASuW.Enabled = GetSelectedUnitDoctrine().GetUseSAMsOnASuW_PlayerEditable(Client.CurrentScenario);
			Combo_IgnoreEMCONunderAttack.Enabled = GetSelectedUnitDoctrine().GetIgnoreEMCONunderAttack_PlayerEditable(Client.CurrentScenario);
			Combo_QuickTurnAroundForAicraft.Enabled = GetSelectedUnitDoctrine().GetQuickTurnAroundForAicraft_PlayerEditable(Client.CurrentScenario);
			Combo_BingoJoker.Enabled = GetSelectedUnitDoctrine().GetBingoJoker_PlayerEditable(Client.CurrentScenario);
			Combo_BingoJokerRTB.Enabled = GetSelectedUnitDoctrine().GetBingoJokerRTB_PlayerEditable(Client.CurrentScenario);
			Combo_WinchesterShotgun.Enabled = GetSelectedUnitDoctrine().GetWinchesterShotgun_PlayerEditable(Client.CurrentScenario);
			Combo_WinchesterShotgunRTB.Enabled = GetSelectedUnitDoctrine().GetWinchesterShotgunRTB_PlayerEditable(Client.CurrentScenario);
			Combo_JettisonOrdnance.Enabled = GetSelectedUnitDoctrine().GetJettisonOrdnance_PlayerEditable(Client.CurrentScenario);
			Combo_AirOpsTempo.Enabled = GetSelectedUnitDoctrine().GetAirOpsTempo_PlayerEditable(Client.CurrentScenario);
			Combo_UseKinematicRangeForTorpedoes.Enabled = GetSelectedUnitDoctrine().GetUseKinematicRangeForTorpedoes_PlayerEditable(Client.CurrentScenario);
			Combo_RefuelAllies.Enabled = GetSelectedUnitDoctrine().GetRefuelAllies_PlayerEditable(Client.CurrentScenario);
			BingoThresholdCombo.Enabled = GetSelectedUnitDoctrine().GetBingoRefuel_PlayerEditable(Client.CurrentScenario);
			Combo_AvoidContact.Enabled = GetSelectedUnitDoctrine().GetAvoidContact_PlayerEditable(Client.CurrentScenario);
			Combo_DiveWhenThreatsDetected.Enabled = GetSelectedUnitDoctrine().GetDiveWhenThreatsDetected_PlayerEditable(Client.CurrentScenario);
			Combo_BatteryRechargePatrol.Enabled = GetSelectedUnitDoctrine().GetRechargePercentagePatrol_PlayerEditable(Client.CurrentScenario);
			Combo_BatteryRechargeAttack.Enabled = GetSelectedUnitDoctrine().GetRechargePercentageAttack_PlayerEditable(Client.CurrentScenario);
			Combo_AIP_Usage.Enabled = GetSelectedUnitDoctrine().GetAIPUsage_PlayerEditable(Client.CurrentScenario);
			Combo_DippingSonar.Enabled = GetSelectedUnitDoctrine().GetDippingSonar_PlayerEditable(Client.CurrentScenario);
			Combo_Surface_Navigation.Enabled = GetSelectedUnitDoctrine().GetSurfaceNavigation_PlayerEditable(Client.CurrentScenario);
			Combo_Submarine_Navigation.Enabled = GetSelectedUnitDoctrine().GetSubmarineNavigation_PlayerEditable(Client.CurrentScenario);
			Combo_Land_Navigation.Enabled = GetSelectedUnitDoctrine().GetLandNavigation_PlayerEditable(Client.CurrentScenario);
		}
		m_BroadcasterStub = false;
	}

	private void RevertSchema(object sender, EventArgs e)
	{
		if (m_BroadcasterStub)
		{
			RefreshPanel(bool_0: false);
		}
		CustomPanelsEventRaiser.FireChangeEvent();
	}

	private void CountUtils(object sender, EventArgs e)
	{
		if (!Information.IsNothing(m_PolicyStub))
		{
			DoctrineForm doctrineForm = new DoctrineForm();
			doctrineForm.Subject = m_PolicyStub;
			doctrineForm.Show();
		}
	}

	private void CustomizeUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_UseNukes = Combo_UseNukes;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_UseNukes(combo_UseNukes, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void CloneUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_WeaponControlStatus_Air = Combo_WeaponControlStatus_Air;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_WeaponControlStatus_Air(combo_WeaponControlStatus_Air, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ConnectUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_WeaponControlStatus_Surface = Combo_WeaponControlStatus_Surface;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_WeaponControlStatus_Surface(combo_WeaponControlStatus_Surface, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void MoveUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_WeaponControlStatus_Submarine = Combo_WeaponControlStatus_Submarine;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_WeaponControlStatus_Submarine(combo_WeaponControlStatus_Submarine, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void DeleteUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_WeaponControlStatus_Land = Combo_WeaponControlStatus_Land;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_WeaponControlStatus_Land(combo_WeaponControlStatus_Land, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void AddUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_GunStrafing = Combo_GunStrafing;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_GunStrafing(combo_GunStrafing, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void DestroyUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_IgnorePlottedCourse = Combo_IgnorePlottedCourse;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_IgnorePlottedCourse(combo_IgnorePlottedCourse, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ComputeUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_BehaviorTowardsAmbigousTarget = Combo_BehaviorTowardsAmbigousTarget;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_BehaviorTowardsAmbigousTarget(combo_BehaviorTowardsAmbigousTarget, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void PatchUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_ShootTourists = Combo_ShootTourists;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_ShootTourists(combo_ShootTourists, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void SelectUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_IgnoreEMCONunderAttack = Combo_IgnoreEMCONunderAttack;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_IgnoreEMCONunderAttack(combo_IgnoreEMCONunderAttack, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void CallUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_AirOpsTempo = Combo_AirOpsTempo;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		bool bool_ = true;
		selectedUnitDoctrine.SelectionChanged_Combo_AirOpsTempo(combo_AirOpsTempo, ref scenario_, ref int_, ref bool_, bool_1: false, bool_2: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void LogoutUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_QuickTurnAroundForAicraft = Combo_QuickTurnAroundForAicraft;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		bool bool_ = true;
		selectedUnitDoctrine.SelectionChanged_Combo_QuickTurnAroundForAicraft(combo_QuickTurnAroundForAicraft, ref scenario_, ref int_, ref bool_, bool_1: false, bool_2: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ViewUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_BingoJoker = Combo_BingoJoker;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		bool bool_ = true;
		bool bool_2 = false;
		selectedUnitDoctrine.SelectionChanged_Combo_BingoJoker(combo_BingoJoker, ref scenario_, ref int_, ref bool_, ref bool_2, bool_2: false, bool_3: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ValidateUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_WinchesterShotgun = Combo_WinchesterShotgun;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		bool bool_ = true;
		selectedUnitDoctrine.SelectionChanged_Combo_WinchesterShotgun(combo_WinchesterShotgun, ref scenario_, ref int_, ref bool_, bool_1: false, bool_2: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void LoginUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_WinchesterShotgunRTB = Combo_WinchesterShotgunRTB;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_WinchesterShotgunRTB(combo_WinchesterShotgunRTB, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void GetUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_BingoJokerRTB = Combo_BingoJokerRTB;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_BingoJokerRTB(combo_BingoJokerRTB, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void WriteUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_JettisonOrdnance = Combo_JettisonOrdnance;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_JettisonOrdnance(combo_JettisonOrdnance, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void NewUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_UseSAMsOnASuW = Combo_UseSAMsOnASuW;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_UseSAMsOnASuW(combo_UseSAMsOnASuW, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void PushUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_Standoff = Combo_Standoff;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_Standoff(combo_Standoff, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void InvokeUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_UseKinematicRangeForTorpedoes = Combo_UseKinematicRangeForTorpedoes;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_UseKinematicRangeForTorpedoes(combo_UseKinematicRangeForTorpedoes, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void SetupUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_AutoEvade = Combo_AutoEvade;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_AutoEvade(combo_AutoEvade, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ExcludeUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		int selectedIndex = Combo_UseRefuel.SelectedIndex;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_UseRefuel(selectedIndex, ref scenario_, ref int_, bool_0: false, bool_1: true, bool_2: false);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void IncludeUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		int selectedIndex = Combo_ReplenishmentSelection.SelectedIndex;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_ReplenishmentSelection(selectedIndex, ref scenario_, ref int_, bool_0: false, bool_1: true, bool_2: false);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void SearchUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_RefuelAllies = Combo_RefuelAllies;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_RefuelAllies(combo_RefuelAllies, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void EnableUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox bingoThresholdCombo = BingoThresholdCombo;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_BingoThresholdCombo(bingoThresholdCombo, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ChangeUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_AvoidContact = Combo_AvoidContact;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_AvoidContact(combo_AvoidContact, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void InitUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_DiveWhenThreatsDetected = Combo_DiveWhenThreatsDetected;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_DiveWhenThreatsDetected(combo_DiveWhenThreatsDetected, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void CheckUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_BatteryRechargePatrol = Combo_BatteryRechargePatrol;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_RechargePercentagePatrol(combo_BatteryRechargePatrol, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void ConcatUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_BatteryRechargeAttack = Combo_BatteryRechargeAttack;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_RechargePercentageAttack(combo_BatteryRechargeAttack, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void InterruptUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_AIP_Usage = Combo_AIP_Usage;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_AIPUsage(combo_AIP_Usage, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void RemoveUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_DippingSonar = Combo_DippingSonar;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_DippingSonar(combo_DippingSonar, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void FindUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_Surface_Navigation = Combo_Surface_Navigation;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_SurfaceNavigation(combo_Surface_Navigation, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void SetUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_Submarine_Navigation = Combo_Submarine_Navigation;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_SubmarineNavigation(combo_Submarine_Navigation, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}

	private void FillUtils(object sender, EventArgs e)
	{
		Doctrine selectedUnitDoctrine = GetSelectedUnitDoctrine();
		DarkUIComboBox combo_Land_Navigation = Combo_Land_Navigation;
		Scenario scenario_ = Client.CurrentScenario;
		int int_ = 0;
		selectedUnitDoctrine.SelectionChanged_Combo_LandNavigation(combo_Land_Navigation, ref scenario_, ref int_, bool_0: false, bool_1: true);
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
	}
}
