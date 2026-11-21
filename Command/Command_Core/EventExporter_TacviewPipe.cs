using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class EventExporter_TacviewPipe : EventExporter_Tacview2x
{
	public delegate void PipeTelemetryToTacviewEventHandler(List<Tuple<string, IEventExporter.EventExportNotification>> tupleList);

	public bool PipeClientsPresent;

	private ConcurrentQueue<Tuple<string, IEventExporter.EventExportNotification>> m_TokenClient;

	private Thread indexerClient;

	private Scenario _ResolverClient;

	public Dictionary<string, long> DeclaredUnits;

	private object publisherClient;

	private bool Enabled;

	[CompilerGenerated]
	private PipeTelemetryToTacviewEventHandler _ServerClient;

	public override bool IsOperating
	{
		get
		{
			return Enabled;
		}
		set
		{
			Enabled = value;
		}
	}

	public override int QueueLength => m_TokenClient.Count;

	public override string Name => "TacviewPipe";

	public override IEventExporter.EventExporterType ExporterType => IEventExporter.EventExporterType.TacviewPipe;

	public event PipeTelemetryToTacviewEventHandler PipeTelemetryToTacview
	{
		[CompilerGenerated]
		add
		{
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler = _ServerClient;
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler2;
			do
			{
				pipeTelemetryToTacviewEventHandler2 = pipeTelemetryToTacviewEventHandler;
				PipeTelemetryToTacviewEventHandler value2 = (PipeTelemetryToTacviewEventHandler)Delegate.Combine(pipeTelemetryToTacviewEventHandler2, value);
				pipeTelemetryToTacviewEventHandler = Interlocked.CompareExchange(ref _ServerClient, value2, pipeTelemetryToTacviewEventHandler2);
			}
			while ((object)pipeTelemetryToTacviewEventHandler != pipeTelemetryToTacviewEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler = _ServerClient;
			PipeTelemetryToTacviewEventHandler pipeTelemetryToTacviewEventHandler2;
			do
			{
				pipeTelemetryToTacviewEventHandler2 = pipeTelemetryToTacviewEventHandler;
				PipeTelemetryToTacviewEventHandler value2 = (PipeTelemetryToTacviewEventHandler)Delegate.Remove(pipeTelemetryToTacviewEventHandler2, value);
				pipeTelemetryToTacviewEventHandler = Interlocked.CompareExchange(ref _ServerClient, value2, pipeTelemetryToTacviewEventHandler2);
			}
			while ((object)pipeTelemetryToTacviewEventHandler != pipeTelemetryToTacviewEventHandler2);
		}
	}

	public void DestroyCache()
	{
		object obj = publisherClient;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			m_TokenClient = new ConcurrentQueue<Tuple<string, IEventExporter.EventExportNotification>>();
			DeclaredUnits = new Dictionary<string, long>();
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	public EventExporter_TacviewPipe(IEventExporter.EventExporterRunMode eventExporterRunMode_0)
		: base(eventExporterRunMode_0, null)
	{
		m_TokenClient = new ConcurrentQueue<Tuple<string, IEventExporter.EventExportNotification>>();
		DeclaredUnits = new Dictionary<string, long>();
		publisherClient = RuntimeHelpers.GetObjectValue(new object());
		base.ExportEngagementCycle = false;
	}

	public override void Start()
	{
		object obj = publisherClient;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			if (indexerClient == null)
			{
				indexerClient = new Thread(CalcRepository);
				indexerClient.Name = "EventExporter_TacviewPipe Thread";
				indexerClient.Priority = ThreadPriority.Normal;
				indexerClient.Start();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private void CalcRepository()
	{
		while (true)
		{
			RateRepository();
			Thread.Sleep(50);
		}
	}

	public override void ExportEvent(IEventExporter.ExportedEventType exportedEventType_0, Dictionary<string, IEventExporter.EventNotificationParameter> dictionary_0, Scenario scenario_0)
	{
		if (PipeClientsPresent && ((exportedEventType_0 != IEventExporter.ExportedEventType.UnitPositions && exportedEventType_0 != IEventExporter.ExportedEventType.ContactPositions) || scenario_0.Time.Second % scenario_0.TimeCompression_SimSeconds == 0))
		{
			IEventExporter.EventExportNotification eventExportNotification = new IEventExporter.EventExportNotification();
			eventExportNotification.EventType = exportedEventType_0;
			eventExportNotification.EventParameters = dictionary_0;
			eventExportNotification.ParentScen = scenario_0;
			string eventString = EventExporter_Tacview2x.GetEventString(eventExportNotification, DeclaredUnits, ref LastPrintedTimeString, NewUnitCache);
			m_TokenClient.Enqueue(new Tuple<string, IEventExporter.EventExportNotification>(eventString, eventExportNotification));
		}
	}

	private void RateRepository()
	{
		try
		{
			List<Tuple<string, IEventExporter.EventExportNotification>> list = new List<Tuple<string, IEventExporter.EventExportNotification>>(m_TokenClient.Count * 2);
			while (m_TokenClient.Count > 0)
			{
				m_TokenClient.TryDequeue(out var result);
				list.Add(result);
			}
			if (list.Any())
			{
				_ServerClient?.Invoke(list);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void StopCleanUpAndReset()
	{
		object obj = publisherClient;
		ObjectFlowControl.CheckForSyncLockOnValueType(obj);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(obj, ref lockTaken);
			Debugger.Break();
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	public override void SetScenario(Scenario scenario_0)
	{
		int num = scenario_0.ActiveUnits_List.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (!scenario_0.ActiveUnits_List.ElementAt(i).IsGroup)
			{
				scenario_0.ActiveUnits_List.ElementAt(i).Kinematics.ExportLocationEvent(bool_0: true);
			}
		}
		_ResolverClient = scenario_0;
	}
}
