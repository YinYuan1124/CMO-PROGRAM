using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.Messages;
using Command_Core;
using Command_Core.DAL;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ReadyAircraft : DarkSecondaryFormBase
{
	private IContainer strategySchema;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _TokenSchema;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _IndexerSchema;

	[AccessedThroughProperty("CheckHostsMagazinesToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _PublisherSchema;

	[AccessedThroughProperty("Button3")]
	[CompilerGenerated]
	private DarkUIButton _ServerSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("Label6")]
	private DarkLabel m_UtilsSchema;

	[AccessedThroughProperty("Label7")]
	[CompilerGenerated]
	private DarkLabel predicateSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("Label8")]
	private DarkLabel m_SingletonSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("Button4")]
	private DarkUIButton m_RecordSchema;

	[AccessedThroughProperty("Button5")]
	[CompilerGenerated]
	private DarkUIButton exceptionSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ShowOnlyUsable")]
	private DarkCheckBox visitorSchema;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	private DarkLabel m_ExporterSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_QuickTurnaround")]
	private DarkCheckBox comparatorSchema;

	[AccessedThroughProperty("Combo_NumberOfSorties")]
	[CompilerGenerated]
	private DarkUIComboBox m_ItemSchema;

	[AccessedThroughProperty("Label_QuickTurnaroundInfo")]
	[CompilerGenerated]
	private DarkLabel setterSchema;

	[AccessedThroughProperty("DGV_LoadoutItems")]
	[CompilerGenerated]
	private DarkDataGridView creatorSchema;

	[AccessedThroughProperty("DGV_Loadouts")]
	[CompilerGenerated]
	private DarkDataGridView templateSchema;

	[AccessedThroughProperty("Loadout")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn mockSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("NumberOfLoadouts")]
	private DataGridViewTextBoxColumn m_TagSchema;

	[AccessedThroughProperty("NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_QueueSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("ReadyTime_Sustained")]
	private DataGridViewTextBoxColumn paramSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("QuickTurnaroundDescription")]
	private DataGridViewTextBoxColumn m_PageSchema;

	[AccessedThroughProperty("TimeofDay")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_RulesSchema;

	[AccessedThroughProperty("Weather")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn methodSchema;

	[AccessedThroughProperty("RangeProfileDescription")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ServiceSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadoutRoleDescription")]
	private DataGridViewTextBoxColumn m_SystemSchema;

	[AccessedThroughProperty("LoadoutRole")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_CandidateSchema;

	[AccessedThroughProperty("RequiresBuddyIllumination")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn baseSchema;

	[AccessedThroughProperty("DefaultMissionProfile")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn identifierSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("AttackAltitude")]
	private DataGridViewTextBoxColumn printerSchema;

	[AccessedThroughProperty("QuickTurnaround_MaxSorties")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn algoSchema;

	[AccessedThroughProperty("QuickTurnaround_AirborneTime")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn databaseSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("QuickTurnaround_StanddownTime")]
	private DataGridViewTextBoxColumn messageSchema;

	[AccessedThroughProperty("QuickTurnaround_TimeofDay")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ProductSchema;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	private DataGridViewTextBoxColumn m_AnnotationSchema;

	[AccessedThroughProperty("Column_Description")]
	[CompilerGenerated]
	private DataGridViewLinkColumn iteratorSchema;

	[AccessedThroughProperty("Available")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn initializerSchema;

	public List<Aircraft> SelectedAircraft;

	public List<Mission.EmptyAircraftSlot> SelectedEmptySlot;

	public int SelectedLoadout;

	private DataTable _FactorySchema;

	private DataTable m_AttributeSchema;

	private Dictionary<int, int> _EventSchema;

	private HashSet<int> globalSchema;

	private string m_WorkerSchema;

	private bool accountSchema;

	private int m_StateSchema;

	private int _AuthenticationSchema;

	private int paramsSchema;

	private int m_InfoSchema;

	private int _HelperSchema;

	private int? mapperSchema;

	private bool m_ManagerSchema;

	[field: AccessedThroughProperty("Label_Loadout")]
	internal DarkLabel Label_Loadout
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _TokenSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PostInterruptibleConnection;
			DarkUIButton tokenSchema = _TokenSchema;
			if (tokenSchema != null)
			{
				tokenSchema.Click -= value2;
			}
			_TokenSchema = value;
			tokenSchema = _TokenSchema;
			if (tokenSchema != null)
			{
				tokenSchema.Click += value2;
			}
		}
	}

	internal DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _IndexerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = StartInterruptibleConnection;
			DarkUIButton indexerSchema = _IndexerSchema;
			if (indexerSchema != null)
			{
				indexerSchema.Click -= value2;
			}
			_IndexerSchema = value;
			indexerSchema = _IndexerSchema;
			if (indexerSchema != null)
			{
				indexerSchema.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("MenuStrip1")]
	internal DarkMenuStrip MenuStrip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkToolStripMenuItem CheckHostsMagazinesToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _PublisherSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PrintInterruptibleConnection;
			DarkToolStripMenuItem publisherSchema = _PublisherSchema;
			if (publisherSchema != null)
			{
				publisherSchema.Click -= value2;
			}
			_PublisherSchema = value;
			publisherSchema = _PublisherSchema;
			if (publisherSchema != null)
			{
				publisherSchema.Click += value2;
			}
		}
	}

	internal DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _ServerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PublishInterruptibleConnection;
			DarkUIButton serverSchema = _ServerSchema;
			if (serverSchema != null)
			{
				serverSchema.Click -= value2;
			}
			_ServerSchema = value;
			serverSchema = _ServerSchema;
			if (serverSchema != null)
			{
				serverSchema.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal DarkLabel Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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
			return m_UtilsSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_UtilsSchema = value;
		}
	}

	internal DarkLabel Label7
	{
		[CompilerGenerated]
		get
		{
			return predicateSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			predicateSchema = value;
		}
	}

	internal DarkLabel Label8
	{
		[CompilerGenerated]
		get
		{
			return m_SingletonSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SingletonSchema = value;
		}
	}

	internal DarkUIButton Button4
	{
		[CompilerGenerated]
		get
		{
			return m_RecordSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AwakeInterruptibleConnection;
			DarkUIButton recordSchema = m_RecordSchema;
			if (recordSchema != null)
			{
				recordSchema.Click -= value2;
			}
			m_RecordSchema = value;
			recordSchema = m_RecordSchema;
			if (recordSchema != null)
			{
				recordSchema.Click += value2;
			}
		}
	}

	internal DarkUIButton Button5
	{
		[CompilerGenerated]
		get
		{
			return exceptionSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RunInterruptibleConnection;
			DarkUIButton darkUIButton = exceptionSchema;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			exceptionSchema = value;
			darkUIButton = exceptionSchema;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("QuickTurnaround_AdditionalTimePenalty")]
	internal DataGridViewTextBoxColumn QuickTurnaround_AdditionalTimePenalty
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_ShowOnlyUsable
	{
		[CompilerGenerated]
		get
		{
			return visitorSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ManageInterruptibleConnection;
			DarkCheckBox darkCheckBox = visitorSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click -= value2;
			}
			visitorSchema = value;
			darkCheckBox = visitorSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.Click += value2;
			}
		}
	}

	internal DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterSchema = value;
		}
	}

	[field: AccessedThroughProperty("FlowLayoutPanel1")]
	internal FlowLayoutPanel FlowLayoutPanel1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkCheckBox CB_QuickTurnaround
	{
		[CompilerGenerated]
		get
		{
			return comparatorSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OrderInterruptibleConnection;
			DarkCheckBox darkCheckBox = comparatorSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged -= value2;
			}
			comparatorSchema = value;
			darkCheckBox = comparatorSchema;
			if (darkCheckBox != null)
			{
				darkCheckBox.CheckedChanged += value2;
			}
		}
	}

	internal DarkUIComboBox Combo_NumberOfSorties
	{
		[CompilerGenerated]
		get
		{
			return m_ItemSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FlushInterruptibleConnection;
			DarkUIComboBox itemSchema = m_ItemSchema;
			if (itemSchema != null)
			{
				itemSchema.SelectedIndexChanged -= value2;
			}
			m_ItemSchema = value;
			itemSchema = m_ItemSchema;
			if (itemSchema != null)
			{
				itemSchema.SelectedIndexChanged += value2;
			}
		}
	}

	internal DarkLabel Label_QuickTurnaroundInfo
	{
		[CompilerGenerated]
		get
		{
			return setterSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			setterSchema = value;
		}
	}

	internal DarkDataGridView DGV_LoadoutItems
	{
		[CompilerGenerated]
		get
		{
			return creatorSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = SortInterruptibleConnection;
			DarkDataGridView darkDataGridView = creatorSchema;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellContentClick -= value2;
			}
			creatorSchema = value;
			darkDataGridView = creatorSchema;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellContentClick += value2;
			}
		}
	}

	internal DarkDataGridView DGV_Loadouts
	{
		[CompilerGenerated]
		get
		{
			return templateSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = QueryInterruptibleConnection;
			EventHandler value3 = ResetInterruptibleConnection;
			DataGridViewCellFormattingEventHandler value4 = CalcInterruptibleConnection;
			DarkDataGridView darkDataGridView = templateSchema;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellMouseDoubleClick -= value2;
				darkDataGridView.SelectionChanged -= value3;
				darkDataGridView.CellFormatting -= value4;
			}
			templateSchema = value;
			darkDataGridView = templateSchema;
			if (darkDataGridView != null)
			{
				darkDataGridView.CellMouseDoubleClick += value2;
				darkDataGridView.SelectionChanged += value3;
				darkDataGridView.CellFormatting += value4;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal DataGridViewTextBoxColumn ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Loadout
	{
		[CompilerGenerated]
		get
		{
			return mockSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mockSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn NumberOfLoadouts
	{
		[CompilerGenerated]
		get
		{
			return m_TagSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TagSchema = value;
		}
	}

	[field: AccessedThroughProperty("NumberOfLoadoutsIncludingMountedWeapons")]
	internal DataGridViewTextBoxColumn NumberOfLoadoutsIncludingMountedWeapons
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly
	{
		[CompilerGenerated]
		get
		{
			return m_QueueSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_QueueSchema = value;
		}
	}

	[field: AccessedThroughProperty("ReadyTime")]
	internal DataGridViewTextBoxColumn ReadyTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn ReadyTime_Sustained
	{
		[CompilerGenerated]
		get
		{
			return paramSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			paramSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn QuickTurnaroundDescription
	{
		[CompilerGenerated]
		get
		{
			return m_PageSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PageSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn TimeofDay
	{
		[CompilerGenerated]
		get
		{
			return m_RulesSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_RulesSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn Weather
	{
		[CompilerGenerated]
		get
		{
			return methodSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			methodSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn RangeProfileDescription
	{
		[CompilerGenerated]
		get
		{
			return m_ServiceSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ServiceSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn LoadoutRoleDescription
	{
		[CompilerGenerated]
		get
		{
			return m_SystemSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SystemSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn LoadoutRole
	{
		[CompilerGenerated]
		get
		{
			return m_CandidateSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CandidateSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn RequiresBuddyIllumination
	{
		[CompilerGenerated]
		get
		{
			return baseSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			baseSchema = value;
		}
	}

	[field: AccessedThroughProperty("DefaultCombatRadius")]
	internal DataGridViewTextBoxColumn DefaultCombatRadius
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("DefaultTimeOnStation")]
	internal DataGridViewTextBoxColumn DefaultTimeOnStation
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DefaultMissionProfile
	{
		[CompilerGenerated]
		get
		{
			return identifierSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			identifierSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn AttackAltitude
	{
		[CompilerGenerated]
		get
		{
			return printerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			printerSchema = value;
		}
	}

	[field: AccessedThroughProperty("QuickTurnaround")]
	internal DataGridViewTextBoxColumn QuickTurnaround
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn QuickTurnaround_MaxSorties
	{
		[CompilerGenerated]
		get
		{
			return algoSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			algoSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn QuickTurnaround_AirborneTime
	{
		[CompilerGenerated]
		get
		{
			return databaseSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			databaseSchema = value;
		}
	}

	[field: AccessedThroughProperty("QuickTurnaround_ReadyTime")]
	internal DataGridViewTextBoxColumn QuickTurnaround_ReadyTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn QuickTurnaround_StanddownTime
	{
		[CompilerGenerated]
		get
		{
			return messageSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			messageSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn QuickTurnaround_TimeofDay
	{
		[CompilerGenerated]
		get
		{
			return m_ProductSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ProductSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[CompilerGenerated]
		get
		{
			return m_AnnotationSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AnnotationSchema = value;
		}
	}

	internal DataGridViewLinkColumn Column_Description
	{
		[CompilerGenerated]
		get
		{
			return iteratorSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iteratorSchema = value;
		}
	}

	internal DataGridViewTextBoxColumn Available
	{
		[CompilerGenerated]
		get
		{
			return initializerSchema;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			initializerSchema = value;
		}
	}

	[field: AccessedThroughProperty("AvailableTotal")]
	internal DataGridViewTextBoxColumn AvailableTotal
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public ReadyAircraft()
	{
		base.FormClosing += CancelInterruptibleConnection;
		base.Load += VerifyInterruptibleConnection;
		base.KeyDown += RateInterruptibleConnection;
		_FactorySchema = new DataTable();
		m_AttributeSchema = new DataTable();
		_EventSchema = new Dictionary<int, int>();
		globalSchema = new HashSet<int>();
		StopInterruptibleConnection();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && strategySchema != null)
			{
				strategySchema.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void StopInterruptibleConnection()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		CB_ShowOnlyUsable = new DarkCheckBox();
		Button5 = new DarkUIButton();
		Button4 = new DarkUIButton();
		Label8 = new DarkLabel();
		Label7 = new DarkLabel();
		Label6 = new DarkLabel();
		Label5 = new DarkLabel();
		Label2 = new DarkLabel();
		Button3 = new DarkUIButton();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label_Loadout = new DarkLabel();
		DGV_LoadoutItems = new DarkDataGridView();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		Column_Description = new DataGridViewLinkColumn();
		Available = new DataGridViewTextBoxColumn();
		AvailableTotal = new DataGridViewTextBoxColumn();
		DGV_Loadouts = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		Loadout = new DataGridViewTextBoxColumn();
		NumberOfLoadouts = new DataGridViewTextBoxColumn();
		NumberOfLoadoutsIncludingMountedWeapons = new DataGridViewTextBoxColumn();
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly = new DataGridViewTextBoxColumn();
		ReadyTime = new DataGridViewTextBoxColumn();
		ReadyTime_Sustained = new DataGridViewTextBoxColumn();
		QuickTurnaroundDescription = new DataGridViewTextBoxColumn();
		TimeofDay = new DataGridViewTextBoxColumn();
		Weather = new DataGridViewTextBoxColumn();
		RangeProfileDescription = new DataGridViewTextBoxColumn();
		LoadoutRoleDescription = new DataGridViewTextBoxColumn();
		LoadoutRole = new DataGridViewTextBoxColumn();
		RequiresBuddyIllumination = new DataGridViewTextBoxColumn();
		DefaultCombatRadius = new DataGridViewTextBoxColumn();
		DefaultTimeOnStation = new DataGridViewTextBoxColumn();
		DefaultMissionProfile = new DataGridViewTextBoxColumn();
		AttackAltitude = new DataGridViewTextBoxColumn();
		QuickTurnaround = new DataGridViewTextBoxColumn();
		QuickTurnaround_MaxSorties = new DataGridViewTextBoxColumn();
		QuickTurnaround_AirborneTime = new DataGridViewTextBoxColumn();
		QuickTurnaround_ReadyTime = new DataGridViewTextBoxColumn();
		QuickTurnaround_StanddownTime = new DataGridViewTextBoxColumn();
		QuickTurnaround_TimeofDay = new DataGridViewTextBoxColumn();
		MenuStrip1 = new DarkMenuStrip();
		CheckHostsMagazinesToolStripMenuItem = new DarkToolStripMenuItem();
		Label1 = new DarkLabel();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		CB_QuickTurnaround = new DarkCheckBox();
		Combo_NumberOfSorties = new DarkUIComboBox();
		Label_QuickTurnaroundInfo = new DarkLabel();
		((ISupportInitialize)DGV_LoadoutItems).BeginInit();
		((ISupportInitialize)DGV_Loadouts).BeginInit();
		MenuStrip1.SuspendLayout();
		FlowLayoutPanel1.SuspendLayout();
		SuspendLayout();
		CB_ShowOnlyUsable.AutoSize = true;
		CB_ShowOnlyUsable.Location = new Point(145, 5);
		CB_ShowOnlyUsable.Name = "CB_ShowOnlyUsable";
		CB_ShowOnlyUsable.Size = new Size(167, 19);
		CB_ShowOnlyUsable.TabIndex = 30;
		CB_ShowOnlyUsable.Text = "仅显示可用的挂载";
		Button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button5.BackColor = Color.Transparent;
		Button5.DialogResult = DialogResult.None;
		Button5.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button5.ForeColor = SystemColors.Control;
		Button5.Location = new Point(85, 538);
		Button5.Name = "Button5";
		Button5.Padding = new Padding(5);
		Button5.RoundRadius = 0;
		Button5.Size = new Size(213, 23);
		Button5.TabIndex = 26;
		Button5.Text = "OK - 准备就绪（排除可选武器）";
		Button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button4.BackColor = Color.Transparent;
		Button4.DialogResult = DialogResult.None;
		Button4.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button4.ForeColor = Color.IndianRed;
		Button4.Location = new Point(497, 538);
		Button4.Name = "Button4";
		Button4.Padding = new Padding(5);
		Button4.RoundRadius = 0;
		Button4.Size = new Size(296, 23);
		Button4.TabIndex = 25;
		Button4.Text = "立即就绪 - 忽略弹药库（ScenEdit）";
		Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label8.AutoSize = true;
		Label8.ForeColor = Color.FromArgb(220, 220, 220);
		Label8.Location = new Point(655, 444);
		Label8.Name = "Label8";
		Label8.Size = new Size(227, 15);
		Label8.TabIndex = 24;
		Label8.Text = "NumberOfLoadoutsTotal_MandatoryOnly";
		Label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label7.AutoSize = true;
		Label7.ForeColor = Color.FromArgb(220, 220, 220);
		Label7.Location = new Point(655, 429);
		Label7.Name = "Label7";
		Label7.Size = new Size(139, 15);
		Label7.TabIndex = 23;
		Label7.Text = "NumberOfLoadoutsTotal";
		Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label6.AutoSize = true;
		Label6.ForeColor = Color.FromArgb(220, 220, 220);
		Label6.Location = new Point(655, 414);
		Label6.Name = "Label6";
		Label6.Size = new Size(153, 15);
		Label6.TabIndex = 22;
		Label6.Text = "NumberOfLoadoutsOnBase";
		Label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label5.AutoSize = true;
		Label5.ForeColor = Color.FromArgb(220, 220, 220);
		Label5.Location = new Point(655, 399);
		Label5.Name = "Label5";
		Label5.Size = new Size(83, 15);
		Label5.TabIndex = 21;
		Label5.Text = "攻击高度";
		Label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label2.AutoSize = true;
		Label2.ForeColor = Color.FromArgb(220, 220, 220);
		Label2.Location = new Point(655, 384);
		Label2.Name = "Label2";
		Label2.Size = new Size(134, 15);
		Label2.TabIndex = 18;
		Label2.Text = "挂载类型描述";
		Button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button3.BackColor = Color.Transparent;
		Button3.DialogResult = DialogResult.None;
		Button3.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button3.ForeColor = Color.IndianRed;
		Button3.Location = new Point(304, 538);
		Button3.Name = "Button3";
		Button3.Padding = new Padding(5);
		Button3.RoundRadius = 0;
		Button3.Size = new Size(187, 23);
		Button3.TabIndex = 16;
		Button3.Text = "立即就绪（ScenEdit）";
		Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Button2.BackColor = Color.Transparent;
		Button2.DialogResult = DialogResult.None;
		Button2.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button2.ForeColor = SystemColors.Control;
		Button2.Location = new Point(1016, 538);
		Button2.Name = "Button2";
		Button2.Padding = new Padding(5);
		Button2.RoundRadius = 0;
		Button2.Size = new Size(75, 23);
		Button2.TabIndex = 14;
		Button2.Text = "取消";
		Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button1.BackColor = Color.Transparent;
		Button1.DialogResult = DialogResult.None;
		Button1.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		Button1.ForeColor = SystemColors.Control;
		Button1.Location = new Point(4, 538);
		Button1.Name = "Button1";
		Button1.Padding = new Padding(5);
		Button1.RoundRadius = 0;
		Button1.Size = new Size(75, 23);
		Button1.TabIndex = 13;
		Button1.Text = "确定 - 就绪";
		Label_Loadout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label_Loadout.AutoSize = true;
		Label_Loadout.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 161);
		Label_Loadout.ForeColor = Color.FromArgb(220, 220, 220);
		Label_Loadout.Location = new Point(3, 382);
		Label_Loadout.Name = "Label_Loadout";
		Label_Loadout.Size = new Size(92, 13);
		Label_Loadout.TabIndex = 12;
		Label_Loadout.Text = "挂载细节：";
		DGV_LoadoutItems.AllowUserToAddRows = false;
		DGV_LoadoutItems.AllowUserToDeleteRows = false;
		DGV_LoadoutItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		DGV_LoadoutItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		DGV_LoadoutItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
		DGV_LoadoutItems.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_LoadoutItems.BorderStyle = BorderStyle.Fixed3D;
		DGV_LoadoutItems.CausesValidation = false;
		DGV_LoadoutItems.CellBorderStyle = DataGridViewCellBorderStyle.None;
		DGV_LoadoutItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.LightGray;
		dataGridViewCellStyle.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_LoadoutItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_LoadoutItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_LoadoutItems.Columns.AddRange(DataGridViewTextBoxColumn1, Column_Description, Available, AvailableTotal);
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.LightGray;
		dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		DGV_LoadoutItems.DefaultCellStyle = dataGridViewCellStyle2;
		DGV_LoadoutItems.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_LoadoutItems.EnableHeadersVisualStyles = false;
		DGV_LoadoutItems.Location = new Point(3, 397);
		DGV_LoadoutItems.MultiSelect = false;
		DGV_LoadoutItems.Name = "DGV_LoadoutItems";
		DGV_LoadoutItems.RowHeadersVisible = false;
		DGV_LoadoutItems.RowHeadersWidth = 20;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle3.ForeColor = Color.LightGray;
		dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle3.SelectionForeColor = Color.LightGray;
		DGV_LoadoutItems.RowsDefaultCellStyle = dataGridViewCellStyle3;
		DGV_LoadoutItems.RowTemplate.Height = 15;
		DGV_LoadoutItems.RowTemplate.Resizable = DataGridViewTriState.False;
		DGV_LoadoutItems.ScrollBars = ScrollBars.Vertical;
		DGV_LoadoutItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_LoadoutItems.Size = new Size(650, 135);
		DGV_LoadoutItems.TabIndex = 11;
		DataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn1.DataPropertyName = "ID";
		DataGridViewTextBoxColumn1.HeaderText = "ID";
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
		DataGridViewTextBoxColumn1.Visible = false;
		Column_Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		Column_Description.DataPropertyName = "Item";
		Column_Description.HeaderText = "弹药储备（点击查询）";
		Column_Description.LinkBehavior = LinkBehavior.HoverUnderline;
		Column_Description.LinkColor = Color.LightBlue;
		Column_Description.MinimumWidth = 470;
		Column_Description.Name = "Column_Description";
		Column_Description.ReadOnly = true;
		Column_Description.Resizable = DataGridViewTriState.True;
		Column_Description.TrackVisitedState = false;
		Column_Description.Width = 470;
		Available.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		Available.DataPropertyName = "Available";
		Available.HeaderText = "＃可用数量，弹仓";
		Available.MinimumWidth = 90;
		Available.Name = "Available";
		Available.ReadOnly = true;
		Available.SortMode = DataGridViewColumnSortMode.NotSortable;
		Available.ToolTipText = "The number of weapons available in the base's ammo dump";
		AvailableTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		AvailableTotal.DataPropertyName = "AvailableTotal";
		AvailableTotal.HeaderText = "# 可用,弹药+飞机挂载";
		AvailableTotal.MinimumWidth = 90;
		AvailableTotal.Name = "AvailableTotal";
		AvailableTotal.ReadOnly = true;
		AvailableTotal.SortMode = DataGridViewColumnSortMode.NotSortable;
		AvailableTotal.ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		DGV_Loadouts.AllowUserToAddRows = false;
		DGV_Loadouts.AllowUserToDeleteRows = false;
		DGV_Loadouts.AllowUserToResizeRows = false;
		DGV_Loadouts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_Loadouts.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Loadouts.BorderStyle = BorderStyle.Fixed3D;
		DGV_Loadouts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Loadouts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(66, 77, 95);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.LightGray;
		dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		DGV_Loadouts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		DGV_Loadouts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGV_Loadouts.Columns.AddRange(ID, Loadout, NumberOfLoadouts, NumberOfLoadoutsIncludingMountedWeapons, NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly, ReadyTime, ReadyTime_Sustained, QuickTurnaroundDescription, TimeofDay, Weather, RangeProfileDescription, LoadoutRoleDescription, LoadoutRole, RequiresBuddyIllumination, DefaultCombatRadius, DefaultTimeOnStation, DefaultMissionProfile, AttackAltitude, QuickTurnaround, QuickTurnaround_MaxSorties, QuickTurnaround_AirborneTime, QuickTurnaround_ReadyTime, QuickTurnaround_StanddownTime, QuickTurnaround_TimeofDay);
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle5.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle5.ForeColor = Color.LightGray;
		dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(122, 128, 132);
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		DGV_Loadouts.DefaultCellStyle = dataGridViewCellStyle5;
		DGV_Loadouts.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_Loadouts.EnableHeadersVisualStyles = false;
		DGV_Loadouts.GridColor = SystemColors.ControlText;
		DGV_Loadouts.Location = new Point(3, 27);
		DGV_Loadouts.MultiSelect = false;
		DGV_Loadouts.Name = "DGV_Loadouts";
		DGV_Loadouts.RowHeadersVisible = false;
		DGV_Loadouts.RowHeadersWidth = 10;
		dataGridViewCellStyle6.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle6.ForeColor = Color.LightGray;
		dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle6.SelectionForeColor = Color.LightGray;
		DGV_Loadouts.RowsDefaultCellStyle = dataGridViewCellStyle6;
		DGV_Loadouts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Loadouts.Size = new Size(1088, 315);
		DGV_Loadouts.TabIndex = 8;
		ID.DataPropertyName = "ID";
		ID.HeaderText = "ID";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		ID.Visible = false;
		Loadout.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Loadout.DataPropertyName = "Name";
		Loadout.HeaderText = "挂载名称";
		Loadout.MinimumWidth = 300;
		Loadout.Name = "Loadout";
		Loadout.ReadOnly = true;
		Loadout.Width = 300;
		NumberOfLoadouts.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		NumberOfLoadouts.DataPropertyName = "NumberOfLoadouts";
		NumberOfLoadouts.HeaderText = "＃可用数量，弹仓";
		NumberOfLoadouts.MinimumWidth = 90;
		NumberOfLoadouts.Name = "NumberOfLoadouts";
		NumberOfLoadouts.ReadOnly = true;
		NumberOfLoadouts.ToolTipText = "The number of weapons available in the base's ammo dump";
		NumberOfLoadouts.Width = 90;
		NumberOfLoadoutsIncludingMountedWeapons.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		NumberOfLoadoutsIncludingMountedWeapons.DataPropertyName = "NumberOfLoadoutsIncludingMountedWeapons";
		NumberOfLoadoutsIncludingMountedWeapons.HeaderText = "# 可用,弹药+飞机挂载";
		NumberOfLoadoutsIncludingMountedWeapons.MinimumWidth = 90;
		NumberOfLoadoutsIncludingMountedWeapons.Name = "NumberOfLoadoutsIncludingMountedWeapons";
		NumberOfLoadoutsIncludingMountedWeapons.ReadOnly = true;
		NumberOfLoadoutsIncludingMountedWeapons.ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft";
		NumberOfLoadoutsIncludingMountedWeapons.Width = 90;
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.DataPropertyName = "NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly";
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.HeaderText = "# 可用，强制性";
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.MinimumWidth = 90;
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.Name = "NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly";
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.ReadOnly = true;
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.ToolTipText = "The total number of weapons available including those mounted on the currently selected aircraft, excluding any optional weapons";
		NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly.Width = 90;
		ReadyTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		ReadyTime.DataPropertyName = "ReadyTime";
		ReadyTime.HeaderText = "准备时间，波次行动";
		ReadyTime.MinimumWidth = 100;
		ReadyTime.Name = "ReadyTime";
		ReadyTime.ReadOnly = true;
		ReadyTime_Sustained.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		ReadyTime_Sustained.DataPropertyName = "ReadyTime_Sustained";
		ReadyTime_Sustained.HeaderText = "准备时间，连续行动";
		ReadyTime_Sustained.MinimumWidth = 100;
		ReadyTime_Sustained.Name = "ReadyTime_Sustained";
		ReadyTime_Sustained.ReadOnly = true;
		QuickTurnaroundDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		QuickTurnaroundDescription.DataPropertyName = "QuickTurnaroundDescription";
		QuickTurnaroundDescription.HeaderText = "快速再次出动";
		QuickTurnaroundDescription.MinimumWidth = 120;
		QuickTurnaroundDescription.Name = "QuickTurnaroundDescription";
		QuickTurnaroundDescription.ReadOnly = true;
		QuickTurnaroundDescription.Width = 120;
		TimeofDay.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		TimeofDay.DataPropertyName = "TimeofDay";
		TimeofDay.HeaderText = "一天的时间";
		TimeofDay.MinimumWidth = 90;
		TimeofDay.Name = "TimeofDay";
		TimeofDay.ReadOnly = true;
		TimeofDay.Width = 90;
		Weather.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		Weather.DataPropertyName = "Weather";
		Weather.HeaderText = "天气";
		Weather.MinimumWidth = 90;
		Weather.Name = "Weather";
		Weather.ReadOnly = true;
		Weather.Width = 90;
		RangeProfileDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		RangeProfileDescription.DataPropertyName = "RangeProfileDescription";
		RangeProfileDescription.HeaderText = "半径 / 侧面";
		RangeProfileDescription.MinimumWidth = 517;
		RangeProfileDescription.Name = "RangeProfileDescription";
		RangeProfileDescription.ReadOnly = true;
		RangeProfileDescription.Width = 517;
		LoadoutRoleDescription.DataPropertyName = "LoadoutRoleDescription";
		LoadoutRoleDescription.HeaderText = "挂载类型描述";
		LoadoutRoleDescription.Name = "LoadoutRoleDescription";
		LoadoutRoleDescription.Visible = false;
		LoadoutRole.DataPropertyName = "LoadoutRole";
		LoadoutRole.HeaderText = "挂载角色";
		LoadoutRole.Name = "LoadoutRole";
		LoadoutRole.Visible = false;
		RequiresBuddyIllumination.DataPropertyName = "RequiresBuddyIllumination";
		RequiresBuddyIllumination.HeaderText = "需要友方照射";
		RequiresBuddyIllumination.Name = "RequiresBuddyIllumination";
		RequiresBuddyIllumination.Visible = false;
		DefaultCombatRadius.DataPropertyName = "DefaultCombatRadius";
		DefaultCombatRadius.HeaderText = "默认战斗半径";
		DefaultCombatRadius.Name = "DefaultCombatRadius";
		DefaultCombatRadius.Visible = false;
		DefaultTimeOnStation.DataPropertyName = "DefaultTimeOnStation";
		DefaultTimeOnStation.HeaderText = "默认巡逻时间";
		DefaultTimeOnStation.Name = "DefaultTimeOnStation";
		DefaultTimeOnStation.Visible = false;
		DefaultMissionProfile.DataPropertyName = "DefaultMissionProfile";
		DefaultMissionProfile.HeaderText = "默认任务描述";
		DefaultMissionProfile.Name = "DefaultMissionProfile";
		DefaultMissionProfile.Visible = false;
		AttackAltitude.DataPropertyName = "AttackAltitude";
		AttackAltitude.HeaderText = "攻击高度";
		AttackAltitude.Name = "AttackAltitude";
		AttackAltitude.Visible = false;
		QuickTurnaround.DataPropertyName = "QuickTurnaround";
		QuickTurnaround.HeaderText = "QuickTurnaround";
		QuickTurnaround.Name = "QuickTurnaround";
		QuickTurnaround.Visible = false;
		QuickTurnaround_MaxSorties.DataPropertyName = "QuickTurnaround_MaxSorties";
		QuickTurnaround_MaxSorties.HeaderText = "QuickTurnaround_MaxSorties";
		QuickTurnaround_MaxSorties.Name = "QuickTurnaround_MaxSorties";
		QuickTurnaround_MaxSorties.Visible = false;
		QuickTurnaround_AirborneTime.DataPropertyName = "QuickTurnaround_AirborneTime";
		QuickTurnaround_AirborneTime.HeaderText = "QuickTurnaround_AirborneTime";
		QuickTurnaround_AirborneTime.Name = "QuickTurnaround_AirborneTime";
		QuickTurnaround_AirborneTime.Visible = false;
		QuickTurnaround_ReadyTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		QuickTurnaround_ReadyTime.DataPropertyName = "QuickTurnaround_ReadyTime";
		QuickTurnaround_ReadyTime.HeaderText = "QuickTurnaround_ReadyTime";
		QuickTurnaround_ReadyTime.Name = "QuickTurnaround_ReadyTime";
		QuickTurnaround_ReadyTime.Visible = false;
		QuickTurnaround_StanddownTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		QuickTurnaround_StanddownTime.DataPropertyName = "QuickTurnaround_AdditionalTimePenalty";
		QuickTurnaround_StanddownTime.HeaderText = "QuickTurnaround_StanddownTime";
		QuickTurnaround_StanddownTime.Name = "QuickTurnaround_StanddownTime";
		QuickTurnaround_StanddownTime.Visible = false;
		QuickTurnaround_TimeofDay.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		QuickTurnaround_TimeofDay.DataPropertyName = "QuickTurnaround_TimeofDay";
		QuickTurnaround_TimeofDay.HeaderText = "QuickTurnaround_TimeofDay";
		QuickTurnaround_TimeofDay.Name = "QuickTurnaround_TimeofDay";
		QuickTurnaround_TimeofDay.Visible = false;
		MenuStrip1.BackColor = Color.FromArgb(60, 63, 65);
		MenuStrip1.ForeColor = Color.FromArgb(220, 220, 220);
		MenuStrip1.Items.AddRange(new ToolStripItem[1] { CheckHostsMagazinesToolStripMenuItem });
		MenuStrip1.Location = new Point(0, 0);
		MenuStrip1.Name = "MenuStrip1";
		MenuStrip1.Padding = new Padding(3, 2, 0, 2);
		MenuStrip1.Size = new Size(1094, 24);
		MenuStrip1.TabIndex = 15;
		MenuStrip1.Text = "MenuStrip1";
		CheckHostsMagazinesToolStripMenuItem.BackColor = Color.FromArgb(60, 63, 65);
		CheckHostsMagazinesToolStripMenuItem.ForeColor = Color.FromArgb(220, 220, 220);
		CheckHostsMagazinesToolStripMenuItem.Name = "CheckHostsMagazinesToolStripMenuItem";
		CheckHostsMagazinesToolStripMenuItem.Size = new Size(138, 20);
		CheckHostsMagazinesToolStripMenuItem.Text = "检查基础弹药库";
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Label1.AutoSize = true;
		Label1.ForeColor = Color.FromArgb(220, 220, 220);
		Label1.Location = new Point(655, 459);
		Label1.MaximumSize = new Size(400, 40);
		Label1.MinimumSize = new Size(400, 40);
		Label1.Name = "Label1";
		Label1.Size = new Size(400, 40);
		Label1.TabIndex = 31;
		Label1.Text = "武器状态";
		FlowLayoutPanel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		FlowLayoutPanel1.BackColor = Color.FromArgb(60, 63, 65);
		FlowLayoutPanel1.Controls.Add(CB_QuickTurnaround);
		FlowLayoutPanel1.Controls.Add(Combo_NumberOfSorties);
		FlowLayoutPanel1.Controls.Add(Label_QuickTurnaroundInfo);
		FlowLayoutPanel1.Location = new Point(3, 348);
		FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		FlowLayoutPanel1.Size = new Size(1088, 31);
		FlowLayoutPanel1.TabIndex = 37;
		CB_QuickTurnaround.Anchor = AnchorStyles.Left;
		CB_QuickTurnaround.Location = new Point(3, 5);
		CB_QuickTurnaround.Name = "CB_QuickTurnaround";
		CB_QuickTurnaround.Size = new Size(148, 17);
		CB_QuickTurnaround.TabIndex = 32;
		CB_QuickTurnaround.Text = "启用快速再次出动";
		Combo_NumberOfSorties.Anchor = AnchorStyles.Left;
		Combo_NumberOfSorties.BackColor = Color.FromArgb(60, 63, 65);
		Combo_NumberOfSorties.DrawMode = DrawMode.OwnerDrawFixed;
		Combo_NumberOfSorties.DropDownStyle = ComboBoxStyle.DropDownList;
		Combo_NumberOfSorties.Font = new Font("Segoe UI", 7f);
		Combo_NumberOfSorties.FormattingEnabled = true;
		Combo_NumberOfSorties.Location = new Point(157, 3);
		Combo_NumberOfSorties.Name = "Combo_NumberOfSorties";
		Combo_NumberOfSorties.Size = new Size(166, 21);
		Combo_NumberOfSorties.TabIndex = 33;
		Label_QuickTurnaroundInfo.Anchor = AnchorStyles.Left;
		Label_QuickTurnaroundInfo.AutoSize = true;
		Label_QuickTurnaroundInfo.ForeColor = Color.FromArgb(220, 220, 220);
		Label_QuickTurnaroundInfo.Location = new Point(329, 6);
		Label_QuickTurnaroundInfo.Name = "Label_QuickTurnaroundInfo";
		Label_QuickTurnaroundInfo.Size = new Size(41, 15);
		Label_QuickTurnaroundInfo.TabIndex = 34;
		Label_QuickTurnaroundInfo.Text = "Label1";
		base.AutoScaleMode = AutoScaleMode.None;
		base.ClientSize = new Size(1094, 564);
		base.Controls.Add(FlowLayoutPanel1);
		base.Controls.Add(Label1);
		base.Controls.Add(CB_ShowOnlyUsable);
		base.Controls.Add(Button5);
		base.Controls.Add(Button4);
		base.Controls.Add(Label8);
		base.Controls.Add(Label7);
		base.Controls.Add(Label6);
		base.Controls.Add(Label5);
		base.Controls.Add(Label2);
		base.Controls.Add(Button3);
		base.Controls.Add(Button2);
		base.Controls.Add(Button1);
		base.Controls.Add(Label_Loadout);
		base.Controls.Add(DGV_LoadoutItems);
		base.Controls.Add(DGV_Loadouts);
		base.Controls.Add(MenuStrip1);
		base.KeyPreview = true;
		base.MainMenuStrip = MenuStrip1;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ReadyAircraft";
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "使飞机就绪";
		((ISupportInitialize)DGV_LoadoutItems).EndInit();
		((ISupportInitialize)DGV_Loadouts).EndInit();
		MenuStrip1.ResumeLayout(performLayout: false);
		MenuStrip1.PerformLayout();
		FlowLayoutPanel1.ResumeLayout(performLayout: false);
		FlowLayoutPanel1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void CancelInterruptibleConnection(object sender, FormClosingEventArgs e)
	{
		ItemExporter.ConnectInterruptibleTemplate.MainForm.BringToFront();
	}

	private void VerifyInterruptibleConnection(object sender, EventArgs e)
	{
		if (Client._StateClass == 1f)
		{
			base.AutoScaleMode = AutoScaleMode.None;
		}
		Button3.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		Button4.Visible = Client.CurrentGame.GameMode == Game._GameMode.ScenEdit;
		if (SimConfiguration.DefaultGamePreferences.OnlyShowAvailableLoadouts)
		{
			CB_ShowOnlyUsable.Checked = true;
		}
		else
		{
			CB_ShowOnlyUsable.Checked = false;
		}
		ListInterruptibleConnection();
		string text;
		string text2;
		if (SelectedAircraft.Count <= 0)
		{
			if (!Information.IsNothing(SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
			{
				text = SelectedEmptySlot[0].ReferenceUnit_UnitClass;
				text2 = SelectedEmptySlot[0].CurrentHostUnit_Name;
			}
			else
			{
				text = "<无所选单元>";
				text2 = "<无所选主机单元>";
			}
		}
		else
		{
			text = Misc.ReadRequest(SelectedAircraft[0].UnitClass);
			text2 = SelectedAircraft[0].AirOps.CurrentHostUnit.Name;
		}
		int num = SelectedAircraft.Count;
		if (!Information.IsNothing(SelectedEmptySlot))
		{
			num += SelectedEmptySlot.Count;
		}
		Text = "就绪飞机：" + Conversions.ToString(num) + "x " + text + "在" + text2;
	}

	private void ListInterruptibleConnection()
	{
		List<Aircraft> selectedAircraft = SelectedAircraft;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		bool bool_ = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
		_EventSchema = DBFunctions.GetSelectedAircraftTotalWeaponQty(selectedAircraft, ref sqliteConnection_, ref bool_);
		if (SelectedAircraft.Count <= 0)
		{
			if (Information.IsNothing(SelectedEmptySlot) || SelectedEmptySlot.Count <= 0)
			{
				return;
			}
			Scenario scenario_ = Client.CurrentScenario;
			Aircraft aircraft_ = new Aircraft(ref scenario_);
			aircraft_.AirOps.CurrentHostUnit = SelectedEmptySlot[0].GetCurrentHostUnit(Client.CurrentScenario);
			int referenceUnit_DBID = SelectedEmptySlot[0].ReferenceUnit_DBID;
			Dictionary<int, int> eventSchema = _EventSchema;
			sqliteConnection_ = Client.CurrentScenario.DBConnection;
			Scenario currentScenario = Client.CurrentScenario;
			bool bool_2 = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
			scenario_ = Client.CurrentScenario;
			int int_ = 0;
			bool_ = false;
			m_AttributeSchema = DBFunctions.LoadoutsForThisAircraft_DT(referenceUnit_DBID, eventSchema, ref sqliteConnection_, currentScenario, ref bool_2, ref scenario_, ref aircraft_, ref int_, ref bool_);
		}
		else
		{
			int dBID = SelectedAircraft[0].DBID;
			Dictionary<int, int> eventSchema2 = _EventSchema;
			sqliteConnection_ = Client.CurrentScenario.DBConnection;
			Scenario currentScenario2 = Client.CurrentScenario;
			bool_ = Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines);
			Scenario scenario_2 = Client.CurrentScenario;
			List<Aircraft> selectedAircraft2 = SelectedAircraft;
			Aircraft aircraft_2 = selectedAircraft2[0];
			int int_2 = 0;
			bool bool_3 = false;
			DataTable attributeSchema = DBFunctions.LoadoutsForThisAircraft_DT(dBID, eventSchema2, ref sqliteConnection_, currentScenario2, ref bool_, ref scenario_2, ref aircraft_2, ref int_2, ref bool_3);
			selectedAircraft2[0] = aircraft_2;
			m_AttributeSchema = attributeSchema;
		}
		DataView dataView = new DataView(m_AttributeSchema);
		if (Client.CurrentScenario.Cache_DisabledLoadouts.Count > 0)
		{
			dataView.RowFilter = "ID Not In (" + string.Join(",", Client.CurrentScenario.Cache_DisabledLoadouts) + ")";
		}
		if (CB_ShowOnlyUsable.Checked)
		{
			if (Client.CurrentScenario.Cache_DisabledLoadouts.Count > 0)
			{
				dataView.RowFilter += "和";
			}
			dataView.RowFilter += "NOT NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly = '0'";
		}
		DGV_Loadouts.DataSource = dataView;
		if (SelectedLoadout == 0)
		{
			SelectedLoadout = Conversions.ToInteger(DGV_Loadouts.Rows[0].Cells["ID"].Value);
		}
		AssetInterruptibleConnection(_EventSchema);
		foreach (Aircraft item in SelectedAircraft)
		{
			if (!Information.IsNothing(item.Loadout) && !globalSchema.Contains(item.Int32_0))
			{
				globalSchema.Add(item.Int32_0);
			}
		}
		if (!Information.IsNothing(SelectedEmptySlot))
		{
			foreach (Mission.EmptyAircraftSlot item2 in SelectedEmptySlot)
			{
				if (item2.int_0 != 0 && !globalSchema.Contains(item2.int_0))
				{
					globalSchema.Add(item2.int_0);
				}
			}
		}
		if (globalSchema.Count == 1)
		{
			int num = globalSchema.ElementAtOrDefault(0);
			IEnumerator enumerator3 = null;
			try
			{
				enumerator3 = ((IEnumerable)DGV_Loadouts.Rows).GetEnumerator();
				while (enumerator3.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator3.Current;
					if (Conversions.ToInteger(dataGridViewRow.Cells["ID"].Value) != num)
					{
						dataGridViewRow.Selected = false;
						continue;
					}
					dataGridViewRow.Selected = true;
					break;
				}
				return;
			}
			finally
			{
				if (enumerator3 is IDisposable)
				{
					(enumerator3 as IDisposable).Dispose();
				}
			}
		}
		IEnumerator enumerator4 = null;
		try
		{
			enumerator4 = ((IEnumerable)DGV_Loadouts.Rows).GetEnumerator();
			while (enumerator4.MoveNext())
			{
				((DataGridViewRow)enumerator4.Current).Selected = false;
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

	private int ResolveInterruptibleConnection(int int_0, Dictionary<int, int> dictionary_0, bool bool_0)
	{
		try
		{
			if (Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				return int.MaxValue;
			}
			int num = 9999999;
			DataTable dataTable = new DataTable();
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			dataTable = DBFunctions.ItemsForThisLoadout(int_0, ref sqliteConnection_, ref bool_0);
			ActiveUnit activeUnit = null;
			if (SelectedAircraft.Count <= 0)
			{
				if (!Information.IsNothing(SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
				{
					activeUnit = SelectedEmptySlot[0].GetCurrentHostUnit(Client.CurrentScenario);
				}
			}
			else
			{
				if (Information.IsNothing(SelectedAircraft[0]))
				{
					return 0;
				}
				activeUnit = SelectedAircraft[0].AirOps.CurrentHostUnit;
			}
			if (Information.IsNothing(activeUnit))
			{
				return 0;
			}
			IEnumerator enumerator = null;
			try
			{
				enumerator = dataTable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					if (bool_0 && Conversions.ToBoolean(dataRow["Optional"]))
					{
						continue;
					}
					int num2 = Conversions.ToInteger(dataRow["ComponentID"]);
					int num3 = Conversions.ToInteger(dataRow["Quantity"]);
					if (num3 != 0)
					{
						Scenario scenario_ = Client.CurrentScenario;
						if (!Weapon.WeaponIsNonRivalrous(num2, ref scenario_))
						{
							int num4 = activeUnit.Weaponry.HowManyOfThisWeaponOnMagazines(num2);
							int num5 = 0;
							if (!Information.IsNothing(dictionary_0) && dictionary_0.ContainsKey(num2))
							{
								num5 = dictionary_0[num2];
							}
							int num6 = (num4 + num5) / num3;
							if (num6 < num)
							{
								num = num6;
							}
						}
						continue;
					}
					return 0;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101137", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0;
		}
	}

	private void PostInterruptibleConnection(object sender, EventArgs e)
	{
		DefineInterruptibleConnection(bool_0: false, bool_1: true, bool_2: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
	}

	private void RunInterruptibleConnection(object sender, EventArgs e)
	{
		DefineInterruptibleConnection(bool_0: false, bool_1: true, bool_2: true, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
	}

	private void StartInterruptibleConnection(object sender, EventArgs e)
	{
		Close();
	}

	private void AssetInterruptibleConnection(Dictionary<int, int> dictionary_0)
	{
		try
		{
			if (Conversions.ToInteger(m_AttributeSchema.AsEnumerable().ElementAtOrDefault(0)["ID"]) <= 4)
			{
				Label2.Text = "";
				Label5.Text = "";
				Label1.Text = "";
				Label6.Text = "";
				Label7.Text = "";
				Label8.Text = "";
				_FactorySchema.Rows.Clear();
				return;
			}
			DataRow[] array = m_AttributeSchema.Select("ID = " + Conversions.ToString(SelectedLoadout));
			if (array.Count() > 0)
			{
				Label2.Text = Conversions.ToString(array[0]["LoadoutRoleDescription"]);
				Label1.Text = "挂载的默认武器状态 " + Conversions.ToString(array[0]["WinchesterShotgunDescription"]);
				Label5.Text = "默认攻击高度：" + Conversions.ToString(array[0]["AttackAltitude"]);
				Label6.Text = "弹药库中可用挂载：" + Conversions.ToString(array[0]["NumberOfLoadouts"]);
				Label7.Text = "可用挂载，包括挂载在当前选定飞机上的武器：" + Conversions.ToString(array[0]["NumberOfLoadoutsIncludingMountedWeapons"]);
				Label8.Text = "可用挂载，包括挂载在当前选定飞机上的武器，但仅限于强制（即不包括可选）武器：" + Conversions.ToString(array[0]["NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly"]);
			}
			int selectedLoadout = SelectedLoadout;
			SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
			bool bool_ = false;
			_FactorySchema = DBFunctions.ItemsForThisLoadout(selectedLoadout, ref sqliteConnection_, ref bool_);
			_FactorySchema.Columns.Add("Available");
			_FactorySchema.Columns.Add("AvailableTotal");
			IEnumerator enumerator = null;
			try
			{
				enumerator = _FactorySchema.Rows.GetEnumerator();
				ActiveUnit activeUnit = null;
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					int num = Conversions.ToInteger(dataRow["ComponentID"]);
					Scenario scenario_ = Client.CurrentScenario;
					if (Weapon.WeaponIsNonRivalrous(num, ref scenario_))
					{
						dataRow["Available"] = "-";
						dataRow["AvailableTotal"] = "-";
					}
					else if (Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
					{
						dataRow["Available"] = "Unlimited";
						dataRow["AvailableTotal"] = "Unlimited";
					}
					else
					{
						if (SelectedAircraft.Count <= 0)
						{
							if (!Information.IsNothing(SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
							{
								activeUnit = SelectedEmptySlot[0].GetCurrentHostUnit(Client.CurrentScenario);
							}
						}
						else if (!Information.IsNothing(SelectedAircraft[0]))
						{
							activeUnit = SelectedAircraft[0].AirOps.CurrentHostUnit;
						}
						int num2 = ((!Information.IsNothing(activeUnit)) ? activeUnit.Weaponry.HowManyOfThisWeaponOnMagazines(Conversions.ToInteger(dataRow["ComponentID"])) : 0);
						int num3 = 0;
						if (!Information.IsNothing(dictionary_0) && dictionary_0.ContainsKey(num))
						{
							num3 = dictionary_0[num];
						}
						dataRow["Available"] = num2;
						dataRow["AvailableTotal"] = num2 + num3;
					}
					dataRow["Item"] = Misc.ReadRequest(Conversions.ToString(dataRow["Item"]));
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			DGV_LoadoutItems.AutoGenerateColumns = false;
			DGV_LoadoutItems.DataSource = _FactorySchema;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101138", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PrintInterruptibleConnection(object sender, EventArgs e)
	{
		if (SelectedAircraft[0].AirOps.CurrentHostUnit.SharedMagazines.Length == 0)
		{
			DarkMessageBox.ShowError("目前这些飞机的主机没有弹药库。", "没有弹药库！");
			return;
		}
		Client.theMagazinesWindow = new Magazines();
		Client.theMagazinesWindow.SelectedUnit = SelectedAircraft[0].AirOps.CurrentHostUnit;
		Client.theMagazinesWindow.Show();
	}

	private void DefineInterruptibleConnection(bool bool_0, bool bool_1, bool bool_2, bool bool_3)
	{
		Cursor = Cursors.WaitCursor;
		try
		{
			if (SelectedAircraft.Count > 0)
			{
				foreach (Aircraft item in SelectedAircraft)
				{
					if (!Information.IsNothing(item.Loadout) && bool_3)
					{
						item.AirOps.UnloadStores();
					}
				}
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (Aircraft item2 in SelectedAircraft)
			{
				Aircraft aircraft_ = item2;
				Aircraft_AirOps aircraft_AirOps_ = aircraft_.AirOps;
				if (aircraft_AirOps_.QuickTurnaround_Enabled && !CB_QuickTurnaround.Checked && !flag)
				{
					if (aircraft_AirOps_.QuickTurnaround_SortiesFlown <= 0)
					{
						aircraft_AirOps_.UpdateQuickTurnaroundSettings_Reset(ref aircraft_AirOps_);
					}
					else
					{
						switch (DarkMessageBox.ShowWarning("飞机" + aircraft_.Name + "之前已启用快速再次出动，但当前所选挂载将禁用快速再次出动。您想保留新配置并解除戒备吗？", "禁用快速再次出动并解除戒备？", DarkDialogButton.YesNoCancel))
						{
						case DialogResult.No:
							flag2 = true;
							break;
						default:
							flag = true;
							break;
						case DialogResult.Yes:
							aircraft_AirOps_.QuickTurnaround_Enabled = false;
							aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_);
							break;
						}
					}
				}
				if (aircraft_AirOps_.QuickTurnaround_Enabled && !flag)
				{
					Loadout loadout = DBFunctions.GetLoadout(ref aircraft_.ParentScen, SelectedLoadout, bool_0: false, bool_1: false);
					if (aircraft_AirOps_.QuickTurnaround_SortiesFlown >= loadout.QuickTurnaround_MaxSorties && loadout.QuickTurnaround)
					{
						switch (DarkMessageBox.ShowWarning("飞机" + aircraft_.Name + "比选定的挂载允许飞行更多的快速再次出动架次。您想切换到新的挂载并解除戒备吗？", "解除戒备？", DarkDialogButton.YesNoCancel))
						{
						case DialogResult.No:
							flag3 = true;
							break;
						default:
							flag = true;
							break;
						case DialogResult.Yes:
							aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_);
							flag2 = false;
							break;
						}
					}
					else if (!loadout.QuickTurnaround)
					{
						aircraft_AirOps_.UpdateQuickTurnaroundSettings_Reset(ref aircraft_AirOps_);
					}
					if (!flag && aircraft_AirOps_.QuickTurnaround_SortiesFlown > 0)
					{
						float num = aircraft_AirOps_.QuickTurnaround_AirborneTime_Flown / (float)aircraft_AirOps_.QuickTurnaround_SortiesFlown;
						if ((double)num > (double)(aircraft_.Loadout.QuickTurnaround_AirborneTime * 60) / (double)(Combo_NumberOfSorties.SelectedIndex + 2) && !flag)
						{
							if (aircraft_AirOps_.QuickTurnaround_SortiesFlown <= Combo_NumberOfSorties.SelectedIndex + 2 - 2)
							{
								if (num + aircraft_AirOps_.QuickTurnaround_AirborneTime_Flown >= (float)(aircraft_.Loadout.QuickTurnaround_AirborneTime * 60))
								{
									flag4 = true;
								}
							}
							else
							{
								flag4 = true;
							}
							if (flag4)
							{
								switch (DarkMessageBox.ShowWarning("飞机" + aircraft_.Name + "已经飞过了" + Conversions.ToString(aircraft_AirOps_.QuickTurnaround_SortiesFlown) + "的" + Conversions.ToString(loadout.QuickTurnaround_MaxSorties) + "快速再次出动架次。总的滞空时间是" + Misc.UpdateRequest((long)Math.Round(aircraft_AirOps_.QuickTurnaround_AirborneTime_Flown)) + "，允许滞空时间是" + Misc.UpdateRequest(aircraft_.Loadout.QuickTurnaround_AirborneTime * 60) + "。完成架次的平均滞空时间是" + Misc.UpdateRequest((long)Math.Round(num)) + "，大于剩余的允许滞空时间。因此飞机需要解除戒备。您想切换到新的挂载并解除戒备吗？", "解除戒备？", DarkDialogButton.YesNoCancel))
								{
								case DialogResult.No:
									flag3 = true;
									break;
								default:
									flag = true;
									break;
								case DialogResult.Yes:
									aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_);
									flag2 = false;
									break;
								}
							}
						}
					}
				}
				int num2 = ((!Information.IsNothing(aircraft_.Loadout)) ? aircraft_.Loadout.DBID : 0);
				if (aircraft_.Loadout == null || aircraft_.Loadout.Weapons.Count() <= 0)
				{
					aircraft_.Loadout = null;
					aircraft_.Weaponry.ClearCachedWeapons();
				}
				ActiveUnit currentHostUnit = aircraft_AirOps_.CurrentHostUnit;
				if (flag3 || flag)
				{
					currentHostUnit.AirOps.OutfitAC(ref aircraft_, num2, num2, bool_0, bool_2, bool_3, bool_1, bool_4: true);
				}
				else
				{
					currentHostUnit.AirOps.OutfitAC(ref aircraft_, SelectedLoadout, num2, bool_0, bool_2, bool_3, bool_1, bool_4: true);
				}
				currentHostUnit.AirOps.RefuelAC_Simple(ref aircraft_);
				currentHostUnit.AirOps.RepairAC(ref aircraft_);
				if (bool_0 && currentHostUnit.IsShip)
				{
					aircraft_AirOps_.HostAirFacility = currentHostUnit.AirOps.CalcClient(aircraft_);
					if (aircraft_AirOps_.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
					{
						aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
					}
				}
				if (CB_QuickTurnaround.CheckState != CheckState.Indeterminate)
				{
					if (!flag2 && !flag)
					{
						aircraft_AirOps_.QuickTurnaround_Enabled = CB_QuickTurnaround.Checked;
					}
					if (Information.IsNothing(mapperSchema))
					{
						if (!flag2 && !flag && !CB_QuickTurnaround.Checked)
						{
							aircraft_AirOps_.QuickTurnaround_SortiesTotal = 0;
						}
					}
					else if (Combo_NumberOfSorties.SelectedIndex >= 0 && Combo_NumberOfSorties.SelectedIndex + 2 <= aircraft_.Loadout.QuickTurnaround_MaxSorties)
					{
						aircraft_AirOps_.QuickTurnaround_SortiesTotal = Combo_NumberOfSorties.SelectedIndex + 2;
					}
					else
					{
						mapperSchema = null;
					}
				}
				if (!Information.IsNothing(aircraft_.AssignedMissionOrPackage()))
				{
					aircraft_.AssignedMissionOrPackage().TimeSincePlayerNotification = 0;
				}
			}
			if (!Information.IsNothing(SelectedEmptySlot))
			{
				foreach (Mission.EmptyAircraftSlot item3 in SelectedEmptySlot)
				{
					item3.int_0 = SelectedLoadout;
					item3.Loadout_ExcludeOptionalWeapons = bool_2;
					if (!flag)
					{
						item3.Loadout_QuickTurnaround = CB_QuickTurnaround.Checked;
					}
					if (Information.IsNothing(mapperSchema))
					{
						if (!flag && !CB_QuickTurnaround.Checked)
						{
							item3.Loadout_QuickTurnaround_NumberOfSorties = 0;
						}
					}
					else if (Combo_NumberOfSorties.SelectedIndex >= 0 && Combo_NumberOfSorties.SelectedIndex + 2 <= item3.Loadout_QuickTurnaround_MaxSorties)
					{
						item3.Loadout_QuickTurnaround_NumberOfSorties = Combo_NumberOfSorties.SelectedIndex + 2;
					}
					else
					{
						mapperSchema = null;
					}
					Scenario scenario_ = Client.CurrentScenario;
					Loadout loadout2 = DBFunctions.GetLoadout(ref scenario_, SelectedLoadout, bool_0: false, bool_1: false);
					item3.LoadoutName = loadout2.Name;
					item3.Loadout_QuickTurnaround_MaxSorties = loadout2.QuickTurnaround_MaxSorties;
				}
			}
			if (ItemExporter.ConnectInterruptibleTemplate.AirOps.Visible)
			{
				ItemExporter.ConnectInterruptibleTemplate.AirOps.RefreshForm();
			}
			if (!Information.IsNothing(Client.MissionEditorWindow) && Client.MissionEditorWindow.Visible)
			{
				Client.MissionEditorWindow.RefreshAll();
			}
			Cursor = Cursors.Default;
			if (!flag)
			{
				Close();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101139", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PublishInterruptibleConnection(object sender, EventArgs e)
	{
		DefineInterruptibleConnection(bool_0: true, bool_1: true, bool_2: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
	}

	private void AwakeInterruptibleConnection(object sender, EventArgs e)
	{
		DefineInterruptibleConnection(bool_0: true, bool_1: true, bool_2: false, bool_3: false);
	}

	private void QueryInterruptibleConnection(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			SelectedLoadout = Conversions.ToInteger(DGV_Loadouts.Rows[e.RowIndex].Cells["ID"].Value);
			if (ResolveInterruptibleConnection(SelectedLoadout, _EventSchema, bool_0: false) > 0)
			{
				DefineInterruptibleConnection(bool_0: false, bool_1: true, bool_2: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
			}
		}
	}

	private void ResetInterruptibleConnection(object sender, EventArgs e)
	{
		if (DGV_Loadouts.SelectedRows.Count != 0)
		{
			SelectedLoadout = Conversions.ToInteger(DGV_Loadouts.SelectedRows[0].Cells["ID"].Value);
			if (!Information.IsNothing(SelectedEmptySlot) && SelectedEmptySlot.Count > 0)
			{
				Button1.Enabled = true;
				Button5.Enabled = true;
				Button3.Enabled = false;
				Button4.Enabled = false;
			}
			else
			{
				Button1.Enabled = ResolveInterruptibleConnection(SelectedLoadout, _EventSchema, bool_0: false) > 0;
				Button5.Enabled = ResolveInterruptibleConnection(SelectedLoadout, _EventSchema, bool_0: true) > 0;
				Button3.Enabled = Button1.Enabled;
				Button4.Enabled = true;
			}
			AssetInterruptibleConnection(_EventSchema);
			MapInterruptibleConnection();
		}
	}

	private void MapInterruptibleConnection()
	{
		bool flag = true;
		int num = 0;
		int num2 = 0;
		List<Aircraft> selectedAircraft = SelectedAircraft;
		Aircraft aircraft = null;
		if (selectedAircraft != null && selectedAircraft.Count > 0)
		{
			aircraft = SelectedAircraft[0];
		}
		bool? flag2 = null;
		DataRow[] array;
		if (aircraft?.Loadout != null && globalSchema.Count == 1 && globalSchema.ElementAtOrDefault(0) == SelectedLoadout)
		{
			array = m_AttributeSchema.Select("ID = " + Conversions.ToString(globalSchema.ElementAtOrDefault(0)));
			if (array.Count() > 0)
			{
				byte? b = (byte?)aircraft.Doctrine.GetAirOpsTempo(aircraft.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					m_WorkerSchema = Misc.UpdateRequest(aircraft.Loadout.ReadyTime_Sustained * 60);
				}
				else
				{
					m_WorkerSchema = Misc.UpdateRequest(aircraft.Loadout.ReadyTime * 60);
				}
				accountSchema = aircraft.Loadout.QuickTurnaround;
				_AuthenticationSchema = aircraft.Loadout.QuickTurnaround_ReadyTime;
				m_InfoSchema = aircraft.Loadout.QuickTurnaround_MaxSorties;
				_HelperSchema = aircraft.Loadout.QuickTurnaround_AdditionalTimePenalty;
				m_StateSchema = aircraft.Loadout.QuickTurnaround_AirborneTime;
			}
			foreach (Aircraft item in SelectedAircraft)
			{
				num++;
				Aircraft_AirOps airOps = item.AirOps;
				if (num == 1)
				{
					flag2 = airOps.QuickTurnaround_Enabled;
					mapperSchema = airOps.QuickTurnaround_SortiesTotal;
					continue;
				}
				bool quickTurnaround_Enabled = airOps.QuickTurnaround_Enabled;
				bool? flag3 = (flag2.HasValue ? new bool?(quickTurnaround_Enabled != flag2.GetValueOrDefault()) : null);
				if (flag3.GetValueOrDefault(true) && !Information.IsNothing(flag2) && flag3.HasValue)
				{
					flag2 = null;
				}
				int quickTurnaround_SortiesTotal = airOps.QuickTurnaround_SortiesTotal;
				int? num3 = mapperSchema;
				flag3 = (num3.HasValue ? new bool?(quickTurnaround_SortiesTotal != num3.GetValueOrDefault()) : null);
				if (flag3.GetValueOrDefault(true) && !Information.IsNothing(mapperSchema) && flag3.HasValue)
				{
					mapperSchema = null;
				}
			}
			if (!Information.IsNothing(SelectedEmptySlot))
			{
				foreach (Mission.EmptyAircraftSlot item2 in SelectedEmptySlot)
				{
					num2++;
					if (num > 0 && num2 == 1)
					{
						flag2 = item2.Loadout_QuickTurnaround;
						mapperSchema = item2.Loadout_QuickTurnaround_NumberOfSorties;
						continue;
					}
					bool loadout_QuickTurnaround = item2.Loadout_QuickTurnaround;
					bool? flag4 = (flag2.HasValue ? new bool?(loadout_QuickTurnaround != flag2.GetValueOrDefault()) : null);
					if (flag4.GetValueOrDefault(true) && !Information.IsNothing(flag2) && flag4.HasValue)
					{
						flag2 = null;
					}
					int loadout_QuickTurnaround_NumberOfSorties = item2.Loadout_QuickTurnaround_NumberOfSorties;
					int? num4 = mapperSchema;
					flag4 = (num4.HasValue ? new bool?(loadout_QuickTurnaround_NumberOfSorties != num4.GetValueOrDefault()) : null);
					if (flag4.GetValueOrDefault(true) && !Information.IsNothing(mapperSchema) && flag4.HasValue)
					{
						mapperSchema = null;
					}
				}
			}
		}
		else if (!Information.IsNothing(SelectedEmptySlot) && SelectedEmptySlot.Count > 0 && globalSchema.Count == 1 && globalSchema.ElementAtOrDefault(0) == SelectedLoadout)
		{
			array = m_AttributeSchema.Select("ID = " + Conversions.ToString(SelectedLoadout));
			if (array.Count() > 0)
			{
				m_WorkerSchema = Conversions.ToString(array[0]["ReadyTime"]);
				accountSchema = Conversions.ToBoolean(array[0]["QuickTurnaround"]);
				_AuthenticationSchema = Conversions.ToInteger(array[0]["QuickTurnaround_ReadyTime"]);
				m_InfoSchema = Conversions.ToInteger(array[0]["QuickTurnaround_MaxSorties"]);
				_HelperSchema = Conversions.ToInteger(array[0]["QuickTurnaround_AdditionalTimePenalty"]);
				m_StateSchema = Conversions.ToInteger(array[0]["QuickTurnaround_AirborneTime"]);
			}
			foreach (Mission.EmptyAircraftSlot item3 in SelectedEmptySlot)
			{
				num2++;
				if (num2 == 1)
				{
					flag2 = item3.Loadout_QuickTurnaround;
					mapperSchema = item3.Loadout_QuickTurnaround_NumberOfSorties;
					continue;
				}
				bool loadout_QuickTurnaround2 = item3.Loadout_QuickTurnaround;
				bool? flag5 = (flag2.HasValue ? new bool?(loadout_QuickTurnaround2 != flag2.GetValueOrDefault()) : null);
				if (flag5.GetValueOrDefault(true) && !Information.IsNothing(flag2) && flag5.HasValue)
				{
					flag2 = null;
				}
				int loadout_QuickTurnaround_NumberOfSorties2 = item3.Loadout_QuickTurnaround_NumberOfSorties;
				int? num5 = mapperSchema;
				flag5 = (num5.HasValue ? new bool?(loadout_QuickTurnaround_NumberOfSorties2 != num5.GetValueOrDefault()) : null);
				if (flag5.GetValueOrDefault(true) && !Information.IsNothing(mapperSchema) && flag5.HasValue)
				{
					mapperSchema = null;
				}
			}
		}
		else
		{
			array = m_AttributeSchema.Select("ID = " + Conversions.ToString(SelectedLoadout));
			if (array.Count() > 0)
			{
				m_WorkerSchema = Conversions.ToString(array[0]["ReadyTime"]);
				accountSchema = Conversions.ToBoolean(array[0]["QuickTurnaround"]);
				_AuthenticationSchema = Conversions.ToInteger(array[0]["QuickTurnaround_ReadyTime"]);
				m_InfoSchema = Conversions.ToInteger(array[0]["QuickTurnaround_MaxSorties"]);
				_HelperSchema = Conversions.ToInteger(array[0]["QuickTurnaround_AdditionalTimePenalty"]);
				m_StateSchema = Conversions.ToInteger(array[0]["QuickTurnaround_AirborneTime"]);
			}
		}
		if (accountSchema)
		{
			if (Information.IsNothing(aircraft))
			{
				if (!Information.IsNothing(SelectedEmptySlot) && SelectedEmptySlot.Count <= 0)
				{
				}
			}
			else
			{
				byte? b2 = (byte?)aircraft.Doctrine.GetQuickTurnAroundForAicraft(aircraft.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 2) : null).GetValueOrDefault())
				{
					flag = false;
				}
				else
				{
					b2 = (byte?)aircraft.Doctrine.GetQuickTurnAroundForAicraft(aircraft.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
					{
						if (array.Count() <= 0)
						{
							flag = false;
						}
						else
						{
							Loadout loadout = new Loadout(Conversions.ToInteger(array[0]["ID"]), Conversions.ToString(array[0]["Name"]), 0, 0, 0, 0, (Loadout.LoadoutRole)Conversions.ToInteger(array[0]["LoadoutRole"]), (Loadout._LoadoutDayNight)0, Command_Core.Loadout._LoadoutWeather.AllWeather, 0f, 0, 0, bool_0: false, bool_1: false, Conversions.ToBoolean(array[0]["QuickTurnaround"]), Conversions.ToInteger(array[0]["QuickTurnaround_ReadyTime"]), Conversions.ToInteger(array[0]["QuickTurnaround_MaxSorties"]), Conversions.ToInteger(array[0]["QuickTurnaround_AdditionalTimePenalty"]), Conversions.ToInteger(array[0]["QuickTurnaround_AirborneTime"]), (Loadout._LoadoutDayNight)1, Doctrine._WeaponState.LoadoutSetting);
							if (!loadout.IsAAW && !loadout.IsSupportOrPatrol && !loadout.IsASW)
							{
								flag = false;
							}
						}
					}
				}
			}
		}
		else
		{
			flag = false;
		}
		m_ManagerSchema = false;
		if (globalSchema.Count == 1 && globalSchema.ElementAtOrDefault(0) == SelectedLoadout)
		{
			if (flag)
			{
				CB_QuickTurnaround.Enabled = true;
				if (Information.IsNothing(flag2))
				{
					CB_QuickTurnaround.CheckState = CheckState.Indeterminate;
					RegisterInterruptibleConnection(mapperSchema);
					Combo_NumberOfSorties.Enabled = false;
					Label_QuickTurnaroundInfo.Enabled = true;
					Label_QuickTurnaroundInfo.Text = "选择包括具有和不具有快速再次出动能力的飞机。";
				}
				else if (flag2.GetValueOrDefault())
				{
					if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
					{
						CB_QuickTurnaround.CheckState = CheckState.Checked;
					}
					else
					{
						CB_QuickTurnaround.Checked = true;
					}
					RegisterInterruptibleConnection(mapperSchema);
					Combo_NumberOfSorties.Enabled = true;
					Label_QuickTurnaroundInfo.Enabled = true;
					if (Information.IsNothing(mapperSchema))
					{
						Label_QuickTurnaroundInfo.Text = "";
					}
					else
					{
						Label_QuickTurnaroundInfo.Text = ForgotInterruptibleConnection();
					}
				}
				else
				{
					if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
					{
						CB_QuickTurnaround.CheckState = CheckState.Unchecked;
					}
					else
					{
						CB_QuickTurnaround.Checked = false;
					}
					RegisterInterruptibleConnection(m_InfoSchema);
				}
			}
			else
			{
				CB_QuickTurnaround.Enabled = false;
				if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
				{
					CB_QuickTurnaround.CheckState = CheckState.Unchecked;
				}
				else
				{
					CB_QuickTurnaround.Checked = false;
				}
				RegisterInterruptibleConnection(0);
			}
		}
		else
		{
			if (flag)
			{
				if (accountSchema)
				{
					CB_QuickTurnaround.Enabled = true;
					if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
					{
						CB_QuickTurnaround.CheckState = CheckState.Unchecked;
					}
					else
					{
						CB_QuickTurnaround.Checked = false;
					}
				}
				else
				{
					CB_QuickTurnaround.Enabled = false;
					if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
					{
						CB_QuickTurnaround.CheckState = CheckState.Unchecked;
					}
					else
					{
						CB_QuickTurnaround.Checked = false;
					}
				}
			}
			else
			{
				CB_QuickTurnaround.Enabled = false;
				if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate)
				{
					CB_QuickTurnaround.CheckState = CheckState.Unchecked;
				}
				else
				{
					CB_QuickTurnaround.Checked = false;
				}
			}
			RegisterInterruptibleConnection(m_InfoSchema);
		}
		m_ManagerSchema = true;
	}

	private void SortInterruptibleConnection(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex != -1 && (object)DGV_LoadoutItems.Columns[e.ColumnIndex].CellType == typeof(DataGridViewLinkCell))
		{
			int int_ = Conversions.ToInteger(_FactorySchema.Rows[e.RowIndex]["ComponentID"]);
			Client.smethod_0("Weapon", int_);
		}
	}

	private void CalcInterruptibleConnection(object sender, DataGridViewCellFormattingEventArgs e)
	{
		try
		{
			if (!Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines))
			{
				DataGridViewRow dataGridViewRow = DGV_Loadouts.Rows[e.RowIndex];
				if (Operators.CompareString(DGV_Loadouts.Columns[e.ColumnIndex].Name, "NumberOfLoadoutsIncludingMountedWeapon_MandatoryOnly", TextCompare: true) == 0 && (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(e.Value)) || Conversions.ToInteger(e.Value) <= 0) && Operators.CompareString(Conversions.ToString(e.Value), "Unlimited", TextCompare: true) != 0)
				{
					dataGridViewRow.DefaultCellStyle.ForeColor = Color.DarkGray;
					dataGridViewRow.DefaultCellStyle.Font = new Font(Font, FontStyle.Italic);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200110", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RateInterruptibleConnection(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape && base.Visible)
		{
			Close();
		}
		else if (e.KeyCode == Keys.Return && base.Visible)
		{
			if (ResolveInterruptibleConnection(SelectedLoadout, _EventSchema, bool_0: false) > 0)
			{
				DefineInterruptibleConnection(bool_0: false, bool_1: true, bool_2: false, !Client.CurrentScenario.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.UnlimitedBaseMagazines));
			}
		}
		else if (!base.Visible || (e.KeyCode != Keys.Prior && e.KeyCode != Keys.Next && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right && e.KeyCode != Keys.Add && e.KeyCode != Keys.Subtract))
		{
			ItemExporter.ConnectInterruptibleTemplate.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void FlushInterruptibleConnection(object sender, EventArgs e)
	{
		Label_QuickTurnaroundInfo.Text = ForgotInterruptibleConnection();
		if (m_ManagerSchema)
		{
			if (Combo_NumberOfSorties.SelectedIndex + 2 <= m_InfoSchema && Combo_NumberOfSorties.SelectedIndex >= 0)
			{
				mapperSchema = Combo_NumberOfSorties.SelectedIndex + 2;
			}
			else
			{
				mapperSchema = null;
			}
		}
	}

	private string ForgotInterruptibleConnection()
	{
		if (Combo_NumberOfSorties.SelectedIndex + 2 <= m_InfoSchema)
		{
			return Conversions.ToString(Combo_NumberOfSorties.SelectedIndex + 2) + " 架次 @ " + Misc.UpdateRequest(m_StateSchema * 60) + "最大滞空时间和" + Misc.UpdateRequest(_AuthenticationSchema * 60) + "转弯，有" + m_WorkerSchema + "退出戒备准备时间";
		}
		return "";
	}

	private void CollectInterruptibleConnection(int? nullable_0)
	{
		Combo_NumberOfSorties.Items.Clear();
		if (CB_QuickTurnaround.CheckState == CheckState.Indeterminate || !CB_QuickTurnaround.Checked)
		{
			return;
		}
		int infoSchema = m_InfoSchema;
		for (int i = 2; i <= infoSchema; i++)
		{
			if (i == m_InfoSchema)
			{
				Combo_NumberOfSorties.Items.Add(Conversions.ToString(i) + "架次（最大）");
			}
			else
			{
				Combo_NumberOfSorties.Items.Add(Conversions.ToString(i) + "架次");
			}
		}
		if (!Information.IsNothing(nullable_0) && Combo_NumberOfSorties.Items.Count > 0)
		{
			Combo_NumberOfSorties.SelectedIndex = Combo_NumberOfSorties.Items.Count - 1;
			return;
		}
		Combo_NumberOfSorties.Items.Add("Various");
		Combo_NumberOfSorties.SelectedIndex = Combo_NumberOfSorties.Items.Count - 1;
	}

	private void OrderInterruptibleConnection(object sender, EventArgs e)
	{
		RegisterInterruptibleConnection(m_InfoSchema);
	}

	private void RegisterInterruptibleConnection(int? nullable_0)
	{
		if (CB_QuickTurnaround.Checked)
		{
			Combo_NumberOfSorties.Enabled = true;
			CollectInterruptibleConnection(nullable_0);
			Label_QuickTurnaroundInfo.Enabled = true;
			Label_QuickTurnaroundInfo.Text = ForgotInterruptibleConnection();
		}
		else
		{
			Combo_NumberOfSorties.Enabled = false;
			CollectInterruptibleConnection(nullable_0);
			Label_QuickTurnaroundInfo.Enabled = false;
			Label_QuickTurnaroundInfo.Text = "";
		}
	}

	private void ManageInterruptibleConnection(object sender, EventArgs e)
	{
		ListInterruptibleConnection();
		if (CB_ShowOnlyUsable.Checked)
		{
			SimConfiguration.DefaultGamePreferences.OnlyShowAvailableLoadouts = true;
		}
		else
		{
			SimConfiguration.DefaultGamePreferences.OnlyShowAvailableLoadouts = false;
		}
	}
}
