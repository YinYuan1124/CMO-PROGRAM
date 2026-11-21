using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command;
using Microsoft.VisualBasic.CompilerServices;

namespace OpenDis.Pages;

[DesignerGenerated]
internal class CallbackMerchantPage : DarkSecondaryFormBase
{
	private Container m_ModelTokenizer;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private GroupBox refTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox5")]
	private GroupBox connectionTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer _StatusTokenizer;

	[AccessedThroughProperty("StatusLabel")]
	[CompilerGenerated]
	private Label proccesorTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("UploadLabel")]
	private Label strategyTokenizer;

	[AccessedThroughProperty("TableLayoutPanel1")]
	[CompilerGenerated]
	private TableLayoutPanel m_ResolverTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TableLayoutPanel4")]
	private TableLayoutPanel adapterTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("PdusTabControl")]
	private DarkUITabControl m_SchemaTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("OutgoingPdusTabPage")]
	private TabPage utilsTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("TableLayoutPanel5")]
	private TableLayoutPanel singletonTokenizer;

	[AccessedThroughProperty("hideEntityStateAndUAPdusCheckBox")]
	[CompilerGenerated]
	private DarkUICheckBox recordTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("MissingDISIDsTextBox")]
	private DarkUITextBox attrTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("OutgoingTextBox")]
	private DarkUITextBox visitorTokenizer;

	[AccessedThroughProperty("IncomingTextBox")]
	[CompilerGenerated]
	private DarkUITextBox m_ExporterTokenizer;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private Label comparatorTokenizer;

	[AccessedThroughProperty("TableLayoutPanel6")]
	[CompilerGenerated]
	private TableLayoutPanel m_ItemTokenizer;

	[AccessedThroughProperty("remoteEntitiesTextBox")]
	[CompilerGenerated]
	private DarkUITextBox creatorTokenizer;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private Label mappingTokenizer;

	[AccessedThroughProperty("ClearRecentPDUsListsButton")]
	[CompilerGenerated]
	private DarkUIButton tagTokenizer;

	[field: AccessedThroughProperty("DISSettingsTextBox")]
	internal virtual DarkUITextBox DarkUITextBox_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("McastSocketTextBox")]
	internal virtual DarkUITextBox McastSocketTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SendSocketTextBox")]
	internal virtual DarkUITextBox SendSocketTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return refTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			refTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual GroupBox GroupBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual GroupBox GroupBox4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return connectionTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			connectionTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox6")]
	internal virtual GroupBox GroupBox6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Label StatusLabel
	{
		[CompilerGenerated]
		get
		{
			return proccesorTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorTokenizer = value;
		}
	}

	internal virtual Label UploadLabel
	{
		[CompilerGenerated]
		get
		{
			return strategyTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			strategyTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("DownloadLabel")]
	internal virtual Label DownloadLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("AdaptersTextBox")]
	internal virtual DarkUITextBox AdaptersTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LBL_Config_Folder")]
	internal virtual Label LBL_Config_Folder
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TableLayoutPanel TableLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ResolverTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("TableLayoutPanel2")]
	internal virtual TableLayoutPanel TableLayoutPanel2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TableLayoutPanel3")]
	internal virtual TableLayoutPanel TableLayoutPanel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TableLayoutPanel TableLayoutPanel4
	{
		[CompilerGenerated]
		get
		{
			return adapterTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			adapterTokenizer = value;
		}
	}

	internal virtual DarkUITabControl PdusTabControl
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SchemaTokenizer = value;
		}
	}

	internal virtual TabPage OutgoingPdusTabPage
	{
		[CompilerGenerated]
		get
		{
			return utilsTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			utilsTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("EntitySummariesTabPage")]
	internal virtual TabPage EntitySummariesTabPage
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TableLayoutPanel TableLayoutPanel5
	{
		[CompilerGenerated]
		get
		{
			return singletonTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			singletonTokenizer = value;
		}
	}

	internal virtual DarkUICheckBox hideEntityStateAndUAPdusCheckBox
	{
		[CompilerGenerated]
		get
		{
			return recordTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			recordTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("MissingDISIDsTabPage")]
	internal virtual TabPage TabPage_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUITextBox DarkUITextBox_1
	{
		[CompilerGenerated]
		get
		{
			return attrTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			attrTokenizer = value;
		}
	}

	internal virtual DarkUITextBox OutgoingTextBox
	{
		[CompilerGenerated]
		get
		{
			return visitorTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			visitorTokenizer = value;
		}
	}

	internal virtual DarkUITextBox IncomingTextBox
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return comparatorTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			comparatorTokenizer = value;
		}
	}

	internal virtual TableLayoutPanel TableLayoutPanel6
	{
		[CompilerGenerated]
		get
		{
			return m_ItemTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ItemTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("localEntitiesTextBox")]
	internal virtual DarkUITextBox localEntitiesTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUITextBox remoteEntitiesTextBox
	{
		[CompilerGenerated]
		get
		{
			return creatorTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			creatorTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return mappingTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mappingTokenizer = value;
		}
	}

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ClearRecentPDUsListsButton
	{
		[CompilerGenerated]
		get
		{
			return tagTokenizer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tagTokenizer = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual Timer VerifyInterruptibleAlgo()
	{
		return _StatusTokenizer;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void ListInterruptibleAlgo(Timer timer_0)
	{
		_StatusTokenizer = timer_0;
	}

	public CallbackMerchantPage()
	{
		AssetServer();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ModelTokenizer != null)
			{
				((IDisposable)m_ModelTokenizer).Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AssetServer()
	{
		m_ModelTokenizer = new Container();
		DarkUITextBox_0 = new DarkUITextBox();
		McastSocketTextBox = new DarkUITextBox();
		SendSocketTextBox = new DarkUITextBox();
		GroupBox1 = new GroupBox();
		AdaptersTextBox = new DarkUITextBox();
		GroupBox3 = new GroupBox();
		TableLayoutPanel2 = new TableLayoutPanel();
		LBL_Config_Folder = new Label();
		GroupBox4 = new GroupBox();
		GroupBox5 = new GroupBox();
		GroupBox6 = new GroupBox();
		TableLayoutPanel3 = new TableLayoutPanel();
		UploadLabel = new Label();
		DownloadLabel = new Label();
		ListInterruptibleAlgo(new Timer(m_ModelTokenizer));
		StatusLabel = new Label();
		TableLayoutPanel1 = new TableLayoutPanel();
		TableLayoutPanel4 = new TableLayoutPanel();
		PdusTabControl = new DarkUITabControl();
		OutgoingPdusTabPage = new TabPage();
		TableLayoutPanel5 = new TableLayoutPanel();
		OutgoingTextBox = new DarkUITextBox();
		IncomingTextBox = new DarkUITextBox();
		hideEntityStateAndUAPdusCheckBox = new DarkUICheckBox();
		Label1 = new Label();
		Label2 = new Label();
		EntitySummariesTabPage = new TabPage();
		TableLayoutPanel6 = new TableLayoutPanel();
		localEntitiesTextBox = new DarkUITextBox();
		remoteEntitiesTextBox = new DarkUITextBox();
		Label3 = new Label();
		Label4 = new Label();
		TabPage_0 = new TabPage();
		DarkUITextBox_1 = new DarkUITextBox();
		SplitContainer1 = new SplitContainer();
		ClearRecentPDUsListsButton = new DarkUIButton();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		TableLayoutPanel2.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox6.SuspendLayout();
		TableLayoutPanel3.SuspendLayout();
		TableLayoutPanel1.SuspendLayout();
		TableLayoutPanel4.SuspendLayout();
		PdusTabControl.SuspendLayout();
		OutgoingPdusTabPage.SuspendLayout();
		TableLayoutPanel5.SuspendLayout();
		EntitySummariesTabPage.SuspendLayout();
		TableLayoutPanel6.SuspendLayout();
		TabPage_0.SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		SplitContainer1.Panel1.SuspendLayout();
		SplitContainer1.Panel2.SuspendLayout();
		SplitContainer1.SuspendLayout();
		SuspendLayout();
		DarkUITextBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DarkUITextBox_0.AutoCompleteCustomSource = null;
		DarkUITextBox_0.AutoCompleteMode = AutoCompleteMode.None;
		DarkUITextBox_0.AutoCompleteSource = AutoCompleteSource.None;
		DarkUITextBox_0.BackColor = Color.Transparent;
		DarkUITextBox_0.ForeColor = Color.FromArgb(189, 189, 189);
		DarkUITextBox_0.Image = null;
		DarkUITextBox_0.Lines = null;
		DarkUITextBox_0.Location = new Point(3, 18);
		DarkUITextBox_0.MaxLength = 32767;
		DarkUITextBox_0.Multiline = true;
		DarkUITextBox_0.Name = "DISSettingsTextBox";
		DarkUITextBox_0.ReadOnly = false;
		DarkUITextBox_0.ScrollBars = ScrollBars.None;
		DarkUITextBox_0.SelectionStart = 0;
		DarkUITextBox_0.Size = new Size(248, 297);
		DarkUITextBox_0.TabIndex = 0;
		DarkUITextBox_0.TextAlign = HorizontalAlignment.Left;
		DarkUITextBox_0.UseSystemPasswordChar = false;
		DarkUITextBox_0.WatermarkText = "";
		McastSocketTextBox.AutoCompleteCustomSource = null;
		McastSocketTextBox.AutoCompleteMode = AutoCompleteMode.None;
		McastSocketTextBox.AutoCompleteSource = AutoCompleteSource.None;
		McastSocketTextBox.BackColor = Color.Transparent;
		McastSocketTextBox.Dock = DockStyle.Fill;
		McastSocketTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		McastSocketTextBox.Image = null;
		McastSocketTextBox.Lines = null;
		McastSocketTextBox.Location = new Point(3, 19);
		McastSocketTextBox.MaxLength = 32767;
		McastSocketTextBox.Multiline = true;
		McastSocketTextBox.Name = "McastSocketTextBox";
		McastSocketTextBox.ReadOnly = false;
		McastSocketTextBox.ScrollBars = ScrollBars.None;
		McastSocketTextBox.SelectionStart = 0;
		McastSocketTextBox.Size = new Size(255, 317);
		McastSocketTextBox.TabIndex = 1;
		McastSocketTextBox.TextAlign = HorizontalAlignment.Left;
		McastSocketTextBox.UseSystemPasswordChar = false;
		McastSocketTextBox.WatermarkText = "";
		SendSocketTextBox.AutoCompleteCustomSource = null;
		SendSocketTextBox.AutoCompleteMode = AutoCompleteMode.None;
		SendSocketTextBox.AutoCompleteSource = AutoCompleteSource.None;
		SendSocketTextBox.BackColor = Color.Transparent;
		SendSocketTextBox.Dock = DockStyle.Fill;
		SendSocketTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		SendSocketTextBox.Image = null;
		SendSocketTextBox.Lines = null;
		SendSocketTextBox.Location = new Point(3, 19);
		SendSocketTextBox.MaxLength = 32767;
		SendSocketTextBox.Multiline = true;
		SendSocketTextBox.Name = "SendSocketTextBox";
		SendSocketTextBox.ReadOnly = false;
		SendSocketTextBox.ScrollBars = ScrollBars.None;
		SendSocketTextBox.SelectionStart = 0;
		SendSocketTextBox.Size = new Size(255, 318);
		SendSocketTextBox.TabIndex = 2;
		SendSocketTextBox.TextAlign = HorizontalAlignment.Left;
		SendSocketTextBox.UseSystemPasswordChar = false;
		SendSocketTextBox.WatermarkText = "";
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox1.Controls.Add(AdaptersTextBox);
		GroupBox1.ForeColor = Color.White;
		GroupBox1.Location = new Point(3, 3);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(260, 339);
		GroupBox1.TabIndex = 3;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Adapters";
		AdaptersTextBox.AutoCompleteCustomSource = null;
		AdaptersTextBox.AutoCompleteMode = AutoCompleteMode.None;
		AdaptersTextBox.AutoCompleteSource = AutoCompleteSource.None;
		AdaptersTextBox.BackColor = Color.Transparent;
		AdaptersTextBox.Dock = DockStyle.Fill;
		AdaptersTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		AdaptersTextBox.Image = null;
		AdaptersTextBox.Lines = null;
		AdaptersTextBox.Location = new Point(3, 19);
		AdaptersTextBox.MaxLength = 32767;
		AdaptersTextBox.Multiline = true;
		AdaptersTextBox.Name = "AdaptersTextBox";
		AdaptersTextBox.ReadOnly = false;
		AdaptersTextBox.ScrollBars = ScrollBars.None;
		AdaptersTextBox.SelectionStart = 0;
		AdaptersTextBox.Size = new Size(254, 317);
		AdaptersTextBox.TabIndex = 3;
		AdaptersTextBox.TextAlign = HorizontalAlignment.Left;
		AdaptersTextBox.UseSystemPasswordChar = false;
		AdaptersTextBox.WatermarkText = "";
		GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox3.Controls.Add(TableLayoutPanel2);
		GroupBox3.ForeColor = Color.White;
		GroupBox3.Location = new Point(3, 348);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(260, 340);
		GroupBox3.TabIndex = 5;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Status summary and Settings";
		TableLayoutPanel2.ColumnCount = 1;
		TableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		TableLayoutPanel2.Controls.Add(DarkUITextBox_0, 0, 1);
		TableLayoutPanel2.Controls.Add(LBL_Config_Folder, 0, 0);
		TableLayoutPanel2.Dock = DockStyle.Fill;
		TableLayoutPanel2.Location = new Point(3, 19);
		TableLayoutPanel2.Name = "TableLayoutPanel2";
		TableLayoutPanel2.RowCount = 2;
		TableLayoutPanel2.RowStyles.Add(new RowStyle());
		TableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel2.Size = new Size(254, 318);
		TableLayoutPanel2.TabIndex = 10;
		LBL_Config_Folder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LBL_Config_Folder.AutoSize = true;
		LBL_Config_Folder.ForeColor = Color.White;
		LBL_Config_Folder.Location = new Point(3, 0);
		LBL_Config_Folder.Name = "LBL_Config_Folder";
		LBL_Config_Folder.Size = new Size(248, 15);
		LBL_Config_Folder.TabIndex = 9;
		LBL_Config_Folder.Text = "LBL_Config_Folder";
		GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox4.Controls.Add(SendSocketTextBox);
		GroupBox4.ForeColor = Color.White;
		GroupBox4.Location = new Point(269, 348);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(261, 340);
		GroupBox4.TabIndex = 5;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "send SOCKET";
		GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox5.Controls.Add(McastSocketTextBox);
		GroupBox5.ForeColor = Color.White;
		GroupBox5.Location = new Point(269, 3);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(261, 339);
		GroupBox5.TabIndex = 6;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "mcast SOCKET";
		GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox6.Controls.Add(TableLayoutPanel3);
		GroupBox6.ForeColor = Color.White;
		GroupBox6.Location = new Point(3, 623);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(933, 65);
		GroupBox6.TabIndex = 6;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Traffic";
		TableLayoutPanel3.ColumnCount = 1;
		TableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		TableLayoutPanel3.Controls.Add(UploadLabel, 0, 1);
		TableLayoutPanel3.Controls.Add(DownloadLabel, 0, 3);
		TableLayoutPanel3.Dock = DockStyle.Fill;
		TableLayoutPanel3.Location = new Point(3, 19);
		TableLayoutPanel3.Name = "TableLayoutPanel3";
		TableLayoutPanel3.RowCount = 5;
		TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
		TableLayoutPanel3.RowStyles.Add(new RowStyle());
		TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
		TableLayoutPanel3.RowStyles.Add(new RowStyle());
		TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
		TableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel3.Size = new Size(927, 43);
		TableLayoutPanel3.TabIndex = 9;
		UploadLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		UploadLabel.AutoSize = true;
		UploadLabel.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		UploadLabel.Location = new Point(3, 1);
		UploadLabel.Name = "UploadLabel";
		UploadLabel.Size = new Size(921, 20);
		UploadLabel.TabIndex = 8;
		UploadLabel.Text = "Upload: ";
		UploadLabel.TextAlign = ContentAlignment.MiddleCenter;
		DownloadLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
		DownloadLabel.AutoSize = true;
		DownloadLabel.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		DownloadLabel.Location = new Point(3, 22);
		DownloadLabel.Name = "DownloadLabel";
		DownloadLabel.Size = new Size(921, 20);
		DownloadLabel.TabIndex = 8;
		DownloadLabel.Text = "Download: ";
		DownloadLabel.TextAlign = ContentAlignment.MiddleCenter;
		StatusLabel.AutoSize = true;
		StatusLabel.Location = new Point(120, 19);
		StatusLabel.Name = "StatusLabel";
		StatusLabel.Size = new Size(0, 15);
		StatusLabel.TabIndex = 8;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20f));
		TableLayoutPanel1.Controls.Add(GroupBox1, 0, 0);
		TableLayoutPanel1.Controls.Add(GroupBox5, 1, 0);
		TableLayoutPanel1.Controls.Add(GroupBox3, 0, 1);
		TableLayoutPanel1.Controls.Add(GroupBox4, 1, 1);
		TableLayoutPanel1.Dock = DockStyle.Fill;
		TableLayoutPanel1.Location = new Point(0, 0);
		TableLayoutPanel1.Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 2;
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
		TableLayoutPanel1.Size = new Size(533, 691);
		TableLayoutPanel1.TabIndex = 10;
		TableLayoutPanel4.ColumnCount = 1;
		TableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		TableLayoutPanel4.Controls.Add(GroupBox6, 0, 1);
		TableLayoutPanel4.Controls.Add(PdusTabControl, 0, 0);
		TableLayoutPanel4.Dock = DockStyle.Fill;
		TableLayoutPanel4.Location = new Point(0, 0);
		TableLayoutPanel4.Margin = new Padding(0);
		TableLayoutPanel4.Name = "TableLayoutPanel4";
		TableLayoutPanel4.RowCount = 2;
		TableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel4.RowStyles.Add(new RowStyle());
		TableLayoutPanel4.Size = new Size(939, 691);
		TableLayoutPanel4.TabIndex = 7;
		PdusTabControl.Controls.Add(OutgoingPdusTabPage);
		PdusTabControl.Controls.Add(EntitySummariesTabPage);
		PdusTabControl.Controls.Add(TabPage_0);
		PdusTabControl.Cursor = Cursors.Hand;
		PdusTabControl.Dock = DockStyle.Fill;
		PdusTabControl.ItemSize = new Size(80, 20);
		PdusTabControl.Location = new Point(1, 1);
		PdusTabControl.Margin = new Padding(1);
		PdusTabControl.Name = "PdusTabControl";
		PdusTabControl.SelectedIndex = 0;
		PdusTabControl.Size = new Size(937, 618);
		PdusTabControl.TabIndex = 4;
		OutgoingPdusTabPage.BackColor = Color.FromArgb(60, 63, 65);
		OutgoingPdusTabPage.Controls.Add(TableLayoutPanel5);
		OutgoingPdusTabPage.Location = new Point(4, 24);
		OutgoingPdusTabPage.Margin = new Padding(1);
		OutgoingPdusTabPage.Name = "OutgoingPdusTabPage";
		OutgoingPdusTabPage.Padding = new Padding(1);
		OutgoingPdusTabPage.Size = new Size(929, 590);
		OutgoingPdusTabPage.TabIndex = 0;
		OutgoingPdusTabPage.Text = "PDUs";
		TableLayoutPanel5.ColumnCount = 2;
		TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel5.Controls.Add(OutgoingTextBox, 0, 1);
		TableLayoutPanel5.Controls.Add(IncomingTextBox, 0, 1);
		TableLayoutPanel5.Controls.Add(hideEntityStateAndUAPdusCheckBox, 0, 2);
		TableLayoutPanel5.Controls.Add(Label1, 0, 0);
		TableLayoutPanel5.Controls.Add(Label2, 1, 0);
		TableLayoutPanel5.Controls.Add(ClearRecentPDUsListsButton, 1, 2);
		TableLayoutPanel5.Dock = DockStyle.Fill;
		TableLayoutPanel5.Location = new Point(1, 1);
		TableLayoutPanel5.Name = "TableLayoutPanel5";
		TableLayoutPanel5.RowCount = 3;
		TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel5.RowStyles.Add(new RowStyle());
		TableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel5.Size = new Size(927, 588);
		TableLayoutPanel5.TabIndex = 4;
		OutgoingTextBox.AutoCompleteCustomSource = null;
		OutgoingTextBox.AutoCompleteMode = AutoCompleteMode.None;
		OutgoingTextBox.AutoCompleteSource = AutoCompleteSource.None;
		OutgoingTextBox.BackColor = Color.Transparent;
		OutgoingTextBox.Dock = DockStyle.Fill;
		OutgoingTextBox.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		OutgoingTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		OutgoingTextBox.Image = null;
		OutgoingTextBox.Lines = null;
		OutgoingTextBox.Location = new Point(1, 21);
		OutgoingTextBox.Margin = new Padding(1);
		OutgoingTextBox.MaxLength = 32767;
		OutgoingTextBox.Multiline = true;
		OutgoingTextBox.Name = "OutgoingTextBox";
		OutgoingTextBox.ReadOnly = false;
		OutgoingTextBox.ScrollBars = ScrollBars.None;
		OutgoingTextBox.SelectionStart = 0;
		OutgoingTextBox.Size = new Size(461, 537);
		OutgoingTextBox.TabIndex = 5;
		OutgoingTextBox.TextAlign = HorizontalAlignment.Left;
		OutgoingTextBox.UseSystemPasswordChar = false;
		OutgoingTextBox.WatermarkText = "";
		IncomingTextBox.AutoCompleteCustomSource = null;
		IncomingTextBox.AutoCompleteMode = AutoCompleteMode.None;
		IncomingTextBox.AutoCompleteSource = AutoCompleteSource.None;
		IncomingTextBox.BackColor = Color.Transparent;
		IncomingTextBox.Dock = DockStyle.Fill;
		IncomingTextBox.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		IncomingTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		IncomingTextBox.Image = null;
		IncomingTextBox.Lines = null;
		IncomingTextBox.Location = new Point(464, 21);
		IncomingTextBox.Margin = new Padding(1);
		IncomingTextBox.MaxLength = 32767;
		IncomingTextBox.Multiline = true;
		IncomingTextBox.Name = "IncomingTextBox";
		IncomingTextBox.ReadOnly = false;
		IncomingTextBox.ScrollBars = ScrollBars.None;
		IncomingTextBox.SelectionStart = 0;
		IncomingTextBox.Size = new Size(462, 537);
		IncomingTextBox.TabIndex = 3;
		IncomingTextBox.TextAlign = HorizontalAlignment.Left;
		IncomingTextBox.UseSystemPasswordChar = false;
		IncomingTextBox.WatermarkText = "";
		hideEntityStateAndUAPdusCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		hideEntityStateAndUAPdusCheckBox.BackColor = Color.Transparent;
		hideEntityStateAndUAPdusCheckBox.Checked = true;
		hideEntityStateAndUAPdusCheckBox.Cursor = Cursors.Hand;
		hideEntityStateAndUAPdusCheckBox.ForeColor = Color.FromArgb(209, 209, 209);
		hideEntityStateAndUAPdusCheckBox.Location = new Point(3, 562);
		hideEntityStateAndUAPdusCheckBox.Name = "hideEntityStateAndUAPdusCheckBox";
		hideEntityStateAndUAPdusCheckBox.Size = new Size(457, 18);
		hideEntityStateAndUAPdusCheckBox.TabIndex = 4;
		hideEntityStateAndUAPdusCheckBox.Text = "Hide EntityState and UnderwaterAcoustics pdus";
		Label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.White;
		Label1.Location = new Point(3, 0);
		Label1.Name = "Label1";
		Label1.Size = new Size(457, 20);
		Label1.TabIndex = 6;
		Label1.Text = "Outgoing PDUs";
		Label1.TextAlign = ContentAlignment.MiddleCenter;
		Label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.White;
		Label2.Location = new Point(466, 0);
		Label2.Name = "Label2";
		Label2.Size = new Size(458, 20);
		Label2.TabIndex = 6;
		Label2.Text = "Incoming PDUs";
		Label2.TextAlign = ContentAlignment.MiddleCenter;
		EntitySummariesTabPage.BackColor = Color.FromArgb(60, 63, 65);
		EntitySummariesTabPage.Controls.Add(TableLayoutPanel6);
		EntitySummariesTabPage.Location = new Point(4, 24);
		EntitySummariesTabPage.Margin = new Padding(1);
		EntitySummariesTabPage.Name = "EntitySummariesTabPage";
		EntitySummariesTabPage.Padding = new Padding(1);
		EntitySummariesTabPage.Size = new Size(929, 590);
		EntitySummariesTabPage.TabIndex = 1;
		EntitySummariesTabPage.Text = "Entity summaries";
		TableLayoutPanel6.ColumnCount = 2;
		TableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
		TableLayoutPanel6.Controls.Add(localEntitiesTextBox, 0, 2);
		TableLayoutPanel6.Controls.Add(remoteEntitiesTextBox, 0, 2);
		TableLayoutPanel6.Controls.Add(Label3, 0, 1);
		TableLayoutPanel6.Controls.Add(Label4, 1, 1);
		TableLayoutPanel6.Dock = DockStyle.Fill;
		TableLayoutPanel6.Location = new Point(1, 1);
		TableLayoutPanel6.Name = "TableLayoutPanel6";
		TableLayoutPanel6.RowCount = 3;
		TableLayoutPanel6.RowStyles.Add(new RowStyle());
		TableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
		TableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		TableLayoutPanel6.Size = new Size(927, 588);
		TableLayoutPanel6.TabIndex = 5;
		localEntitiesTextBox.AutoCompleteCustomSource = null;
		localEntitiesTextBox.AutoCompleteMode = AutoCompleteMode.None;
		localEntitiesTextBox.AutoCompleteSource = AutoCompleteSource.None;
		localEntitiesTextBox.BackColor = Color.Transparent;
		localEntitiesTextBox.Dock = DockStyle.Fill;
		localEntitiesTextBox.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		localEntitiesTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		localEntitiesTextBox.Image = null;
		localEntitiesTextBox.Lines = null;
		localEntitiesTextBox.Location = new Point(1, 21);
		localEntitiesTextBox.Margin = new Padding(1);
		localEntitiesTextBox.MaxLength = 32767;
		localEntitiesTextBox.Multiline = true;
		localEntitiesTextBox.Name = "localEntitiesTextBox";
		localEntitiesTextBox.ReadOnly = false;
		localEntitiesTextBox.ScrollBars = ScrollBars.None;
		localEntitiesTextBox.SelectionStart = 0;
		localEntitiesTextBox.Size = new Size(461, 566);
		localEntitiesTextBox.TabIndex = 5;
		localEntitiesTextBox.TextAlign = HorizontalAlignment.Left;
		localEntitiesTextBox.UseSystemPasswordChar = false;
		localEntitiesTextBox.WatermarkText = "";
		remoteEntitiesTextBox.AutoCompleteCustomSource = null;
		remoteEntitiesTextBox.AutoCompleteMode = AutoCompleteMode.None;
		remoteEntitiesTextBox.AutoCompleteSource = AutoCompleteSource.None;
		remoteEntitiesTextBox.BackColor = Color.Transparent;
		remoteEntitiesTextBox.Dock = DockStyle.Fill;
		remoteEntitiesTextBox.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		remoteEntitiesTextBox.ForeColor = Color.FromArgb(189, 189, 189);
		remoteEntitiesTextBox.Image = null;
		remoteEntitiesTextBox.Lines = null;
		remoteEntitiesTextBox.Location = new Point(464, 21);
		remoteEntitiesTextBox.Margin = new Padding(1);
		remoteEntitiesTextBox.MaxLength = 32767;
		remoteEntitiesTextBox.Multiline = true;
		remoteEntitiesTextBox.Name = "remoteEntitiesTextBox";
		remoteEntitiesTextBox.ReadOnly = false;
		remoteEntitiesTextBox.ScrollBars = ScrollBars.None;
		remoteEntitiesTextBox.SelectionStart = 0;
		remoteEntitiesTextBox.Size = new Size(462, 566);
		remoteEntitiesTextBox.TabIndex = 3;
		remoteEntitiesTextBox.TextAlign = HorizontalAlignment.Left;
		remoteEntitiesTextBox.UseSystemPasswordChar = false;
		remoteEntitiesTextBox.WatermarkText = "";
		Label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label3.AutoSize = true;
		Label3.ForeColor = Color.White;
		Label3.Location = new Point(3, 0);
		Label3.Name = "Label3";
		Label3.Size = new Size(457, 20);
		Label3.TabIndex = 6;
		Label3.Text = "Local Entities";
		Label3.TextAlign = ContentAlignment.MiddleCenter;
		Label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.White;
		Label4.Location = new Point(466, 0);
		Label4.Name = "Label4";
		Label4.Size = new Size(458, 20);
		Label4.TabIndex = 6;
		Label4.Text = "Remote Entities";
		Label4.TextAlign = ContentAlignment.MiddleCenter;
		TabPage_0.BackColor = Color.FromArgb(60, 63, 65);
		TabPage_0.Controls.Add(DarkUITextBox_1);
		TabPage_0.Location = new Point(4, 24);
		TabPage_0.Margin = new Padding(1);
		TabPage_0.Name = "MissingDISIDsTabPage";
		TabPage_0.Padding = new Padding(1);
		TabPage_0.Size = new Size(929, 590);
		TabPage_0.TabIndex = 2;
		TabPage_0.Text = "Missing DIS IDs";
		DarkUITextBox_1.AutoCompleteCustomSource = null;
		DarkUITextBox_1.AutoCompleteMode = AutoCompleteMode.None;
		DarkUITextBox_1.AutoCompleteSource = AutoCompleteSource.None;
		DarkUITextBox_1.BackColor = Color.Transparent;
		DarkUITextBox_1.Dock = DockStyle.Fill;
		DarkUITextBox_1.ForeColor = Color.FromArgb(189, 189, 189);
		DarkUITextBox_1.Image = null;
		DarkUITextBox_1.Lines = null;
		DarkUITextBox_1.Location = new Point(1, 1);
		DarkUITextBox_1.Margin = new Padding(1);
		DarkUITextBox_1.MaxLength = 32767;
		DarkUITextBox_1.Multiline = true;
		DarkUITextBox_1.Name = "MissingDISIDsTextBox";
		DarkUITextBox_1.ReadOnly = false;
		DarkUITextBox_1.ScrollBars = ScrollBars.None;
		DarkUITextBox_1.SelectionStart = 0;
		DarkUITextBox_1.Size = new Size(927, 588);
		DarkUITextBox_1.TabIndex = 4;
		DarkUITextBox_1.TextAlign = HorizontalAlignment.Left;
		DarkUITextBox_1.UseSystemPasswordChar = false;
		DarkUITextBox_1.WatermarkText = "";
		SplitContainer1.Dock = DockStyle.Fill;
		SplitContainer1.Location = new Point(0, 0);
		SplitContainer1.Name = "SplitContainer1";
		SplitContainer1.Panel1.Controls.Add(TableLayoutPanel1);
		SplitContainer1.Panel2.Controls.Add(TableLayoutPanel4);
		SplitContainer1.Size = new Size(1476, 691);
		SplitContainer1.SplitterDistance = 533;
		SplitContainer1.TabIndex = 2;
		ClearRecentPDUsListsButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		ClearRecentPDUsListsButton.BackColor = Color.Transparent;
		ClearRecentPDUsListsButton.DialogResult = DialogResult.None;
		ClearRecentPDUsListsButton.ForeColor = SystemColors.Control;
		ClearRecentPDUsListsButton.Location = new Point(788, 562);
		ClearRecentPDUsListsButton.Name = "ClearRecentPDUsListsButton";
		ClearRecentPDUsListsButton.RoundRadius = 0;
		ClearRecentPDUsListsButton.Size = new Size(136, 23);
		ClearRecentPDUsListsButton.TabIndex = 7;
		ClearRecentPDUsListsButton.Text = "Clear PDU lists";
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1476, 691);
		base.Controls.Add(SplitContainer1);
		base.Controls.Add(StatusLabel);
		base.Name = "DISForm";
		Text = "DIS Status Display";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox3.ResumeLayout(performLayout: false);
		TableLayoutPanel2.ResumeLayout(performLayout: false);
		TableLayoutPanel2.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox6.ResumeLayout(performLayout: false);
		TableLayoutPanel3.ResumeLayout(performLayout: false);
		TableLayoutPanel3.PerformLayout();
		TableLayoutPanel1.ResumeLayout(performLayout: false);
		TableLayoutPanel4.ResumeLayout(performLayout: false);
		PdusTabControl.ResumeLayout(performLayout: false);
		OutgoingPdusTabPage.ResumeLayout(performLayout: false);
		TableLayoutPanel5.ResumeLayout(performLayout: false);
		TableLayoutPanel5.PerformLayout();
		EntitySummariesTabPage.ResumeLayout(performLayout: false);
		TableLayoutPanel6.ResumeLayout(performLayout: false);
		TableLayoutPanel6.PerformLayout();
		TabPage_0.ResumeLayout(performLayout: false);
		SplitContainer1.Panel1.ResumeLayout(performLayout: false);
		SplitContainer1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)SplitContainer1).EndInit();
		SplitContainer1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
