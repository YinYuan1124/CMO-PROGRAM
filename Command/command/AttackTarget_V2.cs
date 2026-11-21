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
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AttackTarget_V2 : Form, GInterface9
{
	[CompilerGenerated]
	private sealed class RuleConfigManager
	{
		public ActiveUnit Local_theAttacker;

		public Func<Warhead, int> _003C_003E9__0;

		internal int StopInterruptibleParam(Warhead CW)
		{
			return CW.GetCarriedWeapon(Local_theAttacker.ParentScen).DBID;
		}
	}

	private IContainer m_BridgeBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearCourse_Attacker")]
	private DarkUIButton m_RequestBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_PlotCourse_Attacker")]
	private DarkUIButton m_ValueBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveWeapons_Attacker")]
	private DarkUIButton m_TokenizerBridge;

	[AccessedThroughProperty("TV_AvailableWeapons")]
	[CompilerGenerated]
	private DarkTreeView writerBridge;

	[AccessedThroughProperty("GB_WeaponAllocate")]
	[CompilerGenerated]
	private DarkGroupBox m_SpecificationBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AllocateSalvo")]
	private DarkUIButton watcherBridge;

	[AccessedThroughProperty("Button_AllocateAllWeapons")]
	[CompilerGenerated]
	private DarkUIButton m_ReponseBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_NumberOfWeapons")]
	private DarkNumericUpDown m_DescriptorBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Allocate")]
	private DarkUIButton m_PoolBridge;

	[AccessedThroughProperty("TabControl4")]
	[CompilerGenerated]
	private DarkUITabControl m_FilterBridge;

	[AccessedThroughProperty("TV_Allocations_ByAttackersOnly")]
	[CompilerGenerated]
	private DarkTreeView _InterpreterBridge;

	[AccessedThroughProperty("Tab_Target_ByAnyone")]
	[CompilerGenerated]
	private TabPage m_ContainerBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Allocations_ByAnyone")]
	private DarkTreeView _ComposerBridge;

	[AccessedThroughProperty("ButtonSelectedWeapon")]
	[CompilerGenerated]
	private DarkUIButton m_AdvisorBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("GB_AllocateToTarget")]
	private DarkGroupBox customerBridge;

	[AccessedThroughProperty("UnitSelection_Targets")]
	[CompilerGenerated]
	private UnitSelection_UC serializerBridge;

	[AccessedThroughProperty("UnitSelection_Attckers")]
	[CompilerGenerated]
	private UnitSelection_UC m_RefBridge;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private Timer m_ErrorBridge;

	[AccessedThroughProperty("Button_UnitWRA")]
	[CompilerGenerated]
	private DarkUIButton codeBridge;

	[AccessedThroughProperty("Button_ClearCourse_Target")]
	[CompilerGenerated]
	private DarkUIButton m_ConnectionBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveWeapons_Target")]
	private DarkUIButton contextBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_PlotCourse_Target")]
	private DarkUIButton _StatusBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("SalvoContextMenu")]
	private DarkContextMenu _ProccesorBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("TSMI_HighAltitudeDetonation")]
	private DarkToolStripMenuItem strategyBridge;

	[AccessedThroughProperty("LV_WarningAndError")]
	[CompilerGenerated]
	private DarkListView m_ConfigurationBridge;

	[AccessedThroughProperty("TabControl2")]
	[CompilerGenerated]
	private DarkUITabControl m_TokenBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("Tab_Attacker_ToAnyone")]
	private TabPage m_PublisherBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Allocations_ToAnyone")]
	private DarkTreeView serverBridge;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_AllowTimeout")]
	private DarkUICheckBox m_AdapterBridge;

	private int? schemaBridge;

	private int utilsBridge;

	private bool _PredicateBridge;

	private bool singletonBridge;

	private string recordBridge;

	private WeaponSalvo exceptionBridge;

	private Keys[] m_AttrBridge;

	[field: AccessedThroughProperty("GB_AttackingUnits")]
	internal DarkGroupBox GB_AttackingUnits
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GB_Targets")]
	internal DarkGroupBox GB_Targets
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_ClearCourse_Attacker
	{
		[CompilerGenerated]
		get
		{
			return m_RequestBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteCode;
			DarkUIButton requestBridge = m_RequestBridge;
			if (requestBridge != null)
			{
				requestBridge.Click -= value2;
			}
			m_RequestBridge = value;
			requestBridge = m_RequestBridge;
			if (requestBridge != null)
			{
				requestBridge.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_PlotCourse_Attacker
	{
		[CompilerGenerated]
		get
		{
			return m_ValueBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveCode;
			DarkUIButton valueBridge = m_ValueBridge;
			if (valueBridge != null)
			{
				valueBridge.Click -= value2;
			}
			m_ValueBridge = value;
			valueBridge = m_ValueBridge;
			if (valueBridge != null)
			{
				valueBridge.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_RemoveWeapons_Attacker
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushError;
			DarkUIButton tokenizerBridge = m_TokenizerBridge;
			if (tokenizerBridge != null)
			{
				tokenizerBridge.Click -= value2;
			}
			m_TokenizerBridge = value;
			tokenizerBridge = m_TokenizerBridge;
			if (tokenizerBridge != null)
			{
				tokenizerBridge.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox_WeaponAllocation")]
	internal DarkGroupBox GroupBox_WeaponAllocation
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkTreeView TV_AvailableWeapons
	{
		[CompilerGenerated]
		get
		{
			return writerBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = CollectError;
			EventHandler value3 = GetCode;
			DarkTreeView darkTreeView = writerBridge;
			if (darkTreeView != null)
			{
				darkTreeView.MouseDoubleClick -= value2;
				darkTreeView.SelectedNodesChanged -= value3;
			}
			writerBridge = value;
			darkTreeView = writerBridge;
			if (darkTreeView != null)
			{
				darkTreeView.MouseDoubleClick += value2;
				darkTreeView.SelectedNodesChanged += value3;
			}
		}
	}

	internal DarkGroupBox GB_WeaponAllocate
	{
		[CompilerGenerated]
		get
		{
			return m_SpecificationBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SpecificationBridge = value;
		}
	}

	internal DarkUIButton Button_AllocateSalvo
	{
		[CompilerGenerated]
		get
		{
			return watcherBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetError;
			DarkUIButton darkUIButton = watcherBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			watcherBridge = value;
			darkUIButton = watcherBridge;
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
			return m_ReponseBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateError;
			DarkUIButton reponseBridge = m_ReponseBridge;
			if (reponseBridge != null)
			{
				reponseBridge.Click -= value2;
			}
			m_ReponseBridge = value;
			reponseBridge = m_ReponseBridge;
			if (reponseBridge != null)
			{
				reponseBridge.Click += value2;
			}
		}
	}

	internal DarkNumericUpDown NUD_NumberOfWeapons
	{
		[CompilerGenerated]
		get
		{
			return m_DescriptorBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DescriptorBridge = value;
		}
	}

	internal DarkUIButton Button_Allocate
	{
		[CompilerGenerated]
		get
		{
			return m_PoolBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortError;
			DarkUIButton poolBridge = m_PoolBridge;
			if (poolBridge != null)
			{
				poolBridge.Click -= value2;
			}
			m_PoolBridge = value;
			poolBridge = m_PoolBridge;
			if (poolBridge != null)
			{
				poolBridge.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("WeaponGroupBox")]
	internal DarkGroupBox WeaponGroupBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITabControl TabControl4
	{
		[CompilerGenerated]
		get
		{
			return m_FilterBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneCode;
			DarkUITabControl filterBridge = m_FilterBridge;
			if (filterBridge != null)
			{
				filterBridge.SelectedIndexChanged -= value2;
			}
			m_FilterBridge = value;
			filterBridge = m_FilterBridge;
			if (filterBridge != null)
			{
				filterBridge.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Tab_Target_BySelected")]
	internal TabPage Tab_Target_BySelected
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkTreeView TV_Allocations_ByAttackersOnly
	{
		[CompilerGenerated]
		get
		{
			return _InterpreterBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = PatchCode;
			MouseEventHandler value3 = WriteCode;
			EventHandler value4 = InvokeCode;
			DarkTreeView interpreterBridge = _InterpreterBridge;
			if (interpreterBridge != null)
			{
				interpreterBridge.MouseClick -= value2;
				interpreterBridge.MouseDoubleClick -= value3;
				interpreterBridge.SelectedNodesChanged -= value4;
			}
			_InterpreterBridge = value;
			interpreterBridge = _InterpreterBridge;
			if (interpreterBridge != null)
			{
				interpreterBridge.MouseClick += value2;
				interpreterBridge.MouseDoubleClick += value3;
				interpreterBridge.SelectedNodesChanged += value4;
			}
		}
	}

	internal TabPage Tab_Target_ByAnyone
	{
		[CompilerGenerated]
		get
		{
			return m_ContainerBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ContainerBridge = value;
		}
	}

	internal DarkTreeView TV_Allocations_ByAnyone
	{
		[CompilerGenerated]
		get
		{
			return _ComposerBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = ComputeCode;
			MouseEventHandler value3 = NewCode;
			EventHandler value4 = ExcludeCode;
			DarkTreeView composerBridge = _ComposerBridge;
			if (composerBridge != null)
			{
				composerBridge.MouseClick -= value2;
				composerBridge.MouseDoubleClick -= value3;
				composerBridge.SelectedNodesChanged -= value4;
			}
			_ComposerBridge = value;
			composerBridge = _ComposerBridge;
			if (composerBridge != null)
			{
				composerBridge.MouseClick += value2;
				composerBridge.MouseDoubleClick += value3;
				composerBridge.SelectedNodesChanged += value4;
			}
		}
	}

	[field: AccessedThroughProperty("GBAttackerAllocateToWeapon")]
	internal DarkGroupBox GBAttackerAllocateToWeapon
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton ButtonSelectedWeapon
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeCode;
			DarkUIButton advisorBridge = m_AdvisorBridge;
			if (advisorBridge != null)
			{
				advisorBridge.Click -= value2;
			}
			m_AdvisorBridge = value;
			advisorBridge = m_AdvisorBridge;
			if (advisorBridge != null)
			{
				advisorBridge.Click += value2;
			}
		}
	}

	internal DarkGroupBox GB_AllocateToTarget
	{
		[CompilerGenerated]
		get
		{
			return customerBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			customerBridge = value;
		}
	}

	internal UnitSelection_UC UnitSelection_Targets
	{
		[CompilerGenerated]
		get
		{
			return serializerBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerBridge = value;
		}
	}

	internal UnitSelection_UC UnitSelection_Attckers
	{
		[CompilerGenerated]
		get
		{
			return m_RefBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RefBridge = value;
		}
	}

	internal DarkUIButton Button_UnitWRA
	{
		[CompilerGenerated]
		get
		{
			return codeBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchCode;
			DarkUIButton darkUIButton = codeBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			codeBridge = value;
			darkUIButton = codeBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_ClearCourse_Target
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyCode;
			DarkUIButton connectionBridge = m_ConnectionBridge;
			if (connectionBridge != null)
			{
				connectionBridge.Click -= value2;
			}
			m_ConnectionBridge = value;
			connectionBridge = m_ConnectionBridge;
			if (connectionBridge != null)
			{
				connectionBridge.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_RemoveWeapons_Target
	{
		[CompilerGenerated]
		get
		{
			return contextBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotError;
			DarkUIButton darkUIButton = contextBridge;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			contextBridge = value;
			darkUIButton = contextBridge;
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
			return _StatusBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddCode;
			DarkUIButton statusBridge = _StatusBridge;
			if (statusBridge != null)
			{
				statusBridge.Click -= value2;
			}
			_StatusBridge = value;
			statusBridge = _StatusBridge;
			if (statusBridge != null)
			{
				statusBridge.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem TSMI_HighAltitudeDetonation
	{
		[CompilerGenerated]
		get
		{
			return strategyBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			strategyBridge = value;
		}
	}

	internal DarkListView LV_WarningAndError
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConfigurationBridge = value;
		}
	}

	internal DarkUITabControl TabControl2
	{
		[CompilerGenerated]
		get
		{
			return m_TokenBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenBridge = value;
		}
	}

	[field: AccessedThroughProperty("Tab_Attacker_ToSelectedOnly")]
	internal TabPage Tab_Attacker_ToSelectedOnly
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TV_Allocations_ToTargetsOnly")]
	internal DarkTreeView TV_Allocations_ToTargetsOnly
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage Tab_Attacker_ToAnyone
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PublisherBridge = value;
		}
	}

	internal DarkTreeView TV_Allocations_ToAnyone
	{
		[CompilerGenerated]
		get
		{
			return serverBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverBridge = value;
		}
	}

	internal DarkUICheckBox CB_AllowTimeout
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterBridge;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdapterBridge = value;
		}
	}

	public List<Module_Unit.Unit> Attackers => UnitSelection_Attckers.StaticUnitList.Keys.ToList();

	public List<Contact> Targets => UnitSelection_Targets.FetchContacts(bool_0: true);

	public List<ActiveUnit> SelectedAttackers => UnitSelection_Attckers.FetchSelectedUnits();

	public List<Contact> SelectedTargets => UnitSelection_Targets.FetchSelectedContact(bool_0: true);

	public Contact SelectedTarget
	{
		get
		{
			List<Contact> selectedTargets = SelectedTargets;
			if (selectedTargets.Count <= 0)
			{
				return null;
			}
			return selectedTargets[0];
		}
	}

	public ActiveUnit SelectedAttacker
	{
		get
		{
			List<ActiveUnit> selectedAttackers = SelectedAttackers;
			if (selectedAttackers.Count <= 0)
			{
				return null;
			}
			return selectedAttackers[0];
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer OrderCode()
	{
		return m_ErrorBridge;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RegisterCode(Timer timer_0)
	{
		EventHandler value = CreateError;
		Timer errorBridge = m_ErrorBridge;
		if (errorBridge != null)
		{
			errorBridge.Tick -= value;
		}
		m_ErrorBridge = timer_0;
		errorBridge = m_ErrorBridge;
		if (errorBridge != null)
		{
			errorBridge.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal DarkContextMenu DestroyConnection()
	{
		return _ProccesorBridge;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ComputeConnection(DarkContextMenu darkContextMenu_0)
	{
		_ProccesorBridge = darkContextMenu_0;
	}

	public AttackTarget_V2()
	{
		base.FormClosing += PopError;
		base.Load += InstantiateError;
		base.KeyDown += RunError;
		singletonBridge = true;
		m_AttrBridge = new Keys[2]
		{
			Keys.F1,
			Keys.Escape
		};
		CalculateError();
		_Initialise();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_BridgeBridge != null)
			{
				m_BridgeBridge.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CalculateError()
	{
		m_BridgeBridge = new Container();
		GroupBox_WeaponAllocation = new DarkGroupBox();
		WeaponGroupBox = new DarkGroupBox();
		LV_WarningAndError = new DarkListView();
		GB_WeaponAllocate = new DarkGroupBox();
		NUD_NumberOfWeapons = new DarkNumericUpDown();
		TV_AvailableWeapons = new DarkTreeView();
		GB_Targets = new DarkGroupBox();
		GB_AllocateToTarget = new DarkGroupBox();
		GB_AttackingUnits = new DarkGroupBox();
		GBAttackerAllocateToWeapon = new DarkGroupBox();
		RegisterCode(new Timer(m_BridgeBridge));
		ComputeConnection(new DarkContextMenu());
		TSMI_HighAltitudeDetonation = new DarkToolStripMenuItem();
		ButtonSelectedWeapon = new DarkUIButton();
		CB_AllowTimeout = new DarkUICheckBox();
		Button_AllocateSalvo = new DarkUIButton();
		Button_AllocateAllWeapons = new DarkUIButton();
		Button_Allocate = new DarkUIButton();
		UnitSelection_Targets = new UnitSelection_UC();
		Button_ClearCourse_Target = new DarkUIButton();
		Button_RemoveWeapons_Target = new DarkUIButton();
		Button_PlotCourse_Target = new DarkUIButton();
		TabControl4 = new DarkUITabControl();
		Tab_Target_BySelected = new TabPage();
		TV_Allocations_ByAttackersOnly = new DarkTreeView();
		Tab_Target_ByAnyone = new TabPage();
		TV_Allocations_ByAnyone = new DarkTreeView();
		Button_UnitWRA = new DarkUIButton();
		UnitSelection_Attckers = new UnitSelection_UC();
		TabControl2 = new DarkUITabControl();
		Tab_Attacker_ToSelectedOnly = new TabPage();
		TV_Allocations_ToTargetsOnly = new DarkTreeView();
		Tab_Attacker_ToAnyone = new TabPage();
		TV_Allocations_ToAnyone = new DarkTreeView();
		Button_PlotCourse_Attacker = new DarkUIButton();
		Button_ClearCourse_Attacker = new DarkUIButton();
		Button_RemoveWeapons_Attacker = new DarkUIButton();
		GroupBox_WeaponAllocation.SuspendLayout();
		WeaponGroupBox.SuspendLayout();
		GB_WeaponAllocate.SuspendLayout();
		((ISupportInitialize)NUD_NumberOfWeapons).BeginInit();
		GB_Targets.SuspendLayout();
		GB_AllocateToTarget.SuspendLayout();
		GB_AttackingUnits.SuspendLayout();
		GBAttackerAllocateToWeapon.SuspendLayout();
		DestroyConnection().SuspendLayout();
		TabControl4.SuspendLayout();
		Tab_Target_BySelected.SuspendLayout();
		Tab_Target_ByAnyone.SuspendLayout();
		TabControl2.SuspendLayout();
		Tab_Attacker_ToSelectedOnly.SuspendLayout();
		Tab_Attacker_ToAnyone.SuspendLayout();
		SuspendLayout();
		GroupBox_WeaponAllocation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox_WeaponAllocation.Controls.Add(WeaponGroupBox);
		GroupBox_WeaponAllocation.Controls.Add(TV_AvailableWeapons);
		GroupBox_WeaponAllocation.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox_WeaponAllocation.Location = new Point(580, 12);
		GroupBox_WeaponAllocation.Name = "GroupBox_WeaponAllocation";
		GroupBox_WeaponAllocation.Size = new Size(418, 652);
		GroupBox_WeaponAllocation.TabIndex = 4;
		GroupBox_WeaponAllocation.TabStop = false;
		GroupBox_WeaponAllocation.Text = "武器分配";
		WeaponGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		WeaponGroupBox.Controls.Add(LV_WarningAndError);
		WeaponGroupBox.Controls.Add(ButtonSelectedWeapon);
		WeaponGroupBox.Controls.Add(GB_WeaponAllocate);
		WeaponGroupBox.ForeColor = Color.FromArgb(220, 220, 220);
		WeaponGroupBox.Location = new Point(7, 358);
		WeaponGroupBox.Name = "WeaponGroupBox";
		WeaponGroupBox.Size = new Size(405, 282);
		WeaponGroupBox.TabIndex = 20;
		WeaponGroupBox.TabStop = false;
		LV_WarningAndError.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		LV_WarningAndError.Location = new Point(10, 26);
		LV_WarningAndError.Name = "LV_WarningAndError";
		LV_WarningAndError.RelatedInfos = null;
		LV_WarningAndError.Size = new Size(384, 119);
		LV_WarningAndError.TabIndex = 25;
		LV_WarningAndError.Text = "LV_WarningAndError";
		GB_WeaponAllocate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GB_WeaponAllocate.Controls.Add(CB_AllowTimeout);
		GB_WeaponAllocate.Controls.Add(Button_AllocateSalvo);
		GB_WeaponAllocate.Controls.Add(Button_AllocateAllWeapons);
		GB_WeaponAllocate.Controls.Add(NUD_NumberOfWeapons);
		GB_WeaponAllocate.Controls.Add(Button_Allocate);
		GB_WeaponAllocate.ForeColor = Color.FromArgb(220, 220, 220);
		GB_WeaponAllocate.Location = new Point(10, 151);
		GB_WeaponAllocate.Name = "GB_WeaponAllocate";
		GB_WeaponAllocate.Size = new Size(384, 124);
		GB_WeaponAllocate.TabIndex = 4;
		GB_WeaponAllocate.TabStop = false;
		GB_WeaponAllocate.Text = "Allocate";
		NUD_NumberOfWeapons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		NUD_NumberOfWeapons.BackColor = Color.FromArgb(69, 73, 74);
		NUD_NumberOfWeapons.BorderStyle = BorderStyle.FixedSingle;
		NUD_NumberOfWeapons.Font = new Font("Segoe UI", 10f);
		NUD_NumberOfWeapons.ForeColor = Color.FromArgb(220, 220, 220);
		NUD_NumberOfWeapons.Location = new Point(295, 18);
		NUD_NumberOfWeapons.Name = "NUD_NumberOfWeapons";
		NUD_NumberOfWeapons.Size = new Size(68, 25);
		NUD_NumberOfWeapons.TabIndex = 17;
		TV_AvailableWeapons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TV_AvailableWeapons.BackColor = Color.FromArgb(44, 44, 44);
		TV_AvailableWeapons.Font = new Font("Segoe UI", 9f);
		TV_AvailableWeapons.ForeColor = Color.Gainsboro;
		TV_AvailableWeapons.Location = new Point(6, 19);
		TV_AvailableWeapons.MaxDragChange = 20;
		TV_AvailableWeapons.Name = "TV_AvailableWeapons";
		TV_AvailableWeapons.Size = new Size(405, 333);
		TV_AvailableWeapons.TabIndex = 5;
		GB_Targets.Controls.Add(UnitSelection_Targets);
		GB_Targets.Controls.Add(GB_AllocateToTarget);
		GB_Targets.ForeColor = Color.FromArgb(220, 220, 220);
		GB_Targets.Location = new Point(10, 339);
		GB_Targets.Name = "GB_Targets";
		GB_Targets.Size = new Size(564, 325);
		GB_Targets.TabIndex = 4;
		GB_Targets.TabStop = false;
		GB_Targets.Text = "Targets";
		GB_AllocateToTarget.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GB_AllocateToTarget.Controls.Add(Button_ClearCourse_Target);
		GB_AllocateToTarget.Controls.Add(Button_RemoveWeapons_Target);
		GB_AllocateToTarget.Controls.Add(Button_PlotCourse_Target);
		GB_AllocateToTarget.Controls.Add(TabControl4);
		GB_AllocateToTarget.ForeColor = Color.FromArgb(220, 220, 220);
		GB_AllocateToTarget.Location = new Point(249, 0);
		GB_AllocateToTarget.Name = "GB_AllocateToTarget";
		GB_AllocateToTarget.Size = new Size(315, 325);
		GB_AllocateToTarget.TabIndex = 6;
		GB_AllocateToTarget.TabStop = false;
		GB_AllocateToTarget.Text = "Weapon(s) Allocated to Target(s)";
		GB_AttackingUnits.Controls.Add(Button_UnitWRA);
		GB_AttackingUnits.Controls.Add(UnitSelection_Attckers);
		GB_AttackingUnits.Controls.Add(GBAttackerAllocateToWeapon);
		GB_AttackingUnits.ForeColor = Color.FromArgb(220, 220, 220);
		GB_AttackingUnits.Location = new Point(10, 12);
		GB_AttackingUnits.Name = "GB_AttackingUnits";
		GB_AttackingUnits.Size = new Size(564, 321);
		GB_AttackingUnits.TabIndex = 3;
		GB_AttackingUnits.TabStop = false;
		GB_AttackingUnits.Text = "Attacking Units";
		GBAttackerAllocateToWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GBAttackerAllocateToWeapon.Controls.Add(TabControl2);
		GBAttackerAllocateToWeapon.Controls.Add(Button_PlotCourse_Attacker);
		GBAttackerAllocateToWeapon.Controls.Add(Button_ClearCourse_Attacker);
		GBAttackerAllocateToWeapon.Controls.Add(Button_RemoveWeapons_Attacker);
		GBAttackerAllocateToWeapon.ForeColor = Color.FromArgb(220, 220, 220);
		GBAttackerAllocateToWeapon.Location = new Point(251, 0);
		GBAttackerAllocateToWeapon.Name = "GBAttackerAllocateToWeapon";
		GBAttackerAllocateToWeapon.Size = new Size(313, 321);
		GBAttackerAllocateToWeapon.TabIndex = 5;
		GBAttackerAllocateToWeapon.TabStop = false;
		GBAttackerAllocateToWeapon.Text = "Attacker's Allocated Weapon(s)";
		DestroyConnection().BackColor = Color.FromArgb(60, 63, 65);
		DestroyConnection().ForeColor = Color.FromArgb(220, 220, 220);
		DestroyConnection().Items.AddRange(new ToolStripItem[1] { TSMI_HighAltitudeDetonation });
		DestroyConnection().Name = "ContextMenuStrip1";
		DestroyConnection().Size = new Size(251, 26);
		TSMI_HighAltitudeDetonation.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_HighAltitudeDetonation.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_HighAltitudeDetonation.Name = "TSMI_HighAltitudeDetonation";
		TSMI_HighAltitudeDetonation.Size = new Size(250, 22);
		TSMI_HighAltitudeDetonation.Text = "特别：高海拔爆炸";
		ButtonSelectedWeapon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		ButtonSelectedWeapon.BackColor = Color.Transparent;
		ButtonSelectedWeapon.DialogResult = DialogResult.None;
		ButtonSelectedWeapon.Font = new Font("Segoe UI", 10f);
		ButtonSelectedWeapon.ForeColor = SystemColors.Control;
		ButtonSelectedWeapon.Location = new Point(39, 0);
		ButtonSelectedWeapon.Name = "ButtonSelectedWeapon";
		ButtonSelectedWeapon.RoundRadius = 0;
		ButtonSelectedWeapon.Size = new Size(321, 20);
		ButtonSelectedWeapon.TabIndex = 20;
		ButtonSelectedWeapon.Text = "---";
		CB_AllowTimeout.BackColor = Color.Transparent;
		CB_AllowTimeout.Checked = false;
		CB_AllowTimeout.Cursor = Cursors.Hand;
		CB_AllowTimeout.ForeColor = Color.FromArgb(209, 209, 209);
		CB_AllowTimeout.Location = new Point(20, 94);
		CB_AllowTimeout.Name = "CB_AllowTimeout";
		CB_AllowTimeout.Size = new Size(314, 18);
		CB_AllowTimeout.TabIndex = 19;
		CB_AllowTimeout.Text = "允许自动齐射超时";
		Button_AllocateSalvo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Button_AllocateSalvo.BackColor = Color.Transparent;
		Button_AllocateSalvo.DialogResult = DialogResult.None;
		Button_AllocateSalvo.Font = new Font("Segoe UI", 10f);
		Button_AllocateSalvo.ForeColor = SystemColors.Control;
		Button_AllocateSalvo.Location = new Point(20, 48);
		Button_AllocateSalvo.Name = "Button_AllocateSalvo";
		Button_AllocateSalvo.RoundRadius = 0;
		Button_AllocateSalvo.Size = new Size(343, 18);
		Button_AllocateSalvo.TabIndex = 18;
		Button_AllocateSalvo.Text = "One salvo";
		Button_AllocateAllWeapons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Button_AllocateAllWeapons.BackColor = Color.Transparent;
		Button_AllocateAllWeapons.DialogResult = DialogResult.None;
		Button_AllocateAllWeapons.Font = new Font("Segoe UI", 10f);
		Button_AllocateAllWeapons.ForeColor = SystemColors.Control;
		Button_AllocateAllWeapons.Location = new Point(20, 70);
		Button_AllocateAllWeapons.Name = "Button_AllocateAllWeapons";
		Button_AllocateAllWeapons.RoundRadius = 0;
		Button_AllocateAllWeapons.Size = new Size(343, 18);
		Button_AllocateAllWeapons.TabIndex = 16;
		Button_AllocateAllWeapons.Text = "所有武器";
		Button_Allocate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Button_Allocate.BackColor = Color.Transparent;
		Button_Allocate.DialogResult = DialogResult.None;
		Button_Allocate.Font = new Font("Segoe UI", 10f);
		Button_Allocate.ForeColor = SystemColors.Control;
		Button_Allocate.Location = new Point(20, 18);
		Button_Allocate.Name = "Button_Allocate";
		Button_Allocate.RoundRadius = 0;
		Button_Allocate.Size = new Size(269, 26);
		Button_Allocate.TabIndex = 15;
		Button_Allocate.Text = "Weapons #";
		UnitSelection_Targets.BackColor = Color.FromArgb(60, 63, 65);
		UnitSelection_Targets.Location = new Point(6, 22);
		UnitSelection_Targets.Mode = E_UnitSelectionMode.Fetch;
		UnitSelection_Targets.Name = "UnitSelection_Targets";
		UnitSelection_Targets.Size = new Size(239, 293);
		UnitSelection_Targets.TabIndex = 7;
		Button_ClearCourse_Target.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ClearCourse_Target.BackColor = Color.Transparent;
		Button_ClearCourse_Target.DialogResult = DialogResult.None;
		Button_ClearCourse_Target.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ClearCourse_Target.ForeColor = SystemColors.Control;
		Button_ClearCourse_Target.Location = new Point(98, 290);
		Button_ClearCourse_Target.Name = "Button_ClearCourse_Target";
		Button_ClearCourse_Target.RoundRadius = 0;
		Button_ClearCourse_Target.Size = new Size(76, 20);
		Button_ClearCourse_Target.TabIndex = 22;
		Button_ClearCourse_Target.Text = "明确的做法";
		Button_RemoveWeapons_Target.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_RemoveWeapons_Target.BackColor = Color.Transparent;
		Button_RemoveWeapons_Target.DialogResult = DialogResult.None;
		Button_RemoveWeapons_Target.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_RemoveWeapons_Target.ForeColor = SystemColors.Control;
		Button_RemoveWeapons_Target.Location = new Point(188, 290);
		Button_RemoveWeapons_Target.Name = "Button_RemoveWeapons_Target";
		Button_RemoveWeapons_Target.RoundRadius = 0;
		Button_RemoveWeapons_Target.Size = new Size(112, 20);
		Button_RemoveWeapons_Target.TabIndex = 20;
		Button_RemoveWeapons_Target.Text = "取消分配已选中";
		Button_PlotCourse_Target.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_PlotCourse_Target.BackColor = Color.Transparent;
		Button_PlotCourse_Target.DialogResult = DialogResult.None;
		Button_PlotCourse_Target.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_PlotCourse_Target.ForeColor = SystemColors.Control;
		Button_PlotCourse_Target.Location = new Point(16, 290);
		Button_PlotCourse_Target.Name = "Button_PlotCourse_Target";
		Button_PlotCourse_Target.RoundRadius = 0;
		Button_PlotCourse_Target.Size = new Size(76, 20);
		Button_PlotCourse_Target.TabIndex = 21;
		Button_PlotCourse_Target.Text = "规划路径";
		TabControl4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl4.Controls.Add(Tab_Target_BySelected);
		TabControl4.Controls.Add(Tab_Target_ByAnyone);
		TabControl4.Cursor = Cursors.Hand;
		TabControl4.Font = new Font("Segoe UI", 10f);
		TabControl4.ItemSize = new Size(80, 20);
		TabControl4.Location = new Point(16, 22);
		TabControl4.Name = "TabControl4";
		TabControl4.SelectedIndex = 0;
		TabControl4.Size = new Size(284, 262);
		TabControl4.TabIndex = 6;
		Tab_Target_BySelected.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Target_BySelected.Controls.Add(TV_Allocations_ByAttackersOnly);
		Tab_Target_BySelected.Location = new Point(4, 24);
		Tab_Target_BySelected.Name = "Tab_Target_BySelected";
		Tab_Target_BySelected.Padding = new Padding(3);
		Tab_Target_BySelected.Size = new Size(276, 234);
		Tab_Target_BySelected.TabIndex = 0;
		Tab_Target_BySelected.Text = "Selected attacker(s)";
		TV_Allocations_ByAttackersOnly.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ByAttackersOnly.Dock = DockStyle.Fill;
		TV_Allocations_ByAttackersOnly.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ByAttackersOnly.Location = new Point(3, 3);
		TV_Allocations_ByAttackersOnly.MaxDragChange = 20;
		TV_Allocations_ByAttackersOnly.Name = "TV_Allocations_ByAttackersOnly";
		TV_Allocations_ByAttackersOnly.Size = new Size(270, 228);
		TV_Allocations_ByAttackersOnly.TabIndex = 6;
		Tab_Target_ByAnyone.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Target_ByAnyone.Controls.Add(TV_Allocations_ByAnyone);
		Tab_Target_ByAnyone.Location = new Point(4, 24);
		Tab_Target_ByAnyone.Name = "Tab_Target_ByAnyone";
		Tab_Target_ByAnyone.Padding = new Padding(3);
		Tab_Target_ByAnyone.Size = new Size(276, 234);
		Tab_Target_ByAnyone.TabIndex = 1;
		Tab_Target_ByAnyone.Text = "Anyone";
		TV_Allocations_ByAnyone.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ByAnyone.Dock = DockStyle.Fill;
		TV_Allocations_ByAnyone.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ByAnyone.Location = new Point(3, 3);
		TV_Allocations_ByAnyone.MaxDragChange = 20;
		TV_Allocations_ByAnyone.Name = "TV_Allocations_ByAnyone";
		TV_Allocations_ByAnyone.Size = new Size(270, 228);
		TV_Allocations_ByAnyone.TabIndex = 7;
		Button_UnitWRA.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_UnitWRA.BackColor = Color.Transparent;
		Button_UnitWRA.DialogResult = DialogResult.None;
		Button_UnitWRA.Font = new Font("Segoe UI", 10f);
		Button_UnitWRA.ForeColor = SystemColors.Control;
		Button_UnitWRA.Location = new Point(183, 0);
		Button_UnitWRA.Name = "Button_UnitWRA";
		Button_UnitWRA.RoundRadius = 0;
		Button_UnitWRA.Size = new Size(62, 16);
		Button_UnitWRA.TabIndex = 9;
		Button_UnitWRA.Text = "WRA";
		UnitSelection_Attckers.BackColor = Color.FromArgb(60, 63, 65);
		UnitSelection_Attckers.Location = new Point(6, 22);
		UnitSelection_Attckers.Mode = E_UnitSelectionMode.Fetch;
		UnitSelection_Attckers.Name = "UnitSelection_Attckers";
		UnitSelection_Attckers.Size = new Size(241, 293);
		UnitSelection_Attckers.TabIndex = 6;
		TabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl2.Controls.Add(Tab_Attacker_ToSelectedOnly);
		TabControl2.Controls.Add(Tab_Attacker_ToAnyone);
		TabControl2.Cursor = Cursors.Hand;
		TabControl2.Font = new Font("Segoe UI", 10f);
		TabControl2.ItemSize = new Size(80, 20);
		TabControl2.Location = new Point(16, 22);
		TabControl2.Name = "TabControl2";
		TabControl2.SelectedIndex = 0;
		TabControl2.Size = new Size(282, 263);
		TabControl2.TabIndex = 18;
		Tab_Attacker_ToSelectedOnly.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Attacker_ToSelectedOnly.Controls.Add(TV_Allocations_ToTargetsOnly);
		Tab_Attacker_ToSelectedOnly.Location = new Point(4, 24);
		Tab_Attacker_ToSelectedOnly.Name = "Tab_Attacker_ToSelectedOnly";
		Tab_Attacker_ToSelectedOnly.Padding = new Padding(3);
		Tab_Attacker_ToSelectedOnly.Size = new Size(274, 235);
		Tab_Attacker_ToSelectedOnly.TabIndex = 0;
		Tab_Attacker_ToSelectedOnly.Text = "仅限选定目标";
		TV_Allocations_ToTargetsOnly.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ToTargetsOnly.Dock = DockStyle.Fill;
		TV_Allocations_ToTargetsOnly.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ToTargetsOnly.Location = new Point(3, 3);
		TV_Allocations_ToTargetsOnly.MaxDragChange = 20;
		TV_Allocations_ToTargetsOnly.Name = "TV_Allocations_ToTargetsOnly";
		TV_Allocations_ToTargetsOnly.Size = new Size(268, 229);
		TV_Allocations_ToTargetsOnly.TabIndex = 5;
		Tab_Attacker_ToAnyone.BackColor = Color.FromArgb(60, 63, 65);
		Tab_Attacker_ToAnyone.Controls.Add(TV_Allocations_ToAnyone);
		Tab_Attacker_ToAnyone.Location = new Point(4, 24);
		Tab_Attacker_ToAnyone.Name = "Tab_Attacker_ToAnyone";
		Tab_Attacker_ToAnyone.Padding = new Padding(3);
		Tab_Attacker_ToAnyone.Size = new Size(274, 235);
		Tab_Attacker_ToAnyone.TabIndex = 1;
		Tab_Attacker_ToAnyone.Text = "对任何人";
		TV_Allocations_ToAnyone.BackColor = Color.FromArgb(60, 63, 65);
		TV_Allocations_ToAnyone.Dock = DockStyle.Fill;
		TV_Allocations_ToAnyone.Font = new Font("Segoe UI", 9f);
		TV_Allocations_ToAnyone.Location = new Point(3, 3);
		TV_Allocations_ToAnyone.MaxDragChange = 20;
		TV_Allocations_ToAnyone.Name = "TV_Allocations_ToAnyone";
		TV_Allocations_ToAnyone.Size = new Size(268, 229);
		TV_Allocations_ToAnyone.TabIndex = 6;
		Button_PlotCourse_Attacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_PlotCourse_Attacker.BackColor = Color.Transparent;
		Button_PlotCourse_Attacker.DialogResult = DialogResult.None;
		Button_PlotCourse_Attacker.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_PlotCourse_Attacker.ForeColor = SystemColors.Control;
		Button_PlotCourse_Attacker.Location = new Point(16, 291);
		Button_PlotCourse_Attacker.Name = "Button_PlotCourse_Attacker";
		Button_PlotCourse_Attacker.RoundRadius = 0;
		Button_PlotCourse_Attacker.Size = new Size(76, 20);
		Button_PlotCourse_Attacker.TabIndex = 16;
		Button_PlotCourse_Attacker.Text = "规划路径";
		Button_ClearCourse_Attacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ClearCourse_Attacker.BackColor = Color.Transparent;
		Button_ClearCourse_Attacker.DialogResult = DialogResult.None;
		Button_ClearCourse_Attacker.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_ClearCourse_Attacker.ForeColor = SystemColors.Control;
		Button_ClearCourse_Attacker.Location = new Point(98, 291);
		Button_ClearCourse_Attacker.Name = "Button_ClearCourse_Attacker";
		Button_ClearCourse_Attacker.RoundRadius = 0;
		Button_ClearCourse_Attacker.Size = new Size(76, 20);
		Button_ClearCourse_Attacker.TabIndex = 17;
		Button_ClearCourse_Attacker.Text = "明确的做法";
		Button_RemoveWeapons_Attacker.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_RemoveWeapons_Attacker.BackColor = Color.Transparent;
		Button_RemoveWeapons_Attacker.DialogResult = DialogResult.None;
		Button_RemoveWeapons_Attacker.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button_RemoveWeapons_Attacker.ForeColor = SystemColors.Control;
		Button_RemoveWeapons_Attacker.Location = new Point(186, 291);
		Button_RemoveWeapons_Attacker.Name = "Button_RemoveWeapons_Attacker";
		Button_RemoveWeapons_Attacker.RoundRadius = 0;
		Button_RemoveWeapons_Attacker.Size = new Size(112, 20);
		Button_RemoveWeapons_Attacker.TabIndex = 15;
		Button_RemoveWeapons_Attacker.Text = "取消分配已选中";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(64, 64, 64);
		base.ClientSize = new Size(1010, 675);
		base.Controls.Add(GroupBox_WeaponAllocation);
		base.Controls.Add(GB_Targets);
		base.Controls.Add(GB_AttackingUnits);
		MinimumSize = new Size(880, 714);
		base.Name = "AttackTarget_V2";
		Text = "Attack Target (V2)";
		GroupBox_WeaponAllocation.ResumeLayout(performLayout: false);
		WeaponGroupBox.ResumeLayout(performLayout: false);
		GB_WeaponAllocate.ResumeLayout(performLayout: false);
		((ISupportInitialize)NUD_NumberOfWeapons).EndInit();
		GB_Targets.ResumeLayout(performLayout: false);
		GB_AllocateToTarget.ResumeLayout(performLayout: false);
		GB_AttackingUnits.ResumeLayout(performLayout: false);
		GBAttackerAllocateToWeapon.ResumeLayout(performLayout: false);
		DestroyConnection().ResumeLayout(performLayout: false);
		TabControl4.ResumeLayout(performLayout: false);
		Tab_Target_BySelected.ResumeLayout(performLayout: false);
		Tab_Target_ByAnyone.ResumeLayout(performLayout: false);
		TabControl2.ResumeLayout(performLayout: false);
		Tab_Attacker_ToSelectedOnly.ResumeLayout(performLayout: false);
		Tab_Attacker_ToAnyone.ResumeLayout(performLayout: false);
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
			SelectedAttackers.Clear();
			SelectedTargets.Clear();
			exceptionBridge = null;
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

	private void PopError(object sender, FormClosingEventArgs e)
	{
		if (_PredicateBridge && Client.CurrentUserAction != Client.UserAction.PlottingCourseForSalvo)
		{
			Client.CurrentGame.Run();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.WorldWindow1.Focus();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] attrBridge = m_AttrBridge;
		int num = 0;
		while (true)
		{
			if (num < attrBridge.Length)
			{
				Keys keys = attrBridge[num];
				if (keyData == keys)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
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

	public void _Initialise()
	{
		_PredicateBridge = Client.CurrentGame.Status == Game._GameStatus.Running;
		if (_PredicateBridge)
		{
			Client.CurrentGame.Pause();
		}
		UnitSelection_Targets.Mode = E_UnitSelectionMode.Assign;
		UnitSelection_Attckers.Mode = E_UnitSelectionMode.Assign;
		UnitSelection_Attckers.Initialise(UnitSelection.UnitSelectionConfig.DefaultUnitSelection(true), new List<ActiveUnit>(), new List<Side>());
		UnitSelection_Targets.Initialise(UnitSelection.UnitSelectionConfig.DefaultUnitSelection(true), new List<ActiveUnit>(), new List<Side>());
		UnitSelection_Attckers.LV_Units.SelectedIndicesChanged += ListError;
		UnitSelection_Targets.LV_Units.SelectedIndicesChanged += ResolveError;
		UnitSelection_Attckers.Button_AddSelected.Click += DefineError;
		UnitSelection_Targets.Button_AddSelected.Click += AwakeError;
		UnitSelection_Attckers.Button_Action_Delete.Click += PublishError;
		UnitSelection_Targets.Button_Action_Delete.Click += QueryError;
		ListAttackers();
		ListTargets();
		if (SelectedTargets.Count > 0 && SelectedAttackers.Count > 0 && TV_AvailableWeapons.Nodes.Count > 0)
		{
			singletonBridge = false;
			TV_AvailableWeapons.SelectNode(TV_AvailableWeapons.Nodes[0]);
			TV_AvailableWeapons.Select();
			singletonBridge = true;
		}
		singletonBridge = false;
		CB_AllowTimeout.Checked = SimConfiguration.DefaultGamePreferences.SalvoTimeout;
		singletonBridge = true;
		new ToolTip().SetToolTip(CB_AllowTimeout, "Enable automatic salvo cancellation when last weapon in first volley impacts, or after 40 seconds if weapons cannot be fired. Note! Disabling salvo cancellation will not drop salvos until all weapons have been fired, and may prevent other units from automatically firing at a contact should it move out of firing parameters!");
	}

	public void LoadForm()
	{
		_Initialise();
	}

	public void RefreshForm()
	{
		if (base.IsDisposed)
		{
			return;
		}
		try
		{
			AssetError();
			RestartError();
			ReadError();
			ListAttackers();
			ListTargets();
			PrintError();
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

	public void AddTarget(Contact contact_0)
	{
		UnitSelection_Targets.AddUnit(contact_0);
	}

	public void AddAttacker(ActiveUnit activeUnit_0)
	{
		UnitSelection_Attckers.AddUnit(activeUnit_0);
	}

	public void RemoveTarget(Contact contact_0)
	{
		UnitSelection_Targets.RemoveUnit(contact_0);
	}

	public void RemoveAttacker(ActiveUnit activeUnit_0)
	{
		UnitSelection_Attckers.RemoveUnit(activeUnit_0);
	}

	private void InstantiateError(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		OrderCode().Interval = 1000;
		OrderCode().Start();
		base.TopMost = true;
		LoadForm();
	}

	private void CreateError(object sender, EventArgs e)
	{
	}

	private void CompareError()
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

	private void ReadError()
	{
		OrderError();
		if (TabControl2.SelectedIndex == 0)
		{
			DisableError();
		}
		else
		{
			UpdateError();
		}
		if (TabControl4.SelectedIndex == 0)
		{
			InsertError();
		}
		else
		{
			PrepareError();
		}
		CompareError();
	}

	public void ListAttackers()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		List<Module_Unit.Unit> list3 = Attackers.OrderBy((Module_Unit.Unit theAu) => theAu.Name).ToList();
		foreach (ActiveUnit item in list3)
		{
			if (!item.IsGroup)
			{
				continue;
			}
			foreach (ActiveUnit value in ((Group)item).Units.Values)
			{
				Side currentSide = Client.CurrentSide;
				string string_ = null;
				if (GameGeneral.CanIssueOrdersToThisUnit(currentSide, value, bool_1: false, ref string_, Client.CurrentMapProfile.String_0) && !list3.Contains(value))
				{
					list.Add(value);
				}
			}
			list2.Add(item);
		}
		foreach (ActiveUnit item2 in list2)
		{
			list3.Remove(item2);
		}
		foreach (ActiveUnit item3 in list)
		{
			list3.Add(item3);
		}
		UnitSelection_Attckers.RefreshUnitList(list3);
	}

	public void ListTargets()
	{
		List<Contact> list = Targets.OrderBy((Contact theC) => theC.Name).ToList();
		Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)> dictionary = new Dictionary<Module_Unit.Unit, (Module_Unit.Unit, string)>();
		string text = null;
		foreach (Contact item2 in list)
		{
			string item = "";
			if (item2.IncludeImporter(Client.CurrentSide).Count > 0)
			{
				Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
				foreach (Contact.HostedUnitReconRecord item3 in item2.IncludeImporter(Client.CurrentSide))
				{
					switch (item3.IDStatus)
					{
					case Contact_Base.IdentificationStatus.Unknown:
						text = "未知单元";
						break;
					case Contact_Base.IdentificationStatus.KnownDomain:
						try
						{
							ActiveUnit activeUnit2 = Client.CurrentScenario.ActiveUnits[item3.UnitID];
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
							ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[item3.UnitID];
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
							text = Client.CurrentScenario.ActiveUnits[item3.UnitID].UnitClass;
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
							text = Client.CurrentScenario.ActiveUnits[item3.UnitID].Name;
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
					text = text + "（最后一次侦察：" + Conversions.ToString(Interaction.IIf(item3.ReconAge > 0f, Misc.UpdateRequest((long)Math.Round(item3.ReconAge), Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable, bool_0: false, bool_1: true) + "前）", "Now)"));
					if (dictionary2.ContainsKey(text))
					{
						dictionary2[text]++;
					}
					else
					{
						dictionary2.Add(text, 1);
					}
				}
				List<string> list2 = new List<string>();
				foreach (KeyValuePair<string, int> item4 in dictionary2)
				{
					list2.Add(Conversions.ToString(item4.Value) + "x " + item4.Key);
				}
				item = " - " + string.Join(" - ", list2);
			}
			dictionary.Add(item2, (item2, item));
		}
		UnitSelection_Targets.RefreshUnitList(dictionary);
	}

	private void DisableError()
	{
		TV_Allocations_ToTargetsOnly.Nodes.Clear();
		if (SelectedAttackers.Count == 0 || SelectedTargets.Count != 1)
		{
			return;
		}
		foreach (ActiveUnit selectedAttacker in SelectedAttackers)
		{
			ActiveUnit activeUnit_ = selectedAttacker;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ToTargetsOnly.Nodes.Add(darkTreeNode);
			Side unitSide = activeUnit_.GetUnitSide();
			Contact contact_ = SelectedTarget;
			foreach (WeaponSalvo item in unitSide.WeaponSalvosFromThisUnitToThisTarget(ref activeUnit_, ref contact_))
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
						DarkTreeNode darkTreeNode2 = new DarkTreeNode();
						recordBridge = "";
						if (item.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
						{
							recordBridge += "[HIGH ALT]";
						}
						if (item.PlottedCourse.Count() > 0)
						{
							ref string reference = ref recordBridge;
							reference = reference + "[" + Conversions.ToString(item.PlottedCourse.Count()) + "航段]";
						}
						darkTreeNode2.Text = "Alloc: " + recordBridge + " " + text + item.GetReferenceWeapon(activeUnit_.ParentScen).Name;
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
	}

	private void UpdateError()
	{
		TV_Allocations_ToAnyone.Nodes.Clear();
		if (SelectedAttackers.Count == 0)
		{
			return;
		}
		foreach (ActiveUnit selectedAttacker in SelectedAttackers)
		{
			ActiveUnit activeUnit_ = selectedAttacker;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ToAnyone.Nodes.Add(darkTreeNode);
			foreach (WeaponSalvo item in activeUnit_.GetUnitSide().WeaponSalvosFromThisUnitToAnyTarget(ref activeUnit_))
			{
				WeaponSalvo.Shooter[] shootersList = item.ShootersList;
				WeaponSalvo.Shooter[] array = shootersList;
				foreach (WeaponSalvo.Shooter shooter in array)
				{
					if (Operators.CompareString(activeUnit_.ObjectID, shooter.ShooterObjectID, TextCompare: true) == 0)
					{
						if (shooter.QuantityAssigned - shooter.QuantityFired > 0)
						{
							string text = ((shooter.QuantityAssigned <= 2147473647) ? (Conversions.ToString(shooter.QuantityAssigned - shooter.QuantityFired) + "x ") : "所有武器");
							DarkTreeNode darkTreeNode2 = new DarkTreeNode();
							darkTreeNode2.Text = (item.ManualFire ? "*" : "") + "分配给" + item.Target.Name + ": " + text + item.GetReferenceWeapon(activeUnit_.ParentScen).Name;
							darkTreeNode2.Tag = item;
							darkTreeNode.Nodes.Add(darkTreeNode2);
						}
						if (shooter.QuantityFired > 0)
						{
							DarkTreeNode darkTreeNode3 = new DarkTreeNode();
							darkTreeNode3.Text = "攻击了" + item.Target.Name + ": " + Conversions.ToString(shooter.QuantityFired) + "x " + item.GetReferenceWeapon(activeUnit_.ParentScen).Name;
							darkTreeNode.Nodes.Add(darkTreeNode3);
						}
					}
				}
			}
			darkTreeNode.Expanded = true;
		}
	}

	private void InsertError()
	{
		TV_Allocations_ByAttackersOnly.Nodes.Clear();
		if (SelectedAttackers.Count == 0 || SelectedTargets.Count != 1)
		{
			return;
		}
		foreach (ActiveUnit selectedAttacker in SelectedAttackers)
		{
			ActiveUnit activeUnit_ = selectedAttacker;
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ByAttackersOnly.Nodes.Add(darkTreeNode);
			Side unitSide = activeUnit_.GetUnitSide();
			Contact contact_ = SelectedTarget;
			foreach (WeaponSalvo item in unitSide.WeaponSalvosFromThisUnitToThisTarget(ref activeUnit_, ref contact_))
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
						recordBridge = "";
						if (item.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
						{
							recordBridge += "[HIGH ALT]";
						}
						if (item.PlottedCourse.Count() > 0)
						{
							ref string reference = ref recordBridge;
							reference = reference + "[" + Conversions.ToString(item.PlottedCourse.Count()) + "航段]";
						}
						DarkTreeNode darkTreeNode2 = new DarkTreeNode();
						darkTreeNode2.Text = "Alloc: " + recordBridge + text + item.GetReferenceWeapon(activeUnit_.ParentScen).Name;
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
	}

	private void PrepareError()
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
			Contact contact_ = SelectedTarget;
			List<WeaponSalvo> list = unitSide.WeaponSalvosFromThisUnitToThisTarget(ref activeUnit_, ref contact_);
			if (list.Count <= 0)
			{
				continue;
			}
			DarkTreeNode darkTreeNode = new DarkTreeNode();
			darkTreeNode.Text = "通过：" + activeUnit_.Name;
			darkTreeNode.Tag = activeUnit_;
			TV_Allocations_ByAnyone.Nodes.Add(darkTreeNode);
			foreach (WeaponSalvo item in list)
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
						recordBridge = "";
						if (item.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation)
						{
							recordBridge += "[HIGH ALT]";
						}
						if (item.PlottedCourse.Count() > 0)
						{
							ref string reference = ref recordBridge;
							reference = reference + "[" + Conversions.ToString(item.PlottedCourse.Count()) + "航段]";
						}
						DarkTreeNode darkTreeNode2 = new DarkTreeNode();
						darkTreeNode2.Text = "Alloc: " + recordBridge + text + item.GetReferenceWeapon(activeUnit_.ParentScen).Name;
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

	private Weapon ReflectError()
	{
		if (TV_AvailableWeapons.SelectedNodes.Count <= 0)
		{
			return null;
		}
		if ((object)TV_AvailableWeapons.SelectedNodes[0].Tag.GetType() == typeof(string))
		{
			return (Weapon)TV_AvailableWeapons.SelectedNodes[0].ParentNode.Tag;
		}
		return (Weapon)TV_AvailableWeapons.SelectedNodes[0].Tag;
	}

	private void VisitError()
	{
		if (TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			WeaponGroupBox.Visible = false;
			return;
		}
		if (SelectedAttackers.Count <= 0)
		{
			WeaponGroupBox.Visible = false;
			return;
		}
		WeaponGroupBox.Visible = true;
		if (SelectedTargets.Count == 1)
		{
			Button_AllocateAllWeapons.Enabled = true;
		}
		else
		{
			Button_AllocateAllWeapons.Enabled = false;
		}
		Weapon weapon_ = ReflectError();
		if (weapon_ == null)
		{
			return;
		}
		ButtonSelectedWeapon.Text = weapon_.Name;
		if (SelectedTargets.Count <= 0)
		{
			Button_AllocateSalvo.Enabled = false;
			Button_Allocate.Enabled = false;
			return;
		}
		if (SelectedAttackers[0].Doctrine.InsertRepository(ref weapon_))
		{
			Button_AllocateSalvo.Enabled = true;
		}
		else
		{
			Button_AllocateSalvo.Enabled = false;
		}
		Button_Allocate.Enabled = true;
	}

	private void RestartError()
	{
		TV_AvailableWeapons.Nodes.Clear();
		VisitError();
		if (SelectedAttackers.Count == 1)
		{
			if (SelectedTargets.Count == 0)
			{
				TV_AvailableWeapons.Enabled = false;
				return;
			}
			if (SelectedTargets.Count > 1)
			{
				int num = 0;
				Contact_Base.ContactType contactType = Contact_Base.ContactType.Air;
				foreach (Contact selectedTarget in SelectedTargets)
				{
					if (num == 0)
					{
						contactType = selectedTarget.Type;
					}
					else if (contactType != selectedTarget.Type)
					{
						TV_AvailableWeapons.Enabled = false;
						return;
					}
					num++;
				}
			}
			TV_AvailableWeapons.Enabled = true;
			foreach (ActiveUnit attacker in Attackers)
			{
				Weapon[] array = attacker.Weaponry.AllDistinctWeaponsAboard_Actual().ToArray();
				Weapon[] array2 = array;
				foreach (Weapon weapon_ in array2)
				{
					TestError(attacker, weapon_);
				}
			}
			if (Information.IsNothing(schemaBridge) || TV_AvailableWeapons.SelectedNodes.Count != 0)
			{
				return;
			}
			{
				foreach (DarkTreeNode node in TV_AvailableWeapons.Nodes)
				{
					if (node.VisibleIndex == utilsBridge)
					{
						foreach (DarkTreeNode node2 in node.Nodes)
						{
							if (node2.VisibleIndex == schemaBridge.Value)
							{
								singletonBridge = false;
								TV_AvailableWeapons.SelectNode(node2);
								singletonBridge = true;
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

	private void TestError(ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		bool? nullable_ = null;
		if (!weapon_0.IsPalletWeapon)
		{
			List<Contact> selectedTargets;
			Contact contact_ = (selectedTargets = SelectedTargets)[0];
			bool num = weapon_0.QueryReponse(activeUnit_0, ref contact_, ref nullable_);
			selectedTargets[0] = contact_;
			if (!num)
			{
				return;
			}
		}
		StopError(activeUnit_0, weapon_0);
	}

	private void StopError(ActiveUnit activeUnit_0, Weapon weapon_0)
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
			foreach (WeaponRec item5 in activeUnit_0.Weaponry.AllDistinctWeaponsAboard_Current_WeaponRecs(bool_1: true))
			{
				if (item5.int_0 == dBID)
				{
					num2 = item5.MaxLoad - num;
				}
			}
		}
		string text = Conversions.ToString(num) + "x " + Misc.ReadRequest(weapon_0.Name);
		if (num2 <= 2147473647)
		{
			if (num2 > 0)
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
		if (num2 == num)
		{
			return;
		}
		short? nullable_ = null;
		foreach (Mount mount in activeUnit_0.Mounts)
		{
			int num3 = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMountTotal(mount, dBID);
			if (num3 > 0)
			{
				ActiveUnit_Weaponry weaponry = activeUnit_0.Weaponry;
				Contact contact_ = SelectedTargets[0];
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
								Contact contact_2 = SelectedTargets[0];
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
						VerifyError(weapon_0, dictionary, darkTreeNode, weapon_0);
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
					Contact contact_3 = SelectedTargets[0];
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
					Contact contact_4 = SelectedTargets[0];
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
		VerifyError(weapon_0, dictionary, darkTreeNode);
	}

	private void CancelError(string string_0, Color color_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			DarkListItem darkListItem = new DarkListItem(string_0);
			darkListItem.TextColor = color_0;
			LV_WarningAndError.Items.Add(darkListItem);
		}
	}

	private void VerifyError(Weapon weapon_0, Dictionary<string, int> dictionary_0, DarkTreeNode darkTreeNode_0, Weapon weapon_1 = null)
	{
		ActiveUnit activeUnit_ = SelectedAttacker;
		Contact contact_ = SelectedTarget;
		int num = activeUnit_.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_, weapon_0);
		int num2 = activeUnit_.Weaponry.HowManyOfThisWeaponOnMagazines(weapon_0.DBID);
		LV_WarningAndError.Items.Clear();
		Doctrine._WCS wCS = activeUnit_.Weaponry.InstantiateConsumer(contact_.Type);
		bool? nullable_ = null;
		Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_, weapon_0, ref nullable_);
		string text = "";
		string text2 = "";
		string text3 = " 目标类型是" + Doctrine.WRA_TargetType_String(wRA_WeaponTargetType_, nullable_.Value);
		string text4 = "";
		Doctrine doctrine = activeUnit_.Doctrine;
		Doctrine doctrine2 = activeUnit_.Doctrine;
		Scenario parentScen = activeUnit_.ParentScen;
		int dBID = weapon_0.DBID;
		float? nullable_2 = null;
		float? nullable_3 = null;
		float? num3 = doctrine.IncludeRepository(doctrine2, parentScen, dBID, wRA_WeaponTargetType_, bool_0: false, ref nullable_2, ref nullable_3);
		if (Information.IsNothing(num3))
		{
			num3 = Doctrine.WRA_FiringRange_GetDefaultFiringRange(activeUnit_.ParentScen, weapon_0.DBID, wRA_WeaponTargetType_);
		}
		int? num4 = 0;
		nullable_3 = num3;
		bool? flag = (nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0f) : null);
		if (((!flag) ?? flag).GetValueOrDefault())
		{
			Doctrine doctrine3 = activeUnit_.Doctrine;
			Scenario parentScen2 = activeUnit_.ParentScen;
			int? nullable_4 = null;
			int? nullable_5 = null;
			num4 = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine3, parentScen2, weapon_0, wRA_WeaponTargetType_, bool_0: false, ref nullable_4, ref nullable_5);
			if (Information.IsNothing(num4))
			{
				num4 = 0;
			}
		}
		if (Information.IsNothing(num4))
		{
			text = "Invalid target type";
			text2 = "";
		}
		else
		{
			nullable_3 = num3;
			text = ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0f) : null).GetValueOrDefault() ? "" : (Doctrine.WRA_WeaponQty_String(num4, activeUnit_, SelectedTargets[0], weapon_0) + ". "));
			int? num5 = num4;
			flag = (num5.HasValue ? new bool?(num5.GetValueOrDefault() == 0) : null);
			if (flag.GetValueOrDefault(true))
			{
				nullable_3 = num3;
				bool? flag2 = (nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0f) : null);
				if (((!flag2) ?? flag2).GetValueOrDefault() && flag.HasValue)
				{
					text2 = "";
					goto IL_0344;
				}
			}
			text2 = activeUnit_.Doctrine.FindRepository(num3) + ". ";
		}
		goto IL_0344;
		IL_0344:
		if (contact_.Type == Contact_Base.ContactType.ActivationPoint)
		{
			text4 = "target is Bearing Only Launch (BOL) point or Impact point";
		}
		else
		{
			Misc.PostureStance stance = SelectedTargets[0].GetStance(activeUnit_.GetUnitSide());
			if (Information.IsNothing(stance))
			{
				text4 = "Could not determine contact posture stance";
			}
			else
			{
				switch (wCS)
				{
				case Doctrine._WCS.Hold:
					text4 = "Weapon Control Status (WCS) is WEAPONS HOLD";
					break;
				case Doctrine._WCS.Tight:
					if (stance != Misc.PostureStance.Hostile)
					{
						text4 = "Weapon Control Status (WCS) is WEAPONS TIGHT and target is not identified as Hostile";
					}
					break;
				}
			}
		}
		nullable_3 = num3;
		if ((nullable_3.HasValue ? new bool?(nullable_3.GetValueOrDefault() == 0f) : null).GetValueOrDefault())
		{
			text4 = "Weapon Release Authorization (WRA) : " + text2;
		}
		else
		{
			int? num6 = num4;
			if ((num6.HasValue ? new bool?(num6.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				text4 = "Weapon Release Authorization (WRA) : " + text;
			}
		}
		if (activeUnit_.IsAircraft && weapon_0.Type == Weapon._WeaponType.Gun && contact_.IsSurfaceContact)
		{
			Doctrine._GunStrafeGroundTargets? gunStrafeGroundTargets = null;
			if (Information.IsNothing(gunStrafeGroundTargets))
			{
				gunStrafeGroundTargets = activeUnit_.Doctrine.GetGunStrafing(activeUnit_.ParentScen, bool_0: false, bool_1: false, bool_2: false);
			}
			byte? b = (byte?)gunStrafeGroundTargets;
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
			{
				text4 = "ground units and ships are not doctrine-authorized targets";
			}
		}
		if (num2 > 0)
		{
			DarkTreeNode darkTreeNode;
			(darkTreeNode = darkTreeNode_0).Text = darkTreeNode.Text + " (x" + num2 + " on magazine)";
		}
		if (!string.IsNullOrEmpty(text4))
		{
			CancelError("Automatique NOT allowed : " + text4, Color.IndianRed);
		}
		CancelError("WCS : Weapons " + wCS.ToString().ToUpperInvariant(), Color.WhiteSmoke);
		CancelError("WRA : " + text + text2 + text3, Color.WhiteSmoke);
		foreach (KeyValuePair<string, int> item in dictionary_0)
		{
			DarkTreeNode darkTreeNode2 = new DarkTreeNode();
			string key = item.Key;
			string text5 = Conversions.ToString(item.Value);
			if (weapon_1 == null)
			{
				if (string.CompareOrdinal(key, "OK") == 0)
				{
					darkTreeNode2.Text = text5 + "x 可以开火（手动武器分配）";
					darkTreeNode2.ForeColor = Color.LightGreen;
				}
				else
				{
					darkTreeNode2.Text = text5 + "x 不能开火。" + key;
					darkTreeNode2.ForeColor = Color.IndianRed;
				}
			}
			else if (string.CompareOrdinal(key, "OK") == 0)
			{
				int num7 = activeUnit_.GetUnitSide().NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_, weapon_0);
				darkTreeNode2.Text = text5 + "x " + weapon_0.Name + " can FIRE (manual weapon allocation)  (" + Conversions.ToString(num7) + "x已分配）";
				darkTreeNode2.ForeColor = Color.LightGreen;
			}
			else
			{
				darkTreeNode2.Text = text5 + "x " + weapon_0.Name + " can NOT fire. " + key + " (" + Conversions.ToString(num) + "x已分配）";
				darkTreeNode2.ForeColor = Color.IndianRed;
			}
			darkTreeNode2.Tag = weapon_0;
			darkTreeNode_0.Nodes.Add(darkTreeNode2);
		}
		darkTreeNode_0.Expanded = true;
	}

	private void ListError(object sender, EventArgs e)
	{
		Button_UnitWRA.Enabled = SelectedAttackers.Count == 1;
		if (singletonBridge)
		{
			RestartError();
			ReadError();
			TV_Allocations_ByAttackersOnly.Refresh();
			TV_Allocations_ByAnyone.Refresh();
			TV_Allocations_ToTargetsOnly.Refresh();
			TV_Allocations_ToAnyone.Refresh();
		}
	}

	private void ResolveError(object sender, EventArgs e)
	{
		Button_UnitWRA.Enabled = SelectedAttackers.Count == 1;
		if (singletonBridge)
		{
			RestartError();
			ReadError();
		}
	}

	private void PostError(object sender, EventArgs e)
	{
		ReadError();
	}

	private void RunError(object sender, KeyEventArgs e)
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

	private void AssetError()
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

	private void PrintError(bool bool_0 = true)
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

	private void DefineError(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedUnit) || Information.IsNothing(Client.SelectedUnit.GetUnitSide()))
		{
			return;
		}
		List<ActiveUnit> selectedAttackers = SelectedAttackers;
		if ((Client.CurrentSide.SelectedUnits.Count <= 0 || Information.IsNothing(Client.SelectedUnit)) && (Client.CurrentSide.SelectedUnits.Count != 0 || Information.IsNothing(Client.SelectedUnit) || !Information.IsNothing(Client.SelectedWaypoint)))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.IsActiveUnit && !selectedUnit.IsWeapon && selectedUnit.GetUnitSide() == Client.CurrentSide)
			{
				ActiveUnit activeUnit = (ActiveUnit)selectedUnit;
				if (!selectedAttackers.Contains(activeUnit))
				{
					AddAttacker(activeUnit);
				}
			}
		}
		ListAttackers();
	}

	private void PublishError(object sender, EventArgs e)
	{
		new List<ActiveUnit>();
		if (SelectedAttackers.Count > 0)
		{
			foreach (ActiveUnit selectedAttacker in SelectedAttackers)
			{
				UnitSelection_Attckers.RemoveUnit(selectedAttacker);
			}
		}
		ListAttackers();
		RestartError();
	}

	private void AwakeError(object sender, EventArgs e)
	{
		if (Information.IsNothing(Client.SelectedUnit) || Client.CurrentSide.SelectedUnits.Count <= 0 || Information.IsNothing(Client.SelectedUnit))
		{
			return;
		}
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (selectedUnit.DisableWriter())
			{
				Contact unit_ = (Contact)selectedUnit;
				UnitSelection_Targets.AddUnit(unit_);
			}
		}
		ListTargets();
	}

	private void QueryError(object sender, EventArgs e)
	{
		new List<Contact>();
		foreach (Contact selectedTarget in SelectedTargets)
		{
			UnitSelection_Targets.RemoveUnit(selectedTarget);
		}
		ListTargets();
		RestartError();
	}

	private void ResetError(object sender, EventArgs e)
	{
		if (TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
		Weapon weapon_ = (((object)darkTreeNode.Tag.GetType() == typeof(string)) ? ((Weapon)darkTreeNode.ParentNode.Tag) : ((Weapon)darkTreeNode.Tag));
		foreach (Contact selectedTarget in SelectedTargets)
		{
			Contact contact_ = selectedTarget;
			List<ActiveUnit> selectedAttackers = SelectedAttackers;
			ActiveUnit activeUnit_ = selectedAttackers[0];
			MapError(ref activeUnit_, ref contact_, ref weapon_, bool_0: true);
			selectedAttackers[0] = activeUnit_;
		}
		RestartError();
		ReadError();
	}

	private void MapError(ref ActiveUnit activeUnit_0, ref Contact contact_0, ref Weapon weapon_0, bool bool_0 = false)
	{
		try
		{
			bool? nullable_ = null;
			Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType_ = Doctrine.WRA_DetermineTargetType(ref contact_0, weapon_0, ref nullable_);
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
							List<ActiveUnit> selectedAttackers = SelectedAttackers;
							ActiveUnit activeUnit_ = selectedAttackers[0];
							Weapon weapon_ = weaponWeapon2.GetReferenceWeapon(activeUnit_0.ParentScen);
							int int_ = num.Value;
							CalcError(ref activeUnit_, ref contact_0, ref weapon_, ref int_, weapon_0);
							selectedAttackers[0] = activeUnit_;
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
				Weapon weapon_2 = weapon_0;
				int? nullable_5 = null;
				nullable_3 = null;
				num = Doctrine.WRA_WeaponQty_AnyTargetType(doctrine2, parentScen2, weapon_2, wRA_WeaponTargetType_, bool_0: false, ref nullable_5, ref nullable_3);
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

	private void SortError(object sender, EventArgs e)
	{
		int int_ = Convert.ToInt32(NUD_NumberOfWeapons.Value);
		if (!Versioned.IsNumeric(NUD_NumberOfWeapons.Value) || decimal.Compare(NUD_NumberOfWeapons.Value, 0m) <= 0 || TV_AvailableWeapons.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
		Weapon weapon_ = (((object)darkTreeNode.Tag.GetType() == typeof(string)) ? ((Weapon)darkTreeNode.ParentNode.Tag) : ((Weapon)darkTreeNode.Tag));
		foreach (Contact selectedTarget in SelectedTargets)
		{
			Contact contact_ = selectedTarget;
			if (darkTreeNode.ParentNode == null)
			{
				List<ActiveUnit> selectedAttackers = SelectedAttackers;
				ActiveUnit activeUnit_ = selectedAttackers[0];
				CalcError(ref activeUnit_, ref contact_, ref weapon_, ref int_);
				selectedAttackers[0] = activeUnit_;
				continue;
			}
			Weapon weapon = (Weapon)darkTreeNode.ParentNode.Tag;
			if (weapon.IsPalletWeapon)
			{
				List<ActiveUnit> selectedAttackers2 = SelectedAttackers;
				ActiveUnit activeUnit_2 = selectedAttackers2[0];
				CalcError(ref activeUnit_2, ref contact_, ref weapon_, ref int_, weapon);
				selectedAttackers2[0] = activeUnit_2;
			}
			else
			{
				List<ActiveUnit> selectedAttackers3 = SelectedAttackers;
				ActiveUnit activeUnit_3 = selectedAttackers3[0];
				CalcError(ref activeUnit_3, ref contact_, ref weapon_, ref int_);
				selectedAttackers3[0] = activeUnit_3;
			}
		}
		RestartError();
		ReadError();
	}

	private void CalcError(ref ActiveUnit activeUnit_0, ref Contact contact_0, ref Weapon weapon_0, ref int int_0, Weapon weapon_1 = null)
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

	private void RateError(object sender, EventArgs e)
	{
		try
		{
			if (TV_AvailableWeapons.SelectedNodes.Count == 0)
			{
				return;
			}
			DarkTreeNode darkTreeNode = TV_AvailableWeapons.SelectedNodes[0];
			Weapon weapon = (((object)darkTreeNode.Tag.GetType() == typeof(string)) ? ((Weapon)darkTreeNode.ParentNode.Tag) : ((Weapon)darkTreeNode.Tag));
			int num = SelectedAttackers[0].Weaponry.TotalAvailableInventoryForThisWeapon(weapon.DBID, bool_1: false);
			int num2 = num;
			Side unitSide = SelectedAttackers[0].GetUnitSide();
			List<ActiveUnit> selectedAttackers;
			ActiveUnit activeUnit_ = (selectedAttackers = SelectedAttackers)[0];
			int num3 = unitSide.NumberOfThisWeaponOnThisUnitLeftToFireAtAnyTarget(ref activeUnit_, weapon);
			selectedAttackers[0] = activeUnit_;
			num = num2 - num3;
			if (num > 0)
			{
				bool flag = false;
				if (SelectedAttackers[0].IsAircraft)
				{
					WeaponRec[] weapons = ((Aircraft)SelectedAttackers[0]).Loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						if (!weaponRec.GetReferenceWeapon(SelectedAttackers[0].ParentScen).IsPalletWeapon)
						{
							continue;
						}
						if (weaponRec.GetReferenceWeapon(SelectedAttackers[0].ParentScen).WeaponWeapons.Count == 0)
						{
							weaponRec.GetReferenceWeapon(SelectedAttackers[0].ParentScen).InitializeWeaponWeaponsPallet();
						}
						foreach (WeaponRec weaponWeapon in weaponRec.GetReferenceWeapon(SelectedAttackers[0].ParentScen).WeaponWeapons)
						{
							if (weaponWeapon.int_0 == weapon.DBID)
							{
								flag = true;
								Weapon referenceWeapon = weaponRec.GetReferenceWeapon(SelectedAttackers[0].ParentScen);
								int currentLoad = weaponRec.CurrentLoad;
								ActiveUnit_Weaponry weaponry = SelectedAttackers[0].Weaponry;
								Contact contact_ = SelectedTargets[0];
								int dBID = referenceWeapon.DBID;
								Doctrine._GunStrafeGroundTargets? nullable_ = null;
								weaponry.CreateSalvo(contact_, dBID, currentLoad, bool_1: true, ref nullable_, DateTime.MinValue, bool_2: false, bool_3: true);
							}
						}
					}
				}
				if (!flag)
				{
					ActiveUnit_Weaponry weaponry2 = SelectedAttackers[0].Weaponry;
					Contact contact_2 = SelectedTargets[0];
					int dBID2 = weapon.DBID;
					int int_ = num;
					Doctrine._GunStrafeGroundTargets? nullable_2 = null;
					weaponry2.CreateSalvo(contact_2, dBID2, int_, bool_1: true, ref nullable_2, DateTime.MinValue, bool_2: false, bool_3: true);
				}
				Client.MustRefreshMainForm = true;
			}
			RestartError();
			ReadError();
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

	private void FlushError(object sender, EventArgs e)
	{
		if (TabControl2.SelectedIndex == 0)
		{
			ManageError(bool_0: true);
		}
		else
		{
			RevertError(bool_0: true);
		}
	}

	private void ForgotError(object sender, EventArgs e)
	{
	}

	private void CollectError(object sender, MouseEventArgs e)
	{
		try
		{
			if (TV_AvailableWeapons.SelectedNodes.Count != 0 && SelectedTargets.Count <= 1)
			{
				Weapon weapon = (((object)TV_AvailableWeapons.SelectedNodes[0].Tag.GetType() == typeof(string)) ? ((Weapon)TV_AvailableWeapons.SelectedNodes[0].ParentNode.Tag) : ((Weapon)TV_AvailableWeapons.SelectedNodes[0].Tag));
				if (!SelectedAttackers[0].AI.Targets_ReadOnly.Contains(SelectedTargets[0]))
				{
					SelectedAttackers[0].AI.TargetThisContact(SelectedTargets[0], bool_0: true, bool_1: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualWeaponAlloc);
				}
				ActiveUnit_Weaponry weaponry = SelectedAttackers[0].Weaponry;
				Contact contact_ = SelectedTargets[0];
				int dBID = weapon.DBID;
				Doctrine._GunStrafeGroundTargets? nullable_ = null;
				weaponry.CreateSalvo(contact_, dBID, 1, bool_1: true, ref nullable_, DateTime.MinValue, bool_2: false, bool_3: true);
				Client.MustRefreshMainForm = true;
				RestartError();
				ReadError();
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

	private void OrderError()
	{
		if (SelectedAttackers.Count <= 0)
		{
			return;
		}
		foreach (WeaponSalvo item in SelectedAttackers[0].GetUnitSide().WeaponSalvos.ToList())
		{
			if (item.ShootersList.Length == 0 && item.WpnQuantityAssigned == 0 && item.WpnQuantityFired == 0)
			{
				ArrayExtensions.Remove(ref SelectedAttackers[0].GetUnitSide().WeaponSalvos, item);
			}
		}
	}

	private void RegisterError(DarkTreeNode darkTreeNode_0)
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
					Side unitSide = SelectedAttackers[0].GetUnitSide();
					Scenario scenario_ = Client.CurrentScenario;
					unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo, bool_0: true);
				}
			}
		}
		RestartError();
		ReadError();
	}

	private void ManageError(bool bool_0)
	{
		if (TV_Allocations_ToTargetsOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ToTargetsOnly.SelectedNodes[0].Tag is ActiveUnit)
		{
			RegisterError(TV_Allocations_ToTargetsOnly.SelectedNodes[0]);
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
				foreach (ActiveUnit selectedAttacker in SelectedAttackers)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, selectedAttacker.ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						if (bool_0)
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
						}
						else
						{
							shooter.QuantityAssigned--;
						}
						Side unitSide = SelectedAttackers[0].GetUnitSide();
						Scenario scenario_ = Client.CurrentScenario;
						unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
					}
				}
			}
			RestartError();
			ReadError();
		}
	}

	private void RevertError(bool bool_0)
	{
		if (TV_Allocations_ToAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ToAnyone.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ToAnyone.SelectedNodes[0].Tag is ActiveUnit)
		{
			RegisterError(TV_Allocations_ToAnyone.SelectedNodes[0]);
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
				foreach (ActiveUnit selectedAttacker in SelectedAttackers)
				{
					if (Operators.CompareString(shooter.ShooterObjectID, selectedAttacker.ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
					{
						if (bool_0)
						{
							shooter.QuantityAssigned = shooter.QuantityFired;
						}
						else
						{
							shooter.QuantityAssigned--;
						}
						Side unitSide = SelectedAttackers[0].GetUnitSide();
						Scenario scenario_ = Client.CurrentScenario;
						unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
					}
				}
			}
			RestartError();
			ReadError();
		}
	}

	private void CountCode(bool bool_0)
	{
		if (TV_Allocations_ByAttackersOnly.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ByAttackersOnly.SelectedNodes[0].Tag is ActiveUnit)
		{
			RegisterError(TV_Allocations_ByAttackersOnly.SelectedNodes[0]);
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
				if (Operators.CompareString(shooter.ShooterObjectID, SelectedAttackers[0].ObjectID, TextCompare: true) == 0 && shooter.QuantityAssigned - shooter.QuantityFired > 0)
				{
					if (bool_0)
					{
						shooter.QuantityAssigned = shooter.QuantityFired;
					}
					else
					{
						shooter.QuantityAssigned--;
					}
					Side unitSide = SelectedAttackers[0].GetUnitSide();
					Scenario scenario_ = Client.CurrentScenario;
					unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
				}
			}
			RestartError();
			ReadError();
		}
	}

	private void CustomizeCode(bool bool_0)
	{
		if (TV_Allocations_ByAnyone.SelectedNodes.Count == 0 || Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Allocations_ByAnyone.SelectedNodes[0].Tag)))
		{
			return;
		}
		if (TV_Allocations_ByAnyone.SelectedNodes[0].Tag is ActiveUnit)
		{
			RegisterError(TV_Allocations_ByAnyone.SelectedNodes[0]);
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
					Side unitSide = SelectedAttackers[0].GetUnitSide();
					Scenario scenario_ = Client.CurrentScenario;
					unitSide.AttemptToRemoveWeaponSalvo(ref scenario_, weaponSalvo);
				}
			}
			RestartError();
			ReadError();
		}
	}

	private void CloneCode(object sender, EventArgs e)
	{
		ReadError();
	}

	private void ConnectCode(object sender, EventArgs e)
	{
		if (singletonBridge)
		{
			SimConfiguration.DefaultGamePreferences.SalvoTimeout = CB_AllowTimeout.Checked;
		}
	}

	private void MoveCode(object sender, EventArgs e)
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

	private void DeleteCode(object sender, EventArgs e)
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

	private void AddCode(object sender, EventArgs e)
	{
	}

	private void DestroyCode(object sender, EventArgs e)
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

	private void ComputeCode(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			LogoutCode(TV_Allocations_ByAnyone, e);
		}
	}

	private void PatchCode(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			LogoutCode(TV_Allocations_ByAttackersOnly, e);
		}
	}

	private void SelectCode(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			LogoutCode(TV_Allocations_ToAnyone, e);
		}
	}

	private void CallCode(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			LogoutCode(TV_Allocations_ToTargetsOnly, e);
		}
	}

	private void LogoutCode(DarkTreeView darkTreeView_0, MouseEventArgs mouseEventArgs_0)
	{
		if (darkTreeView_0.SelectedNodes.Count != 0 && !Information.IsNothing(RuntimeHelpers.GetObjectValue(darkTreeView_0.SelectedNodes[0].Tag)) && (object)darkTreeView_0.SelectedNodes[0].Tag.GetType() == typeof(WeaponSalvo))
		{
			exceptionBridge = (WeaponSalvo)darkTreeView_0.SelectedNodes[0].Tag;
			ViewCode();
			DestroyConnection().Show(darkTreeView_0, mouseEventArgs_0.X, mouseEventArgs_0.Y);
		}
	}

	private void ViewCode()
	{
		Weapon referenceWeapon = exceptionBridge.GetReferenceWeapon(Client.CurrentScenario);
		TSMI_HighAltitudeDetonation.Enabled = referenceWeapon.ValidSpecialModes.Contains(Weapon.WeaponSpecialMode.HighAltitudeDetonation);
		TSMI_HighAltitudeDetonation.Checked = exceptionBridge.ActiveSpecialMode == Weapon.WeaponSpecialMode.HighAltitudeDetonation;
	}

	private void ValidateCode(object sender, MouseEventArgs e)
	{
		ManageError(bool_0: false);
	}

	private void LoginCode(object sender, MouseEventArgs e)
	{
		RevertError(bool_0: false);
	}

	private void GetCode(object sender, EventArgs e)
	{
		if (singletonBridge && TV_AvailableWeapons.SelectedNodes.Count > 0)
		{
			schemaBridge = TV_AvailableWeapons.SelectedNodes[0].VisibleIndex;
			if (!Information.IsNothing(TV_AvailableWeapons.SelectedNodes[0].ParentNode))
			{
				utilsBridge = TV_AvailableWeapons.SelectedNodes[0].ParentNode.VisibleIndex;
			}
		}
		VisitError();
	}

	private void WriteCode(object sender, MouseEventArgs e)
	{
		CountCode(bool_0: false);
	}

	private void NewCode(object sender, MouseEventArgs e)
	{
		CustomizeCode(bool_0: false);
	}

	private void PushCode(object sender, EventArgs e)
	{
		CompareError();
	}

	private void InvokeCode(object sender, EventArgs e)
	{
		CompareError();
	}

	private void SetupCode(object sender, EventArgs e)
	{
		CompareError();
	}

	private void ExcludeCode(object sender, EventArgs e)
	{
		CompareError();
	}

	private void IncludeCode(object sender, EventArgs e)
	{
		Client.smethod_1(ReflectError());
	}

	private void SearchCode(object sender, EventArgs e)
	{
		if (SelectedAttacker != null)
		{
			DoctrineForm doctrineForm = new DoctrineForm();
			doctrineForm.Subject = SelectedAttacker;
			doctrineForm.Show();
			doctrineForm.TabControl1A.SelectedIndex = 2;
		}
	}
}
