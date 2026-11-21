using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdvancedDataGridView;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AirOps : DarkSecondaryFormBase, GInterface9
{
	[CompilerGenerated]
	private sealed class ParameterMap
	{
		public Aircraft Local_myAC;

		internal bool InsertInterruptibleParam(TreeGridNode theNode)
		{
			if (theNode != null)
			{
				return theNode.Tag == Local_myAC;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class DatabaseConfigObject
	{
		public int Local_theDBID;

		internal bool PrepareInterruptibleParam(Aircraft AC)
		{
			return AC.DBID == Local_theDBID;
		}
	}

	[CompilerGenerated]
	private sealed class ConsumerProcessProducer
	{
		public AirOps Me;

		public ExpandedEventArgs Local_e;

		public List<Aircraft> Local_theCol;

		internal void ReflectInterruptibleParam()
		{
			using List<Aircraft>.Enumerator enumerator = Local_theCol.GetEnumerator();
			while (enumerator.MoveNext())
			{
				FacadeParameterMessage CS_0024_003C_003E8__locals0 = new FacadeParameterMessage
				{
					CS_0024_003C_003E8__locals1 = this,
					Local_theNode = null,
					Local_MissionText = null,
					Local_theLoadoutName = null,
					Local_theAC = enumerator.Current
				};
				if (Information.IsNothing(CS_0024_003C_003E8__locals0.Local_theAC.Loadout))
				{
					CS_0024_003C_003E8__locals0.Local_theLoadoutName = "No Loadout";
				}
				else
				{
					CS_0024_003C_003E8__locals0.Local_theLoadoutName = CS_0024_003C_003E8__locals0.Local_theAC.Loadout.Name;
				}
				if (Information.IsNothing(CS_0024_003C_003E8__locals0.Local_theAC.AssignedMissionOrPackage()))
				{
					if (Information.IsNothing(CS_0024_003C_003E8__locals0.Local_theAC.AssignedTaskPool))
					{
						CS_0024_003C_003E8__locals0.Local_MissionText = "-";
					}
					else
					{
						CS_0024_003C_003E8__locals0.Local_MissionText = CS_0024_003C_003E8__locals0.Local_theAC.AssignedTaskPool.Name + "（任务池）";
					}
				}
				else
				{
					string text = "";
					if (CS_0024_003C_003E8__locals0.Local_theAC.AI.IsEscort)
					{
						text = "，护航";
					}
					CS_0024_003C_003E8__locals0.Local_MissionText = CS_0024_003C_003E8__locals0.Local_theAC.AssignedMissionOrPackage().Name + " (" + CS_0024_003C_003E8__locals0.Local_theAC.AssignedMissionOrPackage().GetDescriptionString(Client.CurrentScenario) + text + ")";
				}
				CS_0024_003C_003E8__locals0.Local_theName = CS_0024_003C_003E8__locals0.Local_theAC.Name;
				if (CS_0024_003C_003E8__locals0.Local_theAC.GetUnitSide() != Client.CurrentSide)
				{
					CS_0024_003C_003E8__locals0.Local_theName = CS_0024_003C_003E8__locals0.Local_theName + " (" + CS_0024_003C_003E8__locals0.Local_theAC.GetUnitSide().Name + ")";
				}
				Me.TGV_Aircraft.Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					TreeGridNodeCollection nodes = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_e.Node.Nodes;
					object[] array = new object[6]
					{
						CS_0024_003C_003E8__locals0.Local_theName,
						CS_0024_003C_003E8__locals0.Local_theAC.AirOps.ConditionString,
						CS_0024_003C_003E8__locals0.Local_MissionText,
						Misc.ReadRequest(CS_0024_003C_003E8__locals0.Local_theLoadoutName),
						null,
						null
					};
					long long_ = (long)Math.Round(CS_0024_003C_003E8__locals0.Local_theAC.AirOps.ConditionTimer);
					Aircraft local_theAC = CS_0024_003C_003E8__locals0.Local_theAC;
					string string_2 = null;
					array[4] = Misc.UpdateRequest(long_, local_theAC.IsAvailableForOps(ref string_2));
					array[5] = CS_0024_003C_003E8__locals0.Local_theAC.QuickTurnaroundString();
					CS_0024_003C_003E8__locals0.Local_theNode = nodes.Add(array);
					CS_0024_003C_003E8__locals0.Local_theNode.DefaultCellStyle.Font = new Font(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Me.Font, FontStyle.Regular);
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Me.MoveComposer(CS_0024_003C_003E8__locals0.Local_theNode, CS_0024_003C_003E8__locals0.Local_theAC);
					CS_0024_003C_003E8__locals0.Local_theNode.Tag = CS_0024_003C_003E8__locals0.Local_theAC;
				});
				bool paramsImporter = Me._ParamsImporter;
				string string_ = null;
				if (paramsImporter & (CS_0024_003C_003E8__locals0.Local_theAC.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance))
				{
					CS_0024_003C_003E8__locals0.Local_theNode.Visible = false;
				}
				else
				{
					CS_0024_003C_003E8__locals0.Local_theNode.Visible = true;
				}
				if (CS_0024_003C_003E8__locals0.Local_theAC.Loadout != null && CS_0024_003C_003E8__locals0.Local_theAC.Int32_0 > 0)
				{
					CS_0024_003C_003E8__locals0.Local_theNode.Cells[3].Style.Font = new Font("微软雅黑", 8.25f, FontStyle.Underline);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class FacadeParameterMessage
	{
		public string Local_theName;

		public Aircraft Local_theAC;

		public string Local_MissionText;

		public string Local_theLoadoutName;

		public TreeGridNode Local_theNode;

		public ConsumerProcessProducer CS_0024_003C_003E8__locals1;

		internal void VisitInterruptibleParam()
		{
			TreeGridNodeCollection nodes = CS_0024_003C_003E8__locals1.Local_e.Node.Nodes;
			object[] array = new object[6]
			{
				Local_theName,
				Local_theAC.AirOps.ConditionString,
				Local_MissionText,
				Misc.ReadRequest(Local_theLoadoutName),
				null,
				null
			};
			long long_ = (long)Math.Round(Local_theAC.AirOps.ConditionTimer);
			Aircraft local_theAC = Local_theAC;
			string string_ = null;
			array[4] = Misc.UpdateRequest(long_, local_theAC.IsAvailableForOps(ref string_));
			array[5] = Local_theAC.QuickTurnaroundString();
			Local_theNode = nodes.Add(array);
			Local_theNode.DefaultCellStyle.Font = new Font(CS_0024_003C_003E8__locals1.Me.Font, FontStyle.Regular);
			CS_0024_003C_003E8__locals1.Me.MoveComposer(Local_theNode, Local_theAC);
			Local_theNode.Tag = Local_theAC;
		}
	}

	private IContainer m_RequestImporter;

	[AccessedThroughProperty("TabControl1")]
	[CompilerGenerated]
	private DarkUITabControl valueImporter;

	[AccessedThroughProperty("TabPage1")]
	[CompilerGenerated]
	private TabPage m_TokenizerImporter;

	[AccessedThroughProperty("TabPage2")]
	[CompilerGenerated]
	private TabPage m_StubImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private System.Windows.Forms.Timer _WriterImporter;

	[AccessedThroughProperty("TSL_LaunchIndividually")]
	[CompilerGenerated]
	private ToolStripButton reponseImporter;

	[AccessedThroughProperty("TSL_ReadyAC")]
	[CompilerGenerated]
	private ToolStripButton _DescriptorImporter;

	[AccessedThroughProperty("TSL_LaunchAsGroup")]
	[CompilerGenerated]
	private ToolStripButton poolImporter;

	[AccessedThroughProperty("Timer2")]
	[CompilerGenerated]
	private System.Windows.Forms.Timer filterImporter;

	[AccessedThroughProperty("TGV_Aircraft")]
	[CompilerGenerated]
	private DarkTreeGridView testsImporter;

	[AccessedThroughProperty("TSB_AbortLaunch")]
	[CompilerGenerated]
	private ToolStripButton containerImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel m_AdvisorImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_LoadoutItems")]
	private DarkDataGridView _SerializerImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_RefImporter;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private DarkLabel errorImporter;

	[AccessedThroughProperty("TSB_SetReadyTime")]
	[CompilerGenerated]
	private ToolStripButton m_CodeImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Rename")]
	private ToolStripButton _ConnectionImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Delete")]
	private ToolStripButton _ContextImporter;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel statusImporter;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel m_ProccesorImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_NumberOfSorties")]
	private DarkUIComboBox m_ConfigurationImporter;

	[AccessedThroughProperty("ToolStripSeparator2")]
	[CompilerGenerated]
	private ToolStripSeparator m_TokenImporter;

	[AccessedThroughProperty("CMenu_AirOps")]
	[CompilerGenerated]
	private ContextMenuStrip _IndexerImporter;

	[AccessedThroughProperty("TSMI_Doctrine")]
	[CompilerGenerated]
	private DarkToolStripMenuItem m_ResolverImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSMI_AssignToMission")]
	private DarkToolStripMenuItem m_PublisherImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AssignToMission")]
	private ToolStripDropDownButton serverImporter;

	[AccessedThroughProperty("TSB_Doctrine")]
	[CompilerGenerated]
	private ToolStripButton adapterImporter;

	[AccessedThroughProperty("LaunchIndividuallyToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem schemaImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("LaunchAsGroupsToolStripMenuItem")]
	private DarkToolStripMenuItem utilsImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("ReadyArmToolStripMenuItem")]
	private DarkToolStripMenuItem m_PredicateImporter;

	[AccessedThroughProperty("AbortLaunchToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _SingletonImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripSeparator3")]
	private ToolStripSeparator m_RecordImporter;

	[AccessedThroughProperty("ToolStripSeparator4")]
	[CompilerGenerated]
	private ToolStripSeparator exceptionImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("SetTimeToReadyToolStripMenuItem")]
	private DarkToolStripMenuItem attrImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("RenameToolStripMenuItem")]
	private DarkToolStripMenuItem visitorImporter;

	[AccessedThroughProperty("RemoveToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _ExporterImporter;

	[AccessedThroughProperty("AddLoadoutToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem prototypeImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Cargo")]
	private ToolStripButton m_ComparatorImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStrip1")]
	private DarkToolStrip itemImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_QuickTurnaround")]
	private DarkCheckBox m_SetterImporter;

	[AccessedThroughProperty("Status")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn mappingImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Loadout")]
	private DataGridViewTextBoxColumn tagImporter;

	[AccessedThroughProperty("QuickTurnaroundDescription")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn queueImporter;

	[AccessedThroughProperty("FlowLayoutPanel1")]
	[CompilerGenerated]
	private FlowLayoutPanel regImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Column_Description")]
	private DataGridViewLinkColumn m_PageImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("AvailableTotal")]
	private DataGridViewTextBoxColumn methodImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSL_SHIPONFIRE")]
	private ToolStripLabel systemImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddFac")]
	private ToolStripButton _BaseImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_RemoveFac")]
	private ToolStripButton policyImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("btnEXPCOL")]
	private DarkUIButton _BroadcasterImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("btnHideShowMaintenance")]
	private DarkUIButton identifierImporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddHostedUnit")]
	private ToolStripButton parserImporter;

	public HashSet<string> SelectedHosts_IDs;

	private HashSet<string> algoImporter;

	private string databaseImporter;

	private List<Aircraft> interceptorImporter;

	private List<Aircraft> m_MessageImporter;

	private MaintainScrollPosition productImporter;

	private bool _AnnotationImporter;

	private List<int> iteratorImporter;

	private int m_InitializerImporter;

	private DataTable m_RoleImporter;

	private DataTable m_FactoryImporter;

	private int attributeImporter;

	private bool m_EventImporter;

	private int m_GlobalImporter;

	private int m_WorkerImporter;

	private int _AccountImporter;

	private int _StateImporter;

	private bool _AuthenticationImporter;

	private bool _ParamsImporter;

	private Dictionary<int, int> m_InfoImporter;

	[AccessedThroughProperty("BW_TGV_Aircraft")]
	[CompilerGenerated]
	private BackgroundWorker helperImporter;

	private Keys[] _MapperImporter;

	private bool m_ManagerImporter;

	private bool m_GetterImporter;

	private bool producerImporter;

	[CompilerGenerated]
	private bool procImporter;

	internal DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return valueImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableContainer;
			DarkUITabControl darkUITabControl = valueImporter;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged -= value2;
			}
			valueImporter = value;
			darkUITabControl = valueImporter;
			if (darkUITabControl != null)
			{
				darkUITabControl.SelectedIndexChanged += value2;
			}
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenizerImporter = value;
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_StubImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StubImporter = value;
		}
	}

	[field: AccessedThroughProperty("Facilities")]
	internal TreeGridColumn Facilities
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("theStatus")]
	internal TreeGridColumn theStatus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSL_LaunchIndividually
	{
		[CompilerGenerated]
		get
		{
			return reponseImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeContainer;
			ToolStripButton toolStripButton = reponseImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			reponseImporter = value;
			toolStripButton = reponseImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSL_ReadyAC
	{
		[CompilerGenerated]
		get
		{
			return _DescriptorImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatContainer;
			ToolStripButton descriptorImporter = _DescriptorImporter;
			if (descriptorImporter != null)
			{
				descriptorImporter.Click -= value2;
			}
			_DescriptorImporter = value;
			descriptorImporter = _DescriptorImporter;
			if (descriptorImporter != null)
			{
				descriptorImporter.Click += value2;
			}
		}
	}

	internal ToolStripButton TSL_LaunchAsGroup
	{
		[CompilerGenerated]
		get
		{
			return poolImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetContainer;
			ToolStripButton toolStripButton = poolImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			poolImporter = value;
			toolStripButton = poolImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TV_Facilities")]
	internal DarkTreeView TV_Facilities
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	private DarkTreeGridView TGV_Aircraft
	{
		[CompilerGenerated]
		get
		{
			return testsImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = RemoveContainer;
			CollapsingEventHandler value3 = FindContainer;
			EventHandler value4 = ReadContainer;
			ExpandedEventHandler value5 = ConnectComposer;
			DataGridViewCellMouseEventHandler value6 = ViewComposer;
			DarkTreeGridView darkTreeGridView = testsImporter;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.CellContentClick -= value2;
				darkTreeGridView.NodeCollapsing -= value3;
				darkTreeGridView.SelectionChanged -= value4;
				darkTreeGridView.NodeExpanded -= value5;
				darkTreeGridView.ColumnHeaderMouseClick -= value6;
			}
			testsImporter = value;
			darkTreeGridView = testsImporter;
			if (darkTreeGridView != null)
			{
				darkTreeGridView.CellContentClick += value2;
				darkTreeGridView.NodeCollapsing += value3;
				darkTreeGridView.SelectionChanged += value4;
				darkTreeGridView.NodeExpanded += value5;
				darkTreeGridView.ColumnHeaderMouseClick += value6;
			}
		}
	}

	[field: AccessedThroughProperty("ToolStripSeparator1")]
	internal ToolStripSeparator ToolStripSeparator1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_AbortLaunch
	{
		[CompilerGenerated]
		get
		{
			return containerImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateContainer;
			ToolStripButton toolStripButton = containerImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			containerImporter = value;
			toolStripButton = containerImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label4")]
	internal DarkLabel Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorImporter = value;
		}
	}

	[field: AccessedThroughProperty("Label_Loadout")]
	internal DarkLabel Label_Loadout
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkDataGridView DGV_LoadoutItems
	{
		[CompilerGenerated]
		get
		{
			return _SerializerImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = LogoutContainer;
			DarkDataGridView serializerImporter = _SerializerImporter;
			if (serializerImporter != null)
			{
				serializerImporter.CellContentClick -= value2;
			}
			_SerializerImporter = value;
			serializerImporter = _SerializerImporter;
			if (serializerImporter != null)
			{
				serializerImporter.CellContentClick += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_RefImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RefImporter = value;
		}
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return errorImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			errorImporter = value;
		}
	}

	internal ToolStripButton TSB_SetReadyTime
	{
		[CompilerGenerated]
		get
		{
			return m_CodeImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestContainer;
			ToolStripButton codeImporter = m_CodeImporter;
			if (codeImporter != null)
			{
				codeImporter.Click -= value2;
			}
			m_CodeImporter = value;
			codeImporter = m_CodeImporter;
			if (codeImporter != null)
			{
				codeImporter.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Rename
	{
		[CompilerGenerated]
		get
		{
			return _ConnectionImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitContainer;
			ToolStripButton connectionImporter = _ConnectionImporter;
			if (connectionImporter != null)
			{
				connectionImporter.Click -= value2;
			}
			_ConnectionImporter = value;
			connectionImporter = _ConnectionImporter;
			if (connectionImporter != null)
			{
				connectionImporter.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Delete
	{
		[CompilerGenerated]
		get
		{
			return _ContextImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelContainer;
			ToolStripButton contextImporter = _ContextImporter;
			if (contextImporter != null)
			{
				contextImporter.Click -= value2;
			}
			_ContextImporter = value;
			contextImporter = _ContextImporter;
			if (contextImporter != null)
			{
				contextImporter.Click += value2;
			}
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return statusImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			statusImporter = value;
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return m_ProccesorImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProccesorImporter = value;
		}
	}

	[field: AccessedThroughProperty("Label_QuickTurnaroundInfo")]
	internal DarkLabel Label_QuickTurnaroundInfo
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox Combo_NumberOfSorties
	{
		[CompilerGenerated]
		get
		{
			return m_ConfigurationImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListContainer;
			DarkUIComboBox configurationImporter = m_ConfigurationImporter;
			if (configurationImporter != null)
			{
				configurationImporter.SelectedIndexChanged -= value2;
			}
			m_ConfigurationImporter = value;
			configurationImporter = m_ConfigurationImporter;
			if (configurationImporter != null)
			{
				configurationImporter.SelectedIndexChanged += value2;
			}
		}
	}

	internal ToolStripSeparator ToolStripSeparator2
	{
		[CompilerGenerated]
		get
		{
			return m_TokenImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenImporter = value;
		}
	}

	internal DarkToolStripMenuItem TSMI_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcContainer;
			DarkToolStripMenuItem resolverImporter = m_ResolverImporter;
			if (resolverImporter != null)
			{
				resolverImporter.Click -= value2;
			}
			m_ResolverImporter = value;
			resolverImporter = m_ResolverImporter;
			if (resolverImporter != null)
			{
				resolverImporter.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem TSMI_AssignToMission
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateContainer;
			ToolStripItemClickedEventHandler value3 = CountComposer;
			DarkToolStripMenuItem publisherImporter = m_PublisherImporter;
			if (publisherImporter != null)
			{
				publisherImporter.Click -= value2;
				publisherImporter.DropDownItemClicked -= value3;
			}
			m_PublisherImporter = value;
			publisherImporter = m_PublisherImporter;
			if (publisherImporter != null)
			{
				publisherImporter.Click += value2;
				publisherImporter.DropDownItemClicked += value3;
			}
		}
	}

	internal ToolStripDropDownButton TSB_AssignToMission
	{
		[CompilerGenerated]
		get
		{
			return serverImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AssetContainer;
			EventHandler value3 = PrintContainer;
			ToolStripItemClickedEventHandler value4 = DefineContainer;
			ToolStripDropDownButton toolStripDropDownButton = serverImporter;
			if (toolStripDropDownButton != null)
			{
				toolStripDropDownButton.Click -= value2;
				toolStripDropDownButton.DropDownOpening -= value3;
				toolStripDropDownButton.DropDownItemClicked -= value4;
			}
			serverImporter = value;
			toolStripDropDownButton = serverImporter;
			if (toolStripDropDownButton != null)
			{
				toolStripDropDownButton.Click += value2;
				toolStripDropDownButton.DropDownOpening += value3;
				toolStripDropDownButton.DropDownItemClicked += value4;
			}
		}
	}

	internal ToolStripButton TSB_Doctrine
	{
		[CompilerGenerated]
		get
		{
			return adapterImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeContainer;
			ToolStripButton toolStripButton = adapterImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			adapterImporter = value;
			toolStripButton = adapterImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem LaunchIndividuallyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return schemaImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryContainer;
			DarkToolStripMenuItem darkToolStripMenuItem = schemaImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			schemaImporter = value;
			darkToolStripMenuItem = schemaImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem LaunchAsGroupsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return utilsImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetContainer;
			DarkToolStripMenuItem darkToolStripMenuItem = utilsImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			utilsImporter = value;
			darkToolStripMenuItem = utilsImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem ReadyArmToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapContainer;
			DarkToolStripMenuItem predicateImporter = m_PredicateImporter;
			if (predicateImporter != null)
			{
				predicateImporter.Click -= value2;
			}
			m_PredicateImporter = value;
			predicateImporter = m_PredicateImporter;
			if (predicateImporter != null)
			{
				predicateImporter.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem AbortLaunchToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _SingletonImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortContainer;
			DarkToolStripMenuItem singletonImporter = _SingletonImporter;
			if (singletonImporter != null)
			{
				singletonImporter.Click -= value2;
			}
			_SingletonImporter = value;
			singletonImporter = _SingletonImporter;
			if (singletonImporter != null)
			{
				singletonImporter.Click += value2;
			}
		}
	}

	internal ToolStripSeparator ToolStripSeparator3
	{
		[CompilerGenerated]
		get
		{
			return m_RecordImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RecordImporter = value;
		}
	}

	internal ToolStripSeparator ToolStripSeparator4
	{
		[CompilerGenerated]
		get
		{
			return exceptionImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exceptionImporter = value;
		}
	}

	internal DarkToolStripMenuItem SetTimeToReadyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return attrImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushContainer;
			DarkToolStripMenuItem darkToolStripMenuItem = attrImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			attrImporter = value;
			darkToolStripMenuItem = attrImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem RenameToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return visitorImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotContainer;
			DarkToolStripMenuItem darkToolStripMenuItem = visitorImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			visitorImporter = value;
			darkToolStripMenuItem = visitorImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem RemoveToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _ExporterImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectContainer;
			DarkToolStripMenuItem exporterImporter = _ExporterImporter;
			if (exporterImporter != null)
			{
				exporterImporter.Click -= value2;
			}
			_ExporterImporter = value;
			exporterImporter = _ExporterImporter;
			if (exporterImporter != null)
			{
				exporterImporter.Click += value2;
			}
		}
	}

	internal DarkToolStripMenuItem AddLoadoutToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return prototypeImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterContainer;
			DarkToolStripMenuItem darkToolStripMenuItem = prototypeImporter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			prototypeImporter = value;
			darkToolStripMenuItem = prototypeImporter;
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
			return m_ComparatorImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneComposer;
			ToolStripButton comparatorImporter = m_ComparatorImporter;
			if (comparatorImporter != null)
			{
				comparatorImporter.Click -= value2;
			}
			m_ComparatorImporter = value;
			comparatorImporter = m_ComparatorImporter;
			if (comparatorImporter != null)
			{
				comparatorImporter.Click += value2;
			}
		}
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return itemImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			itemImporter = value;
		}
	}

	internal DarkCheckBox CB_QuickTurnaround
	{
		[CompilerGenerated]
		get
		{
			return m_SetterImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostContainer;
			DarkCheckBox setterImporter = m_SetterImporter;
			if (setterImporter != null)
			{
				setterImporter.CheckedChanged -= value2;
			}
			m_SetterImporter = value;
			setterImporter = m_SetterImporter;
			if (setterImporter != null)
			{
				setterImporter.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Aircraft")]
	internal TreeGridColumn Aircraft
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Status
	{
		[CompilerGenerated]
		get
		{
			return mappingImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mappingImporter = value;
		}
	}

	[field: AccessedThroughProperty("Mission")]
	internal DataGridViewTextBoxColumn Mission
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Loadout
	{
		[CompilerGenerated]
		get
		{
			return tagImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tagImporter = value;
		}
	}

	[field: AccessedThroughProperty("TimeToReady")]
	internal DataGridViewTextBoxColumn TimeToReady
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn QuickTurnaroundDescription
	{
		[CompilerGenerated]
		get
		{
			return queueImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			queueImporter = value;
		}
	}

	internal FlowLayoutPanel FlowLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return regImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regImporter = value;
		}
	}

	[field: AccessedThroughProperty("ComponentID")]
	internal DataGridViewTextBoxColumn ComponentID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewLinkColumn Column_Description
	{
		[CompilerGenerated]
		get
		{
			return m_PageImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageImporter = value;
		}
	}

	[field: AccessedThroughProperty("Available")]
	internal DataGridViewTextBoxColumn Available
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn AvailableTotal
	{
		[CompilerGenerated]
		get
		{
			return methodImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodImporter = value;
		}
	}

	[field: AccessedThroughProperty("FloodAlert")]
	internal ToolStripLabel FloodAlert
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripLabel TSL_SHIPONFIRE
	{
		[CompilerGenerated]
		get
		{
			return systemImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			systemImporter = value;
		}
	}

	[field: AccessedThroughProperty("TS_Edit")]
	internal DarkToolStrip TS_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton Button_AddFac
	{
		[CompilerGenerated]
		get
		{
			return _BaseImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyComposer;
			ToolStripButton baseImporter = _BaseImporter;
			if (baseImporter != null)
			{
				baseImporter.Click -= value2;
			}
			_BaseImporter = value;
			baseImporter = _BaseImporter;
			if (baseImporter != null)
			{
				baseImporter.Click += value2;
			}
		}
	}

	internal ToolStripButton Button_RemoveFac
	{
		[CompilerGenerated]
		get
		{
			return policyImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeComposer;
			ToolStripButton toolStripButton = policyImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			policyImporter = value;
			toolStripButton = policyImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal DarkUIButton DarkUIButton_0
	{
		[CompilerGenerated]
		get
		{
			return _BroadcasterImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchComposer;
			DarkUIButton broadcasterImporter = _BroadcasterImporter;
			if (broadcasterImporter != null)
			{
				broadcasterImporter.Click -= value2;
			}
			_BroadcasterImporter = value;
			broadcasterImporter = _BroadcasterImporter;
			if (broadcasterImporter != null)
			{
				broadcasterImporter.Click += value2;
			}
		}
	}

	internal DarkUIButton btnHideShowMaintenance
	{
		[CompilerGenerated]
		get
		{
			return identifierImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutComposer;
			DarkUIButton darkUIButton = identifierImporter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			identifierImporter = value;
			darkUIButton = identifierImporter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("lblCapacity")]
	internal DarkLabel lblCapacity
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_AddHostedUnit
	{
		[CompilerGenerated]
		get
		{
			return parserImporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateComposer;
			ToolStripButton toolStripButton = parserImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			parserImporter = value;
			toolStripButton = parserImporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	public bool AddingUnit
	{
		[CompilerGenerated]
		get
		{
			return procImporter;
		}
		[CompilerGenerated]
		set
		{
			procImporter = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal System.Windows.Forms.Timer ExcludeComposer()
	{
		return _WriterImporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void IncludeComposer(System.Windows.Forms.Timer timer_0)
	{
		EventHandler value = GetContainer;
		System.Windows.Forms.Timer writerImporter = _WriterImporter;
		if (writerImporter != null)
		{
			writerImporter.Tick -= value;
		}
		_WriterImporter = timer_0;
		writerImporter = _WriterImporter;
		if (writerImporter != null)
		{
			writerImporter.Tick += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal System.Windows.Forms.Timer InstantiateComposer()
	{
		return filterImporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CreateComposer(System.Windows.Forms.Timer timer_0)
	{
		filterImporter = timer_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal ContextMenuStrip CustomizeModel()
	{
		return _IndexerImporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CloneModel(ContextMenuStrip contextMenuStrip_0)
	{
		CancelEventHandler value = RevertContainer;
		ContextMenuStrip indexerImporter = _IndexerImporter;
		if (indexerImporter != null)
		{
			indexerImporter.Opening -= value;
		}
		_IndexerImporter = contextMenuStrip_0;
		indexerImporter = _IndexerImporter;
		if (indexerImporter != null)
		{
			indexerImporter.Opening += value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker DeleteAdvisor()
	{
		return helperImporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void AddAdvisor(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = CalculateContainer;
		RunWorkerCompletedEventHandler value2 = PopContainer;
		BackgroundWorker backgroundWorker = helperImporter;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		helperImporter = backgroundWorker_0;
		backgroundWorker = helperImporter;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	public AirOps()
	{
		base.FormClosing += ComputeContainer;
		base.Shown += InstantiateContainer;
		base.KeyDown += ReflectContainer;
		base.FormClosed += StartContainer;
		base.Load += CustomizeComposer;
		SelectedHosts_IDs = new HashSet<string>();
		algoImporter = new HashSet<string>();
		interceptorImporter = new List<Aircraft>();
		m_MessageImporter = new List<Aircraft>();
		productImporter = new MaintainScrollPosition();
		iteratorImporter = new List<int>();
		m_RoleImporter = new DataTable();
		m_FactoryImporter = new DataTable();
		_ParamsImporter = false;
		m_InfoImporter = new Dictionary<int, int>();
		AddAdvisor(new BackgroundWorker());
		_MapperImporter = new Keys[2]
		{
			Keys.F6,
			Keys.Escape
		};
		m_ManagerImporter = false;
		m_GetterImporter = false;
		producerImporter = false;
		AddingUnit = false;
		DestroyContainer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_RequestImporter != null)
			{
				m_RequestImporter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DestroyContainer()
	{
		m_RequestImporter = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		CloneModel(new ContextMenuStrip(m_RequestImporter));
		LaunchIndividuallyToolStripMenuItem = new DarkToolStripMenuItem();
		LaunchAsGroupsToolStripMenuItem = new DarkToolStripMenuItem();
		ReadyArmToolStripMenuItem = new DarkToolStripMenuItem();
		AbortLaunchToolStripMenuItem = new DarkToolStripMenuItem();
		ToolStripSeparator3 = new ToolStripSeparator();
		TSMI_Doctrine = new DarkToolStripMenuItem();
		TSMI_AssignToMission = new DarkToolStripMenuItem();
		ToolStripSeparator4 = new ToolStripSeparator();
		SetTimeToReadyToolStripMenuItem = new DarkToolStripMenuItem();
		RenameToolStripMenuItem = new DarkToolStripMenuItem();
		RemoveToolStripMenuItem = new DarkToolStripMenuItem();
		AddLoadoutToolStripMenuItem = new DarkToolStripMenuItem();
		Facilities = new TreeGridColumn();
		theStatus = new TreeGridColumn();
		IncludeComposer(new System.Windows.Forms.Timer(m_RequestImporter));
		CreateComposer(new System.Windows.Forms.Timer(m_RequestImporter));
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		CB_QuickTurnaround = new DarkCheckBox();
		Combo_NumberOfSorties = new DarkUIComboBox();
		Label_QuickTurnaroundInfo = new DarkLabel();
		DarkUIButton_0 = new DarkUIButton();
		btnHideShowMaintenance = new DarkUIButton();
		lblCapacity = new DarkLabel();
		Label3 = new DarkLabel();
		Label7 = new DarkLabel();
		Label8 = new DarkLabel();
		Label6 = new DarkLabel();
		Label1 = new DarkLabel();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		Label2 = new DarkLabel();
		Label_Loadout = new DarkLabel();
		DGV_LoadoutItems = new DarkDataGridView();
		ComponentID = new DataGridViewTextBoxColumn();
		Column_Description = new DataGridViewLinkColumn();
		Available = new DataGridViewTextBoxColumn();
		AvailableTotal = new DataGridViewTextBoxColumn();
		TGV_Aircraft = new DarkTreeGridView();
		Aircraft = new TreeGridColumn();
		Status = new DataGridViewTextBoxColumn();
		Mission = new DataGridViewTextBoxColumn();
		Loadout = new DataGridViewTextBoxColumn();
		TimeToReady = new DataGridViewTextBoxColumn();
		QuickTurnaroundDescription = new DataGridViewTextBoxColumn();
		ToolStrip1 = new DarkToolStrip();
		FloodAlert = new ToolStripLabel();
		TSL_SHIPONFIRE = new ToolStripLabel();
		TSL_LaunchIndividually = new ToolStripButton();
		TSL_LaunchAsGroup = new ToolStripButton();
		TSL_ReadyAC = new ToolStripButton();
		TSB_AbortLaunch = new ToolStripButton();
		ToolStripSeparator2 = new ToolStripSeparator();
		TSB_Doctrine = new ToolStripButton();
		TSB_AssignToMission = new ToolStripDropDownButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_SetReadyTime = new ToolStripButton();
		TSB_Rename = new ToolStripButton();
		TSB_Delete = new ToolStripButton();
		TSB_AddHostedUnit = new ToolStripButton();
		TSB_Cargo = new ToolStripButton();
		TabPage2 = new TabPage();
		TV_Facilities = new DarkTreeView();
		TS_Edit = new DarkToolStrip();
		Button_AddFac = new ToolStripButton();
		Button_RemoveFac = new ToolStripButton();
		CustomizeModel().SuspendLayout();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		FlowLayoutPanel1.SuspendLayout();
		((ISupportInitialize)DGV_LoadoutItems).BeginInit();
		((ISupportInitialize)TGV_Aircraft).BeginInit();
		ToolStrip1.SuspendLayout();
		TabPage2.SuspendLayout();
		TS_Edit.SuspendLayout();
		SuspendLayout();
		CustomizeModel().ImageScalingSize = new Size(24, 24);
		CustomizeModel().Items.AddRange(new ToolStripItem[12]
		{
			LaunchIndividuallyToolStripMenuItem, LaunchAsGroupsToolStripMenuItem, ReadyArmToolStripMenuItem, AbortLaunchToolStripMenuItem, ToolStripSeparator3, TSMI_Doctrine, TSMI_AssignToMission, ToolStripSeparator4, SetTimeToReadyToolStripMenuItem, RenameToolStripMenuItem,
			RemoveToolStripMenuItem, AddLoadoutToolStripMenuItem
		});
		CustomizeModel().Name = "CMenu_Unit";
		CustomizeModel().Size = new Size(205, 232);
		LaunchIndividuallyToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		LaunchIndividuallyToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		LaunchIndividuallyToolStripMenuItem.Name = "LaunchIndividuallyToolStripMenuItem";
		LaunchIndividuallyToolStripMenuItem.Size = new Size(204, 24);
		LaunchIndividuallyToolStripMenuItem.Text = "单独出动";
		LaunchAsGroupsToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		LaunchAsGroupsToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		LaunchAsGroupsToolStripMenuItem.Name = "LaunchAsGroupsToolStripMenuItem";
		LaunchAsGroupsToolStripMenuItem.Size = new Size(204, 24);
		LaunchAsGroupsToolStripMenuItem.Text = "作为编队出动";
		ReadyArmToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		ReadyArmToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		ReadyArmToolStripMenuItem.Name = "ReadyArmToolStripMenuItem";
		ReadyArmToolStripMenuItem.Size = new Size(204, 24);
		ReadyArmToolStripMenuItem.Text = "准备/装弹";
		AbortLaunchToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		AbortLaunchToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		AbortLaunchToolStripMenuItem.Name = "AbortLaunchToolStripMenuItem";
		AbortLaunchToolStripMenuItem.Size = new Size(204, 24);
		AbortLaunchToolStripMenuItem.Text = "中止出动";
		ToolStripSeparator3.Name = "ToolStripSeparator3";
		ToolStripSeparator3.Size = new Size(201, 6);
		TSMI_Doctrine.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_Doctrine.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_Doctrine.Name = "TSMI_Doctrine";
		TSMI_Doctrine.Size = new Size(204, 24);
		TSMI_Doctrine.Text = "条令";
		TSMI_AssignToMission.BackColor = Color.FromArgb(60, 63, 65);
		TSMI_AssignToMission.ForeColor = Color.FromArgb(220, 220, 220);
		TSMI_AssignToMission.Name = "TSMI_AssignToMission";
		TSMI_AssignToMission.Size = new Size(204, 24);
		TSMI_AssignToMission.Text = "分配给任务";
		ToolStripSeparator4.Name = "ToolStripSeparator4";
		ToolStripSeparator4.Size = new Size(201, 6);
		SetTimeToReadyToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		SetTimeToReadyToolStripMenuItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		SetTimeToReadyToolStripMenuItem.ForeColor = Color.IndianRed;
		SetTimeToReadyToolStripMenuItem.Name = "SetTimeToReadyToolStripMenuItem";
		SetTimeToReadyToolStripMenuItem.Size = new Size(204, 24);
		SetTimeToReadyToolStripMenuItem.Text = "设置就绪时间";
		RenameToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		RenameToolStripMenuItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		RenameToolStripMenuItem.ForeColor = Color.IndianRed;
		RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
		RenameToolStripMenuItem.Size = new Size(204, 24);
		RenameToolStripMenuItem.Text = "改名";
		RemoveToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		RemoveToolStripMenuItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		RemoveToolStripMenuItem.ForeColor = Color.IndianRed;
		RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
		RemoveToolStripMenuItem.Size = new Size(204, 24);
		RemoveToolStripMenuItem.Text = "删除";
		AddLoadoutToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		AddLoadoutToolStripMenuItem.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		AddLoadoutToolStripMenuItem.ForeColor = Color.IndianRed;
		AddLoadoutToolStripMenuItem.Name = "AddLoadoutToolStripMenuItem";
		AddLoadoutToolStripMenuItem.Size = new Size(204, 24);
		AddLoadoutToolStripMenuItem.Text = "将挂载添加到弹仓";
		Facilities.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Facilities.DefaultNodeImage = null;
		Facilities.HeaderText = "设施和飞机";
		Facilities.MinimumWidth = 8;
		Facilities.Name = "Facilities";
		Facilities.ReadOnly = true;
		Facilities.Resizable = DataGridViewTriState.True;
		Facilities.SortMode = DataGridViewColumnSortMode.NotSortable;
		theStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		theStatus.DefaultNodeImage = null;
		theStatus.HeaderText = "状态";
		theStatus.MinimumWidth = 8;
		theStatus.Name = "theStatus";
		theStatus.ReadOnly = true;
		theStatus.SortMode = DataGridViewColumnSortMode.NotSortable;
		ExcludeComposer().Interval = 1000;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Dock = DockStyle.Fill;
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(0, 0);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(1290, 571);
		TabControl1.TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(FlowLayoutPanel1);
		TabPage1.Controls.Add(Label3);
		TabPage1.Controls.Add(Label7);
		TabPage1.Controls.Add(Label8);
		TabPage1.Controls.Add(Label6);
		TabPage1.Controls.Add(Label1);
		TabPage1.Controls.Add(Label5);
		TabPage1.Controls.Add(Label4);
		TabPage1.Controls.Add(Label2);
		TabPage1.Controls.Add(Label_Loadout);
		TabPage1.Controls.Add(DGV_LoadoutItems);
		TabPage1.Controls.Add(TGV_Aircraft);
		TabPage1.Controls.Add(ToolStrip1);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(1282, 543);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "飞机状态";
		FlowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		FlowLayoutPanel1.BackColor = Color.FromArgb(60, 63, 65);
		FlowLayoutPanel1.Controls.Add(CB_QuickTurnaround);
		FlowLayoutPanel1.Controls.Add(Combo_NumberOfSorties);
		FlowLayoutPanel1.Controls.Add(Label_QuickTurnaroundInfo);
		FlowLayoutPanel1.Controls.Add(DarkUIButton_0);
		FlowLayoutPanel1.Controls.Add(btnHideShowMaintenance);
		FlowLayoutPanel1.Controls.Add(lblCapacity);
		FlowLayoutPanel1.Location = new Point(3, 309);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(1276, 31);
		FlowLayoutPanel1.TabIndex = 36;
		CB_QuickTurnaround.Anchor = AnchorStyles.Left;
		CB_QuickTurnaround.Location = new Point(3, 6);
		CB_QuickTurnaround.Name = "CB_QuickTurnaround";
		CB_QuickTurnaround.Size = new Size(148, 17);
		CB_QuickTurnaround.TabIndex = 32;
		CB_QuickTurnaround.Text = "启用快速再次出动";
		Combo_NumberOfSorties.Anchor = AnchorStyles.Left;
		Combo_NumberOfSorties.BackColor = Color.FromArgb(60, 63, 65);
		Combo_NumberOfSorties.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_NumberOfSorties.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_NumberOfSorties.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_NumberOfSorties.FormattingEnabled = true;
		Combo_NumberOfSorties.Location = new Point(157, 3);
		Combo_NumberOfSorties.Name = "Combo_NumberOfSorties";
		Combo_NumberOfSorties.Size = new Size(166, 24);
		Combo_NumberOfSorties.TabIndex = 33;
		Label_QuickTurnaroundInfo.Anchor = AnchorStyles.Left;
		Label_QuickTurnaroundInfo.AutoSize = true;
		Label_QuickTurnaroundInfo.ForeColor = Color.FromArgb(220, 220, 220);
		Label_QuickTurnaroundInfo.Location = new Point(329, 5);
		Label_QuickTurnaroundInfo.Name = "Label_QuickTurnaroundInfo";
		Label_QuickTurnaroundInfo.Size = new Size(0, 20);
		Label_QuickTurnaroundInfo.TabIndex = 34;
		DarkUIButton_0.BackColor = Color.Transparent;
		DarkUIButton_0.DialogResult = DialogResult.None;
		DarkUIButton_0.Dock = DockStyle.Right;
		DarkUIButton_0.ForeColor = SystemColors.Control;
		DarkUIButton_0.Location = new Point(335, 3);
		DarkUIButton_0.Name = "btnEXPCOL";
		DarkUIButton_0.RoundRadius = 0;
		DarkUIButton_0.Size = new Size(133, 24);
		DarkUIButton_0.TabIndex = 35;
		DarkUIButton_0.Text = "Expand Aircraft List";
		btnHideShowMaintenance.BackColor = Color.Transparent;
		btnHideShowMaintenance.DialogResult = DialogResult.None;
		btnHideShowMaintenance.Dock = DockStyle.Right;
		btnHideShowMaintenance.ForeColor = SystemColors.Control;
		btnHideShowMaintenance.Location = new Point(474, 3);
		btnHideShowMaintenance.Name = "btnHideShowMaintenance";
		btnHideShowMaintenance.RoundRadius = 0;
		btnHideShowMaintenance.Size = new Size(114, 24);
		btnHideShowMaintenance.TabIndex = 36;
		btnHideShowMaintenance.Text = "隐藏不可用";
		lblCapacity.Anchor = AnchorStyles.Right;
		lblCapacity.AutoSize = true;
		lblCapacity.ForeColor = Color.FromArgb(220, 220, 220);
		lblCapacity.Location = new Point(594, 5);
		lblCapacity.Name = "lblCapacity";
		lblCapacity.Size = new Size(111, 20);
		lblCapacity.TabIndex = 37;
		lblCapacity.Text = "设施容量";
		lblCapacity.TextAlign = ContentAlignment.MiddleRight;
		Label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(655, 412);
		Label3.MaximumSize = new Size(400, 40);
		Label3.MinimumSize = new Size(400, 40);
		Label3.Name = "Label3";
		Label3.Size = new Size(400, 40);
		Label3.TabIndex = 35;
		Label3.Text = "武器状态";
		Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(655, 483);
		Label7.Name = "Label7";
		Label7.Size = new Size(173, 20);
		Label7.TabIndex = 31;
		Label7.Text = "NumberOfLoadoutsTotal";
		Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(655, 498);
		Label8.Name = "Label8";
		Label8.Size = new Size(281, 20);
		Label8.TabIndex = 30;
		Label8.Text = "NumberOfLoadoutsTotal_MandatoryOnly";
		Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(655, 468);
		Label6.Name = "Label6";
		Label6.Size = new Size(190, 20);
		Label6.TabIndex = 29;
		Label6.Text = "NumberOfLoadoutsOnBase";
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(655, 373);
		Label1.MaximumSize = new Size(400, 38);
		Label1.MinimumSize = new Size(400, 38);
		Label1.Name = "Label1";
		Label1.Size = new Size(400, 38);
		Label1.TabIndex = 28;
		Label1.Text = "RangeProfile";
		Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(655, 453);
		Label5.Name = "Label5";
		Label5.Size = new Size(104, 20);
		Label5.TabIndex = 27;
		Label5.Text = "攻击高度";
		Label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(655, 358);
		Label4.Name = "Label4";
		Label4.Size = new Size(84, 20);
		Label4.TabIndex = 26;
		Label4.Text = "TimeOfDay";
		Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(655, 343);
		Label2.Name = "Label2";
		Label2.Size = new Size(170, 20);
		Label2.TabIndex = 24;
		Label2.Text = "挂载类型描述";
		Label_Loadout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label_Loadout.AutoSize = true;
		Label_Loadout.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Loadout.Location = new Point(3, 347);
		Label_Loadout.Name = "Label_Loadout";
		Label_Loadout.Size = new Size(117, 20);
		Label_Loadout.TabIndex = 23;
		Label_Loadout.Text = "挂载细节：";
		DGV_LoadoutItems.AllowUserToAddRows = false;
		DGV_LoadoutItems.AllowUserToDeleteRows = false;
		DGV_LoadoutItems.AllowUserToOrderColumns = true;
		DGV_LoadoutItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DGV_LoadoutItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		DGV_LoadoutItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		DGV_LoadoutItems.BackgroundColor = Color.FromArgb(43, 43, 43);
		DGV_LoadoutItems.BorderStyle = BorderStyle.Fixed3D;
		DGV_LoadoutItems.CausesValidation = false;
		DGV_LoadoutItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
		DGV_LoadoutItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.LightGray;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		DGV_LoadoutItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		DGV_LoadoutItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_LoadoutItems.Columns.AddRange(ComponentID, Column_Description, Available, AvailableTotal);
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		DGV_LoadoutItems.DefaultCellStyle = dataGridViewCellStyle3;
		DGV_LoadoutItems.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_LoadoutItems.EnableHeadersVisualStyles = false;
		DGV_LoadoutItems.Location = new Point(3, 363);
		DGV_LoadoutItems.MultiSelect = false;
		DGV_LoadoutItems.Name = "DGV_LoadoutItems";
		DGV_LoadoutItems.RowHeadersVisible = false;
		DGV_LoadoutItems.RowHeadersWidth = 20;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.LightGray;
		DGV_LoadoutItems.RowsDefaultCellStyle = dataGridViewCellStyle4;
		DGV_LoadoutItems.RowTemplate.Height = 15;
		DGV_LoadoutItems.RowTemplate.Resizable = DataGridViewTriState.False;
		DGV_LoadoutItems.ScrollBars = ScrollBars.Vertical;
		DGV_LoadoutItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_LoadoutItems.Size = new Size(650, 149);
		DGV_LoadoutItems.TabIndex = 22;
		ComponentID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ComponentID.DataPropertyName = "ComponentID";
		ComponentID.HeaderText = "ID";
		ComponentID.MinimumWidth = 8;
		ComponentID.Name = "ComponentID";
		ComponentID.SortMode = DataGridViewColumnSortMode.NotSortable;
		ComponentID.Visible = false;
		Column_Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		Column_Description.DataPropertyName = "Item";
		Column_Description.HeaderText = "弹药储备（点击查询）";
		Column_Description.LinkBehavior = LinkBehavior.HoverUnderline;
		Column_Description.LinkColor = Color.LightBlue;
		Column_Description.MinimumWidth = 470;
		Column_Description.Name = "Column_Description";
		Column_Description.ReadOnly = true;
		Column_Description.Resizable = DataGridViewTriState.True;
		Column_Description.TrackVisitedState = false;
		Column_Description.Width = 470;
		Available.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Available.DataPropertyName = "Available";
		Available.HeaderText = "＃可用数量，弹仓";
		Available.MinimumWidth = 90;
		Available.Name = "Available";
		Available.ReadOnly = true;
		Available.SortMode = DataGridViewColumnSortMode.NotSortable;
		Available.ToolTipText = "The number of weapons available in the base's ammo dump";
		AvailableTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		AvailableTotal.DataPropertyName = "AvailableTotal";
		AvailableTotal.HeaderText = "# 可用,弹药+飞机挂载";
		AvailableTotal.MinimumWidth = 90;
		AvailableTotal.Name = "AvailableTotal";
		AvailableTotal.ReadOnly = true;
		AvailableTotal.SortMode = DataGridViewColumnSortMode.NotSortable;
		AvailableTotal.ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		TGV_Aircraft.AllowUserToAddRows = false;
		TGV_Aircraft.AllowUserToDeleteRows = false;
		TGV_Aircraft.AllowUserToOrderColumns = true;
		TGV_Aircraft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_Aircraft.BackgroundColor = Color.FromArgb(60, 63, 65);
		TGV_Aircraft.BorderStyle = BorderStyle.Fixed3D;
		TGV_Aircraft.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Aircraft.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		TGV_Aircraft.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		TGV_Aircraft.ColumnHeadersHeight = 33;
		TGV_Aircraft.Columns.AddRange(Aircraft, Status, Mission, Loadout, TimeToReady, QuickTurnaroundDescription);
		TGV_Aircraft.ContextMenuStrip = CustomizeModel();
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
		TGV_Aircraft.DefaultCellStyle = dataGridViewCellStyle6;
		TGV_Aircraft.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Aircraft.EnableHeadersVisualStyles = false;
		TGV_Aircraft.ImageList = null;
		TGV_Aircraft.Location = new Point(3, 3);
		TGV_Aircraft.Name = "TGV_Aircraft";
		TGV_Aircraft.RowHeadersVisible = false;
		TGV_Aircraft.RowHeadersWidth = 20;
		TGV_Aircraft.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Aircraft.ShowLines = false;
		TGV_Aircraft.Size = new Size(1276, 300);
		TGV_Aircraft.TabIndex = 7;
		Aircraft.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle.Font = new Font("Segoe UI", 8.25f, FontStyle.Underline);
		dataGridViewCellStyle.ForeColor = Color.Blue;
		Aircraft.DefaultCellStyle = dataGridViewCellStyle;
		Aircraft.DefaultNodeImage = null;
		Aircraft.HeaderText = "飞机（点击查询）";
		Aircraft.MinimumWidth = 8;
		Aircraft.Name = "Aircraft";
		Aircraft.ReadOnly = true;
		Aircraft.Resizable = DataGridViewTriState.True;
		Aircraft.SortMode = DataGridViewColumnSortMode.NotSortable;
		Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Status.FillWeight = 50f;
		Status.HeaderText = "状态";
		Status.MinimumWidth = 8;
		Status.Name = "Status";
		Status.ReadOnly = true;
		Status.Resizable = DataGridViewTriState.True;
		Status.SortMode = DataGridViewColumnSortMode.NotSortable;
		Mission.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Mission.FillWeight = 50f;
		Mission.HeaderText = "任务";
		Mission.MinimumWidth = 8;
		Mission.Name = "Mission";
		Mission.ReadOnly = true;
		Mission.Resizable = DataGridViewTriState.True;
		Mission.SortMode = DataGridViewColumnSortMode.NotSortable;
		Loadout.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Loadout.HeaderText = "挂载";
		Loadout.MinimumWidth = 8;
		Loadout.Name = "Loadout";
		Loadout.ReadOnly = true;
		Loadout.Resizable = DataGridViewTriState.True;
		Loadout.SortMode = DataGridViewColumnSortMode.NotSortable;
		TimeToReady.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		TimeToReady.FillWeight = 40f;
		TimeToReady.HeaderText = "就绪时间";
		TimeToReady.MinimumWidth = 8;
		TimeToReady.Name = "TimeToReady";
		TimeToReady.ReadOnly = true;
		TimeToReady.Resizable = DataGridViewTriState.True;
		TimeToReady.SortMode = DataGridViewColumnSortMode.NotSortable;
		QuickTurnaroundDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		QuickTurnaroundDescription.FillWeight = 40f;
		QuickTurnaroundDescription.HeaderText = "快速再次出动";
		QuickTurnaroundDescription.MinimumWidth = 97;
		QuickTurnaroundDescription.Name = "QuickTurnaroundDescription";
		QuickTurnaroundDescription.ReadOnly = true;
		QuickTurnaroundDescription.Resizable = DataGridViewTriState.True;
		QuickTurnaroundDescription.SortMode = DataGridViewColumnSortMode.NotSortable;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.Dock = DockStyle.Bottom;
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.ImageScalingSize = new Size(20, 20);
		ToolStrip1.Items.AddRange(new ToolStripItem[15]
		{
			FloodAlert, TSL_SHIPONFIRE, TSL_LaunchIndividually, TSL_LaunchAsGroup, TSL_ReadyAC, TSB_AbortLaunch, ToolStripSeparator2, TSB_Doctrine, TSB_AssignToMission, ToolStripSeparator1,
			TSB_SetReadyTime, TSB_Rename, TSB_Delete, TSB_AddHostedUnit, TSB_Cargo
		});
		ToolStrip1.Location = new Point(3, 513);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(1, 0, 2, 0);
		ToolStrip1.Size = new Size(1276, 27);
		ToolStrip1.Stretch = true;
		ToolStrip1.TabIndex = 1;
		ToolStrip1.Text = "ToolStrip1";
		FloodAlert.ActiveLinkColor = Color.Blue;
		FloodAlert.BackColor = Color.Black;
		FloodAlert.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		FloodAlert.ForeColor = Color.DodgerBlue;
		FloodAlert.Name = "FloodAlert";
		FloodAlert.Size = new Size(0, 24);
		TSL_SHIPONFIRE.BackColor = Color.Black;
		TSL_SHIPONFIRE.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSL_SHIPONFIRE.ForeColor = Color.Red;
		TSL_SHIPONFIRE.Name = "TSL_SHIPONFIRE";
		TSL_SHIPONFIRE.Size = new Size(0, 24);
		TSL_LaunchIndividually.BackColor = Color.FromArgb(60, 63, 65);
		TSL_LaunchIndividually.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_LaunchIndividually.ImageTransparentColor = Color.Magenta;
		TSL_LaunchIndividually.Name = "TSL_LaunchIndividually";
		TSL_LaunchIndividually.Size = new Size(139, 24);
		TSL_LaunchIndividually.Text = "单独出动";
		TSL_LaunchAsGroup.BackColor = Color.FromArgb(60, 63, 65);
		TSL_LaunchAsGroup.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_LaunchAsGroup.ImageTransparentColor = Color.Magenta;
		TSL_LaunchAsGroup.Name = "TSL_LaunchAsGroup";
		TSL_LaunchAsGroup.Size = new Size(137, 24);
		TSL_LaunchAsGroup.Text = "作为编队出动";
		TSL_ReadyAC.BackColor = Color.FromArgb(60, 63, 65);
		TSL_ReadyAC.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_ReadyAC.ImageTransparentColor = Color.Magenta;
		TSL_ReadyAC.Name = "TSL_ReadyAC";
		TSL_ReadyAC.Size = new Size(96, 24);
		TSL_ReadyAC.Text = "准备/装弹";
		TSB_AbortLaunch.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AbortLaunch.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AbortLaunch.ImageTransparentColor = Color.Magenta;
		TSB_AbortLaunch.Name = "TSB_AbortLaunch";
		TSB_AbortLaunch.Size = new Size(101, 24);
		TSB_AbortLaunch.Text = "中止出动";
		ToolStripSeparator2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator2.Margin = new Padding(0, 0, 2, 0);
		ToolStripSeparator2.Name = "ToolStripSeparator2";
		ToolStripSeparator2.Size = new Size(6, 27);
		TSB_Doctrine.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Doctrine.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Doctrine.ImageTransparentColor = Color.Magenta;
		TSB_Doctrine.Name = "TSB_Doctrine";
		TSB_Doctrine.Size = new Size(70, 24);
		TSB_Doctrine.Text = "条令";
		TSB_AssignToMission.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AssignToMission.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_AssignToMission.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AssignToMission.ImageTransparentColor = Color.Magenta;
		TSB_AssignToMission.Name = "TSB_AssignToMission";
		TSB_AssignToMission.Size = new Size(138, 24);
		TSB_AssignToMission.Text = "分配给任务";
		ToolStripSeparator1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator1.Margin = new Padding(0, 0, 2, 0);
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(6, 27);
		TSB_SetReadyTime.BackColor = Color.FromArgb(60, 63, 65);
		TSB_SetReadyTime.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_SetReadyTime.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_SetReadyTime.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_SetReadyTime.ImageTransparentColor = Color.Magenta;
		TSB_SetReadyTime.Name = "TSB_SetReadyTime";
		TSB_SetReadyTime.Size = new Size(133, 24);
		TSB_SetReadyTime.Text = "设置就绪时间";
		TSB_Rename.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Rename.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_Rename.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_Rename.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Rename.ImageTransparentColor = Color.Magenta;
		TSB_Rename.Name = "TSB_Rename";
		TSB_Rename.Size = new Size(70, 24);
		TSB_Rename.Text = "改名";
		TSB_Delete.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Delete.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_Delete.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_Delete.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Delete.ImageTransparentColor = Color.Magenta;
		TSB_Delete.Name = "TSB_Delete";
		TSB_Delete.Size = new Size(70, 24);
		TSB_Delete.Text = "删除";
		TSB_AddHostedUnit.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddHostedUnit.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_AddHostedUnit.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_AddHostedUnit.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddHostedUnit.ImageTransparentColor = Color.Magenta;
		TSB_AddHostedUnit.Name = "TSB_AddHostedUnit";
		TSB_AddHostedUnit.Size = new Size(76, 24);
		TSB_AddHostedUnit.Text = "添加单元";
		TSB_Cargo.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Cargo.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_Cargo.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		TSB_Cargo.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Cargo.ImageTransparentColor = Color.Magenta;
		TSB_Cargo.Name = "TSB_Cargo";
		TSB_Cargo.Size = new Size(85, 24);
		TSB_Cargo.Text = "Cargo Ops";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(TV_Facilities);
		TabPage2.Controls.Add(TS_Edit);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(1282, 543);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "空军设施";
		TV_Facilities.Dock = DockStyle.Fill;
		TV_Facilities.Location = new Point(3, 3);
		TV_Facilities.MaxDragChange = 20;
		TV_Facilities.Name = "TV_Facilities";
		TV_Facilities.Size = new Size(1276, 510);
		TV_Facilities.TabIndex = 7;
		TS_Edit.BackColor = Color.FromArgb(60, 63, 65);
		TS_Edit.Dock = DockStyle.Bottom;
		TS_Edit.ForeColor = Color.FromArgb(220, 220, 220);
		TS_Edit.GripStyle = ToolStripGripStyle.Hidden;
		TS_Edit.ImageScalingSize = new Size(20, 20);
		TS_Edit.Items.AddRange(new ToolStripItem[2] { Button_AddFac, Button_RemoveFac });
		TS_Edit.Location = new Point(3, 513);
		TS_Edit.Name = "TS_Edit";
		TS_Edit.Padding = new Padding(5, 0, 1, 0);
		TS_Edit.Size = new Size(1276, 27);
		TS_Edit.TabIndex = 7;
		TS_Edit.Text = "ToolStrip2";
		Button_AddFac.BackColor = Color.FromArgb(60, 63, 65);
		Button_AddFac.ForeColor = Color.FromArgb(220, 220, 220);
		Button_AddFac.Image = QResourceHelper.GetImage("Button_AddFac.Image");
		Button_AddFac.ImageTransparentColor = Color.Magenta;
		Button_AddFac.Name = "Button_AddFac";
		Button_AddFac.Size = new Size(110, 24);
		Button_AddFac.Text = "添加设施";
		Button_RemoveFac.BackColor = Color.FromArgb(60, 63, 65);
		Button_RemoveFac.ForeColor = Color.FromArgb(220, 220, 220);
		Button_RemoveFac.Image = QResourceHelper.GetImage("Button_RemoveFac.Image");
		Button_RemoveFac.ImageTransparentColor = Color.Magenta;
		Button_RemoveFac.Name = "Button_RemoveFac";
		Button_RemoveFac.Size = new Size(147, 24);
		Button_RemoveFac.Text = "移除设施";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1290, 571);
		base.Controls.Add(TabControl1);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AirOps";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "空中作战";
		CustomizeModel().ResumeLayout(performLayout: false);
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		FlowLayoutPanel1.PerformLayout();
		((ISupportInitialize)DGV_LoadoutItems).EndInit();
		((ISupportInitialize)TGV_Aircraft).EndInit();
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		TabPage2.ResumeLayout(performLayout: false);
		TabPage2.PerformLayout();
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
			interceptorImporter.Clear();
			m_MessageImporter.Clear();
			TV_Facilities.Nodes.Clear();
			TGV_Aircraft.Nodes.Clear();
			TSB_AssignToMission.DropDownItems.Clear();
			TSMI_AssignToMission.DropDownItems.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] mapperImporter = _MapperImporter;
		Keys[] array = mapperImporter;
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

	private void ComputeContainer(object sender, FormClosingEventArgs e)
	{
		if (_AnnotationImporter)
		{
			Client.CurrentGame.Run();
		}
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		ExcludeComposer().Stop();
	}

	[SpecialName]
	private List<ActiveUnit> GetAllValidAircrafts()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		ActiveUnit item = null;
		foreach (string selectedHosts_ID in SelectedHosts_IDs)
		{
			if (!string.IsNullOrEmpty(selectedHosts_ID) && Client.CurrentScenario.ActiveUnits.TryGetValue(selectedHosts_ID, ref item))
			{
				list.Add(item);
			}
		}
		return list;
	}

	[SpecialName]
	private ReadOnlyCollection<ActiveUnit> GetSelectedAircrafts()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		ActiveUnit item = null;
		foreach (string item2 in algoImporter)
		{
			if (!string.IsNullOrEmpty(item2) && Client.CurrentScenario.ActiveUnits.TryGetValue(item2, ref item))
			{
				list.Add(item);
			}
		}
		return list.AsReadOnly();
	}

	private void PatchContainer(Group group_0, ActiveUnit activeUnit_0)
	{
		foreach (ActiveUnit allValidAircraft in GetAllValidAircrafts())
		{
			if (allValidAircraft == group_0)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(activeUnit_0.Name);
				TV_Facilities.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = activeUnit_0;
			}
		}
	}

	private void SelectContainer(Group group_0, ActiveUnit activeUnit_0)
	{
		foreach (ActiveUnit allValidAircraft in GetAllValidAircrafts())
		{
			if (allValidAircraft != group_0)
			{
				continue;
			}
			foreach (DarkTreeNode node in TV_Facilities.Nodes)
			{
				if (node.Tag == activeUnit_0)
				{
					TV_Facilities.Nodes.Remove(node);
					break;
				}
			}
		}
	}

	private Dictionary<int, int> CallContainer(ref ActiveUnit activeUnit_0)
	{
		List<Aircraft> list = new List<Aircraft>();
		if (Information.IsNothing(activeUnit_0))
		{
			return null;
		}
		foreach (Aircraft item in activeUnit_0.AirOps.EmbarkedAircraft_ReadOnly)
		{
			list.Add(item);
		}
		if (list.Count == 0)
		{
			return null;
		}
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		bool bool_ = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		return DBFunctions.GetSelectedAircraftTotalWeaponQty(list, ref sqliteConnection_, ref bool_);
	}

	private void LogoutContainer(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && (object)DGV_LoadoutItems.Columns[e.ColumnIndex].CellType == typeof(DataGridViewLinkCell))
		{
			int int_ = Conversions.ToInteger(DGV_LoadoutItems.Rows[e.RowIndex].Cells["ComponentID"].Value);
			Client.smethod_0("Weapon", int_);
		}
	}

	private void ViewContainer(Aircraft aircraft_0)
	{
		foreach (ActiveUnit allValidAircraft in GetAllValidAircrafts())
		{
			if (allValidAircraft.AirOps.EmbarkedAircraft_ReadOnly.Contains(aircraft_0))
			{
				interceptorImporter.Add(aircraft_0);
			}
		}
	}

	public void RefreshForm()
	{
		WriteContainer();
		ExcludeContainer();
	}

	private void ValidateContainer()
	{
		DeleteAdvisor().RunWorkerAsync();
	}

	private void LoginContainer(Aircraft aircraft_0)
	{
		m_MessageImporter.Add(aircraft_0);
	}

	private void GetContainer(object sender, EventArgs e)
	{
		if (Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			RefreshAll();
		}
	}

	public void RefreshAll()
	{
		WriteContainer();
		ExcludeContainer();
		interceptorImporter.Clear();
		m_MessageImporter.Clear();
	}

	private void WriteContainer()
	{
		if (!TGV_Aircraft.Enabled)
		{
			return;
		}
		TGV_Aircraft.Enabled = false;
		try
		{
			foreach (Aircraft item in m_MessageImporter)
			{
				Aircraft Local_myAC = item;
				IEnumerable<TreeGridNode> source = from theNode in GetAllNodes()
					where theNode != null && theNode.Tag == Local_myAC
					select theNode;
				if (source.Count() > 0)
				{
					TreeGridNode treeGridNode = source.ElementAtOrDefault(0).Parent;
					List<Aircraft> list = ((IEnumerable<Aircraft>)treeGridNode.Tag).ToList();
					if (list.Count < 2)
					{
						treeGridNode.Parent.Nodes.Remove(treeGridNode);
						continue;
					}
					treeGridNode.Nodes.Remove(source.ElementAtOrDefault(0));
					list.Remove(Local_myAC);
					treeGridNode.Tag = list;
				}
			}
			foreach (TreeGridNode allNode in GetAllNodes())
			{
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(allNode.Tag)) && (object)allNode.Tag.GetType() == typeof(Aircraft))
				{
					Aircraft aircraft = (Aircraft)allNode.Tag;
					bool paramsImporter = _ParamsImporter;
					string string_ = null;
					if (paramsImporter & (aircraft.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance))
					{
						allNode.Visible = false;
					}
					else
					{
						allNode.Visible = true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200111", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (Aircraft item2 in interceptorImporter)
			{
				bool flag = false;
				foreach (TreeGridNode node in TGV_Aircraft.Nodes)
				{
					if (node.Tag != null && Operators.CompareString(((IEnumerable<Aircraft>)node.Tag).ElementAtOrDefault(0).DBID.ToString(), item2.DBID.ToString(), TextCompare: true) == 0)
					{
						node.Nodes.Add().Tag = item2;
						List<Aircraft> list2 = ((IEnumerable<Aircraft>)node.Tag).ToList();
						list2.Add(item2);
						node.Tag = list2;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					IEnumerable<Aircraft> tag = new Aircraft[1] { item2 };
					TreeGridNode treeGridNode2 = TGV_Aircraft.Nodes.Add();
					treeGridNode2.Tag = tag;
					treeGridNode2.Nodes.Add().Tag = item2;
				}
			}
			if (_AuthenticationImporter)
			{
				InsertContainer();
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 200112", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			foreach (TreeGridNode allNode2 in GetAllNodes())
			{
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(allNode2.Tag)))
				{
					continue;
				}
				if ((object)allNode2.Tag.GetType() == typeof(Aircraft))
				{
					Aircraft aircraft2 = (Aircraft)allNode2.Tag;
					string string_2 = (Information.IsNothing(aircraft2.Loadout) ? "Nothing" : aircraft2.Loadout.Name);
					string text;
					if (Information.IsNothing(aircraft2.AssignedMissionOrPackage()))
					{
						text = (Information.IsNothing(aircraft2.AssignedTaskPool) ? "-" : (aircraft2.AssignedTaskPool.Name + "（任务池）"));
					}
					else
					{
						string text2 = "";
						if (aircraft2.AI.IsEscort)
						{
							text2 = "，护航";
						}
						text = aircraft2.AssignedMissionOrPackage().Name + " (" + aircraft2.AssignedMissionOrPackage().GetDescriptionString(Client.CurrentScenario) + text2 + ")";
					}
					Aircraft_AirOps airOps = aircraft2.AirOps;
					string text3 = aircraft2.Name;
					if (aircraft2.GetUnitSide() != Client.CurrentSide)
					{
						text3 = text3 + " (" + aircraft2.GetUnitSide().Name + ")";
					}
					object[] array = new object[6]
					{
						text3,
						airOps.ConditionString,
						text,
						Misc.ReadRequest(string_2),
						null,
						null
					};
					long long_ = (long)Math.Round(airOps.ConditionTimer);
					string string_3 = null;
					array[4] = Misc.UpdateRequest(long_, aircraft2.IsAvailableForOps(ref string_3));
					array[5] = aircraft2.QuickTurnaroundString();
					allNode2.SetValues(array);
					MoveComposer(allNode2, aircraft2);
					continue;
				}
				allNode2.Cells[0].Value = "";
				List<Aircraft> list3 = ((IEnumerable<Aircraft>)allNode2.Tag).ToList();
				if (list3.Count > 0)
				{
					Aircraft aircraft3 = list3.FirstOrDefault();
					Aircraft_AirOps airOps2 = aircraft3.AirOps;
					if (airOps2.CurrentHostUnit != null)
					{
						allNode2.Cells[0].Value = Conversions.ToString(list3.Count) + "x " + Misc.ReadRequest(aircraft3.UnitClass) + " (" + airOps2.CurrentHostUnit.Name + ")";
					}
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception exception_3 = ex3;
			exception_3?.Data.Add("Error at 200279", "");
			GameGeneral.WriteExceptionsToLog(ref exception_3);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Close();
			ProjectData.ClearProjectError();
			return;
		}
		TGV_Aircraft.Enabled = true;
	}

	private void NewContainer()
	{
		DataGridViewColumn dataGridViewColumn = TGV_Aircraft.Columns[3];
		dataGridViewColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending;
		DataGridViewColumn dataGridViewColumn2 = TGV_Aircraft.Columns[4];
		dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
		dataGridViewColumn2.HeaderCell.SortGlyphDirection = SortOrder.Descending;
	}

	[SpecialName]
	private ReadOnlyCollection<TreeGridNode> GetAllNodes()
	{
		try
		{
			List<TreeGridNode> list = new List<TreeGridNode>();
			foreach (TreeGridNode node in TGV_Aircraft.Nodes)
			{
				if (!list.Contains(node))
				{
					list.Add(node);
				}
				PushContainer(node, list);
			}
			return list.AsReadOnly();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101133", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ReadOnlyCollection<TreeGridNode> result = new List<TreeGridNode>().AsReadOnly();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private void PushContainer(TreeGridNode treeGridNode_0, List<TreeGridNode> list_0)
	{
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			if (!list_0.Contains(node))
			{
				list_0.Add(node);
			}
			PushContainer(node, list_0);
		}
	}

	private void InvokeContainer()
	{
		try
		{
			TGV_Aircraft.Nodes.Clear();
			foreach (ActiveUnit allValidAircraft in GetAllValidAircrafts())
			{
				foreach (int item in allValidAircraft.AirOps.EmbarkedAircraft_ReadOnly.Select((Aircraft AC) => AC.DBID).Distinct())
				{
					int Local_theDBID = item;
					IEnumerable<Aircraft> enumerable = from AC in allValidAircraft.AirOps.EmbarkedAircraft_ReadOnly
						where AC.DBID == Local_theDBID
						select (AC);
					TreeGridNode treeGridNode = TGV_Aircraft.Nodes.Add(Conversions.ToString(enumerable.Count()) + "x " + Misc.ReadRequest(enumerable.ElementAtOrDefault(0).UnitClass) + " (" + allValidAircraft.Name + ")");
					treeGridNode.Tag = enumerable;
					treeGridNode.DefaultCellStyle.ForeColor = Color.DodgerBlue;
					treeGridNode.Nodes.Add("Temp");
				}
				foreach (int item2 in iteratorImporter)
				{
					foreach (TreeGridNode node in TGV_Aircraft.Nodes)
					{
						try
						{
							if (((IEnumerable<Aircraft>)node.Tag).ElementAtOrDefault(0).DBID == item2)
							{
								node.Expand();
							}
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception exception_ = ex;
							exception_?.Data.Add("Error at 200121", exception_.Message);
							GameGeneral.WriteExceptionsToLog(ref exception_);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			if (TGV_Aircraft.Nodes.Count > 0)
			{
				TGV_Aircraft.Nodes[0].Expand();
			}
			CallComposer(TGV_Aircraft.Nodes.Count == 1);
			NewContainer();
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 101134", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SetupContainer()
	{
		try
		{
			TV_Facilities.Nodes.Clear();
			foreach (ActiveUnit allValidAircraft in GetAllValidAircrafts())
			{
				if (allValidAircraft.IsGroup)
				{
					if (((Group)allValidAircraft).Type == Group.GroupType.AirBase)
					{
						DarkTreeNode darkTreeNode = new DarkTreeNode(allValidAircraft.Name);
						TV_Facilities.Nodes.Add(darkTreeNode);
						darkTreeNode.Tag = allValidAircraft;
						IncludeContainer((Group)allValidAircraft, darkTreeNode);
						continue;
					}
					foreach (ActiveUnit item in from theAU in ((Group)allValidAircraft).Units.Values
						select (theAU) into theAU
						orderby theAU.Name
						select theAU)
					{
						if (item.AirFacilities_ReadOnly.Length != 0)
						{
							DarkTreeNode darkTreeNode2 = new DarkTreeNode(item.Name);
							TV_Facilities.Nodes.Add(darkTreeNode2);
							darkTreeNode2.Tag = item;
							IncludeContainer(item, darkTreeNode2);
						}
					}
				}
				else
				{
					DarkTreeNode darkTreeNode3 = new DarkTreeNode(allValidAircraft.Name);
					TV_Facilities.Nodes.Add(darkTreeNode3);
					darkTreeNode3.Tag = allValidAircraft;
					IncludeContainer(allValidAircraft, darkTreeNode3);
				}
			}
			InterpreterObjectListener.PostInterruptibleTask(TV_Facilities);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101135", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ExcludeContainer()
	{
		TV_Facilities.SuspendLayout();
		foreach (ActiveUnit allValidAircraft in GetAllValidAircrafts())
		{
			foreach (DarkTreeNode node in TV_Facilities.Nodes)
			{
				ActiveUnit activeUnit_ = (ActiveUnit)node.Tag;
				IncludeContainer(activeUnit_, node);
			}
		}
		TV_Facilities.ResumeLayout();
	}

	private void IncludeContainer(ActiveUnit activeUnit_0, DarkTreeNode darkTreeNode_0)
	{
		IOrderedEnumerable<AirFacility> orderedEnumerable = from theAF in activeUnit_0.AirFacilities_ReadOnly
			select (theAF) into theAF
			orderby theAF.Name
			select theAF;
		double num = 0.0;
		double num2 = 0.0;
		foreach (AirFacility item in orderedEnumerable)
		{
			bool flag = false;
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				if (node.Tag == item)
				{
					flag = true;
					SearchContainer(item, node);
					break;
				}
			}
			if (!flag)
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(item.Name);
				darkTreeNode_0.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item;
				darkTreeNode.Expanded = true;
				foreach (Aircraft value in item.HostedAircraft.Values)
				{
					string[] obj = new string[8]
					{
						value.Name,
						" (",
						Misc.ReadRequest(value.UnitClass),
						"): ",
						value.AirOps.ConditionString,
						" (",
						null,
						null
					};
					long long_ = (long)Math.Round(value.AirOps.ConditionTimer);
					string string_ = null;
					obj[6] = Misc.UpdateRequest(long_, value.IsAvailableForOps(ref string_));
					obj[7] = ")";
					DarkTreeNode darkTreeNode2 = new DarkTreeNode(string.Concat(obj));
					darkTreeNode.Nodes.Add(darkTreeNode2);
					darkTreeNode2.Tag = value;
					darkTreeNode2.Expanded = true;
				}
			}
			num += (double)item.ParkingSpace_Total;
			num2 = num2 + (double)item.ParkingSpace_Total - (double)item.ParkingSpace_Free;
		}
		lblCapacity.Text = "已占用" + num2 + " / " + num + " ( " + Math.Round(num2 / num * 100.0) + "% )";
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
		{
			if (!activeUnit_0.AirFacilities_ReadOnly.Contains((AirFacility)node2.Tag))
			{
				list.Add(node2);
			}
		}
		foreach (DarkTreeNode item2 in list)
		{
			darkTreeNode_0.Nodes.Remove(item2);
		}
	}

	private void SearchContainer(AirFacility airFacility_0, DarkTreeNode darkTreeNode_0)
	{
		bool flag = false;
		foreach (Aircraft value in airFacility_0.HostedAircraft.Values)
		{
			foreach (DarkTreeNode node in darkTreeNode_0.Nodes)
			{
				if (node.Tag == value)
				{
					flag = true;
					node.Text = value.Name + " (" + Misc.ReadRequest(value.UnitClass) + "): " + value.AirOps.ConditionString + " (" + Misc.UpdateRequest((long)Math.Round(value.AirOps.ConditionTimer)) + ")";
					break;
				}
			}
			if (!flag)
			{
				string[] obj = new string[8]
				{
					value.Name,
					" (",
					Misc.ReadRequest(value.UnitClass),
					"): ",
					value.AirOps.ConditionString,
					" (",
					null,
					null
				};
				long long_ = (long)Math.Round(value.AirOps.ConditionTimer);
				string string_ = null;
				obj[6] = Misc.UpdateRequest(long_, value.IsAvailableForOps(ref string_));
				obj[7] = ")";
				DarkTreeNode darkTreeNode = new DarkTreeNode(string.Concat(obj));
				darkTreeNode_0.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = value;
			}
		}
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node2 in darkTreeNode_0.Nodes)
		{
			if (!airFacility_0.HostedAircraft.Values.Contains((Aircraft)node2.Tag))
			{
				list.Add(node2);
			}
		}
		foreach (DarkTreeNode item in list)
		{
			darkTreeNode_0.Nodes.Remove(item);
		}
	}

	private void EnableContainer(object sender, EventArgs e)
	{
	}

	private void ChangeContainer(object sender, EventArgs e)
	{
		InitContainer(bool_0: true);
	}

	private void InitContainer(bool bool_0 = false)
	{
		CheckContainer(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: true);
		switch (GetSelectedAircrafts().Count)
		{
		case 1:
			((Aircraft)GetSelectedAircrafts()[0]).AirOps.AttemptToMoveToRunway(bool_0: true, bool_0);
			break;
		default:
			foreach (Aircraft selectedAircraft in GetSelectedAircrafts())
			{
				selectedAircraft.AirOps.AttemptToMoveToRunway(bool_0: true, bool_0);
			}
			break;
		case 0:
			break;
		}
		WriteContainer();
	}

	private void CheckContainer(bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		algoImporter.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					algoImporter.Add(((Aircraft)node2.Tag).ObjectID);
				}
			}
		}
		if (bool_0)
		{
			List<Aircraft> list = new List<Aircraft>();
			foreach (Aircraft selectedAircraft in GetSelectedAircrafts())
			{
				string string_ = null;
				if (selectedAircraft.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance)
				{
					list.Add(selectedAircraft);
				}
			}
			if (list.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list.Count) + "架选定的飞机无法进行操作，将不出动。", "选择了不可用的飞机！");
				foreach (Aircraft item in list)
				{
					algoImporter.Remove(item.ObjectID);
				}
			}
		}
		if (bool_1)
		{
			List<Aircraft> list2 = new List<Aircraft>();
			foreach (Aircraft selectedAircraft2 in GetSelectedAircrafts())
			{
				if (selectedAircraft2.GetUnitSide() != Client.CurrentSide)
				{
					list2.Add(selectedAircraft2);
				}
			}
			if (list2.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list2.Count) + "架所选飞机是不受您直接控制的盟军单元。", "选择了盟军飞机！");
				foreach (Aircraft item2 in list2)
				{
					algoImporter.Remove(item2.ObjectID);
				}
			}
		}
		if (bool_2)
		{
			List<Aircraft> list3 = new List<Aircraft>();
			foreach (Aircraft selectedAircraft3 in GetSelectedAircrafts())
			{
				if (selectedAircraft3.IsOperating())
				{
					list3.Add(selectedAircraft3);
				}
			}
			if (list3.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list3.Count) + "架所选飞机已出动。", "选择了已出动飞机！");
				foreach (Aircraft item3 in list3)
				{
					algoImporter.Remove(item3.ObjectID);
				}
			}
		}
		if (bool_3)
		{
			List<Aircraft> list4 = new List<Aircraft>();
			foreach (Aircraft selectedAircraft4 in GetSelectedAircrafts())
			{
				if (Information.IsNothing(selectedAircraft4.Loadout))
				{
					list4.Add(selectedAircraft4);
				}
			}
			if (list4.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list4.Count) + "架选定的飞机没有挂载，将不出动。", "选择了没有挂载的飞机！");
				foreach (Aircraft item4 in list4)
				{
					algoImporter.Remove(item4.ObjectID);
				}
			}
		}
		if (!bool_4)
		{
			return;
		}
		List<Aircraft> list5 = new List<Aircraft>();
		foreach (Aircraft selectedAircraft5 in GetSelectedAircrafts())
		{
			if (!Information.IsNothing(selectedAircraft5.Loadout))
			{
				string string_2 = null;
				if (selectedAircraft5.IsAvailableForOps(ref string_2) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsReserve)
				{
					list5.Add(selectedAircraft5);
				}
			}
		}
		if (list5.Count <= 0)
		{
			return;
		}
		DarkMessageBox.ShowWarning(Conversions.ToString(list5.Count) + "架选定的飞机有预留挂载，将不出动。", "选择了预留挂载的飞机！");
		foreach (Aircraft item5 in list5)
		{
			algoImporter.Remove(item5.ObjectID);
		}
	}

	private void ConcatContainer(object sender, EventArgs e)
	{
		InterruptContainer();
	}

	private void InterruptContainer()
	{
		algoImporter.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			if (node.Selected)
			{
				foreach (Aircraft item in (IEnumerable<Aircraft>)node.Tag)
				{
					if (item.AirOps.CanBeRearmedRightNow())
					{
						algoImporter.Add(item.ObjectID);
					}
				}
			}
			if (GetSelectedAircrafts().Count > 0)
			{
				break;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected && (((Aircraft)node2.Tag).AirOps.CanBeRearmedRightNow() | (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)))
				{
					algoImporter.Add(((Aircraft)node2.Tag).ObjectID);
				}
			}
			if (GetSelectedAircrafts().Count > 0)
			{
				break;
			}
		}
		if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
		{
			List<Aircraft> list = new List<Aircraft>();
			foreach (Aircraft selectedAircraft in GetSelectedAircrafts())
			{
				string string_ = null;
				if (selectedAircraft.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance)
				{
					list.Add(selectedAircraft);
				}
			}
			if (list.Count > 0)
			{
				DarkMessageBox.ShowWarning(Conversions.ToString(list.Count) + "架所选飞机无法进行操作，将不进行出动准备。", "选择了不可用的飞机！");
				foreach (Aircraft item2 in list)
				{
					algoImporter.Remove(item2.ObjectID);
				}
			}
		}
		List<Aircraft> list2 = new List<Aircraft>();
		foreach (Aircraft selectedAircraft2 in GetSelectedAircrafts())
		{
			if (selectedAircraft2.GetUnitSide() != Client.CurrentSide)
			{
				list2.Add(selectedAircraft2);
			}
		}
		if (list2.Count > 0)
		{
			DarkMessageBox.ShowWarning(Conversions.ToString(list2.Count) + "架所选飞机是不受您直接控制的盟军单元。", "选择了盟军飞机！");
			foreach (Aircraft item3 in list2)
			{
				algoImporter.Remove(item3.ObjectID);
			}
		}
		List<Aircraft> list3 = new List<Aircraft>();
		foreach (Aircraft selectedAircraft3 in GetSelectedAircrafts())
		{
			if (selectedAircraft3.IsOperating())
			{
				list3.Add(selectedAircraft3);
			}
		}
		if (list3.Count > 0)
		{
			DarkMessageBox.ShowWarning(Conversions.ToString(list3.Count) + "架所选飞机已出动。", "选择了已出动飞机！");
			foreach (Aircraft item4 in list3)
			{
				algoImporter.Remove(item4.ObjectID);
			}
		}
		int num = 0;
		List<Aircraft> list4 = new List<Aircraft>();
		foreach (Aircraft selectedAircraft4 in GetSelectedAircrafts())
		{
			if (num == 0)
			{
				num = selectedAircraft4.DBID;
			}
			else if (selectedAircraft4.DBID != num)
			{
				list4.Add(selectedAircraft4);
			}
		}
		if (list4.Count > 0)
		{
			DarkMessageBox.ShowWarning(Conversions.ToString(list4.Count) + "架所选飞机的类型不同，将不进行出动准备。", "选择了不同的飞机类型！");
			foreach (Aircraft item5 in list4)
			{
				algoImporter.Remove(item5.ObjectID);
			}
		}
		if (GetSelectedAircrafts().Count <= 0)
		{
			return;
		}
		if (Information.IsNothing(ItemExporter.ConnectInterruptibleTemplate.ReadyAircraft.SelectedAircraft))
		{
			ItemExporter.ConnectInterruptibleTemplate.ReadyAircraft.SelectedAircraft = new List<Aircraft>();
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.ReadyAircraft.SelectedAircraft.Clear();
		}
		foreach (ActiveUnit selectedAircraft5 in GetSelectedAircrafts())
		{
			ItemExporter.ConnectInterruptibleTemplate.ReadyAircraft.SelectedAircraft.Add((Aircraft)selectedAircraft5);
		}
		if (Information.IsNothing(((Aircraft)GetSelectedAircrafts()[0]).Loadout))
		{
			ItemExporter.ConnectInterruptibleTemplate.ReadyAircraft.SelectedLoadout = 0;
		}
		else
		{
			ItemExporter.ConnectInterruptibleTemplate.ReadyAircraft.SelectedLoadout = ((Aircraft)GetSelectedAircrafts()[0]).Loadout.DBID;
		}
		ItemExporter.ConnectInterruptibleTemplate.ReadyAircraft.Show();
	}

	private void RemoveContainer(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			TreeGridNode currentNode = TGV_Aircraft.CurrentNode;
			if (currentNode == null || currentNode.Tag == null || e.RowIndex == -1)
			{
				return;
			}
			string name = TGV_Aircraft.Columns[e.ColumnIndex].Name;
			if (Operators.CompareString(name, "Aircraft", TextCompare: true) == 0)
			{
				if ((object)currentNode.Tag.GetType() != typeof(Aircraft))
				{
					int dBID = ((IEnumerable<Aircraft>)currentNode.Tag).ElementAtOrDefault(0).DBID;
					Client.smethod_0("Aircraft", dBID);
				}
			}
			else
			{
				if (Operators.CompareString(name, "Loadout", TextCompare: true) != 0)
				{
					return;
				}
				ActiveUnit activeUnit = null;
				try
				{
					activeUnit = (ActiveUnit)currentNode.Tag;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (activeUnit != null && (object)currentNode.Tag.GetType() == typeof(Aircraft))
				{
					int int32_ = ((Aircraft)activeUnit).Int32_0;
					if (int32_ >= 1)
					{
						Client.smethod_0("Aircraft", activeUnit.DBID, "Loadout" + Conversions.ToString(int32_));
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200122", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FindContainer(object sender, CollapsingEventArgs e)
	{
		if (e.Node.Level == 1)
		{
			iteratorImporter.Remove(((IEnumerable<Aircraft>)e.Node.Tag).ElementAtOrDefault(0).DBID);
		}
	}

	private void SetContainer(object sender, EventArgs e)
	{
		FillContainer();
	}

	private void FillContainer()
	{
		CheckContainer(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: true);
		if ((from AU in GetSelectedAircrafts()
			select ((Aircraft)AU).Int32_0).Distinct().Count() > 1 && DarkMessageBox.ShowInformation("There are different types of aircraft in the current selection. Do you want to :" + Environment.NewLine + "-[yes] Enforce a wing with homogenous types of aircrafts, thus splitting it into multiple wings " + Environment.NewLine + "-[No] Force the entire selection into a mixed group ?", "Confirm", DarkDialogButton.YesNo) == DialogResult.Yes)
		{
			Misc.FormIntoGroups(GetSelectedAircrafts().ToList(), Client.CurrentScenario, Client.CurrentSide, Misc.GroupingLogic.SplitByType);
		}
		else
		{
			Misc.FormIntoGroups(GetSelectedAircrafts().ToList(), Client.CurrentScenario, Client.CurrentSide, Misc.GroupingLogic.MixedGroup);
		}
		switch (GetSelectedAircrafts().Count)
		{
		case 1:
			((Aircraft)GetSelectedAircrafts()[0]).AirOps.AttemptToMoveToRunway(bool_0: true);
			break;
		default:
			foreach (Aircraft selectedAircraft in GetSelectedAircrafts())
			{
				selectedAircraft.AirOps.AttemptToMoveToRunway(bool_0: true);
			}
			break;
		case 0:
			break;
		}
		WriteContainer();
	}

	private void CalculateContainer(object sender, DoWorkEventArgs e)
	{
		Thread.Sleep(100);
	}

	private void PopContainer(object sender, RunWorkerCompletedEventArgs e)
	{
		InvokeContainer();
	}

	private void InstantiateContainer(object sender, EventArgs e)
	{
		if (GetAllValidAircrafts().Count <= 1)
		{
			Text = "空中行动 - " + GetAllValidAircrafts()[0].Name;
		}
		else
		{
			Text = "空中行动  - 多个单元";
		}
		ValidateContainer();
		SetupContainer();
		TSB_SetReadyTime.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_Rename.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_Delete.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_AddHostedUnit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_Cargo.Visible = true;
		TSL_SHIPONFIRE.Visible = false;
		FloodAlert.Visible = false;
		ToolStripSeparator1.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		ExcludeComposer().Start();
		Aircraft_AirOps.TookOff += LoginContainer;
		Aircraft_AirOps.Landing += ViewContainer;
		Group.UnitAdded += PatchContainer;
		Group.UnitRemoved += SelectContainer;
		AddUnit.theAddedUnitChanged += LoginComposer;
	}

	private void CreateContainer(object sender, EventArgs e)
	{
		CompareContainer();
	}

	private void CompareContainer()
	{
		CheckContainer(bool_0: false, bool_1: true, bool_2: true, bool_3: false, bool_4: false);
		foreach (ActiveUnit selectedAircraft in GetSelectedAircrafts())
		{
			if (((Aircraft_AirOps)selectedAircraft.AirOps).IsTakingOff)
			{
				((Aircraft_AirOps)selectedAircraft.AirOps).AttemptToPark(bool_0: true, bool_1: false, bool_2: true);
				if (selectedAircraft.Navigator.HasFlight)
				{
					selectedAircraft.Navigator.GetFlight().SetStatus(Client.CurrentScenario, Command_Core.Mission._FlightStatus.None);
				}
			}
			if (selectedAircraft.IsGroupMember())
			{
				selectedAircraft.SetParentGroup(bool_0: false, null);
			}
		}
		WriteContainer();
	}

	private void ReadContainer(object sender, EventArgs e)
	{
		algoImporter.Clear();
		bool flag = false;
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			if (node.Selected)
			{
				flag = true;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					algoImporter.Add(((Aircraft)node2.Tag).ObjectID);
				}
			}
		}
		if (GetSelectedAircrafts().Count > 0)
		{
			string objectID = ((Aircraft_AirOps)GetSelectedAircrafts()[0].AirOps).CurrentHostUnit.ObjectID;
			if (Operators.CompareString(databaseImporter, objectID, TextCompare: true) != 0)
			{
				ActiveUnit activeUnit_ = Client.CurrentScenario.ActiveUnits[objectID];
				m_InfoImporter = CallContainer(ref activeUnit_);
				databaseImporter = activeUnit_.ObjectID;
			}
		}
		if (flag)
		{
			if (!Information.IsNothing(m_RoleImporter))
			{
				m_RoleImporter.Rows.Clear();
			}
		}
		else if (GetSelectedAircrafts().Count == 1)
		{
			Aircraft aircraft = (Aircraft)GetSelectedAircrafts()[0];
			if (Information.IsNothing(aircraft.Loadout))
			{
				if (!Information.IsNothing(m_RoleImporter))
				{
					m_RoleImporter.Rows.Clear();
				}
			}
			else if (GetSelectedAircrafts()[0].IsOperating())
			{
				if (!Information.IsNothing(m_RoleImporter))
				{
					m_RoleImporter.Rows.Clear();
				}
			}
			else
			{
				int dBID = GetSelectedAircrafts()[0].DBID;
				Dictionary<int, int> infoImporter = m_InfoImporter;
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				Scenario currentScenario = Client.CurrentScenario;
				bool bool_ = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
				Scenario scenario_ = Client.CurrentScenario;
				Aircraft aircraft_ = (Aircraft)GetSelectedAircrafts()[0];
				m_RoleImporter = DBFunctions.LoadoutsForThisAircraft_DT(dBID, infoImporter, ref sqliteConnection_, currentScenario, ref bool_, ref scenario_, ref aircraft_, ref ((Aircraft)GetSelectedAircrafts()[0]).Loadout.DBID, ref aircraft.Loadout.NoOptionalWeapons);
			}
		}
		else if (!Information.IsNothing(m_RoleImporter))
		{
			m_RoleImporter.Rows.Clear();
		}
		if (!Information.IsNothing(m_RoleImporter))
		{
			if (GetSelectedAircrafts().Count <= 0)
			{
				PrepareContainer(null);
			}
			else
			{
				PrepareContainer((Aircraft)GetSelectedAircrafts()[0]);
			}
		}
		UpdateContainer();
		InsertContainer();
	}

	private void DisableContainer(bool bool_0, string string_0 = "All")
	{
		if (Operators.CompareString(string_0, "All", TextCompare: true) == 0)
		{
			TSL_LaunchIndividually.Enabled = bool_0;
			TSL_ReadyAC.Enabled = bool_0;
			TSL_LaunchAsGroup.Enabled = bool_0;
			TSB_AbortLaunch.Enabled = bool_0;
			TSB_Doctrine.Enabled = bool_0;
			TSB_AssignToMission.Enabled = bool_0;
			TSB_Cargo.Enabled = bool_0;
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				TSB_SetReadyTime.Enabled = true;
				TSB_Rename.Enabled = true;
				TSB_Delete.Enabled = true;
				TSB_AddHostedUnit.Enabled = true;
			}
			CustomizeModel().Enabled = bool_0;
		}
	}

	private void UpdateContainer()
	{
		TSL_SHIPONFIRE.Visible = false;
		FloodAlert.Visible = false;
		if (GetSelectedAircrafts().Count <= 0)
		{
			TSB_Cargo.Enabled = false;
			TSL_LaunchIndividually.Enabled = false;
			TSL_ReadyAC.Enabled = false;
			TSL_LaunchAsGroup.Enabled = false;
			TSB_AbortLaunch.Enabled = false;
			TSB_Doctrine.Enabled = false;
			TSB_AssignToMission.Enabled = false;
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				TSB_SetReadyTime.Enabled = false;
				TSB_Rename.Enabled = true;
				TSB_Delete.Enabled = true;
				TSB_AddHostedUnit.Enabled = true;
			}
			return;
		}
		ActiveUnit currentHostUnit = ((Aircraft_AirOps)GetSelectedAircrafts()[0].AirOps).CurrentHostUnit;
		if (currentHostUnit.IsShip)
		{
			if ((int)currentHostUnit.Damage.FireIntensity > 1)
			{
				TSL_SHIPONFIRE.Visible = true;
				TSL_SHIPONFIRE.Text = "MAJOR FIRE - NO AIR OPS";
				DisableContainer(bool_0: false);
				return;
			}
			if ((int)currentHostUnit.Damage.FloodIntensity > 1)
			{
				FloodAlert.Visible = true;
				FloodAlert.Text = "MAJOR FLOOD - NO AIR OPS";
				DisableContainer(bool_0: false);
				return;
			}
			if (currentHostUnit.Damage.FloodIntensity != 0 && ((Aircraft)GetSelectedAircrafts()[0]).GetCanHover(bool_1: true))
			{
				FloodAlert.Visible = true;
				FloodAlert.Text = "Minor FLOOD - VTOL ONLY";
				DisableContainer(bool_0: true);
				return;
			}
		}
		TSL_LaunchIndividually.Enabled = true;
		TSL_ReadyAC.Enabled = true;
		TSL_LaunchAsGroup.Enabled = true;
		TSB_AbortLaunch.Enabled = true;
		TSB_Doctrine.Enabled = true;
		TSB_AssignToMission.Enabled = true;
		if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
		{
			TSB_SetReadyTime.Enabled = true;
			TSB_Rename.Enabled = true;
			TSB_Delete.Enabled = true;
			TSB_AddHostedUnit.Enabled = true;
		}
		TSB_Cargo.Enabled = false;
		foreach (ICargoHost selectedAircraft in GetSelectedAircrafts())
		{
			if (selectedAircraft.GetCargo_Type() != 0)
			{
				TSB_Cargo.Enabled = true;
			}
		}
	}

	private void InsertContainer()
	{
		bool flag = true;
		int num = 0;
		bool? flag2 = null;
		int? num2 = null;
		if (GetSelectedAircrafts().Count <= 0)
		{
			flag = false;
		}
		else
		{
			int? num3 = null;
			foreach (Aircraft selectedAircraft in GetSelectedAircrafts())
			{
				num++;
				if (selectedAircraft.GetUnitSide() == Client.CurrentSide)
				{
					if (num == 1 && !Information.IsNothing(selectedAircraft.Loadout))
					{
						num3 = selectedAircraft.Loadout.DBID;
					}
					byte? b = (byte?)selectedAircraft.Doctrine.GetQuickTurnAroundForAicraft(selectedAircraft.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
					{
						b = (byte?)selectedAircraft.Doctrine.GetQuickTurnAroundForAicraft(selectedAircraft.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
						{
							if (Information.IsNothing(selectedAircraft.Loadout))
							{
								flag = false;
								break;
							}
							Loadout loadout = selectedAircraft.Loadout;
							if (!loadout.IsAAW && !loadout.IsSupportOrPatrol && !loadout.IsASW)
							{
								flag = false;
								break;
							}
						}
						else if (Information.IsNothing(num3))
						{
							if (Information.IsNothing(num3))
							{
								flag = false;
								break;
							}
						}
						else
						{
							if (Information.IsNothing(selectedAircraft.Loadout))
							{
								flag = false;
								break;
							}
							int? num4 = num3;
							int dBID = selectedAircraft.Loadout.DBID;
							if ((num4.HasValue ? new bool?(num4.GetValueOrDefault() != dBID) : null).GetValueOrDefault())
							{
								flag = false;
								break;
							}
						}
						if (!Information.IsNothing(selectedAircraft.Loadout))
						{
							if (!selectedAircraft.Loadout.QuickTurnaround)
							{
								flag = false;
								break;
							}
							b = (byte?)selectedAircraft.Doctrine.GetAirOpsTempo(selectedAircraft.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								attributeImporter = selectedAircraft.Loadout.ReadyTime_Sustained;
							}
							else
							{
								attributeImporter = selectedAircraft.Loadout.ReadyTime;
							}
							m_EventImporter = selectedAircraft.Loadout.QuickTurnaround;
							m_WorkerImporter = selectedAircraft.Loadout.QuickTurnaround_ReadyTime;
							m_GlobalImporter = selectedAircraft.Loadout.QuickTurnaround_AirborneTime;
							_AccountImporter = selectedAircraft.Loadout.QuickTurnaround_MaxSorties;
							_StateImporter = selectedAircraft.Loadout.QuickTurnaround_AdditionalTimePenalty;
							if (!m_EventImporter)
							{
								flag = false;
								break;
							}
						}
						Aircraft_AirOps airOps = selectedAircraft.AirOps;
						if (Information.IsNothing(flag2))
						{
							if (num == 1)
							{
								flag2 = airOps.QuickTurnaround_Enabled;
								num2 = airOps.QuickTurnaround_SortiesTotal;
							}
							continue;
						}
						bool quickTurnaround_Enabled = airOps.QuickTurnaround_Enabled;
						if ((flag2.HasValue ? new bool?(quickTurnaround_Enabled != flag2.GetValueOrDefault()) : null).GetValueOrDefault())
						{
							flag2 = null;
						}
						int quickTurnaround_SortiesTotal = airOps.QuickTurnaround_SortiesTotal;
						bool? flag3 = (num2.HasValue ? new bool?(quickTurnaround_SortiesTotal != num2.GetValueOrDefault()) : null);
						if (flag3.GetValueOrDefault(true) && !Information.IsNothing(num2) && flag3.HasValue)
						{
							num2 = null;
						}
						continue;
					}
					flag = false;
					break;
				}
				flag = false;
				break;
			}
		}
		_AuthenticationImporter = false;
		if (flag)
		{
			CB_QuickTurnaround.Enabled = true;
			if (Information.IsNothing(flag2))
			{
				CB_QuickTurnaround.CheckState = CheckState.Indeterminate;
				RunContainer(num2);
				Combo_NumberOfSorties.Enabled = false;
				Label_QuickTurnaroundInfo.Enabled = true;
				Label_QuickTurnaroundInfo.Text = "选择包括具有和不具有快速再次出动能力的飞机。";
			}
			else if (flag2.GetValueOrDefault())
			{
				if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
				{
					CB_QuickTurnaround.CheckState = CheckState.Checked;
				}
				else
				{
					CB_QuickTurnaround.Checked = true;
				}
				RunContainer(num2);
				Combo_NumberOfSorties.Enabled = true;
				Label_QuickTurnaroundInfo.Enabled = true;
				if (Information.IsNothing(num2))
				{
					Label_QuickTurnaroundInfo.Text = "";
				}
				else
				{
					Label_QuickTurnaroundInfo.Text = QuickTurnaroundPenaltyText();
				}
			}
			else
			{
				if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
				{
					CB_QuickTurnaround.CheckState = CheckState.Unchecked;
				}
				else
				{
					CB_QuickTurnaround.Checked = false;
				}
				RunContainer(_AccountImporter);
				Combo_NumberOfSorties.Enabled = false;
				Label_QuickTurnaroundInfo.Enabled = false;
				Label_QuickTurnaroundInfo.Text = "";
			}
		}
		else
		{
			CB_QuickTurnaround.Enabled = false;
			if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
			{
				CB_QuickTurnaround.CheckState = CheckState.Unchecked;
			}
			else
			{
				CB_QuickTurnaround.Checked = false;
			}
			RunContainer(_AccountImporter);
		}
		_AuthenticationImporter = true;
	}

	private void PrepareContainer(Aircraft aircraft_0)
	{
		new SQLiteHelper(Client.CurrentScenario.DBConnection);
		try
		{
			if (m_RoleImporter.Rows.Count > 0 && Conversions.ToInteger(m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["ID"]) > 4)
			{
				Label1.Text = "范围和飞行剖面：" + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["RangeProfileDescription"].ToString();
				Label2.Text = Conversions.ToString(m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["LoadoutRoleDescription"]);
				Label4.Text = "功能：" + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["TimeofDay"].ToString() + ", " + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["Weather"].ToString() + " 能力";
				Doctrine._WeaponState value = aircraft_0.Doctrine.GetWinchesterShotgun(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
				if (value == Doctrine._WeaponState.LoadoutSetting)
				{
					Label3.Text = "简要武器状态 " + Conversions.ToString(m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["WinchesterShotgunDescription"]);
				}
				else
				{
					string text = Command_Core.Aircraft.LoadoutWeaponStateDescirption(Conversions.ToInteger(m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["ID"]), (int)value, (Loadout.LoadoutRole)Conversions.ToInteger(m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["LoadoutRole"]), Client.CurrentScenario);
					string text2 = Conversions.ToString(m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["WinchesterShotgunDescription"]);
					if (string.CompareOrdinal(text2, text) == 0)
					{
						Label3.Text = "简要武器状态 " + text2;
					}
					else
					{
						Label3.Text = "有效简要武器状态 " + text + Environment.NewLine + "挂载的默认武器状态 " + text2;
					}
				}
				Label5.Text = "攻击高度：" + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["AttackAltitude"].ToString();
				Label6.Text = "弹药库中可用挂载：" + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["NumberOfLoadouts"].ToString();
				Label7.Text = "可用挂载，包括所有飞机上挂载的武器：" + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["NumberOfLoadoutsIncludingMountedWeapons"].ToString();
				Label8.Text = "可用挂载，包括所有飞机上挂载的武器，但不包括可选武器：" + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"].ToString();
				Label_Loadout.Text = "挂载详情：" + m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["Name"].ToString();
				int int_ = Conversions.ToInteger(m_RoleImporter.AsEnumerable().ElementAtOrDefault(0)["ID"]);
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				m_FactoryImporter = DBFunctions.ItemsForThisLoadout(int_, ref sqliteConnection_, ref aircraft_0.Loadout.NoOptionalWeapons);
				m_FactoryImporter.Columns.Add("Available");
				m_FactoryImporter.Columns.Add("AvailableTotal");
				IEnumerator enumerator = null;
				try
				{
					enumerator = m_FactoryImporter.Rows.GetEnumerator();
					while (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						int num = Conversions.ToInteger(dataRow["ComponentID"]);
						int int_2 = Conversions.ToInteger(dataRow["ComponentID"]);
						Scenario scenario_ = Client.CurrentScenario;
						if (Weapon.WeaponIsNonRivalrous(int_2, ref scenario_))
						{
							dataRow["Available"] = "-";
							dataRow["AvailableTotal"] = "-";
						}
						else if (Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
						{
							dataRow["Available"] = "Unlimited";
							dataRow["AvailableTotal"] = "Unlimited";
						}
						else
						{
							int num2 = ((Aircraft)TGV_Aircraft.SelectedRows[0].Tag).AirOps.CurrentHostUnit.Weaponry.HowManyOfThisWeaponOnMagazines(num);
							int num3 = 0;
							if (!Information.IsNothing(m_InfoImporter) && m_InfoImporter.ContainsKey(num))
							{
								num3 = m_InfoImporter[num];
							}
							dataRow["Available"] = num2;
							dataRow["AvailableTotal"] = num2 + num3;
						}
						dataRow["Item"] = Misc.ReadRequest(Conversions.ToString(dataRow["Item"]));
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
			}
			else
			{
				Label1.Text = "";
				Label2.Text = "";
				Label4.Text = "";
				Label3.Text = "";
				Label5.Text = "";
				Label6.Text = "";
				Label7.Text = "";
				Label8.Text = "";
				Label_Loadout.Text = "挂载详情：未选择";
				m_FactoryImporter.Rows.Clear();
			}
			DGV_LoadoutItems.AutoGenerateColumns = false;
			DGV_LoadoutItems.DataSource = m_FactoryImporter;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101136", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ReflectContainer(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F6 && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Add && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.End && e.KeyCode != Keys.Home))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void VisitContainer(object sender, EventArgs e)
	{
		RestartContainer();
	}

	private void RestartContainer()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					list.Add((Aircraft)node2.Tag);
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
			WriteContainer();
			ExcludeContainer();
			_ = TGV_Aircraft.Nodes.Count;
		}
	}

	private void TestContainer(object sender, EventArgs e)
	{
		StopContainer();
	}

	private void StopContainer()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					list.Add((Aircraft)node2.Tag);
				}
			}
		}
		ItemExporter.ConnectInterruptibleTemplate.TimeToReadyWindow.SelectedUnits = list;
		ItemExporter.ConnectInterruptibleTemplate.TimeToReadyWindow.Show();
	}

	private void CancelContainer(object sender, EventArgs e)
	{
		VerifyContainer();
	}

	private void VerifyContainer()
	{
		try
		{
			List<TreeGridNode> list = new List<TreeGridNode>();
			foreach (TreeGridNode node in TGV_Aircraft.Nodes)
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
				Aircraft aircraft = (Aircraft)item.Tag;
				aircraft.AirOps.HostAirFacility.HostedAircraft.Remove(aircraft.ObjectID);
				Client.CurrentScenario.DeleteUnitImmediately(aircraft.ObjectID, bool_0: true, "Aircraft deleted");
				item.Parent.Nodes.Remove(item);
			}
			if (Client.CurrentGame.Status == Game._GameStatus.Paused)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, bool_0: false);
			}
			InvokeContainer();
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.LoadWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 260112", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ListContainer(object sender, EventArgs e)
	{
		Label_QuickTurnaroundInfo.Text = QuickTurnaroundPenaltyText();
		if (_AuthenticationImporter)
		{
			foreach (Aircraft selectedAircraft in GetSelectedAircrafts())
			{
				Aircraft aircraft_ = selectedAircraft;
				Aircraft_AirOps aircraft_AirOps_ = aircraft_.AirOps;
				if (aircraft_AirOps_.QuickTurnaround_SortiesFlown < Combo_NumberOfSorties.SelectedIndex + 2)
				{
					if (Combo_NumberOfSorties.SelectedIndex + 2 <= aircraft_.Loadout.QuickTurnaround_MaxSorties)
					{
						aircraft_AirOps_.QuickTurnaround_SortiesTotal = Combo_NumberOfSorties.SelectedIndex + 2;
					}
				}
				else if (DarkMessageBox.ShowWarning("飞机" + aircraft_.Name + "快速再次出动架次等于或大于所选的最大架次数量。你想改成这个数量并退出戒备吗？", "更改最大架次数并退出戒备？", DarkDialogButton.YesNo) == DialogResult.Yes)
				{
					aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_);
					if (Combo_NumberOfSorties.SelectedIndex + 2 <= aircraft_.Loadout.QuickTurnaround_MaxSorties)
					{
						aircraft_AirOps_.QuickTurnaround_SortiesTotal = Combo_NumberOfSorties.SelectedIndex + 2;
					}
				}
			}
		}
		RefreshForm();
	}

	public string QuickTurnaroundPenaltyText()
	{
		if (Combo_NumberOfSorties.SelectedIndex + 2 <= _AccountImporter)
		{
			return Conversions.ToString(Combo_NumberOfSorties.SelectedIndex + 2) + " 架次 @ " + Misc.UpdateRequest(m_GlobalImporter * 60) + "最大滞空时间和" + Misc.UpdateRequest(m_WorkerImporter * 60) + "转弯，有" + Misc.UpdateRequest(attributeImporter * 60) + "退出戒备准备时间";
		}
		return "";
	}

	private void ResolveContainer(int? nullable_0)
	{
		Combo_NumberOfSorties.Items.Clear();
		Combo_NumberOfSorties.SelectedIndex = -1;
		if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate || !CB_QuickTurnaround.Checked)
		{
			return;
		}
		int accountImporter = _AccountImporter;
		for (int i = 2; i <= accountImporter; i++)
		{
			if (i == _AccountImporter)
			{
				Combo_NumberOfSorties.Items.Add(Conversions.ToString(i) + "架次（最大）");
			}
			else
			{
				Combo_NumberOfSorties.Items.Add(Conversions.ToString(i) + "架次");
			}
		}
		if (!Information.IsNothing(nullable_0) && Combo_NumberOfSorties.Items.Count > 0)
		{
			Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)GetSelectedAircrafts()[0].AirOps;
			if (aircraft_AirOps.QuickTurnaround_SortiesTotal == 0)
			{
				Combo_NumberOfSorties.SelectedIndex = _AccountImporter - 2;
				return;
			}
			if (Combo_NumberOfSorties.Items.Count >= aircraft_AirOps.QuickTurnaround_SortiesTotal - 2)
			{
				try
				{
					Combo_NumberOfSorties.SelectedIndex = aircraft_AirOps.QuickTurnaround_SortiesTotal - 2;
					return;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					Combo_NumberOfSorties.SelectedIndex = 0;
					ProjectData.ClearProjectError();
					return;
				}
			}
			Combo_NumberOfSorties.SelectedIndex = Combo_NumberOfSorties.Items.Count - 1;
		}
		else
		{
			Combo_NumberOfSorties.Items.Add("Various");
			Combo_NumberOfSorties.SelectedIndex = Combo_NumberOfSorties.Items.Count - 1;
		}
	}

	private void PostContainer(object sender, EventArgs e)
	{
		if (_AuthenticationImporter)
		{
			RunContainer(_AccountImporter);
		}
		RefreshForm();
	}

	private void RunContainer(int? nullable_0)
	{
		if (CB_QuickTurnaround.Checked)
		{
			Combo_NumberOfSorties.Enabled = true;
			ResolveContainer(nullable_0);
			Label_QuickTurnaroundInfo.Enabled = true;
			Label_QuickTurnaroundInfo.Text = QuickTurnaroundPenaltyText();
			if (!_AuthenticationImporter)
			{
				return;
			}
			{
				foreach (Aircraft selectedAircraft in GetSelectedAircrafts())
				{
					selectedAircraft.AirOps.QuickTurnaround_Enabled = true;
				}
				return;
			}
		}
		Combo_NumberOfSorties.Enabled = false;
		ResolveContainer(nullable_0);
		Label_QuickTurnaroundInfo.Enabled = false;
		Label_QuickTurnaroundInfo.Text = "";
		if (!_AuthenticationImporter)
		{
			return;
		}
		foreach (Aircraft selectedAircraft2 in GetSelectedAircrafts())
		{
			Aircraft aircraft_ = selectedAircraft2;
			Aircraft_AirOps aircraft_AirOps_ = aircraft_.AirOps;
			if (aircraft_AirOps_.QuickTurnaround_SortiesFlown <= 0)
			{
				aircraft_AirOps_.QuickTurnaround_Enabled = false;
				aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_);
			}
			else if (DarkMessageBox.ShowWarning("飞机" + aircraft_.Name + "之前启用了快速再次出动，并且至少有一个快速再次出动架次已起飞。您想要禁用快速再次出动并解除戒备吗？", "禁用快速再次出动并解除戒备？", DarkDialogButton.YesNo) == DialogResult.Yes)
			{
				aircraft_AirOps_.QuickTurnaround_Enabled = false;
				aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_);
			}
		}
	}

	private void StartContainer(object sender, FormClosedEventArgs e)
	{
		Aircraft_AirOps.TookOff -= LoginContainer;
		Aircraft_AirOps.Landing -= ViewContainer;
		Group.UnitAdded -= PatchContainer;
		Group.UnitRemoved -= SelectContainer;
	}

	private void AssetContainer(object sender, EventArgs e)
	{
	}

	private void PrintContainer(object sender, EventArgs e)
	{
		algoImporter.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					algoImporter.Add(((Aircraft)node2.Tag).ObjectID);
				}
			}
		}
		TSB_AssignToMission.DropDownItems.Clear();
		if (GetSelectedAircrafts().Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripMenuItem)TSB_AssignToMission.DropDown.Items.Add("< Unassign >", null, AssetContainer)).Tag = null;
		foreach (Mission item in Client.CurrentSide.Missions.OrderBy((Mission theM) => theM.Name))
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem = (ToolStripMenuItem)TSB_AssignToMission.DropDown.Items.Add(item.Name, null, AssetContainer);
			toolStripMenuItem.Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				toolStripMenuItem2 = (ToolStripMenuItem)TSB_AssignToMission.DropDown.Items.Add(item.Name + " - 护航", null, AssetContainer);
				toolStripMenuItem2.Tag = item;
			}
			if (GetSelectedAircrafts().Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = GetSelectedAircrafts()[0];
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

	private void DefineContainer(object sender, ToolStripItemClickedEventArgs e)
	{
		PublishContainer(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void PublishContainer(object sender, ToolStripItemClickedEventArgs e)
	{
		CheckContainer(bool_0: false, bool_1: true, bool_2: true, bool_3: false, bool_4: false);
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(e.ClickedItem.Tag)))
		{
			foreach (ActiveUnit selectedAircraft in GetSelectedAircrafts())
			{
				ActiveUnit activeUnit_ = selectedAircraft;
				Client.RemoveUnitFromMission(ref activeUnit_);
			}
		}
		else
		{
			Mission mission_ = (Mission)e.ClickedItem.Tag;
			bool bool_ = Strings.InStr(e.ClickedItem.Text, " - 护航", CompareMethod.Text) != 0;
			Client.AssignToMission(RuntimeHelpers.GetObjectValue(sender), GetSelectedAircrafts(), ref mission_, ref bool_);
			foreach (ActiveUnit selectedAircraft2 in GetSelectedAircrafts())
			{
				ActiveUnit activeUnit_2 = selectedAircraft2;
				MissionPlanner.CheckRangeToMissionTargets_LoadoutRadius(activeUnit_2.ParentScen, mission_, ref activeUnit_2);
			}
		}
		RefreshForm();
	}

	private void AwakeContainer(object sender, EventArgs e)
	{
		CheckContainer(bool_0: false, bool_1: true, bool_2: true, bool_3: false, bool_4: false);
		if (GetSelectedAircrafts().Count > 0)
		{
			MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = null;
			List<ActiveUnit> list_ = GetSelectedAircrafts().ToList();
			mainForm.ShowDoctrineROE(null, ref readOnlyCollection_, ref list_, bool_0: false);
		}
	}

	private void QueryContainer(object sender, EventArgs e)
	{
		InitContainer();
	}

	private void ResetContainer(object sender, EventArgs e)
	{
		FillContainer();
	}

	private void MapContainer(object sender, EventArgs e)
	{
		InterruptContainer();
	}

	private void SortContainer(object sender, EventArgs e)
	{
		CompareContainer();
	}

	private void CalcContainer(object sender, EventArgs e)
	{
		CheckContainer(bool_0: false, bool_1: true, bool_2: true, bool_3: false, bool_4: false);
		if (GetSelectedAircrafts().Count > 0)
		{
			MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
			ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = null;
			List<ActiveUnit> list_ = GetSelectedAircrafts().ToList();
			mainForm.ShowDoctrineROE(null, ref readOnlyCollection_, ref list_, bool_0: false);
		}
	}

	private void RateContainer(object sender, EventArgs e)
	{
	}

	private void FlushContainer(object sender, EventArgs e)
	{
		StopContainer();
	}

	private void ForgotContainer(object sender, EventArgs e)
	{
		RestartContainer();
	}

	private void CollectContainer(object sender, EventArgs e)
	{
		VerifyContainer();
	}

	private void OrderContainer()
	{
		try
		{
			List<ActiveUnit> list = new List<ActiveUnit>();
			foreach (TreeGridNode node in TGV_Aircraft.Nodes)
			{
				foreach (TreeGridNode node2 in node.Nodes)
				{
					if (node2.Selected)
					{
						list.Add((Aircraft)node2.Tag);
						break;
					}
				}
				if (list.Count > 0)
				{
					break;
				}
			}
			int num = 1;
			Aircraft aircraft = (Aircraft)list[0];
			if (aircraft.Loadout == null || aircraft.Int32_0 == 0)
			{
				return;
			}
			Scenario scenario_ = Client.CurrentScenario;
			Loadout loadout = DBFunctions.GetLoadout(ref scenario_, aircraft.Int32_0, bool_0: false, bool_1: true);
			ActiveUnit currentHostUnit = aircraft.AirOps.CurrentHostUnit;
			WeaponRec[] weapons = loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				weaponRec.MaxLoad *= num;
				weaponRec.CurrentLoad *= num;
				int num2 = 0;
				int num3 = 0;
				if (weaponRec.CurrentLoad <= 0)
				{
					continue;
				}
				int currentLoad = weaponRec.CurrentLoad;
				for (int i = 1; i <= currentLoad; i++)
				{
					if (Operators.CompareString(currentHostUnit.Weaponry.AddWeaponToMagazines(weaponRec.int_0, bool_1: true, bool_2: true), "OK", TextCompare: true) == 0)
					{
						num2++;
					}
					else
					{
						num3++;
					}
				}
			}
			if (list.Count <= 0)
			{
				PrepareContainer(null);
			}
			else
			{
				PrepareContainer((Aircraft)list[0]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1732", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RegisterContainer(object sender, EventArgs e)
	{
		OrderContainer();
	}

	private void ManageContainer()
	{
		SetTimeToReadyToolStripMenuItem.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		RenameToolStripMenuItem.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		RemoveToolStripMenuItem.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		AddLoadoutToolStripMenuItem.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		ToolStripSeparator4.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		if (GetSelectedAircrafts().Count <= 0)
		{
			LaunchIndividuallyToolStripMenuItem.Enabled = false;
			LaunchAsGroupsToolStripMenuItem.Enabled = false;
			ReadyArmToolStripMenuItem.Enabled = false;
			AbortLaunchToolStripMenuItem.Enabled = false;
			TSMI_Doctrine.Enabled = false;
			TSMI_AssignToMission.Enabled = false;
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				SetTimeToReadyToolStripMenuItem.Enabled = false;
				RenameToolStripMenuItem.Enabled = false;
				RemoveToolStripMenuItem.Enabled = false;
				AddLoadoutToolStripMenuItem.Enabled = false;
			}
		}
		else
		{
			LaunchIndividuallyToolStripMenuItem.Enabled = true;
			LaunchAsGroupsToolStripMenuItem.Enabled = true;
			ReadyArmToolStripMenuItem.Enabled = true;
			AbortLaunchToolStripMenuItem.Enabled = true;
			TSMI_Doctrine.Enabled = true;
			TSMI_AssignToMission.Enabled = true;
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				SetTimeToReadyToolStripMenuItem.Enabled = true;
				RenameToolStripMenuItem.Enabled = true;
				RemoveToolStripMenuItem.Enabled = true;
				AddLoadoutToolStripMenuItem.Enabled = true;
			}
		}
		algoImporter.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected)
				{
					algoImporter.Add(((Aircraft)node2.Tag).ObjectID);
				}
			}
		}
		TSMI_AssignToMission.DropDownItems.Clear();
		if (GetSelectedAircrafts().Count <= 0)
		{
			return;
		}
		new ToolStripMenuItem();
		((ToolStripMenuItem)TSMI_AssignToMission.DropDown.Items.Add("< Unassign >", null, RateContainer)).Tag = null;
		foreach (Mission item in Client.CurrentSide.Missions.OrderBy((Mission theM) => theM.Name))
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
			ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
			toolStripMenuItem = (ToolStripMenuItem)TSMI_AssignToMission.DropDown.Items.Add(item.Name, null, RateContainer);
			toolStripMenuItem.Tag = item;
			if (item.MissionClass == Command_Core.Mission._MissionClass.Strike)
			{
				toolStripMenuItem2 = (ToolStripMenuItem)TSMI_AssignToMission.DropDown.Items.Add(item.Name + " - 护航", null, RateContainer);
				toolStripMenuItem2.Tag = item;
			}
			if (GetSelectedAircrafts().Count != 1)
			{
				continue;
			}
			ActiveUnit activeUnit = GetSelectedAircrafts()[0];
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

	private void RevertContainer(object sender, CancelEventArgs e)
	{
		ManageContainer();
	}

	private void CountComposer(object sender, ToolStripItemClickedEventArgs e)
	{
		PublishContainer(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void CustomizeComposer(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.Pause)
		{
			Client.CurrentGame.Pause();
		}
		else if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnAirDockOps == SimConfiguration.WindowPauseBehaviour.SlowToRealTime)
		{
			Client.CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		}
	}

	private void CloneComposer(object sender, EventArgs e)
	{
		algoImporter.Clear();
		foreach (TreeGridNode node in TGV_Aircraft.Nodes)
		{
			if (node.Selected)
			{
				foreach (Aircraft item in (IEnumerable<Aircraft>)node.Tag)
				{
					if (item.AirOps.CanBeRearmedRightNow())
					{
						algoImporter.Add(item.ObjectID);
					}
				}
			}
			if (GetSelectedAircrafts().Count > 0)
			{
				break;
			}
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Selected && ((Aircraft)node2.Tag).AirOps.CanBeRearmedRightNow())
				{
					algoImporter.Add(((Aircraft)node2.Tag).ObjectID);
				}
			}
			if (GetSelectedAircrafts().Count > 0)
			{
				break;
			}
		}
		if (GetSelectedAircrafts().Count == 1)
		{
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsV2_0.CargoUnit = GetSelectedAircrafts()[0];
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsV2_0.HostUnit = ((Aircraft)GetSelectedAircrafts()[0]).AirOps.CurrentHostUnit;
			ItemExporter.ConnectInterruptibleTemplate.CargoOpsV2_0.Show();
		}
	}

	private void ConnectComposer(object sender, ExpandedEventArgs e)
	{
		e.Node.Nodes.Clear();
		if (e.Node.Level != 1)
		{
			return;
		}
		List<Aircraft> Local_theCol = null;
		int dBID = ((IEnumerable<Aircraft>)e.Node.Tag).ElementAtOrDefault(0).DBID;
		if (!iteratorImporter.Contains(dBID))
		{
			iteratorImporter.Add(dBID);
		}
		if (m_GetterImporter)
		{
			Local_theCol = ((IEnumerable<Aircraft>)e.Node.Tag).Select((Aircraft theAC) => theAC).ToList();
			Local_theCol.Sort((Aircraft theAirc, Aircraft theAirc2) => theAirc.AirOps.ConditionTimer.CompareTo(theAirc2.AirOps.ConditionTimer));
		}
		else if (producerImporter)
		{
			Local_theCol = ((IEnumerable<Aircraft>)e.Node.Tag).Select((Aircraft theAC) => theAC).ToList();
			Local_theCol.Sort((Aircraft theAirc, Aircraft theAirc2) => theAirc.LoadoutName.CompareTo(theAirc2.LoadoutName));
		}
		else
		{
			Local_theCol = ((IEnumerable<Aircraft>)e.Node.Tag).Select((Aircraft theAC) => theAC).OrderBy((Aircraft theAirc) => theAirc.Name, new NaturalSortComparer<string[]>()).ToList();
		}
		Task.Factory.StartNew(delegate
		{
			using List<Aircraft>.Enumerator enumerator = Local_theCol.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TreeGridNode Local_theNode = null;
				string Local_MissionText = null;
				string Local_theLoadoutName = null;
				Aircraft Local_theAC = enumerator.Current;
				if (Information.IsNothing(Local_theAC.Loadout))
				{
					Local_theLoadoutName = "No Loadout";
				}
				else
				{
					Local_theLoadoutName = Local_theAC.Loadout.Name;
				}
				if (Information.IsNothing(Local_theAC.AssignedMissionOrPackage()))
				{
					if (Information.IsNothing(Local_theAC.AssignedTaskPool))
					{
						Local_MissionText = "-";
					}
					else
					{
						Local_MissionText = Local_theAC.AssignedTaskPool.Name + "（任务池）";
					}
				}
				else
				{
					string text = "";
					if (Local_theAC.AI.IsEscort)
					{
						text = "，护航";
					}
					Local_MissionText = Local_theAC.AssignedMissionOrPackage().Name + " (" + Local_theAC.AssignedMissionOrPackage().GetDescriptionString(Client.CurrentScenario) + text + ")";
				}
				string Local_theName = Local_theAC.Name;
				if (Local_theAC.GetUnitSide() != Client.CurrentSide)
				{
					Local_theName = Local_theName + " (" + Local_theAC.GetUnitSide().Name + ")";
				}
				TGV_Aircraft.Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					TreeGridNodeCollection nodes = e.Node.Nodes;
					object[] array = new object[6]
					{
						Local_theName,
						Local_theAC.AirOps.ConditionString,
						Local_MissionText,
						Misc.ReadRequest(Local_theLoadoutName),
						null,
						null
					};
					long long_ = (long)Math.Round(Local_theAC.AirOps.ConditionTimer);
					Aircraft aircraft = Local_theAC;
					string string_2 = null;
					array[4] = Misc.UpdateRequest(long_, aircraft.IsAvailableForOps(ref string_2));
					array[5] = Local_theAC.QuickTurnaroundString();
					Local_theNode = nodes.Add(array);
					Local_theNode.DefaultCellStyle.Font = new Font(Font, FontStyle.Regular);
					MoveComposer(Local_theNode, Local_theAC);
					Local_theNode.Tag = Local_theAC;
				});
				bool paramsImporter = _ParamsImporter;
				string string_ = null;
				if (paramsImporter & (Local_theAC.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance))
				{
					Local_theNode.Visible = false;
				}
				else
				{
					Local_theNode.Visible = true;
				}
				if (Local_theAC.Loadout != null && Local_theAC.Int32_0 > 0)
				{
					Local_theNode.Cells[3].Style.Font = new Font("微软雅黑", 8.25f, FontStyle.Underline);
				}
			}
		});
	}

	private void MoveComposer(TreeGridNode treeGridNode_0, Aircraft aircraft_0)
	{
		string string_;
		if (aircraft_0.AirOps.ConditionTimer == 0f)
		{
			string_ = null;
			if (aircraft_0.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable)
			{
				treeGridNode_0.DefaultCellStyle.ForeColor = Color.LightGreen;
				return;
			}
		}
		string_ = null;
		if (aircraft_0.IsAvailableForOps(ref string_) == Aircraft_AirOps.AirOpsAvailabilityStatus.IsAvailable)
		{
			treeGridNode_0.DefaultCellStyle.ForeColor = Color.Orange;
		}
		else
		{
			treeGridNode_0.DefaultCellStyle.ForeColor = Color.IndianRed;
		}
	}

	private void DeleteComposer(object sender, EventArgs e)
	{
	}

	private ActiveUnit AddComposer()
	{
		if (GetAllValidAircrafts().Count == 1)
		{
			return GetAllValidAircrafts().First();
		}
		if (TV_Facilities.SelectedNodes.Count == 1)
		{
			DarkTreeNode darkTreeNode = TV_Facilities.SelectedNodes.First();
			foreach (ActiveUnit allValidAircraft in GetAllValidAircrafts())
			{
				if (darkTreeNode.Tag == allValidAircraft)
				{
					return allValidAircraft;
				}
			}
		}
		return null;
	}

	private void DestroyComposer(object sender, EventArgs e)
	{
		ActiveUnit activeUnit = AddComposer();
		if (activeUnit == null)
		{
			DarkMessageBox.ShowError("Select a single hosting unit from the facilities list to add facilities.", "No Hosting Unit");
			return;
		}
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.Mode = 0;
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.ParentForm = this;
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.theSelectedUnit = activeUnit;
		ItemExporter.ConnectInterruptibleTemplate.AddHostingFacility.Show();
	}

	private void ComputeComposer(object sender, EventArgs e)
	{
		ActiveUnit activeUnit = null;
		if (TV_Facilities.SelectedNodes.Count > 0)
		{
			foreach (DarkTreeNode selectedNode in TV_Facilities.SelectedNodes)
			{
				if (selectedNode.Tag == null || (object)selectedNode.Tag.GetType() != typeof(AirFacility))
				{
					continue;
				}
				AirFacility airFacility = (AirFacility)selectedNode.Tag;
				if (airFacility.ParentPlatform == null)
				{
					continue;
				}
				bool flag = true;
				if (airFacility.HostedAircraft.Count > 0 && DarkMessageBox.ShowWarning("Facility " + airFacility.Name + " has one or more aircraft present. Removing this facility will delete the aircraft from your scenario.", "Delete Aircraft?", DarkDialogButton.OkCancel) == DialogResult.Cancel)
				{
					flag = false;
				}
				if (!flag)
				{
					continue;
				}
				if (airFacility.HostedAircraft.Count > 0)
				{
					foreach (Aircraft value in airFacility.HostedAircraft.Values)
					{
						LoginContainer(value);
						Client.CurrentScenario.DeleteUnitImmediately(value.ObjectID, bool_0: true, "Manually deleted by user");
					}
				}
				activeUnit = airFacility.ParentPlatform;
				activeUnit.RemoveAirFacility(airFacility);
			}
		}
		if (activeUnit != null)
		{
			RefreshForm();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, activeUnit, bool_0: false);
		}
	}

	private void PatchComposer(object sender, EventArgs e)
	{
		m_ManagerImporter = !m_ManagerImporter;
		SelectComposer();
	}

	private void SelectComposer()
	{
		if (m_ManagerImporter)
		{
			TGV_Aircraft.ExpandAllItems();
			DarkUIButton_0.Text = "折叠飞机列表";
		}
		else
		{
			TGV_Aircraft.CollapseAllItem();
			DarkUIButton_0.Text = "展开飞机列表";
		}
		WriteContainer();
	}

	private void CallComposer(bool bool_0)
	{
		m_ManagerImporter = bool_0;
		if (m_ManagerImporter)
		{
			DarkUIButton_0.Text = "折叠飞机列表";
		}
		else
		{
			DarkUIButton_0.Text = "展开飞机列表";
		}
	}

	private void LogoutComposer(object sender, EventArgs e)
	{
		_ParamsImporter = !_ParamsImporter;
		if (_ParamsImporter)
		{
			btnHideShowMaintenance.Text = "显示不可用";
		}
		else
		{
			btnHideShowMaintenance.Text = "隐藏不可用";
		}
		WriteContainer();
	}

	private void ViewComposer(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex == 4)
		{
			m_GetterImporter = true;
			producerImporter = false;
		}
		else if (e.ColumnIndex == 3)
		{
			m_GetterImporter = false;
			producerImporter = true;
		}
		else
		{
			m_GetterImporter = false;
			producerImporter = false;
		}
		foreach (TreeGridNode allNode in GetAllNodes())
		{
			if (allNode.IsExpanded)
			{
				ExpandedEventArgs e2 = new ExpandedEventArgs(allNode);
				ConnectComposer(allNode, e2);
			}
		}
	}

	private void ValidateComposer(object sender, EventArgs e)
	{
		AddUnit.CalledFromAirOps = true;
		ItemExporter.ConnectInterruptibleTemplate.AddUnit.Show();
	}

	private void LoginComposer(ActiveUnit activeUnit_0)
	{
		bool flag = false;
		if (!AddUnit.CalledFromAirOps)
		{
			return;
		}
		foreach (DarkTreeNode node in TV_Facilities.Nodes)
		{
			ActiveUnit activeUnit = (ActiveUnit)node.Tag;
			if (!activeUnit_0.IsAircraft)
			{
				break;
			}
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(node.Tag)) && activeUnit.AirOps != null)
			{
				if (activeUnit.AirOps.CanHostThisAircraft((Aircraft)activeUnit_0) == AirOpsAttemptResult.Success)
				{
					((Aircraft)activeUnit_0).AirOps.HostAirFacility = null;
					activeUnit.AirOps.AddThisAircraft((Aircraft)activeUnit_0, bool_0: false);
					activeUnit_0.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
					flag = true;
					break;
				}
				if (Client.CurrentSide.IsHumanControlled)
				{
					DarkMessageBox.ShowError("The Unit " + activeUnit_0.Name + " Cannot be hosted", "Unit cannot be hosted");
				}
			}
		}
		if (flag)
		{
			TGV_Aircraft.Enabled = true;
			ViewContainer((Aircraft)activeUnit_0);
			SetupContainer();
			RefreshAll();
		}
		else
		{
			Client.CurrentScenario.DeleteUnitImmediately(activeUnit_0.ObjectID, bool_0: true, activeUnit_0.Name + " Unit could not be hosted");
		}
	}
}
