using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public class ActiveUnit_AirOps
{
	[CompilerGenerated]
	private sealed class ConsumerComparator
	{
		public ActiveUnit_AirOps _003C_003E4__this;

		public TList<Aircraft> tList;

		internal void RunInterruptibleMock(ActiveUnit theUnit)
		{
			if (theUnit == null || !theUnit.IsAircraft || !theUnit.IsOperating())
			{
				return;
			}
			Aircraft_AirOps airOps = ((Aircraft)theUnit).AirOps;
			if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)
			{
				if (airOps.ActualDestinationHost != null && airOps.ActualDestinationHost == _003C_003E4__this.myUnit)
				{
					tList.Add((Aircraft)theUnit);
				}
				else if ((airOps.ActualDestinationHost == null || airOps.ActualDestinationHost == _003C_003E4__this.myUnit) && airOps.GetAssignedHostUnit(bool_0: true) == _003C_003E4__this.myUnit)
				{
					tList.Add((Aircraft)theUnit);
				}
			}
		}
	}

	protected ActiveUnit myUnit;

	protected Aircraft[] _LandingQueue;

	protected string[] _LandingQueue_IDs;

	protected bool HasBeenReadied;

	public virtual GlobalVariables.RunwayLengthClass LongestRunwayLengthClass
	{
		get
		{
			try
			{
				GlobalVariables.RunwayLengthClass runwayLengthClass = GlobalVariables.RunwayLengthClass.None;
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array = airFacilities_ReadOnly;
				foreach (AirFacility airFacility in array)
				{
					if (airFacility.RunwayLength > runwayLengthClass)
					{
						runwayLengthClass = airFacility.RunwayLength;
					}
				}
				return runwayLengthClass;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100074", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return GlobalVariables.RunwayLengthClass.None;
			}
		}
	}

	public virtual GlobalVariables.AircraftSizeClass LargestAircraftSizeForTOL
	{
		get
		{
			try
			{
				GlobalVariables.AircraftSizeClass aircraftSizeClass = GlobalVariables.AircraftSizeClass.None;
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array = airFacilities_ReadOnly;
				foreach (AirFacility airFacility in array)
				{
					if ((airFacility.DefineReader() || airFacility.AwakeReader()) && (int)airFacility.MaxAircraftSize > (int)aircraftSizeClass)
					{
						aircraftSizeClass = airFacility.MaxAircraftSize;
					}
				}
				return aircraftSizeClass;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100075", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return GlobalVariables.AircraftSizeClass.None;
			}
		}
	}

	public virtual List<Aircraft> EmbarkedAircraft_ReadOnly
	{
		get
		{
			try
			{
				List<Aircraft> list = new List<Aircraft>();
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				for (int i = 0; i < airFacilities_ReadOnly.Length; i++)
				{
					foreach (Aircraft value in airFacilities_ReadOnly[i].HostedAircraft.Values)
					{
						list.Add(value);
					}
				}
				return list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100076", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				List<Aircraft> result = new List<Aircraft>();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public virtual ReadOnlyCollection<Aircraft> AssignedAircraft
	{
		get
		{
			try
			{
				List<Aircraft> list = new List<Aircraft>();
				foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
				{
					if (!Information.IsNothing(activeUnits_) && activeUnits_.IsAircraft && ((Aircraft)activeUnits_).AirOps.GetAssignedHostUnit(bool_0: true) == myUnit)
					{
						list.Add((Aircraft)activeUnits_);
					}
				}
				return list.AsReadOnly();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100082", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ReadOnlyCollection<Aircraft> result = new List<Aircraft>().AsReadOnly();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public IEnumerable<Aircraft> ReadyAircraft
	{
		get
		{
			try
			{
				return EmbarkedAircraft_ReadOnly.Where(delegate(Aircraft AC)
				{
					if (AC.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Parked && AC.AirOps.ConditionTimer == 0f)
					{
						string string_ = null;
						return AC.IsAvailableForOps(ref string_) != Aircraft_AirOps.AirOpsAvailabilityStatus.IsUnderMaintenance;
					}
					return false;
				}).AsEnumerable();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100083", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				IEnumerable<Aircraft> result = new List<Aircraft>().AsEnumerable();
				ProjectData.ClearProjectError();
				return result;
			}
		}
	}

	public Aircraft[] LandingQueue_ReadOnly => _LandingQueue;

	public Geopoint_Struct LandingQueueAssemblyPoint
	{
		get
		{
			try
			{
				float float_ = Math2.UpdateClass(myUnit.CurrentHeading + 180f);
				Geopoint_Struct result = default(Geopoint_Struct);
				Geodesic_EdWilliams.CalcPoint_Williams(myUnit.GetLongitude(), myUnit.GetLatitude(), ref result.Longitude, ref result.Latitude, DistanceToLandingQueueAssemblyPoint, float_);
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100084", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Geopoint_Struct result2 = new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude(), 0f);
				ProjectData.ClearProjectError();
				return result2;
			}
		}
	}

	public float DistanceToLandingQueueAssemblyPoint => 10f;

	public virtual void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("ActiveUnit_AirOps");
			if (_LandingQueue.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("LandingQueue");
				Aircraft[] landingQueue = _LandingQueue;
				Aircraft[] array = landingQueue;
				foreach (Aircraft aircraft in array)
				{
					if (!Information.IsNothing(aircraft))
					{
						xmlWriter_0.WriteElementString("ID", aircraft.ObjectID);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100071", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_AirOps FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			ActiveUnit_AirOps activeUnit_AirOps = new ActiveUnit_AirOps();
			activeUnit_AirOps.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					if (Operators.CompareString(xmlNode.Name, "LandingQueue", TextCompare: false) != 0)
					{
						continue;
					}
					try
					{
						enumerator2 = xmlNode.ChildNodes.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
							ArrayExtensions.Add(ref activeUnit_AirOps._LandingQueue_IDs, xmlNode2.InnerText);
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
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
			return activeUnit_AirOps;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100072", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ActiveUnit_AirOps result = new ActiveUnit_AirOps();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public virtual void PostDeserializationHousekeeping(ref Scenario scenario_0, ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, bool bool_0)
	{
		string[] landingQueue_IDs = _LandingQueue_IDs;
		string[] array = landingQueue_IDs;
		foreach (string text in array)
		{
			try
			{
				if (!Information.IsNothing(text))
				{
					Aircraft theAC = (Aircraft)scenario_0.ActiveUnits[text];
					ArrayExtensions.Add(ref _LandingQueue, theAC);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception_ = ex;
				exception_?.Data.Add("Error at 100073", "");
				GameGeneral.WriteExceptionsToLog(ref exception_);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private ActiveUnit_AirOps()
	{
		_LandingQueue = new Aircraft[0];
		_LandingQueue_IDs = new string[0];
	}

	internal List<Aircraft> ResetClient()
	{
		TList<Aircraft> tList = new TList<Aircraft>();
		List<ActiveUnit> activeUnits_List = myUnit.ParentScen.ActiveUnits_List;
		try
		{
			if (activeUnits_List == null)
			{
				return new List<Aircraft>();
			}
			Parallel.ForEach(activeUnits_List, delegate(ActiveUnit theUnit)
			{
				if (theUnit != null && theUnit.IsAircraft && theUnit.IsOperating())
				{
					Aircraft_AirOps airOps = ((Aircraft)theUnit).AirOps;
					if (airOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PreTouchdown)
					{
						if (airOps.ActualDestinationHost != null && airOps.ActualDestinationHost == myUnit)
						{
							tList.Add((Aircraft)theUnit);
						}
						else if ((airOps.ActualDestinationHost == null || airOps.ActualDestinationHost == myUnit) && airOps.GetAssignedHostUnit(bool_0: true) == myUnit)
						{
							tList.Add((Aircraft)theUnit);
						}
					}
				}
			});
			return tList.ToList();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100077", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			List<Aircraft> result = new List<Aircraft>();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal ReadOnlyCollection<AirFacility> MapClient(bool? nullable_0, Aircraft aircraft_0, ActiveUnit activeUnit_0, IEnumerable<AirFacility> ienumerable_0)
	{
		try
		{
			if (ienumerable_0.Count() == 0)
			{
				return null;
			}
			DateTime time = activeUnit_0.ParentScen.Time;
			List<AirFacility> list = new List<AirFacility>();
			foreach (AirFacility item in ienumerable_0)
			{
				if ((int)aircraft_0.Size > (int)item.MaxAircraftSize)
				{
					continue;
				}
				int num = 0;
				num = ((item.AirFacType == AirFacility._AirFacType.Elevator) ? item.Capacity : ((aircraft_0.Size == item.MaxAircraftSize) ? 1 : ((aircraft_0.Type != Aircraft._AircraftType.Fighter && aircraft_0.Type != Aircraft._AircraftType.Attack && aircraft_0.Type != Aircraft._AircraftType.Multirole && aircraft_0.Type != Aircraft._AircraftType.OECM && aircraft_0.Type != Aircraft._AircraftType.WildWeasel && aircraft_0.Type != Aircraft._AircraftType.Trainer && aircraft_0.Type != Aircraft._AircraftType.Recon) ? 1 : ((SunModule.CollectSpecification(activeUnit_0.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, bool_0: true, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), 0.0) != 0) ? 1 : 2))));
				if (Information.IsNothing(nullable_0))
				{
					foreach (Aircraft value in item.HostedAircraft.Values)
					{
						if (value.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff && value.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToPark)
						{
							num--;
							if (num == 0)
							{
								break;
							}
							continue;
						}
						num = 0;
						break;
					}
				}
				else if (((!nullable_0) ?? nullable_0).GetValueOrDefault())
				{
					foreach (Aircraft value2 in item.HostedAircraft.Values)
					{
						if (value2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff && value2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
						{
							if (aircraft_0.DBID == value2.DBID || item.AirFacType == AirFacility._AirFacType.Elevator)
							{
								num--;
								if (num == 0)
								{
									break;
								}
								continue;
							}
							num = 0;
							break;
						}
						num = 0;
						break;
					}
				}
				else
				{
					foreach (Aircraft value3 in item.HostedAircraft.Values)
					{
						if (value3.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToPark && value3.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
						{
							if (aircraft_0.DBID == value3.DBID || item.AirFacType == AirFacility._AirFacType.Elevator)
							{
								num--;
								if (num == 0)
								{
									break;
								}
								continue;
							}
							num = 0;
							break;
						}
						num = 0;
						break;
					}
				}
				if (num > 0)
				{
					list.Add(item);
				}
			}
			return list.AsReadOnly();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100078", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ReadOnlyCollection<AirFacility> result = new List<AirFacility>().AsReadOnly();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[SpecialName]
	public IEnumerable<AirFacility> GetRunwayAccessPointsInOperationOnMe_myUnitSize(ActiveUnit activeUnit_0)
	{
		try
		{
			List<AirFacility> list = new List<AirFacility>();
			AirFacility[] airFacilities_ReadOnly = activeUnit_0.AirFacilities_ReadOnly;
			AirFacility[] array = airFacilities_ReadOnly;
			foreach (AirFacility airFacility in array)
			{
				if (airFacility.ResetReader() && airFacility.Status == PlatformComponent._ComponentStatus.Operational && airFacility.ResetReader())
				{
					list.Add(airFacility);
				}
			}
			return list.AsReadOnly();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100079", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ReadOnlyCollection<AirFacility> result = new List<AirFacility>().AsReadOnly();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	internal ReadOnlyCollection<AirFacility> SortClient(bool bool_0, bool bool_1, Aircraft aircraft_0, ActiveUnit activeUnit_0, bool bool_2, IEnumerable<AirFacility> ienumerable_0)
	{
		if (ienumerable_0.Count() == 0)
		{
			return null;
		}
		DateTime time = activeUnit_0.ParentScen.Time;
		try
		{
			List<AirFacility> list = new List<AirFacility>();
			List<Aircraft> list2 = new List<Aircraft>();
			if (!bool_1)
			{
				foreach (Aircraft item in activeUnit_0.AirOps.ResetClient())
				{
					list2.Add(item);
				}
			}
			foreach (AirFacility item2 in ienumerable_0)
			{
				if (item2.AirFacType == AirFacility._AirFacType.const_13 && (aircraft_0.Type == Aircraft._AircraftType.UAV || aircraft_0.Type == Aircraft._AircraftType.UCAV))
				{
					list.Add(item2);
				}
				else
				{
					if ((int)aircraft_0.Size > (int)item2.MaxAircraftSize)
					{
						continue;
					}
					int num = 0;
					num = ((item2.AirFacType != AirFacility._AirFacType.Runway) ? 1 : ((aircraft_0.Size == item2.EffectiveRunwaySize) ? 1 : ((aircraft_0.Type != Aircraft._AircraftType.Fighter && aircraft_0.Type != Aircraft._AircraftType.Attack && aircraft_0.Type != Aircraft._AircraftType.Multirole && aircraft_0.Type != Aircraft._AircraftType.OECM && aircraft_0.Type != Aircraft._AircraftType.WildWeasel && aircraft_0.Type != Aircraft._AircraftType.Trainer && aircraft_0.Type != Aircraft._AircraftType.Recon) ? 1 : ((SunModule.CollectSpecification(activeUnit_0.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, bool_0: true, activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude(), 0.0) != 0) ? 1 : 2))));
					if (item2.AirFacType == AirFacility._AirFacType.OpenParking)
					{
						list.Add(item2);
						continue;
					}
					if (bool_1)
					{
						foreach (Aircraft value in item2.HostedAircraft.Values)
						{
							if (value.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.TakingOff)
							{
								if (aircraft_0.DBID == value.DBID)
								{
									num--;
									if (num == 0)
									{
										break;
									}
								}
								else if (((Aircraft)myUnit).AirOps.RestartProxy(item2, bool_0: true) == AirOpsAttemptResult.Success)
								{
									num = 0;
									break;
								}
								continue;
							}
							num = 0;
							break;
						}
					}
					else if (bool_0)
					{
						foreach (Aircraft value2 in item2.HostedAircraft.Values)
						{
							if (value2.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.Landing_PostTouchdown)
							{
								if (aircraft_0.DBID == value2.DBID)
								{
									num--;
									if (num == 0)
									{
										break;
									}
								}
								else if (((Aircraft)myUnit).AirOps.VisitProxy(item2) == Aircraft_AirOps.TakeOffCheck.OK)
								{
									num = 0;
									break;
								}
								continue;
							}
							num = 0;
							break;
						}
					}
					else if (bool_1 || bool_0)
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
					}
					else
					{
						foreach (Aircraft value3 in item2.HostedAircraft.Values)
						{
							if (value3.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TakingOff)
							{
								num = 0;
								break;
							}
						}
						if (list2.Count > 0 && num > 0)
						{
							List<Aircraft> list3 = new List<Aircraft>();
							foreach (Aircraft item3 in list2)
							{
								if (aircraft_0.DBID == item3.DBID)
								{
									list3.Add(item3);
									num--;
									if (num == 0)
									{
										break;
									}
								}
								else if (((Aircraft)myUnit).AirOps.RestartProxy(item2, bool_0: true) == AirOpsAttemptResult.Success)
								{
									list3.Add(item3);
									num = 0;
									break;
								}
							}
							foreach (Aircraft item4 in list3)
							{
								list2.Remove(item4);
							}
						}
					}
					if (num > 0)
					{
						list.Add(item2);
					}
				}
			}
			return list.AsReadOnly();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100080", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ReadOnlyCollection<AirFacility> result = new List<AirFacility>().AsReadOnly();
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public ActiveUnit_AirOps(ref ActiveUnit activeUnit_0)
	{
		_LandingQueue = new Aircraft[0];
		_LandingQueue_IDs = new string[0];
		myUnit = activeUnit_0;
	}

	public void LandingQueue_AddAircraft(Aircraft aircraft_0)
	{
		try
		{
			if (!_LandingQueue.Contains(aircraft_0))
			{
				ArrayExtensions.Add(ref _LandingQueue, aircraft_0);
				aircraft_0.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue;
				aircraft_0.AirOps.ConditionTimer = 5f;
				ReSortLandingQueue();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100085", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void LandingQueue_RemoveAircraft(Aircraft aircraft_0)
	{
		ArrayExtensions.Remove(ref _LandingQueue, aircraft_0);
		ReSortLandingQueue();
	}

	public void LandingQueue_CleanUp()
	{
		try
		{
			if (_LandingQueue.Count() == 0)
			{
				return;
			}
			List<Aircraft> list = new List<Aircraft>();
			list.AddRange(_LandingQueue);
			foreach (Aircraft item in list)
			{
				if (Information.IsNothing(item))
				{
					LandingQueue_RemoveAircraft(item);
				}
				else if (item.IsDestroyed)
				{
					LandingQueue_RemoveAircraft(item);
				}
				if (item.AirOps.Condition != Aircraft_AirOps._AirOpsCondition.HoldingOnLandingQueue)
				{
					LandingQueue_RemoveAircraft(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100086", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public Aircraft HaveAircraftOnTouchdown()
	{
		try
		{
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			for (int i = 0; i < airFacilities_ReadOnly.Length; i++)
			{
				foreach (Aircraft value in airFacilities_ReadOnly[i].HostedAircraft.Values)
				{
					if (value.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Landing_PostTouchdown)
					{
						return value;
					}
				}
			}
			return null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100087", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}

	public void MakeWayForLandings()
	{
		try
		{
			if (myUnit.IsGroup && !myUnit.HasRunwaysOrPads)
			{
				return;
			}
			for (int i = myUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
			{
				AirFacility airFacility = myUnit.AirFacilities_ReadOnly[i];
				if (!airFacility.ResetReader())
				{
					continue;
				}
				foreach (Aircraft value in airFacility.HostedAircraft.Values)
				{
					if (value.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TaxyingToPark)
					{
						return;
					}
				}
			}
			int num = 0;
			for (int j = myUnit.AirFacilities_ReadOnly.Length - 1; j >= 0; j += -1)
			{
				AirFacility airFacility2 = myUnit.AirFacilities_ReadOnly[j];
				if (!airFacility2.ResetReader())
				{
					continue;
				}
				foreach (Aircraft value2 in airFacility2.HostedAircraft.Values)
				{
					if (value2.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff || value2.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.TaxyingToFlightDeck)
					{
						value2.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.TaxyingToPark;
						num++;
						if (num >= airFacility2.HostedAircraft.Values.Count)
						{
							return;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100088", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ReSortLandingQueue()
	{
		if (_LandingQueue.Count() == 0)
		{
			return;
		}
		try
		{
			_LandingQueue = (from theAC in _LandingQueue
				where !Information.IsNothing(theAC)
				orderby theAC.Kinematics.RemainingEndurance()
				select theAC).ToArray();
			Aircraft[] landingQueue = _LandingQueue;
			Aircraft[] array = landingQueue;
			foreach (Aircraft aircraft in array)
			{
				if ((float)aircraft.Kinematics.RemainingEndurance(bool_0: true) < 20f / aircraft.CurrentSpeed * 3600f + 180f)
				{
					aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.EmergencyLanding;
					continue;
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 200113", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool AttemptToRTB(bool bool_0, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_0, bool bool_1, ActiveUnit._ActiveUnitStatus _ActiveUnitStatus_1, bool bool_2, bool bool_3)
	{
		return false;
	}

	public void RepairAC(ref Aircraft aircraft_0)
	{
		int num = aircraft_0.AirOps.CalculateETIC();
		if (num > 0)
		{
			aircraft_0.AddMessage(aircraft_0.Name + " (" + aircraft_0.UnitClass + "）被毁伤，估计需要" + Misc.UpdateRequest(num) + "时间恢复。修理时间将添加到飞机的准备时间。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_0.GetLongitude(), aircraft_0.GetLatitude()));
		}
		aircraft_0.Damage.FireIntensity = ActiveUnit_Damage.FireIntensityLevel.NoFire;
		aircraft_0.SetDamagePts(bool_1: false, null, aircraft_0.InitialDP);
		foreach (PlatformComponent item in aircraft_0.OrderIssuer())
		{
			item.Repair();
		}
		aircraft_0.AirOps.ConditionTimer += num;
	}

	public void RefuelAC_Simple(ref Aircraft aircraft_0)
	{
		try
		{
			foreach (FuelRec item in aircraft_0.Fuel_ReadOnly)
			{
				item.CurrentQuantity = item.MaxQuantity;
			}
			aircraft_0.Kinematics.DetermineReserveFuelQty();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100090", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RefuelAC_Realistic(ref Aircraft aircraft_0)
	{
		try
		{
			foreach (FuelRec item in aircraft_0.Fuel_ReadOnly)
			{
				if (!(item.CurrentQuantity < (float)item.MaxQuantity))
				{
					continue;
				}
				double num = (float)item.MaxQuantity - item.CurrentQuantity;
				foreach (FuelRec item2 in myUnit.Fuel_ReadOnly)
				{
					if (item2.FuelType == item.FuelType)
					{
						if ((double)item2.CurrentQuantity < num)
						{
							item.AddFuel(item2.CurrentQuantity);
							item2.CurrentQuantity = 0f;
						}
						else
						{
							item.CurrentQuantity = item.MaxQuantity;
							item2.CurrentQuantity = (float)((double)item2.CurrentQuantity - num);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100091", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool EnoughOrdnanceInMagazines(ref Aircraft aircraft_0, Loadout loadout_0, int int_0, bool bool_0)
	{
		bool result = true;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		try
		{
			WeaponRec[] weapons = loadout_0.Weapons;
			WeaponRec[] array = weapons;
			foreach (WeaponRec weaponRec in array)
			{
				int int_ = weaponRec.int_0;
				if (Weapon.WeaponIsNonRivalrous(weaponRec.int_0, ref myUnit.ParentScen))
				{
					continue;
				}
				int maxLoad = weaponRec.MaxLoad;
				if (!bool_0 || !weaponRec.OptionalWeapons)
				{
					if (dictionary.ContainsKey(int_))
					{
						dictionary[int_] += maxLoad;
					}
					else
					{
						dictionary.Add(int_, maxLoad);
					}
				}
			}
			foreach (KeyValuePair<int, int> item in dictionary)
			{
				int num = aircraft_0.AirOps.CurrentHostUnit.Weaponry.HowManyOfThisWeaponOnMagazines(item.Key);
				if (item.Value > num)
				{
					result = false;
				}
			}
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100092", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public string OutfitAC(ref Aircraft aircraft_0, int int_0, int int_1, bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4)
	{
		try
		{
			Aircraft_AirOps aircraft_AirOps_ = aircraft_0.AirOps;
			bool flag = false;
			if (!Information.IsNothing(aircraft_0.Loadout))
			{
				if (!Information.IsNothing(aircraft_0.Loadout.Weapons))
				{
					aircraft_AirOps_.UnloadStores();
				}
				if (aircraft_0.Loadout.Weapons.Count() > 0)
				{
					flag = true;
				}
			}
			bool flag2 = true;
			if (int_0 == 0)
			{
				if (bool_0)
				{
					aircraft_AirOps_.ConditionTimer = 0f;
				}
				else
				{
					aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
					if (aircraft_AirOps_.ConditionTimer < 1800f)
					{
						aircraft_AirOps_.ConditionTimer = 1800f;
					}
				}
			}
			else if (!flag)
			{
				aircraft_0.Loadout = null;
				aircraft_0.Weaponry.ClearCachedWeapons();
				if (bool_2)
				{
					Loadout loadout_ = new Loadout(int_0, "tempLoadout", 1, 1, 1, 1, Loadout.LoadoutRole.None, Loadout._LoadoutDayNight.DayOnly, Loadout._LoadoutWeather.None, 0f, 0, 0, bool_0: false, bool_1, bool_2: false, 0, 0, 0, 0, Loadout._LoadoutDayNight.DayNight, Doctrine._WeaponState.LoadoutSetting);
					DBFunctions.GetLoadoutWeapons(ref aircraft_0.ParentScen, ref loadout_, int_0, bool_1);
					if (!EnoughOrdnanceInMagazines(ref aircraft_0, loadout_, int_0, bool_1))
					{
						flag2 = false;
					}
					if (!bool_1 && !flag2)
					{
						bool_1 = true;
						loadout_ = null;
						loadout_ = new Loadout(int_0, "tempLoadout", 1, 1, 1, 1, Loadout.LoadoutRole.None, Loadout._LoadoutDayNight.DayOnly, Loadout._LoadoutWeather.None, 0f, 0, 0, bool_0: false, bool_1: true, bool_2: false, 0, 0, 0, 0, Loadout._LoadoutDayNight.DayNight, Doctrine._WeaponState.LoadoutSetting);
						DBFunctions.GetLoadoutWeapons(ref aircraft_0.ParentScen, ref loadout_, int_0, bool_0: true);
						if (EnoughOrdnanceInMagazines(ref aircraft_0, loadout_, int_0, bool_0: true))
						{
							flag2 = true;
							string text = "";
							if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
							{
								text = " (" + aircraft_0.UnitClass + ")";
							}
							if (bool_3)
							{
								GameGeneral.ResolveBridge("飞机：" + aircraft_0.Name + text + "由于没有足够的武器可以重新装备没有可选武器。", aircraft_0.GetUnitSide());
							}
							aircraft_0.AddMessage("飞机：" + aircraft_0.Name + text + "由于没有足够的武器可以重新装备没有可选武器。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_.CurrentHostUnit.GetLongitude(), aircraft_AirOps_.CurrentHostUnit.GetLatitude()));
						}
						else
						{
							flag2 = false;
						}
					}
					if (flag2)
					{
						WeaponRec[] weapons = loadout_.Weapons;
						WeaponRec[] array = weapons;
						foreach (WeaponRec weaponRec in array)
						{
							int currentLoad = weaponRec.CurrentLoad;
							for (int i = 1; i <= currentLoad; i++)
							{
								if (!Weapon.WeaponIsNonRivalrous(weaponRec.int_0, ref myUnit.ParentScen))
								{
									ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
									int int_2 = weaponRec.int_0;
									float float_ = 0f;
									weaponry.RemoveWeaponFromMagazines(int_2, bool_1: true, ref float_);
								}
							}
						}
					}
				}
			}
			foreach (Mount mount in aircraft_0.Mounts)
			{
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					mountWeapon.CurrentLoad = mountWeapon.MaxLoad;
				}
			}
			if (flag)
			{
				if (aircraft_0.Loadout != null)
				{
					WeaponRec[] weapons2 = aircraft_0.Loadout.Weapons;
					WeaponRec[] array2 = weapons2;
					foreach (WeaponRec weaponRec2 in array2)
					{
						if (weaponRec2.CurrentLoad >= weaponRec2.MaxLoad)
						{
							continue;
						}
						int num = weaponRec2.MaxLoad - weaponRec2.CurrentLoad;
						for (int j = 1; j <= num; j++)
						{
							if (weaponRec2.CurrentLoad >= weaponRec2.MaxLoad)
							{
								continue;
							}
							if (Weapon.WeaponIsNonRivalrous(weaponRec2.int_0, ref myUnit.ParentScen))
							{
								weaponRec2.CurrentLoad++;
								continue;
							}
							ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
							int int_3 = weaponRec2.int_0;
							float float_2 = 0f;
							if (string.CompareOrdinal(weaponry2.RemoveWeaponFromMagazines(int_3, bool_1: true, ref float_2), "OK") == 0)
							{
								weaponRec2.CurrentLoad++;
							}
						}
						flag = false;
					}
				}
			}
			else if (flag2)
			{
				DBFunctions.GetLoadout(ref aircraft_0, int_0, bool_1);
			}
			else
			{
				aircraft_0.Loadout = DBFunctions.GetReserveLoadoutForThisAircraft(ref aircraft_0.ParentScen, aircraft_0.DBID);
				if (Information.IsNothing(aircraft_0.Loadout))
				{
					aircraft_0.Loadout = DBFunctions.GetMaintenanceLoadoutForThisAircraft(ref aircraft_0.ParentScen, aircraft_0.DBID);
				}
				aircraft_AirOps_.UpdateQuickTurnaroundSettings_Reset(ref aircraft_AirOps_);
			}
			if (bool_0)
			{
				aircraft_AirOps_.ConditionTimer = 0f;
			}
			else if (int_0 == int_1 || !aircraft_0.Loadout.SetupClass(aircraft_0.ParentScen, int_1, bool_1))
			{
				if (flag)
				{
					aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
					aircraft_AirOps_.ConditionTimer = 1800f;
				}
				else
				{
					byte? b = (byte?)aircraft_0.Doctrine.GetAirOpsTempo(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
					bool? flag3;
					bool? flag4 = (flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null));
					bool? flag5 = ((flag4.HasValue && !flag3.GetValueOrDefault()) ? new bool?(false) : ((aircraft_AirOps_.ConditionTimer < (float)(aircraft_0.Loadout.ReadyTime * 60)) & flag3));
					if (!(!flag5).GetValueOrDefault() && !aircraft_AirOps_.QuickTurnaround_Enabled && flag5.HasValue)
					{
						if (int_0 != int_1 || !bool_3)
						{
							aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
							aircraft_AirOps_.ConditionTimer = aircraft_0.Loadout.ReadyTime * 60;
						}
					}
					else
					{
						b = (byte?)aircraft_0.Doctrine.GetAirOpsTempo(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						flag4 = (flag3 = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null));
						flag5 = ((flag4.HasValue && !flag3.GetValueOrDefault()) ? new bool?(false) : ((aircraft_AirOps_.ConditionTimer < (float)(aircraft_0.Loadout.ReadyTime_Sustained * 60)) & flag3));
						if (flag5.GetValueOrDefault(true) && !aircraft_AirOps_.QuickTurnaround_Enabled && flag5.HasValue)
						{
							if (int_0 != int_1 || !bool_3)
							{
								aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
								aircraft_AirOps_.ConditionTimer = aircraft_0.Loadout.ReadyTime_Sustained * 60;
							}
						}
						else if (aircraft_AirOps_.QuickTurnaround_Enabled && (int_0 != int_1 || !bool_3))
						{
							b = (byte?)aircraft_0.Doctrine.GetQuickTurnAroundForAicraft(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 2) : null).GetValueOrDefault())
							{
								aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_0);
								string text2 = "";
								if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
								{
									text2 = " (" + aircraft_0.UnitClass + ")";
								}
								aircraft_0.AddMessage(aircraft_0.Name + text2 + "已经飞过了" + Conversions.ToString(aircraft_AirOps_.QuickTurnaround_SortiesFlown) + "的" + Conversions.ToString(aircraft_0.Loadout.QuickTurnaround_MaxSorties) + "架次。总的滞空时间是" + Misc.UpdateRequest((long)Math.Round(aircraft_AirOps_.QuickTurnaround_AirborneTime_Flown)) + "，允许滞空时间是" + Misc.UpdateRequest(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) + "。飞机挂载设置为Quick Turnaround，但是条令设置为No Quick Turnaround，飞机停机！", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_.CurrentHostUnit.GetLongitude(), aircraft_AirOps_.CurrentHostUnit.GetLatitude()));
								b = (byte?)aircraft_0.Doctrine.GetAirOpsTempo(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
								if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
								{
									aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
									aircraft_AirOps_.ConditionTimer = aircraft_0.Loadout.ReadyTime * 60;
								}
								else
								{
									aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
									aircraft_AirOps_.ConditionTimer = aircraft_0.Loadout.ReadyTime_Sustained * 60;
								}
							}
							else if (bool_3)
							{
								if (aircraft_AirOps_.QuickTurnaround_SortiesFlown >= aircraft_0.Loadout.QuickTurnaround_MaxSorties)
								{
									aircraft_AirOps_.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_, ref aircraft_0);
								}
								aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
								if (aircraft_AirOps_.QuickTurnaround_SortiesFlown == 0)
								{
									b = (byte?)aircraft_0.Doctrine.GetAirOpsTempo(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
									if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
									{
										aircraft_AirOps_.ConditionTimer = aircraft_0.Loadout.ReadyTime_Sustained * 60;
									}
									else
									{
										aircraft_AirOps_.ConditionTimer = aircraft_0.Loadout.ReadyTime * 60;
									}
								}
								else
								{
									aircraft_AirOps_.ConditionTimer = aircraft_0.Loadout.QuickTurnaround_ReadyTime * 60;
								}
							}
						}
					}
					if (!bool_3 && aircraft_AirOps_.QuickTurnaround_Enabled)
					{
						b = (byte?)aircraft_0.Doctrine.GetQuickTurnAroundForAicraft(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
						if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
						{
							UpdateQuickTurnaroundParams(ref aircraft_AirOps_, ref aircraft_0);
						}
						else
						{
							b = (byte?)aircraft_0.Doctrine.GetQuickTurnAroundForAicraft(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
							if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
							{
								Loadout loadout = aircraft_0.Loadout;
								if (loadout.IsAAW || loadout.IsSupportOrPatrol || loadout.IsASW)
								{
									UpdateQuickTurnaroundParams(ref aircraft_AirOps_, ref aircraft_0);
								}
							}
						}
					}
				}
			}
			if (!bool_0 && aircraft_AirOps_._ValueObserver > -1f)
			{
				aircraft_AirOps_.ConditionTimer = aircraft_AirOps_._ValueObserver;
			}
			aircraft_AirOps_._ValueObserver = -1f;
			aircraft_0.AirborneTime = 0f;
			if (flag2)
			{
				if (aircraft_AirOps_.ConditionTimer > 0f)
				{
					aircraft_AirOps_.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
				}
				return "OK";
			}
			string text3 = "";
			if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
			{
				text3 = " (" + aircraft_0.UnitClass + ")";
			}
			if (bool_4)
			{
				if (bool_3)
				{
					GameGeneral.ResolveBridge("飞机：" + aircraft_0.Name + text3 + "没有配备预期挂载，因为该挂载的一个或多个主要弹药储备不可用。恢复保留（清洁）挂载。", aircraft_0.GetUnitSide());
				}
				aircraft_0.AddMessage("飞机：" + aircraft_0.Name + text3 + "没有配备预期挂载，因为该挂载的一个或多个主要弹药储备不可用。恢复保留（清洁）挂载。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_.CurrentHostUnit.GetLongitude(), aircraft_AirOps_.CurrentHostUnit.GetLatitude()));
			}
			return "Incomplete";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100093", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return "Error";
		}
	}

	public void UpdateQuickTurnaroundParams(ref Aircraft_AirOps aircraft_AirOps_0, ref Aircraft aircraft_0)
	{
		if (aircraft_AirOps_0.QuickTurnaround_SortiesFlown == 1)
		{
			byte? b = (byte?)aircraft_0.Doctrine.GetAirOpsTempo(aircraft_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
			if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
			{
				aircraft_AirOps_0.QuickTurnaround_TimePentalty += aircraft_0.Loadout.ReadyTime_Sustained;
			}
			else
			{
				aircraft_AirOps_0.QuickTurnaround_TimePentalty += aircraft_0.Loadout.ReadyTime;
			}
		}
		else
		{
			aircraft_AirOps_0.QuickTurnaround_TimePentalty += aircraft_0.Loadout.QuickTurnaround_AdditionalTimePenalty;
		}
		DateTime time = aircraft_0.ParentScen.Time;
		bool use_DST = aircraft_0.ParentScen.Use_DST;
		string dST_Start = aircraft_0.ParentScen.DST_Start;
		string dST_End = aircraft_0.ParentScen.DST_End;
		Weather.TTimeOfDayType tTimeOfDayType = SunModule.CollectSpecification(aircraft_0.ParentScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, bool_0: true, aircraft_AirOps_0.CurrentHostUnit.GetLatitude(), aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), aircraft_AirOps_0.CurrentHostUnit.GetCurrentAltitude());
		if (aircraft_AirOps_0.QuickTurnaround_SortiesFlown < aircraft_AirOps_0.QuickTurnaround_SortiesTotal)
		{
			if ((double)(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) / (double)aircraft_AirOps_0.QuickTurnaround_SortiesTotal <= (double)(aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown / (float)aircraft_AirOps_0.QuickTurnaround_SortiesFlown))
			{
				if (aircraft_AirOps_0.QuickTurnaround_SortiesFlown > aircraft_AirOps_0.QuickTurnaround_SortiesTotal || aircraft_AirOps_0.QuickTurnaround_SortiesFlown <= 0)
				{
					return;
				}
				float num = aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown / (float)aircraft_AirOps_0.QuickTurnaround_SortiesFlown;
				if (num + aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown > (float)(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) && !Information.IsNothing(aircraft_0.Loadout))
				{
					string text = "";
					if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + aircraft_0.UnitClass + ")";
					}
					aircraft_0.AddMessage(aircraft_0.Name + text + "已经飞过了" + Conversions.ToString(aircraft_AirOps_0.QuickTurnaround_SortiesFlown) + "的" + Conversions.ToString(aircraft_0.Loadout.QuickTurnaround_MaxSorties) + "架次。总的滞空时间是" + Misc.UpdateRequest((long)Math.Round(aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown)) + "，允许滞空时间是" + Misc.UpdateRequest(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) + "。完成架次的平均滞空时间是" + Misc.UpdateRequest((long)Math.Round(num)) + "，大于剩余的允许滞空时间。因此，飞机需要停止戒备。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), aircraft_AirOps_0.CurrentHostUnit.GetLatitude()));
					aircraft_AirOps_0.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_0, ref aircraft_0);
				}
			}
			else if (aircraft_0.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.DayOnly && tTimeOfDayType == Weather.TTimeOfDayType.tod_Night)
			{
				string text2 = "";
				if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
				{
					text2 = " (" + aircraft_0.UnitClass + ")";
				}
				aircraft_0.AddMessage(aircraft_0.Name + text2 + "已经飞过了" + Conversions.ToString(aircraft_AirOps_0.QuickTurnaround_SortiesFlown) + "的" + Conversions.ToString(aircraft_0.Loadout.QuickTurnaround_MaxSorties) + "架次。总的滞空时间是" + Misc.UpdateRequest((long)Math.Round(aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown)) + "，允许滞空时间是" + Misc.UpdateRequest(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) + "。该挂载仅具有白天快速再次出动能力，目前是晚上。因此，飞机需要停止戒备。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), aircraft_AirOps_0.CurrentHostUnit.GetLatitude()));
				aircraft_AirOps_0.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_0, ref aircraft_0);
			}
			else if (aircraft_0.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.NightOnly && tTimeOfDayType == Weather.TTimeOfDayType.tod_Day)
			{
				string text3 = "";
				if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
				{
					text3 = " (" + aircraft_0.UnitClass + ")";
				}
				aircraft_0.AddMessage(aircraft_0.Name + text3 + "已经飞过了" + Conversions.ToString(aircraft_AirOps_0.QuickTurnaround_SortiesFlown) + "的" + Conversions.ToString(aircraft_0.Loadout.QuickTurnaround_MaxSorties) + "架次。总的滞空时间是" + Misc.UpdateRequest((long)Math.Round(aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown)) + "，允许滞空时间是" + Misc.UpdateRequest(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) + "。该挂载仅具有夜间快速再次出动能力，目前是白天。因此，飞机需要停止戒备。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), aircraft_AirOps_0.CurrentHostUnit.GetLatitude()));
				aircraft_AirOps_0.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_0, ref aircraft_0);
			}
			else if ((aircraft_0.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.DayOnly || aircraft_0.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.NightOnly) && tTimeOfDayType == Weather.TTimeOfDayType.tod_Twilight)
			{
				if (aircraft_0.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.NightOnly && Misc.DisableRequest(time, aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), use_DST, dST_Start, dST_End).Hour < 12)
				{
					string text4 = "";
					if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
					{
						text4 = " (" + aircraft_0.UnitClass + ")";
					}
					aircraft_0.AddMessage(aircraft_0.Name + text4 + "已经飞过了" + Conversions.ToString(aircraft_AirOps_0.QuickTurnaround_SortiesFlown) + "的" + Conversions.ToString(aircraft_0.Loadout.QuickTurnaround_MaxSorties) + "架次。总的滞空时间是" + Misc.UpdateRequest((long)Math.Round(aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown)) + "，允许滞空时间是" + Misc.UpdateRequest(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) + "。该挂载仅具有夜间快速再次出动能力，目前是黎明。因此，飞机需要停止戒备。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), aircraft_AirOps_0.CurrentHostUnit.GetLatitude()));
					aircraft_AirOps_0.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_0, ref aircraft_0);
				}
				else if (aircraft_0.Loadout.QuickTurnaround_TimeofDay == Loadout._LoadoutDayNight.DayOnly && Misc.DisableRequest(time, aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), use_DST, dST_Start, dST_End).Hour > 12)
				{
					string text5 = "";
					if (Operators.CompareString(aircraft_0.Name, aircraft_0.UnitClass, TextCompare: false) != 0)
					{
						text5 = " (" + aircraft_0.UnitClass + ")";
					}
					aircraft_0.AddMessage(aircraft_0.Name + text5 + "已经飞过了" + Conversions.ToString(aircraft_AirOps_0.QuickTurnaround_SortiesFlown) + "的" + Conversions.ToString(aircraft_0.Loadout.QuickTurnaround_MaxSorties) + "架次。总的滞空时间是" + Misc.UpdateRequest((long)Math.Round(aircraft_AirOps_0.QuickTurnaround_AirborneTime_Flown)) + "，允许滞空时间是" + Misc.UpdateRequest(aircraft_0.Loadout.QuickTurnaround_AirborneTime * 60) + "。该挂载仅具有白天快速再次出动能力，目前是黄昏。因此，飞机需要停止戒备。", "Air operations", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(aircraft_AirOps_0.CurrentHostUnit.GetLongitude(), aircraft_AirOps_0.CurrentHostUnit.GetLatitude()));
					aircraft_AirOps_0.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_0, ref aircraft_0);
				}
				else
				{
					aircraft_AirOps_0.UpdateQuickTurnaroundSettings_ContinueFlying(ref aircraft_AirOps_0, ref aircraft_0);
				}
			}
			else
			{
				aircraft_AirOps_0.UpdateQuickTurnaroundSettings_ContinueFlying(ref aircraft_AirOps_0, ref aircraft_0);
			}
		}
		else
		{
			aircraft_AirOps_0.UpdateQuickTurnaroundSettings_StepDown(ref aircraft_AirOps_0, ref aircraft_0);
		}
	}

	public bool TransitFacilitiesAreOperative()
	{
		try
		{
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			AirFacility[] array = airFacilities_ReadOnly;
			foreach (AirFacility airFacility in array)
			{
				if (airFacility.ResetReader() && airFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100094", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public virtual AirOpsAttemptResult CanHostThisAircraft(Aircraft aircraft_0)
	{
		try
		{
			if (aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.ManualLaunch)
			{
				return AirOpsAttemptResult.Success;
			}
			if ((aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.CatapultLaunched) & (LongestRunwayLengthClass != GlobalVariables.RunwayLengthClass.None))
			{
				return AirOpsAttemptResult.Success;
			}
			if (myUnit.IsShip)
			{
				Ship._ShipCategory category = ((Ship)myUnit).Category;
				if (category == Ship._ShipCategory.MobileOffshoreBase)
				{
					return AirOpsAttemptResult.Success;
				}
				if (aircraft_0.Category == Aircraft._AircraftCategory.CarrierCapable && category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation && (int)aircraft_0.Size > 10)
				{
					return AirOpsAttemptResult.Too_large_for_carrier;
				}
				if (aircraft_0.RunwayLengthNeeded == GlobalVariables.RunwayLengthClass.VTOL && !aircraft_0.IsHelicopter && aircraft_0.Size != GlobalVariables.AircraftSizeClass.Small && !aircraft_0.IsAerostat && category != Ship._ShipCategory.AviationShip && category != Ship._ShipCategory.SurfaceCombatantAviation)
				{
					return AirOpsAttemptResult.Unable_to_host_VTOL;
				}
				if (aircraft_0.Category == Aircraft._AircraftCategory.FixedWing && aircraft_0.RunwayLengthNeeded != GlobalVariables.RunwayLengthClass.VTOL && ((aircraft_0.Type != Aircraft._AircraftType.UAV && aircraft_0.Type != Aircraft._AircraftType.UCAV) || aircraft_0.RunwayLengthNeeded > LongestRunwayLengthClass))
				{
					if (aircraft_0.RunwayLengthNeeded != GlobalVariables.RunwayLengthClass.Between_1_250m)
					{
						return AirOpsAttemptResult.Unsufficient_runway_length;
					}
					if (myUnit.AirOps.ParkingSpace_Free(ref myUnit.ParentScen) <= (double)(int)aircraft_0.Size)
					{
						return AirOpsAttemptResult.No_operational_free_parking_space;
					}
				}
			}
			bool flag = false;
			int num = myUnit.AirFacilities_ReadOnly.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					AirFacility airFacility2 = myUnit.AirFacilities_ReadOnly[num];
					if (airFacility2.Status == PlatformComponent._ComponentStatus.Operational && airFacility2.QueryReader() && !airFacility2.DefineReader() && airFacility2.CanHostThisAircraft_BySize(aircraft_0) == AirOpsAttemptResult.Success)
					{
						break;
					}
					num += -1;
					continue;
				}
				if (!flag)
				{
					for (int i = myUnit.AirFacilities_ReadOnly.Length - 1; i >= 0; i += -1)
					{
						AirFacility airFacility = myUnit.AirFacilities_ReadOnly[i];
						if (airFacility.Status == PlatformComponent._ComponentStatus.Operational && aircraft_0.IsHelicopter && airFacility.PublishReader() && airFacility.CanHostThisAircraft_BySize(aircraft_0) == AirOpsAttemptResult.Success)
						{
							return AirOpsAttemptResult.Success;
						}
					}
				}
				return AirOpsAttemptResult.Failure_other;
			}
			return AirOpsAttemptResult.Success;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100095", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return AirOpsAttemptResult.Failure_Program;
		}
	}

	public virtual bool CanThisAircraftLandHere(Aircraft aircraft_0)
	{
		try
		{
			int num = myUnit.AirFacilities_ReadOnly.Length - 1;
			while (true)
			{
				if (num >= 0)
				{
					AirFacility airFacility = myUnit.AirFacilities_ReadOnly[num];
					if (airFacility.Status == PlatformComponent._ComponentStatus.Operational && airFacility.DefineReader() && airFacility.ParkingSpace_Free >= (int)aircraft_0.Size)
					{
						break;
					}
					num += -1;
					continue;
				}
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100096", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void AddThisAircraft(Aircraft aircraft_0, bool bool_0)
	{
		try
		{
			if (myUnit.AirOps.EmbarkedAircraft_ReadOnly.Contains(aircraft_0))
			{
				return;
			}
			AirFacility airFacility = CalcClient(aircraft_0);
			if (Information.IsNothing(airFacility))
			{
				if (!bool_0)
				{
					GameGeneral.ResolveBridge("飞机停放设施" + myUnit.Name + "被过度填充。请联系想定作者并要求减少飞机数量以匹配实际停靠容量。", myUnit.GetUnitSide());
				}
				AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array = airFacilities_ReadOnly;
				foreach (AirFacility airFacility2 in array)
				{
					if (airFacility2.QueryReader())
					{
						airFacility = airFacility2;
						break;
					}
				}
			}
			aircraft_0.AirOps.HostAirFacility = airFacility;
			aircraft_0.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Parked;
			aircraft_0.AirOps.SetAssignedHostUnit(bool_0: false, myUnit);
			aircraft_0.AirOps.CurrentHostUnit = myUnit;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100097", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public double ParkingSpace_Free(ref Scenario scenario_0)
	{
		try
		{
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			int num = 0;
			AirFacility[] array = airFacilities_ReadOnly;
			AirFacility[] array2 = array;
			foreach (AirFacility airFacility in array2)
			{
				if (airFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					num += airFacility.ParkingSpace_Free;
				}
			}
			return num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100098", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0.0;
		}
	}

	public bool IsParkingSpaceAvailable(ref Scenario scenario_0, Aircraft aircraft_0)
	{
		return ParkingSpace_Free(ref scenario_0) >= (double)(int)aircraft_0.Size;
	}

	internal AirFacility CalcClient(Aircraft aircraft_0)
	{
		try
		{
			List<AirFacility> list = new List<AirFacility>();
			AirFacility[] airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
			AirFacility[] array = airFacilities_ReadOnly;
			foreach (AirFacility airFacility in array)
			{
				if (airFacility.QueryReader() && airFacility.CanHostThisAircraft_BySize(aircraft_0) == AirOpsAttemptResult.Success && airFacility.Status == PlatformComponent._ComponentStatus.Operational)
				{
					list.Add(airFacility);
				}
			}
			if (list.Count == 0)
			{
				airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array2 = airFacilities_ReadOnly;
				foreach (AirFacility airFacility2 in array2)
				{
					if (airFacility2.Status == PlatformComponent._ComponentStatus.Operational && aircraft_0.IsHelicopter && airFacility2.PublishReader() && airFacility2.CanHostThisAircraft_BySize(aircraft_0) == AirOpsAttemptResult.Success)
					{
						list.Add(airFacility2);
					}
				}
			}
			if (list.Count == 0 && (aircraft_0.Type == Aircraft._AircraftType.UAV || aircraft_0.Type == Aircraft._AircraftType.UCAV))
			{
				AirFacility airFacility3 = AirFacility.AddUAV_Class1_Hanger(myUnit);
				airFacilities_ReadOnly = myUnit.AirFacilities_ReadOnly;
				AirFacility[] array3 = airFacilities_ReadOnly;
				foreach (AirFacility airFacility4 in array3)
				{
					if (airFacility4.Status == PlatformComponent._ComponentStatus.Operational && airFacility4.CanHostThisAircraft_BySize(aircraft_0) == AirOpsAttemptResult.Success && (airFacility3 == airFacility4 || (airFacility4.AirFacType == AirFacility._AirFacType.const_13 && aircraft_0.Loadout != null)))
					{
						list.Add(airFacility4);
					}
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			IEnumerable<AirFacility> source;
			if (myUnit.IsShip)
			{
				Ship._ShipCategory category = ((Ship)myUnit).Category;
				if ((category == Ship._ShipCategory.AviationShip || category == Ship._ShipCategory.SurfaceCombatantAviation || category == Ship._ShipCategory.MobileOffshoreBase) && aircraft_0.AirOps.ConditionTimer < 60f && !Information.IsNothing(aircraft_0.Loadout) && aircraft_0.Loadout.Role != Loadout.LoadoutRole.Reserve && aircraft_0.Loadout.Role != Loadout.LoadoutRole.Unavailable)
				{
					source = from theAF in list
						orderby theAF.TypeString descending, theAF.ParkingSpace_Free
						select theAF;
					if ((double)source.ElementAtOrDefault(0).ParkingSpace_Free / (double)(int)source.ElementAtOrDefault(0).MaxAircraftSize > 4.0)
					{
						return source.ElementAtOrDefault(0);
					}
				}
			}
			if ((int)aircraft_0.Size < 10)
			{
				foreach (AirFacility item in list)
				{
					if (item.AirFacType == AirFacility._AirFacType.Hangar && (int)item.MaxAircraftSize < 10 && (int)aircraft_0.Size <= (int)item.MaxAircraftSize)
					{
						return item;
					}
				}
			}
			source = from theAF in list
				orderby theAF.TypeString, theAF.ParkingSpace_Free
				select theAF;
			return source.ElementAtOrDefault(0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100099", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return null;
		}
	}
}
