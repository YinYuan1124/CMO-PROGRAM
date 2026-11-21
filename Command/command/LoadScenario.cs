using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Xml;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class LoadScenario : DarkSecondaryFormBase
{
	public enum DefaultAction : byte
	{
		LoadScenario,
		LoadSavedGame
	}

	[CompilerGenerated]
	private sealed class CodeMap
	{
		public string Local_FileExtension;

		internal bool ManageInterruptiblePage(string theFN)
		{
			return Operators.CompareString(Path.GetExtension(theFN), Local_FileExtension, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class TokenizerListenerMapping
	{
		public string Local_FileExtension;

		internal bool RevertInterruptiblePage(string theFN)
		{
			return Operators.CompareString(Path.GetExtension(theFN), Local_FileExtension, TextCompare: true) == 0;
		}
	}

	[CompilerGenerated]
	private sealed class HelperProcessResolver
	{
		public string Local_AutosavesPath;

		public LoadScenario Me;

		internal void CountInterruptibleRules()
		{
			if (File.Exists(Local_AutosavesPath + "\\Autosave.scen"))
			{
				Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = Local_AutosavesPath + "\\Autosave.scen";
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
				Me.Close();
			}
			else
			{
				DarkMessageBox.ShowError("No autosave file was found at the path" + Local_AutosavesPath + "\\Autosave.scen", "没有找到自动保存存档");
			}
		}
	}

	private IContainer _DicModel;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton m_ConsumerModel;

	[AccessedThroughProperty("TV_Scens")]
	[CompilerGenerated]
	private DarkTreeView facadeModel;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage2")]
	private TabPage propertyModel;

	[AccessedThroughProperty("TV_Saves")]
	[CompilerGenerated]
	private DarkTreeView importerModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _RepositoryModel;

	[AccessedThroughProperty("Label_Title")]
	[CompilerGenerated]
	private DarkLabel m_BridgeModel;

	[AccessedThroughProperty("PB_PercentComplete")]
	[CompilerGenerated]
	private DarkUIProgressBar invocationModel;

	[AccessedThroughProperty("Label_Loading")]
	[CompilerGenerated]
	private DarkLabel classModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel valueModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel tokenizerModel;

	[AccessedThroughProperty("PB_Complexity")]
	[CompilerGenerated]
	private DarkUIProgressBar m_WriterModel;

	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private DarkLabel watcherModel;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ScenOrder")]
	private DarkUIComboBox _ReponseModel;

	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage descriptorModel;

	[AccessedThroughProperty("ElementHost1")]
	[CompilerGenerated]
	private ElementHost poolModel;

	internal ScenarioSelectControl taskModel;

	[AccessedThroughProperty("Button_BrowseScenario")]
	[CompilerGenerated]
	private DarkUIButton m_FilterModel;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog testsModel;

	[AccessedThroughProperty("DeleteSelected_Button")]
	[CompilerGenerated]
	private DarkUIButton interpreterModel;

	[AccessedThroughProperty("Deleteselected")]
	[CompilerGenerated]
	private DarkUIButton containerModel;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadAutosaveButton")]
	private DarkUIButton _ComposerModel;

	[CompilerGenerated]
	[AccessedThroughProperty("LblScenSearch")]
	private DarkLabel m_ModelModel;

	[AccessedThroughProperty("txtScenSearch")]
	[CompilerGenerated]
	private DarkUITextBox m_AdvisorModel;

	private string _CustomerModel;

	public DefaultAction myDefaultAction;

	[AccessedThroughProperty("BW_LoadScen")]
	[CompilerGenerated]
	private BackgroundWorker m_SerializerModel;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_CheckContentTag")]
	private BackgroundWorker m_RefModel;

	private Scenario errorModel;

	private bool codeModel;

	private double _ConnectionModel;

	private bool _ContextModel;

	private string statusModel;

	private FileInfo m_ProccesorModel;

	private ScenContainer _StrategyModel;

	private string m_ConfigurationModel;

	private Bitmap tokenModel;

	private List<string> _IndexerModel;

	private string _ResolverModel;

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_ConsumerModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopAttribute;
			DarkUIButton consumerModel = m_ConsumerModel;
			if (consumerModel != null)
			{
				consumerModel.Click -= value2;
			}
			m_ConsumerModel = value;
			consumerModel = m_ConsumerModel;
			if (consumerModel != null)
			{
				consumerModel.Click += value2;
			}
		}
	}

	internal DarkTreeView TV_Scens
	{
		[CompilerGenerated]
		get
		{
			return facadeModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartAttribute;
			DarkTreeView.AfterNodeExpandDelegate value3 = AssetAttribute;
			DarkTreeView darkTreeView = facadeModel;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
				darkTreeView.AfterNodeExpand -= value3;
			}
			facadeModel = value;
			darkTreeView = facadeModel;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
				darkTreeView.AfterNodeExpand += value3;
			}
		}
	}

	[field: AccessedThroughProperty("TabControl1")]
	internal DarkUITabControl TabControl1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return propertyModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			propertyModel = value;
		}
	}

	internal DarkTreeView TV_Saves
	{
		[CompilerGenerated]
		get
		{
			return importerModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunAttribute;
			DarkTreeView.AfterNodeExpandDelegate value3 = PrintAttribute;
			DarkTreeView darkTreeView = importerModel;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
				darkTreeView.AfterNodeExpand -= value3;
			}
			importerModel = value;
			darkTreeView = importerModel;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
				darkTreeView.AfterNodeExpand += value3;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _RepositoryModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VisitAttribute;
			DarkUIButton repositoryModel = _RepositoryModel;
			if (repositoryModel != null)
			{
				repositoryModel.Click -= value2;
			}
			_RepositoryModel = value;
			repositoryModel = _RepositoryModel;
			if (repositoryModel != null)
			{
				repositoryModel.Click += value2;
			}
		}
	}

	internal DarkLabel Label_Title
	{
		[CompilerGenerated]
		get
		{
			return m_BridgeModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BridgeModel = value;
		}
	}

	internal DarkUIProgressBar PB_PercentComplete
	{
		[CompilerGenerated]
		get
		{
			return invocationModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			invocationModel = value;
		}
	}

	internal DarkLabel Label_Loading
	{
		[CompilerGenerated]
		get
		{
			return classModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			classModel = value;
		}
	}

	[field: AccessedThroughProperty("WebBrowser1")]
	internal WebBrowser WebBrowser1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return valueModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			valueModel = value;
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return tokenizerModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenizerModel = value;
		}
	}

	[field: AccessedThroughProperty("PB_Difficulty")]
	internal DarkUIProgressBar PB_Difficulty
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIProgressBar PB_Complexity
	{
		[CompilerGenerated]
		get
		{
			return m_WriterModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WriterModel = value;
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal DarkLabel Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return watcherModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			watcherModel = value;
		}
	}

	internal DarkUIComboBox CB_ScenOrder
	{
		[CompilerGenerated]
		get
		{
			return _ReponseModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyAttribute;
			DarkUIComboBox reponseModel = _ReponseModel;
			if (reponseModel != null)
			{
				reponseModel.SelectionChangeCommitted -= value2;
			}
			_ReponseModel = value;
			reponseModel = _ReponseModel;
			if (reponseModel != null)
			{
				reponseModel.SelectionChangeCommitted += value2;
			}
		}
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return descriptorModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			descriptorModel = value;
		}
	}

	internal ElementHost ElementHost1
	{
		[CompilerGenerated]
		get
		{
			return poolModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			poolModel = value;
		}
	}

	internal DarkUIButton Button_BrowseScenario
	{
		[CompilerGenerated]
		get
		{
			return m_FilterModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DefineAttribute;
			DarkUIButton filterModel = m_FilterModel;
			if (filterModel != null)
			{
				filterModel.Click -= value2;
			}
			m_FilterModel = value;
			filterModel = m_FilterModel;
			if (filterModel != null)
			{
				filterModel.Click += value2;
			}
		}
	}

	internal OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return testsModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsModel = value;
		}
	}

	internal DarkUIButton DeleteSelected_Button
	{
		[CompilerGenerated]
		get
		{
			return interpreterModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateAttribute;
			DarkUIButton darkUIButton = interpreterModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			interpreterModel = value;
			darkUIButton = interpreterModel;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Deleteselected
	{
		[CompilerGenerated]
		get
		{
			return containerModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			containerModel = value;
		}
	}

	internal DarkUIButton LoadAutosaveButton
	{
		[CompilerGenerated]
		get
		{
			return _ComposerModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishAttribute;
			DarkUIButton composerModel = _ComposerModel;
			if (composerModel != null)
			{
				composerModel.Click -= value2;
			}
			_ComposerModel = value;
			composerModel = _ComposerModel;
			if (composerModel != null)
			{
				composerModel.Click += value2;
			}
		}
	}

	internal DarkLabel LblScenSearch
	{
		[CompilerGenerated]
		get
		{
			return m_ModelModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ModelModel = value;
		}
	}

	internal DarkUITextBox txtScenSearch
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorModel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = AwakeAttribute;
			DarkUITextBox advisorModel = m_AdvisorModel;
			if (advisorModel != null)
			{
				advisorModel.TextChanged -= value2;
			}
			m_AdvisorModel = value;
			advisorModel = m_AdvisorModel;
			if (advisorModel != null)
			{
				advisorModel.TextChanged += value2;
			}
		}
	}

	public string SearchString
	{
		get
		{
			return _ResolverModel;
		}
		set
		{
			if (value != null)
			{
				_ResolverModel = value;
				CompareAttribute();
				DisableAttribute();
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker UpdateEvent()
	{
		return m_SerializerModel;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void InsertEvent(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = TestAttribute;
		RunWorkerCompletedEventHandler value2 = StopAttribute;
		BackgroundWorker serializerModel = m_SerializerModel;
		if (serializerModel != null)
		{
			serializerModel.DoWork -= value;
			serializerModel.RunWorkerCompleted -= value2;
		}
		m_SerializerModel = backgroundWorker_0;
		serializerModel = m_SerializerModel;
		if (serializerModel != null)
		{
			serializerModel.DoWork += value;
			serializerModel.RunWorkerCompleted += value2;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private BackgroundWorker ReflectEvent()
	{
		return m_RefModel;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private void VisitEvent(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = ResolveAttribute;
		RunWorkerCompletedEventHandler value2 = PostAttribute;
		BackgroundWorker refModel = m_RefModel;
		if (refModel != null)
		{
			refModel.DoWork -= value;
			refModel.RunWorkerCompleted -= value2;
		}
		m_RefModel = backgroundWorker_0;
		refModel = m_RefModel;
		if (refModel != null)
		{
			refModel.DoWork += value;
			refModel.RunWorkerCompleted += value2;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _DicModel != null)
			{
				_DicModel.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void FillAttribute()
	{
		Button2 = new DarkUIButton();
		TV_Scens = new DarkTreeView();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		TV_Saves = new DarkTreeView();
		TabPage3 = new TabPage();
		ElementHost1 = new ElementHost();
		taskModel = new ScenarioSelectControl();
		Button1 = new DarkUIButton();
		Label_Title = new DarkLabel();
		PB_PercentComplete = new DarkUIProgressBar();
		Label_Loading = new DarkLabel();
		WebBrowser1 = new WebBrowser();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		PB_Difficulty = new DarkUIProgressBar();
		PB_Complexity = new DarkUIProgressBar();
		Label4 = new DarkLabel();
		Label5 = new DarkLabel();
		CB_ScenOrder = new DarkUIComboBox();
		Button_BrowseScenario = new DarkUIButton();
		OpenFileDialog1 = new OpenFileDialog();
		DeleteSelected_Button = new DarkUIButton();
		Deleteselected = new DarkUIButton();
		LoadAutosaveButton = new DarkUIButton();
		LblScenSearch = new DarkLabel();
		txtScenSearch = new DarkUITextBox();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		TabPage2.SuspendLayout();
		TabPage3.SuspendLayout();
		SuspendLayout();
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(420, 566);
		Button2.Name = "Button2";
		Button2.RoundRadius = 0;
		Button2.Size = new Size(104, 23);
		Button2.TabIndex = 2;
		Button2.Text = "加载选中";
		TV_Scens.Dock = DockStyle.Fill;
		TV_Scens.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TV_Scens.Location = new Point(3, 3);
		TV_Scens.MaxDragChange = 20;
		TV_Scens.MouseWheelStep = 30;
		TV_Scens.Name = "TV_Scens";
		TV_Scens.Size = new Size(388, 490);
		TV_Scens.TabIndex = 5;
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Controls.Add(TabPage3);
		TabControl1.Cursor = Cursors.Hand;
		TabControl1.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TabControl1.ItemSize = new Size(80, 20);
		TabControl1.Location = new Point(12, 65);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(402, 524);
		TabControl1.TabIndex = 6;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(TV_Scens);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(394, 496);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "想定";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(TV_Saves);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(394, 496);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "保存的推演";
		TV_Saves.Dock = DockStyle.Fill;
		TV_Saves.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 161);
		TV_Saves.Location = new Point(3, 3);
		TV_Saves.MaxDragChange = 20;
		TV_Saves.MouseWheelStep = 30;
		TV_Saves.Name = "TV_Saves";
		TV_Saves.Size = new Size(388, 490);
		TV_Saves.TabIndex = 6;
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(ElementHost1);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(394, 496);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Steam Workshop";
		ElementHost1.Dock = DockStyle.Fill;
		ElementHost1.Location = new Point(3, 3);
		ElementHost1.Name = "ElementHost1";
		ElementHost1.Size = new Size(388, 490);
		ElementHost1.TabIndex = 0;
		ElementHost1.Text = "ElementHost1";
		ElementHost1.Child = taskModel;
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(914, 566);
		Button1.Name = "Button1";
		Button1.RoundRadius = 0;
		Button1.Size = new Size(82, 23);
		Button1.TabIndex = 9;
		Button1.Text = "取消";
		Label_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label_Title.AutoSize = true;
		Label_Title.Font = new Font("Arial", 12f, FontStyle.Bold);
		Label_Title.ForeColor = Color.Gainsboro;
		Label_Title.Location = new Point(419, 12);
		Label_Title.Name = "Label_Title";
		Label_Title.Size = new Size(113, 19);
		Label_Title.TabIndex = 10;
		Label_Title.Text = "想定标题";
		Label_Title.TextAlign = ContentAlignment.MiddleCenter;
		Label_Title.Visible = false;
		PB_PercentComplete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		PB_PercentComplete.BackColor = Color.Transparent;
		PB_PercentComplete.CustomForeColor = Color.Transparent;
		PB_PercentComplete.Font = new Font("Segoe UI", 9f);
		PB_PercentComplete.Location = new Point(480, 546);
		PB_PercentComplete.Maximum = 100;
		PB_PercentComplete.Name = "PB_PercentComplete";
		PB_PercentComplete.ShowProgressLines = true;
		PB_PercentComplete.ShowProgressValue = false;
		PB_PercentComplete.ShowText = false;
		PB_PercentComplete.Size = new Size(516, 12);
		PB_PercentComplete.TabIndex = 13;
		PB_PercentComplete.Value = 0;
		Label_Loading.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label_Loading.AutoSize = true;
		Label_Loading.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Loading.Location = new Point(420, 545);
		Label_Loading.Name = "Label_Loading";
		Label_Loading.Size = new Size(59, 15);
		Label_Loading.TabIndex = 14;
		Label_Loading.Text = "载入中...";
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.Location = new Point(423, 89);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(573, 450);
		WebBrowser1.TabIndex = 15;
		WebBrowser1.Visible = false;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.Gainsboro;
		Label1.Location = new Point(420, 45);
		Label1.Name = "Label1";
		Label1.Size = new Size(58, 15);
		Label1.TabIndex = 16;
		Label1.Text = "困难度：";
		Label1.Visible = false;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.Gainsboro;
		Label2.Location = new Point(646, 45);
		Label2.Name = "Label2";
		Label2.Size = new Size(71, 15);
		Label2.TabIndex = 17;
		Label2.Text = "复杂度：";
		Label2.Visible = false;
		PB_Difficulty.BackColor = Color.Transparent;
		PB_Difficulty.CustomForeColor = Color.Transparent;
		PB_Difficulty.Font = new Font("Segoe UI", 9f);
		PB_Difficulty.ForeColor = Color.FromArgb(0, 0, 0, 0);
		PB_Difficulty.Location = new Point(504, 45);
		PB_Difficulty.Maximum = 100;
		PB_Difficulty.Name = "PB_Difficulty";
		PB_Difficulty.ShowProgressLines = true;
		PB_Difficulty.ShowProgressValue = false;
		PB_Difficulty.ShowText = false;
		PB_Difficulty.Size = new Size(100, 16);
		PB_Difficulty.TabIndex = 19;
		PB_Difficulty.Value = 0;
		PB_Difficulty.Visible = false;
		PB_Complexity.BackColor = Color.Transparent;
		PB_Complexity.CustomForeColor = Color.Transparent;
		PB_Complexity.Font = new Font("Segoe UI", 9f);
		PB_Complexity.ForeColor = Color.FromArgb(0, 0, 0, 0);
		PB_Complexity.Location = new Point(722, 45);
		PB_Complexity.Maximum = 100;
		PB_Complexity.Name = "PB_Complexity";
		PB_Complexity.ShowProgressLines = true;
		PB_Complexity.ShowProgressValue = false;
		PB_Complexity.ShowText = false;
		PB_Complexity.Size = new Size(100, 16);
		PB_Complexity.TabIndex = 20;
		PB_Complexity.Value = 0;
		PB_Complexity.Visible = false;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.Gainsboro;
		Label4.Location = new Point(420, 65);
		Label4.Name = "Label4";
		Label4.Size = new Size(104, 15);
		Label4.TabIndex = 21;
		Label4.Text = "位置 / 设置：";
		Label4.Visible = false;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(12, 17);
		Label5.Name = "Label5";
		Label5.Size = new Size(108, 15);
		Label5.TabIndex = 23;
		Label5.Text = "排序想定：";
		CB_ScenOrder.BackColor = Color.Transparent;
		CB_ScenOrder.DrawMode = DrawMode.OwnerDrawFixed;
		CB_ScenOrder.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_ScenOrder.Font = new Font("Segoe UI", 7f);
		CB_ScenOrder.FormattingEnabled = true;
		CB_ScenOrder.Items.AddRange(new object[5] { "名称", "日期", "困难度", "复杂度", "修改日期（仅用于进度保存文件）" });
		CB_ScenOrder.Location = new Point(130, 12);
		CB_ScenOrder.Name = "CB_ScenOrder";
		CB_ScenOrder.Size = new Size(201, 21);
		CB_ScenOrder.TabIndex = 24;
		Button_BrowseScenario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_BrowseScenario.BackColor = Color.Transparent;
		Button_BrowseScenario.DialogResult = DialogResult.Cancel;
		Button_BrowseScenario.Font = new Font("Segoe UI", 10f);
		Button_BrowseScenario.ForeColor = SystemColors.Control;
		Button_BrowseScenario.Location = new Point(815, 566);
		Button_BrowseScenario.Name = "Button_BrowseScenario";
		Button_BrowseScenario.RoundRadius = 0;
		Button_BrowseScenario.Size = new Size(93, 23);
		Button_BrowseScenario.TabIndex = 25;
		Button_BrowseScenario.Text = "浏览...";
		OpenFileDialog1.FileName = "OpenFileDialog1";
		DeleteSelected_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DeleteSelected_Button.BackColor = Color.Transparent;
		DeleteSelected_Button.DialogResult = DialogResult.None;
		DeleteSelected_Button.Font = new Font("Segoe UI", 10f);
		DeleteSelected_Button.ForeColor = SystemColors.Control;
		DeleteSelected_Button.Location = new Point(696, 566);
		DeleteSelected_Button.Name = "DeleteSelected_Button";
		DeleteSelected_Button.RoundRadius = 0;
		DeleteSelected_Button.Size = new Size(113, 23);
		DeleteSelected_Button.TabIndex = 26;
		DeleteSelected_Button.Text = "删除所选";
		Deleteselected.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Deleteselected.BackColor = Color.Transparent;
		Deleteselected.DialogResult = DialogResult.None;
		Deleteselected.Font = new Font("Segoe UI", 10f);
		Deleteselected.ForeColor = SystemColors.Control;
		Deleteselected.Location = new Point(610, 566);
		Deleteselected.Name = "Deleteselected";
		Deleteselected.RoundRadius = 0;
		Deleteselected.Size = new Size(135, 23);
		Deleteselected.TabIndex = 26;
		Deleteselected.Text = "删除所选";
		LoadAutosaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LoadAutosaveButton.BackColor = Color.Transparent;
		LoadAutosaveButton.DialogResult = DialogResult.None;
		LoadAutosaveButton.Font = new Font("Segoe UI", 10f);
		LoadAutosaveButton.ForeColor = SystemColors.Control;
		LoadAutosaveButton.Location = new Point(530, 566);
		LoadAutosaveButton.Name = "LoadAutosaveButton";
		LoadAutosaveButton.RoundRadius = 0;
		LoadAutosaveButton.Size = new Size(135, 23);
		LoadAutosaveButton.TabIndex = 27;
		LoadAutosaveButton.Text = "选择自动保存";
		LblScenSearch.AutoSize = true;
		LblScenSearch.ForeColor = Color.FromArgb(220, 220, 220);
		LblScenSearch.Location = new Point(13, 39);
		LblScenSearch.Name = "LblScenSearch";
		LblScenSearch.Size = new Size(92, 15);
		LblScenSearch.TabIndex = 28;
		LblScenSearch.Text = "搜索想定：";
		txtScenSearch.AutoCompleteCustomSource = null;
		txtScenSearch.AutoCompleteMode = AutoCompleteMode.None;
		txtScenSearch.AutoCompleteSource = AutoCompleteSource.None;
		txtScenSearch.BackColor = Color.Transparent;
		txtScenSearch.ForeColor = Color.FromArgb(189, 189, 189);
		txtScenSearch.Image = null;
		txtScenSearch.Lines = null;
		txtScenSearch.Location = new Point(130, 40);
		txtScenSearch.MaxLength = 32767;
		txtScenSearch.Multiline = false;
		txtScenSearch.Name = "txtScenSearch";
		txtScenSearch.ReadOnly = false;
		txtScenSearch.ScrollBars = ScrollBars.None;
		txtScenSearch.SelectionStart = 0;
		txtScenSearch.Size = new Size(284, 19);
		txtScenSearch.TabIndex = 29;
		txtScenSearch.TextAlign = HorizontalAlignment.Left;
		txtScenSearch.UseSystemPasswordChar = false;
		txtScenSearch.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1008, 601);
		base.Controls.Add(txtScenSearch);
		base.Controls.Add(LblScenSearch);
		base.Controls.Add(LoadAutosaveButton);
		base.Controls.Add(DeleteSelected_Button);
		base.Controls.Add(Button_BrowseScenario);
		base.Controls.Add(PB_Complexity);
		base.Controls.Add(PB_Difficulty);
		base.Controls.Add(Label1);
		base.Controls.Add(Label2);
		base.Controls.Add(Label4);
		base.Controls.Add(CB_ScenOrder);
		base.Controls.Add(Label5);
		base.Controls.Add(WebBrowser1);
		base.Controls.Add(Label_Loading);
		base.Controls.Add(PB_PercentComplete);
		base.Controls.Add(Button1);
		base.Controls.Add(TabControl1);
		base.Controls.Add(Button2);
		base.Controls.Add(Label_Title);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "LoadScenario";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "加载想定";
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage2.ResumeLayout(performLayout: false);
		TabPage3.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public LoadScenario()
	{
		base.FormClosing += PrepareAttribute;
		base.Load += ReflectAttribute;
		base.KeyDown += CancelAttribute;
		base.FormClosed += ListAttribute;
		InsertEvent(new BackgroundWorker());
		VisitEvent(new BackgroundWorker());
		_ResolverModel = "";
		FillAttribute();
		tokenValue = false;
		_IndexerValue = true;
		taskModel.VM.LoadScenarioForm = this;
	}

	private bool CalculateAttribute(WebBrowser webBrowser_0, string string_0, string string_1)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		if (string_0.Contains("[LOADDOC]"))
		{
			int num = Strings.InStr(string_0, "[LOADDOC]", CompareMethod.Text) + "[LOADDOC]".Length - 1;
			int num2 = Strings.InStr(string_0, "[/LOADDOC]", CompareMethod.Text);
			string path = string_0.Substring(num, string_0.Length - num - (string_0.Length - num2 + 1));
			if (FileExistsNative.FileExistsFast(Path.Combine(string_1, path)))
			{
				webBrowser_0.Navigate(Path.Combine(string_1, path));
				webBrowser_0.Visible = true;
				return true;
			}
			string string_2 = Scenario.QueryScenario_ScenXML(_StrategyModel.GetScenarioObject_AsXML(), "CampaignID");
			Campaign campaignByID = Campaign.GetCampaignByID(GameGeneral.ScenariosRootPath, string_2);
			if (Information.IsNothing(campaignByID))
			{
				return false;
			}
			webBrowser_0.Navigate(Path.Combine(campaignByID.FolderPath, path));
			webBrowser_0.Visible = true;
			return true;
		}
		return false;
	}

	private void PopAttribute(object sender, EventArgs e)
	{
		MainForm.KillAllRendering = true;
		if (!Information.IsNothing(_StrategyModel))
		{
			Button2.Enabled = false;
			if (Client.CurrentGame.Status == Game._GameStatus.Running)
			{
				Client.CurrentGame.Pause();
			}
			codeModel = false;
			errorModel = null;
			ItemExporter.ConnectInterruptibleTemplate.ORBAT?.ReleaseReferences();
			UpdateEvent().RunWorkerAsync();
			Label_Loading.Visible = true;
			PB_PercentComplete.Visible = true;
			while (UpdateEvent().IsBusy)
			{
				Application.DoEvents();
				PB_PercentComplete.Value = (int)Math.Round(_ConnectionModel * 100.0);
				Thread.Sleep(50);
			}
			if (!Information.IsNothing(errorModel))
			{
				Client.HandleScenarioLoaded(errorModel, _CustomerModel);
				Close();
			}
			Button2.Enabled = true;
			Label_Loading.Visible = false;
			PB_PercentComplete.Visible = false;
			MainForm.KillAllRendering = false;
		}
	}

	private void InstantiateAttribute(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(_CustomerModel) && Operators.CompareString(Path.GetExtension(_CustomerModel), ".save", TextCompare: true) == 0)
		{
			File.Delete(_CustomerModel);
			_CustomerModel = null;
			DisableAttribute();
		}
	}

	private List<string> CreateAttribute(IEnumerable<string> ienumerable_0)
	{
		List<string> result = new List<string>();
		switch (CB_ScenOrder.SelectedIndex)
		{
		case 0:
			result = ienumerable_0.OrderBy((string theKey) => theKey, new nvSorter()).ToList();
			break;
		case 1:
			result = ienumerable_0.OrderBy((string theKey) => ScenContainer.QueryScenContainer(theKey, "ScenDate")).ToList();
			break;
		case 2:
			result = ienumerable_0.OrderBy((string theKey) => ScenContainer.QueryScenContainer(theKey, "Difficulty")).ToList();
			break;
		case 3:
			result = ienumerable_0.OrderBy((string theKey) => ScenContainer.QueryScenContainer(theKey, "Complexity")).ToList();
			break;
		case 4:
			result = _IndexerModel;
			break;
		}
		return result;
	}

	private void CompareAttribute()
	{
		TV_Scens.Nodes.Clear();
		TV_Scens.ShowIcons = false;
		List<string> list = Directory.GetDirectories(GameGeneral.ScenariosRootPath).ToList();
		string text = string.Empty;
		if (Licensing.GetModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
		{
			foreach (string item in list)
			{
				if (item.EndsWith("独立想定"))
				{
					text = item;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				list.Remove(text);
				list.Insert(0, text);
			}
		}
		text = string.Empty;
		foreach (string item2 in list)
		{
			if (item2.EndsWith("Tutorials"))
			{
				text = item2;
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			list.Remove(text);
			list.Insert(0, text);
		}
		foreach (string item3 in list)
		{
			if (UpdateAttribute(item3, ".scen"))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Localization.ScenarioDisplayName(item3, true));
				TV_Scens.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item3;
				if ((Directory.GetDirectories(item3).Count() > 0) | (Directory.GetFiles(item3).Count() > 0))
				{
					darkTreeNode.Nodes.Add(new DarkTreeNode("virtual"));
				}
				string text2 = InsertAttribute(item3);
				if (!string.IsNullOrEmpty(text2) && !Licensing.IsUserLicensedForThisContent(Licensing.GetContentTagFromCampaignID(text2)))
				{
					TV_Scens.ShowIcons = true;
					darkTreeNode.Icon = tokenModel;
				}
			}
		}
		List<string> ienumerable_ = CreateAttribute(from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
			where Operators.CompareString(Path.GetExtension(theFN), ".scen", TextCompare: true) == 0
			select theFN);
		foreach (string item4 in CreateAttribute(ienumerable_))
		{
			if (ReadAttribute(item4))
			{
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(Localization.ScenarioDisplayName(item4, false));
				TV_Scens.Nodes.Add(darkTreeNode2);
				darkTreeNode2.Tag = item4;
			}
		}
	}

	private bool ReadAttribute(string string_0)
	{
		return string_0.ToUpper().TrimStart().TrimEnd()
			.Replace(" ", "")
			.Contains(SearchString.ToUpper().TrimStart().TrimEnd()
				.Replace(" ", ""));
	}

	private void DisableAttribute()
	{
		TV_Saves.Nodes.Clear();
		TV_Saves.ShowIcons = false;
		string[] directories = Directory.GetDirectories(GameGeneral.ScenariosRootPath);
		string[] array = directories;
		foreach (string text in array)
		{
			if (UpdateAttribute(text, ".save"))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Path.GetFileName(text));
				TV_Saves.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = text;
				if ((Directory.GetDirectories(text).Count() > 0) | (Directory.GetFiles(text).Count() > 0))
				{
					darkTreeNode.Nodes.Add(new DarkTreeNode("virtual"));
				}
				string text2 = InsertAttribute(text);
				if (!string.IsNullOrEmpty(text2) && !Licensing.IsUserLicensedForThisContent(Licensing.GetContentTagFromCampaignID(text2)))
				{
					TV_Saves.ShowIcons = true;
					darkTreeNode.Icon = tokenModel;
				}
			}
		}
		Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
		foreach (string item in from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
			where Operators.CompareString(Path.GetExtension(theFN), ".save", TextCompare: true) == 0
			select theFN)
		{
			dictionary.Add(item, FileSystem.FileDateTime(item));
		}
		_IndexerModel = dictionary.OrderByDescending(delegate(KeyValuePair<string, DateTime> tPair)
		{
			KeyValuePair<string, DateTime> keyValuePair2 = tPair;
			return keyValuePair2.Value;
		}).Select(delegate(KeyValuePair<string, DateTime> tPair)
		{
			KeyValuePair<string, DateTime> keyValuePair = tPair;
			return keyValuePair.Key;
		}).ToList();
		foreach (string item2 in CreateAttribute(from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
			where Operators.CompareString(Path.GetExtension(theFN), ".save", TextCompare: true) == 0
			select theFN))
		{
			if (ReadAttribute(item2))
			{
				statusModel = Path.GetFileName(item2);
				m_ProccesorModel = new FileInfo(item2);
				statusModel = "[" + m_ProccesorModel.LastWriteTime.ToShortDateString() + " " + m_ProccesorModel.LastWriteTime.ToShortTimeString() + "] " + statusModel;
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(statusModel);
				TV_Saves.Nodes.Add(darkTreeNode2);
				darkTreeNode2.Tag = item2;
			}
		}
	}

	private bool UpdateAttribute(string string_0, string string_1)
	{
		string[] files = Directory.GetFiles(string_0);
		string[] array = files;
		foreach (string text in array)
		{
			if (ReadAttribute(text))
			{
				if (Operators.CompareString(string_1, "Both", TextCompare: true) == 0 && (text.EndsWith(".scen") || text.EndsWith(".save")))
				{
					return true;
				}
				if (Operators.CompareString(string_1, ".save", TextCompare: true) == 0 && text.EndsWith(".save"))
				{
					return true;
				}
				if (Operators.CompareString(string_1, ".scen", TextCompare: true) == 0 && text.EndsWith(".scen"))
				{
					return true;
				}
			}
		}
		string[] directories = Directory.GetDirectories(string_0);
		string[] array2 = directories;
		foreach (string string_2 in array2)
		{
			if (UpdateAttribute(string_2, string_1))
			{
				return true;
			}
		}
		return false;
	}

	private string InsertAttribute(string string_0)
	{
		string[] files = Directory.GetFiles(string_0);
		string[] array = files;
		foreach (string text in array)
		{
			if (text.EndsWith(".campaign"))
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(text);
				return xmlDocument.ChildNodes[1].ChildNodes[0].InnerText;
			}
		}
		return null;
	}

	private void PrepareAttribute(object sender, FormClosingEventArgs e)
	{
		errorModel = null;
		_StrategyModel = null;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void ReflectAttribute(object sender, EventArgs e)
	{
		Label_Title.ForeColor = Color.Gainsboro;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = false;
		CB_ScenOrder.SelectedIndex = 0;
		Label_Loading.Visible = false;
		PB_PercentComplete.Visible = false;
		TabControl1.SelectedIndex = (int)myDefaultAction;
		WebBrowser1.Visible = false;
		tokenModel = (Bitmap)Image.FromFile(ItemExporter.RevertInterruptibleMap.Info.DirectoryPath + "\\Symbols\\Lock.png");
		CompareAttribute();
		DisableAttribute();
	}

	private void VisitAttribute(object sender, EventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.Enabled = true;
		Close();
	}

	private void RestartAttribute(DarkTreeNode darkTreeNode_0)
	{
		darkTreeNode_0.Nodes.Clear();
		string path = darkTreeNode_0.Tag.ToString();
		string Local_FileExtension = "";
		switch (TabControl1.SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case 1:
			Local_FileExtension = ".save";
			break;
		case 0:
			Local_FileExtension = ".scen";
			break;
		}
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (string item in Directory.GetDirectories(path).OrderBy((string theFN) => theFN, new nvSorter()).ToList())
		{
			if (UpdateAttribute(item, Local_FileExtension))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Localization.ScenarioDisplayName(item, true));
				list.Add(darkTreeNode);
				darkTreeNode.Tag = item;
				if ((Directory.GetDirectories(item).Length != 0) | (Directory.GetFiles(item).Length != 0))
				{
					darkTreeNode.Nodes.Add(new DarkTreeNode("virtual"));
				}
			}
		}
		foreach (string item2 in CreateAttribute(from theFN in Directory.GetFiles(path)
			where Operators.CompareString(Path.GetExtension(theFN), Local_FileExtension, TextCompare: true) == 0
			select theFN))
		{
			if (ReadAttribute(item2))
			{
				statusModel = Path.GetFileNameWithoutExtension(item2);
				if (Operators.CompareString(Local_FileExtension, ".scen", TextCompare: true) == 0)
				{
					statusModel = Localization.ScenarioDisplayName(item2, false);
				}
				if (Operators.CompareString(Local_FileExtension, ".save", TextCompare: true) == 0)
				{
					m_ProccesorModel = new FileInfo(item2);
					statusModel = "[" + m_ProccesorModel.LastWriteTime.ToShortDateString() + " " + m_ProccesorModel.LastWriteTime.ToShortTimeString() + "] " + statusModel + ".save";
				}
				DarkTreeNode darkTreeNode2 = new DarkTreeNode(statusModel);
				list.Add(darkTreeNode2);
				darkTreeNode2.Tag = item2;
			}
		}
		darkTreeNode_0.Nodes.AddRange(list);
	}

	private void TestAttribute(object sender, DoWorkEventArgs e)
	{
		try
		{
			string scenarioObject_AsXML = _StrategyModel.GetScenarioObject_AsXML();
			CMANO.HandleScenarioChanging();
			m_ConfigurationModel = Scenario.QueryScenario_ScenXML(scenarioObject_AsXML, "ContentTag");
			if (string.IsNullOrEmpty(m_ConfigurationModel))
			{
				m_ConfigurationModel = "";
			}
			if (Licensing.IsUserLicensedForThisContent(m_ConfigurationModel))
			{
				_ContextModel = true;
				Scenario scenario_ = Scenario.FromXmlText(scenarioObject_AsXML, ref Client.authenticationClass, delegate(double double_0)
				{
					_ConnectionModel = double_0;
				});
				if (Information.IsNothing(scenario_))
				{
					_ContextModel = true;
					return;
				}
				Client.ConfigureCommandCoreSettings(ref scenario_);
				if (scenario_.ScenAttachments.Count > 0)
				{
					AttachmentRepoManager.MoveAttachmentsToLocalRepo(scenario_, _CustomerModel);
				}
				if (!Path.GetFileName(_CustomerModel).StartsWith("Autosave"))
				{
					scenario_.FileName = Path.GetFileName(_CustomerModel);
					scenario_.FileNamePath = Path.GetDirectoryName(_CustomerModel);
				}
				errorModel = scenario_;
			}
			else
			{
				_ContextModel = false;
			}
		}
		catch (DBFileNotFoundException ex)
		{
			ProjectData.SetProjectError(ex);
			DarkMessageBox.ShowError(ex.Message + " " + Client.authenticationClass, "Error");
			_ContextModel = true;
			ProjectData.ClearProjectError();
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			DarkMessageBox.ShowError(ex2.Message + " " + Client.authenticationClass, "Error");
			ex2?.Data.Add("Error at 101159", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			_ContextModel = true;
			throw;
		}
	}

	private void StopAttribute(object sender, RunWorkerCompletedEventArgs e)
	{
		if (_ContextModel)
		{
			codeModel = true;
			return;
		}
		ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent(m_ConfigurationModel) };
		ItemExporter.ConnectInterruptibleTemplate.InsufficientLicenseWindow.Show();
	}

	private void CancelAttribute(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
	}

	private void VerifyAttribute(object sender, EventArgs e)
	{
		new List<DarkTreeNode>();
		string Local_FileExtension = "";
		DarkTreeView darkTreeView = null;
		switch (TabControl1.SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case 0:
			darkTreeView = TV_Scens;
			Local_FileExtension = ".scen";
			break;
		case 1:
			darkTreeView = TV_Saves;
			Local_FileExtension = ".save";
			break;
		case 2:
			taskModel.VM.OrderingChange(CB_ScenOrder.SelectedIndex);
			return;
		}
		foreach (DarkTreeNode item in InterpreterObjectListener.PrintInterruptibleTask(darkTreeView).ToList())
		{
			if (item.Expanded)
			{
				RestartAttribute(item);
			}
		}
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		foreach (DarkTreeNode node in darkTreeView.Nodes)
		{
			if (node.Nodes.Count == 0)
			{
				list.Add(node);
			}
		}
		foreach (DarkTreeNode item2 in list)
		{
			darkTreeView.Nodes.Remove(item2);
		}
		foreach (string item3 in CreateAttribute(from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
			where Operators.CompareString(Path.GetExtension(theFN), Local_FileExtension, TextCompare: true) == 0
			select theFN))
		{
			statusModel = Path.GetFileName(item3);
			if (Operators.CompareString(Local_FileExtension, ".save", TextCompare: true) == 0)
			{
				m_ProccesorModel = new FileInfo(item3);
				statusModel = "[" + m_ProccesorModel.LastWriteTime.ToShortDateString() + " " + m_ProccesorModel.LastWriteTime.ToShortTimeString() + "] " + statusModel;
			}
			DarkTreeNode darkTreeNode = new DarkTreeNode(statusModel);
			darkTreeView.Nodes.Add(darkTreeNode);
			darkTreeNode.Tag = item3;
		}
	}

	private void ListAttribute(object sender, FormClosedEventArgs e)
	{
		errorModel = null;
	}

	private void ResolveAttribute(object sender, DoWorkEventArgs e)
	{
		if (!Information.IsNothing(_StrategyModel))
		{
			m_ConfigurationModel = Scenario.QueryScenario_ScenXML(_StrategyModel.GetScenarioObject_AsXML(), "ContentTag");
		}
	}

	private void PostAttribute(object sender, RunWorkerCompletedEventArgs e)
	{
		if (!Licensing.IsUserLicensedForThisContent(m_ConfigurationModel))
		{
			Label_Title.Text = "[未注册]" + Localization.ScenarioText(_CustomerModel, "Title", _StrategyModel.ScenTitle);
			Label_Title.ForeColor = Color.IndianRed;
		}
	}

	private void RunAttribute(object sender, EventArgs e)
	{
		if (TV_Saves.SelectedNodes.Count != 0)
		{
			string text = TV_Saves.SelectedNodes[0].Tag.ToString();
			if (Directory.Exists(text))
			{
				Label_Title.Visible = false;
				Label1.Visible = false;
				PB_Difficulty.Visible = false;
				Label2.Visible = false;
				PB_Complexity.Visible = false;
				Label4.Visible = false;
				WebBrowser1.Visible = false;
				DeleteSelected_Button.Visible = false;
			}
			else if (FileExistsNative.FileExistsFast(text))
			{
				Label_Title.Visible = true;
				Label1.Visible = true;
				PB_Difficulty.Visible = true;
				Label2.Visible = true;
				PB_Complexity.Visible = true;
				Label4.Visible = true;
				DeleteSelected_Button.Visible = true;
				LoadFromPath(text, TV_Saves.SelectedNodes[0].Tag.ToString());
			}
		}
	}

	private void StartAttribute(object sender, EventArgs e)
	{
		if (TV_Scens.SelectedNodes.Count != 0)
		{
			string text = TV_Scens.SelectedNodes[0].Tag.ToString();
			if (Directory.Exists(text))
			{
				Label_Title.Visible = false;
				Label1.Visible = false;
				PB_Difficulty.Visible = false;
				Label2.Visible = false;
				PB_Complexity.Visible = false;
				Label4.Visible = false;
				WebBrowser1.Visible = false;
				DeleteSelected_Button.Visible = false;
			}
			else if (FileExistsNative.FileExistsFast(text))
			{
				Label_Title.Visible = true;
				Label1.Visible = true;
				PB_Difficulty.Visible = true;
				Label2.Visible = true;
				PB_Complexity.Visible = true;
				Label4.Visible = true;
				WebBrowser1.Visible = true;
				DeleteSelected_Button.Visible = false;
				LoadFromPath(text, TV_Scens.SelectedNodes[0].Tag.ToString());
			}
		}
	}

	public void LoadFromPath(string string_0, string string_1)
	{
		try
		{
			_StrategyModel = ScenContainer.LoadFromFile(string_0);
			_CustomerModel = string_1;
			string localizedDescription = Localization.ScenarioText(_CustomerModel, "Description", _StrategyModel.ScenDescription);
			if (!CalculateAttribute(WebBrowser1, localizedDescription, Path.GetDirectoryName(_CustomerModel)))
			{
				InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, localizedDescription);
				WebBrowser1.Visible = true;
			}
			Label_Title.Text = Localization.ScenarioText(_CustomerModel, "Title", _StrategyModel.ScenTitle);
			Label_Title.ForeColor = Color.Gainsboro;
			if (!ReflectEvent().IsBusy)
			{
				ReflectEvent().RunWorkerAsync();
			}
			PB_Difficulty.Value = 20 * _StrategyModel.Difficulty;
			PB_Complexity.Value = 20 * _StrategyModel.Complexity;
			switch (_StrategyModel.Difficulty)
			{
			case 1:
				PB_Difficulty.CustomForeColor = Color.Green;
				break;
			case 2:
				PB_Difficulty.CustomForeColor = Color.LimeGreen;
				break;
			case 3:
				PB_Difficulty.CustomForeColor = Color.Yellow;
				break;
			case 4:
				PB_Difficulty.CustomForeColor = Color.Orange;
				break;
			case 5:
				PB_Difficulty.CustomForeColor = Color.Red;
				break;
			}
			switch (_StrategyModel.Complexity)
			{
			case 1:
				PB_Complexity.CustomForeColor = Color.Green;
				break;
			case 2:
				PB_Complexity.CustomForeColor = Color.LimeGreen;
				break;
			case 3:
				PB_Complexity.CustomForeColor = Color.Yellow;
				break;
			case 4:
				PB_Complexity.CustomForeColor = Color.Orange;
				break;
			case 5:
				PB_Complexity.CustomForeColor = Color.Red;
				break;
			}
			Label4.Text = "";
			if (!string.IsNullOrEmpty(_StrategyModel.ScenSetting))
			{
				Label4.Text = Localization.T("地点：", "Location:") + Localization.Translate(_StrategyModel.ScenSetting);
			}
			if (!string.IsNullOrEmpty(_StrategyModel.ScenSetting))
			{
				Label4.Text += "  --  ";
			}
			Label4.Text = Label4.Text + Localization.T("年份：", "Year:") + Conversions.ToString((int)_StrategyModel.ScenDate);
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				Client.SaveScenarioPath = string_0;
			}
			else
			{
				Client.SaveScenarioPath = null;
			}
			string text = _StrategyModel.ScenTitle;
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			char[] array = invalidFileNameChars;
			foreach (char c in array)
			{
				text = text.Replace(Conversions.ToString(c), "");
			}
			string text2 = GameGeneral.ScenariosRootPath + "\\Autosaves\\" + text;
			LoadAutosaveButton.Visible = File.Exists(text2 + "\\Autosave.scen");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Label_Title.Text = "错误！";
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, "ERROR - Unable to load scenario! Please copy this entire text and submit it to the dev team for investigation. \r\n\r\nException: " + ex2.Message + "\r\n\r\nException source: " + ex2.Source + "\r\n\r\nStack Trace:\r\n" + ex2.StackTrace);
			Label_Title.ForeColor = Color.IndianRed;
			ProjectData.ClearProjectError();
		}
	}

	private void AssetAttribute(DarkTreeView darkTreeView_0, DarkTreeNode darkTreeNode_0)
	{
		RestartAttribute(darkTreeNode_0);
	}

	private void PrintAttribute(DarkTreeView darkTreeView_0, DarkTreeNode darkTreeNode_0)
	{
		RestartAttribute(darkTreeNode_0);
	}

	private void DefineAttribute(object sender, EventArgs e)
	{
		OpenFileDialog1.DefaultExt = "*.scen;*.save";
		OpenFileDialog1.FileName = "*.scen;*.save";
		OpenFileDialog1.Filter = "想定文件 (.scen)|*.scen|存档文件 (.save)|*.save|未加密想定文件 (.scenx)|*.secnx";
		if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
		{
			ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = OpenFileDialog1.FileName;
			ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
			if (ItemExporter.ConnectInterruptibleTemplate.StartGame.Visible)
			{
				ItemExporter.ConnectInterruptibleTemplate.StartGame.Close();
			}
			Close();
		}
	}

	private void PublishAttribute(object sender, EventArgs e)
	{
		if (_StrategyModel == null)
		{
			return;
		}
		string text = _StrategyModel.ScenTitle;
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		char[] array = invalidFileNameChars;
		foreach (char c in array)
		{
			text = text.Replace(Conversions.ToString(c), "");
		}
		string Local_AutosavesPath = GameGeneral.ScenariosRootPath + "\\Autosaves\\" + text;
		MainForm.KillAllRendering = true;
		if (Information.IsNothing(_StrategyModel))
		{
			return;
		}
		LoadAutosaveButton.Enabled = false;
		if (Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			Client.CurrentGame.Pause();
		}
		Client.MainThreadDispatcher.InvokeAsync(delegate
		{
			if (File.Exists(Local_AutosavesPath + "\\Autosave.scen"))
			{
				Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.SelectedFilename = Local_AutosavesPath + "\\Autosave.scen";
				ItemExporter.ConnectInterruptibleTemplate.ResumeFromSave.Show();
				Close();
			}
			else
			{
				DarkMessageBox.ShowError("No autosave file was found at the path" + Local_AutosavesPath + "\\Autosave.scen", "没有找到自动保存存档");
			}
		});
	}

	private void AwakeAttribute(object object_0)
	{
		if (txtScenSearch.Text != null)
		{
			SearchString = txtScenSearch.Text;
		}
	}

	[CompilerGenerated]
	private void QueryAttribute(double double_0)
	{
		_ConnectionModel = double_0;
	}
}
