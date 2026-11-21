using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MultiplayerForm : Form
{
	private IContainer m_ComparatorResolver;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private Label m_ItemResolver;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private GroupBox creatorResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("ConnectButton")]
	private Button m_MappingResolver;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private Label mockResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("TeamsTreeView")]
	private TreeView queueResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox regResolver;

	[AccessedThroughProperty("GroupBox5")]
	[CompilerGenerated]
	private GroupBox pageResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox m_RulesResolver;

	[AccessedThroughProperty("JoinTeamButton")]
	[CompilerGenerated]
	private Button m_MethodResolver;

	[AccessedThroughProperty("DisconnectButton")]
	[CompilerGenerated]
	private Button systemResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("ObserverButton")]
	private Button candidateResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("UmpireButton")]
	private Button baseResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("PortTextBox")]
	private TextBox m_PolicyResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox printerResolver;

	[AccessedThroughProperty("ClearLogButton")]
	[CompilerGenerated]
	private Button m_ParserResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox7")]
	private GroupBox algoResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("GlobalChatButton")]
	private Button interceptorResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("GlobalChatInputTextBox")]
	private TextBox m_MessageResolver;

	[AccessedThroughProperty("TeamChatButton")]
	[CompilerGenerated]
	private Button productResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("TeamChatTextBox")]
	private RichTextBox m_InitializerResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox9")]
	private GroupBox roleResolver;

	[AccessedThroughProperty("CommitTurnButton")]
	[CompilerGenerated]
	private Button factoryResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("MultiplayerStatusRichTextBox")]
	private RichTextBox attributeResolver;

	[AccessedThroughProperty("GroupBox10")]
	[CompilerGenerated]
	private GroupBox eventResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("TurnReplay_ReturnToPresent")]
	private Button m_GlobalResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("TurnReplayListBox")]
	private ListBox workerResolver;

	[AccessedThroughProperty("TurnReplay_Prev")]
	[CompilerGenerated]
	private Button accountResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("TurnReplay_Play")]
	private Button m_StateResolver;

	[AccessedThroughProperty("TurnReplay_Next")]
	[CompilerGenerated]
	private Button authenticationResolver;

	[AccessedThroughProperty("TurnReplay_Pause")]
	[CompilerGenerated]
	private Button paramsResolver;

	[AccessedThroughProperty("MultiplayerOptionsGroupBox")]
	[CompilerGenerated]
	private GroupBox helperResolver;

	[AccessedThroughProperty("MPRuleScenarioEndButton")]
	[CompilerGenerated]
	private CheckBox m_MapperResolver;

	[AccessedThroughProperty("SpeedChessGroupBox")]
	[CompilerGenerated]
	private GroupBox m_GetterResolver;

	[CompilerGenerated]
	[AccessedThroughProperty("SpeedChess_EventLabel")]
	private Label producerResolver;

	[AccessedThroughProperty("SpeedChess_MoreTimeRequestButton3")]
	[CompilerGenerated]
	private Button m_StructPublisher;

	[AccessedThroughProperty("SpeedChess_MoreTimeRequestButton2")]
	[CompilerGenerated]
	private Button merchantPublisher;

	[CompilerGenerated]
	[AccessedThroughProperty("SpecialNoticeLabel")]
	private Label callbackPublisher;

	[AccessedThroughProperty("UmpireResumeButton")]
	[CompilerGenerated]
	private Button m_ThreadPublisher;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	private Label m_InstancePublisher;

	internal Label Label1
	{
		[CompilerGenerated]
		get
		{
			return m_ItemResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ItemResolver = value;
		}
	}

	[field: AccessedThroughProperty("UsernameTextBox")]
	internal TextBox UsernameTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return creatorResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			creatorResolver = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox2")]
	internal GroupBox GroupBox2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Button ConnectButton
	{
		[CompilerGenerated]
		get
		{
			return m_MappingResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MappingResolver = value;
		}
	}

	internal Label Label2
	{
		[CompilerGenerated]
		get
		{
			return mockResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mockResolver = value;
		}
	}

	[field: AccessedThroughProperty("IPTextBox")]
	internal TextBox TextBox_0
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LogListBox")]
	internal ListBox LogListBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal TreeView TeamsTreeView
	{
		[CompilerGenerated]
		get
		{
			return queueResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			queueResolver = value;
		}
	}

	internal GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return regResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			regResolver = value;
		}
	}

	[field: AccessedThroughProperty("ScenarioNameTextBox")]
	internal TextBox ScenarioNameTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return pageResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pageResolver = value;
		}
	}

	internal GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return m_RulesResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RulesResolver = value;
		}
	}

	internal Button JoinTeamButton
	{
		[CompilerGenerated]
		get
		{
			return m_MethodResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MethodResolver = value;
		}
	}

	[field: AccessedThroughProperty("PlayersListBox")]
	internal ListBox PlayersListBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Button DisconnectButton
	{
		[CompilerGenerated]
		get
		{
			return systemResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			systemResolver = value;
		}
	}

	internal Button ObserverButton
	{
		[CompilerGenerated]
		get
		{
			return candidateResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			candidateResolver = value;
		}
	}

	internal Button UmpireButton
	{
		[CompilerGenerated]
		get
		{
			return baseResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			baseResolver = value;
		}
	}

	internal TextBox PortTextBox
	{
		[CompilerGenerated]
		get
		{
			return m_PolicyResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PolicyResolver = value;
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TeamNameTextBox")]
	internal TextBox TeamNameTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return printerResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerResolver = value;
		}
	}

	internal Button ClearLogButton
	{
		[CompilerGenerated]
		get
		{
			return m_ParserResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ParserResolver = value;
		}
	}

	internal GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return algoResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			algoResolver = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox8")]
	internal GroupBox GroupBox8
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Button GlobalChatButton
	{
		[CompilerGenerated]
		get
		{
			return interceptorResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interceptorResolver = value;
		}
	}

	internal TextBox GlobalChatInputTextBox
	{
		[CompilerGenerated]
		get
		{
			return m_MessageResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MessageResolver = value;
		}
	}

	internal Button TeamChatButton
	{
		[CompilerGenerated]
		get
		{
			return productResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			productResolver = value;
		}
	}

	[field: AccessedThroughProperty("TeamChatInputTextBox")]
	internal TextBox TeamChatInputTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GlobalChatTextBox")]
	internal RichTextBox GlobalChatTextBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal RichTextBox TeamChatTextBox
	{
		[CompilerGenerated]
		get
		{
			return m_InitializerResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InitializerResolver = value;
		}
	}

	internal GroupBox GroupBox9
	{
		[CompilerGenerated]
		get
		{
			return roleResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			roleResolver = value;
		}
	}

	internal Button CommitTurnButton
	{
		[CompilerGenerated]
		get
		{
			return factoryResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			factoryResolver = value;
		}
	}

	internal RichTextBox MultiplayerStatusRichTextBox
	{
		[CompilerGenerated]
		get
		{
			return attributeResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			attributeResolver = value;
		}
	}

	internal GroupBox GroupBox_0
	{
		[CompilerGenerated]
		get
		{
			return eventResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eventResolver = value;
		}
	}

	internal Button TurnReplay_ReturnToPresent
	{
		[CompilerGenerated]
		get
		{
			return m_GlobalResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GlobalResolver = value;
		}
	}

	internal ListBox TurnReplayListBox
	{
		[CompilerGenerated]
		get
		{
			return workerResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			workerResolver = value;
		}
	}

	internal Button TurnReplay_Prev
	{
		[CompilerGenerated]
		get
		{
			return accountResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			accountResolver = value;
		}
	}

	internal Button TurnReplay_Play
	{
		[CompilerGenerated]
		get
		{
			return m_StateResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StateResolver = value;
		}
	}

	internal Button TurnReplay_Next
	{
		[CompilerGenerated]
		get
		{
			return authenticationResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			authenticationResolver = value;
		}
	}

	internal Button TurnReplay_Pause
	{
		[CompilerGenerated]
		get
		{
			return paramsResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramsResolver = value;
		}
	}

	[field: AccessedThroughProperty("Label4")]
	internal Label Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GroupBox MultiplayerOptionsGroupBox
	{
		[CompilerGenerated]
		get
		{
			return helperResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			helperResolver = value;
		}
	}

	internal CheckBox MPRuleScenarioEndButton
	{
		[CompilerGenerated]
		get
		{
			return m_MapperResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_MapperResolver = value;
		}
	}

	[field: AccessedThroughProperty("SpeedChess_CommitCountdownLabel")]
	internal Label SpeedChess_CommitCountdownLabel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal GroupBox SpeedChessGroupBox
	{
		[CompilerGenerated]
		get
		{
			return m_GetterResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_GetterResolver = value;
		}
	}

	internal Label SpeedChess_EventLabel
	{
		[CompilerGenerated]
		get
		{
			return producerResolver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			producerResolver = value;
		}
	}

	[field: AccessedThroughProperty("SpeedChess_MoreTimeRequestButton1")]
	internal Button SpeedChess_MoreTimeRequestButton1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Button SpeedChess_MoreTimeRequestButton3
	{
		[CompilerGenerated]
		get
		{
			return m_StructPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StructPublisher = value;
		}
	}

	internal Button SpeedChess_MoreTimeRequestButton2
	{
		[CompilerGenerated]
		get
		{
			return merchantPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			merchantPublisher = value;
		}
	}

	internal Label SpecialNoticeLabel
	{
		[CompilerGenerated]
		get
		{
			return callbackPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			callbackPublisher = value;
		}
	}

	[field: AccessedThroughProperty("TimeTableComboBox")]
	internal ComboBox TimeTableComboBox
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("UmpirePauseButton")]
	internal Button UmpirePauseButton
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Button UmpireResumeButton
	{
		[CompilerGenerated]
		get
		{
			return m_ThreadPublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ThreadPublisher = value;
		}
	}

	[field: AccessedThroughProperty("ForceCommitButton")]
	internal Button ForceCommitButton
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label5")]
	internal Label Label5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal Label Label6
	{
		[CompilerGenerated]
		get
		{
			return m_InstancePublisher;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_InstancePublisher = value;
		}
	}

	[field: AccessedThroughProperty("Label7")]
	internal Label Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("AbortExecutionButton")]
	internal Button AbortExecutionButton
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public MultiplayerForm()
	{
		CloneInterruptibleFilter();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && m_ComparatorResolver != null)
			{
				m_ComparatorResolver.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void CloneInterruptibleFilter()
	{
		Label1 = new Label();
		UsernameTextBox = new TextBox();
		GroupBox1 = new GroupBox();
		Label3 = new Label();
		TeamNameTextBox = new TextBox();
		GroupBox2 = new GroupBox();
		PortTextBox = new TextBox();
		DisconnectButton = new Button();
		ConnectButton = new Button();
		Label4 = new Label();
		Label2 = new Label();
		TextBox_0 = new TextBox();
		LogListBox = new ListBox();
		TeamsTreeView = new TreeView();
		GroupBox3 = new GroupBox();
		GroupBox5 = new GroupBox();
		UmpireButton = new Button();
		ObserverButton = new Button();
		PlayersListBox = new ListBox();
		GroupBox4 = new GroupBox();
		JoinTeamButton = new Button();
		ScenarioNameTextBox = new TextBox();
		GroupBox6 = new GroupBox();
		ClearLogButton = new Button();
		GroupBox7 = new GroupBox();
		GlobalChatTextBox = new RichTextBox();
		GlobalChatButton = new Button();
		GlobalChatInputTextBox = new TextBox();
		GroupBox8 = new GroupBox();
		TeamChatTextBox = new RichTextBox();
		TeamChatButton = new Button();
		TeamChatInputTextBox = new TextBox();
		GroupBox9 = new GroupBox();
		MultiplayerStatusRichTextBox = new RichTextBox();
		CommitTurnButton = new Button();
		GroupBox_0 = new GroupBox();
		TurnReplay_Pause = new Button();
		TurnReplay_Play = new Button();
		TurnReplay_Next = new Button();
		TurnReplay_Prev = new Button();
		TurnReplayListBox = new ListBox();
		TurnReplay_ReturnToPresent = new Button();
		MultiplayerOptionsGroupBox = new GroupBox();
		SpecialNoticeLabel = new Label();
		MPRuleScenarioEndButton = new CheckBox();
		SpeedChess_CommitCountdownLabel = new Label();
		SpeedChessGroupBox = new GroupBox();
		SpeedChess_MoreTimeRequestButton3 = new Button();
		SpeedChess_MoreTimeRequestButton2 = new Button();
		SpeedChess_MoreTimeRequestButton1 = new Button();
		SpeedChess_EventLabel = new Label();
		TimeTableComboBox = new ComboBox();
		UmpirePauseButton = new Button();
		UmpireResumeButton = new Button();
		ForceCommitButton = new Button();
		Label5 = new Label();
		Label6 = new Label();
		Label7 = new Label();
		AbortExecutionButton = new Button();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox6.SuspendLayout();
		GroupBox7.SuspendLayout();
		GroupBox8.SuspendLayout();
		GroupBox9.SuspendLayout();
		GroupBox_0.SuspendLayout();
		MultiplayerOptionsGroupBox.SuspendLayout();
		SpeedChessGroupBox.SuspendLayout();
		SuspendLayout();
		Label1.AutoSize = true;
		Label1.Location = new Point(6, 16);
		Label1.Name = "Label1";
		Label1.Size = new Size(55, 13);
		Label1.TabIndex = 0;
		Label1.Text = "Username";
		UsernameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		UsernameTextBox.Location = new Point(9, 32);
		UsernameTextBox.Name = "UsernameTextBox";
		UsernameTextBox.Size = new Size(211, 20);
		UsernameTextBox.TabIndex = 1;
		GroupBox1.Controls.Add(Label3);
		GroupBox1.Controls.Add(TeamNameTextBox);
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(UsernameTextBox);
		GroupBox1.Location = new Point(12, 12);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(226, 89);
		GroupBox1.TabIndex = 2;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Player Information";
		Label3.AutoSize = true;
		Label3.Location = new Point(10, 58);
		Label3.Name = "Label3";
		Label3.Size = new Size(34, 13);
		Label3.TabIndex = 3;
		Label3.Text = "Team";
		TeamNameTextBox.Location = new Point(50, 58);
		TeamNameTextBox.Name = "TeamNameTextBox";
		TeamNameTextBox.ReadOnly = true;
		TeamNameTextBox.Size = new Size(170, 20);
		TeamNameTextBox.TabIndex = 2;
		GroupBox2.Controls.Add(PortTextBox);
		GroupBox2.Controls.Add(DisconnectButton);
		GroupBox2.Controls.Add(ConnectButton);
		GroupBox2.Controls.Add(Label4);
		GroupBox2.Controls.Add(Label2);
		GroupBox2.Controls.Add(TextBox_0);
		GroupBox2.Location = new Point(13, 107);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(226, 94);
		GroupBox2.TabIndex = 3;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Remote Computer";
		PortTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		PortTextBox.Location = new Point(145, 32);
		PortTextBox.MaxLength = 8;
		PortTextBox.Name = "PortTextBox";
		PortTextBox.Size = new Size(75, 20);
		PortTextBox.TabIndex = 4;
		DisconnectButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		DisconnectButton.Location = new Point(145, 59);
		DisconnectButton.Name = "DisconnectButton";
		DisconnectButton.Size = new Size(75, 23);
		DisconnectButton.TabIndex = 3;
		DisconnectButton.Text = "Disconnect";
		DisconnectButton.UseVisualStyleBackColor = true;
		ConnectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ConnectButton.Location = new Point(9, 59);
		ConnectButton.Name = "ConnectButton";
		ConnectButton.Size = new Size(75, 23);
		ConnectButton.TabIndex = 2;
		ConnectButton.Text = "Connect";
		ConnectButton.UseVisualStyleBackColor = true;
		Label4.AutoSize = true;
		Label4.Location = new Point(142, 16);
		Label4.Name = "Label4";
		Label4.Size = new Size(26, 13);
		Label4.TabIndex = 0;
		Label4.Text = "港口";
		Label2.AutoSize = true;
		Label2.Location = new Point(6, 16);
		Label2.Name = "Label2";
		Label2.Size = new Size(17, 13);
		Label2.TabIndex = 0;
		Label2.Text = "IP";
		TextBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TextBox_0.Location = new Point(9, 32);
		TextBox_0.Name = "IPTextBox";
		TextBox_0.Size = new Size(130, 20);
		TextBox_0.TabIndex = 1;
		TextBox_0.Text = "127.0.0.1";
		LogListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		LogListBox.FormattingEnabled = true;
		LogListBox.Location = new Point(6, 19);
		LogListBox.Name = "LogListBox";
		LogListBox.Size = new Size(523, 95);
		LogListBox.TabIndex = 4;
		TeamsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TeamsTreeView.Location = new Point(6, 19);
		TeamsTreeView.Name = "TeamsTreeView";
		TeamsTreeView.Size = new Size(194, 150);
		TeamsTreeView.TabIndex = 5;
		GroupBox3.Controls.Add(GroupBox5);
		GroupBox3.Controls.Add(GroupBox4);
		GroupBox3.Controls.Add(ScenarioNameTextBox);
		GroupBox3.Location = new Point(14, 207);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(225, 461);
		GroupBox3.TabIndex = 6;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Scenario Information";
		GroupBox5.Controls.Add(UmpireButton);
		GroupBox5.Controls.Add(ObserverButton);
		GroupBox5.Controls.Add(PlayersListBox);
		GroupBox5.Location = new Point(8, 47);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(206, 199);
		GroupBox5.TabIndex = 8;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Players";
		UmpireButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		UmpireButton.Location = new Point(6, 141);
		UmpireButton.Name = "UmpireButton";
		UmpireButton.Size = new Size(194, 23);
		UmpireButton.TabIndex = 1;
		UmpireButton.Text = "Become Umpire";
		UmpireButton.UseVisualStyleBackColor = true;
		ObserverButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ObserverButton.Location = new Point(6, 170);
		ObserverButton.Name = "ObserverButton";
		ObserverButton.Size = new Size(194, 23);
		ObserverButton.TabIndex = 9;
		ObserverButton.Text = "Become Observer";
		ObserverButton.UseVisualStyleBackColor = true;
		PlayersListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		PlayersListBox.FormattingEnabled = true;
		PlayersListBox.Location = new Point(6, 19);
		PlayersListBox.Name = "PlayersListBox";
		PlayersListBox.Size = new Size(194, 108);
		PlayersListBox.TabIndex = 0;
		GroupBox4.Controls.Add(JoinTeamButton);
		GroupBox4.Controls.Add(TeamsTreeView);
		GroupBox4.Location = new Point(8, 251);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(206, 204);
		GroupBox4.TabIndex = 7;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Team Information";
		JoinTeamButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		JoinTeamButton.Location = new Point(6, 175);
		JoinTeamButton.Name = "JoinTeamButton";
		JoinTeamButton.Size = new Size(75, 23);
		JoinTeamButton.TabIndex = 6;
		JoinTeamButton.Text = "Join Team";
		JoinTeamButton.UseVisualStyleBackColor = true;
		ScenarioNameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		ScenarioNameTextBox.Location = new Point(8, 20);
		ScenarioNameTextBox.Name = "ScenarioNameTextBox";
		ScenarioNameTextBox.ReadOnly = true;
		ScenarioNameTextBox.Size = new Size(211, 20);
		ScenarioNameTextBox.TabIndex = 6;
		GroupBox6.Controls.Add(ClearLogButton);
		GroupBox6.Controls.Add(LogListBox);
		GroupBox6.Location = new Point(245, 12);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(535, 153);
		GroupBox6.TabIndex = 7;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Log";
		ClearLogButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ClearLogButton.Location = new Point(6, 123);
		ClearLogButton.Name = "ClearLogButton";
		ClearLogButton.Size = new Size(75, 23);
		ClearLogButton.TabIndex = 5;
		ClearLogButton.Text = "清除日志";
		ClearLogButton.UseVisualStyleBackColor = true;
		GroupBox7.Controls.Add(GlobalChatTextBox);
		GroupBox7.Controls.Add(GlobalChatButton);
		GroupBox7.Controls.Add(GlobalChatInputTextBox);
		GroupBox7.Location = new Point(244, 171);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(535, 176);
		GroupBox7.TabIndex = 8;
		GroupBox7.TabStop = false;
		GroupBox7.Text = "Global Chat";
		GlobalChatTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GlobalChatTextBox.Font = new Font("Lucida Console", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GlobalChatTextBox.Location = new Point(7, 20);
		GlobalChatTextBox.Name = "GlobalChatTextBox";
		GlobalChatTextBox.ReadOnly = true;
		GlobalChatTextBox.Size = new Size(522, 122);
		GlobalChatTextBox.TabIndex = 3;
		GlobalChatTextBox.Text = "";
		GlobalChatButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GlobalChatButton.Location = new Point(454, 146);
		GlobalChatButton.Name = "GlobalChatButton";
		GlobalChatButton.Size = new Size(75, 22);
		GlobalChatButton.TabIndex = 2;
		GlobalChatButton.Text = "Send";
		GlobalChatButton.UseVisualStyleBackColor = true;
		GlobalChatInputTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GlobalChatInputTextBox.Font = new Font("Lucida Console", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GlobalChatInputTextBox.Location = new Point(6, 148);
		GlobalChatInputTextBox.Name = "GlobalChatInputTextBox";
		GlobalChatInputTextBox.Size = new Size(440, 18);
		GlobalChatInputTextBox.TabIndex = 1;
		GroupBox8.Controls.Add(TeamChatTextBox);
		GroupBox8.Controls.Add(TeamChatButton);
		GroupBox8.Controls.Add(TeamChatInputTextBox);
		GroupBox8.Location = new Point(1053, 289);
		GroupBox8.Name = "GroupBox8";
		GroupBox8.Size = new Size(407, 419);
		GroupBox8.TabIndex = 9;
		GroupBox8.TabStop = false;
		GroupBox8.Text = "Team Chat";
		GroupBox8.Visible = false;
		TeamChatTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TeamChatTextBox.Font = new Font("Lucida Console", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TeamChatTextBox.Location = new Point(7, 20);
		TeamChatTextBox.Name = "TeamChatTextBox";
		TeamChatTextBox.ReadOnly = true;
		TeamChatTextBox.Size = new Size(393, 366);
		TeamChatTextBox.TabIndex = 3;
		TeamChatTextBox.Text = "";
		TeamChatButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		TeamChatButton.Location = new Point(325, 391);
		TeamChatButton.Name = "TeamChatButton";
		TeamChatButton.Size = new Size(75, 22);
		TeamChatButton.TabIndex = 2;
		TeamChatButton.Text = "Send";
		TeamChatButton.UseVisualStyleBackColor = true;
		TeamChatInputTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TeamChatInputTextBox.Font = new Font("Lucida Console", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TeamChatInputTextBox.Location = new Point(7, 393);
		TeamChatInputTextBox.Name = "TeamChatInputTextBox";
		TeamChatInputTextBox.Size = new Size(313, 18);
		TeamChatInputTextBox.TabIndex = 1;
		GroupBox9.Controls.Add(MultiplayerStatusRichTextBox);
		GroupBox9.Controls.Add(CommitTurnButton);
		GroupBox9.Location = new Point(246, 353);
		GroupBox9.Name = "GroupBox9";
		GroupBox9.Size = new Size(234, 207);
		GroupBox9.TabIndex = 10;
		GroupBox9.TabStop = false;
		GroupBox9.Text = "Multiplayer Turn";
		MultiplayerStatusRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		MultiplayerStatusRichTextBox.Location = new Point(8, 75);
		MultiplayerStatusRichTextBox.Name = "MultiplayerStatusRichTextBox";
		MultiplayerStatusRichTextBox.ReadOnly = true;
		MultiplayerStatusRichTextBox.Size = new Size(216, 124);
		MultiplayerStatusRichTextBox.TabIndex = 3;
		MultiplayerStatusRichTextBox.Text = "";
		CommitTurnButton.Location = new Point(7, 19);
		CommitTurnButton.Name = "CommitTurnButton";
		CommitTurnButton.Size = new Size(219, 50);
		CommitTurnButton.TabIndex = 1;
		CommitTurnButton.Text = "COMMIT TURN";
		CommitTurnButton.UseVisualStyleBackColor = true;
		GroupBox_0.Controls.Add(TurnReplay_Pause);
		GroupBox_0.Controls.Add(TurnReplay_Play);
		GroupBox_0.Controls.Add(TurnReplay_Next);
		GroupBox_0.Controls.Add(TurnReplay_Prev);
		GroupBox_0.Controls.Add(TurnReplayListBox);
		GroupBox_0.Controls.Add(TurnReplay_ReturnToPresent);
		GroupBox_0.Location = new Point(158, 674);
		GroupBox_0.Name = "GroupBox10";
		GroupBox_0.Size = new Size(293, 207);
		GroupBox_0.TabIndex = 11;
		GroupBox_0.TabStop = false;
		GroupBox_0.Text = "Turn Replay";
		GroupBox_0.Visible = false;
		TurnReplay_Pause.Location = new Point(45, 19);
		TurnReplay_Pause.Name = "TurnReplay_Pause";
		TurnReplay_Pause.Size = new Size(33, 23);
		TurnReplay_Pause.TabIndex = 3;
		TurnReplay_Pause.Text = "||";
		TurnReplay_Pause.UseVisualStyleBackColor = true;
		TurnReplay_Play.Location = new Point(83, 19);
		TurnReplay_Play.Name = "TurnReplay_Play";
		TurnReplay_Play.Size = new Size(33, 23);
		TurnReplay_Play.TabIndex = 3;
		TurnReplay_Play.Text = "▶";
		TurnReplay_Play.UseVisualStyleBackColor = true;
		TurnReplay_Next.Location = new Point(122, 19);
		TurnReplay_Next.Name = "TurnReplay_Next";
		TurnReplay_Next.Size = new Size(33, 23);
		TurnReplay_Next.TabIndex = 2;
		TurnReplay_Next.Text = ">>";
		TurnReplay_Next.UseVisualStyleBackColor = true;
		TurnReplay_Prev.Location = new Point(6, 19);
		TurnReplay_Prev.Name = "TurnReplay_Prev";
		TurnReplay_Prev.Size = new Size(33, 23);
		TurnReplay_Prev.TabIndex = 2;
		TurnReplay_Prev.Text = "<<";
		TurnReplay_Prev.UseVisualStyleBackColor = true;
		TurnReplayListBox.DisplayMember = "DisplayMember";
		TurnReplayListBox.FormattingEnabled = true;
		TurnReplayListBox.Location = new Point(6, 48);
		TurnReplayListBox.Name = "TurnReplayListBox";
		TurnReplayListBox.Size = new Size(277, 147);
		TurnReplayListBox.TabIndex = 1;
		TurnReplay_ReturnToPresent.Location = new Point(161, 19);
		TurnReplay_ReturnToPresent.Name = "TurnReplay_ReturnToPresent";
		TurnReplay_ReturnToPresent.Size = new Size(122, 23);
		TurnReplay_ReturnToPresent.TabIndex = 0;
		TurnReplay_ReturnToPresent.Text = "Return to Present";
		TurnReplay_ReturnToPresent.UseVisualStyleBackColor = true;
		MultiplayerOptionsGroupBox.Controls.Add(SpecialNoticeLabel);
		MultiplayerOptionsGroupBox.Controls.Add(MPRuleScenarioEndButton);
		MultiplayerOptionsGroupBox.Location = new Point(736, 659);
		MultiplayerOptionsGroupBox.Name = "MultiplayerOptionsGroupBox";
		MultiplayerOptionsGroupBox.Size = new Size(294, 101);
		MultiplayerOptionsGroupBox.TabIndex = 12;
		MultiplayerOptionsGroupBox.TabStop = false;
		MultiplayerOptionsGroupBox.Text = "Multiplayer Events";
		MultiplayerOptionsGroupBox.Visible = false;
		SpecialNoticeLabel.AutoSize = true;
		SpecialNoticeLabel.Location = new Point(6, 16);
		SpecialNoticeLabel.Name = "SpecialNoticeLabel";
		SpecialNoticeLabel.Size = new Size(0, 13);
		SpecialNoticeLabel.TabIndex = 1;
		MPRuleScenarioEndButton.Appearance = Appearance.Button;
		MPRuleScenarioEndButton.AutoSize = true;
		MPRuleScenarioEndButton.Location = new Point(9, 37);
		MPRuleScenarioEndButton.Name = "MPRuleScenarioEndButton";
		MPRuleScenarioEndButton.Size = new Size(124, 23);
		MPRuleScenarioEndButton.TabIndex = 0;
		MPRuleScenarioEndButton.Text = "Request End Scenario";
		MPRuleScenarioEndButton.UseVisualStyleBackColor = true;
		MPRuleScenarioEndButton.Visible = false;
		SpeedChess_CommitCountdownLabel.AutoSize = true;
		SpeedChess_CommitCountdownLabel.Location = new Point(5, 16);
		SpeedChess_CommitCountdownLabel.Name = "SpeedChess_CommitCountdownLabel";
		SpeedChess_CommitCountdownLabel.Size = new Size(187, 13);
		SpeedChess_CommitCountdownLabel.TabIndex = 1;
		SpeedChess_CommitCountdownLabel.Text = "SpeedChess_CommitCountdownLabel";
		SpeedChessGroupBox.Controls.Add(SpeedChess_MoreTimeRequestButton3);
		SpeedChessGroupBox.Controls.Add(SpeedChess_MoreTimeRequestButton2);
		SpeedChessGroupBox.Controls.Add(SpeedChess_MoreTimeRequestButton1);
		SpeedChessGroupBox.Controls.Add(SpeedChess_EventLabel);
		SpeedChessGroupBox.Controls.Add(SpeedChess_CommitCountdownLabel);
		SpeedChessGroupBox.Location = new Point(486, 660);
		SpeedChessGroupBox.Name = "SpeedChessGroupBox";
		SpeedChessGroupBox.Size = new Size(235, 100);
		SpeedChessGroupBox.TabIndex = 13;
		SpeedChessGroupBox.TabStop = false;
		SpeedChessGroupBox.Text = "Speed Chess";
		SpeedChessGroupBox.Visible = false;
		SpeedChess_MoreTimeRequestButton3.Location = new Point(162, 71);
		SpeedChess_MoreTimeRequestButton3.Name = "SpeedChess_MoreTimeRequestButton3";
		SpeedChess_MoreTimeRequestButton3.Size = new Size(67, 23);
		SpeedChess_MoreTimeRequestButton3.TabIndex = 3;
		SpeedChess_MoreTimeRequestButton3.Text = "+5 min";
		SpeedChess_MoreTimeRequestButton3.UseVisualStyleBackColor = true;
		SpeedChess_MoreTimeRequestButton2.Location = new Point(87, 71);
		SpeedChess_MoreTimeRequestButton2.Name = "SpeedChess_MoreTimeRequestButton2";
		SpeedChess_MoreTimeRequestButton2.Size = new Size(67, 23);
		SpeedChess_MoreTimeRequestButton2.TabIndex = 3;
		SpeedChess_MoreTimeRequestButton2.Text = "+1 min";
		SpeedChess_MoreTimeRequestButton2.UseVisualStyleBackColor = true;
		SpeedChess_MoreTimeRequestButton1.Location = new Point(9, 71);
		SpeedChess_MoreTimeRequestButton1.Name = "SpeedChess_MoreTimeRequestButton1";
		SpeedChess_MoreTimeRequestButton1.Size = new Size(67, 23);
		SpeedChess_MoreTimeRequestButton1.TabIndex = 3;
		SpeedChess_MoreTimeRequestButton1.Text = "+10 sec";
		SpeedChess_MoreTimeRequestButton1.UseVisualStyleBackColor = true;
		SpeedChess_EventLabel.AutoSize = true;
		SpeedChess_EventLabel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		SpeedChess_EventLabel.ForeColor = SystemColors.Highlight;
		SpeedChess_EventLabel.Location = new Point(6, 32);
		SpeedChess_EventLabel.MaximumSize = new Size(200, 0);
		SpeedChess_EventLabel.Name = "SpeedChess_EventLabel";
		SpeedChess_EventLabel.Size = new Size(148, 13);
		SpeedChess_EventLabel.TabIndex = 2;
		SpeedChess_EventLabel.Text = "SpeedChess_EventLabel";
		TimeTableComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		TimeTableComboBox.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TimeTableComboBox.FormattingEnabled = true;
		TimeTableComboBox.Location = new Point(246, 567);
		TimeTableComboBox.Name = "TimeTableComboBox";
		TimeTableComboBox.Size = new Size(534, 32);
		TimeTableComboBox.TabIndex = 14;
		TimeTableComboBox.Visible = false;
		UmpirePauseButton.Location = new Point(646, 604);
		UmpirePauseButton.Name = "UmpirePauseButton";
		UmpirePauseButton.Size = new Size(134, 23);
		UmpirePauseButton.TabIndex = 15;
		UmpirePauseButton.Text = "Pause Game";
		UmpirePauseButton.UseVisualStyleBackColor = true;
		UmpirePauseButton.Visible = false;
		UmpireResumeButton.Location = new Point(646, 633);
		UmpireResumeButton.Name = "UmpireResumeButton";
		UmpireResumeButton.Size = new Size(134, 23);
		UmpireResumeButton.TabIndex = 15;
		UmpireResumeButton.Text = "Resume Game";
		UmpireResumeButton.UseVisualStyleBackColor = true;
		UmpireResumeButton.Visible = false;
		ForceCommitButton.Location = new Point(507, 604);
		ForceCommitButton.Name = "ForceCommitButton";
		ForceCommitButton.Size = new Size(134, 23);
		ForceCommitButton.TabIndex = 15;
		ForceCommitButton.Text = "Force All Players Commit";
		ForceCommitButton.UseVisualStyleBackColor = true;
		ForceCommitButton.Visible = false;
		Label5.AutoSize = true;
		Label5.Location = new Point(246, 604);
		Label5.Name = "Label5";
		Label5.Size = new Size(0, 13);
		Label5.TabIndex = 16;
		Label6.AutoSize = true;
		Label6.Location = new Point(246, 617);
		Label6.Name = "Label6";
		Label6.Size = new Size(0, 13);
		Label6.TabIndex = 16;
		Label7.AutoSize = true;
		Label7.Location = new Point(246, 630);
		Label7.Name = "Label7";
		Label7.Size = new Size(0, 13);
		Label7.TabIndex = 17;
		AbortExecutionButton.ForeColor = Color.Red;
		AbortExecutionButton.Location = new Point(507, 633);
		AbortExecutionButton.Name = "AbortExecutionButton";
		AbortExecutionButton.Size = new Size(134, 23);
		AbortExecutionButton.TabIndex = 15;
		AbortExecutionButton.Text = "Abort Server Execution";
		AbortExecutionButton.UseVisualStyleBackColor = true;
		AbortExecutionButton.Visible = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(788, 680);
		base.Controls.Add(Label7);
		base.Controls.Add(Label6);
		base.Controls.Add(Label5);
		base.Controls.Add(UmpireResumeButton);
		base.Controls.Add(AbortExecutionButton);
		base.Controls.Add(ForceCommitButton);
		base.Controls.Add(UmpirePauseButton);
		base.Controls.Add(TimeTableComboBox);
		base.Controls.Add(SpeedChessGroupBox);
		base.Controls.Add(MultiplayerOptionsGroupBox);
		base.Controls.Add(GroupBox_0);
		base.Controls.Add(GroupBox9);
		base.Controls.Add(GroupBox7);
		base.Controls.Add(GroupBox6);
		base.Controls.Add(GroupBox3);
		base.Controls.Add(GroupBox2);
		base.Controls.Add(GroupBox1);
		base.Controls.Add(GroupBox8);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "MultiplayerForm";
		base.SizeGripStyle = SizeGripStyle.Hide;
		Text = "Multiplayer";
		base.TopMost = true;
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox6.ResumeLayout(performLayout: false);
		GroupBox7.ResumeLayout(performLayout: false);
		GroupBox7.PerformLayout();
		GroupBox8.ResumeLayout(performLayout: false);
		GroupBox8.PerformLayout();
		GroupBox9.ResumeLayout(performLayout: false);
		GroupBox_0.ResumeLayout(performLayout: false);
		MultiplayerOptionsGroupBox.ResumeLayout(performLayout: false);
		MultiplayerOptionsGroupBox.PerformLayout();
		SpeedChessGroupBox.ResumeLayout(performLayout: false);
		SpeedChessGroupBox.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void ConnectInterruptibleFilter()
	{
		if (Client.CurrentScenario == null)
		{
			return;
		}
		ConcurrentDictionary<long, LoggedMessage> concurrentDictionary = new ConcurrentDictionary<long, LoggedMessage>();
		foreach (LoggedMessage item in Client.CurrentScenario.MessageLog)
		{
			if (SimConfiguration.DefaultGamePreferences.MessageLogSettings.ContainsKey(item.Type) && SimConfiguration.DefaultGamePreferences.MessageLogSettings[item.Type].ShowOnMessageLog)
			{
				concurrentDictionary.TryAdd(item.Increment, item);
			}
		}
		Client.CurrentScenario.MessageLog = concurrentDictionary.Values.ToList();
	}
}
