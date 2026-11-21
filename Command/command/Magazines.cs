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
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Magazines : DarkSecondaryFormBase, GInterface9
{
	[CompilerGenerated]
	private sealed class RulesExpressionDic
	{
		public Magazines Me;

		public TreeGridNode Local_theNode;

		public WeaponRec Local_theRec;

		internal void LogoutInterruptibleRules()
		{
			Me.CompareWorker(Local_theNode, Local_theRec);
			if (!Local_theNode.IsExpanded)
			{
				Local_theNode.Expand();
			}
		}
	}

	[CompilerGenerated]
	private sealed class GlobalMerchantService
	{
		public TreeGridNode Local_theNode;

		public TreeGridNode Local_theRecNode;

		internal void ViewInterruptibleRules()
		{
			Local_theNode.Nodes.Remove(Local_theRecNode);
		}
	}

	[CompilerGenerated]
	private sealed class StrategyMap
	{
		public Magazines Me;

		public TreeGridNode Local_theRecNode;

		public WeaponRec Local_theRec;

		internal void ValidateInterruptibleRules()
		{
			Local_theRecNode.SetValues(Conversions.ToString(Local_theRec.CurrentLoad) + "/" + Conversions.ToString(Local_theRec.MaxLoad) + " " + Misc.ReadRequest(Strings.Trim(Local_theRec.GetReferenceWeapon(Me.SelectedUnit.ParentScen).Name)));
		}
	}

	[CompilerGenerated]
	private sealed class ConfigurationMap
	{
		public Magazines Me;

		public TreeGridNode Local_theNode;

		public Magazine Local_theMag;

		internal void LoginInterruptibleRules()
		{
			Me.EnableWorker(Local_theNode, Local_theMag);
		}
	}

	[CompilerGenerated]
	private sealed class TokenMap
	{
		public Magazines Me;

		public Mount Local_theMount;

		internal void GetInterruptibleRules()
		{
			Me.SearchWorker(Local_theMount.MountMagazine);
		}
	}

	[CompilerGenerated]
	private sealed class IndexerMap
	{
		public Magazines Me0;

		public Magazine Local_theMag;

		internal void WriteInterruptibleRules()
		{
			Me0.SearchWorker(Local_theMag);
		}
	}

	[CompilerGenerated]
	private sealed class ProccesorDecoratorEntry
	{
		public List<WeaponRec> Local_WeapRecs_NotEmpty;

		public Magazines Me;

		public TreeGridNode Local_MagNode;

		public List<WeaponRec> Local_WeapRecs_Empty;

		internal void NewInterruptibleRules()
		{
			using (List<WeaponRec>.Enumerator enumerator = Local_WeapRecs_NotEmpty.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					MapperCollectionRecord CS_0024_003C_003E8__locals0 = new MapperCollectionRecord
					{
						CS_0024_003C_003E8__locals1 = this,
						Local_theRec = enumerator.Current
					};
					Me.Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Me.CompareWorker(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.Local_MagNode, CS_0024_003C_003E8__locals0.Local_theRec);
					});
				}
			}
			using List<WeaponRec>.Enumerator enumerator2 = Local_WeapRecs_Empty.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				ResolverMap CS_0024_003C_003E8__locals1 = new ResolverMap
				{
					CS_0024_003C_003E8__locals2 = this,
					Local_theRec0 = enumerator2.Current
				};
				Me.Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.Me.CompareWorker(CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals2.Local_MagNode, CS_0024_003C_003E8__locals1.Local_theRec0);
				});
			}
		}
	}

	[CompilerGenerated]
	private sealed class MapperCollectionRecord
	{
		public WeaponRec Local_theRec;

		public ProccesorDecoratorEntry CS_0024_003C_003E8__locals1;

		internal void PushInterruptibleRules()
		{
			CS_0024_003C_003E8__locals1.Me.CompareWorker(CS_0024_003C_003E8__locals1.Local_MagNode, Local_theRec);
		}
	}

	[CompilerGenerated]
	private sealed class ResolverMap
	{
		public WeaponRec Local_theRec0;

		public ProccesorDecoratorEntry CS_0024_003C_003E8__locals2;

		internal void InvokeInterruptibleRules()
		{
			CS_0024_003C_003E8__locals2.Me.CompareWorker(CS_0024_003C_003E8__locals2.Local_MagNode, Local_theRec0);
		}
	}

	private IContainer procModel;

	[AccessedThroughProperty("TGV_Mags")]
	[CompilerGenerated]
	private DarkTreeGridView m_StructAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("TS_Edit")]
	private DarkToolStrip m_MerchantAdvisor;

	[AccessedThroughProperty("TSB_RemoveRec")]
	[CompilerGenerated]
	private ToolStripButton callbackAdvisor;

	[AccessedThroughProperty("ToolStripLabel1")]
	[CompilerGenerated]
	private ToolStripLabel m_DecoratorAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSTB_RecCount")]
	private ToolStripTextBox _ProcessAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripLabel2")]
	private ToolStripLabel threadAdvisor;

	[AccessedThroughProperty("TSB_AddRec")]
	[CompilerGenerated]
	private ToolStripButton collectionAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer m_InstanceAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_AddMag")]
	private ToolStripButton objectAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_RemoveMag")]
	private ToolStripButton _ParameterAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("Column_Magazine")]
	private TreeGridColumn _ExpressionAdvisor;

	[AccessedThroughProperty("Status")]
	[CompilerGenerated]
	private TreeGridColumn m_DispatcherAdvisor;

	public ActiveUnit SelectedUnit;

	public Magazine SelectedMag;

	private WeaponRec listenerAdvisor;

	private MaintainScrollPosition m_ConfigAdvisor;

	[CompilerGenerated]
	[AccessedThroughProperty("CB1")]
	private ComboBox _RegistryAdvisor;

	private bool _DefinitionAdvisor;

	private Keys[] m_ValAdvisor;

	private DarkTreeGridView TGV_Mags
	{
		[CompilerGenerated]
		get
		{
			return m_StructAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = ChangeWorker;
			ExpandingEventHandler value3 = CreateWorker;
			CollapsingEventHandler value4 = DisableWorker;
			DarkTreeGridView structAdvisor = m_StructAdvisor;
			if (structAdvisor != null)
			{
				structAdvisor.CellMouseClick -= value2;
				structAdvisor.NodeExpanding -= value3;
				structAdvisor.NodeCollapsing -= value4;
			}
			m_StructAdvisor = value;
			structAdvisor = m_StructAdvisor;
			if (structAdvisor != null)
			{
				structAdvisor.CellMouseClick += value2;
				structAdvisor.NodeExpanding += value3;
				structAdvisor.NodeCollapsing += value4;
			}
		}
	}

	internal DarkToolStrip TS_Edit
	{
		[CompilerGenerated]
		get
		{
			return m_MerchantAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MerchantAdvisor = value;
		}
	}

	internal ToolStripButton TSB_RemoveRec
	{
		[CompilerGenerated]
		get
		{
			return callbackAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckWorker;
			ToolStripButton toolStripButton = callbackAdvisor;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			callbackAdvisor = value;
			toolStripButton = callbackAdvisor;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripLabel ToolStripLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_DecoratorAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DecoratorAdvisor = value;
		}
	}

	internal ToolStripTextBox TSTB_RecCount
	{
		[CompilerGenerated]
		get
		{
			return _ProcessAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatWorker;
			EventHandler value3 = SetWorker;
			EventHandler value4 = FillWorker;
			ToolStripTextBox processAdvisor = _ProcessAdvisor;
			if (processAdvisor != null)
			{
				processAdvisor.TextChanged -= value2;
				processAdvisor.Enter -= value3;
				processAdvisor.Leave -= value4;
			}
			_ProcessAdvisor = value;
			processAdvisor = _ProcessAdvisor;
			if (processAdvisor != null)
			{
				processAdvisor.TextChanged += value2;
				processAdvisor.Enter += value3;
				processAdvisor.Leave += value4;
			}
		}
	}

	internal ToolStripLabel ToolStripLabel2
	{
		[CompilerGenerated]
		get
		{
			return threadAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			threadAdvisor = value;
		}
	}

	[field: AccessedThroughProperty("TSC_MagStatus")]
	internal ToolStripComboBox TSC_MagStatus
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton TSB_AddRec
	{
		[CompilerGenerated]
		get
		{
			return collectionAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitWorker;
			ToolStripButton toolStripButton = collectionAdvisor;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			collectionAdvisor = value;
			toolStripButton = collectionAdvisor;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_AddMag
	{
		[CompilerGenerated]
		get
		{
			return objectAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopWorker;
			ToolStripButton toolStripButton = objectAdvisor;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			objectAdvisor = value;
			toolStripButton = objectAdvisor;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_RemoveMag
	{
		[CompilerGenerated]
		get
		{
			return _ParameterAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateWorker;
			ToolStripButton parameterAdvisor = _ParameterAdvisor;
			if (parameterAdvisor != null)
			{
				parameterAdvisor.Click -= value2;
			}
			_ParameterAdvisor = value;
			parameterAdvisor = _ParameterAdvisor;
			if (parameterAdvisor != null)
			{
				parameterAdvisor.Click += value2;
			}
		}
	}

	internal TreeGridColumn Status
	{
		[CompilerGenerated]
		get
		{
			return m_DispatcherAdvisor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DispatcherAdvisor = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer PublishWorker()
	{
		return m_InstanceAdvisor;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void AwakeWorker(Timer timer_0)
	{
		m_InstanceAdvisor = timer_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal TreeGridColumn RateWorker()
	{
		return _ExpressionAdvisor;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void FlushWorker(TreeGridColumn treeGridColumn_0)
	{
		_ExpressionAdvisor = treeGridColumn_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private ComboBox RegisterWorker()
	{
		return _RegistryAdvisor;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void ManageWorker(ComboBox comboBox_0)
	{
		EventHandler value = InterruptWorker;
		ComboBox registryAdvisor = _RegistryAdvisor;
		if (registryAdvisor != null)
		{
			registryAdvisor.SelectionChangeCommitted -= value;
		}
		_RegistryAdvisor = comboBox_0;
		registryAdvisor = _RegistryAdvisor;
		if (registryAdvisor != null)
		{
			registryAdvisor.SelectionChangeCommitted += value;
		}
	}

	public Magazines()
	{
		base.Load += ViewWorker;
		base.Shown += NewWorker;
		base.KeyDown += RemoveWorker;
		base.FormClosing += FindWorker;
		base.FormClosed += CalculateWorker;
		base.Closed += ReadWorker;
		m_ConfigAdvisor = new MaintainScrollPosition();
		m_ValAdvisor = new Keys[2]
		{
			Keys.F5,
			Keys.Escape
		};
		LogoutWorker();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && procModel != null)
			{
				procModel.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void LogoutWorker()
	{
		procModel = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(Magazines));
		TGV_Mags = new DarkTreeGridView();
		TS_Edit = new DarkToolStrip();
		TSB_AddMag = new ToolStripButton();
		TSB_RemoveMag = new ToolStripButton();
		TSB_AddRec = new ToolStripButton();
		TSB_RemoveRec = new ToolStripButton();
		ToolStripLabel1 = new ToolStripLabel();
		TSTB_RecCount = new ToolStripTextBox();
		ToolStripLabel2 = new ToolStripLabel();
		TSC_MagStatus = new ToolStripComboBox();
		AwakeWorker(new Timer(procModel));
		FlushWorker(new TreeGridColumn());
		Status = new TreeGridColumn();
		((ISupportInitialize)TGV_Mags).BeginInit();
		TS_Edit.SuspendLayout();
		SuspendLayout();
		TGV_Mags.AllowUserToAddRows = false;
		TGV_Mags.AllowUserToDeleteRows = false;
		TGV_Mags.AllowUserToOrderColumns = true;
		TGV_Mags.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TGV_Mags.BackgroundColor = Color.FromArgb(43, 43, 43);
		TGV_Mags.BorderStyle = BorderStyle.Fixed3D;
		TGV_Mags.CellBorderStyle = DataGridViewCellBorderStyle.None;
		TGV_Mags.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		TGV_Mags.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		TGV_Mags.Columns.AddRange(RateWorker(), Status);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		TGV_Mags.DefaultCellStyle = dataGridViewCellStyle2;
		TGV_Mags.EditMode = DataGridViewEditMode.EditProgrammatically;
		TGV_Mags.EnableHeadersVisualStyles = false;
		TGV_Mags.ImageList = null;
		TGV_Mags.Location = new Point(0, 0);
		TGV_Mags.Name = "TGV_Mags";
		TGV_Mags.RowHeadersVisible = false;
		TGV_Mags.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		TGV_Mags.ShowLines = false;
		TGV_Mags.Size = new Size(815, 300);
		TGV_Mags.TabIndex = 5;
		TS_Edit.AutoSize = false;
		TS_Edit.BackColor = Color.FromArgb(60, 63, 65);
		TS_Edit.Dock = DockStyle.Bottom;
		TS_Edit.ForeColor = Color.FromArgb(220, 220, 220);
		TS_Edit.GripStyle = ToolStripGripStyle.Hidden;
		TS_Edit.Items.AddRange(new ToolStripItem[8] { TSB_AddMag, TSB_RemoveMag, TSB_AddRec, TSB_RemoveRec, ToolStripLabel1, TSTB_RecCount, ToolStripLabel2, TSC_MagStatus });
		TS_Edit.Location = new Point(0, 303);
		TS_Edit.Name = "TS_Edit";
		TS_Edit.Padding = new Padding(5, 0, 1, 0);
		TS_Edit.Size = new Size(815, 25);
		TS_Edit.TabIndex = 6;
		TS_Edit.Text = "ToolStrip1";
		TSB_AddMag.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddMag.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddMag.Image = componentResourceManager.GetObject("TSB_AddMag.Image");
		TSB_AddMag.ImageScaling = ToolStripItemImageScaling.None;
		TSB_AddMag.ImageTransparentColor = Color.Magenta;
		TSB_AddMag.Name = "TSB_AddMag";
		TSB_AddMag.Size = new Size(103, 22);
		TSB_AddMag.Text = "添加弹药";
		TSB_RemoveMag.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveMag.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveMag.Image = componentResourceManager.GetObject("TSB_RemoveMag.Image");
		TSB_RemoveMag.ImageTransparentColor = Color.Magenta;
		TSB_RemoveMag.Name = "TSB_RemoveMag";
		TSB_RemoveMag.Size = new Size(124, 22);
		TSB_RemoveMag.Text = "删除弹药";
		TSB_AddRec.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddRec.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddRec.Image = componentResourceManager.GetObject("TSB_AddRec.Image");
		TSB_AddRec.ImageTransparentColor = Color.Magenta;
		TSB_AddRec.Name = "TSB_AddRec";
		TSB_AddRec.Size = new Size(101, 22);
		TSB_AddRec.Text = "添加武器";
		TSB_RemoveRec.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveRec.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveRec.Image = componentResourceManager.GetObject("TSB_RemoveRec.Image");
		TSB_RemoveRec.ImageTransparentColor = Color.Magenta;
		TSB_RemoveRec.Name = "TSB_RemoveRec";
		TSB_RemoveRec.Size = new Size(122, 22);
		TSB_RemoveRec.Text = "删除武器";
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(90, 22);
		ToolStripLabel1.Text = "武器数量：";
		TSTB_RecCount.BackColor = Color.FromArgb(60, 63, 65);
		TSTB_RecCount.ForeColor = Color.FromArgb(220, 220, 220);
		TSTB_RecCount.Name = "TSTB_RecCount";
		TSTB_RecCount.Size = new Size(50, 25);
		ToolStripLabel2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel2.Name = "ToolStripLabel2";
		ToolStripLabel2.Size = new Size(42, 22);
		ToolStripLabel2.Text = "状态：";
		TSC_MagStatus.BackColor = Color.FromArgb(60, 63, 65);
		TSC_MagStatus.ForeColor = Color.FromArgb(220, 220, 220);
		TSC_MagStatus.Items.AddRange(new object[5] { "正常工作", "受损（轻度）", "受损（中度）", "受损（重度）", "被摧毁" });
		TSC_MagStatus.Name = "TSC_MagStatus";
		TSC_MagStatus.Size = new Size(121, 25);
		PublishWorker().Interval = 1000;
		RateWorker().AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		RateWorker().DataPropertyName = "Name";
		RateWorker().DefaultNodeImage = null;
		RateWorker().HeaderText = "弹药";
		RateWorker().Name = "Magazine";
		RateWorker().Resizable = DataGridViewTriState.True;
		RateWorker().SortMode = DataGridViewColumnSortMode.NotSortable;
		Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Status.DefaultNodeImage = null;
		Status.HeaderText = "状态";
		Status.Name = "Status";
		Status.ReadOnly = true;
		Status.SortMode = DataGridViewColumnSortMode.NotSortable;
		Status.Width = 43;
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(815, 328);
		base.Controls.Add(TS_Edit);
		base.Controls.Add(TGV_Mags);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Magazines";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "弹药库";
		((ISupportInitialize)TGV_Mags).EndInit();
		TS_Edit.ResumeLayout(performLayout: false);
		TS_Edit.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] valAdvisor = m_ValAdvisor;
		int num = 0;
		while (true)
		{
			if (num < valAdvisor.Length)
			{
				Keys keys = valAdvisor[num];
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

	public void RefreshForm()
	{
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}

	private void ViewWorker(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		ManageWorker(TSC_MagStatus.ComboBox);
		PlatformComponent.StatusChanged += ExcludeWorker;
		WeaponRec.CurrentLoadChanged += SetupWorker;
		Magazine.MagazineWeaponRecordAdded += PushWorker;
		Magazine.MagazineWeaponRecordRemoved += InvokeWorker;
		Platform.PlatformMagazinesAdded += WriteWorker;
		Platform.PlatformMagazinesRemoved += GetWorker;
		ActiveUnit.ActiveUnitMountsAdded += LoginWorker;
		ActiveUnit.ActiveUnitMountsRemoved += ValidateWorker;
	}

	private void ValidateWorker(string string_0, string string_1)
	{
		IncludeWorker();
	}

	private void LoginWorker(string string_0, string string_1)
	{
		IncludeWorker();
	}

	private void GetWorker(string string_0, string string_1)
	{
		IncludeWorker();
	}

	private void WriteWorker(string string_0, string string_1)
	{
		IncludeWorker();
	}

	private void NewWorker(object sender, EventArgs e)
	{
		TS_Edit.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		TSB_AddRec.Enabled = false;
		TSB_RemoveRec.Enabled = false;
		IncludeWorker();
		Text = "弹药库状态 - " + SelectedUnit.Name;
	}

	private void PushWorker(string string_0, string string_1)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Mags.Nodes.GetEnumerator();
		Magazines Me = null;
		TreeGridNode Local_theNode = null;
		WeaponRec Local_theRec;
		while (enumerator.MoveNext())
		{
			Me = this;
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Magazine))
			{
				continue;
			}
			Magazine magazine = (Magazine)Local_theNode.Tag;
			if (Operators.CompareString(magazine.ObjectID, string_0, TextCompare: true) != 0)
			{
				continue;
			}
			using List<WeaponRec>.Enumerator enumerator2 = magazine.Weapons.GetEnumerator();
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
					Me.CompareWorker(Local_theNode, Local_theRec);
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

	private void InvokeWorker(string string_0, string string_1)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Mags.Nodes.GetEnumerator();
		TreeGridNode Local_theNode = null;
		TreeGridNode Local_theRecNode;
		while (enumerator.MoveNext())
		{
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Magazine) || Operators.CompareString(((Magazine)Local_theNode.Tag).ObjectID, string_0, TextCompare: true) != 0)
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

	private void SetupWorker(string string_0)
	{
		if (SelectedUnit == null)
		{
			return;
		}
		TreeGridNode Local_theRecNode;
		WeaponRec Local_theRec;
		foreach (TreeGridNode node in TGV_Mags.Nodes)
		{
			if (node.Tag == null || (object)node.Tag.GetType() != typeof(Magazine))
			{
				continue;
			}
			_ = (Magazine)node.Tag;
			using IEnumerator<TreeGridNode> enumerator2 = node.Nodes.GetEnumerator();
			Local_theRecNode = null;
			while (enumerator2.MoveNext())
			{
				Local_theRecNode = enumerator2.Current;
				if (Local_theRecNode.Tag == null || (object)Local_theRecNode.Tag.GetType() != typeof(WeaponRec))
				{
					continue;
				}
				Local_theRec = (WeaponRec)Local_theRecNode.Tag;
				if (Operators.CompareString(Local_theRec.ObjectID, string_0, TextCompare: true) != 0)
				{
					continue;
				}
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					Local_theRecNode.SetValues(Conversions.ToString(Local_theRec.CurrentLoad) + "/" + Conversions.ToString(Local_theRec.MaxLoad) + " " + Misc.ReadRequest(Strings.Trim(Local_theRec.GetReferenceWeapon(SelectedUnit.ParentScen).Name)));
				});
				break;
			}
			break;
		}
	}

	private void ExcludeWorker(PlatformComponent platformComponent_0)
	{
		using IEnumerator<TreeGridNode> enumerator = TGV_Mags.Nodes.GetEnumerator();
		Magazine Local_theMag = null;
		Magazines Me = null;
		TreeGridNode Local_theNode = null;
		while (enumerator.MoveNext())
		{
			Me = this;
			Local_theNode = enumerator.Current;
			if (Local_theNode.Tag == null || (object)Local_theNode.Tag.GetType() != typeof(Magazine))
			{
				continue;
			}
			Local_theMag = (Magazine)Local_theNode.Tag;
			if (Operators.CompareString(Local_theMag.ObjectID, platformComponent_0.ObjectID, TextCompare: true) != 0)
			{
				continue;
			}
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				Me.EnableWorker(Local_theNode, Local_theMag);
			});
			break;
		}
	}

	private void IncludeWorker()
	{
		if (SelectedUnit == null)
		{
			return;
		}
		TGV_Mags.Nodes.Clear();
		Task.Factory.StartNew(delegate
		{
			foreach (Mount Local_theMount in SelectedUnit.Mounts)
			{
				if (Local_theMount.MountMagazine.Weapons.Count > 0)
				{
					Invoke((VB_0024AnonymousDelegate_0)delegate
					{
						SearchWorker(Local_theMount.MountMagazine);
					});
				}
			}
			Magazine[] sharedMagazines = SelectedUnit.SharedMagazines;
			Magazine[] array = sharedMagazines;
			foreach (Magazine Local_theMag in array)
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					SearchWorker(Local_theMag);
				});
			}
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				if (TGV_Mags.Nodes.Count <= 0)
				{
					TSB_AddRec.Enabled = false;
					TSB_RemoveRec.Enabled = false;
				}
				else
				{
					SelectedMag = (Magazine)TGV_Mags.Nodes[0].Tag;
					TSB_AddRec.Enabled = true;
					TSB_RemoveRec.Enabled = true;
				}
				TSB_AddMag.Visible = !SelectedUnit.IsGroup;
			});
		});
	}

	private void SearchWorker(Magazine magazine_0)
	{
		TreeGridNode treeGridNode = TGV_Mags.Nodes.Add("新节点");
		EnableWorker(treeGridNode, magazine_0);
		if (magazine_0.Weapons.Count > 0)
		{
			treeGridNode.Nodes.Add("Temp");
		}
	}

	private void EnableWorker(TreeGridNode treeGridNode_0, Magazine magazine_0)
	{
		string text = ((!SelectedUnit.IsGroup || !((Group)SelectedUnit).IsLandInstallation) ? Misc.ReadRequest(magazine_0.Name) : (Misc.ReadRequest(magazine_0.Name) + " [" + magazine_0.ParentPlatform.Name + "]"));
		Color componentDamageColor = GetComponentDamageColor(magazine_0);
		treeGridNode_0.SetValues(text, magazine_0.Status.ToString());
		treeGridNode_0.DefaultCellStyle.ForeColor = componentDamageColor;
		treeGridNode_0.Tag = magazine_0;
	}

	private void ChangeWorker(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex != -1 && !Information.IsNothing(TGV_Mags.CurrentNode))
		{
			if ((object)TGV_Mags.CurrentNode.Tag.GetType() == typeof(Magazine))
			{
				SelectedMag = (Magazine)TGV_Mags.CurrentNode.Tag;
				TSB_RemoveRec.Enabled = false;
				TSTB_RecCount.Enabled = false;
				TSC_MagStatus.Enabled = true;
			}
			if ((object)TGV_Mags.CurrentNode.Tag.GetType() == typeof(WeaponRec))
			{
				SelectedMag = (Magazine)TGV_Mags.CurrentNode.Parent.Tag;
				listenerAdvisor = (WeaponRec)TGV_Mags.CurrentNode.Tag;
				TSB_RemoveRec.Enabled = true;
				TSTB_RecCount.Enabled = true;
				TSC_MagStatus.Enabled = false;
			}
			switch (SelectedMag.Status)
			{
			case PlatformComponent._ComponentStatus.Operational:
				TSC_MagStatus.SelectedIndex = 0;
				break;
			case PlatformComponent._ComponentStatus.Damaged:
				TSC_MagStatus.SelectedIndex = 1;
				break;
			case PlatformComponent._ComponentStatus.Destroyed:
				TSC_MagStatus.SelectedIndex = 2;
				break;
			}
		}
	}

	private void InitWorker(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.AddWeaponRecord.FormThatCalledMe = this;
		ItemExporter.ConnectInterruptibleTemplate.AddWeaponRecord.Show();
	}

	private void CheckWorker(object sender, EventArgs e)
	{
		switch (TGV_Mags.SelectedRows.Count)
		{
		case 1:
			SelectedMag.Weapons.Remove(listenerAdvisor);
			return;
		case 0:
			return;
		}
		List<DataGridViewRow> list = new List<DataGridViewRow>();
		IEnumerator enumerator = null;
		try
		{
			enumerator = TGV_Mags.SelectedRows.GetEnumerator();
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
			SelectedMag.Weapons.Remove((WeaponRec)item.Tag);
		}
	}

	private void ConcatWorker(object sender, EventArgs e)
	{
		if (Information.IsNothing(listenerAdvisor) || !((Operators.CompareString(TSTB_RecCount.Text, "", TextCompare: true) != 0) & Versioned.IsNumeric(TSTB_RecCount.Text)))
		{
			return;
		}
		int num = Conversions.ToInteger(TSTB_RecCount.Text);
		if (num < 0)
		{
			num = 0;
		}
		if (num > listenerAdvisor.MaxLoad)
		{
			num = listenerAdvisor.MaxLoad;
		}
		if ((double)num / (double)listenerAdvisor.Multiple > (double)listenerAdvisor.MaxLoad)
		{
			num = listenerAdvisor.MaxLoad;
		}
		listenerAdvisor.CurrentLoad = 0;
		Magazine selectedMag = SelectedMag;
		int int_ = 0;
		int int_2 = 0;
		int num2 = selectedMag.InitClass(ref int_, ref int_2);
		if ((double)num / (double)listenerAdvisor.Multiple > (double)(SelectedMag.Capacity - num2))
		{
			num = SelectedMag.Capacity - num2 * listenerAdvisor.Multiple;
		}
		if (num < 0)
		{
			num = 0;
		}
		listenerAdvisor.CurrentLoad = num;
		foreach (TreeGridNode node in TGV_Mags.Nodes)
		{
			foreach (TreeGridNode node2 in node.Nodes)
			{
				if (node2.Tag == listenerAdvisor)
				{
					node2.SetValues(Conversions.ToString(listenerAdvisor.CurrentLoad) + "/" + Conversions.ToString(listenerAdvisor.MaxLoad) + " " + Misc.ReadRequest(Strings.Trim(listenerAdvisor.GetReferenceWeapon(Client.CurrentScenario).Name)));
					return;
				}
			}
		}
	}

	private void InterruptWorker(object sender, EventArgs e)
	{
		switch (RegisterWorker().SelectedIndex)
		{
		case 0:
			SelectedMag.MakeOperational(bool_0: true);
			break;
		case 1:
			SelectedMag.Damage(PlatformComponent._DamageSeverityFactor.Light);
			break;
		case 2:
			SelectedMag.Damage(PlatformComponent._DamageSeverityFactor.Medium);
			break;
		case 3:
			SelectedMag.Damage(PlatformComponent._DamageSeverityFactor.Heavy);
			break;
		case 4:
			SelectedMag.Destroy(SelectedUnit.GetUnitSide(), bool_0: true, Module_ActiveUnit.CancelTokenizer(SelectedMag.ParentPlatform));
			break;
		}
	}

	private void RemoveWorker(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (e.KeyCode == Keys.F5 && base.Visible)
		{
			Close();
			return;
		}
		if (_DefinitionAdvisor && (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (!_DefinitionAdvisor && (e.KeyValue != 32 || !base.Visible))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void FindWorker(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void SetWorker(object sender, EventArgs e)
	{
		_DefinitionAdvisor = true;
	}

	private void FillWorker(object sender, EventArgs e)
	{
		_DefinitionAdvisor = false;
		ToolStripLabel2.Select();
	}

	private void CalculateWorker(object sender, FormClosedEventArgs e)
	{
		PlatformComponent.StatusChanged -= ExcludeWorker;
		WeaponRec.CurrentLoadChanged -= SetupWorker;
		Magazine.MagazineWeaponRecordAdded -= PushWorker;
		Magazine.MagazineWeaponRecordRemoved -= InvokeWorker;
		Platform.PlatformMagazinesAdded -= WriteWorker;
		Platform.PlatformMagazinesRemoved -= GetWorker;
		ActiveUnit.ActiveUnitMountsAdded -= LoginWorker;
		ActiveUnit.ActiveUnitMountsRemoved -= ValidateWorker;
	}

	private void PopWorker(object sender, EventArgs e)
	{
		if (!Information.IsNothing(SelectedUnit) && !SelectedUnit.IsGroup)
		{
			ItemExporter.ConnectInterruptibleTemplate.AddMagazine.FormThatCalledMe = this;
			ItemExporter.ConnectInterruptibleTemplate.AddMagazine.Show();
		}
	}

	private void InstantiateWorker(object sender, EventArgs e)
	{
		if (!(!Information.IsNothing(SelectedUnit) & !Information.IsNothing(SelectedMag)))
		{
			return;
		}
		if (SelectedUnit.IsPlatform)
		{
			((Platform)SelectedUnit).RemoveSharedMagazine(SelectedMag);
		}
		else
		{
			if (!SelectedUnit.IsGroup)
			{
				return;
			}
			foreach (ActiveUnit value in ((Group)SelectedUnit).Units.Values)
			{
				if (value.IsPlatform && ((Platform)value).Magazines.Contains(SelectedMag))
				{
					((Platform)value).RemoveSharedMagazine(SelectedMag);
					break;
				}
			}
		}
	}

	private void CreateWorker(object sender, ExpandingEventArgs e)
	{
		if (e.Node.Tag == null || (object)e.Node.Tag.GetType() != typeof(Magazine))
		{
			return;
		}
		TreeGridNode Local_MagNode = e.Node;
		Magazine magazine = (Magazine)e.Node.Tag;
		Local_MagNode.Nodes.Clear();
		List<WeaponRec> Local_WeapRecs_NotEmpty = magazine.Weapons.Where((WeaponRec theWR) => theWR.CurrentLoad > 0).OrderBy((WeaponRec theWR) => theWR.GetReferenceWeapon(Client.CurrentScenario).Name, new NaturalSortComparer<string[]>()).ToList();
		List<WeaponRec> Local_WeapRecs_Empty = magazine.Weapons.Where((WeaponRec theWR) => theWR.CurrentLoad == 0).OrderBy((WeaponRec theWR) => theWR.GetReferenceWeapon(Client.CurrentScenario).Name, new NaturalSortComparer<string[]>()).ToList();
		Task.Factory.StartNew(delegate
		{
			foreach (WeaponRec Local_theRec in Local_WeapRecs_NotEmpty)
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					CompareWorker(Local_MagNode, Local_theRec);
				});
			}
			foreach (WeaponRec Local_theRec2 in Local_WeapRecs_Empty)
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					CompareWorker(Local_MagNode, Local_theRec2);
				});
			}
		});
	}

	private void CompareWorker(TreeGridNode treeGridNode_0, WeaponRec weaponRec_0)
	{
		treeGridNode_0.Nodes.Add(Conversions.ToString(weaponRec_0.CurrentLoad) + "/" + Conversions.ToString(weaponRec_0.MaxLoad) + " " + Misc.ReadRequest(Strings.Trim(weaponRec_0.GetReferenceWeapon(SelectedUnit.ParentScen).Name))).Tag = weaponRec_0;
	}

	private void ReadWorker(object sender, EventArgs e)
	{
		PlatformComponent.StatusChanged -= ExcludeWorker;
		WeaponRec.CurrentLoadChanged -= SetupWorker;
		Magazine.MagazineWeaponRecordAdded -= PushWorker;
		Magazine.MagazineWeaponRecordRemoved -= InvokeWorker;
	}

	private void DisableWorker(object sender, CollapsingEventArgs e)
	{
		e.Node.Nodes.Clear();
		e.Node.Nodes.Add("Temp");
	}

	[CompilerGenerated]
	private void UpdateWorker()
	{
		foreach (Mount Local_theMount in SelectedUnit.Mounts)
		{
			if (Local_theMount.MountMagazine.Weapons.Count > 0)
			{
				Invoke((VB_0024AnonymousDelegate_0)delegate
				{
					SearchWorker(Local_theMount.MountMagazine);
				});
			}
		}
		Magazine[] sharedMagazines = SelectedUnit.SharedMagazines;
		Magazine[] array = sharedMagazines;
		foreach (Magazine Local_theMag in array)
		{
			Invoke((VB_0024AnonymousDelegate_0)delegate
			{
				SearchWorker(Local_theMag);
			});
		}
		Invoke((VB_0024AnonymousDelegate_0)delegate
		{
			if (TGV_Mags.Nodes.Count <= 0)
			{
				TSB_AddRec.Enabled = false;
				TSB_RemoveRec.Enabled = false;
			}
			else
			{
				SelectedMag = (Magazine)TGV_Mags.Nodes[0].Tag;
				TSB_AddRec.Enabled = true;
				TSB_RemoveRec.Enabled = true;
			}
			TSB_AddMag.Visible = !SelectedUnit.IsGroup;
		});
	}

	[CompilerGenerated]
	private void InsertWorker()
	{
		if (TGV_Mags.Nodes.Count <= 0)
		{
			TSB_AddRec.Enabled = false;
			TSB_RemoveRec.Enabled = false;
		}
		else
		{
			SelectedMag = (Magazine)TGV_Mags.Nodes[0].Tag;
			TSB_AddRec.Enabled = true;
			TSB_RemoveRec.Enabled = true;
		}
		TSB_AddMag.Visible = !SelectedUnit.IsGroup;
	}
}
