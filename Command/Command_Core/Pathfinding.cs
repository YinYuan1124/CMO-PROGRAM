using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class Pathfinding
{
	[CompilerGenerated]
	[AccessedThroughProperty("BW1")]
	private static BackgroundWorker utilsConsumer;

	internal static PFCache_Array _PredicateConsumer;

	private static MemoryCache singletonConsumer;

	private static List<PathfindRequest> m_RecordConsumer;

	[CompilerGenerated]
	private static bool exceptionConsumer;

	internal static GInterface8 _AttrConsumer;

	internal static GInterface8 visitorConsumer;

	internal static GInterface8 exporterConsumer;

	private static string m_PrototypeConsumer;

	public static ConcurrentDictionary<string, ActiveUnit> CurrentRequests;

	private static object m_ComparatorConsumer;

	private static AutoResetEvent itemConsumer;

	public static bool PFQueueIsBeingProcessed
	{
		get
		{
			return exceptionConsumer;
		}
		set
		{
			smethod_0(value);
		}
	}

	public static bool PFRequestsPending => m_RecordConsumer.Count > 0;

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private static void FillStub(BackgroundWorker backgroundWorker_0)
	{
		DoWorkEventHandler value = ConcatStub;
		BackgroundWorker backgroundWorker = utilsConsumer;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
		}
		utilsConsumer = backgroundWorker_0;
		backgroundWorker = utilsConsumer;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
		}
	}

	static Pathfinding()
	{
		FillStub(new BackgroundWorker());
		singletonConsumer = MemoryCache.Default;
		m_RecordConsumer = new List<PathfindRequest>();
		m_PrototypeConsumer = "";
		CurrentRequests = new ConcurrentDictionary<string, ActiveUnit>();
		m_ComparatorConsumer = RuntimeHelpers.GetObjectValue(new object());
		itemConsumer = new AutoResetEvent(initialState: false);
	}

	[SpecialName]
	[CompilerGenerated]
	private static void smethod_0(bool bool_0)
	{
		exceptionConsumer = bool_0;
	}

	public static void Initialize()
	{
		if (!utilsConsumer.IsBusy)
		{
			utilsConsumer.RunWorkerAsync();
		}
		_AttrConsumer = new SettlersEnginePathfinder();
		visitorConsumer = new CostBasedPathfinder();
		exporterConsumer = new GroundCostBasedPathfinder();
	}

	public static void LoadIntervalElevations()
	{
		if (!utilsConsumer.IsBusy)
		{
			utilsConsumer.RunWorkerAsync();
		}
	}

	private static void ConcatStub(object sender, CancelEventArgs e)
	{
		_PredicateConsumer = new PFCache_Array();
		while (!utilsConsumer.CancellationPending)
		{
			if (m_RecordConsumer.Count <= 0)
			{
				itemConsumer.WaitOne();
				continue;
			}
			try
			{
				smethod_0(bool_0: true);
				while (m_RecordConsumer.Count > 0)
				{
					PathfindRequest pathfindRequest = null;
					m_PrototypeConsumer = "";
					object comparatorConsumer = m_ComparatorConsumer;
					ObjectFlowControl.CheckForSyncLockOnValueType(comparatorConsumer);
					bool lockTaken = false;
					try
					{
						Monitor.Enter(comparatorConsumer, ref lockTaken);
						if (m_RecordConsumer.Count > 0)
						{
							m_RecordConsumer.Sort((PathfindRequest i1, PathfindRequest i2) => (i1 == null) ? ((i2 != null) ? (-1) : 0) : ((i2 == null) ? 1 : (i1.Distance - i1.Age - (i2.Distance - i2.Age))));
							pathfindRequest = m_RecordConsumer[0];
							m_RecordConsumer.RemoveAt(0);
							int num = m_RecordConsumer.Count - 1;
							for (int j = 0; j <= num; j++)
							{
								if (m_RecordConsumer[j] != null)
								{
									m_RecordConsumer[j].Age = m_RecordConsumer[j].Age + 10;
								}
							}
						}
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(comparatorConsumer);
						}
					}
					if (pathfindRequest == null || ((pathfindRequest.theUnit == null || pathfindRequest.theUnit.IsDestroyed) && pathfindRequest.theFlightPlan == null))
					{
						continue;
					}
					try
					{
						if (pathfindRequest.theUnit == null)
						{
							if (!Information.IsNothing(pathfindRequest.theFlightPlan) && !Information.IsNothing(pathfindRequest.theFlightPlan.GetReferenceUnit(pathfindRequest.theScenario)))
							{
								pathfindRequest.theFlightPlan.GetReferenceUnit(pathfindRequest.theScenario).Navigator.StartPathfinding(pathfindRequest.StartWP, null, pathfindRequest.theFlightPlan, pathfindRequest.theFlightPlanIngressPath, pathfindRequest.ProximityThreshold_Deg, pathfindRequest.DestLat, pathfindRequest.DestLon, pathfindRequest.theScenario, pathfindRequest.ManouverTowardsTarget);
								m_PrototypeConsumer = "攻击任务飞行计划";
							}
							continue;
						}
						if (!CurrentRequests.ContainsKey(pathfindRequest.theUnit.ObjectID))
						{
							CurrentRequests.TryAdd(pathfindRequest.theUnit.ObjectID, pathfindRequest.theUnit);
						}
						if (pathfindRequest.theUnit == null)
						{
							m_PrototypeConsumer = "单元已被摧毁";
						}
						else
						{
							m_PrototypeConsumer = pathfindRequest.theUnit.Name;
						}
						pathfindRequest.theUnit.Navigator.StartPathfinding(pathfindRequest.StartWP, pathfindRequest.theUnit, null, bool_1: false, pathfindRequest.ProximityThreshold_Deg, pathfindRequest.DestLat, pathfindRequest.DestLon, pathfindRequest.theScenario, pathfindRequest.ManouverTowardsTarget);
						CurrentRequests.TryRemove(pathfindRequest.theUnit.ObjectID, out pathfindRequest.theUnit);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception exception_ = ex;
						exception_?.Data.Add("Error at 200497", exception_.Message);
						GameGeneral.WriteExceptionsToLog(ref exception_);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				smethod_0(bool_0: false);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception exception_2 = ex2;
				exception_2?.Data.Add("Error at 101110", "");
				GameGeneral.WriteExceptionsToLog(ref exception_2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				smethod_0(bool_0: false);
				ProjectData.ClearProjectError();
			}
		}
		e.Cancel = true;
	}

	public static void ClearAllPathfinderRequests()
	{
		object comparatorConsumer = m_ComparatorConsumer;
		ObjectFlowControl.CheckForSyncLockOnValueType(comparatorConsumer);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(comparatorConsumer, ref lockTaken);
			m_RecordConsumer.Clear();
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(comparatorConsumer);
			}
		}
	}

	public static void SubmitPathfindRequest(PathfindRequest pathfindRequest_0, Scenario scenario_0)
	{
		object comparatorConsumer = m_ComparatorConsumer;
		ObjectFlowControl.CheckForSyncLockOnValueType(comparatorConsumer);
		bool lockTaken = false;
		try
		{
			Monitor.Enter(comparatorConsumer, ref lockTaken);
			m_RecordConsumer.Add(pathfindRequest_0);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(comparatorConsumer);
			}
		}
		itemConsumer.Set();
	}

	internal static int InterruptStub()
	{
		return m_RecordConsumer.Count;
	}

	internal static string RemoveStub()
	{
		if (exceptionConsumer)
		{
			return m_PrototypeConsumer;
		}
		return null;
	}

	public static void CancelPathfindRequests(ActiveUnit activeUnit_0, Mission.Flight flight_0)
	{
		try
		{
			if (activeUnit_0 != null && CurrentRequests.ContainsKey(activeUnit_0.ObjectID))
			{
				activeUnit_0.Navigator.PathFindingAbortNextPath = true;
			}
			else
			{
				if (m_RecordConsumer.Count < 1)
				{
					return;
				}
				object comparatorConsumer = m_ComparatorConsumer;
				ObjectFlowControl.CheckForSyncLockOnValueType(comparatorConsumer);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(comparatorConsumer, ref lockTaken);
					int num = m_RecordConsumer.Count - 1;
					while (true)
					{
						if (num >= 0)
						{
							if (m_RecordConsumer[num] != null && ((activeUnit_0 != null && m_RecordConsumer[num].theUnit == activeUnit_0) || (flight_0 != null && m_RecordConsumer[num].theFlightPlan == flight_0)))
							{
								break;
							}
							num += -1;
							continue;
						}
						return;
					}
					m_RecordConsumer.RemoveAt(num);
					return;
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(comparatorConsumer);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200342", exception_.Message);
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal static bool FindStub(ActiveUnit activeunit, object object_0, ref Exception exception_0)
	{
		bool result;
		try
		{
			if (activeunit == null)
			{
				result = false;
			}
			else if (CurrentRequests.ContainsKey(((ScenarioObject)activeunit).ObjectID))
			{
				result = true;
			}
			else if (m_RecordConsumer.Count < 1)
			{
				result = false;
			}
			else
			{
				object comparatorConsumer = m_ComparatorConsumer;
				ObjectFlowControl.CheckForSyncLockOnValueType(comparatorConsumer);
				lock (comparatorConsumer)
				{
					for (int i = m_RecordConsumer.Count - 1; i >= 0; i += -1)
					{
						if (m_RecordConsumer[i] != null && ((activeunit != null && m_RecordConsumer[i].theUnit == (ScenarioObject)activeunit) || (object_0 != null && m_RecordConsumer[i].theFlightPlan == object_0)))
						{
							return true;
						}
					}
				}
				result = false;
			}
		}
		catch (Exception ex)
		{
			ex?.Data.Add("Error at 200335", ex.Message);
			GameGeneral.WriteExceptionsToLog(ref ex);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = true;
		}
		return result;
	}

	public static void ProcessRequests(ref Scenario scenario_0)
	{
		throw new NotImplementedException();
	}
}
