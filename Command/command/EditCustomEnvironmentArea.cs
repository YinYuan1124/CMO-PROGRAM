using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditCustomEnvironmentArea : DarkSecondaryFormBase
{
	private IContainer statusReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage1")]
	private TabPage m_IndexerReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox3")]
	private DarkGroupBox resolverReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel4")]
	private DarkLabel m_PublisherReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel2")]
	private DarkLabel serverReponse;

	[AccessedThroughProperty("txtCZInterval")]
	[CompilerGenerated]
	private DarkUITextBox _AdapterReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("cmbTerrainType")]
	private DarkUIComboBox _SchemaReponse;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel predicateReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("lblName")]
	private DarkLabel m_SingletonReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_FUR")]
	private TrackBar m_AttrReponse;

	[AccessedThroughProperty("TrackBar_Rainfall")]
	[CompilerGenerated]
	private TrackBar visitorReponse;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel exporterReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Label6")]
	private DarkLabel m_ComparatorReponse;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel m_ItemReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_AverageTemp")]
	private TrackBar setterReponse;

	[AccessedThroughProperty("Label_AverageTemp")]
	[CompilerGenerated]
	private DarkLabel m_CreatorReponse;

	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private DarkLabel templateReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar_SeaState")]
	private TrackBar mappingReponse;

	[AccessedThroughProperty("Label10")]
	[CompilerGenerated]
	private DarkLabel m_MockReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Label9")]
	private DarkLabel tagReponse;

	[AccessedThroughProperty("ColorDialog1")]
	[CompilerGenerated]
	private ColorDialog m_FieldReponse;

	[AccessedThroughProperty("lblAreaName")]
	[CompilerGenerated]
	private DarkLabel m_QueueReponse;

	[AccessedThroughProperty("DarkLabel7")]
	[CompilerGenerated]
	private DarkLabel regReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("txtTerrainHeight")]
	private DarkUITextBox paramReponse;

	[AccessedThroughProperty("ChkCustomTerrainHeight")]
	[CompilerGenerated]
	private DarkUICheckBox _PageReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("lblWarning")]
	private DarkLabel m_RulesReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkGroupBox2")]
	private DarkGroupBox m_MethodReponse;

	[AccessedThroughProperty("txtThermalLayerCeiling")]
	[CompilerGenerated]
	private DarkUITextBox candidateReponse;

	[AccessedThroughProperty("DarkLabel1")]
	[CompilerGenerated]
	private DarkLabel m_BaseReponse;

	[AccessedThroughProperty("txtThermalLayerFloor")]
	[CompilerGenerated]
	private DarkUITextBox _PolicyReponse;

	[AccessedThroughProperty("txtLayerStrenght")]
	[CompilerGenerated]
	private DarkUITextBox _IdentifierReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkLabel3")]
	private DarkLabel printerReponse;

	private CustomEnvironmentZone _ParserReponse;

	private bool algoReponse;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal DarkToolStrip ToolStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal ToolStripLabel ToolStripLabel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TSDD_WeatherLevel")]
	internal ToolStripDropDownButton TSDD_WeatherLevel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TC_WeatherLevel")]
	internal DarkUITabControl TC_WeatherLevel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_IndexerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_IndexerReponse = value;
		}
	}

	internal DarkGroupBox DarkGroupBox3
	{
		[CompilerGenerated]
		get
		{
			return resolverReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			resolverReponse = value;
		}
	}

	internal DarkLabel DarkLabel4
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PublisherReponse = value;
		}
	}

	internal DarkLabel DarkLabel2
	{
		[CompilerGenerated]
		get
		{
			return serverReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serverReponse = value;
		}
	}

	internal DarkUITextBox txtCZInterval
	{
		[CompilerGenerated]
		get
		{
			return _AdapterReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = ManageTag;
			DarkUITextBox adapterReponse = _AdapterReponse;
			if (adapterReponse != null)
			{
				adapterReponse.TextChanged -= value2;
			}
			_AdapterReponse = value;
			adapterReponse = _AdapterReponse;
			if (adapterReponse != null)
			{
				adapterReponse.TextChanged += value2;
			}
		}
	}

	internal DarkUIComboBox cmbTerrainType
	{
		[CompilerGenerated]
		get
		{
			return _SchemaReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushTag;
			DarkUIComboBox schemaReponse = _SchemaReponse;
			if (schemaReponse != null)
			{
				schemaReponse.SelectedIndexChanged -= value2;
			}
			_SchemaReponse = value;
			schemaReponse = _SchemaReponse;
			if (schemaReponse != null)
			{
				schemaReponse.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal DarkGroupBox DarkGroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return predicateReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			predicateReponse = value;
		}
	}

	internal DarkLabel lblName
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SingletonReponse = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TrackBar TrackBar_FUR
	{
		[CompilerGenerated]
		get
		{
			return m_AttrReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetTag;
			TrackBar attrReponse = m_AttrReponse;
			if (attrReponse != null)
			{
				attrReponse.Scroll -= value2;
			}
			m_AttrReponse = value;
			attrReponse = m_AttrReponse;
			if (attrReponse != null)
			{
				attrReponse.Scroll += value2;
			}
		}
	}

	internal TrackBar TrackBar_Rainfall
	{
		[CompilerGenerated]
		get
		{
			return visitorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QueryTag;
			TrackBar trackBar = visitorReponse;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
			}
			visitorReponse = value;
			trackBar = visitorReponse;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return exporterReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exporterReponse = value;
		}
	}

	[field: AccessedThroughProperty("Label5")]
	internal DarkLabel Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return m_ComparatorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComparatorReponse = value;
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return m_ItemReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ItemReponse = value;
		}
	}

	internal TrackBar TrackBar_AverageTemp
	{
		[CompilerGenerated]
		get
		{
			return setterReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeTag;
			TrackBar trackBar = setterReponse;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
			}
			setterReponse = value;
			trackBar = setterReponse;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
			}
		}
	}

	internal DarkLabel Label_AverageTemp
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorReponse = value;
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return templateReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			templateReponse = value;
		}
	}

	internal TrackBar TrackBar_SeaState
	{
		[CompilerGenerated]
		get
		{
			return mappingReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapTag;
			TrackBar trackBar = mappingReponse;
			if (trackBar != null)
			{
				trackBar.Scroll -= value2;
			}
			mappingReponse = value;
			trackBar = mappingReponse;
			if (trackBar != null)
			{
				trackBar.Scroll += value2;
			}
		}
	}

	internal DarkLabel Label10
	{
		[CompilerGenerated]
		get
		{
			return m_MockReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MockReponse = value;
		}
	}

	internal DarkLabel Label9
	{
		[CompilerGenerated]
		get
		{
			return tagReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tagReponse = value;
		}
	}

	internal DarkLabel lblAreaName
	{
		[CompilerGenerated]
		get
		{
			return m_QueueReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_QueueReponse = value;
		}
	}

	internal DarkLabel DarkLabel7
	{
		[CompilerGenerated]
		get
		{
			return regReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regReponse = value;
		}
	}

	internal DarkUITextBox txtTerrainHeight
	{
		[CompilerGenerated]
		get
		{
			return paramReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = CountField;
			DarkUITextBox darkUITextBox = paramReponse;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			paramReponse = value;
			darkUITextBox = paramReponse;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal DarkUICheckBox ChkCustomTerrainHeight
	{
		[CompilerGenerated]
		get
		{
			return _PageReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUICheckBox.CheckedChangedEventHandler value2 = CloneField;
			DarkUICheckBox pageReponse = _PageReponse;
			if (pageReponse != null)
			{
				pageReponse.CheckedChanged -= value2;
			}
			_PageReponse = value;
			pageReponse = _PageReponse;
			if (pageReponse != null)
			{
				pageReponse.CheckedChanged += value2;
			}
		}
	}

	internal DarkLabel lblWarning
	{
		[CompilerGenerated]
		get
		{
			return m_RulesReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RulesReponse = value;
		}
	}

	internal DarkGroupBox DarkGroupBox2
	{
		[CompilerGenerated]
		get
		{
			return m_MethodReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodReponse = value;
		}
	}

	[field: AccessedThroughProperty("lblElevation")]
	internal DarkLabel lblElevation
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkLabel5")]
	internal DarkLabel DarkLabel5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox txtThermalLayerCeiling
	{
		[CompilerGenerated]
		get
		{
			return candidateReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = CollectTag;
			DarkUITextBox darkUITextBox = candidateReponse;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			candidateReponse = value;
			darkUITextBox = candidateReponse;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal DarkLabel DarkLabel1
	{
		[CompilerGenerated]
		get
		{
			return m_BaseReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_BaseReponse = value;
		}
	}

	internal DarkUITextBox txtThermalLayerFloor
	{
		[CompilerGenerated]
		get
		{
			return _PolicyReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = OrderTag;
			DarkUITextBox policyReponse = _PolicyReponse;
			if (policyReponse != null)
			{
				policyReponse.TextChanged -= value2;
			}
			_PolicyReponse = value;
			policyReponse = _PolicyReponse;
			if (policyReponse != null)
			{
				policyReponse.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("LblElevText")]
	internal DarkLabel LblElevText
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUITextBox txtLayerStrenght
	{
		[CompilerGenerated]
		get
		{
			return _IdentifierReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = RegisterTag;
			DarkUITextBox identifierReponse = _IdentifierReponse;
			if (identifierReponse != null)
			{
				identifierReponse.TextChanged -= value2;
			}
			_IdentifierReponse = value;
			identifierReponse = _IdentifierReponse;
			if (identifierReponse != null)
			{
				identifierReponse.TextChanged += value2;
			}
		}
	}

	internal DarkLabel DarkLabel3
	{
		[CompilerGenerated]
		get
		{
			return printerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerReponse = value;
		}
	}

	public bool IsLoaded { get; set; }

	[SpecialName]
	[CompilerGenerated]
	internal ColorDialog AssetField()
	{
		return m_FieldReponse;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void PrintField(ColorDialog colorDialog_0)
	{
		m_FieldReponse = colorDialog_0;
	}

	public EditCustomEnvironmentArea()
	{
		base.Load += StartTag;
		base.KeyDown += SortTag;
		base.FormClosing += CalcTag;
		IsLoaded = false;
		RunTag();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && statusReponse != null)
			{
				statusReponse.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RunTag()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(EditCustomEnvironmentArea));
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSDD_WeatherLevel = new ToolStripDropDownButton();
		TC_WeatherLevel = new DarkUITabControl();
		TabPage1 = new TabPage();
		lblAreaName = new DarkLabel();
		DarkGroupBox3 = new DarkGroupBox();
		ChkCustomTerrainHeight = new DarkUICheckBox();
		DarkLabel7 = new DarkLabel();
		txtTerrainHeight = new DarkUITextBox();
		DarkLabel4 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		txtCZInterval = new DarkUITextBox();
		cmbTerrainType = new DarkUIComboBox();
		DarkGroupBox1 = new DarkGroupBox();
		Label3 = new DarkLabel();
		lblName = new DarkLabel();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		TrackBar_FUR = new TrackBar();
		TrackBar_Rainfall = new TrackBar();
		Label4 = new DarkLabel();
		Label5 = new DarkLabel();
		Label6 = new DarkLabel();
		Label7 = new DarkLabel();
		TrackBar_AverageTemp = new TrackBar();
		Label_AverageTemp = new DarkLabel();
		Label8 = new DarkLabel();
		TrackBar_SeaState = new TrackBar();
		Label10 = new DarkLabel();
		Label9 = new DarkLabel();
		PrintField(new ColorDialog());
		DarkGroupBox2 = new DarkGroupBox();
		lblElevation = new DarkLabel();
		DarkLabel5 = new DarkLabel();
		txtThermalLayerCeiling = new DarkUITextBox();
		DarkLabel1 = new DarkLabel();
		txtThermalLayerFloor = new DarkUITextBox();
		LblElevText = new DarkLabel();
		txtLayerStrenght = new DarkUITextBox();
		DarkLabel3 = new DarkLabel();
		lblWarning = new DarkLabel();
		ToolStrip1.SuspendLayout();
		TC_WeatherLevel.SuspendLayout();
		TabPage1.SuspendLayout();
		DarkGroupBox3.SuspendLayout();
		DarkGroupBox1.SuspendLayout();
		((ISupportInitialize)TrackBar_FUR).BeginInit();
		((ISupportInitialize)TrackBar_Rainfall).BeginInit();
		((ISupportInitialize)TrackBar_AverageTemp).BeginInit();
		((ISupportInitialize)TrackBar_SeaState).BeginInit();
		DarkGroupBox2.SuspendLayout();
		SuspendLayout();
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.Items.AddRange(new ToolStripItem[2] { ToolStripLabel1, TSDD_WeatherLevel });
		ToolStrip1.Location = new Point(0, 0);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.Size = new Size(609, 25);
		ToolStrip1.TabIndex = 0;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(138, 22);
		ToolStripLabel1.Text = "天气建模水平：";
		TSDD_WeatherLevel.BackColor = Color.FromArgb(60, 63, 65);
		TSDD_WeatherLevel.DisplayStyle = ToolStripItemDisplayStyle.Text;
		TSDD_WeatherLevel.ForeColor = Color.FromArgb(220, 220, 220);
		TSDD_WeatherLevel.Image = componentResourceManager.GetObject("TSDD_WeatherLevel.Image");
		TSDD_WeatherLevel.ImageTransparentColor = Color.Magenta;
		TSDD_WeatherLevel.Name = "TSDD_WeatherLevel";
		TSDD_WeatherLevel.Size = new Size(56, 22);
		TSDD_WeatherLevel.Text = "0级";
		TC_WeatherLevel.Controls.Add(TabPage1);
		TC_WeatherLevel.Cursor = Cursors.Hand;
		TC_WeatherLevel.Dock = DockStyle.Fill;
		TC_WeatherLevel.ItemSize = new Size(80, 20);
		TC_WeatherLevel.Location = new Point(0, 25);
		TC_WeatherLevel.Multiline = true;
		TC_WeatherLevel.Name = "TC_WeatherLevel";
		TC_WeatherLevel.SelectedIndex = 0;
		TC_WeatherLevel.Size = new Size(609, 416);
		TC_WeatherLevel.TabIndex = 19;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(lblAreaName);
		TabPage1.Controls.Add(DarkGroupBox3);
		TabPage1.Controls.Add(DarkGroupBox1);
		TabPage1.Controls.Add(Label3);
		TabPage1.Controls.Add(lblName);
		TabPage1.Controls.Add(Label1);
		TabPage1.Controls.Add(Label2);
		TabPage1.Controls.Add(TrackBar_FUR);
		TabPage1.Controls.Add(TrackBar_Rainfall);
		TabPage1.Controls.Add(Label4);
		TabPage1.Controls.Add(Label5);
		TabPage1.Controls.Add(Label6);
		TabPage1.Controls.Add(Label7);
		TabPage1.Controls.Add(TrackBar_AverageTemp);
		TabPage1.Controls.Add(Label_AverageTemp);
		TabPage1.Controls.Add(Label8);
		TabPage1.Controls.Add(TrackBar_SeaState);
		TabPage1.Controls.Add(Label10);
		TabPage1.Controls.Add(Label9);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(601, 388);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "0级";
		lblAreaName.AutoSize = true;
		lblAreaName.ForeColor = Color.FromArgb(220, 220, 220);
		lblAreaName.Location = new Point(179, 20);
		lblAreaName.Name = "lblAreaName";
		lblAreaName.Size = new Size(0, 15);
		lblAreaName.TabIndex = 60;
		DarkGroupBox3.Controls.Add(ChkCustomTerrainHeight);
		DarkGroupBox3.Controls.Add(DarkLabel7);
		DarkGroupBox3.Controls.Add(txtTerrainHeight);
		DarkGroupBox3.Controls.Add(DarkLabel4);
		DarkGroupBox3.Controls.Add(cmbTerrainType);
		DarkGroupBox3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox3.Location = new Point(305, 181);
		DarkGroupBox3.Name = "DarkGroupBox3";
		DarkGroupBox3.Size = new Size(285, 201);
		DarkGroupBox3.TabIndex = 59;
		DarkGroupBox3.TabStop = false;
		DarkGroupBox3.Text = "地貌";
		ChkCustomTerrainHeight.BackColor = Color.Transparent;
		ChkCustomTerrainHeight.Checked = false;
		ChkCustomTerrainHeight.Cursor = Cursors.Hand;
		ChkCustomTerrainHeight.ForeColor = Color.FromArgb(209, 209, 209);
		ChkCustomTerrainHeight.Location = new Point(17, 50);
		ChkCustomTerrainHeight.Name = "ChkCustomTerrainHeight";
		ChkCustomTerrainHeight.Size = new Size(129, 18);
		ChkCustomTerrainHeight.TabIndex = 36;
		ChkCustomTerrainHeight.Text = "Set Custom Height:";
		DarkLabel7.AutoSize = true;
		DarkLabel7.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel7.Location = new Point(204, 53);
		DarkLabel7.Name = "DarkLabel7";
		DarkLabel7.Size = new Size(43, 15);
		DarkLabel7.TabIndex = 35;
		DarkLabel7.Text = "meters";
		txtTerrainHeight.AutoCompleteCustomSource = null;
		txtTerrainHeight.AutoCompleteMode = AutoCompleteMode.None;
		txtTerrainHeight.AutoCompleteSource = AutoCompleteSource.None;
		txtTerrainHeight.BackColor = Color.Transparent;
		txtTerrainHeight.ForeColor = Color.FromArgb(189, 189, 189);
		txtTerrainHeight.Image = null;
		txtTerrainHeight.Lines = null;
		txtTerrainHeight.Location = new Point(159, 48);
		txtTerrainHeight.MaxLength = 6;
		txtTerrainHeight.Multiline = false;
		txtTerrainHeight.Name = "txtTerrainHeight";
		txtTerrainHeight.ReadOnly = false;
		txtTerrainHeight.ScrollBars = ScrollBars.None;
		txtTerrainHeight.SelectionStart = 0;
		txtTerrainHeight.Size = new Size(39, 24);
		txtTerrainHeight.TabIndex = 34;
		txtTerrainHeight.TextAlign = HorizontalAlignment.Left;
		txtTerrainHeight.UseSystemPasswordChar = false;
		txtTerrainHeight.WatermarkText = "";
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(14, 21);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(65, 15);
		DarkLabel4.TabIndex = 32;
		DarkLabel4.Text = "Cover Type";
		DarkLabel2.AutoSize = true;
		DarkLabel2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel2.Location = new Point(2, 167);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(64, 15);
		DarkLabel2.TabIndex = 28;
		DarkLabel2.Text = "汇聚区间距";
		txtCZInterval.AutoCompleteCustomSource = null;
		txtCZInterval.AutoCompleteMode = AutoCompleteMode.None;
		txtCZInterval.AutoCompleteSource = AutoCompleteSource.None;
		txtCZInterval.BackColor = Color.Transparent;
		txtCZInterval.ForeColor = Color.FromArgb(189, 189, 189);
		txtCZInterval.Image = null;
		txtCZInterval.Lines = null;
		txtCZInterval.Location = new Point(70, 162);
		txtCZInterval.MaxLength = 32767;
		txtCZInterval.Multiline = false;
		txtCZInterval.Name = "txtCZInterval";
		txtCZInterval.ReadOnly = false;
		txtCZInterval.ScrollBars = ScrollBars.None;
		txtCZInterval.SelectionStart = 0;
		txtCZInterval.Size = new Size(174, 24);
		txtCZInterval.TabIndex = 29;
		txtCZInterval.TextAlign = HorizontalAlignment.Left;
		txtCZInterval.UseSystemPasswordChar = false;
		txtCZInterval.WatermarkText = "";
		cmbTerrainType.BackColor = Color.Transparent;
		cmbTerrainType.DrawMode = DrawMode.OwnerDrawFixed;
		cmbTerrainType.DropDownStyle = ComboBoxStyle.DropDownList;
		cmbTerrainType.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		cmbTerrainType.FormattingEnabled = true;
		cmbTerrainType.Location = new Point(85, 18);
		cmbTerrainType.Name = "cmbTerrainType";
		cmbTerrainType.Size = new Size(174, 21);
		cmbTerrainType.TabIndex = 31;
		DarkGroupBox1.Controls.Add(lblWarning);
		DarkGroupBox1.Controls.Add(DarkGroupBox2);
		DarkGroupBox1.Controls.Add(DarkLabel2);
		DarkGroupBox1.Controls.Add(txtCZInterval);
		DarkGroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox1.Location = new Point(3, 181);
		DarkGroupBox1.Name = "DarkGroupBox1";
		DarkGroupBox1.Size = new Size(296, 201);
		DarkGroupBox1.TabIndex = 57;
		DarkGroupBox1.TabStop = false;
		DarkGroupBox1.Text = "Sonar Conditions";
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(4, 112);
		Label3.Name = "Label3";
		Label3.Size = new Size(80, 21);
		Label3.TabIndex = 40;
		Label3.Text = "天气：";
		lblName.AutoSize = true;
		lblName.Font = new Font("Segoe UI", 14f);
		lblName.ForeColor = Color.FromArgb(220, 220, 220);
		lblName.Location = new Point(3, 12);
		lblName.Name = "lblName";
		lblName.Size = new Size(106, 25);
		lblName.TabIndex = 56;
		lblName.Text = "区域名称";
		Label1.AutoSize = true;
		Label1.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(4, 50);
		Label1.Name = "Label1";
		Label1.Size = new Size(160, 21);
		Label1.TabIndex = 38;
		Label1.Text = "平均温度：";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(4, 81);
		Label2.Name = "Label2";
		Label2.Size = new Size(96, 21);
		Label2.TabIndex = 39;
		Label2.Text = "雨量：";
		TrackBar_FUR.AutoSize = false;
		TrackBar_FUR.LargeChange = 10;
		TrackBar_FUR.Location = new Point(173, 115);
		TrackBar_FUR.Name = "TrackBar_FUR";
		TrackBar_FUR.Size = new Size(239, 31);
		TrackBar_FUR.TabIndex = 41;
		TrackBar_Rainfall.AutoSize = false;
		TrackBar_Rainfall.LargeChange = 10;
		TrackBar_Rainfall.Location = new Point(173, 81);
		TrackBar_Rainfall.Maximum = 50;
		TrackBar_Rainfall.Name = "TrackBar_Rainfall";
		TrackBar_Rainfall.Size = new Size(239, 31);
		TrackBar_Rainfall.SmallChange = 5;
		TrackBar_Rainfall.TabIndex = 42;
		Label4.AutoSize = true;
		Label4.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(116, 86);
		Label4.Name = "Label4";
		Label4.Size = new Size(46, 13);
		Label4.TabIndex = 43;
		Label4.Text = "无雨";
		Label5.AutoSize = true;
		Label5.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(436, 87);
		Label5.Name = "Label5";
		Label5.Size = new Size(72, 13);
		Label5.TabIndex = 44;
		Label5.Text = "特大暴雨";
		Label6.AutoSize = true;
		Label6.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(127, 117);
		Label6.Name = "Label6";
		Label6.Size = new Size(33, 13);
		Label6.TabIndex = 45;
		Label6.Text = "清空";
		Label7.AutoSize = true;
		Label7.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(436, 118);
		Label7.Name = "Label7";
		Label7.Size = new Size(117, 13);
		Label7.TabIndex = 46;
		Label7.Text = "浓密云层";
		TrackBar_AverageTemp.AutoSize = false;
		TrackBar_AverageTemp.LargeChange = 10;
		TrackBar_AverageTemp.Location = new Point(173, 50);
		TrackBar_AverageTemp.Maximum = 50;
		TrackBar_AverageTemp.Minimum = -50;
		TrackBar_AverageTemp.Name = "TrackBar_AverageTemp";
		TrackBar_AverageTemp.Size = new Size(239, 31);
		TrackBar_AverageTemp.SmallChange = 5;
		TrackBar_AverageTemp.TabIndex = 47;
		Label_AverageTemp.AutoSize = true;
		Label_AverageTemp.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label_AverageTemp.ForeColor = Color.FromArgb(220, 220, 220);
		Label_AverageTemp.Location = new Point(436, 56);
		Label_AverageTemp.Name = "Label_AverageTemp";
		Label_AverageTemp.Size = new Size(21, 13);
		Label_AverageTemp.TabIndex = 48;
		Label_AverageTemp.Text = "°C";
		Label8.AutoSize = true;
		Label8.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(3, 144);
		Label8.Name = "Label8";
		Label8.Size = new Size(126, 21);
		Label8.TabIndex = 49;
		Label8.Text = "风力/海况：";
		TrackBar_SeaState.AutoSize = false;
		TrackBar_SeaState.LargeChange = 10;
		TrackBar_SeaState.Location = new Point(173, 144);
		TrackBar_SeaState.Maximum = 9;
		TrackBar_SeaState.Name = "TrackBar_SeaState";
		TrackBar_SeaState.Size = new Size(239, 31);
		TrackBar_SeaState.TabIndex = 50;
		Label10.AutoSize = true;
		Label10.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(126, 149);
		Label10.Name = "Label10";
		Label10.Size = new Size(33, 13);
		Label10.TabIndex = 51;
		Label10.Text = "无风";
		Label9.AutoSize = true;
		Label9.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(436, 149);
		Label9.Name = "Label9";
		Label9.Size = new Size(57, 13);
		Label9.TabIndex = 52;
		Label9.Text = "飓风";
		DarkGroupBox2.Controls.Add(lblElevation);
		DarkGroupBox2.Controls.Add(DarkLabel5);
		DarkGroupBox2.Controls.Add(txtThermalLayerCeiling);
		DarkGroupBox2.Controls.Add(DarkLabel1);
		DarkGroupBox2.Controls.Add(txtThermalLayerFloor);
		DarkGroupBox2.Controls.Add(LblElevText);
		DarkGroupBox2.Controls.Add(txtLayerStrenght);
		DarkGroupBox2.Controls.Add(DarkLabel3);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(8, 35);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(282, 121);
		DarkGroupBox2.TabIndex = 39;
		DarkGroupBox2.TabStop = false;
		DarkGroupBox2.Text = "温跃层";
		lblElevation.AutoSize = true;
		lblElevation.ForeColor = Color.FromArgb(220, 220, 220);
		lblElevation.Location = new Point(134, 57);
		lblElevation.Name = "lblElevation";
		lblElevation.Size = new Size(59, 15);
		lblElevation.TabIndex = 45;
		lblElevation.Text = "最小值";
		DarkLabel5.AutoSize = true;
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(24, 54);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(34, 15);
		DarkLabel5.TabIndex = 43;
		DarkLabel5.Text = "下限";
		txtThermalLayerCeiling.AutoCompleteCustomSource = null;
		txtThermalLayerCeiling.AutoCompleteMode = AutoCompleteMode.None;
		txtThermalLayerCeiling.AutoCompleteSource = AutoCompleteSource.None;
		txtThermalLayerCeiling.BackColor = Color.Transparent;
		txtThermalLayerCeiling.ForeColor = Color.FromArgb(189, 189, 189);
		txtThermalLayerCeiling.Image = null;
		txtThermalLayerCeiling.Lines = null;
		txtThermalLayerCeiling.Location = new Point(62, 24);
		txtThermalLayerCeiling.MaxLength = 32767;
		txtThermalLayerCeiling.Multiline = false;
		txtThermalLayerCeiling.Name = "txtThermalLayerCeiling";
		txtThermalLayerCeiling.ReadOnly = false;
		txtThermalLayerCeiling.ScrollBars = ScrollBars.None;
		txtThermalLayerCeiling.SelectionStart = 0;
		txtThermalLayerCeiling.Size = new Size(66, 24);
		txtThermalLayerCeiling.TabIndex = 39;
		txtThermalLayerCeiling.TextAlign = HorizontalAlignment.Left;
		txtThermalLayerCeiling.UseSystemPasswordChar = false;
		txtThermalLayerCeiling.WatermarkText = "";
		DarkLabel1.AutoSize = true;
		DarkLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel1.Location = new Point(14, 25);
		DarkLabel1.Name = "DarkLabel1";
		DarkLabel1.Size = new Size(44, 15);
		DarkLabel1.TabIndex = 41;
		DarkLabel1.Text = "上限";
		txtThermalLayerFloor.AutoCompleteCustomSource = null;
		txtThermalLayerFloor.AutoCompleteMode = AutoCompleteMode.None;
		txtThermalLayerFloor.AutoCompleteSource = AutoCompleteSource.None;
		txtThermalLayerFloor.BackColor = Color.Transparent;
		txtThermalLayerFloor.ForeColor = Color.FromArgb(189, 189, 189);
		txtThermalLayerFloor.Image = null;
		txtThermalLayerFloor.Lines = null;
		txtThermalLayerFloor.Location = new Point(62, 53);
		txtThermalLayerFloor.MaxLength = 32767;
		txtThermalLayerFloor.Multiline = false;
		txtThermalLayerFloor.Name = "txtThermalLayerFloor";
		txtThermalLayerFloor.ReadOnly = false;
		txtThermalLayerFloor.ScrollBars = ScrollBars.None;
		txtThermalLayerFloor.SelectionStart = 0;
		txtThermalLayerFloor.Size = new Size(66, 24);
		txtThermalLayerFloor.TabIndex = 44;
		txtThermalLayerFloor.TextAlign = HorizontalAlignment.Left;
		txtThermalLayerFloor.UseSystemPasswordChar = false;
		txtThermalLayerFloor.WatermarkText = "";
		LblElevText.AutoSize = true;
		LblElevText.ForeColor = Color.FromArgb(220, 220, 220);
		LblElevText.Location = new Point(199, 57);
		LblElevText.Name = "LblElevText";
		LblElevText.Size = new Size(79, 15);
		LblElevText.TabIndex = 46;
		LblElevText.Text = "高度文字";
		txtLayerStrenght.AutoCompleteCustomSource = null;
		txtLayerStrenght.AutoCompleteMode = AutoCompleteMode.None;
		txtLayerStrenght.AutoCompleteSource = AutoCompleteSource.None;
		txtLayerStrenght.BackColor = Color.Transparent;
		txtLayerStrenght.ForeColor = Color.FromArgb(189, 189, 189);
		txtLayerStrenght.Image = null;
		txtLayerStrenght.Lines = null;
		txtLayerStrenght.Location = new Point(61, 83);
		txtLayerStrenght.MaxLength = 32767;
		txtLayerStrenght.Multiline = false;
		txtLayerStrenght.Name = "txtLayerStrenght";
		txtLayerStrenght.ReadOnly = false;
		txtLayerStrenght.ScrollBars = ScrollBars.None;
		txtLayerStrenght.SelectionStart = 0;
		txtLayerStrenght.Size = new Size(67, 24);
		txtLayerStrenght.TabIndex = 40;
		txtLayerStrenght.TextAlign = HorizontalAlignment.Left;
		txtLayerStrenght.UseSystemPasswordChar = false;
		txtLayerStrenght.WatermarkText = "";
		DarkLabel3.AutoSize = true;
		DarkLabel3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel3.Location = new Point(6, 86);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(52, 15);
		DarkLabel3.TabIndex = 42;
		DarkLabel3.Text = "强度";
		lblWarning.AutoSize = true;
		lblWarning.ForeColor = Color.Red;
		lblWarning.Location = new Point(49, 18);
		lblWarning.Name = "lblWarning";
		lblWarning.Size = new Size(199, 15);
		lblWarning.TabIndex = 48;
		lblWarning.Text = "注意：存在陆上参考点";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(609, 441);
		base.Controls.Add(TC_WeatherLevel);
		base.Controls.Add(ToolStrip1);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		MaximumSize = new Size(625, 480);
		base.MinimizeBox = false;
		MinimumSize = new Size(625, 480);
		base.Name = "EditCustomEnvironmentArea";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "自定义环境区域编辑";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		TC_WeatherLevel.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		DarkGroupBox3.ResumeLayout(performLayout: false);
		DarkGroupBox3.PerformLayout();
		DarkGroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox1.PerformLayout();
		((ISupportInitialize)TrackBar_FUR).EndInit();
		((ISupportInitialize)TrackBar_Rainfall).EndInit();
		((ISupportInitialize)TrackBar_AverageTemp).EndInit();
		((ISupportInitialize)TrackBar_SeaState).EndInit();
		DarkGroupBox2.ResumeLayout(performLayout: false);
		DarkGroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void StartTag(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		AssetTag();
	}

	private void AssetTag()
	{
		IsLoaded = false;
		RateTag();
		DefineTag(Client.CurrentScenario);
		IsLoaded = true;
	}

	private void PrintTag()
	{
		if (_ParserReponse.HasCustomTerrainHeight)
		{
			ChkCustomTerrainHeight.Checked = true;
			txtTerrainHeight.Enabled = true;
		}
		else
		{
			ChkCustomTerrainHeight.Checked = false;
			txtTerrainHeight.Enabled = false;
		}
	}

	private void DefineTag(Scenario scenario_0)
	{
		lblAreaName.Text = _ParserReponse.Description;
		TrackBar_AverageTemp.Value = (int)Math.Round(_ParserReponse.Weather.AverageTemp);
		Label_AverageTemp.Text = Conversions.ToString(_ParserReponse.Weather.AverageTemp) + " °C";
		TrackBar_Rainfall.Value = (int)Math.Round(_ParserReponse.Weather.RainfallRate);
		TrackBar_FUR.Value = (int)Math.Round(_ParserReponse.Weather.FractionUnderRain * 10f);
		TrackBar_SeaState.Value = _ParserReponse.Weather.SeaState;
		txtCZInterval.Text = _ParserReponse.Single_0.ToString();
		txtLayerStrenght.Text = _ParserReponse.LayerStrength.ToString();
		txtThermalLayerCeiling.Text = _ParserReponse.ThermalLayerCeiling.ToString();
		txtThermalLayerFloor.Text = _ParserReponse.ThermalLayerFloor.ToString();
		cmbTerrainType.SelectedItem = _ParserReponse.TerrainType;
		PrintTag();
		txtTerrainHeight.Text = _ParserReponse.TerrainHeight.ToString();
		PublishTag(scenario_0);
	}

	private void PublishTag(Scenario scenario_0)
	{
		int num = int.MaxValue;
		foreach (ReferencePoint item in _ParserReponse.Area)
		{
			short elevation = Terrain.GetElevation(item.Latitude, item.Longitude, bool_0: false, scenario_0);
			if (num > elevation)
			{
				num = elevation;
			}
		}
		if (num <= 0)
		{
			lblWarning.Visible = false;
		}
		else
		{
			lblWarning.Visible = true;
		}
		LblElevText.Text = num.ToString();
	}

	private void AwakeTag(object sender, EventArgs e)
	{
		_ParserReponse.Weather.AverageTemp = TrackBar_AverageTemp.Value;
		Label_AverageTemp.Text = Conversions.ToString(_ParserReponse.Weather.AverageTemp) + " °C";
	}

	private void QueryTag(object sender, EventArgs e)
	{
		_ParserReponse.Weather.RainfallRate = TrackBar_Rainfall.Value;
	}

	private void ResetTag(object sender, EventArgs e)
	{
		_ParserReponse.Weather.FractionUnderRain = (float)((double)TrackBar_FUR.Value * 0.1);
	}

	private void MapTag(object sender, EventArgs e)
	{
		_ParserReponse.Weather.SeaState = TrackBar_SeaState.Value;
	}

	private void SortTag(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (!base.Visible || (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void CalcTag(object sender, FormClosingEventArgs e)
	{
		if (ForgotTag())
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
		}
		else
		{
			e.Cancel = true;
		}
	}

	private void RateTag()
	{
		algoReponse = true;
		cmbTerrainType.DataSource = null;
		cmbTerrainType.DataSource = Enum.GetValues(typeof(LandCover.LandCoverType));
		algoReponse = false;
	}

	private void FlushTag(object sender, EventArgs e)
	{
		if (!algoReponse)
		{
			_ParserReponse.TerrainType = (LandCover.LandCoverType)cmbTerrainType.SelectedItem;
			if (!_ParserReponse.HasCustomTerrain)
			{
				_ParserReponse.RemoveCustomTerrainHeight();
			}
			PrintTag();
			if (!_ParserReponse.HasCustomTerrainHeight)
			{
				txtTerrainHeight.Text = _ParserReponse.TerrainHeight.ToString();
			}
		}
	}

	private bool ForgotTag()
	{
		string text = "";
		if (_ParserReponse.ThermalLayerCeiling < _ParserReponse.ThermalLayerFloor)
		{
			text = "Thermal Layer Ceiling must be higher then Thermal Layer Floor";
		}
		if ((_ParserReponse.ThermalLayerCeiling > 0) | (_ParserReponse.ThermalLayerFloor > 0))
		{
			text = text + Environment.NewLine + "Thermal Layer Ceiling and Thermal Layer Floor must be below 0";
		}
		if ((_ParserReponse.LayerStrength < 0f) | (_ParserReponse.LayerStrength > 100f))
		{
			text = text + Environment.NewLine + "Thermal Layer Strength is a percentage value must be between 0 and 100";
		}
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			DarkMessageBox.ShowError(text, "Validation Error");
		}
		return Operators.CompareString(text, "", TextCompare: true) == 0;
	}

	private void CollectTag(object object_0)
	{
		if (Versioned.IsNumeric(txtThermalLayerCeiling.Text))
		{
			_ParserReponse.ThermalLayerCeiling = int.Parse(txtThermalLayerCeiling.Text);
		}
	}

	private void OrderTag(object object_0)
	{
		if (Versioned.IsNumeric(txtThermalLayerFloor.Text))
		{
			_ParserReponse.ThermalLayerFloor = int.Parse(txtThermalLayerFloor.Text);
		}
	}

	private void RegisterTag(object object_0)
	{
		if (Versioned.IsNumeric(txtLayerStrenght.Text))
		{
			_ParserReponse.LayerStrength = int.Parse(txtLayerStrenght.Text);
		}
	}

	private void ManageTag(object object_0)
	{
		if (Versioned.IsNumeric(txtCZInterval.Text))
		{
			_ParserReponse.Single_0 = int.Parse(txtCZInterval.Text);
		}
	}

	private void RevertTag(DarkUITextBox darkUITextBox_0, ref int int_0)
	{
		string obj = darkUITextBox_0.Text;
		bool flag = false;
		if (Operators.CompareString(Conversions.ToString(obj[0]), "-", TextCompare: true) == 0)
		{
			flag = true;
		}
		if (int.TryParse(obj, out var result))
		{
			int_0 = result;
			if (flag & (int_0 > 0))
			{
				int_0 = -int_0;
			}
			try
			{
				txtTerrainHeight.TextChanged -= CountField;
				darkUITextBox_0.Text = int_0.ToString();
				return;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return;
			}
			finally
			{
				txtTerrainHeight.TextChanged += CountField;
			}
		}
		try
		{
			txtTerrainHeight.TextChanged -= CountField;
			if (flag)
			{
				darkUITextBox_0.Text = "-";
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		finally
		{
			txtTerrainHeight.TextChanged += CountField;
		}
	}

	private void CountField(object object_0)
	{
		if (ChkCustomTerrainHeight.Checked && Operators.CompareString(txtTerrainHeight.Text, "", TextCompare: true) != 0)
		{
			DarkUITextBox darkUITextBox_ = txtTerrainHeight;
			CustomEnvironmentZone parserReponse = _ParserReponse;
			int int_ = parserReponse.TerrainHeight;
			RevertTag(darkUITextBox_, ref int_);
			parserReponse.TerrainHeight = int_;
		}
	}

	internal void CustomizeField(ref CustomEnvironmentZone customEnvironmentZone_0)
	{
		_ParserReponse = customEnvironmentZone_0;
	}

	private void CloneField(object object_0)
	{
		if (ChkCustomTerrainHeight.Checked)
		{
			txtTerrainHeight.Enabled = true;
			return;
		}
		txtTerrainHeight.Enabled = false;
		if (_ParserReponse != null && _ParserReponse.HasCustomTerrainHeight)
		{
			_ParserReponse.RemoveCustomTerrainHeight();
		}
	}
}
