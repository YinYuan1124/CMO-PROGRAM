using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TankerPlanner : DarkSecondaryFormBase
{
	private IContainer m_RulesException;

	[AccessedThroughProperty("RadioButton_Mission")]
	[CompilerGenerated]
	private RadioButton methodException;

	[AccessedThroughProperty("RadioButton_Automatic")]
	[CompilerGenerated]
	private RadioButton _ServiceException;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_50")]
	[CompilerGenerated]
	private RadioButton _SystemException;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_100")]
	[CompilerGenerated]
	private RadioButton m_CandidateException;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_250")]
	[CompilerGenerated]
	private RadioButton _BaseException;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_500")]
	[CompilerGenerated]
	private RadioButton policyException;

	[AccessedThroughProperty("RadioButton_TankerMaxDistance_Airborne_Tactical")]
	[CompilerGenerated]
	private RadioButton _BroadcasterException;

	[AccessedThroughProperty("TextBox_TankerMinimum_Total")]
	[CompilerGenerated]
	private DarkUITextBox m_IdentifierException;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private Label m_PrinterException;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	private Label m_ParserException;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox_TankerMinimum_Airborne")]
	private DarkUITextBox algoException;

	[AccessedThroughProperty("Label3")]
	[CompilerGenerated]
	private Label m_DatabaseException;

	[AccessedThroughProperty("TextBox_TankerMinimum_Station")]
	[CompilerGenerated]
	private DarkUITextBox m_InterceptorException;

	[CompilerGenerated]
	[AccessedThroughProperty("ListBox_Tankers")]
	private DarkListView messageException;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private Label productException;

	[AccessedThroughProperty("TextBox_MaxReceiversInQueuePerTanker_Airborne")]
	[CompilerGenerated]
	private DarkUITextBox m_AnnotationException;

	[AccessedThroughProperty("CheckBox_LaunchMissionWithoutTankersInPlace")]
	[CompilerGenerated]
	private CheckBox iteratorException;

	[CompilerGenerated]
	[AccessedThroughProperty("Label8")]
	private Label initializerException;

	[AccessedThroughProperty("TextBox_FuelQtyToStartLookingForTanker")]
	[CompilerGenerated]
	private DarkUITextBox m_RoleException;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private Label m_FactoryException;

	[AccessedThroughProperty("CB_FollowReceivers")]
	[CompilerGenerated]
	private CheckBox m_AttributeException;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	private DarkGroupBox m_EventException;

	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	private DarkGroupBox globalException;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox4")]
	private DarkGroupBox m_WorkerException;

	[CompilerGenerated]
	[AccessedThroughProperty("Combo_FollowReceiversNumber")]
	private DarkUIComboBox m_AccountException;

	public Mission TheMission;

	public Waypoint TheWaypoint;

	private bool stateException;

	private bool m_AuthenticationException;

	private bool _ParamsException;

	private bool _InfoException;

	private bool m_HelperException;

	private bool m_MapperException;

	internal RadioButton RadioButton_Mission
	{
		[CompilerGenerated]
		get
		{
			return methodException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RestartInterruptibleException;
			RadioButton radioButton = methodException;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			methodException = value;
			radioButton = methodException;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal RadioButton RadioButton_Automatic
	{
		[CompilerGenerated]
		get
		{
			return _ServiceException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartInterruptibleException;
			RadioButton serviceException = _ServiceException;
			if (serviceException != null)
			{
				serviceException.CheckedChanged -= value2;
			}
			_ServiceException = value;
			serviceException = _ServiceException;
			if (serviceException != null)
			{
				serviceException.CheckedChanged += value2;
			}
		}
	}

	internal RadioButton RadioButton_TankerMaxDistance_Airborne_50
	{
		[CompilerGenerated]
		get
		{
			return _SystemException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ListInterruptibleException;
			RadioButton systemException = _SystemException;
			if (systemException != null)
			{
				systemException.CheckedChanged -= value2;
			}
			_SystemException = value;
			systemException = _SystemException;
			if (systemException != null)
			{
				systemException.CheckedChanged += value2;
			}
		}
	}

	internal RadioButton RadioButton_TankerMaxDistance_Airborne_100
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VerifyInterruptibleException;
			RadioButton candidateException = m_CandidateException;
			if (candidateException != null)
			{
				candidateException.CheckedChanged -= value2;
			}
			m_CandidateException = value;
			candidateException = m_CandidateException;
			if (candidateException != null)
			{
				candidateException.CheckedChanged += value2;
			}
		}
	}

	internal RadioButton RadioButton_TankerMaxDistance_Airborne_250
	{
		[CompilerGenerated]
		get
		{
			return _BaseException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CancelInterruptibleException;
			RadioButton baseException = _BaseException;
			if (baseException != null)
			{
				baseException.CheckedChanged -= value2;
			}
			_BaseException = value;
			baseException = _BaseException;
			if (baseException != null)
			{
				baseException.CheckedChanged += value2;
			}
		}
	}

	internal RadioButton RadioButton_TankerMaxDistance_Airborne_500
	{
		[CompilerGenerated]
		get
		{
			return policyException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StopInterruptibleException;
			RadioButton radioButton = policyException;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			policyException = value;
			radioButton = policyException;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal RadioButton RadioButton_TankerMaxDistance_Airborne_Tactical
	{
		[CompilerGenerated]
		get
		{
			return _BroadcasterException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TestInterruptibleException;
			RadioButton broadcasterException = _BroadcasterException;
			if (broadcasterException != null)
			{
				broadcasterException.CheckedChanged -= value2;
			}
			_BroadcasterException = value;
			broadcasterException = _BroadcasterException;
			if (broadcasterException != null)
			{
				broadcasterException.CheckedChanged += value2;
			}
		}
	}

	internal DarkUITextBox TextBox_TankerMinimum_Total
	{
		[CompilerGenerated]
		get
		{
			return m_IdentifierException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FindInterruptibleException;
			EventHandler value3 = SetInterruptibleException;
			DarkUITextBox identifierException = m_IdentifierException;
			if (identifierException != null)
			{
				identifierException.Enter -= value2;
				identifierException.Leave -= value3;
			}
			m_IdentifierException = value;
			identifierException = m_IdentifierException;
			if (identifierException != null)
			{
				identifierException.Enter += value2;
				identifierException.Leave += value3;
			}
		}
	}

	internal Label Label1
	{
		[CompilerGenerated]
		get
		{
			return m_PrinterException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PrinterException = value;
		}
	}

	internal Label Label2
	{
		[CompilerGenerated]
		get
		{
			return m_ParserException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParserException = value;
		}
	}

	internal DarkUITextBox TextBox_TankerMinimum_Airborne
	{
		[CompilerGenerated]
		get
		{
			return algoException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FillInterruptibleException;
			EventHandler value3 = CalculateInterruptibleException;
			DarkUITextBox darkUITextBox = algoException;
			if (darkUITextBox != null)
			{
				darkUITextBox.Enter -= value2;
				darkUITextBox.Leave -= value3;
			}
			algoException = value;
			darkUITextBox = algoException;
			if (darkUITextBox != null)
			{
				darkUITextBox.Enter += value2;
				darkUITextBox.Leave += value3;
			}
		}
	}

	internal Label Label3
	{
		[CompilerGenerated]
		get
		{
			return m_DatabaseException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_DatabaseException = value;
		}
	}

	internal DarkUITextBox TextBox_TankerMinimum_Station
	{
		[CompilerGenerated]
		get
		{
			return m_InterceptorException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PopInterruptibleException;
			EventHandler value3 = InstantiateInterruptibleException;
			DarkUITextBox interceptorException = m_InterceptorException;
			if (interceptorException != null)
			{
				interceptorException.Enter -= value2;
				interceptorException.Leave -= value3;
			}
			m_InterceptorException = value;
			interceptorException = m_InterceptorException;
			if (interceptorException != null)
			{
				interceptorException.Enter += value2;
				interceptorException.Leave += value3;
			}
		}
	}

	internal DarkListView ListBox_Tankers
	{
		[CompilerGenerated]
		get
		{
			return messageException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RemoveInterruptibleException;
			DarkListView darkListView = messageException;
			if (darkListView != null)
			{
				darkListView.Click -= value2;
			}
			messageException = value;
			darkListView = messageException;
			if (darkListView != null)
			{
				darkListView.Click += value2;
			}
		}
	}

	internal Label Label6
	{
		[CompilerGenerated]
		get
		{
			return productException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productException = value;
		}
	}

	internal DarkUITextBox TextBox_MaxReceiversInQueuePerTanker_Airborne
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CreateInterruptibleException;
			EventHandler value3 = CompareInterruptibleException;
			DarkUITextBox annotationException = m_AnnotationException;
			if (annotationException != null)
			{
				annotationException.Enter -= value2;
				annotationException.Leave -= value3;
			}
			m_AnnotationException = value;
			annotationException = m_AnnotationException;
			if (annotationException != null)
			{
				annotationException.Enter += value2;
				annotationException.Leave += value3;
			}
		}
	}

	internal CheckBox CheckBox_LaunchMissionWithoutTankersInPlace
	{
		[CompilerGenerated]
		get
		{
			return iteratorException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ResolveInterruptibleException;
			CheckBox checkBox = iteratorException;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			iteratorException = value;
			checkBox = iteratorException;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal Label Label8
	{
		[CompilerGenerated]
		get
		{
			return initializerException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			initializerException = value;
		}
	}

	internal DarkUITextBox TextBox_FuelQtyToStartLookingForTanker
	{
		[CompilerGenerated]
		get
		{
			return m_RoleException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ReadInterruptibleException;
			EventHandler value3 = DisableInterruptibleException;
			DarkUITextBox roleException = m_RoleException;
			if (roleException != null)
			{
				roleException.Enter -= value2;
				roleException.Leave -= value3;
			}
			m_RoleException = value;
			roleException = m_RoleException;
			if (roleException != null)
			{
				roleException.Enter += value2;
				roleException.Leave += value3;
			}
		}
	}

	internal Label Label7
	{
		[CompilerGenerated]
		get
		{
			return m_FactoryException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_FactoryException = value;
		}
	}

	internal CheckBox CB_FollowReceivers
	{
		[CompilerGenerated]
		get
		{
			return m_AttributeException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterruptibleException;
			CheckBox attributeException = m_AttributeException;
			if (attributeException != null)
			{
				attributeException.CheckedChanged -= value2;
			}
			m_AttributeException = value;
			attributeException = m_AttributeException;
			if (attributeException != null)
			{
				attributeException.CheckedChanged += value2;
			}
		}
	}

	internal DarkGroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return m_EventException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_EventException = value;
		}
	}

	internal DarkGroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return globalException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			globalException = value;
		}
	}

	internal DarkGroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return m_WorkerException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_WorkerException = value;
		}
	}

	internal DarkUIComboBox Combo_FollowReceiversNumber
	{
		[CompilerGenerated]
		get
		{
			return m_AccountException;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AssetInterruptibleException;
			DarkUIComboBox accountException = m_AccountException;
			if (accountException != null)
			{
				accountException.SelectionChangeCommitted -= value2;
			}
			m_AccountException = value;
			accountException = m_AccountException;
			if (accountException != null)
			{
				accountException.SelectionChangeCommitted += value2;
			}
		}
	}

	public TankerPlanner()
	{
		base.VisibleChanged += InitInterruptibleException;
		base.FormClosing += CheckInterruptibleException;
		base.KeyDown += InterruptInterruptibleException;
		base.Load += PostInterruptibleException;
		stateException = false;
		m_AuthenticationException = false;
		_ParamsException = false;
		_InfoException = false;
		m_HelperException = false;
		m_MapperException = false;
		EnableInterruptibleException();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_RulesException != null)
			{
				m_RulesException.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void EnableInterruptibleException()
	{
		RadioButton_Mission = new RadioButton();
		RadioButton_Automatic = new RadioButton();
		GroupBox1 = new DarkGroupBox();
		RadioButton_TankerMaxDistance_Airborne_50 = new RadioButton();
		RadioButton_TankerMaxDistance_Airborne_100 = new RadioButton();
		RadioButton_TankerMaxDistance_Airborne_250 = new RadioButton();
		RadioButton_TankerMaxDistance_Airborne_500 = new RadioButton();
		RadioButton_TankerMaxDistance_Airborne_Tactical = new RadioButton();
		TextBox_TankerMinimum_Total = new DarkUITextBox();
		Label1 = new Label();
		Label2 = new Label();
		TextBox_TankerMinimum_Airborne = new DarkUITextBox();
		Label3 = new Label();
		TextBox_TankerMinimum_Station = new DarkUITextBox();
		ListBox_Tankers = new DarkListView();
		Label6 = new Label();
		TextBox_MaxReceiversInQueuePerTanker_Airborne = new DarkUITextBox();
		CheckBox_LaunchMissionWithoutTankersInPlace = new CheckBox();
		GroupBox3 = new DarkGroupBox();
		GroupBox4 = new DarkGroupBox();
		Combo_FollowReceiversNumber = new DarkUIComboBox();
		Label8 = new Label();
		TextBox_FuelQtyToStartLookingForTanker = new DarkUITextBox();
		CB_FollowReceivers = new CheckBox();
		Label7 = new Label();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		SuspendLayout();
		RadioButton_Mission.BackColor = Color.Transparent;
		RadioButton_Mission.Cursor = Cursors.Hand;
		RadioButton_Mission.Font = new Font("Segoe UI", 9f);
		RadioButton_Mission.ForeColor = Color.FromArgb(209, 209, 209);
		RadioButton_Mission.Location = new Point(12, 29);
		RadioButton_Mission.Name = "RadioButton_Mission";
		RadioButton_Mission.Size = new Size(283, 21);
		RadioButton_Mission.TabIndex = 0;
		RadioButton_Mission.Text = "使用分配给特定任务的加油机";
		RadioButton_Mission.UseVisualStyleBackColor = false;
		RadioButton_Automatic.BackColor = Color.Transparent;
		RadioButton_Automatic.Cursor = Cursors.Hand;
		RadioButton_Automatic.Font = new Font("Segoe UI", 9f);
		RadioButton_Automatic.ForeColor = Color.FromArgb(209, 209, 209);
		RadioButton_Automatic.Location = new Point(12, 12);
		RadioButton_Automatic.Name = "RadioButton_Automatic";
		RadioButton_Automatic.Size = new Size(283, 21);
		RadioButton_Automatic.TabIndex = 3;
		RadioButton_Automatic.Text = "使用具有足够的燃料的最近加油机";
		RadioButton_Automatic.UseVisualStyleBackColor = false;
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox1.Controls.Add(RadioButton_TankerMaxDistance_Airborne_50);
		GroupBox1.Controls.Add(RadioButton_TankerMaxDistance_Airborne_100);
		GroupBox1.Controls.Add(RadioButton_TankerMaxDistance_Airborne_250);
		GroupBox1.Controls.Add(RadioButton_TankerMaxDistance_Airborne_500);
		GroupBox1.Controls.Add(RadioButton_TankerMaxDistance_Airborne_Tactical);
		GroupBox1.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox1.Location = new Point(352, 217);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(423, 112);
		GroupBox1.TabIndex = 4;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "飞机可以以下时间内预订加油机：";
		RadioButton_TankerMaxDistance_Airborne_50.BackColor = Color.Transparent;
		RadioButton_TankerMaxDistance_Airborne_50.Cursor = Cursors.Hand;
		RadioButton_TankerMaxDistance_Airborne_50.Font = new Font("Segoe UI", 9f);
		RadioButton_TankerMaxDistance_Airborne_50.ForeColor = Color.FromArgb(209, 209, 209);
		RadioButton_TankerMaxDistance_Airborne_50.Location = new Point(6, 85);
		RadioButton_TankerMaxDistance_Airborne_50.Name = "RadioButton_TankerMaxDistance_Airborne_50";
		RadioButton_TankerMaxDistance_Airborne_50.Size = new Size(54, 21);
		RadioButton_TankerMaxDistance_Airborne_50.TabIndex = 4;
		RadioButton_TankerMaxDistance_Airborne_50.Text = "50海里";
		RadioButton_TankerMaxDistance_Airborne_50.UseVisualStyleBackColor = false;
		RadioButton_TankerMaxDistance_Airborne_100.BackColor = Color.Transparent;
		RadioButton_TankerMaxDistance_Airborne_100.Cursor = Cursors.Hand;
		RadioButton_TankerMaxDistance_Airborne_100.Font = new Font("Segoe UI", 9f);
		RadioButton_TankerMaxDistance_Airborne_100.ForeColor = Color.FromArgb(209, 209, 209);
		RadioButton_TankerMaxDistance_Airborne_100.Location = new Point(6, 68);
		RadioButton_TankerMaxDistance_Airborne_100.Name = "RadioButton_TankerMaxDistance_Airborne_100";
		RadioButton_TankerMaxDistance_Airborne_100.Size = new Size(60, 21);
		RadioButton_TankerMaxDistance_Airborne_100.TabIndex = 3;
		RadioButton_TankerMaxDistance_Airborne_100.Text = "100海里";
		RadioButton_TankerMaxDistance_Airborne_100.UseVisualStyleBackColor = false;
		RadioButton_TankerMaxDistance_Airborne_250.BackColor = Color.Transparent;
		RadioButton_TankerMaxDistance_Airborne_250.Cursor = Cursors.Hand;
		RadioButton_TankerMaxDistance_Airborne_250.Font = new Font("Segoe UI", 9f);
		RadioButton_TankerMaxDistance_Airborne_250.ForeColor = Color.FromArgb(209, 209, 209);
		RadioButton_TankerMaxDistance_Airborne_250.Location = new Point(6, 51);
		RadioButton_TankerMaxDistance_Airborne_250.Name = "RadioButton_TankerMaxDistance_Airborne_250";
		RadioButton_TankerMaxDistance_Airborne_250.Size = new Size(60, 21);
		RadioButton_TankerMaxDistance_Airborne_250.TabIndex = 2;
		RadioButton_TankerMaxDistance_Airborne_250.Text = "250海里";
		RadioButton_TankerMaxDistance_Airborne_250.UseVisualStyleBackColor = false;
		RadioButton_TankerMaxDistance_Airborne_500.BackColor = Color.Transparent;
		RadioButton_TankerMaxDistance_Airborne_500.Cursor = Cursors.Hand;
		RadioButton_TankerMaxDistance_Airborne_500.Font = new Font("Segoe UI", 9f);
		RadioButton_TankerMaxDistance_Airborne_500.ForeColor = Color.FromArgb(209, 209, 209);
		RadioButton_TankerMaxDistance_Airborne_500.Location = new Point(6, 34);
		RadioButton_TankerMaxDistance_Airborne_500.Name = "RadioButton_TankerMaxDistance_Airborne_500";
		RadioButton_TankerMaxDistance_Airborne_500.Size = new Size(60, 21);
		RadioButton_TankerMaxDistance_Airborne_500.TabIndex = 1;
		RadioButton_TankerMaxDistance_Airborne_500.Text = "500海里";
		RadioButton_TankerMaxDistance_Airborne_500.UseVisualStyleBackColor = false;
		RadioButton_TankerMaxDistance_Airborne_Tactical.BackColor = Color.Transparent;
		RadioButton_TankerMaxDistance_Airborne_Tactical.Cursor = Cursors.Hand;
		RadioButton_TankerMaxDistance_Airborne_Tactical.Font = new Font("Segoe UI", 9f);
		RadioButton_TankerMaxDistance_Airborne_Tactical.ForeColor = Color.FromArgb(209, 209, 209);
		RadioButton_TankerMaxDistance_Airborne_Tactical.Location = new Point(6, 17);
		RadioButton_TankerMaxDistance_Airborne_Tactical.Name = "RadioButton_TankerMaxDistance_Airborne_Tactical";
		RadioButton_TankerMaxDistance_Airborne_Tactical.Size = new Size(381, 21);
		RadioButton_TankerMaxDistance_Airborne_Tactical.TabIndex = 0;
		RadioButton_TankerMaxDistance_Airborne_Tactical.Text = "接收飞机在当前的燃料和飞行剖面下的战术范围";
		RadioButton_TankerMaxDistance_Airborne_Tactical.UseVisualStyleBackColor = false;
		TextBox_TankerMinimum_Total.AutoCompleteCustomSource = null;
		TextBox_TankerMinimum_Total.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_TankerMinimum_Total.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_TankerMinimum_Total.BackColor = Color.Transparent;
		TextBox_TankerMinimum_Total.Font = new Font("Segoe UI", 8f);
		TextBox_TankerMinimum_Total.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_TankerMinimum_Total.Image = null;
		TextBox_TankerMinimum_Total.Lines = null;
		TextBox_TankerMinimum_Total.Location = new Point(317, 15);
		TextBox_TankerMinimum_Total.MaxLength = 32767;
		TextBox_TankerMinimum_Total.Multiline = false;
		TextBox_TankerMinimum_Total.Name = "TextBox_TankerMinimum_Total";
		TextBox_TankerMinimum_Total.ReadOnly = false;
		TextBox_TankerMinimum_Total.ScrollBars = ScrollBars.None;
		TextBox_TankerMinimum_Total.SelectionStart = 0;
		TextBox_TankerMinimum_Total.Size = new Size(100, 20);
		TextBox_TankerMinimum_Total.TabIndex = 6;
		TextBox_TankerMinimum_Total.TextAlign = HorizontalAlignment.Left;
		TextBox_TankerMinimum_Total.UseSystemPasswordChar = false;
		TextBox_TankerMinimum_Total.WatermarkText = "";
		Label1.Location = new Point(4, 17);
		Label1.Name = "Label1";
		Label1.Size = new Size(220, 13);
		Label1.TabIndex = 7;
		Label1.Text = "所需加油机的最小数量：";
		Label2.Location = new Point(4, 38);
		Label2.Name = "Label2";
		Label2.Size = new Size(220, 13);
		Label2.TabIndex = 9;
		Label2.Text = "空中加油机的最小数量：";
		TextBox_TankerMinimum_Airborne.AutoCompleteCustomSource = null;
		TextBox_TankerMinimum_Airborne.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_TankerMinimum_Airborne.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_TankerMinimum_Airborne.BackColor = Color.Transparent;
		TextBox_TankerMinimum_Airborne.Font = new Font("Segoe UI", 8f);
		TextBox_TankerMinimum_Airborne.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_TankerMinimum_Airborne.Image = null;
		TextBox_TankerMinimum_Airborne.Lines = null;
		TextBox_TankerMinimum_Airborne.Location = new Point(317, 36);
		TextBox_TankerMinimum_Airborne.MaxLength = 32767;
		TextBox_TankerMinimum_Airborne.Multiline = false;
		TextBox_TankerMinimum_Airborne.Name = "TextBox_TankerMinimum_Airborne";
		TextBox_TankerMinimum_Airborne.ReadOnly = false;
		TextBox_TankerMinimum_Airborne.ScrollBars = ScrollBars.None;
		TextBox_TankerMinimum_Airborne.SelectionStart = 0;
		TextBox_TankerMinimum_Airborne.Size = new Size(100, 20);
		TextBox_TankerMinimum_Airborne.TabIndex = 8;
		TextBox_TankerMinimum_Airborne.TextAlign = HorizontalAlignment.Left;
		TextBox_TankerMinimum_Airborne.UseSystemPasswordChar = false;
		TextBox_TankerMinimum_Airborne.WatermarkText = "";
		Label3.Location = new Point(4, 59);
		Label3.Name = "Label3";
		Label3.Size = new Size(250, 13);
		Label3.TabIndex = 11;
		Label3.Text = "最低加油机数量：";
		TextBox_TankerMinimum_Station.AutoCompleteCustomSource = null;
		TextBox_TankerMinimum_Station.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_TankerMinimum_Station.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_TankerMinimum_Station.BackColor = Color.Transparent;
		TextBox_TankerMinimum_Station.Font = new Font("Segoe UI", 8f);
		TextBox_TankerMinimum_Station.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_TankerMinimum_Station.Image = null;
		TextBox_TankerMinimum_Station.Lines = null;
		TextBox_TankerMinimum_Station.Location = new Point(317, 57);
		TextBox_TankerMinimum_Station.MaxLength = 32767;
		TextBox_TankerMinimum_Station.Multiline = false;
		TextBox_TankerMinimum_Station.Name = "TextBox_TankerMinimum_Station";
		TextBox_TankerMinimum_Station.ReadOnly = false;
		TextBox_TankerMinimum_Station.ScrollBars = ScrollBars.None;
		TextBox_TankerMinimum_Station.SelectionStart = 0;
		TextBox_TankerMinimum_Station.Size = new Size(100, 20);
		TextBox_TankerMinimum_Station.TabIndex = 10;
		TextBox_TankerMinimum_Station.TextAlign = HorizontalAlignment.Left;
		TextBox_TankerMinimum_Station.UseSystemPasswordChar = false;
		TextBox_TankerMinimum_Station.WatermarkText = "";
		ListBox_Tankers.Location = new Point(12, 50);
		ListBox_Tankers.Name = "ListBox_Tankers";
		ListBox_Tankers.MultiSelect = true;
		ListBox_Tankers.Size = new Size(334, 279);
		ListBox_Tankers.TabIndex = 15;
		Label6.Location = new Point(4, 22);
		Label6.Name = "Label6";
		Label6.Size = new Size(300, 13);
		Label6.TabIndex = 18;
		Label6.Text = "每个加油机队列中的最大飞机数量：";
		TextBox_MaxReceiversInQueuePerTanker_Airborne.AutoCompleteCustomSource = null;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.BackColor = Color.Transparent;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Font = new Font("Segoe UI", 8f);
		TextBox_MaxReceiversInQueuePerTanker_Airborne.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Image = null;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Lines = null;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Location = new Point(310, 20);
		TextBox_MaxReceiversInQueuePerTanker_Airborne.MaxLength = 32767;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Multiline = false;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Name = "TextBox_MaxReceiversInQueuePerTanker_Airborne";
		TextBox_MaxReceiversInQueuePerTanker_Airborne.ReadOnly = false;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.ScrollBars = ScrollBars.None;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.SelectionStart = 0;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.Size = new Size(104, 20);
		TextBox_MaxReceiversInQueuePerTanker_Airborne.TabIndex = 17;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.TextAlign = HorizontalAlignment.Left;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.UseSystemPasswordChar = false;
		TextBox_MaxReceiversInQueuePerTanker_Airborne.WatermarkText = "";
		CheckBox_LaunchMissionWithoutTankersInPlace.AutoSize = true;
		CheckBox_LaunchMissionWithoutTankersInPlace.Location = new Point(6, 78);
		CheckBox_LaunchMissionWithoutTankersInPlace.Name = "CheckBox_LaunchMissionWithoutTankersInPlace";
		CheckBox_LaunchMissionWithoutTankersInPlace.Size = new Size(331, 19);
		CheckBox_LaunchMissionWithoutTankersInPlace.TabIndex = 19;
		CheckBox_LaunchMissionWithoutTankersInPlace.Text = "在没有加油机的情况下启动任务（极其危险！）";
		CheckBox_LaunchMissionWithoutTankersInPlace.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox3.Controls.Add(Label1);
		GroupBox3.Controls.Add(TextBox_TankerMinimum_Total);
		GroupBox3.Controls.Add(CheckBox_LaunchMissionWithoutTankersInPlace);
		GroupBox3.Controls.Add(TextBox_TankerMinimum_Airborne);
		GroupBox3.Controls.Add(Label2);
		GroupBox3.Controls.Add(TextBox_TankerMinimum_Station);
		GroupBox3.Controls.Add(Label3);
		GroupBox3.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox3.Location = new Point(352, 12);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(423, 100);
		GroupBox3.TabIndex = 21;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "任务计划细节";
		GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox4.Controls.Add(Combo_FollowReceiversNumber);
		GroupBox4.Controls.Add(Label8);
		GroupBox4.Controls.Add(TextBox_FuelQtyToStartLookingForTanker);
		GroupBox4.Controls.Add(CB_FollowReceivers);
		GroupBox4.Controls.Add(Label7);
		GroupBox4.Controls.Add(TextBox_MaxReceiversInQueuePerTanker_Airborne);
		GroupBox4.Controls.Add(Label6);
		GroupBox4.ForeColor = Color.FromArgb(220, 220, 220);
		GroupBox4.Location = new Point(352, 118);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(423, 90);
		GroupBox4.TabIndex = 22;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "任务执行细节";
		Combo_FollowReceiversNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		Combo_FollowReceiversNumber.BackColor = Color.Transparent;
		Combo_FollowReceiversNumber.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_FollowReceiversNumber.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_FollowReceiversNumber.DropDownWidth = 500;
		Combo_FollowReceiversNumber.Font = new Font("Segoe UI", 7f);
		Combo_FollowReceiversNumber.FormattingEnabled = true;
		Combo_FollowReceiversNumber.Location = new Point(312, 62);
		Combo_FollowReceiversNumber.Name = "Combo_FollowReceiversNumber";
		Combo_FollowReceiversNumber.Size = new Size(102, 21);
		Combo_FollowReceiversNumber.TabIndex = 28;
		Label8.Location = new Point(300, 44);
		Label8.Name = "Label8";
		Label8.Size = new Size(115, 13);
		Label8.TabIndex = 21;
		Label8.Text = "任务燃料的百分比。";
		TextBox_FuelQtyToStartLookingForTanker.AutoCompleteCustomSource = null;
		TextBox_FuelQtyToStartLookingForTanker.AutoCompleteMode = AutoCompleteMode.None;
		TextBox_FuelQtyToStartLookingForTanker.AutoCompleteSource = AutoCompleteSource.None;
		TextBox_FuelQtyToStartLookingForTanker.BackColor = Color.Transparent;
		TextBox_FuelQtyToStartLookingForTanker.Font = new Font("Segoe UI", 8f);
		TextBox_FuelQtyToStartLookingForTanker.ForeColor = Color.FromArgb(189, 189, 189);
		TextBox_FuelQtyToStartLookingForTanker.Image = null;
		TextBox_FuelQtyToStartLookingForTanker.Lines = null;
		TextBox_FuelQtyToStartLookingForTanker.Location = new Point(267, 40);
		TextBox_FuelQtyToStartLookingForTanker.MaxLength = 32767;
		TextBox_FuelQtyToStartLookingForTanker.Multiline = false;
		TextBox_FuelQtyToStartLookingForTanker.Name = "TextBox_FuelQtyToStartLookingForTanker";
		TextBox_FuelQtyToStartLookingForTanker.ReadOnly = false;
		TextBox_FuelQtyToStartLookingForTanker.ScrollBars = ScrollBars.None;
		TextBox_FuelQtyToStartLookingForTanker.SelectionStart = 0;
		TextBox_FuelQtyToStartLookingForTanker.Size = new Size(32, 20);
		TextBox_FuelQtyToStartLookingForTanker.TabIndex = 19;
		TextBox_FuelQtyToStartLookingForTanker.TextAlign = HorizontalAlignment.Left;
		TextBox_FuelQtyToStartLookingForTanker.UseSystemPasswordChar = false;
		TextBox_FuelQtyToStartLookingForTanker.WatermarkText = "";
		CB_FollowReceivers.AutoSize = true;
		CB_FollowReceivers.Location = new Point(6, 64);
		CB_FollowReceivers.Name = "CB_FollowReceivers";
		CB_FollowReceivers.Size = new Size(309, 19);
		CB_FollowReceivers.TabIndex = 19;
		CB_FollowReceivers.Text = "加油机跟随飞机的飞行计划（途中加油）";
		CB_FollowReceivers.UseVisualStyleBackColor = true;
		Label7.Location = new Point(4, 43);
		Label7.Name = "Label7";
		Label7.Size = new Size(289, 17);
		Label7.TabIndex = 20;
		Label7.Text = "飞机开始寻找加油机";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(789, 335);
		base.Controls.Add(GroupBox4);
		base.Controls.Add(GroupBox3);
		base.Controls.Add(ListBox_Tankers);
		base.Controls.Add(GroupBox1);
		base.Controls.Add(RadioButton_Automatic);
		base.Controls.Add(RadioButton_Mission);
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		MinimumSize = new Size(805, 374);
		base.Name = "TankerPlanner";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "加油机规划";
		base.TopMost = true;
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void ChangeInterruptibleException()
	{
		ListBox_Tankers.Items.Clear();
		Side[] sides_ReadOnly = Client.CurrentScenario.Sides_ReadOnly;
		Side[] array = sides_ReadOnly;
		foreach (Side side in array)
		{
			if (side != Client.CurrentSide && !Module_Side.IsAlliedWithThisSide(side, Client.CurrentSide))
			{
				continue;
			}
			foreach (Mission item in side.Missions.OrderBy((Mission theMission) => theMission.Name))
			{
				if (item.MissionClass == Mission._MissionClass.Support || item.MissionClass == Mission._MissionClass.Ferry)
				{
					DarkListItem darkListItem = new DarkListItem();
					if (side == Client.CurrentSide)
					{
						darkListItem.Text = item.Name;
					}
					else
					{
						darkListItem.Text = item.Name + " (" + side.Name + ")";
					}
					darkListItem.Tag = item;
					ListBox_Tankers.Items.Add(darkListItem);
				}
			}
		}
		List<int> list = new List<int>();
		int num = ListBox_Tankers.Items.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (Information.IsNothing(TheMission))
			{
				if (!Information.IsNothing(TheWaypoint) && TheWaypoint.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
				{
					list.Add(i);
				}
			}
			else if (TheMission.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
			{
				list.Add(i);
			}
		}
		if (list.Count > 0)
		{
			ListBox_Tankers.SelectItems(list);
		}
	}

	private void InitInterruptibleException(object sender, EventArgs e)
	{
		if (!base.Visible)
		{
			return;
		}
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				switch (TheWaypoint.TankerUsage)
				{
				case Mission.TankerMethod.Mission:
					RadioButton_Automatic.Checked = false;
					RadioButton_Mission.Checked = true;
					break;
				case Mission.TankerMethod.Automatic:
					RadioButton_Automatic.Checked = true;
					RadioButton_Mission.Checked = false;
					break;
				}
			}
		}
		else
		{
			switch (TheMission.TankerUsage)
			{
			case Mission.TankerMethod.Mission:
				RadioButton_Automatic.Checked = false;
				RadioButton_Mission.Checked = true;
				break;
			case Mission.TankerMethod.Automatic:
				RadioButton_Automatic.Checked = true;
				RadioButton_Mission.Checked = false;
				break;
			}
		}
		ConcatInterruptibleException();
	}

	private void CheckInterruptibleException(object sender, FormClosingEventArgs e)
	{
		e.Cancel = true;
		try
		{
			UpdateInterruptibleException();
			InsertInterruptibleException();
			PrepareInterruptibleException();
			ReflectInterruptibleException();
			VisitInterruptibleException();
			if (Information.IsNothing(TheMission))
			{
				if (!Information.IsNothing(TheWaypoint) && TheWaypoint.TankerUsage == Mission.TankerMethod.Mission && TheWaypoint.TankerMissions.Count == 0)
				{
					TheWaypoint.TankerUsage = Mission.TankerMethod.Automatic;
				}
			}
			else if (TheMission.TankerUsage == Mission.TankerMethod.Mission && TheMission.TankerMissions.Count == 0)
			{
				TheMission.TankerUsage = Mission.TankerMethod.Automatic;
			}
			Hide();
			ListBox_Tankers.Select();
			Client.MissionEditorWindow.BringToFront();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			Hide();
			if (Client.MissionEditorWindow != null && Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.BringToFront();
			}
			exception_?.Data.Add("Error at 9876245", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void ConcatInterruptibleException()
	{
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TextBox_FuelQtyToStartLookingForTanker.Enabled = false;
				Label7.Enabled = false;
				Label8.Enabled = false;
				GroupBox1.Enabled = true;
				GroupBox4.Enabled = true;
				GroupBox3.Enabled = false;
				switch (TheWaypoint.TankerUsage)
				{
				case Mission.TankerMethod.Mission:
					ListBox_Tankers.Enabled = true;
					ChangeInterruptibleException();
					break;
				case Mission.TankerMethod.Automatic:
					ListBox_Tankers.Enabled = false;
					ListBox_Tankers.Items.Clear();
					break;
				}
				if (TheWaypoint.TankerFollowsReceivers)
				{
					Combo_FollowReceiversNumber.Enabled = true;
				}
				else
				{
					Combo_FollowReceiversNumber.Enabled = false;
				}
			}
		}
		else
		{
			TextBox_FuelQtyToStartLookingForTanker.Enabled = true;
			Label7.Enabled = true;
			Label8.Enabled = true;
			Combo_FollowReceiversNumber.Enabled = false;
			GroupBox1.Enabled = true;
			GroupBox3.Enabled = true;
			GroupBox4.Enabled = true;
			CheckBox_LaunchMissionWithoutTankersInPlace.Enabled = true;
			switch (TheMission.TankerUsage)
			{
			case Mission.TankerMethod.Mission:
				ListBox_Tankers.Enabled = true;
				TextBox_TankerMinimum_Total.Enabled = true;
				TextBox_TankerMinimum_Airborne.Enabled = true;
				TextBox_TankerMinimum_Station.Enabled = true;
				Label1.Enabled = true;
				Label2.Enabled = true;
				Label3.Enabled = true;
				ChangeInterruptibleException();
				break;
			case Mission.TankerMethod.Automatic:
				ListBox_Tankers.Enabled = false;
				TextBox_TankerMinimum_Total.Enabled = false;
				TextBox_TankerMinimum_Airborne.Enabled = false;
				TextBox_TankerMinimum_Station.Enabled = false;
				Label1.Enabled = false;
				Label2.Enabled = false;
				Label3.Enabled = false;
				ListBox_Tankers.Items.Clear();
				break;
			}
		}
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint) && TheWaypoint.TankerUsage == Mission.TankerMethod.Mission)
			{
				TextBox_TankerMinimum_Total.Text = "N/A";
				TextBox_TankerMinimum_Airborne.Text = "N/A";
				TextBox_TankerMinimum_Station.Text = "N/A";
				CheckBox_LaunchMissionWithoutTankersInPlace.Checked = false;
			}
		}
		else if (TheMission.TankerUsage == Mission.TankerMethod.Mission)
		{
			if (TheMission.TankerMinNumber_Total <= 0)
			{
				TextBox_TankerMinimum_Total.Text = "未标明";
			}
			else
			{
				TextBox_TankerMinimum_Total.Text = Conversions.ToString(TheMission.TankerMinNumber_Total);
			}
			if (TheMission.TankerMinNumber_Airborne <= 0)
			{
				TextBox_TankerMinimum_Airborne.Text = "未标明";
			}
			else
			{
				TextBox_TankerMinimum_Airborne.Text = Conversions.ToString(TheMission.TankerMinNumber_Airborne);
			}
			if (TheMission.TankerMinNumber_Station <= 0)
			{
				TextBox_TankerMinimum_Station.Text = "未标明";
			}
			else
			{
				TextBox_TankerMinimum_Station.Text = Conversions.ToString(TheMission.TankerMinNumber_Station);
			}
			CheckBox_LaunchMissionWithoutTankersInPlace.Checked = TheMission.LaunchMissionWithoutTankersInPlace;
		}
		DataTable dataTable_ = new DataTable();
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				CB_FollowReceivers.Checked = TheWaypoint.TankerFollowsReceivers;
				if (TheWaypoint.MaxReceiversInQueuePerTanker_Airborne <= 0)
				{
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "未标明";
				}
				else
				{
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(TheWaypoint.MaxReceiversInQueuePerTanker_Airborne);
				}
				TextBox_FuelQtyToStartLookingForTanker.Text = "N/A";
				ComboBox comboBox_ = Combo_FollowReceiversNumber;
				ComboBox_FollowReceiversNumber(ref comboBox_, ref dataTable_, TheWaypoint.TankerFollowsReceivers_NumberOfWaypoints);
				Combo_FollowReceiversNumber = (DarkUIComboBox)comboBox_;
			}
		}
		else
		{
			CB_FollowReceivers.Checked = TheMission.TankerFollowsReceivers;
			if (TheMission.MaxReceiversInQueuePerTanker_Airborne <= 0)
			{
				TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "未标明";
			}
			else
			{
				TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(TheMission.MaxReceiversInQueuePerTanker_Airborne);
			}
			if (TheMission.FuelQtyToStartLookingForTanker_Airborne <= 0)
			{
				TextBox_FuelQtyToStartLookingForTanker.Text = "无";
			}
			else
			{
				TextBox_FuelQtyToStartLookingForTanker.Text = Conversions.ToString(TheMission.FuelQtyToStartLookingForTanker_Airborne);
			}
			Combo_FollowReceiversNumber.SelectedIndex = -1;
		}
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				if (TheWaypoint.TankerMaxDistance_Airborne == int.MaxValue)
				{
					RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = true;
					RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
				}
				else if (TheWaypoint.TankerMaxDistance_Airborne == 500)
				{
					RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_500.Checked = true;
					RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
				}
				else if (TheWaypoint.TankerMaxDistance_Airborne == 250)
				{
					RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_250.Checked = true;
					RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
				}
				else if (TheWaypoint.TankerMaxDistance_Airborne == 100)
				{
					RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_100.Checked = true;
					RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
				}
				else if (TheWaypoint.TankerMaxDistance_Airborne == 50)
				{
					RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
					RadioButton_TankerMaxDistance_Airborne_50.Checked = true;
				}
			}
		}
		else if (TheMission.TankerMaxDistance_Airborne == int.MaxValue)
		{
			RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = true;
			RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
		}
		else if (TheMission.TankerMaxDistance_Airborne == 500)
		{
			RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_500.Checked = true;
			RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
		}
		else if (TheMission.TankerMaxDistance_Airborne == 250)
		{
			RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_250.Checked = true;
			RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
		}
		else if (TheMission.TankerMaxDistance_Airborne == 100)
		{
			RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_100.Checked = true;
			RadioButton_TankerMaxDistance_Airborne_50.Checked = false;
		}
		else if (TheMission.TankerMaxDistance_Airborne == 50)
		{
			RadioButton_TankerMaxDistance_Airborne_Tactical.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_500.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_250.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_100.Checked = false;
			RadioButton_TankerMaxDistance_Airborne_50.Checked = true;
		}
	}

	public static void ComboBox_FollowReceiversNumber(ref ComboBox comboBox_0, ref DataTable dataTable_0, int int_0)
	{
		if (!dataTable_0.Columns.Contains("ID"))
		{
			dataTable_0.Columns.Add("ID", typeof(int));
		}
		if (!dataTable_0.Columns.Contains("Description"))
		{
			dataTable_0.Columns.Add("Description", typeof(string));
		}
		dataTable_0.Rows.Add(0, Mission.GetTankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilFull));
		dataTable_0.Rows.Add(1, Mission.GetTankerFollowsReceiverString(Mission._TankerFollowsReceiver.Waypoint1));
		dataTable_0.Rows.Add(2, Mission.GetTankerFollowsReceiverString(Mission._TankerFollowsReceiver.Waypoint2));
		dataTable_0.Rows.Add(3, Mission.GetTankerFollowsReceiverString(Mission._TankerFollowsReceiver.Weaypoin3));
		dataTable_0.Rows.Add(4, Mission.GetTankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilHoldWaypoint));
		dataTable_0.Rows.Add(5, Mission.GetTankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilStationWaypoint));
		dataTable_0.Rows.Add(6, Mission.GetTankerFollowsReceiverString(Mission._TankerFollowsReceiver.UntilLandingMarshalWaypoint));
		ComboBox obj = comboBox_0;
		obj.DataSource = dataTable_0;
		obj.DisplayMember = "Description";
		obj.ValueMember = "ID";
		obj.SelectedIndex = Mission.FollowReceiversNumber_To_FollowReceiversSelection(int_0);
	}

	private void InterruptInterruptibleException(object sender, KeyEventArgs e)
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

	private void RemoveInterruptibleException(object sender, EventArgs e)
	{
		int num = ListBox_Tankers.Items.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (ListBox_Tankers.SelectedItems.Contains(ListBox_Tankers.Items[i]))
			{
				if (Information.IsNothing(TheMission))
				{
					if (!Information.IsNothing(TheWaypoint) && !TheWaypoint.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
					{
						TheWaypoint.TankerMissions.Add((Mission)ListBox_Tankers.Items[i].Tag);
					}
				}
				else if (!TheMission.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
				{
					TheMission.TankerMissions.Add((Mission)ListBox_Tankers.Items[i].Tag);
				}
			}
			else if (Information.IsNothing(TheMission))
			{
				if (!Information.IsNothing(TheWaypoint) && TheWaypoint.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
				{
					TheWaypoint.TankerMissions.Remove((Mission)ListBox_Tankers.Items[i].Tag);
				}
			}
			else if (TheMission.TankerMissions.Contains((Mission)ListBox_Tankers.Items[i].Tag))
			{
				TheMission.TankerMissions.Remove((Mission)ListBox_Tankers.Items[i].Tag);
			}
		}
	}

	private void FindInterruptibleException(object sender, EventArgs e)
	{
		stateException = true;
	}

	private void SetInterruptibleException(object sender, EventArgs e)
	{
		UpdateInterruptibleException();
	}

	private void FillInterruptibleException(object sender, EventArgs e)
	{
		m_AuthenticationException = true;
	}

	private void CalculateInterruptibleException(object sender, EventArgs e)
	{
		InsertInterruptibleException();
	}

	private void PopInterruptibleException(object sender, EventArgs e)
	{
		_ParamsException = true;
	}

	private void InstantiateInterruptibleException(object sender, EventArgs e)
	{
		PrepareInterruptibleException();
	}

	private void CreateInterruptibleException(object sender, EventArgs e)
	{
		m_HelperException = true;
	}

	private void CompareInterruptibleException(object sender, EventArgs e)
	{
		ReflectInterruptibleException();
	}

	private void ReadInterruptibleException(object sender, EventArgs e)
	{
		m_MapperException = true;
	}

	private void DisableInterruptibleException(object sender, EventArgs e)
	{
		VisitInterruptibleException();
	}

	private void UpdateInterruptibleException()
	{
		if (stateException)
		{
			if (Information.IsNothing(TheMission))
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_TankerMinimum_Total.Text))
			{
				TheMission.TankerMinNumber_Total = 0;
				TextBox_TankerMinimum_Total.Text = "未标明";
			}
			if (!Versioned.IsNumeric(TextBox_TankerMinimum_Total.Text))
			{
				return;
			}
			int num = Conversions.ToInteger(TextBox_TankerMinimum_Total.Text);
			if (num < 0)
			{
				num = 0;
			}
			TheMission.TankerMinNumber_Total = num;
			if (num == 0)
			{
				TextBox_TankerMinimum_Total.Text = "未标明";
			}
			else
			{
				TextBox_TankerMinimum_Total.Text = Conversions.ToString(num);
			}
		}
		stateException = false;
	}

	private void InsertInterruptibleException()
	{
		if (m_AuthenticationException)
		{
			if (Information.IsNothing(TheMission))
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_TankerMinimum_Airborne.Text))
			{
				TheMission.TankerMinNumber_Airborne = 0;
				TextBox_TankerMinimum_Airborne.Text = "未标明";
			}
			if (!Versioned.IsNumeric(TextBox_TankerMinimum_Airborne.Text))
			{
				return;
			}
			int num = Conversions.ToInteger(TextBox_TankerMinimum_Airborne.Text);
			if (num < 0)
			{
				num = 0;
			}
			TheMission.TankerMinNumber_Airborne = num;
			if (num == 0)
			{
				TextBox_TankerMinimum_Airborne.Text = "未标明";
			}
			else
			{
				TextBox_TankerMinimum_Airborne.Text = Conversions.ToString(num);
			}
		}
		m_AuthenticationException = false;
	}

	private void PrepareInterruptibleException()
	{
		if (_ParamsException)
		{
			if (Information.IsNothing(TheMission))
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_TankerMinimum_Station.Text))
			{
				TheMission.TankerMinNumber_Station = 0;
				TextBox_TankerMinimum_Station.Text = "未标明";
			}
			if (!Versioned.IsNumeric(TextBox_TankerMinimum_Station.Text))
			{
				return;
			}
			int num = Conversions.ToInteger(TextBox_TankerMinimum_Station.Text);
			if (num < 0)
			{
				num = 0;
			}
			TheMission.TankerMinNumber_Station = num;
			if (num == 0)
			{
				TextBox_TankerMinimum_Station.Text = "未标明";
			}
			else
			{
				TextBox_TankerMinimum_Station.Text = Conversions.ToString(num);
			}
		}
		_ParamsException = false;
	}

	private void ReflectInterruptibleException()
	{
		if (m_HelperException)
		{
			if (Information.IsNothing(TheMission))
			{
				if (!Information.IsNothing(TheWaypoint))
				{
					if (string.IsNullOrEmpty(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
					{
						TheWaypoint.MaxReceiversInQueuePerTanker_Airborne = 0;
						TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "未标明";
					}
					if (!Versioned.IsNumeric(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
					{
						return;
					}
					int num = Conversions.ToInteger(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text);
					if (num < 0)
					{
						num = 0;
					}
					TheWaypoint.MaxReceiversInQueuePerTanker_Airborne = num;
					if (num == 0)
					{
						TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "未标明";
					}
					else
					{
						TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(num);
					}
				}
			}
			else
			{
				if (string.IsNullOrEmpty(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
				{
					TheMission.MaxReceiversInQueuePerTanker_Airborne = 0;
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "未标明";
				}
				if (!Versioned.IsNumeric(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text))
				{
					return;
				}
				int num2 = Conversions.ToInteger(TextBox_MaxReceiversInQueuePerTanker_Airborne.Text);
				if (num2 < 0)
				{
					num2 = 0;
				}
				TheMission.MaxReceiversInQueuePerTanker_Airborne = num2;
				if (num2 == 0)
				{
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = "未标明";
				}
				else
				{
					TextBox_MaxReceiversInQueuePerTanker_Airborne.Text = Conversions.ToString(num2);
				}
			}
		}
		m_HelperException = false;
	}

	private void VisitInterruptibleException()
	{
		if (m_MapperException)
		{
			if (TheMission == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(TextBox_FuelQtyToStartLookingForTanker.Text))
			{
				TheMission.SetDefaultFuelQtyToStartLookingForTanker_Airborne();
				TextBox_FuelQtyToStartLookingForTanker.Text = Conversions.ToString(TheMission.FuelQtyToStartLookingForTanker_Airborne);
			}
			else
			{
				if (!Versioned.IsNumeric(TextBox_FuelQtyToStartLookingForTanker.Text))
				{
					return;
				}
				int num = Conversions.ToInteger(TextBox_FuelQtyToStartLookingForTanker.Text);
				if (num <= 90)
				{
					if (num < 0)
					{
						TextBox_FuelQtyToStartLookingForTanker.Text = "0";
						TheMission.FuelQtyToStartLookingForTanker_Airborne = 0;
					}
					else
					{
						TheMission.FuelQtyToStartLookingForTanker_Airborne = num;
					}
				}
				else
				{
					TextBox_FuelQtyToStartLookingForTanker.Text = "90";
					TheMission.FuelQtyToStartLookingForTanker_Airborne = 90;
				}
			}
		}
		m_MapperException = false;
	}

	private void RestartInterruptibleException(object sender, EventArgs e)
	{
		if (!RadioButton_Mission.Checked)
		{
			return;
		}
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerUsage = Mission.TankerMethod.Mission;
			}
		}
		else
		{
			TheMission.TankerUsage = Mission.TankerMethod.Mission;
		}
		ConcatInterruptibleException();
	}

	private void TestInterruptibleException(object sender, EventArgs e)
	{
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = int.MaxValue;
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = int.MaxValue;
		}
	}

	private void StopInterruptibleException(object sender, EventArgs e)
	{
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = 500;
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = 500;
		}
	}

	private void CancelInterruptibleException(object sender, EventArgs e)
	{
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = 250;
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = 250;
		}
	}

	private void VerifyInterruptibleException(object sender, EventArgs e)
	{
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = 100;
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = 100;
		}
	}

	private void ListInterruptibleException(object sender, EventArgs e)
	{
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerMaxDistance_Airborne = 50;
			}
		}
		else
		{
			TheMission.TankerMaxDistance_Airborne = 50;
		}
	}

	private void ResolveInterruptibleException(object sender, EventArgs e)
	{
		if (!Information.IsNothing(TheMission))
		{
			TheMission.LaunchMissionWithoutTankersInPlace = CheckBox_LaunchMissionWithoutTankersInPlace.Checked;
		}
	}

	private void PostInterruptibleException(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
	}

	private void RunInterruptibleException(object sender, EventArgs e)
	{
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerFollowsReceivers = CB_FollowReceivers.Checked;
				if (TheWaypoint.TankerFollowsReceivers)
				{
					Combo_FollowReceiversNumber.Enabled = true;
				}
				else
				{
					Combo_FollowReceiversNumber.Enabled = false;
				}
			}
		}
		else
		{
			TheMission.TankerFollowsReceivers = CB_FollowReceivers.Checked;
		}
	}

	private void StartInterruptibleException(object sender, EventArgs e)
	{
		if (!RadioButton_Automatic.Checked)
		{
			return;
		}
		if (Information.IsNothing(TheMission))
		{
			if (!Information.IsNothing(TheWaypoint))
			{
				TheWaypoint.TankerUsage = Mission.TankerMethod.Automatic;
			}
		}
		else
		{
			TheMission.TankerUsage = Mission.TankerMethod.Automatic;
		}
		ConcatInterruptibleException();
	}

	private void AssetInterruptibleException(object sender, EventArgs e)
	{
		if (!Information.IsNothing(TheWaypoint))
		{
			TheWaypoint.TankerFollowsReceivers_NumberOfWaypoints = (int)Mission.FollowReceiversSelection_To_FollowReceiversNumber(Combo_FollowReceiversNumber.SelectedIndex);
		}
	}
}
