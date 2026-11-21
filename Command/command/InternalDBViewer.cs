using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Command.Filters;
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
public sealed class InternalDBViewer : DarkSecondaryFormBase
{
	[CompilerGenerated]
	private sealed class TaskMap
	{
		public Mount Local_theM;

		internal bool DefineInterruptiblePage(Sensor theS)
		{
			return Local_theM.CompatibleDirectors.Contains(theS.DBID);
		}
	}

	[CompilerGenerated]
	private sealed class DicCollectionTask
	{
		public Weapon Local_theW;

		internal bool PublishInterruptiblePage(Sensor theS)
		{
			return Local_theW.Directors.Contains(theS.DBID);
		}
	}

	private IContainer m_RulesContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("ListBox1")]
	private DarkListView m_MethodContainer;

	[AccessedThroughProperty("CB_Country")]
	[CompilerGenerated]
	private DarkUIComboBox _SystemContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private DarkLabel m_BaseContainer;

	[AccessedThroughProperty("TB_Class")]
	[CompilerGenerated]
	private DarkUITextBox m_PolicyContainer;

	[AccessedThroughProperty("CB_ObjectType")]
	[CompilerGenerated]
	private DarkUIComboBox broadcasterContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel m_IdentifierContainer;

	[AccessedThroughProperty("WebBrowser1")]
	[CompilerGenerated]
	private WebBrowser printerContainer;

	[AccessedThroughProperty("CB_Hypothetical")]
	[CompilerGenerated]
	private DarkUIComboBox _ParserContainer;

	[AccessedThroughProperty("CB_SubType")]
	[CompilerGenerated]
	private DarkUIComboBox _DatabaseContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("TypeLabel")]
	private DarkLabel interceptorContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("DuplicateWindowButton")]
	private DarkUIButton m_MessageContainer;

	[AccessedThroughProperty("SearchDBIDButton")]
	[CompilerGenerated]
	private DarkUIButton productContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("DBIDGOTO")]
	private DarkUITextBox m_AnnotationContainer;

	[AccessedThroughProperty("NextButton")]
	[CompilerGenerated]
	private DarkUIButton iteratorContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("PreviousButton")]
	private DarkUIButton initializerContainer;

	public int SelectedObjectID;

	public int selectedSubType;

	public string HighlightTarget;

	public string string_0;

	public string SelectedObjectName;

	public string DatabaseObjectName;

	private DataTable _RoleContainer;

	private bool m_FactoryContainer;

	private int attributeContainer;

	private int _EventContainer;

	private bool _GlobalContainer;

	public List<DBViewerNavigationHistoryItem> DBViewerNavigationHistory;

	public int NavigationHistoryPosition;

	private string m_WorkerContainer;

	private DBOps.DBFileCheckResult _AccountContainer;

	public Dictionary<XSection._SignatureType, Tuple<float, float, float, float>> BaseSignatures;

	internal DarkListView ListBox1
	{
		[CompilerGenerated]
		get
		{
			return m_MethodContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectIterator;
			EventHandler value3 = OrderIterator;
			EventHandler value4 = CustomizeInitializer;
			DarkListView methodContainer = m_MethodContainer;
			if (methodContainer != null)
			{
				methodContainer.MouseEnter -= value2;
				methodContainer.MouseLeave -= value3;
				methodContainer.SelectedIndicesChanged -= value4;
			}
			m_MethodContainer = value;
			methodContainer = m_MethodContainer;
			if (methodContainer != null)
			{
				methodContainer.MouseEnter += value2;
				methodContainer.MouseLeave += value3;
				methodContainer.SelectedIndicesChanged += value4;
			}
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal DarkGroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_Country
	{
		[CompilerGenerated]
		get
		{
			return _SystemContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryIterator;
			MouseEventHandler value3 = ResetIterator;
			DarkUIComboBox systemContainer = _SystemContainer;
			if (systemContainer != null)
			{
				systemContainer.DropDownClosed -= value2;
				systemContainer.MouseWheel -= value3;
			}
			_SystemContainer = value;
			systemContainer = _SystemContainer;
			if (systemContainer != null)
			{
				systemContainer.DropDownClosed += value2;
				systemContainer.MouseWheel += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return m_BaseContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BaseContainer = value;
		}
	}

	internal DarkUITextBox TB_Class
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = PrintIterator;
			DarkUITextBox policyContainer = m_PolicyContainer;
			if (policyContainer != null)
			{
				policyContainer.TextChanged -= value2;
			}
			m_PolicyContainer = value;
			policyContainer = m_PolicyContainer;
			if (policyContainer != null)
			{
				policyContainer.TextChanged += value2;
			}
		}
	}

	internal DarkUIComboBox CB_ObjectType
	{
		[CompilerGenerated]
		get
		{
			return broadcasterContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishIterator;
			MouseEventHandler value3 = AwakeIterator;
			EventHandler value4 = DestroyInitializer;
			DarkUIComboBox darkUIComboBox = broadcasterContainer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.DropDownClosed -= value2;
				darkUIComboBox.MouseWheel -= value3;
				darkUIComboBox.SelectedIndexChanged -= value4;
			}
			broadcasterContainer = value;
			darkUIComboBox = broadcasterContainer;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.DropDownClosed += value2;
				darkUIComboBox.MouseWheel += value3;
				darkUIComboBox.SelectedIndexChanged += value4;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IdentifierContainer = value;
		}
	}

	internal WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return printerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PreviewKeyDownEventHandler value2 = RevertIterator;
			WebBrowserNavigatingEventHandler value3 = CountInitializer;
			WebBrowserDocumentCompletedEventHandler value4 = MoveInitializer;
			WebBrowser webBrowser = printerContainer;
			if (webBrowser != null)
			{
				webBrowser.PreviewKeyDown -= value2;
				webBrowser.Navigating -= value3;
				webBrowser.DocumentCompleted -= value4;
			}
			printerContainer = value;
			webBrowser = printerContainer;
			if (webBrowser != null)
			{
				webBrowser.PreviewKeyDown += value2;
				webBrowser.Navigating += value3;
				webBrowser.DocumentCompleted += value4;
			}
		}
	}

	internal DarkUIComboBox CB_Hypothetical
	{
		[CompilerGenerated]
		get
		{
			return _ParserContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterIterator;
			MouseEventHandler value3 = ManageIterator;
			DarkUIComboBox parserContainer = _ParserContainer;
			if (parserContainer != null)
			{
				parserContainer.DropDownClosed -= value2;
				parserContainer.MouseWheel -= value3;
			}
			_ParserContainer = value;
			parserContainer = _ParserContainer;
			if (parserContainer != null)
			{
				parserContainer.DropDownClosed += value2;
				parserContainer.MouseWheel += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_SubType
	{
		[CompilerGenerated]
		get
		{
			return _DatabaseContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutInitializer;
			MouseEventHandler value3 = ViewInitializer;
			DarkUIComboBox databaseContainer = _DatabaseContainer;
			if (databaseContainer != null)
			{
				databaseContainer.DropDownClosed -= value2;
				databaseContainer.MouseWheel -= value3;
			}
			_DatabaseContainer = value;
			databaseContainer = _DatabaseContainer;
			if (databaseContainer != null)
			{
				databaseContainer.DropDownClosed += value2;
				databaseContainer.MouseWheel += value3;
			}
		}
	}

	internal DarkLabel TypeLabel
	{
		[CompilerGenerated]
		get
		{
			return interceptorContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interceptorContainer = value;
		}
	}

	internal DarkUIButton DuplicateWindowButton
	{
		[CompilerGenerated]
		get
		{
			return m_MessageContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallInitializer;
			DarkUIButton messageContainer = m_MessageContainer;
			if (messageContainer != null)
			{
				messageContainer.Click -= value2;
			}
			m_MessageContainer = value;
			messageContainer = m_MessageContainer;
			if (messageContainer != null)
			{
				messageContainer.Click += value2;
			}
		}
	}

	internal DarkUIButton SearchDBIDButton
	{
		[CompilerGenerated]
		get
		{
			return productContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchInitializer;
			DarkUIButton darkUIButton = productContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			productContainer = value;
			darkUIButton = productContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUITextBox DBIDGOTO
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectInitializer;
			DarkUITextBox annotationContainer = m_AnnotationContainer;
			if (annotationContainer != null)
			{
				annotationContainer.GotFocus -= value2;
			}
			m_AnnotationContainer = value;
			annotationContainer = m_AnnotationContainer;
			if (annotationContainer != null)
			{
				annotationContainer.GotFocus += value2;
			}
		}
	}

	internal DarkUIButton NextButton
	{
		[CompilerGenerated]
		get
		{
			return iteratorContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddInitializer;
			DarkUIButton darkUIButton = iteratorContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			iteratorContainer = value;
			darkUIButton = iteratorContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton PreviousButton
	{
		[CompilerGenerated]
		get
		{
			return initializerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteInitializer;
			DarkUIButton darkUIButton = initializerContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			initializerContainer = value;
			darkUIButton = initializerContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	public string SelectedObjectType
	{
		get
		{
			return m_WorkerContainer;
		}
		set
		{
			m_WorkerContainer = value;
		}
	}

	public InternalDBViewer()
	{
		base.FormClosing += RunIterator;
		base.Load += StartIterator;
		base.Load += AssetIterator;
		base.Shown += delegate
		{
			GlobalSingleton.GetInstance().method_0(this);
			SuspendLayout();
			if (string.IsNullOrEmpty(SelectedObjectType))
			{
				SelectedObjectType = "飞机";
			}
			if (!CB_ObjectType.Items.Contains("传感器"))
			{
				_EventContainer = CB_ObjectType.Items.Add("传感器");
			}
			if (Operators.CompareString(SelectedObjectType, "武器", TextCompare: true) != 0 && Operators.CompareString(SelectedObjectType, "传感器", TextCompare: true) != 0)
			{
				CB_Country.Enabled = true;
				CB_Country.Visible = true;
			}
			else
			{
				CB_Country.Enabled = false;
				CB_Country.Visible = false;
			}
			DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
			CB_Country.DataSource = cache_OperatorCountries_DT;
			CB_Country.DisplayMember = "Description";
			CB_Country.ValueMember = "ID";
			CB_Country.SelectedIndex = 0;
			CB_Hypothetical.Items.Clear();
			CB_Hypothetical.Items.AddRange(new object[3] { "显示所有平台，包括真实和假想", "仅显示真实平台", "仅显示假想平台" });
			CB_Hypothetical.SelectedIndex = 0;
			BindCombobox_SubType(0);
			if (SelectedObjectID <= 0)
			{
				HighlightTarget = null;
				DefineIterator();
			}
			else
			{
				DisplaySelection(bool_0: true);
			}
			WebBrowser1.Focus();
			ResumeLayout();
		};
		base.KeyDown += FlushIterator;
		base.MouseWheel += ForgotIterator;
		base.KeyDown += ConnectInitializer;
		_RoleContainer = new DataTable();
		DBViewerNavigationHistory = new List<DBViewerNavigationHistoryItem>();
		NavigationHistoryPosition = -1;
		BaseSignatures = new Dictionary<XSection._SignatureType, Tuple<float, float, float, float>>();
		PostIterator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_RulesContainer != null)
			{
				m_RulesContainer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PostIterator()
	{
		GroupBox1 = new DarkGroupBox();
		CB_SubType = new DarkUIComboBox();
		TypeLabel = new DarkLabel();
		CB_Hypothetical = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_Country = new DarkUIComboBox();
		Label5 = new DarkLabel();
		Label4 = new DarkLabel();
		TB_Class = new DarkUITextBox();
		CB_ObjectType = new DarkUIComboBox();
		ListBox1 = new DarkListView();
		Label1 = new DarkLabel();
		WebBrowser1 = new WebBrowser();
		DuplicateWindowButton = new DarkUIButton();
		SearchDBIDButton = new DarkUIButton();
		DBIDGOTO = new DarkUITextBox();
		NextButton = new DarkUIButton();
		PreviousButton = new DarkUIButton();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		GroupBox1.Controls.Add(CB_SubType);
		GroupBox1.Controls.Add(TypeLabel);
		GroupBox1.Controls.Add(CB_Hypothetical);
		GroupBox1.Controls.Add(Label7);
		GroupBox1.Controls.Add(CB_Country);
		GroupBox1.Controls.Add(Label5);
		GroupBox1.Controls.Add(Label4);
		GroupBox1.Controls.Add(TB_Class);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(4, 39);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(281, 129);
		GroupBox1.TabIndex = 21;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "过滤...";
		CB_SubType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_SubType.BackColor = Color.Transparent;
		CB_SubType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_SubType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_SubType.Font = new Font("Segoe UI", 7f);
		CB_SubType.Location = new Point(92, 93);
		CB_SubType.MaxDropDownItems = 4;
		CB_SubType.Name = "CB_SubType";
		CB_SubType.Size = new Size(184, 21);
		CB_SubType.TabIndex = 20;
		TypeLabel.AutoSize = true;
		TypeLabel.ForeColor = Color.FromArgb(220, 220, 220);
		TypeLabel.Location = new Point(8, 97);
		TypeLabel.Name = "TypeLabel";
		TypeLabel.Size = new Size(54, 15);
		TypeLabel.TabIndex = 19;
		TypeLabel.Text = "子类型：";
		CB_Hypothetical.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		CB_Hypothetical.BackColor = Color.Transparent;
		CB_Hypothetical.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Hypothetical.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Hypothetical.Font = new Font("Segoe UI", 7f);
		CB_Hypothetical.Location = new Point(91, 66);
		CB_Hypothetical.Name = "CB_Hypothetical";
		CB_Hypothetical.Size = new Size(184, 21);
		CB_Hypothetical.TabIndex = 18;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(7, 70);
		Label7.Name = "Label7";
		Label7.Size = new Size(78, 15);
		Label7.TabIndex = 17;
		Label7.Text = "假想：";
		CB_Country.BackColor = Color.Transparent;
		CB_Country.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Country.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Country.Font = new Font("Segoe UI", 7f);
		CB_Country.Location = new Point(91, 41);
		CB_Country.Name = "CB_Country";
		CB_Country.Size = new Size(184, 21);
		CB_Country.TabIndex = 13;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(7, 45);
		Label5.Name = "Label5";
		Label5.Size = new Size(53, 15);
		Label5.TabIndex = 12;
		Label5.Text = "国家：";
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(7, 21);
		Label4.Name = "Label4";
		Label4.Size = new Size(37, 15);
		Label4.TabIndex = 11;
		Label4.Text = "类别：";
		TB_Class.AutoCompleteCustomSource = null;
		TB_Class.AutoCompleteMode = AutoCompleteMode.None;
		TB_Class.AutoCompleteSource = AutoCompleteSource.None;
		TB_Class.BackColor = Color.FromArgb(69, 73, 74);
		TB_Class.Font = new Font("Segoe UI", 8f);
		TB_Class.ForeColor = Color.FromArgb(220, 220, 220);
		TB_Class.Image = null;
		TB_Class.Lines = null;
		TB_Class.Location = new Point(91, 17);
		TB_Class.MaxLength = 32767;
		TB_Class.Multiline = false;
		TB_Class.Name = "TB_Class";
		TB_Class.ReadOnly = false;
		TB_Class.ScrollBars = ScrollBars.None;
		TB_Class.SelectionStart = 0;
		TB_Class.Size = new Size(184, 20);
		TB_Class.TabIndex = 10;
		TB_Class.TextAlign = HorizontalAlignment.Left;
		TB_Class.UseSystemPasswordChar = false;
		TB_Class.WatermarkText = "";
		CB_ObjectType.BackColor = Color.Transparent;
		CB_ObjectType.DrawMode = DrawMode.OwnerDrawFixed;
		CB_ObjectType.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_ObjectType.Font = new Font("Segoe UI", 7f);
		CB_ObjectType.Items.AddRange(new object[7] { "飞机", "舰船", "潜艇", "设施", "地面单元", "卫星", "武器" });
		CB_ObjectType.Location = new Point(59, 12);
		CB_ObjectType.Name = "CB_ObjectType";
		CB_ObjectType.Size = new Size(226, 21);
		CB_ObjectType.TabIndex = 14;
		ListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		ListBox1.AutoResizeOnItemChange = false;
		ListBox1.Location = new Point(291, 12);
		ListBox1.Name = "ListBox1";
		ListBox1.Size = new Size(712, 156);
		ListBox1.TabIndex = 0;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(7, 15);
		Label1.Name = "Label1";
		Label1.Size = new Size(31, 15);
		Label1.TabIndex = 22;
		Label1.Text = "类型";
		WebBrowser1.AllowWebBrowserDrop = false;
		WebBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		WebBrowser1.IsWebBrowserContextMenuEnabled = false;
		WebBrowser1.Location = new Point(4, 210);
		WebBrowser1.MinimumSize = new Size(20, 20);
		WebBrowser1.Name = "WebBrowser1";
		WebBrowser1.Size = new Size(999, 512);
		WebBrowser1.TabIndex = 23;
		WebBrowser1.WebBrowserShortcutsEnabled = false;
		DuplicateWindowButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		DuplicateWindowButton.BackColor = Color.Transparent;
		DuplicateWindowButton.DialogResult = DialogResult.None;
		DuplicateWindowButton.Font = new Font("Segoe UI", 10f);
		DuplicateWindowButton.ForeColor = SystemColors.Control;
		DuplicateWindowButton.Location = new Point(863, 174);
		DuplicateWindowButton.Name = "DuplicateWindowButton";
		DuplicateWindowButton.RoundRadius = 0;
		DuplicateWindowButton.Size = new Size(140, 28);
		DuplicateWindowButton.TabIndex = 4;
		DuplicateWindowButton.Text = "复制当前窗口";
		SearchDBIDButton.BackColor = Color.Transparent;
		SearchDBIDButton.DialogResult = DialogResult.None;
		SearchDBIDButton.Font = new Font("Segoe UI", 10f);
		SearchDBIDButton.ForeColor = SystemColors.Control;
		SearchDBIDButton.Location = new Point(473, 176);
		SearchDBIDButton.Name = "SearchDBIDButton";
		SearchDBIDButton.RoundRadius = 0;
		SearchDBIDButton.Size = new Size(43, 29);
		SearchDBIDButton.TabIndex = 3;
		SearchDBIDButton.Text = "开始";
		DBIDGOTO.AutoCompleteCustomSource = null;
		DBIDGOTO.AutoCompleteMode = AutoCompleteMode.None;
		DBIDGOTO.AutoCompleteSource = AutoCompleteSource.None;
		DBIDGOTO.BackColor = Color.Transparent;
		DBIDGOTO.Font = new Font("Segoe UI", 11f);
		DBIDGOTO.ForeColor = Color.FromArgb(189, 189, 189);
		DBIDGOTO.Image = null;
		DBIDGOTO.Lines = null;
		DBIDGOTO.Location = new Point(202, 176);
		DBIDGOTO.MaxLength = 32767;
		DBIDGOTO.Multiline = false;
		DBIDGOTO.Name = "DBIDGOTO";
		DBIDGOTO.ReadOnly = false;
		DBIDGOTO.ScrollBars = ScrollBars.None;
		DBIDGOTO.SelectionStart = 0;
		DBIDGOTO.Size = new Size(265, 29);
		DBIDGOTO.TabIndex = 2;
		DBIDGOTO.TextAlign = HorizontalAlignment.Center;
		DBIDGOTO.UseSystemPasswordChar = false;
		DBIDGOTO.WatermarkText = "";
		NextButton.BackColor = Color.Transparent;
		NextButton.DialogResult = DialogResult.None;
		NextButton.Font = new Font("Segoe UI", 10f);
		NextButton.ForeColor = SystemColors.Control;
		NextButton.Location = new Point(103, 176);
		NextButton.Name = "NextButton";
		NextButton.RoundRadius = 0;
		NextButton.Size = new Size(93, 28);
		NextButton.TabIndex = 1;
		NextButton.Text = "下一个";
		PreviousButton.BackColor = Color.Transparent;
		PreviousButton.DialogResult = DialogResult.None;
		PreviousButton.Font = new Font("Segoe UI", 10f);
		PreviousButton.ForeColor = SystemColors.Control;
		PreviousButton.Location = new Point(4, 176);
		PreviousButton.Name = "PreviousButton";
		PreviousButton.RoundRadius = 0;
		PreviousButton.Size = new Size(93, 28);
		PreviousButton.TabIndex = 0;
		PreviousButton.Text = "上一个";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1008, 727);
		base.Controls.Add(DuplicateWindowButton);
		base.Controls.Add(SearchDBIDButton);
		base.Controls.Add(WebBrowser1);
		base.Controls.Add(DBIDGOTO);
		base.Controls.Add(Label1);
		base.Controls.Add(NextButton);
		base.Controls.Add(GroupBox1);
		base.Controls.Add(PreviousButton);
		base.Controls.Add(CB_ObjectType);
		base.Controls.Add(ListBox1);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.Name = "InternalDBViewer";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "数据库查看器";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void RunIterator(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void StartIterator(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnDBView == SimConfiguration.WindowPauseBehaviour.Pause)
		{
			Client.CurrentGame.Pause();
		}
		else if (Client.CurrentGame.Status == Game._GameStatus.Running && SimConfiguration.DefaultGamePreferences.PauseOnDBView == SimConfiguration.WindowPauseBehaviour.SlowToRealTime)
		{
			Client.CurrentScenario.TimeCompression_Set(Scenario.enumTimeCompression.OneSec);
		}
		base.WindowState = FormWindowState.Normal;
		attributeContainer = -1;
		Text = "数据库查看器";
		int? num = ((DbConnection)(Client.CurrentScenario?.DBConnection))?.DataSource?.Length;
		if ((num.HasValue ? new bool?(num.GetValueOrDefault() > 0) : null).GetValueOrDefault())
		{
			Text = Text + " (" + ((DbConnection)Client.CurrentScenario.DBConnection).DataSource + ")";
		}
	}

	public void ScrollToSpecificElement(string string_1)
	{
		if ((object)WebBrowser1.Document.Body == null)
		{
			return;
		}
		HtmlElementCollection all = WebBrowser1.Document.Body.All;
		IEnumerator enumerator = null;
		try
		{
			enumerator = all.GetEnumerator();
			while (enumerator.MoveNext())
			{
				HtmlElement htmlElement = (HtmlElement)enumerator.Current;
				string attribute = htmlElement.GetAttribute("名称");
				if (!string.IsNullOrEmpty(attribute) && Operators.CompareString(attribute, string_1, TextCompare: true) == 0)
				{
					htmlElement.ScrollIntoView(alignWithTop: true);
					break;
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

	public bool DisplayNavigationHistoryIndex(int int_0)
	{
		if (int_0 > -1 && int_0 < DBViewerNavigationHistory.Count)
		{
			DisplayInfoInDetailsPanel(DBViewerNavigationHistory[int_0].DBID, DBViewerNavigationHistory[int_0].ItemType);
			NavigationHistoryPosition = int_0;
			RefreshNavigationHistoryButtons();
			return true;
		}
		return false;
	}

	public bool DisplayInfoInDetailsPanel(int int_0, string string_1)
	{
		string text = "";
		bool result = true;
		SelectedObjectID = int_0;
		SelectedObjectType = string_1;
		string selectedObjectType = SelectedObjectType;
		if (Operators.CompareString(selectedObjectType, "飞机", TextCompare: true) == 0)
		{
			Scenario scenario_ = Client.CurrentScenario;
			Aircraft aircraft_ = new Aircraft(ref scenario_, "");
			scenario_ = Client.CurrentScenario;
			DBFunctions.GetAircraft(ref scenario_, ref aircraft_, SelectedObjectID);
			DatabaseObjectName = aircraft_.UnitClass;
			text = DisplayAircraft(aircraft_);
		}
		else if (Operators.CompareString(selectedObjectType, "舰船", TextCompare: true) == 0)
		{
			Scenario scenario_2 = Client.CurrentScenario;
			Ship ship_ = new Ship(ref scenario_2, "");
			scenario_2 = Client.CurrentScenario;
			DBFunctions.GetShip(ref scenario_2, ref ship_, SelectedObjectID);
			DatabaseObjectName = ship_.UnitClass;
			text = DisplayShip(ship_);
		}
		else if (Operators.CompareString(selectedObjectType, "潜艇", TextCompare: true) == 0)
		{
			Scenario scenario_3 = Client.CurrentScenario;
			Submarine submarine_ = new Submarine(ref scenario_3, "");
			scenario_3 = Client.CurrentScenario;
			DBFunctions.GetSubmarine(ref scenario_3, ref submarine_, SelectedObjectID);
			DatabaseObjectName = submarine_.UnitClass;
			text = DisplaySubmarine(submarine_);
		}
		else if (Operators.CompareString(selectedObjectType, "设施", TextCompare: true) == 0)
		{
			Scenario scenario_4 = Client.CurrentScenario;
			Facility facility_ = new Facility(ref scenario_4, "");
			scenario_4 = Client.CurrentScenario;
			DBFunctions.GetFacility(ref scenario_4, ref facility_, SelectedObjectID);
			DatabaseObjectName = facility_.UnitClass;
			text = DisplayFacility(facility_);
		}
		else if (Operators.CompareString(selectedObjectType, "地面单元", TextCompare: true) != 0 && Operators.CompareString(selectedObjectType, "GroundUnit", TextCompare: true) != 0)
		{
			if (Operators.CompareString(selectedObjectType, "卫星", TextCompare: true) == 0)
			{
				Scenario scenario_5 = Client.CurrentScenario;
				Satellite satellite_ = new Satellite(ref scenario_5);
				scenario_5 = Client.CurrentScenario;
				DBFunctions.GetSatellite(ref scenario_5, ref satellite_, SelectedObjectID);
				DatabaseObjectName = satellite_.UnitClass;
				text = DisplaySatellite(satellite_);
			}
			else if (Operators.CompareString(selectedObjectType, "武器", TextCompare: true) == 0)
			{
				Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(SelectedObjectID);
				DatabaseObjectName = weapon.UnitClass;
				text = DisplayWeapon(weapon);
			}
			else if (Operators.CompareString(selectedObjectType, "传感器", TextCompare: true) == 0)
			{
				text = DisplaySensor(SelectedObjectID);
			}
			else
			{
				result = false;
			}
		}
		else
		{
			Scenario scenario_6 = Client.CurrentScenario;
			Vehicle vehicle_ = new Vehicle(ref scenario_6, "");
			scenario_6 = Client.CurrentScenario;
			DBFunctions.GetVehicle(ref scenario_6, ref vehicle_, SelectedObjectID);
			text = DisplayGroundUnit(vehicle_);
		}
		InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, text);
		string_0 = text;
		return result;
	}

	public void RefreshNavigationHistoryButtons()
	{
		DBIDGOTO.WatermarkText = "输入数据库ID对应于该 " + CB_ObjectType.Text + " ...";
		if (DBViewerNavigationHistory.Count == 0)
		{
			PreviousButton.Enabled = false;
			NextButton.Enabled = false;
		}
		if (NavigationHistoryPosition - 1 > -1 && NavigationHistoryPosition - 1 < DBViewerNavigationHistory.Count)
		{
			PreviousButton.Enabled = true;
		}
		else
		{
			PreviousButton.Enabled = false;
		}
		if (NavigationHistoryPosition + 1 > -1 && NavigationHistoryPosition + 1 < DBViewerNavigationHistory.Count)
		{
			NextButton.Enabled = true;
		}
		else
		{
			NextButton.Enabled = false;
		}
	}

	public void DisplaySelection(bool bool_0, bool bool_1 = false)
	{
		if (string.IsNullOrEmpty(SelectedObjectType) || SelectedObjectID == 0)
		{
			return;
		}
		switch (SelectedObjectType)
		{
		case "Submarine":
			SelectedObjectType = "潜艇";
			break;
		case "Ship":
			SelectedObjectType = "舰船";
			break;
		case "Ground Unit":
			SelectedObjectType = "地面单元";
			break;
		case "Facility":
			SelectedObjectType = "设施";
			break;
		case "Sensor":
			SelectedObjectType = "传感器";
			break;
		case "Weapon":
			SelectedObjectType = "武器";
			break;
		case "Aircraft":
			SelectedObjectType = "飞机";
			break;
		case "Satellite":
			SelectedObjectType = "卫星";
			break;
		}
		bool flag = !SelectedObjectType.Equals(RuntimeHelpers.GetObjectValue(CB_ObjectType.SelectedItem));
		if (!bool_1)
		{
			CB_ObjectType.SelectedItem = SelectedObjectType;
		}
		if (selectedSubType == -1)
		{
			string selectedObjectType = SelectedObjectType;
			if (Operators.CompareString(selectedObjectType, "飞机", TextCompare: true) == 0)
			{
				Scenario scenario_ = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetAircraftType_Int(ref scenario_, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "舰船", TextCompare: true) == 0)
			{
				Scenario scenario_6 = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetShipType_Int(ref scenario_6, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "潜艇", TextCompare: true) == 0)
			{
				Scenario scenario_7 = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetSubmarineType_Int(ref scenario_7, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "设施", TextCompare: true) == 0)
			{
				Scenario scenario_8 = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetFacilityType_Int(ref scenario_8, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "卫星", TextCompare: true) == 0)
			{
				Scenario scenario_9 = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetSatelliteType_Int(ref scenario_9, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "武器", TextCompare: true) == 0)
			{
				Scenario scenario_10 = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetWeaponType_Int(ref scenario_10, SelectedObjectID);
			}
			else if (Operators.CompareString(selectedObjectType, "地面单元", TextCompare: true) == 0 || Operators.CompareString(selectedObjectType, "GroundUnit", TextCompare: true) == 0)
			{
				Scenario scenario_11 = Client.CurrentScenario;
				selectedSubType = DBFunctions.GetVehicleType_Int(ref scenario_11, SelectedObjectID);
			}
		}
		else if (flag)
		{
			selectedSubType = 0;
		}
		BindCombobox_SubType((short)selectedSubType);
		if (bool_0 || !bool_1)
		{
			DefineIterator();
		}
		if (!bool_1)
		{
			m_FactoryContainer = true;
			DarkListItem darkListItem = ListBox1.Items.Where((DarkListItem darkListItem_0) => Conversions.ToInteger(darkListItem_0.Tag) == SelectedObjectID).FirstOrDefault();
			if (darkListItem != null)
			{
				ListBox1.SelectItem(ListBox1.Items.IndexOf(darkListItem));
			}
			m_FactoryContainer = false;
			ListBox1.EnsureVisible();
		}
		SelectedObjectName = ListBox1.Text;
		if (DisplayInfoInDetailsPanel(SelectedObjectID, SelectedObjectType))
		{
			if (DBViewerNavigationHistory.Count <= 0 || DBViewerNavigationHistory[DBViewerNavigationHistory.Count - 1].DBID != SelectedObjectID)
			{
				DBViewerNavigationHistory.Add(new DBViewerNavigationHistoryItem(SelectedObjectID, SelectedObjectType));
				NavigationHistoryPosition = DBViewerNavigationHistory.Count - 1;
			}
			string text = "";
			string selectedObjectType2 = SelectedObjectType;
			if (Operators.CompareString(selectedObjectType2, "飞机", TextCompare: true) == 0)
			{
				Scenario scenario_12 = Client.CurrentScenario;
				Aircraft aircraft_ = new Aircraft(ref scenario_12, "");
				scenario_12 = Client.CurrentScenario;
				DBFunctions.GetAircraft(ref scenario_12, ref aircraft_, SelectedObjectID);
				DatabaseObjectName = aircraft_.UnitClass;
				text = DisplayAircraft(aircraft_);
			}
			else if (Operators.CompareString(selectedObjectType2, "舰船", TextCompare: true) == 0)
			{
				Scenario scenario_13 = Client.CurrentScenario;
				Ship ship_ = new Ship(ref scenario_13, "");
				scenario_13 = Client.CurrentScenario;
				DBFunctions.GetShip(ref scenario_13, ref ship_, SelectedObjectID);
				DatabaseObjectName = ship_.UnitClass;
				text = DisplayShip(ship_);
			}
			else if (Operators.CompareString(selectedObjectType2, "潜艇", TextCompare: true) == 0)
			{
				Scenario scenario_2 = Client.CurrentScenario;
				Submarine submarine_ = new Submarine(ref scenario_2, "");
				scenario_2 = Client.CurrentScenario;
				DBFunctions.GetSubmarine(ref scenario_2, ref submarine_, SelectedObjectID);
				DatabaseObjectName = submarine_.UnitClass;
				text = DisplaySubmarine(submarine_);
			}
			else if (Operators.CompareString(selectedObjectType2, "设施", TextCompare: true) == 0)
			{
				Scenario scenario_3 = Client.CurrentScenario;
				Facility facility_ = new Facility(ref scenario_3, "");
				scenario_3 = Client.CurrentScenario;
				DBFunctions.GetFacility(ref scenario_3, ref facility_, SelectedObjectID);
				DatabaseObjectName = facility_.UnitClass;
				text = DisplayFacility(facility_);
			}
			else if (Operators.CompareString(selectedObjectType2, "卫星", TextCompare: true) == 0)
			{
				Scenario scenario_4 = Client.CurrentScenario;
				Satellite satellite_ = new Satellite(ref scenario_4);
				scenario_4 = Client.CurrentScenario;
				DBFunctions.GetSatellite(ref scenario_4, ref satellite_, SelectedObjectID);
				DatabaseObjectName = satellite_.UnitClass;
				text = DisplaySatellite(satellite_);
			}
			else if (Operators.CompareString(selectedObjectType2, "武器", TextCompare: true) == 0)
			{
				Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(SelectedObjectID);
				DatabaseObjectName = weapon.UnitClass;
				text = DisplayWeapon(weapon);
			}
			else if (Operators.CompareString(selectedObjectType2, "地面单元", TextCompare: true) != 0 && Operators.CompareString(selectedObjectType2, "GroundUnit", TextCompare: true) != 0)
			{
				if (Operators.CompareString(selectedObjectType2, "传感器", TextCompare: true) == 0)
				{
					text = DisplaySensor(SelectedObjectID);
				}
			}
			else
			{
				Scenario scenario_5 = Client.CurrentScenario;
				Vehicle vehicle_ = new Vehicle(ref scenario_5, "");
				scenario_5 = Client.CurrentScenario;
				DBFunctions.GetVehicle(ref scenario_5, ref vehicle_, SelectedObjectID);
				text = DisplayGroundUnit(vehicle_);
			}
			InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, text);
			string_0 = text;
		}
		RefreshNavigationHistoryButtons();
		if ((ListBox1.SelectedIndices != null) & (ListBox1.SelectedIndices.Count > 0))
		{
			attributeContainer = ListBox1.SelectedIndices[0] * ListBox1.ItemHeight;
		}
	}

	private void AssetIterator(object sender, EventArgs e)
	{
		CB_ObjectType.SelectedIndex = 0;
		BindCombobox_SubType(0);
		string text = ColorTranslator.ToHtml(BackColor);
		InterpreterObjectListener.AwakeInterruptibleTask(WebBrowser1, "<html><body style='background-color:" + text + "'></body></html>");
	}

	private void PrintIterator(object object_0)
	{
		if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0)
		{
			DefineIterator();
		}
	}

	private void DefineIterator()
	{
		int selectedIndex = CB_ObjectType.SelectedIndex;
		IEnumerator enumerator = null;
		switch (selectedIndex)
		{
		default:
			if (selectedIndex == _EventContainer)
			{
				SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
				_RoleContainer = DBFunctions.GetAllSensors(ref sqliteConnection_);
				break;
			}
			return;
		case 0:
			_RoleContainer = Client.CurrentScenario.Cache_Aircraft_DT;
			break;
		case 1:
			_RoleContainer = Client.CurrentScenario.Cache_Ships_DT;
			break;
		case 2:
			_RoleContainer = Client.CurrentScenario.Cache_Subs_DT;
			break;
		case 3:
			_RoleContainer = Client.CurrentScenario.Cache_Facilities_DT;
			break;
		case 4:
			_RoleContainer = Client.CurrentScenario.Cache_GroundUnits_DT;
			break;
		case 5:
			_RoleContainer = Client.CurrentScenario.Cache_Satellites_DT;
			break;
		case 6:
			_RoleContainer = Client.CurrentScenario.Cache_Weapons_DT;
			break;
		}
		if (_RoleContainer.Rows.Count == 0)
		{
			return;
		}
		DataView dataView = new DataView(_RoleContainer);
		dataView.Sort = "LongName ASC";
		if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0 || CB_Country.SelectedIndex != 0 || CB_Hypothetical.SelectedIndex != 0 || CB_SubType.SelectedIndex != 0)
		{
			string text = "1=1 ";
			if (Operators.CompareString(TB_Class.Text, "", TextCompare: true) != 0)
			{
				string text2 = TB_Class.Text.Replace("'", "''");
				text = text + " AND LongName LIKE '%" + text2 + "%' ";
			}
			if (CB_Country.Enabled && _RoleContainer.Columns.Contains("OperatorCountry") && CB_Country.SelectedIndex > 0)
			{
				text = text + " AND OperatorCountry=" + CB_Country.SelectedValue.ToString();
			}
			if (_RoleContainer.Columns.Contains("假想"))
			{
				if (CB_Hypothetical.SelectedIndex == 1)
				{
					text += " AND Hypothetical=FALSE";
				}
				else if (CB_Hypothetical.SelectedIndex == 2)
				{
					text += " AND Hypothetical=TRUE";
				}
			}
			if (CB_SubType.SelectedIndex > 0)
			{
				text = ((CB_ObjectType.SelectedIndex == 3) ? (text + " AND category=" + CB_SubType.SelectedValue.ToString()) : ((CB_ObjectType.SelectedIndex == 4) ? (text + " AND category=" + CB_SubType.SelectedValue.ToString()) : (text + " AND type=" + CB_SubType.SelectedValue.ToString())));
			}
			text = text.Replace("[", "[[");
			text = text.Replace("]", "]]");
			text = text.Replace("[[", "[[]");
			string text5 = (dataView.RowFilter = text.Replace("]]", "[]]"));
			string text3 = text5;
			text = text3;
		}
		m_FactoryContainer = true;
		ListBox1.Items.Clear();
		try
		{
			enumerator = dataView.GetEnumerator();
			while (enumerator.MoveNext())
			{
				DataRow row = ((DataRowView)enumerator.Current).Row;
				DarkListItem darkListItem = new DarkListItem(row["LongName"].ToString());
				darkListItem.Tag = RuntimeHelpers.GetObjectValue(row["ID"]);
				ListBox1.Items.Add(darkListItem);
			}
		}
		finally
		{
			if (enumerator is IDisposable)
			{
				(enumerator as IDisposable).Dispose();
			}
		}
		ListBox1.UpdateContentSize();
		m_FactoryContainer = false;
		attributeContainer = -1;
	}

	private void PublishIterator(object sender, EventArgs e)
	{
		if (CB_ObjectType.SelectedIndex == 4 && Client.CurrentScenario.Cache_GroundUnits_DT.Rows.Count == 0)
		{
			DarkMessageBox.ShowWarning("Ground units are not present in this database", "Internal Database Viewer");
			CB_ObjectType.SelectedIndex = 0;
		}
		SelectedObjectType = Conversions.ToString(CB_ObjectType.SelectedItem);
		selectedSubType = 0;
		TB_Class.Clear();
		if (Operators.CompareString(SelectedObjectType, "武器", TextCompare: true) != 0 && Operators.CompareString(SelectedObjectType, "传感器", TextCompare: true) != 0)
		{
			CB_Country.Enabled = true;
			CB_Country.Visible = true;
		}
		else
		{
			CB_Country.Enabled = false;
			CB_Country.Visible = false;
		}
		BindCombobox_SubType((short)selectedSubType);
		DefineIterator();
	}

	private void AwakeIterator(object sender, EventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void QueryIterator(object sender, EventArgs e)
	{
		DefineIterator();
	}

	private void ResetIterator(object sender, EventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void MapIterator(object sender, EventArgs e)
	{
		GlobalSingleton.GetInstance().method_0(this);
		SuspendLayout();
		if (string.IsNullOrEmpty(SelectedObjectType))
		{
			SelectedObjectType = "飞机";
		}
		if (!CB_ObjectType.Items.Contains("传感器"))
		{
			_EventContainer = CB_ObjectType.Items.Add("传感器");
		}
		if (Operators.CompareString(SelectedObjectType, "武器", TextCompare: true) != 0 && Operators.CompareString(SelectedObjectType, "传感器", TextCompare: true) != 0)
		{
			CB_Country.Enabled = true;
			CB_Country.Visible = true;
		}
		else
		{
			CB_Country.Enabled = false;
			CB_Country.Visible = false;
		}
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		CB_Country.DataSource = cache_OperatorCountries_DT;
		CB_Country.DisplayMember = "Description";
		CB_Country.ValueMember = "ID";
		CB_Country.SelectedIndex = 0;
		CB_Hypothetical.Items.Clear();
		CB_Hypothetical.Items.AddRange(new object[3] { "显示所有平台，包括真实和假想", "仅显示真实平台", "仅显示假想平台" });
		CB_Hypothetical.SelectedIndex = 0;
		BindCombobox_SubType(0);
		if (SelectedObjectID <= 0)
		{
			HighlightTarget = null;
			DefineIterator();
		}
		else
		{
			DisplaySelection(bool_0: true);
		}
		WebBrowser1.Focus();
		ResumeLayout();
	}

	public string DisplayAircraft(Aircraft aircraft_0)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		if (aircraft_0.Hypothetical)
		{
			text2 = " - 假想单元";
		}
		Tuple<string, string, string> operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType.Aircraft, aircraft_0.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + aircraft_0.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(aircraft_0));
		text = text.Replace("<%Description%>", DisplayDescription(aircraft_0));
		text = text.Replace("<%General%>", Aircraft_General(aircraft_0));
		text = text.Replace("<%Sensors%>", DisplaySensors(aircraft_0));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts(aircraft_0));
		text = text.Replace("<%Stores%>", DisplayStores(aircraft_0));
		text = text.Replace("<%Loadouts%>", DisplayLoadouts(aircraft_0));
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", DisplayComms(aircraft_0));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", DisplaySignatures(aircraft_0));
		text = text.Replace("<%Flags%>", DisplayFlags(aircraft_0));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(aircraft_0));
		return text.Replace("<%Fuel%>", DisplayFuel(aircraft_0));
	}

	public string DisplayShip(Ship ship_0)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		if (ship_0.Hypothetical)
		{
			text2 = " - 假想单元";
		}
		Tuple<string, string, string> operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType.Ship, ship_0.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + ship_0.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(ship_0));
		text = text.Replace("<%Description%>", DisplayDescription(ship_0));
		text = text.Replace("<%General%>", Ship_General(ship_0));
		text = text.Replace("<%Sensors%>", DisplaySensors(ship_0));
		text = text.Replace("<%MineCountermeasures%>", DisplayMineCountermeasuresGear(ship_0));
		text = text.Replace("<%Mounts%>", DisplayMounts(ship_0));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags(ship_0));
		text = text.Replace("<%Comms%>", DisplayComms(ship_0));
		text = text.Replace("<%AirFacilities%>", DisplayAirFacilities(ship_0));
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities(ship_0));
		text = text.Replace("<%Signatures%>", DisplaySignatures(ship_0));
		text = text.Replace("<%Flags%>", DisplayFlags(ship_0));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(ship_0));
		return text.Replace("<%Fuel%>", DisplayFuel(ship_0));
	}

	public string DisplaySubmarine(Submarine submarine_0)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		if (submarine_0.Hypothetical)
		{
			text2 = " - 假想单元";
		}
		Tuple<string, string, string> operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType.Submarine, submarine_0.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + submarine_0.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(submarine_0));
		text = text.Replace("<%Description%>", DisplayDescription(submarine_0));
		text = text.Replace("<%General%>", Submarine_General(submarine_0));
		text = text.Replace("<%Sensors%>", DisplaySensors(submarine_0));
		text = text.Replace("<%MineCountermeasures%>", DisplayMineCountermeasuresGear(submarine_0));
		text = text.Replace("<%Mounts%>", DisplayMounts(submarine_0));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags(submarine_0));
		text = text.Replace("<%Comms%>", DisplayComms(submarine_0));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities(submarine_0));
		text = text.Replace("<%Signatures%>", DisplaySignatures(submarine_0));
		text = text.Replace("<%Flags%>", DisplayFlags(submarine_0));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(submarine_0));
		return text.Replace("<%Fuel%>", DisplayFuel(submarine_0));
	}

	public string DisplayFacility(Facility facility_0)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		if (facility_0.Hypothetical)
		{
			text2 = " - 假想单元";
		}
		Tuple<string, string, string> operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType.Facility, facility_0.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + facility_0.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(facility_0));
		text = text.Replace("<%Description%>", DisplayDescription(facility_0));
		text = text.Replace("<%General%>", Facility_General(facility_0));
		text = text.Replace("<%Sensors%>", DisplaySensors(facility_0));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts(facility_0));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags(facility_0));
		text = text.Replace("<%Comms%>", DisplayComms(facility_0));
		text = text.Replace("<%AirFacilities%>", DisplayAirFacilities(facility_0));
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities(facility_0));
		text = text.Replace("<%Signatures%>", DisplaySignatures(facility_0));
		text = text.Replace("<%Flags%>", "");
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(facility_0));
		return text.Replace("<%Fuel%>", DisplayFuel(facility_0));
	}

	public string DisplayGroundUnit(IMobileGroundUnit imobileGroundUnit_0)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		if (((Platform)imobileGroundUnit_0).Hypothetical)
		{
			text2 = " - 假想单元";
		}
		Tuple<string, string, string> operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType.Vehicle, ((Platform)imobileGroundUnit_0).DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + ((Platform)imobileGroundUnit_0).UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage((Platform)imobileGroundUnit_0));
		text = text.Replace("<%Description%>", DisplayDescription((Platform)imobileGroundUnit_0));
		text = text.Replace("<%General%>", GroundUnit_General(imobileGroundUnit_0));
		text = text.Replace("<%Sensors%>", DisplaySensors((Platform)imobileGroundUnit_0));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts((Platform)imobileGroundUnit_0));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", DisplayMags((Platform)imobileGroundUnit_0));
		text = text.Replace("<%Comms%>", DisplayComms((Platform)imobileGroundUnit_0));
		text = text.Replace("<%AirFacilities%>", DisplayAirFacilities((Platform)imobileGroundUnit_0));
		text = text.Replace("<%DockingFacilities%>", DisplayDockingFacilities((Platform)imobileGroundUnit_0));
		text = text.Replace("<%Signatures%>", DisplaySignatures((Platform)imobileGroundUnit_0));
		text = text.Replace("<%Flags%>", "");
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", DisplayPropulsion((ActiveUnit)imobileGroundUnit_0));
		return text.Replace("<%Fuel%>", DisplayFuel((ActiveUnit)imobileGroundUnit_0));
	}

	public string DisplaySatellite(Satellite satellite_0)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		string text2 = "";
		if (satellite_0.Hypothetical)
		{
			text2 = " - 假想单元";
		}
		Tuple<string, string, string> operatorCountryAndYears = DBFunctions.GetOperatorCountryAndYears(GlobalVariables.ActiveUnitType.Satellite, satellite_0.DBID, Client.CurrentScenario);
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + satellite_0.UnitClass + " (" + operatorCountryAndYears.Item1 + " - " + operatorCountryAndYears.Item2 + ")" + text2);
		text = text.Replace("<%Image%>", DisplayImage(satellite_0));
		text = text.Replace("<%Description%>", DisplayDescription(satellite_0));
		text = text.Replace("<%General%>", Satellite_General(satellite_0));
		text = text.Replace("<%Sensors%>", DisplaySensors(satellite_0));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", DisplayMounts(satellite_0));
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", DisplayComms(satellite_0));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", DisplaySignatures(satellite_0));
		text = text.Replace("<%Flags%>", DisplayFlags(satellite_0));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", "");
		return text.Replace("<%Fuel%>", "");
	}

	public string Aircraft_General(Aircraft aircraft_0)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Aircraft.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact contact_ = new Contact(aircraft_0);
		string text2 = "";
		if (contact_.ActualUnit != null)
		{
			contact_.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			bool? nullable_ = null;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_), nullable_.Value) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(aircraft_0.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(aircraft_0.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%Length%>", Conversions.ToString(aircraft_0.Length));
		text = text.Replace("<%ClimbRate%>", $"{aircraft_0.Kinematics.GetClimbRate_Nominal(bool_0: false):0.0}");
		text = text.Replace("<%InstantaneousClimbRate%>", $"{aircraft_0.Kinematics.GetClimbRate_Nominal(bool_0: false) * 3f:0.0}");
		text = text.Replace("<%ClimbRateFeetPrMin%>", Conversions.ToString(Conversions.ToInteger($"{(double)aircraft_0.Kinematics.GetClimbRate_Nominal(bool_0: false) / 0.3048 * 60.0 / 10.0:0.0}") * 10));
		text = text.Replace("<%InstantaneousClimbRateFeetPrMin%>", Conversions.ToString(Conversions.ToInteger($"{(double)(aircraft_0.Kinematics.GetClimbRate_Nominal(bool_0: false) * 3f) / 0.3048 * 60.0 / 10.0:0.0}") * 10));
		text = text.Replace("<%Span%>", Conversions.ToString(aircraft_0.Span));
		text = text.Replace("<%Height%>", Conversions.ToString(aircraft_0.Height));
		text = text.Replace("<%Agility%>", Conversions.ToString(aircraft_0.Agility_Nominal));
		text = text.Replace("<%EmptyWeight%>", Conversions.ToString(aircraft_0.EmptyWeight));
		text = text.Replace("<%MaxWeight%>", Conversions.ToString(aircraft_0.MaxWeight));
		text = text.Replace("<%MaxPayloadWeight%>", Conversions.ToString(aircraft_0.MaxPayloadWeight));
		text = text.Replace("<%Crew%>", Conversions.ToString(aircraft_0.Crew));
		text = text.Replace("<%Visibility%>", SortIterator(aircraft_0));
		text = text.Replace("<%Armor%>", CalcIterator(aircraft_0));
		text = text.Replace("<%RunwayLengthNeeded%>", Misc.Description(aircraft_0.RunwayLengthNeeded, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%PhysicalSize%>", Misc.Description(aircraft_0.Size, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%CockpitGeneration%>", CombatSystem_Description(aircraft_0.UnitType, aircraft_0.CockpitGen));
		text = text.Replace("<%OODA%>", OODA_Description(aircraft_0.UnitType, aircraft_0.DBID, aircraft_0.CockpitGen));
		return text.Replace("<%DamagePoints%>", Conversions.ToString(aircraft_0.GetDamagePts()));
	}

	public string GroundUnit_General(IMobileGroundUnit imobileGroundUnit_0)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\GroundUnit.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact contact_ = new Contact((ActiveUnit)imobileGroundUnit_0);
		string text2 = "";
		if (contact_.ActualUnit != null)
		{
			contact_.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			bool? nullable_ = true;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_), nullable_.Value) + ")";
		}
		text = text.Replace("<%Category%>", Misc.ToEnglishString(imobileGroundUnit_0.MobileUnitCategory) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(((Platform)imobileGroundUnit_0).GetDamagePts()));
		if (((Platform)imobileGroundUnit_0).IsVehicle)
		{
			Vehicle vehicle = (Vehicle)imobileGroundUnit_0;
			text = text.Replace("<%TroopCapacity%>", CargoHostHelper.TroopCapacityString(vehicle));
			text = text.Replace("<%CargoCapacity%>", CargoHostHelper.CargoCapacityString(vehicle));
			text = text.Replace("<%Length%>", Conversions.ToString(vehicle.Length));
			text = text.Replace("<%Width%>", Conversions.ToString(vehicle.Width));
			text = text.Replace("<%Area%>", Conversions.ToString(vehicle.Area));
			text = text.Replace("<%Crew%>", Conversions.ToString(vehicle.Crew));
			text = text.Replace("<%Armor_General%>", Misc.Description(vehicle.Armor_General, Client.CurrentScenario.DBConnection));
			text = text.Replace("<%MastHeight%>", Conversions.ToString(vehicle.MastHeight));
			text = text.Replace("<%CombatSystem%>", CombatSystem_Description(vehicle.UnitType, vehicle.CombatSystemGen));
			text = text.Replace("<%OODA%>", OODA_Description(((Platform)imobileGroundUnit_0).UnitType, ((Platform)imobileGroundUnit_0).DBID, 0));
			text = text.Replace("<%MissileDefence%>", Conversions.ToString(vehicle.MissileDefense) + " 鱼雷 / 超音速低空导弹SLAM / Maverick 等效导弹");
			text = text.Replace("<%FireOnTheMove%>", vehicle.CanFireOnTheMove ? "Unit Can Fire on the Move" : "Unit Must Halt to Fire");
		}
		return text;
	}

	private string SortIterator(Aircraft aircraft_0)
	{
		if (Client.CurrentScenario.FeatureCompatibility.CockpitVisibility)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("前面：").Append(Misc.VisitRequest(aircraft_0.VisibilityForward)).Append("<br>");
			stringBuilder.Append("侧面：").Append(Misc.VisitRequest(aircraft_0.VisibilitySideways)).Append("<br>");
			stringBuilder.Append("后面：").Append(Misc.VisitRequest(aircraft_0.VisibilityAft));
			return stringBuilder.ToString();
		}
		return "此数据库不支持。";
	}

	private string CalcIterator(Aircraft aircraft_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("机身：").Append(Misc.Description(aircraft_0.Armor_Fuselage, Client.CurrentScenario.DBConnection)).Append("<br>");
		stringBuilder.Append("座舱：").Append(Misc.Description(aircraft_0.Armor_Cockpit, Client.CurrentScenario.DBConnection)).Append("<br>");
		stringBuilder.Append("供电设备：").Append(Misc.Description(aircraft_0.Armor_Powerplant, Client.CurrentScenario.DBConnection));
		return stringBuilder.ToString();
	}

	public string CombatSystem_Description(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0)
	{
		switch (activeUnitType_0)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
		{
			Scenario scenario_5 = Client.CurrentScenario;
			(string, string, short, short, short) tuple5 = DBFunctions.ConcatList(ref scenario_5, int_0, bool_0: true);
			return tuple5.Item1 + " (ex: " + tuple5.Item2 + ")";
		}
		case GlobalVariables.ActiveUnitType.Ship:
		{
			Scenario scenario_4 = Client.CurrentScenario;
			(string, string, short, short, short) tuple4 = DBFunctions.InterruptList(ref scenario_4, int_0, bool_0: true);
			return tuple4.Item1 + " (ex: " + tuple4.Item2 + ")";
		}
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			Scenario scenario_3 = Client.CurrentScenario;
			(string, string, string, short, short, short) tuple3 = DBFunctions.RemoveList(ref scenario_3, int_0, bool_0: true);
			return tuple3.Item1 + " (ex: " + tuple3.Item2 + " - " + tuple3.Item3 + ")";
		}
		case GlobalVariables.ActiveUnitType.Facility:
		{
			Scenario scenario_2 = Client.CurrentScenario;
			(string, string, short, short, short) tuple2 = DBFunctions.FindList(ref scenario_2, int_0, bool_0: true);
			return tuple2.Item1 + " (ex: " + tuple2.Item2 + ")";
		}
		default:
			return string.Empty;
		case GlobalVariables.ActiveUnitType.Vehicle:
		case GlobalVariables.ActiveUnitType.Personnel:
		{
			Scenario scenario_ = Client.CurrentScenario;
			(string, string, short, short, short) tuple = DBFunctions.SetList(ref scenario_, int_0, bool_0: true);
			return tuple.Item1 + " (ex: " + tuple.Item2 + ")";
		}
		}
	}

	public string OODA_Description(GlobalVariables.ActiveUnitType activeUnitType_0, int int_0, int int_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (int_1 > 0)
		{
			switch (activeUnitType_0)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
			{
				Scenario scenario_5 = Client.CurrentScenario;
				(string, string, short, short, short) tuple5 = DBFunctions.ConcatList(ref scenario_5, int_1, bool_0: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>探测:</td><td>" + Conversions.ToString((int)tuple5.Item3) + " 秒 OODA反应时间<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>目标:</td><td>" + $"{tuple5.Item4 * 2:0}" + " 秒 (新手)<br>" + $"{(double)tuple5.Item4 * 1.5:0}" + " 秒 (学员)<br>" + $"{(double)tuple5.Item4 * 1.2:0}" + " 秒 (一般)<br>" + $"{tuple5.Item4:0}" + " 秒 (熟手)<br>" + $"{(double)tuple5.Item4 * 0.8:0}" + " 秒 (专家)<br>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>规避:</td><td>" + $"{tuple5.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Ship:
			{
				Scenario scenario_4 = Client.CurrentScenario;
				(string, string, short, short, short) tuple4 = DBFunctions.InterruptList(ref scenario_4, int_1, bool_0: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>探测:</td><td>" + Conversions.ToString((int)tuple4.Item3) + " 秒 OODA反应时间<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>目标:</td><td>" + $"{tuple4.Item4 * 2:0}" + " 秒 (新手)<br>" + $"{(double)tuple4.Item4 * 1.5:0}" + " 秒 (学员)<br>" + $"{(double)tuple4.Item4 * 1.2:0}" + " 秒 (一般)<br>" + $"{tuple4.Item4:0}" + " 秒 (熟手)<br>" + $"{(double)tuple4.Item4 * 0.8:0}" + " 秒 (专家)<br>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>规避:</td><td>" + $"{tuple4.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Submarine:
			{
				Scenario scenario_3 = Client.CurrentScenario;
				(string, string, string, short, short, short) tuple3 = DBFunctions.RemoveList(ref scenario_3, int_1, bool_0: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>探测:</td><td>" + Conversions.ToString((int)tuple3.Item4) + " 秒 OODA反应时间<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>目标:</td><td>" + $"{tuple3.Item5 * 2:0}" + " 秒 (新手)<br>" + $"{(double)tuple3.Item5 * 1.5:0}" + " 秒 (学员)<br>" + $"{(double)tuple3.Item5 * 1.2:0}" + " 秒 (一般)<br>" + $"{tuple3.Item5:0}" + " 秒 (熟手)<br>" + $"{(double)tuple3.Item5 * 0.8:0}" + " 秒 (专家)<br>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>规避:</td><td>" + $"{tuple3.Item6:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Facility:
			{
				Scenario scenario_2 = Client.CurrentScenario;
				(string, string, short, short, short) tuple2 = DBFunctions.FindList(ref scenario_2, int_1, bool_0: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>探测:</td><td>" + Conversions.ToString((int)tuple2.Item3) + " 秒 OODA反应时间<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>目标:</td><td>" + $"{tuple2.Item4 * 2:0}" + " 秒 (新手)<br>" + $"{(double)tuple2.Item4 * 1.5:0}" + " 秒 (学员)<br>" + $"{(double)tuple2.Item4 * 1.2:0}" + " 秒 (一般)<br>" + $"{tuple2.Item4:0}" + " 秒 (熟手)<br>" + $"{(double)tuple2.Item4 * 0.8:0}" + " 秒 (专家)<br>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>规避:</td><td>" + $"{tuple2.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			case GlobalVariables.ActiveUnitType.Vehicle:
			case GlobalVariables.ActiveUnitType.Personnel:
			{
				Scenario scenario_ = Client.CurrentScenario;
				(string, string, short, short, short) tuple = DBFunctions.SetList(ref scenario_, int_1, bool_0: false);
				stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>探测:</td><td>" + Conversions.ToString((int)tuple.Item3) + " 秒 OODA反应时间<td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td valign=top>目标:</td><td>" + $"{tuple.Item4 * 2:0}" + " 秒 (新手)<br>" + $"{(double)tuple.Item4 * 1.5:0}" + " 秒 (学员)<br>" + $"{(double)tuple.Item4 * 1.2:0}" + " 秒 (一般)<br>" + $"{tuple.Item4:0}" + " 秒 (熟手)<br>" + $"{(double)tuple.Item4 * 0.8:0}" + " 秒 (专家)<br>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("<tr>");
				stringBuilder.Append("<td>规避:</td><td>" + $"{tuple.Item5:0}" + " seconds</td>");
				stringBuilder.Append("</tr>");
				stringBuilder.Append("</table>");
				return stringBuilder.ToString();
			}
			}
		}
		int int_2 = 0;
		int int_3 = 0;
		int int_4 = 0;
		DBFunctions.smethod_0(activeUnitType_0, int_0, Client.CurrentScenario.DBConnection, ref int_2, ref int_3, ref int_4);
		stringBuilder.Append("<table style='font-family:Verdana;font-size:8pt'>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td>探测:</td><td>" + Conversions.ToString(int_2) + " 秒 OODA反应时间<td>");
		stringBuilder.Append("</tr>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td valign=top>目标:</td><td>" + $"{int_3 * 2:0}" + " 秒 (新手)<br>" + $"{(double)int_3 * 1.5:0}" + " 秒 (学员)<br>" + $"{(double)int_3 * 1.2:0}" + " 秒 (一般)<br>" + $"{int_3:0}" + " 秒 (熟手)<br>" + $"{(double)int_3 * 0.8:0}" + " 秒 (专家)<br>");
		stringBuilder.Append("</tr>");
		stringBuilder.Append("<tr>");
		stringBuilder.Append("<td>规避:</td><td>" + $"{int_4:0}" + " seconds</td>");
		stringBuilder.Append("</tr>");
		stringBuilder.Append("</table>");
		return stringBuilder.ToString();
	}

	public string Weapon_General(Weapon weapon_0)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Weapon.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		text = text.Replace("<%Type%>", Misc.ForgotRequest(weapon_0.Type));
		text = ((weapon_0.Span <= 0f) ? text.Replace("<%Span%>", "-") : text.Replace("<%Span%>", Conversions.ToString(weapon_0.Span) + " 米"));
		text = ((weapon_0.Length <= 0f) ? text.Replace("<%Length%>", "-") : text.Replace("<%Length%>", Conversions.ToString(weapon_0.Length) + " 米"));
		text = ((weapon_0.Diameter <= 0f) ? text.Replace("<%Diameter%>", "-") : text.Replace("<%Diameter%>", Conversions.ToString(weapon_0.Diameter) + " 米"));
		text = ((weapon_0.EmptyWeight <= 0) ? text.Replace("<%Weight%>", "-") : text.Replace("<%Weight%>", Conversions.ToString(weapon_0.EmptyWeight) + "千克"));
		text = ((weapon_0.FindReponse() <= 0) ? text.Replace("<%BurnoutWeight%>", "-") : text.Replace("<%BurnoutWeight%>", Conversions.ToString(weapon_0.FindReponse()) + "千克"));
		if (weapon_0.CruiseAltitude_AGL <= 0f)
		{
			if (weapon_0.CruiseAltitude_ASL <= 0f)
			{
				text = text.Replace("<%CruiseAlt%>", "");
				text = text.Replace("<%CruiseAltFeet%>", "-");
			}
			else
			{
				text = text.Replace("<%CruiseAlt%>", $"{weapon_0.CruiseAltitude_ASL:0.0}" + " 米 海高");
				text = text.Replace("<%CruiseAltFeet%>", $"{weapon_0.CruiseAltitude_ASL * 3.28084f:0}" + " 英尺 海高, ");
			}
		}
		else
		{
			text = text.Replace("<%CruiseAlt%>", $"{weapon_0.CruiseAltitude_AGL:0.0}" + " 米 真高");
			text = text.Replace("<%CruiseAltFeet%>", $"{weapon_0.CruiseAltitude_AGL * 3.28084f:0}" + " 英尺 真高, ");
		}
		if (weapon_0.MaxAirRange <= 0f)
		{
			text = text.Replace("<%RangeAAW%>", "-");
			text = text.Replace("<%AirPOK%>", "-");
		}
		else
		{
			text = ((weapon_0.MinAirRange <= 0f) ? text.Replace("<%RangeAAW%>", Conversions.ToString(weapon_0.MaxAirRange) + "海里") : text.Replace("<%RangeAAW%>", Conversions.ToString(weapon_0.MinAirRange) + " - " + Conversions.ToString(weapon_0.MaxAirRange) + "海里"));
			text = text.Replace("<%AirPOK%>", Conversions.ToString(weapon_0.AirPOK) + " %");
		}
		if (weapon_0.MaxSurfaceRange <= 0f)
		{
			text = text.Replace("<%RangeASUW%>", "-");
			text = text.Replace("<%SurfPOK%>", "-");
		}
		else
		{
			text = ((weapon_0.MinSurfaceRange <= 0f) ? text.Replace("<%RangeASUW%>", Conversions.ToString(weapon_0.MaxSurfaceRange) + "海里") : text.Replace("<%RangeASUW%>", Conversions.ToString(weapon_0.MinSurfaceRange) + " - " + Conversions.ToString(weapon_0.MaxSurfaceRange) + "海里"));
			text = text.Replace("<%SurfPOK%>", Conversions.ToString(weapon_0.SurfPOK) + " %");
		}
		if (weapon_0.MaxLandRange <= 0f)
		{
			text = text.Replace("<%RangeLand%>", "-");
			text = text.Replace("<%LandPOK%>", "-");
		}
		else
		{
			text = ((weapon_0.MinLandRange <= 0f) ? text.Replace("<%RangeLand%>", Conversions.ToString(weapon_0.MaxLandRange) + "海里") : text.Replace("<%RangeLand%>", Conversions.ToString(weapon_0.MinLandRange) + " - " + Conversions.ToString(weapon_0.MaxLandRange) + "海里"));
			text = text.Replace("<%LandPOK%>", Conversions.ToString(weapon_0.LandPOK) + " %");
		}
		if (weapon_0.MaxSubsurfaceRange <= 0f)
		{
			text = text.Replace("<%RangeASW%>", "-");
			text = text.Replace("<%SubPOK%>", "-");
		}
		else
		{
			text = ((weapon_0.MinSubsurfaceRange <= 0f) ? text.Replace("<%RangeASW%>", Conversions.ToString(weapon_0.MaxSubsurfaceRange) + "海里") : text.Replace("<%RangeASW%>", Conversions.ToString(weapon_0.MinSubsurfaceRange) + " - " + Conversions.ToString(weapon_0.MaxSubsurfaceRange) + "海里"));
			text = text.Replace("<%SubPOK%>", Conversions.ToString(weapon_0.SubPOK) + " %");
		}
		text = ((weapon_0.MaxSurfaceRange <= 0f || weapon_0.CEP_Surface <= 0) ? text.Replace("<%CEP_Surface%>", "-") : text.Replace("<%CEP_Surface%>", Conversions.ToString(weapon_0.CEP_Surface) + " 米"));
		text = ((weapon_0.MaxLandRange <= 0f || weapon_0.CEP_Land <= 0) ? text.Replace("<%CEP_Land%>", "-") : text.Replace("<%CEP_Land%>", Conversions.ToString(weapon_0.CEP_Land) + " 米"));
		if (!(weapon_0.MinLaunchAlt_AGL <= 0f) && weapon_0.MinLaunchAlt_ASL > 0f)
		{
			if (weapon_0.MaxLaunchAlt_AGL <= 0f && weapon_0.MaxLaunchAlt_ASL <= 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 海高  " + $"{weapon_0.MinLaunchAlt_AGL:0.0}" + " 米 真高 ");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高  " + $"{weapon_0.MinLaunchAlt_AGL * 3.28084f:0}" + " 英尺 真高, ");
			}
			else
			{
				text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 海高  " + $"{weapon_0.MinLaunchAlt_AGL:0.0}" + " 米 真高 - ");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高  " + $"{weapon_0.MinLaunchAlt_AGL * 3.28084f:0}" + " 英尺 真高 - ");
			}
		}
		else if (weapon_0.MinLaunchAlt_ASL <= 0f)
		{
			if (weapon_0.MinLaunchAlt_AGL <= 0f)
			{
				if (weapon_0.MinLaunchAlt_ASL > 0f && (weapon_0.MaxLaunchAlt_AGL <= 0f || weapon_0.MaxLaunchAlt_ASL <= 0f))
				{
					text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 海高");
					text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高, ");
				}
				else if (weapon_0.Type != Weapon._WeaponType.Torpedo && !weapon_0.IsMine)
				{
					if (weapon_0.Type == Weapon._WeaponType.GuidedWeapon && weapon_0.MinLaunchAlt_AGL < 0f)
					{
						text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 - ");
						text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 - ");
					}
					else if (weapon_0.Type == Weapon._WeaponType.GuidedWeapon && weapon_0.MinLaunchAlt_ASL < 0f)
					{
						text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 - ");
						text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 - ");
					}
					else if (weapon_0.MaxLaunchAlt_AGL == 0f && weapon_0.MaxLaunchAlt_ASL == 0f && weapon_0.MinLaunchAlt_AGL == 0f && weapon_0.MinLaunchAlt_ASL == 0f)
					{
						text = text.Replace("<%LaunchAltMin%>", "-");
						text = text.Replace("<%LaunchAltFeetMin%>", "");
					}
					else if ((weapon_0.Type == Weapon._WeaponType.RV) | (weapon_0.Type == Weapon._WeaponType.HGV))
					{
						text = text.Replace("<%LaunchAltMin%>", "-");
						text = text.Replace("<%LaunchAltFeetMin%>", "");
					}
					else
					{
						text = text.Replace("<%LaunchAltMin%>", "");
						text = text.Replace("<%LaunchAltFeetMin%>", "");
					}
				}
				else if (weapon_0.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(weapon_0.ParentScen.DBConnection))
				{
					text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 - ");
					text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 - ");
				}
				else
				{
					text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_AGL:0.0}" + " 米 - ");
					text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_AGL * 3.28084f:0}" + " 英尺, ");
				}
			}
			else if (weapon_0.MaxLaunchAlt_AGL <= 0f && weapon_0.MaxLaunchAlt_ASL <= 0f)
			{
				text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_AGL:0.0}" + " 米 真高");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_AGL * 3.28084f:0}" + " 英尺 真高, ");
			}
			else
			{
				text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_AGL:0.0}" + " 米 真高 -");
				text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_AGL * 3.28084f:0}" + " 英尺 真高 - ");
			}
		}
		else if (weapon_0.MaxLaunchAlt_AGL <= 0f && weapon_0.MaxLaunchAlt_ASL <= 0f)
		{
			text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 海高");
			text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高, ");
		}
		else
		{
			text = text.Replace("<%LaunchAltMin%>", $"{weapon_0.MinLaunchAlt_ASL:0.0}" + " 米 海高 - ");
			text = text.Replace("<%LaunchAltFeetMin%>", $"{weapon_0.MinLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高 - ");
		}
		if (!(weapon_0.MaxLaunchAlt_AGL <= 0f) && weapon_0.MaxLaunchAlt_ASL > 0f)
		{
			text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_ASL, 0) + " 米 海高  " + string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_AGL, 0) + " 米 真高");
			text = text.Replace("<%LaunchAltFeetMax%>", $"{weapon_0.MaxLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高  " + Conversions.ToString(Conversions.ToInteger($"{(double)weapon_0.MaxLaunchAlt_AGL / 0.3048 / 10.0:0.0}") * 10) + " 英尺 真高, ");
		}
		else if (weapon_0.MaxLaunchAlt_AGL <= 0f)
		{
			if (weapon_0.MaxLaunchAlt_ASL <= 0f)
			{
				if (weapon_0.Type != Weapon._WeaponType.Torpedo && !weapon_0.IsMine)
				{
					if (weapon_0.Type == Weapon._WeaponType.GuidedWeapon && weapon_0.MinLaunchAlt_AGL < 0f)
					{
						text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_AGL, 0) + " 米 真高");
						text = text.Replace("<%LaunchAltFeetMax%>", $"{weapon_0.MaxLaunchAlt_AGL * 3.28084f:0}" + " 英尺 真高, ");
					}
					else if (weapon_0.Type == Weapon._WeaponType.GuidedWeapon && weapon_0.MinLaunchAlt_ASL < 0f)
					{
						text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_ASL, 0) + " 米 海高");
						text = text.Replace("<%LaunchAltFeetMax%>", $"{weapon_0.MaxLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高, ");
					}
					else
					{
						text = text.Replace("<%LaunchAltMax%>", "");
						text = text.Replace("<%LaunchAltFeetMax%>", "");
					}
				}
				else if (weapon_0.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(weapon_0.ParentScen.DBConnection))
				{
					text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_ASL, 0) + " 米");
					text = text.Replace("<%LaunchAltFeetMax%>", $"{weapon_0.MaxLaunchAlt_ASL * 3.28084f:0}" + " 英尺, ");
				}
				else
				{
					text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_AGL, 0) + " 米");
					text = text.Replace("<%LaunchAltFeetMax%>", $"{weapon_0.MaxLaunchAlt_AGL * 3.28084f:0}" + " 英尺, ");
				}
			}
			else
			{
				text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_ASL, 0) + " 米 海高");
				text = text.Replace("<%LaunchAltFeetMax%>", $"{weapon_0.MaxLaunchAlt_ASL * 3.28084f:0}" + " 英尺 海高, ");
			}
		}
		else
		{
			text = text.Replace("<%LaunchAltMax%>", string.Format("{0:0.0}", weapon_0.MaxLaunchAlt_AGL, 0) + " 米 真高");
			text = text.Replace("<%LaunchAltFeetMax%>", $"{weapon_0.MaxLaunchAlt_AGL * 3.28084f:0}" + " 英尺 真高, ");
		}
		text = ((weapon_0.MinLaunchSpeed >= 0 && weapon_0.MaxLaunchSpeed > 0) ? text.Replace("<%LaunchSpdMin%>", Conversions.ToString(weapon_0.MinLaunchSpeed) + " - ") : ((weapon_0.MinLaunchSpeed <= 0 || weapon_0.MaxLaunchSpeed > 0) ? text.Replace("<%LaunchSpdMin%>", "-") : text.Replace("<%LaunchSpdMin%>", Conversions.ToString(weapon_0.MinLaunchSpeed) + "节")));
		text = ((weapon_0.MaxLaunchSpeed <= 0) ? text.Replace("<%LaunchSpdMax%>", "") : text.Replace("<%LaunchSpdMax%>", Conversions.ToString(weapon_0.MaxLaunchSpeed) + "节"));
		text = ((weapon_0.MinTargetSpeed >= 0 && weapon_0.MaxTargetSpeed > 0) ? text.Replace("<%TargetSpdMin%>", Conversions.ToString(weapon_0.MinTargetSpeed) + " - ") : ((weapon_0.MinTargetSpeed > 0 && weapon_0.MaxTargetSpeed <= 0) ? text.Replace("<%TargetSpdMin%>", Conversions.ToString(weapon_0.MinTargetSpeed) + "节") : ((weapon_0.MinTargetSpeed > 0 || weapon_0.MaxTargetSpeed <= 0) ? text.Replace("<%TargetSpdMin%>", "-") : text.Replace("<%TargetSpdMin%>", "n/a"))));
		text = ((weapon_0.MaxTargetSpeed <= 0) ? text.Replace("<%TargetSpdMax%>", "") : text.Replace("<%TargetSpdMax%>", Conversions.ToString(weapon_0.MaxTargetSpeed) + "节"));
		if (!(weapon_0.MinTargetAlt_AGL <= 0f) && (!(weapon_0.MaxTargetAlt_AGL <= 0f) || weapon_0.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", weapon_0.MinTargetAlt_AGL, 0) + " 米 真高 - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{weapon_0.MinTargetAlt_AGL * 3.28084f:0}" + " 英尺 真高 - ");
		}
		else if (!(weapon_0.MinTargetAlt_ASL <= 0f) && (!(weapon_0.MaxTargetAlt_AGL <= 0f) || weapon_0.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", weapon_0.MinTargetAlt_ASL, 0) + " 米 海高 - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{weapon_0.MinTargetAlt_ASL * 3.28084f:0}" + " 英尺 海高 - ");
		}
		else if (weapon_0.MinTargetAlt_AGL > 0f && (weapon_0.MaxTargetAlt_AGL <= 0f || weapon_0.MaxTargetAlt_ASL <= 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", weapon_0.MinTargetAlt_AGL, 0) + " 米 真高 - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{weapon_0.MinTargetAlt_AGL * 3.28084f:0}" + " 英尺 真高 - ");
		}
		else if (weapon_0.MinTargetAlt_ASL > 0f && (weapon_0.MaxTargetAlt_AGL <= 0f || weapon_0.MaxTargetAlt_ASL <= 0f))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", weapon_0.MinTargetAlt_ASL, 0) + " 米 海高 - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{weapon_0.MinTargetAlt_ASL * 3.28084f:0}" + " 英尺 海高 - ");
		}
		else if (weapon_0.MinTargetAlt_AGL <= 0f && (weapon_0.MaxTargetAlt_AGL > 0f || weapon_0.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", "n/a");
			text = text.Replace("<%TargetAltFeetMin%>", "n/a");
		}
		else if (weapon_0.MinTargetAlt_ASL <= 0f && (weapon_0.MaxTargetAlt_AGL > 0f || weapon_0.MaxTargetAlt_ASL > 0f))
		{
			text = text.Replace("<%TargetAltMin%>", "n/a");
			text = text.Replace("<%TargetAltFeetMin%>", "n/a");
		}
		else if (weapon_0.Type != Weapon._WeaponType.Torpedo && !weapon_0.IsMine)
		{
			text = text.Replace("<%TargetAltMin%>", "-");
			text = text.Replace("<%TargetAltFeetMin%>", "");
		}
		else if (weapon_0.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(weapon_0.ParentScen.DBConnection))
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", weapon_0.MinTargetAlt_ASL, 0) + " 米 - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{weapon_0.MinTargetAlt_ASL * 3.28084f:0}" + " 英尺 - ");
		}
		else
		{
			text = text.Replace("<%TargetAltMin%>", string.Format("{0:0.0}", weapon_0.MinTargetAlt_AGL, 0) + " 米 - ");
			text = text.Replace("<%TargetAltFeetMin%>", $"{weapon_0.MinTargetAlt_AGL * 3.28084f:0}" + " 英尺 - ");
		}
		if (weapon_0.MaxTargetAlt_AGL <= 0f)
		{
			if (weapon_0.MaxTargetAlt_ASL <= 0f)
			{
				if (weapon_0.Type != Weapon._WeaponType.Torpedo && !weapon_0.IsMine)
				{
					text = text.Replace("<%TargetAltMax%>", "");
					text = text.Replace("<%TargetAltFeetMax%>", "");
				}
				else if (weapon_0.ParentScen.FeatureCompatibility.GetWeaponAGL_ASL(weapon_0.ParentScen.DBConnection))
				{
					text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", weapon_0.MaxTargetAlt_ASL, 0) + " 米");
					text = text.Replace("<%TargetAltFeetMax%>", $"{weapon_0.MaxTargetAlt_ASL * 3.28084f:0}" + " 英尺, ");
				}
				else
				{
					text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", weapon_0.MaxTargetAlt_AGL, 0) + " 米");
					text = text.Replace("<%TargetAltFeetMax%>", $"{weapon_0.MaxTargetAlt_AGL * 3.28084f:0}" + " 英尺, ");
				}
			}
			else
			{
				text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", weapon_0.MaxTargetAlt_ASL, 0) + " 米 海高");
				text = text.Replace("<%TargetAltFeetMax%>", $"{weapon_0.MaxTargetAlt_ASL * 3.28084f:0}" + " 英尺 海高, ");
			}
		}
		else
		{
			text = text.Replace("<%TargetAltMax%>", string.Format("{0:0.0}", weapon_0.MaxTargetAlt_AGL, 0) + " 米 真高");
			text = text.Replace("<%TargetAltFeetMax%>", $"{weapon_0.MaxTargetAlt_AGL * 3.28084f:0}" + " 英尺 真高, ");
		}
		if (weapon_0.Kinematics.GetClimbRate_Nominal() <= 0f)
		{
			text = text.Replace("<%ClimbRate%>", "");
			text = text.Replace("<%ClimbRateFeetPrMin%>", "-");
		}
		else
		{
			text = text.Replace("<%ClimbRate%>", $"{weapon_0.Kinematics.GetClimbRate_Nominal():0.0}" + " 米/秒");
			text = text.Replace("<%ClimbRateFeetPrMin%>", $"{weapon_0.Kinematics.GetClimbRate_Nominal() * 3.28084f:0}" + " 英尺/分钟, ");
		}
		if (weapon_0.Type == Weapon._WeaponType.GuidedWeapon && weapon_0.IsAAW)
		{
			text = ((weapon_0.SnapUpDown <= 0f) ? text.Replace("<%SnapUpDownAltitude%>", "") : text.Replace("<%SnapUpDownAltitude%>", "<td>Snap Up / Down Altitude:</td><td colspan = 9>" + $"{weapon_0.SnapUpDown * 3.28084f:0}" + " 英尺, " + $"{weapon_0.SnapUpDown:0.0}" + " 米</td>"));
		}
		text = ((weapon_0.Type == Weapon._WeaponType.GuidedWeapon || weapon_0.Type == Weapon._WeaponType.Torpedo) ? text.Replace("<%GuidanceType%>", "<td>导航类型:</td><td colspan = 9>" + weapon_0.WeaponGuidanceTypeString + (weapon_0.Flags.ReAttack_Capability ? " - 能够重新攻击" : "") + "</td>") : text.Replace("<%GuidanceType%>", ""));
		List<float> list = new List<float>();
		try
		{
			list = DBFunctions.GetTorpedoKinematicRange(weapon_0.DBID, Client.CurrentScenario.DBConnection);
			if (list.Count <= 0)
			{
				text = text.Replace("<%TorpedoKinematicRangeCruise%>", "<td></td><td></td>");
				text = text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td></td>");
				return text;
			}
			text = ((list[0] <= 0f) ? text.Replace("<%TorpedoKinematicRangeCruise%>", "<td></td><td></td>") : text.Replace("<%TorpedoKinematicRangeCruise%>", "<td>机动范围:</td><td>" + Conversions.ToString(list[1]) + " 海里  " + Conversions.ToString(list[0]) + " 节</td>"));
			if (list[3] <= 0f)
			{
				text = text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td></td>");
				return text;
			}
			text = text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td>" + Conversions.ToString(list[3]) + " 海里  " + Conversions.ToString(list[2]) + " 节</td>");
			return text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			text = text.Replace("<%TorpedoKinematicRangeCruise%>", "<td></td><td></td>");
			text = text.Replace("<%TorpedoKinematicRangeFull%>", "<td></td><td></td>");
			exception_?.Data.Add("Error at 200375", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return text;
		}
	}

	public string Ship_General(Ship ship_0)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Ship.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact contact_ = new Contact(ship_0);
		string text2 = "";
		if (contact_.ActualUnit != null)
		{
			contact_.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			bool? nullable_ = true;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_), nullable_.Value) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(ship_0.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(ship_0.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(ship_0.InitialDP));
		text = text.Replace("<%Length%>", Conversions.ToString(ship_0.Length));
		text = text.Replace("<%Beam%>", Conversions.ToString(ship_0.Beam));
		text = text.Replace("<%Draft%>", Conversions.ToString(ship_0.Draft));
		text = text.Replace("<%Height%>", Conversions.ToString(ship_0.Height));
		text = text.Replace("<%Crew%>", Conversions.ToString(ship_0.Crew));
		text = ((ship_0.Displacement_Empty <= 0f) ? text.Replace("<%Displacement_Empty%>", "-") : text.Replace("<%Displacement_Empty%>", Conversions.ToString(ship_0.Displacement_Empty) + "吨"));
		text = text.Replace("<%Displacement_Standard%>", Conversions.ToString(ship_0.Displacement_Standard) + "吨");
		text = ((ship_0.Displacement_Full <= 0f) ? text.Replace("<%Displacement_Full%>", "-") : text.Replace("<%Displacement_Full%>", Conversions.ToString(ship_0.Displacement_Full) + "吨"));
		text = text.Replace("<%DockingPhysicalSize%>", Misc.Description(ship_0.DockingPhysicalSize, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%MaxSeaState%>", Conversions.ToString(ship_0.MaxSeaState));
		text = text.Replace("<%TroopCapacity%>", CargoHostHelper.TroopCapacityString(ship_0));
		text = text.Replace("<%CargoCapacity%>", CargoHostHelper.CargoCapacityString(ship_0));
		text = text.Replace("<%Armor_Belt%>", Misc.Description(ship_0.Armor_Belt, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Bulkhead%>", Misc.Description(ship_0.Armor_Bulkhead, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Deck%>", Misc.Description(ship_0.Armor_Deck, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Engineering%>", Misc.Description(ship_0.Armor_Engineering, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Bridge%>", Misc.Description(ship_0.Armor_Bridge, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_CIC%>", Misc.Description(ship_0.Armor_CIC, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Armor_Rudder%>", Misc.Description(ship_0.Armor_Rudder, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%CombatSystem%>", CombatSystem_Description(ship_0.UnitType, ship_0.CombatSystemGen));
		text = text.Replace("<%OODA%>", OODA_Description(ship_0.UnitType, ship_0.DBID, ship_0.CombatSystemGen));
		return text.Replace("<%MissileDefence%>", Conversions.ToString((int)ship_0.MissileDefense) + " 鱼雷 / 超音速低空导弹SLAM / Maverick 等效导弹");
	}

	public string Submarine_General(Submarine submarine_0)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Submarine.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact contact_ = new Contact(submarine_0);
		string text2 = "";
		if (contact_.ActualUnit != null)
		{
			contact_.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			submarine_0.SetCurrentAltitude(bool_0: false, -100f);
			bool? nullable_ = true;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_), nullable_.Value) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(submarine_0.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(submarine_0.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(submarine_0.InitialDP));
		text = text.Replace("<%Length%>", Conversions.ToString(submarine_0.Length));
		text = text.Replace("<%Beam%>", Conversions.ToString(submarine_0.Beam));
		text = text.Replace("<%Draft%>", Conversions.ToString(submarine_0.Draft));
		text = text.Replace("<%Height%>", Conversions.ToString(submarine_0.Height));
		text = text.Replace("<%Crew%>", Conversions.ToString(submarine_0.Crew));
		text = ((submarine_0.Displacement_Empty <= 0f) ? text.Replace("<%Displacement_Empty%>", "-") : text.Replace("<%Displacement_Empty%>", Conversions.ToString(submarine_0.Displacement_Empty) + "吨"));
		text = text.Replace("<%Displacement_Standard%>", Conversions.ToString(submarine_0.Displacement_Standard) + "吨");
		text = ((submarine_0.Displacement_Full <= 0f) ? text.Replace("<%Displacement_Full%>", "-") : text.Replace("<%Displacement_Full%>", Conversions.ToString(submarine_0.Displacement_Full) + "吨"));
		text = text.Replace("<%DockingPhysicalSize%>", Misc.Description(submarine_0.DockingPhysicalSize, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%ROVRadius%>", Conversions.ToString((int)submarine_0.ROVControlRadius_m));
		text = text.Replace("<%MaxDepth%>", Conversions.ToString(submarine_0.MaxDepth));
		text = text.Replace("<%OODA%>", OODA_Description(submarine_0.UnitType, submarine_0.DBID, 0));
		return text.Replace("<%CombatSystem%>", CombatSystem_Description(submarine_0.UnitType, submarine_0.CombatSystemGen));
	}

	public string Facility_General(Facility facility_0)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Facility.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact contact_ = new Contact(facility_0);
		string text2 = "";
		if (contact_.ActualUnit != null)
		{
			contact_.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			bool? nullable_ = true;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_), nullable_.Value) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(facility_0.Category, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(facility_0.GetDamagePts()));
		text = text.Replace("<%Length%>", Conversions.ToString(facility_0.Length));
		text = text.Replace("<%Width%>", Conversions.ToString(facility_0.Width));
		text = text.Replace("<%Area%>", Conversions.ToString(facility_0.Area));
		text = text.Replace("<%Crew%>", Conversions.ToString(facility_0.Crew));
		text = text.Replace("<%Armor_General%>", Misc.Description(facility_0.Armor_General, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%MastHeight%>", Conversions.ToString(facility_0.MastHeight));
		text = text.Replace("<%AimpointDispersalRadius%>", Conversions.ToString(facility_0.AimpointDispersalRadius));
		text = text.Replace("<%OODA%>", OODA_Description(facility_0.UnitType, facility_0.DBID, 0));
		text = text.Replace("<%CombatSystem%>", CombatSystem_Description(facility_0.UnitType, facility_0.CombatSystemGen));
		text = text.Replace("<%MissileDefence%>", Conversions.ToString(facility_0.MissileDefense) + " 鱼雷 / 超音速低空导弹SLAM / Maverick 等效导弹");
		if (facility_0.RepresentsMobileGroundUnit)
		{
			text = text.Replace("<%FireOnTheMove%>", facility_0.CanFireOnTheMove ? "Unit Can Fire on the Move" : "Unit Must Halt to Fire");
		}
		return text;
	}

	public string Satellite_General(Satellite satellite_0)
	{
		string text = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>";
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Satellite.html"));
		using (streamReader)
		{
			text += streamReader.ReadToEnd();
		}
		text += "<br/>";
		Contact contact_ = new Contact(satellite_0);
		string text2 = "";
		if (contact_.ActualUnit != null)
		{
			contact_.IDStatusBypassIdentification = Contact_Base.IdentificationStatus.KnownClass;
			bool? nullable_ = true;
			text2 = " (WRA: " + Doctrine.WRA_TargetType_String(Doctrine.WRA_DetermineTargetType(ref contact_, null, ref nullable_), nullable_.Value) + ")";
		}
		text = text.Replace("<%Category%>", Misc.Description(satellite_0.Category, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%Type%>", Misc.Description(satellite_0.Type, Client.CurrentScenario.DBConnection) + text2);
		text = text.Replace("<%DamagePts%>", Conversions.ToString(satellite_0.InitialDP));
		text = text.Replace("<%Length%>", Conversions.ToString(satellite_0.Length));
		text = text.Replace("<%Span%>", Conversions.ToString(satellite_0.Span));
		text = text.Replace("<%Height%>", Conversions.ToString(satellite_0.Height));
		text = text.Replace("<%WeightEmpty%>", Conversions.ToString(satellite_0.WeightEmpty));
		text = text.Replace("<%WeightMax%>", Conversions.ToString(satellite_0.WeightMax));
		text = text.Replace("<%WeightPayload%>", Conversions.ToString(satellite_0.WeightPayload));
		text = text.Replace("<%Armor%>", Misc.Description(satellite_0.Armor, Client.CurrentScenario.DBConnection));
		text = text.Replace("<%OODA%>", "-");
		return text.Replace("<%Crew%>", "-");
	}

	public string DisplayImage(ActiveUnit activeUnit_0)
	{
		string string_ = StrategyRegistryFilter.ConnectInterruptibleComparator(activeUnit_0);
		List<string> list_ = StrategyRegistryFilter.MoveInterruptibleComparator(activeUnit_0);
		return DisplayImage(string_, list_);
	}

	public string DisplaySensorImage(int int_0)
	{
		if (Client.CurrentScenario == null)
		{
			return string.Empty;
		}
		string string_ = StrategyRegistryFilter.DeleteInterruptibleComparator(Client.CurrentScenario.DBUsed, int_0);
		List<string> list_ = StrategyRegistryFilter.AddInterruptibleComparator(Client.CurrentScenario.DBUsed, int_0);
		return DisplayImage(string_, list_);
	}

	public string DisplayImage(string string_1, List<string> list_0)
	{
		if (list_0.Count == 0)
		{
			return string.Empty;
		}
		string text = list_0[0];
		string text2 = list_0[1];
		string text3 = list_0[2];
		string text4 = list_0[3];
		string text5 = list_0[4];
		string text6 = list_0[5];
		if (FileExistsNative.FileExistsFast(string_1) && new FileInfo(string_1).Length == 0)
		{
			try
			{
				File.Delete(string_1);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
		}
		foreach (string item in list_0)
		{
			if (FileExistsNative.FileExistsFast(item) && new FileInfo(item).Length == 0)
			{
				try
				{
					File.Delete(item);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					_ = Debugger.IsAttached;
					ProjectData.ClearProjectError();
				}
			}
		}
		if (SimConfiguration.DefaultGamePreferences.AllowInGameDownloads)
		{
			if (!FileExistsNative.FileExistsFast(string_1))
			{
				StrategyRegistryFilter.CustomizeInterruptibleComparator(string_1);
			}
			foreach (string item2 in list_0)
			{
				if (!FileExistsNative.FileExistsFast(item2))
				{
					StrategyRegistryFilter.CustomizeInterruptibleComparator(item2);
				}
			}
		}
		string text7;
		if (FileExistsNative.FileExistsFast(string_1))
		{
			text7 = "<div><table width='100%'><tr><td width='10%'><td><td width='80%' align='center'><img src='" + string_1 + "' width='900px'  style='float:middle;margin:0 5px 5px 0;' /></td><td width='10%'></td></tr></table></div><br/>";
			if (FileExistsNative.FileExistsFast(text) || FileExistsNative.FileExistsFast(text2) || FileExistsNative.FileExistsFast(text3))
			{
				text7 += "<div align = 'center'>";
				if (FileExistsNative.FileExistsFast(text))
				{
					text7 = text7 + "<img src='" + text + "' width='250px' style='float:middle;margin:0 5px 5px 0;'/>";
				}
				if (FileExistsNative.FileExistsFast(text2))
				{
					text7 = text7 + "<img src='" + text2 + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				if (FileExistsNative.FileExistsFast(text3))
				{
					text7 = text7 + "<img src='" + text3 + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				text7 += "</div><br/>";
			}
			if (FileExistsNative.FileExistsFast(text4) || FileExistsNative.FileExistsFast(text5) || FileExistsNative.FileExistsFast(text6))
			{
				text7 += "<div align = 'center'>";
				if (FileExistsNative.FileExistsFast(text4))
				{
					text7 = text7 + "<img src='" + text4 + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				if (FileExistsNative.FileExistsFast(text5))
				{
					text7 = text7 + "<img src='" + text5 + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				if (FileExistsNative.FileExistsFast(text6))
				{
					text7 = text7 + "<img src='" + text6 + "' width='250px' style='float:middle;margin:0 5px 5px 0;' />";
				}
				text7 += "</div><br/>";
			}
		}
		else
		{
			text7 = "";
		}
		return text7;
	}

	public string DisplayIndentedImage(ActiveUnit activeUnit_0)
	{
		string text;
		if (activeUnit_0.IsAircraft)
		{
			text = "飞机";
		}
		else if (activeUnit_0.IsShip)
		{
			text = "舰船";
		}
		else if (activeUnit_0.IsSubmarine)
		{
			text = "潜艇";
		}
		else if (activeUnit_0.IsFacility)
		{
			text = "设施";
		}
		else if (activeUnit_0.IsMobileGroundUnit)
		{
			text = "GroundUnit";
		}
		else if (activeUnit_0.IsSatellite)
		{
			text = "卫星";
		}
		else
		{
			if (!activeUnit_0.IsWeapon)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return string.Empty;
			}
			text = "武器";
		}
		string text2 = "";
		switch (DBOps.GetDBRecordByHash(Client.CurrentScenario.DBUsed, ref _AccountContainer, bool_0: false, bool_1: false).DBID)
		{
		case 1:
			text2 = "DB3000";
			break;
		case 2:
			text2 = "CWDB";
			break;
		case 3:
			text2 = "WW2DB";
			break;
		}
		string text3 = Path.Combine(GameGeneral.DBFolderPath, "Images\\" + text2);
		if (!Directory.Exists(text3))
		{
			Directory.CreateDirectory(text3);
		}
		string text4 = Path.Combine(text3, text + "_" + Conversions.ToString(activeUnit_0.DBID) + "_i1.jpg");
		string text5 = Path.Combine(text3, text + "_" + Conversions.ToString(activeUnit_0.DBID) + "_i2.jpg");
		string text6 = Path.Combine(text3, text + "_" + Conversions.ToString(activeUnit_0.DBID) + "_i3.jpg");
		string text7 = Path.Combine(text3, text + "_" + Conversions.ToString(activeUnit_0.DBID) + "_i4.jpg");
		string text8;
		if (FileExistsNative.FileExistsFast(text4))
		{
			text8 = "<img src='" + text4 + "' width='200'/>";
			if (FileExistsNative.FileExistsFast(text5))
			{
				text8 = text8 + "<br><br><img src='" + text5 + "' width='200'/>";
			}
			if (FileExistsNative.FileExistsFast(text6))
			{
				text8 = text8 + "<br><br><img src='" + text6 + "' width='200'/>";
			}
			if (FileExistsNative.FileExistsFast(text7))
			{
				text8 = text8 + "<br><br><img src='" + text7 + "' width='200'/>";
			}
		}
		else
		{
			text8 = "";
		}
		return text8;
	}

	public string DisplaySensorDescription(string string_1, int int_0)
	{
		string text = "传感器";
		string text2 = StrategyRegistryFilter.ComputeInterruptibleComparator(string_1);
		string text3 = Path.Combine(GameGeneral.DBFolderPath, "Descriptions\\" + text2);
		if (!Directory.Exists(text3))
		{
			Directory.CreateDirectory(text3);
		}
		string path = Path.Combine(text3, text + "_" + Conversions.ToString(int_0) + ".txt");
		if (FileExistsNative.FileExistsFast(path))
		{
			StreamReader streamReader = new StreamReader(path);
			string text4 = "";
			using (streamReader)
			{
				text4 += streamReader.ReadToEnd();
			}
			text4 = HttpUtility.HtmlEncode(text4);
			return "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>简介</strong></span></div><div><span><table><tr><td valign='top'></td><td valign='top' style='font-family:Verdana;font-size:8pt;'>" + text4.Replace(Environment.NewLine, "<br/>") + "</td><tr></table></span></div> <br/>";
		}
		return "";
	}

	public string DisplayDescription(ActiveUnit activeUnit_0)
	{
		string text;
		if (activeUnit_0.IsAircraft)
		{
			text = "飞机";
		}
		else if (activeUnit_0.IsShip)
		{
			text = "舰船";
		}
		else if (activeUnit_0.IsSubmarine)
		{
			text = "潜艇";
		}
		else if (activeUnit_0.IsFacility)
		{
			text = "设施";
		}
		else if (activeUnit_0.IsMobileGroundUnit)
		{
			text = "GroundUnit";
		}
		else if (activeUnit_0.IsSatellite)
		{
			text = "卫星";
		}
		else
		{
			if (!activeUnit_0.IsWeapon)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return string.Empty;
			}
			text = "武器";
		}
		string text2 = "";
		switch (DBOps.GetDBRecordByHash(Client.CurrentScenario.DBUsed, ref _AccountContainer, bool_0: false, bool_1: false).DBID)
		{
		case 1:
			text2 = "DB3000";
			break;
		case 2:
			text2 = "CWDB";
			break;
		case 3:
			text2 = "WW2DB";
			break;
		}
		string text3 = Path.Combine(GameGeneral.DBFolderPath, "Descriptions\\" + text2);
		if (!Directory.Exists(text3))
		{
			Directory.CreateDirectory(text3);
		}
		string path = Path.Combine(text3, text + "_" + Conversions.ToString(activeUnit_0.DBID) + ".txt");
		if (FileExistsNative.FileExistsFast(path))
		{
			StreamReader streamReader = new StreamReader(path);
			string text4 = "";
			using (streamReader)
			{
				text4 += streamReader.ReadToEnd();
			}
			text4 = HttpUtility.HtmlEncode(text4);
			string text5 = "<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>简介</strong></span></div>";
			return text5 + "<div><span><table><tr><td valign='top'>" + DisplayIndentedImage(activeUnit_0) + "</td><td valign='top' style='font-family:Verdana;font-size:8pt;'>" + text4.Replace(Environment.NewLine, "<br/>") + "</td><tr></table></span></div> <br/>";
		}
		return "";
	}

	public string DisplaySensors(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.Sensors_Cached.Length != 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>传感器 / 电子设备</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>型号</td><td align='center'>最大范围</td><td>备注</td><td>性能</td>");
			stringBuilder.Append("<td width=75>Arcs</td>");
			stringBuilder.Append("</tr>");
			foreach (IGrouping<int, Sensor> item in from theS in activeUnit_0.Sensors_Cached
				group theS by theS.DBID)
			{
				Sensor sensor = item.ElementAtOrDefault(0);
				string text = "";
				if (Operators.CompareString("传感器" + Conversions.ToString(sensor.DBID), HighlightTarget, TextCompare: true) == 0)
				{
					text = "background-color:DarkGreen;";
				}
				stringBuilder.Append("<tr Name='Sensor" + Conversions.ToString(sensor.DBID) + "' style='" + text + "font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='top'>" + Conversions.ToString(item.Count()) + "x <a href=传感器_" + Conversions.ToString(sensor.DBID) + ">" + sensor.Name + "</a</td>");
				if (sensor.maxRange <= 0f)
				{
					stringBuilder.Append("<td align='center' valign='top'>-</td>");
				}
				else
				{
					switch (sensor.Type)
					{
					case Sensor.Sensor_Type.Infrared:
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Sensor.VolumeSearchRange_IR(sensor)) + " / " + Conversions.ToString(sensor.maxRange) + " 海里</td>");
						break;
					default:
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(sensor.maxRange) + " 海里</td>");
						break;
					case Sensor.Sensor_Type.Visual:
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Sensor.VolumeSearchRange_Visual(sensor)) + " / " + Conversions.ToString(sensor.maxRange) + " 海里</td>");
						break;
					}
				}
				stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
				stringBuilder.Append("<td valign='top'>");
				List<string> list = new List<string>();
				if ((sensor.Type == Sensor.Sensor_Type.Radar || sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.ECM || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.DippingSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.HullSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Type == Sensor.Sensor_Type.TowedArray_ActiveOnly || sensor.Type == Sensor.Sensor_Type.TowedArray_ActivePassive || sensor.Type == Sensor.Sensor_Type.TowedArray_PassiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActivePassive || sensor.Type == Sensor.Sensor_Type.VDS_PassiveOnly) && !sensor.m_IsMk1Eyeball)
				{
					Scenario scenario_ = Client.CurrentScenario;
					list.Add(DBFunctions.Get_Sensor_Generation_String(ref scenario_, (int)sensor.TechGeneration) + "技术");
				}
				if (sensor.Capabilities.AirSearch)
				{
					list.Add("空中搜索");
				}
				if (sensor.Capabilities.SurfaceSearch)
				{
					list.Add("水面搜索");
				}
				if (sensor.Capabilities.SubSearch)
				{
					list.Add("水下搜索");
				}
				if (sensor.Capabilities.Mine_Obstacle_Search)
				{
					list.Add("地雷和障碍物搜索");
				}
				if (sensor.Capabilities.LandSearch_Fixed)
				{
					list.Add("地面搜索（固定）");
				}
				if (sensor.Capabilities.LandSearch_Mobile)
				{
					list.Add("地面搜索（机动）");
				}
				if (sensor.Capabilities.GroundMappingOnly)
				{
					list.Add("仅地面映射");
				}
				if (sensor.Capabilities.NavigationOnly)
				{
					list.Add("仅导航");
				}
				if (sensor.Capabilities.SpaceSearch_ABM)
				{
					list.Add("ABM和太空搜索");
				}
				if (sensor.Capabilities.OTH_Backscatter)
				{
					list.Add("OTH（反向散射）");
				}
				if (sensor.Capabilities.OTH_SurfaceWave)
				{
					list.Add("OTH（水面波）");
				}
				if (sensor.Capabilities.TerrainAvoidanceFollowingOnly)
				{
					list.Add("地形躲避/跟随");
				}
				if (sensor.Capabilities.WeatherAndNavigationOnly)
				{
					list.Add("天气和导航");
				}
				if (sensor.Capabilities.WeatherOnly)
				{
					list.Add("仅限天气");
				}
				if (sensor.Codes.NCTR_JEM)
				{
					list.Add("敌我识别NCTR - JEM");
				}
				if (sensor.Codes.NCTR_NBILST)
				{
					list.Add("敌我识别NCTR - NBILST");
				}
				if (sensor.Type == Sensor.Sensor_Type.ESM && sensor.ESM_PreciseEmitterID)
				{
					list.Add("具体的发射器ID");
				}
				if (sensor.Capabilities.RangeInfo)
				{
					list.Add("范围信息");
				}
				if (sensor.Capabilities.AltitudeInfo)
				{
					list.Add("海拔高度信息");
				}
				if (sensor.Capabilities.SpeedInfo)
				{
					list.Add("速度信息");
				}
				if (sensor.Capabilities.HeadingInfo)
				{
					list.Add("朝向信息");
				}
				stringBuilder.Append(string.Join(", ", list));
				if (sensor.IsSensorInGroup > 0)
				{
					stringBuilder.Append("<br/>[Part of Sensor Group " + Conversions.ToString(sensor.IsSensorInGroup) + "]");
				}
				if (sensor.Type == Sensor.Sensor_Type.Radar)
				{
					if (sensor.SearchFreqs.Length != 0)
					{
						stringBuilder.Append("<br/>工作波段 (搜索 & 跟踪): ").Append(string.Join(" / ", sensor.SearchFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					}
					if (sensor.IlluminationFreqs.Length != 0)
					{
						stringBuilder.Append("<br/>工作波段 (FC / 照射): ").Append(string.Join(" / ", sensor.IlluminationFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					}
				}
				if ((sensor.IsOECM || sensor.IsDECM || sensor.IsSonar) && sensor.SearchFreqs.Length != 0)
				{
					stringBuilder.Append("<br/>工作波段: ").Append(string.Join(" / ", sensor.SearchFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='top'>");
				bool flag = true;
				if (item.Count() > 1)
				{
					PlatformComponent._Coverage coverage = null;
					PlatformComponent._Coverage coverage2 = null;
					foreach (Sensor item2 in item)
					{
						if (item2.Coverage.HasDefinedArcs && coverage == null)
						{
							coverage = item2.Coverage;
							coverage2 = item2.Coverage_Illuminate;
							continue;
						}
						if (!item2.Coverage.HasDefinedArcs || Operators.CompareString(item2.Coverage.ToXML(bool_0: false), coverage.ToXML(bool_0: false), TextCompare: true) == 0)
						{
							if (item2.Coverage_Illuminate.HasDefinedArcs && Operators.CompareString(item2.Coverage_Illuminate.ToXML(bool_0: true), coverage2.ToXML(bool_0: true), TextCompare: true) != 0)
							{
								flag = false;
								break;
							}
							continue;
						}
						flag = false;
						break;
					}
				}
				int num = 0;
				foreach (Sensor item3 in item)
				{
					if (flag && item.Count() > 1)
					{
						stringBuilder.Append("All sensors<br/>");
					}
					else if (!flag || (item.Count() > 1 && num < item.Count()))
					{
						num++;
						stringBuilder.Append("Sensor #" + Conversions.ToString(num) + "<br/>");
					}
					List<string> list_ = new List<string>();
					PlatformComponent._Coverage coverage3 = item3.Coverage;
					PlatformComponent platformComponent_ = item3;
					coverage3.ComponentArcString(ref platformComponent_, ref list_);
					Sensor sensor2 = (Sensor)platformComponent_;
					if (list_.Count > 0)
					{
						stringBuilder.Append(ShowArcImage(list_));
					}
					if (sensor2.Coverage_Illuminate != null && sensor2.Coverage_Illuminate.HasDefinedArcs)
					{
						List<string> list_2 = new List<string>();
						PlatformComponent._Coverage coverage_Illuminate = sensor2.Coverage_Illuminate;
						platformComponent_ = sensor2;
						coverage_Illuminate.ComponentArcString(ref platformComponent_, ref list_2);
						sensor2 = (Sensor)platformComponent_;
						if (list_2.Count > 0 && !list_.SequenceEqual(list_2))
						{
							stringBuilder.Append("<br/>Illuminates: ");
							stringBuilder.Append(ShowArcImage(list_2));
						}
					}
					if (!flag)
					{
						if (num < item.Count())
						{
							stringBuilder.Append("<br/>");
						}
						continue;
					}
					break;
				}
				stringBuilder.Append("</td></tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayMineCountermeasuresGear(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.MineCountermeasures.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>扫雷装置</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>型号</td><td>备注</td>");
			stringBuilder.Append("</tr>");
			foreach (IGrouping<int, Sensor> item in from theS in activeUnit_0.MineCountermeasures
				group theS by theS.DBID)
			{
				Sensor sensor = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='top'>" + Conversions.ToString(item.Count()) + "x " + sensor.Name + "</td>");
				stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayMounts(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.Mounts.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>挂架 / 弹药库 / 武器</strong></span></div>");
			stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>挂架 (枪炮/发射器/弹射器等)</span>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>挂架</td><td align='center'>容量</td><td align='center'>发射间隔</td><td align='center'>装甲</td><td align='center'>挂架传感器</td><td>武器数量（每挂架）</td>");
			stringBuilder.Append("<td>Notes</td><td width=75>Arcs</td>");
			stringBuilder.Append("</tr>");
			foreach (IGrouping<int, Mount> item in from theM in activeUnit_0.Mounts
				group theM by theM.DBID)
			{
				Mount Local_theM = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='top'>" + Conversions.ToString(item.Count()) + "x " + Local_theM.Name + "</td>");
				if ((Local_theM.MountMagazine.Capacity > 0) & (Strings.InStr(Local_theM.Name, "轨", CompareMethod.Text) > 0))
				{
					stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Local_theM.MountMagazine.Capacity) + "</td>");
				}
				else
				{
					stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Local_theM.MaxCapacity + Local_theM.MountMagazine.Capacity) + "</td>");
				}
				if ((Local_theM.MountMagazine.Capacity > 0) & (Strings.InStr(Local_theM.Name, "轨", CompareMethod.Text) > 0))
				{
					int int_ = 0;
					int int_2 = 0;
					if (Local_theM.RegisterTokenizer(ref int_, ref int_2) <= 1)
					{
						stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Local_theM.MountMagazine.ROF) + "</td>");
					}
					else
					{
						string[] array = new string[5]
						{
							"<td align='center' valign='top'>在轨: ",
							Conversions.ToString(Local_theM.ROF),
							"<br>齐射: ",
							null,
							null
						};
						int rOF = Local_theM.ROF;
						int rOF2 = Local_theM.MountMagazine.ROF;
						Mount mount = Local_theM;
						int_2 = 0;
						int_ = 0;
						array[3] = Conversions.ToString(rOF + rOF2 * mount.RegisterTokenizer(ref int_2, ref int_));
						array[4] = "</td>";
						stringBuilder.Append(string.Concat(array));
					}
				}
				else
				{
					stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(Local_theM.ROF) + "</td>");
				}
				stringBuilder.Append("<td align='center' valign='top'>" + Local_theM.ArmorRating.ToString() + "</td>");
				stringBuilder.Append("<td valign='top'>" + string.Join("<br/>", Local_theM.Sensors_ReadOnly.Select((Sensor theS) => theS.Name).ToArray()) + "</td>");
				stringBuilder.Append("<td valign='top'>");
				foreach (WeaponRec mountWeapon in Local_theM.MountWeapons)
				{
					Weapon referenceWeapon = mountWeapon.GetReferenceWeapon(Client.CurrentScenario);
					stringBuilder.Append((mountWeapon.CurrentLoad == 0) ? "<i>" : "");
					stringBuilder.Append(Conversions.ToString(mountWeapon.CurrentLoad) + "x <a href=武器_" + Conversions.ToString(referenceWeapon.DBID) + ">" + referenceWeapon.Name + "</a>");
					foreach (WeaponRec weapon in Local_theM.MountMagazine.Weapons)
					{
						if (weapon.int_0 == mountWeapon.int_0)
						{
							stringBuilder.Append("(+" + Conversions.ToString(weapon.CurrentLoad) + "在挂载弹药库中）");
						}
					}
					stringBuilder.Append((mountWeapon.CurrentLoad == 0) ? "</i>" : "");
					if (!referenceWeapon.IsDecoy)
					{
						stringBuilder.Append("<br/><font style='color:gray'>" + WeaponSummary(activeUnit_0, referenceWeapon) + "</font>");
					}
					stringBuilder.Append("<br/>");
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='top'>");
				if (Local_theM.CompatibleDirectors.Count > 0)
				{
					IEnumerable<IGrouping<int, Sensor>> enumerable = from theS in activeUnit_0.Sensors_Cached
						where Local_theM.CompatibleDirectors.Contains(theS.DBID)
						group theS by theS.DBID;
					if (enumerable.Count() > 0)
					{
						List<string> list = new List<string>();
						foreach (IGrouping<int, Sensor> item2 in enumerable)
						{
							list.Add(item2.ElementAtOrDefault(0).Name);
						}
						stringBuilder.Append("可以由以下单元引导：" + string.Join(", ", list) + ". ");
					}
				}
				if (Local_theM.LocalControl)
				{
					stringBuilder.Append("可以进行局部控制");
				}
				if (Local_theM.IsAutonomous)
				{
					stringBuilder.Append("自主运行（无OODA延迟）。");
				}
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td valign='top'>");
				bool flag = true;
				if (item.Count() > 1)
				{
					PlatformComponent._Coverage coverage = null;
					foreach (Mount item3 in item)
					{
						if (item3.Coverage.HasDefinedArcs && coverage == null)
						{
							coverage = item3.Coverage;
						}
						else if (item3.Coverage.HasDefinedArcs && Operators.CompareString(item3.Coverage.ToXML(bool_0: false), coverage.ToXML(bool_0: false), TextCompare: true) != 0)
						{
							flag = false;
							break;
						}
					}
				}
				int num = 0;
				foreach (Mount item4 in item)
				{
					if (flag && item.Count() > 1)
					{
						stringBuilder.Append("All mounts<br/>");
					}
					else if (!flag || (item.Count() > 1 && num < item.Count()))
					{
						num++;
						stringBuilder.Append("Mount #" + Conversions.ToString(num) + "<br/>");
					}
					List<string> list_ = new List<string>();
					PlatformComponent._Coverage coverage2 = item4.Coverage;
					PlatformComponent platformComponent_ = item4;
					coverage2.ComponentArcString(ref platformComponent_, ref list_);
					if (list_.Count > 0)
					{
						stringBuilder.Append(ShowArcImage(list_));
					}
					if (!flag)
					{
						if (num < item.Count())
						{
							stringBuilder.Append("<br/>");
						}
						continue;
					}
					break;
				}
				stringBuilder.Append("</td></tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayStores(Aircraft aircraft_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int dBID = aircraft_0.DBID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		if (DBFunctions.WeaponsCarriedByThisAircraft(dBID, ref sqliteConnection_).Count > 0)
		{
			if (aircraft_0.Mounts.Count == 0)
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>挂架 / 弹药库 / 武器</strong></span></div>");
			}
			stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>飞机可挂载武器和装备</span>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>可挂载武器和装备</td><td align='center'>发射/投放速度要求</td><td align='center'>发射/投放高度要求</td><td>描述</td>");
			stringBuilder.Append("</tr>");
			List<int>.Enumerator enumerator = default(List<int>.Enumerator);
			try
			{
				int dBID2 = aircraft_0.DBID;
				sqliteConnection_ = Client.CurrentScenario.DBConnection;
				enumerator = DBFunctions.WeaponsCarriedByThisAircraft(dBID2, ref sqliteConnection_).GetEnumerator();
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					Weapon weapon = Client.CurrentScenario.Cache_GetWeapon(current);
					stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
					stringBuilder.Append("<td valign='top'>" + weapon.Name + "</td>");
					string text = ((weapon.MinLaunchSpeed > 0 || weapon.MaxLaunchSpeed > 0) ? (Conversions.ToString(weapon.MinLaunchSpeed) + " - " + Conversions.ToString(weapon.MaxLaunchSpeed) + "节") : "");
					string text2;
					if (weapon.MinLaunchAlt_AGL <= 0f && weapon.MaxLaunchAlt_AGL <= 0f && weapon.MinLaunchAlt_ASL <= 0f && weapon.MaxLaunchAlt_ASL <= 0f)
					{
						text2 = "";
					}
					else
					{
						string text3 = "";
						string text4 = "";
						float num;
						if (weapon.MinLaunchAlt_AGL == 0f)
						{
							num = weapon.MinLaunchAlt_ASL;
							text3 = " 海高";
						}
						else
						{
							num = weapon.MinLaunchAlt_AGL;
							text3 = " 真高";
						}
						float num2;
						if (weapon.MaxLaunchAlt_AGL == 0f)
						{
							num2 = weapon.MaxLaunchAlt_ASL;
							text4 = " 海高";
						}
						else
						{
							num2 = weapon.MaxLaunchAlt_AGL;
							text4 = " 真高";
						}
						text2 = $"{num * 3.28084f:0}" + " 英尺" + text3 + " - " + $"{num2 * 3.28084f:0}" + " 英尺" + text4 + "<br>" + $"{num:0.0}" + " 米" + text3 + " - " + $"{num2:0.0}" + " 米" + text4;
					}
					stringBuilder.Append("<td valign='top' align='center'>" + text + "</td>");
					stringBuilder.Append("<td valign='top' align='center'>" + text2 + "</td>");
					if (!weapon.IsDecoy && !weapon.IsFuelTank && weapon.Type != Weapon._WeaponType.SensorPod)
					{
						stringBuilder.Append("<td valign='top' align='left'>" + WeaponSummary(aircraft_0, weapon) + "</td>");
					}
					else
					{
						stringBuilder.Append("<td valign='top' align='left'>" + Misc.ForgotRequest(weapon.Type) + "</td>");
					}
					stringBuilder.Append("</tr>");
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayLoadouts(Aircraft aircraft_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int dBID = aircraft_0.DBID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Scenario currentScenario = Client.CurrentScenario;
		bool bool_ = false;
		Scenario scenario_ = null;
		Aircraft aircraft_ = null;
		int int_ = 0;
		bool bool_2 = false;
		DataTable dataTable = DBFunctions.LoadoutsForThisAircraft_DT(dBID, null, ref sqliteConnection_, currentScenario, ref bool_, ref scenario_, ref aircraft_, ref int_, ref bool_2);
		if (dataTable.Rows.Count > 0)
		{
			bool num = aircraft_0.Mounts.Count == 0;
			int dBID2 = aircraft_0.DBID;
			sqliteConnection_ = Client.CurrentScenario.DBConnection;
			if (num & (DBFunctions.WeaponsCarriedByThisAircraft(dBID2, ref sqliteConnection_).Count == 0))
			{
				stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>挂架 / 弹药库 / 武器</strong></span></div>");
			}
			stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>飞机挂载方案</span>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>名称</td><td>弹药</td><td>作战半径和性能参数</td><td align='center'>准备时间</td><td align='center'>白天/夜晚 & 天气</td><td align='center'>预置武器状态</td><td>数据库 ID#</td></td>");
			stringBuilder.Append("</tr>");
			IEnumerator enumerator = null;
			try
			{
				enumerator = dataTable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					DBFunctions.GetLoadout(ref aircraft_0, Conversions.ToInteger(dataRow["ID"]), bool_0: false);
					Loadout loadout = aircraft_0.Loadout;
					if (loadout == null)
					{
						stringBuilder.Append("<td> </td><td></td><td align='center' valign='middle'> ** MISSING DATA ON LOADOUT **</td>");
						stringBuilder.Append("<td align='center' valign='middle'>-</td><td align='center' valign='middle'>-</td><td align='center' valign='middle'>-</td>");
						stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToInteger(dataRow["ID"])) + "</td>");
						stringBuilder.Append("</tr>");
						continue;
					}
					string text = "";
					if (!string.IsNullOrEmpty(HighlightTarget) && Operators.CompareString("挂载" + Conversions.ToString(loadout.DBID), HighlightTarget, TextCompare: true) == 0)
					{
						text = "background-color:DarkGreen;";
					}
					stringBuilder.Append("<tr name='Loadout" + Conversions.ToString(loadout.DBID) + "' style='" + text + "font-family:Verdana;font-size:8pt;'>");
					stringBuilder.Append("<td valign='middle'>" + loadout.Name);
					if (loadout.Role != Loadout.LoadoutRole.Ferry && loadout.Role != Loadout.LoadoutRole.Reserve && loadout.Role != Loadout.LoadoutRole.Unavailable)
					{
						stringBuilder.Append("<br>(" + Misc.Description(loadout.Role, Client.CurrentScenario.DBConnection) + ")");
					}
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td valign='middle'>");
					WeaponRec[] weapons = loadout.Weapons;
					WeaponRec[] array = weapons;
					foreach (WeaponRec weaponRec in array)
					{
						stringBuilder.Append(Conversions.ToString(weaponRec.CurrentLoad) + "x <a href=武器_" + Conversions.ToString(weaponRec.GetReferenceWeapon(Client.CurrentScenario).DBID) + ">" + weaponRec.GetReferenceWeapon(Client.CurrentScenario).Name + "</a><br/>");
					}
					stringBuilder.Append(loadout.RequiresBuddyIllumination ? "<br/></br>需要外部照射." : "");
					stringBuilder.Append("</td>");
					stringBuilder.Append("<td valign='middle'>");
					string text2 = "";
					string text3;
					if (Information.IsNothing(loadout.GetMissionProfile(Client.CurrentScenario)))
					{
						text3 = "n/a";
					}
					else
					{
						text3 = loadout.GetMissionProfile(Client.CurrentScenario).Description;
						text2 = ((loadout.GetMissionProfile(Client.CurrentScenario).DBID == 1001) ? "" : ((loadout.TimeOnStation_Minutes <= 0) ? (Conversions.ToString(loadout.CombatRadius) + " 海里 ") : (Conversions.ToString((int)loadout.TimeOnStation_Minutes) + "分钟" + Conversions.ToString(loadout.CombatRadius) + " 海里 ")));
					}
					text3 = text2 + text3;
					stringBuilder.Append(text3);
					if (loadout.Cargo_Type != 0)
					{
						stringBuilder.Append("<br/>");
						switch (loadout.Cargo_Type)
						{
						case CargoType.SmallCargo:
							stringBuilder.Append("货物：小");
							break;
						case CargoType.Personnel:
							stringBuilder.Append("货物：人员");
							break;
						case CargoType.const_5:
							stringBuilder.Append("货物：非常大");
							break;
						case CargoType.LargeCargo:
							stringBuilder.Append("货物：大");
							break;
						case CargoType.MediumCargo:
							stringBuilder.Append("货物：中等");
							break;
						}
					}
					if (loadout.Cargo_ParadropCapable)
					{
						stringBuilder.Append(" &amp; ");
						stringBuilder.Append("可用降落伞空投");
					}
					stringBuilder.Append("</td>");
					string text4 = ((loadout.ReadyTime <= 0) ? "" : Misc.UpdateRequest(loadout.ReadyTime * 60));
					stringBuilder.Append("<td align='center' valign='middle'>" + text4 + "</td>");
					stringBuilder.Append("<td align='center' valign='middle'>" + Misc.Description(loadout.TimeOfDay) + "<br/>" + Misc.Description(loadout.Weather) + "</td>");
					string text5;
					if (Client.CurrentScenario.FeatureCompatibility.GetWeaponAGL_ASL(Client.CurrentScenario.DBConnection))
					{
						int dBID3 = loadout.DBID;
						Doctrine._WeaponState winchesterShotgun = loadout.WinchesterShotgun;
						sqliteConnection_ = Client.CurrentScenario.DBConnection;
						text5 = DBFunctions.GetLoadoutWeaponStateDescription(dBID3, (int)winchesterShotgun, ref sqliteConnection_, Client.CurrentScenario, bool_0: false, loadout.Role);
					}
					else
					{
						text5 = "温彻斯特：任务相关武器已经用完。立即撤离。";
					}
					stringBuilder.Append("<td align='center' valign='middle'>" + text5 + "</td>");
					stringBuilder.Append("<td>" + Conversions.ToString(loadout.DBID) + "</td>");
					stringBuilder.Append("</tr>");
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplaySensors(Sensor sensor_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Sensor sensor = sensor_0;
		List<string> list = new List<string>();
		float float_ = -1f;
		float float_2 = -1f;
		float float_3 = -1f;
		float float_4 = -1f;
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>基本参数</strong></span></div>");
		stringBuilder.Append("<table border='0'><tr style='font-family: Verdana;font-size:10pt;'>");
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		stringBuilder.Append("<td>Category : </td><td>" + DBFunctions.Get_Sensor_Type_String(ref sqliteConnection_, (int)sensor.Type) + "</td>");
		stringBuilder.Append("</table><br/>");
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>传感器 / 电子设备</strong></span></div>");
		stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
		stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
		stringBuilder.Append("<td align='center'>Min/Max Range</td><td>Role</td><td>Abilities</td><td>Scan Interval</td>");
		stringBuilder.Append("</tr>");
		if (sensor.Type == Sensor.Sensor_Type.SensorGroup)
		{
			SQLiteHelper sqliteHelper_ = new SQLiteHelper(Client.CurrentScenario.DBConnection);
			string text = "Select ComponentID from DataSensorSensorGroups where ID = " + Conversions.ToString(sensor.DBID);
			DataTable datatable = DBCache.GetDatatable(sqliteHelper_, text);
			IEnumerator enumerator = null;
			try
			{
				enumerator = datatable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					int int_ = Conversions.ToInteger(((DataRow)enumerator.Current)["ComponentID"]);
					sqliteConnection_ = Client.CurrentScenario.DBConnection;
					sensor = DBFunctions.GetSensor(int_, ref sqliteConnection_);
					sensor.VisualIRZoom(ref float_, ref float_2, ref float_3, ref float_4);
					stringBuilder.Append("<tr Name='Sensor" + Conversions.ToString(sensor.DBID) + "' style='font-family:Verdana;font-size:8pt;'>");
					stringBuilder.Append("<td align='center' valign='top'>");
					if (sensor.minRange <= 0f && sensor.maxRange <= 0f)
					{
						stringBuilder.Append("</td>");
					}
					else
					{
						if (sensor.minRange <= 0f)
						{
							stringBuilder.Append("- / ");
						}
						else
						{
							stringBuilder.Append(Conversions.ToString(sensor.minRange) + " / ");
						}
						if (sensor.maxRange <= 0f)
						{
							stringBuilder.Append("-");
						}
						else
						{
							stringBuilder.Append(sensor.maxRange);
						}
						stringBuilder.Append(" 海里</td>");
					}
					stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
					stringBuilder.Append("<td valign='top'>");
					list.Clear();
					if ((sensor.Type == Sensor.Sensor_Type.Radar || sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.ECM || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.DippingSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.HullSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Type == Sensor.Sensor_Type.TowedArray_ActiveOnly || sensor.Type == Sensor.Sensor_Type.TowedArray_ActivePassive || sensor.Type == Sensor.Sensor_Type.TowedArray_PassiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActivePassive || sensor.Type == Sensor.Sensor_Type.VDS_PassiveOnly) && !sensor.m_IsMk1Eyeball)
					{
						Scenario scenario_ = Client.CurrentScenario;
						list.Add(DBFunctions.Get_Sensor_Generation_String(ref scenario_, (int)sensor.TechGeneration) + "技术");
					}
					if (sensor.Capabilities.AirSearch)
					{
						list.Add("空中搜索");
					}
					if (sensor.Capabilities.SurfaceSearch)
					{
						list.Add("水面搜索");
					}
					if (sensor.Capabilities.SubSearch)
					{
						list.Add("水下搜索");
					}
					if (sensor.Capabilities.Mine_Obstacle_Search)
					{
						list.Add("地雷和障碍物搜索");
					}
					if (sensor.Capabilities.LandSearch_Fixed)
					{
						list.Add("地面搜索（固定）");
					}
					if (sensor.Capabilities.LandSearch_Mobile)
					{
						list.Add("地面搜索（机动）");
					}
					if (sensor.Capabilities.GroundMappingOnly)
					{
						list.Add("仅地面映射");
					}
					if (sensor.Capabilities.NavigationOnly)
					{
						list.Add("仅导航");
					}
					if (sensor.Capabilities.SpaceSearch_ABM)
					{
						list.Add("ABM和太空搜索");
					}
					if (sensor.Capabilities.OTH_Backscatter)
					{
						list.Add("OTH（反向散射）");
					}
					if (sensor.Capabilities.OTH_SurfaceWave)
					{
						list.Add("OTH（水面波）");
					}
					if (sensor.Capabilities.TerrainAvoidanceFollowingOnly)
					{
						list.Add("地形躲避/跟随");
					}
					if (sensor.Capabilities.WeatherAndNavigationOnly)
					{
						list.Add("天气和导航");
					}
					if (sensor.Capabilities.WeatherOnly)
					{
						list.Add("仅限天气");
					}
					if (sensor.Codes.NCTR_JEM)
					{
						list.Add("敌我识别NCTR - JEM");
					}
					if (sensor.Codes.NCTR_NBILST)
					{
						list.Add("敌我识别NCTR - NBILST");
					}
					if (sensor.Type == Sensor.Sensor_Type.ESM && sensor.ESM_PreciseEmitterID)
					{
						list.Add("具体的发射器ID");
					}
					if (sensor.Capabilities.RangeInfo)
					{
						list.Add("范围信息");
					}
					if (sensor.Capabilities.AltitudeInfo)
					{
						list.Add("海拔高度信息");
					}
					if (sensor.Capabilities.SpeedInfo)
					{
						list.Add("速度信息");
					}
					if (sensor.Capabilities.HeadingInfo)
					{
						list.Add("朝向信息");
					}
					stringBuilder.Append(string.Join(", ", list));
					if (sensor.Type == Sensor.Sensor_Type.Radar)
					{
						if (sensor.SearchFreqs.Length != 0)
						{
							stringBuilder.Append("<br/>工作波段 (搜索 & 跟踪): ").Append(string.Join(" / ", sensor.SearchFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
						}
						if (sensor.IlluminationFreqs.Length != 0)
						{
							stringBuilder.Append("<br/>工作波段 (FC / 照射): ").Append(string.Join(" / ", sensor.IlluminationFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
						}
					}
					else if (sensor.Codes.GeneratesAAWFireControl)
					{
						stringBuilder.Append("<br/>Generates AAW fire-control data");
					}
					if ((sensor.IsOECM || sensor.IsDECM || sensor.IsSonar) && sensor.SearchFreqs.Length != 0)
					{
						stringBuilder.Append("<br/>工作波段: ").Append(string.Join(" / ", sensor.SearchFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
					}
					if (sensor.CanPerformIllumination)
					{
						stringBuilder.Append("<br/>Max Target Illumination: ").Append(sensor.MaxIlluminate);
					}
					switch (sensor.Type)
					{
					case Sensor.Sensor_Type.Infrared:
						if (float_4 < float_3)
						{
							stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0} / {1}", float_3, float_4);
						}
						else
						{
							stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0}", float_4);
						}
						break;
					case Sensor.Sensor_Type.Visual:
						if (float_2 < float_)
						{
							stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0} / {1}", float_, float_2);
						}
						else
						{
							stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0}", float_2);
						}
						break;
					}
					stringBuilder.Append("</td>");
					if (sensor.ScanInterval == 0)
					{
						stringBuilder.Append("<td/>");
					}
					else
					{
						stringBuilder.Append("<td valign='top'>" + Conversions.ToString(sensor.ScanInterval) + "</td>");
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
		else
		{
			sensor.VisualIRZoom(ref float_, ref float_2, ref float_3, ref float_4);
			stringBuilder.Append("<tr Name='Sensor" + Conversions.ToString(sensor.DBID) + "' style='font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td align='center' valign='top'>");
			if (sensor.minRange <= 0f && sensor.maxRange <= 0f)
			{
				stringBuilder.Append("</td>");
			}
			else
			{
				if (sensor.minRange <= 0f)
				{
					stringBuilder.Append("- / ");
				}
				else
				{
					stringBuilder.Append(Conversions.ToString(sensor.minRange) + " / ");
				}
				if (sensor.maxRange <= 0f)
				{
					stringBuilder.Append("-");
				}
				else
				{
					stringBuilder.Append(sensor.maxRange);
				}
				stringBuilder.Append(" 海里</td>");
			}
			stringBuilder.Append("<td valign='top'>" + sensor.RoleDescription + "</td>");
			stringBuilder.Append("<td valign='top'>");
			if ((sensor.Type == Sensor.Sensor_Type.Radar || sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.ECM || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.DippingSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.DippingSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActiveOnly || sensor.Type == Sensor.Sensor_Type.HullSonar_ActivePassive || sensor.Type == Sensor.Sensor_Type.HullSonar_PassiveOnly || sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Type == Sensor.Sensor_Type.TowedArray_ActiveOnly || sensor.Type == Sensor.Sensor_Type.TowedArray_ActivePassive || sensor.Type == Sensor.Sensor_Type.TowedArray_PassiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActiveOnly || sensor.Type == Sensor.Sensor_Type.VDS_ActivePassive || sensor.Type == Sensor.Sensor_Type.VDS_PassiveOnly) && !sensor.m_IsMk1Eyeball)
			{
				Scenario scenario_2 = Client.CurrentScenario;
				list.Add(DBFunctions.Get_Sensor_Generation_String(ref scenario_2, (int)sensor.TechGeneration) + "技术");
			}
			if (sensor.Capabilities.AirSearch)
			{
				list.Add("空中搜索");
			}
			if (sensor.Capabilities.SurfaceSearch)
			{
				list.Add("水面搜索");
			}
			if (sensor.Capabilities.SubSearch)
			{
				list.Add("水下搜索");
			}
			if (sensor.Capabilities.Mine_Obstacle_Search)
			{
				list.Add("地雷和障碍物搜索");
			}
			if (sensor.Capabilities.LandSearch_Fixed)
			{
				list.Add("地面搜索（固定）");
			}
			if (sensor.Capabilities.LandSearch_Mobile)
			{
				list.Add("地面搜索（机动）");
			}
			if (sensor.Capabilities.GroundMappingOnly)
			{
				list.Add("仅地面映射");
			}
			if (sensor.Capabilities.NavigationOnly)
			{
				list.Add("仅导航");
			}
			if (sensor.Capabilities.SpaceSearch_ABM)
			{
				list.Add("ABM和太空搜索");
			}
			if (sensor.Capabilities.OTH_Backscatter)
			{
				list.Add("OTH（反向散射）");
			}
			if (sensor.Capabilities.OTH_SurfaceWave)
			{
				list.Add("OTH（水面波）");
			}
			if (sensor.Capabilities.TerrainAvoidanceFollowingOnly)
			{
				list.Add("地形躲避/跟随");
			}
			if (sensor.Capabilities.WeatherAndNavigationOnly)
			{
				list.Add("天气和导航");
			}
			if (sensor.Capabilities.WeatherOnly)
			{
				list.Add("仅限天气");
			}
			if (sensor.Codes.NCTR_JEM)
			{
				list.Add("敌我识别NCTR - JEM");
			}
			if (sensor.Codes.NCTR_NBILST)
			{
				list.Add("敌我识别NCTR - NBILST");
			}
			if (sensor.Type == Sensor.Sensor_Type.ESM && sensor.ESM_PreciseEmitterID)
			{
				list.Add("具体的发射器ID");
			}
			if (sensor.Capabilities.RangeInfo)
			{
				list.Add("范围信息");
			}
			if (sensor.Capabilities.AltitudeInfo)
			{
				list.Add("海拔高度信息");
			}
			if (sensor.Capabilities.SpeedInfo)
			{
				list.Add("速度信息");
			}
			if (sensor.Capabilities.HeadingInfo)
			{
				list.Add("朝向信息");
			}
			stringBuilder.Append(string.Join(", ", list));
			if (sensor.Type == Sensor.Sensor_Type.Radar)
			{
				if (sensor.SearchFreqs.Length != 0)
				{
					stringBuilder.Append("<br/>工作波段 (搜索 & 跟踪): ").Append(string.Join(" / ", sensor.SearchFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				}
				if (sensor.IlluminationFreqs.Length != 0)
				{
					stringBuilder.Append("<br/>工作波段 (FC / 照射): ").Append(string.Join(" / ", sensor.IlluminationFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
				}
			}
			else if (sensor.Codes.GeneratesAAWFireControl)
			{
				stringBuilder.Append("<br/>Generates AAW fire-control data");
			}
			if ((sensor.IsOECM || sensor.IsDECM || sensor.IsSonar) && sensor.SearchFreqs.Length != 0)
			{
				stringBuilder.Append("<br/>工作波段: ").Append(string.Join(" / ", sensor.SearchFreqs.Select((Sensor.RadioElectronicFrequency theF) => theF.ToString_Short)));
			}
			if (sensor.CanPerformIllumination)
			{
				stringBuilder.Append("<br/>Max Target Illumination: ").Append(sensor.MaxIlluminate);
			}
			switch (sensor.Type)
			{
			case Sensor.Sensor_Type.Infrared:
				if (float_4 < float_3)
				{
					stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0} / {1}", float_3, float_4);
				}
				else
				{
					stringBuilder.Append("<br/>InfraRed Zoom Detection/Classification: ").AppendFormat("{0}", float_4);
				}
				break;
			case Sensor.Sensor_Type.Visual:
				if (float_2 < float_)
				{
					stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0} / {1}", float_, float_2);
				}
				else
				{
					stringBuilder.Append("<br/>Visual Zoom Detection/Classification: ").AppendFormat("{0}", float_2);
				}
				break;
			}
			stringBuilder.Append("</td>");
			if (sensor.ScanInterval == 0)
			{
				stringBuilder.Append("<td/>");
			}
			else
			{
				stringBuilder.Append("<td valign='top'>" + Conversions.ToString(sensor.ScanInterval) + "</td>");
			}
		}
		stringBuilder.Append("</tr>");
		stringBuilder.Append("</table>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	private string RateIterator(ref Aircraft aircraft_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (aircraft_0.XSections_ReadOnly.Count() > 0)
		{
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>Type</td><td align='center'>Front</td><td align='center'>Side</td><td align='center'>Rear</td>");
			stringBuilder.Append("</tr>");
		}
		XSection[] xSections_ReadOnly = aircraft_0.XSections_ReadOnly;
		XSection[] array = xSections_ReadOnly;
		foreach (XSection xSection in array)
		{
			if ((xSection.GetFront(aircraft_0) != 0f || xSection.GetSide(aircraft_0) != 0f || xSection.GetRear(aircraft_0) != 0f) && xSection.GetFront(aircraft_0) != -10000f && xSection.GetSide(aircraft_0) != -10000f && xSection.GetRear(aircraft_0) != -10000f && (xSection.SignatureType == XSection._SignatureType.Radar_A_D || xSection.SignatureType == XSection._SignatureType.Radar_E_M))
			{
				Tuple<float, float, float, float> value = null;
				BaseSignatures.TryGetValue(xSection.SignatureType, out value);
				Tuple<float, float, float, float> tuple = new Tuple<float, float, float, float>((float)Math.Round(xSection.GetFront(aircraft_0), 2), (float)Math.Round(xSection.GetSide(aircraft_0), 2), (float)Math.Round(xSection.GetRear(aircraft_0), 2), (float)Math.Round(xSection.GetTop(aircraft_0), 2));
				string text = "";
				if (tuple.Equals(value))
				{
					text = "background-color:DarkGreen;";
				}
				stringBuilder.Append("<tr style='" + text + "font-family: Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>" + DBFunctions.Description(xSection.SignatureType, Client.CurrentScenario) + "</td>");
				double num = Math.Pow(10.0, tuple.Item1 / 10f);
				double num2 = Math.Pow(10.0, tuple.Item2 / 10f);
				double num3 = Math.Pow(10.0, tuple.Item3 / 10f);
				string text2;
				string text3;
				string text4;
				if (num < 1.0 && num >= 0.1)
				{
					text2 = " 分贝平方米(dBsm), " + $"{num:0.00}" + "平方米";
					text3 = " 分贝平方米(dBsm), " + $"{num2:0.00}" + "平方米";
					text4 = " 分贝平方米(dBsm), " + $"{num3:0.00}" + "平方米";
				}
				else if (num < 0.1 && num >= 0.01)
				{
					text2 = " 分贝平方米(dBsm), " + $"{num:0.000}" + "平方米";
					text3 = " 分贝平方米(dBsm), " + $"{num2:0.000}" + "平方米";
					text4 = " 分贝平方米(dBsm), " + $"{num3:0.000}" + "平方米";
				}
				else if (num < 0.01 && num >= 0.001)
				{
					text2 = " 分贝平方米(dBsm), " + $"{num:0.0000}" + "平方米";
					text3 = " 分贝平方米(dBsm), " + $"{num2:0.0000}" + "平方米";
					text4 = " 分贝平方米(dBsm), " + $"{num3:0.0000}" + "平方米";
				}
				else if (num < 0.001 && num >= 0.0001)
				{
					text2 = " 分贝平方米(dBsm), " + $"{num:0.00000}" + "平方米";
					text3 = " 分贝平方米(dBsm), " + $"{num2:0.00000}" + "平方米";
					text4 = " 分贝平方米(dBsm), " + $"{num3:0.00000}" + "平方米";
				}
				else if (num < 0.0001 && num >= 1E-05)
				{
					text2 = " 分贝平方米(dBsm), " + $"{num:0.000000}" + "平方米";
					text3 = " 分贝平方米(dBsm), " + $"{num2:0.000000}" + "平方米";
					text4 = " 分贝平方米(dBsm), " + $"{num3:0.000000}" + "平方米";
				}
				else
				{
					text2 = " 分贝平方米(dBsm), " + $"{num:0.0}" + "平方米";
					text3 = " 分贝平方米(dBsm), " + $"{num2:0.0}" + "平方米";
					text4 = " 分贝平方米(dBsm), " + $"{num3:0.0}" + "平方米";
				}
				stringBuilder.Append("<td align='center'>" + $"{tuple.Item1:0.00}" + text2 + "</td>");
				stringBuilder.Append("<td align='center'>" + $"{tuple.Item2:0.00}" + text3 + "</td>");
				stringBuilder.Append("<td align='center'>" + $"{tuple.Item3:0.00}" + text4 + "</td>");
				stringBuilder.Append("</tr>");
			}
		}
		stringBuilder.Append("</table>");
		return stringBuilder.ToString();
	}

	public string DisplayMags(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.SharedMagazines.Length != 0)
		{
			stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>弹药库</span>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>弹药库</td><td align='center'>容量</td><td align='center'>重新装载速率</td><td align='center'>装甲</td><td>弹药储备</td>");
			stringBuilder.Append("</tr>");
			Magazine[] sharedMagazines = activeUnit_0.SharedMagazines;
			Magazine[] array = sharedMagazines;
			foreach (Magazine magazine in array)
			{
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td valign='top'>" + magazine.Name + "</td>");
				stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(magazine.Capacity) + "</td>");
				stringBuilder.Append("<td align='center' valign='top'>" + Conversions.ToString(magazine.ROF) + "</td>");
				stringBuilder.Append("<td align='center' valign='top'>" + magazine.Armor.ToString() + "</td>");
				stringBuilder.Append("<td valign='top'>" + string.Join("<br/>", magazine.Weapons.Select((WeaponRec theWR) => ((theWR.CurrentLoad == 0) ? "<i style='color:gray'>" : "") + Conversions.ToString(theWR.CurrentLoad) + "x " + theWR.GetReferenceWeapon(Client.CurrentScenario).Name + " (max " + Conversions.ToString(theWR.MaxLoad) + ")" + ((theWR.CurrentLoad == 0) ? "</i>" : "")).ToArray()) + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayComms(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.Comms_ReadOnly.Count() > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>通信设备 / 链路</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>名称</td><td align='center'>类型</td><td align='center'>最大距离</td><td align='center'>频道</td><td>属性</td>");
			stringBuilder.Append("</tr>");
			foreach (IGrouping<int, CommDevice> item in from theC in activeUnit_0.Comms_ReadOnly
				group theC by theC.DBID)
			{
				CommDevice commDevice = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>" + commDevice.Name + "</td>");
				stringBuilder.Append("<td align='center'>" + DBFunctions.Description(commDevice.Type, Client.CurrentScenario) + "</td>");
				if (commDevice.Range <= 0.0)
				{
					stringBuilder.Append("<td align='center'>-</td>");
				}
				else
				{
					stringBuilder.Append("<td align='center'>" + Conversions.ToString(commDevice.Range) + " 海里</td>");
				}
				if (commDevice.MaxChannels <= 0)
				{
					stringBuilder.Append("<td align='center'>-</td>");
				}
				else
				{
					stringBuilder.Append("<td align='center'>" + Conversions.ToString(commDevice.MaxChannels) + "</td>");
				}
				stringBuilder.Append("<td>");
				List<string> list = new List<string>();
				if (!commDevice.ParentSpecific)
				{
					list.Add("支持CEC");
				}
				if (commDevice.Flags.Broadcast)
				{
					list.Add("广播");
				}
				if (commDevice.Flags.ELF_Radio)
				{
					list.Add("ELF 电台");
				}
				if (commDevice.Flags.HF_Radio)
				{
					list.Add("HF 电台");
				}
				if (commDevice.Flags.LF_Radio)
				{
					list.Add("LF 电台");
				}
				if (commDevice.Flags.LOS_Limited)
				{
					list.Add("LOS限制");
				}
				if (commDevice.Flags.MF_Radio)
				{
					list.Add("MF 电台");
				}
				if (commDevice.Flags.Receive_Only)
				{
					list.Add("只接收");
				}
				if (commDevice.Flags.Secure)
				{
					list.Add("安全");
				}
				if (commDevice.Flags.Send_Only)
				{
					list.Add("只发送");
				}
				if (commDevice.Flags.SHF_Radio)
				{
					list.Add("SHF 电台");
				}
				if (commDevice.Flags.UHF_Radio)
				{
					list.Add("UHF 电台");
				}
				if (commDevice.Flags.VHF_Radio)
				{
					list.Add("VHF 电台");
				}
				if (commDevice.Flags.VLF_Radio)
				{
					list.Add("VLF 电台");
				}
				stringBuilder.Append(string.Join(", ", list) + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayAirFacilities(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.AirFacilities_ReadOnly.Length != 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>飞机保障设施</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>类型</td>");
			stringBuilder.Append("</tr>");
			foreach (IGrouping<int, AirFacility> item in from theAF in activeUnit_0.AirFacilities_ReadOnly
				group theAF by theAF.DBID)
			{
				AirFacility airFacility = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>" + Conversions.ToString(item.Count()) + "x " + airFacility.Name + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayDockingFacilities(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.DockFacilities_ReadOnly.Length != 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>停靠设施</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>类型</td>");
			stringBuilder.Append("</tr>");
			foreach (IGrouping<int, DockFacility> item in from theAF in activeUnit_0.DockFacilities_ReadOnly
				group theAF by theAF.DBID)
			{
				DockFacility dockFacility = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>" + Conversions.ToString(item.Count()) + "x " + dockFacility.Name + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayValidTargets(Weapon weapon_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (weapon_0.Type != Weapon._WeaponType.BuddyStore && weapon_0.Type != Weapon._WeaponType.Cargo && weapon_0.Type != Weapon._WeaponType.DropTank && weapon_0.Type != Weapon._WeaponType.FerryTank && weapon_0.Type != Weapon._WeaponType.HeliTowedPackage && weapon_0.Type != Weapon._WeaponType.None && weapon_0.Type != Weapon._WeaponType.Paratroops && weapon_0.Type != Weapon._WeaponType.SensorPod && weapon_0.Type != Weapon._WeaponType.TrainingRound && weapon_0.Type != Weapon._WeaponType.Troops && weapon_0.Type != Weapon._WeaponType.Sonobuoy)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>有效目标</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;background-;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>");
			List<string> validTargets_Description = weapon_0.ValidTargets_Description;
			string value = ((validTargets_Description.Count <= 0) ? "" : string.Join("<br/>", validTargets_Description));
			stringBuilder.Append(value);
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
			return stringBuilder.ToString();
		}
		return stringBuilder.ToString();
	}

	public string method_0(Weapon weapon_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Information.IsNothing(weapon_0.Doctrine.WRA))
		{
			return stringBuilder.ToString();
		}
		string[] restrictionValues = new string[4] { null, null, "EnumWeaponWRA", null };
		if (((DbConnection)weapon_0.ParentScen.DBConnection).GetSchema("Tables", restrictionValues).Rows.Count == 0)
		{
			return stringBuilder.ToString();
		}
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>武器投放授权(WRA) [默认]</strong></span></div>");
		stringBuilder.Append("<div style='color:Black;background-;font-family:Verdana;font-size:8pt;'>");
		stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
		stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
		stringBuilder.Append("<td>目标类型</td><td align='left'>齐射武器数量</td><td align='left'>齐射最大发射单元数量</td><td align='left'>自卫范围</td>");
		stringBuilder.Append("</tr>");
		foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item in weapon_0.Doctrine.WRA)
		{
			Doctrine.WRA_FiringDoctrineEntry[] wRA_WeaponTargets = item.Value.WRA_WeaponTargets;
			Doctrine.WRA_FiringDoctrineEntry[] array = wRA_WeaponTargets;
			foreach (Doctrine.WRA_FiringDoctrineEntry wRA_FiringDoctrineEntry in array)
			{
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(Doctrine.WRA_TargetType_String(wRA_FiringDoctrineEntry.TargetType, bool_0: false));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				Scenario scenario_ = Client.CurrentScenario;
				stringBuilder.Append(DBFunctions.Get_WRA_WeaponTargetType_WeaponQty_String(ref scenario_, wRA_FiringDoctrineEntry.WeaponQty.Value));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				scenario_ = Client.CurrentScenario;
				stringBuilder.Append(DBFunctions.Get_WRA_WeaponTargetType_ShooterQty_String(ref scenario_, wRA_FiringDoctrineEntry.ShooterQty.Value));
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				scenario_ = Client.CurrentScenario;
				stringBuilder.Append(DBFunctions.Get_WRA_WeaponTargetType_SelfDefenceRange_String(ref scenario_, (int)Math.Round(wRA_FiringDoctrineEntry.SelfDefenceRange.Value)));
				stringBuilder.Append("</td>");
				stringBuilder.Append("</tr>");
			}
		}
		stringBuilder.Append("</table>");
		stringBuilder.Append("</div>");
		stringBuilder.Append("<br/>");
		return stringBuilder.ToString();
	}

	public string DisplaySignatures(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		BaseSignatures.Clear();
		if (activeUnit_0.IsWeapon)
		{
			switch (((Weapon)activeUnit_0).Type)
			{
			case Weapon._WeaponType.None:
			case Weapon._WeaponType.Rocket:
			case Weapon._WeaponType.IronBomb:
			case Weapon._WeaponType.Gun:
			case Weapon._WeaponType.TrainingRound:
			case Weapon._WeaponType.Dispenser:
			case Weapon._WeaponType.SensorPod:
			case Weapon._WeaponType.DropTank:
			case Weapon._WeaponType.BuddyStore:
			case Weapon._WeaponType.FerryTank:
			case Weapon._WeaponType.DepthCharge:
			case Weapon._WeaponType.Sonobuoy:
			case Weapon._WeaponType.HeliTowedPackage:
			case Weapon._WeaponType.Laser:
			case Weapon._WeaponType.Microwave:
			case Weapon._WeaponType.LaserDazzler:
			case Weapon._WeaponType.Cargo:
			case Weapon._WeaponType.Troops:
			case Weapon._WeaponType.Paratroops:
				return stringBuilder.ToString();
			}
		}
		if (activeUnit_0.IsAircraft && ((Aircraft)activeUnit_0).Loadout != null)
		{
			((Aircraft)activeUnit_0).Loadout = null;
		}
		if (activeUnit_0.XSections_ReadOnly.Count() > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>信号特征</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>信号特征类型</td><td align='center'>前面</td><td align='center'>侧面</td><td align='center'>后面</td>");
			stringBuilder.Append("</tr>");
		}
		XSection[] xSections_ReadOnly = activeUnit_0.XSections_ReadOnly;
		XSection[] array = xSections_ReadOnly;
		foreach (XSection xSection in array)
		{
			Tuple<float, float, float, float> value = new Tuple<float, float, float, float>((float)Math.Round(xSection.GetFront(activeUnit_0), 2), (float)Math.Round(xSection.GetSide(activeUnit_0), 2), (float)Math.Round(xSection.GetRear(activeUnit_0), 2), (float)Math.Round(xSection.GetTop(activeUnit_0), 2));
			BaseSignatures.Add(xSection.SignatureType, value);
			if ((xSection.GetFront(activeUnit_0) == 0f && xSection.GetSide(activeUnit_0) == 0f && xSection.GetRear(activeUnit_0) == 0f) || xSection.GetFront(activeUnit_0) == -10000f || xSection.GetSide(activeUnit_0) == -10000f || xSection.GetRear(activeUnit_0) == -10000f)
			{
				continue;
			}
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>" + DBFunctions.Description(xSection.SignatureType, Client.CurrentScenario) + "</td>");
			string text;
			string text2;
			string text3;
			if (xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_VLF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_LF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_MF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_HF && xSection.SignatureType != XSection._SignatureType.ActiveSonar)
			{
				if (xSection.SignatureType != XSection._SignatureType.Visual_Detect && xSection.SignatureType != XSection._SignatureType.Visual_ID && xSection.SignatureType != XSection._SignatureType.IR_Detect && xSection.SignatureType != XSection._SignatureType.IR_ID)
				{
					if (xSection.SignatureType != XSection._SignatureType.Radar_A_D && xSection.SignatureType != XSection._SignatureType.Radar_E_M)
					{
						text = "";
						text2 = "";
						text3 = "";
					}
					else
					{
						double num = Math.Pow(10.0, xSection.GetFront(activeUnit_0) / 10f);
						if (num < 1.0 && num >= 0.1)
						{
							text = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetFront(activeUnit_0) / 10f):0.00}" + "平方米";
							text2 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetSide(activeUnit_0) / 10f):0.00}" + "平方米";
							text3 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetRear(activeUnit_0) / 10f):0.00}" + "平方米";
						}
						else if (num < 0.1 && num >= 0.01)
						{
							text = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetFront(activeUnit_0) / 10f):0.000}" + "平方米";
							text2 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetSide(activeUnit_0) / 10f):0.000}" + "平方米";
							text3 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetRear(activeUnit_0) / 10f):0.000}" + "平方米";
						}
						else if (num < 0.01 && num >= 0.001)
						{
							text = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetFront(activeUnit_0) / 10f):0.0000}" + "平方米";
							text2 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetSide(activeUnit_0) / 10f):0.0000}" + "平方米";
							text3 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetRear(activeUnit_0) / 10f):0.0000}" + "平方米";
						}
						else if (num < 0.001 && num >= 0.0001)
						{
							text = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetFront(activeUnit_0) / 10f):0.00000}" + "平方米";
							text2 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetSide(activeUnit_0) / 10f):0.00000}" + "平方米";
							text3 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetRear(activeUnit_0) / 10f):0.00000}" + "平方米";
						}
						else if (num < 0.0001 && num >= 1E-05)
						{
							text = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetFront(activeUnit_0) / 10f):0.000000}" + "平方米";
							text2 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetSide(activeUnit_0) / 10f):0.000000}" + "平方米";
							text3 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetRear(activeUnit_0) / 10f):0.000000}" + "平方米";
						}
						else
						{
							text = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetFront(activeUnit_0) / 10f):0.0}" + "平方米";
							text2 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetSide(activeUnit_0) / 10f):0.0}" + "平方米";
							text3 = " 分贝平方米(dBsm), " + $"{Math.Pow(10.0, xSection.GetRear(activeUnit_0) / 10f):0.0}" + "平方米";
						}
					}
				}
				else
				{
					text = "海里";
					text2 = "海里";
					text3 = "海里";
				}
			}
			else
			{
				text = "分贝";
				text2 = "分贝";
				text3 = "分贝";
			}
			stringBuilder.Append("<td align='center'>" + $"{xSection.GetFront(activeUnit_0):0.00}" + text + "</td>");
			stringBuilder.Append("<td align='center'>" + $"{xSection.GetSide(activeUnit_0):0.00}" + text2 + "</td>");
			stringBuilder.Append("<td align='center'>" + $"{xSection.GetRear(activeUnit_0):0.00}" + text3 + "</td>");
			stringBuilder.Append("</tr>");
		}
		stringBuilder.Append("</table>");
		stringBuilder.Append("<br/>");
		if (activeUnit_0.IsAircraft)
		{
			stringBuilder.Append(DisplaySignatureLoadouts(activeUnit_0));
			((Aircraft)activeUnit_0).Loadout = null;
		}
		return stringBuilder.ToString();
	}

	public string DisplaySignatureLoadouts(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.IsWeapon && (((Weapon)activeUnit_0).Type == Weapon._WeaponType.BuddyStore || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Cargo || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Dispenser || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.DropTank || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.FerryTank || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Gun || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.HeliTowedPackage || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.IronBomb || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Laser || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.None || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Paratroops || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Rocket || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.SensorPod || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.TrainingRound || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Troops || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.DepthCharge || ((Weapon)activeUnit_0).Type == Weapon._WeaponType.Sonobuoy))
		{
			return stringBuilder.ToString();
		}
		int dBID = activeUnit_0.DBID;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Scenario currentScenario = Client.CurrentScenario;
		bool bool_ = false;
		Scenario scenario_ = null;
		Aircraft aircraft_ = null;
		int int_ = 0;
		bool bool_2 = false;
		DataTable dataTable = DBFunctions.LoadoutsForThisAircraft_DT(dBID, null, ref sqliteConnection_, currentScenario, ref bool_, ref scenario_, ref aircraft_, ref int_, ref bool_2);
		if (dataTable.Rows.Count > 0)
		{
			stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>飞机挂载方案</span>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>名称</td><td>弹药</td><td align='center'>信号特征</td><td>数据库ID</td></td>");
			stringBuilder.Append("</tr>");
			IEnumerator enumerator = null;
			try
			{
				enumerator = dataTable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
					aircraft_ = (Aircraft)activeUnit_0;
					DBFunctions.GetLoadout(ref aircraft_, Conversions.ToInteger(dataRow["ID"]), bool_0: false);
					activeUnit_0 = aircraft_;
					Loadout loadout = ((Aircraft)activeUnit_0).Loadout;
					if (loadout != null && loadout.Role != Loadout.LoadoutRole.Reserve && loadout.Role != Loadout.LoadoutRole.Unavailable)
					{
						stringBuilder.Append("<td valign='middle'>" + loadout.Name);
						stringBuilder.Append("<br>(" + Misc.Description(loadout.Role, Client.CurrentScenario.DBConnection) + ")");
						stringBuilder.Append("</td>");
						stringBuilder.Append("<td valign='middle'>");
						WeaponRec[] weapons = loadout.Weapons;
						WeaponRec[] array = weapons;
						foreach (WeaponRec weaponRec in array)
						{
							stringBuilder.Append(Conversions.ToString(weaponRec.CurrentLoad) + "x <a href=武器_" + Conversions.ToString(weaponRec.GetReferenceWeapon(Client.CurrentScenario).DBID) + ">" + weaponRec.GetReferenceWeapon(Client.CurrentScenario).Name + "</a><br/>");
						}
						aircraft_ = (Aircraft)activeUnit_0;
						string text = RateIterator(ref aircraft_);
						activeUnit_0 = aircraft_;
						stringBuilder.Append("<td align='center' valign='middle'>" + text + "</td>");
						stringBuilder.Append("<td>" + Conversions.ToString(loadout.DBID) + "</td>");
						stringBuilder.Append("</tr>");
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
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayFlags(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<string> list = new List<string>();
		list = DBFunctions.GetUnitFlagDescriptions(activeUnit_0.UnitType, activeUnit_0.DBID, Client.CurrentScenario.DBConnection);
		if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0).PopReponse())
		{
			list.Add("ABM Capable");
		}
		if (activeUnit_0.IsWeapon && ((Weapon)activeUnit_0).SupportsWaypoints)
		{
			list.Add("Supports WayPoints");
		}
		if (list.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>属性</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>");
			stringBuilder.Append(string.Join("<br/>", list));
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayWarheads(Weapon weapon_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (weapon_0.Warheads.Length != 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>弹头</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;background-;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>");
			IEnumerable<IGrouping<string, Warhead>> enumerable = from theWH in weapon_0.Warheads
				group theWH by theWH.Name;
			List<string> list = new List<string>();
			foreach (IGrouping<string, Warhead> item in enumerable)
			{
				string text = "";
				if (item.Count() > 1)
				{
					text = Conversions.ToString(item.Count()) + "x ";
				}
				Warhead warhead = item.ElementAtOrDefault(0);
				string text2;
				string text3;
				if (warhead.GetIsNuclear(Client.CurrentScenario) & (warhead.Type != Warhead.WarheadType.Weapon))
				{
					if (warhead.DP < 1E+09f)
					{
						text2 = Conversions.ToString(Math.Round(warhead.DP / 1000000f, 1));
						text3 = "千吨";
					}
					else
					{
						text2 = Conversions.ToString(Math.Round(warhead.DP / 1E+09f, 1));
						text3 = "公吨";
					}
				}
				else if (warhead.Type == Warhead.WarheadType.Weapon)
				{
					text2 = "";
					text3 = "";
				}
				else
				{
					text2 = Convert.ToString(warhead.DP);
					text3 = " 损伤点";
				}
				list.Add(text + "#" + Conversions.ToString(warhead.DBID) + " - " + warhead.Name + " (" + text2 + text3 + ")");
			}
			string value = ((list.Count <= 0) ? "" : string.Join(" - ", list));
			stringBuilder.Append(value);
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string DisplayPropulsion(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (activeUnit_0.Propulsion.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>推进系统</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>引擎</td><td>类型</td><td>最大速度</td>");
			stringBuilder.Append("</tr>");
			IEnumerable<IGrouping<int, Engine>> enumerable = from theE in activeUnit_0.Propulsion
				group theE by theE.DBID;
			foreach (IGrouping<int, Engine> item in enumerable)
			{
				string text = ((item.Count() <= 1) ? "" : (Conversions.ToString(item.Count()) + "x "));
				Engine engine = item.ElementAtOrDefault(0);
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				try
				{
					if (engine.AltBands.Select((AltBand theAltBand) => theAltBand.MaxSpeed.Value).Max() <= 0)
					{
						stringBuilder.Append("<td>无</td>");
						stringBuilder.Append("<td></td>");
						stringBuilder.Append("<td></td>");
					}
					else
					{
						stringBuilder.Append("<td>" + text + engine.Name + "</td>");
						stringBuilder.Append("<td valign='top'>" + Misc.Description(engine.Type, Client.CurrentScenario.DBConnection) + "</td>");
						stringBuilder.Append("<td valign='top'>" + Conversions.ToString(engine.AltBands.Select((AltBand theAltBand) => theAltBand.MaxSpeed.Value).Max()) + " 节</td>");
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception exception_ = ex;
					stringBuilder.Append("<td>无</td>");
					stringBuilder.Append("<td></td>");
					stringBuilder.Append("<td></td>");
					exception_?.Data.Add("Error at 200376", exception_.Message);
					GameGeneral.WriteExceptionsToLog(ref exception_);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
			if (activeUnit_0.IsAircraft)
			{
				foreach (IGrouping<int, Engine> item2 in enumerable)
				{
					Engine engine2 = item2.ElementAtOrDefault(0);
					List<float> list = new List<float>();
					try
					{
						list = DBFunctions.GetEngineDetails(engine2.DBID, Client.CurrentScenario.DBConnection);
						if (list.Count <= 0)
						{
							continue;
						}
						stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>技术细节</span>");
						stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
						stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
						stringBuilder.Append("<td>军事静态推力 S/L</td><td>加力燃烧静态推力 S/L</td><td>军事静态 SFC at S/L</td><td>加力燃烧静态 SFC at S/L</td>");
						stringBuilder.Append("</tr>");
						stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
						if (list[0] == 1f)
						{
							stringBuilder.Append("<td>" + Conversions.ToString(list[1]) + " 千克</td>");
							if (list[2] <= 0f)
							{
								stringBuilder.Append("<td>-</td>");
							}
							else
							{
								stringBuilder.Append("<td>" + Conversions.ToString(list[2]) + " 千克</td>");
							}
						}
						else
						{
							stringBuilder.Append("<td>" + Conversions.ToString(list[1]) + " 公斤每引擎</td>");
							if (list[2] <= 0f)
							{
								stringBuilder.Append("<td>-</td>");
							}
							else
							{
								stringBuilder.Append("<td>" + Conversions.ToString(list[2]) + " 公斤每引擎</td>");
							}
						}
						stringBuilder.Append("<td>" + Conversions.ToString(list[3]) + " 千克/小时/千克</td>");
						if (list[4] <= 0f)
						{
							stringBuilder.Append("<td>-</td>");
						}
						else
						{
							stringBuilder.Append("<td>" + Conversions.ToString(list[4]) + " 千克/小时/千克</td>");
						}
						stringBuilder.Append("</tr>");
						stringBuilder.Append("</table>");
						stringBuilder.Append("<br/>");
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception exception_2 = ex2;
						exception_2?.Data.Add("Error at 200377", exception_2.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
			foreach (IGrouping<int, Engine> item3 in enumerable)
			{
				Engine engine3 = item3.ElementAtOrDefault(0);
				int num = 1;
				if (engine3.AltBands.Length == 0)
				{
					continue;
				}
				if (activeUnit_0.Propulsion.Count <= 1)
				{
					stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>性能详情</span>");
				}
				else
				{
					stringBuilder.Append("<span style='text-align: left; font-family: Arial; font-size: small; font-weight: bold;'>性能详情： " + DBFunctions.GetEngine(engine3.DBID, ref activeUnit_0).Name + "</span>");
				}
				stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
				stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
				if (engine3.Type == Engine.EngineType.Nuclear)
				{
					if (activeUnit_0.IsSubmarine)
					{
						stringBuilder.Append("<td>高度范围 & 油门</td><td>高度</td><td>速度</td>");
					}
					else
					{
						stringBuilder.Append("<td>高度范围 & 油门</td><td>速度</td>");
					}
				}
				else if (!activeUnit_0.IsAircraft && !activeUnit_0.IsMissile)
				{
					if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsTorpedo)
					{
						if (activeUnit_0.IsVehicle && ((Vehicle)activeUnit_0).IsOutOfFuel)
						{
							stringBuilder.Append("<td>Land/Water & Throttle</td><td></td><td>Speed</td><td>Fuel Consumption</td>");
						}
						else
						{
							stringBuilder.Append("<td>高度范围 & 油门</td><td>速度</td><td>燃料消耗</td>");
						}
					}
					else
					{
						stringBuilder.Append("<td>高度范围 & 油门</td><td>深度</td><td>速度</td><td>燃料消耗</td>");
					}
				}
				else
				{
					stringBuilder.Append("<td>高度范围 & 油门</td><td>高度</td><td>速度</td><td>燃料消耗</td>");
				}
				stringBuilder.Append("</tr>");
				AltBand[] altBands = engine3.AltBands;
				AltBand[] array = altBands;
				foreach (AltBand altBand in array)
				{
					try
					{
						if (altBand.Speed_Loiter > 0)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (activeUnit_0.IsVehicle && ((Vehicle)activeUnit_0).IsAmphibious)
							{
								if (engine3.CanBeUsedOnWater() && altBand == engine3.AltBands.Last())
								{
									stringBuilder.Append("<td rowspan='4' valign='middle'>On water</td>");
								}
								else
								{
									stringBuilder.Append("<td rowspan='4' valign='middle'>On land</td>");
								}
							}
							if (!activeUnit_0.IsAircraft && !activeUnit_0.IsMissile)
							{
								if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>低速油门</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 低速油门</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 低速速度</td>");
							}
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " 英尺<br>" + $"{altBand.MinAlt:0.0}" + " - " + $"{altBand.MaxAlt:0.0}" + " 米</td>");
							}
							if (activeUnit_0.IsSubmarine || activeUnit_0.IsTorpedo)
							{
								stringBuilder.Append("<td>" + $"{altBand.MaxAlt * 3.28084f * -1f:0}" + " - " + $"{altBand.MinAlt * 3.28084f * -1f:0}" + " 英尺<br>" + $"{altBand.MaxAlt * -1f:0.0}" + " - " + $"{altBand.MinAlt * -1f:0.0}" + " 米</td>");
							}
							stringBuilder.Append("<td>" + Conversions.ToString(altBand.Speed_Loiter) + "节");
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.CompareStub(altBand.MinAlt, altBand.Speed_Loiter):0.00}" + " 马赫");
							}
							stringBuilder.Append("</td>");
							if (engine3.Type != Engine.EngineType.Nuclear)
							{
								if (engine3.Type != Engine.EngineType.Electric && engine3.Type != Engine.EngineType.AIP)
								{
									if (activeUnit_0.IsWeapon)
									{
										if (altBand.Consumption_Loiter == 1f)
										{
											stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " 燃料点 / 秒</td>");
										}
										else
										{
											stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " 燃料点 / 秒</td>");
										}
									}
									else
									{
										stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " 千克每分钟</td>");
									}
								}
								else if (altBand.Consumption_Loiter == 1f)
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " 电池单元每分钟</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Loiter) + " 电池单元每分钟</td>");
								}
							}
							stringBuilder.Append("</tr>");
						}
						if (altBand.Speed_Cruise > 0)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (!activeUnit_0.IsAircraft && !activeUnit_0.IsMissile)
							{
								if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>巡航油门</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 巡航油门</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 巡航速度</td>");
							}
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " 英尺<br>" + $"{altBand.MinAlt:0.0}" + " - " + $"{altBand.MaxAlt:0.0}" + " 米</td>");
							}
							if (activeUnit_0.IsSubmarine || activeUnit_0.IsTorpedo)
							{
								stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToDouble($"{altBand.MaxAlt * 3.28084f:0}") * -1.0) + " - " + Conversions.ToString(Conversions.ToDouble($"{altBand.MinAlt * 3.28084f:0}") * -1.0) + " 英尺<br>" + $"{altBand.MaxAlt * -1f:0.0}" + " - " + $"{altBand.MinAlt * -1f:0.0}" + " 米</td>");
							}
							stringBuilder.Append("<td>" + Conversions.ToString(altBand.Speed_Cruise) + "节");
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.CompareStub(altBand.MinAlt, altBand.Speed_Cruise):0.00}" + " 马赫");
							}
							stringBuilder.Append("</td>");
							if (engine3.Type != Engine.EngineType.Nuclear)
							{
								if (engine3.Type != Engine.EngineType.Electric && engine3.Type != Engine.EngineType.AIP)
								{
									if (activeUnit_0.IsWeapon)
									{
										if (altBand.Consumption_Cruise == 1f)
										{
											stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " 燃料点 / 秒</td>");
										}
										else
										{
											stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " 燃料点 / 秒</td>");
										}
									}
									else
									{
										stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " 千克每分钟</td>");
									}
								}
								else if (altBand.Consumption_Cruise == 1f)
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " 电池单元每分钟</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>" + Conversions.ToString(altBand.Consumption_Cruise) + " 电池单元每分钟</td>");
								}
							}
							stringBuilder.Append("</tr>");
						}
						if (altBand.Speed_Full.HasValue)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (!activeUnit_0.IsAircraft && !activeUnit_0.IsMissile)
							{
								if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>全速油门</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 全速油门</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 军事速度</td>");
							}
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " 英尺<br>" + $"{altBand.MinAlt:0.0}" + " - " + $"{altBand.MaxAlt:0.0}" + " 米</td>");
							}
							if (activeUnit_0.IsSubmarine || activeUnit_0.IsTorpedo)
							{
								stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToDouble($"{altBand.MaxAlt * 3.28084f:0}") * -1.0) + " - " + Conversions.ToString(Conversions.ToDouble($"{altBand.MinAlt * 3.28084f:0}") * -1.0) + " 英尺<br>" + $"{altBand.MaxAlt * -1f:0.0}" + " - " + $"{altBand.MinAlt * -1f:0.0}" + " 米</td>");
							}
							long? speed_Full;
							long? num6 = (speed_Full = altBand.Speed_Full);
							stringBuilder.Append("<td>" + (num6.HasValue ? Conversions.ToString(speed_Full.GetValueOrDefault()) : null) + "节");
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.CompareStub(altBand.MinAlt, altBand.Speed_Full.Value):0.00}" + " 马赫");
							}
							stringBuilder.Append("</td>");
							if (engine3.Type != Engine.EngineType.Nuclear)
							{
								if (engine3.Type != Engine.EngineType.Electric && engine3.Type != Engine.EngineType.AIP)
								{
									if (activeUnit_0.IsWeapon)
									{
										float? consumption_Full = altBand.Consumption_Full;
										if ((consumption_Full.HasValue ? new bool?(consumption_Full.GetValueOrDefault() == 1f) : null).GetValueOrDefault())
										{
											float? num7 = (consumption_Full = altBand.Consumption_Full);
											stringBuilder.Append("<td valign='top'>" + (num7.HasValue ? Conversions.ToString(consumption_Full.GetValueOrDefault()) : null) + " 燃料点 / 秒</td>");
										}
										else
										{
											float? num8 = (consumption_Full = altBand.Consumption_Full);
											stringBuilder.Append("<td valign='top'>" + (num8.HasValue ? Conversions.ToString(consumption_Full.GetValueOrDefault()) : null) + " 燃料点 / 秒</td>");
										}
									}
									else
									{
										float? consumption_Full2;
										float? num9 = (consumption_Full2 = altBand.Consumption_Full);
										stringBuilder.Append("<td valign='top'>" + (num9.HasValue ? Conversions.ToString(consumption_Full2.GetValueOrDefault()) : null) + " 千克每分钟</td>");
									}
								}
								else
								{
									float? consumption_Full3 = altBand.Consumption_Full;
									if ((consumption_Full3.HasValue ? new bool?(consumption_Full3.GetValueOrDefault() == 1f) : null).GetValueOrDefault())
									{
										float? num10 = (consumption_Full3 = altBand.Consumption_Full);
										stringBuilder.Append("<td valign='top'>" + (num10.HasValue ? Conversions.ToString(consumption_Full3.GetValueOrDefault()) : null) + " 电池单元每分钟</td>");
									}
									else
									{
										float? num11 = (consumption_Full3 = altBand.Consumption_Full);
										stringBuilder.Append("<td valign='top'>" + (num11.HasValue ? Conversions.ToString(consumption_Full3.GetValueOrDefault()) : null) + " 电池单元每分钟</td>");
									}
								}
							}
							stringBuilder.Append("</tr>");
						}
						if (altBand.Speed_Flank.HasValue)
						{
							stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
							if (!activeUnit_0.IsAircraft && !activeUnit_0.IsMissile)
							{
								if (!activeUnit_0.IsSubmarine && !activeUnit_0.IsTorpedo)
								{
									stringBuilder.Append("<td valign='top'>最大油门</td>");
								}
								else
								{
									stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 最大油门</td>");
								}
							}
							else
							{
								stringBuilder.Append("<td valign='top'>范围 " + Conversions.ToString(num) + ", 加力燃烧速度</td>");
							}
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<td>" + $"{altBand.MinAlt * 3.28084f:0}" + " - " + $"{altBand.MaxAlt * 3.28084f:0}" + " 英尺<br>" + Conversions.ToString(altBand.MinAlt) + " - " + Conversions.ToString(altBand.MaxAlt) + " 米</td>");
							}
							if (activeUnit_0.IsSubmarine || activeUnit_0.IsTorpedo)
							{
								stringBuilder.Append("<td>" + Conversions.ToString(Conversions.ToDouble($"{altBand.MaxAlt * 3.28084f:0}") * -1.0) + " - " + Conversions.ToString(Conversions.ToDouble($"{altBand.MinAlt * 3.28084f:0}") * -1.0) + " 英尺<br>" + Conversions.ToString(altBand.MaxAlt * -1f) + " - " + Conversions.ToString(altBand.MinAlt * -1f) + " 米</td>");
							}
							long? speed_Flank;
							long? num12 = (speed_Flank = altBand.Speed_Flank);
							stringBuilder.Append("<td>" + (num12.HasValue ? Conversions.ToString(speed_Flank.GetValueOrDefault()) : null) + "节");
							if (activeUnit_0.IsAircraft || activeUnit_0.IsMissile)
							{
								stringBuilder.Append("<br>" + $"{Physics.CompareStub(altBand.MinAlt, altBand.Speed_Flank.Value):0.00}" + " 马赫");
							}
							stringBuilder.Append("</td>");
							if (engine3.Type != Engine.EngineType.Nuclear)
							{
								if (engine3.Type != Engine.EngineType.Electric && engine3.Type != Engine.EngineType.AIP)
								{
									if (activeUnit_0.IsWeapon)
									{
										float? consumption_Flank = altBand.Consumption_Flank;
										if ((consumption_Flank.HasValue ? new bool?(consumption_Flank.GetValueOrDefault() == 1f) : null).GetValueOrDefault())
										{
											float? num13 = (consumption_Flank = altBand.Consumption_Flank);
											stringBuilder.Append("<td valign='top'>" + (num13.HasValue ? Conversions.ToString(consumption_Flank.GetValueOrDefault()) : null) + " 燃料点 / 秒</td>");
										}
										else
										{
											float? num2 = (consumption_Flank = altBand.Consumption_Flank);
											stringBuilder.Append("<td valign='top'>" + (num2.HasValue ? Conversions.ToString(consumption_Flank.GetValueOrDefault()) : null) + " 燃料点 / 秒</td>");
										}
									}
									else
									{
										float? consumption_Flank2;
										float? num3 = (consumption_Flank2 = altBand.Consumption_Flank);
										stringBuilder.Append("<td valign='top'>" + (num3.HasValue ? Conversions.ToString(consumption_Flank2.GetValueOrDefault()) : null) + " 千克每分钟</td>");
									}
								}
								else
								{
									float? consumption_Flank3 = altBand.Consumption_Flank;
									if ((consumption_Flank3.HasValue ? new bool?(consumption_Flank3.GetValueOrDefault() == 1f) : null).GetValueOrDefault())
									{
										float? num4 = (consumption_Flank3 = altBand.Consumption_Flank);
										stringBuilder.Append("<td valign='top'>" + (num4.HasValue ? Conversions.ToString(consumption_Flank3.GetValueOrDefault()) : null) + " 电池单元每分钟</td>");
									}
									else
									{
										float? num5 = (consumption_Flank3 = altBand.Consumption_Flank);
										stringBuilder.Append("<td valign='top'>" + (num5.HasValue ? Conversions.ToString(consumption_Flank3.GetValueOrDefault()) : null) + " 电池单元每分钟</td>");
									}
								}
							}
							stringBuilder.Append("</tr>");
						}
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception exception_3 = ex3;
						exception_3?.Data.Add("Error at 200378", exception_3.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_3);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					num++;
				}
				stringBuilder.Append("</table>");
				stringBuilder.Append("<br/>");
			}
		}
		return stringBuilder.ToString();
	}

	public string DisplayFuel(ActiveUnit activeUnit_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = "";
		if (activeUnit_0.Fuel_ReadOnly.Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>燃料</strong></span></div>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style='font-family:Verdana;font-size:10pt;font-weight:bold;background-color:DimGrey'>");
			stringBuilder.Append("<td>燃料类型</td><td>数量</td>");
			stringBuilder.Append("</tr>");
			bool flag = false;
			foreach (FuelRec item in activeUnit_0.Fuel_ReadOnly)
			{
				stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
				double num = item.MaxQuantity;
				if (!activeUnit_0.IsAircraft & !activeUnit_0.IsWeapon)
				{
					if (item.FuelType != FuelRec._FuelType.Battery && item.FuelType != FuelRec._FuelType.AirIndepedent)
					{
						num /= 1000.0;
						text = "吨";
					}
					else if (num <= 120.0)
					{
						text = "潜行速度的分钟数";
					}
					else
					{
						num /= 60.0;
						text = "潜行速度的小时数";
					}
				}
				else if (activeUnit_0.IsWeapon)
				{
					Weapon weapon = (Weapon)activeUnit_0;
					if (weapon.UsesBoostCoastModel.Value)
					{
						bool bool_ = DBFunctions.CheckWeaponIsInAircraftLoadouts(Client.CurrentScenario.DBConnection, activeUnit_0.DBID) || weapon.MinLaunchAlt_AGL > 0f || weapon.MinLaunchAlt_ASL > 0f;
						Weapon.RecalculateWeaponFlightEnergyIfNecessary(weapon, Client.CurrentScenario, bool_);
						num = weapon.TotalBurnTime;
					}
					if (num <= 120.0)
					{
						text = "秒";
					}
					else
					{
						num /= 60.0;
						text = "分钟";
					}
					if (weapon.UsesBoostCoastModel.Value)
					{
						string obj = text;
						int? flightEndurance;
						int? num2 = (flightEndurance = weapon.FlightEndurance);
						text = obj + " (Flight Endurance: " + (num2.HasValue ? Conversions.ToString(flightEndurance.GetValueOrDefault()) : null) + " sec)";
					}
				}
				else
				{
					text = "千克";
				}
				string text2 = "";
				if (flag)
				{
					text2 = " (Secondary fuel tank)";
				}
				flag = true;
				stringBuilder.Append("<td>" + Misc.Description(item.FuelType, Client.CurrentScenario.DBConnection) + text2 + "</td>");
				stringBuilder.Append("<td>" + $"{num:0.0}" + text + "</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	public string WeaponSummary(ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		string text = Misc.ForgotRequest(weapon_0.Type) + ". ";
		string text2 = "目标：" + string.Join(", ", weapon_0.ValidTargets_Description) + ". ";
		string text3 = ((weapon_0.Kinematics.GetMaximumSpeed() <= 0) ? "" : ("最大速度：" + Conversions.ToString(weapon_0.Kinematics.GetMaximumSpeed()) + " 节. "));
		string text4 = ((weapon_0.MaxRange_NoTargetType <= 0f) ? "" : ("最大范围：" + Conversions.ToString(weapon_0.MaxRange_NoTargetType) + " 海里. "));
		IEnumerable<IGrouping<string, Warhead>> enumerable = from theWH in weapon_0.Warheads
			group theWH by theWH.Name;
		List<string> list = new List<string>();
		foreach (IGrouping<string, Warhead> item in enumerable)
		{
			string text5 = "";
			if (item.Count() > 1)
			{
				text5 = Conversions.ToString(item.Count()) + "x ";
			}
			if (item.ElementAtOrDefault(0).GetIsNuclear(Client.CurrentScenario))
			{
				list.Add(text5 + item.ElementAtOrDefault(0).Name);
			}
			else if (item.ElementAtOrDefault(0).DP < 0f)
			{
				list.Add(text5 + item.ElementAtOrDefault(0).Name + " (" + Conversions.ToString(item.ElementAtOrDefault(0).DP) + " 毁伤点DPs)");
			}
			else
			{
				list.Add(text5 + item.ElementAtOrDefault(0).Name);
			}
		}
		string text6 = ((list.Count <= 0) ? "" : ((weapon_0.Warheads.Length <= 1) ? ("弹头：" + string.Join(" - ", list)) : ("弹头：" + string.Join(" - ", list)))) + ". ";
		string text7 = null;
		if (weapon_0.IsGuidedWeapon() && weapon_0.Directors.Count > 0)
		{
			IEnumerable<IGrouping<int, Sensor>> enumerable2 = from theS in activeUnit_0.Sensors_Cached
				where weapon_0.Directors.Contains(theS.DBID)
				group theS by theS.DBID;
			if (enumerable2.Count() > 0)
			{
				List<string> list2 = new List<string>();
				foreach (IGrouping<int, Sensor> item2 in enumerable2)
				{
					list2.Add(item2.ElementAtOrDefault(0).Name);
				}
				text7 = "可以被引导：" + string.Join(", ", list2) + ". ";
			}
		}
		string text8 = "";
		if (weapon_0.IsMine)
		{
			text8 = "部署深度：" + $"{weapon_0.MinTargetAlt_ASL * 3.28084f:0}" + " 英尺 - " + $"{weapon_0.MaxTargetAlt_ASL * 3.28084f:0}" + " 英尺, " + Conversions.ToString(weapon_0.MinTargetAlt_ASL) + " 米 - " + Conversions.ToString(weapon_0.MaxTargetAlt_ASL) + " 米. ";
		}
		return text + text2 + text3 + text4 + text6 + text8 + text7;
	}

	public string DisplayWeapon(Weapon weapon_0)
	{
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + weapon_0.UnitClass);
		text = text.Replace("<%Image%>", DisplayImage(weapon_0));
		text = text.Replace("<%Description%>", DisplayDescription(weapon_0));
		text = text.Replace("<%General%>", Weapon_General(weapon_0));
		text = text.Replace("<%Sensors%>", DisplaySensors(weapon_0));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", "");
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", DisplayComms(weapon_0));
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", DisplaySignatures(weapon_0));
		text = text.Replace("<%Flags%>", DisplayFlags(weapon_0));
		text = text.Replace("<%Warheads%>", DisplayWarheads(weapon_0));
		text = text.Replace("<%ValidTargets%>", DisplayValidTargets(weapon_0));
		text = text.Replace("<%WRA%>", method_0(weapon_0));
		text = text.Replace("<%Propulsion%>", DisplayPropulsion(weapon_0));
		text = text.Replace("<%Fuel%>", DisplayFuel(weapon_0));
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>默认挂载该武器平台</strong></span></div>");
		stringBuilder.Append("<div style='color:Black;background-;font-family:Verdana;font-size:8pt;'>");
		foreach (string item in DBFunctions.GetPlatformsThatCarryThisWeapon(weapon_0.DBID, Client.CurrentScenario).OrderBy((string theStr) => theStr.Split('_')[2] + " " + theStr.Split('_')[3] + " " + theStr.Split('_')[4], new NaturalSortComparer<string[]>()).ToList())
		{
			string text2 = item.Split('_')[0];
			string text3 = item.Split('_')[1];
			string text4 = item.Split('_')[2];
			string text5 = item.Split('_')[3];
			string text6 = item.Split('_')[4];
			stringBuilder.Append("<a href=" + text2 + "_" + text3 + ">" + text4 + " (" + text5 + " - " + text6 + ")</a><br/>");
		}
		stringBuilder.Append("</div>");
		return text + stringBuilder.ToString();
	}

	public string DisplaySensor(int int_0)
	{
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		Sensor sensor = DBFunctions.GetSensor(int_0, ref sqliteConnection_);
		StreamReader streamReader = new StreamReader(Path.Combine(GameGeneral.DBFolderPath, "Templates\\Platform.html"));
		string text;
		using (streamReader)
		{
			text = streamReader.ReadToEnd();
		}
		text = text.Replace("<%PlatformName%>", "#" + Conversions.ToString(SelectedObjectID) + " - " + sensor.Name);
		text = text.Replace("<%Image%>", DisplaySensorImage(sensor.DBID));
		text = text.Replace("<%Description%>", DisplaySensorDescription(Client.CurrentScenario.DBUsed, sensor.DBID));
		text = text.Replace("<%General%>", "");
		text = text.Replace("<%Sensors%>", DisplaySensors(sensor));
		text = text.Replace("<%MineCountermeasures%>", "");
		text = text.Replace("<%Mounts%>", "");
		text = text.Replace("<%Stores%>", "");
		text = text.Replace("<%Loadouts%>", "");
		text = text.Replace("<%Magazines%>", "");
		text = text.Replace("<%Comms%>", "");
		text = text.Replace("<%AirFacilities%>", "");
		text = text.Replace("<%DockingFacilities%>", "");
		text = text.Replace("<%Signatures%>", "");
		text = text.Replace("<%Flags%>", DisplaySensorFlags(sensor));
		text = text.Replace("<%Warheads%>", "");
		text = text.Replace("<%ValidTargets%>", "");
		text = text.Replace("<%WRA%>", "");
		text = text.Replace("<%Propulsion%>", "");
		text = text.Replace("<%Fuel%>", "");
		StringBuilder stringBuilder = new StringBuilder();
		string[] platformsThatCarryThisSensor = DBFunctions.GetPlatformsThatCarryThisSensor(sensor.DBID, Client.CurrentScenario);
		if (platformsThatCarryThisSensor.Count() > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='font-family: Arial; color: dodgerblue;'><strong>默认挂载该传感器的平台</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;background-;font-family:Verdana;font-size:8pt;'>");
			List<string> list = platformsThatCarryThisSensor.OrderBy((string theStr) => theStr.Split('_')[0] + " " + theStr.Split('_')[2] + " " + theStr.Split('_')[3] + " " + theStr.Split('_')[4], new NaturalSortComparer<string[]>()).ToList();
			string text2 = null;
			foreach (string item in list)
			{
				string text3 = item.Split('_')[0];
				string text4 = item.Split('_')[1];
				string text5 = item.Split('_')[2];
				string text6 = item.Split('_')[3];
				string text7 = item.Split('_')[4];
				if (text2 == null || !text2.Equals(text3))
				{
					stringBuilder.Append("<span style='font-family: Arial; color: lightblue;font-size:10pt;'><strong>" + text3.ToUpper() + "</strong></span><br/>");
				}
				text2 = text3;
				stringBuilder.Append("<a href=" + text3 + "_" + text4 + ">" + text5 + " (" + text6 + " - " + text7 + ")</a><br/>");
			}
			stringBuilder.Append("</div>");
			text += stringBuilder.ToString();
		}
		return text;
	}

	public string DisplaySensorFlags(Sensor sensor_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		new List<string>();
		if (DBFunctions.GetSensorFlagDescriptions(sensor_0.DBID, Client.CurrentScenario.DBConnection).Count > 0)
		{
			stringBuilder.Append("<div style='border-bottom: black 1px solid'><span style='color: dodgerblue; font-family: Arial'><strong>属性</strong></span></div>");
			stringBuilder.Append("<div style='color:Black;font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<table width='100%' align='Center'  cellpadding='2' cellspacing='0' rules='rows' style=' font-size: medium;  font-weight: normal;  text-align: left;   height: 10px; '>");
			stringBuilder.Append("<tr style=';font-family:Verdana;font-size:8pt;'>");
			stringBuilder.Append("<td>");
			stringBuilder.Append(string.Join("<br/>", DBFunctions.GetSensorFlagDescriptions(sensor_0.DBID, Client.CurrentScenario.DBConnection)));
			stringBuilder.Append("</td>");
			stringBuilder.Append("</tr>");
			stringBuilder.Append("</table>");
			stringBuilder.Append("</div>");
			stringBuilder.Append("<br/>");
		}
		return stringBuilder.ToString();
	}

	private void FlushIterator(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
			return;
		}
		if (DBIDGOTO.Focused && e.KeyCode == Keys.Return)
		{
			ComputeInitializer();
		}
		if (!CB_ObjectType.Focused && !TB_Class.Focused && !DBIDGOTO.Focused && !CB_Country.Focused && !CB_Hypothetical.Focused && !ListBox1.Focused && !WebBrowser1.Focused && base.Visible && e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.End && e.KeyCode != Keys.Home)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Focus();
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ForgotIterator(object sender, MouseEventArgs e)
	{
		int mouseWheelScrollLines = SystemInformation.MouseWheelScrollLines;
		if (_GlobalContainer)
		{
			ListBox1.Focus();
			int num = ((ListBox1.SelectedIndices.Count != 0) ? ListBox1.SelectedIndices[0] : 0);
			if (attributeContainer < 0)
			{
				attributeContainer = num * ListBox1.ItemHeight;
			}
			if (e.Delta <= 0)
			{
				attributeContainer += mouseWheelScrollLines * ListBox1.ItemHeight;
				if (attributeContainer >= ListBox1.Items.Count * ListBox1.ItemHeight)
				{
					attributeContainer = (ListBox1.Items.Count - 1) * ListBox1.ItemHeight;
				}
			}
			else
			{
				attributeContainer -= mouseWheelScrollLines * ListBox1.ItemHeight;
				if (attributeContainer < 0)
				{
					attributeContainer = 0;
				}
			}
			ListBox1.method_0(attributeContainer);
		}
		else
		{
			WebBrowser1.Focus();
		}
	}

	private void CollectIterator(object sender, EventArgs e)
	{
		if (!ListBox1.Focused)
		{
			ListBox1.Focus();
		}
		_GlobalContainer = true;
	}

	private void OrderIterator(object sender, EventArgs e)
	{
		_GlobalContainer = false;
		WebBrowser1.Focus();
	}

	private void RegisterIterator(object sender, EventArgs e)
	{
		DefineIterator();
	}

	private void ManageIterator(object sender, EventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	private void RevertIterator(object sender, PreviewKeyDownEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!CB_ObjectType.Focused && !TB_Class.Focused && !CB_Country.Focused && !CB_Hypothetical.Focused && !ListBox1.Focused && !WebBrowser1.Focused && base.Visible && e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.End && e.KeyCode != Keys.Home)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Focus();
			KeyEventArgs e2 = new KeyEventArgs(e.KeyData);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e2);
			e2 = null;
		}
	}

	private void CountInitializer(object sender, WebBrowserNavigatingEventArgs e)
	{
		if (e.Url.LocalPath.Contains("_"))
		{
			e.Cancel = true;
			string selectedObjectType = e.Url.LocalPath.Split('_')[0];
			int selectedObjectID = Conversions.ToInteger(e.Url.LocalPath.Split('_')[1]);
			bool bool_ = Operators.CompareString(SelectedObjectType, "武器", TextCompare: true) != 0 && Operators.CompareString(SelectedObjectType, "传感器", TextCompare: true) != 0;
			SelectedObjectType = selectedObjectType;
			SelectedObjectID = selectedObjectID;
			DisplaySelection(bool_0: false, bool_);
		}
	}

	private void CustomizeInitializer(object sender, EventArgs e)
	{
		if (!m_FactoryContainer)
		{
			SelectedObjectID = Conversions.ToInteger(ListBox1.SelectedItems[0].Tag);
			if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(CB_ObjectType.SelectedItem)))
			{
				SelectedObjectType = Conversions.ToString(CB_ObjectType.SelectedItem);
			}
			if (!string.IsNullOrEmpty(SelectedObjectType))
			{
				DisplaySelection(bool_0: false);
			}
		}
	}

	private void CloneInitializer(object sender, PreviewKeyDownEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.End && e.KeyCode != Keys.Home)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Focus();
			KeyEventArgs e2 = new KeyEventArgs(e.KeyData);
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e2);
			e2 = null;
		}
	}

	private void ConnectInitializer(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.KeyCode == Keys.Escape && base.Visible)
			{
				Close();
				return;
			}
			switch (e.KeyCode)
			{
			case Keys.Prior:
			{
				int num2 = ListBox1.SelectedIndices[0];
				num2 -= 5;
				if (num2 < 0)
				{
					num2 = 0;
				}
				ListBox1.SelectItem(num2);
				ListBox1.EnsureVisible();
				break;
			}
			case Keys.Next:
			{
				int num = ListBox1.SelectedIndices[0];
				num += 5;
				if (num >= ListBox1.Items.Count)
				{
					num = ListBox1.Items.Count - 1;
				}
				ListBox1.SelectItem(num);
				ListBox1.EnsureVisible();
				break;
			}
			case Keys.End:
				ListBox1.SelectItem(ListBox1.Items.Count - 1);
				ListBox1.EnsureVisible();
				break;
			case Keys.Home:
				ListBox1.SelectItem(0);
				ListBox1.EnsureVisible();
				break;
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			if (exception_ != null)
			{
				exception_.Data.Add("Error at 098678748764", exception_.Message);
				GameGeneral.WriteExceptionsToLog(ref exception_);
			}
			ProjectData.ClearProjectError();
		}
	}

	public string ShowArcImage(List<string> list_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Directory.Exists(Application.StartupPath + "/Symbols/arcs"))
		{
			if (FileExistsNative.FileExistsFast(Application.StartupPath + "/Symbols/arcs/arc_base.png") && FileExistsNative.FileExistsFast(Application.StartupPath + "/Symbols/arcs/arc_360.png"))
			{
				stringBuilder.Append("<style>\r\n.containerdiv { float:vertical-align:bottom; position: relative; } \r\n.cornerimage {position: absolute; top: 0; left: 0; width=50; height=50} \r\n</style>");
				stringBuilder.Append("<div Class=\"containerdiv\" >");
				bool flag = true;
				foreach (string item in list_0)
				{
					if (Operators.CompareString(item, "360", TextCompare: true) != 0)
					{
						if (flag)
						{
							stringBuilder.Append("<img width='50' height='50' src='" + Application.StartupPath + "/Symbols/arcs/arc_base.png'>");
						}
						if (Operators.CompareString(item, "SB1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_sb1.png'>");
						}
						if (Operators.CompareString(item, "SB2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_sb2.png'>");
						}
						if (Operators.CompareString(item, "SMF1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_smf1.png'>");
						}
						if (Operators.CompareString(item, "SMF2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_smf2.png'>");
						}
						if (Operators.CompareString(item, "SMA1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_sma1.png'>");
						}
						if (Operators.CompareString(item, "SMA2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_sma2.png'>");
						}
						if (Operators.CompareString(item, "SS1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_ss1.png'>");
						}
						if (Operators.CompareString(item, "SS2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_ss2.png'>");
						}
						if (Operators.CompareString(item, "PS1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_ps1.png'>");
						}
						if (Operators.CompareString(item, "PS2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_ps2.png'>");
						}
						if (Operators.CompareString(item, "PMA1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_pma1.png'>");
						}
						if (Operators.CompareString(item, "PMA2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_pma2.png'>");
						}
						if (Operators.CompareString(item, "PMF1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_pmf1.png'>");
						}
						if (Operators.CompareString(item, "PMF2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_pmf2.png'>");
						}
						if (Operators.CompareString(item, "PB1", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_pb1.png'>");
						}
						if (Operators.CompareString(item, "PB2", TextCompare: true) == 0)
						{
							stringBuilder.Append("<img class=\"cornerimage\" src='" + Application.StartupPath + "/Symbols/arcs/arc_pb2.png'>");
						}
						flag = false;
						continue;
					}
					stringBuilder.Append("<img width='50' height='50' src='" + Application.StartupPath + "/Symbols/arcs/arc_360.png' >");
					break;
				}
				stringBuilder.Append("<br/></div>");
				return stringBuilder.ToString();
			}
			return "";
		}
		return "";
	}

	private void MoveInitializer(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		ScrollToSpecificElement(HighlightTarget);
		HighlightTarget = null;
	}

	private void DeleteInitializer(object sender, EventArgs e)
	{
		if (Control.ModifierKeys == Keys.Shift)
		{
			DisplayNavigationHistoryIndex(0);
		}
		else
		{
			DisplayNavigationHistoryIndex(NavigationHistoryPosition - 1);
		}
	}

	private void AddInitializer(object sender, EventArgs e)
	{
		if (Control.ModifierKeys == Keys.Shift)
		{
			DisplayNavigationHistoryIndex(DBViewerNavigationHistory.Count - 1);
		}
		else
		{
			DisplayNavigationHistoryIndex(NavigationHistoryPosition + 1);
		}
	}

	private void DestroyInitializer(object sender, EventArgs e)
	{
		DBIDGOTO.WatermarkText = "输入数据库ID对应于该 " + CB_ObjectType.Text + " ...";
	}

	private void ComputeInitializer()
	{
		SQLiteHelper sqliteHelper_ = new SQLiteHelper(Client.CurrentScenario.DBConnection);
		if (Regex.IsMatch(DBIDGOTO.Text, "^[0-9 ]+$"))
		{
			string left = CB_ObjectType.Text;
			DataTable dataTable = null;
			if (Operators.CompareString(left, "飞机", TextCompare: true) == 0)
			{
				string text = "Select * from DataAircraft where ID = " + DBIDGOTO.Text;
				dataTable = DBCache.GetDatatable(sqliteHelper_, text);
			}
			else if (Operators.CompareString(left, "舰船", TextCompare: true) == 0)
			{
				string text2 = "Select * from DataShip where ID = " + DBIDGOTO.Text;
				dataTable = DBCache.GetDatatable(sqliteHelper_, text2);
			}
			else if (Operators.CompareString(left, "潜艇", TextCompare: true) == 0)
			{
				string text3 = "Select * from DataSubmarine where ID = " + DBIDGOTO.Text;
				dataTable = DBCache.GetDatatable(sqliteHelper_, text3);
			}
			else if (Operators.CompareString(left, "设施", TextCompare: true) == 0)
			{
				string text4 = "Select * from DataFacility where ID = " + DBIDGOTO.Text;
				dataTable = DBCache.GetDatatable(sqliteHelper_, text4);
			}
			else if (Operators.CompareString(left, "卫星", TextCompare: true) == 0)
			{
				string text5 = "Select * from DataSatellite where ID = " + DBIDGOTO.Text;
				dataTable = DBCache.GetDatatable(sqliteHelper_, text5);
			}
			else if (Operators.CompareString(left, "武器", TextCompare: true) == 0)
			{
				string text6 = "Select * from DataWeapon where ID = " + DBIDGOTO.Text;
				dataTable = DBCache.GetDatatable(sqliteHelper_, text6);
			}
			else if (Operators.CompareString(left, "传感器", TextCompare: true) == 0)
			{
				string text7 = "Select * from DataSensor where ID = " + DBIDGOTO.Text;
				dataTable = DBCache.GetDatatable(sqliteHelper_, text7);
			}
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DisplayDataBaseEntry(Conversions.ToInteger(DBIDGOTO.Text), CB_ObjectType.Text);
				DBIDGOTO.Text = "";
			}
		}
	}

	public void DisplayDataBaseEntry(int int_0, string string_1)
	{
		if (DisplayInfoInDetailsPanel(int_0, string_1))
		{
			if (DBViewerNavigationHistory.Count <= 0 || DBViewerNavigationHistory[DBViewerNavigationHistory.Count - 1].DBID != SelectedObjectID)
			{
				DBViewerNavigationHistory.Add(new DBViewerNavigationHistoryItem(SelectedObjectID, SelectedObjectType));
				NavigationHistoryPosition = DBViewerNavigationHistory.Count - 1;
			}
			RefreshNavigationHistoryButtons();
			if (!string.IsNullOrEmpty(HighlightTarget))
			{
				ScrollToSpecificElement(HighlightTarget);
			}
		}
	}

	private void PatchInitializer(object sender, EventArgs e)
	{
		ComputeInitializer();
	}

	private void SelectInitializer(object sender, EventArgs e)
	{
		DBIDGOTO._T.SelectAll();
	}

	private void CallInitializer(object sender, EventArgs e)
	{
		DBViewer.OpenNewDatabaseWindow(SelectedObjectType, SelectedObjectID);
	}

	public void BindCombobox_SubType(short short_0)
	{
		DataTable dataTable = new DataTable();
		if (!dataTable.Columns.Contains("ID"))
		{
			dataTable.Columns.Add("ID", typeof(int));
		}
		if (!dataTable.Columns.Contains("Description"))
		{
			dataTable.Columns.Add("Description", typeof(string));
		}
		dataTable.Rows.Clear();
		int selectedIndex = CB_ObjectType.SelectedIndex;
		switch (selectedIndex)
		{
		default:
		{
			if (selectedIndex != _EventContainer)
			{
				break;
			}
			int num8 = 0;
			IEnumerator enumerator8 = null;
			try
			{
				enumerator8 = Enum.GetValues(typeof(Sensor.Sensor_Type)).GetEnumerator();
				while (enumerator8.MoveNext())
				{
					Sensor.Sensor_Type sensor_Type = (Sensor.Sensor_Type)Conversions.ToShort(enumerator8.Current);
					dataTable.Rows.Add((int)sensor_Type, sensor_Type.ToString());
					if (selectedSubType > 0 && (int)sensor_Type == selectedSubType)
					{
						short_0 = (short)num8;
					}
					num8++;
				}
			}
			finally
			{
				if (enumerator8 is IDisposable)
				{
					(enumerator8 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 0:
		{
			int num7 = 0;
			IEnumerator enumerator7 = null;
			try
			{
				enumerator7 = Enum.GetValues(typeof(Aircraft._AircraftType)).GetEnumerator();
				while (enumerator7.MoveNext())
				{
					Aircraft._AircraftType aircraftType = (Aircraft._AircraftType)Conversions.ToInteger(enumerator7.Current);
					string text6 = Misc.Description(aircraftType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(aircraftType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)aircraftType, aircraftType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)aircraftType, text6);
					}
					if (selectedSubType > 0 && aircraftType == (Aircraft._AircraftType)selectedSubType)
					{
						short_0 = (short)num7;
					}
					num7++;
				}
			}
			finally
			{
				if (enumerator7 is IDisposable)
				{
					(enumerator7 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 1:
		{
			int num6 = 0;
			IEnumerator enumerator6 = null;
			try
			{
				enumerator6 = Enum.GetValues(typeof(Ship._ShipType)).GetEnumerator();
				while (enumerator6.MoveNext())
				{
					Ship._ShipType shipType = (Ship._ShipType)Conversions.ToInteger(enumerator6.Current);
					string text5 = Misc.Description(shipType, Client.CurrentScenario.DBConnection);
					Misc.Description(shipType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(shipType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)shipType, shipType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)shipType, text5);
					}
					if (selectedSubType > 0 && shipType == (Ship._ShipType)selectedSubType)
					{
						short_0 = (short)num6;
					}
					num6++;
				}
			}
			finally
			{
				if (enumerator6 is IDisposable)
				{
					(enumerator6 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 2:
		{
			int num5 = 0;
			IEnumerator enumerator5 = null;
			try
			{
				enumerator5 = Enum.GetValues(typeof(Submarine._SubmarineType)).GetEnumerator();
				while (enumerator5.MoveNext())
				{
					Submarine._SubmarineType submarineType = (Submarine._SubmarineType)Conversions.ToInteger(enumerator5.Current);
					string text4 = Misc.Description(submarineType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(submarineType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)submarineType, submarineType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)submarineType, text4);
					}
					if (selectedSubType > 0 && submarineType == (Submarine._SubmarineType)selectedSubType)
					{
						short_0 = (short)num5;
					}
					num5++;
				}
			}
			finally
			{
				if (enumerator5 is IDisposable)
				{
					(enumerator5 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 3:
		{
			int num4 = 0;
			IEnumerator enumerator4 = null;
			try
			{
				enumerator4 = Enum.GetValues(typeof(Facility._FacilityCategory)).GetEnumerator();
				while (enumerator4.MoveNext())
				{
					Facility._FacilityCategory facilityCategory = (Facility._FacilityCategory)Conversions.ToShort(enumerator4.Current);
					string text3 = Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(facilityCategory, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)facilityCategory, facilityCategory.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)facilityCategory, text3);
					}
					if (selectedSubType > 0 && (int)facilityCategory == selectedSubType)
					{
						short_0 = (short)num4;
					}
					num4++;
				}
			}
			finally
			{
				if (enumerator4 is IDisposable)
				{
					(enumerator4 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 4:
		{
			int num3 = 0;
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = Enum.GetValues(typeof(IMobileGroundUnit._MobileUnitCategory)).GetEnumerator();
				while (enumerator3.MoveNext())
				{
					IMobileGroundUnit._MobileUnitCategory mobileUnitCategory = (IMobileGroundUnit._MobileUnitCategory)Conversions.ToInteger(enumerator3.Current);
					string text2 = Misc.ToEnglishString(mobileUnitCategory);
					if (string.IsNullOrEmpty(text2))
					{
						dataTable.Rows.Add((int)mobileUnitCategory, mobileUnitCategory.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)mobileUnitCategory, text2);
					}
					if (selectedSubType > 0 && mobileUnitCategory == (IMobileGroundUnit._MobileUnitCategory)selectedSubType)
					{
						short_0 = (short)num3;
					}
					num3++;
				}
			}
			finally
			{
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 5:
		{
			int num2 = 0;
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = Enum.GetValues(typeof(Satellite._SatelliteType)).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Satellite._SatelliteType satelliteType = (Satellite._SatelliteType)Conversions.ToInteger(enumerator2.Current);
					string text = Misc.Description(satelliteType, Client.CurrentScenario.DBConnection);
					if (string.IsNullOrEmpty(Misc.Description(satelliteType, Client.CurrentScenario.DBConnection)))
					{
						dataTable.Rows.Add((int)satelliteType, satelliteType.ToString());
					}
					else
					{
						dataTable.Rows.Add((int)satelliteType, text);
					}
					if (selectedSubType > 0 && satelliteType == (Satellite._SatelliteType)selectedSubType)
					{
						short_0 = (short)num2;
					}
					num2++;
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			break;
		}
		case 6:
		{
			int num = 0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = Enum.GetValues(typeof(Weapon._WeaponType)).GetEnumerator();
				while (enumerator.MoveNext())
				{
					Weapon._WeaponType weaponType = (Weapon._WeaponType)Conversions.ToShort(enumerator.Current);
					dataTable.Rows.Add((int)weaponType, weaponType.ToString());
					if (selectedSubType > 0 && (int)weaponType == selectedSubType)
					{
						short_0 = (short)num;
					}
					num++;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			break;
		}
		}
		if (short_0 < 0 || short_0 >= dataTable.Rows.Count)
		{
			short_0 = 0;
		}
		if (dataTable.Rows.Count <= 0)
		{
			dataTable.Rows.Add(0, "无");
			DarkUIComboBox cB_SubType = CB_SubType;
			cB_SubType.DataSource = dataTable;
			cB_SubType.DisplayMember = "Description";
			cB_SubType.ValueMember = "ID";
			cB_SubType.SelectedIndex = 0;
			cB_SubType.Enabled = false;
			cB_SubType.Visible = false;
		}
		else
		{
			DarkUIComboBox cB_SubType2 = CB_SubType;
			cB_SubType2.DataSource = dataTable;
			cB_SubType2.DisplayMember = "Description";
			cB_SubType2.ValueMember = "ID";
			cB_SubType2.SelectedIndex = short_0;
			cB_SubType2.Enabled = true;
			cB_SubType2.Visible = true;
		}
	}

	private void LogoutInitializer(object sender, EventArgs e)
	{
		selectedSubType = Conversions.ToInteger(((DarkUIComboBox)sender).SelectedValue);
		DefineIterator();
	}

	private void ViewInitializer(object sender, EventArgs e)
	{
		((HandledMouseEventArgs)e).Handled = true;
	}

	[CompilerGenerated]
	private void ValidateInitializer(object sender, EventArgs e)
	{
		GlobalSingleton.GetInstance().method_0(this);
		SuspendLayout();
		if (string.IsNullOrEmpty(SelectedObjectType))
		{
			SelectedObjectType = "飞机";
		}
		if (!CB_ObjectType.Items.Contains("传感器"))
		{
			_EventContainer = CB_ObjectType.Items.Add("传感器");
		}
		if (Operators.CompareString(SelectedObjectType, "武器", TextCompare: true) != 0 && Operators.CompareString(SelectedObjectType, "传感器", TextCompare: true) != 0)
		{
			CB_Country.Enabled = true;
			CB_Country.Visible = true;
		}
		else
		{
			CB_Country.Enabled = false;
			CB_Country.Visible = false;
		}
		DataTable cache_OperatorCountries_DT = Client.CurrentScenario.Cache_OperatorCountries_DT;
		CB_Country.DataSource = cache_OperatorCountries_DT;
		CB_Country.DisplayMember = "Description";
		CB_Country.ValueMember = "ID";
		CB_Country.SelectedIndex = 0;
		CB_Hypothetical.Items.Clear();
		CB_Hypothetical.Items.AddRange(new object[3] { "显示所有平台，包括真实和假想", "仅显示真实平台", "仅显示假想平台" });
		CB_Hypothetical.SelectedIndex = 0;
		BindCombobox_SubType(0);
		if (SelectedObjectID <= 0)
		{
			HighlightTarget = null;
			DefineIterator();
		}
		else
		{
			DisplaySelection(bool_0: true);
		}
		WebBrowser1.Focus();
		ResumeLayout();
	}

	[CompilerGenerated]
	private bool LoginInitializer(DarkListItem darkListItem_0)
	{
		return Conversions.ToInteger(darkListItem_0.Tag) == SelectedObjectID;
	}
}
