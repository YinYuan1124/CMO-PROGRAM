using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class UnitSerialEditor : Form
{
	[DoNotPruneType]
	[DoNotPrune]
	[DoNotObfuscateType]
	private class MothershipItem
	{
		public ActiveUnit m_StateMap;

		public string Name => Mothership.Name;

		public ActiveUnit Mothership
		{
			get
			{
				return m_StateMap;
			}
			set
			{
				m_StateMap = value;
			}
		}

		public MothershipItem(ActiveUnit activeUnit_0)
		{
			m_StateMap = activeUnit_0;
		}
	}

	private IContainer m_PublisherVisitor;

	[AccessedThroughProperty("Label_Weight")]
	[CompilerGenerated]
	private DarkLabel m_AdapterVisitor;

	[AccessedThroughProperty("Label_Area")]
	[CompilerGenerated]
	private DarkLabel m_UtilsVisitor;

	[AccessedThroughProperty("Combo_MothershipHost")]
	[CompilerGenerated]
	private DarkUIComboBox _PredicateVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_ChalkID")]
	private DarkUITextBox m_RecordVisitor;

	[AccessedThroughProperty("Label_LargestCargo")]
	[CompilerGenerated]
	private DarkLabel m_ExceptionVisitor;

	[AccessedThroughProperty("DarkLabel5")]
	[CompilerGenerated]
	private DarkLabel m_AttrVisitor;

	[CompilerGenerated]
	[AccessedThroughProperty("LV_Serials")]
	private DarkListView visitorVisitor;

	[AccessedThroughProperty("ButtonAddSerial")]
	[CompilerGenerated]
	private DarkUIButton m_PrototypeVisitor;

	[AccessedThroughProperty("ButtonRemoveSerial")]
	[CompilerGenerated]
	private DarkUIButton _ItemVisitor;

	[AccessedThroughProperty("DarkGroupBox5")]
	[CompilerGenerated]
	private DarkGroupBox m_CreatorVisitor;

	[AccessedThroughProperty("DGV_Assets")]
	[CompilerGenerated]
	private DataGridView m_MappingVisitor;

	[AccessedThroughProperty("ButtonRenameChalk")]
	[CompilerGenerated]
	private DarkUIButton m_FieldVisitor;

	public Chalk CurrentlySelectedChalk;

	public ActiveUnit CurrentlySelectedMothership;

	public List<CargoManifestItem> CargoGrouped;

	public List<CargoManifestItem> CargoGroupedAssignedToChalk;

	public Dictionary<string, Chalk> CargoChalkAssigned;

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel Label_Weight
	{
		[CompilerGenerated]
		get
		{
			return m_AdapterVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdapterVisitor = value;
		}
	}

	[field: AccessedThroughProperty("Label_Crew")]
	internal virtual DarkLabel Label_Crew
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel Label_Area
	{
		[CompilerGenerated]
		get
		{
			return m_UtilsVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_UtilsVisitor = value;
		}
	}

	internal virtual DarkUIComboBox Combo_MothershipHost
	{
		[CompilerGenerated]
		get
		{
			return _PredicateVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LogoutInterruptibleSetter;
			DarkUIComboBox predicateVisitor = _PredicateVisitor;
			if (predicateVisitor != null)
			{
				predicateVisitor.SelectedIndexChanged -= value2;
			}
			_PredicateVisitor = value;
			predicateVisitor = _PredicateVisitor;
			if (predicateVisitor != null)
			{
				predicateVisitor.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUITextBox TB_ChalkID
	{
		[CompilerGenerated]
		get
		{
			return m_RecordVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RecordVisitor = value;
		}
	}

	internal virtual DarkLabel Label_LargestCargo
	{
		[CompilerGenerated]
		get
		{
			return m_ExceptionVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExceptionVisitor = value;
		}
	}

	internal virtual DarkLabel DarkLabel5
	{
		[CompilerGenerated]
		get
		{
			return m_AttrVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttrVisitor = value;
		}
	}

	internal virtual DarkListView LV_Serials
	{
		[CompilerGenerated]
		get
		{
			return visitorVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CloneInterruptibleSetter;
			DarkListView darkListView = visitorVisitor;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged -= value2;
			}
			visitorVisitor = value;
			darkListView = visitorVisitor;
			if (darkListView != null)
			{
				darkListView.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ButtonAddSerial
	{
		[CompilerGenerated]
		get
		{
			return m_PrototypeVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectInterruptibleSetter;
			DarkUIButton prototypeVisitor = m_PrototypeVisitor;
			if (prototypeVisitor != null)
			{
				prototypeVisitor.Click -= value2;
			}
			m_PrototypeVisitor = value;
			prototypeVisitor = m_PrototypeVisitor;
			if (prototypeVisitor != null)
			{
				prototypeVisitor.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox2")]
	internal virtual DarkGroupBox DarkGroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ButtonRemoveSerial
	{
		[CompilerGenerated]
		get
		{
			return _ItemVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallInterruptibleSetter;
			DarkUIButton itemVisitor = _ItemVisitor;
			if (itemVisitor != null)
			{
				itemVisitor.Click -= value2;
			}
			_ItemVisitor = value;
			itemVisitor = _ItemVisitor;
			if (itemVisitor != null)
			{
				itemVisitor.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox3")]
	internal virtual DarkGroupBox DarkGroupBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkGroupBox DarkGroupBox5
	{
		[CompilerGenerated]
		get
		{
			return m_CreatorVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CreatorVisitor = value;
		}
	}

	[field: AccessedThroughProperty("LV_PossibleTransport")]
	internal virtual DarkListView LV_PossibleTransport
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DataGridView DGV_Assets
	{
		[CompilerGenerated]
		get
		{
			return m_MappingVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = ValidateInterruptibleSetter;
			DataGridView mappingVisitor = m_MappingVisitor;
			if (mappingVisitor != null)
			{
				mappingVisitor.CellContentClick -= value2;
			}
			m_MappingVisitor = value;
			mappingVisitor = m_MappingVisitor;
			if (mappingVisitor != null)
			{
				mappingVisitor.CellContentClick += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkUIButton4")]
	internal virtual DarkUIButton DarkUIButton4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DarkUIButton5")]
	internal virtual DarkUIButton DarkUIButton5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton ButtonRenameChalk
	{
		[CompilerGenerated]
		get
		{
			return m_FieldVisitor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PatchInterruptibleSetter;
			DarkUIButton fieldVisitor = m_FieldVisitor;
			if (fieldVisitor != null)
			{
				fieldVisitor.Click -= value2;
			}
			m_FieldVisitor = value;
			fieldVisitor = m_FieldVisitor;
			if (fieldVisitor != null)
			{
				fieldVisitor.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Warning_NoMothership")]
	internal virtual DarkLabel Warning_NoMothership
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ModInfos")]
	internal virtual DarkLabel ModInfos
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public UnitSerialEditor()
	{
		base.Load += ComputeInterruptibleSetter;
		CargoGrouped = new List<CargoManifestItem>();
		CargoGroupedAssignedToChalk = new List<CargoManifestItem>();
		CargoChalkAssigned = new Dictionary<string, Chalk>();
		CustomizeInterruptibleSetter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_PublisherVisitor != null)
			{
				m_PublisherVisitor.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CustomizeInterruptibleSetter()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DarkLabel4 = new DarkLabel();
		DarkGroupBox3 = new DarkGroupBox();
		ModInfos = new DarkLabel();
		DGV_Assets = new DataGridView();
		DarkGroupBox2 = new DarkGroupBox();
		ButtonRemoveSerial = new DarkUIButton();
		ButtonAddSerial = new DarkUIButton();
		LV_Serials = new DarkListView();
		DarkGroupBox1 = new DarkGroupBox();
		ButtonRenameChalk = new DarkUIButton();
		DarkGroupBox5 = new DarkGroupBox();
		LV_PossibleTransport = new DarkListView();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Label_LargestCargo = new DarkLabel();
		Label_Weight = new DarkLabel();
		Label_Area = new DarkLabel();
		Label_Crew = new DarkLabel();
		TB_ChalkID = new DarkUITextBox();
		DarkLabel5 = new DarkLabel();
		Warning_NoMothership = new DarkLabel();
		DarkUIButton5 = new DarkUIButton();
		DarkUIButton4 = new DarkUIButton();
		Combo_MothershipHost = new DarkUIComboBox();
		DarkGroupBox3.SuspendLayout();
		((ISupportInitialize)DGV_Assets).BeginInit();
		DarkGroupBox2.SuspendLayout();
		DarkGroupBox1.SuspendLayout();
		DarkGroupBox5.SuspendLayout();
		FlowLayoutPanel1.SuspendLayout();
		SuspendLayout();
		DarkLabel4.AutoSize = true;
		DarkLabel4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel4.Location = new Point(15, 10);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(29, 13);
		DarkLabel4.TabIndex = 2;
		DarkLabel4.Text = "主机";
		DarkGroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox3.Controls.Add(ModInfos);
		DarkGroupBox3.Controls.Add(DGV_Assets);
		DarkGroupBox3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox3.Location = new Point(100, 197);
		DarkGroupBox3.Name = "DarkGroupBox3";
		DarkGroupBox3.Size = new Size(617, 233);
		DarkGroupBox3.TabIndex = 13;
		DarkGroupBox3.TabStop = false;
		DarkGroupBox3.Text = "Assets in Serial";
		ModInfos.AutoSize = true;
		ModInfos.ForeColor = Color.FromArgb(220, 220, 220);
		ModInfos.Location = new Point(104, 0);
		ModInfos.Name = "ModInfos";
		ModInfos.Size = new Size(96, 13);
		ModInfos.TabIndex = 9;
		ModInfos.Text = "(Ctrl +5 / Shift +10)";
		DGV_Assets.AllowUserToAddRows = false;
		DGV_Assets.AllowUserToDeleteRows = false;
		DGV_Assets.AllowUserToResizeColumns = false;
		DGV_Assets.AllowUserToResizeRows = false;
		DGV_Assets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_Assets.BackgroundColor = Color.Silver;
		DGV_Assets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Window;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = Color.FromArgb(220, 220, 220);
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.ControlText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		DGV_Assets.DefaultCellStyle = dataGridViewCellStyle;
		DGV_Assets.Location = new Point(6, 19);
		DGV_Assets.MultiSelect = false;
		DGV_Assets.Name = "DGV_Assets";
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		DGV_Assets.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
		DGV_Assets.RowHeadersVisible = false;
		DGV_Assets.RowHeadersWidth = 51;
		dataGridViewCellStyle3.ForeColor = Color.Black;
		dataGridViewCellStyle3.SelectionForeColor = Color.Black;
		DGV_Assets.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_Assets.Size = new Size(605, 208);
		DGV_Assets.TabIndex = 0;
		DarkGroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DarkGroupBox2.Controls.Add(ButtonRemoveSerial);
		DarkGroupBox2.Controls.Add(ButtonAddSerial);
		DarkGroupBox2.Controls.Add(LV_Serials);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(11, 35);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(81, 395);
		DarkGroupBox2.TabIndex = 9;
		DarkGroupBox2.TabStop = false;
		DarkGroupBox2.Text = "Serials #";
		ButtonRemoveSerial.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ButtonRemoveSerial.BackColor = Color.Transparent;
		ButtonRemoveSerial.DialogResult = DialogResult.None;
		ButtonRemoveSerial.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonRemoveSerial.ForeColor = SystemColors.Control;
		ButtonRemoveSerial.Location = new Point(43, 366);
		ButtonRemoveSerial.Name = "ButtonRemoveSerial";
		ButtonRemoveSerial.RoundRadius = 0;
		ButtonRemoveSerial.Size = new Size(31, 23);
		ButtonRemoveSerial.TabIndex = 9;
		ButtonRemoveSerial.Text = "-";
		ButtonAddSerial.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ButtonAddSerial.BackColor = Color.Transparent;
		ButtonAddSerial.DialogResult = DialogResult.None;
		ButtonAddSerial.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ButtonAddSerial.ForeColor = SystemColors.Control;
		ButtonAddSerial.Location = new Point(7, 366);
		ButtonAddSerial.Name = "ButtonAddSerial";
		ButtonAddSerial.RoundRadius = 0;
		ButtonAddSerial.Size = new Size(31, 23);
		ButtonAddSerial.TabIndex = 8;
		ButtonAddSerial.Text = "+";
		LV_Serials.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LV_Serials.BackColor = Color.FromArgb(50, 53, 55);
		LV_Serials.Location = new Point(7, 22);
		LV_Serials.Name = "LV_Serials";
		LV_Serials.RelatedInfos = null;
		LV_Serials.Size = new Size(67, 338);
		LV_Serials.TabIndex = 7;
		LV_Serials.Text = "LV_Serials";
		DarkGroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox1.Controls.Add(ButtonRenameChalk);
		DarkGroupBox1.Controls.Add(DarkGroupBox5);
		DarkGroupBox1.Controls.Add(FlowLayoutPanel1);
		DarkGroupBox1.Controls.Add(TB_ChalkID);
		DarkGroupBox1.Controls.Add(DarkLabel5);
		DarkGroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox1.Location = new Point(100, 36);
		DarkGroupBox1.Name = "DarkGroupBox1";
		DarkGroupBox1.Size = new Size(617, 155);
		DarkGroupBox1.TabIndex = 0;
		DarkGroupBox1.TabStop = false;
		DarkGroupBox1.Text = "Informations";
		ButtonRenameChalk.BackColor = Color.Transparent;
		ButtonRenameChalk.DialogResult = DialogResult.None;
		ButtonRenameChalk.ForeColor = SystemColors.Control;
		ButtonRenameChalk.Location = new Point(6, 44);
		ButtonRenameChalk.Name = "ButtonRenameChalk";
		ButtonRenameChalk.RoundRadius = 0;
		ButtonRenameChalk.Size = new Size(132, 23);
		ButtonRenameChalk.TabIndex = 8;
		ButtonRenameChalk.Text = "改名";
		DarkGroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox5.Controls.Add(LV_PossibleTransport);
		DarkGroupBox5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox5.Location = new Point(202, 18);
		DarkGroupBox5.Name = "DarkGroupBox5";
		DarkGroupBox5.Size = new Size(409, 131);
		DarkGroupBox5.TabIndex = 7;
		DarkGroupBox5.TabStop = false;
		DarkGroupBox5.Text = "Eligible Tranports [Capacity]";
		LV_PossibleTransport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		LV_PossibleTransport.BackColor = Color.FromArgb(50, 53, 55);
		LV_PossibleTransport.Location = new Point(5, 19);
		LV_PossibleTransport.MinimumSize = new Size(379, 106);
		LV_PossibleTransport.Name = "LV_PossibleTransport";
		LV_PossibleTransport.RelatedInfos = null;
		LV_PossibleTransport.Size = new Size(379, 106);
		LV_PossibleTransport.TabIndex = 0;
		LV_PossibleTransport.Text = "DarkListView1";
		FlowLayoutPanel1.Controls.Add(Label_LargestCargo);
		FlowLayoutPanel1.Controls.Add(Label_Weight);
		FlowLayoutPanel1.Controls.Add(Label_Area);
		FlowLayoutPanel1.Controls.Add(Label_Crew);
		FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
		FlowLayoutPanel1.Location = new Point(6, 69);
		FlowLayoutPanel1.Margin = new Padding(5);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Padding = new Padding(0, 1, 1, 1);
		FlowLayoutPanel1.Size = new Size(188, 80);
		FlowLayoutPanel1.TabIndex = 4;
		Label_LargestCargo.AutoSize = true;
		Label_LargestCargo.ForeColor = Color.FromArgb(220, 220, 220);
		Label_LargestCargo.Location = new Point(3, 1);
		Label_LargestCargo.Name = "Label_LargestCargo";
		Label_LargestCargo.Padding = new Padding(2);
		Label_LargestCargo.Size = new Size(114, 17);
		Label_LargestCargo.TabIndex = 3;
		Label_LargestCargo.Text = "Largest cargo type : L";
		Label_Weight.AutoSize = true;
		Label_Weight.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Weight.Location = new Point(3, 18);
		Label_Weight.Name = "Label_Weight";
		Label_Weight.Padding = new Padding(2);
		Label_Weight.Size = new Size(93, 17);
		Label_Weight.TabIndex = 0;
		Label_Weight.Text = "Weight : 58 Tons";
		Label_Area.AutoSize = true;
		Label_Area.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Area.Location = new Point(3, 35);
		Label_Area.Name = "Label_Area";
		Label_Area.Padding = new Padding(2);
		Label_Area.Size = new Size(71, 17);
		Label_Area.TabIndex = 1;
		Label_Area.Text = "Area : 28 m2";
		Label_Crew.AutoSize = true;
		Label_Crew.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Crew.Location = new Point(3, 52);
		Label_Crew.Name = "Label_Crew";
		Label_Crew.Padding = new Padding(2);
		Label_Crew.Size = new Size(59, 17);
		Label_Crew.TabIndex = 2;
		Label_Crew.Text = "Crew :  38";
		TB_ChalkID.AutoCompleteCustomSource = null;
		TB_ChalkID.AutoCompleteMode = AutoCompleteMode.None;
		TB_ChalkID.AutoCompleteSource = AutoCompleteSource.None;
		TB_ChalkID.BackColor = Color.Transparent;
		TB_ChalkID.ForeColor = Color.FromArgb(189, 189, 189);
		TB_ChalkID.Image = null;
		TB_ChalkID.Lines = null;
		TB_ChalkID.Location = new Point(59, 18);
		TB_ChalkID.MaxLength = 32767;
		TB_ChalkID.Multiline = false;
		TB_ChalkID.Name = "TB_ChalkID";
		TB_ChalkID.ReadOnly = false;
		TB_ChalkID.ScrollBars = ScrollBars.None;
		TB_ChalkID.SelectionStart = 0;
		TB_ChalkID.Size = new Size(79, 24);
		TB_ChalkID.TabIndex = 5;
		TB_ChalkID.Text = "0001";
		TB_ChalkID.TextAlign = HorizontalAlignment.Left;
		TB_ChalkID.UseSystemPasswordChar = false;
		TB_ChalkID.WatermarkText = "";
		DarkLabel5.AutoSize = true;
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(6, 22);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(47, 13);
		DarkLabel5.TabIndex = 6;
		DarkLabel5.Text = "Serial ID";
		Warning_NoMothership.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Warning_NoMothership.AutoSize = true;
		Warning_NoMothership.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Warning_NoMothership.ForeColor = Color.FromArgb(255, 128, 128);
		Warning_NoMothership.Location = new Point(503, 12);
		Warning_NoMothership.Name = "Warning_NoMothership";
		Warning_NoMothership.Size = new Size(208, 15);
		Warning_NoMothership.TabIndex = 17;
		Warning_NoMothership.Text = "No available mothership with cargo  !";
		DarkUIButton5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		DarkUIButton5.BackColor = Color.Transparent;
		DarkUIButton5.DialogResult = DialogResult.None;
		DarkUIButton5.ForeColor = SystemColors.Control;
		DarkUIButton5.Location = new Point(223, 6);
		DarkUIButton5.Name = "DarkUIButton5";
		DarkUIButton5.RoundRadius = 0;
		DarkUIButton5.Size = new Size(132, 23);
		DarkUIButton5.TabIndex = 16;
		DarkUIButton5.Text = "Import from Spreadsheet";
		DarkUIButton5.Visible = false;
		DarkUIButton4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		DarkUIButton4.BackColor = Color.Transparent;
		DarkUIButton4.DialogResult = DialogResult.None;
		DarkUIButton4.ForeColor = SystemColors.Control;
		DarkUIButton4.Location = new Point(361, 6);
		DarkUIButton4.Name = "DarkUIButton4";
		DarkUIButton4.RoundRadius = 0;
		DarkUIButton4.Size = new Size(132, 23);
		DarkUIButton4.TabIndex = 15;
		DarkUIButton4.Text = "Export to Spreadsheet";
		DarkUIButton4.Visible = false;
		Combo_MothershipHost.BackColor = Color.Transparent;
		Combo_MothershipHost.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_MothershipHost.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_MothershipHost.Font = new Font("Segoe UI", 7f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Combo_MothershipHost.FormattingEnabled = true;
		Combo_MothershipHost.Items.AddRange(new object[1] { "Wasp 1" });
		Combo_MothershipHost.Location = new Point(50, 8);
		Combo_MothershipHost.Name = "Combo_MothershipHost";
		Combo_MothershipHost.Size = new Size(167, 21);
		Combo_MothershipHost.TabIndex = 1;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(726, 440);
		base.Controls.Add(Warning_NoMothership);
		base.Controls.Add(DarkUIButton5);
		base.Controls.Add(DarkUIButton4);
		base.Controls.Add(DarkLabel4);
		base.Controls.Add(Combo_MothershipHost);
		base.Controls.Add(DarkGroupBox3);
		base.Controls.Add(DarkGroupBox2);
		base.Controls.Add(DarkGroupBox1);
		MinimumSize = new Size(742, 479);
		base.Name = "UnitSerialEditor";
		base.ShowIcon = false;
		Text = "Unit Serial Editor";
		DarkGroupBox3.ResumeLayout(performLayout: false);
		DarkGroupBox3.PerformLayout();
		((ISupportInitialize)DGV_Assets).EndInit();
		DarkGroupBox2.ResumeLayout(performLayout: false);
		DarkGroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox1.PerformLayout();
		DarkGroupBox5.ResumeLayout(performLayout: false);
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		FlowLayoutPanel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CloneInterruptibleSetter(object sender, EventArgs e)
	{
		if (LV_Serials.SelectedItems.Count >= 1)
		{
			ConnectInterruptibleSetter((Chalk)LV_Serials.SelectedItems.ElementAt(0).Tag);
		}
	}

	private void ConnectInterruptibleSetter(Chalk chalk_0)
	{
		if (!Information.IsNothing(chalk_0))
		{
			CurrentlySelectedChalk = chalk_0;
			MoveInterruptibleSetter();
		}
	}

	private void MoveInterruptibleSetter()
	{
		CargoGrouped.Clear();
		CargoGroupedAssignedToChalk.Clear();
		CargoChalkAssigned.Clear();
		if (CurrentlySelectedChalk == null)
		{
			TB_ChalkID.Text = "";
			Label_LargestCargo.Text = "";
			Label_Weight.Text = "";
			Label_Area.Text = "";
			Label_Crew.Text = "";
		}
		else
		{
			TB_ChalkID.Text = CurrentlySelectedChalk.ID.ToString();
			Label_LargestCargo.Text = "Largest Cargo Type : " + Enum.GetName(typeof(CargoType), (int)CurrentlySelectedChalk.DestroyImporter());
			Label_Weight.Text = "Weight : " + CurrentlySelectedChalk.ComputeImporter() + "吨";
			Label_Area.Text = "Area : " + CurrentlySelectedChalk.PatchImporter() + " m2";
			Label_Crew.Text = "Personnel Capacity : " + CurrentlySelectedChalk.SelectImporter() + " PAX";
		}
		DeleteInterruptibleSetter();
		DGV_Assets.Rows.Clear();
		if (CurrentlySelectedMothership == null || CurrentlySelectedChalk == null)
		{
			return;
		}
		CargoGrouped = Cargo.GenerateCargoManifest(CurrentlySelectedMothership, bool_0: false, bool_1: true);
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			if (chalk.AssociatedMothership == null || Operators.CompareString(chalk.AssociatedMothership.ObjectID, CurrentlySelectedMothership.ObjectID, TextCompare: true) != 0)
			{
				continue;
			}
			foreach (KeyValuePair<Cargo, int> item in chalk.Cargo)
			{
				CargoChalkAssigned.Add(item.Key.ObjectID, chalk);
				CargoManifestItem.Add(item.Key, CargoGroupedAssignedToChalk, bool_0: true);
			}
		}
		foreach (CargoManifestItem item2 in CargoGrouped)
		{
			if (item2.quantity <= 0)
			{
				continue;
			}
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<Cargo, int> item3 in CurrentlySelectedChalk.Cargo)
			{
				Cargo key = item3.Key;
				if (item2.IsMatch(key))
				{
					num2++;
				}
			}
			CargoManifestItem cargoManifestItem = CargoManifestItem.FindMatch(item2, CargoGroupedAssignedToChalk);
			if (cargoManifestItem != null)
			{
				num = cargoManifestItem.quantity;
			}
			Cargo cargo = null;
			Cargo[] onboardCargo = CurrentlySelectedMothership.OnboardCargo;
			Cargo[] array = onboardCargo;
			foreach (Cargo cargo2 in array)
			{
				if (item2.IsMatch(cargo2))
				{
					cargo = cargo2;
					break;
				}
			}
			if (cargo == null)
			{
				AddRowMainDGV(num2.ToString(), "[" + num + "/" + item2.quantity + "]", item2.NameNoQuantity, "ERROR", "ERROR", "ERROR", null);
			}
			else
			{
				AddRowMainDGV(num2.ToString(), "[" + num + "/" + item2.quantity + "]", item2.NameNoQuantity, cargo.RequiredMass.ToString(), cargo.RequiredArea.ToString(), cargo.RequiredCrewSpace.ToString(), cargo);
			}
		}
	}

	private void DeleteInterruptibleSetter()
	{
		LV_PossibleTransport.Items.Clear();
		if (CurrentlySelectedMothership == null || CurrentlySelectedChalk == null)
		{
			return;
		}
		foreach (Aircraft item in CurrentlySelectedMothership.AirOps.EmbarkedAircraft_ReadOnly)
		{
			if (((ICargoHost)item).GetCargo_Type() != 0)
			{
				float float_ = 0f;
				string text = CurrentlySelectedChalk.AddImporter(item, ref float_);
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text += "(Airborne) ";
				darkListItem.Text += item.Name;
				if (Operators.CompareString(text, "OK", TextCompare: true) == 0)
				{
					DarkListItem darkListItem2;
					(darkListItem2 = darkListItem).Text = darkListItem2.Text + " [" + (int)Math.Round((double)float_ * 100.0) + " %]";
					darkListItem.TextColor = Color.FromArgb(255, 0, 255, 0);
				}
				else
				{
					DarkListItem darkListItem3;
					(darkListItem3 = darkListItem).Text = darkListItem3.Text + " ERROR : " + text;
					darkListItem.TextColor = Color.FromArgb(255, 255, 128, 128);
				}
				LV_PossibleTransport.Items.Add(darkListItem);
			}
		}
		foreach (ActiveUnit embarkedBoat in CurrentlySelectedMothership.DockingOps.EmbarkedBoats)
		{
			if (((ICargoHost)embarkedBoat).GetCargo_Type() != 0)
			{
				float float_2 = 0f;
				string text2 = CurrentlySelectedChalk.AddImporter(embarkedBoat, ref float_2);
				DarkListItem darkListItem4 = new DarkListItem();
				darkListItem4.Text += "(Amphibious) ";
				darkListItem4.Text += embarkedBoat.Name;
				if (Operators.CompareString(text2, "OK", TextCompare: true) == 0)
				{
					DarkListItem darkListItem5;
					(darkListItem5 = darkListItem4).Text = darkListItem5.Text + " [" + (int)Math.Round((double)float_2 * 100.0) + " %]";
					darkListItem4.TextColor = Color.FromArgb(255, 0, 255, 0);
				}
				else
				{
					DarkListItem darkListItem6;
					(darkListItem6 = darkListItem4).Text = darkListItem6.Text + " ERROR : " + text2;
					darkListItem4.TextColor = Color.FromArgb(255, 255, 128, 128);
				}
				LV_PossibleTransport.Items.Add(darkListItem4);
			}
		}
	}

	private void AddInterruptibleSetter()
	{
		new List<ActiveUnit>();
		Combo_MothershipHost.Items.Clear();
		Combo_MothershipHost.DisplayMember = "Name";
		Combo_MothershipHost.ValueMember = "Mothership";
		foreach (ActiveUnit unit in Client.CurrentSide.Units)
		{
			if (unit.IsShip && unit.HasCargo && Information.IsNothing(unit.DockingOps.CurrentHostUnit))
			{
				Combo_MothershipHost.Items.Add(new MothershipItem(unit));
			}
		}
		if (Combo_MothershipHost.Items.Count <= 0)
		{
			Warning_NoMothership.Text = "No available mothership with cargo  !";
			return;
		}
		Combo_MothershipHost.SelectedIndex = 0;
		Warning_NoMothership.Text = "";
	}

	private void DestroyInterruptibleSetter()
	{
		LV_Serials.Items.Clear();
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			if (chalk.AssociatedMothership != null && Operators.CompareString(chalk.AssociatedMothership.ObjectID, CurrentlySelectedMothership.ObjectID, TextCompare: true) == 0)
			{
				DarkListItem darkListItem = new DarkListItem();
				darkListItem.Text = chalk.ID.ToString();
				darkListItem.Tag = chalk;
				LV_Serials.Items.Add(darkListItem);
			}
		}
	}

	private void ComputeInterruptibleSetter(object sender, EventArgs e)
	{
		MoveInterruptibleSetter();
		DGV_Assets.AutoGenerateColumns = false;
		DGV_Assets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
		dataGridViewButtonColumn.Name = "QTY Allocated";
		dataGridViewButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DataGridViewButtonColumn dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
		dataGridViewButtonColumn2.Name = "QTY (Mothership)";
		dataGridViewButtonColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn.Name = "Unit";
		dataGridViewTextBoxColumn.ReadOnly = true;
		dataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		dataGridViewTextBoxColumn.Width = 200;
		dataGridViewTextBoxColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn2.Name = "Weight";
		dataGridViewTextBoxColumn2.ReadOnly = true;
		dataGridViewTextBoxColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn3.Name = "Space";
		dataGridViewTextBoxColumn3.ReadOnly = true;
		dataGridViewTextBoxColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DataGridViewTextBoxColumn dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn4.Name = "PAX";
		dataGridViewTextBoxColumn4.ReadOnly = true;
		dataGridViewTextBoxColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
		DGV_Assets.Columns.Add(dataGridViewButtonColumn);
		DGV_Assets.Columns.Add(dataGridViewButtonColumn2);
		DGV_Assets.Columns.Add(dataGridViewTextBoxColumn);
		DGV_Assets.Columns.Add(dataGridViewTextBoxColumn2);
		DGV_Assets.Columns.Add(dataGridViewTextBoxColumn3);
		DGV_Assets.Columns.Add(dataGridViewTextBoxColumn4);
		AddInterruptibleSetter();
		DestroyInterruptibleSetter();
	}

	public void AddRowMainDGV(string string_0, string string_1, string string_2, string string_3, string string_4, string string_5, Cargo cargo_0)
	{
		DGV_Assets.Rows.Add();
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["QTY Allocated"].Value = string_0;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["QTY Allocated"].Tag = cargo_0;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["QTY (Mothership)"].Value = string_1;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["Unit"].Value = string_2;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["Weight"].Value = string_3;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["Space"].Value = string_4;
		DGV_Assets.Rows[DGV_Assets.Rows.Count - 1].Cells["PAX"].Value = string_5;
	}

	private void PatchInterruptibleSetter(object sender, EventArgs e)
	{
		if (CurrentlySelectedChalk == null)
		{
			return;
		}
		foreach (Chalk chalk in Client.CurrentSide.Chalks)
		{
			if (Operators.CompareString(TB_ChalkID.Text, chalk.ID.ToString(), TextCompare: true) == 0)
			{
				return;
			}
		}
		int result = CurrentlySelectedChalk.ID;
		if (int.TryParse(TB_ChalkID.Text, out result))
		{
			CurrentlySelectedChalk.ID = result;
		}
		else
		{
			TB_ChalkID.Text = result.ToString();
		}
		DestroyInterruptibleSetter();
	}

	private void SelectInterruptibleSetter(object sender, EventArgs e)
	{
		if (CurrentlySelectedMothership != null)
		{
			Chalk.AddNewChalk(Client.CurrentSide, CurrentlySelectedMothership);
			DestroyInterruptibleSetter();
			if (LV_Serials.Items.Count > 0)
			{
				LV_Serials.SelectItem(LV_Serials.Items.Count - 1);
			}
		}
	}

	private void CallInterruptibleSetter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(CurrentlySelectedChalk))
		{
			Chalk.RemoveChalk(Client.CurrentSide, CurrentlySelectedChalk);
			DestroyInterruptibleSetter();
			if (LV_Serials.Items.Count > 0)
			{
				LV_Serials.SelectItem(LV_Serials.Items.Count - 1);
			}
		}
	}

	private void LogoutInterruptibleSetter(object sender, EventArgs e)
	{
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(Combo_MothershipHost.SelectedItem)))
		{
			CurrentlySelectedMothership = ((MothershipItem)Combo_MothershipHost.SelectedItem).Mothership;
			DestroyInterruptibleSetter();
			if (LV_Serials.Items.Count > 0)
			{
				LV_Serials.SelectItem(LV_Serials.Items.Count - 1);
			}
			MoveInterruptibleSetter();
		}
	}

	private void ViewInterruptibleSetter(Cargo cargo_0, int int_0)
	{
		if (int_0 == 0)
		{
			return;
		}
		Cargo[] array = CurrentlySelectedMothership.OnboardCargo;
		if (int_0 < 0)
		{
			array = CurrentlySelectedChalk.Cargo.Keys.ToArray();
		}
		int num = Math.Abs(int_0) - 1;
		for (int i = 0; i <= num; i++)
		{
			Cargo[] array2 = array;
			Cargo[] array3 = array2;
			foreach (Cargo cargo in array3)
			{
				if (int_0 <= 0)
				{
					if (cargo.IsMatch(cargo_0) && GetInterruptibleSetter(cargo))
					{
						break;
					}
				}
				else if (cargo.IsMatch(cargo_0) && !CargoChalkAssigned.ContainsKey(cargo.ObjectID) && LoginInterruptibleSetter(cargo))
				{
					break;
				}
			}
		}
		MoveInterruptibleSetter();
	}

	private void ValidateInterruptibleSetter(object sender, DataGridViewCellEventArgs e)
	{
		DataGridView dataGridView = (DataGridView)sender;
		if (e.RowIndex < 0)
		{
			return;
		}
		int num = 1;
		if (Control.ModifierKeys == Keys.Control)
		{
			num = 5;
		}
		if (Control.ModifierKeys == Keys.Shift)
		{
			num = 10;
		}
		if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
		{
			if (Operators.CompareString(dataGridView.Columns[e.ColumnIndex].Name, "QTY Allocated", TextCompare: true) == 0)
			{
				ViewInterruptibleSetter((Cargo)DGV_Assets.Rows[e.RowIndex].Cells["QTY Allocated"].Tag, num);
			}
			else if (Operators.CompareString(dataGridView.Columns[e.ColumnIndex].Name, "QTY (Mothership)", TextCompare: true) == 0)
			{
				ViewInterruptibleSetter((Cargo)DGV_Assets.Rows[e.RowIndex].Cells["QTY Allocated"].Tag, -num);
			}
		}
	}

	private bool LoginInterruptibleSetter(Cargo cargo_0)
	{
		if (CurrentlySelectedChalk.Cargo.ContainsKey(cargo_0))
		{
			return false;
		}
		CurrentlySelectedChalk.Cargo.Add(cargo_0, 0);
		return true;
	}

	private bool GetInterruptibleSetter(Cargo cargo_0)
	{
		if (CurrentlySelectedChalk.Cargo.ContainsKey(cargo_0))
		{
			CurrentlySelectedChalk.Cargo.Remove(cargo_0);
			return true;
		}
		return false;
	}
}
