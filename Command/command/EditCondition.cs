using System;
using System.Collections;
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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class EditCondition : DarkSecondaryFormBase
{
	public delegate void EventConditionsChangedEventHandler(Scenario theScen);

	public enum _FormAction : byte
	{
		AddNew,
		EditExisting
	}

	private IContainer m_RequestReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox m_ValueReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton writerReponse;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton specificationReponse;

	[AccessedThroughProperty("TabPage1")]
	[CompilerGenerated]
	private TabPage watcherReponse;

	[AccessedThroughProperty("CB_ObserverSides")]
	[CompilerGenerated]
	private DarkUIComboBox m_ReponseReponse;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel descriptorReponse;

	[AccessedThroughProperty("CB_Postures")]
	[CompilerGenerated]
	private DarkUIComboBox taskReponse;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel filterReponse;

	[AccessedThroughProperty("CB_TargetSides")]
	[CompilerGenerated]
	private DarkUIComboBox testsReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Label6")]
	private DarkLabel m_InterpreterReponse;

	[AccessedThroughProperty("CB_SidePosture_ModifierNOT")]
	[CompilerGenerated]
	private DarkCheckBox containerReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage2")]
	private TabPage m_ComposerReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ScenHasStarted_ModifierNOT")]
	private DarkCheckBox modelReponse;

	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage advisorReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("NUD_LuaScript")]
	private GControl1 _CustomerReponse;

	[AccessedThroughProperty("Label13")]
	[CompilerGenerated]
	private DarkLabel serializerReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_AddLuaScript")]
	private DarkUIButton refReponse;

	[AccessedThroughProperty("CB_LuaTemplate")]
	[CompilerGenerated]
	private DarkUIComboBox m_ErrorReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("Label12")]
	private DarkLabel codeReponse;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox2")]
	private DarkUITextBox m_ConnectionReponse;

	public EventCondition theEC;

	public _FormAction Action;

	[CompilerGenerated]
	private static EventConditionsChangedEventHandler _ContextReponse;

	internal DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return m_ValueReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = CloneTag;
			DarkUITextBox valueReponse = m_ValueReponse;
			if (valueReponse != null)
			{
				valueReponse.TextChanged -= value2;
			}
			m_ValueReponse = value;
			valueReponse = m_ValueReponse;
			if (valueReponse != null)
			{
				valueReponse.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal DarkLabel Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return writerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RegisterMock;
			DarkUIButton darkUIButton = writerReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			writerReponse = value;
			darkUIButton = writerReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return specificationReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageMock;
			DarkUIButton darkUIButton = specificationReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			specificationReponse = value;
			darkUIButton = specificationReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return watcherReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			watcherReponse = value;
		}
	}

	internal DarkUIComboBox CB_ObserverSides
	{
		[CompilerGenerated]
		get
		{
			return m_ReponseReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RevertMock;
			DarkUIComboBox reponseReponse = m_ReponseReponse;
			if (reponseReponse != null)
			{
				reponseReponse.SelectionChangeCommitted -= value2;
			}
			m_ReponseReponse = value;
			reponseReponse = m_ReponseReponse;
			if (reponseReponse != null)
			{
				reponseReponse.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return descriptorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			descriptorReponse = value;
		}
	}

	[field: AccessedThroughProperty("TC_ConditionOptions")]
	internal DarkUITabControl TC_ConditionOptions
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIComboBox CB_Postures
	{
		[CompilerGenerated]
		get
		{
			return taskReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CustomizeTag;
			DarkUIComboBox darkUIComboBox = taskReponse;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			taskReponse = value;
			darkUIComboBox = taskReponse;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return filterReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			filterReponse = value;
		}
	}

	internal DarkUIComboBox CB_TargetSides
	{
		[CompilerGenerated]
		get
		{
			return testsReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CountTag;
			DarkUIComboBox darkUIComboBox = testsReponse;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted -= value2;
			}
			testsReponse = value;
			darkUIComboBox = testsReponse;
			if (darkUIComboBox != null)
			{
				darkUIComboBox.SelectionChangeCommitted += value2;
			}
		}
	}

	internal DarkLabel Label6
	{
		[CompilerGenerated]
		get
		{
			return m_InterpreterReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InterpreterReponse = value;
		}
	}

	internal DarkCheckBox CB_SidePosture_ModifierNOT
	{
		[CompilerGenerated]
		get
		{
			return containerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MoveTag;
			DarkCheckBox darkCheckBox = containerReponse;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			containerReponse = value;
			darkCheckBox = containerReponse;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return m_ComposerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ComposerReponse = value;
		}
	}

	internal DarkCheckBox CB_ScenHasStarted_ModifierNOT
	{
		[CompilerGenerated]
		get
		{
			return modelReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteTag;
			DarkCheckBox darkCheckBox = modelReponse;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			modelReponse = value;
			darkCheckBox = modelReponse;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return advisorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			advisorReponse = value;
		}
	}

	internal GControl1 NUD_LuaScript
	{
		[CompilerGenerated]
		get
		{
			return _CustomerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DestroyTag;
			EventHandler value3 = ComputeTag;
			GControl1 customerReponse = _CustomerReponse;
			if (customerReponse != null)
			{
				customerReponse.TextChanged -= value2;
				customerReponse.Click -= value3;
			}
			_CustomerReponse = value;
			customerReponse = _CustomerReponse;
			if (customerReponse != null)
			{
				customerReponse.TextChanged += value2;
				customerReponse.Click += value3;
			}
		}
	}

	internal DarkLabel Label13
	{
		[CompilerGenerated]
		get
		{
			return serializerReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			serializerReponse = value;
		}
	}

	internal DarkUIButton Button_AddLuaScript
	{
		[CompilerGenerated]
		get
		{
			return refReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AddTag;
			DarkUIButton darkUIButton = refReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			refReponse = value;
			darkUIButton = refReponse;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIComboBox CB_LuaTemplate
	{
		[CompilerGenerated]
		get
		{
			return m_ErrorReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ErrorReponse = value;
		}
	}

	internal DarkLabel Label12
	{
		[CompilerGenerated]
		get
		{
			return codeReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			codeReponse = value;
		}
	}

	internal DarkUITextBox TextBox2
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionReponse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConnectionReponse = value;
		}
	}

	public static event EventConditionsChangedEventHandler EventConditionsChanged
	{
		[CompilerGenerated]
		add
		{
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler = _ContextReponse;
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler2;
			do
			{
				eventConditionsChangedEventHandler2 = eventConditionsChangedEventHandler;
				EventConditionsChangedEventHandler value2 = (EventConditionsChangedEventHandler)Delegate.Combine(eventConditionsChangedEventHandler2, value);
				eventConditionsChangedEventHandler = Interlocked.CompareExchange(ref _ContextReponse, value2, eventConditionsChangedEventHandler2);
			}
			while ((object)eventConditionsChangedEventHandler != eventConditionsChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler = _ContextReponse;
			EventConditionsChangedEventHandler eventConditionsChangedEventHandler2;
			do
			{
				eventConditionsChangedEventHandler2 = eventConditionsChangedEventHandler;
				EventConditionsChangedEventHandler value2 = (EventConditionsChangedEventHandler)Delegate.Remove(eventConditionsChangedEventHandler2, value);
				eventConditionsChangedEventHandler = Interlocked.CompareExchange(ref _ContextReponse, value2, eventConditionsChangedEventHandler2);
			}
			while ((object)eventConditionsChangedEventHandler != eventConditionsChangedEventHandler2);
		}
	}

	public EditCondition()
	{
		base.FormClosing += CollectMock;
		base.Load += OrderMock;
		base.KeyDown += ConnectTag;
		ForgotMock();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_RequestReponse != null)
			{
				m_RequestReponse.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ForgotMock()
	{
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		Label3 = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		TabPage1 = new TabPage();
		CB_Postures = new DarkUIComboBox();
		Label7 = new DarkLabel();
		CB_TargetSides = new DarkUIComboBox();
		Label6 = new DarkLabel();
		CB_SidePosture_ModifierNOT = new DarkCheckBox();
		CB_ObserverSides = new DarkUIComboBox();
		Label1 = new DarkLabel();
		TC_ConditionOptions = new DarkUITabControl();
		TabPage2 = new TabPage();
		CB_ScenHasStarted_ModifierNOT = new DarkCheckBox();
		TabPage3 = new TabPage();
		NUD_LuaScript = new GControl1();
		Label13 = new DarkLabel();
		Button_AddLuaScript = new DarkUIButton();
		CB_LuaTemplate = new DarkUIComboBox();
		Label12 = new DarkLabel();
		TextBox2 = new DarkUITextBox();
		TabPage1.SuspendLayout();
		TC_ConditionOptions.SuspendLayout();
		TabPage2.SuspendLayout();
		TabPage3.SuspendLayout();
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
		Label2.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(4, 16);
		Label2.Name = "Label2";
		Label2.Size = new Size(75, 13);
		Label2.TabIndex = 5;
		Label2.Text = "描述：";
		Label3.AutoSize = true;
		Label3.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label3.ForeColor = Color.FromArgb(220, 220, 220);
		Label3.Location = new Point(3, 48);
		Label3.Name = "Label3";
		Label3.Size = new Size(120, 13);
		Label3.TabIndex = 21;
		Label3.Text = "条件设置";
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
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(CB_Postures);
		TabPage1.Controls.Add(Label7);
		TabPage1.Controls.Add(CB_TargetSides);
		TabPage1.Controls.Add(Label6);
		TabPage1.Controls.Add(CB_SidePosture_ModifierNOT);
		TabPage1.Controls.Add(CB_ObserverSides);
		TabPage1.Controls.Add(Label1);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(714, 354);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "与分方关系";
		CB_Postures.BackColor = Color.Transparent;
		CB_Postures.DrawMode = DrawMode.OwnerDrawFixed;
		CB_Postures.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_Postures.Font = new Font("Segoe UI", 7f);
		CB_Postures.FormattingEnabled = true;
		CB_Postures.Items.AddRange(new object[5] { "中立", "友方", "非友方", "敌方", "未知" });
		CB_Postures.Location = new Point(557, 56);
		CB_Postures.Name = "CB_Postures";
		CB_Postures.Size = new Size(130, 21);
		CB_Postures.TabIndex = 13;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(530, 59);
		Label7.Name = "Label7";
		Label7.Size = new Size(21, 13);
		Label7.TabIndex = 12;
		Label7.Text = "为：";
		CB_TargetSides.BackColor = Color.Transparent;
		CB_TargetSides.DrawMode = DrawMode.OwnerDrawFixed;
		CB_TargetSides.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_TargetSides.Font = new Font("Segoe UI", 7f);
		CB_TargetSides.FormattingEnabled = true;
		CB_TargetSides.Location = new Point(332, 56);
		CB_TargetSides.Name = "CB_TargetSides";
		CB_TargetSides.Size = new Size(192, 21);
		CB_TargetSides.TabIndex = 11;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(249, 59);
		Label6.Name = "Label6";
		Label6.Size = new Size(77, 13);
		Label6.TabIndex = 10;
		Label6.Text = "与分方";
		CB_SidePosture_ModifierNOT.BackColor = Color.FromArgb(39, 39, 39);
		CB_SidePosture_ModifierNOT.Location = new Point(17, 24);
		CB_SidePosture_ModifierNOT.Name = "CB_SidePosture_ModifierNOT";
		CB_SidePosture_ModifierNOT.Size = new Size(92, 17);
		CB_SidePosture_ModifierNOT.TabIndex = 9;
		CB_SidePosture_ModifierNOT.Text = "条件：否";
		CB_ObserverSides.BackColor = Color.Transparent;
		CB_ObserverSides.DrawMode = DrawMode.OwnerDrawFixed;
		CB_ObserverSides.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_ObserverSides.Font = new Font("Segoe UI", 7f);
		CB_ObserverSides.FormattingEnabled = true;
		CB_ObserverSides.Location = new Point(51, 56);
		CB_ObserverSides.Name = "CB_ObserverSides";
		CB_ObserverSides.Size = new Size(192, 21);
		CB_ObserverSides.TabIndex = 2;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(14, 59);
		Label1.Name = "Label1";
		Label1.Size = new Size(31, 13);
		Label1.TabIndex = 0;
		Label1.Text = "分方：";
		TC_ConditionOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TC_ConditionOptions.Controls.Add(TabPage1);
		TC_ConditionOptions.Controls.Add(TabPage2);
		TC_ConditionOptions.Controls.Add(TabPage3);
		TC_ConditionOptions.Cursor = Cursors.Hand;
		TC_ConditionOptions.Font = new Font("Segoe UI", 8f);
		TC_ConditionOptions.ItemSize = new Size(80, 20);
		TC_ConditionOptions.Location = new Point(4, 64);
		TC_ConditionOptions.Multiline = true;
		TC_ConditionOptions.Name = "TC_ConditionOptions";
		TC_ConditionOptions.SelectedIndex = 0;
		TC_ConditionOptions.Size = new Size(722, 382);
		TC_ConditionOptions.TabIndex = 22;
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Controls.Add(CB_ScenHasStarted_ModifierNOT);
		TabPage2.Location = new Point(4, 24);
		TabPage2.Name = "TabPage2";
		TabPage2.Size = new Size(714, 354);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "想定已开始";
		CB_ScenHasStarted_ModifierNOT.Location = new Point(16, 14);
		CB_ScenHasStarted_ModifierNOT.Name = "CB_ScenHasStarted_ModifierNOT";
		CB_ScenHasStarted_ModifierNOT.Size = new Size(92, 17);
		CB_ScenHasStarted_ModifierNOT.TabIndex = 10;
		CB_ScenHasStarted_ModifierNOT.Text = "条件：否";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(NUD_LuaScript);
		TabPage3.Controls.Add(Label13);
		TabPage3.Controls.Add(Button_AddLuaScript);
		TabPage3.Controls.Add(CB_LuaTemplate);
		TabPage3.Controls.Add(Label12);
		TabPage3.Controls.Add(TextBox2);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Size = new Size(714, 354);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Lua脚本";
		NUD_LuaScript.BackColor = Color.Transparent;
		NUD_LuaScript.Font = new Font("Segoe UI", 10f);
		NUD_LuaScript.Location = new Point(669, 4);
		NUD_LuaScript.Maximum = 100;
		NUD_LuaScript.Minimum = 0;
		NUD_LuaScript.Name = "NUD_LuaScript";
		NUD_LuaScript.Size = new Size(45, 26);
		NUD_LuaScript.TabIndex = 11;
		NUD_LuaScript.Value = 0;
		Label13.ForeColor = Color.FromArgb(220, 220, 220);
		Label13.Location = new Point(609, 10);
		Label13.Name = "Label13";
		Label13.Size = new Size(54, 13);
		Label13.TabIndex = 10;
		Label13.Text = "字体大小：";
		Button_AddLuaScript.BackColor = Color.Transparent;
		Button_AddLuaScript.DialogResult = DialogResult.None;
		Button_AddLuaScript.Font = new Font("Segoe UI", 10f);
		Button_AddLuaScript.ForeColor = SystemColors.Control;
		Button_AddLuaScript.Location = new Point(533, 6);
		Button_AddLuaScript.Name = "Button_AddLuaScript";
		Button_AddLuaScript.Padding = new Padding(5);
		Button_AddLuaScript.RoundRadius = 0;
		Button_AddLuaScript.Size = new Size(75, 24);
		Button_AddLuaScript.TabIndex = 9;
		Button_AddLuaScript.Text = "添加";
		CB_LuaTemplate.BackColor = Color.Transparent;
		CB_LuaTemplate.DrawMode = DrawMode.OwnerDrawFixed;
		CB_LuaTemplate.DropDownStyle = ComboBoxStyle.DropDownList;
		CB_LuaTemplate.Font = new Font("Segoe UI", 7f);
		CB_LuaTemplate.FormattingEnabled = true;
		CB_LuaTemplate.Location = new Point(110, 6);
		CB_LuaTemplate.Name = "CB_LuaTemplate";
		CB_LuaTemplate.Size = new Size(417, 21);
		CB_LuaTemplate.TabIndex = 8;
		Label12.ForeColor = Color.FromArgb(220, 220, 220);
		Label12.Location = new Point(7, 9);
		Label12.Name = "Label12";
		Label12.Size = new Size(100, 13);
		Label12.TabIndex = 7;
		Label12.Text = "添加脚本模板：";
		TextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TextBox2.AutoCompleteCustomSource = null;
		TextBox2.AutoCompleteMode = AutoCompleteMode.None;
		TextBox2.AutoCompleteSource = AutoCompleteSource.None;
		TextBox2.BackColor = Color.FromArgb(69, 73, 74);
		TextBox2.Font = new Font("Segoe UI", 10f);
		TextBox2.ForeColor = Color.FromArgb(220, 220, 220);
		TextBox2.Image = null;
		TextBox2.Lines = null;
		TextBox2.Location = new Point(0, 36);
		TextBox2.MaxLength = 999999999;
		TextBox2.Multiline = true;
		TextBox2.Name = "TextBox2";
		TextBox2.ReadOnly = false;
		TextBox2.ScrollBars = ScrollBars.Vertical;
		TextBox2.SelectionStart = 0;
		TextBox2.Size = new Size(714, 318);
		TextBox2.TabIndex = 6;
		TextBox2.TextAlign = HorizontalAlignment.Left;
		TextBox2.UseSystemPasswordChar = false;
		TextBox2.WatermarkText = "";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(727, 473);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(TC_ConditionOptions);
		base.Controls.Add(Label3);
		base.Controls.Add(TextBox1);
		base.Controls.Add(Label2);
		base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "EditCondition";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "编辑事件条件";
		TabPage1.ResumeLayout(performLayout: false);
		TC_ConditionOptions.ResumeLayout(performLayout: false);
		TabPage2.ResumeLayout(performLayout: false);
		TabPage3.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CollectMock(object sender, FormClosingEventArgs e)
	{
		_ContextReponse?.Invoke(Client.CurrentScenario);
		ItemExporter.ConnectInterruptibleTemplate.ListConditions.RefreshGrid();
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void OrderMock(object sender, EventArgs e)
	{
		if (Information.IsNothing(theEC))
		{
			Close();
		}
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		TextBox1.Text = theEC.Description;
		Button1.Visible = true;
		Button2.Visible = Button1.Visible;
		switch (theEC.Type)
		{
		case EventCondition.EventConditionType.SidePosture:
		{
			TC_ConditionOptions.SelectedIndex = 0;
			CB_ObserverSides.Items.Clear();
			CB_ObserverSides.DisplayMember = "Content";
			CB_SidePosture_ModifierNOT.Checked = ((EventCondition_SidePosture)theEC).Modifier_NOT;
			Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array2 = sides_ReadOnly;
			foreach (Side side in array2)
			{
				ComboBoxItem comboBoxItem = new ComboBoxItem();
				comboBoxItem.Content = side.Name;
				comboBoxItem.Tag = side.ObjectID;
				CB_ObserverSides.Items.Add(comboBoxItem);
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = CB_ObserverSides.Items.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ComboBoxItem comboBoxItem2 = (ComboBoxItem)enumerator.Current;
					if (Operators.CompareString(Conversions.ToString(comboBoxItem2.Tag), ((EventCondition_SidePosture)theEC).ObserverSide_ID, TextCompare: true) == 0)
					{
						CB_ObserverSides.SelectedItem = comboBoxItem2;
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
			CB_TargetSides.Items.Clear();
			CB_TargetSides.DisplayMember = "Content";
			sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
			Side[] array3 = sides_ReadOnly;
			foreach (Side side2 in array3)
			{
				ComboBoxItem comboBoxItem3 = new ComboBoxItem();
				comboBoxItem3.Content = side2.Name;
				comboBoxItem3.Tag = side2.ObjectID;
				CB_TargetSides.Items.Add(comboBoxItem3);
			}
			IEnumerator enumerator2 = null;
			try
			{
				enumerator2 = CB_TargetSides.Items.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ComboBoxItem comboBoxItem4 = (ComboBoxItem)enumerator2.Current;
					if (Operators.CompareString(Conversions.ToString(comboBoxItem4.Tag), ((EventCondition_SidePosture)theEC).TargetSide_ID, TextCompare: true) == 0)
					{
						CB_TargetSides.SelectedItem = comboBoxItem4;
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
			CB_Postures.SelectedIndex = (int)((EventCondition_SidePosture)theEC).TargetPosture;
			break;
		}
		case EventCondition.EventConditionType.ScenHasStarted:
			TC_ConditionOptions.SelectedIndex = 1;
			CB_ScenHasStarted_ModifierNOT.Checked = ((EventCondition_ScenHasStarted)theEC).Modifier_NOT;
			break;
		case EventCondition.EventConditionType.LuaScript:
		{
			TC_ConditionOptions.SelectedIndex = 2;
			NUD_LuaScript.Value = (int)Math.Round(TextBox2.Font.Size);
			TextBox2.Text = ((EventCondition_LuaScript)theEC).ScriptText;
			System.Windows.Forms.ComboBox.ObjectCollection items = CB_LuaTemplate.Items;
			object[] array = LuaSandBox.LuaMethods.OrderBy((string s) => s).ToArray();
			object[] items2 = array;
			items.AddRange(items2);
			CB_LuaTemplate.SelectedIndex = 0;
			break;
		}
		}
		TC_ConditionOptions.HideNonSelectedTabs();
	}

	private void RegisterMock(object sender, EventArgs e)
	{
		Close();
	}

	private void ManageMock(object sender, EventArgs e)
	{
		if (theEC.Type == EventCondition.EventConditionType.LuaScript)
		{
			((EventCondition_LuaScript)theEC).ScriptText = TextBox2.Text;
		}
		if (Action == _FormAction.AddNew)
		{
			Client.CurrentScenario.EventConditions.Add(theEC.ObjectID, theEC);
		}
		Close();
	}

	private void RevertMock(object sender, EventArgs e)
	{
		((EventCondition_SidePosture)theEC).ObserverSide_ID = Conversions.ToString(((ComboBoxItem)CB_ObserverSides.SelectedItem).Tag);
	}

	private void CountTag(object sender, EventArgs e)
	{
		((EventCondition_SidePosture)theEC).TargetSide_ID = Conversions.ToString(((ComboBoxItem)CB_TargetSides.SelectedItem).Tag);
	}

	private void CustomizeTag(object sender, EventArgs e)
	{
		((EventCondition_SidePosture)theEC).TargetPosture = (Misc.PostureStance)CB_Postures.SelectedIndex;
	}

	private void CloneTag(object object_0)
	{
		theEC.Description = TextBox1.Text;
	}

	private void ConnectTag(object sender, KeyEventArgs e)
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

	private void MoveTag(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theEC) && theEC.Type == EventCondition.EventConditionType.SidePosture)
		{
			((EventCondition_SidePosture)theEC).Modifier_NOT = CB_SidePosture_ModifierNOT.Checked;
		}
	}

	private void DeleteTag(object sender, EventArgs e)
	{
		if (!Information.IsNothing(theEC) && theEC.Type == EventCondition.EventConditionType.ScenHasStarted)
		{
			((EventCondition_ScenHasStarted)theEC).Modifier_NOT = CB_ScenHasStarted_ModifierNOT.Checked;
		}
	}

	private void AddTag(object sender, EventArgs e)
	{
		TextBox2.Text = TextBox2.Text.Insert(TextBox2.SelectionStart, Conversions.ToString(CB_LuaTemplate.SelectedItem));
	}

	private void DestroyTag(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_LuaScript.Value))
		{
			TextBox2.Font = new Font(TextBox2.Font.FontFamily, NUD_LuaScript.Value);
		}
	}

	private void ComputeTag(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric(NUD_LuaScript.Value))
		{
			TextBox2.Font = new Font(TextBox2.Font.FontFamily, NUD_LuaScript.Value);
		}
	}
}
