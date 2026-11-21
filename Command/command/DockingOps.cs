using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class DockingOps : DarkSecondaryFormBase, GInterface9
{
	[CompilerGenerated]
	private sealed class PropertyMap
	{
		public DockingOps Me;

		public Group Local_theGroup;

		public ActiveUnit Local_theUnit;

		internal void PushInterruptiblePage()
		{
			Me.AwakeServer(Local_theGroup, Local_theUnit);
		}
	}

	[CompilerGenerated]
	private sealed class ImporterMap
	{
		public DockingOps Me;

		public Group Local_theGroup;

		public ActiveUnit Local_theUnit;

		internal void InvokeInterruptiblePage()
		{
			Me.QueryServer(Local_theGroup, Local_theUnit);
		}
	}

	[CompilerGenerated]
	private sealed class RepositoryMap
	{
		public ActiveUnit Local_theAU;

		internal bool SetupInterruptiblePage(TreeGridNode theNode)
		{
			return theNode.Tag == Local_theAU;
		}
	}

	[CompilerGenerated]
	private sealed class ReaderProcessProducer
	{
		public int Local_theDBID;

		internal bool ExcludeInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsShip & (theBoat.DBID == Local_theDBID);
		}
	}

	[CompilerGenerated]
	private sealed class BridgeMap
	{
		public int Local_theDBID0;

		internal bool IncludeInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsSubmarine & (theBoat.DBID == Local_theDBID0);
		}
	}

	[CompilerGenerated]
	private sealed class PropertyProcessProducer
	{
		public int Local_theDBID00;

		internal bool SearchInterruptiblePage(ActiveUnit theBoat)
		{
			return theBoat.IsVehicle & (theBoat.DBID == Local_theDBID00);
		}
	}

	private IContainer fieldTokenizer;

	[AccessedThroughProperty("TabControl1")]
	[CompilerGenerated]
	private DarkUITabControl m_QueueTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStrip1")]
	private DarkToolStrip m_ParamTokenizer;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton m_PageTokenizer;

	[AccessedThroughProperty("ToolStripButton3")]
	[CompilerGenerated]
	private ToolStripButton _RulesTokenizer;

	[AccessedThroughProperty("SplitContainer1")]
	[CompilerGenerated]
	private SplitContainer methodTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Boats")]
	private DarkTreeGridView serviceTokenizer;

	[AccessedThroughProperty("TabPage2")]
	[CompilerGenerated]
	private TabPage m_SystemTokenizer;

	[AccessedThroughProperty("Timer1")]
	[CompilerGenerated]
	private System.Windows.Forms.Timer _BaseTokenizer;

	[AccessedThroughProperty("TSB_AbortLaunch")]
	[CompilerGenerated]
	private ToolStripButton m_PolicyTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Doctrine")]
	private ToolStripButton m_IdentifierTokenizer;

	[AccessedThroughProperty("TSB_AssignToMission")]
	[CompilerGenerated]
	private ToolStripDropDownButton _PrinterTokenizer;

	[AccessedThroughProperty("CMenu_BoatOps")]
	[CompilerGenerated]
	private DarkContextMenu parserTokenizer;

	[AccessedThroughProperty("LaunchIndividuallyToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _AlgoTokenizer;

	[AccessedThroughProperty("LaunchAsGroupsToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem databaseTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("AbortLaunchToolStripMenuItem")]
	private DarkToolStripMenuItem interceptorTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("DoctrineToolStripMenuItem")]
	private DarkToolStripMenuItem _ProductTokenizer;

	[AccessedThroughProperty("AssignToMissionToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem annotationTokenizer;

	[AccessedThroughProperty("ToolStripSeparator3")]
	[CompilerGenerated]
	private ToolStripSeparator iteratorTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_SetReadyTime")]
	private ToolStripButton initializerTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Rename")]
	private ToolStripButton roleTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Delete")]
	private ToolStripButton factoryTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripSeparator4")]
	private ToolStripSeparator m_AttributeTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("SetTimeToReadyToolStripMenuItem")]
	private DarkToolStripMenuItem _EventTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("RenameToolStripMenuItem")]
	private DarkToolStripMenuItem _GlobalTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("RemoveToolStripMenuItem")]
	private DarkToolStripMenuItem workerTokenizer;

	[AccessedThroughProperty("TSB_Cargo")]
	[CompilerGenerated]
	private ToolStripButton _AccountTokenizer;

	[AccessedThroughProperty("Boat")]
	[CompilerGenerated]
	private TreeGridColumn m_StateTokenizer;

	[AccessedThroughProperty("Damage")]
	[CompilerGenerated]
	private DataGridViewLinkColumn m_AuthenticationTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Weapons")]
	private DataGridViewLinkColumn m_ParamsTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Magazines")]
	private DataGridViewLinkColumn m_InfoTokenizer;

	[AccessedThroughProperty("Fuel")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn helperTokenizer;

	[AccessedThroughProperty("TimeToReady")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn getterTokenizer;

	[AccessedThroughProperty("TS_Edit")]
	[CompilerGenerated]
	private DarkToolStrip m_ProducerTokenizer;

	[AccessedThroughProperty("Button_AddFac")]
	[CompilerGenerated]
	private ToolStripButton procTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveFac")]
	private ToolStripButton m_StructStub;

	[AccessedThroughProperty("Splitter1")]
	[CompilerGenerated]
	private Splitter merchantStub;

	[CompilerGenerated]
	[AccessedThroughProperty("btnExpandShipList")]
	private DarkUIButton _CallbackStub;

	[AccessedThroughProperty("lblCapacity")]
	[CompilerGenerated]
	private DarkLabel m_DecoratorStub;

	[AccessedThroughProperty("btnHideUnderMaintenance")]
	[CompilerGenerated]
	private DarkUIButton _ProcessStub;

	public List<ActiveUnit> SelectedHosts;

	private List<ActiveUnit> _ThreadStub;

	private List<ActiveUnit> _RuleStub;

	private List<ActiveUnit> m_CollectionStub;

	private MaintainScrollPosition instanceStub;

	private bool m_ObjectStub;

	private HashSet<TreeGridNode> m_ParameterStub;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_TGV_Boats")]
	private BackgroundWorker expressionStub;

	private bool _DispatcherStub;

	private bool m_ListenerStub;

	private bool _ConfigStub;

	private Keys[] _RegistryStub;

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return m_QueueTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertServer;
			DarkUITabControl queueTokenizer = m_QueueTokenizer;
			if (queueTokenizer != null)
			{
				queueTokenizer.SelectedIndexChanged -= value2;
			}
			m_QueueTokenizer = value;
			queueTokenizer = m_QueueTokenizer;
			if (queueTokenizer != null)
			{
				queueTokenizer.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return m_ParamTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParamTokenizer = value;
		}
	}

	internal ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return m_PageTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountAdapter;
			ToolStripButton pageTokenizer = m_PageTokenizer;
			if (pageTokenizer != null)
			{
				pageTokenizer.Click -= value2;
			}
			m_PageTokenizer = value;
			pageTokenizer = m_PageTokenizer;
			if (pageTokenizer != null)
			{
				pageTokenizer.Click += value2;
			}
		}
	}

	internal ToolStripButton ToolStripButton3
	{
		[CompilerGenerated]
		get
		{
			return _RulesTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyAdapter;
			ToolStripButton rulesTokenizer = _RulesTokenizer;
			if (rulesTokenizer != null)
			{
				rulesTokenizer.Click -= value2;
			}
			_RulesTokenizer = value;
			rulesTokenizer = _RulesTokenizer;
			if (rulesTokenizer != null)
			{
				rulesTokenizer.Click += value2;
			}
		}
	}

	internal SplitContainer SplitContainer1
	{
		[CompilerGenerated]
		get
		{
			return methodTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodTokenizer = value;
		}
	}

	private DarkTreeGridView TGV_Boats
	{
		[CompilerGenerated]
		get
		{
			return serviceTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CollapsingEventHandler value2 = ConnectAdapter;
			ExpandingEventHandler value3 = MoveAdapter;
			EventHandler value4 = PatchAdapter;
			DataGridViewCellEventHandler value5 = InterruptAdapter;
			DataGridViewCellMouseEventHandler value6 = CancelAdapter;
			DarkTreeGridView darkTreeGridView = serviceTokenizer;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeCollapsing -= value2;
				darkTreeGridView.NodeExpanding -= value3;
				darkTreeGridView.SelectionChanged -= value4;
				darkTreeGridView.CellContentClick -= value5;
				darkTreeGridView.ColumnHeaderMouseClick -= value6;
			}
			serviceTokenizer = value;
			darkTreeGridView = serviceTokenizer;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.NodeCollapsing += value2;
				darkTreeGridView.NodeExpanding += value3;
				darkTreeGridView.SelectionChanged += value4;
				darkTreeGridView.CellContentClick += value5;
				darkTreeGridView.ColumnHeaderMouseClick += value6;
			}
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_SystemTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SystemTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("TV_Facilities")]
	internal DarkTreeView TV_Facilities
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_AbortLaunch
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateAdapter;
			ToolStripButton policyTokenizer = m_PolicyTokenizer;
			if (policyTokenizer != null)
			{
				policyTokenizer.Click -= value2;
			}
			m_PolicyTokenizer = value;
			policyTokenizer = m_PolicyTokenizer;
			if (policyTokenizer != null)
			{
				policyTokenizer.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal ToolStripSeparator ToolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WriteAdapter;
			ToolStripButton identifierTokenizer = m_IdentifierTokenizer;
			if (identifierTokenizer != null)
			{
				identifierTokenizer.Click -= value2;
			}
			m_IdentifierTokenizer = value;
			identifierTokenizer = m_IdentifierTokenizer;
			if (identifierTokenizer != null)
			{
				identifierTokenizer.Click += value2;
			}
		}
	}

	internal ToolStripDropDownButton TSB_AssignToMission
	{
		[CompilerGenerated]
		get
		{
			return _PrinterTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewAdapter;
			EventHandler value3 = PushAdapter;
			ToolStripItemClickedEventHandler value4 = InvokeAdapter;
			ToolStripDropDownButton printerTokenizer = _PrinterTokenizer;
			if (printerTokenizer != null)
			{
				printerTokenizer.Click -= value2;
				printerTokenizer.DropDownOpening -= value3;
				printerTokenizer.DropDownItemClicked -= value4;
			}
			_PrinterTokenizer = value;
			printerTokenizer = _PrinterTokenizer;
			if (printerTokenizer != null)
			{
				printerTokenizer.Click += value2;
				printerTokenizer.DropDownOpening += value3;
				printerTokenizer.DropDownItemClicked += value4;
			}
		}
	}

	internal DarkContextMenu CMenu_BoatOps
	{
		[CompilerGenerated]
		get
		{
			return parserTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CancelEventHandler value2 = CheckAdapter;
			DarkContextMenu darkContextMenu = parserTokenizer;
			if (darkContextMenu != null)
			{
				darkContextMenu.Opening -= value2;
			}
			parserTokenizer = value;
			darkContextMenu = parserTokenizer;
			if (darkContextMenu != null)
			{
				darkContextMenu.Opening += value2;
			}
		}
	}

	internal DarkToolStripMenuItem LaunchIndividuallyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _AlgoTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeAdapter;
			DarkToolStripMenuItem algoTokenizer = _AlgoTokenizer;
			if (algoTokenizer != null)
			{
				algoTokenizer.Click -= value2;
			}
			_AlgoTokenizer = value;
			algoTokenizer = _AlgoTokenizer;
			if (algoTokenizer != null)
			{
				algoTokenizer.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem LaunchAsGroupsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return databaseTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeAdapter;
			DarkToolStripMenuItem darkToolStripMenuItem = databaseTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			databaseTokenizer = value;
			darkToolStripMenuItem = databaseTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem AbortLaunchToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return interceptorTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchAdapter;
			DarkToolStripMenuItem darkToolStripMenuItem = interceptorTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			interceptorTokenizer = value;
			darkToolStripMenuItem = interceptorTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator2")]
	internal ToolStripSeparator ToolStripSeparator2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkToolStripMenuItem DoctrineToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ProductTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableAdapter;
			DarkToolStripMenuItem productTokenizer = _ProductTokenizer;
			if (productTokenizer != null)
			{
				productTokenizer.Click -= value2;
			}
			_ProductTokenizer = value;
			productTokenizer = _ProductTokenizer;
			if (productTokenizer != null)
			{
				productTokenizer.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem AssignToMissionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return annotationTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeAdapter;
			ToolStripItemClickedEventHandler value3 = ConcatAdapter;
			DarkToolStripMenuItem darkToolStripMenuItem = annotationTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
				darkToolStripMenuItem.DropDownItemClicked -= value3;
			}
			annotationTokenizer = value;
			darkToolStripMenuItem = annotationTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
				darkToolStripMenuItem.DropDownItemClicked += value3;
			}
		}
	}

	internal ToolStripSeparator ToolStripSeparator3
	{
		[CompilerGenerated]
		get
		{
			return iteratorTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iteratorTokenizer = value;
		}
	}

	internal ToolStripButton TSB_SetReadyTime
	{
		[CompilerGenerated]
		get
		{
			return initializerTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveAdapter;
			ToolStripButton toolStripButton = initializerTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			initializerTokenizer = value;
			toolStripButton = initializerTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Rename
	{
		[CompilerGenerated]
		get
		{
			return roleTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetAdapter;
			ToolStripButton toolStripButton = roleTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			roleTokenizer = value;
			toolStripButton = roleTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Delete
	{
		[CompilerGenerated]
		get
		{
			return factoryTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalculateAdapter;
			ToolStripButton toolStripButton = factoryTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			factoryTokenizer = value;
			toolStripButton = factoryTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripSeparator ToolStripSeparator4
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttributeTokenizer = value;
		}
	}

	internal DarkToolStripMenuItem SetTimeToReadyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _EventTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateAdapter;
			DarkToolStripMenuItem eventTokenizer = _EventTokenizer;
			if (eventTokenizer != null)
			{
				eventTokenizer.Click -= value2;
			}
			_EventTokenizer = value;
			eventTokenizer = _EventTokenizer;
			if (eventTokenizer != null)
			{
				eventTokenizer.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem RenameToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _GlobalTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateAdapter;
			DarkToolStripMenuItem globalTokenizer = _GlobalTokenizer;
			if (globalTokenizer != null)
			{
				globalTokenizer.Click -= value2;
			}
			_GlobalTokenizer = value;
			globalTokenizer = _GlobalTokenizer;
			if (globalTokenizer != null)
			{
				globalTokenizer.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem RemoveToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return workerTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CompareAdapter;
			DarkToolStripMenuItem darkToolStripMenuItem = workerTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			workerTokenizer = value;
			darkToolStripMenuItem = workerTokenizer;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Cargo
	{
		[CompilerGenerated]
		get
		{
			return _AccountTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadAdapter;
			ToolStripButton accountTokenizer = _AccountTokenizer;
			if (accountTokenizer != null)
			{
				accountTokenizer.Click -= value2;
			}
			_AccountTokenizer = value;
			accountTokenizer = _AccountTokenizer;
			if (accountTokenizer != null)
			{
				accountTokenizer.Click += value2;
			}
		}
	}

	internal TreeGridColumn Boat
	{
		[CompilerGenerated]
		get
		{
			return m_StateTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StateTokenizer = value;
		}
	}

	internal DataGridViewLinkColumn Damage
	{
		[CompilerGenerated]
		get
		{
			return m_AuthenticationTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AuthenticationTokenizer = value;
		}
	}

	internal DataGridViewLinkColumn Weapons
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParamsTokenizer = value;
		}
	}

	internal DataGridViewLinkColumn Magazines
	{
		[CompilerGenerated]
		get
		{
			return m_InfoTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InfoTokenizer = value;
		}
	}

	internal DataGridViewTextBoxColumn Fuel
	{
		[CompilerGenerated]
		get
		{
			return helperTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			helperTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("Mission")]
	internal DataGridViewTextBoxColumn Mission
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Status")]
	internal DataGridViewTextBoxColumn Status
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn TimeToReady
	{
		[CompilerGenerated]
		get
		{
			return getterTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			getterTokenizer = value;
		}
	}

	internal DarkToolStrip TS_Edit
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProducerTokenizer = value;
		}
	}

	internal ToolStripButton Button_AddFac
	{
		[CompilerGenerated]
		get
		{
			return procTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpdateAdapter;
			ToolStripButton toolStripButton = procTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			procTokenizer = value;
			toolStripButton = procTokenizer;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton Button_RemoveFac
	{
		[CompilerGenerated]
		get
		{
			return m_StructStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InsertAdapter;
			ToolStripButton structStub = m_StructStub;
			if (structStub != null)
			{
				structStub.Click -= value2;
			}
			m_StructStub = value;
			structStub = m_StructStub;
			if (structStub != null)
			{
				structStub.Click += value2;
			}
		}
	}

	internal Splitter Splitter1
	{
		[CompilerGenerated]
		get
		{
			return merchantStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			merchantStub = value;
		}
	}

	internal DarkUIButton btnExpandShipList
	{
		[CompilerGenerated]
		get
		{
			return _CallbackStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitAdapter;
			DarkUIButton callbackStub = _CallbackStub;
			if (callbackStub != null)
			{
				callbackStub.Click -= value2;
			}
			_CallbackStub = value;
			callbackStub = _CallbackStub;
			if (callbackStub != null)
			{
				callbackStub.Click += value2;
			}
		}
	}

	internal DarkLabel lblCapacity
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DecoratorStub = value;
		}
	}

	internal DarkUIButton btnHideUnderMaintenance
	{
		[CompilerGenerated]
		get
		{
			return _ProcessStub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectAdapter;
			DarkUIButton processStub = _ProcessStub;
			if (processStub != null)
			{
				processStub.Click -= value2;
			}
			_ProcessStub = value;
			processStub = _ProcessStub;
			if (processStub != null)
			{
				processStub.Click += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal System.Windows.Forms.Timer ForgotAdapter()
	{
		return _BaseTokenizer;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CollectAdapter(System.Windows.Forms.Timer timer_0)
	{
		EventHandler value = CalcServer;
		System.Windows.Forms.Timer baseTokenizer = _BaseTokenizer;
		if (baseTokenizer != null)
		{
			baseTokenizer.Tick -= value;
		}
		_BaseTokenizer = timer_0;
		baseTokenizer = _BaseTokenizer;
		if (baseTokenizer != null)
		{
			baseTokenizer.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker RateSchema()
	{
		return expressionStub;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void FlushSchema(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = SelectAdapter;
		RunWorkerCompletedEventHandler value2 = CallAdapter;
		BackgroundWorker backgroundWorker = expressionStub;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		expressionStub = backgroundWorker_0;
		backgroundWorker = expressionStub;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	public DockingOps()
	{
		base.FormClosing += DefineServer;
		base.Load += PublishServer;
		base.KeyDown += LogoutAdapter;
		base.FormClosed += ViewAdapter;
		base.Shown += PrepareAdapter;
		SelectedHosts = new List<ActiveUnit>();
		_ThreadStub = new List<ActiveUnit>();
		_RuleStub = new List<ActiveUnit>();
		m_CollectionStub = new List<ActiveUnit>();
		instanceStub = new MaintainScrollPosition();
		m_ParameterStub = new HashSet<TreeGridNode>();
		FlushSchema(new BackgroundWorker());
		_DispatcherStub = false;
		m_ListenerStub = false;
		_ConfigStub = false;
		_RegistryStub = new Keys[2]
		{
			Keys.F7,
			Keys.Escape
		};
		PrintServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && fieldTokenizer != null)
			{
				fieldTokenizer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PrintServer()
	{
		fieldTokenizer = new Container();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(DockingOps));
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		ToolStripButton3 = new ToolStripButton();
		TSB_AbortLaunch = new ToolStripButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_Doctrine = new ToolStripButton();
		TSB_AssignToMission = new ToolStripDropDownButton();
		ToolStripSeparator3 = new ToolStripSeparator();
		TSB_Cargo = new ToolStripButton();
		SplitContainer1 = new SplitContainer();
		lblCapacity = new DarkLabel();
		btnHideUnderMaintenance = new DarkUIButton();
		Splitter1 = new Splitter();
		btnExpandShipList = new DarkUIButton();
		TGV_Boats = new DarkTreeGridView();
		Boat = new TreeGridColumn();
		Damage = new DataGridViewLinkColumn();
		Weapons = new DataGridViewLinkColumn();
		Magazines = new DataGridViewLinkColumn();
		Fuel = new DataGridViewTextBoxColumn();
		Mission = new DataGridViewTextBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TimeToReady = new DataGridViewTextBoxColumn();
		CMenu_BoatOps = new DarkContextMenu();
		LaunchIndividuallyToolStripMenuItem = new DarkToolStripMenuItem();
		LaunchAsGroupsToolStripMenuItem = new DarkToolStripMenuItem();
		AbortLaunchToolStripMenuItem = new DarkToolStripMenuItem();
		ToolStripSeparator2 = new ToolStripSeparator();
		DoctrineToolStripMenuItem = new DarkToolStripMenuItem();
		AssignToMissionToolStripMenuItem = new DarkToolStripMenuItem();
		ToolStripSeparator4 = new ToolStripSeparator();
		SetTimeToReadyToolStripMenuItem = new DarkToolStripMenuItem();
		RenameToolStripMenuItem = new DarkToolStripMenuItem();
		RemoveToolStripMenuItem = new DarkToolStripMenuItem();
		TabPage2 = new TabPage();
		TV_Facilities = new DarkTreeView();
		TSB_SetReadyTime = new ToolStripButton();
		TSB_Rename = new ToolStripButton();
		TSB_Delete = new ToolStripButton();
		CollectAdapter(new System.Windows.Forms.Timer(fieldTokenizer));
		TS_Edit = new DarkToolStrip();
		Button_AddFac = new ToolStripButton();
		Button_RemoveFac = new ToolStripButton();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		ToolStrip1.SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.SuspendLayout();
		((ISupportInitialize)TGV_Boats).BeginInit();
		CMenu_BoatOps.SuspendLayout();
		TabPage2.SuspendLayout();
		TS_Edit.SuspendLayout();
		SuspendLayout();
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Dock = DockStyle.Fill;
		TabControl1.Font = new Font("Segoe UI", 8f);
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(0, 0);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(852, 531);
		TabControl1.TabIndex = 1;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(ToolStrip1);
		TabPage1.Controls.Add(SplitContainer1);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(844, 503);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "船只状况";
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.Dock = DockStyle.Bottom;
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[8] { ToolStripButton1, ToolStripButton3, TSB_AbortLaunch, ToolStripSeparator1, TSB_Doctrine, TSB_AssignToMission, ToolStripSeparator3, TSB_Cargo });
		ToolStrip1.Location = new Point(3, 476);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(838, 24);
		ToolStrip1.TabIndex = 1;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripButton1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton1.Image = componentResourceManager.GetObject("ToolStripButton1.Image");
		ToolStripButton1.ImageTransparentColor = Color.Magenta;
		ToolStripButton1.Name = "ToolStripButton1";
		ToolStripButton1.Size = new Size(130, 21);
		ToolStripButton1.Text = "单独出动";
		ToolStripButton3.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton3.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton3.Image = componentResourceManager.GetObject("ToolStripButton3.Image");
		ToolStripButton3.ImageTransparentColor = Color.Magenta;
		ToolStripButton3.Name = "ToolStripButton3";
		ToolStripButton3.Size = new Size(128, 21);
		ToolStripButton3.Text = "作为编队出动";
		TSB_AbortLaunch.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AbortLaunch.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AbortLaunch.ImageTransparentColor = Color.Magenta;
		TSB_AbortLaunch.Name = "TSB_AbortLaunch";
		TSB_AbortLaunch.Size = new Size(83, 21);
		TSB_AbortLaunch.Text = "中止出动";
		ToolStripSeparator1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator1.Margin = new Padding(0, 0, 2, 0);
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(6, 24);
		TSB_Doctrine.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Doctrine.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_Doctrine.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Doctrine.ImageTransparentColor = Color.Magenta;
		TSB_Doctrine.Name = "TSB_Doctrine";
		TSB_Doctrine.Size = new Size(56, 21);
		TSB_Doctrine.Text = "条令";
		TSB_AssignToMission.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AssignToMission.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_AssignToMission.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AssignToMission.ImageTransparentColor = Color.Magenta;
		TSB_AssignToMission.Name = "TSB_AssignToMission";
		TSB_AssignToMission.Size = new Size(113, 21);
		TSB_AssignToMission.Text = "分配给任务";
		ToolStripSeparator3.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator3.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator3.Margin = new Padding(0, 0, 2, 0);
		ToolStripSeparator3.Name = "ToolStripSeparator3";
		ToolStripSeparator3.Size = new Size(6, 24);
		TSB_Cargo.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Cargo.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_Cargo.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Cargo.ImageTransparentColor = Color.Magenta;
		TSB_Cargo.Name = "TSB_Cargo";
		TSB_Cargo.Size = new Size(98, 21);
		TSB_Cargo.Text = " 装载/卸载货物 ";
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.FixedPanel = FixedPanel.Panel2;
		SplitContainer1.Location = new Point(3, 3);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Orientation = Orientation.Horizontal;
		SplitContainer1.Panel1.Controls.Add(lblCapacity);
		SplitContainer1.Panel1.Controls.Add(btnHideUnderMaintenance);
		SplitContainer1.Panel1.Controls.Add(Splitter1);
		SplitContainer1.Panel1.Controls.Add(btnExpandShipList);
		SplitContainer1.Panel1.Controls.Add(TGV_Boats);
		SplitContainer1.Size = new Size(838, 497);
		SplitContainer1.SplitterDistance = 464;
		SplitContainer1.TabIndex = 0;
		lblCapacity.Anchor = AnchorStyles.Right;
		lblCapacity.ForeColor = Color.FromArgb(220, 220, 220);
		lblCapacity.Location = new Point(627, 441);
		lblCapacity.Name = "lblCapacity";
		lblCapacity.Size = new Size(206, 23);
		lblCapacity.TabIndex = 38;
		lblCapacity.Text = "设施容量";
		lblCapacity.TextAlign = ContentAlignment.MiddleRight;
		btnHideUnderMaintenance.BackColor = Color.Transparent;
		btnHideUnderMaintenance.DialogResult = DialogResult.None;
		btnHideUnderMaintenance.ForeColor = SystemColors.Control;
		btnHideUnderMaintenance.Location = new Point(114, 438);
		btnHideUnderMaintenance.Name = "btnHideUnderMaintenance";
		btnHideUnderMaintenance.RoundRadius = 0;
		btnHideUnderMaintenance.Size = new Size(111, 23);
		btnHideUnderMaintenance.TabIndex = 6;
		btnHideUnderMaintenance.Text = "隐藏不可用";
		btnHideUnderMaintenance.Visible = false;
		Splitter1.Location = new Point(0, 0);
		Splitter1.Name = "Splitter1";
		Splitter1.Size = new Size(3, 464);
		Splitter1.TabIndex = 0;
		Splitter1.TabStop = false;
		btnExpandShipList.BackColor = Color.Transparent;
		btnExpandShipList.DialogResult = DialogResult.None;
		btnExpandShipList.ForeColor = SystemColors.Control;
		btnExpandShipList.Location = new Point(9, 438);
		btnExpandShipList.Name = "btnExpandShipList";
		btnExpandShipList.RoundRadius = 0;
		btnExpandShipList.Size = new Size(99, 23);
		btnExpandShipList.TabIndex = 0;
		btnExpandShipList.Text = "收起船只列表";
		TGV_Boats.AllowUserToAddRows = false;
		TGV_Boats.AllowUserToDeleteRows = false;
		TGV_Boats.AllowUserToOrderColumns = true;
		TGV_Boats.BackgroundColor = Color.FromArgb(60, 63, 65);
		TGV_Boats.BorderStyle = BorderStyle.Fixed3D;
		TGV_Boats.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Boats.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_Boats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_Boats.ColumnHeadersHeight = 30;
		TGV_Boats.Columns.AddRange(Boat, Damage, Weapons, Magazines, Fuel, Mission, Status, TimeToReady);
		TGV_Boats.ContextMenuStrip = CMenu_BoatOps;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 8f);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_Boats.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_Boats.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Boats.EnableHeadersVisualStyles = false;
		TGV_Boats.ImageList = null;
		TGV_Boats.Location = new Point(0, 0);
		TGV_Boats.Name = "TGV_Boats";
		TGV_Boats.RowHeadersVisible = false;
		TGV_Boats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Boats.ShowLines = false;
		TGV_Boats.Size = new Size(838, 435);
		TGV_Boats.TabIndex = 5;
		Boat.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 8.25f, FontStyle.Underline);
		dataGridViewCellStyle3.ForeColor = Color.Blue;
		Boat.DefaultCellStyle = dataGridViewCellStyle3;
		Boat.DefaultNodeImage = null;
		Boat.HeaderText = "船只（点击查看数据库信息）";
		Boat.Name = "Boat";
		Boat.Resizable = DataGridViewTriState.True;
		Boat.SortMode = DataGridViewColumnSortMode.NotSortable;
		Damage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle4.Padding = new Padding(1);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		Damage.DefaultCellStyle = dataGridViewCellStyle4;
		Damage.HeaderText = "损伤（点击查看详情）";
		Damage.LinkColor = Color.LightBlue;
		Damage.Name = "Damage";
		Damage.ReadOnly = true;
		Weapons.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle5.Padding = new Padding(1);
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		Weapons.DefaultCellStyle = dataGridViewCellStyle5;
		Weapons.HeaderText = "武器（点击查看详情）";
		Weapons.LinkColor = Color.LightBlue;
		Weapons.Name = "Weapons";
		Weapons.ReadOnly = true;
		Magazines.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle6.Padding = new Padding(1);
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		Magazines.DefaultCellStyle = dataGridViewCellStyle6;
		Magazines.HeaderText = "弹药库（点击查看详情）";
		Magazines.LinkColor = Color.LightBlue;
		Magazines.Name = "Magazines";
		Magazines.ReadOnly = true;
		Fuel.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Fuel.HeaderText = "燃料";
		Fuel.Name = "Fuel";
		Fuel.ReadOnly = true;
		Fuel.SortMode = DataGridViewColumnSortMode.NotSortable;
		Fuel.Width = 33;
		Mission.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Mission.HeaderText = "任务";
		Mission.Name = "Mission";
		Mission.Resizable = DataGridViewTriState.True;
		Mission.SortMode = DataGridViewColumnSortMode.NotSortable;
		Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Status.HeaderText = "状态";
		Status.Name = "Status";
		Status.Resizable = DataGridViewTriState.True;
		Status.SortMode = DataGridViewColumnSortMode.NotSortable;
		Status.Width = 43;
		TimeToReady.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		TimeToReady.HeaderText = "就绪时间";
		TimeToReady.MinimumWidth = 77;
		TimeToReady.Name = "TimeToReady";
		TimeToReady.Resizable = DataGridViewTriState.True;
		TimeToReady.SortMode = DataGridViewColumnSortMode.NotSortable;
		TimeToReady.Width = 77;
		CMenu_BoatOps.BackColor = Color.FromArgb(60, 63, 65);
		CMenu_BoatOps.ForeColor = Color.FromArgb(220, 220, 220);
		CMenu_BoatOps.Items.AddRange(new ToolStripItem[10] { LaunchIndividuallyToolStripMenuItem, LaunchAsGroupsToolStripMenuItem, AbortLaunchToolStripMenuItem, ToolStripSeparator2, DoctrineToolStripMenuItem, AssignToMissionToolStripMenuItem, ToolStripSeparator4, SetTimeToReadyToolStripMenuItem, RenameToolStripMenuItem, RemoveToolStripMenuItem });
		CMenu_BoatOps.Name = "CMenu_BoatOps";
		CMenu_BoatOps.Size = new Size(178, 194);
		LaunchIndividuallyToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		LaunchIndividuallyToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		LaunchIndividuallyToolStripMenuItem.Name = "LaunchIndividuallyToolStripMenuItem";
		LaunchIndividuallyToolStripMenuItem.Size = new Size(177, 22);
		LaunchIndividuallyToolStripMenuItem.Text = "单独出动";
		LaunchAsGroupsToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		LaunchAsGroupsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		LaunchAsGroupsToolStripMenuItem.Name = "LaunchAsGroupsToolStripMenuItem";
		LaunchAsGroupsToolStripMenuItem.Size = new Size(177, 22);
		LaunchAsGroupsToolStripMenuItem.Text = "作为编队出动";
		AbortLaunchToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		AbortLaunchToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		AbortLaunchToolStripMenuItem.Name = "AbortLaunchToolStripMenuItem";
		AbortLaunchToolStripMenuItem.Size = new Size(177, 22);
		AbortLaunchToolStripMenuItem.Text = "中止出动";
		ToolStripSeparator2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator2.Margin = new Padding(0, 0, 0, 1);
		ToolStripSeparator2.Name = "ToolStripSeparator2";
		ToolStripSeparator2.Size = new Size(174, 6);
		DoctrineToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		DoctrineToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		DoctrineToolStripMenuItem.Name = "DoctrineToolStripMenuItem";
		DoctrineToolStripMenuItem.Size = new Size(177, 22);
		DoctrineToolStripMenuItem.Text = "条令";
		AssignToMissionToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		AssignToMissionToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		AssignToMissionToolStripMenuItem.Name = "AssignToMissionToolStripMenuItem";
		AssignToMissionToolStripMenuItem.Size = new Size(177, 22);
		AssignToMissionToolStripMenuItem.Text = "分配给任务";
		ToolStripSeparator4.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator4.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator4.Margin = new Padding(0, 0, 0, 1);
		ToolStripSeparator4.Name = "ToolStripSeparator4";
		ToolStripSeparator4.Size = new Size(174, 6);
		SetTimeToReadyToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		SetTimeToReadyToolStripMenuItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		SetTimeToReadyToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		SetTimeToReadyToolStripMenuItem.Name = "SetTimeToReadyToolStripMenuItem";
		SetTimeToReadyToolStripMenuItem.Size = new Size(177, 22);
		SetTimeToReadyToolStripMenuItem.Text = "设置就绪时间";
		RenameToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		RenameToolStripMenuItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		RenameToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
		RenameToolStripMenuItem.Size = new Size(177, 22);
		RenameToolStripMenuItem.Text = "改名";
		RemoveToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		RemoveToolStripMenuItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		RemoveToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
		RemoveToolStripMenuItem.Size = new Size(177, 22);
		RemoveToolStripMenuItem.Text = "删除";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(TV_Facilities);
		TabPage2.Controls.Add(TS_Edit);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(844, 503);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "停靠设施";
		TV_Facilities.Dock = DockStyle.Fill;
		TV_Facilities.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TV_Facilities.Location = new Point(3, 3);
		TV_Facilities.MaxDragChange = 20;
		TV_Facilities.Name = "TV_Facilities";
		TV_Facilities.Size = new Size(838, 472);
		TV_Facilities.TabIndex = 7;
		TS_Edit.AutoSize = false;
		TS_Edit.BackColor = Color.FromArgb(60, 63, 65);
		TS_Edit.Dock = DockStyle.Bottom;
		TS_Edit.ForeColor = Color.FromArgb(220, 220, 220);
		TS_Edit.GripStyle = ToolStripGripStyle.Hidden;
		TS_Edit.Items.AddRange(new ToolStripItem[2] { Button_AddFac, Button_RemoveFac });
		TS_Edit.Location = new Point(3, 475);
		TS_Edit.Name = "TS_Edit";
		TS_Edit.Padding = new Padding(5, 0, 1, 0);
		TS_Edit.Size = new Size(828, 25);
		TS_Edit.TabIndex = 7;
		TS_Edit.Text = "ToolStrip1";
		Button_AddFac.BackColor = Color.FromArgb(60, 63, 65);
		Button_AddFac.ForeColor = Color.FromArgb(220, 220, 220);
		Button_AddFac.Image = componentResourceManager.GetObject("Button_AddFac.Image");
		Button_AddFac.ImageTransparentColor = Color.Magenta;
		Button_AddFac.Name = "Button_AddFac";
		Button_AddFac.Size = new Size(89, 22);
		Button_AddFac.Text = "添加设施";
		Button_RemoveFac.BackColor = Color.FromArgb(60, 63, 65);
		Button_RemoveFac.ForeColor = Color.FromArgb(220, 220, 220);
		Button_RemoveFac.Image = componentResourceManager.GetObject("Button_RemoveFac.Image");
		Button_RemoveFac.ImageTransparentColor = Color.Magenta;
		Button_RemoveFac.Name = "Button_RemoveFac";
		Button_RemoveFac.Size = new Size(118, 22);
		Button_RemoveFac.Text = "移除设施";
		TSB_SetReadyTime.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_SetReadyTime.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_SetReadyTime.ForeColor = Color.IndianRed;
		TSB_SetReadyTime.ImageTransparentColor = Color.Magenta;
		TSB_SetReadyTime.Name = "TSB_SetReadyTime";
		TSB_SetReadyTime.Size = new Size(108, 22);
		TSB_SetReadyTime.Text = "设置就绪时间";
		TSB_Rename.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_Rename.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_Rename.ForeColor = Color.IndianRed;
		TSB_Rename.ImageTransparentColor = Color.Magenta;
		TSB_Rename.Name = "TSB_Rename";
		TSB_Rename.Size = new Size(57, 22);
		TSB_Rename.Text = "改名";
		TSB_Delete.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_Delete.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_Delete.ForeColor = Color.IndianRed;
		TSB_Delete.ImageTransparentColor = Color.Magenta;
		TSB_Delete.Name = "TSB_Delete";
		TSB_Delete.Size = new Size(58, 22);
		TSB_Delete.Text = "删除";
		ForgotAdapter().Interval = 1000;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(852, 531);
		base.Controls.Add(TabControl1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "DockingOps";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "停靠操作";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		((ISupportInitialize)TGV_Boats).EndInit();
		CMenu_BoatOps.ResumeLayout(performLayout: false);
		TabPage2.ResumeLayout(performLayout: false);
		TS_Edit.ResumeLayout(performLayout: false);
		TS_Edit.PerformLayout();
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
			TGV_Boats.Nodes.Clear();
			TV_Facilities.Nodes.Clear();
			SelectedHosts.Clear();
			_ThreadStub.Clear();
			_RuleStub.Clear();
			m_CollectionStub.Clear();
			TSB_AssignToMission.DropDownItems.Clear();
			AssignToMissionToolStripMenuItem.DropDownItems.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] registryStub = _RegistryStub;
		Keys[] array = registryStub;
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

	private void DefineServer(object sender, FormClosingEventArgs e)
	{
		if (m_ObjectStub)
		{
			Client.CurrentGame.Run();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		ForgotAdapter().Stop();
	}

	private void PublishServer(object sender, EventArgs e)
	{
		TGV_Boats.DefaultCellStyle.BackColor = Colors.DarkBackground;
		TGV_Boats.DefaultCellStyle.ForeColor = Color.White;
		TabControl1.TabPages[0].BackColor = Colors.DarkBackground;
		TabControl1.TabPages[1].BackColor = Colors.DarkBackground;
		m_ObjectStub = Client.CurrentGame.Status == Game._GameStatus.Running;
		if (m_ObjectStub)
		{
			Client.CurrentGame.Pause();
		}
		if (SelectedHosts.Count <= 1)
		{
			Text = "停靠操作 - " + SelectedHosts[0].Name;
		}
		else
		{
			Text = "停靠操作 - 多个单元";
		}
		MapServer();
		CollectServer();
		TSB_SetReadyTime.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_Rename.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_Delete.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		SetTimeToReadyToolStripMenuItem.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		RenameToolStripMenuItem.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		RemoveToolStripMenuItem.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		ToolStripSeparator4.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_Cargo.Visible = true;
		ForgotAdapter().Start();
		ActiveUnit_DockingOps.Docking += ResetServer;
		ActiveUnit_DockingOps.DeployedToSea += SortServer;
		if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.Pause)
		{
			Client.CurrentGame.Pause();
		}
		else if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.SlowToRealTime)
		{
			Client.CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		}
	}

	private void AwakeServer(Group group_0, ActiveUnit activeUnit_0)
	{
		if (base.InvokeRequired)
		{
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				AwakeServer(group_0, activeUnit_0);
			});
			return;
		}
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			DarkTreeView tV_Facilities = TV_Facilities;
			DarkTreeNode darkTreeNode = new DarkTreeNode(selectedHost.Name);
			tV_Facilities.Nodes.Add(darkTreeNode);
			darkTreeNode.Tag = activeUnit_0;
		}
	}

	private void QueryServer(Group group_0, ActiveUnit activeUnit_0)
	{
		if (base.InvokeRequired)
		{
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				QueryServer(group_0, activeUnit_0);
			});
			return;
		}
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			DarkTreeView tV_Facilities = TV_Facilities;
			foreach (DarkTreeNode node in tV_Facilities.Nodes)
			{
				if (node.Tag == activeUnit_0)
				{
					tV_Facilities.Nodes.Remove(node);
					break;
				}
			}
		}
	}

	private void ResetServer(ActiveUnit activeUnit_0)
	{
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			if (!selectedHost.DockingOps.EmbarkedBoats.Contains(activeUnit_0))
			{
				_RuleStub.Add(activeUnit_0);
			}
		}
	}

	public void RefreshForm()
	{
		RateServer();
		OrderServer();
	}

	private void MapServer()
	{
		RateSchema().RunWorkerAsync();
	}

	private void SortServer(ActiveUnit activeUnit_0)
	{
		m_CollectionStub.Add(activeUnit_0);
	}

	public void RefreshAll()
	{
		RateServer();
		OrderServer();
		_RuleStub.Clear();
		m_CollectionStub.Clear();
	}

	private void CalcServer(object sender, EventArgs e)
	{
		if (Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			RefreshAll();
		}
	}

	private void RateServer()
	{
		string string_ = null;
		string string_2 = null;
		string string_3 = null;
		string string_4 = null;
		string string_5 = null;
		string string_6 = null;
		string string_7 = null;
		foreach (TreeGridNode allNodesOfTGV_Boat in GetAllNodesOfTGV_Boats())
		{
			TreeGridNode treeGridNode_ = allNodesOfTGV_Boat;
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(treeGridNode_.Tag)) && ((object)treeGridNode_.Tag.GetType() == typeof(Ship) || (object)treeGridNode_.Tag.GetType() == typeof(Submarine) || (object)treeGridNode_.Tag.GetType() == typeof(Vehicle)))
			{
				ActiveUnit activeUnit = (ActiveUnit)treeGridNode_.Tag;
				bool configStub = _ConfigStub;
				string string_8 = null;
				if (configStub & ((short)(-(activeUnit.IsAvailableForOps(ref string_8) ? 1 : 0)) == 2))
				{
					treeGridNode_.Visible = false;
				}
				else
				{
					treeGridNode_.Visible = true;
				}
				AddAdapter(activeUnit, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
				treeGridNode_.SetValues(activeUnit.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7);
				DeleteAdapter(ref treeGridNode_, activeUnit);
			}
		}
		foreach (ActiveUnit Local_theAU in m_CollectionStub)
		{
			IEnumerable<TreeGridNode> source = from theNode in GetAllNodesOfTGV_Boats()
				where theNode.Tag == Local_theAU
				select theNode;
			if (source.Count() > 0)
			{
				source.ElementAtOrDefault(0).Parent.Nodes.Remove(source.ElementAtOrDefault(0));
			}
		}
		bool flag = false;
		foreach (ActiveUnit item in _RuleStub)
		{
			foreach (TreeGridNode node in TGV_Boats.Nodes)
			{
				TreeGridNode treeGridNode_2 = node;
				if ((object)treeGridNode_2.GetType() == typeof(List<ActiveUnit>))
				{
					AddAdapter(item, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
					treeGridNode_2.Nodes.Add(item.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7).Tag = item;
					DeleteAdapter(ref treeGridNode_2, item);
					flag = true;
				}
			}
			if (!flag)
			{
				TreeGridNode treeGridNode = TGV_Boats.Nodes.Add("1x " + Misc.ReadRequest(item.UnitClass));
				treeGridNode.Tag = item.DBID;
				AddAdapter(item, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
				TreeGridNode treeGridNode_3 = treeGridNode.Nodes.Add(item.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7);
				treeGridNode_3.Tag = item;
				DeleteAdapter(ref treeGridNode_3, item);
			}
		}
	}

	[SpecialName]
	private ReadOnlyCollection<TreeGridNode> GetAllNodesOfTGV_Boats()
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			if (!list.Contains(node))
			{
				list.Add(node);
			}
			FlushServer(node, list);
		}
		return list.AsReadOnly();
	}

	private void FlushServer(TreeGridNode treeGridNode_0, List<TreeGridNode> list_0)
	{
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			FlushServer(node, list_0);
		}
	}

	private void ForgotServer()
	{
		TGV_Boats.Nodes.Clear();
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			IEnumerable<int> enumerable = (from theBoat in selectedHost.DockingOps.EmbarkedBoats
				where theBoat.IsShip
				select theBoat.DBID).Distinct();
			IEnumerable<int> enumerable2 = (from theBoat in selectedHost.DockingOps.EmbarkedBoats
				where theBoat.IsSubmarine
				select theBoat.DBID).Distinct();
			IEnumerable<int> enumerable3 = (from theBoat in selectedHost.DockingOps.EmbarkedBoats
				where theBoat.IsVehicle
				select theBoat.DBID).Distinct();
			foreach (int item in enumerable)
			{
				int Local_theDBID = item;
				IEnumerable<ActiveUnit> enumerable4 = from theBoat in selectedHost.DockingOps.EmbarkedBoats
					where theBoat.IsShip & (theBoat.DBID == Local_theDBID)
					select (theBoat);
				string text = Conversions.ToString(enumerable4.Count()) + "x " + Misc.ReadRequest(enumerable4.ElementAtOrDefault(0).UnitClass);
				if (SelectedHosts.Count > 1)
				{
					text = text + " (" + selectedHost.Name + ")";
				}
				TreeGridNode treeGridNode = TGV_Boats.Nodes.Add(text);
				treeGridNode.DefaultCellStyle.ForeColor = Color.DodgerBlue;
				treeGridNode.Tag = enumerable4;
				treeGridNode.Nodes.Add("Temp");
			}
			foreach (int item2 in enumerable2)
			{
				int Local_theDBID2 = item2;
				IEnumerable<ActiveUnit> enumerable5 = from theBoat in selectedHost.DockingOps.EmbarkedBoats
					where theBoat.IsSubmarine & (theBoat.DBID == Local_theDBID2)
					select (theBoat);
				string text2 = Conversions.ToString(enumerable5.Count()) + "x " + Misc.ReadRequest(enumerable5.ElementAtOrDefault(0).UnitClass);
				if (SelectedHosts.Count > 1)
				{
					text2 = text2 + " (" + selectedHost.Name + ")";
				}
				TreeGridNode treeGridNode2 = TGV_Boats.Nodes.Add(text2);
				treeGridNode2.DefaultCellStyle.ForeColor = Color.DodgerBlue;
				treeGridNode2.Tag = enumerable5;
				treeGridNode2.Nodes.Add("Temp");
			}
			foreach (int item3 in enumerable3)
			{
				int Local_theDBID3 = item3;
				IEnumerable<ActiveUnit> enumerable6 = from theBoat in selectedHost.DockingOps.EmbarkedBoats
					where theBoat.IsVehicle & (theBoat.DBID == Local_theDBID3)
					select (theBoat);
				string text3 = Conversions.ToString(enumerable6.Count()) + "x " + Misc.ReadRequest(enumerable6.ElementAtOrDefault(0).UnitClass);
				if (SelectedHosts.Count > 1)
				{
					text3 = text3 + " (" + selectedHost.Name + ")";
				}
				TreeGridNode treeGridNode3 = TGV_Boats.Nodes.Add(text3);
				treeGridNode3.DefaultCellStyle.ForeColor = Color.DodgerBlue;
				treeGridNode3.Tag = enumerable6;
				treeGridNode3.Nodes.Add("Temp");
			}
			foreach (TreeGridNode node in TGV_Boats.Nodes)
			{
				node.Expand();
			}
			TestAdapter(bool_0: true);
			StopAdapter();
		}
	}

	private void CollectServer()
	{
		TV_Facilities.Nodes.Clear();
		foreach (ActiveUnit selectedHost in SelectedHosts)
		{
			if (selectedHost.IsGroup)
			{
				foreach (ActiveUnit item in from theAU in ((Group)selectedHost).Units.Values
					select (theAU) into theAU
					orderby theAU.Name
					select theAU)
				{
					if (item.DockFacilities_ReadOnly.Length != 0)
					{
						DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
						TV_Facilities.Nodes.Add(darkTreeNode);
						darkTreeNode.Tag = item;
						RegisterServer(item, darkTreeNode);
					}
				}
			}
			else
			{
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(selectedHost.Name);
				TV_Facilities.Nodes.Add(darkTreeNode2);
				darkTreeNode2.Tag = selectedHost;
				RegisterServer(selectedHost, darkTreeNode2);
			}
			InterpreterObjectListener.PostInterruptibleTask(TV_Facilities);
		}
	}

	private void OrderServer()
	{
		TV_Facilities.SuspendLayout();
		foreach (DarkTreeNode node in TV_Facilities.Nodes)
		{
			ActiveUnit activeUnit_ = (ActiveUnit)node.Tag;
			RegisterServer(activeUnit_, node);
		}
		TV_Facilities.ResumeLayout();
	}

	private void RegisterServer(ActiveUnit activeUnit_0, DarkTreeNode darkTreeNode_0)
	{
		IOrderedEnumerable<DockFacility> orderedEnumerable = from theAF in activeUnit_0.DockFacilities_ReadOnly
			select (theAF) into theAF
			orderby theAF.Name
			select theAF;
		double num = 0.0;
		double num2 = 0.0;
		foreach (DockFacility item in orderedEnumerable)
		{
			bool flag = false;
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				if (node.Tag == item)
				{
					flag = true;
					ManageServer(item, node);
					break;
				}
			}
			if (!flag)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
				darkTreeNode_0.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item;
				darkTreeNode.Expanded = true;
				foreach (ActiveUnit value in item.HostedBoats.Values)
				{
					DarkTreeNode darkTreeNode2 = new DarkTreeNode(value.Name + "(" + Misc.ReadRequest(value.UnitClass) + "): " + value.DockingOps.ConditionString + " (" + Misc.UpdateRequest((long)Math.Round(value.DockingOps.ConditionTimer)) + ")");
					darkTreeNode.Nodes.Add(darkTreeNode2);
					darkTreeNode2.Tag = value;
				}
			}
			num += (double)(item.MaximumSingleBoatLength * item.Capacity);
			num2 += num - (double)item.TotalCapacity_Free;
		}
		lblCapacity.Text = "已占用" + num2 + " / " + num + " ( " + Math.Round(num2 / num * 100.0) + "% )";
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
		{
			if (!activeUnit_0.DockFacilities_ReadOnly.Contains((DockFacility)node2.Tag))
			{
				list.Add(node2);
			}
		}
		foreach (DarkTreeNode item2 in list)
		{
			darkTreeNode_0.Nodes.Remove(item2);
		}
	}

	private void ManageServer(DockFacility dockFacility_0, DarkTreeNode darkTreeNode_0)
	{
		bool flag = false;
		foreach (ActiveUnit value in dockFacility_0.HostedBoats.Values)
		{
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				if (node.Tag == value)
				{
					flag = true;
					node.Text = value.Name + "(" + Misc.ReadRequest(value.UnitClass) + "): " + value.DockingOps.ConditionString + " (" + Misc.UpdateRequest((long)Math.Round(value.DockingOps.ConditionTimer)) + ")";
					break;
				}
			}
			if (!flag)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(value.Name + "(" + Misc.ReadRequest(value.UnitClass) + "): " + value.DockingOps.ConditionString + " (" + Misc.UpdateRequest((long)Math.Round(value.DockingOps.ConditionTimer)) + ")");
				darkTreeNode_0.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = value;
			}
		}
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
		{
			if (!dockFacility_0.HostedBoats.Values.Contains((ActiveUnit)node2.Tag))
			{
				list.Add(node2);
			}
		}
		foreach (DarkTreeNode item in list)
		{
			darkTreeNode_0.Nodes.Remove(item);
		}
	}

	private void RevertServer(object sender, EventArgs e)
	{
		switch (TabControl1.SelectedIndex)
		{
		case 1:
			CollectServer();
			break;
		case 0:
			MapServer();
			break;
		}
	}

	private void CountAdapter(object sender, EventArgs e)
	{
		CustomizeAdapter();
	}

	private void CustomizeAdapter()
	{
		CloneAdapter(bool_0: true, bool_1: false);
		switch (_ThreadStub.Count)
		{
		case 1:
			_ThreadStub[0].DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			break;
		default:
			foreach (ActiveUnit item in _ThreadStub)
			{
				item.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			}
			break;
		case 0:
			break;
		}
		RateServer();
	}

	private void CloneAdapter(bool bool_0, bool bool_1)
	{
		_ThreadStub.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					_ThreadStub.Add((ActiveUnit)node2.Tag);
				}
			}
		}
		if (bool_0)
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (ActiveUnit item2 in _ThreadStub)
			{
				if (item2.GetUnitSide() != Client.CurrentSide)
				{
					list.Add(item2);
				}
			}
			if (list.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list.Count) + "所选船只是不受您直接控制的盟军单元。", "选择盟军船只！");
				foreach (ActiveUnit item3 in list)
				{
					_ThreadStub.Remove(item3);
				}
			}
		}
		List<ActiveUnit> list2 = new List<ActiveUnit>();
		foreach (ActiveUnit item4 in _ThreadStub)
		{
			string string_ = null;
			if (!item4.IsAvailableForOps(ref string_))
			{
				list2.Add(item4);
			}
		}
		if (list2.Count <= 0)
		{
			return;
		}
		DarkMessageBox.ShowWarning(Conversions.ToString(list2.Count) + "选定的船只无法进行作业，不会发射。", "选择了不可用的船只！");
		foreach (Aircraft item5 in list2)
		{
			_ThreadStub.Remove(item5);
		}
	}

	private void ConnectAdapter(object sender, CollapsingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			m_ParameterStub.Remove(e.Node);
		}
	}

	private void MoveAdapter(object sender, ExpandingEventArgs e)
	{
		e.Node.Nodes.Clear();
		if (e.Node.Level != 1)
		{
			return;
		}
		_ = ((IEnumerable<ActiveUnit>)e.Node.Tag).ElementAtOrDefault(0).UnitClass;
		m_ParameterStub.Add(e.Node);
		List<ActiveUnit> list = (from theAU in (IEnumerable<ActiveUnit>)e.Node.Tag
			select (theAU) into theAU
			orderby theAU.Name
			select theAU).ToList();
		if (m_ListenerStub)
		{
			list = list.OrderBy((ActiveUnit theU) => theU.DockingOps.ConditionTimer).ToList();
		}
		string string_ = null;
		string string_2 = null;
		string string_3 = null;
		string string_4 = null;
		string string_5 = null;
		string string_6 = null;
		string string_7 = null;
		foreach (ActiveUnit item in list)
		{
			AddAdapter(item, ref string_, ref string_2, ref string_3, ref string_4, ref string_5, ref string_6, ref string_7);
			TreeGridNode treeGridNode_ = e.Node.Nodes.Add(item.Name, string_, string_2, string_3, string_4, string_5, string_6, string_7);
			treeGridNode_.DefaultCellStyle.ForeColor = Color.LightGray;
			treeGridNode_.DefaultCellStyle.Font = new Font(Font, FontStyle.Regular);
			treeGridNode_.Tag = item;
			DeleteAdapter(ref treeGridNode_, item);
		}
	}

	private void DeleteAdapter(ref TreeGridNode treeGridNode_0, ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.AI.IsAllowedToRedeploy_Damage)
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[1]).LinkColor = Color.LightGreen;
		}
		else
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[1]).LinkColor = Color.PaleVioletRed;
		}
		if (activeUnit_0.AI.IsAllowedToRedeploy_AttackWeapon && activeUnit_0.AI.IsAllowedToRedeploy_DefenceWeapon)
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[2]).LinkColor = Color.LightGreen;
			((DataGridViewLinkCell)treeGridNode_0.Cells[3]).LinkColor = Color.LightGreen;
		}
		else
		{
			((DataGridViewLinkCell)treeGridNode_0.Cells[2]).LinkColor = Color.PaleVioletRed;
			((DataGridViewLinkCell)treeGridNode_0.Cells[3]).LinkColor = Color.PaleVioletRed;
		}
		if (activeUnit_0.AI.IsAllowedToRedeploy_Fuel)
		{
			treeGridNode_0.Cells[4].Style.ForeColor = Color.LightGreen;
		}
		else
		{
			treeGridNode_0.Cells[4].Style.ForeColor = Color.PaleVioletRed;
		}
	}

	private void AddAdapter(ActiveUnit activeUnit_0, ref string string_0, ref string string_1, ref string string_2, ref string string_3, ref string string_4, ref string string_5, ref string string_6)
	{
		if (activeUnit_0.Damage.DamagePercent <= 0f)
		{
			string_0 = "没有结构损坏，";
		}
		else
		{
			string_0 = string.Format("{0:0.0}", activeUnit_0.Damage.DamagePercent, 1) + "%毁伤，";
		}
		_ = activeUnit_0.OrderIssuer().Count;
		int num = (from theC in activeUnit_0.OrderIssuer()
			where theC.Status != PlatformComponent._ComponentStatus.Operational
			select theC).Count();
		if (num <= 0)
		{
			string_0 += "所有系统在线";
		}
		else
		{
			string_0 = string_0 + Conversions.ToString(num) + "离线系统";
		}
		string text = "";
		string text2 = "";
		string text3 = "";
		List<WeaponRec> list = new List<WeaponRec>();
		List<WeaponRec> list2 = new List<WeaponRec>();
		List<WeaponRec> list3 = new List<WeaponRec>();
		foreach (Mount mount in activeUnit_0.Mounts)
		{
			foreach (WeaponRec mountWeapon in mount.MountWeapons)
			{
				switch (mountWeapon.GetReferenceWeapon(Client.CurrentScenario).Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.Torpedo:
					list.Add(mountWeapon);
					break;
				default:
					list3.Add(mountWeapon);
					break;
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					list2.Add(mountWeapon);
					break;
				}
			}
			if (Information.IsNothing(mount.MountMagazine))
			{
				continue;
			}
			foreach (WeaponRec weapon in mount.MountMagazine.Weapons)
			{
				switch (weapon.GetReferenceWeapon(Client.CurrentScenario).Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.Torpedo:
					list.Add(weapon);
					break;
				default:
					list3.Add(weapon);
					break;
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					list2.Add(weapon);
					break;
				}
			}
		}
		List<string> list4 = new List<string>();
		if (list.Count > 0)
		{
			text = "制导：" + Conversions.ToString(list.Select((WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list.Select((WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text);
		}
		if (list2.Count > 0)
		{
			text2 = "非制导：" + Conversions.ToString(list2.Select((WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list2.Select((WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text2);
		}
		if (list3.Count > 0)
		{
			text3 = "其他：" + Conversions.ToString(list3.Select((WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list3.Select((WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text3);
		}
		string_1 = string.Join("\r\n", list4);
		list.Clear();
		list2.Clear();
		list3.Clear();
		list4.Clear();
		Magazine[] totalMagazines = activeUnit_0.TotalMagazines;
		for (int i = 0; i < totalMagazines.Length; i++)
		{
			foreach (WeaponRec weapon2 in totalMagazines[i].Weapons)
			{
				switch (weapon2.GetReferenceWeapon(Client.CurrentScenario).Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.Torpedo:
					list.Add(weapon2);
					break;
				default:
					list3.Add(weapon2);
					break;
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.BottomMine:
				case Weapon._WeaponType.FloatingMine:
				case Weapon._WeaponType.MovingMine:
				case Weapon._WeaponType.RisingMine:
				case Weapon._WeaponType.DriftingMine:
				case Weapon._WeaponType.DummyMine:
					list2.Add(weapon2);
					break;
				}
			}
		}
		if (list.Count > 0)
		{
			text = "制导：" + Conversions.ToString(list.Select((WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list.Select((WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text);
		}
		if (list2.Count > 0)
		{
			text2 = "非制导：" + Conversions.ToString(list2.Select((WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list2.Select((WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text2);
		}
		if (list3.Count > 0)
		{
			text3 = "其他：" + Conversions.ToString(list3.Select((WeaponRec theWR) => theWR.CurrentLoad).Sum()) + "/" + Conversions.ToString(list3.Select((WeaponRec theWR) => theWR.DefaultLoad).Sum());
			list4.Add(text3);
		}
		string_2 = string.Join("\r\n", list4);
		double double_ = 0.0;
		double double_2 = 0.0;
		string_3 = string.Format("{0:0.0}", activeUnit_0.FuelPercent(ref double_, ref double_2, bool_0: false) * 100.0, 1) + "%";
		if (Information.IsNothing(activeUnit_0.AssignedMissionOrPackage()))
		{
			string_4 = "-";
		}
		else
		{
			string text4 = "";
			if (activeUnit_0.AI.IsEscort)
			{
				text4 = "，护航";
			}
			string_4 = activeUnit_0.AssignedMissionOrPackage().Name + " (" + activeUnit_0.AssignedMissionOrPackage().GetDescriptionString(Client.CurrentScenario) + text4 + ")";
		}
		string_5 = activeUnit_0.DockingOps.ConditionString;
		string_6 = Misc.UpdateRequest((long)Math.Round(activeUnit_0.DockingOps.ConditionTimer));
	}

	private void DestroyAdapter(object sender, EventArgs e)
	{
		ComputeAdapter();
	}

	private void ComputeAdapter()
	{
		CloneAdapter(bool_0: true, bool_1: true);
		Misc.FormIntoGroups(_ThreadStub, Client.CurrentScenario, Client.CurrentSide, Misc.GroupingLogic.MixedGroup);
		switch (_ThreadStub.Count)
		{
		case 1:
			_ThreadStub[0].DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			break;
		default:
			foreach (ActiveUnit item in _ThreadStub)
			{
				item.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
			}
			break;
		case 0:
			break;
		}
		RateServer();
	}

	private void PatchAdapter(object sender, EventArgs e)
	{
		_ThreadStub.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			_ = node.Selected;
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					if (((ActiveUnit)node2.Tag).IsShip)
					{
						_ThreadStub.Add((Ship)node2.Tag);
					}
					else if (((ActiveUnit)node2.Tag).IsSubmarine)
					{
						_ThreadStub.Add((Submarine)node2.Tag);
					}
					else if (((ActiveUnit)node2.Tag).IsVehicle)
					{
						_ThreadStub.Add((Vehicle)node2.Tag);
					}
				}
			}
		}
		if (_ThreadStub.Count <= 0)
		{
			ToolStripButton1.Enabled = false;
			TSB_Cargo.Enabled = false;
			ToolStripButton3.Enabled = false;
			TSB_AbortLaunch.Enabled = false;
			TSB_Doctrine.Enabled = false;
			TSB_AssignToMission.Enabled = false;
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				TSB_SetReadyTime.Enabled = false;
				TSB_Rename.Enabled = false;
				TSB_Delete.Enabled = false;
				SetTimeToReadyToolStripMenuItem.Enabled = false;
				RenameToolStripMenuItem.Enabled = false;
				RemoveToolStripMenuItem.Enabled = false;
			}
			return;
		}
		ToolStripButton1.Enabled = true;
		TSB_Cargo.Enabled = false;
		foreach (ICargoHost item in _ThreadStub)
		{
			if (item.GetCargo_Type() != 0)
			{
				TSB_Cargo.Enabled = true;
			}
		}
		ToolStripButton3.Enabled = true;
		TSB_AbortLaunch.Enabled = true;
		TSB_Doctrine.Enabled = true;
		TSB_AssignToMission.Enabled = true;
		if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			TSB_SetReadyTime.Enabled = true;
			TSB_Rename.Enabled = true;
			TSB_Delete.Enabled = true;
			SetTimeToReadyToolStripMenuItem.Enabled = true;
			RenameToolStripMenuItem.Enabled = true;
			RemoveToolStripMenuItem.Enabled = true;
		}
	}

	private void SelectAdapter(object sender, DoWorkEventArgs e)
	{
		Thread.Sleep(10);
	}

	private void CallAdapter(object sender, RunWorkerCompletedEventArgs e)
	{
		ForgotServer();
	}

	private void LogoutAdapter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F7 && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Add && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.End && e.KeyCode != Keys.Home))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ViewAdapter(object sender, FormClosedEventArgs e)
	{
		ActiveUnit_DockingOps.Docking -= ResetServer;
		ActiveUnit_DockingOps.DeployedToSea -= SortServer;
	}

	private void ValidateAdapter(object sender, EventArgs e)
	{
		LoginAdapter();
	}

	private void LoginAdapter()
	{
		CloneAdapter(bool_0: true, bool_1: false);
		foreach (ActiveUnit item in _ThreadStub)
		{
			if (item.DockingOps.IsDeploying)
			{
				item.DockingOps.AttemptToStartDocking(item.DockingOps.CurrentHostUnit, bool_0: true);
			}
		}
		RateServer();
	}

	private void GetAdapter()
	{
		_ThreadStub.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					_ThreadStub.Add((ActiveUnit)node2.Tag);
				}
			}
		}
		TSB_AssignToMission.DropDownItems.Clear();
		if (_ThreadStub.Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripMenuItem)TSB_AssignToMission.DropDown.Items.Add("< Unassign >", null, NewAdapter)).Tag = null;
		foreach (Mission item in Client.CurrentSide.Missions.OrderBy((Mission theM) => theM.Name))
		{
			if (item.Category == Command_Core.Mission.MissionCategory.TaskPool || item.Category == Command_Core.Mission.MissionCategory.Package)
			{
				continue;
			}
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem = (ToolStripMenuItem)TSB_AssignToMission.DropDown.Items.Add(item.Name, null, NewAdapter);
			toolStripMenuItem.Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				toolStripMenuItem2 = (ToolStripMenuItem)TSB_AssignToMission.DropDown.Items.Add(item.Name + " - 护航", null, NewAdapter);
				toolStripMenuItem2.Tag = item;
			}
			if (_ThreadStub.Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = _ThreadStub[0];
			if (item == activeUnit.AssignedMissionOrPackage())
			{
				if (item.MissionClass == Command_Core.Mission._MissionClass.Strike && activeUnit.AI.IsEscort)
				{
					toolStripMenuItem2.Checked = true;
				}
				else
				{
					toolStripMenuItem.Checked = true;
				}
			}
		}
	}

	private void WriteAdapter(object sender, EventArgs e)
	{
		CloneAdapter(bool_0: true, bool_1: false);
		if (_ThreadStub.Count > 0)
		{
			MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = null;
			mainForm.ShowDoctrineROE(null, ref readOnlyCollection_, ref _ThreadStub, bool_0: false);
		}
	}

	private void NewAdapter(object sender, EventArgs e)
	{
	}

	private void PushAdapter(object sender, EventArgs e)
	{
		GetAdapter();
	}

	private void InvokeAdapter(object sender, ToolStripItemClickedEventArgs e)
	{
		SetupAdapter(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void SetupAdapter(object sender, ToolStripItemClickedEventArgs e)
	{
		CloneAdapter(bool_0: true, bool_1: false);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(e.ClickedItem.Tag)))
		{
			foreach (ActiveUnit item in _ThreadStub)
			{
				ActiveUnit activeUnit_ = item;
				Client.RemoveUnitFromMission(ref activeUnit_);
			}
		}
		else
		{
			Mission mission_ = (Mission)e.ClickedItem.Tag;
			bool bool_ = Strings.InStr(e.ClickedItem.Text, " - 护航", CompareMethod.Text) != 0;
			Client.AssignToMission(RuntimeHelpers.GetObjectValue(sender), _ThreadStub, ref mission_, ref bool_);
		}
		RefreshForm();
	}

	private void ExcludeAdapter(object sender, EventArgs e)
	{
		CustomizeAdapter();
	}

	private void IncludeAdapter(object sender, EventArgs e)
	{
		ComputeAdapter();
	}

	private void SearchAdapter(object sender, EventArgs e)
	{
		LoginAdapter();
	}

	private void EnableAdapter(object sender, EventArgs e)
	{
		CloneAdapter(bool_0: true, bool_1: false);
		if (_ThreadStub.Count > 0)
		{
			MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = null;
			mainForm.ShowDoctrineROE(null, ref readOnlyCollection_, ref _ThreadStub, bool_0: false);
		}
	}

	private void ChangeAdapter(object sender, EventArgs e)
	{
	}

	private void InitAdapter()
	{
		if (_ThreadStub.Count <= 0)
		{
			LaunchIndividuallyToolStripMenuItem.Enabled = false;
			LaunchAsGroupsToolStripMenuItem.Enabled = false;
			AbortLaunchToolStripMenuItem.Enabled = false;
			DoctrineToolStripMenuItem.Enabled = false;
			AssignToMissionToolStripMenuItem.Enabled = false;
		}
		else
		{
			LaunchIndividuallyToolStripMenuItem.Enabled = true;
			LaunchAsGroupsToolStripMenuItem.Enabled = true;
			AbortLaunchToolStripMenuItem.Enabled = true;
			DoctrineToolStripMenuItem.Enabled = true;
			AssignToMissionToolStripMenuItem.Enabled = true;
		}
		_ThreadStub.Clear();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					_ThreadStub.Add((ActiveUnit)node2.Tag);
				}
			}
		}
		AssignToMissionToolStripMenuItem.DropDownItems.Clear();
		if (_ThreadStub.Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripMenuItem)AssignToMissionToolStripMenuItem.DropDown.Items.Add("< Unassign >", null, ChangeAdapter)).Tag = null;
		foreach (Mission item in Client.CurrentSide.Missions.OrderBy((Mission theM) => theM.Name))
		{
			if (item.Category == Command_Core.Mission.MissionCategory.TaskPool || item.Category == Command_Core.Mission.MissionCategory.Package)
			{
				continue;
			}
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem = (ToolStripMenuItem)AssignToMissionToolStripMenuItem.DropDown.Items.Add(item.Name, null, ChangeAdapter);
			toolStripMenuItem.Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				toolStripMenuItem2 = (ToolStripMenuItem)AssignToMissionToolStripMenuItem.DropDown.Items.Add(item.Name + " - 护航", null, ChangeAdapter);
				toolStripMenuItem2.Tag = item;
			}
			if (_ThreadStub.Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = _ThreadStub[0];
			if (item == activeUnit.AssignedMissionOrPackage())
			{
				if (item.MissionClass == Command_Core.Mission._MissionClass.Strike && activeUnit.AI.IsEscort)
				{
					toolStripMenuItem2.Checked = true;
				}
				else
				{
					toolStripMenuItem.Checked = true;
				}
			}
		}
	}

	private void CheckAdapter(object sender, CancelEventArgs e)
	{
		InitAdapter();
	}

	private void ConcatAdapter(object sender, ToolStripItemClickedEventArgs e)
	{
		SetupAdapter(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void InterruptAdapter(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			TreeGridNode currentNode = TGV_Boats.CurrentNode;
			if (currentNode == null || currentNode.Tag == null)
			{
				return;
			}
			string name = TGV_Boats.Columns[e.ColumnIndex].Name;
			if (Operators.CompareString(name, "Boat", TextCompare: true) == 0)
			{
				try
				{
					if ((object)currentNode.Tag.GetType() != typeof(Ship) && (object)currentNode.Tag.GetType() != typeof(Submarine) && (object)currentNode.Tag.GetType() != typeof(Vehicle))
					{
						ActiveUnit activeUnit;
						try
						{
							activeUnit = (ActiveUnit)currentNode.Tag;
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							if (e.RowIndex == -1)
							{
								ProjectData.ClearProjectError();
								return;
							}
							activeUnit = ((IEnumerable<ActiveUnit>)currentNode.Tag).ElementAtOrDefault(0);
							ProjectData.ClearProjectError();
						}
						if (activeUnit != null)
						{
							int dBID = activeUnit.DBID;
							if (activeUnit.IsShip)
							{
								Client.smethod_0("Ship", dBID);
							}
							else if (activeUnit.IsSubmarine)
							{
								Client.smethod_0("Submarine", dBID);
							}
							else if (activeUnit.IsVehicle)
							{
								Client.smethod_0("地面单元", dBID);
							}
						}
					}
					return;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(name, "Damage", TextCompare: true) == 0)
			{
				try
				{
					ActiveUnit activeUnit2;
					try
					{
						activeUnit2 = (ActiveUnit)currentNode.Tag;
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						ProjectData.ClearProjectError();
						return;
					}
					if (activeUnit2 != null)
					{
						Client.theDamageControlWindow = new DamageControlWindow();
						Client.theDamageControlWindow.theSelectedUnit = activeUnit2;
						Client.theDamageControlWindow.theCurrentGame = Client.CurrentGame;
						Client.theDamageControlWindow.Show();
					}
					return;
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(name, "Weapons", TextCompare: true) == 0)
			{
				try
				{
					ActiveUnit activeUnit3;
					try
					{
						activeUnit3 = (ActiveUnit)currentNode.Tag;
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						ProjectData.ClearProjectError();
						return;
					}
					if (activeUnit3 != null)
					{
						Client.theWeaponsWindow.theSelectedUnit = activeUnit3;
						Client.theWeaponsWindow.Show();
					}
					return;
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (Operators.CompareString(name, "Magazines", TextCompare: true) != 0)
			{
				return;
			}
			try
			{
				ActiveUnit activeUnit4;
				try
				{
					activeUnit4 = (ActiveUnit)currentNode.Tag;
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					ProjectData.ClearProjectError();
					return;
				}
				if (activeUnit4 != null)
				{
					Client.theMagazinesWindow = new Magazines();
					Client.theMagazinesWindow.SelectedUnit = activeUnit4;
					Client.theMagazinesWindow.Show();
				}
			}
			catch (Exception projectError8)
			{
				ProjectData.SetProjectError(projectError8);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200379", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RemoveAdapter(object sender, EventArgs e)
	{
		FindAdapter();
	}

	private void FindAdapter()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					list.Add((ActiveUnit)node2.Tag);
				}
			}
		}
		ItemExporter.ConnectInterruptibleTemplate.TimeToReadyWindow.SelectedUnits = list;
		ItemExporter.ConnectInterruptibleTemplate.TimeToReadyWindow.Show();
	}

	private void SetAdapter(object sender, EventArgs e)
	{
		FillAdapter();
	}

	private void FillAdapter()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					list.Add((ActiveUnit)node2.Tag);
				}
			}
		}
		if (list.Count == 1)
		{
			ItemExporter.ConnectInterruptibleTemplate.RenameObject.RenamingOption = RenameObject.E_RenamingOption.Unit_Generic;
			ItemExporter.ConnectInterruptibleTemplate.RenameObject.SelectedName = list[0].Name;
			if (ItemExporter.ConnectInterruptibleTemplate.RenameObject.ShowDialog() == DialogResult.OK)
			{
				list[0].Name = ItemExporter.ConnectInterruptibleTemplate.RenameObject.SelectedName;
			}
			RateServer();
			OrderServer();
		}
	}

	private void CalculateAdapter(object sender, EventArgs e)
	{
		PopAdapter();
	}

	private void PopAdapter()
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in TGV_Boats.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					list.Add(node2);
				}
			}
		}
		foreach (TreeGridNode item in list)
		{
			ActiveUnit activeUnit = (ActiveUnit)item.Tag;
			activeUnit.DockingOps.HostDockFacility.HostedBoats.Remove(activeUnit.ObjectID);
			Client.CurrentScenario.DeleteUnitImmediately(activeUnit.ObjectID, bool_0: true, "Unit deleted");
			item.Parent.Nodes.Remove(item);
		}
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
		}
		ForgotServer();
	}

	private void InstantiateAdapter(object sender, EventArgs e)
	{
		FindAdapter();
	}

	private void CreateAdapter(object sender, EventArgs e)
	{
		FillAdapter();
	}

	private void CompareAdapter(object sender, EventArgs e)
	{
		PopAdapter();
	}

	private void ReadAdapter(object sender, EventArgs e)
	{
		CloneAdapter(bool_0: true, bool_1: false);
		switch (_ThreadStub.Count)
		{
		case 1:
		{
			ActiveUnit activeUnit = _ThreadStub[0];
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsV2_0.CargoUnit = activeUnit;
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsV2_0.HostUnit = activeUnit.CurrentHostUnitCargoSource;
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsV2_0.Show();
			break;
		}
		default:
			DarkMessageBox.ShowError("请选择一艘舰船", "");
			break;
		case 0:
			break;
		}
		RateServer();
	}

	private ActiveUnit DisableAdapter()
	{
		if (SelectedHosts.Count == 1)
		{
			return SelectedHosts.First();
		}
		if (TV_Facilities.SelectedNodes.Count == 1)
		{
			DarkTreeNode darkTreeNode = TV_Facilities.SelectedNodes.First();
			foreach (ActiveUnit selectedHost in SelectedHosts)
			{
				if (darkTreeNode.Tag == selectedHost)
				{
					return selectedHost;
				}
			}
		}
		return null;
	}

	private void UpdateAdapter(object sender, EventArgs e)
	{
		ActiveUnit activeUnit = DisableAdapter();
		if (activeUnit == null)
		{
			DarkMessageBox.ShowError("Select a single hosting unit from the facilities list to add facilities.", "No Hosting Unit");
			return;
		}
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.Mode = 1;
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.ParentForm = this;
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.theSelectedUnit = activeUnit;
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.Show();
	}

	private void InsertAdapter(object sender, EventArgs e)
	{
		ActiveUnit activeUnit = null;
		if (TV_Facilities.SelectedNodes.Count > 0)
		{
			foreach (DarkTreeNode selectedNode in TV_Facilities.SelectedNodes)
			{
				if (selectedNode.Tag == null || (object)selectedNode.Tag.GetType() != typeof(DockFacility))
				{
					continue;
				}
				DockFacility dockFacility = (DockFacility)selectedNode.Tag;
				if (dockFacility.ParentPlatform == null)
				{
					continue;
				}
				bool flag = true;
				if (dockFacility.HostedBoats.Count > 0 && DarkMessageBox.ShowWarning("Facility " + dockFacility.Name + " has one or more boats present. Removing this facility will delete the boats from your scenario.", "Delete Boats?", DarkDialogButton.OkCancel) == DialogResult.Cancel)
				{
					flag = false;
				}
				if (!flag)
				{
					continue;
				}
				if (dockFacility.HostedBoats.Count > 0)
				{
					foreach (ActiveUnit value in dockFacility.HostedBoats.Values)
					{
						SortServer(value);
						Client.CurrentScenario.DeleteUnitImmediately(value.ObjectID, bool_0: true, "Manually deleted by user");
					}
				}
				activeUnit = dockFacility.ParentPlatform;
				activeUnit.RemoveDockFacility(dockFacility);
			}
		}
		if (activeUnit != null)
		{
			RefreshForm();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, activeUnit, bool_0: false);
		}
	}

	private void PrepareAdapter(object sender, EventArgs e)
	{
	}

	private void ReflectAdapter(object sender, EventArgs e)
	{
		_ConfigStub = !_ConfigStub;
		if (_ConfigStub)
		{
			btnHideUnderMaintenance.Text = "显示不可用";
		}
		else
		{
			btnHideUnderMaintenance.Text = "隐藏不可用";
		}
		RateServer();
	}

	private void VisitAdapter(object sender, EventArgs e)
	{
		_DispatcherStub = !_DispatcherStub;
		RestartAdapter();
	}

	private void RestartAdapter()
	{
		if (_DispatcherStub)
		{
			TGV_Boats.ExpandAllItems();
			btnExpandShipList.Text = "Collapse boat list";
		}
		else
		{
			TGV_Boats.CollapseAllItem();
			btnExpandShipList.Text = "Expand boat list";
		}
		RateServer();
	}

	private void TestAdapter(bool bool_0)
	{
		_DispatcherStub = bool_0;
		if (_DispatcherStub)
		{
			btnExpandShipList.Text = "Collapse boat list";
		}
		else
		{
			btnExpandShipList.Text = "Expand boat list";
		}
	}

	private void StopAdapter()
	{
		DataGridViewColumn dataGridViewColumn = TGV_Boats.Columns[7];
		dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
	}

	private void CancelAdapter(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 7)
		{
			m_ListenerStub = true;
		}
		else
		{
			m_ListenerStub = false;
		}
		foreach (TreeGridNode allNodesOfTGV_Boat in GetAllNodesOfTGV_Boats())
		{
			if (allNodesOfTGV_Boat.IsExpanded)
			{
				ExpandingEventArgs e2 = new ExpandingEventArgs(allNodesOfTGV_Boat);
				MoveAdapter(allNodesOfTGV_Boat, e2);
			}
		}
	}
}
