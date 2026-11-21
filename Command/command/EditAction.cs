using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using DarkUI.Forms;
using MSDN.Html.Editor;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditAction : DarkSecondaryFormBase
{
	public delegate void EventActionsChangedEventHandler(Scenario theScen);

	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer _QueueSpecification;

	[AccessedThroughProperty("TextBox1")]
	[CompilerGenerated]
	private DarkUITextBox regSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private DarkLabel paramSpecification;

	[AccessedThroughProperty("TC_ActionOptions")]
	[CompilerGenerated]
	private DarkUITabControl pageSpecification;

	[AccessedThroughProperty("TabPage1")]
	[CompilerGenerated]
	private TabPage m_RulesSpecification;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private DarkLabel methodSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton m_ServiceSpecification;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton m_SystemSpecification;

	[AccessedThroughProperty("Label5")]
	[CompilerGenerated]
	private DarkLabel candidateSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_Points")]
	private DarkNumericUpDown m_BaseSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_Points_Sides")]
	private DarkUIComboBox policySpecification;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	private DarkLabel broadcasterSpecification;

	[AccessedThroughProperty("ListBox_UnitsToTeleport")]
	[CompilerGenerated]
	private DarkListView algoSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Label6")]
	private DarkLabel databaseSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("AreaEditor1")]
	private AreaEditor interceptorSpecification;

	[AccessedThroughProperty("CB_Message_Side")]
	[CompilerGenerated]
	private DarkUIComboBox productSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Label8")]
	private DarkLabel m_AnnotationSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage5")]
	private TabPage m_InitializerSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Label11")]
	private DarkLabel roleSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_MissionStatus_Mission")]
	private DarkUIComboBox factorySpecification;

	[AccessedThroughProperty("CB_MissionStatus_Side")]
	[CompilerGenerated]
	private DarkUIComboBox m_AttributeSpecification;

	[AccessedThroughProperty("Label10")]
	[CompilerGenerated]
	private DarkLabel m_GlobalSpecification;

	[AccessedThroughProperty("CB_MissionStatus_Status")]
	[CompilerGenerated]
	private DarkUIComboBox m_WorkerSpecification;

	[AccessedThroughProperty("TabPage6")]
	[CompilerGenerated]
	private TabPage m_StateSpecification;

	[AccessedThroughProperty("Button_AddLuaScript")]
	[CompilerGenerated]
	private DarkUIButton _AuthenticationSpecification;

	[AccessedThroughProperty("CB_LuaTemplate")]
	[CompilerGenerated]
	private DarkUIComboBox m_ParamsSpecification;

	[AccessedThroughProperty("NUD_LuaScript")]
	[CompilerGenerated]
	private GControl1 mapperSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Label13")]
	private DarkLabel m_ManagerSpecification;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton m_GetterSpecification;

	public EventAction theEA;

	public _FormAction Action;

	[CompilerGenerated]
	private static EventActionsChangedEventHandler m_ProducerSpecification;

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return regSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = CustomizeMap;
			DarkUITextBox darkUITextBox = regSpecification;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			regSpecification = value;
			darkUITextBox = regSpecification;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	internal DarkLabel Label2
	{
		[CompilerGenerated]
		get
		{
			return paramSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramSpecification = value;
		}
	}

	internal DarkUITabControl TC_ActionOptions
	{
		[CompilerGenerated]
		get
		{
			return pageSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pageSpecification = value;
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return m_RulesSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RulesSpecification = value;
		}
	}

	internal DarkLabel Label3
	{
		[CompilerGenerated]
		get
		{
			return methodSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodSpecification = value;
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResetCreator;
			DarkUIButton serviceSpecification = m_ServiceSpecification;
			if (serviceSpecification != null)
			{
				serviceSpecification.Click -= value2;
			}
			m_ServiceSpecification = value;
			serviceSpecification = m_ServiceSpecification;
			if (serviceSpecification != null)
			{
				serviceSpecification.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return m_SystemSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MapCreator;
			DarkUIButton systemSpecification = m_SystemSpecification;
			if (systemSpecification != null)
			{
				systemSpecification.Click -= value2;
			}
			m_SystemSpecification = value;
			systemSpecification = m_SystemSpecification;
			if (systemSpecification != null)
			{
				systemSpecification.Click += value2;
			}
		}
	}

	internal DarkLabel Label5
	{
		[CompilerGenerated]
		get
		{
			return candidateSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			candidateSpecification = value;
		}
	}

	internal DarkNumericUpDown NUD_Points
	{
		[CompilerGenerated]
		get
		{
			return m_BaseSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CalcCreator;
			DarkNumericUpDown baseSpecification = m_BaseSpecification;
			if (baseSpecification != null)
			{
				baseSpecification.TextChanged -= value2;
			}
			m_BaseSpecification = value;
			baseSpecification = m_BaseSpecification;
			if (baseSpecification != null)
			{
				baseSpecification.TextChanged += value2;
			}
		}
	}

	internal DarkUIComboBox CB_Points_Sides
	{
		[CompilerGenerated]
		get
		{
			return policySpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SortCreator;
			DarkUIComboBox darkUIComboBox = policySpecification;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			policySpecification = value;
			darkUIComboBox = policySpecification;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label4
	{
		[CompilerGenerated]
		get
		{
			return broadcasterSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			broadcasterSpecification = value;
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal DarkLabel Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage2")]
	internal TabPage TabPage2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal TabPage TabPage3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkListView ListBox_UnitsToTeleport
	{
		[CompilerGenerated]
		get
		{
			return algoSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			algoSpecification = value;
		}
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return databaseSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			databaseSpecification = value;
		}
	}

	internal AreaEditor AreaEditor1
	{
		[CompilerGenerated]
		get
		{
			return interceptorSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interceptorSpecification = value;
		}
	}

	[field: AccessedThroughProperty("TabPage4")]
	internal TabPage TabPage4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_Message_Side
	{
		[CompilerGenerated]
		get
		{
			return productSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RateCreator;
			DarkUIComboBox darkUIComboBox = productSpecification;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			productSpecification = value;
			darkUIComboBox = productSpecification;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationSpecification = value;
		}
	}

	[field: AccessedThroughProperty("Label9")]
	internal DarkLabel Label9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage5
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InitializerSpecification = value;
		}
	}

	internal DarkLabel Label11
	{
		[CompilerGenerated]
		get
		{
			return roleSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			roleSpecification = value;
		}
	}

	internal DarkUIComboBox CB_MissionStatus_Mission
	{
		[CompilerGenerated]
		get
		{
			return factorySpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CollectCreator;
			DarkUIComboBox darkUIComboBox = factorySpecification;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			factorySpecification = value;
			darkUIComboBox = factorySpecification;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkUIComboBox CB_MissionStatus_Side
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ForgotCreator;
			DarkUIComboBox attributeSpecification = m_AttributeSpecification;
			if (attributeSpecification != null)
			{
				attributeSpecification.SelectionChangeCommitted -= value2;
			}
			m_AttributeSpecification = value;
			attributeSpecification = m_AttributeSpecification;
			if (attributeSpecification != null)
			{
				attributeSpecification.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal DarkLabel Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkLabel Label10
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalSpecification = value;
		}
	}

	internal DarkUIComboBox CB_MissionStatus_Status
	{
		[CompilerGenerated]
		get
		{
			return m_WorkerSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderCreator;
			DarkUIComboBox workerSpecification = m_WorkerSpecification;
			if (workerSpecification != null)
			{
				workerSpecification.SelectionChangeCommitted -= value2;
			}
			m_WorkerSpecification = value;
			workerSpecification = m_WorkerSpecification;
			if (workerSpecification != null)
			{
				workerSpecification.SelectionChangeCommitted += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Editor_Message_Text")]
	private HtmlEditorControl Editor_Message_Text
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TabPage TabPage6
	{
		[CompilerGenerated]
		get
		{
			return m_StateSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StateSpecification = value;
		}
	}

	internal DarkUIButton Button_AddLuaScript
	{
		[CompilerGenerated]
		get
		{
			return _AuthenticationSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageCreator;
			DarkUIButton authenticationSpecification = _AuthenticationSpecification;
			if (authenticationSpecification != null)
			{
				authenticationSpecification.Click -= value2;
			}
			_AuthenticationSpecification = value;
			authenticationSpecification = _AuthenticationSpecification;
			if (authenticationSpecification != null)
			{
				authenticationSpecification.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_LuaTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_ParamsSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParamsSpecification = value;
		}
	}

	[field: AccessedThroughProperty("Label12")]
	internal DarkLabel Label12
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextBox2")]
	internal DarkTextBox TextBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GControl1 NUD_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return mapperSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertCreator;
			EventHandler value3 = CloneMap;
			GControl1 gControl = mapperSpecification;
			if (gControl != null)
			{
				gControl.TextChanged -= value2;
				gControl.Click -= value3;
			}
			mapperSpecification = value;
			gControl = mapperSpecification;
			if (gControl != null)
			{
				gControl.TextChanged += value2;
				gControl.Click += value3;
			}
		}
	}

	internal DarkLabel Label13
	{
		[CompilerGenerated]
		get
		{
			return m_ManagerSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ManagerSpecification = value;
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return m_GetterSpecification;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountMap;
			DarkUIButton getterSpecification = m_GetterSpecification;
			if (getterSpecification != null)
			{
				getterSpecification.Click -= value2;
			}
			m_GetterSpecification = value;
			getterSpecification = m_GetterSpecification;
			if (getterSpecification != null)
			{
				getterSpecification.Click += value2;
			}
		}
	}

	public static event EventActionsChangedEventHandler EventActionsChanged
	{
		[CompilerGenerated]
		add
		{
			EventActionsChangedEventHandler eventActionsChangedEventHandler = m_ProducerSpecification;
			EventActionsChangedEventHandler eventActionsChangedEventHandler2;
			do
			{
				eventActionsChangedEventHandler2 = eventActionsChangedEventHandler;
				EventActionsChangedEventHandler value2 = (EventActionsChangedEventHandler)Delegate.Combine(eventActionsChangedEventHandler2, value);
				eventActionsChangedEventHandler = Interlocked.CompareExchange(ref m_ProducerSpecification, value2, eventActionsChangedEventHandler2);
			}
			while ((object)eventActionsChangedEventHandler != eventActionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventActionsChangedEventHandler eventActionsChangedEventHandler = m_ProducerSpecification;
			EventActionsChangedEventHandler eventActionsChangedEventHandler2;
			do
			{
				eventActionsChangedEventHandler2 = eventActionsChangedEventHandler;
				EventActionsChangedEventHandler value2 = (EventActionsChangedEventHandler)Delegate.Remove(eventActionsChangedEventHandler2, value);
				eventActionsChangedEventHandler = Interlocked.CompareExchange(ref m_ProducerSpecification, value2, eventActionsChangedEventHandler2);
			}
			while ((object)eventActionsChangedEventHandler != eventActionsChangedEventHandler2);
		}
	}

	public EditAction()
	{
		base.FormClosing += AwakeCreator;
		base.Load += QueryCreator;
		base.KeyDown += RegisterCreator;
		PublishCreator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _QueueSpecification != null)
			{
				_QueueSpecification.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void PublishCreator()
	{
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		TC_ActionOptions = new DarkUITabControl();
		TabPage1 = new TabPage();
		Label5 = new DarkLabel();
		NUD_Points = new DarkNumericUpDown();
		CB_Points_Sides = new DarkUIComboBox();
		Label4 = new DarkLabel();
		Label1 = new DarkLabel();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		AreaEditor1 = new AreaEditor();
		ListBox_UnitsToTeleport = new DarkListView();
		Label6 = new DarkLabel();
		TabPage4 = new TabPage();
		Button3 = new DarkUIButton();
		Editor_Message_Text = new HtmlEditorControl();
		CB_Message_Side = new DarkUIComboBox();
		Label8 = new DarkLabel();
		Label9 = new DarkLabel();
		TabPage5 = new TabPage();
		CB_MissionStatus_Status = new DarkUIComboBox();
		Label11 = new DarkLabel();
		CB_MissionStatus_Mission = new DarkUIComboBox();
		CB_MissionStatus_Side = new DarkUIComboBox();
		Label7 = new DarkLabel();
		Label10 = new DarkLabel();
		TabPage6 = new TabPage();
		NUD_LuaScript = new GControl1();
		Label13 = new DarkLabel();
		Button_AddLuaScript = new DarkUIButton();
		CB_LuaTemplate = new DarkUIComboBox();
		Label12 = new DarkLabel();
		TextBox2 = new DarkTextBox();
		Label3 = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		TC_ActionOptions.SuspendLayout();
		TabPage1.SuspendLayout();
		((ISupportInitialize)NUD_Points).BeginInit();
		TabPage3.SuspendLayout();
		TabPage4.SuspendLayout();
		TabPage5.SuspendLayout();
		TabPage6.SuspendLayout();
		SuspendLayout();
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = AutoCompleteMode.None;
		TextBox1.AutoCompleteSource = AutoCompleteSource.None;
		TextBox1.BackColor = Color.FromArgb(69, 73, 74);
		TextBox1.Font = new Font("Segoe UI", 10f);
		TextBox1.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		TextBox1.Location = new Point(90, 12);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		TextBox1.Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = ScrollBars.None;
		TextBox1.SelectionStart = 0;
		TextBox1.Size = new Size(632, 20);
		TextBox1.TabIndex = 6;
		TextBox1.TextAlign = HorizontalAlignment.Left;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		Label2.AutoSize = true;
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(4, 16);
		Label2.Name = "Label2";
		Label2.Size = new Size(69, 13);
		Label2.TabIndex = 5;
		Label2.Text = "描述：";
		TC_ActionOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TC_ActionOptions.Controls.Add(TabPage1);
		TC_ActionOptions.Controls.Add(TabPage2);
		TC_ActionOptions.Controls.Add(TabPage3);
		TC_ActionOptions.Controls.Add(TabPage4);
		TC_ActionOptions.Controls.Add(TabPage5);
		TC_ActionOptions.Controls.Add(TabPage6);
		TC_ActionOptions.Cursor = Cursors.Hand;
		TC_ActionOptions.Font = new Font("Segoe UI", 8f);
		TC_ActionOptions.ItemSize = new Size(80, 20);
		TC_ActionOptions.Location = new Point(4, 64);
		TC_ActionOptions.Multiline = true;
		TC_ActionOptions.Name = "TC_ActionOptions";
		TC_ActionOptions.SelectedIndex = 0;
		TC_ActionOptions.Size = new Size(722, 382);
		TC_ActionOptions.TabIndex = 22;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(Label5);
		TabPage1.Controls.Add(NUD_Points);
		TabPage1.Controls.Add(CB_Points_Sides);
		TabPage1.Controls.Add(Label4);
		TabPage1.Controls.Add(Label1);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(714, 354);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "改变分数";
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(372, 120);
		Label5.Name = "Label5";
		Label5.Size = new Size(116, 13);
		Label5.TabIndex = 4;
		Label5.Text = "（为负数则减去分数）";
		NUD_Points.BackColor = Color.FromArgb(35, 35, 35);
		NUD_Points.BorderStyle = BorderStyle.FixedSingle;
		NUD_Points.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
		NUD_Points.ForeColor = Color.White;
		NUD_Points.Location = new Point(174, 113);
		NUD_Points.Maximum = new decimal(new int[4] { 999999, 0, 0, 0 });
		NUD_Points.Minimum = new decimal(new int[4] { 999999, 0, 0, -2147483648 });
		NUD_Points.Name = "NUD_Points";
		NUD_Points.Size = new Size(192, 29);
		NUD_Points.TabIndex = 3;
		CB_Points_Sides.BackColor = Color.Transparent;
		CB_Points_Sides.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Points_Sides.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Points_Sides.Font = new Font("Segoe UI", 7f);
		CB_Points_Sides.FormattingEnabled = true;
		CB_Points_Sides.Location = new Point(174, 85);
		CB_Points_Sides.Name = "CB_Points_Sides";
		CB_Points_Sides.Size = new Size(192, 21);
		CB_Points_Sides.TabIndex = 2;
		Label4.AutoSize = true;
		Label4.ForeColor = Color.FromArgb(220, 220, 220);
		Label4.Location = new Point(89, 121);
		Label4.Name = "Label4";
		Label4.Size = new Size(80, 13);
		Label4.TabIndex = 1;
		Label4.Text = "分数变化：";
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(137, 88);
		Label1.Name = "Label1";
		Label1.Size = new Size(32, 13);
		Label1.TabIndex = 0;
		Label1.Text = "分方：";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(714, 354);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "结束想定";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(AreaEditor1);
		TabPage3.Controls.Add(ListBox_UnitsToTeleport);
		TabPage3.Controls.Add(Label6);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(714, 354);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "传送到区域";
		AreaEditor1.BackColor = Color.FromArgb(60, 63, 65);
		AreaEditor1.Location = new Point(356, 7);
		AreaEditor1.Name = "AreaEditor1";
		AreaEditor1.Size = new Size(351, 124);
		AreaEditor1.TabIndex = 2;
		AreaEditor1.Title = "Edit teleport area";
		ListBox_UnitsToTeleport.Location = new Point(10, 23);
		ListBox_UnitsToTeleport.MultiSelect = true;
		ListBox_UnitsToTeleport.Name = "ListBox_UnitsToTeleport";
		ListBox_UnitsToTeleport.RelatedInfos = null;
		ListBox_UnitsToTeleport.Size = new Size(340, 316);
		ListBox_UnitsToTeleport.TabIndex = 1;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(7, 7);
		Label6.Name = "Label6";
		Label6.Size = new Size(152, 13);
		Label6.TabIndex = 0;
		Label6.Text = "突出显示要传送的单元：";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Controls.Add(Button3);
		TabPage4.Controls.Add(Editor_Message_Text);
		TabPage4.Controls.Add(CB_Message_Side);
		TabPage4.Controls.Add(Label8);
		TabPage4.Controls.Add(Label9);
		TabPage4.Location = new Point(4, 24);
		TabPage4.Name = "TabPage4";
		TabPage4.Size = new Size(714, 354);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "消息";
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 10f);
		Button3.ForeColor = SystemColors.Control;
		Button3.Location = new Point(636, 18);
		Button3.Name = "Button3";
		Button3.Padding = new Padding(5);
		Button3.RoundRadius = 0;
		Button3.Size = new Size(75, 23);
		Button3.TabIndex = 29;
		Button3.Text = "编辑HTML";
		((System.Windows.Forms.Control)Editor_Message_Text).Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		((System.Windows.Forms.Control)Editor_Message_Text).BackColor = Color.FromArgb(69, 73, 74);
		Editor_Message_Text.BodyBackColor = Color.FromArgb(43, 43, 43);
		Editor_Message_Text.BodyForeColor = Color.FromArgb(220, 220, 220);
		Editor_Message_Text.BorderSize = 0;
		((System.Windows.Forms.UserControl)Editor_Message_Text).BorderStyle = BorderStyle.Fixed3D;
		((System.Windows.Forms.Control)Editor_Message_Text).Enabled = false;
		((System.Windows.Forms.Control)Editor_Message_Text).ForeColor = Color.FromArgb(220, 220, 220);
		Editor_Message_Text.InnerText = null;
		((System.Windows.Forms.Control)Editor_Message_Text).Location = new Point(72, 47);
		((System.Windows.Forms.Control)Editor_Message_Text).Name = "Editor_Message_Text";
		((System.Windows.Forms.Control)Editor_Message_Text).Size = new Size(639, 307);
		((System.Windows.Forms.Control)Editor_Message_Text).TabIndex = 28;
		CB_Message_Side.BackColor = Color.Transparent;
		CB_Message_Side.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Message_Side.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Message_Side.Font = new Font("Segoe UI", 7f);
		CB_Message_Side.FormattingEnabled = true;
		CB_Message_Side.Location = new Point(73, 14);
		CB_Message_Side.Name = "CB_Message_Side";
		CB_Message_Side.Size = new Size(231, 21);
		CB_Message_Side.TabIndex = 7;
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(13, 47);
		Label8.Name = "Label8";
		Label8.Size = new Size(55, 13);
		Label8.TabIndex = 6;
		Label8.Text = "消息：";
		Label9.AutoSize = true;
		Label9.ForeColor = Color.FromArgb(220, 220, 220);
		Label9.Location = new Point(13, 17);
		Label9.Name = "Label9";
		Label9.Size = new Size(32, 13);
		Label9.TabIndex = 5;
		Label9.Text = "分方：";
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		TabPage5.Controls.Add(CB_MissionStatus_Status);
		TabPage5.Controls.Add(Label11);
		TabPage5.Controls.Add(CB_MissionStatus_Mission);
		TabPage5.Controls.Add(CB_MissionStatus_Side);
		TabPage5.Controls.Add(Label7);
		TabPage5.Controls.Add(Label10);
		TabPage5.Location = new Point(4, 24);
		TabPage5.Name = "TabPage5";
		TabPage5.Size = new Size(714, 354);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "任务状态";
		CB_MissionStatus_Status.BackColor = Color.Transparent;
		CB_MissionStatus_Status.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MissionStatus_Status.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MissionStatus_Status.Font = new Font("Segoe UI", 7f);
		CB_MissionStatus_Status.FormattingEnabled = true;
		CB_MissionStatus_Status.Items.AddRange(new object[2] { "启用", "未启用" });
		CB_MissionStatus_Status.Location = new Point(73, 68);
		CB_MissionStatus_Status.Name = "CB_MissionStatus_Status";
		CB_MissionStatus_Status.Size = new Size(231, 21);
		CB_MissionStatus_Status.TabIndex = 14;
		Label11.AutoSize = true;
		Label11.ForeColor = Color.FromArgb(220, 220, 220);
		Label11.Location = new Point(13, 71);
		Label11.Name = "Label11";
		Label11.Size = new Size(67, 13);
		Label11.TabIndex = 13;
		Label11.Text = "新状态：";
		CB_MissionStatus_Mission.BackColor = Color.Transparent;
		CB_MissionStatus_Mission.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MissionStatus_Mission.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MissionStatus_Mission.Font = new Font("Segoe UI", 7f);
		CB_MissionStatus_Mission.FormattingEnabled = true;
		CB_MissionStatus_Mission.Location = new Point(73, 41);
		CB_MissionStatus_Mission.Name = "CB_MissionStatus_Mission";
		CB_MissionStatus_Mission.Size = new Size(231, 21);
		CB_MissionStatus_Mission.TabIndex = 12;
		CB_MissionStatus_Side.BackColor = Color.Transparent;
		CB_MissionStatus_Side.DrawMode = DrawMode.OwnerDrawFixed;
		CB_MissionStatus_Side.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_MissionStatus_Side.Font = new Font("Segoe UI", 7f);
		CB_MissionStatus_Side.FormattingEnabled = true;
		CB_MissionStatus_Side.Location = new Point(73, 14);
		CB_MissionStatus_Side.Name = "CB_MissionStatus_Side";
		CB_MissionStatus_Side.Size = new Size(231, 21);
		CB_MissionStatus_Side.TabIndex = 11;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(13, 44);
		Label7.Name = "Label7";
		Label7.Size = new Size(50, 13);
		Label7.TabIndex = 10;
		Label7.Text = "任务：";
		Label10.AutoSize = true;
		Label10.ForeColor = Color.FromArgb(220, 220, 220);
		Label10.Location = new Point(13, 17);
		Label10.Name = "Label10";
		Label10.Size = new Size(32, 13);
		Label10.TabIndex = 9;
		Label10.Text = "分方：";
		TabPage6.BackColor = Color.FromArgb(60, 63, 65);
		TabPage6.Controls.Add(NUD_LuaScript);
		TabPage6.Controls.Add(Label13);
		TabPage6.Controls.Add(Button_AddLuaScript);
		TabPage6.Controls.Add(CB_LuaTemplate);
		TabPage6.Controls.Add(Label12);
		TabPage6.Controls.Add(TextBox2);
		TabPage6.Location = new Point(4, 24);
		TabPage6.Name = "TabPage6";
		TabPage6.Padding = new Padding(3);
		TabPage6.Size = new Size(714, 354);
		TabPage6.TabIndex = 5;
		TabPage6.Text = "Lua脚本";
		NUD_LuaScript.BackColor = Color.FromArgb(69, 73, 74);
		NUD_LuaScript.Font = new Font("Segoe UI", 10f);
		NUD_LuaScript.ForeColor = Color.FromArgb(220, 220, 220);
		NUD_LuaScript.Location = new Point(660, 7);
		NUD_LuaScript.Maximum = 100;
		NUD_LuaScript.Minimum = 0;
		NUD_LuaScript.Name = "NUD_LuaScript";
		NUD_LuaScript.Size = new Size(54, 26);
		NUD_LuaScript.TabIndex = 5;
		NUD_LuaScript.Value = 0;
		Label13.AutoSize = true;
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(600, 13);
		Label13.Name = "Label13";
		Label13.Size = new Size(53, 13);
		Label13.TabIndex = 4;
		Label13.Text = "字体大小：";
		Button_AddLuaScript.BackColor = Color.Transparent;
		Button_AddLuaScript.DialogResult = DialogResult.None;
		Button_AddLuaScript.Font = new Font("Segoe UI", 10f);
		Button_AddLuaScript.ForeColor = SystemColors.Control;
		Button_AddLuaScript.Location = new Point(521, 9);
		Button_AddLuaScript.Name = "Button_AddLuaScript";
		Button_AddLuaScript.Padding = new Padding(5);
		Button_AddLuaScript.RoundRadius = 0;
		Button_AddLuaScript.Size = new Size(75, 21);
		Button_AddLuaScript.TabIndex = 3;
		Button_AddLuaScript.Text = "添加";
		CB_LuaTemplate.BackColor = Color.Transparent;
		CB_LuaTemplate.DrawMode = DrawMode.OwnerDrawFixed;
		CB_LuaTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_LuaTemplate.Font = new Font("Segoe UI", 7f);
		CB_LuaTemplate.FormattingEnabled = true;
		CB_LuaTemplate.Location = new Point(109, 9);
		CB_LuaTemplate.Name = "CB_LuaTemplate";
		CB_LuaTemplate.Size = new Size(406, 21);
		CB_LuaTemplate.TabIndex = 2;
		Label12.AutoSize = true;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(6, 12);
		Label12.Name = "Label12";
		Label12.Size = new Size(110, 13);
		Label12.TabIndex = 1;
		Label12.Text = "添加脚本模板：";
		TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox2.BackColor = Color.FromArgb(69, 73, 74);
		TextBox2.BorderStyle = BorderStyle.FixedSingle;
		TextBox2.Font = new Font("Segoe UI", 10f);
		TextBox2.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox2.Location = new Point(0, 37);
		TextBox2.MaxLength = 999999999;
		TextBox2.Multiline = true;
		TextBox2.Name = "TextBox2";
		TextBox2.ScrollBars = ScrollBars.Both;
		TextBox2.Size = new Size(714, 317);
		TextBox2.TabIndex = 0;
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(3, 48);
		Label3.Name = "Label3";
		Label3.Size = new Size(102, 13);
		Label3.TabIndex = 21;
		Label3.Text = "动作设定";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 10f);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(651, 448);
		Button2.Name = "Button2";
		Button2.Padding = new Padding(5);
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 24;
		Button2.Text = "取消";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 10f);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(4, 448);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 23;
		Button1.Text = "确定";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(727, 473);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(TC_ActionOptions);
		base.Controls.Add(Label3);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label2);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditAction";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑事件动作";
		TC_ActionOptions.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		((ISupportInitialize)NUD_Points).EndInit();
		TabPage3.ResumeLayout(performLayout: false);
		TabPage3.PerformLayout();
		TabPage4.ResumeLayout(performLayout: false);
		TabPage4.PerformLayout();
		TabPage5.ResumeLayout(performLayout: false);
		TabPage5.PerformLayout();
		TabPage6.ResumeLayout(performLayout: false);
		TabPage6.PerformLayout();
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
			theEA = null;
			ListBox_UnitsToTeleport.Items.Clear();
			AreaEditor1.ReleaseReferences();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void AwakeCreator(object sender, FormClosingEventArgs e)
	{
		m_ProducerSpecification?.Invoke(Client.CurrentScenario);
		ItemExporter.ConnectInterruptibleTemplate.ListActions.RefreshGrid();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void QueryCreator(object sender, EventArgs e)
	{
		if (Information.IsNothing(theEA))
		{
			Close();
		}
		TC_ActionOptions.SizeMode = TabSizeMode.Normal;
		TextBox1.Text = theEA.Description;
		Button1.Visible = true;
		Button2.Visible = Button1.Visible;
		switch (theEA.Type)
		{
		case EventAction.EventActionType.Points:
		{
			TC_ActionOptions.SelectedIndex = 0;
			CB_Points_Sides.Items.Clear();
			CB_Points_Sides.DisplayMember = "Content";
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array2 = sides_ReadOnly;
			foreach (Side side in array2)
			{
				ComboBoxItem comboBoxItem = new ComboBoxItem();
				comboBoxItem.Content = side.Name;
				comboBoxItem.Tag = side.ObjectID;
				CB_Points_Sides.Items.Add(comboBoxItem);
			}
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = CB_Points_Sides.Items.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ComboBoxItem comboBoxItem2 = (ComboBoxItem)enumerator2.Current;
					if (Operators.CompareString(Conversions.ToString(comboBoxItem2.Tag), ((EventAction_Points)theEA).SideID, TextCompare: true) == 0)
					{
						CB_Points_Sides.SelectedItem = comboBoxItem2;
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
			NUD_Points.Value = new decimal(((EventAction_Points)theEA).PointChange);
			break;
		}
		case EventAction.EventActionType.EndScenario:
			TC_ActionOptions.SelectedIndex = 1;
			break;
		case EventAction.EventActionType.TeleportInArea:
		{
			TC_ActionOptions.SelectedIndex = 2;
			ListBox_UnitsToTeleport.Items.Clear();
			DarkListItem darkListItem = new DarkListItem();
			List<int> list = new List<int>();
			foreach (ActiveUnit item in Client.CurrentScenario.ActiveUnits_List.OrderBy((ActiveUnit theAU) => theAU.Name, new NaturalSortComparer<string[]>()).ToList())
			{
				darkListItem = new DarkListItem(item.Name + " [" + item.ObjectID + "]");
				darkListItem.Tag = item;
				ListBox_UnitsToTeleport.Items.Add(darkListItem);
				if (((EventAction_TeleportInArea)theEA).UnitIDs.Contains(item.ObjectID))
				{
					list.Add(ListBox_UnitsToTeleport.Items.IndexOf(darkListItem));
				}
			}
			if (list.Count > 0)
			{
				ListBox_UnitsToTeleport.SelectItems(list);
			}
			AreaEditor1.AreaPoints = ((EventAction_TeleportInArea)theEA).Area;
			AreaEditor1.RefreshForm();
			break;
		}
		case EventAction.EventActionType.Message:
		{
			TC_ActionOptions.SelectedIndex = 3;
			CB_Message_Side.Items.Clear();
			CB_Message_Side.DisplayMember = "Content";
			Side[] sides_ReadOnly3 = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array3 = sides_ReadOnly3;
			foreach (Side side5 in array3)
			{
				ComboBoxItem comboBoxItem7 = new ComboBoxItem();
				comboBoxItem7.Content = side5.Name;
				comboBoxItem7.Tag = side5.ObjectID;
				CB_Message_Side.Items.Add(comboBoxItem7);
			}
			IEnumerator enumerator5 = null;
			try
			{
				enumerator5 = CB_Message_Side.Items.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					ComboBoxItem comboBoxItem8 = (ComboBoxItem)enumerator5.Current;
					if (Operators.CompareString(Conversions.ToString(comboBoxItem8.Tag), ((EventAction_Message)theEA).SideID, TextCompare: true) == 0)
					{
						CB_Message_Side.SelectedItem = comboBoxItem8;
						break;
					}
				}
			}
			finally
			{
				if (enumerator5 is IDisposable)
				{
					(enumerator5 as IDisposable).Dispose();
				}
			}
			if (!string.IsNullOrEmpty(((EventAction_Message)theEA).Text))
			{
				Editor_Message_Text.BodyHtml = ((EventAction_Message)theEA).Text;
			}
			break;
		}
		case EventAction.EventActionType.ChangeMissionStatus:
		{
			TC_ActionOptions.SelectedIndex = 4;
			if (Client.CurrentScenario.Sides_ReadOnly.Length == 0)
			{
				return;
			}
			Side side2 = Client.CurrentScenario.Sides_ReadOnly[0];
			CB_MissionStatus_Side.Items.Clear();
			CB_MissionStatus_Side.DisplayMember = "Content";
			Side[] sides_ReadOnly2 = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array4 = sides_ReadOnly2;
			foreach (Side side3 in array4)
			{
				ComboBoxItem comboBoxItem3 = new ComboBoxItem();
				comboBoxItem3.Content = side3.Name;
				comboBoxItem3.Tag = side3.ObjectID;
				CB_MissionStatus_Side.Items.Add(comboBoxItem3);
			}
			Side[] sides_ReadOnly4 = Client.CurrentScenario.Sides_ReadOnly;
			IEnumerator enumerator3 = null;
			sides_ReadOnly2 = sides_ReadOnly4;
			Side[] array5 = sides_ReadOnly2;
			foreach (Side side4 in array5)
			{
				foreach (Mission mission2 in side4.Missions)
				{
					if (Operators.CompareString(mission2.ObjectID, ((EventAction_ChangeMissionStatus)theEA).MissionID, TextCompare: true) != 0)
					{
						continue;
					}
					try
					{
						enumerator3 = CB_MissionStatus_Side.Items.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							ComboBoxItem comboBoxItem4 = (ComboBoxItem)enumerator3.Current;
							if (Operators.CompareString(Conversions.ToString(comboBoxItem4.Tag), side4.ObjectID, TextCompare: true) == 0)
							{
								side2 = side4;
								CB_MissionStatus_Side.SelectedItem = comboBoxItem4;
								break;
							}
						}
					}
					finally
					{
						if (enumerator3 is IDisposable)
						{
							(enumerator3 as IDisposable).Dispose();
						}
					}
				}
			}
			if (Client.CurrentSide.Missions.Count == 0)
			{
				break;
			}
			CB_MissionStatus_Mission.Items.Clear();
			CB_MissionStatus_Mission.DisplayMember = "Content";
			foreach (Mission mission3 in side2.Missions)
			{
				ComboBoxItem comboBoxItem5 = new ComboBoxItem();
				comboBoxItem5.Content = mission3.Name;
				comboBoxItem5.Tag = mission3.ObjectID;
				CB_MissionStatus_Mission.Items.Add(comboBoxItem5);
			}
			if (side2.Missions.Count > 0)
			{
				Mission mission = side2.Missions[0];
				foreach (Mission mission4 in side2.Missions)
				{
					if (Operators.CompareString(mission4.ObjectID, ((EventAction_ChangeMissionStatus)theEA).MissionID, TextCompare: true) == 0)
					{
						mission = mission4;
						break;
					}
				}
				IEnumerator enumerator4 = null;
				try
				{
					enumerator4 = CB_MissionStatus_Mission.Items.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						ComboBoxItem comboBoxItem6 = (ComboBoxItem)enumerator4.Current;
						if (Operators.CompareString(Conversions.ToString(comboBoxItem6.Tag), mission.ObjectID, TextCompare: true) == 0)
						{
							CB_MissionStatus_Mission.SelectedItem = comboBoxItem6;
							break;
						}
					}
				}
				finally
				{
					if (enumerator4 is IDisposable)
					{
						(enumerator4 as IDisposable).Dispose();
					}
				}
			}
			CB_MissionStatus_Status.SelectedIndex = (int)((EventAction_ChangeMissionStatus)theEA).NewStatus;
			break;
		}
		case EventAction.EventActionType.LuaScript:
		{
			TC_ActionOptions.SelectedIndex = 5;
			if (!string.IsNullOrEmpty(((EventAction_LuaScript)theEA).ScriptText))
			{
				TextBox2.Text = ((EventAction_LuaScript)theEA).ScriptText;
			}
			NUD_LuaScript.Value = (int)Math.Round(TextBox2.Font.Size);
			System.Windows.Forms.ComboBox.ObjectCollection items = CB_LuaTemplate.Items;
			object[] array = LuaSandBox.LuaMethods.OrderBy((string s) => s).ToArray();
			object[] items2 = array;
			items.AddRange(items2);
			CB_LuaTemplate.SelectedIndex = 0;
			break;
		}
		}
		TC_ActionOptions.HideNonSelectedTabs();
	}

	private void ResetCreator(object sender, EventArgs e)
	{
		Close();
	}

	private void MapCreator(object sender, EventArgs e)
	{
		switch (theEA.Type)
		{
		case EventAction.EventActionType.TeleportInArea:
		{
			if (((EventAction_TeleportInArea)theEA).Area.Count < 3)
			{
				DarkMessageBox.ShowError("您必须为传送区域定义至少3个参考点。", "参考点不够！");
				return;
			}
			HashSet<string> hashSet = new HashSet<string>();
			foreach (DarkListItem selectedItem in ListBox_UnitsToTeleport.SelectedItems)
			{
				hashSet.Add(((ActiveUnit)selectedItem.Tag).ObjectID);
			}
			((EventAction_TeleportInArea)theEA).UnitIDs = hashSet;
			break;
		}
		case EventAction.EventActionType.Message:
			((EventAction_Message)theEA).Text = Editor_Message_Text.BodyHtml;
			break;
		case EventAction.EventActionType.LuaScript:
			((EventAction_LuaScript)theEA).ScriptText = TextBox2.Text;
			break;
		}
		theEA.Description = TextBox1.Text;
		if (Action == _FormAction.AddNew)
		{
			Client.CurrentScenario.EventActions.Add(theEA.ObjectID, theEA);
		}
		Close();
	}

	private void SortCreator(object sender, EventArgs e)
	{
		((EventAction_Points)theEA).SideID = Conversions.ToString(NewLateBinding.LateGet(CB_Points_Sides.SelectedItem, null, "tag", new object[0], null, null, null));
	}

	private void CalcCreator(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_Points.Value))
		{
			((EventAction_Points)theEA).PointChange = Convert.ToInt32(NUD_Points.Value);
		}
	}

	private void RateCreator(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theEA))
		{
			((EventAction_Message)theEA).SideID = Conversions.ToString(((ComboBoxItem)CB_Message_Side.SelectedItem).Tag);
		}
	}

	private void FlushCreator(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theEA))
		{
			((EventAction_Message)theEA).Text = ((System.Windows.Forms.Control)Editor_Message_Text).Text;
		}
	}

	private void ForgotCreator(object sender, EventArgs e)
	{
		if (Client.CurrentScenario.Sides_ReadOnly.Length == 0)
		{
			return;
		}
		Side side = Client.CurrentScenario.Sides_ReadOnly[0];
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side2 in array)
		{
			if (Operators.CompareString(side2.ObjectID, Conversions.ToString(((ComboBoxItem)CB_MissionStatus_Side.SelectedItem).Tag), TextCompare: true) == 0)
			{
				side = side2;
				break;
			}
		}
		CB_MissionStatus_Mission.Items.Clear();
		CB_MissionStatus_Mission.DisplayMember = "Content";
		foreach (Mission mission in side.Missions)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem();
			comboBoxItem.Content = mission.Name;
			comboBoxItem.Tag = mission.ObjectID;
			CB_MissionStatus_Mission.Items.Add(comboBoxItem);
		}
		if (!Information.IsNothing(theEA) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(CB_MissionStatus_Mission.SelectedItem)))
		{
			((EventAction_ChangeMissionStatus)theEA).MissionID = Conversions.ToString(NewLateBinding.LateGet(CB_MissionStatus_Mission.SelectedItem, null, "Tag", new object[0], null, null, null));
			if (side.Missions.Count > 0)
			{
				CB_MissionStatus_Status.SelectedIndex = (int)side.Missions[0].GetStatus(Client.CurrentScenario);
			}
		}
	}

	private void CollectCreator(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theEA))
		{
			((EventAction_ChangeMissionStatus)theEA).MissionID = Conversions.ToString(NewLateBinding.LateGet(CB_MissionStatus_Mission.SelectedItem, null, "Tag", new object[0], null, null, null));
		}
	}

	private void OrderCreator(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theEA))
		{
			((EventAction_ChangeMissionStatus)theEA).NewStatus = (Mission.MissionStatus)CB_MissionStatus_Status.SelectedIndex;
		}
	}

	private void RegisterCreator(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2 || e.KeyCode == Keys.F3 || e.KeyCode == Keys.F4 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F10 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12)
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void ManageCreator(object sender, EventArgs e)
	{
		TextBox2.Text = TextBox2.Text.Insert(TextBox2.SelectionStart, Conversions.ToString(CB_LuaTemplate.SelectedItem));
	}

	private void RevertCreator(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_LuaScript.Value))
		{
			TextBox2.Font = new Font(TextBox2.Font.FontFamily, NUD_LuaScript.Value);
		}
	}

	private void CountMap(object sender, EventArgs e)
	{
		Editor_Message_Text.HtmlContentsEdit();
	}

	private void CustomizeMap(object object_0)
	{
		theEA.Description = TextBox1.Text;
	}

	private void CloneMap(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_LuaScript.Value))
		{
			TextBox2.Font = new Font(TextBox2.Font.FontFamily, NUD_LuaScript.Value);
		}
	}
}
