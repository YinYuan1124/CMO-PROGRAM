using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class IconeCustomizer : Form
{
	private IContainer _ParamsInterpreter;

	[AccessedThroughProperty("LV_SelectedUnits")]
	[CompilerGenerated]
	private DarkListView _InfoInterpreter;

	[AccessedThroughProperty("DarkGroupBox2")]
	[CompilerGenerated]
	private DarkGroupBox mapperInterpreter;

	[AccessedThroughProperty("IconContainer")]
	[CompilerGenerated]
	private FlowLayoutPanel m_ManagerInterpreter;

	[AccessedThroughProperty("Button_Confirm")]
	[CompilerGenerated]
	private DarkUIButton m_GetterInterpreter;

	[AccessedThroughProperty("ButtonRestoreDefault")]
	[CompilerGenerated]
	private DarkUIButton m_ProducerInterpreter;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private Button m_CallbackContainer;

	[AccessedThroughProperty("Button7")]
	[CompilerGenerated]
	private Button processContainer;

	[AccessedThroughProperty("Button11")]
	[CompilerGenerated]
	private Button threadContainer;

	[AccessedThroughProperty("Button12")]
	[CompilerGenerated]
	private Button m_RuleContainer;

	[AccessedThroughProperty("Button14")]
	[CompilerGenerated]
	private Button m_InstanceContainer;

	[AccessedThroughProperty("Button15")]
	[CompilerGenerated]
	private Button m_ObjectContainer;

	[AccessedThroughProperty("Button16")]
	[CompilerGenerated]
	private Button parameterContainer;

	[AccessedThroughProperty("DarkGroupBox3")]
	[CompilerGenerated]
	private DarkGroupBox registryContainer;

	[AccessedThroughProperty("Button_OpenFolder2")]
	[CompilerGenerated]
	private DarkUIButton _DefinitionContainer;

	[AccessedThroughProperty("DarkGroupBox4")]
	[CompilerGenerated]
	private DarkGroupBox m_ValContainer;

	[AccessedThroughProperty("DarkLabel2")]
	[CompilerGenerated]
	private DarkLabel m_WrapperContainer;

	[AccessedThroughProperty("DarkGroupBox5")]
	[CompilerGenerated]
	private DarkGroupBox observerContainer;

	[AccessedThroughProperty("Button_OpenFolder1")]
	[CompilerGenerated]
	private DarkUIButton _ClientContainer;

	[AccessedThroughProperty("Button22")]
	[CompilerGenerated]
	private Button dicContainer;

	[AccessedThroughProperty("Button5")]
	[CompilerGenerated]
	private Button m_ProxyContainer;

	[AccessedThroughProperty("Button8")]
	[CompilerGenerated]
	private Button m_ReaderContainer;

	[AccessedThroughProperty("Button10")]
	[CompilerGenerated]
	private Button importerContainer;

	[AccessedThroughProperty("Button27")]
	[CompilerGenerated]
	private Button invocationContainer;

	[AccessedThroughProperty("Button28")]
	[CompilerGenerated]
	private Button m_ClassContainer;

	[AccessedThroughProperty("CurrentSelection")]
	[CompilerGenerated]
	private PictureBox m_RequestContainer;

	[AccessedThroughProperty("Button_Reload")]
	[CompilerGenerated]
	private DarkUIButton valueContainer;

	[AccessedThroughProperty("DarkLabel6")]
	[CompilerGenerated]
	private DarkLabel tokenizerContainer;

	[AccessedThroughProperty("TB_Structure")]
	[CompilerGenerated]
	private RichTextBox stubContainer;

	[AccessedThroughProperty("DarkLabel4")]
	[CompilerGenerated]
	private DarkLabel specificationContainer;

	[AccessedThroughProperty("TB_Synthax")]
	[CompilerGenerated]
	private RichTextBox reponseContainer;

	[AccessedThroughProperty("TabPage3")]
	[CompilerGenerated]
	private TabPage taskContainer;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Reload2")]
	private DarkUIButton m_FilterContainer;

	private string _TestsContainer;

	private string m_InterpreterContainer;

	internal virtual DarkListView LV_SelectedUnits
	{
		[CompilerGenerated]
		get
		{
			return _InfoInterpreter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckIterator;
			DarkListView infoInterpreter = _InfoInterpreter;
			if (infoInterpreter != null)
			{
				infoInterpreter.SelectedIndicesChanged -= value2;
			}
			_InfoInterpreter = value;
			infoInterpreter = _InfoInterpreter;
			if (infoInterpreter != null)
			{
				infoInterpreter.SelectedIndicesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("DarkGroupBox1")]
	internal virtual DarkGroupBox DarkGroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkGroupBox DarkGroupBox2
	{
		[CompilerGenerated]
		get
		{
			return mapperInterpreter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mapperInterpreter = value;
		}
	}

	internal virtual FlowLayoutPanel IconContainer
	{
		[CompilerGenerated]
		get
		{
			return m_ManagerInterpreter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ManagerInterpreter = value;
		}
	}

	internal virtual DarkUIButton Button_Confirm
	{
		[CompilerGenerated]
		get
		{
			return m_GetterInterpreter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableIterator;
			DarkUIButton getterInterpreter = m_GetterInterpreter;
			if (getterInterpreter != null)
			{
				getterInterpreter.Click -= value2;
			}
			m_GetterInterpreter = value;
			getterInterpreter = m_GetterInterpreter;
			if (getterInterpreter != null)
			{
				getterInterpreter.Click += value2;
			}
		}
	}

	internal virtual DarkUIButton ButtonRestoreDefault
	{
		[CompilerGenerated]
		get
		{
			return m_ProducerInterpreter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchIterator;
			DarkUIButton producerInterpreter = m_ProducerInterpreter;
			if (producerInterpreter != null)
			{
				producerInterpreter.Click -= value2;
			}
			m_ProducerInterpreter = value;
			producerInterpreter = m_ProducerInterpreter;
			if (producerInterpreter != null)
			{
				producerInterpreter.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Button4")]
	internal virtual Button Button4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button1")]
	internal virtual Button Button1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button2")]
	internal virtual Button Button2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button3
	{
		[CompilerGenerated]
		get
		{
			return m_CallbackContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CallbackContainer = value;
		}
	}

	[field: AccessedThroughProperty("Button6")]
	internal virtual Button Button6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button7
	{
		[CompilerGenerated]
		get
		{
			return processContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			processContainer = value;
		}
	}

	internal virtual Button Button11
	{
		[CompilerGenerated]
		get
		{
			return threadContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			threadContainer = value;
		}
	}

	internal virtual Button Button12
	{
		[CompilerGenerated]
		get
		{
			return m_RuleContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RuleContainer = value;
		}
	}

	[field: AccessedThroughProperty("Button13")]
	internal virtual Button Button13
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button14
	{
		[CompilerGenerated]
		get
		{
			return m_InstanceContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InstanceContainer = value;
		}
	}

	internal virtual Button Button15
	{
		[CompilerGenerated]
		get
		{
			return m_ObjectContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ObjectContainer = value;
		}
	}

	internal virtual Button Button16
	{
		[CompilerGenerated]
		get
		{
			return parameterContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			parameterContainer = value;
		}
	}

	[field: AccessedThroughProperty("Button18")]
	internal virtual Button Button18
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button19")]
	internal virtual Button Button19
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button20")]
	internal virtual Button Button20
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button21")]
	internal virtual Button Button21
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkGroupBox DarkGroupBox3
	{
		[CompilerGenerated]
		get
		{
			return registryContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			registryContainer = value;
		}
	}

	internal virtual DarkUIButton Button_OpenFolder2
	{
		[CompilerGenerated]
		get
		{
			return _DefinitionContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeIterator;
			DarkUIButton definitionContainer = _DefinitionContainer;
			if (definitionContainer != null)
			{
				definitionContainer.Click -= value2;
			}
			_DefinitionContainer = value;
			definitionContainer = _DefinitionContainer;
			if (definitionContainer != null)
			{
				definitionContainer.Click += value2;
			}
		}
	}

	internal virtual DarkGroupBox DarkGroupBox4
	{
		[CompilerGenerated]
		get
		{
			return m_ValContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ValContainer = value;
		}
	}

	internal virtual DarkLabel DarkLabel2
	{
		[CompilerGenerated]
		get
		{
			return m_WrapperContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WrapperContainer = value;
		}
	}

	internal virtual DarkGroupBox DarkGroupBox5
	{
		[CompilerGenerated]
		get
		{
			return observerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			observerContainer = value;
		}
	}

	[field: AccessedThroughProperty("TB_Examples")]
	internal virtual RichTextBox TB_Examples
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkUIButton Button_OpenFolder1
	{
		[CompilerGenerated]
		get
		{
			return _ClientContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeIterator;
			DarkUIButton clientContainer = _ClientContainer;
			if (clientContainer != null)
			{
				clientContainer.Click -= value2;
			}
			_ClientContainer = value;
			clientContainer = _ClientContainer;
			if (clientContainer != null)
			{
				clientContainer.Click += value2;
			}
		}
	}

	internal virtual Button Button22
	{
		[CompilerGenerated]
		get
		{
			return dicContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dicContainer = value;
		}
	}

	[field: AccessedThroughProperty("Button23")]
	internal virtual Button Button23
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button24")]
	internal virtual Button Button24
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button5
	{
		[CompilerGenerated]
		get
		{
			return m_ProxyContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProxyContainer = value;
		}
	}

	internal virtual Button Button8
	{
		[CompilerGenerated]
		get
		{
			return m_ReaderContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ReaderContainer = value;
		}
	}

	[field: AccessedThroughProperty("Button9")]
	internal virtual Button Button9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button10
	{
		[CompilerGenerated]
		get
		{
			return importerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			importerContainer = value;
		}
	}

	[field: AccessedThroughProperty("Button25")]
	internal virtual Button Button25
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Button26")]
	internal virtual Button Button26
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button27
	{
		[CompilerGenerated]
		get
		{
			return invocationContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			invocationContainer = value;
		}
	}

	internal virtual Button Button28
	{
		[CompilerGenerated]
		get
		{
			return m_ClassContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ClassContainer = value;
		}
	}

	internal virtual PictureBox CurrentSelection
	{
		[CompilerGenerated]
		get
		{
			return m_RequestContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RequestContainer = value;
		}
	}

	internal virtual DarkUIButton Button_Reload
	{
		[CompilerGenerated]
		get
		{
			return valueContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitIterator;
			DarkUIButton darkUIButton = valueContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			valueContainer = value;
			darkUIButton = valueContainer;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal virtual DarkLabel DarkLabel6
	{
		[CompilerGenerated]
		get
		{
			return tokenizerContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tokenizerContainer = value;
		}
	}

	internal virtual RichTextBox TB_Structure
	{
		[CompilerGenerated]
		get
		{
			return stubContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			stubContainer = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel5")]
	internal virtual DarkLabel DarkLabel5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DarkLabel DarkLabel4
	{
		[CompilerGenerated]
		get
		{
			return specificationContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			specificationContainer = value;
		}
	}

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual RichTextBox TB_Synthax
	{
		[CompilerGenerated]
		get
		{
			return reponseContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			reponseContainer = value;
		}
	}

	[field: AccessedThroughProperty("DarkUITabControl1")]
	internal virtual DarkUITabControl DarkUITabControl1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return taskContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			taskContainer = value;
		}
	}

	internal virtual DarkUIButton Button_Reload2
	{
		[CompilerGenerated]
		get
		{
			return m_FilterContainer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ConcatIterator;
			DarkUIButton filterContainer = m_FilterContainer;
			if (filterContainer != null)
			{
				filterContainer.Click -= value2;
			}
			m_FilterContainer = value;
			filterContainer = m_FilterContainer;
			if (filterContainer != null)
			{
				filterContainer.Click += value2;
			}
		}
	}

	public string CurrentIconSelected
	{
		get
		{
			return _TestsContainer;
		}
		set
		{
			_TestsContainer = value;
			try
			{
				CurrentSelection.BackgroundImage = Image.FromFile(Client.GetCustomIconPath(_TestsContainer));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				CurrentSelection.BackgroundImage = null;
				ProjectData.ClearProjectError();
			}
		}
	}

	public IconeCustomizer()
	{
		base.Load += SetupIterator;
		_TestsContainer = "";
		m_InterpreterContainer = "";
		InvokeIterator();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _ParamsInterpreter != null)
			{
				_ParamsInterpreter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InvokeIterator()
	{
		QComponentResourceManager componentResourceManager = new QComponentResourceManager(typeof(IconeCustomizer));
		DarkUITabControl1 = new DarkUITabControl();
		TabPage3 = new TabPage();
		DarkGroupBox4 = new DarkGroupBox();
		Button_OpenFolder2 = new DarkUIButton();
		Button_Reload2 = new DarkUIButton();
		DarkLabel2 = new DarkLabel();
		DarkGroupBox1 = new DarkGroupBox();
		LV_SelectedUnits = new DarkListView();
		DarkGroupBox2 = new DarkGroupBox();
		IconContainer = new FlowLayoutPanel();
		Button4 = new Button();
		Button1 = new Button();
		Button2 = new Button();
		Button3 = new Button();
		Button6 = new Button();
		Button7 = new Button();
		Button11 = new Button();
		Button12 = new Button();
		Button13 = new Button();
		Button14 = new Button();
		Button15 = new Button();
		Button16 = new Button();
		Button18 = new Button();
		Button19 = new Button();
		Button20 = new Button();
		Button21 = new Button();
		Button22 = new Button();
		Button23 = new Button();
		Button24 = new Button();
		Button5 = new Button();
		Button8 = new Button();
		Button9 = new Button();
		Button10 = new Button();
		Button25 = new Button();
		Button26 = new Button();
		Button27 = new Button();
		Button28 = new Button();
		Button_Confirm = new DarkUIButton();
		DarkGroupBox3 = new DarkGroupBox();
		CurrentSelection = new PictureBox();
		ButtonRestoreDefault = new DarkUIButton();
		TabPage1 = new TabPage();
		DarkGroupBox5 = new DarkGroupBox();
		DarkLabel6 = new DarkLabel();
		TB_Structure = new RichTextBox();
		DarkLabel5 = new DarkLabel();
		DarkLabel4 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		TB_Synthax = new RichTextBox();
		Button_Reload = new DarkUIButton();
		Button_OpenFolder1 = new DarkUIButton();
		TB_Examples = new RichTextBox();
		DarkUITabControl1.SuspendLayout();
		TabPage3.SuspendLayout();
		DarkGroupBox4.SuspendLayout();
		DarkGroupBox1.SuspendLayout();
		DarkGroupBox2.SuspendLayout();
		IconContainer.SuspendLayout();
		DarkGroupBox3.SuspendLayout();
		((ISupportInitialize)CurrentSelection).BeginInit();
		TabPage1.SuspendLayout();
		DarkGroupBox5.SuspendLayout();
		SuspendLayout();
		DarkUITabControl1.Controls.Add(TabPage3);
		DarkUITabControl1.Controls.Add(TabPage1);
		DarkUITabControl1.Cursor = Cursors.Hand;
		DarkUITabControl1.ItemSize = new Size(80, 20);
		DarkUITabControl1.Location = new Point(12, 12);
		DarkUITabControl1.Name = "DarkUITabControl1";
		DarkUITabControl1.SelectedIndex = 0;
		DarkUITabControl1.Size = new Size(676, 515);
		DarkUITabControl1.TabIndex = 23;
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Controls.Add(DarkGroupBox4);
		TabPage3.Location = new Point(4, 24);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(668, 487);
		TabPage3.TabIndex = 1;
		TabPage3.Text = "Scenario Unit";
		DarkGroupBox4.Controls.Add(Button_OpenFolder2);
		DarkGroupBox4.Controls.Add(Button_Reload2);
		DarkGroupBox4.Controls.Add(DarkLabel2);
		DarkGroupBox4.Controls.Add(DarkGroupBox1);
		DarkGroupBox4.Controls.Add(DarkGroupBox2);
		DarkGroupBox4.Controls.Add(Button_Confirm);
		DarkGroupBox4.Controls.Add(DarkGroupBox3);
		DarkGroupBox4.Controls.Add(ButtonRestoreDefault);
		DarkGroupBox4.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox4.Location = new Point(6, 6);
		DarkGroupBox4.Name = "DarkGroupBox4";
		DarkGroupBox4.Size = new Size(656, 475);
		DarkGroupBox4.TabIndex = 19;
		DarkGroupBox4.TabStop = false;
		DarkGroupBox4.Text = "Custom Icon [Scenario Unit]";
		Button_OpenFolder2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Button_OpenFolder2.BackColor = Color.Transparent;
		Button_OpenFolder2.DialogResult = DialogResult.None;
		Button_OpenFolder2.ForeColor = SystemColors.Control;
		Button_OpenFolder2.Location = new Point(555, 15);
		Button_OpenFolder2.Name = "Button_OpenFolder2";
		Button_OpenFolder2.RoundRadius = 0;
		Button_OpenFolder2.Size = new Size(96, 20);
		Button_OpenFolder2.TabIndex = 19;
		Button_OpenFolder2.Text = "Open folder";
		Button_Reload2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Reload2.BackColor = Color.Transparent;
		Button_Reload2.DialogResult = DialogResult.None;
		Button_Reload2.ForeColor = SystemColors.Control;
		Button_Reload2.Location = new Point(470, 15);
		Button_Reload2.Name = "Button_Reload2";
		Button_Reload2.RoundRadius = 0;
		Button_Reload2.Size = new Size(79, 20);
		Button_Reload2.TabIndex = 22;
		Button_Reload2.Text = "Reload";
		DarkLabel2.AutoSize = true;
		DarkLabel2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		DarkLabel2.ForeColor = Color.White;
		DarkLabel2.Location = new Point(9, 18);
		DarkLabel2.Name = "DarkLabel2";
		DarkLabel2.Size = new Size(308, 13);
		DarkLabel2.TabIndex = 18;
		DarkLabel2.Text = "Customize the icon of one or more units in a scenario";
		DarkGroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DarkGroupBox1.Controls.Add(LV_SelectedUnits);
		DarkGroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox1.Location = new Point(6, 38);
		DarkGroupBox1.Name = "DarkGroupBox1";
		DarkGroupBox1.Size = new Size(379, 430);
		DarkGroupBox1.TabIndex = 1;
		DarkGroupBox1.TabStop = false;
		DarkGroupBox1.Text = "Current Unit Selection";
		LV_SelectedUnits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LV_SelectedUnits.BackColor = Color.FromArgb(40, 43, 45);
		LV_SelectedUnits.Location = new Point(6, 19);
		LV_SelectedUnits.MultiSelect = true;
		LV_SelectedUnits.Name = "LV_SelectedUnits";
		LV_SelectedUnits.RelatedInfos = null;
		LV_SelectedUnits.Size = new Size(367, 404);
		LV_SelectedUnits.TabIndex = 0;
		LV_SelectedUnits.Text = "LV_SelectedUnits";
		DarkGroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		DarkGroupBox2.Controls.Add(IconContainer);
		DarkGroupBox2.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox2.Location = new Point(391, 38);
		DarkGroupBox2.Name = "DarkGroupBox2";
		DarkGroupBox2.Size = new Size(261, 324);
		DarkGroupBox2.TabIndex = 2;
		DarkGroupBox2.TabStop = false;
		DarkGroupBox2.Text = "Available Icons";
		IconContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		IconContainer.AutoScroll = true;
		IconContainer.Controls.Add(Button4);
		IconContainer.Controls.Add(Button1);
		IconContainer.Controls.Add(Button2);
		IconContainer.Controls.Add(Button3);
		IconContainer.Controls.Add(Button6);
		IconContainer.Controls.Add(Button7);
		IconContainer.Controls.Add(Button11);
		IconContainer.Controls.Add(Button12);
		IconContainer.Controls.Add(Button13);
		IconContainer.Controls.Add(Button14);
		IconContainer.Controls.Add(Button15);
		IconContainer.Controls.Add(Button16);
		IconContainer.Controls.Add(Button18);
		IconContainer.Controls.Add(Button19);
		IconContainer.Controls.Add(Button20);
		IconContainer.Controls.Add(Button21);
		IconContainer.Controls.Add(Button22);
		IconContainer.Controls.Add(Button23);
		IconContainer.Controls.Add(Button24);
		IconContainer.Controls.Add(Button5);
		IconContainer.Controls.Add(Button8);
		IconContainer.Controls.Add(Button9);
		IconContainer.Controls.Add(Button10);
		IconContainer.Controls.Add(Button25);
		IconContainer.Controls.Add(Button26);
		IconContainer.Controls.Add(Button27);
		IconContainer.Controls.Add(Button28);
		IconContainer.Location = new Point(6, 19);
		IconContainer.Name = "IconContainer";
		IconContainer.Size = new Size(249, 299);
		IconContainer.TabIndex = 0;
		Button4.BackColor = Color.Transparent;
		Button4.BackgroundImage = componentResourceManager.GetObject("Button4.BackgroundImage");
		Button4.BackgroundImageLayout = ImageLayout.Stretch;
		Button4.FlatStyle = FlatStyle.Flat;
		Button4.ForeColor = Color.DarkGray;
		Button4.Location = new Point(3, 3);
		Button4.Name = "Button4";
		Button4.Size = new Size(40, 40);
		Button4.TabIndex = 3;
		Button4.UseVisualStyleBackColor = false;
		Button1.BackColor = Color.Transparent;
		Button1.BackgroundImage = componentResourceManager.GetObject("Button1.BackgroundImage");
		Button1.BackgroundImageLayout = ImageLayout.Stretch;
		Button1.FlatStyle = FlatStyle.Flat;
		Button1.ForeColor = Color.DarkGray;
		Button1.Location = new Point(49, 3);
		Button1.Name = "Button1";
		Button1.Size = new Size(40, 40);
		Button1.TabIndex = 4;
		Button1.UseVisualStyleBackColor = false;
		Button2.BackColor = Color.Transparent;
		Button2.BackgroundImage = componentResourceManager.GetObject("Button2.BackgroundImage");
		Button2.BackgroundImageLayout = ImageLayout.Stretch;
		Button2.FlatStyle = FlatStyle.Flat;
		Button2.ForeColor = Color.DarkGray;
		Button2.Location = new Point(95, 3);
		Button2.Name = "Button2";
		Button2.Size = new Size(40, 40);
		Button2.TabIndex = 5;
		Button2.UseVisualStyleBackColor = false;
		Button3.BackColor = Color.Transparent;
		Button3.BackgroundImage = componentResourceManager.GetObject("Button3.BackgroundImage");
		Button3.BackgroundImageLayout = ImageLayout.Stretch;
		Button3.FlatStyle = FlatStyle.Flat;
		Button3.ForeColor = Color.DarkGray;
		Button3.Location = new Point(141, 3);
		Button3.Name = "Button3";
		Button3.Size = new Size(40, 40);
		Button3.TabIndex = 6;
		Button3.UseVisualStyleBackColor = false;
		Button6.BackColor = Color.Transparent;
		Button6.BackgroundImage = componentResourceManager.GetObject("Button6.BackgroundImage");
		Button6.BackgroundImageLayout = ImageLayout.Stretch;
		Button6.FlatStyle = FlatStyle.Flat;
		Button6.ForeColor = Color.DarkGray;
		Button6.Location = new Point(187, 3);
		Button6.Name = "Button6";
		Button6.Size = new Size(40, 40);
		Button6.TabIndex = 8;
		Button6.UseVisualStyleBackColor = false;
		Button7.BackColor = Color.Transparent;
		Button7.BackgroundImage = componentResourceManager.GetObject("Button7.BackgroundImage");
		Button7.BackgroundImageLayout = ImageLayout.Stretch;
		Button7.FlatStyle = FlatStyle.Flat;
		Button7.ForeColor = Color.DarkGray;
		Button7.Location = new Point(3, 49);
		Button7.Name = "Button7";
		Button7.Size = new Size(40, 40);
		Button7.TabIndex = 9;
		Button7.UseVisualStyleBackColor = false;
		Button11.BackColor = Color.Transparent;
		Button11.BackgroundImage = componentResourceManager.GetObject("Button11.BackgroundImage");
		Button11.BackgroundImageLayout = ImageLayout.Stretch;
		Button11.FlatStyle = FlatStyle.Flat;
		Button11.ForeColor = Color.DarkGray;
		Button11.Location = new Point(49, 49);
		Button11.Name = "Button11";
		Button11.Size = new Size(40, 40);
		Button11.TabIndex = 13;
		Button11.UseVisualStyleBackColor = false;
		Button12.BackColor = Color.Transparent;
		Button12.BackgroundImage = componentResourceManager.GetObject("Button12.BackgroundImage");
		Button12.BackgroundImageLayout = ImageLayout.Stretch;
		Button12.FlatStyle = FlatStyle.Flat;
		Button12.ForeColor = Color.DarkGray;
		Button12.Location = new Point(95, 49);
		Button12.Name = "Button12";
		Button12.Size = new Size(40, 40);
		Button12.TabIndex = 14;
		Button12.UseVisualStyleBackColor = false;
		Button13.BackColor = Color.Transparent;
		Button13.BackgroundImage = componentResourceManager.GetObject("Button13.BackgroundImage");
		Button13.BackgroundImageLayout = ImageLayout.Stretch;
		Button13.FlatStyle = FlatStyle.Flat;
		Button13.ForeColor = Color.DarkGray;
		Button13.Location = new Point(141, 49);
		Button13.Name = "Button13";
		Button13.Size = new Size(40, 40);
		Button13.TabIndex = 15;
		Button13.UseVisualStyleBackColor = false;
		Button14.BackColor = Color.Transparent;
		Button14.BackgroundImage = componentResourceManager.GetObject("Button14.BackgroundImage");
		Button14.BackgroundImageLayout = ImageLayout.Stretch;
		Button14.FlatStyle = FlatStyle.Flat;
		Button14.ForeColor = Color.DarkGray;
		Button14.Location = new Point(187, 49);
		Button14.Name = "Button14";
		Button14.Size = new Size(40, 40);
		Button14.TabIndex = 16;
		Button14.UseVisualStyleBackColor = false;
		Button15.BackColor = Color.Transparent;
		Button15.BackgroundImage = componentResourceManager.GetObject("Button15.BackgroundImage");
		Button15.BackgroundImageLayout = ImageLayout.Stretch;
		Button15.FlatStyle = FlatStyle.Flat;
		Button15.ForeColor = Color.DarkGray;
		Button15.Location = new Point(3, 95);
		Button15.Name = "Button15";
		Button15.Size = new Size(40, 40);
		Button15.TabIndex = 17;
		Button15.UseVisualStyleBackColor = false;
		Button16.BackColor = Color.Transparent;
		Button16.BackgroundImage = componentResourceManager.GetObject("Button16.BackgroundImage");
		Button16.BackgroundImageLayout = ImageLayout.Stretch;
		Button16.FlatStyle = FlatStyle.Flat;
		Button16.ForeColor = Color.DarkGray;
		Button16.Location = new Point(49, 95);
		Button16.Name = "Button16";
		Button16.Size = new Size(40, 40);
		Button16.TabIndex = 18;
		Button16.UseVisualStyleBackColor = false;
		Button18.BackColor = Color.Transparent;
		Button18.BackgroundImage = componentResourceManager.GetObject("Button18.BackgroundImage");
		Button18.BackgroundImageLayout = ImageLayout.Stretch;
		Button18.FlatStyle = FlatStyle.Flat;
		Button18.ForeColor = Color.DarkGray;
		Button18.Location = new Point(95, 95);
		Button18.Name = "Button18";
		Button18.Size = new Size(40, 40);
		Button18.TabIndex = 19;
		Button18.UseVisualStyleBackColor = false;
		Button19.BackColor = Color.Transparent;
		Button19.BackgroundImage = componentResourceManager.GetObject("Button19.BackgroundImage");
		Button19.BackgroundImageLayout = ImageLayout.Stretch;
		Button19.FlatStyle = FlatStyle.Flat;
		Button19.ForeColor = Color.DarkGray;
		Button19.Location = new Point(141, 95);
		Button19.Name = "Button19";
		Button19.Size = new Size(40, 40);
		Button19.TabIndex = 20;
		Button19.UseVisualStyleBackColor = false;
		Button20.BackColor = Color.Transparent;
		Button20.BackgroundImage = componentResourceManager.GetObject("Button20.BackgroundImage");
		Button20.BackgroundImageLayout = ImageLayout.Stretch;
		Button20.FlatStyle = FlatStyle.Flat;
		Button20.ForeColor = Color.DarkGray;
		Button20.Location = new Point(187, 95);
		Button20.Name = "Button20";
		Button20.Size = new Size(40, 40);
		Button20.TabIndex = 21;
		Button20.UseVisualStyleBackColor = false;
		Button21.BackColor = Color.Transparent;
		Button21.BackgroundImage = componentResourceManager.GetObject("Button21.BackgroundImage");
		Button21.BackgroundImageLayout = ImageLayout.Stretch;
		Button21.FlatStyle = FlatStyle.Flat;
		Button21.ForeColor = Color.DarkGray;
		Button21.Location = new Point(3, 141);
		Button21.Name = "Button21";
		Button21.Size = new Size(40, 40);
		Button21.TabIndex = 22;
		Button21.UseVisualStyleBackColor = false;
		Button22.BackColor = Color.Transparent;
		Button22.BackgroundImage = componentResourceManager.GetObject("Button22.BackgroundImage");
		Button22.BackgroundImageLayout = ImageLayout.Stretch;
		Button22.FlatStyle = FlatStyle.Flat;
		Button22.ForeColor = Color.DarkGray;
		Button22.Location = new Point(49, 141);
		Button22.Name = "Button22";
		Button22.Size = new Size(40, 40);
		Button22.TabIndex = 23;
		Button22.UseVisualStyleBackColor = false;
		Button23.BackColor = Color.Transparent;
		Button23.BackgroundImage = componentResourceManager.GetObject("Button23.BackgroundImage");
		Button23.BackgroundImageLayout = ImageLayout.Stretch;
		Button23.FlatStyle = FlatStyle.Flat;
		Button23.ForeColor = Color.DarkGray;
		Button23.Location = new Point(95, 141);
		Button23.Name = "Button23";
		Button23.Size = new Size(40, 40);
		Button23.TabIndex = 24;
		Button23.UseVisualStyleBackColor = false;
		Button24.BackColor = Color.Transparent;
		Button24.BackgroundImage = componentResourceManager.GetObject("Button24.BackgroundImage");
		Button24.BackgroundImageLayout = ImageLayout.Stretch;
		Button24.FlatStyle = FlatStyle.Flat;
		Button24.ForeColor = Color.DarkGray;
		Button24.Location = new Point(141, 141);
		Button24.Name = "Button24";
		Button24.Size = new Size(40, 40);
		Button24.TabIndex = 25;
		Button24.UseVisualStyleBackColor = false;
		Button5.BackColor = Color.Transparent;
		Button5.BackgroundImage = componentResourceManager.GetObject("Button5.BackgroundImage");
		Button5.BackgroundImageLayout = ImageLayout.Stretch;
		Button5.FlatStyle = FlatStyle.Flat;
		Button5.ForeColor = Color.DarkGray;
		Button5.Location = new Point(187, 141);
		Button5.Name = "Button5";
		Button5.Size = new Size(40, 40);
		Button5.TabIndex = 26;
		Button5.UseVisualStyleBackColor = false;
		Button8.BackColor = Color.Transparent;
		Button8.BackgroundImage = componentResourceManager.GetObject("Button8.BackgroundImage");
		Button8.BackgroundImageLayout = ImageLayout.Stretch;
		Button8.FlatStyle = FlatStyle.Flat;
		Button8.ForeColor = Color.DarkGray;
		Button8.Location = new Point(3, 187);
		Button8.Name = "Button8";
		Button8.Size = new Size(40, 40);
		Button8.TabIndex = 27;
		Button8.UseVisualStyleBackColor = false;
		Button9.BackColor = Color.Transparent;
		Button9.BackgroundImage = componentResourceManager.GetObject("Button9.BackgroundImage");
		Button9.BackgroundImageLayout = ImageLayout.Stretch;
		Button9.FlatStyle = FlatStyle.Flat;
		Button9.ForeColor = Color.DarkGray;
		Button9.Location = new Point(49, 187);
		Button9.Name = "Button9";
		Button9.Size = new Size(40, 40);
		Button9.TabIndex = 28;
		Button9.UseVisualStyleBackColor = false;
		Button10.BackColor = Color.Transparent;
		Button10.BackgroundImage = componentResourceManager.GetObject("Button10.BackgroundImage");
		Button10.BackgroundImageLayout = ImageLayout.Stretch;
		Button10.FlatStyle = FlatStyle.Flat;
		Button10.ForeColor = Color.DarkGray;
		Button10.Location = new Point(95, 187);
		Button10.Name = "Button10";
		Button10.Size = new Size(40, 40);
		Button10.TabIndex = 29;
		Button10.UseVisualStyleBackColor = false;
		Button25.BackColor = Color.Transparent;
		Button25.BackgroundImage = componentResourceManager.GetObject("Button25.BackgroundImage");
		Button25.BackgroundImageLayout = ImageLayout.Stretch;
		Button25.FlatStyle = FlatStyle.Flat;
		Button25.ForeColor = Color.DarkGray;
		Button25.Location = new Point(141, 187);
		Button25.Name = "Button25";
		Button25.Size = new Size(40, 40);
		Button25.TabIndex = 30;
		Button25.UseVisualStyleBackColor = false;
		Button26.BackColor = Color.Transparent;
		Button26.BackgroundImage = componentResourceManager.GetObject("Button26.BackgroundImage");
		Button26.BackgroundImageLayout = ImageLayout.Stretch;
		Button26.FlatStyle = FlatStyle.Flat;
		Button26.ForeColor = Color.DarkGray;
		Button26.Location = new Point(187, 187);
		Button26.Name = "Button26";
		Button26.Size = new Size(40, 40);
		Button26.TabIndex = 31;
		Button26.UseVisualStyleBackColor = false;
		Button27.BackColor = Color.Transparent;
		Button27.BackgroundImage = componentResourceManager.GetObject("Button27.BackgroundImage");
		Button27.BackgroundImageLayout = ImageLayout.Stretch;
		Button27.FlatStyle = FlatStyle.Flat;
		Button27.ForeColor = Color.DarkGray;
		Button27.Location = new Point(3, 233);
		Button27.Name = "Button27";
		Button27.Size = new Size(40, 40);
		Button27.TabIndex = 32;
		Button27.UseVisualStyleBackColor = false;
		Button28.BackColor = Color.Transparent;
		Button28.BackgroundImage = componentResourceManager.GetObject("Button28.BackgroundImage");
		Button28.BackgroundImageLayout = ImageLayout.Stretch;
		Button28.FlatStyle = FlatStyle.Flat;
		Button28.ForeColor = Color.DarkGray;
		Button28.Location = new Point(49, 233);
		Button28.Name = "Button28";
		Button28.Size = new Size(40, 40);
		Button28.TabIndex = 33;
		Button28.UseVisualStyleBackColor = false;
		Button_Confirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button_Confirm.BackColor = Color.Transparent;
		Button_Confirm.DialogResult = DialogResult.None;
		Button_Confirm.ForeColor = SystemColors.Control;
		Button_Confirm.Location = new Point(513, 410);
		Button_Confirm.Name = "Button_Confirm";
		Button_Confirm.RoundRadius = 0;
		Button_Confirm.Size = new Size(138, 58);
		Button_Confirm.TabIndex = 3;
		Button_Confirm.Text = "确认";
		DarkGroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		DarkGroupBox3.BackColor = Color.Transparent;
		DarkGroupBox3.Controls.Add(CurrentSelection);
		DarkGroupBox3.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox3.Location = new Point(391, 368);
		DarkGroupBox3.Name = "DarkGroupBox3";
		DarkGroupBox3.Size = new Size(116, 100);
		DarkGroupBox3.TabIndex = 17;
		DarkGroupBox3.TabStop = false;
		DarkGroupBox3.Text = "Selected";
		CurrentSelection.BackgroundImageLayout = ImageLayout.Stretch;
		CurrentSelection.Location = new Point(21, 19);
		CurrentSelection.Name = "CurrentSelection";
		CurrentSelection.Size = new Size(74, 74);
		CurrentSelection.TabIndex = 0;
		CurrentSelection.TabStop = false;
		ButtonRestoreDefault.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		ButtonRestoreDefault.BackColor = Color.Transparent;
		ButtonRestoreDefault.DialogResult = DialogResult.None;
		ButtonRestoreDefault.ForeColor = SystemColors.Control;
		ButtonRestoreDefault.Location = new Point(513, 374);
		ButtonRestoreDefault.Name = "ButtonRestoreDefault";
		ButtonRestoreDefault.RoundRadius = 0;
		ButtonRestoreDefault.Size = new Size(139, 30);
		ButtonRestoreDefault.TabIndex = 4;
		ButtonRestoreDefault.Text = "Restore default icon";
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Controls.Add(DarkGroupBox5);
		TabPage1.Location = new Point(4, 24);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(668, 487);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "DBID and Type";
		DarkGroupBox5.Controls.Add(DarkLabel6);
		DarkGroupBox5.Controls.Add(TB_Structure);
		DarkGroupBox5.Controls.Add(DarkLabel5);
		DarkGroupBox5.Controls.Add(DarkLabel4);
		DarkGroupBox5.Controls.Add(DarkLabel3);
		DarkGroupBox5.Controls.Add(TB_Synthax);
		DarkGroupBox5.Controls.Add(Button_Reload);
		DarkGroupBox5.Controls.Add(Button_OpenFolder1);
		DarkGroupBox5.Controls.Add(TB_Examples);
		DarkGroupBox5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkGroupBox5.Location = new Point(3, 6);
		DarkGroupBox5.Name = "DarkGroupBox5";
		DarkGroupBox5.Size = new Size(662, 478);
		DarkGroupBox5.TabIndex = 20;
		DarkGroupBox5.TabStop = false;
		DarkGroupBox5.Text = "Custom Icon [DBID and Type]";
		DarkLabel6.AutoSize = true;
		DarkLabel6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		DarkLabel6.ForeColor = Color.White;
		DarkLabel6.Location = new Point(3, 32);
		DarkLabel6.Name = "DarkLabel6";
		DarkLabel6.Size = new Size(65, 15);
		DarkLabel6.TabIndex = 27;
		DarkLabel6.Text = "Structure";
		TB_Structure.BackColor = Color.FromArgb(40, 43, 45);
		TB_Structure.ForeColor = SystemColors.Info;
		TB_Structure.Location = new Point(6, 50);
		TB_Structure.Name = "TB_Structure";
		TB_Structure.ReadOnly = true;
		TB_Structure.Size = new Size(650, 138);
		TB_Structure.TabIndex = 26;
		TB_Structure.Text = componentResourceManager.GetString("TB_Structure.Text");
		DarkLabel5.AutoSize = true;
		DarkLabel5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		DarkLabel5.ForeColor = Color.FromArgb(220, 220, 220);
		DarkLabel5.Location = new Point(42, 19);
		DarkLabel5.Name = "DarkLabel5";
		DarkLabel5.Size = new Size(583, 13);
		DarkLabel5.TabIndex = 25;
		DarkLabel5.Text = "Customize the appearance, size and orientation of an icon specific to the DBID or the type of an unit.";
		DarkLabel4.AutoSize = true;
		DarkLabel4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		DarkLabel4.ForeColor = Color.White;
		DarkLabel4.Location = new Point(6, 274);
		DarkLabel4.Name = "DarkLabel4";
		DarkLabel4.Size = new Size(70, 15);
		DarkLabel4.TabIndex = 24;
		DarkLabel4.Text = "Examples";
		DarkLabel3.AutoSize = true;
		DarkLabel3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		DarkLabel3.ForeColor = Color.White;
		DarkLabel3.Location = new Point(6, 191);
		DarkLabel3.Name = "DarkLabel3";
		DarkLabel3.Size = new Size(57, 15);
		DarkLabel3.TabIndex = 23;
		DarkLabel3.Text = "Synthax";
		TB_Synthax.BackColor = Color.FromArgb(40, 43, 45);
		TB_Synthax.ForeColor = SystemColors.Info;
		TB_Synthax.Location = new Point(6, 209);
		TB_Synthax.Name = "TB_Synthax";
		TB_Synthax.ReadOnly = true;
		TB_Synthax.Size = new Size(650, 62);
		TB_Synthax.TabIndex = 22;
		TB_Synthax.Text = componentResourceManager.GetString("TB_Synthax.Text");
		Button_Reload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_Reload.BackColor = Color.Transparent;
		Button_Reload.DialogResult = DialogResult.None;
		Button_Reload.ForeColor = SystemColors.Control;
		Button_Reload.Location = new Point(517, 0);
		Button_Reload.Name = "Button_Reload";
		Button_Reload.RoundRadius = 0;
		Button_Reload.Size = new Size(128, 16);
		Button_Reload.TabIndex = 21;
		Button_Reload.Text = "Reload";
		Button_OpenFolder1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		Button_OpenFolder1.BackColor = Color.Transparent;
		Button_OpenFolder1.DialogResult = DialogResult.None;
		Button_OpenFolder1.ForeColor = SystemColors.Control;
		Button_OpenFolder1.Location = new Point(374, 0);
		Button_OpenFolder1.Name = "Button_OpenFolder1";
		Button_OpenFolder1.RoundRadius = 0;
		Button_OpenFolder1.Size = new Size(137, 16);
		Button_OpenFolder1.TabIndex = 20;
		Button_OpenFolder1.Text = "Open folder";
		TB_Examples.BackColor = Color.FromArgb(40, 43, 45);
		TB_Examples.ForeColor = SystemColors.Info;
		TB_Examples.Location = new Point(6, 292);
		TB_Examples.Name = "TB_Examples";
		TB_Examples.ReadOnly = true;
		TB_Examples.Size = new Size(650, 180);
		TB_Examples.TabIndex = 1;
		TB_Examples.Text = componentResourceManager.GetString("TB_Examples.Text");
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(60, 63, 65);
		base.ClientSize = new Size(700, 539);
		base.Controls.Add(DarkUITabControl1);
		base.Name = "IconeCustomizer";
		Text = "Icon Customizer";
		DarkUITabControl1.ResumeLayout(performLayout: false);
		TabPage3.ResumeLayout(performLayout: false);
		DarkGroupBox4.ResumeLayout(performLayout: false);
		DarkGroupBox4.PerformLayout();
		DarkGroupBox1.ResumeLayout(performLayout: false);
		DarkGroupBox2.ResumeLayout(performLayout: false);
		IconContainer.ResumeLayout(performLayout: false);
		DarkGroupBox3.ResumeLayout(performLayout: false);
		((ISupportInitialize)CurrentSelection).EndInit();
		TabPage1.ResumeLayout(performLayout: false);
		DarkGroupBox5.ResumeLayout(performLayout: false);
		DarkGroupBox5.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void SetupIterator(object sender, EventArgs e)
	{
		refresh();
	}

	public void refresh()
	{
		new List<string>();
		LV_SelectedUnits.Items.Clear();
		foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
		{
			if (string.IsNullOrEmpty(selectedUnit.CustomIcon))
			{
				LV_SelectedUnits.Items.Add(new DarkListItem(selectedUnit.Name + " (" + selectedUnit.UnitClass + ")"));
			}
			else
			{
				LV_SelectedUnits.Items.Add(new DarkListItem("[" + Path.GetFileNameWithoutExtension(selectedUnit.CustomIcon) + "] " + selectedUnit.Name + " (" + selectedUnit.UnitClass + ")"));
			}
			LV_SelectedUnits.Items.ElementAt(LV_SelectedUnits.Items.Count - 1).Tag = selectedUnit;
		}
		if (LV_SelectedUnits.Items.Count > 0)
		{
			LV_SelectedUnits.SelectItems(0, LV_SelectedUnits.Items.Count - 1);
		}
		IconContainer.Controls.Clear();
		string[] files = Directory.GetFiles(Application.StartupPath + "\\Symbols\\Custom");
		string[] array = files;
		foreach (string path in array)
		{
			if (Operators.CompareString(Path.GetExtension(path).ToLower(), ".png", TextCompare: true) == 0)
			{
				AddNewIconItem(Path.GetFileName(path));
			}
		}
	}

	public void AddNewIconItem(string string_0)
	{
		IconItem iconItem = new IconItem();
		iconItem.Refresh(string_0, this);
		IconContainer.Controls.Add(iconItem);
	}

	private void ExcludeIterator(object sender, EventArgs e)
	{
		Process.Start(Application.StartupPath + "\\Symbols\\Custom");
	}

	private void IncludeIterator(object sender, EventArgs e)
	{
		Process.Start(Application.StartupPath + "\\Symbols\\Custom");
	}

	private void SearchIterator(object sender, EventArgs e)
	{
		foreach (Module_Unit.Unit item in ChangeIterator())
		{
			item.CustomIcon = "";
		}
		refresh();
	}

	private void EnableIterator(object sender, EventArgs e)
	{
		foreach (Module_Unit.Unit item in ChangeIterator())
		{
			item.CustomIcon = CurrentIconSelected;
		}
	}

	private List<Module_Unit.Unit> ChangeIterator()
	{
		List<Module_Unit.Unit> list = new List<Module_Unit.Unit>();
		foreach (DarkListItem selectedItem in LV_SelectedUnits.SelectedItems)
		{
			list.Add((Module_Unit.Unit)selectedItem.Tag);
		}
		return list;
	}

	private void InitIterator(object sender, EventArgs e)
	{
		Client.ParseCustomICons();
	}

	private void CheckIterator(object sender, EventArgs e)
	{
		List<Module_Unit.Unit> list = ChangeIterator();
		if (list.Count == 0)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (Module_Unit.Unit item in list)
		{
			if (!hashSet.Contains(item.CustomIcon))
			{
				hashSet.Add(item.CustomIcon);
			}
		}
		if (hashSet.Count == 1)
		{
			CurrentIconSelected = hashSet.ElementAt(0);
		}
		else
		{
			CurrentIconSelected = "";
		}
	}

	private void ConcatIterator(object sender, EventArgs e)
	{
		Client.ParseCustomICons();
	}
}
