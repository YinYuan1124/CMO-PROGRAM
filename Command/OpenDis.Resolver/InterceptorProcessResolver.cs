using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace OpenDis.Resolver;

[DesignerGenerated]
internal class InterceptorProcessResolver : Form
{
	private IDisposable m_StrategyContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("ControlTab")]
	private DarkUITabControl configurationContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("ExportSettingsTab")]
	private TabPage tokenContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("OutputRootDirectory")]
	private DarkLabel publisherContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ExportSIMDIS")]
	private DarkCheckBox serverContainer;

	[AccessedThroughProperty("CB_ExportSQLite")]
	[CompilerGenerated]
	private DarkCheckBox adapterContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ExportSQLServer")]
	private DarkCheckBox m_SchemaContainer;

	[AccessedThroughProperty("CB_ExportTacview2x")]
	[CompilerGenerated]
	private DarkCheckBox m_SingletonContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ExportXML")]
	private DarkCheckBox m_RecordContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ExportTacview1x")]
	private DarkCheckBox exceptionContainer;

	[AccessedThroughProperty("PropertyGridCSV")]
	[CompilerGenerated]
	private PropertyGrid m_VisitorContainer;

	[AccessedThroughProperty("SettingsTab")]
	[CompilerGenerated]
	private DarkUITabControl exporterContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("PropertyGridXML")]
	private PropertyGrid itemContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("MSATab")]
	private TabPage m_SetterContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("SQLiteTab")]
	private TabPage m_TemplateContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("PropertyGridMSA")]
	private PropertyGrid m_MappingContainer;

	[AccessedThroughProperty("PropertyGridSQLServer")]
	[CompilerGenerated]
	private PropertyGrid m_MockContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("PropertyGridSQLite")]
	private PropertyGrid m_TagContainer;

	[AccessedThroughProperty("Start_StopButton")]
	[CompilerGenerated]
	private DarkUIButton m_FieldContainer;

	internal virtual DarkUITabControl ControlTab
	{
		[CompilerGenerated]
		get
		{
			return configurationContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationContainer = value;
		}
	}

	internal virtual TabPage ExportSettingsTab
	{
		[CompilerGenerated]
		get
		{
			return tokenContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenContainer = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual DarkGroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("OutputDirectoryButton")]
	internal virtual DarkUIButton OutputDirectoryButton
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel OutputRootDirectory
	{
		[CompilerGenerated]
		get
		{
			return publisherContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			publisherContainer = value;
		}
	}

	internal virtual DarkCheckBox CB_ExportSIMDIS
	{
		[CompilerGenerated]
		get
		{
			return serverContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverContainer = value;
		}
	}

	internal virtual DarkCheckBox CB_ExportSQLite
	{
		[CompilerGenerated]
		get
		{
			return adapterContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			adapterContainer = value;
		}
	}

	internal virtual DarkCheckBox CB_ExportSQLServer
	{
		[CompilerGenerated]
		get
		{
			return m_SchemaContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SchemaContainer = value;
		}
	}

	[field: AccessedThroughProperty("CB_ExportCSV")]
	internal virtual DarkCheckBox CB_ExportCSV
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CB_ExportMSAccess")]
	internal virtual DarkCheckBox CB_ExportMSAccess
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkCheckBox CB_ExportTacview2x
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SingletonContainer = value;
		}
	}

	internal virtual DarkCheckBox CB_ExportXML
	{
		[CompilerGenerated]
		get
		{
			return m_RecordContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RecordContainer = value;
		}
	}

	internal virtual DarkCheckBox CB_ExportTacview1x
	{
		[CompilerGenerated]
		get
		{
			return exceptionContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exceptionContainer = value;
		}
	}

	[field: AccessedThroughProperty("CB_OutputSeparated")]
	internal virtual DarkCheckBox CB_OutputSeparated
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual PropertyGrid PropertyGridCSV
	{
		[CompilerGenerated]
		get
		{
			return m_VisitorContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_VisitorContainer = value;
		}
	}

	internal virtual DarkUITabControl SettingsTab
	{
		[CompilerGenerated]
		get
		{
			return exporterContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterContainer = value;
		}
	}

	[field: AccessedThroughProperty("CSVTab")]
	internal virtual TabPage CSVTab
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("XMLTab")]
	internal virtual TabPage XMLTab
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual PropertyGrid PropertyGridXML
	{
		[CompilerGenerated]
		get
		{
			return itemContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			itemContainer = value;
		}
	}

	internal virtual TabPage MSATab
	{
		[CompilerGenerated]
		get
		{
			return m_SetterContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SetterContainer = value;
		}
	}

	[field: AccessedThroughProperty("SQLServerTab")]
	internal virtual TabPage SQLServerTab
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TabPage TabPage_0
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TemplateContainer = value;
		}
	}

	internal virtual PropertyGrid PropertyGridMSA
	{
		[CompilerGenerated]
		get
		{
			return m_MappingContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingContainer = value;
		}
	}

	internal virtual PropertyGrid PropertyGridSQLServer
	{
		[CompilerGenerated]
		get
		{
			return m_MockContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockContainer = value;
		}
	}

	internal virtual PropertyGrid PropertyGrid_0
	{
		[CompilerGenerated]
		get
		{
			return m_TagContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TagContainer = value;
		}
	}

	internal virtual DarkUIButton Start_StopButton
	{
		[CompilerGenerated]
		get
		{
			return m_FieldContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FieldContainer = value;
		}
	}

	[field: AccessedThroughProperty("TB_OutputRootDirectoryValue")]
	internal virtual DarkUITextBox TB_OutputRootDirectoryValue
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public InterceptorProcessResolver()
	{
		VerifyIterator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_StrategyContainer != null)
			{
				m_StrategyContainer.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void VerifyIterator()
	{
		ControlTab = new DarkUITabControl();
		ExportSettingsTab = new TabPage();
		SettingsTab = new DarkUITabControl();
		CSVTab = new TabPage();
		PropertyGridCSV = new PropertyGrid();
		XMLTab = new TabPage();
		PropertyGridXML = new PropertyGrid();
		MSATab = new TabPage();
		PropertyGridMSA = new PropertyGrid();
		SQLServerTab = new TabPage();
		PropertyGridSQLServer = new PropertyGrid();
		TabPage_0 = new TabPage();
		PropertyGrid_0 = new PropertyGrid();
		GroupBox1 = new DarkGroupBox();
		TB_OutputRootDirectoryValue = new DarkUITextBox();
		Start_StopButton = new DarkUIButton();
		CB_OutputSeparated = new DarkCheckBox();
		OutputDirectoryButton = new DarkUIButton();
		OutputRootDirectory = new DarkLabel();
		CB_ExportSIMDIS = new DarkCheckBox();
		CB_ExportSQLite = new DarkCheckBox();
		CB_ExportSQLServer = new DarkCheckBox();
		CB_ExportCSV = new DarkCheckBox();
		CB_ExportMSAccess = new DarkCheckBox();
		CB_ExportTacview2x = new DarkCheckBox();
		CB_ExportXML = new DarkCheckBox();
		CB_ExportTacview1x = new DarkCheckBox();
		ControlTab.SuspendLayout();
		ExportSettingsTab.SuspendLayout();
		SettingsTab.SuspendLayout();
		CSVTab.SuspendLayout();
		XMLTab.SuspendLayout();
		MSATab.SuspendLayout();
		SQLServerTab.SuspendLayout();
		TabPage_0.SuspendLayout();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		ControlTab.Controls.Add(ExportSettingsTab);
		ControlTab.Cursor = Cursors.Hand;
		ControlTab.Dock = DockStyle.Fill;
		ControlTab.ItemSize = new Size(80, 20);
		ControlTab.Location = new Point(0, 0);
		ControlTab.Name = "ControlTab";
		ControlTab.SelectedIndex = 0;
		ControlTab.Size = new Size(631, 543);
		ControlTab.TabIndex = 0;
		ExportSettingsTab.BackColor = Color.FromArgb(60, 63, 65);
		ExportSettingsTab.Controls.Add(SettingsTab);
		ExportSettingsTab.Controls.Add(GroupBox1);
		ExportSettingsTab.Location = new Point(4, 24);
		ExportSettingsTab.Name = "ExportSettingsTab";
		ExportSettingsTab.Padding = new Padding(3);
		ExportSettingsTab.Size = new Size(623, 515);
		ExportSettingsTab.TabIndex = 0;
		ExportSettingsTab.Text = "Export Settings";
		SettingsTab.Controls.Add(CSVTab);
		SettingsTab.Controls.Add(XMLTab);
		SettingsTab.Controls.Add(MSATab);
		SettingsTab.Controls.Add(SQLServerTab);
		SettingsTab.Controls.Add(TabPage_0);
		SettingsTab.Cursor = Cursors.Hand;
		SettingsTab.ItemSize = new Size(80, 20);
		SettingsTab.Location = new Point(6, 113);
		SettingsTab.Name = "SettingsTab";
		SettingsTab.SelectedIndex = 0;
		SettingsTab.Size = new Size(611, 396);
		SettingsTab.TabIndex = 2;
		CSVTab.BackColor = Color.FromArgb(60, 63, 65);
		CSVTab.Controls.Add(PropertyGridCSV);
		CSVTab.Location = new Point(4, 24);
		CSVTab.Name = "CSVTab";
		CSVTab.Padding = new Padding(3);
		CSVTab.Size = new Size(603, 368);
		CSVTab.TabIndex = 0;
		CSVTab.Text = "CSV Settings";
		PropertyGridCSV.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridCSV.CategoryForeColor = Color.White;
		PropertyGridCSV.CommandsForeColor = Color.White;
		PropertyGridCSV.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridCSV.HelpForeColor = Color.White;
		PropertyGridCSV.LineColor = Color.FromArgb(110, 113, 115);
		PropertyGridCSV.Location = new Point(3, 3);
		PropertyGridCSV.Name = "PropertyGridCSV";
		PropertyGridCSV.PropertySort = PropertySort.Alphabetical;
		PropertyGridCSV.Size = new Size(597, 362);
		PropertyGridCSV.TabIndex = 1;
		PropertyGridCSV.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridCSV.ViewForeColor = Color.White;
		XMLTab.BackColor = Color.FromArgb(60, 63, 65);
		XMLTab.Controls.Add(PropertyGridXML);
		XMLTab.Location = new Point(4, 24);
		XMLTab.Name = "XMLTab";
		XMLTab.Padding = new Padding(3);
		XMLTab.Size = new Size(603, 368);
		XMLTab.TabIndex = 1;
		XMLTab.Text = "XML Settings";
		PropertyGridXML.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridXML.CategoryForeColor = Color.White;
		PropertyGridXML.CommandsBackColor = SystemColors.Control;
		PropertyGridXML.CommandsForeColor = Color.White;
		PropertyGridXML.Dock = DockStyle.Fill;
		PropertyGridXML.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridXML.HelpForeColor = Color.White;
		PropertyGridXML.LineColor = Color.FromArgb(110, 113, 115);
		PropertyGridXML.Location = new Point(3, 3);
		PropertyGridXML.Name = "PropertyGridXML";
		PropertyGridXML.PropertySort = PropertySort.Alphabetical;
		PropertyGridXML.Size = new Size(597, 362);
		PropertyGridXML.TabIndex = 2;
		PropertyGridXML.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridXML.ViewForeColor = Color.White;
		MSATab.BackColor = Color.FromArgb(60, 63, 65);
		MSATab.Controls.Add(PropertyGridMSA);
		MSATab.Location = new Point(4, 24);
		MSATab.Name = "MSATab";
		MSATab.Padding = new Padding(3);
		MSATab.Size = new Size(603, 368);
		MSATab.TabIndex = 2;
		MSATab.Text = "MS Access Settings";
		PropertyGridMSA.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridMSA.CategoryForeColor = Color.White;
		PropertyGridMSA.CommandsForeColor = Color.White;
		PropertyGridMSA.Dock = DockStyle.Fill;
		PropertyGridMSA.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridMSA.HelpForeColor = Color.White;
		PropertyGridMSA.LineColor = Color.FromArgb(110, 113, 115);
		PropertyGridMSA.Location = new Point(3, 3);
		PropertyGridMSA.Name = "PropertyGridMSA";
		PropertyGridMSA.PropertySort = PropertySort.Alphabetical;
		PropertyGridMSA.Size = new Size(597, 362);
		PropertyGridMSA.TabIndex = 2;
		PropertyGridMSA.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridMSA.ViewForeColor = Color.White;
		SQLServerTab.BackColor = Color.FromArgb(60, 63, 65);
		SQLServerTab.Controls.Add(PropertyGridSQLServer);
		SQLServerTab.Location = new Point(4, 24);
		SQLServerTab.Name = "SQLServerTab";
		SQLServerTab.Padding = new Padding(3);
		SQLServerTab.Size = new Size(603, 368);
		SQLServerTab.TabIndex = 2;
		SQLServerTab.Text = "SQL Server Settings";
		PropertyGridSQLServer.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGridSQLServer.CategoryForeColor = Color.White;
		PropertyGridSQLServer.CommandsForeColor = Color.White;
		PropertyGridSQLServer.Dock = DockStyle.Fill;
		PropertyGridSQLServer.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGridSQLServer.HelpForeColor = Color.White;
		PropertyGridSQLServer.LineColor = Color.FromArgb(110, 113, 115);
		PropertyGridSQLServer.Location = new Point(3, 3);
		PropertyGridSQLServer.Name = "PropertyGridSQLServer";
		PropertyGridSQLServer.PropertySort = PropertySort.Alphabetical;
		PropertyGridSQLServer.Size = new Size(597, 362);
		PropertyGridSQLServer.TabIndex = 2;
		PropertyGridSQLServer.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGridSQLServer.ViewForeColor = Color.White;
		TabPage_0.BackColor = Color.FromArgb(60, 63, 65);
		TabPage_0.Controls.Add(PropertyGrid_0);
		TabPage_0.Location = new Point(4, 24);
		TabPage_0.Name = "SQLiteTab";
		TabPage_0.Padding = new Padding(3);
		TabPage_0.Size = new Size(603, 368);
		TabPage_0.TabIndex = 2;
		TabPage_0.Text = "SQLite Settings";
		PropertyGrid_0.BackColor = Color.FromArgb(70, 73, 75);
		PropertyGrid_0.CategoryForeColor = Color.White;
		PropertyGrid_0.CommandsForeColor = Color.White;
		PropertyGrid_0.Dock = DockStyle.Fill;
		PropertyGrid_0.HelpBackColor = Color.FromArgb(80, 83, 85);
		PropertyGrid_0.HelpForeColor = Color.White;
		PropertyGrid_0.LineColor = Color.FromArgb(110, 113, 115);
		PropertyGrid_0.Location = new Point(3, 3);
		PropertyGrid_0.Name = "PropertyGridSQLite";
		PropertyGrid_0.PropertySort = PropertySort.Alphabetical;
		PropertyGrid_0.Size = new Size(597, 362);
		PropertyGrid_0.TabIndex = 2;
		PropertyGrid_0.ViewBackColor = Color.FromArgb(60, 63, 65);
		PropertyGrid_0.ViewForeColor = Color.White;
		GroupBox1.Controls.Add(TB_OutputRootDirectoryValue);
		GroupBox1.Controls.Add(Start_StopButton);
		GroupBox1.Controls.Add(CB_OutputSeparated);
		GroupBox1.Controls.Add(OutputDirectoryButton);
		GroupBox1.Controls.Add(OutputRootDirectory);
		GroupBox1.Controls.Add(CB_ExportSIMDIS);
		GroupBox1.Controls.Add(CB_ExportSQLite);
		GroupBox1.Controls.Add(CB_ExportSQLServer);
		GroupBox1.Controls.Add(CB_ExportCSV);
		GroupBox1.Controls.Add(CB_ExportMSAccess);
		GroupBox1.Controls.Add(CB_ExportTacview2x);
		GroupBox1.Controls.Add(CB_ExportXML);
		GroupBox1.Controls.Add(CB_ExportTacview1x);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(6, 6);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(611, 101);
		GroupBox1.TabIndex = 11;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Export to:";
		TB_OutputRootDirectoryValue.AutoCompleteCustomSource = null;
		TB_OutputRootDirectoryValue.AutoCompleteMode = AutoCompleteMode.None;
		TB_OutputRootDirectoryValue.AutoCompleteSource = AutoCompleteSource.None;
		TB_OutputRootDirectoryValue.BackColor = Color.Transparent;
		TB_OutputRootDirectoryValue.ForeColor = Color.FromArgb(189, 189, 189);
		TB_OutputRootDirectoryValue.Image = null;
		TB_OutputRootDirectoryValue.Lines = null;
		TB_OutputRootDirectoryValue.Location = new Point(104, 46);
		TB_OutputRootDirectoryValue.MaxLength = 32767;
		TB_OutputRootDirectoryValue.Multiline = false;
		TB_OutputRootDirectoryValue.Name = "TB_OutputRootDirectoryValue";
		TB_OutputRootDirectoryValue.ReadOnly = false;
		TB_OutputRootDirectoryValue.ScrollBars = ScrollBars.None;
		TB_OutputRootDirectoryValue.SelectionStart = 0;
		TB_OutputRootDirectoryValue.Size = new Size(257, 24);
		TB_OutputRootDirectoryValue.TabIndex = 18;
		TB_OutputRootDirectoryValue.TextAlign = HorizontalAlignment.Left;
		TB_OutputRootDirectoryValue.UseSystemPasswordChar = false;
		TB_OutputRootDirectoryValue.WatermarkText = "";
		Start_StopButton.BackColor = Color.Transparent;
		Start_StopButton.DialogResult = DialogResult.None;
		Start_StopButton.Font = new Font("Microsoft Sans Serif", 14f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Start_StopButton.ForeColor = Color.Green;
		Start_StopButton.Location = new Point(473, 46);
		Start_StopButton.Name = "Start_StopButton";
		Start_StopButton.RoundRadius = 0;
		Start_StopButton.Size = new Size(131, 49);
		Start_StopButton.TabIndex = 17;
		Start_StopButton.Text = "开始";
		CB_OutputSeparated.AutoSize = true;
		CB_OutputSeparated.Location = new Point(9, 72);
		CB_OutputSeparated.Name = "CB_OutputSeparated";
		CB_OutputSeparated.Size = new Size(328, 17);
		CB_OutputSeparated.TabIndex = 16;
		CB_OutputSeparated.Text = "Each run is separated in a different folder (Partition output mode)";
		OutputDirectoryButton.BackColor = Color.Transparent;
		OutputDirectoryButton.DialogResult = DialogResult.None;
		OutputDirectoryButton.ForeColor = SystemColors.Control;
		OutputDirectoryButton.Location = new Point(367, 46);
		OutputDirectoryButton.Name = "OutputDirectoryButton";
		OutputDirectoryButton.RoundRadius = 0;
		OutputDirectoryButton.Size = new Size(51, 24);
		OutputDirectoryButton.TabIndex = 15;
		OutputDirectoryButton.Text = "更改";
		OutputRootDirectory.AutoSize = true;
		OutputRootDirectory.ForeColor = Color.FromArgb(220, 220, 220);
		OutputRootDirectory.Location = new Point(6, 49);
		OutputRootDirectory.Name = "OutputRootDirectory";
		OutputRootDirectory.Size = new Size(92, 13);
		OutputRootDirectory.TabIndex = 13;
		OutputRootDirectory.Text = "Output root folder:";
		CB_ExportSIMDIS.AutoSize = true;
		CB_ExportSIMDIS.Location = new Point(196, 19);
		CB_ExportSIMDIS.Name = "CB_ExportSIMDIS";
		CB_ExportSIMDIS.Size = new Size(63, 17);
		CB_ExportSIMDIS.TabIndex = 12;
		CB_ExportSIMDIS.Text = "SIMDIS";
		CB_ExportSQLite.AutoSize = true;
		CB_ExportSQLite.Location = new Point(524, 19);
		CB_ExportSQLite.Name = "CB_ExportSQLite";
		CB_ExportSQLite.Size = new Size(58, 17);
		CB_ExportSQLite.TabIndex = 11;
		CB_ExportSQLite.Text = "SQLite";
		CB_ExportSQLServer.AutoSize = true;
		CB_ExportSQLServer.Location = new Point(352, 19);
		CB_ExportSQLServer.Name = "CB_ExportSQLServer";
		CB_ExportSQLServer.Size = new Size(81, 17);
		CB_ExportSQLServer.TabIndex = 10;
		CB_ExportSQLServer.Text = "SQL Server";
		CB_ExportCSV.AutoSize = true;
		CB_ExportCSV.Location = new Point(6, 19);
		CB_ExportCSV.Name = "CB_ExportCSV";
		CB_ExportCSV.Size = new Size(47, 17);
		CB_ExportCSV.TabIndex = 5;
		CB_ExportCSV.Text = "CSV";
		CB_ExportMSAccess.AutoSize = true;
		CB_ExportMSAccess.Location = new Point(110, 19);
		CB_ExportMSAccess.Name = "CB_ExportMSAccess";
		CB_ExportMSAccess.Size = new Size(80, 17);
		CB_ExportMSAccess.TabIndex = 7;
		CB_ExportMSAccess.Text = "MS Access";
		CB_ExportTacview2x.AutoSize = true;
		CB_ExportTacview2x.Location = new Point(437, 19);
		CB_ExportTacview2x.Name = "CB_ExportTacview2x";
		CB_ExportTacview2x.Size = new Size(84, 17);
		CB_ExportTacview2x.TabIndex = 8;
		CB_ExportTacview2x.Text = "Tacview 2.x";
		CB_ExportXML.AutoSize = true;
		CB_ExportXML.Location = new Point(59, 19);
		CB_ExportXML.Name = "CB_ExportXML";
		CB_ExportXML.Size = new Size(48, 17);
		CB_ExportXML.TabIndex = 4;
		CB_ExportXML.Text = "XML";
		CB_ExportTacview1x.AutoSize = true;
		CB_ExportTacview1x.Location = new Point(262, 19);
		CB_ExportTacview1x.Name = "CB_ExportTacview1x";
		CB_ExportTacview1x.Size = new Size(84, 17);
		CB_ExportTacview1x.TabIndex = 6;
		CB_ExportTacview1x.Text = "Tacview 1.x";
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(631, 543);
		base.Controls.Add(ControlTab);
		MaximumSize = new Size(647, 582);
		MinimumSize = new Size(647, 582);
		base.Name = "InteractiveAnalysisForm";
		base.ShowIcon = false;
		Text = "Interactive Analysis";
		ControlTab.ResumeLayout(performLayout: false);
		ExportSettingsTab.ResumeLayout(performLayout: false);
		SettingsTab.ResumeLayout(performLayout: false);
		CSVTab.ResumeLayout(performLayout: false);
		XMLTab.ResumeLayout(performLayout: false);
		MSATab.ResumeLayout(performLayout: false);
		SQLServerTab.ResumeLayout(performLayout: false);
		TabPage_0.ResumeLayout(performLayout: false);
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
