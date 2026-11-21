using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Navigator : ActiveUnit_Navigator
{
	private Aircraft m_ContainerObserver;

	[SpecialName]
	private Aircraft GetAircraft()
	{
		if (m_ContainerObserver == null)
		{
			m_ContainerObserver = (Aircraft)myUnit;
		}
		return m_ContainerObserver;
	}

	public override void ToXML(ref XmlWriter xmlWriter_0, ref HashSet<string> hashSet_0)
	{
		try
		{
			xmlWriter_0.WriteStartElement("Navigator");
			if (base.PlottedCourse.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("PC");
				List<Waypoint> list = new List<Waypoint>();
				list.AddRange(base.PlottedCourse);
				foreach (Waypoint item in list)
				{
					if (!Information.IsNothing(item))
					{
						item.ToXML(ref xmlWriter_0, ref hashSet_0);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (base.PlottedCourse_PrePlanned.Count() > 0)
			{
				xmlWriter_0.WriteStartElement("PC_PP");
				List<Waypoint> list2 = new List<Waypoint>();
				list2.AddRange(base.PlottedCourse_PrePlanned);
				foreach (Waypoint item2 in list2)
				{
					if (!Information.IsNothing(item2))
					{
						item2.ToXML(ref xmlWriter_0, ref hashSet_0);
					}
				}
				xmlWriter_0.WriteEndElement();
			}
			if (!Information.IsNothing(_Flight))
			{
				xmlWriter_0.WriteElementString("Flight", _Flight.ObjectID);
			}
			xmlWriter_0.WriteElementString("MPO", ManualPlotOverride.ToString());
			if (!Information.IsNothing(TankerFollowsMe))
			{
				xmlWriter_0.WriteElementString("TankerFollowsMe", TankerFollowsMe.Value.ToString());
			}
			if (TankerFollowsMe_NumberOfWaypoints != 0)
			{
				xmlWriter_0.WriteElementString("TankerFollowsMe_NumberOfWaypoints", TankerFollowsMe_NumberOfWaypoints.ToString());
			}
			if (GetAircraft().IsGroupMember())
			{
				xmlWriter_0.WriteElementString("FS_B", XmlConvert.ToString(base.UnitFormationStation.Bearing));
				xmlWriter_0.WriteElementString("FS_D", XmlConvert.ToString(base.UnitFormationStation.Distance));
				xmlWriter_0.WriteElementString("FS_BT", XmlConvert.ToString((byte)base.UnitFormationStation.BearingType));
			}
			if (SupportMission_NextRefPoint != null)
			{
				xmlWriter_0.WriteStartElement("SM_NRP");
				xmlWriter_0.WriteRaw(SupportMission_NextRefPoint.ToXML(ref hashSet_0));
				xmlWriter_0.WriteEndElement();
			}
			if (PreviousWaypointTime.HasValue)
			{
				xmlWriter_0.WriteElementString("PreviousWaypointTime", PreviousWaypointTime.Value.ToBinary().ToString());
			}
			if (PreviousWaypointType.HasValue)
			{
				xmlWriter_0.WriteElementString("PreviousWaypointType", PreviousWaypointType.Value.ToString());
			}
			xmlWriter_0.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100459", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_Navigator FromXML(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref ActiveUnit activeUnit_0)
	{
		try
		{
			Aircraft_Navigator aircraft_Navigator = new Aircraft_Navigator(ref activeUnit_0);
			aircraft_Navigator.myUnit = activeUnit_0;
			IEnumerator enumerator = null;
			try
			{
				enumerator = xmlNode_0.ChildNodes.GetEnumerator();
				IEnumerator enumerator2 = null;
				IEnumerator enumerator3 = null;
				while (enumerator.MoveNext())
				{
					XmlNode xmlNode = (XmlNode)enumerator.Current;
					switch (xmlNode.Name)
					{
					case "TankerFollowsMe_NumberOfWaypoints":
						aircraft_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(xmlNode.InnerText);
						break;
					case "Flight":
						aircraft_Navigator._Flight_ID = xmlNode.InnerText;
						break;
					case "PreviousWaypointType":
						if (Versioned.IsNumeric(xmlNode.InnerText))
						{
							aircraft_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(xmlNode.InnerText);
							break;
						}
						try
						{
							aircraft_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), xmlNode.InnerText, ignoreCase: true);
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
						break;
					case "PreviousWaypointTime":
					{
						DateTime value = DateTime.FromBinary(Conversions.ToLong(xmlNode.InnerText));
						aircraft_Navigator.PreviousWaypointTime = value;
						break;
					}
					case "MPO":
					case "ManualPlotOverride":
						aircraft_Navigator.ManualPlotOverride = Conversions.ToBoolean(xmlNode.InnerText);
						break;
					case "PC":
					case "PlottedCourse":
						try
						{
							enumerator2 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								XmlNode xmlNode_3 = (XmlNode)enumerator2.Current;
								Waypoint theAC2 = Waypoint.FromXML(ref xmlNode_3, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref aircraft_Navigator._PlottedCourse, theAC2);
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
						break;
					case "FS_B":
					case "FormationStation_Bearing":
						aircraft_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "SupportMission_NextRefPoint":
					case "SM_NRP":
					{
						XmlNode xmlNode_2 = xmlNode.ChildNodes[0];
						aircraft_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref xmlNode_2, ref concurrentDictionary_0);
						break;
					}
					case "FS_BT":
						aircraft_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(xmlNode.InnerText);
						break;
					case "PC_PP":
						try
						{
							enumerator3 = xmlNode.ChildNodes.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								XmlNode xmlNode_ = (XmlNode)enumerator3.Current;
								Waypoint theAC = Waypoint.FromXML(ref xmlNode_, ref concurrentDictionary_0, activeUnit_0.ParentScen);
								ArrayExtensions.Add(ref aircraft_Navigator._PlottedCourse_PrePlanned, theAC);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					case "FS_D":
					case "FormationStation_Distance":
						aircraft_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(xmlNode.InnerText);
						break;
					case "TankerFollowsMe":
						aircraft_Navigator.TankerFollowsMe = Conversions.ToBoolean(xmlNode.InnerText);
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
			return aircraft_Navigator;
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception exception_2 = ex2;
			exception_2?.Data.Add("Error at 100460", "");
			GameGeneral.WriteExceptionsToLog(ref exception_2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Aircraft_Navigator result = new Aircraft_Navigator(ref activeUnit_0);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	public override void CalculateFormationStationRelativeData()
	{
		try
		{
			if (myUnit.GetParentGroup() != null && !myUnit.IsGroupLead())
			{
				ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
				float currentHeading = groupLead.CurrentHeading;
				LockRandom lockRandom = new LockRandom(myUnit.GetParentGroup().Units.Values.ToList().IndexOf(GetAircraft()));
				float num = ((lockRandom.NextDouble() <= 0.5) ? Math2.UpdateClass(currentHeading - 90f) : Math2.UpdateClass(currentHeading + 90f));
				if (base.UnitFormationStation.BearingType == ReferencePoint.OrientationType.Rotating)
				{
					base.UnitFormationStation.Bearing = MathFunctions.DeleteRequest(groupLead.CurrentHeading, num);
				}
				else
				{
					base.UnitFormationStation.Bearing = num;
				}
				base.UnitFormationStation.Distance = (float)(lockRandom.NextDouble() * 1.5);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 1021341908598432694685438", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool HaveReachedFormationStation()
	{
		if (myUnit.GetParentGroup() == null)
		{
			return false;
		}
		if (myUnit.GetParentGroup().GroupLead == null)
		{
			return false;
		}
		Tuple<double, double> latitudeAndLongitude = base.UnitFormationStation.GetLatitudeAndLongitude(myUnit, myUnit.GetParentGroup().GroupLead);
		double item = latitudeAndLongitude.Item1;
		double item2 = latitudeAndLongitude.Item2;
		if ((double)Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), item, item2) < 0.5)
		{
			return true;
		}
		return false;
	}

	public Aircraft_Navigator(ref ActiveUnit activeUnit_0)
		: base(ref activeUnit_0)
	{
		_ComposerWrapper = 100;
		modelWrapper = 1000;
	}

	public override void AddWaypoint(double double_0, double double_1, float float_0, Waypoint.WaypointType waypointType_0, Waypoint.WaypointCreator waypointCreator_0, Waypoint.WaypointCategory waypointCategory_0, bool bool_1 = true)
	{
		try
		{
			base.AddWaypoint(double_0, double_1, float_0, waypointType_0, waypointCreator_0, waypointCategory_0, bool_1);
			if (base.PlottedCourse.Count() == 1)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
			if (waypointType_0 == Waypoint.WaypointType.ManualPlottedCourseWaypoint && myUnit.IsRTB)
			{
				myUnit.AddMessage("你最好知道你在做什么！我在返回基地！", myUnit.Name + " 正在返回基地", LoggedMessage.MessageType.UI, 1, bool_0: true, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100461", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void PlotCourseToStationArea(float float_0, bool bool_1)
	{
		try
		{
			base.PlotCourseToStationArea(float_0, bool_1);
			if (!myUnit.Navigator.HasFlightPlan)
			{
				Aircraft_AirOps airOps = GetAircraft().AirOps;
				if (myUnit.AssignedMissionOrPackage() != null && myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					SetPatrolThrottle(bool_1: false, airOps.Condition);
					SetPatrolAltitude(bool_1: false, airOps.Condition);
				}
				else if (myUnit.AssignedMissionOrPackage() != null)
				{
					_ = myUnit.AssignedMissionOrPackage().MissionClass;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100462", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void HeadToFormationStation(float float_0)
	{
		try
		{
			if (myUnit.IsGroupLead())
			{
				return;
			}
			if (myUnit.GetParentGroup()?.GroupLead == null)
			{
				myUnit.GetParentGroup()?.PrintInvocation();
				if (myUnit.GetParentGroup()?.GroupLead == null)
				{
					return;
				}
			}
			m_ErrorWrapper = true;
			Aircraft aircraft = (Aircraft)myUnit;
			ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
			if (groupLead != myUnit && Module_Unit.RangeToUnit_Horiz(myUnit, groupLead) < 4f)
			{
				aircraft.AI.HasCaughtUpWithGroup = true;
			}
			if (myUnit.IsGroupMember())
			{
				if (myUnit.GetParentGroup().GroupLead.GetDesiredAltitude_UseTerrainFollowing(myUnit.GetParentGroup().GroupLead) && myUnit.GetParentGroup().GroupLead.DesiredAltitude_AGL > 0f)
				{
					myUnit.DesiredAltitude_AGL = myUnit.GetParentGroup().GroupLead.DesiredAltitude_AGL;
				}
				else
				{
					myUnit.DesiredAltitude = myUnit.GetParentGroup().GroupLead.DesiredAltitude;
				}
			}
			if (myUnit.IsGroupMember() && myUnit.GetParentGroup().GroupLead != null && (myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling) && myUnit.GetParentGroup().GroupLead.DockingOps.UNREP_Destination == myUnit)
			{
				if (myUnit.GetParentGroup().GroupLead.Navigator.HasPlottedCourse())
				{
					Waypoint waypoint = myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse[0];
					myUnit.SetDesiredHeading(myUnit.GetParentGroup().GroupLead.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint.Latitude, waypoint.Longitude));
					Waypoint waypoint_ = null;
					ExtendIfNecessary(float_0, ref waypoint_, waypoint.Latitude, waypoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
				}
				return;
			}
			if (base.HasPathfindingPlottedCourse)
			{
				FollowPlottedCourse(float_0);
				return;
			}
			ActiveUnit activeUnit = myUnit.GetParentGroup()?.GroupLead;
			if (activeUnit == null || base.UnitFormationStation == null)
			{
				return;
			}
			double double_ = 0.0;
			double double_2 = 0.0;
			Geodesic_EdWilliams.CalcPoint_Williams(activeUnit.GetLongitude(), activeUnit.GetLatitude(), ref double_, ref double_2, base.UnitFormationStation.Distance, base.UnitFormationStation.GetResultantBearing(myUnit));
			if (HaveReachedFormationStation())
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), double_2, double_));
				if (relativeBearing > 90f && relativeBearing < 270f)
				{
					myUnit.SetDesiredHeading(activeUnit.DesiredTurnRate, myUnit.GetParentGroup().DesiredHeading);
					myUnit.DesiredSpeed = myUnit.GetParentGroup().GroupLead.CurrentSpeed - Module_Unit.RangeToPoint_Horiz(myUnit, double_2, double_) * 10f;
				}
				else
				{
					myUnit.SetDesiredHeading(activeUnit.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), double_2, double_));
					myUnit.DesiredSpeed = myUnit.GetParentGroup().DesiredSpeed;
				}
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				return;
			}
			myUnit.SetDesiredHeading(activeUnit.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), double_2, double_));
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && !m_ErrorWrapper)
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
				}
				else
				{
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
				}
			}
			else if (myUnit.IsGroupMember())
			{
				if (Math.Abs(MathFunctions.DeleteRequest(groupLead.DesiredHeading, groupLead.CurrentHeading)) < 5f && Math.Abs(MathFunctions.DeleteRequest(myUnit.DesiredHeading, myUnit.CurrentHeading)) < 5f)
				{
					if ((int)myUnit.GetParentGroup().GroupLead.ThrottleSetting <= 3)
					{
						if (Module_Unit.RangeToPoint_Horiz(myUnit, double_2, double_) <= 4f)
						{
							myUnit.SetThrottle(activeUnit.ThrottleSetting + 1);
						}
						else
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Full);
						}
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
					}
				}
			}
			else
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Full);
			}
			if ((myUnit.Kinematics.DesiredSpeedOverride.HasValue || myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None) && activeUnit.DesiredSpeed >= myUnit.DesiredSpeed && Math.Abs(MathFunctions.DeleteRequest(groupLead.DesiredHeading, groupLead.CurrentHeading)) < 5f && Math.Abs(MathFunctions.DeleteRequest(myUnit.DesiredHeading, groupLead.DesiredHeading)) < 45f)
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			}
			if (activeUnit.CurrentSpeed > 0f)
			{
				double double_3 = 0.0;
				double double_4 = 0.0;
				Geodesic_EdWilliams.CalcPoint_Williams(double_, double_2, ref double_3, ref double_4, base.UnitFormationStation.Distance, activeUnit.CurrentHeading);
				ActiveUnit activeUnit2 = myUnit;
				double double_5 = double_4;
				double double_6 = double_3;
				int int_ = 0;
				bool bool_ = true;
				bool bool_2 = true;
				List<ActiveUnit> list_ = null;
				string string_ = "";
				bool bool_3 = false;
				if (!activeUnit2.CanMoveToThisLocation(double_5, double_6, ref int_, bool_0: false, bool_1: false, bool_2: true, ref bool_, bool_4: true, ref bool_2, null, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_3))
				{
					double_2 = activeUnit.GetLatitude();
					double_ = activeUnit.GetLongitude();
				}
			}
			myUnit.AI.NavDestination = new Geopoint_Struct(double_, double_2);
			if (base.HasPathfindingPlottedCourse || base.PathFindingInProgress)
			{
				return;
			}
			if (myUnit.Navigator.bool_0)
			{
				double latitude = myUnit.GetLatitude();
				double longitude = myUnit.GetLongitude();
				double double_7 = double_2;
				double double_8 = double_;
				float? nullable_ = Pathfinding.visitorConsumer.DegreeInterval_Finegrained;
				int int_2 = 0;
				GeoPoint geoPoint_ = null;
				if (PathLineIsInterrupted(latitude, longitude, double_7, double_8, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: true, nullable_, ref int_2, ref geoPoint_))
				{
					TriggerPathfinderThread(null, myUnit, null, bool_1: false, 0.15f, double_2, double_, myUnit.ParentScen, bool_2: false);
					return;
				}
			}
			float relativeBearing2 = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), double_2, double_));
			if (myUnit.GetParentGroup() != null && relativeBearing2 > 90f && relativeBearing2 < 270f && Math.Abs(MathFunctions.DeleteRequest(myUnit.CurrentHeading, myUnit.GetParentGroup().CurrentHeading)) <= 30f)
			{
				myUnit.SetDesiredHeading(activeUnit.DesiredTurnRate, myUnit.GetParentGroup().CurrentHeading);
				myUnit.DesiredSpeed = (float)((double)myUnit.GetParentGroup().CurrentSpeed * 0.2);
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
			}
			else
			{
				myUnit.SetDesiredHeading(activeUnit.DesiredTurnRate, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), double_2, double_));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100217", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HandleReachedInitialPoint()
	{
		myUnit.Kinematics.DesiredAltitudeOverride = false;
		byte? b = (byte?)myUnit.Doctrine.GetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
		bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
		if (((!flag) ?? flag).GetValueOrDefault())
		{
			myUnit.Doctrine.SetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
		}
		if (!myUnit.IsGroupLead())
		{
			return;
		}
		foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
		{
			if (value != myUnit && !value.Navigator.HasPlottedCourse())
			{
				value.Kinematics.DesiredSpeedOverride = myUnit.Kinematics.DesiredSpeedOverride;
				value.Kinematics.ThrottlePreset = myUnit.Kinematics.ThrottlePreset;
				value.Kinematics.DesiredAltitudeOverride = false;
				b = (byte?)value.Doctrine.GetIgnorePlottedCourse(value.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null);
				if (((!flag) ?? flag).GetValueOrDefault())
				{
					value.Doctrine.SetIgnorePlottedCourse(value.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.Yes);
				}
			}
		}
	}

	internal bool CalcProxy()
	{
		if (myUnit.IsGroupLead())
		{
			foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
			{
				if (value.IsOperating())
				{
					if (!value.IsGroupLead() && !value.AI.HasCaughtUpWithGroup)
					{
						return true;
					}
					continue;
				}
				return true;
			}
		}
		return false;
	}

	protected override void HeadToFirstWaypoint(float float_0)
	{
		try
		{
			Waypoint[] gparam_ = base.PlottedCourse;
			if (gparam_.Length == 0)
			{
				ManualPlotOverride = false;
				return;
			}
			Waypoint waypoint = gparam_[0];
			if (waypoint.Type == Waypoint.WaypointType.WeaponTarget && gparam_.Count() > 1)
			{
				ArrayExtensions.Remove(ref gparam_, gparam_.ElementAt(0));
			}
			waypoint = gparam_[0];
			if (myUnit.Navigator.HasFlightPlan && myUnit.Navigator.HasPlottedCourse())
			{
				if (myUnit.Navigator.PlottedCourse[0].SpacingManeuver_Time <= 0f)
				{
					if (!Information.IsNothing(myUnit.Navigator.PlottedCourse[0].Time_Zulu) && myUnit.Navigator.PlottedCourse[0].Hold_Time > 0f)
					{
						if (myUnit.Navigator.PlottedCourse[0].InitReponse() && !Information.IsNothing(myUnit.Navigator.PlottedCourse[0].RaceTrackHelperPoint) && gparam_.Length > 1 && !Information.IsNothing(myUnit.Navigator.PlottedCourse[1].Time_Zulu))
						{
							if (myUnit.AI.ManouverRaceTrack(ref myUnit.ParentScen, ref waypoint, ref myUnit.Navigator.PlottedCourse[1]))
							{
								return;
							}
						}
						else if (myUnit.AI.ManouverForSpace(waypoint.Time_Zulu, ref waypoint, bool_0: false))
						{
							return;
						}
					}
					else if (myUnit.Navigator.PlottedCourse[0].Hold_Time > 0f && myUnit.IsAircraft && ((Aircraft)myUnit).Navigator.CalcProxy() && myUnit.AI.ManouverForSpace(waypoint.Time_Zulu, ref waypoint, bool_0: false))
					{
						return;
					}
				}
				else if (myUnit.AI.ManouverForSpace(waypoint.Time_Zulu, ref waypoint, bool_0: false))
				{
					return;
				}
			}
			ActiveUnit.TurnRate turnRate_ = ((gparam_[0].Type != Waypoint.WaypointType.TakeOff) ? ActiveUnit.TurnRate.Navigation : ActiveUnit.TurnRate.Max);
			myUnit.SetDesiredHeading(turnRate_, Module_Unit.BearingToPoint_True(myUnit, waypoint.Latitude, waypoint.Longitude));
			ExtendIfNecessary(float_3: (GetAircraft().DesiredTurnRate != ActiveUnit.TurnRate.Navigation || myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive) ? myUnit.Kinematics.TurnRate() : ((myUnit.Navigator.GetFlight() == null) ? myUnit.Kinematics.TurnRate() : ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(myUnit.DesiredTurnRate_Navigation, myUnit.CurrentSpeed)), float_0: float_0, waypoint_0: ref waypoint, double_0: waypoint.Latitude, double_1: waypoint.Longitude, float_1: 0f, float_2: 0f);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 10023296543967976", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void CheckIfReachedWaypoint(float float_0, ref bool bool_1, ref bool bool_2)
	{
		bool_1 = false;
		if (base.PlottedCourse.Length == 0)
		{
			return;
		}
		Scenario parentScen = myUnit.ParentScen;
		if (DateTime.Compare(WP_reach_cache_memory.theTime, parentScen.Time) == 0)
		{
			if (parentScen.GameContext.GameMode != Game._GameMode.ScenEdit || myUnit.Location == WP_reach_cache_memory.UnitLocation)
			{
				return;
			}
		}
		else if (((base.PlottedCourse[0].Latitude == WP_reach_cache_memory.theWaypoint.Latitude) & (base.PlottedCourse[0].Longitude == WP_reach_cache_memory.theWaypoint.Longitude)) && myUnit.Location == WP_reach_cache_memory.UnitLocation)
		{
			return;
		}
		try
		{
			Waypoint waypoint_ = base.PlottedCourse.FirstOrDefault();
			if (waypoint_ == null || (!bool_1 && (waypoint_.Type == Waypoint.WaypointType.Assemble || waypoint_.Type == Waypoint.WaypointType.HoldEnd) && myUnit.IsGroupLead() && (Information.IsNothing(waypoint_.Time_Zulu) || waypoint_.Hold_Time <= 0f) && CalcProxy()))
			{
				return;
			}
			if (!bool_1 && waypoint_.Hold_Time > 0f)
			{
				if (!Information.IsNothing(waypoint_.Time_Zulu))
				{
					DateTime? time_Zulu = waypoint_.Time_Zulu;
					DateTime time = myUnit.ParentScen.Time;
					if ((time_Zulu.HasValue ? new bool?(DateTime.Compare(time_Zulu.GetValueOrDefault(), time) >= 0) : null).GetValueOrDefault())
					{
						return;
					}
				}
				if (((waypoint_.Type == Waypoint.WaypointType.Assemble || waypoint_.Type == Waypoint.WaypointType.HoldEnd) && myUnit.IsGroupLead()) & bool_1)
				{
					if (myUnit.IsGroupMember())
					{
						myUnit.AddMessage(myUnit.GetParentGroup().Name + "已完成组装并正在前往下一个航路点。", myUnit.GetParentGroup().Name + " 机动出", LoggedMessage.MessageType.UI, 1, bool_0: true, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					else
					{
						myUnit.AddMessage(myUnit.Name + "已完成组装并正在前往下一个航路点。", myUnit.Name + " 机动出", LoggedMessage.MessageType.UI, 1, bool_0: true, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
				}
			}
			Waypoint waypoint = null;
			if (waypoint_.Type == Waypoint.WaypointType.StationEnd && waypoint_.Station_Time > 0f)
			{
				waypoint = waypoint_;
			}
			else
			{
				int? num = (int?)PreviousWaypointType;
				bool? flag;
				bool? flag8 = (flag = (num.HasValue ? new bool?(num.GetValueOrDefault() == 24) : null));
				bool? flag9;
				flag = (flag9 = ((flag8.HasValue && !flag.GetValueOrDefault()) ? new bool?(false) : ((base.PlottedCourse.Length > 1) & flag)));
				bool? flag10 = ((flag.HasValue && !flag9.GetValueOrDefault()) ? new bool?(false) : ((base.PlottedCourse[1].Type == Waypoint.WaypointType.StationEnd) & flag9));
				if (flag10.GetValueOrDefault(true) && base.PlottedCourse[1].Station_Time > 0f && flag10.HasValue)
				{
					waypoint = base.PlottedCourse[1];
				}
			}
			if (waypoint != null && !Information.IsNothing(waypoint.Time_Zulu))
			{
				DateTime? time_Zulu2 = waypoint.Time_Zulu;
				DateTime time2 = myUnit.ParentScen.Time;
				if ((time_Zulu2.HasValue ? new bool?(DateTime.Compare(time_Zulu2.GetValueOrDefault(), time2) <= 0) : null).GetValueOrDefault())
				{
					bool_2 = true;
					if (myUnit.IsGroupMember())
					{
						myUnit.AddMessage(myUnit.GetParentGroup().Name + "已经完成了巡逻时间并且正在前往下一个航点。", myUnit.Name + " 机动在", LoggedMessage.MessageType.UI, 1, bool_0: true, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
					else
					{
						myUnit.AddMessage(myUnit.Name + "已经完成了巡逻时间并且正在前往下一个航点。", myUnit.Name + " 机动在", LoggedMessage.MessageType.UI, 1, bool_0: true, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					}
				}
			}
			if (!(HaveReachedPoint(waypoint_.Latitude, waypoint_.Longitude, float_0, waypoint_.OvershootWaypoint, bool_2: true) | bool_1))
			{
				return;
			}
			GetAircraft().AI.RefueledInThisLeg = false;
			if (FlushProxy(float_0, ref waypoint_, ref bool_2))
			{
				return;
			}
			ApplyWaypointSpeedAltToUnit(waypoint_);
			if (DateTime.Compare(WP_reach_cache_memory.theTime, parentScen.Time) == 0)
			{
				if (parentScen.GameContext.GameMode != Game._GameMode.ScenEdit || myUnit.Location == WP_reach_cache_memory.UnitLocation)
				{
					return;
				}
			}
			else if (((waypoint_.Latitude == WP_reach_cache_memory.theWaypoint.Latitude) & (waypoint_.Longitude == WP_reach_cache_memory.theWaypoint.Longitude)) && myUnit.Location == WP_reach_cache_memory.UnitLocation)
			{
				return;
			}
			ApplyWaypointDoctrineToUnit(waypoint_);
			WP_reach_cache_memory = new WP_reach_cache(waypoint_.Latitude, waypoint_.Longitude, myUnit.ParentScen.Time, bool_0: false, 0.0, myUnit.Location);
			RemoveWaypoint_Soft(waypoint_, bool_1: false);
			if (waypoint_.Type == Waypoint.WaypointType.InitialPoint || waypoint_.Type == Waypoint.WaypointType.WeaponLaunch)
			{
				HandleReachedInitialPoint();
			}
			if ((waypoint_.Type == Waypoint.WaypointType.LandingMarshal) | (waypoint_.Type == Waypoint.WaypointType.Land))
			{
				if (myUnit.IsGroupLead())
				{
					List<Aircraft> list = new List<Aircraft>();
					foreach (Aircraft value in myUnit.GetParentGroup().Units.Values)
					{
						if (value != myUnit)
						{
							list.Add(value);
						}
					}
					foreach (Aircraft item in list)
					{
						item.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
						item.AI.ReturnToBase(float_0);
					}
				}
				myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
				GetAircraft().AI.ReturnToBase(float_0);
			}
			if ((!Information.IsNothing(GetAircraft().AssignedMissionOrPackage()) && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && ((Patrol)GetAircraft().AssignedMissionOrPackage()).Type == GlobalVariables.PatrolType.ASW && GetAircraft().Sensory.HasAvailableDippingSonar && GetAircraft().AirOps.HoverForDippingSonar()) || (waypoint_.Type == Waypoint.WaypointType.LocalizationRun && GetAircraft().Sensory.HasAvailableDippingSonar && myUnit.AI.PrimaryTarget != null && GetAircraft().AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine && GetAircraft().AirOps.HoverForDippingSonar()) || ((waypoint_.Type == Waypoint.WaypointType.PickupPoint || waypoint_.Type == Waypoint.WaypointType.DropOffPoint) && GetAircraft().AirOps.SettleForCargoTransfer()))
			{
				return;
			}
			if (TankerFollowsMe_NumberOfWaypoints != 0 && Information.IsNothing(myUnit.AI.RaceTrackPoint))
			{
				bool? flag5;
				if (waypoint_.EnableReponse())
				{
					int? num2 = (int?)PreviousWaypointType;
					bool? flag11;
					bool? flag12 = (flag11 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 22) : null));
					bool? flag13;
					bool? flag14;
					if (flag12.HasValue && flag11.GetValueOrDefault())
					{
						flag13 = true;
					}
					else
					{
						num2 = (int?)PreviousWaypointType;
						flag12 = (flag14 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 21) : null));
						flag13 = ((!flag12.HasValue) ? null : (flag14.GetValueOrDefault() | flag11));
					}
					bool? flag15 = flag13;
					flag14 = flag13;
					bool? flag2;
					bool? flag3;
					if (flag14.HasValue && flag15.GetValueOrDefault())
					{
						flag2 = true;
					}
					else
					{
						num2 = (int?)PreviousWaypointType;
						flag14 = (flag3 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 20) : null));
						flag2 = ((!flag14.HasValue) ? null : (flag3.GetValueOrDefault() | flag15));
					}
					bool? flag4 = flag2;
					flag3 = flag2;
					if (flag3.HasValue && flag4.GetValueOrDefault())
					{
						flag5 = true;
					}
					else
					{
						num2 = (int?)PreviousWaypointType;
						bool? flag6;
						flag3 = (flag6 = (num2.HasValue ? new bool?(num2.GetValueOrDefault() == 23) : null));
						flag5 = ((!flag3.HasValue) ? null : (flag6.GetValueOrDefault() | flag4));
					}
				}
				else
				{
					flag5 = false;
				}
				bool? flag7 = flag5;
				if (((!flag7) ?? flag7).GetValueOrDefault())
				{
					AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_);
				}
			}
			if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse && base.PlottedCourse.Count() > 0 && TankerFollowsMe_NumberOfWaypoints == 0)
			{
				byte? b = (byte?)myUnit.Doctrine.GetUseReplenishment(myUnit.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false);
				if ((b.HasValue ? new bool?(b.GetValueOrDefault() == 1) : null).GetValueOrDefault())
				{
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						TankerFollowsMe = null;
						GetAircraft().AirOps.DisconnectFromTanker();
						string text = "";
						if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
						{
							text = " (" + myUnit.UnitClass + ")";
						}
						Aircraft aircraft2 = GetAircraft();
						double double_ = 0.0;
						double double_2 = 0.0;
						if (aircraft2.FuelPercent(ref double_, ref double_2, bool_0: false) < 0.99)
						{
							myUnit.AddMessage(myUnit.Name + text + "已经到达了一个不再允许空中加油的航点。即使飞机没有完全加油，也要与加油机断开连接。", myUnit.Name + " 正断开连接", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
						else
						{
							myUnit.AddMessage(myUnit.Name + text + "已经到达了一个不再允许空中加油的航点。与加油机断开连接。", myUnit.Name + " 正断开连接", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
						}
					}
					if (myUnit.IsGroupLead())
					{
						foreach (ActiveUnit value2 in myUnit.GetParentGroup().Units.Values)
						{
							if (value2 != myUnit && !value2.Navigator.HasPlottedCourse() && value2.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
							{
								TankerFollowsMe = null;
								((Aircraft)value2).AirOps.DisconnectFromTanker();
								string text2 = "";
								if (value2.IsAircraft && Operators.CompareString(value2.Name, value2.UnitClass, TextCompare: false) != 0)
								{
									text2 = " (" + value2.UnitClass + ")";
								}
								Aircraft aircraft3 = GetAircraft();
								double double_3 = 0.0;
								double double_4 = 0.0;
								if (aircraft3.FuelPercent(ref double_3, ref double_4, bool_0: false) < 0.99)
								{
									value2.AddMessage(value2.Name + text2 + "已经到达了一个不再允许空中加油的航点。即使飞机没有完全加油，也要与加油机断开连接。", value2.Name + " 正中止空中加油", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(value2.GetLongitude(), value2.GetLatitude()));
								}
								else
								{
									value2.AddMessage(value2.Name + text2 + "已经到达了一个不再允许空中加油的航点。与加油机断开连接。", value2.Name + " 正中止空中加油", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(value2.GetLongitude(), value2.GetLatitude()));
								}
							}
						}
					}
				}
			}
			if (waypoint_.Type == Waypoint.WaypointType.Assemble)
			{
				if (base.PlottedCourse.Count() > 0)
				{
					myUnit.CurrentHeading = Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), base.PlottedCourse[0].Latitude, base.PlottedCourse[0].Longitude);
				}
				if (myUnit.IsGroupLead())
				{
					foreach (ActiveUnit value3 in myUnit.GetParentGroup().Units.Values)
					{
						if (!value3.IsGroupLead() && value3.IsOperating())
						{
							value3.CurrentHeading = myUnit.CurrentHeading;
						}
					}
				}
			}
			myUnit.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
			myUnit.Navigator.PreviousWaypointLatitude = waypoint_.Latitude;
			myUnit.Navigator.PreviousWaypointLongitude = waypoint_.Longitude;
			myUnit.Navigator.PreviousWaypointType = waypoint_.Type;
			if (base.PlottedCourse.Count() > 0)
			{
				ExtendTimer = 0.0;
				if ((waypoint_.Category == Waypoint.WaypointCategory.FlightPlan) & (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse) & (base.PlottedCourse[0].Category != Waypoint.WaypointCategory.FlightPlan))
				{
					Waypoint[] gparam_ = base.PlottedCourse;
					ArrayExtensions.Clear(ref gparam_);
					base.PlottedCourse = gparam_;
					gparam_ = base.PlottedCourse;
					ArrayExtensions.Remove(ref gparam_, waypoint_);
					base.PlottedCourse = gparam_;
				}
				if ((waypoint_.Type == Waypoint.WaypointType.Refuel) & !GetAircraft().AI.RefueledInThisLeg)
				{
					RateProxy(waypoint_, myUnit);
				}
				else
				{
					HeadToFirstWaypoint(float_0);
					ExtendTimer = 0.0;
				}
				ForgotProxy(float_0, ref waypoint_);
			}
			if (base.IsOnAutoPlannerPlottedCourse && base.PlottedCourse[0].Type != Waypoint.WaypointType.Target && base.PlottedCourse[0].Type != Waypoint.WaypointType.WeaponTarget && base.PlottedCourse[0].Type != Waypoint.WaypointType.InitialPoint && base.PlottedCourse[0].Type != Waypoint.WaypointType.WeaponLaunch && myUnit.Navigator.InstantiateDic(base.PlottedCourse[0].Latitude, base.PlottedCourse[0].Longitude, 0f, 0f, ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(myUnit.DesiredTurnRate_Navigation, myUnit.CurrentSpeed)) && Math2.ResolveClass(myUnit, base.PlottedCourse[0]) < 10f)
			{
				bool bool_3 = true;
				bool bool_4 = false;
				CheckIfReachedWaypoint(float_0, ref bool_3, ref bool_4);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100463", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void RateProxy(Waypoint waypoint_0, ActiveUnit activeUnit_0)
	{
		if (waypoint_0.Type == Waypoint.WaypointType.Refuel)
		{
			GeoPoint geoPoint_ = GetAircraft().AI.LoginClient();
			List<Mission> list_ = null;
			if (waypoint_0.TankerUsage == Mission.TankerMethod.Mission)
			{
				list_ = waypoint_0.TankerMissions;
			}
			bool bool_ = false;
			Aircraft_AirOps airOps = GetAircraft().AirOps;
			Doctrine._UnderwayRefuelAndReplenishmentSelection value = activeUnit_0.Doctrine.GetReplenishmentSelection(activeUnit_0.ParentScen, bool_0: false, bool_1: false, bool_2: false, bool_3: false).Value;
			bool flag = false;
			ActiveUnit activeUnit_ = null;
			string string_ = "";
			bool bool_2 = false;
			bool flag2 = airOps.AssetProxy(geoPoint_, value, ref flag, bool_1: true, ref activeUnit_, ref list_, ref string_, ref bool_2, ref bool_);
			if (waypoint_0.TankerFollowsReceivers)
			{
				TankerFollowsMe = true;
				TankerFollowsMe_NumberOfWaypoints = waypoint_0.TankerFollowsReceivers_NumberOfWaypoints;
				string text = "";
				if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
				{
					text = " (" + activeUnit_0.UnitClass + ")";
				}
				if (TankerFollowsMe_NumberOfWaypoints <= 0)
				{
					if (TankerFollowsMe_NumberOfWaypoints == -98)
					{
						activeUnit_0.AddMessage(activeUnit_0.Name + text + "已到达加油航点，现在将尝试与加油机连接。加油机将提供航路加油，并将与飞机保持一致直到下一巡逻航点，以确保油箱在该点充满，然后断开连接并继续执行任务。", activeUnit_0.Name + " 尝试连接加油机", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
					}
					else if (TankerFollowsMe_NumberOfWaypoints == -97)
					{
						activeUnit_0.AddMessage(activeUnit_0.Name + text + "已到达加油航点，现在将尝试与加油机连接。加油机将提供航路加油，并将与飞机保持一致直到停靠终点航点，以确保油箱在该点充满，然后断开连接并继续执行任务。", activeUnit_0.Name + " 尝试连接加油机", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
					}
					else if (TankerFollowsMe_NumberOfWaypoints == -99)
					{
						activeUnit_0.AddMessage(activeUnit_0.Name + text + "已到达加油航点，现在将尝试与加油机连接。加油机将提供航路加油，并将与飞机保持一致直到着陆集结航点，然后断开连接并继续执行任务。", activeUnit_0.Name + " 尝试连接加油机", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
					}
					else
					{
						activeUnit_0.AddMessage(activeUnit_0.Name + text + "已到达加油航点，现在将尝试与加油机连接。加油机将提供航路加油，飞机将断开连接并继续执行任务。", activeUnit_0.Name + " 尝试连接加油机", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
					}
				}
				else
				{
					activeUnit_0.AddMessage(activeUnit_0.Name + text + "已到达加油航点，现在将尝试与加油机连接。加油机将提供航线加油，并将留在飞机上" + Conversions.ToString(TankerFollowsMe_NumberOfWaypoints) + "航点确保加油机在该点满载，然后断开连接并继续执行任务。", activeUnit_0.Name + " 尝试连接加油机", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
				}
			}
			else
			{
				TankerFollowsMe = false;
				TankerFollowsMe_NumberOfWaypoints = 0;
				string text2 = "";
				if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, TextCompare: false) != 0)
				{
					text2 = " (" + activeUnit_0.UnitClass + ")";
				}
				activeUnit_0.AddMessage(activeUnit_0.Name + text2 + "已到达加油航点，现在将尝试与加油机连接加油。飞机将完全断开并继续执行任务。", activeUnit_0.Name + " 尝试连接加油机", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(activeUnit_0.GetLongitude(), activeUnit_0.GetLatitude()));
			}
			if (activeUnit_0.IsGroupLead())
			{
				foreach (ActiveUnit value2 in activeUnit_0.GetParentGroup().Units.Values)
				{
					if (value2 != activeUnit_0 && !value2.Navigator.HasPlottedCourse())
					{
						value2.Navigator.TankerFollowsMe_NumberOfWaypoints = TankerFollowsMe_NumberOfWaypoints;
					}
				}
			}
			if (flag2 && !bool_)
			{
				GetAircraft().AI.PerformScheduledRefuel();
			}
		}
		else if (activeUnit_0.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
		{
			TankerFollowsMe = null;
			TankerFollowsMe_NumberOfWaypoints = 0;
		}
	}

	private bool FlushProxy(float float_0, ref Waypoint waypoint_0, ref bool bool_1)
	{
		try
		{
			if (myUnit.Navigator.HasFlightPlan)
			{
				if (bool_1)
				{
					if (waypoint_0.EnableReponse())
					{
						return false;
					}
					if (waypoint_0.SearchReponse())
					{
						ApplyWaypointSpeedAltToUnit(base.PlottedCourse[0]);
						ApplyWaypointDoctrineToUnit(base.PlottedCourse[0]);
						RemoveWaypoint_Soft(base.PlottedCourse[0], bool_1: false);
						myUnit.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
						myUnit.Navigator.PreviousWaypointLatitude = waypoint_0.Latitude;
						myUnit.Navigator.PreviousWaypointLongitude = waypoint_0.Longitude;
						myUnit.Navigator.PreviousWaypointType = waypoint_0.Type;
						waypoint_0 = base.PlottedCourse[0];
					}
					return false;
				}
				if (waypoint_0.EnableReponse())
				{
					int num = myUnit.Navigator.GetFlight().FlightPlan.Count() - 1;
					Waypoint waypoint = null;
					for (int i = 1; i <= num; i++)
					{
						if (myUnit.Navigator.GetFlight().FlightPlan[i] == waypoint_0)
						{
							waypoint = myUnit.Navigator.GetFlight().FlightPlan[i - 1];
							break;
						}
					}
					if (Information.IsNothing(waypoint))
					{
						return false;
					}
					if (waypoint.SearchReponse())
					{
						bool flag = false;
						if (waypoint.SearchReponse())
						{
							myUnit.Navigator.ClearPathfindingWaypoints();
							ActiveUnit_Navigator navigator = myUnit.Navigator;
							Waypoint[] waypoint_ = navigator.PlottedCourse;
							ActiveUnit_Navigator.AddWaypoint(ref waypoint_, 0, waypoint);
							navigator.PlottedCourse = waypoint_;
							if (waypoint.Type == Waypoint.WaypointType.StationStart_RaceTrackRandom && GameGeneral.LockRandom_0.Next(1, 100) <= 33)
							{
								myUnit.Navigator.PlotCourseToStationArea(float_0, bool_1: true);
								flag = true;
							}
						}
						if (!flag)
						{
							ApplyWaypointSpeedAltToUnit(base.PlottedCourse[0]);
							ApplyWaypointDoctrineToUnit(base.PlottedCourse[0]);
							myUnit.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
							myUnit.Navigator.PreviousWaypointLatitude = waypoint_0.Latitude;
							myUnit.Navigator.PreviousWaypointLongitude = waypoint_0.Longitude;
							myUnit.Navigator.PreviousWaypointType = waypoint_0.Type;
						}
						ExtendTimer = 0.0;
						HeadToFirstWaypoint(float_0);
						ExtendTimer = 0.0;
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
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
			return false;
		}
	}

	private void ForgotProxy(float float_0, ref Waypoint waypoint_0)
	{
		try
		{
			if (base.PlottedCourse.Count() <= 0 || !myUnit.IsGroupLead() || waypoint_0.FlightFormation == Waypoint.Formation.Split || base.PlottedCourse[0].FlightFormation != Waypoint.Formation.Split)
			{
				return;
			}
			foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
			{
				if (value.FlightRole == Mission.Flight.FlightElement.LeadElement || !value.IsOperating())
				{
					continue;
				}
				Waypoint[] gparam_ = new Waypoint[0];
				value.Navigator.ApplyWaypointSpeedAltToUnit(waypoint_0);
				value.Navigator.ApplyWaypointDoctrineToUnit(waypoint_0);
				value.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
				value.Navigator.PreviousWaypointLatitude = waypoint_0.Latitude;
				value.Navigator.PreviousWaypointLongitude = waypoint_0.Longitude;
				value.Navigator.PreviousWaypointType = waypoint_0.Type;
				Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
				Waypoint[] array = plottedCourse;
				foreach (Waypoint waypoint in array)
				{
					if (value.FlightRole == Mission.Flight.FlightElement.LeadElementWingman)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
							{
								ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_LeadElementWingman);
							}
							break;
						}
						if (!Information.IsNothing(waypoint.Waypoint_LeadElementWingman))
						{
							ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_LeadElementWingman);
						}
					}
					else if (value.FlightRole == Mission.Flight.FlightElement.SecondElement)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
							{
								ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_SecondElement);
							}
							break;
						}
						if (!Information.IsNothing(waypoint.Waypoint_SecondElement))
						{
							ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_SecondElement);
						}
					}
					else if (value.FlightRole == Mission.Flight.FlightElement.SecondElementWingman)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
							{
								ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_SecondElementWingman);
							}
							break;
						}
						if (!Information.IsNothing(waypoint.Waypoint_SecondElementWingman))
						{
							ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_SecondElementWingman);
						}
					}
					else if (value.FlightRole == Mission.Flight.FlightElement.ThirdElement)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
							{
								ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_ThirdElement);
							}
							break;
						}
						if (!Information.IsNothing(waypoint.Waypoint_ThirdElement))
						{
							ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_ThirdElement);
						}
					}
					else
					{
						if (value.FlightRole != Mission.Flight.FlightElement.ThirdElementWingman)
						{
							continue;
						}
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
							{
								ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_ThirdElementWingman);
							}
							break;
						}
						if (!Information.IsNothing(waypoint.Waypoint_ThirdElementWingman))
						{
							ArrayExtensions.Add(ref gparam_, waypoint.Waypoint_ThirdElementWingman);
						}
					}
				}
				if (gparam_.Count() > 0)
				{
					value.Navigator.PlottedCourse = gparam_;
					ExtendTimer = 0.0;
					((Aircraft)value).Navigator.HeadToFirstWaypoint(float_0);
					ExtendTimer = 0.0;
				}
				value.AI.EvaluateUnitStatus(0f, bool_0: false, bool_1: false);
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

	public void SetStrikeMissionOrUnassignedThrottle()
	{
		try
		{
			if (Information.IsNothing(GetAircraft().AssignedMissionOrPackage()))
			{
				return;
			}
			ActiveUnit.Throttle throttle = ActiveUnit.Throttle.FullStop;
			if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				_ = (Strike)myUnit.AssignedMissionOrPackage();
				if (Information.IsNothing(GetAircraft().Loadout))
				{
					throttle = ActiveUnit.Throttle.Cruise;
				}
				else
				{
					throttle = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationThrottleSetting;
					if (throttle == ActiveUnit.Throttle.FullStop)
					{
						throttle = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress;
					}
				}
			}
			GetAircraft().SetThrottle(throttle);
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

	public void SetStrikeMissionOrUnassignedAltitude()
	{
		try
		{
			float num = 0f;
			bool bool_ = false;
			if (Information.IsNothing(GetAircraft().AssignedMissionOrPackage()))
			{
				if (GetAircraft().AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
				{
					num = 304.80002f;
					bool_ = false;
				}
			}
			else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				_ = (Strike)myUnit.AssignedMissionOrPackage();
				if (Information.IsNothing(GetAircraft().Loadout))
				{
					if (((Strike)myUnit.AssignedMissionOrPackage()).Type == Strike.StrikeType.Sub_Strike)
					{
						num = 304.80002f;
						bool_ = false;
					}
					else
					{
						Aircraft aircraft_ = GetAircraft();
						num = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_);
					}
				}
				else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
				{
					Aircraft aircraft_2 = GetAircraft();
					num = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_2, ActiveUnit.Throttle.Loiter, ref bool_);
				}
				else
				{
					Aircraft_AI aI = GetAircraft().AI;
					Aircraft aircraft_3 = GetAircraft();
					num = aI.PrintFacade(ref aircraft_3, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_);
				}
			}
			myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_);
			if (bool_)
			{
				myUnit.DesiredAltitude_AGL = num;
			}
			else
			{
				myUnit.DesiredAltitude = num;
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

	public void SetPatrolAltitude(bool bool_1, Aircraft_AirOps._AirOpsCondition _AirOpsCondition_0)
	{
		try
		{
			if (myUnit.Kinematics.DesiredAltitudeOverride || _AirOpsCondition_0 == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				return;
			}
			float float_ = 0f;
			bool bool_2 = false;
			float? nullable_ = null;
			bool bool_3 = false;
			Aircraft aircraft_;
			if (Information.IsNothing(GetAircraft().AssignedMissionOrPackage()))
			{
				if (Information.IsNothing(GetAircraft().Loadout))
				{
					float_ = 0f;
					bool_2 = false;
				}
				else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitude <= 0f)
				{
					if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						aircraft_ = GetAircraft();
						float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_2);
					}
					else
					{
						Aircraft_AI aI = GetAircraft().AI;
						aircraft_ = GetAircraft();
						float_ = aI.PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_2);
					}
				}
				else
				{
					float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitude;
					bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
				}
				nullable_ = null;
				bool_3 = false;
			}
			else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
				if (GetAircraft().IsOnActivePatrol && (myUnit.Navigator.IsInsidePatrolArea || bool_1))
				{
					if (Information.IsNothing(GetAircraft().Loadout))
					{
						float_ = 0f;
						bool_2 = false;
					}
					else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitude <= 0f)
					{
						if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
						{
							aircraft_ = GetAircraft();
							float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_2);
						}
						else
						{
							Aircraft_AI aI2 = GetAircraft().AI;
							aircraft_ = GetAircraft();
							float_ = aI2.PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_2);
						}
					}
					else
					{
						float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitude;
						bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
					}
					nullable_ = patrol.StationAltitude_Aircraft;
					bool_3 = patrol.StationTerrainFollowing_Aircraft;
				}
				else
				{
					if (Information.IsNothing(GetAircraft().Loadout))
					{
						float_ = 0f;
						bool_2 = false;
					}
					else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress <= 0f)
					{
						if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
						{
							aircraft_ = GetAircraft();
							float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_2);
						}
						else
						{
							float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
							bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
						}
					}
					else
					{
						float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
						bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
					}
					nullable_ = patrol.TransitAltitude_Aircraft;
					bool_3 = patrol.TransitTerrainFollowing_Aircraft;
				}
			}
			else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
			{
				MiningMission miningMission = (MiningMission)myUnit.AssignedMissionOrPackage();
				if (GetAircraft().IsOnActiveMiningMission && (DisableDic(ref miningMission.Area, ref miningMission.Area_5nm_Buffered, ref miningMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false) || bool_1))
				{
					if (Information.IsNothing(GetAircraft().Loadout))
					{
						float_ = 0f;
						bool_2 = false;
					}
					else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						aircraft_ = GetAircraft();
						float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_2);
					}
					else
					{
						Aircraft_AI aI3 = GetAircraft().AI;
						aircraft_ = GetAircraft();
						float_ = aI3.PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_2);
					}
					float? num = myUnit.AI.SetClient(float_);
					if (num.HasValue)
					{
						float? num2 = num;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > float_) : null).GetValueOrDefault())
						{
							float_ = num.Value;
						}
					}
					nullable_ = miningMission.StationAltitude_Aircraft;
					bool_3 = miningMission.StationTerrainFollowing_Aircraft;
				}
				else
				{
					if (Information.IsNothing(GetAircraft().Loadout))
					{
						float_ = 0f;
						bool_2 = false;
					}
					else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						aircraft_ = GetAircraft();
						float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_2);
					}
					else
					{
						float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
						bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
					}
					nullable_ = miningMission.TransitAltitude_Aircraft;
					bool_3 = miningMission.TransitTerrainFollowing_Aircraft;
				}
			}
			else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
			{
				MineClearingMission mineClearingMission = (MineClearingMission)myUnit.AssignedMissionOrPackage();
				if (GetAircraft().IsOnActiveMineClearingMission && (DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false) || bool_1))
				{
					if (Information.IsNothing(GetAircraft().Loadout))
					{
						float_ = 0f;
						bool_2 = false;
					}
					else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitude <= 0f)
					{
						if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
						{
							aircraft_ = GetAircraft();
							float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_2);
						}
						else
						{
							Aircraft_AI aI4 = GetAircraft().AI;
							aircraft_ = GetAircraft();
							float_ = aI4.PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_2);
						}
					}
					else
					{
						float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitude;
						bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
					}
					nullable_ = mineClearingMission.StationAltitude_Aircraft;
					bool_3 = mineClearingMission.StationTerrainFollowing_Aircraft;
				}
				else
				{
					if (Information.IsNothing(GetAircraft().Loadout))
					{
						float_ = 0f;
						bool_2 = false;
					}
					else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress <= 0f)
					{
						if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
						{
							aircraft_ = GetAircraft();
							float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_2);
						}
						else
						{
							Aircraft_AI aI5 = GetAircraft().AI;
							aircraft_ = GetAircraft();
							float_ = aI5.PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_2);
						}
					}
					else
					{
						float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
						bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
					}
					nullable_ = mineClearingMission.TransitAltitude_Aircraft;
					bool_3 = mineClearingMission.TransitTerrainFollowing_Aircraft;
				}
			}
			aircraft_ = GetAircraft();
			SetMissionAltitude(ref float_, ref bool_2, ref nullable_, ref bool_3, ref aircraft_);
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

	public void SetPatrolThrottle(bool bool_1, Aircraft_AirOps._AirOpsCondition _AirOpsCondition_0)
	{
		try
		{
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
				}
				else
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
				}
			}
			else
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue || _AirOpsCondition_0 == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || _AirOpsCondition_0 == Aircraft_AirOps._AirOpsCondition.TransferringCargo)
				{
					return;
				}
				ActiveUnit.Throttle throttle_ = ActiveUnit.Throttle.FullStop;
				ActiveUnit.Throttle? nullable_ = null;
				if (Information.IsNothing(GetAircraft().AssignedMissionOrPackage()))
				{
					if (Information.IsNothing(GetAircraft().Loadout))
					{
						throttle_ = ActiveUnit.Throttle.Loiter;
					}
					else
					{
						throttle_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationThrottleSetting;
						if (throttle_ == ActiveUnit.Throttle.FullStop)
						{
							throttle_ = ActiveUnit.Throttle.Loiter;
						}
					}
					nullable_ = null;
				}
				else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
					if (GetAircraft().IsOnActivePatrol && (myUnit.Navigator.IsInsidePatrolArea || bool_1))
					{
						if (Information.IsNothing(GetAircraft().Loadout))
						{
							throttle_ = ActiveUnit.Throttle.Loiter;
						}
						else
						{
							throttle_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationThrottleSetting;
							if (throttle_ == ActiveUnit.Throttle.FullStop)
							{
								throttle_ = ActiveUnit.Throttle.Loiter;
							}
						}
						nullable_ = patrol.StationThrottle_Aircraft;
					}
					else
					{
						throttle_ = (Information.IsNothing(GetAircraft().Loadout) ? ActiveUnit.Throttle.Cruise : GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
						nullable_ = patrol.TransitThrottle_Aircraft;
					}
				}
				else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
				{
					MiningMission miningMission = (MiningMission)myUnit.AssignedMissionOrPackage();
					if (GetAircraft().IsOnActiveMiningMission && (DisableDic(ref miningMission.Area, ref miningMission.Area_5nm_Buffered, ref miningMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false) || bool_1))
					{
						if (Information.IsNothing(GetAircraft().Loadout))
						{
							throttle_ = ActiveUnit.Throttle.Loiter;
						}
						else
						{
							throttle_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationThrottleSetting;
							if (throttle_ == ActiveUnit.Throttle.FullStop)
							{
								throttle_ = ActiveUnit.Throttle.Loiter;
							}
						}
						nullable_ = miningMission.StationThrottle_Aircraft;
					}
					else
					{
						throttle_ = (Information.IsNothing(GetAircraft().Loadout) ? ActiveUnit.Throttle.Cruise : GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
						nullable_ = miningMission.TransitThrottle_Aircraft;
					}
				}
				else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
				{
					MineClearingMission mineClearingMission = (MineClearingMission)myUnit.AssignedMissionOrPackage();
					if (GetAircraft().IsOnActiveMineClearingMission && (DisableDic(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, bool_1: false, bool_2: false) || bool_1))
					{
						if (Information.IsNothing(GetAircraft().Loadout))
						{
							throttle_ = ActiveUnit.Throttle.Loiter;
						}
						else
						{
							throttle_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationThrottleSetting;
							if (throttle_ == ActiveUnit.Throttle.FullStop)
							{
								throttle_ = ActiveUnit.Throttle.Loiter;
							}
						}
						nullable_ = mineClearingMission.StationThrottle_Aircraft;
					}
					else
					{
						throttle_ = (Information.IsNothing(GetAircraft().Loadout) ? ActiveUnit.Throttle.Cruise : GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
						nullable_ = mineClearingMission.TransitThrottle_Aircraft;
					}
				}
				else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Support)
				{
					SupportMission obj = (SupportMission)myUnit.AssignedMissionOrPackage();
					throttle_ = (Information.IsNothing(GetAircraft().Loadout) ? ActiveUnit.Throttle.Cruise : GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
					nullable_ = obj.TransitThrottle_Aircraft;
				}
				else if (GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
				{
					CargoMission cargoMission = (CargoMission)myUnit.AssignedMissionOrPackage();
					nullable_ = ((!GetAircraft().IsOnActiveCargoMission || cargoMission.Area.Count <= 0 || !(DisableDic(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 5, bool_1: false, bool_2: false) || bool_1)) ? new ActiveUnit.Throttle?(cargoMission.TransitThrottle_Aircraft) : new ActiveUnit.Throttle?(cargoMission.StationThrottle_Aircraft));
				}
				Aircraft aircraft_ = GetAircraft();
				SetMissionThrottle(ref throttle_, ref nullable_, ref aircraft_);
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

	public void SetInterceptAltitude(Aircraft_AirOps._AirOpsCondition _AirOpsCondition_0)
	{
		try
		{
			if ((myUnit.Kinematics.DesiredAltitudeOverride && (Information.IsNothing(myUnit.AssignedMissionOrPackage()) || (myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Patrol && (myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || !myUnit.AI.IsEscort)) || (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse && (!myUnit.IsGroupWingman() || Information.IsNothing(myUnit.GetParentGroup().GroupLead) || !myUnit.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))) || _AirOpsCondition_0 == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				return;
			}
			Aircraft_AirOps._AirOpsCondition airOpsCondition = _AirOpsCondition_0;
			if (airOpsCondition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || airOpsCondition == Aircraft_AirOps._AirOpsCondition.const_19 || airOpsCondition == Aircraft_AirOps._AirOpsCondition.Dogfight)
			{
				return;
			}
			bool bool_ = false;
			float float_;
			Aircraft aircraft_;
			if (Information.IsNothing(GetAircraft().Loadout))
			{
				float_ = 0f;
			}
			else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
			{
				aircraft_ = GetAircraft();
				float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_);
			}
			else
			{
				float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitude;
				bool_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
				if (float_ == 0f)
				{
					float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).AttackAltitudeIngress;
					bool_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).AttackAltitudeIngressTerrainFollowing;
				}
				if (float_ == 0f)
				{
					float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
					bool_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
				}
			}
			float? nullable_ = null;
			bool bool_2 = false;
			if (!Information.IsNothing(GetAircraft().AssignedMissionOrPackage()) && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
				float? num = null;
				float num2;
				if (Information.IsNothing(GetAircraft().AI.PrimaryTarget))
				{
					num2 = 0f;
				}
				else
				{
					Weapon weapon = null;
					Doctrine doctrine = myUnit.Doctrine;
					weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(GetAircraft().AI.PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, doctrine);
					num2 = (Information.IsNothing(weapon) ? 0f : weapon.GetMaxRangeForThisTarget(myUnit, GetAircraft().AI.PrimaryTarget, bool_0: true, doctrine, bool_1: false));
				}
				patrol = (Patrol)myUnit.AssignedMissionOrPackage();
				num = patrol.AttackDistance_Aircraft;
				float num3 = (Information.IsNothing(num) ? ((float)Math.Max(10f + num2, (double)num2 * 1.2)) : (num + num2).Value);
				if (Module_Unit.RangeToUnit_Horiz(myUnit, GetAircraft().AI.PrimaryTarget) <= num3)
				{
					nullable_ = patrol.AttackAltitude_Aircraft;
					bool_2 = patrol.AttackTerrainFollowing_Aircraft;
				}
				else
				{
					nullable_ = patrol.TransitAltitude_Aircraft;
					bool_2 = patrol.TransitTerrainFollowing_Aircraft;
				}
			}
			aircraft_ = GetAircraft();
			SetMissionAltitude(ref float_, ref bool_, ref nullable_, ref bool_2, ref aircraft_);
			if (myUnit.AI.PrimaryTarget.IsAir_Missile_Orbital_Contact && myUnit.AI.PrimaryTarget.AltitudeIsKnown && myUnit.AI.PrimaryTarget.GetCurrentAltitude() > myUnit.DesiredAltitude)
			{
				myUnit.DesiredAltitude = myUnit.AI.PrimaryTarget.GetCurrentAltitude();
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

	public void SetInterceptThrottle(float float_0, float? nullable_0, bool bool_1, Aircraft_AirOps._AirOpsCondition _AirOpsCondition_0)
	{
		try
		{
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue && (Information.IsNothing(myUnit.AssignedMissionOrPackage()) || (myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Patrol && (myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Strike || !myUnit.AI.IsEscort)) || (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse && (!myUnit.IsGroupWingman() || Information.IsNothing(myUnit.GetParentGroup().GroupLead) || !myUnit.GetParentGroup().GroupLead.Navigator.IsOnAutoPlannerPlottedCourse))))
			{
				if (myUnit.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
				}
				else
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
				}
			}
			else
			{
				if (_AirOpsCondition_0 == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
				{
					return;
				}
				if (!Information.IsNothing(GetAircraft().AssignedMissionOrPackage()) && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
					bool? flag;
					if (Information.IsNothing(patrol.AttackThrottle_Aircraft))
					{
						flag = false;
					}
					else
					{
						byte? b = (byte?)patrol.AttackThrottle_Aircraft;
						flag = (b.HasValue ? new bool?(b.GetValueOrDefault() != 0) : null);
					}
					bool? flag2 = flag;
					if (flag2.GetValueOrDefault(true) && !Information.IsNothing(patrol.AttackDistance_Aircraft) && flag2.HasValue)
					{
						float? num = null;
						float num2;
						if (Information.IsNothing(GetAircraft().AI.PrimaryTarget))
						{
							num2 = 0f;
						}
						else
						{
							Weapon weapon = null;
							Doctrine doctrine = myUnit.Doctrine;
							weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(GetAircraft().AI.PrimaryTarget, bool_1: false, bool_2: false, bool_3: true, doctrine);
							num2 = (Information.IsNothing(weapon) ? 0f : weapon.GetMaxRangeForThisTarget(myUnit, GetAircraft().AI.PrimaryTarget, bool_0: true, doctrine, bool_1: false));
						}
						patrol = (Patrol)myUnit.AssignedMissionOrPackage();
						num = patrol.AttackDistance_Aircraft;
						float num3 = (Information.IsNothing(num) ? ((float)Math.Max(10f + num2, (double)num2 * 1.2)) : (num + num2).Value);
						if (Module_Unit.RangeToUnit_Horiz(myUnit, GetAircraft().AI.PrimaryTarget) <= num3)
						{
							myUnit.SetThrottle(patrol.AttackThrottle_Aircraft.Value);
							return;
						}
						if (!Information.IsNothing(patrol.TransitThrottle_Aircraft))
						{
							byte? b2 = (byte?)patrol.TransitThrottle_Aircraft;
							if ((b2.HasValue ? new bool?(b2.GetValueOrDefault() != 0) : null).GetValueOrDefault())
							{
								myUnit.SetThrottle(patrol.TransitThrottle_Aircraft.Value);
								return;
							}
						}
					}
				}
				Aircraft_AI aI = GetAircraft().AI;
				Contact primaryTarget = myUnit.AI.PrimaryTarget;
				float currentAltitude = myUnit.GetCurrentAltitude();
				float currentHeading = myUnit.CurrentHeading;
				float? nullable_ = 0f;
				bool bool_2 = true;
				if (aI.CanInterceptTarget(primaryTarget, null, currentAltitude, null, currentHeading, ActiveUnit.Throttle.Full, nullable_, bool_0: false, bool_1: false, ref bool_2))
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Full);
					if (bool_1 && myUnit.Kinematics.CanApplyFlankThrottle())
					{
						Aircraft_AI aI2 = GetAircraft().AI;
						Contact primaryTarget2 = myUnit.AI.PrimaryTarget;
						float currentAltitude2 = myUnit.GetCurrentAltitude();
						float currentHeading2 = myUnit.CurrentHeading;
						float? nullable_2 = 0f;
						bool_2 = true;
						if (aI2.CanInterceptTarget(primaryTarget2, null, currentAltitude2, null, currentHeading2, ActiveUnit.Throttle.Flank, nullable_2, bool_0: false, bool_1: false, ref bool_2))
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						}
					}
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100390", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal ActiveUnit.Throttle CollectProxy()
	{
		try
		{
			ActiveUnit.Throttle? throttle = null;
			if (!Information.IsNothing(GetAircraft().AssignedMissionOrPackage()))
			{
				Mission mission = GetAircraft().AssignedMissionOrPackage();
				Aircraft aircraft_ = GetAircraft();
				throttle = mission.PushValue(ref aircraft_);
			}
			byte? b;
			if (Information.IsNothing(GetAircraft().Loadout))
			{
				if (!Information.IsNothing(throttle))
				{
					b = (byte?)throttle;
					if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						goto IL_0180;
					}
				}
				throttle = ActiveUnit.Throttle.Cruise;
			}
			else
			{
				if (!Information.IsNothing(throttle))
				{
					b = (byte?)throttle;
					if (!(b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null).GetValueOrDefault())
					{
						goto IL_0180;
					}
				}
				throttle = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseThrottleSettingEgress;
			}
			goto IL_0180;
			IL_0180:
			if (Information.IsNothing(throttle))
			{
				throttle = ActiveUnit.Throttle.Cruise;
			}
			b = (byte?)throttle;
			byte maxPossibleThrottleSetting = (byte)GetAircraft().MaxPossibleThrottleSetting;
			if ((b.HasValue ? new bool?((uint)b.GetValueOrDefault() > (uint)maxPossibleThrottleSetting) : null).GetValueOrDefault())
			{
				throttle = GetAircraft().MaxPossibleThrottleSetting;
			}
			return throttle.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101376", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return ActiveUnit.Throttle.Cruise;
		}
	}

	internal float OrderProxy(ref bool bool_1)
	{
		try
		{
			float? num = null;
			if (GetAircraft().AssignedMissionOrPackage() != null)
			{
				Mission mission = GetAircraft().AssignedMissionOrPackage();
				Aircraft aircraft_ = GetAircraft();
				num = mission.NewValue(ref aircraft_, ref bool_1);
			}
			if (GetAircraft().Loadout != null && GetAircraft().Loadout.GetMissionProfile(GetAircraft().ParentScen) != null)
			{
				if (!num.HasValue)
				{
					if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						Aircraft aircraft_2 = GetAircraft();
						num = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_2, ActiveUnit.Throttle.Cruise, ref bool_1);
					}
					else
					{
						num = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeEgress;
						bool_1 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeEgressTerrainFollowing;
					}
				}
				if (!num.HasValue)
				{
					Aircraft aircraft_3 = GetAircraft();
					num = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_3, ActiveUnit.Throttle.Cruise, ref bool_1);
				}
			}
			else if (!num.HasValue)
			{
				Aircraft aircraft_4 = GetAircraft();
				num = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_4, ActiveUnit.Throttle.Cruise, ref bool_1);
			}
			float maximumAltitude = GetAircraft().Kinematics.GetMaximumAltitude();
			if (num.HasValue && num.Value > maximumAltitude)
			{
				num = maximumAltitude;
			}
			return num.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101377", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return 0f;
		}
	}

	public override void FollowSupportMissionCourse(float float_0, bool bool_1)
	{
		try
		{
			if (myUnit.AssignedMissionOrPackage() == null || myUnit.AssignedMissionOrPackage().MissionClass != Mission._MissionClass.Support)
			{
				return;
			}
			base.FollowSupportMissionCourse(float_0, bool_1);
			SupportMission supportMission = (SupportMission)myUnit.AssignedMissionOrPackage();
			Aircraft aircraft_;
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				ActiveUnit.Throttle throttle_;
				ActiveUnit.Throttle? nullable_;
				if (bool_1)
				{
					throttle_ = ((GetAircraft().Loadout == null) ? ActiveUnit.Throttle.Cruise : GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
					nullable_ = supportMission.TransitThrottle_Aircraft;
				}
				else
				{
					if (GetAircraft().Loadout == null)
					{
						throttle_ = ActiveUnit.Throttle.Loiter;
					}
					else
					{
						throttle_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).StationThrottleSetting;
						if (throttle_ == ActiveUnit.Throttle.FullStop)
						{
							throttle_ = ActiveUnit.Throttle.Loiter;
						}
					}
					nullable_ = supportMission.StationThrottle_Aircraft;
				}
				aircraft_ = GetAircraft();
				SetMissionThrottle(ref throttle_, ref nullable_, ref aircraft_);
			}
			if (myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			bool bool_2 = false;
			float float_;
			float? nullable_2;
			bool bool_3;
			if (bool_1)
			{
				if (GetAircraft().Loadout == null)
				{
					float_ = 0f;
					bool_2 = false;
				}
				else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
				{
					aircraft_ = GetAircraft();
					float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Cruise, ref bool_2);
				}
				else
				{
					float_ = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
					bool_2 = GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
				}
				nullable_2 = supportMission.TransitAltitude_Aircraft;
				bool_3 = supportMission.TransitTerrainFollowing_Aircraft;
			}
			else
			{
				if (GetAircraft().Loadout == null)
				{
					float_ = 0f;
					bool_2 = false;
				}
				else if (GetAircraft().Loadout.GetMissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
				{
					aircraft_ = GetAircraft();
					float_ = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, ActiveUnit.Throttle.Loiter, ref bool_2);
				}
				else
				{
					Aircraft_AI aI = GetAircraft().AI;
					aircraft_ = GetAircraft();
					float_ = aI.PrintFacade(ref aircraft_, ActiveUnit.Throttle.Cruise, bool_0: true, ref bool_2);
				}
				nullable_2 = supportMission.StationAltitude_Aircraft;
				bool_3 = supportMission.StationTerrainFollowing_Aircraft;
			}
			aircraft_ = GetAircraft();
			SetMissionAltitude(ref float_, ref bool_2, ref nullable_2, ref bool_3, ref aircraft_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101378", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetMissionAltitude(ref float float_0, ref bool bool_1, ref float? nullable_0, ref bool bool_2, ref Aircraft aircraft_0)
	{
		try
		{
			if (myUnit.Kinematics.DesiredAltitudeOverride || aircraft_0.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				return;
			}
			if (nullable_0.HasValue)
			{
				myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_2);
				if (bool_2)
				{
					myUnit.DesiredAltitude_AGL = nullable_0.Value;
				}
				else
				{
					myUnit.DesiredAltitude = nullable_0.Value;
				}
			}
			else if (Information.IsNothing(aircraft_0.Loadout))
			{
				ActiveUnit activeUnit = myUnit;
				Aircraft aircraft_ = GetAircraft();
				ActiveUnit.Throttle throttleSetting = myUnit.ThrottleSetting;
				ActiveUnit activeUnit2 = myUnit;
				ActiveUnit activeUnit_;
				bool desiredAltitude_UseTerrainFollowing = activeUnit2.GetDesiredAltitude_UseTerrainFollowing(activeUnit_ = myUnit);
				float desiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_, throttleSetting, ref desiredAltitude_UseTerrainFollowing);
				activeUnit2.SetDesiredAltitude_UseTerrainFollowing(activeUnit_, desiredAltitude_UseTerrainFollowing);
				activeUnit.DesiredAltitude = desiredAltitude;
			}
			else if (float_0 <= 0f)
			{
				Aircraft obj = aircraft_0;
				Aircraft aircraft_2 = GetAircraft();
				ActiveUnit.Throttle throttleSetting2 = myUnit.ThrottleSetting;
				ActiveUnit activeUnit3 = myUnit;
				ActiveUnit activeUnit_2;
				bool desiredAltitude_UseTerrainFollowing2 = activeUnit3.GetDesiredAltitude_UseTerrainFollowing(activeUnit_2 = myUnit);
				float desiredAltitude2 = Aircraft_AI.MostRealisticOptimumAltitude(ref aircraft_2, throttleSetting2, ref desiredAltitude_UseTerrainFollowing2);
				activeUnit3.SetDesiredAltitude_UseTerrainFollowing(activeUnit_2, desiredAltitude_UseTerrainFollowing2);
				obj.DesiredAltitude = desiredAltitude2;
			}
			else
			{
				myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_1);
				if (bool_1)
				{
					aircraft_0.DesiredAltitude_AGL = float_0;
				}
				else
				{
					aircraft_0.DesiredAltitude = float_0;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101379", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetMissionThrottle(ref ActiveUnit.Throttle throttle_0, ref ActiveUnit.Throttle? nullable_0, ref Aircraft aircraft_0)
	{
		try
		{
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
				}
				else
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
				}
			}
			else
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue || aircraft_0.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
				{
					return;
				}
				if (nullable_0.HasValue)
				{
					aircraft_0.SetThrottle(nullable_0.Value);
				}
				else if (aircraft_0.Loadout == null)
				{
					if ((int)myUnit.ThrottleSetting < 2)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					float num = aircraft_0.Kinematics.GetMaximumSpeed(aircraft_0.GetCurrentAltitude(), aircraft_0.ThrottleSetting, bool_0: false);
					if (myUnit.CurrentSpeed < num)
					{
						myUnit.DesiredSpeed = num;
					}
				}
				else
				{
					aircraft_0.SetThrottle(throttle_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101380", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool CurrentFlightHasStandoffWeaponFiringPoint()
	{
		if (base.HasFlightPlan)
		{
			return GetFlight().FlightPlan.Where((Waypoint theFP) => theFP.Type == Waypoint.WaypointType.WeaponLaunch).FirstOrDefault() != null;
		}
		return false;
	}

	public bool HasReachedStandoffWeaponFiringPoint()
	{
		if (base.HasFlightPlan)
		{
			if (DistanceFromStandioffWeaponFiringPoint() < 3.0 && HasPlottedCourse() && base.PlottedCourse[0].Type == Waypoint.WaypointType.WeaponLaunch)
			{
				return true;
			}
			if (base.PlottedCourse != null)
			{
				try
				{
					Waypoint waypoint = null;
					if (base.PlottedCourse != null && (base.PlottedCourse.Count() != 0 || !myUnit.IsGroupMember()))
					{
						if (base.PlottedCourse.Count() > 0)
						{
							waypoint = GetFlight().FlightPlan.Where((Waypoint waypoint_0) => Operators.CompareString(waypoint_0.ObjectID, base.PlottedCourse[0].ObjectID, TextCompare: false) == 0).FirstOrDefault();
						}
					}
					else if (myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse != null && myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse.Count() > 0)
					{
						waypoint = GetFlight().FlightPlan.Where((Waypoint waypoint_0) => Operators.CompareString(waypoint_0.ObjectID, myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse[0].ObjectID, TextCompare: false) == 0).FirstOrDefault();
					}
					Waypoint waypoint2 = GetFlight().FlightPlan.Where((Waypoint theFP) => theFP.Type == Waypoint.WaypointType.WeaponLaunch).FirstOrDefault();
					if (waypoint != null && waypoint2 != null)
					{
						int num = GetFlight().FlightPlan.ToList().IndexOf(waypoint2);
						if (GetFlight().FlightPlan.ToList().IndexOf(waypoint) > num)
						{
							return true;
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					return false;
				}
			}
			return false;
		}
		return false;
	}

	public double DistanceFromStandioffWeaponFiringPoint()
	{
		Waypoint waypoint = GetFlight().InterruptInterruptibleQueue(myUnit.FlightRole, Waypoint.WaypointType.WeaponLaunch);
		if (waypoint == null)
		{
			return double.MaxValue;
		}
		return Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), waypoint.Latitude, waypoint.Longitude);
	}

	public bool HasReachedLandingAssemblyPoint(ActiveUnit activeUnit_0)
	{
		if (base.PlottedCourse != null && base.PlottedCourse.Count() > 0 && base.PlottedCourse[0].Type != Waypoint.WaypointType.LandingMarshal)
		{
			return false;
		}
		if (Information.IsNothing(activeUnit_0))
		{
			return false;
		}
		return DistanceFromLandingAssemblyPoint(activeUnit_0) < 3.0;
	}

	public double DistanceFromLandingAssemblyPoint(ActiveUnit activeUnit_0)
	{
		if (GetAircraft().CanLandVertically)
		{
			return Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), activeUnit_0.GetLatitude(), activeUnit_0.GetLongitude());
		}
		Geopoint_Struct landingQueueAssemblyPoint = activeUnit_0.AirOps.LandingQueueAssemblyPoint;
		return Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude);
	}

	public void HeadToLandingAssemblyPoint(float float_0, ActiveUnit activeUnit_0, float float_1, float float_2, ref bool bool_1)
	{
		if (Information.IsNothing(activeUnit_0) || Information.IsNothing(activeUnit_0.AirOps))
		{
			return;
		}
		try
		{
			Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
			if (HasPlottedCourse())
			{
				geopoint_Struct.Latitude = base.PlottedCourse[0].Latitude;
				geopoint_Struct.Longitude = base.PlottedCourse[0].Longitude;
				FollowPlottedCourse(float_0);
			}
			else if (GetAircraft().CanLandVertically)
			{
				geopoint_Struct.Latitude = activeUnit_0.GetLatitude();
				geopoint_Struct.Longitude = activeUnit_0.GetLongitude();
			}
			else
			{
				geopoint_Struct = activeUnit_0.AirOps.LandingQueueAssemblyPoint;
			}
			myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), geopoint_Struct.Latitude, geopoint_Struct.Longitude));
			Waypoint waypoint_ = null;
			ExtendIfNecessary(float_0, ref waypoint_, geopoint_Struct.Latitude, geopoint_Struct.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			if (bool_0 && !base.PathFindingInProgress && !base.HasPathfindingPlottedCourse)
			{
				double latitude = myUnit.GetLatitude();
				double longitude = myUnit.GetLongitude();
				double latitude2 = geopoint_Struct.Latitude;
				double longitude2 = geopoint_Struct.Longitude;
				int int_ = 0;
				GeoPoint geoPoint_ = null;
				if (PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, bool_1: true, 0f, bool_2: true, null, bool_3: true, bool_4: false, bool_5: false, null, ref int_, ref geoPoint_))
				{
					TriggerPathfinderThread(null, myUnit, null, bool_1: false, 0.15f, geopoint_Struct.Latitude, geopoint_Struct.Longitude, myUnit.ParentScen, bool_2: false);
				}
			}
			myUnit.DesiredSpeed = float_1;
			myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.GetCurrentAltitude(), (int)Math.Round(myUnit.DesiredSpeed)));
			myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_1);
			if (bool_1)
			{
				myUnit.DesiredAltitude_AGL = float_2;
			}
			else
			{
				myUnit.DesiredAltitude = float_2;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100464", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EgressToRejoinPoint(float float_0, bool bool_1)
	{
		try
		{
			if (Information.IsNothing(myUnit.AssignedMissionOrPackage()))
			{
				return;
			}
			if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !myUnit.AI.IsEscort)
			{
				byte? b = (byte?)myUnit.Doctrine.GetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false);
				bool? flag = (b.HasValue ? new bool?(b.GetValueOrDefault() == 0) : null);
				if (((!flag) ?? flag).GetValueOrDefault())
				{
					myUnit.Doctrine.SetIgnorePlottedCourse(myUnit.ParentScen, bool_0: false, null, bool_1: false, bool_2: false, Doctrine._UseIgnorePlottedCourse.No);
				}
			}
			if (GetAircraft().IsGroupWingman() && (!GetAircraft().IsGroupWingman() || !GetAircraft().Navigator.HasPlottedCourse()))
			{
				if (!GetAircraft().Navigator.HasPlottedCourse())
				{
					GetAircraft().Navigator.HeadToFormationStation(float_0);
				}
				return;
			}
			List<Waypoint> list_ = base.PlottedCourse.ToList();
			EgressToRejoinPoint_RemoveWaypoints(ref list_, bool_1, bool_2: false);
			GetAircraft().AirOps.SwitchToNearestWaypoint(ref list_, bool_1, bool_1: false);
			if (myUnit.Navigator.HasFlight)
			{
				myUnit.Navigator.GetFlight().SetStatus(myUnit.ParentScen, Mission._FlightStatus.Airborne_EgressLeg);
			}
			HeadToFirstWaypoint(float_0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100465", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EgressToRejoinPoint_RemoveWaypoints(ref List<Waypoint> list_0, bool bool_1, bool bool_2)
	{
		try
		{
			List<Waypoint> list = new List<Waypoint>();
			if (Information.IsNothing(list_0) || list_0.Count <= 1)
			{
				return;
			}
			if (GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse_HasObjectiveWaypoints)
			{
				int num = list_0.Count - 1;
				Contact contact = null;
				for (int i = 0; i <= num; i++)
				{
					Waypoint waypoint_ = list_0[i];
					if (waypoint_.Type == Waypoint.WaypointType.PathfindingPoint)
					{
						list.Add(waypoint_);
						continue;
					}
					if (waypoint_.Type == Waypoint.WaypointType.PatrolStation)
					{
						list.Add(waypoint_);
						continue;
					}
					if (waypoint_.Type != Waypoint.WaypointType.Split && waypoint_.Type != Waypoint.WaypointType.InitialPoint && waypoint_.Type != Waypoint.WaypointType.WeaponLaunch && waypoint_.Type != Waypoint.WaypointType.Target && waypoint_.Type != Waypoint.WaypointType.WeaponTarget && waypoint_.Type != Waypoint.WaypointType.StrikeIngress && waypoint_.Type != Waypoint.WaypointType.TurningPoint && waypoint_.Type != Waypoint.WaypointType.Refuel && !waypoint_.IncludeReponse())
					{
						if (bool_1)
						{
							if (!bool_2)
							{
								ApplyWaypointSpeedAltToUnit(waypoint_);
								ApplyWaypointDoctrineToUnit(waypoint_);
								AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_);
							}
							if (!list.Contains(waypoint_))
							{
								list.Add(waypoint_);
							}
						}
					}
					else
					{
						if (!bool_2)
						{
							ApplyWaypointSpeedAltToUnit(waypoint_);
							ApplyWaypointDoctrineToUnit(waypoint_);
							AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_);
						}
						if (!list.Contains(waypoint_))
						{
							list.Add(waypoint_);
						}
					}
					if (waypoint_.Type != Waypoint.WaypointType.Target && waypoint_.Type != Waypoint.WaypointType.WeaponTarget)
					{
						if (waypoint_.Type == Waypoint.WaypointType.StationEnd)
						{
							if (!bool_2 && (GetAircraft().FuelState == ActiveUnit._ActiveUnitFuelState.IsBingo || GetAircraft().FuelState == ActiveUnit._ActiveUnitFuelState.IsJoker))
							{
								GetAircraft().DisconnectTankerClients();
							}
							break;
						}
						continue;
					}
					float num3 = 0f;
					float num4 = (Information.IsNothing(GetAircraft().AI.PrimaryTarget) ? Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), waypoint_.Latitude, waypoint_.Longitude) : Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), GetAircraft().AI.PrimaryTarget.GetLatitude(), GetAircraft().AI.PrimaryTarget.GetLongitude()));
					if (bool_2)
					{
						num3 = num4;
					}
					else
					{
						foreach (ActiveUnit value in GetAircraft().ParentScen.ActiveUnits.Values)
						{
							if (value == null || !value.IsWeapon)
							{
								continue;
							}
							Weapon weapon = (Weapon)value;
							if (weapon.FiringParent == GetAircraft() && !Information.IsNothing(weapon.AI.PrimaryTarget) && (weapon.AI.PrimaryTarget.IsShipContact || weapon.AI.PrimaryTarget.IsGroundContact))
							{
								float num5 = Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), weapon.AI.PrimaryTarget.GetLatitude(), weapon.AI.PrimaryTarget.GetLongitude());
								if (!(num5 <= num3))
								{
									num3 = num5;
									contact = weapon.AI.PrimaryTarget;
									break;
								}
							}
						}
					}
					if ((num3 <= 0f || Information.IsNothing(contact)) && !bool_2)
					{
						break;
					}
					ActiveUnit actualDestinationHost = GetAircraft().AirOps.ActualDestinationHost;
					float num6 = (Information.IsNothing(actualDestinationHost) ? 0f : Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), actualDestinationHost.GetLatitude(), actualDestinationHost.GetLongitude()));
					int num7 = list_0.Count - 1;
					for (int j = 0; j <= num7; j++)
					{
						Waypoint waypoint_2 = list_0[j];
						if (list.Contains(waypoint_2) || (waypoint_2.Type != Waypoint.WaypointType.StrikeEgress && waypoint_2.Type != Waypoint.WaypointType.TurningPoint && waypoint_2.Type != Waypoint.WaypointType.Refuel))
						{
							continue;
						}
						float num8 = Math2.VerifyClass(GetAircraft().GetLatitude(), GetAircraft().GetLongitude(), waypoint_2.Latitude, waypoint_2.Longitude);
						if ((Information.IsNothing(contact) ? Math2.VerifyClass(waypoint_2.Latitude, waypoint_2.Longitude, waypoint_.Latitude, waypoint_.Longitude) : Math2.VerifyClass(waypoint_2.Latitude, waypoint_2.Longitude, contact.GetLatitude(), contact.GetLongitude())) < num3 && num8 < num3 + 10f)
						{
							if (!bool_2)
							{
								ApplyWaypointSpeedAltToUnit(waypoint_2);
								ApplyWaypointDoctrineToUnit(waypoint_2);
								AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_2);
							}
							if (!list.Contains(waypoint_2))
							{
								list.Add(waypoint_2);
							}
							continue;
						}
						if ((Information.IsNothing(myUnit.AI.PrimaryTarget) ? 0f : Math2.VerifyClass(waypoint_2.Latitude, waypoint_2.Longitude, myUnit.AI.PrimaryTarget.GetLatitude(), myUnit.AI.PrimaryTarget.GetLongitude())) < num4 && num8 < num4 + 10f)
						{
							if (!bool_2)
							{
								ApplyWaypointSpeedAltToUnit(waypoint_2);
								ApplyWaypointDoctrineToUnit(waypoint_2);
								AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_2);
							}
							if (!list.Contains(waypoint_2))
							{
								list.Add(waypoint_2);
							}
							continue;
						}
						if (bool_2 || Information.IsNothing(actualDestinationHost))
						{
							break;
						}
						float num9 = Math2.VerifyClass(waypoint_2.Latitude, waypoint_2.Longitude, actualDestinationHost.GetLatitude(), actualDestinationHost.GetLongitude());
						if (!(num8 < num9) || !(num6 < num9 + 10f))
						{
							break;
						}
						if (!bool_2)
						{
							ApplyWaypointSpeedAltToUnit(waypoint_2);
							ApplyWaypointDoctrineToUnit(waypoint_2);
							AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_2);
						}
						if (!list.Contains(waypoint_2))
						{
							list.Add(waypoint_2);
						}
					}
					break;
				}
				if (bool_2)
				{
					foreach (Waypoint item in list)
					{
						list_0.Remove(item);
					}
					return;
				}
				{
					foreach (Waypoint item2 in list)
					{
						list_0.Remove(item2);
						ApplyWaypointSpeedAltToUnit(item2);
						ApplyWaypointDoctrineToUnit(item2);
						RemoveWaypoint_Soft(item2, bool_1: false);
					}
					return;
				}
			}
			if (!GetAircraft().Navigator.IsOnAutoPlannerPlottedCourse || (!Information.IsNothing(GetAircraft().AssignedMissionOrPackage()) && GetAircraft().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !GetAircraft().AI.IsEscort))
			{
				return;
			}
			Waypoint waypoint = null;
			Waypoint waypoint2 = null;
			float num10 = 0f;
			float num2 = 0f;
			int count = list_0.Count;
			Waypoint waypoint3 = list_0[count - 1];
			for (int k = count - 1; k >= 0; k += -1)
			{
				Waypoint waypoint4 = list_0[k];
				if (waypoint4.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					list.Add(waypoint4);
					continue;
				}
				if (waypoint4.Type == Waypoint.WaypointType.Land)
				{
					waypoint = waypoint4;
					continue;
				}
				if (waypoint4.Type == Waypoint.WaypointType.LandingMarshal)
				{
					waypoint = waypoint4;
					waypoint3 = waypoint4;
					continue;
				}
				waypoint2 = ((k <= 0) ? new Waypoint(myUnit.GetLongitude(), myUnit.GetLatitude(), 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan) : list_0[k - 1]);
				num2 = ((num2 == 0f) ? Math2.VerifyClass(waypoint4.Latitude, waypoint4.Longitude, waypoint3.Latitude, waypoint3.Longitude) : num10);
				num10 = Math2.VerifyClass(waypoint2.Latitude, waypoint2.Longitude, waypoint3.Latitude, waypoint3.Longitude);
				if (!(num2 < num10))
				{
					break;
				}
				waypoint = waypoint4;
			}
			if (Information.IsNothing(waypoint))
			{
				return;
			}
			List<Waypoint> list2 = new List<Waypoint>();
			foreach (Waypoint item3 in list_0)
			{
				if (waypoint != item3)
				{
					list2.Add(item3);
					continue;
				}
				break;
			}
			if (bool_2)
			{
				foreach (Waypoint item4 in list2)
				{
					list_0.Remove(item4);
				}
				return;
			}
			foreach (Waypoint item5 in list2)
			{
				list_0.Remove(item5);
				ApplyWaypointSpeedAltToUnit(item5);
				ApplyWaypointDoctrineToUnit(item5);
				RemoveWaypoint_Soft(item5, bool_1: false);
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

	public override bool EgressToRejoinPoint_CallOff(float float_0)
	{
		try
		{
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
			{
				return false;
			}
			if (Information.IsNothing(myUnit.AssignedMissionOrPackage()))
			{
				return false;
			}
			if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				bool flag = false;
				if (myUnit.IsGroupMember())
				{
					foreach (ActiveUnit value in myUnit.GetParentGroup().Units.Values)
					{
						if (value != myUnit && value.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
						{
							flag = true;
							break;
						}
					}
				}
				ActiveUnit activeUnit = null;
				if (!flag)
				{
					if (myUnit.IsGroupWingman() && (!myUnit.IsGroupWingman() || !myUnit.Navigator.HasPlottedCourse()))
					{
						if (Information.IsNothing(myUnit.GetParentGroup().GroupLead))
						{
							return false;
						}
						if (myUnit.GetParentGroup().GroupLead.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
						{
							flag = true;
						}
						else
						{
							activeUnit = myUnit.GetParentGroup().GroupLead;
						}
					}
					else
					{
						activeUnit = myUnit;
					}
				}
				if (!flag)
				{
					if (activeUnit == null)
					{
						return false;
					}
					if (!activeUnit.Navigator.HasPlottedCourse())
					{
						return false;
					}
					Waypoint waypoint = activeUnit.Navigator.PlottedCourse[0];
					if (waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponTarget && waypoint.Type != Waypoint.WaypointType.InitialPoint && waypoint.Type != Waypoint.WaypointType.WeaponLaunch)
					{
						return false;
					}
					DateTime? previousWaypointTime = activeUnit.Navigator.PreviousWaypointTime;
					if (Information.IsNothing(previousWaypointTime))
					{
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						activeUnit.Navigator.PreviousWaypointTime = activeUnit.ParentScen.Time;
					}
					else
					{
						DateTime? dateTime = null;
						if (Information.IsNothing(previousWaypointTime))
						{
							if (!Information.IsNothing(waypoint.Time_Zulu))
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								dateTime = waypoint.Time_Zulu;
							}
						}
						else
						{
							dateTime = previousWaypointTime.Value.AddSeconds(waypoint.Leg_Time_Straight + waypoint.Leg_Time_Turn + waypoint.Hold_Time + waypoint.Station_Time + waypoint.SpacingManeuver_Time);
						}
						if (Information.IsNothing(dateTime))
						{
							return false;
						}
						dateTime = dateTime.Value.AddSeconds(120.0);
						DateTime time = activeUnit.ParentScen.Time;
						if ((dateTime.HasValue ? new bool?(DateTime.Compare(time, dateTime.GetValueOrDefault()) >= 0) : null).GetValueOrDefault())
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					string text = "";
					if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, TextCompare: false) != 0)
					{
						text = " (" + myUnit.UnitClass + ")";
					}
					myUnit.AddMessage(myUnit.Name + text + "没有完成它的攻击，但燃料的危险性却很低。以最佳高度和速度呼叫并返回基地。", myUnit.Name + " 取消", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
					myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
					if (!Information.IsNothing(myUnit.AssignedMissionOrPackage()))
					{
						Strike strike = (Strike)GetAircraft().AssignedMissionOrPackage();
						if (strike.BingoFuel == Mission._BingoFuelSetting.UseLoadoutSetting)
						{
							if (!Information.IsNothing(GetAircraft().Loadout) && GetAircraft().Loadout.GetMissionProfile(GetAircraft().ParentScen).DropBombsAtMaxRange)
							{
								GetAircraft().Weaponry.JettisonOrdnance(bool_1: true, bool_2: false, bool_3: true, bool_4: true, bool_5: false, bool_6: false, bool_7: false);
								myUnit.AddMessage(myUnit.Name + text + " had to jettison its air-to-ground ordnance or else it would not have enough fuel to get back to base due to the increased fuel burn rate caused by the payload weight and drag. To avoid this situation, change the mission 'Fuel/Ordnance' setting to 'Bring A/G ordnance back to base if target cannot be struck'. The extra payload weight and drag on the return leg will then be taken into account when estimating Bingo Fuel. Note that this will reduce the maximum strike radius, since the flightplan generator will take the increased fuel burn rate on the return leg into account.", myUnit.Name + " jettisoned A2G", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							}
						}
						else if (strike.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
						{
							myUnit.AddMessage(myUnit.Name + text + " had to jettison its air-to-ground ordnance or else it would not have enough fuel to get back to base due to the increased fuel burn rate caused by the payload weight and drag. To avoid this situation, change the mission 'Fuel/Ordnance' setting to 'Bring A/G ordnance back to base if target cannot be struck'. The extra payload weight and drag on the return leg will then be taken into account when estimating Bingo Fuel. Note that this will reduce the maximum strike radius, since the flightplan generator will take the increased fuel burn rate on the return leg into account.", myUnit.Name + " jettisoned A2G", LoggedMessage.MessageType.AirOps, 0, bool_0: false, new Geopoint_Struct(myUnit.GetLongitude(), myUnit.GetLatitude()));
							GetAircraft().Weaponry.JettisonOrdnance(bool_1: false, bool_2: false, bool_3: true, bool_4: true, bool_5: false, bool_6: false, bool_7: false);
						}
					}
					if (myUnit.Navigator.HasPlottedCourse())
					{
						ActiveUnit.Throttle throttle = GetAircraft().Navigator.CollectProxy();
						Aircraft_Navigator navigator = GetAircraft().Navigator;
						bool bool_ = false;
						float num = navigator.OrderProxy(ref bool_);
						float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
						if (num > maximumAltitude)
						{
							num = maximumAltitude;
						}
						int maximumSpeed = myUnit.Kinematics.GetMaximumSpeed(num, throttle, bool_0: false);
						Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
						Waypoint[] array = plottedCourse;
						foreach (Waypoint waypoint2 in array)
						{
							if (waypoint2.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
							{
								waypoint2.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)throttle;
							}
							waypoint2.DesiredSpeed = maximumSpeed;
							waypoint2.DesiredSpeedOverride = maximumSpeed;
							waypoint2.TerrainFollowing = false;
							waypoint2.DesiredAltitudeOverride = true;
							waypoint2.DesiredAltitude = num;
							waypoint2.DesiredAltitude_TerrainFollowing = null;
							waypoint2.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
						}
					}
					else
					{
						if (!Information.IsNothing(myUnit.Kinematics.DesiredSpeedOverride))
						{
							myUnit.Kinematics.DesiredSpeedOverride = null;
						}
						if (myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
						}
						myUnit.Kinematics.DesiredAltitudeOverride = false;
						myUnit.SetDesiredAltitude_UseTerrainFollowing(myUnit, bool_0: false);
					}
					myUnit.Navigator.EgressToRejoinPoint(float_0, bool_1: false);
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 101381", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public void GlideToHomeBase(float float_0)
	{
		try
		{
			ActiveUnit actualDestinationHost = GetAircraft().AirOps.ActualDestinationHost;
			if (!Information.IsNothing(actualDestinationHost))
			{
				double num = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), actualDestinationHost.GetLatitude(), actualDestinationHost.GetLongitude());
				double num2 = actualDestinationHost.CurrentSpeed;
				if (GetAircraft().IsHelicopter)
				{
					double num3 = myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Full, bool_0: false);
					double val = Math.Max(num3 / 3.0, num2 + 30.0);
					myUnit.DesiredSpeed = (float)Math.Min(Math.Max(val, num3 * num), num3);
				}
				else
				{
					double num4 = (double)myUnit.Kinematics.GetMaximumSpeed(myUnit.GetCurrentAltitude(), ActiveUnit.Throttle.Loiter, bool_0: false) * 0.7;
					myUnit.DesiredSpeed = (float)(num4 + num);
				}
				GetAircraft().SetThrottle(GetAircraft().Kinematics.GetThrottleSuitableForThisSpeed(GetAircraft().GetCurrentAltitude(), (int)Math.Round(GetAircraft().DesiredSpeed)));
				myUnit.SetDesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.PublishClass(myUnit.GetLatitude(), myUnit.GetLongitude(), actualDestinationHost.GetLatitude(), actualDestinationHost.GetLongitude()));
				Waypoint waypoint_ = null;
				ExtendIfNecessary(float_0, ref waypoint_, actualDestinationHost.GetLatitude(), actualDestinationHost.GetLongitude(), 0f, 0f, myUnit.Kinematics.TurnRate());
				float num5 = (float)((double)actualDestinationHost.GetCurrentAltitude() + 100.0 * num);
				if (myUnit.DesiredAltitude >= num5)
				{
					myUnit.DesiredAltitude = num5;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100466", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool AboutToLand(float float_0)
	{
		try
		{
			ActiveUnit actualDestinationHost = GetAircraft().AirOps.ActualDestinationHost;
			if (Information.IsNothing(actualDestinationHost))
			{
				return false;
			}
			double num = Math2.VerifyClass(myUnit.GetLatitude(), myUnit.GetLongitude(), actualDestinationHost.GetLatitude(), actualDestinationHost.GetLongitude());
			return (double)(2f * myUnit.CurrentSpeed * float_0 / 3600f) > num;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100467", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return false;
		}
	}

	public override bool PathLineIsInterrupted(double double_0, double double_1, double double_2, double double_3, bool bool_1, float float_0, bool bool_2, int? nullable_0, bool bool_3, bool bool_4, bool bool_5, float? nullable_1, ref int int_0, ref GeoPoint geoPoint_0)
	{
		try
		{
			bool bool_8 = false;
			bool bool_9 = false;
			if (bool_2)
			{
				ActiveUnit activeUnit = myUnit;
				double latitude = myUnit.GetLatitude();
				double longitude = myUnit.GetLongitude();
				int int_ = 0;
				bool bool_10 = false;
				bool bool_11 = false;
				float? nullable_2 = 0f;
				List<ActiveUnit> list_ = null;
				string string_ = "";
				bool bool_6 = false;
				if (!activeUnit.CanMoveToThisLocation(latitude, longitude, ref int_, bool_3, bool_4, bool_5, ref bool_10, bool_4: false, ref bool_11, nullable_2, null, ref list_, 0f, bool_6: false, bool_7: false, ref string_, ref bool_6))
				{
					return false;
				}
			}
			if (base.PlottedCourse.Length != 0)
			{
				Waypoint waypoint = base.PlottedCourse[0];
				if ((waypoint.Type == Waypoint.WaypointType.Target || waypoint.Type == Waypoint.WaypointType.WeaponTarget) && waypoint.Creator == Waypoint.WaypointCreator.Pathfinder)
				{
					return false;
				}
			}
			if (myUnit.IsGroupWingman() && myUnit.GetParentGroup().GroupLead != null)
			{
				ActiveUnit groupLead = myUnit.GetParentGroup().GroupLead;
				bool? flag;
				if (groupLead.Navigator.PlottedCourse.Count() <= 0)
				{
					flag = false;
				}
				else
				{
					Waypoint waypoint2 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
					bool? flag4;
					bool? flag5 = (flag4 = ((waypoint2 == null) ? null : new bool?(waypoint2.Type == Waypoint.WaypointType.Target)));
					bool? flag6;
					bool? flag7;
					if (flag5.HasValue && flag4.GetValueOrDefault())
					{
						flag6 = true;
					}
					else
					{
						Waypoint waypoint3 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
						flag5 = (flag7 = ((waypoint3 == null) ? null : new bool?(waypoint3.Type == Waypoint.WaypointType.WeaponTarget)));
						flag6 = ((!flag5.HasValue) ? null : (flag7.GetValueOrDefault() | flag4));
					}
					bool? flag8 = flag6;
					flag7 = flag6;
					bool? flag9;
					bool? flag10;
					if (flag7.HasValue && flag8.GetValueOrDefault())
					{
						flag9 = true;
					}
					else
					{
						Waypoint waypoint4 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
						flag7 = (flag10 = ((waypoint4 == null) ? null : new bool?(waypoint4.Type == Waypoint.WaypointType.StrikeEgress)));
						flag9 = ((!flag7.HasValue) ? null : (flag10.GetValueOrDefault() | flag8));
					}
					bool? flag11 = flag9;
					flag10 = flag9;
					if (flag10.HasValue && flag11.GetValueOrDefault())
					{
						flag = true;
					}
					else
					{
						Waypoint waypoint5 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
						bool? flag2;
						flag10 = (flag2 = ((waypoint5 == null) ? null : new bool?(waypoint5.Type == Waypoint.WaypointType.Formate)));
						flag = ((!flag10.HasValue) ? null : (flag2.GetValueOrDefault() | flag11));
					}
				}
				bool? flag3 = flag;
				if (flag3.GetValueOrDefault(true))
				{
					Waypoint waypoint6 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
					if (waypoint6 != null && waypoint6.Creator == Waypoint.WaypointCreator.Pathfinder && flag3.HasValue)
					{
						return false;
					}
				}
			}
			if (TestDic(double_0, double_1, double_2, double_3, float_0))
			{
				return true;
			}
			float num = Math2.VerifyClass(double_0, double_1, double_2, double_3);
			if (!float.IsNaN(num) && num != 0f)
			{
				if (!nullable_1.HasValue)
				{
					nullable_1 = (myUnit.IsAircraft ? new float?(Pathfinding._AttrConsumer.DegreeInterval_Coarse) : ((num < myUnit.ParentScen.Navigation_FinegrainedMaxDistance) ? new float?(Pathfinding._AttrConsumer.DegreeInterval_Finegrained) : new float?(Pathfinding._AttrConsumer.DegreeInterval_Coarse)));
				}
				if (nullable_1.HasValue)
				{
					bool result = false;
					Angle angle_ = default(Angle);
					angle_.Degrees = double_1;
					Angle angle_2 = default(Angle);
					angle_2.Degrees = double_0;
					Angle angle_3 = default(Angle);
					angle_3.Degrees = double_3;
					Angle angle_4 = default(Angle);
					angle_4.Degrees = double_2;
					Angle angle_5 = World.ApproxAngularDistance(angle_2, angle_, angle_4, angle_3);
					float num2 = (float)angle_5.Degrees;
					float num3 = num2;
					float? num4 = nullable_1 * 2f;
					if ((num4.HasValue ? new bool?(num3 < num4.GetValueOrDefault()) : null).GetValueOrDefault())
					{
						return false;
					}
					int num5 = (int)Math.Round((num2 / nullable_1).Value);
					Angle angle_6 = default(Angle);
					Angle angle_7 = default(Angle);
					int num6 = num5;
					for (int i = 1; i <= num6; i++)
					{
						World.smethod_0(nullable_1.Value * (float)i / num2, angle_2, angle_, angle_4, angle_3, angle_5, out angle_7, out angle_6);
						double degrees = angle_7.Degrees;
						double degrees2 = angle_6.Degrees;
						ActiveUnit activeUnit2 = myUnit;
						int int_2 = 0;
						float? nullable_3 = nullable_0;
						List<ActiveUnit> list_2 = null;
						string string_2 = "";
						bool bool_7 = false;
						if (!activeUnit2.CanMoveToThisLocation(degrees, degrees2, ref int_2, bool_3, bool_4, bool_5, ref bool_9, bool_4: false, ref bool_8, nullable_3, null, ref list_2, float_0, bool_6: false, bool_7: false, ref string_2, ref bool_7))
						{
							if (bool_8)
							{
								int_0++;
							}
							if (bool_9)
							{
								int_0 += 2;
							}
							result = true;
							break;
						}
					}
					return result;
				}
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception exception_ = ex;
			exception_?.Data.Add("Error at 100468", "");
			GameGeneral.WriteExceptionsToLog(ref exception_);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
			return true;
		}
	}

	[CompilerGenerated]
	private bool RegisterProxy(Waypoint waypoint_0)
	{
		return Operators.CompareString(waypoint_0.ObjectID, myUnit.GetParentGroup().GroupLead.Navigator.PlottedCourse[0].ObjectID, TextCompare: false) == 0;
	}

	[CompilerGenerated]
	private bool ManageProxy(Waypoint waypoint_0)
	{
		return Operators.CompareString(waypoint_0.ObjectID, base.PlottedCourse[0].ObjectID, TextCompare: false) == 0;
	}
}
