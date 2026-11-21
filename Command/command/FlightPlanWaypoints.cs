using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanWaypoints : UserControl
{
	private IContainer _RequestFilter;

	[AccessedThroughProperty("DGV_Waypoints")]
	[CompilerGenerated]
	private DarkDataGridView valueFilter;

	[AccessedThroughProperty("Button_InsertWaypoint")]
	[CompilerGenerated]
	private DarkUIButton tokenizerFilter;

	[AccessedThroughProperty("Button_DeleteWaypoint")]
	[CompilerGenerated]
	private DarkUIButton _StubFilter;

	[AccessedThroughProperty("Button_EditTime")]
	[CompilerGenerated]
	private DarkUIButton m_WriterFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditSpeedAltitude")]
	private DarkUIButton _SpecificationFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditDoctrine")]
	private DarkUIButton m_WatcherFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditAAR")]
	private DarkUIButton reponseFilter;

	[AccessedThroughProperty("DataGridViewTextBoxColumn1")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn descriptorFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn2")]
	private DataGridViewTextBoxColumn poolFilter;

	[AccessedThroughProperty("DataGridViewTextBoxColumn4")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn filterFilter;

	[AccessedThroughProperty("DataGridViewTextBoxColumn5")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn testsFilter;

	[AccessedThroughProperty("DataGridViewTextBoxColumn6")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn interpreterFilter;

	[AccessedThroughProperty("DataGridViewTextBoxColumn8")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn composerFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("DataGridViewTextBoxColumn9")]
	private DataGridViewTextBoxColumn modelFilter;

	[AccessedThroughProperty("DataGridViewTextBoxColumn10")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_AdvisorFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_ClearTime")]
	private DarkUIButton _SerializerFilter;

	[AccessedThroughProperty("Button_EditSensorUsage")]
	[CompilerGenerated]
	private DarkUIButton refFilter;

	[AccessedThroughProperty("ObjectID")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_CodeFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Type")]
	private DataGridViewComboBoxColumn m_ConnectionFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Time_Zulu")]
	private DataGridViewTextBoxColumn contextFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Time_Local")]
	private DataGridViewTextBoxColumn m_StatusFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("TimeFixedImg")]
	private DataGridViewImageColumn proccesorFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("TimeFixed")]
	private DataGridViewTextBoxColumn strategyFilter;

	[AccessedThroughProperty("DesiredSpeed")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn configurationFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("SpeedFixedImg")]
	private DataGridViewImageColumn m_TokenFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("DesiredAltitude")]
	private DataGridViewTextBoxColumn m_ResolverFilter;

	[AccessedThroughProperty("Leg_Distance")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_PublisherFilter;

	[AccessedThroughProperty("Leg_TotalDistance")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_ServerFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Hold_Time")]
	private DataGridViewTextBoxColumn schemaFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Leg_FuelRequired")]
	private DataGridViewTextBoxColumn m_PredicateFilter;

	[AccessedThroughProperty("Leg_FuelRemaining")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn singletonFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("SpeedToT")]
	private DataGridViewComboBoxColumn recordFilter;

	[AccessedThroughProperty("Formation")]
	[CompilerGenerated]
	private DataGridViewComboBoxColumn exceptionFilter;

	[AccessedThroughProperty("AARUsage")]
	[CompilerGenerated]
	private DataGridViewComboBoxColumn m_AttrFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("AARSettings")]
	private DataGridViewTextBoxColumn m_ExporterFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Doctrine")]
	private DataGridViewTextBoxColumn comparatorFilter;

	[AccessedThroughProperty("Coordinates")]
	[CompilerGenerated]
	private DataGridViewTextBoxColumn m_SetterFilter;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_EditTargetAndWeapons")]
	private DarkUIButton _CreatorFilter;

	public Mission.Flight.FlightElement FlightPlan_Element;

	[CompilerGenerated]
	private string m_TemplateFilter;

	internal DarkDataGridView DGV_Waypoints
	{
		[CompilerGenerated]
		get
		{
			return valueFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewColumnEventHandler value2 = ConcatAlgo;
			PaintEventHandler value3 = InterruptAlgo;
			EventHandler value4 = RemoveAlgo;
			DataGridViewCellEventHandler value5 = FindAlgo;
			DataGridViewCellEventHandler value6 = SetAlgo;
			EventHandler value7 = FillAlgo;
			EventHandler value8 = PopAlgo;
			DarkDataGridView darkDataGridView = valueFilter;
			if (darkDataGridView != null)
			{
				darkDataGridView.ColumnWidthChanged -= value2;
				darkDataGridView.Paint -= value3;
				darkDataGridView.SelectionChanged -= value4;
				darkDataGridView.CellClick -= value5;
				darkDataGridView.CellValueChanged -= value6;
				darkDataGridView.CurrentCellDirtyStateChanged -= value7;
				darkDataGridView.SelectionChanged -= value8;
			}
			valueFilter = value;
			darkDataGridView = valueFilter;
			if (darkDataGridView != null)
			{
				darkDataGridView.ColumnWidthChanged += value2;
				darkDataGridView.Paint += value3;
				darkDataGridView.SelectionChanged += value4;
				darkDataGridView.CellClick += value5;
				darkDataGridView.CellValueChanged += value6;
				darkDataGridView.CurrentCellDirtyStateChanged += value7;
				darkDataGridView.SelectionChanged += value8;
			}
		}
	}

	internal DarkUIButton Button_InsertWaypoint
	{
		[CompilerGenerated]
		get
		{
			return tokenizerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ExcludeAlgo;
			DarkUIButton darkUIButton = tokenizerFilter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			tokenizerFilter = value;
			darkUIButton = tokenizerFilter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_DeleteWaypoint
	{
		[CompilerGenerated]
		get
		{
			return _StubFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IncludeAlgo;
			DarkUIButton stubFilter = _StubFilter;
			if (stubFilter != null)
			{
				stubFilter.Click -= value2;
			}
			_StubFilter = value;
			stubFilter = _StubFilter;
			if (stubFilter != null)
			{
				stubFilter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_EditTime
	{
		[CompilerGenerated]
		get
		{
			return m_WriterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SearchAlgo;
			DarkUIButton writerFilter = m_WriterFilter;
			if (writerFilter != null)
			{
				writerFilter.Click -= value2;
			}
			m_WriterFilter = value;
			writerFilter = m_WriterFilter;
			if (writerFilter != null)
			{
				writerFilter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_EditSpeedAltitude
	{
		[CompilerGenerated]
		get
		{
			return _SpecificationFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EnableAlgo;
			DarkUIButton specificationFilter = _SpecificationFilter;
			if (specificationFilter != null)
			{
				specificationFilter.Click -= value2;
			}
			_SpecificationFilter = value;
			specificationFilter = _SpecificationFilter;
			if (specificationFilter != null)
			{
				specificationFilter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_EditDoctrine
	{
		[CompilerGenerated]
		get
		{
			return m_WatcherFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ChangeAlgo;
			DarkUIButton watcherFilter = m_WatcherFilter;
			if (watcherFilter != null)
			{
				watcherFilter.Click -= value2;
			}
			m_WatcherFilter = value;
			watcherFilter = m_WatcherFilter;
			if (watcherFilter != null)
			{
				watcherFilter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_EditAAR
	{
		[CompilerGenerated]
		get
		{
			return reponseFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InitAlgo;
			DarkUIButton darkUIButton = reponseFilter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			reponseFilter = value;
			darkUIButton = reponseFilter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1
	{
		[CompilerGenerated]
		get
		{
			return descriptorFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			descriptorFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2
	{
		[CompilerGenerated]
		get
		{
			return poolFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			poolFilter = value;
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn3")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn4
	{
		[CompilerGenerated]
		get
		{
			return filterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			filterFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn5
	{
		[CompilerGenerated]
		get
		{
			return testsFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			testsFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn6
	{
		[CompilerGenerated]
		get
		{
			return interpreterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			interpreterFilter = value;
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn7")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn8
	{
		[CompilerGenerated]
		get
		{
			return composerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			composerFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn9
	{
		[CompilerGenerated]
		get
		{
			return modelFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			modelFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn10
	{
		[CompilerGenerated]
		get
		{
			return m_AdvisorFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AdvisorFilter = value;
		}
	}

	[field: AccessedThroughProperty("DataGridViewTextBoxColumn11")]
	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn11
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DarkUIButton Button_ClearTime
	{
		[CompilerGenerated]
		get
		{
			return _SerializerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateAlgo;
			DarkUIButton serializerFilter = _SerializerFilter;
			if (serializerFilter != null)
			{
				serializerFilter.Click -= value2;
			}
			_SerializerFilter = value;
			serializerFilter = _SerializerFilter;
			if (serializerFilter != null)
			{
				serializerFilter.Click += value2;
			}
		}
	}

	internal DarkUIButton Button_EditSensorUsage
	{
		[CompilerGenerated]
		get
		{
			return refFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckAlgo;
			DarkUIButton darkUIButton = refFilter;
			if (darkUIButton != null)
			{
				darkUIButton.Click -= value2;
			}
			refFilter = value;
			darkUIButton = refFilter;
			if (darkUIButton != null)
			{
				darkUIButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ID")]
	internal DataGridViewTextBoxColumn ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn ObjectID
	{
		[CompilerGenerated]
		get
		{
			return m_CodeFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_CodeFilter = value;
		}
	}

	internal DataGridViewComboBoxColumn Type
	{
		[CompilerGenerated]
		get
		{
			return m_ConnectionFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ConnectionFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Time_Zulu
	{
		[CompilerGenerated]
		get
		{
			return contextFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			contextFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Time_Local
	{
		[CompilerGenerated]
		get
		{
			return m_StatusFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_StatusFilter = value;
		}
	}

	internal DataGridViewImageColumn TimeFixedImg
	{
		[CompilerGenerated]
		get
		{
			return proccesorFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			proccesorFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn TimeFixed
	{
		[CompilerGenerated]
		get
		{
			return strategyFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			strategyFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn DesiredSpeed
	{
		[CompilerGenerated]
		get
		{
			return configurationFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			configurationFilter = value;
		}
	}

	internal DataGridViewImageColumn SpeedFixedImg
	{
		[CompilerGenerated]
		get
		{
			return m_TokenFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_TokenFilter = value;
		}
	}

	[field: AccessedThroughProperty("SpeedFixed")]
	internal DataGridViewTextBoxColumn SpeedFixed
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DesiredAltitude
	{
		[CompilerGenerated]
		get
		{
			return m_ResolverFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ResolverFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Leg_Distance
	{
		[CompilerGenerated]
		get
		{
			return m_PublisherFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PublisherFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Leg_TotalDistance
	{
		[CompilerGenerated]
		get
		{
			return m_ServerFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ServerFilter = value;
		}
	}

	[field: AccessedThroughProperty("Leg_Time")]
	internal DataGridViewTextBoxColumn Leg_Time
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Hold_Time
	{
		[CompilerGenerated]
		get
		{
			return schemaFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			schemaFilter = value;
		}
	}

	[field: AccessedThroughProperty("Leg_TotalTime")]
	internal DataGridViewTextBoxColumn Leg_TotalTime
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Leg_FuelRequired
	{
		[CompilerGenerated]
		get
		{
			return m_PredicateFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_PredicateFilter = value;
		}
	}

	internal DataGridViewTextBoxColumn Leg_FuelRemaining
	{
		[CompilerGenerated]
		get
		{
			return singletonFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			singletonFilter = value;
		}
	}

	internal DataGridViewComboBoxColumn SpeedToT
	{
		[CompilerGenerated]
		get
		{
			return recordFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			recordFilter = value;
		}
	}

	internal DataGridViewComboBoxColumn Formation
	{
		[CompilerGenerated]
		get
		{
			return exceptionFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			exceptionFilter = value;
		}
	}

	internal DataGridViewComboBoxColumn AARUsage
	{
		[CompilerGenerated]
		get
		{
			return m_AttrFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_AttrFilter = value;
		}
	}

	[field: AccessedThroughProperty("AARSelection")]
	internal DataGridViewComboBoxColumn AARSelection
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn_0
	{
		[CompilerGenerated]
		get
		{
			return m_ExporterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_ExporterFilter = value;
		}
	}

	[field: AccessedThroughProperty("SensorUsage")]
	internal DataGridViewTextBoxColumn SensorUsage
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Doctrine
	{
		[CompilerGenerated]
		get
		{
			return comparatorFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			comparatorFilter = value;
		}
	}

	[field: AccessedThroughProperty("TurnRate")]
	internal DataGridViewComboBoxColumn TurnRate
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal DataGridViewTextBoxColumn Coordinates
	{
		[CompilerGenerated]
		get
		{
			return m_SetterFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m_SetterFilter = value;
		}
	}

	internal DarkUIButton Button_EditTargetAndWeapons
	{
		[CompilerGenerated]
		get
		{
			return _CreatorFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = InstantiateAlgo;
			EventHandler value3 = CreateAlgo;
			DarkUIButton creatorFilter = _CreatorFilter;
			if (creatorFilter != null)
			{
				creatorFilter.Click -= value2;
				creatorFilter.Click -= value3;
			}
			_CreatorFilter = value;
			creatorFilter = _CreatorFilter;
			if (creatorFilter != null)
			{
				creatorFilter.Click += value2;
				creatorFilter.Click += value3;
			}
		}
	}

	public string OldErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return m_TemplateFilter;
		}
		[CompilerGenerated]
		set
		{
			m_TemplateFilter = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _RequestFilter != null)
			{
				_RequestFilter.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SetupAlgo()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
		DGV_Waypoints = new DarkDataGridView();
		ID = new DataGridViewTextBoxColumn();
		ObjectID = new DataGridViewTextBoxColumn();
		Type = new DataGridViewComboBoxColumn();
		Time_Zulu = new DataGridViewTextBoxColumn();
		Time_Local = new DataGridViewTextBoxColumn();
		TimeFixedImg = new DataGridViewImageColumn();
		TimeFixed = new DataGridViewTextBoxColumn();
		DesiredSpeed = new DataGridViewTextBoxColumn();
		SpeedFixedImg = new DataGridViewImageColumn();
		SpeedFixed = new DataGridViewTextBoxColumn();
		DesiredAltitude = new DataGridViewTextBoxColumn();
		Leg_Distance = new DataGridViewTextBoxColumn();
		Leg_TotalDistance = new DataGridViewTextBoxColumn();
		Leg_Time = new DataGridViewTextBoxColumn();
		Hold_Time = new DataGridViewTextBoxColumn();
		Leg_TotalTime = new DataGridViewTextBoxColumn();
		Leg_FuelRequired = new DataGridViewTextBoxColumn();
		Leg_FuelRemaining = new DataGridViewTextBoxColumn();
		SpeedToT = new DataGridViewComboBoxColumn();
		Formation = new DataGridViewComboBoxColumn();
		AARUsage = new DataGridViewComboBoxColumn();
		AARSelection = new DataGridViewComboBoxColumn();
		DataGridViewTextBoxColumn_0 = new DataGridViewTextBoxColumn();
		SensorUsage = new DataGridViewTextBoxColumn();
		Doctrine = new DataGridViewTextBoxColumn();
		TurnRate = new DataGridViewComboBoxColumn();
		Coordinates = new DataGridViewTextBoxColumn();
		Button_InsertWaypoint = new DarkUIButton();
		Button_DeleteWaypoint = new DarkUIButton();
		Button_EditTime = new DarkUIButton();
		Button_EditSpeedAltitude = new DarkUIButton();
		Button_EditDoctrine = new DarkUIButton();
		Button_EditSensorUsage = new DarkUIButton();
		Button_EditAAR = new DarkUIButton();
		DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
		DataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
		Button_ClearTime = new DarkUIButton();
		Button_EditTargetAndWeapons = new DarkUIButton();
		((ISupportInitialize)DGV_Waypoints).BeginInit();
		SuspendLayout();
		DGV_Waypoints.AllowUserToAddRows = false;
		DGV_Waypoints.AllowUserToDeleteRows = false;
		DGV_Waypoints.AllowUserToResizeColumns = false;
		DGV_Waypoints.AllowUserToResizeRows = false;
		DGV_Waypoints.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGV_Waypoints.BackgroundColor = Color.FromArgb(60, 63, 65);
		DGV_Waypoints.BorderStyle = BorderStyle.None;
		DGV_Waypoints.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
		DGV_Waypoints.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		DGV_Waypoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		DGV_Waypoints.ColumnHeadersHeight = 18;
		DGV_Waypoints.Columns.AddRange(ID, ObjectID, Type, Time_Zulu, Time_Local, TimeFixedImg, TimeFixed, DesiredSpeed, SpeedFixedImg, SpeedFixed, DesiredAltitude, Leg_Distance, Leg_TotalDistance, Leg_Time, Hold_Time, Leg_TotalTime, Leg_FuelRequired, Leg_FuelRemaining, SpeedToT, Formation, AARUsage, AARSelection, DataGridViewTextBoxColumn_0, SensorUsage, Doctrine, TurnRate, Coordinates);
		dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle12.BackColor = SystemColors.Window;
		dataGridViewCellStyle12.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 161);
		dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
		DGV_Waypoints.DefaultCellStyle = dataGridViewCellStyle12;
		DGV_Waypoints.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGV_Waypoints.EnableHeadersVisualStyles = false;
		DGV_Waypoints.Location = new Point(0, 0);
		DGV_Waypoints.Name = "DGV_Waypoints";
		dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle13.BackColor = SystemColors.Control;
		dataGridViewCellStyle13.Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
		DGV_Waypoints.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
		DGV_Waypoints.RowHeadersVisible = false;
		DGV_Waypoints.RowHeadersWidth = 10;
		dataGridViewCellStyle14.BackColor = Color.FromArgb(60, 63, 65);
		dataGridViewCellStyle14.ForeColor = Color.LightGray;
		dataGridViewCellStyle14.SelectionBackColor = Color.FromArgb(75, 110, 175);
		dataGridViewCellStyle14.SelectionForeColor = Color.LightGray;
		DGV_Waypoints.RowsDefaultCellStyle = dataGridViewCellStyle14;
		DGV_Waypoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGV_Waypoints.Size = new Size(586, 303);
		DGV_Waypoints.TabIndex = 10;
		ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		ID.DataPropertyName = "ID";
		dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleRight;
		ID.DefaultCellStyle = dataGridViewCellStyle15;
		ID.Frozen = true;
		ID.HeaderText = "#";
		ID.Name = "ID";
		ID.ReadOnly = true;
		ID.Width = 5;
		ObjectID.DataPropertyName = "ObjectID";
		ObjectID.HeaderText = "对象ID";
		ObjectID.Name = "ObjectID";
		ObjectID.Visible = false;
		Type.AutoComplete = false;
		Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Type.DataPropertyName = "Type";
		Type.FlatStyle = FlatStyle.Flat;
		Type.Frozen = true;
		Type.HeaderText = "类型";
		Type.MaxDropDownItems = 20;
		Type.Name = "Type";
		Type.Resizable = DataGridViewTriState.True;
		Type.SortMode = DataGridViewColumnSortMode.Automatic;
		Type.Width = 52;
		Time_Zulu.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Time_Zulu.DataPropertyName = "Time_Zulu";
		dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.BottomCenter;
		Time_Zulu.DefaultCellStyle = dataGridViewCellStyle16;
		Time_Zulu.HeaderText = "祖鲁时间";
		Time_Zulu.Name = "Time_Zulu";
		Time_Zulu.ReadOnly = true;
		Time_Zulu.Width = 79;
		Time_Local.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Time_Local.DataPropertyName = "Time_Local";
		dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.BottomCenter;
		Time_Local.DefaultCellStyle = dataGridViewCellStyle17;
		Time_Local.HeaderText = "当地时间";
		Time_Local.Name = "Time_Local";
		Time_Local.ReadOnly = true;
		Time_Local.Width = 82;
		TimeFixedImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		TimeFixedImg.DataPropertyName = "TimeFixedImg";
		TimeFixedImg.HeaderText = " ";
		TimeFixedImg.Name = "TimeFixedImg";
		TimeFixedImg.Width = 5;
		TimeFixed.DataPropertyName = "TimeFixed";
		TimeFixed.HeaderText = "TimeFixed";
		TimeFixed.Name = "TimeFixed";
		TimeFixed.Resizable = DataGridViewTriState.True;
		TimeFixed.Visible = false;
		TimeFixed.Width = 5;
		DesiredSpeed.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DesiredSpeed.DataPropertyName = "DesiredSpeed";
		dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleRight;
		DesiredSpeed.DefaultCellStyle = dataGridViewCellStyle18;
		DesiredSpeed.HeaderText = "速度";
		DesiredSpeed.Name = "DesiredSpeed";
		DesiredSpeed.ReadOnly = true;
		DesiredSpeed.Width = 65;
		SpeedFixedImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
		SpeedFixedImg.DataPropertyName = "SpeedFixedImg";
		SpeedFixedImg.HeaderText = " ";
		SpeedFixedImg.Name = "SpeedFixedImg";
		SpeedFixedImg.Width = 5;
		SpeedFixed.DataPropertyName = "SpeedFixed";
		dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleRight;
		SpeedFixed.DefaultCellStyle = dataGridViewCellStyle19;
		SpeedFixed.HeaderText = "SpeedFixed";
		SpeedFixed.Name = "SpeedFixed";
		SpeedFixed.Resizable = DataGridViewTriState.True;
		SpeedFixed.Visible = false;
		SpeedFixed.Width = 5;
		DesiredAltitude.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DesiredAltitude.DataPropertyName = "DesiredAltitude";
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
		DesiredAltitude.DefaultCellStyle = dataGridViewCellStyle2;
		DesiredAltitude.HeaderText = "高度";
		DesiredAltitude.Name = "DesiredAltitude";
		DesiredAltitude.ReadOnly = true;
		DesiredAltitude.Width = 71;
		Leg_Distance.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_Distance.DataPropertyName = "Leg_Distance";
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_Distance.DefaultCellStyle = dataGridViewCellStyle3;
		Leg_Distance.HeaderText = "航段距离";
		Leg_Distance.Name = "Leg_Distance";
		Leg_Distance.Width = 95;
		Leg_TotalDistance.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_TotalDistance.DataPropertyName = "Leg_TotalDistance";
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_TotalDistance.DefaultCellStyle = dataGridViewCellStyle4;
		Leg_TotalDistance.HeaderText = "总距离";
		Leg_TotalDistance.Name = "Leg_TotalDistance";
		Leg_TotalDistance.Width = 101;
		Leg_Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_Time.DataPropertyName = "Leg_Time";
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_Time.DefaultCellStyle = dataGridViewCellStyle5;
		Leg_Time.HeaderText = "航段时间";
		Leg_Time.Name = "Leg_Time";
		Leg_Time.ToolTipText = "Time needed to fly this leg.";
		Leg_Time.Width = 74;
		Hold_Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Hold_Time.DataPropertyName = "Hold_Time";
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
		Hold_Time.DefaultCellStyle = dataGridViewCellStyle6;
		Hold_Time.HeaderText = "保持时间";
		Hold_Time.Name = "Hold_Time";
		Hold_Time.ToolTipText = "Loiter time at waypoint to allow flight to form up (Push Point).";
		Hold_Time.Width = 81;
		Leg_TotalTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_TotalTime.DataPropertyName = "Leg_TotalTime";
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_TotalTime.DefaultCellStyle = dataGridViewCellStyle7;
		Leg_TotalTime.HeaderText = "总时间";
		Leg_TotalTime.Name = "Leg_TotalTime";
		Leg_TotalTime.Width = 80;
		Leg_FuelRequired.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_FuelRequired.DataPropertyName = "Leg_FuelRequired";
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_FuelRequired.DefaultCellStyle = dataGridViewCellStyle8;
		Leg_FuelRequired.HeaderText = "航段燃料";
		Leg_FuelRequired.Name = "Leg_FuelRequired";
		Leg_FuelRequired.ToolTipText = "Fuel neeed to fly this leg.";
		Leg_FuelRequired.Width = 73;
		Leg_FuelRemaining.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Leg_FuelRemaining.DataPropertyName = "Leg_FuelRemaining";
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
		Leg_FuelRemaining.DefaultCellStyle = dataGridViewCellStyle9;
		Leg_FuelRemaining.HeaderText = "剩余燃料";
		Leg_FuelRemaining.Name = "Leg_FuelRemaining";
		Leg_FuelRemaining.ToolTipText = "Remaining mission fuel (i.e. total fuel minus reserves) after this leg has been completed.";
		Leg_FuelRemaining.Width = 110;
		SpeedToT.AutoComplete = false;
		SpeedToT.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		SpeedToT.DataPropertyName = "SpeedToT";
		SpeedToT.FlatStyle = FlatStyle.Flat;
		SpeedToT.HeaderText = "调整ToT的速度";
		SpeedToT.Name = "SpeedToT";
		SpeedToT.Resizable = DataGridViewTriState.True;
		SpeedToT.SortMode = DataGridViewColumnSortMode.Automatic;
		SpeedToT.Width = 135;
		Formation.AutoComplete = false;
		Formation.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Formation.DataPropertyName = "Formation";
		Formation.FlatStyle = FlatStyle.Flat;
		Formation.HeaderText = "编队";
		Formation.Name = "Formation";
		Formation.Resizable = DataGridViewTriState.True;
		Formation.SortMode = DataGridViewColumnSortMode.Automatic;
		Formation.Width = 83;
		AARUsage.AutoComplete = false;
		AARUsage.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		AARUsage.DataPropertyName = "AARUsage";
		AARUsage.FlatStyle = FlatStyle.Flat;
		AARUsage.HeaderText = "加油机（AAR）";
		AARUsage.Name = "AARUsage";
		AARUsage.Resizable = DataGridViewTriState.True;
		AARUsage.SortMode = DataGridViewColumnSortMode.Automatic;
		AARUsage.Width = 98;
		AARSelection.AutoComplete = false;
		AARSelection.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		AARSelection.DataPropertyName = "AARSelection";
		AARSelection.FlatStyle = FlatStyle.Flat;
		AARSelection.HeaderText = "加油机选择";
		AARSelection.Name = "AARSelection";
		AARSelection.Resizable = DataGridViewTriState.True;
		AARSelection.SortMode = DataGridViewColumnSortMode.Automatic;
		AARSelection.Width = 113;
		DataGridViewTextBoxColumn_0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn_0.DataPropertyName = "AARSettings";
		DataGridViewTextBoxColumn_0.HeaderText = "加油机计划设置";
		DataGridViewTextBoxColumn_0.Name = "AARSettings";
		DataGridViewTextBoxColumn_0.ReadOnly = true;
		DataGridViewTextBoxColumn_0.Width = 150;
		SensorUsage.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		SensorUsage.DataPropertyName = "SensorUsage";
		SensorUsage.HeaderText = "传感器用法";
		SensorUsage.Name = "SensorUsage";
		Doctrine.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Doctrine.DataPropertyName = "Doctrine";
		Doctrine.HeaderText = "条令/电磁控制/武器释放权限(WRA)";
		Doctrine.Name = "Doctrine";
		Doctrine.Width = 159;
		TurnRate.AutoComplete = false;
		TurnRate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		TurnRate.DataPropertyName = "TurnRate";
		TurnRate.FlatStyle = FlatStyle.Flat;
		TurnRate.HeaderText = "转弯速率";
		TurnRate.Name = "TurnRate";
		TurnRate.Width = 60;
		Coordinates.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		Coordinates.DataPropertyName = "Coordinates";
		Coordinates.HeaderText = "坐标";
		Coordinates.Name = "Coordinates";
		Coordinates.Width = 93;
		Button_InsertWaypoint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_InsertWaypoint.BackColor = Color.Transparent;
		Button_InsertWaypoint.DialogResult = DialogResult.None;
		Button_InsertWaypoint.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_InsertWaypoint.ForeColor = SystemColors.Control;
		Button_InsertWaypoint.Location = new Point(-1, 305);
		Button_InsertWaypoint.Name = "Button_InsertWaypoint";
		Button_InsertWaypoint.RoundRadius = 0;
		Button_InsertWaypoint.Size = new Size(95, 24);
		Button_InsertWaypoint.TabIndex = 12;
		Button_InsertWaypoint.Text = "插入航点";
		Button_DeleteWaypoint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_DeleteWaypoint.BackColor = Color.Transparent;
		Button_DeleteWaypoint.DialogResult = DialogResult.None;
		Button_DeleteWaypoint.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_DeleteWaypoint.ForeColor = SystemColors.Control;
		Button_DeleteWaypoint.Location = new Point(95, 305);
		Button_DeleteWaypoint.Name = "Button_DeleteWaypoint";
		Button_DeleteWaypoint.RoundRadius = 0;
		Button_DeleteWaypoint.Size = new Size(95, 24);
		Button_DeleteWaypoint.TabIndex = 13;
		Button_DeleteWaypoint.Text = "删除航点";
		Button_EditTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditTime.BackColor = Color.Transparent;
		Button_EditTime.DialogResult = DialogResult.None;
		Button_EditTime.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_EditTime.ForeColor = SystemColors.Control;
		Button_EditTime.Location = new Point(307, 305);
		Button_EditTime.Name = "Button_EditTime";
		Button_EditTime.RoundRadius = 0;
		Button_EditTime.Size = new Size(115, 24);
		Button_EditTime.TabIndex = 16;
		Button_EditTime.Text = "编辑时间";
		Button_EditSpeedAltitude.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditSpeedAltitude.BackColor = Color.Transparent;
		Button_EditSpeedAltitude.DialogResult = DialogResult.None;
		Button_EditSpeedAltitude.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_EditSpeedAltitude.ForeColor = SystemColors.Control;
		Button_EditSpeedAltitude.Location = new Point(191, 305);
		Button_EditSpeedAltitude.Name = "Button_EditSpeedAltitude";
		Button_EditSpeedAltitude.RoundRadius = 0;
		Button_EditSpeedAltitude.Size = new Size(115, 24);
		Button_EditSpeedAltitude.TabIndex = 17;
		Button_EditSpeedAltitude.Text = "编辑速度/高度";
		Button_EditDoctrine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditDoctrine.BackColor = Color.Transparent;
		Button_EditDoctrine.DialogResult = DialogResult.None;
		Button_EditDoctrine.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_EditDoctrine.ForeColor = SystemColors.Control;
		Button_EditDoctrine.Location = new Point(-1, 329);
		Button_EditDoctrine.Name = "Button_EditDoctrine";
		Button_EditDoctrine.RoundRadius = 0;
		Button_EditDoctrine.Size = new Size(174, 24);
		Button_EditDoctrine.TabIndex = 18;
		Button_EditDoctrine.Text = "编辑条令/电磁控制/武器释放权限(WRA)";
		Button_EditSensorUsage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditSensorUsage.BackColor = Color.Transparent;
		Button_EditSensorUsage.DialogResult = DialogResult.None;
		Button_EditSensorUsage.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_EditSensorUsage.ForeColor = SystemColors.Control;
		Button_EditSensorUsage.Location = new Point(349, 329);
		Button_EditSensorUsage.Name = "Button_EditSensorUsage";
		Button_EditSensorUsage.RoundRadius = 0;
		Button_EditSensorUsage.Size = new Size(144, 24);
		Button_EditSensorUsage.TabIndex = 19;
		Button_EditSensorUsage.Text = "编辑传感器用法";
		Button_EditAAR.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditAAR.BackColor = Color.Transparent;
		Button_EditAAR.DialogResult = DialogResult.None;
		Button_EditAAR.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_EditAAR.ForeColor = SystemColors.Control;
		Button_EditAAR.Location = new Point(174, 329);
		Button_EditAAR.Name = "Button_EditAAR";
		Button_EditAAR.RoundRadius = 0;
		Button_EditAAR.Size = new Size(174, 24);
		Button_EditAAR.TabIndex = 20;
		Button_EditAAR.Text = "编辑空对空加油设置";
		DataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn1.DataPropertyName = "ID";
		DataGridViewTextBoxColumn1.Frozen = true;
		DataGridViewTextBoxColumn1.HeaderText = "航点";
		DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
		DataGridViewTextBoxColumn1.ReadOnly = true;
		DataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn2.DataPropertyName = "Time_Zulu";
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.BottomCenter;
		DataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
		DataGridViewTextBoxColumn2.HeaderText = "祖鲁";
		DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
		DataGridViewTextBoxColumn2.ReadOnly = true;
		DataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn3.DataPropertyName = "Time_Local";
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.BottomCenter;
		DataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
		DataGridViewTextBoxColumn3.HeaderText = "本地";
		DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
		DataGridViewTextBoxColumn3.ReadOnly = true;
		DataGridViewTextBoxColumn4.DataPropertyName = "TimeFixed";
		DataGridViewTextBoxColumn4.HeaderText = "TimeFixed";
		DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
		DataGridViewTextBoxColumn4.Resizable = DataGridViewTriState.True;
		DataGridViewTextBoxColumn4.Visible = false;
		DataGridViewTextBoxColumn4.Width = 5;
		DataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn5.DataPropertyName = "DesiredSpeed";
		DataGridViewTextBoxColumn5.HeaderText = " ";
		DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
		DataGridViewTextBoxColumn5.ReadOnly = true;
		DataGridViewTextBoxColumn6.DataPropertyName = "SpeedFixed";
		DataGridViewTextBoxColumn6.HeaderText = "SpeedFixed";
		DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
		DataGridViewTextBoxColumn6.Resizable = DataGridViewTriState.True;
		DataGridViewTextBoxColumn6.Visible = false;
		DataGridViewTextBoxColumn6.Width = 5;
		DataGridViewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn7.DataPropertyName = "DesiredAltitude";
		DataGridViewTextBoxColumn7.HeaderText = "预期高度";
		DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
		DataGridViewTextBoxColumn7.ReadOnly = true;
		DataGridViewTextBoxColumn8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn8.DataPropertyName = "AARSettings";
		DataGridViewTextBoxColumn8.HeaderText = "AARSettings";
		DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
		DataGridViewTextBoxColumn8.ReadOnly = true;
		DataGridViewTextBoxColumn9.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn9.DataPropertyName = "Doctrine";
		DataGridViewTextBoxColumn9.HeaderText = "条令/电磁控制/武器释放权限(WRA)";
		DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9";
		DataGridViewTextBoxColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn10.DataPropertyName = "SensorUsage";
		DataGridViewTextBoxColumn10.HeaderText = "传感器用法";
		DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10";
		DataGridViewTextBoxColumn11.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		DataGridViewTextBoxColumn11.DataPropertyName = "Coordinates";
		DataGridViewTextBoxColumn11.HeaderText = "坐标";
		DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11";
		Button_ClearTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_ClearTime.BackColor = Color.Transparent;
		Button_ClearTime.DialogResult = DialogResult.None;
		Button_ClearTime.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_ClearTime.ForeColor = SystemColors.Control;
		Button_ClearTime.Location = new Point(423, 305);
		Button_ClearTime.Name = "Button_ClearTime";
		Button_ClearTime.RoundRadius = 0;
		Button_ClearTime.Size = new Size(70, 24);
		Button_ClearTime.TabIndex = 21;
		Button_ClearTime.Text = "清除时间";
		Button_EditTargetAndWeapons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		Button_EditTargetAndWeapons.BackColor = Color.Transparent;
		Button_EditTargetAndWeapons.DialogResult = DialogResult.None;
		Button_EditTargetAndWeapons.Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		Button_EditTargetAndWeapons.ForeColor = SystemColors.Control;
		Button_EditTargetAndWeapons.Location = new Point(494, 305);
		Button_EditTargetAndWeapons.Name = "Button_EditTargetAndWeapons";
		Button_EditTargetAndWeapons.RoundRadius = 0;
		Button_EditTargetAndWeapons.Size = new Size(92, 48);
		Button_EditTargetAndWeapons.TabIndex = 21;
		Button_EditTargetAndWeapons.Text = "目标&武器";
		base.AutoScaleMode = AutoScaleMode.None;
		base.Controls.Add(Button_EditTargetAndWeapons);
		base.Controls.Add(Button_ClearTime);
		base.Controls.Add(Button_EditAAR);
		base.Controls.Add(Button_EditSensorUsage);
		base.Controls.Add(Button_EditDoctrine);
		base.Controls.Add(Button_EditSpeedAltitude);
		base.Controls.Add(Button_EditTime);
		base.Controls.Add(Button_DeleteWaypoint);
		base.Controls.Add(Button_InsertWaypoint);
		base.Controls.Add(DGV_Waypoints);
		base.Name = "FlightPlanWaypoints";
		base.Size = new Size(586, 352);
		((ISupportInitialize)DGV_Waypoints).EndInit();
		ResumeLayout(performLayout: false);
	}

	public FlightPlanWaypoints()
	{
		SetupAlgo();
	}

	private void ExcludeAlgo(object sender, EventArgs e)
	{
		try
		{
			bool flag = false;
			int count = DGV_Waypoints.Rows.Count;
			int num = count - 1;
			Waypoint waypoint_ = null;
			Waypoint waypoint = null;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow = DGV_Waypoints.Rows[i];
				if (!dataGridViewRow.Selected)
				{
					continue;
				}
				waypoint_ = (Waypoint)dataGridViewRow.Tag;
				if (waypoint_.SearchReponse() || waypoint_.ChangeReponse())
				{
					new DarkMessageBox("无法在开始和终止巡逻点之间插入新的航点！").ShowDialog();
					continue;
				}
				if (FlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
				{
					waypoint_ = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[i];
				}
				if (waypoint_.SetupReponse())
				{
					new DarkMessageBox("无法插入编队分解航点。改变队型，然后再试一次。").ShowDialog();
					return;
				}
				Waypoint.WaypointType type;
				switch (waypoint_.Type)
				{
				case Waypoint.WaypointType.ManualPlottedCourseWaypoint:
					type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
					break;
				case Waypoint.WaypointType.TurningPoint:
					type = Waypoint.WaypointType.TurningPoint;
					break;
				case Waypoint.WaypointType.StrikeIngress:
					type = Waypoint.WaypointType.StrikeIngress;
					break;
				case Waypoint.WaypointType.StrikeEgress:
					type = Waypoint.WaypointType.StrikeEgress;
					break;
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Split:
				case Waypoint.WaypointType.WeaponLaunch:
					type = Waypoint.WaypointType.StrikeIngress;
					break;
				case Waypoint.WaypointType.Formate:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.WeaponTarget:
					type = Waypoint.WaypointType.StrikeEgress;
					break;
				default:
					type = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
					break;
				case Waypoint.WaypointType.PatrolStation:
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.LandingMarshal:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.TakeOff:
				case Waypoint.WaypointType.Marshal:
				case Waypoint.WaypointType.Land:
				case Waypoint.WaypointType.StationStart_Racetrack:
				case Waypoint.WaypointType.StationStart_FigureEight:
				case Waypoint.WaypointType.StationStart_Area:
				case Waypoint.WaypointType.StationStart_RaceTrackRandom:
				case Waypoint.WaypointType.StationEnd:
				case Waypoint.WaypointType.HoldStart:
				case Waypoint.WaypointType.HoldEnd:
					type = Waypoint.WaypointType.TurningPoint;
					break;
				}
				GeoPoint geoPoint = new GeoPoint();
				GeoPoint geoPoint2 = new GeoPoint();
				GeoPoint geoPoint3 = new GeoPoint();
				GeoPoint geoPoint4 = new GeoPoint();
				GeoPoint geoPoint5 = new GeoPoint();
				GeoPoint geoPoint6 = new GeoPoint();
				if (i + 1 <= count - 1)
				{
					Waypoint waypoint4 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[i + 1];
					double double_ = Math2.PublishClass(waypoint_.Latitude, waypoint_.Longitude, waypoint4.Latitude, waypoint4.Longitude);
					double num2 = Math2.VerifyClass(waypoint_.Latitude, waypoint_.Longitude, waypoint4.Latitude, waypoint4.Longitude);
					Waypoint waypoint5 = waypoint_;
					double double_4 = waypoint5.Longitude;
					Waypoint waypoint6 = waypoint_;
					double double_5 = waypoint6.Latitude;
					double double_6 = geoPoint.Longitude;
					double double_7 = geoPoint.Latitude;
					double double_8 = num2 / 2.0;
					double double_9 = Math2.DisableClass(double_);
					Geodesic_EdWilliams.CalcPoint_Williams(ref double_4, ref double_5, ref double_6, ref double_7, ref double_8, ref double_9);
					geoPoint.Latitude = double_7;
					geoPoint.Longitude = double_6;
					waypoint6.Latitude = double_5;
					waypoint5.Longitude = double_4;
					if (!Information.IsNothing(waypoint_.Waypoint_LeadElementWingman))
					{
						Waypoint waypoint_LeadElementWingman = waypoint_.Waypoint_LeadElementWingman;
						Waypoint waypoint7 = (Information.IsNothing(waypoint4.Waypoint_LeadElementWingman) ? waypoint4 : waypoint4.Waypoint_LeadElementWingman);
						double_ = Math2.PublishClass(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint7.Latitude, waypoint7.Longitude);
						num2 = Math2.VerifyClass(waypoint_LeadElementWingman.Latitude, waypoint_LeadElementWingman.Longitude, waypoint7.Latitude, waypoint7.Longitude);
						double_9 = waypoint_LeadElementWingman.Longitude;
						double_8 = waypoint_LeadElementWingman.Latitude;
						double_7 = geoPoint2.Longitude;
						double_6 = geoPoint2.Latitude;
						double_5 = num2 / 2.0;
						double_4 = Math2.DisableClass(double_);
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_9, ref double_8, ref double_7, ref double_6, ref double_5, ref double_4);
						geoPoint2.Latitude = double_6;
						geoPoint2.Longitude = double_7;
						waypoint_LeadElementWingman.Latitude = double_8;
						waypoint_LeadElementWingman.Longitude = double_9;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_SecondElement))
					{
						Waypoint waypoint_SecondElement = waypoint_.Waypoint_SecondElement;
						Waypoint waypoint8 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
						double_ = Math2.PublishClass(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint8.Latitude, waypoint8.Longitude);
						num2 = Math2.VerifyClass(waypoint_SecondElement.Latitude, waypoint_SecondElement.Longitude, waypoint8.Latitude, waypoint8.Longitude);
						double_4 = waypoint_SecondElement.Longitude;
						double_5 = waypoint_SecondElement.Latitude;
						double_6 = geoPoint.Longitude;
						double_7 = geoPoint.Latitude;
						double_8 = num2 / 2.0;
						double_9 = Math2.DisableClass(double_);
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_4, ref double_5, ref double_6, ref double_7, ref double_8, ref double_9);
						geoPoint.Latitude = double_7;
						geoPoint.Longitude = double_6;
						waypoint_SecondElement.Latitude = double_5;
						waypoint_SecondElement.Longitude = double_4;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_SecondElementWingman))
					{
						Waypoint waypoint_SecondElement2 = waypoint_.Waypoint_SecondElement;
						Waypoint waypoint9 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
						double_ = Math2.PublishClass(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint9.Latitude, waypoint9.Longitude);
						num2 = Math2.VerifyClass(waypoint_SecondElement2.Latitude, waypoint_SecondElement2.Longitude, waypoint9.Latitude, waypoint9.Longitude);
						double_9 = waypoint_SecondElement2.Longitude;
						double_8 = waypoint_SecondElement2.Latitude;
						double_7 = geoPoint.Longitude;
						double_6 = geoPoint.Latitude;
						double_5 = num2 / 2.0;
						double_4 = Math2.DisableClass(double_);
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_9, ref double_8, ref double_7, ref double_6, ref double_5, ref double_4);
						geoPoint.Latitude = double_6;
						geoPoint.Longitude = double_7;
						waypoint_SecondElement2.Latitude = double_8;
						waypoint_SecondElement2.Longitude = double_9;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_ThirdElement))
					{
						Waypoint waypoint_SecondElement3 = waypoint_.Waypoint_SecondElement;
						Waypoint waypoint10 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
						double_ = Math2.PublishClass(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint10.Latitude, waypoint10.Longitude);
						num2 = Math2.VerifyClass(waypoint_SecondElement3.Latitude, waypoint_SecondElement3.Longitude, waypoint10.Latitude, waypoint10.Longitude);
						double_4 = waypoint_SecondElement3.Longitude;
						double_5 = waypoint_SecondElement3.Latitude;
						double_6 = geoPoint.Longitude;
						double_7 = geoPoint.Latitude;
						double_8 = num2 / 2.0;
						double_9 = Math2.DisableClass(double_);
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_4, ref double_5, ref double_6, ref double_7, ref double_8, ref double_9);
						geoPoint.Latitude = double_7;
						geoPoint.Longitude = double_6;
						waypoint_SecondElement3.Latitude = double_5;
						waypoint_SecondElement3.Longitude = double_4;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_ThirdElementWingman))
					{
						Waypoint waypoint_SecondElement4 = waypoint_.Waypoint_SecondElement;
						Waypoint waypoint11 = (Information.IsNothing(waypoint4.Waypoint_SecondElement) ? waypoint4 : waypoint4.Waypoint_SecondElement);
						double_ = Math2.PublishClass(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint11.Latitude, waypoint11.Longitude);
						num2 = Math2.VerifyClass(waypoint_SecondElement4.Latitude, waypoint_SecondElement4.Longitude, waypoint11.Latitude, waypoint11.Longitude);
						double_9 = waypoint_SecondElement4.Longitude;
						double_8 = waypoint_SecondElement4.Latitude;
						double_7 = geoPoint.Longitude;
						double_6 = geoPoint.Latitude;
						double_5 = num2 / 2.0;
						double_4 = Math2.DisableClass(double_);
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_9, ref double_8, ref double_7, ref double_6, ref double_5, ref double_4);
						geoPoint.Latitude = double_6;
						geoPoint.Longitude = double_7;
						waypoint_SecondElement4.Latitude = double_8;
						waypoint_SecondElement4.Longitude = double_9;
					}
				}
				else
				{
					Waypoint waypoint2 = waypoint_;
					double double_10 = waypoint2.Longitude;
					Waypoint waypoint3 = waypoint_;
					double double_11 = waypoint3.Latitude;
					double double_2 = geoPoint.Longitude;
					double double_3 = geoPoint.Latitude;
					int int_ = 10;
					int int_2 = 0;
					Geodesic_EdWilliams.CalcPoint_Williams(ref double_10, ref double_11, ref double_2, ref double_3, ref int_, ref int_2);
					geoPoint.Latitude = double_3;
					geoPoint.Longitude = double_2;
					waypoint3.Latitude = double_11;
					waypoint2.Longitude = double_10;
					if (!Information.IsNothing(waypoint_.Waypoint_LeadElementWingman))
					{
						Waypoint waypoint_LeadElementWingman2 = waypoint_.Waypoint_LeadElementWingman;
						double_3 = waypoint_LeadElementWingman2.Longitude;
						Waypoint waypoint_LeadElementWingman3 = waypoint_.Waypoint_LeadElementWingman;
						double_2 = waypoint_LeadElementWingman3.Latitude;
						double_11 = geoPoint.Longitude;
						double_10 = geoPoint.Latitude;
						int_2 = 10;
						int_ = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_3, ref double_2, ref double_11, ref double_10, ref int_2, ref int_);
						geoPoint.Latitude = double_10;
						geoPoint.Longitude = double_11;
						waypoint_LeadElementWingman3.Latitude = double_2;
						waypoint_LeadElementWingman2.Longitude = double_3;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_SecondElement))
					{
						Waypoint waypoint_SecondElement5 = waypoint_.Waypoint_SecondElement;
						double_10 = waypoint_SecondElement5.Longitude;
						Waypoint waypoint_SecondElement6 = waypoint_.Waypoint_SecondElement;
						double_11 = waypoint_SecondElement6.Latitude;
						double_2 = geoPoint.Longitude;
						double_3 = geoPoint.Latitude;
						int_ = 10;
						int_2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_10, ref double_11, ref double_2, ref double_3, ref int_, ref int_2);
						geoPoint.Latitude = double_3;
						geoPoint.Longitude = double_2;
						waypoint_SecondElement6.Latitude = double_11;
						waypoint_SecondElement5.Longitude = double_10;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_SecondElementWingman))
					{
						Waypoint waypoint_SecondElementWingman = waypoint_.Waypoint_SecondElementWingman;
						double_3 = waypoint_SecondElementWingman.Longitude;
						Waypoint waypoint_SecondElementWingman2 = waypoint_.Waypoint_SecondElementWingman;
						double_2 = waypoint_SecondElementWingman2.Latitude;
						double_11 = geoPoint.Longitude;
						double_10 = geoPoint.Latitude;
						int_2 = 10;
						int_ = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_3, ref double_2, ref double_11, ref double_10, ref int_2, ref int_);
						geoPoint.Latitude = double_10;
						geoPoint.Longitude = double_11;
						waypoint_SecondElementWingman2.Latitude = double_2;
						waypoint_SecondElementWingman.Longitude = double_3;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_ThirdElement))
					{
						Waypoint waypoint_ThirdElement = waypoint_.Waypoint_ThirdElement;
						double_10 = waypoint_ThirdElement.Longitude;
						Waypoint waypoint_ThirdElement2 = waypoint_.Waypoint_ThirdElement;
						double_11 = waypoint_ThirdElement2.Latitude;
						double_2 = geoPoint.Longitude;
						double_3 = geoPoint.Latitude;
						int_ = 10;
						int_2 = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_10, ref double_11, ref double_2, ref double_3, ref int_, ref int_2);
						geoPoint.Latitude = double_3;
						geoPoint.Longitude = double_2;
						waypoint_ThirdElement2.Latitude = double_11;
						waypoint_ThirdElement.Longitude = double_10;
					}
					if (!Information.IsNothing(waypoint_.Waypoint_ThirdElementWingman))
					{
						Waypoint waypoint_ThirdElementWingman = waypoint_.Waypoint_ThirdElementWingman;
						double_3 = waypoint_ThirdElementWingman.Longitude;
						Waypoint waypoint_ThirdElementWingman2 = waypoint_.Waypoint_ThirdElementWingman;
						double_2 = waypoint_ThirdElementWingman2.Latitude;
						double_11 = geoPoint.Longitude;
						double_10 = geoPoint.Latitude;
						int_2 = 10;
						int_ = 0;
						Geodesic_EdWilliams.CalcPoint_Williams(ref double_3, ref double_2, ref double_11, ref double_10, ref int_2, ref int_);
						geoPoint.Latitude = double_10;
						geoPoint.Longitude = double_11;
						waypoint_ThirdElementWingman2.Latitude = double_2;
						waypoint_ThirdElementWingman.Longitude = double_3;
					}
				}
				Scenario scenario_ = Client.CurrentScenario;
				Doctrine doctrine_ = null;
				waypoint = Waypoint.CopyWaypoint(ref scenario_, ref waypoint_, bool_0: true, bool_1: false, ref doctrine_);
				waypoint.Type = type;
				waypoint.Latitude = geoPoint.Latitude;
				waypoint.Longitude = geoPoint.Longitude;
				waypoint.Hold_Time = 0f;
				waypoint.Station_Time = 0f;
				waypoint.SpacingManeuver_Time = 0f;
				if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
				{
					Waypoint waypoint_LeadElementWingman4 = waypoint.Waypoint_LeadElementWingman;
					waypoint_LeadElementWingman4.Type = type;
					waypoint_LeadElementWingman4.Latitude = geoPoint2.Latitude;
					waypoint_LeadElementWingman4.Longitude = geoPoint2.Longitude;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
				{
					Waypoint waypoint_SecondElement7 = waypoint.Waypoint_SecondElement;
					waypoint_SecondElement7.Type = type;
					waypoint_SecondElement7.Latitude = geoPoint3.Latitude;
					waypoint_SecondElement7.Longitude = geoPoint3.Longitude;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
				{
					Waypoint waypoint_SecondElementWingman3 = waypoint.Waypoint_SecondElementWingman;
					waypoint_SecondElementWingman3.Type = type;
					waypoint_SecondElementWingman3.Latitude = geoPoint4.Latitude;
					waypoint_SecondElementWingman3.Longitude = geoPoint4.Longitude;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
				{
					Waypoint waypoint_ThirdElement3 = waypoint.Waypoint_ThirdElement;
					waypoint_ThirdElement3.Type = type;
					waypoint_ThirdElement3.Latitude = geoPoint5.Latitude;
					waypoint_ThirdElement3.Longitude = geoPoint5.Longitude;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
				{
					Waypoint waypoint_ThirdElementWingman3 = waypoint.Waypoint_ThirdElementWingman;
					waypoint_ThirdElementWingman3.Type = type;
					waypoint_ThirdElementWingman3.Latitude = geoPoint6.Latitude;
					waypoint_ThirdElementWingman3.Longitude = geoPoint6.Longitude;
				}
				Mission.Flight selectedFlight = Client.FlightPlanEditorWindow.SelectedFlight;
				Waypoint[] waypoint_2 = selectedFlight.FlightPlan;
				ActiveUnit_Navigator.AddWaypoint(ref waypoint_2, i + 1, waypoint);
				selectedFlight.FlightPlan = waypoint_2;
				break;
			}
			if (!Information.IsNothing(waypoint_) && !Information.IsNothing(waypoint))
			{
				for (int j = Client.CurrentScenario.ActiveUnits_List.Count - 1; j >= 0; j += -1)
				{
					ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits_List[j];
					if (Information.IsNothing(activeUnit) || !activeUnit.IsOperating())
					{
						continue;
					}
					if ((activeUnit.IsAircraft || (activeUnit.IsGroup && ((Group)activeUnit).Type == Group.GroupType.AirGroup)) && activeUnit.Navigator.HasFlightPlan && !Information.IsNothing(activeUnit.GetUnitSide()) && activeUnit.GetUnitSide() == Client.CurrentSide)
					{
						int num3 = activeUnit.Navigator.PlottedCourse.Count() - 1;
						for (int k = 0; k <= num3; k++)
						{
							if (activeUnit.Navigator.PlottedCourse[k] == waypoint_ && k >= 0)
							{
								ActiveUnit_Navigator navigator = activeUnit.Navigator;
								Waypoint[] waypoint_3 = navigator.PlottedCourse;
								ActiveUnit_Navigator.AddWaypoint(ref waypoint_3, k + 1, waypoint);
								navigator.PlottedCourse = waypoint_3;
								flag = true;
							}
							if (flag)
							{
								break;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			if (DGV_Waypoints.SelectedRows.Count > 0)
			{
				Client.FlightPlanEditorWindow.SelectedRow = DGV_Waypoints.SelectedRows[0].Index;
				Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)DGV_Waypoints.Rows[Client.FlightPlanEditorWindow.SelectedRow].Tag;
				DGV_Waypoints.Rows[0].Selected = false;
			}
			Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: false);
			if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
			{
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
				FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
				Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
				FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
				Waypoint waypoint_4 = flightPlanEditorWindow2.SelectedWaypoint;
				flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_4, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
				flightPlanEditorWindow2.SelectedWaypoint = waypoint_4;
				flightPlanEditorWindow.SelectedFlight = flight_;
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void IncludeAlgo(object sender, EventArgs e)
	{
		try
		{
			if (DGV_Waypoints.SelectedRows.Count == 0)
			{
				return;
			}
			for (int i = DGV_Waypoints.Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow dataGridViewRow = DGV_Waypoints.Rows[i];
				if (!dataGridViewRow.Selected)
				{
					continue;
				}
				Waypoint waypoint = (Waypoint)dataGridViewRow.Tag;
				switch (waypoint.Type)
				{
				default:
					if (waypoint.CheckReponse())
					{
						new DarkMessageBox("无法删除开始警戒或结束警戒航点！").ShowDialog();
					}
					else if (waypoint.IncludeReponse())
					{
						new DarkMessageBox("无法删除开始警戒或结束警戒航点！").ShowDialog();
					}
					else
					{
						new DarkMessageBox("无法删除航点！").ShowDialog();
					}
					break;
				case Waypoint.WaypointType.Assemble:
				case Waypoint.WaypointType.TurningPoint:
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.Refuel:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
					if (FlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
					{
						waypoint = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[i];
					}
					if (waypoint.SetupReponse())
					{
						new DarkMessageBox("无法删除编队分解航点。改变队型，然后再试一次。").ShowDialog();
						break;
					}
					if (!Information.IsNothing(waypoint))
					{
						foreach (ActiveUnit unit in Client.CurrentSide.Units)
						{
							if (unit.Navigator.HasPlottedCourse())
							{
								if (unit.Navigator.PlottedCourse.Contains(waypoint))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint, bool_1: true);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_LeadElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_LeadElementWingman, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_SecondElement) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_SecondElement))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_SecondElement, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_SecondElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_SecondElementWingman, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_ThirdElement) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_ThirdElement))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_ThirdElement, bool_1: false);
								}
								else if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman) && unit.Navigator.PlottedCourse.Contains(waypoint.Waypoint_ThirdElementWingman))
								{
									unit.Navigator.RemoveWaypoint_Soft(waypoint.Waypoint_ThirdElementWingman, bool_1: false);
								}
							}
						}
					}
					ActiveUnit_Navigator.RemoveWaypoint_Hard(Client.CurrentScenario, Client.FlightPlanEditorWindow.SelectedMission, Client.FlightPlanEditorWindow.SelectedFlight, waypoint);
					break;
				}
			}
			if (DGV_Waypoints.SelectedRows.Count > 0)
			{
				Client.FlightPlanEditorWindow.SelectedRow = DGV_Waypoints.SelectedRows[0].Index;
				Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)DGV_Waypoints.Rows[Client.FlightPlanEditorWindow.SelectedRow].Tag;
				DGV_Waypoints.Rows[0].Selected = false;
			}
			Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: false);
			if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
			{
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
				FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
				Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
				FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
				Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
				flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
				flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
				flightPlanEditorWindow.SelectedFlight = flight_;
			}
			if (Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void SearchAlgo(object sender, EventArgs e)
	{
		try
		{
			FlightPlanEditor.DoNotNotifyFlightError = true;
			Waypoint waypoint = null;
			for (int i = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows.Count - 1; i >= 0; i += -1)
			{
				DataGridViewRow dataGridViewRow = Client.FlightPlanEditorWindow.theFlightPlanWaypoints.DGV_Waypoints.Rows[i];
				if (dataGridViewRow.Selected)
				{
					waypoint = (Waypoint)dataGridViewRow.Tag;
					break;
				}
			}
			if (Information.IsNothing(waypoint) || (Client.FlightPlanEditorWindow.SelectedFlight.Type == Mission._FlightType.FlightplanTemplate && !waypoint.EnableReponse()))
			{
				return;
			}
			Client.FlightPlanTimeWindow.ViaFlightPlanEditor = true;
			FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
			ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
			FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
			Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
			FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
			Waypoint waypoint_ = flightPlanEditorWindow2.SelectedWaypoint;
			flightPlanTimeWindow.RefreshStats(ref selectedMission, ref flight_, ref waypoint_, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
			flightPlanEditorWindow2.SelectedWaypoint = waypoint_;
			flightPlanEditorWindow.SelectedFlight = flight_;
			Client.FlightPlanTimeWindow.Show();
			Client.FlightPlanTimeWindow.BringToFront();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 78364648fbfgsf", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			FlightPlanEditor.DoNotNotifyFlightError = false;
			ProjectData.ClearProjectError();
		}
		FlightPlanEditor.DoNotNotifyFlightError = false;
	}

	private void EnableAlgo(object sender, EventArgs e)
	{
		int num = DGV_Waypoints.Rows.Count - 1;
		int num2 = 0;
		DataGridViewRow dataGridViewRow;
		while (true)
		{
			if (num2 <= num)
			{
				dataGridViewRow = DGV_Waypoints.Rows[num2];
				if (dataGridViewRow.Selected)
				{
					break;
				}
				num2++;
				continue;
			}
			return;
		}
		Waypoint speedAlt_FlightPlanWaypoint = (Waypoint)dataGridViewRow.Tag;
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_FlightPlanWaypoint = speedAlt_FlightPlanWaypoint;
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_SelectedUnit = null;
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Flight = Client.FlightPlanEditorWindow.SelectedFlight;
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.SpeedAlt_Mission = Client.FlightPlanEditorWindow.SelectedMission;
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.LoadForm();
		ItemExporter.ConnectInterruptibleTemplate.SpeedAlt.Show();
	}

	private void ChangeAlgo(object sender, EventArgs e)
	{
		if (DGV_Waypoints.SelectedRows.Count > 0)
		{
			Waypoint waypoint = (Waypoint)DGV_Waypoints.SelectedRows[0].Tag;
			if (!Information.IsNothing(waypoint))
			{
				MainForm mainForm = ItemExporter.ConnectInterruptibleTemplate.MainForm;
				ReadOnlyCollection<Module_Unit.Unit> readOnlyCollection_ = null;
				List<ActiveUnit> list_ = null;
				mainForm.ShowDoctrineROE(waypoint, ref readOnlyCollection_, ref list_, bool_0: false);
			}
		}
	}

	private void InitAlgo(object sender, EventArgs e)
	{
		if (DGV_Waypoints.SelectedRows.Count > 0)
		{
			Waypoint waypoint = (Waypoint)DGV_Waypoints.SelectedRows[0].Tag;
			if (!Information.IsNothing(waypoint) && waypoint.Type == Waypoint.WaypointType.Refuel)
			{
				ItemExporter.ConnectInterruptibleTemplate.TankerPlanner.TheMission = null;
				ItemExporter.ConnectInterruptibleTemplate.TankerPlanner.TheWaypoint = waypoint;
				ItemExporter.ConnectInterruptibleTemplate.TankerPlanner.Show();
			}
		}
	}

	private void CheckAlgo(object sender, EventArgs e)
	{
		if (DGV_Waypoints.SelectedRows.Count > 0)
		{
			Waypoint waypoint = (Waypoint)DGV_Waypoints.SelectedRows[0].Tag;
			if (!Information.IsNothing(waypoint))
			{
				DoctrineForm doctrineForm = new DoctrineForm();
				doctrineForm.Subject = waypoint;
				doctrineForm.isEscorts = false;
				doctrineForm.Show();
				doctrineForm.TabControl1A.SelectedIndex = 1;
			}
		}
	}

	private void ConcatAlgo(object sender, DataGridViewColumnEventArgs e)
	{
		Rectangle displayRectangle = DGV_Waypoints.DisplayRectangle;
		DGV_Waypoints.Invalidate(displayRectangle);
	}

	private void InterruptAlgo(object sender, PaintEventArgs e)
	{
		try
		{
			if (DGV_Waypoints.Rows.Count > 0)
			{
				Rectangle cellDisplayRectangle = DGV_Waypoints.GetCellDisplayRectangle(DGV_Waypoints.Columns["TimeFixedImg"].Index, 0, cutOverflow: false);
				Rectangle cellDisplayRectangle2 = DGV_Waypoints.GetCellDisplayRectangle(DGV_Waypoints.Columns["TimeFixedImg"].Index, DGV_Waypoints.Rows.Count - 1, cutOverflow: false);
				float x = cellDisplayRectangle.Right;
				float y = cellDisplayRectangle.Top;
				float x2 = cellDisplayRectangle2.Right;
				float y2 = cellDisplayRectangle2.Bottom;
				e.Graphics.DrawLine(Pens.DarkGray, x, y, x2, y2);
				cellDisplayRectangle = DGV_Waypoints.GetCellDisplayRectangle(DGV_Waypoints.Columns["SpeedFixedImg"].Index, 0, cutOverflow: false);
				cellDisplayRectangle2 = DGV_Waypoints.GetCellDisplayRectangle(DGV_Waypoints.Columns["SpeedFixedImg"].Index, DGV_Waypoints.Rows.Count - 1, cutOverflow: false);
				x = cellDisplayRectangle.Right;
				y = cellDisplayRectangle.Top;
				x2 = cellDisplayRectangle2.Right;
				y2 = cellDisplayRectangle2.Bottom;
				e.Graphics.DrawLine(Pens.DarkGray, x, y, x2, y2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RemoveAlgo(object sender, EventArgs e)
	{
		if (!Client.FlightPlanEditorWindow.WaypointList_Refresh)
		{
			return;
		}
		DisplayLocks();
		EnableAndDisableCells();
		EnableAndDisableButtons();
		try
		{
			(from x in (from x in Module_Mission.AssetTokenizer(Client.FlightPlanEditorWindow.SelectedMission, Client.CurrentScenario)
					where !Information.IsNothing(x.Navigator.GetFlight())
					select x).ToList()
				where Operators.CompareString(x.Navigator.GetFlight().Callsign, Client.FlightPlanEditorWindow.SelectedFlight.Callsign, TextCompare: true) == 0
				select x).ToList();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 98723454657411", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void DisplayLocks()
	{
		try
		{
			Client.FlightPlanEditorWindow.theImageLocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageUnlocked.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageNotConfigured.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageNotLockable.MakeTransparent(Color.White);
			Client.FlightPlanEditorWindow.theImageRelative.MakeTransparent(Color.White);
			bool waypointList_Refresh = Client.FlightPlanEditorWindow.WaypointList_Refresh;
			Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
			IEnumerator enumerator = null;
			try
			{
				enumerator = ((IEnumerable)DGV_Waypoints.Rows).GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 1))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageLocked)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageLocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 0))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageUnlocked)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageUnlocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 2))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotLockable)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotLockable;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["TimeFixed"].Value), 3))
					{
						if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageRelative)
						{
							dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageRelative;
						}
					}
					else if (dataGridViewRow.Cells["TimeFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotConfigured)
					{
						dataGridViewRow.Cells["TimeFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotConfigured;
					}
					if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 1))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageLocked)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageLocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 0))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageUnlocked)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageUnlocked;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 2))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotLockable)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotLockable;
						}
					}
					else if (object.Equals(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells["SpeedFixed"].Value), 3))
					{
						if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageRelative)
						{
							dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageRelative;
						}
					}
					else if (dataGridViewRow.Cells["SpeedFixedImg"].Value != Client.FlightPlanEditorWindow.theImageNotConfigured)
					{
						dataGridViewRow.Cells["SpeedFixedImg"].Value = Client.FlightPlanEditorWindow.theImageNotConfigured;
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
			Client.FlightPlanEditorWindow.WaypointList_Refresh = waypointList_Refresh;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EnableAndDisableCells()
	{
		try
		{
			bool flag = true;
			IEnumerator enumerator = null;
			try
			{
				enumerator = ((IEnumerable)DGV_Waypoints.Rows).GetEnumerator();
				Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
				while (enumerator.MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator.Current;
					Waypoint waypoint = (Waypoint)dataGridViewRow.Tag;
					if (Information.IsNothing(waypoint))
					{
						continue;
					}
					if (waypoint.Type == Waypoint.WaypointType.StationEnd)
					{
						dataGridViewRow.Cells["Type"].ReadOnly = true;
						dataGridViewRow.Cells["Type"].Style.BackColor = Color.LightGray;
						dataGridViewRow.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
						dataGridViewRow.Cells["Type"].Style.SelectionForeColor = Color.Black;
					}
					else if (dataGridViewRow.Cells["Type"].ReadOnly)
					{
						dataGridViewRow.Cells["Type"].ReadOnly = false;
						dataGridViewRow.Cells["Type"].Style.BackColor = default(Color);
						dataGridViewRow.Cells["Type"].Style.SelectionBackColor = default(Color);
					}
					if (waypoint.Type == Waypoint.WaypointType.HoldEnd)
					{
						dataGridViewRow.Cells["Type"].ReadOnly = true;
						dataGridViewRow.Cells["Type"].Style.SelectionBackColor = Color.LightGray;
						dataGridViewRow.Cells["Type"].Style.SelectionForeColor = Color.Black;
					}
					else if (dataGridViewRow.Cells["Type"].ReadOnly)
					{
						dataGridViewRow.Cells["Type"].ReadOnly = false;
						dataGridViewRow.Cells["Type"].Style.BackColor = default(Color);
						dataGridViewRow.Cells["Type"].Style.SelectionBackColor = default(Color);
					}
					flag = true;
					Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = waypoint.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					byte? b = (byte?)useReplenishment;
					bool? flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
					bool? flag3 = (!flag2) ?? flag2;
					if (flag3.GetValueOrDefault(true))
					{
						b = (byte?)useReplenishment;
						bool? flag4;
						bool? flag5 = (flag4 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
						bool? flag6;
						flag4 = (flag6 = ((flag5.HasValue && !flag4.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag4)));
						bool? flag7;
						if (flag4.HasValue && !flag6.GetValueOrDefault())
						{
							flag7 = false;
						}
						else
						{
							b = (byte?)useUnderwayRefuelAndReplenishment;
							bool? flag8;
							flag4 = (flag8 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
							flag7 = ((!flag4.HasValue) ? null : (flag8.GetValueOrDefault() & flag6));
						}
						flag2 = flag7;
						if (((!flag2) ?? flag2).GetValueOrDefault() && flag3.HasValue)
						{
							if (dataGridViewRow.Cells["AARSelection"].ReadOnly)
							{
								dataGridViewRow.Cells["AARSelection"].ReadOnly = false;
								dataGridViewRow.Cells["AARSelection"].Style.BackColor = default(Color);
								dataGridViewRow.Cells["AARSelection"].Style.ForeColor = default(Color);
								dataGridViewRow.Cells["AARSelection"].Style.SelectionBackColor = default(Color);
								dataGridViewRow.Cells["AARSelection"].Style.SelectionForeColor = default(Color);
							}
							goto IL_0618;
						}
					}
					flag = false;
					dataGridViewRow.Cells["AARSelection"].ReadOnly = true;
					dataGridViewRow.Cells["AARSelection"].Style.BackColor = Color.LightGray;
					dataGridViewRow.Cells["AARSelection"].Style.ForeColor = dataGridViewRow.Cells["AARSelection"].Style.BackColor;
					dataGridViewRow.Cells["AARSelection"].Style.SelectionBackColor = Color.LightGray;
					dataGridViewRow.Cells["AARSelection"].Style.SelectionForeColor = dataGridViewRow.Cells["AARSelection"].Style.SelectionBackColor;
					goto IL_0618;
					IL_0618:
					b = (byte?)useReplenishment;
					flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
					if (((!flag3) ?? flag3).GetValueOrDefault())
					{
						useUnderwayRefuelAndReplenishment = useReplenishment;
					}
					if (waypoint.Type != Waypoint.WaypointType.StationEnd && waypoint.Type != Waypoint.WaypointType.Assemble && waypoint.Type != Waypoint.WaypointType.HoldEnd && waypoint.Type != Waypoint.WaypointType.TakeOff)
					{
						if (dataGridViewRow.Cells["SpeedToT"].ReadOnly)
						{
							dataGridViewRow.Cells["SpeedToT"].ReadOnly = false;
							dataGridViewRow.Cells["SpeedToT"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["SpeedToT"].Style.ForeColor = default(Color);
							dataGridViewRow.Cells["SpeedToT"].Style.SelectionBackColor = default(Color);
							dataGridViewRow.Cells["SpeedToT"].Style.SelectionForeColor = default(Color);
						}
					}
					else
					{
						dataGridViewRow.Cells["SpeedToT"].ReadOnly = true;
						dataGridViewRow.Cells["SpeedToT"].Style.BackColor = Color.LightGray;
						dataGridViewRow.Cells["SpeedToT"].Style.ForeColor = dataGridViewRow.Cells["SpeedToT"].Style.BackColor;
						dataGridViewRow.Cells["SpeedToT"].Style.SelectionBackColor = Color.LightGray;
						dataGridViewRow.Cells["SpeedToT"].Style.SelectionForeColor = dataGridViewRow.Cells["SpeedToT"].Style.SelectionBackColor;
					}
					if (!Information.IsNothing(Client.FlightPlanEditorWindow.SelectedFlight))
					{
						if (Client.FlightPlanEditorWindow.SelectedFlight.DesiredAircraftQty <= 1)
						{
							dataGridViewRow.Cells["Formation"].ReadOnly = true;
							dataGridViewRow.Cells["Formation"].Style.BackColor = Color.LightGray;
							dataGridViewRow.Cells["Formation"].Style.ForeColor = dataGridViewRow.Cells["Formation"].Style.BackColor;
							dataGridViewRow.Cells["Formation"].Style.SelectionBackColor = Color.LightGray;
							dataGridViewRow.Cells["Formation"].Style.SelectionForeColor = dataGridViewRow.Cells["Formation"].Style.SelectionBackColor;
						}
						else
						{
							dataGridViewRow.Cells["Formation"].ReadOnly = false;
							dataGridViewRow.Cells["Formation"].Style.BackColor = default(Color);
							dataGridViewRow.Cells["Formation"].Style.ForeColor = default(Color);
							dataGridViewRow.Cells["Formation"].Style.SelectionBackColor = default(Color);
							dataGridViewRow.Cells["Formation"].Style.SelectionForeColor = default(Color);
						}
					}
					Doctrine._UnderwayRefuelAndReplenishmentSelection? replenishmentSelection = waypoint.Doctrine.GetReplenishmentSelection(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					if (waypoint.Type == Waypoint.WaypointType.Refuel && flag)
					{
						b = (byte?)replenishmentSelection;
						flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
						if (((!flag3) ?? flag3).GetValueOrDefault())
						{
							if (dataGridViewRow.Cells["AARSettings"].ReadOnly)
							{
								dataGridViewRow.Cells["AARSettings"].ReadOnly = false;
								dataGridViewRow.Cells["AARSettings"].Style.BackColor = default(Color);
								dataGridViewRow.Cells["AARSettings"].Style.ForeColor = default(Color);
								dataGridViewRow.Cells["AARSettings"].Style.SelectionBackColor = default(Color);
								dataGridViewRow.Cells["AARSettings"].Style.SelectionForeColor = default(Color);
							}
							continue;
						}
					}
					dataGridViewRow.Cells["AARSettings"].ReadOnly = true;
					dataGridViewRow.Cells["AARSettings"].Style.BackColor = Color.LightGray;
					dataGridViewRow.Cells["AARSettings"].Style.ForeColor = dataGridViewRow.Cells["AARSettings"].Style.BackColor;
					dataGridViewRow.Cells["AARSettings"].Style.SelectionBackColor = Color.LightGray;
					dataGridViewRow.Cells["AARSettings"].Style.SelectionForeColor = dataGridViewRow.Cells["AARSettings"].Style.SelectionBackColor;
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EnableAndDisableButtons()
	{
		try
		{
			Button_InsertWaypoint.Enabled = false;
			Button_DeleteWaypoint.Enabled = false;
			Button_EditSpeedAltitude.Enabled = false;
			Button_EditTime.Enabled = false;
			Button_ClearTime.Enabled = false;
			Button_EditDoctrine.Enabled = false;
			Button_EditAAR.Enabled = false;
			Button_EditSensorUsage.Enabled = false;
			Button_EditTargetAndWeapons.Enabled = false;
			if (DGV_Waypoints.SelectedRows.Count == 1)
			{
				int num = DGV_Waypoints.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					DataGridViewRow dataGridViewRow = DGV_Waypoints.Rows[i];
					if (!dataGridViewRow.Selected)
					{
						continue;
					}
					Waypoint waypoint = (Waypoint)dataGridViewRow.Tag;
					if (Information.IsNothing(waypoint))
					{
						continue;
					}
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.Refuel:
					case Waypoint.WaypointType.TakeOff:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
					case Waypoint.WaypointType.StationEnd:
					case Waypoint.WaypointType.HoldEnd:
						Button_InsertWaypoint.Enabled = true;
						break;
					}
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.Refuel:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
						Button_DeleteWaypoint.Enabled = true;
						break;
					}
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.Refuel:
					case Waypoint.WaypointType.TakeOff:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
					case Waypoint.WaypointType.HoldStart:
					case Waypoint.WaypointType.HoldEnd:
						Button_EditSpeedAltitude.Enabled = true;
						break;
					}
					if (Client.FlightPlanEditorWindow.SelectedFlight.Task != Mission._FlightTask.QRA)
					{
						if (Client.FlightPlanEditorWindow.SelectedFlight.Type == Mission._FlightType.FlightplanTemplate)
						{
							if (waypoint.Type == Waypoint.WaypointType.StationEnd)
							{
								Button_EditTime.Enabled = true;
							}
						}
						else
						{
							switch (waypoint.Type)
							{
							case Waypoint.WaypointType.Assemble:
							case Waypoint.WaypointType.TurningPoint:
							case Waypoint.WaypointType.InitialPoint:
							case Waypoint.WaypointType.Target:
							case Waypoint.WaypointType.LandingMarshal:
							case Waypoint.WaypointType.StrikeIngress:
							case Waypoint.WaypointType.StrikeEgress:
							case Waypoint.WaypointType.Refuel:
							case Waypoint.WaypointType.TakeOff:
							case Waypoint.WaypointType.WeaponLaunch:
							case Waypoint.WaypointType.Land:
							case Waypoint.WaypointType.WeaponTarget:
							case Waypoint.WaypointType.StationStart_Racetrack:
							case Waypoint.WaypointType.StationStart_FigureEight:
							case Waypoint.WaypointType.StationStart_Area:
							case Waypoint.WaypointType.StationStart_RaceTrackRandom:
							case Waypoint.WaypointType.StationEnd:
							case Waypoint.WaypointType.HoldStart:
							case Waypoint.WaypointType.HoldEnd:
								Button_EditTime.Enabled = true;
								break;
							}
						}
					}
					if (DGV_Waypoints.Rows.Count > 0)
					{
						Button_ClearTime.Enabled = true;
					}
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.Refuel:
					case Waypoint.WaypointType.TakeOff:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
					case Waypoint.WaypointType.HoldStart:
					case Waypoint.WaypointType.HoldEnd:
						Button_EditDoctrine.Enabled = true;
						break;
					}
					Doctrine._UseUnderwayRefuelAndReplenishment? useReplenishment = waypoint.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					byte? b;
					bool? flag2;
					if (waypoint.Type == Waypoint.WaypointType.Refuel)
					{
						b = (byte?)useReplenishment;
						bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
						flag2 = (!flag) ?? flag;
						if (flag2.GetValueOrDefault(true))
						{
							b = (byte?)useReplenishment;
							bool? flag3;
							bool? flag4 = (flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null));
							Doctrine._UseUnderwayRefuelAndReplenishment? useUnderwayRefuelAndReplenishment = null;
							bool? flag5;
							flag3 = (flag5 = ((flag4.HasValue && !flag3.GetValueOrDefault()) ? new bool?(false) : (Information.IsNothing(useUnderwayRefuelAndReplenishment) ? new bool?(false) : flag3)));
							bool? flag6;
							if (flag3.HasValue && !flag5.GetValueOrDefault())
							{
								flag6 = false;
							}
							else
							{
								b = (byte?)useUnderwayRefuelAndReplenishment;
								bool? flag7;
								flag3 = (flag7 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
								flag6 = ((!flag3.HasValue) ? null : (flag7.GetValueOrDefault() & flag5));
							}
							flag = flag6;
							if (((!flag) ?? flag).GetValueOrDefault() && flag2.HasValue)
							{
								Button_EditAAR.Enabled = true;
							}
						}
					}
					b = (byte?)useReplenishment;
					flag2 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 4) : null);
					((!flag2) ?? flag2).GetValueOrDefault();
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.Refuel:
					case Waypoint.WaypointType.TakeOff:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
					case Waypoint.WaypointType.HoldStart:
					case Waypoint.WaypointType.HoldEnd:
						Button_EditSensorUsage.Enabled = true;
						break;
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.Marshal:
					case Waypoint.WaypointType.Land:
					case Waypoint.WaypointType.PickupPoint:
						break;
					}
					break;
				}
			}
			else if (DGV_Waypoints.SelectedRows.Count <= 1)
			{
				if (DGV_Waypoints.Rows.Count > 0)
				{
					Button_ClearTime.Enabled = true;
				}
			}
			else if (DGV_Waypoints.Rows.Count > 0)
			{
				Button_ClearTime.Enabled = true;
				Button_DeleteWaypoint.Enabled = true;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FindAlgo(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			int num = DGV_Waypoints.Rows.Count - 1;
			DataGridViewRow dataGridViewRow = null;
			for (int i = 0; i <= num; i++)
			{
				DataGridViewRow dataGridViewRow2 = DGV_Waypoints.Rows[i];
				if (!dataGridViewRow2.Selected)
				{
					continue;
				}
				dataGridViewRow = dataGridViewRow2;
				Client.FlightPlanEditorWindow.SelectedWaypoint = (Waypoint)dataGridViewRow.Tag;
				Client.SelectedWaypoint = Client.FlightPlanEditorWindow.SelectedWaypoint;
				DataGridViewColumn dataGridViewColumn = DGV_Waypoints.Columns[e.ColumnIndex];
				if (Operators.CompareString(dataGridViewColumn.Name, "Type", TextCompare: true) == 0)
				{
					if (!DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_ = new DataTable();
						DataGridViewComboBoxCell obj = (DataGridViewComboBoxCell)DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_WaypointType(ref dataTable_);
						obj.DataSource = dataTable_;
						obj.DisplayMember = "Description";
						obj.ValueMember = "ID";
						obj.DropDownWidth = 500;
					}
					DGV_Waypoints.BeginEdit(selectAll: true);
					if (DGV_Waypoints.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_Waypoints.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_Waypoints.EditingControl).DroppedDown = true;
					}
					break;
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "Formation", TextCompare: true) == 0)
				{
					if (!DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_2 = new DataTable();
						DataGridViewComboBoxCell obj2 = (DataGridViewComboBoxCell)DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_Formation(ref dataTable_2);
						obj2.DataSource = dataTable_2;
						obj2.DisplayMember = "Description";
						obj2.ValueMember = "ID";
						obj2.DropDownWidth = 500;
					}
					DGV_Waypoints.BeginEdit(selectAll: true);
					if (DGV_Waypoints.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_Waypoints.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_Waypoints.EditingControl).DroppedDown = true;
					}
					break;
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "AARUsage", TextCompare: true) == 0)
				{
					Waypoint waypoint = (Waypoint)dataGridViewRow2.Tag;
					if (!Information.IsNothing(waypoint))
					{
						if (!DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
						{
							DataTable dataTable_3 = new DataTable();
							waypoint.Doctrine.ComboBox_UseReplenishment(ref dataTable_3, Client.CurrentScenario, null);
							DataGridViewComboBoxCell obj3 = (DataGridViewComboBoxCell)DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index];
							obj3.DataSource = dataTable_3;
							obj3.DisplayMember = "Description";
							obj3.ValueMember = "ID";
							obj3.DropDownWidth = 500;
						}
						DGV_Waypoints.BeginEdit(selectAll: true);
						if (DGV_Waypoints.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_Waypoints.EditingControl))
						{
							((DataGridViewComboBoxEditingControl)DGV_Waypoints.EditingControl).DroppedDown = true;
						}
						break;
					}
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "AARSelection", TextCompare: true) == 0)
				{
					Waypoint waypoint2 = (Waypoint)dataGridViewRow2.Tag;
					if (!Information.IsNothing(waypoint2))
					{
						if (!DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
						{
							DataTable dataTable_4 = new DataTable();
							waypoint2.Doctrine.ComboBox_ReplenishmentSelection(ref dataTable_4, Client.CurrentScenario, null);
							DataGridViewComboBoxCell obj4 = (DataGridViewComboBoxCell)DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index];
							obj4.DataSource = dataTable_4;
							obj4.DisplayMember = "Description";
							obj4.ValueMember = "ID";
							obj4.DropDownWidth = 500;
						}
						DGV_Waypoints.BeginEdit(selectAll: true);
						if (DGV_Waypoints.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_Waypoints.EditingControl))
						{
							((DataGridViewComboBoxEditingControl)DGV_Waypoints.EditingControl).DroppedDown = true;
						}
						break;
					}
				}
				if (Operators.CompareString(dataGridViewColumn.Name, "SpeedToT", TextCompare: true) == 0)
				{
					if (!DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_5 = new DataTable();
						DataGridViewComboBoxCell obj5 = (DataGridViewComboBoxCell)DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_SpeedToT(ref dataTable_5);
						obj5.DataSource = dataTable_5;
						obj5.DisplayMember = "Description";
						obj5.ValueMember = "ID";
						obj5.DropDownWidth = 500;
					}
					DGV_Waypoints.BeginEdit(selectAll: true);
					if (DGV_Waypoints.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_Waypoints.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_Waypoints.EditingControl).DroppedDown = true;
					}
				}
				else if (Operators.CompareString(dataGridViewColumn.Name, "TurnRate", TextCompare: true) == 0)
				{
					if (!DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index].IsInEditMode)
					{
						DataTable dataTable_6 = new DataTable();
						DataGridViewComboBoxCell obj6 = (DataGridViewComboBoxCell)DGV_Waypoints[dataGridViewColumn.Index, dataGridViewRow2.Index];
						Waypoint.ComboBoxDataSource_TurnRate(ref dataTable_6);
						obj6.DataSource = dataTable_6;
						obj6.DisplayMember = "Description";
						obj6.ValueMember = "ID";
						obj6.DropDownWidth = 500;
					}
					DGV_Waypoints.BeginEdit(selectAll: true);
					if (DGV_Waypoints.Rows[e.RowIndex].Cells[Type.Name].Selected && !Information.IsNothing(DGV_Waypoints.EditingControl))
					{
						((DataGridViewComboBoxEditingControl)DGV_Waypoints.EditingControl).DroppedDown = true;
					}
				}
				else if (Operators.CompareString(dataGridViewColumn.Name, "TimeFixedImg", TextCompare: true) == 0)
				{
					Waypoint waypoint_ = (Waypoint)dataGridViewRow2.Tag;
					if (Information.IsNothing(waypoint_.Time_Zulu))
					{
						break;
					}
					if (waypoint_.TimeFixed == Waypoint.FixedFree.Free)
					{
						waypoint_.TimeFixed = Waypoint.FixedFree.Fixed;
						dataGridViewRow2.Cells["TimeFixed"].Value = waypoint_.TimeFixed;
						Mission.Flight selectedFlight = Client.FlightPlanEditorWindow.SelectedFlight;
						ref Mission selectedMission = ref Client.FlightPlanEditorWindow.SelectedMission;
						Mission.Flight selectedFlight2 = Client.FlightPlanEditorWindow.SelectedFlight;
						Waypoint[] waypoint_2 = selectedFlight2.FlightPlan;
						AirTaskingOrder.UpdateWingmanWaypoints(selectedFlight, ref waypoint_, ref selectedMission, ref waypoint_2, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element);
						selectedFlight2.FlightPlan = waypoint_2;
					}
					else if (waypoint_.TimeFixed == Waypoint.FixedFree.Fixed)
					{
						if (waypoint_.FlightFormation == Waypoint.Formation.Split && FlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
						{
							waypoint_.TimeFixed = Waypoint.FixedFree.Relative;
							dataGridViewRow2.Cells["TimeFixed"].Value = waypoint_.TimeFixed;
						}
						else
						{
							waypoint_.TimeFixed = Waypoint.FixedFree.Free;
							dataGridViewRow2.Cells["TimeFixed"].Value = waypoint_.TimeFixed;
						}
					}
					else if (waypoint_.TimeFixed == Waypoint.FixedFree.Relative)
					{
						waypoint_.TimeFixed = Waypoint.FixedFree.Free;
						dataGridViewRow2.Cells["TimeFixed"].Value = waypoint_.TimeFixed;
					}
					flag = true;
					flag2 = true;
					flag4 = true;
				}
				else
				{
					if (Operators.CompareString(dataGridViewColumn.Name, "SpeedFixedImg", TextCompare: true) != 0)
					{
						break;
					}
					Waypoint waypoint3 = (Waypoint)dataGridViewRow2.Tag;
					if (Client.FlightPlanEditorWindow.SelectedFlight.ReferenceUnit_DBID == 0)
					{
						new DarkMessageBox("没有选择飞机类\u200b\u200b型的Flightplan模板只能使用固定速度！").ShowDialog();
						waypoint3.SpeedFixed = Waypoint.FixedFree.Fixed;
					}
					else if (waypoint3.SpeedFixed == Waypoint.FixedFree.Free)
					{
						if (!Information.IsNothing(waypoint3.DesiredSpeed) || waypoint3.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							waypoint3.SpeedFixed = Waypoint.FixedFree.Fixed;
						}
					}
					else if (waypoint3.SpeedFixed == Waypoint.FixedFree.Fixed)
					{
						if (waypoint3.Type != Waypoint.WaypointType.TakeOff && waypoint3.Type != Waypoint.WaypointType.Land)
						{
							if (waypoint3.FlightFormation == Waypoint.Formation.Split && FlightPlan_Element != Mission.Flight.FlightElement.LeadElement)
							{
								waypoint3.SpeedFixed = Waypoint.FixedFree.Relative;
								if (!Information.IsNothing(Client.FlightPlanEditorWindow.SelectedFlight) && Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan.Count() >= i + 1)
								{
									Waypoint waypoint4 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[i];
									waypoint3.DesiredSpeed = waypoint4.DesiredSpeed;
									waypoint3.DesiredSpeedOverride = waypoint4.DesiredSpeedOverride;
									waypoint3.ThrottlePreset = waypoint4.ThrottlePreset;
								}
							}
							else
							{
								waypoint3.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
								waypoint3.DesiredSpeed = null;
								waypoint3.DesiredSpeedOverride = null;
								waypoint3.SpeedFixed = Waypoint.FixedFree.Free;
							}
						}
						else
						{
							waypoint3.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
							waypoint3.DesiredSpeed = null;
							waypoint3.DesiredSpeedOverride = null;
							waypoint3.SpeedFixed = Waypoint.FixedFree.Fixed;
						}
					}
					else if (waypoint3.SpeedFixed == Waypoint.FixedFree.Relative)
					{
						waypoint3.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
						waypoint3.DesiredSpeed = null;
						waypoint3.DesiredSpeedOverride = null;
						waypoint3.SpeedFixed = Waypoint.FixedFree.Free;
					}
					flag = true;
					flag2 = true;
				}
				break;
			}
			if (Information.IsNothing(dataGridViewRow))
			{
				Button_InsertWaypoint.Enabled = false;
				Button_DeleteWaypoint.Enabled = false;
				Button_EditTime.Enabled = false;
				Button_ClearTime.Enabled = false;
				Button_EditSpeedAltitude.Enabled = false;
				Button_EditDoctrine.Enabled = false;
				Button_EditAAR.Enabled = false;
				Button_EditSensorUsage.Enabled = false;
			}
			else
			{
				Button_InsertWaypoint.Enabled = true;
				Button_DeleteWaypoint.Enabled = true;
				Button_EditTime.Enabled = true;
				Button_ClearTime.Enabled = true;
				Button_EditSpeedAltitude.Enabled = true;
				Button_EditDoctrine.Enabled = true;
				Button_EditAAR.Enabled = true;
				Button_EditSensorUsage.Enabled = true;
			}
			if (flag)
			{
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, flag2, bool_2: false, flag3, bool_4: false);
			}
			else if (flag3)
			{
				Client.FlightPlanEditorWindow.NewPolicy();
			}
			else if (flag2)
			{
				Client.FlightPlanEditorWindow.InvokePolicy();
			}
			if (flag || flag3 || flag2)
			{
				DisplayLocks();
				EnableAndDisableCells();
			}
			if (Client.FlightPlanTimeWindow.Visible && Client.FlightPlanTimeWindow.ViaFlightPlanEditor)
			{
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				ref Mission selectedMission2 = ref Client.FlightPlanEditorWindow.SelectedMission;
				FlightPlanEditor flightPlanEditorWindow = Client.FlightPlanEditorWindow;
				Mission.Flight flight_ = flightPlanEditorWindow.SelectedFlight;
				FlightPlanEditor flightPlanEditorWindow2 = Client.FlightPlanEditorWindow;
				Waypoint waypoint_3 = flightPlanEditorWindow2.SelectedWaypoint;
				flightPlanTimeWindow.RefreshStats(ref selectedMission2, ref flight_, ref waypoint_3, Client.FlightPlanEditorWindow.theFlightPlanWaypoints.FlightPlan_Element, bool_0: true);
				flightPlanEditorWindow2.SelectedWaypoint = waypoint_3;
				flightPlanEditorWindow.SelectedFlight = flight_;
			}
			if (flag4 && Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
				Client.AirTaskingOrderWindow.DisplayLocks();
			}
			EnableAndDisableButtons();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200588", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Waypoint GetActualWaypoint(ref Waypoint waypoint_0, Mission.Flight.FlightElement flightElement_0)
	{
		try
		{
			if (flightElement_0 == Mission.Flight.FlightElement.LeadElement)
			{
				return waypoint_0;
			}
			if (waypoint_0.FlightFormation == Waypoint.Formation.Spread)
			{
				return waypoint_0;
			}
			switch (flightElement_0)
			{
			case Mission.Flight.FlightElement.LeadElementWingman:
				if (!Information.IsNothing(waypoint_0.Waypoint_LeadElementWingman))
				{
					return waypoint_0.Waypoint_LeadElementWingman;
				}
				break;
			case Mission.Flight.FlightElement.SecondElement:
				if (!Information.IsNothing(waypoint_0.Waypoint_SecondElement))
				{
					return waypoint_0.Waypoint_SecondElement;
				}
				break;
			case Mission.Flight.FlightElement.SecondElementWingman:
				if (!Information.IsNothing(waypoint_0.Waypoint_SecondElementWingman))
				{
					return waypoint_0.Waypoint_SecondElementWingman;
				}
				break;
			case Mission.Flight.FlightElement.ThirdElement:
				if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElement))
				{
					return waypoint_0.Waypoint_ThirdElement;
				}
				break;
			case Mission.Flight.FlightElement.ThirdElementWingman:
				if (!Information.IsNothing(waypoint_0.Waypoint_ThirdElementWingman))
				{
					return waypoint_0.Waypoint_ThirdElementWingman;
				}
				break;
			}
			return waypoint_0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	private void SetAlgo(object sender, DataGridViewCellEventArgs e)
	{
		if (DGV_Waypoints.SelectedRows.Count != 0 && Client.FlightPlanEditorWindow.WaypointList_Refresh)
		{
			CalculateAlgo(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void FillAlgo(object sender, EventArgs e)
	{
		Client.FlightPlanEditorWindow.WaypointList_Refresh = true;
		if (DGV_Waypoints.IsCurrentCellDirty)
		{
			DGV_Waypoints.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private void CalculateAlgo(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			bool flag = false;
			if (Information.IsNothing(Client.FlightPlanEditorWindow.SelectedFlight) || e.RowIndex > Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan.Count() - 1)
			{
				return;
			}
			Waypoint waypoint = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex];
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_Waypoints.Columns["Type"].Index)
			{
				DataGridViewCell dataGridViewCell = DGV_Waypoints[e.ColumnIndex, e.RowIndex];
				object object_ = RuntimeHelpers.GetObjectValue(dataGridViewCell.Value);
				int? num = Waypoint.WaypointTypeSelection_To_WaypointType(ref object_);
				dataGridViewCell.Value = RuntimeHelpers.GetObjectValue(object_);
				Waypoint.WaypointType value = (Waypoint.WaypointType)num.Value;
				if (e.RowIndex == 0)
				{
					if (value == Waypoint.WaypointType.TakeOff)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("飞行计划中的第一个航点必须是起飞航路点！").ShowDialog();
					}
				}
				else if (e.RowIndex == DGV_Waypoints.Rows.Count - 1)
				{
					if (value == Waypoint.WaypointType.Land)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("飞行计划中的最后一个航点必须是着陆航点！").ShowDialog();
					}
				}
				else if (e.RowIndex == DGV_Waypoints.Rows.Count - 2)
				{
					if (value == Waypoint.WaypointType.LandingMarshal)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("飞行计划中的倒数第二个航点必须是着陆集结航点！").ShowDialog();
					}
				}
				else if (value == Waypoint.WaypointType.TakeOff)
				{
					if (e.RowIndex == 0)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("起飞航点必须是飞行计划中的第一个航点！").ShowDialog();
					}
				}
				else if (value == Waypoint.WaypointType.Land)
				{
					if (e.RowIndex == DGV_Waypoints.Rows.Count - 1)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("登陆航点必须是飞行计划中的最后一个航点！").ShowDialog();
					}
				}
				else if (value == Waypoint.WaypointType.LandingMarshal)
				{
					if (e.RowIndex == DGV_Waypoints.Rows.Count - 2)
					{
						waypoint.Type = value;
					}
					else
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("着陆集结航点必须是飞行计划中的第二个航点！").ShowDialog();
					}
				}
				else if (value != Waypoint.WaypointType.StationStart_Area && value != Waypoint.WaypointType.StationStart_FigureEight && value != Waypoint.WaypointType.StationStart_Racetrack && value != Waypoint.WaypointType.StationStart_RaceTrackRandom)
				{
					if (value == Waypoint.WaypointType.StationEnd)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("配置了开始巡逻航点时，将自动设置结束巡逻航点。请选择开始巡逻。").ShowDialog();
					}
					else if (value == Waypoint.WaypointType.HoldStart)
					{
						if (e.RowIndex < 1)
						{
							Client.FlightPlanEditorWindow.NewPolicy();
							new DarkMessageBox("飞行计划中的第一个航路点不能是开始警戒航点！").ShowDialog();
						}
						else if (e.RowIndex <= DGV_Waypoints.Rows.Count - 4)
						{
							Waypoint waypoint2 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
							if (waypoint2.ChangeReponse() && !waypoint2.InitReponse())
							{
								Client.FlightPlanEditorWindow.NewPolicy();
								new DarkMessageBox("Hold Start航路点之后的航路点不能是另一个开始警戒航点！").ShowDialog();
							}
							else if (waypoint.FlightFormation != Waypoint.Formation.Split && waypoint2.FlightFormation != Waypoint.Formation.Split)
							{
								if (waypoint2.Type != Waypoint.WaypointType.TurningPoint && waypoint2.Type != Waypoint.WaypointType.StrikeIngress && waypoint2.Type != Waypoint.WaypointType.StrikeEgress)
								{
									Client.FlightPlanEditorWindow.NewPolicy();
									new DarkMessageBox("开始警戒航点后面的航点将变为结束警戒航点，并且只能是转弯点类型。").ShowDialog();
								}
								else
								{
									waypoint.Type = value;
									waypoint.TurnRate_Navigation = Waypoint.TurnRateCategory.StandardRateTurn;
									if (!Information.IsNothing(Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario)))
									{
										waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
										waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
										if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
										{
											waypoint.DesiredSpeed = Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
										}
										else
										{
											waypoint.DesiredSpeed = Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
										}
										waypoint.DesiredSpeedOverride = null;
									}
									waypoint2.Type = Waypoint.WaypointType.HoldEnd;
									waypoint2.Hold_Time = 600f;
									Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
									flag = true;
								}
							}
							else
							{
								Client.FlightPlanEditorWindow.NewPolicy();
								new DarkMessageBox("开始警戒或结束警戒航点不能使用编队解散。将阵型更改为分散并再次尝试。").ShowDialog();
							}
						}
						else
						{
							Client.FlightPlanEditorWindow.NewPolicy();
							new DarkMessageBox("飞行计划中的倒数第三个航路点不能是开始警戒航点！原因：着陆和着陆集结航路点都不能是结束警戒航点。注意！开始警戒后的航点自动变为结束警戒航路点。").ShowDialog();
						}
					}
					else if (value == Waypoint.WaypointType.HoldEnd)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("配置开始警戒航点时，会自动设置结束警戒航点。请选择开始警戒。").ShowDialog();
					}
					else if ((value == Waypoint.WaypointType.InitialPoint || value == Waypoint.WaypointType.WeaponLaunch) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("只有打击任务可以使用初始点或武器释放航路点。").ShowDialog();
					}
					else if ((value == Waypoint.WaypointType.InitialPoint || value == Waypoint.WaypointType.WeaponLaunch) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("攻击任务的护航不能使用初始点或武器释放航路点。如果您希望攻击特定目标，请将编队任务更改为非护航类型。").ShowDialog();
					}
					else if ((value == Waypoint.WaypointType.Target || value == Waypoint.WaypointType.WeaponTarget) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("只有打击任务可以使用目标或武器目标航点。").ShowDialog();
					}
					else if ((value == Waypoint.WaypointType.Target || value == Waypoint.WaypointType.WeaponTarget) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("攻击任务的护航不能使用目标或武器目标航点。如果您希望攻击特定目标，请将编队任务更改为非护航类型。").ShowDialog();
					}
					else if ((value == Waypoint.WaypointType.StrikeIngress || value == Waypoint.WaypointType.StrikeEgress) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("只有打击任务可以使用Ingress或Egress航路点。").ShowDialog();
					}
					else if ((value == Waypoint.WaypointType.StrikeIngress || value == Waypoint.WaypointType.StrikeEgress) && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("攻击任务的护航必须使用转弯点航路点，而不是转弯点（入口）或转弯点（出口）。").ShowDialog();
					}
					else if (value == Waypoint.WaypointType.TurningPoint && Client.FlightPlanEditorWindow.SelectedMission.MissionClass == Mission._MissionClass.Strike && !Client.FlightPlanEditorWindow.SelectedFlight.IsEscort)
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("使用转折点（入口）或转折点（出口）航路点进行打击任务。").ShowDialog();
					}
					else
					{
						if (waypoint.ChangeReponse() || waypoint.SearchReponse())
						{
							if (!Information.IsNothing(Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario)))
							{
								waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
								waypoint.SpeedFixed = Waypoint.FixedFree.Free;
								if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
								{
									waypoint.DesiredSpeed = Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
								}
								else
								{
									waypoint.DesiredSpeed = Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
								}
								waypoint.DesiredSpeedOverride = null;
							}
							flag = true;
						}
						bool flag2 = false;
						bool flag3 = false;
						if (waypoint.Type != Waypoint.WaypointType.WeaponTarget && value != Waypoint.WaypointType.WeaponTarget && waypoint.Type != Waypoint.WaypointType.Target && value != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.InitialPoint && value != Waypoint.WaypointType.InitialPoint && waypoint.Type != Waypoint.WaypointType.WeaponLaunch && value != Waypoint.WaypointType.WeaponLaunch)
						{
							if (waypoint.Type == Waypoint.WaypointType.TurningPoint || value == Waypoint.WaypointType.TurningPoint || waypoint.Type == Waypoint.WaypointType.StrikeIngress || value == Waypoint.WaypointType.StrikeIngress || waypoint.Type == Waypoint.WaypointType.StrikeEgress || value == Waypoint.WaypointType.StrikeEgress)
							{
								flag3 = true;
							}
						}
						else
						{
							flag2 = true;
						}
						waypoint.Type = value;
						switch (value)
						{
						default:
							if (flag2)
							{
								Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
								flag = true;
							}
							else if (flag3)
							{
								Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
							}
							break;
						case Waypoint.WaypointType.Refuel:
						{
							bool flag4 = false;
							Waypoint[] flightPlan = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan;
							Waypoint[] array = flightPlan;
							foreach (Waypoint waypoint3 in array)
							{
								if (waypoint3.Type != Waypoint.WaypointType.Refuel && !Information.IsNothing(waypoint3.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false)))
								{
									byte? b = (byte?)waypoint3.Doctrine.GetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
									bool? flag5 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
									if (((!flag5) ?? flag5).GetValueOrDefault())
									{
										flag4 = true;
										break;
									}
								}
							}
							if (flag4 && DarkMessageBox.ShowWarning("禁用除加油型航路点以外的所有航路点的空对空加油（AAR）原则？", "AAR Doctrine", DarkDialogButton.YesNo) == DialogResult.Yes)
							{
								flightPlan = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan;
								Waypoint[] array2 = flightPlan;
								foreach (Waypoint waypoint4 in array2)
								{
									if (waypoint4.Type != Waypoint.WaypointType.Refuel)
									{
										waypoint4.Doctrine.SetUseReplenishment(Client.CurrentScenario, bool_0: false, bool_1: false, bool_2: false, bool_3: false, Command_Core.Doctrine._UseUnderwayRefuelAndReplenishment.Never);
									}
								}
							}
							Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
							break;
						}
						case Waypoint.WaypointType.Assemble:
							waypoint.Hold_Time = 600f;
							flag = true;
							break;
						}
						Waypoint waypoint5 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
						if (waypoint5.Type == Waypoint.WaypointType.StationEnd)
						{
							waypoint5.Type = Waypoint.WaypointType.TurningPoint;
							waypoint5.Station_Time = 0f;
							waypoint5.Hold_Time = 0f;
							waypoint5.TimeFixed = Waypoint.FixedFree.Free;
							waypoint5.TurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
							Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
						}
						if (waypoint5.Type == Waypoint.WaypointType.HoldEnd)
						{
							switch (value)
							{
							case Waypoint.WaypointType.StrikeEgress:
								waypoint5.Type = Waypoint.WaypointType.StrikeEgress;
								break;
							default:
								waypoint5.Type = Waypoint.WaypointType.TurningPoint;
								break;
							case Waypoint.WaypointType.StrikeIngress:
								waypoint5.Type = Waypoint.WaypointType.StrikeIngress;
								break;
							}
							waypoint5.Station_Time = 0f;
							waypoint5.Hold_Time = 0f;
							waypoint5.TimeFixed = Waypoint.FixedFree.Free;
							waypoint5.TurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
							Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
							flag = true;
						}
					}
				}
				else if (e.RowIndex < 1)
				{
					Client.FlightPlanEditorWindow.NewPolicy();
					new DarkMessageBox("飞行计划中的第一个航路点不能是开始巡逻航点！").ShowDialog();
				}
				else if (e.RowIndex <= DGV_Waypoints.Rows.Count - 4)
				{
					if (Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Patrol && Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Support && (Client.FlightPlanEditorWindow.SelectedMission.MissionClass != Mission._MissionClass.Strike || !Client.FlightPlanEditorWindow.SelectedFlight.IsEscort))
					{
						Client.FlightPlanEditorWindow.NewPolicy();
						new DarkMessageBox("只有巡逻任务，支援任务和攻击任务护航可以使用巡逻航路点。").ShowDialog();
					}
					else
					{
						Waypoint waypoint6 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
						if (waypoint6.SearchReponse() && !waypoint6.EnableReponse())
						{
							Client.FlightPlanEditorWindow.NewPolicy();
							new DarkMessageBox("开始巡逻航航点后的航点不能是另一个开始巡逻航航点！").ShowDialog();
						}
						else if (waypoint.FlightFormation != Waypoint.Formation.Split && waypoint6.FlightFormation != Waypoint.Formation.Split)
						{
							if (waypoint6.Type != Waypoint.WaypointType.TurningPoint && waypoint6.Type != Waypoint.WaypointType.StrikeIngress && waypoint6.Type != Waypoint.WaypointType.StrikeEgress && waypoint6.Type != Waypoint.WaypointType.StationEnd)
							{
								Client.FlightPlanEditorWindow.NewPolicy();
								new DarkMessageBox("开始巡逻航后的航点将变为Station End航点，并且只能是Turning Point类型。").ShowDialog();
							}
							else
							{
								waypoint.Type = value;
								waypoint.TurnRate_Navigation = Waypoint.TurnRateCategory.HalfStandardRateTurn;
								if (!Information.IsNothing(Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario)))
								{
									waypoint.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Loiter;
									waypoint.SpeedFixed = Waypoint.FixedFree.Fixed;
									if (waypoint.TerrainFollowing && !Information.IsNothing(waypoint.DesiredAltitude_TerrainFollowing))
									{
										waypoint.DesiredSpeed = Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude_TerrainFollowing.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
									}
									else
									{
										waypoint.DesiredSpeed = Client.FlightPlanEditorWindow.SelectedFlight.GetReferenceUnit(Client.CurrentScenario).Kinematics.GetMaximumSpeed(waypoint.DesiredAltitude.Value, (ActiveUnit.Throttle)waypoint.ThrottlePreset, bool_0: false);
									}
									waypoint.DesiredSpeedOverride = null;
								}
								waypoint6.Type = Waypoint.WaypointType.StationEnd;
								Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
								flag = true;
							}
						}
						else
						{
							Client.FlightPlanEditorWindow.NewPolicy();
							new DarkMessageBox("开始巡逻航或Station End航路点不能使用Split结构。将阵型更改为Spread并再次尝试。").ShowDialog();
						}
					}
				}
				else
				{
					Client.FlightPlanEditorWindow.NewPolicy();
					new DarkMessageBox("飞行计划中的最后三个航路点不能是开始巡逻航点！原因：着陆和着陆集结航点都不能作为结束巡逻航点。注意！ 开始巡逻航后的航点自动变为结束巡逻航点。").ShowDialog();
				}
				if (waypoint.Type != Waypoint.WaypointType.Assemble && waypoint.Type != Waypoint.WaypointType.HoldEnd)
				{
					if (waypoint.Hold_Time > 0f)
					{
						waypoint.Hold_Time = 0f;
						Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
						flag = true;
					}
				}
				else
				{
					Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
					flag = true;
				}
				if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
				{
					waypoint.Waypoint_LeadElementWingman.Type = waypoint.Type;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
				{
					waypoint.Waypoint_SecondElement.Type = waypoint.Type;
				}
				if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
				{
					waypoint.Waypoint_SecondElementWingman.Type = waypoint.Type;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
				{
					waypoint.Waypoint_ThirdElement.Type = waypoint.Type;
				}
				if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
				{
					waypoint.Waypoint_ThirdElementWingman.Type = waypoint.Type;
				}
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_Waypoints.Columns["Formation"].Index)
			{
				DataGridViewCell dataGridViewCell2 = DGV_Waypoints[e.ColumnIndex, e.RowIndex];
				object object_2 = RuntimeHelpers.GetObjectValue(dataGridViewCell2.Value);
				int? num2 = Waypoint.FormationSelection_To_Formation(ref object_2);
				dataGridViewCell2.Value = RuntimeHelpers.GetObjectValue(object_2);
				Waypoint.Formation value2 = (Waypoint.Formation)num2.Value;
				if (value2 == Waypoint.Formation.Split && waypoint.IncludeReponse())
				{
					Client.FlightPlanEditorWindow.NewPolicy();
					new DarkMessageBox("巡逻航点无法设置为拆分编队。").ShowDialog();
				}
				else if (value2 == Waypoint.Formation.Split && waypoint.ConcatReponse())
				{
					Client.FlightPlanEditorWindow.NewPolicy();
					new DarkMessageBox("警戒和集合航点无法设置为拆分编队。").ShowDialog();
				}
				else if (value2 == Waypoint.Formation.Split && e.RowIndex <= 1)
				{
					Client.FlightPlanEditorWindow.NewPolicy();
					new DarkMessageBox("飞行计划中的前两个航路点不能设置为拆分编队。").ShowDialog();
				}
				else if (value2 == Waypoint.Formation.Split && e.RowIndex >= DGV_Waypoints.Rows.Count - 1)
				{
					Client.FlightPlanEditorWindow.NewPolicy();
					new DarkMessageBox("飞行计划中的最后一个航路点不能设置为拆分编队。").ShowDialog();
				}
				else if (value2 == Waypoint.Formation.Split && waypoint.Type == Waypoint.WaypointType.LandingMarshal)
				{
					Client.FlightPlanEditorWindow.NewPolicy();
					new DarkMessageBox("着陆集合航路点不能设置为拆分编队。").ShowDialog();
				}
				else
				{
					if (e.RowIndex > 0 && e.RowIndex < Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan.Count() - 2)
					{
						waypoint.FlightFormation = value2;
						Waypoint waypoint_ = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex - 1];
						Waypoint waypoint_2 = Client.FlightPlanEditorWindow.SelectedFlight.FlightPlan[e.RowIndex + 1];
						if (waypoint.FlightFormation == Waypoint.Formation.Split)
						{
							Scenario scenario_ = Client.CurrentScenario;
							waypoint.SplitWaypoint(ref scenario_, ref Client.FlightPlanEditorWindow.SelectedFlight.DesiredAircraftQty, ref waypoint_, ref waypoint_2, bool_0: true);
						}
						else
						{
							waypoint.FormateWaypoint(ref waypoint_, ref waypoint_2);
						}
					}
					else
					{
						waypoint.FlightFormation = Waypoint.Formation.Spread;
						Waypoint waypoint_3 = null;
						Waypoint waypoint_4 = null;
						waypoint.FormateWaypoint(ref waypoint_3, ref waypoint_4);
						new DarkMessageBox("飞行计划中的第一个航路点或最后两个航路点无法拆分。").ShowDialog();
					}
					Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: true, bool_4: false);
					flag = true;
				}
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_Waypoints.Columns["TurnRate"].Index)
			{
				DataGridViewCell dataGridViewCell3 = DGV_Waypoints[e.ColumnIndex, e.RowIndex];
				object object_3 = RuntimeHelpers.GetObjectValue(dataGridViewCell3.Value);
				int? num3 = Waypoint.TurnRateSelection_To_TurnRate(ref object_3);
				dataGridViewCell3.Value = RuntimeHelpers.GetObjectValue(object_3);
				waypoint.TurnRate_Navigation = (Waypoint.TurnRateCategory)num3.Value;
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: true, bool_3: false, bool_4: false);
				flag = true;
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_Waypoints.Columns["AARUsage"].Index)
			{
				Doctrine doctrine = waypoint.Doctrine;
				int int_ = Conversions.ToInteger(DGV_Waypoints[e.ColumnIndex, e.RowIndex].Value);
				Scenario scenario_2 = Client.CurrentScenario;
				int int_2 = 0;
				doctrine.SelectionChanged_Combo_UseRefuel(int_, ref scenario_2, ref int_2, bool_0: false, bool_1: false, bool_2: false);
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_Waypoints.Columns["AARSelection"].Index)
			{
				Doctrine doctrine2 = waypoint.Doctrine;
				int int_3 = Conversions.ToInteger(DGV_Waypoints[e.ColumnIndex, e.RowIndex].Value);
				Scenario scenario_3 = Client.CurrentScenario;
				int int_4 = 0;
				doctrine2.SelectionChanged_Combo_ReplenishmentSelection(int_3, ref scenario_3, ref int_4, bool_0: false, bool_1: false, bool_2: false);
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: true, bool_1: true, bool_2: false, bool_3: false, bool_4: false);
			}
			if (e.RowIndex != -1 && e.ColumnIndex == DGV_Waypoints.Columns["SpeedToT"].Index)
			{
				DataGridViewCell dataGridViewCell4 = DGV_Waypoints[e.ColumnIndex, e.RowIndex];
				object object_4 = RuntimeHelpers.GetObjectValue(dataGridViewCell4.Value);
				int? num4 = Waypoint.SpeedToTSelection_To_SpeedToT(ref object_4);
				dataGridViewCell4.Value = RuntimeHelpers.GetObjectValue(object_4);
				waypoint.SpeedAdjustmentToT = (Waypoint.SpeedToT)num4.Value;
			}
			DisplayLocks();
			EnableAndDisableCells();
			EnableAndDisableButtons();
			if (flag && Client.AirTaskingOrderWindow.Visible)
			{
				Client.AirTaskingOrderWindow.RefreshWindow();
				Client.AirTaskingOrderWindow.EnableAndDisableButtons();
			}
			Client.FlightPlanEditorWindow.WaypointList_Refresh = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void PopAlgo(object sender, EventArgs e)
	{
		if (Client.FlightPlanEditorWindow.WaypointList_Refresh)
		{
			_ = DGV_Waypoints.SelectedRows.Count;
		}
	}

	private void InstantiateAlgo(object sender, EventArgs e)
	{
		try
		{
			bool bool_ = !Information.IsNothing(Client.FlightPlanEditorWindow.SelectedMission) && Client.FlightPlanEditorWindow.SelectedMission.Category == Mission.MissionCategory.Package;
			if (Information.IsNothing(Client.FlightPlanEditorWindow.SelectedMission) || Client.FlightPlanEditorWindow.SelectedMission.Category != Mission.MissionCategory.Package || DarkMessageBox.ShowWarning("任务包中的飞行计划应始终设置航点时间！您确定要清除航点时间吗？", "Confirm", DarkDialogButton.OkCancel) != DialogResult.Cancel)
			{
				AirTaskingOrder.ClearFlightTime(Client.FlightPlanEditorWindow.SelectedFlight, bool_);
				Client.FlightPlanEditorWindow.RecalculateFlightPlanFuelAndTimes(bool_0: false, bool_1: true, bool_2: false, bool_3: false, bool_4: true);
				EnableAndDisableCells();
				EnableAndDisableButtons();
				RegistryParameterMessage.AwakeCustomer();
				Client.MustRefreshMainForm = true;
				if (Client.AirTaskingOrderWindow.Visible)
				{
					Client.AirTaskingOrderWindow.LoadWindow();
				}
				FlightPlanTime flightPlanTimeWindow = Client.FlightPlanTimeWindow;
				Mission mission_ = null;
				Mission.Flight flight_ = null;
				Waypoint waypoint_ = null;
				flightPlanTimeWindow.RefreshStats(ref mission_, ref flight_, ref waypoint_, Mission.Flight.FlightElement.None, bool_0: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void CreateAlgo(object sender, EventArgs e)
	{
		try
		{
			new DarkMessageBox("Not yet, sorry!").ShowDialog();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
