using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Listeners;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FormationEditor : DarkSecondaryFormBase
{
	private IContainer _AccountFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton1")]
	private ToolStripButton authenticationFilter;

	[AccessedThroughProperty("CMenu_Unit")]
	[CompilerGenerated]
	private DarkContextMenu paramsFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("AssignToPatrol_TSMI")]
	private DarkToolStripMenuItem infoFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Units")]
	private DarkTreeView _MapperFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_SetStationRelative")]
	private ToolStripButton _ManagerFilter;

	[AccessedThroughProperty("TSB_SetStationFixed")]
	[CompilerGenerated]
	private ToolStripButton m_GetterFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStrip2")]
	private DarkToolStrip producerFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer m_StructTests;

	[AccessedThroughProperty("combo_Formations")]
	[CompilerGenerated]
	private ToolStripComboBox _MerchantTests;

	[CompilerGenerated]
	[AccessedThroughProperty("label_Spacing")]
	private ToolStripLabel callbackTests;

	[CompilerGenerated]
	[AccessedThroughProperty("combo_SpacingUnits")]
	private ToolStripComboBox _DecoratorTests;

	[AccessedThroughProperty("label_Heading")]
	[CompilerGenerated]
	private ToolStripLabel processTests;

	[AccessedThroughProperty("button_SetFormation")]
	[CompilerGenerated]
	private ToolStripButton _ThreadTests;

	[CompilerGenerated]
	[AccessedThroughProperty("button_SetImmediate")]
	private ToolStripButton _RuleTests;

	[AccessedThroughProperty("numeric_Heading")]
	[CompilerGenerated]
	private NumericUpDown collectionTests;

	[CompilerGenerated]
	[AccessedThroughProperty("numeric_SpacingDistance")]
	private NumericUpDown instanceTests;

	[AccessedThroughProperty("CB_MembersInheritIcon")]
	[CompilerGenerated]
	private CheckBox expressionTests;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ReloadFormation")]
	private ToolStripButton m_ListenerTests;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditFormation")]
	private ToolStripButton _ConfigTests;

	public Group SelectedGroup;

	public Patrol SelectedPatrol;

	private DarkCheckBox _RegistryTests;

	private Keys[] m_DefinitionTests;

	private List<StandardFormation> valTests;

	private static int m_WrapperTests;

	private static int observerTests;

	private static int m_IssuerTests;

	private static int _ClientTests;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal DarkToolStrip ToolStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return authenticationFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteMessage;
			ToolStripButton toolStripButton = authenticationFilter;
			if (toolStripButton != null)
			{
				toolStripButton.Click -= value2;
			}
			authenticationFilter = value;
			toolStripButton = authenticationFilter;
			if (toolStripButton != null)
			{
				toolStripButton.Click += value2;
			}
		}
	}

	internal DarkContextMenu CMenu_Unit
	{
		[CompilerGenerated]
		get
		{
			return paramsFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramsFilter = value;
		}
	}

	internal DarkToolStripMenuItem AssignToPatrol_TSMI
	{
		[CompilerGenerated]
		get
		{
			return infoFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ComputeMessage;
			DarkToolStripMenuItem darkToolStripMenuItem = infoFilter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click -= value2;
			}
			infoFilter = value;
			darkToolStripMenuItem = infoFilter;
			if (darkToolStripMenuItem != null)
			{
				darkToolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("RemoveFromPatrol_TSMI")]
	internal DarkToolStripMenuItem RemoveFromPatrol_TSMI
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkTreeView TV_Units
	{
		[CompilerGenerated]
		get
		{
			return _MapperFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = PatchMessage;
			DarkTreeView mapperFilter = _MapperFilter;
			if (mapperFilter != null)
			{
				mapperFilter.MouseClick -= value2;
			}
			_MapperFilter = value;
			mapperFilter = _MapperFilter;
			if (mapperFilter != null)
			{
				mapperFilter.MouseClick += value2;
			}
		}
	}

	internal ToolStripButton TSB_SetStationRelative
	{
		[CompilerGenerated]
		get
		{
			return _ManagerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SelectMessage;
			ToolStripButton managerFilter = _ManagerFilter;
			if (managerFilter != null)
			{
				managerFilter.Click -= value2;
			}
			_ManagerFilter = value;
			managerFilter = _ManagerFilter;
			if (managerFilter != null)
			{
				managerFilter.Click += value2;
			}
		}
	}

	internal ToolStripButton TSB_SetStationFixed
	{
		[CompilerGenerated]
		get
		{
			return m_GetterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CallMessage;
			ToolStripButton getterFilter = m_GetterFilter;
			if (getterFilter != null)
			{
				getterFilter.Click -= value2;
			}
			m_GetterFilter = value;
			getterFilter = m_GetterFilter;
			if (getterFilter != null)
			{
				getterFilter.Click += value2;
			}
		}
	}

	internal DarkToolStrip ToolStrip2
	{
		[CompilerGenerated]
		get
		{
			return producerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			producerFilter = value;
		}
	}

	[field: AccessedThroughProperty("label_Formation")]
	internal ToolStripLabel label_Formation
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripComboBox combo_Formations
	{
		[CompilerGenerated]
		get
		{
			return _MerchantTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ValidateMessage;
			ToolStripComboBox merchantTests = _MerchantTests;
			if (merchantTests != null)
			{
				merchantTests.SelectedIndexChanged -= value2;
			}
			_MerchantTests = value;
			merchantTests = _MerchantTests;
			if (merchantTests != null)
			{
				merchantTests.SelectedIndexChanged += value2;
			}
		}
	}

	internal ToolStripLabel label_Spacing
	{
		[CompilerGenerated]
		get
		{
			return callbackTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackTests = value;
		}
	}

	internal ToolStripComboBox combo_SpacingUnits
	{
		[CompilerGenerated]
		get
		{
			return _DecoratorTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LoginMessage;
			ToolStripComboBox decoratorTests = _DecoratorTests;
			if (decoratorTests != null)
			{
				decoratorTests.SelectedIndexChanged -= value2;
			}
			_DecoratorTests = value;
			decoratorTests = _DecoratorTests;
			if (decoratorTests != null)
			{
				decoratorTests.SelectedIndexChanged += value2;
			}
		}
	}

	internal ToolStripLabel label_Heading
	{
		[CompilerGenerated]
		get
		{
			return processTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			processTests = value;
		}
	}

	internal ToolStripButton button_SetFormation
	{
		[CompilerGenerated]
		get
		{
			return _ThreadTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InvokeMessage;
			ToolStripButton threadTests = _ThreadTests;
			if (threadTests != null)
			{
				threadTests.Click -= value2;
			}
			_ThreadTests = value;
			threadTests = _ThreadTests;
			if (threadTests != null)
			{
				threadTests.Click += value2;
			}
		}
	}

	internal ToolStripButton button_SetImmediate
	{
		[CompilerGenerated]
		get
		{
			return _RuleTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SetupMessage;
			ToolStripButton ruleTests = _RuleTests;
			if (ruleTests != null)
			{
				ruleTests.Click -= value2;
			}
			_RuleTests = value;
			ruleTests = _RuleTests;
			if (ruleTests != null)
			{
				ruleTests.Click += value2;
			}
		}
	}

	internal NumericUpDown numeric_Heading
	{
		[CompilerGenerated]
		get
		{
			return collectionTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NewMessage;
			EventHandler value3 = PushMessage;
			NumericUpDown numericUpDown = collectionTests;
			if (numericUpDown != null)
			{
				numericUpDown.TextChanged -= value2;
				numericUpDown.ValueChanged -= value3;
			}
			collectionTests = value;
			numericUpDown = collectionTests;
			if (numericUpDown != null)
			{
				numericUpDown.TextChanged += value2;
				numericUpDown.ValueChanged += value3;
			}
		}
	}

	internal NumericUpDown numeric_SpacingDistance
	{
		[CompilerGenerated]
		get
		{
			return instanceTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GetMessage;
			EventHandler value3 = WriteMessage;
			NumericUpDown numericUpDown = instanceTests;
			if (numericUpDown != null)
			{
				numericUpDown.TextChanged -= value2;
				numericUpDown.ValueChanged -= value3;
			}
			instanceTests = value;
			numericUpDown = instanceTests;
			if (numericUpDown != null)
			{
				numericUpDown.TextChanged += value2;
				numericUpDown.ValueChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty("TS_RenderOptions")]
	internal DarkToolStrip TS_RenderOptions
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

	internal CheckBox CB_MembersInheritIcon
	{
		[CompilerGenerated]
		get
		{
			return expressionTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeMessage;
			CheckBox checkBox = expressionTests;
			if (checkBox != null)
			{
				checkBox.Click -= value2;
			}
			expressionTests = value;
			checkBox = expressionTests;
			if (checkBox != null)
			{
				checkBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("File")]
	internal DarkToolStrip File
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal ToolStripButton Button_ReloadFormation
	{
		[CompilerGenerated]
		get
		{
			return m_ListenerTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchMessage;
			ToolStripButton listenerTests = m_ListenerTests;
			if (listenerTests != null)
			{
				listenerTests.Click -= value2;
			}
			m_ListenerTests = value;
			listenerTests = m_ListenerTests;
			if (listenerTests != null)
			{
				listenerTests.Click += value2;
			}
		}
	}

	internal ToolStripButton Button_EditFormation
	{
		[CompilerGenerated]
		get
		{
			return _ConfigTests;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableMessage;
			ToolStripButton configTests = _ConfigTests;
			if (configTests != null)
			{
				configTests.Click -= value2;
			}
			_ConfigTests = value;
			configTests = _ConfigTests;
			if (configTests != null)
			{
				configTests.Click += value2;
			}
		}
	}

	[SpecialName]
	[CompilerGenerated]
	internal Timer VisitMessage()
	{
		return m_StructTests;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal void RestartMessage(Timer timer_0)
	{
		EventHandler value = ExcludeMessage;
		Timer structTests = m_StructTests;
		if (structTests != null)
		{
			structTests.Tick -= value;
		}
		m_StructTests = timer_0;
		structTests = m_StructTests;
		if (structTests != null)
		{
			structTests.Tick += value;
		}
	}

	static FormationEditor()
	{
		m_WrapperTests = 0;
	}

	public FormationEditor()
	{
		base.FormClosing += RevertInterceptor;
		base.Load += CountMessage;
		base.KeyDown += LogoutMessage;
		base.FormClosed += ViewMessage;
		_RegistryTests = new DarkCheckBox();
		m_DefinitionTests = new Keys[2]
		{
			Keys.F4,
			Keys.Escape
		};
		valTests = new List<StandardFormation>();
		ManageInterceptor();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _AccountFilter != null)
			{
				_AccountFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ManageInterceptor()
	{
		_AccountFilter = new Container();
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(FormationEditor));
		ToolStrip1 = new DarkToolStrip();
		ToolStripButton1 = new ToolStripButton();
		TSB_SetStationRelative = new ToolStripButton();
		TSB_SetStationFixed = new ToolStripButton();
		CMenu_Unit = new DarkContextMenu();
		AssignToPatrol_TSMI = new DarkToolStripMenuItem();
		RemoveFromPatrol_TSMI = new DarkToolStripMenuItem();
		TV_Units = new DarkTreeView();
		label_Formation = new ToolStripLabel();
		RestartMessage(new Timer(_AccountFilter));
		ToolStrip2 = new DarkToolStrip();
		combo_Formations = new ToolStripComboBox();
		label_Spacing = new ToolStripLabel();
		combo_SpacingUnits = new ToolStripComboBox();
		label_Heading = new ToolStripLabel();
		button_SetFormation = new ToolStripButton();
		button_SetImmediate = new ToolStripButton();
		numeric_SpacingDistance = new NumericUpDown();
		numeric_Heading = new NumericUpDown();
		TS_RenderOptions = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		CB_MembersInheritIcon = new CheckBox();
		File = new DarkToolStrip();
		Button_ReloadFormation = new ToolStripButton();
		Button_EditFormation = new ToolStripButton();
		ToolStrip1.SuspendLayout();
		CMenu_Unit.SuspendLayout();
		ToolStrip2.SuspendLayout();
		((ISupportInitialize)numeric_SpacingDistance).BeginInit();
		((ISupportInitialize)numeric_Heading).BeginInit();
		TS_RenderOptions.SuspendLayout();
		File.SuspendLayout();
		SuspendLayout();
		ToolStrip1.AutoSize = false;
		ToolStrip1.BackColor = Color.FromArgb(43, 43, 43);
		ToolStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip1.ImageScalingSize = new Size(20, 20);
		ToolStrip1.Items.AddRange(new ToolStripItem[3] { ToolStripButton1, TSB_SetStationRelative, TSB_SetStationFixed });
		ToolStrip1.Location = new Point(0, 50);
		ToolStrip1.Name = "ToolStrip1";
		ToolStrip1.Padding = new Padding(5, 0, 1, 0);
		ToolStrip1.RenderMode = ToolStripRenderMode.Professional;
		ToolStrip1.Size = new Size(590, 25);
		ToolStrip1.TabIndex = 8;
		ToolStrip1.Text = "ToolStrip1";
		ToolStripButton1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripButton1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripButton1.Image = componentResourceManager.GetObject("ToolStripButton1.Image");
		ToolStripButton1.ImageTransparentColor = Color.Magenta;
		ToolStripButton1.Name = "ToolStripButton1";
		ToolStripButton1.Size = new Size(111, 22);
		ToolStripButton1.Text = "设为编队领队";
		TSB_SetStationRelative.BackColor = Color.FromArgb(60, 63, 65);
		TSB_SetStationRelative.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_SetStationRelative.Image = componentResourceManager.GetObject("TSB_SetStationRelative.Image");
		TSB_SetStationRelative.ImageTransparentColor = Color.Magenta;
		TSB_SetStationRelative.Name = "TSB_SetStationRelative";
		TSB_SetStationRelative.Size = new Size(178, 22);
		TSB_SetStationRelative.Text = "设置在编队中位置（相对）";
		TSB_SetStationFixed.BackColor = Color.FromArgb(60, 63, 65);
		TSB_SetStationFixed.ForeColor = Color.FromArgb(220, 220, 220);
		TSB_SetStationFixed.Image = componentResourceManager.GetObject("TSB_SetStationFixed.Image");
		TSB_SetStationFixed.ImageTransparentColor = Color.Magenta;
		TSB_SetStationFixed.Name = "TSB_SetStationFixed";
		TSB_SetStationFixed.Size = new Size(166, 22);
		TSB_SetStationFixed.Text = "设置在编队中位置（固定）";
		CMenu_Unit.BackColor = Color.FromArgb(60, 63, 65);
		CMenu_Unit.ForeColor = Color.FromArgb(220, 220, 220);
		CMenu_Unit.ImageScalingSize = new Size(20, 20);
		CMenu_Unit.Items.AddRange(new ToolStripItem[2] { AssignToPatrol_TSMI, RemoveFromPatrol_TSMI });
		CMenu_Unit.Name = "CMenu_ThreatAxis";
		CMenu_Unit.Size = new Size(181, 48);
		AssignToPatrol_TSMI.BackColor = Color.FromArgb(60, 63, 65);
		AssignToPatrol_TSMI.ForeColor = Color.FromArgb(220, 220, 220);
		AssignToPatrol_TSMI.Name = "AssignToPatrol_TSMI";
		AssignToPatrol_TSMI.Size = new Size(180, 22);
		AssignToPatrol_TSMI.Text = "分配给巡逻任务...";
		RemoveFromPatrol_TSMI.BackColor = Color.FromArgb(60, 63, 65);
		RemoveFromPatrol_TSMI.ForeColor = Color.FromArgb(220, 220, 220);
		RemoveFromPatrol_TSMI.Name = "RemoveFromPatrol_TSMI";
		RemoveFromPatrol_TSMI.Size = new Size(180, 22);
		RemoveFromPatrol_TSMI.Text = "从巡逻任务中删除";
		TV_Units.AllowDrop = true;
		TV_Units.Dock = DockStyle.Fill;
		TV_Units.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		TV_Units.Location = new Point(0, 100);
		TV_Units.MaxDragChange = 20;
		TV_Units.Name = "TV_Units";
		TV_Units.Size = new Size(590, 358);
		TV_Units.TabIndex = 12;
		label_Formation.BackColor = Color.FromArgb(60, 63, 65);
		label_Formation.ForeColor = Color.FromArgb(220, 220, 220);
		label_Formation.Name = "label_Formation";
		label_Formation.Size = new Size(65, 22);
		label_Formation.Text = "Formation:";
		VisitMessage().Interval = 1000;
		ToolStrip2.AutoSize = false;
		ToolStrip2.BackColor = Color.FromArgb(60, 63, 65);
		ToolStrip2.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStrip2.GripStyle = ToolStripGripStyle.Hidden;
		ToolStrip2.ImageScalingSize = new Size(20, 20);
		ToolStrip2.Items.AddRange(new ToolStripItem[9]
		{
			label_Formation,
			combo_Formations,
			label_Spacing,
			new ToolStripControlHost(numeric_SpacingDistance),
			combo_SpacingUnits,
			label_Heading,
			new ToolStripControlHost(numeric_Heading),
			button_SetFormation,
			button_SetImmediate
		});
		ToolStrip2.Location = new Point(0, 25);
		ToolStrip2.Name = "ToolStrip2";
		ToolStrip2.Padding = new Padding(5, 0, 1, 0);
		ToolStrip2.RenderMode = ToolStripRenderMode.Professional;
		ToolStrip2.Size = new Size(590, 25);
		ToolStrip2.TabIndex = 8;
		combo_Formations.BackColor = Color.FromArgb(60, 63, 65);
		combo_Formations.ForeColor = Color.FromArgb(220, 220, 220);
		combo_Formations.Name = "combo_Formations";
		combo_Formations.Size = new Size(75, 25);
		label_Spacing.BackColor = Color.FromArgb(60, 63, 65);
		label_Spacing.ForeColor = Color.FromArgb(220, 220, 220);
		label_Spacing.Name = "label_Spacing";
		label_Spacing.Size = new Size(52, 22);
		label_Spacing.Text = "Spacing:";
		combo_SpacingUnits.BackColor = Color.FromArgb(60, 63, 65);
		combo_SpacingUnits.ForeColor = Color.FromArgb(220, 220, 220);
		combo_SpacingUnits.Name = "combo_SpacingUnits";
		combo_SpacingUnits.Size = new Size(75, 25);
		label_Heading.BackColor = Color.FromArgb(60, 63, 65);
		label_Heading.ForeColor = Color.FromArgb(220, 220, 220);
		label_Heading.Name = "label_Heading";
		label_Heading.Size = new Size(55, 22);
		label_Heading.Text = "Heading:";
		label_Heading.TextAlign = ContentAlignment.MiddleRight;
		button_SetFormation.BackColor = Color.FromArgb(60, 63, 65);
		button_SetFormation.ForeColor = Color.FromArgb(220, 220, 220);
		button_SetFormation.Name = "button_SetFormation";
		button_SetFormation.Size = new Size(46, 22);
		button_SetFormation.Text = "Assign";
		button_SetImmediate.BackColor = Color.FromArgb(60, 63, 65);
		button_SetImmediate.ForeColor = Color.FromArgb(220, 220, 220);
		button_SetImmediate.Name = "button_SetImmediate";
		button_SetImmediate.Size = new Size(39, 22);
		button_SetImmediate.Text = "Place";
		numeric_SpacingDistance.BackColor = Color.FromArgb(60, 63, 65);
		numeric_SpacingDistance.ForeColor = Color.FromArgb(220, 220, 220);
		numeric_SpacingDistance.Location = new Point(199, 1);
		numeric_SpacingDistance.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		numeric_SpacingDistance.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		numeric_SpacingDistance.Name = "numeric_SpacingDistance";
		numeric_SpacingDistance.Size = new Size(53, 20);
		numeric_SpacingDistance.TabIndex = 0;
		numeric_SpacingDistance.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		numeric_Heading.BackColor = Color.FromArgb(60, 63, 65);
		numeric_Heading.ForeColor = Color.FromArgb(220, 220, 220);
		numeric_Heading.Location = new Point(384, 1);
		numeric_Heading.Maximum = new decimal(new int[4] { 359, 0, 0, 0 });
		numeric_Heading.Name = "numeric_Heading";
		numeric_Heading.Size = new Size(41, 20);
		numeric_Heading.TabIndex = 6;
		TS_RenderOptions.AutoSize = false;
		TS_RenderOptions.BackColor = Color.FromArgb(60, 63, 65);
		TS_RenderOptions.ForeColor = Color.FromArgb(220, 220, 220);
		TS_RenderOptions.GripStyle = ToolStripGripStyle.Hidden;
		TS_RenderOptions.ImageScalingSize = new Size(20, 20);
		TS_RenderOptions.Items.AddRange(new ToolStripItem[1] { ToolStripLabel1 });
		TS_RenderOptions.Location = new Point(0, 75);
		TS_RenderOptions.Name = "TS_RenderOptions";
		TS_RenderOptions.Padding = new Padding(5, 0, 1, 0);
		TS_RenderOptions.RenderMode = ToolStripRenderMode.Professional;
		TS_RenderOptions.Size = new Size(590, 25);
		TS_RenderOptions.TabIndex = 13;
		ToolStripLabel1.BackColor = Color.FromArgb(60, 63, 65);
		ToolStripLabel1.ForeColor = Color.FromArgb(220, 220, 220);
		ToolStripLabel1.Name = "ToolStripLabel1";
		ToolStripLabel1.Size = new Size(205, 22);
		ToolStripLabel1.Text = "Group members inherit leader's icon :";
		CB_MembersInheritIcon.AutoSize = true;
		CB_MembersInheritIcon.Location = new Point(212, 80);
		CB_MembersInheritIcon.Name = "CB_MembersInheritIcon";
		CB_MembersInheritIcon.Size = new Size(15, 14);
		CB_MembersInheritIcon.TabIndex = 14;
		CB_MembersInheritIcon.UseVisualStyleBackColor = true;
		File.AutoSize = false;
		File.BackColor = Color.FromArgb(60, 63, 65);
		File.ForeColor = Color.FromArgb(220, 220, 220);
		File.GripStyle = ToolStripGripStyle.Hidden;
		File.ImageScalingSize = new Size(20, 20);
		File.Items.AddRange(new ToolStripItem[2] { Button_ReloadFormation, Button_EditFormation });
		File.Location = new Point(0, 0);
		File.Name = "File";
		File.Padding = new Padding(5, 0, 1, 0);
		File.RenderMode = ToolStripRenderMode.Professional;
		File.Size = new Size(590, 25);
		File.TabIndex = 15;
		Button_ReloadFormation.BackColor = Color.FromArgb(60, 63, 65);
		Button_ReloadFormation.ForeColor = Color.FromArgb(220, 220, 220);
		Button_ReloadFormation.Name = "Button_ReloadFormation";
		Button_ReloadFormation.Size = new Size(134, 22);
		Button_ReloadFormation.Text = "Reload formation types";
		Button_EditFormation.BackColor = Color.FromArgb(60, 63, 65);
		Button_EditFormation.ForeColor = Color.FromArgb(220, 220, 220);
		Button_EditFormation.Name = "Button_EditFormation";
		Button_EditFormation.Size = new Size(118, 22);
		Button_EditFormation.Text = "Edit formation types";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(590, 458);
		base.Controls.Add(TV_Units);
		base.Controls.Add(CB_MembersInheritIcon);
		base.Controls.Add(TS_RenderOptions);
		base.Controls.Add(ToolStrip1);
		base.Controls.Add(ToolStrip2);
		base.Controls.Add(File);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FormationEditor";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编队编辑";
		ToolStrip1.ResumeLayout(performLayout: false);
		ToolStrip1.PerformLayout();
		CMenu_Unit.ResumeLayout(performLayout: false);
		ToolStrip2.ResumeLayout(performLayout: false);
		ToolStrip2.PerformLayout();
		((ISupportInitialize)numeric_SpacingDistance).EndInit();
		((ISupportInitialize)numeric_Heading).EndInit();
		TS_RenderOptions.ResumeLayout(performLayout: false);
		TS_RenderOptions.PerformLayout();
		File.ResumeLayout(performLayout: false);
		File.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public void ReleaseReferences()
	{
		try
		{
			if (base.Visible)
			{
				Close();
			}
			SelectedGroup = null;
			SelectedPatrol = null;
			TV_Units.Nodes.Clear();
			AssignToPatrol_TSMI.DropDownItems.Clear();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void LoadStandardFormations()
	{
		valTests.Clear();
		string text = Path.Combine(GameGeneral.ResourcesFolderPath, "Formation\\StandardFormations.txt");
		List<string> list = new List<string>();
		if (!FileExistsNative.FileExistsFast(text))
		{
			return;
		}
		try
		{
			StreamReader streamReader = new StreamReader(new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
			while (!streamReader.EndOfStream)
			{
				list.Add(streamReader.ReadLine());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error loading group formation data", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
			return;
		}
		if (list.Count <= 1 || !int.TryParse(list[0], out var result))
		{
			return;
		}
		int num = result;
		for (int i = 1; i <= num; i++)
		{
			StandardFormation standardFormation = new StandardFormation();
			if (standardFormation.NewSpecification(list[i]))
			{
				valTests.Add(standardFormation);
			}
		}
	}

	public void InitStandardFormationsUI()
	{
		combo_SpacingUnits.Items.Clear();
		combo_SpacingUnits.Items.Add("m");
		combo_SpacingUnits.Items.Add("nm");
		combo_Formations.Items.Clear();
		combo_Formations.Items.Add("(None)");
		foreach (StandardFormation valTest in valTests)
		{
			combo_Formations.Items.Add(valTest.Name);
		}
		m_WrapperTests = 0;
		if (valTests.Count == 0)
		{
			combo_Formations.Enabled = false;
			combo_SpacingUnits.Enabled = false;
			numeric_SpacingDistance.Enabled = false;
			numeric_Heading.Enabled = false;
			button_SetFormation.Enabled = false;
			button_SetImmediate.Enabled = false;
			Text += " - No defaults";
			return;
		}
		combo_Formations.SelectedIndex = m_WrapperTests;
		combo_SpacingUnits.SelectedIndex = m_IssuerTests;
		numeric_SpacingDistance.Value = new decimal(Math.Max(1, observerTests));
		if (SelectedGroup.DesiredHeading <= 359f)
		{
			numeric_Heading.Value = new decimal((int)Math.Round(SelectedGroup.DesiredHeading));
		}
		else
		{
			numeric_Heading.Value = 0m;
		}
		button_SetFormation.Enabled = m_WrapperTests > 0;
		button_SetImmediate.Enabled = button_SetFormation.Enabled;
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		Keys[] definitionTests = m_DefinitionTests;
		int num = 0;
		while (true)
		{
			if (num < definitionTests.Length)
			{
				Keys keys = definitionTests[num];
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

	public void BuildForm()
	{
		SuspendLayout();
		InitStandardFormationsUI();
		if (valTests.Count == 0)
		{
			combo_Formations.Enabled = false;
			combo_SpacingUnits.Enabled = false;
			numeric_SpacingDistance.Enabled = false;
			numeric_Heading.Enabled = false;
			button_SetFormation.Enabled = false;
			button_SetImmediate.Enabled = false;
			Text += " - No defaults";
		}
		else
		{
			combo_Formations.SelectedIndex = m_WrapperTests;
			combo_SpacingUnits.SelectedIndex = m_IssuerTests;
			numeric_SpacingDistance.Value = new decimal(Math.Max(1, observerTests));
			if (SelectedGroup.DesiredHeading <= 359f)
			{
				numeric_Heading.Value = new decimal((int)Math.Round(SelectedGroup.DesiredHeading));
			}
			else
			{
				numeric_Heading.Value = 0m;
			}
			button_SetFormation.Enabled = m_WrapperTests > 0;
			button_SetImmediate.Enabled = button_SetFormation.Enabled;
		}
		button_SetImmediate.Visible = Client.CurrentGame.IsScenEditGameMode;
		CB_MembersInheritIcon.Checked = SelectedGroup.MembersInheritIcon;
		TV_Units.Nodes.Clear();
		foreach (ActiveUnit value in SelectedGroup.Units.Values)
		{
			string text = value.Name;
			if (value.IsGroupLead())
			{
				text = "[领队]" + text;
			}
			string text2;
			if (value.IsAircraft)
			{
				Aircraft aircraft = (Aircraft)value;
				text2 = (Information.IsNothing(aircraft.Loadout) ? "" : (" (" + aircraft.Loadout.Name + ")"));
			}
			else
			{
				text2 = "";
			}
			string text3 = (string.IsNullOrEmpty(value.UnitClass) ? "" : (" (" + Misc.ReadRequest(value.UnitClass) + ")"));
			DarkTreeNode darkTreeNode = new DarkTreeNode(text + text3 + text2);
			TV_Units.Nodes.Add(darkTreeNode);
			darkTreeNode.Tag = value;
		}
		InterpreterObjectListener.PostInterruptibleTask(TV_Units);
		if (string.IsNullOrEmpty(SelectedGroup.LastFormationSet))
		{
			if (combo_Formations.Items.Count > 0)
			{
				combo_Formations.SelectedIndex = 0;
				numeric_SpacingDistance.Value = 1m;
				combo_SpacingUnits.SelectedIndex = 1;
			}
		}
		else
		{
			int num = combo_Formations.FindString(SelectedGroup.LastFormationSet);
			if (num >= 0)
			{
				combo_Formations.SelectedIndex = num;
				numeric_SpacingDistance.Value = new decimal(SelectedGroup.LastFormationSpacing);
				combo_SpacingUnits.SelectedIndex = SelectedGroup.LastFormationSpacingUnits;
			}
		}
		ResumeLayout();
	}

	private void RevertInterceptor(object sender, FormClosingEventArgs e)
	{
		VisitMessage().Stop();
		Client.CurrentMapProfile.ViewMode = MapProfile.MapViewMode.GroupView;
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void CountMessage(object sender, EventArgs e)
	{
		Text = "编队编辑 - " + SelectedGroup.Name;
		_RegistryTests.Text = "高速低速交替航行";
		_RegistryTests.Click += MoveMessage;
		ToolStripControlHost value = new ToolStripControlHost(_RegistryTests);
		ToolStrip1.Items.Add(value);
		Client.SelectedUnitChanged += CustomizeMessage;
		Group.UnitAdded += CloneMessage;
		Group.UnitRemoved += ConnectMessage;
		LoadStandardFormations();
		BuildForm();
		VisitMessage().Start();
	}

	private void CustomizeMessage(Module_Unit.Unit unit_0)
	{
		foreach (DarkTreeNode item in InterpreterObjectListener.PrintInterruptibleTask(TV_Units))
		{
			if (item.Tag != null && item.Tag == unit_0)
			{
				TV_Units.SelectNode(item);
				if (((ActiveUnit)unit_0).IsGroupLead())
				{
					_RegistryTests.Enabled = false;
					ToolStripButton1.Enabled = false;
					TSB_SetStationFixed.Enabled = false;
					TSB_SetStationRelative.Enabled = false;
				}
				else
				{
					_RegistryTests.Enabled = unit_0.IsBoat;
					ToolStripButton1.Enabled = true;
					TSB_SetStationFixed.Enabled = true;
					TSB_SetStationRelative.Enabled = true;
				}
				_RegistryTests.Checked = ((ActiveUnit)unit_0).Navigator.SprintDrift;
				if (base.Visible)
				{
					Focus();
				}
				break;
			}
		}
	}

	private void CloneMessage(Group group_0, ActiveUnit activeUnit_0)
	{
		if (group_0 == SelectedGroup)
		{
			BuildForm();
		}
	}

	private void ConnectMessage(Group group_0, ActiveUnit activeUnit_0)
	{
		if (group_0 == SelectedGroup)
		{
			BuildForm();
		}
	}

	private void MoveMessage(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count == 0 || TV_Units.SelectedNodes[0].Tag == null)
		{
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
		if ((object)objectValue.GetType().BaseType == typeof(Platform))
		{
			ActiveUnit activeUnit = (ActiveUnit)objectValue;
			if (!activeUnit.IsGroupLead())
			{
				activeUnit.Navigator.SprintDrift = _RegistryTests.Checked;
			}
		}
	}

	private void DeleteMessage(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count != 0 && !Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag)))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
			if ((object)objectValue.GetType().BaseType == typeof(Platform))
			{
				ActiveUnit groupLead = (ActiveUnit)objectValue;
				SelectedGroup.SetGroupLead(groupLead);
				BuildForm();
				Client.MustRefreshMainForm = true;
			}
		}
	}

	private bool AddMessage(TreeNode treeNode_0, TreeNode treeNode_1)
	{
		if (treeNode_1.Parent == null)
		{
			return false;
		}
		if (treeNode_1.Parent.Equals(treeNode_0))
		{
			return true;
		}
		return AddMessage(treeNode_0, treeNode_1.Parent);
	}

	private void DestroyMessage(ActiveUnit activeUnit_0)
	{
		if (Information.IsNothing(activeUnit_0.AssignedMissionOrPackage()))
		{
			RemoveFromPatrol_TSMI.Enabled = false;
		}
		else
		{
			RemoveFromPatrol_TSMI.Enabled = activeUnit_0.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol;
		}
		AssignToPatrol_TSMI.DropDownItems.Clear();
		foreach (Patrol patrol in SelectedGroup.Patrols)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(patrol.Name);
			toolStripMenuItem.Tag = patrol;
			toolStripMenuItem.MouseDown += ComputeMessage;
			AssignToPatrol_TSMI.DropDownItems.Add(toolStripMenuItem);
		}
	}

	private void ComputeMessage(object sender, EventArgs e)
	{
		ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
		if (Information.IsNothing(RuntimeHelpers.GetObjectValue(toolStripMenuItem.Tag)) || (object)toolStripMenuItem.Tag.GetType() != typeof(Patrol))
		{
			return;
		}
		foreach (Patrol patrol in SelectedGroup.Patrols)
		{
			if (Operators.CompareString(patrol.Name, toolStripMenuItem.Text, TextCompare: true) == 0)
			{
				ActiveUnit obj = (ActiveUnit)Client.SelectedUnit;
				Mission.MissionAssignmentAttemptResult missionAssignmentAttemptResult_ = Mission.MissionAssignmentAttemptResult.None;
				obj.Set_AssignedMissionOrPackage(patrol, bool_0: false, bool_1: false, ref missionAssignmentAttemptResult_);
				BuildForm();
				break;
			}
		}
	}

	private void PatchMessage(object sender, MouseEventArgs e)
	{
		if (TV_Units.SelectedNodes.Count == 0)
		{
			return;
		}
		DarkTreeNode darkTreeNode = TV_Units.SelectedNodes[0];
		if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(darkTreeNode.Tag)) && (object)darkTreeNode.Tag.GetType().BaseType.BaseType == typeof(ActiveUnit))
		{
			Client.SelectThisUnit((Module_Unit.Unit)darkTreeNode.Tag, bool_0: true);
			if (e.Button == MouseButtons.Right)
			{
				DestroyMessage((ActiveUnit)darkTreeNode.Tag);
				CMenu_Unit.Show(TV_Units, e.X, e.Y);
			}
		}
	}

	private void SelectMessage(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count != 0 && !Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag)))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
			if ((object)objectValue.GetType().BaseType == typeof(Platform) && !((ActiveUnit)objectValue).IsGroupLead())
			{
				Client.m_AccountClass = ReferencePoint.OrientationType.Rotating;
				Client.CurrentUserAction = Client.UserAction.AddingFormationStation;
			}
		}
	}

	private void CallMessage(object sender, EventArgs e)
	{
		if (TV_Units.SelectedNodes.Count != 0 && !Information.IsNothing(RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag)))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(TV_Units.SelectedNodes[0].Tag);
			if ((object)objectValue.GetType().BaseType == typeof(Platform) && !((ActiveUnit)objectValue).IsGroupLead())
			{
				Client.m_AccountClass = ReferencePoint.OrientationType.Fixed;
				Client.CurrentUserAction = Client.UserAction.AddingFormationStation;
			}
		}
	}

	private void LogoutMessage(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		if (e.KeyCode == Keys.F4 && base.Visible)
		{
			Close();
		}
	}

	private void ViewMessage(object sender, FormClosedEventArgs e)
	{
		_RegistryTests.Click -= MoveMessage;
		Client.SelectedUnitChanged -= CustomizeMessage;
		Group.UnitAdded -= CloneMessage;
		Group.UnitRemoved -= ConnectMessage;
		IEnumerator enumerator = null;
		try
		{
			enumerator = AssignToPatrol_TSMI.DropDownItems.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((ToolStripMenuItem)enumerator.Current).MouseDown -= ComputeMessage;
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

	private void ValidateMessage(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			m_WrapperTests = combo_Formations.SelectedIndex;
		}
		button_SetFormation.Enabled = m_WrapperTests > 0;
		button_SetImmediate.Enabled = button_SetFormation.Enabled;
		button_SetImmediate.Visible = Client.CurrentGame.IsScenEditGameMode;
	}

	private void LoginMessage(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			m_IssuerTests = combo_SpacingUnits.SelectedIndex;
		}
	}

	private void GetMessage(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			observerTests = Convert.ToInt32(numeric_SpacingDistance.Value);
		}
	}

	private void WriteMessage(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			observerTests = Convert.ToInt32(numeric_SpacingDistance.Value);
		}
	}

	private void NewMessage(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			_ClientTests = Convert.ToInt32(numeric_Heading.Value);
		}
	}

	private void PushMessage(object sender, EventArgs e)
	{
		if (base.Visible)
		{
			_ClientTests = Convert.ToInt32(numeric_Heading.Value);
		}
	}

	private void InvokeMessage(object sender, EventArgs e)
	{
		if (SelectedGroup != null && SelectedGroup.GroupLead != null && combo_Formations.SelectedIndex > 0)
		{
			float float_ = Convert.ToSingle(numeric_SpacingDistance.Value);
			float float_2 = Convert.ToSingle(numeric_Heading.Value);
			string string_ = combo_Formations.SelectedItem.ToString();
			StandardFormation.SetFormation(SelectedGroup, string_, float_2, float_, combo_SpacingUnits.SelectedIndex, bool_0: false);
		}
	}

	private void SetupMessage(object sender, EventArgs e)
	{
		if (SelectedGroup != null && SelectedGroup.GroupLead != null)
		{
			if (combo_Formations.SelectedIndex > 0)
			{
				float float_ = Convert.ToSingle(numeric_SpacingDistance.Value);
				float float_2 = Convert.ToSingle(numeric_Heading.Value);
				string string_ = combo_Formations.SelectedItem.ToString();
				StandardFormation.SetFormation(SelectedGroup, string_, float_2, float_, combo_SpacingUnits.SelectedIndex, bool_0: true);
			}
			ItemExporter.ConnectInterruptibleTemplate.MainForm.AdjustToUserActionChange();
		}
	}

	private void ExcludeMessage(object sender, EventArgs e)
	{
		try
		{
			if (Client.CurrentGame.Status == Game._GameStatus.Running && !numeric_Heading.Focused && ((SelectedGroup != null) & (SelectedGroup.GroupLead != null)))
			{
				if (SelectedGroup.GroupLead.DesiredHeading <= 359f)
				{
					numeric_Heading.Value = new decimal((int)Math.Round(SelectedGroup.GroupLead.DesiredHeading));
				}
				else
				{
					numeric_Heading.Value = 0m;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 9346354850", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
		}
	}

	private void IncludeMessage(object sender, EventArgs e)
	{
		SelectedGroup.MembersInheritIcon = CB_MembersInheritIcon.Checked;
	}

	private void SearchMessage(object sender, EventArgs e)
	{
		LoadStandardFormations();
		BuildForm();
	}

	private void EnableMessage(object sender, EventArgs e)
	{
		string text = Path.Combine(GameGeneral.ResourcesFolderPath, "Formation\\StandardFormations.txt");
		try
		{
			if (FileExistsNative.FileExistsFast(text))
			{
				Process.Start(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error while accessing StandardFormations.txt", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			ProjectData.ClearProjectError();
		}
	}
}
