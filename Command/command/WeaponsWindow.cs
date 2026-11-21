using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
public sealed class WeaponsWindow : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class DicMerchantPage
	{
		public WeaponsWindow Me;

		public TreeGridNode Local_theNode;

		public Mount Local_theMount;

		public WeaponRec Local_theRec;

		internal void ResetInterruptibleMethod()
		{
			Me.CompareInterruptibleCreator(Local_theNode, Local_theMount, Local_theRec);
			if (!Local_theNode.IsExpanded)
			{
				Local_theNode.Expand();
			}
		}
	}

	[CompilerGenerated]
	private sealed class RulesCallbackCandidate
	{
		public TreeGridNode Local_theNode;

		public TreeGridNode Local_theRecNode;

		internal void MapInterruptibleMethod()
		{
			Local_theNode.Nodes.Remove(Local_theRecNode);
		}
	}

	[CompilerGenerated]
	private sealed class SystemExpressionDic
	{
		public WeaponsWindow Me;

		public TreeGridNode Local_theNode;

		public WeaponRec Local_theRec;

		internal void SortInterruptibleMethod()
		{
			Me.ReadInterruptibleCreator(Local_theNode, Local_theRec);
			if (!Local_theNode.IsExpanded)
			{
				Local_theNode.Expand();
			}
		}
	}

	[CompilerGenerated]
	private sealed class GetterProcessResolver
	{
		public TreeGridNode Local_theNode;

		public TreeGridNode Local_theRecNode;

		internal void CalcInterruptibleMethod()
		{
			Local_theNode.Nodes.Remove(Local_theRecNode);
		}
	}

	[CompilerGenerated]
	private sealed class ManagerCollectionRecord
	{
		public WeaponsWindow Me;

		public TreeGridNode Local_theNode;

		public Mount Local_theMount;

		internal void RateInterruptibleMethod()
		{
			Me.CreateInterruptibleCreator(Local_theNode, Local_theMount);
		}
	}

	[CompilerGenerated]
	private sealed class ProcMap
	{
		public WeaponsWindow Me;
	}

	[CompilerGenerated]
	private sealed class StructTemplate
	{
		public TreeGridNode Local_theNode;

		public ProcMap CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class MerchantTemplate
	{
		public TreeGridNode Local_theRecNode;

		public WeaponRec Local_theRec;

		public StructTemplate CS_0024_003C_003E8__locals2;

		internal void FlushInterruptibleMethod()
		{
			if ((object)CS_0024_003C_003E8__locals2.Local_theNode.Tag.GetType() == typeof(Mount))
			{
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.DisableInterruptibleCreator(Local_theRecNode, Local_theRec, (Mount)CS_0024_003C_003E8__locals2.Local_theNode.Tag);
			}
			if ((object)CS_0024_003C_003E8__locals2.Local_theNode.Tag.GetType() == typeof(Loadout))
			{
				CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.Me.UpdateInterruptibleCreator(Local_theRecNode, Local_theRec);
			}
		}
	}

	[CompilerGenerated]
	private sealed class CallbackTemplate
	{
		public WeaponsWindow Me;

		public TreeGridNode Local_theNode;

		internal void ForgotInterruptibleMethod()
		{
			Me.TGV_Weapons.Nodes.Remove(Local_theNode);
		}
	}

	[CompilerGenerated]
	private sealed class DecoratorTemplate
	{
		public WeaponsWindow Me;

		public Mount Local_theMount;

		internal void CollectInterruptibleMethod()
		{
			TreeGridNode treeGridNode = Me.TGV_Weapons.Nodes.Add("新节点");
			Me.CreateInterruptibleCreator(treeGridNode, Local_theMount);
			foreach (WeaponRec mountWeapon in Local_theMount.MountWeapons)
			{
				Me.CompareInterruptibleCreator(treeGridNode, Local_theMount, mountWeapon);
			}
			treeGridNode.Expand();
		}
	}

	[CompilerGenerated]
	private sealed class StrategyDecoratorEntry
	{
		public WeaponsWindow Me;

		public ExpandingEventArgs Local_e;

		public Mount Local_theMount;

		internal void OrderInterruptibleMethod()
		{
			using List<WeaponRec>.Enumerator enumerator = Local_theMount.MountWeapons.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ExporterRegistryFilter CS_0024_003C_003E8__locals0 = new ExporterRegistryFilter
				{
					CS_0024_003C_003E8__locals1 = this,
					Local_theWeaponRec = enumerator.Current
				};
				Me.Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Me.CompareInterruptibleCreator(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_e.Node, CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_theMount, CS_0024_003C_003E8__locals0.Local_theWeaponRec);
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class ExporterRegistryFilter
	{
		public WeaponRec Local_theWeaponRec;

		public StrategyDecoratorEntry CS_0024_003C_003E8__locals1;

		internal void RegisterInterruptibleMethod()
		{
			CS_0024_003C_003E8__locals1.Me.CompareInterruptibleCreator(CS_0024_003C_003E8__locals1.Local_e.Node, CS_0024_003C_003E8__locals1.Local_theMount, Local_theWeaponRec);
		}
	}

	private IContainer valueExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Mount")]
	private TreeGridColumn m_TokenizerExporter;

	[AccessedThroughProperty("Status")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn writerExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TGV_Weapons")]
	private DarkTreeGridView m_SpecificationExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("ImageList1")]
	private ImageList watcherExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer m_ReponseExporter;

	[AccessedThroughProperty("TSB_AddRec")]
	[CompilerGenerated]
	private ToolStripButton _PoolExporter;

	[AccessedThroughProperty("TSB_RemoveRec")]
	[CompilerGenerated]
	private ToolStripButton taskExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSL_WeaponCount1")]
	private ToolStripLabel m_FilterExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSTB_RecCount")]
	private ToolStripTextBox m_TestsExporter;

	[AccessedThroughProperty("TSB_AddMount")]
	[CompilerGenerated]
	private ToolStripButton interpreterExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveMount")]
	private ToolStripButton containerExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSL_WeaponCount2")]
	private ToolStripLabel m_ComposerExporter;

	[AccessedThroughProperty("TSB_ChangeWeaponCount")]
	[CompilerGenerated]
	private ToolStripButton _ModelExporter;

	[AccessedThroughProperty("ToolStripSeparator1")]
	[CompilerGenerated]
	private ToolStripSeparator m_AdvisorExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripSeparator2")]
	private ToolStripSeparator m_CustomerExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("Column1")]
	private TreeGridColumn serializerExporter;

	[AccessedThroughProperty("Column3")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_CodeExporter;

	[CompilerGenerated]
	[AccessedThroughProperty("ReloadPriority")]
	private DataGridViewCheckBoxColumn connectionExporter;

	[AccessedThroughProperty("ShowArcs")]
	[CompilerGenerated]
	private DataGridViewCheckBoxColumn contextExporter;

	private ActiveUnit _StatusExporter;

	private WeaponRec m_ProccesorExporter;

	private Mount m_StrategyExporter;

	private Loadout m_ConfigurationExporter;

	private bool tokenExporter;

	private bool indexerExporter;

	private bool m_ResolverExporter;

	private bool publisherExporter;

	private Keys[] serverExporter;

	internal TreeGridColumn Mount
	{
		[CompilerGenerated]
		get
		{
			return m_TokenizerExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenizerExporter = value;
		}
	}

	[field: AccessedThroughProperty("WeaponType")]
	internal DataGridViewTextBoxColumn WeaponType
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Status
	{
		[CompilerGenerated]
		get
		{
			return writerExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			writerExporter = value;
		}
	}

	private DarkTreeGridView TGV_Weapons
	{
		[CompilerGenerated]
		get
		{
			return m_SpecificationExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellPaintingEventHandler value2 = CheckInterruptibleCreator;
			DataGridViewCellEventHandler value3 = VisitInterruptibleCreator;
			ExpandingEventHandler value4 = RestartInterruptibleCreator;
			DataGridViewCellEventHandler value5 = StopInterruptibleCreator;
			EventHandler value6 = ListInterruptibleCreator;
			DarkTreeGridView specificationExporter = m_SpecificationExporter;
			if (specificationExporter != null)
			{
				specificationExporter.CellPainting -= value2;
				specificationExporter.CellClick -= value3;
				specificationExporter.NodeExpanding -= value4;
				specificationExporter.CellContentClick -= value5;
				specificationExporter.SelectionChanged -= value6;
			}
			m_SpecificationExporter = value;
			specificationExporter = m_SpecificationExporter;
			if (specificationExporter != null)
			{
				specificationExporter.CellPainting += value2;
				specificationExporter.CellClick += value3;
				specificationExporter.NodeExpanding += value4;
				specificationExporter.CellContentClick += value5;
				specificationExporter.SelectionChanged += value6;
			}
		}
	}

	[field: AccessedThroughProperty("TS_Edit")]
	internal DarkToolStrip TS_Edit
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_AddRec
	{
		[CompilerGenerated]
		get
		{
			return _PoolExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareInterruptibleCreator;
			ToolStripButton poolExporter = _PoolExporter;
			if (poolExporter != null)
			{
				poolExporter.Click -= value2;
			}
			_PoolExporter = value;
			poolExporter = _PoolExporter;
			if (poolExporter != null)
			{
				poolExporter.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_RemoveRec
	{
		[CompilerGenerated]
		get
		{
			return taskExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectInterruptibleCreator;
			ToolStripButton toolStripButton = taskExporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			taskExporter = value;
			toolStripButton = taskExporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripLabel TSL_WeaponCount1
	{
		[CompilerGenerated]
		get
		{
			return m_FilterExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FilterExporter = value;
		}
	}

	internal ToolStripTextBox TSTB_RecCount
	{
		[CompilerGenerated]
		get
		{
			return m_TestsExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostInterruptibleCreator;
			EventHandler value3 = RunInterruptibleCreator;
			ToolStripTextBox testsExporter = m_TestsExporter;
			if (testsExporter != null)
			{
				testsExporter.Enter -= value2;
				testsExporter.Leave -= value3;
			}
			m_TestsExporter = value;
			testsExporter = m_TestsExporter;
			if (testsExporter != null)
			{
				testsExporter.Enter += value2;
				testsExporter.Leave += value3;
			}
		}
	}

	internal ToolStripButton TSB_AddMount
	{
		[CompilerGenerated]
		get
		{
			return interpreterExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestInterruptibleCreator;
			ToolStripButton toolStripButton = interpreterExporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			interpreterExporter = value;
			toolStripButton = interpreterExporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_RemoveMount
	{
		[CompilerGenerated]
		get
		{
			return containerExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleCreator;
			ToolStripButton toolStripButton = containerExporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			containerExporter = value;
			toolStripButton = containerExporter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripLabel TSL_WeaponCount2
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerExporter = value;
		}
	}

	internal ToolStripButton TSB_ChangeWeaponCount
	{
		[CompilerGenerated]
		get
		{
			return _ModelExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleCreator;
			ToolStripButton modelExporter = _ModelExporter;
			if (modelExporter != null)
			{
				modelExporter.Click -= value2;
			}
			_ModelExporter = value;
			modelExporter = _ModelExporter;
			if (modelExporter != null)
			{
				modelExporter.Click += value2;
			}
		}
	}

	internal ToolStripSeparator ToolStripSeparator1
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorExporter = value;
		}
	}

	internal ToolStripSeparator ToolStripSeparator2
	{
		[CompilerGenerated]
		get
		{
			return m_CustomerExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CustomerExporter = value;
		}
	}

	internal TreeGridColumn Column1
	{
		[CompilerGenerated]
		get
		{
			return serializerExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerExporter = value;
		}
	}

	[field: AccessedThroughProperty("Type")]
	internal DataGridViewTextBoxColumn Type
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TimeToFire")]
	internal DataGridViewTextBoxColumn TimeToFire
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Column3
	{
		[CompilerGenerated]
		get
		{
			return m_CodeExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeExporter = value;
		}
	}

	internal DataGridViewCheckBoxColumn ReloadPriority
	{
		[CompilerGenerated]
		get
		{
			return connectionExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionExporter = value;
		}
	}

	internal DataGridViewCheckBoxColumn ShowArcs
	{
		[CompilerGenerated]
		get
		{
			return contextExporter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			contextExporter = value;
		}
	}

	public ActiveUnit theSelectedUnit
	{
		get
		{
			return _StatusExporter;
		}
		set
		{
			bool flag = false;
			if (value != null)
			{
				flag = value != _StatusExporter;
			}
			_StatusExporter = value;
			if (flag && base.Visible && publisherExporter)
			{
				BuildForm();
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal ImageList CalcInterruptibleCreator()
	{
		return watcherExporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RateInterruptibleCreator(ImageList imageList_0)
	{
		watcherExporter = imageList_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer ForgotInterruptibleCreator()
	{
		return m_ReponseExporter;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CollectInterruptibleCreator(Timer timer_0)
	{
		EventHandler value = AssetInterruptibleCreator;
		Timer reponseExporter = m_ReponseExporter;
		if (reponseExporter != null)
		{
			reponseExporter.Tick -= value;
		}
		m_ReponseExporter = timer_0;
		reponseExporter = m_ReponseExporter;
		if (reponseExporter != null)
		{
			reponseExporter.Tick += value;
		}
	}

	public WeaponsWindow()
	{
		base.FormClosing += EnableInterruptibleCreator;
		base.VisibleChanged += ChangeInterruptibleCreator;
		base.Load += InitInterruptibleCreator;
		base.KeyDown += ResolveInterruptibleCreator;
		base.FormClosed += StartInterruptibleCreator;
		indexerExporter = false;
		serverExporter = new Keys[2]
		{
			Keys.F8,
			Keys.Escape
		};
		SearchInterruptibleCreator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && valueExporter != null)
			{
				valueExporter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SearchInterruptibleCreator()
	{
		valueExporter = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(WeaponsWindow));
		Mount = new TreeGridColumn();
		WeaponType = new DataGridViewTextBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		TGV_Weapons = new DarkTreeGridView();
		Column1 = new TreeGridColumn();
		Type = new DataGridViewTextBoxColumn();
		TimeToFire = new DataGridViewTextBoxColumn();
		Column3 = new DataGridViewTextBoxColumn();
		ReloadPriority = new DataGridViewCheckBoxColumn();
		ShowArcs = new DataGridViewCheckBoxColumn();
		RateInterruptibleCreator(new ImageList(valueExporter));
		CollectInterruptibleCreator(new Timer(valueExporter));
		TS_Edit = new DarkToolStrip();
		TSB_AddRec = new ToolStripButton();
		TSB_RemoveRec = new ToolStripButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		TSB_AddMount = new ToolStripButton();
		TSB_RemoveMount = new ToolStripButton();
		ToolStripSeparator2 = new ToolStripSeparator();
		TSL_WeaponCount1 = new ToolStripLabel();
		TSL_WeaponCount2 = new ToolStripLabel();
		TSTB_RecCount = new ToolStripTextBox();
		TSB_ChangeWeaponCount = new ToolStripButton();
		((ISupportInitialize)TGV_Weapons).BeginInit();
		TS_Edit.SuspendLayout();
		SuspendLayout();
		Mount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Mount.DefaultNodeImage = null;
		Mount.HeaderText = "挂架";
		Mount.Name = "Mount";
		Mount.ReadOnly = true;
		Mount.SortMode = DataGridViewColumnSortMode.NotSortable;
		WeaponType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		WeaponType.HeaderText = "类型";
		WeaponType.Name = "WeaponType";
		WeaponType.ReadOnly = true;
		WeaponType.SortMode = DataGridViewColumnSortMode.NotSortable;
		Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Status.HeaderText = "状态";
		Status.Name = "Status";
		Status.ReadOnly = true;
		Status.SortMode = DataGridViewColumnSortMode.NotSortable;
		TGV_Weapons.AllowUserToAddRows = false;
		TGV_Weapons.AllowUserToDeleteRows = false;
		TGV_Weapons.AllowUserToOrderColumns = true;
		TGV_Weapons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_Weapons.BackgroundColor = Color.FromArgb(43, 43, 43);
		TGV_Weapons.BorderStyle = BorderStyle.Fixed3D;
		TGV_Weapons.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Weapons.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_Weapons.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_Weapons.Columns.AddRange(Column1, Type, TimeToFire, Column3, ReloadPriority, ShowArcs);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_Weapons.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_Weapons.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Weapons.EnableHeadersVisualStyles = false;
		TGV_Weapons.ImageList = null;
		TGV_Weapons.Location = new Point(0, 0);
		TGV_Weapons.MultiSelect = false;
		TGV_Weapons.Name = "TGV_Weapons";
		TGV_Weapons.RowHeadersVisible = false;
		TGV_Weapons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Weapons.ShowLines = false;
		TGV_Weapons.Size = new Size(732, 333);
		TGV_Weapons.TabIndex = 4;
		Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Column1.DefaultNodeImage = null;
		Column1.HeaderText = "挂载（点击武器以显示数据库信息）";
		Column1.MinimumWidth = 250;
		Column1.Name = "Column1";
		Column1.ReadOnly = true;
		Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
		Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Type.FillWeight = 10f;
		Type.HeaderText = "";
		Type.MinimumWidth = 75;
		Type.Name = "Type";
		Type.ReadOnly = true;
		Type.SortMode = DataGridViewColumnSortMode.NotSortable;
		TimeToFire.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		TimeToFire.HeaderText = "开火时间";
		TimeToFire.Name = "TimeToFire";
		TimeToFire.ReadOnly = true;
		TimeToFire.SortMode = DataGridViewColumnSortMode.NotSortable;
		TimeToFire.Width = 69;
		Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Column3.FillWeight = 10f;
		Column3.HeaderText = "状态";
		Column3.MinimumWidth = 75;
		Column3.Name = "Column3";
		Column3.ReadOnly = true;
		Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
		ReloadPriority.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ReloadPriority.HeaderText = "重新加载优先权";
		ReloadPriority.Name = "ReloadPriority";
		ReloadPriority.Width = 86;
		ShowArcs.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		ShowArcs.HeaderText = "显示角度";
		ShowArcs.Name = "ShowArcs";
		ShowArcs.Width = 64;
		CalcInterruptibleCreator().ColorDepth = ColorDepth.Depth8Bit;
		CalcInterruptibleCreator().ImageSize = new Size(16, 16);
		CalcInterruptibleCreator().TransparentColor = Color.Transparent;
		ForgotInterruptibleCreator().Interval = 1000;
		TS_Edit.AutoSize = false;
		TS_Edit.BackColor = Color.FromArgb(60, 63, 65);
		TS_Edit.Dock = DockStyle.Bottom;
		TS_Edit.ForeColor = Color.FromArgb(220, 220, 220);
		TS_Edit.GripStyle = ToolStripGripStyle.Hidden;
		TS_Edit.Items.AddRange(new ToolStripItem[10] { TSB_AddRec, TSB_RemoveRec, ToolStripSeparator1, TSB_AddMount, TSB_RemoveMount, ToolStripSeparator2, TSL_WeaponCount1, TSL_WeaponCount2, TSTB_RecCount, TSB_ChangeWeaponCount });
		TS_Edit.Location = new Point(0, 336);
		TS_Edit.Name = "TS_Edit";
		TS_Edit.Padding = new Padding(5, 0, 1, 0);
		TS_Edit.Size = new Size(732, 25);
		TS_Edit.TabIndex = 7;
		TS_Edit.Text = "ToolStrip1";
		TSB_AddRec.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddRec.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddRec.Image = componentResourceManager.GetObject("TSB_AddRec.Image");
		TSB_AddRec.ImageTransparentColor = Color.Magenta;
		TSB_AddRec.Name = "TSB_AddRec";
		TSB_AddRec.Size = new Size(136, 22);
		TSB_AddRec.Text = "添加武器记录";
		TSB_RemoveRec.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveRec.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveRec.Image = componentResourceManager.GetObject("TSB_RemoveRec.Image");
		TSB_RemoveRec.ImageTransparentColor = Color.Magenta;
		TSB_RemoveRec.Name = "TSB_RemoveRec";
		TSB_RemoveRec.Size = new Size(170, 22);
		TSB_RemoveRec.Text = "删除武器记录";
		ToolStripSeparator1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator1.Margin = new Padding(0, 0, 2, 0);
		ToolStripSeparator1.Name = "ToolStripSeparator1";
		ToolStripSeparator1.Size = new Size(6, 25);
		TSB_AddMount.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddMount.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddMount.Image = componentResourceManager.GetObject("TSB_AddMount.Image");
		TSB_AddMount.ImageTransparentColor = Color.Magenta;
		TSB_AddMount.Name = "TSB_AddMount";
		TSB_AddMount.Size = new Size(88, 22);
		TSB_AddMount.Text = "添加武器挂架";
		TSB_RemoveMount.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveMount.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveMount.Image = componentResourceManager.GetObject("TSB_RemoveMount.Image");
		TSB_RemoveMount.ImageTransparentColor = Color.Magenta;
		TSB_RemoveMount.Name = "TSB_RemoveMount";
		TSB_RemoveMount.Size = new Size(109, 22);
		TSB_RemoveMount.Text = "删除武器挂架";
		TSB_RemoveMount.ToolTipText = "Remove Mount";
		ToolStripSeparator2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripSeparator2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripSeparator2.Margin = new Padding(0, 0, 2, 0);
		ToolStripSeparator2.Name = "ToolStripSeparator2";
		ToolStripSeparator2.Size = new Size(6, 25);
		TSL_WeaponCount1.BackColor = Color.FromArgb(60, 63, 65);
		TSL_WeaponCount1.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_WeaponCount1.Name = "TSL_WeaponCount1";
		TSL_WeaponCount1.Size = new Size(59, 22);
		TSL_WeaponCount1.Text = "武器：";
		TSL_WeaponCount2.BackColor = Color.FromArgb(60, 63, 65);
		TSL_WeaponCount2.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_WeaponCount2.Name = "TSL_WeaponCount2";
		TSL_WeaponCount2.Size = new Size(37, 22);
		TSL_WeaponCount2.Text = "12345";
		TSTB_RecCount.BackColor = Color.FromArgb(60, 63, 65);
		TSTB_RecCount.ForeColor = Color.FromArgb(220, 220, 220);
		TSTB_RecCount.Name = "TSTB_RecCount";
		TSTB_RecCount.Size = new Size(40, 25);
		TSTB_RecCount.Visible = false;
		TSB_ChangeWeaponCount.BackColor = Color.FromArgb(60, 63, 65);
		TSB_ChangeWeaponCount.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSB_ChangeWeaponCount.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_ChangeWeaponCount.Image = componentResourceManager.GetObject("TSB_ChangeWeaponCount.Image");
		TSB_ChangeWeaponCount.ImageTransparentColor = Color.Magenta;
		TSB_ChangeWeaponCount.Name = "TSB_ChangeWeaponCount";
		TSB_ChangeWeaponCount.Size = new Size(52, 22);
		TSB_ChangeWeaponCount.Text = "更改";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(732, 361);
		base.Controls.Add(TS_Edit);
		base.Controls.Add(TGV_Weapons);
		Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(200, 200);
		base.Name = "WeaponsWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "武器";
		((ISupportInitialize)TGV_Weapons).EndInit();
		TS_Edit.ResumeLayout(performLayout: false);
		TS_Edit.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] array = serverExporter;
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
		return false;
	}

	public void AddWeaponRec(WeaponRec weaponRec_0)
	{
		if (theSelectedUnit == null)
		{
			return;
		}
		if (m_ConfigurationExporter == null)
		{
			m_StrategyExporter.MountWeapons.Add(weaponRec_0);
		}
		else
		{
			m_ConfigurationExporter.AddWeaponRec(weaponRec_0);
		}
		List<CommDevice> list = new List<CommDevice>();
		bool flag = true;
		CommDevice[] comms_ReadOnly = weaponRec_0.GetReferenceWeapon(Client.CurrentScenario).Comms_ReadOnly;
		CommDevice[] array = comms_ReadOnly;
		foreach (CommDevice commDevice in array)
		{
			if (commDevice.IsOptional)
			{
				continue;
			}
			flag = false;
			list.Add(commDevice);
			CommDevice[] comms_ReadOnly2 = theSelectedUnit.Comms_ReadOnly;
			for (int i = 0; i < comms_ReadOnly2.Length; i = checked(i + 1))
			{
				if (comms_ReadOnly2[i].DBID == commDevice.DBID)
				{
					flag = true;
				}
			}
		}
		if (!flag && list.Count > 0 && DarkMessageBox.ShowWarning("The weapon record you have added misses a datalink, do you want to add one ?", "Datalink Needed", DarkDialogButton.YesNo) == DialogResult.Yes)
		{
			Client.theCommsWindow = new UnitComms();
			Client.theCommsWindow.Show();
			ItemExporter.ConnectInterruptibleTemplate.AddComms.FormThatCalledMe = Client.theCommsWindow;
			ItemExporter.ConnectInterruptibleTemplate.AddComms.Show();
			Client.MustRefreshMainForm = true;
			AddComms addComms = ItemExporter.ConnectInterruptibleTemplate.AddComms;
			int dBID = list[0].DBID;
			ActiveUnit activeUnit_ = theSelectedUnit;
			CommDevice commDevice2 = DBFunctions.GetCommDevice(dBID, ref activeUnit_);
			theSelectedUnit = activeUnit_;
			addComms.InjectFilterByKeyword(commDevice2.Name);
		}
	}

	public void RemoveWeaponRec(WeaponRec weaponRec_0)
	{
		if (Information.IsNothing(m_StrategyExporter))
		{
			if (!Information.IsNothing(m_ConfigurationExporter))
			{
				m_ConfigurationExporter.RemoveWeaponRec(weaponRec_0);
			}
		}
		else
		{
			m_StrategyExporter.MountWeapons.Remove(weaponRec_0);
		}
	}

	private void EnableInterruptibleCreator(object sender, FormClosingEventArgs e)
	{
		Client._ManagerClass = null;
		_StatusExporter = null;
		e.Cancel = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		Hide();
	}

	private void ChangeInterruptibleCreator(object sender, EventArgs e)
	{
		if (!base.Visible)
		{
			return;
		}
		if (Information.IsNothing(_StatusExporter) && Client.SelectedUnit.IsActiveUnit)
		{
			_StatusExporter = (ActiveUnit)Client.SelectedUnit;
		}
		if (!Information.IsNothing(_StatusExporter) && _StatusExporter.IsActiveUnit)
		{
			BuildForm();
			if ((TGV_Weapons.Nodes.Count > 0 && !Information.IsNothing(_StatusExporter)) & (_StatusExporter.Mounts.Count > 0))
			{
				m_StrategyExporter = (Mount)TGV_Weapons.Nodes[0].Tag;
			}
		}
		else
		{
			Hide();
		}
	}

	private void InitInterruptibleCreator(object sender, EventArgs e)
	{
		tokenExporter = false;
		PlatformComponent.StatusChanged += FillInterruptibleCreator;
		WeaponRec.CurrentLoadChanged += CalculateInterruptibleCreator;
		Command_Core.Mount.MountWeaponRecordAdded += ConcatInterruptibleCreator;
		Command_Core.Mount.MountWeaponRecordRemoved += InterruptInterruptibleCreator;
		Loadout.LoadoutWeaponRecordAdded += RemoveInterruptibleCreator;
		Loadout.LoadoutWeaponRecordRemoved += FindInterruptibleCreator;
		ActiveUnit.ActiveUnitMountsAdded += InstantiateInterruptibleCreator;
		ActiveUnit.ActiveUnitMountsRemoved += PopInterruptibleCreator;
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		publisherExporter = true;
		ForgotInterruptibleCreator().Start();
	}

	private void CheckInterruptibleCreator(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if ((e.ColumnIndex == 4 || e.ColumnIndex == 5) && (e.State & DataGridViewElementStates.ReadOnly) != 0)
		{
			e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.SelectionBackground);
			e.Handled = true;
		}
	}

	private void ConcatInterruptibleCreator(string string_0, string string_1)
	{
		WeaponsWindow Me = null;
		Me = this;
		TreeGridNode Local_theNode = null;
		Mount Local_theMount;
		WeaponRec Local_theRec;
		foreach (TreeGridNode node in TGV_Weapons.Nodes)
		{
			Local_theNode = node;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Mount))
			{
				continue;
			}
			Local_theMount = (Mount)Local_theNode.Tag;
			if (Operators.CompareString(Local_theMount.ObjectID, string_0, TextCompare: true) != 0)
			{
				continue;
			}
			using List<WeaponRec>.Enumerator enumerator2 = Local_theMount.MountWeapons.GetEnumerator();
			Local_theRec = null;
			while (enumerator2.MoveNext())
			{
				Local_theRec = enumerator2.Current;
				if (Operators.CompareString(Local_theRec.ObjectID, string_1, TextCompare: true) != 0)
				{
					continue;
				}
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					Me.CompareInterruptibleCreator(Local_theNode, Local_theMount, Local_theRec);
					if (!Local_theNode.IsExpanded)
					{
						Local_theNode.Expand();
					}
				});
				break;
			}
			break;
		}
	}

	private void InterruptInterruptibleCreator(string string_0, string string_1)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		TreeGridNode Local_theNode = null;
		TreeGridNode Local_theRecNode;
		while (enumerator.MoveNext())
		{
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Mount) || Operators.CompareString(((Mount)Local_theNode.Tag).ObjectID, string_0, TextCompare: true) != 0)
			{
				continue;
			}
			using IEnumerator<TreeGridNode> enumerator2 = Local_theNode.Nodes.GetEnumerator();
			Local_theRecNode = null;
			while (enumerator2.MoveNext())
			{
				Local_theRecNode = enumerator2.Current;
				if (Local_theRecNode.Tag != null && (object)Local_theRecNode.Tag.GetType() == typeof(WeaponRec) && Operators.CompareString(((WeaponRec)Local_theRecNode.Tag).ObjectID, string_1, TextCompare: true) == 0)
				{
					Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						Local_theNode.Nodes.Remove(Local_theRecNode);
					});
					break;
				}
			}
			break;
		}
	}

	private void RemoveInterruptibleCreator(string string_0, string string_1)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		WeaponRec Local_theRec = null;
		WeaponsWindow Me = null;
		TreeGridNode Local_theNode = null;
		while (enumerator.MoveNext())
		{
			Me = this;
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Loadout))
			{
				continue;
			}
			Loadout loadout = (Loadout)Local_theNode.Tag;
			if (Operators.CompareString(loadout.ObjectID, string_0, TextCompare: true) != 0)
			{
				continue;
			}
			WeaponRec[] weapons = loadout.Weapons;
			for (int i = 0; i < weapons.Length; i = checked(i + 1))
			{
				Local_theRec = weapons[i];
				if (Operators.CompareString(Local_theRec.ObjectID, string_1, TextCompare: true) != 0)
				{
					continue;
				}
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					Me.ReadInterruptibleCreator(Local_theNode, Local_theRec);
					if (!Local_theNode.IsExpanded)
					{
						Local_theNode.Expand();
					}
				});
				break;
			}
			break;
		}
	}

	private void FindInterruptibleCreator(string string_0, string string_1)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		TreeGridNode Local_theNode = null;
		TreeGridNode Local_theRecNode;
		while (enumerator.MoveNext())
		{
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Loadout) || Operators.CompareString(((Loadout)Local_theNode.Tag).ObjectID, string_0, TextCompare: true) != 0)
			{
				continue;
			}
			using IEnumerator<TreeGridNode> enumerator2 = Local_theNode.Nodes.GetEnumerator();
			Local_theRecNode = null;
			while (enumerator2.MoveNext())
			{
				Local_theRecNode = enumerator2.Current;
				if (Local_theRecNode.Tag != null && (object)Local_theRecNode.Tag.GetType() == typeof(WeaponRec) && Operators.CompareString(((WeaponRec)Local_theRecNode.Tag).ObjectID, string_1, TextCompare: true) == 0)
				{
					Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						Local_theNode.Nodes.Remove(Local_theRecNode);
					});
					break;
				}
			}
			break;
		}
	}

	private void SetInterruptibleCreator(string string_0, string string_1)
	{
		if (base.Visible && theSelectedUnit != null && Operators.CompareString(theSelectedUnit.ObjectID, string_0, TextCompare: true) == 0)
		{
			BuildForm();
		}
	}

	private void FillInterruptibleCreator(PlatformComponent platformComponent_0)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		Mount Local_theMount = null;
		WeaponsWindow Me = null;
		TreeGridNode Local_theNode = null;
		while (enumerator.MoveNext())
		{
			Me = this;
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Mount))
			{
				continue;
			}
			Local_theMount = (Mount)Local_theNode.Tag;
			if (Operators.CompareString(Local_theMount.ObjectID, platformComponent_0.ObjectID, TextCompare: true) != 0)
			{
				continue;
			}
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				Me.CreateInterruptibleCreator(Local_theNode, Local_theMount);
			});
			break;
		}
	}

	private void CalculateInterruptibleCreator(string string_0)
	{
		foreach (TreeGridNode Local_theNode in TGV_Weapons.Nodes)
		{
			if (Local_theNode.Tag == null || ((object)Local_theNode.Tag.GetType() != typeof(Mount) && (object)Local_theNode.Tag.GetType() != typeof(Loadout)))
			{
				continue;
			}
			foreach (TreeGridNode Local_theRecNode in Local_theNode.Nodes)
			{
				if (Local_theRecNode.Tag == null || (object)Local_theRecNode.Tag.GetType() != typeof(WeaponRec))
				{
					continue;
				}
				WeaponRec Local_theRec = (WeaponRec)Local_theRecNode.Tag;
				if (Operators.CompareString(Local_theRec.ObjectID, string_0, TextCompare: true) != 0)
				{
					continue;
				}
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					if ((object)Local_theNode.Tag.GetType() == typeof(Mount))
					{
						DisableInterruptibleCreator(Local_theRecNode, Local_theRec, (Mount)Local_theNode.Tag);
					}
					if ((object)Local_theNode.Tag.GetType() == typeof(Loadout))
					{
						UpdateInterruptibleCreator(Local_theRecNode, Local_theRec);
					}
				});
				return;
			}
		}
	}

	private void PopInterruptibleCreator(string string_0, string string_1)
	{
		if (!base.Visible || Operators.CompareString(_StatusExporter.ObjectID, string_0, TextCompare: true) != 0)
		{
			return;
		}
		using IEnumerator<TreeGridNode> enumerator = TGV_Weapons.Nodes.GetEnumerator();
		TreeGridNode Local_theNode = null;
		WeaponsWindow Me = null;
		while (enumerator.MoveNext())
		{
			Me = this;
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag != null && (object)Local_theNode.Tag.GetType() == typeof(Mount) && Operators.CompareString(((Mount)Local_theNode.Tag).ObjectID, string_1, TextCompare: true) == 0)
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					Me.TGV_Weapons.Nodes.Remove(Local_theNode);
				});
				break;
			}
		}
	}

	private void InstantiateInterruptibleCreator(string string_0, string string_1)
	{
		if (!base.Visible || Operators.CompareString(_StatusExporter.ObjectID, string_0, TextCompare: true) != 0)
		{
			return;
		}
		using List<Mount>.Enumerator enumerator = _StatusExporter.Mounts.GetEnumerator();
		Mount Local_theMount = null;
		WeaponsWindow Me = null;
		while (enumerator.MoveNext())
		{
			Me = this;
			Local_theMount = enumerator.Current;
			if (Operators.CompareString(Local_theMount.ObjectID, string_1, TextCompare: true) != 0)
			{
				continue;
			}
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				TreeGridNode treeGridNode = Me.TGV_Weapons.Nodes.Add("新节点");
				Me.CreateInterruptibleCreator(treeGridNode, Local_theMount);
				foreach (WeaponRec current in Local_theMount.MountWeapons)
				{
					Me.CompareInterruptibleCreator(treeGridNode, Local_theMount, current);
				}
				treeGridNode.Expand();
			});
			break;
		}
	}

	public void RemoveOrphanedRecords(TreeGridNode treeGridNode_0, IEnumerable<WeaponRec> ienumerable_0)
	{
		List<TreeGridNode> list = new List<TreeGridNode>();
		foreach (TreeGridNode node in treeGridNode_0.Nodes)
		{
			if (!ienumerable_0.Contains((WeaponRec)node.Tag))
			{
				list.Add(node);
			}
		}
		foreach (TreeGridNode item in list)
		{
			treeGridNode_0.Nodes.Remove(item);
		}
	}

	private void CreateInterruptibleCreator(TreeGridNode treeGridNode_0, Mount mount_0)
	{
		int num = 0;
		foreach (WeaponRec mountWeapon in mount_0.MountWeapons)
		{
			num += mountWeapon.MaxLoad;
		}
		string text = Conversions.ToString(0);
		if (mount_0.ReloadStatus == Command_Core.Mount._ReloadStatus.Ready)
		{
			text = Misc.UpdateRequest((long)Math.Round(mount_0.TimeToFire));
		}
		else
		{
			float num2 = 0f;
			if (mount_0.TimeToFire > 0f)
			{
				num2 = mount_0.TimeToFire;
			}
			if (mount_0.MountMagazine.TimeToFire > 0f && mount_0.MountMagazine.TimeToFire > num2)
			{
				num2 = mount_0.MountMagazine.TimeToFire;
			}
			foreach (WeaponRec mountWeapon2 in mount_0.MountWeapons)
			{
				if (mountWeapon2.TimeToFire > num2)
				{
					num2 = mountWeapon2.TimeToFire;
				}
			}
			foreach (WeaponRec weapon in mount_0.MountMagazine.Weapons)
			{
				if (weapon.TimeToFire > num2)
				{
					num2 = weapon.TimeToFire;
				}
			}
			if (num2 == 0f)
			{
				text = Misc.UpdateRequest((long)Math.Round(mount_0.TimeToFire));
			}
			else if (mount_0.ReloadStatus == Command_Core.Mount._ReloadStatus.Reloading)
			{
				text = "重加载：" + Misc.UpdateRequest((long)Math.Round(num2));
			}
			else if (mount_0.ReloadStatus == Command_Core.Mount._ReloadStatus.Unloading)
			{
				text = "卸载：" + Misc.UpdateRequest((long)Math.Round(num2));
			}
		}
		object[] array = new object[4]
		{
			Misc.ReadRequest(mount_0.Name),
			null,
			null,
			null
		};
		string[] array2 = new string[5] { "(", null, null, null, null };
		int int_ = 0;
		int int_2 = 0;
		array2[1] = Conversions.ToString(mount_0.RegisterTokenizer(ref int_, ref int_2));
		array2[2] = "/";
		array2[3] = Conversions.ToString(mount_0.MaxCapacity);
		array2[4] = ")";
		array[1] = string.Concat(array2);
		array[2] = text;
		array[3] = mount_0.Status.ToString();
		treeGridNode_0.SetValues(array);
		treeGridNode_0.Cells["ReloadPriority"].ReadOnly = true;
		treeGridNode_0.DefaultCellStyle.ForeColor = Color.Black;
		treeGridNode_0.DefaultCellStyle.Font = new Font(Font, FontStyle.Regular);
		treeGridNode_0.DefaultCellStyle.ForeColor = GetComponentDamageColor(mount_0);
		treeGridNode_0.Tag = mount_0;
	}

	private void CompareInterruptibleCreator(TreeGridNode treeGridNode_0, Mount mount_0, WeaponRec weaponRec_0)
	{
		TreeGridNode treeGridNode_ = treeGridNode_0.Nodes.Add("新节点");
		DisableInterruptibleCreator(treeGridNode_, weaponRec_0, mount_0);
	}

	private void ReadInterruptibleCreator(TreeGridNode treeGridNode_0, WeaponRec weaponRec_0)
	{
		TreeGridNode treeGridNode_ = treeGridNode_0.Nodes.Add("新节点");
		UpdateInterruptibleCreator(treeGridNode_, weaponRec_0);
	}

	private void DisableInterruptibleCreator(TreeGridNode treeGridNode_0, WeaponRec weaponRec_0, Mount mount_0)
	{
		if (_StatusExporter == null)
		{
			return;
		}
		int num = _StatusExporter.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount_0, weaponRec_0.int_0);
		int num2 = _StatusExporter.Weaponry.HowManyOfThisWeaponOnMagazines(weaponRec_0.int_0);
		string text = "";
		string text2 = "";
		if (num <= 0)
		{
			if (num2 == 0 && mount_0.ParentPlatform != null && !mount_0.ParentPlatform.IsAircraft)
			{
				text2 = " (No reloads available)";
			}
		}
		else
		{
			text = " (" + Conversions.ToString(num) + "在挂架弹药库）";
		}
		string text3 = (tokenExporter ? ("（TTF：" + Misc.UpdateRequest((long)Math.Round(weaponRec_0.TimeToFire)) + ") ") : string.Empty);
		string text4 = string.Empty;
		if (weaponRec_0.Multiple > 1)
		{
			text4 = " (" + Conversions.ToString(weaponRec_0.Multiple) + "x/cell)";
		}
		treeGridNode_0.SetValues(Conversions.ToString(weaponRec_0.CurrentLoad) + "/" + Conversions.ToString(weaponRec_0.MaxLoad) + text4 + text3 + " " + Misc.ReadRequest(Strings.Trim(weaponRec_0.GetReferenceWeapon(Client.CurrentScenario).Name)) + text + text2, Misc.ForgotRequest(weaponRec_0.GetReferenceWeapon(Client.CurrentScenario).Type), null, null, mount_0.ReloadPriority.Contains(weaponRec_0.int_0));
		treeGridNode_0.Tag = weaponRec_0;
		if (weaponRec_0.CurrentLoad == 0)
		{
			treeGridNode_0.DefaultCellStyle.ForeColor = Color.DarkGray;
			treeGridNode_0.DefaultCellStyle.Font = new Font(TGV_Weapons.DefaultCellStyle.Font, FontStyle.Italic);
		}
		else
		{
			treeGridNode_0.DefaultCellStyle.ForeColor = Color.LightBlue;
			treeGridNode_0.DefaultCellStyle.Font = new Font(TGV_Weapons.DefaultCellStyle.Font, FontStyle.Regular);
			Weapon referenceWeapon = weaponRec_0.GetReferenceWeapon(Client.CurrentScenario);
			referenceWeapon.SetLatitude(null, _StatusExporter.GetLatitude());
			referenceWeapon.SetLongitude(null, _StatusExporter.GetLongitude());
			referenceWeapon.SetCurrentAltitude(bool_0: false, _StatusExporter.GetCurrentAltitude());
			CommDevice[] comms_ReadOnly = referenceWeapon.Comms_ReadOnly;
			if (comms_ReadOnly.Length != 0 && !comms_ReadOnly[0].IsOptional && referenceWeapon.CommStuff.CommDevicePresentToConnectToThisUnit(comms_ReadOnly, _StatusExporter) == null)
			{
				treeGridNode_0.DefaultCellStyle.ForeColor = Color.Pink;
				treeGridNode_0.Cells[3].Value = "No datalink";
			}
		}
		treeGridNode_0.Cells[5].ReadOnly = true;
	}

	private void UpdateInterruptibleCreator(TreeGridNode treeGridNode_0, WeaponRec weaponRec_0)
	{
		string text = (tokenExporter ? ("（TTF：" + Misc.UpdateRequest((long)Math.Round(weaponRec_0.TimeToFire)) + ") ") : "");
		treeGridNode_0.SetValues(Conversions.ToString(weaponRec_0.CurrentLoad) + "/" + Conversions.ToString(weaponRec_0.MaxLoad) + text + "  " + Misc.ReadRequest(Strings.Trim(weaponRec_0.GetReferenceWeapon(Client.CurrentScenario).Name)), Misc.ForgotRequest(weaponRec_0.GetReferenceWeapon(Client.CurrentScenario).Type));
		treeGridNode_0.Tag = weaponRec_0;
		if (weaponRec_0.CurrentLoad == 0)
		{
			treeGridNode_0.DefaultCellStyle.ForeColor = Color.DarkGray;
			treeGridNode_0.DefaultCellStyle.Font = new Font(TGV_Weapons.DefaultCellStyle.Font, FontStyle.Italic);
		}
		else
		{
			treeGridNode_0.DefaultCellStyle.ForeColor = Color.LightBlue;
			treeGridNode_0.DefaultCellStyle.Font = new Font(TGV_Weapons.DefaultCellStyle.Font, FontStyle.Regular);
		}
		treeGridNode_0.Cells[4].ReadOnly = true;
		treeGridNode_0.Cells[5].ReadOnly = true;
	}

	public void BuildForm()
	{
		if (Information.IsNothing(_StatusExporter))
		{
			if (!Client.SelectedUnit.IsActiveUnit)
			{
				return;
			}
			_StatusExporter = (ActiveUnit)Client.SelectedUnit;
		}
		TGV_Weapons.Nodes.Clear();
		TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		Text = "武器" + _StatusExporter.Name;
		TSB_AddRec.Visible = _StatusExporter.Mounts.Count > 0 || (_StatusExporter.IsAircraft && ((Aircraft)_StatusExporter).Loadout != null);
		TSB_RemoveRec.Visible = TSB_AddRec.Visible;
		TGV_Weapons.Nodes.Clear();
		foreach (Mount item in _StatusExporter.Mounts.OrderBy((Mount theM) => theM.Name).ToList())
		{
			TreeGridNode treeGridNode = TGV_Weapons.Nodes.Add("新节点");
			CreateInterruptibleCreator(treeGridNode, item);
			if (item.MountWeapons.Count > 0)
			{
				treeGridNode.Nodes.Add("Temp");
			}
		}
		if (_StatusExporter.IsAircraft && !Information.IsNothing(((Aircraft)_StatusExporter).Loadout))
		{
			Loadout loadout = ((Aircraft)_StatusExporter).Loadout;
			TreeGridNode treeGridNode2 = TGV_Weapons.Nodes.Add("新节点");
			InsertInterruptibleCreator(treeGridNode2, loadout);
			WeaponRec[] weapons = loadout.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec_ in array)
			{
				ReadInterruptibleCreator(treeGridNode2, weaponRec_);
			}
			treeGridNode2.Expand();
		}
	}

	private void InsertInterruptibleCreator(TreeGridNode treeGridNode_0, Loadout loadout_0)
	{
		int num = 0;
		WeaponRec[] weapons = loadout_0.Weapons;
		WeaponRec[] array = weapons;
		foreach (WeaponRec weaponRec in array)
		{
			num += weaponRec.MaxLoad;
		}
		treeGridNode_0.SetValues("挂载：" + Misc.ReadRequest(loadout_0.Name), "(" + Conversions.ToString(loadout_0.CurrentCapacity) + "/" + Conversions.ToString(num) + ")");
		treeGridNode_0.Tag = loadout_0;
		treeGridNode_0.DefaultCellStyle.ForeColor = Color.LightGray;
		treeGridNode_0.DefaultCellStyle.Font = new Font(Font, FontStyle.Regular);
		treeGridNode_0.Cells[4].ReadOnly = true;
		treeGridNode_0.Cells[5].ReadOnly = true;
	}

	private void PrepareInterruptibleCreator(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.AddWeaponRecord.FormThatCalledMe = this;
		ItemExporter.ConnectInterruptibleTemplate.AddWeaponRecord.Show();
	}

	private void ReflectInterruptibleCreator(object sender, EventArgs e)
	{
		switch (TGV_Weapons.SelectedRows.Count)
		{
		case 1:
			RemoveWeaponRec(m_ProccesorExporter);
			return;
		case 0:
			return;
		}
		List<DataGridViewRow> list = new List<DataGridViewRow>();
		IEnumerator enumerator = null;
		try
		{
			enumerator = TGV_Weapons.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
				if ((object)dataGridViewRow.Tag.GetType() == typeof(WeaponRec))
				{
					list.Add(dataGridViewRow);
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		if (DarkMessageBox.ShowWarning("你确定吗？", "删除" + Conversions.ToString(list.Count) + "武器记录", DarkDialogButton.OkCancel) != DialogResult.OK)
		{
			return;
		}
		foreach (DataGridViewRow item in list)
		{
			RemoveWeaponRec((WeaponRec)item.Tag);
		}
	}

	private void VisitInterruptibleCreator(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || e.ColumnIndex == -1)
		{
			return;
		}
		DataGridViewColumn dataGridViewColumn = TGV_Weapons.Columns[e.ColumnIndex];
		if (Information.IsNothing(TGV_Weapons.CurrentNode))
		{
			return;
		}
		if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(WeaponRec) && Operators.CompareString(dataGridViewColumn.Name, "ReloadPriority", TextCompare: true) == 0 && !Information.IsNothing(m_StrategyExporter))
		{
			DataGridViewCheckBoxCell dataGridViewCheckBoxCell = (DataGridViewCheckBoxCell)TGV_Weapons[e.ColumnIndex, e.RowIndex];
			WeaponRec weaponRec = (WeaponRec)TGV_Weapons.CurrentNode.Tag;
			Mount mount = (Mount)TGV_Weapons.CurrentNode.Parent.Tag;
			if (mount.ReloadPriority.Contains(weaponRec.int_0))
			{
				mount.ReloadPriority.Remove(weaponRec.int_0);
				dataGridViewCheckBoxCell.Value = false;
			}
			else
			{
				mount.ReloadPriority.Add(weaponRec.int_0);
				dataGridViewCheckBoxCell.Value = true;
				if (mount.ParentPlatform != null && mount.ParentPlatform.Weaponry.HowManyOfThisWeaponOnMountMagazine(mount, weaponRec.int_0) == 0 && mount.ParentPlatform.Weaponry.HowManyOfThisWeaponOnMagazines(weaponRec.int_0) == 0)
				{
					DarkMessageBox.ShowWarning("You have set reload priority for a weapon with no reloads available. This will have no effect unless new reloads become available.", "No reloads available.");
				}
			}
		}
		if ((object)TGV_Weapons.CurrentNode.Tag.GetType() != typeof(Mount) || Operators.CompareString(dataGridViewColumn.Name, "ShowArcs", TextCompare: true) != 0 || Information.IsNothing(m_StrategyExporter))
		{
			return;
		}
		Mount mount2 = null;
		WeaponRec weaponRec2 = null;
		foreach (TreeGridNode item in InterpreterObjectListener.FlushInterruptibleTask(TGV_Weapons))
		{
			DataGridViewCheckBoxCell obj = (DataGridViewCheckBoxCell)item.Cells[e.ColumnIndex];
			if (Operators.ConditionalCompareObjectEqual(obj.Value, true, TextCompare: true))
			{
				if ((object)item.Tag.GetType() == typeof(Mount))
				{
					mount2 = (Mount)item.Tag;
				}
				else if ((object)item.Tag.GetType() == typeof(WeaponRec))
				{
					weaponRec2 = (WeaponRec)item.Tag;
				}
			}
			obj.Value = false;
		}
		WeaponRec weaponRec3 = null;
		Mount mount3;
		if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(Mount))
		{
			mount3 = (Mount)TGV_Weapons.CurrentNode.Tag;
		}
		else if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(WeaponRec))
		{
			mount3 = (Mount)TGV_Weapons.CurrentNode.Parent.Tag;
			weaponRec3 = (WeaponRec)TGV_Weapons.CurrentNode.Tag;
		}
		else
		{
			mount3 = null;
		}
		if (!Information.IsNothing(mount3))
		{
			DataGridViewCheckBoxCell dataGridViewCheckBoxCell2 = (DataGridViewCheckBoxCell)TGV_Weapons[e.ColumnIndex, e.RowIndex];
			if (!Information.IsNothing(mount3) && !Information.IsNothing(mount2) && mount2 == mount3)
			{
				Client._ManagerClass = null;
			}
			else if (!Information.IsNothing(weaponRec3) && !Information.IsNothing(weaponRec2) && weaponRec2 == weaponRec3)
			{
				Client._ManagerClass = null;
			}
			else
			{
				dataGridViewCheckBoxCell2.Value = true;
				Client._ManagerClass = mount3;
			}
			Client.MustRefreshMainForm = true;
		}
	}

	private void RestartInterruptibleCreator(object sender, ExpandingEventArgs e)
	{
		e.Node.Nodes.Clear();
		if (e.Node.Tag != null && (object)e.Node.Tag.GetType() == typeof(Mount))
		{
			Mount Local_theMount = (Mount)e.Node.Tag;
			Task.Factory.StartNew(delegate
			{
				foreach (WeaponRec Local_theWeaponRec in Local_theMount.MountWeapons)
				{
					Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						CompareInterruptibleCreator(e.Node, Local_theMount, Local_theWeaponRec);
					});
				}
			});
			m_StrategyExporter = (Mount)e.Node.Tag;
			TSB_RemoveRec.Visible = false;
		}
		if ((object)e.Node.Tag.GetType() == typeof(Loadout))
		{
			WeaponRec[] weapons = ((Loadout)e.Node.Tag).Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec_ in array)
			{
				ReadInterruptibleCreator(e.Node, weaponRec_);
			}
			TSB_AddRec.Visible = false;
			TSB_RemoveRec.Visible = false;
		}
	}

	private void TestInterruptibleCreator(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.AddMount.FormThatCalledMe = this;
		ItemExporter.ConnectInterruptibleTemplate.AddMount.targetUnit = _StatusExporter;
		ItemExporter.ConnectInterruptibleTemplate.AddMount.Show();
	}

	private void StopInterruptibleCreator(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex != 0)
		{
			return;
		}
		try
		{
			TreeGridNode treeGridNode = null;
			foreach (TreeGridNode item in InterpreterObjectListener.FlushInterruptibleTask(TGV_Weapons))
			{
				if (item.Selected)
				{
					treeGridNode = item;
					break;
				}
			}
			if (!Information.IsNothing(treeGridNode) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(treeGridNode.Tag)) && (object)treeGridNode.Tag.GetType() == typeof(WeaponRec))
			{
				int int_ = ((WeaponRec)treeGridNode.Tag).int_0;
				Client.smethod_0("Weapon", int_);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200104", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CancelInterruptibleCreator(object sender, EventArgs e)
	{
		try
		{
			m_StrategyExporter = null;
			if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(Loadout))
			{
				return;
			}
			if (!Information.IsNothing(TGV_Weapons.CurrentNode))
			{
				if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(Mount))
				{
					m_StrategyExporter = (Mount)TGV_Weapons.CurrentNode.Tag;
				}
				else if (TGV_Weapons.CurrentNode.Parent != null && TGV_Weapons.CurrentNode.Parent.Index > 0 && (object)TGV_Weapons.CurrentNode.Parent.Tag.GetType() == typeof(Mount))
				{
					m_StrategyExporter = (Mount)TGV_Weapons.CurrentNode.Parent.Tag;
				}
			}
			if (Information.IsNothing(m_StrategyExporter))
			{
				DarkMessageBox.ShowWarning("没有选择安装！", string.Empty);
				return;
			}
			TGV_Weapons.CurrentNode.Parent.Nodes.Remove(TGV_Weapons.CurrentNode);
			if (!Information.IsNothing(_StatusExporter))
			{
				_StatusExporter.Mounts.Remove(m_StrategyExporter);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void VerifyInterruptibleCreator(object sender, EventArgs e)
	{
		bool flag;
		if (flag = indexerExporter)
		{
			if (!flag)
			{
				return;
			}
			indexerExporter = false;
			TSB_ChangeWeaponCount.Text = "更改";
			TSTB_RecCount.Visible = false;
			TSL_WeaponCount2.Visible = true;
			if (Information.IsNothing(m_ProccesorExporter))
			{
				return;
			}
			if ((Operators.CompareString(TSTB_RecCount.Text, "", TextCompare: true) != 0) & Versioned.IsNumeric(TSTB_RecCount.Text))
			{
				int num = Conversions.ToInteger(TSTB_RecCount.Text);
				if (num < 0)
				{
					num = 0;
				}
				if ((double)num / (double)m_ProccesorExporter.Multiple > (double)m_ProccesorExporter.MaxLoad)
				{
					num = m_ProccesorExporter.MaxLoad;
				}
				if (!Information.IsNothing(m_StrategyExporter))
				{
					m_ProccesorExporter.CurrentLoad = 0;
					Mount strategyExporter = m_StrategyExporter;
					int int_ = 0;
					int int_2 = 0;
					int num2 = strategyExporter.RegisterTokenizer(ref int_, ref int_2);
					if ((double)num / (double)m_ProccesorExporter.Multiple > (double)(m_StrategyExporter.MaxCapacity - num2))
					{
						num = m_StrategyExporter.MaxCapacity - num2 * m_ProccesorExporter.Multiple;
					}
				}
				if (num < 0)
				{
					num = 0;
				}
				m_ProccesorExporter.CurrentLoad = num;
				TSL_WeaponCount2.Text = Conversions.ToString(num);
				foreach (TreeGridNode node in TGV_Weapons.Nodes)
				{
					foreach (TreeGridNode node2 in node.Nodes)
					{
						if (node2.Tag == m_ProccesorExporter)
						{
							node2.SetValues(Conversions.ToString(m_ProccesorExporter.CurrentLoad) + "/" + Conversions.ToString(m_ProccesorExporter.MaxLoad) + "  " + Misc.ReadRequest(Strings.Trim(m_ProccesorExporter.GetReferenceWeapon(Client.CurrentScenario).Name)));
						}
					}
				}
				if (!Information.IsNothing(_StatusExporter) && _StatusExporter.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)_StatusExporter;
					if (!Information.IsNothing(aircraft.Loadout))
					{
						aircraft.Weaponry.AdjustLoadoutPayloadWeight();
					}
				}
			}
			_StatusExporter.Weaponry.ClearCachedWeapons();
			Client.MustRefreshMainForm = true;
			ItemExporter.ConnectInterruptibleTemplate.MainForm.MapRender_Tactical();
		}
		else
		{
			indexerExporter = true;
			TSB_ChangeWeaponCount.Text = "设置";
			TSTB_RecCount.Visible = true;
			TSL_WeaponCount2.Visible = false;
		}
	}

	private void ListInterruptibleCreator(object sender, EventArgs e)
	{
		if (Information.IsNothing(TGV_Weapons.CurrentNode))
		{
			return;
		}
		TSB_AddMount.Visible = true;
		TSL_WeaponCount1.Visible = false;
		indexerExporter = false;
		TSL_WeaponCount1.Visible = true;
		TSL_WeaponCount2.Visible = true;
		TSTB_RecCount.Visible = false;
		TSB_ChangeWeaponCount.Text = "更改";
		if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(WeaponRec))
		{
			m_ProccesorExporter = (WeaponRec)TGV_Weapons.CurrentNode.Tag;
			if ((object)TGV_Weapons.CurrentNode.Parent.Tag.GetType() == typeof(Mount))
			{
				m_StrategyExporter = (Mount)TGV_Weapons.CurrentNode.Parent.Tag;
				m_ConfigurationExporter = null;
				TSB_AddRec.Visible = true;
				TSB_RemoveRec.Visible = true;
				TSB_RemoveMount.Visible = true;
			}
			else if ((object)TGV_Weapons.CurrentNode.Parent.Tag.GetType() == typeof(Loadout))
			{
				m_StrategyExporter = null;
				m_ConfigurationExporter = (Loadout)TGV_Weapons.CurrentNode.Parent.Tag;
				TSB_AddRec.Visible = false;
				TSB_RemoveRec.Visible = false;
				TSB_RemoveMount.Visible = false;
			}
			TSTB_RecCount.Text = Conversions.ToString(m_ProccesorExporter.CurrentLoad);
			TSL_WeaponCount2.Text = Conversions.ToString(m_ProccesorExporter.CurrentLoad);
			TSL_WeaponCount1.Visible = true;
			TSL_WeaponCount2.Visible = true;
			TSB_ChangeWeaponCount.Visible = true;
		}
		if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(Mount))
		{
			m_StrategyExporter = (Mount)TGV_Weapons.CurrentNode.Tag;
			m_ConfigurationExporter = null;
			TSB_AddRec.Visible = true;
			TSB_RemoveRec.Visible = false;
			TSB_RemoveMount.Visible = true;
			TSL_WeaponCount2.Visible = false;
			TSL_WeaponCount1.Visible = false;
			TSB_ChangeWeaponCount.Visible = false;
		}
		if ((object)TGV_Weapons.CurrentNode.Tag.GetType() == typeof(Loadout))
		{
			m_ConfigurationExporter = (Loadout)TGV_Weapons.CurrentNode.Tag;
			TSB_AddRec.Visible = true;
			TSB_RemoveRec.Visible = false;
			TSB_RemoveMount.Visible = false;
			TSL_WeaponCount2.Visible = false;
			TSL_WeaponCount1.Visible = false;
			TSB_ChangeWeaponCount.Visible = false;
		}
	}

	private void ResolveInterruptibleCreator(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (e.KeyCode == Keys.F8 && base.Visible)
		{
			Close();
			return;
		}
		if (m_ResolverExporter)
		{
			if (e.KeyValue == 13 && base.Visible)
			{
				TSB_ChangeWeaponCount.Select();
				return;
			}
			if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
			{
				ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!m_ResolverExporter && e.KeyValue != 32)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void PostInterruptibleCreator(object sender, EventArgs e)
	{
		m_ResolverExporter = true;
	}

	private void RunInterruptibleCreator(object sender, EventArgs e)
	{
		m_ResolverExporter = false;
		TSB_ChangeWeaponCount.Select();
	}

	private void StartInterruptibleCreator(object sender, FormClosedEventArgs e)
	{
		PlatformComponent.StatusChanged -= FillInterruptibleCreator;
		WeaponRec.CurrentLoadChanged -= CalculateInterruptibleCreator;
		Command_Core.Mount.MountWeaponRecordAdded -= ConcatInterruptibleCreator;
		Command_Core.Mount.MountWeaponRecordRemoved -= InterruptInterruptibleCreator;
		Loadout.LoadoutWeaponRecordAdded -= RemoveInterruptibleCreator;
		Loadout.LoadoutWeaponRecordRemoved -= FindInterruptibleCreator;
		ActiveUnit.ActiveUnitMountsAdded -= InstantiateInterruptibleCreator;
		ActiveUnit.ActiveUnitMountsRemoved -= PopInterruptibleCreator;
		Client._ManagerClass = null;
		ForgotInterruptibleCreator().Stop();
	}

	private void AssetInterruptibleCreator(object sender, EventArgs e)
	{
		if (Client.CurrentGame.Status != Game._GameStatus.Running)
		{
			return;
		}
		foreach (TreeGridNode node in TGV_Weapons.Nodes)
		{
			if (node.Tag != null && (object)node.Tag.GetType() == typeof(Mount))
			{
				Mount mount_ = (Mount)node.Tag;
				CreateInterruptibleCreator(node, mount_);
			}
		}
	}
}
