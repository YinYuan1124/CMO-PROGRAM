using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.LoadSave;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class CampaignEditorWindow : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class ValMerchantPage
	{
		public CampaignEditorWindow _003C_003E4__this;

		public Campaign.CampaignItem campaignItem;

		public string text;

		internal void StartInterruptibleParam()
		{
			string text = Path.Combine(Path.GetDirectoryName(Campaign.GetCampaignFilename(_003C_003E4__this.theCampaign.ID)), ((Campaign.ScenarioRecord)campaignItem).FileName);
			ScenContainer scenContainer = ScenContainer.LoadFromFile(text);
			string string_ = null;
			Scenario scenarioObject = scenContainer.GetScenarioObject(ref string_, null, bool_0: false);
			scenarioObject.ObjectID = this.text;
			File.Move(text, text + ".OLD");
			LoadSave.SaveScenario(scenarioObject, scenarioObject.GetCurrentSide(), text, bool_0: false);
			File.Delete(text + ".OLD");
		}
	}

	private IContainer _ObserverInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("DGV_CampaignItems")]
	private DarkDataGridView issuerInvocation;

	[AccessedThroughProperty("TSB_AddScenario")]
	[CompilerGenerated]
	private ToolStripButton m_ClientInvocation;

	[AccessedThroughProperty("TSB_RemoveSelected")]
	[CompilerGenerated]
	private ToolStripButton m_DicInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_MoveUp")]
	private ToolStripButton _ConsumerInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_MoveDown")]
	private ToolStripButton facadeInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_Save")]
	private ToolStripButton proxyInvocation;

	[AccessedThroughProperty("OpenFileDialog_AddScen")]
	[CompilerGenerated]
	private OpenFileDialog _ReaderInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("SaveFileDialog_SaveCampaign")]
	private SaveFileDialog _PropertyInvocation;

	[AccessedThroughProperty("TSB_Description")]
	[CompilerGenerated]
	private ToolStripButton _ImporterInvocation;

	[AccessedThroughProperty("TSB_AddAttachment")]
	[CompilerGenerated]
	private ToolStripButton repositoryInvocation;

	[AccessedThroughProperty("TSB_CampaignEnding")]
	[CompilerGenerated]
	private ToolStripButton _BridgeInvocation;

	[AccessedThroughProperty("TS_PassScore")]
	[CompilerGenerated]
	private DarkToolStrip m_InvocationInvocation;

	[CompilerGenerated]
	[AccessedThroughProperty("TSTB_PassScore")]
	private ToolStripTextBox requestInvocation;

	[AccessedThroughProperty("TSL_SetScore")]
	[CompilerGenerated]
	private ToolStripButton _ValueInvocation;

	[AccessedThroughProperty("Column2")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn stubInvocation;

	[AccessedThroughProperty("ScenarioID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn writerInvocation;

	[AccessedThroughProperty("ToolStrip1")]
	[CompilerGenerated]
	private DarkToolStrip watcherInvocation;

	public Campaign theCampaign;

	public string CampaignFileName;

	private Keys[] m_ReponseInvocation;

	internal DarkDataGridView DGV_CampaignItems
	{
		[CompilerGenerated]
		get
		{
			return issuerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyContext;
			DataGridViewCellEventHandler value3 = StartContext;
			DarkDataGridView darkDataGridView = issuerInvocation;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged -= value2;
				darkDataGridView.CellContentClick -= value3;
			}
			issuerInvocation = value;
			darkDataGridView = issuerInvocation;
			if (darkDataGridView != null)
			{
				darkDataGridView.SelectionChanged += value2;
				darkDataGridView.CellContentClick += value3;
			}
		}
	}

	internal ToolStripButton TSB_AddScenario
	{
		[CompilerGenerated]
		get
		{
			return m_ClientInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrepareContext;
			ToolStripButton clientInvocation = m_ClientInvocation;
			if (clientInvocation != null)
			{
				clientInvocation.Click -= value2;
			}
			m_ClientInvocation = value;
			clientInvocation = m_ClientInvocation;
			if (clientInvocation != null)
			{
				clientInvocation.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_RemoveSelected
	{
		[CompilerGenerated]
		get
		{
			return m_DicInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReflectContext;
			ToolStripButton dicInvocation = m_DicInvocation;
			if (dicInvocation != null)
			{
				dicInvocation.Click -= value2;
			}
			m_DicInvocation = value;
			dicInvocation = m_DicInvocation;
			if (dicInvocation != null)
			{
				dicInvocation.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_MoveUp
	{
		[CompilerGenerated]
		get
		{
			return _ConsumerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitContext;
			ToolStripButton consumerInvocation = _ConsumerInvocation;
			if (consumerInvocation != null)
			{
				consumerInvocation.Click -= value2;
			}
			_ConsumerInvocation = value;
			consumerInvocation = _ConsumerInvocation;
			if (consumerInvocation != null)
			{
				consumerInvocation.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_MoveDown
	{
		[CompilerGenerated]
		get
		{
			return facadeInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartContext;
			ToolStripButton toolStripButton = facadeInvocation;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			facadeInvocation = value;
			toolStripButton = facadeInvocation;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Save
	{
		[CompilerGenerated]
		get
		{
			return proxyInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestContext;
			ToolStripButton toolStripButton = proxyInvocation;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			proxyInvocation = value;
			toolStripButton = proxyInvocation;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_Description
	{
		[CompilerGenerated]
		get
		{
			return _ImporterInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelContext;
			ToolStripButton importerInvocation = _ImporterInvocation;
			if (importerInvocation != null)
			{
				importerInvocation.Click -= value2;
			}
			_ImporterInvocation = value;
			importerInvocation = _ImporterInvocation;
			if (importerInvocation != null)
			{
				importerInvocation.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_AddAttachment
	{
		[CompilerGenerated]
		get
		{
			return repositoryInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListContext;
			ToolStripButton toolStripButton = repositoryInvocation;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			repositoryInvocation = value;
			toolStripButton = repositoryInvocation;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_CampaignEnding
	{
		[CompilerGenerated]
		get
		{
			return _BridgeInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveContext;
			ToolStripButton bridgeInvocation = _BridgeInvocation;
			if (bridgeInvocation != null)
			{
				bridgeInvocation.Click -= value2;
			}
			_BridgeInvocation = value;
			bridgeInvocation = _BridgeInvocation;
			if (bridgeInvocation != null)
			{
				bridgeInvocation.Click += value2;
			}
		}
	}

	internal DarkToolStrip TS_PassScore
	{
		[CompilerGenerated]
		get
		{
			return m_InvocationInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InvocationInvocation = value;
		}
	}

	[field: AccessedThroughProperty("TSL_PassScore")]
	internal ToolStripLabel TSL_PassScore
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripTextBox TSTB_PassScore
	{
		[CompilerGenerated]
		get
		{
			return requestInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			requestInvocation = value;
		}
	}

	internal ToolStripButton TSL_SetScore
	{
		[CompilerGenerated]
		get
		{
			return _ValueInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostContext;
			ToolStripButton valueInvocation = _ValueInvocation;
			if (valueInvocation != null)
			{
				valueInvocation.Click -= value2;
			}
			_ValueInvocation = value;
			valueInvocation = _ValueInvocation;
			if (valueInvocation != null)
			{
				valueInvocation.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Column1")]
	internal DataGridViewTextBoxColumn Column1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Column2
	{
		[CompilerGenerated]
		get
		{
			return stubInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stubInvocation = value;
		}
	}

	internal DataGridViewTextBoxColumn ScenarioID
	{
		[CompilerGenerated]
		get
		{
			return writerInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			writerInvocation = value;
		}
	}

	[field: AccessedThroughProperty("ChangeScenID")]
	internal DataGridViewButtonColumn ChangeScenID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkToolStrip ToolStrip1
	{
		[CompilerGenerated]
		get
		{
			return watcherInvocation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			watcherInvocation = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal OpenFileDialog ForgotContext()
	{
		return _ReaderInvocation;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void CollectContext(OpenFileDialog openFileDialog_0)
	{
		_ReaderInvocation = openFileDialog_0;
	}

	[SpecialName]
	[CompilerGenerated]
	internal SaveFileDialog RegisterContext()
	{
		return _PropertyInvocation;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void ManageContext(SaveFileDialog saveFileDialog_0)
	{
		_PropertyInvocation = saveFileDialog_0;
	}

	public CampaignEditorWindow()
	{
		base.FormClosing += InsertContext;
		base.VisibleChanged += StopContext;
		base.Load += RunContext;
		m_ReponseInvocation = new Keys[1] { Keys.Escape };
		DisableContext();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ObserverInvocation != null)
			{
				_ObserverInvocation.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DisableContext()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(CampaignEditorWindow));
		DGV_CampaignItems = new DarkDataGridView();
		Column1 = new DataGridViewTextBoxColumn();
		Column2 = new DataGridViewTextBoxColumn();
		ScenarioID = new DataGridViewTextBoxColumn();
		ChangeScenID = new DataGridViewButtonColumn();
		ToolStrip1 = new DarkToolStrip();
		TSB_AddScenario = new ToolStripButton();
		TSB_AddAttachment = new ToolStripButton();
		TSB_RemoveSelected = new ToolStripButton();
		TSB_MoveUp = new ToolStripButton();
		TSB_MoveDown = new ToolStripButton();
		TSB_Description = new ToolStripButton();
		TSB_CampaignEnding = new ToolStripButton();
		TSB_Save = new ToolStripButton();
		CollectContext(new OpenFileDialog());
		ManageContext(new SaveFileDialog());
		TS_PassScore = new DarkToolStrip();
		TSL_PassScore = new ToolStripLabel();
		TSTB_PassScore = new ToolStripTextBox();
		TSL_SetScore = new ToolStripButton();
		((ISupportInitialize)DGV_CampaignItems).BeginInit();
		ToolStrip1.SuspendLayout();
		TS_PassScore.SuspendLayout();
		SuspendLayout();
		DGV_CampaignItems.AllowUserToAddRows = false;
		DGV_CampaignItems.AllowUserToDeleteRows = false;
		DGV_CampaignItems.AllowUserToResizeRows = false;
		DGV_CampaignItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_CampaignItems.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_CampaignItems.BorderStyle = BorderStyle.Fixed3D;
		DGV_CampaignItems.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_CampaignItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_CampaignItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_CampaignItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_CampaignItems.Columns.AddRange(Column1, Column2, ScenarioID, ChangeScenID);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_CampaignItems.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_CampaignItems.EditMode = DataGridViewEditMode.EditOnEnter;
		DGV_CampaignItems.EnableHeadersVisualStyles = false;
		DGV_CampaignItems.GridColor = SystemColors.ControlText;
		DGV_CampaignItems.Location = new Point(2, 28);
		DGV_CampaignItems.MultiSelect = false;
		DGV_CampaignItems.Name = "DGV_CampaignItems";
		DGV_CampaignItems.RowHeadersVisible = false;
		DGV_CampaignItems.RowHeadersWidth = 10;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_CampaignItems.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_CampaignItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_CampaignItems.Size = new Size(905, 376);
		DGV_CampaignItems.TabIndex = 9;
		Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Column1.HeaderText = "名称";
		Column1.Name = "Column1";
		Column1.ReadOnly = true;
		Column1.Width = 58;
		Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Column2.HeaderText = "通过分数";
		Column2.Name = "Column2";
		Column2.ReadOnly = true;
		Column2.Width = 84;
		ScenarioID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		ScenarioID.HeaderText = "想定ID";
		ScenarioID.Name = "ScenarioID";
		ScenarioID.ReadOnly = true;
		ChangeScenID.HeaderText = "更改ID";
		ChangeScenID.Name = "ChangeScenID";
		ChangeScenID.Text = "更改ID";
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[8] { TSB_AddScenario, TSB_AddAttachment, TSB_RemoveSelected, TSB_MoveUp, TSB_MoveDown, TSB_Description, TSB_CampaignEnding, TSB_Save });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(907, 25);
		ToolStrip1.TabIndex = 10;
		ToolStrip1.Text = "ToolStrip1";
		TSB_AddScenario.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddScenario.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddScenario.ImageTransparentColor = Color.Magenta;
		TSB_AddScenario.Name = "TSB_AddScenario";
		TSB_AddScenario.Size = new Size(81, 22);
		TSB_AddScenario.Text = "添加想定";
		TSB_AddAttachment.BackColor = Color.FromArgb(60, 63, 65);
		TSB_AddAttachment.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_AddAttachment.ImageTransparentColor = Color.Magenta;
		TSB_AddAttachment.Name = "TSB_AddAttachment";
		TSB_AddAttachment.Size = new Size(99, 22);
		TSB_AddAttachment.Text = "添加附件";
		TSB_RemoveSelected.BackColor = Color.FromArgb(60, 63, 65);
		TSB_RemoveSelected.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_RemoveSelected.ImageTransparentColor = Color.Magenta;
		TSB_RemoveSelected.Name = "TSB_RemoveSelected";
		TSB_RemoveSelected.Size = new Size(101, 22);
		TSB_RemoveSelected.Text = "删除选定";
		TSB_MoveUp.BackColor = Color.FromArgb(60, 63, 65);
		TSB_MoveUp.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_MoveUp.Image = componentResourceManager.GetObject("TSB_MoveUp.Image");
		TSB_MoveUp.ImageTransparentColor = Color.Magenta;
		TSB_MoveUp.Name = "TSB_MoveUp";
		TSB_MoveUp.Size = new Size(75, 22);
		TSB_MoveUp.Text = "上移";
		TSB_MoveDown.BackColor = Color.FromArgb(60, 63, 65);
		TSB_MoveDown.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_MoveDown.Image = componentResourceManager.GetObject("TSB_MoveDown.Image");
		TSB_MoveDown.ImageTransparentColor = Color.Magenta;
		TSB_MoveDown.Name = "TSB_MoveDown";
		TSB_MoveDown.Size = new Size(91, 22);
		TSB_MoveDown.Text = "下移";
		TSB_Description.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Description.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Description.Image = componentResourceManager.GetObject("TSB_Description.Image");
		TSB_Description.ImageTransparentColor = Color.Magenta;
		TSB_Description.Name = "TSB_Description";
		TSB_Description.Size = new Size(124, 22);
		TSB_Description.Text = "标题+描述";
		TSB_CampaignEnding.BackColor = Color.FromArgb(60, 63, 65);
		TSB_CampaignEnding.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_CampaignEnding.Image = componentResourceManager.GetObject("TSB_CampaignEnding.Image");
		TSB_CampaignEnding.ImageTransparentColor = Color.Magenta;
		TSB_CampaignEnding.Name = "TSB_CampaignEnding";
		TSB_CampaignEnding.Size = new Size(88, 22);
		TSB_CampaignEnding.Text = "结束文本";
		TSB_Save.BackColor = Color.FromArgb(60, 63, 65);
		TSB_Save.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_Save.Image = componentResourceManager.GetObject("TSB_Save.Image");
		TSB_Save.ImageTransparentColor = Color.Magenta;
		TSB_Save.Name = "TSB_Save";
		TSB_Save.Size = new Size(109, 22);
		TSB_Save.Text = "保存战役";
		TS_PassScore.AutoSize = false;
		TS_PassScore.BackColor = Color.FromArgb(60, 63, 65);
		TS_PassScore.Dock = DockStyle.Bottom;
		TS_PassScore.ForeColor = Color.FromArgb(220, 220, 220);
		TS_PassScore.GripStyle = ToolStripGripStyle.Hidden;
		TS_PassScore.Items.AddRange(new ToolStripItem[3] { TSL_PassScore, TSTB_PassScore, TSL_SetScore });
		TS_PassScore.Location = new Point(0, 407);
		TS_PassScore.Name = "TS_PassScore";
		TS_PassScore.Padding = new Padding(5, 0, 1, 0);
		TS_PassScore.Size = new Size(907, 25);
		TS_PassScore.TabIndex = 12;
		TS_PassScore.Text = "ToolStrip2";
		TSL_PassScore.BackColor = Color.FromArgb(60, 63, 65);
		TSL_PassScore.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_PassScore.Name = "TSL_PassScore";
		TSL_PassScore.Size = new Size(160, 22);
		TSL_PassScore.Text = "选定的想定通过分数：";
		TSTB_PassScore.BackColor = Color.FromArgb(60, 63, 65);
		TSTB_PassScore.ForeColor = Color.FromArgb(220, 220, 220);
		TSTB_PassScore.Name = "TSTB_PassScore";
		TSTB_PassScore.Size = new Size(100, 25);
		TSL_SetScore.BackColor = Color.FromArgb(60, 63, 65);
		TSL_SetScore.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSL_SetScore.ForeColor = Color.FromArgb(220, 220, 220);
		TSL_SetScore.Image = componentResourceManager.GetObject("TSL_SetScore.Image");
		TSL_SetScore.ImageTransparentColor = Color.Magenta;
		TSL_SetScore.Name = "TSL_SetScore";
		TSL_SetScore.Size = new Size(30, 22);
		TSL_SetScore.Text = "设置";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(907, 432);
		base.Controls.Add(DGV_CampaignItems);
		base.Controls.Add(TS_PassScore);
		base.Controls.Add(ToolStrip1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CampaignEditorWindow";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "战役编辑器";
		((ISupportInitialize)DGV_CampaignItems).EndInit();
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		TS_PassScore.ResumeLayout(performLayout: false);
		TS_PassScore.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] reponseInvocation = m_ReponseInvocation;
		Keys[] array = reponseInvocation;
		foreach (Keys keys in array)
		{
			if (keyData == keys)
			{
				Close();
				return true;
			}
		}
		return false;
	}

	private void UpdateContext()
	{
		object obj = null;
		if (DGV_CampaignItems.SelectedRows.Count > 0)
		{
			obj = RuntimeHelpers.GetObjectValue(DGV_CampaignItems.SelectedRows[0].Tag);
		}
		DGV_CampaignItems.Rows.Clear();
		foreach (Campaign.CampaignItem campaignItem in theCampaign.CampaignItems)
		{
			DataGridViewRow dataGridViewRow = new DataGridViewRow();
			dataGridViewRow.ReadOnly = false;
			dataGridViewRow.CreateCells(DGV_CampaignItems);
			Type type = campaignItem.GetType();
			if (type == typeof(Campaign.ScenarioRecord))
			{
				dataGridViewRow.Cells[0].Value = "想定：" + campaignItem.Name;
				dataGridViewRow.Cells[1].Value = ((Campaign.ScenarioRecord)campaignItem).PassScore;
				dataGridViewRow.Cells[2].Value = ((Campaign.ScenarioRecord)campaignItem).ID;
			}
			else if (type == typeof(Campaign.AttachmentRecord))
			{
				dataGridViewRow.Cells[0].Value = "附件：" + campaignItem.Name;
				dataGridViewRow.Cells[1].Value = "";
			}
			dataGridViewRow.Tag = campaignItem;
			DGV_CampaignItems.Rows.Add(dataGridViewRow);
		}
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)))
		{
			return;
		}
		IEnumerator enumerator2 = null;
		try
		{
			enumerator2 = ((IEnumerable)DGV_CampaignItems.Rows).GetEnumerator();
			while (enumerator2.MoveNext())
			{
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)enumerator2.Current;
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dataGridViewRow2.Tag)) && obj == dataGridViewRow2.Tag)
				{
					dataGridViewRow2.Selected = true;
					break;
				}
			}
		}
		finally
		{
			if (enumerator2 is IDisposable)
			{
				(enumerator2 as IDisposable).Dispose();
			}
		}
	}

	private void InsertContext(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		Hide();
	}

	private void PrepareContext(object sender, EventArgs e)
	{
		ForgotContext().Filter = "Command 想定文件 (*.scen)|*.scen";
		if (ForgotContext().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			ScenContainer scenContainer = ScenContainer.LoadFromFile(ForgotContext().FileName);
			string string_ = null;
			Scenario scenarioObject = scenContainer.GetScenarioObject(ref string_, null, bool_0: false);
			scenarioObject.CampaignID = theCampaign.ID;
			LoadSave.SaveScenario(scenarioObject, scenarioObject.Sides_ReadOnly[0], ForgotContext().FileName, bool_0: false);
			Campaign.ScenarioRecord scenarioRecord = new Campaign.ScenarioRecord();
			scenarioRecord.Name = scenarioObject.Title;
			scenarioRecord.ID = scenarioObject.ObjectID;
			scenarioRecord.FileName = Path.GetFileName(ForgotContext().FileName);
			theCampaign.CampaignItems.Add(scenarioRecord);
			UpdateContext();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("无法加载所选想定。错误是：" + ex2.Message, "Error");
			ProjectData.ClearProjectError();
		}
	}

	private void ReflectContext(object sender, EventArgs e)
	{
		if (DGV_CampaignItems.SelectedRows.Count <= 0)
		{
			return;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = DGV_CampaignItems.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
				theCampaign.CampaignItems.Remove((Campaign.CampaignItem)NewLateBinding.LateGet(objectValue, null, "Tag", new object[0], null, null, null));
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		UpdateContext();
	}

	private void VisitContext(object sender, EventArgs e)
	{
		if (DGV_CampaignItems.SelectedRows.Count == 0)
		{
			return;
		}
		if (DGV_CampaignItems.SelectedRows.Count <= 1)
		{
			Campaign.CampaignItem item = (Campaign.CampaignItem)DGV_CampaignItems.SelectedRows[0].Tag;
			int num = theCampaign.CampaignItems.IndexOf(item);
			if (num != 0)
			{
				theCampaign.CampaignItems.Remove(item);
				theCampaign.CampaignItems.Insert(num - 1, item);
				UpdateContext();
			}
		}
		else
		{
			DarkMessageBox.ShowError("一次只能重新安排一个项目", "一次一个项目！");
		}
	}

	private void RestartContext(object sender, EventArgs e)
	{
		if (DGV_CampaignItems.SelectedRows.Count == 0)
		{
			return;
		}
		if (DGV_CampaignItems.SelectedRows.Count <= 1)
		{
			Campaign.CampaignItem item = (Campaign.CampaignItem)DGV_CampaignItems.SelectedRows[0].Tag;
			int num = theCampaign.CampaignItems.IndexOf(item);
			if (num != theCampaign.CampaignItems.Count - 1)
			{
				theCampaign.CampaignItems.Remove(item);
				theCampaign.CampaignItems.Insert(num + 1, item);
				UpdateContext();
			}
		}
		else
		{
			DarkMessageBox.ShowError("一次只能重新安排一个项目", "一次一个项目！");
		}
	}

	private void TestContext(object sender, EventArgs e)
	{
		if (Information.IsNothing(CampaignFileName))
		{
			RegisterContext().Filter = "Command 战役文件 (*.campaign)|*.campaign";
			if (RegisterContext().ShowDialog() == DialogResult.OK)
			{
				theCampaign.Save(RegisterContext().FileName);
				CampaignFileName = RegisterContext().FileName;
			}
		}
		else
		{
			theCampaign.Save(CampaignFileName);
		}
	}

	private void StopContext(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			UpdateContext();
		}
	}

	private void CancelContext(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.Title = theCampaign.Name;
		ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.Description = theCampaign.Description;
		if (ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.ShowDialog() == DialogResult.OK)
		{
			theCampaign.Name = ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.Title;
			theCampaign.Description = ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.Description;
		}
	}

	private void VerifyContext(object sender, EventArgs e)
	{
		if (DGV_CampaignItems.SelectedRows.Count != 0)
		{
			Campaign.CampaignItem campaignItem = (Campaign.CampaignItem)DGV_CampaignItems.SelectedRows[0].Tag;
			if ((object)campaignItem.GetType() == typeof(Campaign.ScenarioRecord))
			{
				TS_PassScore.Visible = true;
				TSTB_PassScore.Text = Conversions.ToString(((Campaign.ScenarioRecord)campaignItem).PassScore);
			}
			else
			{
				TS_PassScore.Visible = false;
			}
		}
	}

	private void ListContext(object sender, EventArgs e)
	{
		if (ItemExporter.ConnectInterruptibleTemplate.StopInterruptibleBase().ShowDialog() != DialogResult.OK)
		{
			return;
		}
		foreach (ScenAttachmentObject selectedSAO in ItemExporter.ConnectInterruptibleTemplate.StopInterruptibleBase().SelectedSAOs)
		{
			Campaign.AttachmentRecord attachmentRecord = new Campaign.AttachmentRecord();
			attachmentRecord.Name = selectedSAO.Name;
			attachmentRecord.ID = selectedSAO.ObjectID;
			theCampaign.CampaignItems.Add(attachmentRecord);
		}
		if (ItemExporter.ConnectInterruptibleTemplate.StopInterruptibleBase().SelectedSAOs.Count > 0)
		{
			UpdateContext();
		}
	}

	private void ResolveContext(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.Title = "结束文本";
		ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.Description = theCampaign.EndingText;
		if (ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.ShowDialog() == DialogResult.OK)
		{
			theCampaign.EndingText = ItemExporter.ConnectInterruptibleTemplate.TitleAndDescription.Description;
		}
	}

	private void PostContext(object sender, EventArgs e)
	{
		if (DGV_CampaignItems.SelectedRows.Count <= 0)
		{
			return;
		}
		IEnumerator enumerator = null;
		try
		{
			enumerator = DGV_CampaignItems.SelectedRows.GetEnumerator();
			while (enumerator.MoveNext())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, null, "tag", new object[0], null, null, null))) && (object)NewLateBinding.LateGet(objectValue, null, "tag", new object[0], null, null, null).GetType() == typeof(Campaign.ScenarioRecord))
				{
					((Campaign.ScenarioRecord)NewLateBinding.LateGet(objectValue, null, "Tag", new object[0], null, null, null)).PassScore = Conversions.ToInteger(TSTB_PassScore.Text);
					UpdateContext();
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
	}

	private void RunContext(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void StartContext(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex == -1 || (object)DGV_CampaignItems.Columns[e.ColumnIndex].CellType != typeof(DataGridViewButtonCell))
		{
			return;
		}
		Campaign.CampaignItem campaignItem = (Campaign.CampaignItem)DGV_CampaignItems.Rows[e.RowIndex].Tag;
		if (campaignItem.Type == Campaign.CampaignItemType.ScenarioRecord)
		{
			string text = Guid.NewGuid().ToString();
			Task.Factory.StartNew(delegate
			{
				string text2 = Path.Combine(Path.GetDirectoryName(Campaign.GetCampaignFilename(theCampaign.ID)), ((Campaign.ScenarioRecord)campaignItem).FileName);
				ScenContainer scenContainer = ScenContainer.LoadFromFile(text2);
				string string_ = null;
				Scenario scenarioObject = scenContainer.GetScenarioObject(ref string_, null, bool_0: false);
				scenarioObject.ObjectID = text;
				File.Move(text2, text2 + ".OLD");
				LoadSave.SaveScenario(scenarioObject, scenarioObject.GetCurrentSide(), text2, bool_0: false);
				File.Delete(text2 + ".OLD");
			});
			((Campaign.ScenarioRecord)campaignItem).ID = text;
			UpdateContext();
		}
	}
}
